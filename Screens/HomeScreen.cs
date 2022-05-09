using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class HomeScreen : UserControl
    {
        public HomePanel TopPanel = null;
        public NewMethod.n_user CurrentUser;
        public n_team CurrentTeam;
        Boolean bNSNView = false;
        ArrayList AllOptions = null;
        HomeScreenOption CurrentOption = null;
        ContextRz x = RzWin.Context;

        public HomeScreen()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(NewMethod.n_user u, n_team t)
        {
            CurrentUser = u;
            CurrentTeam = t;
            if (AllOptions == null)
                AllOptions = RzWin.Logic.GetHomeScreenOptions(RzWin.User);
            LoadTree();
            LoadAgents();
            //if (Rz3App.xLogic.IsAAT)
            //    LoadNSNNumbers();
        }
        public void DoResize()
        {
            DoResize(false);
        }
        public void DoResize(Boolean split)
        {
            try
            {
                ctl_StartDate.Top = 2;
                ctl_StartDate.Left = 2;
                ctl_EndDate.Top = ctl_StartDate.Bottom + 2;
                ctl_EndDate.Left = ctl_StartDate.Left;
                tv.Left = ctl_StartDate.Left;
                tv.Top = ctl_EndDate.Bottom + 2;

                int topp = 0;

                if (TopPanel != null)
                {
                    TopPanel.Top = 0;
                    TopPanel.Left = tv.Right;
                    TopPanel.Width = this.ClientRectangle.Width - TopPanel.Left;
                    topp = TopPanel.Height;
                }

                lv.Left = tv.Left;
                chkAll.Left = lv.Left;
                Int32 top = 0;
                //if (Rz3App.xLogic.IsAAT)
                //{
                //    chkAll.Top = tv.Bottom + 2;
                //    chkAll.Visible = true;
                //    chkAll.BringToFront();
                //    top = chkAll.Bottom + 2;
                //}
                //else
                //{
                chkAll.Visible = false;
                chkAll.SendToBack();
                top = tv.Bottom + 2;
                //}
                lv.Top = top;
                cmdRefresh.Left = tv.Left;
                cmdRefresh.Top = (this.ClientRectangle.Height - cmdRefresh.Height) - 2;
                lv.Height = (cmdRefresh.Top - lv.Top) - 2;
                lst.Top = topp;  // pTop.Bottom;  // ctl_StartDate.Top;
                lst.Left = tv.Right + 2;
                lst.Width = (this.ClientRectangle.Width - lst.Left) - 2;
                lstDetails.Visible = split;
                if (split)
                {
                    Int32 mid = ((this.ClientRectangle.Height - lst.Top) - 2) / 2;
                    lst.Height = mid;
                    lstDetails.Top = lst.Bottom + 2;
                    lstDetails.Height = (this.ClientRectangle.Height - lstDetails.Top) - 2;
                    lstDetails.Width = lst.Width;
                }
                else
                    lst.Height = (this.ClientRectangle.Height - lst.Top) - 2;
                gbNSN.Visible = false;
                if (bNSNView)
                {
                    gbNSN.Left = lst.Left;
                    gbNSN.Width = lst.Width;
                    gbNSN.Top = (this.ClientRectangle.Height - gbNSN.Height) - 2;
                    lst.Height = (gbNSN.Top - lst.Top) - 2;
                    Int32 i = (gbNSN.Width - 8) / 3;
                    txtNSNStart.Width = i;
                    txtNSNEnd.Left = txtNSNStart.Right + 2;
                    txtNSNEnd.Width = i;
                    cmdSearchNSN.Left = txtNSNEnd.Right + 2;
                    cmdSearchNSN.Width = (gbNSN.Width - cmdSearchNSN.Left) - 2;
                    gbNSN.Visible = true;
                }
            }
            catch
            { }
        }
        public void ShowNotes()
        {
            HomeScreenOption o = GetOptionByName("Notes");
            if (o == null)
                return;
            CurrentOption = o;
            ShowOption(o);
        }
        //Private Functions
        //protected virtual void LoadAgents()
        //{

        //    lv.Items.Clear();
        //    ListViewItem i = lv.Items.Add(RzWin.User.name);
        //    i.Checked = true;
        //    i.Tag = RzWin.User.unique_id;
        //    ArrayList a;
        //    //if (Rz3App.xUser.SuperUser || Rz3App.xLogic.IsConcord || (Rz3App.xLogic.IsCuetech && Rz3App.xSys.xUser.IsTeamMember("Purchasing"))) 
        //    if (RzWin.Context.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
        //        a = RzWin.Logic.SalesPeople;
        //    else if (RzWin.Context.xUser.IsOnTeam(RzWin.Context, "sales_assistant"))
        //        a = RzWin.Logic.SalesPeople;
        //    else
        //    {
        //        ArrayList b = RzWin.User.GetCaptainUsers(RzWin.Context);
        //        a = new ArrayList();
        //        foreach (NewMethod.n_user u in b)
        //        {
        //            a.Add(u.name);
        //        }
        //    }
        //    foreach (String n in a)
        //    {
        //        if (!Tools.Strings.StrCmp(n, RzWin.User.name))
        //        {
        //            i = lv.Items.Add(n);
        //            i.Tag = RzWin.Context.xSys.TranslateUserNameToID(n);
        //        }
        //    }
        //}

        protected virtual void LoadAgents() //refactored from RzSensible
        {
            lv.Items.Clear();
            ListViewItem i = lv.Items.Add(x.xUser.name);
            i.Checked = true;
            i.Tag = x.xUser.unique_id;
            ArrayList a;
            if (x.xUser.SuperUser || x.xUser.IsTeamMember(x, "Purchasing") || x.xUser.IsTeamMember(x, "Marketing"))
                a = x.Logic.SalesPeople;
            else if (RzWin.Context.xUser.IsTeamMember(RzWin.Context, "sales_assistant"))
                a = RzWin.Logic.SalesPeople;
            else
            {
                ArrayList b = x.xUser.GetCaptainUsers(x);
                a = new ArrayList();
                foreach (NewMethod.n_user u in b)
                {
                    a.Add(u.name);
                }

                //Assistant To Logic
                if (x.xUser.IsAssistant(x))
                {
                    n_user AssistantLeader = n_user.GetById(x, x.xUser.assistant_to_uid);
                    if (AssistantLeader != null)
                        if (!a.Contains(AssistantLeader.name))
                            a.Add(AssistantLeader.name);
                }

                //if AssitantLeader               
                if (x.xUser.IsAssistantLeader(x))
                {
                    foreach (n_user u in x.xUser.GetAssistantsForLeader(x, x.xUser.unique_id))
                    {
                        if (!a.Contains(u.name))
                            a.Add(u.name);
                    }
                }


            }
            foreach (String n in a)
            {
                if (!Tools.Strings.StrCmp(n, x.xUser.name))
                {
                    i = lv.Items.Add(n);
                    i.Tag = x.xSys.TranslateUserNameToID(n);
                }
            }


        }
        private void LoadTree()
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();

            TreeNode t = tv.Nodes.Add(CurrentUser.name);
            TreeNode u;

            foreach (HomeScreenOption o in AllOptions)
            {
                u = t.Nodes.Add(o.Caption);
                u.Tag = o;
            }

            tv.ExpandAll();
            tv.EndUpdate();
        }
        private HomeScreenOption GetOptionByName(String s)
        {
            foreach (HomeScreenOption o in AllOptions)
            {
                if (Tools.Strings.StrCmp(o.Name, s))
                    return o;
            }
            return null;
        }
        private void TopPanelClear()
        {
            try
            {
                if (TopPanel != null)
                {
                    TopPanel.SearchClicked -= new EventHandler(TopPanel_SearchClicked);
                    Controls.Remove(TopPanel);
                    TopPanel.Dispose();
                    TopPanel = null;
                }
            }
            catch { }
        }
        private void ShowOption(HomeScreenOption option)
        {
            if (option == null)
            {
                TopPanelClear();
                lst.Clear();
                lstDetails.Clear();
                return;
            }
            TopPanelInit(option);
            option.SelectedIDs = GetSelectedIDs(option);
            option.DateRange = GetDateRange(option.ClassName);
            option.NSNSearch = GetNSNWhere(option.ClassName);
            bNSNView = false; // IsNSNView(option.ClassName);
            option.NSNView = bNSNView;
            option.UnlimitedResults = lst.UnlimitedResults;

            ShowOptionCurrent();
        }

        private void ShowOptionCurrent()
        {
            HomePanelSearchArgs args = null;
            if (TopPanel != null)
                args = TopPanel.SearchArgs;

            ListArgs a = RzWin.Logic.HomeScreenSearchArgsGet(RzWin.Form.TheContextNM, CurrentOption, args);
            Boolean split = Tools.Strings.StrCmp(CurrentOption.ClassName, "ordhed");
            DoResize(split);
            lst.ShowTemplate(CurrentOption.TemplateName, CurrentOption.ClassName);
            lst.ShowData(CurrentOption.ClassName, a.TheWhere, CurrentOption.OrderField, CurrentOption.Limit);
            if (split)
            {
                lstDetails.ShowTemplate(CurrentOption.TemplateName + "_detailview", "orddet", RzWin.User.TemplateEditor);
                lstDetails.ShowData("orddet", "base_ordhed_uid in (select unique_id from ordhed where " + a.TheWhere + " )", "orddet.orderdate desc", CurrentOption.Limit);
            }
        }
        private void TopPanelInit(HomeScreenOption o)
        {
            TopPanelClear();

            switch (o.Name.ToLower().Trim())
            {
                case "notes":
                case "notes_closed":
                    TopPanel = new HomePanelNotes();
                    break;
                case "ordertrees":
                    TopPanel = new HomePanelBatches();
                    break;
            }

            if (TopPanel != null)
            {
                TopPanel.SearchClicked += new EventHandler(TopPanel_SearchClicked);
                TopPanel.Caption = o.Caption;
                Controls.Add(TopPanel);
                DoResize();
            }
        }
        private void TopPanel_SearchClicked(object sender, EventArgs e)
        {
            ShowOptionCurrent();
        }
        //protected virtual String GetSelectedIDs(HomeScreenOption option)
        //{
        //    String s = "";
        //    if (lv.CheckedItems.Count <= 0)
        //        return "'none1230172302178312073oidsh'";
        //    foreach (ListViewItem i in lv.CheckedItems)
        //    {
        //        if (Tools.Strings.StrExt(s))
        //            s += ", ";
        //        s += "'" + RzWin.Context.Filter((String)i.Tag) + "'";
        //    }
        //    return s;
        //}

        protected virtual String GetSelectedIDs(Rz5.HomeScreenOption option)
        {
            if (RzWin.Context.xUser.IsTeamMember(RzWin.Context, "Purchasing"))
            {
                switch (option.ClassName.ToLower().Trim())
                {
                    case "usernote":
                    case "contactnote":
                    case "calllog":
                    case "phonecall":
                    case "checkpayment":
                        return "'" + RzWin.Context.xUser.unique_id + "'";
                }
            }
            String s = "";
            if (lv.CheckedItems.Count <= 0)
                return "'none1230172302178312073oidsh'";
            foreach (ListViewItem i in lv.CheckedItems)
            {
                if (Tools.Strings.StrExt(s))
                    s += ", ";
                s += "'" + RzWin.Context.Filter((String)i.Tag) + "'";
            }
            return s;
        }

        private String GetDateRange(String classname)
        {
            String where = "";
            //if (classname.ToLower().Contains("ordhed"))
            //    classname = "ordhed";
            String datefield = classname + ".date_created";
            switch (classname.ToLower())
            {
                case "usernote":
                    datefield = "usernote.displaydate";
                    break;
                case "calllog":
                    datefield = "calllog.datecall";
                    break;
                case "quote":
                    datefield = "quote.quotedate";
                    break;
                case "ordhed":
                    datefield = "ordhed.orderdate";
                    break;
                case "phonecall":
                    datefield = "phonecall.calldate";
                    break;
                case "checkpayment":
                    datefield = "checkpayment.transdate";
                    break;
            }
            DateTime st = ctl_StartDate.GetValue_Date();
            DateTime ed = ctl_EndDate.GetValue_Date();
            Boolean s = IsValidDate(st);
            Boolean e = IsValidDate(ed);
            if (s && e)
                where = " " + datefield + " between cast('" + st.ToShortDateString() + " 00:00:00' as datetime) and cast('" + ed.ToShortDateString() + "  23:59:59' as datetime) ";
            else if (s)
                where = " " + datefield + " >= cast('" + st.ToShortDateString() + " 00:00:00' as datetime) ";
            else if (e)
                where = " " + datefield + "  between cast('" + ed.ToShortDateString() + " 00:00:00' as datetime) and cast('" + ed.ToShortDateString() + "  23:59:59' as datetime) ";
            return where;
        }
        private String GetNSNWhere(String classname)
        {
            String s_start = Tools.Strings.ParseDelimit(txtNSNStart.GetValue_String(), "-", 1).Trim();
            String s_end = Tools.Strings.ParseDelimit(txtNSNEnd.GetValue_String(), "-", 1).Trim();
            Int64 start = 0;
            Int64 end = 0;
            Int64.TryParse(s_start, out start);
            Int64.TryParse(s_end, out end);
            if (start == 0 && end == 0)
                return "";
            if (end != 0 && end < start)
                return "";
            String SQL = "";
            if (start == 0)
            {
                if (Tools.Strings.StrCmp(classname, "req"))
                    SQL = " req.nsn_prefix = " + end + " ";
                else if (Tools.Strings.StrCmp(classname, "reqbatch"))
                    SQL = " reqbatch.unique_id in (select req.base_reqbatch_uid from req where req.nsn_prefix = " + end + ") ";
                return SQL;
            }
            if (end == 0)
            {
                if (Tools.Strings.StrCmp(classname, "req"))
                    SQL = " req.nsn_prefix >= " + start + " ";
                else if (Tools.Strings.StrCmp(classname, "reqbatch"))
                    SQL = " reqbatch.unique_id in (select req.base_reqbatch_uid from req where req.nsn_prefix >= " + start + ") ";
                return SQL;
            }
            if (Tools.Strings.StrCmp(classname, "req"))
                SQL = " req.nsn_prefix >= " + start + " and req.nsn_prefix <= " + end + " ";
            else if (Tools.Strings.StrCmp(classname, "reqbatch"))
                SQL = " reqbatch.unique_id in (select req.base_reqbatch_uid from req where req.nsn_prefix >= " + start + " and req.nsn_prefix <= " + end + ") ";
            return SQL;
        }
        private Boolean IsValidDate(DateTime dt)
        {
            //The rules for this is the date needs to be greater than 1950
            DateTime d = new DateTime(1950, 1, 1);
            if (dt < d)
                return false;
            return true;
        }
        //private Boolean IsNSNView(String classname)
        //{
        //    if (!Rz3App.xLogic.IsAAT)
        //        return false;
        //    if (Tools.Strings.StrCmp(classname, "req"))
        //        return true;
        //    if (Tools.Strings.StrCmp(classname, "reqbatch"))
        //        return true;
        //    return false;
        //}
        //private void LoadNSNNumbers()
        //{
        //    //txtNSNStart.ClearList();
        //    //txtNSNEnd.ClearList();
        //    //if (nsn.nsn_list == null)
        //    //    nsn.LoadNSNList();
        //    //if (nsn.nsn_list.Count <= 0)
        //    //    nsn.LoadNSNList();
        //    //String list = "";
        //    //foreach (KeyValuePair<Int64, nsn> kvp in nsn.nsn_list)
        //    //{
        //    //    nsn n = (nsn)kvp.Value;
        //    //    if (n == null)
        //    //        continue;
        //    //    if (Tools.Strings.StrExt(list))
        //    //        list += "|" + n.nsn_prefix.ToString() + "-" + n.nsn_descr;
        //    //    else
        //    //        list = n.nsn_prefix.ToString() + "-" + n.nsn_descr;
        //    //}
        //    //txtNSNStart.SimpleList = list;
        //    //txtNSNEnd.SimpleList = list;
        //}
        //Buttons
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            ShowOption(CurrentOption);
        }
        private void cmdSearchNSN_Click(object sender, EventArgs e)
        {
            ShowOption(CurrentOption);
        }
        //Control Events
        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                CurrentOption = (HomeScreenOption)tv.SelectedNode.Tag;
                //if (lst.UnlimitedResults)
                //    CurrentOption.Limit = -1;
                ShowOption(CurrentOption);
            }
            catch (Exception ex)
            { string message = ex.Message; }
        }
        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            tv.SelectedNode = tv.GetNodeAt(new Point(e.X, e.Y));
        }
        private void HomeScreen_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }


}
