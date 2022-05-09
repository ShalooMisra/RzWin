using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.SessionState;
using CoreWeb;
using Rz5;

namespace RzWeb
{
    public class RzWebApp : CoreWebApp
    {
        public static String BilgePath = @"C:\Bilge\RzWeb\";
        protected override void SupportingFilesImport()
        {
            base.SupportingFilesImport();
            FileImport("Scripts", "Rz.js", @"C:\Eternal\Code\Rz4\Rz4Web\");
        }
        public static void ManageRzWebAccount(ContextRz context)
        {
            if (Tools.Misc.IsDevelopmentMachine())
            {
                context.Leader.BrowseUrl("Member.aspx?id=" + context.GetSetting("rzweb_id"));
            }
            else
                context.Leader.BrowseUrl("https://rzweb.recognin.com/Member.aspx?id=" + context.GetSetting("rzweb_id"));
        }
    }
}
