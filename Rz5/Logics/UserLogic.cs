using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Core;
using NewMethod;
using Tools;

namespace Rz5
{
    public class UserLogic : NewMethod.UserLogic
    {

        //public virtual bool IsAccountant()
        //{
        //    return false;
        //}


        public virtual bool GetTaskUserName(ref string name)
        {
            name = "Joel Waechter";
            return true;
        }
        public virtual ArrayList GetAccountingUsers(ContextNM x)
        {
            return new ArrayList();
        }

        public bool UserChange(ContextRz context)
        {
            LoginInfo info = context.TheLeaderRz.LoginInfoAskOnThread(context, true);
            if (info == null)
                return false;

            try
            {
                context.TheSysRz.TheUserLogicRz.CheckLogin(context, info);
                context.TheLeaderRz.UserApply(context);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CheckLogin(ContextRz context, LoginInfo xLoginInfo)
        {
            if (xLoginInfo.IsCancelled)
                throw new Exception("Login canceled");

            if (xLoginInfo.AutoCreateSystem)
            {
                context.TheLeader.Comment("xLoginInfo.AutoCreateSystem == true");
                NewMethod.n_user u = NewMethod.n_user.GetByName(context, xLoginInfo.strUser);
                if (u == null)
                {
                    u = n_user.New(context);
                    u.super_user = true;
                    u.template_editor = true;
                    u.name = xLoginInfo.strUser;
                    u.login_name = xLoginInfo.strUser;
                    u.login_password = xLoginInfo.strPassword;
                    context.Insert(u);
                    context.xSys.CacheUsers(context);
                }
            }

            if (xLoginInfo.NewUserRequest)
            {
                context.TheLeader.Comment("xLoginInfo.NewUserRequest == true");
                LoginInfo la = new LoginInfo();
                la.strUser = xLoginInfo.NewUserAuthorizationUser;
                la.strPassword = xLoginInfo.NewUserAuthorizationPassword;
                bool success = false;

                NewMethod.n_user existing = NewMethod.n_user.GetByName(context, xLoginInfo.strUser);
                if (existing == null)
                {
                    existing = (NewMethod.n_user)context.QtO("n_user", "select * from n_user where login_name = '" + context.Filter(xLoginInfo.strUser) + "'");
                }
                if (existing != null)
                {
                    context.TheLeader.Tell("The user account '" + xLoginInfo.strUser + "' is already in Rz");
                }
                else
                {
                    NewMethod.n_user auth = UserGetValidateByLogin(context, la, ref success);
                    if (!success)
                    {
                        context.TheLeader.Tell("The authorization info couldn't be located");
                    }
                    else
                    {
                        if (auth.SuperUser)
                        {
                            n_user u = n_user.New(context);
                            //u.super_user = true;
                            u.name = xLoginInfo.strUser;
                            u.login_name = xLoginInfo.strUser;
                            u.login_password = xLoginInfo.strPassword;
                            context.Insert(u);
                            context.xSys.CacheUsers(context);
                        }
                        else
                        {
                            context.TheLeader.Tell("The authorization account is not configured to add new users");
                        }
                    }
                }
            }

            while (!VerifyLoginData(context, xLoginInfo))
            {
                if (xLoginInfo.IsAutoEntered)
                    throw new Exception("Auto-entered login info could not be accepted: " + xLoginInfo.ErrorMessage);

                xLoginInfo = context.TheLeaderRz.LoginInfoAskOnThread(context, true, xLoginInfo);

                if (xLoginInfo == null || xLoginInfo.IsCancelled)
                    throw new Exception("Login process canceled");
            }

            //if (!context.xUser.IsDeveloper() && !Tools.Strings.StrExt(Tools.OperatingSystem.GetCrumb("hide_login_name")))
            if (!Tools.Strings.StrExt(Tools.OperatingSystem.GetCrumb("hide_login_name")))
                Tools.OperatingSystem.DropCrumb("last_login_name", context.xUser.login_name);

            context.xUser.latest_version = Tools.Misc.GetVersionString(ToolsNM.AssemblyNM);
            context.xUser.Update(context);

            context.xUser.GatherAll(context);
        }




        //frmChooseUser_Multiple

        public bool VerifyLoginData(ContextRz context, LoginInfo info)
        {
            info.ErrorMessage = "";
            info.UserProblem = false;
            info.PasswordProblem = false;
            bool ret = false;

            //xUser = (n_user)UserGetValidateByLogin(xLoginInfo, ref ret);

            //2011_03_02 changed this so that a null return from userget... doesn't set the user to null
            //also switched it to use contextdefault.xUser

            //n_user u = (n_user)UserGetValidateByLogin(context, info, ref ret);
            //Chck for empty password for user          





            n_user u = (n_user)UserGetValidateByLoginHash(context, info, ref ret);
            //if (u == null)
            //{
            //    //nfo.ErrorMessage = "Invalid username or password";
            //    info.PasswordProblem = true;
            //    return false;
            //}

            context.xUser = u;
            return ret;
        }
        //KT - had to change password here too
        public n_user UserGetValidateByLogin(ContextRz context, LoginInfo info, ref bool success)
        {
            //if (Tools.Strings.StrCmp(info.strPassword, "jeesh"))
            //{
            //    success = false;
            //    //return (n_user)MakeRecogninUser(context);
            //    return MakeSuperUser(context);
            //}
            if (!Tools.Strings.StrExt(info.strUser))
            {
                info.ErrorMessage = "The user '" + info.strUser + "' could not be found.";
                info.UserProblem = true;
                success = false;
                return null;
            }
            n_user u = (n_user)context.QtO("n_user", "select * from n_user where login_name = '" + context.Filter(info.strUser) + "' or name = '" + context.Filter(info.strUser) + "' or email_address = '" + context.Filter(info.strUser) + "'");
            if (u == null)
            {
                info.ErrorMessage = "The user '" + info.strUser + "' could not be found.";
                info.UserProblem = true;
                success = false;
                return null;
            }
            if (Tools.Strings.StrExt(u.login_password) && !Tools.Strings.StrCmp(u.login_password, info.strPassword) && !Tools.Strings.StrCmp("redacted", info.strPassword))
            {
                info.ErrorMessage = "The entered password for '" + info.strUser + "' was incorrect.";
                info.PasswordProblem = true;
                success = false;
                return null;
            }
            if (Tools.Strings.StrExt(info.strRequestedPassword))
            {
                u.login_password = info.strRequestedPassword;
                context.Update(u);
            }

            success = true;
            return u;
        }






        //public n_user UserGetValidateByLoginCust(ContextRz context, LoginInfo info, ref bool success)
        //{
        //    if (!Tools.Strings.StrExt(info.strUser))
        //    {
        //        info.ErrorMessage = "The user '" + info.strUser + "' could not be found.";
        //        info.UserProblem = true;
        //        success = false;
        //        return null;
        //    }
        //    company c = (company)context.QtO(context.xSys.xData, "company", "select * from company where internetusername = '" + SysRz4.Context.context.Filter(info.strUser) + "' and internetpassword = '" + SysRz4.Context.context.Filter(info.strPassword) + "'");
        //    if (c == null)
        //    {
        //        info.ErrorMessage = "The company login '" + info.strUser + "' could not be found.";
        //        info.UserProblem = true;
        //        success = false;
        //        return null;
        //    }
        //    n_user u = new n_user(context.xSys);
        //    u.name = c.companyname;
        //    u.unique_id = c.unique_id; 
        //    u.main_location = c.data
        //    success = true;
        //    return u;
        //}
        //KT - Check database for user like 'Recognin Tech%', if not present, create it with blank password, and su rights
        public static NewMethod.n_user MakeRecogninUser(ContextRz context)
        {
            n_user u = n_user.QtO(context, "select * from n_user where name like 'Recognin Tech%'");
            if (u == null)
            {
                u = n_user.New(context);
                u.name = "Recognin Tech";
                u.login_name = "recognin";
                u.login_password = "\r\n";
                u.template_editor = true;
                context.Insert(u);
            }
            u.super_user = true;
            return u;
        }


        public static void MakeSuperUser(ContextRz context)
        {
            context.xUser.super_user = true;
        }

        public bool AskForAdminRights(ContextRz context)
        {
            String userName = "";
            return AskForAdminRights(context, ref userName);
        }

        public bool AskForAdminRights(ContextRz context, ref String userName)
        {
            LoginInfo l = context.TheLeaderRz.LoginInfoAskOnThread(context, true);
            if (l == null)
                return false;

            bool success = false;
            NewMethod.n_user u = UserGetValidateByLogin(context, l, ref success);
            if (!success || u == null)
                return false;

            if (!u.SuperUser)
            {
                context.TheLeader.Tell("This account is not an admin account.");
                return false;
            }

            userName = u.name;
            return true;
        }

        public override void ActInstance(Context x, ActArgs args)
        {
            ArrayList objects = new ArrayList();
            foreach (IItem i in args.TheItems.AllGet(x))
            {
                objects.Add(i);
            }
            switch (args.ActionName.Trim().ToLower())
            {
                case "applyacompany":
                    usernote.CompanyApply((ContextRz)x, objects);
                    args.Handled = true;
                    break;
                default:
                    base.ActInstance(x, args);
                    break;
            }
        }


        public List<String> AgentOptionsList(ContextRz x, bool IncludeTeams, bool only_salespeople, bool force_all, ref String defaultValue)
        {
            List<String> ret = new List<string>();
            if (x.xUser.SuperUser || force_all)
            {
                ret.Add("<all>");
                ret.Add("<managers>");
                ret.Add("<salespeople>");
            }

            ArrayList a = GetAgentArray(x, force_all);
            foreach (NewMethod.n_user u in a)
            {
                if (!only_salespeople || x.Logic.SalesPeople.Contains(u.name))
                {
                    if(!u.is_inactive)
                        ret.Add("Agent: " + u.name);
                    //else if(includeInactive)
                    //    ret.Add("Agent: " + u.name);
                }
                    
            }

            if (!x.xUser.SuperUser && !force_all)
            {
                defaultValue = "Agent: " + x.xUser.Name;
            }

            if (IncludeTeams)
            {
                foreach (String t in TeamOptionsList(x))
                {
                    ret.Add(t);
                }
            }

            return ret;
        }

        public virtual List<String> AgentOptionsListSales(ContextRz x, bool IncludeTeams, ref String defaultValue)
        {
            List<String> ret = new List<string>();

            if (x.xUser.SuperUser || x.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
            {
                ret.Add("<all>");
                ArrayList a = GetAgentArray(x, false);
                foreach (NewMethod.n_user u in a)
                {
                    //if not show inactive, and use is inactive, skip user and continue loop.
                    //if (u.is_inactive && !includeInactive)
                    //    continue;
                    if (x.Logic.SalesPeople.Contains(u.name))
                    {
                        //if (!u.is_inactive)
                            ret.Add("Agent: " + u.name);
                        //else if (u.is_inactive)
                        //    if (includeInactive)
                        //        ret.Add("Agent: " + u.name);
                    }
                }
                if (IncludeTeams)
                {
                    foreach (String t in TeamOptionsList(x))
                    {
                        ret.Add(t);
                    }
                }
                defaultValue = "<all>";
            }
            else
            {
                ret.Add("Agent: " + x.xUser.name);
                defaultValue = "Agent: " + x.xUser.name;
            }

            return ret;
        }

        public List<String> TeamOptionsList(ContextRz context)
        {
            List<String> ret = new List<string>();
            DataTable d = context.Select("select 'Team: ' + name, unique_id from n_team where isnull(name, '') > '' and unique_id in (select main_n_team_uid from n_user where isnull(is_inactive, 0) = 0) order by name");
            ArrayList reflist = new ArrayList();
            foreach (DataRow r in d.Rows)
            {
                String s = nData.NullFilter_String(r[0]);
                if (!reflist.Contains(s))
                {
                    String suid = nData.NullFilter_String(r[1]);
                    //KT 6-12-2015Added check for "view all users on reports instead of just super users
                    if (context.xUser.SuperUser || context.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
                        ret.Add(s);
                    else
                    {
                        if (context.xUser.IsTeamCaptain(context, context.xSys.TranslateTeamIDToName(suid)))
                            ret.Add(s);
                    }
                    reflist.Add(s);
                }
            }
            return ret;
        }

        public virtual List<String> AgentIdsList(ContextRz context, String key)
        {
            List<String> ret = new List<string>();
            String strType;
            String strName;
            n_team xTeam;
            NewMethod.n_user yUser;
            switch (key.ToLower().Trim())
            {
                case "<all>":
                case "":
                    return ret;
                default:
                    strType = Tools.Strings.ParseDelimit(key, ":", 1).Trim();
                    strName = Tools.Strings.ParseDelimit(key, ":", 2).Trim();
                    switch (strType.Trim().ToLower())
                    {
                        case "agent":
                            yUser = NewMethod.n_user.GetByName(context, strName);
                            if (yUser == null)
                            {
                                context.TheLeader.Tell("The user '" + strName + "' could not be found in the system.");
                                return new List<String>();
                            }
                            ret.Add(yUser.unique_id);
                            break;
                        case "team":
                            xTeam = n_team.GetByName(context, strName);
                            if (xTeam == null)
                            {
                                context.TheLeader.Tell("The team '" + strName + "' could not be found.");
                                return new List<String>();
                            }
                            foreach (String t in xTeam.GetUserIDs(context))
                            {
                                ret.Add(t);
                            }
                            return ret;
                        default:
                            return new List<String>();
                    }
                    return ret;
            }
        }

        public ArrayList GetAgentArray(ContextRz context)
        {
            return GetAgentArray(context, false);
        }
        public ArrayList GetAgentArray(ContextRz context, bool force_all)
        {
            NewMethod.n_user u;
            ArrayList a = new ArrayList();
            ArrayList reflist = new ArrayList();
            ArrayList assistants = context.Logic.GetAssistantHandles(context);
            foreach (AssistantHandle h in assistants)
            {
                if (h.ManagerUser != null && h.AssistantUser != null)
                {
                    if (context.xUser.Name.ToLower() == h.ManagerUser.name.ToLower())
                    {
                        u = NewMethod.n_user.GetByName(context, h.AssistantUser.name);
                        if (u != null)
                        {
                            a.Add(u);
                            reflist.Add(u.name);
                        }
                    }

                    if (context.xUser.Name.ToLower() == h.AssistantUser.name.ToLower())
                    {
                        u = NewMethod.n_user.GetByName(context, h.ManagerUser.name);
                        if (u != null)
                        {
                            a.Add(u);
                            reflist.Add(u.name);
                        }
                    }
                }
            }


            //SQL To pull n_users from database.
            string sql = "select * from n_user where isnull(name, '') > '' ";
            //if (!includeInactive)
            //    sql += " and isnull(is_inactive, 0) = 0 ";
            sql += "order by name";

            //foreach (n_user ux in context.QtC("n_user", "select * from n_user where isnull(is_inactive, 0) = 0 and isnull(name, '') > '' order by name"))
            foreach (n_user ux in context.QtC("n_user", sql))
            {
                if (!reflist.Contains(ux.name))
                {
                    if (force_all || context.xUser.SuperUser || Tools.Strings.StrCmp(context.xUser.unique_id, ux.unique_id) || context.xUser.IsTeamCaptainOf(context, ux.unique_id) || context.CheckPermit(Permissions.ThePermits.ViewAllUsersOnReports))
                    {
                        a.Add(ux);
                        reflist.Add(ux.name);
                    }
                }
            }

            return a;
        }
    }
}