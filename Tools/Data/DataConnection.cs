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
    public abstract class DataConnection
    {
        //Public Static Variables
        public static bool SimulateDelay = false;
        public static int TimeOut = 20800;//6 hours?
        //Public Variables
        public int TimeOutDefault = 20800;//6 hours?
        public Key TheKey;
        public String ConnectionString;
        public ArrayList StatementCache;
        public bool CacheStatements = false;

        //Public Static Functions
        public static DataConnection Create(ServerType type)
        {
            switch (type)
            {
                case ServerType.SqlMy:
                    return new DataConnectionSqlMy();
                case ServerType.SqlServer:
                default:
                    return new DataConnectionSqlServer();
            }
        }
        public static String ConvertDataTableToHTML(DataTable d, ArrayList formats = null, ArrayList alignments = null, String linecolor = "", bool wrap = false)
        {
            DataFormatter f = new DataFormatter();
            f.WrapText = wrap;
            if (formats != null)
            {
                f.Formats = new List<String>();
                foreach (String form in formats)
                {
                    f.Formats.Add(form);
                }
            }
            if (alignments != null)
            {
                f.Alignments = new System.Collections.Generic.List<string>();
                foreach (String align in alignments)
                {
                    f.Alignments.Add(align);
                }
            }
            f.LineColor = linecolor;
            return f.Write(d);
        }
        public static int ColumnCountDelimited(String strFile, Char limit)
        {
            try
            {
                int t = 0;
                System.IO.StreamReader sr = new System.IO.StreamReader(strFile);
                string input;
                int r = 0;
                int cols = 0;
                while ((input = sr.ReadLine()) != null)
                {
                    String[] a = SplitDelimitedLine(input, -1, limit, ref cols);
                    if (cols > t)
                        t = cols;
                    r++;
                    if (r > 50)
                        break;
                }
                sr.Close();
                sr = null;
                return t;
            }
            catch
            {
                return 0;
            }
        }
        public static String[] SplitDelimitedLine(String s, int cols, Char limit, ref int rcols)
        {
            Char[] chars = s.ToCharArray();
            bool bq = false;
            int bound = 50;
            if (cols > -1)
                bound = cols;
            String[] r = new String[bound];
            int col = 0;
            String temp = "";
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '\"':
                        bq = !bq;
                        break;
                    default:
                        if (chars[i] == limit && !bq)
                        {
                            r[col] = temp;
                            temp = "";
                            col++;
                            if (col >= bound)
                            {
                                rcols = col + 1;
                                return r;
                            }
                        }
                        else
                        {
                            temp += chars[i].ToString();
                        }
                        break;
                }
            }
            rcols = col + 1;
            r[col] = temp;
            return r;
        }
        //Public Abstract Functions
        public abstract void Shrink();
        public abstract void Backup(ref String strFile);
        public abstract bool Reindex();
        public abstract bool ReindexTable(String table);
        public abstract bool ViewIs(String table);
        public abstract bool FieldsExist(String table, String[] fields);
        public abstract DbConnection ConnectionGet();
        public abstract DbCommand CommandGet(String sql, DbConnection con);
        public abstract DbDataAdapter AdapterGet();
        public abstract bool TableExists(String table);
        public abstract bool StoredProcedureExists(String table);
        public abstract String SyntaxFilter(String s);        
        public abstract String DatabaseCreateSql(Key key);
        public abstract DataConnection MasterConnection
        {
            get;
        }
        public abstract ServerType GetServerType();
        public abstract ArrayList GetFieldArray(String table);

        public abstract bool DatabaseExists(String db);
        public abstract bool IsDateField(String table, String field);
        public abstract bool IsTextField(String table, String field);
        public abstract bool IsDecimalField(String table, String field);
        public abstract String ConnectionStringGet(bool skipProvider);

        public abstract void SetBlob(String table, String field, String where, Byte[] bytes);
        public abstract Byte[] GetBlob(String table, String field, String where);

        //Public Virtual Functions
        public virtual String FieldTypeSpec(Field f)
        {
            switch (f.Type)
            {
                case FieldType.DateTime:
                    return "datetime";
                case FieldType.Double:
                    return "float";
                //switch (f.ValueUse)
                //{
                //    case ValueUse.TotalMoney:
                //        return "decimal(26,2)";
                //    case ValueUse.UnitMoney:
                //    default:
                //        return "decimal(26,6)";
                //}
                case FieldType.Boolean:
                    return "bit";
                case FieldType.Text:
                    return "text";
                //case FieldType.List:
                //    return "varchar(255)";
                case FieldType.Blob:
                    return "image";
                case FieldType.Int32:
                case FieldType.Int64:
                    return "int";
                case FieldType.String:
                default:
                    if (f.Length > 0)
                        return "varchar(" + f.Length.ToString() + ")";
                    else
                    {
                        return "varchar(4096)";
                    }
            }
        }
        //Public Functions
        public bool Init(Key key)
        {
            TheKey = key;
            ConnectionStringSet();
            return true;
        }

        public void FieldsAdd(String table, List<Field> fields)
        {
            if (fields.Count == 0)
                return;

            List<String> specs = new List<string>();
            foreach (Field f in fields)
            {
                specs.Add(FieldSpec(f));
            }

            Execute("alter table [" + table + "] add " + Tools.Strings.CommaSeparateBlanksIgnore(specs));
        }

        public void FieldMakeExist(String table, Field field)
        {
            if (FieldExists(table, field.Name))
                return;
            Execute(String.Concat("alter table [", table, "] add ", FieldSpec(field)));
        }
        public String FieldSpec(List<Field> fields)
        {
            String[] specs = new String[fields.Count];
            int x = 0;
            foreach (Field f in fields)
            {
                specs[x] = FieldSpec(f);
                x++;
            }
            return Tools.Strings.CommaSeparateBlanksIgnore(specs);
        }
        public string FieldName(Field f)
        {
            if (!Tools.Strings.StrExt(f.Name))
                return "";
            return "[" + f.Name + "]";
        }
        //KT 4-19-2016 - Field Names for MySQL
        public string FieldNameMy(Field f)
        {
            if (!Tools.Strings.StrExt(f.Name))
                return "";
            return f.Name;

        }

        public List<String> GetFieldNameListLowerCase(String table)
        {
            List<String> ret = new List<string>();
            foreach (String n in GetFieldArray(table))
            {
                ret.Add(n.ToLower());
            }
            return ret;
        }

        public bool ConnectPossible(ref String err)
        {
            try
            {
                DbConnection d = ConnectionGetOpen(false);
                if (d == null)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public bool ConnectPossible()
        {
            String err = "";
            return ConnectPossible(ref err);
        }

        public void DatabaseCreate(Key key)
        {
            String s = DatabaseCreateSql(key);
            try
            {
                Execute(s);
                return;
            }
            catch { }
            DataConnection master = MasterConnection;
            if (master == null)
                throw new Exception("No master connection");
            master.Execute(s);
        }
        public DataSet SelectSet(string sql, bool FailOK = false)
        {
            DbConnection xConnect = ConnectionGetOpen(FailOK);
            if (xConnect == null)
                return null;
            DbCommand cmd = null;
            DbDataAdapter adp = null;
            try
            {
                cmd = CommandGet(sql, xConnect);
                cmd.CommandTimeout = TimeOutDefault;
                adp = AdapterGet();
                DataSet rst = new DataSet();
                adp.SelectCommand = cmd;
                adp.Fill(rst, "x");
                adp.Dispose();
                adp = null;
                cmd.Dispose();
                cmd = null;
                xConnect.Close();
                xConnect = null;
                if (rst == null)
                    return null;
                else
                    return rst;
            }
            catch (Exception e)
            {
                if (adp != null)
                {
                    adp.Dispose();
                    adp = null;
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
                xConnect.Close();
                xConnect = null;
                if (!FailOK)
                {
                    if (!Tools.Strings.StrCmp(e.Message, "thread was being aborted."))
                        throw new Exception(String.Concat("SQL Failed: \r\n\r\n", e.Message, "\r\n\r\n", sql));
                    throw e;
                }
                return null;
            }
        }
        public DataTable Select(string sql, bool FailOK = false)
        {
            DataSet d = SelectSet(sql, FailOK);
            if (d == null)
                return null;
            try { return d.Tables[0]; }
            catch { return null; }
        }

        public void Execute(string sql, bool FailOK = false)
        {
            long l = 0;
            Execute(sql, ref l, FailOK);
        }

        public void Execute(string sql, ref long affected, bool FailOK = false)
        {
            DbConnection xConnect = ConnectionGetOpen(FailOK);
            if (xConnect == null)
                throw new Exception("Execute: xConnect == null");
            if (xConnect.State == ConnectionState.Open)
            {
                DbCommand oCmd = CommandGet(sql, xConnect);
                oCmd.CommandTimeout = TimeOutDefault;
                try
                {
                    affected = oCmd.ExecuteNonQuery();
                    oCmd.Dispose();
                    oCmd = null;
                    xConnect.Close();
                    xConnect = null;
                }
                catch (Exception e)
                {
                    affected = 0;
                    if (!FailOK)
                    {
                        oCmd.Dispose();
                        oCmd = null;
                        xConnect.Close();
                        xConnect = null;
                        throw new Exception("SQL Error: " + e.Message + "\r\n\r\n\r\n" + sql);
                    }
                    else
                    {
                        oCmd.Dispose();
                        oCmd = null;
                        xConnect.Close();
                        xConnect = null;
                        affected = 0;
                    }
                }
            }
            else
            {
                affected = 0;
                if (!FailOK)
                    throw new Exception("Execute: ConnectionState is not Open");
            }
        }

        public virtual void ExecuteTransaction(String sql)
        {
            throw new NotImplementedException("Execute transaction not implemented");
        }

        public String FieldValue(FieldValue f)
        {
            try
            {
                switch (f.Type)
                {
                    case FieldType.DateTime:  //this needs to be overridden for MySql, right?
                        if (f.NullIs)
                            return "'" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(Tools.Dates.NullDate) + "'";
                        else
                            return "'" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings((DateTime)f.Value) + "'";
                    case FieldType.Int32:
                    case FieldType.Int64:
                        if (f.NullIs)
                            return "0";
                        else
                            return f.Value.ToString();
                    case FieldType.Double:
                        if (f.NullIs)
                            return "0";
                        else
                            return ((Double)f.Value).ToString("R");
                    case FieldType.Boolean:
                        if (f.NullIs)
                            return "0";
                        else if ((bool)f.Value)
                            return "1";
                        else
                            return "0";
                    default:
                        if (f.NullIs)
                            return "''";
                        else
                            return "'" + SyntaxFilter(f.Value.ToString()) + "'";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String FieldValueMy(FieldValue f)
        {
            try
            {
                switch (f.Type)
                {
                    case FieldType.DateTime:  //this needs to be overridden for MySql, right?
                        if (f.NullIs)
                            return "'" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(Tools.Dates.NullDate) + "'";
                        else
                        //return "'" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings((DateTime)f.Value) + "'";
                        {
                            DateTime n = (DateTime)f.Value;
                            string m = n.ToString("yyyy-MM-dd HH:mm:ss");
                            return "'"+m+"'";
                            
                        }
                            
                    case FieldType.Int32:
                    case FieldType.Int64:
                        if (f.NullIs)
                            return "0";
                        else
                            return f.Value.ToString();
                    case FieldType.Double:
                        if (f.NullIs)
                            return "0";
                        else
                            return ((Double)f.Value).ToString("R");
                    case FieldType.Boolean:
                        if (f.NullIs)
                            return "0";
                        else if ((bool)f.Value)
                            return "1";
                        else
                            return "0";
                    default:
                        if (f.NullIs)
                            return "''";
                        else
                            return "'" + SyntaxFilter(f.Value.ToString()) + "'";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Key GetDatabaseKey(string db)
        {
            Key k = new Key();
            k.DatabaseName = db;
            k.ServerName = TheKey.ServerName;
            k.UserName = TheKey.UserName;
            k.UserPassword = TheKey.UserPassword;
            k.FolderPath = TheKey.FolderPath;
            return k;
        }
        public bool Execute(String strSQL, ref long affected, bool failok, bool hidemessage, ref String message)
        {
            try
            {
                Execute(strSQL, ref affected, failok);
                return true;
            }
            catch (Exception e)
            {
                if (!failok)
                {
                    if (hidemessage)
                        message = e.Message;
                    else
                        throw e;
                }
                return false;
            }
        }
        public bool ExecuteHandled(String sql)  //i had a lot of code that used this format
        {
            try
            {
                Execute(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public long Execute(string sql)
        {
            long a = 0;
            Execute(sql, ref a);
            return a;
        }
        public void ExecuteAsync(string sql, string descr, bool FailOK = false)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ExecuteAsyncHandler));
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start(new ExecutionArgsAsync(sql, descr, FailOK));
        }
        public void ExecuteAsyncHandler(Object a)
        {
            try
            {
                ExecutionArgsAsync args = (ExecutionArgsAsync)a;
                long l = 0;
                Execute(args.strSQL, ref l, args.FailOK);
            }
            catch (Exception) { }
        }
        public DbConnection ConnectionGetOpen(bool failok = false)
        {
            DbConnection xConnect;
            try
            {
                xConnect = ConnectionGet();
                xConnect.Open();
                return xConnect;
            }
            catch (Exception e)
            {
                if (!failok)
                {
                    if (!Tools.Strings.HasString(e.Message, "thread was being aborted") && !Tools.Strings.HasString(e.Message, "Login timeout expired"))
                        throw e;
                }
                return null;
            }
        }

        //"select pe= '" + this.unique_id + "' order by line_code", file, ref l
        public void ExportCSV(String sql, String file, ref long lineCount)
        {
            ExportCSV(Select(sql), file, ref lineCount);
        }
        public void ExportCSV(String strSQL, String strFile, bool generate_header = false, String header = "", bool tab_delimited = false)
        {
            DataTable d = Select(strSQL);
            if (d == null)
                throw new Exception("ExportCSV: datatable == null");
            long a = 0;
            ExportCSV(d, strFile, ref a, generate_header, header, tab_delimited);
        }
        public void ExportCSV(DataTable d, String strFile, ref long affected, bool generate_header = false, String header = "", bool tab_delimited = false, bool noQuotes = false)
        {
            try
            {
                if (!Tools.Strings.StrExt(strFile))
                    strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "Export_" + Tools.Strings.GetNewID() + ".csv";

                System.IO.StreamWriter file = new System.IO.StreamWriter(strFile, false);
                affected = WriteDelimited(d, header, null, file, generate_header, tab_delimited, noQuotes);
                file.Close();
                file = null;
            }
            catch (Exception ex)
            {
                affected = 0;
                throw ex;
            }
        }

        


        public void TableCreate(String table, List<Field> fields)
        {
            if (TableExists(table))
                return;

            Execute("create table [" + table + "] ( " + FieldSpec(MakeUniqueFieldList(fields)) + " )");
        }

        static List<Field> MakeUniqueFieldList(List<Field> listIn)
        {
            List<Field> listOut = new List<Field>();
            List<String> namesIncluded = new List<string>();
            foreach (Field f in listIn)
            {
                if (namesIncluded.Contains(f.Name.ToLower()))
                    continue;

                listOut.Add(f);
                namesIncluded.Add(f.Name.ToLower());
            }
            return listOut;
        }

        public bool FieldExists(String table, String field)
        {
            return FieldsExist(table, new String[] { "[" + field + "]" });
        }
        public bool StatementPasses(String sql)
        {
            DataTable t = Select(sql, true);
            return (t != null);
        }
        public bool StatementExists(String sql)
        {
            DataTable t = Select(sql, true);
            return Tools.Data.DataTableExists(t);
        }
        public object GetBlankValue(FieldType type)
        {
            switch (type)
            {
                case FieldType.String:
                case FieldType.Text:
                    //case FieldType.List:
                    return (Object)"";
                case FieldType.Boolean:
                    return (Object)false;
                case FieldType.Int32:
                    return (Object)(Int32)0;
                case FieldType.Int64:
                    return (Object)(Int64)0;
                case FieldType.Double:
                    return (Object)(Double)0;
                case FieldType.DateTime:
                    return Tools.Dates.GetBlankDate();
                default:
                    throw new Exception("Invalid field type");
            }
        }
        public Object Scalar(String sql)
        {
            DataTable rst = Select(sql, true);
            try
            {
                return rst.Rows[0][0];
            }
            catch
            {
                return null;
            }
        }
        public String ScalarString(String sql, string s = "")
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToString(x);
            }
            catch
            {
                return s;
            }
        }
        public Int32 ScalarInt32(String sql, Int32 i = 0)
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToInt32(x);
            }
            catch
            {
                return Convert.ToInt32(i);
            }
        }
        public Int64 ScalarInt64(String sql, Int64 i = 0)
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToInt64(x);
            }
            catch
            {
                return Convert.ToInt64(i);
            }
        }
        public Double ScalarDouble(String sql, Double d = 0)
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToDouble(x);
            }
            catch
            {
                return Convert.ToDouble(d);
            }
        }
        public Boolean ScalarBoolean(String sql, Boolean b = false)
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToBoolean(x);
            }
            catch
            {
                return Convert.ToBoolean(b);
            }
        }
        public DateTime ScalarDateTime(String sql)
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToDateTime(x);
            }
            catch
            {
                return Convert.ToDateTime(Tools.Dates.GetBlankDate());
            }
        }
        public DateTime ScalarDateTime(String sql, DateTime d)
        {
            Object x = Scalar(sql);
            try
            {
                return Convert.ToDateTime(x);
            }
            catch
            {
                return Convert.ToDateTime(d);
            }
        }

        public Object Scalar(String sql, FieldType type)
        {
            try
            {
                switch (type)
                {
                    case FieldType.String:
                    case FieldType.Text:
                        return ScalarString(sql, "");
                    case FieldType.Boolean:
                        return ScalarBoolean(sql, false);
                    case FieldType.Int32:
                        return ScalarInt32(sql, (Int32)0);
                    case FieldType.Int64:
                        return ScalarInt64(sql, (long)0);
                    case FieldType.Double:
                        return ScalarDouble(sql, (Double)0);
                    case FieldType.DateTime:
                        return ScalarDateTime(sql, Tools.Dates.NullDate);
                    default:
                        return "";
                }
            }
            catch
            {
                return GetBlankValue(type);
            }
        }

        public bool FieldsMakeExist(String table, List<Field> fields)
        {
            List<String> existingFieldNames = GetFieldNameListLowerCase(table);
            List<Field> fieldsToAdd = new List<Field>();

            foreach (Field f in fields)
            {
                if (existingFieldNames.Contains(f.Name.ToLower()))
                    continue;

                fieldsToAdd.Add(f);
            }

            FieldsAdd(table, MakeUniqueFieldList(fieldsToAdd));

            return true;
        }
        public String FieldSpec(Field f)
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(FieldName(f));
            ret.Append(" ");
            ret.Append(FieldTypeSpec(f));
            return ret.ToString();
        }
        public String FieldValueRenderEquals(FieldValue v)
        {
            StringBuilder sb = new StringBuilder();
            //KT 4-18-2016 - FieldName is a method that appends the T-SQL only Brackets.
            sb.Append(FieldName(v));
            sb.Append(" = ");
            sb.Append(FieldValue(v));
            return sb.ToString();
        }

        public String FieldValueRenderEqualsMy(FieldValue v)
        {
            StringBuilder sb = new StringBuilder();
            //KT 4-18-2016 - FieldName is a method that appends the T-SQL only Brackets.
            sb.Append(v.Name);
            sb.Append(" = ");
            sb.Append(FieldValueMy(v));
            return sb.ToString();
        }
        public long GetDataSizeK()
        {
            return ScalarInt64("select max(size * 8) from sysfiles where fileid = 1");
        }
        public long GetDataSizeBytes()
        {
            return ScalarInt64("select max(size * 8 * 1024) from sysfiles where fileid = 1");
        }
        public long GetLogSizeK()
        {
            return ScalarInt64("select max(size * 8) from sysfiles where fileid = 2");
        }
        public long GetLogSizeBytes()
        {
            return ScalarInt64("select max(size * 8 * 1024) from sysfiles where fileid = 2");
        }
        public void DropTable(String strTable)
        {
            Execute("drop table " + strTable);
        }
        public String ConvertSQLToHTML(String strSQL, ArrayList formats = null, ArrayList alignments = null, String linecolor = "", bool wrap = false)
        {
            return ConvertDataTableToHTML(Select(strSQL), formats, alignments, linecolor, wrap);
        }
        public bool CheckNotifyConnect()
        {
            try
            {
                ConnectPossible();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool ImportDataTable(DataTable d, String strTable, bool silent = false, int[] lens = null, bool existing = false, int abs_len = -1)
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
                    return true;
                }
                catch (Exception ex2)
                {
                    if (!silent)
                        throw new Exception(strStatus + ex2.Message);
                    return false;
                }
            }
        }
        public bool ImportDelimitedFileToTable(String strFile, Char limit, ref String strTable)
        {
            String strStatus = "";
            try
            {
                int cols = ColumnCountDelimited(strFile, limit);
                if (cols == 0)
                {
                    try
                    {
                        using (System.IO.StreamReader srx = new System.IO.StreamReader(strFile))
                        {
                        }
                    }
                    catch
                    {
                        throw new Exception(strFile + " is locked by another process");
                    }
                    throw new Exception("No columns were found in the file");
                }
                DataTable dt = new DataTable();
                DataColumn dc;
                DataRow dr;
                if (!Tools.Strings.StrExt(strTable))
                    strTable = "temp_" + Tools.Strings.GetNewID();
                try
                {
                    Execute("create table " + strTable + " (column_0 varchar(8000))");
                }
                catch { return false; }
                for (int i = 0; i < cols; i++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.MaxLength = 8000;
                    dc.ColumnName = "column_" + i.ToString();
                    dc.Unique = false;
                    dt.Columns.Add(dc);
                    if (i > 0)
                    {
                        try
                        {
                            Execute("alter table " + strTable + " add " + dc.ColumnName + " varchar(8000)");
                        }
                        catch { return false; }
                    }
                }
                int x = 0;
                System.IO.StreamReader sr = new System.IO.StreamReader(strFile);
                string input;
                while ((input = sr.ReadLine()) != null)
                {
                    if (!Tools.Strings.StrExt(input))
                        continue;
                    string[] s = SplitDelimitedLine(input, cols, limit, ref x);
                    dr = dt.NewRow();
                    for (int i = 0; i < cols; i++)
                    {
                        try { dr[i] = s[i]; }
                        catch { }
                    }
                    dt.Rows.Add(dr);
                }
                sr.Close();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(ConnectionStringGet(true), SqlBulkCopyOptions.TableLock);
                bulkCopy.BulkCopyTimeout = 3600;  //1 hour?
                bulkCopy.DestinationTableName = "dbo." + strTable;
                bulkCopy.WriteToServer(dt);
                bulkCopy.Close();
                bulkCopy = null;
                dt = null;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool IsDefinitelySameTable(String strTable, DataConnection xd, String extra_field = "")
        {
            if (Tools.Strings.StrCmp(TheKey.ServerName + "_-_" + TheKey.DatabaseName, xd.TheKey.ServerName + "_-_" + xd.TheKey.DatabaseName))
                return true;
            String strID = Tools.Strings.GetNewID();
            String strSQL = "";
            if (Tools.Strings.StrExt(extra_field))
                strSQL = "insert into " + strTable + " (unique_id, " + extra_field + ") values ('" + strID + "', 'whatever')";
            else
                strSQL = "insert into " + strTable + " (unique_id) values ('" + strID + "')";
            Execute(strSQL);
            strSQL = "select count(*) from " + strTable + " where unique_id = '" + strID + "'";
            bool b = false;
            if (!xd.TableExists(strTable))
            {
                strSQL = "delete from " + strTable + " where unique_id = '" + strID + "'";
                Execute(strSQL);
                return false;
            }
            if (xd.ScalarInt64(strSQL) > 0)
                b = true;
            strSQL = "delete from " + strTable + " where unique_id = '" + strID + "'";
            Execute(strSQL);
            return b;
        }
        public string GetFriendlyName()
        {
            return "Server: " + TheKey.ServerName + "\r\n" + "Database: " + TheKey.DatabaseName;
        }
        public void ConnectionStringSet()
        {
            ConnectionString = ConnectionStringGet(false);
        }
        //KT 5-4-2016 - Added this variation so I can pass skipProvider.
        public void ConnectionStringSet(bool skipProvider)
        {
            ConnectionString = ConnectionStringGet(skipProvider);
        }
        //Private Functions
        private int WriteDelimited(DataTable d, String header, StringBuilder sb, System.IO.StreamWriter file, bool generate_header = false, bool tab_delimited = false, bool noQuotes = false)
        {
            int i = 0;
            string delimit = ",";
            string quote = "\"";
            if (noQuotes)
                quote = "";
            if (tab_delimited)
                delimit = "\t";
            if (generate_header && !Tools.Strings.StrExt(header))
            {
                foreach (DataColumn c in d.Columns)
                {
                    if (header != "")
                        header += delimit;
                    header += quote + Tools.Strings.NiceFormat(c.Caption) + quote;
                }
            }
            if (Tools.Strings.StrExt(header))
            {
                if (file != null)
                    file.Write(header + "\r\n");
                if (sb != null)
                    sb.Append(header + "\r\n");
            }
            int j = 0;
            foreach (DataRow r in d.Rows)
            {
                i = 0;
                foreach (DataColumn c in d.Columns)
                {
                    if (i != 0)
                    {
                        if (file != null)
                            file.Write(delimit);
                        if (sb != null)
                            sb.Append(delimit);
                    }
                    String s = "";
                    Object x = r[i];
                    if (x != null && x != System.DBNull.Value)
                    {
                        if (c.DataType.Name == "DateTime")
                        {
                            try
                            {
                                if (Tools.Dates.DateExists((DateTime)x))
                                    s = Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings((DateTime)x);
                            }
                            catch { }
                        }
                        else if (c.DataType.Name == "Boolean")
                            s = Tools.Strings.YesBlankFilter((bool)x);
                        else
                            s = x.ToString().Replace('\"', ' ').Replace('\r', ' ').Replace('\n', ' ');
                    }
                    if (file != null)
                        file.Write(quote + s + quote);
                    if (sb != null)
                        sb.Append(quote + s + quote);
                    i++;
                }
                j++;
                if (file != null)
                    file.Write("\r\n");
                if (sb != null)
                    sb.Append("\r\n");
            }
            return j;
        }

        public ArrayList ScalarArray(String sql)
        {
            ArrayList a = new ArrayList();
            DataTable d = Select(sql);
            if (d == null)
                return a;
            if (d.Rows.Count <= 0)
                return a;
            foreach (DataRow r in d.Rows)
            {
                try { a.Add((String)r[0]); }
                catch { }
            }
            return a;
        }

        public List<String> ScalarList(String sql)
        {
            List<String> a = new List<String>();
            DataTable d = Select(sql);
            if (d == null)
                return a;
            if (d.Rows.Count <= 0)
                return a;
            foreach (DataRow r in d.Rows)
            {
                try { a.Add((String)r[0]); }
                catch { }
            }
            return a;
        }

        public List<Object> ScalarListObjectExcludeNull(String sql)
        {
            List<Object> a = new List<Object>();
            DataTable d = Select(sql);
            if (d == null)
                return a;
            if (d.Rows.Count <= 0)
                return a;
            foreach (DataRow r in d.Rows)
            {
                try
                {
                    Object x = r[0];
                    if (x == null || x == DBNull.Value)
                        continue;

                    a.Add(x);
                }
                catch { }
            }
            return a;
        }

        public ArrayList ScalarArray_Integer(String sql)
        {
            ArrayList a = new ArrayList();
            DataTable d = Select(sql);
            if (d == null)
                return a;
            if (d.Rows.Count <= 0)
                return a;
            foreach (DataRow r in d.Rows)
            {
                try { a.Add(Tools.Data.NullFilterIntegerFromIntOrLong(r[0])); }
                catch { }
            }
            return a;
        }

        public virtual bool RenameTable(String strTable, String strNew)
        {
            throw new NotImplementedException();
        }

        public virtual void RenameField(String table, String fieldFrom, String fieldTo)
        {
            throw new NotImplementedException();
        }
    }

    //public class DataConnectionSqlMy : DataConnection
    //{
    //    public DataConnectionSqlMy()
    //    {
    //    }

    //    public DataConnectionSqlMy(String server, String database, String user, String password)
    //    {
    //        TheKey = new Key();
    //        TheKey.ServerName = server;
    //        TheKey.DatabaseName = database;
    //        TheKey.UserName = user;
    //        TheKey.UserPassword = password;
    //        ConnectionStringSet();
    //    }


    //    //KT 4-14-2016 - Implementing Missing Methods from DatConnectionSqlServer.cs to support MySql
    //    public Int32 GetScalar_Integer(String strSQL)
    //    {
    //        return ScalarInt32(strSQL);
    //    }


    //    public String DatabaseName
    //    {
    //        get
    //        {
    //            return TheKey.DatabaseName;
    //        }
    //    }


    //    public ArrayList GetScalarArray(String strSQL)
    //    {
    //        return GetScalarArray(strSQL, false);
    //    }

    //    public ArrayList GetScalarArray(String strSQL, bool hidemessage)
    //    {
    //        return ScalarArray(strSQL);
    //    }

    //    public Int64 GetScalar_Long(String strSQL)
    //    {
    //        return ScalarInt64(strSQL);
    //    }
    //    public Int64 GetScalar_Long(String strSQL, bool failok, bool hidemsg, ref string msg)
    //    {
    //        return ScalarInt64(strSQL);
    //    }

    //    //End KT 4-14-2016
    //    public static String DateFormat(DateTime dt)
    //    {
    //        return dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
    //    }

    //    public override string ConnectionStringGet(bool skipProvider)
    //    {
    //        return "Driver={MySQL ODBC 3.51 Driver};Server=" + TheKey.ServerName + ";Port=3306;Option=131072;Stmt=;Database=" + TheKey.DatabaseName + ";Uid=" + TheKey.UserName + ";Pwd=" + TheKey.UserPassword + ";Connection Timeout = 10";
    //        //return "Driver={MySQL ODBC 5.1 Driver};Server=" + server_name + ";Port=3306;Option=131072;Stmt=;Database=" + database_name + ";Uid=" + user_name + ";Pwd=" + user_password + ";Connection Timeout = 10";
    //    }

    //    public override bool FieldsExist(string table, string[] fields)
    //    {
    //        return StatementPasses("select " + Tools.Strings.CommaSeparateBlanksIgnore(fields) + " from " + table + " limit 1");
    //    }
    //    public override DbConnection ConnectionGet()
    //    {
    //        return new OdbcConnection(ConnectionString);
    //    }
    //    public override DbCommand CommandGet(string sql, DbConnection con)
    //    {
    //        return new OdbcCommand(sql, (OdbcConnection)con);
    //    }
    //    public override DbDataAdapter AdapterGet()
    //    {
    //        return new OdbcDataAdapter();
    //    }
    //    public override string SyntaxFilter(string s)
    //    {
    //        return s.Replace("\\", "\\\\").Replace("'", "\'\'");
    //    }
    //    public override ServerType GetServerType()
    //    {
    //        return ServerType.SqlMy;
    //    }
    //    public override void Backup(ref String strFile)
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: Backup is not implemented");
    //    }
    //    public override void Shrink()
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: Shrink is not implemented");
    //    }
    //    public override bool Reindex()
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: Reindex is not implemented");
    //    }
    //    public override bool ReindexTable(String table)
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: ReindexTable is not implemented");
    //    }
    //    public override bool ViewIs(string table)
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: ViewIs is not implemented");
    //    }
    //    public override bool TableExists(string table)
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: TableExists is not implemented");
    //    }
    //    public override bool StoredProcedureExists(string table)
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: StoredProcedureExists is not implemented");
    //    }
    //    public override string DatabaseCreateSql(Key key)
    //    {
    //        throw new NotImplementedException("DataConnectionSqlMy: DatabaseCreateSql is not implemented");
    //    }
    //    public override DataConnection MasterConnection
    //    {
    //        get
    //        {
    //            throw new NotImplementedException("DataConnectionSqlMy: MasterConnection is not implemented");
    //        }
    //    }
    //    public override ArrayList GetFieldArray(String table)
    //    {
    //        ArrayList a = new ArrayList();
    //        DataTable t = Select("select * from " + table + " limit 1");
    //        if (t == null)
    //            return a;
    //        for (int i = 0; i < t.Columns.Count; i++)
    //            a.Add(t.Columns[i].ColumnName);
    //        return a;
    //    }
    //    public override bool DatabaseExists(String db)
    //    {
    //        if (!Tools.Strings.StrExt(db))
    //            return false;
    //        DataConnectionSqlMy d = new DataConnectionSqlMy();
    //        d.Init(GetDatabaseKey(db));
    //        return d.ConnectPossible();
    //    }
    //    public override bool IsDateField(String table, String field)
    //    {
    //        DataTable d = Select("select " + field + " from " + table + " limit 1");
    //        if (d == null)
    //            return false;
    //        DataColumn c = d.Columns[0];
    //        return (c.DataType == System.Type.GetType("System.DateTime"));
    //    }
    //    public override bool IsTextField(String table, String field)
    //    {
    //        DataTable d = Select("select " + field + " from " + table + " limit 1");
    //        if (d == null)
    //            return false;
    //        DataColumn c = d.Columns[0];
    //        return (c.DataType == System.Type.GetType("System.String"));
    //    }
    //    public override bool IsDecimalField(String table, String field)
    //    {
    //        DataTable d = Select("select " + field + " from " + table + " limit 1");
    //        if (d == null)
    //            return false;
    //        DataColumn c = d.Columns[0];
    //        return (c.DataType == System.Type.GetType("System.Decimal"));
    //    }

    //    public override void SetBlob(string table, string field, string where, byte[] bytes)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override byte[] GetBlob(string table, string field, string where)
    //    {
    //        throw new NotImplementedException();
    //    }


    //}
    public class Key
    {
        public String ServerName = "";
        public String DatabaseName = "";
        public String UserName = "";
        public String UserPassword = "";
        public String FolderPath = "";

        public Key()
        {
        }
        public Key(Key key)
        {
            ServerName = key.ServerName;
            DatabaseName = key.DatabaseName;
            UserName = key.UserName;
            UserPassword = key.UserPassword;
            FolderPath = key.FolderPath;
        }
    }
    public class ExecutionArgsAsync
    {
        public string strSQL;
        public string strDescription;
        public bool FailOK = false;

        public ExecutionArgsAsync(string sql, string desc, bool failok)
        {
            strSQL = sql;
            FailOK = failok;
            strDescription = desc;
        }
    }
    public enum ServerType
    {
        SqlServer = 0,
        SqlMy = 1,
    }
    public enum FieldType
    {
        //String = 0,
        //Int32 = 1,
        //DateTime = 2,        
        //Double = 3,
        //Boolean = 4,
        //Int64 = 5,
        //Original NM Enums with original number assignments
        String = 1,
        Int32 = 2,
        Int64 = 3,
        Double = 4,
        DateTime = 5,
        Boolean = 6,
        Text = 7,
        //List = 8,
        Picture = 9,
        Document = 10,
        Object = 11,
        Blob = 12,
        Data = 13,
        SingleRef = 14,
        Unknown,
    }


    public class DataFormatter
    {
        //Public Variables
        public List<String> Formats;
        public List<String> Alignments;
        public int Border = 1;
        public int CellPadding = 1;
        public int CellSpacing = 1;
        public bool BoldCaptions = true;
        public String LineColor = "";
        public bool WrapText = false;
        //Protected Variables
        protected List<DataFormatterField> Fields;

        //Public Virtual Functions
        public virtual String CalcColor(DataRow r)
        {
            return LineColor;
        }
        //Public Functions
        public String Write(DataTable d)
        {
            StringBuilder sb = new StringBuilder();
            if (!Tools.Data.DataTableExists(d))
                return "<font color=red>No Data</font><br>";
            sb.Append("<table border=\"" + Border.ToString() + "\" cellpadding=\"" + CellPadding.ToString() + "\" cellspacing=\"" + CellSpacing.ToString() + "\"><tr>");
            if (Fields == null)
            {
                Fields = new List<DataFormatterField>();
                int ix = 0;
                foreach (DataColumn c in d.Columns)
                {
                    Fields.Add(new DataFormatterField(ix, c.Caption));
                    ix++;
                }
            }
            foreach (DataFormatterField f in Fields)
            {
                sb.Append("<td nowrap>");
                if (BoldCaptions)
                    sb.Append("<b>");
                sb.Append(f.Caption);
                if (BoldCaptions)
                    sb.Append("</b>");
                sb.Append("</td>");
            }
            sb.Append("</tr>");
            foreach (DataRow r in d.Rows)
            {
                String linecolor = CalcColor(r);
                sb.Append("<tr>");
                int i = 0;
                foreach (DataFormatterField f in Fields)
                {
                    String salign = "";
                    if (Alignments != null)
                    {
                        try { salign = Alignments[i]; }
                        catch { }
                    }
                    else
                        salign = f.Alignment;
                    String wraptext = "";
                    if (!WrapText)
                        wraptext = " nowrap";
                    if (salign == "")
                        sb.Append("<td" + wraptext + ">");
                    else
                        sb.Append("<td" + wraptext + " align=\"" + salign + "\">");
                    String sformat = "";
                    if (Formats != null)
                    {
                        try { sformat = Formats[i]; }
                        catch { }
                    }
                    else
                        sformat = f.Format;
                    Object o = null;
                    if (f.Index > -1)
                        o = r[f.Index];
                    else
                        o = r[f.Name];
                    if (o == null || o == System.DBNull.Value)
                        sb.Append("&nbsp;");
                    else
                    {
                        if (Tools.Strings.StrExt(linecolor))
                            sb.Append("<font color=\"" + linecolor + "\">");
                        if (sformat == "")
                        {
                            String raw = "";
                            if (o.GetType().Name == "DateTime")
                                raw = Tools.Dates.DateFormat((DateTime)o);
                            else if (o.GetType().Name == "Boolean")
                                raw = Tools.Strings.YesBlankFilter((Boolean)o);
                            else
                                raw = o.ToString();
                            if (WrapText)
                                raw = raw.Replace("\n", "<br>").Replace("\r", "");
                            else
                                raw = raw.Replace("\n", "&nbsp;").Replace("\r", "");
                            sb.Append(raw + "&nbsp;");
                        }
                        else
                            sb.Append(String.Format(sformat, o) + "&nbsp;");
                        if (Tools.Strings.StrExt(linecolor))
                            sb.Append("</font>");
                    }
                    sb.Append("</td>");
                    i++;
                }
                sb.Append("</tr>");
            }
            sb.Append("</table><br>");
            return sb.ToString();
        }
        //Protected Classes
        protected class DataFormatterField
        {
            //Public Variables
            public String Name = "";
            public int Index = -1;
            public String Caption = "";
            public String Alignment = "";
            public String Format = "";

            //Constructors
            public DataFormatterField(int index, String caption)
            {
                Index = index;
                Caption = caption;
            }
            public DataFormatterField(String name, String caption, String alignment, String format)
            {
                Name = name;
                Caption = caption;
                Alignment = alignment;
                Format = format;
            }
            public DataFormatterField(String name, String caption) : this(name, caption, "", "")
            {

            }

        }
    }
}
