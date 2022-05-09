//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Text;
//using System.Data;

//using Core;
//using NewMethod;

//namespace Rz4
//{
//    public partial class lot_buy : lot_buy_auto
//    {

//        public bool CalculateAndReportAndShow()
//        {
//            return CalculateAndReportAndShow(null);
//        }

//        public bool CalculateAndReportAndShow(nDateRange cutoff)
//        {
//            String s = CalculateAndReport(cutoff);
//            RzApp.xMainForm.ShowHTML(s, "Lot Buy " + name);
//            return true;
//        }

//        public String CalculateAndReport()
//        {
//            return CalculateAndReport(null);
//        }

//        public String CalculateAndReport(nDateRange range)
//        {
//            String strPartWhere = partrecord_criteria;
//            if (!Tools.Strings.StrExt(strPartWhere))
//                return "no part criteria";

//            StringBuilder sb = new StringBuilder();

//            sb.Append("<h2>Lot Buy Report: " + name + " run on " + nTools.DateFormat(DateTime.Now) + "</h2><br>");
//            if (range != null)
//                sb.Append("<h3>" + range.Caption + "</h3>");
//            sb.Append("<hr><br>"); 

//            String strCount = "select count(*) from partrecord where " + strPartWhere;
//            calc_lines = xSys.xData.GetScalar_Long(strCount);

//            String strPieces = "select sum(quantity) from partrecord where " + strPartWhere;
//            calc_pieces = xSys.xData.GetScalar_Long(strPieces);

//            //calculate sales based on these lines.
//            ArrayList a = context.SelectScalarArray("select unique_id from partrecord where " + strPartWhere);
//            if (a.Count == 0)
//                return "No inventory lines were found for this lot buy.";

//            Double dblProfit = 0;

//            //show the sales
//            String strSQL = "select ";
//            strSQL += " " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordernumber, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".orderdate, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".companyname, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".fullpartnumber, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".manufacturer, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".datecode, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".quantityfilled, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".unitprice, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".unitcost, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".stockid, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".agentname, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_mc_user_uid ";
//            strSQL += " from " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + " ";
//            strSQL += " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".base_ordhed_uid ";
//            strSQL += " where " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".isvoid, 0) = 0 and " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".quantityfilled > 0 and (" + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".stockid in( " + nTools.GetIn(a) + " ) or " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".original_stock_id in( " + nTools.GetIn(a) + " ) ) ";
//            if (range != null)
//                strSQL += " and " + range.GetSQL(ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".orderdate") + " ";
//            strSQL += " group by " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordernumber, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".orderdate, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".companyname, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".fullpartnumber, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".manufacturer, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".datecode, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".quantityfilled, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".unitprice, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".unitcost, " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".stockid, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".agentname, " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_mc_user_uid ";
//            strSQL += " order by " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".orderdate ";

//            DataTable sale = xSys.xData.GetDataTable(strSQL);

//            sb.AppendLine("<br>" + Tools.Number.LongFormat(sale.Rows.Count) + " Sales<br><br>");

//            if (Tools.Data.DataTableExists(sale))
//            {
//                sb.AppendLine("<table width=\"100%\" bgcolor=\"#99CCFF\" border=0 cellpadding=5 cellspacing=1>");

//                sb.AppendLine("<tr>");
//                sb.AppendLine("<td>&nbsp;</td>");
//                sb.AppendLine("<td><font color=\"gray\">Date</font></td>");
//                sb.AppendLine("<td><font color=\"gray\">Invoice#</font></td>");
//                sb.AppendLine("<td><font color=\"gray\">Agent</font></td>");

//                sb.AppendLine("<td><font color=\"gray\">Part #</font></td>");
//                sb.AppendLine("<td><font color=\"gray\">Customer</font></td>");
//                sb.AppendLine("<td><font color=\"gray\">Manufacturer</font></td>");
//                sb.AppendLine("<td align=\"right\"><font color=\"gray\">Quantity</font></td>");
//                sb.AppendLine("<td align=\"right\"><font color=\"gray\">Unit Price</font></td>");
//                sb.AppendLine("<td nowrap align=\"right\"><font color=\"gray\">Total " + contextRz.TheSys.CurrencySymbol + " Recouped</font></td>");
//                sb.AppendLine("</tr>");



