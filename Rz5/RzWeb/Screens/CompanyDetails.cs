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
    public class CompanyDetails : RzScreen
    {
        String CompDiv
        {
            get
            {
                return "compdet_" + Uid;
            }
        }
        TextControl txtCompany;
        TextControl txtAdr1;
        TextControl txtAdr2;
        TextControl txtCity;
        TextControl txtState;
        TextControl txtZip;
        ComboBoxControl cboCountry;
        TextControl txtPhone;
        TextControl txtFax;
        TextControl txtUPS;
        TextControl txtFedEx;
        TextControl txtDHL;

        public CompanyDetails(ContextRz x)
            : base(x)
        {            
            txtCompany = (TextControl)SpotAdd(ControlAdd(new TextControl("txtCompany", "Company Name", OwnerSettings.GetValue(x, OwnerSettingField.owner_companyname))));
            txtAdr1 = (TextControl)SpotAdd(ControlAdd(new TextControl("txtAdr1", "Address Line 1", OwnerSettings.GetValue(x, OwnerSettingField.owner_address1))));
            txtAdr2 = (TextControl)SpotAdd(ControlAdd(new TextControl("txtAdr2", "Address Line 2", OwnerSettings.GetValue(x, OwnerSettingField.owner_address2))));
            txtCity = (TextControl)SpotAdd(ControlAdd(new TextControl("txtCity", "City", OwnerSettings.GetValue(x, OwnerSettingField.owner_city))));
            txtState = (TextControl)SpotAdd(ControlAdd(new TextControl("txtState", "State", OwnerSettings.GetValue(x, OwnerSettingField.owner_state))));
            txtZip = (TextControl)SpotAdd(ControlAdd(new TextControl("txtZip", "Zip", OwnerSettings.GetValue(x, OwnerSettingField.owner_zip))));
            cboCountry = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboCountry", "Country", OwnerSettings.GetValue(x, OwnerSettingField.owner_country), GetCountries())));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("txtPhone", "Phone Number", OwnerSettings.GetValue(x, OwnerSettingField.owner_phone))));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("txtFax", "Fax Number", OwnerSettings.GetValue(x, OwnerSettingField.owner_fax))));
            txtUPS = (TextControl)SpotAdd(ControlAdd(new TextControl("txtUPS", "UPS Account Number", x.TheLogicRz.InternalUPS)));
            txtFedEx = (TextControl)SpotAdd(ControlAdd(new TextControl("txtFedEx", "FedEx Account Number", x.TheLogicRz.InternalFedex)));
            txtDHL = (TextControl)SpotAdd(ControlAdd(new TextControl("txtDHL", "DHL Account Number", x.TheLogicRz.InternalDHL)));            
            AdjustControls();
        }
        //Override Functions
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {         
                case "save":
                    SaveSettings((ContextRz)x, args.ActionParams);
                    break;
                default:
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"compdet_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 175px;\">");
            txtCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAdr1.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAdr2.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCity.Render(x, sb, screenHandle, viewHandle, session, page);
            txtState.Render(x, sb, screenHandle, viewHandle, session, page);
            txtZip.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCountry.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtUPS.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFedEx.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDHL.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("   <div id=\"cmdsave_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            sb.AppendLine("      <input id=\"cmdSave\" type=\"button\" value=\"Save\" onclick=\"Save()\">");
            sb.AppendLine("   </div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        public override String Title(Context x)
        {
            return "Company Details";
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, CompDiv);
            RunDivToBottom(sb, CompDiv);
            RunDivToRight(sb, CompDiv);
            sb.AppendLine(txtCompany.Select + ".css('top', 10);");
            sb.AppendLine(txtCompany.Select + ".css('left', 10);");
            sb.AppendLine(txtAdr1.Select + ".css('left', 10);");
            sb.AppendLine(txtAdr1.PlaceBelow(txtCompany));
            sb.AppendLine(txtAdr2.Select + ".css('left', 10);");
            sb.AppendLine(txtAdr2.PlaceBelow(txtAdr1));
            sb.AppendLine(txtCity.Select + ".css('left', 10);");
            sb.AppendLine(txtCity.PlaceBelow(txtAdr2));
            sb.AppendLine(txtState.PlaceRight(txtCity));
            sb.AppendLine(txtState.PlaceBelow(txtAdr2));
            sb.AppendLine(txtZip.PlaceRight(txtState));
            sb.AppendLine(txtZip.PlaceBelow(txtAdr2));
            sb.AppendLine(cboCountry.Select + ".css('left', 10);");
            sb.AppendLine(cboCountry.PlaceBelow(txtCity));
            sb.AppendLine(txtPhone.Select + ".css('left', 10);");
            sb.AppendLine(txtPhone.PlaceBelow(cboCountry));
            sb.AppendLine(txtFax.PlaceRight(txtPhone));
            sb.AppendLine(txtFax.PlaceBelow(cboCountry));
            sb.AppendLine(txtUPS.Select + ".css('left', 10);");
            sb.AppendLine(txtUPS.PlaceBelow(txtPhone));
            sb.AppendLine(txtFedEx.PlaceRight(txtUPS));
            sb.AppendLine(txtFedEx.PlaceBelow(txtPhone));
            sb.AppendLine(txtDHL.PlaceRight(txtFedEx));
            sb.AppendLine(txtDHL.PlaceBelow(txtPhone));
            sb.AppendLine("$('#cmdsave_" + Uid + "').css('top', " + txtUPS.Select + ".position().top + " + txtUPS.Select + ".height() + 7);");
            sb.AppendLine("$('#cmdsave_" + Uid + "').css('left', 10);");
            sb.AppendLine("$('#cmdSave').css('width', 625);");
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function Save() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#cmdSave').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
        }
        private void AdjustControls()
        {
            txtCompany.FixedWidth = 620;
            txtAdr1.FixedWidth = 620;
            txtAdr2.FixedWidth = 620;
            cboCountry.FixedWidth = 625;
            txtPhone.FixedWidth = 304;
            txtFax.FixedWidth = 304;
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
        private void SaveSettings(ContextRz x, string s)
        {
            Dictionary<string, string> d = ParseValueString(s);
            if (d == null)
                return;
            string ss = "";
            d.TryGetValue("txtCompany", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_companyname, ss);
            ss = "";
            d.TryGetValue("txtAdr1", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_address1, ss);
            ss = "";
            d.TryGetValue("txtAdr2", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_address2, ss);
            ss = "";
            d.TryGetValue("txtCity", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_city, ss);
            ss = "";
            d.TryGetValue("txtState", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_state, ss);
            ss = "";
            d.TryGetValue("txtZip", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_zip, ss);
            ss = "";
            d.TryGetValue("cboCountry", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_country, ss);
            ss = "";
            d.TryGetValue("txtPhone", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_phone, ss);
            ss = "";
            d.TryGetValue("txtFax", out ss);
            OwnerSettings.SetValue(x, OwnerSettingField.owner_fax, ss);
            ss = "";
            d.TryGetValue("txtUPS", out ss);
            x.TheLogicRz.SetInternalUPS(x, ss);
            ss = "";
            d.TryGetValue("txtFedEx", out ss);
            x.TheLogicRz.SetInternalFedex(x, ss);
            ss = "";
            d.TryGetValue("txtDHL", out ss);
            x.TheLogicRz.SetInternalDHL(x, ss);
        }
    }
}
