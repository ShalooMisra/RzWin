using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

using Tools;
using NewMethod;

namespace Rz5
{
    public partial class frmPhoneFaxMonitor : Form
    {
        public ContextNM TheContext;
        protected String PhoneBuffer = "";
        //protected SortedList UsersByExtension;
        Socket FaxListener;
        Thread FaxThread;
        ArrayList DupeWatcher = new ArrayList();
        //Private Delegates
        delegate void UpdateText(string r, bool f);
        //Public Variables
        public System.Net.Sockets.Socket TheSocket = null;
        //Private Variables
        Rz5.phonecall SensibleCall = null;
        String IP = "";
        int Port = 0;
        Thread xThread;
        Byte[] byte_buffer;
        //StringBuilder read_buffer;
        int BufferSize = 1024;
        ManualResetEvent allDone = null;

        //Constructors
        public frmPhoneFaxMonitor()
        {
            InitializeComponent();
            if (!this.DesignMode)
                Init(RzWin.Form.TheContextNM);
        }
        public virtual void Init(ContextNM x)
        {
            TheContext = x;
            tmr.Interval = 30000;
            pIP.Visible = true;
            ctlIP.SetValue(x.GetSetting("phone_monitor_ip"));
            ctlPort.SetValue(x.GetSettingInt32("phone_monitor_port"));
        }
        private void chkEnablePhone_CheckedChanged(object sender, EventArgs e)
        {
            if( chkEnablePhone.Checked )
                StartPhone();
            else
                StopPhone();
        }
        //public virtual void StartPhone()
        //{
        //    try
        //    {
        //        txtPhoneStatus.Text = "";
        //        CacheUsers();
        //        sp.Open();
        //        AddStatus("Waiting for data on " + sp.PortName + " [" + sp.BaudRate.ToString() + "]   " + Tools.Number.LongFormat(RzWin.Context.TheSysRz.ThePhoneLogic.UsersByExtension.Count) + " Users ...");
        //        txtPhoneStatus.Enabled = true;
        //        txtPhoneData.Enabled = true;
        //        lblTestCall.Enabled = true;
        //        tmr.Start();
        //    }
        //    catch(Exception ex)
        //    {
        //        txtPhoneStatus.Text = "Serial Connection Error: " + ex.Message;
        //        txtPhoneStatus.Enabled = false;
        //        txtPhoneData.Enabled = false;
        //        chkEnablePhone.Checked = false;
        //        lblTestCall.Enabled = false;
        //    }
        //}
        public void StartPhone()
        {
            try
            {
                txtFaxStatus.Enabled = true;
                txtPhoneStatus.Text = "";
                CacheUsers();
                IP = ctlIP.GetValue_String();
                Port = ctlPort.GetValue_Integer();
                Connect();
                AddStatus("Waiting for data on IP: " + IP + " Port: " + Port.ToString() + " " + Tools.Number.LongFormat(RzWin.Context.TheSysRz.ThePhoneLogic.UsersByExtension.Count) + " Users ...");
                txtPhoneStatus.Enabled = true;
                txtPhoneData.Enabled = true;
                lblTestCall.Enabled = true;
                tmr.Start();
            }
            catch (Exception ex)
            {
                txtPhoneStatus.Text = "Socket Connection Error: " + ex.Message;
                txtPhoneStatus.Enabled = false;
                txtPhoneData.Enabled = false;
                chkEnablePhone.Checked = false;
                lblTestCall.Enabled = false;
            }
        }

        
        public bool IsNewMeritServer
        {
            get
            {
                return (Environment.MachineName == "MERIT-SERVER-1");
            }
        }
        public virtual void StopPhone()
        {
            try
            {
                tmr.Stop();
                txtPhoneStatus.Enabled = false;
                txtPhoneData.Enabled = false;
                txtPhoneStatus.Text = "Closed.";
                sp.Close();
                CloseConnection();
            }
            catch(Exception)
            {
            }
        }
        protected void CacheUsers()
        {
            AddStatus("Caching users by extension...");
            string status = "";
            RzWin.Context.TheSysRz.ThePhoneLogic.CacheUsers(RzWin.Context, ref status);
            if (Tools.Strings.StrExt(status))
                AddStatus(status);
        }
        //protected void ParseCalls()
        //{
        //    while (Tools.Strings.HasString(PhoneBuffer, "\n\n"))
        //    {
        //        PhoneBuffer = PhoneBuffer.Replace("\n\n", "\n");
        //    }
        //    if (!Tools.Strings.StrExt(PhoneBuffer))
        //        return;
        //    bool bComplete = PhoneBuffer.EndsWith("\n");
        //    String[] ary = Tools.Strings.Split(PhoneBuffer, "\n");
        //    int s = ary.Length;
        //    if (!bComplete)
        //    {
        //        s = ary.Length - 1;
        //        LeftOver(ary[ary.Length - 1]);
        //    }
        //    else
        //        PhoneBuffer = "";
        //    ArrayList a = new ArrayList();
        //    if (s > 0)
        //    {
        //        for (int i = 0; i < s; i++)
        //        {
        //            ParseCall(ary[i]);
        //        }
        //    }
        //}
        //public virtual void LeftOver(String leftover)
        //{
        //    PhoneBuffer = leftover;
        //}
        //protected virtual void ParseCall(String strLine)
        //{
        //    RzWin.Leader.Comment("Parsing " + strLine + "...");
        //}
        //public virtual void GotCall(phonecall c)
        //{

