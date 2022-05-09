using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz5.Web;
using Rz5;
using Core;
using CoreWeb;
using System.Collections;
using NewMethod;
using System.IO;

namespace RzWeb
{
    public class ExportOEMEmails : RzScreen
    {
        System.Web.UI.Page ThePage;
        ViewHandle TheViewHandle;

        public ExportOEMEmails(ContextRz x)
            : base(x)
        {

        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            ThePage = page;
            TheViewHandle = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"oemexport_" + Uid + "\" style=\"position: absolute; padding: 6px; width: 250px;\"><a href=\"#\" onclick=\"SpinDownload('spin_" + Uid + "');" + ActionScript("'email'") + "\">Click to Downlaod OEM EMail List</a></div>");
            sb.AppendLine("<div id=\"spin_" + Uid + "\" style=\"position: absolute; padding: 6px; width: 250px;\"></div>");            
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "email":
                    ExportEmails((ContextRz)x);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "oemexport_" + Uid);
            PlaceDivBelowDiv(sb, "spin_" + Uid, "oemexport_" + Uid);
        }
        private void ExportEmails(ContextRz context)
        {
            if (ThePage == null)
                return;
            String email = "";
            SortedList s = new SortedList();
            context.TheLeader.StartPopStatus();
            context.TheLeader.Comment("Calculating company addresses...");
            String strSQL = "";
            strSQL = "select distinct(isnull(primaryemailaddress, '')) as primaryemailaddress from company where isnull(donotemail, 0) = 0 and len(isnull(primaryemailaddress, '')) > 0 and (isnull(company.abs_type, '') = 'OEM' or company.companytype like '%oem%') order by primaryemailaddress";
            ArrayList a = context.TheData.SelectScalarArray(strSQL);
            foreach (String st in a)
            {
                email = st.Trim();
                if (nTools.IsEmailAddress(email))
                {
                    try
                    {
                        s.Add(email, email);
                        context.TheLeader.Comment("Added " + email);
                    }
                    catch { }
                }
            }
            context.TheLeader.Comment("Calculating contact addresses...");
            strSQL = "select distinct(isnull(companycontact.primaryemailaddress, '')) as primaryemailaddress from companycontact inner join company on company.unique_id = companycontact.base_company_uid where isnull(companycontact.donotemail, 0) = 0 and len(companycontact.primaryemailaddress) > 0  and (isnull(company.abs_type, '') = 'OEM' or company.companytype like '%oem%') order by companycontact.primaryemailaddress";
            a = context.TheData.SelectScalarArray(strSQL);
            foreach (String st in a)
            {
                email = st.Trim();
                if (nTools.IsEmailAddress(email))
                {
                    try
                    {
                        s.Add(email, email);
                        context.TheLeader.Comment("Added " + email);
                    }
                    catch { }
                }
            }
            StringBuilder sb = new StringBuilder();
            if (s.Count == 0)
                sb.AppendLine("No records.");
            else
            {
                foreach (DictionaryEntry d in s)
                {
                    sb.AppendLine((String)d.Value);
                }
            }
            String strFolder = Tools.Folder.ConditionFolderName(ThePage.Server.MapPath("~/Exports/"));
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);
            string file = Tools.Strings.GetNewID() + ".txt";
            string writeFileAndFolder = strFolder + file;
            Tools.Files.SaveFileAsString(writeFileAndFolder, sb.ToString());
            string zip = Tools.Strings.GetNewID() + ".zip";
            Tools.Zip.ZipOneFile(writeFileAndFolder, Tools.Folder.ConditionFolderName(strFolder) + zip);
            TheViewHandle.FilesToDownload.Add(Tools.Folder.ConditionFolderName(strFolder) + zip);
            //TheViewHandle.Flow();
        }
        public override String Title(Context x)
        {
            return "OEM Email Export";
        }
    }
}
