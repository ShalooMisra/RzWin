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

using NewMethod;

namespace Peak
{
    static class Program
    {

        public static String ApplicationName;
        public static String FolderName;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            String s = MainTry("Rz4", "Rz4");

            if (s == "cancel")
                return;

            if (System.IO.File.Exists(s))
                NewMethod.Tools.Files.Shell(s);
            //else
            //{
            //    s = MainTry("Rz4", "Rz3");
            //    if (s == "cancel")
            //        return;

            //    if (System.IO.File.Exists(s))
            //        NewMethod.Tools.Files.Shell(s);
            else
                System.Windows.Forms.MessageBox.Show(Program.ApplicationName + " could not be found in " + s + ".   (Old Details: "+NewMethod.Tools.Folder.GetAppPath()+")");
            //}
        }

        static String MainTry(String appName, String folderPrefix)
        {
            Program.ApplicationName = appName;
            // Program.FolderName = NewMethod.Tools.Folder.GetAppPath();
            Program.FolderName = Directory.GetCurrentDirectory();
            //Check Permissions here

            string pathName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Sensible Micro Corporation";


            //if (Environment.MachineName == "LAPTOP08")
            //    Program.FolderName = "C:\\Program Files (x86)\\Recognin Technologies\\Rz\\";
            if (Environment.MachineName == "6WS9PV1")
            {


                //var pathName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"\Senisble Micro Corporation\Rz");
                //string pathName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Senisble Micro Corporation\Rz";
                //pathName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Sensible Micro Corporation\";
                try { Program.FolderName = pathName; }
                catch { Program.FolderName = @"C:\Eternal\RzWin\RzSensible\RzLoader\bin\Debug\"; }
            }
            //else
            //{
            //    string pathName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Sensible Micro Corporation\";
            //    try { Program.FolderName = pathName; }
            //    catch {}
            //}
            //pathName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Sensible Micro Corporation";
            try { Program.FolderName = pathName; }
            catch { }



            if (Program.FolderName.ToLower().EndsWith("\\exec\\"))
                Program.FolderName = NewMethod.Tools.Folder.ConditionFolderName(NewMethod.Tools.Folder.GetDirectoryParent(Program.FolderName));

            int i = System.Environment.CommandLine.IndexOf("application=");
            if (i > -1)
            {
                Program.ApplicationName = NewMethod.Tools.Strings.ParseDelimit(System.Environment.CommandLine.Substring(i + 12).Trim(), ".", 1);
            }

            String s = "";

            //THis is an arrayList that holds all the versions detected.
            ArrayList a = NewMethod.VersionUpdate.GetVersions(appName, folderPrefix, Program.FolderName, false);
            if (a.Count > 0)
            {
                if (System.Environment.CommandLine.IndexOf("-latestonly") > -1)
                {
                    a.Reverse();
                    NewMethod.Version v = (NewMethod.Version)a[0];
                    s = v.FolderPath + v.ExeName;
                    v = null;
                }
                else
                {
                    if (a.Count == 1)
                    {
                        NewMethod.Version v = (NewMethod.Version)a[0];
                        s = v.FolderPath + v.ExeName;
                        v = null;

                    }
                    else
                    {
                        //remove the first entirely as an option
                        //KT 6-11-2018, now that I am counting the initial Rz Install folder as a "version", don't think I want to remote the [o] index version.
                        //a.RemoveAt(0);

                        if (a.Count == 1)
                        {
                            NewMethod.Version v = (NewMethod.Version)a[0];
                            s = v.FolderPath + v.ExeName;
                            v = null;
                        }
                        else
                        {
                            NewMethod.Version v = frmChooseVersion.Choose(a);
                            if (v == null)
                                return "cancel";

                            s = v.FolderPath + v.ExeName;
                            v = null;
                        }
                    }
                }
            }
            else
            {
                //s = nTools.GetHighestFileName(nTools.GetAppPath(), Program.ApplicationName);
                //s = Program.FolderName+ @"\Rz\";
                //s = @"C:\Eternal\RzWin\RzSensible\RzLoader\bin\Debug\Rz4Loader.exe";
                s = pathName + @"\Rz\Rz4Loader.exe";

            }




            return s;

        }



        //static String MainTry(String appName, String folderPrefix)
        //{
        //    Program.ApplicationName = appName;
        //    // Program.FolderName = NewMethod.Tools.Folder.GetAppPath();
        //    Program.FolderName = Directory.GetCurrentDirectory();

        //    if ( Environment.MachineName == "LAPTOP08" )
        //        Program.FolderName = "C:\\Program Files (x86)\\Recognin Technologies\\Rz\\";
        //    if (Environment.MachineName == "6WS9PV1")
        //    {
        //        try { Program.FolderName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Senisble Micro Corporation\\Rz\\"; }
        //        catch { Program.FolderName = @"C:\Eternal\RzWin\RzSensible\RzLoader\bin\Debug\"; }
        //    }



        //    //else if( Environment.MachineName == "NEWMETHOD1" )
        //    //    Program.FolderName = "C:\\Program Files\\Recognin Technologies\\Rz3\\";


        //    if (Program.FolderName.ToLower().EndsWith("\\exec\\"))
        //        Program.FolderName = NewMethod.Tools.Folder.ConditionFolderName(NewMethod.Tools.Folder.GetDirectoryParent(Program.FolderName));

        //    int i = System.Environment.CommandLine.IndexOf("application=");
        //    if (i > -1)
        //    {
        //        Program.ApplicationName = NewMethod.Tools.Strings.ParseDelimit(System.Environment.CommandLine.Substring(i + 12).Trim(), ".", 1);
        //    }

        //    String s = "";
        //    ArrayList a = NewMethod.VersionUpdate.GetVersions(appName, folderPrefix, Program.FolderName, false);
        //    if( a.Count > 0 )
        //    {
        //        if (System.Environment.CommandLine.IndexOf("-latestonly") > -1)
        //        {
        //            a.Reverse();
        //            NewMethod.Version v = (NewMethod.Version)a[0];
        //            s = v.FolderPath + v.ExeName;
        //            v = null;
        //        }
        //        else
        //        {
        //            if (a.Count == 1)
        //            {
        //                NewMethod.Version v = (NewMethod.Version)a[0];
        //                s = v.FolderPath + v.ExeName;
        //                v = null;

        //            }
        //            else
        //            {
        //                //remove the first entirely as an option
        //                a.RemoveAt(0);

        //                if (a.Count == 1)
        //                {
        //                    NewMethod.Version v = (NewMethod.Version)a[0];
        //                    s = v.FolderPath + v.ExeName;
        //                    v = null;
        //                }
        //                else
        //                {
        //                    NewMethod.Version v = frmChooseVersion.Choose(a);
        //                    if (v == null)
        //                        return "cancel";

        //                    s = v.FolderPath + v.ExeName;
        //                    v = null;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //s = nTools.GetHighestFileName(nTools.GetAppPath(), Program.ApplicationName);
        //        //s = Program.FolderName+ @"\Rz\";
        //        s = @"C:\Eternal\RzWin\RzSensible\RzLoader\bin\Debug\Rz4Loader.exe";
        //    }

        //    return s;

        //}

        //static void InsertNewFiles()
        //{
        //    try
        //    {
        //        String[] files = Directory.GetFiles(nTools.GetAppPath());
        //        foreach (String s in files)
        //        {
        //            if (s.EndsWith("_new"))
        //            {
        //                String old = nTools.Left(s, s.Length - 4);
        //                if (File.Exists(old))
        //                {
        //                    try
        //                    {
        //                        File.Delete(old);
        //                    }
        //                    catch { }
        //                }

        //                if (!File.Exists(old))
        //                    File.Move(s, old);
        //            }
        //        }
        //    }
        //    catch { }
        //}
    }
}