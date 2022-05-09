using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using NewMethod;
using Tools.Database;
using System.IO;

namespace Rz5
{
    public class PrintLogic
    {
        public virtual String GetColumnValue(n_column xColumn, LineHandle xLine)
        {
            try
            {
                Object varValue = xLine.Value(xColumn.field_name);
                if (varValue == null)
                    return "";
                return Stylizer.RenderVal(varValue, xColumn, "$");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return "";
            }
        }
        //KT - Refactored from RzSensible 2-26-2015
        public String EmailOrderTableRender(ContextRz context, Rz5.Enums.OrderType type, emailtemplate template, n_template yTemplate, ArrayList colDetails)
        {
            if (Tools.Strings.StartsWith(yTemplate.class_name, "orddet"))
            {
                if (!template.is_text)
                    return template.GetAsHTMLTableWithDescription(context, type, yTemplate, colDetails, "#E2E2E2");
                else
                    return template.GetAsTextWithDescription(context, yTemplate, colDetails);
            }
            else
                return GetAsHTMLTable(context, yTemplate, colDetails);
        }
       
        public String GetAsHTMLTable(ContextRz context, n_template t, ArrayList colIn)
        {
            return GetAsHTMLTable(context, t, colIn, "");
        }
        public String GetAsHTMLTable(ContextRz context, n_template t, ArrayList colIn, String strColor)
        {
            if (Tools.Strings.StrExt(strColor))
                return GetAsHTMLTable(context, t, colIn, "<font color=\"" + strColor + "\">", "</font>", "<font color=\"" + strColor + "\">", "</font>");
            else
                return GetAsHTMLTable(context, t, colIn, "", "", "", "");
        }
        public String GetAsHTMLTable(ContextRz context, n_template t, ArrayList colIn, String beforevalueheader, String aftervalueheader, String beforevalueline, String aftervalueline)
        {
            SortedList colColumns = t.GetColumns(context);
            StringBuilder strHTML = new StringBuilder();

            strHTML.AppendLine("<table class=\"RzDetailTable\" border=\"0\" width=\"100%\">");
            strHTML.AppendLine("<tr>");
            n_column xColumn;
            foreach (DictionaryEntry d in colColumns)
            {
                xColumn = (n_column)d.Value;
                strHTML.Append("<th align=\"left\">");  //td

                strHTML.Append(beforevalueheader);

                strHTML.Append("<b>" + xColumn.column_caption + "</b>");

                strHTML.Append(aftervalueheader);

                strHTML.Append("</td>");
            }

            strHTML.AppendLine("</tr>");

            foreach (nObject xObject in colIn)
            {
                strHTML.AppendLine("<tr>");
                foreach (DictionaryEntry d in colColumns)
                {
                    xColumn = (n_column)d.Value;
                    if (xColumn.is_entry_field)
                    {
                        String sv = GetColumnValue(xColumn, new LineHandleObject(context, xObject));
                        if (sv == "0")
                            sv = "";

                        if (sv == "0.00")
                            sv = "";

                        String sl = "<td><input type=\"text\" value=\"" + nTools.Replace(sv, "\"", "") + "\"></td>";
                        strHTML.AppendLine(sl);
                    }
                    else
                    {
                        if (Tools.Strings.StrExt(xColumn.column_format))
                        {
                            strHTML.AppendLine("<td>" + beforevalueline + GetColumnValue(xColumn, new LineHandleObject(context, xObject)) + aftervalueline + "</td>");
                        }
                        else
                        {
                            switch (xColumn.data_type)
                            {
                                case (Int32)FieldType.String:
                                    strHTML.AppendLine("<td>" + beforevalueline + GetColumnValue(xColumn, new LineHandleObject(context, xObject)) + aftervalueline + "</td>");
                                    break;
                                case (Int32)FieldType.Text:
                                    strHTML.AppendLine("<td>" + beforevalueline + GetColumnValue(xColumn, new LineHandleObject(context, xObject)) + aftervalueline + "</td>");
                                    break;
                                case (Int32)FieldType.Int64:
                                    strHTML.AppendLine("<td>" + beforevalueline + Tools.Number.LongFormat((long)xObject.IGet(xColumn.field_name)) + aftervalueline + "</td>");
                                    break;
                                case (Int32)FieldType.Int32:
                                    strHTML.AppendLine("<td>" + beforevalueline + Tools.Number.LongFormat((int)xObject.IGet(xColumn.field_name)) + aftervalueline + "</td>");
                                    break;
                                case (Int32)FieldType.Boolean:
                                    strHTML.AppendLine("<td>" + beforevalueline + nTools.YesNoFilter((bool)xObject.IGet(xColumn.field_name)) + aftervalueline + "</td>");
                                    break;
                                case (Int32)FieldType.Double:
                                    strHTML.AppendLine("<td>" + beforevalueline + nTools.MoneyFormat_2_6((Double)xObject.IGet(xColumn.field_name)) + aftervalueline + "</td>");
                                    break;
                                case (Int32)FieldType.DateTime:
                                    strHTML.AppendLine("<td>" + beforevalueline + nTools.DateFormat((DateTime)xObject.IGet(xColumn.field_name)) + aftervalueline + "</td>");
                                    break;
                                default:
                                    strHTML.AppendLine("<td>" + beforevalueline + "&nbsp;" + aftervalueline + "</td>");
                                    break;
                            }
                        }
                    }
                }

                strHTML.AppendLine("</tr>");
            }

            strHTML.AppendLine("</table>");
            return strHTML.ToString();
        }
        //public virtual void DescriptionFilter(ref bool blank_desc, ref String desc)
        //{
        //    //do nothing
        //}
        public virtual bool UseWrappedDescription()
        {
            return false;
        }
        public virtual string GetOrderCurrencySymbol(ContextNM x, ordhed o)
        {
            //if (x == null)
            //    return SysRz4.Context.TheSys.CurrencySymbol;
            return x.TheSys.CurrencySymbol;
        }
        public virtual bool ShouldUseDescriptExtra(nObject o, string name)
        {
            return false;
        }
        //KT - Refactored from RzSensible 2-26-2015
        public List<Rz5.orddet> DetailsListForPrint(Rz5.ContextRz context, Rz5.ordhed o, bool consolidate_if_possible, String template_name)
        {
            List<Rz5.orddet> ret;
            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Quote:
                    {
                        ordhed_quote q = (ordhed_quote)o;
                        if (q.is_oem_product)
                        {
                            ret = DetailsListOEM_Product(context, o);
                            break;
                        }
                        else
                        {
                            if (consolidate_if_possible)
                                ret = DetailsListQuoteSummed(context, o);
                            else
                                ret = o.DetailsList(context);
                            break;
                        }

                    }

                //case Rz5.Enums.OrderType.Service:
                //    ret = ((Rz5.ordhed_service)o).ServicesAndDetailsCombine(context);
                //    break;
                default:
                    {
                        if (!Tools.Strings.HasString(template_name, "sales order") && consolidate_if_possible)
                            ret = o.DetailsListSummed(context).Where(w => w.noPrint != true).Cast<orddet>().ToList();
                        else
                            ret = o.DetailsList(context).Where(w => w.noPrint != true).Cast<orddet>().ToList();
                        //ret = ret.Where(w => w.noPrint != true).Cast<orddet>().ToList();
                       

                    }
                    
                    break;
            }
            switch (o.OrderType)
            {
                case Rz5.Enums.OrderType.Sales:
                case Rz5.Enums.OrderType.Invoice:
                    if (Tools.Strings.HasString(template_name, "invoice") || Tools.Strings.HasString(template_name, "Sales Order"))
                        CreditsAppend(context, o, ret);
                    if (Tools.Strings.HasString(template_name, "Packing Slip") || Tools.Strings.HasString(template_name, "Certificate of Conformance"))
                    {
                        List<string> invalidStatus = new List<string>();
                        invalidStatus.Add(Enums.OrderLineStatus.RMA_Received.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.RMA_Received.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.Vendor_RMA_Packing.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.Vendor_RMA_Shipped.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.Quarantined.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.Scrapped.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.Void.ToString());
                        invalidStatus.Add(Enums.OrderLineStatus.Frozen.ToString());
                        List<Rz5.orddet> validLineStatusList = new List<Rz5.orddet>();
                        foreach (orddet od in ret)
                        {
                            //Clear out existing list, and only add good lines.
                            
                            if (!invalidStatus.Contains(od.status))
                                validLineStatusList.Add(od);

                        }

                        if (validLineStatusList.Count > 0)
                            ret = validLineStatusList;
                    }
                    break;
                case Rz5.Enums.OrderType.Purchase:
                    {
                        CheckForRMAConsignmentLines(ret);
                        ChargesAppend(context, o, ret);
                        break;
                    }
                case Rz5.Enums.OrderType.VendRMA:
                    ChargesAppend(context, o, ret);
                    break;
            }
            return ret;
        }



