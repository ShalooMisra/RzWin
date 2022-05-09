using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Tools
{
    public static class FileSystem
    {
        public static String ConditionFolderName(String f)
        {
            if (Tools.Strings.Right(f, 1) == "\\")
                return f;
            else
                return f + "\\";
        }

        public static bool ExploreFolder(String strFolder)
        {
            try
            {
                String ex = Tools.FileSystem.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.System)) + "explorer";
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.FileName = strFolder;
                x.StartInfo.Arguments = "";
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                x.StartInfo.UseShellExecute = true;
                x.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Shell(String strFilePath)
        {
            return Shell(strFilePath, "");
        }
        public static bool Shell(String strFilePath, String strArguments)
        {
            return Shell(strFilePath, strArguments, false, false);
        }
        public static bool Shell(String strFilePath, String strArguments, bool NoWindow, bool WaitForDone)
        {
            string msg = "";
            return Shell(strFilePath, strArguments, NoWindow, WaitForDone, ref msg);
        }

        //2013_05_01 removed StringBuilder sb parameter; was not used!
        public static bool Shell(String strFilePath, String strArguments, bool NoWindow, bool WaitForDone, ref string msg)
        {
            try
            {
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.FileName = strFilePath;
                x.StartInfo.Arguments = strArguments;
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                if (NoWindow)
                    x.StartInfo.CreateNoWindow = true;
                x.Start();
                if (WaitForDone)
                    x.WaitForExit();
                return true;
            }
            catch (Exception ee)
            {
                msg = "ShellError: " + ee.Message;
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
                    if (Tools.Strings.StrExt(strIgnore))
                    {
                        if (!Tools.Strings.HasString(str, strIgnore))
                            output += str + "\r\n";
                    }
                    else
                        output += str + "\r\n";
                }

                x.Close();
                x.Dispose();
                x = null;

                return true;
            }
            catch (Exception e)
            {
                output = "";
                return false;
            }
        }

        public static void ShellSilently(String strFilePath, String arguments = "", bool waitForDone = false)
        {
            Process target = new Process();
            target.StartInfo.FileName = strFilePath;
            target.StartInfo.Arguments = arguments;
            target.StartInfo.UseShellExecute = true;
            target.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            target.StartInfo.CreateNoWindow = true;
            target.Start();

            if (waitForDone)
                target.WaitForExit();
        }

        public static bool PopText(String s)
        {
            String f = Tools.FileSystem.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "pop_sys_nm.temp";
            Tools.FileSystem.SaveFileAsString(f, s);
            return PopTextFile(f);
        }

        public static bool PopText(List<String> s)
        {
            String f = Tools.FileSystem.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + "pop_sys_nm.temp";
            StringBuilder sb = new StringBuilder();
            foreach (String x in s)
            {
                sb.AppendLine(x);
            }
            Tools.FileSystem.SaveFileAsString(f, sb.ToString());
            return PopTextFile(f);
        }

        public static bool PopTextFile(String strFile)
        {
            return Shell("notepad.exe", strFile);
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

        public static bool CreateFileFromArrayList(String strFileName, System.Collections.ArrayList strData)
        {
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(strFileName, false);
                StringBuilder sb = new StringBuilder();
                foreach (object o in strData)
                {
                    sb.AppendLine(o.ToString());
                }
                file.Write(sb.ToString());
                file.Close();
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
            catch (Exception e)
            {
                return "";
            }
        }

        public static String GetAppPath()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim()));
            if (Tools.Strings.Right(sb.ToString(), 1) != "\\")
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
            return Tools.FileSystem.ConditionFolderName(b.ToString());
        }
    }
}
