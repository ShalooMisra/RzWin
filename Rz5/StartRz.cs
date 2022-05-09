using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Core;
using NewMethod;
using NewMethod.Enums;
using Tools.Database;

namespace Rz5
{
    public class StartRz : StartNM
    {
        public override void Init(Context context, StartArgs args)
        {
            ContextRz xrz = (ContextRz)context;            
            LicenseCheck(xrz);
            base.Init(context, args);
        }
        protected override void InitData(Context context, StartArgs args)
        {
            ContextRz xrz = (ContextRz)context;
            StartArgsRz argsRz = (StartArgsRz)args;
            if (args.DataKey == null && !DepotConnection.DepotFileExists() && !argsRz.DepotIgnore)
                DepotMissingConnection(argsRz);
            if( args.DataKey == null )
            {
                if (DepotConnection.DepotFileExists() && !argsRz.DepotIgnore)
                {
                    context.TheLeader.Comment("Depot file exists.");
                    DepotConnection c = xrz.TheLeaderRz.ChooseDepotConnection();
                    if (c == null)
                        throw new Exception("DepotConnection is null");
                    args.DataKey = new DataKeySql(ServerType.SqlServer);
                    args.DataKey.ServerName = c.ServerName;
                    args.DataKey.DatabaseName = c.DatabaseName;
                    args.DataKey.UserName = c.UserName;
                    args.DataKey.UserPassword = c.Password;

                    argsRz.RecallKey = new DataKeySql(ServerType.SqlServer);
                    argsRz.RecallKey.ServerName = c.RecallServerName;
                    argsRz.RecallKey.DatabaseName = c.RecallDatabaseName;
                    argsRz.RecallKey.UserName = c.RecallUserName;
                    argsRz.RecallKey.UserPassword = c.RecallPassword;
                }
                else
                {
                    

                    args.DataKey = new DataKeySql(ServerType.SqlServer);                   
                    //going with IP instead of DNS for performance.
                    args.DataKey.ServerName = @"10.2.0.7\sqlexpress";
                    args.DataKey.DatabaseName = "Rz3";

                    //1-30-2020 - As yet have not found a way besides SQL Server authentication to allow access to SQL.
                    //Note when you specify User Name / Password - then you are forcing it into SQL Authentication mode, and you will never be able to authenticate an AD user that way.
                    args.DataKey.UserName = "redacted";
                    args.DataKey.UserPassword = "redacted";                  


                    argsRz.RecallKey = new DataKeySql(ServerType.SqlServer);
                    argsRz.RecallKey.ServerName = args.DataKey.ServerName;
                    argsRz.RecallKey.DatabaseName = "Rz3_Recall";
                    argsRz.RecallKey.UserName = args.DataKey.UserName;
                    argsRz.RecallKey.UserPassword = args.DataKey.UserPassword;

                }
            }
            base.InitData(context, args);
            //if (!DepotConnection.DepotFileExists() && args.DataKey == null && ServerSwitchCheck(xrz))
            if (ServerSwitchCheck(xrz))
            {

                Tools.FileSystem.Shell(Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppParentPath()) + "Peak.exe");
                throw new Exception("Restarting Rz...");

                //this didn't seem to work
                //Init(context, args);
                //return;
            }
           
        }
        protected override void InitSystem(Context context, StartArgs args)
        {
            base.InitSystem(context, args);

            ContextRz xrz = (ContextRz)context;
            StartArgsRz argsRz = (StartArgsRz)args;
            
            //has to be before the login and everything
            (xrz).Logic.CheckCompanyIdentifier(xrz);

            context.TheLeader.CommentEllipse("Showing the login");
            LoginPreFire(xrz);

            if (argsRz.Recall)
                xrz.Sys.InitRecall(xrz, argsRz.RecallKey, Environment.MachineName);

            Permissions.InitPermits(xrz);
        }
        protected override bool StructureUpdateNeeded(Context context, StartArgs args)
        {
            if (base.StructureUpdateNeeded(context, args))
                return true;

            ContextRz xrz = (ContextRz)context;
            Int64 highest = xrz.GetSettingInt64("highest_version");
            Int64 current = CurrentVersion; 
            context.TheLeader.Comment("CanConnect - highest:" + highest.ToString() + " current:" + current);
            return (current > highest);
        }
        long CurrentVersion
        {
            get
            {
                return Tools.Misc.GetVersionNumber(Tools.ToolsNM.AssemblyNM);
            }
        }
        protected override void StructureUpdate(Context context, StartArgs args)
        {
            //if (Tools.Strings.StrCmp(Environment.MachineName, "RZWORKSTATION"))
            //    System.Windows.Forms.MessageBox.Show("Updating structure");

            base.StructureUpdate(context, args);
            ordhed.DropOrderViews((ContextRz)context);
            ordhed.CreateOrderViews((ContextRz)context);
            ContextRz xrz = (ContextRz)context;
            StartArgsRz argsRz = (StartArgsRz)args;

            if (argsRz.Recall)
                xrz.Sys.StructureCheckRecall(xrz);
        }
        protected override void StructureUpdateComplete(Context context, StartArgs args)
        {
            base.StructureUpdateComplete(context, args);
            ContextRz xrz = (ContextRz)context;
            xrz.SetSettingInt64("highest_version", CurrentVersion);
        }
        protected override void InitComplete(Context context, StartArgs args)
        {
            try
            {
                base.InitComplete(context, args);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ContextRz xrz = (ContextRz)context;
            StartArgsRz argsRz = (StartArgsRz)args;

            context.Leader.ProgressClear();
            context.Leader.ProgressUpdate(20);
            context.TheLeader.CommentEllipse("Caching users");
            xrz.Sys.CacheUsers(xrz);

            context.Leader.ProgressUpdate(20);
            context.TheLeader.CommentEllipse("Caching teams");
            xrz.Sys.FillTeamTree(xrz);

            context.Leader.ProgressUpdate(20);
            context.TheLeader.CommentEllipse("Caching choices");
            xrz.Sys.CacheChoices(xrz);

            context.Leader.ProgressUpdate(20);
            context.TheLeader.CommentEllipse("Caching companies");
            xrz.Logic.CacheCompanies(xrz);

            context.Leader.ProgressUpdate(100);
            context.TheLeader.Comment("Connection Active");
            if (argsRz.TheLoginInfo == null)
                LoginFire(xrz);
            else
                xrz.TheSysRz.TheUserLogicRz.CheckLogin(xrz, argsRz.TheLoginInfo);
    
            if (argsRz.CompanyIdentifier != "")
                xrz.SetSetting("company_identifier", argsRz.CompanyIdentifier);
                    
            xrz.Sys.CheckHighestVersion(xrz);
            //InitTie(xrz, argsRz);

            xrz.Logic.CheckPrintedFormGraphics(xrz);
        }
        //void InitTie(ContextRz context, StartArgsRz args)
        //{
        //    if (!args.TieHookSuppress && context.GetSettingBoolean("use_hook"))
        //    {
        //        String strTieServer = RzHook.GetTieServerName((ContextRz)context);
        //        int intPort = context.GetSettingInt32("tie_server_port");
        //        String strPassword = context.GetSetting("tie_password");
        //        if (Tools.Strings.StrExt(strTieServer) && intPort > 0 && Tools.Strings.StrExt(strPassword))
        //        {
        //            context.TheLeader.Comment("Connecting hook to " + strTieServer + " on " + intPort.ToString());
        //            context.Logic.StartHook(context, strTieServer, intPort, strPassword, false);
        //        }
        //    }
        //}
        private bool DemoExpired(ContextRz context)
        {
            DateTime demo = n_set.GetSetting_Date(context, "demo_date");
            if (demo == Tools.Dates.GetNullDate())
            {
                n_set.SetSetting_Date(context, "demo_date", DateTime.Now);
                return false;
            }
            TimeSpan ts = demo.Subtract(DateTime.Now);
            return ts.Days > 30;
        }
        //private void CreateRecallDB(ContextNM x, DataConnectionSqlServer recall)
        //{
        //    if (recall == null)
        //        return;
        //    Tools.Database.Key k = recall.GetDatabaseKey(recall.TheKey.DatabaseName);
        //    k.FolderPath = n_data_target.dDataPath;
        //    recall.DatabaseCreate(k);
        //    //recall.CreateDatabase(recall.database_name, n_data_target.dDataPath);
        //    n_set.SetSetting_Long(x, "highest_version_recall", 0);
        //}
        private void CheckUpdateRecallTarget(ContextNM x, n_data_target recall_target)
        {
            if (recall_target == null)
                return;
            if (!Tools.Strings.StrExt(recall_target.server_name))
                recall_target.server_name = x.TheData.TheConnection.TheKey.ServerName;
            if (!Tools.Strings.StrExt(recall_target.user_name))
                recall_target.user_name = x.TheData.TheConnection.TheKey.UserName;
            if (!Tools.Strings.StrExt(recall_target.user_password))
                recall_target.user_password = x.TheData.TheConnection.TheKey.UserPassword;
            if (!Tools.Strings.StrExt(recall_target.database_name))
                recall_target.database_name = "Rz3_Recall";
        }
        public bool ServerSwitchCheck(ContextRz context)
        {
            String oldServerName = context.Connection.TheKey.ServerName;

            String server = context.GetSetting("switch_to_server");
            if (!Tools.Strings.StrExt(server))
                return false;
            if (Tools.Strings.StrCmp(server, context.Data.ServerName))
                return false;

            //if (!context.TheLeader.AskYesNo("The server " + context.Data.ServerName + " has a setting telling Rz to use a different server (" + server + " ) as the live Rz information source.  Do you want to swicth to " + server + "?"))
            //    return false;

            String username = context.GetSetting("switch_to_user");
            if (!Tools.Strings.StrExt(username))
                username = context.Connection.TheKey.UserName;

            String password = context.GetSetting("switch_to_password");
            if (!Tools.Strings.StrExt(password))
                password = context.Connection.TheKey.UserPassword;

            String database = context.GetSetting("switch_to_database");
            if (!Tools.Strings.StrExt(database))
                database = context.Connection.TheKey.DatabaseName;         
            
            DataConnectionSqlServer dNew = new DataConnectionSqlServer(server, database, username, password);
            String error = "";
            if (!dNew.ConnectPossible(ref error))
            {
                context.TheLeader.Tell("The server " + server + " can't be connected to: " + error);
                return false;
            }
            if (!ConnectionManager.ToolsConnection.ConnectionFileDataSet(server, username, password, database))
            {
                context.TheLeader.Tell("Rz was not able to set the new connection info.");
                return false;
            }
            if (DepotConnection.DepotFileExists())
            {
                if (!CheckForDepotUpdate(context, oldServerName, server))
                {
                    context.TheLeader.Tell("Rz was not able to set the new connection info to the depot file.");
                    return false;
                }
            }
            context.TheLeader.Tell("Set the connection to " + server + "; reloading...");
            return true;
        }
        private bool CheckForDepotUpdate(ContextNM x, String oldServerName, string newServerName)
        {
            if (!Tools.Strings.StrExt(newServerName))
                return false;
            string file = DepotConnection.GetDepotFileName();
            if (!Tools.Strings.StrExt(file))
                return false;
            if (!Tools.Files.FileExists(file))
                return false;
            StringBuilder sb = new StringBuilder();
            string[] str = Tools.Strings.Split(Tools.Files.OpenFileAsString(file), "\r\n");
            foreach (string s in str)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (s.ToLower().Trim().StartsWith("<servername>" + oldServerName.ToLower() + "</servername>"))
                    sb.AppendLine(Tools.Strings.ParseDelimit(s, "<", 1) + "<servername>" + newServerName + "</servername>");  //maintain the formatting, must be lowercase
                else if(s.ToLower().Trim().StartsWith("<recallservername>" + oldServerName.ToLower() + "</recallservername>"))
                    sb.AppendLine(Tools.Strings.ParseDelimit(s, "<", 1) + "<recallservername>" + newServerName + "</recallservername>");  //maintain the formatting, must be lowercase
                else
                    sb.AppendLine(s);
            }
            if (!Tools.Files.SaveFileAsString(file, sb.ToString()))
                return false;
            file = file.Replace(Tools.Files.GetFileName(file), "");
            file = file.Replace(Tools.Folder.GetTopLevelFolderName(file), "").TrimEnd(new char[] { '\\' });
            file = Tools.Folder.ConditionFolderName(file) + "Rz4_InitialVersion\\";
            if (Tools.Folder.FolderExists(file))
                Tools.Files.SaveFileAsString(file + "depot.xml", sb.ToString());
            return true;
        }
        protected override Sys SystemCreate()
        {
            return new SysRz5();
        }
        //public n_sys WebStartUp()
        //{
        //    return SysRz4.Context.xSys;
        //}


