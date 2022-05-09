using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using NewMethod;

namespace Rz5
{
    public partial class RzLicense
    {
        //Public Static Variables
        public static String LicenseID;
        //public static LicenseTypes LicenseType = LicenseTypes.Lite;

        //Public Static Functions
        public static bool IsValidLicense(String s)
        {
            String clear = DecryptLicense(s);
            if (Tools.Strings.CharCount(clear, '|') != 1)
                return false;
            return true;
        }
        public static bool ApplyNewLicenseFile(ContextRz context, String s)
        {
            if (Tools.Files.SaveFileAsString(LicenseFileName, s))
            {
                InitLicense(context);
                return true;
            }
            else
                return false;
        }

        public static bool ApplyNewLicense(ContextRz context)  //LicenseTypes t
        {
            return ApplyNewLicense(context, Tools.Strings.GetNewID());  //, t
        }

        public static bool ApplyNewLicense(ContextRz context, String strID)  //, LicenseTypes t
        {
            String s = strID + "|";
            //if (t == LicenseTypes.Lite)
            //    s += "Lite";
            //else if (t == LicenseTypes.Pro)
                s += "Pro";
            //else if (t == LicenseTypes.Ultimate)
            //    s += "Ultimate";
            //else if (t == LicenseTypes.Custom)
            //    s += "Custom";
            //else
            //    s += "Lite";
            s += "|" + Environment.MachineName;
            return ApplyNewLicenseFile(context, Tools.Encryption.Encrypt(s, "recogninp"));
        }
        public static String DecryptLicense(String s)
        {
            try { return Tools.Encryption.Decrypt(s, "recogninp"); }
            catch { return ""; }
        }
        public static String LicenseFileName
        {
            get
            {
                return Tools.FileSystem.GetAppPath() + "tieinfo.txt";
            }
        }
        public static void InitLicense(ContextRz context)
        {
            String f = LicenseFileName;
            String s;
            context.TheLeader.Comment("Using license file: " + LicenseFileName);
            if (File.Exists(f))
            {
                context.TheLeader.Comment("License file exists : " + LicenseFileName);
                s = DecryptLicense(Tools.Files.OpenFileAsString(f));
            }
            else
            {
                //s = Tools.Strings.GetNewID() + "|Pro";
                s = Tools.Strings.GetNewID() + "|Lite|" + Environment.MachineName;
                Tools.Files.SaveFileAsString(f, nTools.Encrypt(s, "recogninp"));
            }
            InitLicense(s);
        }
        public static void InitLicense(String s)
        {
            LicenseID = Tools.Strings.ParseDelimit(s, "|", 1);
            String strType = Tools.Strings.ParseDelimit(s, "|", 2);
            String strMachine = Tools.Strings.ParseDelimit(s, "|", 3);

            //if (Tools.Strings.StrExt(strMachine) && !Tools.Strings.StrCmp(strMachine, Environment.MachineName))
            //{
            //    LicenseType = LicenseTypes.Lite;
            //    context.TheLeader.Comment("LicenseType = LicenseTypes.Lite");
            //    return;
            //}

            //switch (strType.ToLower())
            //{
            //    case "lite":
            //        LicenseType = LicenseTypes.Lite;
            //        break;
            //    case "pro":
            //        LicenseType = LicenseTypes.Pro;
            //        break;
            //    case "ultimate":
            //        LicenseType = LicenseTypes.Ultimate;
            //        break;
            //    case "custom":
            //        LicenseType = LicenseTypes.Custom;
            //        break;
            //    default:
            //        LicenseType = LicenseTypes.Lite;
            //        break;
            //}
            //context.TheLeader.Comment("LicenseType = LicenseTypes." + LicenseType.ToString());
        }
    }
    //public enum LicenseTypes
    //{
    //    Lite = 1,
    //    Pro = 2,
    //    Ultimate = 3,
    //    Custom = 4
    //}
}
