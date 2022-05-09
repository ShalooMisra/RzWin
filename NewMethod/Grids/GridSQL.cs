using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using OfficeOpenXml;
using Tools.Database;

namespace NewMethod.Grids
{
    public class GridSQL : Grid
    {
        String m_TheSql;
        public String TheSql
        {
            get
            {
                if (DateSensitive)
                    return DateInsert(m_TheSql);
                else
                    return m_TheSql;
            }

            set
            {
                m_TheSql = value;
            }
        }

        public String DateInsert(String sql)
        {
            return sql.Replace("<StartDate>", "'" + nTools.GetDayStart(DateStart).ToString() + "'").Replace("<EndDate>", "'" + nTools.GetDayEnd(DateEnd).ToString() + "'");
        }

        public DataConnectionSqlServer TheData;

        public GridSQL(String the_sql, DataConnectionSqlServer the_data, String caption)
            : base(caption)
        {
            TheSql = the_sql;
            TheData = the_data;
        }

        public override string RenderAsHTML()
        {
            DataTable t = DataTableGet();
            if (!Tools.Data.DataTableExists(t))
            {
                return "<font color=gray>No Results: " + TheSql + "</font>";
            }

            if (SmallSize)
                return "<html><head>" + Tools.Html.GetSmallStyle() + "</head><body><b>" + Caption + "</b><br><hr><br>" + TheData.ConvertSQLToHTML(TheSql, WrapText) + "</body></html>";
            else
                return "<html><head></head><body><b>" + Caption + "</b><br><hr><br>" + TheData.ConvertSQLToHTML(TheSql, WrapText) + "</body></html>";
        }

        public override void RenderAsCsv(string file_name, ref long count)
        {
            TheData.ExportSQLToCsv(TheSql, file_name, ref count);
        }

        public override void RenderAsXlsx(string file_name, ref long count)
        {
            ExcelPackage xlApp = new ExcelPackage(new FileInfo(file_name));
            ExcelWorksheet xlSheet = xlApp.Workbook.Worksheets.Add("Export");

            xlSheet.Cells[1, 1].Value = Caption;

            int i = 3;
            DataTable d = DataTableGet();

            int col = 1;
            foreach (DataColumn c in d.Columns)
            {
                xlSheet.Cells[i, col].Value= c.Caption;
                col++;
            }

            i++;

            foreach (DataRow r in d.Rows)
            {
                col = 1;
                foreach (DataColumn c in d.Columns)
                {
                    xlSheet.Cells[i, col].Value = nData.NullFilter_String(r[col - 1]);
                    col++;
                }
                i++;
            }

            xlApp.Save();
            Tools.FileSystem.Shell(file_name);
        }

        public override List<GridColumn> ColumnsGet()
        {
            DataTable top = TheData.Select(" select top 1 " + Tools.Strings.Mid(TheSql, 7));
            List<GridColumn> ret = new List<GridColumn>();
            foreach (DataColumn c in top.Columns)
            {
                GridColumn gc = new GridColumn(c.Caption);

                switch (c.DataType.Name)
                {
                    case "System.DateTime":
                        gc.ColumnType = FieldType.DateTime;
                        break;
                    case "System.Int16":
                    case "System.Int32":
                        gc.ColumnType = FieldType.Int32;
                        break;
                    case "System.Int64":
                        gc.ColumnType = FieldType.Int64;
                        break;
                    case "System.Decimal":
                    case "System.Double":
                        gc.ColumnType = FieldType.Double;
                        break;
                    default:
                        gc.ColumnType = FieldType.String;
                        break;
                }
                ret.Add(gc);
            }
            return ret;
        }

        //public override nCubeSummary CubeSummaryGetAs(String caption, GridColumn name_column, GridColumn value_column)
        //{
        //    nCubeSeries series = new nCubeSeries();
        //    series.Name = caption;
        //    series.DisplayType = NewMethod.Enums.CubeDataDisplayType.Any;

        //    DataTable d = DataTableGet();
        //    String temp_table = "temp_" + Tools.Strings.GetNewID();
        //    TheData.ImportDataTable(d, temp_table);
        //    d = TheData.GetDataTable("select " + name_column.Name + ", sum(cast(" + value_column.Name + " as float)) from " + temp_table + " group by " + name_column.Name + " order by " + name_column.Name);

        //    foreach (DataRow r in d.Rows)
        //    {
        //        nCubePoint p = null;
        //        p = new nCubePoint();
        //        p.Name = nData.NullFilter_String(r[0]);
        //        p.Value = nData.NullFilter_Double(r[1]);
        //        series.AllPoints.Add(p);
        //    }

        //    d = null;
        //    TheData.DropTable(temp_table);

        //    nCubeSummary sum = new nCubeSummary();
        //    sum.Name = caption;
        //    //sum.YAxisInterval = 10000;
        //    sum.Series.Add(series);
        //    return sum;
        //}