//                foreach (DataRow ds in sale.Rows)
//                {
//                    Double dblSalePrice = nData.NullFilter_Double(ds["unitprice"]);
//                    long lngQuantity = nData.NullFilter_Long(ds["quantityfilled"]);
//                    Double dblTotal = nData.NullFilter_Double(Math.Round(dblSalePrice * lngQuantity, 2));
//                    DateTime dtSale = nData.NullFilter_DateTime(ds["orderdate"]);
//                    String strSalePart = nData.NullFilter_String(ds["fullpartnumber"]);
//                    String strCustomer = nData.NullFilter_String(ds["companyname"]);
//                    String strManufacturer = nData.NullFilter_String(ds["manufacturer"]);
//                    Double dblCost = nData.NullFilter_Double(ds["unitcost"]);
//                    String strInvoiceNumber = nData.NullFilter_String(ds["ordernumber"]);
//                    String strInvoiceAgent = nData.NullFilter_String(ds["agentname"]);
//                    String strInvoiceUserID = nData.NullFilter_String(ds["base_mc_user_uid"]);

//                    dblProfit += (lngQuantity * dblSalePrice) - (lngQuantity * dblCost);

//                    sb.AppendLine("<tr>");
//                    sb.AppendLine("<td>&nbsp;&nbsp;&nbsp;</td>");
//                    sb.AppendLine("<td>" + nTools.DateFormat(dtSale) + "</td>");
//                    sb.AppendLine("<td>" + strInvoiceNumber + "&nbsp;</td>");
//                    sb.AppendLine("<td>" + strInvoiceAgent + "&nbsp;</td>");
//                    sb.AppendLine("<td>" + strSalePart + "&nbsp;</td>");
//                    sb.AppendLine("<td>" + strCustomer + "&nbsp;</td>");
//                    sb.AppendLine("<td>" + strManufacturer + "&nbsp;</td>");
//                    sb.AppendLine("<td align=\"right\">" + Tools.Number.LongFormat(lngQuantity) + "</td>");
//                    sb.AppendLine("<td align=\"right\">" + nTools.MoneyFormat_2_6(dblSalePrice) + "</td>");
//                    sb.AppendLine("<td align=\"right\"><font color=\"green\">" + nTools.MoneyFormat(dblTotal) + "</font></td>");
//                    sb.AppendLine("</tr>");
//                }                
//                sb.AppendLine("</table>");
//            }

//            calc_profit = dblProfit;
//            calc_date = DateTime.Now;
//            ISave();

//            sb.AppendLine("<br><br>Total Lines: " + Tools.Number.LongFormat(calc_lines) + "<br>Total Pieces: " + Tools.Number.LongFormat(calc_pieces) + "<br>Total Profit: " + contextRz.TheSys.CurrencySymbol + nTools.MoneyFormat(calc_profit) + "<br>");
//            return sb.ToString();
//        }

//        //Public Override Functions
//        public override void HandleAction(ActArgs args)
//        {
//            switch (args.ActionName.ToLower())
//            {
//                case "calculateandreport":
//                    CalculateAndReportAndShow();
//                    break;
//                case "reportinadaterange":
//                    DateTime start = frmChooseDate.ChooseDate(DateTime.Now.Subtract(TimeSpan.FromDays(30)), "Start Date", null);
//                    if (!Tools.Dates.DateExists(start))
//                        return;
//                    DateTime end = frmChooseDate.ChooseDate(DateTime.Now, "End Date", null);
//                    if (!Tools.Dates.DateExists(end))
//                        return;
//                    nDateRange r = new nDateRange(start, end);
//                    CalculateAndReportAndShow(r);
//                    break;
//                default:
//                    base.HandleAction(args);
//                    break;
//            }
//        }
//    }
//}
