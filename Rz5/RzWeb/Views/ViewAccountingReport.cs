using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Core;
using CoreWeb;
using Rz5;
using System.Text;
using System.Web.UI;
using RzWeb.Screens;
using RzWeb.Controls;
using Rz5.Web;
using NewMethod;
using System.Collections;
using CoreWeb.Controls;

namespace RzWeb
{
    public class ViewAccountingReport : RzScreen
    {
        //Public Variables
        public AccountingReport TheReport;
        public AccountingReportResult Result;

        //Constructors
        public ViewAccountingReport(Rz5.ContextRz context, AccountingReport r)
            : base(context)
        {
            TheReport = r;
            Result = (AccountingReportResult)SpotAdd(new AccountingReportResult(this));
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            if (TheReport != null)
                return TheReport.ReportTitle;
            return "Accounting Report";
        }
        public override void ClientScriptsInclude(System.Web.UI.Page page)
        {
            base.ClientScriptsInclude(page);
            page.ClientScript.RegisterClientScriptInclude("Rz", page.ResolveClientUrl("~/Scripts") + "/Rz.js");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                case "refresh":
                    RefreshReport(xrz, args);
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("<div class=\"ui-corner-all\" id=\"controlDiv\" style=\"position: absolute; margin: 4px; border-color: #CCCCCC; border-width: thin; border-style: solid; padding: 4px\">");
            sb.Append("<div style=\"height: 160px\">");
            string title = TheReport.ReportTitle;
            if (title.Contains("["))
                title = title.Replace(" [", "<br>[");
            sb.Append("<span style=\"position: absolute; width: 235px; margin: 6px; text-align: center\"><font size=\"4\"><b>" + title + "</b></font></span><br /><br /><br /><br />");
            sb.Append("<center><input type=\"button\" id=\"reportButton\" value=\"Refresh\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScriptPlusControls("'refresh'", "''") + "\">");
            Buttonize(viewHandle, "reportButton", "RefreshBlue3.png");
            sb.AppendLine("</center>");
            sb.Append("</div>");
            sb.AppendLine("<br />");
            sb.AppendLine("<div id=\"criteriaScroll\" style=\"width: 100%; overflow: auto\">");
            ReportCriteriaDateRange dr = new ReportCriteriaDateRange("Date Range");
            dr.TheRange = TheReport.DateRange;
            RenderDateRange(x, sb, dr, viewHandle);
            sb.AppendLine("</div>");
            sb.Append("</div>");
        }
        public override string ScriptToolsRender(Page page, ViewHandle viewHandle)
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine(base.ScriptToolsRender(page, viewHandle));
            return ret.ToString();
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine(PlaceBelowMenu(Result));
            PlaceDivBelowMenu(sb, "controlDiv");
            sb.AppendLine("$('#controlDiv').css('left', 0);");
            sb.AppendLine("$('#controlDiv').css('height', " + Select + ".height() - ($('#controlDiv').position().top + MarginHeight('controlDiv')));");
            sb.AppendLine("$('#controlDiv').css('width', 250);");
            sb.AppendLine(Result.Select + ".css('left', 265);");
            sb.AppendLine(Result.Select + ".css('width', " + Select + ".width() - ( $('#controlDiv').outerWidth(true) - MarginWidth('" + Result.DivId + "')));");
            sb.AppendLine(Result.Select + ".css('height', (" + Select + ".height() - $('#rz_menu').outerHeight(true)));");
        }
        //Private Functions
        //private void RenderDateRange(Context x, StringBuilder sb, ReportCriteriaDateRange dateRange, ViewHandle viewHandle)
        //{
        //    String title = "";
        //    if (Tools.Strings.StrExt(dateRange.Description))
        //        title = " title=\"" + HttpUtility.HtmlEncode(dateRange.Description) + "\"";
        //    sb.AppendLine("<div class=\"ui-corner-all\" style=\"width: 98%; border: thin solid #CCCCCC; margin: 2px; margin-bottom: 4px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td width=\"24px\"><img src=\"Graphics/ReportDate.png\"" + title + "/></td><td><font size=\"larger\">" + dateRange.Caption + "</font></td><td align=\"right\">");
        //    sb.AppendLine("</td></tr></table>");
        //    if (TheReport.ReportType == AccountingReportType.BalanceSheet)
        //        dateRange.DefaultOption = "On";
        //    else
        //        dateRange.DefaultOption = "Between";
        //    sb.AppendLine("<select id=\"ctl_" + dateRange.Uid + "\" style=\"margin: 2px; visibility: hidden;\" name=\"ctl_" + dateRange.Uid + "\">");
        //    sb.AppendLine("<option selected>" + HttpUtility.HtmlEncode(dateRange.DefaultOption) + "</option>");
        //    sb.AppendLine("</select>");
        //    sb.AppendLine("<div id=\"dateRangeOptions_" + Uid + "\" style=\"overflow: auto\">");
        //    sb.AppendLine("<div><input style=\"float: left; width: 100px; margin: 2px\" type=\"text\" name=\"ctl_" + dateRange.Uid + "_start\" id=\"ctl_" + dateRange.Uid + "_start\" value=\"" + Tools.Dates.DateFormat(dateRange.TheRange.StartDate) + "\">");
        //    sb.AppendLine("<input style=\"float: left; width: 100px; margin: 2px\" type=\"text\" name=\"ctl_" + dateRange.Uid + "_end\" id=\"ctl_" + dateRange.Uid + "_end\" value=\"" + Tools.Dates.DateFormat(dateRange.TheRange.EndDate) + "\">");
        //    sb.AppendLine("</div>");
        //    sb.AppendLine("</div>");
        //    viewHandle.ScriptsToRun.Add("$('#ctl_" + dateRange.Uid + "_start').datepicker();");
        //    viewHandle.ScriptsToRun.Add("$('#ctl_" + dateRange.Uid + "_end').datepicker();");
        //    viewHandle.ScriptsToRun.Add("SetDateCriteria('ctl_" + dateRange.Uid + "', 'ctl_" + dateRange.Uid + "_start', 'ctl_" + dateRange.Uid + "_end');");
        //    sb.AppendLine("</div>");
        //}

