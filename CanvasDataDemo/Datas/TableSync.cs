using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Datas
{
    public class TableSync : IHasCreationTime, IHasModificationTime
    {
        public string TableName { get; set; }

        public int? LatestSequence { get; set; }

        public DateTime? CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
