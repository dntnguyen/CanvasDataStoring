using CanvasDataDemo.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CanvasDataDemo.Utilities
{
    public class SettingHelper : ISettingHelper
    {
        private const string CANVAS_DATA_EXPLORER_APPSETTING_FILENAME = "canvas_data_appsetting.json";
        private readonly ILogger<MainForm> _logger;

        public SettingHelper(ILogger<MainForm> logger)
        {
            this._logger = logger;
        }

        public void WriteSettingToFile(Setting setting)
        {
            try
            {
                string content = JsonSerializer.Serialize(setting);
                File.WriteAllText(CANVAS_DATA_EXPLORER_APPSETTING_FILENAME, content);
            }
            catch (Exception ex)
            {
                _logger.LogError("WriteSettingToFile: " + ex.Message);
            }
        }

        public ResponseResult<Setting> GetSettingFromFile()
        {
            var result = new ResponseResult<Setting>();
            string content;
            try
            {
                File.AppendAllText(CANVAS_DATA_EXPLORER_APPSETTING_FILENAME, string.Empty);
                content = File.ReadAllText(CANVAS_DATA_EXPLORER_APPSETTING_FILENAME);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetSettingFromFile: " + ex.Message);
                result.ResultCode = ResponseResultCode.Fail;
                result.ResultDescription = "Failed to Append/Read data to Setting";
                return result;
            }

            try
            {
                result.ResultValue = JsonSerializer.Deserialize<Setting>(content);
                result.ResultDescription = "Succeeded";
                result.ResultCode = ResponseResultCode.Ok;
            }
            catch (Exception ex)
            {
                _logger.LogError("GetSettingFromFile: " + ex.Message);
                result.ResultCode = ResponseResultCode.Fail;
                result.ResultDescription = "Failed to parse text data to Setting";
            }

            return result;
        }
    }
}
