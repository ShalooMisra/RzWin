using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;

namespace Tools
{
    public class GenericEvent
    {
        public string Message = "";
        public bool Handled = false;
        public GenericEvent()
        {
        }
        public GenericEvent(String s)
        {
            Message = s;
        }
    }

    public static class Misc
    {
        public static Int64 GetTicks()
        {
            return Environment.TickCount;
        }
        public static string GetVersionString(Assembly assembly)
        {
            FileVersionInfo fvi = GetFileVersionInfo(assembly);
            return fvi.ProductMajorPart.ToString() + "." + fvi.ProductMinorPart.ToString() + "." + fvi.ProductBuildPart.ToString() + "." + fvi.ProductPrivatePart.ToString();
        }
        public static FileVersionInfo GetFileVersionInfo(Assembly assembly)
        {
            return FileVersionInfo.GetVersionInfo(assembly.Location);
        }
        public static long GetVersionNumber(Assembly assembly)
        {
            FileVersionInfo fvi = GetFileVersionInfo(assembly);
            return GetVersionNumber(fvi.ProductMajorPart, fvi.ProductMinorPart, fvi.ProductBuildPart, fvi.ProductPrivatePart);
        }
        public static long GetVersionNumber(int major, int minor, int revision, int extra)
        {
            return (major * 10000000) + (minor * 100000) + (revision * 1000) + extra;
        }

        public static bool IsDevelopmentMachine()
        {
            switch (Environment.MachineName.ToLower())
            {
                //case "vanburgh02":
                //case "vanburgh03":
                //case "laptop06":
                //case "westwood":
                //case "westwood1":
                //case "jlaptop":
                //case "development-2":
                //case "newmethod1":
                //case "laptop64":
                //case "v4":
                //case "v5":
                //case "laptop07":
                //case "laptop08":
                //case "rz0":
                //case "mikeoffice01":
                case "it-31gkgx1":
                case "6ws9pv1":
                    return true;
                default:
                    return false;
                //    return LoginInfo.IsDevelopmentMachine;
            }
        }
    }
}
