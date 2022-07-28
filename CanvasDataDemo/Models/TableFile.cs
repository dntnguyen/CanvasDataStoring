using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class TableFile
    {
        public string? TableName { get; set; }

        public List<TableFileHistory> ListHistory { get; set; } = new List<TableFileHistory>();
    }
}
