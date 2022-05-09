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
    public class ShippingAccount : _Item
    {
        public shippingaccount TheAccount
        {
            get
            {
                return (shippingaccount)Item;
            }
        }
        TextControl txtDescr;
        TextControl txtNumber;
        AnchorControl aViewCompany;
        ViewHandle TheView;
        String AccntDiv
        {
            get
            {
                return "company_account_" + Uid;
            }
        }

        public ShippingAccount(ContextRz x, shippingaccount c)
            : base(x, c)
        {
            txtDescr = (TextControl)SpotAdd(ControlAdd(new TextControl("description", "Description", TheAccount.description)));
            txtNumber = (TextControl)SpotAdd(ControlAdd(new TextControl("accountnumber", "Number", TheAccount.accountnumber)));
            aViewCompany = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewCompany", "View Company", "ViewCompany()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            return "Shipping Account";
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"company_account_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            txtDescr.Render(x, sb, screenHandle, viewHandle, session, page);
            txtNumber.Render(x, sb, screenHandle, viewHandle, session, page);
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
            PlaceDivBelowMenu(sb, AccntDiv);
            RunDivToBottom(sb, AccntDiv);
            sb.AppendLine("$('#" + AccntDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + AccntDiv + "').position().left - 20);");
            sb.AppendLine(txtDescr.Select + ".css('top', 2);");
            sb.AppendLine(txtDescr.Select + ".css('left', 2);");
            sb.AppendLine(txtNumber.Select + ".css('left', 2);");
            sb.AppendLine(txtNumber.PlaceBelow(txtDescr));
            sb.AppendLine(aViewCompany.Select + ".css('left', 2);");
            sb.AppendLine(aViewCompany.PlaceRight(txtDescr, false, 0, 87));
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
            txtDescr.TextFontSize = FontSize.Small;
            txtDescr.CaptionFontSize = FontSize.Small;
            txtDescr.FixedWidth = 590;
            txtNumber.TextFontSize = FontSize.Small;
            txtNumber.CaptionFontSize = FontSize.Small;
            txtNumber.FixedWidth = 590;
        }
        private void ViewCompany(ContextRz x)
        {
            company c = company.GetById(x, TheAccount.base_company_uid);
            if (c == null)
                return;
            RzWeb.Company q = new RzWeb.Company((ContextRz)x, c);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}
