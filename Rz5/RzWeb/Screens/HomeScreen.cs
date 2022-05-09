using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Rz5.Web;
using System.Web.UI;

namespace RzWeb
{
    public class HomeScreen : RzScreen
    {
        ListViewSpotHome lvResults;
        DateControl dtStart;
        DateControl dtEnd;
        String OptionsDiv
        {
            get
            {
                return "home_options_" + Uid;
            }
        }
        String ResultsDiv
        {
            get
            {
                return "results_" + Uid;
            }
        }
        String ChoicesDiv
        {
            get
            {
                return "home_choices_" + Uid;
            }
        }
        String AgentsDiv
        {
            get
            {
                return "home_agents_" + Uid;
            }
        }
        ContextRz TheContext;
        Screen TheScreen;
        ViewHandle TheView;
        System.Web.SessionState.HttpSessionState TheSession;
        System.Web.UI.Page ThePage;
        ArrayList aAgents = new ArrayList();

        public HomeScreen(ContextRz x)
            : base(x)
        {
            dtStart = (DateControl)SpotAdd(ControlAdd(new DateControl("dtStart", "Start Date", Tools.Dates.GetBlankDate())));
            dtEnd = (DateControl)SpotAdd(ControlAdd(new DateControl("dtEnd", "End Date", Tools.Dates.GetBlankDate())));           
            lvResults = (ListViewSpotHome)SpotAdd(new ListViewSpotHome());
            lvResults.SkipParentRender = true;
            lvResults.TheArgs = new ListArgs(x);
            lvResults.TheArgs.AddAllow = false;
            lvResults.ItemDoubleClicked += new ItemDoubleClickHandler(lvResults_ItemDoubleClicked);
            if (!((LeaderWebUserRz)x.TheLeaderRz).DemoInfoCleared(x))
                RunSearch(x);            
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "Home Screen";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            ArrayList AllOptions = ((ContextRz)x).TheLogicRz.GetHomeScreenOptions(((ContextRz)x).xUserRz);
            HomeScreenOption opt = null;
            switch (args.ActionId.ToLower())
            {
                case "order batches":
                    opt = GetOptionByName(AllOptions, "ordertrees");
                    break;
                case "quotes":
                    opt = GetOptionByName(AllOptions, "mergedquotes");
                    break;
                case "bids":
                    opt = GetOptionByName(AllOptions, "mergedbids");
                    break;
                case "sales orders":
                    opt = GetOptionByName(AllOptions, "salesorders");
                    break;
                case "purchase orders":
                    opt = GetOptionByName(AllOptions, "purchaseorders");
                    break;
                case "invoices":
                    opt = GetOptionByName(AllOptions, "invoices");
                    break;
                case "calls":
                    opt = GetOptionByName(AllOptions, "calls");
                    break;
                default:
                    break;
            }
            if (opt == null)
                return;
            ShowOption((ContextRz)x, opt, args.ActionParams);
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheContext = (ContextRz)x;
            TheScreen = screenHandle;
            TheView = viewHandle;
            TheSession = session;
            ThePage = page;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"home_options_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 175px;\">");
            dtStart.Render(x, sb, screenHandle, viewHandle, session, page);
            dtEnd.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"home_choices_" + Uid + "\" style=\"position: absolute; overflow: scroll; padding: 6px; height: 145px; width: 175px; left: 0px;\">");
            sb.AppendLine("   <table border=\"0\" width=\"100%\" cellspacing=\"0\">");
            sb.AppendLine(GetHomeOptions(page));
            sb.AppendLine("   </table>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"home_agents_" + Uid + "\" style=\"position: absolute; overflow: scroll; padding: 6px; width: 175px; left: 0px;\">");
            sb.AppendLine(GetAgentList((ContextRz)x));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"results_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 230px;\">");
            lvResults.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, OptionsDiv);
            RunDivToBottom(sb, OptionsDiv);
            PlaceDivBelowMenu(sb, ResultsDiv);
            PlaceDivRight(sb, ResultsDiv, OptionsDiv);
            RunDivToBottom(sb, ResultsDiv);
            RunDivToRight(sb, ResultsDiv);
            sb.AppendLine(dtStart.Select + ".css('left', 2);");
            sb.AppendLine(dtStart.Select + ".css('top', 2);");
            sb.AppendLine(dtEnd.Select + ".css('left', 2);");
            sb.AppendLine(dtEnd.PlaceBelow(dtStart));
            sb.AppendLine("$('#home_choices_" + Uid + "').css('top', " + dtEnd.Select + ".position().top + " + dtEnd.Select + ".height());");
            PlaceDivBelowDiv(sb, AgentsDiv, ChoicesDiv);
            sb.AppendLine("$('#home_agents_" + Uid + "').css('top', $('#home_agents_" + Uid + "').position().top + 5);");
            sb.AppendLine("$('#" + AgentsDiv + "').css('height', $('#" + OptionsDiv + "').height() - $('#home_agents_" + Uid + "').position().top - 2);");
            sb.AppendLine(lvResults.Select + ".css('top', 2);");
            sb.AppendLine(lvResults.Select + ".css('left', 2);");
            sb.AppendLine(lvResults.Select + ".css('width', $('#" + ResultsDiv + "').width() - 4);");
            sb.AppendLine(lvResults.Select + ".css('height', $('#" + ResultsDiv + "').height() - 4);");            
            BoolControl prev = null;
            foreach (BoolControl b in aAgents)
            {
                if (prev == null)
                {
                    prev = b;
                    continue;
                }
                sb.AppendLine(b.PlaceBelow(prev));
                prev = b;
            }
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function HomeSearch(varType) {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("varType", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
        }
        private void AdjustControls()
        {
            dtStart.CaptionFontSize = FontSize.XSmall;
            dtStart.TextFontSize = FontSize.XSmall;
            dtStart.FixedWidth = 175;
            dtEnd.CaptionFontSize = FontSize.XSmall;
            dtEnd.TextFontSize = FontSize.XSmall;
            dtEnd.FixedWidth = 175;
            lvResults.ExtraStyle = "; font-size: small";
        }
        private string GetHomeOptions(System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            //Order Batches
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Order Batches');\">Order Batches</a></b></font></td>");
            sb.AppendLine("      </tr>");
            //Quotes
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Quotes');\">Quotes</a></b></font></td>");
            sb.AppendLine("      </tr>");
            //Bids
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Bids');\">Bids</a></b></font></td>");
            sb.AppendLine("      </tr>");
            //Sales Orders
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Sales Orders');\">Sales Orders</a></b></font></td>");
            sb.AppendLine("      </tr>");
            //Purchase Orders
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Purchase Orders');\">Purchase Orders</a></b></font></td>");
            sb.AppendLine("      </tr>");
            //Invoices
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Invoices');\">Invoices</a></b></font></td>");
            sb.AppendLine("      </tr>");
            //Calls
            sb.AppendLine("      <tr>");
            sb.AppendLine("         <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
            sb.AppendLine("         <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"Spin('" + DivIdConvert(lvResults.Uid) + "');HomeSearch('Calls');\">Calls</a></b></font></td>");
            sb.AppendLine("      </tr>");
            return sb.ToString();
        }
        private string GetAgentList(ContextRz x)
        {
            aAgents = new ArrayList();
            StringBuilder sb = new StringBuilder();
            BoolControl bc = (BoolControl)SpotAdd(ControlAdd(new BoolControl("bool_" + x.xUserRz.unique_id, x.xUserRz.name, true)));
            bc.Render(x, sb, TheScreen, TheView, TheSession, ThePage);
            aAgents.Add(bc);
            ArrayList a;
            if (x.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
                a = x.TheLogicRz.SalesPeople;
            else
            {
                ArrayList b = x.xUserRz.GetCaptainUsers(x);
                a = new ArrayList();
                foreach (NewMethod.n_user u in b)
                {
                    a.Add(u.name);
                }
            }
            foreach (String n in a)
            {
                if (Tools.Strings.StrCmp(n, "Recognin Technologies"))
                    continue;
                if (Tools.Strings.StrCmp(n, "RzSystem"))
                    continue;
                if (!Tools.Strings.StrCmp(n, x.xUserRz.name))
                {
                    bool check = false;
                    if (n.Trim().ToLower().Contains("example"))
                        check = true;
                    BoolControl bcc = (BoolControl)SpotAdd(ControlAdd(new BoolControl("bool_" + x.xSys.TranslateUserNameToID(n), n, check)));
                    bcc.Render(x, sb, TheScreen, TheView, TheSession, ThePage);
                    aAgents.Add(bcc);
                }
            }
            return sb.ToString();
        }
        private void RunSearch(ContextRz x)
        {
            HomePanelBatchesArgs args = new HomePanelBatchesArgs("", false, false);
            lvResults.ClassId = "dealheader";
            lvResults.TheArgs = new ListArgs(x);
            lvResults.TheArgs.TheLimit = 200;
            lvResults.TheArgs.TheWhere = "isnull(manually_created, 0) = 1 and dealheader.base_mc_user_uid in('" + x.xSys.TranslateUserNameToID("Bob Example") + "')";
            lvResults.TheArgs.TheOrder="dealheader.start_date desc";
            lvResults.TheArgs.AddAllow = false;
            lvResults.TheArgs.TheClass = "dealheader";
            lvResults.TheArgs.TheTable = "dealheader";
            lvResults.TheArgs.TheTemplate = "USERDEALS";
            lvResults.TheArgs.TheCaption = "Order Batches";
            lvResults.CurrentTemplate = n_template.GetByName(x, "USERDEALS");
            if (lvResults.CurrentTemplate == null)
                lvResults.CurrentTemplate = n_template.Create(x, "dealheader", "USERDEALS");
            lvResults.CurrentTemplate.GatherColumns(x);
            lvResults.ColSource = new ColumnSourceTemplate(lvResults.CurrentTemplate);
            lvResults.RowSource = new RowSourceTable(x.Select(lvResults.TheArgs.RenderSql(x, lvResults.CurrentTemplate)));
            lvResults.Change();
        }
        private HomeScreenOption GetOptionByName(ArrayList options, String s)
        {
            foreach (HomeScreenOption o in options)
            {
                if (Tools.Strings.StrCmp(o.Name, s))
                    return o;
            }
            return null;
        }
        private void ShowOption(ContextRz x, HomeScreenOption opt, String s)
        {
            HomePanelSearchArgs args = new HomePanelSearchArgs();
            if (opt.Name == "ordertrees")
                args = new HomePanelBatchesArgs("", false, false);
            Dictionary<string, string> d = ParseValueString(s);
            string str = "";
            d.TryGetValue("dtStart", out str);
            DateTime dtStart = Tools.Dates.GetBlankDate();
            try { dtStart = Convert.ToDateTime(str); }
            catch { }  
            str = "";
            d.TryGetValue("dtEnd", out str);
            DateTime dtEnd = Tools.Dates.GetBlankDate();
            try { dtEnd = Convert.ToDateTime(str); }
            catch { }           
            String datefield = opt.ClassName + ".date_created";
            switch (opt.ClassName.ToLower())
            {
                case "calllog":
                    datefield = "calllog.datecall";
                    break;
                case "quote":
                    datefield = "quote.quotedate";
                    break;
                case "ordhed":
                    datefield = "ordhed.orderdate";
                    break;
            }
            Boolean ss = IsValidDate(dtStart);
            Boolean ee = IsValidDate(dtEnd);
            if (ss && ee)
                opt.DateRange = " " + datefield + " between cast('" + dtStart.ToShortDateString() + " 00:00:00' as datetime) and cast('" + dtEnd.ToShortDateString() + "  23:59:59' as datetime) ";
            else if (ss)
                opt.DateRange = " " + datefield + " >= cast('" + dtStart.ToShortDateString() + " 00:00:00' as datetime) ";
            else if (ee)
                opt.DateRange = " " + datefield + "  between cast('" + dtEnd.ToShortDateString() + " 00:00:00' as datetime) and cast('" + dtEnd.ToShortDateString() + "  23:59:59' as datetime) ";
            foreach (KeyValuePair<string, string> kvp in d)
            {
                if (!kvp.Key.StartsWith("bool_"))
                    continue;
                if (Tools.Strings.StrCmp(kvp.Value, "undefined"))
                    continue;
                if (Tools.Strings.StrExt(opt.SelectedIDs))
                    opt.SelectedIDs += ", ";
                opt.SelectedIDs += "'" + x.Filter(kvp.Key.Replace("bool_", "").Trim()) + "'";
            }
            lvResults.ClassId = opt.ClassName;
            lvResults.TheArgs = x.TheLogicRz.HomeScreenSearchArgsGet(x, opt, args);
            lvResults.TheArgs.AddAllow = false;
            lvResults.TheArgs.TheLimit = 200;
            lvResults.TheArgs.TheClass = opt.ClassName;
            lvResults.TheArgs.TheTable = opt.ClassName;
            lvResults.TheArgs.TheTemplate = opt.TemplateName;
            lvResults.CurrentTemplate = n_template.GetByName(x, opt.TemplateName);
            if (lvResults.CurrentTemplate == null)
                lvResults.CurrentTemplate = n_template.Create(x, opt.ClassName, opt.TemplateName);
            lvResults.CurrentTemplate.GatherColumns(x);
            lvResults.ColSource = new ColumnSourceTemplate(lvResults.CurrentTemplate);
            lvResults.RowSource = new RowSourceTable(x.Select(lvResults.TheArgs.RenderSql(x, lvResults.CurrentTemplate)));
            lvResults.Change();
        }
        private Boolean IsValidDate(DateTime dt)
        {
            //The rules for this is the date needs to be greater than 1950
            DateTime d = new DateTime(1950, 1, 1);
            if (dt < d)
                return false;
            return true;
        }
        private void lvResults_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            ShowArgs args = new ShowArgs(x, ViewType.SingleItem, item);
            if (item is ordhed)
            {
                ordhed o = (ordhed)item;
                args = new ShowArgsOrder(x, item, o.OrderType);
            }
            if (item is orddet_quote)
                args = new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Quote);
            if (item is orddet_rfq)
                args = new ShowArgsOrder(x, item, Rz5.Enums.OrderType.RFQ);
            x.Show(args);
        }
    }
    public class ListViewSpotHome : ListViewSpotRz
    {
        public ListViewSpotHome()
            : base("")
        {
        }
    }
}

