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

namespace RzWeb
{
    public class PartSearch : RzScreen
    {
        public Stack RecentSearches = new Stack();
        public bool SearchesLoaded = false;
        private bool DoRecent = false;
        private ListArgs TheArgs;
        private ContextRz TheContext;
        RadioButtonControl optSearchBy;
        TextControl txtSearch;
        RadioButtonControl optSearchType;
        BoolControl chkStock;
        BoolControl chkExcess;
        BoolControl chkConsign;
        AnchorControl aRecentSearches;
        AnchorControl cmdSearch;
        AnchorControl cmdQuote;
        AnchorControl cmdBid;
        RadioButtonControl optSearchRecord;
        ListViewPartSearch lv;
        CompanyContactControl xCompany;
        Rz5.Enums.OrderType LastOrderType = Rz5.Enums.OrderType.Any;

        public PartSearch(ContextRz x)
            : base(x)
        {
            TheContext = (ContextRz)x;
            lv = (ListViewPartSearch)SpotAdd(new ListViewPartSearch());
            TheArgs = x.Sys.ThePartLogic.PartSearchArgsGet(TheContext, new PartSearchParameters(""));
            lv.TheArgs = TheArgs;
            lv.TheArgs.HeaderOnly = true;
            lv.TheArgs.AddAllow = false;
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.ItemDoubleClicked += new ItemDoubleClickHandler(lv_ItemDoubleClicked);
            lv.MenuActionClicked += new MenuActionHandler(lv_MenuActionClicked);
            optSearchBy = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("searchby", "", "part", Tools.Strings.Split("Part #          :part|MFG     :mfg|Description:box", "|"))));
            txtSearch = (TextControl)SpotAdd(ControlAdd(new TextControl("txtSearch", "", "")));
            optSearchType = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("searchtype", "", "standard", Tools.Strings.Split("Standard    :standard|Fuzzy    :fuzzy|Exact:exact", "|"))));
            chkStock = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkStock", "Stock", true)));
            chkExcess = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkExcess", "Excess", true)));
            chkConsign = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkConsign", "Consign", true)));
            aRecentSearches = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("RecentSearches", "recent searches", ActionScript("'recentsearches'", "'na'"))));
            cmdSearch = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdSearch", "Search", "Spin('" + Spot.DivIdConvert(lv.Uid) + "'); PartSearch('');", "Search.png")));
            cmdQuote = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdQuote", "Quote", ActionScript("'new_quote'", "$('#" + txtSearch.ControlId + "').val() + '|~|' +" + lv.SelectedRowIdsScript), "Quote.png")));
            cmdBid = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdBid", "Bid", ActionScript("'new_bid'", "$('#" + txtSearch.ControlId + "').val() + '|~|' +" + lv.SelectedRowIdsScript), "Bid.png")));
            optSearchRecord = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("searchrecord", "", "all", GetSearchOptions())));
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("xCompany", "Company", "", "", "", "", "", "", "", "")));
            AdjustControls();
            txtSearch.OnEnterClick = cmdSearch.ControlId;
            if (!((LeaderWebUserRz)x.TheLeaderRz).DemoInfoCleared(x))
                RunSearch(x);
        }
        private void RunSearch(ContextRz x)
        {
            txtSearch.Value = "EX";
            txtSearch.Change();
            PartSearchParameters p = new PartSearchParameters("EX");            
            p.IncludeAllocated = true;
            p.IncludeAlternatePart = true;
            p.IncludeUserDefined = true;
            p.UnlimitedResults = false;
            p.TheTarget = PartSearchTarget.Part;
            p.IncludeStock = true;
            p.IncludeExcess = true;
            p.IncludeConsign = true;
            p.TheComparison = SearchComparison.Normal;
            TheArgs = x.Sys.ThePartLogic.PartSearchArgsGet((ContextRz)x, p);
            lv.TheArgs = TheArgs;
            if (lv.TheArgs == null)
                return;
            UpdateRecentSearches(x, p.SearchTerm);
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
            lv.AlternateTable = "";
            lv.ClassId = TheArgs.TheClass;
            lv.Change();
        }
        public override String Title(Context x)
        {
            return "Part Search";
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"part_search_top_" + Uid + "\" style=\"position: absolute; top: 0px; margin-top: 8px; padding: 4px\">");
            optSearchBy.Render(x, sb, screenHandle, viewHandle, session, page);
            aRecentSearches.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdQuote.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdBid.Render(x, sb, screenHandle, viewHandle, session, page);
            optSearchType.Render(x, sb, screenHandle, viewHandle, session, page);
            chkStock.Render(x, sb, screenHandle, viewHandle, session, page);
            chkExcess.Render(x, sb, screenHandle, viewHandle, session, page);
            chkConsign.Render(x, sb, screenHandle, viewHandle, session, page);
            optSearchRecord.Render(x, sb, screenHandle, viewHandle, session, page);
            xCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            if (DoRecent && RecentSearches != null)
            {
                DoRecent = false;
                sb.AppendLine("	<div id=\"recent_searches\" style=\"position: absolute; z-index: 1000; top: -15px; left: 317px; height: 140px; width: 250px; background-color: #FFFFFF; bottom: 68px; overflow: scroll; font-family: Calibri; font-size: medium;\">");
                sb.AppendLine("        <table border=\"1\" width=\"100%\">");
                if (RecentSearches.Count <= 0)
                {
                    sb.AppendLine("          <tr>");
                    sb.AppendLine("            <td width=\"100%\">No Recent Searches</td>");
                    sb.AppendLine("          </tr>");
                }
                else
                {
                    foreach (String s in RecentSearches)
                    {
                        string part = Tools.Strings.ParseDelimit(s, "<", 1).Trim();
                        sb.AppendLine("          <tr>");
                        sb.AppendLine("            <td width=\"100%\"><a href=\"#\" id=\"recent_click\" onclick=\"$('#recent_searches').hide(); Spin('" + Spot.DivIdConvert(lv.Uid) + "'); SetSearchTxt('" + part + "'); PartSearch();\">" + s + "</a></td>");
                        sb.AppendLine("          </tr>");
                    }
                }
                sb.AppendLine("        </table>");
                sb.AppendLine("    </div>");
                viewHandle.ScriptsToRun.Add("var spot = $(this).offset();$('#recent_searches_link').show().offset(spot);");
                viewHandle.ScriptsToRun.Add("$(\"#recent_searches\").bind(\"mouseleave\", function (event) { $('#recent_searches').hide(); });");
                //viewHandle.Flow();
            }
            sb.AppendLine("</div>");
            viewHandle.ScriptsToRun.Add(optSearchRecord.Select + ".buttonset();");
            viewHandle.ScriptsToRun.Add("$('#" + txtSearch.ControlId + "').focus();");
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "part_search_top_" + Uid);
            RunDivToRight(sb, "part_search_top_" + Uid);
            sb.AppendLine(txtSearch.PlaceBelow(optSearchBy));
            sb.AppendLine(optSearchType.PlaceBelow(txtSearch));
            sb.AppendLine(chkStock.PlaceBelow(optSearchType));
            sb.AppendLine(chkExcess.PlaceBelow(optSearchType));
            sb.AppendLine(chkConsign.PlaceBelow(optSearchType));
            sb.AppendLine(chkExcess.PlaceRight(chkStock, false, 34, 0));
            sb.AppendLine(chkConsign.PlaceRight(chkExcess, false, 5, 0));
            sb.AppendLine(aRecentSearches.PlaceRight(txtSearch));
            sb.AppendLine(cmdSearch.PlaceBelow(aRecentSearches));
            sb.AppendLine(cmdQuote.PlaceBelow(aRecentSearches));
            sb.AppendLine(cmdBid.PlaceBelow(aRecentSearches));
            sb.AppendLine(cmdSearch.PlaceRight(txtSearch));
            sb.AppendLine(cmdQuote.PlaceRight(cmdSearch));
            sb.AppendLine(cmdBid.PlaceRight(cmdQuote));
            sb.AppendLine(optSearchRecord.PlaceBelow(chkStock));
            sb.AppendLine("try{$('#recent_searches').css('top', " + aRecentSearches.Select + ".position().top);}catch(evnt){}");
            sb.AppendLine("try{$('#recent_searches').css('left', " + aRecentSearches.Select + ".position().left);}catch(evnt){}");
            sb.AppendLine("try{" + xCompany.Select + ".css('top', " + aRecentSearches.Select + ".position().top);}catch(evnt){}");
            sb.AppendLine("try{" + xCompany.Select + ".css('left', " + cmdBid.Select + ".width() + " + cmdBid.Select + ".position().left + 10);}catch(evnt){}");
            sb.AppendLine("try{$('#" + xCompany.ControlId + "').css('width', 400);}catch(evnt){}");
            sb.AppendLine("$('#part_search_top_" + Uid + "').css('height', " + optSearchRecord.Select + ".position().top + " + optSearchRecord.Select + ".height() );");
            sb.AppendLine("PlaceDivBelow('" + lv.DivId + "', 'part_search_top_" + Uid + "');");
            lv.RunToRight(sb);
            lv.RunToBottom(sb);
        }
        private void AdjustControls()
        {
            optSearchBy.AddPadding(GenAlign.Left, 5);
            txtSearch.AddPadding(GenAlign.Left, 10);
            txtSearch.FixedWidth = 308;
            optSearchType.AddPadding(GenAlign.Left, 5);
            optSearchType.AddPaddingControl(GenAlign.Right, 10);
            chkStock.AddPaddingControl(GenAlign.Left, 7);
            aRecentSearches.AddPaddingControl(GenAlign.Left, 10);
            cmdSearch.AddPaddingControl(GenAlign.Left, 10);
            optSearchRecord.AddPaddingControl(GenAlign.Left, 8);
            lv.AddPadding(GenAlign.Left, 10);
            lv.ExtraStyle = "; font-size: small";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId)
            {
                case "new_quote":
                    NewQuote((ContextRz)x, args.ActionParams);
                    break;
                case "new_bid":
                    NewBid((ContextRz)x, args.ActionParams);
                    break;
                case "search":
                    Search((ContextRz)x, args.ActionParams, args.SourceView);
                    break;
                case "recentsearches":
                    ShowRecentSearches((ContextRz)x);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        public override string ScriptToolsRender(System.Web.UI.Page page, ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ScriptToolsRender(page, viewHandle));
            sb.AppendLine("");
            sb.AppendLine("function SetSearchTxt(term) {");
            sb.AppendLine("     $('#" + txtSearch.ControlId + "').val(term);");
            sb.AppendLine("}");
            sb.AppendLine("");
            sb.AppendLine("function PartSearch(term) {");
            sb.AppendLine("var data = \"\";");
            //add each of the control values
            foreach (Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'search'", "data"));
            sb.AppendLine("}");
            return sb.ToString();
        }
        private void ShowRecentSearches(ContextRz x)
        {
            DoRecent = true;
            if (RecentSearches == null || !SearchesLoaded)
                RecentSearches = ((ContextRz)x).TheSysRz.ThePartLogic.GetRecentSearchStack((ContextRz)x);
            Change();
        }
        private void Search(ContextRz x, string term, ViewHandle viewHandle)
        {
            Dictionary<string, string> d = ParseValueString(term);
            PartSearchParameters p = ParsePartSearchParameters(d);
            TheArgs = GetSearchArgs(x, p, d);
            lv.TheArgs = TheArgs;
            if (lv.TheArgs == null)
                return;
            UpdateRecentSearches(x, p.SearchTerm);
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
            lv.AlternateTable = "";
            lv.ClassId = TheArgs.TheClass;
            if (p.ShippedStock)
                lv.AlternateTable = "shipped_stock";
            lv.Change();
        }
        private void NewQuote(ContextRz x, string ids)
        {
            string comp_id = xCompany.CompanyID;
            string cont_id = xCompany.ContactID;
            string partnum = Tools.Strings.ParseDelimit(ids, "|~|", 1).Trim();
            ids = Tools.Strings.ParseDelimit(ids, "|~|", 2).Trim();
            string[] str = Tools.Strings.Split(ids, "|");
            company c = null;
            companycontact cc = null;
            if (Tools.Strings.StrExt(comp_id))
                c = company.GetById(x, comp_id);
            if (c == null)
            {
                c = ((LeaderWebUserRz)x.TheLeader).AskForCompany((Rz5.ContextRz)x, "Please choose a company below:", "");
                if (c != null)
                    cc = ((LeaderWebUserRz)x.TheLeader).AskForContact((Rz5.ContextRz)x, "Please choose a contact below:", "", c.unique_id);
            }
            if (c == null)
                return;
            if (Tools.Strings.StrExt(cont_id) && cc == null)
                cc = companycontact.GetById(x, cont_id);
            string id = Tools.Strings.ParseDelimit(str[0], "_dot_", 2).Trim();
            partrecord p = null;
            if (Tools.Strings.StrExt(id))
                p = partrecord.GetById(x, id);
            if (p == null)
            { 
                p = new partrecord();
                p.fullpartnumber = partnum;
            }
            dealheader.MakeManualDealAndItemAndShow(x, c, cc, Rz5.Enums.OrderType.Quote, p);
        }
        private void NewBid(ContextRz x, string ids)
        {
            string comp_id = xCompany.CompanyID;
            string cont_id = xCompany.ContactID;
            string partnum = Tools.Strings.ParseDelimit(ids, "|~|", 1).Trim();
            ids = Tools.Strings.ParseDelimit(ids, "|~|", 2).Trim();
            string[] str = Tools.Strings.Split(ids, "|");
            company c = null;
            companycontact cc = null;
            if (Tools.Strings.StrExt(comp_id))
                c = company.GetById(x, comp_id);
            if (c == null)
            {
                c = ((LeaderWebUserRz)x.TheLeader).AskForCompany((Rz5.ContextRz)x, "Please choose a company below:", "");
                if (c != null)
                    cc = ((LeaderWebUserRz)x.TheLeader).AskForContact((Rz5.ContextRz)x, "Please choose a contact below:", "", c.unique_id);
            }
            if (c == null)
                return;
            if (Tools.Strings.StrExt(cont_id) && cc == null)
                cc = companycontact.GetById(x, cont_id);
            string id = Tools.Strings.ParseDelimit(str[0], "_dot_", 2).Trim();
            partrecord p = null;
            if (Tools.Strings.StrExt(id))
                p = partrecord.GetById(x, id);
            if (p == null)
            {
                p = new partrecord();
                p.fullpartnumber = partnum;
            }
            ordhed_rfq r = null;
            if (cc != null)
                r = (ordhed_rfq)cc.AddOrder(x, Rz5.Enums.OrderType.RFQ);
            else
                r = (ordhed_rfq)c.AddOrder(x, Rz5.Enums.OrderType.RFQ);
            orddet d = r.AddLineItem(x, p.fullpartnumber, 0, 0);
            d.manufacturer = p.manufacturer;
            d.datecode = p.datecode;
            d.condition = p.condition;
            d.packaging = p.packaging;
            d.Update(x);
            x.Show(new ShowArgsOrder(x, d, Rz5.Enums.OrderType.RFQ));
        }
        private void UpdateRecentSearches(ContextRz x, string part)
        {
            if (part.Length > 150)
                return;
            if (RecentSearches == null)
                return;
            if (RecentSearches.Count > 0)
            {
                string last = (String)RecentSearches.Peek();
                last = Tools.Strings.ParseDelimit(last, "<>", 1).Trim();
                if (Tools.Strings.StrCmp(part, last))
                    return;
            }
            string strDate = DateTime.Now.ToString();
            x.Execute("insert into partsearch(base_mc_user_uid, fullpartnumber, searchdate) values ('" + x.xUser.unique_id + "', '" + x.Filter(part) + "', '" + strDate + "')");
            RecentSearches.Push(part.ToUpper() + " <> " + strDate);
        }
        private RadioControlConfig GetSearchOptions()
        {
            RadioControlConfig c = new RadioControlConfig();
            RadioControlConfig o = new RadioControlConfig();
            o.Caption = "Parts";
            o.Value = "parts";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Quotes";
            o.Value = "quotes";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Bids";
            o.Value = "bids";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Sales";
            o.Value = "sales";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Purchases";
            o.Value = "purchases";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "RMAs";
            o.Value = "rmas";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "VRMAs";
            o.Value = "vrmas";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Pictures";
            o.Value = "pictures";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Shipped";
            o.Value = "shipped";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            o = new RadioControlConfig();
            o.Caption = "Master";
            o.Value = "master";
            o.OnClick = "Spin('" + Spot.DivIdConvert(lv.Uid) + "');PartSearch($('#" + txtSearch.ControlId + "').val());";
            c.AllOptions.Add(o);

            return c;
        }
        private PartSearchParameters ParsePartSearchParameters(Dictionary<string, string> param)
        {
            string term = "";
            string hold = "";
            param.TryGetValue("txtSearch", out term);
            PartSearchParameters p = new PartSearchParameters(term);
            p.SearchTerm = term;
            p.IncludeAllocated = true;
            p.IncludeAlternatePart = true;
            p.IncludeUserDefined = true;
            p.UnlimitedResults = false;
            param.TryGetValue("searchby", out hold);
            p.TheTarget = PartSearchTarget.Part;
            if (Tools.Strings.StrCmp(hold, "mfg"))
                p.TheTarget = PartSearchTarget.Manufacturer;
            if (Tools.Strings.StrCmp(hold, "box"))
                p.TheTarget = PartSearchTarget.Description;
            param.TryGetValue("chkStock", out hold);
            if (!Tools.Strings.StrCmp(hold, "undefined"))
                p.IncludeStock = true;
            else
                p.IncludeStock = false;
            param.TryGetValue("chkExcess", out hold);
            if (!Tools.Strings.StrCmp(hold, "undefined"))
                p.IncludeExcess = true;
            else
                p.IncludeExcess = false;
            param.TryGetValue("chkConsign", out hold);
            if (!Tools.Strings.StrCmp(hold, "undefined"))
                p.IncludeConsign = true;
            else
                p.IncludeConsign = false;
            param.TryGetValue("searchtype", out hold);
            p.TheComparison = SearchComparison.Normal;
            if (Tools.Strings.StrCmp(hold, "fuzzy"))
                p.TheComparison = SearchComparison.Fuzzy;
            if (Tools.Strings.StrCmp(hold, "exact"))
                p.TheComparison = SearchComparison.Exact;
            return p;
        }
        private ListArgs GetSearchArgs(ContextRz x, PartSearchParameters p, Dictionary<string, string> param)
        {
            ContextRz xrz = (ContextRz)x;

            string hold = "";
            string type = "parts";
            param.TryGetValue("searchrecord", out hold);
            if (Tools.Strings.StrCmp(hold, "quotes"))
                type = "quotes"; 
            if (Tools.Strings.StrCmp(hold, "bids"))
                type = "bids";
            if (Tools.Strings.StrCmp(hold, "sales"))
                type = "sales";
            if (Tools.Strings.StrCmp(hold, "purchases"))
                type = "purchases";
            if (Tools.Strings.StrCmp(hold, "pictures"))
                type = "pictures";
            if (Tools.Strings.StrCmp(hold, "rmas"))
                type = "rmas";
            if (Tools.Strings.StrCmp(hold, "shipped"))
                type = "shipped";
            if (Tools.Strings.StrCmp(hold, "vrmas"))
                type = "vrmas";
            if (Tools.Strings.StrCmp(hold, "master"))
                type = "master";
            LastOrderType = Rz5.Enums.OrderType.Any;
            if (x.xUserRz.GetSetting_Boolean(x, "restricted_user"))
                p.AgentID = x.xUserRz.unique_id;
            ListArgs a = new ListArgs(x);
            switch (type)
            {
                case "quotes":
                    return x.Sys.TheQuoteLogic.QuoteSearchArgsGet(xrz, Rz5.Enums.PartSearchType.Quotes_Giving, p.TheComparison, p, true);
                case "bids":
                    return x.Sys.TheQuoteLogic.QuoteSearchArgsGet(xrz, Rz5.Enums.PartSearchType.Quotes_Receiving, p.TheComparison, p, true);
                case "sales":
                    LastOrderType = Rz5.Enums.OrderType.Sales;                  
                    return x.TheLogicRz.SalesSearchArgsGet(xrz, p.TheComparison, p);
                case "purchases":
                    LastOrderType = Rz5.Enums.OrderType.Purchase;
                    return x.TheLogicRz.PurchaseSearchArgsGet(xrz, p.TheComparison, p);
                case "pictures":
                    return x.TheLogicRz.AttachmentSearchArgsGet(x, p.TheComparison, p.SearchTerm);
                case "rmas":
                    LastOrderType = Rz5.Enums.OrderType.RMA;
                    return x.TheLogicRz.RMASearchArgsGet(xrz, Rz5.Enums.PartSearchType.RMA, p.TheComparison, p);
                case "vrmas":
                    LastOrderType = Rz5.Enums.OrderType.VendRMA;
                    return x.TheLogicRz.RMASearchArgsGet(xrz, Rz5.Enums.PartSearchType.VendRMA, p.TheComparison, p);
                case "shipped":
                    p.ShippedStock = true;
                    return x.TheSysRz.ThePartLogic.ShippedSearchArgsGet(xrz, p);
                case "master":
                    return x.TheSysRz.ThePartLogic.MasterSearchArgsGet(xrz, p);
                default:
                    return x.Sys.ThePartLogic.PartSearchArgsGet(xrz, p);
            }
        }
        private orddet GetOrddetConversion(ContextRz x, IItem item)
        {
            string type = x.SelectScalarString("select ordertype from orddet where unique_id = '" + item.Uid + "'");
            if (!Tools.Strings.StrExt(type))
                return null;
            switch (type.ToLower().Trim())
            {
                case "quote":
                    return orddet_quote.GetById(x, item.Uid);
                case "rfq":
                    return orddet_rfq.GetById(x, item.Uid);
                default:
                    return null;
            }
        }
        private ShowArgsOrder GetOrddetLineArgs(ContextRz x, IItem item)
        {
            Rz5.Enums.OrderType t = LastOrderType;
            orddet_line l = (orddet_line)item;
            if (LastOrderType == Rz5.Enums.OrderType.Sales)
            {
                if (Tools.Strings.StrExt(l.orderid_invoice))
                    t = Rz5.Enums.OrderType.Invoice;
            }
            return new ShowArgsOrder(x, item, t);
        }
        private void ShowPartPicture(ContextRz x, partpicture p, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (p == null) 
                return;
            string filename = Tools.Strings.GetNewID() + "." + p.filetype.Replace(".", "").Trim();
            string path = Tools.Folder.ConditionFolderName(page.Server.MapPath("~/Graphics")) + "Attachment_Temp\\";
            if (!Tools.Folder.FolderExists(path))
                Tools.Folder.MakeFolderExist(path);
            string file = path + filename;
            p.LoadPictureData(x);
            p.SaveDataAsFile(x, file);
            viewHandle.FilesToDownload.Add(file);
        }
        private void lv_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            ShowArgs args = null;
            if (item is orddet_line)            
                args = GetOrddetLineArgs((ContextRz)x, item);
            else if (item is orddet)
                item = GetOrddetConversion((ContextRz)x, item);
            if (item == null)
                return;
            if (item is partpicture)
            {
                ShowPartPicture((ContextRz)x, (partpicture)item, page, viewHandle);
                return;
            }
            if (args == null)
                args = new ShowArgs(x, item);
            x.Show(args);
        }
        private void lv_MenuActionClicked(Context x, ActArgs args, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            switch (args.ActionName.ToLower())
            {
                case "open":
                    switch (lv.TheArgs.TheTemplate.ToLower())
                    {
                        case "partpictures_partsearchscreen":
                            ShowPartPicture((ContextRz)x, (partpicture)args.TheItems.FirstGet(x), page, viewHandle);
                            args.Handled = true;
                            break;
                        case "simple_quotes":
                            switch (lv.ClassId.ToLower().Trim())
                            {
                                case "orddet_quote":
                                    x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Quote));
                                    break;
                                case "orddet_rfq":
                                    x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.RFQ));
                                    break;
                            }
                            args.Handled = true;
                            break;
                        case "salessearchnew":
                            x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Sales));
                            args.Handled = true;
                            break;
                        case "buysearchnew":
                            x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Purchase));
                            args.Handled = true;
                            break;
                        case "rmasearchnew":
                            x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.RMA));
                            args.Handled = true;
                            break;
                        case "vendrmasearchnew":
                            x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.VendRMA));
                            args.Handled = true;
                            break;
                    }
                    break;
            }
        }
    }
    public class ListViewPartSearch : ListViewSpotRz
    {
        public ListViewPartSearch()
            : base("")
        {
        }
    }
}