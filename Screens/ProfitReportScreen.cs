using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

//using Dundas.Charting.WinControl;
using Tools;
using ToolsWin;
using NewMethod;
using Core;
using Tools.Database;
using Rz5.Reports;

namespace Rz5
{
    public partial class ProfitReportScreen : UserControl
    {
        //Public Variables
        public String LastSQL;
        public String LastRMASQL;
        public bool boolIncludeComplete = false;
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        //Private Variables
        protected Report CurrentCore;
        protected ReportTarget CurrentTarget;

        //Constructors
        public ProfitReportScreen()
        {
            InitializeComponent();
        }
        //Public Functions
        public virtual void CompleteStructure()
        {
            wb.Clear();
            dtStart.SetValue(nTools.GetDate_ThisMonthStart());
            dtEnd.SetValue(DateTime.Now);
            LoadAgentTeams();
            boolIncludeComplete = false;

            cmdThisMonth.Text = Tools.Dates.GetMonthName(DateTime.Now.Month);
            cmdLastMonth.Text = Tools.Dates.GetMonthName(Tools.Dates.GetPreviousMonthStart(DateTime.Now).Month);

            if (!RzWin.User.SuperUser)
                cboAgent.Text = "Agent: " + RzWin.User.name;
        }
        public void SetDateRange(Tools.Dates.DateRange d)
        {
            dtStart.SetValue(d.StartDate);
            dtEnd.SetValue(d.EndDate);
        }
        public void SetUserByID(String strID)
        {
            NewMethod.n_user u = (NewMethod.n_user)TheContext.xSys.Users.GetByID(strID);
            if (u == null)
                return;

            cboAgent.Text = "Agent: " + u.name;
        }
        public void SetTeamByID(String strID)
        {
            n_team t = (n_team)TheContext.xSys.Teams.GetByID(strID);
            if (t == null)
                return;

            cboAgent.Text = "Team: " + t.name;
        }
        public bool RunReport()
        {
            return RunReport(false, ArgsGet());
        }

        protected ProfitReportArgs ArgsGet()
        {
            ProfitReportArgs args = ArgsObjectCreate();
            args.DateRange.TheRange.StartDate = dtStart.GetValue_Date();
            args.DateRange.TheRange.EndDate = dtEnd.GetValue_Date();
            args.UserIds = new List<string>();
            ArrayList colUsers = GetUserIDCollection();
            if (colUsers != null)
            {
                foreach (String userid in colUsers)
                {
                    args.UserIds.Add(userid);
                }
            }


            args.xData = (DataConnectionSqlServer)RzWin.Context.Data.Connection;
            return args;
        }

        protected virtual ProfitReportArgs ArgsObjectCreate()
        {
            return new ProfitReportArgs(RzWin.Context);
        }

        public bool RunReport(bool syncronously)
        {
            return RunReport(syncronously, ArgsGet());
        }

        public bool RunReport(bool syncronously, ProfitReportArgs args)
        {
            if (!syncronously)
            {
                if (bg.IsBusy)
                    return true;
            }

            if (!args.ValidCheck(RzWin.Context))
                return false;

            if (CurrentCore != null)
            {
                DisposeCurrentCore();
            }

            currentArgs = args;
            CurrentCore = RzWin.Context.TheSysRz.TheProfitLogic.ProfitReportCreate(RzWin.Context);
            return RunReport(syncronously, args, new ReportTargetHtml(true));
        }

        protected ProfitReportArgs currentArgs;
        public virtual bool RunReport(bool syncronously, ProfitReportArgs args, ReportTarget t)
        {
            CurrentTarget = t;

            wb.ReloadWB();
            wb.Add("<font face=\"Calibri\">Calculating...</font>");

            currentArgs = args;
            throb.ShowThrobber();

            if (syncronously)
            {
                RzWin.Leader.Comment("Running synchronously...");
                ActuallyRunReport();
                ActuallyFinishReport();  //!args.IncludeChartLinks
                RzWin.Leader.Comment("Run complete...");
            }
            else
            {
                bg.RunWorkerAsync();
            }

            RzWin.Context.xUser.SetActivity(RzWin.Context);
            return true;
        }

        public virtual void LoadAgentTeams()
        {

            String defaultValue = "";
            cboAgent.Items.Clear();
            foreach (String s in RzWin.Context.TheSysRz.TheUserLogicRz.AgentOptionsListSales(RzWin.Context, true, ref defaultValue))
            {
                cboAgent.Items.Add(s);
            }
            cboAgent.Text = defaultValue;
        }

