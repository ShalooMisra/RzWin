
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Tools.Database;

namespace NewMethod
{
    public partial class nWebScan : UserControl
    {
        public String ScanName = "";
        public SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }
        public bool CancelFlag = false;
        public nWebScan()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }
        private void cmdGo_Click(object sender, EventArgs e)
        {
            Start();
        }
        public virtual void CompleteLoad()
        {

        }
        public virtual void Start()
        {
            CancelFlag = false;
            SetStatus("Starting...");
        }
        public virtual void Stop()
        {
            SetStatus("Stopped.");
        }
        public void Pause()
        {
            SetStatus("Pausing...");
        }
        public void SetStatus(String s)
        {
            if( InvokeRequired )
                this.Invoke(new SetStatusHandler(ActuallySetStatus), new object[]{ s });
            else
                ActuallySetStatus(s);
        }
        delegate void SetStatusHandler(String s);
        public void ActuallySetStatus(String s)
        {
            txtStatus.Text = s + "\r\n" + Tools.Strings.Left(txtStatus.Text, 4000);
            txtStatus.Refresh();
            //this.Refresh();
        }
        private void cmdParse_Click(object sender, EventArgs e)
        {
            Parse();
        }
        public virtual void Parse()
        {
            SetStatus("Parsing...");
        }
        public virtual void MakeScanTableExist()
        {
            if(!Tools.Strings.StrExt(ScanName))
                throw new Exception("Please set the scan name before continuing.");

            String rawTable = "raw_" + ScanName;

            if (NMWin.Data.TableExists(rawTable))
                NMWin.Data.DropTable(rawTable);
            NMWin.Data.Execute("create table " + rawTable + " (unique_id varchar(255), url varchar(8000), scandate datetime, all_text text, all_html text, is_parsed bit)");
        }
        public virtual void ClearScanTable()
        {
            NMWin.Data.Execute("truncate table raw_" + ScanName + " ");
        }
        public virtual void GrabPage()
        {
            String strURL = wbExtra.GetURL();
            String strText = wbExtra.GetPageText();
            String strHTML = wbExtra.GetPageHTML();
            String strID = Tools.Strings.GetNewID();
            NMWin.Data.Execute("insert into raw_" + ScanName + " (unique_id, url, scandate, all_text, all_html, is_parsed) values ('" + strID + "', '" + NMWin.Data.SyntaxFilter(strURL) + "', getdate(), '" + NMWin.Data.SyntaxFilter(strText) + "', '" + NMWin.Data.SyntaxFilter(strHTML) + "', 0)");
        }

        //public virtual bool GrabMainPageAndParseHTML()
        //{
        //    String strURL = wb.GetURL();
        //    String strText = wb.GetPageText();
        //    String strHTML = wb.GetPageHTML();
        //    String strID = Tools.Strings.GetNewID();
        //    if (!xSys.xData.Execute("insert into raw_" + ScanName + " (unique_id, url, scandate, all_text, all_html, is_parsed) values ('" + strID + "', '" + xSys.xData.SyntaxFilter(strURL) + "', getdate(), '" + xSys.xData.SyntaxFilter(strText) + "', '" + xSys.xData.SyntaxFilter(strHTML) + "', 0)"))
        //        return false;

        //    ParseOneByHTML(strHTML);
        //    return true;
        //}

        public virtual void ParseMainPageByHTML()
        {
            ParseOneByHTML(wb.GetPageHTML());
        }

        public virtual void GrabMainPage()
        {
            String strURL = wb.GetURL();
            String strText = wb.GetPageText();
            String strHTML = wb.GetPageHTML();
            String strID = Tools.Strings.GetNewID();
            NMWin.Data.Execute("insert into raw_" + ScanName + " (unique_id, url, scandate, all_text, all_html, is_parsed) values ('" + strID + "', '" + NMWin.Data.SyntaxFilter(strURL) + "', getdate(), '" + NMWin.Data.SyntaxFilter(strText) + "', '" + NMWin.Data.SyntaxFilter(strHTML) + "', 0)");
        }
        public void SaveAPage(String strURL, String strText, String strHTML)
        {
            String strID = Tools.Strings.GetNewID();
            NMWin.Data.Execute("insert into raw_" + ScanName + " (unique_id, url, scandate, all_text, all_html, is_parsed) values ('" + strID + "', '" + NMWin.Data.SyntaxFilter(strURL) + "', getdate(), '" + NMWin.Data.SyntaxFilter(strText) + "', '" + NMWin.Data.SyntaxFilter(strHTML) + "', 0)");
        }

        public ArrayList GetLinkArray(String strIncluding)
        {
            return wb.GetLinkArray(strIncluding);
        }
        public ArrayList GetLinkArray()
        {
            return wb.GetLinkArray();
        }
        public void GrabLink(String strLink)
        {
            //check to make sure we don't already have it
            if (NMWin.Data.StatementExists("select * from raw_" + ScanName + " where url = '" + NMWin.Data.SyntaxFilter(strLink) + "&logonstatus=N'"))
            {
                SetStatus("Skipping " + strLink);
                return;
            }
            SetStatus("Grabbing " + Tools.Strings.Right(strLink, 20));
            wbExtra.Navigate(strLink);
            wbExtra.WaitForDone();
            wbExtra.WaitForDone();
            GrabPage();
        }
        public void GrabLink_WithoutIE(String strLink)
        {
            GrabLink_WithoutIE(strLink, false);
        }
        public void GrabLink_WithoutIE(String strLink, bool remove_scripts)
        {
            //check to make sure we don't already have it
            if (NMWin.Data.StatementExists("select * from raw_" + ScanName + " where url = '" + NMWin.Data.SyntaxFilter(strLink) + "'"))
            {
                SetStatus("Skipping " + Tools.Strings.Right(strLink, 50));
                return;
            }
            SetStatus("Grabbing " + Tools.Strings.Right(strLink, 50));
            System.Net.ServicePointManager.CertificatePolicy = new AcceptAllCerts(); //see class below

            String s = "";
            try
            {
                System.Net.WebClient c = new System.Net.WebClient();
                Byte[] b = c.DownloadData(strLink);
                s = Encoding.ASCII.GetString(b);
            }
            catch
            {
                throw new Exception("Error on " + strLink);
            }
            
            if( remove_scripts )
                s = nTools.RemoveHTMLScripts(s);
            try
            {
                wbExtra.ReloadWB();
                wbExtra.Add(s);
            }
            catch
            {
            }
            String strURL = strLink;
            String strText = wbExtra.GetPageText();
            String strHTML = s;
            String strID = Tools.Strings.GetNewID();
            if( Tools.Strings.StrExt(strText) || Tools.Strings.StrExt(strHTML) )
                NMWin.Data.Execute("insert into raw_" + ScanName + " (unique_id, url, scandate, all_text, all_html, is_parsed) values ('" + strID + "', '" + NMWin.Data.SyntaxFilter(strURL) + "', getdate(), '" + NMWin.Data.SyntaxFilter(strText) + "', '" + NMWin.Data.SyntaxFilter(strHTML) + "', 0)");
            else
                SetStatus("Blank page");
        }

        public void GrabLink_QuickHTML(String strLink)
        {
            SetStatus("Grabbing " + Tools.Strings.Right(strLink, 20));
            System.Net.WebClient c = new System.Net.WebClient();
            Byte[] b = c.DownloadData(strLink);
            String s = Encoding.ASCII.GetString(b);
            String strURL = strLink;
            String strText = "";
            String strHTML = s;
            String strID = Tools.Strings.GetNewID();
            NMWin.Data.Execute("insert into raw_" + ScanName + " (unique_id, url, scandate, all_text, all_html, is_parsed) values ('" + strID + "', '" + NMWin.Data.SyntaxFilter(strURL) + "', getdate(), '" + NMWin.Data.SyntaxFilter(strText) + "', '" + NMWin.Data.SyntaxFilter(strHTML) + "', 0)");
        }

        public void GrabLink_Post(String strLink, String strPost)
        {
            String strTotalLink = strLink;
            if( Tools.Strings.StrExt(strPost) )
                strTotalLink += "<post>" + strPost;
            if (NMWin.Data.StatementExists("select * from raw_" + ScanName + " where url = '" + NMWin.Data.SyntaxFilter(strTotalLink) + "'"))
            {
                SetStatus("Skipping " + Tools.Strings.Right(strTotalLink, 50));
                return;
            }

            WebRequest t = WebRequest.Create(strLink);
            t.Method = "POST";
            t.ContentType = "application/x-www-form-urlencoded";
            writeToURL(t, strPost);
            string htmlContent = retrieveFromURL(t);
            SaveAPage(strTotalLink, "", htmlContent);            
        }

        public void GrabLinksIncluding(String strStart)
        {
            ArrayList a = null;
            if( strStart == "" )
                a = GetLinkArray();
            else
                a = GetLinkArray(strStart);

            GrabLinks(a);
        }

        public void GrabLinks(ArrayList a)
        {
            foreach (String s in a)
            {
                GrabLink(s);
            }
        }

        public void GrabLinksIncluding_WithoutIE(String strStart)
        {
            ArrayList a = GetLinkArray();
            foreach(String s in a)
            {
                if(Tools.Strings.HasString(s, strStart))
                {
                    GrabLink_WithoutIE(s, true);
                }
            }
        }
        private void nWebScan_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        public virtual void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                sc.Width = this.ClientRectangle.Width - gb.Width;
                sc.Height = this.ClientRectangle.Height - ( gbBottom.Height + sc.Top );
                gbBottom.Top = this.ClientRectangle.Height - gbBottom.Height;
            }
            catch(Exception)
            {
            }
        }
        public void ParseEachByText()
        {
            DataTable d = NMWin.ContextDefault.Select("select unique_id from raw_" + ScanName + " where isnull(is_parsed, 0) = 0 order by scandate");
            if(!nTools.DataTableExists(d))
            {
                NMWin.Leader.Tell("No Records.");
                return;
            }
            foreach(DataRow r in d.Rows)
            {
                String s = NMWin.Data.GetScalar_String("select all_text from raw_" + ScanName + " where unique_id = '" + (String)r["unique_id"] + "'");
                if(Tools.Strings.StrExt(s))
                {
                    ParseOneByText(s);
                }
            }
        }

        public void ParseEachByHTML()
        {
            ParseEachByHTML("");
        }

        public void ParseEachByHTML(String strDatabaseName)
        {
            DataConnectionSqlServer dt = null;
            if (Tools.Strings.StrExt(strDatabaseName))
            {
                dt = new DataConnectionSqlServer(NMWin.Data.TheKey.ServerName, strDatabaseName, NMWin.Data.TheKey.UserName, NMWin.Data.TheKey.UserPassword);
                dt.Init(dt.TheKey);
                try
                {
                    dt.ConnectPossible();
                }
                catch (Exception e)
                {
                    NMWin.Leader.Tell(e.Message);
                    return;
                }
                SetStatus("Using " + strDatabaseName);
            }
            else
            {
                dt = NMWin.Data;
            }

            DataTable d = dt.Select("select unique_id from raw_" + ScanName + " where isnull(is_parsed, 0) = 0 order by scandate");
            if(!nTools.DataTableExists(d))
            {
                NMWin.Leader.Tell("No Records.");
                return;
            }
            foreach(DataRow r in d.Rows)
            {
                String s = dt.GetScalar_String("select all_html from raw_" + ScanName + " where unique_id = '" + (String)r["unique_id"] + "'");
                String strURL = dt.GetScalar_String("select url from raw_" + ScanName + " where unique_id = '" + (String)r["unique_id"] + "'");
                if(Tools.Strings.StrExt(s))
                {
                    ParseOneByHTML(s);
                    ParseOneByHTML(s, strURL);
                }
            }
        }
        public virtual void ParseOneByText(String s)
        {
            throw new Exception("ParseOneByText needs to be overridden to be used, or implemented as a generic parse.");
        }
        public virtual void ParseOneByHTML(String s)
        {
            //context.TheLeader.Tell("ParseOneByHTML needs to be overridden to be used, or implemented as a generic parse.");
            return;
        }
        public virtual void ParseOneByHTML(String s, String strURL)
        {
            //context.TheLeader.Tell("ParseOneByHTML needs to be overridden to be used, or implemented as a generic parse.");
            return;
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            AsyncWork((String)e.Argument);
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AsyncWorkCompleted();
        }
        public virtual void AsyncWork(String strArgument)
        {
        }
        public virtual void AsyncWorkCompleted()
        {
        }
        public void SetGoogleUserAgent()
        {
            wb.UserAgent = "Googlebot/2.1 (http://www.googlebot.com/bot.html)";
            wbExtra.UserAgent = "Googlebot/2.1 (http://www.googlebot.com/bot.html)";
        }
        private void cmdStop_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("cancel this scan"))
                return;
            SetStatus("Cancelling...");
            CancelFlag = true;
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            DoView();
        }

        public virtual void DoView()
        {

        }

        public void SetHeader(WebRequest t, String name, String value)
        {
            try
            {
                String s = t.Headers.Get(name);
                if (s == null)
                    t.Headers.Add(name, value);
                else
                    t.Headers.Set(name, value);
            }
            catch { }
        }

        public String WebFlatten(String s)
        {
            return s.Replace("<br>", " ").Replace("\r\n", " ").Replace("?", "").Trim();
        }

        public String retrieveFromURL(WebRequest request)
        {
            String s = "";
            return retrieveFromURL(request, ref s);
        }

        public String retrieveFromURL(WebRequest request, ref String cookie)
        {
            // 1. Get the Web Response Object from the request
            WebResponse response = request.GetResponse();

            try
            {
                cookie = response.Headers.Get("Set-Cookie");
            }
            catch { }

            // 2. Get the Stream Object from the response
            Stream responseStream = response.GetResponseStream();

            // 3. Create a stream reader and associate it with the stream object
            StreamReader reader = new StreamReader(responseStream);

            // 4. read the entire stream
            return reader.ReadToEnd();
        }// end retrieveFromURL method

        public void SaveFileFromRequest(WebRequest request, String strLocalFileName)
        {
            // 1. Get the Web Response Object from the request
            WebResponse response = request.GetResponse();

            // 2. Get the Stream Object from the response
            Stream responseStream = response.GetResponseStream();

            // 3. Create a stream reader and associate it with the stream object
            BinaryReader reader = new BinaryReader(responseStream);

            if (File.Exists(strLocalFileName))
                File.Delete(strLocalFileName);

            BinaryWriter w = new BinaryWriter(new FileStream(strLocalFileName, FileMode.Create));

            try
            {
                while (true)
                {
                    Byte b = reader.ReadByte();
                    w.Write(b);
                }
            }
            catch { }

            try
            {

                reader.Close();
                reader = null;

                w.Close();
                w = null;
            }
            catch { }

        }

        public void writeToURL(WebRequest request, string data)
        {

            byte[] bytes = null;
            // Get the data that is being posted (or sent) to the server
            bytes = System.Text.Encoding.ASCII.GetBytes(data);
            request.ContentLength = bytes.Length;
            // 1. Get an output stream from the request object
            Stream outputStream = request.GetRequestStream();

            // 2. Post the data out to the stream
            outputStream.Write(bytes, 0, bytes.Length);

            // 3. Close the output stream and send the data out to the web server
            outputStream.Close();
        }


        public virtual void ParseEachByRow(int RowLength)
        {
            DataTable d = NMWin.ContextDefault.Select("select unique_id from raw_" + ScanName + " where isnull(is_parsed, 0) = 0 order by scandate");
            if (!nTools.DataTableExists(d))
            {
                NMWin.Leader.Tell("No Records.");
                return;
            }
            foreach (DataRow r in d.Rows)
            {
                String s = NMWin.Data.GetScalar_String("select all_html from raw_" + ScanName + " where unique_id = '" + (String)r["unique_id"] + "'");
                if (Tools.Strings.StrExt(s))
                {
                    ParseOneByRow(s, RowLength);
                }
            }
        }

        public void ParseOneByRow(String s, int RowLength)
        {
            wb.ReloadWB();
            wb.Add(s);

            foreach (mshtml.IHTMLElement e in wb.GetDocument().all)
            {
                if (Tools.Strings.StrCmp(e.tagName, "table"))
                {
                    mshtml.HTMLTable t = (mshtml.HTMLTable)e;

                    if (t.rows.length > 1)
                    {
                        foreach (mshtml.HTMLTableRow r in t.rows)
                        {
                            if (r.cells.length > 4)
                            {
                                ;
                            }
                            if (r.cells.length == RowLength)
                            {
                                ParseARow(r);
                            }
                        }
                    }
                }
            }
        }

        public virtual void ParseARow(mshtml.HTMLTableRow r)
        {
            throw new Exception("ParseARow must be overridden");
        }

        public void IndexURL()
        {
            SetStatus("indexing...");
            NMWin.Data.Execute("drop index url_index on raw_" + ScanName, true);
            NMWin.Data.Execute("create index url_index on raw_" + ScanName + " ( url )");
        }
    }

    class AcceptAllCerts : System.Net.ICertificatePolicy
    {

        public AcceptAllCerts()
        {
        }
        public bool CheckValidationResult(
            System.Net.ServicePoint servicePoint,
            System.Security.Cryptography.X509Certificates.X509Certificate cert,
            System.Net.WebRequest webRequest,
            int iProblem)
        {
            //this line of code is never hit
            return true;
        }

    }
}