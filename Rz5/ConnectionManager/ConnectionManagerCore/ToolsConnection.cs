using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

using OthersCodex;

namespace ConnectionManagerCore
{
    public static class ToolsConnection
    {
        public static string RzCustomDB = "RzInstall.mdf";
        public static string RzDBZipFile = "RzInstallDb.zip";
        public static string RzMSSqlInstanceName = "SQLEXPRESS_RZ";
        public static string RzWebsiteFolderUrl = "http://www.recognin.com/Rz/";

        public static String ConnectionFileName
        {
            get
            {
                return Tools.FileSystem.ConditionFolderName(ConnectionFolderName) + "RzConnectionSettings.txt";
            }
        }

        public static String ConnectionFolderName
        {
            get
            {
                return Tools.FileSystem.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) + "Recognin Technologies\\";
            }
        }

        public static bool ConnectionFileExists
        {
            get
            {
                return File.Exists(ConnectionFileName);
            }
        }

        public static bool ConnectionFolderMakeExist()
        {
            try
            {
                string rzAppData = ToolsConnection.ConnectionFolderName;
                if (!Directory.Exists(rzAppData))
                    Directory.CreateDirectory(rzAppData);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public static void ConnectionFileDelete()
        {
            try
            {
                File.Delete(ConnectionFileName);
            }
            catch { }
        }

        public static String ConnectionFileDataGet()
        {
            String s = Tools.FileSystem.OpenFileAsString(ConnectionFileName);
            if (s.StartsWith("<encrypted>"))
            {
                s = s.Substring(11);
                s = EncDec.Decrypt(s, "rec0gnin");
            }
            return s;
        }

        public static bool ConnectionFileDataSet(String server, String user, String password, String database)
        {
            String s = server + "\r\n" + user + "\r\n" + password + "\r\n" + database;
            s = EncDec.Encrypt(s, "rec0gnin");
            s = "<encrypted>" + s;
            return ConnectionFileDataSetDirect(s);
        }

        //public static bool ConnectionFileDataSet(String server, String user, String password, String database)
        //{
        //    String s = server + "\r\n" + user + "\r\n" + password + "\r\n" + database;
        //    s = EncDec.Encrypt(s, "rec0gnin");
        //    s = "<encrypted>" + s;
        //    return ConnectionFileDataSetDirect(s);
        //}

        public static bool ConnectionFileDataSetDirect(String data)
        {
            if (!ConnectionFolderMakeExist())
                return false;

            if (!Tools.FileSystem.SaveFileAsString(ConnectionFileName, data))
            {
                MessageBox.Show("The connection info could not be saved to " + ConnectionFileName + "\r\nThis could be because the Windows user currently logged in does not have permission to create and write to files in the Rz folder.  On Windows Vista and Windows 7, be sure that the User Account Control is disabled.  On all platforms, make sure the user has write access to the Rz and application settings folder.");
                return false;
            }
            else
                return true;
        }

        //public static String RzCustomDBPath
        //{
        //    get
        //    {
        //        return ConnectionFolderName + RzCustomDB;
        //    }
        //}

        public static String TempDatabasePathZip
        {
            get
            {

                return DatabasePathZip + ".tmp";
            }
        }

        public static String TempExpressExePath
        {
            get
            {
                return ExpressExePath + ".tmp";
            }
        }

        public static String DatabasePath
        {
            get
            {
                return ConnectionFolderName + RzCustomDB;
            }
        }

        public static String DatabasePathLog
        {
            get
            {
                return DatabasePath.Replace(".mdf", ".ldf");
            }
        }

        public static String DatabasePathZip
        {
            get
            {
                return ConnectionFolderName + RzDBZipFile;
            }
        }

        public static String ExpressExePath
        {
            get
            {
                return ToolsConnection.ConnectionFolderName + "SQLEXPR.EXE";
            }
        }

        public static bool TestConnect(ref String status)
        {
            String un = "";
            String pw = "";
            String db = "";
            String serv = "";

            ToolsConnection.ConnectionParse(ref serv, ref un, ref pw, ref db);

            String strConnect = "Provider=SQLOLEDB.1;User Id=" + un + ";Password=" + pw + ";Initial Catalog=" + db + ";Data Source=" + serv + ";Connect Timeout=4";

            OleDbConnection xConnect;

            try
            {
                xConnect = new OleDbConnection(strConnect);
                //xConnect.ConnectionTimeout = 4000;
                xConnect.Open();
                xConnect.Close();
                xConnect.Dispose();
                xConnect = null;
                status = "Success";
                return true;
            }
            catch (Exception e)
            {
                status = "[" + serv + "] " + e.Message;
                return false;
            }
        }

        public static void ConnectionParse(ref String server, ref String user, ref String password, ref String database)
        {
            server = "";
            user = "";
            password = "";
            database = "";

            String[] ary = Tools.Strings.Split(ConnectionFileDataGet(), "\r\n");
            if (ary.Length < 3)
                return;
            server = ary[0];
            user = ary[1];
            password = ary[2];

            if (ary.Length > 3)
                database = ary[3];
        }

        public static void ConnectionManagerRestart()
        {
            Tools.FileSystem.Shell(Tools.FileSystem.GetAppPath() + "ConnectionManager.exe", "");
        }

        public static void ConnectionManagerRestart(string controlName)
        {
            Tools.FileSystem.Shell(Tools.FileSystem.GetAppPath() + "ConnectionManager.exe", controlName);
        }
    }
}