        public virtual ArrayList GetUserIDCollection()
        {
            String strType;
            String strName;
            n_team xTeam;
            NewMethod.n_user yUser;
            ArrayList colHold;
            colHold = new ArrayList();
            switch (cboAgent.Text.ToLower().Trim())
            {
                case "<all>":
                    return colHold;
                case "":
                    return colHold;
                default:
                    strType = Tools.Strings.ParseDelimit(cboAgent.Text, ":", 1).Trim();
                    strName = Tools.Strings.ParseDelimit(cboAgent.Text, ":", 2).Trim();
                    switch (strType.Trim().ToLower())
                    {
                        case "agent":
                            yUser = NewMethod.n_user.GetByName(RzWin.Context, strName);
                            if (yUser == null)
                            {
                                RzWin.Leader.Tell("The user '" + strName + "' could not be found in the system.");
                                return new ArrayList();
                            }
                            colHold.Add(yUser.unique_id);
                            break;
                        case "team":
                            xTeam = n_team.GetByName(RzWin.Context, strName);
                            if (xTeam == null)
                            {
                                RzWin.Leader.Tell("The team '" + strName + "' could not be found.");
                                return new ArrayList();
                            }
                            return xTeam.GetUserIDs(RzWin.Context);
                        default:
                            return new ArrayList();
                    }
                    return colHold;
            }
        }
        public void ReportByDealID(String strID)
        {
            //ReportTarget xTarget = new ReportTarget();
            //String strKey = "";
            //RunReport(false, strID, null, null, false);
        }
        public void ReportByUserID(String strID, Tools.Dates.DateRange dr)
        {
            cboAgent.Text = "Agent: " + TheContext.xSys.TranslateUserIDToName(strID);
            dtStart.SetValue(dr.StartDate);
            dtEnd.SetValue(dr.EndDate);
            RunReport();
        }
        //Private Functions
        protected virtual void DoResize()
        {
            try
            {
                pb.Left = wb.Left;
                pb.Top = this.ClientRectangle.Height - pb.Height;
                pb.Width = this.ClientRectangle.Width;
                gbOptions.Left = 0;
                gbOptions.Top = 0;
                gbOptions.Height = this.ClientRectangle.Height - pb.Height;
                wb.Top = 0;
                wb.Left = gbOptions.Right;
                wb.Width = this.ClientRectangle.Width - wb.Left;
                wb.Height = this.ClientRectangle.Height - pb.Height;

            }
            catch (Exception)
            {
            }
        }
        private void CompleteDispose()
        {
            try
            {
                DisposeCurrentCore();
            }
            catch { }
        }
        protected void DisposeCurrentCore()
        {
            try
            {
                CurrentCore.Dispose();
                CurrentCore = null;
            }
            catch { }
        }
        private void ShowOneMonthlyChart(DataRow r)
        {
            RzWin.Context.Reorg();
            //String name = nData.NullFilter_String(r["name"]);
            //nCubeSeries series = new nCubeSeries();
            //series.Name = "Profit";
            //series.DisplayType = NewMethod.Enums.CubeDataDisplayType.ReallyBigDollars;

            //foreach (DataColumn c in r.Table.Columns)
            //{
            //    if (c.Caption.StartsWith("profit_") && !Tools.Strings.HasString(c.Caption, "nopo"))
            //    {
            //        nCubePoint p = new nCubePoint();
            //        p.Name = Tools.Strings.ParseDelimit(c.Caption, "profit_", 2).Trim();
            //        p.Value = nData.NullFilter_Float(r[c.Caption]);
            //        series.AllPoints.Add(p);
            //    }
            //}

            //nCubeSummary sum = new nCubeSummary();
            //sum.Name = name + " Profit";
            //sum.YAxisInterval = 10000;
            //sum.Series.Add(series);

            //nCubeSummaryView v = new nCubeSummaryView();
            //RzWin.Form.TabShow(v, "Profit for " + name);
            //v.CompleteLoad(TheContext.xSys, sum);
        }

