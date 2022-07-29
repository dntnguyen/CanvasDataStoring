using CanvasDataDemo.DatabaseHelper;
using CanvasDataDemo.DatabaseProviders;
using CanvasDataDemo.DataMappingSettingModels;
using CanvasDataDemo.Datas;
using CanvasDataDemo.Executors;
using CanvasDataDemo.Models;
using CanvasDataDemo.Utilities;
using CanvasDataDemo.Views;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasDataDemo
{
    public partial class MainForm : Form, IMainFormSettingView
    {
        public string? SqlConnectionString { get => txtSqlConnectionString.Text; set => txtSqlConnectionString.Text = value; }

        public string? ApiKey { get => txtApiKey.Text; set => txtApiKey.Text = value; }

        public string? ApiSecret { get => txtApiSecret.Text; set => txtApiSecret.Text = value; }

        public string? TableFileUrl { get => txtTableFileUrl.Text; set => txtTableFileUrl.Text = value; }

        public string? LatestTableSchemaUrl { get => txtLatestTableSchemaUrl.Text; set => txtLatestTableSchemaUrl.Text = value; }

        private readonly ISettingHelper _settingHelper;
        private readonly ICanvasDataApiHelper _canvasDataApiHelper;
        private readonly string _fileDataFolderName = "FileData";

        public MainForm(ISettingHelper settingHelper, ICanvasDataApiHelper canvasDataApiHelper)
        {
            this._settingHelper = settingHelper;
            this._canvasDataApiHelper = canvasDataApiHelper;
            InitializeComponent();
        }

        private Setting GetSetting()
        {
            var setting = new Setting();
            setting.SqlConnectionString = SqlConnectionString;
            setting.ApiKey = ApiKey;
            setting.ApiSecret = ApiSecret;
            setting.TableFileUrl = TableFileUrl;
            setting.LatestTableSchemaUrl = LatestTableSchemaUrl;
            return setting;
        }

        private void LoadSettingFromFile()
        {
            var setting = this._settingHelper.GetSettingFromFile()?.ResultValue;
            if (setting is null)
            {
                setting = new Setting();
            }

            SqlConnectionString = setting.SqlConnectionString;
            ApiKey = setting.ApiKey;
            ApiSecret = setting.ApiSecret;
            TableFileUrl = setting.TableFileUrl;
            LatestTableSchemaUrl = setting.LatestTableSchemaUrl;

            MyConnection.SetGlobalConnectionString(SqlConnectionString);

            if (string.IsNullOrEmpty(SqlConnectionString))
            {
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettingFromFile();
        }
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string sqlConnectionString = txtSqlConnectionString.Text;
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                MessageBox.Show("Please input connection string");
            }

            var testConnectionErrorDescription = MyDatabaseHelper.TestConnection(sqlConnectionString);

            if (string.IsNullOrEmpty(testConnectionErrorDescription))
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show($"Failed to connection to database: {testConnectionErrorDescription}");
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            this._settingHelper.WriteSettingToFile(GetSetting());
        }

        private void btnRunGetDataJob_Click(object sender, EventArgs e)
        {
            IEnumerable<TableSchema> listLatestTableSchema =
                this._canvasDataApiHelper.GetLatestTableSchema(ApiKey, ApiSecret, LatestTableSchemaUrl);
            foreach (var tableSchema in listLatestTableSchema)
            {
                if (tableSchema.TableName != "account_dim")
                {
                    continue;
                }

                var tableFile = GetTableFile(tableSchema);
            }
        }

        private TableFile GetTableFile(TableSchema tableSchema)
        {
            var tableFile = this._canvasDataApiHelper.GetTableFile(ApiKey, ApiSecret, TableFileUrl, tableSchema.TableName);

            var tableSyncProvider = new TableSyncProvider();
            var tableSync = tableSyncProvider.GetTableSync(tableSchema.TableName);
            if (tableSync is null)
            {
                tableSync = tableSyncProvider.AddTableToTableSync(tableSchema.TableName);
            }

            int maxSequenceOfTableFile = -1;

            if (tableFile.ListHistory?.Count > 0)
            {
                maxSequenceOfTableFile = tableFile.ListHistory.Max(x => x.Sequence);
                if (tableSync.LatestSequence is null || tableSync.LatestSequence <= 0 || tableSync.LatestSequence < maxSequenceOfTableFile)
                {
                    var tableFileHistory = tableFile.ListHistory.FirstOrDefault(x => x.Sequence == maxSequenceOfTableFile);

                    var downloadFileName = tableFileHistory.FileInfo?.FileName;
                    var downloadUrl = tableFileHistory.FileInfo?.Url;

                    DownloadFileToFileDataFolder(downloadUrl, downloadFileName, tableSchema);
                }
            }


            return tableFile;
        }

        private void DownloadFileToFileDataFolder(string downloadUrl, string downloadFileName, TableSchema tableSchema)
        {
            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + _fileDataFolderName;

            Directory.CreateDirectory(fullPathFolder);

            using (var mywebClient = new WebClient())
            {
                mywebClient.DownloadFile(downloadUrl, fullPathFolder + "\\" + downloadFileName);
            }

            string decompressedFileNameFullPath = DecompressDownloadedFile(downloadFileName);

            if (string.IsNullOrEmpty(decompressedFileNameFullPath))
            {
                return;
            }

            string writeFilePath = fullPathFolder + "\\" + tableSchema.TableName + ".json";

            MappingDataRawWithSchemaToDataTable(decompressedFileNameFullPath, tableSchema, writeFilePath);
        }

        private string DecompressDownloadedFile(string downloadedFileName)
        {
            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + _fileDataFolderName;

            foreach (var path in Directory.GetFiles(fullPathFolder))
            {
                var fi = new FileInfo(path);
                if (fi.Name == downloadedFileName)
                {
                    if (fi.Extension != ".gz")
                    {
                        continue;
                    }
                    string decompressedFileName = Decompress(fi);
                    return decompressedFileName;
                }
            }

            return string.Empty;
        }

        private string Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        return newFileName;
                    }
                }
            }
        }

        private DataTable MappingDataRawWithSchemaToDataTable(
            string rawFilePath, TableSchema tableSchema, string writeFilePath)
        {
            var dtDestination = CreateDataTableFromCanvasTableSchema(tableSchema);
            
            foreach (string line in File.ReadLines(rawFilePath))
            {
                DataRow row = dtDestination.NewRow();
                string[] values = line.Split('\t');
                int colCount = values.Length;
                for (int i = 0; i < colCount; i++)
                {
                    row[i] = this.RemoveNullValue(values[i]);
                }

                dtDestination.Rows.Add(row);
            }

            var json = JsonConvert.SerializeObject(dtDestination);
            File.WriteAllText(writeFilePath, json);

            return dtDestination;
        }

        private string RemoveNullValue(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            if (input.Trim().ToLower() == @"\n")
            {
                return string.Empty;
            }

            return input;
        }

        private DataTable CreateDataTableFromCanvasTableSchema(TableSchema schema)
        {
            var dt = new DataTable();

            foreach (var schemaColumn in schema.ListColumn)
            {
                var col = new DataColumn();
                col.AllowDBNull = true;
                col.ColumnName = schemaColumn.Name;


                if (schemaColumn.Type == "bigint" || schemaColumn.Type == "int")
                {
                    col.DataType = typeof(long);
                }
                else if (schemaColumn.Type == "double precision")
                {
                    col.DataType = typeof(double);
                }
                else if (schemaColumn.Type == "boolean")
                {
                    col.DataType = typeof(bool);
                }
                else if (schemaColumn.Type == "datetime")
                {
                    col.DataType = typeof(DateTime);
                }
                dt.Columns.Add(col);
            }

            dt.TableName = schema.TableName;
            return dt;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + _fileDataFolderName;
            try
            {
                Process.Start(fullPathFolder);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
