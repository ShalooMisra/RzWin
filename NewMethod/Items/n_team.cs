using System;
using System.Collections;
using System.Text;

using Core;
using System.Collections.Generic;

namespace NewMethod
{
    public partial class n_team : n_team_auto
    {
        public nArray TeamTree;
        public n_team ParentTeam;
        public SortedList AllPermits;
        public ArrayList AllMembers;

        //public bool PermissionAllowedToExport
        //{
        //    get
        //    {
        //        return HasPermit(Permissions.AllowedToExport);
        //    }
        //    set
        //    {
        //        AddPermit(Permissions.AllowedToExport, value);
        //        UpdateUserExport(value);
        //    }
        //}
        //public bool PermissionViewAllOrders
        //{
        //    get
        //    {
        //        return HasPermit(Permissions.ViewAllOrders);
        //    }
        //    set
        //    {
        //        AddPermit(Permissions.ViewAllOrders, value);
        //    }
        //}
        //public bool PermissionViewAllCompanies
        //{
        //    get
        //    {
        //        return HasPermit(Permissions.ViewAllCompanies);
        //    }
        //    set
        //    {
        //        AddPermit(Permissions.ViewAllCompanies, value);
        //    }
        //}
        //public bool PermissionViewOrderLinks
        //{
        //    get
        //    {
        //        return HasPermit(Permissions.AllowedToViewOrderLinks);
        //    }
        //    set
        //    {
        //        AddPermit(Permissions.AllowedToViewOrderLinks, value);
        //    }
        //}
        //public bool PermissionDeleteAllItems
        //{
        //    get
        //    {
        //        return HasPermit(Permissions.AllowedToDeleteAllItems);
        //    }
        //    set
        //    {
        //        AddPermit(Permissions.AllowedToDeleteAllItems, value);
        //    }
        //}

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        //Public Functions
        public void FillTeamTree(ContextNM x, n_team parent, nArray allteams)
        {
            CacheMembers(x);

            ParentTeam = parent;
            TeamTree = new nArray();
            ArrayList l = x.QtC("n_team", "select * from n_team where isnull(the_n_team_uid, '') = '" + this.unique_id + "' order by name");

            foreach (n_team t in l)
            {
                AbsorbTeam(t);

                if (allteams != null)
                    allteams.Add(t);

                t.FillTeamTree(x, this, allteams);
            }
        }

        public void CacheMembers(ContextNM context)
        {
            AllMembers = context.QtC("n_member", "select * from n_member where the_n_team_uid = '" + this.unique_id + "'");
        }