        private List<ProfitReportSectionUser> SortByProfit(List<ProfitReportSectionUser> totals)
        {
            //don't destroy the original collection
            List<ProfitReportSectionUser> totalcopy = new List<ProfitReportSectionUser>(totals);

            List<ProfitReportSectionUser> ret = new List<ProfitReportSectionUser>();
            while (totalcopy.Count > 0)
            {
                ProfitReportSectionUser t = GetHightestProfit(totalcopy);
                totalcopy.Remove(t);
                ret.Add(t);
            }
            return ret;
        }
        private ProfitReportSectionUser GetHightestProfit(List<ProfitReportSectionUser> a)
        {
            ProfitReportSectionUser winner = null;
            Double dw = -10000000000;
            foreach (ProfitReportSectionUser t in a)
            {
                if (t.TotalProfit.Value > dw)
                {
                    winner = t;
                    dw = t.TotalProfit.Value;
                }
            }
            return winner;
        }

        private void MarkOrdersAsCompleted()
        {
            //try
            //{
            //    if (CurrentCore == null)
            //        return;
            //    if (CurrentCore.AllLines == null)
            //        return;
            //    if (CurrentCore.AllLines.Count <= 0)
            //        return;
            //    ArrayList a = new ArrayList();
            //    foreach (profit_line p in CurrentCore.AllLines)
            //    {
            //        if (!Tools.Strings.StrExt(p.the_ordhed_uid))
            //            continue;
            //        if (a.Contains(p.the_ordhed_uid))
            //            continue;
            //        a.Add(p.the_ordhed_uid);
            //    }
            //    if (a.Count > 0)
            //        FlagOrdersComplete(nTools.GetIn(a));
            //}
            //catch { }
        }
        private void FlagOrdersComplete(string inn)
        {
            if (!Tools.Strings.StrExt(inn))
                return;
                
            RzWin.Context.Execute("update ordhed set is_commission_paid = 1 where unique_id in (" + inn + ")");
            RzWin.Leader.Tell("Done");
        }
        private void CompareVSPastReport()
        {
            //try
            //{
            //    ArrayList a = ((n_sys_Rz4)Rz3App.xMainForm.TheContextNM.TheSys).xData.GetScalarArray("select top 44 name from dbo.sysobjects where xtype = 'U' and name like 'DailyProfitReport_%' order by cast(replace(replace(name,'DailyProfitReport_',''),'_','/')as datetime) desc");
            //    if (a == null)
            //        return;
            //    if (a.Count <= 0)
            //        return;
            //    String s = frmChooseStringFromArray.ChooseStringFromArray(a, "Please choose past report to compare to:", this.ParentForm);
            //    if (!Tools.Strings.StrExt(s))
            //        return;
            //    if (!Rz3App.xSys.xData.TableExists(s))
            //        return;
            //    ArrayList colUsers = GetUserIDCollection();
            //    if (colUsers.Count <= 0 && !Rz3App.xUser.SuperUser)
            //    {
            //        RzWin.Leader.ShowNoRight();
            //        return;
            //    }
            //    nDateRange xDate = new nDateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            //    if (!Tools.Dates.DateExists(xDate.StartDate))
            //    {
            //        RzWin.Leader.Tell("Please select a valid start date before continuing.");
            //        return;
            //    }
            //    if (!Tools.Dates.DateExists(xDate.EndDate))
            //    {
            //        RzWin.Leader.Tell("Please select a valid end date before continuing.");
            //        return;
            //    }

            //    ProfitReportArgs args = new ProfitReportArgs();
            //    args.DateRange = xDate;
            //    args.UserIds = new List<string>();
            //    foreach (String userid in colUsers)
            //    {
            //        args.UserIds.Add(userid);
            //    }

            //ProfitReport CurrentCore = new ProfitReport(args);
            //CurrentCore.Calculate(context);
            //ReportTargetHtml t = new ReportTargetHtml();
            //t.Render(CurrentCore);
            ////if (args.DropTables)
            ////    CurrentCore.DropReportTables(context);
            //return CurrentCore;

            //    ProfitReport c = ProfitReport.GetReportAsProfitReportCore( GetReportAsProfitReportCore(RzWin.Context, xDate, colUsers, false, false);
            //    if (c == null)
            //        return;
            //    if (c.AllLines == null)
            //        return;
            //    ArrayList deleted = new ArrayList();
            //    ArrayList added = new ArrayList();
            //    ArrayList changed = new ArrayList();
            //    foreach (profit_line p in c.AllLines)
            //    {
            //        string where = GetWhere(p);
            //        if (!Tools.Strings.StrExt(where))
            //            continue;
            //        string id = ((n_sys_Rz4)Rz3App.xMainForm.TheContextNM.TheSys).xData.GetScalar_String("select unique_id from " + s + " where " + where);
            //        if (!Tools.Strings.StrExt(id))
            //        {
            //            id = ((n_sys_Rz4)Rz3App.xMainForm.TheContextNM.TheSys).xData.GetScalar_String("select unique_id from " + s + " where base_orddet_uid = '" + p.base_orddet_uid + "'");
            //            if (!Tools.Strings.StrExt(id))
            //                added.Add(p);
            //            else
            //                changed.Add(p);
            //        }
            //        else
            //            deleted.Add(id);
            //    }
            //    string sin = "";
            //    foreach (string ss in deleted)
            //    {
            //        if (Tools.Strings.StrExt(sin))
            //            sin += ",'" + ss + "'";
            //        else
            //            sin += "'" + ss + "'";
            //    }
            //    deleted = new ArrayList();
            //    if (Tools.Strings.StrExt(sin))
            //        deleted = ((n_sys_Rz4)Rz3App.xMainForm.TheContextNM.TheSys).QtC("profit_line", "select * from " + s + " where unique_id not in (" + sin + ")");
            //    else
            //        deleted = ((n_sys_Rz4)Rz3App.xMainForm.TheContextNM.TheSys).QtC("profit_line", "select * from " + s);
            //    string current_html_add = GetHTMLFromLines(added);
            //    string current_html_change = GetHTMLFromLines(changed);
            //    string past_html = GetHTMLFromLines(deleted);
            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine("<html><body>");
            //    sb.AppendLine("<table border=\"1\" width=\"100%\">");
            //    sb.AppendLine("  <tr>");
            //    sb.AppendLine("    <td width=\"100%\">Current Report Showing Added Lines</td>");
            //    sb.AppendLine("  </tr>");
            //    sb.AppendLine("  <tr>");
            //    sb.AppendLine("    <td width=\"100%\">" + current_html_add + "</td>");
            //    sb.AppendLine("  </tr>");
            //    sb.AppendLine("</table>");
            //    sb.AppendLine("<p></p>");
            //    sb.AppendLine("<table border=\"1\" width=\"100%\">");
            //    sb.AppendLine("  <tr>");
            //    sb.AppendLine("    <td width=\"100%\">Current Report Showing Updated Lines</td>");
            //    sb.AppendLine("  </tr>");
            //    sb.AppendLine("  <tr>");
            //    sb.AppendLine("    <td width=\"100%\">" + current_html_change + "</td>");
            //    sb.AppendLine("  </tr>");
            //    sb.AppendLine("</table>");
            //    sb.AppendLine("<p></p>");
            //    sb.AppendLine("<table border=\"1\" width=\"100%\">");
            //    sb.AppendLine("  <tr>");
            //    sb.AppendLine("    <td width=\"100%\">Past Report Showing Deleted Lines</td>");
            //    sb.AppendLine("  </tr>");
            //    sb.AppendLine("  <tr>");
            //    sb.AppendLine("    <td width=\"100%\">" + past_html + "</td>");
            //    sb.AppendLine("  </tr>");
            //    sb.AppendLine("</table>");
            //    sb.AppendLine("</body></html>");

            //    //Couldn't get this to work
            //    //wb.Clear();
            //    //wb.Add(sb.ToString());
                                
            //    Tools.Files.SaveFileAsString(Tools.Folder.GetAppPath() + "report_check.html", sb.ToString());
            //    Tools.Files.OpenFileInDefaultViewer(Tools.Folder.GetAppPath() + "report_check.html");
            //}
            //catch { }
        }
        private string GetHTMLFromLines(ArrayList lines)
        {
            StringBuilder sb = new StringBuilder ();
            if (lines == null)
                return "None";
            sb.AppendLine("<table border=\"1\" width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Order Date</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Order Type</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Order Number</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Customer Name</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Part Number</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Quantity</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Unit Price</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Unit Cost</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Total Price</font></td>");
            sb.AppendLine("    <td width=\"4%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Total Cost</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Total Volume</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Profit</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Ship Via</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Terms</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Vendor Name</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Customer Email</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Stock</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Problem</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Warning</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Priority</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Commission</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Paid</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Is Priority Rfq</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Buy Type</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Abs Type</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Email Domain</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">User Name</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\"> Companycontact Uid</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\"> Orddet Uid</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font FACE=\"Consolas\" SIZE=\"2\" COLOR=\"#008000\">Date Created</font></td>");
            sb.AppendLine("  </tr>");
            foreach (profit_line p in lines)
            {
                sb.AppendLine(p.GetClipHTML(RzWin.Context));
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        private string GetWhere(profit_line p)
        {
            string s = "";
            try
            {
                if (p == null)
                    return "";
                CoreClassHandle c = RzWin.Context.Sys.CoreClassGet("profit_line");
                foreach (CoreVarValAttribute prop in c.VarValsGet())
                {
                    switch (prop.Name)
                    {
                        case "unique_id":
                        case "grid_color":
                        case "icon_index":
                        case "the_profit_line_uid":
                        case "date_modified":
                        case "date_created":
                            break;
                        default:
                            if (Tools.Strings.StrExt(s))
                                s += " and " + prop.Name + " = " + GetPropValue(p.IGet(prop.Name), prop);
                            else
                                s += " " + prop.Name + " = " + GetPropValue(p.IGet(prop.Name), prop);
                            break;
                    }
                }
            }
            catch { }
            return s;
        }
        private string GetPropValue(object value, CoreVarValAttribute p)
        {
            string s = "";
            try
            {
                if (p == null)
                    return "";
                switch (p.TheFieldType)
                {
                    case FieldType.Boolean:
                        if (value is Boolean)
                        {
                            if ((bool)value)
                                s = "1";
                            else
                                s = "0";
                        }
                        break;
                    case FieldType.Double:
                    case FieldType.Int32:
                    case FieldType.Int64:
                        s = value.ToString();
                        break;
                    default:
                        s = "'" + nData.SyntaxFilterGeneral(value.ToString()) + "'";
                        break;
                }
            }
            catch { }
            return s;
        }
        protected virtual void DoPrint()
        {
            wb.Print();
        }
        //Buttons
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DoPrint();
        }
        private void cmdView_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        private void cmdMonthly_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("run a monthly summary"))
                return;

