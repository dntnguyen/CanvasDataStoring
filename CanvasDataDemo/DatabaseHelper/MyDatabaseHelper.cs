using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.DatabaseHelper
{
    public class MyDatabaseHelper
    {
        public static string TestConnection(string sqlConnectionString)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(sqlConnectionString))
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }
    }
}