        //}
        //private void ParseCall_Merit(String strLine)
        //{
        //    if(!Tools.Strings.StrExt(strLine))
        //    {
        //        RzWin.Leader.Comment("blank phone line");
        //        return;
        //    }
        //    if( strLine.Length < 40 )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "\r") )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "\n") )
        //        return;
        //    if( Tools.Strings.CharCount(strLine, '|') < 6 )
        //        return;
        //    try
        //    {
        //        String[] ary = Tools.Strings.Split(strLine, "|");
        //        phonecall c = phonecall.New(RzWin.Context);
        //        c.callextension = ary[0].Trim();
        //        c.phonenumber = ary[2].Trim();
        //        c.calldate = DateTime.Parse(nTools.DateFormat(DateTime.Now) + " " + ary[4].Replace("A", " AM").Replace("P", " PM").Trim());
        //        if( c.phonenumber.Length == 7 )
        //            c.phonenumber = RzWin.Logic.LocalAreaCode + c.phonenumber;
        //        //String strActual = Rz3App.RzWin.Context.SelectScalarString("select realphone from alternatephone where phone = '" + nTools.FilterPhoneNumber(c.phonenumber, Rz3App.xLogic.LocalAreaCode) + "'");
        //        //if (Tools.Strings.StrExt(strActual))
        //        //{
        //        //    AddStatus("Switching " + c.phonenumber + " to " + strActual);
        //        //    c.phonenumber = strActual;
        //        //}
        //        String strDur = ary[5].Trim();
        //        if( strDur == "99:99:99" )
        //            c.duration = 59;
        //        else
        //            c.duration = ( Int32.Parse(Tools.Strings.Left(strDur, 2)) * 60 * 60 ) + ( Int32.Parse(Tools.Strings.Mid(strDur, 4, 2)) * 60 ) + ( Int32.Parse(Tools.Strings.Mid(strDur, 7, 2)) );
        //        if( Tools.Strings.StrCmp(ary[6].Trim(), "In") )
        //            c.direction = "In";
        //        else
        //            c.direction = "Out";
        //        NewMethod.n_user u = GetUserByExtension(c.callextension);
        //        if(u != null)
        //        {
        //            c.base_mc_user_uid = u.unique_id;
        //            c.username = u.name;
        //            c.main_mc_team_uid = u.main_n_team_uid;
        //            RzWin.Leader.Comment("Using " + u.name + " from ext " + c.callextension);
        //        }
        //        String strDup = c.callextension + "|" + c.duration.ToString() + "|" + c.calldate.ToString();
        //        if(DupeWatcher.Contains(strDup))
        //        {
        //            AddStatus("Skipped duplicate " + strDup);
        //            return;
        //        }
        //        DupeWatcher.Add(strDup);
        //        c.alldata = strLine;
        //        //c.GrabAlternates();
        //        c.Insert(RzWin.Context);
        //        c.ApplyExtraCallStuff(((ContextRz)RzWin.Context), u);
        //        AddStatus("Saved Call: " + c.ToString());
        //        RzWin.Logic.MarkConcern(RzWin.Context, "Phonecall");
        //    }
        //    catch(Exception ex)
        //    {
        //        AddStatus("Error: " + ex.Message);
        //    }
        //}
        //private void ParseCall_Nasco(String strLine)
        //{
        //    if( !Tools.Strings.StrExt(strLine) )
        //        return;
        //    if( strLine.Trim().Length <= 40 )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "SMDR REPORT FOR") )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "====") )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "T EXT  AUTH TRK  MM/DD STT.TIME DURATION FG DIALED DIGIT       ACCOUNT CODE") )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "\r") )
        //        return;
        //    if( Tools.Strings.HasString(strLine, "\n") )
        //        return;
        //    try
        //    {
        //        phonecall c = (phonecall)Rz3App.xSys.MakeObject("phonecall");
        //        System.Globalization.DateTimeFormatInfo dtfFormat = new System.Globalization.CultureInfo("en-US", false).DateTimeFormat;
        //        dtfFormat.LongTimePattern = "HH:mm:ss";
        //        dtfFormat.MonthDayPattern = "MM/dd";
        //        String strDate = Tools.Strings.Mid(strLine, 21, 14);
        //        c.calldate = DateTime.ParseExact(strDate, "MM/dd HH:mm:ss", dtfFormat);
        //        if( strLine.Trim().Length >= 48 )
        //            c.phonenumber = Tools.Strings.Mid(strLine, 48, 16).Trim();
        //        else
        //            c.phonenumber = "";
        //        if( c.phonenumber.Length == 7 )
        //            c.phonenumber = Rz3App.xLogic.LocalAreaCode + c.phonenumber;
        //        String strActual = "";
        //        if( Rz3App.xLogic.IsCTG )
        //            strActual = Rz3App.RzWin.Context.SelectScalarString("select realphone from alternatephone where phone = '" + nTools.FilterPhoneNumber(c.phonenumber, Rz3App.xLogic.LocalAreaCode) + "'");
        //        if(Tools.Strings.StrExt(strActual))
        //        {
        //            AddStatus("Switching " + c.phonenumber + " to " + strActual);
        //            c.phonenumber = strActual;
        //        }
        //        String strDur = Tools.Strings.Mid(strLine, 36, 8).Trim();
        //        c.duration = ( Int32.Parse(Tools.Strings.Left(strDur, 2)) * 60 * 60 ) + ( Int32.Parse(Tools.Strings.Mid(strDur, 4, 2)) * 60 ) + ( Int32.Parse(Tools.Strings.Mid(strDur, 7, 2)) );
        //        c.callextension = Tools.Strings.Mid(strLine, 6, 3).Trim();
        //        String strDirection = Tools.Strings.Mid(strLine, 45, 2).Trim();
        //        if( ( strDirection.StartsWith("I") ) || strDirection.StartsWith("T") || strDirection.StartsWith("==") )
        //            c.direction = "In";
        //        //else
        //        if( strDirection.StartsWith("O") )
        //            c.direction = "Out";
        //        NewMethod.n_user u = GetUserByExtension(c.callextension);
        //        if(u != null)
        //        {
        //            c.base_mc_user_uid = u.unique_id;
        //            c.username = u.name;
        //            c.main_mc_team_uid = u.main_n_team_uid;
        //        }
        //        c.alldata = strLine;
        //        if( Rz3App.xLogic.IsCTG )
        //            c.GrabAlternates();
        //        c.ISave();
        //        c.ApplyExtraCallStuff(((ContextRz)RzWin.Context), u);

