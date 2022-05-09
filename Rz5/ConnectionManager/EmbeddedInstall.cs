using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
//using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography;
using System.Threading;
using System.Xml;
using System.Management;

//using ICSharpCode;
using NewMethodx;
using OthersCodex;

namespace ConnectionManager
{
    public class EmbeddedInstall
    {
        //Public Properties
        public string InstanceName
        {
            get
            {
                return instanceName;
            }
            set
            {
                instanceName = value;
            }
        }
        public string SetupFileLocation
        {
            get
            {
                return sqlExpressSetupFileLocation;
            }
            set
            {
                sqlExpressSetupFileLocation = value;
            }
        }
        //public string SqlInstallDirectory
        //{
        //    get
        //    {
        //        return installSqlDir;
        //    }
        //    set
        //    {
        //        installSqlDir = value;
        //    }
        //}
        //public string SqlInstallSharedDirectory
        //{
        //    get
        //    {
        //        return installSqlSharedDir;
        //    }
        //    set
        //    {
        //        installSqlSharedDir = value;
        //    }
        //}
        //public string SqlDataDirectory
        //{
        //    get
        //    {
        //        return installSqlDataDir;
        //    }
        //    set
        //    {
        //        installSqlDataDir = value;
        //    }
        //}
        public bool AutostartSQLService
        {
            get
            {
                return sqlAutoStart;
            }
            set
            {
                sqlAutoStart = value;
            }
        }
        public bool AutostartSQLBrowserService
        {
            get
            {
                return sqlBrowserAutoStart;
            }
            set
            {
                sqlBrowserAutoStart = value;
            }
        }
        //public string SqlBrowserAccountName
        //{
        //    get
        //    {
        //        return sqlBrowserAccount;
        //    }
        //    set
        //    {
        //        sqlBrowserAccount = value;
        //    }
        //}
        //public string SqlBrowserPassword
        //{
        //    get
        //    {
        //        return sqlBrowserPassword;
        //    }
        //    set
        //    {
        //        sqlBrowserPassword = value;
        //    }
        //}
        public string SqlServiceAccountName
        {
            get
            {
                return sqlAccount;
            }
            set
            {
                sqlAccount = value;
            }
        }
        public string SqlServicePassword
        {
            get
            {
                return sqlPassword;
            }
            set
            {
                sqlPassword = value;
            }
        }
        public string SqlAgentServiceAccountName
        {
            get
            {
                return agentAccount;
            }
            set
            {
                agentAccount = value;
            }
        }
        public string SqlAgentServicePassword
        {
            get
            {
                return agentPassword;
            }
            set
            {
                agentPassword = value;
            }
        }
        public string SqlAdminAccountName
        {
            get
            {
                return adminAccount;
            }
            set
            {
                adminAccount = value;
            }
        }
        public string SqlAdminPassword
        {
            get
            {
                return adminPassword;
            }
            set
            {
                adminPassword = value;
            }
        }
        public bool UseSQLSecurityMode
        {
            get
            {
                return sqlSecurityMode;
            }
            set
            {
                sqlSecurityMode = value;
            }
        }
        public string SysadminPassword
        {
            set
            {
                saPassword = value;
            }
        }
        public string Collation
        {
            get
            {
                return sqlCollation;
            }
            set
            {
                sqlCollation = value;
            }
        }
        //public bool DisableNetworkProtocols
        //{
        //    get
        //    {
        //        return disableNetworkProtocols;
        //    }
        //    set
        //    {
        //        disableNetworkProtocols = value;
        //    }
        //}
        public bool ReportErrors
        {
            get
            {
                return errorReporting;
            }
            set
            {
                errorReporting = value;
            }
        }
        //Private Variables
        private string instanceName = "SQLEXPRESS_RZ";
        //private string installSqlDir = "";
        //private string installSqlSharedDir = "";
        //private string installSqlDataDir = "";
        //private string addLocal = "All";
        private bool sqlAutoStart = true;
        private bool sqlBrowserAutoStart = false;
        //private string sqlBrowserAccount = "NT AUTHORITY\\SYSTEM";
        //private string sqlBrowserPassword = "";
        private string sqlAccount = "NT AUTHORITY\\SYSTEM";
        private string sqlPassword = "";
        private string agentAccount = "NT AUTHORITY\\SYSTEM";
        private string agentPassword = "";
        private string adminAccount = "BUILTIN\\ADMINISTRATORS";
        private string adminPassword = "";
        private bool sqlSecurityMode = false;
        private string saPassword = "";
        private string sqlCollation = "";
        private bool sqlTCPEnabled = true;
        //private bool disableNetworkProtocols = true;
        private bool errorReporting = true;
        private string sqlExpressSetupFileLocation = System.Environment.GetEnvironmentVariable("TEMP") + "\\sqlexpr.exe";

