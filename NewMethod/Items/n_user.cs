using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Tools;
using Core;
using Tools.Database;
using System.Linq;

namespace NewMethod
{
    public partial class n_user : n_user_auto
    {

        //Public Static Variables
        public static ArrayList HouseAccounts;
        public static ArrayList HiddenAccounts;

        //Public Static Functions
        public static bool CacheHouseAccounts(ContextNM context)
        {
            try
            {
                HouseAccounts = context.QtC("n_user", "select * from n_user where is_house_account = 1");
                return true;
            }
            catch { }
            return false;
        }
        public static bool CacheHiddenAccounts(ContextNM context)
        {
            try
            {
                HiddenAccounts = context.QtC("n_user", "select * from n_user where is_activity_hidden = 1");
                return true;
            }
            catch { }
            return false;
        }



        //Public Properties
        public n_team MainTeam = null;
        public nArray Teams;
        public nArray CaptainTeams;
        public nArray CaptainUsers;
        public nArray Permits;
        public nArray ActivePermits;
        public nArray Members;
        public n_team PermitTeam = null;
        //Clipboard
        public SortedList ClipsByClipID;
        public SortedList ClipsByObjectID;
        public n_clip RootClip;
        public n_clip ClipByDate;
        public n_clip ClipByUse;
        public n_clip ClipByClass;
        public DateTime LastClipAddition = System.DateTime.Now;
        public Enums.PermitMode CurrentPermitMode = NewMethod.Enums.PermitMode.Normal;




        //Public Functions
        public bool AccountingIs
        {
            get
            {
                return HasJobDescription("accounting") || is_accounting;
            }
        }
        //public bool WarehouseIs
        //{
        //    get
        //    {
        //        return HasJobDescription("warehouse") || HasJobDescription("picking") || is_warehouse;
        //    }
        //}

        //public bool SalesIs
        //{
        //    get
        //    {
        //        return HasJobDescription("sales") || is_sales || Tools.Strings.StrExt(main_n_team_uid);
        //    }
        //}

        public String CurrentPermitModeCaption
        {
            get
            {
                String strMode = "";
                switch (CurrentPermitMode)
                {
                    case NewMethod.Enums.PermitMode.Normal:
                        strMode = "";
                        break;
                    case NewMethod.Enums.PermitMode.AskAlways:
                        strMode = "  --  Permit Mode: Ask Always";
                        break;
                    case NewMethod.Enums.PermitMode.AskIfMissing:
                        strMode = "  --  Permit Mode: Ask If Missing";
                        break;
                    case NewMethod.Enums.PermitMode.AskIfMissingOrBlocked:
                        strMode = "  --  Permit Mode: Ask If Missing Or Blocked";
                        break;
                }
                return strMode;
            }
        }

        n_user m_ManagerUser = null;
        public n_user ManagerUser
        {
            set
            {
                m_ManagerUser = value;
            }

            get
            {
                if (m_ManagerUser == null)
                    return this;
                else
                    return m_ManagerUser;
            }
        }
        public String FirstName
        {
            get
            {
                return Tools.Strings.ParseDelimit(name, " ", 1);
            }
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            internal_phonenumber_stripped = Tools.Industry.StripPhoneNumber(internal_phonenumber);
        }