            DateTime start = nTools.GetMonthStart(dtStart.GetValue_Date());
            DateTime end = nTools.GetMonthEnd(dtEnd.GetValue_Date());
            int month = start.Month;
            int year = start.Year;
            DateTime d = new DateTime(year, month, 1);
            String strTable = "temp_monthly_profit_" + Tools.Strings.GetNewID();
            RzWin.Context.Execute("drop table " + strTable, true);
            RzWin.Context.Execute("create table " + strTable + "(name varchar(255))");

            RzWin.Leader.StartPopStatus("Calculating by month...");
            ArrayList colUsers = GetUserIDCollection();
            if (colUsers.Count == 0 && !RzWin.User.SuperUser)
            {
                RzWin.Leader.ShowNoRight();
                return;
            }

            String profit_fields = "";
            String profit_fields_nopo = "";

            while (d <= end)
            {
                try
                {
                    String strField = "_" + d.Year.ToString() + "_" + d.Month.ToString();
                    RzWin.Leader.Comment("Calculating " + strField);
                    RzWin.Context.Execute("alter table " + strTable + " add profit" + strField + " float");
                    RzWin.Context.Execute("alter table " + strTable + " add profit_nopo" + strField + " float");

                    profit_fields += "profit" + strField + ", ";
                    profit_fields_nopo += "profit_nopo" + strField + ", ";

                    RzWin.Leader.Comment("Running report for " + nTools.GetMonthName(d.Month) + " " + d.Year.ToString() + "...");

                    ProfitReportArgs args = ArgsGet();
                    args.DateRange.TheRange.StartDate = d;
                    args.DateRange.TheRange.EndDate = nTools.GetMonthEnd(d);

                    RunReport(true, args);

                    //array of totals
                    if (CurrentCore.Totals.Count == 0 && colUsers.Count == 1)
                    {
                        String sn = TheContext.xSys.TranslateUserIDToName((String)colUsers[0]);
                        if (Tools.Strings.StrExt(sn))
                        {
                            String s = RzWin.Context.SelectScalarString("select max(name) from " + strTable + " where name = '" + RzWin.Context.Filter(sn) + "'");
                            if (!Tools.Strings.StrExt(s))
                                RzWin.Context.Execute("insert into " + strTable + " (name) values ('" + RzWin.Context.Filter(sn) + "')");
                        }
                    }
                    else
                    {
                        foreach (ProfitReportSectionUser t in CurrentCore.SectionsList)
                        {
                            String s = RzWin.Context.SelectScalarString("select max(name) from " + strTable + " where name = '" + RzWin.Context.Filter(t.UserName) + "'");
                            if (!Tools.Strings.StrExt(s))
                                RzWin.Context.Execute("insert into " + strTable + " (name) values ('" + RzWin.Context.Filter(t.UserName) + "')");
                            RzWin.Context.Execute("update " + strTable + " set profit" + strField + " = " + t.TotalProfit.Value.ToString() + ", profit_nopo" + strField + " = 0 where name = '" + RzWin.Context.Filter(t.UserName) + "'");
                        }
                    }

                    month++;
                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                    d = new DateTime(year, month, 1);
                }
                catch (Exception ex)
                {
                    RzWin.Leader.Tell("Error: " + ex.Message);
                }
            }

