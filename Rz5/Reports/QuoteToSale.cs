using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using Rz5;
using Core;

namespace Rz5.Reports
{
    public class QuoteToSale : Rz5.Report
    {
        public ReportTotal QuoteVolume;
        public ReportTotal TotalOutstanding;
        public ReportTotal TotalSales;

        public QuoteToSale(ContextRz x)
            : base(x)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Date"));
            ColumnAdd(new ReportColumn("Quote #"));
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Company"));
            ColumnAdd(new ReportColumn("Quote Total", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("No. Quotes", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("No. Sales", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Close Ratio", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Outstanding", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Sale Amt", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Sale Amt%", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Invoiced"));
        }
        public override string Title
        {
            get
            {
                return "Quote-To-Sale Ratio";
            }
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            ContextRz xs = (ContextRz)context;
            base.CalculateLines(context, args);
            QuoteToSaleSummary sum = new QuoteToSaleSummary(xs);            
            SubReports.Clear();
            SubReports.Add(sum);
            String sql = "select q.unique_id, q.base_ordhed_uid, q.base_dealheader_uid, d.dealheader_name, o.orderdate, q.ordernumber, q.agentname, q.companyname, q.target_quantity, q.quantityordered, q.unitprice, q.base_company_uid, max(l.ordernumber_sales) as ordernumber_sales, max(l.ordernumber_invoice) as ordernumber_invoice, max(isnull(l.unit_price, 0) * isnull(l.quantity, 0)) as sale_total from orddet_quote q left join orddet_line l on l.quote_line_uid = q.unique_id and l.status <> 'Void' left join dealheader d on d.unique_id = q.base_dealheader_uid left join ordhed_quote o on o.unique_id = q.base_ordhed_uid ";
            sql += " where ( isnull(q.target_quantity, 0) > 0 or isnull(q.quantityordered, 0) > 0 ) and len(isnull(q.base_ordhed_uid,'')) > 0 and isnull(q.isvoid,0) = 0 ";
            QuoteToSaleArgs argsx = (QuoteToSaleArgs)args;
            if (argsx.QuoteRange.TheRange.Valid)
                sql += " and " + argsx.QuoteRange.TheRange.GetSQL("o.orderdate");
            if (argsx.Agent.Exists())
                sql += " and q.base_mc_user_uid in ( " + Tools.Data.GetIn(argsx.Agent.AgentIds) + " ) ";
            if (!xs.xUser.SuperUser && !xs.CheckPermit(NewMethod.Permissions.ThePermits.ViewAllUsersOnReports))
                sql += " and q.agentname = '" + context.Filter(xs.xUser.name) + "' ";
            sql += " group by q.unique_id, q.base_ordhed_uid, q.base_dealheader_uid, d.dealheader_name, o.orderdate, q.ordernumber, q.agentname, q.companyname, q.target_quantity, q.quantityordered, q.unitprice, q.base_company_uid ";
            sql += " order by q.agentname, o.orderdate";
            DataTable d = context.Select(sql);
            foreach (DataRow r in d.Rows)
            {
                String key = Tools.Strings.NiceFormat(Tools.Data.NullFilterString(r["agentname"]));
                AgentSection s = null;
                if( Sections.ContainsKey(key) )
                    s = (AgentSection)Sections[key];
                else
                {
                    s = new AgentSection();
                    s.AgentName = key;
                    Sections.Add(key, s);
                }
                s.Add(xs, this, r, sum);
            }
            sum.Apply();
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            //return base.ArgsCreate();
            return new QuoteToSaleArgs((ContextRz)context);
        }
        protected override void InitTotals()
        {
            base.InitTotals();

            QuoteVolume = new ReportTotal("Office Total");
            QuoteVolume.CaptionColumn = 3;
            QuoteVolume.ValueColumn = 4;
            Totals.Add(QuoteVolume);

            TotalOutstanding = new ReportTotalOutstandingAmout();
            TotalOutstanding.ValueColumn = 8;
            Totals.Add(TotalOutstanding);

            TotalSales = new ReportTotal("");
            TotalSales.ValueColumn = 9;
            Totals.Add(TotalSales);
        }
    }
    public class AgentSection : ReportSection
    {
        public String AgentName;
        ReportTotal QuoteVolume;
        ReportTotalInteger QuoteCount;
        ReportTotalInteger SaleCount;
        ReportTotalPercent CloseRatio;
        ReportTotal TotalOutstanding;
        ReportTotal TotalSales;
        ReportTotal TotalQuotes;
        ReportTotalPercent TotalSalesPerc;
            
        public AgentSection()
        {
            ShowColumnCaptions = true;

            QuoteVolume = new ReportTotal("Agent Total");
            QuoteVolume.CaptionColumn = 3;
            QuoteVolume.ValueColumn = 4;
            Totals.Add(QuoteVolume);


            QuoteCount = new ReportTotalInteger("");
            QuoteCount.ValueColumn = 5;
            Totals.Add(QuoteCount);

            SaleCount = new ReportTotalInteger("");
            SaleCount.ValueColumn = 6;
            Totals.Add(SaleCount);

            CloseRatio = new ReportTotalPercent("");
            CloseRatio.ValueColumn = 7;
            Totals.Add(CloseRatio);

            TotalOutstanding = new ReportTotalOutstandingAmout();
            TotalOutstanding.ValueColumn = 8;
            Totals.Add(TotalOutstanding);

            TotalSales = new ReportTotal("");
            TotalSales.ValueColumn = 9;
            Totals.Add(TotalSales);

            TotalQuotes = new ReportTotal("");

            TotalSalesPerc = new ReportTotalPercent("");
            TotalSalesPerc.ValueColumn = 10;
            Totals.Add(TotalSalesPerc);
        }
        public void Add(Rz5.ContextRz context, QuoteToSale report, DataRow r, QuoteToSaleSummary sum)
        {
            DateTime quoteDate = Tools.Data.NullFilterDate(r["orderdate"]);
            String key = Tools.Dates.DateFormat(quoteDate);
            DaySection s = null;
            if (Sections.ContainsKey(key))
                s = (DaySection)Sections[key];
            else
            {
                s = new DaySection();
                Sections.Add(key, s);
            }
            
            int quantityQuoted = Tools.Data.NullFilterIntegerFromIntOrLong(r["quantityordered"]);
            Double unitPrice = Tools.Data.NullFilterDouble(r["unitprice"]);

            if (quantityQuoted > 0 && unitPrice > 0)
            {
                s.QuoteCount.Value++; // Total quotes for the agent by day
                QuoteCount.Value++; //Total quotes fore the agent
            }

            ReportLine l = new ReportLine();
            l.Set(0, key);

            String quoteNumber = Tools.Data.NullFilterString(r["ordernumber"]);
            String classname = "";
            String id = "";
            if (!Tools.Strings.StrExt(quoteNumber))
            {
                quoteNumber = Tools.Data.NullFilterString(r["dealheader_name"]);
                classname = "dealheader";
                id = Tools.Data.NullFilterString(r["base_dealheader_uid"]);
            }
            else
            {
                id = Tools.Data.NullFilterString(r["base_ordhed_uid"]);
                classname = "ordhed_quote";
            }
            l.Set(1, quoteNumber, new Core.ItemTag(classname, id));
            l.Set(2, Tools.Data.NullFilterString(r["agentname"]));

            String companyId = Tools.Data.NullFilterString(r["base_company_uid"]);
            l.Set(3, Tools.Data.NullFilterString(r["companyname"]), new Core.ItemTag("company", companyId));

            bool sold = Tools.Strings.StrExt(Tools.Data.NullFilterString(r["ordernumber_sales"]));

            if (sold)
            {
                s.SaleCount.Value++;
                SaleCount.Value++;
            }

            Double totalQuote = quantityQuoted * unitPrice;

            int one = 1;

            l.Set(4, totalQuote, Tools.Number.MoneyFormat(totalQuote));
            //l.Set(6, one, "1");

            //if( quantityQuoted > 0 )
            //    l.Set(6, one, "1");
            //else
            //    l.Set(6, 0, "");

            //if( sold )
            //    l.Set(7, one, "1");
            //else
            //    l.Set(7, 0, "");

            Double totalSale = Tools.Data.NullFilterDouble(r["sale_total"]);
            Double outstandingAmount = totalQuote - totalSale;

            if (outstandingAmount > 0)
            {
                if(totalSale > 0 )
                    l.Set(8, outstandingAmount, "($" + Tools.Number.MoneyFormat(outstandingAmount) + ")", Color.Red);
                else
                    l.Set(8, outstandingAmount, "$" + Tools.Number.MoneyFormat(outstandingAmount));
            }
            else
                l.Set(8, 0, "");

            if (totalSale > 0)
                l.Set(9, totalSale, "$" + Tools.Number.MoneyFormat(totalSale));
            else
                l.Set(9, 0, "");
            TotalQuotes.Value += totalQuote;
            l.Set(11, Tools.Strings.YesBlankFilter(Tools.Strings.StrExt(Tools.Data.NullFilterString(r["ordernumber_invoice"]))));
            s.QuoteVolume.Value += totalQuote;
            report.QuoteVolume.Value += totalQuote;
            QuoteVolume.Value += totalQuote;
            TotalOutstanding.Value += outstandingAmount;
            report.TotalOutstanding.Value += outstandingAmount;
            TotalSales.Value += totalSale;
            report.TotalSales.Value += totalSale;
            TotalSalesPerc.Value = Tools.Number.CalcPercent(TotalQuotes.Value, TotalSales.Value);
            s.TotalSalesPerc.Value = Tools.Number.CalcPercent(TotalQuotes.Value, TotalSales.Value);
            s.Lines.Add(l);
            CloseRatio.Value = Tools.Number.CalcPercent(QuoteCount.Value, SaleCount.Value);
            int quoteCount = 0;
            if( quantityQuoted > 0 )
                quoteCount = 1;
            int saleCount = 0;
            if( sold )
                saleCount = 1;
            sum.Add(quoteDate, quoteCount, saleCount);
        }
    }
    public class DaySection : ReportSection
    {
        public ReportTotal QuoteVolume;       
        public ReportTotalInteger QuoteCount;
        public ReportTotalInteger SaleCount;
        public ReportTotalPercent TotalSalesPerc;

        public DaySection()
        {
            InsertSpaceBelow = false;

            QuoteVolume = new ReportTotal("Sub-Total");
            QuoteVolume.CaptionColumn = 3;
            QuoteVolume.ValueColumn = 4;
            Totals.Add(QuoteVolume);

            QuoteCount = new ReportTotalInteger("");
            QuoteCount.ValueColumn = 5;
            Totals.Add(QuoteCount);

            SaleCount = new ReportTotalInteger("");
            SaleCount.ValueColumn = 6;
            Totals.Add(SaleCount);

            TotalSalesPerc = new ReportTotalPercent("");
            TotalSalesPerc.ValueColumn = 10;
            Totals.Add(TotalSalesPerc);
        }
    }
    public class QuoteToSaleArgs : ReportArgs
    {
        public ReportCriteriaDateRange QuoteRange;
        public ReportCriteriaAgent Agent;
        public QuoteToSaleArgs(Rz5.ContextRz context)
            : base(context)
        {
            QuoteRange = new ReportCriteriaDateRange("Quote Range");
            QuoteRange.TheRange = Tools.Dates.DateRange.MonthToDate;
            QuoteRange.DefaultOption = "Month To Date";
            Criteria.Add(QuoteRange);
            Agent = new ReportCriteriaAgent("Agent");
            Criteria.Add(Agent); 
        }
    }
    class ReportTotalOutstandingAmout : ReportTotal
    {
        public ReportTotalOutstandingAmout()
            : base("")
        {
        }
        public override string Render()
        {
            return "(" + base.Render() + ")";
        }
        public override Color Color
        {
            get
            {
                return Color.Red;
            }
        }
    }
    public class QuoteToSaleSummary : Rz5.Report
    {
        ReportTotalInteger QuoteCount;
        ReportTotalInteger SaleCount;
        ReportTotalPercent CloseRatio;
        public QuoteToSaleSummary(ContextRz x)
            : base(x)
        {

        }
        Dictionary<String, ReportLine> LinesByDate;
        List<DateTime> Dates;
        public void Apply()
        {
            Dates.Sort();
            foreach (DateTime d in Dates)
            {
                String dt = Tools.Dates.DateFormat(d);
                Lines.Add(LinesByDate[dt]);
            }
        }
        public void Add(DateTime date, int quoteCount, int saleCount)
        {
            String d = Tools.Dates.DateFormat(date);
            ReportLine l = null;
            if( LinesByDate.ContainsKey(d))
                l = LinesByDate[d];
            else
            {
                l = new ReportLine();
                LinesByDate.Add(d, l);
                l.Set(0, d);
                Dates.Add(date);
            }

            int qc = 0;
            try
            {
                qc = (int)l.Cells[1].Value;
            }
            catch { }

            qc += quoteCount;
            l.Set(1, qc, Tools.Number.LongFormat(qc));

            int sc = 0;
            try
            {
                sc = (int)l.Cells[2].Value;
            }
            catch { }

            sc += saleCount;
            l.Set(2, sc, Tools.Number.LongFormat(sc));

            int percent = Tools.Number.CalcPercent(qc, sc);
            l.Set(3, percent, percent.ToString() + "%");

            QuoteCount.Value += quoteCount;
            SaleCount.Value += saleCount;
            CloseRatio.Value = Tools.Number.CalcPercent(QuoteCount.Value, SaleCount.Value);
        }
        public override string Title
        {
            get
            {
                return "";
            }
        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Date"));
            ColumnAdd(new ReportColumn("No. Quotes", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("No. Sales", Core.ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Close Ratio", Core.ColumnAlignment.Right));
            LinesByDate = new Dictionary<string, ReportLine>();
            Dates = new List<DateTime>();
            Calculate(context, new ReportArgs(context));  //to init things
        }
        protected override void InitTotals()
        {
            base.InitTotals();

            QuoteCount = new ReportTotalInteger("");
            QuoteCount.CaptionColumn = 0;
            QuoteCount.Caption = "Total";
            QuoteCount.ValueColumn = 1;
            Totals.Add(QuoteCount);

            SaleCount = new ReportTotalInteger("");
            SaleCount.ValueColumn = 2;
            Totals.Add(SaleCount);

            CloseRatio = new ReportTotalPercent("");
            CloseRatio.ValueColumn = 3;
            Totals.Add(CloseRatio);
        }
    }
}
