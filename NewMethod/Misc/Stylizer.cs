using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using Tools.Database;

namespace NewMethod
{
    public class Stylizer
    {
        public static string RenderVal(Object val, n_column c, string currency_symbol)
        {
            if (val == DBNull.Value)
                return "";
            if (val == null)
                return "";
            else
            {
                switch (c.data_type)
                {
                    case (Int32)FieldType.DateTime:
                        try
                        {
                            if (!Tools.Dates.DateExists((DateTime)val))
                            {
                                return "";
                            }
                            else
                            {
                                if (Tools.Strings.StrExt(c.column_format))
                                {
                                    //this is not the right place for this
                                    //if (!c.column_format.StartsWith("{"))
                                    //{
                                    //    c.column_format = "{0:d}";
                                    //    SysNewMethod.ContextDefault.Update(c);
                                    //}
                                    return nTools.Format(c.column_format, val);
                                }
                                else
                                {
                                    return nTools.DateFormat(Convert.ToDateTime(val));
                                    //return Convert.ToString(val);
                                }
                            }
                        }
                        catch { return ""; }
                    case (Int32)FieldType.Boolean:
                        switch (c.column_format.ToLower())
                        {
                            case "yn":
                                return nTools.YesNoFilter((Boolean)val);
                            case "yblank":
                                return nTools.YesBlankFilter((Boolean)val);
                            default:
                                return Convert.ToString(val);
                        }
                    default:
                        if (Tools.Strings.StrExt(c.column_format))
                        {
                            switch(c.column_format)
                            {
                                case "{0:C}":
                                case "CURRENCY2":
                                    return currency_symbol + Tools.Strings.Format("{0:###,###,##0.00}", val);
                                case "CURRENCY6":
                                    return currency_symbol + Tools.Strings.Format("{0:###,###,##0.00####}", val);
                                case "gblank":
                                    int x = (int)val;
                                    if (x == 0)
                                        return "";
                                    else
                                        return String.Format("{0:G}", x);
                                default:
                                    //this is not the right place for this
                                    //if (c.column_format.StartsWith("#"))
                                    //{
                                    //    c.column_format = "{0:" + c.column_format + "}";
                                    //    SysNewMethod.ContextDefault.Update(c);
                                    //}
                                    if (c.data_type == (Int32)FieldType.Int32 && c.translate_enum)
                                        return NewMethod.Enums.ConvertEnum.TranslateEnumTypeToString(Convert.ToInt32(val), c.enum_datatype);
                             
                                    return nTools.Format(c.column_format, val);
                            }
                        }
                        else
                            switch (c.data_type)
                            {
                                case (Int32)FieldType.Int32:
                                    if (c.translate_enum)
                                        return NewMethod.Enums.ConvertEnum.TranslateEnumTypeToString(Convert.ToInt32(val), c.enum_datatype);
                                    else
                                        return Tools.Number.LongFormat(Convert.ToInt32(val));
                                case (Int32)FieldType.Int64:
                                    return Tools.Number.LongFormat(Convert.ToInt32(val));
                                case (Int32)FieldType.Double:
                                    if (Tools.Strings.HasString(c.field_name, "unit"))
                                        return currency_symbol + nTools.MoneyFormat_2_6(Convert.ToDouble(val));
                                    else
                                        return currency_symbol + nTools.MoneyFormat(Convert.ToDouble(val));
                                default:
                                    switch (c.field_name.ToLower())
                                    {
                                        case "unitprice":
                                            return currency_symbol + nTools.MoneyFormat_2_6(Convert.ToDouble(val));
                                        case "unitcost":
                                            return currency_symbol + nTools.MoneyFormat_2_6(Convert.ToDouble(val));
                                        case "extendedorder":
                                            return currency_symbol + nTools.MoneyFormat(Convert.ToDouble(val));
                                        case "extendedfilled":
                                            return currency_symbol + nTools.MoneyFormat(Convert.ToDouble(val));
                                        case "totalprofit":
                                            return currency_symbol + nTools.MoneyFormat(Convert.ToDouble(val));
                                        default:
                                            return Convert.ToString(val);
                                    }
                            }
                        break;
                }
            }
        }

    }
}