        private void CheckForRMAConsignmentLines(List<orddet> lines)
        {
            foreach (orddet_line l in lines)
            {
                if (l.was_rma)
                    l.fullpartnumber += " - RMA";

            }
        }


       
        public List<orddet> DetailsListOEM_Product(ContextRz context, ordhed o)
        {
            List<orddet> ret = new List<orddet>();
            orddet_quote l = new Rz5.orddet_quote();
            dealheader d = dealheader.GetById(context, o.base_dealheader_uid);
            oem_product oem = oem_product.GetByName(context, d.oem_product_name);
            l.fullpartnumber = d.dealheader_name;
            l.internalpartnumber = oem.oem_product_name;
            l.quantityordered = 1;
            l.unitprice = oem.base_price;
            l.extendedorder = oem.base_price * l.quantityordered; //"Amount" column
            l.condition = "New";
            l.rohs_info = "N/A";
            l.datecode = "N/A";
            l.delivery = "3-15-2017";
            l.manufacturer = "Sensible Micro Corporation";



            ret.Add(l);
            return ret;
        }



        private List<Rz5.orddet> DetailsListQuoteSummed(Rz5.ContextRz context, Rz5.ordhed o)
        {
            List<Rz5.orddet> ret = new List<Rz5.orddet>();
            if (o == null)
                return ret;
            Dictionary<String, Rz5.orddet_quote> dict = new Dictionary<string, Rz5.orddet_quote>();
            List<Rz5.orddet> a = o.DetailsList(context);
            Rz5.orddet_quote yDetail;
            foreach (Rz5.orddet d in a)
            {
                if (!(d is Rz5.orddet_quote))
                    continue;
                Rz5.orddet_quote xDetail = (Rz5.orddet_quote)d;
                String strAll = xDetail.fullpartnumber;
                strAll = strAll.ToLower();
                if (dict.ContainsKey(strAll))
                {
                    yDetail = (Rz5.orddet_quote)dict[strAll];
                    yDetail.quantityordered += xDetail.quantityordered;
                    yDetail.Updating(context);
                }
                else
                {
                    Rz5.orddet_quote nd = (Rz5.orddet_quote)xDetail.CloneValues(context);//CloneWithNewID();
                    nd.unique_id = "<none>";
                    dict.Add(strAll, nd);
                    ret.Add(nd);
                }
            }
            return ret;
        }
        //KT - Refctored from RzSensible 2-26-2015
        private void CreditsAppend(ContextRz context, Rz5.ordhed o, List<Rz5.orddet> ret)
        {
            if (o == null)
                return;
            ArrayList hits = context.QtC("ordhit", "select * from ordhit where the_ordhed_uid = '" + o.unique_id + "'");
            if (hits == null)
                return;
            foreach (ordhit h in hits)
            {
                Double cred = Tools.Data.NullFilterDouble(h.hit_amount);
                if (cred == 0)
                    return;
                String cap = Tools.Data.NullFilterString(h.ordhit_name);
                if (!Tools.Strings.StrExt(cap))
                    cap = "Credit/Charge";
                ret.Add(context.Sys.TheOrderLogic.CreditLineForPrint(context, cap, cred));
            }
        }
        //KT - Refctored from RzSensible 2-26-2015
        protected void ChargesAppend(ContextRz context, ordhed o, List<orddet> ret)
        {
            if (o == null)
                return;
            switch (o.OrderType)
            {
                case Enums.OrderType.VendRMA:
                    {
                        AppendVendRMACharges(context, o, ret);
                        break;
                    }
                case Enums.OrderType.Purchase:
                    {
                        AppendPurchaseCharges(context, o, ret);
                        break;
                    }
            }


        }

