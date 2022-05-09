using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;

namespace Rz5
{
    public partial class PhoneReport : UserControl
    {
        public static string SummaryColor1 = "Black";//"#66FFCC";
        public static string SummaryColor2 = "Red";//"#66CCFF";
        //Private Static Variables
        private static String LastCallSQL = "";
        //Public Variables
        public ContextRz TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        //Private Variables
        private bool InhibitSelect = false;
        private StringBuilder WeeklySummary;
        private DateTime WeeklyStart;
        private ArrayList WeeklyUserIDs;
        private DataTable d_total;
        private DataTable d_outnd;

        //Constructors
        public PhoneReport()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }
        //Public Virtual Functions
        public virtual void CompleteLoad(ContextNM x)
        {
            SetDates(DateRangeTypes.Today);
            wb.Clear();
            txtDate.Text = nTools.DateFormat(DateTime.Now);
            LoadAgents(TheContext);
            LoadTeams(TheContext);
            UpdateAgentTotals();
            SetDate(DateTime.Now);
            lblApplyCalls.Visible = RzWin.User.SuperUser;
            cmdList.Visible = x.xUser.IsDeveloper();
        }

        private void SetDates(DateRangeTypes dr)
        {
            dtStart.SetValue(GetDate(dr, false));
            dtEnd.SetValue(GetDate(dr, true));
        }

        //public virtual Tools.Dates.DateRange GetCurrentRange()
        //{
        //    try
        //    {
        //        return new Tools.Dates.DateRange(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));
        //    }
        //    catch { return null; }
        //}
        public virtual Tools.Dates.DateRange GetCurrentRange()
        {
            try
            {
                return new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            }
            catch { return null; }
        }


        //public virtual string GetDateRangeText(bool summary)
        //{
        //    if (summary)
        //        return "On " + txtDate.Text;
        //    else
        //        return "on " + txtDate.Text;
        //}

        public virtual string GetDateRangeText(bool summary)
        {
            if (summary)
                return "From " + dtStart.GetValue_Date().ToShortDateString() + " to " + dtEnd.GetValue_Date().ToShortDateString();
            else
                return "from " + dtStart.GetValue_Date().ToShortDateString() + " to " + dtEnd.GetValue_Date().ToShortDateString();
        }


        public virtual void ShowSummary()
        {
            String strCaption = "";
            Tools.Dates.DateRange d = GetCurrentRange();
            wb.ReloadWB();
            String strTable = GetCurrentTable(ref strCaption);
            if (optVertical.Checked)
            {
                wb.Add("<h1>Phone Report " + strCaption + "</h1><hr><br>");
                WriteVerticalReport_HTML(strTable);
            }
            else
            {
                if (!RzWin.Context.Data.TableExists(strTable))
                {
                    wb.Add("No call information exists for " + nTools.DateFormat(d.StartDate));
                    return;
                }
                ArrayList UserIDs = new ArrayList();
                wb.Add("<h1>Phone Report " + GetDateRangeText(true) + "</h1><hr><br>");
                foreach (ListViewItem xLst in lv.Items)
                {
                    if (xLst.Selected)
                    {
                        String strID = SysNewMethod.ParseKeyID((String)xLst.Tag);
                        UserIDs.Add(strID);
                    }
                }
                UserIDs = OrderByVolume(UserIDs, strTable);
                foreach (String s in UserIDs)
                {
                    WriteUserSection(s, strTable, "day");
                    wb.Add("<br><br>");
                }
            }
        }
        public virtual String GetCurrentTable(ref String strCaption)
        {
            Tools.Dates.DateRange d = GetCurrentRange();

            string sql = "drop table temp_phonesummary";
            RzWin.Context.Execute(sql, true);
            sql = "select sum(duration) as total_volume,count(unique_id) as total_count,base_mc_user_uid into temp_phonesummary from phonecall where calldate " + d.GetBetweenSQL() + " group by base_mc_user_uid";
            try { RzWin.Context.Execute(sql); }
            catch
            {
                switch (tsTime.SelectedIndex)
                {
                    case 0:
                        strCaption = GetDateRangeText(true);
                        return "cube_base_phonecall_byday_" + d.StartDate.Year.ToString() + "_" + nTools.GetMonth_2Digit(d.StartDate) + "_" + nTools.GetDay_2Digit(d.StartDate);
                    case 1:
                        strCaption = "For The Week Of " + nTools.DateFormat_Extra(d.StartDate);
                        return "cube_base_phonecall_byweek_" + d.StartDate.Year.ToString() + "_" + nTools.GetMonth_2Digit(d.StartDate) + "_" + nTools.GetDay_2Digit(d.StartDate);
                    case 2:
                        strCaption = "For The Month Of " + nTools.DateFormat_Extra(d.StartDate);
                        return "cube_base_phonecall_bymonth_" + d.StartDate.Year.ToString() + "_" + nTools.GetMonth_2Digit(d.StartDate) + "_" + nTools.GetDay_2Digit(d.StartDate);
                    case 3:
                        strCaption = "For The Quarter Of " + nTools.DateFormat_Extra(d.StartDate);
                        return "cube_base_phonecall_byquarter_" + d.StartDate.Year.ToString() + "_" + nTools.GetMonth_2Digit(d.StartDate) + "_" + nTools.GetDay_2Digit(d.StartDate);
                }
            }
            return "temp_phonesummary";
        }

        //public virtual String GetCurrentTable(ref String strCaption)
        //{
        //    Tools.Dates.DateRange d = GetCurrentRange();
        //    strCaption = GetDateRangeText(true);
        //    string sql = "drop table temp_phonesummary";
        //    RzWin.Context.Execute(sql, true);
        //    sql = "select sum(duration) as total_volume,count(unique_id) as total_count,base_mc_user_uid into temp_phonesummary from phonecall where calldate " + d.GetBetweenSQL() + " group by base_mc_user_uid";
        //    try { RzWin.Context.Execute(sql); }
        //    catch { 
        //        //return base.GetCurrentTable(ref strCaption); 
        //    }
        //    return "temp_phonesummary";
        //}



