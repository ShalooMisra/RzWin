using System;
using System.Collections.Generic;
using System.Windows.Forms;

using CoreDevelopWin.Dialogs;

namespace CoreDevelopWinLoader
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

            CoreDevelopForm f = CoreDevelopWin.Startup.Init();
            if (f == null)
                return;
            
            Application.Run(f);
        }
    }
}
