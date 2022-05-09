using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using OfficeOpenXml;
using Tools.Database;
using System.Reflection;

namespace Tools
{
    public static class Data
    {
        public static bool DataTableExists(DataTable d)
        {
            if (d == null)
                return false;
            if (d.Rows.Count <= 0)
                return false;
            return true;
        }
        public static String GetIn(List<String> a)
        {
            StringBuilder sb = new StringBuilder();
            int x = 0;
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(s))
                {
                    if (x > 0)
                        sb.Append(", ");
                    sb.Append("'" + s.Replace("'", "''") + "'");
                    x++;
                }
            }
            return sb.ToString();
        }
        public static String GetIn(ArrayList a, bool include_blank = false)
        {
            StringBuilder sb = new StringBuilder();
            int x = 0;
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(s))
                {
                    if (x > 0)
                        sb.Append(", ");
                    sb.Append("'" + s.Replace("'", "''") + "'");
                    x++;
                }
                else if (include_blank)
                {
                    if (x > 0)
                        sb.Append(", ");
                    sb.Append("''");
                    x++;
                }
            }
            return sb.ToString();
        }
        public static String GetIn(String[] a, bool includeBlanks = false)
        {
            StringBuilder sb = new StringBuilder();
            int x = 0;
            foreach (String s in a)
            {
                if (Tools.Strings.StrExt(s) || includeBlanks)
                {
                    if (x > 0)
                        sb.Append(", ");
                    sb.Append("'" + s.Replace("'", "''") + "'");
                    x++;
                }
            }
            return sb.ToString();
        }
        public static String GetIn_Integer(ArrayList a)
        {
            StringBuilder sb = new StringBuilder();
            int x = 0;
            foreach (int i in a)
            {
                if (x > 0)
                    sb.Append(", ");
                sb.Append(i.ToString());
                x++;
            }
            return sb.ToString();
        }
        public static ArrayList ConvertToArray(SortedList s)
        {
            ArrayList a = new ArrayList();
            foreach (DictionaryEntry d in s)
            {
                a.Add(d.Value);
            }
            return a;
        }
        public static String BoolToYN(bool b)
        {
            //changed from T and F  2009/10/19

            if (b)
                return "Y";
            else
                return "N";
        }

        public static String BoolTo10(bool b)
        {
            if (b)
                return "1";
            else
                return "0";
        }

        public static byte[] FromHex(string s)
        {
            try
            {
                //s = Regex.Replace(s.ToUpper(), "[^0-9A-F]", "");
                byte[] b = new byte[s.Length / 2];
                for (int i = 0; i < s.Length; i += 2)
                    b[i / 2] = byte.Parse(s.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                return b;
            }
            catch (Exception)
            {
                return new Byte[1];
            }
        }
        public static String DecodeBinaryString(Byte[] b, String strEncoding)
        {
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(strEncoding);
            return encoding.GetString(b);
        }
        public static bool IsInCollection(String strFind, SortedList s)
        {
            Object o = s[strFind];
            return (o != null);

        }
        public static void AppendArray(ArrayList container, ArrayList contents)
        {
            foreach (Object x in contents)
            {
                container.Add(x);
            }
        }
        public static String NullFilterString(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return "";
            else
                return varIn.ToString();
        }
        public static DateTime NullFilterDate(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return Tools.Dates.NullDate;
            else
                return (DateTime)varIn;
        }
        public static Double NullFilterDouble(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return 0;
            else
                return (Double)varIn;
        }

        public static Double NullFilterDoubleFromAny(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return 0;
            else
                return Convert.ToDouble(varIn);
        }

        public static Int32 NullFilterInt(Object varIn)
        {
            return NullFilterInteger(varIn);
        }
        public static Int32 NullFilterInteger(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return 0;
            else
                return Convert.ToInt32(varIn);
        }

        public static Decimal NullFilterDecimal(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return 0;
            else
                return (Decimal)varIn;
        }

        public static Int64 NullFilterInt64(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return 0;
            else
                return (Int64)varIn;
        }
        public static Int32 NullFilterIntegerFromIntOrLong(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return 0;
            else
                return Convert.ToInt32(varIn);
        }
        public static bool NullFilterBool(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return false;
            else
                return (bool)varIn;
        }

        public static bool NullFilterBoolFromBoolOrInt(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return false;
            else
            {
                if (varIn is int)
                    return ((int)varIn) > 0;
                else
                    return (bool)varIn;
            }
        }
        public static void SqlToExcel(Tools.Database.DataConnection con, String sql)
        {
            String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "Export_" + Tools.Dates.GetNowPathHMS() + ".xlsx";
            SqlToExcel(con, sql, file, true);
        }
        public static void SqlToExcel(Tools.Database.DataConnection con, String sql, String file, bool show)
        {
            DataTable table = con.Select(sql);

            ExcelPackage package = new ExcelPackage(new FileInfo(file));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

            int z = 1;
            foreach (DataColumn col in table.Columns)
            {
                worksheet.Cells[1, z].Value = col.Caption;
                z++;
            }

            int xlRow = 2;

            foreach (DataRow r in table.Rows)
            {
                int c = 1;
                foreach (DataColumn col in table.Columns)
                {
                    Object value = r[col.Caption];
                    if (value == null || value == DBNull.Value)
                    {
                    }
                    else
                    {
                        if( value is DateTime )
                        {
                            if( Tools.Dates.DateExists((DateTime)value) )
                                worksheet.Cells[xlRow, c].Value = Tools.Dates.DateFormat((DateTime)value);
                        }
                        else if( value is Boolean )
                        {
                            if ((bool)value)
                                worksheet.Cells[xlRow, c].Value = "Y";
                        }
                        else
                        {
                            worksheet.Cells[xlRow, c].Value = value;
                        }
                    }
                    c++;
                }
                xlRow++;
            }

            package.Save();

            if( show )
                Tools.FileSystem.Shell(file);
        }

        public static Object GetTestValueProgressive(FieldType type, Int32 length, int seed)  //guarantees that a successive call will not generate the same value (except for bool)
        {
            switch (type)
            {
                case FieldType.Int32:
                    return (Object)seed;
                case FieldType.Int64:
                    return (Object)Convert.ToInt64(seed * seed);
                case FieldType.Double:
                    return (Object)Convert.ToDouble((seed * seed) + (seed / 10));
                case FieldType.Boolean:
                    return (Object)Tools.Number.GetRandomBoolean();
                case FieldType.DateTime:
                    return (Object)DateTime.Now.Subtract(TimeSpan.FromSeconds(seed));
                default:
                    if (length > 0)
                    {
                        if (length < 30)
                            return (Object)Tools.Strings.Left(Tools.Strings.GetNewID(), length);
                        else
                            return Tools.Strings.GetNewID();
                    }
                    else
                        return (Object)Tools.Strings.GetNewID();
            }
        }

        public static Object GetTestValue(FieldType type, Int32 length)
        {
            switch (type)
            {
                case FieldType.Int32:
                    return (Object)Tools.Number.GetRandomInteger();
                case FieldType.Int64:
                    return (Object)Tools.Number.GetRandomLong();
                case FieldType.Double:
                    return (Object)Tools.Number.GetRandomFloat();
                case FieldType.Boolean:
                    return (Object)Tools.Number.GetRandomBoolean();
                case FieldType.DateTime:
                    return (Object)Tools.Dates.GetRandomDate();
                default:
                    if (length > 0)
                    {
                        if( length < 30 )
                            return (Object)Tools.Strings.Left(Tools.Strings.GetNewID(), length);
                        else
                            return (Object)Tools.Strings.GetNewID();
                    }
                    else
                        return (Object)Tools.Strings.GetNewID();
            }
        }

        public static FieldType FieldTypeFromString(String fieldTypeString)
        {
            return (FieldType)Enum.Parse(Type.GetType("Tools.Database.FieldType"), fieldTypeString);
        }
        
        public static class ListtoDataTable
        {
            public static DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties by using reflection   
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names  
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {

                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

                return dataTable;
            }
        }


    }
}
