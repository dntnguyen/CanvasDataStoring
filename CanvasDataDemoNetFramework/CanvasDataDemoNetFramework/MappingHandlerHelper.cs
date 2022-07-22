using CanvasDataDemoNetFramework.DataMappingSettingModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CanvasDataDemoNetFramework
{
    public class MappingHandlerHelper
    {
        public MappingHandlerHelper()
        {

        }

        public enum MappingRuleDataType
        {
            STRING,
            INTEGER,
            DECIMAL,
            DATETIME,
            BOOLEAN
        }

        private MappingRuleDataType GetMappingRuleDataType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return MappingRuleDataType.STRING;
            }

            string checkValue = value.Trim().ToLower();

            if (checkValue == "string")
            {
                return MappingRuleDataType.STRING;
            }
            else if (checkValue == "integer" || checkValue == "int")
            {
                return MappingRuleDataType.INTEGER;
            }
            else if (checkValue == "decimal")
            {
                return MappingRuleDataType.DECIMAL;
            }
            else if (checkValue == "datetime")
            {
                return MappingRuleDataType.DATETIME;
            }
            else if (checkValue == "boolean" || checkValue == "bool")
            {
                return MappingRuleDataType.BOOLEAN;
            }

            return MappingRuleDataType.STRING;
        }

        public DataTable Map(string json, MappingSetting mappingSetting)
        {
            if (mappingSetting == null)
            {
                return null;
            }

            var dt = new DataTable();

            foreach (var rule in mappingSetting.MappingRules)
            {
                var col = new DataColumn();
                col.AllowDBNull = true;
                col.ColumnName = rule.SourceKey;
                var mappingRuleDataType = GetMappingRuleDataType(rule.DestinationDataType);

                if (mappingRuleDataType == MappingRuleDataType.INTEGER)
                {
                    col.DataType = typeof(int);
                }
                else if (mappingRuleDataType == MappingRuleDataType.DECIMAL)
                {
                    col.DataType = typeof(decimal);
                }
                else if (mappingRuleDataType == MappingRuleDataType.BOOLEAN)
                {
                    col.DataType = typeof(bool);
                }
                else if (mappingRuleDataType == MappingRuleDataType.DATETIME)
                {
                    col.DataType = typeof(DateTime);
                }
                col.Caption = rule.DestinationKey is null ? rule.SourceKey : rule.DestinationKey;
                dt.Columns.Add(col);
            }

            var colTableName = new DataColumn();
            colTableName.ColumnName = "TableName";
            dt.Columns.Add(colTableName);

            var schemaTableName = new DataColumn();
            schemaTableName.ColumnName = "SchemaTableName";
            dt.Columns.Add(schemaTableName);

            var doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;
            var sectionNameArray = mappingSetting.SectionPath.Split('/');
            var ele = GetTargetSectionMappingObjectRecursive(root, sectionNameArray);

            var listJsonObjectElement = new List<JsonElement>();
            if (ele.ValueKind == JsonValueKind.Object)
            {
                listJsonObjectElement = GetJsonObjectListFromJsonObject(ele);
            }
            else if (ele.ValueKind == JsonValueKind.Array)
            {
                listJsonObjectElement = GetJsonObjectListFromJsonArray(ele);
            }

            AssignToDataTable(dt, listJsonObjectElement, mappingSetting);
            if (doc != null)
            {
                doc.Dispose();
            }
            return dt;
        }

        private void WriteExcelFile(DataTable dt, List<MappingRule> mappingRules)
        {
            // Creating an instance
            // of ExcelPackage
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            // name of the sheet
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            // setting the properties
            // of the work sheet 
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;

            workSheet.Cells["A1"].LoadFromDataTable(dt, true);

            workSheet.Row(1).Style.Font.Bold = true;

            int endColIndex = workSheet.Dimension.End.Column;
            for (int i = 1; i < endColIndex; i++)
            {
                workSheet.Column(i).AutoFit();
                foreach (var rule in mappingRules)
                {
                    if (rule.DestinationKey == workSheet.Cells[1, i].Text)
                    {
                        var mappingRuleDataType = GetMappingRuleDataType(rule.DestinationDataType);
                        if (mappingRuleDataType == MappingRuleDataType.DATETIME)
                        {
                            if (string.IsNullOrWhiteSpace(rule.DestinationFormat))
                            {
                                workSheet.Column(i).Style.Numberformat.Format = "yyyy/MM/dd";
                            }
                            else
                            {
                                workSheet.Column(i).Style.Numberformat.Format = rule.DestinationFormat;
                            }
                        }
                    }
                }
            }
            // file name with .xlsx extension 
            string p_strPath = @"D:\geeksforgeeks.xlsx";

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            // Create excel file on physical disk 
            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            // Write content to excel file 
            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            //Close Excel package
            excel.Dispose();
        }

        private void AssignToDataTable(DataTable dt, List<JsonElement> listJsonObjectElement
            , MappingSetting mappingSetting)
        {
            if (dt.Columns.Count <= 0)
            {
                return;
            }

            DataRow row;
            foreach (var element in listJsonObjectElement)
            {
                row = null;
                foreach (DataColumn col in dt.Columns)
                {
                    var columnName = col.ColumnName.Trim().ToLower();
                    var props = element.EnumerateObject();
                    while (props.MoveNext())
                    {
                        var prop = props.Current;
                        var propName = prop.Name.Trim().ToLower();

                        if (propName == columnName)
                        {
                            if (row == null)
                            {
                                row = dt.NewRow();
                            }

                            if (prop.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }

                            if (col.DataType == typeof(int))
                            {
                                if (prop.Value.TryGetInt32(out int value))
                                {
                                    row[col] = value;
                                }
                            }
                            else if (col.DataType == typeof(decimal))
                            {
                                if (prop.Value.TryGetDecimal(out decimal value))
                                {
                                    row[col] = value;
                                }
                            }
                            else if (col.DataType == typeof(DateTime))
                            {
                                if (prop.Value.TryGetDateTime(out DateTime value))
                                {
                                    row[col] = value;
                                }
                            }
                            else if (col.DataType == typeof(bool))
                            {
                                row[col] = prop.Value.GetBoolean();
                            }
                            else
                            {
                                row[col] = prop.Value.GetString();
                            }
                        }
                    }
                }

                if (row != null)
                {
                    row["TableName"] = mappingSetting.MainTableName;
                    row["SchemaTableName"] = mappingSetting.SchemaTableName;
                    dt.Rows.Add(row);
                }
            }
        }

        private JsonElement GetTargetSectionMappingObjectRecursive(JsonElement root, string[] sectionNameArray)
        {
            if (sectionNameArray == null || sectionNameArray.Length <= 0)
            {
                return root;
            }

            var sectionName = sectionNameArray.First();
            if (string.IsNullOrWhiteSpace(sectionName))
            {
                return root;
            }

            sectionName = sectionName.Trim().ToLower();

            var props = root.EnumerateObject();
            while (props.MoveNext())
            {
                var prop = props.Current;
                var name = prop.Name;
                var value = prop.Value;

                if (name.Trim().ToLower() == sectionName)
                {
                    if (sectionNameArray.Length == 1)
                    {
                        return value;
                    }

                    return GetTargetSectionMappingObjectRecursive(value, sectionNameArray.Skip(1).ToArray());
                }
            }

            return root;
        }

        private List<JsonElement> GetJsonObjectListFromJsonArray(JsonElement element)
        {
            var listJsonObjectElement = new List<JsonElement>();
            var array = element.EnumerateArray();

            while (array.MoveNext())
            {
                listJsonObjectElement.Add(array.Current);
            }

            return listJsonObjectElement;
        }

        private List<JsonElement> GetJsonObjectListFromJsonObject(JsonElement element)
        {
            var listJsonObjectElement = new List<JsonElement>();
            listJsonObjectElement.Add(element);
            return listJsonObjectElement;
        }
    }
}
