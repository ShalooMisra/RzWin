//using System;
//using System.Collections;
//using System.Text;
//using System.Data;
//using System.Data.OleDb;
//using System.Data.Odbc;
//using System.Data.Sql;
//using System.Data.SqlClient;
//using System.Windows.Forms;
//using System.Threading;
//using System.IO;
//using NewMethodx.Enums;

//namespace NewMethodx
//{
//    namespace Enums
//    {
//        public enum DataType
//        {
//            Unknown = -1,
//            Any = 0,
//            String = 1,
//            Integer = 2,
//            Long = 3,
//            Float = 4,
//            Date = 5,
//            Boolean = 6,
//            Memo = 7,
//            List = 8,
//            Picture = 9,
//            Document = 10,
//            Object = 11,
//            Blob = 12,
//            Data = 13,
//        }
//        public enum DataUse
//        {
//            Unknown = -1,
//            Any = 0,
//            //string stuff
//            TableSplit = 1,
//            Email = 2,
//            Phone = 3,
//            Url = 4,
//            List = 5,
//            PersonName = 6,
//            FirstName = 7,
//            LastName = 8,
//            IPAddress = 9,
//        }
//    }
//    public partial class nData : n_data_target
//    {
//        //public static bool ShowAsyncWarnings = true;
//        //public static bool DataTableExists(DataTable d)
//        //{
//        //    if (d == null)
//        //        return false;

//        //    if (d.Rows.Count <= 0)
//        //        return false;

//        //    return true;
//        //}
//        private String ConnectionString;
//        public bool BigIntDisabled = false;
//        public bool VarcharMaxDisabled = false;
//        private System.Data.OleDb.OleDbConnection GetConnect()
//        {
//            String s = "";
//            return GetConnect(false, ref s);
//        }
//        private System.Data.OleDb.OleDbConnection GetConnect(bool failok)
//        {
//            String s = "";
//            return GetConnect(failok, ref s);
//        }
//        public void CheckBigIntDisabled()
//        {
//            if (!StatementPasses("select top 1 cast(1 as bigint) as test from sysobjects"))
//                BigIntDisabled = true;
//        }
//        public void CheckVarcahrMaxDisabled()
//        {
//            if (!StatementPasses("select top 1 cast(1 as varchar(max)) as test from sysobjects"))
//                VarcharMaxDisabled = true;
//        }
//        public String GetVarcharMax()
//        {
//            if (VarcharMaxDisabled)
//                return "varchar(255)";
//            else
//                return "varchar(max)";
//        }
//        private System.Data.OleDb.OleDbConnection GetConnect(bool failok, ref String s)
//        {
//            OleDbConnection xConnect;

//            try
//            {
//                xConnect = new OleDbConnection(ConnectionString);
//                xConnect.Open();
//                return xConnect;
//            }
//            catch (Exception e)
//            {
//                s = e.Message;
//                if (!failok)
//                {
//                    //if (!Tools.Strings.HasString(e.Message, "thread was being aborted"))
//                    //    context.TheLeader.Tell(e.Message);
//                }

//                return null;
//            }
//        }
//        private System.Data.Odbc.OdbcConnection GetConnect_Odbc(bool failok, ref String s)
//        {
//            OdbcConnection xConnect;

//            try
//            {
//                xConnect = new OdbcConnection(ConnectionString);
//                xConnect.Open();
//                return xConnect;
//            }
//            catch (Exception e)
//            {
//                s = e.Message;
//                if (!failok)
//                {
//                    //if (!Tools.Strings.HasString(e.Message, "thread was being aborted"))
//                    //    context.TheLeader.Tell(e.Message);
//                }

//                return null;
//            }
//        }
//        public void SetConnectionString()
//        {
//            ConnectionString = GetConnectionString();
//        }//??
//        public bool Execute(String strSQL)
//        {
//            long l = 0;
//            return Execute(strSQL, ref l, false, false);
//        }
//        public bool Execute(String strSQL, bool failok)
//        {
//            return Execute(strSQL, failok, false);
//        }
//        public bool Execute(String strSQL, bool failok, bool hidemessage)
//        {
//            long l = 0;
//            return Execute(strSQL, ref l, failok, hidemessage);
//        }
//        public bool Execute(String strSQL, bool failok, ref long count)
//        {
//            return Execute(strSQL, ref count, failok, false);
//        }
//        public bool Execute(String strSQL, ref long affected)
//        {
//            return Execute(strSQL, ref affected, false, false);
//        }
//        public void ExecuteAsync(String strSQL, bool show_warnings, String strDesc)
//        {
//            Thread t = new Thread(new ParameterizedThreadStart(ExecuteAsyncHandler));
//            t.SetApartmentState(ApartmentState.STA);
//            t.Start(new AsyncExecutionArgs(strSQL, show_warnings, strDesc));
//        }
//        public void ExecuteAsyncHandler(Object a)
//        {
//            AsyncExecutionArgs args = (AsyncExecutionArgs)a;
//            OleDbConnection xConnect = GetConnect();

//            if (xConnect == null)
//                return;

//            long affect;
//            if (xConnect.State == ConnectionState.Open)
//            {
//                OleDbCommand oCmd = new OleDbCommand(args.strSQL, xConnect);
//                oCmd.CommandTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                ////loop until it works or the user cancels
//                //while (true)
//                //{
//                try
//                {
//                    oCmd.ExecuteNonQuery();
//                }
//                catch (Exception ex)
//                {
//                    //if (args.show_warnings && nData.ShowAsyncWarnings)
//                    //{
//                    //    //if (!context.TheLeader.AskYesNo("An error occured while " + args.strDescription + " [" + ex.Message + "].  Do you want to continue seeing these messages?"))
//                    //    //{
//                    //    //    args.show_warnings = false;
//                    //    //    nData.ShowAsyncWarnings = false;
//                    //    //}
//                    //}
//                }
//                finally
//                {
//                    if (oCmd != null)
//                    {
//                        oCmd.Dispose();
//                        oCmd = null;
//                    }

//                    if (xConnect != null)
//                    {
//                        xConnect.Close();
//                        xConnect = null;
//                    }
//                }
//                //    break;
//                //}
//            }
//        }
//        public bool Execute(String strSQL, ref long affected, bool failok, bool hidemessage)
//        {
//            String s = "";
//            return Execute(strSQL, ref affected, failok, hidemessage, ref s);
//        }
//        public bool Execute(String strSQL, bool failok, bool hidemessage, ref String message)
//        {
//            String s = "";
//            long l = 0;
//            return Execute(strSQL, ref l, failok, hidemessage, ref message);
//        }
//        public bool Execute(String strSQL, ref long affected, bool failok, bool hidemessage, ref String message)
//        {
//            if (target_type == (Int32)Tools.Database.ServerType.SqlMy)
//                return Execute_Odbc(strSQL, ref affected, failok, hidemessage, ref message);

//            OleDbConnection xConnect = GetConnect();

//            if (xConnect == null)
//                return false;

//            long affect;
//            if (xConnect.State == ConnectionState.Open)
//            {
//                OleDbCommand oCmd = new OleDbCommand(strSQL, xConnect);
//                oCmd.CommandTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                //loop until it works or the user cancels
//                while (true)
//                {
//                    try
//                    {
//                        affect = oCmd.ExecuteNonQuery();

//                        oCmd.Dispose();
//                        oCmd = null;

//                        xConnect.Close();
//                        xConnect = null;

