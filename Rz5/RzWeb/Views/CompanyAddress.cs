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
    public class CompanyAddress : _Item
    {
        public companyaddress TheAddress
        {
            get
            {
                return (companyaddress)Item;
            }
        }
        BoolControl chkDefBill;
        BoolControl chkDefShip;
        TextControl txtDescr;
        TextControl txtLine1;
        TextControl txtLine2;
        TextControl txtLine3;
        TextControl txtCity;
        ComboBoxControl cboState;
        TextControl txtZip;
        ComboBoxControl cboCountry;
        AnchorControl aViewCompany;
        ViewHandle TheView;
        String AddrDiv
        {
            get
            {
                return "company_address_" + Uid;
            }
        }

        public CompanyAddress(ContextRz x, companyaddress c)
            : base(x, c)
        {
            chkDefBill = (BoolControl)SpotAdd(ControlAdd(new BoolControl("defaultbilling", "Default Billing", TheAddress.defaultbilling)));
            chkDefShip = (BoolControl)SpotAdd(ControlAdd(new BoolControl("defaultshipping", "Default Shipping", TheAddress.defaultshipping)));
            txtDescr = (TextControl)SpotAdd(ControlAdd(new TextControl("description", "Description", TheAddress.description)));
            txtLine1 = (TextControl)SpotAdd(ControlAdd(new TextControl("line1", "Line 1", TheAddress.line1)));
            txtLine2 = (TextControl)SpotAdd(ControlAdd(new TextControl("line2", "Line 2", TheAddress.line2)));
            txtLine3 = (TextControl)SpotAdd(ControlAdd(new TextControl("line3", "Line 3", TheAddress.line3)));
            txtCity = (TextControl)SpotAdd(ControlAdd(new TextControl("adrcity", "City", TheAddress.adrcity)));
            cboState = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("adrstate", "State", TheAddress.adrstate, GetStates())));
            txtZip = (TextControl)SpotAdd(ControlAdd(new TextControl("adrzip", "Zip", TheAddress.adrzip)));
            cboCountry = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("adrcountry", "Country", TheAddress.adrcountry, GetCountries())));
            aViewCompany = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewCompany", "View Company", "ViewCompany()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            return "Address Entry";
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"company_address_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            chkDefBill.Render(x, sb, screenHandle, viewHandle, session, page);
            chkDefShip.Render(x, sb, screenHandle, viewHandle, session, page);
            aViewCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescr.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLine1.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLine2.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLine3.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCity.Render(x, sb, screenHandle, viewHandle, session, page);
            cboState.Render(x, sb, screenHandle, viewHandle, session, page);
            txtZip.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCountry.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
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
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, AddrDiv);
            RunDivToBottom(sb, AddrDiv);
            sb.AppendLine("$('#" + AddrDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + AddrDiv + "').position().left - 20);");
            sb.AppendLine(chkDefBill.Select + ".css('top', 2);");
            sb.AppendLine(chkDefBill.Select + ".css('left', 2);");
            sb.AppendLine(chkDefShip.Select + ".css('top', 2);");
            sb.AppendLine(chkDefShip.PlaceRight(chkDefBill));
            sb.AppendLine(aViewCompany.Select + ".css('top', 2);");
            sb.AppendLine(aViewCompany.PlaceRight(chkDefShip, false, 10, 0));
            sb.AppendLine(txtDescr.Select + ".css('left', 2);");
            sb.AppendLine(txtDescr.PlaceBelow(chkDefBill));
            sb.AppendLine(txtLine1.Select + ".css('left', 2);");
            sb.AppendLine(txtLine1.PlaceBelow(txtDescr));
            sb.AppendLine(txtLine2.Select + ".css('left', 2);");
            sb.AppendLine(txtLine2.PlaceBelow(txtLine1));
            sb.AppendLine(txtLine3.Select + ".css('left', 2);");
            sb.AppendLine(txtLine3.PlaceBelow(txtLine2));
            sb.AppendLine(txtCity.Select + ".css('left', 2);");
            sb.AppendLine(txtCity.PlaceBelow(txtLine3));
            sb.AppendLine(cboState.Select + ".css('left', 2);");
            sb.AppendLine(cboState.PlaceBelow(txtCity));
            sb.AppendLine(txtZip.PlaceRight(cboState));
            sb.AppendLine(txtZip.PlaceBelow(txtCity));
            sb.AppendLine(cboCountry.Select + ".css('left', 2);");
            sb.AppendLine(cboCountry.PlaceBelow(cboState));
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
            chkDefBill.TextFontSize = FontSize.Small;
            chkDefShip.TextFontSize = FontSize.Small;
            txtDescr.TextFontSize = FontSize.Small;
            txtDescr.CaptionFontSize = FontSize.Small;
            txtDescr.FixedWidth = 590;
            txtLine1.TextFontSize = FontSize.Small;
            txtLine1.CaptionFontSize = FontSize.Small;
            txtLine1.FixedWidth = 590;
            txtLine2.TextFontSize = FontSize.Small;
            txtLine2.CaptionFontSize = FontSize.Small;
            txtLine2.FixedWidth = 590;
            txtLine3.TextFontSize = FontSize.Small;
            txtLine3.CaptionFontSize = FontSize.Small;
            txtLine3.FixedWidth = 590;
            txtCity.TextFontSize = FontSize.Small;
            txtCity.CaptionFontSize = FontSize.Small;
            txtCity.FixedWidth = 590;
            cboState.TextFontSize = FontSize.Small;
            cboState.CaptionFontSize = FontSize.Small;
            cboState.FixedWidth = 300;
            txtZip.TextFontSize = FontSize.Small;
            txtZip.CaptionFontSize = FontSize.Small;
            txtZip.FixedWidth = 285;
            cboCountry.TextFontSize = FontSize.Small;
            cboCountry.CaptionFontSize = FontSize.Small;
            cboCountry.FixedWidth = 594;
        }
        private ArrayList GetStates()
        {
            ArrayList a = new ArrayList();
            string[] str = Tools.Strings.Split("AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY", "|");
            foreach (string s in str)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                a.Add(s);
            }
            return a;
        }
        private ArrayList GetCountries()
        {
            ArrayList a = new ArrayList();
            string[] str = Tools.Strings.Split("United States|Canada|Afghanistan|Albania|Algeria|Andorra|Angola|Antigua|Argentina|Armenia|Australia|Austria|Azerbaijan|Bahamas|Bahrain|Bangladesh|Barbados|Belarus|Belgium|Belize|Benin|Bhutan|Bolivia|Bosnia|Botswana|Brazil|Brunei|Bulgaria|Burkina Faso|Burundi|Cambodia|Cameroon|Canada|Cape Verde|Chad|Chile|China|Colombia|Comoros|Congo|Costa Rica|Côte dIvoire|Croatia|Cuba|Cyprus|Czech Republic|Denmark|Djibouti|Dominica|Dominican Republic|East Timor|Ecuador|Egypt|El Salvador|Equatorial Guinea|Eritrea|Estonia|Ethiopia|Fiji|Finland|France|Gabon|Gambia, The|Georgia|Germany|Ghana|Greece|Grenada|Guatemala|Guinea|GuineaBissau|Guyana|Haiti|Honduras|Hungary|Iceland|India|Indonesia|Iran|Iraq|Ireland|Israel|Italy|Jamaica|Japan|Jordan|Kazakhstan|Kenya|Kiribati|Korea, North|Korea, South|Kuwait|Kyrgyzstan|Laos|Latvia|Lebanon|Lesotho|Liberia|Libya|Liechtenstein|Lithuania|Luxembourg|Macedonia|Madagascar|Malawi|Malaysia|Maldives|Mali|Malta|Marshall Islands|Mauritania|Mauritius|Mexico|Micronesia|Moldova|Monaco|Mongolia|Montenegro|Morocco|Mozambique|Myanmar Burma|Namibia|Nauru|Nepal|Netherlands|New Zealand|Nicaragua|Niger|Nigeria|Norway|Oman|Pakistan|Palau|Panama|Papua New Guinea|Paraguay|Peru|Philippines|Poland|Portugal|Qatar|Romania|Russia|Rwanda|Saint Kitts|Saint Lucia|Saint Vincent|Samoa|San Marino|Sao Tome|Saudi Arabia|Senegal|Serbia|Seychelles|Sierra Leone|Singapore|Slovakia|Slovenia|Solomon Islands|Somalia|South Africa|Spain|Sri Lanka|Sudan|Suriname|Swaziland|Sweden|Switzerland|Syria|Taiwan|Tajikistan|Tanzania|Thailand|Togo|Tonga|Trinidad and Tobago|Tunisia|Turkey|Turkmenistan|Tuvalu|Uganda|Ukraine|United Arab Emirates|United Kingdom|United States|Uruguay|Uzbekistan|Vanuatu|Vatican City|Venezuela|Vietnam|Western Sahara|Yemen|Zambia|Zimbabwe", "|");
            foreach (string s in str)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                a.Add(s);
            }
            return a;
        }
        private void ViewCompany(ContextRz x)
        {
            company c = company.GetById(x, TheAddress.base_company_uid);
            if (c == null)
                return;
            RzWeb.Company q = new RzWeb.Company((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}


