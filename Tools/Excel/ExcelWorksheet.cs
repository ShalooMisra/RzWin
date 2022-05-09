using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;

using OfficeOpenXml;

namespace OfficeInterop
{
    public class ExcelWorksheet
    {
        public String SheetName = "";
        private OfficeOpenXml.ExcelWorksheet Worksheet;

        public ExcelWorksheet(OfficeOpenXml.ExcelWorksheet worksheet)
        {
            Worksheet = worksheet;
            SheetName = worksheet.Name;
        }

        public void FormatCells(System.Drawing.Font font, ExcelRange range)
        {

        }

        public void FormatCells(System.Drawing.Font font, Cell[] cells)
        {

        }

        public Cell get_Cell(int row, int column)
        {
            OfficeOpenXml.ExcelRange range = this.Worksheet.Cells[row, column];
            return new Cell()
            {
                Row = row,
                Column = column,
                Value = range.Value
            };
        }

        public object GetCellValue(int row, int column)
        {
            try
            {
                return Worksheet.Cells[row, column].Value;
            }
            catch { return ""; }
            //Excel.Range range = this.worksheet.get_Range(index, columnIndex);
            //return range.Value2;
        }

        public void SetCellValue(int row, int column, object value)
        {
            try
            {
                Worksheet.Cells[row, column].Value = value;
            }
            catch { }
        }

        public void SetCellValue(int row, int column, object value, string format)
        {
            try
            {
                Worksheet.Cells[row, column].Value = value;                
            }
            catch { }
        }

        public ExcelRange get_Range(Cell cell1, Cell cell2)
        {
            return Worksheet.Cells[cell1.Row, cell1.Column, cell2.Row, cell2.Column];
        }

        public ExcelRange get_Range(Cell cell1)
        {
            return Worksheet.Cells[cell1.Row, cell1.Column];
        }

        public ExcelRange get_Range(int row, int column)
        {
            return get_Range(new Cell() { Row = row, Column = column });
        }

        public void UsedRangeFind(ref int lastCol, ref int lastRow)
        {
            if (Worksheet.Dimension == null)
            {
                lastCol = 0;
                lastRow = 0;
                return;
            }

            ExcelCellAddress end = Worksheet.Dimension.End;
            lastCol = end.Column;
            lastRow = end.Row;
        }

        //public int get_ColumnIndex(string columnName)
        //{
        //    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)this.worksheet.Columns[columnName];
        //    return range.Column;
        //}

        //public void PrintOut()
        //{
        //    this.worksheet.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        //        Type.Missing, Type.Missing, Type.Missing);

        //}

        //private void AppendRow(ExcelWorksheet xlSheet, string fileName)
        //{
        //    int numRows = this.worksheet.Rows.Count;
        //    Microsoft.Office.Interop.Excel.Range range = this.worksheet.get_Range(this.worksheet.Cells[numRows, 1], Type.Missing);
        //    Microsoft.Office.Interop.Excel.Range lastRow = range.EntireRow;
        //    lastRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
        //}

        public static string ExcelColumnLetter(int columnIndex)
        {
            if (columnIndex > 16384)
            {
                throw new Exception("Index exceeds maximum columns allowed.");
            }
            if (columnIndex <= 26)
                return ((char)(columnIndex + 64)).ToString();
            columnIndex--;
            return ExcelColumnLetter(columnIndex / 26) + ExcelColumnLetter((columnIndex % 26) + 1);
        }

        //public ExcelRange Cells
        //{
        //    get
        //    {
        //        return (ExcelRange)this.worksheet.Cells;
        //    }
        //}

        //public string CellsNumberFormat
        //{
        //    get
        //    {
        //        return (string)this.Worksheet.Cells.Number
        //    }
        //    set
        //    {
        //        this.worksheet.Cells.NumberFormat = value;
        //    }
        //}


        //public ExcelRange Columns
        //{
        //    get
        //    {
        //        return (ExcelRange)this.worksheet.Columns;
        //    }
        //}

        //public int UsedRows
        //{
        //    get
        //    {
        //        return Worksheet.Used UsedRange.Rows.Count;
        //    }
        //}

        //public int UsedColumns
        //{
        //    get
        //    {
        //        return this.worksheet.UsedRange.Columns.Count;
        //    }
        //}

        //public void Replace(String find, String replace)
        //{

        //}
    }
}

