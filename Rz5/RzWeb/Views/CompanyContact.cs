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
using NewMethodWeb;
using Rz5;
using Rz5.Web;

namespace RzWeb
{
    public class CompanyContact : _Item
    {
        public companycontact TheContact
        {
            get
            {
                return (companycontact)Item;
            }
        }
        String CompanyDiv
        {
            get
            {
                return "company_" + Uid;
            }
        }
        String CompanyLinkDiv
        {
            get
            {
                return "companylinks_" + Uid;
            }
        }
        ListViewSpotCompQuotes lvQuotes;
        ListViewSpotCompBids lvBids;
        ListViewSpotOrders lvOrders;
        ListViewSpotCalls lvCalls;
        TextAreaControl txtNotes;
        TextControl txtContactName;
        TextControl txtCompanyName;
        TextControl txtPhone;
        TextControl txtExt;
        TextControl txtAltPhone;
        TextControl txtFax;
        TextControl txtAltFax;
        TextControl txtEmail;
        TextControl txtWebAddr;
        TextControl txtJobType;
        RzWeb.ChoicesControl cboType;
        RzWeb.ChoicesControl cboGender;
        RzWeb.ChoicesControl cboMarital;
        TextAreaControl txtInterests;
        AnchorControl aViewCompany;
        ViewHandle TheView;

