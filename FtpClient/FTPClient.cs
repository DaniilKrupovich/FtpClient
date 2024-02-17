using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient
{
    internal class FTPClient
    {
        private string _Host;
        private string _UserName;
        private string _Password;
        static FtpWebRequest _ftpRequest;
        static FtpWebResponse _ftpResponse;
        private bool _UseSSL = false;
        public FTPClient(string host, string userName, string password = null)
        {
            _Host = host;
            _UserName = userName;
            _Password = password;
        }
        public string Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
            }
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public bool UseSSL
        {
            get
            {
                return _UseSSL;
            }
            set
            {
                _UseSSL = value;
            }
        }

        public void DownLoadFile(string fileName)
        {
            _ftpRequest = (FtpWebRequest)WebRequest.Create($"ftp://{_Host}/{fileName}");
            _ftpRequest.Credentials = new NetworkCredential(_UserName, _Password );

            _ftpRequest.UseBinary = true;
            _ftpRequest.UsePassive = true;
            _ftpRequest.KeepAlive = true;
            _ftpRequest.EnableSsl = _UseSSL;

            _ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            _ftpResponse = (FtpWebResponse)_ftpRequest.GetResponse();
            var ftpStream = _ftpResponse.GetResponseStream();
            FileStream downloadFile = new FileStream(@"C:\\Users\\Barsu4ok\\Desktop\\newFile.txt", FileMode.Create, FileAccess.ReadWrite);

            byte[] buffer = new byte[1024];
            int size = 0;
            while ((size = ftpStream.Read(buffer, 0, 1024)) > 0)
            {
                downloadFile.Write(buffer, 0, size);

            }
            _ftpResponse.Close();
            downloadFile.Close();
            ftpStream.Close();
        }

    }
}
