using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;

namespace CoreWeb
{
    public class CorePage : System.Web.UI.Page
    {
        public Context TheContext
        {
            get
            {
                return (Context)Session["TheContext"];
            }

            //why wasn't the set accessor available?  2011_08_21
            set
            {
                Session["TheContext"] = value;
            }
        }

        protected virtual bool ContextInit(bool redirect)
        {
            if (TheContext == null)
            {
                if( redirect )
                    Response.Redirect(Page.ResolveClientUrl("~/Default.aspx"));
    
                return false;
            }
            else
            {
                //this has to be set each time
                ((LeaderWebUser)TheContext.TheLeader).Request = Request;
                ((LeaderWebUser)TheContext.TheLeader).Response = Response;
                ((LeaderWebUser)TheContext.TheLeader).PageIsDialog = false;
                return true;
            }
        }

        protected bool ContextInit()
        {
            return ContextInit(true);
        }

        public String GraphicsPath
        {
            get
            {
                return this.ResolveClientUrl("~/Graphics/");
            }
        }

        public String ItemUrl(IItem item)
        {
            return ResolveClientUrl("~/Process.aspx?action=show&class=" + item.ClassId + "&id=" + item.Uid);
        }

        //public String MessagesRender()
        //{
        //    LeaderWebUser u = (LeaderWebUser)TheContext.TheLeader;
        //    return MessagesRender(u.Messages);
        //}

        public String JqPath
        {
            get
            {
                return Page.ResolveClientUrl("~/Jq");
            }
        }

        public static String MessagesRender(List<Message> messages)
        {
            if (messages.Count == 0)
                return "";

            String id = "msg_" + Tools.Strings.GetNewID();
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id=\"" + id + "\" style=\"position: absolute; left: 20%; width: 60%; padding: 0px; top: 10%; z-index: 0; background-color: white; border: 4px blue solid; \"><p align=\"center\">");
            foreach (Message m in messages)
            {
                sb.Append("<br><font color=\"red\">" + Tools.Html.ConvertTextToHTML(m.TheText) + "</font>");

                //this didn't seem to give a valid color, at least for gray
                //" + Tools.Colors.RGBtoHEX(m.TheColor.ToArgb()) + "
            }

            sb.Append("<br><br><button onclick=\" $('#" + id + "').hide(); return false;\">Ok</button></p>");
            sb.Append("</div>");
            messages.Clear();
            return sb.ToString();

        }

    }
}
