using System;
using System.Collections;
using System.Text;
using Tools.Database;

using Core;

namespace NewMethod
{
    public partial class n_column : n_column_auto
    {
        public int ActualWidth = 0;
        public int ActualHeight = 0;

        //Public Functions
        public void AbsorbProp(CoreVarValAttribute p)
        {
            field_name = p.Name;
            column_caption = p.Caption;
            data_type = (Int32)p.TheFieldType;
            is_enum = false;
            enum_datatype = "";
            switch (p.TheFieldType)
            {
                case FieldType.Boolean:
                    column_width = 3;
                    column_alignment = 2;
                    column_format = "yblank";
                    break;
                case FieldType.DateTime:
                    column_width = 6;
                    column_alignment = 2;
                    column_format = "{0:d}";
                    break;
                case FieldType.Int32:
                case FieldType.Int64:
                    column_width = 6;
                    column_alignment = 1;
                    column_format = "{0:G}";
                    break;
                case FieldType.Double:
                    column_width = 6;
                    column_alignment = 1;
                    column_format = "{0:###,###,##0.00####}";
                    break;
                default:
                    column_width = 20;
                    column_alignment = 0;
                    column_format = "";
                    break;
            }            
        }
        public string GetAsName()
        {
            if (Tools.Strings.StrExt(this.function_name))
                return this.relate_class + "_" + this.relate_name + "_" + this.field_name + "_" + this.function_name;
            else
                return this.relate_class + "_" + this.relate_name + "_" + this.field_name;
        }
        public int GetActualWidth(int lngTotal)
        {
            Double dblFactor = 0;

            if( column_width > 0 )
                dblFactor = Convert.ToDouble(column_width) / 100.0;
            else
                dblFactor = 0.1;

            return Convert.ToInt32(lngTotal * dblFactor);
        }

        public System.Windows.Forms.HorizontalAlignment TextAlign
        {
            get
            {
                switch (column_alignment)
                {
                    case 2:
                        return System.Windows.Forms.HorizontalAlignment.Center;
                    case 1:
                        return System.Windows.Forms.HorizontalAlignment.Right;
                    default:
                        return System.Windows.Forms.HorizontalAlignment.Left;
                }
            }

            set
            {
                switch (value)
                {
                    case System.Windows.Forms.HorizontalAlignment.Center:
                        column_alignment = 2;
                        break;
                    case System.Windows.Forms.HorizontalAlignment.Right:
                        column_alignment = 1;
                        break;
                    default:
                        column_alignment = 0;
                        break;
                }
            }
        }

        public bool IsNumeric()
        {
            switch (data_type)
            {
                case (Int32)FieldType.Int32:
                    return true;
                case (Int32)FieldType.Int64:
                    return true;
                case (Int32)FieldType.Double:
                    return true;
            }
            return false;
        }

        public bool RightAlign
        {
            get
            {
                return IsNumeric() || TextAlign == System.Windows.Forms.HorizontalAlignment.Right;
            }
        }
    }
}