//                        break;
//                    }
//                    catch (Exception e)
//                    {
//                        message = e.Message;
//                        affected = 0;
//                        if (!failok)
//                        {
//                            if (!hidemessage)
//                            {
//                                try
//                                {
//                                    Clipboard.SetText(strSQL);
//                                }
//                                catch (Exception)
//                                { }
//                                //context.TheLeader.Tell("SQL Error: " + e.Message + "\r\n\r\n\r\n" + strSQL);
//                            }

//                            oCmd.Dispose();
//                            oCmd = null;

//                            xConnect.Close();
//                            xConnect = null;

//                            return false;
//                        }
//                        else
//                        {

//                            oCmd.Dispose();
//                            oCmd = null;

//                            xConnect.Close();
//                            xConnect = null;

//                            affected = 0;
//                            return true;  //still return false, just don't show the message?
//                        }
//                    }
//                }
//                affected = affect;
//                return true;
//            }
//            else
//            {
//                affected = 0;
//                return false;
//            }
//        }
//        public bool Execute_Odbc(String strSQL, ref long affected, bool failok, bool hidemessage, ref String message)
//        {
//            String s = "";
//            OdbcConnection xConnect = GetConnect_Odbc(failok, ref s);

//            if (xConnect == null)
//                return false;

//            long affect;
//            if (xConnect.State == ConnectionState.Open)
//            {
//                OdbcCommand oCmd = new OdbcCommand(strSQL, xConnect);
//                oCmd.CommandTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                //loop until it works or the user cancels
//                while (true)
//                {
//                    try
//                    {
//                        affect = oCmd.ExecuteNonQuery();

//                        oCmd.Dispose();
//                        oCmd = null;

//                        xConnect.Close();
//                        xConnect = null;

//                        break;
//                    }
//                    catch (Exception e)
//                    {
//                        message = e.Message;
//                        affected = 0;
//                        if (!failok)
//                        {
//                            ///nSQLContext* c = new nSQLContext();
//                            ///c->strSQL = strSQL;
//                            ///c->TryAgain = false;
//                            ///MySys->xStreams->HandleSQLException(MySys, e, c);
//                            ///if( !c->TryAgain )
//                            ///{
//                            ///    return false;
//                            ///    break;
//                            ///}
//                            ///strSQL = c->strSQL;
//                            ///
//                            if (!hidemessage)
//                                //context.TheLeader.Tell("SQL Error: " + e.Message);

//                                oCmd.Dispose();
//                            oCmd = null;

//                            xConnect.Close();
//                            xConnect = null;

//                            return false;
//                        }
//                        else
//                        {

//                            oCmd.Dispose();
//                            oCmd = null;

//                            xConnect.Close();
//                            xConnect = null;

//                            affected = 0;
//                            return true;
//                        }
//                    }
//                }
//                affected = affect;
//                return true;
//            }
//            else
//            {
//                affected = 0;
//                return false;
//            }
//        }
//        public DataTable GetDataTable(String strSQL)
//        {
//            return GetDataTable(strSQL, false);
//        }
//        public DateTime GetServerNow()
//        {
//            return System.DateTime.Now;
//        }
//        public bool DropTable(String strTable)
//        {
//            return Execute("drop table " + strTable, true);
//        }
//        public DataTable GetDataTable(String strSQL, bool FailOK)
//        {
//            return GetDataTable(strSQL, FailOK, false);
//        }
//        public DataTable GetDataTable(String strSQL, bool FailOK, bool hidemessage)
//        {
//            String s = "";
//            return GetDataTable(strSQL, FailOK, hidemessage, ref s);
//        }
//        public DataTable GetDataTable(String strSQL, bool FailOK, bool hidemessage, ref String strError)
//        {
//            if (target_type == (Int32)Tools.Database.ServerType.SqlMy)
//                return GetDataTable_Odbc(strSQL, FailOK);

//            if (Tools.Database.DataConnection.SimulateDelay)
//                System.Threading.Thread.Sleep(Tools.Number.GetRandomInteger(3000, 8000));

//            OleDbConnection xConnect = GetConnect();
//            if (xConnect == null)
//                return null;

//            OleDbCommand cmd = null;
//            OleDbDataAdapter adp = null;
//            try
//            {
//                cmd = new OleDbCommand(strSQL, xConnect);
//                cmd.CommandTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                adp = new OleDbDataAdapter();

//                DataSet rst = new DataSet();
//                adp.SelectCommand = cmd;
//                adp.Fill(rst, "x");

//                adp.Dispose();
//                adp = null;

//                cmd.Dispose();
//                cmd = null;

//                xConnect.Close();
//                xConnect = null;

//                return rst.Tables[0];
//            }
//            catch (Exception e)
//            {
//                strError = e.Message;

//                if (adp != null)
//                {
//                    adp.Dispose();
//                    adp = null;
//                }

//                if (cmd != null)
//                {
//                    cmd.Dispose();
//                    cmd = null;
//                }

//                xConnect.Close();
//                xConnect = null;

//                if (!FailOK)
//                {
//                    //if( MySys )
//                    //{
//                    //    MySys->xStreams->MsgBox(String::Concat(S"SQL Failed: \r\n\r\n", e->Message, S"\r\n\r\n", strSQL));
//                    //}
//                    //else
//                    //{
//                    if (!hidemessage)
//                    {
//                        //if (!Tools.Strings.StrCmp(e.Message, "thread was being aborted."))
//                        //context.TheLeader.Tell(String.Concat("SQL Failed: \r\n\r\n", e.Message, "\r\n\r\n", strSQL));
//                    }
//                    //}
//                }
//                return null;
//            }
//        }
//        public DataTable GetDataTable_Odbc(String strSQL, bool FailOK)
//        {
//            if (Tools.Database.DataConnection.SimulateDelay)
//                System.Threading.Thread.Sleep(Tools.Number.GetRandomInteger(3000, 8000));

//            String s = "";
//            OdbcConnection xConnect = GetConnect_Odbc(FailOK, ref s);
//            OdbcCommand cmd = null;
//            OdbcDataAdapter adp = null;
//            try
//            {
//                cmd = new OdbcCommand(strSQL, xConnect);
//                cmd.CommandTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                adp = new OdbcDataAdapter();

//                DataSet rst = new DataSet();
//                adp.SelectCommand = cmd;
//                adp.Fill(rst, "x");

//                adp.Dispose();
//                adp = null;

//                cmd.Dispose();
//                cmd = null;

//                xConnect.Close();
//                xConnect = null;

//                return rst.Tables[0];
//            }
//            catch (Exception e)
//            {
//                if (adp != null)
//                {
//                    adp.Dispose();
//                    adp = null;
//                }

//                if (cmd != null)
//                {
//                    cmd.Dispose();
//                    cmd = null;
//                }

//                xConnect.Close();
//                xConnect = null;

