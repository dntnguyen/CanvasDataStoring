using CanvasDataDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CanvasDataDemo.Utilities
{
    public class CanvasDataApiHelper : ICanvasDataApiHelper
    {
        public IEnumerable<TableSchema> GetLatestTableSchema(string apiKey, string apiSecret, string url)
        {
            string json = GetCanvasDataApiContentJson(apiKey, apiSecret, url);
            return null;
        }

        private string GetCanvasDataApiContentJson(string apiKey, string apiSecret, string url)
        {
            var request = GetWebRequest(apiKey, apiSecret, DateTime.Now, url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            using (var reader = new StreamReader(dataStream))
            {
                return reader.ReadToEnd();
            }

        }

        private HttpWebRequest GetWebRequest(string apiKey, string apiSecret, DateTime timestamp, string url)
        {
            var signature = HmacHelper.GenerateHMACSignature(apiSecret, url, timestamp);
            var request = WebRequest.CreateHttp(url);
            request.Headers["Authorization"] = $"HMACAuth {apiKey}:{signature}";
            request.Date = timestamp;
            return request;
        }
    }
}
