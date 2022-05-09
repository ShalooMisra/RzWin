using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Core;
using NewMethod;


namespace Rz5
{
    public partial class PartPictureViewer : UserControl
    {
        public static event PictureAddedHandler PictureAdded;
        public static event PictureRemovedHandler PictureRemoved;

        public String DescriptionTag = "";
        public String DescriptionTagExclude = "";
        public String DescriptionTagExclude2 = "";

        //n_sys xSys;
        String the_ordhed_uid = "";
        String the_orddet_uid = "";
        String the_company_uid = "";
        String the_companycontact_uid = "";
        String the_qualitycontrol_uid = "";
        String the_partrecord_uid = "";
        String fullpartnumber = "";
        protected partpicture m_xPartPic;
        protected partpicture xPartPic
        {
            get
            {
                return m_xPartPic;
            }
            set
            {
                m_xPartPic = value;
                cmdDeletePicture.Enabled = false;


                //2012_08_28
                //what does this have to do with setting the selected pic?
                //cmdAddPicture.Enabled = false;

                if (m_xPartPic != null)
                {
                    if (m_xPartPic.picturedata != null)
                    {
                        m_xPartPic.LoadPictureData(RzWin.Context);
                        byte[] bytes = m_xPartPic.picturedata;
                        if (bytes != null)
                        {
                            if (bytes.Length > 0)
                            {
                                cmdDeletePicture.Enabled = true;
                                //cmdAddPicture.Enabled = true;
                            }
                        }
                    }
                }
                cmdDeletePicture.Enabled = true;
            }
        }
        nObject viewby;
        Boolean bShowFirst = false;
        String templatename = "PartPictureViewer";
        private Boolean bPartSearch = false;
        private Boolean bShowZoomButton = true;
        private Boolean bShowFullScreenButton = true;
        private Boolean bShowPartNumberLink = false;
        private Boolean bDisablePartLink = false;
        private Boolean is_cofc = false;
        private String sCaption = "Rz Picture Viewer";
        protected virtual void LinksShow()
        {
            if (Tools.Strings.StrExt(fullpartnumber))
                lblLinks.Text = "Part# : " + fullpartnumber;
            else
                lblLinks.Text = "";
        }
        private string DefaultPath
        {
            get
            {
                return n_set.GetSetting(RzWin.Context, "camera_picture_default_path");
            }
            set
            {
                if (!Tools.Strings.StrExt(value))
                    value = nTools.GetDriveLetter() + ":\\";
                if (!System.IO.Directory.Exists(value))
                    value = nTools.GetDriveLetter() + ":\\";
                RzWin.Context.SetSetting("camera_picture_default_path", Tools.Folder.ConditionFolderName(value));
            }
        }
        public String SelectID = "";

