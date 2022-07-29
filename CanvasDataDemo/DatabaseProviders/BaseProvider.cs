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

        protected string pTableName = string.Empty;

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
            string result = input;
            switch (input)
            {
                case "public":
                case "user":
                    result = input + "x";
                    break;
                default:
                    break;
            }

            return result;
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

        protected string GetSqlQuery_CreateTableInTableSyncIfNotExists()
        {
            string sqlUpdateTableSync = "";
            sqlUpdateTableSync += $" IF NOT EXISTS(SELECT 1 FROM dbo.TableSync WHERE TableName = @TableName) " + Environment.NewLine;
            sqlUpdateTableSync += " BEGIN " + Environment.NewLine;
            sqlUpdateTableSync += $"     INSERT INTO dbo.TableSync (TableName) VALUES (@TableName) " + Environment.NewLine;
            sqlUpdateTableSync += " END " + Environment.NewLine;

            return sqlUpdateTableSync;
        }

        protected virtual void InsertDataToTable(string tableName, int sequence, DataTable dtData)
        {
            //Create Table And Columns
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

                        " ) "
                ;

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
                        commandTimeout: pDefaultQueryTimeoutInSecond
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
                        commandTimeout: pDefaultQueryTimeoutInSecond
                    );
                }

                string paramTableName = "@TableName";
                string paramSequence = "@Sequence";

                string sqlUpdateTableSync = "";
                sqlUpdateTableSync += this.GetSqlQuery_CreateTableInTableSyncIfNotExists();
                sqlUpdateTableSync += $" UPDATE dbo.TableSync SET Sequence = {paramSequence} WHERE TableName = {paramTableName} " + Environment.NewLine;
                sqlUpdateTableSync += " GO " + Environment.NewLine;

                var tableSyncParams = new DynamicParameters();
                tableSyncParams.Add(paramTableName, tableName);
                tableSyncParams.Add(paramSequence, sequence);

                sqlConnection.Execute(sql: sqlUpdateTableSync,
                        param: tableSyncParams,
                        commandType: CommandType.Text,
                        commandTimeout: pDefaultQueryTimeoutInSecond
                    );

                // Attempt to commit the transaction.
                transaction.Commit();
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
            }
        }
    }
}
