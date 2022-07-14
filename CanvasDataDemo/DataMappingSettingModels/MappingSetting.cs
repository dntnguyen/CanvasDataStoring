using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDataDemo.DataMappingSettingModels
{
    public class MappingSetting
    {
        public string SourceApi { get; set; }

        public string SectionPath { get; set; }

        public List<MappingRule> MappingRules { get; set; } = new List<MappingRule>();

        public string MainTableName { get; set; }

        public string SchemaTableName { get; set; }

        public MappingSetting()
        {

        }

        public MappingSetting(string sourceApi, string sectionPath)
        {
            this.SourceApi = sourceApi;
            this.SectionPath = sectionPath;
        }

        public MappingSetting(string sourceApi, string sectionName, List<MappingRule> rules)
        {
            this.SourceApi = sourceApi;
            this.SectionPath = sectionName;
            if (rules == null)
            {
                return;
            }
            this.MappingRules.AddRange(rules);
        }

        public MappingSetting Clone()
        {
            return (MappingSetting)this.MemberwiseClone();
        }

        public MappingSetting SetSourceApi(string sourceApi)
        {
            this.SourceApi = sourceApi;
            return this;
        }

        public MappingSetting SetSectionPath(string sectionPath)
        {
            this.SectionPath = sectionPath;
            return this;
        }

        public MappingSetting SetMainTableName(string mainTableName)
        {
            this.MainTableName = mainTableName;
            return this;
        }

        public MappingSetting SetSchemaTableName(string schemaTableName)
        {
            this.SchemaTableName = schemaTableName;
            return this;
        }

        public MappingSetting AddMappingRule(MappingRule rule)
        {
            this.MappingRules.Add(rule);
            return this;
        }

        public MappingSetting AddMappingRule(string sourceKey, string destinationKey, string destinationDataType = "", string destinationFormat = "")
        {
            var rule = new MappingRule()
            {
                SourceKey = sourceKey,
                DestinationKey = destinationKey,
                DestinationDataType = destinationDataType,
                DestinationFormat = destinationFormat
            };
            this.MappingRules.Add(rule);
            return this;
        }
    }
}