        public CompanyContact(ContextRz x, companycontact c)
            : base(x, c)
        {
            InitListViews(x);
            txtNotes = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("contactnotes", "Notes", TheContact.contactnotes)));
            txtContactName = (TextControl)SpotAdd(ControlAdd(new TextControl("contactname", "Contact Name", TheContact.contactname)));
            txtCompanyName = (TextControl)SpotAdd(ControlAdd(new TextControl("companyname", "Company Name", TheContact.companyname)));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphone", "Phone Number", TheContact.primaryphone)));
            txtExt = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphoneextension", "Ext", TheContact.primaryphoneextension)));
            txtAltPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatephone", "Alternate Phone", TheContact.alternatephone)));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryfax", "Fax Number", TheContact.primaryfax)));
            txtAltFax = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatefax", "Alternate Fax", TheContact.alternatefax)));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryemailaddress", "Email", TheContact.primaryemailaddress)));
            txtWebAddr = (TextControl)SpotAdd(ControlAdd(new TextControl("primarywebaddress", "Web Address", TheContact.primarywebaddress)));
            txtJobType = (TextControl)SpotAdd(ControlAdd(new TextControl("jobtype", "Job Type", TheContact.jobtype)));
            cboType = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("contacttype", "Type", TheContact.contacttype, GetChoiceList(x, "contacttype"), "", "contacttype")));
            cboGender = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("contactgender", "Gender", TheContact.contactgender, GetChoiceList(x, "contactgender"), "", "contactgender")));
            cboMarital = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("maritalstatus", "Marital Status", TheContact.maritalstatus, GetChoiceList(x, "maritalstatus"), "", "maritalstatus")));            
            txtInterests = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("interests", "Interests", TheContact.interests)));
            aViewCompany = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewCompany", "View Company", "ViewCompany()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Contact Screen";
            if (TheContact != null)
            {
                s = TheContact.contactname + " [" + TheContact.companyname + "]";
            }
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <div id=\"company_" + Uid + "\" style=\"position: absolute; left: 2px; width: 600px; height: 200px;\">");
            sb.AppendLine("            <ul id=\"tabcompany_" + Uid + "\">");
            sb.AppendLine("                <li><a href=\"#tabInfo\" style=\"font-size: xx-small\">Info</a></li>");
            sb.AppendLine("                <li><a href=\"#tabMoreInfo\" style=\"font-size: xx-small\">More Info</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabInfo\">");
            txtContactName.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCompanyName.Render(x, sb, screenHandle, viewHandle, session, page);
            aViewCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtExt.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAltPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAltFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            txtWebAddr.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabMoreInfo\">");
            txtJobType.Render(x, sb, screenHandle, viewHandle, session, page);
            cboType.Render(x, sb, screenHandle, viewHandle, session, page);
            cboGender.Render(x, sb, screenHandle, viewHandle, session, page);
            cboMarital.Render(x, sb, screenHandle, viewHandle, session, page);
            txtInterests.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("        <div id=\"companylinks_" + Uid + "\" style=\"position: absolute; left: 2px;\">");
            sb.AppendLine("            <ul id=\"tabcompanylinks_" + Uid + "\">");
            sb.AppendLine("                <li><a href=\"#tabReqsQuotes\" style=\"font-size: xx-small\">Quotes</a></li>");
            sb.AppendLine("                <li><a href=\"#tabBids\" style=\"font-size: xx-small\">Bids</a></li>");
            sb.AppendLine("                <li><a href=\"#tabOrders\" style=\"font-size: xx-small\">Orders</a></li>");
            sb.AppendLine("                <li><a href=\"#tabNotes\" style=\"font-size: xx-small\">Notes</a></li>");
            sb.AppendLine("                <li><a href=\"#tabCalls\" style=\"font-size: xx-small\">Calls</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabReqsQuotes\">");
            lvQuotes.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabBids\">");
            lvBids.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabOrders\">");
            lvOrders.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabNotes\">");
            txtNotes.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabCalls\">");
            lvCalls.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ViewCompany() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine(ActionScript("'view_company'"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#company_" + Uid + "').tabs({ select: function(event, ui) { " + ActionScript("'tabShow'") + " } });");
            viewHandle.ScriptsToRun.Add("$('#companylinks_" + Uid + "').tabs({ select: function(event, ui) { " + ActionScript("'tabShow'") + " } });");            
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, CompanyDiv);
            PlaceDivBelowDiv(sb, CompanyLinkDiv, CompanyDiv);
            RunDivToBottom(sb, CompanyLinkDiv);
            sb.AppendLine("$('#" + CompanyLinkDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + CompanyLinkDiv + "').position().left - 15);");
            sb.AppendLine(lvQuotes.Select + ".css('top', 2);");
            sb.AppendLine(lvQuotes.Select + ".css('left', 2);");
            sb.AppendLine(lvQuotes.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvQuotes.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvBids.Select + ".css('top', 2);");
            sb.AppendLine(lvBids.Select + ".css('left', 2);");
            sb.AppendLine(lvBids.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvBids.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvOrders.Select + ".css('top', 2);");
            sb.AppendLine(lvOrders.Select + ".css('left', 2);");
            sb.AppendLine(lvOrders.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvOrders.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvCalls.Select + ".css('top', 2);");
            sb.AppendLine(lvCalls.Select + ".css('left', 2);");
            sb.AppendLine(lvCalls.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvCalls.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(txtNotes.Select + ".css('top', 2);");
            sb.AppendLine(txtNotes.Select + ".css('left', 2);");
            sb.AppendLine("$('#" + txtNotes.ControlId + "').css('width', $('#" + CompanyLinkDiv + "').width() - " + txtNotes.Select + ".position().left - 10);");
            sb.AppendLine("$('#" + txtNotes.ControlId + "').css('height', $('#" + CompanyLinkDiv + "').height() - " + txtNotes.Select + ".position().top - 53);");
            sb.AppendLine(txtContactName.Select + ".css('top', 2);");
            sb.AppendLine(txtContactName.Select + ".css('left', 2);");           
            sb.AppendLine(txtCompanyName.Select + ".css('top', 2);");
            sb.AppendLine(txtCompanyName.PlaceRight(txtContactName, false, 0, 0));
            sb.AppendLine(aViewCompany.Select + ".css('top', 2);");
            sb.AppendLine(aViewCompany.PlaceRight(txtContactName, false, 188, 0));
            sb.AppendLine(txtPhone.Select + ".css('left', 2);");
            sb.AppendLine(txtPhone.PlaceBelow(txtContactName));
            sb.AppendLine(txtExt.PlaceBelow(txtContactName));
            sb.AppendLine(txtExt.PlaceRight(txtPhone));
            sb.AppendLine(txtAltPhone.PlaceBelow(txtContactName));
            sb.AppendLine(txtAltPhone.PlaceRight(txtExt));
            sb.AppendLine(txtFax.Select + ".css('left', 2);");
            sb.AppendLine(txtFax.PlaceBelow(txtPhone));
            sb.AppendLine(txtAltFax.PlaceBelow(txtPhone));
            sb.AppendLine(txtAltFax.PlaceRight(txtFax));
            sb.AppendLine(txtEmail.Select + ".css('left', 2);");
            sb.AppendLine(txtEmail.PlaceBelow(txtFax, false, 0, 4));
            sb.AppendLine(txtWebAddr.PlaceBelow(txtFax, false, 0, 4));
            sb.AppendLine(txtWebAddr.PlaceRight(txtEmail));
            sb.AppendLine(txtJobType.Select + ".css('top', 2);");
            sb.AppendLine(txtJobType.Select + ".css('left', 2);");
            sb.AppendLine(cboType.Select + ".css('top', 2);");
            sb.AppendLine(cboType.PlaceRight(txtJobType));
            sb.AppendLine(cboGender.Select + ".css('left', 2);");
            sb.AppendLine(cboGender.PlaceBelow(txtJobType));
            sb.AppendLine(cboMarital.PlaceBelow(txtJobType));
            sb.AppendLine(cboMarital.PlaceRight(cboGender));
            sb.AppendLine(txtInterests.Select + ".css('left', 2);");
            sb.AppendLine(txtInterests.PlaceBelow(cboGender));
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                case "tabShow":
                    break;
                case "view_company":
                    ViewCompany((ContextRz)x);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            aViewCompany.TextFontSize = FontSize.Small;
            lvQuotes.ExtraStyle = "; font-size: small";
            lvBids.ExtraStyle = "; font-size: small";
            lvOrders.ExtraStyle = "; font-size: small";
            lvCalls.ExtraStyle = "; font-size: small";
            txtNotes.CaptionFontSize = FontSize.XSmall;
            txtNotes.TextFontSize = FontSize.XSmall;
            txtNotes.FixedWidth = 140;
            txtNotes.Rows = 5;
            txtContactName.CaptionFontSize = FontSize.Small;
            txtContactName.TextFontSize = FontSize.Small;
            txtContactName.FixedWidth = 285;
            txtCompanyName.CaptionFontSize = FontSize.Small;
            txtCompanyName.TextFontSize = FontSize.Small;
            txtCompanyName.FixedWidth = 280;
            txtCompanyName.ReadOnly = true;
            txtPhone.CaptionFontSize = FontSize.Small;
            txtPhone.TextFontSize = FontSize.Small;
            txtPhone.FixedWidth = 175;
            txtExt.CaptionFontSize = FontSize.Small;
            txtExt.TextFontSize = FontSize.Small;
            txtExt.FixedWidth = 175;
            txtAltPhone.CaptionFontSize = FontSize.Small;
            txtAltPhone.TextFontSize = FontSize.Small;
            txtAltPhone.FixedWidth = 205;
            txtFax.CaptionFontSize = FontSize.Small;
            txtFax.TextFontSize = FontSize.Small;
            txtFax.FixedWidth = 273;
            txtAltFax.CaptionFontSize = FontSize.Small;
            txtAltFax.TextFontSize = FontSize.Small;
            txtAltFax.FixedWidth = 292;
            txtEmail.CaptionFontSize = FontSize.Small;
            txtEmail.TextFontSize = FontSize.Small;
            txtEmail.FixedWidth = 273;
            txtWebAddr.CaptionFontSize = FontSize.Small;
            txtWebAddr.TextFontSize = FontSize.Small;
            txtWebAddr.FixedWidth = 292;
            txtJobType.CaptionFontSize = FontSize.Small;
            txtJobType.TextFontSize = FontSize.Small;
            txtJobType.FixedWidth = 287;
            cboType.CaptionFontSize = FontSize.Small;
            cboType.TextFontSize = FontSize.Small;
            cboType.FixedWidth = 295;
            cboGender.CaptionFontSize = FontSize.Small;
            cboGender.TextFontSize = FontSize.Small;
            cboGender.FixedWidth = 295;
            cboMarital.CaptionFontSize = FontSize.Small;
            cboMarital.TextFontSize = FontSize.Small;
            cboMarital.FixedWidth = 295;
            txtInterests.CaptionFontSize = FontSize.Small;
            txtInterests.TextFontSize = FontSize.Small;
            txtInterests.FixedWidth = 587;
            txtInterests.Rows = 2;
        }
        private void InitListViews(ContextRz x)
        {
            company c = (company)TheContact.TheCompanyVar.RefItemGet(x);
            lvQuotes = (ListViewSpotCompQuotes)SpotAdd(new ListViewSpotCompQuotes());
            lvQuotes.SkipParentRender = true;
            lvQuotes.TheArgs = new ListArgs(x);
            lvQuotes.TheArgs.AddAllow = false;
            lvQuotes.TheArgs.TheCaption = "Quotes";
            lvQuotes.TheArgs.TheClass = "orddet_quote";
            lvQuotes.TheArgs.TheLimit = -1;
            lvQuotes.TheArgs.TheOrder = "orderdate desc";
            lvQuotes.TheArgs.TheTable = "orddet_quote";
            lvQuotes.TheArgs.TheTemplate = "simple_quotes";
            lvQuotes.TheArgs.TheWhere = " base_company_uid = '" + c.unique_id  + "' and base_companycontact_uid = '" + TheContact.unique_id + "' "; 
            lvQuotes.CurrentTemplate = n_template.GetByName(x, lvQuotes.TheArgs.TheTemplate);
            if (lvQuotes.CurrentTemplate == null)
                lvQuotes.CurrentTemplate = n_template.Create(x, lvQuotes.TheArgs.TheClass, lvQuotes.TheArgs.TheTemplate);
            lvQuotes.CurrentTemplate.GatherColumns(x);
            lvQuotes.ColSource = new ColumnSourceTemplate(lvQuotes.CurrentTemplate);
            lvQuotes.RowSource = new RowSourceTable(x.Select(lvQuotes.TheArgs.RenderSql(x, lvQuotes.CurrentTemplate)));
            lvQuotes.ItemDoubleClicked += new ItemDoubleClickHandler(lvQuotes_ItemDoubleClicked);

            lvBids = (ListViewSpotCompBids)SpotAdd(new ListViewSpotCompBids());
            lvBids.SkipParentRender = true;
            lvBids.TheArgs = new ListArgs(x);
            lvBids.TheArgs.AddAllow = false;
            lvBids.TheArgs.TheCaption = "Bids";
            lvBids.TheArgs.TheClass = "orddet_rfq";
            lvBids.TheArgs.TheLimit = -1;
            lvBids.TheArgs.TheOrder = "orderdate desc";
            lvBids.TheArgs.TheTable = "orddet_rfq";
            lvBids.TheArgs.TheTemplate = "COMPANYQUOTES1";
            lvBids.TheArgs.TheWhere = " base_company_uid = '" + c.unique_id + "' and base_companycontact_uid = '" + TheContact.unique_id + "' ";
            lvBids.CurrentTemplate = n_template.GetByName(x, lvBids.TheArgs.TheTemplate);
            if (lvBids.CurrentTemplate == null)
                lvBids.CurrentTemplate = n_template.Create(x, lvBids.TheArgs.TheClass, lvBids.TheArgs.TheTemplate);
            lvBids.CurrentTemplate.GatherColumns(x);
            lvBids.ColSource = new ColumnSourceTemplate(lvBids.CurrentTemplate);
            lvBids.RowSource = new RowSourceTable(x.Select(lvBids.TheArgs.RenderSql(x, lvBids.CurrentTemplate)));
            lvBids.ItemDoubleClicked += new ItemDoubleClickHandler(lvBids_ItemDoubleClicked);

            lvOrders = (ListViewSpotOrders)SpotAdd(new ListViewSpotOrders());
            lvOrders.SkipParentRender = true;
            lvOrders.TheArgs = new ListArgs(x);
            lvOrders.TheArgs.AddAllow = false;
            lvOrders.TheArgs.TheCaption = "Orders";
            lvOrders.TheArgs.TheClass = "ordhed";
            lvOrders.TheArgs.TheLimit = -1;
            lvOrders.TheArgs.TheOrder = "orderdate desc";
            lvOrders.TheArgs.TheTable = "ordhed";
            lvOrders.TheArgs.TheTemplate = "COMPANYORDERS";
            lvOrders.TheArgs.TheWhere = "base_companycontact_uid = '" + TheContact.unique_id + "'";
            lvOrders.CurrentTemplate = n_template.GetByName(x, lvOrders.TheArgs.TheTemplate);
            if (lvOrders.CurrentTemplate == null)
                lvOrders.CurrentTemplate = n_template.Create(x, lvOrders.TheArgs.TheClass, lvOrders.TheArgs.TheTemplate);
            lvOrders.CurrentTemplate.GatherColumns(x);
            lvOrders.ColSource = new ColumnSourceTemplate(lvOrders.CurrentTemplate);
            lvOrders.RowSource = new RowSourceTable(x.Select(lvOrders.TheArgs.RenderSql(x, lvOrders.CurrentTemplate)));
            lvOrders.ItemDoubleClicked += new ItemDoubleClickHandler(lvOrders_ItemDoubleClicked);

            lvCalls = (ListViewSpotCalls)SpotAdd(new ListViewSpotCalls());
            lvCalls.SkipParentRender = true;
            lvCalls.TheArgs = new ListArgs(x);
            lvCalls.TheArgs.AddAllow = true;
            lvCalls.TheArgs.AddCaption = "Add New Call";
            lvCalls.TheArgs.TheCaption = "Calls";
            lvCalls.TheArgs.TheClass = "calllog";
            lvCalls.TheArgs.TheLimit = -1;
            lvCalls.TheArgs.TheOrder = "DATECALL desc";
            lvCalls.TheArgs.TheTable = "calllog";
            lvCalls.TheArgs.TheTemplate = "calllog";
            lvCalls.TheArgs.TheWhere = "base_companycontact_uid = '" + TheContact.unique_id + "'";
            lvCalls.CurrentTemplate = n_template.GetByName(x, lvCalls.TheArgs.TheTemplate);
            if (lvCalls.CurrentTemplate == null)
                lvCalls.CurrentTemplate = n_template.Create(x, lvCalls.TheArgs.TheClass, lvCalls.TheArgs.TheTemplate);
            lvCalls.CurrentTemplate.GatherColumns(x);
            lvCalls.ColSource = new ColumnSourceTemplate(lvCalls.CurrentTemplate);
            lvCalls.RowSource = new RowSourceTable(x.Select(lvCalls.TheArgs.RenderSql(x, lvCalls.CurrentTemplate)));
            lvCalls.ItemDoubleClicked += new ItemDoubleClickHandler(lvCalls_ItemDoubleClicked);
            lvCalls.AddNewItem += new ItemAddHandler(lvCalls_AddNewItem);
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
        private void ViewCompany(ContextRz x)
        {
            company c = company.GetById(x, TheContact.base_company_uid);
            if (c == null)
                return;
            RzWeb.Company q = new RzWeb.Company((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvQuotes_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.Quote));
        }
        private void lvBids_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgsOrder(x, item, Rz5.Enums.OrderType.RFQ));
        }
        private void lvOrders_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            ordhed o = CastOrder((ContextRz)x, (ordhed)item);
            x.Show(new ShowArgsOrder(x, o, o.OrderType));
        }
        private void lvCalls_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            calllog c = null;
            try { c = (calllog)item; }
            catch { }
            if (c == null)
                return;
            RzWeb.CallLog q = new RzWeb.CallLog((ContextRz)x, c, true);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvCalls_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            company c = (company)TheContact.TheCompanyVar.RefItemGet(x);
            calllog n = calllog.New((ContextRz)x);
            n.base_company_uid = c.unique_id;
            n.callcompanyname = c.companyname;
            n.base_mc_user_uid = ((ContextRz)x).xUserRz.unique_id;
            n.agentname = ((ContextRz)x).xUserRz.name;
            n.datecall = System.DateTime.Now;
            n.contactname = TheContact.contactname;
            n.base_companycontact_uid = TheContact.unique_id;
            n.Insert((ContextRz)x);
            RzWeb.CallLog q = new RzWeb.CallLog((ContextRz)x, n, true);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}