        public static n_user Choose(ContextNM xs, bool AllowNew)
        {
            return Choose(xs, null, AllowNew);
        }
        public static n_user Choose(ContextNM xs, ArrayList choices, bool allowNew)
        {
            return xs.LeaderNM.AskForUser(choices, allowNew);
        }
        //public static n_user AddNewUser(ContextNM context, String s)
        //{
        //    return AddNewUser(context, s);, ""
        //}
        public static n_user AddNewUser(ContextNM context, String s)  //, String strForcedID
        {
            if (!Tools.Strings.StrExt(s))
                return null;

            n_user u = n_user.GetByName(context, s);
            if (u != null)
            {
                context.TheLeader.Error("The user name '" + s + "' is already in use.");
                return null;
            }

            u = n_user.New(context); //new n_user(context.xSys);
            //if (Tools.Strings.StrExt(strForcedID))
            //    u.unique_id = strForcedID;
            u.name = s;
            u.login_name = Tools.Strings.ParseDelimit(s, " ", 1);
            //u.super_user = true;
            u.super_user = false;
            u.show_on_sales_screen = false;
            u.email_client = Enums.EmailClient.Gmail.ToString();
            //if (Tools.Strings.StrExt(strForcedID))
            //    u.ISave_PreserveID(context);
            //else
            context.Insert(u);
            context.xSys.CacheUsers(context);
            return u;
        }
        public static void FillIn(ContextNM xs, nObject xObject, String strIDProp, String strNameProp)
        {
            try
            {
                if (!Tools.Strings.StrExt((String)xObject.IGet(strIDProp)) && Tools.Strings.StrExt((String)xObject.IGet(strNameProp)))
                    xObject.ISet(strIDProp, n_user.TranslateNameToID(xs, (String)xObject.IGet(strNameProp)));
                else if (!Tools.Strings.StrExt((String)xObject.IGet(strNameProp)) && Tools.Strings.StrExt((String)xObject.IGet(strIDProp)))
                    xObject.ISet(strNameProp, n_user.TranslateIDToName(xs, (String)xObject.IGet(strIDProp)));
            }
            catch (Exception)
            {
            }
        }
        public static String TranslateIDToName(ContextNM xs, String strID)
        {
            String u = xs.xSys.TranslateUserIDToName(strID);
            if (!Tools.Strings.StrExt(u))
                return xs.TheData.SelectScalarString("select name from n_user where unique_id = '" + xs.TheData.Filter(strID) + "'");
            else
                return u;
        }
        public static String TranslateNameToID(ContextNM xs, String strName)
        {
            String u = xs.xSys.TranslateUserNameToID(strName);
            if (!Tools.Strings.StrExt(u))
                return xs.TheData.SelectScalarString("select unique_id from n_user where name = '" + xs.TheData.Filter(strName) + "'");
            else
                return u;
        }
        public static String TranslateLoginNameToID(ContextNM xs, String strName)
        {
            foreach (n_user u in xs.xSys.Users.All)
            {
                if (Tools.Strings.StrCmp(u.login_name, strName))
                    return u.login_name;
            }
            return xs.TheData.SelectScalarString("select unique_id from n_user where login_name = '" + xs.TheData.Filter(strName) + "'");
        }
        public static void GetRandomInfo(ref String strID, ref String strName, SysNewMethod xs)
        {
            strID = "";
            strName = "";
            try
            {
                Int32 i = RandomProvider.Next(0, xs.Users.AllByName.Count - 1);
                int j = 0;
                foreach (DictionaryEntry d in xs.Users.AllByName)
                {
                    if (j == i)
                    {
                        n_user u = (n_user)d.Value;
                        strID = u.unique_id;
                        strName = u.name;
                        break;
                    }

                    j++;
                }
            }
            catch (Exception)
            { }
        }
        //public static bool Import(SysNewMethod xs, nDataTable dtUser)
        //{
        //    if (!PrepareUserImport(dtUser))
        //        return false;

        //    return ImportUserList(xs, dtUser);
        //}
        //public static bool PrepareUserImport(nDataTable dtUser)
        //{
        //    dtUser.SetActualFieldNames();

        //    String s = "";
        //    if (!dtUser.FormalizeFieldTypes(false, ref s))
        //        return false;

        //    if (!dtUser.CheckCriteria("have no user name", "isnull(name, '') = ''", false))
        //        return false;

        //    if (!dtUser.RemoveDuplicates("name", false))
        //        return false;

        //    if (dtUser.Count == 0)
        //    {
        //        context.TheLeader.Tell("After filtering duplicates, no users are left to import.");
        //        return false;
        //    }

        //    return true;
        //}




        public virtual bool IsDeveloper()
        {
            return Tools.Strings.HasString(this.name, "recognin") || Tools.Strings.StrCmp(name, "rz system") || Tools.Strings.StrCmp(name, "rzsystem") || Tools.Strings.StrCmp(name, "kevin till");
        }
        public virtual void CacheClips(ContextNM x)
        {
            ClipsByClipID = new SortedList();
            ClipsByObjectID = new SortedList();
            RootClip = null;

            if (x.xSys == null)
                return;

            //this brings back the list of clips, grouped or not
            ArrayList a = x.QtC("n_clip", "select * from n_clip where the_n_user_uid = '" + unique_id + "' order by the_n_clip_uid, clip_type");

            //add them to the sorted list by the ID if the object

            foreach (n_clip c in a)
            {
                ClipsByClipID.Add(c.unique_id, c);

                try
                {
                    if (Tools.Strings.StrExt(c.link_id))
                        ClipsByObjectID.Add(c.link_id, c);
                }
                catch (Exception)
                { }

                c.Clear();

                if (Tools.Strings.StrCmp(c.clip_type, "root"))
                    RootClip = c;
            }

            if (RootClip == null)
            {
                RootClip = new n_clip();
                RootClip.clip_type = "root";
                RootClip.the_n_user_uid = unique_id;
                RootClip.name = name;
                x.Insert(RootClip);
                RootClip.Clear();
            }

            //link them together
            foreach (n_clip c in a)
            {
                n_clip l = (n_clip)ClipsByClipID[c.the_n_clip_uid];
                if (l != null)
                {
                    //this does both of the linking
                    l.Add(c);
                }
            }
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextNM context = (ContextNM)args.TheContext;

            switch (args.ActionName.ToLower().Trim())
            {
                case "activate":
                    SetActive(context, true);
                    break;
                case "de-activate":
                    SetActive(context, false);
                    break;
                case "viewmainteam":
                    ShowMainTeam(context);
                    break;
                case "setmainteam":
                    SetMainTeam(context);
                    return;
                case "clearmainteam":
                    ClearMainTeam(args);
                    return;
                case "setsetting-boolean":
                    AskSetBooleanSetting(context, true);
                    break;
                case "unsetsetting-boolean":
                    AskSetBooleanSetting(context, false);
                    break;
                case "copypermissions":
                    CopyPermissions(context);
                    break;
                case "pastepermissions":
                    PastePermissions(context);
                    break;
            }
        }

