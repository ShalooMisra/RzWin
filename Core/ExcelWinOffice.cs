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
using Tools.Database;

namespace ToolsOffice
{
    public static class ExcelOffice
    {
        //Public Static Variables
        public static bool largeColumnSupport = false;
        //Private Static Variables
        private static Exception lastException = null;

        //Public Static Functions
        public static bool Excel2CSV(Context context, string sourceFile)
        {
            if (System.IO.File.Exists(sourceFile) == false)
            {
                throw new Exception("Excel file " + sourceFile + "could not be found.");
            }
            string filedir = System.IO.Path.GetDirectoryName(sourceFile);

            return Excel2CSV(context, sourceFile, filedir);
        }
        public static bool Excel2CSV(Context context, string sourceFile, string targetDir)
        {
            if (!System.IO.File.Exists(sourceFile))
                throw new Exception("Excel file " + sourceFile + "could not be found.");

            return ReadExcel(context, sourceFile, targetDir);
        }
        public static bool Split(Context context, String strFile)
        {
            String strUtil = Tools.FileSystem.GetAppPath() + "XLSplit.exe";
            if (!File.Exists(strUtil))
            {
                context.TheLeader.Comment(Tools.FileSystem.GetAppPath() + "XLSplit.exe does not exist.");
                return false;
            }

            return Tools.FileSystem.Shell(strUtil, " -file:" + strFile, false, true);
        }
        public static ArrayList GetExcelSheetNames(string sourceFile)
        {
            bool b = false;
            System.Data.DataSet ds = null;
            OleDbConnection conn = null;
            DataTable tables = null;
            OleDbDataAdapter adapter = null;
            OleDbCommand cmd = null;
            DataTable dt = null;

            ArrayList a = new ArrayList();

            try
            {
                string filePrefix = System.IO.Path.GetFileNameWithoutExtension(sourceFile);

                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;";
                strConnection += " Data Source=" + sourceFile + ";";
                strConnection += " Extended Properties=\"Excel 8.0;HDR=No;Imex=1;\"";

                //    IMEX Values
                //    0 is Export mode
                //    1 is Import mode
                //    2 is Linked mode (full update capabilities)

                conn = new System.Data.OleDb.OleDbConnection(strConnection);
                conn.Open();

                tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                if (tables == null)
                    throw new Exception("Sheet names table returned null");

                if (tables.Rows == null)
                    throw new Exception("Sheet names rows returned null");

                foreach (DataRow row in tables.Rows)
                {
                    //Check to see if it is loading the print area and ignore if so
                    string tName = Convert.ToString(row[2]);
                    if ((tName.IndexOf("$Print_Area") == -1) && (tName.IndexOf("$'Print_Area") == -1))
                    {
                        if (tName.StartsWith("'") && tName.EndsWith("'"))  //this is later used with [] so it doesn't need the quotes or escapes
                        {
                            tName = Tools.Strings.Mid(tName, 2, tName.Length - 2);
                            tName = tName.Replace("''", "'");
                        }

                        a.Add(tName);
                    }
                }
                conn.Close();
                return a;
            }
            catch (Exception e)
            {
                lastException = e;
                throw e;
            }
            finally
            {
                try
                {
                    if (tables != null)
                    {
                        tables.Dispose();
                        tables = null;
                    }

                    if (ds != null)
                    {
                        ds.Dispose();
                        ds = null;
                    }

                    if (dt != null)
                    {
                        dt.Dispose();
                        dt = null;
                    }

                    if (cmd != null)
                    {
                        cmd.Dispose();
                        cmd = null;
                    }

                    if (adapter != null)
                    {
                        adapter.Dispose();
                        adapter = null;
                    }

                    if (conn != null)
                    {
                        conn.Close();
                        conn.Dispose();
                        conn = null;
                    }
                }
                catch (Exception)
                { }
            }
        }
        public static DataTable OpenExcelAsDataTable(string sourceFile, String strSheet)
        {
            System.Data.DataSet ds = null;
            OleDbConnection conn = null;
            OleDbDataAdapter adapter = null;
            OleDbCommand cmd = null;
            DataTable dt = null;

            try
            {
                string filePrefix = System.IO.Path.GetFileNameWithoutExtension(sourceFile);

                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;";
                strConnection += " Data Source=" + sourceFile + ";";
                strConnection += " Extended Properties=\"Excel 8.0;HDR=No;Imex=1;\"";
                //    IMEX Values
                //    0 is Export mode
                //    1 is Import mode
                //    2 is Linked mode (full update capabilities)

                if (Path.GetExtension(sourceFile).ToLower() == ".xlsx")
                {
                    strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile + ";Extended Properties=Excel 12.0;HDR=No;Imex=1;";
                }

                conn = new System.Data.OleDb.OleDbConnection(strConnection);

                conn.Open();

                ds = new DataSet();
                adapter = new OleDbDataAdapter();
                string strSelect = "SELECT * FROM [" + strSheet + "]";
                cmd = new OleDbCommand(strSelect, conn);
                cmd.CommandType = CommandType.Text;
                adapter.SelectCommand = cmd;

                dt = new DataTable();
                adapter.FillSchema(dt, SchemaType.Source);
                adapter.Fill(dt);

                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                lastException = e;
                return null;
            }
            finally
            {
                try
                {
                    //tables.Dispose();
                    //tables = null;

                    ds.Dispose();
                    ds = null;

                    dt.Dispose();
                    dt = null;

                    cmd.Dispose();
                    cmd = null;

                    adapter.Dispose();
                    adapter = null;

                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                catch (Exception)
                { }
            }
        }
        public static String ExportListViewToCsv(Context context, ListView lv, Boolean bShow, Boolean bOnlySelected)
        {

            return ExportListViewToCsv(context, lv, bShow, bOnlySelected, Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + Tools.Strings.GetNewID() + ".csv");
        }
        public static String ExportListViewToCsv(Context context, ListView lv, Boolean bShow, Boolean bOnlySelected, String file)
        {
            try
            {
                String driveletter = Tools.Folder.GetDriveLetter();

                //String strFile = driveletter + ":\\" + Tools.Strings.GetNewID() + ".xls";

                String strFile = file;

                if (File.Exists(strFile))
                {
                    if (!context.TheLeader.AreYouSure("overwrite the previous copy of " + strFile))
                        return "";
                }

                TextWriter t = new StreamWriter(new FileStream(strFile, FileMode.Create));

                int i = 0;
                foreach (ColumnHeader c in lv.Columns)
                {
                    if (i > 0)
                        t.Write(",");
                    t.Write(CsvFilter(c.Text));
                    i++;
                }

                t.WriteLine();

                int j = 2;
                if (bOnlySelected)
                {
                    foreach (ListViewItem li in lv.SelectedItems)
                    {
                        i = 0;
                        foreach (ColumnHeader c in lv.Columns)
                        {
                            if (i > 0)
                                t.Write(",");

                            String str = li.SubItems[i].Text;
                            if (str != null)
                            {
                                t.Write(CsvFilter(str));
                            }
                            i++;
                        }
                        j++;
                        t.WriteLine();
                    }
                }
                else
                {
                    foreach (ListViewItem li in lv.Items)
                    {
                        i = 0;
                        foreach (ColumnHeader c in lv.Columns)
                        {
                            if (i > 0)
                                t.Write(",");

                            String str = li.SubItems[i].Text;
                            if (str != null)
                            {
                                t.Write(CsvFilter(str));
                            }
                            i++;
                        }
                        j++;
                        t.WriteLine();
                    }
                }

                t.Close();
                t.Dispose();
                t = null;

                if (bShow)
                    Tools.Folder.ExploreFolder(Path.GetDirectoryName(strFile));

                return strFile;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }
        public static void SplitExcelXml(String file, String folder)
        {
            if (!Tools.Files.FileExists(file))
                throw new Exception(file + " does not exist");
            OfficeInterop.ExcelApplication app = new OfficeInterop.ExcelApplication(file);
            int sheetIndex = 1;
            foreach (OfficeInterop.ExcelWorksheet w in app.Workbook.Worksheets)
            {
                int width = 0;
                int height = 0;
                w.UsedRangeFind(ref width, ref height);
                StringBuilder sb = new StringBuilder();
                for (int row = 1; row <= height; row++)
                {
                    for (int col = 1; col <= width; col++)
                    {
                        if (col > 1)
                            sb.Append(",");
                        String val = "";
                        try
                        {
                            val = "\"" + Convert.ToString(w.GetCellValue(row, col)).Replace("\"", "").Replace("'", "").Replace("\r", "").Replace("\n", "").Replace("\t", "") + "\"";
                        }
                        catch { }
                        sb.Append(val);
                    }
                    sb.Append("\r\n");
                }
                String sheetName = "Sheet_" + sheetIndex.ToString();
                if (Tools.Strings.StrExt(w.SheetName))
                    sheetName = w.SheetName;
                String resultFile = Tools.Folder.ConditionFolderName(folder) + Tools.Strings.FilterFileNameTrash(Path.GetFileNameWithoutExtension(file)) + "_" + sheetName + ".csv";
                if (File.Exists(resultFile))
                    File.Delete(resultFile);
                Tools.Files.SaveStringAsFile(resultFile, sb.ToString());
                sheetIndex++;
            }
            app.Quit();
        }
        //Private Static Functions
        private static bool ReadExcel(Context context, string sourceFile, string targetDir)
        {
            bool b = false;
            System.Data.DataSet ds = null;
            OleDbConnection conn = null;
            DataTable tables = null;
            OleDbDataAdapter adapter = null;
            OleDbCommand cmd = null;
            DataTable dt = null;

            try
            {
                string filePrefix = System.IO.Path.GetFileNameWithoutExtension(sourceFile);

                string strConnection = "Provider=Microsoft.Jet.OLEDB.4.0;";
                strConnection += " Data Source=" + sourceFile + ";";
                strConnection += " Extended Properties=\"Excel 8.0;HDR=No;Imex=1;\"";

                //  IMEX Values
                //  0 is Export mode
                //  1 is Import mode
                //  2 is Linked mode (full update capabilities)

                conn = new System.Data.OleDb.OleDbConnection(strConnection);

                conn.Open();


                tables = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                int rx = 0;
                foreach (DataRow row in tables.Rows)
                {
                    //Check to see if it is loading the print area and ignore if so
                    string tName = Convert.ToString(row[2]).Replace("''", "'");
                    if ((tName.IndexOf("$Print_Area") == -1) && (tName.IndexOf("$'Print_Area") == -1))
                    {
                        rx++;
                        if (rx < 4 || (!Tools.Strings.HasString(tName, "query") && !Tools.Strings.HasString(tName, "externaldata")))
                        {
                            ds = new DataSet();
                            adapter = new OleDbDataAdapter();
                            string strSelect = "SELECT * FROM [" + tName + "]";
                            cmd = new OleDbCommand(strSelect, conn);
                            cmd.CommandType = CommandType.Text;
                            adapter.SelectCommand = cmd;

                            dt = new DataTable();
                            adapter.FillSchema(dt, SchemaType.Source);
                            adapter.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                if (!WriteCSV(dt, targetDir, filePrefix))
                                {
                                    return false;
                                }
                                else
                                    b = true;
                            }
                        }
                        else
                        {
                            context.TheLeader.Comment(tName + " was not parsed from Excel");
                        }
                    }
                }
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                lastException = e;
                return b;
            }
            finally
            {
                try
                {
                    tables.Dispose();
                    tables = null;

                    ds.Dispose();
                    ds = null;

                    dt.Dispose();
                    dt = null;

                    cmd.Dispose();
                    cmd = null;

                    adapter.Dispose();
                    adapter = null;

                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                catch (Exception)
                { }
            }
        }
        private static bool WriteCSV(DataTable dt, string outDir, string filePrefix)
        {
            if (!Tools.Data.DataTableExists(dt))
                return true;
            if (dt.Rows.Count == 2 && dt.Columns.Count == 1)
            {
                if ((NullFilterString(dt.Rows[0][0]) == "") && (NullFilterString(dt.Rows[1][0]) == ""))
                    return true;
            }
            if (outDir.IndexOf("\\", outDir.Length - 1) == -1) //Need to add \ to end of directory
                outDir = outDir + "\\";
            // Create the CSV file to which grid data will be exported.
            string fname = dt.TableName + ".csv";
            fname = fname.Replace("$", "");
            fname = fname.Replace(" ", "_");
            fname = outDir + filePrefix + "_" + fname.Replace("\'", "");
            StreamWriter sw = new StreamWriter(fname, false);
            int iColCount = dt.Columns.Count;
            // Now write all the rows.
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                        sw.Write(dr[i].ToString().Replace(",", "").Replace("\"", ""));
                    if (i < iColCount - 1)
                        sw.Write(",");
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            return true;
        }
        private static String NullFilterString(Object varIn)
        {
            if (varIn == System.DBNull.Value || varIn == null)
                return "";
            else
                return varIn.ToString();
        }
        private static String CsvFilter(String s)
        {
            string build = "";
            if (s.IndexOf(',') > -1)
                build = "\"" + s.Replace('\"', ' ') + "\"";
            else
                build = s.Replace('\"', ' ');
            if (build.IndexOf('\r') > -1)
                build = build.Replace('\r', ' ');
            if (build.IndexOf('\n') > -1)
                build = build.Replace('\n', ' ');
            return build;
        }
    }
}


//public static void SplitExcelXml(String file, String folder)
//{
//    if (!Tools.Files.FileExists(file))
//        throw new Exception(file + " does not exist");

//    OfficeInterop.ExcelApplication app = new ExcelApplication(file);

//    int sheetIndex = 1;
//    foreach (OfficeInterop.ExcelWorksheet w in app.Workbook.Worksheets)
//    {
//        int width = 0;
//        int height = 0;
//        w.UsedRangeFind(ref width, ref height);
//        StringBuilder sb = new StringBuilder();

//        for (int row = 1; row <= height; row++)
//        {
//            for (int col = 1; col <= width; col++)
//            {
//                if (col > 1)
//                    sb.Append(",");

//                String val = "";
//                try
//                {
//                    val = "\"" + Convert.ToString(w.GetCellValue(row, col)).Replace("\"", "").Replace("'", "").Replace("\r", "").Replace("\n", "").Replace("\t", "") + "\"";
//                }
//                catch { }

//                sb.Append(val);
//            }
//            sb.Append("\r\n");
//        }

//        String resultFile = Tools.Folder.ConditionFolderName(folder) + Tools.Strings.FilterFileNameTrash(Path.GetFileNameWithoutExtension(file)) + "_Sheet_" + sheetIndex.ToString() + ".csv";
//        if (File.Exists(resultFile))
//            File.Delete(resultFile);
//        Tools.Files.SaveStringAsFile(resultFile, sb.ToString());
//        sheetIndex++;
//    }

//    app.Quit();
//}
