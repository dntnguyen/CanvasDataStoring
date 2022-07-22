
namespace CanvasDataDemoNetFramework
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtApiSecret = new System.Windows.Forms.TextBox();
            this.lblApiSecret = new System.Windows.Forms.Label();
            this.btnGetApiData = new System.Windows.Forms.Button();
            this.lblDataFromApi = new System.Windows.Forms.Label();
            this.rtbDataFromApi = new System.Windows.Forms.RichTextBox();
            this.btnGetListFileData = new System.Windows.Forms.Button();
            this.dgwListFileData = new System.Windows.Forms.DataGridView();
            this.lblListFileData = new System.Windows.Forms.Label();
            this.btnDownloadFileFromLink = new System.Windows.Forms.Button();
            this.txtFileFolder = new System.Windows.Forms.TextBox();
            this.lblFileFolder = new System.Windows.Forms.Label();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnDecompressFile = new System.Windows.Forms.Button();
            this.txtTableSchemaUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGetTableSchema = new System.Windows.Forms.Button();
            this.rtbTableSchema = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReadFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dgwListDataFileJson = new System.Windows.Forms.DataGridView();
            this.rtbFileLinkFromDataGridView = new System.Windows.Forms.RichTextBox();
            this.lblFileLinkFromDataGridView = new System.Windows.Forms.Label();
            this.btnCreateTableInDatabase = new System.Windows.Forms.Button();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.lblSqlConnectionString = new System.Windows.Forms.Label();
            this.rtbTableCreated = new System.Windows.Forms.RichTextBox();
            this.lblTableCreated = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListFileData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListDataFileJson)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Latest Shcema";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(125, 53);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(356, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "https://portal.inshosteddata.com/api/account/self/file/latest";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(125, 97);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.PasswordChar = '*';
            this.txtApiKey.Size = new System.Drawing.Size(356, 20);
            this.txtApiKey.TabIndex = 3;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(11, 100);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(43, 13);
            this.lblApiKey.TabIndex = 2;
            this.lblApiKey.Text = "Api Key";
            // 
            // txtApiSecret
            // 
            this.txtApiSecret.Location = new System.Drawing.Point(125, 141);
            this.txtApiSecret.Name = "txtApiSecret";
            this.txtApiSecret.PasswordChar = '*';
            this.txtApiSecret.Size = new System.Drawing.Size(356, 20);
            this.txtApiSecret.TabIndex = 5;
            // 
            // lblApiSecret
            // 
            this.lblApiSecret.AutoSize = true;
            this.lblApiSecret.Location = new System.Drawing.Point(11, 144);
            this.lblApiSecret.Name = "lblApiSecret";
            this.lblApiSecret.Size = new System.Drawing.Size(56, 13);
            this.lblApiSecret.TabIndex = 4;
            this.lblApiSecret.Text = "Api Secret";
            // 
            // btnGetApiData
            // 
            this.btnGetApiData.Location = new System.Drawing.Point(373, 177);
            this.btnGetApiData.Name = "btnGetApiData";
            this.btnGetApiData.Size = new System.Drawing.Size(108, 23);
            this.btnGetApiData.TabIndex = 6;
            this.btnGetApiData.Text = "Get Api Data ";
            this.btnGetApiData.UseVisualStyleBackColor = true;
            this.btnGetApiData.Click += new System.EventHandler(this.btnGetApiData_Click);
            // 
            // lblDataFromApi
            // 
            this.lblDataFromApi.AutoSize = true;
            this.lblDataFromApi.Location = new System.Drawing.Point(11, 228);
            this.lblDataFromApi.Name = "lblDataFromApi";
            this.lblDataFromApi.Size = new System.Drawing.Size(74, 13);
            this.lblDataFromApi.TabIndex = 7;
            this.lblDataFromApi.Text = "Data From Api";
            // 
            // rtbDataFromApi
            // 
            this.rtbDataFromApi.Location = new System.Drawing.Point(125, 225);
            this.rtbDataFromApi.Name = "rtbDataFromApi";
            this.rtbDataFromApi.Size = new System.Drawing.Size(356, 81);
            this.rtbDataFromApi.TabIndex = 8;
            this.rtbDataFromApi.Text = "";
            // 
            // btnGetListFileData
            // 
            this.btnGetListFileData.Location = new System.Drawing.Point(373, 319);
            this.btnGetListFileData.Name = "btnGetListFileData";
            this.btnGetListFileData.Size = new System.Drawing.Size(108, 23);
            this.btnGetListFileData.TabIndex = 9;
            this.btnGetListFileData.Text = "Get List File Data ";
            this.btnGetListFileData.UseVisualStyleBackColor = true;
            this.btnGetListFileData.Click += new System.EventHandler(this.btnGetListFileData_Click);
            // 
            // dgwListFileData
            // 
            this.dgwListFileData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListFileData.Location = new System.Drawing.Point(125, 354);
            this.dgwListFileData.Name = "dgwListFileData";
            this.dgwListFileData.Size = new System.Drawing.Size(356, 94);
            this.dgwListFileData.TabIndex = 10;
            // 
            // lblListFileData
            // 
            this.lblListFileData.AutoSize = true;
            this.lblListFileData.Location = new System.Drawing.Point(11, 397);
            this.lblListFileData.Name = "lblListFileData";
            this.lblListFileData.Size = new System.Drawing.Size(68, 13);
            this.lblListFileData.TabIndex = 11;
            this.lblListFileData.Text = "List File Data";
            // 
            // btnDownloadFileFromLink
            // 
            this.btnDownloadFileFromLink.Location = new System.Drawing.Point(879, 46);
            this.btnDownloadFileFromLink.Name = "btnDownloadFileFromLink";
            this.btnDownloadFileFromLink.Size = new System.Drawing.Size(187, 23);
            this.btnDownloadFileFromLink.TabIndex = 12;
            this.btnDownloadFileFromLink.Text = "Donwload File From Link To Folder";
            this.btnDownloadFileFromLink.UseVisualStyleBackColor = true;
            this.btnDownloadFileFromLink.Click += new System.EventHandler(this.btnDownloadFileFromLink_Click);
            // 
            // txtFileFolder
            // 
            this.txtFileFolder.Location = new System.Drawing.Point(710, 75);
            this.txtFileFolder.Name = "txtFileFolder";
            this.txtFileFolder.Size = new System.Drawing.Size(356, 20);
            this.txtFileFolder.TabIndex = 14;
            this.txtFileFolder.Text = "FileData";
            // 
            // lblFileFolder
            // 
            this.lblFileFolder.AutoSize = true;
            this.lblFileFolder.Location = new System.Drawing.Point(596, 78);
            this.lblFileFolder.Name = "lblFileFolder";
            this.lblFileFolder.Size = new System.Drawing.Size(78, 13);
            this.lblFileFolder.TabIndex = 13;
            this.lblFileFolder.Text = "File folder root\\";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(710, 115);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(162, 23);
            this.btnOpenFolder.TabIndex = 15;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // btnDecompressFile
            // 
            this.btnDecompressFile.Location = new System.Drawing.Point(879, 115);
            this.btnDecompressFile.Name = "btnDecompressFile";
            this.btnDecompressFile.Size = new System.Drawing.Size(187, 23);
            this.btnDecompressFile.TabIndex = 16;
            this.btnDecompressFile.Text = "Decompress File";
            this.btnDecompressFile.UseVisualStyleBackColor = true;
            this.btnDecompressFile.Click += new System.EventHandler(this.btnDecompressFile_Click);
            // 
            // txtTableSchemaUrl
            // 
            this.txtTableSchemaUrl.Location = new System.Drawing.Point(710, 153);
            this.txtTableSchemaUrl.Name = "txtTableSchemaUrl";
            this.txtTableSchemaUrl.Size = new System.Drawing.Size(356, 20);
            this.txtTableSchemaUrl.TabIndex = 18;
            this.txtTableSchemaUrl.Text = "https://portal.inshosteddata.com/api/schema/latest";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(596, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Table Schema Url";
            // 
            // btnGetTableSchema
            // 
            this.btnGetTableSchema.Location = new System.Drawing.Point(879, 189);
            this.btnGetTableSchema.Name = "btnGetTableSchema";
            this.btnGetTableSchema.Size = new System.Drawing.Size(187, 23);
            this.btnGetTableSchema.TabIndex = 19;
            this.btnGetTableSchema.Text = "Get Table Schema";
            this.btnGetTableSchema.UseVisualStyleBackColor = true;
            this.btnGetTableSchema.Click += new System.EventHandler(this.btnGetTableSchema_Click);
            // 
            // rtbTableSchema
            // 
            this.rtbTableSchema.Location = new System.Drawing.Point(710, 225);
            this.rtbTableSchema.Name = "rtbTableSchema";
            this.rtbTableSchema.Size = new System.Drawing.Size(356, 81);
            this.rtbTableSchema.TabIndex = 21;
            this.rtbTableSchema.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(596, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Table Schema";
            // 
            // btnReadFile
            // 
            this.btnReadFile.Location = new System.Drawing.Point(879, 319);
            this.btnReadFile.Name = "btnReadFile";
            this.btnReadFile.Size = new System.Drawing.Size(187, 23);
            this.btnReadFile.TabIndex = 22;
            this.btnReadFile.Text = "Read File";
            this.btnReadFile.UseVisualStyleBackColor = true;
            this.btnReadFile.Click += new System.EventHandler(this.btnReadFile_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(596, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "List File Data";
            // 
            // dgwListDataFileJson
            // 
            this.dgwListDataFileJson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwListDataFileJson.Location = new System.Drawing.Point(710, 354);
            this.dgwListDataFileJson.Name = "dgwListDataFileJson";
            this.dgwListDataFileJson.Size = new System.Drawing.Size(356, 94);
            this.dgwListDataFileJson.TabIndex = 23;
            // 
            // rtbFileLinkFromDataGridView
            // 
            this.rtbFileLinkFromDataGridView.Location = new System.Drawing.Point(125, 467);
            this.rtbFileLinkFromDataGridView.Name = "rtbFileLinkFromDataGridView";
            this.rtbFileLinkFromDataGridView.Size = new System.Drawing.Size(356, 76);
            this.rtbFileLinkFromDataGridView.TabIndex = 26;
            this.rtbFileLinkFromDataGridView.Text = "";
            // 
            // lblFileLinkFromDataGridView
            // 
            this.lblFileLinkFromDataGridView.AutoSize = true;
            this.lblFileLinkFromDataGridView.Location = new System.Drawing.Point(11, 480);
            this.lblFileLinkFromDataGridView.Name = "lblFileLinkFromDataGridView";
            this.lblFileLinkFromDataGridView.Size = new System.Drawing.Size(46, 13);
            this.lblFileLinkFromDataGridView.TabIndex = 25;
            this.lblFileLinkFromDataGridView.Text = "File Link";
            // 
            // btnCreateTableInDatabase
            // 
            this.btnCreateTableInDatabase.Location = new System.Drawing.Point(879, 454);
            this.btnCreateTableInDatabase.Name = "btnCreateTableInDatabase";
            this.btnCreateTableInDatabase.Size = new System.Drawing.Size(187, 23);
            this.btnCreateTableInDatabase.TabIndex = 27;
            this.btnCreateTableInDatabase.Text = "Create Table In Database";
            this.btnCreateTableInDatabase.UseVisualStyleBackColor = true;
            this.btnCreateTableInDatabase.Click += new System.EventHandler(this.btnCreateTableInDatabase_Click);
            // 
            // txtSqlConnectionString
            // 
            this.txtSqlConnectionString.Location = new System.Drawing.Point(125, 12);
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.PasswordChar = '*';
            this.txtSqlConnectionString.Size = new System.Drawing.Size(941, 20);
            this.txtSqlConnectionString.TabIndex = 30;
            this.txtSqlConnectionString.Text = "Server=.\\sqlexpress;Database=CanvasDemoDb;Trusted_Connection=True;";
            // 
            // lblSqlConnectionString
            // 
            this.lblSqlConnectionString.AutoSize = true;
            this.lblSqlConnectionString.Location = new System.Drawing.Point(11, 15);
            this.lblSqlConnectionString.Name = "lblSqlConnectionString";
            this.lblSqlConnectionString.Size = new System.Drawing.Size(101, 13);
            this.lblSqlConnectionString.TabIndex = 29;
            this.lblSqlConnectionString.Text = "SQL Connect String";
            // 
            // rtbTableCreated
            // 
            this.rtbTableCreated.Location = new System.Drawing.Point(710, 524);
            this.rtbTableCreated.Name = "rtbTableCreated";
            this.rtbTableCreated.Size = new System.Drawing.Size(356, 76);
            this.rtbTableCreated.TabIndex = 32;
            this.rtbTableCreated.Text = "";
            // 
            // lblTableCreated
            // 
            this.lblTableCreated.AutoSize = true;
            this.lblTableCreated.Location = new System.Drawing.Point(596, 537);
            this.lblTableCreated.Name = "lblTableCreated";
            this.lblTableCreated.Size = new System.Drawing.Size(74, 13);
            this.lblTableCreated.TabIndex = 31;
            this.lblTableCreated.Text = "Table Created";
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPleaseWait.Location = new System.Drawing.Point(706, 491);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(137, 20);
            this.lblPleaseWait.TabIndex = 33;
            this.lblPleaseWait.Text = "Please wait............";
            this.lblPleaseWait.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 663);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.rtbTableCreated);
            this.Controls.Add(this.lblTableCreated);
            this.Controls.Add(this.txtSqlConnectionString);
            this.Controls.Add(this.lblSqlConnectionString);
            this.Controls.Add(this.btnCreateTableInDatabase);
            this.Controls.Add(this.rtbFileLinkFromDataGridView);
            this.Controls.Add(this.lblFileLinkFromDataGridView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgwListDataFileJson);
            this.Controls.Add(this.btnReadFile);
            this.Controls.Add(this.rtbTableSchema);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnGetTableSchema);
            this.Controls.Add(this.txtTableSchemaUrl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDecompressFile);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.txtFileFolder);
            this.Controls.Add(this.lblFileFolder);
            this.Controls.Add(this.btnDownloadFileFromLink);
            this.Controls.Add(this.lblListFileData);
            this.Controls.Add(this.dgwListFileData);
            this.Controls.Add(this.btnGetListFileData);
            this.Controls.Add(this.rtbDataFromApi);
            this.Controls.Add(this.lblDataFromApi);
            this.Controls.Add(this.btnGetApiData);
            this.Controls.Add(this.txtApiSecret);
            this.Controls.Add(this.lblApiSecret);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Canvas Data To Sql Server Demo";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgwListFileData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwListDataFileJson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiSecret;
        private System.Windows.Forms.Label lblApiSecret;
        private System.Windows.Forms.Button btnGetApiData;
        private System.Windows.Forms.Label lblDataFromApi;
        private System.Windows.Forms.RichTextBox rtbDataFromApi;
        private System.Windows.Forms.Button btnGetListFileData;
        private System.Windows.Forms.DataGridView dgwListFileData;
        private System.Windows.Forms.Label lblListFileData;
        private System.Windows.Forms.Button btnDownloadFileFromLink;
        private System.Windows.Forms.TextBox txtFileFolder;
        private System.Windows.Forms.Label lblFileFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnDecompressFile;
        private System.Windows.Forms.TextBox txtTableSchemaUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGetTableSchema;
        private System.Windows.Forms.RichTextBox rtbTableSchema;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReadFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgwListDataFileJson;
        private System.Windows.Forms.RichTextBox rtbFileLinkFromDataGridView;
        private System.Windows.Forms.Label lblFileLinkFromDataGridView;
        private System.Windows.Forms.Button btnCreateTableInDatabase;
        private System.Windows.Forms.TextBox txtSqlConnectionString;
        private System.Windows.Forms.Label lblSqlConnectionString;
        private System.Windows.Forms.RichTextBox rtbTableCreated;
        private System.Windows.Forms.Label lblTableCreated;
        private System.Windows.Forms.Label lblPleaseWait;
    }
}

