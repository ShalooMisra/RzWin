using System;
using System.Collections;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.OleDb;
using OfficeOpenXml;

using Core;
using NewMethod;
using Tools.Database;

namespace NewMethod
{
    public static class Excel
    {
        public static void DataTableToExcel(DataTable d, n_template t)
        {
            String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "Export_" + Tools.Dates.GetNowPathHMS() + ".xlsx";
            DataTableToExcel(file, d, t, "Export");
            Tools.FileSystem.Shell(file);
        }
        public static void DataTableToExcel(String file, DataTable d, n_template t, String sheetName)
        {
            DataTableToExcel(file, new RowSourceTable(d), t, sheetName);
        }
        public static void DataTableToExcel(String file, RowSource d, n_template t, String sheetName)
        {
            ExcelPackage package = new ExcelPackage(new FileInfo(file));
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);

            int z = 1;
            foreach (DictionaryEntry col in t.AllColumns)
            {
                n_column c = (n_column)col.Value;
                worksheet.Cells[1, z].Value = c.column_caption;
                z++;
            }

            int xlRow = 2;

            foreach (RowHandle h in d)
            {
                int c = 1;
                foreach (DictionaryEntry col in t.AllColumns)
                {
                    Object value = h.Value(((n_column)col.Value).field_name);
                    if (value == null || value == DBNull.Value)
                    {
                    }
                    else
                    {
                        switch (((n_column)col.Value).data_type)
                        {
                            case (int)FieldType.DateTime:
                                if( Tools.Dates.DateExists((DateTime)value) )
                                    worksheet.Cells[xlRow, c].Value = Tools.Dates.DateFormat((DateTime)value);
                                break;
                            case (int)FieldType.Boolean:
                                if ((bool)value)
                                    worksheet.Cells[xlRow, c].Value = "Y";
                                break;
                            default:
                                worksheet.Cells[xlRow, c].Value = value;
                                break;
                        }
                    }
                    c++;
                }
                xlRow++;
            }

            package.Save();
            package.Dispose();
        }
    }
}

//namespace ToolsOffice
//{
//    public static class ExcelOffice
//    {
//        //Public Static Variables
//        public static bool largeColumnSupport = false;
//        //Private Static Variables
//        private static Exception lastException = null;

//        //Public Static Functions
//        public static bool Excel2CSV(ContextNM context, string sourceFile)
//        {
//            if (System.IO.File.Exists(sourceFile) == false)
//            {
//                throw new Exception("Excel file " + sourceFile + "could not be found.");
//            }
//            string filedir = System.IO.Path.GetDirectoryName(sourceFile);

//            return Excel2CSV(context, sourceFile, filedir);
//        }
//        public static bool Excel2CSV(ContextNM context, string sourceFile, string targetDir)
//        {
//            if (!System.IO.File.Exists(sourceFile))
//                throw new Exception("Excel file " + sourceFile + "could not be found.");

//            return ReadExcel(context, sourceFile, targetDir);
//        }
//        //public static Exception GetLastError()
//        //{
//        //    return lastException;
//        //}
//        //public static ExcelApplication ExportSQLToExcel(n_sys xs, String strSQL, bool show)
//        //{
//        //    return ExportSQLToExcel(xs, strSQL, "c:\\" + Tools.Strings.GetNewID() + ".xls", show);
//        //}
//        //public static ExcelApplication ExportSQLToExcel(n_sys xs, String strSQL, String strFile, bool show)
//        //{
//        //    DataTable d = xs.xData.Select(strSQL);
//        //    if (!nTools.DataTableExists(d))
//        //        return null;

//        //    return ExportTableToExcel(d, strFile, show);
//        //}
//        //public static ExcelApplication ExportTableToExcel(DataTable t, bool show)
//        //{
//        //    return ExportTableToExcel(t, "c:\\" + Tools.Strings.GetNewID() + ".xls", show);
//        //    //return ExportTableToExcel(t, Environment.SpecialFolder.MyDocuments + Tools.Strings.GenerateRandomName("","") + ".xls", show);

//        //}
//        //public static ExcelApplication ExportTableToExcel(DataTable t, String strFile, bool show)
//        //{
//        //    if (System.IO.File.Exists(strFile))
//        //    {
//        //        if (!context.TheLeader.AskYesNo("The file " + strFile + " already exists.  Do you want to overwrite it?"))
//        //            return null;

