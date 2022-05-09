using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Rz5.Reports
{
    public class SalesReport : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;

        //Public Override Functions
        public SalesReport(ContextRz context) : base(context)
        {

        }

        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Order Number"));
            ColumnAdd(new ReportColumn("Order Date"));
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Company"));
            ColumnAdd(new ReportColumn("Total", ColumnAlignment.Right));
        }

        public override void CalculateLines(Context context, ReportArgs args)
        {
            SalesReportArgs argsx = (SalesReportArgs)args;
            base.CalculateLines(context, args);
            String sql = "select ordhed_invoice.ordernumber,ordhed_invoice.orderdate,ordhed_invoice.companyname,ordhed_invoice.agentname,ordhed_invoice.ordertotal from ordhed_invoice where isnull(ordhed_invoice.isvoid,0) = 0 "; //inner join orddet_line on ordhed_invoice.unique_id = orddet_line.orderid_invoice
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("ordhed_invoice.orderdate");
            if (argsx.Agent.Exists())
                sql += " and ordhed_invoice.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            if (argsx.Company.Exists())
                sql += " and ordhed_invoice.base_company_uid = '" + context.Filter(argsx.Company.TheID) + "' ";
            sql += " order by ordhed_invoice.orderdate desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    String order_number = Tools.Data.NullFilterString(r["ordernumber"]);
                    DateTime order_date = Tools.Data.NullFilterDate(r["orderdate"]);
                    String company = Tools.Data.NullFilterString(r["companyname"]);
                    String agent = Tools.Data.NullFilterString(r["agentname"]);
                    Double value = Tools.Data.NullFilterDouble(r["ordertotal"]);
                    ReportLine l = new ReportLine();
                    l.SetInc(order_number);
                    l.SetInc(order_date, order_date.ToShortDateString());
                    l.SetInc(agent);
                    l.SetInc(company);
                    l.SetInc(value, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(value), null, context.TheSys.CurrencySymbol + "0.00#####");
                    Lines.Add(l);
                    TotalValue.Value += value;
                }
            }
        }
        public override string Title
        {
            get
            {
                return "Sales Report";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new SalesReportArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalValue = new ReportTotal("Total Value");
            TotalValue.Caption = "Totals:";
            TotalValue.CaptionColumn = 1;
            TotalValue.ValueColumn = 4;
            Totals.Add(TotalValue);            
        }
    }
    public class SalesReportArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;
        public ReportCriteriaAgent Agent;
        public ReportCriteriaCompany Company;

        //Constructors
        public SalesReportArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Order Date");
            Criteria.Add(Range);
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent);
            Company = new ReportCriteriaCompany("Company");
            Criteria.Add(Company);
        }
    }
}