        private void RenderDateRange(Context x, StringBuilder sb, ReportCriteriaDateRange dateRange, ViewHandle viewHandle)
        {
            String title = "";
            if (Tools.Strings.StrExt(dateRange.Description))
                title = " title=\"" + HttpUtility.HtmlEncode(dateRange.Description) + "\"";
            sb.AppendLine("<div class=\"ui-corner-all\" style=\"width: 98%; border: thin solid #CCCCCC; margin: 2px; margin-bottom: 4px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td width=\"24px\"><img src=\"Graphics/ReportDate.png\"" + title + "/></td><td><font size=\"larger\">" + dateRange.Caption + "</font></td><td align=\"right\">");
            sb.AppendLine("</td></tr></table>");
            String changeScript = "SetDateCriteria('ctl_" + dateRange.Uid + "', 'ctl_" + dateRange.Uid + "_start', 'ctl_" + dateRange.Uid + "_end');";
            sb.AppendLine("<select id=\"ctl_" + dateRange.Uid + "\" style=\"margin: 2px;\" name=\"ctl_" + dateRange.Uid + "\" onchange=\"" + changeScript + "\">");            
            List<String> options = new List<string>();
            options.Add("On");
            options.Add("Between");
            foreach (string s in options)
            {
                string sel = "";
                if (TheReport.ReportType == AccountingReportType.BalanceSheet && Tools.Strings.StrCmp(s, "On"))
                    sel = "selected";
                else if (TheReport.ReportType != AccountingReportType.BalanceSheet && Tools.Strings.StrCmp(s, "Between"))
                    sel = "selected";
                sb.AppendLine("<option " + sel + ">" + HttpUtility.HtmlEncode(s) + "</option>");
            }
            sb.AppendLine("</select><br />");
            sb.AppendLine("<div id=\"dateRangeOptions_" + Uid + "\" style=\"overflow: auto\">");
            sb.AppendLine("<div><input style=\"float: left; width: 100px; margin: 2px\" type=\"text\" name=\"ctl_" + dateRange.Uid + "_start\" id=\"ctl_" + dateRange.Uid + "_start\" value=\"" + Tools.Dates.DateFormat(dateRange.TheRange.StartDate) + "\">");
            sb.AppendLine("<input style=\"float: left; width: 100px; margin: 2px\" type=\"text\" name=\"ctl_" + dateRange.Uid + "_end\" id=\"ctl_" + dateRange.Uid + "_end\" value=\"" + Tools.Dates.DateFormat(dateRange.TheRange.EndDate) + "\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            viewHandle.ScriptsToRun.Add("$('#ctl_" + dateRange.Uid + "_start').datepicker();");
            viewHandle.ScriptsToRun.Add("$('#ctl_" + dateRange.Uid + "_end').datepicker();");
            viewHandle.ScriptsToRun.Add(changeScript);
            sb.AppendLine("</div>");
        }














        private void RefreshReport(ContextRz x, SpotActArgs args)
        {
            string s = "";
            args.Vars.TryGetValue("ctl_daterange_start", out s);
            string e = "";
            args.Vars.TryGetValue("ctl_daterange_end", out e);
            DateTime start = Tools.Dates.GetBlankDate();
            try { start = Convert.ToDateTime(s); }
            catch { }
            DateTime end = Tools.Dates.GetBlankDate();
            try { end = Convert.ToDateTime(e); }
            catch { }
            TheReport.DateRange = new Tools.Dates.DateRange(start, end);
            if (TheReport.ReportType == AccountingReportType.BalanceSheet)
                TheReport.DateRange = new Tools.Dates.DateRange(start, start);
            Result.Change();
        }
    }
    public class AccountingReportResult : Spot
    {
        //Private Variables
        private ViewAccountingReport Screen;

        //Constructors
        public AccountingReportResult(ViewAccountingReport screen)
        {
            Screen = screen;
        }
        //Public Override Functions
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            ContextRz xrz = (ContextRz)x;
            sb.AppendLine("<div id=\"contentDiv\" style=\"position: absolute; overflow: scroll\">");
            Screen.TheReport.Action = new AccountingReportAction();
            Screen.TheReport.Action.ScreenId = Screen.Uid;
            Screen.TheReport.Action.SpotId = Uid;
            sb.AppendLine(Screen.TheReport.GetReport((ContextRz)x));
            sb.AppendLine("</div>");
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#contentDiv').css('left', 0);");
            sb.AppendLine("$('#contentDiv').css('top', 0);");
            RunDivToRight(sb, "contentDiv");
            RunDivToBottom(sb, "contentDiv");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId)
            {
                case "view_account_report":
                    ViewAccountingReport((ContextRz)x, args.ActionParams);
                    break;
            }
        }
        //Private Functions
        private void ViewAccountingReport(ContextRz x, string id)
        {
            if (!Tools.Strings.StrExt(id))
                return;
            account a = account.GetById(x, id);
            if (a == null)
                return;
            a.ShowAccountReport(x);
        }
    }
}
