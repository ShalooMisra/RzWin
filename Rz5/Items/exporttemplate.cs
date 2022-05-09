using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;

using Tools;
using Core;
using NewMethod;
using OfficeInterop;
using Tools.Database;

namespace Rz5
{
    public partial class exporttemplate : exporttemplate_auto
    {
        public bool IncludeStock = false;
        public bool IncludeConsign = false;
        public bool IncludeExcess = true;
        public int ConsignFactor = 0;
        public bool IncludeRQST = false;
        public bool IncludeHeaders = false;
        public String HeaderString = "";
        public bool AllExcess = false;
        public ArrayList ExcessCompanies = new ArrayList();
        public ArrayList ExcessCompaniesAsStock = new ArrayList();
        public bool AllAvail = false;
        public ArrayList AvailCompanies = new ArrayList();
        public bool IncludeManufacturer = false;
        public bool IncludeDescription = false;
        public bool IncludeDateCode = false;
        public bool IncludePartsPerPack = false;
        public bool IncludePrice = false;
        public bool IncludePackaging = false;
        public bool IncludeAlternatePart = false;
        public bool TextMode = false;

        public bool BlockAllReplacements = false;
        public bool ExcludeAvailWithoutNSN = false;
        public bool BlockNumericPrefixLogic = false;

        public String StaticStockDescription = "";
        public String StaticStockDescriptionWithCerts = "";
        public bool IncludeMFGDCWithCerts = false;
        public String StaticExcessDescription = "";
        public String StaticAvailDescription = "";
        public bool IncludeCondition = false;
        public String StaticCondition = "";
        public bool IncludeListName = false;
        public String StaticListName = "";
        public ArrayList QuantityReplacements;
        public bool AppendOnly = false;
        public bool DoNotExport = false;
        public bool ReIncludeStrippedPartNumber = false;
        public bool AppendSearchTerm = false;
        public ArrayList ColumnsInOrder = new ArrayList();
        public export_log CurrentLog;
        public bool BlankDateCode = false;
        public bool BlankPrice = true;
        public bool IgnoreExportRestrictions = false;
        public String PartCaption = "partnumber";
        public bool AppendMFGNumber = false;
        public bool VisibleToDistributors = false;
        public bool HasStockType()
        {
            if (this == null)
                return false;
            if (this.exportstock)
                return true;
            if (this.exportexcess)
                return true;
            if (this.exportconsigned)
                return true;
            return false;
        }
        public static exporttemplate NewTemplate(ContextRz x)
        {
            exporttemplate xTemplate = exporttemplate.New(x);
            xTemplate.includeheader = true;
            xTemplate.qtyabovezero = true;
            xTemplate.pnlength = true;
            xTemplate.exportstock = true;
            xTemplate.exportconsigned = true;
            xTemplate.exportexcess = true;
            xTemplate.exportname = "New Export Template (" + DateTime.Now.ToShortDateString() + ")";
            xTemplate.exportfile = "c:\\Export_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + "_" + ".csv";
            xTemplate.templatename = "";
            xTemplate.Insert(x);
            return xTemplate;
        }
        public static String GetColumnList(Boolean TFieldsFCaptions, List<n_column> l)
        {
            try
            {
                String build = "";
                if (l == null)
                    return "";
                if (l.Count <= 0)
                    return "";
                foreach (n_column c in l)
                {
                    if (Tools.Strings.StrExt(build))
                        build += ",";
                    if (TFieldsFCaptions)
                    {
                        if (Tools.Strings.StrCmp("quantity", c.field_name))
                            build += "sum(quantity - quantityallocated) as quantity";
                        else
                            build += c.field_name;
                    }
                    else
                        build += c.column_caption;
                }
                return build;
            }
            catch (Exception)
            { return ""; }
        }
        public static String GetGroupByList(List<n_column> l)
        {
            try
            {
                String build = "";
                if (l == null)
                    return "";
                if (l.Count <= 0)
                    return "";
                foreach (n_column c in l)
                {
                    if (Tools.Strings.StrExt(build))
                        build += ",";
                    build += c.field_name;
                }
                return build;
            }
            catch (Exception)
            { return ""; }
        }
        public static Boolean HasQtyField(List<n_column> l)
        {
            try
            {
                if (l == null)
                    return false;
                if (l.Count <= 0)
                    return false;
                foreach (n_column c in l)
                {
                    if (Tools.Strings.StrCmp(c.field_name, "quantity"))
                        return true;
                }
                return false;
            }
            catch { }
            return false;
        }