//        //        try
//        //        {
//        //            System.IO.File.Delete(strFile);
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            context.TheLeader.Tell("There was an error trying to remove the previous copy of " + strFile + ": " + ex.Message);
//        //            return null;
//        //        }
//        //    }

//        //    try
//        //    {
//        //        ExcelApplication xlApp = new ExcelApplication();
//        //        ExcelWorkbook xlBook;

//        //        if (System.IO.File.Exists("c:\\xls.xls"))
//        //        {
//        //            xlBook = xlApp.OpenWorkbooks("c:\\xls.xls", false, false);
//        //        }
//        //        else
//        //        {
//        //            xlBook = xlApp.AddWorkbook();
//        //        }

//        //        xlBook.SaveAs(strFile, ExcelSaveAsAccess.Exclusive);
//        //        ExcelWorksheet xlSheet = xlBook.get_Worksheet(1);

//        //        int i = 1;
//        //        foreach (DataColumn c in t.Columns)
//        //        {
//        //            xlSheet.SetCellValue(1, i, c.Caption);
//        //            i++;
//        //        }

//        //        int j = 2;
//        //        foreach (DataRow r in t.Rows)
//        //        {
//        //            i = 1;
//        //            foreach (DataColumn c in t.Columns)
//        //            {
//        //                Object o = r[i - 1];
//        //                if (o != null)
//        //                {
//        //                    if (o.ToString().StartsWith("="))
//        //                        xlSheet.SetCellValue(j, i, "<eq>" + o.ToString());
//        //                    else
//        //                        xlSheet.SetCellValue(j, i, o.ToString());
//        //                }

//        //                i++;
//        //            }
//        //            j++;
//        //        }

//        //        xlBook.Save();

//        //        if (show)
//        //        {
//        //            xlApp.Visible = true;
//        //            return xlApp;
//        //        }
//        //        else
//        //        {
//        //            CloseExcel(xlApp, xlBook, xlSheet);
//        //            return null;
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        context.TheLeader.Error(ex.Message);
//        //        return null;
//        //    }
//        //}
//        //public static void CloseExcel(ExcelApplication xlApp, ExcelWorkbook xlBook, ExcelWorksheet xlSheet)
//        //{
//        //    context.TheLeader.Comment("Closing Excel...");
//        //    System.Object missingValue = System.Reflection.Missing.Value;

//        //    try
//        //    {
//        //        xlSheet = null;

//        //        if (xlBook != null)
//        //            xlBook.Close(false);

//        //        if (xlApp != null)
//        //        {
//        //            xlApp.Quit();
//        //        }

//        //        if (xlSheet != null)
//        //            Marshal.ReleaseComObject(xlSheet);

//        //        if (xlBook != null)
//        //            Marshal.ReleaseComObject(xlBook);

//        //        if (xlApp != null)
//        //            Marshal.ReleaseComObject(xlApp);

//        //        xlSheet = null;
//        //        xlBook = null;
//        //        xlApp = null;

//        //        GC.GetTotalMemory(false);
//        //        GC.Collect();
//        //        GC.WaitForPendingFinalizers();
//        //        GC.Collect();
//        //        GC.GetTotalMemory(true);

//        //    }
//        //    catch (Exception)
//        //    { }
//        //}
//        //public static ExcelWorksheet GetExcelWorksheet(String strFile, String sheet)
//        //{
//        //    ExcelApplication xlApp = new ExcelApplication();
//        //    ExcelWorkbook xlBook = null;
//        //    if (System.IO.File.Exists(strFile))
//        //        xlBook = xlApp.OpenWorkbooks(strFile, false, false);
//        //    if (xlBook == null)
//        //        return null;
//        //    ExcelWorksheet sht = null;
//        //    try { sht = xlBook.get_Worksheet(sheet); }
//        //    catch { }
//        //    return sht;
//        //}
//        //public static ExcelApplication ExportListViewToExcel(ListView lv)
//        //{
//        //    return ExportListViewToExcel(lv, true, false);
//        //}
//        //public static ExcelApplication ExportListViewToExcel(ListView lv, Boolean bShow)
//        //{
//        //    return ExportListViewToExcel(lv, bShow, false);
//        //}
//        //public static ExcelApplication ExportListViewToExcel(ListView lv, Boolean bShow, Boolean bOnlySelected)
//        //{
//        //    try
//        //    {
//        //        String driveletter = nTools.GetDriveLetter();

