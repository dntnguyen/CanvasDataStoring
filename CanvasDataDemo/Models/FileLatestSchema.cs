using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class FileLatestSchema
    {
        public string TableName { get; set; }

        public FileLatestSchemaFileInfo FileInfo { get; set; } = new FileLatestSchemaFileInfo();
    }

    public class FileLatestSchemaFileInfo
    {
        public string Url { get; set; }

        public string FileName { get; set; }
    }
}
