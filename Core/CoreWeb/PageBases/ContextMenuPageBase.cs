using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using Core;
using CoreWeb;

namespace CoreWeb
{
    public class ContextMenuPageBase : CorePage
    {
        protected void LoadHandle()
        {
            if (!ContextInit(false))
            {
                Response.Clear();
                Response.Write("Menu Error");
                Response.End();
                return;
            }

            Response.Clear();

            List<String> ids = CoreWeb.LeaderWebUser.ItemIdsParse(Request["ids"]);

            //find the requesting screen
            String screenId = Request["sid"];
            if (!Tools.Strings.StrExt(screenId))
            {
                Response.End();
                return;
            }

            AsyncScreenHandle h = AsyncScreenHandle.ActiveHandleGet(screenId);
            if (h == null)
            {
                Response.End();
                return;
            }

            String vid = Request["vid"];
            if (!Tools.Strings.StrExt(vid))
            {
                Response.End();
                return;
            }

            ViewHandle vh = h.Screen.ViewGet(vid);
            if (vh == null)
            {
                Response.End();
                return;
            }

            SpotActArgs args = new SpotActArgs(Request, Page, vh);

            String spotId = Request["cid"];
            if (!Tools.Strings.StrExt(spotId))
            {
                Response.End();
                return;
            }

            Spot sh = h.Screen.SpotById(spotId);
            if (sh == null)
            {
                Response.End();
                return;
            }

            List<ActHandle> acts = new List<ActHandle>();
            sh.ActsList(TheContext, ids, acts, Request);
            foreach(ActHandle a in acts)
            {
                WriteAct(a);
            }

            Response.End();
        }

        void WriteAct(ActHandle a)
        {
            WriteAct(a, 0);
        }

        void WriteAct(ActHandle a, int indent)
        {
            if (a is ActHandleSeparator)
                Response.Write("<tr><td><hr></td></tr>");
            else if (a.SubActs.Count > 0)
            {
                Response.Write("<tr><td style=\"background-color: white;\"><span class=\"\" style=\"float: left\"></span><font color=\"#000000\">" + Indent(indent) + a.Caption.Replace("<", "").Replace(">", "") + "</font></td></tr>");
                foreach (ActHandle h in a.SubActs)
                {
                    WriteAct(h, indent + 1);
                }
            }
            else
            {                
                string insert = "";
                if (a.Inserts.Count > 0)
                {
                    insert = "<td valign=\"middle\">";
                    foreach (string s in a.Inserts)
                    {
                        if (!Tools.Strings.StrExt(s))
                            continue;
                        insert += s;
                    }
                    insert += "</td>";
                }
                Response.Write("<tr class=\"menu_row\"><td id=\"ContextMenuLine_" + Tools.Strings.FilterTrash(a.Name) + "__" + Tools.Strings.FilterTrashExceptUnderscore(a.ActionParameters) + "\" class=\"menu_cell\" style=\"\"><span class=\"ui-icon ui-icon-carat-1-e\" style=\"float: left\"></span><font color=\"#000000\">" + Indent(indent) + a.Caption.Replace("<", "").Replace(">", "") + "</font></td>" + insert + "</tr>");
            }
        }

        String Indent(int indent)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < indent; i++)
            {
                sb.Append("&nbsp;&nbsp;&nbsp;");
            }
            return sb.ToString();
        }
    }
}
