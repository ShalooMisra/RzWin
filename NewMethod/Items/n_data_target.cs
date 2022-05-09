using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Tools.Database;
using Core;

namespace NewMethod
{
    public partial class n_data_target : n_data_target_auto
    {
        //public static int dTargetType = 0;
        //public static string dServerName = "";
        //public static string dDatabaseName = "";
        //public static string dUserName = "";
        //public static string dPassword = "";
        //public static string dCodePath = "";
        //public static string dDataPath = "";
        //public static string dAbsoluteConnectionString = "";
        //public String AbsoluteConnectionString = "";

        public n_data_target()
        {
        }

        //public n_data_target(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword, String strAbsoluteConnectionString)
        //{
        //    SetConnectionInfo(xType, strServer, strDatabase, strUser, strPassword, strAbsoluteConnectionString);
        //}
        public n_data_target(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword)
        {
            SetConnectionInfo(xType, strServer, strDatabase, strUser, strPassword);  //, ""
        }
        //public n_data_target(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword, String strAbsoluteConnectionString)
        //{
        //    SetConnectionInfo(xType, strServer, strDatabase, strUser, strPassword, strAbsoluteConnectionString);
        //}
        //public n_data_target(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword)
        //{
        //    SetConnectionInfo(xType, strServer, strDatabase, strUser, strPassword, "");
        //}
        public n_data_target(n_data_target t, bool by_data_target)
        {
            SetConnectionInfo(t.target_type, t.server_name, t.database_name, t.user_name, t.user_password); //, ""
        }

        public bool IsValid
        {
            get
            {
                return Tools.Strings.StrExt(server_name) && Tools.Strings.StrExt(database_name) && Tools.Strings.StrExt(user_name) && Tools.Strings.StrExt(user_password);
            }
        }

        //public static bool IsStructureServer()
        //{
        //    switch (dServerName.ToLower())
        //    {
        //        case "newmethod1":
        //            //case "65.13.153.140":
        //            return true;
        //        default:
        //            return false;
        //    }
        //}

        public override string ToString()
        {
            return "Server: " + server_name + "\r\n" + "Database: " + database_name;
        }
        //Public Functions
        //public void AbsorbDefaultInfo()
        //{
        //    SetConnectionInfo(dTargetType, dServerName, dDatabaseName, dUserName, dPassword, "");
        //}
        public void SetConnectionInfo(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword) //, String strAbsoluteConnectionString
        {
            target_type = xType;
            server_name = strServer;
            database_name = strDatabase;
            user_name = strUser;
            user_password = strPassword;
            //AbsoluteConnectionString = strAbsoluteConnectionString;
        }
        //public String GetConnectionString()
        //{
        //    return GetConnectionString(false);
        //}
        //public String GetConnectionString(bool skip_provider)
        //{
        //    //if (Tools.Strings.StrExt(AbsoluteConnectionString))
        //    //    return AbsoluteConnectionString;

        //    switch (target_type)
        //    {
        //        case (Int32)Enums.ServerTypes.MySQL:
        //            //switched to 5.1 2010_04_16
        //            //switched back 2010_04_25
        //            return "Driver={MySQL ODBC 3.51 Driver};Server=" + server_name + ";Port=3306;Option=131072;Stmt=;Database=" + database_name + ";Uid=" + user_name + ";Pwd=" + user_password + ";Connection Timeout = 10";
        //            //return "Driver={MySQL ODBC 5.1 Driver};Server=" + server_name + ";Port=3306;Option=131072;Stmt=;Database=" + database_name + ";Uid=" + user_name + ";Pwd=" + user_password + ";Connection Timeout = 10";
        //        case (Int32)Enums.ServerTypes.SQLServer:
        //            if( skip_provider )
        //                return String.Concat("User Id=", user_name, ";Password=", user_password, ";Initial Catalog=", database_name, ";Data Source=", server_name);
        //            else
        //                return String.Concat("Provider=SQLOLEDB.1;User Id=", user_name, ";Password=", user_password, ";Initial Catalog=", database_name, ";Data Source=", server_name);
        //        default:
        //            return "";
        //    }
        //}

        public void ClearTargetInfo()
        {
            target_type = 0;
            server_name = "";
            database_name = "";
            user_name = "";
            user_password = "";
        }

        public void AbsorbTargetInfo(n_data_target t)
        {
            target_type = t.target_type;
            server_name = t.server_name;
            database_name = t.database_name;
            user_name = t.user_name;
            user_password = t.user_password;
        }

        public Enums.ServerTypes TargetType
        {
            get
            {
                return (Enums.ServerTypes)target_type;
            }

            set
            {
                target_type = (int)value;
            }
        }

        //static nArray m_LocalDataConnections;
        //public static nArray GetLocalDataConnections(n_sys xs)
        //{
        //    if (m_LocalDataConnections == null)
        //    {
        //        m_LocalDataConnections = new nArray();
        //        ArrayList a = xs.GetAllByClass("n_data_target");
        //        foreach (n_data_target d in a)
        //        {
        //            if (Tools.Strings.StrExt(d.unique_id))
        //                m_LocalDataConnections.Add(d);
        //        }
        //    }

        //    return m_LocalDataConnections;
        //}

        public Tools.Database.DataConnection GetAsDataConnection()
        {
            if (target_type == 1)
                return new DataConnectionSqlMy(server_name, database_name, user_name, user_password);
            else
                return new DataConnectionSqlServer(server_name, database_name, user_name, user_password);
        }
    }
}