        void CopyPermissions(ContextNM context)
        {
            StringBuilder sb = new StringBuilder();

            if (Permits == null || Permits.All.Count == 0)
                GatherPermits(context);

            foreach (n_permit p in Permits.All)
            {
                if (p.is_positive)
                    sb.AppendLine(p.name);
                else
                    sb.AppendLine(p.name + "\tnegative");
            }

            if (PermitTeam != null)
            {
                if (PermitTeam.AllPermits == null || PermitTeam.AllPermits.Count == 0)
                    PermitTeam.CachePermits(context);

                foreach (n_permit p in PermitTeam.AllPermits)
                {
                    if (p.is_positive)
                        sb.AppendLine(p.name);
                    else
                        sb.AppendLine(p.name + "\tnegative");
                }
            }
            //context.Leader.SetClipboardText(sb.ToString());
            context.Leader.ShowText(sb.ToString());
        }

        void PastePermissions(ContextNM context)
        {
            String paste = context.Leader.AskForString("Permissions", "", true);
            if (!Tools.Strings.StrExt(paste))
                return;

            if (context.Leader.AskYesNo("Do you want to clear the existing permissions?"))
                RemoveAllPermits(context);

            foreach (String line in Tools.Strings.SplitLinesList(paste))
            {
                if (line == "")
                    continue;

                String permit = Tools.Strings.ParseDelimit(line, "\t", 1);
                bool negative = Tools.Strings.StrExt(Tools.Strings.ParseDelimit(line, "\t", 2));

                n_permit p = (n_permit)context.xUser.Permits.GetByName(permit);
                if (p == null)
                {
                    p = new n_permit();
                    p.Insert(context);
                }
                p.the_n_user_uid = unique_id;
                p.name = permit;
                p.is_positive = !negative;
                p.Update(context);
            }

            GatherPermits(context);
            context.Leader.Tell("Done.");
        }

        //xrz.SetSettingInt64("highest_version", CurrentVersion);
        public override String GetClipHTML(ContextNM x)
        {
            x.xSys.CheckHighestVersion(x);

            String s = GetClipHeader(x);

            s += GetClipLine_Email("email_address");
            s += "<font face=\"Arial\" size=\"2\">" + phone;
            if (Tools.Strings.StrExt(phone_ext))
                s += " x" + phone_ext;
            s += "</font>";
            s += "<p><font face=\"Arial\" size=\"2\">Current Version: " + Tools.Misc.GetVersionString(Tools.ToolsNM.AssemblyNM) + "&nbsp;&nbsp;<a href=\"/x/versionupdate.rzl\">Update</a>";

            if (IsDeveloper())
            {
                s += "&nbsp;&nbsp;<a href=\"/x/setversion.rzl\">Set Ideal</a>";
                s += "&nbsp;&nbsp;<a href=\"/x/setminversion.rzl\">Set Min</a>";
            }

            s += "</font><br>";
            s += "<font face=\"Arial\" size=\"2\">Ideal Version: " + x.xSys.GetHighestVersion() + "</font></p><br>";

            s += OptionHtmlCalc();

            return s;
        }

        protected virtual String OptionHtmlCalc()
        {
            String s = "<p><font face=\"Arial\" size=\"2\"><a href=\"/x/notes.rzl\">Notes</a></font>";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/commission_report.rzl\">Comission Report</a></font>";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/profit_report.rzl\">Profit Report</a></font>";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/quote_sale_ratio_report.rzl\">Quote-To-Sale Ratio Report</a></font>";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/cross_reference_report.rzl\">Cross Reference Report</a></font>";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/agent_preferences.rzl\">Agent Preferences</a></font>";
            s += "<hr />";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/save_tabs.rzl\">Save CurrentTabs</a></font>";
            s += "<br><font face=\"Arial\" size=\"2\"><a href=\"/x/restore_tabs.rzl\">Restore Saved Tabs</a></font>";
            s += "</p>";
            return s;
        }




        public override string ToString()
        {
            return name;
        }

        //Public Functions
        public bool GatherAll(ContextNM x)
        {
            x.TheLeader.Comment("About to GatherTeams()");
            GatherTeams(x);
            x.TheLeader.Comment("About to GatherPermits()");
            GatherPermits(x);
            x.TheLeader.Comment("About to GatherCaptianUsers()");
            GatherCaptianUsers(x);
            return true;
        }
        public ArrayList GetCaptainUsers(ContextNM x)
        {
            if (CaptainUsers != null)
                return CaptainUsers.All;

            GatherCaptianUsers(x);
            return CaptainUsers.All;
        }
        public void GatherCaptianUsers(ContextNM x)
        {
            CaptainUsers = new nArray();

            if (CaptainTeams == null)
                return;

            if (CaptainTeams.Count <= 0)
                return;

            ArrayList a = x.QtC("n_user", "select * from n_user where unique_id in (select the_n_user_uid from n_member where the_n_team_uid in (" + nTools.GetIDString(CaptainTeams.All) + "))");
            foreach (n_user u in a)
            {
                CaptainUsers.Add(u);
            }
        }

