using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Tools.Database;
using Core;

namespace Rz5
{
    public class StockEvaluatorCore
    {
        public ReportTarget TheTarget;

        public bool bReqs = false;
        public bool bBids = false;
        public bool bSales = false;
        public bool bPurchases = false;
        public bool bInventory = false;
        public bool bStock = false;
        public bool bConsign = false;
        public bool bExcess = false;
        public bool bBuy = false;
        public bool bOnlyTotals = false;

        public ArrayList OpenRfqParts = null;
        public bool OpenRfqMode = false;
        public void SearchList(ContextRz context, String s, DataConnection data)
        {
            if (!Tools.Strings.StrExt(s))
                return;

            if( TheTarget is ReportTargetHtml )
                ((ReportTargetHtml)TheTarget).PlainStyle = true;
            string hold = Tools.Strings.ParseDelimit(s, "[", 1).Trim();
            if (hold.ToLower().StartsWith("temptable:"))
                hold = "Pasted Numbers";
            TheTarget.AddHeading(hold);

            String strSQL = "";
            String strReqIgnore = "";
            String strStockIgnore = "";
            if (s.StartsWith("OrderBatch:"))
            {
                String strBatchID = Tools.Strings.ParseDelimit(Tools.Strings.ParseDelimit(s, "[", 2), "]", 1).Trim();
                strSQL = "select max(linecode) as linecode, fullpartnumber, sum(isnull(target_quantity, 0)) as [quantity] from orddet_quote where base_dealheader_uid = '" + strBatchID + "' group by fullpartnumber order by linecode, fullpartnumber";
                strReqIgnore = " and base_dealheader_uid <> '" + strBatchID + "'";
            }
            else if (Tools.Strings.StrCmp(s, "Open RFQs"))
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                sb.Append(" ( ");
                foreach (String part in OpenRfqParts)
                {
                    if (i > 0)
                        sb.Append(" or ");
                    sb.Append(" fullpartnumber like '" + data.SyntaxFilter(part) + "%' ");
                    i++;
                }
                sb.Append(" ) ");
                String strWhere = " quantity > 0 and stocktype in ('stock', 'buy', 'consign', 'consigned') and " + sb.ToString();
                long l = data.ScalarInt64("select count(*) from partrecord where " + strWhere);
                TheTarget.Comment(Tools.Number.LongFormat(l) + " " + nTools.Pluralize("Line", l));
                strSQL = "select fullpartnumber, sum(isnull(quantity, 0)) as [quantity] from partrecord where " + strWhere + " group by fullpartnumber order by fullpartnumber";
                strStockIgnore = " and quantity > 0 and stocktype in ('stock', 'buy', 'consign', 'consigned')";
            }
            else if (s.StartsWith("Part:"))
            {
                String strPart = Tools.Strings.ParseDelimit(s, ":", 2).Trim();
                if (!Tools.Strings.StrExt(strPart))
                    return;
                strSQL = "select top 1 '" + data.SyntaxFilter(strPart) + "' as fullpartnumber, 0 as quantity from partrecord";
            }
            else if (s.StartsWith("TempTable:"))
            {
                String strTable = Tools.Strings.ParseDelimit(s, ":", 2).Trim();
                if (!Tools.Strings.StrExt(strTable))
                    return;
                //strSQL = "select fullpartnumber, sum(isnull(quantity, 0)) as [quantity] from partrecord where fullpartnumber in (select fullpartnumber from " + strTable + ") group by fullpartnumber order by fullpartnumber";
                strSQL = "select fullpartnumber, cast(1 as int) as quantity from " + strTable + " group by fullpartnumber order by fullpartnumber";
            }
            else
            {
                String strWhere = "importid = '" + data.SyntaxFilter(s) + "'";
                long l = data.ScalarInt64("select count(*) from partrecord where " + strWhere);
                TheTarget.Comment(Tools.Number.LongFormat(l) + " " + nTools.Pluralize("Line", l));
                strSQL = "select fullpartnumber, sum(isnull(quantity, 0)) as [quantity] from partrecord where " + strWhere + " group by fullpartnumber order by fullpartnumber";
                strStockIgnore = " and importid <> '" + data.SyntaxFilter(s) + "'";
            }
            DataTable da = data.Select(strSQL);
            foreach (DataRow r in da.Rows)
            {
                SearchPart(context, nData.NullFilter(r["fullpartnumber"]), Tools.Data.NullFilterIntegerFromIntOrLong(r["quantity"]), strReqIgnore, strStockIgnore, data);
            }
        }

