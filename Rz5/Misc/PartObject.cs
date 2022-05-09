using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Net;

using Tools;
using NewMethod;
using Tools.Database;

namespace Rz5
{

    public class PartObject //: nObject
    {
        public static int JanLines = 9;
        public static string[,] JanArray = null;

        static PartObject()
        {
            InitJanArray();
        }

        private static String ExcludeString = "!@#$%^&*,|<>";
        public static Boolean IsPart(String PartString)
        {
            try
            {
                String strBase = "";
                String strPrefix = "";
                Boolean boolInclude = false;
                PartString = PartString.Trim().ToUpper();
                FilterSingleCharacters(PartString, ExcludeString, ref boolInclude);
                if (boolInclude)
                    return false;
                if (PartString.IndexOf(".COM") > 0)
                    return false;
                if (PartString.IndexOf(".NET") > 0)
                    return false;
                if (PartString.IndexOf("DAY") > 0)
                    return false;
                if (PartString.IndexOf("D/C") > 0)
                    return false;
                if (PartString.IndexOf("AREA") > 0)
                    return false;
                String strStart = PartString.Substring(0, 1);
                if (Tools.Strings.StrCmp(strStart, "/"))
                    return false;
                if (Tools.Strings.StrCmp(strStart, "\\"))
                    return false;
                if (NumberMix(PartString.Replace("-", "").Replace(".", "").Replace("/", "")) >= 100)
                    return false;
                if (CharCount(PartString, "\\") > 1)
                    return false;
                if (NumberMix(PartString.Replace("/", "")) >= 100)
                    return false;
                if (NumberMix(PartString.Replace("\\", "")) >= 100)
                    return false;
                if (PartString.Trim().Length == 5 && Tools.Number.IsNumeric(PartString.Trim()))
                    return false;
                PartObject.ParsePartNumber(PartString, ref strPrefix, ref strBase);
                Int64 lngNumberMix = NumberMix(PartString);
                if (strPrefix.Length >= 0 && strPrefix.Length <= 6 && strBase.Length >= 2 || (lngNumberMix > 10 && lngNumberMix < 100 && PartString.Length > 5))
                {
                    if (PartString.ToUpper().IndexOf("HTTP:") > 0 || PartString.ToUpper().IndexOf("PHONE") > 0 || PartString.ToUpper().IndexOf("$") > 0 || PartString.ToUpper().IndexOf(":") > 0 || PartString.ToUpper().IndexOf("@") > 0 || PartString.ToUpper().IndexOf("(") > 0 || PartString.ToUpper().IndexOf(")") > 0)
                        return false;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsNSN(String part, ref String result)
        {
            result = StripPart(part);
            if (result.Length != 13)
                return false;
            if (!Tools.Number.IsNumeric(result))
                return false;
            return true;
        }

        private static String FilterSingleCharacters(String strIn, String strExclude, ref Boolean boolIncludes)
        {
            boolIncludes = false;
            String strHold = strIn;
            String strProduct = "";
            Char[] ary = strHold.ToCharArray();
            foreach (char strChar in ary)
            {
                Char[] ary2 = strExclude.ToCharArray();
                foreach (char strChar2 in ary2)
                {
                    if (Tools.Strings.StrCmp(strChar.ToString(), strChar2.ToString()))
                    {
                        boolIncludes = true;
                        return strProduct;
                    }
                }
                strProduct += strChar.ToString();
            }
            return strProduct;
        }
        private static Int64 CharCount(String strIn, String strSeek)
        {
            Int64 lne = 1;
            Int64 lngCounter = 0;
            lne++;
            Char[] ary = strIn.ToCharArray();
            lne++;
            foreach (char strChar in ary)
            {
                if (Tools.Strings.StrCmp(strChar.ToString(), strSeek))
                    lngCounter++;
            }
            lne++;
            return lngCounter;
        }
        private static Int64 NumberMix(String strIn)
        {
            Int64 lngAlpha = 0;
            Int64 lngNumber = 0;
            Char[] ary = strIn.ToCharArray();
            foreach (char strChar in ary)
            {
                if (Tools.Number.IsNumeric(strChar.ToString()))
                {
                    lngNumber++;
                }
                else
                {
                    lngAlpha++;
                }
            }
            if (strIn.Length <= 0)
            {
                return 0;
            }
            Int64 returnnumb = ((lngNumber / (Int64)strIn.Length) * 100);
            return returnnumb;
        }

        public static void InitJanArray()
        {
            //be sure to set the janlines #
            //JanArray = new string[,] { { "JAN", "J" }, { "JANTX", "JTX" }, { "JTX", "" }, { "JANTXV", "JTXV" }, { "JTXV", "" }, { "JANS", "" }, { "JANTX", "JX" } };
            JanArray = new string[,]{ { "JAN", "J" }, { "JANTX", "JTX" }, { "JTX", "" }, { "JANTXV", "JTXV" }, { "JTXV", "" }, { "JANS", "" }, { "JANTX", "JX" }, { "JANTX", "SX" }, { "JANTXV", "SV" } };
        }
        public static void ParsePartNumber(IPartObject xObject)
        {
            String strPrefix = "";
            String strBase = "";
            String strStripped = "";
            PartObject.ParseStripPartNumber(xObject.fullpartnumber, ref strPrefix, ref strBase, ref strStripped);
            if( xObject.prefix != strPrefix )
                xObject.prefix = strPrefix;
            if( xObject.basenumber != strBase )
                xObject.basenumber = strBase;
            if( xObject.basenumberstripped != strStripped )
                xObject.basenumberstripped = strStripped;
            strStripped = StripPart(xObject.alternatepart);
            if( xObject.alternatepartstripped != strStripped )
                xObject.alternatepartstripped = strStripped;
        }
        public static void ParseStripPartNumber(String strPart, ref String strPrefix, ref String strBase, ref String strStripped)
        {
            ParsePartNumber(strPart, ref strPrefix, ref strBase);
            strPrefix = StripPart(strPrefix);
            strStripped = StripPart(strBase);
        }
        public static void ParsePartNumber(String strPart, ref String strPrefix, ref String strBase)
        {

            SensibleDAL.PartLogic.ParsePartNumber(strPart, ref strPrefix, ref strBase);
            //if(!Tools.Strings.StrExt(strPart))
            //{
            //    strPrefix = "";
            //    strBase = "";
            //    return;
            //}
            //int p = strPart.Length + 1;
            //for(int i = 0 ; i < 10 ; i++)
            //{
            //    int j = strPart.IndexOf(i.ToString());
            //    if( j >= 0 && j < p )
            //        p = j;
            //}
            //if(p == ( strPart.Length + 1 ))
            //{
            //    strPrefix = StripPart(strPart);
            //    strBase = "";
            //    return;
            //}
            //if(p == 0)
            //{
            //    strPrefix = "";
            //    strBase = strPart;
            //    return;
            //}
            //strPrefix = StripPart(Tools.Strings.Left(strPart, p));
            //strBase = strPart.Substring(p);
        }
        public static String GetSingleSearchLine(ContextRz context, String strField, String strPrefix, String strBase, SearchComparison comparison)
        {
           
            return GetSingleSearchLine(context, strField, strPrefix, strBase, comparison, false);
        }
        public static String GetSingleSearchLine(ContextRz context, String strField, String strPrefix, String strBase, SearchComparison comparison, bool clean)
        {
            return GetSingleSearchLine(context, strField, strPrefix, strBase, comparison, clean, "");
        }
        public static String GetSingleSearchLine(ContextRz context, String strField, String strPrefix, String strBase, SearchComparison comparison, bool clean, String tablename)
        {
            if(clean)
            {
                if(comparison != SearchComparison.Exact)
                {
                    //strField = "replace(replace(replace(replace(" + strField + ", ' ', ''), '-', ''), '/', ''), '\\', '')";
                    strPrefix = strPrefix.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\\", "");
                    strBase = strBase.Replace(" ", "").Replace("-", "").Replace("/", "").Replace("\\", "");
                }
            }
            if( Tools.Strings.StrExt(tablename) )
                tablename += ".";
            if(comparison == SearchComparison.Exact)
            {
                return " " + tablename + strField + " = '" + context.Filter(strPrefix + strBase) + "' ";
            }
            else
            {
                if(comparison == SearchComparison.Fuzzy)
                {
                    if( Tools.Strings.StrExt(strPrefix) )
                        return " " + tablename + strField + " like '%" + context.Filter(strPrefix) + "%" + context.Filter(strBase) + "%' ";
                    else
                        return " " + tablename + strField + " like '%" + context.Filter(strBase) + "%' ";
                }
                else
                {
                    if( Tools.Strings.StrExt(strPrefix) )
                        return " " + tablename + strField + " like '" + context.Filter(strPrefix) + "%" + context.Filter(strBase) + "%' ";
                    else
                        return " " + tablename + strField + " like '" + context.Filter(strBase) + "%' ";
                }
            }
        }
        public static String GetSearchLine(ContextRz context, String strPrefix, String strBase)
        {
            return GetSearchLine(context, strPrefix, strBase, SearchComparison.Normal);
        }
        public static String GetSearchLine(ContextRz context, String strPrefix, String strBase, SearchComparison comparison)
        {
            return GetSearchLine(context, strPrefix, strBase, comparison, "");
        }
        public static String GetSearchLine(ContextRz context, String strPrefix, String strBase, SearchComparison comparison, String tablename)
        {
            if( Tools.Strings.StrExt(tablename) )
                tablename += ".";
            if(comparison == SearchComparison.Exact)
            {
                return " ( " + tablename + "fullpartnumber = '" + context.Filter(strPrefix + strBase) + "' )";
            }
            else
            {
                if(comparison == SearchComparison.Fuzzy)
                {
                    if( Tools.Strings.StrExt(strPrefix) )
                        return " ( " + tablename + "prefix like '%" + context.Filter(strPrefix) + "%' and " + tablename + "basenumberstripped like '%" + context.Filter(strBase) + "%' )";
                    else
                        return " ( " + tablename + "basenumberstripped like '%" + context.Filter(strBase) + "%' )";
                }
                else
                {
                    if( Tools.Strings.StrExt(strPrefix) )
                        return " ( " + tablename + "prefix like '" + context.Filter(strPrefix) + "%' and " + tablename + "basenumberstripped like '" + context.Filter(strBase) + "%' )";
                    else
                        return " ( " + tablename + "basenumberstripped like '" + context.Filter(strBase) + "%' )";
                }
            }
        }
        public static String StripPart(String s)
        {
            return SensibleDAL.PartLogic.StripPart(s);
            //return s.Replace("-", "").Replace("\\", "").Replace("/", "").Replace(".", "").Replace("_", "").Replace(" ", "").Replace("#", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("+", "[").Replace("+", "]");
        }
        public static ArrayList GetSearchPermutations(ContextRz x, String strPart, SearchComparison comparison, bool alternatepart, bool userdef, bool simple, bool allalternates, bool replacevisual)
        {
            return GetSearchPermutations(x, strPart, comparison, alternatepart, userdef, simple, allalternates, replacevisual, "", false);
        }
        public static ArrayList GetSearchPermutations(ContextRz x, String strPart, SearchComparison comparison, bool alternatepart, bool userdef, bool simple, bool allalternates, bool replacevisual, String tablename, bool include_internal)
        {
            PartSearchParameters pars = new PartSearchParameters(strPart);
            pars.IncludeAlternatePart = alternatepart;
            pars.IncludeUserDefined = userdef;
            pars.Simple = simple;
            pars.IncludeAllAlternates = allalternates;
            pars.ReplaceVisual = replacevisual;
            pars.TheComparison = comparison;
            pars.IncludeInternalPart = include_internal;
            pars.TableName = tablename;
            return GetSearchPermutations(x, pars);
        }
        public static ArrayList GetSearchPermutations(ContextRz context, PartSearchParameters pars)
        {
            ArrayList a = new ArrayList();
            String strPrefix = "";
            String strBase = "";
            PartObject.ParsePartNumber(pars.SearchTerm, ref strPrefix, ref strBase);
            strPrefix = PartObject.StripPart(strPrefix);
            strBase = PartObject.StripPart(strBase);
            if(pars.ReplaceVisual && !pars.Simple)
            {
                String strPrefixV = nTools.ReplaceVisualAll(strPrefix);
                String strBaseV = nTools.ReplaceVisualAll(strBase);
                a.Add(GetSearchLine(context, strPrefixV, strBaseV, pars.TheComparison, pars.TableName));
            }
            else
            {
                //standard
                if( pars.Simple )
                    a.Add(strPrefix + strBase);
                else
                    a.Add(GetSearchLine(context, strPrefix, strBase, pars.TheComparison, pars.TableName));
            }
            ((SysRz5)context.xSys).ThePartLogic.GetSearchPermutationsExtra(context, pars, a, strPrefix, strBase);
            if( pars.IncludeAlternatePart )
                a.Add(GetSingleSearchLine(context, "alternatepartstripped", strPrefix, strBase, pars.TheComparison, true, pars.TableName));
            if( pars.IncludeInternalPart )
                a.Add(GetSingleSearchLine(context, "internalstripped", strPrefix, strBase, SearchComparison.Fuzzy, true, pars.TableName));
            if( pars.IncludeUserDefined )
                a.Add(GetSingleSearchLine(context, "userdata_01", strPrefix, strBase, pars.TheComparison, true, pars.TableName));
            if(pars.IncludeAllAlternates)
            {
                a.Add(GetSingleSearchLine(context, "alternatepart_01", strPrefix, strBase, pars.TheComparison, true, pars.TableName));
                a.Add(GetSingleSearchLine(context, "alternatepart_02", strPrefix, strBase, pars.TheComparison, true, pars.TableName));
                a.Add(GetSingleSearchLine(context, "alternatepart_03", strPrefix, strBase, pars.TheComparison, true, pars.TableName));
                a.Add(GetSingleSearchLine(context, "alternatepart_04", strPrefix, strBase, pars.TheComparison, true, pars.TableName));
            }
            return a;
        }
        public static String GetClipLine_Part(nObject o)
        {
            return GetClipLine_Part(o, "quantity");
        }
        public static String GetClipLine_Part(nObject o, String strQuantityField)
        {
            try
            {
                String strPart = (String)o.IGet("fullpartnumber");
                long lngQuantity = (Int64)o.IGet(strQuantityField);
                String strMFG = (String)o.IGet("manufacturer");
                String strDC = (String)o.IGet("datecode");
                String s = "";
                s += "<table border=\"1\" bordercolor=\"#C0C0C0\">";
                s += "  <tr>";
                s += "    <td align=\"center\" nowrap><b><font color=\"#C0C0C0\">Part #:</font></b></td>";
                s += "    <td align=\"center\" nowrap><b><font color=\"#C0C0C0\">Quantity:</font></b></td>";
                s += "    <td align=\"center\" nowrap><b><font color=\"#C0C0C0\">Manufacturer:</font></b></td>";
                s += "    <td align=\"center\" nowrap><b><font color=\"#C0C0C0\">Date Code:</font></b></td>";
                s += "  </tr>";
                s += "  <tr>";
                s += "    <td align=\"center\" nowrap><b>" + strPart + "&nbsp;</b></td>";
                s += "    <td align=\"center\" nowrap><b>" + Tools.Number.LongFormat(lngQuantity) + "&nbsp;</b></td>";
                s += "    <td align=\"center\" nowrap><b>" + strMFG + "&nbsp;</b></td>";
                s += "    <td align=\"center\" nowrap><b>" + strDC + "&nbsp;</b></td>";
                s += "  </tr>";
                s += "</table><br>";
                return s;
            }
            catch(Exception)
            {
                return "";
            }
        }
        public static String BuildWhere(ArrayList a)
        {
            StringBuilder sb = new StringBuilder();
            int x = 0;
            foreach(String str in a)
            {
                if( x > 0 )
                    sb.Append(" or ");
                sb.AppendLine(str);
                x++;
            }
            return sb.ToString();
        }
        public static void AddPartFields(nDataTable d)
        {
            d.AddField("fullpartnumber");
            d.AddField("prefix");
            d.AddField("basenumber");
            d.AddField("basenumberstripped");
        }
        public static void BuildPartNumber(nDataTable d)
        {
            AddPartFields(d);
            d.xData.Execute("update " + d.TableName + " set fullpartnumber = isnull(prefix, '') + isnull(basenumber, '') where isnull(fullpartnumber, '') = ''");
            nTools.StripField(d, "prefix");
            StripBaseNumber(d);
        }
        public static void ExportStockCsvFile(ContextNM context, String strSQL, String strFile)
        {
            if(System.IO.File.Exists(strFile))
            {
                context.TheLeader.Comment("Removing previous copy of " + strFile + "...");
                System.IO.File.Delete(strFile);
            }
            context.TheLeader.Comment("Selecting data...");
            DataTable d = context.Select(strSQL);
            if(!Tools.Data.DataTableExists(d))
                throw new Exception ("The SQL " + strSQL + " produced no results.");
    
            context.TheLeader.Comment("Exporting...");
            long l = 0;
            context.TheData.TheConnection.ExportCSV(d, strFile, ref l);
            context.TheLeader.Comment("Done: " + Tools.Number.LongFormat(l) + " lines exported.");
        }
        public static void ParsePartNumber(ContextRz context, nDataTable d, bool remove_bad, ref long removecount)
        {
            AddPartFields(d);
            ParsePartNumber(context, d.xData, d.TableName, "fullpartnumber", "prefix", "basenumber", remove_bad, ref removecount);
        }

        public static void ParsePartNumber(ContextRz context, DataConnectionSqlServer d, String tableName, String partField, String prefixField, String baseField, bool remove_bad, ref long removecount)
        {
            d.Execute("alter table " + tableName + " add temp_flagged int", true);
            d.Execute("update " + tableName + " set temp_flagged = -1");
            d.Execute("update " + tableName + " set temp_flagged = 0, basenumber = fullpartnumber where temp_flagged = -1 and left(fullpartnumber, 1) in ( '0', '1', '2', '3', '4', '5', '6', '7', '8', '9')");

            for(int i = 1 ; i < 101 ; i++)
            {
                int j = i + 1;
                String strSQL = "update " + tableName + " set temp_flagged = " + i.ToString() + ", basenumber = substring(fullpartnumber, " + j.ToString() + ", (len(fullpartnumber) - " + i.ToString() + ")) where temp_flagged = -1 and substring(fullpartnumber, " + i.ToString() + ", ";
                strSQL += " 1) not in ( '0', '1', '2', '3', '4', '5', '6', '7', '8', '9') and ( len(fullpartnumber) = " + i.ToString() + " or substring(FULLPARTNUMBER, " + j.ToString() + ", 1) in ( '0', '1', '2', '3',";
                strSQL += " '4', '5', '6', '7', '8', '9') )";
                d.Execute(strSQL);

                if(i > 6 && ( ( i % 5 ) == 0 ))
                {
                    if( d.ScalarInt64("select count(*) from " + tableName + " where temp_flagged = -1") == 0 )
                        break;
                }
            }
            d.Execute("update " + tableName + " set PREFIX = Left(FULLPARTNUMBER,temp_flagged) where temp_flagged > 0");
            if(remove_bad)          
                d.Execute("delete from " + tableName + " where temp_flagged = -1 ", ref removecount);

            d.Execute("update " + tableName + " set prefix = '' where prefix is null");
            d.StripField(tableName, prefixField);
            d.StripField(tableName, baseField);
            d.Execute("update " + tableName + " set basenumberstripped = basenumber");
        }
        public static void StripBaseNumber(nDataTable d)
        {
            d.xData.Execute("update " + d.TableName + " set BASENUMBERSTRIPPED = BASENUMBER");
            nTools.StripField(d, "basenumberstripped");
        }
        
        //public static bool ImportParts(nDataTable dv, Enums.StockType stocktype, companycontact contactinfo, String strAgent, String strImportID, PartImportArgs args)
        //{
        //    if( !PrepareImportParts(dv, args) )
        //        return false;

        //    if (!SetExtraImportStuff(dv, stocktype, contactinfo, strAgent, strImportID, args))
        //        return false;

        //    if (!FilterImportParts(dv, args, false))
        //        return false;

        //    return ImportFilteredParts(dv, contactinfo, stocktype, args);
        //}
        //public static bool PrepareImportParts(nDataTable dv, PartImportArgs args)
        //{
        //    //check for a part number
        //    if (!dv.HasColumnField("fullpartnumber"))
        //    {
        //        if (!dv.HasColumnField("prefix") || !dv.HasColumnField("basenumber"))
        //        {
        //            args.AddError("No valid part field combination");
        //            if (!args.Silent)
        //                context.TheLeader.Tell("Please choose either a column for the part number, or the prefix and base number separately.");
        //            return false;
        //        }
        //        else
        //        {
        //            args.PrefixBase = true;
        //        }
        //    }
        //    else
        //    {
        //        args.PrefixBase = false;
        //    }
        //    //check for a quantity
        //    if (!dv.HasColumnField("quantity"))
        //    {
        //        if (!args.IgnoreMissingQuantityField)
        //        {
        //            args.AddError("No quantity column");
        //            if (!args.Silent)
        //                context.TheLeader.Tell("Please choose the quantity column.");
        //            return false;
        //        }
        //    }
        //    dv.RemoveBlurb("?");
        //    dv.RemoveBlurb("€");
        //    dv.RemoveBlurb("xxx");
        //    //switch to table mode and set the field names
        //    dv.SetActualFieldNames();
        //    String s = "";
        //    if (!dv.FormalizeFieldTypes(args.Silent, ref s))
        //    {
        //        args.AddError("FormalizeFieldTypes failed.");
        //        return false;
        //    }
        //    if (Tools.Strings.StrExt(s))
        //        args.AddLog(s);
        //    args.ImportCount = dv.Count;
        //    args.AcceptedCount = 0;
        //    args.RejectedCount = 0;
        //    return true;
        //}
        //public static bool SetExtraImportStuff(nDataTable dv, Enums.StockType stocktype, companycontact contactinfo, String strAgent, String strImportID, PartImportArgs args)
        //{
        //    //set the stock type
        //    dv.xData.Execute("alter table " + dv.TableName + " add stocktype varchar(255)", true);
        //    if (!dv.xData.Execute("update " + dv.TableName + " set stocktype = '" + stocktype.ToString() + "' where isnull(stocktype, '') not in ('stock', 'excess', 'consign', 'buy') " + args.ExtraWhere, args.Silent))
        //        return false;
        //    //set the import id
        //    dv.xData.Execute("alter table " + dv.TableName + " add importid varchar(255)", true);
        //    if (!dv.xData.Execute("update " + dv.TableName + " set importid = '" + dv.xData.SyntaxFilter(strImportID) + "' where unique_id <> 'not an id' " + args.ExtraWhere, args.Silent))
        //        return false;
        //    if (Rz3App.xLogic.IsIconix)
        //    {
        //        dv.xData.Execute("alter table " + dv.TableName + " add pmt_sort int", true);
        //        if (!dv.xData.Execute("update " + dv.TableName + " set pmt_sort = " + args.priority.ToString(), args.Silent))
        //            return false;
        //    }
        //    //set the agent
        //    dv.xData.Execute("alter table " + dv.TableName + " add agentname varchar(255)", true);
        //    if (!dv.SetFieldIfBlank("agentname", strAgent))
        //        return false;

        //    dv.xData.Execute("alter table " + dv.TableName + " add partsetup varchar(255)", true);

        //    if (!SetContactInfo(dv, contactinfo))
        //        return false;

        //    return true;
        //}
        //public static bool ImportFilteredParts(nDataTable dv, companycontact contactinfo, Enums.StockType stocktype, PartImportArgs args)
        //{
        //    long count = 0;
        //    ArrayList a = new ArrayList();
        //    a.Add("fullpartnumber");
        //    a.Add("quantity");
        //    a.Add("prefix");
        //    a.Add("basenumber");
        //    a.Add("basenumberstripped");
        //    a.Add("datecreated");
        //    a.Add("date_created");
        //    a.Add("companycontactname");
        //    a.Add("companyemailaddress");
        //    a.Add("companyfax");
        //    a.Add("companyname");
        //    a.Add("companyphone");
        //    a.Add("base_company_uid");
        //    a.Add("base_companycontact_uid");
        //    a.Add("agentname");
        //    a.Add("stocktype");
        //    a.Add("importid");
        //    if (Rz3App.xLogic.IsIconix)
        //        a.Add("pmt_sort");
        //    //added 2009_10_27  how on earth were these missing?
        //    a.Add("description");
        //    a.Add("category");
        //    a.Add("condition");
        //    a.Add("packaging");

        //    dv.AddField("description");
        //    dv.AddField("category");
        //    dv.AddField("condition");
        //    dv.AddField("packaging");

        //    dv.AddField("cost", "float", "0");
        //    dv.AddField("price", "float", "0");
        //    dv.AddField("manufacturer");
        //    dv.AddField("datecode");
        //    dv.AddField("userdata_01");
        //    dv.AddField("userdata_02");
        //    dv.AddField("location");
        //    dv.AddField("internalcomment");

        //    a.Add("cost");
        //    a.Add("price");
        //    a.Add("manufacturer");
        //    a.Add("datecode");
        //    a.Add("userdata_01");
        //    a.Add("userdata_02");
        //    a.Add("location");
        //    a.Add("internalcomment");

        //    a.Add("partsetup");
        //    dv.AddField("partsetup");
        //    dv.SetFieldIfBlank("partsetup", "");

        //    if(StripAltParts(dv))
        //    {
        //        a.Add("alternatepart");
        //        a.Add("alternatepartstripped");
        //    }
        //    SortedList props = null;
        //    if(Tools.Strings.StrCmp(args.TableName, "offer") && !Rz3App.xLogic.IsPMT)
        //    {
        //        a.Add("contactname");
        //        a.Add("phonenumber");
        //        a.Add("faxnumber");
        //        dv.AddField("contactname");
        //        dv.AddField("phonenumber");
        //        dv.AddField("faxnumber");
        //        dv.SetFieldIfBlank("contactname", contactinfo.contactname);
        //        dv.SetFieldIfBlank("phonenumber", contactinfo.primaryphone);
        //        dv.SetFieldIfBlank("faxnumber", contactinfo.primaryfax);
        //        props = Rz3App.xSys.CoalescePropsByClass("offer");
        //        dv.ImportObjects("offer", "unique_id", props, a, ref count);
        //    }
        //    else
        //    {
        //        props = Rz3App.xSys.CoalescePropsByClass("partrecord", "", "", false, true);    //include system fields like date_created
        //        String tablename = "partrecord";
        //        if( Rz3App.xLogic.IsPMT && stocktype == Enums.StockType.Offers )
        //            tablename = "partrecord_offer";
        //        if (Rz3App.xLogic.IsAAT && stocktype == Enums.StockType.WebPart)
        //            tablename = "web_parts";
        //        dv.ImportObjects(tablename, "unique_id", props, a, ref count, args.ExtraWhere);
        //    }
        //    args.AcceptedCount = count;
        //    return true;
        //}
        //public static Boolean StripAltParts(nDataTable dv)
        //{
        //    try
        //    {
        //        if( !dv.FieldExists("alternatepart") )
        //            return false;
        //        dv.xData.Execute("alter table " + dv.TableName + " add alternatepartstripped varchar(255)", true);
        //        return dv.xData.Execute("update " + dv.TableName + " set alternatepartstripped = replace(replace(replace(alternatepart, '-', ''), '\', ''), '/', '')", true);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public static bool FilterImportParts(nDataTable dv, PartImportArgs args, bool reinsert_alternates)
        //{
        //    long count = 0;
        //    //part number
        //    if (args.PrefixBase)
        //    {
        //        PartObject.BuildPartNumber(dv);
        //        if (reinsert_alternates)
        //        {
        //            PartObject.ReInsertAlternates(dv);
        //            PartObject.ParsePartNumber(dv, args.Silent, ref count);
        //        }
        //    }
        //    else
        //    {
        //        if (reinsert_alternates)
        //            PartObject.ReInsertAlternates(dv);
        //        PartObject.ParsePartNumber(dv, args.Silent, ref count);
        //    }
        //    if (count > 0)
        //    {
        //        args.AddLog(Tools.Number.LongFormat(count) + " rows deleted by blank base number criteria.");
        //        args.RejectedCount += count;
        //    }
        //    if (!dv.CheckCriteria("have no part number", "isnull(fullpartnumber, '') = ''", args.Silent, ref count))
        //        return false;
        //    else
        //    {
        //        if (count > 0)
        //        {
        //            args.AddLog(Tools.Number.LongFormat(count) + " rows deleted by blank part number criteria.");
        //            args.RejectedCount += count;
        //        }
        //    }
        //    if (!dv.CheckCriteria("have no base number", "temp_flagged = -1", args.Silent, ref count))
        //        return false;
        //    else
        //    {
        //        if (count > 0)
        //        {
        //            args.AddLog(Tools.Number.LongFormat(count) + " rows deleted by blank base number criteria.");
        //            args.RejectedCount += count;
        //        }
        //    }
        //    if (!FilterBadPartNumbers(dv, args.Silent, ref count))
        //        return false;
        //    else
        //    {
        //        if (count > 0)
        //        {
        //            args.AddLog(Tools.Number.LongFormat(count) + " rows deleted by bad part number criteria.");
        //            args.RejectedCount += count;
        //        }
        //    }

        //    if (dv.HasColumnField("quantity"))
        //    {
        //        if (!dv.CheckCriteria("have no valid quantity", "quantity <= 0", args.Silent, ref count))
        //            return false;
        //        else
        //        {
        //            if (count > 0)
        //            {
        //                args.AddLog(Tools.Number.LongFormat(count) + " rows deleted by valid quantity criteria.");
        //                args.RejectedCount += count;
        //            }
        //        }
        //    }
        //    //datecreated
        //    dv.xData.Execute("alter table " + dv.TableName + " add datecreated datetime", true);
        //    if (!dv.xData.Execute("update " + dv.TableName + " set datecreated = getdate() where datecreated is null or isdate(datecreated) = 0 or datediff(d, datecreated, cast('01/01/1900' as datetime)) = 0", args.Silent))
        //        return false;
        //    //set the date
        //    dv.xData.Execute("alter table " + dv.TableName + " add date_created datetime", true);
        //    if (!dv.xData.Execute("update " + dv.TableName + " set date_created = getdate() where date_created is null or isdate(date_created) = 0 or datediff(d, date_created, cast('01/01/1900' as datetime)) = 0", args.Silent))
        //        return false;
        //    return true;
        //}
        //public static bool SetContactInfo(nDataTable dv, companycontact contactinfo)
        //{
        //    //set the company and contact
        //    dv.AddField("companycontactname");
        //    dv.AddField("contactname");
        //    dv.AddField("companyemailaddress");
        //    dv.AddField("companyfax");
        //    dv.AddField("companyname");
        //    dv.AddField("companyphone");
        //    dv.AddField("base_company_uid");
        //    dv.AddField("base_companycontact_uid");
        //    if(contactinfo != null)
        //    {
        //        if( !dv.SetFieldIfBlank("companycontactname", contactinfo.contactname) )
        //            return false;
        //        if (!dv.SetFieldIfBlank("contactname", contactinfo.contactname))
        //            return false;
        //        if( !dv.SetFieldIfBlank("companyemailaddress", contactinfo.primaryemailaddress) )
        //            return false;
        //        if( !dv.SetFieldIfBlank("companyfax", contactinfo.primaryfax) )
        //            return false;
        //        if( !dv.SetFieldIfBlank("companyname", contactinfo.companyname) )
        //            return false;
        //        if( !dv.SetFieldIfBlank("companyphone", contactinfo.primaryphone) )
        //            return false;
        //        if( !dv.SetFieldIfBlank("base_company_uid", contactinfo.base_company_uid) )
        //            return false;
        //        if( !dv.SetFieldIfBlank("base_companycontact_uid", contactinfo.unique_id) )
        //            return false;
        //    }
        //    return true;
        //}
        //public static bool FilterBadPartNumbers(nDataTable d, bool silent, ref long count)
        //{
        //    count = 0;
        //    String strWhere = " fullpartnumber is null or (len(fullpartnumber) < 4 and fullpartnumber like '%n%a%') or fullpartnumber = 'part number' or fullpartnumber like '%pull' or fullpartnumber like '%refurb' or fullpartnumber like '%pulls' or fullpartnumber like '%refurbs' ";
        //    if (!silent)
        //    {
        //        Int64 l = d.xData.GetScalar_Long("select count(*) from " + d.TableName + " where " + strWhere);
        //        if (l > 0)
        //        {
        //            if (!context.TheLeader.AskYesNo(Tools.Number.LongFormat(l) + " items appear to have invalid part numbers ('n/a', 'part number', etc), and will be removed.  Do you want to continue?"))
        //                return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    return d.xData.Execute("delete from " + d.TableName + " where " + strWhere, ref count);
        //}


        public static Enums.StockType ConvertStockType(String strType)
        {
            switch(strType.ToLower())
            {
                case "stock":
                    return Enums.StockType.Stock;
                case "excess":
                case "oem":
                    return Enums.StockType.Excess;
                case "consign":
                case "consigned":
                    return Enums.StockType.Consign;
                case "buy":
                    return Enums.StockType.Buy;
                case "archive":
                    return Enums.StockType.Archive;
                case "offers":
                    return Enums.StockType.Offers;
                    //KT - Had to define this enum as well as eNum.cs in ordet to get new Master parts to get properly saved as "Master" stocktype, and set color accordingly.
                case "master":
                    return Enums.StockType.Master;
                case "service":
                    return Enums.StockType.Service;
            }
            return Enums.StockType.Any;
        }
        public static Boolean IsPartPackageSetup(String sIn)
        {
            if( sIn.ToLower().StartsWith("plcc") )
                return true;
            if( sIn.ToLower().StartsWith("dip") )
                return true;
            if( sIn.ToLower().StartsWith("sop") )
                return true;
            if (sIn.ToLower().StartsWith("sot-"))
                return true;
            if (sIn.ToLower().StartsWith("to-"))
                return true;
            if (sIn.ToLower().StartsWith("qfp"))
                return true;
            if( sIn.ToLower().StartsWith("soic") )
                return true;
            if( sIn.ToLower().StartsWith("can") )
                return true;
            if( sIn.ToLower().StartsWith("smd") )
                return true;
            if( sIn.ToLower().StartsWith("bga") )
                return true;
            return false;
        }
        public static bool UploadViaEmail(ContextNM x, String strAddress, String strFiles, String strSubject)
        {
            return UploadViaEmail(x, strAddress, strFiles, strSubject, "");
        }
        public static bool UploadViaEmail(ContextNM x, String strAddress, String strFiles, String strSubject, String strBody, string strCC = "")
        {
            ContextRz xrz = (ContextRz)x;

            x.TheLeader.CommentEllipse("Preparing email upload to " + strAddress);
            ArrayList a = new ArrayList();
            String[] ary = Tools.Strings.Split(strFiles, "|");
            foreach(String s in ary)
            {
                String f = Tools.Folder.ConditionFolderName(RzLogic.ExportFolder) + s;
                if( File.Exists(f) )
                    a.Add(f);
                else
                {
                    x.TheLeader.Error(f + " does not exist.");
                    return false;
                }
            }
            nEmailMessage m = new nEmailMessage();
            if( Tools.Misc.IsDevelopmentMachine() )
                m.ToAddress = "test@recognin.com";
            else
                m.ToAddress = strAddress;
            m.Subject = strSubject;
            m.HTMLBody = strBody;
            
            if( Tools.Email.IsEmailAddress(strCC) )
                m.AddBccRecipient(strCC);

            foreach(String s in a)
            {
                FileInfo f = new FileInfo(s);
                x.TheLeader.CommentEllipse("Attaching " + s + " Size: " + Tools.Number.LongFormat(f.Length / 1024) + " Date: " + nTools.DateFormat_ShortDateTime(f.LastWriteTime));
                m.AddAttachment(s);
            }
            xrz.Logic.SetFromNotification(m, true);
            String r = "";
            if(m.Send(ref r))
            {
                x.TheLeader.Comment("Sent " + Tools.Number.LongFormat(a.Count) + " file(s) to " + strAddress, Core.InfoGrade.Positive);
                return true;
            }
            else
            {
                x.TheLeader.Error("Send to " + strAddress + " failed: " + r);
                return false;
            }
        }
        public static bool UploadViaFTP(ContextNM context, String strServer, String strUser, String strPassword, String strExtraPath, String strFiles)
        {
            try
            {
                //String err = "";
                //if (!Tools.Folder.CheckReadWrite(ref err))
                //{

                //}

                bool b = true;
                context.TheLeader.CommentEllipse("Uploading to " + strServer);
                FTP ftp;
                if( Tools.Misc.IsDevelopmentMachine() )
                    ftp = new FTP("ftp.recognin.com", "recognin", "Rec0gnin");
                else
                    ftp = new FTP(strServer, strUser, strPassword);
                ftp.Connect();
                context.TheLeader.Comment("FTP Connected.");
                String[] path = Tools.Strings.Split(strExtraPath, "/");
                foreach(String f in path)
                {
                    if(Tools.Strings.StrExt(f))
                    {
                        context.TheLeader.Comment("Changing to '" + f + "'");
                        ftp.ChangeDir(f);
                    }
                }
                String[] files = Tools.Strings.Split(strFiles, "|");
                foreach(String f in files)
                {
                    String ff = Tools.Folder.ConditionFolderName(RzLogic.ExportFolder) + f;
                    if(File.Exists(ff))
                    {
                        String bilge = @"c:\bilge\";
                        if (!Directory.Exists(bilge))
                            Directory.CreateDirectory(bilge);

                        String bilgeFile = bilge + f;
                        if (File.Exists(bilgeFile))
                            File.Delete(bilgeFile);

                        File.Copy(ff, bilgeFile);

                        FileInfo fi = new FileInfo(bilgeFile);
                        context.TheLeader.CommentEllipse("Sending " + bilgeFile + " Size: " + Tools.Number.LongFormat(fi.Length / 1024) + " Date: " + nTools.DateFormat_ShortDateTime(fi.LastWriteTime));
                        String status = "";
                        if (!ftp.SendFile(bilgeFile, ref status))
                        {
                            context.TheLeader.Comment("Sending " + bilgeFile + " failed: " + status);
                            b = false;
                        }
                    }
                    else
                    {
                        context.TheLeader.Comment(ff + " not found");
                        b = false;
                    }
                }
                context.TheLeader.CommentEllipse("Disconnecting");
                ftp.Disconnect();
                return b;
            }
            catch(Exception ex)
            {
                context.TheLeader.Comment("RTE in FTP upload to " + strServer + ": " + ex.Message);
                return false;
            }
        }


        public static bool UploadViaFTP_New(ContextNM x, String strServer, String strUser, String strPassword, String strExtraPath, String strFiles)
        {
            try
            {
                if (Tools.Misc.IsDevelopmentMachine())
                {
                    strServer = "mike.recognin.com";
                    strUser = "recognin";
                    strPassword = "Rec0gnin";
                }

                bool b = true;
                x.TheLeader.CommentEllipse("Uploading to " + strServer);

                if( !strServer.StartsWith("ftp://") )
                    strServer = "ftp://" + strServer;
                
                if( !strServer.EndsWith("/") )
                    strServer += "/";

                String[] path = Tools.Strings.Split(strExtraPath, "/");
                String strURI = strServer;

                foreach (String f in path)
                {
                    if (Tools.Strings.StrExt(f))
                    {
                        x.TheLeader.CommentEllipse("Adding to '" + f + "'");
                        strURI += f + "/";
                    }
                }

                String[] files = Tools.Strings.Split(strFiles, "|");
                foreach (String f in files)
                {
                    try
                    {
                        // Get the object used to communicate with the server.
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(strURI + f);
                        request.Method = WebRequestMethods.Ftp.UploadFile;
                        request.Credentials = new NetworkCredential(strUser, strPassword);


                        String ff = Tools.Folder.ConditionFolderName(RzLogic.ExportFolder) + f;

                        // Copy the contents of the file to the request stream.
                        FileInfo fi = new FileInfo(ff);
                        BinaryReader r = new BinaryReader(new FileStream(ff, FileMode.Open, FileAccess.Read));

                        int chunksize = 1024 * 1024;
                        long chunks = fi.Length / chunksize;
                        int leftover = Convert.ToInt32(fi.Length % chunksize);
                        
                        request.ContentLength = fi.Length;
                        Stream requestStream = request.GetRequestStream();

                        for (int chunk = 0; chunk < chunks; chunk++)
                        {
                            byte[] fileContents = r.ReadBytes(chunksize);
                            requestStream.Write(fileContents, 0, chunksize);
                        }

                        if (leftover > 0)
                        {
                            byte[] fileContents = r.ReadBytes(leftover);
                            requestStream.Write(fileContents, 0, leftover);
                        }

                        r.Close();
                        r = null;
                        requestStream.Close();

                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                        x.TheLeader.Comment("Upload File Complete, status " + response.StatusDescription);
                        response.Close();

                        if (!response.StatusDescription.StartsWith("226"))
                        {
                            b = false;
                            x.TheLeader.Comment("Transfer of " + f + " failed: " + response.StatusDescription);
                        }

                    }
                    catch (Exception ex)
                    {
                        b = false;
                        x.TheLeader.Comment("Error FTPing " + f + ": " + ex.Message);
                    }
                }

                x.TheLeader.Comment("Done");
                return b;
            }
            catch (Exception ex)
            {
                x.TheLeader.Error("RTE in FTP upload to " + strServer + ": " + ex.Message);
                return false;
            }
        }

        public static void ReInsertAlternates(nDataTable dv)
        {
            //here we need to grab all of the alternate part numbers
            //and bring them in with the same quantity, company info, mfg, dc, etc
            dv.xData.Execute("insert into " + dv.TableName + " (unique_id, fullpartnumber, manufacturer, quantity) select cast(newid() as varchar(50)) as unique_id, alternatepart as fullpartnumber, manufacturer as manufacturer, quantity as quantity from " + dv.TableName + " where len(isnull(alternatepart, '')) > 4");
        }


    }
    public class PartImportArgs
    {
        public Int64 ImportCount = 0;
        public Int64 AcceptedCount = 0;
        public Int64 RejectedCount = 0;
        public StringBuilder Log = new StringBuilder();
        public String TableName = "";
        public bool Silent = true;
        public bool PrefixBase = false;
        public bool HadErrors = false;
        public bool IgnoreMissingQuantityField = false;
        public String ExtraWhere = "";
        public long priority = 0;
        public n_user AcquisitionAgent = null;        

        public PartImportArgs(String strTable, bool silent)
        {
            TableName = strTable;
            Silent = silent;
        }
        public void AddLog(ContextRz context, String s)
        {
            context.TheLeader.Comment(s);
            Log.AppendLine(nTools.DateFormat_ShortDateTime(System.DateTime.Now) + ": " + s);
        }
        public void AddError(ContextRz context, String s)
        {
            HadErrors = true;
            AddLog(context, "<ERROR> " + s);
        }
    }

    public interface IPartObject
    {
        String fullpartnumber { get; set; }
        String prefix { get; set; }
        String basenumber { get; set; }
        String basenumberstripped { get; set; }
        String alternatepart { get; set; }
        String alternatepartstripped { get; set; }
    }
}