        public ArrayList MembersThisUserIsTeamCaptainOf(ContextNM x)
        {
            if (CaptainTeams.Count == 0)
                return new ArrayList();
            return x.QtC("n_user", "select * from n_user where unique_id <> '" + unique_id + "' and isnull(is_inactive, 0) = 0 and unique_id in (select the_n_user_uid from n_member where the_n_team_uid in (" + nTools.GetIDString(CaptainTeams.All) + "))");
        }

        public ArrayList ThisUsersTeamCaptains(ContextNM x)
        {
            if (Teams == null)
                GatherTeams(x);
            if (Teams.Count == 0)
                return new ArrayList();
            return x.QtC("n_user", "select * from n_user where unique_id <> '" + unique_id + "' and isnull(is_inactive, 0) = 0 and unique_id in (select the_n_user_uid from n_member where is_captain = 1 and the_n_team_uid in (" + nTools.GetIDString(Teams.All) + "))");
        }

        public void GatherTeams(ContextNM x)
        {
            Teams = new nArray();
            CaptainTeams = new nArray();

            Members = x.xSys.CollectMembershipsByUser(unique_id);

            n_team t;
            foreach (n_member m in Members.All)
            {
                t = n_team.GetById(x, m.the_n_team_uid);
                if (t != null)
                {
                    Teams.Add(t);

                    if (m.is_captain)
                        CaptainTeams.Add(t);
                }
            }

            if (Tools.Strings.StrExt(main_n_team_uid))
                MainTeam = (n_team)x.xSys.Teams.GetByID(main_n_team_uid);
            else
                MainTeam = null;
        }
        public bool PermitOptimistic()
        {
            return Tools.Strings.StrCmp(this.permit_type, "optimistic");
        }
        public void GatherPermits(ContextNM x)
        {
            Permits = new nArray();
            ActivePermits = new nArray();
            bool super = SuperUser;
            SortedList c = this.CoalesceTeams();
            String st = nTools.GetIDString(c);
            String strSQL = "select * from n_permit where ( the_n_user_uid = '" + this.unique_id + "'";
            if (Tools.Strings.StrExt(st))
                strSQL = strSQL + " or the_n_team_uid in (" + st + ")";
            strSQL = strSQL + " ) order by the_n_user_uid desc";
            ArrayList l = x.QtC("n_permit", strSQL);
            foreach (n_permit p in l)
            {
                if (p.is_positive || !super)
                    AbsorbPermit(p);
            }
        }
        public void AbsorbPermit(n_permit p)
        {
            try
            {
                Permits.Add(p);
                ActivePermits.Add(p);
            }
            catch (Exception)
            { }
        }
        public void AbsorbActivePermit(n_permit p)
        {
            try
            {
                ActivePermits.Remove(p);
            }
            catch (Exception)
            { }

            try
            {
                ActivePermits.Add(p);
            }
            catch (Exception)
            { }
        }
        public void DesorbPermit(n_permit p)
        {
            Permits.Remove(p);
            ActivePermits.Remove(p);

            //check to see if the permit being removed is still available from another team, etc.

            //foreach (n_permit t in Permits.All)
            //{
            //    if (Tools.Strings.StrCmp(t.name, p.name))
            //    {
            //        ActivePermits.Add(t);
            //        return;
            //    }
            //}
        }
        public SortedList CoalesceTeams()
        {
            SortedList c = new SortedList();

            try
            {

                n_team ht;
                foreach (n_team t in Teams.All)
                {
                    ht = t;
                    while (ht != null)
                    {
                        try
                        {
                            c.Add(ht.unique_id, ht);
                            ht = ht.ParentTeam;
                        }
                        catch (Exception)
                        {
                            ht = null;
                        }
                    }
                }
            }
            catch (Exception)
            { }

            return c;
        }

        public bool CheckPermit(ContextNM context, string strPermit)
        {
            return CheckPermit(context, strPermit, false);
        }

        public bool CheckPermit(ContextNM context, string strPermit, bool block_if_missing)
        {
            return CheckPermit(context, strPermit, block_if_missing, false);
        }

        public bool CheckPermit(ContextNM context, string strPermit, bool block_if_missing, bool ignore_super_user)
        {
            n_user u = this.ManagerUser;

            switch (CurrentPermitMode)
            {
                case NewMethod.Enums.PermitMode.Normal:
                    return u.HasPermit(strPermit, block_if_missing, ignore_super_user);
                case NewMethod.Enums.PermitMode.AskIfMissing:
                    if (!u.PermitExists(strPermit))
                    {
                        return u.AskPermit(context, strPermit);
                    }
                    else
                    {
                        if (!u.HasPermit(strPermit, block_if_missing, ignore_super_user))
                            return false;   //return AskPermit(strPermit);
                        else
                            return true;
                    }
                case NewMethod.Enums.PermitMode.AskIfMissingOrBlocked:
                    if (!u.PermitExists(strPermit))
                    {
                        return u.AskPermit(context, strPermit);
                    }
                    else
                    {
                        if (!u.HasPermit(strPermit, block_if_missing, ignore_super_user))
                            return u.AskPermit(context, strPermit);
                        else
                            return true;
                    }
                case NewMethod.Enums.PermitMode.AskAlways:
                    return u.AskPermit(context, strPermit);
            }

            return false;
        }

