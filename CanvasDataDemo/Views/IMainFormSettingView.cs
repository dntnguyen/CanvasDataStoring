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

    }
}
