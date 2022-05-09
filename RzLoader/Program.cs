using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Tools;
using ToolsWin;
using Core;
using CoreWin;
using NewMethod;
using NewMethod.Win;
using Rz5;


namespace RzLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                StartArgsRz args = new StartArgsRz();
                if (Environment.CommandLine.Contains("-duty_monitor_unattended"))
                {
                    ContextRz q = new ContextRz(new LeaderServiceRz());
                    StartRz s = new StartRz();
                    StartArgsRz a = new StartArgsRz();
                    a.DepotIgnore = true;
                    a.TieHookSuppress = true;
                    a.TheLoginInfo = new LoginInfo();
                    a.TheLoginInfo.IsAutoEntered = true;
                    a.TheLoginInfo.strUser = "RzSystem";
                    a.TheLoginInfo.strPassword = "x\r\ny";
                    a.TheLoginInfo.AutoCreateSystem = true;
                    String connection_file = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "DutyMonitorConnection.txt";
                    if (File.Exists(connection_file))
                    {
                        String[] cfs = Tools.Strings.SplitLines(Tools.Files.OpenFileAsString(connection_file));
                        if (cfs.Length >= 4)
                        {
                            a.DataKey = new DataKeySql(Tools.Database.ServerType.SqlServer);
                            a.DataKey.ServerName = cfs[0];
                            a.DataKey.UserName = cfs[1];
                            a.DataKey.UserPassword = cfs[2];
                            a.DataKey.DatabaseName = cfs[3];
                        }
                    }
                    try
                    {
                        s.Init(q, a);
                    }
                    catch
                    {
                        return;
                    }
                    q.Sys.TheDutyLogic.RunUnattendedPermanently(q);
                }
                else if (Environment.CommandLine.Contains("-systemtest="))
                {
                    //string line = Tools.Strings.ParseDelimit(Environment.CommandLine, "-systemtest=", 2).Trim();
                    //ContextRz q = new ContextRz(new LeaderWinUserRz(null));
                    //StartupRz s = new StartupRz();
                    //TestCore.InTestMode = true;
                    //nStatus.CurrentMode = StatusMode.Normal;
                    //StartupArgsRz a = new StartupArgsRz();
                    //a.Silent = true;
                    //a.DepotIgnore = true;
                    //a.TieHookSuppress = true;
                    //a.TheLoginInfo = new LoginInfo();
                    //a.TheLoginInfo.IsAutoEntered = true;
                    //a.TheLoginInfo.strUser = "RzSystem";
                    //a.TheLoginInfo.strPassword = "x\r\ny";
                    //a.TheLoginInfo.AutoCreateSystem = true;
                    //String[] cfs = Tools.Strings.Split(line, "||");
                    //if (cfs.Length >= 4)
                    //{
                    //    a.xDepot = new DepotConnection();
                    //    a.xDepot.ServerName = cfs[0];
                    //    a.xDepot.UserName = cfs[1];
                    //    a.xDepot.Password = cfs[2];
                    //    a.xDepot.DatabaseName = cfs[3];
                    //}
                    //string ident = "";
                    //try { ident = cfs[4]; }
                    //catch { }
                    //StartupRzWin sw = new StartupRzWin(s);
                    //if (!s.Startup(q, a))
                    //    return;
                    //q.TheLogicRz.CompanyIdentifier = ident;
                    //q.TheLogicRz.CheckCompanyIdentifier();
                    //sw.Startup(q);
                }
                else
                {
                    Tools.Style.StyleCurrent = new Tools.Style(new System.Drawing.Font("Calibri", 12.0f));
                    //ContextRz q = new ContextRz(new RzSensible.LeaderWinUserRzSensible());
                    //RzSensible.StartupRzSensible s = new RzSensible.StartupRzSensible();
                    //RzSensible.StartupRzWinSensible sw = new RzSensible.StartupRzWinSensible(q, s);
                    ContextRz q = new ContextRz(new Rz5.LeaderWinUserRz());
                    StartRz s = new StartRz();
                    StartupRzWin sw = new StartupRzWin(q,s);
                    
                    try
                    {
                        s.Init(q, args);
                    }
                    catch
                    {
                        return;
                    }
                    sw.Startup(q);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string innerException = ex.InnerException.ToString();
                
            }
        }
    }
}