        //OMG why isn't any of this calling Rz3App.xSys.UpdateDataStructure?
        //private void UpdateDataStructure(ContextNM context)
        //{
        //    if (Rz3App.xLogic.IsPhoenixCA && Environment.MachineName == "LAPTOP07")
        //    {
        //        if (!context.TheLeader.AreYouSure("run the structure update"))
        //            return;
        //    }

            

        //    n_class c;
        //    context.TheLeader.StartPopStatus();
        //    SortedList l = Rz3App.xSys.CoalesceClasses();
        //    nStatus.StartPercent(l.Count);
        //    foreach(DictionaryEntry d in l)
        //    {
        //        c = (n_class)d.Value;
        //        Rz3App.xSys.MakeClassDataStructure(c);
        //        //update the recall structure also
        //        if( Rz3App.xSys.Recall )
        //            Rz3App.xSys.MakeClassDataStructure(c, Rz3App.xSys.recall_connection, true);
        //        nStatus.AddPercent();
        //    }

        //    context.TheLeader.Comment("Done.");

        //    context.TheLeader.StopPopStatus(false);
        //}
        public virtual void ConnectionFailureHandle(ContextRz context)
        {
        }
        //public static String StartAndCube(String RzDatabaseName, String RzRecallDatabaseName, String RzServerName, String RzServerUserName, String RzServerPassword)
        //{
        //    String result = "";

