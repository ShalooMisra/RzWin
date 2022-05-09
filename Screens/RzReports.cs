using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class RzReports : WebReport_User_Date 
    {
        //Private Variables
        private RzReportArgs TheArgs;

        //Constructors
        public RzReports()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void Init()
        {
            base.Init();
            optReqsByAgent.Checked = true;
        }
        public override void CompleteStructure()
        {
            base.CompleteStructure();
            cmdExport.Visible = true;
            SetCaption("Reports");
            dtStart.SetValue(nTools.GetMonthStart(DateTime.Now));
            dtEnd.SetValue(nTools.GetMonthEnd(DateTime.Now));
        }
        public override void RunReport()
        {
            TheArgs = new RzReportArgs();
            TheArgs.TheAgents = GetUserIDCollection_BlankIfAll();
            TheArgs.TheDates = GetDateRange();
            TheArgs.TheType = GetReportType(); 
            ShowThrobber();
            wb.ReloadWB();
            wb.Add("Calculating...");
            base.RunReport();
            StartAsync();
        }
        public override void DoAsync()
        {
            base.DoAsync();
            if (TheArgs == null)
                return;
            switch (TheArgs.TheType)
            {
                case RzReportType.QuotesByAgent:
                    RunQuotesByAgent();
                    break;
                case RzReportType.InvoicesByAgent:
                    RunInvoicesByAgent();
                    break;
                case RzReportType.TopCusts:
                    RunTopCusts();
                    break;
                case RzReportType.TopVendors:
                    RunTopVendors();
                    break;
                case RzReportType.TopHotParts:
                    RunTopHotParts();
                    break;
                default: //ReqsByAgent
                    RunReqsByAgent();
                    break;
            }
        }
        public override void AsyncFinished()
        {
            base.AsyncFinished();
            string html = "";
            if (TheArgs != null)
                html = TheArgs.TheHTML.ToString();
            wb.ReloadWB();
            wb.Add(html);
            HideThrobber();
        }
        public override void DoExport()
        {
            base.DoExport();
        }
        //Private Functions
        private RzReportType GetReportType()
        {
            if (optReqsByAgent.Checked)
                return RzReportType.ReqsByAgent;
            if (optQuotesByAgent.Checked)
                return RzReportType.QuotesByAgent;
            if (optInvoiceByAgent.Checked)
                return RzReportType.InvoicesByAgent;
            if (optTopCusts.Checked)
                return RzReportType.TopCusts;
            if (optTopVendors.Checked)
                return RzReportType.TopVendors;
            if (optTopHotParts.Checked)
                return RzReportType.TopHotParts;
            return RzReportType.ReqsByAgent;
        }
        private bool CheckDT(DataTable dt)
        {
            if (dt == null)
            {
                TheArgs.TheHTML = new StringBuilder();
                TheArgs.TheHTML.AppendLine("<b><font size=\"4\" color=\"#FF0000\">No Results.</font></b>");
                return false;
            }
            if (dt.Rows.Count <= 0)
            {
                TheArgs.TheHTML = new StringBuilder();
                TheArgs.TheHTML.AppendLine("<b><font size=\"4\" color=\"#FF0000\">No Results.</font></b>");
                return false;
            }
            return true;
        }
        private void RunReqsByAgent()
        {
            try
            {
                string sql = GetReqsByAgentSQL();
                DataTable dt = RzWin.Context.Select(sql);
                if (!CheckDT(dt))
                    return;
                ExportTable = dt;
                TheArgs.TheHTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Requirements By Agent</b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>From <font color=\"#000080\">" + TheArgs.TheDates.StartDate.ToShortDateString() + "</font>");
                TheArgs.TheHTML.AppendLine("      To <font color=\"#000080\">" + TheArgs.TheDates.EndDate.ToShortDateString() + "</font></b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("</table>");
                TheArgs.TheHTML.AppendLine("&nbsp;");
                TheArgs.TheHTML.AppendLine("<table border=\"1\" width=\"100%\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"33%\" bgcolor=\"#E5E5E5\"><b>Agent Name</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"33%\" bgcolor=\"#E5E5E5\"><b>Requirement Count</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"34%\" bgcolor=\"#E5E5E5\"><b>Requirement Value (Based on TP)</b></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    TheArgs.TheHTML.AppendLine("  <tr>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"33%\"><font color=\"#000080\">" + dr["agentname"].ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"33%\"><font color=\"#000080\">" + Tools.Data.NullFilterInt(dr["reqcount"]).ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"34%\" align=\"right\"><font color=\"#000080\">$" + Tools.Number.MoneyFormat(nData.NullFilter_Double(dr["total_req_value"])) + "</font></td>");
                    TheArgs.TheHTML.AppendLine("  </tr>");
                }
                TheArgs.TheHTML.AppendLine("</table>");
            }
            catch { }
        }
        private void RunQuotesByAgent()
        {
            try
            {
                string sql = GetQuotesByAgentSQL();
                DataTable dt = RzWin.Context.Select(sql);
                if (!CheckDT(dt))
                    return;
                ExportTable = dt;
                TheArgs.TheHTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Quotes By Agent</b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>From <font color=\"#000080\">" + TheArgs.TheDates.StartDate.ToShortDateString() + "</font>");
                TheArgs.TheHTML.AppendLine("      To <font color=\"#000080\">" + TheArgs.TheDates.EndDate.ToShortDateString() + "</font></b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("</table>");
                TheArgs.TheHTML.AppendLine("&nbsp;");
                TheArgs.TheHTML.AppendLine("<table border=\"1\" width=\"100%\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"33%\" bgcolor=\"#E5E5E5\"><b>Agent Name</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"33%\" bgcolor=\"#E5E5E5\"><b>Quote Count</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"34%\" bgcolor=\"#E5E5E5\"><b>Quote Value</b></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    TheArgs.TheHTML.AppendLine("  <tr>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"33%\"><font color=\"#000080\">" + dr["agentname"].ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"33%\"><font color=\"#000080\">" + Tools.Data.NullFilterInt(dr["quotecount"]).ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"34%\" align=\"right\"><font color=\"#000080\">$" + Tools.Number.MoneyFormat(nData.NullFilter_Double(dr["total_quote_value"])) + "</font></td>");
                    TheArgs.TheHTML.AppendLine("  </tr>");
                }
                TheArgs.TheHTML.AppendLine("</table>");
            }
            catch { }
        }
        private void RunInvoicesByAgent()
        {
            try
            {
                string sql = GetInvoicesByAgentSQL();
                DataTable dt = RzWin.Context.Select(sql);
                if (!CheckDT(dt))
                    return;
                ExportTable = dt;
                TheArgs.TheHTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Invoice Total By Agent</b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>From <font color=\"#000080\">" + TheArgs.TheDates.StartDate.ToShortDateString() + "</font>");
                TheArgs.TheHTML.AppendLine("      To <font color=\"#000080\">" + TheArgs.TheDates.EndDate.ToShortDateString() + "</font></b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("</table>");
                TheArgs.TheHTML.AppendLine("&nbsp;");
                TheArgs.TheHTML.AppendLine("<table border=\"1\" width=\"100%\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Agent Name</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Invoice Amount</b></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    TheArgs.TheHTML.AppendLine("  <tr>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">" + dr["agentname"].ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">$ " + Tools.Number.MoneyFormat(nData.NullFilter_Double(dr["invoicetotal"])) + "</font></td>");
                    TheArgs.TheHTML.AppendLine("  </tr>");
                }
                TheArgs.TheHTML.AppendLine("</table>");
            }
            catch { }
        }
        private void RunTopCusts()
        {
            try
            {
                string sql = GetTopCustsSQL();
                DataTable dt = RzWin.Context.Select(sql);
                if (!CheckDT(dt))
                    return;
                ExportTable = dt;
                TheArgs.TheHTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Top 5 Customers (Invoice)</b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>From <font color=\"#000080\">" + TheArgs.TheDates.StartDate.ToShortDateString() + "</font>");
                TheArgs.TheHTML.AppendLine("      To <font color=\"#000080\">" + TheArgs.TheDates.EndDate.ToShortDateString() + "</font></b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("</table>");
                TheArgs.TheHTML.AppendLine("&nbsp;");
                TheArgs.TheHTML.AppendLine("<table border=\"1\" width=\"100%\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Customer Name</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Total Invoice Amount</b></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                int count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    count++;
                    TheArgs.TheHTML.AppendLine("  <tr>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">" + dr["companyname"].ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">$ " + Tools.Number.MoneyFormat(nData.NullFilter_Double(dr["total_inv"])) + "</font></td>");
                    TheArgs.TheHTML.AppendLine("  </tr>");
                    if (count >= 5)
                        break;
                }
                TheArgs.TheHTML.AppendLine("</table>");
            }
            catch { }
        }
        private void RunTopVendors()
        {
            try
            {
                string sql = GetTopVendorsSQL();
                DataTable dt = RzWin.Context.Select(sql);
                if (!CheckDT(dt))
                    return;
                ExportTable = dt;
                TheArgs.TheHTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Top 5 Vendors (Purchase)</b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>From <font color=\"#000080\">" + TheArgs.TheDates.StartDate.ToShortDateString() + "</font>");
                TheArgs.TheHTML.AppendLine("      To <font color=\"#000080\">" + TheArgs.TheDates.EndDate.ToShortDateString() + "</font></b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("</table>");
                TheArgs.TheHTML.AppendLine("&nbsp;");
                TheArgs.TheHTML.AppendLine("<table border=\"1\" width=\"100%\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Vendor Name</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Total Purchase Amount</b></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                int count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    count++;
                    TheArgs.TheHTML.AppendLine("  <tr>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">" + dr["companyname"].ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">$ " + Tools.Number.MoneyFormat(nData.NullFilter_Double(dr["total_purch"])) + "</font></td>");
                    TheArgs.TheHTML.AppendLine("  </tr>");
                    if (count >= 5)
                        break;
                }
                TheArgs.TheHTML.AppendLine("</table>");
            }
            catch { }
        }
        private void RunTopHotParts()
        {
            try
            {
                string sql = GetTopHotPartsSQL();
                DataTable dt = RzWin.Context.Select(sql);
                if (!CheckDT(dt))
                    return;
                ExportTable = dt;
                TheArgs.TheHTML.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Top 5 Hot Parts (Reqs)</b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>From <font color=\"#000080\">" + TheArgs.TheDates.StartDate.ToShortDateString() + "</font>");
                TheArgs.TheHTML.AppendLine("      To <font color=\"#000080\">" + TheArgs.TheDates.EndDate.ToShortDateString() + "</font></b></font></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                TheArgs.TheHTML.AppendLine("</table>");
                TheArgs.TheHTML.AppendLine("&nbsp;");
                TheArgs.TheHTML.AppendLine("<table border=\"1\" width=\"100%\">");
                TheArgs.TheHTML.AppendLine("  <tr>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Part Number</b></td>");
                TheArgs.TheHTML.AppendLine("    <td width=\"50%\" bgcolor=\"#E5E5E5\"><b>Req Amount</b></td>");
                TheArgs.TheHTML.AppendLine("  </tr>");
                int count = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    count++;
                    TheArgs.TheHTML.AppendLine("  <tr>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">" + dr["fullpartnumber"].ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("    <td width=\"50%\"><font color=\"#000080\">" + nData.NullFilter_Int64(dr["req_amnt"]).ToString() + "</font></td>");
                    TheArgs.TheHTML.AppendLine("  </tr>");
                    if (count >= 5)
                        break;
                }
                TheArgs.TheHTML.AppendLine("</table>");
            }
            catch { }
        }
        private string GetReqsByAgentSQL()
        {
            string inn = "";
            if (TheArgs.TheAgents != null)
            {
                if (TheArgs.TheAgents.Count > 0)
                    inn = Tools.Data.GetIn(TheArgs.TheAgents);
            }
            if (Tools.Strings.StrExt(inn))
                inn = " and base_mc_user_uid in (" + inn + ") ";
            return "select agentname, count(*) as reqcount, sum(target_quantity * target_price) as total_req_value from orddet_quote where len(isnull(agentname,'')) > 0 and orderdate " + TheArgs.TheDates.GetBetweenSQL() + " " + inn + " group by agentname order by reqcount desc";
        }
        private string GetQuotesByAgentSQL()
        {
            string inn = "";
            if (TheArgs.TheAgents != null)
            {
                if (TheArgs.TheAgents.Count > 0)
                    inn = Tools.Data.GetIn(TheArgs.TheAgents);
            }
            if (Tools.Strings.StrExt(inn))
                inn = " and base_mc_user_uid in (" + inn + ") ";
            return "select agentname, count(*) as quotecount, sum(quantityordered * unitprice) as total_quote_value from orddet_quote where len(isnull(agentname,'')) > 0 and quantityordered > 0 and unitprice > 0 and orderdate " + TheArgs.TheDates.GetBetweenSQL() + " " + inn + " group by agentname order by quotecount desc";
        }
        private string GetInvoicesByAgentSQL()
        {
            string inn = "";
            if (TheArgs.TheAgents != null)
            {
                if (TheArgs.TheAgents.Count > 0)
                    inn = Tools.Data.GetIn(TheArgs.TheAgents);
            }
            if (Tools.Strings.StrExt(inn))
                inn = " and base_mc_user_uid in (" + inn + ") ";
            return "select agentname, sum(ordertotal) as invoicetotal from ordhed_invoice where len(isnull(agentname,'')) > 0 and orderdate " + TheArgs.TheDates.GetBetweenSQL() + " " + inn + " group by agentname order by invoicetotal desc";
        }
        private string GetTopCustsSQL()
        {
            return "select distinct(ordhed_invoice.base_company_uid),max(isnull(ordhed_invoice.companyname,'(None)')) as companyname,(select sum(orddet_line.quantity * orddet_line.unit_price) from orddet_line where LEN(ISNULL(orddet_line.orderid_invoice,'')) > 0 and orddet_line.customer_uid = ordhed_invoice.base_company_uid) as total_inv from ordhed_invoice where len(isnull(ordhed_invoice.base_company_uid,'')) > 0 and isnull(ordhed_invoice.isvoid,0) = 0 and ordhed_invoice.orderdate " + TheArgs.TheDates.GetBetweenSQL() + " group by ordhed_invoice.base_company_uid,ordhed_invoice.unique_id order by total_inv desc";
        }
        private string GetTopVendorsSQL()
        {
            return "select distinct(ordhed_purchase.base_company_uid),max(isnull(ordhed_purchase.companyname,'(None)')) as companyname,(select sum(orddet_line.quantity * orddet_line.unit_cost) from orddet_line where LEN(ISNULL(orddet_line.orderid_purchase,'')) > 0 and orddet_line.vendor_uid = ordhed_purchase.base_company_uid) as total_purch from ordhed_purchase where len(isnull(ordhed_purchase.base_company_uid,'')) > 0 and isnull(ordhed_purchase.isvoid,0) = 0 and ordhed_purchase.orderdate " + TheArgs.TheDates.GetBetweenSQL() + " group by ordhed_purchase.base_company_uid,ordhed_purchase.unique_id order by total_purch desc";
        }
        private string GetTopHotPartsSQL()
        {
            return "select distinct(fullpartnumber), count(*) as req_amnt from orddet_quote where LEN(ISNULL(fullpartnumber,'')) > 0 and orderdate " + TheArgs.TheDates.GetBetweenSQL() + " group by fullpartnumber order by req_amnt desc";
        }
        //Private Enums
        private enum RzReportType
        {
            ReqsByAgent,
            QuotesByAgent,
            InvoicesByAgent,
            TopCusts,
            TopVendors,
            TopHotParts
        }
        //Private Classes
        private class RzReportArgs
        {
            public StringBuilder TheHTML = new StringBuilder();
            public RzReportType TheType = RzReportType.ReqsByAgent;
            public ArrayList TheAgents = new ArrayList();
            public Tools.Dates.DateRange TheDates = null;
        }
    }
}
