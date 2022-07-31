using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Views
{
    public interface IMainFormSettingView
    {
        string? SqlConnectionString { get; set; }

        string? ApiKey { get; set; }

        string? ApiSecret { get; set; }

        string? TableFileUrl { get; set; }

        string? LatestTableSchemaUrl { get; set; }

        bool GenerateJsonFile { get; set; }

        bool RunWhenWindowsStarts { get; set; }

        DateTime AutoGetDataEverydayAt { get; set; }
    }
}
