using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Tools.Database;
using Core;

namespace CoreDevelop
{
    public class Import
    {
        public static bool ImportFromNM(ContextDevelop x, BoxSys sys, String sysname)
        {
            if (!Tools.Strings.StrExt(sysname))
            {
                x.TheLeader.Error("Please enter a system name");
                return false;
            }

            DataConnectionSqlServer d = new DataConnectionSqlServer();
            d.TheKey = new Tools.Database.Key();
            d.TheKey.ServerName = @"LAPTOP07\SQLEXPRESS";
            d.TheKey.DatabaseName = "NewMethod";
            d.TheKey.UserName = "sa";
            d.TheKey.UserPassword = "rec0gnin";
            d.ConnectionStringSet();

            String err = "";
            if( !d.ConnectPossible(ref err) )
            {
                x.TheLeader.Error("Can't connect: " + err);
                return false;
            }

            DataTable t = d.Select("select * from n_class where the_n_sys_uid = '000NMUID000'");

            foreach (DataRow r in t.Rows)
            {
                ImportFromNMClass(x, d, sys, r);
            }

            return true;
        }

        public static bool ImportFromNMClass(ContextDevelop x, DataConnectionSqlServer data, BoxSys sys, DataRow r)
        {
            //BoxClass c = sys.ClassAdd(x, Tools.Data.NullFilterString(r["class_name"]));

            //DataTable t = data.Select("select * from n_prop where the_n_class_uid = '" + Tools.Data.NullFilterString(r["unique_id"]) + "' order by name");

            //foreach (DataRow rp in t.Rows)
            //{
            //    String pname = Tools.Data.NullFilterString(rp["name"]);
            //    String tag = Tools.Data.NullFilterString(rp["property_tag"]);
            //    int ptype = Tools.Data.NullFilterIntegerFromIntOrLong(rp["property_type"]);
            //    int length = Tools.Data.NullFilterIntegerFromIntOrLong(rp["property_length"]);

            //    BoxVar v = c.MemberAddVar(
            //}

            //c.Write();
            return true;
        }
    }
}