        public bool HasMember(ContextNM context, String strUserID)
        {
            if (AllMembers == null)
                CacheMembers(context);

            foreach (n_member m in AllMembers)
            {
                if (Tools.Strings.StrCmp(m.the_n_user_uid, strUserID))
                    return true;
            }
            return false;
        }
        public void CollectMembershipsByUser(String strUserID, nArray a)
        {
            if (AllMembers != null)
            {
                foreach (n_member m in AllMembers)
                {
                    if (Tools.Strings.StrCmp(strUserID, m.the_n_user_uid))
                        a.Add(m);
                }
            }

            foreach (n_team t in TeamTree.All)
            {
                t.CollectMembershipsByUser(strUserID, a);
            }
        }
        public void AbsorbTeam(n_team t)
        {
            TeamTree.Add(t);
        }
        public void RemoveTeam(n_team t)
        {
            TeamTree.Remove(t);
        }
        public void CachePermits(ContextNM x)
        {
            AllPermits = new SortedList();
            String strSQL = "select * from n_permit where the_n_team_uid = '" + this.unique_id + "'";
            ArrayList l = x.QtC("n_permit", strSQL);

            foreach (n_permit p in l)
            {
                try
                {
                    AllPermits.Add(p.name.ToLower(), p);
                }
                catch (Exception)
                {
                }
            }
        }
        public bool HasPermit(string strPermit)
        {
            if (AllPermits == null)
                return false;

            n_permit p = (n_permit)AllPermits[strPermit.ToLower()];

            if (p == null)
            {
                //return this.PermitOptimistic();
                return false;
            }
            else
            {
                return p.is_positive;
            }
        }
        public bool HasBlock(string strPermit)
        {

            if (AllPermits == null)
                return false;

            n_permit p = (n_permit)AllPermits[strPermit.ToLower()];

            if (p == null)
            {
                return false;
            }
            else
            {
                return !p.is_positive;
            }
        }
        public n_permit AddPermit(Context x, String strPermit)
        {
            return AddPermit(x, strPermit, true);
        }
        public n_permit AddPermit(Context x, String strPermit, bool positive)
        {
            n_permit p = (n_permit)AllPermits[strPermit.ToLower()];

            if (p != null)
            {
                if (p.is_positive != positive)
                {
                    p.is_positive = positive;
                    x.Update(p);  // p.ISave();
                }
            }

            if (p == null)
            {
                p = new n_permit();
                p.name = strPermit;
                p.the_n_team_uid = this.unique_id;
                AllPermits.Add(p.name.ToLower(), p);
                p.is_positive = positive;
                x.Insert(p);
            }

            return p;
        }
        public n_permit RemovePermit(Context x, String strPermit)
        {
            return AddPermit(x, strPermit, false);
        }
        public void GatherCaptainEmailAddresses(ContextNM x, SortedList colCoalesce)
        {
            ArrayList colCaptains = GetCaptains(x);

            foreach (n_user u in colCaptains)
            {
                if (!u.is_inactive && Tools.Strings.StrExt(u.email_address))
                {
                    if (!nTools.IsInCollection(u.email_address, colCoalesce))
                    {
                        colCoalesce.Add(u.email_address, u.email_address);
                    }
                }
            }
        }
        public ArrayList GetCaptains(ContextNM context)
        {
            return context.QtC("n_user", "select * from n_user where unique_id in (select distinct(the_n_user_uid) from n_member where isnull(n_member.is_captain, 0) = 1 and n_member.the_n_team_uid = '" + unique_id + "') order by name");
        }
        public ArrayList GetNonCaptainMembers(Context context, bool ExcludeInactive)
        {
            if (ExcludeInactive)
                return context.QtC("n_user", "select * from n_user where isnull(is_inactive, 0) = 0 and unique_id in (select distinct(the_n_user_uid) from n_member where isnull(n_member.is_captain, 0) = 0 and n_member.the_n_team_uid = '" + unique_id + "') order by name");
            else
                return context.QtC("n_user", "select * from n_user where unique_id in (select distinct(the_n_user_uid) from n_member where isnull(n_member.is_captain, 0) = 0 and n_member.the_n_team_uid = '" + unique_id + "') order by name");
        }
        public ArrayList GetUserIDs(ContextNM context)
        {
            return context.TheData.ScalarArray("select distinct(the_n_user_uid) from n_member where the_n_team_uid = '" + this.unique_id + "'");
        }
        public ArrayList GetUserNames(ContextNM context)
        {
            return context.TheData.ScalarArray("select distinct(n_user.name) from n_user inner join n_member on n_member.the_n_user_uid = n_user.unique_id where n_member.the_n_team_uid = '" + this.unique_id + "' order by n_user.name");
        }
        public void RemoveAllPermits(ContextNM x)
        {
            x.Execute("delete from n_permit where the_n_team_uid = '" + this.unique_id + "'");
            CachePermits(x);
        }
        public void RemoveNegativePermits(ContextNM x)
        {
            x.Execute("delete from n_permit where the_n_team_uid = '" + this.unique_id + "' and isnull(is_positive, 0) = 0");
            CachePermits(x);
        }
        public ArrayList GetPermitArray(ContextNM context, bool positive)
        {
            ArrayList a = new ArrayList();

            if (AllPermits == null)
                CachePermits(context);

            foreach (DictionaryEntry p in AllPermits)
            {
                n_permit x = (n_permit)p.Value;
                if (x.is_positive == positive)
                    a.Add(x.name);
            }

            a.Sort();
            return a;
        }
        public ArrayList GetPermitArrayWithPositiveNegative(ContextNM context)
        {
            ArrayList a = new ArrayList();

            if (AllPermits == null)
                CachePermits(context);

            foreach (DictionaryEntry p in AllPermits)
            {
                n_permit x = (n_permit)p.Value;
                if (x.is_positive)
                    a.Add(x.name);
                else
                    a.Add(x.name + " negative");
            }

            a.Sort();
            return a;
        }
        public void ClearPermit(Context x, String strPermit)
        {
            n_permit p = (n_permit)AllPermits[strPermit.ToLower()];

            if (p != null)
            {
                x.Delete(p);  // p.IDelete();
                AllPermits.Remove(p.name.ToLower());
            }
        }

        public override string ToString()
        {
            return name;
        }

        public String MemberOverview(ContextNM x)
        {
            //FillTeamTree  done already?
            StringBuilder ret = new StringBuilder();

            int i = 0;
            foreach (n_member m in AllMembers)
            {
                if (i > 0)
                    ret.Append(", ");
                ret.Append(x.xSys.TranslateUserIDToName(m.the_n_user_uid));
                i++;
            }

            return ret.ToString();
        }

        //Currently not using this, was intended to allow Captains to view all members on team, then I decided against that
        //and am going with the permission (can view all users on team)
        public static List<n_team> GetAllTeamsForUser(ContextNM x, string specificID = null)
        {
            string userIDToCheck = x.xUser.unique_id;
            if (specificID != null)
                userIDToCheck = specificID;

            List<n_team> ret = new List<n_team>();
            List<String> teamIDs = new List<string>();
            teamIDs = x.SelectScalarList("select * from n_team where unique_id IN (select m.the_n_team_uid from n_user u inner join n_member m on u.unique_id = m.the_n_user_uid where the_n_user_uid = '" + userIDToCheck + "')");
            foreach (string s in teamIDs)
            {
                ret.Add(n_team.GetById(x, s));
            }
            return ret;
        }   

        protected void UpdateUserExport(ContextNM x, bool allow)
        {
            ArrayList a = GetUserIDs(x);
            string inn = Tools.Data.GetIn(a);
            if (!Tools.Strings.StrExt(inn))
                return;
            x.Execute("update n_user set allow_list_export = " + (allow ? "1" : "0") + " where unique_id in (" + inn + ")");
        }




    }
}
