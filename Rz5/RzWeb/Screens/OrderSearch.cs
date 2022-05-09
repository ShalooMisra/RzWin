using System;
using System.Text;
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
using NewMethodWeb;
using System.Collections;

namespace RzWeb
{
    public class OrderSearch : RzScreen
    {
        ListViewSpotOrderSearch lvSearch;
        ListViewSpotBidsSearch lvBids;
        ListViewSpotQuoteSearch lvQuotes;
        ListViewSpotSalesSearch lvSales;
        ListViewSpotPurchaseSearch lvPurchase;
        ListViewSpotInvoiceSearch lvInvoice;
        ListViewSpotRMASearch lvRMA;
        ListViewSpotVRMASearch lvVRMA;
        ListViewSpotServiceSearch lvService;
        RadioButtonControl optOrderType;
        TextControl txtSearch;
        TextControl txtPartNumber;
        TextControl txtCompanyName;
        TextControl txtTracking;
        RadioButtonControl optStatus;
        BoolControl chkVoid;
        DateControl dtStart;
        DateControl dtEnd;
        AgentControl xAgent;
        bool bBids = false;
        bool bQuotes = false;
        bool bSales = false;
        bool bPurchase = false;
        bool bInvoice = false;
        bool bRMA = false;
        bool bVRMA = false;
        bool bService = false;
        String OptionsDiv
        {
            get
            {
                return "ordersearch_options_" + Uid;
            }
        }