        //        if (Tools.Strings.StrExt(c.strippedphone) && !Tools.Strings.StrExt(c.company))
        //        {
        //            String s = Rz3App.RzWin.Context.SelectScalarString("select max(companyname) from company where strippedphone = '%" + c.strippedphone + "%'");

        //            if (Tools.Strings.StrExt(s))
        //            {
        //                c.company = s;
        //                c.companyname = c.company;
        //                AddStatus("Found company match for " + c.strippedphone + ": " + c.company);
        //            }
        //            else
        //            {
        //                AddStatus("No company found for " + c.strippedphone);
        //            }
        //        }
        //        else
        //        {
        //            AddStatus("Skipping company info for " + c.strippedphone + " : " + c.company);                    
        //        }

        //        c.ISave();
        //        AddStatus("Saved Nasco Call: " + c.ToString());
        //        Rz3App.xLogic.MarkConcern("Phonecall");
        //    }
        //    catch(Exception ex)
        //    {
        //        AddStatus("Error: " + ex.Message);
        //    }
        //}
        //protected NewMethod.n_user GetUserByExtension(String strExt)
        //{
        //    if( !Tools.Strings.StrExt(strExt) )
        //        return null;
        //    if( UsersByExtension == null )
        //        CacheUsers();
        //    return (NewMethod.n_user)UsersByExtension[strExt];
        //}
        protected void AddStatus(String strStatus)
        {
            txtPhoneStatus.Text = strStatus + "\r\n" + Tools.Strings.Left(txtPhoneStatus.Text, 2000);
            RzWin.Leader.Comment(strStatus);
        }
        private void lblTestCall_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = Tools.Files.OpenFileAsString(@"c:\bilge\testcalls.txt");
            if(!Tools.Strings.StrExt(s))
            {
                RzWin.Leader.Tell("Please create a file with a sample of the call data at c:\\bilge\\testcalls.txt");
                return;
            }
            PhoneBuffer = s.Replace("\r\n", "\n\n") + "\n\n";
            RzWin.Leader.StartPopStatus("Parsing...");
            PhoneCallArgs args = new PhoneCallArgs(RzWin.Context, PhoneBuffer, chkDebug.Checked);
            RzWin.Context.TheSysRz.ThePhoneLogic.ParseCalls(args);
            if (Tools.Strings.StrExt(args.TheStatus))
                AddStatus(args.TheStatus);
            RzWin.Leader.StopPopStatus();
        }
        private void chkFax_CheckedChanged(object sender, EventArgs e)
        {
            if( chkFax.Checked )
                StartFax();
            else
                StopFax();
        }
        public void StartFax()
        {
            txtFaxStatus.Text = "Starting the fax server...";
            txtFaxStatus.Enabled = true;
            ((Win.RzHookWin)((ContextRz)RzWin.Context).xHook).xFaxForm = this;
            TheContext.SetSetting("windows_fax_server", ((ContextRz)RzWin.Context).xHook.MachineID);
        }
        private void StopFax()
        {
            try
            {
                txtFaxStatus.Text = "Fax server stopped.";
                ((Win.RzHookWin)((ContextRz)RzWin.Context).xHook).xFaxForm = null;
                TheContext.SetSetting("windows_fax_server", "");
            }
            catch(Exception)
            {
            }
        }
        private void AddFaxStatus(String s)
        {
            this.Invoke(new FaxStatusHandler(ActuallyAddFaxStatus), new object[]{ s });
        }
        public delegate void FaxStatusHandler(String s);
        private void ActuallyAddFaxStatus(String s)
        {
            txtFaxStatus.Text = s + "\r\n" + Tools.Strings.Left(txtFaxStatus.Text, 2000);
        }
        delegate void FaxByIDHandler(String strID);
        public void FaxByID(String strID)
        {
            if( InvokeRequired )
                Invoke(new FaxByIDHandler(ActuallyFaxByID), new object[]{ strID });
            else
                ActuallyFaxByID(strID);
        }
        public void ActuallyFaxByID(String strID)
        {
            Thread t = new Thread(new ParameterizedThreadStart(FaxByIDOnThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(strID);
        }
        void FaxByIDOnThread(object x)
        {
            String strID = (String)x;
            DataTable d = RzWin.Context.Select("select order_key, layout_key, fax_number, use_cover, cover_text, requesting_user_uid, extra_documents from faxes where unique_id = '" + strID + "'");
            if(!Tools.Data.DataTableExists(d))
            {
                AddFaxStatus("A fax record [" + strID + "] could not be found.");
                return;
            }
            DataRow r = d.Rows[0];
            String strKey = nData.NullFilter_String(r["order_key"]);
            String strLayout = nData.NullFilter_String(r["layout_key"]);
            String strNumber = nData.NullFilter_String(r["fax_number"]);
            bool boolCover = nData.NullFilter_Boolean(r["use_cover"]);
            String strCover = nData.NullFilter_String(r["cover_text"]);
            String requestUser = nData.NullFilter_String(r["requesting_user_uid"]);
            String strDocuments = "";
            try
            {
                strDocuments = nData.NullFilter_String(r["extra_documents"]);
            }
            catch(Exception)
            {
            }
            if( !boolCover )
                strCover = "";
            ordhed xOrder = (ordhed)RzWin.Context.Sys.GetByKey(RzWin.Context, strKey);
            if(xOrder == null)
            {
                AddFaxStatus("Order " + strKey + " was not found.");
                return;
            }
            printheader xLayout = (printheader)TheContext.xSys.GetByKey(RzWin.Context, strLayout);
            if(xLayout == null)
            {
                AddFaxStatus("The layout " + strLayout + " could not be found.");
                return;
            }
            if(Tools.Strings.StrExt(strNumber) && !Tools.Strings.StrExt(xOrder.primaryfax))
            {
                xOrder.primaryfax = strNumber;
                xOrder.Update(RzWin.Context);
            }
            else if(Tools.Strings.StrExt(xOrder.primaryfax) && !Tools.Strings.StrExt(strNumber))
            {
                strNumber = xOrder.primaryfax;
            }

            nBlobHandle h = new nBlobHandle(RzWin.Context, "faxes", "pdf_data", strID);
            

            AddFaxStatus("Faxing " + xOrder.ToString() + " using template " + xLayout.printtag + " [" + xLayout.printname + "]");
            FaxAnOrder(xOrder, xLayout, strNumber, requestUser, h);
            RzWin.Logic.MarkConcern(RzWin.Context, "Fax");
        }
        void FaxAnOrder(ordhed xOrder, printheader xLayout, String strFaxNumber, String userid, nBlobHandle pdf_data)
        {
            try
            {
                String strFileID = nTools.Replace(Tools.Strings.GetNewID(), "-", "");
                String s = GetPDFFile(xOrder, strFileID);
                try
                {
                    if( File.Exists(s) )
                        File.Delete(s);
                }
                catch
                {
                    AddFaxStatus("The previous copy of " + s + " could not be removed.  Please close any programs using a previously created .pdf file and try again.");
                    return;
                }

                pdf_data.SaveAsFile(s);
                SendWindowsFax(s, strFaxNumber, userid);

                ////throb.ShowThrobber();
                //if(Environment.MachineName == "V4")
                //{
                //    AddFaxStatus("Fake PDFing...");
                //    System.IO.File.Copy("c:\\trash\\2005_08_18.pdf", s);
                //}
                //else
                //{
                //    AddFaxStatus("PDFing...");
                //    xOrder.PrintPDF(xLayout, this, strFileID);
                //}
                //WatchForFile(xOrder, strFileID, strFaxNumber, userid);
            }
            catch
            {
            }
        }
        void WatchForFile(ordhed xOrder, String strFileID, String strFaxNumber, String userid)
        {
            String s = GetPDFFile(xOrder, strFileID);
            for(int i = 0 ; i < 120 ; i++)
            {
                System.Threading.Thread.Sleep(500);
                if( File.Exists(s) )
                    break;
            }
            if(File.Exists(s))
            {
                for(int i = 0 ; i < 120 ; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    try
                    {
                        FileStream f = File.Open(s, FileMode.Open, FileAccess.ReadWrite, FileShare.None);    //see if its locked
                        f.Close();
                        f.Dispose();
                        f = null;
                        break;
                    }
                    catch
                    {
                    }
                }
                System.Threading.Thread.Sleep(2000);
                SendWindowsFax(s, strFaxNumber, userid);
            }
            else
            {
                AddFaxStatus("The .pdf file (" + s + ") was not created within the expected time.");
            }
        }
        public void SendWindowsFax(String strFile, String strNumber, String userid)
        {
            try
            {
                //AddFaxStatus("Faxing to " + strNumber);
                //FAXCOMLib.FaxServerClass fsc = new FAXCOMLib.FaxServerClass();
                //fsc.Connect(Environment.MachineName);
                //object obj = fsc.CreateDocument(strFile);
                //FAXCOMLib.FaxDoc fd = (FAXCOMLib.FaxDoc)obj;
                //fd.FaxNumber = strNumber;
                //fd.RecipientName = strNumber;
                //int i = fd.Send();
                //AddFaxStatus("Fax complete: " + i.ToString());
                //SendUserNotification(userid, true, i.ToString());
                //fd = null;
                //fsc.Disconnect();
                //fsc = null;
            }
            catch(Exception ex)
            {
                AddFaxStatus("There was an error sending this fax: " + ex.Message);
                SendUserNotification(userid, false, ex.Message);
            }
        }
        String GetPDFFile(ordhed xOrder, String strFileID)
        {
            return Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "Orders\\" + xOrder.PDFFileName(strFileID);
        }
        private void SendUserNotification(String id, Boolean success, String result)
        {
            try
            {
                if( !Tools.Strings.StrExt(id) )
                    return;

                usernote n = usernote.New(RzWin.Context);
                n.by_mc_user_uid = RzWin.User.unique_id;
                n.for_mc_user_uid = id;
                n.subjectstring = "Fax Response";
                n.notetext = success ? "Sent! - Code# " + result : "Failed! - Error: " + result;
                n.shouldpopup = true;
                n.displaydate = DateTime.Now;
                n.Insert(RzWin.Context);
            }
            catch
            {
            }
        }
        private void lblTestFax_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SendTestFax(RzWin.Context);
        }
        public virtual void SendTestFax(ContextRz context)
        {
            ordhed x = (ordhed)context.QtO("ordhed", "select top 1 * from " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + " where ordertype = 'purchase' and isnull(companyname, '') > '' order by orderdate desc");
            if( x == null )
                return;
            x.Fax(context);
        }
        private void tmr_Tick(object sender, EventArgs e)
        {
            tmr.Stop();
            try
            {
                HandleTick();
            }
            catch(Exception)
            {
            }
            tmr.Start();
        }
        //public virtual void HandleTick()
        //{
        //    String s = nTools.Replace(sp.ReadExisting(), "\0", "").Replace("\r", "");
        //    if (s.Length > 0)
        //    {
        //        PhoneBuffer += s;
        //        txtPhoneData.Text = Tools.Strings.Right(txtPhoneData.Text, 2000) + s;
        //        PhoneCallArgs args = new PhoneCallArgs(RzWin.Context, PhoneBuffer, chkDebug.Checked);
        //        RzWin.Context.TheSysRz.ThePhoneLogic.ParseCalls(args);
        //        if (Tools.Strings.StrExt(args.TheStatus))
        //            AddStatus(args.TheStatus);
        //    }
        //}
        public void HandleTick()
        {
            SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Checking Socket", true);
            if (TheSocket == null)
            {
                SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Socket==null", true);
                Connect();
                return;
            }
            if (!TheSocket.Connected)
            {
                SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Socket not connected", true);
                Connect();
                return;
            }
            SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Socket Is Connected!", true);
        }





        private void ni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            ni.Visible = false;
        }
        private void cmdHide_Click(object sender, EventArgs e)
        {
            ni.Visible = true;
            this.Hide();
        }
        private void lblSingleTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            phonecall c = phonecall.New(RzWin.Context);
            c.duration = 65;
            c.phonenumber = "19198707899";
            c.base_mc_user_uid = RzWin.User.unique_id;
            c.username = RzWin.User.name;
            c.calldate = DateTime.Now;
            c.direction = "Out";
            c.callextension = RzWin.User.phone_ext;
            c.Inserting(RzWin.Context);
            c.ApplyExtraCallStuff(((ContextRz)RzWin.Context), RzWin.User);
        }
        private void lblInspect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String number = RzWin.Leader.AskForString("Phone number", "", "Number");
            if( !Tools.Strings.StrExt(number) )
                return;
            String strID = "";
            String strName = "";
            frmChooseUser.ChooseUserName(ref strID, ref strName, null, false);
            if( !Tools.Strings.StrExt(strID) )
                return;
            NewMethod.n_user u = (NewMethod.n_user)TheContext.xSys.Users.GetByID(strID);
            if( u == null )
                return;
            RzWin.Leader.StartPopStatus("Inspecting " + number + " for " + u.name);
            phonecall c = phonecall.New(TheContext);
            c.calldate = DateTime.Now;
            c.phonenumber = number;
            c.duration = 1;
            c.username = u.name;
            c.base_mc_user_uid = u.unique_id;
            c.alldata = "test call";
            c.Insert(RzWin.Context);
            c.ApplyExtraCallStuff(((ContextRz)RzWin.Context), u);
            RzWin.Leader.Comment("Inspection complete.");
            RzWin.Leader.StopPopStatus(true);
            RzWin.Context.Show(c);
        }
        private void lblCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String strUserName = "", strUserID = "";
            frmChooseUser.ChooseUserName(ref strUserID, ref strUserName, null, false);
            if (!Tools.Strings.StrExt(strUserID))
                return;

            String strNumber = RzWin.Leader.AskForString("Number?", "", "Number");

            if (!Tools.Strings.StrExt(strNumber))
                return;


            NewMethod.n_user u = (NewMethod.n_user)TheContext.xSys.Users.GetByID(strUserID);
            if( u == null )
                return;

            phonecall c = phonecall.New(RzWin.Context);
            c.calldate = frmChooseDate.ChooseDate(DateTime.Now, "When", this);
            if (!Tools.Dates.DateExists(c.calldate))
                c.calldate = DateTime.Now;
            c.alldata = "manually created " + DateTime.Now.ToString();
            c.callextension = u.phone_ext;
            c.phonenumber = strNumber;
            c.duration = 60;
            c.base_mc_user_uid = u.unique_id;
            c.username = u.name;
            c.Insert(RzWin.Context);
            c.ApplyExtraCallStuff(RzWin.Context, u, false);

            TheContext.TheLeader.TellTemp("Done.");
        }
        private void frmPhoneFaxMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkEnablePhone.Checked)
            {
                if (!RzWin.Leader.AreYouSure("close the phone monitor"))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void chkRecordings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecordings.Checked)
            {
                String strFolder = TheContext.GetSetting("call_recording_folder");
                if (!Tools.Strings.StrExt(strFolder))
                {
                    RzWin.Leader.Tell("Please create a setting for call_recording_folder");
                    chkRecordings.Checked = false;
                    return;
                }

                if (!Directory.Exists(strFolder))
                {
                    RzWin.Leader.Tell("The folder " + strFolder + " could not be found.  Trying anyway...");
                    //return;
                }

                try
                {
                    fsw.Path = strFolder;
                    fsw.EnableRaisingEvents = true;
                    AddStatus("Watching recordings on " + strFolder);
                }
                catch(Exception ex)
                {
                    AddStatus("Error " + ex.Message);
                }
            }
            else
            {
                fsw.EnableRaisingEvents = false;
                AddStatus("Stopped watching recordings");
            }
        }
        private void fsw_Created(object sender, FileSystemEventArgs e)
        {
            string full_path = e.FullPath;
            if (!Tools.Strings.HasString(full_path, "\\Prelog\\"))
            {
                if (full_path.ToLower().EndsWith(".wav"))
                {
                    String dat = Tools.Folder.ConditionFolderName(Path.GetDirectoryName(full_path)) + Path.GetFileNameWithoutExtension(full_path) + ".dat";
                    if (File.Exists(dat))
                    {
                        AddStatus("Recording: " + full_path);
                        //System.Threading.Thread.Sleep(1000);
                        GotRecording(full_path);
                    }
                }
                else if (e.FullPath.ToLower().EndsWith(".dat"))
                {
                    String wav = Tools.Folder.ConditionFolderName(Path.GetDirectoryName(full_path)) + Path.GetFileNameWithoutExtension(full_path) + ".wav";
                    if (File.Exists(wav))
                    {
                        AddStatus("Recording: " + full_path);
                        //System.Threading.Thread.Sleep(1000);
                        GotRecording(wav);  //always pass the wav file, because it converts it to .dat
                    }
                }   
            }
        }
        public virtual void GotRecording(String path)
        {

        }
        private void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            //AddStatus("Recording: " + e.FullPath);
        }
        private void fsw_Renamed(object sender, RenamedEventArgs e)
        {
            //AddStatus("Recording: " + e.FullPath);
        }
        //protected virtual void SaveIP()
        //{

        //}

        protected virtual void SaveIP()
        {
            RzWin.Context.SetSetting("phone_monitor_ip", ctlIP.GetValue_String());
            RzWin.Context.SetSettingInt32("phone_monitor_port", ctlPort.GetValue_Integer());
        }
        private void cmdSaveIP_Click(object sender, EventArgs e)
        {
            SaveIP();
        }





        private bool Connect()
        {
            try
            {
                EndPoint ep = new IPEndPoint(IPAddress.Parse(IP), Port);
                if (TheSocket != null)
                    CloseConnection();
                TheSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Socket connecting...", true);
                TheSocket.Connect(ep);
                if (TheSocket.Connected)
                {
                    SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Socket connected!", true);
                    ReadLoopOnThread();
                    return true;
                }
                else
                {
                    SetTextData(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " : Socket NOT CONNECTED!", true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                SetTextData("Error: " + ex.Message, true);
                return false;
            }
        }
        private void ReadLoopOnThread()
        {
            KillThread();
            InitReading();
            xThread = new Thread(new ThreadStart(ReadLoop));
            xThread.SetApartmentState(ApartmentState.STA);
            xThread.Start();
        }
        private void KillThread()
        {
            if (xThread == null)
                return;
            try
            {
                xThread.Abort();
                xThread = null;
            }
            catch { }
        }
        private void InitReading()
        {
            byte_buffer = new Byte[BufferSize];
            //read_buffer = new StringBuilder();
        }
        private void ReadLoop()
        {
            try
            {
                allDone = new ManualResetEvent(false);
                while (true)
                {
                    allDone.Reset();
                    if (allDone == null)
                        break;
                    ClearBytes();
                    TheSocket.BeginReceive(byte_buffer, 0, BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), this);
                    allDone.WaitOne();
                    if (allDone == null)
                        break;
                }
            }
            catch (Exception ex)
            {
                SetTextData("Error: " + ex.Message, true);
            }
            allDone = null;
        }
        private void ClearBytes()
        {
            Array.Clear(byte_buffer, 0, byte_buffer.Length);
        }
        private void ReadCallback(IAsyncResult ar)
        {
            frmPhoneFaxMonitor c = (frmPhoneFaxMonitor)ar.AsyncState;
            try
            {
                int bytesRead = c.TheSocket.EndReceive(ar);
                if (bytesRead > 0)
                {
                    String r = Encoding.ASCII.GetString(c.byte_buffer, 0, bytesRead);
                    c.ClearBytes();
                    //c.read_buffer.Append(r);
                    if (r.Length > 0)
                    {
                        PhoneBuffer += r;
                        SetTextData(r, false);
                        PhoneCallArgs a = new PhoneCallArgs(RzWin.Context, PhoneBuffer, false);
                        RzWin.Context.TheSysRz.ThePhoneLogic.ParseCalls(a);
                        PhoneBuffer = a.PhoneBuffer;
                    }
                }
            }
            catch (Exception ex)
            {
                c.ClearBytes();
                SetTextData("Error: " + ex.Message, true);
            }
            try
            {
                allDone.Set();
            }
            catch { }
        }
        private void CloseConnection()
        {
            if (TheSocket != null)
            {
                try
                {
                    TheSocket.Shutdown(SocketShutdown.Both);
                    TheSocket.Close();
                    TheSocket = null;
                }
                catch { }
            }
        }
        private void SetTextData(string r, bool fax)
        {
            UpdateText t = new UpdateText(ActuallySetTextData);
            if (this.InvokeRequired)
                Invoke(t, new Object[] { r, fax });
            else
                ActuallySetTextData(r, fax);
        }
        private void ActuallySetTextData(string r, bool fax)
        {
            if (fax)
                txtFaxStatus.Text = r + "\r\n" + Tools.Strings.Right(txtFaxStatus.Text, 2000);
            else
                txtPhoneData.Text = Tools.Strings.Right(txtPhoneData.Text, 2000) + r;
        }
    }
}