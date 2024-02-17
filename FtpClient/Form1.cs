namespace FtpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FTPClient client = new FTPClient("192.168.0.104","Anonymous");
            client.DownLoadFile("Test.txt");
        }
    }
}
