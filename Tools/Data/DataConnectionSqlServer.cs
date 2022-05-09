using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Tools.Database
{
    public class DataConnectionSqlServer : DataConnection
    {
        public DataConnectionSqlServer()
        {
        }

        public DataConnectionSqlServer(String server, String database, String user, String password) : this(server, database, user, password, false)
        {

        }

        public DataConnectionSqlServer(String server, String database, String user, String password, bool persistSecurity)
        {
            PersistSecurityInfo = persistSecurity;
            TheKey = new Key();
            TheKey.ServerName = server;
            TheKey.DatabaseName = database;
            TheKey.UserName = user;
            TheKey.UserPassword = password;           
            ConnectionStringSet();
        }

        public String ServerName
        {
            get
            {
                return TheKey.ServerName;
            }
        }


        public String DatabaseName
        {
            get
            {
                return TheKey.DatabaseName;
            }
        }

        public String UserName
        {
            get
            {
                return TheKey.UserName;
            }
        }

        public String UserPassword
        {
            get
            {
                return TheKey.UserPassword;
            }
        }

        public bool SkipProvider = false;
        public bool PersistSecurityInfo = false;
        public bool BigIntDisabled = false;
        public bool VarcharMaxDisabled = false;
        
        public override String ConnectionStringGet(bool skipProvider)
        {
            //1-20-2020 - As of yet, I have not found a way to get SSPI to work.  Works for my Kevint account, but all others crash after Rz Login
            //return "Data Source=" + TheKey.ServerName + ";Initial Catalog=" + TheKey.DatabaseName + ";Integrated Security=SSPI;";
            String security = "";
            if (PersistSecurityInfo)
                security = ";Persist Security Info=True";

            if (skipProvider)  //the parameter passed in, not SkipProvider
                return String.Concat("User Id=", TheKey.UserName, ";Password=", TheKey.UserPassword, ";Initial Catalog=", TheKey.DatabaseName, ";Data Source=", TheKey.ServerName, security);
            else
                //return String.Concat("Provider=SQLOLEDB.1;User Id=", TheKey.UserName, ";Password=", TheKey.UserPassword, ";Initial Catalog=", TheKey.DatabaseName, ";Data Source=", TheKey.ServerName, security);
                return String.Concat("Provider=SQLOLEDB.1;User Id=", TheKey.UserName, ";Password=", TheKey.UserPassword, ";Initial Catalog=", TheKey.DatabaseName, ";Data Source=", TheKey.ServerName);
        }
        public override bool ViewIs(string table)
        {
            try
            {
                String field = "type";
                if (FieldExists("sysobjects", "xtype"))
                    field = "xtype";
                String s = ScalarString("select " + field + " from sysobjects where name  = '" + table + "'");
                return Tools.Strings.StrCmp(s, "V");
            }
            catch
            {
                return false;
            }
        }
        public override bool TableExists(string table)
        {
            return Tools.Strings.StrCmp(ScalarString("select name from sysobjects where name = '" + SyntaxFilter(table) + "' and type = 'U'"), table);
        }
        public override bool StoredProcedureExists(string table)
        {
            return Tools.Strings.StrCmp(ScalarString("select name from sysobjects where name = '" + SyntaxFilter(table) + "' and type = 'P'"), table); 
        }
        public override bool FieldsExist(string table, string[] fields)
        {
            return StatementPasses("select top 1 " + Tools.Strings.CommaSeparateBlanksIgnore(fields) + " from [" + table + "]");
        }
        public override DbConnection ConnectionGet()
        {
            return new OleDbConnection(ConnectionString);
        }
        public override DbCommand CommandGet(string sql, DbConnection con)
        {
            return new OleDbCommand(sql, (OleDbConnection)con);
        }

        public override DbDataAdapter AdapterGet()
        {
            return new OleDbDataAdapter();
        }
        public override String FieldTypeSpec(Field f)
        {
            String ret = "";

            switch (f.Type)
            {
                case FieldType.DateTime:
                case FieldType.Double:
                case FieldType.Boolean:
                case FieldType.Text:
                case FieldType.Blob:
                    ret = base.FieldTypeSpec(f);
                    break;
                case FieldType.Int64:
                    if (BigIntDisabled)
                        ret = base.FieldTypeSpec(f);
                    else
                        ret = "bigint";
                    break;
                case FieldType.Int32:
                    if (BigIntDisabled)
                        ret = base.FieldTypeSpec(f);
                    else
                        ret = "int";
                    break;
                case FieldType.String:
                default:
                    if (f.Length >= 50 && f.Length < 256 && (f.Name.ToLower().EndsWith("id") || f.Name.ToLower().Contains("_uid_") || f.Name.ToLower().Contains("_id_") || f.Name.ToLower() == "pec" || f.Name.ToLower() == "pec_stripped" ))
                        ret = "varchar(256)";
                    else if (f.Length > 0 || VarcharMaxDisabled)
                        ret = base.FieldTypeSpec(f);
                    else
                        ret = "varchar(max)";
                    break;
            }

            if (f.Required)
                ret += " NOT NULL";

            if (f.Unique)
                ret += " UNIQUE";

            return ret;
        }
        public override string DatabaseCreateSql(Key key)
        {
            String folder = key.FolderPath;
            if (Tools.Strings.StrExt(folder))
                folder = Tools.Folder.ConditionFolderName(folder);
            if (!Tools.Strings.StrExt(folder))
                folder = "c:\\eternal\\data\\newmethod\\";
            String s = "CREATE DATABASE " + key.DatabaseName + "\r\n";
            s = s + "ON\r\n";
            s = s + "( NAME = " + key.DatabaseName + "_data,\r\n";
            s = s + "    FILENAME = '" + folder + key.DatabaseName + "_data.mdf',\r\n";
            s = s + "    SIZE = 10,\r\n";
            s = s + "    FILEGROWTH = 10% )\r\n";
            s = s + "LOG ON\r\n";
            s = s + "( NAME = " + key.DatabaseName + "_log,\r\n";
            s = s + "    FILENAME = '" + folder + key.DatabaseName + "_log.ldf',\r\n";
            s = s + "    SIZE = 5MB,\r\n";
            s = s + "    FILEGROWTH = 10% )\r\n";
            return s;
        }
        public override DataConnection MasterConnection
        {
            get
            {
                DataConnectionSqlServer ret = new DataConnectionSqlServer();
                Key key = new Key(TheKey);
                key.DatabaseName = "master";
                ret.Init(key);
                return ret;
            }
        }
        public override ServerType GetServerType()
        {
            return ServerType.SqlServer;
        }
        public override void Shrink()
        {
            Execute("DBCC SHRINKDATABASE (" + TheKey.DatabaseName + ", 10)");
        }
        public override void Backup(ref String strFile)
        {
            if (!Tools.Strings.StrExt(strFile))
            {
                strFile = "c:\\backup\\";
                if (!System.IO.Directory.Exists(strFile))
                    throw new Exception("Backup: The folder " + strFile + " does not exist.");
            }
            if (!Tools.Files.HasFileName(strFile))
                strFile = strFile + TheKey.DatabaseName + "_" + Tools.Folder.GetNowPath() + ".bak";
            String strSQL;
            try
            {
                strSQL = "EXEC sp_dropdevice '" + TheKey.DatabaseName + "_bak'";
                Execute(strSQL);
            }
            catch { }
            strSQL = "EXEC sp_addumpdevice 'disk', '" + TheKey.DatabaseName + "_bak', '" + strFile + "'";
            Execute(strSQL);
            strSQL = "BACKUP DATABASE " + TheKey.DatabaseName + " TO " + TheKey.DatabaseName + "_bak";
            Execute(strSQL);
        }
        public override bool Reindex()
        {
            try { Execute("sp_updatestats"); }
            catch { return false; }
            try
            {
                Execute("EXEC sp_MSforeachtable @command1=\"print '?' DBCC DBREINDEX ('?', ' ', 80)\"");
                return true;
            }
            catch { return false; }
        }
        public override bool ReindexTable(String table)
        {
            try
            {
                Execute("DBCC DBREINDEX ('" + table + "', ' ', 80)");
                return true;
            }
            catch { return false; }
        }

        public String Filter(String s)
        {
            return SyntaxFilter(s);
        }

        public override string SyntaxFilter(string s)
        {
            return s.Replace("'", "''");
        }
        


        public override ArrayList GetFieldArray(String table)
        {
            ArrayList a = new ArrayList();
            DataTable t = Select("select top 1 * from " + table);
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
            DataConnectionSqlServer d = new DataConnectionSqlServer();
            d.Init(GetDatabaseKey(db));
            return d.ConnectPossible();
        }
        public override bool IsDateField(String table, String field)
        {
            DataTable d = Select("select top 1 " + field + " from " + table);
            if (d == null)
                return false;
            DataColumn c = d.Columns[0];
            return (c.DataType == System.Type.GetType("System.DateTime"));
        }
        public override bool IsTextField(String table, String field)
        {
            DataTable d = Select("select top 1 " + field + " from " + table);
            if (d == null)
                return false;
            DataColumn c = d.Columns[0];
            return (c.DataType == System.Type.GetType("System.String"));
        }
        public override bool IsDecimalField(String table, String field)
        {
            DataTable d = Select("select top 1 " + field + " from " + table);
            if (d == null)
                return false;
            DataColumn c = d.Columns[0];
            return (c.DataType == System.Type.GetType("System.Decimal"));
        }

        public bool DetachDatabase(String databaseName, ref String err)
        {
            try { Execute("ALTER DATABASE " + databaseName + " SET SINGLE_USER with rollback immediate"); }
            catch (Exception e)
            {
                err = "Failed to single user " + databaseName + ": " + e.Message;
                return false;
            }
            try { Execute("EXEC sp_detach_db " + databaseName); }
            catch (Exception e)
            {
                err = "Failed to detach " + databaseName + ": " + e.Message;
                return false;
            }
            return true;
        }

        public bool IsValidName(String strIn)
        {
            return (Tools.Strings.StrCmp(strIn, Tools.Strings.StripNonAlphaNumeric(strIn, true)));
        }

        public bool Copy(String strNewName, string strNewFolder, ref String err)
        {
            if (!IsValidName(strNewName))
                throw new Exception("The database name " + strNewName + " is not a valid database item name.");

            if (DatabaseExists(strNewName))
                throw new Exception("The database name " + strNewName + " is already in use.");

            String strFile = strNewName;
            try { Backup(ref strFile); }
            catch (Exception e)
            {
                err = "The backup step of the copy operation failed: " + e.Message;
                return false;
            }
            if (!Restore(strFile, strNewName, strNewFolder, TheKey.DatabaseName))
            {
                err = "The restore step of the copy operation failed." + err;
                return false;
            }
            return true;
        }

        public bool Restore(String strFile, String strName, String strNewFolder, String strOldName)
        {
            string s = "";
            return Restore(strFile, strName, strNewFolder, strOldName, ref s, "", "");
        }
        public bool Restore(String strFile, String strName, String strNewFolder, String strOldName, ref string msg, String newDataFileName, String newLogFileName)
        {
            DataTable d = null;
            try { d = Select("RESTORE FILELISTONLY FROM DISK = '" + strFile + "'"); }
            catch (Exception e)
            { msg = e.Message; }
            if (!Tools.Data.DataTableExists(d))
            {
                msg = "Restore() : !Tools.Data.DataTableExists(d) ErrMsg : " + msg;
                return false;
            }
            String strLogicalData = strOldName + "_Data";
            String strLogicalLog = strOldName + "_Log";
            foreach (DataRow r in d.Rows)
            {
                switch (Tools.Data.NullFilterString(r["Type"]).ToLower())
                {
                    case "d":
                        strLogicalData = Tools.Data.NullFilterString(r["LogicalName"]);
                        break;
                    case "l":
                        strLogicalLog = Tools.Data.NullFilterString(r["LogicalName"]);
                        break;
                }
            }
            if (!Tools.Strings.StrExt(newDataFileName))
                newDataFileName = strName + ".mdf";
            if (!Tools.Strings.StrExt(newLogFileName))
                newLogFileName = strName + ".ldf";
            String strSQL = "\r\nRESTORE DATABASE " + strName + " FROM DISK = '" + strFile + "' WITH MOVE '" + strLogicalData + "' TO '" + strNewFolder + newDataFileName + "', MOVE '" + strLogicalLog + "' TO '" + strNewFolder + newLogFileName + "'";
            try
            {
                Execute(strSQL);
                return true;
            }
            catch (Exception e)
            {
                msg = e.Message;
                return false;
            }
        }

        public override void SetBlob(string table, string field, string where, byte[] bytes)
        {
            String sql;

            if (bytes == null)
            {
                sql = "update " + table + " set " + field + " = null where " + where;
                Execute(sql);
                return;
            }
            else
                sql = "update " + table + " set " + field + " = ? where " + where;  //@picture

            Int32 affect;

            System.Data.IDbConnection xConnect = ConnectionGet();
            IDbCommand oCmd = xConnect.CreateCommand();
            oCmd.CommandTimeout = TimeOut;
            oCmd.CommandText = sql;

            IDbDataParameter param = oCmd.CreateParameter();
            param.ParameterName = "@picture";
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.Binary;
            param.Value = bytes;
            oCmd.Parameters.Add(param);
            xConnect.Open();
            affect = oCmd.ExecuteNonQuery();
            oCmd.Dispose();
            oCmd = null;
            xConnect.Close();
            xConnect = null;
        }

        public override byte[] GetBlob(string table, string field, string where)
        {
            String sql = "select " + field + " from " + table + " where " + where;
            try
            {
                System.Data.IDbConnection xConnect = ConnectionGet();
                IDbCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = TimeOut;
                oCmd.CommandText = sql;
                xConnect.Open();
                Byte[] data = (byte[])oCmd.ExecuteScalar();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override void ExecuteTransaction(string sql)
        {
            //base.ExecuteTransaction(sql);

            String id = Tools.Strings.GetNewID();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CREATE PROCEDURE p" + id);
            sb.AppendLine("AS");
            sb.AppendLine(sql);

            Execute(sb.ToString());  //if this throws an error, just let it

            try
            {
                sb = new StringBuilder();
                sb.AppendLine("begin try");
                sb.AppendLine("begin tran");
                sb.AppendLine("EXEC p" + id);
                sb.AppendLine("commit tran");
                sb.AppendLine("end try");
                sb.AppendLine("begin catch");
                sb.AppendLine("rollback tran");
                sb.AppendLine("DECLARE @ErrorMessage NVARCHAR(4000);");
                sb.AppendLine("DECLARE @ErrorSeverity INT;");
                sb.AppendLine("DECLARE @ErrorState INT;");
                sb.AppendLine("SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();");
                sb.AppendLine("RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);");
                sb.AppendLine("end catch");
                Execute(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Execute("DROP PROCEDURE p" + id);
            }
        }

        public bool ViewExists(String strView)
        {
            return Tools.Strings.StrCmp(ScalarString("select xtype from sysobjects where name = '" + strView + "'"), "V");
        }
        public bool DropView(String strView)
        {
            try
            {
                Execute("drop view " + strView);
                return true;
            }
            catch { return false; }
        }
        public bool FieldExists(String strTable, String strField)
        {
            return StatementPasses(String.Concat("select top 1 ", strField, " from ", strTable));
        }
        public bool FieldExists(DataTable dt, String strField)
        {
            try
            {
                if (!Tools.Strings.StrExt(strField))
                    return false;
                foreach (DataColumn dc in dt.Columns)
                {
                    if (Tools.Strings.StrCmp(dc.ColumnName, strField))
                        return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Server: " + ServerName + "\r\n" + "Database: " + DatabaseName;
        }
        public bool RenameDatabase(String strNewName)
        {
            try
            {
                Execute("alter database " + TheKey.DatabaseName + " MODIFY NAME = " + strNewName + " ");
                return true;
            }
            catch { return false; }
        }
        public bool MakeTableExist(String strTable)
        {
            try
            {
                List<Field> l = new List<Field>();
                l.Add(new Field("unique_id", FieldType.String, 255));
                l.Add(new Field("grid_color", FieldType.Int32));
                l.Add(new Field("icon_index", FieldType.Int32));
                TableCreate(strTable, l);
                return true;
            }
            catch { return false; }
        }
        public bool MakeFieldExist(String strTable, String strField, Int32 t, Int32 length)
        {
            try
            {
                Field f = new Field(strField, (FieldType)t, length);
                FieldMakeExist(strTable, f);
                return true;
            }
            catch { return false; }
        }
        public String GetFieldSpec(FieldType type, int length)
        {
            int i = (int)type;
            Field f = new Field("", (FieldType)i, length);
            return FieldSpec(f);
        }

        public Int64 GetScalar(String strSQL, Int64 i)
        {
            return ScalarInt64(strSQL, i);
        }
        public Int32 GetScalar_Integer(String strSQL)
        {
            return ScalarInt32(strSQL);
        }
        public String GetScalar_String(String strSQL)
        {
            return GetScalar(strSQL, "");
        }
        public Int64 GetScalar_Long(String strSQL)
        {
            return ScalarInt64(strSQL);
        }
        public Int64 GetScalar_Long(String strSQL, bool failok, bool hidemsg, ref string msg)
        {
            return ScalarInt64(strSQL);
        }
        public Double GetScalar(String strSQL, Double d)
        {
            return ScalarDouble(strSQL, d);
        }
        public String GetScalar(String strSQL, String s)
        {
            return ScalarString(strSQL, s);
        }
        public DateTime GetScalar(String strSQL, DateTime d)
        {
            return ScalarDateTime(strSQL, d);
        }
        public bool GetScalar(String strSQL, bool b)
        {
            return ScalarBoolean(strSQL, b);
        }
        public Double GetScalar_Float(String strSQL)
        {
            return GetScalar_Float(strSQL, false);
        }
        public Double GetScalar_Float(String strSQL, bool failok)
        {
            return ScalarDouble(strSQL);
        }
        public Boolean GetScalar_Boolean(String strSQL)
        {
            return ScalarBoolean(strSQL);
        }
        public DateTime GetScalar_Date(String strSQL)
        {
            return ScalarDateTime(strSQL);
        }
        public DateTime GetScalar_Date(String strSQL, bool failok, bool hidemsg, ref string msg)
        {
            return ScalarDateTime(strSQL);
        }

        public void TruncateLog()
        {
            //context.TheLeader.Comment("Truncating the transaction log on " + TheKey.ServerName + "." + TheKey.DatabaseName + "...");
            long l = GetLogSizeK();
            //context.TheLeader.Comment("Original log size: " + Tools.Number.LongFormat(l) + " K");
            String s = ScalarString("select name from sysfiles WHERE FILEID=2");
            if (!Tools.Strings.StrExt(s))
                throw new Exception("Database name not found");

            //we need a better way to detect this
            bool b2008 = true;
            //if (n_sys.ContextDefault.xSys != null)
            //    b2008 = n_sys.ContextDefault.xSys.GetSetting_Boolean("IS_SQL2008");  //xsys is null sometimes
            if (b2008)
            {
                Execute("alter database " + TheKey.DatabaseName + " set recovery simple");
                Execute("dbcc shrinkfile( " + s + ", 10 )");
                Execute("alter database " + TheKey.DatabaseName + " set recovery full");
            }
            else
            {
                Execute("backup log " + TheKey.DatabaseName + " with truncate_only");
                Execute("dbcc shrinkfile( " + s + ", 10 )");
            }
            l = GetLogSizeK();
            //context.TheLeader.Comment("Current log size: " + Tools.Number.LongFormat(l) + " K");
            //context.TheLeader.Comment("Truncate complete.");
        }
        public long GetDataFileSizeInK()
        {
            return GetDataSizeK();
        }
        public long GetLogFileSizeInK()
        {
            return GetLogSizeK();
        }
        public void ImportDataTable(DataTable d, String strTable)
        {
            ImportDataTable(d, strTable, null);
        }
        public void ImportDataTable(DataTable d, String strTable, int[] lens)
        {
            ImportDataTable(d, strTable, false, lens, false, -1);
        }
        public void ImportDataTable(DataTable d, String strTable, bool silent, int[] lens, bool existing, int abs_len)
        {
            if (d == null)
                throw new Exception("Null table");
            String strStatus = "";
            using (SqlBulkCopy copy = new SqlBulkCopy(ConnectionStringGet(true)))
            {
                int i = 0;
                String s = "";
                StringBuilder sb = new StringBuilder();
                foreach (DataColumn dc in d.Columns)
                {
                    try
                    {
                        s = dc.Caption;
                        if (!existing)
                        {
                            int len = 0;
                            if (abs_len > 0)
                                len = abs_len;
                            else
                            {
                                if (lens != null)
                                    len = lens[i];
                            }
                            if (i == 0)
                                Execute("create table " + strTable + "( " + s + " " + FieldTypeSpec(new Field(dc, len)) + " )");
                            else
                                Execute("alter table " + strTable + " add " + s + " " + FieldTypeSpec(new Field(dc, len)));
                            sb.AppendLine(s + " : " + FieldTypeSpec(new Field(dc, len)));
                        }
                        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(s, s));
                        i++;
                    }
                    catch (Exception ex)
                    {
                        strStatus += "Error in Import DataTable on column " + s + " : " + ex.Message + "\r\n";
                    }
                }
                try
                {
                    copy.BulkCopyTimeout = TimeOutDefault;
                    copy.DestinationTableName = strTable;
                    copy.WriteToServer(d);
                    copy.Close();
                }
                catch (Exception ex2)
                {
                    if (!silent)
                        throw new Exception(strStatus + ex2.Message);
                }
            }
        }
        public bool ImportDelimitedFileToTable(String strFile, Char limit, ref String strTable, ref String strStatus)
        {
            try
            {
                return ImportDelimitedFileToTable(strFile, limit, ref strTable);
            }
            catch (Exception e)
            {
                strStatus = e.Message;
                return false;
            }
        }

        public void ExportSQLToCsv(String strSQL, String strFile, ref long l)
        {
            ExportSQLToCsv(strSQL, strFile, ref l, "");
        }
        public void ExportSQLToCsv(String strSQL, String strFile, ref long l, String headerstring)
        {
            ExportDataTableToCsv(Select(strSQL), strFile, ref l, headerstring);
        }
        public void ExportDataTableToCsv(DataTable d, String strFile, ref long l)
        {
            ExportDataTableToCsv(d, strFile, ref l, "");
        }
        public void ExportDataTableToCsv(DataTable d, String strFile, ref long l, String headerstring)
        {
            ExportCSV(d, strFile, ref l, false, headerstring);
        }
        public bool ExportSqlToCsvWithHeader(String sql, String file, ref long l)
        {
            try
            {
                DataTable d = Select(sql);
                if (d == null)
                    return false;
                ExportCSV(d, file, ref l, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CheckBigIntDisabled()
        {
            if (!StatementPasses("select top 1 cast(1 as bigint) as test from sysobjects"))
                BigIntDisabled = true;
        }
        public void CheckVarcahrMaxDisabled()
        {
            if (!StatementPasses("select top 1 cast(1 as varchar(max)) as test from sysobjects"))
                VarcharMaxDisabled = true;
        }
        public String GetVarcharMax()
        {
            if (VarcharMaxDisabled)
                return "varchar(255)";
            else
                return "varchar(max)";
        }

        public DataTable GetDataTable(String strSQL, bool FailOK)
        {
            return GetDataTable(strSQL, FailOK, false);
        }
        public DataTable GetDataTable(String strSQL, bool FailOK, bool hidemessage)
        {
            string s = "";
            return GetDataTable(strSQL, FailOK, hidemessage, ref s);
        }
        public DataTable GetDataTable(String strSQL, bool FailOK, bool hidemessage, ref string msg)
        {
            try
            {
                return Select(strSQL, FailOK);
            }
            catch (Exception e)
            {
                if (!hidemessage)
                    throw e;
                msg = e.Message;
                return null;
            }
        }

        public static FieldType ConvertColumnTypeToFieldType(DataColumn t)
        {
            if (System.Type.Equals(t.DataType, System.Type.GetType("Boolean")))
                return FieldType.Boolean;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Byte")))
                return FieldType.Int32;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Char")))
                return FieldType.Int32;
            if (System.Type.Equals(t.DataType, System.Type.GetType("DateTime")))
                return FieldType.DateTime;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Decimal")))
                return FieldType.Double;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Double")))
                return FieldType.Double;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Int16")))
                return FieldType.Int32;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Int32")))
                return FieldType.Int32;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Int64")))
                return FieldType.Int64;
            if (System.Type.Equals(t.DataType, System.Type.GetType("SByte")))
                return FieldType.Int32;
            if (System.Type.Equals(t.DataType, System.Type.GetType("Single")))
                return FieldType.Double;
            if (System.Type.Equals(t.DataType, System.Type.GetType("String")))
                return FieldType.String;
            if (System.Type.Equals(t.DataType, System.Type.GetType("TimeSpan")))
                return FieldType.Double;
            if (System.Type.Equals(t.DataType, System.Type.GetType("UInt16")))
                return FieldType.Int32;
            if (System.Type.Equals(t.DataType, System.Type.GetType("UInt32")))
                return FieldType.Int64;
            if (System.Type.Equals(t.DataType, System.Type.GetType("UInt64")))
                return FieldType.Int64;
            return FieldType.String;
        }
        public ArrayList GetTableArray()
        {
            ArrayList a = new ArrayList();
            DataTable t = Select("select name from sysobjects where type = 'U' order by name");
            if (t == null)
                return a;
            for (int i = 0; i < t.Rows.Count; i++)
                a.Add(Convert.ToString(t.Rows[i][0]));
            return a;
        }

        public bool CreateDatabaseWithoutChanging(String strDatabase, ref String strError, String dataPath)
        {
            try
            {
                Key k = GetDatabaseKey(strDatabase);
                k.FolderPath = dataPath;
                DatabaseCreate(k);
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                return false;
            }
        }

        public static String ReplaceNullString(FieldType type)
        {
            switch (type)
            {
                case FieldType.String:
                case FieldType.Text:
                    return "''";
                case FieldType.Int32:
                case FieldType.Int64:
                case FieldType.Double:
                case FieldType.Boolean:
                    return "0";
                case FieldType.DateTime:
                    return "'01/01/1900'";
                default:
                    return "''";
            }
        }

        public String FormatInsertValue(Object value, FieldType type, int StringLength)
        {
            String s;
            if (value == null)
                return ReplaceNullString(type);
            switch (type)
            {
                case FieldType.String:
                    s = Convert.ToString(value);
                    //s = Left(s, StringLength);
                    s = SyntaxFilter(s);
                    return String.Concat("'", s, "'");
                case FieldType.Text:
                    return String.Concat("'", Filter(value.ToString()), "'");
                case FieldType.Int32:
                case FieldType.Int64:
                case FieldType.Double:
                    return value.ToString();
                case FieldType.DateTime:
                    return String.Concat("'", ((DateTime)(value)).ToString(), "'");
                case FieldType.Boolean:
                    return BoolFilter((bool)value);
                default:
                    return "";
            }
        }    //overload??
        public bool IsView(String strTable)
        {
            try
            {
                String strField = "";
                String s = "";
                if (FieldExists("sysobjects", "xtype"))
                    strField = "xtype";
                else
                    strField = "type";
                s = ScalarString("select " + strField + " from sysobjects where name  = '" + strTable + "'");
                return Tools.Strings.StrCmp(s, "V");
            }
            catch
            {
                return false;
            }
        }
        public bool BackupTableList(ArrayList a, ref String strFile, String strDatabase, ref String err, String dataPath)
        {
            if (!BackupTableList_Tables(a, strDatabase, ref err, dataPath))
                return false;

            return BackupTableList_Database(ref strFile, strDatabase, ref err);
        }
        public bool BackupTableList_Tables(ArrayList a, String s, ref String err, String dataPath)
        {
            if (DatabaseExists(s))
            {
                err = "The database " + s + " already exists";
                return false;
            }
            //context.TheLeader.Comment("Creating " + s + "...");
            Key k = GetDatabaseKey(s);
            k.FolderPath = dataPath;
            try { DatabaseCreate(k); }
            catch (Exception e)
            {
                throw new Exception("The database " + s + " couldn't be created in " + dataPath + " - " + e.Message);
            }
            foreach (String t in a)
            {
                if (!TableExists(t))
                    continue;
                String strSQL = "select * into " + s + ".dbo." + t + " from " + t;
                try { Execute(strSQL); }
                catch { return false; }
            }
            return true;
        }
        public bool BackupTableList_Database(ref String strFile, String strDatabase, ref String err)
        {
            DataConnectionSqlServer d = new DataConnectionSqlServer();
            d.Init(GetDatabaseKey(strDatabase));
            if (!d.ConnectPossible())
            {
                err = "Could not connect to " + strDatabase;
                return false;
            }
            try { d.Backup(ref strFile); }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
            d = null;
            if (Tools.Strings.HasString(strDatabase, "_temp_"))
            {
                if (MasterConnection == null)
                    return false;
                if (!MasterConnection.ConnectPossible())
                    return false;
                //context.TheLeader.Comment("Dropping database " + strDatabase);
                MasterConnection.Execute("ALTER DATABASE " + strDatabase + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                try { MasterConnection.Execute("DROP DATABASE " + strDatabase); }
                catch (Exception e)
                {
                    err = "Failed to remove previous copy of " + strDatabase + " Msg: " + e.Message;
                    return false;
                }
            }
            return true;
        }
        public bool Backup(ref String strFile, ref String err)
        {
            try
            {
                Backup(ref strFile);
                return true;
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
        }

        public bool ReTargetDatabase(String strDatabase)
        {
            TheKey.DatabaseName = strDatabase;
            this.Init(TheKey);
            return true;
        }
        public ArrayList GetScalarArray(String strSQL)
        {
            return GetScalarArray(strSQL, false);
        }
        public ArrayList GetScalarArray(String strSQL, bool hidemessage)
        {
            return ScalarArray(strSQL);
        }
        public String ConvertSQLToTabDelimited(String strSQL)
        {
            StringBuilder sb = new StringBuilder();
            DataTable d = Select(strSQL);
            if (!Tools.Data.DataTableExists(d))
                return "";
            foreach (DataColumn c in d.Columns)
            {
                sb.Append(c.Caption + "\t");
            }
            sb.Append("\r\n");
            foreach (DataRow r in d.Rows)
            {
                foreach (DataColumn c in d.Columns)
                {
                    Object o = r[c.Ordinal];
                    if (o == null)
                        sb.Append("\t");
                    else
                        sb.Append(o.ToString() + "\t");
                }
                sb.Append("\r\n");
            }
            return sb.ToString();
        }
        public String DateExistsSQL(String strField)
        {
            return " isnull(" + strField + ", cast('01/01/1900' as datetime)) > cast('01/02/1900' as datetime) ";
        }
        public String ConvertSQLToHTML(String strSQL)
        {
            return ConvertSQLToHTML(strSQL, false);
        }
        public String ConvertSQLToHTML(String strSQL, bool wrap)
        {
            return ConvertDataTableToHTML(Select(strSQL), null, null, "", wrap);
        }
        public override bool RenameTable(String strTable, String strNew)
        {
            try
            {
                Execute("sp_rename '" + strTable + "', '" + strNew + "'");
                return true;
            }
            catch { return false; }
        }

        public override void RenameField(String strTable, String strFieldStart, String strFieldEnd)
        {
            Execute("EXEC sp_rename '" + strTable + ".[" + strFieldStart + "]', '" + strFieldEnd + "', 'COLUMN'");
        }

        public bool HasIdentityField(String strTable)
        {
            return Tools.Strings.StrExt(ScalarString("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'TableHasIdentity') = 1 AND TABLE_TYPE = 'BASE TABLE' and table_name = '" + strTable + "' "));
        }
        public DataTable GetTableTable()
        {
            return Select("select name, crdate from sysobjects where type = 'U' order by crdate");
        }

        public bool LinkSQLServer(DataConnection nd)
        {
            String strSQL = "USE [master] \r\n EXEC master.dbo.sp_addlinkedserver @server = N'" + nd.TheKey.ServerName + "', @srvproduct=N'SQL Server'\n";
            long l = 0;
            Execute(strSQL, ref l, true);
            strSQL = "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'collation compatible', @optvalue=N'false'\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'data access', @optvalue=N'true'\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'rpc', @optvalue=N'false'\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'rpc out', @optvalue=N'false'\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'connect timeout', @optvalue=N'0'\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'collation name', @optvalue=null\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'query timeout', @optvalue=N'0'\n" + "EXEC master.dbo.sp_serveroption @server=N'" + nd.TheKey.ServerName + "', @optname=N'use remote collation', @optvalue=N'true'\n";
            Execute(strSQL, ref l, true);
            strSQL = "EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname = N'" + nd.TheKey.ServerName + "', @locallogin = NULL , @useself = N'False', @rmtuser = N'" + nd.TheKey.UserName + "', @rmtpassword = N'" + nd.TheKey.UserPassword + "'\n";
            try
            {
                Execute(strSQL);
                return true;
            }
            catch { return false; }
        }
        public void SplitEmailDomain(String TableName, String strEmailField, String strDestField)
        {
            long le = 0;
            SplitEmailDomain(TableName, strEmailField, strDestField, ref le, "");
        }
        public void SplitEmailDomain(String TableName, String strEmailField, String strDestField, ref long l, String where)
        {
            String strSQL = "alter table " + TableName + " add temp_email_split_index int";
            Execute(strSQL);
            
            strSQL = "update " + TableName + " set temp_email_split_index = isnull(charindex('@', " + strEmailField + "), -1)";
            if (Tools.Strings.StrExt(where))
                strSQL += " where " + where;
            Execute(strSQL);
            
            strSQL = "update " + TableName + " set " + strDestField + " = SubString(" + strEmailField + ", temp_email_split_index + 1, 4096) where temp_email_split_index > 0";
            if (Tools.Strings.StrExt(where))
                strSQL += " and " + where;
            Execute(strSQL, ref l);
            
            Execute("alter table " + TableName + " drop column temp_email_split_index");
        }
        public void SplitEmailSuffix(String TableName, String strEmailField, String strDestField)
        {
            SplitEmailSuffix(TableName, strEmailField, strDestField, "");
        }
        public void SplitEmailSuffix(String TableName, String strEmailField, String strDestField, String where)
        {
            long l = 0;
            String strSQL = "alter table " + TableName + " add temp_email_split_index int";
            Execute(strSQL);
            
            strSQL = "update " + TableName + " set temp_email_split_index = isnull(charindex('.', reverse(" + strEmailField + ")), -1)";
            if (Tools.Strings.StrExt(where))
                strSQL += " where " + where;
            Execute(strSQL);
            
            strSQL = "update " + TableName + " set " + strDestField + " = right(" + strEmailField + ", temp_email_split_index - 1) where temp_email_split_index > 0";
            if (Tools.Strings.StrExt(where))
                strSQL += " and " + where;
            Execute(strSQL, ref l);
            
            Execute("alter table " + TableName + " drop column temp_email_split_index");
        }
        public bool ParseDelimit1(String strTable, String strField, String strLook)
        {
            try
            {
                Execute("update " + strTable + " set " + strField + " = ltrim(rtrim(left(" + strField + ", charindex('" + SyntaxFilter(strLook) + "', " + strField + ") - 1))) where charindex('" + SyntaxFilter(strLook) + "', " + strField + ") > 0");
                return true;
            }
            catch { return false; }
        }
        public bool ParseDelimit1Ascii(String strTable, String strField, int asc)
        {
            try
            {
                Execute("update " + strTable + " set " + strField + " = ltrim(rtrim(left(" + strField + ", charindex(char(" + asc.ToString() + "), " + strField + ") - 1))) where charindex(char(" + asc.ToString() + "), " + strField + ") > 0");
                return true;
            }
            catch { return false; }
        }
        public String InsertFormat(Object val, FieldType t)
        {
            switch (t)
            {
                case FieldType.Boolean:
                    if ((bool)val)
                        return "1";
                    else
                        return "2";
                case FieldType.Double:
                case FieldType.Int64:
                case FieldType.Int32:
                    return val.ToString();
                default:
                    return "'" + SyntaxFilter(val.ToString()) + "'";
            }
        }
        public bool StripField(String strTable, String strField)
        {
            return StripField(strTable, strField, "");
        }
        public bool StripField(String strTable, String field, String where)
        {
            foreach (String s in Tools.Strings.GetTrashKeys())
            {
                String sql = "update " + strTable + " set " + field + " = REPLACE(" + field + ", '" + SyntaxFilter(s) + "', '')";
                if (Tools.Strings.StrExt(where))
                    sql += " where " + where;
                try { Execute(sql); }
                catch { return false; }
            }
            return true;
        }
        public bool StripFieldInto(String table, String field_from, String field_to, String where)
        {
            String sql = "update " + table + " set " + field_to + " = " + field_from;
            if (Tools.Strings.StrExt(where))
                sql += " where " + where;
            try { Execute(sql); }
            catch { return false; }
            return StripField(table, field_to, where);
        }
        public bool SplitFieldLeft(String table, String field_from, String field_to, String split_value, ref long affected)
        {
            return SplitFieldLeft(table, field_from, field_to, split_value, ref affected, "");
        }
        public bool SplitFieldLeft(String table, String field_from, String field_to, String split_value, ref long affected, String where)
        {
            String sql = "update " + table + " set " + field_to + " = ltrim(rtrim(left(" + field_from + ", charindex('" + SyntaxFilter(split_value) + "', " + field_from + ") -1))) where isnull(" + field_from + ", '') like '%" + SyntaxFilter(split_value) + "%'";
            if (Tools.Strings.StrExt(where))
                sql += " and " + where;
            try { Execute(sql, ref affected); }
            catch { return false; }
            long l = 0;
            sql = "update " + table + " set " + field_to + " = ltrim(rtrim(" + field_from + ")) where isnull(" + field_from + ", '') not like '%" + SyntaxFilter(split_value) + "%'";
            if (Tools.Strings.StrExt(where))
                sql += " and " + where;
            try { Execute(sql, ref l); }
            catch { return false; }
            affected += l;
            return true;
        }
        public bool SplitFieldRight(String table, String field_from, String field_to, String split_value, ref long affected)
        {
            return SplitFieldRight(table, field_from, field_to, split_value, ref affected, "");
        }
        public bool SplitFieldRight(String table, String field_from, String field_to, String split_value, ref long affected, String where)
        {
            String sql = "update " + table + " set " + field_to + " = SubString(" + field_from + ", len(" + field_from + ") - charindex('" + SyntaxFilter(split_value) + "', reverse(" + field_from + ")) + 2, 4096) where isnull(" + field_from + ", '') like '%" + SyntaxFilter(split_value) + "%'";
            if (Tools.Strings.StrExt(where))
                sql += " and " + where;
            try { Execute(sql, ref affected); }
            catch { return false; }
            return true;
        }

        public static String BoolFilter(bool blnin)
        {
            if (blnin)
                return "1";
            return "0";
        }

        public bool AddColumnIfNotExists(String fieldName, String tableName, String type, bool allowNull, string defaultValue)
        {
            string nullAllowed = "NOT NULL";
            if (allowNull)
                nullAllowed = "NULL";
            if (defaultValue != null)
                defaultValue = "DEFAULT " + defaultValue;
            string sql = String.Format("IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{0}' AND column_name = '{1}') ALTER TABLE {0} ADD {1} {2} {3} {4}", tableName, fieldName, type, nullAllowed, defaultValue);
            try
            {
                Execute(sql);
                return true;
            }
            catch { return false; }
        }

        public static bool IsDefinitlelySameDatabase(DataConnectionSqlServer d1, DataConnectionSqlServer d2)
        {
            String checkid = "temp_newmethod_check_for_table_exists_do_not_use_1234567asdasdasdasd_" + Tools.Strings.GetNewID();
            while(d1.TableExists(checkid) || d2.TableExists(checkid))
            {
                checkid += "x";
            }
            List<Field> f = new List<Field>();
            f.Add(new Field("unique_id", FieldType.String, 255));
            d1.TableCreate(checkid, f);
            bool b = d2.TableExists(checkid);
            d1.DropTable(checkid);
            return b;
        }

        public String ConnectionStringWithoutProvider
        {
            get
            {
                return String.Concat("User Id=", TheKey.UserName, ";Password=", TheKey.UserPassword, ";Initial Catalog=", TheKey.DatabaseName, ";Data Source=", TheKey.ServerName);
            }
        }
    }

    public enum SplitDirection
    {
        Left = 0,
        Right = 1,
    }
}