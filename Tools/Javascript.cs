using System;
using System.Collections.Generic;
using System.Text;

namespace Tools
{
    public static class Javascript
    {
        public static String Encode(String s)
        {
            String key = "<" + Tools.Strings.GetNewID() + ">";
            while(s.Contains(key) )
            {
                key = "<" + Tools.Strings.GetNewID() + ">";
            }
            String ret = s.Replace(@"\", key);
            ret = ret.Replace("'", "\\'").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "\\n").Replace(" ", @"\s");
            ret = ret.Replace(key, @"\\");
            return ret;
        }
    }
}
