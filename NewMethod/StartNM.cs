using System;
using System.Collections;
using System.Text;
using Core;

namespace NewMethod
{
    public class StartNM : Start
    {
        public static bool ShowLinksOption = false;
        public event LoginPreHandler LoginPre;
        public event LoginHandler Login;

        public void LoginPreFire(ContextNM context)
        {
            try
            {
                if (LoginPre != null)
                    LoginPre(context);
            }
            catch (Exception)
            {
                ;
            }
        }

        public void LoginFire(ContextNM q)
        {
            if (Login != null)
                Login(q);
            else
                throw new Exception("Login process is not assigned");
        }
    }

    public delegate void LoginHandler(ContextNM q);
    public delegate void LoginPreHandler(ContextNM q);

    public class StartArgsNM : StartArgs
    {
        public DataKeySql RecallKey = null;    
        public bool DepotIgnore = false;
        public bool TieHookSuppress = false;
    }

    public class DepotConnection
    {
        //Public Variables
        public String Description = "";
        public String ServerName = "";
        public String DatabaseName = "";
        public String UserName = "";
        public String Password = "";
        public String RecallServerName = "";
        public String RecallDatabaseName = "";
        public String RecallUserName = "";
        public String RecallPassword = "";


        public static String GetDepotFileName()
        {
            String oldFile = Tools.FileSystem.GetAppPath() + "depot.xml";
            //String newFile = Tools.Files

            return oldFile;
        }
        public static bool DepotFileExists()
        {
            return System.IO.File.Exists(GetDepotFileName());
        }
    }
}
