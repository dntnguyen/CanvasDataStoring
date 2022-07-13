using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.DataMappingSettingModels
{
    public class MappingRule
    {
        public string SourceKey { get; set; }

        public string? DestinationKey { get; set; }

        public string? DestinationDataType { get; set; }

        public string? DestinationFormat { get; set; }
    }
}
