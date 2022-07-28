using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.Models
{
    public class Setting
    {
        public string SqlConnectionString { get; set; }

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        public string FileLatestSchemaUrl { get; set; }

        public string TableSchemaUrl { get; set; }
    }
}
