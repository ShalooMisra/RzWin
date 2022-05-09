using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Text;
using System.Collections;
using System.IO;
using System.Xml;

namespace RzWinTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string file = Tools.Strings.ParseDelimit(Environment.CommandLine, "\" \"", 2).Replace("\"", "").Trim();
            string ext = Tools.Files.GetFileExtention(file);
            if (Tools.Strings.StrCmp(ext, "rzdl"))
            {
                MessageBox.Show("About to process RZDL file.");
                RZDL.ProcessRzDownload(Environment.CommandLine, file);
                return;
            }
            //"C:\Eternal\Code\Rz4\RzWinTools\bin\Debug\RzWinTools.exe" "rzlinkprotocol://Label_d11c23060f1d41109c1108570d361e42.txt/"
            String labelFile = Tools.Strings.ParseDelimit(Tools.Strings.ParseDelimit(Environment.CommandLine, "rzlinkprotocol://", 2), "/", 1).Trim();
            String labelData = "";  // Tools.Strings.DownloadInternetString("http://remote.phoenix-ts.com/LabelsToPrint/" + labelFile);
            String url = "http://remote.phoenix-ts.com/LabelsToPrint/" + labelFile;
            try
            {
                WebClient xClient = new WebClient();
                Byte[] b = xClient.DownloadData(url);
                labelData = Encoding.ASCII.GetString(b);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\r\n\r\n" + Environment.CommandLine + "\r\n\r\n" + url);
                return;
            }
            if( !Tools.Strings.StrExt(labelData) )
            {
                MessageBox.Show("No label info was found at " + labelFile + "\r\n\r\n" + Environment.CommandLine + "\r\n\r\n" + url);
                return;
            }
            if (Tools.Misc.IsDevelopmentMachine())
                Tools.FileSystem.PopText(labelData);
            else
                Tools.PrintDirect.PrintString(labelData, "ZebraHuge");            
        }
    }
}
