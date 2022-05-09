using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

using Tools;
using ToolsWin;
using Core;
using Core.Display;
using CoreWin;
using NewMethod;
using Tools.Database;
using System.Collections.Generic;

namespace Rz5
{
    public partial class frmRecogniz : NewMethod.frmMain
    {
        public bool ShowClip = true;
        protected String strCaption;
        protected ToolStripSplitButton PanelButton = null;
        private nClip xClip = null;

        public frmRecogniz()
        {
            InitializeComponent();
        }

        public override void Init(Context x)
        {
            Style.StyleCurrent.IconFormDefault = this.Icon;
            sb.Visible = false;
            base.Init(x);
            try
            {
                tmrNotes.Start();
                tmrQuick.Start();
                CheckStartScreen();
                if (!RzWin.User.IsDeveloper() && !Tools.Strings.StrExt(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_companyname)))
                    RzWin.Leader.ShowCompanySettings();
                vp.ServerName = RzWin.Context.Data.ServerName;
                vp.IsDataConnected = true;
                vp.ShowAllInfo();
                ConfirmClose = RzWin.User.GetSetting_Boolean(RzWin.Context, "confirm_close");
                if (Tools.Strings.HasString(RzWin.Context.Data.DatabaseName, "recent") || Tools.Strings.HasString(RzWin.Context.Data.DatabaseName, "test"))
                {
                    vp.BackColor = Color.LightSalmon;
                    TestScreenShow();
                }
                LoadUserTabs();
                //KT Make Rz get focus after load?
                this.WindowState = FormWindowState.Maximized;

            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error in frmRecogniz.CompleteLoad: " + ex.Message);
            }
        }
        public override Image GetBackButtonImage()
        {
            try
            {

                return ilRz.Images["RZ-Back-1.png"];
            }
            catch
            {
                return base.GetBackButtonImage();
            }
        }
        public override Image GetExitButtonImage()
        {
            try
            {
                return ilRz.Images["RZ-Exit-1.png"];
            }
            catch
            {
                return base.GetBackButtonImage();
            }
        }
        //Protected Override Functions
        protected override Image ToolBarImageGet(string s)
        {
            //caused a compiled error after the Rz5 rename?
            //switch (s.ToLower())
            //{
            //    case "reports":
            //        return RzInterfaceWin.Properties.Resources.reports;
            //}

            switch (s.ToLower())
            {
                //case "reports":
                //return RzInterfaceWin.Properties.Resources.reports;
                case "parts":
                    return ilRz.Images["RZ-Parts-1.png"];
                case "people":
                    return ilRz.Images["RZ-People-1.png"];
                case "home":
                    return ilRz.Images["RZ-Home-1.png"];
                case "orders":
                    return ilRz.Images["RZ-Orders-1.png"];
                case "ship":
                    return ilRz.Images["RZ-Ship-1.png"];
                case "email":
                    return ilRz.Images["RZ-Email-1.png"];
                case "import":
                    return ilRz.Images["RZ-Import-1.png"];
                case "reports":
                    return ilRz.Images["RZ-Reports-1.png"];
                case "panel":
                    return ilRz.Images["RZ-panel-1.png"];
                case "tools":
                    return ilRz.Images["RZ-tools-1.png"];

            }



            Image ret = null;
            try
            {
                ret = ilRz.Images[s];
            }
            catch
            {
                ret = base.ToolBarImageGet(s);
            }

            if (ret == null)
            {
                try
                {
                    ret = il24.Images[s];
                }
                catch { }
            }

            if (ret == null)
                ret = base.ToolBarImageGet(s);
            return ret;
        }

        //Protected Virtual Functions
        protected virtual void LoadUserScreen(n_user_screens u)
        {
            if (u == null)
                return;
            UserControl screen = ((LeaderWinUserRz)RzWin.Context.TheLeader).TranslateUserScreen(RzWin.Context, u.screen_id);
            if (screen == null)
                return;
            this.strCaption = u.screen_id;
            TabPageCore tp = TabShow(screen, strCaption, u.is_locked);
            tp.DoResize();
        }
        protected virtual void LoadToolBarRz()
        {

        }
        protected virtual void EmailAndArApAdd()
        {

        }
        protected virtual void AddPanelButton()
        {

        }
        protected virtual Win.Screens.TestRzScreen TestScreenCreate()
        {
            return new Win.Screens.TestRzScreen();
        }
        protected virtual void RunTests()
        {
            CoreWin.frmTest t = new CoreWin.frmTest();
            t.CompleteLoad(TheContext, true);
            t.ShowDialog();
            HandleTestPassFail(t.TheResult);
        }
        private void HandleTestPassFail(ProveResult r)
        {
            string ident = "";
            try { ident = ((ContextRz)TheContextNM).TheLogicRz.CompanyIdentifier + "_"; }
            catch { }
            string file = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + ident + Tools.Strings.GetNewID();
            if (r == null)
            {
                file += ".fail.txt";
                Tools.Files.SaveFileAsString(file, "SystemTest=Fail\r\nTestResult == null");
            }
            else
            {
                if (r.Passed)
                {
                    file += ".success.txt";
                    Tools.Files.SaveFileAsString(file, "SystemTest=Success");
                    Application.Exit();
                    return;
                }
                else
                {
                    file += ".fail.txt";
                    Tools.Files.SaveFileAsString(file, "SystemTest=Fail\r\n" + r.ToString());
                }
            }
            Tools.FileSystem.Shell(file);
        }
        //Public Functions
        public void CreditCardNumbersShow()
        {
            CreditCardEntry c = new CreditCardEntry();
            c.Init();
            c.ShowDialog();
        }
        public void TestScreenShow()
        {
            TabPageCore p = TabShow(TestScreenCreate(), "Test Options");
            p.Lock();
        }



        public void DataTableSizesManage()
        {
            n_data_target t = frmDataSources.Choose(this, TheContextNM.xSys);
            if (t == null)
                return;

            DataConnectionSqlServer d = (DataConnectionSqlServer)t.GetAsDataConnection();
            String err = "";
            if (!d.ConnectPossible(ref err))
            {
                RzWin.Leader.Tell("Can't connect: " + err);
                return;
            }

            NewMethod.Original.Controls.nTables tables = new NewMethod.Original.Controls.nTables();
            TabShow(tables, "Tables");
            tables.xData = d;
        }
        public void RzTestProcessShow()
        {
            Context context = TheContextNM.Clone();
            context.LeaderRecreate();
            context.Leader.HtmlInit();
            ((SysRz5)TheContextNM.TheSys).ProofLogic.TestNewVersion((ContextRz)context);
            ShowHTML(context.Leader.Html, "Rz Test");
        }
        public void FlashChat()
        {
            vp.FlashChat();
        }
        //Private Functions
        TabPageCore startTab;
        private void ShowClipTab()
        {
            try
            {
                xClip = new nClip();
                xClip.OnClipEvent += new nClip.ClipEventHandler(clip_OnClipEvent);
                startTab = TabShow(xClip, "Start");
                startTab.Lock();
            }
            catch { }
        }
        private void OpenUserScreens(bool clear_tabs)
        {
            try
            {
                ArrayList a = RzWin.Context.QtC("n_user_screens", "select * from n_user_screens where the_n_user_uid = '" + RzWin.User.unique_id + "' order by load_order");
                if (a == null)
                    return;
                if (a.Count <= 0)
                    return;
                if (clear_tabs)
                    ts.TabsClearAll();
                foreach (n_user_screens u in a)
                {
                    LoadUserScreen(u);
                }
            }
            catch { }
        }
        private void GetLatestQB()
        {
            String strFile = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "Interop.QBFC7Lib.dll";
            if (!System.IO.File.Exists(strFile))
            {
                Tools.Files.DownloadInternetFile("http://www.recognin.com/Interop.QBFC7Lib.dll", strFile);
            }

            Tools.FileSystem.Shell("http://mike.recognin.com/QBSDK70.exe");

        }
        //Menus  
        private void ImportRz3_Click(object sender, EventArgs e)
        {
            //ImportRz3 i = new ImportRz3();
            //i.Import(RzWin.Context);
            //RzWin.Context.TheLeader.Tell("Done");
        }
        protected void SetDutyMonitorServerName_Click(object sender, EventArgs e)
        {
            try
            {
                string cur = RzWin.Context.GetSetting("DutyMonitorServerName");
                string cha = RzWin.Leader.AskForString("Enter the new servers name.", cur);
                RzWin.Context.SetSetting("DutyMonitorServerName", cha);
            }
            catch { }
        }
        protected void PurgeOutdatedExcess_Click(object sender, EventArgs e)
        {
            //!!!
            //Rz3Logic.PurgeOutdatedExcess(Rz3App.xMainForm.TheContextRzCommon);
        }
        private void mnuChangeUserName_Click(Object sender, EventArgs e)
        {
            RzWin.Logic.ChangeUserName(RzWin.Context);
        }
        private void mnuSetDecimals_Click(Object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("switch the format of all costs and prices to 2-6 decimal places"))
                return;

