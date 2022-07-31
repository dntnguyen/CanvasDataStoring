using CanvasDataDemo.Models;
using System;
using System.Collections.Generic;

namespace CanvasDataDemo.Utilities
{
    public interface ICanvasDataApiHelper
    {
        ResponseResult<IEnumerable<TableSchema>> GetLatestTableSchema(string apiKey, string apiSecret, string url);

        ResponseResult GetTableFileContentJson(string apiKey, string apiSecret, string apiUrl, string tableName);

        ResponseResult<TableFile> GetTableFile(string apiKey, string apiSecret, string apiUrl, string tableName);
    }
}