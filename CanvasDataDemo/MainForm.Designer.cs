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
            this.lblSequence = new System.Windows.Forms.Label();
            this.txtSequence = new System.Windows.Forms.TextBox();
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
            this.btnGetTableSyncHistoryData = new System.Windows.Forms.Button();
            this.btnGetTableSyncData = new System.Windows.Forms.Button();
            this.btnGetLatestSchema = new System.Windows.Forms.Button();
            this.lblGetFilesOfTableTableName = new System.Windows.Forms.Label();
            this.txtGetFilesOfTableTableName = new System.Windows.Forms.TextBox();
            this.lblResultData = new System.Windows.Forms.Label();
            this.rtbResultData = new System.Windows.Forms.RichTextBox();
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
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1023, 582);
            this.tabMain.TabIndex = 4;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.lblSequence);
            this.tabPageMain.Controls.Add(this.txtSequence);
            this.tabPageMain.Controls.Add(this.txtGetSpecificTableData);
            this.tabPageMain.Controls.Add(this.lblGetSpecificTableData);
            this.tabPageMain.Controls.Add(this.btnGetSpecificTableData);
            this.tabPageMain.Controls.Add(this.rtbJobNotes);
            this.tabPageMain.Controls.Add(this.btnStopGetDataJob);
            this.tabPageMain.Controls.Add(this.btnRunGetDataJob);
            this.tabPageMain.Controls.Add(this.lblApplicationStatusValue);
            this.tabPageMain.Controls.Add(this.lblApplicationStatus);
            this.tabPageMain.Location = new System.Drawing.Point(4, 29);
            this.tabPageMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageMain.Size = new System.Drawing.Size(1015, 549);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // lblSequence
            // 
            this.lblSequence.Location = new System.Drawing.Point(8, 167);
            this.lblSequence.Name = "lblSequence";
            this.lblSequence.Size = new System.Drawing.Size(162, 65);
            this.lblSequence.TabIndex = 44;
            this.lblSequence.Text = "Sequence (leave it empty to get latest sequence)";
            // 
            // txtSequence
            // 
            this.txtSequence.Location = new System.Drawing.Point(177, 163);
            this.txtSequence.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(95, 27);
            this.txtSequence.TabIndex = 43;
            // 
            // txtGetSpecificTableData
            // 
            this.txtGetSpecificTableData.Location = new System.Drawing.Point(177, 124);
            this.txtGetSpecificTableData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGetSpecificTableData.Name = "txtGetSpecificTableData";
            this.txtGetSpecificTableData.Size = new System.Drawing.Size(180, 27);
            this.txtGetSpecificTableData.TabIndex = 42;
            // 
            // lblGetSpecificTableData
            // 
            this.lblGetSpecificTableData.AutoSize = true;
            this.lblGetSpecificTableData.Location = new System.Drawing.Point(8, 128);
            this.lblGetSpecificTableData.Name = "lblGetSpecificTableData";
            this.lblGetSpecificTableData.Size = new System.Drawing.Size(163, 20);
            this.lblGetSpecificTableData.TabIndex = 41;
            this.lblGetSpecificTableData.Text = "Get Specific Table Data";
            // 
            // btnGetSpecificTableData
            // 
            this.btnGetSpecificTableData.Location = new System.Drawing.Point(177, 201);
            this.btnGetSpecificTableData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetSpecificTableData.Name = "btnGetSpecificTableData";
            this.btnGetSpecificTableData.Size = new System.Drawing.Size(181, 31);
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
            this.rtbJobNotes.Location = new System.Drawing.Point(25, 255);
            this.rtbJobNotes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbJobNotes.Name = "rtbJobNotes";
            this.rtbJobNotes.Size = new System.Drawing.Size(968, 281);
            this.rtbJobNotes.TabIndex = 39;
            this.rtbJobNotes.Text = "";
            // 
            // btnStopGetDataJob
            // 
            this.btnStopGetDataJob.Enabled = false;
            this.btnStopGetDataJob.Location = new System.Drawing.Point(448, 201);
            this.btnStopGetDataJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStopGetDataJob.Name = "btnStopGetDataJob";
            this.btnStopGetDataJob.Size = new System.Drawing.Size(181, 31);
            this.btnStopGetDataJob.TabIndex = 38;
            this.btnStopGetDataJob.Text = "Stop Get Data Job";
            this.btnStopGetDataJob.UseVisualStyleBackColor = true;
            this.btnStopGetDataJob.Click += new System.EventHandler(this.btnStopGetDataJob_Click);
            // 
            // btnRunGetDataJob
            // 
            this.btnRunGetDataJob.Location = new System.Drawing.Point(177, 68);
            this.btnRunGetDataJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRunGetDataJob.Name = "btnRunGetDataJob";
            this.btnRunGetDataJob.Size = new System.Drawing.Size(181, 31);
            this.btnRunGetDataJob.TabIndex = 6;
            this.btnRunGetDataJob.Text = "Run Get Data Job";
            this.btnRunGetDataJob.UseVisualStyleBackColor = true;
            this.btnRunGetDataJob.Click += new System.EventHandler(this.btnRunGetDataJob_Click);
            // 
            // lblApplicationStatusValue
            // 
            this.lblApplicationStatusValue.AutoSize = true;
            this.lblApplicationStatusValue.Location = new System.Drawing.Point(177, 21);
            this.lblApplicationStatusValue.Name = "lblApplicationStatusValue";
            this.lblApplicationStatusValue.Size = new System.Drawing.Size(45, 20);
            this.lblApplicationStatusValue.TabIndex = 5;
            this.lblApplicationStatusValue.Text = "None";
            // 
            // lblApplicationStatus
            // 
            this.lblApplicationStatus.AutoSize = true;
            this.lblApplicationStatus.Location = new System.Drawing.Point(8, 21);
            this.lblApplicationStatus.Name = "lblApplicationStatus";
            this.lblApplicationStatus.Size = new System.Drawing.Size(130, 20);
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
            this.tabPageSettings.Location = new System.Drawing.Point(4, 29);
            this.tabPageSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageSettings.Size = new System.Drawing.Size(1015, 549);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Auto Get Data Everyday At";
            // 
            // dtpAutoGetDataEverydayTime
            // 
            this.dtpAutoGetDataEverydayTime.Checked = false;
            this.dtpAutoGetDataEverydayTime.CustomFormat = "HH:mm";
            this.dtpAutoGetDataEverydayTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAutoGetDataEverydayTime.Location = new System.Drawing.Point(192, 409);
            this.dtpAutoGetDataEverydayTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpAutoGetDataEverydayTime.Name = "dtpAutoGetDataEverydayTime";
            this.dtpAutoGetDataEverydayTime.ShowCheckBox = true;
            this.dtpAutoGetDataEverydayTime.ShowUpDown = true;
            this.dtpAutoGetDataEverydayTime.Size = new System.Drawing.Size(151, 27);
            this.dtpAutoGetDataEverydayTime.TabIndex = 41;
            this.dtpAutoGetDataEverydayTime.Value = new System.DateTime(2022, 7, 31, 6, 0, 0, 0);
            // 
            // chkRunWhenWindowsStarts
            // 
            this.chkRunWhenWindowsStarts.AutoSize = true;
            this.chkRunWhenWindowsStarts.Location = new System.Drawing.Point(192, 351);
            this.chkRunWhenWindowsStarts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkRunWhenWindowsStarts.Name = "chkRunWhenWindowsStarts";
            this.chkRunWhenWindowsStarts.Size = new System.Drawing.Size(199, 24);
            this.chkRunWhenWindowsStarts.TabIndex = 39;
            this.chkRunWhenWindowsStarts.Text = "Run when Windows starts";
            this.chkRunWhenWindowsStarts.UseVisualStyleBackColor = true;
            this.chkRunWhenWindowsStarts.CheckedChanged += new System.EventHandler(this.chkRunWhenWindowsStarts_CheckedChanged);
            // 
            // chkGenerateJsonFile
            // 
            this.chkGenerateJsonFile.AutoSize = true;
            this.chkGenerateJsonFile.Location = new System.Drawing.Point(563, 351);
            this.chkGenerateJsonFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkGenerateJsonFile.Name = "chkGenerateJsonFile";
            this.chkGenerateJsonFile.Size = new System.Drawing.Size(157, 24);
            this.chkGenerateJsonFile.TabIndex = 38;
            this.chkGenerateJsonFile.Text = "Generate Json File?";
            this.chkGenerateJsonFile.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(192, 480);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(181, 31);
            this.btnTestConnection.TabIndex = 36;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtSqlConnectionString
            // 
            this.txtSqlConnectionString.Location = new System.Drawing.Point(192, 295);
            this.txtSqlConnectionString.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.Size = new System.Drawing.Size(514, 27);
            this.txtSqlConnectionString.TabIndex = 35;
            // 
            // lblSqlConnectionString
            // 
            this.lblSqlConnectionString.AutoSize = true;
            this.lblSqlConnectionString.Location = new System.Drawing.Point(19, 299);
            this.lblSqlConnectionString.Name = "lblSqlConnectionString";
            this.lblSqlConnectionString.Size = new System.Drawing.Size(157, 20);
            this.lblSqlConnectionString.TabIndex = 34;
            this.lblSqlConnectionString.Text = "SQL Connection String";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(526, 480);
            this.btnSaveSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(181, 31);
            this.btnSaveSettings.TabIndex = 33;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtLatestTableSchemaUrl
            // 
            this.txtLatestTableSchemaUrl.Location = new System.Drawing.Point(192, 227);
            this.txtLatestTableSchemaUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLatestTableSchemaUrl.Name = "txtLatestTableSchemaUrl";
            this.txtLatestTableSchemaUrl.Size = new System.Drawing.Size(514, 27);
            this.txtLatestTableSchemaUrl.TabIndex = 32;
            this.txtLatestTableSchemaUrl.Text = "https://portal.inshosteddata.com/api/schema/latest";
            // 
            // lblLatestTableSchemaUrl
            // 
            this.lblLatestTableSchemaUrl.AutoSize = true;
            this.lblLatestTableSchemaUrl.Location = new System.Drawing.Point(19, 231);
            this.lblLatestTableSchemaUrl.Name = "lblLatestTableSchemaUrl";
            this.lblLatestTableSchemaUrl.Size = new System.Drawing.Size(166, 20);
            this.lblLatestTableSchemaUrl.TabIndex = 31;
            this.lblLatestTableSchemaUrl.Text = "Latest Table Schema Url";
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(192, 91);
            this.txtApiSecret.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.PasswordChar = '*';
            this.txtApiSecret.Size = new System.Drawing.Size(514, 27);
            this.txtApiSecret.TabIndex = 30;
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.AutoSize = true;
            this.lblApiSecret.Location = new System.Drawing.Point(19, 95);
            this.lblApiSecret.Name = "lblApiSecret";
            this.lblApiSecret.Size = new System.Drawing.Size(77, 20);
            this.lblApiSecret.TabIndex = 29;
            this.lblApiSecret.Text = "Api Secret";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(192, 29);
            this.txtApiKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '*';
            this.txtApiKey.Size = new System.Drawing.Size(514, 27);
            this.txtApiKey.TabIndex = 28;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(19, 33);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(60, 20);
            this.lblApiKey.TabIndex = 27;
            this.lblApiKey.Text = "Api Key";
            // 
            // txtTableFileUrl
            // 
            this.txtTableFileUrl.Location = new System.Drawing.Point(192, 159);
            this.txtTableFileUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTableFileUrl.Name = "txtTableFileUrl";
            this.txtTableFileUrl.Size = new System.Drawing.Size(514, 27);
            this.txtTableFileUrl.TabIndex = 26;
            this.txtTableFileUrl.Text = "https://portal.inshosteddata.com/api/account/self/file/byTable/:tableName";
            // 
            // lblTableFileUrl
            // 
            this.lblTableFileUrl.AutoSize = true;
            this.lblTableFileUrl.Location = new System.Drawing.Point(19, 163);
            this.lblTableFileUrl.Name = "lblTableFileUrl";
            this.lblTableFileUrl.Size = new System.Drawing.Size(94, 20);
            this.lblTableFileUrl.TabIndex = 25;
            this.lblTableFileUrl.Text = "Table File Url";
            // 
            // tabPageUtilities
            // 
            this.tabPageUtilities.Controls.Add(this.btnGetTableSyncHistoryData);
            this.tabPageUtilities.Controls.Add(this.btnGetTableSyncData);
            this.tabPageUtilities.Controls.Add(this.btnGetLatestSchema);
            this.tabPageUtilities.Controls.Add(this.lblGetFilesOfTableTableName);
            this.tabPageUtilities.Controls.Add(this.txtGetFilesOfTableTableName);
            this.tabPageUtilities.Controls.Add(this.lblResultData);
            this.tabPageUtilities.Controls.Add(this.rtbResultData);
            this.tabPageUtilities.Controls.Add(this.btnGetFilesOfTable);
            this.tabPageUtilities.Location = new System.Drawing.Point(4, 29);
            this.tabPageUtilities.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageUtilities.Name = "tabPageUtilities";
            this.tabPageUtilities.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPageUtilities.Size = new System.Drawing.Size(1015, 549);
            this.tabPageUtilities.TabIndex = 2;
            this.tabPageUtilities.Text = "Utilities";
            this.tabPageUtilities.UseVisualStyleBackColor = true;
            // 
            // btnGetTableSyncHistoryData
            // 
            this.btnGetTableSyncHistoryData.Location = new System.Drawing.Point(743, 80);
            this.btnGetTableSyncHistoryData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetTableSyncHistoryData.Name = "btnGetTableSyncHistoryData";
            this.btnGetTableSyncHistoryData.Size = new System.Drawing.Size(246, 31);
            this.btnGetTableSyncHistoryData.TabIndex = 43;
            this.btnGetTableSyncHistoryData.Text = "Get TableSyncHistory Data";
            this.btnGetTableSyncHistoryData.UseVisualStyleBackColor = true;
            this.btnGetTableSyncHistoryData.Click += new System.EventHandler(this.btnGetTableSyncHistoryData_Click);
            // 
            // btnGetTableSyncData
            // 
            this.btnGetTableSyncData.Location = new System.Drawing.Point(743, 22);
            this.btnGetTableSyncData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetTableSyncData.Name = "btnGetTableSyncData";
            this.btnGetTableSyncData.Size = new System.Drawing.Size(246, 31);
            this.btnGetTableSyncData.TabIndex = 42;
            this.btnGetTableSyncData.Text = "Get TableSync Data";
            this.btnGetTableSyncData.UseVisualStyleBackColor = true;
            this.btnGetTableSyncData.Click += new System.EventHandler(this.btnGetTableSyncData_Click);
            // 
            // btnGetLatestSchema
            // 
            this.btnGetLatestSchema.Location = new System.Drawing.Point(354, 80);
            this.btnGetLatestSchema.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetLatestSchema.Name = "btnGetLatestSchema";
            this.btnGetLatestSchema.Size = new System.Drawing.Size(246, 31);
            this.btnGetLatestSchema.TabIndex = 41;
            this.btnGetLatestSchema.Text = "Get Latest Schema";
            this.btnGetLatestSchema.UseVisualStyleBackColor = true;
            this.btnGetLatestSchema.Click += new System.EventHandler(this.btnGetLatestSchema_Click);
            // 
            // lblGetFilesOfTableTableName
            // 
            this.lblGetFilesOfTableTableName.AutoSize = true;
            this.lblGetFilesOfTableTableName.Location = new System.Drawing.Point(21, 28);
            this.lblGetFilesOfTableTableName.Name = "lblGetFilesOfTableTableName";
            this.lblGetFilesOfTableTableName.Size = new System.Drawing.Size(88, 20);
            this.lblGetFilesOfTableTableName.TabIndex = 39;
            this.lblGetFilesOfTableTableName.Text = "Table Name";
            // 
            // txtGetFilesOfTableTableName
            // 
            this.txtGetFilesOfTableTableName.Location = new System.Drawing.Point(129, 24);
            this.txtGetFilesOfTableTableName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGetFilesOfTableTableName.Name = "txtGetFilesOfTableTableName";
            this.txtGetFilesOfTableTableName.Size = new System.Drawing.Size(218, 27);
            this.txtGetFilesOfTableTableName.TabIndex = 38;
            // 
            // lblResultData
            // 
            this.lblResultData.AutoSize = true;
            this.lblResultData.Location = new System.Drawing.Point(21, 180);
            this.lblResultData.Name = "lblResultData";
            this.lblResultData.Size = new System.Drawing.Size(85, 20);
            this.lblResultData.TabIndex = 37;
            this.lblResultData.Text = "Result Data";
            // 
            // rtbResultData
            // 
            this.rtbResultData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbResultData.Location = new System.Drawing.Point(129, 176);
            this.rtbResultData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbResultData.Name = "rtbResultData";
            this.rtbResultData.Size = new System.Drawing.Size(860, 316);
            this.rtbResultData.TabIndex = 36;
            this.rtbResultData.Text = "";
            // 
            // btnGetFilesOfTable
            // 
            this.btnGetFilesOfTable.Location = new System.Drawing.Point(354, 23);
            this.btnGetFilesOfTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetFilesOfTable.Name = "btnGetFilesOfTable";
            this.btnGetFilesOfTable.Size = new System.Drawing.Size(246, 31);
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
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVersion,
            this.tsVersionValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 591);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1023, 26);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsVersion
            // 
            this.tsVersion.Name = "tsVersion";
            this.tsVersion.Size = new System.Drawing.Size(57, 20);
            this.tsVersion.Text = "Version";
            this.tsVersion.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // tsVersionValue
            // 
            this.tsVersionValue.Name = "tsVersionValue";
            this.tsVersionValue.Size = new System.Drawing.Size(39, 20);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 617);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.Label lblResultData;
        private System.Windows.Forms.RichTextBox rtbResultData;
        private System.Windows.Forms.Button btnGetFilesOfTable;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox chkGenerateJsonFile;
        private System.Windows.Forms.CheckBox chkRunWhenWindowsStarts;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsVersion;
        private System.Windows.Forms.ToolStripStatusLabel tsVersionValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAutoGetDataEverydayTime;
        private System.Windows.Forms.Timer timerAutoGetData;
        private System.Windows.Forms.TextBox txtSequence;
        private System.Windows.Forms.Label lblSequence;
        private System.Windows.Forms.Button btnGetLatestSchema;
        private System.Windows.Forms.Button btnGetTableSyncHistoryData;
        private System.Windows.Forms.Button btnGetTableSyncData;
    }
}