            if (Environment.MachineName == "LAPTOP08")
            {
                String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "temp_profit_report.csv";
                long l = 0;
                TheContext.Data.Connection.ExportCSV("select * from " + strTable + " order by name", file, ref l);
                Tools.FileSystem.PopTextFile(file);
            }
            else
                Tools.Data.SqlToExcel(RzWin.Context.Data.Connection, "select * from " + strTable + " order by name");

            if (RzWin.User.IsDeveloper())
            {
                Tools.FileSystem.PopText("Done: Table= " + strTable + "\r\n" + profit_fields + "\r\n" + profit_fields_nopo);
            }

            //if (chkIncludeChart.Checked)
            //{
            //    DataTable dx = Rz3App.RzWin.Context.Select("select * from " + strTable + " order by name");
            //    if (Tools.Data.DataTableExists(dx))
            //    {
            //        foreach (DataRow r in dx.Rows)
            //        {
            //            ShowOneMonthlyChart(r);
            //        }
            //    }
            //}

            RzWin.Leader.Comment("Done.");
            RzWin.Leader.StopPopStatus(true);
        }
        //Control Events
        private void ProfitReport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void wb_OnNavigate(GenericEvent e)
        {
            NavigateHandle(e);
        }

        protected virtual void NavigateHandle(GenericEvent e)
        {                
            if (Tools.Strings.HasString(e.Message, "managedomain.rzl"))
            {
                e.Handled = true;

                String x = Tools.Strings.ParseDelimit(e.Message, "?", 2);
                String[] pars = Tools.Strings.Split(x, "&");

                String dom = "";
                String con = "";
                String strLine = "";

                foreach (String p in pars)
                {
                    if( p.StartsWith("email") )
                        dom = Tools.Strings.ParseDelimit(p, "=", 2).Replace("_dot_", ".");
                    else if( p.StartsWith("contactid=") )
                        con = Tools.Strings.ParseDelimit(p, "=", 2);
                    else if( p.StartsWith("lineid") )
                        strLine = Tools.Strings.ParseDelimit(p, "=", 2);
                }

                //if (Tools.Strings.StrExt(dom) || Tools.Strings.StrExt(con))
                //    RzWin.Logic.ShowDomainMenu(dom, con, strLine);
                //else
                //{
                //    TheContext.TheLeader.TellTemp("This order has no linked contact and no email address.");
                //}
            }
            else if (e.Message.ToLower().Contains("show.rzl"))
            {
                e.Handled = true;
                String q = Tools.Strings.ParseDelimit(e.Message, "?", 2);
                string cid = Tools.Strings.ParseDelimit(q, "&", 1).Replace("cid=", "").Trim();
                string uid = Tools.Strings.ParseDelimit(q, "&", 2).Replace("uid=", "").Trim();
                if (!Tools.Strings.StrExt(cid))
                    return;
                if (!Tools.Strings.StrExt(uid))
                    return;
                RzWin.Context.Show(RzWin.Context.TheSys.ItemGetByTag(RzWin.Context, new Core.ItemTag(cid, uid)));
            }
            //this is copied from Rz4.Views.ReportView
            else if (e.Message.ToLower().Contains("sort.rzl"))
            {
                e.Handled = true;
                String colIndexString = Tools.Strings.ParseDelimit(e.Message, "column=", 2);
                if (!Tools.Number.IsNumeric(colIndexString))
                    return;

                ReportColumn col = null;

                int i = 0;
                int colIndexNumber = Int32.Parse(colIndexString) - 1;  //the cols are 1 based
                foreach (KeyValuePair<String, ReportColumn> k in CurrentCore.Columns)
                {
                    if (i == colIndexNumber)
                    {
                        col = k.Value;
                        break;
                    }
                    i++;
                }

                if (col == null)
                    return;

                if (Tools.Strings.StrCmp(col.Caption, CurrentCore.SortColumn))
                {
                    if (CurrentCore.SortDirection == SortDirection.Ascending)
                        CurrentCore.SortDirection = SortDirection.Descending;
                    else
                        CurrentCore.SortDirection = SortDirection.Ascending;
                }
                else
                {
                    CurrentCore.SortDirection = SortDirection.Ascending;
                    CurrentCore.SortColumn = col.Caption;
                }

                ReportLineComparison comp = new ReportLineComparison(colIndexNumber, (CurrentCore.SortDirection == SortDirection.Descending));
                CurrentCore.Sort(comp);

                wb.ReloadWB();
                ((ReportTargetHtml)CurrentTarget).Clear();
                CurrentTarget.Render(RzWin.Context, CurrentCore);
                WriteReportToBrowser();
            }
        }
        private void lnkCompare_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompareVSPastReport();
        }
        //Background Workers
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            ActuallyRunReport();
        }

        protected virtual void ActuallyRunReport()
        {
            try
            {
                CurrentCore.Calculate(RzWin.Context, currentArgs);
                CurrentTarget.Render(RzWin.Context, CurrentCore);
            }
            catch(Exception ex)
            {
                CurrentTarget.Error(ex.Message);
            }
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ActuallyFinishReport();
        }

        protected virtual void ActuallyFinishReport()
        {
            wb.ReloadWB();

            if (!(CurrentTarget is ReportTargetHtml))
                wb.Add("Not Html");
            else
                WriteReportToBrowser();

            throb.HideThrobber();
            pExport.Visible = RzWin.Logic.ExportReportsAllowed(RzWin.Context);
        }

        protected virtual void WriteReportToBrowser()
        {
            wb.Add(((ReportTargetHtml)CurrentTarget).HtmlResult);
        }

        //Menus
        private void domainViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Rz3App.xMainForm.BrowseWebAddress("http://www." + CurrentDomain);
        }
        private void domainAlwaysOEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //domain.UpdateDomainOEM(Rz3App.xSys, CurrentDomain);
        }
        private void domainAlwaysDistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //domain.UpdateDomainDist(Rz3App.xSys, CurrentDomain);
        }
        private void contactDistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //companycontact c = (companycontact)Rz3App.GetById("companycontact", CurrentContact);
            //if (c == null)
            //{
            //    nStatus.TellUserTemp("The contact for this order could not be located.");
            //    return;
            //}

            //c.abs_type = "DIST";
            //c.ISave();
            //nStatus.TellUserTemp("Done.");
        }
        private void contactOEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //companycontact c = (companycontact)Rz3App.GetById("companycontact", CurrentContact);
            //if (c == null)
            //{
            //    nStatus.TellUserTemp("The contact for this order could not be located.");
            //    return;
            //}

            //c.abs_type = "OEM";
            //c.ISave();
            //nStatus.TellUserTemp("Done.");
        }

        private void cmdThisMonth_Click(object sender, EventArgs e)
        {
            dtStart.SetValue(Tools.Dates.GetMonthStart(DateTime.Now));
            dtEnd.SetValue(DateTime.Now);
            RunReport();
        }

        private void cmdLastMonth_Click(object sender, EventArgs e)
        {
            dtStart.SetValue(Tools.Dates.GetPreviousMonthStart(DateTime.Now));
            dtEnd.SetValue(Tools.Dates.GetPreviousMonthEnd(DateTime.Now));
            RunReport();
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            if (bgExcel.IsBusy)
                return;

            excelArgs = ArgsGet();
            throb.ShowThrobber();
            bgExcel.RunWorkerAsync();
        }

        ProfitReportArgs excelArgs = null;
        ReportTargetExcel xl = null;
        void ExcelRun()
        {
            xl = new ReportTargetExcel();
            xl.Render(RzWin.Context, CurrentCore);
        }

        private void bgExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            ExcelRun();
        }

        private void bgExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (xl != null)
                xl.ShowExcel();
            throb.HideThrobber();
        }
    }
}