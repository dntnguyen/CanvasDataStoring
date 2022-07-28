using System;

namespace CanvasDataDemo.Utilities
{
    public interface ICanvasDataApiHelper
    {
        string GetFileLatestSchema(string apiKey, string apiSecret, string url);
    }
}