//        //        //String strFile = driveletter + ":\\" + Tools.Strings.GetNewID() + ".xls";

//        //        String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + Tools.Strings.GetNewID() + ".xls";
//        //        ExcelApplication xlApp = new ExcelApplication();
//        //        ExcelWorkbook xlBook;

//        //        if (System.IO.File.Exists(driveletter + ":\\xls.xls"))
//        //        {
//        //            xlBook = xlApp.OpenWorkbooks(driveletter + ":\\xls.xls", false, false);
//        //        }
//        //        else
//        //        {
//        //            xlBook = xlApp.AddWorkbook();
//        //        }

//        //        xlBook.SaveAs(strFile, ExcelSaveAsAccess.Exclusive);
//        //        ExcelWorksheet xlSheet = xlBook.get_Worksheet(1);

//        //        int i = 1;
//        //        foreach (ColumnHeader c in lv.Columns)
//        //        {
//        //            xlSheet.SetCellValue(1, i, c.Text);
//        //            i++;
//        //        }

//        //        int j = 2;
//        //        if (bOnlySelected)
//        //        {
//        //            foreach (ListViewItem li in lv.SelectedItems)
//        //            {
//        //                i = 1;
//        //                foreach (ColumnHeader c in lv.Columns)
//        //                {
//        //                    Object o = li.SubItems[i - 1].Text;
//        //                    if (o != null)
//        //                    {
//        //                        if (o.ToString().StartsWith("="))
//        //                            xlSheet.SetCellValue(j, i, "<eq>" + o.ToString());
//        //                        else
//        //                            xlSheet.SetCellValue(j, i, o.ToString());
//        //                    }

//        //                    i++;
//        //                }
//        //                j++;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            foreach (ListViewItem li in lv.Items)
//        //            {
//        //                i = 1;
//        //                foreach (ColumnHeader c in lv.Columns)
//        //                {
//        //                    Object o = li.SubItems[i - 1].Text;
//        //                    if (o != null)
//        //                    {
//        //                        if (o.ToString().StartsWith("="))
//        //                            xlSheet.SetCellValue(j, i, "<eq>" + o.ToString());
//        //                        else
//        //                            xlSheet.SetCellValue(j, i, o.ToString());
//        //                    }

//        //                    i++;
//        //                }
//        //                j++;
//        //            }
//        //        }
//        //        xlBook.Save();

//        //        xlApp.Visible = bShow;
//        //        return xlApp;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        context.TheLeader.Error(ex.Message);
//        //        return null;
//        //    }
//        //}
//        //public static void ShowInExcel(String strFile)
//        //{
//        //    try
//        //    {
//        //        ExcelApplication xlApp = new ExcelApplication();
//        //        ExcelWorkbook xlBook;
//        //        xlBook = xlApp.OpenWorkbooks(strFile, false, false);
//        //        xlApp.Visible = true;
//        //    }
//        //    catch (Exception)
//        //    { }
//        //}
//        //public static bool SaveAsCSV(String strFile)
//        //{
//        //    try
//        //    {
//        //        String strNew = Tools.Folder.ConditionFolderName(Path.GetDirectoryName(strFile)) + Path.GetFileNameWithoutExtension(strFile) + ".csv";
//        //        if (File.Exists(strNew))
//        //        {
//        //            context.TheLeader.Comment("Save As CSV error: file " + strNew + " already exists.");
//        //            return false;
//        //        }

//        //        ExcelApplication xlApp = new ExcelApplication();
//        //        ExcelWorkbook xlBook;
//        //        xlBook = xlApp.OpenWorkbooks(strFile, false, false);
//        //        xlBook.SaveAs(strNew, ExcelFileFormat.CSV, ExcelSaveAsAccess.NoChange);
//        //        xlBook.Close(false);

