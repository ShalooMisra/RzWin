using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.IO;

using ConnectionManagerCore;

namespace ConnectionManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool restart = false;
            if( HasString(System.Environment.CommandLine, "-restart") )
            {
                restart = true;
                Shell(GetAppPath() + "ConnectionManager.exe", "");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists(ToolsConnection.ConnectionFileName))
            {
                ConnectionTest f = new ConnectionTest();
                f.Init();
                Application.Run(f);
            }
            else
            {
                if (SystemBitDetection.Is64BitOperatingSystem())
                    ConnectionManager.FileName = "SQLEXPR_x64_ENU.exe";
                else
                    ConnectionManager.FileName = "SQLEXPR_x86_ENU.exe";
                if (restart)
                {
                    ConnectionManager connectionManager = new ConnectionManager(restart);
                    Application.Run(connectionManager);
                }
                else
                {
                    ConnectionManager connectionManager = new ConnectionManager();
                    Application.Run(connectionManager);
                }
            }
        }
        //Public Static Functions
        public static bool HasString(string str, string f)
        {
            if (str == null)
                return false;

            if (f == null)
                return false;

            long l = str.ToLower().IndexOf(f.ToLower());
            return l >= 0;
        }
        public static String GetAppPath()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim()));
            if (!sb.ToString().EndsWith("\\") )
                sb.Append("\\");
            return sb.ToString();
        }
        public static bool Shell(String strFilePath, String strArguments)
        {
            try
            {
                System.Diagnostics.Process x = new System.Diagnostics.Process();
                x.StartInfo.Verb = "runas";
                x.StartInfo.FileName = strFilePath;
                x.StartInfo.Arguments = strArguments;
                x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                x.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}