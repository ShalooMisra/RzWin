using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Core;
using CoreWin;
using CoreDevelop;

namespace CoreDevelopWin
{
    public static class Startup
    {
        public static CoreDevelop.ContextDevelop TheContext;

        public static CoreDevelopWin.Dialogs.CoreDevelopForm Init()
        {
            System.Threading.Thread t = new Thread(new ThreadStart(ClearThreadStart));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            CoreDevelopWin.Dialogs.CoreDevelopForm f = new Dialogs.CoreDevelopForm();

            TheContext = new CoreDevelopWin.ContextDevelop();
            TheContext.TheSys = new SysCoreDevelop();
            TheContext.TheLeader = new LeaderWinUser(f);
            TheContext.TheDelta = new DeltaDevelop(TheContext);
            f.Init(TheContext);
            return f;
        }

        static void ClearThreadStart()
        {
            BoxSys.HoldClear();
        }
    }
}
