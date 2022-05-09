using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeInterop
{
    public static class ToolsStrings
    {
        public static String Trim(String s)
        {
            return s.Trim();
        }

        public static String GetNewID()
        {
            System.Guid x = System.Guid.NewGuid();
            return x.ToString().Replace("-", "");
        }

        public static Boolean StrExt(String s)
        {
            if (s == null)
                return false;
            if (s.Trim().Length <= 0)
                return false;
            return true;
        }

        public static String[] Split(String strIn, String strSplit)
        {
            return strIn.Split(new String[] { strSplit }, StringSplitOptions.None);
        }
    }
}