        private void AppendPurchaseCharges(ContextRz context, ordhed o, List<orddet> ret)
        {
            ordhed_purchase p = (ordhed_purchase)o;
            foreach (profit_deduction d in p.DeductionsVar.RefsList(context))
            {
                if (d == null)
                    continue;
                if (!d.include_on_po)
                    continue;
                ret.Add(ChargeLineForPrint(context, d.name, d.amount));
            }
            //KT Get Company Credit on the Printable
            foreach (companycredit d in p.CompanyCreditVar.RefsList(context))
            {
                if (d == null)
                    continue;
                if (d.applied_to_order_uid != o.unique_id)
                    continue;
                ret.Add(CompanyCreditForPrint(context, d.description + " || Ref: PO# " + d.ordernumber, d.creditamount));
            }
        }

        private void AppendVendRMACharges(ContextRz context, ordhed o, List<orddet> ret)
        {
            ordhed_vendrma v = (ordhed_vendrma)o;
            if (v == null)
                return;
            foreach (ordhit h in context.TheSysRz.TheProfitLogic.GetInvoiceChargesList(context, v.unique_id))
            {
                if (h == null)
                    continue;
                ret.Add(ChargeLineForPrint(context, h.ordhit_name, h.hit_amount));
            }
        }
        protected orddet_line ChargeLineForPrint(ContextRz context, String caption, Double charge)
        {
            orddet_line l = orddet_line.New(context);
            l.unique_id = "not_an_id";
            l.fullpartnumber = caption;
            l.quantity = 1;
            l.unit_cost = charge;
            l.total_cost = charge;
            return l;
        }
        protected orddet_line CompanyCreditForPrint(ContextRz context, String description, Double creditamount)
        {
            orddet_line l = orddet_line.New(context);
            l.unique_id = "not_an_id";
            l.fullpartnumber = description;
            l.quantity = 1;
            l.unit_cost = creditamount;
            l.total_cost = creditamount;
            return l;
        }



    }
}