//                if (!FailOK)
//                {
//                    //if( MySys )
//                    //{
//                    //    MySys->xStreams->MsgBox(String::Concat(S"SQL Failed: \r\n\r\n", e->Message, S"\r\n\r\n", strSQL));
//                    //}
//                    //else
//                    //{
//                    //if (!Tools.Strings.StrCmp(e.Message, "thread was being aborted."))
//                    //    context.TheLeader.Tell(String.Concat("SQL Failed: \r\n\r\n", e.Message, "\r\n\r\n", strSQL));
//                    //}
//                }
//                return null;
//            }
//        }
//        public ArrayList GetFieldArray(String strTable)
//        {
//            ArrayList a = new ArrayList();
//            DataTable t = GetDataTable(String.Concat("select top 1 * from ", strTable));
//            if (t == null)
//                return a;
//            for (int i = 0; i < t.Columns.Count; i++)
//                a.Add(t.Columns[i].ColumnName);
//            return a;
//        }
//        public ArrayList GetTableArray()
//        {
//            ArrayList a = new ArrayList();
//            DataTable t = GetDataTable("select name from sysobjects where type = 'U' order by name");
//            if (t == null)
//                return a;
//            for (int i = 0; i < t.Rows.Count; i++)
//                a.Add(Convert.ToString(t.Rows[i][0]));
//            return a;
//        }
//        public bool StatementPasses(String str)
//        {
//            DataTable t = GetDataTable(str, true);
//            return (t != null);
//        }
//        public bool StatementExists(String str)
//        {
//            DataTable t = GetDataTable(str, true);
//            return Tools.Data.DataTableExists(t);
//        }
//        public bool TableExists(String strTable)
//        {
//            return StatementPasses(String.Concat("select top 1 * from ", strTable));
//        }
//        public bool FieldExists(String strTable, String strField)//?? I added for assistance with CheckCreateField
//        {
//            return StatementPasses(String.Concat("select top 1 ", strField, " from ", strTable));
//        }
//        public bool FieldExists(DataTable dt, String strField)//?? I added for assistance with CheckCreateField
//        {
//            try
//            {
//                if (!Tools.Strings.StrExt(strField))
//                    return false;
//                foreach (DataColumn dc in dt.Columns)
//                {
//                    if (Tools.Strings.StrCmp(dc.ColumnName, strField))
//                        return true;
//                }
//                return false;
//            }
//            catch (Exception)
//            { return false; }
//        }
//        public bool CanConnect()
//        {
//            String s = "";
//            return CanConnect(ref s);
//        }
//        public bool CanConnect(ref String s)
//        {
//            switch (this.target_type)
//            {
//                case (Int32)Tools.Database.ServerType.SqlMy:
//                    return CanConnect_Odbc(ref s);
//                default:
//                    return CanConnect_OleDb(ref s);
//            }
//        }
//        public bool CanConnect_OleDb(ref String s)
//        {
//            OleDbConnection xConnect = GetConnect(true, ref s);
//            if (xConnect == null)
//                return false;
//            return (xConnect.State == ConnectionState.Open);
//        }
//        public bool CanConnect_Odbc(ref String s)
//        {
//            OdbcConnection xConnect = GetConnect_Odbc(true, ref s);
//            if (xConnect == null)
//                return false;
//            return (xConnect.State == ConnectionState.Open);
//        }
//        public bool CreateDatabase(String strDatabase)
//        {
//            if (!Tools.Strings.StrExt(dDataPath))
//                dDataPath = "c:\\eternal\\data\\newmethod\\";

//            String s = "CREATE DATABASE " + strDatabase + "\r\n";
//            s = s + "ON\r\n";
//            s = s + "( NAME = " + strDatabase + "_data,\r\n";
//            s = s + "    FILENAME = '" + n_data_target.dDataPath + strDatabase + "_data.mdf',\r\n";
//            s = s + "    SIZE = 10,\r\n";
//            s = s + "    FILEGROWTH = 10% )\r\n";
//            s = s + "LOG ON\r\n";
//            s = s + "( NAME = " + strDatabase + "_log,\r\n";
//            s = s + "    FILENAME = '" + n_data_target.dDataPath + strDatabase + "_log.ldf',\r\n";
//            s = s + "    SIZE = 5MB,\r\n";
//            s = s + "    FILEGROWTH = 10% )\r\n";

