using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Datas
{
    public class TableSyncHistory : IHasCreationTime
    {
        public string TableName { get; set; }

        public int? Sequence { get; set; }

        public bool? Partial { get; set; }

        public DateTime? CreationTime { get; set; }
    }
}
