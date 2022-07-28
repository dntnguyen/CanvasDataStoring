using CanvasDataDemo.DatabaseHelper;
using CanvasDataDemo.DataMappingSettingModels;
using CanvasDataDemo.Executors;
using CanvasDataDemo.Models;
using CanvasDataDemo.Utilities;
using CanvasDataDemo.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasDataDemo
{
    public partial class MainForm : Form, IMainFormSettingView
    {
        private readonly ISettingHelper _settingHelper;
        private readonly ICanvasDataApiHelper _canvasDataApiHelper;

        public string? SqlConnectionString { get => txtSqlConnectionString.Text; set => txtSqlConnectionString.Text = value; }

        public string? ApiKey { get => txtApiKey.Text; set => txtApiKey.Text = value; }

        public string? ApiSecret { get => txtApiSecret.Text; set => txtApiSecret.Text = value; }

        public string? FileLatestSchemaUrl { get => txtFileLatestSchemaUrl.Text; set => txtFileLatestSchemaUrl.Text = value; }

        public string? TableSchemaUrl { get => txtTableSchemaUrl.Text; set => txtTableSchemaUrl.Text = value; }

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
            setting.FileLatestSchemaUrl = FileLatestSchemaUrl;
            setting.TableSchemaUrl = TableSchemaUrl;
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
            FileLatestSchemaUrl = setting.FileLatestSchemaUrl;
            TableSchemaUrl = setting.TableSchemaUrl;
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
            var listLatestTableSchema = this._canvasDataApiHelper.GetLatestTableSchema(ApiKey, ApiSecret, FileLatestSchemaUrl);
            GetTable(fileLatestSchema);
        }

        private void GetTable(string fileLatestSchema)
        {
            var mappingSettingAccountDim = new MappingSetting()
                .SetSectionPath("artifactsByTable/account_dim/files")
                .SetMainTableName("account_dim")
                .SetSchemaTableName("account")
                .AddMappingRule("filename", "filename")
                .AddMappingRule("url", "url");

           
            var mappingHandlerHelper = new MappingHandlerHelper();
            var dt_account_dim_files = mappingHandlerHelper.Map(fileLatestSchema, mappingSettingAccountDim);

            //GetFileLinkFromDataTable(dt_account_dim_files);
        }

    }
}
