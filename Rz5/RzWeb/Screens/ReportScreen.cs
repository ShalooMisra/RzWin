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
    public class ReportScreen : RzScreen
    {
        public Core.Report TheReport;
        public ReportArgs TheArgs;
        public String ExportedFile = "";
        ReportResult Result;
        ChartControl Chart;
        public bool AutoCalc;
        Stack<ReportArgs> ArgsStack = new Stack<ReportArgs>();

        public ReportScreen(Rz5.ContextRz context, Core.Report r, bool autoCalc)
            : this(context, r, autoCalc, r.ArgsCreate(context))
        {

        }
        public ReportScreen(Rz5.ContextRz context, Core.Report r, bool autoCalc, ReportArgs args)
            : base(context)
        {
            TheReport = r;
            TheArgs = args;
            //AutoCalc = autoCalc;
            AutoCalc = false;

            Result = (ReportResult)SpotAdd(new ReportResult(this));
            Chart = (ChartControl)SpotAdd(new ChartControl());
            
            //if (autoCalc)
            //    Recalc(context, TheArgs);

            Change();
        }
        public override String Title(Context x)
        {
            return "Report";
        }
        public override void ClientScriptsInclude(System.Web.UI.Page page)
        {
            base.ClientScriptsInclude(page);
            page.ClientScript.RegisterClientScriptInclude("HighCharts", "Scripts/highcharts.js");
            page.ClientScript.RegisterClientScriptInclude("Rz", page.ResolveClientUrl("~/Scripts") + "/Rz.js");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                case "show_item":
                    ShowItem(xrz, args.ActionParams);
                    break;
                case "refresh":
                    Refresh(xrz, args);
                    break;
                case "export":
                    Export(xrz);
                    break;
                case "summarize":
                    Summarize(xrz, args, ArgsGather(xrz, args));
                    SetChartMode(args.SourceView, false);
                    break;
                case "chart":
                    ChartShow(xrz, args);
                    break;
                case "summarize_chart":
                    SummarizeChart(xrz, args, ArgsGather(xrz, args));
                    break;
                case "summary_line":
                    ShowSummaryLine(xrz, args);
                    break;
                case "column_sort":
                    Sort(xrz, args);
                    break;
                case "column_bar_chart":
                    ColumnChart(xrz, args, ChartType.Bar);
                    break;
                case "column_pie_chart":
                    ColumnChart(xrz, args, ChartType.Pie);
                    break;
                case "choose_company":
                    ChooseCompany(xrz, args);
                    break;
                case "clear_company":
                    ClearCompany(xrz, args);
                    break;
                case "choose_agents":
                    ChooseAgents(xrz, args);
                    break;
                case "clear_agents":
                    ClearAgents(xrz, args);
                    break;
                case "report_command":
                    TheReport.ProcessCommand(xrz, args.ActionParams);
                    break;
            }
        }
        void ChooseCompany(ContextRz context, SpotActArgs args)
        {
            company c = context.Leader.ChooseCompany(context);
            if (c == null)
            {
                ClearCompany(context, args);
                return;
            }

            args.SourceView.ScriptsToRun.Add("$('#name_" + args.ActionParams + "').text('" + c.companyname.Replace("'", "''") + "');");  //apparently JQ already encodes with the text() function automatically
            args.SourceView.ScriptsToRun.Add("$('#ctl_id_" + args.ActionParams + "').val('" + c.unique_id + "');");
            args.SourceView.ScriptsToRun.Add("$('#clear_" + args.ActionParams + "').show();");
        }
        void ClearCompany(ContextRz context, SpotActArgs args)
        {
            args.SourceView.ScriptsToRun.Add("$('#name_" + args.ActionParams + "').text('[none selected]');");
            args.SourceView.ScriptsToRun.Add("$('#ctl_id_" + args.ActionParams + "').val('');");
            args.SourceView.ScriptsToRun.Add("$('#clear_" + args.ActionParams + "').hide();");
        }
        void ChooseAgents(ContextRz context, SpotActArgs args)
        {
            ArrayList a = context.Leader.ChooseFromArray((ContextRz)context, GetAgentList((ContextRz)context, true), "Choose Agents");
            if (a == null || a.Count <= 0)
            {
                ClearAgents(context, args);
                return;
            }
            string val = a[0].ToString().Replace("'", "''");
            if (a.Count > 1)
                val += " +" + Convert.ToInt32(a.Count - 1).ToString();
            args.SourceView.ScriptsToRun.Add("$('#agentmanylink_" + args.ActionParams + "').text('" + val + "');");
            string build = "";
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    return;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += s;
            }
            args.SourceView.ScriptsToRun.Add("$('#ctl_" + args.ActionParams + "').val('" + build + "');");
            args.SourceView.ScriptsToRun.Add("$('#clear_" + args.ActionParams + "').show();");
        }
        void ClearAgents(ContextRz context, SpotActArgs args)
        {
            args.SourceView.ScriptsToRun.Add("$('#agentmanylink_" + args.ActionParams + "').text('[none selected]');");
            args.SourceView.ScriptsToRun.Add("$('#ctl_" + args.ActionParams + "').val('');");
            args.SourceView.ScriptsToRun.Add("$('#clear_" + args.ActionParams + "').hide();");
        }
        void Refresh(ContextRz xrz, SpotActArgs args)
        {
            NewReportInstance(xrz);
            ReportArgs reportArgs = ArgsGather(xrz, args);
            Recalc(xrz, reportArgs);
            SetChartMode(args.SourceView, false);
        }
        void ColumnChart(ContextRz xrz, SpotActArgs args, ChartType chartType)
        {
            TheReport.SummarizeByColumn(xrz, ArgsStack.Peek(), Int32.Parse(args.ActionParams));

            Result.Change();

            Chart.Init(TheReport, chartType);
            SetChartMode(args.SourceView, true);
        }
        void Sort(ContextRz xrz, SpotActArgs args)
        {
            TheReport.SortByColumnIndex(Int32.Parse(args.ActionParams));
            Result.Change();
        }
        void Recalc(ContextRz xrz, ReportArgs reportArgs)
        {
            TheReport.Calculate(xrz, reportArgs);
            TheReport.InferColumnOptions(xrz);

            if (ArgsStack.Count == 0)
                ArgsStack.Push(reportArgs.Clone(xrz));
            else
            {
                ReportArgs clone = reportArgs.Clone(xrz); 
                if (!ArgsStack.Peek().Matches(clone))  //  don't push duplicates
                    ArgsStack.Push(clone);
            }
            Result.Change();
        }
        void Summarize(ContextRz context, SpotActArgs actArgs, ReportArgs reportArgs)
        {
            ReportCriteria criteria = reportArgs.CriteriaById(actArgs.ActionParams);
            if (criteria == null)
                throw new Exception("This criteria was not found");

            if (criteria is ReportCriteriaDateRange)
                TheReport.SummarizeByDate(context, reportArgs, (ReportCriteriaDateRange)criteria);
            else if (criteria is ReportCriteriaRadio)
                TheReport.SummarizeByRadio(context, reportArgs, (ReportCriteriaRadio)criteria);
            else if (criteria is Rz5.ReportCriteriaCompany)
            {
                if (TheReport is Rz5.Report)
                    ((Rz5.Report)TheReport).SummarizeByCompany(context, reportArgs, (Rz5.ReportCriteriaCompany)criteria);
            }
            else
                throw new Exception("This criteria cannot be summarized");

            Result.Change();
        }
        void ChartShow(ContextRz context, SpotActArgs actArgs)
        {
            if (TheReport.Lines.Count > 100 || (TheReport.Lines.Count == 0 && TheReport.Sections.Count > 100))
                throw new Exception("This report has too many lines to chart");

            Chart.Init(TheReport, ChartType.Bar);
            SetChartMode(actArgs.SourceView, true);
        }
        void SetChartMode(ViewHandle viewHandle, bool on)
        {
            if (on)
            {
                Result.ChartMode = true;
                Result.Change();
                viewHandle.ScriptsToRun.Add("chartMode = true; DoResize();");
            }
            else
            {
                Result.ChartMode = false;
                Result.Change();
                viewHandle.ScriptsToRun.Add("chartMode = false; DoResize();");
            }
        }
        void SummarizeChart(ContextRz context, SpotActArgs actArgs, ReportArgs reportArgs)
        {
            Summarize(context, actArgs, reportArgs);
            ChartShow(context, actArgs);
        }
        void ShowSummaryLine(ContextRz context, SpotActArgs args)
        {
            ReportLine l = TheReport.LineById(args.ActionParams);
            if (l == null)
                throw new Exception("This report line was not found");

            TheArgs = l.SummaryArgs;

            NewReportInstance(context);
            TheReport.Calculate(context, TheArgs);
            TheReport.InferColumnOptions(context);
            SetChartMode(args.SourceView, false);
            Change();
        }
        void NewReportInstance(ContextRz context)
        {
            TheReport = (Rz5.Report)TheReport.Clone(context);
        }
        ReportArgs ArgsGather(ContextRz x, SpotActArgs actArgs)
        {
            ReportArgs args = TheReport.ArgsCreate((ContextRz)x);
            //fill in from the posted controls

            foreach (ReportCriteria c in args.Criteria)
            {
                if (c is ReportCriteriaDateRange)
                    GatherDateRange(x, (ReportCriteriaDateRange)c, actArgs);
                else if (c is ReportCriteriaRadio)
                    GatherRadio(x, (ReportCriteriaRadio)c, actArgs);
                else if (c is ReportCriteriaBoolean)
                    GatherBoolean(x, (ReportCriteriaBoolean)c, actArgs);
                else if (c is ReportCriteriaString)
                    GatherString(x, (ReportCriteriaString)c, actArgs);
                else if (c is ReportCriteriaAgent)
                    GatherAgent(x, (ReportCriteriaAgent)c, actArgs);
                else if (c is ReportCriteriaAgentMany)
                    GatherAgentMany(x, (ReportCriteriaAgentMany)c, actArgs);
                else if (c is Rz5.ReportCriteriaCompany)
                    GatherCompany(x, (Rz5.ReportCriteriaCompany)c, actArgs);
            }

            return args;
        }
        void GatherDateRange(ContextRz x, ReportCriteriaDateRange dateRange, SpotActArgs actArgs)
        {
            String startString = actArgs.Var(dateRange.Uid + "_start");
            DateTime start = Tools.Dates.NullDate;
            if (Tools.Dates.IsDate(startString))
                start = Tools.Dates.GetDayStart(DateTime.Parse(startString));

            String endString = actArgs.Var(dateRange.Uid + "_end");
            DateTime end = Tools.Dates.NullDate;
            if (Tools.Dates.IsDate(endString))
                end = Tools.Dates.GetDayEnd(DateTime.Parse(endString));

            switch(actArgs.Var(dateRange.Uid).ToLower())
            {
                case "any date":
                    dateRange.TheRange.StartDate = Tools.Dates.NullDate;
                    dateRange.TheRange.EndDate = Tools.Dates.NullDate;
                    break;
                case "on":
                    dateRange.TheRange.StartDate = start;
                    dateRange.TheRange.EndDate = Tools.Dates.GetDayEnd(start);  //for ON, the entry is the start date
                    break;
                case "before":
                    dateRange.TheRange.StartDate = Tools.Dates.NullDate;
                    dateRange.TheRange.EndDate = end;
                    break;
                case "after":
                    dateRange.TheRange.StartDate = start;
                    dateRange.TheRange.EndDate = Tools.Dates.NullDate;
                    break;
                default:
                    dateRange.TheRange.StartDate = start;
                    dateRange.TheRange.EndDate = end;
                    break;
            }
        }
        void GatherRadio(ContextRz x, ReportCriteriaRadio radio, SpotActArgs actArgs)
        {
            radio.SelectedCaption = actArgs.Var(radio.Uid);
        }
        void GatherBoolean(ContextRz x, ReportCriteriaBoolean booleanCriteria, SpotActArgs actArgs)
        {
            booleanCriteria.Value = Tools.Strings.StrCmp(actArgs.Var(booleanCriteria.Uid), "true");
        }
        void GatherString(ContextRz x, ReportCriteriaString stringCriteria, SpotActArgs actArgs)
        {
            stringCriteria.Value = actArgs.Var(stringCriteria.Uid);
        }
        void GatherAgent(ContextRz x, ReportCriteriaAgent agent, SpotActArgs actArgs)
        {
            List<String> names = new List<String>(Tools.Strings.Split(actArgs.Var(agent.Uid), "|"));
            agent.AgentIds = new List<string>();
            foreach (string s in names)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = NewMethod.n_user.TranslateNameToID(x, s);
                if (Tools.Strings.StrExt(id))
                    agent.AgentIds.Add(id);
            }
        }
        void GatherAgentMany(ContextRz x, ReportCriteriaAgentMany agent, SpotActArgs actArgs)
        {
            List<String> names = new List<String>(Tools.Strings.Split(actArgs.Var(agent.Uid), "|"));
            agent.AgentIds = new List<string>();
            foreach (string s in names)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string id = NewMethod.n_user.TranslateNameToID(x, s);
                if (Tools.Strings.StrExt(id))
                    agent.AgentIds.Add(id);
            }
        }
        void GatherCompany(ContextRz x, ReportCriteriaCompany company, SpotActArgs actArgs)
        {
            company.TheID = actArgs.Var("id_" + company.Uid);
            company.TheName = Rz5.company.TranslateIDToName(x, company.TheID);
        }
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

            sb.AppendLine("if(chartMode) {");
            sb.AppendLine("if( reportHidden ) {");
                sb.AppendLine(Result.Select + ".hide();");
                sb.AppendLine(Chart.Select + ".css('height', " + Select + ".height() - $('#rz_menu').outerHeight(true));");
                sb.AppendLine(PlaceBelowMenu(Chart));
            sb.AppendLine("} else {");
                sb.AppendLine(Result.Select + ".show();");
                sb.AppendLine(Result.Select + ".css('height', ((" + Select + ".height() - $('#rz_menu').outerHeight(true)) / 2 ));");
                sb.AppendLine(Chart.Select + ".css('height', ((" + Select + ".height() - $('#rz_menu').outerHeight(true)) / 2 ));");
                sb.AppendLine(Chart.Select + ".css('top', " + Result.Select + ".position().top + " + Result.Select + ".outerHeight(true));");
            sb.AppendLine("}");
            sb.AppendLine(Chart.Select + ".css('left', 265);");
            sb.AppendLine(Chart.Select + ".css('width', " + Select + ".width() - ($('#controlDiv').outerWidth(true) - MarginWidth('" + Chart.DivId + "') ));");
            sb.AppendLine(Chart.Select + ".show();");
            sb.AppendLine("if( reportHidden ) { $('#reportShowButton').show(); $('#reportHideButton').hide(); } else { $('#reportShowButton').hide(); $('#reportHideButton').show(); } ");  //this gave me a headache
            sb.AppendLine("} else { ");
            sb.AppendLine(Result.Select + ".css('height', (" + Select + ".height() - $('#rz_menu').outerHeight(true)));");
            sb.AppendLine(Chart.Select + ".hide();");
            sb.AppendLine("$('#reportShowButton').hide(); $('#reportHideButton').hide();");
            sb.AppendLine("}");

            sb.AppendLine("$('#criteriaScroll').css('height', $('#controlDiv').height() - ( $('#criteriaScroll').position().top + 24 ) + 16);");
            sb.AppendLine("$('#totalLabelDiv').css('top', $('#controlDiv').height() - 20);");
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            sb.Append("<div class=\"ui-corner-all\" id=\"controlDiv\" style=\"position: absolute; margin: 4px; border-color: #CCCCCC; border-width: thin; border-style: solid; padding: 4px\">");

            sb.Append("<div style=\"height: 160px\">");

            sb.Append("<div style=\"float: right;\"><img id=\"reportHideButton\" style=\"display: none; cursor: pointer\" src=\"Graphics/Minimize.png\" title=\"Hide The Report\" onclick=\"reportHidden = true; DoResize(); setTimeout(function(){$(window).resize();}, 500);\" /><img id=\"reportShowButton\" style=\"display: none; cursor: pointer\" src=\"Graphics/Maximize.png\" title=\"Show The Report\" onclick=\"reportHidden = false; DoResize(); setTimeout(function(){$(window).resize();}, 500);\" /></div>");
            sb.Append("<span style=\"margin: 6px\"><font size=\"4\"><b>" + TheReport.Title + "</b></font></span><br /><br />");
            
            sb.Append("<center><input type=\"button\" id=\"reportButton\" value=\"Refresh\" style=\"font-size: x-small; width: 80px;\" onclick=\"ChartClose(); RunReport(); " + ActionScriptPlusControls("'refresh'", "''") + "\">");
            Buttonize(viewHandle, "reportButton", "RefreshBlue3.png");

            sb.AppendLine("<div id=\"contentOptions\" style=\"display: none\">");

            if (TheReport.Totals.Count == 0)
            {
                sb.Append("<br /><table border=\"0\" width=\"100%\"><tr><td width=\"100%\" align=\"center\"><input type=\"button\" id=\"excelButton\" value=\"Download\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'export'", "''") + "\"></td></tr></table>");
                Buttonize(viewHandle, "excelButton", "ExcelFile3.png");

            }
            else
            {
                sb.Append("<br /><table border=\"0\" width=\"100%\"><tr><td width=\"50%\" align=\"center\"><input type=\"button\" id=\"excelButton\" value=\"Download\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'export'", "''") + "\"></td>");
                Buttonize(viewHandle, "excelButton", "ExcelFile3.png");

                sb.Append("<td width=\"50%\" align=\"center\"><input type=\"button\" id=\"chartButton\" value=\"Chart\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'chart'", "''") + "\"></td></tr></table>");
                Buttonize(viewHandle, "chartButton", "Chart.png");
            }

            sb.AppendLine("</div></center>");

            sb.Append("</div>");

            sb.AppendLine("<br />");

            sb.AppendLine("<div id=\"criteriaScroll\" style=\"width: 100%; overflow: auto\">");

            foreach (ReportCriteria c in TheArgs.Criteria)
            {
                if (c is ReportCriteriaDateRange)
                    RenderDateRange(x, sb, (ReportCriteriaDateRange)c, viewHandle);
                else if (c is ReportCriteriaRadio)
                    RenderRadio(x, sb, (ReportCriteriaRadio)c, viewHandle);
                else if (c is ReportCriteriaBoolean)
                    RenderBoolean(x, sb, (ReportCriteriaBoolean)c, viewHandle);
                else if (c is ReportCriteriaString)
                    RenderString(x, sb, (ReportCriteriaString)c, viewHandle);
                else if (c is ReportCriteriaAgent)
                    RenderAgent(x, sb, (ReportCriteriaAgent)c, viewHandle);
                else if (c is ReportCriteriaAgentMany)
                    RenderAgentMany(x, sb, (ReportCriteriaAgentMany)c, viewHandle);
                else if (c is Rz5.ReportCriteriaCompany)
                    RenderCompany(x, sb, (Rz5.ReportCriteriaCompany)c, viewHandle);
            }

            sb.AppendLine("</div>");

            sb.AppendLine("<div style=\"position: absolute; width: 250px\" id=\"totalLabelDiv\"><center><span id=\"totalLabelSpan\"></span></center></div>");

            sb.Append("</div>");
                
            if (File.Exists(ExportedFile))
            {
                String exportFolder = Tools.Folder.ConditionFolderName(page.Server.MapPath("~/Exports"));
                if (!Directory.Exists(exportFolder))
                    Directory.CreateDirectory(exportFolder);

                String fn = Path.GetFileName(ExportedFile);
                File.Copy(ExportedFile, exportFolder + fn);

                viewHandle.ScriptsToRun.Add("window.open('" + page.ResolveClientUrl("~/Exports/" + fn) + "');");
                ExportedFile = "";
            }
        }
        void RenderDateRange(Context x, StringBuilder sb, ReportCriteriaDateRange dateRange, ViewHandle viewHandle)
        {
            RenderCriteriaHeader(sb, dateRange, viewHandle, "ReportDate.png", true);

            String changeScript = "SetDateCriteria('ctl_" + dateRange.Uid + "', 'ctl_" + dateRange.Uid + "_start', 'ctl_" + dateRange.Uid + "_end');";
            sb.AppendLine("<select id=\"ctl_" + dateRange.Uid + "\" style=\"margin: 2px;\" name=\"ctl_" + dateRange.Uid + "\" onchange=\"" + changeScript + "\">");

            List<String> options = new List<string>();
            if (dateRange.AllowAny)
                options.Add("Any Date");

            options.Add("On");
            options.Add("Between");
            options.Add("Before");
            options.Add("After");

            if (!options.Contains(dateRange.DefaultOption))
            {
                if (!dateRange.TheRange.Valid)
                    dateRange.DefaultOption = "Any Date";
                else if (!Tools.Dates.DateExists(dateRange.TheRange.StartDate))
                    dateRange.DefaultOption = "Before";
                else if (!Tools.Dates.DateExists(dateRange.TheRange.EndDate))
                    dateRange.DefaultOption = "After";
                else
                    dateRange.DefaultOption = "Between";
            }

            if (dateRange.AllowNonDefault)
            {
                foreach (String o in options)
                {
                    String selected = "";
                    if (Tools.Strings.StrCmp(o, dateRange.DefaultOption))
                        selected = " selected";

                    sb.AppendLine("<option" + selected + ">" + HttpUtility.HtmlEncode(o) + "</option>");
                }
            }
            else
            {
                sb.AppendLine("<option selected>" + HttpUtility.HtmlEncode(dateRange.DefaultOption) + "</option>");
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

            RenderCriteriaFooter(sb, dateRange, viewHandle);
        }
        void RenderRadio(Context x, StringBuilder sb, ReportCriteriaRadio radio, ViewHandle viewHandle)
        {
            RenderCriteriaHeader(sb, radio, viewHandle, "ReportList.png", includeSummary: true);
            sb.AppendLine("<select id=\"ctl_" + radio.Uid + "\" name=\"ctl_" + radio.Uid + "\" style=\"margin: 2px; width: 240px\">");

            foreach (String s in radio.ValueCaptions)
            {
                String selected = "";
                if (Tools.Strings.StrCmp(s, radio.SelectedCaption))
                    selected = " selected";
                sb.AppendLine("<option" + selected + ">" + HttpUtility.HtmlEncode(s) + "</option>");
            }

            sb.AppendLine("</select><br />");

            RenderCriteriaFooter(sb, radio, viewHandle);
        }
        void RenderBoolean(Context x, StringBuilder sb, ReportCriteriaBoolean booleanCriteria, ViewHandle viewHandle)
        {
            String chk = "";
            if (booleanCriteria.Value)
                chk = " checked";

            sb.AppendLine("<div class=\"ui-corner-all\" style=\"width: 98%; border: thin solid #CCCCCC; margin: 2px; margin-bottom: 4px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td width=\"24px\"><label><input type=\"checkbox\" " + chk + " id=\"ctl_" + booleanCriteria.Uid + "\" name=\"ctl_" + booleanCriteria.Uid + "\" style=\"margin: 2px;\"><font size=\"larger\">" + booleanCriteria.Caption + "</font></label></td></td></tr></table>");
            RenderCriteriaFooter(sb, booleanCriteria, viewHandle);
        }
        void RenderString(Context x, StringBuilder sb, ReportCriteriaString stringCriteria, ViewHandle viewHandle)
        {
            RenderCriteriaHeader(sb, stringCriteria, viewHandle, "ReportText.png", includeSummary: false);
            sb.AppendLine("<input type=\"text\" id=\"ctl_" + stringCriteria.Uid + "\" name=\"ctl_" + stringCriteria.Uid + "\" style=\"margin: 2px; width: 240px\" /><br />");
            RenderCriteriaFooter(sb, stringCriteria, viewHandle);
        }
        void RenderAgent(Context x, StringBuilder sb, ReportCriteriaAgent agent, ViewHandle viewHandle)
        {
            RenderCriteriaHeader(sb, agent, viewHandle, "ReportCompany.png", includeSummary: true);
            sb.AppendLine("<select id=\"ctl_" + agent.Uid + "\" name=\"ctl_" + agent.Uid + "\" style=\"margin: 2px; width: 240px\">");
            sb.AppendLine("<option selected>&nbsp;</option>");
            ArrayList agents = GetAgentList((ContextRz)x, agent.OnlyActiveSalespeople);
            foreach (String s in agents)
            {
                sb.AppendLine("<option>" + HttpUtility.HtmlEncode(s) + "</option>");
            }
            sb.AppendLine("</select><br />");
            RenderCriteriaFooter(sb, agent, viewHandle);
        }
        void RenderAgentMany(Context x, StringBuilder sb, ReportCriteriaAgentMany agent, ViewHandle viewHandle)
        {
            RenderCriteriaHeader(sb, agent, viewHandle, "ReportCompany.png", includeSummary: true);
            string v = "";
            if (agent.AgentIds.Count > 0)
                v = agent.AgentIds[0];
            sb.AppendLine("<input type=\"hidden\" name=\"ctl_" + agent.Uid + "\" id=\"ctl_" + agent.Uid + "\" value=\"" + v + "\" />");
            sb.AppendLine("<a href=\"#\" onclick=\"" + ActionScript("'choose_agents'", "'" + agent.Uid + "'") + "\" id=\"agentmanylink_" + agent.Uid + "\">[click to choose]</a>");
            String displayClear = "";
            if (agent.AgentIds.Count <= 0)
                displayClear = "; display: none";            
            sb.Append("<br />");
            sb.AppendLine("<input id=\"clear_" + agent.Uid + "\" type=\"button\" style=\"float: right; font-size: smaller" + displayClear + "\" value=\"Clear\" onclick=\"" + ActionScript("'clear_agents'", "'" + agent.Uid + "'") + "\" />");
            sb.AppendLine("<br /><br />");
            viewHandle.ScriptsToRun.Add("$('#clear_" + agent.Uid + "').button();");
            RenderCriteriaFooter(sb, agent, viewHandle);
        }
        void RenderCompany(Context x, StringBuilder sb, Rz5.ReportCriteriaCompany company, ViewHandle viewHandle)
        {
            RenderCriteriaHeader(sb, company, viewHandle, "ReportCompany.png", includeSummary: company.NameColumn > -1);
            sb.AppendLine("<input type=\"hidden\" name=\"ctl_id_" + company.Uid + "\" id=\"ctl_id_" + company.Uid + "\" value=\"" + company.TheID + "\" />");
            sb.AppendLine("<span id=\"name_" + company.Uid + "\">");

            String displayClear = "";
            if (Tools.Strings.StrExt(company.TheName))
            {
                sb.Append("<font size=\"larger\">" + HttpUtility.HtmlEncode(company.TheName) + "</font>");
            }
            else
            {
                sb.Append("[none selected]");
                displayClear = "; display: none";
            }

            sb.Append("</span><br />");
            sb.AppendLine("<input id=\"clear_" + company.Uid + "\" type=\"button\" style=\"float: right; font-size: smaller" + displayClear + "\" value=\"Clear\" onclick=\"" + ActionScript("'clear_company'", "'" + company.Uid + "'") + "\" />");
            viewHandle.ScriptsToRun.Add("$('#clear_" + company.Uid + "').button();");

            sb.AppendLine("<input id=\"choose_" + company.Uid + "\" type=\"button\" style=\"float: right; font-size: smaller\" value=\"Choose\" onclick=\"" + ActionScript("'choose_company'", "'" + company.Uid + "'") + "\" />");
            viewHandle.ScriptsToRun.Add("$('#choose_" + company.Uid + "').button();");

            sb.AppendLine("<br /><br />");

            RenderCriteriaFooter(sb, company, viewHandle);

            //company.TheID = actArgs.Var("id_" + company.Uid);
            //company.TheName = actArgs.Var("name_" + company.Uid);
        }
        //boolean has a separate implementation of this
        void RenderCriteriaHeader(StringBuilder sb, ReportCriteria criteria, ViewHandle viewHandle, String iconFile, bool includeSummary = false)
        {
            String title = "";
            if (Tools.Strings.StrExt(criteria.Description))
                title = " title=\"" + HttpUtility.HtmlEncode(criteria.Description) + "\"";

            sb.AppendLine("<div class=\"ui-corner-all\" style=\"width: 98%; border: thin solid #CCCCCC; margin: 2px; margin-bottom: 4px;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tr><td width=\"24px\"><img src=\"Graphics/" + iconFile + "\"" + title  +  "/></td><td><font size=\"larger\">" + criteria.Caption + "</font></td><td align=\"right\">");

            if (includeSummary)
                RenderSummaryOptions(sb, criteria, viewHandle);

            sb.AppendLine("</td></tr></table>");
        }
        void RenderCriteriaFooter(StringBuilder sb, ReportCriteria criteria, ViewHandle viewHandle)
        {
            sb.AppendLine("</div>");
        }
        void RenderSummaryOptions(StringBuilder sb, ReportCriteria criteria, ViewHandle viewHandle)
        {
            if (TheReport.Totals.Count == 0)
                return;

            sb.AppendLine("<div id=\"summaryOptions_" + criteria.Uid + "\">");

            sb.AppendLine("<img src=\"Graphics/Summarize.png\" class=\"rz-summary-button\" id=\"cmdSummarize_" + criteria.Uid + "\" style=\"cursor: pointer; margin: 2px\" onclick=\"ChartClose(); RunReport();" + ActionScriptPlusControls("'summarize'", "'" + criteria.Uid + "'") + "\" title=\"Summarize\" alt=\"Summarize\" />");
            sb.AppendLine("<img src=\"Graphics/SummarizeChart.png\" class=\"rz-summary-button\" id=\"cmdSummarizeChart_" + criteria.Uid + "\" style=\"cursor: pointer; margin: 2px\" onclick=\"ChartClose(); RunReport();" + ActionScriptPlusControls("'summarize_chart'", "'" + criteria.Uid + "'") + "\"  title=\"Summarize and Chart\" alt=\"Summarize and Chart\" />");

            sb.AppendLine("</div>");
        }
        void Export(Rz5.ContextRz x)
        {
            String bilge = @"c:\bilge\";
            if (!Directory.Exists(bilge))
                Directory.CreateDirectory(bilge);

            String exportFile = bilge + Tools.Files.FilterFileNameTrash(TheReport.Title) + "_" + Tools.Folder.GetNowPathPlusTime() + ".xlsx";
            ReportTargetExcel excel = new ReportTargetExcel(exportFile);
            excel.Render(x, TheReport);
            excel.SaveExcel();

            ExportedFile = exportFile;
            Change();
        }
        ArrayList GetAgentList(ContextRz x, bool OnlyActiveSalespeople)
        {
            ArrayList agents = new ArrayList();
            if (OnlyActiveSalespeople)
            {
                foreach (Rz5.n_user u in ((ContextRz)x).xSys.Users.All)
                {
                    if (u.is_inactive)
                        continue;
                    if (!u.is_sales && !Tools.Strings.HasString(u.job_desc, "sales"))
                        continue;
                    agents.Add(u.name);
                }
            }
            else
            {
                foreach (Rz5.n_user u in ((ContextRz)x).xSys.Users.All)
                {
                    if (!u.is_inactive)
                        agents.Add(u.name);
                }
            }
            return agents;
        }
        public override string ScriptToolsRender(Page page, ViewHandle viewHandle)
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendLine(base.ScriptToolsRender(page, viewHandle));
            ret.AppendLine("var chartMode = false;");
            ret.AppendLine("var reportHidden = false;");
            ret.AppendLine("function RunReport() { Spin('contentDiv'); $('#reportButton').hide(); $('#contentOptions').hide(); $('#totalLabelSpan').text(''); }");
            ret.AppendLine("function ChartClose() { reportHidden = false; chartMode = false; " + Chart.Select + ".empty(); " + Chart.Select + ".hide(); " + Result.Select + ".show(); DoResize(); }");
            return ret.ToString();
        }
        private void ShowItem(ContextRz x, String info)
        {
            string classname = Tools.Strings.ParseDelimit(info, "__dot__", 1).Trim();
            string id = Tools.Strings.ParseDelimit(info, "__dot__", 2).Trim();
            if (!Tools.Strings.StrExt(classname))
                return;
            if (!Tools.Strings.StrExt(id))
                return;
            nObject o = (nObject)x.QtO(classname, "select * from " + classname + " where unique_id = '" + id + "'");
            if (o == null)
                return;
            ShowArgs a = new ShowArgs(x, o);
            if (classname.ToLower().StartsWith("ordhed"))
            {
                switch (classname.ToLower())
                {
                    case "ordhed_invoice":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.Invoice);
                        break;
                    case "ordhed_purchase":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.Purchase);
                        break;
                    case "ordhed_quote":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.Quote);
                        break;
                    case "ordhed_rfq":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.RFQ);
                        break;
                    case "ordhed_rma":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.RMA);
                        break;
                    case "ordhed_sales":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.Sales);
                        break;
                    case "ordhed_service":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.Service);
                        break;
                    case "ordhed_vendrma":
                        a = new ShowArgsOrder(x, o, Rz5.Enums.OrderType.VendRMA);
                        break;
                }
            }
            x.Show(a);
        }
    }
    public class ReportResult : Spot
    {
        public bool ChartMode = false;
        ReportScreen Screen;

        public ReportResult(ReportScreen screen)
        {
            Screen = screen;
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#contentDiv').css('left', 0);");
            sb.AppendLine("$('#contentDiv').css('top', 0);");

            RunDivToRight(sb, "contentDiv");
            RunDivToBottom(sb, "contentDiv");
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            ContextRz xrz = (ContextRz)x;

            sb.AppendLine("<div id=\"contentDiv\" style=\"position: absolute; overflow: scroll\">");

            if (viewHandle.InitialRender)
            {
                if (Screen.AutoCalc)
                {
                    viewHandle.ScriptsToRun.Add("RunReport();");
                    viewHandle.ScriptsToRun.Add(Screen.ActionScriptPlusControls("'refresh'", "''"));
                }
                else
                {
                    RenderDescription(xrz, sb, viewHandle);
                }
            }
            else
            {
                ReportTargetHtmlWeb html = ((LeaderWebUserRz)x.TheLeader).GetReportTargetHtmlWeb(Screen);  //new ReportTargetHtmlWeb(Screen);
                html.UseChartColumnColors = ChartMode;
                html.Render(xrz, Screen.TheReport);
                html.RenderStyle(sb);
                sb.Append(html.HtmlResultInner);
                viewHandle.ScriptsToRun.Add("$('#contentOptions').show();");
                viewHandle.ScriptsToRun.Add("$('#totalLabelSpan').text('" + Tools.Strings.PluralizePhrase("Result", Screen.TheReport.ResultCount) + "');");
            }

            sb.AppendLine("</div>");

            //this is based on the report now, not the status of the result
            //if (Screen.TheReport.Totals.Count > 0)
            //    viewHandle.ScriptsToRun.Add("$('.rz-summary-button').show();");
            //else
            //    viewHandle.ScriptsToRun.Add("$('.rz-summary-button').hide();");

            viewHandle.ScriptsToRun.Add("$('#reportButton').show();");
            viewHandle.ScriptsToRun.Add("var wasHidden = reportHidden; reportHidden = false; if( wasHidden ) DoResize();");
        }
        void RenderDescription(ContextRz context, StringBuilder sb, ViewHandle viewHandle)
        {
            Core.Report r = Screen.TheReport;
            sb.Append("<div style=\"margin-top: 20px\"><center><table cellpadding=\"4px\" cellspacing=\"0\" style=\"border: thin solid #CCCCCC\"><tr><td colspan=\"3\" align=\"center\" style=\"background-color: #CCCCCC; color: white; font-weight: bold; padding: 2px;\"><font size=\"larger\"><b>" + r.Title + "</b></font></td></tr>");

            if (Tools.Strings.StrExt(r.Description))
            {
                sb.Append("<tr><td colspan=\"3\" style=\"border-top: thin solid #CCCCCC\" align=\"left\">Description:<br>");
                sb.Append("<p class=\"core-report-description\">" + HttpUtility.HtmlEncode(r.Description) + "</p>");
            }

            sb.Append("</td></tr>");

            sb.Append("<tr><td align=\"left\" valign=\"top\" width=\"210px\" style=\"border-top: thin solid #CCCCCC\" align=\"left\">Columns:<br><ul>");

            foreach (ReportColumn c in r.ColumnsList)
            {
                sb.Append("<li>" + HttpUtility.HtmlEncode(c.Caption) + "</li>");
            }

            sb.Append("</ul></td>");

            if (r.Totals.Count > 0)
            {
                sb.Append("<td align=\"left\" valign=\"top\" width=\"210px\" style=\"border-top: thin solid #CCCCCC; border-left: thin solid #CCCCCC\" align=\"left\">Totals:<br><ul>");

                foreach (ReportTotal t in r.Totals)
                {
                    sb.Append("<li>" + HttpUtility.HtmlEncode(t.Caption));
                    sb.Append("</li>");
                }

                sb.Append("</ul></td>");
            }

            ReportArgs args = r.ArgsCreate(context);

            if (args.Criteria.Count > 0)
            {
                sb.Append("<td align=\"left\" valign=\"top\" width=\"210px\" style=\"border-top: thin solid #CCCCCC; border-left: thin solid #CCCCCC\" align=\"left\">Criteria:<br><ul>");

                foreach (ReportCriteria c in args.Criteria)
                {
                    sb.Append("<li>" + HttpUtility.HtmlEncode(c.Caption));

                    if (Tools.Strings.StrExt(c.Description))
                        sb.Append("<p class=\"core-report-description\">" + HttpUtility.HtmlEncode(c.Description) + "</p>");

                    sb.Append("</li>");
                }

                sb.Append("</ul></td>");
            }

            sb.Append("</tr></table></center></div>");
        }
    }
    public class ReportTargetHtmlWeb : ReportTargetHtml
    {
        public Spot ActionSpot;

        public ReportTargetHtmlWeb(Spot actionSpot)
            : base(true)//false
        {
            ActionSpot = actionSpot;
        }
        protected override void RenderSummaryLink(ReportLine l, ref string hyperStart, ref string hyperEnd)
        {
            hyperStart = "<a href=\"#\" onclick=\"RunReport();" + ActionSpot.ActionScript("'summary_line'", "'" + l.Uid + "'") + "\">";
            hyperEnd = "</a>";
        }
        protected override void RenderColumnHeader(Core.Report r, ReportColumn c)
        {
            //base.RenderColumnHeader(r, c);

            String align = "";

            if (c.Alignment == ColumnAlignment.Right)
                align = " align=\"right\"";
            else if (c.Alignment == ColumnAlignment.Center)
                align = " align=\"center\"";
            else
                align = " align=\"left\"";  //sometimes is centered for some reason

            String chart = "";
            if (c.ColumnSummary)
            {
                chart = "<div style=\"float: right\"><img style=\"margin-left: 8px\" src=\"Graphics/SmallBar.png\" title=\"Bar Chart - " + c.Caption + "\" onclick=\"" + ActionSpot.ActionScript("'column_bar_chart'", "'" + c.Index.ToString() + "'") + " (arguments[0] || window.event).stopPropagation();\" />";

                if (c.ColumnSummaryCount <= 20)
                    chart += "<img src=\"Graphics/SmallPie.png\" title=\"Pie Chart - " + c.Caption + "\" onclick=\"" + ActionSpot.ActionScript("'column_pie_chart'", "'" + c.Index.ToString() + "'") + " (arguments[0] || window.event).stopPropagation();\" />";

                chart += "</div>";
            }

            Write("<th class=\"rz-report\" " + align + "bgcolor=\"cccccc\" style=\"cursor: pointer\" onclick=\"RunReport();" + ActionSpot.ActionScript("'column_sort'", "'" + c.Index.ToString() + "'") + "\"><b>" + c.Caption + "</b>" + chart + "</th>");
        }
        protected override void RenderHyperLink(ReportCell c, ref string hyper_beg, ref string hyper_end)
        {
            if (c.ItemTag != null)
            {
                if (c.ItemTag.Valid)
                {
                    hyper_beg = "<a href=\"#\" onclick=\"" + ActionSpot.ActionScript("'show_item'", "'" + c.ItemTag.ClassId + "__dot__" + c.ItemTag.Uid + "'") + "\">";
                    hyper_end = "</a>";
                }
            }
            else if (c.Command != "")
            {
                if (!c.Command.Contains("history.rzl"))
                    return;

                hyper_beg = "<a href=\"#\" onclick=\"" + ActionSpot.ActionScript("'report_command'", "'" + c.Command + "'") + "\">";
                hyper_end = "</a>";
            }
        }
    }
}