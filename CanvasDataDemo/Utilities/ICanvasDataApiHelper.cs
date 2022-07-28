using CanvasDataDemo.Models;
using System;
using System.Collections.Generic;

namespace CanvasDataDemo.Utilities
{
    public interface ICanvasDataApiHelper
    {
        IEnumerable<TableSchema> GetLatestTableSchema(string apiKey, string apiSecret, string url);
    }
}