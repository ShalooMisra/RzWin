using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Core;
using NewMethod;
using NewMethod.Win;
using Tools.Database;

namespace Test
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

            ContextNM x = new ContextNM();
            NMWin.ContextDefault = x;
            x.TheSys = new SysNM();
            x.TheData = new Core.DataSql(@"LAPTOP07\SQLEXPRESS", "sa", "rec0gnin", "NMTest", ServerType.SqlServer);
            
            x.StructureCheck();

            x.xSys.CacheUsers(x);
            x.xSys.FillTeamTree(x);
            x.xSys.CacheChoices(x);

            frmMain f = new frmMain();
            x.TheLeader = new LeaderWinUserNM(f);

            ProveResult r = x.TheSys.Prove(x);
            if (r.Passed)
            {
                Application.Run(f);
            }
            else
                MessageBox.Show(r.ToString());
        }
    }
}
