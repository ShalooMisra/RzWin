using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;

namespace Core
{
    public abstract class ColumnSource : IEnumerable
    {
        public abstract int Count { get; }
        public abstract IEnumerator GetEnumerator();
    }

    public class ColumnSourceTable : ColumnSource
    {
        DataTable Table;
        public ColumnSourceTable(DataTable table)
        {
            Table = table;
        }

        public override IEnumerator GetEnumerator()
        {
            return new EnumeratorTableColumns(Table);
        }

        public override int Count
        {
            get
            {
                if (Table == null)
                    return 0;

                return Table.Columns.Count;
            }
        }
    }

    public class EnumeratorTableColumns : IEnumerator
    {
        DataTable Table;
        int ColumnIndex = -1;
        public EnumeratorTableColumns(DataTable table)
        {
            Table = table;
        }

        public Object Current
        {
            get
            {
                return new ColumnHandleTable(Table.Columns[ColumnIndex]);
            }
        }

        public void Reset()
        {
            ColumnIndex = 0;
        }

        public bool MoveNext()
        {
            if (Table == null)
                return false;

            ColumnIndex++;
            return ColumnIndex < Table.Columns.Count;
        }

        public void Dispose()
        {
            Table = null;
        }
    }

    public class ColumnSourceExplicit : ColumnSource
    {
        List<ColumnHandle> Columns;
        public ColumnSourceExplicit(List<ColumnHandle> columns)
        {
            Columns = columns;
        }

        public override IEnumerator GetEnumerator()
        {
            return Columns.GetEnumerator();
        }

        public override int Count
        {
            get
            {
                return Columns.Count;
            }
        }
    }

    public abstract class ColumnHandle
    {
        public abstract String Name { get; }
        public abstract String Caption { get; }
        public abstract int WidthPercent { get; }
        public abstract String RenderVal(Object v);
        public abstract Tools.Database.FieldType DataType { get; }
        public String Format = "";

        public virtual ColumnAlignment Alignment
        {
            get
            {
                switch (DataType)
                {
                    case Tools.Database.FieldType.Int32:
                    case Tools.Database.FieldType.Int64:
                    case Tools.Database.FieldType.Double:
                        return ColumnAlignment.Right;
                    default:
                        return ColumnAlignment.Left;
                }
            }
        }
    }

    public enum ColumnAlignment
    {
        Left = 0,
        Right = 1,
        Center = 2
    }

    public class ColumnHandleTable : ColumnHandle
    {
        DataColumn Column;
        public ColumnHandleTable(DataColumn column)
        {
            Column = column;
        }

        public override string Name
        {
            get { return Column.Caption; }
        }

        public override string Caption
        {
            get { return Column.Caption; }
        }

        public override int WidthPercent
        {
            get { return 10; }
        }

        public override string RenderVal(object v)
        {
            if (v == null || v == DBNull.Value)
                return "";

            return v.ToString();
        }

        Tools.Database.FieldType m_DataType = Tools.Database.FieldType.Unknown;
        public override Tools.Database.FieldType DataType
        {            
            get
            {
                if (m_DataType == Tools.Database.FieldType.Unknown)
                {
                    if (Column.DataType == typeof(Int32))
                        m_DataType = Tools.Database.FieldType.Int32;
                    else if (Column.DataType == typeof(Int64))
                        m_DataType = Tools.Database.FieldType.Int64;
                    else if (Column.DataType == typeof(Double))
                        m_DataType = Tools.Database.FieldType.Double;
                    else if (Column.DataType == typeof(DateTime))
                        m_DataType = Tools.Database.FieldType.DateTime;
                    else if (Column.DataType == typeof(Boolean))
                        m_DataType = Tools.Database.FieldType.Boolean;
                    else
                        m_DataType = Tools.Database.FieldType.String;
                }

                return m_DataType;
            }
        }
    }

    public class ColumnHandleExplicit : ColumnHandle
    {
        String m_Name;
        String m_Caption;
        Tools.Database.FieldType m_DataType = Tools.Database.FieldType.Unknown;

        public ColumnHandleExplicit(String name)
            : this(name, name, Tools.Database.FieldType.String)
        {
        }

        public ColumnHandleExplicit(String name, Tools.Database.FieldType dataType)
            : this(name, name, dataType)
        {
        }

        public ColumnHandleExplicit(String name, String caption, Tools.Database.FieldType dataType)
        {
            m_Name = name;
            m_Caption = caption;
            m_DataType = dataType;
        }

        public override string Name
        {
            get { return m_Name; }
        }

        public override string Caption
        {
            get { return m_Caption; }
        }

        public override int WidthPercent
        {
            get { return 10; }
        }

        public override string RenderVal(object v)
        {
            if (v == null || v == DBNull.Value)
                return "";
            if (v is Boolean)
                return Tools.Strings.YesBlankFilter((bool)v);
            if (v is DateTime)
            {
                if (Format == "")
                    return Tools.Dates.DateFormat((DateTime)v);
                else
                    return String.Format(Format, (DateTime)v);
            }
            return v.ToString();
        }
        
        public override Tools.Database.FieldType DataType
        {            
            get
            {
                return m_DataType;
            }
        }
    }
}