        public OrderSearch(ContextRz x)
            : base(x)
        {
            InitListViews(x);
            txtSearch = (TextControl)SpotAdd(ControlAdd(new TextControl("txtSearch", "Order Number/PO Number")));
            optOrderType = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("optOrderType", "", "all", GetTypeOptions())));
            optOrderType.CountHorizontal = 3;
            optOrderType.CountVertical = 3;
            txtPartNumber = (TextControl)SpotAdd(ControlAdd(new TextControl("txtPartNumber", "PartNumber/Internal#")));
            txtCompanyName = (TextControl)SpotAdd(ControlAdd(new TextControl("txtCompanyName", "Company Name")));
            txtTracking = (TextControl)SpotAdd(ControlAdd(new TextControl("txtTracking", "Tracking Number")));
            optStatus = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("optStatus", "", "all", GetStatusOptions())));
            chkVoid = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkVoid", "Void", false)));
            dtStart = (DateControl)SpotAdd(ControlAdd(new DateControl("dtStart", "Start Date", Tools.Dates.GetNullDate())));
            dtEnd = (DateControl)SpotAdd(ControlAdd(new DateControl("dtEnd", "End Date", Tools.Dates.GetNullDate())));
            xAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("ctl_agent", "Agent", "", "", "agent_id", "agent_name", GetAgentArray(x))));
            txtSearch.OnEnterClick = "cmdSearch";
            if (!((LeaderWebUserRz)x.TheLeaderRz).DemoInfoCleared(x))
                RunSearch(x);
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "Order Search";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {
                case "clear_screen":
                    ClearScreen((ContextRz)x);
                    break;
                case "search":
                    DoSearch((ContextRz)x, args.ActionParams);
                    break;
                case "tabshow":
                    TabSwitched((ContextRz)x, args.ActionParams, args.SourceView);
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"ordersearch_options_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 230px;\">");
            txtSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            optOrderType.Render(x, sb, screenHandle, viewHandle, session, page);
            dtStart.Render(x, sb, screenHandle, viewHandle, session, page);
            dtEnd.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPartNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCompanyName.Render(x, sb, screenHandle, viewHandle, session, page);
            txtTracking.Render(x, sb, screenHandle, viewHandle, session, page);
            xAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            optStatus.Render(x, sb, screenHandle, viewHandle, session, page);
            chkVoid.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<center><input id=\"cmdClear\" type=\"button\" value=\"  Clear  \" onclick=\"" + ActionScript("'clear_screen'") + "\">&nbsp;&nbsp;&nbsp;<input id=\"cmdSearch\" type=\"button\" value=\"Search\" onclick=\"$('#tabHeader_" + Uid + "').get(0).TabHolder.tabs('select', 0); OrderSearch();\"></center>");
            Buttonize(viewHandle, "cmdSearch", "ordersmenu.png");
            Buttonize(viewHandle, "cmdClear", "clear.png");
            sb.AppendLine("</div>");
            //tabs
            sb.AppendLine("        <div id=\"tabHeader_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabHeaderNav\">");
            sb.AppendLine("                <li><a href=\"#tabSearch\" style=\"font-size: x-small\">Search Results</a></li>");
            sb.AppendLine("                <li><a href=\"#tabBids\" style=\"font-size: x-small\">Bids</a></li>");
            sb.AppendLine("                <li><a href=\"#tabQuotes\" style=\"font-size: x-small\">Formal Quotes</a></li>");
            sb.AppendLine("                <li><a href=\"#tabSales\" style=\"font-size: x-small\">Sales Orders</a></li>");
            sb.AppendLine("                <li><a href=\"#tabPurchases\" style=\"font-size: x-small\">POs</a></li>");
            sb.AppendLine("                <li><a href=\"#tabInvoices\" style=\"font-size: x-small\">Invoices</a></li>");
            sb.AppendLine("                <li><a href=\"#tabRMAs\" style=\"font-size: x-small\">RMAs</a></li>");
            sb.AppendLine("                <li><a href=\"#tabVRMAs\" style=\"font-size: x-small\">Vendor RMAs</a></li>");
            sb.AppendLine("                <li><a href=\"#tabService\" style=\"font-size: x-small\">Service</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabSearch\">");
            lvSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabBids\">");
            lvBids.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabQuotes\">");
            lvQuotes.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabSales\">");
            lvSales.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabPurchases\">");
            lvPurchase.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabInvoices\">");
            lvInvoice.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabRMAs\">");
            lvRMA.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabVRMAs\">");
            lvVRMA.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabService\">");
            lvService.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, OptionsDiv);
            RunDivToBottom(sb, OptionsDiv);
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('left', $('#" + OptionsDiv + "').width() + $('#" + OptionsDiv + "').position().left + " + Screen.LayoutTheta.ToString() + " + 18);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('top', $('#" + OptionsDiv + "').position().top + 4);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', $(window).width() - $('#tabHeader_" + Uid + "').position().left - 15);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', $('#" + OptionsDiv + "').height() + 5);");
            sb.AppendLine(lvSearch.Select + ".css('top', 2);");
            sb.AppendLine(lvSearch.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvSearch.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvBids.Select + ".css('top', 2);");
            sb.AppendLine(lvBids.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvBids.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvQuotes.Select + ".css('top', 2);");
            sb.AppendLine(lvQuotes.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvQuotes.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvSales.Select + ".css('top', 2);");
            sb.AppendLine(lvSales.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvSales.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvPurchase.Select + ".css('top', 2);");
            sb.AppendLine(lvPurchase.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvPurchase.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvInvoice.Select + ".css('top', 2);");
            sb.AppendLine(lvInvoice.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvInvoice.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvRMA.Select + ".css('top', 2);");
            sb.AppendLine(lvRMA.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvRMA.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvVRMA.Select + ".css('top', 2);");
            sb.AppendLine(lvVRMA.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvVRMA.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(lvService.Select + ".css('top', 2);");
            sb.AppendLine(lvService.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - 10);");
            sb.AppendLine(lvService.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 35);");
            sb.AppendLine(txtSearch.Select + ".css('top', 1);");
            sb.AppendLine(txtSearch.Select + ".css('left', 8);");
            sb.AppendLine(optOrderType.PlaceBelow(txtSearch, false, 0, 4));
            sb.AppendLine(optOrderType.Select + ".css('left', 8);");
            sb.AppendLine(dtStart.Select + ".css('left', 8);");
            sb.AppendLine(dtStart.PlaceBelow(optOrderType, false, 0, 7));
            sb.AppendLine(dtEnd.PlaceRight(dtStart));
            sb.AppendLine(dtEnd.PlaceBelow(optOrderType, false, 0, 7));
            sb.AppendLine(txtPartNumber.PlaceBelow(dtStart));
            sb.AppendLine(txtPartNumber.Select + ".css('left', 8);");
            sb.AppendLine(txtCompanyName.PlaceBelow(txtPartNumber));
            sb.AppendLine(txtCompanyName.Select + ".css('left', 8);");
            sb.AppendLine(txtTracking.PlaceBelow(txtCompanyName));
            sb.AppendLine(txtTracking.Select + ".css('left', 8);");
            sb.AppendLine(xAgent.PlaceBelow(txtTracking));
            sb.AppendLine(xAgent.Select + ".css('left', 8);");
            sb.AppendLine(optStatus.PlaceBelow(xAgent));
            sb.AppendLine(optStatus.Select + ".css('left', 8);");
            sb.AppendLine(chkVoid.PlaceBelow(xAgent));
            sb.AppendLine(chkVoid.PlaceRight(optStatus));
            sb.AppendLine("$('#cmdSearch').css('top', " + optStatus.Select + ".position().top + " + optStatus.Select + ".height() + 8);");
            sb.AppendLine("$('#cmdClear').css('top', " + optStatus.Select + ".position().top + " + optStatus.Select + ".height() + 8);");
            sb.AppendLine("$('#" + txtSearch.ControlId + "').css('width', $('#ordersearch_options_" + Uid + "').width() - " + txtSearch.Select + ".position().left);");
            sb.AppendLine("$('#" + txtPartNumber.ControlId + "').css('width',  $('#ordersearch_options_" + Uid + "').width() - " + txtPartNumber.Select + ".position().left);");
            sb.AppendLine("$('#" + txtCompanyName.ControlId + "').css('width',  $('#ordersearch_options_" + Uid + "').width() - " + txtCompanyName.Select + ".position().left);");
            sb.AppendLine("$('#" + txtTracking.ControlId + "').css('width',  $('#ordersearch_options_" + Uid + "').width() - " + txtTracking.Select + ".position().left);");
        }
        //Public Functions
        public String CurrentOrderClass(ContextRz x, Rz5.Enums.OrderType type)
        {
            if (type != Rz5.Enums.OrderType.Any)
                return ordhed.MakeOrdhedName(type);
            else
                return "ordhed";
        }
        public String CurrentOrderTable(ContextRz x, Rz5.Enums.OrderType type)
        {
            if (type != Rz5.Enums.OrderType.Any)
                return ordhed.MakeOrdhedName(type);
            else
                return "ordhed";
        }
        //Private Functions
        private OrderSearchParameters GetOrderSearchParameters(ContextRz x, Dictionary<string, string> d)
        {
            OrderSearchParameters p = new OrderSearchParameters();
            if (d == null)
                return p;
            string s = "";
            d.TryGetValue("txtSearch", out s);
            p.OrderNumber = s;
            s = "";
            d.TryGetValue("optOrderType", out s);
            p.OrderType = GetOrderType(s);
            DateTime dt = Tools.Dates.GetBlankDate();
            s = "";
            d.TryGetValue("dtStart", out s);
            if (Tools.Strings.StrExt(s))
            {
                try { dt = Convert.ToDateTime(s); }
                catch { }
                if (Tools.Dates.DateExists(dt))
                    p.StartDate = dt;
            }
            dt = Tools.Dates.GetBlankDate();
            s = "";
            d.TryGetValue("dtEnd", out s);
            if (Tools.Strings.StrExt(s))
            {
                try { dt = Convert.ToDateTime(s); }
                catch { }
                if (Tools.Dates.DateExists(dt))
                    p.EndDate = dt;
            }
            s = "";
            d.TryGetValue("txtPartNumber", out s);
            p.PartNumber = s;
            s = "";
            d.TryGetValue("txtCompanyName", out s);
            p.CompanyName = s;
            s = "";
            d.TryGetValue("txtTracking", out s);
            p.TrackingNumber = s;
            s = "";
            d.TryGetValue("optStatus", out s);
            if (!Tools.Strings.StrCmp(s, "closed") && !Tools.Strings.StrCmp(s, "open"))
                s = "";
            p.OrderStatus = s;
            s = "";
            d.TryGetValue("chkVoid", out s);
            p.IncludeVoid = Tools.Strings.StrCmp("void", s);
            s = "";
            d.TryGetValue("agent_name", out s);
            p.Agent = s;
            p.RowLimit = 200;
            p.DetailType = p.OrderType;
            p.CurrentOrderClass = CurrentOrderClass(x, p.OrderType);
            p.CurrentOrderTable = CurrentOrderTable(x, p.OrderType);
            p.CurrentOrderType = p.OrderType;
            return p;
        }
        private Rz5.Enums.OrderType GetOrderType(string type)
        {
            switch (type)
            {
                case "all":
                    return Rz5.Enums.OrderType.Any;
                case "sales":
                    return Rz5.Enums.OrderType.Sales;
                case "invoice":
                    return Rz5.Enums.OrderType.Invoice;
                case "bid":
                    return Rz5.Enums.OrderType.RFQ;
                case "purchase":
                    return Rz5.Enums.OrderType.Purchase;
                case "rma":
                    return Rz5.Enums.OrderType.RMA;
                case "quote":
                    return Rz5.Enums.OrderType.Quote;
                case "service":
                    return Rz5.Enums.OrderType.Service;
                case "vrma":
                    return Rz5.Enums.OrderType.VendRMA;
                default:
                    return Rz5.Enums.OrderType.Any;
            }
        }
        private void TabSwitched(ContextRz x, String tab, ViewHandle v)
        {
            string[] str = Tools.Strings.Split(tab, "|");
            Dictionary<string, string> d = ParseValueString(tab);
            tab = str[0];
            OrderSearchParameters p = new OrderSearchParameters();
            p.RowLimit = 200;
            string s = "";
            p.IncludeVoid = false;
            p.UnlimitedResults = false;
            if (x.xUserRz.GetSetting_Boolean(x, "restricted_user"))
                p.Agent = x.xUserRz.name;
            ListArgs args = new ListArgs(x);
            switch (tab.ToLower().Trim())
            {
                case "tabbids":
                    if (bBids)
                    {
                        lvBids.Change();
                        return;
                    }
                    bBids = true;
                    p.DetailType = Rz5.Enums.OrderType.RFQ;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvBids.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvBids.TheArgs == null)
                        return;
                    lvBids.RowSource = new RowSourceTable(x.Select(lvBids.TheArgs.RenderSql(x, lvBids.CurrentTemplate)));
                    lvBids.Change();
                    break;
                case "tabquotes":
                    if (bQuotes)
                    {
                        lvQuotes.Change();
                        return;
                    }
                    bQuotes = true;
                    p.DetailType = Rz5.Enums.OrderType.Quote;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvQuotes.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvQuotes.TheArgs == null)
                        return;
                    lvQuotes.RowSource = new RowSourceTable(x.Select(lvQuotes.TheArgs.RenderSql(x, lvQuotes.CurrentTemplate)));
                    lvQuotes.Change();
                    break;
                case "tabsales":
                    if (bSales)
                    {
                        lvSales.Change();
                        return;
                    }
                    bSales = true;
                    p.DetailType = Rz5.Enums.OrderType.Sales;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvSales.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvSales.TheArgs == null)
                        return;
                    lvSales.RowSource = new RowSourceTable(x.Select(lvSales.TheArgs.RenderSql(x, lvSales.CurrentTemplate)));
                    lvSales.Change();
                    break;
                case "tabpurchases":
                    if (bPurchase)
                    {
                        lvPurchase.Change();
                        return;
                    }
                    bPurchase = true;
                    p.DetailType = Rz5.Enums.OrderType.Purchase;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvPurchase.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvPurchase.TheArgs == null)
                        return;
                    lvPurchase.RowSource = new RowSourceTable(x.Select(lvPurchase.TheArgs.RenderSql(x, lvPurchase.CurrentTemplate)));
                    lvPurchase.Change();
                    break;
                case "tabinvoices":
                    if (bInvoice)
                    {
                        lvInvoice.Change();
                        return;
                    }
                    bInvoice = true;
                    p.DetailType = Rz5.Enums.OrderType.Invoice;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvInvoice.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvInvoice.TheArgs == null)
                        return;
                    lvInvoice.RowSource = new RowSourceTable(x.Select(lvInvoice.TheArgs.RenderSql(x, lvInvoice.CurrentTemplate)));
                    lvInvoice.Change();
                    break;
                case "tabrmas":
                    if (bRMA)
                    {
                        lvRMA.Change();
                        return;
                    }
                    bRMA = true;
                    p.DetailType = Rz5.Enums.OrderType.RMA;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvRMA.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvRMA.TheArgs == null)
                        return;
                    lvRMA.RowSource = new RowSourceTable(x.Select(lvRMA.TheArgs.RenderSql(x, lvRMA.CurrentTemplate)));
                    lvRMA.Change();
                    break;
                case "tabvrmas":
                    if (bVRMA)
                    {
                        lvVRMA.Change();
                        return;
                    }
                    bVRMA = true;
                    p.DetailType = Rz5.Enums.OrderType.VendRMA;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvVRMA.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvVRMA.TheArgs == null)
                        return;
                    lvVRMA.RowSource = new RowSourceTable(x.Select(lvVRMA.TheArgs.RenderSql(x, lvVRMA.CurrentTemplate)));
                    lvVRMA.Change();
                    break;
                case "tabservice":
                    if (bService)
                    {
                        lvService.Change();
                        return;
                    }
                    bService = true;
                    p.DetailType = Rz5.Enums.OrderType.Service;
                    p.CurrentOrderClass = CurrentOrderClass(x, p.DetailType);
                    p.CurrentOrderTable = CurrentOrderTable(x, p.DetailType);
                    p.CurrentOrderType = p.DetailType;
                    lvService.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
                    if (lvService.TheArgs == null)
                        return;
                    lvService.RowSource = new RowSourceTable(x.Select(lvService.TheArgs.RenderSql(x, lvService.CurrentTemplate)));
                    lvService.Change();
                    break;
                default:
                    lvSearch.Change();
                    break;
            }
        }
        private void RunSearch(ContextRz x)
        {
            txtSearch.Value = "200002";
            txtSearch.Change();
            OrderSearchParameters p = new OrderSearchParameters();
            p.OrderNumber = "200002";
            p.OrderType = Rz5.Enums.OrderType.Sales;
            p.RowLimit = 200;
            p.DetailType = p.OrderType;
            p.CurrentOrderClass = CurrentOrderClass(x, p.OrderType);
            p.CurrentOrderTable = CurrentOrderTable(x, p.OrderType);
            p.CurrentOrderType = p.OrderType;
            if (x.xUserRz.GetSetting_Boolean(x, "restricted_user"))
                p.Agent = x.xUserRz.name;
            ListArgs args = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
            nSQL sql = args.SQL;
            lvSearch.TheArgs = args;
            if (lvSearch.TheArgs == null)
                return;
            lvSearch.CurrentTemplate = n_template.GetByName(x, lvSearch.TheArgs.TheTemplate);
            if (lvSearch.CurrentTemplate == null)
                lvSearch.CurrentTemplate = n_template.Create(x, lvSearch.TheArgs.TheClass, lvSearch.TheArgs.TheTemplate);
            lvSearch.CurrentTemplate.GatherColumns(x);
            lvSearch.ColSource = new ColumnSourceTemplate(lvSearch.CurrentTemplate);
            lvSearch.RowSource = new RowSourceTable(x.Select(lvSearch.TheArgs.RenderSql(x, lvSearch.CurrentTemplate)));
            lvSearch.Change();
        }
        private void DoSearch(ContextRz x, String s)
        {
            Dictionary<string, string> d = ParseValueString(s);
            OrderSearchParameters p = GetOrderSearchParameters(x, d);
            if (x.xUserRz.GetSetting_Boolean(x, "restricted_user"))
                p.Agent = x.xUserRz.name;
            ListArgs args = x.TheSysRz.TheOrderLogic.OrdHedSearchCompanyArgsGet(x, p);
            nSQL sql = args.SQL;
            lvSearch.TheArgs = args;
            if (lvSearch.TheArgs == null)
                return;
            lvSearch.CurrentTemplate = n_template.GetByName(x, lvSearch.TheArgs.TheTemplate);
            if (lvSearch.CurrentTemplate == null)
                lvSearch.CurrentTemplate = n_template.Create(x, lvSearch.TheArgs.TheClass, lvSearch.TheArgs.TheTemplate);
            lvSearch.CurrentTemplate.GatherColumns(x);
            lvSearch.ColSource = new ColumnSourceTemplate(lvSearch.CurrentTemplate);
            lvSearch.RowSource = new RowSourceTable(x.Select(lvSearch.TheArgs.RenderSql(x, lvSearch.CurrentTemplate)));
            lvSearch.Change();
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function OrderSearch() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'search'", "data"));
            sb.AppendLine("}");
            sb.AppendLine("function TabSwitch() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine("     return data;");
            sb.AppendLine("}");
            sb.AppendLine("function GetTypeValue()");
            sb.AppendLine("{");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_all:checked').val() == 'all')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"all\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_sales:checked').val() == 'sales')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"sales\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_invoice:checked').val() == 'invoice')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"invoice\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_bid:checked').val() == 'bid')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"bid\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_purchase:checked').val() == 'purchase')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"purchase\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_rma:checked').val() == 'rma')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"rma\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_quote:checked').val() == 'quote')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"quote\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_service:checked').val() == 'service')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"service\";");
            sb.AppendLine("        }");
            sb.AppendLine("        if($('#" + optOrderType.ControlId + "_vrma:checked').val() == 'vrma')");
            sb.AppendLine("        {");
            sb.AppendLine("            return \"vrma\";");
            sb.AppendLine("        }");
            sb.AppendLine("        return \"\";");
            sb.AppendLine("}");
            sb.AppendLine("function GetDivID(tabID)");
            sb.AppendLine("{");
            sb.AppendLine("     switch(tabID)");
            sb.AppendLine("     {");
            sb.AppendLine("         case \"tabSearch\":");
            sb.AppendLine("             return \"" + lvSearch.DivId + "\";");
            sb.AppendLine("         case \"tabBids\":");
            sb.AppendLine("             return \"" + lvBids.DivId + "\";");
            sb.AppendLine("         case \"tabQuotes\":");
            sb.AppendLine("             return \"" + lvQuotes.DivId + "\";");
            sb.AppendLine("         case \"tabSales\":");
            sb.AppendLine("             return \"" + lvSales.DivId + "\";");
            sb.AppendLine("         case \"tabPurchases\":");
            sb.AppendLine("             return \"" + lvPurchase.DivId + "\";");
            sb.AppendLine("         case \"tabInvoices\":");
            sb.AppendLine("             return \"" + lvInvoice.DivId + "\";");
            sb.AppendLine("         case \"tabRMAs\":");
            sb.AppendLine("             return \"" + lvRMA.DivId + "\";");
            sb.AppendLine("         case \"tabVRMAs\":");
            sb.AppendLine("             return \"" + lvVRMA.DivId + "\";");
            sb.AppendLine("         case \"tabService\":");
            sb.AppendLine("             return \"" + lvService.DivId + "\";");
            sb.AppendLine("     }");
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("var tabHolder = $('#tabHeader_" + Uid + "').tabs( { select: function(event, ui) { Spin(GetDivID(ui.panel.id)); " + ActionScript("'tabShow'", "ui.panel.id + '|' + TabSwitch()") + " } }); $('#tabHeader_" + Uid + "').get(0).TabHolder = tabHolder");
            viewHandle.ScriptsToRun.Add("$('#txtSearch').focus();");
        }
        private RadioControlConfig GetTypeOptions()
        {
            RadioControlConfig c = new RadioControlConfig();
            //All
            RadioControlConfig r = new RadioControlConfig();
            r.Caption = "All";
            r.Value = "all";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //Sales
            r = new RadioControlConfig();
            r.Caption = "Sales";
            r.Value = "sales";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //Invoice
            r = new RadioControlConfig();
            r.Caption = "Invoice";
            r.Value = "invoice";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //Bid
            r = new RadioControlConfig();
            r.Caption = "Bid";
            r.Value = "bid";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //Purchase
            r = new RadioControlConfig();
            r.Caption = "Purchase";
            r.Value = "purchase";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //RMA
            r = new RadioControlConfig();
            r.Caption = "RMA";
            r.Value = "rma";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //Quote
            r = new RadioControlConfig();
            r.Caption = "Quote";
            r.Value = "quote";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //Service
            r = new RadioControlConfig();
            r.Caption = "Service";
            r.Value = "service";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            //VRMA
            r = new RadioControlConfig();
            r.Caption = "vRMA";
            r.Value = "vrma";
            r.OnClick = ActionScript("'type_changed'", "GetTypeValue()");
            r.FontSize = FontSize.Small;
            c.AllOptions.Add(r);
            return c;
        }
        private RadioControlConfig GetStatusOptions()
        {
            RadioControlConfig c = new RadioControlConfig();
            //All
            RadioControlConfig r = new RadioControlConfig();
            r.Caption = "All";
            r.Value = "all";
            //r.FontSize = FontSize.Small;
            //r.OnClick = "";
            //r.Bold = true;
            c.AllOptions.Add(r);
            //Open
            r = new RadioControlConfig();
            r.Caption = "Open";
            r.Value = "open";
            //r.FontSize = FontSize.Small;
            //r.OnClick = "";
            //r.Bold = true;
            c.AllOptions.Add(r);
            //Closed
            r = new RadioControlConfig();
            r.Caption = "Closed";
            r.Value = "closed";
            //r.FontSize = FontSize.Small;
            //r.OnClick = "";
            //r.Bold = true;
            c.AllOptions.Add(r);
            return c;
        }
        private void InitListViews(ContextRz x)
        {
            lvSearch = (ListViewSpotOrderSearch)SpotAdd(new ListViewSpotOrderSearch());
            lvSearch.SkipParentRender = true;
            lvSearch.TheArgs = new ListArgs(x);
            lvSearch.TheArgs.AddAllow = false;
            lvSearch.TheArgs.TheClass = "ordhed";
            lvSearch.TheArgs.TheLimit = 200;
            lvSearch.TheArgs.TheTable = "ordhed";
            lvSearch.TheArgs.TheTemplate = "order_search_results";
            lvSearch.CurrentTemplate = n_template.GetByName(x, lvSearch.TheArgs.TheTemplate);
            if (lvSearch.CurrentTemplate == null)
                lvSearch.CurrentTemplate = n_template.Create(x, lvSearch.TheArgs.TheClass, lvSearch.TheArgs.TheTemplate);
            lvSearch.CurrentTemplate.GatherColumns(x);
            lvSearch.ColSource = new ColumnSourceTemplate(lvSearch.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvSearch.ItemDoubleClicked += new ItemDoubleClickHandler(lvSearch_ItemDoubleClicked);

            lvBids = (ListViewSpotBidsSearch)SpotAdd(new ListViewSpotBidsSearch());
            lvBids.SkipParentRender = true;
            lvBids.TheArgs = new ListArgs(x);
            lvBids.TheArgs.AddAllow = false;
            lvBids.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.RFQ);
            lvBids.TheArgs.TheLimit = 200;
            lvBids.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.RFQ);
            lvBids.TheArgs.TheTemplate = "ORDERSEARCH-RFQ";
            lvBids.CurrentTemplate = n_template.GetByName(x, lvBids.TheArgs.TheTemplate);
            if (lvBids.CurrentTemplate == null)
                lvBids.CurrentTemplate = n_template.Create(x, lvBids.TheArgs.TheClass, lvBids.TheArgs.TheTemplate);
            lvBids.CurrentTemplate.GatherColumns(x);
            lvBids.ColSource = new ColumnSourceTemplate(lvBids.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvBids.ItemDoubleClicked += new ItemDoubleClickHandler(lvBids_ItemDoubleClicked);

            lvQuotes = (ListViewSpotQuoteSearch)SpotAdd(new ListViewSpotQuoteSearch());
            lvQuotes.SkipParentRender = true;
            lvQuotes.TheArgs = new ListArgs(x);
            lvQuotes.TheArgs.AddAllow = false;
            lvQuotes.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Quote);
            lvQuotes.TheArgs.TheLimit = 200;
            lvQuotes.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Quote);
            lvQuotes.TheArgs.TheTemplate = "ORDERSEARCH-QUOTE";
            lvQuotes.CurrentTemplate = n_template.GetByName(x, lvQuotes.TheArgs.TheTemplate);
            if (lvQuotes.CurrentTemplate == null)
                lvQuotes.CurrentTemplate = n_template.Create(x, lvQuotes.TheArgs.TheClass, lvQuotes.TheArgs.TheTemplate);
            lvQuotes.CurrentTemplate.GatherColumns(x);
            lvQuotes.ColSource = new ColumnSourceTemplate(lvQuotes.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvQuotes.ItemDoubleClicked += new ItemDoubleClickHandler(lvQuotes_ItemDoubleClicked);

            lvSales = (ListViewSpotSalesSearch)SpotAdd(new ListViewSpotSalesSearch());
            lvSales.SkipParentRender = true;
            lvSales.TheArgs = new ListArgs(x);
            lvSales.TheArgs.AddAllow = false;
            lvSales.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Sales);
            lvSales.TheArgs.TheLimit = 200;
            lvSales.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Sales);
            lvSales.TheArgs.TheTemplate = "ORDERSEARCH-SALES";
            lvSales.CurrentTemplate = n_template.GetByName(x, lvSales.TheArgs.TheTemplate);
            if (lvSales.CurrentTemplate == null)
                lvSales.CurrentTemplate = n_template.Create(x, lvSales.TheArgs.TheClass, lvSales.TheArgs.TheTemplate);
            lvSales.CurrentTemplate.GatherColumns(x);
            lvSales.ColSource = new ColumnSourceTemplate(lvSales.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvSales.ItemDoubleClicked += new ItemDoubleClickHandler(lvSales_ItemDoubleClicked);

            lvPurchase = (ListViewSpotPurchaseSearch)SpotAdd(new ListViewSpotPurchaseSearch());
            lvPurchase.SkipParentRender = true;
            lvPurchase.TheArgs = new ListArgs(x);
            lvPurchase.TheArgs.AddAllow = false;
            lvPurchase.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Purchase);
            lvPurchase.TheArgs.TheLimit = 200;
            lvPurchase.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Purchase);
            lvPurchase.TheArgs.TheTemplate = "ORDERSEARCH-PURCHASE";
            lvPurchase.CurrentTemplate = n_template.GetByName(x, lvPurchase.TheArgs.TheTemplate);
            if (lvPurchase.CurrentTemplate == null)
                lvPurchase.CurrentTemplate = n_template.Create(x, lvPurchase.TheArgs.TheClass, lvPurchase.TheArgs.TheTemplate);
            lvPurchase.CurrentTemplate.GatherColumns(x);
            lvPurchase.ColSource = new ColumnSourceTemplate(lvPurchase.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvPurchase.ItemDoubleClicked += new ItemDoubleClickHandler(lvPurchase_ItemDoubleClicked);

            lvInvoice = (ListViewSpotInvoiceSearch)SpotAdd(new ListViewSpotInvoiceSearch());
            lvInvoice.SkipParentRender = true;
            lvInvoice.TheArgs = new ListArgs(x);
            lvInvoice.TheArgs.AddAllow = false;
            lvInvoice.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Invoice);
            lvInvoice.TheArgs.TheLimit = 200;
            lvInvoice.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Invoice);
            lvInvoice.TheArgs.TheTemplate = "ORDERSEARCH-INVOICE";
            lvInvoice.CurrentTemplate = n_template.GetByName(x, lvInvoice.TheArgs.TheTemplate);
            if (lvInvoice.CurrentTemplate == null)
                lvInvoice.CurrentTemplate = n_template.Create(x, lvInvoice.TheArgs.TheClass, lvInvoice.TheArgs.TheTemplate);
            lvInvoice.CurrentTemplate.GatherColumns(x);
            lvInvoice.ColSource = new ColumnSourceTemplate(lvInvoice.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvInvoice.ItemDoubleClicked += new ItemDoubleClickHandler(lvInvoice_ItemDoubleClicked);

            lvRMA = (ListViewSpotRMASearch)SpotAdd(new ListViewSpotRMASearch());
            lvRMA.SkipParentRender = true;
            lvRMA.TheArgs = new ListArgs(x);
            lvRMA.TheArgs.AddAllow = false;
            lvRMA.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.RMA);
            lvRMA.TheArgs.TheLimit = 200;
            lvRMA.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.RMA);
            lvRMA.TheArgs.TheTemplate = "ORDERSEARCH-RMA";
            lvRMA.CurrentTemplate = n_template.GetByName(x, lvRMA.TheArgs.TheTemplate);
            if (lvRMA.CurrentTemplate == null)
                lvRMA.CurrentTemplate = n_template.Create(x, lvRMA.TheArgs.TheClass, lvRMA.TheArgs.TheTemplate);
            lvRMA.CurrentTemplate.GatherColumns(x);
            lvRMA.ColSource = new ColumnSourceTemplate(lvRMA.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvRMA.ItemDoubleClicked += new ItemDoubleClickHandler(lvRMA_ItemDoubleClicked);

            lvVRMA = (ListViewSpotVRMASearch)SpotAdd(new ListViewSpotVRMASearch());
            lvVRMA.SkipParentRender = true;
            lvVRMA.TheArgs = new ListArgs(x);
            lvVRMA.TheArgs.AddAllow = false;
            lvVRMA.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.VendRMA);
            lvVRMA.TheArgs.TheLimit = 200;
            lvVRMA.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.VendRMA);
            lvVRMA.TheArgs.TheTemplate = "ORDERSEARCH-VENDRMA";
            lvVRMA.CurrentTemplate = n_template.GetByName(x, lvVRMA.TheArgs.TheTemplate);
            if (lvVRMA.CurrentTemplate == null)
                lvVRMA.CurrentTemplate = n_template.Create(x, lvVRMA.TheArgs.TheClass, lvVRMA.TheArgs.TheTemplate);
            lvVRMA.CurrentTemplate.GatherColumns(x);
            lvVRMA.ColSource = new ColumnSourceTemplate(lvVRMA.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvVRMA.ItemDoubleClicked += new ItemDoubleClickHandler(lvVRMA_ItemDoubleClicked);

            lvService = (ListViewSpotServiceSearch)SpotAdd(new ListViewSpotServiceSearch());
            lvService.SkipParentRender = true;
            lvService.TheArgs = new ListArgs(x);
            lvService.TheArgs.AddAllow = false;
            lvService.TheArgs.TheClass = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Service);
            lvService.TheArgs.TheLimit = 200;
            lvService.TheArgs.TheTable = ordhed.MakeOrdhedName(Rz5.Enums.OrderType.Service);
            lvService.TheArgs.TheTemplate = "ORDERSEARCH-SERVICE";
            lvService.CurrentTemplate = n_template.GetByName(x, lvService.TheArgs.TheTemplate);
            if (lvService.CurrentTemplate == null)
                lvService.CurrentTemplate = n_template.Create(x, lvService.TheArgs.TheClass, lvService.TheArgs.TheTemplate);
            lvService.CurrentTemplate.GatherColumns(x);
            lvService.ColSource = new ColumnSourceTemplate(lvService.CurrentTemplate);
            //we need to consider permissions here before we make this a feature of the list itself
            lvService.ItemDoubleClicked += new ItemDoubleClickHandler(lvService_ItemDoubleClicked);
        }
        private void AdjustControls()
        {
            lvSearch.ExtraStyle = "; font-size: small";
            lvBids.ExtraStyle = "; font-size: small";
            lvQuotes.ExtraStyle = "; font-size: small";
            lvSales.ExtraStyle = "; font-size: small";
            lvPurchase.ExtraStyle = "; font-size: small";
            lvInvoice.ExtraStyle = "; font-size: small";
            lvRMA.ExtraStyle = "; font-size: small";
            lvVRMA.ExtraStyle = "; font-size: small";
            lvService.ExtraStyle = "; font-size: small";
            optOrderType.CellPadding = 0;
            dtStart.CaptionFontSize = FontSize.Small;
            dtStart.TextFontSize = FontSize.Small;
            dtStart.FixedWidth = 105;
            dtEnd.CaptionFontSize = FontSize.Small;
            dtEnd.TextFontSize = FontSize.Small;
            dtEnd.FixedWidth = 105;
            txtSearch.CaptionFontSize = FontSize.Small;
            txtSearch.TextFontSize = FontSize.Small;
            txtPartNumber.CaptionFontSize = FontSize.Small;
            txtPartNumber.TextFontSize = FontSize.Small;
            txtCompanyName.CaptionFontSize = FontSize.Small;
            txtCompanyName.TextFontSize = FontSize.Small;
            txtTracking.CaptionFontSize = FontSize.Small;
            txtTracking.TextFontSize = FontSize.Small;
            xAgent.LabelFontSize = FontSize.Small;
            xAgent.TextFontSize = FontSize.Small;
        }
        private ordhed CastOrder(ContextRz x, ordhed o)
        {
            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Invoice:
                    return ordhed_invoice.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Purchase:
                    return ordhed_purchase.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Quote:
                    return ordhed_quote.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.RFQ:
                    return ordhed_rfq.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.RMA:
                    return ordhed_rma.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Sales:
                    return ordhed_sales.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.Service:
                    return ordhed_service.GetById(x, o.unique_id);
                case Rz5.Enums.OrderType.VendRMA:
                    return ordhed_vendrma.GetById(x, o.unique_id);
                default:
                    return o;
            }
        }
        private void ClearScreen(ContextRz x)
        {
            optOrderType.Value = "all";
            txtSearch.Value = "";
            txtPartNumber.Value = "";
            txtCompanyName.Value = "";
            txtTracking.Value = "";
            optStatus.Value = "all";
            chkVoid.ValueSet(false);
            dtStart.Value = Tools.Dates.GetBlankDate().ToString();
            dtEnd.Value = Tools.Dates.GetBlankDate().ToString();
            xAgent.AgentID = "";
            xAgent.AgentName = "";
            optOrderType.Change();
            txtSearch.Change();
            txtPartNumber.Change();
            txtCompanyName.Change();
            txtTracking.Change();
            optStatus.Change();
            chkVoid.Change();
            dtStart.Change();
            dtEnd.Change();
            xAgent.Change();
        }
        private ArrayList GetAgentArray(ContextRz x)
        {
            ArrayList a = new ArrayList();
            foreach (Rz5.n_user u in x.xSys.Users.All)
            {
                a.Add(u.name);
            }
            return a;
        }
        //Control Events
        private void lvSearch_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            ordhed o = CastOrder((ContextRz)x, (ordhed)item);
            x.Show(new ShowArgsOrder(x, o, o.OrderType));
        }
        private void lvBids_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.RFQ));
        }
        private void lvQuotes_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Quote));
        }
        private void lvSales_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Sales));
        }
        private void lvPurchase_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Purchase));
        }
        private void lvInvoice_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Invoice));
        }
        private void lvRMA_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.RMA));
        }
        private void lvVRMA_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.VendRMA));
        }
        private void lvService_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Service));
        }
    }
    public class ListViewSpotOrderSearch : ListViewSpotRz
    {
        public ListViewSpotOrderSearch()
            : base("ordhed")
        {
        }
    }
    public class ListViewSpotBidsSearch : ListViewSpotRz
    {
        public ListViewSpotBidsSearch()
            : base("ordhed_rfq")
        {
        }
    }
    public class ListViewSpotQuoteSearch : ListViewSpotRz
    {
        public ListViewSpotQuoteSearch()
            : base("ordhed_quote")
        {
        }
    }
    public class ListViewSpotSalesSearch : ListViewSpotRz
    {
        public ListViewSpotSalesSearch()
            : base("ordhed_sales")
        {
        }
    }
    public class ListViewSpotPurchaseSearch : ListViewSpotRz
    {
        public ListViewSpotPurchaseSearch()
            : base("ordhed_purchase")
        {
        }
    }
    public class ListViewSpotInvoiceSearch : ListViewSpotRz
    {
        public ListViewSpotInvoiceSearch()
            : base("ordhed_invoice")
        {
        }
    }
    public class ListViewSpotRMASearch : ListViewSpotRz
    {
        public ListViewSpotRMASearch()
            : base("ordhed_rma")
        {
        }
    }
    public class ListViewSpotVRMASearch : ListViewSpotRz
    {
        public ListViewSpotVRMASearch()
            : base("ordhed_vendrma")
        {
        }
    }
    public class ListViewSpotServiceSearch : ListViewSpotRz
    {
        public ListViewSpotServiceSearch()
            : base("ordhed_service")
        {
        }
    }
}