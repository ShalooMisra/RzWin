using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RzWeb;
using Rz5;
using NewMethod;
using Core;
using CoreWeb;

namespace RzWeb.Screens
{
    public class ImportScreenCompany : ImportScreen
    {
        //Private Variables
        CoreClassHandle classHandle;
        int importCount = 0;
        String import_source = "";

        //Constructors
        public ImportScreenCompany(ContextRz context)
            : base(context)
        {
            classHandle = context.Sys.CoreClassGet("company");
        }
        //Protected Override functions
        public override String Title(Context x)
        {
            return "Import Company/Contacts";
        }
        protected override string Caption
        {
            get
            {
                return "Company / Contact";
            }
        }
        protected override string IconSource
        {
            get
            {
                return "ImportCompanies.png";
            }
        }
        protected override void RenderImportOptions(Core.Context x, StringBuilder sb, CoreWeb.ViewHandle viewHandle)
        {
            base.RenderImportOptions(x, sb, viewHandle);
            sb.AppendLine("<br />Source: <input name=\"ctl_sourceName\" type=\"text\" value=\"" + import_source + "\" size=\"45\" /><br />Optionally add a source for this information");
        }
        protected override void RemoveRow(Context x, SpotActArgs args)
        {
            import_source = args.Vars["ctl_sourcename"].ToString();
            base.RemoveRow(x, args);
        }
        protected override List<string> ListFieldCaptions(Context x)
        {
            List<String> ret = base.ListFieldCaptions(x);
            ret.Add("Company Name");
            ret.Add("Contact Name");
            ret.Add("Phone Number");
            ret.Add("Fax Number");
            ret.Add("Email Address");
            return ret;
        }
        protected override void Import(Core.Context x, CoreWeb.SpotActArgs args)
        {
            //base.Import(x, args);

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

            if (!fieldsChosen.Contains("Company Name"))
            {
                x.Leader.Tell("Each import needs a Company Name column");
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
                importCount = company.Import(xrz, dataTable, "", args.Var("sourceName"));
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
                case "Company Name":
                    c = classHandle.VarValGet("companyname");
                    c.Caption = "Company Name";
                    return c;
                case "Contact Name":
                    c = classHandle.VarValGet("primarycontact");
                    c.Caption = "Contact Name";
                    return c;
                case "Phone Number":
                    c = classHandle.VarValGet("primaryphone");
                    c.Caption = "Phone Number";
                    return c;
                case "Fax Number":
                    c = classHandle.VarValGet("primaryfax");
                    c.Caption = "Fax Number";
                    return c;
                case "Email Address":
                    c = classHandle.VarValGet("primaryemailaddress");
                    c.Caption = "Email Address";
                    return c;
                default:
                    return null;
            }
        }
        protected override void RenderComplete(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            sb.AppendLine("<br /><br /><center><span style=\"font-size: larger\">Import Complete</span><br>");
            sb.AppendLine(Tools.Strings.PluralizePhrase("company record", importCount) + " added<br />");
            base.RenderComplete(x, sb, viewHandle);
            sb.AppendLine("</center>");
        }
    }
}
