using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Rz5.Reports;

namespace Rz5
{
    public partial class UserPanel : UserControl
    {
        //Private Variables
        private ContextNM TheContext
        {
            get { return RzWin.Context; }
        }
        private ArrayList AllSections;
        private SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.Sys;
            }
        }

        //Constructors
        public UserPanel()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            AllSections = GetAllSections(RzWin.Context);
            LoadLV();
            DoResize();
            SelectFirstCategory();
        }
        public void DoResize()
        {
            try
            {
                LV.Top = 0;
                LV.Left = 0;
                LV.Height = this.ClientRectangle.Height;

                lblOptionHeader.Left = LV.Right;
                lblOptionHeader.Top = 0;

                lvOptions.Top = lblOptionHeader.Height;
                lvOptions.Left = LV.Right;
                lvOptions.Height = this.ClientRectangle.Height - lblOptionHeader.Height;
                lvOptions.Width = this.ClientRectangle.Width - LV.Width;
            }
            catch (Exception)
            { }
        }
        //Private Functions
        private void LoadLV()
        {
            LV.Items.Clear();
            if (AllSections == null)
                return;
            foreach (UserPanelSection u in AllSections)
            {
                ListViewItem xLst = LV.Items.Add(u.SectionName, u.GraphicImage);
                xLst.Tag = u;
            }
        }
        private void SelectFirstCategory()
        {
            try
            {
                if (LV.Items.Count <= 0)
                    return;
                LV.SelectedItems.Clear();
                LV.Items[0].Selected = true;
            }
            catch (Exception)
            { }
        }
        private void LoadCategoryOptions(UserPanelSection u)
        {
            try
            {
                lvOptions.Items.Clear();
                if (u == null)
                    return;
                lblOptionHeader.Text = u.SectionName;
                foreach (UserPanelSection s in u.AllSections)
                {
                    ListViewItem xLst;
                    if (Tools.Strings.StrExt(s.SQL))
                    {
                        xLst = lvOptions.Items.Add(s.SectionName, s.GraphicImage);
                        xLst.Tag = s;
                        LoadCategorySQLOptions(s);
                        continue;
                    }
                    xLst = lvOptions.Items.Add(s.SectionName, s.GraphicImage);
                    xLst.Tag = s;
                }
            }
            catch { }
        }
        private void LoadCategorySQLOptions(UserPanelSection u)
        {
            if (u == null)
                return;
            UserPanelSection s = (UserPanelSection)u.AllSections[0];
            if (s == null)
                return;
            DataTable dt = RzWin.Context.Select(u.SQL);
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem xLst = lvOptions.Items.Add(s.SectionName + dr[s.KeyField].ToString(), s.GraphicImage);
                UserPanelSection up = new UserPanelSection();
                up.SectionName = s.SectionName + dr[s.UIDField].ToString();
                xLst.Tag = up;
            }
        }
        private void AddNewChoiceList()
        {
            String s = RzWin.Leader.AskForString("What is the name of this new choice list?", "new_choice_list_001", "Choice List Name");
            if (!Tools.Strings.StrExt(s))
                return;
            n_choices c = xSys.GetChoicesByName(s);
            if (c != null)
            {
                RzWin.Leader.Tell("The choice list named '" + c.name + "' already exists.");
                return;
            }
            c = n_choices.New(RzWin.Context);
            c.name = s;
            c.Insert(RzWin.Context);
            xSys.CacheChoices(RzWin.Context);
            RzWin.Context.Show(c);
            ListViewItem xLst = lvOptions.Items.Add("Edit List : " + c.name, 8);
            xLst.Tag = c.unique_id;
        }
        private void ImportPDFTermsConditions()
        {
            frmTermsPDFFileAdd t = new frmTermsPDFFileAdd();
            t.CompleteLoad(RzWin.Context);
            t.ShowDialog();
        }
        public void ShowTeamManager()
        {
            RzWin.Form.ShowUserManager();
            //nTeams b = new nTeams();
            //b.xSys = xSys;
            //b.AboutToThrow += new ShowHandler(Rz3App.xMainForm.ShowHandler);
            //b.GetUserList().AboutToThrow += new ShowHandler(Rz3App.xMainForm.ShowHandler);
            //Rz3App.xMainForm.TabShow(b, "Teams and Users");
            //b.CompleteLoad();
        }
        private void LoadPrintedForm(Boolean bDesign)
        {
            if (bDesign)
            {
                PrintedForms p = new PrintedForms();
                RzWin.Form.TabShow(p, "Printed Forms");
                p.CompleteLoad();
            }
            else
            {
                printheader p = printheader.ImportFromExcel(TheContext, this);
                if (p != null)
                    RzWin.Context.Show(p);
            }
        }
        private void ShowCubes()
        {
            //nCubeView v = new nCubeView();
            //RzWin.Form.TabShow(v, "Summaries");
            //v.CompleteLoad();
        }
        private void ShowReports()
        {
            RzReports v = new RzReports();
            RzWin.Form.TabShow(v, "Statistic Reports");
            v.Init();
        }
        private void ShowCommissionReport()
        {
            ((SysRz5)RzWin.Context.xSys).TheProfitLogic.CommissionReportShow(RzWin.Context);
        }
        private void ShowSalesReport()
        {
            Reports.SalesReport r = new Reports.SalesReport(RzWin.Context);
            RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, r, false);
        }
        private void ShowPurchaseReport()
        {
            Reports.PurchaseReport r = new Reports.PurchaseReport(RzWin.Context);
            RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, r, false);
        }

        private void ShowProfitReport()
        {
            Reports.ProfitReport r = new Reports.ProfitReport(RzWin.Context);
            RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, r, false);
        }
        private void DoWebUpdate()
        {
            RzWin.Form.ShowVersionUpdate();
        }
        private void EditChoiceList(String uid)
        {
            try
            {
                if (!Tools.Strings.StrExt(uid))
                    return;
                n_choices c = n_choices.GetById(RzWin.Context, uid);
                if (c != null)
                    RzWin.Context.Show(c);
            }
            catch (Exception)
            { }
        }
        private void ShowRzLinkManager()
        {
            Rz5.Win.Screens.RzLink l = new Win.Screens.RzLink();
            l.Init();
            RzWin.Form.TabShow(l, "Rz Portal Mangement");
        }


        private void ShowSandBox()
        {
            SandBox l = new SandBox();
            l.Init();
            RzWin.Form.TabShow(l, "SandBox");
        }
        private void ConvertToRz4Show()
        {
            RzWin.Form.TabShow(new Rz5.Win.Screens.ConvertToRz4(), "Convert To Rz4");
        }
        public virtual void RunSelectedOption(ContextNM x, UserPanelSection u)
        {
            try
            {
                if (u == null)
                    return;
                String s = u.SectionName.ToLower();
                if (s.Contains("edit list"))
                    s = "edit list";
                switch (s)
                {
                    case "add new choice list":
                        AddNewChoiceList();
                        break;
                    case "edit list":
                        EditChoiceList(Tools.Strings.ParseDelimit(u.SectionName.ToLower(), ":", 2).Trim());
                        break;
                    case "quote completion":
                        ShowQuoteCompletion(RzWin.Context);
                        break;
                    case "sandbox":
                        ShowSandBox();
                        break;
                    case "convert to rz4":
                        ConvertToRz4Show();
                        break;
                    case "teams and users":
                        ShowTeamManager();
                        break;
                    case "design":
                        LoadPrintedForm(true);
                        break;
                    case "import":
                        LoadPrintedForm(false);
                        break;
                    case "email templates":
                        RzWin.Form.ShowGenericTabControl_CompleteLoad(new EmailTemplates(), "Email Templates");
                        break;
                    case "email blaster":
                        RzWin.Form.ShowGenericTabControl_CompleteLoad(((LeaderWinUserRz)RzWin.Context.TheLeader).EmailBlasterCreate(), "Email Blaster");
                        break;
                    case "duty monitor":
                        RzWin.Form.ShowGenericTabControl_CompleteLoad(new DutyMonitor(), "Duty Monitor");
                        break;
                    case "phone/fax monitor":
                        RzWin.Context.TheSysRz.ThePanelLogic.PhoneMonitorShow(RzWin.Context);
                        break;
                    case "order number editor":
                        frmOrderNumberEditor f = RzWin.Leader.GetOrderNumberEditor(RzWin.Context);
                        if (!f.CompleteLoad(RzWin.Context))
                            return;
                        f.ShowDialog();
                        break;
                    case "summaries":
                        ShowCubes();
                        break;
                    case "statistic reports":
                        ShowReports();
                        break;
                    case "commission report":
                        ShowCommissionReport();
                        break;
                    case "database manager":
                        if (!RzWin.User.SuperUser)
                        {
                            RzWin.Leader.Tell("You must be a SuperUser to access this feature.");
                            return;
                        }
                        RzWin.Form.ShowGenericTabControl_CompleteLoad(new DatabaseManager(), "Database Manager");
                        break;
                    case "web update":
                        DoWebUpdate();
                        break;
                    case "your company information":
                        RzWin.Leader.ShowCompanySettings();
                        break;
                    //case "community settings":
                    //    RzCommunitySettings set = new RzCommunitySettings();
                    //    set.CompleteLoad(RzWin.Context);
                    //    RzWin.Context.xSys.xMainForm.TabShow(set, "Community Settings");
                    //    break;
                    case "bin swapper":
                        frmBinSwapper xSwap = new frmBinSwapper();
                        if (xSwap.CompleteLoad())
                            xSwap.ShowDialog();
                        break;
                    case "contact recognin":
                        break;
                    case "restore company":
                        RzWin.Context.TheSysRz.TheCompanyLogic.CompanyRestore(RzWin.Context);
                        break;
                    case "restore contact":
                        RzWin.Context.TheSysRz.TheCompanyLogic.ContactRestore(RzWin.Context);
                        break;
                    case "restore order":
                        RzWin.Context.TheSysRz.TheOrderLogic.OrderRestore(RzWin.Context);
                        break;
                    case "restore order line":
                        RzWin.Context.TheSysRz.TheOrderLogic.OrderLineRestore(RzWin.Context);
                        break;
                    case "import pdf terms & conditions":
                        ImportPDFTermsConditions();
                        break;
                    case "inventory value report":
                        RzWin.Context.TheSysRz.ThePanelLogic.ShowStockValueReport(RzWin.Context);
                        break;
                    case "sales report":
                        ShowSalesReport();
                        break;
                    case "purchase report":
                        ShowPurchaseReport();
                        break;
                    case "rzlink manager":
                        ShowRzLinkManager();
                        break;
                    case "consignment report":
                        ShowConsignmentReport();
                        break;
                    case "quote-to-sale ratio":
                        RzWin.Context.TheSysRz.ThePanelLogic.QuoteToSaleRatio(RzWin.Context);
                        //((PanelLogic)((SysSensible)x.TheSys).ThePanelLogic).QuoteToSaleRatio(x);
                        break;
                    //case "profit report":
                    //    ShowProfitReport();
                    //    break;
                    case "profit report (rz canned)":
                        ShowProfitReport();
                        break;
                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message + Environment.NewLine+ ex.InnerException);
            }
        }
        private void ShowConsignmentReport()
        {
            try
            {
                ConsignmentReport r = new ConsignmentReport();
                r.Init();
                r.CompleteStructure();
                RzWin.Form.TabShow(r, "Consignment Report");
            }
            catch { }
        }


        //public virtual ArrayList GetAllSections(ContextRz x)
        //{
        //    return RzWin.Logic.UserPanelOptionTree(x, false);
        //}

        public virtual ArrayList GetAllSections(ContextRz x)
        {
            ArrayList a = RzWin.Logic.UserPanelOptionTree(x, false);
            foreach (UserPanelSection u in a)
            {
                if (!Tools.Strings.StrCmp(u.SectionName, "Reports"))
                    continue;
                UserPanelSection s = new UserPanelSection();
                s.SectionName = "Consignment Report";
                s.GraphicImage = "Reports.bmp";
                u.AllSections.Add(s);

                s = new UserPanelSection();
                s.SectionName = "Quote-To-Sale Ratio";
                s.GraphicImage = "Reports.bmp";
                u.AllSections.Add(s);

                s = new UserPanelSection();
                s.SectionName = "Customer Invoice Report";
                s.GraphicImage = "Reports.bmp";
                u.AllSections.Add(s);
            }
            return a;
        }
        public virtual bool ShowQuoteCompletion(ContextRz x)
        {
            Reports.QuoteCompletion r = new Reports.QuoteCompletion(x);
            x.TheLeaderRz.ReportShow(x, r, false);
            return true;
        }
        //Control Events
        private void UserPanel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void LV_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (LV.SelectedItems.Count == 1)
                LoadCategoryOptions((UserPanelSection)LV.SelectedItems[0].Tag);
        }
        private void lvOptions_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (lvOptions.SelectedItems.Count <= 0)
                    return;
                RunSelectedOption(RzWin.Context, (UserPanelSection)lvOptions.SelectedItems[0].Tag);
            }
            catch { }
        }
    }
}
