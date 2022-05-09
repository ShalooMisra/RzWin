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
    public class OrderBatch : RzScreen
    {
        dealheader TheDeal;
        orddet_quote TheReq;
        orddet_quote TheQuote;
        orddet_rfq TheBid;
        ListViewSpotReqs lvReqs;
        ListViewSpotQuotes lvQuotes;
        ListViewSpotBids lvBids;
        CompanyContactControl xCompany;
        TextControl txtBatchName;
        AgentControl xAgent;
        ViewHandle TheView;

        public OrderBatch(ContextRz x, dealheader d)
            : base(x)
        {
            TheDeal = d;
            InitListViews(x);            
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("customer_uid|customer_name|contact_uid|contact_name", "Customer", TheDeal.customer_uid, TheDeal.customer_name, "customer_uid", "customer_name", TheDeal.contact_uid, TheDeal.contact_name, "contact_uid", "contact_name")));
            xCompany.CompanyOnly = true;
            xCompany.AskForContact = true;
            xCompany.CompanyChanged += new CompanyChangedHandler(xCompany_CompanyChanged);
            xCompany.ContactChanged += new ContactChangedHandler(xCompany_ContactChanged);
            txtBatchName = (TextControl)SpotAdd(ControlAdd(new TextControl("dealheader_name", "Batch Name", TheDeal.dealheader_name)));
            xAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("base_mc_user_uid|agentname", "Agent", TheDeal.base_mc_user_uid, TheDeal.agentname, "base_mc_user_uid", "agentname", GetAgentArray(x))));
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "Order Batch";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {
                case "save":
                    SaveOrderBatch((ContextRz)x, args.ActionParams);
                    break;
                case "new_req":
                    NewReq((ContextRz)x);
                    break;
                case "import_reqs":
                    ImportReqs((ContextRz)x);
                    break;
                case "import_bids":
                    ImportBids((ContextRz)x);
                    break;
                case "new_quote":
                    NewFormalQuote((ContextRz)x);
                    break;
                case "new_so":
                    NewSalesOrder((ContextRz)x);
                    break;
                case "new_bid":
                    NewBid((ContextRz)x);
                    break;
                case "accept_bid":
                    AcceptBid((ContextRz)x);
                    break;
                default:
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"orderbatch_header_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 230px; height: 45px;\">");
            xCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBatchName.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"save_button" + Uid + "\" style=\"position: absolute; padding: 6px; left: 690px;\">");
            sb.AppendLine("<a href=\"#\" onclick=\"SaveBatch()\"><img style=\"padding: 4px;\" alt=\"save\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/task_save.jpg") + "\"/></a>");
            sb.AppendLine("</div>");
            xAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"lvreqs_quotes_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 100px;\">");
            lvReqs.Render(x, sb, screenHandle, viewHandle, session, page);
            lvQuotes.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"reqquote_options_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 2px; height: 100px;  width: 63px;\">");
            sb.AppendLine("<input id=\"cmdNewReq\" type=\"button\" style=\"font-size: xx-small;\" value=\"New Req\" onclick=\"" + ActionScript("'new_req'") + "\"><br>");
            sb.AppendLine("<input id=\"cmdImportReq\" type=\"button\" style=\"font-size: xx-small; width: 62px; height: 45px; margin-top: 4px;\" value=\"  Import   \" onclick=\"" + ActionScript("'import_reqs'") + "\"><br>");
            sb.AppendLine("<input id=\"cmdQuote\" type=\"button\" style=\"font-size: xx-small;\" value=\"  Quote    \" onclick=\"" + ActionScript("'new_quote'") + "\"><br>");
            sb.AppendLine("<input id=\"cmdSales\" type=\"button\" style=\"font-size: xx-small;\" value=\"   Sales    \" onclick=\"" + ActionScript("'new_so'") + "\">");
            Buttonize(viewHandle, "cmdNewReq", "SignUp.png");
            Buttonize(viewHandle, "cmdImportReq", "csv.png", 25);
            Buttonize(viewHandle, "cmdQuote", "Quote.png");
            Buttonize(viewHandle, "cmdSales", "ordersmenu.png");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"lvbids_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 300px;\">");
            lvBids.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"bid_options_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 2px; height: 100px;  width: 63px;\">");
            sb.AppendLine("<input id=\"cmdNewBid\" type=\"button\" style=\"font-size: xx-small;\" value=\"New Bid \" onclick=\"" + ActionScript("'new_bid'") + "\"><br>");
            sb.AppendLine("<input id=\"cmdImportBid\" type=\"button\" style=\"font-size: xx-small; width: 62px; height: 45px; margin-top: 4px;\" value=\"Import\" onclick=\"" + ActionScript("'import_bids'") + "\"><br>");
            sb.AppendLine("<input id=\"cmdAcceptBid\" type=\"button\" style=\"font-size: xx-small; width: 62px; height: 45px; margin-top: 4px;\" value=\"  Accept  \" title=\"Click To Accept Selected Bid\" onclick=\"" + ActionScript("'accept_bid'") + "\">");
            Buttonize(viewHandle, "cmdNewBid", "Bid.png");
            Buttonize(viewHandle, "cmdImportBid", "csv.png", 25);
            Buttonize(viewHandle, "cmdAcceptBid", "check.png", 25);
            sb.AppendLine("</div>");            
            sb.AppendLine("</div>");
            AddScripts((ContextRz)x, viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "orderbatch_header_" + Uid);
            RunDivToRight(sb, "orderbatch_header_" + Uid);            
            sb.AppendLine("$('#lvreqs_quotes_" + Uid + "').css('top', $('#orderbatch_header_" + Uid + "').position().top + $('#orderbatch_header_" + Uid + "').height() + 15);");
            sb.AppendLine("$('#lvreqs_quotes_" + Uid + "').css('width', $('#orderbatch_header_" + Uid + "').width());");
            sb.AppendLine("$('#lvbids_" + Uid + "').css('top', $(window).height() - $('#lvbids_" + Uid + "').height() - 21);");
            sb.AppendLine("$('#lvreqs_quotes_" + Uid + "').css('height', $('#lvbids_" + Uid + "').position().top - $('#lvreqs_quotes_" + Uid + "').position().top - 15);");
            sb.AppendLine("$('#lvbids_" + Uid + "').css('width', $('#orderbatch_header_" + Uid + "').width());");
            sb.AppendLine(xCompany.Select + ".css('left', 10);");
            sb.AppendLine(txtBatchName.Select + ".css('top', 10);");
            sb.AppendLine(txtBatchName.Select + ".css('left', 250);");
            sb.AppendLine("$('#reqquote_options_" + Uid + "').css('top', -3);");
            sb.AppendLine("$('#reqquote_options_" + Uid + "').css('height', $('#lvreqs_quotes_" + Uid + "').height() + 4);");
            sb.AppendLine("$('#reqquote_options_" + Uid + "').css('left',  $('#lvreqs_quotes_" + Uid + "').width() - $('#reqquote_options_" + Uid + "').width() - 4);");
            sb.AppendLine(lvReqs.Select + ".css('top', 2);");
            sb.AppendLine(lvReqs.Select + ".css('left', 2);");
            sb.AppendLine(lvReqs.Select + ".css('height', ($('#lvreqs_quotes_" + Uid + "').height() / 2) - 4);");
            sb.AppendLine(lvReqs.Select + ".css('width', $('#reqquote_options_" + Uid + "').position().left - " + lvReqs.Select + ".position().left);");
            sb.AppendLine(lvQuotes.Select + ".css('top', " + lvReqs.Select + ".position().top + " + lvReqs.Select + ".height() + 5);");
            sb.AppendLine(lvQuotes.Select + ".css('left', 2);");
            sb.AppendLine(lvQuotes.Select + ".css('height', $('#lvreqs_quotes_" + Uid + "').height() - " + lvReqs.Select + ".position().top - 5);");
            sb.AppendLine(lvQuotes.Select + ".css('width', " + lvReqs.Select + ".width());");
            sb.AppendLine("$('#bid_options_" + Uid + "').css('top', -3);");
            sb.AppendLine("$('#bid_options_" + Uid + "').css('height', $('#lvbids_" + Uid + "').height() + 4);");
            sb.AppendLine("$('#bid_options_" + Uid + "').css('left',  $('#lvbids_" + Uid + "').width() - $('#bid_options_" + Uid + "').width() - 4);");
            sb.AppendLine(lvBids.Select + ".css('top', 2);");
            sb.AppendLine(lvBids.Select + ".css('left', 2);");
            sb.AppendLine(lvBids.Select + ".css('height', $('#lvbids_" + Uid + "').height() - 4);");
            sb.AppendLine(lvBids.Select + ".css('width', $('#bid_options_" + Uid + "').position().left - " + lvBids.Select + ".position().left);");
            sb.AppendLine(xAgent.Select + ".css('top', 2);");
            sb.AppendLine(xAgent.Select + ".css('left', 465);");
        }
        private void AddScripts(ContextRz x, ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function SaveBatch() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#cmdQuote').hide();");
            viewHandle.ScriptsToRun.Add("$('#cmdSales').hide();");
            if (TheReq == null && TheQuote == null)
            {
                viewHandle.ScriptsToRun.Add("$('#cmdNewBid').hide();");
                viewHandle.ScriptsToRun.Add("$('#" + lvBids.DivId + "').hide();");
            }
            viewHandle.ScriptsToRun.Add("$('#cmdAcceptBid').hide();");
            if (lvQuotes.TheArgs.LiveItems.CountGet(x) <= 0)
                viewHandle.ScriptsToRun.Add("$('#" + lvQuotes.DivId + "').hide();");      
        }
        private void AdjustControls()
        {
            txtBatchName.FixedWidth = 200;
            xAgent.LabelFontSize = FontSize.Small;
            lvReqs.ExtraStyle = "; font-size: small";
            lvQuotes.ExtraStyle = "; font-size: small";
            lvBids.ExtraStyle = "; font-size: small";
        }
        private void InitListViews(ContextRz x)
        {
            ItemsInstance reqs = new ItemsInstance();
            ItemsInstance quotes = new ItemsInstance();
            if (TheDeal.CustomerHalf == null)
                TheDeal.Init(x);
            foreach (KeyValuePair<String, Item> k in TheDeal.CustomerHalf.Details)
            {
                orddet_quote q = (orddet_quote)k.Value;
                if (q.IsQuoted)
                    quotes.Add(x, q);
                else
                    reqs.Add(x, q);
            }
            orddet_quote first = null;
            if (reqs.Count > 0)
            {
                first = (orddet_quote)reqs.First;
                TheReq = first;
                TheQuote = null;
                TheBid = null;
            }
            if (first == null && quotes.Count > 0)
            {
                first = (orddet_quote)quotes.First;
                TheReq = null;
                TheQuote = first;
                TheBid = null;
            }
            //lvReqs
            lvReqs = (ListViewSpotReqs)SpotAdd(new ListViewSpotReqs());
            lvReqs.SkipParentRender = true;
            lvReqs.TheArgs = new ListArgs(x);
            lvReqs.TheArgs.AddAllow = false;
            lvReqs.TheArgs.ExportAllow = false;
            lvReqs.TheArgs.OptionsAllow = false;
            lvReqs.TheArgs.TheCaption = "Requirements";
            lvReqs.TheArgs.TheClass = "orddet_quote";
            lvReqs.TheArgs.TheLimit = -1;
            lvReqs.TheArgs.TheOrder = "linecode";
            lvReqs.TheArgs.TheTable = "orddet_quote";
            lvReqs.TheArgs.TheTemplate = "orderbatch_req_listview";
            lvReqs.TheArgs.LiveItems = reqs;
            lvReqs.CurrentTemplate = n_template.GetByName(x, lvReqs.TheArgs.TheTemplate);
            if (lvReqs.CurrentTemplate == null)
                lvReqs.CurrentTemplate = n_template.Create(x, lvReqs.TheArgs.TheClass, lvReqs.TheArgs.TheTemplate);
            lvReqs.CurrentTemplate.GatherColumns(x);
            lvReqs.ColSource = new ColumnSourceTemplate(lvReqs.CurrentTemplate);
            lvReqs.RowSource = new RowSourceItem(lvReqs.TheArgs.LiveItems.AllGet(x));
            lvReqs.ItemDoubleClicked += new ItemDoubleClickHandler(lvReqs_ItemDoubleClicked);
            lvReqs.ItemSingleClicked += new ItemSingleClickHandler(lvReqs_ItemSingleClicked);
            //lvQuotes
            lvQuotes = (ListViewSpotQuotes)SpotAdd(new ListViewSpotQuotes());
            lvQuotes.SkipParentRender = true;
            lvQuotes.TheArgs = new ListArgs(x);
            lvQuotes.TheArgs.AddAllow = false;
            lvQuotes.TheArgs.ExportAllow = false;
            lvQuotes.TheArgs.OptionsAllow = false;
            lvQuotes.TheArgs.TheCaption = "Quotes";
            lvQuotes.TheArgs.TheClass = "orddet_quote";
            lvQuotes.TheArgs.TheLimit = -1;
            lvQuotes.TheArgs.TheOrder = "linecode";
            lvQuotes.TheArgs.TheTable = "orddet_quote";
            lvQuotes.TheArgs.TheTemplate = "orderbatch_quote_listview";
            lvQuotes.TheArgs.LiveItems = quotes;
            lvQuotes.CurrentTemplate = n_template.GetByName(x, lvQuotes.TheArgs.TheTemplate);
            if (lvQuotes.CurrentTemplate == null)
                lvQuotes.CurrentTemplate = n_template.Create(x, lvQuotes.TheArgs.TheClass, lvQuotes.TheArgs.TheTemplate);
            lvQuotes.CurrentTemplate.GatherColumns(x);
            lvQuotes.ColSource = new ColumnSourceTemplate(lvQuotes.CurrentTemplate);
            lvQuotes.RowSource = new RowSourceItem(lvQuotes.TheArgs.LiveItems.AllGet(x));
            lvQuotes.ItemDoubleClicked += new ItemDoubleClickHandler(lvQuotes_ItemDoubleClicked);
            lvQuotes.ItemSingleClicked += new ItemSingleClickHandler(lvQuotes_ItemSingleClicked);
            //lvBids
            lvBids = (ListViewSpotBids)SpotAdd(new ListViewSpotBids());
            lvBids.SkipParentRender = true;
            lvBids.TheArgs = new ListArgs(x);
            lvBids.TheArgs.AddAllow = false;
            lvBids.TheArgs.ExportAllow = false;
            lvBids.TheArgs.OptionsAllow = false;
            lvBids.TheArgs.TheCaption = "Bids";
            string q_id = "<not an id>";
            if (first != null)
            {
                q_id = first.unique_id;
                lvBids.TheArgs.TheCaption = "Bids for " + first.ToString();
            }
            lvBids.TheArgs.TheClass = "orddet_rfq";
            lvBids.TheArgs.TheLimit = -1;
            lvBids.TheArgs.TheOrder = "linecode";
            lvBids.TheArgs.TheTable = "orddet_rfq";
            lvBids.TheArgs.TheTemplate = "orderbatch_bid_listview";
            lvBids.TheArgs.TheWhere = "base_dealheader_uid = '" + TheDeal.unique_id + "' and the_orddet_quote_uid = '" + q_id + "'";
            lvBids.CurrentTemplate = n_template.GetByName(x, lvBids.TheArgs.TheTemplate);
            if (lvBids.CurrentTemplate == null)
                lvBids.CurrentTemplate = n_template.Create(x, lvBids.TheArgs.TheClass, lvBids.TheArgs.TheTemplate);
            lvBids.CurrentTemplate.GatherColumns(x);
            lvBids.ColSource = new ColumnSourceTemplate(lvBids.CurrentTemplate);
            lvBids.RowSource = new RowSourceTable(x.Select(lvBids.TheArgs.RenderSql((ContextRz)x, lvBids.CurrentTemplate)));
            lvBids.ItemDoubleClicked += new ItemDoubleClickHandler(lvBids_ItemDoubleClicked);
            lvBids.ItemSingleClicked += new ItemSingleClickHandler(lvBids_ItemSingleClicked);
        }
        private void ShowBids(ContextRz x, orddet_quote q)
        {
            lvBids.TheArgs.TheCaption = "Bids for " + q.ToString();
            lvBids.TheArgs.TheWhere = "base_dealheader_uid = '" + TheDeal.unique_id + "' and the_orddet_quote_uid = '" + q.unique_id + "'";
            lvBids.RowSource = new RowSourceTable(x.Select(lvBids.TheArgs.RenderSql((ContextRz)x, lvBids.CurrentTemplate)));
            lvBids.Change();
            TheView.ScriptsToRun.Add("$('#cmdNewBid').show();");
            TheView.ScriptsToRun.Add("$('#cmdAcceptBid').hide();");
        }
        private int GetQuoteCount()
        {
            if (TheDeal == null)
                return 0;
            int count = 0;
            foreach (KeyValuePair<String, Item> k in TheDeal.CustomerHalf.Details)
            {
                orddet_quote q = (orddet_quote)k.Value;
                if (q.IsQuoted)
                    count++;
            }
            return count;
        }
        private void SaveOrderBatch(ContextRz x, string s)
        {
            Dictionary<string, string> d = ParseValueString(s);
            if (d == null)
                return;
            string str = "";
            d.TryGetValue("dealheader_name", out str);
            TheDeal.dealheader_name = str;
            str = "";
            d.TryGetValue("customer_uid", out str);
            TheDeal.customer_uid = str;
            str = "";
            d.TryGetValue("customer_name", out str);
            TheDeal.customer_name = str;
            str = "";
            d.TryGetValue("contact_uid", out str);
            TheDeal.contact_uid = str;
            str = "";
            d.TryGetValue("contact_name", out str);
            TheDeal.contact_name = str;
            TheDeal.Update(x);
        }
        private void NewReq(ContextRz x)
        {
            if (TheDeal == null)
                return;
            if (!Tools.Strings.StrExt(TheDeal.customer_uid) || !Tools.Strings.StrExt(TheDeal.customer_name))
            {
                x.TheLeader.Tell("You must first choose a company above before adding a new requirement.");
                return;
            }
            orddet_quote q = TheDeal.CustomerHalf.QuoteAdd(x);
            if (q != null)
            {
                q.Update(x);
                TheReq = q;
                TheQuote = null;
                OpenReqQuote(x, q);
            }
        }
        private void ImportReqs(ContextRz x)
        {
            if (TheDeal == null)
                return;
            if (TheView == null)
                return;
            if (!Tools.Strings.StrExt(TheDeal.customer_uid) || !Tools.Strings.StrExt(TheDeal.customer_name))
            {
                x.TheLeader.Tell("You must first choose a company above before adding a new requirement.");
                return;
            }
            RzWeb.Screens.ImportScreenReqs s = new RzWeb.Screens.ImportScreenReqs(x, TheDeal);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, s));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + s.Uid + "');window.close();");
        }

        private void ImportBids(ContextRz x)
        {
            if (TheDeal == null)
                return;
            if (TheView == null)
                return;

            company vendor = x.TheLeaderRz.ChooseCompany(x);
            if (vendor == null)
                return;

            RzWeb.Screens.ImportScreenBids s = new RzWeb.Screens.ImportScreenBids(x, TheDeal, vendor);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, s));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + s.Uid + "');window.close();");
        }

        private void NewFormalQuote(ContextRz x)
        {
            if (TheDeal == null)
                return;
            if (GetQuoteCount() == 0)
            {
                x.TheLeader.Tell("You need at least one requirement with a quote quantity and quote price.");
                return;
            }
            TheDeal.CustomerHalf.FormalQuoteCreate((ContextRz)x);
        }
        private void NewSalesOrder(ContextRz x)
        {
            if (TheDeal == null)
                return;
            if (GetQuoteCount() == 0)
            {
                x.TheLeader.Tell("You need at least one requirement with a quote quantity and quote price.");
                return;
            }
            TheDeal.CustomerHalf.SalesOrderCreate((ContextRz)x);
        }
        private void NewBid(ContextRz x)
        {
            orddet_quote o = null;
            if (TheReq != null)
                o = TheReq;
            else if (TheQuote != null)
                o = TheQuote;
            if (o == null)
            {
                x.TheLeader.Tell("You need to first select a req or quote before adding a new bid.");
                return;
            }
            Rz5.company comp = ((LeaderWebUserRz)x.TheLeader).AskForCompany((Rz5.ContextRz)x, "Please choose a vendor below:", "");
            if (comp == null)
                return;
            Rz5.companycontact cont = ((LeaderWebUserRz)x.TheLeader).AskForContact((Rz5.ContextRz)x, "Please choose a contact below:", "", comp.unique_id);
            orddet_rfq r = TheDeal.VendorHalf.BidAdd(x, comp, cont);
            if (r != null)
            {
                r.fullpartnumber = o.fullpartnumber;
                r.target_quantity = o.target_quantity;
                r.quantityordered = o.target_quantity;
                r.manufacturer = o.manufacturer;
                r.condition = o.condition;
                r.category = o.category;
                r.description = o.description;
                r.is_accepted = false;
                r.Update(x);
                o.BidAbsorb(x, r);
                OpenBid(x, r);
            }
        }
        private void AcceptBid(ContextRz x)
        {
            orddet_quote q = TheReq;
            if (q == null)
                q = TheQuote;
            if (q == null)
                return;
            if (TheBid == null)
            {
                x.TheLeader.Tell("You need to first select a bid to accept.");
                return;
            }
            foreach (orddet_rfq rf in q.DetailsGet(x))
            {
                if (!Tools.Strings.StrCmp(rf.unique_id, TheBid.unique_id))
                    continue;
                rf.Accept(x);
                q.manufacturer = rf.manufacturer;
                q.datecode = rf.datecode;
                q.condition = rf.condition;
                q.packaging = rf.packaging;
                q.category = rf.category;
                q.description = rf.description;
                q.rohs_info = rf.rohs_info;
                q.unitcost = rf.unitprice;
                q.Update(x);
                break;
            }
            x.TheLeader.Tell("This bid has been accepted.");
            RzWeb.OrderBatch ob = new RzWeb.OrderBatch((ContextRz)x, TheDeal);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, ob));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + ob.Uid + "');window.close();");
        }
        private void OpenReqQuote(ContextRz x, orddet_quote d)
        {
            RzWeb.FormalQuoteLine q = new RzWeb.FormalQuoteLine(x, d, TheDeal);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void OpenBid(ContextRz x, orddet_rfq d)
        {
            RzWeb.RFQLine q = new RzWeb.RFQLine(x, d, TheDeal);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
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
        private void xCompany_CompanyChanged(ContextNM x, company c, ViewHandle v)
        {
            TheDeal.customer_uid = c.unique_id;
            TheDeal.customer_name = c.companyname;
            TheDeal.Update(x);
        }
        private void xCompany_ContactChanged(ContextNM x, companycontact c, ViewHandle v)
        {
            TheDeal.contact_uid = c.unique_id;
            TheDeal.contact_name = c.contactname;
            TheDeal.Update(x);
        }
        private void lvReqs_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_quote d = null;
            try { d = (orddet_quote)item; }
            catch { }
            if (d == null)
                return;
            OpenReqQuote((ContextRz)x, d);
        }
        private void lvQuotes_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_quote d = null;
            try { d = (orddet_quote)item; }
            catch { }
            if (d == null)
                return;
            OpenReqQuote((ContextRz)x, d);
        }
        private void lvBids_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_rfq d = null;
            try { d = (orddet_rfq)item; }
            catch { }
            if (d == null)
                return;
            OpenBid((ContextRz)x, d);
        }
        private void lvReqs_ItemSingleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            TheReq = (orddet_quote)item;
            TheQuote = null;
            TheBid = null;
            ShowBids((ContextRz)x, (orddet_quote)item);
        }
        private void lvQuotes_ItemSingleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            TheReq = null;
            TheQuote = (orddet_quote)item;
            TheBid = null;
            ShowBids((ContextRz)x, (orddet_quote)item);
            viewHandle.ScriptsToRun.Add("$('#cmdQuote').show();");
            viewHandle.ScriptsToRun.Add("$('#cmdSales').show();");
        }
        private void lvBids_ItemSingleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            TheBid = (orddet_rfq)item;
            viewHandle.ScriptsToRun.Add("$('#cmdAcceptBid').show();");
        }
    }
    public class ListViewSpotReqs : ListViewSpotRz
    {
        public ListViewSpotReqs()
            : base("orddet_quote")
        {
        }
    }
    public class ListViewSpotQuotes : ListViewSpotRz
    {
        public ListViewSpotQuotes()
            : base("orddet_quote")
        {
        }
    }
    public class ListViewSpotBids : ListViewSpotRz
    {
        public ListViewSpotBids()
            : base("orddet_rfq")
        {
        }
    }
}

