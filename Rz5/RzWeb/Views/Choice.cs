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
    public class Choice : _Item
    {
        public n_choice TheChoice
        {
            get
            {
                return (n_choice)Item;
            }
        }
        TextControl txtChoice;
        Int64Control txtOrder;
        String ChoiceDiv
        {
            get
            {
                return "choice_" + Uid;
            }
        }

        public Choice(ContextRz x, n_choice c)
            : base(x, c)
        {
            txtChoice = (TextControl)SpotAdd(ControlAdd(new TextControl("name", "Choice", TheChoice.name)));
            txtOrder = (Int64Control)SpotAdd(ControlAdd(new Int64Control("the_n_choices_order", "Order", TheChoice.the_n_choices_order)));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Choice";
            if (TheChoice != null)
                s = "Choice: " + TheChoice.name;
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"choice_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            txtChoice.Render(x, sb, screenHandle, viewHandle, session, page);
            txtOrder.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {

        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, ChoiceDiv);
            RunDivToBottom(sb, ChoiceDiv);
            sb.AppendLine(txtChoice.Select + ".css('top', 10);");
            sb.AppendLine(txtChoice.Select + ".css('left', 5);");
            sb.AppendLine(txtOrder.Select + ".css('left', 5);");
            sb.AppendLine(txtOrder.PlaceBelow(txtChoice));
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            txtChoice.FixedWidth = 665;
            txtOrder.FixedWidth = 665;
        }
    }
}
