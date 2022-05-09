using System;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Threading;
using Tools.Database;
using NewMethod.Enums;
using Core;

namespace NewMethod
{
    public static partial class nData //: n_data_target
    {
        public static event SqlFinishedHandler SqlFinished;

        public static void FilterTrashField(DataConnection xd, String strTable, String strField, bool RemoveNumbers, bool OnlySymbols, String where)
        {
            if (OnlySymbols)
            {
                BulkReplaceField(xd, strTable, strField, nTools.GetTrashKeys(), where);
            }
            else
            {
                if (RemoveNumbers)
                {
                    BulkReplaceField(xd, strTable, strField, nTools.GetTrashKeys_Numbers(), where);
                }
                else
                {
                    BulkReplaceField(xd, strTable, strField, nTools.GetTrashKeys(), where);
                }
            }
        }
        public static void BulkReplaceField(DataConnection xd, String strTable, String strField, String[] r, String where)
        {
            foreach (String x in r)
            {
                String sql = "update " + strTable + " set " + strField + " = replace(" + strField + ", '" + xd.SyntaxFilter(x) + "', '')";
                if (Tools.Strings.StrExt(where))
                    sql += " where " + where;
                xd.Execute(sql);
            }
        }

        public static bool StripField(nDataTable d, String strField)
        {
            return d.xData.StripField(d.TableName, strField);
        }


        //Public Static Functions
        public static Object ReplaceNull(FieldType type)
        {
            Int32 i;
            Int64 l;
            Double d;
            DateTime t;
            switch (type)
            {
                case FieldType.String:
                case FieldType.Text:
                    return "";
                case FieldType.Int32:
                case FieldType.Boolean:
                    i = 0;
                    return (Object)(i);
                case FieldType.Int64:
                    l = 0;
                    return (Object)(l);
                case FieldType.Double:
                    d = 0;
                    return (Object)(d);
                case FieldType.DateTime:
                    t = Tools.Dates.NullDate;
                    return (Object)(t);
                default:
                    return "";
            }
        }

