using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using RzWeb;

namespace Rz5.Web
{
    public delegate void CompanyChangedHandler(ContextNM x, company c, ViewHandle v);
    public delegate void ContactChangedHandler(ContextNM x, companycontact c, ViewHandle v);
    public delegate void CompanyContactClearHandler(ContextNM x, ViewHandle v);    
    public class CompanyContactControl : Control
    {
        public event CompanyChangedHandler CompanyChanged;
        public event ContactChangedHandler ContactChanged;
        public event CompanyContactClearHandler CompanyCleared;
        public event CompanyContactClearHandler ContactCleared;
        public String CompanyID = "";
        public String CompanyName = "";
        public String CompanyIDField = "";
        public String CompanyNameField = "";
        public String ContactID = "";
        public String ContactName = "";
        public String ContactIDField = "";
        public String ContactNameField = "";
        public bool Disabled = false;
        public bool CompanyOnly = false;
        public bool AskForContact = false;
        FontSize m_TextFontSize = FontSize.Inherit;
        public FontSize TextFontSize
        {
            get
            {
                return m_TextFontSize;
            }
            set
            {
                m_TextFontSize = value;
            }
        }

        public CompanyContactControl(String name, String caption, String company_id, String company_name, String company_id_field, String company_name_field, String contact_id, String contact_name, String contact_id_field, String contact_name_field, bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            CompanyID = company_id;
            CompanyName = company_name;
            CompanyIDField = company_id_field;
            CompanyNameField = company_name_field;
            ContactID = contact_id;
            ContactName = contact_name;
            ContactIDField = contact_id_field;
            ContactNameField = contact_name_field;
        }
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing, handled in render control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            string comp = CompanyName;
            string cont = ContactName;
            if (!Tools.Strings.StrExt(comp))
                comp = "&lt;click to choose&gt;";
            if (!Tools.Strings.StrExt(cont))
                cont = "&lt;click to choose&gt;";
            string height = "110";
            if (CompanyOnly)
                height = "70";
            sb.AppendLine("        <div id=\"" + ControlId + "\" style=\"position: absolute; width: 283px; height: " + height + "px;\">");
            sb.AppendLine("            <label style=\"font-size: x-small;\">" + Caption + "</label><br />");
            string font_size = "";
            if (TextFontSize != FontSize.Inherit)
            {
                switch (TextFontSize)
                {
                    case FontSize.XLarge:
                        font_size = " font-size: x-large; ";
                        break;
                    case FontSize.XXLarge:
                        font_size = " font-size: xx-large; ";
                        break;
                    case FontSize.XSmall:
                        font_size = " font-size: x-small; ";
                        break;
                    case FontSize.XXSmall:
                        font_size = " font-size: xx-small; ";
                        break;
                    case FontSize.Small:
                        font_size = " font-size: small; ";
                        break;
                    default:
                        font_size = " font-size: large; ";
                        break;
                }
            }
            string onclick = ActionScript("'choose_company'", "'na'");
            if (Disabled)
                onclick = "#";
            sb.AppendLine("            <a href=\"#\" onclick=\"" + onclick + "\" style=\"" + font_size + "\">" + comp + "</a><br />");
            if (Tools.Strings.StrExt(CompanyID))
            {
                sb.AppendLine("            &nbsp;<a href=\"#\" onclick=\"" + ActionScript("'view_company'", "'na'") + "\" style=\"font-size: x-small; color: #800080;\">view</a>");
                sb.AppendLine("            &nbsp;<a href=\"#\" onclick=\"" + ActionScript("'clear_company'", "'na'") + "\" style=\"font-size: x-small; color: #800080;\">clear</a>");
            }
            sb.AppendLine ("<br />");
            if (!CompanyOnly)
            {
                onclick = ActionScript("'choose_contact'", "'na'");
                if (Disabled)
                    onclick = "#";
                sb.AppendLine("            <a href=\"#\" onclick=\"" + onclick + "\" style=\"" + font_size + "\">" + cont + "</a><br />");
                if (Tools.Strings.StrExt(ContactID))
                {

                    sb.AppendLine("            &nbsp;<a href=\"#\" onclick=\"" + ActionScript("'view_contact'", "'na'") + "\" style=\"font-size: x-small; color: #800080;\">view</a>");
                    sb.AppendLine("            &nbsp;<a href=\"#\" onclick=\"" + ActionScript("'clear_contact'", "'na'") + "\"style=\"font-size: x-small; color: #800080;\">clear</a>");
                }
            }
            sb.AppendLine("        </div>");
            sb.AppendLine("<input id=\"companyname_" + ControlId + "\" type=\"text\" size=\"25\" value=\"" + CompanyName + "\" style=\"display: none;\" >");
            sb.AppendLine("<input id=\"companyid_" + ControlId + "\" type=\"text\" size=\"25\" value=\"" + CompanyID + "\" style=\"display: none;\" >");
            sb.AppendLine("<input id=\"contactname_" + ControlId + "\" type=\"text\" size=\"25\" value=\"" + ContactName + "\" style=\"display: none;\" >");
            sb.AppendLine("<input id=\"contactid_" + ControlId + "\" type=\"text\" size=\"25\" value=\"" + ContactID + "\" style=\"display: none;\" >");
        }
        public override string ValueAddScript(string varName)
        {
            return varName + " += '|" + CompanyIDField + ":' + ConvertToPostString($('#companyid_" + ControlId + "').val()) + '|" + CompanyNameField + ":' + ConvertToPostString($('#companyname_" + ControlId + "').val()) + '|" + ContactIDField + ":' + ConvertToPostString($('#contactid_" + ControlId + "').val()) + '|" + ContactNameField + ":' + ConvertToPostString($('#contactname_" + ControlId + "').val());";
        }
        public override bool ValueEquals(Object val)
        {
            //Need to figure this out further
            return false;
        }
        public override void ValueSet(Object val)
        {
            try
            {
                //Need to figure this out further                
            }
            catch { }
        }
        public override object StringToObject(String val)
        {
            return val;
        }
        public override void Act(Core.Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId.ToLower())
            {
                case "choose_company":
                    ChooseCompany((ContextRz)x, args.SourceView);
                    break;
                case "choose_contact":
                    ChooseContact((ContextRz)x, args.SourceView);
                    break;
                case "clear_company":
                    ClearCompany((ContextRz)x, args.SourceView);
                    break;
                case "view_company":
                    ViewCompany((ContextRz)x);
                    break;
                case "clear_contact":
                    ClearContact((ContextRz)x, args.SourceView);
                    break;
                case "view_contact":
                    ViewContact((ContextRz)x);
                    break;

                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void ChooseCompany(ContextRz x, ViewHandle v)
        {
            Rz5.company c = ((LeaderWebUserRz)x.TheLeader).AskForCompany((Rz5.ContextRz)x, "Please choose a company below:", CompanyID);
            if (c == null)
                return;
            CompanyID = c.unique_id;
            CompanyName = c.companyname;
            if (CompanyChanged != null)
                CompanyChanged(x, c, v);
            ContactID = "";
            ContactName = "";
            Change();
            if (AskForContact)
                ChooseContact(x, v);
        }
        private void ClearCompany(ContextRz x, ViewHandle v)
        {
            CompanyID = "";
            CompanyName = "";
            ContactID = "";
            ContactName = "";
            if (CompanyCleared != null)
                CompanyCleared(x, v);
            Change();
        }
        private void ChooseContact(ContextRz x, ViewHandle v)
        {
            Rz5.companycontact c = ((LeaderWebUserRz)x.TheLeader).AskForContact((Rz5.ContextRz)x, "Please choose a contact below:", ContactID, CompanyID);
            if (c == null)
                return;
            ContactID = c.unique_id;
            ContactName = c.contactname;
            if (ContactChanged != null)
                ContactChanged(x, c, v);
            Change();
        }
        private void ViewCompany(ContextRz x)
        {
            if (!Tools.Strings.StrExt(CompanyID))
                return;
            Rz5.company c = Rz5.company.GetById(x, CompanyID);
            if (c == null)
                return;
            x.Show(new ShowArgs(x, ViewType.SingleItem, c));
        }
        private void ClearContact(ContextRz x, ViewHandle v)
        {
            ContactID = "";
            ContactName = "";
            if (ContactCleared != null)
                ContactCleared(x, v);
            Change();
        }
        private void ViewContact(ContextRz x)
        {
            if (!Tools.Strings.StrExt(ContactID))
                return;
            Rz5.companycontact c = Rz5.companycontact.GetById(x, ContactID);
            if (c == null)
                return;
            x.Show(new ShowArgs(x, ViewType.SingleItem, c));
        }
    }
    public class WebThreadHandleAskCompany : WebThreadHandle
    {
        public String Prompt;
        private String ID = "";
        String CustomerId;
        String DefaultValue = "";
        Rz5.company TheCompany;

