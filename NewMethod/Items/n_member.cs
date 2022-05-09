using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace NewMethod
{
    public partial class n_member : n_member_auto
    {

        
        public static ArrayList GetAllMembersByTeamID(Context x, n_team t)
        {
            ArrayList members = x.QtC("n_member", "select * from n_member where the_n_team_uid = '" + t.unique_id + "'");
            return members;

        }

        //Callign this from an unused method to determing if current user is the captain of company owner's team
        //Decided against using captain status, then I'd have 2 paths to granting permisison for team members to view each other's teams
        public static  n_member GetMemberByTeamID(Context x, n_team t, string userID)
        {
            return (n_member)x.QtO("n_member", "select * from n_member where the_n_team_uid = '" + t.unique_id + "' and the_n_user_uid = '"+ userID + "'");
        }

    }
}
