using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace OfficeInterop
{
    public enum ExcelXlColorIndex
    {
        Auto = OfficeOpenXml.Style.ExcelFont Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
        None = Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexNone
    }

    public enum ExcelFileFormat
    {
        CSV = Microsoft.Office.Interop.Excel.XlFileFormat.xlCSV,
        XLS9795 = Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795
    }

    public enum ExcelXlHAlign
    {
        Center = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter,
        Left = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft,
        Right = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight
    }

    public enum ExcelXlLineStyle
    {
        Continuous = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
    }

    public enum ExcelBorderWeight
    {
        Thin = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin
    }

    public enum ExcelSaveAsAccess
    {
        Exclusive = Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
        NoChange = Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange
    }
}
