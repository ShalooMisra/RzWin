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
    public class ContactNote : _Item
    {
        public contactnote TheNote
        {
            get
            {
                return (contactnote)Item;
            }
        }
        CompanyContactControl xCompany;
        DateControl dtDate;
        TextAreaControl txtNote;
        AnchorControl aViewCompany;
        ViewHandle TheView;
        String NoteDiv
        {
            get
            {
                return "contact_note_" + Uid;
            }
        }

        public ContactNote(ContextRz x, contactnote c)
            : base(x, c)
        {
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("base_company_uid|companyname|base_companycontact_uid|contactname", "Company", TheNote.base_company_uid, TheNote.companyname, "base_company_uid", "companyname", TheNote.base_companycontact_uid, TheNote.contactname, "base_companycontact_uid", "contactname")));
            dtDate = (DateControl)SpotAdd(ControlAdd(new DateControl("notedate", "Date", TheNote.notedate)));
            txtNote = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("notetext", "Note", TheNote.notetext)));
            aViewCompany = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewCompany", "View Company", "ViewCompany()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Contact Note";
            if (TheNote != null)
            {
                if (Tools.Strings.StrExt(TheNote.companyname))
                    s = "Note [" + TheNote.companyname + "]";
            }
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"contact_note_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            xCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            dtDate.Render(x, sb, screenHandle, viewHandle, session, page);
            txtNote.Render(x, sb, screenHandle, viewHandle, session, page);
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
            PlaceDivBelowMenu(sb, NoteDiv);
            RunDivToBottom(sb, NoteDiv);
            sb.AppendLine("$('#" + NoteDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + NoteDiv + "').position().left - 20);");
            sb.AppendLine(xCompany.Select + ".css('top', 10);");
            sb.AppendLine(xCompany.Select + ".css('left', 10);");
            sb.AppendLine(xCompany.Select + ".css('height', 100);");
            sb.AppendLine(dtDate.Select + ".css('left', 10);");
            sb.AppendLine(dtDate.PlaceBelow(xCompany, false, 10, 0));
            sb.AppendLine(txtNote.Select + ".css('left', 10);");
            sb.AppendLine(txtNote.PlaceBelow(dtDate, false, 10, 0));
            sb.AppendLine(aViewCompany.Select + ".css('top', 10);");
            sb.AppendLine(aViewCompany.Select + ".css('left', 250);");
            sb.AppendLine("$('#" + txtNote.ControlId + "').css('width', $('#" + NoteDiv + "').width() - " + txtNote.Select + ".position().left - 10);");
            sb.AppendLine("$('#" + txtNote.ControlId + "').css('height', $('#" + NoteDiv + "').height() - " + txtNote.Select + ".position().top - 23);");
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
        }
        private void ViewCompany(ContextRz x)
        {
            company c = company.GetById(x, TheNote.base_company_uid);
            if (c == null)
                return;
            RzWeb.Company q = new RzWeb.Company((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}