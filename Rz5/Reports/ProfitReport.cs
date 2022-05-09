using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;
using Core;
using Tools.Database;

namespace Rz5.Reports
{
    public class ProfitReport : Rz5.Report, IDisposable
    {
        //Public Variables
        public ProfitReportArgs CurrentArgs;
        public ReportTotal TotalProfit;
        public ReportTotal TotalVolume;

        //?
        public String ReportKey;
        public String StaticFinalTable = "";
        public bool trackmarks = Tools.Misc.IsDevelopmentMachine();

        public static int MaxPartLength = 25;

        public ProfitReport(ContextRz context)
            : base(context)
        {
            //TotalsColumn = "Profit";
        }

        //Public Static Functions
        public static String GetReportAsHTML(ContextRz context, ProfitReportArgs args)  //synchronous to the report, but possibly already on another thread
        {
            ProfitReport CurrentCore = new ProfitReport(context);
            CurrentCore.Calculate(context, args);

            ReportTargetHtml t = new ReportTargetHtml(false);
            t.Render(context, CurrentCore);
            CurrentCore.InitUn(context);
            CurrentCore.Dispose();
            return t.HtmlResult;
        }

        protected override void InitColumns(Context context)
        {
            Columns = new Dictionary<string, ReportColumn>();
            ColumnAdd(new ReportColumn("Agent"));
            ColumnAdd(new ReportColumn("Invoice"));
            ColumnAdd(new ReportColumn("Date"));
            ColumnAdd(new ReportColumn("Customer"));
            ColumnAdd(new ReportColumn("Vendor"));
            ColumnAdd(new ReportColumn("Part"));
            ColumnAdd(new ReportColumn("Price", ValueUse.TotalMoney));
            ColumnAdd(new ReportColumn("Cost", ValueUse.TotalMoney));
            ColumnAdd(new ReportColumn("Profit", ValueUse.TotalMoney));
        }

        protected override void InitTotals()
        {
            //this is required to clear the previous collection
            base.InitTotals();

            TotalProfit = new ReportTotal("Total Profit");
            TotalProfit.Overline = 1;
            TotalProfit.ValueColumn = 8;
            TotalProfit.ValueUse = ValueUse.TotalMoney;
            Totals.Add(TotalProfit);

            TotalVolume = new ReportTotal("Total Volume");
            TotalVolume.Underline = 2;
            TotalProfit.ValueColumn = 8;
            TotalVolume.ValueUse = ValueUse.TotalMoney;
            Totals.Add(TotalVolume);
        }

        public void InitUn(ContextRz context)
        {
            //DropReportTables(context);
        }

        public override void Dispose()
        {
            try
            {
                if (CurrentArgs != null)
                {
                    CurrentArgs.Dispose();
                    CurrentArgs = null;
                }
            }
            catch
            {
            }
        }

        public override void CalculateLines(Context context, ReportArgs args)
        {
            CurrentArgs = (ProfitReportArgs)args;

            base.CalculateLines(context, args);

            List<orddet_line> lines = OrderLinesSelect((ContextRz)context);

            foreach (orddet_line l in lines)
            {
                LineAdd((ContextRz)context, l);
            }
        }

        public override ReportArgs ArgsCreate(Context context)
        {
            return new ProfitReportArgs((ContextRz)context);
        }

        public override string Title
        {
            get
            {
                return "Profit Report";
            }
        }

        protected virtual void LineAdd(ContextRz context, orddet_line l)
        {
            ProfitReportSectionUser userSection = null;
            if (Sections.ContainsKey(l.seller_uid))
                userSection = (ProfitReportSectionUser)Sections[l.seller_uid];
            else
            {
                userSection = UserSectionCreate(context, l.seller_uid, l.seller_name);
                Sections.Add(l.seller_uid, userSection);
            }

            userSection.OrderLineAdd(context, this, l);
        }

        protected virtual ProfitReportSectionUser UserSectionCreate(ContextRz context, String user_id, String user_name)
        {
            return new ProfitReportSectionUser(context, user_id, user_name);
        }

        protected virtual String GetAgentSQL()
        {
            string sql = "";
            if (CurrentArgs.Agent != null)
            {
                if (CurrentArgs.Agent.AgentIds != null)
                {
                    if (CurrentArgs.Agent.AgentIds.Count > 0)
                    {
                        sql += " and orddet_line.seller_uid in ( " + Tools.Data.GetIn(CurrentArgs.Agent.AgentIds) + " ) ";
                    }
                }
            }
            return sql;
        }

        protected virtual List<orddet_line> OrderLinesSelect(ContextRz context)
        {
            String sql = "select orddet_line.* from orddet_line inner join ordhed_invoice on orddet_line.orderid_invoice = ordhed_invoice.unique_id where orddet_line.quantity > 0 and isnull(orddet_line.was_shipped, 0) = 1 ";

            if (CurrentArgs.DateRange.TheRange.Valid)
                sql += " and " + CurrentArgs.DateRange.TheRange.GetSQL("orddet_line.orderdate_invoice");
            else
                sql += " and orddet_line.orderdate_invoice > '1/2/1900' ";
            sql += GetAgentSQL();
            if (CurrentArgs.LimitToLineIds.Count > 0)
            {
                sql += " and orddet_line.unique_id in ( " + Tools.Data.GetIn(CurrentArgs.LimitToLineIds) + " ) ";
            }

            sql += ExtraSql(context);

            sql += " order by orddet_line.seller_name, orddet_line.orderdate_invoice";

            ArrayList a = context.QtC("orddet_line", sql);
            List<orddet_line> ret = new List<orddet_line>();

            foreach (orddet_line l in a)
            {
                ret.Add(l);
            }

            return ret;
        }