//            if (Execute(s))
//                return true;
//            database_name = "master";
//            SetConnectionString();
//            if (!Execute(String.Concat("create database ", strDatabase)))
//                return false;
//            if (!Execute(String.Concat("use ", strDatabase)))
//                return false;
//            database_name = strDatabase;
//            SetConnectionString();
//            return true;
//        }
//        public bool RenameDatabase(String strNewName)
//        {
//            return Execute("alter database " + database_name + " MODIFY NAME = " + strNewName + " ");
//        }
//        public bool MakeTableExist(String strTable)
//        {
//            if (TableExists(strTable))
//                return true;
//            return Execute(String.Concat("create table ", strTable, " ( unique_id varchar(255), grid_color int, icon_index int ) "));
//        }
//        public bool MakeFieldExist(String strTable, String strField, Int32 t, Int32 length)
//        {
//            if (FieldExists(strTable, strField))
//                return true;
//            String str;
//            switch (t)
//            {
//                case (Int32)DataType.String:
//                    str = String.Concat("varchar(", length.ToString(), ")");
//                    break;
//                case (Int32)DataType.Memo:
//                    str = "text";
//                    break;
//                case (Int32)DataType.List:
//                    str = "varchar(255)";
//                    break;
//                case (Int32)DataType.Boolean:
//                    str = "bit";
//                    break;
//                case (Int32)DataType.Integer:
//                    str = "int";
//                    break;
//                case (Int32)DataType.Long:
//                    if (BigIntDisabled)
//                        str = "int";
//                    else
//                        str = "bigint";
//                    break;
//                case (Int32)DataType.Float:
//                    str = "float";
//                    break;
//                case (Int32)DataType.Date:
//                    str = "datetime";
//                    break;
//                case (Int32)DataType.Blob:
//                    str = "image";
//                    break;
//                default:
//                    return false;
//            }
//            return Execute(String.Concat("alter table ", strTable, " add ", strField, " ", str));
//        }
//        public Object GetScalar(String strSQL, DataType xType)
//        {
//            //DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                switch (xType)
//                {
//                    case DataType.String:
//                        return GetScalar(strSQL, "");
//                    case DataType.Memo:
//                        return GetScalar(strSQL, "");
//                    case DataType.List:
//                        return GetScalar(strSQL, "");
//                    case DataType.Boolean:
//                        return GetScalar(strSQL, false);
//                    case DataType.Integer:
//                        return GetScalar_Integer(strSQL);
//                    case DataType.Long:
//                        return GetScalar(strSQL, (long)0);
//                    case DataType.Float:
//                        return GetScalar(strSQL, (Double)0);
//                    case DataType.Date:
//                        return GetScalar(strSQL, Tools.Dates.GetBlankDate());
//                    default:
//                        return "";
//                }
//            }
//            catch (Exception e)
//            {
//                return GetBlankValue(xType);
//            }
//        }//Work on this one
//        public object GetBlankValue(Enums.DataType xType)
//        {
//            switch (xType)
//            {
//                case DataType.String:
//                    return (Object)"";
//                case DataType.Memo:
//                    return (Object)"";
//                case DataType.List:
//                    return (Object)"";
//                case DataType.Boolean:
//                    return (Object)false;
//                case DataType.Integer:
//                    return (Object)(int)0;
//                case DataType.Long:
//                    return (Object)(long)0;
//                case DataType.Float:
//                    return (Object)(Double)0;
//                case DataType.Date:
//                    return Tools.Dates.GetBlankDate();
//                default:
//                    return (Object)"";
//            }
//        }
//        public Int64 GetScalar(String strSQL, Int64 i)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToInt64(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return Convert.ToInt64(i);
//            }
//        }
//        public Int32 GetScalar_Integer(String strSQL)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToInt32(rst.Rows[0][0]);
//            }
//            catch
//            {
//                return Convert.ToInt32(0);
//            }
//        }
//        public Boolean GetScalar_Boolean(String strSQL)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToBoolean(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return false;
//            }
//        }
//        public String GetScalar_String(String strSQL)
//        {
//            return GetScalar(strSQL, "");
//        }
//        public Int64 GetScalar_Long(String strSQL)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToInt64(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return Convert.ToInt64(0);
//            }
//        }
//        public DateTime GetScalar_Date(String strSQL)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToDateTime(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return Tools.Dates.GetNullDate();
//            }
//        }
//        public Double GetScalar_Float(String strSQL)
//        {
//            return GetScalar_Float(strSQL, false);
//        }
//        public Double GetScalar_Float(String strSQL, bool failok)
//        {
//            DataTable rst = GetDataTable(strSQL, failok);
//            try
//            {
//                return Convert.ToDouble(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return Convert.ToDouble(0);
//            }
//        }
//        public Double GetScalar(String strSQL, Double d)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToDouble(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return Convert.ToDouble(d);
//            }
//        }
//        public String GetScalar(String strSQL, String s)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToString(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return s;
//            }
//        }
//        public DateTime GetScalar(String strSQL, DateTime d)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToDateTime(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return Convert.ToDateTime(d);
//            }
//        }
//        public bool GetScalar(String strSQL, bool b)
//        {
//            DataTable rst = GetDataTable(strSQL);
//            try
//            {
//                return Convert.ToBoolean(rst.Rows[0][0]);
//            }
//            catch (Exception e)
//            {
//                return b;
//            }
//        }
//        public String SyntaxFilter(String strSQL)
//        {
//            switch (target_type)
//            {
//                case (Int32)Tools.Database.ServerType.SqlMy:
//                    return strSQL.Replace("\\", "\\\\").Replace("'", "\'\'");
//                default:
//                    return strSQL.Replace("'", "''");
//            }
//        }
//        public Object ConvertFromString(String strIn, Int32 t)
//        {
//            switch (t)
//            {
//                case (Int32)DataType.String:
//                case (Int32)DataType.Memo:
//                case (Int32)DataType.List:
//                    return strIn;
//                case (Int32)DataType.Long:
//                    try
//                    {
//                        return (Object)(Convert.ToInt64(strIn));
//                    }
//                    catch (Exception e)
//                    {
//                        return 0;
//                    }
//                case (Int32)DataType.Integer:
//                case (Int32)DataType.Boolean:
//                    try
//                    {
//                        return (Object)(Convert.ToInt32(strIn));
//                    }
//                    catch (Exception e)
//                    {
//                        return (Object)false;
//                    }
//                case (Int32)DataType.Float:
//                    try
//                    {
//                        return (Object)(Convert.ToDouble(strIn));
//                    }
//                    catch (Exception e)
//                    {
//                        return (Object)Convert.ToDouble(0);
//                    }
//                case (Int32)DataType.Date:
//                    try
//                    {
//                        return (Object)(Convert.ToDateTime(strIn));
//                    }
//                    catch (Exception e)
//                    {
//                        return (Object)nData.ReplaceNull((Int32)DataType.Date);
//                    }
//            }
//            return 0;
//        }
//        public static Object ReplaceNull(Int32 xType)
//        {
//            Int32 i;
//            Int64 l;
//            Double d;
//            DateTime t;
//            switch (xType)
//            {
//                case (Int32)Enums.DataType.String:
//                case (Int32)Enums.DataType.List:
//                case (Int32)Enums.DataType.Memo:
//                    return "";
//                case (Int32)Enums.DataType.Integer:
//                case (Int32)Enums.DataType.Boolean:
//                    i = 0;
//                    return (Object)(i);
//                case (Int32)Enums.DataType.Long:
//                    l = 0;
//                    return (Object)(l);
//                case (Int32)Enums.DataType.Float:
//                    d = 0;
//                    return (Object)(d);
//                case (Int32)Enums.DataType.Date:
//                    t = Convert.ToDateTime("01/01/1900");
//                    return (Object)(t);
//                default:
//                    return "";
//            }
//        }
//        public String FormatInsertValue(Object value, Int32 xType, int StringLength)
//        {
//            String s;
//            if (value == null)
//                return ReplaceNullString(xType);
//            switch (xType)
//            {
//                case (Int32)DataType.String:
//                    s = Convert.ToString(value);
//                    //s = Left(s, StringLength);
//                    s = this.SyntaxFilter(s);
//                    return String.Concat("'", s, "'");
//                case (Int32)DataType.List:
//                    s = Convert.ToString(value);
//                    //s = Left(s, 4096);
//                    s = this.SyntaxFilter(s);
//                    return String.Concat("'", s, "'");
//                case (Int32)DataType.Memo:
//                    return String.Concat("'", SyntaxFilter(value.ToString()), "'");
//                case (Int32)DataType.Integer:
//                case (Int32)DataType.Long:
//                case (Int32)DataType.Float:
//                    return value.ToString();
//                case (Int32)DataType.Date:
//                    return String.Concat("'", ((DateTime)(value)).ToString(), "'");
//                case (Int32)DataType.Boolean:
//                    return BoolFilter((bool)value);
//                default:
//                    return "";
//            }
//        }//overload??
//        public bool Backup(ref String strFile)
//        {
//            String s = "";
//            return Backup(ref strFile, false, ref s);
//        }
//        public bool Backup(ref String strFile, bool hidemessage, ref String s)
//        {
//            if (!Tools.Strings.StrExt(strFile))
//            {
//                strFile = "c:\\backup\\";
//                if (!Directory.Exists(strFile))
//                {
//                    if (hidemessage)
//                        return false;
//                    else
//                    {
//                        return false;
//                    }
//                }
//            }
//            if (!Tools.Files.HasFileName(strFile))
//                strFile = strFile + this.database_name + "_" + Tools.Folder.GetNowPath() + ".bak";
//            //if( !System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFile)) )
//            //{
//            //    context.TheLeader.Tell("The folder " + System.IO.Path.GetDirectoryName(strFile) + " does not exist.");
//            //    return false;
//            //}
//            //if( System.IO.File.Exists(strFile) )
//            //{
//            //    context.TheLeader.Tell("The file " + strFile + " already exists.");
//            //    return false;
//            //}
//            String strSQL;
//            strSQL = "EXEC sp_dropdevice '" + this.database_name + "_bak'";
//            context.TheLeader.Comment("Dropping backup device...");
//            long l = 0;
//            Execute(strSQL, ref l, true, false);
//            strSQL = "EXEC sp_addumpdevice 'disk', '" + this.database_name + "_bak', '" + strFile + "'";
//            context.TheLeader.Comment("Creating backup device...");
//            if (!Execute(strSQL, false, hidemessage, ref s))
//                return false;
//            strSQL = "BACKUP DATABASE " + this.database_name + " TO " + this.database_name + "_bak";
//            context.TheLeader.Comment("Running the backup...");
//            if (!Execute(strSQL, false, hidemessage, ref s))
//            {
//                context.TheLeader.Comment("The backup was not successful.");
//                return false;
//            }
//            else
//            {
//                //if( System.IO.File.Exists(strFile))
//                //{
//                context.TheLeader.Comment("Backup Complete.");
//                return true;
//                //}
//                //else
//                //{
//                //    context.TheLeader.Comment("The backup returned a success code, but the file does not exist.");
//                //    return false;
//                //}
//            }
//        }
//        public bool Restore(String strFile, String strName, String strNewFolder, String strOldName)
//        {
//            String strSQL = "RESTORE FILELISTONLY FROM DISK = '" + strFile + "'";
//            if (!Execute(strSQL))
//                return false;

