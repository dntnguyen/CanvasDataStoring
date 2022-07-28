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
    public interface ISettingHelper
    {
        void WriteSettingToFile(Setting setting);

        ResponseResult<Setting> GetSettingFromFile();
    }
}
