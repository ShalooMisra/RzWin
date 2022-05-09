using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using NewMethod;
using Core;
using Tools.Database;

namespace Tools
{
    public partial class Zebra
    {
        //Public Static Functions
        public static bool PrintZebraLabel(ContextNM context, String strLabel, nObject x)
        {
            return PrintZebraLabel(context, strLabel, x, null, false);
        }
        public static bool PrintZebraLabel(ContextNM context, String strLabel, nObject x, ArrayList extra, bool uppercase)
        {
            ArrayList c = new ArrayList();
            c.Add(x);
            return PrintZebraLabel(context, strLabel, c, extra, uppercase);
        }
        public static bool PrintZebraLabel(ContextNM context, String strLabel, ArrayList objects, bool uppercase)
        {
            return PrintZebraLabel(context, strLabel, objects, null, uppercase);
        }
        public static bool PrintZebraLabel(ContextNM context, String strLabel, ArrayList objects, ArrayList extra, bool uppercase)
        {
            if (!strLabel.ToLower().EndsWith(".epl"))
                strLabel += ".epl";

            String strFile = "c:\\" + strLabel;

            if (!System.IO.File.Exists(strFile))
            {
                strFile = Tools.FileSystem.GetAppPath() + strLabel;
                if (!System.IO.File.Exists(strFile))
                {
                    strFile = nTools.GetAppParentPath() + "labels\\" + strLabel;
                    if (!System.IO.File.Exists(strFile))
                    {
                        strFile = Tools.FileSystem.GetAppPath() + "labels\\" + strLabel;
                        if (!System.IO.File.Exists(strFile))
                        {
                            context.TheLeader.Error("The file " + strFile + " was not found");
                            return false;
                        }
                    }
                }
            }

            String strData = Tools.Files.OpenFileAsString(strFile);
            return PrintZebraLabelData(context, strData, objects, extra, uppercase, "");
        }
        public static bool PrintZebraLabelFromSetting(ContextNM context, String setting_name, nObject x, bool uppercase)
        {
            ArrayList objects = new ArrayList();
            objects.Add(x);
            String data = n_set.GetSetting(context, setting_name);

            String printer_name = Tools.Strings.ParseDelimit(data, "</PrinterName>", 1);
            printer_name = Tools.Strings.ParseDelimit(printer_name, ">", 2).Trim();
            String raw_data = Tools.Strings.ParseDelimit(data, "</PrinterName>", 2);

            if (!Tools.Strings.StrExt(raw_data))
            {
                context.TheLeader.Error("The setting for label '" + setting_name + "' was not found");
                return false;
            }
            return PrintZebraLabelData(context, raw_data, objects, new ArrayList(), uppercase, printer_name);
        }
        public static bool PrintZebraLabelData(ContextNM x, String raw_label_data, ArrayList objects, ArrayList extra, bool uppercase, String printer_name)
        {            
            string r = "";
            return PrintZebraLabelData(x, raw_label_data, objects, extra, uppercase, printer_name, ref r);
        }
        public static bool PrintZebraLabelData(ContextNM x, String raw_label_data, ArrayList objects, ArrayList extra, bool uppercase, String printer_name, ref String ret_data)
        {
            try
            {
                String strData = raw_label_data;
                if (objects != null)
                {
                    foreach (nObject xObject in objects)
                    {
                        AssociateObjectWithZebra(x, ref strData, xObject, uppercase);
                        String fullpartnumber = "";
                        try
                        {
                            fullpartnumber = nData.NullFilter_String(xObject.IGet("fullpartnumber"));
                            if (Tools.Strings.StrExt(fullpartnumber))
                            {
                                strData = strData.Replace("<any.pec_with_release>", fullpartnumber);
                            }
                        }
                        catch { }
                    }
                }
                //set the extra data
                if (extra != null)
                {
                    foreach (LabelReplacement lr in extra)
                    {
                        strData = strData.Replace(lr.strKey, lr.strValue);
                    }
                }
                strData = strData.Replace("GETDATE", nTools.DateFormat(System.DateTime.Now));
                strData = strData.Replace("mm/yy", System.DateTime.Now.Month.ToString() + "/" + Tools.Strings.Right(System.DateTime.Now.Year.ToString(), 2));
                ret_data = strData;
                PrintDirect.PrintString(strData, printer_name);
                return true;
            }
            catch (Exception ex)
            {
                x.TheLeader.Error("There was an error printing this label: " + ex.Message);
                return false;
            }
            finally
            {
            }
        }
        //Private Static Functions
        private static void AssociateObjectWithZebra(ContextNM x, ref String strData, nObject xObject, bool uppercase)
        {
            if (xObject == null)
                return;

            String strKey;
            String strVal;
            foreach (VarVal p in xObject.VarValsGet())
            {
                switch (p.FieldType)
                {
                    case FieldType.Double:
                        strVal = nTools.MoneyFormat_2_6((Double)xObject.IGet(p.Name));
                        break;
                    case FieldType.Int64:
                        strVal = Tools.Number.LongFormat((long)xObject.IGet(p.Name));
                        break;
                    case FieldType.DateTime:
                        strVal = nTools.DateFormat((DateTime)xObject.IGet(p.Name));
                        break;
                    default:
                        strVal = xObject.IGet(p.Name).ToString();
                        break;
                }

                switch (p.Name.ToLower())
                {
                    case "companyname":
                    case "vendorname":
                    case "customer_name":
                    case "vendor_name":
                        strVal = Tools.Strings.ParseDelimit(strVal, "[", 1).Trim();
                        break;
                }
                if (uppercase)
                    strVal = strVal.ToUpper();

                strKey = "<" + xObject.ClassId.ToLower() + "." + p.Name.ToLower() + ">";
                strData = strData.Replace(strKey, strVal);

                strKey = "<any." + p.Name.ToLower() + ">";
                strData = strData.Replace(strKey, strVal);

                //old style
                strKey = xObject.ClassId.ToLower() + "_" + p.Name.ToLower();
                strData = strData.Replace(strKey, strVal);

                strKey = "<datetime.now>";
                strData = strData.Replace(strKey, DateTime.Now.ToShortDateString());
            }
        }
    }

}
