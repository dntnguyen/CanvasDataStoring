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
            pTableName = base.ReplaceSpecialTextInDatabase(nameof(TableSync));
        }

        public ResponseResult<List<TableSync>> GetAll()
        {
            return base.GetAll<TableSync>(pTableName);
        }

        public TableSync GetTableSync(string tableName)
        {
            using (var sqlConnection = new SqlConnection(pDefaultConnectionString))
            {
                sqlConnection.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@TableName", tableName);

                var result = sqlConnection.QueryFirstOrDefault<TableSync>(this.GetSqlQueryTableInTableSync(),
                    parameters,
                    commandType: CommandType.Text,
                    commandTimeout: pDefaultQueryTimeoutInSecond);

                return result;
            }
        }

        private string GetSqlQueryTableInTableSync()
        {
            return $" SELECT * FROM {pTableName} WHERE TableName = @TableName " + Environment.NewLine;
        }

        public TableSync AddTableToTableSync(string tableNameToAdd)
        {
            string query = base.GetSqlQuery_CreateTableInTableSyncIfNotExists();
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
