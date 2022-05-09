using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NewMethod
{
    public class LoginInfo
    {
        //Public Static Variables
        public static bool IsDevelopmentMachine = false;
        //Public Variables
        public SysNewMethod xSys;
        public String strUser = "";
        public String strPassword = "";
        public String strRequestedPassword = "";
        public bool IsReady = false;
        public bool IsCancelled = false;
        public string ErrorMessage = "";
        public bool UserProblem = false;
        public bool PasswordProblem = false;
        public bool IsAutoEntered = false;
        public bool AutoCreateSystem = false;
        public bool NewUserRequest = false;
        public String NewUserAuthorizationUser = "";
        public String NewUserAuthorizationPassword = "";
        public bool IsDemo = false;

        //Public Static Functions
        public static String GetAutoLoginFileName(String strPath)
        {
            return strPath + "al.txt";
        }
        public static bool SetAutoLogin(String user, String password)
        {
            if (password == "\r\n" || Tools.Strings.HasString(user, "recognin"))
            {
                user = "";
                //password = "jeesh";
                
            }

            String lf = GetAutoLoginFileName(nTools.GetAppParentPath());
            return Tools.Files.SaveFileAsString(lf, user + "\r\n" + password + "\r\n");
        }
        //Public Functions
        public bool GetAutoLogin(ContextNM x)
        {
            try
            {
                if (IsDemo)
                {
                    strUser = "recognin";
                    strPassword = "";
                    IsAutoEntered = true;
                    return true;
                }
                if (IsAutoEntered)
                    return true;
                String lf = GetAutoLoginFileName(nTools.GetAppParentPath());
                if (File.Exists(lf))
                {
                    String ls = Tools.Files.OpenFileAsString(lf);
                    String[] la = Tools.Strings.SplitLines(ls);
                    IsAutoEntered = true;
                    try { strUser = la[0]; }
                    catch { }
                    try { strPassword = la[1]; }
                    catch { }
                    bool bDelete = true;
                    if (xSys != null)
                    {
                        string name = n_set.GetSetting(x, "DutyMonitorServerName");
                        if (Tools.Strings.StrCmp(Environment.MachineName, name))
                            bDelete = false;
                    }
                    if (bDelete)
                        File.Delete(lf);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