        //Public Functions
        public void CompleteLoad()
        {
            CompleteLoad(RzWin.Form.TheContextNM);
        }
        public void DoResize()
        {
            try
            {
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height - wb.Top;
            }
            catch { }
        }
        public void SetDate(DateTime dtDate)
        {
            switch (tsTime.SelectedIndex)
            {
                case 0:
                    cmdNow.Text = "Today";
                    lblSummary.Text = "\r\n" + nTools.DateFormat_Extra(dtDate);
                    break;
                case 1:
                    dtDate = nTools.GetWeekStart(dtDate);
                    lblSummary.Text = nTools.DateFormat_Extra(dtDate) + "\r\nTo\r\n" + nTools.DateFormat_Extra(dtDate.Add(TimeSpan.FromDays(6)));
                    cmdNow.Text = "This Week";
                    break;
                case 2:
                    dtDate = nTools.GetMonthStart(dtDate);
                    cmdNow.Text = "This Month";
                    lblSummary.Text = nTools.DateFormat_Extra(dtDate) + "\r\nTo\r\n" + nTools.DateFormat_Extra(nTools.GetMonthEnd(dtDate));
                    break;
                case 3:
                case 4:
                    break;
            }
            txtDate.Text = nTools.DateFormat(dtDate);
        }
        public String GetTotalTime(String strID, String strExt)
        {
            Tools.Dates.DateRange d = GetCurrentRange();
            String strSQL = "select sum(duration) from phonecall where base_mc_user_uid = '" + strID + "' and " + d.GetSQL("calldate");
            long lngTime = RzWin.Context.SelectScalarInt64(strSQL);
            return Tools.Number.LongFormat(Convert.ToInt64(Convert.ToDouble(lngTime) / Convert.ToDouble(60)));
        }
        public void RunReport()
        {
            //ShowSummary();

            //Individual Agents
            //if (lv.SelectedItems.Count >= 0)
            //    return;
            ArrayList a;

            if(!string.IsNullOrEmpty(cboTeams.Text))
                SelectByTeam(Tools.Strings.Mid(cboTeams.Text, 6).Trim());
            else
                a = GetSelectedUserIDs();

            if ((ts.SelectedIndex == 0) && (tsTime.SelectedIndex == 0))
            {

                a = GetSelectedUserIDs();
                //if (a.Count == 0)
                //    return;
            }
            else
                a = AgentIdsGet(RzWin.Context);
            LoadReport(a);
            if (ts.SelectedIndex == 1)
                ShowSummary();
            else if (ts.SelectedIndex == 2)
                RunWeeklyOverview();
            else if (ts.SelectedIndex == 3)
                RunYearlyOverview();
            RzWin.User.SetActivity(RzWin.Context);
        }
        public ArrayList OrderByVolume(ArrayList x, String strTable)
        {
            RzWin.Context.Reorg();
            return x;
            //return nCube.OrderByVolume(TheContext.xSys, x, strTable);
        }
        public ArrayList GetSelectedUserIDs()
        {
            ArrayList a = new ArrayList();
            foreach (ListViewItem i in lv.SelectedItems)
            {
                String k = (String)i.Tag;
                String strClass = SysNewMethod.ParseKeyClass(k);
                String strID = SysNewMethod.ParseKeyID(k);
                switch (strClass.ToLower())
                {
                    case "n_team":
                        n_team t = (n_team)TheContext.xSys.Teams.GetByID(strID);
                        if (t != null)
                        {
                            foreach (NewMethod.n_user u in t.AllMembers)
                            {
                                if (!a.Contains(u.unique_id))
                                    a.Add(u.unique_id);
                            }
                        }
                        break;
                    case "n_user":
                        if (!a.Contains(strID))
                            a.Add(strID);
                        break;
                }
            }
            return a;
        }
        public void SelectUserByID(String strID)
        {
            InhibitSelect = true;
            foreach (ListViewItem i in lv.Items)
            {
                i.Selected = Tools.Strings.StrCmp(strID, SysNewMethod.ParseKeyID((String)i.Tag));
            }
            InhibitSelect = false;
        }
        public void SelectTeamByID(String strID)
        {
            n_team t = (n_team)TheContext.xSys.Teams.GetByID(strID);
            if (t == null)
                return;
            SelectByTeam(t);
        }
        //Private Functions
        private void LoadTeams(ContextRz context)
        {
            foreach (String t in context.TheSysRz.TheUserLogicRz.TeamOptionsList(context))
            {
                cboTeams.Items.Add(t);
            }
        }
        protected virtual ArrayList AgentIdsGet(ContextRz context)
        {
            ArrayList ids = null;
            //KT 6-12-2015 Added check for "view all users on reports instead of just super users
            if (context.xUser.SuperUser || context.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
                ids = context.SelectScalarArray("select unique_id from n_user where isnull(main_n_team_uid, '') > '' and isnull(is_inactive, 0) = 0 and isnull(phone_ext, '') > '' order by name ");
            else
                ids = context.SelectScalarArray("select unique_id from n_user where isnull(main_n_team_uid, '') > '' and isnull(is_inactive, 0) = 0 and isnull(phone_ext, '') > '' and unique_id in (" + RzWin.User.GetCaptainUserIDs(RzWin.Context) + " ) order by name ");
            if (context.xUser.SuperUser)
            {
                ArrayList extras = context.SelectScalarArray("select setting_key from n_set where name = 'always_on_phone_report'");
                foreach (String idx in extras)
                {
                    if (!ids.Contains(idx))
                        ids.Add(idx);
                }
            }
            return ids;
        }
        private void LoadAgents(ContextRz context)
        {
            //String strSQL = "";
            lv.Items.Clear();
            ArrayList ids = AgentIdsGet(context);
            if (ids.Count == 0)
                ids.Add("not and id");
            DataTable d = context.Select("select unique_id, name from n_user where unique_id in (" + nTools.GetIn(ids) + ") order by name");
            if (!nTools.DataTableExists(d))
                return;
            foreach (DataRow r in d.Rows)
            {
                bool b = true;
                String n = (String)r["name"];
                if (n.ToLower().EndsWith(" - private"))
                {
                    if (!context.xUser.IsDeveloper())
                    {
                        String an = Tools.Strings.Left(n, n.Length - 10);
                        if (!Tools.Strings.StrCmp(an, context.xUser.name))
                            b = false;
                    }
                }
                switch (n)
                {
                    case "Joe Santora":
                        b = false;
                        break;
                }
                if (b)
                {
                    ListViewItem xLst = lv.Items.Add(n);
                    xLst.SubItems.Add("");
                    xLst.SubItems.Add("");
                    xLst.Tag = "n_user:" + (String)r["unique_id"];
                }
            }
        }
        private void RunWeeklyOverview()
        {
            if (bgSummary.IsBusy)
            {
                RzWin.Leader.Tell("The report is already running.");
                return;
            }
            if (!Tools.Dates.IsDate(txtDate.Text))
            {
                TheContext.TheLeader.TellTemp("Please enter a valid date.");
                return;
            }
            throb.ShowThrobber();
            wb.ReloadWB();
            WeeklyStart = DateTime.Parse(txtDate.Text);
            WeeklyUserIDs = new ArrayList();
            foreach (ListViewItem xLst in lv.Items)
            {
                if (xLst.Selected)
                {
                    String strID = SysNewMethod.ParseKeyID((String)xLst.Tag);
                    WeeklyUserIDs.Add(strID);
                }
            }
            bgSummary.RunWorkerAsync();
        }
        private void RunYearlyOverview()
        {
            if (bgYearly.IsBusy)
            {
                RzWin.Leader.Tell("The report is already running.");
                return;
            }
            throb.ShowThrobber();
            wb.ReloadWB();
            WeeklyStart = DateTime.Parse(txtDate.Text);
            WeeklyUserIDs = new ArrayList();
            foreach (ListViewItem xLst in lv.Items)
            {
                if (xLst.Selected)
                {
                    String strID = SysNewMethod.ParseKeyID((String)xLst.Tag);
                    WeeklyUserIDs.Add(strID);
                }
            }
            bgYearly.RunWorkerAsync();
        }
        private void WriteUserSection(String strUserID, String strTable, String strType)
        {
            NewMethod.n_user yUser = NewMethod.n_user.GetById(RzWin.Context, strUserID);
            wb.Add(yUser.name + "<br>");
            wb.Add("<table border=0 cellspacing=0 cellpadding=0><tr>");
            String strSQL = "select * from " + strTable + " where base_mc_user_uid = '" + strUserID + "' order by hour_index";
            DataTable d = RzWin.Context.Select(strSQL);
            if (!nTools.DataTableExists(d))
            {
                wb.Add("<td>(none)</td></tr></table>");
                return;
            }
            long lngBlue = 255;
            long lngGreen = 0;
            long lngTotalSeconds = 0;
            long lngTotalCalls = 0;
            String strColor;
            lngTotalCalls = 0;
            lngTotalSeconds = 0;
            foreach (DataRow r in d.Rows)
            {
                long lngWidth = Convert.ToInt64(Convert.ToDouble(nData.NullFilter_Long(r["total_volume"])) / Convert.ToDouble(30));
                if (nData.NullFilter_Long(r["hour_index"]) <= 12)
                    strColor = "66CCFF";
                else if (nData.NullFilter_Long(r["hour_index"]) >= 17)
                    strColor = "FF0000";
                else
                    strColor = "66FFCC";
                wb.Add("<td width=" + lngWidth.ToString() + " bgcolor=#" + strColor + " height=18>");
                wb.Add("</td>");
                lngTotalCalls += nData.NullFilter_Long(r["total_count"]);
                lngTotalSeconds += nData.NullFilter_Long(r["total_volume"]);
            }
            wb.Add("</tr></table>");
            wb.Add("<font color=#C0C0C0 size=2>" + Tools.Number.LongFormat(lngTotalCalls) + " calls / " + Tools.Dates.FormatHMS(lngTotalSeconds) + "<br>Average: " + Tools.Dates.FormatHMS(Convert.ToInt32(Convert.ToDouble(lngTotalSeconds) / Convert.ToDouble(lngTotalCalls))) + "</font>");
        }
        private long GetSelectedCount()
        {
            return lv.SelectedItems.Count;
        }
        private void LoadReport(ArrayList userids)
        {
            Tools.Dates.DateRange dr = GetCurrentRange();
            if (dr == null)
                return;

            string daterange = GetDateRangeText(false);
            wb.ReloadWB();
            if (chkGroupByAgent.Checked)
            {
                wb.Add("<h1>Phone Report</h1>");
                foreach (String s in userids)
                {
                    NewMethod.n_user yUser = NewMethod.n_user.GetById(TheContext, s);
                    ArrayList singleuser = new ArrayList();
                    singleuser.Add(yUser.unique_id);

                    PhoneReportArgs args = new PhoneReportArgs(singleuser, dr.GetSQL("calldate"), true, chkOnlyCustomers.Checked, chkOnlyProspects.Checked, "Phone Report " + daterange, optIn.Checked, optOut.Checked, chkOnlyInfo.Checked, optOnlyOEM.Checked, optOnlyDist.Checked);
                    LastCallSQL = RzWin.Context.TheSysRz.ThePhoneLogic.GetCallSQLWhere(RzWin.Context, args);
                    String strSQL = RzWin.Context.TheSysRz.ThePhoneLogic.GetCallSQL(RzWin.Context, args);
                    DataTable d = RzWin.Context.Select(strSQL);
                    long lngDuration = 0;
                    long lngCount = 0;
                    wb.Add("<hr><h2>" + yUser.name + " on " + txtDate.Text + "</h2><br>");
                    String strColor = "";
                    wb.Add("<table width=100% border=0><tr><td><b>Date-Time</b></td><td><b>Phone Number</b></td><td><b>Duration</b></td><td><b>Company</b></td><td><b>Contact</b></td><td><b>Type</b></td></tr>");
                    foreach (DataRow r in d.Rows)
                    {
                        if (Tools.Strings.StrCmp(nData.NullFilter_String(r["phonenumber"]), "in") || Tools.Strings.StrCmp(nData.NullFilter_String(r["direction"]), "in"))
                            strColor = "#00FF00";
                        else
                            strColor = "#000000";
                        wb.Add("<tr><td><font color=" + strColor + ">" + nTools.DateFormat_ShortDateTime(nData.NullFilter_Date(r["calldate"])) + "</font></td><td><font color=" + strColor + ">" + nData.NullFilter_String(r["PhoneNumber"]) + "</font></td><td><font color=" + strColor + ">" + Tools.Dates.FormatHMS(nData.NullFilter_Long(r["Duration"])) + "</font></td><td><font color=" + strColor + ">" + nData.NullFilter_String(r["company"]) + "</font></td><td><font color=" + strColor + ">" + nData.NullFilter_String(r["contact"]) + "</font></td><td><font color=" + strColor + ">" + nData.NullFilter_String(r["abs_type"]) + "</font></td></tr>");
                        lngDuration += Tools.Data.NullFilterIntegerFromIntOrLong(r["duration"]);
                        lngCount++;
                    }
                    wb.Add("</table><br><br>");
                    wb.Add("<h2>" + Tools.Number.LongFormat(lngCount) + " calls for a total of " + Tools.Dates.FormatHMS(lngDuration) + "</h2>");
                }
            }
            else   //all together
            {
                PhoneReportArgs args = new PhoneReportArgs(userids, dr.GetSQL("calldate"), true, chkOnlyCustomers.Checked, chkOnlyProspects.Checked, "Phone Report on " + daterange, optIn.Checked, optOut.Checked, chkOnlyInfo.Checked, optOnlyOEM.Checked, optOnlyDist.Checked);
                LastCallSQL = RzWin.Context.TheSysRz.ThePhoneLogic.GetCallSQLWhere(RzWin.Context, args);
                wb.Add(RzWin.Context.TheSysRz.ThePhoneLogic.GetCallReportHtml(RzWin.Context, args));
            }
        }
        private NewMethod.n_user GetSelectedUser()
        {
            try
            {
                if (lv.SelectedItems[0] == null)
                    return RzWin.User;
                else
                    return (NewMethod.n_user)TheContext.xSys.GetByKey(RzWin.Context, (String)lv.SelectedItems[0].Tag);
            }
            catch { return RzWin.User; }
        }
        private n_team GetSelectedTeam()
        {
            try
            {
                if (lv.SelectedItems[0] == null)
                    return RzWin.User.GetMainTeam(RzWin.Context);
                else
                    return (n_team)TheContext.xSys.GetByKey(RzWin.Context, (String)lv.SelectedItems[0].Tag);
            }
            catch (Exception)
            {
                return RzWin.User.GetMainTeam(RzWin.Context);
            }
        }
        private void ChangeDayBy(int intNumber)
        {
            DateTime dtSelected = GetCurrentRange().StartDate + TimeSpan.FromDays(Convert.ToDouble(intNumber));
            SetDate(dtSelected);
            RunReport();
        }
        private void SelectByTeam(String strTeam)
        {
            n_team t = n_team.GetByName(RzWin.Context, strTeam);
            if (t == null)
            {
                RzWin.Leader.Tell("The team '" + strTeam + "' could not be found.");
                return;
            }

            SelectByTeam(t);
        }
        private void SelectByTeam(n_team t)
        {
            ArrayList a = t.GetUserIDs(RzWin.Context);

            InhibitSelect = true;
            foreach (ListViewItem i in lv.Items)
            {
                i.Selected = a.Contains(SysNewMethod.ParseKeyID((String)i.Tag));
            }
            InhibitSelect = false;
        }
        private void ResetDate()
        {
            try
            {
                SetDate(Convert.ToDateTime(txtDate.Text));
            }
            catch (Exception)
            { }
        }
        private void WriteVerticalReport_HTML(String strTable)
        {
            //RzWin.Context.Reorg();
            long lngTotalSeconds = 0;
            long lngTotalCalls = 0;
            long lngTotalSecondsBeforeNoon = 0;
            long lngTotalCallsBeforeNoon = 0;
            int intCalls = 0;
            long lngHeight = 0;
            long lngThis = 0;
            long lngMostCalls = 0;
            int ScaleFactor = 15;
            int ScaleFactorCalls = 60;
            wb.Visible = true;
            wb.Add("<html><head></head><body topmargin=0 leftmargin=0>");
            if (!TheContext.Data.Connection.TableExists(strTable))
            {
                wb.Add("No data is available for this time period.</body><html>");
                return;
            }
            long lngMost = 0;
            foreach (ListViewItem xLst in lv.Items)
            {
                if (xLst.Selected)
                {
                    String strID = SysNewMethod.ParseKeyID((String)xLst.Tag);
                    lngThis = TheContext.SelectScalarInt64("select sum(total_volume) from " + strTable + " where base_mc_user_uid = '" + strID + "'");
                    if (lngThis > lngMost)
                        lngMost = lngThis;
                }
            }
            //convert to minutes
            lngMost = nTools.DivideWithFractions(lngMost, 60);
            //round up to the next 15 minutes
            while ((lngMost % ScaleFactor) != 0)
                lngMost++;
            long l = ((lngMost / 15) * 20) + 50;
            wb.Add("<table cellpadding=0 cellspacing=0 background=\"file:///" + nTools.GetAppParentPath() + "graphics\\line.bmp\" border=0 height=" + l.ToString() + "><tr valign=bottom>");
            //write the scale
            wb.Add("<td nowrap valign=bottom height=100%><table cellpadding=0 cellspacing=0 border=0 width=30px>");
            if (lngMost > ScaleFactor)
            {
                for (intCalls = Convert.ToInt32(lngMost); intCalls < ScaleFactor && intCalls > 0; intCalls -= ScaleFactor)
                {
                    if ((intCalls % 60) == 0)
                    {
                        if ((intCalls / 60) == 1)
                            wb.Add("<tr height=20px><td valign=bottom align=right nowrap>1 hr</td></tr>");
                        else
                            wb.Add("<tr height=20px><td valign=bottom align=right nowrap>" + Tools.Number.LongFormat(intCalls / 60) + " hrs</td></tr>");
                        if (intCalls % 60 == 45)
                            wb.Add("<tr height=20px><td valign=bottom align=right nowrap>45</td></tr>");
                        else if (intCalls % 60 == 30)
                            wb.Add("<tr height=20px><td valign=bottom align=right nowrap>30</td></tr>");
                        else if (intCalls % 60 == 15)
                            wb.Add("<tr height=20px><td valign=bottom align=right nowrap>15</td></tr>");
                    }
                }
            }
            wb.Add("<tr height=20px><td nowrap>&nbsp;</td></tr>");
            wb.Add("</table></td><td nowrap width=50px></td>");
            lngMostCalls = 0;
            ArrayList colUsers = new ArrayList();
            foreach (ListViewItem xLst in lv.Items)
            {
                if (xLst.Selected)
                {
                    NewMethod.n_user yUser = (NewMethod.n_user)TheContext.xSys.GetByKey(TheContext, (String)xLst.Tag);
                    if (yUser != null)
                    {
                        lngTotalSeconds = TheContext.SelectScalarInt64("select sum(total_volume) from " + strTable + " where base_mc_user_uid = '" + yUser.unique_id + "'");
                        lngTotalCalls = TheContext.SelectScalarInt64("select sum(total_count) from " + strTable + " where base_mc_user_uid = '" + yUser.unique_id + "'");
                        colUsers.Add(new UserPhoneHandle(yUser, lngTotalSeconds, lngTotalCalls));
                    }
                }
            }
            colUsers.Sort();
            foreach (UserPhoneHandle h in colUsers)
            {
                NewMethod.n_user yUser = h.xUser;
                lngTotalSeconds = h.total_volume;
                lngTotalCalls = h.total_count;
                if (lngTotalCalls > lngMostCalls)
                    lngMostCalls = lngTotalCalls;
                //ok, this cell is the entire slice for the user
                wb.Add("<td valign=bottom height=100%><table cellpadding=0 cellspacing=0 border=0 width=25>");
                wb.Add("<tr><td width=25px valign=bottom align=center><font color=" + PhoneReport.SummaryColor1 + " size=1>" + Tools.Number.LongFormat(lngTotalCalls) + "</font></td></tr>");
                if (lngTotalCalls - lngTotalCallsBeforeNoon > 0)
                    lngHeight = ((lngTotalCalls / 15) * 20);
                //cell 2
                wb.Add("<tr width=25px height=" + lngHeight.ToString() + "px><td nowrap width=25px nowrap bgcolor=" + PhoneReport.SummaryColor1 + "></td></tr>");
                //end of the entire user's slice
                wb.Add("</table></td>");
                //Minutes %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                wb.Add("<td valign=bottom height=100%><table cellpadding=0 cellspacing=0 border=0 width=25>");
                Double hours = lngTotalSeconds;
                hours = GetCallTimeTotal(hours);
                wb.Add("<tr><td width=25px valign=bottom align=center><font color=" + PhoneReport.SummaryColor2 + " size=1>" + hours.ToString() + "</font></td></tr>");
                if (lngTotalSeconds - lngTotalSecondsBeforeNoon > 0)
                {
                    lngHeight = ((lngTotalSeconds / (60 * 15)) * 20);
                    //cell 2
                    wb.Add("<tr width=25px height=" + lngHeight.ToString() + "px><td nowrap width=25px nowrap bgcolor=" + PhoneReport.SummaryColor2 + "></td></tr>");
                }
                wb.Add("</table></td>");
                wb.Add("<td nowrap width=20px>&nbsp;</td>");
                //End Of Minutes%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            }
            //write the minutes scale
            while (lngMostCalls % 15 != 0)
            {
                lngMostCalls++;
            }
            wb.Add("<td nowrap valign=bottom height=100%><table cellpadding=0 cellspacing=0 border=0 width=30px>");
            for (intCalls = Convert.ToInt32(lngMostCalls); intCalls > 15; intCalls -= 15)
            {
                wb.Add("<tr height=20px><td valign=bottom align=right nowrap>" + intCalls.ToString() + "</td></tr>");
            }
            wb.Add("<tr height=20px><td nowrap>&nbsp;</td></tr>");
            wb.Add("</table></td><td nowrap width=50px></td>");
            //end minutes scale
            wb.Add("</table>");
            wb.Add("<table border=0 cellpadding=0 cellspacing=0 ><tr height=30px><td nowrap width=80px></td>");
            foreach (UserPhoneHandle h in colUsers)
            {
                wb.Add("<td nowrap valign=top width=50px align=center><font size=1>" + h.xUser.name.Replace(" ", "<br>") + "</font></td>");
                wb.Add("<td nowrap width=20px>&nbsp;</td>");
            }
            wb.Add("</tr></table>");
            wb.Add("<br><br><p align=center><table width=300px border=1><tr><td colspan=2><font size=1><center>Legend</center></font></td></tr><tr><td width=50% bgcolor=" + PhoneReport.SummaryColor1 + "></td><td><font size=1 color=" + PhoneReport.SummaryColor1 + ">Call Count</td></tr><tr><td width=50% bgcolor=" + PhoneReport.SummaryColor2 + "></td><td><font size=1 color=" + PhoneReport.SummaryColor2 + ">Total Minutes</td></tr></table></p>");
            wb.Add("</body></html>");
        }
        protected virtual Double GetCallTimeTotal(Double hours)
        {
            return Math.Round(hours / (60 * 60), 1);
        }
        private void UpdateAgentTotals()
        {
            ArrayList use = new ArrayList();
            foreach (ListViewItem xLst in lv.Items)
            {
                xLst.SubItems[1].Text = "";
                xLst.SubItems[2].Text = "";
                use.Add(SysNewMethod.ParseKeyID((String)xLst.Tag));
            }

            if (use.Count == 0)
                use.Add("not and id");

            d_total = RzWin.Context.Select("select base_mc_user_uid, username, sum(duration) as duration, count(unique_id) as call_count from phonecall where base_mc_user_uid in ( " + nTools.GetIn(use) + " ) and datediff(d, calldate, getdate()) = 0 group by base_mc_user_uid, username order by username ");
            d_outnd = RzWin.Context.Select("select base_mc_user_uid, username, sum(duration) as duration, count(unique_id) as call_count from phonecall where base_mc_user_uid in ( " + nTools.GetIn(use) + " ) and datediff(d, calldate, getdate()) = 0 and direction = 'Out' and abs_type not like '%dist%' group by base_mc_user_uid, username order by username");

            foreach (ListViewItem xLst in lv.Items)
            {
                String strID = SysNewMethod.ParseKeyID((String)xLst.Tag);
                try
                {
                    DataRow r = d_total.Select("base_mc_user_uid = '" + strID + "'")[0];
                    if (r != null)
                        xLst.SubItems[1].Text = Tools.Dates.FormatHMS(Tools.Data.NullFilterInt(r["duration"]));

                    r = d_outnd.Select("base_mc_user_uid = '" + strID + "'")[0];
                    if (r != null)
                        xLst.SubItems[2].Text = Tools.Dates.FormatHMS(Tools.Data.NullFilterInt(r["duration"]));
                }
                catch { }
            }
        }
        private void WriteToExcel()
        {
        }
        private void WriteMonthSection(Tools.Dates.DateRange range, String strCaption, String strTempTable, String strSignOnTable, String strUserID, String strName, bool bso, long weekcount)
        {
            WeeklySummary.AppendLine("<tr><td>" + strCaption.Replace(" ", "<br>") + "</td><td><font color=\"green\">Time</font><br><font color=\"black\">Sign Ons</font><br><font color=\"red\">Next 50</font></td>");

            long TotalCalls = 0;
            long TotalSeconds = 0;
            Double TotalSignsD = 0;

            for (int d = 0; d < 5; d++)
            {
                long lngCalls = TheContext.SelectScalarInt64("select count(*) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and " + range.GetSQL("calldate") + " and DATEPART(weekday,calldate) = " + (d + 2).ToString() + " ");
                long lngSeconds = TheContext.SelectScalarInt64("select sum(isnull(duration, 0)) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and " + range.GetSQL("calldate") + " and DATEPART(weekday,calldate) = " + (d + 2).ToString() + " ");
                long lngNextSeconds = TheContext.SelectScalarInt64("select sum(isnull(duration, 0)) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and isnull(from_call_list, 0) = 1 and " + range.GetSQL("calldate") + " and DATEPART(weekday,calldate) = " + (d + 2).ToString() + " ");
                long lngSigns = 0;

                if (bso)
                    lngSigns = TheContext.SelectScalarInt64("select count(*) from " + strSignOnTable + " where referrer = '" + RzWin.Context.Filter(strName) + "' and " + range.GetSQL("addtimestamp") + " and DATEPART(weekday, addtimestamp) = " + (d + 2).ToString() + " ");

                long avg = (lngSeconds / weekcount); //4 of any 1 weekday in a month, or less for fewer weeks in the period
                long avgnext = (lngNextSeconds / weekcount);
                Double avgsign = lngSigns / Convert.ToDouble(weekcount);
                Double avgsignr = Math.Round(avgsign, 2);

                WeeklySummary.AppendLine("<td align=\"center\"><font color=\"green\">" + nTools.FormatHM(avg) + "</font>");

                if (bso)
                    WeeklySummary.AppendLine("<br>" + avgsignr.ToString());

                WeeklySummary.AppendLine("<br><font color=\"red\">" + nTools.FormatHM(avgnext) + "</font>");

                WeeklySummary.Append("</td>");

                //TotalCalls += lngCalls;
                TotalSeconds += avg;
                TotalSignsD += avgsign;
            }

            long dailyavg = TotalSeconds / 5;
            WeeklySummary.AppendLine("<td align=\"center\"><font color=\"green\">" + nTools.FormatHM(TotalSeconds) + "</font>");
            if (bso)
            {
                Double dsr = Math.Round(TotalSignsD, 2);
                WeeklySummary.AppendLine("<br>" + dsr.ToString());
            }

            WeeklySummary.AppendLine("</td></td><td align=\"center\">" + nTools.FormatHM(dailyavg));

            if (bso)
            {
                Double tsdr = Math.Round(TotalSignsD / 5, 2);
                WeeklySummary.AppendLine("<br>" + tsdr.ToString());
            }

            WeeklySummary.AppendLine("</td>");

            WeeklySummary.AppendLine("</tr>");
        }
        private void ShowWeeklySummary()
        {
            wb.Add(WeeklySummary.ToString());
        }
        private String MakeTempPhoneTable(Tools.Dates.DateRange dr)
        {
            String strTempTable = "temp_phone_" + Tools.Strings.GetNewID();

            RzWin.Context.Execute("select unique_id, username, base_mc_user_uid, calldate, duration, from_call_list into " + strTempTable + " from phonecall where " + dr.GetSQL("calldate"));
            if (TheContext.Data.Connection.TableExists("phonecall_sys_archive"))
                RzWin.Context.Execute("insert into " + strTempTable + " ( unique_id, username, base_mc_user_uid, calldate, duration, from_call_list ) select unique_id, username, base_mc_user_uid, calldate, duration, from_call_list from phonecall_sys_archive where " + dr.GetSQL("calldate") + " and unique_id not in ( select unique_id from " + strTempTable + " )");

            return strTempTable;
        }
        private void ShowChart(DataTable d, String caption)
        {
            RzWin.Context.Reorg();
            //nCubeSeries series = new nCubeSeries();
            //series.Name = "Call Time";
            //series.DisplayType = NewMethod.Enums.CubeDataDisplayType.Seconds;

            //foreach (DataRow r in d.Rows)
            //{
            //    long l = nData.NullFilter_Long(r["duration"]);
            //    if (l > 0)
            //    {
            //        nCubePoint p = new nCubePoint();
            //        p.Name = nData.NullFilter(r["username"]) + "  " + Tools.Number.LongFormat(Tools.Data.NullFilterInt(r["call_count"])).ToString();
            //        p.Value = l;
            //        series.AllPoints.Add(p);
            //    }
            //}

            //nCubeSummary sum = new nCubeSummary();
            //sum.Name = caption;
            ////sum.YAxisInterval = 10;
            //sum.Series.Add(series);

            //nCubeSummaryView v = new nCubeSummaryView();
            //RzWin.Form.TabShow(v, caption);
            //v.CompleteLoad(TheContext.xSys, sum);
        }
        //Buttons
        private void cmdChooseDate_Click(object sender, EventArgs e)
        {
            txtDate.Text = nTools.DateFormat(frmChooseDate.ChooseDate(DateTime.Now, "Date", this.ParentForm));

        }
        private void cmdPreviousDay_Click()
        {
            //switch( tabPhone.Tab )
            //{
            //    break;
            //case 0:
            //        ChangeDayBy("d", -1)
            //    break;
            //case 1:
            //        ResetDate()
            //        SetDate(DateAdd("d", -7, CDate(txtDate.Text)))
            //        RunReport()
            //    break;
            //case 2:
            //        ResetDate()
            //        SetDate(GetPreviousMonthStart(CDate(txtDate.Text)))
            //        RunReport()
            //    break;
            //case 3:
            //        ResetDate()
            //        SetDate(GetPreviousQuarterStart(CDate(txtDate.Text)))
            //        RunReport()
            //}
        }
        private void cmdNext_Click(object sender, EventArgs e)
        {
            switch (tsTime.SelectedIndex)
            {
                case 0:
                    ChangeDayBy(1);
                    break;
                case 1:
                    ResetDate();
                    SetDate(Convert.ToDateTime(txtDate.Text).Add(TimeSpan.FromDays(7)));
                    RunReport();
                    break;
                    //case 2:
                    //        ResetDate()
                    //        SetDate(GetNextMonthStart(CDate(txtDate.Text)))
                    //        RunReport()
                    //    break;
                    //case 3:
                    //        ResetDate()
                    //        SetDate(GetNextQuarterStart(CDate(txtDate.Text)))
                    //        RunReport()
            }
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RunReport();
        }
        private void cmdStartWeek_Click()
        {
            //DateTime dtDate;

            //GetCurrentDates(dtDate)
            //txtDate.Text = nTools.DateFormat(GetWeekStart(dtDate))
            //RunReport()
        }
        private void cmdGo_Click(object sender, EventArgs e)
        {
            ResetDate();
            RunReport();
        }
        private void cmdExcel_Click()
        {
            WriteToExcel();
        }
        private void cmdIE_Click()
        {

        }
        private void cmdTestCall_Click(object sender, EventArgs e)
        {
            NewMethod.n_user yUser = GetSelectedUser();
            if (yUser == null)
                return;

            phonecall xCall = phonecall.New(TheContext);
            xCall.base_mc_user_uid = yUser.unique_id;
            xCall.username = yUser.name;
            xCall.calldate = DateTime.Now;
            xCall.duration = (5 * 60);
            xCall.companyname = "Test Call Company";
            xCall.phonenumber = "Test Number";
            xCall.direction = "Out";
            xCall.callextension = yUser.phone_ext;
            xCall.Insert(RzWin.Context);

            DateTime LastCubeDate;

            RunReport();
        }
        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            switch (tsTime.SelectedIndex)
            {
                case 0:
                    ChangeDayBy(-1);
                    break;
                case 1:
                    ResetDate();
                    SetDate(Convert.ToDateTime(txtDate.Text).Subtract(TimeSpan.FromDays(7)));
                    RunReport();
                    break;
                    //case 2:
                    //        ResetDate()
                    //        SetDate(GetNextMonthStart(CDate(txtDate.Text)))
                    //        RunReport()
                    //    break;
                    //case 3:
                    //        ResetDate()
                    //        SetDate(GetNextQuarterStart(CDate(txtDate.Text)))
                    //        RunReport()
            }
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            wb.Print();
        }
        private void cmdNow_Click(object sender, EventArgs e)
        {
            //SetDate(System.DateTime.Now);
            SetDates(DateRangeTypes.Today);
            RunReport();
        }
        private void cmdRecalc_Click(object sender, EventArgs e)
        {
            nCube.CubeATable_Day(RzWin.Context, "phonecall", "base", "calldate", "duration", "base_mc_user_uid");
            RunReport();
        }
        private void cmdList_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.StrExt(LastCallSQL))
            {
                nList l = new nList();
                RzWin.Form.TabShow(l, "Calls");
                l.ShowTemplate("calls", "phonecall");
                l.ShowData("phonecall", LastCallSQL, "calldate desc");
            }
        }
        //Control Events
        private void optHorizontal_Click()
        {
            RunReport();
        }
        private void optVertical_Click()
        {
            RunReport();
        }
        private void tabPhone_Click(int PreviousTab)
        {
            ResetDate();
            RunReport();
        }
        private void tabView_Click(int PreviousTab)
        {
            RunReport();
        }
        private void PhoneReport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InhibitSelect)
                return;

            if (lv.SelectedItems.Count == 1)
            {
                if (ts.SelectedIndex == 0)
                    RunReport();
            }
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ts.SelectedIndex <= 1)
                RunReport();
        }
        private void cboTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(cboTeams.Text))
                return;

            SelectByTeam(Tools.Strings.Mid(cboTeams.Text, 6).Trim());
            RunReport();
        }
        private void chkOnlyCustomers_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlyCustomers.Checked)
                chkOnlyProspects.Checked = false;
        }
        private void chkOnlyProspects_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnlyProspects.Checked)
                chkOnlyCustomers.Checked = false;
        }
        private void lblApplyCalls_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewMethod.n_user u = frmChooseUser.ChooseUser(RzWin.Logic.SalesPeople);
            if (u == null)
                return;

            String ext = RzWin.Leader.AskForString("Please enter the extension to apply", TheContext.GetSetting("applied_phone_ext"), "Extension");
            if (!Tools.Strings.StrExt(ext))
                return;

            TheContext.SetSetting("applied_phone_ext", ext);

            DateTime t = frmChooseDate.ChooseDate(DateTime.Now, "Date", this.ParentForm);
            if (!Tools.Dates.DateExists(t))
                return;

            String time = RzWin.Leader.AskForString("Please enter the time span", "8:00 am - 1:00 pm", "Time Span");
            if (!Tools.Strings.StrExt(time))
                return;

            Tools.Dates.DateRange range = new Tools.Dates.DateRange(DateTime.Parse(nTools.DateFormat(t) + " " + Tools.Strings.ParseDelimit(time, "-", 1).Trim()), DateTime.Parse(nTools.DateFormat(t) + " " + Tools.Strings.ParseDelimit(time, "-", 2).Trim()), true);

            String strWhere = " where callextension = '" + ext + "' and " + range.GetSQL("calldate");
            int i = TheContext.SelectScalarInt32("select count(*) from phonecall " + strWhere);
            if (i == 0)
            {
                RzWin.Leader.Tell("No calls were found for extension " + ext + " between " + range.Caption);
                return;
            }

            if (!RzWin.Leader.AreYouSure("apply " + i.ToString() + " call(s) on extension " + ext + " to " + u.name))
                return;

            RzWin.Context.Execute("update phonecall set username = '" + RzWin.Context.Filter(u.name) + "', base_mc_user_uid = '" + u.unique_id + "' " + strWhere);
            RzWin.Leader.Tell("Done.");
        }
        private void lblRefreshTotals_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateAgentTotals();
        }
        private void lblChartTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowChart(d_total, "Total Call Time " + nTools.DateFormat(DateTime.Now));
        }
        private void lblChartOND_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowChart(d_total, "Outbound, Non-Dist Call Time " + nTools.DateFormat(DateTime.Now));
        }
        private void wb_OnNavigate2(WebBrowserNavigatingEventArgs args)
        {
            //phonenumbersearch.rzl?number=3523840100

            GenericEvent ge = new GenericEvent(args.Url.ToString());
            RzWin.Context.TheSysRz.TheUrlLogic.NavigateHandle(RzWin.Context, ge);

            //this wasn't there before; wtf?
            args.Cancel = ge.Handled;
        }
        //Background Workers
        private void bgSummary_DoWork(object sender, DoWorkEventArgs e)
        {
            //set up the dates
            DateTime dtStart = nTools.GetWeekStart(WeeklyStart);
            DateTime dtEnd = dtStart.Add(TimeSpan.FromDays(4));
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(dtStart, dtEnd);

            String strSignOnTable = "temp_" + Tools.Strings.GetNewID();
            bool bso = false;
            DataTable tso = null;

            //if (Rz3App.xLogic.IsCTG)
            //{
            //    nDateRange ndsr = new nDateRange(WeeklyStart.Subtract(TimeSpan.FromDays(6 * 30)), WeeklyStart.Add(TimeSpan.FromDays(7)));
            //    bso = Rz4 Rz3App.xLogic.ImportSignOnInfo(strSignOnTable, ndsr);
            //}

            WeeklySummary = new StringBuilder();
            WeeklySummary.AppendLine("<h1>Weekly Summary Between " + dr.Caption + "</h1><hr><br>");

            WeeklySummary.AppendLine("<table>");
            WeeklySummary.AppendLine("<tr><td colspan=\"2\">Agent</td><td>Monday</td><td>Tuesday</td><td>Wednesday</td><td>Thursday</td><td>Friday</td><td>Weekly Average</td><td>Daily Average</td></tr>");

            String strTempTable = MakeTempPhoneTable(new Tools.Dates.DateRange(WeeklyStart.Subtract(TimeSpan.FromDays(6 * 30)), WeeklyStart.Add(TimeSpan.FromDays(7))));

            long TotalCalls = 0;
            long TotalSeconds = 0;
            long NextSeconds = 0;
            long TotalSigns = 0;

            foreach (String strUserID in WeeklyUserIDs)
            {
                String strName = NewMethod.n_user.TranslateIDToName(RzWin.Context, strUserID);
                WeeklySummary.AppendLine("<tr><td colspan=\"8\"><b>" + strName + "</b></td></tr>");
                WeeklySummary.AppendLine("<tr><td>This Week</td><td><font color=\"green\">Time</font><br><font color=\"blue\">Calls</font><br><font color=\"black\">Sign Ons</font><br><font color=\"red\">Next 50</font></td>");

                TotalCalls = 0;
                TotalSeconds = 0;
                TotalSigns = 0;
                NextSeconds = 0;

                for (int d = 0; d < 5; d++)
                {
                    DateTime cd = dtStart.Add(TimeSpan.FromDays(d));
                    long lngCalls = TheContext.SelectScalarInt64("select count(*) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and datediff(d, calldate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(cd) + "' as datetime)) = 0 ");
                    long lngSeconds = TheContext.SelectScalarInt64("select sum(isnull(duration, 0)) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and datediff(d, calldate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(cd) + "' as datetime)) = 0 ");
                    long lngNextSeconds = TheContext.SelectScalarInt64("select sum(isnull(duration, 0)) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and isnull(from_call_list, 0) = 1 and datediff(d, calldate, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(cd) + "' as datetime)) = 0 ");

                    long lngSigns = 0;

                    if (bso)
                        lngSigns = TheContext.SelectScalarInt64("select count(*) from " + strSignOnTable + " where referrer = '" + RzWin.Context.Filter(strName) + "' and datediff(d, addtimestamp, cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(cd) + "' as datetime)) = 0 ");

                    WeeklySummary.AppendLine("<td align=\"center\"><font color=\"green\">" + nTools.FormatHM(lngSeconds) + "</font><br><font color=\"blue\">" + Tools.Number.LongFormat(lngCalls) + "</font>");

                    if (bso)
                        WeeklySummary.AppendLine("<br>" + Tools.Number.LongFormat(lngSigns));

                    WeeklySummary.AppendLine("<br><font color=\"red\">" + nTools.FormatHM(lngNextSeconds) + "</font>");

                    WeeklySummary.AppendLine("</td>");

                    TotalCalls += lngCalls;
                    TotalSeconds += lngSeconds;
                    TotalSigns += lngSigns;

                    //WeeklySummary.AppendLine("<tr><td>" + cd.DayOfWeek.ToString() + " " + cd.Month.ToString() + "/" + cd.Day.ToString() + "</td><td align=\"right\">" + Tools.Number.LongFormat(lngCalls) + "</td><td align=\"right\">" + Tools.Dates.FormatHMS(lngSeconds) + "</td></tr>");
                }

                long dailyavg = TotalSeconds / 5;
                Double dailysignavg = Math.Round(TotalSigns / 5.0, 1);
                long dailyavgcalls = TotalCalls / 5;

                WeeklySummary.AppendLine("<td align=\"center\"><font color=\"green\">" + nTools.FormatHM(TotalSeconds) + "</font><br><font color=\"blue\">" + Tools.Number.LongFormat(TotalCalls) + "</font>");
                if (bso)
                    WeeklySummary.AppendLine("<br>" + Tools.Number.LongFormat(TotalSigns));

                WeeklySummary.AppendLine("</td>");

                WeeklySummary.AppendLine("<td align=\"center\"><font color=\"green\">" + nTools.FormatHM(dailyavg) + "</font><br><font color=\"blue\">" + Tools.Number.LongFormat(dailyavgcalls) + "</font>");
                if (bso)
                    WeeklySummary.AppendLine("<br>" + dailysignavg.ToString());

                WeeklySummary.AppendLine("</td>");
                WeeklySummary.AppendLine("</tr>");


                //get the first part of this month               
                Tools.Dates.DateRange between = new Tools.Dates.DateRange(nTools.GetMonthStart(dtStart), dtStart.Subtract(TimeSpan.FromDays(3))); // the start of the month to before the week shown above

                TimeSpan t = between.EndDate.Subtract(between.StartDate);
                if (t.TotalDays > 0)
                {
                    int weeks = Convert.ToInt32(t.TotalDays) / 7;
                    if (weeks == 0)
                        weeks = 1;
                    WriteMonthSection(between, "Between " + between.Caption, strTempTable, strSignOnTable, strUserID, strName, bso, 4);
                }

                //start of last month
                DateTime ms = nTools.GetMonthStart(dtStart.Subtract(TimeSpan.FromDays(30)));

                //go back 3 months
                for (int m = 0; m < 3; m++)
                {
                    DateTime mstart = nTools.GetMonthStart(ms);
                    DateTime mend = nTools.GetMonthEnd(ms);
                    Tools.Dates.DateRange range = new Tools.Dates.DateRange(mstart, mend);

                    WriteMonthSection(range, nTools.GetMonthName(mstart.Month), strTempTable, strSignOnTable, strUserID, strName, bso, 4);

                    ms = nTools.GetMonthStart(ms.Subtract(TimeSpan.FromDays(1)));
                }

                WeeklySummary.AppendLine("<tr><td colspan=\"7\">&nbsp</td></tr>");
            }

            WeeklySummary.AppendLine("</table><br><br>");
            WeeklySummary.AppendLine("<font color=\"green\">Green=Phone Time</font><br><font color=\"blue\">Blue=Call Count</font><br><font color=\"black\">Black=Sign Ons</font><br>");
            TheContext.Data.Connection.DropTable(strTempTable);

            if (RzWin.User.IsDeveloper())
            {
                WeeklySummary.AppendLine("<br><br>Sign Ons: " + strSignOnTable + "<br>");
            }

        }
        private void bgSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowWeeklySummary();
            throb.HideThrobber();
        }
        private void bgYearly_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dtStart = nTools.GetMonthStart(WeeklyStart.Subtract(TimeSpan.FromDays(365)));
            DateTime dtEnd = nTools.GetMonthEnd(WeeklyStart);
            Tools.Dates.DateRange dr = new Tools.Dates.DateRange(dtStart, dtEnd);
            WeeklySummary = new StringBuilder();
            WeeklySummary.AppendLine("<h1>Yearly Summary Between " + dr.Caption + "</h1><hr><br>");

            WeeklySummary.AppendLine("<table>");

            String strTempTable = MakeTempPhoneTable(dr);

            foreach (String strUserID in WeeklyUserIDs)
            {
                String strName = NewMethod.n_user.TranslateIDToName(RzWin.Context, strUserID);
                WeeklySummary.AppendLine("<tr><td colspan=\"3\"><b>" + strName + "</b></td></tr>");

                long TotalCalls = 0;
                long TotalSeconds = 0;

                for (int d = 0; d < 12; d++)
                {
                    Tools.Dates.DateRange range = new Tools.Dates.DateRange(nTools.GetMonthStart(dtStart), nTools.GetMonthEnd(dtStart));
                    dtStart = nTools.GetMonthStart(dtStart.Add(TimeSpan.FromDays(32)));
                    long lngCalls = TheContext.SelectScalarInt64("select count(*) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and " + range.GetSQL("calldate") + " ");
                    long lngSeconds = TheContext.SelectScalarInt64("select sum(isnull(duration, 0)) from " + strTempTable + " where base_mc_user_uid = '" + strUserID + "' and " + range.GetSQL("calldate") + " ");

                    //String strSQL = "select * from " + strTable + " where base_mc_user_uid = '" + strUserID + "' order by hour_index";
                    //DataTable dx = Rz3App.RzWin.Context.Select(strSQL);

                    //if (Tools.Data.DataTableExists(dx))
                    //{
                    //    DataRow r = dx.Rows[0];

                    //    lngCalls = nData.NullFilter_Long(r["total_count"]);
                    //    lngSeconds = nData.NullFilter_Long(r["total_volume"]);
                    //}


                    TotalCalls += lngCalls;
                    TotalSeconds += lngSeconds;



                    WeeklySummary.AppendLine("<tr><td>" + range.StartDate.Month.ToString() + "/" + range.StartDate.Year.ToString() + "</td><td align=\"right\">" + Tools.Number.LongFormat(lngCalls) + "</td><td align=\"right\">" + Tools.Dates.FormatHMS(lngSeconds) + "</td></tr>");
                }

                long avg = TotalSeconds / 260;  //working days

                WeeklySummary.AppendLine("<tr><td><b>Total</b></td><td align=\"right\"><b>" + Tools.Number.LongFormat(TotalCalls) + "</b></td><td align=\"right\"><b>" + nTools.FormatDHMS(TotalSeconds) + "</b></td></tr>");
                WeeklySummary.AppendLine("<tr><td colspan=\"3\"><font color=\"blue\">Daily Average: " + Tools.Dates.FormatHMS(avg) + "</font></td></tr>");
                WeeklySummary.AppendLine("<tr><td colspan=\"3\">&nbsp</td></tr>");
            }

            WeeklySummary.AppendLine("</table><br>");
            TheContext.Data.Connection.DropTable(strTempTable);
        }
        private void bgYearly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wb.Add(WeeklySummary.ToString());
            throb.HideThrobber();
        }


        private DateTime GetDate(DateRangeTypes dr, Boolean bEnd)
        {
            DateTime dt = DateTime.Now;
            if (dr.Equals(DateRangeTypes.This))
                return GetDate(DateTime.Now, dr, bEnd);
            else if (dr.Equals(DateRangeTypes.Next))
            {
                if (bEnd)
                    dt = dtEnd.GetValue_Date();
                else
                    dt = dtStart.GetValue_Date();
                if (dt.Month == DateTime.Now.Month)
                    return GetDate(DateTime.Now, DateRangeTypes.Next, bEnd);
                return GetDate(dt, dr, bEnd);
            }
            else if (dr.Equals(DateRangeTypes.Last))
            {
                if (bEnd)
                    dt = dtEnd.GetValue_Date();
                else
                    dt = dtStart.GetValue_Date();
                return GetDate(dt, dr, bEnd);
            }
            else
                return GetDate(DateTime.Now, dr, bEnd);
        }
        private DateTime GetDate(DateTime dt, DateRangeTypes dr, Boolean bEnd)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            Int32 month = 0;
            Int32 year = 0;
            switch (dr)
            {
                case DateRangeTypes.This:
                    start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, GetMonthEnd(DateTime.Now.Month, DateTime.Now.Year));
                    break;
                case DateRangeTypes.Last:
                    month = dt.Month - 1;
                    year = dt.Year;
                    if (month <= 0)
                    {
                        month = 12;
                        year -= 1;
                    }
                    start = new DateTime(year, month, 1);
                    end = new DateTime(year, month, GetMonthEnd(month, year));
                    break;
                case DateRangeTypes.Next:
                    month = dt.Month + 1;
                    year = dt.Year;
                    if (month > 12)
                    {
                        month = 1;
                        year += 1;
                    }
                    start = new DateTime(year, month, 1);
                    end = new DateTime(year, month, GetMonthEnd(month, year));
                    break;
                case DateRangeTypes.Today:
                    start = DateTime.Today;
                    end = DateTime.Now;
                    break;
            }
            if (bEnd)
                return end;
            return start;
        }
        private Int32 GetMonthEnd(Int32 month, Int32 year)
        {
            switch (month)
            {
                case 1: //Jan
                    return 31;
                case 2: //Feb
                    if (DateTime.IsLeapYear(year))
                        return 29;
                    else
                        return 28;
                case 3: //March
                    return 31;
                case 4: //April
                    return 30;
                case 5: //May
                    return 31;
                case 6: //June
                    return 30;
                case 7: //July
                    return 31;
                case 8: //Aug
                    return 31;
                case 9: //Sept
                    return 30;
                case 10: //Oct
                    return 31;
                case 11: //Nov
                    return 30;
                case 12: //Dec
                    return 31;
                default:
                    return 31;
            }
        }
        //Buttons
        private void cmdLastMonth_Click(object sender, EventArgs e)
        {
            SetDates(DateRangeTypes.Last);
        }
        private void cmdThisMonth_Click(object sender, EventArgs e)
        {
            SetDates(DateRangeTypes.This);
        }
        private void cmdNextMonth_Click(object sender, EventArgs e)
        {
            SetDates(DateRangeTypes.Next);
        }
        //Enums
        private enum DateRangeTypes
        {
            Last = 0,
            This = 1,
            Next = 2,
            Today = 3
        }
    }
    public class UserPhoneHandle : IComparable
    {
        public NewMethod.n_user xUser;
        public long total_volume;
        public long total_count;

        public UserPhoneHandle(NewMethod.n_user u, long v, long c)
        {
            xUser = u;
            total_volume = v;
            total_count = c;
        }
        public int CompareTo(Object obj)
        {
            try
            {
                UserPhoneHandle p = (UserPhoneHandle)obj;
                return total_volume.CompareTo(p.total_volume) * -1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
