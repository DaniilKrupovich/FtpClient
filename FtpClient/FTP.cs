using System.Data;
using static FtpClient.FTPClient;

namespace FtpClient
{
    public partial class FTP : Form
    {
        private DataTable _listFiles;
        private FTPClient _client;
        private bool _isConnect = false;
        public FTP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listFiles = new DataTable();
            _listFiles.Columns.Add("File Name", typeof(string));
            _listFiles.Columns.Add("Create Time", typeof(string));
            _listFilesFromFtpServer.DataSource = _listFiles;

            _listFilesFromFtpServer.Columns["File Name"].Width = 379;
            _listFilesFromFtpServer.Columns["Create Time"].Width = 280;

            EnableControl(_isConnect);
        }

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            if (_tbHostAddress.Text != "")
            {
                try
                {
                    if (_chBoxAnonim.Checked == true)
                    {
                        _client = new FTPClient(_tbHostAddress.Text, "Anonymous");
                        _isConnect = true;
                    }
                    else
                    {
                        _client = new FTPClient(_tbHostAddress.Text, _tbUserName.Text, _tbPassword.Text);
                        _isConnect = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к серверу!\nВозможно немерно введены параметры", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                EnableControl(_isConnect);
            }
            else
            {
                MessageBox.Show("Адресс не может быть пустым", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableControl(bool isConnect)
        {
            _btnDownloadFile.Enabled = isConnect;
            _btnConnect.Enabled = !isConnect;
            _btnGetFiles.Enabled = isConnect;
            _btnClear.Enabled = isConnect;
        }

        private void _chBoxAnonim_CheckedChanged(object sender, EventArgs e)
        {
            if (_chBoxAnonim.Checked == true)
            {
                _tbUserName.Clear();
                _tbUserName.Enabled = false;

                _tbPassword.Clear();
                _tbPassword.Enabled = false;
            }
            else
            {
                _tbUserName.Enabled = true;
                _tbPassword.Enabled = true;
            }
        }

        private void _btnGetFiles_Click(object sender, EventArgs e)
        {
            FileStruct[] FileList = _client.ListDirectory("");
            foreach (FileStruct s in FileList)
            {
                _listFiles.Rows.Add(s.Name, s.CreateTime);
            }
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void _btnDownloadFile_Click(object sender, EventArgs e)
        {
            int index = _listFilesFromFtpServer.CurrentCell.RowIndex;
            if (index > -1)
            {
                _client.DownLoadFile(Convert.ToString(_listFiles.Rows[index][0]));
            }
            else
            {
                MessageBox.Show("Сперва выберите файл", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _btnClear_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            _client.Host = "";
            _client.UserName = "";
            _client.Password = "";
            _isConnect = false;
            _chBoxAnonim.Checked = false;
            _listFiles.Clear();
            EnableControl(_isConnect);
        }

        private void _listFilesFromFtpServer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = _listFilesFromFtpServer.CurrentCell.RowIndex;
                if (index > -1)
                {
                    using var stream = _client.GetImageStream(Convert.ToString(_listFiles.Rows[index][0]));
                    if (stream != null)
                    {
                        var image = Image.FromStream(stream);
                        _pictureBox.Image = image;
                    }
                    else
                    {
                        MessageBox.Show("Возникла ошибка при загрузке файла", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (_isConnect)
            {
                Thread.Sleep(2000);
                foreach (var fileOnServer in _client.ListDirectory(""))
                {
                    bool fileExists = false;

                    foreach (DataRow row in _listFiles.Rows)
                    {
                        string fileName = row["File Name"].ToString();
                        if (fileName == fileOnServer.Name)
                        {
                            fileExists = true;
                            break;
                        }
                    }
                    if (!fileExists)
                    {
                        _listFiles.Rows.Add(fileOnServer.Name, fileOnServer.CreateTime);
                        backgroundWorker.ReportProgress(0);
                        using var stream = _client.GetImageStream(fileOnServer.Name);
                        if (stream != null)
                        {
                            var image = Image.FromStream(stream);
                            _pictureBox.Image = image;
                        }
                        else
                        {
                            MessageBox.Show("Возникла ошибка при загрузке файла", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("BackWork end", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            _listFilesFromFtpServer.Update();
        }
    }
}
