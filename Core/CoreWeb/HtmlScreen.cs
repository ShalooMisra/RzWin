using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWeb
{
    public class HtmlScreen : Screen
    {
        String TitleString;
        String Html;

        public HtmlScreen(String title, String html)
        {
            TitleString = title;
            Html = html;
        }

        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("<div style=\"width: 100%; height: 100%; overflow: scroll; margin: 4px;\">");
            sb.Append(Html);
            sb.Append("</div>");
        }

        public override string Title(Core.Context x)
        {
            //return base.Title(x);
            return TitleString;
        }
    }
}
