using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RzWeb;
using Rz5;
using NewMethod;
using Core;
using CoreWeb;
using Rz5.Web;
using System.Drawing;
using System.Collections;
using Tools.Database;
using System.Web;

namespace RzWeb.Screens
{
    public class ImportScreenBids : ImportScreen
    {
        //Private Variables
        CoreClassHandle classHandle;
        int importCount = 0;
        dealheader TheDeal;
        company Vendor;

        //Constructors
        public ImportScreenBids(ContextRz context, dealheader d, company vendor)
            : base(context)
        {
            TheDeal = d;
            Vendor = vendor;
            classHandle = context.Sys.CoreClassGet("orddet_rfq");
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Import Bids To " + HttpUtility.HtmlEncode(TheDeal.Name) + " from " + HttpUtility.HtmlEncode(Vendor.companyname);
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "show_deal":
                    x.Show(new ShowArgs(x, TheDeal));
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        //Protected Override Functions
        protected override string Caption
        {
            get
            {
                return "Bids";
            }
        }
        protected override string IconSource
        {
            get
            {
                return "ImportParts.png";
            }
        }       
        protected override void RenderImportOptions(Core.Context x, StringBuilder sb, CoreWeb.ViewHandle viewHandle)
        {
            base.RenderImportOptions(x, sb, viewHandle);
        }
        protected override void RenderComplete(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            sb.AppendLine("<br /><br /><center><span style=\"font-size: larger\">Import Complete</span><br>");
            sb.AppendLine(Tools.Strings.PluralizePhrase("bid", importCount) + " added<br /><br />");
            sb.AppendLine("<a href=\"#\" onclick=\"" + ActionScript("'show_deal'") + "\">Click to view Order Batch</a><br />");
            sb.AppendLine("</center>");
        }
        protected override List<string> ListFieldCaptions(Context x)
        {
            List<String> ret = base.ListFieldCaptions(x);
            ret.Add("Part Number");
            ret.Add("Bid Quantity");
            ret.Add("Bid Price");
            ret.Add("Manufacturer");
            ret.Add(((ContextRz)x).DateCodeCaption);
            ret.Add("Condition");
            ret.Add("Packaging");
            ret.Add("Customer Part");
            ret.Add("Description");
            ret.Add("Category");
            return ret;
        }
        protected override void Import(Core.Context x, CoreWeb.SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            List<String> fieldsChosen = new List<string>();
            foreach (nDataColumn c in dataTable.Columns)
            {
                String selected = args.Var(c.unique_id);
                if( selected == "Ignore" )
                    continue;
                if( fieldsChosen.Contains(selected) )
                {
                    x.Leader.Tell("More than 1 column was chosen for " + selected);
                    return;
                }
                fieldsChosen.Add(selected);
            }
            if (!fieldsChosen.Contains("Part Number") || !fieldsChosen.Contains("Bid Quantity"))
            {
                x.Leader.Tell("Each import needs a part number and bid quantity column");
                return;
            }
            foreach (nDataColumn c in dataTable.Columns)
            {
                String selected = args.Var(c.unique_id);
                if (selected == "Ignore")
                    continue;
                c.p = VarValGet(selected);
            }
            try
            {
                int count = 1;
                ArrayList a = GetObjects(xrz);
                foreach (rzObjectHolder h in a)
                {
                    orddet_rfq b = (orddet_rfq)h.xObject;
                    if (Tools.Strings.StrExt(b.fullpartnumber))
                    {
                        b.AbsorbCompanyAndContact(Vendor, null);

                        b.linecode = count;
                        count++;
                        if (!Tools.Strings.StrExt(b.unique_id))
                            b.Insert(x);

                        TheDeal.VendorHalf.BidAbsorb(xrz, b);

                        //try to match it with a req
                        foreach (orddet_quote q in TheDeal.CustomerHalf.QuotesList(xrz))
                        {
                            if (Tools.Strings.StrCmp(q.fullpartnumber, b.fullpartnumber))
                            {
                                q.BidAbsorb(xrz, b);
                                break;
                            }
                        }

                        part_master.CheckEverything(xrz, b);
                        b.Update(xrz);
                    }
                }
                importCount = count;
                complete = true;
                Change();
            }
            catch (Exception ex)
            {
                x.Leader.Tell(ex.Message);
                Change();
            }
        }
        protected override CoreVarValAttribute VarValGet(String caption)
        {
            CoreVarValAttribute c = null;
            switch (caption)
            {
                case "Part Number":
                    c = classHandle.VarValGet("fullpartnumber");
                    c.Caption = "Part Number";
                    return c;
                case "Bid Quantity":
                    c = classHandle.VarValGet("quantityordered");
                    c.Caption = "Bid Quantity";
                    return c;
                case "Bid Price":
                    c = classHandle.VarValGet("unitprice");
                    c.Caption = "Bid Price";
                    return c;
                case "Manufacturer":
                    c = classHandle.VarValGet("manufacturer");
                    c.Caption = "Manufacturer";
                    return c;
                case "Date Code":
                    c = classHandle.VarValGet("datecode");
                    c.Caption = "Date Code";
                    return c;
                case "Condition":
                    c = classHandle.VarValGet("condition");
                    c.Caption = "Condition";
                    return c;
                case "Packaging":
                    c = classHandle.VarValGet("packaging");
                    c.Caption = "Packaging";
                    return c;
                case "Customer Part":
                    c = classHandle.VarValGet("internalpartnumber");
                    c.Caption = "Customer Part";
                    return c;
                case "Description":
                    c = classHandle.VarValGet("description");
                    c.Caption = "Description";
                    return c;
                case "Category":
                    c = classHandle.VarValGet("category");
                    c.Caption = "Category";
                    return c;
                default:
                    return null;
            }
        }
        public ArrayList GetObjects(ContextRz x)
        {
            ArrayList ret = new ArrayList();
            foreach (nDataRow r in dataTable.GetAllRows(x))
            {
                nObject o = (nObject)x.Item("orddet_rfq");
                if (o != null)
                {
                    rzObjectHolder h = new rzObjectHolder(o);
                    foreach (nDataColumn c in dataTable.Columns)
                    {
                        if (c.p != null)
                        {
                            String s = nData.NullFilter_String((String)r.Values[c.order]);
                            if (c.IsExtra)
                                h.AddExtraProp(c.p.Name, (String)r.Values[c.order]);
                            else
                            {
                                switch (c.p.TheFieldType)
                                {
                                    case FieldType.Double:
                                        s = s.Replace("$", "").Trim();
                                        break;
                                    case FieldType.Int32:
                                    case FieldType.Int64:
                                        s = Tools.Number.QuantityFilter(s);
                                        break;
                                }
                                o.ISet_String(c.p.Name, s, c.p.TheFieldType);
                            }
                        }
                    }
                    ret.Add(h);
                }
            }
            return ret;
        }
    }
}
