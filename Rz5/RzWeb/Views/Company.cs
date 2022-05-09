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
    public class Company : _Item
    {
        public company TheCompany
        {
            get
            {
                return (company)Item;
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
        ListViewSpotContacts lvContacts;
        ListViewSpotAddress lvAddress;
        ListViewSpotShipAccounts lvShipAccounts;
        ListViewSpotOrderBatches lvOrderBatch;
        ListViewSpotCompQuotes lvQuotes;
        ListViewSpotCompBids lvBids;
        ListViewSpotOrders lvOrders;
        ListViewSpotNotes lvNotes;
        ListViewSpotCalls lvCalls;
        TextControl txtCompanyName;
        AgentControl xAgent;
        TextControl txtPhone;
        TextControl txtExt;
        TextControl txtFax;
        TextControl txtEmail;
        TextControl txtSource;
        RzWeb.ChoicesControl cboType;
        TextControl txtContact;
        TextAreaControl txtDescrip;
        TextControl txtCCNumber;
        RzWeb.ChoicesControl cboCCType;
        TextControl txtCCName;
        TextAreaControl txtBankInfo;
        Int32Control txtSec;
        Int32Control txtExpM;
        Int32Control txtExpY;
        TextControl txtBAddr;
        TextControl txtBZip;
        RzWeb.ChoicesControl cboTermsCust;
        RzWeb.ChoicesControl cboTermsVend;        
        ViewHandle TheView;

        public Company(ContextRz x, company c)
            : base(x, c)
        {
            InitListViews(x);
            txtCompanyName = (TextControl)SpotAdd(ControlAdd(new TextControl("companyname", "Company Name", TheCompany.companyname)));
            ArrayList agents = GetAgentArray(x);
            xAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("base_mc_user_uid|agentname", "Sales Agent", TheCompany.base_mc_user_uid, TheCompany.agentname, "base_mc_user_uid", "agentname", agents)));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphone", "Phone", TheCompany.primaryphone)));
            txtExt = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphoneextension", "Ext", TheCompany.primaryphoneextension)));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryfax", "Fax", TheCompany.primaryfax)));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryemailaddress", "Email", TheCompany.primaryemailaddress)));
            txtSource = (TextControl)SpotAdd(ControlAdd(new TextControl("source", "Source", TheCompany.source)));
            txtSource.DisableEdit = true;
            cboType = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("companytype", "Company Type", TheCompany.companytype, GetChoiceList(x, "companytype"), "", "companytype")));
            txtContact = (TextControl)SpotAdd(ControlAdd(new TextControl("primarycontact", "Primary Contact", TheCompany.primarycontact)));
            txtDescrip = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("description", "Description", TheCompany.description)));
            txtCCNumber = (TextControl)SpotAdd(ControlAdd(new TextControl("creditcardnumber", "Credit Card Number", TheCompany.creditcardnumber)));
            cboCCType = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("creditcardtype", "Credit Card Type", TheCompany.creditcardtype, GetChoiceList(x, "creditcardtypes"), "", "creditcardtypes")));
            txtCCName = (TextControl)SpotAdd(ControlAdd(new TextControl("nameoncard", "Name On Card", TheCompany.nameoncard)));
            txtBankInfo = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("bank_wire_info", "Bank Info", TheCompany.bank_wire_info)));
            txtSec = (Int32Control)SpotAdd(ControlAdd(new Int32Control("security_code", "Security Code", TheCompany.security_code)));
            txtExpM = (Int32Control)SpotAdd(ControlAdd(new Int32Control("expiration_month", "Exp Month", TheCompany.expiration_month)));
            txtExpY = (Int32Control)SpotAdd(ControlAdd(new Int32Control("expiration_year", "Exp Year", TheCompany.expiration_year)));
            txtBAddr = (TextControl)SpotAdd(ControlAdd(new TextControl("cardbillingaddr", "Billing Address", TheCompany.cardbillingaddr)));
            txtBZip = (TextControl)SpotAdd(ControlAdd(new TextControl("cardbillingzip", "Billing Zip", TheCompany.cardbillingzip)));
            cboTermsCust = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("termsascustomer", "Terms As Customer", TheCompany.termsascustomer, GetChoiceList(x, "terms"), "", "terms")));
            cboTermsVend = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("termsasvendor", "Terms As Vendor", TheCompany.termsasvendor, GetChoiceList(x, "terms"), "", "terms")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Company Screen";
            if (TheCompany != null)
                s = TheCompany.companyname;
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <div id=\"company_" + Uid + "\" style=\"position: absolute; left: 2px; width: 600px; height: 200px;\">");
            sb.AppendLine("            <ul id=\"tabcompany_" + Uid + "\">");
            sb.AppendLine("                <li><a href=\"#tabCompany\" style=\"font-size: xx-small\">Company</a></li>");            
            sb.AppendLine("                <li><a href=\"#tabTerms\" style=\"font-size: xx-small\">Terms</a></li>");
            sb.AppendLine("                <li><a href=\"#tabDescription\" style=\"font-size: xx-small\">Description</a></li>");
            sb.AppendLine("                <li><a href=\"#tabCreditCard\" style=\"font-size: xx-small\">Credit Card Info</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabCompany\">");
            txtCompanyName.Render(x, sb, screenHandle, viewHandle, session, page);
            xAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtExt.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSource.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            cboType.Render(x, sb, screenHandle, viewHandle, session, page);
            txtContact.Render(x, sb, screenHandle, viewHandle, session, page);    
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabTerms\">");
            cboTermsCust.Render(x, sb, screenHandle, viewHandle, session, page);
            cboTermsVend.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabDescription\">");
            txtDescrip.Render(x, sb, screenHandle, viewHandle, session, page);   
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabCreditCard\">");
            txtCCNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCCType.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCCName.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBankInfo.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSec.Render(x, sb, screenHandle, viewHandle, session, page);
            txtExpM.Render(x, sb, screenHandle, viewHandle, session, page);
            txtExpY.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBAddr.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBZip.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("        <div id=\"companylinks_" + Uid + "\" style=\"position: absolute; left: 2px;\">");
            sb.AppendLine("            <ul id=\"tabcompanylinks_" + Uid + "\">");
            sb.AppendLine("                <li><a href=\"#tabContacts\" style=\"font-size: xx-small\">Contacts</a></li>");
            sb.AppendLine("                <li><a href=\"#tabAddresses\" style=\"font-size: xx-small\">Address</a></li>");
            sb.AppendLine("                <li><a href=\"#tabShippingAccounts\" style=\"font-size: xx-small\">ShipAccounts</a></li>");
            sb.AppendLine("                <li><a href=\"#tabOrderBatches\" style=\"font-size: xx-small\">OrderBatches</a></li>");
            sb.AppendLine("                <li><a href=\"#tabReqsQuotes\" style=\"font-size: xx-small\">Quotes</a></li>");
            sb.AppendLine("                <li><a href=\"#tabBids\" style=\"font-size: xx-small\">Bids</a></li>");
            sb.AppendLine("                <li><a href=\"#tabOrders\" style=\"font-size: xx-small\">Orders</a></li>");
            sb.AppendLine("                <li><a href=\"#tabNotes\" style=\"font-size: xx-small\">Notes</a></li>");
            sb.AppendLine("                <li><a href=\"#tabCalls\" style=\"font-size: xx-small\">Calls</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabContacts\">");
            lvContacts.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabAddresses\">");
            lvAddress.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabShippingAccounts\">");
            lvShipAccounts.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabOrderBatches\">");
            lvOrderBatch.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
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
            lvNotes.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabCalls\">");
            lvCalls.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
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
            sb.AppendLine(lvContacts.Select + ".css('top', 2);");
            sb.AppendLine(lvContacts.Select + ".css('left', 2);");
            sb.AppendLine(lvContacts.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvContacts.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvAddress.Select + ".css('top', 2);");
            sb.AppendLine(lvAddress.Select + ".css('left', 2);");
            sb.AppendLine(lvAddress.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvAddress.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvShipAccounts.Select + ".css('top', 2);");
            sb.AppendLine(lvShipAccounts.Select + ".css('left', 2);");
            sb.AppendLine(lvShipAccounts.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvShipAccounts.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvOrderBatch.Select + ".css('top', 2);");
            sb.AppendLine(lvOrderBatch.Select + ".css('left', 2);");
            sb.AppendLine(lvOrderBatch.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvOrderBatch.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
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
            sb.AppendLine(lvNotes.Select + ".css('top', 2);");
            sb.AppendLine(lvNotes.Select + ".css('left', 2);");
            sb.AppendLine(lvNotes.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvNotes.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(lvCalls.Select + ".css('top', 2);");
            sb.AppendLine(lvCalls.Select + ".css('left', 2);");
            sb.AppendLine(lvCalls.Select + ".css('width', $('#" + CompanyLinkDiv + "').width() - 4);");
            sb.AppendLine(lvCalls.Select + ".css('height', $('#" + CompanyLinkDiv + "').height() - 28);");
            sb.AppendLine(txtCompanyName.Select + ".css('top', 7);");
            sb.AppendLine(txtCompanyName.Select + ".css('left', 2);");
            sb.AppendLine(xAgent.Select + ".css('top', 10);");
            sb.AppendLine(xAgent.PlaceRight(txtCompanyName, false, 12, 0));
            sb.AppendLine(txtPhone.Select + ".css('left', 2);");
            sb.AppendLine(txtPhone.PlaceBelow(txtCompanyName, false, 5, 0));
            sb.AppendLine(txtExt.PlaceBelow(txtCompanyName, false, 5, 0));
            sb.AppendLine(txtExt.PlaceRight(txtPhone));
            sb.AppendLine(txtFax.PlaceBelow(txtCompanyName, false, 5, 0));
            sb.AppendLine(txtFax.PlaceRight(txtExt));
            sb.AppendLine(txtSource.PlaceBelow(txtCompanyName, false, 5, 0));
            sb.AppendLine(txtSource.PlaceRight(txtFax));
            sb.AppendLine(txtContact.Select + ".css('left', 2);");
            sb.AppendLine(txtContact.PlaceBelow(txtPhone, false, 15, 0));
            sb.AppendLine(cboType.PlaceBelow(txtPhone, false, 15, 0));
            sb.AppendLine(cboType.PlaceRight(txtContact));
            sb.AppendLine(txtEmail.PlaceBelow(txtPhone, false, 15, 0));
            sb.AppendLine(txtEmail.PlaceRight(cboType));
            sb.AppendLine(txtDescrip.Select + ".css('top', 5);");
            sb.AppendLine(txtDescrip.Select + ".css('left', 2);");
            sb.AppendLine(txtCCNumber.Select + ".css('top', 5);");
            sb.AppendLine(txtCCNumber.Select + ".css('left', 2);");
            sb.AppendLine(cboCCType.Select + ".css('top', 5);");
            sb.AppendLine(cboCCType.PlaceRight(txtCCNumber));
            sb.AppendLine(txtCCName.PlaceBelow(txtCCNumber));
            sb.AppendLine(txtCCName.Select + ".css('left', 2);");
            sb.AppendLine(txtBankInfo.PlaceBelow(txtCCNumber));
            sb.AppendLine(txtBankInfo.PlaceRight(txtCCNumber));
            sb.AppendLine(txtSec.PlaceBelow(txtCCName));
            sb.AppendLine(txtSec.Select + ".css('left', 2);");
            sb.AppendLine(txtExpM.PlaceBelow(txtCCName));
            sb.AppendLine(txtExpM.PlaceRight(txtSec));
            sb.AppendLine(txtExpY.PlaceBelow(txtCCName));
            sb.AppendLine(txtExpY.PlaceRight(txtExpM));
            sb.AppendLine(txtBAddr.PlaceBelow(txtSec));
            sb.AppendLine(txtBAddr.Select + ".css('left', 2);");
            sb.AppendLine(txtBZip.PlaceBelow(txtSec));
            sb.AppendLine(txtBZip.PlaceRight(txtBAddr));
            sb.AppendLine(cboTermsCust.Select + ".css('top', 2);");
            sb.AppendLine(cboTermsCust.Select + ".css('left', 2);");
            sb.AppendLine(cboTermsVend.Select + ".css('left', 2);");
            sb.AppendLine(cboTermsVend.PlaceBelow(cboTermsCust));
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
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            lvContacts.ExtraStyle = "; font-size: small";
            lvAddress.ExtraStyle = "; font-size: small";
            lvShipAccounts.ExtraStyle = "; font-size: small";
            lvOrderBatch.ExtraStyle = "; font-size: small";
            lvQuotes.ExtraStyle = "; font-size: small";
            lvBids.ExtraStyle = "; font-size: small";
            lvOrders.ExtraStyle = "; font-size: small";
            lvNotes.ExtraStyle = "; font-size: small";
            lvCalls.ExtraStyle = "; font-size: small";
            txtCompanyName.CaptionFontSize = FontSize.Small;
            txtCompanyName.TextFontSize = FontSize.Small;
            txtCompanyName.FixedWidth = 350;
            xAgent.LabelFontSize = FontSize.Small;
            xAgent.TextFontSize = FontSize.Small;
            txtPhone.CaptionFontSize = FontSize.Small;
            txtPhone.TextFontSize = FontSize.Small;
            txtPhone.FixedWidth = 150;
            txtExt.CaptionFontSize = FontSize.Small;
            txtExt.TextFontSize = FontSize.Small;
            txtExt.FixedWidth = 50;
            txtFax.CaptionFontSize = FontSize.Small;
            txtFax.TextFontSize = FontSize.Small;
            txtFax.FixedWidth = 158;
            txtSource.CaptionFontSize = FontSize.Small;
            txtSource.TextFontSize = FontSize.Small;
            txtSource.FixedWidth = 187;
            txtContact.CaptionFontSize = FontSize.Small;
            txtContact.TextFontSize = FontSize.Small;
            txtContact.FixedWidth = 185;
            cboType.CaptionFontSize = FontSize.Small;
            cboType.TextFontSize = FontSize.Small;
            cboType.FixedWidth = 190;
            txtEmail.CaptionFontSize = FontSize.Small;
            txtEmail.TextFontSize = FontSize.Small;
            txtEmail.FixedWidth = 185;
            txtDescrip.CaptionFontSize = FontSize.Small;
            txtDescrip.TextFontSize = FontSize.Small;
            txtDescrip.FixedWidth = 590;
            txtDescrip.Rows = 7;
            txtCCNumber.CaptionFontSize = FontSize.XSmall;
            txtCCNumber.TextFontSize = FontSize.XSmall;
            txtCCNumber.FixedWidth = 301;
            cboCCType.CaptionFontSize = FontSize.XSmall;
            cboCCType.TextFontSize = FontSize.XSmall;
            cboCCType.FixedWidth = 275;
            txtCCName.CaptionFontSize = FontSize.XSmall;
            txtCCName.TextFontSize = FontSize.XSmall;
            txtCCName.FixedWidth = 301;
            txtBankInfo.CaptionFontSize = FontSize.XSmall;
            txtBankInfo.TextFontSize = FontSize.XSmall;
            txtBankInfo.FixedWidth = 270;
            txtBankInfo.Rows = 6;
            txtSec.CaptionFontSize = FontSize.XSmall;
            txtSec.TextFontSize = FontSize.XSmall;
            txtSec.FixedWidth = 100;
            txtExpM.CaptionFontSize = FontSize.XSmall;
            txtExpM.TextFontSize = FontSize.XSmall;
            txtExpM.FixedWidth = 56;
            txtExpY.CaptionFontSize = FontSize.XSmall;
            txtExpY.TextFontSize = FontSize.XSmall;
            txtExpY.FixedWidth = 56;
            txtBAddr.CaptionFontSize = FontSize.XSmall;
            txtBAddr.TextFontSize = FontSize.XSmall;
            txtBAddr.FixedWidth = 217;
            txtBZip.CaptionFontSize = FontSize.XSmall;
            txtBZip.TextFontSize = FontSize.XSmall;
            txtBZip.FixedWidth = 75;
            cboTermsCust.CaptionFontSize = FontSize.XSmall;
            cboTermsCust.TextFontSize = FontSize.XSmall;
            cboTermsCust.FixedWidth = 275;
            cboTermsVend.CaptionFontSize = FontSize.XSmall;
            cboTermsVend.TextFontSize = FontSize.XSmall;
            cboTermsVend.FixedWidth = 275;
        }
        private void InitListViews(ContextRz x)
        {
            lvContacts = (ListViewSpotContacts)SpotAdd(new ListViewSpotContacts());
            lvContacts.SkipParentRender = true;
            lvContacts.TheArgs = TheCompany.ContactArgsGet(x);
            lvContacts.CurrentTemplate = n_template.GetByName(x, lvContacts.TheArgs.TheTemplate);
            if (lvContacts.CurrentTemplate == null)
                lvContacts.CurrentTemplate = n_template.Create(x, lvContacts.TheArgs.TheClass, lvContacts.TheArgs.TheTemplate);
            lvContacts.CurrentTemplate.GatherColumns(x);
            lvContacts.ColSource = new ColumnSourceTemplate(lvContacts.CurrentTemplate);
            lvContacts.RowSource = new RowSourceTable(x.Select(lvContacts.TheArgs.RenderSql(x, lvContacts.CurrentTemplate)));
            lvContacts.ItemDoubleClicked += new ItemDoubleClickHandler(lvContacts_ItemDoubleClicked);
            lvContacts.AddNewItem += new ItemAddHandler(lvContacts_AddNewItem);

            lvAddress = (ListViewSpotAddress)SpotAdd(new ListViewSpotAddress());
            lvAddress.SkipParentRender = true;
            lvAddress.TheArgs = TheCompany.AddressArgsGet(x);
            lvAddress.CurrentTemplate = n_template.GetByName(x, lvAddress.TheArgs.TheTemplate);
            if (lvAddress.CurrentTemplate == null)
                lvAddress.CurrentTemplate = n_template.Create(x, lvAddress.TheArgs.TheClass, lvAddress.TheArgs.TheTemplate);
            lvAddress.CurrentTemplate.GatherColumns(x);
            lvAddress.ColSource = new ColumnSourceTemplate(lvAddress.CurrentTemplate);
            lvAddress.RowSource = new RowSourceTable(x.Select(lvAddress.TheArgs.RenderSql(x, lvAddress.CurrentTemplate)));
            lvAddress.ItemDoubleClicked += new ItemDoubleClickHandler(lvAddress_ItemDoubleClicked);
            lvAddress.AddNewItem += new ItemAddHandler(lvAddress_AddNewItem);

            lvShipAccounts = (ListViewSpotShipAccounts)SpotAdd(new ListViewSpotShipAccounts());
            lvShipAccounts.SkipParentRender = true;
            lvShipAccounts.TheArgs = TheCompany.AccountArgsGet(x);
            lvShipAccounts.CurrentTemplate = n_template.GetByName(x, lvShipAccounts.TheArgs.TheTemplate);
            if (lvShipAccounts.CurrentTemplate == null)
                lvShipAccounts.CurrentTemplate = n_template.Create(x, lvShipAccounts.TheArgs.TheClass, lvShipAccounts.TheArgs.TheTemplate);
            lvShipAccounts.CurrentTemplate.GatherColumns(x);
            lvShipAccounts.ColSource = new ColumnSourceTemplate(lvShipAccounts.CurrentTemplate);
            lvShipAccounts.RowSource = new RowSourceTable(x.Select(lvShipAccounts.TheArgs.RenderSql(x, lvShipAccounts.CurrentTemplate)));
            lvShipAccounts.ItemDoubleClicked += new ItemDoubleClickHandler(lvShipAccounts_ItemDoubleClicked);
            lvShipAccounts.AddNewItem += new ItemAddHandler(lvShipAccounts_AddNewItem);

            lvOrderBatch = (ListViewSpotOrderBatches)SpotAdd(new ListViewSpotOrderBatches());
            lvOrderBatch.SkipParentRender = true;
            lvOrderBatch.TheArgs = TheCompany.OrderBatchesArgsGet(x);
            lvOrderBatch.TheArgs.TheCaption = "Order Batches";
            lvOrderBatch.TheArgs.AddAllow = false;
            lvOrderBatch.CurrentTemplate = n_template.GetByName(x, lvOrderBatch.TheArgs.TheTemplate);
            if (lvOrderBatch.CurrentTemplate == null)
                lvOrderBatch.CurrentTemplate = n_template.Create(x, lvOrderBatch.TheArgs.TheClass, lvOrderBatch.TheArgs.TheTemplate);
            lvOrderBatch.CurrentTemplate.GatherColumns(x);
            lvOrderBatch.ColSource = new ColumnSourceTemplate(lvOrderBatch.CurrentTemplate);
            lvOrderBatch.RowSource = new RowSourceTable(x.Select(lvOrderBatch.TheArgs.RenderSql(x, lvOrderBatch.CurrentTemplate)));
            lvOrderBatch.ItemDoubleClicked += new ItemDoubleClickHandler(lvOrderBatch_ItemDoubleClicked);

            lvQuotes = (ListViewSpotCompQuotes)SpotAdd(new ListViewSpotCompQuotes());
            lvQuotes.SkipParentRender = true;
            lvQuotes.TheArgs = TheCompany.QuoteAndReqArgsGet(x);
            lvQuotes.TheArgs.TheCaption = "Quotes";
            lvQuotes.CurrentTemplate = n_template.GetByName(x, lvQuotes.TheArgs.TheTemplate);
            if (lvQuotes.CurrentTemplate == null)
                lvQuotes.CurrentTemplate = n_template.Create(x, lvQuotes.TheArgs.TheClass, lvQuotes.TheArgs.TheTemplate);
            lvQuotes.CurrentTemplate.GatherColumns(x);
            lvQuotes.ColSource = new ColumnSourceTemplate(lvQuotes.CurrentTemplate);
            lvQuotes.RowSource = new RowSourceTable(x.Select(lvQuotes.TheArgs.RenderSql(x, lvQuotes.CurrentTemplate)));
            lvQuotes.ItemDoubleClicked += new ItemDoubleClickHandler(lvQuotes_ItemDoubleClicked);

            lvBids = (ListViewSpotCompBids)SpotAdd(new ListViewSpotCompBids());
            lvBids.SkipParentRender = true;
            lvBids.TheArgs = TheCompany.BidArgsGet(x);
            lvBids.TheArgs.TheCaption = "Bids";
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
            lvOrders.TheArgs.TheWhere = "base_company_uid = '" + TheCompany.unique_id + "'";
            lvOrders.CurrentTemplate = n_template.GetByName(x, lvOrders.TheArgs.TheTemplate);
            if (lvOrders.CurrentTemplate == null)
                lvOrders.CurrentTemplate = n_template.Create(x, lvOrders.TheArgs.TheClass, lvOrders.TheArgs.TheTemplate);
            lvOrders.CurrentTemplate.GatherColumns(x);
            lvOrders.ColSource = new ColumnSourceTemplate(lvOrders.CurrentTemplate);
            lvOrders.RowSource = new RowSourceTable(x.Select(lvOrders.TheArgs.RenderSql(x, lvOrders.CurrentTemplate)));
            lvOrders.ItemDoubleClicked += new ItemDoubleClickHandler(lvOrders_ItemDoubleClicked);

            lvNotes = (ListViewSpotNotes)SpotAdd(new ListViewSpotNotes());
            lvNotes.SkipParentRender = true;
            lvNotes.TheArgs = TheCompany.NotesArgsGet(x);
            lvNotes.TheArgs.AddAllow = true;
            lvNotes.TheArgs.AddCaption = "Add New Note";
            lvNotes.TheArgs.TheCaption = "Notes";
            lvNotes.CurrentTemplate = n_template.GetByName(x, lvNotes.TheArgs.TheTemplate);
            if (lvNotes.CurrentTemplate == null)
                lvNotes.CurrentTemplate = n_template.Create(x, lvNotes.TheArgs.TheClass, lvNotes.TheArgs.TheTemplate);
            lvNotes.CurrentTemplate.GatherColumns(x);
            lvNotes.ColSource = new ColumnSourceTemplate(lvNotes.CurrentTemplate);
            lvNotes.RowSource = new RowSourceTable(x.Select(lvNotes.TheArgs.RenderSql(x, lvNotes.CurrentTemplate)));
            lvNotes.ItemDoubleClicked += new ItemDoubleClickHandler(lvNotes_ItemDoubleClicked);
            lvNotes.AddNewItem += new ItemAddHandler(lvNotes_AddNewItem);

            lvCalls = (ListViewSpotCalls)SpotAdd(new ListViewSpotCalls());
            lvCalls.SkipParentRender = true;
            lvCalls.TheArgs = TheCompany.CallArgsGet(x);
            lvCalls.TheArgs.AddAllow = true;
            lvCalls.TheArgs.AddCaption = "Add New Call";
            lvCalls.TheArgs.TheCaption = "Calls";
            lvCalls.CurrentTemplate = n_template.GetByName(x, lvCalls.TheArgs.TheTemplate);
            if (lvCalls.CurrentTemplate == null)
                lvCalls.CurrentTemplate = n_template.Create(x, lvCalls.TheArgs.TheClass, lvCalls.TheArgs.TheTemplate);
            lvCalls.CurrentTemplate.GatherColumns(x);
            lvCalls.ColSource = new ColumnSourceTemplate(lvCalls.CurrentTemplate);
            lvCalls.RowSource = new RowSourceTable(x.Select(lvCalls.TheArgs.RenderSql(x, lvCalls.CurrentTemplate)));
            lvCalls.ItemDoubleClicked += new ItemDoubleClickHandler(lvCalls_ItemDoubleClicked);
            lvCalls.AddNewItem += new ItemAddHandler(lvCalls_AddNewItem); 
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
        private void lvContacts_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            companycontact c = null;
            try { c = (companycontact)item; }
            catch { }
            if (c == null)
                return;
            RzWeb.CompanyContact q = new RzWeb.CompanyContact((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvAddress_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            companyaddress c = null;
            try { c = (companyaddress)item; }
            catch { }
            if (c == null)
                return;
            RzWeb.CompanyAddress q = new RzWeb.CompanyAddress((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvShipAccounts_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            shippingaccount c = null;
            try { c = (shippingaccount)item; }
            catch { }
            if (c == null)
                return;
            RzWeb.ShippingAccount q = new RzWeb.ShippingAccount((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvOrderBatch_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            x.Show(new ShowArgs(x, item));
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
        private void lvNotes_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            contactnote c = null;
            try { c = (contactnote)item; }
            catch { }
            if (c == null)
                return;
            RzWeb.ContactNote q = new RzWeb.ContactNote((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvCalls_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            calllog c = null;
            try { c = (calllog)item; }
            catch { }
            if (c == null)
                return;
            RzWeb.CallLog q = new RzWeb.CallLog((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvContacts_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            companycontact c = TheCompany.AddContact((ContextRz)x);
            RzWeb.CompanyContact q = new RzWeb.CompanyContact((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvAddress_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            companyaddress c = TheCompany.AddAddress((ContextRz)x);
            RzWeb.CompanyAddress q = new RzWeb.CompanyAddress((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvShipAccounts_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            shippingaccount c = shippingaccount.New((ContextRz)x);
            c.base_company_uid = TheCompany.unique_id;
            c.Insert((ContextRz)x);
            RzWeb.ShippingAccount q = new RzWeb.ShippingAccount((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvNotes_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            contactnote n = TheCompany.CreateNewContactNote((ContextRz)x);
            n.base_mc_user_uid = ((ContextRz)x).xUserRz.unique_id;
            n.agentname = ((ContextRz)x).xUserRz.name;
            n.notedate = System.DateTime.Now;
            n.Update((ContextRz)x);
            RzWeb.ContactNote q = new RzWeb.ContactNote((ContextRz)x, n);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");

        }
        private void lvCalls_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            calllog n = calllog.New((ContextRz)x);
            n.base_company_uid = TheCompany.unique_id;
            n.callcompanyname = TheCompany.companyname;
            n.base_mc_user_uid = ((ContextRz)x).xUserRz.unique_id;
            n.agentname = ((ContextRz)x).xUserRz.name;
            n.datecall = System.DateTime.Now;
            n.contactname = TheCompany.primarycontact;
            n.Insert((ContextRz)x);
            RzWeb.CallLog q = new RzWeb.CallLog((ContextRz)x, n);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
    public class ListViewSpotContacts : ListViewSpotRz
    {
        public ListViewSpotContacts()
            : base("companycontact")
        {
        }
    }
    public class ListViewSpotAddress : ListViewSpotRz
    {
        public ListViewSpotAddress()
            : base("companyaddress")
        {            
        }
    }
    public class ListViewSpotShipAccounts : ListViewSpotRz
    {
        public ListViewSpotShipAccounts()
            : base("shippingaccount")
        { 
        }
    }
    public class ListViewSpotOrderBatches : ListViewSpotRz
    {
        public ListViewSpotOrderBatches()
            : base("dealheader")
        {
        }
    }
    public class ListViewSpotCompQuotes : ListViewSpotRz
    {
        public ListViewSpotCompQuotes()
            : base("orddet_quote")
        {
        }
    }
    public class ListViewSpotCompBids : ListViewSpotRz
    {
        public ListViewSpotCompBids()
            : base("orddet_rfq")
        {
        }
    }
    public class ListViewSpotOrders : ListViewSpotRz
    {
        public ListViewSpotOrders()
            : base("ordhed")
        {
        }
    }
    public class ListViewSpotNotes : ListViewSpotRz
    {
        public ListViewSpotNotes()
            : base("contactnote")
        {
        }
    }
    public class ListViewSpotCalls : ListViewSpotRz
    {
        public ListViewSpotCalls()
            : base("calllog")
        {
        }
    }
}



