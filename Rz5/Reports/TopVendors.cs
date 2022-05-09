using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Rz5.Reports
{
    public class TopVendors : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;

        //Public Override Functions
        public TopVendors(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Vendor Name"));
            ColumnAdd(new ReportColumn("Phone")); 
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Purchase Amount", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("POCount"));
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            TopVendorsArgs argsx = (TopVendorsArgs)args;
            base.CalculateLines(context, args);
            String sql = "select top 200 ordhed_purchase.companyname,ordhed_purchase.base_company_uid,max(ordhed_purchase.primaryphone) as primaryphone,max(ordhed_purchase.agentname) as agentname,sum(ordhed_purchase.ordertotal) as ordertotal, count(unique_id) as POCount from ordhed_purchase where len(isnull(base_company_uid,'')) > 0 and isnull(ordhed_purchase.isvoid, 0) = 0 and ordhed_purchase.ordertotal > 0";           
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("ordhed_purchase.orderdate");
            sql += " group by ordhed_purchase.companyname,ordhed_purchase.base_company_uid order by sum(ordhed_purchase.ordertotal) desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    string id = Tools.Data.NullFilterString(r["base_company_uid"]); 
                    string comp = Tools.Data.NullFilterString(r["companyname"]);
                    string phone = Tools.Data.NullFilterString(r["primaryphone"]);
                    string agent = Tools.Data.NullFilterString(r["agentname"]);
                    Double value = Tools.Data.NullFilterDouble(r["ordertotal"]);
                    int  poCount = Tools.Data.NullFilterInt(r["POCount"]);
                   
                    ReportLine l = new ReportLine();
                    l.SetInc(comp, new ItemTag("company", id));
                    l.SetInc(phone);
                    l.SetInc(agent);
                    l.SetInc(value, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(value), null, context.TheSys.CurrencySymbol + "0.00#####");
                    l.SetInc(poCount);
                    Lines.Add(l);
                    TotalValue.Value += value;
                }
            }
        }
        public override string Title
        {
            get
            {
                return "Top 200 Vendors";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new TopVendorsArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalValue = new ReportTotal("");
            TotalValue.Caption = "Totals:";
            TotalValue.CaptionColumn = 0;
            TotalValue.ValueColumn = 3;
            Totals.Add(TotalValue);
        }
    }
    public class TopVendorsArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;

        //Constructors
        public TopVendorsArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Order Date");
            Criteria.Add(Range);
        }
    }
}


