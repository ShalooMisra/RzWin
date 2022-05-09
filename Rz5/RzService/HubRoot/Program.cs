using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace HubRoot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AddLog("Starting main...");

            AppDomain d = AppDomain.CurrentDomain;
            d.UnhandledException += new UnhandledExceptionEventHandler(d_UnhandledException);

            int port = 2949;
            String password = "thepassword";
            String[] s = System.Environment.CommandLine.Split("=".ToCharArray());
            try
            {
                port = int.Parse(s[1]);
                password = s[2];
            }
            catch
            { }

            AddLog("Using port " + port.ToString());
            AddLog("Using password " + password);

            HubEye h = new HubEye();
            h.Start(port, password);
            h.ServerEye.ListenThread.Join();
            AddLog("Exiting");

        }

        static void d_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AddLog("UnhandledException: " + e.ExceptionObject.ToString());
            AddLog("e.IsTerminating=" + e.IsTerminating.ToString());
        }

        public static void AddLog(String s)
        {
            try
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "RzServiceEye.txt";
                if (!File.Exists(strFile))
                {
                    FileStream st = File.Create(strFile);
                    st.Close();
                    st.Dispose();
                    st = null;
                }

                StreamWriter f = new StreamWriter(strFile, true);
                f.WriteLine(DateTime.Now.ToString() + " : " + s);
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }
        }
    }
}
