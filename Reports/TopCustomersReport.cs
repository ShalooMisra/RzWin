using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class TopCustomersReport : WebReport_User_Date
    {
        //Private Variables
        private ArrayList agents;
        private Tools.Dates.DateRange range;
        private StringBuilder html;
        private ArrayList agentNames;
        private long limit = 10;
        private bool SalesCount = false;
        private bool SalesVolume = false;

        //Constructors
        public TopCustomersReport()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteStructure()
        {
            base.CompleteStructure();
            SetCaption("Top Customers");
            dtStart.SetValue(nTools.GetMonthStart(DateTime.Now));
            dtEnd.SetValue(nTools.GetMonthEnd(DateTime.Now));
        }
        public override void RunReport()
        {
            this.agentNames = new ArrayList();
            ShowThrobber();
            wb.ReloadWB();
            wb.Add("Calculating...");
            agents = GetUserIDCollection_BlankIfAll();
            if (agents.Count > 0)
            {
                for (int i = 0; i < agents.Count; i++)
                {
                    string name = RzWin.Context.xSys.TranslateUserIDToName(agents[i].ToString());
                    if (RzWin.User.SuperUser)
                        this.agentNames.Add(name);
                    else if (name == RzWin.User.Name)
                    {
                        this.agentNames.Add(name);
                        break;
                    }
                }
            }
            else
                this.agentNames.Add("All");
            range = GetDateRange();
            limit = ctl_Results.GetValue_Long();
            if (limit <= 0)
                limit = 10;
            SalesCount = optRankBySale.Checked;
            SalesVolume = optRankBySaleVolume.Checked;
            base.RunReport();
            StartAsync();
        }
        public override void DoAsync()
        {
            base.DoAsync();
            string between = range.GetBetweenSQL();
            string agentQuery = "";
            if (agents.Count > 0)
                agentQuery = " and seller_uid in ( " + nTools.GetIn(agents) + " ) ";
            string sql = "select top " + limit.ToString() + " customer_name, seller_name, count(*) as invoice_count , sum(quantity * unit_price) as invoice_amount from orddet_line where isnull(orderid_invoice, '') > '' and orderdate_invoice " + between;
            if (Tools.Strings.StrExt(agentQuery))
                sql += " " + agentQuery;
            sql += " group by customer_name, seller_name";
            if (SalesCount)
                sql += " order by invoice_count desc";
            else
                sql += " order by invoice_amount desc";
            DataTable dt = RzWin.Context.Select(sql);
            if (dt == null)
            {
                html = new StringBuilder("<html><head></head><body>No Results.");
                html.Append("</body></html>");
                return;
            }
            StringBuilder sb = new StringBuilder("<html><head></head><body>");
            sb.AppendLine("          <table border=\"1\" width=\"100%\">");
            sb.AppendLine("            <tr>");
            sb.AppendLine("              <td width=\"20%\" align=\"center\" bgcolor=\"#E4E4E4\">Position #</td>");
            sb.AppendLine("              <td width=\"20%\" align=\"center\" bgcolor=\"#E4E4E4\">Customer Name</td>");
            sb.AppendLine("              <td width=\"20%\" align=\"center\" bgcolor=\"#E4E4E4\">Agent Name</td>");
            sb.AppendLine("              <td width=\"20%\" align=\"center\" bgcolor=\"#E4E4E4\">Total Invoices</td>");
            sb.AppendLine("              <td width=\"20%\" align=\"center\" bgcolor=\"#E4E4E4\">Total Invoiced");
            sb.AppendLine("                Amount</td>");
            sb.AppendLine("            </tr>");
            int count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                sb.AppendLine("            <tr>");
                sb.AppendLine("              <td width=\"20%\" align=\"center\">" + count.ToString() + "</td>");
                sb.AppendLine("              <td width=\"20%\">" + dr["customer_name"].ToString() + "&nbsp;</td>");
                sb.AppendLine("              <td width=\"20%\">" + dr["seller_name"].ToString() + "&nbsp;</td>");
                sb.AppendLine("              <td width=\"20%\" align=\"right\">" + nData.NullFilter_Int64(dr["invoice_count"]).ToString() + "</td>");
                sb.AppendLine("              <td width=\"20%\" align=\"right\">" + MoneyFormat(nData.NullFilter_Double(dr["invoice_amount"])) + "</td>");
                sb.AppendLine("            </tr>");
                count++;
            }
            sb.AppendLine("          </table>");
            sb.Append("</body></html>");
            html = sb;
        }
        public override void AsyncFinished()
        {
            base.AsyncFinished();
            wb.ReloadWB();
            wb.Add(html.ToString());
            HideThrobber();
        }
        public override bool zz_OnNavigate(Tools.GenericEvent e)
        {
            string id = "";
            if (e.Message.ToLower().Contains("showcompany~"))
            {
                e.Handled = true;
                id = Tools.Strings.ParseDelimit(e.Message, "showcompany~", 2).Trim();
                if (!Tools.Strings.StrExt(id))
                    return true;
                company c = company.GetById(RzWin.Context, id);
                if (c == null)
                    return true;
                RzWin.Context.Show(c);
            }
            return false;
        }
        //Private Functions
        private string MoneyFormat(double d)
        {
            if (Double.IsNaN(d))
                d = 0;
            return string.Format("{0:C}", d);
        }
    }
}
