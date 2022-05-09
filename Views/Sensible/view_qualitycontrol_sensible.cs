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

namespace RzSensible
{
    public partial class view_qualitycontrol : Rz5.view_qualitycontrol
    {
        //Private Variables
        private Rz5.InspectionLine l_1 = null;
        private Rz5.InspectionLine l_2 = null;
        private Rz5.InspectionLine l_3 = null;
        private Rz5.InspectionLine l_4 = null;
        private Rz5.InspectionLine l_5 = null;
        private Rz5.InspectionLine l_6 = null;
        private Rz5.InspectionLine l_7 = null;
        private Rz5.InspectionLine l_8 = null;
        private Rz5.InspectionLine l_9 = null;
        private Rz5.InspectionLine l_10 = null;
        private Rz5.InspectionLine l_11 = null;
        private Rz5.InspectionLine l_12 = null;
        private Rz5.InspectionLine l_13 = null;
        private Rz5.InspectionLine l_14 = null;
        private Rz5.InspectionLine l_15 = null;
        private Rz5.InspectionLine l_16 = null;
        private Rz5.InspectionLine l_17 = null;

        //Constructors
        public view_qualitycontrol()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void Init(Item items)
        {
            base.Init(items);
            fp.Controls.Clear();
            SetUpAltInspections();
            DoResize();
            UncheckRadioButtons();
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
        public override void HandleCommand(string strCommand)
        {
            base.HandleCommand(strCommand);
            if (Tools.Strings.StrCmp(strCommand, "Customer Report"))
                ShowCustomerReport();
        }
        //Public Functions
        public Rz5.ordhed GetLinkedOrder(Rz5.ordhed o, string type)
        {
            switch (type.ToLower().Trim())
            {
                case "sales":
                    return CurrentDetail.SalesVar.RefGet(RzWin.Context);
                case "purchase":
                    return CurrentDetail.PurchaseVar.RefGet(RzWin.Context);
            }
            return null;
        }      
        //Protected Override Functions
        protected override void InitUn()
        {
            fp.Controls.Clear();
            base.InitUn();
        }
        protected override System.Collections.ArrayList GetInspectionLinesForPrint()
        {
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
            try
            {
                string logo = OwnerSettings.GetCompanyLogoPath(RzWin.Context);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"34%\"><img src=\"" + logo + "\" width=\"143\" height=\"69\"></td>");
                sb.AppendLine("    <td width=\"33%\" align=\"center\"><b><font size=\"6\">Receiving Report</font></b></td>");
                sb.AppendLine("    <td width=\"33%\" align=\"center\"><p align=\"right\"><b>F-740-003-A</b></p></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                String detail_id = "";
                String vendor = "";
                String customer = "";
                String po = "";
                Rz5.ordhed_sales so = null;
                Rz5.ordhed_purchase purchase = null;
                if (CurrentDetail == null && Tools.Strings.StrExt(CurrentInspection.the_orddet_uid))
                    CurrentDetail = orddet_line.GetById(RzWin.Context, CurrentInspection.the_orddet_uid);
                if (CurrentDetail != null)
                {
                    if (!(CurrentDetail is orddet_line))
                        return "";
                    orddet_line l = (orddet_line)CurrentDetail;
                    so = ordhed_sales.GetById(RzWin.Context, l.orderid_sales);
                    purchase = ordhed_purchase.GetById(RzWin.Context, l.orderid_purchase);
                    if (so == null)
                        so = new ordhed_sales();
                    if (purchase == null)
                        purchase = new ordhed_purchase();
                    customer = so.companyname;
                    vendor = purchase.companyname;
                    po = purchase.ordernumber;
                    detail_id = CurrentDetail.unique_id;
                }
                if (so == null)
                    so = new Rz5.ordhed_sales();
                if (purchase == null)
                    purchase = new Rz5.ordhed_purchase();
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Vendor Name:&nbsp; <b>" + vendor + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">Part Number:&nbsp; <b>" + CurrentInspection.fullpartnumber + "</b></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Sensible PO#:&nbsp; <b>" + po + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">MFG:&nbsp; <b>" + CurrentInspection.manufacturer + "</b></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Customer Name:&nbsp; <b>" + customer + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">Date Code:&nbsp; <b>" + CurrentInspection.datecode + "</b></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Customer PO#:&nbsp; <b>" + so.orderreference + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">COO:&nbsp; <b>" + l_8.Notes + "</b></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Sales Order#:&nbsp; <b>" + so.ordernumber + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">Is RoHS:&nbsp; <b>" + CurrentInspection.lead_free.ToString() + "</b></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Order Date:&nbsp; <b>" + purchase.orderdate.ToShortDateString() + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">QTY:&nbsp; <b>" + CurrentInspection.quantityreceived + "</b></td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"50%\">Received Date:&nbsp; <b>" + CurrentInspection.date_created.ToShortDateString() + "</b></td>");
                sb.AppendLine("    <td width=\"50%\">Received by:&nbsp; <b>" + CurrentInspection.processor_name + "</b></td>");
                sb.AppendLine("  </tr>            ");
                sb.AppendLine("</table>");
                foreach (Rz5.InspectionLine l in GetInspectionLines())
                {
                    sb.Append("<br>" + l.Caption + ":&nbsp;");
                    if (Tools.Strings.HasString(l.Notes, "-NA-"))
                        sb.Append("<font color=\"gray\">" + l.Notes + "</font>");
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
                sb.AppendLine("&nbsp;");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"20%\">Images:&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                ArrayList a = new ArrayList();
                if (Tools.Strings.StrExt(detail_id))
                    a = RzWin.Context.QtC("partpicture", "select * from partpicture where the_orddet_uid = '" + detail_id + "'");
                foreach (partpicture p in a)
                {
                    string file = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".jpg";
                    p.SaveDataAsJpg(RzWin.Context, file, 240, 240);
                    sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                    sb.AppendLine("  <tr>");
                    sb.AppendLine("    <td width=\"25%\"><img border=\"0\" src=\"file:///" + file.Replace("\\", "/") + "\" width=\"100\" height=\"100\"></td>");
                    sb.AppendLine("    <td width=\"75%\">" + p.description + "</td>");
                    sb.AppendLine("  </tr>");
                    sb.AppendLine("</table>");
                }
                string file_name = HtmlToPdfBuilder.GetPDFFromHTML(RzWin.Context, sb.ToString(), Tools.Strings.GetNewID());
                Tools.Files.OpenFileInDefaultViewer(file_name);
                return sb.ToString();
            }
            catch (Exception ee)
            {
                RzWin.Context.TheLeader.Tell("Error: " + ee.Message);
            }
            return "";
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
                            ((RadioButton)subcontrol).Checked = true;
                    }
                }
            }
        }
        private void SetUpAltInspections()
        {
            //Were the parts received in good condition?
            l_1 = new Rz5.InspectionLine();
            l_1.Caption = "Were the parts received in good condition?";
            l_1.FieldYesNo = "parts_good_cond";
            l_1.FieldNotes = "parts_good_cond_notes";
            var child = l_1.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_1);
            //Is the Qty received the amount ordered?
            l_2 = new Rz5.InspectionLine();
            l_2.Caption = "Is the Qty received the amount ordered?";
            l_2.FieldYesNo = "qty_amnt_ordered";
            l_2.FieldNotes = "qty_amnt_ordered_notes";
            child = l_2.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_2);
            //Are the Date Codes received consistent / ordered?
            l_3 = new Rz5.InspectionLine();
            l_3.Caption = "Are the Date Codes received consistent / ordered?";
            l_3.FieldYesNo = "dc_match_ordered";
            l_3.FieldNotes = "dc_match_ordered_notes";
            child = l_3.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_3);
            //Does the MFG match what was ordered?
            l_4 = new Rz5.InspectionLine();
            l_4.Caption = "Does the MFG match what was ordered?";
            l_4.FieldYesNo = "mfg_match_ordered";
            l_4.FieldNotes = "pmfg_match_ordered_notes";
            child = l_4.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_4);
            //Does the cost (if any) match what was ordered?
            l_5 = new Rz5.InspectionLine();
            l_5.Caption = "Does the cost (if any) match what was ordered?";
            l_5.FieldYesNo = "cost_match_ordered";
            l_5.FieldNotes = "cost_match_ordered_notes";
            child = l_5.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_5);
            //Does packaging have a label of Authenticity (Quality Stamp)?
            l_6 = new Rz5.InspectionLine();
            l_6.Caption = "Does packaging have a label of Authenticity (Quality Stamp)?";
            l_6.FieldYesNo = "pkg_label_auth";
            l_6.FieldNotes = "pkg_label_auth_notes";
            child = l_6.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_6);
            //Are the Lot Codes consistent / ordered?
            l_7 = new Rz5.InspectionLine();
            l_7.Caption = "Are the Lot Codes consistent / ordered?";
            l_7.FieldYesNo = "lot_match_ordered";
            l_7.FieldNotes = "lot_match_ordered_notes";
            child = l_7.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_7);
            //Is the Country of Origin (COO) consistent?
            l_8 = new Rz5.InspectionLine();
            l_8.Caption = "Is the Country of Origin (COO) consistent?";
            l_8.FieldYesNo = "country_origin_consistent";
            l_8.FieldNotes = "country_origin_consistent_notes";
            child = l_8.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_8);
            //Are there signs of rework (body, leads, remarking)?
            l_9 = new Rz5.InspectionLine();
            l_9.Caption = "Are there signs of rework (body, leads, remarking)?";
            l_9.FieldYesNo = "signs_rework";
            l_9.FieldNotes = "signs_rework_notes";
            child = l_9.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_9);
            //Did product pass acetone screening?
            l_10 = new Rz5.InspectionLine();
            l_10.Caption = "Did product pass acetone screening?";
            l_10.FieldYesNo = "pass_acetone";
            l_10.FieldNotes = "pass_acetone_notes";
            child = l_10.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_10);
            //Are parts packaged in original manufacturer packaging?
            l_11 = new Rz5.InspectionLine();
            l_11.Caption = "Are parts packaged in original manufacturer packaging?";
            l_11.FieldYesNo = "original_mfg_pkg";
            l_11.FieldNotes = "original_mfg_pkg_notes";
            child = l_11.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_11);
            //Is the PIN1 orientation in the correct place (per OEM datasheet)?
            l_12 = new Rz5.InspectionLine();
            l_12.Caption = "Is the PIN1 orientation in the correct place (per OEM datasheet)?";
            l_12.FieldYesNo = "pin1_correct_loc";
            l_12.FieldNotes = "pin1_correct_loc_notes";
            child = l_12.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_12);
            //Under Microscope, any scratches or sanding marks visible?
            l_13 = new Rz5.InspectionLine();
            l_13.Caption = "Under Microscope, any scratches or sanding marks visible?";
            l_13.FieldYesNo = "micro_sanding";
            l_13.FieldNotes = "micro_sanding_notes";
            child = l_13.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_13);
            //Under Microscope, any solder, oxidation, or other damage to the leads?
            l_14 = new Rz5.InspectionLine();
            l_14.Caption = "Under Microscope, any solder, oxidation, or other damage to the leads?";
            l_14.FieldYesNo = "micro_solder";
            l_14.FieldNotes = "micro_solder_notes";
            child = l_14.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_14);
            //Does this order meet specified order criteria?
            l_15 = new Rz5.InspectionLine();
            l_15.Caption = "Does this order meet specified order criteria?";
            l_15.FieldYesNo = "order_meet_criteria";
            l_15.FieldNotes = "order_meet_criteria_notes";
            child = l_15.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_15);
            //Will parts be released for shipping?
            l_16 = new Rz5.InspectionLine();
            l_16.Caption = "Will parts be released for shipping?";
            l_16.FieldYesNo = "part_to_be_shipped";
            l_16.FieldNotes = "part_to_be_shipped_notes";
            child = l_16.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_16);
            //Do the parts show any evidence of being non-conforming material?
            l_17 = new Rz5.InspectionLine();
            l_17.Caption = "Do the parts show any evidence of being non-conforming material?";
            l_17.FieldYesNo = "parts_nonconfirm_material";
            l_17.FieldNotes = "parts_nonconfirm_material_notes";
            child = l_17.Controls.Find("optNo", true);
            ((RadioButton)child[0]).Checked = true;
            fp.Controls.Add(l_17);
        }
        private void ShowCustomerReport()
        {
            try
            {
                CompleteSave();
                orddet_line l = orddet_line.GetById(RzWin.Context, CurrentInspection.the_orddet_uid);
                ordhed_sales s = ordhed_sales.GetById(RzWin.Context, l.orderid_sales);
                if (l == null)
                    return;
                if (s == null)
                    s = new ordhed_sales();
                string logo = OwnerSettings.GetCompanyLogoPath(RzWin.Context);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"33%\"><img border=\"0\" src=\"" + logo + "\" width=\"143\" height=\"69\"></td>");
                sb.AppendLine("    <td width=\"33%\" align=\"center\"><b><font size=\"6\">Inspection Report</font></b></td>");
                sb.AppendLine("    <td width=\"34%\">&nbsp;</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("&nbsp;");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"20%\">Order Details&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Customer Name:</td>");
                sb.AppendLine("    <td width=\"75%\">" + s.companyname + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Customer PO:</td>");
                sb.AppendLine("    <td width=\"75%\">" + s.orderreference + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Sales Order#:</td>");
                sb.AppendLine("    <td width=\"75%\">" + s.ordernumber + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Inspection Date:</td>");
                sb.AppendLine("    <td width=\"75%\">" + DateTime.Now.ToShortDateString() + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Inspector Initials:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.processor_name + "</td>");
                sb.AppendLine("  </tr>        ");
                sb.AppendLine("</table>");
                sb.AppendLine("&nbsp;");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"20%\">Product Description&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Part#:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.fullpartnumber + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">MFG:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.manufacturer + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">QTY:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.quantityreceived + "</td>");
                sb.AppendLine("  </tr>       ");
                sb.AppendLine("</table>");
                sb.AppendLine("&nbsp;");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"20%\">Receiving Info:&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Condition:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.condition + "</td>"); // l_1.Notes 
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Packaging:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.packaging + "</td>"); //l_11.Notes
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Qty per PKG Unit:</td>");
                sb.AppendLine("    <td width=\"75%\">" + l_12.Notes + "</td>");
                sb.AppendLine("  </tr>   ");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Date Code:</td>");
                sb.AppendLine("    <td width=\"75%\">" + CurrentInspection.datecode + "</td>"); // l_3.Notes 
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">COO:</td>");
                sb.AppendLine("    <td width=\"75%\">" + l_8.Notes + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">RoHS?:</td>");
                sb.AppendLine("    <td width=\"75%\">" + (insLeadFree.IsYes ? "Y" : "N") + " - " + insLeadFree.Notes + "</td>");
                sb.AppendLine("  </tr>   ");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Pin1 orientation consistent:</td>");
                sb.AppendLine("    <td width=\"75%\">" + (l_13.IsYes ? "Y" : "N") + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Part marking authenticity:</td>");
                sb.AppendLine("    <td width=\"75%\">" + (l_9.IsYes ? "Y" : "N") + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Evidence of secondary coating:</td>");
                sb.AppendLine("    <td width=\"75%\">" + (l_10.IsYes ? "Y" : "N") + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Evidence of Solder/Oxidation damage?</td>");
                sb.AppendLine("    <td width=\"75%\">" + (l_15.IsYes ? "Y" : "N") + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\">Other inconsistencies?</td>");
                sb.AppendLine("    <td width=\"75%\">" + (l_16.IsYes ? "Y" : "N") + " - " + l_16.Notes + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                sb.AppendLine("&nbsp;");
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"20%\">Images:&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">&nbsp;</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table>");
                ArrayList a = RzWin.Context.QtC("partpicture", "select * from partpicture where the_orddet_uid = '" + l.unique_id + "'");
                foreach (partpicture p in a)
                {
                    string file = Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".jpg";
                    p.SaveDataAsJpg(RzWin.Context, file, 240, 240);
                    sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                    sb.AppendLine("  <tr>");
                    sb.AppendLine("    <td width=\"25%\"><img border=\"0\" src=\"file:///" + file.Replace("\\", "/") + "\" width=\"100\" height=\"100\"></td>");
                    sb.AppendLine("    <td width=\"75%\">" + p.description + "</td>");
                    sb.AppendLine("  </tr>");
                    sb.AppendLine("</table>");
                }
                string file_name = HtmlToPdfBuilder.GetPDFFromHTML(RzWin.Context, sb.ToString(), Tools.Strings.GetNewID());
                Tools.Files.OpenFileInDefaultViewer(file_name);
            }
            catch { }
        }
        
    }
}