        //public override nCubeSummary CubeSummaryDateGetAs(string caption, GridColumn date_column, GridColumn value_column, Tools.CubeInterval interval)
        //{
        //    nCubeSeries series = new nCubeSeries();
        //    series.Name = caption;
        //    series.DisplayType = NewMethod.Enums.CubeDataDisplayType.Any;

        //    DataTable d = DataTableGet();
        //    String temp_table = "temp_" + Tools.Strings.GetNewID();
        //    TheData.ImportDataTable(d, temp_table);

        //    String temp_2 = "temp_" + Tools.Strings.GetNewID();
        //    List<CubeField> fields = new List<CubeField>();

        //    switch (interval)
        //    {
        //        case Tools.CubeInterval.Year:
        //            fields.Add(new CubeField("year", Tools.CubeInterval.Year));
        //            break;
        //        case Tools.CubeInterval.Month:
        //            fields.Add(new CubeField("year", Tools.CubeInterval.Year));
        //            fields.Add(new CubeField("month", Tools.CubeInterval.Month));
        //            break;
        //    }

        //    String strCreate = "create table " + temp_2 + " ( the_value float, the_caption varchar(255) ";

        //    foreach (CubeField cf in fields)
        //    {
        //        strCreate += ", the_" + cf.Name + " int";
        //    }

        //    strCreate += " ) ";
        //    TheData.Execute(strCreate);

        //    DateTime start = DateStart;
        //    while (start <= DateEnd)
        //    {
        //        String strInsert = "insert into " + temp_2 + " ( the_value, the_caption ";

        //        foreach (CubeField cf in fields)
        //        {
        //            strInsert += ", the_" + cf.Name + " ";
        //        }

        //        strInsert += " ) values ( 0, '" + nTools.DateFormat(start) + "' ";

        //        foreach (CubeField cf in fields)
        //        {
        //            strInsert += ", " + cf.GetIntervalValue(start).ToString() + " ";
        //        }

        //        strInsert += " )";
        //        TheData.Execute(strInsert);

        //        switch (interval)
        //        {
        //            case Tools.CubeInterval.Year:
        //                start = nTools.GetYearEnd(start.Year);
        //                break;
        //            case Tools.CubeInterval.Month:
        //                start = nTools.GetMonthEnd(start);
        //                break;
        //        }

        //        start = nTools.GetDayStart(start.Add(TimeSpan.FromDays(1)));
        //    }

        //    String strUpdate = "update " + temp_2 + " set the_value = (select sum(" + value_column.Name + ") from " + temp_table + " where ";

        //    int i = 0;
        //    foreach (CubeField cf in fields)
        //    {
        //        if (i > 0)
        //            strUpdate += " and ";

        //        strUpdate += " " + temp_2 + ".the_" + cf.Name + " = " + cf.Function + "(" + temp_table + "." + date_column.Name + ") ";
        //        i++;
        //    }

        //    strUpdate += " ) ";

        //    TheData.Execute(strUpdate);

        //    TheData.Execute("update " + temp_2 + " set the_value = 0 where the_value is null");

        //    String strFields = "";
        //    foreach (CubeField cf in fields)
        //    {
        //        if (Tools.Strings.StrExt(strFields))
        //            strFields += ", ";
        //        strFields += " the_" + cf.Name;
        //    }

        //    d = TheData.GetDataTable("select the_caption, the_value from " + temp_2 + " order by " + strFields);

        //    foreach (DataRow r in d.Rows)
        //    {
        //        nCubePoint p = null;
        //        p = new nCubePoint();
        //        p.Name = nData.NullFilter_String(r[0]);
        //        p.Value = nData.NullFilter_Double(r[1]);
        //        series.AllPoints.Add(p);
        //    }

        //    d = null;
        //    TheData.DropTable(temp_table);
        //    TheData.DropTable(temp_2);

        //    nCubeSummary sum = new nCubeSummary();
        //    sum.Name = caption;
        //    //sum.YAxisInterval = 10000;
        //    sum.Series.Add(series);
        //    return sum;
        //}

        public virtual DataTable DataTableGet()
        {
            QueryPre();
            return TheData.Select(TheSql);
        }

        protected virtual void QueryPre()
        {

        }
    }

    public class CubeField
    {
        public String Name;
        public String Function;
        public Tools.CubeInterval Interval;

        public CubeField(String name, Tools.CubeInterval interval)
        {
            Name = name;
            Function = name;
            Interval = interval;
        }

        public int GetIntervalValue(DateTime dt)
        {
            switch (Interval)
            {
                case Tools.CubeInterval.Year:
                    return dt.Year;
                case Tools.CubeInterval.Month:
                    return dt.Month;
                default:
                    return 0;
            }
        }
    }
}
