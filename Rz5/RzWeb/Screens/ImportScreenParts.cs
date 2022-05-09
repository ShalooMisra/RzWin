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
using Tools;

namespace RzWeb.Screens
{
    public class ImportScreenParts : ImportScreen
    {
        //Private Variables
        Rz5.Enums.StockType StockType = Rz5.Enums.StockType.Stock;
        CoreClassHandle classHandle;
        int importCount = 0;
        string import_source = "";

        //Constructors
        public ImportScreenParts(ContextRz context)
            : base(context)
        {
            classHandle = context.Sys.CoreClassGet("partrecord");
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Import Inventory";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "stocktype_changed":
                    switch (args.ActionParams.ToLower().Trim())
                    {
                        case "consigned":
                            StockType = Rz5.Enums.StockType.Consign;
                            break;
                        case "excess":
                            StockType = Rz5.Enums.StockType.Excess;
                            break;
                        default:
                            StockType = Rz5.Enums.StockType.Stock;
                            break;
                    }
                    args.SourceView.ScriptsToRun.Add("$('#ctl_importName').val('[" + args.ActionParams + "] Import on " + DateTime.Now.ToString() + "');");
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
                return "Inventory";
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
            string name = "Stock";
            if (StockType == Rz5.Enums.StockType.Consign)
                name = "Consigned";
            else if (StockType == Rz5.Enums.StockType.Excess)
                name = "Excess";
            if (!Tools.Strings.StrExt(import_source))
                import_source = "[" + name + "] Import on " + DateTime.Now.ToString();
            sb.AppendLine("<br />Enter a descriptive name for this import<br />Import Id: <input id=\"ctl_importName\" name=\"ctl_importName\" type=\"text\" value=\"" + import_source + "\" size=\"45\" />");
            sb.AppendLine("<table cellpadding=\"0\" border=\"0\" cellspacing=\"0\"><tr>");
            string c = "";
            if (StockType == Rz5.Enums.StockType.Stock)
                c = " checked=\"checked\" ";
            sb.AppendLine("<td><input id=\"ctl_stock\" type=\"radio\" name=\"stocktype\" " + c + " value=\"Stock\" onclick=\"" + ActionScript("'stocktype_changed'", "'Stock'") + "\"/><label for=\"ctl_stock\" style=\"font-weight: bold; color: " + Tools.Html.GetHTMLColor(Color.Blue) + ";\">Stock&nbsp;</label></td>");
            c = "";
            if (StockType == Rz5.Enums.StockType.Consign)
                c = " checked=\"checked\" ";
            sb.AppendLine("<td><input id=\"ctl_consign\" type=\"radio\" name=\"stocktype\" " + c + " value=\"Consign\" onclick=\"" + ActionScript("'stocktype_changed'", "'Consigned'") + "\"/><label for=\"ctl_consign\" style=\"font-weight: bold; color: " + Tools.Html.GetHTMLColor(Color.Green) + ";\">Consignment&nbsp;</label></td>");
            c = "";
            if (StockType == Rz5.Enums.StockType.Excess)
                c = " checked=\"checked\" ";
            sb.AppendLine("<td><input id=\"ctl_excess\" type=\"radio\" name=\"stocktype\" " + c + " value=\"Excess\" onclick=\"" + ActionScript("'stocktype_changed'", "'Excess'") + "\"/><label for=\"ctl_excess\" style=\"font-weight: bold; color: " + Tools.Html.GetHTMLColor(Color.Red) + ";\">Excess&nbsp;</label></td>");
            sb.AppendLine("</table>");
        }
        protected override void RenderComplete(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            sb.AppendLine("<br /><br /><center><span style=\"font-size: larger\">Import Complete</span><br>");
            sb.AppendLine(Tools.Strings.PluralizePhrase("inventory record", importCount) + " added<br />");
            base.RenderComplete(x, sb, viewHandle);
            sb.AppendLine("</center>");
        }
        protected override void RemoveRow(Context x, SpotActArgs args)
        {
            import_source = args.Vars["ctl_importname"].ToString();
            base.RemoveRow(x, args);
        }
        protected override List<string> ListFieldCaptions(Context x)
        {
            List<String> ret = base.ListFieldCaptions(x);
            ret.Add("Part Number");
            ret.Add("Quantity");
            ret.Add("Manufacturer");
            ret.Add("Date Code");
            ret.Add("Description");
            ret.Add("Condition");
            ret.Add("Cost");
            ret.Add("Price");
            ret.Add("Lot Number");
            ret.Add("Location");
            ret.Add("Vendor Name");
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
                    Change();  //added to clear the spinner
                    return;
                }
                fieldsChosen.Add(selected);
            }
            if (!fieldsChosen.Contains("Part Number") || !fieldsChosen.Contains("Quantity"))
            {
                x.Leader.Tell("Each import needs a part number and quantity column");
                Change();  //added to clear the spinner
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
                ImportInventory import = new ImportInventory();
                import.CurrentType = StockType;
                string comp_id = "";
                string cont_id = "";
                if (StockType == Rz5.Enums.StockType.Excess || StockType == Rz5.Enums.StockType.Consign)
                {
                    company comp = ((LeaderWebUserRz)x.TheLeader).AskForCompany((Rz5.ContextRz)x, "Please choose a supplier below:", "");
                    if (comp == null)
                    {
                        string s = "excess";
                        if (StockType == Rz5.Enums.StockType.Consign)
                            s = "consigned";
                        x.TheLeader.Tell("You need to select a supplier when importing " + s + ".");
                        return;
                    }
                    companycontact cont = ((LeaderWebUserRz)x.TheLeader).AskForContact((Rz5.ContextRz)x, "Please choose a contact below:", "", comp.unique_id);
                    comp_id = comp.unique_id;
                    if(cont!=null)
                        cont_id = cont.unique_id;
                }
                importCount = import.RunImport(xrz, dataTable, args.Var("importName"), xrz.xUser.Name, comp_id, cont_id);
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
            switch (caption)
            {
                case "Part Number":
                    return classHandle.VarValGet("fullpartnumber");
                case "Quantity":
                    return classHandle.VarValGet("quantity");
                case "Manufacturer":
                    return classHandle.VarValGet("manufacturer");
                case "Date Code":
                    return classHandle.VarValGet("datecode");
                case "Description":
                    return classHandle.VarValGet("description");
                case "Cost":
                    return classHandle.VarValGet("cost");
                case "Price":
                    return classHandle.VarValGet("price");
                case "Lot Number":
                    return classHandle.VarValGet("lotnumber");
                case "Location":
                    return classHandle.VarValGet("location");
                case "Vendor Name":
                    return classHandle.VarValGet("vendorname");
                case "Condition":
                    return classHandle.VarValGet("condition");
                default:
                    return null;
            }
        }

        protected override void FileUploaded(ContextRz context, string fileName)
        {
            base.FileUploaded(context, fileName);

            importtemplate t = importtemplate.QtO(context, "select * from importtemplate where file_name = '" + context.Filter(fileName) + "'");
            if (t == null)
                return;

            int index = 0;
            foreach (String field in Strings.SplitList(t.templatespecs, ","))
            {
                switch (field.ToLower().Trim())
                {
                    case "":
                        break;
                    default:
                        ((nDataColumn)dataTable.Columns[index]).p = classHandle.VarValGet(field);
                        break;
                }
                index++;
            }

            if (t.do_batch)
                dataTable.DeleteFirstRow(context);
        }
    }
}