        //Construtors
        public PartPictureViewer()
        {
            try
            {
                InitializeComponent();
            }
            catch { }

        }
        //Public Functions
        public void CompleteLoad()
        {
            lvPictures.SuppressSelectionChanged = true;
            CompleteLoad(false);
        }
        public void CompleteLoad(bool cofc)
        {
            if (RzWin.Context == null)
                return;

            is_cofc = cofc;
            CreateNewPartPicture();

            lvPictures.ShowTemplate(templatename, "partpicture", RzWin.User.TemplateEditor);
            lvPictures.AlternateConnection = RzWin.Logic.PictureData;
            DoResize();

            String strWatchFolder = GetWatchFolder();
            if (System.IO.Directory.Exists(strWatchFolder))
            {
                chkAutoWatch.Checked = true;
            }

        }
        void CompleteDispose()
        {
            try
            {
                this.lblPartNumber.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPartNumber_LinkClicked);
                this.lvPictures.ObjectClicked -= new NewMethod.ObjectClickHandler(this.lvPictures_ObjectClicked);
                this.lvPictures.AboutToThrow -= new Core.ShowHandler(this.lvPictures_AboutToThrow);
                this.lvPictures.FinishedFill -= new NewMethod.FillHandler(this.lvPictures_FinishedFill);
                this.cmdFullScreen.Click -= new System.EventHandler(this.cmdFullScreen_Click);
                this.cmdZoom.Click -= new System.EventHandler(this.cmdZoom_Click);
                this.mnuSave.Click -= new System.EventHandler(this.mnuSave_Click);
                this.mnuEmail.Click -= new System.EventHandler(this.mnuEmail_Click);
                this.mnuOpen.Click -= new System.EventHandler(this.mnuOpen_Click);
                this.cmdUpdatePicture.Click -= new System.EventHandler(this.cmdUpdatePicture_Click);
                this.cmdDeletePicture.Click -= new System.EventHandler(this.cmdDeletePicture_Click);
                this.cmdAddPicture.Click -= new System.EventHandler(this.cmdAddPicture_Click);
                this.cmdBrowse.Click -= new System.EventHandler(this.cmdBrowse_Click);
                this.cmdUnZoom.Click -= new System.EventHandler(this.cmdUnZoom_Click);
                this.chkAutoWatch.CheckedChanged -= new System.EventHandler(this.chkAutoWatch_CheckedChanged);
                this.fsw.Created -= new System.IO.FileSystemEventHandler(this.fsw_Created);
                this.cmdGrab.Click -= new System.EventHandler(this.cmdGrab_Click);
                this.toolStripMenuItem1.Click -= new System.EventHandler(this.toolStripMenuItem1_Click);
                this.Resize -= new System.EventHandler(this.PartPictureViewer_Resize);
            }
            catch { }
        }
        public String Caption
        {
            get
            {
                return sCaption;
            }
            set
            {
                sCaption = value;
            }
        }
        public Boolean DisablePartLink
        {
            get
            {
                return bDisablePartLink;
            }
            set
            {
                bDisablePartLink = value;
                DoResize();
            }
        }
        public Boolean ShowPartSearch
        {
            get
            {
                return bPartSearch;
            }
            set
            {
                bPartSearch = value;
                DoResize();
            }
        }
        public Boolean ShowZoomButton
        {
            get
            {
                return bShowZoomButton;
            }
            set
            {
                bShowZoomButton = value;
                DoResize();
            }
        }
        public Boolean ShowFullScreenButton
        {
            get
            {
                return bShowFullScreenButton;
            }
            set
            {
                bShowFullScreenButton = value;
                DoResize();
            }
        }
        public Boolean ShowPartNumberLink
        {
            get
            {
                return bShowPartNumberLink;
            }
            set
            {
                bShowPartNumberLink = value;
                DoResize();
            }
        }
        public String TemplateName
        {
            get
            {
                return templatename;
            }
            set
            {
                templatename = value;
            }
        }
        public void DoResize()
        {
            try
            {
                //Boolean bDoNotShowButtons = false;
                //cmdBrowse.Enabled = true;
                if (this.Width < 360)
                    this.Width = 360;
                //if (this.Height < 275)
                //{
                //    bDoNotShowButtons = true;
                //    cmdBrowse.Enabled = false; 
                //    if (this.Height < 215)
                //        this.Height = 215;
                //}
                //SetBorder();
                //if (bDoNotShowButtons)
                //{
                //    cmdDeletePicture.Visible = true;
                //    cmdAddPicture.Visible = true;
                //    cmdUpdatePicture.Visible = true;
                //    cmdDeletePicture.Top = this.Height - pbBottom.Height;
                //}
                //else
                //{
                //    cmdDeletePicture.Visible = true;
                //    cmdAddPicture.Visible = true;
                //    cmdUpdatePicture.Visible = true;
                //    cmdDeletePicture.Top = this.Height - ((cmdDeletePicture.Height + pbBottom.Height) + 5);
                //}

                pOptions.Left = 0;
                pOptions.Width = this.ClientRectangle.Width;
                pOptions.Top = this.ClientRectangle.Height - pOptions.Height;

                //cmdDeletePicture.Left = pbLeft.Right + 10;
                //cmdUpdatePicture.Top = cmdDeletePicture.Top;
                //cmdUpdatePicture.Left = pbRight.Left - (cmdUpdatePicture.Width + 10);
                //Int32 width = ((cmdUpdatePicture.Right - cmdDeletePicture.Left) - 20) / 3;
                //cmdDeletePicture.Width = width;
                //cmdUpdatePicture.Width = width;
                //cmdAddPicture.Width = width;
                //cmdAddPicture.Top = cmdDeletePicture.Top;
                //width = ((cmdUpdatePicture.Left - cmdDeletePicture.Right) - cmdAddPicture.Width) / 2;
                //cmdAddPicture.Left = cmdDeletePicture.Right + width;
                //txtComments.Top = cmdDeletePicture.Top - (txtComments.Height + 5);
                //lblComments.Top = txtComments.Top + 2;
                //lblComments.Left = pbLeft.Right;
                //txtComments.Left = lblComments.Right;
                //txtComments.Width = this.Width - (txtComments.Left + (pbRight.Width + 2));
                //lblFileName.Top = lblComments.Top - (lblFileName.Height + 10);
                //lblFileName.Left = lblComments.Left;
                //txtFileName.Top = lblFileName.Top - 2;
                //txtFileName.Left = lblFileName.Right;
                //cmdBrowse.Top = txtFileName.Top;
                //cmdBrowse.Left = this.Width - (cmdBrowse.Width + pbRight.Width);
                //lnkDefaultPath.Top = cmdBrowse.Bottom - 4;
                //lnkDefaultPath.Left = cmdBrowse.Left - 4;
                //txtFileName.Width = cmdBrowse.Left - txtFileName.Left;
                if (bShowFullScreenButton)
                {
                    cmdFullScreen.Visible = true;
                    cmdFullScreen.Top = picPicture.Top;
                    cmdFullScreen.Left = picPicture.Right - cmdFullScreen.Width;
                }
                else
                    cmdFullScreen.Visible = false;
                if (bShowZoomButton && bShowFullScreenButton)
                {
                    cmdZoom.Visible = true;
                    cmdZoom.Top = cmdFullScreen.Top;
                    cmdZoom.Left = cmdFullScreen.Left - (cmdZoom.Width);
                }
                else if (bShowZoomButton && !bShowFullScreenButton)
                {
                    cmdZoom.Visible = true;
                    cmdZoom.Top = picPicture.Top;
                    cmdZoom.Left = picPicture.Right - cmdZoom.Width;
                }
                else
                    cmdZoom.Visible = false;
                if (bShowPartNumberLink)
                {
                    lblPartNumber.Top = 0;
                    lblPartNumber.Left = 0;
                    lblPartNumber.Width = this.Width;
                    lblPartNumber.Visible = true;
                }
                else
                {
                    lblPartNumber.Top = 0 - (lblPartNumber.Height - 5);
                    lblPartNumber.Left = 0;
                    lblPartNumber.Width = this.Width;
                    lblPartNumber.Visible = false;
                }
                lvPictures.Top = lblPartNumber.Bottom;
                picPicture.Top = lvPictures.Top;

                //int width = (this.Width - (pbLeft.Width * 2)) / 2;

                int width = this.ClientRectangle.Width / 2;

                lvPictures.Left = 0;
                lvPictures.Width = width - 2;
                picPicture.Left = lvPictures.Right;
                picPicture.Width = this.ClientRectangle.Width - picPicture.Left;
                lvPictures.Height = this.ClientRectangle.Height - (pOptions.Height + lvPictures.Top);
                picPicture.Height = this.ClientRectangle.Height - (pOptions.Height + picPicture.Top);

                chkAutoWatch.Left = picPicture.Left;
                chkAutoWatch.Top = picPicture.Bottom;

                cmdGrab.Left = chkAutoWatch.Right;
                cmdGrab.Top = chkAutoWatch.Top;

                lvPictures.DoResize();
                picZoomView.Top = 0;
                picZoomView.Left = 0;
                picZoomView.Width = this.Width;
                picZoomView.Height = this.Height;
                cmdUnZoom.Top = 0;
                cmdUnZoom.Left = this.ClientRectangle.Width - (cmdUnZoom.Width);
                picZoomView.BringToFront();
                cmdUnZoom.BringToFront();
            }
            catch (Exception)
            { }
        }
        public void LoadViewBy(nObject n)
        {
            LoadViewBy(n, "");
        }
        public static string GetShowWhereClause()
        {
            return "";
        }
        public virtual void LoadViewBy(nObject n, String SQL)
        {
            String sWhere = "";
            if (n != null)
            {
                viewby = n;
                try
                {
                    switch (n.ClassId.ToLower())
                    {
                        case "qualitycontrol":
                            qualitycontrol qc = (qualitycontrol)n;
                            sWhere = "the_qualitycontrol_uid = '" + qc.unique_id + "'";
                            the_company_uid = qc.the_company_uid;
                            the_companycontact_uid = qc.the_companycontact_uid;
                            the_orddet_uid = qc.the_orddet_uid;
                            the_partrecord_uid = qc.the_partrecord_uid;
                            the_qualitycontrol_uid = qc.unique_id;
                            fullpartnumber = qc.fullpartnumber;
                            break;
                        case "partrecord":
                            partrecord part = (partrecord)n;
                            sWhere = "the_partrecord_uid = '" + part.unique_id + "'";
                            the_company_uid = part.base_company_uid;
                            the_companycontact_uid = part.base_companycontact_uid;
                            the_orddet_uid = "";
                            the_partrecord_uid = part.unique_id;
                            the_qualitycontrol_uid = "";
                            fullpartnumber = part.fullpartnumber;
                            break;
                        case "partpicture":
                            partpicture pic = (partpicture)n;
                            String strPart = pic.fullpartnumber;
                            if (!Tools.Strings.StrExt(strPart))
                                break;
                            strPart = PartObject.StripPart(strPart);
                            sWhere = "prefix + basenumberstripped = '" + strPart + "'";
                            if (!Tools.Strings.StrExt(sWhere))
                                break;
                            the_company_uid = "";
                            the_companycontact_uid = "";
                            the_orddet_uid = "";
                            the_partrecord_uid = "";
                            the_qualitycontrol_uid = "";
                            fullpartnumber = pic.fullpartnumber;
                            break;
                        case "company":
                            bShowPartNumberLink = false;
                            company comp = (company)n;
                            sWhere = "the_company_uid = '" + comp.unique_id + "' AND LENGTH(the_ordhed_uid) <= 0"; //Company level only
                            the_company_uid = comp.unique_id;
                            the_companycontact_uid = "";
                            the_orddet_uid = "";
                            the_partrecord_uid = "";
                            the_qualitycontrol_uid = "";
                            fullpartnumber = "";
                            DoResize();
                            break;
                        case "companycontact":
                            bShowPartNumberLink = false;
                            companycontact cont = (companycontact)n;
                            sWhere = "the_companycontact_uid = '" + cont.unique_id + "'";
                            the_company_uid = cont.base_company_uid;
                            the_companycontact_uid = cont.unique_id;
                            the_orddet_uid = "";
                            the_partrecord_uid = "";
                            the_qualitycontrol_uid = "";
                            fullpartnumber = "";
                            DoResize();
                            break;
                        case "usernote":  //i realize this is a hack, but we need a way to link to attachments without partpicture having a field for every class
                            bShowPartNumberLink = false;
                            sWhere = "the_orddet_uid = '" + n.unique_id + "'";
                            the_orddet_uid = n.unique_id;
                            the_company_uid = "";
                            the_companycontact_uid = "";
                            the_partrecord_uid = "";
                            the_qualitycontrol_uid = "";
                            fullpartnumber = "";
                            DoResize();
                            break;
                        case "dealheader":  //i realize this is a hack, but we need a way to link to attachments without partpicture having a field for every class
                            bShowPartNumberLink = false;
                            sWhere = "the_ordhed_uid = '" + n.unique_id + "'";
                            the_ordhed_uid = n.unique_id;
                            the_company_uid = "";
                            the_companycontact_uid = "";
                            the_partrecord_uid = "";
                            the_qualitycontrol_uid = "";
                            fullpartnumber = "";
                            DoResize();
                            break;
                        default:
                            if (n.ClassId.ToLower().StartsWith("ordhed"))
                            {
                                ordhed hed = (ordhed)n;
                                //sWhere = "the_orddet_uid in (select unique_id from " + ordhed.MakeOrddetName(hed.OrderType) + " where base_ordhed_uid = '" + hed.unique_id + "')";
                                //sWhere = "the_ordhed_uid = '" + hed.unique_id + "'";

                                //2010_03_18  switched to include both options

                                //2010_03_22 switch to include the specific ids without the subquery, since the pics db can be separate

                                //2011_04_20 switch to get the detail ids regardless of ordhed_old or ordhed_new

                                List<String> ordhed_ids = new List<string>();
                                ordhed_ids.Add(hed.unique_id);
                                if (hed.OrderType == Enums.OrderType.Sales)
                                    foreach (ordlnk l in hed.LinksToVar.RefsList(RzWin.Context))
                                    {

                                        if (l.OrderType1 == Enums.OrderType.Quote)
                                            if (!ordhed_ids.Contains(l.orderid1))
                                                ordhed_ids.Add(l.orderid1);

                                    }
                                else if (hed.OrderType == Enums.OrderType.Invoice)
                                    foreach (ordlnk l in hed.LinksToVar.RefsList(RzWin.Context))
                                    {

                                        if (l.OrderType1 == Enums.OrderType.Quote)
                                            if (!ordhed_ids.Contains(l.orderid1))
                                                ordhed_ids.Add(l.orderid1);
                                        if (l.OrderType1 == Enums.OrderType.Sales)
                                            if (!ordhed_ids.Contains(l.orderid1))
                                                ordhed_ids.Add(l.orderid1);

                                    }
                                //foreach (orddet d in hed.Details.RefsGetAsItems(RzWin.Context).AllGet(RzWin.Context))
                                //{
                                //    ids.Add(d.unique_id);
                                //}

                                //string in_sql = nTools.GetIn(Rz3App.SelectScalarArray("select unique_id from orddet_line where orderid_" + hed.ordertype + " = '" + hed.unique_id + "'"));
                                List<String> line_ids = new List<string>();
                                if (hed is ordhed_quote)
                                {
                                    foreach (orddet_quote l in hed.DetailsList(RzWin.Context))
                                    {
                                        if (!line_ids.Contains(l.unique_id))
                                            line_ids.Add(l.unique_id);
                                    }
                                    sWhere = " ( the_ordhed_uid in (" + Tools.Data.GetIn(ordhed_ids) + ") OR the_orddet_uid in (" + Tools.Data.GetIn(line_ids) + ")) ";
                                }
                                else if (hed is ordhed_new)
                                {
                                    foreach (orddet_line l in hed.DetailsList(RzWin.Context))
                                    {
                                        if (!line_ids.Contains(l.unique_id))
                                            line_ids.Add(l.unique_id);
                                    }
                                    sWhere = " ( the_ordhed_uid in (" + Tools.Data.GetIn(ordhed_ids) + ") OR the_orddet_uid in (" + Tools.Data.GetIn(line_ids) + ")) ";

                                }




                                //if (ids.Count == 0)
                                //    sWhere = " ( the_ordhed_uid = '" + hed.unique_id + "' )";
                                //else
                                //    sWhere = " ( the_ordhed_uid = '" + hed.unique_id + "' or the_orddet_uid in ( " + Tools.Data.GetIn(ids) + " ) ";

                                try
                                {
                                    fullpartnumber = "";
                                    the_company_uid = hed.base_company_uid;
                                    the_companycontact_uid = hed.base_companycontact_uid;
                                    the_ordhed_uid = hed.unique_id;
                                    the_partrecord_uid = "";
                                    the_qualitycontrol_uid = "";
                                }
                                catch (Exception)
                                { }
                            }
                            else if (n.ClassId.ToLower().StartsWith("orddet"))
                            {
                                orddet det = (orddet)n;
                                sWhere = "the_orddet_uid = '" + det.unique_id + "'";
                                the_orddet_uid = n.unique_id;

                                if (det is orddet_old)
                                {
                                    try
                                    {
                                        the_ordhed_uid = ((orddet_old)det).base_ordhed_uid;
                                    }
                                    catch
                                    { }
                                }

                                fullpartnumber = det.fullpartnumber;

                                //if (det is orddet_line)
                                //{
                                //    try
                                //    {
                                //        the_ordhed_uid = ((orddet_line)det).OrderIdGet(
                                //    }
                                //    catch
                                //    { }
                                //}

                                //try
                                //{
                                //    
                                //    ordhed h = det.OrderObject;
                                //    if (h != null)
                                //    {
                                //        the_company_uid = det.GetOrderObject().base_company_uid;
                                //        the_companycontact_uid = det.GetOrderObject().base_companycontact_uid;
                                //    }
                                //    the_orddet_uid = det.unique_id;
                                //    the_ordhed_uid = det.base_ordhed_uid;

                                //    partrecord p = det.LinkedPart;
                                //    if (p != null)
                                //        the_partrecord_uid = p.unique_id;

                                //    the_qualitycontrol_uid = "";
                                //}
                                //catch (Exception)
                                //{ }
                            }
                            break;
                    }
                    String orderby = "date_created desc";
                    if (Tools.Strings.StrExt(SQL))
                    {
                        sWhere = GetWhereClause(SQL);
                        orderby = GetOrderByClause(SQL);
                    }
                    if (Tools.Strings.StrExt(sWhere))
                    {
                        if (is_cofc)
                            sWhere += " and is_cofc = 'true'";

                        if (Tools.Strings.StrExt(DescriptionTag))
                            sWhere += " and description like '%(" + RzWin.Context.Filter(DescriptionTag) + ")%'";

                        if (Tools.Strings.StrExt(DescriptionTagExclude))
                        {
                            sWhere += " and description not like '%(" + RzWin.Context.Filter(DescriptionTagExclude) + ")%'";
                            if (Tools.Strings.StrExt(DescriptionTagExclude2))
                                sWhere += " and description not like '%(" + RzWin.Context.Filter(DescriptionTagExclude2) + ")%'";
                        }

                        lvPictures.ShowData("partpicture", sWhere, orderby, 200);
                    }
                }
                catch (Exception ex)
                {

                    RzWin.Leader.Tell(ex.Message);
                }
                lblPartNumber.Text = fullpartnumber;
                bShowFirst = false;
                cmdAddPicture.Enabled = true;
            }
        }
        public void LoadViewByExactPic(partpicture pic)
        {
            lvPictures.ShowData("partpicture", "unique_id = '" + pic.unique_id + "'", "", 200);
            xPartPic = pic;
            ShowPartPicture();
        }
        public void LoadView(String where)
        {
            CompleteLoad();
            lvPictures.ShowData("partpicture", where, "description", 200);
        }
        public ArrayList GetPictureCollection()
        {
            try
            {
                String SQL = lvPictures.CurrentSQL;
                string[] s = Tools.Strings.Split(SQL.ToLower(), "from");
                SQL = "";
                if (s.Length > 2)
                {
                    for (Int32 i = 1; i < s.Length; i++)
                    {
                        if (i == 1)
                            SQL = " " + s[i];
                        else
                            SQL = SQL + " from " + s[i];
                    }
                }
                else
                {
                    SQL = s[1];
                }
                SQL = "select * from " + SQL;
                ArrayList a = new ArrayList();
                foreach (partpicture p in ((ContextRz)RzWin.Context).QtC("partpicture", SQL))
                {
                    a.Add(p);
                }
                return a;
            }
            catch (Exception e)
            { return null; }
        }
        public PartPictureViewer GetClone()
        {
            PartPictureViewer p = new PartPictureViewer();
            p.ShowPartSearch = bPartSearch;
            p.ShowFullScreenButton = bShowFullScreenButton;
            p.ShowZoomButton = bShowZoomButton;
            p.ShowPartNumberLink = bShowPartNumberLink;
            p.DisablePartLink = bDisablePartLink;
            p.CompleteLoad();
            p.LoadViewBy(this.viewby);
            p.SelectID = xPartPic.unique_id;
            p.TemplateName = templatename;
            p.Caption = sCaption;
            return p;
        }
        //Private Functions
        private void BrowseForFile()
        {
            string currentFile = "";
            try
            {
                oFile.Filter = "Image / PDF / Word Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png,*.pdf,*.doc,*.docx)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png;*.pdf;*.doc;*.docx|All Files (*.*)|*.*";
                oFile.FileName = "";
                if (System.IO.Directory.Exists(DefaultPath))
                    oFile.InitialDirectory = DefaultPath;
                DialogResult dr = oFile.ShowDialog();
                if (dr.Equals(DialogResult.Cancel))
                    return;
                if (!Tools.Strings.StrExt(oFile.FileName))
                    return;
                //Eliminate spaces, can be an issue with loading via HTTP
                //oFile.FileName = oFile.FileName.Replace(" ", "_");
                //bool auto_save = oFile.FileNames.Length > 1;
                //bool auto_save = true;
                int completed = 0;
                int count = oFile.FileNames.Length;
                RzWin.Context.TheLeader.StartPopStatus("Uploading " + count + " files.");

                foreach (string file in oFile.FileNames)
                {
                    currentFile = file;


                    //if (auto_save)
                    NewPicture();
                    txtFileName.Text = file;
                    if (partpicture.IsPictureFileName(oFile.FileName.Trim().ToUpper()))
                    {
                        if (xPartPic.SetPictureDataByFile(((ContextRz)RzWin.Context), txtFileName.Text.Trim()))
                            picPicture.Image = xPartPic.GetPictureImage(RzWin.Context, picPicture.Width, picPicture.Height);
                    }
                    else
                    {
                        if (xPartPic.SetDocDataByFile((ContextRz)RzWin.Context, txtFileName.Text.Trim()))
                        {
                            picPicture.Image = xPartPic.GetPictureImage(RzWin.Context, picPicture.Width, picPicture.Height);

                        }

                    }

                    if (string.IsNullOrEmpty(xPartPic.file_path))
                    {
                        xPartPic.Delete(RzWin.Context);
                        throw new Exception("Destination File Path not found.  Picture NOT saved");
                    }

                    //This requires permissions to lookup UNC.  If this is needed, consider FTP.
                    //if (!File.Exists(xPartPic.file_path))
                    //{
                    //    xPartPic.Delete(RzWin.Context);
                    //    throw new Exception("File path exists, but file not found at destination.  Picture NOT saved");
                    //}


                    txtComments.Text = Tools.Files.GetFileNameNoExtention(file);
                    SavePicture(false);
                    completed++;
                    RzWin.Context.TheLeader.Comment(file + " successfully uploaded.");
                }

                lvPictures.ReDoSearch();
                RzWin.Context.TheLeader.Comment(completed + " file(s) successfully uploaded.");
                RzWin.Context.TheLeader.StopPopStatus(true);

            }
            catch (Exception ex)
            {
                RzWin.Context.TheLeader.StopPopStatus(true);
                RzWin.Context.TheLeader.Comment("Error at " + currentFile, Color.Red);
                RzWin.Context.Error(ex.Message + Environment.NewLine + ex.InnerException);
            }
        }
        //public void AddByImage(Image i, String caption)
        //{
        //    NewPicture();
        //    xPartPic.SetPictureDataByImage((ContextRz)RzWin.Context, i, "");
        //    txtFileName.Text = caption;
        //    SavePicture();
        //}
        private void ShowFirstPicture()
        {
            lvPictures.SelectFirst();
            partpicture p = (partpicture)lvPictures.GetSelectedObject();
            if (p == null)
                CreateNewPartPicture();
            else
                xPartPic = p;
            ShowPartPicture();
        }
        private void ShowPartPicture()
        {
            try
            {
                txtFileName.Text = xPartPic.filename;
                txtComments.Text = xPartPic.description;
                if (!xPartPic.LoadPictureData(RzWin.Context))
                {
                   
                    //if (RzWin.Leader.AskYesNo("The picture data could not be loaded, would you like to delete this from the attachments list so it can be re-added?"))
                    //{
                    //    //CompleteLoad(false);
                    //    xPartPic.Delete(RzWin.Context);                        
                    //}
                        
                    //throw new Exception("Failed to load attachment.");
                    return;


                }

                if (!string.IsNullOrEmpty(xPartPic.file_path))
                    //picPicture.Image = xPartPic.GetPictureImage(RzWin.Context, picPicture.Width, picPicture.Height);
                    picPicture.Image = xPartPic.GetPictureImageFromPath(RzWin.Context, picPicture.Width, picPicture.Height);
                else
                    picPicture.Image = null;
                cmdDeletePicture.Enabled = true;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }

        }
        private void DeleteSelectedPictures()
        {
            if (!RzWin.Leader.AskYesNo("You are about to delete the selected attachment entry(s). Ok to continue?"))
                return;
            if (xPartPic == null)
                return;
            foreach (partpicture p in lvPictures.GetSelectedObjects())
            {
                picPicture.Dispose();
                picPicture.Image = null;
                //xPartPic.picturedata = null;
                p.DeletePicture(RzWin.Context);
            }

            lvPictures.ReDoSearch();
            CreateNewPartPicture();
            //ShowPartPicture();
            txtFileName.Text = "";
            txtComments.Text = "";
            lblPartNumber.Text = "";
            PictureWasDeleted();
        }
        private void ZoomPicture()
        {
            if (cmdUnZoom.Visible)
            {
                cmdUnZoom.Visible = false;
                picZoomView.Visible = false;
                picZoomView.Image = null;
            }
            else
            {
                cmdUnZoom.Visible = true;
                picZoomView.Image = picPicture.Image;
                picZoomView.Visible = true;
            }
        }
        private void FullScreenPic()
        {
            try
            {
                frmPartPictureViewer fPart = new frmPartPictureViewer();
                fPart.WindowState = FormWindowState.Maximized;
                PartPictureViewer p = GetClone();
                p.ShowFullScreenButton = false;
                fPart.CompleteLoad(p);
                fPart.ShowDialog();
            }
            catch (Exception)
            { }
        }
        private void NewPicture()
        {
            //if (!RzWin.Leader.AskYesNo("You are about to create a new picture to add. This will erase any current unsaved data. Ok to continue?"))
            //    return;

            //Set Object uid linkage
            CreateNewPartPicture();
            //ShowPartPicture();
            txtFileName.Text = "";
            txtComments.Text = "";
            lblPartNumber.Text = "";
        }
        private void SavePicture()
        {
            SavePicture(true);
        }
        private void SavePicture(bool redo)
        {
            try
            {
                if (xPartPic == null)
                    CreateNewPartPicture();
                AssemblePartPic();





                if (AttachmentSave != null)
                    AttachmentSave(xPartPic);

                if (Tools.Strings.StrExt(DescriptionTag) && !xPartPic.description.Contains("(" + DescriptionTag + ")"))
                {
                    if (xPartPic.description != "")
                        xPartPic.description += " ";
                    xPartPic.description += "(" + DescriptionTag + ")";
                }

                if (xPartPic.unique_id == "")
                {
                    //if (!string.IsNullOrEmpty(the_ordhed_uid))
                    //{
                    //    //CHeck if this is a sales order or PO, if so, aske user if it's a component/inspection picture
                    //    List<string> OrderTypeCheckList = new List<string>() { "Rz5.ordhed_sales", "Rz5.ordhed_purchase" };
                    //    ordhed o = ordhed.GetById(RzWin.Context, the_ordhed_uid);
                    //    if (o != null)
                    //    {
                    //        if (OrderTypeCheckList.Contains(o.GetType().ToString()))
                    //        {
                    //            if (RzWin.Leader.AskYesNo("Are you trying to upload part imagery (Inspections, etc.)"))
                    //            {
                    //                RzWin.Leader.Tell("In order to associate this image with the part, please open the actual line item you are uploading images for, and use the attachments section on the line item to upload.");
                    //                return;
                    //            }

                    //        }
                    //    }
                    //}
                    xPartPic.InsertTo(RzWin.Context, RzWin.Logic.PictureData);
                }
                else
                    xPartPic.UpdateTo(RzWin.Context, RzWin.Logic.PictureData);


                //This one's an update, insert happened above.
                if (!xPartPic.SavePictureData(((ContextRz)RzWin.Context)))
                {
                    //does the telling through the leader now in SavePictureData
                    //RzWin.Leader.Tell("There was an error saving the attachment info.");
                    return;
                }

                ShowPartPicture();
                PictureWasAdded();
                if (redo)
                    lvPictures.ReDoSearch();

                cmdDeletePicture.Enabled = true;
                cmdAddPicture.Enabled = true;

            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
        }



        private void AssemblePartPic()
        {
            xPartPic.filename = GetFileName();
            String ext = Path.GetExtension(txtFileName.Text);
            if (Tools.Strings.StrExt(ext))
                xPartPic.filetype = ext;
            xPartPic.description = txtComments.Text;
        }
        private String GetFileName()
        {
            //String hold = txtFileName.Text.Trim();  //.Replace(".pdf", "-pdf.pdf").Replace(".doc", "-doc.doc");
            //if (hold.Contains(":") && hold.Contains("\\"))
            //{
            //    string[] s = Tools.Strings.Split(hold, "\\");
            //    hold = s[(s.Length-1)].Trim();
            //    s = Tools.Strings.Split(hold, ".");
            //    hold = s[0];
            //}
            //return hold;
            return Path.GetFileNameWithoutExtension(txtFileName.Text);
        }
        protected virtual void CreateNewPartPicture()
        {
            if (RzWin.Context == null)
                return;

            xPartPic = partpicture.New(RzWin.Context);  // new partpicture(((ContextRz)RzWin.Context).xSys);
            xPartPic.the_company_uid = the_company_uid;
            xPartPic.the_companycontact_uid = the_companycontact_uid;
            xPartPic.the_ordhed_uid = the_ordhed_uid;
            xPartPic.the_orddet_uid = the_orddet_uid;
            xPartPic.the_partrecord_uid = the_partrecord_uid;
            xPartPic.the_qualitycontrol_uid = the_qualitycontrol_uid;
            xPartPic.fullpartnumber = fullpartnumber;
            PartObject.ParsePartNumber(xPartPic);
        }
        private String GetWhereClause(String SQL)
        {
            try
            {
                if (!Tools.Strings.StrExt(SQL))
                    return "";
                string[] s = Tools.Strings.Split(SQL.ToLower(), "where");
                SQL = "";
                if (s.Length > 2)
                {
                    for (Int32 i = 1; i < s.Length; i++)
                    {
                        if (i == 1)
                            SQL = " " + s[i];
                        else
                            SQL = SQL + " where " + s[i];
                    }
                }
                else
                {
                    SQL = s[1];
                }
                s = Tools.Strings.Split(SQL, "order by");
                if (s.Length <= 0)
                    return SQL;
                if (s.Length >= 1)
                    return s[0].Trim();
                else
                    return "";
            }
            catch (Exception)
            { return ""; }
        }
        private String GetOrderByClause(String SQL)
        {
            if (!Tools.Strings.StrExt(SQL))
                return "";
            string[] s = Tools.Strings.Split(SQL, "order by");
            if (s.Length <= 0)
                return "";
            if (s.Length > 1)
                return s[1].Trim();
            else
                return "";
        }
        private void LoadSelectedPicture()
        {

            partpicture p = (partpicture)lvPictures.GetSelectedObject();
            if (p == null)
                return;
            xPartPic = p;
            ShowPartPicture();
        }
        private Boolean SavePictureAs()
        {
            try
            {
                //Image picture = picPicture.Image;
                //if (picture == null)
                //    return false;
                //if (xPartPic == null)
                //    return false;
                //String path = SaveImageToJPG(true, xPartPic.filename, picture);
                //return Tools.Strings.StrExt(path);

                if (xPartPic == null)
                    return false;
                sFile.FileName = xPartPic.filename + xPartPic.filetype;
                DialogResult dr = sFile.ShowDialog(this.ParentForm);
                if (dr.Equals(DialogResult.Cancel))
                    return false;

                String filename = sFile.FileName;

                return SavePictureAs(filename);
            }
            catch (Exception)
            { return false; }
        }
        private bool SavePictureAs(String filename)
        {
            xPartPic.SaveDataAsFile(RzWin.Context, filename);
            return Tools.FileSystem.Shell(filename);
        }
        private Boolean EmailPictureTo()
        {
            try
            {
                Image picture = picPicture.Image;
                if (picture == null)
                {
                    RzWin.Leader.Tell("The attachment is not available");
                    return false;
                }
                String attach = SaveImageToJPG(false, "", picture);
                if (!System.IO.File.Exists(attach))
                {
                    RzWin.Leader.Tell("The attachment could not be converted to the .jpg format.");
                    return false;
                }
                String err = "";
                //ToolsOffice.OutlookOffice.SendOutlookMessage("", "", "", false, true, "", attach, false, null, "", "", "", "", ref err);
                //context.TheSysRz.TheEmailLogic.SendOutlookEmail(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, true, ref err);

                //System.IO.File.Delete(attach); 
                return true;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error: " + ex.Message);
                return false;
            }
        }
        private String SaveImageToJPG(Boolean bSaveAs, String filename, Image im)
        {
            try
            {
                if (bSaveAs)
                {
                    sFile.FileName = filename;
                    DialogResult dr = sFile.ShowDialog(this.ParentForm);
                    if (dr.Equals(DialogResult.Cancel))
                        return "";
                    filename = sFile.FileName;
                    im.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    filename = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "rz_" + Tools.Strings.GetNewID() + ".jpg";
                    im.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return filename;
            }
            catch (Exception)
            { return ""; }
        }
        private String GetWatchFolder()
        {
            String s = "";
            if (ToolsWin.Keyboard.GetControlKey())
            {
                s = ToolsWin.FileSystem.ChooseAFolder();
                if (System.IO.Directory.Exists(s))
                {
                    if (RzWin.Leader.AreYouSure("set the watch folder to " + s))
                    {
                        ((ContextRz)RzWin.Context).SetSetting("picture_watch_folder_" + System.Environment.MachineName, s);
                    }
                }
            }

            s = ((ContextRz)RzWin.Context).GetSetting("picture_watch_folder_" + System.Environment.MachineName);
            return s;
        }
        private void PictureWasAdded()
        {
            if (PictureAdded != null)
                PictureAdded();
        }
        private void PictureWasDeleted()
        {
            if (PictureRemoved != null)
                PictureRemoved();
        }
        private void SetDefaultPath()
        {
            try
            {
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.SelectedPath = DefaultPath;
                DialogResult dr = f.ShowDialog();
                if (dr == DialogResult.Cancel)
                    return;
                DefaultPath = f.SelectedPath;
            }
            catch { }
        }
        //private bool IsPictureImage(string file)
        //{
        //    try
        //    {
        //        switch(Tools.Files.GetFileExtention(file).ToLower())
        //        {
        //            case "gif":
        //            case "jpg":
        //            case "jpeg":
        //            case "bmp":
        //            case "wmf":
        //            case "png":
        //                return true;
        //            default:
        //                return false;
        //        }
        //    }
        //    catch { }
        //    return false;
        //}
        private void ShowAttachment()
        {
            try
            {
                if (xPartPic == null)
                    return;
                xPartPic.OpenFile(RzWin.Context);
            }
            catch { }
        }
        //Buttons
        private void cmdZoom_Click(object sender, EventArgs e)
        {
            ZoomPicture();
        }
        private void cmdFullScreen_Click(object sender, EventArgs e)
        {
            FullScreenPic();
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            BrowseForFile();
        }
        private void cmdDeletePicture_Click(object sender, EventArgs e)
        {
            DeleteSelectedPictures();
        }
        private void cmdAddPicture_Click(object sender, EventArgs e)
        {
            NewPicture();
        }
        private void cmdUpdatePicture_Click(object sender, EventArgs e)
        {
            SavePicture();
        }
        private void cmdUnZoom_Click(object sender, EventArgs e)
        {
            ZoomPicture();
        }
        private void cmdGrab_Click(object sender, EventArgs e)
        {
            if (xPartPic != null)
                NewPicture();

            txtFileName.Text = (String)cmdGrab.Tag;
            if (xPartPic.SetPictureDataByFile(RzWin.Context, txtFileName.Text.Trim()))
                picPicture.Image = xPartPic.GetPictureImage(RzWin.Context, picPicture.Width, picPicture.Height);

            cmdGrab.Visible = false;
        }
        //Control Events
        private void PartPictureViewer_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lblPartNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (bDisablePartLink)
                return;
            if (Tools.Strings.StrExt(the_partrecord_uid))
                ((ContextRz)RzWin.Context).Show(partrecord.GetById(RzWin.Context, the_partrecord_uid));
        }
        private void lvPictures_AboutToThrow(object sender, ShowArgs args)
        {
            ShowAttachment();
            args.Handled = true;
        }
        private void lvPictures_FinishedFill(object sender)
        {
            if (bShowFirst)
            {
                ShowFirstPicture();
                bShowFirst = false;
            }
            //2010_07_19 this seems to be causing a lot of weird jumping around
            //if (Tools.Strings.StrExt(SelectID))
            //{
            //    lvPictures.ClearAllSelected();
            //    lvPictures.SelectIndex(lvPictures.GetIndexOfKey(SelectID.Trim()));
            //    LoadSelectedPicture();
            //}
        }
        private void lvPictures_ObjectClicked(object sender, ObjectClickArgs args)
        {
            LoadSelectedPicture();
        }
        private void chkAutoWatch_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAutoWatch.Checked)
                {
                    String strWatchFolder = GetWatchFolder();
                    if (!System.IO.Directory.Exists(strWatchFolder))
                        return;

                    fsw.Path = strWatchFolder;
                    fsw.EnableRaisingEvents = chkAutoWatch.Checked;
                }
                else
                {
                    fsw.EnableRaisingEvents = false;
                }
            }
            catch (Exception)
            { }
        }
        private void fsw_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            cmdGrab.Visible = true;
            cmdGrab.Tag = e.FullPath;
            cmdGrab.Text = System.IO.Path.GetFileName(e.FullPath);
        }
        private void lnkDefaultPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetDefaultPath();
        }
        //Menus
        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (SavePictureAs())
                RzWin.Leader.Tell("Saved.");
            //else
            //    RzWin.Leader.Tell("There was an error saving this picture.");
        }
        private void mnuEmail_Click(object sender, EventArgs e)
        {
            if (!EmailPictureTo())
                RzWin.Leader.Tell("There was an error emailing this attachment.");
        }
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (xPartPic == null)
                return;

            xPartPic.OpenFile(RzWin.Context);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolsWin.Clipboard.SetClip(lblPartNumber.Text);
        }
        private void cmdAddPicture_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])
              e.Data.GetData(DataFormats.FileDrop);
            //MemoryStream stream = (MemoryStream)
            //  data.GetData("Preferred DropEffect", true);
            //int flag = stream.ReadByte();
            //if (flag != 2 && flag != 5)
            //    return;
            //bool cut = (flag == 2);
            foreach (string file in files)
            {
                try
                {
                    NewPicture();

                    txtFileName.Text = file;
                    txtComments.Text = Path.GetFileNameWithoutExtension(file);
                    if (xPartPic.SetPictureDataByFile(RzWin.Context, txtFileName.Text.Trim()))
                        picPicture.Image = xPartPic.GetPictureImage(RzWin.Context, picPicture.Width, picPicture.Height);

                    SavePicture();
                }
                catch (IOException ex)
                {
                    RzWin.Context.Error("Error: " + ex.Message);
                }
            }
        }
        private void cmdAddPicture_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void picPicture_DoubleClick(object sender, EventArgs e)
        {
            if (xPartPic == null)
                return;

            String filename = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + xPartPic.filename + "_Rztemp" + xPartPic.filetype;
            SavePictureAs(filename);
        }
        public event AttachmentSaveHandler AttachmentSave;


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            int initialIndex = lvPictures.lv.SelectedIndices[0];
            int newIndex = initialIndex;
            if (keyData == Keys.Right || keyData == Keys.Down)
            {
                newIndex++;
            }
            if (keyData == Keys.Left || keyData == Keys.Up)
            {
                newIndex--;
            }

            if (newIndex < 0) newIndex = 0;
            if (newIndex > lvPictures.lv.Items.Count - 1)
                newIndex = lvPictures.lv.Items.Count - 1;


            //lvPictures.SelectIndex(idx);
            lvPictures.lv.Items[initialIndex].Selected = false;
            lvPictures.lv.Items[newIndex].Selected = true;
            LoadSelectedPicture();
            return true;
        }




    }

    public delegate void AttachmentSaveHandler(partpicture pic);
    public delegate void PictureAddedHandler();
    public delegate void PictureRemovedHandler();
}
