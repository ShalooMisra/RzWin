using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Data;
using PDFBuilder;
using System.Text;
using System.Windows.Forms;
using Rz5;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class ViewQualityControl : Rz5.view_qualitycontrol
    {
        //Private Delegates
        private delegate void CheckFileHandler(String strFile);
        //Private Variables
        private Rz5.InspectionLine insLotCode = null;
        private Rz5.InspectionLine insCountry = null;
        protected ArrayList NewPicFiles = new ArrayList();

        //Constructors
        public ViewQualityControl()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void Init(Item items)
        {
            base.Init(items);
            fp.Controls.Clear();

            if (insLotCode == null)
            {
                insLotCode = new Rz5.InspectionLine();
                insLotCode.FieldYesNo = "lot_code_match";
                insLotCode.FieldNotes = "lot_code_notes";
            }

            if (insCountry == null)
            {
                insCountry = new Rz5.InspectionLine();
                insCountry.FieldYesNo = "country_match";
                insCountry.FieldNotes = "country_notes_text";
            }

            Rz5.InspectionLine packingSlipDateLine = new Rz5.InspectionLine()
            {
                Caption = "Does vendor packing slip match internal documents for the date code?",
                FieldYesNo = "packing_slip_date_yn",
                FieldNotes = "packing_slip_date_notes"
            };
            var child = packingSlipDateLine.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;

            Rz5.InspectionLine packingSlipMfg = new Rz5.InspectionLine()
            {
                Caption = "Does vendor packing slip match internal documents for manufacturer?",
                FieldYesNo = "packing_slip_mfg_yn",
                FieldNotes = "packing_slip_mfg_notes"
            };
            child = packingSlipMfg.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;

            Rz5.InspectionLine packingSlipCost = new Rz5.InspectionLine()
            {
                Caption = "Does vendor packing slip match internal documents for cost?",
                FieldYesNo = "packing_slip_cost_yn",
                FieldNotes = "packing_slip_cost_notes"
            };
            child = packingSlipCost.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;

            Rz5.InspectionLine packingSlipPONum = new Rz5.InspectionLine()
            {
                Caption = "Does vendor packing slip match internal documents for the PO #?",
                FieldYesNo = "packing_slip_ponum_yn",
                FieldNotes = "packing_slip_ponum_notes"
            };
            child = packingSlipPONum.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;

            Rz5.InspectionLine packingSlipSONum = new Rz5.InspectionLine()
            {
                Caption = "Does vendor packing slip match internal documents for the Sales Order #?",
                FieldYesNo = "packing_slip_sonum_yn",
                FieldNotes = "packing_slip_sonum_notes"
            };
            child = packingSlipSONum.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;

            child = insCountry.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;

            fp.Controls.Add(insGoodPackage);
            fp.Controls.Add(insVendorInfo); //
            fp.Controls.Add(packingSlipDateLine);
            fp.Controls.Add(packingSlipMfg);
            fp.Controls.Add(packingSlipCost);
            fp.Controls.Add(packingSlipPONum);
            fp.Controls.Add(packingSlipSONum);
            fp.Controls.Add(insAuthentic); //
            fp.Controls.Add(insDateCode); //
            fp.Controls.Add(insLotCode);
            fp.Controls.Add(insCountry);
            fp.Controls.Add(insRefurb); //
            fp.Controls.Add(insHumidity); // - Acetone
            fp.Controls.Add(insPackaging); //
            fp.Controls.Add(insScan); // - q, mfg, dc
            fp.Controls.Add(insOrigin); // - pin1
            fp.Controls.Add(ins_ocm_verification); // - microscope
            fp.Controls.Add(ins_calibrations_measured); // - m2
            fp.Controls.Add(ins_gold_standard); // - shippable
            fp.Controls.Add(insPhotosInBox); // - NonConforming

            insGoodPackage.Caption = "Was the package delivered in good condition?";
            //insVendorInfo.Caption = "Does vendor packing slip match internal documents? (Qty, date code, mfg, cost)?";
            insVendorInfo.Caption = "Does vendor packing slip match internal documents for quantity?";

            insAuthentic.Caption = "Are part labels marked authentic by the manufacturer? (Quality stamps)?";
            insDateCode.Caption = "Are date codes consistent?";
            insLotCode.Caption = "Are lot codes consistent?";
            insCountry.Caption = "Is the country of origin consistent?";
            insRefurb.Caption = "Any signs of product rework? (Body, leads, remarking)?";
            insHumidity.Caption = "Did product pass acetone screening?";
            insPackaging.Caption = "Are parts packaged in original manufacturer tubes or reels?";
            insScan.Caption = "Is the quantity, manufacturer and date code correct?";
            insOrigin.Caption = "Is the pin 1 orientation in the correct place according to OEM data sheet?";
            ins_ocm_verification.Caption = "Under microscope are any scratches or sanding marks visible?";
            ins_calibrations_measured.Caption = "Under microscope is any solder, oxidation or damage visible to leads?";
            ins_gold_standard.Caption = "This order meets the above criteria and will be released for shipment?";
            insPhotosInBox.Caption = "Non-Conforming Material?";
            DoResize();
            UncheckRadioButtons();
            LoadPics();
        }
        public override ArrayList GetInspectionLines(ArrayList ret)
        {
            ret = new ArrayList();
            foreach (Control c in Controls)
            {
                if (c is Rz5.InspectionLine)
                    ret.Add(c);
            }
            ret.AddRange(GetInspectionLinesFlow());
            return ret;
        }
        public override void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentInspection);
            foreach (Rz5.InspectionLine l in GetInspectionLines())
            {
                l.CompleteSave();
                LineCol.Add(l);
            }
            base.CompleteSave();
        }
        public override bool AllQuestionsAnswered(StringBuilder sb)
        {
            if (!base.AllQuestionsAnswered(sb))
                return false;
            foreach (Control control in fp.Controls)
            {

                if (control is Rz5.InspectionLine)
                {
                    Rz5.InspectionLine l = (Rz5.InspectionLine)control;
                    if (!l.YesNoNASelected)
                    {
                        sb.AppendLine(l.Caption);
                        return false;
                    }
                }
            }
            return true;
        }
        //Protected Override Functions
        protected override void InitUn()
        {
            fp.Controls.Clear();
            base.InitUn();
        }
        protected override System.Collections.ArrayList GetInspectionLinesForPrint()
        {
            //return base.GetInspectionLinesForPrint();
            return base.GetInspectionLinesFlow();  //only print the ones they have on the sheet
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                foreach (Control c in fp.Controls)
                {
                    c.Width = Convert.ToInt32(fp.Width - 25);
                }
            }
            catch { }
        }
        protected override string HtmlGetAs()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<img src=\"http://www.recognin.com/Sensible/Logo.jpg\"><p align=\"right\">F-740-003-A</p><br><center><h1>Receiving Report</h1></center>");
            sb.AppendLine("<table border=\"1\"><tr><td>Vendor:</td><td>Purchase order:</td><td>Customer:</td><td>Date:</td><td>Receiving Initial</td></tr>");

            String vendor = "";
            String customer = "";
            String po = "";
            if (CurrentDetail != null)
            {
                if (!(CurrentDetail is Rz5.orddet_line))
                    return "";
                Rz5.orddet_line l = (Rz5.orddet_line)CurrentDetail;
                Rz5.ordhed_sales so = ordhed_sales.GetById(RzWin.Context, l.orderid_sales);
                Rz5.ordhed_purchase purchase = ordhed_purchase.GetById(RzWin.Context, l.orderid_purchase);
                if (so == null)
                    return "";
                if (purchase == null)
                    return "";
                vendor = purchase.companyname;
                customer = so.companyname;
                po = purchase.ordernumber;
            }
            sb.AppendLine("<tr><td>" + vendor + "&nbsp;</td><td>" + po + "&nbsp;</td><td>" + customer + "&nbsp;</td><td>" + nTools.DateFormat(CurrentInspection.date_created) + "&nbsp;</td><td>" + CurrentInspection.processor_name + "&nbsp;</td></tr>");
            sb.AppendLine("</table>");
            foreach (Rz5.InspectionLine l in GetInspectionLines())
            {
                sb.Append("<br>" + l.Caption + ":&nbsp;");
                if (Tools.Strings.HasString(l.Notes, "-NA-"))
                {
                    sb.Append("<font color=\"gray\">" + l.Notes + "</font>");
                }
                else
                {
                    if (l.Checked)
                        sb.Append("<font color=\"green\">Y</font>");
                    else
                        sb.Append("<font color=\"red\">N</font>");

                    sb.Append("&nbsp;&nbsp;" + l.Notes);
                }                
            }
            sb.AppendLine("<ul><li>Yes requires a Non-Conforming Material Report F-830-001 to be completed.</li><li>Report log F-830-002 needs to be completed.</li></ul>");
            return sb.ToString();
        }
        //Private Functions
        private void UncheckRadioButtons()
        {
            foreach (Control control in fp.Controls)
            {
                if (control is Rz5.InspectionLine)
                {
                    foreach (Control subcontrol in control.Controls)
                    {
                        if (subcontrol is RadioButton && subcontrol.Name == "optNo")
                        {
                            ((RadioButton)subcontrol).Checked = true;
                        }

                    }
                }
            }
        }
        protected void LoadPics()
        {
            lvPics.Items.Clear();
            lvPics.BeginUpdate();
            try
            {
                il.Images.Clear();
                ArrayList pics = RzWin.Context.QtC("partpicture", "select * from partpicture where the_qualitycontrol_uid = '" + TheQC.unique_id + "'");
                foreach (partpicture p in pics)
                {
                    AddPartPicture(p);
                }
            }
            catch { }
            lvPics.EndUpdate();
        }
        private void BrowseForPictureFile()
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png";
                of.ShowDialog(this);
                string file = of.FileName;
                if (!Tools.Strings.StrExt(file))
                    return;
                if (!Tools.Files.FileExists(file))
                    return;
                CheckFile(file);
                SelectBrowseFile(file);
                AddSelected();
            }
            catch { }
        }
        private void SelectBrowseFile(string file)
        {
            lvNew.SelectedItems.Clear();
            foreach (ListViewItem i in lvNew.Items)
            {
                if (Tools.Strings.StrCmp(i.Tag.ToString(), file))
                {
                    i.Selected = true;
                    return;
                }
            }
        }
        private void CheckFile(String strFile)
        {
            if (InvokeRequired)
                Invoke(new CheckFileHandler(ActuallyCheckFile), new object[] { strFile });
            else
                ActuallyCheckFile(strFile);
        }
        private void AddSelected()
        {
            try
            {
                String s = GetSelectedNewFileName();
                if (!Tools.Files.FileExists(s))
                    return;
                partpicture p = new partpicture();
                p.the_qualitycontrol_uid = TheQC.unique_id;
                p.fullpartnumber = TheQC.fullpartnumber;
                p.description = RzWin.Context.TheLeader.AskForString("Description", System.IO.Path.GetFileName(s), false);
                if (!Tools.Strings.StrExt(p.description))
                    p.description = System.IO.Path.GetFileName(s);               
                p.InsertTo(RzWin.Context, RzWin.Logic.PictureData);
                p.SetPictureDataByFile(RzWin.Context, s);
                p.SavePictureData(RzWin.Context);
                AddPartPicture(p);
            }
            catch { }
        }
        private void ActuallyCheckFile(String strFile)
        {
            String ext = System.IO.Path.GetExtension(strFile);
            switch (ext.ToLower())
            {
                case ".jpg":
                case ".bmp":
                case ".gif":
                case ".mpg":
                case ".pdf":
                    CheckGrabFile(strFile);
                    break;
            }
        }
        private void CheckGrabFile(String strFile)
        {
            lock (NewPicFiles.SyncRoot)
            {
                if (NewPicFiles.Contains(strFile))
                    return;
                NewPicFiles.Add(strFile);
                ListViewItem i = lvNew.Items.Add(System.IO.Path.GetFileName(strFile));
                i.SubItems.Add(System.IO.Path.GetDirectoryName(strFile));
                i.Tag = strFile;
                ShowThumbnail(strFile);
            }
        }
        private void ShowThumbnail(String strFile)
        {
            Image i = nTools.GetImage(strFile, pbNew.Width, pbNew.Height);
            pbNew.Image = i;
        }
        private void AddPartPicture(partpicture p)
        {
            ListViewItem i = lvPics.Items.Add(p.description);
            Image m = p.GetImage(RzWin.Context, 32, 32);
            if (m == null)
            {
                m = nTools.GetGenericThumbnail(32, 32);
            }
            il.Images.Add(p.unique_id, m);
            i.ImageKey = p.unique_id;
            i.Tag = p;
        }
        private String GetSelectedNewFileName()
        {
            try
            {
                return (String)lvNew.SelectedItems[0].Tag;
            }
            catch
            {
                return "";
            }
        }
        //Buttons
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            BrowseForPictureFile();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddSelected();
        }
    }
}
