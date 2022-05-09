using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Rz5.Reports
{
    public class SalesLineReport : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;
        private ReportTotal TotalGP;

        //Public Override Functions
        public SalesLineReport(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Sales Date")); 
            ColumnAdd(new ReportColumn("Sales Number"));
            ColumnAdd(new ReportColumn("Invoice Number"));
            ColumnAdd(new ReportColumn("Company")); 
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Part Number"));
            ColumnAdd(new ReportColumn("Quantity", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Price", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Cost", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("GP", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Total", ColumnAlignment.Right));
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            SalesLineReportArgs argsx = (SalesLineReportArgs)args;
            base.CalculateLines(context, args);
            String sql = "select orddet_line.orderdate_sales,orddet_line.orderid_sales,orddet_line.ordernumber_sales,orddet_line.orderid_invoice,orddet_line.ordernumber_invoice,orddet_line.customer_uid,orddet_line.customer_name,orddet_line.seller_name,orddet_line.fullpartnumber,orddet_line.quantity,orddet_line.unit_price,orddet_line.unit_cost,(orddet_line.quantity * orddet_line.unit_price) as total,((orddet_line.quantity * orddet_line.unit_price)-(orddet_line.quantity * orddet_line.unit_cost)) as gp from orddet_line where len(isnull(orddet_line.orderid_sales,'')) > 0 and isnull(orddet_line.isvoid,0) = 0 and orddet_line.status not in ('Canceled','Void') ";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_line.orderdate_sales");
            if (argsx.Agent.Exists())
                sql += " and orddet_line.seller_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " ) ";
            if (argsx.Company.Exists())
                sql += " and orddet_line.customer_uid = '" + context.Filter(argsx.Company.TheID) + "' ";
            if (argsx.Shipped.Value)
                sql += " and isnull(orddet_line.was_shipped,0) = 1 ";
            sql += " order by orddet_line.orderdate_sales desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    DateTime orderdate_sales = Tools.Data.NullFilterDate(r["orderdate_sales"]);
                    String orderid_sales = Tools.Data.NullFilterString(r["orderid_sales"]);
                    String ordernumber_sales = Tools.Data.NullFilterString(r["ordernumber_sales"]);
                    String orderid_invoice = Tools.Data.NullFilterString(r["orderid_invoice"]);
                    String ordernumber_invoice = Tools.Data.NullFilterString(r["ordernumber_invoice"]);
                    String customer_uid = Tools.Data.NullFilterString(r["customer_uid"]);
                    String customer_name = Tools.Data.NullFilterString(r["customer_name"]);
                    String seller_name = Tools.Data.NullFilterString(r["seller_name"]);
                    String fullpartnumber = Tools.Data.NullFilterString(r["fullpartnumber"]);
                    Int32 quantity = Tools.Data.NullFilterInteger(r["quantity"]);
                    Double unit_price = Tools.Data.NullFilterDouble(r["unit_price"]);
                    Double unit_cost = Tools.Data.NullFilterDouble(r["unit_cost"]);
                    Double total = Tools.Data.NullFilterDouble(r["total"]);
                    Double gp = Tools.Data.NullFilterDouble(r["gp"]);                   
                    ReportLine l = new ReportLine();
                    l.SetInc(orderdate_sales.ToShortDateString());
                    l.SetInc(ordernumber_sales, new ItemTag("ordhed_sales", orderid_sales));
                    l.SetInc(ordernumber_invoice, new ItemTag("ordhed_invoice", orderid_invoice));
                    l.SetInc(customer_name, new ItemTag("company", customer_uid));
                    l.SetInc(seller_name);
                    l.SetInc(fullpartnumber);
                    l.SetInc(Tools.Number.LongFormat(quantity));
                    l.SetInc(unit_price, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(unit_price), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(unit_cost, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(unit_cost), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(gp, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(gp), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(total, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(total), null, context.TheSys.CurrencySymbol + "0.00#####");
                    Lines.Add(l);
                    TotalValue.Value += total;
                    TotalGP.Value += gp;
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
            return new SalesLineReportArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalValue = new ReportTotal("Total Value");
            TotalValue.Caption = "Totals:";
            TotalValue.CaptionColumn = 1;
            TotalValue.ValueColumn = 10;
            Totals.Add(TotalValue);

            TotalGP = new ReportTotal("");
            TotalGP.Caption = "";
            TotalGP.ValueColumn = 9;
            Totals.Add(TotalGP);
        }
    }
    public class SalesLineReportArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;
        public ReportCriteriaAgent Agent;
        public ReportCriteriaCompany Company;
        public ReportCriteriaBoolean Shipped;

        //Constructors
        public SalesLineReportArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Order Date");
            Criteria.Add(Range);
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent);
            Company = new ReportCriteriaCompany("Company");
            Criteria.Add(Company);

            Shipped = new ReportCriteriaBoolean("Only Shipped Lines", "", "");
            Criteria.Add(Shipped);
        }
    }
}
