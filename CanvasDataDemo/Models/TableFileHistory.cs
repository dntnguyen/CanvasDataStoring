using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class TableFileHistory
    {
        public string? DumpId { get; set; }

        public bool Partial { get; set; }

        public int Sequence { get; set; }

        public TableFileFileInfo FileInfo { get; set; } = new TableFileFileInfo();
    }
}
