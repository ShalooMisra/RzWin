using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;
using Tools.Database;

namespace Rz5.Reports
{
    public class InventoryAllocation : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalSales;
        private ReportTotal TotalCost;
        private ReportTotal TotalGP;

        //Public Override Functions
        public InventoryAllocation(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Order Number"));
            ColumnAdd(new ReportColumn("Due To Ship"));
            ColumnAdd(new ReportColumn("Part Number"));
            ColumnAdd(new ReportColumn("Stock Qty"));//100
            ColumnAdd(new ReportColumn("Allocated Qty"));//10 (sales line qty not part allocation qty)
            ColumnAdd(new ReportColumn("Company"));
            ColumnAdd(new ReportColumn("Sales Price", ColumnAlignment.Right));//1.50
            ColumnAdd(new ReportColumn("Sales Cost", ColumnAlignment.Right));//0.50
            ColumnAdd(new ReportColumn("Total Sales", ColumnAlignment.Right));//15.00
            ColumnAdd(new ReportColumn("Total Cost", ColumnAlignment.Right));//5.00
            ColumnAdd(new ReportColumn("GP Total", ColumnAlignment.Right));//10.00
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            InventoryAllocationArgs argsx = (InventoryAllocationArgs)args;
            base.CalculateLines(context, args);
            String sql = "select orddet_line.orderid_sales,orddet_line.ordernumber_sales,orddet_line.ship_date_due,orddet_line.fullpartnumber,partrecord.quantity as part_qty,orddet_line.quantity as sales_qty,orddet_line.customer_uid,orddet_line.customer_name,orddet_line.unit_price,orddet_line.unit_cost from orddet_line inner join partrecord on partrecord.unique_id = orddet_line.inventory_link_uid where len(isnull(orddet_line.orderid_invoice,'')) <= 0 and len(isnull(orddet_line.orderid_sales,'')) > 0 and orddet_line.status != 'void' and len(isnull(orddet_line.inventory_link_uid,'')) > 0 ";           
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
                    String ship_date_s = "";                    
                    DateTime ship_date = Tools.Data.NullFilterDate(r["ship_date_due"]);
                    if (Tools.Dates.DateExists(ship_date))
                        ship_date_s = ship_date.ToShortDateString();
                    String pn = Tools.Data.NullFilterString(r["fullpartnumber"]);
                    long part_qty = Tools.Data.NullFilterInt64(r["part_qty"]);
                    int sales_qty = Tools.Data.NullFilterInt(r["sales_qty"]);                    
                    String company = Tools.Data.NullFilterString(r["customer_name"]);
                    String company_uid = Tools.Data.NullFilterString(r["customer_uid"]);
                    Double unit_price = Tools.Data.NullFilterDouble(r["unit_price"]);
                    Double unit_cost = Tools.Data.NullFilterDouble(r["unit_cost"]);
                    Double price_total = sales_qty * unit_price;
                    Double cost_total = sales_qty * unit_cost;
                    Double gp = price_total - cost_total;
                    ReportLine l = new ReportLine();
                    l.SetInc(order_number, new ItemTag("ordhed_sales", order_id));
                    l.SetInc(Tools.Data.NullFilterDate(r["ship_date_due"]), ship_date_s);
                    l.SetInc(pn);
                    l.SetInc(part_qty.ToString());
                    l.SetInc(sales_qty.ToString());
                    l.SetInc(company, new ItemTag("company", company_uid));
                    l.SetInc(unit_price, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(unit_price), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(unit_cost, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(unit_cost), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(price_total, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(price_total), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(cost_total, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(cost_total), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(gp, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(gp), null, context.TheSys.CurrencySymbol + "0.00#####");
                    Lines.Add(l);
                    TotalSales.Value += price_total;
                    TotalCost.Value += cost_total;
                    TotalGP.Value += gp;
                }
            }
        }
        public override string Title
        {
            get
            {
                return "Inventory Allocation";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new InventoryAllocationArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalSales = new ReportTotal("");
            TotalSales.Caption = "Totals:";
            TotalSales.CaptionColumn = 0;
            TotalSales.ValueColumn = 8;
            TotalSales.ValueUse = ValueUse.TotalMoney;
            Totals.Add(TotalSales);

            TotalCost = new ReportTotal("");
            TotalCost.Caption = "Totals:";
            TotalCost.CaptionColumn = 0;
            TotalCost.ValueColumn = 9;
            TotalCost.ValueUse = ValueUse.TotalMoney;
            Totals.Add(TotalCost);

            TotalGP = new ReportTotal("");
            TotalGP.Caption = "Totals:";
            TotalGP.CaptionColumn = 0;
            TotalGP.ValueColumn = 10;
            TotalGP.ValueUse = ValueUse.TotalMoney;
            Totals.Add(TotalGP);
        }
    }
    public class InventoryAllocationArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;

        //Constructors
        public InventoryAllocationArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Ship Date");
            Criteria.Add(Range);
        }
    }
}
