using CanvasDataDemo.Models;
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
        public void WriteSettingToFile(Setting setting)
        {
            string content = JsonSerializer.Serialize(setting);
            File.WriteAllText(CANVAS_DATA_EXPLORER_APPSETTING_FILENAME, content);
        }

        public ResponseResult<Setting> GetSettingFromFile()
        {
            var result = new ResponseResult<Setting>();

            File.AppendAllText(CANVAS_DATA_EXPLORER_APPSETTING_FILENAME, string.Empty);
            string content = File.ReadAllText(CANVAS_DATA_EXPLORER_APPSETTING_FILENAME);

            try
            {
                result.ResultValue = JsonSerializer.Deserialize<Setting>(content);
                result.ResultDescription = "Succeeded";
                result.ResultCode = ResponseResultCode.Ok;
            }
            catch
            {
                result.ResultCode = ResponseResultCode.Fail;
                result.ResultDescription = "Failed to parse text data to Setting";
            }

            return result;
        }
    }
}
