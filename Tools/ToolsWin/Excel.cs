using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using Tools.Database;

namespace ToolsWin
{
    public static class Excel
    {
        public static void ListViewToExcel(ListView lv)
        {
            ListViewToExcel(lv, null);
        }

        public static void ListViewToExcel(ListView lv, List<FieldType> types)
        {
            String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "Export_" + Tools.Dates.GetNowPathHMS() + ".xlsx";
            ListViewToExcel(file, lv, false, types);
            Tools.FileSystem.Shell(file);
        }

        public static void ListViewToExcel(String file, ListView lv, bool bSelected, List<FieldType> types)
        {
            ExcelPackage package = new ExcelPackage(new FileInfo(file));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
            int z = 1;
            foreach (ColumnHeader h in lv.Columns)
            {
                worksheet.Cells[1, z].Value = h.Text;
                z++;
            }
            int xlRow = 2;
            IEnumerable col = null;
            if (bSelected)
                col = lv.SelectedItems;
            else
                col = lv.Items;
            foreach (ListViewItem i in col)
            {
                object obj = i.Tag;
                for (int c = 1; c <= i.SubItems.Count; c++)
                {                    
                    string txt = i.SubItems[c - 1].Text;
                    if (types != null)
                    {
                        if (types.Count > 0)
                        {
                            try
                            {
                                switch (types[c - 1])
                                {
                                    case FieldType.Int32:
                                        txt = txt.Replace(",", "").Trim();
                                        worksheet.Cells[xlRow, c].Value = Convert.ToInt32(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "#,##0";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                        break;
                                    case FieldType.Int64:
                                        txt = txt.Replace(",", "").Trim();
                                        worksheet.Cells[xlRow, c].Value = Convert.ToInt64(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "#,##0";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                        break;
                                    case FieldType.Double:
                                        txt = txt.Replace("$", "").Replace(",", "").Trim();
                                        worksheet.Cells[xlRow, c].Value = Convert.ToDouble(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "0.00#####";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;
                                        break;
                                    case FieldType.DateTime:
                                        worksheet.Cells[xlRow, c].Value = Convert.ToDateTime(txt);
                                        worksheet.Cells[xlRow, c].Style.Numberformat.Format = "mm/dd/yyyy";
                                        worksheet.Cells[xlRow, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                                        break;
                                    default:
                                        worksheet.Cells[xlRow, c].Value = txt;
                                        break;
                                }
                            }
                            catch
                            {
                                worksheet.Cells[xlRow, c].Value = i.SubItems[c - 1].Text;
                            }
                        }
                        else
                            worksheet.Cells[xlRow, c].Value = i.SubItems[c - 1].Text;
                    }
                    else
                        worksheet.Cells[xlRow, c].Value = i.SubItems[c - 1].Text;
                }
                xlRow++;
            }
            package.Save();
        }
    }
}
