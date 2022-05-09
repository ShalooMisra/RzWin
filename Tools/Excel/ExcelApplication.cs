using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;

using OfficeOpenXml;
using Tools.Database;
using System.Collections;

namespace OfficeInterop
{
    public class ExcelApplication
    {
        private OfficeOpenXml.ExcelPackage Package;

        public ExcelApplication()
        {
            Package = new ExcelPackage();
        }

        public ExcelApplication(String fileXlsx)
        {
            Package = new ExcelPackage(new FileInfo(fileXlsx));
        }

        public ExcelWorkbook Workbook
        {
            get
            {
                return new ExcelWorkbook(Package, Package.Workbook);
            }
        }

        //public void ShowSaveDialog(string fileName)
        //{
        //    this.app.Visible = true;
        //    string fileName2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + fileName;
        //    Microsoft.Office.Interop.Excel.Dialog dialog = this.app.Application.Dialogs[Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogSaveAs];
        //    dialog.Show(fileName2, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel9795, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        //                Type.Missing, Type.Missing, Type.Missing);
        //}

        //public string GetWorkbookName(int workbookIndex)
        //{
        //    return this.app. Workbooks[workbookIndex].Name;
        //}

        //public ExcelWorkbook OpenWorkbooks(string fileName, bool updateLinks, bool readOnly)
        //{
        //    try
        //    {
        //        @app.Load(fileName);
        //        return new ExcelWorkbook(

        //        return new ExcelWorkbook(this.app.Workbooks.Open(fileName, updateLinks, readOnly, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value));
        //    }
        //    catch
        //    {
        //        return new ExcelWorkbook();
        //    }
        //}

        //public ExcelWorkbook AddWorkbook()
        //{
        //    return new ExcelWorkbook(this.app.Workbooks.Add(Type.Missing));
        //}

        public void Quit()
        {
            Package = null;
        }
    }
}

namespace Tools
{
    public static class Excel
    {
        public static void DataTableToExcel(String file, DataTable data, List<String> captions, List<FieldType> types)
        {
            ExcelPackage package = new ExcelPackage(new FileInfo(file));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

            DataTableToSheet(worksheet, data, captions, types);

            package.Save();
        }

        public static void DataTableToSheet(ExcelWorksheet worksheet, DataTable data, List<String> captions, List<FieldType> types)
        {
            Dictionary<int, int> maxWidths = new Dictionary<int, int>();
            int cx = 1;  //1 based for excel
            foreach (DataColumn c in data.Columns)
            {
                maxWidths.Add(cx, c.Caption.Length);
                cx++;
            }

            int xlRow = 1;
            if (captions != null && captions.Count > 0)
            {
                int z = 1;
                foreach (String caption in captions)
                {
                    worksheet.Cells[xlRow, z].Value = caption;
                    z++;
                }

                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Row(1).Style.Font.UnderLine = true;
                worksheet.Row(1).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Row(1).Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);

                xlRow++;
            }
            
            foreach (DataRow r in data.Rows)
            {
                for (int c = 1; c <= data.Columns.Count; c++)
                {
                    Object x = r[c - 1];
                    String txt = "";
                    if (x != null && x != DBNull.Value)
                        txt = x.ToString();

                    int currentMax = maxWidths[c];
                    if (txt.Length > currentMax)
                        maxWidths[c] = txt.Length;

                    if (types != null)
                    {
                        if (types.Count > 0)
                        {
                            try
                            {
                                switch (types[c - 1])
                                {
                                    case FieldType.Int32:
                                        //txt = txt.Replace(",", "").Trim();
                                        worksheet.Cells[xlRow, c].Value = Tools.Data.NullFilterIntegerFromIntOrLong(x);  // Convert.ToInt32(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "#,##0";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                        break;
                                    case FieldType.Int64:
                                        //txt = txt.Replace(",", "").Trim();
                                        worksheet.Cells[xlRow, c].Value = Tools.Data.NullFilterInt64(x);  // Convert.ToInt64(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "#,##0";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                        break;
                                    case FieldType.Double:
                                        //txt = txt.Replace("$", "").Replace(",", "").Trim();
                                        worksheet.Cells[xlRow, c].Value = Tools.Data.NullFilterDoubleFromAny(x);  // Convert.ToDouble(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "0.00#####";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                        break;
                                    case FieldType.DateTime:
                                        if (Tools.Dates.DateExists((DateTime)x))
                                        {
                                            worksheet.Cells[xlRow, c].Value = Tools.Data.NullFilterDate(x);  // Convert.ToDateTime(txt);
                                            worksheet.Cells[xlRow, c].Style.Numberformat.Format = "mm/dd/yyyy";
                                            worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                        }
                                        else
                                            worksheet.Cells[xlRow, c].Value = "";
                                        break;
                                    case FieldType.Boolean:
                                        if(Tools.Data.NullFilterBool(x))
                                            worksheet.Cells[xlRow, c].Value = "Y";
                                        else
                                            worksheet.Cells[xlRow, c].Value = "";
                                        break;
                                    default:
                                        worksheet.Cells[xlRow, c].Value = txt;
                                        break;
                                }
                            }
                            catch
                            {
                                worksheet.Cells[xlRow, c].Value = txt;
                            }
                        }
                        else
                            worksheet.Cells[xlRow, c].Value = txt;
                    }
                    else
                        worksheet.Cells[xlRow, c].Value = txt;
                }
                xlRow++;
            }

            foreach (KeyValuePair<int, int> k in maxWidths)
            {
                if (k.Value < 5)
                    continue;

                int lengthToUse = k.Value;
                if (lengthToUse > 25)
                    lengthToUse = 25;

                ExcelColumn col = worksheet.Column(k.Key);
                col.Width = lengthToUse * 2;
            }
        }
    }
}