        //    try
        //    {
        //        System.Windows.Forms.Form xForm = StartAndLogIn(RzDatabaseName, RzRecallDatabaseName, RzServerName, RzServerUserName, RzServerPassword, ref result);
        //        if (xForm == null)
        //            return result;

        //        NewMethod.nData cd = Rz3App.xSys.GetCubeData();
        //        String reason = "";
        //        if (cd.CanConnect(ref reason))
        //        {
        //            nStatus.StartLogFile(Tools.FileSystem.GetAppPath() + "AutoCubeLog.txt");

        //            //do the cubes
        //            Rz3App.xSys.CalculateAllCubes();

        //            context.TheLeader.Comment("Auto cube complete");
        //            //nStatus.StopLogFile();
        //        }
        //        else
        //        {
        //            result = "Cube data unavailable: " + reason + "   connectionstring=  " + cd.GetConnectionString();
        //            return result;
        //        }

        //        try
        //        {
        //            xForm.Close();
        //            xForm.Dispose();
        //            xForm = null;
        //        }
        //        catch { }

        //        result = "Cube complete.";
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "Error in RunRzCubeStart: " + ex.Message;
        //        return result;
        //    }
        //}

        //public static String StartAndRunTheDutyMonitor(String RzDatabaseName, String RzRecallDatabaseName, String RzServerName, String RzServerUserName, String RzServerPassword)
        //{
        //    String result = "";

