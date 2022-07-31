using CanvasDataDemo.DatabaseHelper;
using CanvasDataDemo.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.DatabaseProviders
{
    public class BaseProvider
    {
        protected int pDefaultQueryTimeoutInSecond = MyConnection.DEFAULT_QUERY_TIMEOUT_IN_SECOND;

        protected string pDefaultConnectionString = string.Empty;

        public BaseProvider()
        {
            pDefaultConnectionString = MyConnection.GetGlobalConnectionString();
        }

        public void SetQueryTimeout(int seconds)
        {
            pDefaultQueryTimeoutInSecond = seconds;
        }

        protected string ReplaceSpecialTextInDatabase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            string temp = input;
            temp = temp.Trim().ToLower();
            switch (temp)
            {
                case "public":
                case "percent":
                case "max":
                case "user":
                    input = input + "x";
                    break;
                default:
                    break;
            }

            return input;
        }

        protected ResponseResult<List<T>> GetAll<T>(string tableName)
        {
            var response = new ResponseResult<List<T>>();
            response.ResultCode = ResponseResultCode.NoResult;
            response.ResultDescription = "No data";
            try
            {
                using (var sqlConnection = new SqlConnection(MyConnection.GetGlobalConnectionString()))
                {
                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    ////parameters.Add("@RID", filter.RID);

                    var result = sqlConnection.Query<T>($"SELECT * FROM {tableName}",
                        parameters,
                        commandType: CommandType.Text,
                        commandTimeout: pDefaultQueryTimeoutInSecond);

                    if (result != null)
                    {
                        response.ResultCode = ResponseResultCode.Ok;
                        response.ResultDescription = "Get data successfully";
                        response.ResultValue = result.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResultCode = ResponseResultCode.Fail;
                response.ResultDescription = "Failed to get data from database. Description: " + ex.Message;
            }

            return response;
        }

        protected string GetSqlQuery_CreateTableRecordInTableSyncIfNotExists()
        {
            string sqlUpdateTableSync = "";
            sqlUpdateTableSync += $" IF NOT EXISTS(SELECT 1 FROM dbo.TableSync WHERE TableName = @TableName) " + Environment.NewLine;
            sqlUpdateTableSync += " BEGIN " + Environment.NewLine;
            sqlUpdateTableSync += $"     INSERT INTO dbo.TableSync (TableName, CreationTime) VALUES (@TableName, GETDATE()) " + Environment.NewLine;
            sqlUpdateTableSync += " END " + Environment.NewLine;

            return sqlUpdateTableSync;
        }

        public virtual ResponseResult InsertDataToTable(TableSchema tableSchema, TableFileHistory tableFileHistory, DataTable dtData)
        {
            var res = new ResponseResult();
            res.ResultCode = ResponseResultCode.NoResult;
            res.ResultDescription = "No Result";

            //Create Table And Columns
            var tableName = tableSchema.TableName;
            var sequence = tableFileHistory.Sequence;

            var createTableColumnParameters = new DynamicParameters();
            createTableColumnParameters.Add("@TableName", this.ReplaceSpecialTextInDatabase(tableName));

            string columnGenerateScript = "";
            foreach (DataColumn col in dtData.Columns)
            {
                columnGenerateScript += $" {ReplaceSpecialTextInDatabase(col.ColumnName)} NVARCHAR(MAX) ,";
            }

            if (columnGenerateScript.Substring(columnGenerateScript.Length - 1, 1) == ",")
            {
                columnGenerateScript = columnGenerateScript.Substring(0, columnGenerateScript.Length - 1);
            }

            string sqlScriptCreateTable = " IF NOT EXISTS(SELECT* FROM sysobjects WHERE name= '" + ReplaceSpecialTextInDatabase(tableName) + "' and xtype = 'U') " +
                " CREATE TABLE " + ReplaceSpecialTextInDatabase(tableName) + "(" +
                        columnGenerateScript +
                        " ) " + Environment.NewLine
                ;


            string sqlScriptDeleteTableDataIfNotPartial = "";
            if (tableFileHistory.Partial == false)
            {
                sqlScriptDeleteTableDataIfNotPartial = $" DELETE FROM {ReplaceSpecialTextInDatabase(tableName)} WHERE 2 = 2 ";
            }

            sqlScriptCreateTable += sqlScriptDeleteTableDataIfNotPartial;

            // Generate Column Insert Data
            string columnsScriptForInsert = "";
            foreach (DataColumn col in dtData.Columns)
            {
                columnsScriptForInsert += $" {ReplaceSpecialTextInDatabase(col.ColumnName)},";
            }
            if (columnsScriptForInsert.Substring(columnsScriptForInsert.Length - 1, 1) == ",")
            {
                columnsScriptForInsert = columnsScriptForInsert.Substring(0, columnsScriptForInsert.Length - 1);
            }

            var sqlConnection = new SqlConnection(pDefaultConnectionString);
            SqlTransaction transaction = null;

            try
            {
                sqlConnection.Open();
                transaction = sqlConnection.BeginTransaction();

                sqlConnection.Execute(sql: sqlScriptCreateTable,
                        param: createTableColumnParameters,
                        commandType: CommandType.Text,
                        commandTimeout: pDefaultQueryTimeoutInSecond,
                        transaction: transaction
                    );

                // Generate Data Values To Insert
                foreach (DataRow row in dtData.Rows)
                {
                    var insertParameters = new DynamicParameters();

                    string valueScript = " VALUES ";
                    valueScript += Environment.NewLine;

                    string valueChildString = "";
                    foreach (DataColumn col in dtData.Columns)
                    {
                        var insertParamName = $"@{ReplaceSpecialTextInDatabase(col.ColumnName)}";
                        valueChildString += $"{insertParamName},";

                        if (row.IsNull(col) || string.IsNullOrEmpty(row[col].ToString()))
                        {
                            insertParameters.Add(insertParamName, DBNull.Value, DbType.String);
                        }
                        else
                        {
                            insertParameters.Add(insertParamName, row[col]);
                        }
                    }
                    if (valueChildString.Substring(valueChildString.Length - 1, 1) == ",")
                    {
                        valueChildString = valueChildString.Substring(0, valueChildString.Length - 1);
                    }

                    valueScript += $" ({valueChildString})";

                    string insertScript = $"INSERT INTO {ReplaceSpecialTextInDatabase(tableName)} ({columnsScriptForInsert}) {valueScript}";

                    sqlConnection.Execute(sql: insertScript,
                        param: insertParameters,
                        commandType: CommandType.Text,
                        commandTimeout: pDefaultQueryTimeoutInSecond,
                        transaction: transaction
                    );
                }

                string paramTableName = "@TableName";
                string paramSequence = "@Sequence";

                string sqlUpdateTableSync = GetCreatedDefaultDatabaseTables();
                sqlUpdateTableSync += this.GetSqlQuery_CreateTableRecordInTableSyncIfNotExists();
                sqlUpdateTableSync += $" UPDATE dbo.TableSync SET LatestSequence = {paramSequence}, LastModificationTime = GETDATE() WHERE TableName = {paramTableName} " + Environment.NewLine;
                //sqlUpdateTableSync += " GO " + Environment.NewLine;

                var tableSyncParams = new DynamicParameters();
                tableSyncParams.Add(paramTableName, tableName);
                tableSyncParams.Add(paramSequence, sequence);

                sqlConnection.Execute(sql: sqlUpdateTableSync,
                        param: tableSyncParams,
                        commandType: CommandType.Text,
                        commandTimeout: pDefaultQueryTimeoutInSecond,
                        transaction: transaction
                    );

                // Attempt to commit the transaction.
                transaction.Commit();

                res.ResultCode = ResponseResultCode.Ok;
                res.ResultDescription = "Succeeded";
            }
            catch (Exception ex)
            {
                try
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception ex2)
                {
                    // This catch block will handle any errors that may have occurred
                    // on the server that would cause the rollback to fail, such as
                    // a closed connection.
                }

                res.ResultCode = ResponseResultCode.Fail;
                res.ResultDescription = $"Error: {ex.Message}";
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return res;
        }

        protected string GetCreatedDefaultDatabaseTables()
        {
            var query =
            " IF NOT EXISTS " + Environment.NewLine +
            "( " + Environment.NewLine +
            "SELECT * " + Environment.NewLine +
            "FROM INFORMATION_SCHEMA.TABLES " + Environment.NewLine +
            "WHERE TABLE_SCHEMA = 'dbo' " + Environment.NewLine +
            "AND  TABLE_NAME = 'TableSync' " + Environment.NewLine +
            ") " + Environment.NewLine +
            "BEGIN " + Environment.NewLine +
                "CREATE TABLE[dbo].[TableSync]( " + Environment.NewLine +
                "[TableName][varchar](50) NOT NULL, " + Environment.NewLine +
                "[LatestSequence] [int] NULL, " + Environment.NewLine +
                "[CreationTime][datetime] NULL, " + Environment.NewLine +
                "[LastModificationTime][datetime] NULL, " + Environment.NewLine +
                "CONSTRAINT[PK_TableSyncs] PRIMARY KEY CLUSTERED " + Environment.NewLine +
                "( " + Environment.NewLine +
                "[TableName] ASC " + Environment.NewLine +
                ")WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] " + Environment.NewLine +
                ") ON[PRIMARY] " + Environment.NewLine +
            "END " + Environment.NewLine +
            "ELSE " + Environment.NewLine +
            "BEGIN " + Environment.NewLine +
                "PRINT('--------Table Existed--------') " + Environment.NewLine +
            "END" + Environment.NewLine;

            return query;
        }
    }
}
