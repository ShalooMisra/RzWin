using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.Odbc;
using MySql.Data.MySqlClient;

using System.Data.SqlClient;

namespace Tools.Database
{
    public class DataConnectionSqlMy : DataConnection
    {
        public DataConnectionSqlMy()
        {
        }

        public DataConnectionSqlMy(String server, String database, String user, String password)
        {

            TheKey = new Key();
            TheKey.ServerName = server;
            TheKey.DatabaseName = database;
            TheKey.UserName = user;
            TheKey.UserPassword = password;

      
            ConnectionString = "server=" + server + ";port=3306;uid=<redacted>; database=" + database + ";password=" + password;
          
        }


        //KT 4-14-2016 - Implementing Missing Methods from DatConnectionSqlServer.cs to support MySql
        public Int32 GetScalar_Integer(String strSQL)
        {
            return ScalarInt32(strSQL);
        }


        public String DatabaseName
        {
            get
            {
                return TheKey.DatabaseName;
            }
        }


        public ArrayList GetScalarArray(String strSQL)
        {
            return GetScalarArray(strSQL, false);
        }

        public ArrayList GetScalarArray(String strSQL, bool hidemessage)
        {
            return ScalarArray(strSQL);
        }

        public Int64 GetScalar_Long(String strSQL)
        {
            return ScalarInt64(strSQL);
        }
        public Int64 GetScalar_Long(String strSQL, bool failok, bool hidemsg, ref string msg)
        {
            return ScalarInt64(strSQL);
        }

        //End KT 4-14-2016
        public static String DateFormat(DateTime dt)
        {
            return dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
        }

        public override string ConnectionStringGet(bool skipProvider = false)
        {
		   
            return "Server=" + TheKey.ServerName + ";Port=3306;Database=" + TheKey.DatabaseName + ";Uid=" + TheKey.UserName + ";Pwd=" + TheKey.UserPassword + ";Connection Timeout = 10";
          
            



        }

        public override bool FieldsExist(string table, string[] fields)
        {
            return StatementPasses("select " + Tools.Strings.CommaSeparateBlanksIgnore(fields) + " from " + table + " limit 1");
        }
        public override DbConnection ConnectionGet()
        {
            //return new OdbcConnection(ConnectionString);
            return new MySqlConnection(ConnectionString);
        }
        public override DbCommand CommandGet(string sql, DbConnection con)
        {
            //return new OdbcCommand(sql, (OdbcConnection)con);
            return new MySqlCommand(sql, (MySqlConnection)con);
        }
        public override DbDataAdapter AdapterGet()
        {
            //return new OdbcDataAdapter();
            return new MySqlDataAdapter();
        }
        public override string SyntaxFilter(string s)
        {
            string ret = s;
            ret = s.Replace("\\", "\\\\").Replace("'", "\'\'");
            return ret;
        }
        public override ServerType GetServerType()
        {
            return ServerType.SqlMy;
        }
        public override void Backup(ref String strFile)
        {
            throw new NotImplementedException("DataConnectionSqlMy: Backup is not implemented");
        }
        public override void Shrink()
        {
            throw new NotImplementedException("DataConnectionSqlMy: Shrink is not implemented");
        }
        public override bool Reindex()
        {
            throw new NotImplementedException("DataConnectionSqlMy: Reindex is not implemented");
        }
        public override bool ReindexTable(String table)
        {
            throw new NotImplementedException("DataConnectionSqlMy: ReindexTable is not implemented");
        }
        public override bool ViewIs(string table)
        {
            throw new NotImplementedException("DataConnectionSqlMy: ViewIs is not implemented");
        }
        public override bool TableExists(string table)
        {
            throw new NotImplementedException("DataConnectionSqlMy: TableExists is not implemented");
        }
        public override bool StoredProcedureExists(string table)
        {
            throw new NotImplementedException("DataConnectionSqlMy: StoredProcedureExists is not implemented");
        }
        public override string DatabaseCreateSql(Key key)
        {
            throw new NotImplementedException("DataConnectionSqlMy: DatabaseCreateSql is not implemented");
        }
        public override DataConnection MasterConnection
        {
            get
            {
                throw new NotImplementedException("DataConnectionSqlMy: MasterConnection is not implemented");
            }
        }
        public override ArrayList GetFieldArray(String table)
        {
            ArrayList a = new ArrayList();
            DataTable t = Select("select * from " + table + " limit 1");
            if (t == null)
                return a;
            for (int i = 0; i < t.Columns.Count; i++)
                a.Add(t.Columns[i].ColumnName);
            return a;
        }
        public override bool DatabaseExists(String db)
        {
            if (!Tools.Strings.StrExt(db))
                return false;
            DataConnectionSqlMy d = new DataConnectionSqlMy();
            d.Init(GetDatabaseKey(db));
            return d.ConnectPossible();
        }
        public override bool IsDateField(String table, String field)
        {
            DataTable d = Select("select " + field + " from " + table + " limit 1");
            if (d == null)
                return false;
            DataColumn c = d.Columns[0];
            return (c.DataType == System.Type.GetType("System.DateTime"));
        }
        public override bool IsTextField(String table, String field)
        {
            DataTable d = Select("select " + field + " from " + table + " limit 1");
            if (d == null)
                return false;
            DataColumn c = d.Columns[0];
            return (c.DataType == System.Type.GetType("System.String"));
        }
        public override bool IsDecimalField(String table, String field)
        {
            DataTable d = Select("select " + field + " from " + table + " limit 1");
            if (d == null)
                return false;
            DataColumn c = d.Columns[0];
            return (c.DataType == System.Type.GetType("System.Decimal"));
        }

        public override void SetBlob(string table, string field, string where, byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public override byte[] GetBlob(string table, string field, string where)
        {
            throw new NotImplementedException();
        }
    }
}