        protected virtual string GetPartComparisonSQL(String s, DataConnection data)
        {
            if (data == null)
                return "";
            return "replace(replace(replace(replace(fullpartnumber, '-', ''), '\', ''), '/', ''), ' ', '') = '" + Tools.Strings.FilterTrash(s) + "'";
        }

        protected void SearchPart(ContextRz context, String s, long q, String strReqIgnore, String strStockIgnore, DataConnection data)
        {
            if (!Tools.Strings.StrExt(s))
                return;

            bool contents = false;

            String strSQL = "";
            DataTable dReqs = null;
            DataTable dBids = null;
            DataTable dSales = null;
            DataTable dPurchases = null;
            DataTable dStock = null;
            //StringBuilder summary = new StringBuilder();
            List<SummaryLine> summary_reqs = new List<SummaryLine>();
            List<SummaryLine> summary_bids = new List<SummaryLine>();
            List<SummaryLine> summary_sales = new List<SummaryLine>();
            List<SummaryLine> summary_buys = new List<SummaryLine>();
            List<SummaryLine> summary_stock = new List<SummaryLine>();

            String strPartComparison = GetPartComparisonSQL(s, data);// "fullpartnumber = '" + data.SyntaxFilter(s) + "'";
            //if (Rz3App.xLogic.IsPhoenix)  //handled in GetPartComparisonSQL override
            //{
            //    String without_revision_prefix = "";
            //    String without_revision_basenumber = "";
            //    PartObject.ParsePartNumber(s, ref without_revision_prefix, ref without_revision_basenumber);

            //    without_revision_prefix = PartObject.StripPart(without_revision_prefix);
            //    without_revision_basenumber = PartObject.StripPart(Tools.Strings.ParseDelimit(without_revision_basenumber, " ", 1));
            //    strPartComparison = "( prefix = '" + without_revision_prefix + "' and basenumberstripped like '" + data.SyntaxFilter(without_revision_basenumber) + "%' )";
            //}

            if (!OpenRfqMode)
            {
                if (bReqs)
                {
                    strSQL = "select orderdate as [Date], companyname as [Customer], sum(target_quantity) as [Target Quantity], sum(quantityordered) as [Quote Quantity], unitprice as [Quote Price], agentname as [Agent] from orddet_quote where " + strPartComparison + " " + strReqIgnore + " group by orderdate, companyname, unitprice, agentname order by orderdate desc";
                    dReqs = data.Select(strSQL);
                    if (Tools.Data.DataTableExists(dReqs))
                    {
                        int total_quote_quantity = data.ScalarInt32("select sum(isnull(quantityordered, 0)) from orddet_quote where " + strPartComparison + " " + strReqIgnore);
                        int total_req_quantity = data.ScalarInt32("select sum(isnull(target_quantity, 0)) from orddet_quote where " + strPartComparison + " " + strReqIgnore);
                        double total_quote_volume = data.ScalarDouble("select sum(isnull(quantityordered, 0) * isnull(unitprice, 0)) from orddet_quote where " + strPartComparison + " " + strReqIgnore);
                        double average_quote_price = 0;
                        if (total_quote_quantity > 0)
                            average_quote_price = Math.Round(total_quote_volume / total_quote_quantity, 2);

                        summary_reqs.Add(new SummaryLine("Total RFQ Quantity", Tools.Number.LongFormat(total_req_quantity)));
                        if (total_quote_quantity > 0)
                            summary_reqs.Add(new SummaryLine("Total Quote Quantity", Tools.Number.LongFormat(total_quote_quantity)));
                        summary_reqs.Add(new SummaryLine("Total Quote Volume", "$" + Tools.Number.MoneyFormat(total_quote_volume)));
                        summary_reqs.Add(new SummaryLine("Average Quote Price", "$" + Tools.Number.MoneyFormat(average_quote_price)));
                        contents = true;
                    }
                }

                if (bBids)
                {
                    strSQL = "select orderdate as [Date], companyname as [Vendor], sum(target_quantity) as [Target Quantity], sum(quantityordered) as [Bid Quantity], unitprice as [Bid Price], agentname as [Agent] from orddet_rfq where " + strPartComparison + " group by orderdate, companyname, unitprice, agentname order by orderdate desc";
                    dBids = data.Select(strSQL);
                    if (Tools.Data.DataTableExists(dBids))
                    {
                        int total_bid_quantity = data.ScalarInt32("select sum(isnull(quantityordered, 0)) from orddet_rfq where " + strPartComparison);
                        double total_bid_volume = data.ScalarDouble("select sum(isnull(quantityordered, 0) * isnull(unitprice, 0)) from orddet_rfq where " + strPartComparison);
                        double average_bid_price = 0;
                        if (total_bid_quantity > 0)
                            average_bid_price = Math.Round(total_bid_volume / total_bid_quantity, 2);

                        summary_bids.Add(new SummaryLine("Total Bid Quantity", Tools.Number.LongFormat(total_bid_quantity)));
                        summary_bids.Add(new SummaryLine("Total Bid Volume", "$" + Tools.Number.MoneyFormat(total_bid_volume)));
                        summary_bids.Add(new SummaryLine("Average Bid Price", "$" + Tools.Number.MoneyFormat(average_bid_price)));
                        contents = true;
                    }
                }

                if (bSales)
                {
                    //String saletable = "orddet_line";
                    //if (Rz3App.xLogic.IsPhoenix)
                    //    saletable = "orddet_sales";

                    strSQL = "select orderdate_sales as [Date], customer_name as [Customer], sum(quantity) as [Quantity], unit_cost as [Cost], unit_price as [Price], vendor_name as [Vendor], seller_name as [Agent] from orddet_line where isnull(was_shipped, 0) = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison + " group by orderdate_sales, customer_name, unit_cost, unit_price, vendor_name, seller_name order by orderdate_sales desc";

                    dSales = data.Select(strSQL);
                    if (Tools.Data.DataTableExists(dSales))
                    {
                        int total_sale_quantity = data.ScalarInt32("select sum(isnull(quantity, 0)) from orddet_line where isnull(was_shipped, 0) = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison);
                        double total_sale_volume = data.ScalarDouble("select sum(isnull(quantity, 0) * isnull(unit_price, 0)) from orddet_line where isnull(was_shipped, 0) = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison);
                        //double total_sale_profit = data.ScalarDouble("select ( sum(isnull(quantityfilled, 0) * isnull(unitprice, 0)) - sum(isnull(quantityfilled, 0) * isnull(unitcost, 0)) ) from " + saletable + " where isnull(isvoid, 0) = 0 and " + strPartComparison);

                        double average_sale_price = 0;
                        //double average_profit = 0;

                        if (total_sale_quantity > 0)
                        {
                            average_sale_price = Math.Round(total_sale_volume / total_sale_quantity, 2);
                            //average_profit = Math.Round(total_sale_profit / total_sale_quantity, 2);
                        }

                        summary_sales.Add(new SummaryLine("Total Sale Quantity", Tools.Number.LongFormat(total_sale_quantity)));
                        summary_sales.Add(new SummaryLine("Total Sale Volume", "$" + Tools.Number.MoneyFormat(total_sale_volume)));

                        if (average_sale_price > 0)
                            summary_sales.Add(new SummaryLine("Average Sale Price", "$" + Tools.Number.MoneyFormat(average_sale_price)));

                        orddet_line lastSale = (orddet_line)context.QtO("orddet_line", "select top 1 * from orddet_line where isnull(was_shipped, 0) = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison + " order by ship_date_actual desc");
                        if (lastSale != null)
                        {
                            summary_sales.Add(new SummaryLine("Last Customer", lastSale.customer_name));
                            summary_sales.Add(new SummaryLine("Last Sale Agent", lastSale.seller_name));
                            summary_sales.Add(new SummaryLine("Last Sale Date", Tools.Dates.DateFormat(lastSale.ship_date_actual)));
                        }

                        contents = true;
                    }
                }

                if (bPurchases)
                {
                    strSQL = "select orderdate_purchase as [Date], vendor_name as [Vendor], sum(quantity) as [Quantity], unit_cost as [Cost], buyer_name as [Agent] from orddet_line where isnull(was_received, 0) = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison + " group by orderdate_purchase, vendor_name, unit_cost, buyer_name order by orderdate_purchase desc";
                    dPurchases = data.Select(strSQL);
                    if (Tools.Data.DataTableExists(dPurchases))
                    {
                        int total_buy_quantity = data.ScalarInt32("select sum(isnull(quantity, 0)) from orddet_line where was_received = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison);
                        double total_buy_volume = data.ScalarDouble("select sum(isnull(quantity, 0) * isnull(unit_cost, 0)) from orddet_line where was_received = 1 and isnull(isvoid, 0) = 0 and " + strPartComparison);
                        double average_buy_price = 0;
                        if (total_buy_quantity > 0)
                            average_buy_price = Math.Round(total_buy_volume / total_buy_quantity, 2);

                        summary_buys.Add(new SummaryLine("Total Buy Quantity", Tools.Number.LongFormat(total_buy_quantity)));
                        summary_buys.Add(new SummaryLine("Total Buy Volume", "$" + Tools.Number.MoneyFormat(total_buy_volume)));
                        summary_buys.Add(new SummaryLine("Average Cost", "$" + Tools.Number.MoneyFormat(average_buy_price)));
                        contents = true;
                    }
                }
            }

            if (bInventory)
            {
                summary_stock = SummaryStock(context, data, bStock, bConsign, bExcess, bBuy, strPartComparison, strStockIgnore, ref contents, ref dStock, ref q);
            }

            if (!contents)
                return;
            TheTarget.AddHeading2(s + "   [ " + Tools.Number.LongFormat(q) + " pcs. ]");
            TheTarget.AddHeadingExtra(data, s);
            if (bOnlyTotals)
                WriteHtml("<table width=\"300px\" border=\"1\" cellpadding=\"2\" cellspacing=\"2\">");

            if (nTools.DataTableExists(dReqs))
            {
                if (bOnlyTotals)
                {
                    WriteHtml("<tr><td colspan=\"2\" bgcolor=\"FFFF99\">RFQs and Quotes</td></tr>");
                    WriteSummaries(summary_reqs);
                }
                else
                {
                    ArrayList aligns = new ArrayList();
                    aligns.Add("left");
                    aligns.Add("left");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("left");

                    ArrayList formats = new ArrayList();
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("{0:C}");
                    formats.Add("");

                    TheTarget.AddDataTable("RFQs and Quotes:", summary_reqs, dReqs, aligns, formats);
                }
            }

            if (nTools.DataTableExists(dBids))
            {
                if (bOnlyTotals)
                {
                    WriteHtml("<tr><td colspan=\"2\" bgcolor=\"FF9966\">Vendor Bids</td></tr>");
                    WriteSummaries(summary_bids);
                }
                else
                {
                    ArrayList aligns = new ArrayList();
                    aligns.Add("left");
                    aligns.Add("left");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("left");

                    ArrayList formats = new ArrayList();
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("{0:C}");
                    formats.Add("");

                    TheTarget.AddDataTable("Vendor Bids:", summary_bids, dBids, aligns, formats);
                }
            }

            if (nTools.DataTableExists(dSales))
            {
                if (bOnlyTotals)
                {
                    WriteHtml("<tr><td colspan=\"2\" bgcolor=\"99FF66\">Sales</td></tr>");
                    WriteSummaries(summary_sales);
                }
                else
                {
                    ArrayList aligns = new ArrayList();
                    aligns.Add("left");
                    aligns.Add("left");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("left");
                    aligns.Add("left");
                    
                    ArrayList formats = new ArrayList();
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("{0:C}");
                    formats.Add("{0:C}");
                    formats.Add("");
                    formats.Add("");

                    TheTarget.AddDataTable("Sales:", summary_sales, dSales, aligns, formats);
                }
            }

            if (nTools.DataTableExists(dPurchases))
            {
                if (bOnlyTotals)
                {
                    WriteHtml("<tr><td colspan=\"2\" bgcolor=\"66FFFF\">Buys</td></tr>");
                    WriteSummaries(summary_buys);
                }
                else
                {
                    ArrayList aligns = new ArrayList();
                    aligns.Add("left");
                    aligns.Add("left");
                    aligns.Add("right");
                    aligns.Add("right");
                    aligns.Add("left");

                    ArrayList formats = new ArrayList();
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("{0:C}");
                    formats.Add("");

                    TheTarget.AddDataTable("Buys:", summary_buys, dPurchases, aligns, formats);
                }
            }

            if (nTools.DataTableExists(dStock))
            {
                if (bOnlyTotals)
                {
                    WriteHtml("<tr><td colspan=\"2\" bgcolor=\"dddddd\">Inventory</td></tr>");
                    WriteSummaries(summary_stock);
                }
                else
                {
                    ArrayList aligns = new ArrayList();
                    aligns.Add("left");
                    aligns.Add("right");
                    aligns.Add("left");
                    aligns.Add("left");
                    aligns.Add("right");
                    aligns.Add("left");

                    ArrayList formats = new ArrayList();
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("");
                    formats.Add("{0:C}");

                    TheTarget.AddDataTable("Inventory:", summary_stock, dStock, aligns, formats);
                }
            }

            if (bOnlyTotals)
                WriteHtml("</table>");
        }

        protected virtual List<SummaryLine> SummaryStock(ContextRz context, DataConnection data, bool bStock, bool bConsign, bool bExcess, bool bBuy, String strPartComparison, String strStockIgnore, ref bool contents, ref DataTable dStock, ref long q)
        {
            List<SummaryLine> summary_stock = new List<SummaryLine>();

            String stocktypesin = "'none'";

            if (bStock)
                stocktypesin += ", 'stock'";
            if (bConsign)
                stocktypesin += ", 'consign', 'consigned'";
            if (bExcess)
                stocktypesin += ", 'excess'";
            if (bBuy)
                stocktypesin += ", 'buy'";

            String strSQL = "select stocktype as [Stock Type], sum(quantity) as [Quantity], manufacturer as [Manufacturer], description as [Description], cost as [Cost], companyname as [Vendor] from partrecord where quantity > 0 and stocktype in (" + stocktypesin + ") and " + strPartComparison + " " + strStockIgnore + " group by stocktype, manufacturer, description, cost, companyname order by quantity desc";
            dStock = data.Select(strSQL);
            if (Tools.Data.DataTableExists(dStock))
            {
                DataTable st = data.Select("select stocktype as [Type], sum(quantity) as [Qty] from partrecord where quantity > 0 and stocktype in (" + stocktypesin + ") and " + strPartComparison + " " + strStockIgnore + " group by stocktype order by stocktype desc");
                if (Tools.Data.DataTableExists(st))
                {
                    foreach (DataRow r in st.Rows)
                    {
                        summary_stock.Add(new SummaryLine(Tools.Strings.NiceFormat(nData.NullFilter_String(r["Type"])), Tools.Number.LongFormat(Tools.Data.NullFilterInt64(r["Qty"]))));
                        //summary_stock.Add(new SummaryLine(Tools.Strings.NiceFormat(nData.NullFilter_String(r["Type"])), Tools.Number.LongFormat(Tools.Data.NullFilterIntegerFromIntOrLong(r["Qty"]))));
                    }
                }
                contents = true;
            }
            return summary_stock;
        }

        void WriteHtml(String html)
        {
            if (TheTarget == null)
                return;
            if (!(TheTarget is ReportTargetHtml))
                return;

            ((ReportTargetHtml)TheTarget).Write(html);
        }
        void WriteSummaries(List<SummaryLine> summaries)
        {
            if (TheTarget == null)
                return;
            if (!(TheTarget is ReportTargetHtml))
                return;

            ((ReportTargetHtml)TheTarget).WriteSummaries(summaries);
        }
    }
    //public class SummaryLine
    //{
    //    public String Caption = "";
    //    public String Value = "";

    //    public SummaryLine(String caption, String value)
    //    {
    //        Caption = caption;
    //        Value = value;
    //    }
    //}
}
