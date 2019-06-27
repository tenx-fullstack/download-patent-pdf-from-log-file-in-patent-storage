using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace downloadProgress
{
    public delegate void progressProcessor(int i);
    public partial class Form1 : Form
    {
        string sSelectedFolder;
        int j = 0, i = 0;
        public progressProcessor progress;
        string savedDir;
        List<string> PdfListUrl = new List<string>();

        bool html_Flag = true ;
        bool pdf_Flag = false;

        bool firstPageDownloadFlag = true;
        WebClient webPdfDownloader = new WebClient();
        WebClient myweb = new WebClient();
        AutoResetEvent htmlWaiter = new AutoResetEvent(true);
        AutoResetEvent pdfWaiter = new AutoResetEvent(false);

        public Form1()
        {
            InitializeComponent();
            progress += new progressProcessor(handleProgess);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void downBt_Click(object sender, EventArgs e)
        {
            //get pdf Url list from log file
            string[] arrayData = this.arrayFromImportLogfile(LogPathTb.Text);
           
            foreach (string data in arrayData)
            {
                PdfListUrl.Add(data);
            }
            
            //set path saved direct
            savedDir = txt_saveFile.Text;


            // start double thred
            
            Uri uri = new Uri(PdfListUrl[0]);
            if (PdfListUrl.Count > 0)
            {

                myweb.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DownloadDataCallback);
                myweb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                myweb.DownloadDataAsync(uri);
            }

        }

        private void DownloadDataCallback(Object sender, DownloadDataCompletedEventArgs e)
        {

            PdfListUrl.RemoveAt(0);
            if (PdfListUrl.Count > 0)
            {
                Uri uri = new Uri(PdfListUrl[0]);
                myweb.DownloadDataAsync(uri);
                try
                {
                    // html text download and save to <downHtml.txt> in local direct folder 
                    if (!e.Cancelled && e.Error == null)
                    {
                        byte[] data = (byte[])e.Result;
                        string default_str = @"";
                        string saveFileName = this.getFileNameFromUrl(PdfListUrl[0]);
                        string Para = default_str + savedDir + "/" + saveFileName;
                        Thread file_thread = new Thread(() => write_file_html_thread(Para, data));
                        file_thread.Start();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + e.Error.Message);
                    }
                }
                finally
                {
                
                }
            }
        }

        public void write_file_html_thread(string fileName, byte[] data)
        {
            string filedir = fileName;
            System.IO.File.WriteAllBytes(filedir, data);
        }


        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            // Displays the operation identifier, and the transfer progress.
            Console.WriteLine("{0}    downloaded {1} of {2} bytes. {3} % complete...",
                e.UserState,
                e.BytesReceived,
                e.TotalBytesToReceive,
                e.ProgressPercentage);
            
            progress(e.ProgressPercentage);
            //MessageBox.Show("mee");
        }

        //html file download progress option
        public void handleProgess(int p)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            progressBar1.Value = p;
            percentLabel.Text = p.ToString() + "%";
            downloadingFile.Text = PdfListUrl[0];
        }

        private void cancelBt_Click(object sender, EventArgs e)
        {
            myweb.CancelAsync();
            progressBar1.Value = 0;
            percentLabel.Text = "0%";
        }

        private void savePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.Description = "Custom Description"; //not mandatory

            if (fbd.ShowDialog() == DialogResult.OK)
                sSelectedFolder = fbd.SelectedPath;
            else
                sSelectedFolder = string.Empty;
            txt_saveFile.Text = sSelectedFolder;
        }

        public string getFileNameFromUrl(string strUrl)
        {
            int indexCharacter = strUrl.LastIndexOf(@"/")+1;
            int startlength = strUrl.Length - indexCharacter;
            
            string getFileNameFromUrl = strUrl.Substring(indexCharacter, startlength);
            return getFileNameFromUrl;
        }


        private void ImportLogBt_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
            }
            LogPathTb.Text = filePath;
        }

        public string[] arrayFromImportLogfile(string fileName)
        {
            string[] pdfUrlList = File.ReadAllLines(fileName);
            //List<string> pdfUrlList = new List<string>();
            return pdfUrlList;
        }
    }
}
