using CanvasDataDemo.DatabaseHelper;
using CanvasDataDemo.DataMappingSettingModels;
using CanvasDataDemo.Executors;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OfficeOpenXml;
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
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasDataDemo
{
    public partial class Form1 : Form
    {
        private readonly string _separator = "[;]";

        private List<MappingSetting> _listMappingSetting = new List<MappingSetting>();

        private Dictionary<string, DataTable> _dicTableData = new Dictionary<string, DataTable>();

        public Form1()
        {
            InitializeComponent();
        }

        private HttpWebRequest GetWebRequest(string apiKey, string apiSecret, DateTime timestamp, string url)
        {
            var signature = HmacHelper.GenerateHMACSignature(apiSecret, url, timestamp);
            var request = WebRequest.CreateHttp(url);
            request.Headers["Authorization"] = $"HMACAuth {apiKey}:{signature}";
            request.Date = timestamp;
            return request;
        }

        private void btnGetApiData_Click(object sender, EventArgs e)
        {
            var apiSecret = txtApiSecret.Text;
            var apiKey = txtApiKey.Text;
            var timestamp = DateTime.Now;
            var url = txtUrl.Text;

            var request = GetWebRequest(apiKey, apiSecret, timestamp, url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            string content;
            using (var reader = new StreamReader(dataStream))
            {
                content = reader.ReadToEnd();
            }

            rtbDataFromApi.Text = content;
        }

        private void btnGetListFileData_Click(object sender, EventArgs e)
        {

            var mappingSettingAccountDim = new MappingSetting()
                .SetSectionPath("artifactsByTable/account_dim/files")
                .SetMainTableName("account_dim")
                .SetSchemaTableName("account")
                .AddMappingRule("filename", "filename")
                .AddMappingRule("url", "url");

            var mappingSettingCourseDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/course_dim/files")
                .SetMainTableName("course_dim")
                .SetSchemaTableName("course");

            var mappingSettingRequestsDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/requests/files")
                .SetMainTableName("requests")
                .SetSchemaTableName("requests");

            var mappingSettingTermDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/enrollment_term_dim/files")
                .SetMainTableName("enrollment_term")
                .SetSchemaTableName("enrollment_term");

            var mappingSettingEnrollmentDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/enrollment_dim/files")
                .SetMainTableName("enrollment_dim")
                .SetSchemaTableName("enrollment_dim");

            var mappingSettingAssignmentDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/assignment_dim/files")
                .SetMainTableName("assignment")
                .SetSchemaTableName("assignment_dim");

            var mappingSettingUserDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/user_dim/files")
                .SetMainTableName("user_dim")
                .SetSchemaTableName("user");


            _listMappingSetting.Add(mappingSettingAccountDim);
            _listMappingSetting.Add(mappingSettingCourseDim);
            _listMappingSetting.Add(mappingSettingRequestsDim);
            _listMappingSetting.Add(mappingSettingTermDim);
            _listMappingSetting.Add(mappingSettingEnrollmentDim);
            _listMappingSetting.Add(mappingSettingAssignmentDim);
            _listMappingSetting.Add(mappingSettingUserDim);

            var mappingHandlerHelper = new MappingHandlerHelper();
            var dt_account_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingAccountDim);
            var dt_course_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingCourseDim);
            var dt_requests_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingRequestsDim);
            var dt_enrollment_term_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingTermDim);
            var dt_enrollment_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingEnrollmentDim);
            var dt_assignment_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingAssignmentDim);
            var dt_user_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingUserDim);

            dt_account_dim_files.Merge(dt_course_dim_files);
            dt_account_dim_files.Merge(dt_requests_dim_files);
            dt_account_dim_files.Merge(dt_enrollment_term_dim_files);
            dt_account_dim_files.Merge(dt_enrollment_dim_files);
            dt_account_dim_files.Merge(dt_assignment_dim_files);
            dt_account_dim_files.Merge(dt_user_dim_files);

            dgwListFileData.DataSource = dt_account_dim_files;

            GetFileLinkFromDataTable(dt_account_dim_files);
        }

        private void GetFileLinkFromDataTable(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }

            string links = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                links += _separator + Environment.NewLine + row["url"].ToString() + Environment.NewLine;
            }

            if (links.Substring(0, 3) == _separator)
            {
                links = links.Substring(3);
            }

            rtbFileLinkFromDataGridView.Text = links;
        }

        private void btnDownloadFileFromLink_Click(object sender, EventArgs e)
        {
            string fileFolderName = "FileData";
            if (string.IsNullOrWhiteSpace(txtFileFolder.Text) == false)
            {
                fileFolderName = txtFileFolder.Text.Trim();
            }

            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + fileFolderName;

            Directory.CreateDirectory(fullPathFolder);

            var dt = dgwListFileData.DataSource as DataTable;

            if (dt == null)
            {
                MessageBox.Show("Table url null");
                return;
            }

            WebClient mywebClient = new WebClient();
            foreach (DataRow row in dt.Rows)
            {
                mywebClient.DownloadFile(row["url"].ToString(), fullPathFolder + "\\" + row["filename"].ToString());
            }
        }

        private void btnDecompressFile_Click(object sender, EventArgs e)
        {
            string fileFolderName = "FileData";
            if (string.IsNullOrWhiteSpace(txtFileFolder.Text) == false)
            {
                fileFolderName = txtFileFolder.Text.Trim();
            }

            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + fileFolderName;

            foreach (var path in Directory.GetFiles(fullPathFolder))
            {
                var fi = new FileInfo(path);
                if (fi.Extension != ".gz")
                {
                    continue;
                }
                Decompress(fi);
            }
        }

        public static void Decompress(FileInfo fileToDecompress)
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
                    }
                }
            }
        }

        private void btnReadFile_Click(object sender, EventArgs e)
        {
            _dicTableData.Clear();
            DataTable dt = GetDataTableListJsonFile();
            dgwListDataFileJson.DataSource = dt;
        }

        private DataTable GetDataTableListJsonFile()
        {
            string fileFolderName = "FileData";
            if (string.IsNullOrWhiteSpace(txtFileFolder.Text) == false)
            {
                fileFolderName = txtFileFolder.Text.Trim();
            }

            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + fileFolderName;

            foreach (var path in Directory.GetFiles(fullPathFolder))
            {
                var fi = new FileInfo(path);
                if (fi.Extension == ".gz")
                {
                    continue;
                }
                ReadFile(path, fi);
            }

            var dtListDataFileJson = new DataTable();
            dtListDataFileJson.Columns.Add(new DataColumn("fileName"));
            foreach (var path in Directory.GetFiles(fullPathFolder))
            {
                var fi = new FileInfo(path);
                if (fi.Extension == ".json")
                {
                    var row = dtListDataFileJson.NewRow();
                    row["fileName"] = fi.Name;
                    dtListDataFileJson.Rows.Add(row);
                    continue;
                }
            }
            return dtListDataFileJson;
        }

        private void ReadFile(string path, FileInfo fileName)
        {
            string matchTableName = "";
            var dt = dgwListFileData.DataSource as DataTable;
            foreach (DataRow row in dt.Rows)
            {
                var fileNameWithGz = row["fileName"].ToString();
                var fileNameWithoutGz = fileNameWithGz.Replace(".gz", "");
                if (fileNameWithoutGz == fileName.Name)
                {
                    matchTableName = row["TableName"].ToString();
                }
            }

            if (string.IsNullOrEmpty(matchTableName))
            {
                return;
            }

            var obj = _listMappingSetting.Where(x => x.MainTableName == matchTableName).FirstOrDefault();
            string schemaTableName = obj.SchemaTableName;

            string tableNameWithoutDim = matchTableName.Replace("_dim", "");
            string pathFolder = path.Replace(fileName.Name, "");
            string writeFilePath = pathFolder + tableNameWithoutDim + ".json";

            var jsonTableSchema = rtbTableSchema.Text;

            var mappingSettingCourse = new MappingSetting();

            mappingSettingCourse.SetSectionPath($"schema/{schemaTableName}/columns")
                .SetSchemaTableName(schemaTableName)
                .AddMappingRule("type", "type")
                .AddMappingRule("description", "description")
                .AddMappingRule("name", "name");

            MappingDataRawWithSchemaToDataTable(path, jsonTableSchema, mappingSettingCourse, writeFilePath);
        }

        private void MappingDataRawWithSchemaToDataTable(
            string path, string jsonTableSchema, MappingSetting mappingSettingCourse, string writeFilePath)
        {
            var mappingHandlerHelper = new MappingHandlerHelper();
            var dtCourse = new DataTable();
            var dt_course_columns = mappingHandlerHelper.Map(jsonTableSchema, mappingSettingCourse);
            foreach (DataRow row in dt_course_columns.Rows)
            {
                dtCourse.Columns.Add(row["name"].ToString());
            }

            foreach (string line in File.ReadLines(path))
            {
                DataRow row = dtCourse.NewRow();
                string[] values = line.Split('\t');
                int colCount = values.Length;
                for (int i = 0; i < colCount; i++)
                {
                    row[i] = this.RemoveNullValue(values[i]);
                }

                dtCourse.Rows.Add(row);
            }

            if (dtCourse != null && dtCourse.Rows.Count > 0)
            {
                _dicTableData.Add(mappingSettingCourse.SchemaTableName, dtCourse);
            }

            var json = JsonConvert.SerializeObject(dtCourse);
            File.WriteAllText(writeFilePath, json);
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

        private void btnGetTableSchema_Click(object sender, EventArgs e)
        {
            var apiSecret = txtApiSecret.Text;
            var apiKey = txtApiKey.Text;
            var timestamp = DateTime.Now;
            var url = txtTableSchemaUrl.Text;

            var request = GetWebRequest(apiKey, apiSecret, timestamp, url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            string content;
            using (var reader = new StreamReader(dataStream))
            {
                content = reader.ReadToEnd();
            }

            rtbTableSchema.Text = content;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connString = Program.Configuration.GetSection("ConnectionStrings:CanvasDemoDb").Get<string>();
            MyConnection.SetGlobalConnectionString(connString);
        }

        private void btnCreateTableInDatabase_Click(object sender, EventArgs e)
        {
            var databaseProvider = new MyDatabaseProvider();
            foreach (var item in _dicTableData)
            {
                databaseProvider.GenerateTableInDatabase(item.Key, item.Value);
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            string fileFolderName = "FileData";
            if (string.IsNullOrWhiteSpace(txtFileFolder.Text) == false)
            {
                fileFolderName = txtFileFolder.Text.Trim();
            }

            var fullPathFolder = Directory.GetCurrentDirectory() + "\\" + fileFolderName;
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
