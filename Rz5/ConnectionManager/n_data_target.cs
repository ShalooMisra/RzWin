using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace NewMethodx
{
    public partial class n_data_target
    {
        public static string dDataPath = "";

        public String name = "";
        public String database_name = "";

        public String server_name = "";
        public int target_type = 0;
        public String user_name = "";
        public String user_password = "";
        public String AbsoluteConnectionString = "";

        public String GetConnectionString()
        {
            return GetConnectionString(false);
        }
        public String GetConnectionString(bool skip_provider)
        {
            if (nTools.StrExt(AbsoluteConnectionString))
                return AbsoluteConnectionString;

            switch (target_type)
            {
                case (Int32)Enums.ServerTypes.MySQL:
                    return "Driver={MySQL ODBC 3.51 Driver};Server=" + server_name + ";Port=3306;Option=131072;Stmt=;Database=" + database_name + ";Uid=" + user_name + ";Pwd=" + user_password;
                case (Int32)Enums.ServerTypes.SQLServer:
                    if (skip_provider)
                        return String.Concat("User Id=", user_name, ";Password=", user_password, ";Initial Catalog=", database_name, ";Data Source=", server_name);
                    else
                        return String.Concat("Provider=SQLOLEDB.1;User Id=", user_name, ";Password=", user_password, ";Initial Catalog=", database_name, ";Data Source=", server_name);
                default:
                    return "";
            }
        }

    }
}