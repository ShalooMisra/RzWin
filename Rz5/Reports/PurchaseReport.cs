using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Rz5.Reports
{
    public class PurchaseReport : Rz5.Report
    {
        //Private Variables
        private ReportTotal TotalValue;

        //Public Override Functions
        public PurchaseReport(ContextRz context) : base(context)
        {

        }

        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Order Number"));
            ColumnAdd(new ReportColumn("Order Date"));
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Vendor"));
            ColumnAdd(new ReportColumn("Total", ColumnAlignment.Right));            
        }

        public override void CalculateLines(Context context, ReportArgs args)
        {
            PurchaseReportArgs argsx = (PurchaseReportArgs)args;
            base.CalculateLines(context, args);

            String sql = "select ordhed_purchase.unique_id,ordhed_purchase.ordernumber,ordhed_purchase.orderdate,ordhed_purchase.base_company_uid,ordhed_purchase.companyname,ordhed_purchase.agentname,ordhed_purchase.ordertotal from ordhed_purchase where isnull(ordhed_purchase.isvoid,0) = 0 ";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("ordhed_purchase.orderdate");            
            if (argsx.Agent.Exists())
                sql += " and ordhed_purchase.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " ) ";            
            if (argsx.Company.Exists())
                sql += " and ordhed_purchase.base_company_uid = '" + context.Filter(argsx.Company.TheID) + "' ";
            sql += " order by ordhed_purchase.orderdate desc";
            DataTable d = context.Select(sql);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    String order_id = Tools.Data.NullFilterString(r["unique_id"]);
                    String order_number = Tools.Data.NullFilterString(r["ordernumber"]);
                    DateTime order_date = Tools.Data.NullFilterDate(r["orderdate"]);
                    String comp_id = Tools.Data.NullFilterString(r["base_company_uid"]);
                    String company = Tools.Data.NullFilterString(r["companyname"]);
                    String agent = Tools.Data.NullFilterString(r["agentname"]);
                    Double value = Tools.Data.NullFilterDouble(r["ordertotal"]);
                    ReportLine l = new ReportLine();
                    l.SetInc(order_number, new ItemTag("ordhed_purchase", order_id));
                    l.SetInc(Tools.Data.NullFilterDate(r["orderdate"]), order_date.ToShortDateString());
                    l.SetInc(agent);
                    l.SetInc(company, new ItemTag("company", comp_id));
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
                return "Purchase Report";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new PurchaseReportArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            TotalValue = new ReportTotal("Total Value");
            TotalValue.Caption = "Totals:";
            TotalValue.CaptionColumn = 0;
            TotalValue.ValueColumn = 4;
            Totals.Add(TotalValue);                          
        }
    }
    public class PurchaseReportArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;
        public ReportCriteriaAgent Agent;
        public ReportCriteriaCompany Company;

        //Constructors
        public PurchaseReportArgs(ContextRz context) : base(context)
        {
            Range = new ReportCriteriaDateRange("Order Date");
            Criteria.Add(Range);
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent);
            Company = new ReportCriteriaCompany("Vendor");
            Criteria.Add(Company);
        }
    }
}


