using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NewMethod;

namespace Rz5
{
    public static class RzWin
    {
        public static ContextRz Context
        {
            get
            {
                return (ContextRz)NMWin.ContextDefault;
            }
        }

        public static n_user User
        {
            get
            {
                return (n_user)NMWin.User;
            }
        }

        public static LeaderWinUserRz Leader
        {
            get
            {
                return (LeaderWinUserRz)NMWin.Leader;
            }
        }

        public static RzLogic Logic
        {
            get
            {
                return (RzLogic)Context.Logic;
            }
        }

        public static frmRecogniz Form
        {
            get
            {
                return Leader.TheRzForm;
            }
        }

        public static SysRz5 Sys
        {
            get
            {
                return Context.Sys;
            }
        }

        public static AccountLogic Accounts
        {
            get
            {
                return Sys.TheAccountLogic;
            }
        }
    }
}
