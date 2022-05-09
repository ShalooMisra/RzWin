using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Core;
using CoreWin;
using NewMethod;
using NewMethod.Win;

namespace Rz5
{
    public class StartupRzWin : StartupWin
    {
        public StartupRzWin(ContextRz context, StartNM start)
            : base(context, start)
        {
            ((StartRz)start).ConnectionFailed += new NothingDelegate(StartupRzWin_ConnectionFailed);
        }

        void StartupRzWin_ConnectionFailed()
        {
            RzWin.Leader.Comment("Starting the connection manager.");
            Tools.FileSystem.Shell(nTools.GetAppParentPath() + @"ConnectionManager\ConnectionManager.exe");
        }

        public override Form FormMainCreateAndShow(ContextNM q)

        {
            //KT added the if, and put original code in the else // Need also to check for Test System.
            //I'm checkiong for xUser to allow the publish project to work as it doesn't have recall.      
            bool skipRecall = false;
            if (RzWin.Context.Data.ServerName.Contains("localhost"))
                skipRecall = true;

            if (Tools.Strings.HasString(RzWin.Context.Data.DatabaseName, "recent"))
                skipRecall = true;

            if (Tools.Strings.HasString(RzWin.Context.Data.DatabaseName, "test"))
                skipRecall = true;
            //if (RzWin.Context.xUser.Name != "Recognin Technologies")
            //    skipRecall = true;

            if (!q.Sys.Recall && !skipRecall)
            {
                q.Leader.Tell("This system is not configured for Recall, please see your system administrator.");
                return null;
            }

            //KT - Original Rz Code
            Form ret = FormMainCreate(q);
            RzWin.Leader.TheMainForm = (frmRecogniz)ret;
            RzWin.Form.Init(q);

            if (RzWin.Logic.IsBelowMinVersion(RzWin.Context))
            {
                RzWin.Leader.Comment("Showing below min warning...");
                RzWin.Form.ShowUpdateWarning();
            }
            RzWin.Form.Show();
            return ret;




        }

        public override Form FormMainCreate(ContextNM context)
        {
            return new frmRecogniz();
        }

        public override void HandleLoginPre(ContextNM context)
        {
            base.HandleLoginPre(context);
            ((ContextRz)context).TheLeaderRz.PopLogin((ContextRz)context);
        }

        public override void HandleLogin(ContextNM q)
        {
            ContextRz qrz = (ContextRz)q;

            LoginInfo xLoginInfo = ((LeaderWinUserRz)q.TheLeader).xLoginInfo;
            //xLoginInfo.GetAutoLogin(q);

            if (!xLoginInfo.IsAutoEntered)
            {
                if (!xLoginInfo.IsReady)
                {
                    qrz.TheLeaderRz.CheckLogin();
                }
            }

            try
            {
                qrz.TheLeaderRz.CloseLogin();
            }
            catch { }

            qrz.TheSysRz.TheUserLogicRz.CheckLogin(qrz, xLoginInfo);

        }

        public virtual Leader LeaderCreate(MainForm f)
        {
            return new LeaderWinUserRz(f);
        }
    }
}