//        //        CloseExcel(xlApp, xlBook, null);
//        //        return true;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        context.TheLeader.Comment("Save As CSV error: " + ex.Message);
//        //        return false;
//        //    }
//        //}
//        public static bool Split(ContextNM context, String strFile)
//        {
//            String strUtil = Tools.FileSystem.GetAppPath() + "XLSplit.exe";
//            if (!File.Exists(strUtil))
//            {
//                context.TheLeader.Comment(Tools.FileSystem.GetAppPath() + "XLSplit.exe does not exist.");
//                return false;
//            }

//            return Tools.FileSystem.Shell(strUtil, " -file:" + strFile, null, false, true);
//        }
//        public static ArrayList GetExcelSheetNames(string sourceFile)
//        {
//            bool b = false;
//            System.Data.DataSet ds = null;
//            OleDbConnection conn = null;
//            DataTable tables = null;
//            OleDbDataAdapter adapter = null;
//            OleDbCommand cmd = null;
//            DataTable dt = null;

//            ArrayList a = new ArrayList();

//            try
//            {
//                string filePrefix = System.IO.Path.GetFileNameWithoutExtension(sourceFile);

//                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;";
//                strConnection += " Data Source=" + sourceFile + ";";
//                strConnection += " Extended Properties=\"Excel 8.0;HDR=No;Imex=1;\"";

//                //    IMEX Values
//                //    0 is Export mode
//                //    1 is Import mode
//                //    2 is Linked mode (full update capabilities)

//                conn = new System.Data.OleDb.OleDbConnection(strConnection);
//                conn.Open();

//                tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
//                if (tables == null)
//                    throw new Exception("Sheet names table returned null");

//                if (tables.Rows == null)
//                    throw new Exception("Sheet names rows returned null");

//                foreach (DataRow row in tables.Rows)
//                {
//                    //Check to see if it is loading the print area and ignore if so
//                    string tName = Convert.ToString(row[2]);
//                    if ((tName.IndexOf("$Print_Area") == -1) && (tName.IndexOf("$'Print_Area") == -1))
//                    {
//                        if (tName.StartsWith("'") && tName.EndsWith("'"))  //this is later used with [] so it doesn't need the quotes or escapes
//                        {
//                            tName = Tools.Strings.Mid(tName, 2, tName.Length - 2);
//                            tName = tName.Replace("''", "'");
//                        }

//                        a.Add(tName);
//                    }
//                }
//                conn.Close();
//                return a;
//            }
//            catch (Exception e)
//            {
//                lastException = e;
//                throw e;
//            }
//            finally
//            {
//                try
//                {
//                    if (tables != null)
//                    {
//                        tables.Dispose();
//                        tables = null;
//                    }

//                    if (ds != null)
//                    {
//                        ds.Dispose();
//                        ds = null;
//                    }

//                    if (dt != null)
//                    {
//                        dt.Dispose();
//                        dt = null;
//                    }

//                    if (cmd != null)
//                    {
//                        cmd.Dispose();
//                        cmd = null;
//                    }

//                    if (adapter != null)
//                    {
//                        adapter.Dispose();
//                        adapter = null;
//                    }

//                    if (conn != null)
//                    {
//                        conn.Close();
//                        conn.Dispose();
//                        conn = null;
//                    }
//                }
//                catch (Exception)
//                { }
//            }
//        }
//        public static DataTable OpenExcelAsDataTable(string sourceFile, String strSheet)
//        {
//            //if (Tools.Strings.HasString(strSheet, "'"))
//            //{
//            //    context.TheLeader.Tell("Worksheets cannot be imported if the sheet name contains an apostrophe.  Please remove the apostrophe, save the workbook, and try again.");
//            //    return null;
//            //}

//            bool b = false;
//            System.Data.DataSet ds = null;
//            OleDbConnection conn = null;
//            OleDbDataAdapter adapter = null;
//            OleDbCommand cmd = null;
//            DataTable dt = null;

//            try
//            {
//                string filePrefix = System.IO.Path.GetFileNameWithoutExtension(sourceFile);

//                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;";
//                strConnection += " Data Source=" + sourceFile + ";";
//                strConnection += " Extended Properties=\"Excel 8.0;HDR=No;Imex=1;\"";
//                //    IMEX Values
//                //    0 is Export mode
//                //    1 is Import mode
//                //    2 is Linked mode (full update capabilities)

//                if (Path.GetExtension(sourceFile).ToLower() == ".xlsx")
//                {
//                    strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";Extended Properties=Excel 12.0;HDR=No;Imex=1;";
//                }

