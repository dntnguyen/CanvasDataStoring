using CanvasDataDemo.DatabaseHelper;
using CanvasDataDemo.DatabaseProviders;
using CanvasDataDemo.DataMappingSettingModels;
using CanvasDataDemo.Datas;
using CanvasDataDemo.Executors;
using CanvasDataDemo.Models;
using CanvasDataDemo.Utilities;
using CanvasDataDemo.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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

        public bool GenerateJsonFile { get => chkGenerateJsonFile.Checked; set => chkGenerateJsonFile.Checked = value; }

        private readonly ILogger<MainForm> _logger;
        private readonly ISettingHelper _settingHelper;
        private readonly ICanvasDataApiHelper _canvasDataApiHelper;
        private readonly string _fileDataFolderName = "FileData";

        private BaseProvider _databaseProvider = null;
        private BackgroundWorker _bgwGetDataJob = new BackgroundWorker();

        public MainForm(
            ILogger<MainForm> logger,
            ISettingHelper settingHelper,
            ICanvasDataApiHelper canvasDataApiHelper)
        {
            this._logger = logger;
            this._settingHelper = settingHelper;
            this._canvasDataApiHelper = canvasDataApiHelper;
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private Setting GetSetting()
        {
            var setting = new Setting();
            setting.SqlConnectionString = SqlConnectionString;
            setting.ApiKey = ApiKey;
            setting.ApiSecret = ApiSecret;
            setting.TableFileUrl = TableFileUrl;
            setting.LatestTableSchemaUrl = LatestTableSchemaUrl;
            setting.GenerateJsonFile = GenerateJsonFile.ToString();
            return setting;
        }

        private void LoadSettingFromFile()
        {
            var setting = this._settingHelper.GetSettingFromFile()?.ResultValue;
            if (setting is null)
            {
                setting = new Setting();
            }

            var defaultSchemaLatestUrl = "https://portal.inshosteddata.com/api/schema/latest";
            var defaultTableFileUrl = "https://portal.inshosteddata.com/api/account/self/file/byTable/:tableName";

            SqlConnectionString = setting.SqlConnectionString;
            ApiKey = setting.ApiKey;
            ApiSecret = setting.ApiSecret;
            TableFileUrl = string.IsNullOrEmpty(setting.TableFileUrl) ? defaultTableFileUrl : setting.TableFileUrl;
            LatestTableSchemaUrl = string.IsNullOrEmpty(setting.LatestTableSchemaUrl) ? defaultSchemaLatestUrl : setting.LatestTableSchemaUrl;
            GenerateJsonFile = !string.IsNullOrEmpty(setting.GenerateJsonFile) && setting.GenerateJsonFile == "True" 
                ? true
                : false;

            MyConnection.SetGlobalConnectionString(SqlConnectionString);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettingFromFile();
            this._logger.LogInformation("Load Setting From File");
        }
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private bool TestConnection(bool isShowMessagae = true)
        {
            string sqlConnectionString = txtSqlConnectionString.Text;
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                if (isShowMessagae)
                {
                    MessageBox.Show("Please input connection string");
                }
                return false;
            }

            var testConnectionErrorDescription = MyDatabaseHelper.TestConnection(sqlConnectionString);

            if (string.IsNullOrEmpty(testConnectionErrorDescription))
            {
                if (isShowMessagae)
                {
                    MessageBox.Show("Success");
                }
                return true;
            }
            else
            {
                if (isShowMessagae)
                {
                    MessageBox.Show($"Failed to connection to database: {testConnectionErrorDescription}");
                }
                return false;
            }
        }

        private void InitializeBackgroundWorker()
        {
            _bgwGetDataJob.WorkerReportsProgress = true;
            _bgwGetDataJob.WorkerSupportsCancellation = true;
            _bgwGetDataJob.DoWork +=
                new DoWorkEventHandler(bgwGetDataJob_DoWork);
            _bgwGetDataJob.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            bgwGetDataJob_RunWorkerCompleted);
            _bgwGetDataJob.ProgressChanged +=
                new ProgressChangedEventHandler(
            bgwGetDataJob_ProgressChanged);
        }

        private void InvokeWriteNotes(string message, bool isClear = false)
        {
            if (isClear)
            {
                rtbJobNotes.Invoke((MethodInvoker)(() => rtbJobNotes.Text = ""));
                return;
            }

            DateTime nun = DateTime.Now;
            var nunText = nun.ToString("yyyy-MM-dd HH:mm:ss fff");
            rtbJobNotes.Invoke((MethodInvoker)(() => rtbJobNotes.Text += nunText + "\t" + message + "\n"));
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            this._settingHelper.WriteSettingToFile(GetSetting());
            MyConnection.SetGlobalConnectionString(SqlConnectionString);
        }

        private bool InitConnectionBeforeRunGetDataJob()
        {
            MyConnection.SetGlobalConnectionString(SqlConnectionString);
            if (TestConnection(false))
            {
                _databaseProvider = new BaseProvider();
                return true;
            }
            else
            {
                MessageBox.Show("Connection is not available");
                return false;
            }
        }

        private void btnRunGetDataJob_Click(object sender, EventArgs e)
        {
            if (InitConnectionBeforeRunGetDataJob() == false)
            {
                return;
            }

            EnableGetDataControls(false);
            _bgwGetDataJob.RunWorkerAsync();
        }


        private void btnGetSpecificTableData_Click(object sender, EventArgs e)
        {
            if (InitConnectionBeforeRunGetDataJob() == false)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGetSpecificTableData.Text))
            {
                MessageBox.Show("Please input table name");
                return;
            }

            _bgwGetDataJob.RunWorkerAsync(txtGetSpecificTableData.Text.Trim());
        }

        private void GetDataJob(DoWorkEventArgs e, string tableName = "")
        {
            InvokeWriteNotes("", true);
            var logText = "Start To Get Data";
            _logger.LogInformation(logText);
            InvokeWriteNotes(logText);

            var response = this._canvasDataApiHelper.GetLatestTableSchema(ApiKey, ApiSecret, LatestTableSchemaUrl);

            if (response.ResultCode != ResponseResultCode.Ok)
            {
                logText = "Start To Get Data";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);
                return;
            }

            var listLatestTableSchema = response.ResultValue;

            if (listLatestTableSchema == null || listLatestTableSchema.Count() <= 0)
            {
                logText = "No Table To Get Data";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);
                return;
            }

            var count = 0;
            foreach (var tableSchema in listLatestTableSchema)
            {
                if (_bgwGetDataJob.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                if (string.IsNullOrEmpty(tableName) || tableSchema.TableName == tableName)
                {
                    if (GetDataJobFromTable(tableSchema))
                    {
                        count++;
                    }
                }
            }
            var tableCount = string.IsNullOrEmpty(tableName) ? listLatestTableSchema.Count() : 1;
            logText = $"Finish To Get Table Data. Total:{count}/{tableCount}";
            _logger.LogInformation(logText);
            InvokeWriteNotes(logText);
        }

        private bool GetDataJobFromTable(TableSchema tableSchema)
        {
            TableFileHistory tableFileHistory = GetTableFileAndDownloadToDataFolder(tableSchema.TableName);

            if (tableFileHistory == null || tableFileHistory.FileInfo == null || tableFileHistory.FileInfo.IsCannotDownload())
            {
                return false;
            }

            var logText = $"Begin to process table: {tableSchema.TableName}, sequence: {tableFileHistory.Sequence}";
            _logger.LogInformation(logText);
            InvokeWriteNotes(logText);

            string decompressedFileNameFullPath = DownloadFileToFileDataFolder(tableFileHistory.FileInfo);


            string writeFilePath = this.GenerateJsonFile ? GetFullPathFolderFileData() + tableSchema.TableName + ".json" : string.Empty;

            DataTable dtData = MappingDataRawWithSchemaToDataTable(decompressedFileNameFullPath, tableSchema, writeFilePath);


            var response = _databaseProvider.InsertDataToTable(tableSchema, tableFileHistory, dtData);
            if (response.ResultCode == ResponseResultCode.Ok)
            {
                logText = $"Sucessfully process table: {tableSchema.TableName}, sequence: {tableFileHistory.Sequence}";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);

                DeleteDownloadedFileWhichWasImportedSuccessfully(tableFileHistory, decompressedFileNameFullPath);
                return true;
            }
            else
            {
                logText = $"Fail to process table: {tableSchema.TableName}, sequence: {tableFileHistory.Sequence}. Result: {response.ResultDescription}";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);
                return false;
            }
        }

        private void DeleteDownloadedFileWhichWasImportedSuccessfully(TableFileHistory tableFileHistory, string decompressedFileNameFullPath)
        {
            try
            {
                if (File.Exists(decompressedFileNameFullPath))
                {

                    File.Delete(decompressedFileNameFullPath);
                }
            }
            catch (Exception ex)
            {
                var logText = $"Fail to delete data file: {decompressedFileNameFullPath}. Error: {ex.Message}";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);
            }

            string compressedFileToDelete = GetFullPathFolderFileData() + tableFileHistory.FileInfo.FileName;
            try
            {
                if (File.Exists(compressedFileToDelete))
                {

                    File.Delete(compressedFileToDelete);
                }
            }
            catch (Exception ex)
            {
                var logText = $"Fail to delete data file: {compressedFileToDelete}. Error: {ex.Message}";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);
            }
        }

        private TableFileHistory GetTableFileAndDownloadToDataFolder(string tableName)
        {
            var response = this._canvasDataApiHelper.GetTableFile(ApiKey, ApiSecret, TableFileUrl, tableName);

            if (response.ResultCode != ResponseResultCode.Ok)
            {
                var logText = $"GetTableFileAndDownloadToDataFolder: {response.ResultDescription}";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);

                return null;
            }

            TableFile tableFile = response.ResultValue;

            var tableSyncProvider = new TableSyncProvider();
            var tableSync = tableSyncProvider.GetTableSync(tableName);
            if (tableSync is null)
            {
                tableSync = tableSyncProvider.AddTableToTableSync(tableName);
            }

            int maxSequenceOfTableFile = -1;

            if (tableFile.ListHistory?.Count > 0)
            {
                maxSequenceOfTableFile = tableFile.ListHistory.Max(x => x.Sequence);
                if (tableSync.LatestSequence is null || tableSync.LatestSequence <= 0 || tableSync.LatestSequence < maxSequenceOfTableFile)
                {
                    return tableFile.ListHistory.FirstOrDefault(x => x.Sequence == maxSequenceOfTableFile);
                }
            }


            return null;
        }

        private string GetFullPathFolderFileData()
        {
            return Directory.GetCurrentDirectory() + "\\" + _fileDataFolderName + "\\";
        }

        private string DownloadFileToFileDataFolder(TableFileFileInfo tableFileFileInfo)
        {
            var fullPathFolder = GetFullPathFolderFileData();

            var downloadUrl = tableFileFileInfo.Url;
            var downloadFileName = tableFileFileInfo.FileName;

            Directory.CreateDirectory(fullPathFolder);

            using (var mywebClient = new WebClient())
            {
                mywebClient.DownloadFile(downloadUrl, fullPathFolder + downloadFileName);
            }

            string decompressedFileNameFullPath = DecompressDownloadedFile(downloadFileName);

            return decompressedFileNameFullPath;
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

            if (string.IsNullOrEmpty(writeFilePath) == false)
            {
                var json = JsonConvert.SerializeObject(dtDestination);
                File.WriteAllText(writeFilePath, json);
            }

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

                ////if (schemaColumn.Type == "bigint" || schemaColumn.Type == "int")
                ////{
                ////    col.DataType = typeof(long);
                ////}
                ////else if (schemaColumn.Type == "double precision")
                ////{
                ////    col.DataType = typeof(double);
                ////}
                ////else if (schemaColumn.Type == "boolean")
                ////{
                ////    col.DataType = typeof(bool);
                ////}
                ////else if (schemaColumn.Type == "datetime")
                ////{
                ////    col.DataType = typeof(DateTime);
                ////}
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

        private void btnOpenForm1_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.APIKey = ApiKey;
            form1.APISecret = ApiSecret;
            form1.Show(this);
        }

        private void bgwGetDataJob_DoWork(object sender,
            DoWorkEventArgs e)
        {
            lblApplicationStatusValue.Invoke((MethodInvoker)(() => lblApplicationStatusValue.Text = ApplicationStatuses.SyncingData));

            string tableName = e.Argument as string;
            GetDataJob(e, tableName);
        }

        private void EnableGetDataControls(bool enabled)
        {
            btnStopGetDataJob.Enabled = !enabled;
            txtGetSpecificTableData.Enabled = enabled;
            btnGetSpecificTableData.Enabled = enabled;
            btnRunGetDataJob.Enabled = enabled;
        }

        private void bgwGetDataJob_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            EnableGetDataControls(true);

            if (e.Error != null)
            {
                lblApplicationStatusValue.Text = ApplicationStatuses.SyncEndedWithError;
            }
            else if (e.Cancelled)
            {
                lblApplicationStatusValue.Text = ApplicationStatuses.SyncCancelled;

                var logText = $"Get Data Job has been cancelled";
                _logger.LogInformation(logText);
                InvokeWriteNotes(logText);
            }
            else
            {
                lblApplicationStatusValue.Text = ApplicationStatuses.None;
            }

        }

        private void bgwGetDataJob_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

        }

        private void btnStopGetDataJob_Click(object sender, EventArgs e)
        {
            if (_bgwGetDataJob.IsBusy)
            {
                _bgwGetDataJob.CancelAsync();
            }
        }

        private void btnGetFilesOfTable_Click(object sender, EventArgs e)
        {
            var tableName = txtGetFilesOfTableTableName.Text;
            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show($"Please input {lblGetFilesOfTableTableName}");
                return;
            }
            var response = this._canvasDataApiHelper.GetTableFileContentJson(ApiKey, ApiSecret, TableFileUrl, tableName);
            if (response.ResultCode != ResponseResultCode.Ok)
            {
                MessageBox.Show(response.ResultDescription);
                return;
            }
            string content = response.ResultValue as string;
            rtbFilesOfTable.Text = content;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
