using System;
using System.Data;
using System.Linq;
using System.Text;
using NewMethod;
using Rz5;
using System.Collections;
using System.Collections.Generic;
//using SensibleDAL;
using System.Windows.Forms;

namespace Rz5.Reports
{
    public partial class ConsignmentReport : Rz5.WebReport_User_Date
    {
        //Private Variables
        private StringBuilder HTML = new StringBuilder();
        private Tools.Dates.DateRange dtRange = new Tools.Dates.DateRange(Tools.Dates.GetBlankDate(), Tools.Dates.GetBlankDate());
        private Rz5.company TheVendor;
        private bool IsPDF = false;
        private bool IsPO = false;
        private DataTable Orders;
        private string viewBy;

        //Constructors
        public ConsignmentReport()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteStructure()
        {
            base.CompleteStructure();
            pbHelp.Image = ilReportImages.Images[0];
            HandleHelpTooltip();

            //btnHelp.BackgroundImage=ilReportImages.G
            lblCaption.Text = "Consignment Report";
            //GetDateParameterValue();
            LoadViewByComboBox();
            dtEnd.SetValue(new DateTime(DateTime.Now.Year, DateTime.Now.Month, GetMonthEnd(DateTime.Now.Month, DateTime.Now.Year)));
            LoadConsignmentVendors();
            cmdExport.Visible = true;
        }



        private void LoadViewByComboBox()
        {
            cboViewBy.Items.Clear();
            cboViewBy.Items.Add("All");
            cboViewBy.Items.Add("Fully Paid");
            //cboViewBy.Items.Add("Open Balance");
            //cboViewBy.SelectedIndex = cboViewBy.FindStringExact("All");
            cboViewBy.SelectedItem = "Fully Paid";
        }

        public override void RunReport()
        {
            try
            {

                base.RunReport();
                ShowThrobber();
                HTML = new StringBuilder();
                dtRange = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
                DataRowView drv = (DataRowView)cboSuppliers.SelectedItem;
                if (drv != null)
                    TheVendor = Rz5.company.GetById(RzWin.Context, drv.Row["vendor_uid"].ToString());
                StartAsync();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex);
            }


        }
        public override void DoAsync()
        {


            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\">");
            sb.AppendLine("      <table border=\"0\" width=\"100%\" cellpadding=\"2\">");
            sb.AppendLine("        <tr>");
            sb.AppendLine("          <td width=\"100%\" align=\"center\"><b><font size=\"5\">Consignment Report</font></b></td>");
            sb.AppendLine("        </tr>");
            sb.AppendLine("        <tr>");
            sb.AppendLine("          <td width=\"100%\" align=\"center\"><b><font size=\"5\" color=\"#000080\">From");
            sb.AppendLine("            " + dtRange.StartDate.ToShortDateString() + " To " + dtRange.EndDate.ToShortDateString() + "</font></b></td>");
            sb.AppendLine("        </tr>");
            sb.AppendLine("      </table>");
            string sup = "ALL";
            if (TheVendor != null)
                sup = "<a href=\"_vendor_" + TheVendor.unique_id + "\">" + TheVendor.companyname + "</a>";
            sb.AppendLine("      <p><b>Supplier Information: " + sup + "</b></p>");
            sb.AppendLine("    </td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            //if (TheVendor == null)
            //    return;


            //string SQL = GetSQL();
            //Orders = RzWin.Context.Select(SQL);
            //if (ctl_ShowOnlyPaid.Checked)
            //    Orders = FilterDataTableByPaid(Orders, dtRange.StartDate, dtRange.EndDate);
            string vendorID = TheVendor != null ? TheVendor.unique_id : "All";
            bool fullyPaidOnly = viewBy.ToLower() == "fully paid";
            Orders = GetConsignmentDataLinq(dtRange.StartDate, dtRange.EndDate, vendorID, fullyPaidOnly);
            if (Orders == null)
                return;

            //RzWin.Context.Leader.Tell("DataTable Count: "+Orders.Rows.Count.ToString());


            //Order by invoice data instead of agentntame
            DataView OrdersDv = Orders.DefaultView;
            OrdersDv.Sort = "orderdate";
            Orders = OrdersDv.ToTable();

            //RzWin.Context.Leader.Tell("DataView Count: " + Orders.Rows.Count.ToString());

            if (Orders == null)
            {
                HTML.Append("<p><b><font size=\"5\" color=\"#FF0000\">No Results</font></b></p>");
                return;
            }
            if (Orders.Rows.Count <= 0)
            {
                HTML.Append("<p><b><font size=\"5\" color=\"#FF0000\">No Results</font></b></p>");
                return;
            }
            //RzWin.Context.Leader.Tell("Appended HTML Count: " + Orders.Rows.Count.ToString());
            if (TheVendor != null)
                sb.AppendLine(GetHTMLSingleVendor());
            else
                sb.AppendLine(GetHTMLAllVendors());
            HTML = sb;
            //RzWin.Context.Leader.Tell(HTML.ToString());
        }

