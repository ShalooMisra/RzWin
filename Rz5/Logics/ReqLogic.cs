using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewMethod;
using Tools;

namespace Rz5
{
    public class ReqLogic
    {
        public virtual bool SendSupplierRFQs(ContextNM context, ArrayList ids)
        {
            return false;
        }
        public virtual bool ReqImportIgnoreBlankPart()
        {
            return false;
        }
        public virtual string GetCustomerTargetString(ContextRz x, orddet_quote req)
        {
            return x.TheSys.CurrencySymbol + ": " + req.target_price.ToString();
        }
        public virtual string GetQuoteTreeCaption(orddet_quote q, bool show_company)
        {
            String strHold;
            bool bq = q.IsQuoted;
            if (bq)
                strHold = "[Quote]";
            else
                strHold = "[Req]";
            if (show_company)
                strHold += " " + q.companyname;
            strHold += " Part=" + q.fullpartnumber;
            if (Tools.Strings.StrExt(q.alternatepart))
                strHold = strHold + " (" + q.alternatepart + ") ";
            if (q.target_quantity > 0)
                strHold = strHold + " Target Qty=" + Tools.Number.LongFormat(q.target_quantity);
            if (q.target_price > 0)
                strHold += " Target Price=" + nTools.MoneyFormat_2_6(q.target_price);
            if (q.quantityordered > 0)
            {
                strHold += " Quote Qty=" + Tools.Number.LongFormat(q.quantityordered);
                strHold += " Quote Price=" + nTools.MoneyFormat_2_6(q.unitprice);
            }
            if (Tools.Strings.StrExt(q.manufacturer))
                strHold = strHold + " Mfg=" + q.manufacturer;
            if (Tools.Strings.StrExt(q.description))
                strHold = strHold + " Desc=" + q.description;
            if (bq && Tools.Dates.DateExists(q.last_transmit_date))
                strHold += " Quoted " + q.last_transmit_date.Month.ToString() + "/" + q.last_transmit_date.Day.ToString();
            return strHold;
        }
        public virtual string GetRFQTreeCaption(orddet_rfq r, bool show_company)
        {
            String strHold;
            if (r.isinstock)
            {
                strHold = "[Inventory]";
                strHold += " " + r.companyname;
                strHold += " Part=" + r.fullpartnumber;
                if (Tools.Strings.StrExt(r.alternatepart))
                    strHold = strHold + " (" + r.alternatepart + ") ";
                if (Tools.Strings.StrExt(r.manufacturer))
                    strHold = strHold + " Mfg=" + r.manufacturer;
                if (Tools.Strings.StrExt(r.description))
                    strHold = strHold + " Desc=" + r.description;
                strHold += " Qty from Stock= " + Tools.Number.LongFormat(r.quantitystocked);
                if (r.unitprice > 0)
                    strHold += " Stock Cost= " + nTools.MoneyFormat_2_6(r.unitprice);
            }
            else
            {
                strHold = "[Bid]";
                strHold += " " + r.companyname;
                strHold += " Part=" + r.fullpartnumber;
                if (Tools.Strings.StrExt(r.alternatepart))
                    strHold = strHold + " (" + r.alternatepart + ") ";
                if (r.target_quantity > 0)
                    strHold += " Need Qty=" + Tools.Number.LongFormat(r.target_quantity);
                if (r.target_price > 0)
                    strHold += " Need Price=" + nTools.MoneyFormat_2_6(r.target_price);
                if (r.quantityordered > 0)
                    strHold += " Bid Qty=" + Tools.Number.LongFormat(r.quantityordered) + " Bid Price=" + nTools.MoneyFormat_2_6(r.unitprice);
                if (Tools.Strings.StrExt(r.manufacturer))
                    strHold = strHold + " Mfg=" + r.manufacturer;
                if (Tools.Strings.StrExt(r.description))
                    strHold = strHold + " Desc=" + r.description;
            }
            return strHold;
        }

        public virtual List<string> GetRequiredReqDetailProperties()
        {
            List<string> ret = new List<string>();
            ret.Add("fullpartnumber");
            ret.Add("quantityordered");
            //ret.Add("target_price");
            ret.Add("target_manufacturer");
            ret.Add("unitprice");
            ret.Add("totalprice");

            return ret;

        }



    }
}
