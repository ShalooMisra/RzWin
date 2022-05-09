using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConnectionManagerInit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProcessStartInfo pi = new ProcessStartInfo();
            pi.Verb = "runas";
            pi.FileName = "ConnectionManager.exe";
            Process.Start(pi);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
