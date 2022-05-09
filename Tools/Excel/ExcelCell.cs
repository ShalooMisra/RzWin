using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace OfficeInterop
{
    public struct Cell
    {
        public int Row;
        public int Column;
        public object Value;

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.Value = null;
        }

        public Cell(int row, int column, object value)
        {
            this.Row = row;
            this.Column = column;
            this.Value = value;
        }

        public string GetColumnLetterAndRowNumber()
        {
            return ExcelWorksheet.ExcelColumnLetter(this.Column) + Convert.ToString(this.Row);
        }
    }
}