//            strSQL = "RESTORE DATABASE " + strName + " FROM DISK = '" + strFile + "' WITH MOVE '" + strOldName + "_Data' TO '" + strNewFolder + strName + ".mdf', MOVE '" + strOldName + "_Log' TO '" + strNewFolder + strName + ".ldf'";
//            if (!Execute(strSQL))
//                return false;

//            return true;
//        }
//        public bool IsValidName(String strIn)
//        {
//            return (Tools.Strings.StrCmp(strIn, Tools.Strings.StripNonAlphaNumeric(strIn, true)));
//        }
//        public bool ReTargetDatabase(String strDatabase)
//        {
//            database_name = strDatabase;
//            ConnectionString = GetConnectionString();
//            return true;
//        }
//        public ArrayList GetScalarArray(String strSQL)
//        {
//            ArrayList a = new ArrayList();
//            DataTable d = GetDataTable(strSQL);
//            if (d == null)
//                return a;
//            if (d.Rows.Count <= 0)
//                return a;

//            foreach (DataRow r in d.Rows)
//            {
//                try
//                {
//                    a.Add((String)r[0]);
//                }
//                catch (Exception)
//                { }
//            }
//            return a;
//        }
//        public String ConvertSQLToTabDelimited(String strSQL)
//        {
//            StringBuilder sb = new StringBuilder();
//            DataTable d = GetDataTable(strSQL);
//            if (!Tools.Data.DataTableExists(d))
//            {
//                return "";
//            }

//            foreach (DataColumn c in d.Columns)
//            {
//                sb.Append(c.Caption + "\t");
//            }

//            sb.Append("\r\n");

//            foreach (DataRow r in d.Rows)
//            {
//                foreach (DataColumn c in d.Columns)
//                {
//                    Object o = r[c.Ordinal];
//                    if (o == null)
//                        sb.Append("\t");
//                    else
//                        sb.Append(o.ToString() + "\t");
//                }
//                sb.Append("\r\n");
//            }

//            return sb.ToString();
//        }
//        public String DateExistsSQL(String strField)
//        {
//            return " isnull(" + strField + ", cast('01/01/1900' as datetime)) > cast('01/02/1900' as datetime) ";
//        }
//        public static bool HasField(System.Data.DataTable d, String s)
//        {
//            foreach (System.Data.DataColumn c in d.Columns)
//            {
//                if (Tools.Strings.StrCmp(c.Caption, s))
//                    return true;
//            }
//            return false;
//        }
//        //public String ConvertSQLToHTML(String strSQL)
//        //{
//        //    return ConvertDataTableToHTML(GetDataTable(strSQL));
//        //}
//        //public static String ConvertDataTableToHTML(DataTable d)
//        //{
//        //    StringBuilder sb = new StringBuilder();

//        //    if (!DataTableExists(d))
//        //        return "<font color=red>No Data</font><br>";

//        //    sb.Append("<table border=1 cellpadding=1 cellspacing=1><tr>");

//        //    foreach (DataColumn c in d.Columns)
//        //    {
//        //        sb.Append("<td nowrap>" + c.Caption + "</td>");
//        //    }

//        //    sb.Append("</tr>");

//        //    foreach (DataRow r in d.Rows)
//        //    {
//        //        sb.Append("<tr>");
//        //        int i = 0;
//        //        foreach (DataColumn c in d.Columns)
//        //        {
//        //            sb.Append("<td nowrap>");
//        //            Object o = r[i];
//        //            if (o == null)
//        //                sb.Append("&nbsp;");
//        //            else
//        //                sb.Append(o.ToString() + "&nbsp;");
//        //            sb.Append("</td>");

//        //            i++;
//        //        }
//        //        sb.Append("</tr>");
//        //    }

//        //    sb.Append("</table><br>");
//        //    return sb.ToString();
//        //}
//        public bool RenameTable(String strTable, String strNew)
//        {
//            return Execute("sp_rename '" + strTable + "', '" + strNew + "'");
//        }

//        public bool IsDateField(String strTable, String strField)
//        {
//            DataTable d = GetDataTable("select top 1 " + strField + " from " + strTable);
//            if (d == null)
//                return false;

//            DataColumn c = d.Columns[0];
//            return (c.DataType == System.Type.GetType("System.DateTime"));
//        }
//        public bool IsTextField(String strTable, String strField)
//        {
//            DataTable d = GetDataTable("select top 1 " + strField + " from " + strTable);
//            if (d == null)
//                return false;

//            DataColumn c = d.Columns[0];
//            return (c.DataType == System.Type.GetType("System.String"));
//        }
//        public bool IsDecimalField(String strTable, String strField)
//        {
//            DataTable d = GetDataTable("select top 1 " + strField + " from " + strTable);
//            if (d == null)
//                return false;

//            DataColumn c = d.Columns[0];
//            return (c.DataType == System.Type.GetType("System.Decimal"));
//        }
//        public bool CheckNotifyConnect()
//        {
//            String s = "";
//            if (CanConnect(ref s))
//                return true;
//            else
//            {
//                //context.TheLeader.Tell("The connection to this data source could not be made: " + s);
//                return false;
//            }
//        }
//        public bool HasIdentityField(String strTable)
//        {
//            return Tools.Strings.StrExt(GetScalar_String("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE OBJECTPROPERTY(OBJECT_ID(TABLE_NAME), 'TableHasIdentity') = 1 AND TABLE_TYPE = 'BASE TABLE' and table_name = '" + strTable + "' "));
//        }
//        public DataTable GetTableTable()
//        {
//            return GetDataTable("select name, crdate from sysobjects where type = 'U' order by crdate");
//        }
//        public bool Shrink()
//        {
//            return Execute("DBCC SHRINKDATABASE (" + database_name + ", 10)");
//        }
//        public bool Reindex()
//        {
//            if (!Execute("sp_updatestats", false, true))
//                return false;

//            return Execute("EXEC sp_MSforeachtable @command1=\"print '?' DBCC DBREINDEX ('?', ' ', 80)\"", false, true);
//        }
//        public long GetDataFileSizeInK()
//        {
//            return GetScalar_Long("select max(size * 8) from sysfiles where fileid = 1");
//        }
//        public long GetDataFileSizeInBytes()
//        {
//            return GetScalar_Long("select max(size * 8 * 1024) from sysfiles where fileid = 1");
//        }
//        public long GetLogFileSizeInK()
//        {
//            return GetScalar_Long("select max(size * 8) from sysfiles where fileid = 2");
//        }
//        public static bool CopyTable(String source, String dest, String SourceTable, String DestTable, String strFields, ref String status)
//        {
//            try
//            {
//                string sql = "SELECT " + strFields + " from " + SourceTable;

//                SqlConnection sourceconn = new SqlConnection(source);
//                SqlCommand command = new SqlCommand(sql, sourceconn);

//                sourceconn.Open();
//                IDataReader dr = command.ExecuteReader();

//                SqlConnection destconn = new SqlConnection(dest);
//                destconn.Open();

//                using (SqlBulkCopy copy =
//                        new SqlBulkCopy(dest))
//                {
//                    String[] fields = Tools.Strings.Split(strFields, ",");
//                    foreach (String s in fields)
//                    {
//                        if (Tools.Strings.StrExt(s))
//                            copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(s.Trim(), s.Trim()));
//                    }

//                    copy.BulkCopyTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                    copy.DestinationTableName = DestTable;
//                    //context.TheLeader.Comment("Transferring bulk data...");
//                    copy.WriteToServer(dr);

