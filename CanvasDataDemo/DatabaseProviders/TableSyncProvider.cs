using CanvasDataDemo.DatabaseHelper;
using CanvasDataDemo.Datas;
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
    public class TableSyncProvider : BaseProvider
    {
        public TableSyncProvider()
        {
        }

        public TableSync GetTableSync(string tableName)
        {
            using (var sqlConnection = new SqlConnection(pDefaultConnectionString))
            {
                sqlConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@TableName", tableName);

                var query = base.GetCreatedDefaultDatabaseTables();
                query += this.GetSqlQueryTableInTableSync();

                var result = sqlConnection.QueryFirstOrDefault<TableSync>(
                    query,
                    parameters,
                    commandType: CommandType.Text,
                    commandTimeout: pDefaultQueryTimeoutInSecond);

                return result;
            }
        }

        private string GetSqlQueryTableInTableSync()
        {
            return $" SELECT * FROM dbo.TableSync WHERE TableName = @TableName " + Environment.NewLine;
        }

        public TableSync AddTableToTableSync(string tableNameToAdd)
        {

            string query = base.GetCreatedDefaultDatabaseTables();
            query += base.GetSqlQuery_CreateTableRecordInTableSyncIfNotExists();
            query += this.GetSqlQueryTableInTableSync();


            using (var sqlConnection = new SqlConnection(pDefaultConnectionString))
            {
                sqlConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@TableName", tableNameToAdd);

                var result = sqlConnection.QueryFirstOrDefault<TableSync>(query,
                    parameters,
                    commandType: CommandType.Text,
                    commandTimeout: pDefaultQueryTimeoutInSecond);

                return result;
            }
        }
    }
}