        private DataTable GetConsignmentDataLinq(DateTime start, DateTime end, string companyID, bool fullyPaidOnly)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("vendor_uid");
            dt.Columns.Add("vendor_name");
            dt.Columns.Add("agentname");
            dt.Columns.Add("base_company_uid");
            dt.Columns.Add("companyname");
            dt.Columns.Add("manufacturer");
            dt.Columns.Add("fullpartnumber");
            dt.Columns.Add("quantity_packed");
            dt.Columns.Add("unit_price");
            dt.Columns.Add("pay");
            dt.Columns.Add("keep");
            dt.Columns.Add("unit_pay");
            dt.Columns.Add("unit_keep");
            dt.Columns.Add("total_amnt");
            dt.Columns.Add("pay_keep");
            dt.Columns.Add("Account");
            dt.Columns.Add("ordernumber_sales");
            dt.Columns.Add("ordernumber_invoice");
            dt.Columns.Add("orderdate_invoice");
            dt.Columns.Add("orderid_invoice");
            dt.Columns.Add("orderdate");
            dt.Columns.Add("consignment_code");
            dt.Columns.Add("inventory_link_uid");
            //NEed to target SensibleDAL. instead of "using", else there will be ambiguity with other SensibleDAL objects like "partrecord", etc.
            List<SensibleDAL.ConsignmentData.ConsignmentSalesData> cList = new List<SensibleDAL.ConsignmentData.ConsignmentSalesData>();
            SensibleDAL.ConsignmentData csd = new SensibleDAL.ConsignmentData();
            //cList = csd.GetConsignmentSalesData(start, end, companyID, FullyPaid);            
            cList = csd.GetConsignmentData(start, end, companyID, fullyPaidOnly);




