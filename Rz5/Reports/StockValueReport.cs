using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NewMethod;
using Core;
using Tools.Database;

namespace Rz5
{
    public class StockValueReport : Report
    {
        public StockValueReport(ContextRz context) : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd("Part Number");
            ColumnAdd("Quantity", ValueUse.Quantity);
            ColumnAdd("Vendor");
            ColumnAdd("Location");
            ColumnAdd("Box");
            ColumnAdd("Unit Cost", ValueUse.UnitMoney);
            ColumnAdd("Item Value", ValueUse.TotalMoney);
        }
        protected override void  InitTotals()
        {
 	         base.InitTotals();
             AutoTotalInteger("Total Quantity", "Quantity", ValueUse.Quantity);
             AutoTotal("Total Value", "Item Value", ValueUse.TotalMoney);
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
 	        base.CalculateLines(context, args);
            String s = "select unique_id,fullpartnumber,sum(quantity) as quantity,base_company_uid,companyname,cost,sum((isnull(cost, 0) * isnull(quantity, 0))) as [total],left(location, 50) as [location],left(boxnum, 50) as [boxnum] from partrecord where quantity > 0 and stocktype = 'stock' and len(isnull(fullpartnumber, '')) > 2 group by fullpartnumber, companyname, cost, left(location, 50), left(boxnum, 50), unique_id, base_company_uid order by sum((isnull(cost, 0) * isnull(quantity, 0))) desc, fullpartnumber";
            foreach (DataRow r in context.Select(s).Rows)
            {
                ReportLine l = LineAdd();
                string id = Tools.Data.NullFilterString(r["unique_id"]);
                string vend_id = Tools.Data.NullFilterString(r["base_company_uid"]);
                l.SetInc(Tools.Data.NullFilterString(r["fullpartnumber"]), new ItemTag("partrecord", id));
                l.SetInc(Tools.Data.NullFilterIntegerFromIntOrLong(r["quantity"]));
                l.SetInc(Tools.Data.NullFilterString(r["companyname"]), new ItemTag("company", vend_id));
                l.SetInc(Tools.Data.NullFilterString(r["location"]));
                l.SetInc(Tools.Data.NullFilterString(r["boxnum"]));
                l.SetInc(Tools.Data.NullFilterDouble(r["cost"]), "$" + String.Format("{0:###,###,###,##0.00####}", Tools.Data.NullFilterDouble(r["cost"])));
                l.SetInc(Tools.Data.NullFilterDouble(r["total"]), "$" + String.Format("{0:###,###,###,##0.00####}", Tools.Data.NullFilterDouble(r["total"])));
            }
        }
        public override string Title
        {
            get
            {
                return "Inventory Value";
            }
        }
    }
}
