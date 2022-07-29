using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.DatabaseHelper
{
    public static class MyConnection
    {
        public const int DEFAULT_QUERY_TIMEOUT_IN_SECOND = 30;

        private static string GlobalConnectionString = "";

        public static void SetGlobalConnectionString(string connectionString)
        {
            GlobalConnectionString = connectionString;
        }

        public static string GetGlobalConnectionString()
        {
            return GlobalConnectionString;
        }
    }
}
