using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TieServerTest
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

            //frmTieTest t = new frmTieTest();
            //t.Show();
            //t.RunTest();
            //Application.Run(t);

            frmTest2 t = new frmTest2();
            t.Show();
            Application.Run(t);

        }
    }
}