//                    sourceconn.Close();
//                    sourceconn = null;
//                    destconn.Close();
//                    destconn = null;
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                status = ex.Message;
//                return false;
//            }
//        }
//        public bool ImportDataTable(DataTable d, String strTable)
//        {
//            return ImportDataTable(d, strTable, null);
//        }
//        public bool ImportDataTable(DataTable d, String strTable, int[] lens)
//        {
//            String s = "";
//            return ImportDataTable(d, strTable, false, ref s, lens);
//        }
//        public bool ImportDataTable(DataTable d, String strTable, bool silent, ref String strStatus, int[] lens)
//        {
//            using (SqlBulkCopy copy = new SqlBulkCopy(GetConnectionString(true)))
//            {
//                int i = 0;
//                String s = "";
//                StringBuilder sb = new StringBuilder();
//                foreach (DataColumn dc in d.Columns)
//                {
//                    try
//                    {
//                        int len = 0;
//                        if (lens != null)
//                            len = lens[i];

//                        s = dc.Caption;
//                        if (i == 0)
//                            Execute("create table " + strTable + "( " + s + " " + GetFieldSpec(dc, len) + " )");
//                        else
//                            Execute("alter table " + strTable + " add " + s + " " + GetFieldSpec(dc, len));

//                        sb.AppendLine(s + " : " + GetFieldSpec(dc, len));

//                        copy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(s, s));
//                        i++;
//                    }
//                    catch (Exception ex)
//                    {
//                        //nStatus.TellUserTemp("Error in Import DataTable on column " + s + " : " + ex.Message);
//                    }
//                }

//                try
//                {
//                    copy.BulkCopyTimeout = Tools.Database.DataConnection.TimeOutDefault;
//                    copy.DestinationTableName = strTable;
//                    //context.TheLeader.Comment("Transferring bulk data...");
//                    copy.WriteToServer(d);
//                    copy.Close();
//                    return true;
//                }
//                catch (Exception ex2)
//                {
//                    if (silent)
//                    {
//                        //nStatus.TellUserTemp("Error in ImportDataTable: " + ex2.Message + "\r\n\r\n\r\n" + sb.ToString());
//                    }
//                    else
//                    {
//                        //context.TheLeader.Tell("Error in ImportDataTable: " + ex2.Message + "\r\n\r\n\r\n" + sb.ToString());
//                    }
//                    strStatus = ex2.Message;
//                    return false;
//                }
//            }
//        }
//        public static String GetFieldSpec(DataColumn dc, int len)
//        {
//            switch (dc.DataType.ToString())
//            {
//                case "System.String":
//                    if (len > -1 && len <= 4096)
//                        return "varchar(4096)";
//                    else
//                        return "text";
//                case "System.Int16":
//                case "System.Int32":
//                case "System.Int64":
//                    return "int";
//                case "System.DateTime":
//                    return "datetime";
//                case "System.Boolean":
//                    return "bit";
//                default:
//                    return "varchar(255)";
//            }
//        }
//        public static int GetColumnCount_Delimited(String strFile, Char limit)
//        {
//            try
//            {
//                int t = 0;
//                StreamReader sr = new StreamReader(strFile);
//                string input;
//                int r = 0;
//                int cols = 0;
//                while ((input = sr.ReadLine()) != null)
//                {
//                    String[] a = SplitDelimitedLine(input, -1, limit, ref cols);
//                    if (cols > t)
//                        t = cols;
//                    r++;
//                    if (r > 50)
//                        break;
//                }
//                sr.Close();
//                sr = null;
//                return t;
//            }
//            catch (Exception ex)
//            {
//                return 0;
//            }
//        }
//        public static String[] SplitDelimitedLine(String s, int cols, Char limit, ref int rcols)
//        {
//            Char[] chars = s.ToCharArray();
//            bool bq = false;

//            int bound = 50;
//            if (cols > -1)
//                bound = cols;

//            String[] r = new String[bound];

//            int col = 0;
//            String temp = "";
//            for (int i = 0; i < chars.Length; i++)
//            {
//                switch (chars[i])
//                {
//                    case '\"':
//                        bq = !bq;
//                        break;
//                    default:
//                        if (chars[i] == limit && !bq)
//                        {
//                            r[col] = temp;
//                            temp = "";
//                            col++;
//                            if (col >= bound)
//                            {
//                                rcols = col + 1;
//                                return r;
//                            }
//                        }
//                        else
//                        {
//                            temp += chars[i].ToString();
//                        }
//                        break;
//                }
//            }
//            rcols = col + 1;
//            r[col] = temp;
//            return r;
//        }
//        public bool ImportDelimitedFileToTable(String strFile, Char limit, ref String strTable)
//        {
//            try
//            {
//                int cols = GetColumnCount_Delimited(strFile, limit);
//                if (cols == 0)
//                    return false;

//                DataTable dt = new DataTable();
//                DataColumn dc;
//                DataRow dr;

//                strTable = "temp_" + Tools.Strings.GetNewID();
//                if (!Execute("create table " + strTable + " (column_0 varchar(255))"))
//                    return false;


//                for (int i = 0; i < cols; i++)
//                {
//                    dc = new DataColumn();
//                    dc.DataType = System.Type.GetType("System.String");
//                    dc.MaxLength = 255;
//                    dc.ColumnName = "column_" + i.ToString();
//                    dc.Unique = false;
//                    dt.Columns.Add(dc);

//                    if (i > 0)
//                    {
//                        if (!Execute("alter table " + strTable + " add " + dc.ColumnName + " varchar(255)"))
//                            return false;
//                    }
//                }

//                int x = 0;
//                StreamReader sr = new StreamReader(strFile);
//                string input;
//                while ((input = sr.ReadLine()) != null)
//                {
//                    string[] s = SplitDelimitedLine(input, cols, ',', ref x);
//                    dr = dt.NewRow();
//                    for (int i = 0; i < cols; i++)
//                    {
//                        dr[i] = s[i];
//                    }
//                    dt.Rows.Add(dr);
//                }
//                sr.Close();

//                SqlBulkCopy bulkCopy = new SqlBulkCopy(GetConnectionString(true), SqlBulkCopyOptions.TableLock);
//                bulkCopy.DestinationTableName = "dbo." + strTable;
//                bulkCopy.WriteToServer(dt);
//                bulkCopy.Close();
//                bulkCopy = null;
//                dt = null;
//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//        public bool IsDefinitelySameTable(String strTable, nData xd)
//        {
//            if (Tools.Strings.StrCmp(server_name + "_-_" + database_name, xd.server_name + "_-_" + xd.database_name))
//                return true;

//            String strID = Tools.Strings.GetNewID();
//            String strSQL = "insert into " + strTable + " (unique_id) values ('" + strID + "')";
//            Execute(strSQL);
//            strSQL = "select count(*) from " + strTable + " where unique_id = '" + strID + "'";
//            bool b = false;
//            if (xd.GetScalar_Long(strSQL) > 0)
//                b = true;

