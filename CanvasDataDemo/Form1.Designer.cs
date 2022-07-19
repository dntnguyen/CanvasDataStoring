
namespace CanvasDataDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetApiData = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.lblApiSecret = new System.Windows.Forms.Label();
            this.rtbDataFromApi = new System.Windows.Forms.RichTextBox();
            this.lblDataFromApi = new System.Windows.Forms.Label();
            this.btnGetListFileData = new System.Windows.Forms.Button();
            this.dgwListFileData = new System.Windows.Forms.DataGridView();
            this.lblListFileData = new System.Windows.Forms.Label();
            this.btnDownloadFileFromLink = new System.Windows.Forms.Button();
            this.lblFileLinkFromDataGridView = new System.Windows.Forms.Label();
            this.rtbFileLinkFromDataGridView = new System.Windows.Forms.RichTextBox();
            this.txtFileFolder = new System.Windows.Forms.TextBox();
            this.lblFileFolder = new System.Windows.Forms.Label();
            this.btnDecompressFile = new System.Windows.Forms.Button();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.lblTableSchema = new System.Windows.Forms.Label();
            this.rtbTableSchema = new System.Windows.Forms.RichTextBox();
            this.txtTableSchemaUrl = new System.Windows.Forms.TextBox();
            this.lblTableSchemaUrl = new System.Windows.Forms.Label();
            this.btnGetTableSchema = new System.Windows.Forms.Button();
            this.lblListDataFileJson = new System.Windows.Forms.Label();
            this.dgwListDataFileJson = new System.Windows.Forms.DataGridView();
            this.btnCreateTableInDatabase = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListFileData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListDataFileJson)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetApiData
            // 
            this.btnGetApiData.Location = new System.Drawing.Point(428, 135);
            this.btnGetApiData.Name = "btnGetApiData";
            this.btnGetApiData.Size = new System.Drawing.Size(103, 23);
            this.btnGetApiData.TabIndex = 0;
            this.btnGetApiData.Text = "Get Api Data ";
            this.btnGetApiData.UseVisualStyleBackColor = true;
            this.btnGetApiData.Click += new System.EventHandler(this.btnGetApiData_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(24, 20);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(22, 15);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "Url";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(119, 17);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(412, 23);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Text = "https://portal.inshosteddata.com/api/account/self/file/latest";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(119, 59);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '*';
            this.txtApiKey.Size = new System.Drawing.Size(412, 23);
            this.txtApiKey.TabIndex = 4;
            this.txtApiKey.Text = "27c030d1f5a9f1d4fb0f207c519deefaf13b941e";
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(24, 62);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(47, 15);
            this.lblApiKey.TabIndex = 3;
            this.lblApiKey.Text = "Api Key";
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(119, 105);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.PasswordChar = '*';
            this.txtApiSecret.Size = new System.Drawing.Size(412, 23);
            this.txtApiSecret.TabIndex = 6;
            this.txtApiSecret.Text = "ae6677cd7f94043d1c745ef0b31ebaba2d829fb2";
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.AutoSize = true;
            this.lblApiSecret.Location = new System.Drawing.Point(24, 108);
            this.lblApiSecret.Name = "lblApiSecret";
            this.lblApiSecret.Size = new System.Drawing.Size(60, 15);
            this.lblApiSecret.TabIndex = 5;
            this.lblApiSecret.Text = "Api Secret";
            // 
            // rtbDataFromApi
            // 
            this.rtbDataFromApi.Location = new System.Drawing.Point(119, 172);
            this.rtbDataFromApi.Name = "rtbDataFromApi";
            this.rtbDataFromApi.Size = new System.Drawing.Size(412, 96);
            this.rtbDataFromApi.TabIndex = 7;
            this.rtbDataFromApi.Text = "";
            // 
            // lblDataFromApi
            // 
            this.lblDataFromApi.AutoSize = true;
            this.lblDataFromApi.Location = new System.Drawing.Point(24, 174);
            this.lblDataFromApi.Name = "lblDataFromApi";
            this.lblDataFromApi.Size = new System.Drawing.Size(83, 15);
            this.lblDataFromApi.TabIndex = 8;
            this.lblDataFromApi.Text = "Data From Api";
            // 
            // btnGetListFileData
            // 
            this.btnGetListFileData.Location = new System.Drawing.Point(428, 283);
            this.btnGetListFileData.Name = "btnGetListFileData";
            this.btnGetListFileData.Size = new System.Drawing.Size(103, 23);
            this.btnGetListFileData.TabIndex = 9;
            this.btnGetListFileData.Text = "Get List File Data ";
            this.btnGetListFileData.UseVisualStyleBackColor = true;
            this.btnGetListFileData.Click += new System.EventHandler(this.btnGetListFileData_Click);
            // 
            // dgwListFileData
            // 
            this.dgwListFileData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListFileData.Location = new System.Drawing.Point(119, 312);
            this.dgwListFileData.Name = "dgwListFileData";
            this.dgwListFileData.RowTemplate.Height = 25;
            this.dgwListFileData.Size = new System.Drawing.Size(412, 150);
            this.dgwListFileData.TabIndex = 10;
            // 
            // lblListFileData
            // 
            this.lblListFileData.AutoSize = true;
            this.lblListFileData.Location = new System.Drawing.Point(24, 312);
            this.lblListFileData.Name = "lblListFileData";
            this.lblListFileData.Size = new System.Drawing.Size(73, 15);
            this.lblListFileData.TabIndex = 11;
            this.lblListFileData.Text = "List File Data";
            // 
            // btnDownloadFileFromLink
            // 
            this.btnDownloadFileFromLink.Location = new System.Drawing.Point(936, 12);
            this.btnDownloadFileFromLink.Name = "btnDownloadFileFromLink";
            this.btnDownloadFileFromLink.Size = new System.Drawing.Size(215, 23);
            this.btnDownloadFileFromLink.TabIndex = 12;
            this.btnDownloadFileFromLink.Text = "Donwload File From Link To Folder";
            this.btnDownloadFileFromLink.UseVisualStyleBackColor = true;
            this.btnDownloadFileFromLink.Click += new System.EventHandler(this.btnDownloadFileFromLink_Click);
            // 
            // lblFileLinkFromDataGridView
            // 
            this.lblFileLinkFromDataGridView.AutoSize = true;
            this.lblFileLinkFromDataGridView.Location = new System.Drawing.Point(24, 488);
            this.lblFileLinkFromDataGridView.Name = "lblFileLinkFromDataGridView";
            this.lblFileLinkFromDataGridView.Size = new System.Drawing.Size(50, 15);
            this.lblFileLinkFromDataGridView.TabIndex = 13;
            this.lblFileLinkFromDataGridView.Text = "File Link";
            // 
            // rtbFileLinkFromDataGridView
            // 
            this.rtbFileLinkFromDataGridView.DetectUrls = false;
            this.rtbFileLinkFromDataGridView.Location = new System.Drawing.Point(119, 485);
            this.rtbFileLinkFromDataGridView.Name = "rtbFileLinkFromDataGridView";
            this.rtbFileLinkFromDataGridView.Size = new System.Drawing.Size(412, 96);
            this.rtbFileLinkFromDataGridView.TabIndex = 15;
            this.rtbFileLinkFromDataGridView.Text = "";
            // 
            // txtFileFolder
            // 
            this.txtFileFolder.Location = new System.Drawing.Point(739, 41);
            this.txtFileFolder.Name = "txtFileFolder";
            this.txtFileFolder.Size = new System.Drawing.Size(412, 23);
            this.txtFileFolder.TabIndex = 16;
            this.txtFileFolder.Text = "FileData";
            // 
            // lblFileFolder
            // 
            this.lblFileFolder.AutoSize = true;
            this.lblFileFolder.Location = new System.Drawing.Point(644, 44);
            this.lblFileFolder.Name = "lblFileFolder";
            this.lblFileFolder.Size = new System.Drawing.Size(89, 15);
            this.lblFileFolder.TabIndex = 17;
            this.lblFileFolder.Text = "File folder root\\";
            // 
            // btnDecompressFile
            // 
            this.btnDecompressFile.Location = new System.Drawing.Point(936, 88);
            this.btnDecompressFile.Name = "btnDecompressFile";
            this.btnDecompressFile.Size = new System.Drawing.Size(215, 23);
            this.btnDecompressFile.TabIndex = 18;
            this.btnDecompressFile.Text = "Decompress File";
            this.btnDecompressFile.UseVisualStyleBackColor = true;
            this.btnDecompressFile.Click += new System.EventHandler(this.btnDecompressFile_Click);
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(936, 304);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(215, 23);
            this.btnReadFile.TabIndex = 19;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // lblTableSchema
            // 
            this.lblTableSchema.AutoSize = true;
            this.lblTableSchema.Location = new System.Drawing.Point(644, 197);
            this.lblTableSchema.Name = "lblTableSchema";
            this.lblTableSchema.Size = new System.Drawing.Size(79, 15);
            this.lblTableSchema.TabIndex = 22;
            this.lblTableSchema.Text = "Table Schema";
            // 
            // rtbTableSchema
            // 
            this.rtbTableSchema.Location = new System.Drawing.Point(739, 199);
            this.rtbTableSchema.Name = "rtbTableSchema";
            this.rtbTableSchema.Size = new System.Drawing.Size(412, 69);
            this.rtbTableSchema.TabIndex = 21;
            this.rtbTableSchema.Text = "";
            // 
            // txtTableSchemaUrl
            // 
            this.txtTableSchemaUrl.Location = new System.Drawing.Point(739, 136);
            this.txtTableSchemaUrl.Name = "txtTableSchemaUrl";
            this.txtTableSchemaUrl.Size = new System.Drawing.Size(412, 23);
            this.txtTableSchemaUrl.TabIndex = 24;
            this.txtTableSchemaUrl.Text = "https://portal.inshosteddata.com/api/schema/latest";
            // 
            // lblTableSchemaUrl
            // 
            this.lblTableSchemaUrl.AutoSize = true;
            this.lblTableSchemaUrl.Location = new System.Drawing.Point(644, 139);
            this.lblTableSchemaUrl.Name = "lblTableSchemaUrl";
            this.lblTableSchemaUrl.Size = new System.Drawing.Size(97, 15);
            this.lblTableSchemaUrl.TabIndex = 23;
            this.lblTableSchemaUrl.Text = "Table Schema Url";
            // 
            // btnGetTableSchema
            // 
            this.btnGetTableSchema.Location = new System.Drawing.Point(936, 170);
            this.btnGetTableSchema.Name = "btnGetTableSchema";
            this.btnGetTableSchema.Size = new System.Drawing.Size(215, 23);
            this.btnGetTableSchema.TabIndex = 25;
            this.btnGetTableSchema.Text = "Get Table Schema";
            this.btnGetTableSchema.UseVisualStyleBackColor = true;
            this.btnGetTableSchema.Click += new System.EventHandler(this.btnGetTableSchema_Click);
            // 
            // lblListDataFileJson
            // 
            this.lblListDataFileJson.AutoSize = true;
            this.lblListDataFileJson.Location = new System.Drawing.Point(644, 353);
            this.lblListDataFileJson.Name = "lblListDataFileJson";
            this.lblListDataFileJson.Size = new System.Drawing.Size(73, 15);
            this.lblListDataFileJson.TabIndex = 27;
            this.lblListDataFileJson.Text = "List File Data";
            // 
            // dgwListDataFileJson
            // 
            this.dgwListDataFileJson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListDataFileJson.Location = new System.Drawing.Point(739, 353);
            this.dgwListDataFileJson.Name = "dgwListDataFileJson";
            this.dgwListDataFileJson.RowTemplate.Height = 25;
            this.dgwListDataFileJson.Size = new System.Drawing.Size(412, 150);
            this.dgwListDataFileJson.TabIndex = 26;
            // 
            // btnCreateTableInDatabase
            // 
            this.btnCreateTableInDatabase.Location = new System.Drawing.Point(936, 537);
            this.btnCreateTableInDatabase.Name = "btnCreateTableInDatabase";
            this.btnCreateTableInDatabase.Size = new System.Drawing.Size(215, 23);
            this.btnCreateTableInDatabase.TabIndex = 28;
            this.btnCreateTableInDatabase.Text = "Create Table In Database";
            this.btnCreateTableInDatabase.UseVisualStyleBackColor = true;
            this.btnCreateTableInDatabase.Click += new System.EventHandler(this.btnCreateTableInDatabase_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(739, 88);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(177, 23);
            this.btnOpenFolder.TabIndex = 29;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 645);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnCreateTableInDatabase);
            this.Controls.Add(this.lblListDataFileJson);
            this.Controls.Add(this.dgwListDataFileJson);
            this.Controls.Add(this.btnGetTableSchema);
            this.Controls.Add(this.txtTableSchemaUrl);
            this.Controls.Add(this.lblTableSchemaUrl);
            this.Controls.Add(this.lblTableSchema);
            this.Controls.Add(this.rtbTableSchema);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.btnDecompressFile);
            this.Controls.Add(this.lblFileFolder);
            this.Controls.Add(this.txtFileFolder);
            this.Controls.Add(this.rtbFileLinkFromDataGridView);
            this.Controls.Add(this.lblFileLinkFromDataGridView);
            this.Controls.Add(this.btnDownloadFileFromLink);
            this.Controls.Add(this.lblListFileData);
            this.Controls.Add(this.dgwListFileData);
            this.Controls.Add(this.btnGetListFileData);
            this.Controls.Add(this.lblDataFromApi);
            this.Controls.Add(this.rtbDataFromApi);
            this.Controls.Add(this.txtApiSecret);
            this.Controls.Add(this.lblApiSecret);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnGetApiData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListFileData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListDataFileJson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetApiData;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiSecret;
        private System.Windows.Forms.Label lblApiSecret;
        private System.Windows.Forms.RichTextBox rtbDataFromApi;
        private System.Windows.Forms.Label lblDataFromApi;
        private System.Windows.Forms.Button btnGetListFileData;
        private System.Windows.Forms.DataGridView dgwListFileData;
        private System.Windows.Forms.Label lblListFileData;
        private System.Windows.Forms.Button btnDownloadFileFromLink;
        private System.Windows.Forms.Label lblFileLinkFromDataGridView;
        private System.Windows.Forms.RichTextBox rtbFileLinkFromDataGridView;
        private System.Windows.Forms.TextBox txtFileFolder;
        private System.Windows.Forms.Label lblFileFolder;
        private System.Windows.Forms.Button btnDecompressFile;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Label lblTableSchema;
        private System.Windows.Forms.RichTextBox rtbTableSchema;
        private System.Windows.Forms.TextBox txtTableSchemaUrl;
        private System.Windows.Forms.Label lblTableSchemaUrl;
        private System.Windows.Forms.Button btnGetTableSchema;
        private System.Windows.Forms.Label lblListDataFileJson;
        private System.Windows.Forms.DataGridView dgwListDataFileJson;
        private System.Windows.Forms.Button btnCreateTableInDatabase;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}
