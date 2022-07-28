using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class TableSchema
    {
        public string? TableName { get; set; }

        public string? DwType { get; set; }

        public string? Description { get; set; }

        public bool Incremental { get; set; }

        public List<TableSchemaColumn> ListColumn { get; set; } = new List<TableSchemaColumn>();
    }
}
