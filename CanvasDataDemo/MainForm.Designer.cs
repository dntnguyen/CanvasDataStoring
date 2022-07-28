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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.btnRunGetDataJob = new System.Windows.Forms.Button();
            this.lblApplicationStatusValue = new System.Windows.Forms.Label();
            this.lblApplicationStatus = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.lblSqlConnectionString = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtTableSchemaUrl = new System.Windows.Forms.TextBox();
            this.lblTableSchemaUrl = new System.Windows.Forms.Label();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.lblApiSecret = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtFileLatestSchemaUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPageMain);
            this.tabMain.Controls.Add(this.tabPageSettings);
            this.tabMain.Location = new System.Drawing.Point(1, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(613, 416);
            this.tabMain.TabIndex = 4;
            // 
            // tabPageMain
            // 
            this.tabPageMain.Controls.Add(this.btnRunGetDataJob);
            this.tabPageMain.Controls.Add(this.lblApplicationStatusValue);
            this.tabPageMain.Controls.Add(this.lblApplicationStatus);
            this.tabPageMain.Location = new System.Drawing.Point(4, 24);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(605, 388);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // btnRunGetDataJob
            // 
            this.btnRunGetDataJob.Location = new System.Drawing.Point(19, 56);
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
            this.lblApplicationStatusValue.Location = new System.Drawing.Point(141, 16);
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
            this.tabPageSettings.Controls.Add(this.btnTestConnection);
            this.tabPageSettings.Controls.Add(this.txtSqlConnectionString);
            this.tabPageSettings.Controls.Add(this.lblSqlConnectionString);
            this.tabPageSettings.Controls.Add(this.btnSaveSettings);
            this.tabPageSettings.Controls.Add(this.txtTableSchemaUrl);
            this.tabPageSettings.Controls.Add(this.lblTableSchemaUrl);
            this.tabPageSettings.Controls.Add(this.txtApiSecret);
            this.tabPageSettings.Controls.Add(this.lblApiSecret);
            this.tabPageSettings.Controls.Add(this.txtApiKey);
            this.tabPageSettings.Controls.Add(this.lblApiKey);
            this.tabPageSettings.Controls.Add(this.txtFileLatestSchemaUrl);
            this.tabPageSettings.Controls.Add(this.lblUrl);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(605, 388);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // txtSqlConnectionString
            // 
            this.txtSqlConnectionString.Location = new System.Drawing.Point(168, 221);
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.Size = new System.Drawing.Size(412, 23);
            this.txtSqlConnectionString.TabIndex = 35;
            // 
            // lblSqlConnectionString
            // 
            this.lblSqlConnectionString.AutoSize = true;
            this.lblSqlConnectionString.Location = new System.Drawing.Point(24, 224);
            this.lblSqlConnectionString.Name = "lblSqlConnectionString";
            this.lblSqlConnectionString.Size = new System.Drawing.Size(127, 15);
            this.lblSqlConnectionString.TabIndex = 34;
            this.lblSqlConnectionString.Text = "SQL Connection String";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(422, 264);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(158, 23);
            this.btnSaveSettings.TabIndex = 33;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtTableSchemaUrl
            // 
            this.txtTableSchemaUrl.Location = new System.Drawing.Point(168, 170);
            this.txtTableSchemaUrl.Name = "txtTableSchemaUrl";
            this.txtTableSchemaUrl.Size = new System.Drawing.Size(412, 23);
            this.txtTableSchemaUrl.TabIndex = 32;
            this.txtTableSchemaUrl.Text = "https://portal.inshosteddata.com/api/schema/latest";
            // 
            // lblTableSchemaUrl
            // 
            this.lblTableSchemaUrl.AutoSize = true;
            this.lblTableSchemaUrl.Location = new System.Drawing.Point(24, 173);
            this.lblTableSchemaUrl.Name = "lblTableSchemaUrl";
            this.lblTableSchemaUrl.Size = new System.Drawing.Size(97, 15);
            this.lblTableSchemaUrl.TabIndex = 31;
            this.lblTableSchemaUrl.Text = "Table Schema Url";
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(168, 68);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.PasswordChar = '*';
            this.txtApiSecret.Size = new System.Drawing.Size(412, 23);
            this.txtApiSecret.TabIndex = 30;
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.AutoSize = true;
            this.lblApiSecret.Location = new System.Drawing.Point(24, 71);
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
            this.txtApiKey.Size = new System.Drawing.Size(412, 23);
            this.txtApiKey.TabIndex = 28;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(24, 25);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(47, 15);
            this.lblApiKey.TabIndex = 27;
            this.lblApiKey.Text = "Api Key";
            // 
            // txtFileLatestSchemaUrl
            // 
            this.txtFileLatestSchemaUrl.Location = new System.Drawing.Point(168, 119);
            this.txtFileLatestSchemaUrl.Name = "txtFileLatestSchemaUrl";
            this.txtFileLatestSchemaUrl.Size = new System.Drawing.Size(412, 23);
            this.txtFileLatestSchemaUrl.TabIndex = 26;
            this.txtFileLatestSchemaUrl.Text = "https://portal.inshosteddata.com/api/account/self/file/latest";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(24, 122);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(122, 15);
            this.lblUrl.TabIndex = 25;
            this.lblUrl.Text = "File Latest Schema Url";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(168, 264);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(158, 23);
            this.btnTestConnection.TabIndex = 36;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 416);
            this.Controls.Add(this.tabMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TextBox txtTableSchemaUrl;
        private System.Windows.Forms.Label lblTableSchemaUrl;
        private System.Windows.Forms.TextBox txtApiSecret;
        private System.Windows.Forms.Label lblApiSecret;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtFileLatestSchemaUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnRunGetDataJob;
        private System.Windows.Forms.Label lblApplicationStatusValue;
        private System.Windows.Forms.Label lblApplicationStatus;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtSqlConnectionString;
        private System.Windows.Forms.Label lblSqlConnectionString;
        private System.Windows.Forms.Button btnTestConnection;
    }
}