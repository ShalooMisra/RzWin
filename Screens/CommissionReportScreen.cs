using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class CommissionReportScreen : Rz5.WebReport_User_Date
    {
        //Private Variables
        private StringBuilder HTML = new StringBuilder();
        private ArrayList Agents = new ArrayList();
        Tools.Dates.DateRange dtRange = new Tools.Dates.DateRange(Tools.Dates.GetBlankDate(), Tools.Dates.GetBlankDate());
        String PaidInFullToggle = "";

        //Constructors
        public CommissionReportScreen()
        {
            InitializeComponent();
            AddLinksGroupbox();
        }
        //Public Override Functions
        public override void RunReport()
        {
            base.RunReport();
            HTML = new StringBuilder();
            Agents = GetUserIDCollection_BlankIfAll();
            dtRange = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            StartAsync();
        }
        public override void CompleteStructure()
        {
            base.CompleteStructure();
            dtEnd.SetValue(new DateTime(DateTime.Now.Year, DateTime.Now.Month, GetMonthEnd(DateTime.Now.Month, DateTime.Now.Year)));
            SetCaption("Commission Report");
            cmdExport.Visible = true;

            
        }

        public void AddLinksGroupbox()
        {
            //ReportCriteriaGroupBox gbLinks = new ReportCriteriaGroupBox();
            GroupBox gb = new GroupBox();
            gb.Name = "Links";
            LinkLabel llRegularPayalendar = new LinkLabel();
            llRegularPayalendar.Name = "Sensible Regular Pay Calendar";
            llRegularPayalendar.LinkClicked += new LinkLabelLinkClickedEventHandler(llPayCalendar_LinkClicked);


            LinkLabel llCommissionSchedule = new LinkLabel();
            llCommissionSchedule.Name = "Sensible Commission Schedule";
            llCommissionSchedule.LinkClicked += new LinkLabelLinkClickedEventHandler(llCommisionSchedule_LinkClicked);

            gb.Controls.Add(llRegularPayalendar);
            gb.Controls.Add(llCommissionSchedule);
            //Criteria.Add(gbLinks);
            gbOptions.Controls.Add(gb);
        }

        private void llPayCalendar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://calendar.google.com/calendar/embed?src=sensiblemicro.com_l0dh02oo6cqa2sqdpve5m7rffs%40group.calendar.google.com&ctz=America%2FNew_York");
        }

        private void llCommisionSchedule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://docs.google.com/document/d/1rADR9Df087jaYSOoMqYK97VIhl5N0OguNkIXEdE-uJk/edit?usp=sharing");
        }

        public override void DoAsync()
        {
            StringBuilder sb = new StringBuilder();
            string SQL = GetSQL();
            DataTable dt = RzWin.Context.Select(SQL);
            if (dt == null)
            {
                HTML.Append("<p><b><font size=\"5\" color=\"#FF0000\">No Results</font></b></p>");
                return;
            }
            if (dt.Rows.Count <= 0)
            {
                HTML.Append("<p><b><font size=\"5\" color=\"#FF0000\">No Results</font></b></p>");
                return;
            }
            sb.Append(WriteHeader());
            Dictionary<string, ArrayList> dAgents = GetAgentDictionary(dt);
            foreach (KeyValuePair<string, ArrayList> kvp in dAgents)
            {
                sb.Append(WriteUserSection(kvp.Key, (ArrayList)kvp.Value));
            }
            HTML = sb;
        }
        public override void AsyncFinished()
        {
            base.AsyncFinished();
            wb.ReloadWB();
            wb.Add(HTML.ToString());
        }
        public override void DoExport()
        {
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            string agents = "";
            if (Agents != null)
            {
                if (Agents.Count > 0)
                {
                    string inn = Tools.Data.GetIn(Agents);
                    if (Tools.Strings.StrExt(inn))
                        agents = " and ordhed_invoice.base_mc_user_uid in (" + inn + ") ";
                }
            }
            string sql = GetBeginningSQL() + " into " + table + GetEndSQL(agents);
            RzWin.Context.Execute(sql);
            RzWin.Context.Execute("update " + table + " set total_cost = total_cost + fees");
            RzWin.Context.Execute("update " + table + " set gp = gp - fees");
            RzWin.Context.Execute("alter table " + table + " add gp_perc int");
            RzWin.Context.Execute("update " + table + " set gp_perc = cast(((gp / total_sales) * 100) as int) where total_sales > 0");
            RzWin.Context.Execute("alter table " + table + " add comm float");
            RzWin.Context.Execute("update " + table + " set comm = gp * .3");
            RzWin.Context.Execute("alter table " + table + " add commission_percent int");
            RzWin.Context.Execute("update " + table + " set commission_percent = cast(((select commission_percent from n_user where unique_id = base_mc_user_uid)*100) as int)");
            long l = 0;
            String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "export_" + Tools.Strings.GetNewID() + ".csv";
            RzWin.Leader.StartPopStatus("Exporting...");
            RzWin.Context.Data.Connection.ExportCSV("select companyname as [Company],buyername as [Buyer],agentname as [Agent],orderdate as [Date],ordernumber as [Invoice#],datecode as [DC],manufacturer as [MFG],fullpartnumber as [Part],paydate as [Pay Date],payamount as [Amnt Paid],quantity_packed as [Qty],unit_price as [Price],total_sales as [Total Sales],unit_cost as [Cost],fees as [Fees],total_cost as [Total Cost],gp as [GP],cast(gp_perc as varchar(50)) + '%' as [GP%],cast(commission_percent as varchar(50)) + '%' as [Comm%],comm as [Comm Paid] from " + table, strFile, ref l);
            RzWin.Context.Execute("drop table " + table);
            RzWin.Leader.Comment("Done: " + Tools.Number.LongFormat(l) + " rows exported.");
            RzWin.Leader.Comment("Opening...");
            Tools.FileSystem.Shell(strFile);
            RzWin.Leader.StopPopStatus(true);
        }
        public override void LoadAgentTeams()
        {
            RzWin.Context.TheLogicRz.LoadAgentTeamCombo(RzWin.Context, cboAgent, OnlySalespeople, AllowAllUsers);
        }

        

        public override void Print()
        {
            try
            {
                if (ShowChartOnly)
                    PopChartPicture();
                else
                    wb.PrintWithDialog();
            }
            catch { }
        }
        //Private Functions
        private Dictionary<string, ArrayList> GetAgentDictionary(DataTable dt)
        {
            ArrayList a = new ArrayList();
            Dictionary<string, ArrayList> agents = new Dictionary<string, ArrayList>();
            string last_id = "";
            foreach (DataRow dr in dt.Rows)
            {
                string id = dr["base_mc_user_uid"].ToString();
                if (!Tools.Strings.StrExt(id))
                    continue;
                if (!Tools.Strings.StrCmp(id, last_id))
                {
                    a = new ArrayList();
                    agents.Add(id, a);
                    a.Add(dr);
                    last_id = id;
                }
                else
                {
                    agents.TryGetValue(id, out a);
                    if (a != null)
                        a.Add(dr);
                }
            }
            return agents;
        }
        private string GetSQL()
        {
            string agents = "";
            if (Agents != null)
            {
                if (Agents.Count > 0)
                {
                    string inn = Tools.Data.GetIn(Agents);
                    if (Tools.Strings.StrExt(inn))
                        agents = " and ordhed_invoice.base_mc_user_uid in (" + inn + ") ";
                }
            }
            return GetBeginningSQL() + GetEndSQL(agents);
        }
        private string GetBeginningSQL()
        {
            return "select orddet_line.unique_id,orddet_line.customer_name as companyname,ordhed_invoice.base_company_uid,ordhed_invoice.base_mc_user_uid,ordhed_invoice.agentname,ordhed_invoice.buyername,ordhed_invoice.orderdate,ordhed_invoice.ordernumber,orddet_line.datecode,orddet_line.manufacturer,orddet_line.fullpartnumber,(select max(checkpayment.transdate) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice) as paydate,isnull((select sum(checkpayment.transamount) from checkpayment where checkpayment.transtype = 'payment' and checkpayment.base_ordhed_uid = orddet_line.orderid_invoice),0) as payamount,(select ordhed_invoice.ordertotal from ordhed_invoice where ordhed_invoice.unique_id = orddet_line.orderid_invoice) as ordertotal,orddet_line.quantity_packed,orddet_line.unit_price,(orddet_line.quantity_packed * orddet_line.unit_price) as total_sales,orddet_line.unit_cost,isnull(((select sum(amount) from profit_deduction where orddet_line.unique_id = profit_deduction.the_orddet_line_uid) + orddet_line.rma_subtraction),0) as fees,(orddet_line.quantity_packed * orddet_line.unit_cost) as total_cost,((orddet_line.quantity_packed * orddet_line.unit_price) - (orddet_line.quantity_packed * orddet_line.unit_cost)) as gp ";
        }

        private string GetEndSQL(string agents)
        {
            return " from orddet_line inner join ordhed_invoice on orddet_line.orderid_invoice = ordhed_invoice.unique_id where isnull(ordhed_invoice.isvoid,0) = 0 and len(isnull(ordhed_invoice.unique_id,'')) > 0 and ordhed_invoice.orderdate " + dtRange.GetBetweenSQL() + " " + agents + " group by orddet_line.unique_id,orddet_line.customer_name,ordhed_invoice.base_mc_user_uid,ordhed_invoice.agentname,ordhed_invoice.buyername,ordhed_invoice.orderdate,ordhed_invoice.ordernumber,orddet_line.datecode,orddet_line.manufacturer,orddet_line.fullpartnumber,orddet_line.orderid_invoice,orddet_line.quantity_packed,orddet_line.unit_price,orddet_line.unit_cost,ordhed_invoice.base_company_uid,orddet_line.rma_subtraction order by ordhed_invoice.base_mc_user_uid,ordhed_invoice.ordernumber,ordhed_invoice.base_company_uid " + PaidInFullToggle;
        }
        private string WriteHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\" align=\"center\"><font size=\"5\"><b>Commission Report</b></font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><font size=\"5\">From " + dtRange.StartDate.ToShortDateString() + " to " + dtRange.EndDate.ToShortDateString() + "</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<hr>");
            return sb.ToString();
        }
        private string WriteUserSection(string user, ArrayList rows)
        {
            n_user u = n_user.GetById(RzWin.Context, user);
            if (u == null)
                return "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><b><font size=\"4\">" + u.name + "</font></b></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<table border=\"0\" width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"8%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Company</b></font></td>");
            sb.AppendLine("    <td width=\"6%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Buyer</b></font></td>");
            sb.AppendLine("    <td width=\"6%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Date</b></font></td>");
            sb.AppendLine("    <td width=\"6%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Invoice#</b></font></td>");
            sb.AppendLine("    <td width=\"3%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>DC</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>MFG</b></font></td>");
            sb.AppendLine("    <td width=\"6%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Part</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Pay Date</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Amnt Paid</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Qty</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Price</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Total Sales</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Cost</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Fees</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Total Cost</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>GP</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>GP%</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Comm%</b></font></td>");
            sb.AppendLine("    <td width=\"5%\" bgcolor=\"#E1E1E1\"><font size=\"1\"><b>Comm Paid</b></font></td>");
            sb.AppendLine("  </tr>");
            double SalesTotal = 0;
            double CostTotal = 0;
            double GPTotal = 0;
            double CommPdTotal = 0;
            foreach (DataRow dr in rows)
            {
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"8%\"><font size=\"1\"><a href=\"_company_" + dr["base_company_uid"].ToString() + "\">" + dr["companyname"].ToString() + "</a></font></td>");
                sb.AppendLine("    <td width=\"6%\"><font size=\"1\">" + dr["buyername"].ToString() + "</font></td>");
                sb.AppendLine("    <td width=\"6%\"><font size=\"1\">" + nData.NullFilter_DateTime(dr["orderdate"]).ToShortDateString() + "</font></td>");
                sb.AppendLine("    <td width=\"6%\"><font size=\"1\"><a href=\"_invoice_" + dr["ordernumber"].ToString() + "\">" + dr["ordernumber"].ToString() + "</a></font></td>");
                sb.AppendLine("    <td width=\"3%\"><font size=\"1\">" + dr["datecode"].ToString() + "</font></td>");
                sb.AppendLine("    <td width=\"6%\"><font size=\"1\">" + dr["manufacturer"].ToString() + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + dr["fullpartnumber"].ToString() + "</font></td>");
                string date = nData.NullFilter_DateTime(dr["paydate"]).ToShortDateString();
                if (!Tools.Dates.DateExists(nData.NullFilter_DateTime(dr["paydate"])))
                    date = "&nbsp;";
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + date + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["payamount"])) + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + nData.NullFilter_Int64(dr["quantity_packed"]).ToString() + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_price"])) + "</font></td>");
                double fees = nData.NullFilter_Double(dr["fees"]);
                double total_sales = nData.NullFilter_Double(dr["total_sales"]);
                double total_cost = nData.NullFilter_Double(dr["total_cost"]) + fees;
                double gp = nData.NullFilter_Double(dr["gp"]) - fees;
                SalesTotal += total_sales;
                CostTotal += total_cost;
                GPTotal += gp;
                int gp_perc = 0;
                try { gp_perc = ((int)((gp / total_sales) * 100)); }
                catch { }
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(total_sales) + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["unit_cost"])) + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(fees) + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(total_cost) + "</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(gp) + "</font></td>");
                if (gp_perc < 0)
                    gp_perc = 0;
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + gp_perc.ToString() + "%</font></td>");
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + ((int)(u.commission_percent * 100)).ToString() + "%</font></td>");
                double comm = gp * u.commission_percent;
                CommPdTotal += comm;
                sb.AppendLine("    <td width=\"5%\"><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(comm) + "</font></td>");
                sb.AppendLine("  </tr>");
            }
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"8%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"6%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"6%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"6%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"3%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"6%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><hr><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(SalesTotal) + "</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><hr><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(CostTotal) + "</font></td>");
            sb.AppendLine("    <td width=\"5%\"><hr><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(GPTotal) + "</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><font size=\"1\">&nbsp;</font></td>");
            sb.AppendLine("    <td width=\"5%\"><hr><font size=\"1\">" + RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat_2_6(CommPdTotal) + "</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<hr>");
            sb.AppendLine("&nbsp;");
            //Tools.Files.SaveFileAsString(Tools.Folder.ConditionFolderName(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + Tools.Strings.GetNewID() + ".txt", sb.ToString());
            return sb.ToString();
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
        //Control Events
        private void wb_OnNavigate(Tools.GenericEvent e)
        {
            string id = "";
            if (e.Message.ToLower().Contains("_company_"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "_company_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                company c = company.GetById(RzWin.Context, id);
                if (c == null)
                    return;
                RzWin.Context.Show(c);
            }
            if (e.Message.ToLower().Contains("_invoice_"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "_invoice_", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return;
                ordhed_invoice i = (ordhed_invoice)ordhed_invoice.GetByNumberAndType(RzWin.Context, id, Enums.OrderType.Invoice);
                if (i == null)
                    return;
                RzWin.Context.Show(i);
            }
        }

       
    }
}
