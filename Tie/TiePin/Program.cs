using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Threading;
using System.IO;
using Tie;

using NewMethodx;

namespace TiePin
{
    static class Program
    {
        public static TieTack TheTack;
        public static System.Threading.Timer timer;
        static frmPin p = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Tools.Strings.HasString(Environment.CommandLine, "-show_settings"))
            {
                frmPins f = new frmPins();
                f.Show();
                f.CompleteLoad();
                Application.Run(f);
                return;
            }

            TheTack = new TieTack();

            if (Tools.Strings.HasString(Environment.CommandLine, "-show_status"))
            {
                p = new frmPin();
                p.Show();
                p.SetTack(TheTack);
            }

            bool s = TheTack.InitFromSettings();

            if (!s)
            {
                if (p == null)
                    return;
            }

            try
            {
                String st = TieEnd.LocalTempFolder;
                if (!Directory.Exists(st))
                    Directory.CreateDirectory(st);
            }
            catch { }

            //try the initial connection
            String str = "";
            if (!TheTack.Connect(ref str))
            {
                if (p == null)
                    return;
                else
                    TheTack.SetStatus("No connection: " + str);
            }

            if (p == null)
            {
                //run the persistence check as part of the main thread
                while (true)
                {
                    if( !CheckTack() )
                        return;

                    System.Threading.Thread.Sleep(TieEnd.PingSeconds * 1000);
                }
            }
            else
            {
                //use a timer and run on the form
                timer = new System.Threading.Timer(new TimerCallback(timer_tick));
                timer.Change(TieEnd.PingSeconds * 1000, TieEnd.PingSeconds * 1000);
                Application.Run(p);
            }
        }

        public static void timer_tick(Object x)
        {
            if (!CheckTack())
                timer.Change(-1, -1);
        }



        public static bool CheckTack()
        {
            if (TheTack == null)
                return false;

            if (TheTack.ReadyToExit)
                return false;

            try
            {

                TheTack.SetLastPing();

                if (TheTack == null)
                    return false;

                TheTack.PersistenceCheck();

                if (TheTack == null)
                    return false;

                //if its been more than 20 times the pingseconds, leave
                TimeSpan t = DateTime.Now.Subtract(TheTack.LastPing);
                if (t.TotalSeconds > (TieEnd.PingSeconds * 20))
                {
                    TheTack.SetStatus("Ping overdue");
                    try
                    {
                        TheTack.Close();
                        TheTack = null;
                    }
                    catch { }

                    return false;
                }
                else
                {
                    TheTack.CheckDuties();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}