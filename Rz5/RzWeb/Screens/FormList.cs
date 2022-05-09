using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using Rz5.Web;
using Rz5;
using System.Web;
using Core;

namespace RzWeb.Screens
{
    public class FormList : RzScreen
    {
        public FormList(ContextRz context) : base(context)
        {

        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            ContextRz xrz = (ContextRz)x;

            sb.AppendLine("<div id=\"listDiv\" style=\"position: absolute; margin: 8px; padding: 8px\">");
            foreach (printheader p in xrz.QtC("printheader", "select * from printheader order by printname"))
            {
                sb.AppendLine("<div><a href=\"#\" onclick=\"" + ActionScript("'show_form'", "'" + p.unique_id + "'") + "\">" + HttpUtility.HtmlEncode(p.printname) + "</a></div>");
            }
            sb.AppendLine("</div>");
        }
        public override String Title(Context x)
        {
            return "Form List";
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "listDiv");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "show_form":
                    ShowForm(x, args);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        void ShowForm(Context x, SpotActArgs args)
        {
            printheader p = printheader.GetById(x, args.ActionParams);
            ((LeaderWebUser)x.Leader).ScreenShowNewWindow(x, new FormDesigner((ContextRz)x, p, args.SourcePage));
        }
    }
}
