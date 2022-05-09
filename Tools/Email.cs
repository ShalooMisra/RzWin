using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public static class Email
    {
        public static bool IsEmailAddress(String s)
        {
            if (Tools.Strings.HasString(s, ".."))
                return false;
            if (Tools.Strings.HasString(s, ","))
                return false;
            if (Tools.Strings.HasString(s, ";"))
                return false;
            if (Tools.Strings.HasString(s, ":"))
                return false;
            if (Tools.Strings.HasString(s, "\\"))
                return false;
            if (Tools.Strings.HasString(s, "/"))
                return false;
            if (Tools.Strings.HasString(s, "$"))
                return false;
            if (Tools.Strings.HasString(s, "%"))
                return false;
            if (Tools.Strings.HasString(s, "&"))
                return false;
            if (Tools.Strings.HasString(s, "!"))
                return false;
            if (Tools.Strings.HasString(s, "<"))
                return false;
            if (Tools.Strings.HasString(s, ">"))
                return false;
            if (Tools.Strings.HasString(s, "?"))
                return false;
            if (Tools.Strings.HasString(s, "+"))
                return false;
            if (Tools.Strings.HasString(s, "="))
                return false;
            if (Tools.Strings.HasString(s, "*"))
                return false;
            if (Tools.Strings.HasString(s, "^"))
                return false;
            if (Tools.Strings.HasString(s, "#"))
                return false;
            if (Tools.Strings.HasString(s, "["))
                return false;
            if (Tools.Strings.HasString(s, "]"))
                return false;
            if (Tools.Strings.HasString(s, "{"))
                return false;
            if (Tools.Strings.HasString(s.Trim(), " "))
                return false;
            String s1 = Tools.Strings.ParseDelimit(s, "@", 1);
            String s2 = Tools.Strings.ParseDelimit(s, "@", 2);
            String se = Tools.Strings.ParseDelimit(s2, ".", 2);
            if (s1.Length > 40)
                return false;
            if (s2.Length > 60)
                return false;
            if (se.Length > 40)
                return false;
            if (Tools.Strings.HasString(s1, "@"))
                return false;
            if (Tools.Strings.HasString(s2, "@"))
                return false;
            if (Tools.Strings.HasString(se, "@"))
                return false;
            return Tools.Strings.StrExt(s1) && Tools.Strings.StrExt(s2) && Tools.Strings.StrExt(se);
        }
        public static String ParseEmailDomain(String strEmail)
        {
            String s = Tools.Strings.ParseDelimit(strEmail, "@", 2);
            return s;
        }
        public static String ParseEmailSuffix(String strEmail)
        {
            if (strEmail.ToLower().EndsWith(".mod.uk"))
                return "mod.uk";

            String[] sx = Tools.Strings.Split(strEmail.Trim(), ".");
            if (sx.Length < 2)
                return "";
            return sx[sx.Length - 1].Trim();
        }

        public static String IsEmailAddressSql(String field)
        {
            String ret = " ( isnull(" + field + ", '') like '%_@_%._%' ) ";
            return ret;
        }

        public static String IsNotEmailAddressSql(String field)
        {
            String ret = " ( isnull(" + field + ", '') not like '%_@_%._%' ) ";
            return ret;
        }
    }
}
