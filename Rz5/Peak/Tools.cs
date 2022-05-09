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

namespace NewMethod
{
    namespace Tools
    {

        public static class Files
        {
            public static bool Shell(String strFilePath)
            {
                return Shell(strFilePath, "");
            }
            public static bool Shell(String strFilePath, String strArguments)
            {
                return Shell(strFilePath, strArguments, new StringBuilder(), false, false);
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
        }

        public static class Folder
        {

            public static String GetAppPathFile(String strName)
            {
                StringBuilder sb = new StringBuilder(NewMethod.Tools.Folder.GetAppPath());
                sb.Append("\\");
                sb.Append(strName);
                return sb.ToString();
            }

            public static String GetAppPath()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim()));
                if (NewMethod.Tools.Strings.Right(sb.ToString(), 1) != "\\")
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
                return NewMethod.Tools.Folder.ConditionFolderName(b.ToString());
            }

            public static String ConditionFolderName(String s)
            {
                if (NewMethod.Tools.Strings.Right(s, 1) == "\\")
                    return s;
                else
                    return s + "\\";
            }

            public static String GetTopLevelFolderName(String s)
            {
                String[] ary = NewMethod.Tools.Strings.Split(s, "\\");
                if (s.EndsWith("\\"))
                    return ary[ary.Length - 2];
                else
                    return ary[ary.Length - 1];
            }

        }

        public static class Strings
        {
            public static Boolean StrExt(String s)
            {
                if (s == null)
                    return false;
                if (s.Trim().Length <= 0)
                    return false;
                return true;
            }
            public static Boolean StrCmp(String s1, String s2)
            {
                if (s1 == null)
                    return false;
                if (s2 == null)
                    return false;
                return (s1.ToLower().Trim() == s2.ToLower().Trim());
            }

            public static String Right(String strIn, int len)
            {
                try
                {
                    return strIn.Substring(strIn.Length - len, len);
                }
                catch (Exception ex)
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
                catch (Exception e)
                {
                    return "";
                }
            }

            public static String ParseDelimit(String strIn, String s, int p)
            {
                try
                {
                    if (!Tools.Strings.StrExt(strIn))
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
                {
                    return "";
                }
            }

            public static String[] Split(String strIn, String strSplit)
            {
                return strIn.Split(new String[] { strSplit }, StringSplitOptions.None);
            }

            public static String LongFormat(long l)
            {
                return String.Format("{0:###,###,###,##0}", l);
            }
        }

        public static class Dates
        {        
            public static DateTime GetNullDate()
            {
                return DateTime.Parse("01/01/1900");
            }
        }

    }
}