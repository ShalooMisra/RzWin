using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OfficeInterop;
//using Word = Microsoft.Office.Interop.Word;
using NewMethod;
using Core;
using Tools.Database;

namespace NewMethod
{
    public static class ToolsWordNM
    {
        public static String ErrorMsg;

        //Public Static Functions
        public static Boolean MixObjectWithWordDocument(ContextNM context, nObject n, Word.Document doc)
        {
            return MixObjectWithWordDocument(context, n, doc, "", 0, "");
        }
        public static Boolean MixObjectWithWordDocument(ContextNM context, nObject n, Word.Document doc, String sKey, Int32 index, String sPrefix)
        {
            ErrorMsg = "";
            try
            {
                var bodyText = doc.Range(0, doc.Characters.Count);
                String all = bodyText.ToString();
                String value = "";
                String find = "";
                foreach (VarVal prop in n.VarValsGet())
                {
                    switch (prop.FieldType)
                    {
                        case FieldType.Double:
                            value = String.Format("{0:###,###,##0.00##}", n.IGet(prop.Name));
                            value = value.Substring(0, ((value.Length > 254) ? 254 : value.Length));
                            break;
                        case FieldType.Int64:
                        case FieldType.Int32:
                            value = String.Format("{0:###,###,##0}", n.IGet(prop.Name));
                            value = value.Substring(0, ((value.Length > 254) ? 254 : value.Length));
                            break;
                        case FieldType.DateTime:
                            value = String.Format("{0:d}", n.IGet(prop.Name));
                            value = value.Substring(0, ((value.Length > 254) ? 254 : value.Length));
                            break;
                        default:
                            value = n.IGet(prop.Name).ToString();
                            value = value.Substring(0, ((value.Length > 254) ? 254 : value.Length));
                            break;
                    }
                    if (Tools.Strings.StrCmp(prop.Name, "companyname"))
                        value = Tools.Strings.Split(value, "[")[0].Trim();
                    switch (prop.Name)
                    {
                        case "shippingaddress":
                        case "billingaddress":
                        case "bankaddress":
                            value = value.Replace("\r", "");
                            String[] ary = Tools.Strings.Split(value, "\n");
                            for (Int32 x = 0; x < ary.Length; x++)
                            {
                                value = ary[x];
                                find = "<" + n.ClassId + "." + prop.Name + "_" + ((Int32)(x + 1)).ToString() + ">";
                                if (all.Contains(find))
                                {
                                    //doc.ReplaceText(find, value, 2);
                                }
                                    
                            }
                            break;
                        default:
                            //Index Override
                            if (Tools.Strings.StrExt(sKey))
                                find = "<" + sKey + "_" + index.ToString() + "." + prop.Name + ">";
                            else
                            {
                                if (Tools.Strings.StrExt(sPrefix))
                                    find = "<" + sPrefix + "." + prop.Name + ">";
                                else
                                    find = "<" + n.ClassId + "." + prop.Name + ">";
                            }
                            if (all.ToLower().Contains(find.ToLower()))
                            {
                                //doc.ReplaceText(find, value, 0);
                            }                                
                            break;
                    }

                }
                find = "<ordhed.subtotal>";
                if (all.Contains(find))
                {
                    value = String.Format("{0:c}", n.IGet("subtotal").ToString());
                    //doc.ReplaceText(find, value, 0);
                }
                return true;
            }
            catch (Exception e)
            {
                //if (nTools.GetControlKey())
                //    context.TheLeader.Tell(e.Message);
                ErrorMsg = e.Message;
                return false;
            }
        }

        public static Boolean ClearTags(Word.Document doc, String sKey, nObject obj, Int32 start, Int32 stop)
        {
            ErrorMsg = "";
            try
            {
                //String all = doc.ContentText;
                var bodyText = doc.Range(0, doc.Characters.Count);
                String all = bodyText.ToString();
                for (Int32 i = start; i < stop; i++)
                {
                    Boolean bIn = false;
                    foreach (VarVal p in obj.VarValsGet())
                    {
                        String tag = "<" + sKey + "_" + i.ToString() + "." + p.Name + ">";
                        if (all.ToLower().Contains(tag.ToLower()))
                        {
                            bIn = true;
                            Object replaceText;
                            Object t = true;
                            Object f = false;
                            Object missing = System.Reflection.Missing.Value;
                            replaceText = "";
                            //To ensure that unwanted formats aren't included as criteria
                            //doc.Content.Find.ClearFormatting();
                            //doc.ContentFindText = tag;
                            //doc.ContentFindReplacementText = "";
                            //doc.ContentFindMatchCase = false;
                            //doc.ContentFindExecute(tag, (Object)replaceText);
                        }
                    }
                    if (!bIn)
                        return true;
                }
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }

    }
}