        public bool HasPermit(string strPermit)
        {
            return HasPermit(strPermit, false, false);
        }

        public bool HasPermit(string strPermit, bool block_if_missing)
        {
            return HasPermit(strPermit, block_if_missing, false);
        }

        public virtual bool HasPermit(string strPermit, bool block_if_missing, bool ignore_super_user)
        {
            if (!ignore_super_user)
            {
                if (SuperUser)
                    return true;
            }

            if (Permits == null)
                return false;

            n_permit p = (n_permit)ActivePermits.GetByName(strPermit.ToLower());

            if (p == null)
            {
                //ok; this is the change
                //now, if the permission doesn't exist at all, then the user can do it
                //the only time the user can't is when there's a specific block

                //return this.PermitOptimistic();

                if (block_if_missing)
                    return false;
                else
                    return true;
            }
            else
            {
                return p.is_positive;
            }
        }
        public bool PermitExists(String strPermit)
        {
            return ActivePermits.GetByName(strPermit) != null;
        }
        public bool HasBlock(string strPermit)
        {
            if (SuperUser)
                return false;

            if (Permits == null)
                return false;

            n_permit p = (n_permit)ActivePermits.GetByName(strPermit);

            if (p == null)
            {
                return false;
            }
            else
            {
                return !p.is_positive;
            }
        }
        public n_permit GetExplicitPermit(string strPermit)
        {
            if (Permits == null)
                return null;

            foreach (n_permit p in Permits.All)
            {
                if (Tools.Strings.StrCmp(p.the_n_user_uid, this.unique_id) && Tools.Strings.StrCmp(p.name, strPermit))
                {
                    return p;
                }
            }

            return null;
        }
        public bool HasExplicitPermit(string strPermit)
        {
            return (GetExplicitPermit(strPermit) != null);
        }
        public bool AskPermit(ContextNM context, string strPermit)
        {
            context.TheLeader.Reorg();
            return false;

            //frmPermit p = new frmPermit();
            //p.CompleteLoad(this, strPermit);
            ////p.Show();
            //p.ShowDialog(SysNewMethod.DefaultOwnerForm);
            //return HasPermit(strPermit);
        }


        //Team Membership Logic
        public bool IsTeamMember(ContextNM x, String strTeamName)
        {
            if (Teams == null)
                GatherTeams(x);

            if (Teams != null)
            {
                return (Teams.GetByName(strTeamName) != null);
            }
            else
                return false;
        }

        public bool IsTeamMember(ContextNM x, String strTeamName, n_user u)
        {
            //if (Teams == null)
            u.GatherTeams(x);

            if (Teams != null)
            {
                return (Teams.GetByName(strTeamName) != null);
            }
            else
                return false;

            //if (!Tools.Strings.StrExt(strTeamName))
            //    return false;
            //string teamName = strTeamName.ToLower();
            //n_team team = n_team.GetByName(context, strTeamName);
            //if (team == null)
            //    return false;
            //string teamID = team.unique_id;
            //if (team == null)
            //    return false;

            ////Get list of teams for user.
            //List<n_team> teamListForUser = new List<n_team>();
            //teamListForUser = n_team.GetAllTeamsForUser(context, u.unique_id);
            //if (teamListForUser.Count == 0)
            //    return false;

            ////If list contains the team, return true.
            //if (teamListForUser.Select(s => s.unique_id).Distinct().ToList().Contains(teamID))
            //    return true;

            //return false;

        }

        public bool IsTeamCaptain(ContextNM x, String strTeamName)
        {
            String strTeamID = x.xSys.TranslateTeamNameToID(strTeamName);
            if (Members == null)
                GatherTeams(x);
            foreach (n_member m in Members.All)
            {
                if (Tools.Strings.StrCmp(strTeamID, m.the_n_team_uid))
                {
                    if (m.is_captain)
                        return true;
                }
            }
            return false;
        }

        public List<n_user> GetManagementTeamCaptains(ContextNM x, n_user u)
        {
            List<n_user> ret = new List<n_user>();

            return ret;

        }
        public bool IsTeamCaptainOf(ContextNM context, String strUserID)
        {
            if (CaptainTeams == null)
                return false;
            foreach (n_team t in CaptainTeams.All)
            {
                if (t.HasMember(context, strUserID))
                    return true;
            }
            return false;
        }



        public bool IsOnTeamWith(ContextNM context, String strUserID)
        {
            if (!Tools.Strings.StrExt(strUserID))
                return false;
            if (Tools.Strings.StrCmp(strUserID, unique_id))
                return true;
            return context.TheData.TheConnection.StatementExists("select * from n_member where the_n_user_uid = '" + unique_id + "' and exists( select * from n_member m where m.the_n_team_uid = n_member.the_n_team_uid and m.the_n_user_uid = '" + strUserID + "')");
        }



        //Assistant To Logic
        public bool IsAssistantTo(n_user leader)
        {
            if (Tools.Strings.StrCmp(leader.unique_id, this.assistant_to_uid))
                return true;
            else
                return false;
        }
        public bool IsAssistantLeader(ContextNM x)
        {
            return GetAllAssistantLeaderIds(x).Contains(this.unique_id);
        }

