using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
//using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;

namespace Tools
{
    public static class OperatingSystem
    {
        //Public Static Functions
        public static Boolean PrinterIsValid(String printerName)
        {
            try
            {
                System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
                pd.PrinterSettings.PrinterName = printerName;
                return pd.PrinterSettings.IsValid;
            }
            catch
            {
                return false;
            }
        }

        public static String GetTempFileName(String strExt)
        {
            if (!strExt.StartsWith("."))
                strExt = "." + strExt;
            return Tools.FileSystem.GetAppPath() + Tools.Strings.GetNewID() + strExt;
        }

        public static bool MakeFileRemoved(String a)
        {
            if (File.Exists(a))
            {
                try
                {
                    ////context.TheLeader.Comment("Removing " + a);
                    File.Delete(a);
                    return true;
                }
                catch
                {
                    ////context.TheLeader.Comment("Failed to remove " + a + ": " + ex.Message);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static String GetAppPathFile(String strName)
        {
            StringBuilder sb = new StringBuilder(Tools.FileSystem.GetAppPath());
            sb.Append("\\");
            sb.Append(strName);
            return sb.ToString();
        }

        public static bool CheckReadWrite(String strFolder)
        {
            String s = "";
            return CheckReadWrite(strFolder, ref s);
        }

        public static bool CheckReadWrite(String strFolder, ref String strCool)
        {
            String strID = Tools.Strings.GetNewID();
            if (!System.IO.Directory.Exists(strFolder))
            {
                //nStatus.TellUserTemp("The folder " + strFolder + " doesn't seem to exist; trying to find it...");
                if (strFolder.StartsWith("\\\\"))
                {
                    Tools.Folder.TryUnlockFolder(strFolder);
                }
                if (!System.IO.Directory.Exists(strFolder))
                {
                    strCool = "Folder Not Found";
                    return false;
                }
            }
            if (!Tools.Files.WriteTestFile(strFolder))
            {
                //nStatus.TellUserTemp("The folder " + strFolder + " can't be written to; trying to unlock it...");

                if (strFolder.StartsWith("\\\\"))
                {
                    Tools.Folder.TryUnlockFolder(strFolder);
                }
                if (!Tools.Files.WriteTestFile(strFolder, ref strCool))
                    return false;
            }
            return true;
        }

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

        public static bool IsProcessRunning(String strName)
        {
            // Get all processess into Process array.
            Process[] myProcesses = Process.GetProcesses();
            strName = Path.GetFileNameWithoutExtension(strName);
            foreach (Process p in myProcesses)
            {
                if (Tools.Strings.HasString(p.ProcessName, strName))
                    return true;
            }
            return false;
        }
        public static bool StopProcess(String strName)
        {
            // Get all processess into Process array.
            Process[] myProcesses = Process.GetProcesses();
            strName = Path.GetFileNameWithoutExtension(strName);
            foreach (Process p in myProcesses)
            {
                if (Tools.Strings.HasString(p.ProcessName, strName))
                {
                    try
                    {
                        p.Kill();
                        for (int i = 0; i < 20; i++)
                        {
                            System.Threading.Thread.Sleep(500);
                            if (p.HasExited)
                                break;
                        }
                    }
                    catch { }
                    return !IsProcessRunning(strName);
                }
            }
            return false;
        }

        //public static void InitStructureUpdateConnection()
        //{
        //    ToolsWin.Dialogs.Tell("InitStructureUpdateConnection is not set");
        //    ////n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //    ////n_data_target.dServerName = "65.13.153.140";
        //    ////n_data_target.dUserName = "sa";
        //    ////n_data_target.dPassword = "rec0gnin";
        //    //n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //    //n_data_target.dServerName = "71.251.105.34";
        //    //n_data_target.dUserName = "sa";
        //    //n_data_target.dPassword = "newm3th0d";
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
        //        case "laptop07":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            //n_data_target.dServerName = "65.13.153.140";
        //            n_data_target.dServerName = "LAPTOP07\\SQLEXPRESS";
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
        //            n_data_target.dPassword = "newm3th0d";
        //            break;
        //        case "laptop64":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = Environment.MachineName;
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "camar0rs";
        //            break;
        //        case "v4":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = "v4";
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "rec0gnin";
        //            break;
        //        case "v5":
        //            n_data_target.dTargetType = (Int32)NewMethod.Enums.ServerTypes.SQLServer;
        //            n_data_target.dServerName = "v5";
        //            n_data_target.dUserName = "sa";
        //            n_data_target.dPassword = "rec0gnin";
        //            break;
        //        default:
        //            //context.TheLeader.Tell("Development Data Setup Required For " + Environment.MachineName);
        //            break;
        //    }
        //}

        public static void GetMemoryUse(ref long memory, ref long pagefile)
        {
            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            memory = p.WorkingSet64;
            pagefile = p.PagedMemorySize64;
        }
        public static bool IsServiceInstalled(String strServiceName)
        {
            System.ServiceProcess.ServiceController controller = null;

            try
            {
                controller = new System.ServiceProcess.ServiceController(strServiceName);

                try
                {
                    controller.Close();
                    controller.Dispose();
                    controller = null;
                }
                catch { }
                return true;
            }
            catch { return false; }
        }
        public static bool IsServiceRunning(String strServiceName)
        {
            System.ServiceProcess.ServiceController controller = null;

            try
            {
                controller = new System.ServiceProcess.ServiceController(strServiceName);
                bool b = (controller.Status == System.ServiceProcess.ServiceControllerStatus.Running);
                try
                {
                    controller.Close();
                    controller.Dispose();
                    controller = null;
                }
                catch { }
                return b;
            }
            catch { return false; }
        }
        public static bool StopService(String strServiceName)
        {
            System.ServiceProcess.ServiceController controller = null;

            try
            {
                bool b = true;
                controller = new System.ServiceProcess.ServiceController(strServiceName);
                if (controller.Status != System.ServiceProcess.ServiceControllerStatus.Stopped)
                {
                    controller.Stop();
                    controller.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(20));
                    b = (controller.Status == System.ServiceProcess.ServiceControllerStatus.Stopped);
                }
                try
                {
                    controller.Close();
                    controller.Dispose();
                    controller = null;
                }
                catch { }
                return b;
            }
            catch { return false; }
        }




        public static void DropCrumb(String strName, String strValue)
        {
            Tools.Files.SaveFileAsString(Tools.FileSystem.GetAppPath() + strName + "cmb", strValue);
        }
        public static string GetCrumb(String strName)
        {
            return Tools.Files.OpenFileAsString(Tools.FileSystem.GetAppPath() + strName + "cmb");
        }
    }
}
