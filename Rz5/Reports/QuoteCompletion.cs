using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMethod;
using Core;

namespace Rz5.Reports
{
    public class QuoteCompletion : Rz5.Report
    {
        //Protected Variables
        public ReportTotalInteger ReqCount;
        public ReportTotalInteger QuoteCount;
        public ReportTotalInteger SalesCount;
        public ReportTotal ReqDollar;
        public ReportTotal QuoteDollar;
        public ReportTotal SalesDollar;
        public ReportTotalPercent QuoteRatio;
        public ReportTotalPercent SalesRatio;
        public ReportTotalPercent QuoteTotal;
        public ReportTotalPercent SalesTotal;

        //Public Override Functions
        public QuoteCompletion(ContextRz context)
            : base(context)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn(""));
            ColumnAdd(new ReportColumn("Req Count"));
            ColumnAdd(new ReportColumn("Quote Count"));
            ColumnAdd(new ReportColumn("Sales Count"));
            ColumnAdd(new ReportColumn("Quote Ratio"));
            ColumnAdd(new ReportColumn("Sales Ratio"));
            ColumnAdd(new ReportColumn("Req Dollar Amount"));
            ColumnAdd(new ReportColumn("Quote Dollar Amount"));
            ColumnAdd(new ReportColumn("Sales Dollar Amount"));
            ColumnAdd(new ReportColumn("Quote Dollar Ratio"));
            ColumnAdd(new ReportColumn("Sales Dollar Ratio"));
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            ContextRz x = (ContextRz)context;
            QuoteCompletionArgs argsx = (QuoteCompletionArgs)args;
            base.CalculateLines(context, args);
            string table = "temp_" + Tools.Strings.GetNewID();
            long reqs = 0;
            long quote = 0;
            long sales = 0;
            double reqs_d = 0;
            double quote_d = 0;
            double sales_d = 0;
            //Req Count
            string sql = "select count(*) from orddet_quote ";
            string where = "";
            if (argsx.Range.Exists())
                where = " where " + argsx.Range.TheRange.GetSQL("orddet_quote.orderdate");
            if (argsx.Agent.Exists())
            {
                if (Tools.Strings.StrExt(where))
                    where += " and ";
                else
                    where = " where ";
                where += " orddet_quote.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " ) ";
            }
            reqs = context.SelectScalarInt64(sql + where);
            //Quote Count
            sql = "select count(*) from orddet_quote where isnull(orddet_quote.unitprice,0)>0 ";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_quote.orderdate");
            if (argsx.Agent.Exists())
                sql += " and orddet_quote.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " ) ";
            quote = context.SelectScalarInt64(sql);
            //Sales Count
            sql = "select count(*) from orddet_line where len(isnull(orddet_line.orderid_sales,''))>0 ";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_line.orderdate_sales");
            if (argsx.Agent.Exists())
                sql += " and orddet_line.seller_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            sales = context.SelectScalarInt64(sql);
            //Req $
            sql = "select sum(target_quantity * target_price) from orddet_quote ";
            where = "";
            if (argsx.Range.Exists())
                where = " where " + argsx.Range.TheRange.GetSQL("orddet_quote.orderdate");
            if (argsx.Agent.Exists())
            {
                if (Tools.Strings.StrExt(where))
                    where += " and ";
                else
                    where = " where ";
                where += " orddet_quote.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            }
            reqs_d = context.SelectScalarDouble(sql + where);
            //Quote $
            sql = "select sum(quantityordered * unitprice) from orddet_quote where isnull(orddet_quote.unitprice,0)>0 ";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_quote.orderdate");
            if (argsx.Agent.Exists())
                sql += " and orddet_quote.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            quote_d = context.SelectScalarDouble(sql);
            //Sales $
            sql = "select sum(quantity * unit_price) from orddet_line where len(isnull(orddet_line.orderid_sales,''))>0 ";
            if (argsx.Range.Exists())
                sql += " and " + argsx.Range.TheRange.GetSQL("orddet_line.orderdate_sales");
            if (argsx.Agent.Exists())
                sql += " and orddet_line.seller_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " )";
            sales_d = context.SelectScalarDouble(sql);
            context.Execute("create table " + table + " (req_count int,quote_count int,sales_count int,req_d float,quote_d float,sales_d float)");
            context.Execute("insert into " + table + " (req_count,quote_count,sales_count,req_d,quote_d,sales_d) values (" + reqs.ToString() + "," + quote.ToString() + "," + sales.ToString() + "," + reqs_d.ToString() + "," + quote_d.ToString() + "," + sales_d.ToString() + ")");
            DataTable d = context.Select("select * from " + table);
            if (Tools.Data.DataTableExists(d))
            {
                foreach (DataRow r in d.Rows)
                {
                    String agentId = "";
                    if (argsx.Agent.AgentIds.Count > 0)
                        agentId = argsx.Agent.AgentIds[0];

                    QuoteCompletionSectionUser userSection = null;
                    if (Sections.ContainsKey(agentId))
                        userSection = (QuoteCompletionSectionUser)Sections[agentId];
                    else
                    {
                        userSection = new QuoteCompletionSectionUser(x, agentId, x.xSys.TranslateUserIDToName(agentId));
                        Sections.Add(agentId, userSection);
                    }
                    userSection.QuoteCompletionLineAdd(x, this, r);
                }
            }
            foreach (ReportSection s in Sections.Values)
            {
                if (!(s is QuoteCompletionSectionUser))
                    continue;
                QuoteCompletionSectionUser ss = (QuoteCompletionSectionUser)s;
                ReqCount.Value += ss.ReqCount.Value;
                QuoteCount.Value += ss.QuoteCount.Value;
                SalesCount.Value += ss.SalesCount.Value;
                QuoteRatio.Value = FilterNumber(FilterNumber(QuoteCount.Value) / FilterNumber(ReqCount.Value)) * 100;
                SalesRatio.Value = FilterNumber(FilterNumber(SalesCount.Value) / FilterNumber(QuoteCount.Value)) * 100;
                ReqDollar.Value += ss.ReqDollar.Value;
                QuoteDollar.Value += ss.QuoteDollar.Value;
                SalesDollar.Value += ss.SalesDollar.Value;
                QuoteTotal.Value = FilterNumber(FilterNumber(QuoteDollar.Value) / FilterNumber(ReqDollar.Value)) * 100;
                SalesTotal.Value = FilterNumber(FilterNumber(SalesDollar.Value) / FilterNumber(QuoteDollar.Value)) * 100;
            }
        }
        public override string Title
        {
            get
            {
                return "Quote Completion";
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            return new QuoteCompletionArgs((ContextRz)context);
        }
        //Protected Override Functions
        protected override void InitTotals()
        {
            base.InitTotals();
            ReqCount = new ReportTotalInteger("Totals");
            ReqCount.Overline = 1;
            ReqCount.Underline = 2;
            ReqCount.ValueColumn = 2;
            ReqCount.CaptionColumn = 1;
            Totals.Add(ReqCount);

            QuoteCount = new ReportTotalInteger("");
            QuoteCount.Overline = 1;
            QuoteCount.Underline = 2; 
            QuoteCount.ValueColumn = 3;
            Totals.Add(QuoteCount);

            SalesCount = new ReportTotalInteger("");
            SalesCount.Overline = 1;
            SalesCount.Underline = 2;
            SalesCount.ValueColumn = 4;
            Totals.Add(SalesCount);

            QuoteRatio = new ReportTotalPercent("");
            QuoteRatio.Overline = 1;
            QuoteRatio.Underline = 2;
            QuoteRatio.ValueColumn = 5;
            Totals.Add(QuoteRatio);

            SalesRatio = new ReportTotalPercent("");
            SalesRatio.Overline = 1;
            SalesRatio.Underline = 2;
            SalesRatio.ValueColumn = 6;
            Totals.Add(SalesRatio);

            ReqDollar = new ReportTotal("");
            ReqDollar.Overline = 1;
            ReqDollar.Underline = 2;
            ReqDollar.ValueColumn = 7;
            Totals.Add(ReqDollar);

            QuoteDollar = new ReportTotal("");
            QuoteDollar.Overline = 1;
            QuoteDollar.Underline = 2;
            QuoteDollar.ValueColumn = 8;
            Totals.Add(QuoteDollar);

            SalesDollar = new ReportTotal("");
            SalesDollar.Overline = 1;
            SalesDollar.Underline = 2;
            SalesDollar.ValueColumn = 9;
            Totals.Add(SalesDollar);

            QuoteTotal = new ReportTotalPercent("");
            QuoteTotal.Overline = 1;
            QuoteTotal.Underline = 2;
            QuoteTotal.ValueColumn = 10;
            Totals.Add(QuoteTotal);

            SalesTotal = new ReportTotalPercent("");
            SalesTotal.Overline = 1;
            SalesTotal.Underline = 2;
            SalesTotal.ValueColumn = 11;
            Totals.Add(SalesTotal);
        }
        private double FilterNumber(double d)
        {
            try
            {
                if (!Tools.Number.IsNumeric(d.ToString()))
                    return 0;
                if (d.ToString().ToLower().Contains("nan"))
                    return 0;
                if (d.ToString().ToLower().Contains("infinity"))
                    return 0;
                return d;
            }
            catch { }
            return 0;
        }
    }
    public class QuoteCompletionArgs : ReportArgs
    {
        //Public Variables
        public ReportCriteriaDateRange Range;
        public ReportCriteriaAgent Agent;

        //Constructors
        public QuoteCompletionArgs(ContextRz context) : base(context)
        {
            Range = new ReportCriteriaDateRange("Date Range");
            Criteria.Add(Range);
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent);
        }
    }
    public class QuoteCompletionSectionUser : ReportSection
    {
        public String UserID = "";
        public String UserName = "";
        public ReportTotalInteger ReqCount;
        public ReportTotalInteger QuoteCount;
        public ReportTotalInteger SalesCount;
        public ReportTotal ReqDollar;
        public ReportTotal QuoteDollar;
        public ReportTotal SalesDollar;
        public ReportTotalPercent QuoteRatio;
        public ReportTotalPercent SalesRatio;
        public ReportTotalPercent QuoteTotal;
        public ReportTotalPercent SalesTotal;

        //Constructors
        public QuoteCompletionSectionUser(ContextRz context, String user_id, String user_name)
        {
            UserID = user_id;
            UserName = user_name;

            string cap = "Totals";
            if (Tools.Strings.StrExt(UserName))
                cap = "Totals For " + UserName;
            ReqCount = new ReportTotalInteger(cap); 
            ReqCount.Overline = 1;
            ReqCount.ValueColumn = 2;
            ReqCount.CaptionColumn = 1;
            Totals.Add(ReqCount);

            QuoteCount = new ReportTotalInteger("");
            QuoteCount.Overline = 1;
            QuoteCount.ValueColumn = 3;
            Totals.Add(QuoteCount);

            SalesCount = new ReportTotalInteger("");
            SalesCount.Overline = 1;
            SalesCount.ValueColumn = 4;
            Totals.Add(SalesCount);

            QuoteRatio = new ReportTotalPercent("");
            QuoteRatio.Overline = 1;
            QuoteRatio.ValueColumn = 5;
            Totals.Add(QuoteRatio);

            SalesRatio = new ReportTotalPercent("");
            SalesRatio.Overline = 1;
            SalesRatio.ValueColumn = 6;
            Totals.Add(SalesRatio);

            ReqDollar = new ReportTotal("");
            ReqDollar.Overline = 1;
            ReqDollar.ValueColumn = 7;
            Totals.Add(ReqDollar);

            QuoteDollar = new ReportTotal("");
            QuoteDollar.Overline = 1;
            QuoteDollar.ValueColumn = 8;
            Totals.Add(QuoteDollar);

            SalesDollar = new ReportTotal("");
            SalesDollar.Overline = 1;
            SalesDollar.ValueColumn = 9;
            Totals.Add(SalesDollar);

            QuoteTotal = new ReportTotalPercent("");
            QuoteTotal.Overline = 1;
            QuoteTotal.ValueColumn = 10;
            Totals.Add(QuoteTotal);

            SalesTotal = new ReportTotalPercent("");
            SalesTotal.Overline = 1;
            SalesTotal.ValueColumn = 11;
            Totals.Add(SalesTotal);
        }
        public void QuoteCompletionLineAdd(ContextRz context, QuoteCompletion c, DataRow dr)
        {
            if (dr == null)
                return;
            long req_count = nData.NullFilter_Long(dr["req_count"]);
            long quote_count = nData.NullFilter_Long(dr["quote_count"]);
            long sales_count = nData.NullFilter_Long(dr["sales_count"]);
            double quote_r = (double)quote_count / (double)req_count;
            double sales_r = (double)sales_count / (double)quote_count; 
            double req_d = nData.NullFilter_Float(dr["req_d"]);
            double quote_d = nData.NullFilter_Float(dr["quote_d"]);
            double sales_d = nData.NullFilter_Float(dr["sales_d"]);
            double quote_r_d = FilterNumber(quote_d) / FilterNumber(req_d);
            double sales_r_d = FilterNumber(sales_d) / FilterNumber(quote_d);
            quote_r_d = FilterNumber(quote_r_d);
            sales_r_d = FilterNumber(sales_r_d);
            ReportLine l = new ReportLine();
            l.Set(1, "");
            l.Set(2, req_count, req_count.ToString());
            l.Set(3, quote_count, quote_count.ToString());
            l.Set(4, sales_count, sales_count.ToString());
            l.Set(5, ((long)Math.Round((quote_r * 100))), ((long)Math.Round((quote_r * 100))).ToString() + "%", null, "##0%");
            l.Set(6, ((long)Math.Round((sales_r * 100))), ((long)Math.Round((sales_r * 100))).ToString() + "%", null, "##0%");
            l.Set(7, req_d, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(req_d), null, context.TheSys.CurrencySymbol + "0.00#####");
            l.Set(8, quote_d, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(quote_d), null, context.TheSys.CurrencySymbol + "0.00#####");
            l.Set(9, sales_d, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(sales_d), null, context.TheSys.CurrencySymbol + "0.00#####");
            l.Set(10, ((long)Math.Round((quote_r_d * 100))), ((long)Math.Round((quote_r_d * 100))).ToString() + "%", null, "##0%");
            l.Set(11, ((long)Math.Round((sales_r_d * 100))), ((long)Math.Round((sales_r_d * 100))).ToString() + "%", null, "##0%");
            Lines.Add(l);
            ReqCount.Value += req_count;
            QuoteCount.Value += quote_count;
            SalesCount.Value += sales_count;
            QuoteRatio.Value = FilterNumber(FilterNumber(QuoteCount.Value) / FilterNumber(ReqCount.Value)) * 100;
            SalesRatio.Value = FilterNumber(FilterNumber(SalesCount.Value) / FilterNumber(QuoteCount.Value)) * 100;
            ReqDollar.Value += req_d;
            QuoteDollar.Value += quote_d;
            SalesDollar.Value += sales_d;
            QuoteTotal.Value = FilterNumber(FilterNumber(QuoteDollar.Value) / FilterNumber(ReqDollar.Value)) * 100;
            SalesTotal.Value = FilterNumber(FilterNumber(SalesDollar.Value) / FilterNumber(QuoteDollar.Value)) * 100;
        }
        private double FilterNumber(double d)
        {
            try
            {
                if (!Tools.Number.IsNumeric(d.ToString()))
                    return 0;
                if (d.ToString().ToLower().Contains("nan"))
                    return 0;
                if (d.ToString().ToLower().Contains("infinity"))
                    return 0;
                return d;
            }
            catch { }
            return 0;
        }
    }

}
