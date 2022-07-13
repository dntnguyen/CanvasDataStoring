using CanvasDataDemo.DataMappingSettingModels;
using CanvasDataDemo.Executors;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Form1 : Form
    {
        private readonly string _separator = "[;]";

        private List<MappingSetting> _listMappingSetting = new List<MappingSetting>();

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
                .AddMappingRule("filename", "filename")
                .AddMappingRule("url", "url");

            var mappingSettingCourseDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/course_dim/files")
                .SetMainTableName("course_dim");

            var mappingSettingRequestsDim = mappingSettingAccountDim.Clone()
                .SetSectionPath("artifactsByTable/requests/files")
                .SetMainTableName("requests");

            _listMappingSetting.Add(mappingSettingAccountDim);
            _listMappingSetting.Add(mappingSettingCourseDim);
            _listMappingSetting.Add(mappingSettingRequestsDim);

            var mappingHandlerHelper = new MappingHandlerHelper();
            var dt_account_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingAccountDim);
            var dt_course_dim_files = mappingHandlerHelper.Map(rtbDataFromApi.Text, mappingSettingCourseDim);

            dt_account_dim_files.Merge(dt_course_dim_files);

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
                ReadFile(path, fi.Name);
                break;
            }
        }

        private void ReadFile(string path, string fileName)
        {
            string matchTableName = "";
            foreach (var setting in _listMappingSetting)
            {
                if (fileName.Contains(setting.MainTableName))
                {
                    matchTableName = setting.MainTableName;
                    break;
                }
            }

            if (string.IsNullOrEmpty(matchTableName))
            {
                return;
            }

            rtbData.Text = "";
            foreach (string line in File.ReadLines(path))
            {
                rtbData.Text += line + Environment.NewLine;
                
            }
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
    }
}
