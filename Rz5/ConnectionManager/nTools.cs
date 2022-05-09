using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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
//using ICSharpCode.SharpZipLib.Zip;

namespace NewMethodx
{
    public class nTools
    {
        //new stuff

        public static String TranslateFileName(String f)
        {
            String r = f.Replace("|desktop|", nTools.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            r = r.Replace("|my_documents|", nTools.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)));
            r = r.Replace("|my_music|", nTools.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)));
            r = r.Replace("|my_pictures|", nTools.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)));
            r = r.Replace("|root_folder|", nTools.ConditionFolderName(Path.GetPathRoot(nTools.GetAppPath())));
            r = r.Replace("|desktop_wallpaper|", nTools.GetDesktopWallpaperFile());
            return r;
        }

        public static String FilterPath(String s)
        {
            return s.Replace("|", "\\");
        }

        public static String GetDesktopWallpaperFile()
        {
            try
            {
                //HKEY_CURRENT_USER\Control Panel\Desktop\Wallpaper
                Microsoft.Win32.RegistryKey ckey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);
                String s = ckey.GetValue("Wallpaper").ToString();
                if (!File.Exists(s))
                    return "";
                return s;
            }
            catch { return ""; }
        }

        public static String BuildXmlProp(String strName, long val)
        {
            return BuildXmlProp(strName, val.ToString(), true);
        }

        public static String BuildXmlProp(String strName, int val)
        {
            return BuildXmlProp(strName, val.ToString(), true);
        }

        public static String BuildXmlProp(String strName, bool val)
        {
            return BuildXmlProp(strName, val.ToString(), true);
        }

        public static String BuildXmlProp(String strName, String strValue)
        {
            return BuildXmlProp(strName, strValue, true);
        }

        public static String BuildXmlProp(String strName, String strValue, bool encode)
        {
            if (encode)
                return "<" + strName + ">" + nTools.EncodeForXml(strValue) + "</" + strName + ">\n";
            else
                return "<" + strName + ">" + strValue + "</" + strName + ">\n";

        }

        public static String ReadXmlProp(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return fNode.InnerText;
            }
            catch { return ""; }
        }

        public static long ReadXmlProp_Long(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return Int64.Parse(fNode.InnerText);
            }
            catch { return 0; }
        }

        public static int ReadXmlProp_Integer(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return Int32.Parse(fNode.InnerText);
            }
            catch { return 0; }
        }

        public static bool ReadXmlProp_Boolean(XmlNode n, String strName)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                return Boolean.Parse(fNode.InnerText);
            }
            catch { return false; }
        }

        public static bool ReadXmlProp_Boolean(XmlNode n, String strName, bool def)
        {
            try
            {
                XmlNode fNode = n.SelectSingleNode(strName);
                if (fNode == null)
                    return def;

                return Boolean.Parse(fNode.InnerText);
            }
            catch { return def; }
        }

        public static String GetTopLevelFolderName(String s)
        {
            String[] ary = nTools.Split(s, "\\");

            if (s.EndsWith("\\"))
                return ary[ary.Length - 2];
            else
                return ary[ary.Length - 1];
        }

        public static String EncodeForXml(String s)
        {
            return s.Replace("&", "&amp;").Replace("<", "&lt;");
        }

        public static bool BinCpy(String strOriginal, String strNew)
        {
            try
            {
                FileInfo f = new FileInfo(strOriginal);
                BinaryWriter w = new BinaryWriter(new FileStream(strNew, FileMode.CreateNew, FileAccess.Write));
                BinaryReader r = new BinaryReader(new FileStream(strOriginal, FileMode.Open, FileAccess.Read));
                w.Write(r.ReadBytes(Convert.ToInt32(f.Length)));

                r.Close();
                r = null;
                w.Close();
                w = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean StrExt(String s)
        {
            if (s == null)
                return false;
            if (s.Trim().Length <= 0)
                return false;
            return true;
        }
        public static String GetNewID()
        {
            System.Guid x = System.Guid.NewGuid();
            return x.ToString().Replace("-", "");
        }
        public static Boolean StrCmp(String s1, String s2)
        {
            if (s1 == null)
                return false;
            if (s2 == null)
                return false;
            return (s1.ToLower().Trim() == s2.ToLower().Trim());
        }

        public static String GetLocalIP()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress i = ipHostInfo.AddressList[0];
                return i.ToString();
            }
            catch
            {
                return "0.0.0.0";
            }
        }

        public static bool SaveFileAsString(String strFileName, String strData)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(strFileName, false);
                file.Write(strData);
                file.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SaveFileAsString(String strFileName, String strData, FileMode mode)
        {
            try
            {
                using (Stream str = new FileStream(strFileName, mode))
                using (TextWriter writer = new StreamWriter(str))
                {
                    writer.Write(strData);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static String OpenFileAsString(String strFile)
        {
            String s;
            try
            {
                System.IO.StreamReader w = new System.IO.StreamReader(strFile);
                s = w.ReadToEnd();
                w.Close();
                return s;
            }
            catch
            {
                return "";
            }
        }

        public static bool Shell(String strFilePath)
        {
            return Shell(strFilePath, "");
        }

        public static bool Shell(String strFilePath, String strArguments)
        {
            return Shell(strFilePath, strArguments, new StringBuilder(), false, false);

        }

        public static void ShellSilently(String strFilePath)
        {
            Process target = new Process();
            target.StartInfo.FileName = strFilePath;
            target.StartInfo.UseShellExecute = true;
            target.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            target.StartInfo.CreateNoWindow = true;
            target.Start();
        }

        public static bool Shell(String strFilePath, String strArguments, StringBuilder sb, bool NoWindow, bool WaitForDone)
        {
            try
            {

                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.FileName = strFilePath;
                x.StartInfo.Arguments = strArguments;
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                if (NoWindow)
                {
                    x.StartInfo.CreateNoWindow = true;
                }
                x.Start();

                if (WaitForDone)
                    x.WaitForExit(10000);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ShellAndViewOutput(String strFilePath, String strArguments, ref String output, String strIgnore)
        {
            try
            {
                output = "";
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.FileName = strFilePath;
                x.StartInfo.Arguments = strArguments;
                x.StartInfo.RedirectStandardOutput = true;
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                x.StartInfo.UseShellExecute = false;
                //if (NoWindow)
                //{
                x.StartInfo.CreateNoWindow = true;
                //}
                x.Start();

                string str;
                while ((str = x.StandardOutput.ReadLine()) != null)
                {
                    if (nTools.StrExt(strIgnore))
                    {
                        if (!nTools.HasString(str, strIgnore))
                            output += str + "\r\n";
                    }
                    else
                        output += str + "\r\n";
                }
                return true;
            }
            catch
            {
                output = "";
                return false;
            }
        }

        //////Null Filters
        public static Object ReplaceNull(Int32 xType)
        {
            Int32 i;
            Int64 l;
            Double d;
            DateTime t;
            switch (xType)
            {
                case (Int32)Enums.DataType.String:
                case (Int32)Enums.DataType.List:
                case (Int32)Enums.DataType.Memo:
                    return "";
                case (Int32)Enums.DataType.Integer:
                case (Int32)Enums.DataType.Boolean:
                    i = 0;
                    return (Object)(i);
                case (Int32)Enums.DataType.Long:
                    l = 0;
                    return (Object)(l);
                case (Int32)Enums.DataType.Float:
                    d = 0;
                    return (Object)(d);
                case (Int32)Enums.DataType.Date:
                    t = Convert.ToDateTime("01/01/1900");
                    return (Object)(t);
                default:
                    return "";
            }
        }

        //public static String CStr(Object i)
        //{
        //    if (i == null)
        //        return "";

        //    return i.ToString();
        //}

        //public static String Format(String strFormat, Object o)
        //{
        //    try
        //    {
        //        switch (strFormat.ToLower())
        //        {
        //            case "yn":
        //                if (Convert.ToBoolean(o))
        //                { return "Y"; }
        //                else
        //                { return "N"; }
        //                break;
        //            case "hms":
        //                return FormatHMS(Convert.ToInt64(o));
        //            //case "###,##0.00":
        //            //    return System.String.Format(

        //            //case "###,##0.00##":
        //            //case "###,##0.0000":
        //            //case "###,##0.00":
        //            //case "mm/dd/yy":
        //            //case "mm/dd/yyyy":
        //            //case "mm/dd/yy hh:mm:ss":
        //            //case "mm/dd":
        //            //case "mm/dd hh:mm":

        //            default:
        //                return String.Format(strFormat, o);
        //                break;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return Convert.ToString(o);
        //    }
        //}

        //public static System.Drawing.Color GetColorFromInt(int c)
        //{
        //    switch (c)
        //    {
        //        case 0:
        //            return System.Drawing.Color.Black;
        //        case 1:
        //            return System.Drawing.Color.Blue;
        //        case 2:
        //            return System.Drawing.Color.Red;
        //        case 3:
        //            return System.Drawing.Color.Green;
        //        case 4:
        //            return System.Drawing.Color.Yellow;
        //        default:
        //            return System.Drawing.Color.FromArgb(c);
        //    }
        //}

        //public static int GetIntFromColor(System.Drawing.Color c)
        //{
        //    if (c == System.Drawing.Color.Blue)
        //        return 1;

        //    if (c == System.Drawing.Color.Red)
        //        return 2;

        //    if (c == System.Drawing.Color.Green)
        //        return 3;

        //    if (c == System.Drawing.Color.Yellow)
        //        return 4;

        //    return 0;
        //}

        //public static String YesBlankFilter(bool b)
        //{
        //    if (b)
        //        return "Y";
        //    else
        //        return "";
        //}

        //public static String YesNoFilter(bool b)
        //{
        //    if (b)
        //        return "Y";
        //    else
        //        return "N";
        //}

        //public static void MakeFolderExist(String f)
        //{
        //    try
        //    {
        //        System.IO.Directory.CreateDirectory(f);
        //    }
        //    catch (Exception e)
        //    { }
        //}

        //public static String NiceFormat(String s)
        //{
        //    s = s.Replace(" ", "_");
        //    s = s.Replace("__", "_");

        //    String[] a = s.Split("_".ToCharArray());
        //    String c = "";
        //    foreach (String b in a)
        //    {
        //        if (nTools.StrExt(c))
        //            c += " ";

        //        if (b.Length > 0)
        //        {
        //            c += b.Substring(0, 1).ToUpper();

        //            if (b.Length > 1)
        //                c += b.Substring(1).ToLower();
        //        }
        //    }
        //    return c;
        //}

        public static bool PopText(String s)
        {
            string file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "pop.txt";
            SaveFileAsString(file, s);
            return PopTextFile(file);
        }

        public static bool PopTextFile(String strFile)
        {
            return Shell("notepad.exe", strFile);
        }

        public static Int64 GetTicks()
        {
            return Environment.TickCount;
        }

        public static String GetAppPath()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim()));
            if (Right(sb.ToString(), 1) != "\\")
                sb.Append("\\");

            return sb.ToString();
        }

        public static String GetAppParentPath()
        {
            return GetDirectoryParent(GetAppPath());
        }

        public static String GetDirectoryParent(String s)
        {
            String[] ary = s.Split("\\".ToCharArray());
            StringBuilder b = new StringBuilder();

            for (int i = 0; i < ary.Length - 2; i++)
            {
                b.Append(ary[i]);
                b.Append("\\");
            }
            return ConditionFolderName(b.ToString());
        }

        public static String Right(String strIn, int len)
        {
            try
            {
                return strIn.Substring(strIn.Length - len, len);
            }
            catch
            {
                return "";
            }
        }

        public static String Left(String strIn, int len)
        {

            try
            {
                if (len >= strIn.Length)
                    return strIn;
                else if (!StrExt(strIn))
                    return "";
                else
                    return strIn.Substring(0, len);
            }
            catch
            {
                return "";
            }
        }

        public static DateTime GetBlankDate()
        {
            return DateTime.Parse("01/01/1900");
        }

        public static bool DateExists(DateTime d)
        {
            if (d == null)
                return false;

            return d > Convert.ToDateTime("01/02/1900");
        }

        //public static void MakeBackup(String f)
        //{
        //    if (System.IO.File.Exists(f))
        //    {
        //        String b = n_data_target.dCodePath + "bak\\" + System.IO.Path.GetFileNameWithoutExtension(f) + "_" + Convert.ToString(System.DateTime.Now.Year) + "_" + Convert.ToString(System.DateTime.Now.Month) + "_" + Convert.ToString(System.DateTime.Now.Day) + "_" + Convert.ToString(System.DateTime.Now.Hour) + "_" + Convert.ToString(System.DateTime.Now.Minute) + "_" + Convert.ToString(System.DateTime.Now.Second) + "_" + GetNewID() + System.IO.Path.GetExtension(f);
        //        System.IO.File.Copy(f, b);
        //    }
        //}

        public static bool HasString(string str, string f)
        {
            if (str == null)
                return false;

            if (f == null)
                return false;

            long l = str.ToLower().IndexOf(f.ToLower());
            return l >= 0;
        }

        //public static bool HasString(string str, string[] f)
        //{
        //    foreach (String s in f)
        //    {
        //        if (HasString(str, s))
        //            return true;

        //    }
        //    return false;
        //}

        //public static String Space(int l)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < l; i++)
        //    {
        //        sb.Append(" ");
        //    }
        //    return sb.ToString();
        //}

        //public static int GetIconIndex(Enums.IconType t)
        //{
        //    switch (t)
        //    {
        //        case Enums.IconType.Class:
        //            return 1;
        //        case Enums.IconType.Property:
        //            return 2;
        //        case Enums.IconType.Method:
        //            return 3;
        //        case Enums.IconType.GuidedClass:
        //            return 4;
        //        case Enums.IconType.GuidedProperty:
        //            return 2;
        //        case Enums.IconType.GuidedMethod:
        //            return 3;
        //        default:
        //            return 0;
        //    }
        //}

        public static string StripNonAlphaNumeric(String s, bool AllowUnderscores)
        {
            String c;
            String r = "";
            for (int i = 0; i < s.Length; i++)
            {
                c = s.Substring(i, 1);
                if ((c.ToLower().CompareTo("a") >= 0 && c.ToLower().CompareTo("z") <= 0) || (c.ToLower().CompareTo("0") >= 0 && c.ToLower().CompareTo("9") <= 0))
                {
                    r += c;
                }
                else
                {
                    if (c == "_" && AllowUnderscores)
                    {
                        r += c;
                    }
                }

            }
            return r;
        }

        //public static string StripNonNumeric(String s)
        //{
        //    return StripNonNumeric(s, false);
        //}

        //public static string StripNonNumeric(String s, bool AllowPeriods)
        //{
        //    String c;
        //    String r = "";
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        c = s.Substring(i, 1);
        //        if ((c.ToLower().CompareTo("0") >= 0 && c.ToLower().CompareTo("9") <= 0))
        //        {
        //            r += c;
        //        }
        //        else
        //        {
        //            if (c == "." && AllowPeriods)
        //            {
        //                r += c;
        //            }
        //        }

        //    }
        //    return r;
        //}

        public static bool HasFileName(String s)
        {
            return nTools.StrExt(System.IO.Path.GetFileName(s));
        }

        public static string GetNowPath()
        {
            String s = DateTime.Now.Year.ToString() + "_";

            if (DateTime.Now.Month <= 9)
                s += "0" + DateTime.Now.Month.ToString();
            else
                s += DateTime.Now.Month.ToString();

            s += "_";

            if (DateTime.Now.Day <= 9)
                s += "0" + DateTime.Now.Day.ToString();
            else
                s += DateTime.Now.Day.ToString();

            return s;
        }

        //public static void DropCrumb(String strName, String strValue)
        //{
        //    SaveFileAsString(GetAppPath() + strName + "cmb", strValue);
        //}

        //public static string GetCrumb(String strName)
        //{
        //    return OpenFileAsString(GetAppPath() + strName + "cmb");
        //}

        //public static String GetFirstLine(String s)
        //{
        //    try
        //    {
        //        String[] ary = nTools.Split(s, "\r\n");
        //        return ary[0];
        //    }
        //    catch (Exception)
        //    {
        //        return "";
        //    }
        //}

        public static String ParseDelimit(String strIn, String s, int p)
        {
            try
            {
                if (!nTools.StrExt(strIn))
                    return "";

                String[] a = strIn.Split(new String[] { s }, StringSplitOptions.None);

                if (a.Length == 0)
                    return "";

                if (a.Length < (p - 1))
                    return "";

                if (a.Length == 1)
                {
                    if (p == 1)
                        return a[0];
                    else
                        return "";
                }

                return a[p - 1];
            }
            catch (Exception)
            { return ""; }
        }

        //public static String FilterPhoneNumber(String strPhone)
        //{
        //    return FilterPhoneNumber(strPhone, "");
        //}

        //public static String FilterPhoneNumber(String strPhone, String strAreaCode)
        //{
        //    strPhone = FilterEverythingButNumbers(strPhone);
        //    if (strPhone.StartsWith("1") && strPhone.Length > 10)
        //        strPhone = Mid(strPhone, 2);

        //    if (strPhone.Length == 7)
        //    {
        //        if (nTools.StrExt(strAreaCode))
        //            strPhone = strAreaCode + strPhone;
        //    }

        //    return strPhone;
        //}

        //public static ArrayList GetUniqueStrings(ArrayList a, ArrayList b)
        //{
        //    ArrayList c = new ArrayList();
        //    foreach (String s in a)
        //    {
        //        if (!IsInArray(s, c))
        //            c.Add(s);
        //    }

        //    foreach (String s in b)
        //    {
        //        if (!IsInArray(s, c))
        //            c.Add(s);
        //    }

        //    return c;
        //}

        public static String GetHighestFileName(String strFolder, String strBaseName)
        {
            String s = "";
            GetHighestFileNumber(strFolder, strBaseName, ref s);
            return s;
        }

        public static SortedList GetHighestFileCollection(String strFolder)
        {
            SortedList hold = new SortedList();

            if (!System.IO.Directory.Exists(strFolder))
                return hold;

            String strBase;
            NumberedFile nf;
            Int64 num;

            String[] files = System.IO.Directory.GetFiles(strFolder);
            foreach (String f in files)
            {
                String fl = System.IO.Path.GetFileName(f);

                strBase = nTools.RemoveNumberedFileName(fl);
                num = GetFileNumber(fl);

                nf = (NumberedFile)hold[strBase.ToLower()];
                if (nf == null)
                {
                    nf = new NumberedFile();
                    nf.FileBase = strBase;
                    nf.FilePath = fl;
                    nf.HighestNumber = num;
                    hold.Add(nf.FileBase.ToLower(), nf);
                }
                else
                {
                    if (num > nf.HighestNumber)
                    {
                        nf.FilePath = fl;
                    }
                }
            }
            return hold;
        }

        public static String RemoveNumberedFileName(String strFile)
        {
            int mark;
            mark = strFile.IndexOf("__");
            if (mark >= 0)
                return Left(strFile, mark) + Path.GetExtension(strFile);
            else
                return strFile;
        }

        public static Int64 GetHighestFileNumber(String[] files, String strBaseName, ref String strActualName)
        {
            Int64 h = -1;
            String sh = "";

            foreach (String s in files)
            {
                String b = nTools.RemoveNumberedFileName(System.IO.Path.GetFileName(s));
                if (nTools.StrCmp(b, strBaseName))
                {
                    Int64 v = GetFileNumber(s);
                    if (v > h)
                    {
                        h = v;
                        sh = s;
                    }
                }
            }

            strActualName = sh;
            return h;
        }

        public static Int64 GetHighestFileNumber(String strFolder, String strBaseName)
        {
            String s = "";
            return GetHighestFileNumber(strFolder, strBaseName, ref s);
        }

        public static Int64 GetHighestFileNumber(String strFolder, String strBaseName, ref String strActualName)
        {
            String strBase;
            String strExt;
            String strHighest = "";

            strBase = Path.GetFileNameWithoutExtension(strBaseName);
            strExt = Path.GetExtension(strBaseName);

            if (strBase.IndexOf("__") > 0)
                strBase = ParseDelimit(strBase, "__", 1);

            //strActualName = "";

            Int64 highest = -1;
            Int64 number = 0;

            if (!System.IO.Directory.Exists(strFolder))
                return -1;

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strFolder);

            System.IO.FileInfo[] files = di.GetFiles();
            String strName;

            for (int i = 0; i < files.Length; i++)
            {

                strName = files[i].Name;
                if ((strName.ToLower().StartsWith(strBase.ToLower() + "__") && strName.ToLower().EndsWith(strExt.ToLower())) || StrCmp(strName, strBase + strExt))
                {
                    number = GetFileNumber(strName);
                    if (number > highest)
                    {
                        highest = number;
                        strHighest = strName;
                    }

                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Highest = ");
            sb.Append(highest);

            if (strActualName != null)
                strActualName = strHighest;

            return highest;
        }

        public static Int64 GetFileNumber(String strFileName)
        {
            String strBase = Path.GetFileNameWithoutExtension(strFileName);
            if (strBase.IndexOf("__") < 0)
                return 0;

            strBase = ParseDelimit(strBase, "__", 2);
            try
            {
                return System.Convert.ToInt64(strBase);
            }
            catch
            {
                return -1;
            }
        }

        public static String InsertNumberedFileName(String strName, Int64 num)
        {
            String strFile = Right(String.Concat("0000000", num.ToString()), 7);
            strFile = String.Concat(Path.GetFileNameWithoutExtension(strName), "__", strFile, Path.GetExtension(strName));
            return strFile;
        }

        public static String GetNextNumberedFileName(String strFolder, String strName)
        {
            Int64 current;
            String s = "";
            current = GetHighestFileNumber(strFolder, strName, ref s);
            current++;
            return InsertNumberedFileName(strName, current);
        }

        public static bool DownloadInternetFile(String strURL, String strLocalFile)
        {
            try
            {
                WebClient Client = new WebClient();
                Client.DownloadFile(strURL, strLocalFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static String DownloadInternetFileAsString(String strURL)
        {
            try
            {
                String strLocalFile = GetAppPath() + "temp_web_download.txt";
                WebClient Client = new WebClient();
                Client.DownloadFile(strURL, strLocalFile);
                return OpenFileAsString(strLocalFile);
            }
            catch
            {
                return "";
            }
        }

        //public static string GetVersionString()
        //{
        //    FileVersionInfo fvi = GetFileVersionInfo();
        //    return fvi.ProductMajorPart.ToString() + "." + fvi.ProductMinorPart.ToString() + "." + fvi.ProductBuildPart.ToString() + "." + fvi.ProductPrivatePart.ToString();
        //}

        //public static FileVersionInfo GetFileVersionInfo()
        //{
        //    Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        //    return FileVersionInfo.GetVersionInfo(assembly.Location);
        //}

        //public static long GetVersionNumber()
        //{
        //    FileVersionInfo fvi = GetFileVersionInfo();
        //    return (fvi.ProductMajorPart * 10000000) + (fvi.ProductMinorPart * 100000) + (fvi.ProductBuildPart * 1000) + fvi.ProductPrivatePart;
        //}

        //public static int ChooseColor(System.Windows.Forms.IWin32Window owner)
        //{
        //    System.Windows.Forms.ColorDialog f = new ColorDialog();
        //    f.ShowDialog(owner);
        //    return f.Color.ToArgb();
        //}

        //public static String GetIDString(ArrayList l)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    bool b = true;

        //    foreach (nObject o in l)
        //    {
        //        if (!b)
        //        {
        //            sb.Append(", ");
        //        }

        //        sb.Append("'" + o.unique_id + "'");
        //        b = false;
        //    }
        //    return sb.ToString();
        //}

        //public static String GetIDString(SortedList l)
        //{
        //    nObject o;
        //    StringBuilder sb = new StringBuilder();
        //    bool b = true;

        //    foreach (DictionaryEntry d in l)
        //    {
        //        o = (nObject)d.Value;

        //        if (!b)
        //        {
        //            sb.Append(", ");
        //        }

        //        sb.Append("'" + o.unique_id + "'");
        //        b = false;
        //    }
        //    return sb.ToString();
        //}

        //public static void LoadChoicesCombo(System.Windows.Forms.ComboBox cbo, n_choices choices)
        //{
        //    if (cbo == null)
        //        return;

        //    if (choices == null)
        //        return;

        //    cbo.Items.Clear();
        //    foreach (n_choice c in choices.AllChoices)
        //    {
        //        cbo.Items.Add(c.name);
        //    }
        //}

        //public static void SetOnMouse(System.Windows.Forms.Form xForm)
        //{

        //    Enums.ScreenQuadrant x = GetMouseQuadrant();
        //    System.Drawing.Point p = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);

        //    switch (x)
        //    {
        //        case NewMethod.Enums.ScreenQuadrant.TopLeft:
        //            xForm.Left = p.X;
        //            xForm.Top = p.Y;
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.TopCenter:
        //            xForm.Left = p.X - (xForm.Width / 2);
        //            xForm.Top = p.Y;
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.TopRight:
        //            xForm.Left = p.X - xForm.Width;
        //            xForm.Top = p.Y;
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.MidLeft:
        //            xForm.Left = p.X;
        //            xForm.Top = p.Y - (xForm.Height / 2);
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.MidCenter:
        //            xForm.Top = p.Y - (xForm.Height / 2);
        //            xForm.Left = p.X - (xForm.Width / 2);
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.MidRight:
        //            xForm.Top = p.Y - (xForm.Height / 2);
        //            xForm.Left = p.X - xForm.Width;
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.BottomLeft:
        //            xForm.Left = p.X;
        //            xForm.Top = p.Y - xForm.Height;
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.BottomCenter:
        //            xForm.Left = p.X - (xForm.Width / 2);
        //            xForm.Top = p.Y - xForm.Height;
        //            break;
        //        case NewMethod.Enums.ScreenQuadrant.BottomRight:
        //            xForm.Left = p.X - xForm.Width;
        //            xForm.Top = p.Y - xForm.Height;
        //            break;
        //    }
        //}

        //public static Enums.ScreenQuadrant GetMouseQuadrant()
        //{
        //    int w = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
        //    w = w / 3;

        //    int x = System.Windows.Forms.Cursor.Position.X;

        //    int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
        //    y = y / 3;

        //    int z = System.Windows.Forms.Cursor.Position.Y;

        //    if (x <= w)  //left
        //    {
        //        if (z <= y)  //top
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.TopLeft;
        //        }
        //        else if (z < (y * 2))  //middle
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.MidLeft;
        //        }
        //        else  //bottom
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.BottomLeft;
        //        }
        //    }
        //    else if (x < (w * 2))  //center
        //    {
        //        if (z <= y)  //top
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.TopCenter;
        //        }
        //        else if (z < (y * 2))  //middle
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.MidCenter;
        //        }
        //        else  //bottom
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.BottomCenter;
        //        }
        //    }
        //    else  //right
        //    {
        //        if (z <= y)  //top
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.TopRight;
        //        }
        //        else if (z < (y * 2))  //middle
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.MidRight;
        //        }
        //        else  //bottom
        //        {
        //            return NewMethod.Enums.ScreenQuadrant.BottomRight;
        //        }

        //    }

        //}

        //private static String[] TrashKeys_OnlySymbols;
        //public static String[] GetTrashKeys_OnlySymbols()
        //{
        //    if (TrashKeys_OnlySymbols != null)
        //        return TrashKeys_OnlySymbols;
        //    String s = "!|&|+|-|/|)|(| |'|\r|\n|\t|.|,|\\|*|#|:|[|]|%|{|}|`|~|$|_";
        //    TrashKeys_OnlySymbols = s.Split("|".ToCharArray());
        //    return TrashKeys_OnlySymbols;
        //}

        //private static String[] TrashKeys_FileName;
        //public static String[] GetTrashKeys_FileName()
        //{
        //    if (TrashKeys_FileName != null)
        //        return TrashKeys_FileName;
        //    String s = "!|&|+|-|/|)|(| |'|\r|\n|\t|,|\\|*|#|:|[|]|%|{|}|`|~|$";
        //    TrashKeys_FileName = s.Split("|".ToCharArray());
        //    return TrashKeys_FileName;
        //}

        //private static String[] TrashKeys_Numbers;
        //public static String[] GetTrashKeys_Numbers()
        //{
        //    if (TrashKeys_Numbers != null)
        //        return TrashKeys_Numbers;

        //    String s = "+|011|-|/|)|(| |'|\"|.|,|*|ext|#|x|:|0|1|2|3|4|5|6|7|8|9|[|]";
        //    TrashKeys_Numbers = s.Split("|".ToCharArray());
        //    return TrashKeys_Numbers;
        //}

        //private static String[] TrashKeys;
        //public static String[] GetTrashKeys()
        //{
        //    if (TrashKeys != null)
        //        return TrashKeys;

        //    String s = "+|011|-|/|)|(| |'|\"|.|,|*|ext|#|x|:|[|]";
        //    TrashKeys = s.Split("|".ToCharArray());
        //    return TrashKeys;
        //}

        //public static String FilterEverythingButNumbers(String strIn)
        //{
        //    String r = "";
        //    for (int i = 0; i < strIn.Length; i++)
        //    {
        //        String c = Mid(strIn, i + 1, 1);
        //        switch (c)
        //        {
        //            case "0":
        //            case "1":
        //            case "2":
        //            case "3":
        //            case "4":
        //            case "5":
        //            case "6":
        //            case "7":
        //            case "8":
        //            case "9":
        //                r += c;
        //                break;
        //        }
        //    }
        //    return r;
        //}

        //public static String FilterTrash(String strIn)
        //{
        //    return FilterTrash(strIn, false, true);
        //}

        //public static String FilterFileNameTrash(String s)
        //{
        //    return BulkReplace(s, nTools.GetTrashKeys_FileName());
        //}

        //public static String FilterTrash(String strIn, bool RemoveNumbers, bool OnlySymbols)
        //{
        //    if (OnlySymbols)
        //    {
        //        return BulkReplace(strIn, nTools.GetTrashKeys_OnlySymbols());
        //    }
        //    else
        //    {
        //        if (RemoveNumbers)
        //        {
        //            return BulkReplace(strIn, nTools.GetTrashKeys_Numbers());
        //        }
        //        else
        //        {
        //            return BulkReplace(strIn, nTools.GetTrashKeys());
        //        }
        //    }
        //}

        //public static bool FilterTrashField(nData xd, String strTable, String strField, bool RemoveNumbers, bool OnlySymbols)
        //{
        //    if (OnlySymbols)
        //    {
        //        return BulkReplaceField(xd, strTable, strField, nTools.GetTrashKeys_OnlySymbols());
        //    }
        //    else
        //    {
        //        if (RemoveNumbers)
        //        {
        //            return BulkReplaceField(xd, strTable, strField, nTools.GetTrashKeys_Numbers());
        //        }
        //        else
        //        {
        //            return BulkReplaceField(xd, strTable, strField, nTools.GetTrashKeys());
        //        }
        //    }
        //}

        //public static String BulkReplace(String s, String[] r)
        //{
        //    String v = s;
        //    foreach (String x in r)
        //    {
        //        v = v.Replace(x, "");
        //    }
        //    return v;
        //}

        //public static bool BulkReplaceField(nData xd, String strTable, String strField, String[] r)
        //{
        //    foreach (String x in r)
        //    {
        //        if (!xd.Execute("update " + strTable + " set " + strField + " = replace(" + strField + ", '" + xd.SyntaxFilter(x) + "', '')"))
        //            return false;

        //        //v = v.Replace(x, "");
        //    }
        //    return true;
        //}

        //public static bool GetControlKey()
        //{
        //    return ((Control.ModifierKeys & Keys.Control) == Keys.Control);
        //}

        //public static bool GetShiftKey()
        //{
        //    return ((Control.ModifierKeys & Keys.Shift) == Keys.Shift);
        //}

        //public static bool GetControlAndShiftKeys()
        //{
        //    return (GetControlKey() && GetShiftKey());
        //}

        //public static string StrReplace(string original, string pattern, string replacement)
        //{
        //    int count, position0, position1;
        //    count = position0 = position1 = 0;
        //    string upperString = original.ToUpper();
        //    string upperPattern = pattern.ToUpper();
        //    int inc = (original.Length / pattern.Length) *
        //              (replacement.Length - pattern.Length);
        //    char[] chars = new char[original.Length + Math.Max(0, inc)];
        //    while ((position1 = upperString.IndexOf(upperPattern,
        //                                      position0)) != -1)
        //    {
        //        for (int i = position0; i < position1; ++i)
        //            chars[count++] = original[i];
        //        for (int i = 0; i < replacement.Length; ++i)
        //            chars[count++] = replacement[i];
        //        position0 = position1 + pattern.Length;
        //    }
        //    if (position0 == 0) return original;
        //    for (int i = position0; i < original.Length; ++i)
        //        chars[count++] = original[i];
        //    return new string(chars, 0, count);
        //}

        //public static String MoneyFormat_2_6(Double d)
        //{
        //    return String.Format("{0:###,###,##0.00####}", d);
        //}

        public static String DateFormat(DateTime d)
        {
            if (nTools.DateExists(d))
                return String.Format("{0:d}", d);
            else
                return "";
        }

        //public static String TimeFormat(DateTime d)
        //{
        //    if (nTools.DateExists(d))
        //        return String.Format("{0:t}", d);
        //    else
        //        return "";
        //}

        //public static String TimeFormat_WithSeconds(DateTime d)
        //{
        //    if (nTools.DateExists(d))
        //        return String.Format("{0:T}", d);
        //    else
        //        return "";
        //}

        //public static long DivideWithFractions(long lng1, long lng2)
        //{
        //    return Convert.ToInt64(Convert.ToDouble(lng1) / Convert.ToDouble(lng2));
        //}

        //public static String DateFormat_ShortDateTime(DateTime d)
        //{
        //    if (nTools.DateExists(d))
        //        return String.Format("{0:g}", d);
        //    else
        //        return "";
        //}

        //public static String DateFormat_Extra(DateTime d)
        //{
        //    String strExtra = "";

        //    if (d > System.DateTime.Now)
        //        return nTools.DateFormat(d);

        //    TimeSpan t = System.DateTime.Now.Subtract(d);

        //    if (t.Days <= 0)
        //        strExtra = " (today)";
        //    else if (t.Days <= 0)
        //        strExtra = " (yesterday)";
        //    else if (t.Days < 100)
        //        strExtra = " (" + t.Days.ToString() + " days ago)";
        //    else
        //        strExtra = "";

        //    return nTools.DateFormat(d) + strExtra;
        //}

        //public static String Trim(String s)
        //{
        //    return s.Trim();
        //}

        public static String[] Split(String strIn, String strSplit)
        {
            return strIn.Split(new String[] { strSplit }, StringSplitOptions.None);
        }

        //public static void SplitInTwo(String start, ref String str1, ref String str2, String split)
        //{
        //    int i = start.IndexOf(split);
        //    if (i == -1)
        //    {
        //        str1 = start;
        //        str2 = "";
        //        return;
        //    }

        //    str1 = start.Substring(0, i);
        //    str2 = start.Substring(i + 1);
        //}

        //public static ArrayList SplitArray(String strIn, String strSplit)
        //{
        //    String[] s = nTools.Split(strIn, strSplit);
        //    return ToArray(s);
        //}

        //public static ArrayList ToArray(String[] ary)
        //{
        //    ArrayList a = new ArrayList();
        //    foreach (String s in ary)
        //    {
        //        a.Add(s);
        //    }
        //    return a;
        //}

        public static String LongFormat(Double d)
        {
            return String.Format("{0:###,###,###,##0}", Convert.ToInt64(d));
        }

        public static String LongFormat(long l)
        {
            return String.Format("{0:###,###,###,##0}", l);
        }

        public static String LongFormat(int i)
        {
            return String.Format("{0:###,###,###,##0}", i);
        }

        //public static bool IsInCollection(String strFind, SortedList s)
        //{
        //    Object o = s[strFind];
        //    return (o != null);
        //}

        //public static String MoneyFilter(String s)
        //{
        //    return s.Replace(",", "").Trim().Replace("$", "");
        //}

        //public static Double MoneyFilterAsDouble(String s)
        //{
        //    try
        //    {
        //        s = MoneyFilter(s);
        //        if (IsNumeric(s))
        //            return Convert.ToDouble(s);
        //        else
        //            return 0;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}

        //public static String QuantityFilter(String s)
        //{
        //    s = nTools.Replace(s.Replace(",", "").Trim(), "K", "000");
        //    if (s.StartsWith("."))
        //        s = nTools.Mid(s, 2);
        //    s = ParseDelimit(s, ".", 1);
        //    return s;
        //}

        //public static long QuantityFilterAsLong(String s)
        //{
        //    try
        //    {
        //        s = QuantityFilter(s);
        //        if (IsNumeric(s))
        //            return Convert.ToInt64(s);
        //        else
        //            return 0;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}

        //public static String MoneyFormat(Double d)
        //{
        //    return String.Format("{0:###,###,###,##0.00}", d);
        //}

        public static String ConditionFolderName(String s)
        {
            if (nTools.Right(s, 1) == "\\")
                return s;
            else
                return s + "\\";
        }

        //public static DateTime BuildDate_YM(int year, int month)
        //{
        //    try
        //    {
        //        return DateTime.Parse(month.ToString() + "/01/" + year.ToString());
        //    }
        //    catch (Exception)
        //    {
        //        return nTools.GetNullDate();
        //    }
        //}

        //public static bool CheckReadWrite(String strFolder)
        //{
        //    String s = "";
        //    return CheckReadWrite(strFolder, ref s);
        //}

        //public static bool CheckReadWrite(String strFolder, ref String strCool)
        //{
        //    String strID = nTools.GetNewID();

        //    if (!System.IO.Directory.Exists(strFolder))
        //    {
        //        if (strFolder.StartsWith("\\\\"))
        //        {
        //            TryUnlockFolder(strFolder);
        //        }

        //        if (!System.IO.Directory.Exists(strFolder))
        //        {
        //            strCool = "Folder Not Found";
        //            return false;
        //        }
        //    }

        //    if (!nTools.WriteTestFile(strFolder))
        //    {
        //        if (strFolder.StartsWith("\\\\"))
        //        {
        //            TryUnlockFolder(strFolder);
        //        }

        //        if (!WriteTestFile(strFolder, ref strCool))
        //            return false;
        //    }

        //    return true;
        //}

        //public static void TryUnlockFolder(String strFolder)
        //{
        //    nTools.Shell("explorer", strFolder);
        //    return;
        //}

        //public static bool WriteTestFile(String strFolder)
        //{
        //    String s = "";
        //    return WriteTestFile(strFolder, ref s);
        //}

        //public static bool WriteTestFile(String strFolder, ref String strCool)
        //{
        //    String strID = nTools.GetNewID();
        //    String strFile = ConditionFolderName(strFolder) + strID + ".txt";
        //    nTools.SaveFileAsString(strFile, "test");

        //    String strD = nTools.OpenFileAsString(strFile);
        //    if (!nTools.StrCmp(strD, "test"))
        //        return false;

        //    try
        //    {
        //        System.IO.File.Delete(strFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        strCool = ex.Message;
        //        return false;
        //    }
        //    return true;
        //}

        //public static ArrayList GetFileCollection(String strFolder, String strBase)
        //{
        //    ArrayList r = new ArrayList();
        //    String[] s = System.IO.Directory.GetFiles(strFolder);
        //    foreach (String x in s)
        //    {
        //        String f = System.IO.Path.GetFileName(x);
        //        String b = RemoveNumberedFileName(f);
        //        if (nTools.StrCmp(b, strBase))
        //        {
        //            r.Add(x);
        //        }
        //    }
        //    return r;
        //}

        //public static void TryDeleteFile(String strFile)
        //{
        //    try
        //    {
        //        System.IO.File.Delete(strFile);
        //    }
        //    catch (Exception)
        //    { }
        //}

        //public static bool IsIn(String strStart, String strLook)
        //{
        //    String[] a = strLook.Split(new String[] { "|" }, StringSplitOptions.None);
        //    foreach (String s in a)
        //    {
        //        if (nTools.StrCmp(s, strStart))
        //            return true;
        //    }
        //    return false;
        //}

        //public static String GetIn(ArrayList a)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    int x = 0;
        //    foreach (String s in a)
        //    {
        //        if (nTools.StrExt(s))
        //        {
        //            if (x > 0)
        //                sb.Append(", ");

        //            sb.Append("'" + s.Replace("'", "''") + "'");
        //            x++;
        //        }
        //    }
        //    return sb.ToString();
        //}

        //public static ArrayList ConvertToArray(SortedList s)
        //{
        //    ArrayList a = new ArrayList();
        //    foreach (DictionaryEntry d in s)
        //    {
        //        a.Add(d.Value);
        //    }
        //    return a;
        //}

        public static DateTime GetNullDate()
        {
            return DateTime.Parse("01/01/1900");
        }

        //public static bool IsEmailAddress(String s)
        //{
        //    if (nTools.HasString(s, ".."))
        //        return false;

        //    if (nTools.HasString(s, ","))
        //        return false;

        //    if (nTools.HasString(s, ";"))
        //        return false;

        //    if (nTools.HasString(s, ":"))
        //        return false;

        //    if (nTools.HasString(s.Trim(), " "))
        //        return false;

        //    String s1 = nTools.ParseDelimit(s, "@", 1);
        //    String s2 = nTools.ParseDelimit(s, "@", 2);

        //    String se = nTools.ParseDelimit(s2, ".", 2);

        //    if (s1.Length > 40)
        //        return false;

        //    if (s2.Length > 60)
        //        return false;

        //    if (se.Length > 40)
        //        return false;

        //    if (nTools.HasString(s1, "@"))
        //        return false;

        //    if (nTools.HasString(s2, "@"))
        //        return false;

        //    if (nTools.HasString(se, "@"))
        //        return false;

        //    return nTools.StrExt(s1) && nTools.StrExt(s2) && nTools.StrExt(se);
        //}

        //public static String ReplaceVisualAll(String s)
        //{
        //    s = nTools.ReplaceVisual(s, "s", "5", "");
        //    s = nTools.ReplaceVisual(s, "y", "4", "");
        //    s = nTools.ReplaceVisual(s, "l", "1", "i");
        //    s = nTools.ReplaceVisual(s, "o", "0", "");
        //    s = nTools.ReplaceVisual(s, "z", "2", "");
        //    return s;
        //}

        //public static String ReplaceVisual(String strBase, String str1, String str2, String str3)
        //{
        //    String strTemp = strBase;

        //    strTemp = strBase.Replace(str1, "\t");
        //    strTemp = strTemp.Replace(str2, "\r");
        //    if (nTools.StrExt(str3))
        //    {
        //        strTemp = strTemp.Replace(str3, "\n");
        //        strTemp = strTemp.Replace("\t", "[" + str1 + str2 + str3 + "]");
        //        strTemp = strTemp.Replace("\r", "[" + str1 + str2 + str3 + "]");
        //        strTemp = strTemp.Replace("\n", "[" + str1 + str2 + str3 + "]");
        //    }
        //    else
        //    {
        //        strTemp = strTemp.Replace("\t", "[" + str1 + str2 + "]");
        //        strTemp = strTemp.Replace("\r", "[" + str1 + str2 + "]");
        //    }

        //    return strTemp;
        //}

        //public static String Replace(String strExpression, String strSearch, String strReplace)
        //{
        //    String strReturn;
        //    int intPosition;
        //    String strTemp;

        //    strReturn = "";
        //    strSearch = strSearch.ToUpper();
        //    strTemp = strExpression.ToUpper();
        //    intPosition = strTemp.IndexOf(strSearch);

        //    while (intPosition >= 0)
        //    {
        //        strReturn = strReturn + strExpression.Substring(0, intPosition) + strReplace;
        //        strExpression = strExpression.Substring(intPosition + strSearch.Length);
        //        strTemp = strTemp.Substring(intPosition + strSearch.Length);
        //        intPosition = strTemp.IndexOf(strSearch);
        //    }

        //    strReturn = strReturn + strExpression;
        //    return strReturn;
        //}

        //public static String ParseEmailDomain(String strEmail)
        //{
        //    String s = nTools.ParseDelimit(strEmail, "@", 2);
        //    return s;
        //}

        //public static String ConvertTextToHTML(String strText)
        //{
        //    //has to handle < without then converting the & in &lt; into &amp
        //    return strText.Replace("<", "!less than!").Replace(">", "!greater than!").Replace("\r\n", "<br>").Replace("&", "&amp;").Replace("\n", "<br>").Replace("!less than!", "&lt;").Replace("!greater than!", "&gt;").Replace(" ", "&nbsp;");
        //}

        //public static String ConvertHTMLToText(String strHTML)
        //{
        //    HTMLConversionHolder h = new HTMLConversionHolder();
        //    h.strHTML = strHTML;
        //    Thread t = new Thread(new ParameterizedThreadStart(ConvertHTMLToTextOnThread));
        //    t.SetApartmentState(ApartmentState.STA);
        //    t.Start(h);
        //    t.Join();
        //    return h.strText;
        //}

        //public static void ConvertHTMLToTextOnThread(Object x)
        //{
        //    try
        //    {
        //        HTMLConversionHolder h = (HTMLConversionHolder)x;
        //        nBrowser b = new nBrowser();
        //        b.ReloadWB();
        //        b.Add(h.strHTML);
        //        String s = b.GetPageText();
        //        b.Dispose();
        //        b = null;
        //        h.strText = s;
        //    }
        //    catch (Exception)
        //    { }
        //}

        //public static int CharCount(String s, Char l)
        //{
        //    int r = 0;
        //    Char[] ary = s.ToCharArray();
        //    foreach (Char c in ary)
        //    {
        //        if (c == l)
        //            r++;
        //    }
        //    return r;
        //}

        //public static DateTime ParseDate_YYYY_MM_DD(String s)
        //{
        //    try
        //    {
        //        String[] ary = nTools.Split(s, "_");
        //        int year = Int32.Parse(ary[0]);
        //        int month = Int32.Parse(ary[1]);
        //        int day = Int32.Parse(ary[2]);
        //        return new DateTime(year, month, day);
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //class HTMLConversionHolder
        //{
        //    public String strHTML;
        //    public String strText;
        //}

        //public static String WebTrim(String s)
        //{
        //    String c = new string((Char)160, 1);
        //    return s.Replace("\t", "").Replace(c, "").Trim();
        //}

        //public static String[] SplitLines(String s)
        //{
        //    return Split(s, "\r\n");
        //}

        //public static bool SetClip(String s)
        //{
        //    try
        //    {
        //        //System.Windows.Forms.Clipboard.Clear();
        //        System.Windows.Forms.Clipboard.SetText(s);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static Object GetTestValue(Int32 type, Int32 length)
        //{
        //    switch (type)
        //    {
        //        case (Int32)Enums.DataType.Integer:
        //            return (Object)nTools.GetRandomInteger();
        //        case (Int32)Enums.DataType.Long:
        //            return (Object)nTools.GetRandomLong();
        //        case (Int32)Enums.DataType.Float:
        //            return (Object)nTools.GetRandomFloat();
        //        case (Int32)Enums.DataType.Boolean:
        //            return (Object)nTools.GetRandomBoolean();
        //        case (Int32)Enums.DataType.Date:
        //            return (Object)nTools.GetRandomDate();
        //        default:
        //            if (length > 0)
        //                return (Object)nTools.Left(nTools.GetNewID(), length);
        //            else
        //                return (Object)nTools.GetNewID();
        //    }
        //}

        //public static Int32 GetRandomInteger()
        //{
        //    return OthersCodex.RandomProvider.Next(-100, 250000);
        //}

        //public static Int32 GetRandomInteger(int min, int max)
        //{
        //    return OthersCodex.RandomProvider.Next(min, max);
        //}

        //public static Int64 GetRandomLong()
        //{
        //    return OthersCode.RandomProvider.Next(-100, 500000);
        //}

        //public static Int64 GetRandomLong(Int64 low, Int64 high)
        //{
        //    return OthersCode.RandomProvider.Next(low, high);
        //}

        //public static Double GetRandomFloat()
        //{
        //    return Convert.ToDouble(Math.Round(OthersCode.RandomProvider.Next(Convert.ToDouble(-10000), Convert.ToDouble(10000)), 6));
        //}

        //public static bool GetRandomBoolean()
        //{
        //    return OthersCode.RandomProvider.NextBoolean();
        //}

        //public static DateTime GetRandomDate()
        //{
        //    return OthersCode.RandomProvider.Next(DateTime.Now.Subtract(new TimeSpan(36500, 0, 0, 0)), DateTime.Now.Add(new TimeSpan(36500, 0, 0, 0)));
        //}

        //public static bool IsInArray(ArrayList a, String s)
        //{
        //    return IsInArray(s, a);
        //}

        //public static bool IsInArray(String s, ArrayList a)
        //{
        //    foreach (String x in a)
        //    {
        //        if (nTools.StrCmp(x, s))
        //            return true;
        //    }
        //    return false;
        //}

        //public static String DistillPhoneNumber(String s)
        //{
        //    return FilterPhoneNumber(s, "");
        //}

        //public static String ChopFront(String strIn, String strFront)
        //{
        //    if (nTools.StrCmp(nTools.Left(strIn.Trim(), strFront.Length), strFront))
        //        return strIn.Trim().Substring(strFront.Length);
        //    else
        //        return strIn;
        //}

        public static String Mid(String s, int start)
        {
            return Mid(s, start, 0);
        }

        public static String Mid(String s, int start, int length)
        {
            try
            {
                String st = s.Substring(start - 1);
                if (length > 0)
                    return nTools.Left(st, length);
                else
                    return st;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static int Len(String s)
        {
            return s.Length;
        }

        public static String FormatHMS(int seconds)
        {
            return FormatHMS(Convert.ToInt64(seconds));
        }

        public static String FormatHMS(Double seconds)
        {
            return FormatHMS(Convert.ToInt64(seconds));
        }

        public static String FormatHMS(long seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, Convert.ToInt32(seconds));

            String s = nTools.Right("00" + t.Minutes.ToString(), 2) + ":" + nTools.Right("00" + t.Seconds.ToString(), 2);

            if (t.Hours <= 0)
                return s;
            else
                return nTools.Right("00" + t.Hours.ToString(), 2) + ":" + s;
        }

        public static String FormatDHMS(long seconds)
        {
            TimeSpan t = new TimeSpan(0, 0, Convert.ToInt32(seconds));

            String s = "";

            if (t.Days > 0)
                s += Convert.ToInt32(t.Days).ToString() + "d ";

            if (t.Hours > 0)
                s += nTools.Right("00" + t.Hours.ToString(), 2) + ":";

            s += nTools.Right("00" + t.Minutes.ToString(), 2) + ":" + nTools.Right("00" + t.Seconds.ToString(), 2);

            return s;
        }

        //public static bool IsProcessRunning(String strName)
        //{
        //    // Get all processess into Process array.
        //    Process[] myProcesses = Process.GetProcesses();

        //    strName = Path.GetFileNameWithoutExtension(strName);
        //    foreach (Process p in myProcesses)
        //    {
        //        if (nTools.HasString(p.ProcessName, strName))
        //            return true;
        //    }

        //    return false;
        //}

        //public static bool IsTermsCreditCard(String terms)
        //{
        //    String s = terms.Replace(" ", "").Trim();
        //    s = s.Replace("/", "").Trim();
        //    if (nTools.HasString(s, "cc"))
        //        return true;

        //    if (nTools.HasString(s, "ccard"))
        //        return true;

        //    if (nTools.HasString(s, "creditcard"))
        //        return true;

        //    return false;
        //}

        //public static bool IsTermsCOD(String terms)
        //{
        //    return nTools.HasString(terms.Replace(".", "").Replace(" ", ""), "cod");
        //}

        //public static bool IsTermsTT(String terms)
        //{
        //    String s = nTools.FilterTrash(terms, true, false);

        //    if (nTools.HasString(s, "tt"))
        //        return true;

        //    if (nTools.HasString(s, "wire"))
        //        return true;

        //    return false;
        //}

        public static bool DataTableExists(System.Data.DataTable t)
        {
            if (t == null)
                return false;

            if (t.Rows.Count == 0)
                return false;

            return true;
        }

        //public static DateTime GetDate_ThisMonthStart()
        //{
        //    return DateTime.Parse(DateTime.Now.Month.ToString() + "/01/" + DateTime.Now.Year.ToString());
        //}

        public static String GetDateTimeString()
        {
            return DateTime.Now.Year.ToString() + "_" + PadTwoDigits(DateTime.Now.Month.ToString()) + "_" + PadTwoDigits(DateTime.Now.Day.ToString()) + "_" + PadTwoDigits(DateTime.Now.Hour.ToString()) + "_" + PadTwoDigits(DateTime.Now.Minute.ToString()) + "_" + PadTwoDigits(DateTime.Now.Second.ToString());
        }

        public static String PadTwoDigits(String s)
        {
            return nTools.Right("0" + s, 2);
        }

        public static bool IsNumeric(String s)
        {
            if (s == null)
                return false;

            if (!nTools.StrExt(s))
                return false;

            try
            {
                Double d = Double.Parse(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsDate(String s)
        {
            if (s == null)
                return false;

            if (!nTools.StrExt(s))
                return false;

            try
            {
                DateTime d = DateTime.Parse(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //[DllImport("kernel32")]
        //public extern static int LoadLibrary(string lpLibFileName);
        //[DllImport("kernel32")]
        //public extern static bool FreeLibrary(int hLibModule);

        //public static bool IsDLLAvailabile(String strName)
        //{
        //    try
        //    {
        //        int l = LoadLibrary(strName);
        //        if (l > 32)
        //        {
        //            FreeLibrary(l);
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}

        //public static String ChooseAFile(System.Windows.Forms.IWin32Window owner)
        //{
        //    System.Windows.Forms.OpenFileDialog d = new System.Windows.Forms.OpenFileDialog();

        //    if (owner != null)
        //        d.ShowDialog(owner);
        //    else
        //        d.ShowDialog();

        //    return d.FileName;
        //}

        //public static String ChooseAFolder()
        //{
        //    return ChooseAFolder(null, "");
        //}

        //public static String ChooseAFolder(System.Windows.Forms.IWin32Window owner, String start)
        //{
        //    System.Windows.Forms.FolderBrowserDialog d = new System.Windows.Forms.FolderBrowserDialog();

        //    try
        //    {
        //        d.SelectedPath = start;
        //    }
        //    catch (Exception)
        //    { }

        //    if (owner != null)
        //        d.ShowDialog(owner);
        //    else
        //        d.ShowDialog();

        //    return d.SelectedPath;
        //}

        public static ArrayList KillBlankLines(ArrayList a)
        {
            ArrayList b = new ArrayList();
            foreach (String s in a)
            {
                if (nTools.StrExt(s))
                    b.Add(s);
            }
            return b;
        }

        public static String KillBlankLines(String s)
        {
            while (nTools.HasString(s, "\r\n\r\n"))
            {
                s = s.Replace("\r\n\r\n", "\r\n");
            }

            while (nTools.HasString(s, "\n\n"))
            {
                s = s.Replace("\n\n", "\n");
            }

            if (s.StartsWith("\r\n"))
                s = nTools.Mid(s, 3);

            return s;
        }

        public static bool IsDevelopmentMachinePlain()
        {
            switch (Environment.MachineName.ToLower())
            {
                case "vanburgh02":
                case "laptop06":
                case "westwood":
                case "westwood1":
                case "jlaptop":
                case "development-2":
                case "newmethod1":
                case "laptop64":
                    return true;
                default:
                    return false;
            }
        }

        //public static void InitStructureUpdateConnection()
        //{
        //    n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //    n_data_target.dServerName = "65.13.153.140";
        //    n_data_target.dUserName = "sa";
        //    n_data_target.dPassword = "rec0gnin";
        //}

        //public static void InitDevelopmentDataConnection()
        //{
        //    switch (Environment.MachineName.ToLower())
        //    {
        //        case "vanburgh02":
        //        case "vanburgh03":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = "vanburgh03";
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "rec0gnin";
        //            break;
        //        case "laptop06":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            //n_data_target.dServerName = "65.13.153.140";
        //            n_data_target.dServerName = "LAPTOP06";
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "rec0gnin";
        //            break;
        //        case "westwood":
        //        case "westwood1":
        //        case "jlaptop":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = Environment.MachineName;
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "camar0rs";
        //            break;
        //        case "development-2":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = Environment.MachineName;
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "camarors";
        //            break;
        //        case "newmethod1":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = Environment.MachineName;
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "n3w meth0d";
        //            break;
        //        default:
        //            nStatus.TellUser("Development Data Setup Required For " + Environment.MachineName);
        //            break;
        //    }
        //}

        //public static void GetMemoryUse(ref long memory, ref long pagefile)
        //{
        //    System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
        //    memory = p.WorkingSet64;
        //    pagefile = p.PagedMemorySize64;
        //}

        //public static String GetTempFileName(String strExt)
        //{
        //    if (!strExt.StartsWith("."))
        //        strExt = "." + strExt;
        //    return nTools.GetAppPath() + nTools.GetNewID() + strExt;
        //}

        //public static DateTime GetWeekStart(DateTime d)
        //{
        //    while (d.DayOfWeek != DayOfWeek.Monday)
        //    {
        //        d -= TimeSpan.FromDays(1);
        //    }
        //    return d;
        //}

        //public static DateTime GetWeekStart(int year, int week)
        //{
        //    try
        //    {
        //        DateTime t = GetYearStart(year);
        //        if (week == 1)
        //            return t.Add(TimeSpan.FromDays(7));

        //        return System.Globalization.CultureInfo.CurrentCulture.Calendar.AddWeeks(t, week + 1);
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetQuarterStart(DateTime d)
        //{
        //    switch (d.Month)
        //    {
        //        case 1:
        //        case 2:
        //        case 3:
        //            return DateTime.Parse("01/01/" + d.Year.ToString());
        //        case 4:
        //        case 5:
        //        case 6:
        //            return DateTime.Parse("04/01/" + d.Year.ToString());
        //        case 7:
        //        case 8:
        //        case 9:
        //            return DateTime.Parse("07/01/" + d.Year.ToString());
        //        case 10:
        //        case 11:
        //        case 12:
        //            return DateTime.Parse("10/01/" + d.Year.ToString());
        //    }
        //    return GetNullDate();
        //}

        //public static DateTime GetQuarterStart(int year, int quarter)
        //{
        //    switch (quarter)
        //    {
        //        case 1:
        //            return DateTime.Parse("01/01/" + year.ToString());
        //        case 2:
        //            return DateTime.Parse("04/01/" + year.ToString());
        //        case 3:
        //            return DateTime.Parse("07/01/" + year.ToString());
        //        case 4:
        //            return DateTime.Parse("10/01/" + year.ToString());
        //    }
        //    return GetNullDate();
        //}

        //public static DateTime GetQuarterEnd(int year, int quarter)
        //{
        //    switch (quarter)
        //    {
        //        case 1:
        //            return GetMonthEnd(year, 3);
        //        case 2:
        //            return GetMonthEnd(year, 6);
        //        case 3:
        //            return GetMonthEnd(year, 9);
        //        case 4:
        //            return GetMonthEnd(year, 12);
        //    }
        //    return GetNullDate();
        //}

        //public static DateTime GetDateByWeek(int year, int week)
        //{
        //    DateTime d = DateTime.Parse("01/01/" + year.ToString());
        //    d += TimeSpan.FromDays((week * 7) - 1);
        //    return d;
        //}

        //public static DateTime GetDateByQuarter(int year, int quarter)
        //{
        //    switch (quarter)
        //    {
        //        case 1:
        //            return DateTime.Parse("01/01/" + year.ToString());
        //        case 2:
        //            return DateTime.Parse("04/01/" + year.ToString());
        //        case 3:
        //            return DateTime.Parse("07/01/" + year.ToString());
        //        case 4:
        //            return DateTime.Parse("10/01/" + year.ToString());
        //    }
        //    return GetNullDate();
        //}

        //public static DateTime GetWeekEnd(DateTime d)
        //{
        //    while (d.DayOfWeek != DayOfWeek.Sunday)
        //    {
        //        d += TimeSpan.FromDays(1);
        //    }
        //    return d;
        //}

        //public static DateTime GetWeekEnd(int year, int week)
        //{
        //    return GetWeekEnd(GetWeekStart(year, week));
        //}

        //public static DateTime GetDayStart(DateTime d)
        //{
        //    try
        //    {
        //        return DateTime.Parse(d.Month.ToString() + "/" + d.Day.ToString() + "/" + d.Year.ToString() + " 12:00:00 AM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetDayEnd(DateTime d)
        //{
        //    try
        //    {
        //        return DateTime.Parse(d.Month.ToString() + "/" + d.Day.ToString() + "/" + d.Year.ToString() + " 11:59:59 PM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetDayStart(int year, int month, int day)
        //{
        //    try
        //    {
        //        return GetDayStart(DateTime.Parse(month.ToString() + "/" + day.ToString() + "/" + year.ToString()));
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static String GetMonthName(int month)
        //{
        //    try
        //    {
        //        return System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[month - 1];
        //    }
        //    catch (Exception)
        //    {
        //        return "x";
        //    }
        //}

        //public static DateTime GetStartDate(DateTime d, Enums.CubeInterval interval)
        //{
        //    switch (interval)
        //    {
        //        case NewMethod.Enums.CubeInterval.Day:
        //            return GetDayStart(d);
        //        case NewMethod.Enums.CubeInterval.Week:
        //            return GetWeekStart(d);
        //        case NewMethod.Enums.CubeInterval.Month:
        //            return GetMonthStart(d);
        //        case NewMethod.Enums.CubeInterval.Quarter:
        //            return GetQuarterStart(d);
        //        case NewMethod.Enums.CubeInterval.Year:
        //            return GetYearStart(d);
        //    }
        //    return d;
        //}

        //public static DateTime GetMonthStart(DateTime d)
        //{
        //    try
        //    {
        //        return DateTime.Parse(d.Month.ToString() + "/01/" + d.Year.ToString() + " 12:00:00 AM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetMonthStart(int year, int month)
        //{
        //    try
        //    {
        //        return DateTime.Parse(month.ToString() + "/01/" + year.ToString() + " 12:00:00 AM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetMonthEnd(DateTime d)
        //{
        //    while (d.Day != DateTime.DaysInMonth(d.Year, d.Month))
        //    {
        //        d += TimeSpan.FromDays(1);
        //    }
        //    return DateTime.Parse(DateFormat(d) + " 11:59:59 PM");
        //}

        //public static DateTime GetMonthEnd(int year, int month)
        //{
        //    return GetMonthEnd(GetMonthStart(year, month));
        //}

        //public static DateTime GetPreviousMonthStart(DateTime d)
        //{
        //    return GetMonthStart(SubtractOneMonth(d));
        //}

        //public static DateTime GetPreviousMonthEnd(DateTime d)
        //{
        //    return GetMonthEnd(SubtractOneMonth(d));
        //}

        //public static DateTime GetYearStart(DateTime d)
        //{
        //    try
        //    {
        //        return DateTime.Parse("01/01/" + d.Year.ToString() + " 12:00:00 AM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetYearStart(int year)
        //{
        //    try
        //    {
        //        return DateTime.Parse("01/01/" + year.ToString() + " 12:00:00 AM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime GetYearEnd(int year)
        //{
        //    try
        //    {
        //        return DateTime.Parse("12/31/" + year.ToString() + " 11:59:59 PM");
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static String GetDay_2Digit(DateTime d)
        //{
        //    String s = "00" + d.Day.ToString();
        //    return Right(s, 2);
        //}

        //public static String GetMonth_2Digit(DateTime d)
        //{
        //    String s = "00" + d.Month.ToString();
        //    return Right(s, 2);
        //}

        //public static DateTime AddOneMonth(DateTime d)
        //{
        //    try
        //    {
        //        int day = d.Day;
        //        int month = d.Month;
        //        int year = d.Year;

        //        month++;
        //        if (month > 12)
        //        {
        //            month = 1;
        //            year++;
        //        }
        //        return DateTime.Parse(month.ToString() + "/" + day.ToString() + "/" + year.ToString());
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static DateTime SubtractOneMonth(DateTime d)
        //{
        //    try
        //    {
        //        int day = d.Day;
        //        int month = d.Month;
        //        int year = d.Year;

        //        month--;
        //        if (month < 1)
        //        {
        //            month = 12;
        //            year--;
        //        }
        //        return DateTime.Parse(month.ToString() + "/" + day.ToString() + "/" + year.ToString());
        //    }
        //    catch (Exception)
        //    {
        //        return GetNullDate();
        //    }
        //}

        //public static String GetClipText()
        //{
        //    try
        //    {
        //        return System.Windows.Forms.Clipboard.GetText();
        //    }
        //    catch (Exception)
        //    {
        //        return "";
        //    }
        //}

        //public static int GetQuarter(DateTime d)
        //{
        //    switch (d.Month)
        //    {
        //        case 1:
        //        case 2:
        //        case 3:
        //            return 1;
        //        case 4:
        //        case 5:
        //        case 6:
        //            return 2;
        //        case 7:
        //        case 8:
        //        case 9:
        //            return 3;
        //        case 10:
        //        case 11:
        //        case 12:
        //            return 4;
        //        default:
        //            return -1;
        //    }
        //}

        //public static int GetWeek(DateTime d)
        //{
        //    return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        //}

        //public static double CalcPercent(Double large, Double small)
        //{
        //    try
        //    {
        //        Double d = small / large;
        //        return d * 100.0;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}

        //public static DateTime ConcatDateTime(DateTime d, String strTime)
        //{
        //    try
        //    {
        //        return DateTime.Parse(nTools.DateFormat(d) + " " + strTime);
        //    }
        //    catch (Exception)
        //    {
        //        return d;
        //    }
        //}

        //public static void CoalesceFileNames(ref ArrayList ary, String strFolder, String strExtension)
        //{
        //    String[] files = System.IO.Directory.GetFiles(strFolder);
        //    foreach (String s in files)
        //    {
        //        if (s.ToLower().EndsWith(strExtension.ToLower()))
        //            ary.Add(s);
        //    }

        //    String[] dirs = System.IO.Directory.GetDirectories(strFolder);
        //    foreach (String s in dirs)
        //    {
        //        if (!s.ToLower().EndsWith("\\projects"))
        //            CoalesceFileNames(ref ary, s, strExtension);
        //    }
        //}

        //public static bool ExploreFolder(String strFolder)
        //{
        //    try
        //    {
        //        String ex = nTools.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "explorer";
        //        System.Diagnostics.Process x = new System.Diagnostics.Process();
        //        x.StartInfo.FileName = strFolder;
        //        x.StartInfo.Arguments = "";
        //        x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        //        x.StartInfo.UseShellExecute = true;
        //        x.Start();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool AppendLogFile(String strFile, String strLine)
        //{
        //    try
        //    {
        //        System.IO.StreamWriter file = new System.IO.StreamWriter(strFile, true);
        //        file.WriteLine(strLine);
        //        file.Close();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool StrCmpExcludingTrash(String str1, String str2)
        //{
        //    return StrCmp(FilterTrash(str1), FilterTrash(str2));
        //}

        //public static String BoolToYN(bool b)
        //{
        //    if (b)
        //        return "T";
        //    else
        //        return "F";
        //}

        public static bool OpenFileInDefaultViewer(String strFile)
        {
            try
            {
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.FileName = strFile;
                x.StartInfo.Arguments = "";
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                x.StartInfo.Verb = "open";
                x.StartInfo.UseShellExecute = true;
                x.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public static String GetInsert(String strLine, String strStart, String strEnd)
        //{
        //    return GetInsert(strLine, strStart, strEnd, "");
        //}

        //public static String GetInsert(String strLine, String strStart, String strEnd, String strAlternateEnd)
        //{
        //    int lngMark = strLine.ToLower().IndexOf(strStart.ToLower());
        //    if (lngMark < 0)
        //        return "";

        //    lngMark += strStart.Length + 1;
        //    if (strEnd.Length == 0)
        //        return nTools.Mid(strLine, lngMark);

        //    int lngMark2 = strLine.ToLower().IndexOf(strEnd.ToLower(), lngMark);
        //    if (lngMark2 <= 0)
        //    {
        //        if (strAlternateEnd.Length > 0)
        //            lngMark2 = strLine.IndexOf(strAlternateEnd, lngMark);
        //        else
        //            return "";
        //    }

        //    return Mid(strLine, lngMark, (lngMark2 - lngMark) + 1).Trim();
        //}

        //public static bool StartsWith(String strBase, String strStart)
        //{
        //    return strBase.ToLower().StartsWith(strStart.ToLower());
        //}

        //public static bool ZipOneFile(String strFileName, String strZipName)
        //{
        //    try
        //    {
        //        ZipOutputStream s = new ZipOutputStream(File.Create(strZipName));
        //        FileStream fs = File.OpenRead(strFileName);

        //        ZipEntry entry = new ZipEntry(Path.GetFileName(strFileName));
        //        entry.DateTime = DateTime.Now;
        //        entry.Size = fs.Length;
        //        s.PutNextEntry(entry);

        //        Int64 total;
        //        Int32 chunksize;
        //        Int64 chunks;
        //        Int32 leftover;

        //        chunksize = 4096;
        //        total = fs.Length;
        //        chunks = total / chunksize;
        //        leftover = Convert.ToInt32(total % Convert.ToInt64(chunksize));

        //        for (int ch = 0; ch < chunks; ch++)
        //        {
        //            byte[] buffer = new byte[chunksize];
        //            fs.Read(buffer, 0, chunksize);
        //            s.Write(buffer, 0, buffer.Length);
        //        }

        //        if (leftover > 0)
        //        {
        //            byte[] buffer = new byte[leftover];
        //            fs.Read(buffer, 0, leftover);
        //            s.Write(buffer, 0, buffer.Length);
        //        }

        //        fs.Close();
        //        s.Finish();
        //        s.Close();
        //        s = null;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool UnZipOneFile(String strZipName, String strFolder)
        //{
        //    try
        //    {
        //        ICSharpCode.SharpZipLib.Zip.FastZip f = new ICSharpCode.SharpZipLib.Zip.FastZip();
        //        f.ExtractZip(strZipName, strFolder, "");
        //        f = null;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //       public static bool UnZipMultiFiles(String strZipName, String strFolder)
        //{
        //    try
        //    {
        //        ICSharpCode.SharpZipLib.Zip.FastZip fastZip = new FastZip();

        //        FileStream fs = new FileStream(strZipName, FileMode.Open, FileAccess.Read);

        //        ZipFile zipFile = new ZipFile(fs);
        //        foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry entry in zipFile)
        //        {
        //            fastZip.ExtractZip(strZipName, strFolder, "");
        //        }

        //        zipFile.Close();
        //        zipFile = null;

        //        fs.Close();
        //        fs.Dispose();
        //        fs = null;

        //        //ICSharpCode.SharpZipLib.Zip.FastZip f = new ICSharpCode.SharpZipLib.Zip.FastZip();
        //        //ICSharpCode.SharpZipLib.Zip.ZipFile zipFile = new ZipFile(strZipName);
        //        //foreach (ICSharpCode.SharpZipLib.Zip.ZipEntry entry in zipFile)
        //        //    zipFile.g
        //        //zipFile.
        //        //f.ExtractZip(strZipName, strFolder, "");
        //        //f = null;
        //        fastZip = null;
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool MakeFileRemoved(String a)
        //{
        //    if (File.Exists(a))
        //    {
        //        try
        //        {
        //            nStatus.SetStatus("Removing " + a);
        //            File.Delete(a);
        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            nStatus.SetStatus("Failed to remove " + a + ": " + ex.Message);
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public static byte[] FromHex(string s)
        //{
        //    try
        //    {
        //        //s = Regex.Replace(s.ToUpper(), "[^0-9A-F]", "");
        //        byte[] b = new byte[s.Length / 2];
        //        for (int i = 0; i < s.Length; i += 2)
        //            b[i / 2] = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);

        //        return b;
        //    }
        //    catch (Exception)
        //    {
        //        return new Byte[1];
        //    }
        //}

        //public static String DecodeBinaryString(Byte[] b, String strEncoding)
        //{
        //    System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(strEncoding);
        //    return encoding.GetString(b);
        //}

        //public static String ConvertListViewToHTML(ListView lv)
        //{
        //    int cols = lv.Columns.Count;
        //    StringBuilder s = new StringBuilder();

        //    s.AppendLine("<table border=\"1\" cellpadding=\"1\" cellspacing=\"1\">");
        //    s.AppendLine("<tr>");
        //    foreach (ColumnHeader c in lv.Columns)
        //    {
        //        s.AppendLine("<td><b>" + c.Text + "</b></td>");
        //    }
        //    s.AppendLine("</tr>");

        //    foreach (ListViewItem i in lv.Items)
        //    {
        //        s.AppendLine("<tr>");
        //        for (int j = 0; j < cols; j++)
        //        {
        //            try
        //            {
        //                s.AppendLine("<td>" + i.SubItems[j].Text + "</td>");
        //            }
        //            catch (Exception)
        //            { }
        //        }
        //        s.AppendLine("</tr>");
        //    }

        //    s.AppendLine("</table>");
        //    return s.ToString();
        //}

        //public static String DateFormatWithTime(DateTime d)
        //{
        //    return d.ToString();
        //}

        //public static bool IsPhoneNumber(String s)
        //{
        //    if (s == null)
        //        return false;

        //    if (s.Length < 7)
        //        return false;

        //    if (s.Length > 16)
        //        return false;

        //    return true;
        //}

        //public static String StripPhoneNumber(String s)
        //{
        //    String x = nTools.StripNonNumeric(s);
        //    if (x.Length == 11 && x.StartsWith("1"))
        //        x = nTools.Mid(x, 2);
        //    return x;
        //}

        //public static bool StripPhoneNumberField(nData xd, String strTable, String strField)
        //{
        //    if (!StripField(xd, strTable, strField))
        //        return false;
        //    return xd.Execute("update " + strTable + " set " + strField + " = substring(" + strField + ", 2, 255) where " + strField + " like '1%' and len(" + strField + ") = 11 ");
        //}

        //public static bool StripField(nDataTable d, String strField)
        //{
        //    return StripField(d.xData, d.TableName, strField);
        //}

        //public static bool StripField(nData xd, String strTable, String strField)
        //{
        //    foreach (String s in nTools.GetTrashKeys_OnlySymbols())
        //    {
        //        if (!xd.Execute("update " + strTable + " set " + strField + " = REPLACE(" + strField + ", '" + xd.SyntaxFilter(s) + "', '')"))
        //            return false;
        //    }
        //    return true;
        //}

        //public static String GetAppPathFile(String strName)
        //{
        //    StringBuilder sb = new StringBuilder(GetAppPath());
        //    sb.Append("\\");
        //    sb.Append(strName);

        //    return sb.ToString();
        //}

        //public static Image GetImage(String strFile, int width, int height)
        //{
        //    try
        //    {
        //        if (!IsPictureFile(strFile))
        //        {
        //            Bitmap b = new Bitmap(width, height);
        //            Graphics g = Graphics.FromImage(b);
        //            g.DrawString(Path.GetExtension(strFile), new Font("Times New Roman", 12), Brushes.Blue, new PointF(3, 3));
        //            g.Dispose();
        //            return b;
        //        }

        //        System.Drawing.Image image = System.Drawing.Image.FromFile(strFile);
        //        if (image == null)
        //        {
        //            Bitmap b = new Bitmap(width, height);
        //            return b;
        //        }

        //        return GetThumbnail(image, width, height);
        //    }
        //    catch
        //    {
        //        return new Bitmap(width, height);
        //    }
        //}

        //public static Image GetGenericThumbnail(int width, int height)
        //{
        //    Bitmap b = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(b);
        //    g.DrawRectangle(new Pen(Brushes.Blue, 2.0F), new Rectangle(0, 0, width, height));
        //    g.Dispose();
        //    return b;
        //}

        //public static Image GetThumbnail(Image i, int width, int height)
        //{
        //    // create the actual thumbnail image
        //    System.Drawing.Image thumbnailImage = i.GetThumbnailImage(width, height, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        //    return thumbnailImage;
        //}

        //public static bool ThumbnailCallback()
        //{
        //    return true;
        //}

        //public static bool IsPictureFile(String strFile)
        //{
        //    switch (Path.GetExtension(strFile).ToLower())
        //    {
        //        case ".jpg":
        //        case ".jpeg":
        //        case ".bmp":
        //        case ".gif":
        //            return true;
        //        default:
        //            return false;
        //    }
        //}

        //public static bool IncludesLine(String strText, String s)
        //{
        //    //middle
        //    if (nTools.HasString(strText, "\r\n" + s + "\r\n"))
        //        return true;

        //    //top line
        //    if (nTools.StrCmp(nTools.Left(strText, s.Length + 2), s + "\r\n"))
        //        return true;

        //    //bottom line
        //    if (nTools.StrCmp(nTools.Right(strText, s.Length + 2), "\r\n" + s))
        //        return true;

        //    return false;
        //}

        //public static String GetHTMLColor(int color)
        //{
        //    Color c = Color.FromArgb(color);
        //    return "#" + RGBtoHEX(c.R) + RGBtoHEX(c.G) + RGBtoHEX(c.B);
        //}

        //private static string RGBtoHEX(int Value)
        //{
        //    int Result = (Value / 16);
        //    int Remain = (Value % 16);

        //    string Resultant = null;

        //    if (Result >= 10)
        //    {
        //        if (Result == 10)
        //            Resultant = "A";
        //        if (Result == 11)
        //            Resultant = "B";
        //        if (Result == 12)
        //            Resultant = "C";
        //        if (Result == 13)
        //            Resultant = "D";
        //        if (Result == 14)
        //            Resultant = "E";
        //        if (Result == 15)
        //            Resultant = "F";
        //    }

        //    else Resultant = Result.ToString();

        //    if (Remain >= 10)
        //    {
        //        if (Remain == 10)
        //            Resultant += "A";
        //        if (Remain == 11)
        //            Resultant += "B";
        //        if (Remain == 12)
        //            Resultant += "C";
        //        if (Remain == 13)
        //            Resultant += "D";
        //        if (Remain == 14)
        //            Resultant += "E";
        //        if (Remain == 15)
        //            Resultant += "F";
        //    }

        //    else Resultant += Remain.ToString();

        //    return Resultant;
        //}

    }

    public class GenericEvent
    {
        public string Message = "";
        public bool Handled = false;

        public GenericEvent()
        {
        }

        GenericEvent(String s)
        {
            Message = s;
        }
    }

    public class NumberedFile
    {
        public String FileBase = "";
        public String FilePath = "";
        public Int64 HighestNumber = -1;
    }

    namespace Enums
    {
        public enum IconType
        {
            Unknown = -1,
            Any = 0,
            Class = 1,
            Property = 2,
            Method = 3,
            GuidedClass = 4,
            GuidedProperty = 5,
            GuidedMethod = 6,
        }

        public enum ScreenQuadrant
        {
            TopLeft = 1,
            TopCenter = 2,
            TopRight = 3,
            MidLeft = 4,
            MidCenter = 5,
            MidRight = 6,
            BottomLeft = 7,
            BottomCenter = 8,
            BottomRight = 9,
        }
    }
}
