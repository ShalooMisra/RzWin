using System;
using System.Collections;
using System.Text;
using System.Reflection;
using System.IO;

using NewMethod;
using Core;
using Tools.Database;

namespace Tools
{
    public partial class Dymo
    {
        //Public Static Functions
        public static bool PrintDymoLabel(ContextNM context, String strLabel, nObject x)
        {
            return PrintDymoLabel(context, strLabel, x, null);
        }
        public static bool PrintDymoLabel(ContextNM context, String strLabel, nObject x, ArrayList extra)
        {
            ArrayList c = new ArrayList();
            c.Add(x);
            return PrintDymoLabel(context, strLabel, c, extra);
        }
        public static bool PrintDymoLabel(ContextNM context, String strLabel, ArrayList objects)
        {
            return PrintDymoLabel(context, strLabel, objects, null);
        }
        public static bool PrintDymoLabel(ContextNM context, String strLabel, ArrayList objects, ArrayList extra)
        {
            return PrintDymoLabel(context, strLabel, objects, extra, false);
        }
        //public static bool NewDymoVersion = false;
        public static bool PrintDymoLabel(ContextNM context, String strLabel, ArrayList objects, ArrayList extra, Boolean bBarcode)
        {
            context.TheLeader.StartPopStatus("Printing label...");
            if (!strLabel.ToLower().EndsWith(".lwl"))
                strLabel += ".lwl";
            String strFile = LabelFileFind(strLabel);
            if (!File.Exists(strFile))
            {
                strLabel = Path.GetFileNameWithoutExtension(strLabel) + ".label";
                strFile = LabelFileFind(strLabel);
                if (!File.Exists(strFile))
                {
                    context.TheLeader.Error("The file " + strLabel + " was not found");
                    return false;
                }
            }
            context.TheLeader.Comment("Using file: " + strFile);
            Type tAddIn = null;
            Type tLabels = null;
            Object IDymoAddIn = null;
            Object IDymoLabels = null;
            try
            {
                tAddIn = Type.GetTypeFromProgID("Dymo.DymoAddIn");
                tLabels = Type.GetTypeFromProgID("Dymo.DymoLabels");
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("Error initializing the Dymo types: " + ex.Message);
            }
            try
            {
                IDymoAddIn = Activator.CreateInstance(tAddIn);
                IDymoLabels = Activator.CreateInstance(tLabels);
            }
            catch (Exception ex2)
            {
                context.TheLeader.Error("Error initializing the Dymo objects: " + ex2.Message);
            }
            if (IDymoAddIn == null || IDymoLabels == null)
            {
                context.TheLeader.Error("The Dymo label printing software couldn't be accessed.  Are the Dymo LabelWriter and the Software Development Kit (DLS_SDK) installed?");
                context.TheLeader.StopPopStatus(true);
                return false;
            }
            try
            {
                Object[] args = { strFile };
                Object r;
                context.TheLeader.CommentEllipse("Opening");
                r = tAddIn.InvokeMember("Open", BindingFlags.InvokeMethod, null, IDymoAddIn, args);
                try
                {
                    context.TheLeader.Comment("Open returned " + r.ToString());
                }
                catch { }
                if (objects != null)
                {
                    foreach (nObject xObject in objects)
                    {
                        AssociateObjectWithDymo(context, tAddIn, tLabels, IDymoAddIn, IDymoLabels, xObject, bBarcode);
                    }
                }
                if (extra == null)
                    extra = new ArrayList();
                extra.Add(new LabelReplacement("MMYY", DateTime.Now.Month.ToString() + "/" + Tools.Strings.Right(DateTime.Now.Year.ToString(), 2)));
                //set the extra data
                if (extra != null)
                {
                    foreach (LabelReplacement lr in extra)
                    {
                        Object[] argsx = { lr.strKey, lr.strValue };
                        r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, argsx);
                    }
                }
                Object[] argsy = { "GETDATE", nTools.DateFormat(System.DateTime.Now) };
                r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, argsy);
                args = new Object[] { 1, true };
                context.TheLeader.Comment("Printing...");
                r = tAddIn.InvokeMember("Print", BindingFlags.InvokeMethod, null, IDymoAddIn, args);
                try
                {
                    context.TheLeader.Comment("Print returned " + r.ToString());
                }
                catch { }
                context.TheLeader.Comment("Done.");
                context.TheLeader.StopPopStatus(false);
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error printing this label: " + ex.Message);
                context.TheLeader.StopPopStatus(true);
                return false;
            }
            finally
            {
                IDymoAddIn = null;
                IDymoLabels = null;
            }
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }
        public static String LabelFileFind(String strLabel)
        {

            string strFile = "";
            var path = @"\\sm1\Dymo Labels\";
            if (Directory.Exists(path))
                strFile = path + strLabel;
            else
                strFile = "c:\\" + strLabel;




            if (!File.Exists(strFile))
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
                            return "";
                        }
                    }
                }
            }

            return strFile;
        }
        public static bool PrintAddressLabel(ContextNM context, String strAddress, String strFile)
        {
            ArrayList a = new ArrayList();
            a.Add(strAddress);
            return PrintAddressLabel(context, a, strFile);
        }
        public static bool PrintAddressLabel(ContextNM context, ArrayList AddressStrings, String strFile)
        {
            Type tAddIn = null;
            Type tLabels = null;
            Object IDymoAddIn = null;
            Object IDymoLabels = null;

            try
            {
                tAddIn = Type.GetTypeFromProgID("Dymo.DymoAddIn");
                tLabels = Type.GetTypeFromProgID("Dymo.DymoLabels");

                IDymoAddIn = Activator.CreateInstance(tAddIn);
                IDymoLabels = Activator.CreateInstance(tLabels);
            }
            catch (Exception)
            {
            }

            if (IDymoAddIn == null || IDymoLabels == null)
            {
                context.TheLeader.Error("The Dymo label printing software couldn't be accessed.  Are the Dymo LabelWriter and the Software Development Kit (DLS_SDK) installed?");
                return false;
            }

            try
            {
                Object[] args = { strFile };
                Object r;
                r = tAddIn.InvokeMember("Open", BindingFlags.InvokeMethod, null, IDymoAddIn, args);

                foreach (String strAddress in AddressStrings)
                {
                    Object[] args2 = { "address_text", strAddress };
                    r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args2);

                    args = new Object[] { 1, true };
                    r = tAddIn.InvokeMember("Print", BindingFlags.InvokeMethod, null, IDymoAddIn, args);
                }

                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error printing this label: " + ex.Message);
                return false;
            }
            finally
            {
                IDymoAddIn = null;
                IDymoLabels = null;
            }
        }
        //Private Static Functions
        private static void AssociateObjectWithDymo(ContextNM context, Type tAddIn, Type tLabels, object IDymoAddIn, object IDymoLabels, nObject xObject, Boolean bBarcode)
        {
            if (xObject == null)
                return;

            String strKey;

            String strVal;
            foreach (VarVal p in xObject.VarValsGet())
            {
                try
                {
                    strKey = xObject.ClassId.ToLower() + "_" + p.Name.ToLower();
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
                            strVal = Tools.Strings.ParseDelimit(strVal, "[", 1).Trim();
                            break;
                    }
                    if (bBarcode)
                    {
                        if (!Tools.Strings.StrCmp(strVal, "<none>"))
                        {
                            strVal = strVal.ToUpper();
                            if (p.FieldType == FieldType.Double || p.FieldType == FieldType.Int64 || p.FieldType == FieldType.Int32)
                            {
                                nDouble dub = strVal;
                                strVal = dub.ToString();
                            }
                        }
                    }
                    Object[] args = { strKey, strVal };
                    Object r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args);

                    if (xObject.ClassId.ToLower().StartsWith("ordhed_"))
                    {
                        strKey = "ordhed_" + p.Name.ToLower();
                        args = new Object[] { strKey, strVal };
                        r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args);
                    }

                    if (xObject.ClassId.ToLower().StartsWith("orddet_"))
                    {
                        strKey = "orddet_" + p.Name.ToLower();

                        args = new Object[] { strKey, strVal };
                        r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args);

                        args = new Object[] { strKey + "_extra", strVal };
                        r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args);
                    }

                    strKey = "any_" + p.Name.ToLower();

                    args = new Object[] { strKey, strVal };
                    r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args);

                    args = new Object[] { strKey + "_extra", strVal };
                    r = tLabels.InvokeMember("SetField", BindingFlags.InvokeMethod, null, IDymoLabels, args);
                }
                catch (Exception ex)
                {
                    context.TheLeader.Error("Error in nDymo.AssociateObject: " + ex.Message);
                }
            }
        }
    }
    public class LabelReplacement
    {
        public String strKey = "";
        public String strValue = "";

        public LabelReplacement(String sk, String sv)
        {
            strKey = sk;
            strValue = sv;
        }
    }
}