        //    try
        //    {
        //        System.Windows.Forms.Form xForm = StartAndLogIn(RzDatabaseName, RzRecallDatabaseName, RzServerName, RzServerUserName, RzServerPassword, ref result);
        //        if (xForm == null)
        //            return result;

        //        frmRecogniz r = (frmRecogniz)xForm;
        //        DutyMonitor m = r.ShowDutyMonitor(true);

        //        System.Windows.Forms.Application.Run(r);

        //        try
        //        {
        //            xForm.Close();
        //            xForm.Dispose();
        //            xForm = null;
        //        }
        //        catch { }

        //        result = "Duty form closed.";
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result = "StartAndRunTheDutyMonitor: " + ex.Message;
        //        return result;
        //    }
        //}

        //public static System.Windows.Forms.Form StartAndLogIn(String RzDatabaseName, String RzRecallDatabaseName, String RzServerName, String RzServerUserName, String RzServerPassword, ref String result)
        //{
        //    StartupRz s = new StartupRz();
        //    NewMethod.nStatus.CurrentMode = NewMethod.Enums.StatusMode.NoModal;

        //    NewMethod.nStartUpArgs args = new NewMethod.nStartUpArgs();
        //    args.Silent = true;
        //    args.SuppressHook = true;
        //    args.CheckStructureUpdate = true;
        //    args.xDepot = new NewMethod.DepotConnection();

        //    args.xDepot.DatabaseName = RzDatabaseName;
        //    args.xDepot.UserName = RzServerUserName;
        //    args.xDepot.Password = RzServerPassword;
        //    args.xDepot.ServerName = RzServerName;

