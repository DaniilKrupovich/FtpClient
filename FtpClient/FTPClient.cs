using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            _ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);

            _ftpRequest.UseBinary = true;
            _ftpRequest.UsePassive = true;
            _ftpRequest.KeepAlive = true;
            _ftpRequest.EnableSsl = _UseSSL;

            _ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

            _ftpResponse = (FtpWebResponse)_ftpRequest.GetResponse();
            var ftpStream = _ftpResponse.GetResponseStream();
            FileStream downloadFile = new FileStream($"C:\\Users\\Barsu4ok\\Desktop\\{fileName}", FileMode.Create, FileAccess.ReadWrite);

            byte[] buffer = new byte[1024];
            int size = 0;
            while ((size = ftpStream.Read(buffer, 0, 1024)) > 0)
            {
                downloadFile.Write(buffer, 0, size);

            }
            downloadFile.Close();
            _ftpResponse.Close();
            ftpStream.Close();
        }
        public FileStruct[] ListDirectory(string path)
        {
            if (path == null || path == "")
            {
                path = "/";
            }
            //Создаем объект запроса
            _ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + _Host + path);
            //логин и пароль
            _ftpRequest.Credentials = new NetworkCredential(_UserName, _Password);
            //команда фтп LIST
            _ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            _ftpRequest.EnableSsl = _UseSSL;
            //Получаем входящий поток
            _ftpResponse = (FtpWebResponse)_ftpRequest.GetResponse();

            //переменная для хранения всей полученной информации
            string content = "";

            StreamReader sr = new StreamReader(_ftpResponse.GetResponseStream(), System.Text.Encoding.ASCII);
            content = sr.ReadToEnd();
            sr.Close();
            _ftpResponse.Close();

            DirectoryListParser parser = new DirectoryListParser(content);
            return parser.FullListing;
        }
        public struct FileStruct
        {
            public string Flags;
            public string Owner;
            public bool IsDirectory;
            public string CreateTime;
            public string Name;
        }

        public enum FileListStyle
        {
            UnixStyle,
            WindowsStyle,
            Unknown
        }
        public class DirectoryListParser
        {
            private List<FileStruct> _myListArray;
            public FileStruct[] FullListing
            {
                get
                {
                    return _myListArray.ToArray();
                }
            }
            public FileStruct[] FileList
            {
                get
                {
                    List<FileStruct> _fileList = new List<FileStruct>();
                    foreach (FileStruct thisstruct in _myListArray)
                    {
                        if (!thisstruct.IsDirectory)
                        {
                            _fileList.Add(thisstruct);
                        }
                    }
                    return _fileList.ToArray();
                }
            }
            public FileStruct[] DirectoryList
            {
                get
                {
                    List<FileStruct> _dirList = new List<FileStruct>();
                    foreach (FileStruct thisstruct in _myListArray)
                    {
                        if (thisstruct.IsDirectory)
                        {
                            _dirList.Add(thisstruct);
                        }
                    }
                    return _dirList.ToArray();
                }
            }
            public DirectoryListParser(string responseString)
            {
                _myListArray = GetList(responseString);
            }
            private List<FileStruct> GetList(string datastring)
            {
                List<FileStruct> myListArray = new List<FileStruct>();
                string[] dataRecords = datastring.Split('\n');
                //Получаем стиль записей на сервере
                FileListStyle _directoryListStyle = GuessFileListStyle(dataRecords);
                foreach (string s in dataRecords)
                {
                    if (_directoryListStyle != FileListStyle.Unknown && s != "")
                    {
                        FileStruct f = new FileStruct();
                        f.Name = "..";
                        switch (_directoryListStyle)
                        {
                            case FileListStyle.WindowsStyle:
                                f = ParseFileStructFromWindowsStyleRecord(s);
                                break;
                        }
                        if (f.Name != "" && f.Name != "." && f.Name != "..")
                        {
                            myListArray.Add(f);
                        }
                    }
                }
                return myListArray;
            }
            private FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
            {
                //Предположим стиль записи 02-03-04  07:46PM       <DIR>     Append
                FileStruct f = new FileStruct();
                string processstr = Record.Trim();
                //Получаем дату
                string dateStr = processstr.Substring(0, 8);
                processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
                //Получаем время
                string timeStr = processstr.Substring(0, 7);
                processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
                f.CreateTime = dateStr + " " + timeStr;
                //Это папка или нет
                if (processstr.Substring(0, 5) == "<DIR>")
                {
                    f.IsDirectory = true;
                    processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
                }
                else
                {
                    string[] strs = processstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    processstr = strs[1];
                    f.IsDirectory = false;
                }
                //Остальное содержмое строки представляет имя каталога/файла
                f.Name = processstr;
                return f;
            }
            public FileListStyle GuessFileListStyle(string[] recordList)
            {
                foreach (string s in recordList)
                {
                    //Если соблюдено условие, то используется стиль Unix
                    if (s.Length > 10
                        && Regex.IsMatch(s.Substring(0, 10), "(-|d)((-|r)(-|w)(-|x)){3}"))
                    {
                        return FileListStyle.UnixStyle;
                    }
                    //Иначе стиль Windows
                    else if (s.Length > 8
                        && Regex.IsMatch(s.Substring(0, 8), "[0-9]{2}-[0-9]{2}-[0-9]{2}"))
                    {
                        return FileListStyle.WindowsStyle;
                    }
                }
                return FileListStyle.Unknown;
            }
            private string getCreateTimeString(string record)
            {
                //Получаем время
                string month = "(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)";
                string space = @"(\040)+";
                string day = "([0-9]|[1-3][0-9])";
                string year = "[1-2][0-9]{3}";
                string time = "[0-9]{1,2}:[0-9]{2}";
                Regex dateTimeRegex = new Regex(month + space + day + space + "(" + year + "|" + time + ")", RegexOptions.IgnoreCase);
                Match match = dateTimeRegex.Match(record);
                return match.Value;
            }

            private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
            {
                int pos1 = s.IndexOf(c, startIndex);
                string retString = s.Substring(0, pos1);
                s = (s.Substring(pos1)).Trim();
                return retString;
            }
        }
    }
}