        public WebThreadHandleAskCompany(ContextRz x, String ask, String defaultValue, String customerId)
            : base((LeaderWebUser)x.Leader)
        {
            Prompt = ask;
            DefaultValue = defaultValue;
            TheCompany = Rz5.company.GetById(x, DefaultValue);
            CustomerId = customerId;
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public String NonResult
        {
            get
            {
                try
                {
                    return TheRequest["nonresult"];
                }
                catch { return ""; }
            }
        }
        public Boolean New
        {
            get
            {
                try
                {
                    string s = TheRequest["new"];
                    return Tools.Strings.StrCmp(s, "y");
                }
                catch { return false; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            string val = "";
            string id = "";
            if (TheCompany != null)
            {
                val = TheCompany.companyname;
                id = TheCompany.unique_id;
            }
            sb.Append("<input type=\"text\" id=\"" + ID + "\" value=\"" + val + "\" style=\"margin: 4px; width: 310px;\" onKeyDown=\"if(event.keyCode == 13) $('#ok_" + Uid + "').click();\">");
            sb.Append("<input id=\"cmdDrop\" type=\"button\" value=\"\" onclick=\"$('#" + ID + "').val('*'); $('#" + ID + "').trigger('keydown'); return false;\">");
            sb.Append("<input id=\"cmdAdd\" type=\"button\" value=\"\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#" + ID + "').val()},{name: 'new', value: 'y'}]);\">");
            sb.Append("<input type=\"text\" id=\"id_" + ID + "\" value=\"" + id + "\" style=\"display: none;\">");
            sb.Append("<br><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#id_" + ID + "').val()},{name: 'nonresult', value: $('#" + ID + "').val()}]);\">");
            string s = "";
            if (!((LeaderWebUserRz)((ContextRz)x).TheLeaderRz).DemoInfoCleared((ContextRz)x))
                s = "$('#" + ID + "').val('EX'); $('#" + ID + "').trigger('keydown');";
            sb.AppendLine("<script type=\"text/javascript\">$('#dialog_div').dialog({ height: 180, width: 450 }); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); AutoCompleteCompany('" + ID + "', 'id_" + ID + "', '" + CustomerId + "'); $('#" + ID + "').focus().select(); buttonize('cmdAdd', 'add.png'); $('#cmdAdd').css('padding', '0px 6px 0px 6px').button(); buttonize('cmdDrop', 'drop.png'); $('#cmdDrop').css('padding', '0px 6px 0px 6px').button();" + s + " </script>");
            return sb.ToString();
        }
        public override String Script
        {
            get
            {
                return "Ask('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "');";
            }
        }
    }
    public class WebThreadHandleAskContact : WebThreadHandle
    {
        public String Prompt;
        private String ID = "";
        String DefaultValue = "";
        String CompanyID = "";
        ContextRz TheContext;

        public WebThreadHandleAskContact(ContextRz x, String ask, String defaultValue, String company_id)
            : base((LeaderWebUser)x.Leader)
        {
            Prompt = ask;
            DefaultValue = defaultValue;
            CompanyID = company_id;
            TheContext = x;
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public Boolean New
        {
            get
            {
                try
                {
                    string s = TheRequest["new"];
                    return Tools.Strings.StrCmp(s, "y");
                }
                catch { return false; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            sb.AppendLine("<select id=\"" + ID + "\" name=\"" + ID + "\" style=\"width: 310px;\" ><option value=\"\"></option>");
            ArrayList List = null;
            if (Tools.Strings.StrExt(CompanyID))
                List = TheContext.QtC("companycontact", "select * from companycontact where base_company_uid = '" + CompanyID + "'");
            if (List == null)
                List = new ArrayList();
            foreach (Rz5.companycontact c in List)
            {
                string sel = "";
                if (Tools.Strings.StrCmp(c.unique_id, DefaultValue))
                    sel = "selected";
                sb.AppendLine("<option " + sel + " value=\"" + c.unique_id + "\">" + Tools.Html.ConvertTextToHTML(c.contactname) + "</option>");
            }
            sb.AppendLine("</select>");
            sb.Append("<input id=\"cmdAdd\" type=\"button\" value=\"\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: '" + CompanyID + "'},{name: 'new', value: 'y'}]);\">");
            sb.Append("<br><br><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: $('#" + ID + "').val()}]);\">");
            sb.AppendLine("<script type=\"text/javascript\"> $('#dialog_div').dialog({ height: 180, width: 400 }); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); $('#" + ID + "').focus().select(); buttonize('cmdAdd', 'add.png'); $('#cmdAdd').css('padding', '0px 6px 0px 6px').button(); </script>");
            return sb.ToString();
        }
    }  
    public class WebThreadHandleAskInventory : WebThreadHandle
    {
        public String Prompt;
        private String ID = "";
        String CustomerId;
        String DefaultPart = "";
        RzWeb.ListViewPartSearch lv;
        Screen TheScreen;
        System.Web.SessionState.HttpSessionState TheSession;
        System.Web.UI.Page ThePage;

        public WebThreadHandleAskInventory(ContextRz x, String ask, String defaultPart, String customerId, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
            : base((LeaderWebUser)x.Leader)
        {
            Prompt = ask;
            DefaultPart = defaultPart;
            CustomerId = customerId;
            TheScreen = screenHandle;
            TheSession = session;
            ThePage = page;
            if (!Tools.Strings.StrExt(defaultPart))
                defaultPart = "Search By Part Number";
            PartSearchParameters p = new PartSearchParameters(defaultPart);
            p.IncludeAllocated = false;
            p.IncludeStock = true;
            p.IncludeConsign = true;
            p.IncludeExcess = false;
            lv = new RzWeb.ListViewPartSearch();
            lv.SkipParentRender = true;
            lv.TheArgs = x.Sys.ThePartLogic.PartSearchArgsGet(x, p);
            lv.TheArgs.TheCaption = "Stock and Consignment";
            lv.TheArgs.AddAllow = false;
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public bool Search
        {
            get
            {
                try
                {
                    return Tools.Strings.StrCmp(TheRequest["search"], "y");
                }
                catch { return false; }
            }
        }
        public String PartNumber
        {
            get
            {
                try
                {
                    return TheRequest["partnumber"];
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            lv.TheScreen = TheScreen;
            lv.ExtraStyle = "; font-size: small; height: 80px";
            sb.AppendLine("<div id=\"criteria_" + Uid + "\" style=\"position: absolute; top: 30px; left: 13px; width: 400px; height: 30px; font-size: small;\">");
            sb.Append("<input type=\"text\" id=\"" + ID + "\" value=\"" + DefaultPart + "\" size=\"40\" style=\"margin: 4px;\">");
            sb.Append("<input id=\"search_inv_" + Uid + "\" type=\"button\" value=\"Search\" onclick=\"Reply('" + Uid + "', [{name: 'search', value: 'Y'},{name: 'partnumber', value: $('#" + ID + "').val()}]);\" >");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"results_" + Uid + "\" style=\"position: absolute; top: 70px; left: 15px; width: 375px; height: 130px; font-size: small;\">");            
            lv.Render(x, sb, TheScreen, ((LeaderWebUser)Leader).TheViewHandle, TheSession, ThePage);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"commands_" + Uid + "\" style=\"position: absolute; top: 205px; left: 13px; width: 400px; height: 60px; font-size: small;\">");
            sb.Append("<input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: " + lv.SelectedRowIdsScript + "}]);\">");
            sb.AppendLine("</div>");
            sb.AppendLine("<script type=\"text/javascript\">$('#dialog_div').dialog({ height: 295, width: 435 }); " + lv.Select + ".css('width', 390); " + lv.Select + ".css('height', 130); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); $('#search_inv_" + Uid + "').css('padding', '0px 6px 0px 6px').button(); $('#" + ID + "').focus().select(); </script>");
            return sb.ToString();
        }
        public override String Script
        {
            get
            {
                return "Ask('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "');";
            }
        }        
    }
    public class WebThreadHandleAskBid : WebThreadHandle
    {
        public String Prompt;
        private String ID = "";
        String CustomerId;
        String DefaultPart = "";
        RzWeb.ListViewPartSearch lv;
        Screen TheScreen;
        ViewHandle TheView;
        System.Web.SessionState.HttpSessionState TheSession;
        System.Web.UI.Page ThePage;

        public WebThreadHandleAskBid(ContextRz x, String ask, String defaultPart, String customerId, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
            : base((LeaderWebUser)x.Leader)
        {
            Prompt = ask;
            DefaultPart = defaultPart;
            CustomerId = customerId;
            TheScreen = screenHandle;
            TheView = viewHandle;
            TheSession = session;
            ThePage = page;
            lv = new RzWeb.ListViewPartSearch();
            lv.SkipParentRender = true;
            PartSearchParameters p = new PartSearchParameters(defaultPart);
            p.IncludeAllocated = false;
            p.IncludeStock = true;
            p.IncludeConsign = true;
            p.IncludeExcess = false;
            lv.TheArgs = x.Sys.TheQuoteLogic.QuoteSearchArgsGet(x, Enums.PartSearchType.Bids, SearchComparison.Fuzzy, p, true);
            lv.TheArgs.TheCaption = "Bids";
            lv.TheArgs.AddAllow = false;
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public bool Search
        {
            get
            {
                try
                {
                    return Tools.Strings.StrCmp(TheRequest["search"], "y");
                }
                catch { return false; }
            }
        }
        public String PartNumber
        {
            get
            {
                try
                {
                    return TheRequest["partnumber"];
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            lv.TheScreen = TheScreen;
            lv.ExtraStyle = "; font-size: small; height: 80px";
            sb.AppendLine("<div id=\"criteria_" + Uid + "\" style=\"position: absolute; top: 30px; left: 13px; width: 400px; height: 30px; font-size: small;\">");
            sb.Append("<input type=\"text\" id=\"" + ID + "\" value=\"" + DefaultPart + "\" size=\"40\" style=\"margin: 4px;\">");
            sb.Append("<input id=\"search_inv_" + Uid + "\" type=\"button\" value=\"Search\" onclick=\"Reply('" + Uid + "', [{name: 'search', value: 'Y'},{name: 'partnumber', value: $('#" + ID + "').val()}]);\" >");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"results_" + Uid + "\" style=\"position: absolute; top: 70px; left: 15px; width: 375px; height: 130px; font-size: small;\">");
            lv.Render(x, sb, TheScreen, TheView, TheSession, ThePage);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"commands_" + Uid + "\" style=\"position: absolute; top: 205px; left: 13px; width: 400px; height: 60px; font-size: small;\">");
            sb.Append("<input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: " + lv.SelectedRowIdsScript + "}]);\">");//SelectedRowIds('" + lv.TableId() + "')
            sb.AppendLine("</div>");
            //top: 5px; left: 5px;height: 435, width: 765
            sb.AppendLine("<script type=\"text/javascript\">$('#dialog_div').dialog({ height: 295, width: 435 }); " + lv.Select + ".css('width', 390); " + lv.Select + ".css('height', 130); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); $('#search_inv_" + Uid + "').css('padding', '0px 6px 0px 6px').button(); $('#" + ID + "').focus().select(); </script>");//height: 280, width: 415
            return sb.ToString();
        }
        public override String Script
        {
            get
            {
                return "Ask('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "');";
            }
        }
    }
    public class WebThreadHandleAskCancelArgs : WebThreadHandle
    {
        public String Prompt;
        private String ID = "";
        private OrderLineCancelArgs TheArgs;

        public WebThreadHandleAskCancelArgs(ContextRz x, String ask, OrderLineCancelArgs args)
            : base((LeaderWebUser)x.Leader)
        {
            Prompt = ask;
            TheArgs = args;
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder notposs = new StringBuilder();
            ArrayList poss = new ArrayList();
            OrderLineCancelStatus s = TheArgs.TheLine.CancelStatusGet((ContextRz)x);
            foreach (OrderLineCancelStatusEntry e in s.Entries)
            {
                if (e.CancelPossible)
                {
                    OrderHand o = new OrderHand();
                    o.TheOrder = e.TheOrder;
                    if (TheArgs.TypesToCancel.Contains(e.TheOrder.OrderType))
                        o.Selected = true;
                    poss.Add(o);
                }
                else
                    notposs.AppendLine(e.TheOrder.ToString() + " (" + e.NotPossibleReason + ")");
            }
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            sb.AppendLine("<div id=\"cancel_lines_" + Uid + "\" style=\"position: absolute; overflow: scroll; padding: 6px; width: 220px; left: 10px; height: 95px;\">");
            sb.AppendLine("<div id=\"checks_" + Uid + "\" style=\"position: absolute; padding: 6px; width: 500px; top: 0px; left: 0px; height: 100px;\">");
            foreach (OrderHand o in poss)
            {
                string cap = o.TheOrder.ordernumber + " : " + o.TheOrder.OrderType.ToString() + " : " + o.TheOrder.companyname + " : " + o.TheOrder.orderdate.ToShortDateString();
                string check = "";
                if (o.Selected)
                    check = " checked=\"checked\" ";
                sb.AppendLine("<input id=\"bool_" + o.TheOrder.unique_id + "\" type=\"checkbox\" name=\"bool_" + o.TheOrder.unique_id + "\" value=\"bool_" + o.TheOrder.unique_id + "\" " + check + " /><label for=\"bool_" + o.TheOrder.unique_id + "\" style=\"font-size: xx-small;\">" + cap + "</label><br>");
            } 
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"not_possible" + Uid + "\" style=\"position: absolute; overflow: scroll; padding: 6px; width: 210px; top: 45px; left: 240px; height: 100px;\">");
            sb.AppendLine("   <textarea id=\"not_poss_" + ID + "\" style=\"font-size: xx-small; width: 300px; height: 80px;\" name=\"not_poss_" + ID + "\">" + notposs.ToString() + "</textarea>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"cancel_lines_" + Uid + "\" style=\"position: absolute; padding: 6px; width: 220px; left: 10px; height: 55px; top: 155px;\">");
            string ok_script = "''";
            if (poss.Count > 0)
            {
                ok_script = "";
                foreach (OrderHand o in poss)
                {
                    if (Tools.Strings.StrExt(ok_script))
                        ok_script += "+'|'+";
                    ok_script += "'" + o.TheOrder.unique_id + "_dot_" + "' + $('#bool_" + o.TheOrder.unique_id + ":checked').val()";
                } 
            }
            sb.AppendLine("   <input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"ReplyCancel('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"ReplyCancel('" + Uid + "', [{name: 'result', value: " + ok_script + "}]);\">");
            sb.AppendLine("</div>");
            sb.AppendLine("<script type=\"text/javascript\">$('#dialog_div').dialog({ height: 210, width: 470 }); $('#dialog_div').css('height', 210); $('#dialog_div').css('width', 470); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); </script>");
            return sb.ToString();
        }
        public override String Script
        {
            get
            {
                return "AskCancelArgs('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "');";
            }
        }
        private class OrderHand
        {
            public ordhed TheOrder;
            public bool Selected = false;
        }
    }
    public class WebThreadHandleAskPurchaseOrderLink : WebThreadHandle
    {
        public String Prompt;
        private String ID = "";
        ListViewSpotDetails lv;
        private String SearchPO = "";
        Screen TheScreen;
        ViewHandle TheView;
        System.Web.SessionState.HttpSessionState TheSession;
        System.Web.UI.Page ThePage;

        public WebThreadHandleAskPurchaseOrderLink(ContextRz x, String ask, String searchPO, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
            : base((LeaderWebUser)x.Leader)
        {
            Prompt = ask;
            TheScreen = screenHandle;
            TheView = viewHandle;
            TheSession = session;
            ThePage = page;
            SearchPO = searchPO;
            lv = new ListViewSpotDetails();
            lv.SkipParentRender = true;
            lv.TheArgs = new ListArgs(x);
            lv.TheArgs.TheCaption = "Purchase Order Lines";
            lv.TheArgs.TheTemplate = "ORDERDETAILPurchase";
            lv.TheArgs.TheClass = "orddet_line";
            lv.TheArgs.TheLimit = 200;
            lv.TheArgs.TheOrder = "orddet_line.ordernumber_purchase";
            lv.TheArgs.TheTable = "orddet_line";
            lv.TheArgs.TheWhere = "orddet_line.ordernumber_purchase like '" + SearchPO + "%'";
            lv.TheArgs.AddAllow = false;
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            if (Tools.Strings.StrExt(SearchPO))
                lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
        }
        public String Result
        {
            get
            {
                try
                {
                    return TheRequest["result"];
                }
                catch { return ""; }
            }
        }
        public bool Search
        {
            get
            {
                try
                {
                    return Tools.Strings.StrCmp(TheRequest["search"], "y");
                }
                catch { return false; }
            }
        }
        public String OrderNumber
        {
            get
            {
                try
                {
                    return TheRequest["ordernumber"];
                }
                catch { return ""; }
            }
        }
        public override string Caption
        {
            get
            {
                return Prompt;
            }
        }
        public override string Render(Context x)
        {
            StringBuilder sb = new StringBuilder();
            ID = "x" + Tools.Strings.GetNewID();
            lv.TheScreen = TheScreen;
            lv.ExtraStyle = "; font-size: small; height: 80px";
            sb.AppendLine("<div id=\"criteria_" + Uid + "\" style=\"position: absolute; top: 30px; left: 13px; width: 400px; height: 30px; font-size: small;\">");
            sb.Append("<input type=\"text\" id=\"" + ID + "\" value=\"" + SearchPO + "\" size=\"40\" style=\"margin: 4px;\">");
            sb.Append("<input id=\"search_inv_" + Uid + "\" type=\"button\" value=\"Search\" onclick=\"Reply('" + Uid + "', [{name: 'search', value: 'Y'},{name: 'ordernumber', value: $('#" + ID + "').val()}]);\" >");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"results_" + Uid + "\" style=\"position: absolute; top: 70px; left: 15px; width: 375px; height: 130px; font-size: small;\">");
            lv.Render(x, sb, TheScreen, TheView, TheSession, ThePage);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"commands_" + Uid + "\" style=\"position: absolute; top: 205px; left: 13px; width: 400px; height: 60px; font-size: small;\">");
            sb.Append("<input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: ''}]);\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"Reply('" + Uid + "', [{name: 'result', value: " + lv.SelectedRowIdsScript + "}]);\">");//SelectedRowIds('" + lv.TableId() + "')
            sb.AppendLine("</div>");
            sb.AppendLine("<script type=\"text/javascript\">$('#dialog_div').dialog({ height: 280, width: 415 }); " + lv.Select + ".css('width', 390); " + lv.Select + ".css('height', 130); buttonize('ok_" + Uid + "', 'Ok.png'); buttonize('cancel_" + Uid + "', 'Cancel.png'); $('#search_inv_" + Uid + "').css('padding', '0px 6px 0px 6px').button(); $('#" + ID + "').focus().select(); </script>");
            return sb.ToString();
        }
        public override String Script
        {
            get
            {
                return "Ask('" + Uid + "', '" + Tools.Html.AlertFilter(Caption) + "');";
            }
        }
    }
}