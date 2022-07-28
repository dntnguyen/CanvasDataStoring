using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class TableSchemaColumn
    {
        public string? Name { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public int? Length { get; set; }
    }
}
