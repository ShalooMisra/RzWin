using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using Tools.Database;
using System.Data.SqlClient;

namespace NewMethod
{
    public partial class n_set : n_set_auto
    {
        public void Set(ContextNM context, String val)
        {
            setting_value = val;
            context.TheDelta.Update(context, this);
        }

        public void Clear(ContextNM context)
        {
            setting_value = "";
            context.TheDelta.Update(context, this);
        }

        public static int NextInteger(ContextNM x, String settingName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("begin tran");
            sb.AppendLine("update n_set set setting_value = cast(cast(cast(setting_value as varchar(255)) as int) + 1 as varchar(255)) where name = '" + settingName + "'");
            sb.AppendLine("IF @@ROWCOUNT = 0 insert into n_set(unique_id, name, setting_value) values ('autoid_" + settingName + "', '" + settingName + "', '1')");
            
            //for testing.  this tran concept works; it actually makes a second call wait until the first transaction is done
            //sb.AppendLine("WAITFOR DELAY '00:00:05'");

            sb.AppendLine("select setting_value from n_set where name = '" + settingName + "'");
            sb.AppendLine("commit tran");

            String ret = x.TheData.SelectScalarString(sb.ToString());
            if (Tools.Number.IsNumeric(ret))
                return Int32.Parse(ret);
            else
                return 0;
        }

        public static String GetSetting(ContextNM x, String strName)
        {
            return (String)x.TheData.SelectScalarString("select setting_value from n_set where name = '" + x.TheData.Filter(strName) + "'");
        }

        public static void SetSetting(ContextNM x, String strName, String strValue)
        {
            n_set s = n_set.GetByName(x, strName);
            if (s == null)
            {
                s = (n_set)x.Item("n_set");
                s.name = strName;
                x.Insert(s);
            }
            s.setting_value = strValue;
            s.Update(x);
        }

        public static void SetSettingBlob(ContextNM x, String settingName, byte[] b)
        {
            bool exists = true;
            try
            {
                x.Execute("select top 1 picturedata from n_set");
            }
            catch { exists = false; }
            if (!exists)
                x.Execute("alter table n_set add picturedata image");
            n_set s = n_set.GetByName(x, settingName);
            if (s == null)
            {
                s = (n_set)x.Item("n_set");
                s.name = settingName;
                x.Insert(s);
            }
            SqlConnection xConnect = new SqlConnection(x.Data.Connection.ConnectionString.Replace(Tools.Strings.Split(x.Data.Connection.ConnectionString, ";")[0] + ";", ""));
            if (b == null)
                return;
            if (b.Length <= 0)
                return;
            String SQL;
            SQL = "update n_set set picturedata = @picture where name = '" + x.TheData.Filter(settingName) + "'";
            Int32 affect;
            try
            {
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                SqlParameter param = new SqlParameter("@picture", SqlDbType.VarBinary);
                param.Value = b;
                oCmd.Parameters.Add(param);
                xConnect.Open();
                affect = oCmd.ExecuteNonQuery();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;                
            }
            catch (Exception ex)
            {
                x.TheLeader.Error("Error saving attachment info: " + ex.Message);
            }            
        }

        public static byte[] GetSettingBlob(ContextNM x, String settingName)
        {
            String SQL = "select picturedata from n_set where name = '" + x.TheData.Filter(settingName) + "'";
            try
            {
                SqlConnection xConnect = new SqlConnection(x.Data.Connection.ConnectionString.Replace(Tools.Strings.Split(x.Data.Connection.ConnectionString, ";")[0] + ";", ""));
                SqlCommand oCmd = xConnect.CreateCommand();
                oCmd.CommandTimeout = DataConnectionSqlServer.TimeOut;
                oCmd.CommandText = SQL;
                xConnect.Open();
                byte[] picturedata = (byte[])oCmd.ExecuteScalar();
                oCmd.Dispose();
                oCmd = null;
                xConnect.Close();
                xConnect = null;
                return picturedata;
            }
            catch
            { return null; }
        }

        public static void SetSetting_Integer(ContextNM x, String strName, int intValue)
        {
            n_set s = n_set.GetByName(x, strName);
            if (s == null)
            {
                s = (n_set)x.Item("n_set");
                s.name = strName;
                x.Insert(s);
            }
            s.setting_value = intValue.ToString();
            s.Update(x);
        }
        public static void SetSetting_Long(ContextNM x, String strName, long lngValue)
        {
            n_set s = n_set.GetByName(x, strName);
            if (s == null)
            {
                s = (n_set)x.Item("n_set");
                s.name = strName;
                x.Insert(s);
            }
            s.setting_value = lngValue.ToString();
            s.Update(x);
        }
        public static void SetSetting_Double(ContextNM x, String strName, Double dblValue)
        {
            n_set s = n_set.GetByName(x, strName);
            if (s == null)
            {
                s = (n_set)x.Item("n_set");
                s.name = strName;
                x.Insert(s);
            }
            s.setting_value = dblValue.ToString();
            s.Update(x);
        }
        public static void SetSetting_Date(ContextNM x, String strName, DateTime d)
        {
            if (Tools.Dates.DateExists(d))
                SetSetting(x, strName, d.ToString());
            else
                SetSetting(x, strName, "");
        }
        public static DateTime GetSetting_Date(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            try
            {
                return DateTime.Parse(s);
            }
            catch (Exception)
            {
                return Tools.Dates.GetNullDate();
            }
        }
        public static bool GetSetting_Boolean(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            if (Tools.Strings.StrCmp(s, "true"))
                return true;
            else
                return false;
        }
        public static Int64 GetSetting_Long(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            try
            {
                return Int64.Parse(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Double GetSetting_Double(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            try
            {
                return Double.Parse(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int32 GetSetting_Integer(ContextNM x, String strName)
        {
            String s = GetSetting(x, strName);
            try
            {
                return Int32.Parse(s);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        
        public static void SetSetting_Boolean(ContextNM x, String strName, bool value)
        {
            if (value)
                SetSetting(x, strName, "true");
            else
                SetSetting(x, strName, "false");
        }
    }
}
