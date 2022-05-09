using System;
using System.Collections.Generic;
using System.Text;

using NewMethod;

namespace NewMethodWeb
{
    public class StartupWeb
    {
        public String UserEntered;
        public String PasswordEntered;
        StartNM Start;
        public StartupWeb(StartNM start)
        {
            Start = start;
            start.LoginPre += new LoginPreHandler(start_LoginPre);
            start.Login += new LoginHandler(start_Login);
        }

        ~StartupWeb()
        {
            Start.LoginPre -= new LoginPreHandler(start_LoginPre);
            Start.Login -= new LoginHandler(start_Login);
        }

        void start_Login(ContextNM q)
        {
            if (!HandleLogin(q))
                throw new Exception("HandleLogin failed");
        }

        void start_LoginPre(ContextNM q)
        {
            //HandleLoginPre();
        }

        public virtual bool HandleLogin(ContextNM q)
        {
            return false;
        }
    }
}
