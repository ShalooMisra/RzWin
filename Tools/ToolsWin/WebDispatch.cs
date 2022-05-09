using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ToolsWin
{
    public partial class WebDispatch : UserControl
    {
        WebTarget Target;

        public WebDispatch()
        {
            InitializeComponent();
        }

        public void Init(WebTarget target)
        {
            Target = target;
            lblTarget.Text = Target.UpdateUrl + "\r\n" + Target.Path;
            cmdUpdate.Text = "Update " + Target.Name;
            lblLocation.Text = "";
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (!ToolsWin.Dialogs.YesNo.Ask("Did you just publish the site to " + Target.Path + "?"))
                return;

            cmdUpdate.Enabled = false;
            wb.ReloadWB();
            lblLocation.Text = "";
            wbResult.Clear();
            wb.Add("Updating...");
            pb.Value = 0;
            bw.RunWorkerAsync();
        }

        String response;
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            StatusHandle("Zipping...");
            Target.Zip();
            pb.Value = 0;

            String shortFileName = Path.GetFileName(Target.LocalFile);

            StatusHandle("Uploading...");
            StringBuilder sb = new StringBuilder();

            //using (WebClient client = new WebClient())
            //{
            //    response = System.Text.Encoding.ASCII.GetString(client.UploadFile(Target.Url + "/Update.aspx", Target.LocalFile));
            //} 

            response = HttpUploadFile(Target.UpdateUrl + "/Update.aspx", Target.LocalFile);
            //response = HttpUploadFile("http://localhost:52337/Update.aspx", @"c:\bilge\Sensible.jpg");

            ////List<String> folders = new List<string>();
            ////folders.Add("WebDispatch");

            ////Tools.FTP.SendFile("mike.recognin.com", "recognin", "Rec0gnin", Target.LocalFile, shortFileName, new Tools.FTPProgressHandler(ProgressHandle), new Tools.FTPStatusHandler(StatusHandle), folders);

            //File.Delete(Target.LocalFile);

            //StatusHandle("Notifying...");
            //WebRequest r = WebRequest.Create(Target.Url + "/Update.aspx?filename=" + shortFileName);
            //r.Timeout = (1000 * 60 * 60);  //hour long timeout
            //response = r.GetResponse();
        }

        public static String HttpUploadFile(string url, string file)
        {
            //log.Debug(string.Format("Uploading {0} to {1}", file, url));
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wr.Timeout = (1000 * 60 * 60);  //hour long timeout

            Stream rs = wr.GetRequestStream();

            //string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
            //foreach (string key in nvc.Keys)
            //{
            //    rs.Write(boundarybytes, 0, boundarybytes.Length);
            //    string formitem = string.Format(formdataTemplate, key, nvc[key]);
            //    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
            //    rs.Write(formitembytes, 0, formitembytes.Length);
            //}
            rs.Write(boundarybytes, 0, boundarybytes.Length);

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string header = string.Format(headerTemplate, "file", Path.GetFileName(file), "application/octet-stream");
            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            rs.Write(headerbytes, 0, headerbytes.Length);

            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[4096];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                rs.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            rs.Write(trailer, 0, trailer.Length);
            rs.Close();

            WebResponse wresp = null;
            try
            {
                wresp = wr.GetResponse();
                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);
                return string.Format("File uploaded, server response is: {0}", reader2.ReadToEnd());
                //log.Debug();
            }
            catch (Exception ex)
            {
                //log.Error("Error uploading file", ex);
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
                return ex.Message;
            }
            finally
            {
                wr = null;
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wb.Add("<br><hr><br>");
            //StreamReader r = new StreamReader(response.GetResponseStream());r.ReadToEnd()
            wb.Add(response);
            //r.Close();
            //r.Dispose();
            //r = null;
            cmdUpdate.Enabled = true;

            //wbResult.Navigate(Target.UpdateUrl);
            wbResult.Navigate(Target.LiveUrl);
        }

        void StatusHandle(String status)
        {
            Invoke(new Tools.FTPStatusHandler(ActualStatusHandle), new Object[] { status });
        }

        void ProgressHandle(int progress)
        {
            Invoke(new Tools.FTPProgressHandler(ActualProgressHandle), new Object[] { progress });
        }

        void ActualStatusHandle(String status)
        {
            wb.Add("<br>" + Tools.Html.ConvertTextToHTML(status));
        }

        void ActualProgressHandle(int progress)
        {
            pb.Value = progress;
        }

        private void WebDispatch_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            wb.Left = 0;
            wb.Height = this.ClientRectangle.Height - wb.Top;

            wbResult.Height = this.ClientRectangle.Height - wbResult.Top;
            wbResult.Width = this.ClientRectangle.Width - wbResult.Left;

            ph.Width = this.ClientRectangle.Width - ph.Left;
            pv.Height = this.ClientRectangle.Height - pv.Top;
        }

        private void wbResult_OnNavigate2(WebBrowserNavigatingEventArgs args)
        {
            lblLocation.Text = wbResult.GetURL();
        }
    }
}

namespace ToolsWin
{
    public class WebTarget
    {
        public String Name;
        public String Path;
        public String UpdateUrl;
        public String LiveUrl;
        //public String FtpSite = "mike.recognin.com";

        public String LocalFile = "";

        public WebTarget(String name, String path, String updateUrl, String liveUrl)
        {
            Name = name;
            Path = path;
            UpdateUrl = updateUrl;
            LiveUrl = liveUrl;
        }

        public void Zip()
        {
            LocalFile = @"c:\bilge\WebTarget" + Tools.Strings.GetNewID() + ".zip";
            Tools.Zip.ZipOneFolder(Path, LocalFile);
        }
    }
}
