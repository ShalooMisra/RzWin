using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;

namespace NewMethod
{
    public class ColumnSourceTemplate : ColumnSource
    {
        n_template TheTemplate;
        public ColumnSourceTemplate(n_template template)
        {
            TheTemplate = template;
        }

        public override IEnumerator GetEnumerator()
        {
            return new EnumeratorTemplateColumns(TheTemplate);
        }

        public override int Count
        {
            get
            {
                if (TheTemplate == null)
                    return 0;

                return TheTemplate.AllColumns.Count;
            }
        }
    }

    public class EnumeratorTemplateColumns : IEnumerator
    {
        n_template TheTemplate;
        int ColumnIndex = -1;
        public EnumeratorTemplateColumns(n_template template)
        {
            TheTemplate = template;
        }

        public Object Current
        {
            get
            {
                return new ColumnHandleTemplate((n_column)TheTemplate.AllColumns[ColumnIndex]);
            }
        }

        public void Reset()
        {
            ColumnIndex = 0;
        }

        public bool MoveNext()
        {
            if (TheTemplate == null)
                return false;

            ColumnIndex++;
            return ColumnIndex < TheTemplate.AllColumns.Count;
        }

        public void Dispose()
        {
            TheTemplate = null;
        }
    }


    public class ColumnHandleTemplate : ColumnHandle
    {
        n_column Column;
        public ColumnHandleTemplate(n_column column)
        {
            Column = column;
        }

        public override string Name
        {
            get
            {
                if (Column == null)
                    return "";

                return Column.field_name;
            }
        }

        public override string Caption
        {
            get
            {
                if( Column == null )
                    return "";
                return Column.column_caption;
            }
        }

        public override int WidthPercent
        {
            get
            {
                if( Column == null )
                    return 10;
                return Column.column_width;
            }
        }

        public override string RenderVal(object v)
        {
            if (v == null || v == DBNull.Value)
                return "";

            return Stylizer.RenderVal(v, Column, "$");
        }

        Tools.Database.FieldType m_DataType = Tools.Database.FieldType.Unknown;
        public override Tools.Database.FieldType DataType
        {
            get
            {
                if (Column == null)
                    return Tools.Database.FieldType.String;

                return (Tools.Database.FieldType)Column.data_type;
            }
        }

        public override ColumnAlignment Alignment
        {
            get
            {
                if( Column == null )
                    return base.Alignment;

                switch (Column.column_alignment)
                {
                    case 1:
                        return ColumnAlignment.Right;
                    case 2:
                        return ColumnAlignment.Center;
                    default:
                        return ColumnAlignment.Left;
                }
            }
        }
    }
}
