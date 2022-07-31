using CanvasDataDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ResponseResult<IEnumerable<TableSchema>> GetLatestTableSchema(string apiKey, string apiSecret, string apiUrl)
        {
            var resultGetLatestTableSchema = new ResponseResult<IEnumerable<TableSchema>>();
            resultGetLatestTableSchema.ResultCode = ResponseResultCode.NoResult;
            resultGetLatestTableSchema.ResultDescription = "No Result";

            ResponseResult resultGetData = GetCanvasDataApiContentJson(apiKey, apiSecret, apiUrl);

            if (resultGetData.ResultCode != ResponseResultCode.Ok)
            {
                resultGetLatestTableSchema.CopyResult(resultGetData);
                return resultGetLatestTableSchema;
            }

            string json = resultGetData.ResultValue as string;

            var listTableSchema = new List<TableSchema>();

            using var doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("schema", out JsonElement schemaJsonEle))
            {
                var schemaEle = schemaJsonEle.EnumerateObject();
                while (schemaEle.MoveNext())
                {
                    var schemaProperty = schemaEle.Current;

                    var tableSchema = new TableSchema();

                    if (schemaProperty.Value.TryGetProperty("tableName", out JsonElement tableNameEle))
                    {
                        tableSchema.TableName = tableNameEle.GetString();
                    }
                    if (schemaProperty.Value.TryGetProperty("dw_type", out JsonElement dwTypeEle))
                    {
                        tableSchema.DwType = dwTypeEle.GetString();
                    }
                    if (schemaProperty.Value.TryGetProperty("description", out JsonElement descriptionEle))
                    {
                        tableSchema.Description = descriptionEle.GetString();
                    }
                    if (schemaProperty.Value.TryGetProperty("incremental", out JsonElement incrementalEle))
                    {
                        tableSchema.Incremental = incrementalEle.ValueKind == JsonValueKind.True ? true : false;
                    }
                    if (schemaProperty.Value.TryGetProperty("columns", out JsonElement columnsEle))
                    {
                        var columnArrays = columnsEle.EnumerateArray();
                        while (columnArrays.MoveNext())
                        {
                            var columnObjectEle = columnArrays.Current;

                            var column = new TableSchemaColumn();

                            if (columnObjectEle.TryGetProperty("type", out JsonElement columnType))
                            {
                                column.Type = columnType.GetString();
                            }

                            if (columnObjectEle.TryGetProperty("description", out JsonElement columnDescription))
                            {
                                column.Description = columnDescription.GetString();
                            }

                            if (columnObjectEle.TryGetProperty("name", out JsonElement columnName))
                            {
                                column.Name = columnName.GetString();
                            }

                            if (columnObjectEle.TryGetProperty("length", out JsonElement columnLength))
                            {
                                if (columnLength.TryGetInt32(out int columnLengthValue))
                                {
                                    column.Length = columnLengthValue;
                                }
                            }

                            tableSchema.ListColumn.Add(column);
                        }
                    }
                    listTableSchema.Add(tableSchema);
                }
            }

            resultGetLatestTableSchema.ResultCode = ResponseResultCode.Ok;
            resultGetLatestTableSchema.ResultValue = listTableSchema;
            return resultGetLatestTableSchema;
        }

        public ResponseResult GetTableFileContentJson(string apiKey, string apiSecret, string apiUrl, string tableName)
        {
            string replaceUrlWithTableName = apiUrl.Replace(":tableName", tableName);

            return GetCanvasDataApiContentJson(apiKey, apiSecret, replaceUrlWithTableName);
        }

        public ResponseResult<TableFile> GetTableFile(string apiKey, string apiSecret, string apiUrl, string tableName)
        {
            var resultGetTableFile = new ResponseResult<TableFile>();
            resultGetTableFile.ResultCode = ResponseResultCode.NoResult;
            resultGetTableFile.ResultDescription = "No Result";

            ResponseResult resultGetData = GetTableFileContentJson(apiKey, apiSecret, apiUrl, tableName);

            if (resultGetData.ResultCode != ResponseResultCode.Ok)
            {
                resultGetTableFile.CopyResult(resultGetData);
                return resultGetTableFile;
            }

            string json = resultGetData.ResultValue as string;

            var tableFileSchema = new TableFile();

            using var doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("table", out JsonElement tableJsonEle))
            {
                tableFileSchema.TableName = tableJsonEle.GetString();

            }
            if (root.TryGetProperty("history", out JsonElement historyJsonEle))
            {
                var historyArraysEle = historyJsonEle.EnumerateArray();
                while (historyArraysEle.MoveNext())
                {
                    var historyObjectEle = historyArraysEle.Current;

                    var his = new TableFileHistory();

                    if (historyObjectEle.TryGetProperty("dumpId", out JsonElement dumpId))
                    {
                        his.DumpId = dumpId.GetString();
                    }

                    if (historyObjectEle.TryGetProperty("partial", out JsonElement partial))
                    {
                        his.Partial = partial.ValueKind == JsonValueKind.True ? true : false;
                    }

                    if (historyObjectEle.TryGetProperty("sequence", out JsonElement sequence))
                    {
                        his.Sequence = sequence.GetInt32();
                    }

                    if (historyObjectEle.TryGetProperty("files", out JsonElement files))
                    {
                        var fileArraysEle = files.EnumerateArray();
                        while (fileArraysEle.MoveNext())
                        {
                            var fileObjectEle = fileArraysEle.Current;

                            if (fileObjectEle.TryGetProperty("url", out JsonElement url))
                            {
                                his.FileInfo.Url = url.GetString();
                            }

                            if (fileObjectEle.TryGetProperty("filename", out JsonElement filename))
                            {
                                his.FileInfo.FileName = filename.GetString();
                            }
                            //Loop 1 lần
                            break;
                        }
                    }

                    tableFileSchema.ListHistory.Add(his);
                }
            }

            resultGetTableFile.ResultCode = ResponseResultCode.Ok;
            resultGetTableFile.ResultValue = tableFileSchema;
            return resultGetTableFile;
        }

        private ResponseResult GetCanvasDataApiContentJson(string apiKey, string apiSecret, string apiUrl)
        {
            var result = new ResponseResult();
            result.ResultCode = ResponseResultCode.NoResult;
            result.ResultDescription = "No Result";
            try
            {
                var request = GetWebRequest(apiKey, apiSecret, DateTime.Now, apiUrl);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                using (var reader = new StreamReader(dataStream))
                {
                    result.ResultValue = reader.ReadToEnd();
                    result.ResultDescription = "Succeeded";
                    result.ResultCode = ResponseResultCode.Ok;
                }
            }
            catch (Exception ex)
            {
                result.ResultDescription = $"Failed to get content json {ex.Message}"; 
                result.ResultCode = ResponseResultCode.Fail; 
            }

            return result;
        }

        private HttpWebRequest GetWebRequest(string apiKey, string apiSecret, DateTime timestamp, string apiUrl)
        {
            var signature = HmacHelper.GenerateHMACSignature(apiSecret, apiUrl, timestamp);
            var request = WebRequest.CreateHttp(apiUrl);
            request.Headers["Authorization"] = $"HMACAuth {apiKey}:{signature}";
            request.Date = timestamp;
            return request;
        }
    }
}
