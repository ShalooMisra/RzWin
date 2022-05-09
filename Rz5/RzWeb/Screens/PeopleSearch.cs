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
using NewMethodWeb;
using Rz5;
using Rz5.Web;
using System.Web.UI;
using System.Collections;

namespace RzWeb
{
    public class PeopleSearch : RzScreen
    {
        ListViewSpotPeopleSearch lv;
        TextControl txtSearch;
        TextControl txtPF;
        TextControl txtEmail;
        ComboBoxControl cboSource;
        AgentControl xAgent;
        BoolControl chkUnlimited;
        RadioButtonControl xOptions;

        public PeopleSearch(ContextRz x)
            : base(x)
        {
            txtSearch = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_searchterm", "Company Name", "")));
            txtPF = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_pf", "Phone Number", "")));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_email", "Email Address", "")));
            xOptions = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("ctl_options", "Search For:", "company", GetTypeOptions())));
            xAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("ctl_agent", "Agent", "", "", "agent_id", "agent_name", GetAgentArray(x))));
            cboSource = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("ctl_source", "Source", "", GetSourceList(x))));
            chkUnlimited = (BoolControl)SpotAdd(ControlAdd(new BoolControl("ctl_unlimited", "Unlimited Results", false)));
            lv = (ListViewSpotPeopleSearch)SpotAdd(new ListViewSpotPeopleSearch());
            lv.LeftAbs = 285;
            lv.WidthAbs = 10;
            lv.TopAbs = 75;
            lv.TheArgs = x.Sys.TheCompanyLogic.PeopleSearchCompanyArgsGet(x, new PeopleSearchParameters(true));
            lv.TheArgs.TheLimit = 200;
            lv.TheArgs.HeaderOnly = true;
            lv.TheArgs.AddAllow = false;
            lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
            lv.ExtraStyle = "; font-size: small";
            if (lv.CurrentTemplate == null)
                lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
            lv.CurrentTemplate.GatherColumns(x);
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.ItemDoubleClicked += new ItemDoubleClickHandler(lv_ItemDoubleClicked);
            AdjustControls();
            txtSearch.OnEnterClick = "cmdSearch";
            if (!((LeaderWebUserRz)x.TheLeaderRz).DemoInfoCleared(x))
                RunSearch(x);
        }
        public override String Title(Context x)
        {
            return "People Search";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);            
            sb.AppendLine("<div id=\"peoplesearch_options_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 230px;\">");                        
            xOptions.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSearch.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPF.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            cboSource.Render(x, sb, screenHandle, viewHandle, session, page);
            xAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            chkUnlimited.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<center><input id=\"cmdClear\" type=\"button\" value=\"  Clear  \" onclick=\"" + ActionScript("'clear_screen'") + "\">&nbsp;&nbsp;&nbsp;<input id=\"cmdSearch\" type=\"button\" value=\"Search\" onclick=\"Spin('" + Spot.DivIdConvert(lv.Uid) + "');PeopleSearch();\"></center>");
            Buttonize(viewHandle, "cmdSearch", "peoplemenu.png");
            Buttonize(viewHandle, "cmdClear", "clear.png");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, OptionsDiv);
            RunDivToBottom(sb, OptionsDiv);                     
            PlaceBelowMenu(lv);
            PlaceDivRight(sb, lv.DivId, OptionsDiv);
            lv.RunToRight(sb);
            lv.RunToBottom(sb);
            sb.AppendLine(xOptions.Select + ".css('left', 5);");
            sb.AppendLine(xOptions.Select + ".css('top', 5);");
            sb.AppendLine(txtSearch.Select + ".css('left', 5);");
            sb.AppendLine(txtSearch.PlaceBelow(xOptions, false, 0, 5));
            sb.AppendLine(txtPF.Select + ".css('left', 5);");
            sb.AppendLine(txtPF.PlaceBelow(txtSearch, false, 0, 0));
            sb.AppendLine(txtEmail.Select + ".css('left', 5);");
            sb.AppendLine(txtEmail.PlaceBelow(txtPF, false, 0, 0));
            sb.AppendLine(cboSource.Select + ".css('left', 5);");
            sb.AppendLine(cboSource.PlaceBelow(txtEmail, false, 0, 0));
            sb.AppendLine(xAgent.Select + ".css('left', 5);");
            sb.AppendLine(xAgent.PlaceBelow(cboSource, false, 0, 0));
            sb.AppendLine(chkUnlimited.Select + ".css('left', 5);");
            sb.AppendLine(chkUnlimited.PlaceBelow(xAgent, false, 0, 0));
            sb.AppendLine("$('#cmdSearch').css('top', 285);");
            sb.AppendLine("$('#cmdClear').css('top', 285);");
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function PeopleSearch() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'search'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#txtSearch').focus();");
        }
        private String OptionsDiv
        {
            get
            {
                return "peoplesearch_options_" + Uid;
            }
        }
        private ArrayList GetSourceList(Context x)
        {
            return x.SelectScalarArray("select distinct(source) from company order by source");
        }
        private void AdjustControls()
        {
            txtSearch.CaptionBold = true;
            txtSearch.CaptionFontSize = FontSize.Small;
            txtPF.CaptionFontSize = FontSize.Small;
            txtEmail.CaptionFontSize = FontSize.Small;
            cboSource.CaptionFontSize = FontSize.Small;
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
            }
        }
        private void RunSearch(ContextRz x)
        {
            txtSearch.Value = "EX";
            txtSearch.Change();
            PeopleSearchParameters p = new PeopleSearchParameters();
            p.GeneralTerm = "EX";
            lv.ClassId = "company";
            if (x.xUserRz.GetSetting_Boolean(x, "restricted_user"))
                GetAgentNames(x, p);
            lv.TheArgs = x.TheSysRz.TheCompanyLogic.PeopleSearchCompanyArgsGet(x, p);
            lv.TheArgs.TheLimit = 200;
            lv.TheArgs.AddAllow = false;
            if (lv.CurrentTemplate == null || !Tools.Strings.StrCmp(lv.CurrentTemplate.template_name, lv.TheArgs.TheTemplate))
            {
                lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
                if (lv.CurrentTemplate == null)
                    lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
                lv.CurrentTemplate.GatherColumns(x);
            }
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
            lv.Change();
        }
        private void DoSearch(ContextRz x, string s)
        {
            Dictionary<string, string> d = ParseValueString(s);
            PeopleSearchParameters p = new PeopleSearchParameters();
            string ss = "";
            d.TryGetValue("ctl_searchterm", out ss);
            p.GeneralTerm = ss;
            ss = "";
            d.TryGetValue("agent_name", out ss);
            p.AgentNamePipeDelimited = ss;
            ss = "";
            d.TryGetValue("ctl_pf", out ss);
            p.Phone = ss;
            ss = "";
            d.TryGetValue("ctl_email", out ss);
            p.Email = ss;
            ss = "";
            d.TryGetValue("ctl_source", out ss);
            p.SourceName = ss;
            ss = "";
            d.TryGetValue("ctl_options", out ss);
            if (x.xUserRz.GetSetting_Boolean(x, "restricted_user"))
                GetAgentNames(x, p);            
            if (Tools.Strings.StrCmp(ss, "Company"))
            {
                lv.ClassId = "company";
                lv.TheArgs = x.TheSysRz.TheCompanyLogic.PeopleSearchCompanyArgsGet(x, p);
            }
            else
            {
                lv.ClassId = "companycontact";
                lv.TheArgs = x.TheSysRz.TheCompanyLogic.PeopleSearchContactArgsGet(x, p);
            }
            ss = "";
            d.TryGetValue("ctl_unlimited", out ss);
            if (Tools.Strings.StrCmp(ss, "Unlimited Results"))
                lv.TheArgs.TheLimit = -1;
            else
                lv.TheArgs.TheLimit = 200;
            lv.TheArgs.AddAllow = false;
            if (lv.CurrentTemplate == null || !Tools.Strings.StrCmp(lv.CurrentTemplate.template_name, lv.TheArgs.TheTemplate))  //prevents the template from getting brought from the db on every search
            {
                lv.CurrentTemplate = n_template.GetByName(x, lv.TheArgs.TheTemplate);
                if (lv.CurrentTemplate == null)
                    lv.CurrentTemplate = n_template.Create(x, lv.TheArgs.TheClass, lv.TheArgs.TheTemplate);
                lv.CurrentTemplate.GatherColumns(x);
            }
            lv.ColSource = new ColumnSourceTemplate(lv.CurrentTemplate);
            lv.RowSource = new RowSourceTable(x.Select(lv.TheArgs.RenderSql((ContextRz)x, lv.CurrentTemplate)));
            lv.Change();
        }
        private void GetAgentNames(ContextRz x, PeopleSearchParameters p)
        {
            string a = GetRestrictedUserAgents(x);
            if (Tools.Strings.StrExt(p.AgentNamePipeDelimited))
            {
                if (Tools.Strings.StrCmp(p.AgentNamePipeDelimited, x.xUserRz.name))
                    return;
                string[] str = Tools.Strings.Split(a, "|");
                foreach (string s in str)
                {
                    if (Tools.Strings.StrCmp(p.AgentNamePipeDelimited, s))
                        return;
                }
                p.AgentNamePipeDelimited = a;
                p.IncludeBlankAgents = true;
            }
            else
            {
                p.AgentNamePipeDelimited = a;
                p.IncludeBlankAgents = true;
            }
                
        }
        private string GetRestrictedUserAgents(ContextRz x)
        {
            string s = "";
            if (x == null)
                return s;
            s += x.xUserRz.name + "|";
            s += "unclaimed|";
            s += "house|";
            s += "bad record|";
            ArrayList a = x.SelectScalarArray("select the_n_team_uid from n_member where the_n_user_uid = '" + x.xUserRz.unique_id + "'");
            string inn = Tools.Data.GetIn(a);
            if (!Tools.Strings.StrExt(inn))
                return s;
            a = x.SelectScalarArray("select distinct(the_n_user_uid) from n_member where the_n_team_uid in (" + inn + ") and the_n_user_uid != '" + x.xUserRz.unique_id + "'");
            inn = "";
            inn = Tools.Data.GetIn(a);
            if (!Tools.Strings.StrExt(inn))
                return s;
            a = x.SelectScalarArray("select distinct(name) from n_user where unique_id in (" + inn + ")");
            foreach (string ss in a)
            {
                if (!Tools.Strings.StrExt(ss))
                    continue;
                s += ss + "|";
            }
            return s;
        }
        private void lv_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            company c = null;
            try { c = (company)item; }
            catch { }
            if (c == null)
                return;
            if (Tools.Strings.StrExt(c.base_mc_user_uid))
            {
                if (!((Rz5.PermitLogic)((ContextRz)x).xSys.ThePermitLogic).IsHouseAccount(c.agentname))
                {
                    if (!((ContextRz)x).xUserRz.CheckPermit((ContextNM)x, Permissions.ThePermits.ViewAllCompanies) && !Tools.Strings.StrCmp(((ContextRz)x).xUserRz.unique_id, c.base_mc_user_uid))
                    {
                        x.TheLeader.ShowNoRight();
                        return;
                    }
                }
            }
            x.Show(new ShowArgs(x, ViewType.SingleItem, item));
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
        private RadioControlConfig GetTypeOptions()
        {
            RadioControlConfig c = new RadioControlConfig();
            //All
            RadioControlConfig r = new RadioControlConfig();
            r.Caption = "Company";
            r.Value = "company";            
            c.AllOptions.Add(r);
            r = new RadioControlConfig();
            r.Caption = "Contact";
            r.Value = "contact";
            c.AllOptions.Add(r);
            return c;
        }
        private void ClearScreen(ContextRz x)
        {
            txtSearch.ValueSet("");
            txtPF.ValueSet("");
            txtEmail.ValueSet("");
            cboSource.ValueSet("");
            xAgent.AgentID = "";
            xAgent.AgentName = "";
            xOptions.ValueSet("company");
            chkUnlimited.ValueSet(false);
            txtSearch.Change();
            txtPF.Change();
            txtEmail.Change();
            cboSource.Change();
            xAgent.Change();
            xOptions.Change();
            chkUnlimited.Change();
        }
    }
    public class ListViewSpotPeopleSearch : ListViewSpotRz
    {
        public ListViewSpotPeopleSearch()
            : base("company")
        {
        }
    }
}