        public static String GetIn_nObjects(ArrayList a)
        {
            String s = "";
            foreach (nObject o in a)
            {
                if (o != null)
                {
                    if (Tools.Strings.StrExt(o.unique_id))
                    {
                        if (Tools.Strings.StrExt(s))
                            s += ",'" + o.unique_id.Replace("'", "''") + "'";
                        else
                            s = "'" + o.unique_id.Replace("'", "''") + "'";
                    }
                }
            }
            return s;
        }
        public static String GetIn_nObjects(ArrayList a, String fieldname)
        {
            String s = "";
            foreach (nObject o in a)
            {
                if (o != null)
                {
                    if (Tools.Strings.StrExt(o.unique_id))
                    {
                        if (Tools.Strings.StrExt(s))
                            s += ",'" + o.unique_id.Replace("'", "''") + "'";
                        else
                            s = "'" + o.unique_id.Replace("'", "''") + "'";
                    }
                }
            }
            return s;
        }
 
        
        ////DataType conversions  what is this for?
        //public static String ConvertDataType(FieldType type)
        //{
        //    switch (type)
        //    {
        //        case FieldType.String:
        //            return "String";
        //        case FieldType.Int64:
        //            return "Long";
        //        case FieldType.Double:
        //            return "Float";
        //        case FieldType.Text:
        //            return "Memo";
        //        case FieldType.Int32:
        //            return "Integer";
        //        case FieldType.DateTime:
        //            return "Date";
        //        case FieldType.Boolean:
        //            return "Boolean";
        //        case FieldType.Blob:
        //            return "Blob";
        //        default:
        //            return "(Unknown)";
        //    }
        //}
        //public static FieldType ConvertDataTypeToEnum(Int32 d)
        //{
        //    switch (d)
        //    {
        //        case (Int32)FieldType.String:
        //            return FieldType.String;
        //        case (Int32)FieldType.Int64:
        //            return FieldType.Int64;
        //        case (Int32)FieldType.Double:
        //            return FieldType.Double;
        //        case (Int32)FieldType.Text:
        //            return FieldType.Text;
        //        case (Int32)FieldType.Int32:
        //            return FieldType.Int32;
        //        case (Int32)FieldType.DateTime:
        //            return FieldType.DateTime;
        //        case (Int32)FieldType.Boolean:
        //            return FieldType.Boolean;
        //        case (Int32)DataType.Blob:
        //            return DataType.Blob;
        //        default:
        //            return DataType.Any;
        //    }
        //}
        //public static Int32 ConvertDataType(String str)
        //{
        //    if (Tools.Strings.StrCmp(str, "String"))
        //        return (Int32)FieldType.String;
        //    if (Tools.Strings.StrCmp(str, "Long"))
        //        return (Int32)FieldType.Int64;
        //    if (Tools.Strings.StrCmp(str, "Float"))
        //        return (Int32)FieldType.Double;
        //    if (Tools.Strings.StrCmp(str, "Memo"))
        //        return (Int32)FieldType.Text;
        //    if (Tools.Strings.StrCmp(str, "Integer"))
        //        return (Int32)FieldType.Int32;
        //    if (Tools.Strings.StrCmp(str, "Date"))
        //        return (Int32)FieldType.DateTime;
        //    if (Tools.Strings.StrCmp(str, "Boolean"))
        //        return (Int32)FieldType.Boolean;
        //    if (Tools.Strings.StrCmp(str, "Blob"))
        //        return (Int32)DataType.Blob;
        //    return (Int32)FieldType.String;
        //}
        public static ValueUse ConvertUseType(Int32 d)
        {
            try
            {
                ValueUse u = (ValueUse)d;
                return u;
            }
            catch
            {
                return ValueUse.Any;
            }

            //switch (d)
            //{
            //    case (Int32)DataUse.Unknown:
            //        return 
            //    case (Int32)DataUse.Any:
            //        return "Any";
            //    case (Int32)DataUse.TableSplit:
            //        return "TableSplit";
            //    case (Int32)DataUse.Email:
            //        return "Email";
            //    case (Int32)DataUse.Phone:
            //        return "Phone";
            //    case (Int32)DataUse.Url:
            //        return "Url";
            //    case (Int32)DataUse.List:
            //        return "List";
            //    case (Int32)DataUse.PersonName:
            //        return "PersonName";
            //    case (Int32)DataUse.FirstName:
            //        return "FirstName";
            //    case (Int32)DataUse.LastName:
            //        return "LastName";
            //    case (Int32)DataUse.Password:
            //        return "Password";
            //    default:
            //        return "(Unknown)";
            //}
        }
        public static Int32 ConvertUseType(String str)
        {
            try
            {
                ValueUse u = (ValueUse)Enum.Parse(Type.GetType("NewMethod.Enums.DataUse"), str);
                return (Int32)u;
            }
            catch
            {
                return 0;
            }

            //if (Tools.Strings.StrCmp(str, "Unknown"))
            //    return (Int32)DataUse.Unknown;
            //if (Tools.Strings.StrCmp(str, "Any"))
            //    return (Int32)DataUse.Any;
            //if (Tools.Strings.StrCmp(str, "TableSplit"))
            //    return (Int32)DataUse.TableSplit;
            //if (Tools.Strings.StrCmp(str, "Email"))
            //    return (Int32)DataUse.Email;
            //if (Tools.Strings.StrCmp(str, "Phone"))
            //    return (Int32)DataUse.Phone;
            //if (Tools.Strings.StrCmp(str, "Url"))
            //    return (Int32)DataUse.Url;
            //if (Tools.Strings.StrCmp(str, "List"))
            //    return (Int32)DataUse.List;
            //if (Tools.Strings.StrCmp(str, "PersonName"))
            //    return (Int32)DataUse.PersonName;
            //if (Tools.Strings.StrCmp(str, "FirstName"))
            //    return (Int32)DataUse.FirstName;
            //if (Tools.Strings.StrCmp(str, "LastName"))
            //    return (Int32)DataUse.LastName;
            //if (Tools.Strings.StrCmp(str, "Password"))
            //    return (Int32)DataUse.Password;
            //return 0;
        }

        public static DateTime DateFilter(DateTime dt)
        {
            if (dt > Tools.Dates.NullDateCompare)
                return dt;
            else
                return Tools.Dates.NullDate;
        }

        public static String DateFilterString(DateTime dt)
        {
            return Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(DateFilter(dt));
        }