        //    args.xDepot.RecallDatabaseName = RzRecallDatabaseName;
        //    args.xDepot.RecallUserName = RzServerUserName;
        //    args.xDepot.RecallPassword = RzServerPassword;
        //    args.xDepot.RecallServerName = RzServerName;

        //    Rz3App.xLoginInfo = new NewMethod.LoginInfo();
        //    Rz3App.xLoginInfo.IsAutoEntered = true;
        //    Rz3App.xLoginInfo.AutoCreateSystem = true;

        //    Rz3App.xLoginInfo.strUser = "Rz System";
        //    Rz3App.xLoginInfo.strPassword = "x\r\ny";

        //    args.SuppressHook = true;

        //    System.Windows.Forms.Form xForm = s.StartUp(args);
        //    if (xForm == null)
        //    {
        //        result = "StartUp returned null";
        //        return null;
        //    }
        //    return xForm;
        //}
        protected virtual void DepotMissingConnection(StartArgsRz args)
        {
        }
        public static void DutyMonitorStart(ContextRz context, StartRz startup, StartArgsRz args)
        {           
            StartArgsRz argsRz = (StartArgsRz)args;

            args.DepotIgnore = true;
            args.TieHookSuppress = true;
            args.TheLoginInfo = new LoginInfo();
            args.TheLoginInfo.IsAutoEntered = true;
            args.TheLoginInfo.strUser = "RzSystem";
            args.TheLoginInfo.strPassword = "x\r\ny";
            args.TheLoginInfo.AutoCreateSystem = true;

            String connection_file = Tools.Folder.ConditionFolderName(Tools.Folder.GetParentFolder(Tools.Folder.GetAppPath())) + "DutyMonitorConnection.txt";
            if( !File.Exists(connection_file) )
                connection_file = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "DutyMonitorConnection.txt";

            if (File.Exists(connection_file))
            {
                String[] cfs = Tools.Strings.SplitLines(Tools.Files.OpenFileAsString(connection_file));
                if (cfs.Length >= 4)
                {
                    args.DataKey = new DataKeySql(ServerType.SqlServer);
                    args.DataKey.ServerName = cfs[0];
                    args.DataKey.UserName = cfs[1];
                    args.DataKey.UserPassword = cfs[2];
                    args.DataKey.DatabaseName = cfs[3];

                    if (cfs.Length >= 8)
                    {
                        argsRz.RecallKey.ServerName = cfs[4];
                        argsRz.RecallKey.UserName = cfs[5];
                        argsRz.RecallKey.UserPassword = cfs[6];
                        argsRz.RecallKey.DatabaseName = cfs[7];
                    }
                }
            }

            startup.Init(context, args);
            context.TheSysRz.TheDutyLogic.RunUnattendedPermanently(context);
        }
        public void DateFormatCheck(ContextRz context)
        {
            string lcid = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern.ToLower();
            bool good_format = false;
            if (lcid.Contains("/"))
            {
                string[] str = Tools.Strings.Split(lcid, "/");
                try
                {
                    if (str[0].Contains("m") && str[1].Contains("d") && str[2].Contains("y"))
                        good_format = true;
                }
                catch { }
            }
            if (!good_format)
                context.TheLeader.Tell("This machine does not appear to be configured with the ideal date format for Rz3 to function properly.\r\nPlease adjust your date settings to reflect a (M/d/yyyy) format.");
        }

        public event NothingDelegate ConnectionFailed;
        public void ConnectionFailureHandle()
        {
            if (ConnectionFailed != null)
                ConnectionFailed();
        }

        public virtual void LicenseCheck(ContextRz context)
        {
            context.TheLeader.CommentEllipse("Checking For Rz License");
            RzLicense.InitLicense(context);
            //switch (RzLicense.LicenseType)
            //{
            //    case LicenseTypes.Lite:
            //        context.TheLeader.Comment("Using Rz3 Lite");
            //        break;
            //    case LicenseTypes.Pro:
            context.TheLeader.Comment("Found Rz Pro License");
            //        break;
            //    case LicenseTypes.Ultimate:
            //        context.TheLeader.Comment("Found Rz3 Ultimate License");
            //        break;
            //}
        }
    }

    public class StartArgsRz : StartArgsNM
    {
        public DataKeySql RecallKey;
        public String CompanyIdentifier = "";
        public LoginInfo TheLoginInfo = null;

        public bool Recall
        {
            get
            {
                return RecallKey != null && RecallKey.Valid;
            }
        }
    }
}