        public bool IsAssistantLeaderTo(ContextNM x, n_user assistantUser)
        {
            //return GetAllAssistantLeaderIds(x).Contains(this.unique_id);
            return (assistantUser.assistant_to_uid == x.xUser.unique_id);

        }

        public bool IsAssistant(ContextNM x)
        {
            return GetAllAssistantIds(x).Contains(this.unique_id);
        }

        public List<string> GetAllAssistantLeaderIds(ContextNM x)
        {
            return x.SelectScalarList("select distinct assistant_to_uid from n_user where LEN(isnull(assistant_to_uid, 0)) > 0 AND assistant_to_uid IS NOT NULL");
        }

        public List<string> GetAllAssistantIds(ContextNM x)
        {
            return x.SelectScalarList("select distinct unique_id from n_user where LEN(isnull(assistant_to_uid, 0)) > 0 AND assistant_to_uid IS NOT NULL");
        }
        public ArrayList GetAssistantsForLeader(ContextNM x, string leaderID)
        {
            return x.QtC("n_user", "select * from n_user where assistant_to_uid ='" + leaderID + "'");
        }







        public void AddPermit(ContextNM x, String strPermit, bool positive)
        {
            n_permit p = GetExplicitPermit(strPermit);

            if (p == null)
            {
                p = new n_permit();
                p.name = strPermit;
                p.the_n_user_uid = this.unique_id;
                x.Insert(p);
                AbsorbPermit(p);
            }

            p.is_positive = positive;
            x.Update(p);
        }
        public void RemovePermit(ContextNM x, String strPermit)
        {
            n_permit p = GetExplicitPermit(strPermit);
            if (p != null)
            {
                x.Delete(p);
                DesorbPermit(p);
            }
        }
        public void RemoveAllPermits(ContextNM x)
        {
            x.Execute("delete from n_permit where the_n_user_uid = '" + this.unique_id + "'");
            GatherPermits(x);
        }
        public string GetCaptainUserIDs(ContextNM x)
        {
            if (ManagerUser.CaptainUsers == null)
                ManagerUser.GatherCaptianUsers(x);

            String s = nTools.GetIDString(ManagerUser.CaptainUsers.All);
            if (Tools.Strings.StrExt(s))
                s = s + ", ";

            s = s + "'" + this.unique_id + "'";
            return s;
        }
        public String GetSetting(ContextNM x, String strName)
        {
            if (x.xSys == null)
                return "";
            return x.TheData.SelectScalarString("select setting_value from n_set where name = '" + x.TheData.Filter(strName) + "' and setting_key = '" + unique_id + "'");
        }
        public bool GetSetting_Boolean(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            if (Tools.Strings.StrCmp(s, "true"))
                return true;
            else
                return false;
        }
        public DateTime GetSetting_Date(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            try
            {
                return DateTime.Parse(s);
            }
            catch (Exception)
            {
                return Tools.Dates.GetNullDate();
            }
        }
        public Double GetSetting_Double(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            try
            {
                return Double.Parse(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void SetSetting_Boolean(ContextNM x, String strName, bool value)
        {
            if (value)
                SetSetting(x, strName, "true");
            else
                SetSetting(x, strName, "false");
        }
        public void SetSetting_Date(ContextNM x, String strName, DateTime d)
        {
            if (Tools.Dates.DateExists(d))
                SetSetting(x, strName, d.ToString());
            else
                SetSetting(x, strName, "");
        }
        public void SetSetting(ContextNM x, String strName, String strValue)
        {
            n_set s = n_set.GetByName(x, strName, "setting_key = '" + unique_id + "'");
            if (s == null)
            {
                s = n_set.New(x);  // (n_set)x.Item("n_set");  // new n_set(xSys);
                s.name = strName;
                s.setting_key = unique_id;
                x.Insert(s);
            }
            s.setting_value = strValue;
            x.Update(s);
        }
        public virtual ArrayList GetNotifyEmailList(ContextNM x)
        {
            SortedList colAddresses = new SortedList();

            if (Tools.Strings.StrExt(email_address))
            {
                colAddresses.Add(email_address, email_address);
            }

            if (Teams == null)
                GatherTeams(x);

            foreach (n_team t in Teams.All)
            {
                t.GatherCaptainEmailAddresses(x, colAddresses);
            }

            ArrayList a = new ArrayList();
            foreach (DictionaryEntry d in colAddresses)
            {
                a.Add((String)d.Value);
            }
            return a;
        }
        public bool SuperUser
        {
            get
            {
                if (Tools.Strings.HasString(name, "recognin"))
                    return true;
                return super_user;
            }
        }
        public bool TemplateEditor
        {
            get
            {
                //wtf?  i've been telling people forever that template editing is not available to normal super users?

                //bool b = false;
                //b = super_user;
                //if (!b)
                //    b = template_editor;
                //if (!b)
                //    b = IsDeveloper();
                //return b;

                bool b = template_editor;
                if (!b)
                    b = IsDeveloper();
                return b;
            }
        }



        public void AddDefaultClips(ContextNM x)
        {
            ClipByDate = (n_clip)x.Item("n_clip");
            ClipByDate.ClipType = NewMethod.Enums.ClipType.Folder;
            ClipByDate.name = "By Date";

            ClipByUse = (n_clip)x.Item("n_clip");
            ClipByUse.ClipType = NewMethod.Enums.ClipType.Folder;
            ClipByUse.name = "Recent Items";

            ClipByClass = (n_clip)x.Item("n_clip");
            ClipByClass.ClipType = NewMethod.Enums.ClipType.Folder;
            ClipByClass.name = "By Type";

            RootClip.Add(ClipByDate);
            RootClip.Add(ClipByUse);
            RootClip.Add(ClipByClass);
        }
        public void AddClipObject(ContextNM x, nObject o)
        {
            AddClipObject(x, o, false);
        }
        public void AddClipObject(ContextNM x, nObject o, bool ignore_block)
        {
            if (!ignore_block && !n_clip.AutoClip)
                return;

            //see if it has been added
            if (HasClipObject(o.unique_id))
                return;

            n_clip c = (n_clip)x.Item("n_clip");
            c.the_n_user_uid = unique_id;
            c.RefreshSummary(x, o);
            c.ClipType = NewMethod.Enums.ClipType.Instance;
            c.link_class = o.ClassId;
            c.link_id = o.unique_id;
            c.the_n_clip_uid = RootClip.unique_id;
            x.Insert(c);

            c.Clear();

            if (RootClip.MyNode == null)
                return;

            //AddAutoClip(c);
            RootClip.Add(c);
            RootClip.MyNode.Expand();
            ClipsByClipID.Add(c.unique_id, c);
            ClipsByObjectID.Add(c.link_id, c);
            LastClipAddition = System.DateTime.Now;
        }
        public bool HasClipObject(String strID)
        {
            n_clip c = (n_clip)ClipsByObjectID[strID];
            return (c != null);
        }
        public void AddAutoClip(ContextNM x, n_clip c)
        {
            ClipByDate.AddInCategory(x, c, nTools.DateFormat(c.date_created));
            //ClipByUse.AddInCategory(c, c.activity_index);
            ClipByClass.AddInCategory(x, c, c.link_class);
        }
        public n_team GetMainTeam(ContextNM x)
        {
            if (MainTeam == null)
                MainTeam = n_team.GetById(x, main_n_team_uid);
            return MainTeam;
        }
        public void AskSetBooleanSetting(ContextNM context, bool val)
        {
            String strName = context.TheLeader.AskForString("Setting name to set to " + val.ToString() + ":");
            if (!Tools.Strings.StrExt(strName))
                return;

            SetSetting_Boolean(context, strName, val);
        }
        public void ShowMainTeam(ContextNM x)
        {
            n_team t = n_team.GetById(x, this.main_n_team_uid);
            if (t == null)
            {
                x.TheLeader.Tell(this.ToString() + " is not assigned to a main team.");
                return;
            }
            x.TheLeader.Tell(this.ToString() + "'s main team is " + t.ToString());
        }

        public void SetMainTeam(ContextNM x)
        {
            n_team t = InferMainTeam(x);
            if (t != null)
            {
                if (x.TheLeader.AskYesNo("Do you want to assign " + this.ToString() + " to " + t.ToString() + "?"))
                {
                    main_n_team_uid = t.unique_id;
                    if (t.name.ToLower().Contains("sales"))//Sales Users automatically show on sales screen
                        show_on_sales_screen = true;
                    x.Update(this);
                    return;
                }
            }

            List<Object> objects = new List<object>();
            foreach (Item i in x.QtC("n_team", "select * from n_team order by name"))
            {
                objects.Add(i);
            }

            t = (n_team)x.TheLeader.ChooseFromObjects(objects, null);
            if (t != null)
            {
                main_n_team_uid = t.unique_id;
                x.Update(this);
            }
        }

        public void ClearMainTeam(ActArgs args)
        {
            main_n_team_uid = "";
            args.TheContext.Update(this);
        }

        public n_team InferMainTeam(ContextNM x)
        {
            GatherTeams(x);
            foreach (n_team t in Teams.All)
            {
                if (t.is_main)
                    return t;
            }
            return null;
        }
        public void SetActive(Context x, bool active)
        {
            is_inactive = !active;
            x.Update(this);
        }
        public bool HasJobDescription(String s)
        {
            return Tools.Strings.HasString(job_desc, s);
        }

        //Private Static Functions
        private static void ImportUserList(Context x, nDataTable dtUsers)
        {
            x.TheLeader.Reorg();
            //ArrayList a = new ArrayList();
            //a.Add("name");

            //SortedList props = xs.CoalescePropsByClass("n_user");
            //long importcount = 0;

            //if (dtUsers.ImportObjects("n_user", "unique_id", props, a, ref importcount))
            //{
            //    context.TheLeader.Tell("Done: " + Tools.Number.LongFormat(importcount) + " user records were imported.");
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public static String TranslateUserIDToMainTeam(ContextNM context, String strUserID)
        {
            return context.TheData.SelectScalarString("select isnull(max(main_n_team_uid), '') from n_user where unique_id = '" + strUserID + "'");
        }

        public void SetActivity(ContextNM context)
        {
            last_activity = DateTime.Now;
            context.TheData.TheConnection.ExecuteAsync("update n_user set last_activity = getdate() where unique_id = '" + unique_id + "'", "", false);
            //ISave();
        }

        public ArrayList GetPermitArray(ContextNM context, bool positive)
        {
            ArrayList a = new ArrayList();

            if (Permits == null)
                GatherPermits(context);

            foreach (n_permit x in Permits.All)
            {
                if (x.is_positive == positive)
                    a.Add(x.name);
            }

            a.Sort();
            return a;
        }

        public ArrayList OwnerNames(ContextNM x)
        {
            ArrayList owners = new ArrayList();
            if (Tools.Strings.StrExt(name))
                owners.Add(name);
            else
                owners.Add("not_an_id");

            GatherTeams(x);
            foreach (n_team t in this.Teams.All)
            {
                if (Tools.Strings.StrExt(t.name))
                    owners.Add(t.name);
            }

            foreach (n_user u in CaptainUsers.All)
            {
                owners.Add(u.name);
            }

            return owners;
        }

        //public n_path PathAdd(ContextNM q, String name)
        //{
        //    n_path ret = new n_path(q.xSys);
        //    ret.TheUser = this;
        //    ret.name = name;
        //    ret.ISave();
        //    return ret;
        //}

        public virtual bool TextSend(String text)
        {
            if (cell_number.Length != 10)
                return false;

            String address = "";
            switch (cell_carrier.ToLower())
            {
                case "verizon":
                    address = cell_number + "@vtext.com";
                    break;
                case "at&t":
                    address = cell_number + "@txt.att.net";
                    break;
                case "sprint":
                    address = cell_number + "@messaging.sprintpcs.com";
                    break;
                case "t-mobile":
                    address = cell_number + "@tmomail.net";
                    break;
                case "nextel":
                    address = cell_number + "@messaging.nextel.com";
                    break;
                case "cingular":
                    address = cell_number + "@cingularme.com";
                    break;
                case "virgin mobile":
                    address = cell_number + "@vmobl.com";
                    break;
                case "alltel":
                    address = cell_number + "@message.alltel.com";
                    break;
                case "cellularone":
                    address = cell_number + "@mobile.celloneusa.com";
                    break;
                case "omnipoint":
                    address = cell_number + "@omnipointpcs.com";
                    break;
                case "qwest":
                    address = cell_number + "@qwestmp.com";
                    break;
                default:
                    return false;
            }

            nEmailMessage m = new nEmailMessage();
            m.ToAddress = address;
            m.Subject = text;
            m.TextBody = text;
            m.SetNotifyServer("RzNote", "notify@recognin.com", "N0tify");
            return m.Send();
        }

        public String Initials
        {
            get
            {
                if (Tools.Strings.StrExt(user_initials))
                    return user_initials;

                if (name.Contains(" "))
                    return Tools.Strings.Left(name, 1).ToUpper() + Tools.Strings.Left(Tools.Strings.ParseDelimit(name, " ", 2), 1).ToUpper();

                return name.ToUpper();
            }
        }

        public bool ExportAllow(ContextNM context)
        {
            if (allow_list_export)
                return true;

            return CheckPermit(context, "General:View:AllowedToExport", true, true);
        }

        public static String InitialsCalc(String name)
        {
            try
            {
                String[] names = Tools.Strings.Split(name, " ");
                if (names.Length == 0)
                    return name;
                else if (names.Length == 1)
                    return names[0];
                else
                    return (names[0].Substring(0, 1) + names[1].Substring(0, 1)).ToUpper();

            }
            catch { return name; }
        }


        public void SetLeaderboardImage(ContextNM x, string url)
        {
            string defaultUrl = @"https://portal.sensiblemicro.com/Images/logo_flat_1.png";
            if (string.IsNullOrEmpty(url))
                return;

            bool allowed = false;
            List<string> allowedExtensions = new List<string>() { "gif", "jpeg", "jpg", "bmp", "tif", "tiff", "png" };
            foreach (string s in allowedExtensions)
            {
                if (url.ToLower().Contains("." + s))
                    allowed = true;
            }


            if (allowed)
            {
                this.leaderboard_image_url = url;
            }
            else
            {
                x.Leader.Error(url + " is not a valid image url.  Please be sure you url ends in an image extension (i.e. jpg, gif, png, etc).  Setting to default Sensible Logo.");
                this.leaderboard_image_url = defaultUrl;
            }
            this.Update(x);

        }




    }

    public class AssistantHandle
    {
        public n_user ManagerUser;
        public String ManagerMachineID = "";
        public n_user AssistantUser;
        public bool SuppressOverdueEmails = false;
        public bool ChatSuppress = false;

        public AssistantHandle(ContextNM context, String strManagerName, String strAssistantName)
        {
            ManagerUser = (n_user)context.Sys.Users.GetByName(strManagerName);
            AssistantUser = (n_user)context.Sys.Users.GetByName(strAssistantName);
        }

        public bool IsValid
        {
            get
            {
                if (ManagerUser == null)
                    return false;

                if (AssistantUser == null)
                    return false;

                return true;
            }
        }
    }





}
