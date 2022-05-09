using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;

using Core;
using Tools.Database;

namespace NewMethod
{
    public abstract class Grid
    {
        public abstract String RenderAsHTML();
        public abstract void RenderAsCsv(String file_name, ref long count);
        public abstract void RenderAsXlsx(String file_name, ref long count);
        public bool DateSensitive = false;
        public DateTime DateStart;
        public DateTime DateEnd;
        public String Caption;
        public bool SmallSize = false;
        public bool WrapText = false;
        public abstract List<GridColumn> ColumnsGet();
        //public abstract nCubeSummary CubeSummaryGetAs(String caption, GridColumn name_column, GridColumn value_column);
        //public abstract nCubeSummary CubeSummaryDateGetAs(String caption, GridColumn date_column, GridColumn value_column, Tools.CubeInterval interval);

        public Grid(String caption)
        {
            Caption = caption;
        }
    }

    public class GridColumn
    {
        public String Name = "";
        public FieldType ColumnType = FieldType.Unknown;

        public GridColumn(String name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name + " [" + ColumnType.ToString() + "]";
        }
    }
}
