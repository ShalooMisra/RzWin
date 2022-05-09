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
    public class CustomerInvoiceReport : Rz5.Report
    {
        //Public Variables
        public ReportTotal TotalAmount;
        //KT
        public ReportTotal NetAmount;
        public ReportTotal TotalCost;
        public ReportTotal TotalPostCost;
        public ReportTotal OpenBalance;
        public ReportTotal GP;
        public ReportTotalPercent GP_Perc;
        public ReportTotal Net;
        public ReportTotalPercent Net_Perc;

        public CustomerInvoiceReport(ContextRz x)
            : base(x)
        {

        }
        protected override void InitColumns(Context context)
        {
            ColumnAdd(new ReportColumn("Date", ColumnAlignment.Left));
            ColumnAdd(new ReportColumn("Sale #", ColumnAlignment.Left));
            ColumnAdd(new ReportColumn("Invoice #", ColumnAlignment.Left));
            ColumnAdd(new ReportColumn("Customer", ColumnAlignment.Left));
            ColumnAdd(new ReportColumn("Amount", ColumnAlignment.Right));
            //KT
            ColumnAdd(new ReportColumn("NetAmount", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Open Balance", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("GP", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("GP %", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Net", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Net %", ColumnAlignment.Right));
            ColumnAdd(new ReportColumn("Rep", ColumnAlignment.Left));
        }
        protected override void InitTotals()
        {

            base.InitTotals();
            TotalAmount = new ReportTotal("Totals:");
            TotalAmount.Caption = "Totals:";
            TotalAmount.CaptionColumn = 3;
            TotalAmount.ValueColumn = 4;
            Totals.Add(TotalAmount);

            NetAmount = new ReportTotal("");
            NetAmount.ValueColumn = 5;
            Totals.Add(NetAmount);

            OpenBalance = new ReportTotal("");
            OpenBalance.ValueColumn = 6;
            Totals.Add(OpenBalance);

            GP = new ReportTotal("");
            GP.ValueColumn = 7;
            Totals.Add(GP);

            GP_Perc = new ReportTotalPercent("");
            GP_Perc.ValueColumn = 8;
            Totals.Add(GP_Perc);

            Net = new ReportTotal("");
            Net.ValueColumn = 9;
            Totals.Add(Net);

            Net_Perc = new ReportTotalPercent("");
            Net_Perc.ValueColumn = 10;
            Totals.Add(Net_Perc);

            TotalCost = new ReportTotal("");
            TotalPostCost = new ReportTotal("");
        }
        public override string Title
        {
            get
            {
                return "Customer Invoice Report";
            }
        }
        public override void CalculateLines(Context context, ReportArgs args)
        {
            ContextRz xs = (ContextRz)context;
            base.CalculateLines(context, args);
            CustomerInvoiceReportArgs argsx = (CustomerInvoiceReportArgs)args;
            Caption = Title + " " + argsx.ToString();
            Lines.Clear();
            InitTotals();
            Sections.Clear();
            string table = "temp_" + Tools.Strings.GetNewID() + "_table";
            //String sql = "select orderdate_invoice,orderid_sales,ordernumber_sales,orderid_invoice,ordernumber_invoice,orderid_purchase,orderid_rma,orderid_vendrma,seller_uid,seller_name,(quantity*unit_price) as total_price,(quantity*unit_cost) as total_cost,service_cost,customer_name,customer_uid into " + table + " from orddet_line where len(isnull(orderid_sales,'')) > 0 and len(isnull(orderid_invoice,'')) > 0 and isnull(isvoid,0) = 0 and status != 'void' ";
            //KT original query did not have net_profit
            string sql = "select i.isclosed, was_rma, l.net_profit, orderdate_invoice,orderid_sales,ordernumber_sales,orderid_invoice,ordernumber_invoice,orderid_purchase,orderid_rma,orderid_vendrma,seller_uid,seller_name,(quantity*unit_price) as total_price,(quantity*unit_cost) as total_cost,service_cost,customer_name,customer_uid into " + table + " from orddet_line l left outer join ordhed_invoice i on l.orderid_invoice = i.unique_id where len(isnull(orderid_sales,'')) > 0 and len(isnull(orderid_invoice,'')) > 0 and isnull(l.isvoid,0) = 0 and status != 'void' ";

            if (argsx.ShippedOnly.Value == true)
                //sql += " AND isnull(i.isclosed, 0) = 1 ";
                sql += " AND len(isnull(i.trackingnumber, '')) > 0 ";

            //Here, if not a super user, set arts to the current agent, then set the dropdown to static?
            //if((Rz5.PermitLogic.  )
            //    (Rz5.PermitLogic)context.xSys.ThePermitLogic.CanBeDeletedByFormalQuote((ContextRz)context, this, context.xUser);


            if (argsx.Agent != null)
            {
                if (argsx.Agent.Exists())
                {
                    string inn = Tools.Data.GetIn(argsx.Agent.AgentIds);
                    if (Tools.Strings.StrExt(inn))
                        sql += " and seller_uid in (" + inn + ") ";
                }
                //KT only show current agents totals if no permission (see Agent criteria section below for permission check)

            }
            else
            {
                sql += " and seller_uid = '" + xs.xUser.unique_id + "' ";
                Caption += " [" + xs.xUser.name + "]";
            }
            if (argsx.Date.Exists())
                sql += " and orderdate_invoice " + argsx.Date.TheRange.GetBetweenSQL();
            context.Execute(sql);
            context.Execute("alter table " + table + " add gp float");
            context.Execute("alter table " + table + " add net float");
            context.Execute("update " + table + " set gp = (total_price - total_cost)");
            //context.Execute("update " + table + " set net = (total_price - total_cost)");
            context.Execute("update " + table + " set net = (net_profit)");
            string order = "";
            if (Tools.Strings.StrCmp(argsx.Group.SelectedCaption, "Agent"))
                order = " order by seller_name asc,orderdate_invoice desc";
            else
                order = " order by customer_name asc,orderdate_invoice desc";
            DataTable d = context.Select("select * from " + table + order);
            Dictionary<String, CustomerInvoice> invoices = new Dictionary<String, CustomerInvoice>();
            foreach (DataRow r in d.Rows)
            {
                string id = Tools.Data.NullFilterString(r["orderid_invoice"]);
                CustomerInvoice i = null;
                invoices.TryGetValue(id, out i);
                if (i == null)
                {
                    i = new CustomerInvoice();
                    invoices.Add(id, i);
                }
                i.ProcessRow(r);
            }
            foreach (KeyValuePair<String, CustomerInvoice> kvp in invoices)
            {
                kvp.Value.ProcessRest((ContextRz)context);
                if (Tools.Strings.StrCmp(argsx.Group.SelectedCaption, "Agent"))
                {
                    CustomerInvoiceReportAgentSection agentSection = null;
                    if (Sections.ContainsKey(kvp.Value.RepID))
                        agentSection = (CustomerInvoiceReportAgentSection)Sections[kvp.Value.RepID];
                    else
                    {
                        agentSection = new CustomerInvoiceReportAgentSection(kvp.Value.Rep);
                        Sections.Add(kvp.Value.RepID, agentSection);
                    }
                    agentSection.Add(xs, this, kvp.Value);
                }
                else
                {
                    CustomerInvoiceReportCompanySection companySection = null;
                    if (Sections.ContainsKey(kvp.Value.CustomerID))
                        companySection = (CustomerInvoiceReportCompanySection)Sections[kvp.Value.CustomerID];
                    else
                    {
                        companySection = new CustomerInvoiceReportCompanySection(kvp.Value.CustomerName);
                        Sections.Add(kvp.Value.CustomerID, companySection);
                    }
                    companySection.Add(xs, this, kvp.Value);
                }
            }
            context.Execute("drop table " + table);
            if (Tools.Strings.StrCmp(argsx.Group.SelectedCaption, "Agent"))
            {
                foreach (KeyValuePair<String, ReportSection> kvp in Sections)
                {
                    CustomerInvoiceReportAgentSection a = (CustomerInvoiceReportAgentSection)kvp.Value;
                    if (a.TotalAmount.Value < 0)
                        ((ReportTotalColored)a.TotalAmount).TheColor = Color.Red;
                    if (a.OpenBalance.Value < 0)
                        ((ReportTotalColored)a.OpenBalance).TheColor = Color.Red;
                    if (a.GP.Value < 0)
                        ((ReportTotalColored)a.GP).TheColor = Color.Red;
                    if (a.GP_Perc.Value < 0)
                        ((ReportTotalColoredPercent)a.GP_Perc).TheColor = Color.Red;
                    if (a.Net.Value < 0)
                        ((ReportTotalColored)a.Net).TheColor = Color.Red;
                    if (a.Net_Perc.Value < 0)
                        ((ReportTotalColoredPercent)a.Net_Perc).TheColor = Color.Red;
                }
            }
            else
            {
                foreach (KeyValuePair<String, ReportSection> kvp in Sections)
                {
                    CustomerInvoiceReportCompanySection a = (CustomerInvoiceReportCompanySection)kvp.Value;
                    if (a.TotalAmount.Value < 0)
                        ((ReportTotalColored)a.TotalAmount).TheColor = Color.Red;
                    if (a.OpenBalance.Value < 0)
                        ((ReportTotalColored)a.OpenBalance).TheColor = Color.Red;
                    if (a.GP.Value < 0)
                        ((ReportTotalColored)a.GP).TheColor = Color.Red;
                    if (a.GP_Perc.Value < 0)
                        ((ReportTotalColoredPercent)a.GP_Perc).TheColor = Color.Red;
                    if (a.Net.Value < 0)
                        ((ReportTotalColored)a.Net).TheColor = Color.Red;
                    if (a.Net_Perc.Value < 0)
                        ((ReportTotalColoredPercent)a.Net_Perc).TheColor = Color.Red;
                }
            }
        }
        public override ReportArgs ArgsCreate(Context context)
        {
            //return base.ArgsCreate();
            return new CustomerInvoiceReportArgs((ContextRz)context);
        }
    }
    public class CustomerInvoice
    {
        public DateTime Date = Tools.Dates.GetNullDate();
        public String SalesNumber = "";
        public String SalesID = "";
        public String InvoiceNumber = "";
        public String InvoiceID = "";
        public String CustomerName = "";
        public String CustomerID = "";
        public Double Amount = 0;
        //KT
        public Double NetAmount = 0;
        public Double Cost = 0;
        public Double PostCost = 0;
        public Double ServiceCost = 0;
        public String RepID = "";
        public String Rep = "";
        public Double Deductions = 0;
        public Double OpenBalance = 0;
        public Double GP = 0;
        public Double Net = 0;
        public Double GP_Perc = 0;
        public Double Net_Perc = 0;
        public Double RMA_Total = 0;
        public Double VRMA_Total = 0;
        private DataRow Row;

        public CustomerInvoice()
        {

        }
        public void ProcessRow(DataRow r)
        {
            Row = r;
            ProcessStrings();
            ProcessNumbers();
        }
        public void ProcessRest(ContextRz x)
        {
            //Deductions + Invoice Credits + Service Cost
            Deductions = x.SelectScalarDouble("select sum(amount) from profit_deduction where the_orddet_line_uid in (select unique_id from orddet_line where orderid_invoice = '" + InvoiceID + "')");
            Deductions += ServiceCost;
            string po_id = Tools.Data.NullFilterString(Row["orderid_purchase"]);
            if (Tools.Strings.StrExt(po_id))
            {
                Deductions += x.SelectScalarDouble("select sum(hit_amount) from ordhit where base_ordhed_uid = '" + po_id + "' and isnull(deduct_profit,0) = 1");
                Cost += x.SelectScalarDouble("select (shippingamount+handlingamount+taxamount) from ordhed_purchase where unique_id = '" + po_id + "'");

            }

            double discounts = ((SysRz5)x.xSys).TheProfitLogic.GetOrderCredits(x, new List<string>() { InvoiceID });
            double companycredits = ((SysRz5)x.xSys).TheProfitLogic.GetAssignedCompanyCredits(x, new List<string>() { InvoiceID });
            double charges = ((SysRz5)x.xSys).TheProfitLogic.GetOrderCharges(x, InvoiceID);
            double paid = x.SelectScalarDouble("select sum(transamount) from checkpayment where base_ordhed_uid = '" + InvoiceID + "' and transtype = 'payment'");

            //Cost += ServiceCost;

            //Amount += charges;
            //GP = Amount - Cost - RMA_Total;




            //KT 11-4-2015
            //Net = amnt - PostCost;
            //KT going to try to handle this back on processrow so I can work with net_profit





            //KT not sure why NetAmount was the amoutn minus the Total, I though FT wanted this to be the amount before credits applied.
            //NetAmount = Amount - RMA_Total;











            //Open Balance Stuff?
            double amnt = Amount - RMA_Total;
            double cost = Cost - VRMA_Total;
            PostCost = cost + Deductions;
            Amount += charges;

            if (RMA_Total > 0)
                GP = Amount - RMA_Total;
            else
                GP = Amount - Cost;
            GP_Perc = 0;
            if (Cost > 0)
                GP_Perc = x.Sys.TheOrderLogic.GetMarginNetValue(GP, Cost);


            OpenBalance = (amnt - discounts - companycredits + charges) - paid;
            if (OpenBalance < 0)
                OpenBalance = 0;

            Net = Net - discounts - ServiceCost;
            Net_Perc = 0;
            if (PostCost > 0)
                Net_Perc = x.Sys.TheOrderLogic.GetMarginNetValue(Net, PostCost);

            NetAmount = Amount - discounts;

        }
        private void ProcessStrings()
        {
            if (!Tools.Dates.DateExists(Date))
                Date = Tools.Data.NullFilterDate(Row["orderdate_invoice"]);
            if (!Tools.Strings.StrExt(SalesNumber))
                SalesNumber = Tools.Data.NullFilterString(Row["ordernumber_sales"]);
            if (!Tools.Strings.StrExt(SalesID))
                SalesID = Tools.Data.NullFilterString(Row["orderid_sales"]);
            if (!Tools.Strings.StrExt(InvoiceNumber))
                InvoiceNumber = Tools.Data.NullFilterString(Row["ordernumber_invoice"]);
            if (!Tools.Strings.StrExt(InvoiceID))
                InvoiceID = Tools.Data.NullFilterString(Row["orderid_invoice"]);
            if (!Tools.Strings.StrExt(CustomerName))
                CustomerName = Tools.Data.NullFilterString(Row["customer_name"]);
            if (!Tools.Strings.StrExt(CustomerID))
                CustomerID = Tools.Data.NullFilterString(Row["customer_uid"]);
            if (!Tools.Strings.StrExt(Rep))
                Rep = Tools.Data.NullFilterString(Row["seller_name"]);
            if (!Tools.Strings.StrExt(RepID))
                RepID = Tools.Data.NullFilterString(Row["seller_uid"]);
        }
        private void ProcessNumbers()
        {

            //KT 11-17-2015 - Updated the below calcs to round up appropriately per Fred.
            Amount += Tools.Data.NullFilterDouble(Row["total_price"]);
            //Amount = System.Math.Ceiling(Amount * 100) / 100;            

            Cost += Tools.Data.NullFilterDouble(Row["total_cost"]);
            //Cost = System.Math.Ceiling(Cost * 100) / 100;

            ServiceCost += Tools.Data.NullFilterDouble(Row["service_cost"]);
            //ServiceCost = System.Math.Ceiling(ServiceCost * 100) / 100;

            if (Tools.Strings.StrExt(Tools.Data.NullFilterString(Row["orderid_rma"])))
            {
                RMA_Total += Tools.Data.NullFilterDouble(Row["total_price"]);
                //RMA_Total = System.Math.Ceiling(RMA_Total * 100) / 100;
            }

            if (Tools.Strings.StrExt(Tools.Data.NullFilterString(Row["orderid_vendrma"])))
            {
                VRMA_Total += Tools.Data.NullFilterDouble(Row["total_cost"]);
                //VRMA_Total = System.Math.Ceiling(VRMA_Total * 100) / 100;
            }
            if (Tools.Strings.StrExt(Tools.Data.NullFilterString(Row["net_profit"])))
            {

                double line_net_profit = Tools.Data.NullFilterDouble(Row["net_profit"]);
                Net += line_net_profit;
                //VRMA_Total = System.Math.Ceiling(VRMA_Total * 100) / 100;
            }
        }
    }
    public class CustomerInvoiceReportAgentSection : ReportSection // Totals at the botom of each agent sectionm
    {
        //Public Variables
        public ReportTotalColored TotalAmount;
        //KT
        public ReportTotalColored NetAmount;
        public ReportTotal TotalCost;
        public ReportTotal TotalPostCost;
        public ReportTotalColored OpenBalance;
        public ReportTotalColored GP;
        public ReportTotalColoredPercent GP_Perc;
        public ReportTotalColored Net;
        public ReportTotalColoredPercent Net_Perc;

        public CustomerInvoiceReportAgentSection(String caption)
            : base(caption)
        {
            ShowColumnCaptions = true;
            TotalAmount = new ReportTotalColored("");
            TotalAmount.BoldFont = false;
            TotalAmount.Caption = caption; // Agnet Name
            TotalAmount.CaptionColumn = 3;// column for Agent Name
            TotalAmount.ValueColumn = 4;
            Totals.Add(TotalAmount);

            //KT
            NetAmount = new ReportTotalColored("");
            NetAmount.BoldFont = false;
            NetAmount.ValueColumn = 5;
            Totals.Add(NetAmount);

            OpenBalance = new ReportTotalColored("");
            OpenBalance.BoldFont = false;
            OpenBalance.ValueColumn = 6;
            Totals.Add(OpenBalance);

            GP = new ReportTotalColored("");
            GP.BoldFont = false;
            GP.ValueColumn = 7;
            Totals.Add(GP);

            GP_Perc = new ReportTotalColoredPercent("");
            GP_Perc.BoldFont = false;
            GP_Perc.ValueColumn = 8;
            Totals.Add(GP_Perc);

            Net = new ReportTotalColored("");
            Net.BoldFont = false;
            Net.ValueColumn = 9;
            Totals.Add(Net);

            Net_Perc = new ReportTotalColoredPercent("");
            Net_Perc.BoldFont = false;
            Net_Perc.ValueColumn = 10;
            Totals.Add(Net_Perc);

            TotalCost = new ReportTotal("");
            TotalPostCost = new ReportTotal("");
        }
        public void Add(Rz5.ContextRz context, CustomerInvoiceReport report, CustomerInvoice i)
        {

            //KT this adds columns to the details section
            ReportLine l = new ReportLine();
            l.SetInc(i.Date, i.Date.ToShortDateString());
            l.SetInc(i.SalesNumber, new ItemTag("ordhed_sales", i.SalesID));
            l.SetInc(i.InvoiceNumber, new ItemTag("ordhed_invoice", i.InvoiceID));
            l.SetInc(i.CustomerName, new ItemTag("company", i.CustomerID));
            Color c = Color.Black;
            if (i.Amount < 0)
                c = Color.Red;
            l.SetInc(i.Amount, "$" + Tools.Number.MoneyFormat(i.Amount), c);
            c = Color.Black;
            //KT
            //Only subtract RMA total for orders that have some kind of net profit.
            //Per fred in situations like this, agent should only be held responsible for deductions.
            if (i.Net <= 0)
                i.NetAmount = 0;
            l.SetInc(i.NetAmount, "$" + Tools.Number.MoneyFormat(i.NetAmount), c);
            c = Color.Black;
            if (i.OpenBalance < 0)
                c = Color.Red;
            l.SetInc(i.OpenBalance, "$" + Tools.Number.MoneyFormat(i.OpenBalance), c);
            c = Color.Black;
            if (i.GP < 0)
            {
                c = Color.Red;
            }
            l.SetInc(i.GP, "$" + Tools.Number.MoneyFormat(i.GP), c);
            string h = Math.Round(i.GP_Perc, 1).ToString();
            if (!h.Contains("."))
                h += ".0";
            c = Color.Black;
            if (i.GP_Perc < 0)
                c = Color.Red;
            l.SetInc(i.GP_Perc, h + "%", c);
            c = Color.Black;
            if (i.Net < 0)
                c = Color.Red;
            l.SetInc(i.Net, "$" + Tools.Number.MoneyFormat(i.Net), c);
            h = Math.Round(i.Net_Perc, 1).ToString();
            if (!h.Contains("."))
                h += ".0";
            c = Color.Black;
            if (i.Net_Perc < 0)
                c = Color.Red;
            l.SetInc(i.Net_Perc, h + "%", c);
            l.SetInc(i.Rep);
            Lines.Add(l);
            report.TotalAmount.Value += i.Amount;
            //KT - 5-20-2016 Had an error here subtracting TotalAmount, which was 0, causinng this to always be zero.  i.Amount works better.


            report.NetAmount.Value += i.NetAmount;
            report.TotalCost.Value += i.Cost;
            report.TotalPostCost.Value += i.PostCost;
            report.OpenBalance.Value += i.OpenBalance;
            report.GP.Value += i.GP;


            report.GP_Perc.Value = 0;
            //if (report.TotalAmount.Value > 0)
            //    report.GP_Perc.Value = Math.Round((report.GP.Value / report.TotalAmount.Value) * 100, 1);
            report.GP_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(report.GP.Value, report.TotalCost.Value);

            report.Net.Value += i.Net;


            report.Net_Perc.Value = 0;
            //if (report.TotalCost.Value > 0)
            //    report.Net_Perc.Value = Math.Round((report.Net.Value / report.TotalCost.Value) * 100, 1);
            report.Net_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(report.Net.Value, report.TotalPostCost.Value);


            TotalAmount.Value += i.Amount;
            //KT
            NetAmount.Value += i.NetAmount;
            TotalCost.Value += i.Cost;
            TotalPostCost.Value += i.PostCost;
            OpenBalance.Value += i.OpenBalance;
            GP.Value += i.GP;


            GP_Perc.Value = 0;
            //if (TotalAmount.Value > 0)
            //    GP_Perc.Value = Math.Round((GP.Value / TotalAmount.Value) * 100, 1);
            GP_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(GP.Value, TotalCost.Value);


            Net.Value += i.Net;


            Net_Perc.Value = 0;
            //if (TotalCost.Value > 0)
            //    Net_Perc.Value = Math.Round((Net.Value / TotalCost.Value) * 100, 1);
            Net_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(Net.Value, TotalPostCost.Value);

            foreach (ordhed_rma r in context.Sys.TheOrderLogic.GetRelatedRMAs(context, ordhed_invoice.GetById(context, i.InvoiceID)))//Add related rma's in red for each invoice row
            {
                ReportLine ret = new ReportLine();
                ret.ForeColor = Color.Red;
                report.Set(ret, "NetAmount", "(RMA#" + r.ordernumber + ")   -" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(r.ordertotal));
                Lines.Add(ret);
            }

        }

    }


    public class CustomerInvoiceReportCompanySection : ReportSection
    {
        //Public Variables
        public ReportTotalColored TotalAmount;
        public ReportTotal TotalCost;
        public ReportTotal TotalPostCost;
        public ReportTotalColored OpenBalance;
        public ReportTotalColored GP;
        public ReportTotalColoredPercent GP_Perc;
        public ReportTotalColored Net;
        public ReportTotalColoredPercent Net_Perc;

        public CustomerInvoiceReportCompanySection(String caption)
            : base(caption)
        {
            ShowColumnCaptions = true;
            TotalAmount = new ReportTotalColored("");
            TotalAmount.BoldFont = false;
            TotalAmount.Caption = caption;
            TotalAmount.CaptionColumn = 3;
            TotalAmount.ValueColumn = 4;
            Totals.Add(TotalAmount);

            OpenBalance = new ReportTotalColored("");
            OpenBalance.BoldFont = false;
            OpenBalance.ValueColumn = 5;
            Totals.Add(OpenBalance);

            GP = new ReportTotalColored("");
            GP.BoldFont = false;
            GP.ValueColumn = 6;
            Totals.Add(GP);

            GP_Perc = new ReportTotalColoredPercent("");
            GP_Perc.BoldFont = false;
            GP_Perc.ValueColumn = 7;
            Totals.Add(GP_Perc);

            Net = new ReportTotalColored("");
            Net.BoldFont = false;
            Net.ValueColumn = 8;
            Totals.Add(Net);

            Net_Perc = new ReportTotalColoredPercent("");
            Net_Perc.BoldFont = false;
            Net_Perc.ValueColumn = 9;
            Totals.Add(Net_Perc);

            TotalCost = new ReportTotal("");
            TotalPostCost = new ReportTotal("");


        }
        public void Add(Rz5.ContextRz context, CustomerInvoiceReport report, CustomerInvoice i)
        {
            ReportLine l = new ReportLine();
            l.SetInc(i.Date, i.Date.ToShortDateString());
            l.SetInc(i.SalesNumber, new ItemTag("ordhed_sales", i.SalesID));
            l.SetInc(i.InvoiceNumber, new ItemTag("ordhed_invoice", i.InvoiceID));
            l.SetInc(i.CustomerName, new ItemTag("company", i.CustomerID));
            Color c = Color.Black;
            if (i.Amount < 0)
                c = Color.Red;
            l.SetInc(i.Amount, "$" + Tools.Number.MoneyFormat(i.Amount), c);
            c = Color.Black;
            if (i.OpenBalance < 0)
                c = Color.Red;
            l.SetInc(i.OpenBalance, "$" + Tools.Number.MoneyFormat(i.OpenBalance), c);
            c = Color.Black;
            if (i.GP < 0)
                c = Color.Red;
            l.SetInc(i.GP, "$" + Tools.Number.MoneyFormat(i.GP), c);
            string h = Math.Round(i.GP_Perc, 1).ToString();
            if (!h.Contains("."))
                h += ".0";
            c = Color.Black;
            if (i.GP_Perc < 0)
                c = Color.Red;
            l.SetInc(i.GP_Perc, h + "%", c);
            c = Color.Black;
            if (i.Net < 0)
                c = Color.Red;
            l.SetInc(i.Net, "$" + Tools.Number.MoneyFormat(i.Net), c);
            h = Math.Round(i.Net_Perc, 1).ToString();
            if (!h.Contains("."))
                h += ".0";
            c = Color.Black;
            if (i.Net_Perc < 0)
                c = Color.Red;
            l.SetInc(i.Net_Perc, h + "%", c);
            l.SetInc(i.Rep);
            Lines.Add(l);
            report.TotalAmount.Value += i.Amount;
            report.TotalCost.Value += i.Cost;
            report.TotalPostCost.Value += i.PostCost;
            report.OpenBalance.Value += i.OpenBalance;
            report.GP.Value += i.GP;


            report.GP_Perc.Value = 0;
            //if (report.TotalAmount.Value > 0)
            //    report.GP_Perc.Value = Math.Round((report.GP.Value / report.TotalAmount.Value) * 100, 1);
            report.GP_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(report.GP.Value, report.TotalCost.Value);

            report.Net.Value += i.Net;


            report.Net_Perc.Value = 0;
            //if (report.TotalCost.Value > 0)
            //    report.Net_Perc.Value = Math.Round((report.Net.Value / report.TotalCost.Value) * 100, 1);
            report.Net_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(report.Net.Value, report.TotalPostCost.Value);


            TotalAmount.Value += i.Amount;
            TotalCost.Value += i.Cost;
            TotalPostCost.Value += i.PostCost;
            OpenBalance.Value += i.OpenBalance;
            GP.Value += i.GP;


            GP_Perc.Value = 0;
            //if (TotalAmount.Value > 0)
            //    GP_Perc.Value = Math.Round((GP.Value / TotalAmount.Value) * 100, 1);
            GP_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(GP.Value, TotalCost.Value);


            Net.Value += i.Net;


            Net_Perc.Value = 0;
            //if (TotalCost.Value > 0)
            //    Net_Perc.Value = Math.Round((Net.Value / TotalCost.Value) * 100, 1);
            Net_Perc.Value = context.Sys.TheOrderLogic.GetMarginNetValue(Net.Value, TotalPostCost.Value);


            foreach (ordhed_rma r in context.Sys.TheOrderLogic.GetRelatedRMAs(context, ordhed_invoice.GetById(context, i.InvoiceID)))//Add related rma's in red for each invoice row
            {
                ReportLine ret = new ReportLine();
                ret.ForeColor = Color.Red;
                report.Set(ret, "NetAmount", "(RMA#" + r.ordernumber + ")   -" + context.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(r.ordertotal));
                Lines.Add(ret);
            }

        }
    }
    public class CustomerInvoiceReportArgs : ReportArgs
    {
        public ReportCriteriaDateRange Date;
        public ReportCriteriaAgentMany Agent;
        public ReportCriteriaRadio Group;
        public ReportCriteriaBoolean ShippedOnly;

        public CustomerInvoiceReportArgs(Rz5.ContextRz context)
            : base(context)
        {
            Date = new ReportCriteriaDateRange("Invoice Date");
            Date.DefaultOption = "This Month";
            Criteria.Add(Date);
            //if (context.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
            //if (context.CheckPermit("ViewAllUsersOnReports") || context.xUser.SuperUser)
            if (context.xUser.CheckPermit(context, "ViewAllUsersOnReports") || context.xUser.SuperUser)
            //if (context.xUser.SuperUser)
            {
                Agent = new ReportCriteriaAgentMany("Agent");
                Criteria.Add(Agent);
            }



            List<string> l = new List<string>();
            l.Add("Agent");
            l.Add("Company");
            Group = new ReportCriteriaRadio("Group By", l);
            Group.SelectedCaption = "Agent";
            Criteria.Add(Group);



            ShippedOnly = new ReportCriteriaBoolean("Only Shipped Lines", "Showing only shipped lines.", " Showing shipped and unshipped lines");
            ShippedOnly.Value = true;
            Criteria.Add(ShippedOnly);


        }
    }
    public class ReportTotalColored : ReportTotal
    {
        public Color TheColor = Color.Black;
        public override Color Color
        {
            get
            {
                return TheColor;
            }
        }

        public ReportTotalColored(String caption)
            : base(caption)
        {
        }
    }
    public class ReportTotalColoredPercent : ReportTotalPercent
    {
        public Color TheColor = Color.Black;
        public override Color Color
        {
            get
            {
                return TheColor;
            }
        }

        public ReportTotalColoredPercent(String caption)
            : base(caption)
        {
        }
    }
}