        public static String GetImportException(ContextRz x, List<string> l)
        {
            String build = "";
            foreach (string s in l)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (!Tools.Strings.StrExt(build))
                    build += "'" + x.Filter(s) + "'";
                else
                    build += ", '" + x.Filter(s) + "'";                
            }
            if (!Tools.Strings.StrExt(build))
                return "";
            else
                return " and importid not in (" + build + ")";
        }
        public static String GetExportLists(ContextRz x, List<string> l)
        {
            String build = "";
            foreach (string s in l)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (!Tools.Strings.StrExt(build))
                    build += "'" + x.Filter(s) + "'";
                else
                    build += ", '" + x.Filter(s) + "'";
            }
            if (!Tools.Strings.StrExt(build))
                return "";
            else
                return " and importid in (" + build + ")";
        }
        public static String GetConsignException(ContextRz x, List<string> l, Boolean bOr)
        {
            String build = "";
            foreach (string s in l)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (!Tools.Strings.StrExt(build))
                    build += "'" + x.Filter(s) + "'";
                else
                    build += ", '" + x.Filter(s) + "'";
            }
            if (!Tools.Strings.StrExt(build))
                return "";
            else
                return " " + (bOr ? "or" : "and") + " importid not in (" + build + ")";
        }
        public static String GetConsignLists(ContextRz x, List<string> l, Boolean bOr)
        {
            String build = "";
            foreach (string s in l)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (!Tools.Strings.StrExt(build))
                    build += "'" + x.Filter(s) + "'";
                else
                    build += ", '" + x.Filter(s) + "'";
            }
            if (!Tools.Strings.StrExt(build))
                return "";
            else
                return " " + (bOr ? "or" : "and") + " importid in (" + build + ")";
        }


        public String GetExportWhere(ContextRz x, List<string> export_list, List<string> export_exception_list, List<string> consign_list, List<string> consign_exception_list)
        {
            String sWhere = "";
            if (!HasStockType())
                return "";
            if (Tools.Strings.StrExt(exportonly) || Tools.Strings.StrExt(exportonly_consign))
                return GetExportWhereException(x, export_list, consign_list);
            String build = "";
            if (exportstock)
                build = "'stock'";
            if (exportexcess)
            {
                if (Tools.Strings.StrExt(build))
                    build += ", 'oem', 'excess'";
                else
                    build = "'oem', 'excess'";
            }
            if (exportconsigned)
            {
                if (Tools.Strings.StrExt(build))
                    build += ", 'consign', 'consigned'";
                else
                    build = "'consign', 'consigned'";
            }
            sWhere = "stocktype in (" + build + ")";
            if (qtyabovezero)
                sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
            if (pnlength)
                sWhere += " and len(isnull(fullpartnumber, '')) > 2";
            String lists = "";
            if (Tools.Strings.StrExt(donotexport))
                lists += GetImportException(x, export_exception_list);
            else if (Tools.Strings.StrExt(exportonly))
                lists += GetExportLists(x, export_list);
            if (Tools.Strings.StrExt(donotexport_consign))
                lists += GetConsignException(x, consign_exception_list, Tools.Strings.StrExt(lists));
            else if (Tools.Strings.StrExt(exportonly_consign))
                lists += GetConsignLists(x, consign_list, Tools.Strings.StrExt(lists));
            sWhere += lists;
            if (exportexcess && withcost)
                sWhere += " and isnull(cost, 0) > 0";
            return sWhere;
        }
        public String GetExportWhereException(ContextRz x, List<string> export_list, List<string> consign_list)
        {
            String sWhere = "";
            if (exportstock)
            {
                sWhere = " stocktype in ('stock') ";
            }
            if (exportexcess)
            {
                if (Tools.Strings.StrExt(sWhere))
                    sWhere += " or ";
                sWhere += " (stocktype in ('oem', 'excess') ";
                sWhere += GetExportLists(x, export_list) + ") ";
            }
            if (exportconsigned)
            {
                if (Tools.Strings.StrExt(sWhere))
                    sWhere += " or ";
                sWhere += " (stocktype in ('consign', 'consigned')";
                sWhere += GetConsignLists(x, consign_list, false) + ") ";
            }
            if (qtyabovezero)
                sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
            if (pnlength)
                sWhere += " and len(isnull(fullpartnumber, '')) > 2";
            if (exportexcess && withcost)
                sWhere += " and isnull(cost, 0) > 0 ";
            return sWhere;


            //String sWhere = "";
            //if (exportstock)
            //{
            //    sWhere = " stocktype in ('stock')";
            //    if (qtyabovezero)
            //        sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
            //    if (pnlength)
            //        sWhere += " and len(isnull(fullpartnumber, '')) > 2";
            //    if (exportexcess && withcost)
            //        sWhere += " and isnull(cost, 0) > 0 ";
            //}
            //if (exportexcess)
            //{
            //    if (Tools.Strings.StrExt(sWhere))
            //        sWhere += " union select " + fieldstring + " from partrecord where ";
            //    sWhere += " stocktype in ('oem', 'excess')";
            //    if (qtyabovezero)
            //        sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
            //    if (pnlength)
            //        sWhere += " and len(isnull(fullpartnumber, '')) > 2";
            //    if (exportexcess && withcost)
            //        sWhere += " and isnull(cost, 0) > 0 ";
            //    sWhere += GetExportLists(x, export_list);
            //}
            //if (exportconsigned)
            //{
            //    if (Tools.Strings.StrExt(sWhere))
            //        sWhere += " union select " + fieldstring + " from partrecord where ";
            //    sWhere += " stocktype in ('consign', 'consigned')";
            //    if (qtyabovezero)
            //        sWhere += " and (isnull(quantity, 0) - isnull(quantityallocated, 0)) > 0";
            //    if (pnlength)
            //        sWhere += " and len(isnull(fullpartnumber, '')) > 2";
            //    if (exportexcess && withcost)
            //        sWhere += " and isnull(cost, 0) > 0 ";
            //    sWhere += GetConsignLists(x, consign_list, false);
            //}
            //return sWhere;
        }

        public virtual void SetStatus(ContextNM context, String status)
        {
            context.TheLeader.Comment(status);
        }

        public virtual String GetFileName()
        {
            if (TextMode)
                return Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + exportname + ".txt";
            else
                return Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "export_" + exportname + ".csv";
        }

        public virtual String GetStockDesignation()
        {
            return " stocktype = 'stock' ";
        }
        public virtual String GetExcessDesignation()
        {
            return "stocktype in ( 'oem', 'excess' ) ";
        }
        public virtual String GetConsignDesignation()
        {
            return "stocktype in ( 'consign', 'consigned' ) ";
        }
        public virtual String GetAvailDesignation()
        {
            return "isnull(companyname, '') > '' ";
        }
        public virtual String TempTable
        {
            get
            {
                return "temp_" + this.exportname;
            }
        }

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch(args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public void ExportTemplate(ContextRz context)
        {
            ExportTemplate(context, true);
        }
        public void ExportTemplate(ContextRz context, Boolean bShowStatus)
        {
            try
            {
                if( bShowStatus )
                    context.TheLeader.StartPopStatus();
                if(!Tools.Strings.StrExt(templatename))
                {
                    context.TheLeader.Comment("There is no column template for this export.\r\nFinished.");
                    context.TheLeader.StopPopStatus(true);
                    return;
                }
                if(!Tools.Strings.StrExt(exportfile))
                {
                    context.TheLeader.Comment("This template needs a filename to export to.\r\nFinished.");
                    context.TheLeader.StopPopStatus(true);
                    return;
                }
                if(!Tools.Strings.StrExt(exportstring))
                {
                    context.TheLeader.Comment("This template doesn't contain a SQL-Statement to export from.\r\nFinished.");
                    context.TheLeader.StopPopStatus(true);
                    return;
                }
                long number = 0;
                if (adqty)
                {
                    if (!UpdateAdvertisedQty(context))
                    {
                        context.TheLeader.Comment("There was an error in updating your advertised quantity. Export cancelled.");
                        return;
                    }
                }
                context.TheLeader.Comment("Starting Export ...");
                String SQL = exportstring;
                Int64 tot = 0;
                if( filter_dupes )
                    SQL = GetDupeFilterExportSQL(context, exportstring, ref tot);
                if(!Tools.Strings.StrExt(SQL))
                {
                    context.TheLeader.Comment("This export failed. No SQL statement was available.");
                    return;
                }
                string headers = "";
                if (includeheader)
                    headers = exportcaptions;
                if (includeheader && manualsql)
                    headers = GetSQLHeaders(context, SQL);
                DataTable d = context.TheData.Select(SQL);
                if (d == null)
                    throw new Exception("ExportCSV: datatable == null");
                context.TheData.TheConnection.ExportCSV(d, exportfile, ref number, false, headers);
                //context.TheData.TheConnection.ExportCSV(SQL, exportfile, false, headers);
                if(filter_dupes)
                {
                    Int64 n = tot - number;
                    context.TheLeader.Comment(number.ToString() + " records were exported.");
                    if( n > 0 )
                        context.TheLeader.Comment(n.ToString() + " records were duplicates and were not exported.");
                }
                else
                    context.TheLeader.Comment(number.ToString() + " records were exported.");

                context.TheLeader.Comment("Finished.");
                if( bShowStatus )
                    context.TheLeader.StopPopStatus(true);
            }
            catch(Exception ee)
            {
                context.TheLeader.Tell("There was an error exporting this list : " + ee.Message);
                if( bShowStatus )
                    context.TheLeader.StopPopStatus(true);
            }
        }



        public bool RunSimpleExport(ContextRz context, bool show)
        {
            if(exporttotext)
            {
                if( File.Exists(exportfile) )
                    File.Delete(exportfile);
                long l = 0;
                ((DataConnectionSqlServer)context.TheData.TheConnection).ExportSQLToCsv(exportstring, exportfile, ref l);
                if( show )
                    Tools.FileSystem.PopTextFile(exportfile);
            }
            else
                Tools.Data.SqlToExcel(context.TheData.TheConnection, exportstring, exportfile, show);
            return true;
        }
        //Private Functions
        private String GetSQLHeaders(ContextRz context, String SQL)
        {
            try
            {
                SQL = SQL.Replace("select", "select top 1");
                DataTable dt = context.Select(SQL);
                String header = "";
                if (dt == null)
                    return header;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (Tools.Strings.StrExt(header))
                        header += ",\"" + dc.ColumnName + "\"";
                    else
                        header = "\"" + dc.ColumnName + "\"";
                }
                return header;
            }
            catch { return ""; }
        }
        protected void InsertHeaderRow(String strFile, String strHeader)
        {
            String s = strFile + ".bak";
            Tools.OperatingSystem.MakeFileRemoved(s);
            File.Move(strFile, s);
            StreamWriter w = new StreamWriter(strFile);
            StreamReader r = new StreamReader(s);
            w.WriteLine(strHeader);
            String sl = r.ReadLine();
            while(sl != null)
            {
                if( TextMode )
                    w.WriteLine(sl.Replace("\"", ""));
                else
                    w.WriteLine(sl);
                sl = r.ReadLine();
            }
            w.Close();
            w = null;
            r.Close();
            r = null;
            Tools.OperatingSystem.MakeFileRemoved(s);
        }
        private String GetDupeFilterExportSQL(ContextRz context, String SQL, ref Int64 total)
        {
            try
            {
                String where = Tools.Strings.ParseDelimit(SQL, "where", 2).Trim();
                String select = Tools.Strings.ParseDelimit(Tools.Strings.ParseDelimit(SQL, "where", 1).Replace("select", ""), "from", 1).Trim();
                if( !Tools.Strings.StrExt(where) )
                    return "";
                if( !Tools.Strings.StrExt(select) )
                    return "";
                
                try
                {
                    context.Execute("drop table pmt_temp_inv");
                }
                catch { }

                String s = "select " + select + " into pmt_temp_inv from partrecord where " + where;
                context.Execute(s);

                total = context.SelectScalarInt64("select count(*) from pmt_temp_inv");
                String[] str = Tools.Strings.Split(select, ",");
                String build = "";
                Boolean bPart = false;
                foreach(String ss in str)
                {
                    if(Tools.Strings.StrExt(build))
                        build += ",";
                    if (ss.ToLower().StartsWith("sum(quantity"))
                    {
                        build += "max(quantity) as quantity";
                        continue;
                    }
                    if (Tools.Strings.StrCmp(ss, "fullpartnumber"))
                    {
                        bPart = true;
                        build += ss;
                    }
                    else
                        build += "max(" + ss + ") as " + ss;                    
                }
                if (!Tools.Strings.StrExt(build))
                    return "";
                s = "select " + build + " from pmt_temp_inv " + (bPart ? "group by fullpartnumber" : "");
                return s;
            }
            catch
            {
                return "";
            }
        }
        private Boolean UpdateAdvertisedQty(ContextRz context)
        {
            String table = "temp_" + Tools.Strings.GetNewID();
            String strSQL = "";
            try { context.Execute("select unique_id into " + table + " from partrecord where " + exportwhere + " and len(isnull(unique_id,'')) > 0"); }
            catch { return false; }
            strSQL = "update partrecord set ad_quantity = abs(((isnull(quantity,0)-isnull(quantityallocated,0)) + (isnull(quantity,0)-isnull(quantityallocated,0)) * " + (Convert.ToDouble(adpercent) / Convert.ToDouble(100)).ToString() + ")) where unique_id in (select unique_id from " + table + ")";
            context.Execute(strSQL);
            context.Execute("drop table " + table);
            return true;
        }
        public static n_template GetDefaultExportTemplate(ContextRz context)
        {
            try
            {
                CoreClassHandle partclass = context.Sys.CoreClassGet("partrecord");
                n_template t = n_template.New(context);
                t.class_name = "partrecord";
                t.template_name = Tools.Strings.GetNewID();
                t.Insert(context);
                //PartNumber
                n_column c = n_column.New(context);
                c.the_n_template_uid = t.unique_id;
                c.field_name = "fullpartnumber";
                c.column_alignment = 0;
                c.column_caption = "Part Number";
                c.column_format = "";
                c.column_order = 0;
                c.column_width = 34;
                c.data_type = 1;
                c.Insert(context);
                //Quantity
                c = n_column.New(context);
                c.the_n_template_uid = t.unique_id;
                c.field_name = "quantity";
                c.column_alignment = 1;
                c.column_caption = "Qty";
                c.column_format = "{0:G}";
                c.column_order = 1;
                c.column_width = 16;
                c.data_type = 3;
                c.Insert(context);
                //Manufacturer
                c = n_column.New(context);
                c.the_n_template_uid = t.unique_id;
                c.field_name = "manufacturer";
                c.column_alignment = 0;
                c.column_caption = "MFG";
                c.column_format = "";
                c.column_order = 2;
                c.column_width = 23;
                c.data_type = 1;
                c.Insert(context);
                //Date Code
                c = n_column.New(context);
                c.the_n_template_uid = t.unique_id;
                c.field_name = "datecode";
                c.column_alignment = 0;
                c.column_caption = "D/C";
                c.column_format = "";
                c.column_order = 3;
                c.column_width = 13;
                c.data_type = 1;
                c.Insert(context);
                //Condition
                c = n_column.New(context);
                c.the_n_template_uid = t.unique_id;
                c.field_name = "condition";
                c.column_alignment = 0;
                c.column_caption = "Cond";
                c.column_format = "";
                c.column_order = 4;
                c.column_width = 13;
                c.data_type = 1;
                c.Insert(context);
                return t;
            }
            catch (Exception)
            { return null; }
        }
    }
    public class QuantityReplacement
    {
        public double Multiplier;
        public long StartQuantity;
        public long EndQuantity;
        public QuantityReplacement(double mult, long start, long end)
        {
            Multiplier = mult;
            StartQuantity = start;
            EndQuantity = end;
        }
    }
}