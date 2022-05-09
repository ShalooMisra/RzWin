using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using System.Web.UI;
using System.IO;

namespace Rz5.Web
{
    public class Attachments : CoreWeb.Control
    {
        //Public Variables
        public nObject TheObject = null;
        public String ClassExtra = "";
        //Private Variables
        ContextRz TheContext;
        RzScreen TheControlScreen
        {
            get
            {
                return (RzScreen)TheScreen;
            }
        }
        bool AttachmentLoaded = false;
        bool UploadAvailable = false;
        String AvailableFileName = "";
        partpicture TheAttachment;
        ListViewSpotAttachments lvAttach;
        LabelControl lblAttach;
        TextControl txtAttach;
        TextAreaControl txtDescription;
        AnchorControl cmdBrowse;
        AnchorControl cmdDelete;
        AnchorControl cmdNew;
        AnchorControl cmdSave;
        ImageControl imgAttach;
        AnchorControl aDoc;

        //Constructors
        public Attachments(String name, String caption, Context x, Screen screenHandle, nObject obj, string class_extra = "", bool skip_parent_render = true)
            : base(name, caption, skip_parent_render)
        {
            TheScreen = screenHandle;
            TheContext = (ContextRz)x;
            TheObject = obj;
            ClassExtra = class_extra;
            lblAttach = (LabelControl)SpotAdd(TheControlScreen, ControlAdd(new LabelControl("lblAttach", "", "Attachment:")));
            txtAttach = (TextControl)SpotAdd(TheControlScreen, ControlAdd(new TextControl("txtAttach", "", "")));
            txtDescription = (TextAreaControl)SpotAdd(TheControlScreen, ControlAdd(new TextAreaControl("txtDescription", "Description:", "")));
            txtDescription.FixedWidth = 200;
            imgAttach = (ImageControl)SpotAdd(TheControlScreen, ControlAdd(new ImageControl("imgAttach", "", "~/Graphics/attach_img.jpg")));
            cmdBrowse = (AnchorControl)SpotAdd(TheControlScreen, ControlAdd(new AnchorControl("cmdBrowse", "", "$('#fileUploadEntry').click();", "attach_browse.png")));
            cmdDelete = (AnchorControl)SpotAdd(TheControlScreen, ControlAdd(new AnchorControl("cmdDelete", "Delete", ActionScript("'delete'", "'na'"), "attach_delete.png")));
            cmdNew = (AnchorControl)SpotAdd(TheControlScreen, ControlAdd(new AnchorControl("cmdNew", "New", ActionScript("'new'", "'na'"), "attach_new.png")));
            cmdSave = (AnchorControl)SpotAdd(TheControlScreen, ControlAdd(new AnchorControl("cmdSave", "Save", ActionScriptPlusControls("'save'"), "attach_save.png")));
            aDoc = (AnchorControl)SpotAdd(TheControlScreen, ControlAdd(new AnchorControl("aDoc", "", "onclick")));
            aDoc.Visible = false;
            InitLV();
            AdjustControls();
        }
        //Public Override Functions
        public override void RenderCaption(Core.Context x, StringBuilder sb)
        {
            //do nothing, handled in render control
        }
        public override void RenderControl(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            sb.AppendLine("<div id=\"attachments_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            cmdDelete.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdNew.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdSave.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdBrowse.Render(x, sb, screenHandle, viewHandle, session, page);
            lblAttach.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAttach.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescription.Render(x, sb, screenHandle, viewHandle, session, page);
            imgAttach.Render(x, sb, screenHandle, viewHandle, session, page);
            lvAttach.Render(x, sb, screenHandle, viewHandle, session, page);
            aDoc.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<form id=\"uploadForm2\" method=\"post\" enctype=\"multipart/form-data\" action=\"Action.aspx\" target=\"iframe-post-form\">");
            sb.AppendLine("<input id=\"actionId_" + Uid + "\" type=\"hidden\" name=\"action_id\" value=\"upload\">");
            sb.AppendLine("<input type=\"hidden\" name=\"action_params\">");
            sb.AppendLine("<input type=\"hidden\" name=\"sid\" value=\"" + TheScreen.Uid + "\">");
            sb.AppendLine("<input type=\"hidden\" name=\"vid\" value=\"" + viewHandle.Uid + "\">");
            sb.AppendLine("<input type=\"hidden\" name=\"cid\" value=\"" + Uid + "\">");
            sb.Append("<div id=\"fileUpload\"><input type=\"file\" id=\"fileUploadEntry\" name=\"fileUpload\" style=\"display: none;\" onchange=\"" + ActionScript("'image_changed'", "$('#file').val()") + "\"></div>");
            sb.AppendLine("</form>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        public override string ValueAddScript(string varName)
        {
            return "";
        }
        public override object StringToObject(string val)
        {
            return val;
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId)
            {
                case "image_changed":
                    ImageChanged((ContextRz)x, args);
                    break;
                case "save":
                    Save((ContextRz)x, args);
                    break;
                case "delete":
                    DeleteAttachment((ContextRz)x, args);
                    break;
                case "new":
                    NewAttachment((ContextRz)x, args);
                    break;
                case "import":
                    Import((ContextRz)x, args);
                    break;
                case "upload":
                    UploadAttachment((ContextRz)x, args);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        //Public Functions
        public void ReDoSearch()
        {
            lvAttach.RowSource = new RowSourceTable(TheContext.Select(lvAttach.TheArgs.RenderSql(TheContext, lvAttach.CurrentTemplate)));
            lvAttach.Change();
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#attachments_" + Uid + "').css('width', " + this.Select + ".width());");
            sb.AppendLine("$('#attachments_" + Uid + "').css('height', " + this.Select + ".height());");
            sb.AppendLine(cmdDelete.Select + ".css('top', $('#attachments_" + Uid + "').height() - " + cmdDelete.Select + ".height());");
            sb.AppendLine(cmdNew.Select + ".css('top', $('#attachments_" + Uid + "').height() - " + cmdNew.Select + ".height());"); ;
            sb.AppendLine(cmdNew.PlaceRight(cmdDelete));
            sb.AppendLine(cmdSave.Select + ".css('top', $('#attachments_" + Uid + "').height() - " + cmdSave.Select + ".height());"); ;
            sb.AppendLine(cmdSave.PlaceRight(cmdNew));
            sb.AppendLine(lblAttach.Select + ".css('top', $('#attachments_" + Uid + "').height() - " + cmdDelete.Select + ".height() - " + lblAttach.Select + ".height() - 6);");
            sb.AppendLine(txtAttach.Select + ".css('top', $('#attachments_" + Uid + "').height() - " + cmdDelete.Select + ".height() - " + txtAttach.Select + ".height() - 7);");
            sb.AppendLine(txtAttach.PlaceRight(lblAttach));
            sb.AppendLine(cmdBrowse.Select + ".css('top', " + txtAttach.Select + ".position().top);"); //$('#attachments_" + Uid + "').height() - " + cmdDelete.Select + ".height() - " + cmdBrowse.Select + ".height());");//" + aPath.Select + ".height() - 
            sb.AppendLine(cmdBrowse.PlaceRight(txtAttach, false, 3, 0));
            sb.AppendLine(txtDescription.Select + ".css('top', $('#attachments_" + Uid + "').height() - " + txtDescription.Select + ".height());");
            sb.AppendLine(txtDescription.PlaceRight(cmdBrowse));
            sb.AppendLine("$('#" + txtDescription.ControlId + "').css('width', $('#attachments_" + Uid + "').width() - " + txtDescription.Select + ".position().left - 7);");
            sb.AppendLine(imgAttach.Select + ".css('top', 5);");
            sb.AppendLine(imgAttach.Select + ".css('left', " + txtDescription.Select + ".position().left);");
            sb.AppendLine(imgAttach.Select + ".css('width', " + txtDescription.Select + ".width());");
            sb.AppendLine(imgAttach.Select + ".css('height', " + txtDescription.Select + ".position().top - " + imgAttach.Select + ".position().top );");
            sb.AppendLine("$('#" + imgAttach.ControlId + "').css('width', " + imgAttach.Select + ".width());");
            sb.AppendLine("$('#" + imgAttach.ControlId + "').css('height', " + imgAttach.Select + ".height() - 4);");
            sb.AppendLine(lvAttach.Select + ".css('top', 5);");
            sb.AppendLine(lvAttach.Select + ".css('width', " + imgAttach.Select + ".position().left - " + lvAttach.Select + ".position().left - 10);");
            sb.AppendLine(lvAttach.Select + ".css('height', " + txtDescription.Select + ".position().top - " + lvAttach.Select + ".position().top );");
            sb.AppendLine(aDoc.Select + ".css('top', " + imgAttach.Select + ".position().top + 5);");
            sb.AppendLine(aDoc.Select + ".css('left', " + imgAttach.Select + ".position().left + 11);");
        }
        //Private Functions
        private void InitLV()
        {
            lvAttach = (ListViewSpotAttachments)SpotAdd(TheControlScreen, new ListViewSpotAttachments());
            lvAttach.SkipParentRender = true;
            lvAttach.TheArgs = new ListArgs(TheContext);
            lvAttach.TheArgs.AddAllow = false;
            lvAttach.TheArgs.TheClass = "partpicture";
            lvAttach.TheArgs.TheLimit = 200;
            lvAttach.TheArgs.TheTable = "partpicture";
            lvAttach.TheArgs.TheTemplate = "PartPictureViewer";
            lvAttach.TheArgs.TheOrder = "date_created desc";
            lvAttach.TheArgs.TheWhere = "unique_id = '<not an id>'";
            if (TheObject != null)
            {
                try
                {
                    switch (TheObject.ClassId.ToLower())
                    {
                        case "qualitycontrol":
                            lvAttach.TheArgs.TheWhere = "the_qualitycontrol_uid = '" + TheObject.unique_id + "'";
                            break;
                        case "partrecord":
                            lvAttach.TheArgs.TheWhere = "the_partrecord_uid = '" + TheObject.unique_id + "'";
                            break;
                        case "partpicture":
                            partpicture pic = (partpicture)TheObject;
                            String strPart = pic.fullpartnumber;
                            if (!Tools.Strings.StrExt(strPart))
                                break;
                            strPart = PartObject.StripPart(strPart);
                            lvAttach.TheArgs.TheWhere = "prefix + basenumberstripped = '" + strPart + "'";
                            break;
                        case "company":
                            lvAttach.TheArgs.TheWhere = "the_company_uid = '" + TheObject.unique_id + "'";
                            break;
                        case "companycontact":
                            lvAttach.TheArgs.TheWhere = "the_companycontact_uid = '" + TheObject.unique_id + "'";
                            break;
                        default:
                            if (TheObject.ClassId.ToLower().StartsWith("ordhed"))
                            {
                                ordhed hed = (ordhed)TheObject;
                                List<String> ids = new List<string>();
                                foreach (orddet d in hed.Details.RefsGetAsItems(TheContext).AllGet(TheContext))
                                {
                                    ids.Add(d.unique_id);
                                }
                                if (ids.Count == 0)
                                    lvAttach.TheArgs.TheWhere = " ( the_ordhed_uid = '" + hed.unique_id + "' )";
                                else
                                    lvAttach.TheArgs.TheWhere = " ( the_ordhed_uid = '" + hed.unique_id + "' or the_orddet_uid in ( " + Tools.Data.GetIn(ids) + " ) )";
                            }
                            else if (TheObject.ClassId.ToLower().StartsWith("orddet"))
                                lvAttach.TheArgs.TheWhere = "the_orddet_uid = '" + TheObject.unique_id + "'";
                            break;
                    }
                }
                catch { }
            }
            lvAttach.TheArgs.TheConnection = TheContext.TheLogicRz.PictureData;
            lvAttach.CurrentTemplate = n_template.GetByName(TheContext, lvAttach.TheArgs.TheTemplate);
            if (lvAttach.CurrentTemplate == null)
                lvAttach.CurrentTemplate = n_template.Create(TheContext, lvAttach.TheArgs.TheClass, lvAttach.TheArgs.TheTemplate);
            lvAttach.CurrentTemplate.GatherColumns(TheContext);
            lvAttach.ColSource = new ColumnSourceTemplate(lvAttach.CurrentTemplate);
            lvAttach.RowSource = new RowSourceTable(lvAttach.TheArgs.TheConnection.Select(lvAttach.TheArgs.RenderSql(TheContext, lvAttach.CurrentTemplate)));
            lvAttach.ItemDoubleClicked += new ItemDoubleClickHandler(lvAttach_ItemDoubleClicked);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function SubmitImportForm() {");
            sb.AppendLine("var x = $('#uploadForm2');");
            sb.AppendLine("x.submit();");
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("iframePostForm('uploadForm2');");
            viewHandle.ScriptsToRun.Add("$('#fileUpload').change(function () { iFramePostAction = function() {" + ActionScriptPlusControls("'import'") + "}; SubmitImportForm(); SpinSimple('" + lvAttach.DivId + "'); } );");       
        }
        private void AdjustControls()
        {
            lblAttach.TextFontSize = FontSize.XSmall;
            lblAttach.TextBold = true;
            txtAttach.ReadOnly = true;
            txtAttach.UseNameInID = true;
            txtDescription.TextFontSize = FontSize.Small;
            txtDescription.CaptionFontSize = FontSize.Small;
            txtDescription.UseNameInID = true;
            imgAttach.ImageBorderSize = 2;
            lvAttach.ExtraStyle = "; font-size: small";
            aDoc.TextFontSize = FontSize.Large;
            aDoc.TextForeColor = Color.LightBlue;
            aDoc.TextBackColor = Color.Gray;
            cmdBrowse.ButtonTopPadding = 2;
            cmdDelete.ButtonTopPadding = 20;
            cmdNew.ButtonTopPadding = 20;
            cmdSave.ButtonTopPadding = 20;
        }
        private void Save(ContextRz x, SpotActArgs args)
        {
            if (TheAttachment == null)
                return;
            string s = "";
            args.Vars.TryGetValue("ctl_txtdescription", out s);
            if (Tools.Strings.StrExt(s))
                TheAttachment.description = s;
            TheAttachment.Update(x);
            ReDoSearch();
        }
        private void DeleteAttachment(ContextRz x, SpotActArgs args)
        {
            if (!AttachmentLoaded)
            {
                x.TheLeader.Tell("You do not currently have an attachment loaded to delete.");
                return;
            }
            if (TheAttachment == null)
            {
                x.TheLeader.Tell("The attachment selected does not appear to exist.");
                return;
            }
            if (!x.TheLeader.AskYesNo("you want ot delete the attachment: " + TheAttachment.description))
                return;
            TheAttachment.Delete(x);
            TheAttachment = null;
            aDoc.Visible = false;
            aDoc.Change();
            imgAttach.ImageURL = args.SourcePage.ResolveClientUrl("~/Graphics/attach_img.jpg");
            imgAttach.Change();
            txtAttach.Value = "";
            txtAttach.Change();
            args.SourceView.ScriptsToRun.Add("HideDivIndex('" + aDoc.DivId + "', -10);");
            lvAttach.RowSource = new RowSourceTable(lvAttach.TheArgs.TheConnection.Select(lvAttach.TheArgs.RenderSql(x, lvAttach.CurrentTemplate)));
            lvAttach.Change();
            AttachmentLoaded = false;
        }
        private void NewAttachment(ContextRz x, SpotActArgs args)
        {
            TheAttachment = null;
            aDoc.Visible = false;
            aDoc.Change();
            imgAttach.ImageURL = args.SourcePage.ResolveClientUrl("~/Graphics/attach_img.jpg");
            imgAttach.Change();
            txtAttach.ValueSet("");
            txtAttach.Change();
            txtDescription.ValueSet("");
            txtDescription.Change();
            args.SourceView.ScriptsToRun.Add("HideDivIndex('" + aDoc.DivId + "', -10);");
            lvAttach.RowSource = new RowSourceTable(lvAttach.TheArgs.TheConnection.Select(lvAttach.TheArgs.RenderSql(x, lvAttach.CurrentTemplate)));
            lvAttach.Change();
            AttachmentLoaded = false;
        }
        private void ImageChanged(ContextRz x, SpotActArgs args)
        {
            txtAttach.ValueSet(args.ActionParams);
            txtAttach.Change();          
        }
        private void UploadAttachment(ContextRz x, SpotActArgs args)
        {
            UploadAvailable = false;
            AvailableFileName = "";
            HttpPostedFile b = (HttpPostedFile)args.Request.Files["fileUpload"];
            if (b == null)
                return;
            if (b.ContentLength == 0)
                return;
            String bilge = args.Request.MapPath("~/Bilge/");
            if (!Directory.Exists(bilge))
                Directory.CreateDirectory(bilge);
            AvailableFileName = bilge + "x_" + Tools.Strings.GetNewID() + Path.GetExtension(b.FileName);
            b.SaveAs(AvailableFileName);
            UploadAvailable = true;
        }
        private void Import(ContextRz x, SpotActArgs args)
        {
            try
            {
                if (!UploadAvailable)
                {
                    x.Leader.Error("No uploaded file is available");
                    return;
                }
                if (!Tools.Strings.StrExt(AvailableFileName))
                    return;
                if (!Tools.Files.FileExists(AvailableFileName))
                    return;
                TheAttachment = new partpicture();
                TheAttachment.SetPictureDataByFile(x, AvailableFileName);
                try
                {
                    switch (TheObject.ClassId.ToLower().Trim())
                    {
                        case "company":
                            TheAttachment.the_company_uid = TheObject.IGet("unique_id").ToString();
                            break;
                        case "companycontact":
                            TheAttachment.the_company_uid = TheObject.IGet("base_company_uid").ToString();
                            TheAttachment.the_companycontact_uid = TheObject.IGet("unique_id").ToString();
                            break;
                        case "ordhed":
                            TheAttachment.the_ordhed_uid = TheObject.IGet("unique_id").ToString();
                            break;
                        case "orddet":
                            TheAttachment.the_orddet_uid = TheObject.IGet("unique_id").ToString();
                            TheAttachment.fullpartnumber = TheObject.IGet("fullpartnumber").ToString();
                            break;
                        case "partrecord":
                            TheAttachment.the_partrecord_uid = TheObject.IGet("unique_id").ToString();
                            TheAttachment.fullpartnumber = TheObject.IGet("fullpartnumber").ToString();
                            break;
                        case "qualitycontrol":
                            TheAttachment.the_qualitycontrol_uid = TheObject.IGet("unique_id").ToString();
                            TheAttachment.fullpartnumber = TheObject.IGet("fullpartnumber").ToString();
                            break;
                    }
                    PartObject.ParsePartNumber(TheAttachment);
                }
                catch { }
                string s = "";
                args.Vars.TryGetValue("ctl_txtdescription", out s);
                TheAttachment.description = s;
                if (!Tools.Strings.StrExt(TheAttachment.description))
                    TheAttachment.description = TheAttachment.filename;
                TheAttachment.Insert(x);
                TheAttachment.SavePictureData(x);
                ShowAttachment(x, args.SourcePage, args.SourceView);
                ReDoSearch();
            }
            catch (Exception ee)
            {
                x.TheLeader.Tell("Error: " + ee.Message);
            }
        }
        private void ShowAttachment(ContextRz x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (TheAttachment == null)
                return;
            string filename = Tools.Strings.GetNewID() + "." + TheAttachment.filetype.Replace(".", "").Trim();
            string path = Tools.Folder.ConditionFolderName(page.Server.MapPath("~/Graphics")) + "Attachment_Temp\\";
            if (!Tools.Folder.FolderExists(path))
                Tools.Folder.MakeFolderExist(path);
            string file = path + filename;
            TheAttachment.LoadPictureData(x);
            TheAttachment.SaveDataAsFile(x, file);
            txtAttach.ValueSet(TheAttachment.filename);
            txtAttach.Change();
            txtDescription.ValueSet(TheAttachment.description);
            txtDescription.Change();
            bool is_image = false;
            switch (TheAttachment.filetype.ToLower().Replace(".", "").Trim())
            {
                case "gif":
                case "jpg":
                case "jpeg":
                case "bmp":
                case "wmf":
                case "png":
                    is_image = true;
                    break;
            }
            if (is_image)
            {
                aDoc.Visible = false;
                aDoc.Change();
                imgAttach.ImageURL = page.ResolveClientUrl("~/Graphics/Attachment_Temp/" + Tools.Files.GetFileName(file));
                imgAttach.Change();
                viewHandle.ScriptsToRun.Add("HideDivIndex('" + aDoc.DivId + "', -10);");
            }
            else
            {
                imgAttach.ImageURL = page.ResolveClientUrl("~/Graphics/attach_img.jpg");
                imgAttach.Change();
                aDoc.Caption = TheAttachment.filetype.Replace(".", "").ToUpper();
                aDoc.Href = page.ResolveClientUrl("~/Graphics/Attachment_Temp/" + Tools.Files.GetFileName(file));
                aDoc.Visible = true;
                aDoc.Change();
                viewHandle.ScriptsToRun.Add("ShowDivIndex('" + aDoc.DivId + "', 10);");
            }
            viewHandle.ScriptsToRun.Add("DoResize();");
            AttachmentLoaded = true;
        }
        //Control Events
        private void lvAttach_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (item == null)
                return;
            TheAttachment = (partpicture)item;
            ShowAttachment((ContextRz)x, page, viewHandle);
        }
    }
    public class ListViewSpotAttachments : ListViewSpotRz
    {
        public ListViewSpotAttachments()
            : base("partpicture")
        {
        }
    }
}