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
    public class CallLog : _Item
    {
        public calllog TheCall
        {
            get
            {
                return (calllog)Item;
            }
        }
        RzWeb.ChoicesControl cboResult;
        RzWeb.ChoicesControl cboResponse;
        TextAreaControl txtNotes;
        AnchorControl aViewCompany;
        ViewHandle TheView;
        String CallDiv
        {
            get
            {
                return "call_log_" + Uid;
            }
        }
        bool FromContact = false;

        public CallLog(ContextRz x, calllog c, bool from_contact = false)
            : base(x, c)
        {
            FromContact = from_contact;
            cboResult = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("callresult", "Call Result", TheCall.callresult, GetChoiceList(x, "callresult"), "", "callresult")));
            cboResponse = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("responsetype", "Response Type", TheCall.responsetype, GetChoiceList(x, "responsetype"), "", "responsetype")));
            txtNotes = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("callnotes", "Notes", TheCall.callnotes)));
            string s = "View Company";
            if (from_contact)
                s = "View Contact";
            aViewCompany = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewCompany", s, "ViewCompany()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            return "Call Log";
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"call_log_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            cboResult.Render(x, sb, screenHandle, viewHandle, session, page);
            cboResponse.Render(x, sb, screenHandle, viewHandle, session, page);
            txtNotes.Render(x, sb, screenHandle, viewHandle, session, page);
            aViewCompany.Render(x, sb, screenHandle, viewHandle, session, page);
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
            PlaceDivBelowMenu(sb, CallDiv);
            RunDivToBottom(sb, CallDiv);
            sb.AppendLine("$('#" + CallDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + CallDiv + "').position().left - 20);");
            sb.AppendLine(cboResult.Select + ".css('top', 10);");
            sb.AppendLine(cboResult.Select + ".css('left', 10);");
            sb.AppendLine(aViewCompany.Select + ".css('top', 10);");
            sb.AppendLine(aViewCompany.PlaceRight(cboResult, false, 0, 114));
            sb.AppendLine(cboResponse.Select + ".css('left', 10);");
            sb.AppendLine(cboResponse.PlaceBelow(cboResult, false, 10, 0));
            sb.AppendLine(txtNotes.Select + ".css('left', 10);");
            sb.AppendLine(txtNotes.PlaceBelow(cboResponse, false, 10, 0));
            sb.AppendLine("$('#" + txtNotes.ControlId + "').css('width', $('#" + CallDiv + "').width() - " + txtNotes.Select + ".position().left - 10);");
            sb.AppendLine("$('#" + txtNotes.ControlId + "').css('height', $('#" + CallDiv + "').height() - " + txtNotes.Select + ".position().top - 23);");
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
            cboResult.FixedWidth = 580;
            cboResponse.FixedWidth = 580;
        }
        private void ViewCompany(ContextRz x)
        {
            if (FromContact)
                ShowContact(x);
            else
                ShowCompany(x);
        }
        private void ShowCompany(ContextRz x)
        {
            company c = company.GetById(x, TheCall.base_company_uid);
            if (c == null)
                return;
            RzWeb.Company q = new RzWeb.Company((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void ShowContact(ContextRz x)
        {
            companycontact c = companycontact.GetById(x, TheCall.base_companycontact_uid);
            if (c == null)
                return;
            RzWeb.CompanyContact q = new RzWeb.CompanyContact((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}