        //Overload these below
        public static String NullFilter_String(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return "";
            else
                return varIn.ToString();
        }
        public static Int32 NullFilter_Int32(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return Convert.ToInt32(0);
            else
                return Convert.ToInt32(varIn);
        }
        public static bool NullFilter_Boolean(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return Convert.ToBoolean(false);
            else
                return Convert.ToBoolean(varIn);
        }
        public static bool NullFilter_Boolean_IntOrByte(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return Convert.ToBoolean(false);
            else
                return Convert.ToBoolean(varIn);
        }
        public static Double NullFilter_Float(Object varIn)
        {
            try
            {
                if (varIn == System.DBNull.Value || varIn == null)
                    return Convert.ToDouble(0);
                else
                    return (Double)varIn;
            }
            catch (Exception)
            {
                return Convert.ToDouble(0);
            }
        }
        public static Double NullFilter_Double(Object varIn)
        {
            try
            {
                if (varIn == System.DBNull.Value || varIn == null)
                    return Convert.ToDouble(0);
                else
                    return Convert.ToDouble(varIn);
            }
            catch (Exception)
            { return Convert.ToDouble(0); }
        }
        public static Int64 NullFilter_Long(Object varIn)
        {
            return NullFilter_Int64(varIn);
        }
        public static Int64 NullFilter_Int64(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return Convert.ToInt64(0);
            else
                return Convert.ToInt64(varIn);
        }
        public static DateTime NullFilter_Date(Object varIn)
        {
            return NullFilter_DateTime(varIn);
        }
        public static DateTime NullFilter_DateTime(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return Tools.Dates.NullDate;
            else
                return (DateTime)varIn;
        }

        public static String NullFilter(Object x)
        {
            return NullFilter_String(x);
        }

        public static Object NullFilter(String s, FieldType t)
        {
            try
            {
                switch (t)
                {
                    case FieldType.String:
                    case FieldType.Text:
                        return (Object)s;
                    case FieldType.Int32:
                        return (Object)Convert.ToInt32(s);
                    case FieldType.Int64:
                        return (Object)Convert.ToInt64(s);
                    case FieldType.Double:
                        return (Object)Convert.ToDouble(s);
                    case FieldType.Boolean:
                        return (Object)Convert.ToBoolean(s);
                    case FieldType.DateTime:
                        return (Object)Convert.ToDateTime(s);
                }
            }
            catch (Exception)
            {
            }

            return nData.GetNullValue(t);
        }
        public static Object GetNullValue(FieldType t)
        {
            try
            {
                switch (t)
                {
                    case FieldType.String:
                    case FieldType.Text:
                        return (Object)"";
                    case FieldType.Int32:
                        return (Object)Convert.ToInt32(0);
                    case FieldType.Int64:
                        return (Object)Convert.ToInt64(0);
                    case FieldType.Double:
                        return (Object)Convert.ToDouble(0);
                    case FieldType.Boolean:
                        return (Object)Convert.ToBoolean(false);
                    case FieldType.DateTime:
                        return (Object)Convert.ToDateTime(Tools.Dates.GetNullDate());
                }
            }
            catch (Exception)
            {}

            return null;
        }
        public static Object NullFilter(Object o, FieldType t)
        {
            try
            {
                if (o != null)
                {
                    switch (t)
                    {
                        case FieldType.String:
                        case FieldType.Text:
                            return o;
                        case FieldType.Int32:
                            return (Object)Convert.ToInt32(o);
                        case FieldType.Int64:
                            return (Object)Convert.ToInt64(o);
                        case FieldType.Double:
                            return (Object)Convert.ToDouble(o);
                        case FieldType.Boolean:
                            return (Object)Convert.ToBoolean(o);
                        case FieldType.DateTime:
                            return (Object)Convert.ToDateTime(o);
                    }
                }
            }
            catch (Exception)
            {}
            return nData.GetNullValue(t);
        }
        public static String ReturnCodeNullString(Int32 xType)
        {
            switch (xType)
            {
                case (Int32)FieldType.String:
                case (Int32)FieldType.Text:
                    return "\"\"";
                case (Int32)FieldType.Int32:
                case (Int32)FieldType.Int64:
                case (Int32)FieldType.Double:
                    return "0";
                case (Int32)FieldType.Boolean:
                    return "false";
                case (Int32)FieldType.DateTime:
                    return "\"01/01/1900\"";
                default:
                    return "null";
            }
        }//Added to convert nulls to code defaults

        public static String SyntaxFilterGeneral(String strSQL)
        {
            return strSQL.Replace("'", "''");
        }
    }

    public delegate void SqlFinishedHandler(String sql, Double milliseconds);
}