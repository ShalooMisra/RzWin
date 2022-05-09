using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewMethod;

namespace Rz5
{
    public class Duty_CalculateStats : nDuty
    {
        ContextRz TheContext;

        public Duty_CalculateStats()
            : base("Calculate Stats", "Calculate Stats")
        {

        }
        protected override void Run(ContextNM q)
        {
            TheContext = (ContextRz)q;
            base.Run(q);
            RunReqBidSupplierStats((ContextRz)q);
            RunCompanyStats(TheContext);
            RunBestBid(TheContext);
            RunReqPotential(TheContext);
        }
        private void RunReqBidSupplierStats(ContextRz context)
        {
            context.Execute("alter table company add calc_purchase_line_count int", true);
            context.Execute("alter table company add calc_invoice_line_count int", true);
            context.Execute("alter table company add calc_purchase_volume float", true);
            context.Execute("alter table company add calc_invoice_volume float", true);
            context.Execute("alter table req add calc_last_quote datetime", true);
            context.Execute("update company set calc_vendrma_line_count = (select isnull(count(" + ordhed.MakeOrddetName(Enums.OrderType.VendRMA) + ".unique_id), 0) from " + ordhed.MakeOrddetName(Enums.OrderType.VendRMA) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.VendRMA) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.VendRMA) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.VendRMA) + ".base_ordhed_uid where " + ordhed.MakeOrdhedName(Enums.OrderType.VendRMA) + ".base_company_uid = company.unique_id and " + ordhed.MakeOrdhedName(Enums.OrderType.VendRMA) + ".ordertype = 'vendrma' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.VendRMA) + ".isvoid, 0) = 0)");
            context.Execute("update company set calc_purchase_line_count = (select isnull(count(" + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + ".unique_id), 0) from " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + ".base_ordhed_uid where " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".base_company_uid = company.unique_id and " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".ordertype = 'purchase' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".isvoid, 0) = 0)");
            context.Execute("update company set calc_invoice_line_count = (select isnull(count(" + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".unique_id), 0) from " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".base_ordhed_uid where " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_company_uid = company.unique_id and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".isvoid, 0) = 0)");
            context.Execute("update company set calc_purchase_volume = (select sum(isnull(quantityfilled, 0) * isnull(unitprice, 0)) from " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + ".base_ordhed_uid where " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + ".extendedorder > 0 and " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".base_company_uid = company.unique_id and " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".ordertype = 'purchase' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".isvoid, 0) = 0)");
            context.Execute("update company set calc_invoice_volume = (select sum(isnull(quantityfilled, 0) * isnull(unitprice, 0)) from " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".base_ordhed_uid where " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".extendedorder > 0 and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_company_uid = company.unique_id and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".isvoid, 0) = 0)");
            context.Execute("update req set calc_last_quote = (select max(quotedate) from quote where quotetype = 'giving out' and quote.companyname = req.companyname and quote.fullpartnumber = req.fullpartnumber)");
            context.Execute("update req set calc_last_quote = (select max(orderdate) from " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + " where ordertype = 'quote' and " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".companyname = req.companyname and exists(select unique_id from " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + " where " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".base_ordhed_uid = " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".unique_id and " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".fullpartnumber = req.fullpartnumber)) where calc_last_quote is null");
        }
        private void RunCompanyStats(ContextRz context)
        {
            context.Execute("update company set calc_reqs = (select count(*) from req where req.base_company_uid = company.unique_id)");
            context.Execute("update company set calc_bids = (select count(*) from quote where quotetype = 'receiving' and base_company_uid = company.unique_id)");
            context.Execute("update company set calc_qquotes = (select count(*) from quote where quotetype = 'giving out' and base_company_uid = company.unique_id)");
            context.Execute("update company set calc_fquotes = (select count(*) from " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Quote) + ".base_ordhed_uid where " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".ordertype = 'quote' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".isvoid, 0) = 0 and " + ordhed.MakeOrdhedName(Enums.OrderType.Quote) + ".base_company_uid = company.unique_id)");
            context.Execute("update company set calc_sales = (select count(*) from " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Invoice) + ".base_ordhed_uid where " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".isvoid, 0) = 0 and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_company_uid = company.unique_id)");
            context.Execute("update company set calc_purchases = (select count(*) from " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + " inner join " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + " on " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".unique_id = " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + ".base_ordhed_uid where " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".ordertype = 'purchase' and isnull(" + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".isvoid, 0) = 0 and " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".base_company_uid = company.unique_id)");
            context.Execute("update company set bids_from_reqs = (select count(*) from quote where quotetype = 'receiving' and ( reqid in (select unique_id from req where req.base_company_uid = company.unique_id) or sessionid in (select unique_id from req where req.base_company_uid = company.unique_id) ))");
            context.Execute("update company set bell_ringers = (select count(*) from req where targetprice > 0 and (select max(quoteprice) from quote where quotetype = 'receiving' and (reqid = req.unique_id or sessionid = req.unique_id)) > 0 and (select max(quoteprice) from quote where quotetype = 'receiving' and  (reqid = req.unique_id or sessionid = req.unique_id)) <= (req.targetprice * 0.9) and req.base_company_uid = company.unique_id)");
            context.Execute("update company set total_sales_amount = (select sum(ordertotal) from " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " where ordertype = 'invoice' and isnull(isvoid, 0) = 0 and base_company_uid = company.unique_id)");
            context.Execute("update company set calc_calls = (select count(*) from calllog where base_company_uid = company.unique_id)");
            context.Execute("update company set calc_notes = (select count(*) from contactnote where base_company_uid = company.unique_id)");
            context.Execute("update company set last_req_date = (select max(datecreated) from req where req.base_company_uid = company.unique_id)");
            context.Execute("update company set last_sale_date = (select max(orderdate) from " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + " where " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".ordertype = 'invoice' and " + ordhed.MakeOrdhedName(Enums.OrderType.Invoice) + ".base_company_uid = company.unique_id)");
            context.Execute("update company set last_call_date = (select max(datecall) from calllog where calllog.base_company_uid = company.unique_id)");
            context.Execute("update company set last_call_result = (select top 1 left(callresult, 255) from calllog where calllog.base_company_uid = company.unique_id order by datecall desc)");
            context.Execute("update company set last_call_notes = (select top 1 left(callnotes, 255) from calllog where calllog.base_company_uid = company.unique_id order by datecall desc)");
            context.Execute("update company set last_purchase_date = (select max(orderdate) from " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + " where " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".ordertype = 'purchase' and " + ordhed.MakeOrdhedName(Enums.OrderType.Purchase) + ".base_company_uid = company.unique_id)");
        }
        private void RunBestBid(ContextRz context)
        {
            if (!TheContext.TheData.TheConnection.FieldExists("req", "autobestbid"))
                throw new Exception("No field");

            if (!TheContext.TheData.TheConnection.FieldExists("req", "autobestbid_uid"))
                throw new Exception("No field");

            DataTable dt = TheContext.Select("select unique_id, isnull(reqid,''), min(isnull(quoteprice,0)) from quote where isnull(quoteprice,0) > 0 and quotetype = 'receiving' and reqid in (select unique_id from req) group by reqid, quoteprice, unique_id");
            if (dt == null)
                throw new Exception("Query error");

            if (dt.Rows.Count <= 0)
                return;

            foreach (DataRow dr in dt.Rows)
            {
                if (!Tools.Strings.StrExt(dr[1].ToString()))
                    continue;
                
                context.Execute("update req set autobestbid = " + dr[2].ToString() + ", autobestbid_uid = '" + dr[0].ToString() + "' where unique_id = '" + dr[1].ToString() + "'");
            }
        }
        private void RunReqPotential(ContextRz q)
        {
            String strSQL = "select req.unique_id, sum(isnull(req.targetquantity,0) * isnull(req.suppliercost,0)) as pot_1, sum(isnull(req.targetquantity,0) * isnull(req.targetprice,0)) as pot_2 from req group by req.unique_id";
            DataTable dt = q.Select(strSQL);
            if (dt != null)
            {
                Int32 count = 0;
                q.TheLeader.Comment("Found " + dt.Rows.Count + " records.");
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        count += 1;
                        String id = dr[0].ToString();
                        Double dPot1 = nData.NullFilter_Double(dr[1]);
                        Double dPot2 = nData.NullFilter_Double(dr[2]);
                        Double MainPot = 0;
                        int i = dPot1.CompareTo(dPot2);
                        switch (i)
                        {
                            case 0:
                            case 1:
                                MainPot = dPot1;
                                break;
                            case -1:
                                MainPot = dPot2;
                                break;
                        }
                        if (MainPot <= 0)
                            continue;
                        q.Execute("update req set req_potential = " + MainPot + " where unique_id = '" + id + "'");
                    }
                    catch (Exception)
                    { continue; }
                }
            }
            q.TheLeader.Comment("Done updating reqs.");
        }
    }
}
