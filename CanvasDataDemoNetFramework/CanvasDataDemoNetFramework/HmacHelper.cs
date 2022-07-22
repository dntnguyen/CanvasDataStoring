using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemoNetFramework
{
    public class HmacHelper
    {
        public static string GenerateHMACSignature(string secret, string url, DateTime timestamp)
        {
            var uri = new Uri(url);
            string query = "";
            if (uri.Query.Length > 1)
            {
                var queryParams = uri.Query.Substring(1).Split('&').OrderBy(q => q);
                query = Combine(queryParams, "&");
            }
            var parts = $"GET\n{uri.Host}\n\n\n{uri.AbsolutePath}\n{query}\n{timestamp.ToUniversalTime().ToString("r")}\n{secret}";

            using (HMACSHA256 hmac = new HMACSHA256(Encoding.Default.GetBytes(secret)))
            {
                var hash = hmac.ComputeHash(Encoding.Default.GetBytes(parts));
                return Convert.ToBase64String(hash);
            }
        }

        private static string Combine(IOrderedEnumerable<string> queryParams, string separator)
        {
            string query = "";
            foreach (var para in queryParams)
            {
                query += $"{separator}{para}";
            }
            if (query.Substring(0, 1) == separator)
            {
                query = query.Substring(1);
            }

            return query;
        }
    }
}
