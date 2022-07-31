namespace CanvasDataDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.txtGetSpecificTableData = new System.Windows.Forms.TextBox();
            this.lblGetSpecificTableData = new System.Windows.Forms.Label();
            this.btnGetSpecificTableData = new System.Windows.Forms.Button();
            this.rtbJobNotes = new System.Windows.Forms.RichTextBox();
            this.btnStopGetDataJob = new System.Windows.Forms.Button();
            this.btnRunGetDataJob = new System.Windows.Forms.Button();
            this.lblApplicationStatusValue = new System.Windows.Forms.Label();
            this.lblApplicationStatus = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAutoGetDataEverydayTime = new System.Windows.Forms.DateTimePicker();
            this.chkRunWhenWindowsStarts = new System.Windows.Forms.CheckBox();
            this.chkGenerateJsonFile = new System.Windows.Forms.CheckBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.lblSqlConnectionString = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtLatestTableSchemaUrl = new System.Windows.Forms.TextBox();
            this.lblLatestTableSchemaUrl = new System.Windows.Forms.Label();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.lblApiSecret = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtTableFileUrl = new System.Windows.Forms.TextBox();
            this.lblTableFileUrl = new System.Windows.Forms.Label();
            this.tabPageUtilities = new System.Windows.Forms.TabPage();
            this.btnOpenForm1 = new System.Windows.Forms.Button();
            this.lblGetFilesOfTableTableName = new System.Windows.Forms.Label();
            this.txtGetFilesOfTableTableName = new System.Windows.Forms.TextBox();
            this.lblFilesOfTable = new System.Windows.Forms.Label();
            this.rtbFilesOfTable = new System.Windows.Forms.RichTextBox();
            this.btnGetFilesOfTable = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsVersionValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerAutoGetData = new System.Windows.Forms.Timer(this.components);
            this.tabMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageUtilities.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPageMain);
            this.tabMain.Controls.Add(this.tabPageSettings);
            this.tabMain.Controls.Add(this.tabPageUtilities);
            this.tabMain.Location = new System.Drawing.Point(1, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(738, 438);
            this.tabMain.TabIndex = 4;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.txtGetSpecificTableData);
            this.tabPageMain.Controls.Add(this.lblGetSpecificTableData);
            this.tabPageMain.Controls.Add(this.btnGetSpecificTableData);
            this.tabPageMain.Controls.Add(this.rtbJobNotes);
            this.tabPageMain.Controls.Add(this.btnStopGetDataJob);
            this.tabPageMain.Controls.Add(this.btnRunGetDataJob);
            this.tabPageMain.Controls.Add(this.lblApplicationStatusValue);
            this.tabPageMain.Controls.Add(this.lblApplicationStatus);
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(730, 410);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // txtGetSpecificTableData
            // 
            this.txtGetSpecificTableData.Location = new System.Drawing.Point(155, 93);
            this.txtGetSpecificTableData.Name = "txtGetSpecificTableData";
            this.txtGetSpecificTableData.Size = new System.Drawing.Size(158, 23);
            this.txtGetSpecificTableData.TabIndex = 42;
            // 
            // lblGetSpecificTableData
            // 
            this.lblGetSpecificTableData.AutoSize = true;
            this.lblGetSpecificTableData.Location = new System.Drawing.Point(20, 96);
            this.lblGetSpecificTableData.Name = "lblGetSpecificTableData";
            this.lblGetSpecificTableData.Size = new System.Drawing.Size(126, 15);
            this.lblGetSpecificTableData.TabIndex = 41;
            this.lblGetSpecificTableData.Text = "Get Specific Table Data";
            // 
            // btnGetSpecificTableData
            // 
            this.btnGetSpecificTableData.Location = new System.Drawing.Point(155, 122);
            this.btnGetSpecificTableData.Name = "btnGetSpecificTableData";
            this.btnGetSpecificTableData.Size = new System.Drawing.Size(158, 23);
            this.btnGetSpecificTableData.TabIndex = 40;
            this.btnGetSpecificTableData.Text = "Get Specific Table Data";
            this.btnGetSpecificTableData.UseVisualStyleBackColor = true;
            this.btnGetSpecificTableData.Click += new System.EventHandler(this.btnGetSpecificTableData_Click);
            // 
            // rtbJobNotes
            // 
            this.rtbJobNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbJobNotes.Location = new System.Drawing.Point(22, 176);
            this.rtbJobNotes.Name = "rtbJobNotes";
            this.rtbJobNotes.Size = new System.Drawing.Size(690, 228);
            this.rtbJobNotes.TabIndex = 39;
            this.rtbJobNotes.Text = "";
            // 
            // btnStopGetDataJob
            // 
            this.btnStopGetDataJob.Enabled = false;
            this.btnStopGetDataJob.Location = new System.Drawing.Point(393, 122);
            this.btnStopGetDataJob.Name = "btnStopGetDataJob";
            this.btnStopGetDataJob.Size = new System.Drawing.Size(158, 23);
            this.btnStopGetDataJob.TabIndex = 38;
            this.btnStopGetDataJob.Text = "Stop Get Data Job";
            this.btnStopGetDataJob.UseVisualStyleBackColor = true;
            this.btnStopGetDataJob.Click += new System.EventHandler(this.btnStopGetDataJob_Click);
            // 
            // btnRunGetDataJob
            // 
            this.btnRunGetDataJob.Location = new System.Drawing.Point(155, 51);
            this.btnRunGetDataJob.Name = "btnRunGetDataJob";
            this.btnRunGetDataJob.Size = new System.Drawing.Size(158, 23);
            this.btnRunGetDataJob.TabIndex = 6;
            this.btnRunGetDataJob.Text = "Run Get Data Job";
            this.btnRunGetDataJob.UseVisualStyleBackColor = true;
            this.btnRunGetDataJob.Click += new System.EventHandler(this.btnRunGetDataJob_Click);
            // 
            // lblApplicationStatusValue
            // 
            this.lblApplicationStatusValue.AutoSize = true;
            this.lblApplicationStatusValue.Location = new System.Drawing.Point(155, 16);
            this.lblApplicationStatusValue.Name = "lblApplicationStatusValue";
            this.lblApplicationStatusValue.Size = new System.Drawing.Size(36, 15);
            this.lblApplicationStatusValue.TabIndex = 5;
            this.lblApplicationStatusValue.Text = "None";
            // 
            // lblApplicationStatus
            // 
            this.lblApplicationStatus.AutoSize = true;
            this.lblApplicationStatus.Location = new System.Drawing.Point(19, 16);
            this.lblApplicationStatus.Name = "lblApplicationStatus";
            this.lblApplicationStatus.Size = new System.Drawing.Size(103, 15);
            this.lblApplicationStatus.TabIndex = 4;
            this.lblApplicationStatus.Text = "Application Status";
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.label1);
            this.tabPageSettings.Controls.Add(this.dtpAutoGetDataEverydayTime);
            this.tabPageSettings.Controls.Add(this.chkRunWhenWindowsStarts);
            this.tabPageSettings.Controls.Add(this.chkGenerateJsonFile);
            this.tabPageSettings.Controls.Add(this.btnTestConnection);
            this.tabPageSettings.Controls.Add(this.txtSqlConnectionString);
            this.tabPageSettings.Controls.Add(this.lblSqlConnectionString);
            this.tabPageSettings.Controls.Add(this.btnSaveSettings);
            this.tabPageSettings.Controls.Add(this.txtLatestTableSchemaUrl);
            this.tabPageSettings.Controls.Add(this.lblLatestTableSchemaUrl);
            this.tabPageSettings.Controls.Add(this.txtApiSecret);
            this.tabPageSettings.Controls.Add(this.lblApiSecret);
            this.tabPageSettings.Controls.Add(this.txtApiKey);
            this.tabPageSettings.Controls.Add(this.lblApiKey);
            this.tabPageSettings.Controls.Add(this.txtTableFileUrl);
            this.tabPageSettings.Controls.Add(this.lblTableFileUrl);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(730, 410);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 15);
            this.label1.TabIndex = 42;
            this.label1.Text = "Auto Get Data Everyday At";
            // 
            // dtpAutoGetDataEverydayTime
            // 
            this.dtpAutoGetDataEverydayTime.Checked = false;
            this.dtpAutoGetDataEverydayTime.CustomFormat = "HH:mm";
            this.dtpAutoGetDataEverydayTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAutoGetDataEverydayTime.Location = new System.Drawing.Point(168, 307);
            this.dtpAutoGetDataEverydayTime.Name = "dtpAutoGetDataEverydayTime";
            this.dtpAutoGetDataEverydayTime.ShowCheckBox = true;
            this.dtpAutoGetDataEverydayTime.ShowUpDown = true;
            this.dtpAutoGetDataEverydayTime.Size = new System.Drawing.Size(133, 23);
            this.dtpAutoGetDataEverydayTime.TabIndex = 41;
            this.dtpAutoGetDataEverydayTime.Value = new System.DateTime(2022, 7, 31, 6, 0, 0, 0);
            // 
            // chkRunWhenWindowsStarts
            // 
            this.chkRunWhenWindowsStarts.AutoSize = true;
            this.chkRunWhenWindowsStarts.Location = new System.Drawing.Point(168, 263);
            this.chkRunWhenWindowsStarts.Name = "chkRunWhenWindowsStarts";
            this.chkRunWhenWindowsStarts.Size = new System.Drawing.Size(162, 19);
            this.chkRunWhenWindowsStarts.TabIndex = 39;
            this.chkRunWhenWindowsStarts.Text = "Run when Windows starts";
            this.chkRunWhenWindowsStarts.UseVisualStyleBackColor = true;
            this.chkRunWhenWindowsStarts.CheckedChanged += new System.EventHandler(this.chkRunWhenWindowsStarts_CheckedChanged);
            // 
            // chkGenerateJsonFile
            // 
            this.chkGenerateJsonFile.AutoSize = true;
            this.chkGenerateJsonFile.Location = new System.Drawing.Point(493, 263);
            this.chkGenerateJsonFile.Name = "chkGenerateJsonFile";
            this.chkGenerateJsonFile.Size = new System.Drawing.Size(125, 19);
            this.chkGenerateJsonFile.TabIndex = 38;
            this.chkGenerateJsonFile.Text = "Generate Json File?";
            this.chkGenerateJsonFile.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(168, 360);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(158, 23);
            this.btnTestConnection.TabIndex = 36;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtSqlConnectionString
            // 
            this.txtSqlConnectionString.Location = new System.Drawing.Point(168, 221);
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.Size = new System.Drawing.Size(450, 23);
            this.txtSqlConnectionString.TabIndex = 35;
            // 
            // lblSqlConnectionString
            // 
            this.lblSqlConnectionString.AutoSize = true;
            this.lblSqlConnectionString.Location = new System.Drawing.Point(17, 224);
            this.lblSqlConnectionString.Name = "lblSqlConnectionString";
            this.lblSqlConnectionString.Size = new System.Drawing.Size(127, 15);
            this.lblSqlConnectionString.TabIndex = 34;
            this.lblSqlConnectionString.Text = "SQL Connection String";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(460, 360);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(158, 23);
            this.btnSaveSettings.TabIndex = 33;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtLatestTableSchemaUrl
            // 
            this.txtLatestTableSchemaUrl.Location = new System.Drawing.Point(168, 170);
            this.txtLatestTableSchemaUrl.Name = "txtLatestTableSchemaUrl";
            this.txtLatestTableSchemaUrl.Size = new System.Drawing.Size(450, 23);
            this.txtLatestTableSchemaUrl.TabIndex = 32;
            this.txtLatestTableSchemaUrl.Text = "https://portal.inshosteddata.com/api/schema/latest";
            // 
            // lblLatestTableSchemaUrl
            // 
            this.lblLatestTableSchemaUrl.AutoSize = true;
            this.lblLatestTableSchemaUrl.Location = new System.Drawing.Point(17, 173);
            this.lblLatestTableSchemaUrl.Name = "lblLatestTableSchemaUrl";
            this.lblLatestTableSchemaUrl.Size = new System.Drawing.Size(131, 15);
            this.lblLatestTableSchemaUrl.TabIndex = 31;
            this.lblLatestTableSchemaUrl.Text = "Latest Table Schema Url";
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(168, 68);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.PasswordChar = '*';
            this.txtApiSecret.Size = new System.Drawing.Size(450, 23);
            this.txtApiSecret.TabIndex = 30;
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.AutoSize = true;
            this.lblApiSecret.Location = new System.Drawing.Point(17, 71);
            this.lblApiSecret.Name = "lblApiSecret";
            this.lblApiSecret.Size = new System.Drawing.Size(60, 15);
            this.lblApiSecret.TabIndex = 29;
            this.lblApiSecret.Text = "Api Secret";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(168, 22);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '*';
            this.txtApiKey.Size = new System.Drawing.Size(450, 23);
            this.txtApiKey.TabIndex = 28;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(17, 25);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(47, 15);
            this.lblApiKey.TabIndex = 27;
            this.lblApiKey.Text = "Api Key";
            // 
            // txtTableFileUrl
            // 
            this.txtTableFileUrl.Location = new System.Drawing.Point(168, 119);
            this.txtTableFileUrl.Name = "txtTableFileUrl";
            this.txtTableFileUrl.Size = new System.Drawing.Size(450, 23);
            this.txtTableFileUrl.TabIndex = 26;
            this.txtTableFileUrl.Text = "https://portal.inshosteddata.com/api/account/self/file/byTable/:tableName";
            // 
            // lblTableFileUrl
            // 
            this.lblTableFileUrl.AutoSize = true;
            this.lblTableFileUrl.Location = new System.Drawing.Point(17, 122);
            this.lblTableFileUrl.Name = "lblTableFileUrl";
            this.lblTableFileUrl.Size = new System.Drawing.Size(73, 15);
            this.lblTableFileUrl.TabIndex = 25;
            this.lblTableFileUrl.Text = "Table File Url";
            // 
            // tabPageUtilities
            // 
            this.tabPageUtilities.Controls.Add(this.btnOpenForm1);
            this.tabPageUtilities.Controls.Add(this.lblGetFilesOfTableTableName);
            this.tabPageUtilities.Controls.Add(this.txtGetFilesOfTableTableName);
            this.tabPageUtilities.Controls.Add(this.lblFilesOfTable);
            this.tabPageUtilities.Controls.Add(this.rtbFilesOfTable);
            this.tabPageUtilities.Controls.Add(this.btnGetFilesOfTable);
            this.tabPageUtilities.Location = new System.Drawing.Point(4, 24);
            this.tabPageUtilities.Name = "tabPageUtilities";
            this.tabPageUtilities.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUtilities.Size = new System.Drawing.Size(730, 410);
            this.tabPageUtilities.TabIndex = 2;
            this.tabPageUtilities.Text = "Utilities";
            this.tabPageUtilities.UseVisualStyleBackColor = true;
            // 
            // btnOpenForm1
            // 
            this.btnOpenForm1.Location = new System.Drawing.Point(551, 17);
            this.btnOpenForm1.Name = "btnOpenForm1";
            this.btnOpenForm1.Size = new System.Drawing.Size(158, 23);
            this.btnOpenForm1.TabIndex = 40;
            this.btnOpenForm1.Text = "Open Form1";
            this.btnOpenForm1.UseVisualStyleBackColor = true;
            this.btnOpenForm1.Click += new System.EventHandler(this.btnOpenForm1_Click);
            // 
            // lblGetFilesOfTableTableName
            // 
            this.lblGetFilesOfTableTableName.AutoSize = true;
            this.lblGetFilesOfTableTableName.Location = new System.Drawing.Point(18, 21);
            this.lblGetFilesOfTableTableName.Name = "lblGetFilesOfTableTableName";
            this.lblGetFilesOfTableTableName.Size = new System.Drawing.Size(69, 15);
            this.lblGetFilesOfTableTableName.TabIndex = 39;
            this.lblGetFilesOfTableTableName.Text = "Table Name";
            // 
            // txtGetFilesOfTableTableName
            // 
            this.txtGetFilesOfTableTableName.Location = new System.Drawing.Point(113, 18);
            this.txtGetFilesOfTableTableName.Name = "txtGetFilesOfTableTableName";
            this.txtGetFilesOfTableTableName.Size = new System.Drawing.Size(191, 23);
            this.txtGetFilesOfTableTableName.TabIndex = 38;
            // 
            // lblFilesOfTable
            // 
            this.lblFilesOfTable.AutoSize = true;
            this.lblFilesOfTable.Location = new System.Drawing.Point(18, 56);
            this.lblFilesOfTable.Name = "lblFilesOfTable";
            this.lblFilesOfTable.Size = new System.Drawing.Size(74, 15);
            this.lblFilesOfTable.TabIndex = 37;
            this.lblFilesOfTable.Text = "Files of Table";
            // 
            // rtbFilesOfTable
            // 
            this.rtbFilesOfTable.Location = new System.Drawing.Point(113, 54);
            this.rtbFilesOfTable.Name = "rtbFilesOfTable";
            this.rtbFilesOfTable.Size = new System.Drawing.Size(412, 239);
            this.rtbFilesOfTable.TabIndex = 36;
            this.rtbFilesOfTable.Text = "";
            // 
            // btnGetFilesOfTable
            // 
            this.btnGetFilesOfTable.Location = new System.Drawing.Point(310, 17);
            this.btnGetFilesOfTable.Name = "btnGetFilesOfTable";
            this.btnGetFilesOfTable.Size = new System.Drawing.Size(215, 23);
            this.btnGetFilesOfTable.TabIndex = 35;
            this.btnGetFilesOfTable.Text = "Get File Of Table";
            this.btnGetFilesOfTable.UseVisualStyleBackColor = true;
            this.btnGetFilesOfTable.Click += new System.EventHandler(this.btnGetFilesOfTable_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVersion,
            this.tsVersionValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(738, 22);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsVersion
            // 
            this.tsVersion.Name = "tsVersion";
            this.tsVersion.Size = new System.Drawing.Size(45, 17);
            this.tsVersion.Text = "Version";
            this.tsVersion.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tsVersionValue
            // 
            this.tsVersionValue.Name = "tsVersionValue";
            this.tsVersionValue.Size = new System.Drawing.Size(31, 17);
            this.tsVersionValue.Text = "0.0.1";
            // 
            // timerAutoGetData
            // 
            this.timerAutoGetData.Enabled = true;
            this.timerAutoGetData.Interval = 10000;
            this.timerAutoGetData.Tick += new System.EventHandler(this.timerAutoGetData_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 464);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Canvas Data Importer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tabMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabPageUtilities.ResumeLayout(false);
            this.tabPageUtilities.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TextBox txtLatestTableSchemaUrl;
        private System.Windows.Forms.Label lblLatestTableSchemaUrl;
        private System.Windows.Forms.TextBox txtApiSecret;
        private System.Windows.Forms.Label lblApiSecret;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtTableFileUrl;
        private System.Windows.Forms.Label lblTableFileUrl;
        private System.Windows.Forms.Button btnRunGetDataJob;
        private System.Windows.Forms.Label lblApplicationStatusValue;
        private System.Windows.Forms.Label lblApplicationStatus;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtSqlConnectionString;
        private System.Windows.Forms.Label lblSqlConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnStopGetDataJob;
        private System.Windows.Forms.RichTextBox rtbJobNotes;
        private System.Windows.Forms.TextBox txtGetSpecificTableData;
        private System.Windows.Forms.Label lblGetSpecificTableData;
        private System.Windows.Forms.Button btnGetSpecificTableData;
        private System.Windows.Forms.TabPage tabPageUtilities;
        private System.Windows.Forms.Label lblGetFilesOfTableTableName;
        private System.Windows.Forms.TextBox txtGetFilesOfTableTableName;
        private System.Windows.Forms.Label lblFilesOfTable;
        private System.Windows.Forms.RichTextBox rtbFilesOfTable;
        private System.Windows.Forms.Button btnGetFilesOfTable;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnOpenForm1;
        private System.Windows.Forms.CheckBox chkGenerateJsonFile;
        private System.Windows.Forms.CheckBox chkRunWhenWindowsStarts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsVersionValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAutoGetDataEverydayTime;
        private System.Windows.Forms.Timer timerAutoGetData;
    }
}