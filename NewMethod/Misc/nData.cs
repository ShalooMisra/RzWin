using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Tools.Database;
using NewMethod.Enums;
using Core;

namespace NewMethod
{
    public static partial class nData //: DataConnectionSqlServer 
    {
        //public n_sys xSys;
        //public string server_name
        //{
        //    get
        //    {
        //        return TheKey.ServerName;
        //    }
        //    set
        //    {
        //        TheKey.ServerName = value;
        //        ConnectionStringSet();
        //    }
        //}
        //public string user_name
        //{
        //    get
        //    {
        //        return TheKey.UserName;
        //    }
        //    set
        //    {
        //        TheKey.UserName = value;
        //        ConnectionStringSet();
        //    }
        //}
        //public string user_password
        //{
        //    get
        //    {
        //        return TheKey.UserPassword;
        //    }
        //    set
        //    {
        //        TheKey.UserPassword = value;
        //        ConnectionStringSet();
        //    }
        //}
        //public string database_name
        //{
        //    get
        //    {
        //        return TheKey.DatabaseName;
        //    }
        //    set
        //    {
        //        TheKey.DatabaseName = value;
        //        ConnectionStringSet();
        //    }
        //}
        //public int target_type
        //{
        //    get
        //    {
        //        return 2;
        //    }
        //    set
        //    {
        //        ;
        //    }
        //}

        ////Public Static Variables
        //public static int TimeOut = 20800;    //6 hours?
        //public static bool SimulateDelay = false;
        //public static bool ShowAsyncWarnings = true;
        ////Public Variables

        //public ArrayList StatementCache;
        //public bool CacheStatements = false;
        //public int InstanceTimeOut = TimeOut;
        ////Private Variables
        //private String ConnectionString;

        ////Constructors
        //public nData(n_data_target t)
        //{
        //    Key k = new Key();
        //    k.ServerName = t.server_name;
        //    k.DatabaseName = t.database_name;
        //    k.UserName = t.user_name;
        //    k.UserPassword = t.user_password;
        //    Init(k);
        //}
        //public nData(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword)
        //{
        //    Key k = new Key();
        //    k.ServerName = strServer;
        //    k.DatabaseName = strDatabase;
        //    k.UserName = strUser;
        //    k.UserPassword = strPassword;
        //    Init(k);
        //}
        //public nData(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword, int timeout)
        //{
        //    Key k = new Key();
        //    k.ServerName = strServer;
        //    k.DatabaseName = strDatabase;
        //    k.UserName = strUser;
        //    k.UserPassword = strPassword;
        //    Init(k);
        //    TimeOutDefault = timeout;
        //}
        //public nData(Int32 xType, String strServer, String strDatabase, String strUser, String strPassword, String strAbsoluteConnectionString)
        //{
        //    Key k = new Key();
        //    k.ServerName = strServer;
        //    k.DatabaseName = strDatabase;
        //    k.UserName = strUser;
        //    k.UserPassword = strPassword;
        //    Init(k);
        //    if (Tools.Strings.StrExt(strAbsoluteConnectionString))
        //        ConnectionString = strAbsoluteConnectionString;
        //}
        //Public Static Functions
        public static bool IsValidDBObjectName(String strIn)
        {
            return (Tools.Strings.StrCmp(strIn, Tools.Strings.StripNonAlphaNumeric(strIn, true)));
        }
        public static bool HasField(System.Data.DataTable d, String s)
        {
            foreach (System.Data.DataColumn c in d.Columns)
            {
                if (Tools.Strings.StrCmp(c.Caption, s))
                    return true;
            }
            return false;
        }
        public static String ConvertDataTableToHTML(DataTable d)
        {
            return ConvertDataTableToHTML(d, false);
        }
        public static String ConvertDataTableToHTML(DataTable d, bool wrap)
        {
            return ConvertDataTableToHTML(d, null, null, wrap);
        }
        public static String ConvertDataTableToHTML(DataTable d, ArrayList formats, ArrayList alignments, bool wrap)
        {
            return DataConnection.ConvertDataTableToHTML(d, formats, alignments, "", wrap);
        }

        public static bool CopyTable(ContextNM context, String source, String dest, String SourceTable, String DestTable, String strFields, ref String status)
        {
            try
            {
                string sql = "SELECT " + strFields + " from " + SourceTable;
                SqlConnection sourceconn = new SqlConnection(source);
                SqlCommand command = new SqlCommand(sql, sourceconn);
                sourceconn.Open();
                IDataReader dr = command.ExecuteReader();
                SqlConnection destconn = new SqlConnection(dest);
                destconn.Open();
                using (SqlBulkCopy copy = new SqlBulkCopy(dest))
                {
                    String[] fields = Tools.Strings.Split(strFields, ",");
                    foreach (String s in fields)
                    {
                        if (Tools.Strings.StrExt(s))
                            copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(s.Trim(), s.Trim()));
                    }
                    copy.BulkCopyTimeout = DataConnection.TimeOut;
                    copy.DestinationTableName = DestTable;
                    context.TheLeader.Comment("Transferring bulk data...");
                    copy.WriteToServer(dr);
                    sourceconn.Close();
                    sourceconn = null;
                    destconn.Close();
                    destconn = null;
                    return true;
                }
            }
            catch (Exception ex)
            {
                status = ex.Message;
                return false;
            }
        }
        public static String GetFieldSpec(DataColumn dc, int len)
        {
            Field f = new Field(dc, len);
            DataConnectionSqlServer d = new DataConnectionSqlServer();
            return d.FieldSpec(f);
        }
        
        public static Object ConvertFromString(String strIn, FieldType t)
        {
            switch (t)
            {
                case FieldType.String:
                case FieldType.Text:
                    return strIn;
                case FieldType.Int64:
                    try
                    {
                        return (Object)(Convert.ToInt64(strIn));
                    }
                    catch
                    {
                        return 0;
                    }
                case FieldType.Int32:
                case FieldType.Boolean:
                    try
                    {
                        return (Object)(Convert.ToInt32(strIn));
                    }
                    catch (Exception e)
                    {
                        return (Object)false;
                    }
                case FieldType.Double:
                    try
                    {
                        return (Object)(Convert.ToDouble(strIn));
                    }
                    catch
                    {
                        return (Object)Convert.ToDouble(0);
                    }
                case FieldType.DateTime:
                    try
                    {
                        return (Object)(Convert.ToDateTime(strIn));
                    }
                    catch
                    {
                        return Tools.Dates.NullDate;
                    }
            }
            return 0;
        }
    }

    namespace Enums
    {
        public enum ServerTypes
        {
            Unknown = -1,
            Any = 0,
            MySQL = 1,
            SQLServer = 2,
        }
    }
}