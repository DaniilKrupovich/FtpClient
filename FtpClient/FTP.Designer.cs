namespace FtpClient
{
    partial class FTP
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
            _btnClear = new Button();
            _pictureBox = new PictureBox();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)_listFilesFromFtpServer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_pictureBox).BeginInit();
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
            _listFilesFromFtpServer.Size = new Size(630, 323);
            _listFilesFromFtpServer.TabIndex = 0;
            _listFilesFromFtpServer.CellClick += _listFilesFromFtpServer_CellClick;
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
            _btnConnect.Text = "Test Connection";
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
            // _btnClear
            // 
            _btnClear.Location = new Point(142, 217);
            _btnClear.Name = "_btnClear";
            _btnClear.Size = new Size(123, 29);
            _btnClear.TabIndex = 11;
            _btnClear.Text = "Disconnect";
            _btnClear.UseVisualStyleBackColor = true;
            _btnClear.Click += _btnClear_Click;
            // 
            // _pictureBox
            // 
            _pictureBox.BackColor = SystemColors.ControlLightLight;
            _pictureBox.BorderStyle = BorderStyle.FixedSingle;
            _pictureBox.Location = new Point(636, 8);
            _pictureBox.Name = "_pictureBox";
            _pictureBox.Size = new Size(440, 560);
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _pictureBox.TabIndex = 12;
            _pictureBox.TabStop = false;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            // 
            // FTP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1081, 575);
            Controls.Add(_pictureBox);
            Controls.Add(_btnClear);
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
            MaximumSize = new Size(1099, 622);
            MinimumSize = new Size(1099, 622);
            Name = "FTP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FTP";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)_listFilesFromFtpServer).EndInit();
            ((System.ComponentModel.ISupportInitialize)_pictureBox).EndInit();
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
        private Button _btnClear;
        private PictureBox _pictureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}
