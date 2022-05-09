using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using System.IO;
using System.Windows.Forms;

//using OthersCodex;
using NewMethod;

//this is a copy of the one in the connectionmanagercore app; not the same file

namespace ConnectionManager
{
    public static class ToolsConnection
    {
        public static String ConnectionFileName
        {
            get
            {
                return Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) + "Recognin Technologies\\RzConnectionSettings.txt";
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

        public static String ConnectionFileDataGetWithFix()
        {
            try
            {
                String dir = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)) + "Recognin Technologies\\";
                if(!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }
            catch { }


            try
            {

                if (!File.Exists(ConnectionFileName))
                {
                    String x = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "c.txt";
                    if (File.Exists(x))
                        File.Copy(x, ConnectionFileName);
                    else
                    {
                        x = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + "c.txt";
                        if (File.Exists(x))
                            File.Copy(x, ConnectionFileName);
                        else
                        {
                            x = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)) + "RzConnectionSettings.txt";
                            if (File.Exists(x))
                                File.Copy(x, ConnectionFileName);
                        }
                    }
                }

                return ConnectionFileDataGet();
            }
            catch(Exception ex)
            {
                return Tools.Files.OpenFileAsString(Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "c.txt");
            }
        }

        public static String ConnectionFileDataGet()
        {
            String s = Tools.Files.OpenFileAsString(ConnectionFileName);
            if (s.StartsWith("<encrypted>"))
            {
                s = s.Substring(11);
                //s = EncDec.Decrypt(s, "rec0gnin");
            }
            return s;
        }

        public static bool ConnectionFileDataSet(String server, String user, String password, String database)
        {
            String s = server + "\r\n" + user + "\r\n" + password + "\r\n" + database;
            //s = EncDec.Encrypt(s, "rec0gnin");
            s = "<encrypted>" + s;

            return ConnectionFileDataSet(s);
        }

        public static bool ConnectionFileDataSet(String data)
        {
            if (!Tools.Files.SaveFileAsString(ConnectionFileName, data))
            {
                MessageBox.Show("The connection info could not be saved.  This could be because the Windows user currently logged in does not have permission to create and write to files in the Rz folder.  On Vista and Windows 7, run Rz as a Windows Administrator or consider disabling the User Account Control security feature.  On all platforms, make sure the user has write access to the Rz and application settings folder.");
                return false;
            }
            else
                return true;
        }

        public static bool TestConnect(ref String status)
        {
            String un = "";
            String pw = "";
            String db = "";
            String serv = "";

            ToolsConnection.ConnectionParse(ref serv, ref un, ref pw, ref db);

            String strConnect = "Provider=SQLOLEDB.1;User Id=" + un + ";Password=" + pw + ";Initial Catalog=" + db + ";Data Source=" + serv;

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

        public static bool ConnectionSettingsImport(String key)
        {
            String url = "http://www.recognin.com/" + key + "/RzConnectionSettings.txt";
            String s = Tools.Strings.DownloadInternetString(url);
            if (nTools.StartsWith(s, "<encrypted>"))
            {
                return ConnectionFileDataSet(s);
            }
            else
            {
                MessageBox.Show("No connection settings were found ( looking for <encrypted> @ " + url + ")");
                return false;
            }
        }

        public static bool ConnectionSettingsImportIfMissing(String key)
        {
            if (File.Exists(ConnectionFileName))
                return true;

            return ConnectionSettingsImport(key);
        }
    }
}
