using System.Data;
using System.Diagnostics;
using static FtpClient.FTPClient;
using static System.Net.WebRequestMethods;

namespace FtpClient
{
    public partial class Form1 : Form
    {
        private DataTable _listFiles;
        private FTPClient _client;
        private bool _isConnect = false;
        public Form1()
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
            _btnDisconnect.Enabled = isConnect;
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

        private void _btnDisconnect_Click(object sender, EventArgs e)
        {
            _client.Host = "";
            _client.UserName = "";
            _client.Password = "";
            _isConnect = false;
            EnableControl(_isConnect);
        }
    }
}
