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

namespace RzWeb.Screens
{
    public class ImportScreenReqs : ImportScreen
    {
        //Private Variables
        CoreClassHandle classHandle;
        int importCount = 0;
        dealheader TheDeal;

        //Constructors
        public ImportScreenReqs(ContextRz context, dealheader d)
            : base(context)
        {
            TheDeal = d;
            classHandle = context.Sys.CoreClassGet("orddet_quote");
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Import Requirements";
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
                return "Requirements";
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
            sb.AppendLine(Tools.Strings.PluralizePhrase("requirement record", importCount) + " added<br /><br />");
            sb.AppendLine("<a href=\"#\" onclick=\"" + ActionScript("'show_deal'") + "\">Click to view Order Batch</a><br />");
            //base.RenderComplete(x, sb, viewHandle);
            sb.AppendLine("</center>");
        }
        protected override List<string> ListFieldCaptions(Context x)
        {
            List<String> ret = base.ListFieldCaptions(x);
            ret.Add("Part Number");
            ret.Add("T.Quantity");
            ret.Add("T.Price");
            ret.Add("Manufacturer");
            ret.Add("Date Code");
            ret.Add("Condition");
            ret.Add("Packaging");
            ret.Add("Customer Part");
            ret.Add("Description");
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
            if (!fieldsChosen.Contains("Part Number") || !fieldsChosen.Contains("T.Quantity"))
            {
                x.Leader.Tell("Each import needs a part number and target quantity column");
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
                ArrayList a = GetObjects((ContextRz)x);
                foreach (rzObjectHolder h in a)
                {
                    orddet_quote q = (orddet_quote)h.xObject;
                    if (Tools.Strings.StrExt(q.fullpartnumber))
                    {
                        q.linecode = count;
                        count++;
                        if (!Tools.Strings.StrExt(q.unique_id))
                            q.Insert(x);
                        TheDeal.CustomerHalf.QuoteAbsorb((ContextRz)x, q);

                        part_master.CheckEverything(xrz, q);
                        q.Update(xrz);
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
                case "T.Quantity":
                    c = classHandle.VarValGet("target_quantity");
                    c.Caption = "T.Quantity";
                    return c;
                case "T.Price":
                    c = classHandle.VarValGet("target_price");
                    c.Caption = "T.Price";
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
                default:
                    return null;
            }
        }
        public ArrayList GetObjects(ContextRz x)
        {
            ArrayList ret = new ArrayList();
            foreach (nDataRow r in dataTable.GetAllRows(x))
            {
                nObject o = (nObject)x.Item("orddet_quote");
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
    public class rzObjectHolder
    {
        public nObject xObject;
        public SortedList ExtraProps = new SortedList();
        public rzObjectHolder(nObject x)
        {
            xObject = x;
        }
        public void AddExtraProp(String strName, String strVal)
        {
            nVar v = new nVar();
            v.variable_name = strName;
            v.variable_value = strVal;
            try
            {
                ExtraProps.Add(v.variable_name, v);
            }
            catch (Exception)
            { }
        }
        public Int64 Get_Long(String strField)
        {
            nVar v = (nVar)ExtraProps[strField];
            if (v == null)
                return 0;
            String lng = Get_String(strField);
            if (Tools.Strings.StrExt(lng))
            {
                lng = lng.Replace("k", "");
                lng = lng.Replace("pcs", "");
                lng = lng.Replace("peices", "");
                lng = lng.Replace("K", "");
                lng = lng.Replace("PCS", "");
                lng = lng.Replace("PEICES", "");
            }
            if (Tools.Strings.StrExt(lng))
                v.variable_value = lng;
            try
            {
                return Convert.ToInt64(v.variable_value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Double Get_Double(String strField)
        {
            nVar v = (nVar)ExtraProps[strField];
            if (v == null)
                return 0;
            String dbl = Get_String(strField);
            if (Tools.Strings.StrExt(dbl))
            {
                dbl = dbl.Replace("$", "");
                dbl = dbl.Replace("usd", "");
                dbl = dbl.Replace("USD", "");
            }
            if (Tools.Strings.StrExt(dbl))
                v.variable_value = dbl;
            try
            {
                return Convert.ToDouble(v.variable_value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public String Get_String(String strField)
        {
            nVar v = (nVar)ExtraProps[strField];
            if (v == null)
                return "";
            try
            {
                return Convert.ToString(v.variable_value);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