//            strSQL = "delete from " + strTable + " where unique_id = '" + strID + "'";
//            Execute(strSQL);
//            return b;
//        }
//        public bool ExportSQLToCsv(String strSQL, String strFile, ref long l)
//        {
//            return ExportSQLToCsv(strSQL, strFile, ref l, "");
//        }
//        public bool ExportSQLToCsv(String strSQL, String strFile, ref long l, String headerstring)
//        {
//            DataTable d = GetDataTable(strSQL);
//            if (d == null)
//                return false;
//            return ExportDataTableToCsv(d, strFile, ref l, headerstring);
//        }
//        public bool ExportDataTableToCsv(DataTable d, String strFile, ref long l)
//        {
//            return ExportDataTableToCsv(d, strFile, ref l, "");
//        }
//        public bool ExportDataTableToCsv(DataTable d, String strFile, ref long l, String headerstring)
//        {
//            try
//            {
//                System.IO.StreamWriter file = new System.IO.StreamWriter(strFile, false);

//                int i = 0;
//                //foreach (DataColumn c in d.Columns)
//                //{
//                //    if (i != 0)
//                //        file.Write(",");
//                //    file.Write("\"" + c.Caption.Replace("\"", "") + "\"");
//                //    i++;
//                //}

//                //file.Write("\r\n");

//                if (Tools.Strings.StrExt(headerstring))
//                    file.Write(headerstring + "\r\n");

//                int j = 0;
//                foreach (DataRow r in d.Rows)
//                {
//                    i = 0;
//                    foreach (DataColumn c in d.Columns)
//                    {
//                        if (i != 0)
//                            file.Write(",");
//                        String s = nData.NullFilter_String(r[i]).Replace("\"", "");
//                        file.Write("\"" + s + "\"");
//                        i++;
//                    }
//                    j++;
//                    file.Write("\r\n");
//                }

//                file.Close();
//                file = null;
//                l = j;
//                return true;

//            }
//            catch (Exception ex)
//            {
//                //context.TheLeader.Comment("Error in ExportDataTableToCsv: " + ex.Message);
//                l = 0;
//                return false;
//            }
//        }
//        public bool LinkSQLServer(nData nd)
//        {
//            String strSQL = "USE [master] \r\n EXEC master.dbo.sp_addlinkedserver @server = N'" + nd.server_name + "', @srvproduct=N'SQL Server'\n";
//            Execute(strSQL, true);

//            strSQL = "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'collation compatible', @optvalue=N'false'\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'data access', @optvalue=N'true'\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'rpc', @optvalue=N'false'\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'rpc out', @optvalue=N'false'\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'connect timeout', @optvalue=N'0'\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'collation name', @optvalue=null\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'query timeout', @optvalue=N'0'\n" +
//                "EXEC master.dbo.sp_serveroption @server=N'" + nd.server_name + "', @optname=N'use remote collation', @optvalue=N'true'\n";

//            Execute(strSQL, true);

//            strSQL = "EXEC master.dbo.sp_addlinkedsrvlogin @rmtsrvname = N'" + nd.server_name + "', @locallogin = NULL , @useself = N'False', @rmtuser = N'" + nd.user_name + "', @rmtpassword = N'" + nd.user_password + "'\n";
//            return Execute(strSQL);
//        }
//        //DataType conversions
//        public static String ConvertDataType(Int32 d)
//        {
//            switch (d)
//            {
//                case (Int32)DataType.String:
//                    return "String";
//                case (Int32)DataType.Long:
//                    return "Long";
//                case (Int32)DataType.Float:
//                    return "Float";
//                case (Int32)DataType.Memo:
//                    return "Memo";
//                case (Int32)DataType.Integer:
//                    return "Integer";
//                case (Int32)DataType.Date:
//                    return "Date";
//                case (Int32)DataType.Boolean:
//                    return "Boolean";
//                case (Int32)DataType.Blob:
//                    return "Blob";
//                default:
//                    return "(Unknown)";
//            }
//        }
//        public static Enums.DataType ConvertDataTypeToEnum(Int32 d)
//        {
//            switch (d)
//            {
//                case (Int32)DataType.String:
//                    return DataType.String;
//                case (Int32)DataType.Long:
//                    return DataType.Long;
//                case (Int32)DataType.Float:
//                    return DataType.Float;
//                case (Int32)DataType.Memo:
//                    return DataType.Memo;
//                case (Int32)DataType.Integer:
//                    return DataType.Integer;
//                case (Int32)DataType.Date:
//                    return DataType.Date;
//                case (Int32)DataType.Boolean:
//                    return DataType.Boolean;
//                case (Int32)DataType.Blob:
//                    return DataType.Blob;
//                default:
//                    return DataType.Any;
//            }
//        }
//        public static Int32 ConvertDataType(String str)
//        {
//            if (Tools.Strings.StrCmp(str, "String"))
//                return (Int32)DataType.String;
//            if (Tools.Strings.StrCmp(str, "Long"))
//                return (Int32)DataType.Long;
//            if (Tools.Strings.StrCmp(str, "Float"))
//                return (Int32)DataType.Float;
//            if (Tools.Strings.StrCmp(str, "Memo"))
//                return (Int32)DataType.Memo;
//            if (Tools.Strings.StrCmp(str, "Integer"))
//                return (Int32)DataType.Integer;
//            if (Tools.Strings.StrCmp(str, "Date"))
//                return (Int32)DataType.Date;
//            if (Tools.Strings.StrCmp(str, "Boolean"))
//                return (Int32)DataType.Boolean;
//            if (Tools.Strings.StrCmp(str, "Blob"))
//                return (Int32)DataType.Blob;
//            return (Int32)DataType.String;
//        }
//        public static String ConvertUseType(Int32 d)
//        {
//            switch (d)
//            {
//                case (Int32)DataUse.Unknown:
//                    return "Unknown";
//                case (Int32)DataUse.Any:
//                    return "Any";
//                case (Int32)DataUse.TableSplit:
//                    return "TableSplit";
//                case (Int32)DataUse.Email:
//                    return "Email";
//                case (Int32)DataUse.Phone:
//                    return "Phone";
//                case (Int32)DataUse.Url:
//                    return "Url";
//                case (Int32)DataUse.List:
//                    return "List";
//                case (Int32)DataUse.PersonName:
//                    return "PersonName";
//                case (Int32)DataUse.FirstName:
//                    return "FirstName";
//                case (Int32)DataUse.LastName:
//                    return "LastName";
//                default:
//                    return "(Unknown)";
//            }
//        }
//        public static Int32 ConvertUseType(String str)
//        {
//            if (Tools.Strings.StrCmp(str, "Unknown"))
//                return (Int32)DataUse.Unknown;
//            if (Tools.Strings.StrCmp(str, "Any"))
//                return (Int32)DataUse.Any;
//            if (Tools.Strings.StrCmp(str, "TableSplit"))
//                return (Int32)DataUse.TableSplit;
//            if (Tools.Strings.StrCmp(str, "Email"))
//                return (Int32)DataUse.Email;
//            if (Tools.Strings.StrCmp(str, "Phone"))
//                return (Int32)DataUse.Phone;
//            if (Tools.Strings.StrCmp(str, "Url"))
//                return (Int32)DataUse.Url;
//            if (Tools.Strings.StrCmp(str, "List"))
//                return (Int32)DataUse.List;
//            if (Tools.Strings.StrCmp(str, "PersonName"))
//                return (Int32)DataUse.PersonName;
//            if (Tools.Strings.StrCmp(str, "FirstName"))
//                return (Int32)DataUse.FirstName;
//            if (Tools.Strings.StrCmp(str, "LastName"))
//                return (Int32)DataUse.LastName;

//            return 0;
//        }
//        public static String BoolFilter(bool blnin)
//        {
//            if (blnin)
//                return "1";
//            return "0";
//        }
//        public static DateTime DateFilter(DateTime dt)
//        {
//            if (dt >= System.Convert.ToDateTime("01/01/1900"))
//                return dt;
//            else
//                return System.Convert.ToDateTime("01/01/1900");

