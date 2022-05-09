using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Rz5.Web;
using RzWeb;
using Tools.Database;

namespace RzWeb
{
    public class ImportScreen : RzScreen
    {
        //Protected Variables
        protected nDataTable dataTable;
        protected bool complete = false;
        //Prtvate Variables
        String selectedFile;
        String selectedCaption;
        bool UploadAvailable = false;

        //Constructors
        public ImportScreen(ContextRz x)
            : base(x)
        {
        }
        //Public Override Functions
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"importScreenDiv\" class=\"ui-corner-all\" style=\"position: absolute; border: thin solid #CCCCCC; margin: 4px; padding: 4px\">");
            sb.AppendLine("<strong>" + Caption + " Import</strong><br />");
            if (complete)
                RenderComplete(x, sb, viewHandle);
            else if (File.Exists(selectedFile))
            {
                sb.Append("<table border=\"0\"><tr><td><input id=\"cancelButton\" type=\"button\" value=\"Cancel\" onclick=\"" + ActionScript("'cancel'", "''") + "\"/></td><td><img src=\"Graphics/" + Path.GetExtension(selectedFile).Replace(".", "") + ".png\"></td><td>");
                sb.AppendLine("<br />File: " + selectedCaption);
                sb.AppendLine("<br />Size: " + Tools.Files.SpaceFormat(new FileInfo(selectedFile).Length));
                sb.AppendLine("<br />Rows: " + Tools.Number.LongFormat(dataTable.Count));
                sb.AppendLine("</td><tr></table>");
                RenderImportOptions(x, sb, viewHandle);
                Buttonize(viewHandle, "cancelButton", "Cancel.png");
            }
            else
            {
                sb.AppendLine("<div style=\"float: left\"><img src=\"Graphics/" + IconSource + "\" /></div><div style=\"float: left\">");
                sb.AppendLine("<form id=\"uploadForm\" method=\"post\" enctype=\"multipart/form-data\" action=\"Action.aspx\" target=\"iframe-post-form\">");
                sb.AppendLine("<input id=\"actionId_" + Uid + "\" type=\"hidden\" name=\"action_id\" value=\"upload\">");
                sb.AppendLine("<input type=\"hidden\" name=\"action_params\">");
                sb.AppendLine("<input type=\"hidden\" name=\"sid\" value=\"" + TheScreen.Uid + "\">");
                sb.AppendLine("<input type=\"hidden\" name=\"vid\" value=\"" + viewHandle.Uid + "\">");
                sb.AppendLine("<input type=\"hidden\" name=\"cid\" value=\"" + Uid + "\">");
                sb.Append("<div id=\"fileUpload\">Please choose an Excel, .csv, or .dbf file to upload:<br /><input type=\"file\" name=\"fileUpload\"></div>");
                sb.AppendLine("</form></div>");
                viewHandle.ScriptsToRun.Add("iframePostForm('uploadForm');");
                viewHandle.ScriptsToRun.Add("$('#fileUpload').change( function ()  {    iFramePostAction = function() {" + ActionScript("'process_upload'") + "}; $('#uploadForm').submit(); SpinSimple('fileUpload');  }  );");
            }
            sb.Append("</div>");
            if (!complete && dataTable != null)
            {
                sb.AppendLine("<div id=\"previewDiv\" style=\"position: absolute; overflow: scroll\">");
                sb.AppendLine("<table border=\"0\" style=\"margin: 4px; width: 100%\"><tr><td valign=\"top\" style=\"width: 60px\"><div id=\"importButtonDiv\"><input id=\"importButton\" type=\"button\" value=\"Import\" style=\"\" onclick=\"" + ActionScriptPlusControls("'import'", "''") + " SpinSimple('importButtonDiv');\"/></div></td><td>");
                sb.AppendLine("<table border=\"0\"><tr><td>&nbsp;</td>");
                int i = 1;
                foreach (nDataColumn c in dataTable.Columns)
                {
                    String ignoreSel = "";
                    if (c.p == null)
                        ignoreSel = " selected";
                    sb.AppendLine("<td><center><b>Column " + Tools.Number.LongFormat(i) + "</b></center><br><select name=\"ctl_" + c.unique_id + "\" onchange=\"" + ActionScriptPlusControls("'column_assigned'") + "\"><option" + ignoreSel + ">Ignore</option>" + RenderOptions(x, c) + "</select></td>");
                    i++;
                }
                sb.AppendLine("</tr>");
                foreach (nDataRow r in dataTable.GetQuickRows())
                {
                    sb.AppendLine("<tr><td><img src=\"Graphics/Cancel.png\" width=\"8px\" height=\"8px\" onclick=\"" + ActionScriptPlusControls("'remove_row'", "'" + r.unique_id + "'") + "\"/>");
                    i = 0;
                    foreach (nDataColumn c in dataTable.Columns)
                    {
                        sb.Append("<td>");
                        String value = Tools.Data.NullFilterString(r.Values[i]);
                        if (value.Length > 15)
                            value = value.Substring(0, 13) + "...";
                        sb.Append(value + "&nbsp;");
                        sb.Append("</td>");
                        i++;
                    }
                    sb.AppendLine("</tr>");
                }
                sb.AppendLine("</table>");
                sb.AppendLine("</td></tr></table>");
                Buttonize(viewHandle, "importButton", "importmenu.png");
                sb.AppendLine("</div>");
            }
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "column_assigned":
                    ColumnAssigned(x, args);
                    break;
                case "upload":
                    HandleUpload(x, args);
                    break;
                case "cancel":
                    Cancel();
                    Change();
                    break;
                case "import":
                    Import(x, args);
                    break;
                case "remove_row":
                    RemoveRow(x, args);
                    break;
                case "new_file":
                    Cancel();
                    Change();
                    break;
                case "process_upload":
                    ProcessUpload(x);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "importScreenDiv");
            //PlaceDivCenterX(sb, "importScreenDiv");

            sb.AppendLine("$('#previewDiv').css('left', 0);");
            sb.AppendLine("PlaceDivBelow('previewDiv', 'importScreenDiv');");
            RunDivToBottom(sb, "previewDiv");
            RunDivToRight(sb, "previewDiv");
        }
        //Protected Virtual Functions
        protected virtual String Caption
        {
            get
            {
                return "";
            }
        }
        protected virtual String IconSource
        {
            get
            {
                return "";
            }
        }
        protected virtual void RenderComplete(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            sb.AppendLine("<input id=\"anotherImport\" type=\"button\" value=\"Import Another File\" onclick=\"" + ActionScript("'new_file'", "''") + "\"/>");
            Buttonize(viewHandle, "anotherImport", "NewFile.png");
        }
        protected virtual void RenderImportOptions(Context x, StringBuilder sb, ViewHandle viewHandle)
        {

        }
        protected virtual void Import(Context x, SpotActArgs args)
        {
            throw new NotImplementedException();
        }
        protected virtual CoreVarValAttribute VarValGet(String caption)
        {
            switch (caption)
            {
                default:
                    return null;
            }
        }
        protected virtual void ColumnAssigned(Context x, SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            foreach (nDataColumn c in dataTable.Columns)
            {
                String selected = args.Var(c.unique_id);
                if (selected == "Ignore")
                    continue;
                c.p = VarValGet(selected);
            }
        }
        protected virtual List<String> ListFieldCaptions(Context x)
        {
            return new List<string>();
        }
        protected virtual void RemoveRow(Context x, SpotActArgs args)
        {
            dataTable.DeleteRow(args.ActionParams);
            dataTable.RefreshFromDatabase((ContextNM)x);
            Change();
        }
        //Private Functions
        private void ProcessUpload(Context x)
        {
            //int halfSeconds = 0;
            //while (halfSeconds < 4 || UploadAvailable)
            //{
            //    System.Threading.Thread.Sleep(500);
            //    halfSeconds++;
            //}

            if (!UploadAvailable)
                x.Leader.Error("Upload failed.  Please re-try.");

            Change();

            UploadAvailable = false;
        }
        private String RenderOptions(Context x, nDataColumn c)
        {
            List<String> fields = ListFieldCaptions(x);

            StringBuilder sb = new StringBuilder();
            foreach (String f in fields)
            {
                String sel = "";
                if (c.p != null && Tools.Strings.StrCmp(f, c.p.Caption))
                    sel = " selected";
                sb.AppendLine("<option" + sel + ">" + f + "</option>");
            }
            return sb.ToString();
        }
        private String SampleLine(nDataColumn c)
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in dataTable.GetColumnSample(c))
            {
                sb.Append("  |  " + s);

                if (sb.ToString().Length > 200)
                    break;
            }
            return sb.ToString();
        }
        private void HandleUpload(Context x, SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            UploadAvailable = false;

            HttpPostedFile b = (HttpPostedFile)args.Request.Files["fileUpload"];
            if (b == null)
                return;
            if (b.ContentLength == 0)
                return;
            if (!Directory.Exists(RzWebApp.BilgePath))
                Directory.CreateDirectory(RzWebApp.BilgePath);
            String tempFile = RzWebApp.BilgePath + "x_" + Tools.Strings.GetNewID() + Path.GetExtension(b.FileName);
            b.SaveAs(tempFile);
            dataTable = new nDataTable((DataConnectionSqlServer)x.Data.Connection);
            try
            {
                dataTable.AbsorbFile(xrz, tempFile, defaultSheet: true);
                selectedFile = tempFile;
                selectedCaption = b.FileName;
                UploadAvailable = true;
                FileUploaded(xrz, b.FileName);
            }
            catch (Exception ex)
            {
                Cancel();
                x.Leader.Tell("Import error: " + ex.Message);
            }
        }
        private void Cancel()
        {
            dataTable = null;
            selectedFile = "";
            selectedCaption = "";
            complete = false;
        }

        protected virtual void FileUploaded(ContextRz context, String fileName)
        {

        }
    }
}


