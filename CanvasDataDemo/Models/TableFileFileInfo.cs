using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class TableFileFileInfo
    {
        public string? Url { get; set; }

        public string? FileName { get; set; }

        public bool IsCannotDownload()
        {
            return string.IsNullOrEmpty(Url) || string.IsNullOrEmpty(FileName);
        }
    }
}