            foreach (var r in cList)
            {

                dt.Rows.Add(
                    r.VendorUid, //vendor_uid
                    r.VendorName, //vendor_name
                    r.Agent, // agentname
                    r.CustomerUid, // base_company_uid
                    r.CustomerName, //companyname
                    r.MFG, //manufacturer
                    r.PartNumber,//fullpartnumber
                    r.QTY, //quantity_packed
                    r.UnitPrice, //unit_price
                    r.PayoutAmnt, //pay
                    r.KeepAmnt, //keep
                    r.UnitPayoutAmnt,
                    r.UnitKeepAmnt,
                    r.TotalPrice, //total_amnt
                    r.PayKeepPct, //pay_keep                    
                    r.PaymentAccount, //Account
                    r.SO, //ordernumber_salse
                    r.InvoiceNumber, //ordernumber_invoice
                    r.InvoiceDate, //orderdate_invoice
                    r.InvoiceID, //orderid_invoice
                    r.InvoicePaymentDate, //orderdate
                    r.ConsignmentCode, //consignment_code
                    r.InventoryLinkUID
                    );
            }
            //Orders = Tools.Lists.ToDataTable(cList); // No Good, because I need to match the column names in Recognin's html strings, or rewrite it all.
            //return Orders;
            //dt.DefaultView.Sort = "InvoiceDate";
            return dt;
        }

        private string GetViewBy()
        {
            string text = "";
            text = cboViewBy.GetItemText(cboViewBy.SelectedItem);
            return text;
        }



        public override void AsyncFinished()
        {
            base.AsyncFinished();
            wb.ReloadWB();
            wb.Add(HTML.ToString());
            HideThrobber();
            if (IsPDF)
                DoPDF();
            if (IsPO)
                SendToPO();
        }
        public override void DoExport()
        {
            HTML = new StringBuilder();
            dtRange = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            DataRowView drv = (DataRowView)cboSuppliers.SelectedItem;
            if (drv != null)
                TheVendor = Rz5.company.GetById(RzWin.Context, drv.Row["vendor_uid"].ToString());
            if (dtRange == null)
            {
                RzWin.Context.TheLeader.Tell("No Results found.");
                return;
            }
            //string SQL = GetSQL();
            //DataTable dt = RzWin.Context.Select(SQL);
            bool fullyPaidOnly = viewBy == "fully paid";
            DataTable dt = GetConsignmentDataLinq(dtRange.StartDate, dtRange.EndDate, TheVendor.unique_id, fullyPaidOnly);


            if (dt == null)
            {
                RzWin.Context.TheLeader.Tell("No Results found.");
                return;
            }
            if (dt.Rows.Count <= 0)
            {
                RzWin.Context.TheLeader.Tell("No Results found.");
                return;
            }
            StringBuilder sb = new StringBuilder();
            if (TheVendor != null)
                sb.Append(GetCSVSingleVendor(dt));
            else
                sb.Append(GetCSVAllVendors(dt));
            string file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".csv";
            Tools.Files.SaveFileAsString(file, sb.ToString());
            if (Tools.Files.FileExists(file))
                Tools.Files.OpenFileInDefaultViewer(file);
        }
        //Private Functions
        private string GetHTMLSingleVendor()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Agent</font></b></td>");
                sb.AppendLine("    <td width=\"12%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Customer</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">MFG</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Part Number</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Quantity</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Price</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Total Amount</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Pay/Keep %</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Pay Amount</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Keep Amount</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Account</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">SO #</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Invoice #</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Inv Date</font></b></td>");
                sb.AppendLine("  </tr>");
                double total_amt = 0;
                double total_pay = 0;
                double total_keep = 0;
                foreach (DataRow dr in Orders.Rows)
                {
                    sb.AppendLine("  <tr>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + dr["agentname"].ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"12%\" align=\"center\"><a href=\"_company_" + dr["base_company_uid"].ToString() + "\"><font size=\"2\">" + dr["companyname"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + dr["manufacturer"].ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + dr["fullpartnumber"].ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + nData.NullFilter_Int64(dr["quantity_packed"]).ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">$" + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_price"])) + "&nbsp;</font></td>");
                    double pay = nData.NullFilter_Double(dr["pay"]);
                    double keep = nData.NullFilter_Double(dr["keep"]);
                    double total = nData.NullFilter_Double(dr["total_amnt"]);
                    double consignmentPercent = nData.NullFilter_Double(dr["pay_keep"]);
                    //string pay_keep = GetPayKeepString(dr);
                    string pay_keep = nData.NullFilter_String(dr["pay_keep"]);
                    if (total > 0)
                        total_amt += total;
                    if (pay > 0)
                        total_pay += pay;
                    if (keep > 0)
                        total_keep += keep;
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">$" + Tools.Number.MoneyFormat_2_6(total) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + pay_keep + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font color=\"#FF0000\" size=\"2\">$" + Tools.Number.MoneyFormat_2_6(pay) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font color=\"#008000\" size=\"2\">$" + Tools.Number.MoneyFormat_2_6(keep) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + GetPaymentAccount(dr) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><a href=\"_sales_" + dr["ordernumber_sales"].ToString() + "\"><font size=\"2\">" + dr["ordernumber_sales"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><a href=\"_invoice_" + dr["ordernumber_invoice"].ToString() + "\"><font size=\"2\">" + dr["ordernumber_invoice"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + Convert.ToDateTime(dr["orderdate_invoice"]).ToString("d") + "&nbsp;</font></a></td>");

                    sb.AppendLine("  </tr>");
                }
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"100%\" colspan=\"12\"><hr></td>");
                sb.AppendLine("  </tr>  ");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">$" + Tools.Number.MoneyFormat(total_amt) + "&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font color=\"#FF0000\" size=\"3\">$" + Tools.Number.MoneyFormat(total_pay) + "&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font color=\"#008000\" size=\"3\">$" + Tools.Number.MoneyFormat(total_keep) + "&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"8%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("  </tr>  ");
                sb.AppendLine("</table>");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
            return "";
        }
        private string GetHTMLAllVendors()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"11%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Supplier</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Agent</font></b></td>");
                sb.AppendLine("    <td width=\"12%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Customer</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">MFG</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Part Number</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Quantity</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Price</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Total Amount</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Pay/Keep %</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Pay Amount</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Keep Amount</font></b></td>");
                sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Account</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">SO #</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Invoice #</font></b></td>");
                sb.AppendLine("    <td width=\"7%\" bgcolor=\"#E9E9E9\" align=\"center\"><b><font size=\"4\">Inv Date</font></b></td>");
                sb.AppendLine("  </tr>");
                double total_amt = 0;
                double total_pay = 0;
                double total_keep = 0;
                foreach (DataRow dr in Orders.Rows)
                {
                    sb.AppendLine("  <tr>");
                    sb.AppendLine("    <td width=\"11%\" align=\"center\"><a href=\"_vendor_" + dr["vendor_uid"].ToString() + "\"><font size=\"2\">" + dr["vendor_name"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">" + dr["agentname"].ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"12%\" align=\"center\"><a href=\"_company_" + dr["base_company_uid"].ToString() + "\"><font size=\"2\">" + dr["companyname"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">" + dr["manufacturer"].ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">" + dr["fullpartnumber"].ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">" + nData.NullFilter_Int64(dr["quantity_packed"]).ToString() + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">$" + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_price"])) + "&nbsp;</font></td>");
                    double pay = nData.NullFilter_Double(dr["pay"]);
                    double keep = nData.NullFilter_Double(dr["keep"]);
                    double total = nData.NullFilter_Double(dr["total_amnt"]);
                    double consignmentPercent = nData.NullFilter_Double(dr["pay_keep"]);
                    //string pay_keep = GetPayKeepString(dr);
                    string pay_keep = nData.NullFilter_String(dr["pay_keep"]);
                    //For right now, Fred doesn't want RMA's to be included in the totals (so skipping them if negative)
                    if (total > 0)
                        total_amt += total;
                    if (pay > 0)
                        total_pay += pay;
                    if (keep > 0)
                        total_keep += keep;
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">$" + Tools.Number.MoneyFormat(total) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font size=\"2\">" + pay_keep + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font color=\"#FF0000\" size=\"2\">$" + Tools.Number.MoneyFormat(pay) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><font color=\"#008000\" size=\"2\">$" + Tools.Number.MoneyFormat(keep) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + GetPaymentAccount(dr) + "&nbsp;</font></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><a href=\"_sales_" + dr["ordernumber_sales"].ToString() + "\"><font size=\"2\">" + dr["ordernumber_sales"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"7%\" align=\"center\"><a href=\"_invoice_" + dr["ordernumber_invoice"].ToString() + "\"><font size=\"2\">" + dr["ordernumber_invoice"].ToString() + "&nbsp;</font></a></td>");
                    sb.AppendLine("    <td width=\"8%\" align=\"center\"><font size=\"2\">" + Convert.ToDateTime(dr["orderdate_invoice"]).ToString("d") + "&nbsp;</font></a></td>");
                    sb.AppendLine("  </tr>");
                }
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"100%\" colspan=\"12\"><hr></td>");
                sb.AppendLine("  </tr>  ");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"11%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"12%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">$" + Tools.Number.MoneyFormat(total_amt) + "&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\">&nbsp;</td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font color=\"#FF0000\" size=\"3\">$" + Tools.Number.MoneyFormat(total_pay) + "&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font color=\"#008000\" size=\"3\">$" + Tools.Number.MoneyFormat(total_keep) + "&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("    <td width=\"7%\" align=\"center\" bgcolor=\"#E9E9E9\"><font size=\"3\">&nbsp;</font></td>");
                sb.AppendLine("  </tr>  ");
                sb.AppendLine("</table>");
                return sb.ToString();
            }
            catch { }
            return "";
        }
        private string GetCSVSingleVendor(DataTable dt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Consignment Report,,,,,,,,,,,");
                sb.AppendLine("From " + dtRange.StartDate.ToShortDateString() + " To " + dtRange.EndDate.ToShortDateString() + ",,,,,,,,,,,");
                sb.AppendLine("Supplier Info: " + TheVendor.companyname + ",,,,,,,,,,,");
                sb.AppendLine(",,,,,,,,,,,");
                sb.AppendLine("Agent,Customer,MFG,Part Number,Quantity,Price,Total Amount,Pay/Keep %,Pay Amount,Keep Amount,SO #,Invoice #");
                sb.AppendLine(",,,,,,,,,,,");
                double total_amt = 0;
                double total_pay = 0;
                double total_keep = 0;
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sb.Append("\"" + dr["agentname"].ToString() + "\",");
                        sb.Append("\"" + dr["companyname"].ToString() + "\",");
                        sb.Append("\"" + dr["manufacturer"].ToString() + "\",");
                        sb.Append("\"" + dr["fullpartnumber"].ToString() + "\",");
                        sb.Append("\"" + nData.NullFilter_Int64(dr["quantity_packed"]).ToString() + "\",");
                        sb.Append("\"$" + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_price"])) + "\",");
                        double pay = nData.NullFilter_Double(dr["pay"]);
                        double keep = nData.NullFilter_Double(dr["keep"]);
                        double total = nData.NullFilter_Double(dr["total_amnt"]);
                        double consignmentPercent = nData.NullFilter_Double(dr["pay_keep"]);
                        //string pay_keep = GetPayKeepString(dr);
                        string pay_keep = nData.NullFilter_String(dr["pay_keep"]);
                        total_amt += total;
                        total_pay += pay;
                        total_keep += keep;
                        sb.Append("\"$" + Tools.Number.MoneyFormat(total) + "\",");
                        sb.Append("\"" + pay_keep + "\",");
                        sb.Append("\"$" + Tools.Number.MoneyFormat(pay) + "\",");
                        sb.Append("\"$" + Tools.Number.MoneyFormat(keep) + "\",");
                        sb.Append("\"" + dr["ordernumber_sales"].ToString() + "\",");
                        sb.Append("\"" + dr["ordernumber_invoice"].ToString() + "\"");
                        sb.AppendLine();
                    }
                }
                sb.AppendLine(",,,,,,\"$" + Tools.Number.MoneyFormat(total_amt) + "\",,\"$" + Tools.Number.MoneyFormat(total_pay) + "\",\"$" + Tools.Number.MoneyFormat(total_keep) + "\",,");
                return sb.ToString();
            }
            catch { }
            return "";
        }
        private string GetCSVAllVendors(DataTable dt)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Consignment Report,,,,,,,,,,,");
                sb.AppendLine("From " + dtRange.StartDate.ToShortDateString() + " To " + dtRange.EndDate.ToShortDateString() + ",,,,,,,,,,,");
                sb.AppendLine("Supplier Info: ALL,,,,,,,,,,,,");
                sb.AppendLine(",,,,,,,,,,,,");
                sb.AppendLine("Supplier,Agent,Customer,MFG,Part Number,Quantity,Price,Total Amount,Pay/Keep %,Pay Amount,Keep Amount,SO #,Invoice #");
                sb.AppendLine(",,,,,,,,,,,,");
                double total_amt = 0;
                double total_pay = 0;
                double total_keep = 0;
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sb.Append("\"" + dr["vendor_name"].ToString() + "\",");
                        sb.Append("\"" + dr["agentname"].ToString() + "\",");
                        sb.Append("\"" + dr["companyname"].ToString() + "\",");
                        sb.Append("\"" + dr["manufacturer"].ToString() + "\",");
                        sb.Append("\"" + dr["fullpartnumber"].ToString() + "\",");
                        sb.Append("\"" + nData.NullFilter_Int64(dr["quantity_packed"]).ToString() + "\",");
                        sb.Append("\"$" + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_price"])) + "\",");
                        double pay = nData.NullFilter_Double(dr["pay"]);
                        double keep = nData.NullFilter_Double(dr["keep"]);
                        double total = nData.NullFilter_Double(dr["total_amnt"]);
                        double consignmentPercent = nData.NullFilter_Double(dr["pay_keep"]);
                        //string pay_keep = GetPayKeepString(dr);
                        string pay_keep = nData.NullFilter_String(dr["pay_keep"]);
                        total_amt += total;
                        total_pay += pay;
                        total_keep += keep;
                        sb.Append("\"$" + Tools.Number.MoneyFormat(total) + "\",");
                        sb.Append("\"" + pay_keep + "\",");
                        sb.Append("\"$" + Tools.Number.MoneyFormat(pay) + "\",");
                        sb.Append("\"$" + Tools.Number.MoneyFormat(keep) + "\",");
                        sb.Append("\"" + dr["ordernumber_sales"].ToString() + "\",");
                        sb.Append("\"" + dr["ordernumber_invoice"].ToString() + "\"");
                        sb.AppendLine();
                    }
                }
                sb.AppendLine(",,,,,,,\"$" + Tools.Number.MoneyFormat(total_amt) + "\",,\"$" + Tools.Number.MoneyFormat(total_pay) + "\",\"$" + Tools.Number.MoneyFormat(total_keep) + "\",,");
                return sb.ToString();
            }
            catch { }
            return "";
        }
        private void DoPDF()
        {
            IsPDF = false;
            try
            {
                string file = PDFBuilder.HtmlToPdfBuilder.GetPDFFromHTML(RzWin.Context, HTML.ToString(), Tools.Strings.GetNewID());
                if (Tools.Files.FileExists(file))
                    Tools.Files.OpenFileInDefaultViewer(file);
            }
            catch { }
        }
        private void SendToPO()
        {
            // Set cursor as hourglass
            Cursor.Current = Cursors.WaitCursor;
            // Execute your time-intensive hashing code here...
            IsPO = false;
            try
            {
                if (TheVendor == null)
                {
                    RzWin.Context.TheLeader.Tell("No supplier found.");
                    return;
                }
                if (Orders == null)
                {
                    RzWin.Context.TheLeader.Tell("No results found for this supplier.");
                    return;
                }
                if (Orders.Rows.Count <= 0)
                {
                    RzWin.Context.TheLeader.Tell("No results found for this supplier.");
                    return;
                }
                ordhed_purchase p = (ordhed_purchase)Rz5.ordhed.CreateNew(RzWin.Context, Rz5.Enums.OrderType.Purchase);
                p.is_consign = true;
                p.AbsorbCompany(RzWin.Context, TheVendor);
                if (Tools.Strings.StrExt(p.unique_id))
                    p.Update(RzWin.Context);
                else
                    p.Insert(RzWin.Context);
                foreach (DataRow dr in Orders.Rows)
                {
                    orddet_line l = (orddet_line)p.GetNewDetail(RzWin.Context);
                    l.fullpartnumber = dr["fullpartnumber"].ToString();
                    l.manufacturer = dr["manufacturer"].ToString();
                    l.quantity = nData.NullFilter_Int32(dr["quantity_packed"]);
                    l.quantity_unpacked = l.quantity;
                    l.consignment_code = nData.NullFilter(dr["consignment_code"]);
                    //KT - We don't care about cost for consignment, cost is determined by final sale amount
                    //switching unit_cost to derive from the dt.unit_price
                    //Often, the code below will still work, but only if the cost is divisible by the price
                    //byt the exact split amount.  i.e. cost=.5 and price = .5 would be fine, but .51 and.5 wont work.
                    //Remember users have the ability to change cost, so ignoring it is a good idea for CONSIGNMENT ONLY.
                    //l.consignment_percent = nData.NullFilter_Int32(dr["consignment_percent"]);


                    //Since the PO using unit Price, unlike the reports, need to set those values.
                    SetPOPayKeepValues(dr, l);
                    //string pay_keep = GetPayKeepString(dr);
                    string pay_keep = nData.NullFilter_String(dr["pay_keep"]);

                    
                    l.StockType = Rz5.Enums.StockType.Consign;
                    l.Status = Rz5.Enums.OrderLineStatus.Received;
                    l.was_received = true;
                    if (Tools.Strings.StrExt(l.unique_id))
                        l.Update(RzWin.Context);
                    else
                        l.Insert(RzWin.Context);
                }
                RzWin.Context.Show(p);
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                // Set cursor as default arrow
                Cursor.Current = Cursors.Default;
                RzWin.Context.Leader.Tell(ex.Message);
            }
        }

        private void SetPOPayKeepValues(DataRow dr, orddet_line l)
        {
            double totalpay = nData.NullFilter_Double(dr["pay"]);
            double totalkeep = nData.NullFilter_Double(dr["keep"]);
            double unitpay = nData.NullFilter_Double(dr["unit_pay"]);
            double unitkeep = nData.NullFilter_Double(dr["unit_keep"]);
            double total = nData.NullFilter_Double(dr["total_amnt"]);
            double consignmentPercent = nData.NullFilter_Double(dr["pay_keep"]);
            l.unit_cost = unitpay;            
            l.unit_price = unitkeep;



        }



        private string GetPayKeepString(DataRow dr)
        {
            if (dr == null)
                return "None";
            string name = dr["consignment_code"].ToString();
            string id = dr["vendor_uid"].ToString();
            if (!Tools.Strings.StrExt(name))
                return "None";
            if (!Tools.Strings.StrExt(id))
                return "None";
            consignment_code c = (consignment_code)RzWin.Context.QtO("consignment_code", "select * from consignment_code where code_name = '" + RzWin.Context.Filter(name) + "' and vendor_uid = '" + id + "'");
            if (c == null)
                return "None";
            return c.payout_percent.ToString() + "/" + c.keep_percent.ToString();
        }


        private string GetPaymentAccount(DataRow dr)
        {
            string ret = "";
            if (dr == null)
                return "None";
            string orderid = dr["orderid_invoice"].ToString();
            string vendoruid = dr["vendor_uid"].ToString();
            ArrayList cps = RzWin.Context.QtC("checkpayment", "select * from checkpayment where base_ordhed_uid = '" + RzWin.Context.Filter(orderid) + "'");
            if (cps.Count <= 0)
                return "NP";
            int i = 1;
            //Save them in an List rather than string += so I can say if(!Contains) to skip dupes.?
            //List<string> AccountList = new List<string>();
            foreach (checkpayment cpp in cps)
            {

                if (string.IsNullOrEmpty(cpp.qb_account))
                    ret += "MISSING";
                else
                    ret += cpp.qb_account;
                if (i < cps.Count)
                    ret += ",  ";
                i++;

            }
            return ret.Trim();
        }

        private void LoadConsignmentVendors()
        {
            cboSuppliers.DataSource = null;
            cboSuppliers.SelectedItem = null;
            try
            {
                DataTable dt = RzWin.Context.Select("select '<All>' as vendor_uid, '<All>' as vendor_name union select distinct(vendor_uid)as vendor_uid,max(vendor_name)as vendor_name from consignment_code group by vendor_uid order by vendor_name");
                cboSuppliers.DataSource = dt;
                cboSuppliers.DisplayMember = "vendor_name";
                cboSuppliers.ValueMember = "vendor_uid";
            }
            catch { }
        }
        private Int32 GetMonthEnd(Int32 month, Int32 year)
        {
            switch (month)
            {
                case 1: //Jan
                    return 31;
                case 2: //Feb
                    if (DateTime.IsLeapYear(year))
                        return 29;
                    else
                        return 28;
                case 3: //March
                    return 31;
                case 4: //April
                    return 30;
                case 5: //May
                    return 31;
                case 6: //June
                    return 30;
                case 7: //July
                    return 31;
                case 8: //Aug
                    return 31;
                case 9: //Sept
                    return 30;
                case 10: //Oct
                    return 31;
                case 11: //Nov
                    return 30;
                case 12: //Dec
                    return 31;
                default:
                    return 31;
            }
        }
        private void CheckPO()
        {
            cmdPO.Enabled = true;
            DataRowView drv = (DataRowView)cboSuppliers.SelectedItem;
            if (drv != null)
            {
                if (Tools.Strings.StrCmp(drv.Row["vendor_uid"].ToString(), "<all>"))
                    cmdPO.Enabled = false;
            }
        }
        //Buttons
        private void cmdPO_Click(object sender, EventArgs e)
        {
            IsPO = true;
            RunReport();
        }
        private void cmdPDF_Click(object sender, EventArgs e)
        {
            IsPDF = true;
            RunReport();
        }
        //Control Events
        private void wb_OnNavigate(Tools.GenericEvent e)
        {
            string id = "";
            if (e.Message.ToLower().Contains("_vendor_"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "_vendor_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                Rz5.company v = Rz5.company.GetById(RzWin.Context, id);
                if (v == null)
                    return;
                RzWin.Context.Show(v);
            }
            else if (e.Message.ToLower().Contains("_company_"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "_company_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                Rz5.company c = Rz5.company.GetById(RzWin.Context, id);
                if (c == null)
                    return;
                RzWin.Context.Show(c);
            }
            else if (e.Message.ToLower().Contains("_sales_"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "_sales_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                Rz5.ordhed_sales s = (Rz5.ordhed_sales)RzWin.Context.QtO("ordhed_sales", "select * from ordhed_sales where ordernumber = '" + id + "' and ordertype = 'sales'");
                if (s == null)
                    return;
                RzWin.Context.Show(s);
            }
            else if (e.Message.ToLower().Contains("_invoice_"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "_invoice_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                Rz5.ordhed_invoice i = (Rz5.ordhed_invoice)RzWin.Context.QtO("ordhed_invoice", "select * from ordhed_invoice where ordernumber = '" + id + "' and ordertype = 'invoice'");
                if (i == null)
                    return;
                RzWin.Context.Show(i);
            }
        }
        private void cboSuppliers_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckPO();
        }
        private void cboSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPO();
        }

        private void ctl_ShowOnlyPaid_CheckedChanged(object sender, EventArgs e)
        {
            // GetDateParameterValue();
        }

        private void cboViewBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetViewByParameters();
        }



        private void GetViewByParameters()
        {

            //Fully Paid
            //Open Balance
            //All
            string text = "";
            viewBy = GetViewBy();
            switch (viewBy.ToLower())
            {
                case "all":
                case "open balance":
                    text = "<Date Invoiced>";
                    break;
                case "fully paid":
                    text = "<Date Paid>";
                    break;
            }


            lblDateParameter.Text = text;
        }

        private void HandleHelpTooltip()
        {
            GetViewByParameters();
            toolTip1.ReshowDelay = 0;
            toolTip1.InitialDelay = 0;
            toolTip1.IsBalloon = true;

            string text = "";
            switch (viewBy.ToLower())
            {
                case "all":
                    text = "Invoices containing consignment lines matching selected parameters.  The date range used is \"Invoice Created Date\"";
                    break;
                case "open balance":
                    text = "Invoices containing consignment lines with an open balance matching selected parameters.   The date range used is \"Invoice Created Date\"";
                    break;
                case "fully paid":
                    text = "Fully paid invoices containing consignment lines that were paid in full matching selected parameters.   The date range used is \"Invoice Paid Date\"";
                    break;
            }
            toolTip1.SetToolTip(pbHelp, text);
        }

        private void pbHelp_MouseHover(object sender, EventArgs e)
        {
            HandleHelpTooltip();
        }
    }
}
