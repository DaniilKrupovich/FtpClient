namespace FtpClient
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
            _listFilesFromFtpServer = new DataGridView();
            _lblHostAddress = new Label();
            _tbHostAddress = new TextBox();
            _lblUserName = new Label();
            _tbUserName = new TextBox();
            _lblPassword = new Label();
            _tbPassword = new TextBox();
            _btnConnect = new Button();
            _chBoxAnonim = new CheckBox();
            _btnGetFiles = new Button();
            _btnDownloadFile = new Button();
            _btnDisconnect = new Button();
            ((System.ComponentModel.ISupportInitialize)_listFilesFromFtpServer).BeginInit();
            SuspendLayout();
            // 
            // _listFilesFromFtpServer
            // 
            _listFilesFromFtpServer.AllowUserToAddRows = false;
            _listFilesFromFtpServer.AllowUserToDeleteRows = false;
            _listFilesFromFtpServer.AllowUserToResizeColumns = false;
            _listFilesFromFtpServer.AllowUserToResizeRows = false;
            _listFilesFromFtpServer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _listFilesFromFtpServer.Location = new Point(0, 252);
            _listFilesFromFtpServer.Name = "_listFilesFromFtpServer";
            _listFilesFromFtpServer.ReadOnly = true;
            _listFilesFromFtpServer.RowHeadersVisible = false;
            _listFilesFromFtpServer.RowHeadersWidth = 51;
            _listFilesFromFtpServer.Size = new Size(627, 281);
            _listFilesFromFtpServer.TabIndex = 0;
            // 
            // _lblHostAddress
            // 
            _lblHostAddress.AutoSize = true;
            _lblHostAddress.Font = new Font("Segoe UI", 10F);
            _lblHostAddress.Location = new Point(12, 9);
            _lblHostAddress.Name = "_lblHostAddress";
            _lblHostAddress.Size = new Size(124, 23);
            _lblHostAddress.TabIndex = 1;
            _lblHostAddress.Text = "Server address:";
            // 
            // _tbHostAddress
            // 
            _tbHostAddress.Location = new Point(142, 8);
            _tbHostAddress.Name = "_tbHostAddress";
            _tbHostAddress.Size = new Size(295, 27);
            _tbHostAddress.TabIndex = 2;
            // 
            // _lblUserName
            // 
            _lblUserName.AutoSize = true;
            _lblUserName.Font = new Font("Segoe UI", 10F);
            _lblUserName.Location = new Point(37, 58);
            _lblUserName.Name = "_lblUserName";
            _lblUserName.Size = new Size(99, 23);
            _lblUserName.TabIndex = 3;
            _lblUserName.Text = "User Name:";
            // 
            // _tbUserName
            // 
            _tbUserName.Location = new Point(142, 54);
            _tbUserName.Name = "_tbUserName";
            _tbUserName.Size = new Size(295, 27);
            _tbUserName.TabIndex = 4;
            // 
            // _lblPassword
            // 
            _lblPassword.AutoSize = true;
            _lblPassword.Font = new Font("Segoe UI", 10F);
            _lblPassword.Location = new Point(52, 108);
            _lblPassword.Name = "_lblPassword";
            _lblPassword.Size = new Size(84, 23);
            _lblPassword.TabIndex = 5;
            _lblPassword.Text = "Password:";
            // 
            // _tbPassword
            // 
            _tbPassword.Location = new Point(142, 104);
            _tbPassword.Name = "_tbPassword";
            _tbPassword.PasswordChar = '*';
            _tbPassword.Size = new Size(295, 27);
            _tbPassword.TabIndex = 6;
            // 
            // _btnConnect
            // 
            _btnConnect.Location = new Point(314, 158);
            _btnConnect.Name = "_btnConnect";
            _btnConnect.Size = new Size(123, 29);
            _btnConnect.TabIndex = 7;
            _btnConnect.Text = "Connect";
            _btnConnect.UseVisualStyleBackColor = true;
            _btnConnect.Click += _btnConnect_Click;
            // 
            // _chBoxAnonim
            // 
            _chBoxAnonim.AutoSize = true;
            _chBoxAnonim.Location = new Point(142, 161);
            _chBoxAnonim.Name = "_chBoxAnonim";
            _chBoxAnonim.Size = new Size(109, 24);
            _chBoxAnonim.TabIndex = 8;
            _chBoxAnonim.Text = "Anonymous";
            _chBoxAnonim.UseVisualStyleBackColor = true;
            _chBoxAnonim.CheckedChanged += _chBoxAnonim_CheckedChanged;
            // 
            // _btnGetFiles
            // 
            _btnGetFiles.Location = new Point(0, 217);
            _btnGetFiles.Name = "_btnGetFiles";
            _btnGetFiles.Size = new Size(123, 29);
            _btnGetFiles.TabIndex = 9;
            _btnGetFiles.Text = "Get Files";
            _btnGetFiles.UseVisualStyleBackColor = true;
            _btnGetFiles.Click += _btnGetFiles_Click;
            // 
            // _btnDownloadFile
            // 
            _btnDownloadFile.Location = new Point(142, 217);
            _btnDownloadFile.Name = "_btnDownloadFile";
            _btnDownloadFile.Size = new Size(123, 29);
            _btnDownloadFile.TabIndex = 10;
            _btnDownloadFile.Text = "Download File";
            _btnDownloadFile.UseVisualStyleBackColor = true;
            _btnDownloadFile.Click += _btnDownloadFile_Click;
            // 
            // _btnDisconnect
            // 
            _btnDisconnect.Location = new Point(283, 217);
            _btnDisconnect.Name = "_btnDisconnect";
            _btnDisconnect.Size = new Size(123, 29);
            _btnDisconnect.TabIndex = 11;
            _btnDisconnect.Text = "Disconnect";
            _btnDisconnect.UseVisualStyleBackColor = true;
            _btnDisconnect.Click += _btnDisconnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 575);
            Controls.Add(_btnDisconnect);
            Controls.Add(_btnDownloadFile);
            Controls.Add(_btnGetFiles);
            Controls.Add(_chBoxAnonim);
            Controls.Add(_btnConnect);
            Controls.Add(_tbPassword);
            Controls.Add(_lblPassword);
            Controls.Add(_tbUserName);
            Controls.Add(_lblUserName);
            Controls.Add(_tbHostAddress);
            Controls.Add(_lblHostAddress);
            Controls.Add(_listFilesFromFtpServer);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)_listFilesFromFtpServer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView _listFilesFromFtpServer;
        private Label _lblHostAddress;
        private TextBox _tbHostAddress;
        private Label _lblUserName;
        private TextBox _tbUserName;
        private Label _lblPassword;
        private TextBox _tbPassword;
        private Button _btnConnect;
        private CheckBox _chBoxAnonim;
        private Button _btnGetFiles;
        private Button _btnDownloadFile;
        private Button _btnDisconnect;
    }
}