        //Public Static Functions
        public static bool IsRzExpressInstalled()
        {

            if (IsRzExpressRunning())
                return true;
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SQL Server\\", RegistryKeyPermissionCheck.ReadSubTree))
            {

                if (Key == null) return false;
                string[] strNames = Key.GetSubKeyNames();

                //If we cannot find a SQL Server registry key, we don't have SQL Server Express installed
                if (strNames.Length == 0) return false;

                foreach (string s in strNames)
                {
                    if (s == "SQLEXPRESS_RZ")
                        return true;
                }
                return false;
            }
        }
        public static bool IsRzExpressRunning()
        {
            //this threw management and out of memory errors for some reason
            //StringBuilder sb = new StringBuilder();
            //List<ManagementObject> arrServices = new List<ManagementObject>();
            //ManagementClass mcServices = new ManagementClass("Win32_Service");
            //ManagementObjectCollection c = mcServices.GetInstances();
            //foreach (ManagementObject moService in c)
            //{
            //    string serv = moService.GetPropertyValue("Name").ToString();
            //    sb.AppendLine(serv);
            //    if (serv.Contains("_RZ"))
            //        return true;
            //}
            ////if (nTools.IsDevelopmentMachinePlain())
            ////    nTools.PopText(sb.ToString());
            //return false;

            try
            {
                System.ServiceProcess.ServiceController controller = new System.ServiceProcess.ServiceController("MSSQL$SQLEXPRESS_RZ");
                if (controller == null)
                    return false;

                if (controller.Status != System.ServiceProcess.ServiceControllerStatus.Running)
                    return false;
 
                controller.Dispose();
                controller = null;
                return true;
            }
            catch { return false; }
        }
        //Public Functions
        public int EnumSQLInstances(ref string[] strInstanceArray, ref string[] strEditionArray, ref string[] strVersionArray)
        {
            using (RegistryKey Key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Microsoft SQL Server\\", false))
            {
                if (Key == null) return 0;
                string[] strNames;
                strNames = Key.GetSubKeyNames();

                //If we can not find a SQL Server registry key, we return 0 for none
                if (strNames.Length == 0) return 0;

                //How many instances do we have?
                int iNumberOfInstances = 0;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                        iNumberOfInstances++;
                }

                //Reallocate the string arrays to the new number of instances
                strInstanceArray = new string[iNumberOfInstances];
                strVersionArray = new string[iNumberOfInstances];
                strEditionArray = new string[iNumberOfInstances];
                int iCounter = 0;

                foreach (string s in strNames)
                {
                    if (s.StartsWith("MSSQL."))
                    {
                        //Get Instance name
                        using (RegistryKey KeyInstanceName = Key.OpenSubKey(s.ToString(), false))
                        {
                            strInstanceArray[iCounter] = (string)KeyInstanceName.GetValue("");
                        }

                        //Get Edition
                        using (RegistryKey KeySetup = Key.OpenSubKey(s.ToString() + "\\Setup\\", false))
                        {
                            strEditionArray[iCounter] = (string)KeySetup.GetValue("Edition");
                            strVersionArray[iCounter] = (string)KeySetup.GetValue("Version");
                        }

                        iCounter++;
                    }
                }
                return iCounter;
            }
        }
        public bool InstallExpress(string installLocation)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = installLocation;
            myProcess.StartInfo.Arguments = "/QS /ACTION=Install " + BuildCommandLine();
            if (nTools.IsDevelopmentMachinePlain())
                nTools.PopText(myProcess.StartInfo.Arguments);
            myProcess.StartInfo.UseShellExecute = false;
            return myProcess.Start();
        }
        //Private Functions
        private string BuildCommandLine()
        {
            StringBuilder strCommandLine = new StringBuilder();
            strCommandLine.Append(" /TCPENABLED=");
            if (sqlTCPEnabled)
                strCommandLine.Append("1");
            else
                strCommandLine.Append("0");
            strCommandLine.Append(" /SQLSVCSTARTUPTYPE=");
            if (sqlAutoStart)
                strCommandLine.Append("Automatic");
            else
                strCommandLine.Append("Manual");
            if (!string.IsNullOrEmpty(sqlAccount))
                strCommandLine.Append(" /SQLSVCACCOUNT=\"").Append(sqlAccount).Append("\"");
            if (!string.IsNullOrEmpty(sqlPassword))
                strCommandLine.Append(" /SQLSVCPASSWORD=\"").Append(sqlPassword).Append("\"");
            if (!string.IsNullOrEmpty(agentAccount))
                strCommandLine.Append(" /AGTSVCACCOUNT=\"").Append(agentAccount).Append("\"");
            if (!string.IsNullOrEmpty(agentPassword))
                strCommandLine.Append(" /AGTSVCPASSWORD=\"").Append(agentPassword).Append("\"");
            if (!string.IsNullOrEmpty(adminAccount))
                strCommandLine.Append(" /SQLSYSADMINACCOUNTS=\"").Append(adminAccount).Append("\"");
            if (!string.IsNullOrEmpty(adminPassword))
                strCommandLine.Append(" /SQLSYSADMINACCOUNTS=\"").Append(adminPassword).Append("\"");
            strCommandLine.Append(" /BROWSERSVCSTARTUPTYPE=");
            if (sqlBrowserAutoStart)
                strCommandLine.Append("Automatic");
            else
                strCommandLine.Append("Manual");
            if (sqlSecurityMode == true)
                strCommandLine.Append(" /SECURITYMODE=SQL");
            if (!string.IsNullOrEmpty(saPassword))
                strCommandLine.Append(" /SAPWD=\"").Append(saPassword).Append("\"");
            if (!string.IsNullOrEmpty(sqlCollation))
                strCommandLine.Append(" /SQLCOLLATION=\"").Append(sqlCollation).Append("\"");
            strCommandLine.Append(" /ERRORREPORTING=");
            if (errorReporting == true)
                strCommandLine.Append("1");
            else
                strCommandLine.Append("0");
            if (instanceName != "SQLEXPRESS")
                strCommandLine.Append(" /INSTANCENAME=" + instanceName);
            strCommandLine.Append(" /FEATURES=SQL,ADV_SSMS");
            return strCommandLine.ToString();
        }
        //private string BuildCommandLine()
        //{
        //    StringBuilder strCommandLine = new StringBuilder();
        //    if (!string.IsNullOrEmpty(installSqlDir))
        //        strCommandLine.Append("INSTALLSQLDIR=\"").Append(installSqlDir).Append("\"");
        //    if (!string.IsNullOrEmpty(installSqlSharedDir))
        //        strCommandLine.Append("INSTALLSQLSHAREDDIR=\"").Append(installSqlSharedDir).Append("\"");
        //    if (!string.IsNullOrEmpty(installSqlDataDir))
        //        strCommandLine.Append("INSTALLSQLDATADIR=\"").Append(installSqlDataDir).Append("\"");
        //    if (!string.IsNullOrEmpty(addLocal))
        //        strCommandLine.Append(" ADDLOCAL=\"").Append(addLocal).Append("\"");
        //    if (sqlAutoStart)
        //        strCommandLine.Append(" SQLAUTOSTART=1");
        //    else
        //        strCommandLine.Append(" SQLAUTOSTART=0");
        //    if (sqlBrowserAutoStart)
        //        strCommandLine.Append(" SQLBROWSERAUTOSTART=1");
        //    else
        //        strCommandLine.Append(" SQLBROWSERAUTOSTART=0");
        //    if (!string.IsNullOrEmpty(sqlBrowserAccount))
        //        strCommandLine.Append(" SQLBROWSERACCOUNT=\"").Append(sqlBrowserAccount).Append("\"");
        //    if (!string.IsNullOrEmpty(sqlBrowserPassword))
        //        strCommandLine.Append(" SQLBROWSERPASSWORD=\"").Append(sqlBrowserPassword).Append("\"");
        //    if (!string.IsNullOrEmpty(sqlAccount))
        //        strCommandLine.Append(" SQLACCOUNT=\"").Append(sqlAccount).Append("\"");
        //    if (!string.IsNullOrEmpty(sqlPassword))
        //        strCommandLine.Append(" SQLPASSWORD=\"").Append(sqlPassword).Append("\"");
        //    if (sqlSecurityMode == true)
        //        strCommandLine.Append(" SECURITYMODE=SQL");
        //    if (!string.IsNullOrEmpty(saPassword))
        //        strCommandLine.Append(" SAPWD=\"").Append(saPassword).Append("\"");
        //    if (!string.IsNullOrEmpty(sqlCollation))
        //        strCommandLine.Append(" SQLCOLLATION=\"").Append(sqlCollation).Append("\"");
        //    if (disableNetworkProtocols == true)
        //        strCommandLine.Append(" DISABLENETWORKPROTOCOLS=1");
        //    else
        //        strCommandLine.Append(" DISABLENETWORKPROTOCOLS=0");
        //    if (errorReporting == true)
        //        strCommandLine.Append(" ERRORREPORTING=1");
        //    else
        //        strCommandLine.Append(" ERRORREPORTING=0");
        //    if (instanceName != "SQLEXPRESS")
        //        strCommandLine.Append(" INSTANCENAME=" + instanceName);
        //    return strCommandLine.ToString();
        //}
    }
}


