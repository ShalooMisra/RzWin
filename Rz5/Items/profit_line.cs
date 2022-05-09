using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class profit_line : profit_line_auto
    {
        //Public Variables
        public ArrayList Subtractions = new ArrayList();
        public Enums.ContactType ContactType
        {
            get
            {
                switch (abs_type.ToUpper())
                {
                    case "OEM":
                        return Enums.ContactType.OEM;
                    default:
                        return Enums.ContactType.DIST;
                }
            }
        }
        public System.Drawing.Color color
        {
            get
            {
                if (is_problem || Tools.Strings.StrCmp(order_type, "RMA") || profit < 0)
                    return System.Drawing.Color.Red;
                else if (is_stock)
                    return System.Drawing.Color.Blue;
                else
                    return System.Drawing.Color.Black;
            }
        }

        public static string CreateNewReportTable(ContextNM x)
        {
            string table = "";
            try
            {
                int count = x.TheData.SelectScalarInt32("select count(name) from dbo.sysobjects where xtype = 'U' and name like 'DailyProfitReport_%'");
                if (count >= 44) //Count starts at 0 so 45 days worth of storage
                {
                    ArrayList move = x.TheData.SelectScalarArray("select name from dbo.sysobjects where xtype = 'U' and name like 'DailyProfitReport_%' and name not in (select top 44 name from dbo.sysobjects where xtype = 'U' and name like 'DailyProfitReport_%' order by cast(replace(replace(name,'DailyProfitReport_',''),'_','/')as datetime) desc)");
                    foreach (string s in move)
                    {
                        x.TheData.TheConnection.DropTable(s);
                    }
                }
                table = "DailyProfitReport_" + DateTime.Now.ToShortDateString().Replace("/", "_").Trim();
                DataSql.StructureCheckClass(x, x.TheData.TheConnection, x.TheSys.CoreClassGet("profit_line"), table);
                return table;
            }
            catch { }
            return "";
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Updating(Context x)
        {
            //originally this wasn't included, but i don't see a reason
            base.Updating(x);
            if (Tools.Strings.StrCmp(order_type, "rma"))
                total_volume = quantity * unit_price * -1;
            else
                total_volume = quantity * unit_price;
        }

        public override String GetClipHTML(ContextNM context)
        {
            context.Reorg();
            return "";
            //n_class c = xSys.GetClassByName("profit_line");
            //if (c == null)
            //    return "";
            //StringBuilder sb = new StringBuilder();
            ////sb.Append(GetClipHeader());
            //string html = GetHTMLBlock();
            //foreach (DictionaryEntry d in c.Props.AllInOrder)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    if (p.property_order > 0)
            //    {
            //        Object o = IGet(p.name);
            //        if (o != null)
            //            html = html.Replace("[" + p.name + "]", o.ToString());
            //    }
            //}
            //sb.Append(html);
            //return sb.ToString();
        }
        //Public Functions
        public bool AbsorbLegacyRst(ContextNM context, DataRow rOrder, DataRow r)
        {
            try { user_name = nData.NullFilter_String(rOrder["agentname"]); }
            catch { }
            try { order_number = nData.NullFilter_String(rOrder["ordernumber"]); }
            catch { }
            try { the_ordhed_uid = nData.NullFilter_String(rOrder["base_ordhed_uid"]); }
            catch { }
            try { customer_name = nData.NullFilter_String(rOrder["companyname"]); }
            catch { }
            try { customer_email = nData.NullFilter_String(rOrder["companyemail"]); }
            catch { }
            try { terms = nData.NullFilter_String(rOrder["terms"]); }
            catch { }
            try { ship_via = nData.NullFilter_String(rOrder["shipvia"]); }
            catch { }
            try { customer_company_uid = nData.NullFilter_String(rOrder["companyid"]); }
            catch { }
            try { order_date = nData.NullFilter_Date(rOrder["orderdate"]); }
            catch { }
            try { the_n_user_uid = nData.NullFilter_String(rOrder["base_mc_user_uid"]); }
            catch { }
            try { order_type = nTools.NiceFormat(nData.NullFilter_String(rOrder["ordertype"])); }
            catch { }
            if (r != null)
            {
                try { vendor_name = nData.NullFilter_String(r["vendorname"]); }
                catch { }
                try { vendor_company_uid = nData.NullFilter_String(r["vendorid"]); }
                catch { }
                try { part_number = nData.NullFilter_String(r["fullpartnumber"]); }
                catch { }
                try { total_cost = nData.NullFilter_Double(r["totalcost"]); }
                catch { }
                try { total_price = nData.NullFilter_Double(r["totalprice"]); }
                catch { }
                try { profit = nData.NullFilter_Double(r["totalprofit"]); }
                catch { }
                try { unit_cost = nData.NullFilter_Double(r["unitcost"]); }
                catch { }
                try { unit_price = nData.NullFilter_Double(r["unitprice"]); }
                catch { }
                try { quantity = nData.NullFilter_Long(r["quantityfilled"]); }
                catch { }
                try { buy_type = nData.NullFilter_String(r["buytype"]); }
                catch { }
            }
            Updating(context);
            return true;
        }
        //Private Functions
        private string GetHTMLBlock()
        {
            string color = "";
            switch (order_type.ToLower().Trim())
            {
                case "invoice":
                case "sales":
                case "vendrma":
                    color = "bgcolor=\"#00CC00\"";
                    break;
                default:
                    color = "bgcolor=\"#FF0000\"";
                    break;
            }
            StringBuilder sb = new StringBuilder ();
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[order_date]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[order_type]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[order_number]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[customer_name]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[part_number]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[quantity]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[unit_price]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[unit_cost]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[total_price]&nbsp;</td>");
            sb.AppendLine("    <td width=\"4%\" " + color + ">[total_cost]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[total_volume]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[profit]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[ship_via]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[terms]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[vendor_name]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[customer_email]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_stock]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_problem]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_warning]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_priority_defense]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_commission_paid]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_paid]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[is_priority_rfq]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[buy_type]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[abs_type]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[email_domain]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[user_name]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[base_companycontact_uid]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[base_orddet_uid]&nbsp;</td>");
            sb.AppendLine("    <td width=\"3%\" " + color + ">[date_created]&nbsp;</td>");
            sb.AppendLine("  </tr>");
            return sb.ToString();
        }
    }
}

