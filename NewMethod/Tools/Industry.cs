using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;

using NewMethod;
using Tools.Database;

namespace Tools
{
    public partial class Industry
    {
        //Public Static Functions
        public static String DistillPhoneNumber(String s)
        {
            return nTools.FilterPhoneNumber(s, "");
        }
        public static bool IsTermsCreditCard(String terms)
        {
            return IsTermsCreditCard(terms, false);
        }
        public static bool IsTermsCreditCard(String terms, bool excludegeneric)
        {
            String s = terms.Replace(" ", "").Trim();
            s = s.Replace("/", "").Trim();
            if (!excludegeneric)
            {
                if (Tools.Strings.HasString(s, "cc"))
                    return true;
                if (Tools.Strings.HasString(s, "ccard"))
                    return true;
                if (Tools.Strings.HasString(s, "creditcard"))
                    return true;
            }
            if (Tools.Strings.HasString(s, "mastercard"))
                return true;
            if (Tools.Strings.HasString(s, "visa"))
                return true;
            if (Tools.Strings.HasString(s, "discover"))
                return true;
            if (Tools.Strings.HasString(s, "amex"))
                return true;
            if (Tools.Strings.HasString(s, "americanexpress"))
                return true;
            if (Tools.Strings.StrCmp(s, "mc"))
                return true;
            return false;
        }
        public static bool IsTermsCOD(String terms)
        {
            return Tools.Strings.HasString(terms.Replace(".", "").Replace(" ", ""), "cod");
        }
        public static bool IsTermsTT(String terms)
        {
            String s = Tools.Strings.FilterTrash(terms);
            if (Tools.Strings.HasString(s, "tt"))
                return true;
            if (Tools.Strings.HasString(s, "wire"))
                return true;
            return false;
        }
        public static bool IsPhoneNumber(String s)
        {
            if (s == null)
                return false;

            if (Tools.Strings.HasString(s, "@"))
                return false;

            if (Tools.Strings.HasString(s, "$"))
                return false;

            if (Tools.Strings.HasString(s, ":"))
                return false;

            int l1 = s.Length;
            if (l1 > 16)
                return false;

            s = nTools.StripNonNumeric(s);

            if ((l1 - s.Length) > 6)
                return false;

            if (s.Length < 7)
                return false;
            if (s.Length > 16)
                return false;
            return true;
        }
        public static String StripPhoneNumber(String s)
        {
            return StripPhoneNumber(s, true);
        }
        public static String StripPhoneNumber(String s, bool chop)
        {
            String x = Tools.Strings.ParseDelimit(s.ToLower(), "ext", 1);
            x = Tools.Strings.ParseDelimit(x, "ex", 1);
            x = Tools.Strings.ParseDelimit(x, "x", 1);
            
            x = nTools.StripNonNumeric(x);
            if (x.Length == 11 && x.StartsWith("1"))
                x = Tools.Strings.Mid(x, 2);
            if (chop && x.Length > 10 && x.StartsWith("011"))
                x = Tools.Strings.Mid(x, 4);

            if (chop && x.Length > 10 && x.StartsWith("001"))
                x = Tools.Strings.Mid(x, 4);

            //+44 (0)161 455 4243  in this number the (0) is never dialled and isn't in the caller ID
            //just chop it down to 9 for intl numbers

            if (chop && x.Length > 10)
                x = Tools.Strings.Right(x, 9);

            return x;
        }
        public static bool StripPhoneNumberField(DataConnection xd, String strTable, String strField)
        {
            xd.Execute("update " + strTable + " set " + strField + " = substring(" + strField + ", 0, charindex('e', " + strField + ")) where " + strField + " like '%_e%'");
            xd.Execute("update " + strTable + " set " + strField + " = substring(" + strField + ", 0, charindex('x', " + strField + ")) where " + strField + " like '%_x%'");
            xd.Execute("update " + strTable + " set " + strField + " = substring(" + strField + ", 0, charindex('c', " + strField + ")) where " + strField + " like '%_c%'"); //for 'cell'
            if (!nTools.StripField((DataConnectionSqlServer)xd, strTable, strField))
                return false;
            xd.Execute("update " + strTable + " set " + strField + " = substring(" + strField + ", 2, 255) where " + strField + " like '1%' and len(" + strField + ") = 11 ");
            xd.Execute("update " + strTable + " set " + strField + " = right(" + strField + ", 9) where len(" + strField + ") > 10");  //just take the last 9
            return true;
        }
        public static String FilterPhoneNumber(String strPhone)
        {
            return FilterPhoneNumber(strPhone, "");
        }
        public static String FilterPhoneNumber(String strPhone, String strAreaCode)
        {
            strPhone = nTools.StripPhoneNumber(strPhone);
            if (strPhone.Length == 7)
            {
                if (Tools.Strings.StrExt(strAreaCode))
                    strPhone = strAreaCode + strPhone;
            }
            return strPhone;
        }
        public static MailingAddress ParseAddress(string data)
        {
            MailingAddress m = new MailingAddress();
            try
            {
                String s = "!|&|+|-|/|)|(|'|\r|\n|\t|\\|*|#|:|[|]|%|{|}|`|~|$";
                String[] hold = Tools.Strings.BulkReplace(Tools.Strings.Split(data, "\r\n"), s.Split("|".ToCharArray()));
                m.Line1 = hold[0];
                Int32 iCity = 0;
                if (hold[hold.Length - 1].StartsWith("us, ", StringComparison.CurrentCultureIgnoreCase))
                {
                    m.City = Tools.Strings.ParseDelimit(hold[1], ",", 1);
                    m.State = Tools.Strings.ParseDelimit(hold[1], ",", 2);
                    m.Country = Tools.Strings.ParseDelimit(hold[2], ",", 1);
                    m.Zip = Tools.Strings.ParseDelimit(hold[2], ",", 2);
                }
                else
                {
                    if (hold.Length == 2)
                        iCity = 1;
                    else if (hold.Length == 3)
                    {
                        m.Line2 = hold[1];
                        iCity = 2;
                    }
                    else if (hold.Length == 4)
                    {
                        m.Line2 = hold[1];
                        m.Line3 = hold[2];
                        iCity = 3;
                    }
                    else
                        return null;
                    m.City = Tools.Strings.ParseDelimit(hold[iCity], ",", 1);
                    String strRest = Tools.Strings.ParseDelimit(hold[iCity], ",", 2);
                    do
                    {
                        strRest = strRest.Replace("  ", " ").Trim();
                    } while (strRest.Contains("  "));
                    m.State = Tools.Strings.ParseDelimit(strRest, " ", 1);
                    m.Zip = Tools.Strings.ParseDelimit(strRest, " ", 2);
                    return m;
                }
            }
            catch { }
            return null;
        }
    }
    public partial class MailingAddress
    {
        //Public Variables
        public string Line1 = "";
        public string Line2 = "";
        public string Line3 = "";
        public string City = "";
        public string State = "";
        public string Zip = "";
        public string Country = "";
    }
}
