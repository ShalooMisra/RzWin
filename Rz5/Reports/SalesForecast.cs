using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Rz5.Reports
{
    public class SalesForecast : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;

        //Public Override Functions
        public SalesForecast(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Order Number"));
            ColumnAdd(new ReportColumn("Order Date"));
            ColumnAdd(new ReportColumn("Due To Ship"));
            ColumnAdd(new ReportColumn("Company"));
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("GP Total", ColumnAlignment.Right));
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            SalesForecastArgs argsx = (SalesForecastArgs)args;
            base.CalculateLines(context, args);
            String sql = "select orddet_line.orderid_sales,orddet_line.ordernumber_sales,orddet_line.orderdate_sales,orddet_line.ship_date_due,orddet_line.customer_uid,orddet_line.customer_name,orddet_line.seller_name,orddet_line.gross_profit from orddet_line where len(isnull(orddet_line.orderid_invoice,'')) <= 0 and len(isnull(orddet_line.orderid_sales,'')) > 0 and orddet_line.status != 'void'";           
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_line.ship_date_due");
            sql += " order by orddet_line.orderdate_sales desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    String order_id = Tools.Data.NullFilterString(r["orderid_sales"]);
                    String order_number = Tools.Data.NullFilterString(r["ordernumber_sales"]);
                    String order_date_s = "";
                    String ship_date_s = "";                    
                    DateTime order_date = Tools.Data.NullFilterDate(r["orderdate_sales"]);
                    DateTime ship_date = Tools.Data.NullFilterDate(r["ship_date_due"]);
                    if (Tools.Dates.DateExists(order_date))
                        order_date_s = order_date.ToShortDateString();
                    if (Tools.Dates.DateExists(ship_date))
                        ship_date_s = ship_date.ToShortDateString();
                    String company_id = Tools.Data.NullFilterString(r["customer_uid"]);
                    String company = Tools.Data.NullFilterString(r["customer_name"]);
                    String agent = Tools.Data.NullFilterString(r["seller_name"]);
                    Double value = Tools.Data.NullFilterDouble(r["gross_profit"]);
                    ReportLine l = new ReportLine();
                    l.SetInc(order_number, new ItemTag("ordhed_sales", order_id));
                    l.SetInc(Tools.Data.NullFilterDate(r["orderdate_sales"]), order_date_s);
                    l.SetInc(Tools.Data.NullFilterDate(r["ship_date_due"]), ship_date_s);
                    l.SetInc(agent);
                    l.SetInc(company, new ItemTag("company", company_id));
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
                return "Sales Forecast";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new SalesForecastArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalValue = new ReportTotal("Total GP");
            TotalValue.Caption = "Totals:";
            TotalValue.CaptionColumn = 0;
            TotalValue.ValueColumn = 5;
            Totals.Add(TotalValue);
        }
    }
    public class SalesForecastArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;

        //Constructors
        public SalesForecastArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Ship Date");
            Criteria.Add(Range);
        }
    }
}


