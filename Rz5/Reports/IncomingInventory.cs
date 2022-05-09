using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Rz5.Reports
{
    public class IncomingInventory : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;

        //Public Override Functions
        public IncomingInventory(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Order Number"));
            ColumnAdd(new ReportColumn("Due To Receive"));
            ColumnAdd(new ReportColumn("Part Number"));
            ColumnAdd(new ReportColumn("Quantity", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Cost", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Vendor"));
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Total Value", ColumnAlignment.Right));
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            IncomingInventoryArgs argsx = (IncomingInventoryArgs)args;
            base.CalculateLines(context, args);
            String sql = "select orddet_line.orderid_purchase,orddet_line.ordernumber_purchase,orddet_line.receive_date_due,orddet_line.fullpartnumber,orddet_line.quantity,orddet_line.unit_cost,ordhed_purchase.base_company_uid,ordhed_purchase.companyname,ordhed_purchase.agentname from orddet_line inner join ordhed_purchase on ordhed_purchase.unique_id = orddet_line.orderid_purchase where len(isnull(orddet_line.orderid_purchase,'')) > 0 and orddet_line.status in ('Hold','Open','Buy','Out_For_Service','RMA_Receiving')";           
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_line.receive_date_due");
            sql += " order by orddet_line.orderdate_purchase desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    String order_id = Tools.Data.NullFilterString(r["orderid_purchase"]);
                    String order_number = Tools.Data.NullFilterString(r["ordernumber_purchase"]);
                    String receive_date_s = "";
                    DateTime receive_date = Tools.Data.NullFilterDate(r["receive_date_due"]);
                    if (Tools.Dates.DateExists(receive_date))
                        receive_date_s = receive_date.ToShortDateString();
                    String pn = Tools.Data.NullFilterString(r["fullpartnumber"]);
                    int qty = Tools.Data.NullFilterInt(r["quantity"]);
                    Double cost = Tools.Data.NullFilterDouble(r["unit_cost"]);
                    String comp_id = Tools.Data.NullFilterString(r["base_company_uid"]);
                    String comp = Tools.Data.NullFilterString(r["companyname"]);
                    String agent = Tools.Data.NullFilterString(r["agentname"]);
                    Double value = qty * cost;
                    ReportLine l = new ReportLine();
                    l.SetInc(order_number, new ItemTag("ordhed_purchase", order_id));
                    l.SetInc(receive_date, receive_date_s);
                    l.SetInc(pn);
                    l.SetInc(qty, qty.ToString());
                    l.SetInc(cost, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(cost), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(comp, new ItemTag("company", comp_id)); 
                    l.SetInc(agent);                    
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
                return "Incoming Inventory";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new IncomingInventoryArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalValue = new ReportTotal("Total GP");
            TotalValue.Caption = "Totals:";
            TotalValue.CaptionColumn = 0;
            TotalValue.ValueColumn = 7;
            Totals.Add(TotalValue);
        }
    }
    public class IncomingInventoryArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;

        //Constructors
        public IncomingInventoryArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Receive Date");
            Criteria.Add(Range);
        }
    }
}