//                conn = new System.Data.OleDb.OleDbConnection(strConnection);

//                conn.Open();

//                ds = new DataSet();
//                adapter = new OleDbDataAdapter();
//                string strSelect = "SELECT * FROM [" + strSheet + "]";
//                cmd = new OleDbCommand(strSelect, conn);
//                cmd.CommandType = CommandType.Text;
//                adapter.SelectCommand = cmd;

//                dt = new DataTable();
//                adapter.FillSchema(dt, SchemaType.Source);
//                adapter.Fill(dt);

//                conn.Close();
//                return dt;
//            }
//            catch (Exception e)
//            {
//                lastException = e;
//                return null;
//            }
//            finally
//            {
//                try
//                {
//                    //tables.Dispose();
//                    //tables = null;

//                    ds.Dispose();
//                    ds = null;

//                    dt.Dispose();
//                    dt = null;

//                    cmd.Dispose();
//                    cmd = null;

//                    adapter.Dispose();
//                    adapter = null;

//                    conn.Close();
//                    conn.Dispose();
//                    conn = null;
//                }
//                catch (Exception)
//                { }
//            }
//        }
//        //Private Static Functions
//        private static bool ReadExcel(ContextNM context, string sourceFile, string targetDir)
//        {
//            bool b = false;
//            System.Data.DataSet ds = null;
//            OleDbConnection conn = null;
//            DataTable tables = null;
//            OleDbDataAdapter adapter = null;
//            OleDbCommand cmd = null;
//            DataTable dt = null;

//            try
//            {
//                string filePrefix = System.IO.Path.GetFileNameWithoutExtension(sourceFile);

//                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;";
//                strConnection += " Data Source=" + sourceFile + ";";
//                strConnection += " Extended Properties=\"Excel 8.0;HDR=No;Imex=1;\"";

//                //  IMEX Values
//                //  0 is Export mode
//                //  1 is Import mode
//                //  2 is Linked mode (full update capabilities)

//                conn = new System.Data.OleDb.OleDbConnection(strConnection);

//                conn.Open();


//                tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
//                int rx = 0;
//                foreach (DataRow row in tables.Rows)
//                {
//                    //Check to see if it is loading the print area and ignore if so
//                    string tName = Convert.ToString(row[2]).Replace("''", "'");
//                    if ((tName.IndexOf("$Print_Area") == -1) && (tName.IndexOf("$'Print_Area") == -1))
//                    {
//                        rx++;
//                        if (rx < 4 || (!Tools.Strings.HasString(tName, "query") && !Tools.Strings.HasString(tName, "externaldata")))
//                        {
//                            ds = new DataSet();
//                            adapter = new OleDbDataAdapter();
//                            string strSelect = "SELECT * FROM [" + tName + "]";
//                            cmd = new OleDbCommand(strSelect, conn);
//                            cmd.CommandType = CommandType.Text;
//                            adapter.SelectCommand = cmd;

//                            dt = new DataTable();
//                            adapter.FillSchema(dt, SchemaType.Source);
//                            adapter.Fill(dt);

//                            if (dt.Rows.Count > 0)
//                            {
//                                if (!WriteCSV(dt, targetDir, filePrefix))
//                                {
//                                    return false;
//                                }
//                                else
//                                    b = true;
//                            }
//                        }
//                        else
//                        {
//                            context.TheLeader.Comment(tName + " was not parsed from Excel");
//                        }
//                    }
//                }
//                conn.Close();
//                return true;
//            }
//            catch (Exception e)
//            {
//                lastException = e;
//                return b;
//            }
//            finally
//            {
//                try
//                {
//                    tables.Dispose();
//                    tables = null;

//                    ds.Dispose();
//                    ds = null;

//                    dt.Dispose();
//                    dt = null;

//                    cmd.Dispose();
//                    cmd = null;

//                    adapter.Dispose();
//                    adapter = null;

//                    conn.Close();
//                    conn.Dispose();
//                    conn = null;
//                }
//                catch (Exception)
//                { }
//            }
//        }
//        private static bool WriteCSV(DataTable dt, string outDir, string filePrefix)
//        {
//            if (!Tools.Data.DataTableExists(dt))
//                return true;

