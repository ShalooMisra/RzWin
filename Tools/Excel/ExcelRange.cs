using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
//using Excel = Microsoft.Office.Interop.Excel;
//using XL = Excel;

namespace OfficeInterop
{
    public class ExcelRange
    {

        private OfficeOpenXml.ExcelRange range;
        public Cell RangeStart;
        public Cell @RangeEnd;

        public ExcelRange(OfficeOpenXml.ExcelRange xlRange)
        {
            this.range = xlRange;
        }

        public void SetRangeFormat(string format)
        {
            //this.range.NumberFormat = format;
        }

        //public ExcelRange EntireColumn
        //{
        //    get
        //    {
        //        return new ExcelRange(this.range.Worksheet.Cells[1, range.Start.Column, OfficeOpenXml.);
        //        return null;
        //    }
        //}

        //public int ColumnWidth
        //{
        //    get
        //    {
        //        return (int)this.range.C;
        //    }

        //    set
        //    {
        //        this.range.ColumnWidth = value;
        //    }
        //}

        //public void ColumnAutoFit()
        //{
        //    this.range.EntireColumn.AutoFit();
        //}

        public Cell GetCell(int rowIndex, int columnIndex)
        {
            Cell cell = new Cell(rowIndex, columnIndex);
            cell.Value = this.range[rowIndex, columnIndex].Value;
            return cell;
        }

        //public Cell GetCell(int rowIndex, string columnString)
        //{
        //    int columnIndex = (int)this.range.Columns[columnString];

        //    return GetCell(rowIndex, columnIndex);
        //}

        public ExcelXlHAlign HorizontalAlignment
        {
            get
            {
                return (ExcelXlHAlign)this.range.HorizontalAlignment;
            }
            set
            {
                this.range.HorizontalAlignment = (Microsoft.Office.Interop.Excel.XlHAlign)value;
            }
        }

        public void BorderAround(ExcelXlLineStyle lineSytle, ExcelBorderWeight weight, ExcelXlColorIndex colorIndex1, ExcelXlColorIndex colorIndex2)
        {
            this.range.Cells.BorderAround((Microsoft.Office.Interop.Excel.XlLineStyle)lineSytle, (Microsoft.Office.Interop.Excel.XlBorderWeight)weight,
                                          (Microsoft.Office.Interop.Excel.XlColorIndex)colorIndex1, (Microsoft.Office.Interop.Excel.XlColorIndex)colorIndex2);
        }

        public object InteriorColorIndex
        {
            get
            {
                return this.range.Interior.ColorIndex;
            }
                        set
            {
                this.range.Interior.ColorIndex = value;
            }
        }

        public ExcelFont Font
        {
            get
            {
                return new ExcelFont(this.range);
            }
            set
            {
                //this.range.Font = value;
            }
        }

        public object RangeValue
        {
            get
            {
                return this.range.Cells.Value;
            }
        }

        public object RangeValue2
        {
            get
            {
                return this.range.Cells.Value2;
            }
        }
    }

}
