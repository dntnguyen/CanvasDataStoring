using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.DatabaseHelper
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

        public ResponseResult GenerateTableInDatabase(string tableName, DataTable dtData)
        {
            var response = new ResponseResult();
            try
            {
                //syllabus_body
                var parameters = new DynamicParameters();
                parameters.Add("@TableName", tableName);

                string columnGenerateScript = "";
                foreach (DataColumn col in dtData.Columns)
                {
                    columnGenerateScript += $" {col.ColumnName} NVARCHAR(MAX) ,";
                }

                if (columnGenerateScript.Substring(columnGenerateScript.Length - 1, 1) == ",")
                {
                    columnGenerateScript = columnGenerateScript.Substring(0, columnGenerateScript.Length - 1);
                }

                string sqlScriptCreateTable = " IF NOT EXISTS(SELECT* FROM sysobjects WHERE name= '" + tableName + "' and xtype = 'U') " + 
    " BEGIN " +
        //" DROP TABLE " + tableName + 
        " CREATE TABLE " + tableName + "(" +
            columnGenerateScript +

            " ) " +
    " END " 
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
                        columnsScriptForInsert += $" {col.ColumnName},";
                    }
                    if (columnsScriptForInsert.Substring(columnsScriptForInsert.Length - 1, 1) == ",")
                    {
                        columnsScriptForInsert = columnsScriptForInsert.Substring(0, columnsScriptForInsert.Length - 1);
                    }

                    string valueScript = " VALUES ";

                    foreach (DataRow row in dtData.Rows)
                    {
                        valueScript += Environment.NewLine;

                        string valueChildString = "";
                        foreach (DataColumn col in dtData.Columns)
                        {
                            valueChildString += $"N'{row[col]}',";
                        }
                        if (valueChildString.Substring(valueChildString.Length - 1, 1) == ",")
                        {
                            valueChildString = valueChildString.Substring(0, valueChildString.Length - 1);
                        }
                        valueScript += $" ({valueChildString}),";
                    }

                    if (columnsScriptForInsert.Substring(columnsScriptForInsert.Length - 1, 1) == ",")
                    {
                        columnsScriptForInsert = columnsScriptForInsert.Substring(0, columnsScriptForInsert.Length - 1);
                    }

                    string insertScript = $"INSERT INTO {tableName} ({columnsScriptForInsert}) {valueScript}";

                    sqlConnection.Execute(insertScript,

                        parameters,
                        commandType: CommandType.Text,
                        commandTimeout: 180);
                }
            }
            catch (Exception ex)
            {
                response.ResultCode = ResponseResultCode.Ok;
                response.ResultDescription = "Failed to update data. Description: " + ex.Message;
            }

            return response;
        }
    }
}
