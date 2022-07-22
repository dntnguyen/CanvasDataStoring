using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemoNetFramework.DatabaseHelper
{
    public class MyDatabaseProvider
    {
        private string _connectionString = "";
        private int _defaultQueryTimeoutInSecond = MyConnection.DEFAULT_QUERY_TIMEOUT_IN_SECOND;

        public MyDatabaseProvider(string connectionString = "")
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                _connectionString = MyConnection.GlobalConnectionString;
            }
            else
            {
                _connectionString = connectionString;
            }
        }

        public void SetQueryTimeout(int seconds)
        {
            _defaultQueryTimeoutInSecond = seconds;
        }

        private string ReplaceSpecialTextInDatabase(string input)
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

        public ResponseResult GenerateTableInDatabase(string tableName, DataTable dtData)
        {
            var response = new ResponseResult();
            response.ResultCode = ResponseResultCode.Ok;
            object testValue;
            try
            {
                //syllabus_body
                var parameters = new DynamicParameters();
                parameters.Add("@TableName", ReplaceSpecialTextInDatabase(tableName));

                string columnGenerateScript = "";
                foreach (DataColumn col in dtData.Columns)
                {
                    columnGenerateScript += $" {ReplaceSpecialTextInDatabase(col.ColumnName)} NVARCHAR(MAX) ,";
                }

                if (columnGenerateScript.Substring(columnGenerateScript.Length - 1, 1) == ",")
                {
                    columnGenerateScript = columnGenerateScript.Substring(0, columnGenerateScript.Length - 1);
                }

                string sqlScriptCreateTable = " IF EXISTS(SELECT* FROM sysobjects WHERE name= '" + ReplaceSpecialTextInDatabase(tableName) + "' and xtype = 'U') " +
    " BEGIN " +
        " DROP TABLE " + ReplaceSpecialTextInDatabase(tableName) +
    " END " +
    " CREATE TABLE " + ReplaceSpecialTextInDatabase(tableName) + "(" +
            columnGenerateScript +

            " ) "
    ;

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();

                    sqlConnection.Execute(sqlScriptCreateTable,

                        parameters,
                        commandType: CommandType.Text,
                        commandTimeout: _defaultQueryTimeoutInSecond);
           

                    string columnsScriptForInsert = "";
                    foreach (DataColumn col in dtData.Columns)
                    {
                        columnsScriptForInsert += $" {ReplaceSpecialTextInDatabase(col.ColumnName)},";
                    }
                    if (columnsScriptForInsert.Substring(columnsScriptForInsert.Length - 1, 1) == ",")
                    {
                        columnsScriptForInsert = columnsScriptForInsert.Substring(0, columnsScriptForInsert.Length - 1);
                    }


                    foreach (DataRow row in dtData.Rows)
                    {
                        var insertParameters = new DynamicParameters();

                        string valueScript = " VALUES ";
                        valueScript += Environment.NewLine;

                        string valueChildString = "";
                        foreach (DataColumn col in dtData.Columns)
                        {
                            ////valueChildString += $"N'{row[col]}',";
                            var insertParamName = $"@{ReplaceSpecialTextInDatabase(col.ColumnName)}";
                            valueChildString += $"{insertParamName},";
                            testValue = row[col];
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
                        ////valueScript += $" ({valueChildString}),";

                        valueScript += $" ({valueChildString})";

                        string insertScript = $"INSERT INTO {ReplaceSpecialTextInDatabase(tableName)} ({columnsScriptForInsert}) {valueScript}";

                        sqlConnection.Execute(insertScript,

                            insertParameters,
                            commandType: CommandType.Text,
                            commandTimeout: 180);
                    }

                    ////if (columnsScriptForInsert.Substring(columnsScriptForInsert.Length - 1, 1) == ",")
                    ////{
                    ////    columnsScriptForInsert = columnsScriptForInsert.Substring(0, columnsScriptForInsert.Length - 1);
                    ////}

                    ////string insertScript = $"INSERT INTO {tableName} ({columnsScriptForInsert}) {valueScript}";

                    ////sqlConnection.Execute(insertScript,

                    ////    parameters,
                    ////    commandType: CommandType.Text,
                    ////    commandTimeout: 180);
                }
            }
            catch (Exception ex)
            {
                response.ResultCode = ResponseResultCode.Fail;
                response.ResultDescription = "Failed to update data. Description: " + ex.Message;
            }

            return response;
        }
    }
}
