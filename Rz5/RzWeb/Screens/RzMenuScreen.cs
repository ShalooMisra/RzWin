using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz5;
using Rz5.Web;
using Core;
using System.Web;

namespace RzWeb.Screens
{
    public class RzMenuScreen : RzScreen
    {
        public RzMenuScreen(ContextRz context) : base(context)
        {
            InitSections(context);
        }

        protected List<MenuSection> Sections = new List<MenuSection>();
        protected virtual void InitSections(ContextRz context)
        {
        }

        public override void RenderContents(Context x, StringBuilder sb, CoreWeb.Screen screenHandle, CoreWeb.ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            Queue<MenuSection> sq = new Queue<MenuSection>(Sections);
            List<MenuSection> div1 = new List<MenuSection>();
            List<MenuSection> div2 = new List<MenuSection>();
            List<MenuSection> div3 = new List<MenuSection>();

            while (sq.Count > 0)
            {
                div1.Add(sq.Dequeue());
                if (sq.Count == 0)
                    continue;
                
                div2.Add(sq.Dequeue());
                if (sq.Count == 0)
                    continue;
                
                div3.Add(sq.Dequeue());
                if (sq.Count == 0)
                    continue;
            }

            sb.AppendLine("<div id=\"menuDiv\" style=\"position: absolute; margin: 4px; padding: 4px\">");
            sb.AppendLine("<center><table border=\"0\"><tr><td valign=\"top\">");
            RenderSections(sb, div1);
            sb.AppendLine("</td><td valign=\"top\">");
            RenderSections(sb, div2);
            sb.AppendLine("</td><td valign=\"top\">");
            RenderSections(sb, div3);
            sb.AppendLine("</td></tr></table></center>");
            sb.AppendLine("</div>");
        }

        void RenderSections(StringBuilder sb, List<MenuSection> sectionSlice)
        {
            foreach (MenuSection s in sectionSlice)
            {
                sb.Append("<div class=\"ui-corner-all\" style=\"border: thin solid #CCCCCC; margin: 8px; padding: 4px; width: 190px\">");
                sb.Append("<div width=\"100%\" style=\"background-color: #CCCCCC; color: white; font-weight: bold; padding: 2px;\"><font size=\"larger\"><center>" + HttpUtility.HtmlEncode(s.Caption) + "</center></font></div>");
                foreach (ActHandle h in s.Contents)
                {
                    sb.AppendLine("<a href=\"#\" onclick=\"" + ActionScript("'run'", "'" + s.Caption + "__" + h.Name + "'") + "\">" + h.Caption + "</a><br />");
                }

                sb.Append("</div>");
            }
        }

        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "menuDiv");
            PlaceDivCenterX(sb, "menuDiv");
        }

        public override void Act(Context x, CoreWeb.SpotActArgs args)
        {
            foreach (MenuSection s in Sections)
            {
                foreach (ActHandle h in s.Contents)
                {
                    if (args.ActionParams == s.Caption + "__" + h.Name)
                    {
                        h.TheAct.Handler(x, new ActArgs());
                        return;
                    }
                }
            }

            base.Act(x, args);
        }

        protected virtual void AddSection(String sectionTitle, List<Act> acts)
        {
            MenuSection s = new MenuSection(sectionTitle);
            foreach (Act a in acts)
            {
                s.Contents.Add(new ActHandle(a));
            }
            Sections.Add(s);
        }

        protected void Add(List<ActHandle> handles)
        {
            foreach (ActHandle h in handles)
            {
                if (h.SubActs.Count == 0)
                    continue;

                MenuSection s = new MenuSection(h.Caption);
                foreach (ActHandle a in h.SubActs)
                {
                    s.Contents.Add(a);
                }
                Sections.Add(s);
            }
        }
    }

    public class MenuSection
    {
        public String Caption;
        public List<ActHandle> Contents = new List<ActHandle>();

        public MenuSection(String caption)
        {
            Caption = caption;
        }
    }
}