//            if (dt.Rows.Count == 2 && dt.Columns.Count == 1)
//            {
//                if ((nData.NullFilter_String(dt.Rows[0][0]) == "") && (nData.NullFilter_String(dt.Rows[1][0]) == ""))
//                    return true;
//            }

//            if (outDir.IndexOf("\\", outDir.Length - 1) == -1) //Need to add \ to end of directory
//                outDir = outDir + "\\";
//            // Create the CSV file to which grid data will be exported.

//            string fname = dt.TableName + ".csv";
//            fname = fname.Replace("$", "");
//            fname = fname.Replace(" ", "_");
//            fname = outDir + filePrefix + "_" + fname.Replace("\'", "");
//            StreamWriter sw = new StreamWriter(fname, false);

//            int iColCount = dt.Columns.Count;

//            // Now write all the rows.
//            foreach (DataRow dr in dt.Rows)
//            {
//                for (int i = 0; i < iColCount; i++)
//                {
//                    if (!Convert.IsDBNull(dr[i]))
//                    {
//                        sw.Write(dr[i].ToString().Replace(",", "").Replace("\"", ""));
//                    }
//                    if (i < iColCount - 1)
//                    {
//                        sw.Write(",");
//                    }
//                }
//                sw.Write(sw.NewLine);
//            }
//            sw.Close();
//            return true;

//        }
//        public static String ExportListViewToCsv(ContextNM context, ListView lv, Boolean bShow, Boolean bOnlySelected)
//        {

//            return ExportListViewToCsv(context, lv, bShow, bOnlySelected, Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + Tools.Strings.GetNewID() + ".csv");
//        }
//        public static String ExportListViewToCsv(ContextNM context, ListView lv, Boolean bShow, Boolean bOnlySelected, String file)
//        {
//            try
//            {
//                String driveletter = nTools.GetDriveLetter();

//                //String strFile = driveletter + ":\\" + Tools.Strings.GetNewID() + ".xls";

//                String strFile = file;

//                if (File.Exists(strFile))
//                {
//                    if (!context.TheLeader.AreYouSure("overwrite the previous copy of " + strFile))
//                        return "";
//                }

//                TextWriter t = new StreamWriter(new FileStream(strFile, FileMode.Create));

//                int i = 0;
//                foreach (ColumnHeader c in lv.Columns)
//                {
//                    if (i > 0)
//                        t.Write(",");
//                    t.Write(CsvFilter(c.Text));
//                    i++;
//                }

//                t.WriteLine();

//                int j = 2;
//                if (bOnlySelected)
//                {
//                    foreach (ListViewItem li in lv.SelectedItems)
//                    {
//                        i = 0;
//                        foreach (ColumnHeader c in lv.Columns)
//                        {
//                            if (i > 0)
//                                t.Write(",");

//                            String str = li.SubItems[i].Text;
//                            if (str != null)
//                            {
//                                t.Write(CsvFilter(str));
//                            }
//                            i++;
//                        }
//                        j++;
//                        t.WriteLine();
//                    }
//                }
//                else
//                {
//                    foreach (ListViewItem li in lv.Items)
//                    {
//                        i = 0;
//                        foreach (ColumnHeader c in lv.Columns)
//                        {
//                            if (i > 0)
//                                t.Write(",");

//                            String str = li.SubItems[i].Text;
//                            if (str != null)
//                            {
//                                t.Write(CsvFilter(str));
//                            }
//                            i++;
//                        }
//                        j++;
//                        t.WriteLine();
//                    }
//                }

//                t.Close();
//                t.Dispose();
//                t = null;

//                if (bShow)
//                    nTools.ExploreFolder(Path.GetDirectoryName(strFile));

//                return strFile;
//            }
//            catch (Exception ex)
//            {
//                context.TheLeader.Error(ex.Message);
//                return null;
//            }
//        }
//        static String CsvFilter(String s)
//        {
//            string build = "";
//            if (s.IndexOf(',') > -1)
//                build = "\"" + s.Replace('\"', ' ') + "\"";
//            else
//                build = s.Replace('\"', ' ');
//            if (build.IndexOf('\r') > -1)
//                build = build.Replace('\r', ' ');
//            if (build.IndexOf('\n') > -1)
//                build = build.Replace('\n', ' ');
//            return build;
//        }
//    }
//}
