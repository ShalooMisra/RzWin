using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NewMethodx;

using Tie;
using TiePin;

namespace TieServiceManager
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

            if (Tools.Strings.HasString(System.Environment.CommandLine, "-do_nothing"))
            {
                return;
            }

            if (Tools.Strings.HasString(System.Environment.CommandLine, "-restart"))
            {
                Tools.FileSystem.Shell(Tools.FileSystem.GetAppPath() + "TieServiceManager.exe");
                return;
            }

            frmPins f = new frmPins();
            f.Show();
            f.CompleteLoad(true, false);
            //f.Text = Environment.CommandLine;
            Application.Run(f);
        }
    }
}