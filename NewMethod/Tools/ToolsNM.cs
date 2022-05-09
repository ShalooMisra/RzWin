using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using NewMethod;

namespace Tools
{
    public static class ToolsNM
    {
        public static String GetIDString(SortedList l)
        {
            nObject o;
            StringBuilder sb = new StringBuilder();
            bool b = true;
            foreach (DictionaryEntry d in l)
            {
                o = (nObject)d.Value;
                if (!b)
                {
                    sb.Append(", ");
                }
                sb.Append("'" + o.unique_id + "'");
                b = false;
            }
            return sb.ToString();
        }

        public static String GetIDString(ArrayList l)
        {
            StringBuilder sb = new StringBuilder();
            bool b = true;
            foreach (nObject o in l)
            {
                if (!b)
                {
                    sb.Append(", ");
                }
                sb.Append("'" + o.unique_id + "'");
                b = false;
            }
            return sb.ToString();
        }

        public static Assembly AssemblyNM
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }
    }
}
