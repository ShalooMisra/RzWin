using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Tools;

namespace NewMethod.Win
{
    public class StartupWin
    {
        StartNM Start;
        public StartupWin(ContextNM context, StartNM start)
        {
            NMWin.ContextDefault = context;
            Start = start;
            start.LoginPre += new LoginPreHandler(start_LoginPre);
            start.Login += new LoginHandler(start_Login);
        }

        ~StartupWin()
        {
            Start.LoginPre -= new LoginPreHandler(start_LoginPre);
            Start.Login -= new LoginHandler(start_Login);
        }

        public virtual void Startup(ContextNM q)
        {
            Form xForm = FormMainCreateAndShow(q);
            if (xForm == null)
            {
                return;
            }
            try { Application.Run(xForm); }
            catch(Exception ex)
            {
                q.Leader.Tell(ex.Message);
            }
        }

        void start_Login(ContextNM q)
        {
            HandleLogin(q);
        }

        void start_LoginPre(ContextNM q)
        {
            HandleLoginPre(q);
        }

        public virtual Form FormMainCreateAndShow(ContextNM q)
        {
            return null;
        }

        public virtual Form FormMainCreate(ContextNM q)
        {
            return null;
        }

        public virtual void HandleLoginPre(ContextNM q)
        {

        }

        public virtual void HandleLogin(ContextNM q)
        {

        }
    }
}
