using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using Core;
using NewMethod;
using System.IO;
using System.Drawing.Imaging;

namespace Rz5
{
    public partial class DesignOptions : UserControl
    {
        //Public Startic Variables
        public static ArrayList CopiedDetails = null;
        //Public Variables
        public frmPrintedFormsPreview frmPreview;
        //Private Variables
        private printheader xHeader;
        private printdetail z_Detail;
        private List<printdetail> z_Details;
        private Object xFromObject;
        private Boolean bClosing = false;
        private Boolean bLoadFirst = false;
        private int lastchoice = -1;
        private bool inhibit = false;

        //Constructors
        public DesignOptions()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(Object parent)
        {
            xFromObject = parent;
            LV.ShowTemplate("PrintedFormsDesignerDetails", "printdetail", RzWin.User.TemplateEditor);
            ShowDesignerPreview();
            DoResize();
        }
        public void DoResize()
        {
            LV.DoResize();
            lvColumns.DoResize();
        }
        public void ShowDesignerTab(printheader header)
        {
            try
            {
                ArrayList a = header.AllDetails(RzWin.Context);  //forces the detail cache
                if (frmPreview != null)
                {
                    frmPreview.ShowDesignerTab(header, null);
                    frmPreview.PreviewClick += new PreviewClickHandler(frmPreview_PreviewClick);
                    frmPreview.PreviewBox += new PreviewBoxHandler(frmPreview_PreviewBox);
                }
                SetDesignerControlObject(header);
            }
            catch (Exception)
            { }
        }
        public void PreviewFormSet(frmPrintedFormsPreview f)
        {
            frmPreview = f;
            frmPreview.PreviewClick += new PreviewClickHandler(frmPreview_PreviewClick);
            frmPreview.PreviewBox += new PreviewBoxHandler(frmPreview_PreviewBox);
        }
        public void SetDesignerControlObject(printheader header)
        {
            if (header == null)
                return;
            xHeader = header;
            LoadHeader();
        }
        public void ShowDesignerPreview()
        {
            //frmPreview = new frmPrintedFormsPreview();
            //frmPreview.CompleteLoad(xSys, xFromObject);
            //frmPreview.FormBorderStyle = FormBorderStyle.FixedSingle;
            //frmPreview.WindowState = FormWindowState.Maximized;
            //frmPreview.Show();
            RegisterPreviewWithParent();
        }
        public void RefreshDesigner()
        {
            if (frmPreview != null)
            {
                SaveTemplate();
                frmPreview.RefreshDesigner(false);
            }
        }
        //Private Functions
        private void RefreshPreview()
        {
            if (frmPreview != null)
            {
                frmPreview.xHeader = xHeader;
                frmPreview.RefreshDesigner(xHeader, false);
            }
        }
        private void LoadHeader()
        {
            switch (xHeader.class_name)
            {
                case "telequip_ship":
                    switch (xHeader.printname)
                    {
                        case "Bill Of Lading":
                            lvColumns.ShowTemplate(xHeader.GetTemplateName(), "ship_carton", RzWin.User.TemplateEditor);
                            break;
                        default:
                            lvColumns.ShowTemplate(xHeader.GetTemplateName(), "telequip_ship_line", RzWin.User.TemplateEditor);
                            break;
                    }
                    break;
                case "pick_ticket":
                    switch (xHeader.printname)
                    {
                        case "Pick Ticket":
                            lvColumns.ShowTemplate(xHeader.GetTemplateName(), "pick_ticket_line", RzWin.User.TemplateEditor);
                            break;
                    }
                    break;
                default:
                    switch (xHeader.ordertype.ToLower().Trim())
                    {
                        case "ordhed_rfq":
                        case "ordhed_quote":
                        case "rfq":
                        case "quote":
                            lvColumns.ShowTemplate(xHeader.GetTemplateName(), ordhed.MakeOrddetName(RzLogic.ConvertOrderType(xHeader.ordertype)), RzWin.User.TemplateEditor);
                            break;
                        default:
                            lvColumns.ShowTemplate(xHeader.GetTemplateName(), "orddet_line", true);
                            break;
                    }
                    break;
            }

            lblTemplate.Text = xHeader.Name.Replace("Print Template", "").Trim();
            bLoadFirst = true;
            ArrayList a = xHeader.AllDetails(RzWin.Context);
            ShowDetails();
            //LV.ShowData("printdetail", "base_printheader_uid = '"+ xHeader.unique_id +"'", "detailtype desc", 200);
            ts.SelectedTab = tabCurrent;
            SetTemplateTab();
        }
        private void LoadDetail()
        {
            try
            {
                if (z_Detail == null)
                    return;
                SetDetailView();
                lblDetailName.Text = z_Detail.detailname;
                lblDetailType.Text = z_Detail.detailtype.ToUpper();
                txtStartX.Text = z_Detail.StartX.ToString();
                txtStartY.Text = z_Detail.StartY.ToString();
                txtXStart.Text = z_Detail.StartX.ToString();
                txtYStart.Text = z_Detail.StartY.ToString();
                txtMaxWidth.Text = z_Detail.max_width.ToString();
                txtFileName.Text = z_Detail.filename;
                ctlStyle.SetValue(z_Detail.style_info);
                txtFontColor.Text = nTools.GetColorFromInt((Int32)z_Detail.fontcolor).Name;
                switch (z_Detail.detailtype.ToLower())
                {
                    case "line":
                    case "box":
                        txtStopX.Text = z_Detail.StopX.ToString();
                        txtStopY.Text = z_Detail.StopY.ToString();
                        txtXStop.Text = z_Detail.StopX.ToString();
                        txtYStop.Text = z_Detail.StopY.ToString();
                        if (z_Detail.drawwidth > 0)
                            udLineWidth.Value = (Decimal)z_Detail.drawwidth;
                        break;
                    case "band":
                    case "headerband":
                        txtStopX.Text = z_Detail.StopX.ToString();
                        txtStopY.Text = z_Detail.StopY.ToString();
                        txtXStop.Text = z_Detail.StopX.ToString();
                        txtYStop.Text = z_Detail.StopY.ToString();
                        if (z_Detail.drawwidth > 0)
                            udLineWidth.Value = (Decimal)z_Detail.drawwidth;
                        lblFontName.Text = z_Detail.fontname;
                        chkFontBold.Checked = z_Detail.fontbold;
                        chkFontItalic.Checked = z_Detail.fontitalic == 0 ? false : true;
                        txtFontSize.Text = z_Detail.fontsize.ToString();
                        txtTextString.Text = z_Detail.textstring;
                        break;
                    default:
                        txtCenterX1.Text = z_Detail.centerx1.ToString();
                        txtCenterX2.Text = z_Detail.centerx2.ToString();
                        lblFontName.Text = z_Detail.fontname;
                        chkFontBold.Checked = z_Detail.fontbold;
                        chkFontItalic.Checked = z_Detail.fontitalic == 0 ? false : true;
                        txtFontSize.Text = z_Detail.fontsize.ToString();
                        txtTextString.Text = z_Detail.textstring;
                        break;

                }
                SetMovementView();
            }
            catch (Exception)
            { }
        }
        private void ShowDetails()
        {
            ItemsInstance items = new ItemsInstance();
            foreach (printdetail d in xHeader.AllDetails(RzWin.Context))
            {
                try
                {
                    items.Add(RzWin.Context, d);
                }
                catch (Exception ex)
                {
                    RzWin.Context.Leader.Tell(ex.Message);
                }
            }
            LV.Clear();
            LV.CollectionMode = true;
            LV.CurrentItems = items;
            LV.RefreshFromCollection();
        }
        private void SetTemplateTab()
        {
            if (xHeader != null)
            {
                txtPrintName.Text = xHeader.printname;
                txtPrintTag.Text = xHeader.printtag;
                txtPrintDescription.Text = xHeader.printdescription;
                txtClassName.Text = xHeader.class_name;
                txtCopyCount.Text = xHeader.copycount.ToString();
                cboOrderType.Text = xHeader.ordertype;
                cboPrinterName.Text = xHeader.printername;
                lblColHedFontText.Text = xHeader.colhedfont;
                txtColHedFontSize.Text = xHeader.colhedfontsize.ToString();
                chkColHedFontBold.Checked = xHeader.colhedfontbold;
                chkColHedFontItalic.Checked = xHeader.colhedfontitalic;
                ctl_is_landscape.SetValue(xHeader.is_landscape);
                ctl_has_extras.SetValue(xHeader.has_extras);
            }
        }
        private Boolean AssymbleTemplateTab()
        {
            try
            {
                if (xHeader != null)
                {
                    xHeader.printname = txtPrintName.Text.Trim();
                    xHeader.printtag = txtPrintTag.Text.Trim();
                    xHeader.printdescription = txtPrintDescription.Text.Trim();
                    xHeader.class_name = txtClassName.Text.Trim();
                    xHeader.copycount = ConvertStrToInt32(txtCopyCount.Text.Trim());
                    xHeader.ordertype = cboOrderType.Text.Trim();
                    xHeader.printername = cboPrinterName.Text.Trim();
                    xHeader.colhedfont = lblColHedFontText.Text.Trim();
                    xHeader.colhedfontsize = ConvertStrToInt64(txtColHedFontSize.Text.Trim());
                    xHeader.colhedfontbold = chkColHedFontBold.Checked;
                    xHeader.colhedfontitalic = chkColHedFontItalic.Checked;
                    xHeader.has_extras = ctl_has_extras.GetValue_Boolean();
                    xHeader.is_landscape = ctl_is_landscape.GetValue_Boolean();
                    return true;
                }
                return false;
            }
            catch (Exception)
            { return false; }
        }
        private Boolean AssymbleDetail()
        {
            try
            {
                if (z_Detail == null)
                    return false;
                z_Detail.detailname = lblDetailName.Text;
                z_Detail.detailtype = lblDetailType.Text.ToUpper();
                z_Detail.StartX = ConvertStrToInt32(txtStartX.Text);
                z_Detail.StartY = ConvertStrToInt32(txtStartY.Text);
                z_Detail.StopX = ConvertStrToInt32(txtStopX.Text);
                z_Detail.StopY = ConvertStrToInt32(txtStopY.Text);
                z_Detail.max_width = ConvertStrToInt32(txtMaxWidth.Text);
                z_Detail.drawwidth = (Int32)udLineWidth.Value;
                z_Detail.centerx1 = ConvertStrToInt64(txtCenterX1.Text);
                z_Detail.centerx2 = ConvertStrToInt64(txtCenterX2.Text);
                z_Detail.fontname = lblFontName.Text;
                z_Detail.fontbold = chkFontBold.Checked;
                z_Detail.fontitalic = chkFontItalic.Checked ? 1 : 0;
                z_Detail.fontsize = ConvertStrToInt32(txtFontSize.Text);
                z_Detail.textstring = txtTextString.Text;
                z_Detail.filename = txtFileName.Text;
                z_Detail.style_info = ctlStyle.GetValue_String();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        private Int32 ConvertStrToInt32(String sIn)
        {
            if (!Tools.Strings.StrExt(sIn))
                return 0;
            try
            {
                return Int32.Parse(sIn);
            }
            catch (Exception)
            { return 0; }
        }
        private Int64 ConvertStrToInt64(String sIn)
        {
            if (!Tools.Strings.StrExt(sIn))
                return 0;
            try
            {
                return Int64.Parse(sIn);
            }
            catch (Exception)
            { return 0; }
        }
        private void LoadSelectedObject(printdetail detail)
        {
            if (detail == null)
                return;
            z_Detail = detail;
            foreach (printdetail d in xHeader.AllDetails(RzWin.Context))
            {
                if (d.detailname == "LINE8_1")
                {
                    ;
                }
                d.IsSelected = false;
            }
            foreach (printdetail d in z_Details)
            {
                d.IsSelected = true;
            }
            if (z_Detail != null)
                z_Detail.IsSelected = true;

            LoadDetail();
            RefreshPreview();
        }
        private void RegisterPreviewWithParent()
        {
            //try
            //{
            //    switch (xFromObject.GetType().ToString())
            //    {
            //        case "PrintedForms":
            //            ((PrintedForms)xFromObject).frmPreview = frmPreview;
            //            break;
            //    }
            //}
            //catch (Exception)
            //{ }
        }
        private void SetMovementView()
        {
            if (LV.GetSelectedCount() > 1)
            {
                lblGroup.Visible = true;
                panelMoveView.Visible = false;
            }
            else
            {
                lblGroup.Visible = false;
                panelMoveView.Visible = true;
            }
        }
        private void ClearDetailView()
        {
            lblDetailName.Text = "NAME";
            lblDetailType.Text = "TYPE";
            txtStartX.Text = "0";
            txtStartX.Enabled = false;
            txtStartY.Text = "0";
            txtStartY.Enabled = false;
            txtStopX.Text = "0";
            txtStopX.Enabled = false;
            txtStopY.Text = "0";
            txtStopY.Enabled = false;
            udLineWidth.Value = 1;
            udLineWidth.Enabled = false;
            txtCenterX1.Text = "0";
            txtCenterX1.Enabled = false;
            txtCenterX2.Text = "0";
            txtCenterX2.Enabled = false;
            lblFontName.Text = "FontName";
            chkFontBold.Checked = false;
            chkFontBold.Enabled = false;
            chkFontItalic.Checked = false;
            chkFontItalic.Enabled = false;
            txtFontColor.Text = "Black";
            txtFontColor.Enabled = false;
            txtFontSize.Text = "0";
            txtFontSize.Enabled = false;
            txtTextString.Text = "";
            txtTextString.Enabled = false;
            cmdApply.Enabled = false;
            cmdDelete.Enabled = false;
            cmdNew.Enabled = false;
            cmdSelectColor.Enabled = false;
            cmdSelectFont.Enabled = false;
            lblGroup.Visible = false;
            panelMoveView.Visible = false;
            txtXStart.Text = "0";
            txtYStart.Text = "0";
            txtXStop.Text = "0";
            txtYStop.Text = "0";
        }
        private void SetDetailView()
        {
            if (z_Detail == null)
                return;
            ClearDetailView();
            switch (z_Detail.detailtype.ToLower())
            {
                case "line":
                case "box":
                    txtStartX.Enabled = true;
                    txtStartY.Enabled = true;
                    txtStopX.Enabled = true;
                    txtStopY.Enabled = true;
                    udLineWidth.Enabled = true;
                    cmdApply.Enabled = true;
                    cmdDelete.Enabled = true;
                    cmdNew.Enabled = true;
                    cmdSelectColor.Enabled = true;
                    break;
                case "headerband":
                    txtStartX.Enabled = true;
                    txtStartY.Enabled = true;
                    txtStopX.Enabled = true;
                    txtStopY.Enabled = true;
                    udLineWidth.Enabled = true;
                    cmdApply.Enabled = true;
                    cmdDelete.Enabled = true;
                    cmdNew.Enabled = true;
                    chkFontBold.Enabled = true;
                    chkFontItalic.Enabled = true;
                    txtFontColor.Enabled = true;
                    txtFontSize.Enabled = true;
                    txtTextString.Enabled = true;
                    cmdChooseHeaderFont.Enabled = true;
                    cmdSelectFont.Enabled = true;
                    break;
                default:
                    txtStartX.Enabled = true;
                    txtStartY.Enabled = true;
                    txtCenterX1.Enabled = true;
                    txtCenterX2.Enabled = true;
                    chkFontBold.Enabled = true;
                    chkFontItalic.Enabled = true;
                    txtFontColor.Enabled = true;
                    txtFontSize.Enabled = true;
                    txtTextString.Enabled = true;
                    cmdApply.Enabled = true;
                    cmdDelete.Enabled = true;
                    cmdNew.Enabled = true;
                    cmdSelectColor.Enabled = true;
                    cmdSelectFont.Enabled = true;
                    break;
            }
        }
        private void SaveTemplate()
        {
            if (AssymbleTemplateTab())
            {
                RzWin.Context.Update(xHeader);
            }
        }
        private void PrintTemplate()
        {
            frmPreview.PrintPreview();
        }
        private void CloseTemplate()
        {
            if (xHeader == null)
                return;
            frmPreview.CloseDesigner(xHeader);
        }
        private void RenameDetail()
        {
            if (z_Detail == null)
                return;
            String name = RzWin.Leader.AskForString("Please enter a new name for this print object:", z_Detail.detailname, "New Name");
            if (Tools.Strings.StrExt(name))
            {
                z_Detail.detailname = name.Trim();
                z_Detail.Update(RzWin.Context);
                LoadDetail();
            }
        }
        private void ChooseFont(String sIn)
        {
            cFont.Font = GetDefaultFont(sIn);
            DialogResult dr = cFont.ShowDialog();
            if (dr.Equals(DialogResult.Cancel))
                return;
            if (cFont.Font == null)
                return;
            Font sFont = cFont.Font;
            switch (sIn)
            {
                case "header":
                    xHeader.colhedfont = sFont.Name;
                    xHeader.colhedfontsize = (Int32)sFont.Size;
                    xHeader.colhedfontbold = sFont.Bold;
                    xHeader.colhedfontitalic = sFont.Italic;
                    RzWin.Context.Update(xHeader);
                    break;
                case "detail":
                    z_Detail.fontname = sFont.Name;
                    z_Detail.fontsize = (Int32)sFont.Size;
                    z_Detail.fontbold = sFont.Bold;
                    z_Detail.fontitalic = sFont.Italic ? 1 : 0;
                    RzWin.Context.Update(z_Detail);
                    break;
            }
            LoadHeader();
            LoadDetail();
            RefreshPreview();
        }
        private Font GetDefaultFont(String sIn)
        {
            try
            {
                Font f = new Font("Times New Roman", 8);
                switch (sIn.ToLower())
                {
                    case "header":
                        if (xHeader.colhedfontbold && xHeader.colhedfontitalic)
                            f = new Font(xHeader.colhedfont, xHeader.colhedfontsize, FontStyle.Bold | FontStyle.Italic);
                        else if (xHeader.colhedfontbold && !xHeader.colhedfontitalic)
                            f = new Font(xHeader.colhedfont, xHeader.colhedfontsize, FontStyle.Bold);
                        else if (!xHeader.colhedfontbold && xHeader.colhedfontitalic)
                            f = new Font(xHeader.colhedfont, xHeader.colhedfontsize, FontStyle.Italic);
                        else if (!xHeader.colhedfontbold && !xHeader.colhedfontitalic)
                            f = new Font(xHeader.colhedfont, xHeader.colhedfontsize, FontStyle.Regular);
                        break;
                    case "detail":
                        if (z_Detail.fontbold && (z_Detail.fontitalic == 1))
                            f = new Font(z_Detail.fontname, z_Detail.fontsize, FontStyle.Bold | FontStyle.Italic);
                        else if (z_Detail.fontbold && (z_Detail.fontitalic == 0))
                            f = new Font(z_Detail.fontname, z_Detail.fontsize, FontStyle.Bold);
                        else if (!z_Detail.fontbold && (z_Detail.fontitalic == 1))
                            f = new Font(z_Detail.fontname, z_Detail.fontsize, FontStyle.Italic);
                        else if (!z_Detail.fontbold && (z_Detail.fontitalic == 0))
                            f = new Font(z_Detail.fontname, z_Detail.fontsize, FontStyle.Regular);
                        break;
                }
                return f;
            }
            catch (Exception)
            { return new Font("Times New Roman", 8, FontStyle.Regular); }
        }
        private void SelectDetailColor()
        {
            try
            {
                if (z_Details == null)
                    return;
                if (z_Details.Count == 0)
                    return;
                cColor.AllowFullOpen = false;
                cColor.AnyColor = false;
                cColor.FullOpen = false;
                cColor.SolidColorOnly = true;
                cColor.Color = nTools.GetColorFromInt((Int32)z_Detail.fontcolor);
                cColor.Reset();
                DialogResult dr = cColor.ShowDialog();
                if (dr.Equals(DialogResult.Cancel))
                    return;
                Color c = cColor.Color;
                foreach (printdetail d in z_Details)
                {
                    d.fontcolor = c.ToArgb();
                    RzWin.Context.Update(d);
                }
                RefreshPreview();
                LoadDetail();
            }
            catch (Exception)
            { }
        }
        private void DeleteLoadedDetail()
        {
            try
            {
                if (z_Details != null)
                {
                    if (z_Details.Count > 0)
                    {
                        DeleteLoadedDetails();
                        return;
                    }
                }
                if (z_Detail == null)
                    return;
                if (!RzWin.Leader.AskYesNo("You are about to delete the loaded object. Ok to continue?"))
                    return;
                RzWin.Context.Delete(z_Detail);
                xHeader.AllDetails(RzWin.Context).Remove(z_Detail);
                z_Detail = null;
                RefreshPreview();
                LoadDetail();
                ShowDetails();
            }
            catch { }
        }
        private void DeleteLoadedDetails()
        {
            try
            {
                if (!RzWin.Leader.AreYouSure("delete " + Tools.Number.LongFormat(z_Details.Count) + " items"))
                    return;

                foreach (printdetail d in z_Details)
                {
                    RzWin.Context.Delete(d);
                    xHeader.AllDetails(RzWin.Context).Remove(d);
                }

                z_Detail = null;
                z_Details.Clear();
                z_Details = null;

                RefreshPreview();
                LoadDetail();
                ShowDetails();
            }
            catch (Exception)
            { }
        }
        private void UpdateDetail()
        {
            if (z_Details.Count > 1)
            {
                RzWin.Context.TheLeader.TellTemp("Please select a single item before continuing.");
                return;
            }
            AssymbleDetail();
            if (z_Detail != null)
                z_Detail.Update(RzWin.Context);
            else
            {
                ;
            }
            RefreshPreview();
            LoadDetail();
        }
        private void UpdateDetailAskForms()
        {
            if (z_Details.Count > 1)
            {
                RzWin.Context.TheLeader.TellTemp("Please select a single item before continuing.");
                return;
            }
            UpdateDetail();
            printdetail detail = (printdetail)z_Details[0];
            if (detail == null)
                return;
            string new_name = AskNewPrintHeaderName();
            if (!Tools.Strings.StrExt(new_name))
                return;
            detail.detailname = new_name;
            RzWin.Context.Update(detail);
            ArrayList a = frmAskSelectPrintedForm.AskSelectPrintedForm(RzWin.Context);
            if (a == null)
                return;
            if (a.Count <= 0)
                return;
            foreach (printheader p in a)
            {
                string id = "";
                printdetail pp = null;
                pp = printdetail.GetByName(RzWin.Context, p.unique_id, detail.detailname);
                if (pp == null)
                    pp = printdetail.New(RzWin.Context);
                id = pp.unique_id;
                pp = (printdetail)detail.CloneValues(RzWin.Context);
                pp.unique_id = id;
                pp.base_printheader_uid = p.unique_id;
                RzWin.Context.Insert(pp);
            }
            RzWin.Context.TheLeader.Tell("Done.");
        }
        private string AskNewPrintHeaderName()
        {
            string s = "";
            try
            {
                s = RzWin.Context.TheLeader.AskForString("Please enter a unique name for this detail item.", "", false);
            }
            catch { }
            return s;
        }
        private void CreateNewDetail(String type)
        {
            printdetail yDetail;
            string alt_type = type;
            if (Tools.Strings.StrCmp(type, "orderprop"))
                alt_type = "TEXT";
            else if (Tools.Strings.StrCmp(type, "agentprop"))
                alt_type = "TEXT";
            if (xHeader != null)
            {
                yDetail = xHeader.DetailAdd(RzWin.Context, alt_type);
                yDetail.startx = 10;
                yDetail.starty = 10;
                switch (type.ToLower())
                {
                    case "line":
                        yDetail.stopy = 50;
                        yDetail.stopx = 50;
                        break;
                    case "box":
                        yDetail.stopy = 50;
                        yDetail.stopx = 50;
                        break;
                    case "headerband":
                        yDetail.startx = 310;
                        yDetail.starty = 2910;
                        yDetail.stopx = 7550;
                        yDetail.stopy = 3450;
                        yDetail.textstring = "Agent Name|[ORDER.AGENTNAME]\r\nTerms|[ORDER.TERMS]";
                        break;
                    case "text":
                        yDetail.textstring = "NEW_TEXT";
                        yDetail.stopy = 0;
                        yDetail.stopx = 0;
                        break;
                    case "orderprop":
                        yDetail.textstring = GetNewOrderProp();
                        if (!Tools.Strings.StrExt(yDetail.textstring))
                            return;
                        yDetail.stopy = 0;
                        yDetail.stopx = 0;
                        break;
                    case "agentprop":
                        yDetail.textstring = GetNewAgentProp();
                        if (!Tools.Strings.StrExt(yDetail.textstring))
                            return;
                        yDetail.stopy = 0;
                        yDetail.stopx = 0;
                        break;
                    case "graphic":
                        String strFile = null;
                        if (RzWin.Leader.AskYesNo("Are you adding the Company Logo?"))

                            //Get the pre-set company logo path / url, as defined int he CompanySettings                           
                            AddCompanyLogo(RzWin.Context, out strFile);


                        if (string.IsNullOrEmpty(strFile))
                            strFile = ToolsWin.FileSystem.ChooseAFile();


                        if (!Tools.Strings.StrExt(strFile))
                            return;
                        yDetail.AbsorbGraphic(RzWin.Context, strFile);


                        //yDetail.filename = "partpicture/" + p.unique_id;




                        break;
                    default:
                        yDetail.stopy = 0;
                        yDetail.stopx = 0;
                        break;
                }
                RzWin.Context.Update(yDetail);

                z_Detail = yDetail;
                ShowDetails();

                SelectDetail(yDetail);
                RefreshPreview();
            }
        }

        private void AddCompanyLogo(ContextRz x, out string strFilePath)
        {
            string fileName = "Sensible Company Logo";

            strFilePath = OwnerSettings.GetCompanyLogoPath(x);
            if (!File.Exists(strFilePath))
                throw new Exception("File not found: " + strFilePath);

            //We need a valid partpicture when loading documents.
            partpicture p = (partpicture)x.QtO("partpicture", "select * from partpicture where filename = '" + fileName + "'");
            if (p == null)
            {
                p = partpicture.New(x);
                p.filename = fileName;
                p.file_path = strFilePath;
                p.Insert(x);
            }

            Image i = Image.FromFile(p.file_path);

            //Constrain to size
            //Size size = new Size(200, 120);

            //Resize the Company Logo to a common size for Printed forms uniformity.            
            //Image resized = Tools.Picture.ResizeImage(i, size);

            //Absorb Temp File into Image set values for picturedata logic
            //p.SetPictureDataByImage(x, resized, strFilePath);
            //p.filename = "Company Logo";
            //Check if logo already exists            
            //if (!File.Exists(strFilePath))
            //{
            //    //output the file to temp directory
            //    if (!File.Exists(strFilePath))
            //        p.SaveDataAsFile(x, strFilePath, false);

            //}




        }

        //private partpicture GetImageFromCompanyLogoUrl(ContextRz x, string logoUrl, out string strFilePath)
        //{

        //    partpicture p = (partpicture)x.QtO("partpicture", "select * from partpicture where fullpartnumber = '" + logoUrl + "'");
        //    if (p == null)
        //    {
        //        p = partpicture.New(x);
        //        p.Insert(x);
        //    }

        //    //Set the path of the locally Stored Logo    
        //    //Tools.Picture.GetFilePathFromLogoUrl(logoUrl, out strFilePath);
        //    p.file_path = @"\\storage\sm_storage\rz_attachments\rz_company_logo.jpg";
        //    strFilePath = p.file_path;
        //    p.fullpartnumber = logoUrl;
        //    p.Update(x);
        //    return p;

        //}

        private void MoveSelectedObjects(String direction, Int32 factor)
        {
            try
            {
                List<printdetail> a = z_Details;
                if (a.Count <= 0)
                    return;
                switch (factor)
                {
                    case 1:
                        factor = (Int32)ud1.Value;
                        break;
                    case 2:
                        factor = (Int32)ud2.Value;
                        break;
                    case 3:
                        factor = (Int32)ud3.Value;
                        break;
                }
                Boolean bAdd = false;
                Boolean bX = false;
                switch (direction.ToLower())
                {
                    case "down":
                        bAdd = true;
                        break;
                    case "right":
                        bAdd = true;
                        bX = true;
                        break;
                    case "left":
                        bX = true;
                        break;
                }
                foreach (printdetail d in a)
                {
                    switch (d.detailtype.ToLower())
                    {
                        case "line":
                        case "box":
                        case "headerband":
                        case "band":
                            switch (bX)
                            {
                                case true:
                                    if (chkUpperLeft.Checked)
                                    {
                                        if (bAdd)
                                            d.startx = d.startx + factor;
                                        else
                                            d.startx = d.startx - factor;
                                    }
                                    if (chkLowerRight.Checked)
                                    {
                                        if (bAdd)
                                            d.stopx = d.stopx + factor;
                                        else
                                            d.stopx = d.stopx - factor;
                                    }
                                    break;
                                case false:
                                    if (chkUpperLeft.Checked)
                                    {
                                        if (bAdd)
                                            d.starty = d.starty + factor;
                                        else
                                            d.starty = d.starty - factor;
                                    }
                                    if (chkLowerRight.Checked)
                                    {
                                        if (bAdd)
                                            d.stopy = d.stopy + factor;
                                        else
                                            d.stopy = d.stopy - factor;
                                    }
                                    break;
                            }
                            break;
                        default:
                            if (chkUpperLeft.Checked)
                            {
                                switch (bX)
                                {
                                    case true:
                                        if (bAdd)
                                            d.startx = d.startx + factor;
                                        else
                                            d.startx = d.startx - factor;
                                        break;
                                    case false:
                                        if (bAdd)
                                            d.starty = d.starty + factor;
                                        else
                                            d.starty = d.starty - factor;
                                        break;
                                }
                            }
                            break;
                    }
                    d.Update(RzWin.Context);
                }

                if (a.Count == 1)
                {
                    printdetail dx = (printdetail)a[0];
                    txtStartX.Text = dx.StartX.ToString();
                    txtXStart.Text = dx.StartX.ToString();
                    txtStartY.Text = dx.StartY.ToString();
                    txtYStart.Text = dx.StartY.ToString();

                    txtStopX.Text = dx.StopX.ToString();
                    txtXStop.Text = dx.StopX.ToString();
                    txtStopY.Text = dx.StopY.ToString();
                    txtYStop.Text = dx.StopY.ToString();
                }
                RefreshPreview();
            }
            catch
            { }
        }
        private void SetCurrentDetail(printdetail d)
        {
            try
            {
                if (d == null)
                    return;
                if (ts.SelectedTab == tabTemplate)
                    ts.SelectedTab = tabCurrent;
                if (ts.SelectedTab == tabColumns)
                    ts.SelectedTab = tabCurrent;
                z_Detail = d;
                ShowDetailList();
                try
                {
                    LoadSelectedObject(d);
                    SetMovementView();
                }
                catch
                { }
            }
            catch { }
        }
        private void ShowDetailList()
        {
            lblSelected.Text = Tools.Number.LongFormat(z_Details.Count) + " Selected";
        }
        private void SelectDetailInLV(printdetail d)
        {
            inhibit = true;
            try
            {
                LV.ClearAllSelected();
                LV.SelectObjectByID(d.unique_id);
            }
            catch { }
            inhibit = false;
        }
        private void SelectDetailsInLV(List<printdetail> a)
        {
            inhibit = true;
            try
            {
                LV.ClearAllSelected();
                foreach (printdetail p in a)
                {
                    LV.SelectObjectByID(p.unique_id);
                }
            }
            catch { }
            inhibit = false;
        }
        private int GetMaxWidth()
        {
            if (z_Detail == null)
                return 0;
            frmPreview.bPictureLoaded = false;
            if (frmPreview.PreviewSession != null)
            {
                frmPreview.PreviewSession.Dispose();
                frmPreview.PreviewSession = null;
            }

            Bitmap b = new Bitmap(frmPreview.PreviewImageWidth, frmPreview.PreviewImageHeight);
            using (Graphics g = Graphics.FromImage(b))
            {
                return Convert.ToInt32(g.MeasureString(z_Detail.textstring, z_Detail.GetFont()).Width);
            }
        }
        private void SelectDetail(printdetail d)
        {
            z_Details = new List<printdetail>();
            z_Details.Add(d);
            SelectDetailInLV(d);
            SetCurrentDetail(d);
        }
        private string GetNewOrderProp()
        {
            frmChoosePrintedFormProp p = new frmChoosePrintedFormProp();
            p.CompleteLoad(RzWin.Context, "Order");
            p.ShowDialog();
            return p.TheProp;
        }
        private string GetNewAgentProp()
        {
            frmChoosePrintedFormProp p = new frmChoosePrintedFormProp();
            p.CompleteLoad(RzWin.Context, "Agent");
            p.ShowDialog();
            return p.TheProp;
        }
        //Buttons
        private void cmdSaveTemplate_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveTemplate();
        }
        private void cmdPrintTemplate_Click(object sender, EventArgs e)
        {
            PrintTemplate();
        }
        private void cmdSendPrint_Click(object sender, EventArgs e)
        {
            PrintTemplate();
        }
        private void cmdCloseTemplate_Click(object sender, EventArgs e)
        {
            CloseTemplate();
        }
        private void cmdSendClose_Click(object sender, EventArgs e)
        {
            CloseTemplate();
        }
        private void cmdChooseHeaderFont_Click(object sender, EventArgs e)
        {
            ChooseFont("header");
        }
        private void cmdSelectFont_Click(object sender, EventArgs e)
        {
            ChooseFont("detail");
        }
        private void cmdSelectColor_Click(object sender, EventArgs e)
        {
            SelectDetailColor();
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteLoadedDetail();
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            ts.SelectedTab = tabNewDetail;
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            UpdateDetail();
        }
        private void cmdApplyToForms_Click(object sender, EventArgs e)
        {
            UpdateDetailAskForms();
        }
        private void cmdU1_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("up", 1);
        }
        private void cmdU2_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("up", 2);
        }
        private void cmdU3_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("up", 3);
        }
        private void cmdL1_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("left", 1);
        }
        private void cmdL2_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("left", 2);
        }
        private void cmdL3_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("left", 3);
        }
        private void cmdR1_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("right", 1);
        }
        private void cmdR2_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("right", 2);
        }
        private void cmdR3_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("right", 3);
        }
        private void cmdD1_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("down", 1);
        }
        private void cmdD2_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("down", 2);
        }
        private void cmdD3_Click(object sender, EventArgs e)
        {
            MoveSelectedObjects("down", 3);
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshDesigner();
        }
        private void cmdNewText_Click(object sender, EventArgs e)
        {
            CreateNewDetail("TEXT");
        }
        private void cmdNewLine_Click(object sender, EventArgs e)
        {
            CreateNewDetail("LINE");
        }
        private void cmdNewBox_Click(object sender, EventArgs e)
        {
            CreateNewDetail("BOX");
        }
        private void cmdNewPicture_Click(object sender, EventArgs e)
        {
            CreateNewDetail("GRAPHIC");
        }
        private void cmdCreateOrderProp_Click(object sender, EventArgs e)
        {
            CreateNewDetail("ORDERPROP");
        }
        private void cmdCreateAgentProp_Click(object sender, EventArgs e)
        {
            CreateNewDetail("AGENTPROP");
        }
        private void cmdTheBand_Click(object sender, EventArgs e)
        {
            CreateNewDetail("BAND");
        }
        private void cmdHeaderBand_Click(object sender, EventArgs e)
        {
            CreateNewDetail("HEADERBAND");
        }
        private void cmdGetMaxWidth_Click(object sender, EventArgs e)
        {
            txtMaxWidth.Text = GetMaxWidth().ToString();
        }
        //Control Events
        private void frmPrintedFormsDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bClosing)
                return;
            try
            {
                switch (xFromObject.GetType().ToString())
                {
                    case "PrintedForms":
                        bClosing = true;
                        ((PrintedForms)xFromObject).CloseDesigners();
                        break;
                }
            }
            catch (Exception)
            { }
        }
        private void LV_ObjectClicked(object sender, ObjectClickArgs args)
        {
            if (inhibit)
                return;
            z_Details = new List<printdetail>();
            foreach (nObject o in LV.GetSelectedObjects())
            {
                z_Detail = (printdetail)o;
                z_Details.Add((printdetail)o);
            }
            SetCurrentDetail(z_Detail);
        }
        private void LV_FinishedFill(object sender)
        {
            if (bLoadFirst)
            {
                LV.SelectFirst();
                bLoadFirst = false;
                LoadSelectedObject((printdetail)LV.GetSelectedObject());
            }
        }
        private void LV_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        private void lblImportBackground_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            List<object> objects = new List<object>();
            foreach (Object x in RzWin.Context.QtC("printheader", "select * from printheader where printname <> '" + RzWin.Context.Filter(xHeader.printname) + "' order by printname"))
            {
                objects.Add(x);
            }
            printheader h = (printheader)frmChooseObject.ChooseFromCollection(objects);
            if (h == null)
                return;

            ArrayList remove = new ArrayList();
            //remove the old ones
            foreach (printdetail d in xHeader.AllDetails(RzWin.Context))
            {
                if (d.detailname.Contains("<" + h.printname + ">"))
                {

                    remove.Add(d);

                }
            }

            foreach (printdetail d in remove)
            {
                xHeader.AllDetails(RzWin.Context).Remove(d);
                d.Delete(RzWin.Context);
            }

            h.GatherDetails(RzWin.Context);
            foreach (printdetail d in h.AllDetails(RzWin.Context))
            {
                printdetail nd = (printdetail)d.CloneValues(RzWin.Context);
                nd.base_printheader_uid = xHeader.unique_id;
                nd.detailname += " <" + h.printname + ">";
                nd.Insert(RzWin.Context);
                xHeader.AllDetails(RzWin.Context).Add(nd);
            }

            ShowDetails();
            RefreshPreview();
            LoadDetail();
        }
        private void lblCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DesignOptions.CopiedDetails = new ArrayList();
            if (z_Details == null)
                return;
            foreach (printdetail d in z_Details)
            {
                CopiedDetails.Add(d);
            }
        }
        private void lblPaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DesignOptions.CopiedDetails == null)
                return;
            if (DesignOptions.CopiedDetails.Count <= 0)
                return;
            foreach (printdetail d in DesignOptions.CopiedDetails)
            {
                printdetail dx = (printdetail)d.CloneValues(RzWin.Context);
                dx.unique_id = "";
                dx.base_printheader_uid = xHeader.unique_id;
                dx.detailname = d.detailtype;
                dx.Insert(RzWin.Context);
                xHeader.AllDetails(RzWin.Context).Add(dx);
            }
            ShowDetails();
            RefreshPreview();
            LoadDetail();
            RefreshDesigner();
            SetCurrentDetail((printdetail)DesignOptions.CopiedDetails[0]);
            SelectDetailInLV(z_Detail);
        }
        private void lblDetailName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RenameDetail();
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ts.SelectedIndex)
            {
                case 2:
                    SetMovementView();
                    break;
            }
        }
        //Event Handlers
        private void frmPreview_PreviewBox(int x_pct, int y_pct, int x2_pct, int y2_pct)
        {
            try
            {
                List<printdetail> a = xHeader.GetDetailsByBox(RzWin.Context, x_pct, y_pct, x2_pct, y2_pct);
                if (a.Count > 0)
                {
                    foreach (printdetail d in xHeader.AllDetails(RzWin.Context))
                    {
                        d.IsSelected = false;
                    }
                    foreach (printdetail d in a)
                    {
                        d.IsSelected = true;
                    }
                    SelectDetailsInLV(a);
                    RefreshPreview();
                    z_Details = a;
                    ShowDetailList();
                }
            }
            catch { }
        }
        private void frmPreview_PreviewClick(int width_pct, int height_pct)
        {
            try
            {
                ArrayList a = xHeader.GetDetailsByPct(RzWin.Context, width_pct, height_pct);
                if (a.Count == 0)
                    return;
                printdetail d = null;
                if (a.Count == 1)
                {
                    d = (printdetail)a[0];
                    //z_Details.Add(d);
                }
                else
                {
                    if (lastchoice == -1)
                        lastchoice = 0;
                    else if (lastchoice > (a.Count - 2))
                        lastchoice = 0;
                    else
                        lastchoice++;
                    d = (printdetail)a[lastchoice];
                }
                if (d != null)
                {
                    SelectDetail(d);
                }
            }
            catch { }
        }

        private void lblAltFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (z_Detail == null)
                return;

            String strFile = ToolsWin.FileSystem.ChooseAFile();
            if (!Tools.Strings.StrExt(strFile))
                return;

            partpicture p = partpicture.New(RzWin.Context);
            p.InsertTo(RzWin.Context, RzWin.Context.Logic.PictureData);
            p.SetPictureDataByFile(RzWin.Context, strFile);
            p.SavePictureData((ContextRz)RzWin.Context);
            z_Detail.alternate_file_name = "partpicture/" + p.unique_id;
            z_Detail.Update(RzWin.Context);
        }
    }
}