//        }
//        public static String ReplaceNullString(Int32 xType)
//        {
//            switch (xType)
//            {
//                case (Int32)DataType.String:
//                case (Int32)DataType.List:
//                case (Int32)DataType.Memo:
//                    return "''";
//                case (Int32)DataType.Integer:
//                case (Int32)DataType.Long:
//                case (Int32)DataType.Float:
//                case (Int32)DataType.Boolean:
//                    return "0";
//                case (Int32)DataType.Date:
//                    return "'01/01/1900'";
//                default:
//                    return "''";
//            }
//        }
//        //Overload these below
//        public static String NullFilter_String(Object varIn)
//        {
//            if (varIn == System.DBNull.Value || varIn == null)
//                return "";
//            else
//                return varIn.ToString();
//        }
//        public static Int32 NullFilter_Int32(Object varIn)
//        {
//            if (varIn == System.DBNull.Value || varIn == null)
//                return Convert.ToInt32(0);
//            else
//                return Convert.ToInt32(varIn);
//        }
//        public static bool NullFilter_Boolean(Object varIn)
//        {
//            if (varIn == System.DBNull.Value || varIn == null)
//                return Convert.ToBoolean(false);
//            else
//                return Convert.ToBoolean(varIn);
//        }
//        public static bool NullFilter_Boolean_IntOrByte(Object varIn)
//        {
//            if (varIn == System.DBNull.Value || varIn == null)
//                return Convert.ToBoolean(false);
//            else
//                return Convert.ToBoolean(varIn);
//        }
//        public static Double NullFilter_Float(Object varIn)
//        {
//            try
//            {
//                if (varIn == System.DBNull.Value || varIn == null)
//                    return Convert.ToDouble(0);
//                else
//                    return (Double)varIn;
//            }
//            catch (Exception)
//            {
//                return Convert.ToDouble(0);
//            }
//        }
//        public static Double NullFilter_Double(Object varIn)
//        {
//            try
//            {
//                if (varIn == System.DBNull.Value || varIn == null)
//                    return Convert.ToDouble(0);
//                else
//                    return (Double)varIn;
//            }
//            catch (Exception)
//            { return Convert.ToDouble(0); }
//        }
//        public static Int64 NullFilter_Long(Object varIn)
//        {
//            return NullFilter_Int64(varIn);
//        }
//        public static Int64 NullFilter_Int64(Object varIn)
//        {
//            if (varIn == System.DBNull.Value || varIn == null)
//                return Convert.ToInt64(0);
//            else
//                return Convert.ToInt64(varIn);
//        }
//        public static DateTime NullFilter_Date(Object varIn)
//        {
//            return NullFilter_DateTime(varIn);
//        }
//        public static DateTime NullFilter_DateTime(Object varIn)
//        {
//            if (varIn == System.DBNull.Value || varIn == null)
//                return Convert.ToDateTime("01/01/1900");
//            else
//                return (DateTime)varIn;
//        }
//        public static Object NullFilter(String s, Enums.DataType t)
//        {
//            try
//            {
//                switch (t)
//                {
//                    case DataType.String:
//                    case DataType.List:
//                    case DataType.Memo:
//                        return (Object)s;
//                    case DataType.Integer:
//                        return (Object)Convert.ToInt32(s);
//                    case DataType.Long:
//                        return (Object)Convert.ToInt64(s);
//                    case DataType.Float:
//                        return (Object)Convert.ToDouble(s);
//                    case DataType.Boolean:
//                        return (Object)Convert.ToBoolean(s);
//                    case DataType.Date:
//                        return (Object)Convert.ToDateTime(s);
//                }
//            }
//            catch (Exception)
//            {
//            }

//            return nData.GetNullValue(t);
//        }
//        public static Object GetNullValue(Enums.DataType t)
//        {
//            try
//            {
//                switch (t)
//                {
//                    case DataType.String:
//                    case DataType.List:
//                    case DataType.Memo:
//                        return (Object)"";
//                    case DataType.Integer:
//                        return (Object)Convert.ToInt32(0);
//                    case DataType.Long:
//                        return (Object)Convert.ToInt64(0);
//                    case DataType.Float:
//                        return (Object)Convert.ToDouble(0);
//                    case DataType.Boolean:
//                        return (Object)Convert.ToBoolean(false);
//                    case DataType.Date:
//                        return (Object)Convert.ToDateTime(Tools.Dates.GetNullDate());
//                }
//            }
//            catch (Exception)
//            { }

//            return null;
//        }
//        public static Object NullFilter(Object o, Enums.DataType t)
//        {
//            try
//            {
//                if (o != null)
//                {
//                    switch (t)
//                    {
//                        case DataType.String:
//                        case DataType.List:
//                        case DataType.Memo:
//                            return o;
//                        case DataType.Integer:
//                            return (Object)Convert.ToInt32(o);
//                        case DataType.Long:
//                            return (Object)Convert.ToInt64(o);
//                        case DataType.Float:
//                            return (Object)Convert.ToDouble(o);
//                        case DataType.Boolean:
//                            return (Object)Convert.ToBoolean(o);
//                        case DataType.Date:
//                            return (Object)Convert.ToDateTime(o);
//                    }
//                }
//            }
//            catch (Exception)
//            { }
//            return nData.GetNullValue(t);
//        }
//        public static String ReturnCodeNullString(Int32 xType)
//        {
//            switch (xType)
//            {
//                case (Int32)DataType.String:
//                case (Int32)DataType.List:
//                case (Int32)DataType.Memo:
//                    return "\"\"";
//                case (Int32)DataType.Integer:
//                case (Int32)DataType.Long:
//                case (Int32)DataType.Float:
//                    return "0";
//                case (Int32)DataType.Boolean:
//                    return "false";
//                case (Int32)DataType.Date:
//                    return "\"01/01/1900\"";
//                default:
//                    return "null";
//            }
//        }//Added to convert nulls to code defaults
//        public Enums.DataType ConvertColumnTypeToPropertyType(DataColumn t)
//        {
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Boolean")))
//                return Enums.DataType.Boolean;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Byte")))
//                return Enums.DataType.Integer;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Char")))
//                return Enums.DataType.Integer;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("DateTime")))
//                return Enums.DataType.Date;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Decimal")))
//                return Enums.DataType.Float;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Double")))
//                return Enums.DataType.Float;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Int16")))
//                return Enums.DataType.Integer;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Int32")))
//                return Enums.DataType.Integer;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Int64")))
//                return Enums.DataType.Long;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("SByte")))
//                return Enums.DataType.Integer;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("Single")))
//                return Enums.DataType.Float;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("String")))
//                return Enums.DataType.String;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("TimeSpan")))
//                return Enums.DataType.Float;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("UInt16")))
//                return Enums.DataType.Integer;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("UInt32")))
//                return Enums.DataType.Long;
//            if (System.Type.Equals(t.DataType, System.Type.GetType("UInt64")))
//                return Enums.DataType.Long;
//            return Enums.DataType.String;
//        }
//    }
//    public class AsyncExecutionArgs
//    {
//        public String strSQL;
//        public bool show_warnings = false;
//        public String strDescription;

//        public AsyncExecutionArgs(String str, bool warn, String desc)
//        {
//            strSQL = str;
//            show_warnings = warn;
//            strDescription = desc;
//        }
//    }
//    public class nStatus
//    {
//        public static void SetStatus(String s)
//        {

//        }
//    }
//}
