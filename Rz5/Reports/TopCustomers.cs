using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;
using System.Collections;

namespace Rz5.Reports
{
    public class TopCustomers : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;

        //Public Override Functions
        public TopCustomers(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Company Name"));
            ColumnAdd(new ReportColumn("Phone")); 
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Sales Amount", ColumnAlignment.Right));
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            TopCustomersArgs argsx = (TopCustomersArgs)args;
            base.CalculateLines(context, args);
            String sql = "select top 200 ordhed_sales.companyname,ordhed_sales.base_company_uid,max(ordhed_sales.primaryphone) as primaryphone,max(ordhed_sales.agentname) as agentname,sum(ordhed_sales.ordertotal) as ordertotal from ordhed_sales where len(isnull(base_company_uid,'')) > 0 and isnull(ordhed_sales.isvoid, 0) = 0 and ordhed_sales.ordertotal > 0";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("ordhed_sales.orderdate");
            sql += "  group by ordhed_sales.companyname, ordhed_sales.base_company_uid order by sum(ordhed_sales.ordertotal) desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    string comp_id = Tools.Data.NullFilterString(r["base_company_uid"]);
                    string comp = Tools.Data.NullFilterString(r["companyname"]);
                    string phone = Tools.Data.NullFilterString(r["primaryphone"]);
                    string agent = Tools.Data.NullFilterString(r["agentname"]);
                    double value = Tools.Data.NullFilterDouble(r["ordertotal"]);                    
                    ReportLine l = new ReportLine();
                    l.SetInc(comp, new ItemTag("company", comp_id));
                    l.SetInc(phone);
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
                return "Top Customers";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new TopCustomersArgs((ContextRz)context);
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
    public class TopCustomersArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;

        //Constructors
        public TopCustomersArgs(ContextRz context)
            : base(context)
        {
            Range = new ReportCriteriaDateRange("Order Date");
            Criteria.Add(Range);
        }
    }
}