        protected virtual String ExtraSql(ContextRz context)
        {
            return "";
        }
    }
    public class ProfitReportSectionUser : ReportSection, IComparable
    {
        //Public Variables
        public String UserID = "";
        public String UserName = "";

        public ReportTotal TotalProfit;
        public ReportTotal TotalVolume;

        public ProfitReportSectionUser(ContextRz context, String user_id, String user_name)
        {
            UserID = user_id;
            UserName = user_name;

            TotalProfit = new ReportTotal("Total " + UserName);
            TotalProfit.Overline = 1;
            TotalProfit.ValueUse = ValueUse.TotalMoney;
            TotalProfit.ValueColumn = 8;
            TotalProfit.CaptionColumn = 0;
            Totals.Add(TotalProfit);

            TotalVolume = new ReportTotal("Volume " + UserName);
            TotalVolume.ValueUse = ValueUse.TotalMoney;
            Totals.Add(TotalVolume);
        }

        public override string Caption
        {
            get
            {
                return UserName;
            }
        }

        //Public Functions
        public int CompareTo(Object x)
        {
            ProfitReportSectionUser u = (ProfitReportSectionUser)x;
            return UserName.Trim().ToLower().CompareTo(u.UserName.Trim().ToLower());
        }

        public virtual void OrderLineAdd(ContextRz context, ProfitReport r, orddet_line l)
        {
            ReportLine ret = new ReportLine();
            ProfitLineSet(context, r, ret, l);
            Lines.Add(ret);

            ProfitAdd(context, r, l, l.gross_profit, "Profit");
            VolumeAdd(context, r, l, l.total_price);

            foreach (profit_deduction d in l.DeductionsVar.RefsList(context))
            {
                ret = new ReportLine();
                ret.ForeColor = Color.Red;
                r.Set(ret, "Part", d.name, Tools.Strings.LeftEllipse(d.name, ProfitReport.MaxPartLength));
                r.Set(ret, "Profit", d.amount * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(d.amount));
                Lines.Add(ret);

                ProfitAdd(context, r, l, (d.amount * -1), "Deduction");
            }
            //services
            if (!l.charge_service_to_customer)
            {
                foreach (service_line sl in l.ServiceLines.RefsList(context))
                {
                    ret = new ReportLine();
                    ret.ForeColor = Color.Red;
                    double total_cost = sl.total_cost;
                    r.Set(ret, "Part", sl.service_name, Tools.Strings.LeftEllipse(sl.service_name, ProfitReport.MaxPartLength));
                    r.Set(ret, "Profit", total_cost * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(total_cost));
                    Lines.Add(ret);
                    ProfitAdd(context, r, l, (total_cost * -1), "Service");
                }
            }
            RMACheckAdd(context, r, l);
        }

        protected virtual void ProfitAdd(ContextRz context, ProfitReport r, orddet_line l, Double amount, String caption)
        {
            //this user
            TotalProfit.Value += amount;

            //overall
            r.TotalProfit.Value += amount;
        }

        protected virtual void VolumeAdd(ContextRz context, ProfitReport r, orddet_line l, Double amount)
        {
            //this user
            TotalVolume.Value += amount;

            //overall
            r.TotalVolume.Value += amount;
        }

        protected virtual void RMACheckAdd(ContextRz context, ProfitReport r, orddet_line l)
        {
            if (l.rma_subtraction != 0)
            {
                ReportLine ret = new ReportLine();
                ret.ForeColor = Color.Red;
                r.Set(ret, "Part", "RMA " + l.ordernumber_rma);
                r.Set(ret, "Profit", l.rma_subtraction * -1, "-" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(l.rma_subtraction));
                Lines.Add(ret);

                ProfitAdd(context, r, l, (l.rma_subtraction * -1), "RMA");
                VolumeAdd(context, r, l, (l.total_price * -1));
            }
        }

        protected virtual void ProfitLineSet(ContextRz context, Report report, ReportLine rl, orddet_line ol)
        {
            report.Set(rl, "Agent", ol.seller_name);
            report.Set(rl, "Invoice", ol.ordernumber_invoice);
            report.Set(rl, "Date", Tools.Dates.DateFormat(ol.orderdate_invoice));
            report.Set(rl, "Customer", Tools.Strings.ParseDelimit(ol.customer_name, "[", 1));

            if (ol.PurchaseHas)
                report.Set(rl, "Vendor", Tools.Strings.ParseDelimit(ol.vendor_name, "[", 1) + " [PO# " + ol.ordernumber_purchase + "]");
            else
            {
                if (ol.StockTypeReceive == Enums.StockType.Consign)
                    report.Set(rl, "Vendor", "Consignment [Lot# " + ol.lotnumber + "]");
                else
                    report.Set(rl, "Vendor", "Stock");
            }

            report.Set(rl, "Part", ol.fullpartnumber, Tools.Strings.LeftEllipse(ol.fullpartnumber, ProfitReport.MaxPartLength));
            report.Set(rl, "Price", ol.total_price, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ol.total_price));
            report.Set(rl, "Cost", ol.total_cost, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ol.total_cost));
            report.Set(rl, "Profit", ol.gross_profit, context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(ol.gross_profit));
        }

        public void AbsorbTotals(ProfitReportSectionUser x)
        {
            TotalProfit.Value += x.TotalProfit.Value;
            TotalVolume.Value += x.TotalVolume.Value;

            x.TotalProfit.Value = 0;
            x.TotalVolume.Value = 0;
        }
    }
}