            RzWin.Context.Execute("update n_column set column_format = '{0:###,###,##0.00####}' where data_type = 4 and field_name not like '%extended%' and field_name not like '%total%' and field_name not like '%amount%'");
            RzWin.Leader.Tell("Done; please close and reopen Rz to see these changes.");
        }
        private void LatestQB_Click(object sender, EventArgs e)
        {
            GetLatestQB();
        }
        private void mnuRzRescueInterface_Click(Object sender, EventArgs e)
        {
            frmRzRescueInterface f = new frmRzRescueInterface();
            f.Show();
        }
        private void mnuOrderNumberEditor_Click(Object sender, EventArgs e)
        {
            frmOrderNumberEditor f = RzWin.Leader.GetOrderNumberEditor(RzWin.Context);
            if (!f.CompleteLoad(RzWin.Form.TheContextNM))
                return;
            f.ShowDialog();
        }
        private void QBSettings_Click(object sender, EventArgs e)
        {
            ShowQuickBench();
        }
        private void Decode_Click(object sender, EventArgs e)
        {
            String s = RzWin.Leader.AskForString("Code", "", true, "Code");
            if (!Tools.Strings.StrExt(s))
                return;
            Tools.FileSystem.PopText(nTools.Decrypt(s, "rec0gnin"));
        }
        private void WebTables_Click(object sender, EventArgs e)
        {
            ToolsWin.TableScanner s = new ToolsWin.TableScanner();
            TabShow(s, "Web Tables");
        }
        private void RzTestProcess_Click(object sender, EventArgs e)
        {
            RzTestProcessShow();
        }
        private void ShowOrders_Click(object sender, EventArgs e)
        {
            String s = RzWin.Leader.AskForString("Numbers", "10-10", "Numbers (Orders-Repetitions)");
            if (!Tools.Strings.StrExt(s))
                return;
            try
            {
                long orders = Int64.Parse(Tools.Strings.ParseDelimit(s, "-", 1).Trim());
                long repetitions = Int64.Parse(Tools.Strings.ParseDelimit(s, "-", 2).Trim());
                for (int r = 0; r < repetitions; r++)
                {
                    ArrayList a = RzWin.Context.QtC(ordhed.MakeOrdhedName(Enums.OrderType.Invoice), "select top " + orders.ToString() + " * from " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " order by orderdate desc");
                    foreach (ordhed o in a)
                    {
                        TheContextNM.Show(o);
                    }
                    for (int i = 0; i < a.Count; i++)
                    {
                        TabTopClose();
                    }
                }
                RzWin.Leader.Done();
            }
            catch
            {
            }
        }
        private void Rz3_Licensing_Click(object sender, EventArgs e)
        {
            FeaturesAndUpgrades f = new FeaturesAndUpgrades();
            f.CompleteLoad();
            TabShow(f, "Rz3 Licensing");
        }
        private void Scan_ICSource_Click(object sender, EventArgs e)
        {
            //ShowGenericTabControl_CompleteLoad(new Scan_ICSource_RFQs(), "IC Source Bids");
        }
        private void Scan_ICSourceRFQ_Click(object sender, EventArgs e)
        {
            //ShowGenericTabControl_CompleteLoad(new Scan_ICSource_RFQs(true), "IC Source RFQs");
        }
        private void Scan_BrokerForum_Click(object sender, EventArgs e)
        {
            //if (Rz3App.xLogic.UseMergedQuotes)
            ShowGenericTabControl_CompleteLoad(new Scan_BF_RFQs(), "BrokerForum Bids");
            //else
            //    ShowGenericTabControl_CompleteLoad(new Scan_Brokerforum_RFQs(), "BrokerForum Bids");
        }
        private void Scan_BrokerForumRFQ_Click(object sender, EventArgs e)
        {
            //if (Rz3App.xLogic.UseMergedQuotes)
            ShowGenericTabControl_CompleteLoad(new Scan_BF_RFQs(true), "BrokerForum RFQs");
            //else
            //    ShowGenericTabControl_CompleteLoad(new Scan_Brokerforum_RFQs(true), "BrokerForum RFQs");
        }
        private void ContactReminderScreen_Click(object sender, EventArgs e)
        {
            //ShowGenericTabControl_CompleteLoad(new Reminders(), "Contact Reminder Screen");
        }
        private void CalcCompanyStats_Click(object sender, EventArgs e)
        {
            RzWin.Leader.StartPopStatus();
            RzWin.Leader.Comment("Calculating company stats...");

            try
            {
                company.CalcStats(RzWin.Context);
                RzWin.Leader.Comment("Stats calculation complete.");
            }
            catch
            {
                RzWin.Leader.Comment("Stats calculation failed.");
            }

            RzWin.Leader.StopPopStatus(true);
        }
        private void mnuParts_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:Parts"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }
        private void mnuShipDrop_Opening(object sender, CancelEventArgs e)
        {
            //if( RzLicense.LicenseType != LicenseTypes.Lite )
            e.Cancel = true;
        }
        private void mnuPeople_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:People"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }
        private void mnuHome_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:Home"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }
        private void mnuPanel_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:Panel"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }
        private void mnuOrders_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:Orders"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }
        private void mnuAccounting_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:ArAp"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }
        private void mnuTransfer_Opening(object sender, CancelEventArgs e)
        {
            if (!RzWin.Context.CheckPermit("SubMenu:View:Transfer"))
            {
                RzWin.Leader.ShowNoRight();
                e.Cancel = true;
                return;
            }
        }

        bool update_nag = false;
        protected virtual void SetRz3AppUserName(ref bool skip)
        {

        }

        public void CheckNotes()
        {
            CheckNotes(false);
        }

        public virtual void CheckNotes(bool loud)
        {
            try
            {
                tmrNotes.Stop();
                try
                {
                    if (!RzWin.Context.Data.TheConnection.ConnectPossible())
                    {
                        vp.IsDataConnected = false;
                        vp.ShowDataInfo();
                        tmrNotes.Start();
                        return;
                    }
                    vp.IsDataConnected = true;
                    vp.ShowDataInfo();
                    //check the min version
                    if (!update_nag && RzWin.Logic.IsBelowMinVersion(RzWin.Context))
                    {
                        TheContextNM.TheLeader.TellTemp("Please update to the latest version of Rz.");
                        update_nag = true;
                    }
                    //skip this for assistants logged in as managers
                    bool skip = false;
                    SetRz3AppUserName(ref skip);
                    if (!skip)
                    {
                        ArrayList notes = RzWin.Context.QtC("usernote", "SELECT * FROM usernote WHERE DISPLAYDATE <= getdate() AND for_mc_user_uid = '" + RzWin.User.unique_id + "' AND isnull(is_pending, 0) = 0 and isnull(SHOULDPOPUP, 0) = 1");
                        int i = 0;
                        if (loud)
                            RzWin.Leader.Comment(Tools.Number.LongFormat(notes.Count) + " " + nTools.Pluralize("note", notes.Count) + " found.");
                        foreach (usernote xNote in notes)
                        {
                            if (loud)
                                RzWin.Leader.Comment("Handling " + xNote.subjectstring);
                            TimeSpan t = xNote.displaydate.Subtract(System.DateTime.Now);
                            if (Tools.Strings.StrCmp(xNote.by_mc_user_uid, RzWin.User.unique_id) && Math.Abs(t.Minutes) < 5 && !RzWin.User.IsDeveloper())
                            {
                                //don't send it
                                if (loud)
                                    RzWin.Leader.Comment("Skipping because it hasn't been 5 minutes.");
                            }
                            else
                            {
                                if (i > 10)
                                {
                                    TheContextNM.TheLeader.TellTemp("There are more notes to view, but no more will be shown until the next scheduled check.  Click 'Home' to view these notes now.");
                                    break;
                                }
                                xNote.shouldpopup = false;
                                xNote.Update(RzWin.Context);
                                if (loud)
                                    RzWin.Leader.Comment("Showing " + xNote.subjectstring + " from " + xNote.createdbyname + "...");
                                //Rz3App.Show(xNote);
                                focus_item f = focus_item.New(RzWin.Context);
                                f.the_n_user_uid = xNote.for_mc_user_uid;
                                f.user_name = xNote.createdforname;
                                f.name = "Note from " + xNote.createdbyname;
                                f.description = xNote.notetext.Replace("\r\n", "   \\    ");
                                f.item_type = "UserNote";
                                f.extra_info = xNote.unique_id;
                                f.Insert(RzWin.Context);
                                i++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    RzWin.Leader.Comment("Error: " + ex.Message);
                }
                if (loud)
                    RzWin.Leader.Comment("Done.");
                vp.ShowInboxInfo();
                tmrNotes.Start();
            }
            catch (Exception ex2)
            {
                RzWin.Leader.Comment("Last error: " + ex2.Message);
            }
        }
        public virtual void TieConnectionChanged(bool connected)
        {
            vp.CompanyStatus.IsConnected = connected;
            vp.ShowCompanyInfo();
        }
        public virtual bool RunSync()
        {
            return false;
        }
        public virtual void ShowAllReminderTab()
        {
            //ShowGenericTabControl_CompleteLoad(new AllReminders(), "All Reminders");
        }
        public virtual void ShowContactReminderScreen()
        {
            //Need to be overridden since this is an Rz3 only screen.
        }
        public virtual HomeScreen ShowHomeScreen()
        {
            HomeScreen h;
            if (!RzWin.Context.CheckPermit("General:Search:Search Home"))
            {
                RzWin.Leader.ShowNoRight();
                return null;
            }
            Control c = TabCheckShow("home");
            if (c != null)
            {
                h = (HomeScreen)c;
                return h;
            }
            h = RzWin.Leader.GetHomeScreen();
            System.Windows.Forms.TabPage p = TabShow(h, "Home");
            h.CompleteLoad(RzWin.User, null);
            return h;
        }
        public DutyMonitor ShowDutyMonitor(bool bStart = false, bool bLock = false)
        {
            DutyMonitor d;
            Control c = TabCheckShow("dutymonitor");
            if (c != null)
            {
                d = (DutyMonitor)c;
                return d;
            }
            d = new DutyMonitor();
            TabPageCore p = TabShow(d, "Duty Monitor");
            d.CompleteLoad();
            p.Lock();
            //d.StartStopTimers();
            return d;
        }
        //public void OrderLinksShow(string order_id)
        //{
        //    ordhed o = ordhed.GetById(RzWin.Context, order_id);
        //    if (o == null)
        //        return;
        //    OrderMap m = new OrderMap();
        //    RzWin.Form.TabShow(m, "Order Map");
        //    m.CompleteLoad(o, true);
        //}
        public void PaymentsShow(string orderId)
        {
            ordhed o = ordhed.GetById(RzWin.Context, orderId);
            if (o == null)
                return;
            IPaymentScreen p = RzWin.Leader.GetPaymentScreen(RzWin.Context);
            RzWin.Form.ShowGenericTabControl_CompleteLoad((ICompleteLoad)p, "Payments on " + o.ToString());
            p.ShowOrder(o);
        }
        public void ShowUserPanel()
        {
            UserPanel s;
            Control c = TabCheckShow("panel");
            if (c != null)
            {
                s = (UserPanel)c;
                s.CompleteLoad();
                return;
            }
            s = RzWin.Leader.GetUserPanel();
            TabPage p = TabShow(s, "Panel");
            s.CompleteLoad();
        }
        public void ShowUserManager()
        {
            nTeams b = new nTeams();
            //b.AboutToThrow += new ShowHandler(Rz3App.xMainForm.ShowHandler);
            //b.GetUserList().AboutToThrow += new ShowHandler(Rz3App.xMainForm.ShowHandler);
            RzWin.Form.TabShow(b, "Teams and Users");
            b.CompleteLoad();
        }
        public void ShowCompanyInfo()
        {
            RzWin.Leader.ShowCompanySettings();
        }
        public void ReqSourcingManagerShow()
        {
            //Currently just for Web
        }
        public void ReqQuotingManagerShow()
        {
            //Currently just for Web
        }
        public override void Show(ShowArgs args)
        {
            if (InvokeRequired)
                Invoke(new ShowHandler(ShowObjectActually), new object[] { args });
            else
                ShowObjectActually(args);
        }
        delegate void ShowHandler(ShowArgs args);
        void ShowObjectActually(ShowArgs args)
        {
            try
            {
                base.Show(args);
                nView v = (nView)args.ViewUsed;
                SetActive();

                nObject x = (nObject)args.TheItems.FirstGet(RzWin.Context);

                //user_activity.AddActivity(RzWin.Context, "InfoView", "Viewed " + x.ToString(), "infoview", 0, x);
                RzWin.Context.Logic.RequestObjectLockCheck(RzWin.Context, x.unique_id, x.ToString());
                //return v;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("There was an error showing this information (Rz, show):" + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
                //return null;
            }
        }
        public ordhed GetDisplayedOrder(string strID)
        {
            //for the moment, not all order screens inherit from view_ordhed
            try
            {
                Control c = TabCheckShow(strID);
                if (c != null)
                {
                    view_ordhed v = (view_ordhed)c;
                    return v.CurrentOrder;
                }
                else
                    return null;
            }
            catch
            {
            }
            return null;
        }
        public void ShowMultiSearch()
        {
            ShowMultiSearch("");
        }
        public void ShowMultiSearch(string strPartNumber)
        {
            //if (Rz3App.xLogic.IsAAT)
            //{
            //    ShowAATMultiSearch(strPartNumber);
            //    return;
            //}
            if (!RzWin.Context.CheckPermit("Sales:View:MultiSearch"))
            {
                RzWin.Leader.ShowNoRight();
                return;
            }
            MultiSearch.MultiSearchScreen s;
            Control c = TabCheckShow("multisearch");
            Form xForm = null;
            if (c != null)
            {
                s = (MultiSearch.MultiSearchScreen)c;
                s.SetPartNumber(strPartNumber);
                s.DoRunSearch();
                return;
            }
            else
            {
                FormCollection col = Application.OpenForms;
                foreach (Form frm in col)
                {
                    if (Tools.Strings.StrCmp(frm.Text, "multisearch"))
                    {
                        foreach (Control cc in frm.Controls)
                        {
                            try
                            {
                                s = (MultiSearch.MultiSearchScreen)cc;
                                s.SetPartNumber(strPartNumber);
                                s.DoRunSearch();
                                return;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        return;
                    }
                }
            }
            s = (MultiSearch.MultiSearchScreen)RzWin.Leader.MultiSearchCreate();// new MultiSearch.MultiSearchScreen();
            TabPage p = TabShow(s, "MultiSearch");
            s.SetPartNumber(strPartNumber);
            //MultiSearch.MSData d = new MultiSearch.MSData();
            //s.CompleteLoad(d);
        }
        //public virtual void ShowAATMultiSearch(string strPartNumber)
        //{

        //}     

        public void OEMProductsShow()
        {
            try
            {
                ProductScreen p;
                Control c = TabCheckShow("products");
                if (c != null)
                {
                    p = (ProductScreen)c;
                    p.CompleteLoad();
                    return;
                }
                else
                {
                    p = new ProductScreen();
                    //RzWin.Leader.OEMProductsShow(RzWin.Context);
                    TabPage tp = TabShow(p, "Products");
                    p.CompleteLoad();
                }
            }
            catch
            {

            }


        }
        public void ShowPanel()
        {
            if (!RzWin.Context.CheckPermit("System:View:ViewPanel"))
            {
                RzWin.Leader.ShowNoRight();
                return;
            }
            UserPanel s;
            Control c = TabCheckShow("panel");
            if (c != null)
            {
                s = (UserPanel)c;
                s.CompleteLoad();
                return;
            }
            s = RzWin.Leader.GetUserPanel();
            TabPage p = TabShow(s, "Panel");
            s.CompleteLoad();
        }
        public void ShowTeamManager()
        {
            nTeams b = new nTeams();
            //b.AboutToThrow += new ShowHandler(ShowHandler);
            //b.GetUserList().AboutToThrow += new ShowHandler(ShowHandler);
            TabPage t = TabShow(b, "Teams and Users");
            b.CompleteLoad();
        }
        public void ShowDisconnected(string strError)
        {
            Browser b = new Browser();
            TabShow(b, "Disconnected");
            b.OnNavigate += new OnNavigateHandler(b_OnNavigate);
            b.ReloadWB();
            b.Add("<h1><font color=red>No Data Connection</font></h1><br>The connection to " + RzWin.Context.Data.ServerName + " is not available; the error returned by the connection system is below.<br><br>Please click <a href=update>here</a> to enter new connection details or contact your system administrator or Recognin technical support.<br><br>" + strError + "<br><br>Some common connection problems arise from a lack of network connectivity, the server being unavailable, or a hardware or software firewall blocking the server connection.  For connections over the Internet, be sure that the connection settings include the server's latest IP address.");
        }
        public void ShowUpdateWarning()
        {
            BrowserPlain b = new BrowserPlain();
            TabShow(b, "Update Warning");
            b.OnNavigate += new OnNavigateHandler(b_OnNavigate);
            b.ReloadWB();
            b.Add("<h1><font color=red>Below Min Version</font></h1><br>This workstation's version is below the minimum set for this system.  Please update to continue.");

            ShowVersionUpdate();
            tools.Enabled = false;
        }
        public bool IsObjectOpen(string strID, ref bool focus)
        {
            //is this where it shows it when it checks it?
            //why was it showing the tab to see if its open?
            //Control c = TabCheckShow(strID);
            //if (c == null)
            //    return false;

            try
            {
                TabPageCore t = TabGetByID(strID);
                if (t != null)
                {
                    if (t.HasTheFocus)
                        focus = true;
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }

            //why on earth was this returning true if t is null?
            //return true;
        }
        public void BrowseWebAddress(string url)
        {
            Browser b = new Browser();
            TabPage t = TabShow(b, url);
            b.Navigate(url);
        }
        public void ShowUpgradeToPro()
        {
            FeaturesAndUpgrades f = new FeaturesAndUpgrades();
            f.CompleteLoad();
            TabShow(f, "Rz3 Licensing");
        }
        public override Rectangle AvailableRectangle
        {
            get
            {
                Rectangle r = base.AvailableRectangle;
                r.Height -= vp.Height;
                return r;
            }
        }
        //Private Functions
        public override void DoResize()
        {
            try
            {
                //tools.Top = mnu.Bottom;
                tools.Top = 0;
                base.DoResize();
                vp.Top = this.ClientRectangle.Height - vp.Height;
                vp.Left = 0;
                vp.Width = this.ClientRectangle.Width;
            }
            catch (Exception)
            {
            }
        }

        private void InvokeUpdate(bool request)
        {
            if (this.InvokeRequired)
            {
                RunUpdateDelegate d = new RunUpdateDelegate(RunUpdateHandler);
                this.Invoke(d, new object[] { request });
            }
            else
            {
                RunUpdateHandler(request);
            }
        }
        private void RunUpdateHandler(bool request)
        {
            if (request)
            {
                if (!frmUpdateRequest.RequestVersionUpdate(this))
                    return;
            }
            TheContextNM.xSys.RunVersionUpdate(true);
        }
        public virtual void CheckStartScreen()
        {
        }
        public override void UserApply()
        {
            try
            {
                base.UserApply();
                //TheContextNM.xSys.recall_user_uid = Rz3App.xUser.unique_id;
                //TheContextNM.xSys.recall_user_name = Rz3App.xUser.name;
                nList.AllowConfiguration = RzWin.User.SuperUser;

                //this needs much more granularity than a static variable
                //MenuSetup.AllowExcelExport = Rz3App.xUser.allow_list_export;

                //This is the main version caption in the upper left of the window
                CaptionInit();
                SuppressOpenWarnings = RzWin.User.GetSetting_Boolean(RzWin.Context, "suppress_open_warnings");
                if (RzWin.Context.GetSettingBoolean("alternate_avail_server"))
                    mnuAlternateAvailServer.Checked = true;
                else
                    mnuAlternateAvailServer.Checked = false;
                //Loads Recent Companies?  Not sure if I've seen this in the UI
                if (RzWin.Leader.CompanyForm != null)
                    RzWin.Leader.CompanyForm.ShowClipCompanies();
                tmrQuick.Start();
                vp.CurrentUser = RzWin.User;
                //Sets the name on teh Start Screen
                vp.ShowUserInfo();
                //These "Clips" (n_clips) are the "tree" on the Left of the start screen. (Recent companies, quotes, etc.)
                RzWin.User.CacheClips(RzWin.Context);
                if (ShowClip && xClip == null)
                    ShowClipTab();
                if (xClip != null)
                {
                    xClip.CurrentUser = RzWin.User;
                    xClip.CompleteLoad();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ApplyUser: " + ex.Message);
            }
        }
        private void SetPermitMode(NewMethod.Enums.PermitMode m)
        {
            if (RzWin.User.SuperUser)
            {
                RzWin.Context.Error("The permit mode can't be changed for super users.");
                return;
            }
            if (!RzWin.Context.TheSysRz.TheUserLogicRz.AskForAdminRights(RzWin.Context))  // Rz3App.xUser.  , this
            {
                RzWin.Leader.ShowNoRight();
                return;
            }
            RzWin.User.CurrentPermitMode = m;
            RzWin.Context.xSys.CacheTeamPermits(RzWin.Context);
            UserApply();
        }
        public Rz5.UpdateDownload ShowVersionUpdate()
        {
            UpdateType t = UpdateType.WebToWorkstation;
            if (RzWin.Context.GetSettingBoolean("use_network_update"))
                t = UpdateType.ServerToWorkstation;
            return ShowVersionUpdate(t);
        }
        protected virtual string GetEULA()
        {
            return "http://www.recognin.com/Rz3/eula.htm";
        }
        public Rz5.UpdateDownload ShowVersionUpdate(UpdateType t)
        {
            Rz5.UpdateDownload d = new Rz5.UpdateDownload();
            String strEULA = GetEULA();
            String folder = RzWin.Context.Sys.Name;
            //if (Rz3App.xLogic.IsPhoenix)
            //    folder = "Rz3_Phoenix";      //put in GetUpdateFolder override
            //else
            folder = RzWin.Logic.GetUpdateFolder(TheContextNM);
            UpdateDownloadCore c = new UpdateDownloadCore();
            c.Init(TheContextNM, t, strEULA, folder, false);
            TabShow(d, "Update Download");
            d.Init(c);
            return d;
        }
        private void ListControls(Control c, StringBuilder sb)
        {
            foreach (Control co in c.Controls)
            {
                sb.AppendLine(co.Name);
                ListControls(co, sb);
            }
        }
        private void ShowMultiSearch_Legacy(string strPartNumber)
        {
            Int32 tempHwnd = ToolsWin.Win32API.FindWindow(null, "MultiSearch");
            string strPath = "";
            if (Tools.Misc.IsDevelopmentMachine())
                strPath = "c:\\eternal\\code\\MultiSearch\\MultiSearch\\bin\\Debug\\multisearch.txt";
            else
                strPath = Tools.FileSystem.GetAppPath() + "multisearch.txt";
            string strData = strPartNumber + "|" + RzWin.User.unique_id + "|" + RzWin.User.name + "||";
            Tools.Files.SaveFileAsString(strPath, strData);
            if (tempHwnd == 0)
            {
                strPath = Tools.FileSystem.GetAppPath() + nTools.GetHighestFileName(Tools.FileSystem.GetAppPath(), "multisearch.exe");
                Tools.FileSystem.Shell(strPath);
            }
            else
            {
                IntPtr i = new IntPtr(tempHwnd);
                //activate it
                ToolsWin.Win32API.ShowWindow(i, ToolsWin.Win32API.SW_RESTORE);
                ToolsWin.Win32API.SetForegroundWindow(i);
            }
        }
        private void clip_OnClipEvent(GenericEvent e)
        {
            ClipHandle(e.Message.ToLower().Trim());
        }

        protected virtual void ClipHandle(String m)
        {
            switch (m)
            {
                case "notes":
                    HomeScreen h = ShowHomeScreen();
                    if (h != null)
                        h.ShowNotes();
                    break;
                case "versionupdate":
                    ShowVersionUpdate();
                    break;
                case "setversion":
                    TheContextNM.xSys.SetHighestVersion(RzWin.Context);
                    xClip.ReShowClip();
                    break;
                case "setminversion":
                    TheContextNM.xSys.SetMinVersion(RzWin.Context);
                    xClip.ReShowClip();
                    break;
                //Refactored from RzSensible
                case "commission_report":
                    Reports.CommissionReport c = new Rz5.Reports.CommissionReport(RzWin.Context);        
                    
                    RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, c, false);
                    break;
                ////KT - Customer Invoice Report
                //case "customer_invoice_report":
                //    Reports.CustomerInvoiceReport cir = new Rz5.Reports.CustomerInvoiceReport(RzWin.Context);
                //    RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, cir, false);
                //    break;
                //KT - Profit Report
                case "profit_report":
                    Reports.ProfitReport pr = new Reports.ProfitReport(RzWin.Context);
                    RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, pr, false);
                    break;
                case "quote_sale_ratio_report":
                    Reports.QuoteToSale r = new Reports.QuoteToSale(RzWin.Context);
                    RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, r, true);
                    break;
                case "cross_reference_report":
                    InventoryCrossRef i = new InventoryCrossRef();
                    i.Init(RzWin.Context);
                    RzWin.Form.TabShow(i, "Cross Reference Report");
                    break;
                case "agent_preferences":
                    agent_preferences ap = new agent_preferences();
                    ap.CompleteLoad();
                    RzWin.Form.TabShow(ap, "Agent Preferences");
                    break;
                    ////KT - Dashboard Link
                    //case "dashboard":
                    //    Dashboard d = new Dashboard();
                    //    RzWin.Form.TabShow(d, "Dashboard");
                    //    break;
                    break;
                case "save_tabs":
                    RzWin.Logic.SaveOpenTabs(RzWin.Context);
                    break;
                case "restore_tabs":
                    RzWin.Logic.OpenRecentTabs(RzWin.Context);
                    break;
            }
        }
        private void ImportUpdates(bool CompleteReplace)
        {
            //String strFolder = RzWin.Leader.AskForString("Folder:", "c:\\", "Folder", this);
            //if (!Tools.Strings.StrExt(strFolder))
            //    return;
            //if (CompleteReplace)
            //{
            //    if (!RzWin.Leader.AreYouSure("completely remove the system's structural information and run the structure update from " + strFolder))
            //        return;
            //}
            //else
            //{
            //    if (!RzWin.Leader.AreYouSure("run the structure update from " + strFolder))
            //        return;
            //}
            //if (!Rz3App.xSys.AbsorbAllUpdateFiles(strFolder, CompleteReplace))
            //    nStatus.TellUserTemp("Absorbing the update filed failed.");
            //else
            //    nStatus.TellUserTemp("Done.");
        }
        //private void ShowThreadSummary()
        //{
        //    ThreadSummary s = new ThreadSummary();
        //    TabPage t = TabShow(s, "Threads");
        //    s.CompleteLoad();
        //}
        private void mnuShowNMI_Click(object sender, EventArgs e)
        {
        }
        private void mnuNormalPermitMode_Click(object sender, EventArgs e)
        {
            RzWin.User.CurrentPermitMode = NewMethod.Enums.PermitMode.Normal;
            UserApply();
        }
        private void mnuAskMissing_Click(object sender, EventArgs e)
        {
            SetPermitMode(NewMethod.Enums.PermitMode.AskIfMissing);
        }
        private void mnuAskAlways_Click(object sender, EventArgs e)
        {
            SetPermitMode(NewMethod.Enums.PermitMode.AskAlways);
        }
        private void mnuPermitTest_Click(object sender, EventArgs e)
        {
            if (RzWin.Context.CheckPermit("System:Test:TestPoint"))
                RzWin.Leader.Tell("Has permission for System:Test:TestPoint");
            else
                RzWin.Leader.Tell("Does not have permission for System:Test:TestPoint");
        }
        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            ShowVersionUpdate();
        }
        private void mnuDepotOptions_Click(object sender, EventArgs e)
        {
            frmDepot.ShowDepotOptions();
        }
        private void mnuTest_Click(object sender, EventArgs e)
        {
        }

        private void mnuUpBoard_Click(object sender, EventArgs e)
        {
            RzWin.Logic.ShowUpBoard(false, this);
        }
        //private void mnuMonitor_Click(object sender, EventArgs e)
        //{
        //    frmMonitor xForm = new frmMonitor();
        //    xForm.Show();
        //}
        private void mnuGC_Click(object sender, EventArgs e)
        {
            try
            {
                SetStatus("Collecting...");
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                SetStatus("Done.");
            }
            catch (Exception)
            {
            }
        }
        private void mnuFormList_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            foreach (Form f in System.Windows.Forms.Application.OpenForms)
            {
                s.AppendLine(f.Name + " " + f.GetType().ToString());
            }
            RzWin.Leader.Tell(s.ToString());
        }
        private void mnuStatus_Click(object sender, EventArgs e)
        {
            SetStatus("Status Test...");
            SetActivityType(ActivityType.Saving);
        }
        private void mnuControlList_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            ListControls(this, sb);
            RzWin.Leader.Tell(sb.ToString());
        }
        private void mnuTeamsAndUsers_Click(object sender, EventArgs e)
        {
            ShowTeamManager();
        }
        private void mnuAddNewChoice_Click(object sender, EventArgs e)
        {
            string s = RzWin.Leader.AskForString("What is the name of this new choice list?", "new_choice_list_001", "Choice List Name");
            if (!Tools.Strings.StrExt(s))
                return;
            n_choices c = TheContextNM.xSys.GetChoicesByName(s);
            if (c != null)
            {
                RzWin.Leader.Tell("The choice list named '" + c.name + "' already exists.");
                return;
            }
            c = n_choices.New(RzWin.Context);
            c.name = s;
            c.Insert(RzWin.Context);
            TheContextNM.xSys.CacheChoices(RzWin.Context);
            TheContextNM.Show(c);
        }
        private void mnuScan_Click(object sender, EventArgs e)
        {
        }
        //private void mnuCone_Click(object sender, EventArgs e)
        //{
        //    nConeView v = new nConeView();
        //    TabPage t = TabShow(v, "Cone");
        //    v.CompleteLoad(TheContextNM.xSys, new nCone());
        //}
        //private void mnuDashboard_Click(object sender, EventArgs e)
        //{
        //    if(!RzWin.Context.CheckPermit("Sales:View:Dashboard"))
        //    {
        //        RzWin.Leader.ShowNoRight();
        //        return;
        //    }
        //    ShowGenericTabControl_CompleteLoad(RzWin.Logic.GetDashboard(), "Dashboard");
        //}
        private void mnuPrintedForms_Click(object sender, EventArgs e)
        {
        }
        //private void mnuThreadSummary_Click(object sender, EventArgs e)
        //{
        //    ShowThreadSummary();
        //}
        private void mnuCauseRTE_Click(object sender, EventArgs e)
        {
            if (!RzWin.User.IsDeveloper())
                return;
            int x = 1;
            x--;
            int y = 5 / x;
            RzWin.Leader.Tell(y.ToString());
        }
        private void mnuDownloadNewVersion_Click(object sender, EventArgs e)
        {
            UpdateDownload d = new UpdateDownload();
            UpdateType t = UpdateType.WebToWorkstation;
            if (RzWin.Context.GetSettingBoolean("use_network_update"))
                t = UpdateType.WebToServer;
            ShowVersionUpdate(t);
        }
        private void mnuUpdateCheck_Click(object sender, EventArgs e)
        {
            tmrUpdate_Tick(null, null);
        }
        //private void mnuImportByClass_Click(object sender, EventArgs e)
        //{
        //    TheContextNM.xSys.ImportByClass();
        //}
        private void mnuBrowserTest_Click(object sender, EventArgs e)
        {
            try
            {
                AxSHDocVw.AxWebBrowser wbx = new AxSHDocVw.AxWebBrowser();
                ((System.ComponentModel.ISupportInitialize)(wbx)).BeginInit();
                wbx.Enabled = true;
                wbx.Location = new System.Drawing.Point(0, 0);
                //wbx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wb.OcxState")));
                wbx.Size = new System.Drawing.Size(552, 474);
                wbx.TabIndex = 0;
                //wbx.BeforeNavigate2 += new AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(this.wb_BeforeNavigate2);
                //wbx.NavigateComplete2 += new AxSHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(wb_NavigateComplete2);
                this.Controls.Add(wbx);
                ((System.ComponentModel.ISupportInitialize)(wbx)).EndInit();
                this.Controls.Remove(wbx);

                RzWin.Leader.Tell("Done.");
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error: " + ex.Message);
            }
        }
        public void CompanyRestoreShow()
        {
            if (!TheContextNM.xSys.Recall)
            {
                RzWin.Leader.Tell("This system isn't set up for Recall.");
                return;
            }
            ArrayList companies = frmRecallRestore_Company.AskRecallRestore_Company(TheContextNM, RzWin.Context.Connection, RzWin.Context.Sys.RecallConnection);
            if (companies == null)
                return;
            if (companies.Count <= 0)
                return;
            string insert = "";
            foreach (company c in companies)
            {
                string s = RzWin.Context.SelectScalarString("select unique_id from company where unique_id = '" + c.unique_id + "'");
                if (!Tools.Strings.StrExt(s))
                {
                    if (Tools.Strings.StrExt(insert))
                        insert += ",'" + c.unique_id + "'";
                    else
                        insert += "'" + c.unique_id + "'";
                }
                else
                {
                    RzWin.Context.TheLeader.Error("The company with UID " + c.unique_id + " already exists in the company list");
                }
            }
            if (!Tools.Strings.StrExt(insert))
                return;
            DataTable st = RzWin.Context.Sys.RecallConnection.Select("select top 1 * from company");
            CoreClassHandle h = RzWin.Context.Sys.CoreClassGet("company");
            String strSQL = "";
            ArrayList a = new ArrayList();
            foreach (CoreVarValAttribute v in h.VarValsGet())
            {
                List<Field> fields = new List<Field>();
                v.FieldsAppend(fields);
                foreach (Field f in fields)
                {
                    //only restore fields that exist in the backup
                    if (nData.HasField(st, f.Name))
                    {
                        if (!nTools.IsInArray(f.Name, a))
                        {
                            if (Tools.Strings.StrExt(strSQL))
                                strSQL += ", ";
                            strSQL += f.Name;
                            a.Add(f.Name);
                        }
                    }
                }
            }
            //KT - 11-13-2014 - Again, on the insert, it's making sure recall type = 3, which is odd.  All the companies I delete are recall type 1.
            //Rz Code
            string where = RzWin.Context.Sys.RecallConnection.DatabaseName + ".dbo.company.unique_id in (" + insert + ") and recall_type = 3";  //the recall type wasn't there before, so it was restoring every instance of the company being changed
            //KT Code
            //string where = RzWin.Context.Sys.RecallConnection.DatabaseName + ".dbo.company.unique_id in (" + insert + ") and recall_type = 1";
            strSQL = "insert into " + RzWin.Context.Connection.DatabaseName + ".dbo.company(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from company where " + where + " order by recall_date desc";  //added top 1, because with restoration, there can be multiple delete records
            RzWin.Context.Sys.RecallConnection.Execute(strSQL);
            //show the first 3
            int cx = 0;
            foreach (company coriginal in companies)
            {
                company crestore = company.GetById(RzWin.Context, coriginal.unique_id);
                if (crestore != null)
                    TheContextNM.Show(crestore);

                cx++;
                if (cx > 3)
                    break;
            }

            RzWin.Leader.Tell("Done.");
        }
        private void mnuRestoreExportTemplate_Click(object sender, EventArgs e)
        {
            RestoreObject("exporttemplate");
        }
        void RestoreObject(String strClass)
        {
            RzWin.Context.Reorg();
            //if (!TheContextNM.xSys.Recall)
            //{
            //    RzWin.Leader.Tell("This system isn't set up for Recall.");
            //    return;
            //}
            //string strNumber = RzWin.Leader.AskForString(strClass + " ID?", "", "ID", this);
            //if (!Tools.Strings.StrExt(strNumber))
            //    return;
            //string strSQL = "select unique_id from " + strClass + " where unique_id = '" + strNumber + "'";
            //string s = TheContextNM.xSys.xData.GetScalar(strSQL, "");
            //if (Tools.Strings.StrExt(s))
            //{
            //    RzWin.Leader.Tell("This " + strClass + " already appears to exist in the main database.");
            //    return;
            //}
            //s = TheContextNM.xSys.recall_connection.GetScalar(strSQL, "");
            //if (!Tools.Strings.StrExt(s))
            //{
            //    RzWin.Leader.Tell("This " + strClass + " wasn't found in the Recall system.");
            //    return;
            //}
            //DataTable st = TheContextNM.xSys.recall_connection.Select("select top 1 * from " + strClass + " ");
            //SortedList props = TheContextNM.xSys.GetPropsByClass(strClass);
            //strSQL = "";
            //ArrayList a = new ArrayList();
            //foreach (DictionaryEntry d in props)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    //only restore fields that exist in the backup
            //    if (!p.IsUniqueID)
            //    {
            //        if (nData.HasField(st, p.name))
            //        {
            //            if (!nTools.IsInArray(p.name, a))
            //            {
            //                if (Tools.Strings.StrExt(strSQL))
            //                    strSQL += ", ";
            //                strSQL += p.name;
            //                a.Add(p.Name);
            //            }
            //        }
            //    }
            //}
            //strSQL = "insert into " + TheContextNM.xSys.xData.database_name + ".dbo." + strClass + "(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from " + strClass + " where unique_id = '" + s + "' and recall_type = 3";
            //if (TheContextNM.xSys.recall_connection.Execute(strSQL))
            //{
            //    TheContextNM.xSys.ThrowByKey(strClass + ":" + s);
            //    RzWin.Leader.Tell("Done.");
            //}
            //else
            //{
            //    RzWin.Leader.Tell("The restore was not successful.");
            //}
        }
        protected virtual void LoadDutyMonitor()
        {
            ShowGenericTabControl_CompleteLoad(new DutyMonitor(), "Duty Monitor");
        }
        public void ContactRestoreShow()
        {
            RzWin.Context.Reorg();

            //if (!TheContextNM.xSys.Recall)
            //{
            //    RzWin.Leader.Tell("This system isn't set up for Recall.");
            //    return;
            //}
            //string strNumber = RzWin.Leader.AskForString("Contact ID?", "", "ID", this);
            //if( !Tools.Strings.StrExt(strNumber) )
            //    return;
            //string strSQL = "select unique_id from companycontact where unique_id = '" + strNumber + "'";
            //string s = TheContextNM.xSys.xData.GetScalar(strSQL, "");
            //if(Tools.Strings.StrExt(s))
            //{
            //    RzWin.Leader.Tell("This contact already appears to exist in the main database.");
            //    return;
            //}
            //s = TheContextNM.xSys.recall_connection.GetScalar(strSQL, "");
            //if(!Tools.Strings.StrExt(s))
            //{
            //    RzWin.Leader.Tell("This contact wasn't found in the Recall system.");
            //    return;
            //}
            //DataTable st = TheContextNM.xSys.recall_connection.Select("select top 1 * from companycontact");
            //SortedList props = TheContextNM.xSys.GetPropsByClass("companycontact");
            //strSQL = "";
            //ArrayList a = new ArrayList();
            //foreach(DictionaryEntry d in props)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    //only restore fields that exist in the backup
            //    if(!p.IsUniqueID)
            //    {
            //        if(nData.HasField(st, p.name))
            //        {
            //            if(!nTools.IsInArray(p.name, a))
            //            {
            //                if( Tools.Strings.StrExt(strSQL) )
            //                    strSQL += ", ";
            //                strSQL += p.name;
            //                a.Add(p.Name);
            //            }
            //        }
            //    }
            //}
            //strSQL = "insert into " + TheContextNM.xSys.xData.database_name + ".dbo.companycontact(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from companycontact where unique_id = '" + s + "' and recall_type = 3";
            //if (TheContextNM.xSys.recall_connection.Execute(strSQL))
            //{
            //    TheContextNM.xSys.ThrowByKey("companycontact:" + s);
            //    RzWin.Leader.Tell("Done.");
            //}
            //else
            //{
            //    RzWin.Leader.Tell("The restore was not successful.");
            //}
        }
        private void mnuVersion12_Click(object sender, EventArgs e)
        {
            string s = nTools.GetHighestFileName(Tools.FileSystem.GetAppPath(), "rz3_old.exe");
            string strFile = Tools.FileSystem.GetAppPath() + s;
            if (!System.IO.File.Exists(strFile))
            {
                TheContextNM.TheLeader.TellTemp("Version 12 of Rz3 doesn't appear to be installed: " + strFile);
                return;
            }
            Tools.FileSystem.Shell(strFile);
        }
        private void mnuEmailTemplates_Click(object sender, EventArgs e)
        {
            ShowGenericTabControl_CompleteLoad(new EmailTemplates(), "Email Templates");
        }
        private void mnuUserActivity_Click(object sender, EventArgs e)
        {
            ShowGenericTabControl_CompleteLoad(new ActivityReport(), "Activity Report");
        }
        //private void mnuAlternateAvailServer_CheckedChanged(object sender, EventArgs e)
        //{
        //    RzWin.Context.SetSettingBoolean("alternate_avail_server", mnuAlternateAvailServer.Checked);
        //}
        private void mnuUpdateCheckAdd_Click(object sender, EventArgs e)
        {
            ImportUpdates(false);
        }
        private void mnuUpdateReplace_Click(object sender, EventArgs e)
        {
            ImportUpdates(true);
        }
        private void mnuDutyMonitor_Click(object sender, EventArgs e)
        {
            LoadDutyMonitor();
        }
        private void mnuCompanyImport_Click(object sender, EventArgs e)
        {
        }
        private void mnuOrderImport_Click(object sender, EventArgs e)
        {
        }
        private void mnuPartMatching_Click(object sender, EventArgs e)
        {
            if (!RzWin.User.SuperUser)
            {
                RzWin.Leader.ShowNoRight();
                return;
            }
            ShowGenericTabControl_CompleteLoad(new PartMatching(), "Part Matching");
        }
        private void mnuOrderImport_General_Click(object sender, EventArgs e)
        {
            if (!RzWin.User.SuperUser)
            {
                RzWin.Leader.ShowNoRight();
                return;
            }
            ShowGenericTabControl_CompleteLoad(new OrderImport(), "Order Import");
        }
        //private void mnuOrderImport_SDS_Click(object sender, EventArgs e)
        //{
        //    n_data_target t = frmDataSources.Choose(this, TheContextNM.xSys);
        //    if( t == null )
        //        return;
        //    PreDefinedImports.ImportInvoicesFromSDS(TheContextNM, t);
        //    PreDefinedImports.ImportPOsFromSDS(TheContextNM, t);
        //}
        //private void mnuCompanyImport_SDS_Click(object sender, EventArgs e)
        //{
        //    n_data_target t = frmDataSources.Choose(this, TheContextNM.xSys);
        //    if( t == null )
        //        return;
        //    PreDefinedImports.ImportCompaniesFromSDS(TheContextNM, t);
        //}
        private void mnuCompanyImport_General_Click(object sender, EventArgs e)
        {
            //if(!Rz3App.xUser.SuperUser)
            //{
            //    RzWin.Leader.ShowNoRight();
            //    return;
            //}
            //ShowGenericTabControl_CompleteLoad(new CompanyImport(), "Company Import");
        }
        private void mnuReqManager_Click(object sender, EventArgs e)
        {
            //ShowReqManager();
        }
        private void mnuAllReminders_Click(object sender, EventArgs e)
        {
            ShowAllReminderTab();
        }
        //private void mnuImportHTCompanies_Click(object sender, EventArgs e)
        //{
        //    n_data_target t = frmDataSources.Choose(this, TheContextNM.xSys);
        //    if( t == null )
        //        return;
        //    PreDefinedImports.ImportCompaniesFromHT(TheContextNM, t);
        //}
        //private void fromSolomonToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    n_data_target t = frmDataSources.Choose(this, TheContextNM.xSys);
        //    if( t == null )
        //        return;
        //    PreDefinedImports.ImportCompaniesFromSolomon(TheContextNM, t);
        //}
        private void mnuTestNotificationEmail_Click(object sender, EventArgs e)
        {
            nEmailMessage m = new nEmailMessage();
            m.ToAddress = "test@recognin.com";
            m.ToName = "test";
            m.Subject = "test";
            RzWin.Logic.SetFromNotification(m);
            string s = "";
            if (m.Send(ref s))
                RzWin.Leader.Tell("Test message sent.");
            else
                RzWin.Leader.Tell("Test failed: " + s);
        }
        private void mnuDesignPrintedForms_Click(object sender, EventArgs e)
        {
            ShowGenericTabControl_CompleteLoad(new PrintedForms(), "Printed Forms");
        }
        private void mnuImportPrintedForms_Click(object sender, EventArgs e)
        {
            printheader p = printheader.ImportFromExcel(TheContextNM, this);
            if (p != null)
                TheContextNM.Show(p);
        }
        //private void mnuExcelSplit_Click(object sender, EventArgs e)
        //{
        //    string s = ToolsWin.FileSystem.ChooseAFile(this);
        //    if( !Tools.Strings.StrExt(s) )
        //        return;
        //    ToolsOffice.ExcelOffice.Split(s);
        //    TheContextNM.TheLeader.TellTemp("Done.");
        //}
        //private void mnuCustomExports_Click(object sender, EventArgs e)
        //{
        //    if(!RzWin.Context.CheckPermit("Inventory:Exports:CustomExport"))
        //    {
        //        RzWin.Leader.ShowNoRight();
        //        return;
        //    }
        //    ExportInventory export;
        //    Control c = TabCheckShow("exportinventory");
        //    if( c != null )
        //        return;
        //    ShowGenericTabControl_CompleteLoad(new ExportInventory(), "Export Inventory");
        //}
        private void mnuContactImport_Click(object sender, EventArgs e)
        {
            if (!RzWin.User.SuperUser)
            {
                RzWin.Leader.ShowNoRight();
                return;
            }
            ShowGenericTabControl_CompleteLoad(new ContactImport(), "Contact Import");
        }
        //private void mnuInitPictures_Click(object sender, EventArgs e)
        //{
        //    RzWin.Context.Execute("alter table partpicture add picturedata image");
        //    RzWin.Context.Execute("alter table filelink add picturedata image");
        //    RzWin.Leader.Tell("Done.");
        //}
        //private void mnuCompleteOEMEmailList_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.PopCompleteOEMEmailList();
        //}
        //private void mnuMarketingBatches_Click(object sender, EventArgs e)
        //{
        //}
        //private void mnuIncompleteEmailReport_Company_Click(object sender, EventArgs e)
        //{
        //    ShowHTML(RzWin.Logic.GetIncompleteEmailReport_Company(), "Incomplete Email Addresses - By Company");
        //}
        //private void mnuIncompleteEmailReportContact_Click(object sender, EventArgs e)
        //{
        //    ShowHTML(RzWin.Logic.GetIncompleteEmailReport_Contact(), "Incomplete Email Addresses - By Contact");
        //}
        //private void mnuPDAExport_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.RunPDAExport();
        //}
        //private void mnuDateModified_Click(object sender, EventArgs e)
        //{
        //    n_sys s = TheContextNM.xSys;
        //    RzWin.Leader.StartPopStatus();
        //    SortedList classes = s.CoalesceUniqueClasses();
        //    nStatus.StartPercent(classes.Count);
        //    //if(Rz3App.xLogic.IsPMT)
        //    //{
        //    //    n_class part = s.GetClassByName("partrecord");
        //    //    n_class offer = (n_class)part.CloneWithNewID();
        //    //    n_class archive = (n_class)part.CloneWithNewID();
        //    //    if(offer != null)
        //    //    {
        //    //        offer.class_name = "partrecord_offer";
        //    //        classes.Add("partrecord_offer", offer);
        //    //    }
        //    //    if(archive != null)
        //    //    {
        //    //        archive.class_name = "partrecord_archive";
        //    //        classes.Add("partrecord_archive", archive);
        //    //    }
        //    //}
        //    foreach(DictionaryEntry d in classes)
        //    {
        //        n_class c = (n_class)d.Value;
        //        RzWin.Leader.Comment("Checking " + c.class_name);
        //        if(s.xData.FieldExists(c.class_name, "date_modified"))
        //        {
        //            if(!s.xData.IsDateField(c.class_name, "date_modified"))
        //            {
        //                RzWin.Leader.Comment("Changing date_modified on " + c.class_name + "...");
        //                s.xData.Execute("alter table " + c.class_name + " drop column date_modified");
        //                s.xData.Execute("alter table " + c.class_name + " add date_modified datetime");
        //            }
        //        }
        //        if(s.Recall)
        //        {
        //            RzWin.Leader.Comment("Checking Recall " + c.class_name);
        //            if(s.recall_connection.FieldExists(c.class_name, "date_modified"))
        //            {
        //                if(!s.recall_connection.IsDateField(c.class_name, "date_modified"))
        //                {
        //                    RzWin.Leader.Comment("Changing recall date_modified on " + c.class_name + "...");
        //                    s.recall_connection.Execute("alter table " + c.class_name + " drop column date_modified");
        //                    s.recall_connection.Execute("alter table " + c.class_name + " add date_modified datetime");
        //                }
        //            }
        //        }
        //        nStatus.AddPercent();
        //    }
        //    RzWin.Leader.Comment("Done.");
        //    RzWin.Leader.StopPopStatus(true);
        //}
        //private void mnuUpdateClass_Click(object sender, EventArgs e)
        //{
        //    string strClass = RzWin.Leader.AskForString("Class name:", "ordhed", "Class", this);
        //    if( !Tools.Strings.StrExt(strClass) )
        //        return;
        //    string strSQL = nStatus.InputMessageBoxMultiLine("SQL:", "select * from " + strClass, "SQL", this);
        //    if( !Tools.Strings.StrExt(strClass) )
        //        return;
        //    RzWin.Leader.StartPopStatus();
        //    RzWin.Leader.Comment("Selecting data...");
        //    DataTable d = TheContextNM.RzWin.Context.Select(strSQL);
        //    if(!Tools.Data.DataTableExists(d))
        //    {
        //        RzWin.Leader.Comment("No records.");
        //        RzWin.Leader.StopPopStatus();
        //        return;
        //    }
        //    if(!RzWin.Leader.AreYouSure("continue saving " + Tools.Number.LongFormat(d.Rows.Count) + " items"))
        //    {
        //        RzWin.Leader.Comment("No records.");
        //        RzWin.Leader.StopPopStatus();
        //        return;
        //    }
        //    nStatus.StartPercent(d.Rows.Count);
        //    foreach(DataRow r in d.Rows)
        //    {
        //        nObject x = TheContextNM.xSys.MakeObject(strClass);
        //        x.ICreate(TheContextNM.xSys, r);
        //        x.ISave();
        //        System.Windows.Forms.Application.DoEvents();
        //        System.Windows.Forms.Application.DoEvents();
        //        System.Windows.Forms.Application.DoEvents();

        //        RzWin.Leader.Comment("Saved " + x.ToString());
        //        nStatus.AddPercent();
        //    }
        //    RzWin.Leader.Comment("Done.");
        //    RzWin.Leader.StopPopStatus(true);
        //}
        //private void mnuCompleteEmailList_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.PopCompleteEmailList();
        //}
        //private void mnuSetSetting_Click(object sender, EventArgs e)
        //{
        //    string strName = RzWin.Leader.AskForString("Setting name", "", "Name", this);
        //    if( !Tools.Strings.StrExt(strName) )
        //        return;
        //    string strValue = nStatus.InputMessageBoxMultiLine("Setting value", "", "Value", this);
        //    if( !RzWin.Leader.AreYouSure("Set the " + strName + " setting = '" + strValue + "'") )
        //        return;
        //    TheContextNM.SetSetting(strName, strValue);
        //    TheContextNM.TheLeader.TellTemp("Done.");
        //}
        //private void mnuStat_Click(object sender, EventArgs e)
        //{
        //    string strFile = nTools.GetHighestFileName(Tools.FileSystem.GetAppPath(), "StatLoader.exe");
        //    if(Tools.Strings.StrExt(strFile))
        //    {
        //        string strUser = "";
        //        if(RzWin.User.IsDeveloper())
        //        {
        //            if( Tools.Strings.StrExt(RzWin.Logic.DefaultAgentName) )
        //                strUser = RzWin.Logic.DefaultAgentName;
        //            else
        //                strUser = RzWin.User.name;
        //        }
        //        else
        //            strUser = RzWin.User.name;
        //        Tools.FileSystem.Shell(strFile, " user=" + strUser + " password=<ok>");
        //    }
        //}
        //private void mnuBuyReport_Click(object sender, EventArgs e)
        //{
        //    if(!RzWin.Context.CheckPermit("Stock:View:HoldingAreaReport"))
        //    {
        //        RzWin.Leader.ShowNoRight();
        //        return;
        //    }
        //    ShowHTML(RzWin.Logic.GetBuyReportHTML(), "Holding Area Report");
        //}
        public void ChatWithSomeone()
        {
            bool b = true;
            if (((ContextRz)RzWin.Context).xHook == null)
                b = false;
            if (b)
            {
                if (!((ContextRz)RzWin.Context).xHook.IsConnected())
                    b = false;
            }
            if (!b)
            {
                TheContextNM.TheLeader.TellTemp("The chat system doesn't appear to be available.");
                return;
            }
            ((ContextRz)RzWin.Context).xHook.ShowChatListDetails = (RzWin.User.IsDeveloper() && ToolsWin.Keyboard.GetControlKey());
            ((ContextRz)RzWin.Context).xHook.RequestChatList();
        }
        private void mnuDevelopEmails_Click(object sender, EventArgs e)
        {
            TabShow(new nEmails(), "Emails");
        }
        private void mnuMailingLists_Click(object sender, EventArgs e)
        {
        }
        private void mnuAskIfMissingOrBlocked_Click(object sender, EventArgs e)
        {
            SetPermitMode(NewMethod.Enums.PermitMode.AskIfMissingOrBlocked);
        }
        private void mnuImportGraphic_Click(object sender, EventArgs e)
        {
            string s = ToolsWin.FileSystem.ChooseAFile();
            if (!System.IO.File.Exists(s))
                return;
            string n = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath() + "Graphics\\" + Path.GetFileName(s));
            try
            {
                System.IO.File.Copy(s, n);
                TheContextNM.TheLeader.TellTemp("Done.");
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error: " + ex.Message);
            }
        }
        //private void mnuChatServer_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmRzTieServer.CheckStartTieServer(TheContextNM.xSys);
        //    }
        //    catch
        //    {
        //    }
        //}
        //private void mnuChatHookMonitor_Click(object sender, EventArgs e)
        //{
        //    if (((ContextRz)RzWin.Context).xHook == null)
        //    {
        //        RzWin.Leader.Tell("The chat system doesn't appear to be connected.");
        //        return;
        //    }
        //    ((ContextRz)RzWin.Context).xHook.ShowStatus();
        //}
        //private void mnuInternalSearchReport_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.ShowInternalSearchReport(this);
        //}
        //private void mnuSetTieServer_Click(object sender, EventArgs e)
        //{
        //    string s = RzWin.Leader.AskForString("Tie Server", RzHook.GetTieServerName(RzWin.Context), "Tie Server", this);
        //    if( !Tools.Strings.StrExt(s) )
        //        return;
        //    RzWin.User.SetSetting("tie_server_name", s);
        //}
        //private void mnuKnowlegeBase_Click(object sender, EventArgs e)
        //{
        //    ShowHelpSite();
        //}
        //public void ShowHelpSite()
        //{
        //    try
        //    {
        //        Browser b = new Browser();
        //        b.ShowControls = true;
        //        Rz3App.xMainForm.TabShow(b, "Welcome");
        //        b.Navigate("http://www.recognin.com/Rz3/Docs/");
        //    }
        //    catch
        //    {
        //    }
        //}
        private void mnuCommonSettings_Click(object sender, EventArgs e)
        {
            ShowGenericTabControl_CompleteLoad(new SettingsPanel(), "Common Settings");
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }
        //private void completeEmailListToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.PopInvalidEmailList(false);
        //}
        //private void oEMEmailListToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.PopInvalidEmailList(true);
        //}
        private void mnuQuickbooks_Click(object sender, EventArgs e)
        {
            ShowQuickBench();
        }
        void ShowQuickBench()
        {
            ShowGenericTabControl_CompleteLoad(((LeaderWinUserRz)RzWin.Context.TheLeaderRz).GetQuickBench(), "Quickbooks Settings");
        }
        private void frmRecogniz_KeyPress(object sender, KeyPressEventArgs e)
        {
            //switch (e.KeyChar)
            //{
            //    case '\r':
            //        this.Text = "Enter " + System.DateTime.Now.ToString();
            //        break;
            //    case '\n':
            //        this.Text = "Enter " + System.DateTime.Now.ToString();
            //        break;
            //}
        }
        private void frmRecogniz_KeyUp(object sender, KeyEventArgs e)
        {
            switch ((Int32)e.KeyCode)
            {
                case (Int32)System.Windows.Forms.Keys.F1:
                    e.Handled = true;
                    UpdateCheck();
                    break;
                case (Int32)System.Windows.Forms.Keys.F2:
                    e.Handled = true;
                    UpdateCheck(true);
                    break;
                    //case 10:
                    //    RzWin.Leader.Tell("return");
                    //    break;
                    //case 13:
                    //    RzWin.Leader.Tell("return");
                    //    break;
            }
            //if(Rz3App.xLogic.IsPMT)
            //{
            //    if((Int32)e.KeyCode == (Int32)System.Windows.Forms.Keys.F8)
            //    {
            //        PartSearch ps = (PartSearch)TabCheckShow("partsearch");
            //        if( ps == null )
            //            return;
            //        ps.HandleCommand("showsupplierinfo");
            //    }
            //}
        }
        private void frmRecogniz_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void frmRecogniz_FormClosed(object sender, FormClosedEventArgs e)
        {
            DoFormClosed();
        }
        public virtual void DoFormClosed()
        {
            try
            {
                ////nStatus.UnRegisterStatusView(this);
                frmRzTieServer.StopTieServer();
                RzWin.Logic.StopHook(RzWin.Context);
            }
            catch (Exception)
            {
            }
        }
        private void tmrQuick_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    tmrQuick.Stop();
            //    if(ShowClip)
            //    {
            //        ShowClip = false;
            //        clip.ShowClip(Rz3App.xUser.RootClip);
            //    }
            //}
            //catch
            //{
            //}
        }
        private void tmrClearStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                if (CurrentActivityType != ActivityType.None)
                    return;
                TimeSpan t = System.DateTime.Now.Subtract(LastActivity);
                if (t.TotalSeconds > 5)
                    SetStatus("");
            }
            catch
            {
            }
        }
        private void tmrNotes_Tick(object sender, EventArgs e)
        {
            try
            {
                CheckNotes();
            }
            catch
            {
            }
        }
        private void n_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem t = (ToolStripMenuItem)sender;
                n_choices c = (n_choices)t.Tag;
                TheContextNM.Show(c);
            }
            catch (Exception)
            {
            }
        }
        protected override void NavigateHandle(GenericEvent e)
        {
            RzWin.Context.TheSysRz.TheUrlLogic.NavigateHandle(RzWin.Context, e);
            if (e.Handled)
                return;

            base.NavigateHandle(e);
        }
        //private void mnuClassFieldList_Click(object sender, EventArgs e)
        //{
        //    string s = RzWin.Leader.AskForString("Class?", "ordhed_invoice", "Class", this);
        //    n_class c = TheContextNM.xSys.GetClassByName(s);
        //    if(c == null)
        //    {
        //        RzWin.Leader.Tell("Class '" + s + "' wasn't found.");
        //        return;
        //    }
        //    SortedList sa = c.CoalesceProps();
        //    StringBuilder sb = new StringBuilder("unique_id");
        //    foreach(DictionaryEntry d in sa)
        //    {
        //        n_prop p = (n_prop)d.Value;
        //        if( !p.IsUniqueID )
        //            sb.Append(", " + p.name);
        //    }
        //    Tools.FileSystem.PopText(sb.ToString());
        //}
        //private void mnuContactGroups_Click(object sender, EventArgs e)
        //{
        //    companycontact.ShowGroups(TheContextNM);
        //}
        private void mnuPanelView_Click(object sender, EventArgs e)
        {
            ShowPanel();
        }
        private void mnuUpgradePro_Click(object sender, EventArgs e)
        {
            ShowUpgradeToPro();
        }
        private void mnuUpgradeToPro2_Click(object sender, EventArgs e)
        {
            ShowUpgradeToPro();
        }
        private void mnuUpgradeToPro3_Click(object sender, EventArgs e)
        {
            ShowUpgradeToPro();
        }
        private void frmRecogniz_FormClosing(object sender, FormClosingEventArgs e)
        {
            RzWin.Logic.SaveOpenTabs(RzWin.Context);
        }
        private void mnuPurchase_Click(object sender, EventArgs e)
        {
            RzWin.Form.ShowUpgradeToPro();
        }
        private void mnuTools_Click(object sender, EventArgs e)
        {
            nToolsView v = new nToolsView();
            TabShow(v, "Tools");
            v.CompleteLoad(TheContextNM.xSys);
        }
        private void mnuStats_Click(object sender, EventArgs e)
        {
        }
        private void mnuQBSettings_Click(object sender, EventArgs e)
        {
            ShowGenericTabControl_CompleteLoad(((LeaderWinUserRz)RzWin.Context.TheLeaderRz).GetQuickBench(), "Quickbooks Interface Settings");
        }
        private void mnuCheckNotes_Click(object sender, EventArgs e)
        {
            RzWin.Leader.StartPopStatus("Checking notes...");
            if (tmrNotes.Enabled)
                RzWin.Leader.Comment("Auto checking is enabled.");
            else
                RzWin.Leader.Comment("Auto checking is not enabled.");
            CheckNotes(true);
            RzWin.Leader.StopPopStatus(true);
        }
        //private void mnuVirtualFloors_DropDownOpening(object sender, EventArgs e)
        //{
        //    ArrayList remove = new ArrayList();
        //    foreach(ToolStripItem i in mnuVirtualFloors.DropDownItems)
        //    {
        //        if( i.Text != "<add new>" )
        //            remove.Add(i);
        //    }
        //    foreach(ToolStripItem i in remove)
        //    {
        //        mnuVirtualFloors.DropDownItems.Remove(i);
        //    }
        //    ArrayList a = Rz3App.SelectScalarArray("select distinct(name) from virtual_floor where isnull(name, '') > '' order by name");
        //    foreach(string s in a)
        //    {
        //        ToolStripItem i = mnuVirtualFloors.DropDownItems.Add(s);
        //        i.Tag = s;
        //        i.Click += new EventHandler(i_Click);
        //    }
        //}
        //void i_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ToolStripItem i = (ToolStripItem)sender;
        //        string s = (string)i.Tag;
        //        virtual_floor f = virtual_floor.GetByName(TheContextNM.xSys, s);
        //        if(f != null)
        //        {
        //            ShowVirtualFloor(f);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        //void ShowVirtualFloor(virtual_floor f)
        //{
        //    VirtualFloor.VirtualFloor vf = new VirtualFloor.VirtualFloor();
        //    TabShow(vf, f.name);
        //    vf.CompleteLoad(f);
        //}
        //private void mnuAddNewFloor_Click(object sender, EventArgs e)
        //{
        //    string strName = RzWin.Leader.AskForString("New Floor Name", "New Floor 1", "Name", this);
        //    if( !Tools.Strings.StrExt(strName) )
        //        return;
        //    virtual_floor f = virtual_floor.GetByName(TheContextNM.xSys, strName);
        //    if(f != null)
        //    {
        //        RzWin.Leader.Tell("The floor '" + strName + "' already exists.");
        //        return;
        //    }
        //    f = new virtual_floor(TheContextNM.xSys);
        //    f.name = strName;
        //    f.ISave();
        //    ShowVirtualFloor(f);
        //}
        public void RefreshInbox()
        {
            vp.ShowInboxInfo();
        }
        public void ShowFocusInbox()
        {
            Control u = TabCheckShow("inboxitems");
            if (u != null)
            {
                try
                {
                    Focus.FocusItems fi = (Focus.FocusItems)u;
                    fi.CompleteLoad();
                }
                catch
                {
                }
                return;
            }
            Focus.FocusItems f = new Focus.FocusItems();
            TabShow(f, "Inbox Items");
            f.CompleteLoad();
        }
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        private void mnuTurnOffCapsLock_Click(object sender, EventArgs e)
        {
            try
            {
                uint KEYEVENTF_EXTENDEDKEY = 1;
                uint KEYEVENTF_KEYUP = 2;
                keybd_event(20, 69, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(20, 69, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            catch
            {
            }
        }
        private void mnuCleanExecFolder_Click(object sender, EventArgs e)
        {
            ArrayList a = new ArrayList();
            string[] files = Directory.GetFiles(Tools.FileSystem.GetAppPath());
            foreach (string s in files)
            {
                string name = Path.GetFileName(s).ToLower();
                string ext = Path.GetExtension(s);
                switch (ext.ToLower())
                {
                    case ".exe":
                    case ".exez":
                    case ".dll":
                    case ".dllz":
                    case ".application":
                    case ".manifest":
                        if (name.StartsWith("rz3__"))
                            a.Add(s);
                        else if (name.StartsWith("rz3_common__"))
                            a.Add(s);
                        else if (name.StartsWith("newmethod__"))
                            a.Add(s);
                        else if (name.StartsWith("ilsupload__"))
                            a.Add(s);
                        else if (name.StartsWith("rz3_ctg__"))
                            a.Add(s);
                        else if (name.StartsWith("tie__"))
                            a.Add(s);
                        break;
                }
            }
            if (a.Count == 0)
            {
                RzWin.Leader.Tell("No files to clean.");
                return;
            }
            if (!RzWin.Leader.AreYouSure("Remove " + Tools.Number.LongFormat(a.Count) + " " + nTools.Pluralize("file", a.Count)))
                return;
            int done = 0;
            int skipped = 0;
            RzWin.Leader.StartPopStatus("Cleaning...");
            foreach (string s in a)
            {
                try
                {
                    System.IO.File.Delete(s);
                    done++;
                }
                catch
                {
                    skipped++;
                }
            }
            RzWin.Leader.Comment("Done: " + done.ToString() + " removed, " + skipped.ToString() + " skipped.");
            RzWin.Leader.StopPopStatus(true);
        }
        //private void mnuTestNoteHandling_Click(object sender, EventArgs e)
        //{
        //    usernote u = new usernote(TheContextNM.xSys);
        //    u.shouldpopup = false;
        //    u.notetext = "test";
        //    u.is_pending = false;
        //    u.ISave();
        //    for(int i = 0 ; i < 100 ; i++)
        //    {
        //        Form f = u.ShowInWindow((ContextRz)TheContext, this);
        //        System.Threading.Thread.Sleep(500);
        //        System.Windows.Forms.Application.DoEvents();
        //        System.Windows.Forms.Application.DoEvents();
        //        System.Windows.Forms.Application.DoEvents();
        //        System.Windows.Forms.Application.DoEvents();
        //        f.Close();
        //        f.Dispose();
        //        f = null;
        //    }
        //}
        public override void SetActivityType(ActivityType t)
        {
            vp.SetActivityType(t);
        }
        private void mnuTabStack_Click(object sender, EventArgs e)
        {
            ShowTabStack();
        }
        //private void mnuNonVendorEmails_Click(object sender, EventArgs e)
        //{
        //    RzWin.Logic.PopCompleteNonVendorEmailList();
        //}
        private void mnuSettingsViewAll_Click(object sender, EventArgs e)
        {
            nList l = new nList();
            TabShow(l, "All Settings");
            l.AllowAdd = true;
            l.AddCaption = "Add A New Setting";
            l.ShowTemplate("allsettings", "n_set");
            l.ShowData("n_set", "", "name");

        }
        private void topCustomerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopCustomersReport t = new TopCustomersReport();
            t.CompleteStructure();
            TabShow(t, "Top Customers");
        }
        public void UpdateCheckingStart()
        {
            tmrUpdate.Start();
            bgUpdate.RunWorkerAsync();  //kick it off once right away
        }
        public void UpdateCheckingStop()
        {
            tmrUpdate.Stop();
        }
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (bgUpdate.IsBusy)
                return;

            tmrUpdate.Stop();
            vp.ExtraShow(il24.Images["Import"], "Checking for new Rz versions...");
            bgUpdate.RunWorkerAsync();
        }
        protected void UpdateCheck(bool startNewVersionIfAvailable = false)
        {
            try
            {
                UpdateDownload d = new UpdateDownload();
                String strEULA = GetEULA();
                String folder = GetUpdateCheckFolder();
                UpdateType t = UpdateType.WebToWorkstation;
                if (RzWin.Context.GetSettingBoolean("use_network_update"))
                    t = UpdateType.ServerToWorkstation;
                UpdateDownloadCore c = new UpdateDownloadCore();
                c.Init(TheContextNM, t, strEULA, folder, false);

                bool update_success = c.RunUpdate(RzWin.Context, false, false, false);

                String status = "";
                if (c.NewVersionDownloaded(ref status))
                {
                    NewVersionAvailable(c, startNewVersionIfAvailable);
                }
            }
            catch { }
        }

        protected virtual void NewVersionAvailable(UpdateDownloadCore c, bool startNewVersionIfAvailable)
        {
            startTab.ShowUpdateIcon();
        }

        protected void StartNewVersion(UpdateDownloadCore c)
        {
            c.OpenLatestVersion();
            CompleteClose();
        }

        protected virtual string GetUpdateCheckFolder()
        {
            return RzWin.Context.Sys.Name;
        }
        private void bgUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateCheck();
        }
        private void bgUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrUpdate.Start();
            vp.ExtraHide();
        }
        private void chatMessageSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatMessageSearch t = new ChatMessageSearch();
            t.Init();
            TabShow(t, "Message Search");
        }
        private void mnuImportFromQBs_Click(object sender, EventArgs e)
        {
            ImportFromQBs qb = new ImportFromQBs();
            qb.CompleteLoad();
            TabShow(qb, "Import from Quickbooks");
        }
        public void OrderLinkWorkbenchShow()
        {
            TabShow(new Win.Screens.OrderLinkWorkBench(), "Order Link Workbench");
        }
        private void frmRecogniz_Load(object sender, EventArgs e)
        {
            //this was keeping the form from opening in the designer
            if (RzWin.Context == null)
                return;

            if (RzWin.Context.Sys.ProofLogic.InProveMode)
                RunTests();
        }
    }
    public interface IPartSearch
    {
        //event ShowHandler AboutToThrow;
        void CompleteLoad();
        void SetPartNumber(String strPartNumber);
        void SetTab(Enums.PartSearchType type);
        void SetCompany(company c);
        void SetContact(companycontact c);
        void RunSearch(bool x);
        void DoResize();
        void FocusOnBox();
        void SetReminder(String s);
    }
}