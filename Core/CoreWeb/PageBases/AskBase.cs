using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

using Core;

namespace CoreWeb
{
    public class AskBase : CorePage
    {
        protected virtual void LoadHandle()
        {
            if (TheContext == null)
            {
                ;
            }

            Response.Clear();
            
            //made no difference
            //Response.ContentType = "application/json";  //added 2013_07_15 to solve IE error message, was text/html

            String askId = Request["askId"];
            if( !Tools.Strings.StrExt(askId) )
                return;

            if( !LeaderWebUser.WebThreads.ContainsKey(askId) )
                return;

            WebThreadHandle h = LeaderWebUser.WebThreads[askId];

            Context cloneContext = TheContext.Clone();
            cloneContext.Leader = h.Leader;

            String html = "";
            String after = "";

            html = h.Render(TheContext, ref after);

            lock (h.Leader.TheViewHandle.ScriptsToRun)
            {
                if (h.Leader.TheViewHandle.ScriptsToRun.Count > 0)
                {
                    after += "<script type=\"text/javascript\">\r\n";
                    foreach (String s in h.Leader.TheViewHandle.ScriptsToRun)
                    {
                        after += s + "\r\n";
                    }
                    after += "</script>";
                    h.Leader.TheViewHandle.ScriptsToRun.Clear();
                }
            } 

            StringBuilder json = new StringBuilder();
            json.Append("{\"d\":[");
            json.Append("{\"html\":\"" + AsyncLinkPageBase.EncodeForJson(html) + "\", \"after\":\"" + AsyncLinkPageBase.EncodeForJson(after) + "\"}");
            json.Append("]}");
            Response.Write(json.ToString());           
            //$('#dialog_div').dialog({ height: 295, width: 435 }); $('#l_bef0d192d2f347efbec974a457385ab8').css('width', 390); $('#l_bef0d192d2f347efbec974a457385ab8').css('height', 130); buttonize('ok_19f633fb1e324417a18b3ced10692e37', 'Ok.png'); buttonize('cancel_19f633fb1e324417a18b3ced10692e37', 'Cancel.png'); $('#search_inv_19f633fb1e324417a18b3ced10692e37').css('padding', '0px 6px 0px 6px').button(); $('#xb1e723474ed54a889a355a4a08a51323').focus().select(); 
            Response.End();
        }
    }
}
