using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using OfficeInterop;
using OfficeOpenXml;
using Core;
using Tools.Database;
//using Rz3_Common;

//using Word = Microsoft.Office.Interop.Word;
//using Excel = Microsoft.Office.Interop.Excel;

namespace NewMethod
{
    public delegate void DataTableStatusHandler(String status);
    public delegate void DataTableProgressHandler(int progress);
    public delegate void DataTableCancelHandler(nDataTableCancelArgs args);

    public class nDataTable
    {
        public static int TableModeLevel = 100;
        public static int FieldLength = 4096;

        public event DataTableStatusHandler GotStatus;
        public event DataTableProgressHandler GotProgress;
        public event DataTableCancelHandler CancelCheck;

        public ArrayList Columns = new ArrayList();
        public bool TableMode = false;
        public String TableName = "";
        public DataConnectionSqlServer xData;
        private ArrayList Rows = new ArrayList();
        Int64 m_count = 0;

        public nDataTable(DataConnectionSqlServer dataConnection)
        {
            xData = dataConnection;
        }

        public void AbsorbFile(ContextNM context, String strFile, bool defaultSheet = false)
        {
            String s = Path.GetExtension(strFile);
            switch (s.ToLower())
            {
                case ".xls":
                    if (defaultSheet)
                        AbsorbExcelFile_ByFileFirstSheet(context, strFile);
                    else
                        AbsorbExcelFile_ByFile(context, strFile);
                    break;
                case ".xlsx":
                    if (defaultSheet)
                        AbsorbExcel2007File_ByFileFirstSheet(context, strFile);
                    else
                        AbsorbExcel2007File_ByFile(context, strFile);
                    break;
                case ".dbf":
                    AbsorbDBFFile(context, strFile);
                    break;
                case ".csv":
                    AbsorbCSVFile(context, strFile);
                    break;
                default:
                    throw new Exception("Unrecognized file type " + s);
            }
        }

        public void AbsorbExcelFile(ContextNM x, String strFile, String strSheet, bool ForceSharedFolder)
        {
            if (strFile.ToLower().EndsWith(".xlsx"))
            {
                if (Tools.Strings.StrExt(strSheet))
                    AbsorbExcel2007File_ByFile(x, strFile, strSheet);
                else
                    AbsorbExcel2007File_ByFile(x, strFile);
            }
            else
            {
                if (Tools.Strings.StrExt(strSheet))
                    AbsorbExcelFile_ByFile(x, strFile, strSheet);
                else
                    AbsorbExcelFile_ByFile(x, strFile);
            }
        }

        public String Row0Cell0(ContextNM x)
        {
            return Tools.Data.NullFilterString(x.Select("select * from " + TableName + " where unique_order = (select min(unique_order) from " + TableName + ")").Rows[0][0]);
        }

        public void DeleteFirstRow(ContextNM x)
        {
            x.Execute("delete from " + TableName + " where unique_order = (select min(unique_order) from " + TableName + ")");
            RefreshFromDatabase(x);
        }

        public void RenameTable(String s)
        {
            xData.RenameTable(TableName, s);
            TableName = s;
        }

        public void CopyColumn(ContextNM context, int c)
        {
            nDataColumn col = (nDataColumn)Columns[c];
            if (col == null)
                throw new Exception("Column not found");

            nDataColumn n = new nDataColumn(Columns.Count);
            AddField(n.unique_id);

            Columns.Add(n);
            xData.Execute("update " + TableName + " set " + n.unique_id + " = " + col.unique_id);
            RefreshFromDatabase(context);
        }

        public DataTable GetDataTable()
        {
            return GetDataTable(false);
        }

        public DataTable GetDataTable(bool exclude_system_columns)
        {
            return GetDataTable("", "", exclude_system_columns);
        }

        public DataTable GetDataTable(String strWhere, String strOrder)
        {
            return GetDataTable(strWhere, strOrder);
        }

        public DataTable GetDataTable(String strWhere, String strOrder, bool exclude_system_columns)
        {
            String s = "";
            if (exclude_system_columns)
            {
                foreach (nDataColumn c in Columns)
                {
                    if (Tools.Strings.StrExt(s))
                        s += ", ";
                    s += c.unique_id;
                }
                s = "select " + s + " from " + TableName;
            }
            else
                s = "select * from " + TableName;

            if (Tools.Strings.StrExt(strWhere))
                s += " where " + strWhere;

            s += " order by ";

            if (!Tools.Strings.StrExt(strOrder))
                s += "unique_order";
            else
                s += strOrder;

            return xData.Select(s);
        }

        public void ClusterIndexField(String strField)
        {
            xData.Execute("drop index temp_index on " + TableName, FailOK: true);
            xData.Execute("create clustered index temp_index on " + TableName + " (" + strField + ")");
        }

        //public bool AbsorbExcelFile_ByRows(ExcelApplication xlApp, OfficeInterop.ExcelWorkbook xlBook)
        //{
        //    OfficeInterop.ExcelWorksheet xlSheet = xlBook.get_Worksheet(1);

        //    SetColumns(xlSheet.UsedColumns);

        //    Int64 FileLength = xlSheet.UsedRows;

        //    SetProgress(0);
        //    for (int r = 1; r <= FileLength; r++)
        //    {
        //        nDataRow row = new nDataRow(r - 1);
        //        for (int c = 1; c <= xlSheet.UsedColumns; c++)
        //        {
        //            Cell cell = xlSheet.get_Cell(r, c);
        //            OfficeInterop.ExcelRange range = xlSheet.get_Range(cell);
        //            //Array vals = null;

        //            String sv = "";
        //            if (range.RangeValue != null)
        //                sv = range.RangeValue.ToString();

        //            row.Values.Add(sv);
        //        }
        //        if (row.Values.Count > 0)
        //            AddRow(row);
        //        try
        //        {
        //            if (CancelCheck != null)
        //            {
        //                nDataTableCancelArgs args = new nDataTableCancelArgs();
        //                CancelCheck(args);
        //                if (args.Cancel)
        //                {
        //                    //ToolsOffice.ExcelOffice.CloseExcel(xlApp, xlBook, xlSheet);
        //                    return false;
        //                }
        //            }

        //            if (FileLength > 0)
        //            {
        //                SetProgressPercent(FileLength, r);
        //            }
        //        }
        //        catch (Exception)
        //        { }
        //    }
        //    xlSheet = null;
        //    return true;
        //}


        //public bool AbsorbExcel2007File_ByFile(String strFile, String strSheet, bool silent, ref String status, System.Windows.Forms.IWin32Window owner)
        //{
        //    DataSet dataSet = new DataSet();
        //    DataTable dataTable = new DataTable();

        //    dataTable = ToolsWin.ExcelXlsx.XlsxWorksheetToDataTable(strFile, "");

        //    string strTable = Tools.Strings.GenerateRandomName("temp_", "");
        //    if (!xData.ImportDataTable(dataTable, strTable))
        //    {
        //        status = "Saving the data table failed";
        //        return false;
        //    }

        //    long l = ImportFromSQL("select * from " + strTable);
        //    xData.Execute("drop table " + strTable);
        //    return l > 0;
        //    //return false;
        //}
        public void AbsorbExcel2007File_ByFile(ContextNM x, String strFile)
        {
            String sheet = "";
            FileInfo existingFile = new FileInfo(strFile);
            using (OfficeOpenXml.ExcelPackage package = new OfficeOpenXml.ExcelPackage(existingFile))
            {
                List<String> a = new List<String>();
                if (package.Workbook.Worksheets != null)
                {
                    
                    if (package.Workbook.Worksheets.Count <= 0)
                        throw new Exception("No worksheets were found");

                    if (package.Workbook.Worksheets.Count > 1)
                    {
                        for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                        {
                            a.Add(package.Workbook.Worksheets[i].Name);
                        }
                        sheet = x.TheLeader.ChooseBetweenStrings("Please choose a worksheet", a);
                        if (!Tools.Strings.StrExt(sheet))
                            return;  //user cancel
                    }
                }
            }

            AbsorbExcel2007File_ByFile(x, strFile, sheet);
        }

        public void AbsorbExcel2007File_ByFileFirstSheet(ContextNM x, String strFile)
        {
            AbsorbExcel2007File_ByFile(x, strFile, "");
        }

        public void AbsorbExcel2007File_ByFile(ContextNM x, String strFile, String strSheet)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();

            if (!Tools.Files.FileExists(strFile))
                throw new Exception(strFile + " does not exist");

            FileInfo existingFile = new FileInfo(strFile);
            using (OfficeOpenXml.ExcelPackage package = new OfficeOpenXml.ExcelPackage(existingFile))
            {
                List<String> a = new List<String>();
                if (package.Workbook.Worksheets.Count <= 0)
                    throw new Exception("No worksheets were found");

                //String str = "";
                //if (package.Workbook.Worksheets.Count > 1)   
                //{
                //    for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                //    {
                //        a.Add(package.Workbook.Worksheets[i].Name);
                //    }
                //    str = x.TheLeader.ChooseBetweenStrings("Please choose a worksheet", a);
                //}
                OfficeOpenXml.ExcelWorksheet worksheet = null;

                if (!Tools.Strings.StrExt(strSheet))
                    worksheet = package.Workbook.Worksheets[1];
                else
                    worksheet = package.Workbook.Worksheets[strSheet];

                if (worksheet == null)
                    throw new Exception("The worksheet was not found");

                ExcelCellAddress start = worksheet.Dimension.Start;
                ExcelCellAddress end = worksheet.Dimension.End;
                int count = 1;
                for (int i = start.Column; i <= end.Column; i++)
                {
                    //if (worksheet.Cells[start.Row, i].Value == null)
                    //    break;
                    //string s = worksheet.Cells[start.Row, i].Value.ToString();
                    //if (!Tools.Strings.StrExt(s))
                    //    break;
                    DataColumn column = new DataColumn();
                    column.ColumnName = "F" + count.ToString();
                    count = count + 1;
                    column.MaxLength = 8000;
                    dataTable.Columns.Add(column);
                }
                for (int row = start.Row; row <= end.Row; row++)
                {
                    DataRow dr = dataTable.NewRow();
                    for (int col = start.Column; col <= end.Column; col++)
                    {
                        if (worksheet.Cells[row, col].Value != null)
                            dr[col - 1] = worksheet.Cells[row, col].Value;
                    }
                    dataTable.Rows.Add(dr);
                }
            }
            string strTable = Tools.Strings.GenerateRandomName("temp_", "");

            xData.ImportDataTable(dataTable, strTable);

            long l = ImportFromSQL(x, "select * from " + strTable);
            xData.Execute("drop table " + strTable);
        }

        public void AbsorbExcelFile_ByFile(ContextNM context, String strFile)
        {
            String strSheet = "";
            List<String> sheets = new List<string>();
            foreach (String s in ToolsOffice.ExcelOffice.GetExcelSheetNames(strFile))
            {
                sheets.Add(s);
            }
            strSheet = context.TheLeader.ChooseBetweenStrings("Worksheet selection", sheets);

            if (!Tools.Strings.StrExt(strSheet))
                return;

            AbsorbExcelFile_ByFile(context, strFile, strSheet);
        }

        public void AbsorbExcelFile_ByFileFirstSheet(ContextNM context, String strFile)
        {
            String strSheet = "";
            try
            {

                List<String> sheets = new List<string>();
                foreach (String s in ToolsOffice.ExcelOffice.GetExcelSheetNames(strFile))
                {
                    strSheet = s;
                    break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting the sheet names: " + ex.Message);
            }

            if (!Tools.Strings.StrExt(strSheet))
                throw new Exception("No worksheets were found");

            AbsorbExcelFile_ByFile(context, strFile, strSheet);
        }

        public void AbsorbExcelFile_ByFile(ContextNM context, String strFile, String strSheet)
        {
            DataTable dataTable = ToolsOffice.ExcelOffice.OpenExcelAsDataTable(strFile, strSheet);

            if (dataTable == null)
                throw new Exception("OpenExcelAsDataTable returned null");

            string strTable = Tools.Strings.GenerateRandomName("temp_", "");
            xData.ImportDataTable(dataTable, strTable);

            long l = ImportFromSQL(context, "select * from " + strTable);
            xData.Execute("drop table " + strTable);
        }

        private String MakeExistOnServer(ContextNM context, String strFile)
        {
            if (Tools.Strings.StrCmp(xData.TheKey.ServerName, System.Environment.MachineName))
            {
                if (!Tools.Strings.StrCmp(System.Environment.MachineName, "westwood1"))
                    return strFile;
            }

            String strServer = xData.TheKey.ServerName;
            if (Tools.Number.IsNumeric(strServer.Replace(".", "")))
            {
                //if (Tools.Misc.IsDevelopmentMachine())
                //    strServer = "VANBURGH03";
            }

            //get the file to a place that the server can access them.
            String strPath = "\\\\" + strServer + "\\SQLShare";
            String strCool = "";
            context.TheLeader.Comment("Checking read/write to folder: " + strPath);
            if (!Tools.OperatingSystem.CheckReadWrite(strPath, ref strCool))
            {
                context.TheLeader.Tell("This file could not be moved to the server for importing: " + strCool + "\r\n\r\nPlease ensure that there is a shared folder on " + xData.TheKey.ServerName + " named 'SQLShare' that is accessible from this workstation.");
                return "";
            }
            context.TheLeader.Comment("Read/Write success!");
            String s = System.IO.Path.GetFileName(strFile);
            String strNew = Tools.Folder.ConditionFolderName(strPath) + "x" + Tools.Strings.Right(Tools.Strings.GetNewID(), 5) + Tools.Strings.Right(strFile, 4);

            SetStatus("Copying...");
            context.TheLeader.Comment("Copying " + strFile + " to " + strNew);
            System.IO.File.Copy(strFile, strNew);
            return strNew;
        }

        private void SetProgress(int p)
        {
            if (GotProgress != null)
                GotProgress(p);
        }

        private void SetStatus(String s)
        {
            if (GotStatus != null)
                GotStatus(s);
        }

        public int MatchWithClass(ContextNM context, String strClass)
        {
            int i = 0;
            foreach (CoreVarValAttribute p in context.TheSys.CoreClassGet(strClass).VarValsGet())
            {
                foreach (nDataColumn c in Columns)
                {
                    if (c.p == null)
                    {
                        if (Tools.Strings.StrCmp(p.Name, c.Heading))
                        {
                            c.p = p;
                            i++;
                        }
                    }
                }
            }
            return i;
        }

        public Int64 ImportFromSQL(ContextNM context, String sql)
        {
            //DataConnectionSqlServer xd = new DataConnectionSqlServer(
            //n_data_target t = new n_data_target(xData.target_type, xData.server_name, xData.database_name, xData.user_name, xData.user_password);
            //t.command_string = strSQL;
            return ImportFromSQL(context, xData, sql);
        }

        public Int64 ImportFromSQL(ContextNM context, DataConnection xd, String sql)
        {
            SetStatus("Testing connection...");

            if (!xd.ConnectPossible())
                throw new Exception("Connection not found");

            InitTableMode();

            SetStatus("Selecting...");
            DataTable dataTable = xd.Select(sql);
            if (dataTable == null)
                throw new Exception("No data found");

            SetStatus("Importing...");
            xData.ImportDataTable(dataTable, TableName);

            if (xData.HasIdentityField(TableName))
            {
                context.TheLeader.Tell("This table has an identity column.  Please remove the identity property of the appropriate field before continuing.");
                return -1;
            }

            xData.Execute("alter table " + TableName + " add unique_order int IDENTITY(0, 1)");

            SetStatus("Scanning columns...");

            if (xData.FieldExists(TableName, "unique_id"))
                xData.RenameField(TableName, "unique_id", "renamed_unique_id");

            FilterDatabaseColumns();

            TrimFields();

            //do this after the columns have been renamed
            xData.Execute("alter table " + TableName + " add unique_id varchar(255)");

            //if it has an original uid use it
            bool buid = false;
            if (xData.FieldExists(TableName, "column_renamed_unique_id"))
            {
                if (xData.GetScalar_Long("select count(*) from " + TableName) == xData.GetScalar_Long("select count(distinct(column_renamed_unique_id)) from " + TableName))
                    buid = true;
            }

            if (buid)
            {
                xData.Execute("update " + TableName + " set unique_id = cast(column_renamed_unique_id as varchar(255))");
            }
            else
            {
                xData.Execute("update " + TableName + " set unique_id = cast(newid() as varchar(255))");
            }

            CleanTheData();
            RefreshFromDatabase(context);
            return Count;

        }

        public void CleanTheData()
        {
            ClearBlankRows();
            TrimFields();
        }

        public void TrimFields()
        {
            SetStatus("Trimming...");
            foreach (nDataColumn c in Columns)
            {
                TrimField(c.unique_id);
            }
        }

        public void TrimField(String strField)
        {
            //also filter char(160)
            xData.Execute("update " + TableName + " set " + strField + " = replace(LTRIM(RTRIM(" + strField + ")), char(160), '')");
        }

        public bool RenameFieldByIndex(int index, String strNew)
        {
            return RenameFieldByIndex(index, strNew, false);
        }

        public bool RenameFieldByIndex(int index, String strNew, bool update_caption)
        {
            try
            {
                nDataColumn c = (nDataColumn)Columns[index];
                xData.RenameField(TableName, c.unique_id, strNew);

                c.unique_id = strNew;
                if (update_caption)
                {
                    c.Caption = strNew;
                    c.Heading = strNew;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckRemoveIdentity()
        {
            return false;
            //String s = xData.GetIdentityField(TableName);
            //if (!Tools.Strings.StrExt(s))
            //    return true;

            ////make a bigint column
            //if (!xData.Execute("alter table " + TableName + " add temp_identity_field int"))
            //    return false;

            //if (!xData.Execute("update " + TableName + " set temp_identity_field = " + s))
            //    return false;

            //if (!xData.Execute("alter table " + TableName + " drop column " + s))
            //    return false;

            //if (!xData.RenameField(TableName, "temp_identity_field", s))
            //    return false;

            //return true;
        }

        public void ScanColumnsWithoutChanges()
        {
            Columns.Clear();
            DataTable dataTable = xData.Select("select top 1 * from " + TableName);
            int i = 0;
            foreach (DataColumn c in dataTable.Columns)
            {
                switch (c.Caption.ToLower().Trim())
                {
                    case "unique_id":
                    case "unique_order":
                    case "temp_unique_order":
                        break;
                    default:
                        nDataColumn col = new nDataColumn(i);
                        col.Heading = c.Caption;
                        col.unique_id = c.Caption;
                        Columns.Add(col);
                        i++;
                        break;
                }
            }
        }

        public void ImportFromDataSourceString(ContextNM context, String strFile, String strSource)
        {
            Clear();

            if (!System.IO.File.Exists(strFile))
                throw new Exception(strFile + " could not be found.");

            InitTableMode();

            String strSQL = "select *, IDENTITY(bigint, 0, 1) as temp_unique_order, cast(newid() as varchar(255)) as unique_id into " + TableName + " from " + strSource;
            xData.Execute(strSQL);

            //major problem - deleted files even if they were local and not copied
            //try { System.IO.File.Delete(strFile); }
            //catch (Exception) { }

            FilterDatabaseColumns();
            xData.Execute("alter table " + TableName + " add unique_order int");
            xData.Execute("update " + TableName + " set unique_order = temp_unique_order");
            xData.Execute("alter table " + TableName + " drop column temp_unique_order");
            CleanTheData();
            RefreshFromDatabase(context);
        }

        public void AbsorbCSVFile(ContextNM context, String strFile)
        {
            //strFile = MakeExistOnServer(strFile);
            //if (!Tools.Strings.StrExt(strFile))
            //{
            //    status = "Could not make " + strFile + " exist on the server";
            //    return false;
            //}

            ////screws up the text/number columns
            ////return ImportFromDataSourceString(strFile, "OPENDATASOURCE('Microsoft.Jet.OLEDB.4.0', 'Data Source=" + System.IO.Path.GetDirectoryName(strFile) + ";Extended Properties=\"Text;HDR=No;FMT=Delimited;IMEX=2\"')...\"" + Path.GetFileName(strFile).Replace(".", "#") + "\"", silent, ref status);
            //String strTable = "";
            //if (!xData.ImportDelimitedFileToTable(strFile, ',', ref strTable))
            //    return false;

            //return ImportFromDataSourceString(strFile, strTable, silent, ref status);

            InitTableMode();
            String strTable = TableName;

            xData.ImportDelimitedFileToTable(strFile, ',', ref strTable);
            FinishAbsorbing(context);
        }

        public void FinishAbsorbing(ContextNM context)
        {
            String strSQL = "alter table " + TableName + " add temp_unique_order numeric(18,0) identity not null, unique_id varchar(255)";
            xData.Execute(strSQL);

            strSQL = "update " + TableName + " set unique_id  = cast(newid() as varchar(255))";
            xData.Execute(strSQL);
            FilterDatabaseColumns();
            xData.Execute("alter table " + TableName + " add unique_order int");
            xData.Execute("update " + TableName + " set unique_order = temp_unique_order");
            xData.Execute("alter table " + TableName + " drop column temp_unique_order");
            CleanTheData();
            RefreshFromDatabase(context);
        }

        public void AbsorbDBFFile(ContextNM context, String strFile)
        {
            context.TheLeader.Comment("Starting import..");

            InitTableMode();
            String strTable = TableName;

            DataTable dt = OthersCode.ParseDBF.ReadDBF(strFile, true);

            if (dt == null || dt.Columns.Count == 0)
                throw new Exception("The dbf file could not be parsed.");

            int cx = 0;
            foreach (DataColumn c in dt.Columns)
            {
                String strType = "varchar(255)";
                switch (c.DataType.Name)
                {
                    case "String":
                        break;
                    case "Int32":
                        strType = "int";
                        break;
                    case "DateTime":
                        strType = "datetime";
                        break;
                    case "Double":
                    case "Float":
                    case "Decimal":
                        strType = "float";
                        break;
                    case "Boolean":
                        strType = "bit";
                        break;
                    default:
                        throw new Exception("Unknown DBF column type " + c.DataType.Name);
                }

                String fn = "column_" + Tools.Strings.FilterTrash(c.Caption);

                if (cx == 0)
                    xData.Execute("create table " + strTable + " (" + fn + " " + strType + ")");
                else
                    xData.Execute("alter table " + strTable + " add " + fn + " " + strType);

                cx++;
            }

            SqlBulkCopy bulkCopy = new SqlBulkCopy(xData.ConnectionStringWithoutProvider, SqlBulkCopyOptions.TableLock);
            bulkCopy.BulkCopyTimeout = 3600 * 2;  //2 hours?
            bulkCopy.DestinationTableName = "dbo." + strTable;
            bulkCopy.WriteToServer(dt);
            bulkCopy.Close();
            bulkCopy = null;
            dt = null;

            FinishAbsorbing(context);
        }

        public void FilterDatabaseColumns()
        {
            SetStatus("Filtering columns...");
            Columns.Clear();

            DataTable dataTable = xData.Select("select top 1 * from " + TableName);
            if (dataTable == null)
                throw new Exception("No data");

            int i = 0;
            foreach (DataColumn c in dataTable.Columns)
            {
                switch (c.Caption.ToLower())
                {
                    case "unique_id":
                    case "unique_order":
                    case "temp_unique_order":
                        //
                        break;
                    default:

                        nDataColumn col = new nDataColumn(i);
                        if (nData.IsValidDBObjectName(c.Caption))
                        {
                            if (c.Caption.StartsWith("column_"))
                                col.unique_id = c.Caption;
                            else
                            {
                                col.unique_id = "column_" + c.Caption;
                                xData.RenameField(TableName, c.Caption, col.unique_id);
                            }
                        }
                        else
                        {
                            col.unique_id = "column_" + Tools.Strings.StripNonAlphaNumeric(c.Caption, false) + "_" + Tools.Strings.StripNonAlphaNumeric(Tools.Strings.GetNewID(), false);
                            xData.RenameField(TableName, c.Caption, col.unique_id);
                        }

                        col.Heading = c.Caption;

                        if (c.DataType == System.Type.GetType("System.String"))
                        {
                            if ((c.MaxLength < nDataTable.FieldLength) && !ToolsOffice.ExcelOffice.largeColumnSupport)
                                WidenField(col.unique_id);
                        }
                        else
                            ConvertToText(col.unique_id);

                        Columns.Add(col);
                        i++;
                        break;
                }
            }
        }

        public void WidenField(String strField)
        {
            xData.Execute("alter table " + TableName + " alter column " + strField + " varchar(" + FieldLength.ToString() + ")");
        }

        public void SetColumnProperty(ContextNM context, int columnIndex, String classId, String property)
        {
            nDataColumn c = (nDataColumn)Columns[columnIndex];
            c.p = context.Sys.CoreClassGet(classId).VarValGet(property);
        }

        private void AddRow(ContextNM context, nDataRow r)
        {
            while (r.Values.Count < Columns.Count)
            {
                r.Values.Add("");
            }

            if (TableMode)
            {
                SaveRow(r);
            }
            else if (Rows.Count > TableModeLevel)
            {
                SetTableMode(context);
                SaveRow(r);
            }
            else
            {
                Rows.Add(r);
            }

            m_count++;
        }

        public void RemoveRow(nDataRow r)
        {
            Rows.Remove(r);
            if (TableMode)
                DeleteRow(r);

            m_count--;
        }

        public void RemoveFirst()
        {
            try
            {
                if (Rows.Count == 0)
                    return;

                nDataRow r = (nDataRow)Rows[0];
                if (r == null)
                    return;

                RemoveRow(r);
            }
            catch (Exception)
            { }
        }

        public Int64 Count
        {
            get
            {
                return m_count;
            }
        }

        public void DeleteRow(nDataRow r)
        {
            DeleteRow(r.unique_id);
        }

        public void DeleteRow(String rowId)
        {
            xData.Execute("delete from " + TableName + " where unique_id = '" + rowId + "'");
        }

        public void SaveRow(nDataRow r)
        {
            String strSQL = "insert into " + TableName + " (unique_id, unique_order";

            foreach (nDataColumn c in Columns)
            {
                strSQL += ", " + c.unique_id;
            }

            strSQL += " ) values ('" + r.unique_id + "', " + r.unique_order.ToString();

            int i = 0;
            foreach (String s in r.Values)
            {
                if (i <= Columns.Count)
                    strSQL += ", '" + xData.SyntaxFilter(Tools.Strings.Left(s, FieldLength)) + "'";

                i++;
            }

            for (int j = i; j < Columns.Count; j++)
            {
                strSQL += ", ''";
            }

            strSQL += ")";

            xData.Execute(strSQL);
        }

        public void ForceTableMode(ContextNM context)
        {
            if (TableMode)
                return;

            SetTableMode(context);
        }

        private void SetTableMode(ContextNM context)
        {
            bool b = false;
            if (xData == null)
            {
                b = true;
            }
            else
            {
                if (!xData.ConnectPossible())
                    b = true;
            }

            if (b)
            {
                context.TheLeader.Tell("The xData object isn't set for this nDataTable item.");
                return;
            }

            InitTableMode();
            CreateTheTable();

            foreach (nDataRow r in Rows)
            {
                SaveRow(r);
            }
        }

        public void InitTableMode()
        {
            TableMode = true;
            TableName = "temp_" + Tools.Strings.GetNewID();
        }

        public void SetActualFieldNames(ContextNM context)
        {
            ForceTableMode(context);
            foreach (nDataColumn c in Columns)
            {
                if (c.p != null)
                {
                    if (Tools.Strings.StrExt(c.p.Name))
                    {
                        xData.RenameField(TableName, c.unique_id, c.p.Name);
                        c.unique_id = c.p.Name;
                    }
                }
            }
        }

        public void LimitFieldLength(String strField, int len)
        {
            String strSQL = "update " + TableName + " set " + strField + " = left(" + strField + ", " + len.ToString() + ")";
            xData.Execute(strSQL);
        }

        public void FormalizeFieldTypes(ContextNM x)
        {
            SetProgress(0);
            SetStatus("Checking field types...");
            int i = 1;
            foreach (nDataColumn c in Columns)
            {
                if (c.p != null)
                {
                    FormalizeFieldType(x, c.p.Name, c.p.TheFieldType);
                }
                SetProgressPercent(Columns.Count, i);
                i++;
            }
        }

        public void FormalizeFieldType(ContextNM x, String strField, FieldType t)
        {
            switch (t)
            {
                case FieldType.Boolean:
                    ConvertField_Boolean(x, strField);
                    break;
                case FieldType.Int32:
                case FieldType.Int64:
                    ConvertField_Long(x, strField);
                    break;
                case FieldType.Double:
                    ConvertField_Float(x, strField);
                    break;
                case FieldType.DateTime:
                    ConvertField_Date(x, strField);
                    break;
            }
        }

        public void RemoveBlurb(String strBlurb)
        {
            foreach (nDataColumn c in Columns)
            {
                RemoveBlurb(c.unique_id, strBlurb);
            }
        }

        public void RemoveBlurb(String strField, String strBlurb)
        {
            xData.Execute("update " + TableName + " set " + strField + " = replace(" + strField + ", '" + xData.SyntaxFilter(strBlurb) + "', '') where " + strField + " like '%" + xData.SyntaxFilter(strBlurb) + "%'");
        }

        public void ReplaceField(String strField, String strFind, String strReplace)
        {
            xData.Execute("update " + TableName + " set " + strField + " = '" + xData.SyntaxFilter(strReplace) + "' where isnull(" + strField + ", '') = '" + xData.SyntaxFilter(strFind) + "'");
        }

        public void ReplacePartial(String strField, String strFind, String strReplace)
        {
            xData.Execute("update " + TableName + " set " + strField + " = replace(" + strField + ", '" + xData.SyntaxFilter(strFind) + "', '" + xData.SyntaxFilter(strReplace) + "')");
        }

        public void ChopDecimals(String strField)
        {
            xData.Execute("update " + TableName + " set " + strField + " = LEFT(" + strField + ", CHARINDEX('.', " + strField + ") - 1) where " + strField + " like '%.%'");
        }

        public void ChopLeadingCharacters(String strField, String strChar)
        {
            if (!Tools.Strings.StrExt(strChar))
                return;

            int iLength = strChar.Length + 1;
            String strSQL = "update " + TableName + " set " + strField + " = SUBSTRING(" + strField + ", " + iLength.ToString() + ", 4096) where " + strField + " like '" + xData.SyntaxFilter(strChar) + "%'";

            long l = -1;
            int x = 0;
            while (l != 0)
            {
                xData.Execute(strSQL, ref l);

                x++;
                if (x > 100)
                {
                    throw new Exception("Too many leading '" + strChar + "' characters");
                }
            }
        }

        public void ConvertField(ContextNM x, String strField, ArrayList replacements, FieldType dt, String strInvalid, String strFieldType, String strCaption, String strDefault)
        {
            if (!xData.IsTextField(TableName, strField))
                return;

            //replacements
            if (replacements != null)
            {
                foreach (String s in replacements)
                {
                    String s1 = Tools.Strings.ParseDelimit(s, "|", 1);
                    String s2 = Tools.Strings.ParseDelimit(s, "|", 2);

                    ReplaceField(strField, s1, s2);
                }
            }

            //trim it
            xData.Execute("update " + TableName + " set " + strField + " = LTRIM(RTRIM(" + strField + "))");

            //get rid of chr(160)
            Char c160 = Convert.ToChar(160);
            String s160 = c160.ToString();
            xData.Execute("update " + TableName + " set " + strField + " = replace(" + strField + ", '" + s160 + "', '')");

            Int64 l = 0;
            if (Tools.Strings.StrExt(strInvalid))
            {
                l = xData.GetScalar_Long("select count(*) from " + TableName + " where " + strInvalid);
            }

            if (l > 0)
            {
                Enums.DataConversionType t = AskConversionType(x, strField, strCaption, ref strDefault, l, dt);

                switch (t)
                {
                    case NewMethod.Enums.DataConversionType.Cancel:
                        throw new Exception("Cancel");
                    case NewMethod.Enums.DataConversionType.DeleteRow:
                        xData.Execute("delete from " + TableName + " where " + strInvalid);
                        break;
                    case NewMethod.Enums.DataConversionType.SetDefault:

                        switch (strDefault.Trim().ToLower())
                        {
                            case "<no date>":
                                strDefault = Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(Tools.Dates.NullDate);
                                break;
                        }

                        long la = 0;
                        xData.Execute("update " + TableName + " set " + strField + " = '" + xData.SyntaxFilter(strDefault) + "' where " + strInvalid, ref la);
                        x.TheLeader.Comment(Tools.Number.LongFormat(la) + " lines were set to " + strDefault);
                        break;
                }

                l = xData.GetScalar_Long("select count(*) from " + TableName + " where " + strInvalid);
                if (l != 0)
                    throw new Exception("Invalid records remain");
            }

            xData.Execute("alter table " + TableName + " drop column " + strField + "_temp", true);

            xData.Execute("alter table " + TableName + " add " + strField + "_temp " + strFieldType);
            xData.Execute("update " + TableName + " set " + strField + "_temp = cast(replace(" + strField + ", ',', '') as " + strFieldType + ")");
            xData.Execute("alter table " + TableName + " drop column " + strField);
            xData.RenameField(TableName, strField + "_temp", strField);
        }

        public Enums.DataConversionType AskConversionType(ContextNM x, String strField, String strCaption, ref String def, Int64 l, FieldType fieldType)
        {
            String s = Tools.Number.LongFormat(l) + " item(s) appear to have values in the " + strField + " column that can't be converted to a valid " + strCaption + ", and will be removed from the list.  How do you want to proceed?";
            return ((ILeaderNM)x.TheLeader).AskConversionType(ref def, s, fieldType);
        }

        public void ConvertField_Boolean(ContextNM x, String strField)
        {
            ArrayList a = new ArrayList();
            a.Add("true|1");
            a.Add("false|0");
            a.Add("yes|1");
            a.Add("no|0");
            a.Add("y|1");
            a.Add("n|0");
            a.Add("x|1");

            ConvertField(x, strField, a, FieldType.Boolean, strField + " <> '0' and " + strField + " <> '1'", "bit", "yes/no value", "0");
        }

        public void ConvertField_Date(ContextNM x, String strField)
        {
            ArrayList a = new ArrayList();
            a.Add("now|" + nTools.DateFormat(System.DateTime.Now));
            a.Add("today|" + nTools.DateFormat(System.DateTime.Now));
            a.Add("|" + nTools.DateFormat(Tools.Dates.GetNullDate()));
            ConvertField(x, strField, a, FieldType.DateTime, "isdate(" + strField + ") = 0", "datetime", "date", "<no date>");
        }

        public void ConvertField_Long(ContextNM x, String strField)
        {
            if (!xData.IsTextField(TableName, strField))
                return;

            NumberFilter(strField);
            ChopDecimals(strField);
            ChopLeadingCharacters(strField, "0");

            ArrayList a = new ArrayList();
            a.Add("zero|0");
            a.Add("none|0");
            a.Add("|0");

            CheckCriteria(x, "have a higher value in " + strField + " than the system supports", "len(replace(" + strField + ", '-', '')) > 8");
            ConvertField(x, strField, a, FieldType.Int64, "isnumeric(" + strField + ") = 0", "int", "number", "0");
        }

        public void ConvertField_Float(ContextNM x, String strField)
        {
            NumberFilter(strField);

            ArrayList a = new ArrayList();
            a.Add("zero|0");
            a.Add("none|0");
            a.Add("|0");
            a.Add("-|0");

            ConvertField(x, strField, a, FieldType.Double, "isnumeric(" + strField + ") = 0", "float", "number", "0");
        }

        public void SetFieldIfBlank(String strField, String strValue)
        {
            xData.Execute("update " + TableName + " set " + strField + " = '" + xData.SyntaxFilter(strValue) + "' where isnull(" + strField + ", '') = ''");
        }

        public void AddField(String strField)
        {
            AddField(strField, "varchar(255)", "''");
        }

        public void AddDateField(String strField)
        {
            AddField(strField, "datetime", "cast('01/01/1900' as datetime)");
        }

        public void AddField(String strField, String strType, String strBlank)
        {
            if (!TableMode)
                throw new Exception("This data table is not in 'Table Mode'.");

            if (xData.FieldExists(TableName, strField))
                return;

            xData.Execute("alter table " + TableName + " add " + strField + " " + strType + " ", FailOK: true);
            xData.Execute("update " + TableName + " set " + strField + " = " + strBlank + " where " + strField + " is null");
        }

        public bool FieldExists(String strField)
        {
            return xData.FieldExists(TableName, strField);
        }

        public void LinkInInfo(String strLocalTargetField, String strLocalKeyField, String strRemoteTable, String strRemoteKeyField, String strRemoteValueField)
        {
            String strSQL = "update " + TableName + " set " + strLocalTargetField + " = ( select max(" + strRemoteValueField + ") from " + strRemoteTable + " where " + strRemoteTable + "." + strRemoteKeyField + " = " + TableName + "." + strLocalKeyField + ") where isnull(" + TableName + "." + strLocalKeyField + ", '') > ''";
            xData.Execute(strSQL);
        }

        public bool NumberFilter(String strField)
        {
            ReplacePartial(strField, "A", "");
            ReplacePartial(strField, "B", "");
            ReplacePartial(strField, "C", "");
            ReplacePartial(strField, "dataTable", "");
            ReplacePartial(strField, "E", "");
            ReplacePartial(strField, "F", "");
            ReplacePartial(strField, "K", "000");
            ReplacePartial(strField, "$", "");
            ReplacePartial(strField, ",", "");
            ReplacePartial(strField, "USD", "");
            ReplacePartial(strField, "US", "");
            ReplacePartial(strField, " ", "");
            ReplacePartial(strField, "(", "-");
            ReplacePartial(strField, ")", "");
            return true;
        }

        public void SetProgressPercent(Int32 total, Int32 current)
        {
            SetProgressPercent(Convert.ToInt64(total), Convert.ToInt64(current));
        }

        public void SetProgressPercent(Int64 total, Int64 current)
        {
            SetProgress(Convert.ToInt32(Math.Round(Convert.ToDouble((Convert.ToDouble(current) / Convert.ToDouble(total)) * 100), 0)));
        }

        public ArrayList GetQuickRows()
        {
            return Rows;
        }

        public ArrayList GetAllRows(ContextNM context)
        {
            if (TableMode)
                return SelectRows(context);
            else
                return Rows;
        }

        public ArrayList SelectRows(ContextNM context)
        {
            return SelectRows(context, -1);
        }

        public ArrayList SelectRows(ContextNM context, int limit)
        {
            ArrayList a = new ArrayList();

            try
            {
                String s = "select";
                if (limit > 0)
                    s += " top " + limit.ToString();
                s += " * from " + TableName + " order by unique_order";

                DataTable dataTable = xData.Select(s);
                if (dataTable == null)
                    return a;

                foreach (DataRow r in dataTable.Rows)
                {
                    nDataRow row = new nDataRow(nData.NullFilter_String(r["unique_id"]), nData.NullFilter_Long(r["unique_order"]));
                    foreach (nDataColumn c in Columns)
                    {
                        row.Values.Add(nData.NullFilter_String(r[c.unique_id]));
                    }
                    a.Add(row);
                }
            }
            catch (Exception ex)
            {
                context.TheLeader.Comment("Error: " + ex.Message);
            }
            return a;
        }

        public void CreateTheTable()
        {
            String strSQL = "create table " + TableName + " ( unique_id varchar(255), unique_order int ";
            foreach (nDataColumn c in Columns)
            {
                strSQL += ", " + c.unique_id + " varchar(" + FieldLength.ToString() + ")";
            }
            strSQL += " ) ";

            xData.Execute(strSQL);
        }

        private void SetColumns(int i)
        {
            for (int j = 0; j < i; j++)
            {
                Columns.Add(new nDataColumn(j));
            }
        }

        //public void SetColumnProperty(int i, String s, FieldType t)
        //{
        //    try
        //    {
        //        nDataColumn c = (nDataColumn)Columns[i];
        //        CoreVarValAttribute p = null;  // new n_prop(s, "", 255, (Int32)t, -1);
        //        c.p = p;
        //    }
        //    catch (Exception)
        //    { }
        //}

        public void Clear()
        {
            Columns = new ArrayList();
            Rows = new ArrayList();
            SetCount(0);

            if (TableMode)
            {
                TableMode = false;
                if (xData.TableExists(TableName))
                    xData.DropTable(TableName);
            }
        }

        public String GetFirstValue(int c)
        {
            return GetRowValue(0, c);
        }

        public String GetRowValue(int row, int c)
        {
            if (Rows == null)
                return "";

            if (Rows.Count == 0)
                return "";

            try
            {
                nDataRow r = (nDataRow)Rows[row];
                if (c >= r.Values.Count)
                    return "";

                return (String)r.Values[c];
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool HasColumnField(String strField)
        {
            foreach (nDataColumn c in Columns)
            {
                if (c.p != null)
                {
                    if (Tools.Strings.StrCmp(strField, c.p.Name))
                        return true;
                }
            }
            return false;
        }

        public String TranslatePropertyToField(String strProperty)
        {
            foreach (nDataColumn c in Columns)
            {
                if (c.p != null)
                {
                    if (Tools.Strings.StrCmp(strProperty, c.p.Name))
                        return c.unique_id;
                }
            }
            return "";
        }

        public nDataColumn GetColumnField(String strField)
        {
            foreach (nDataColumn c in Columns)
            {
                if (c.p != null)
                {
                    if (Tools.Strings.StrCmp(strField, c.p.Name))
                        return c;
                }
            }
            return null;
        }

        public nDataColumn GetColumnByID(String strID)
        {
            foreach (nDataColumn c in Columns)
            {
                if (Tools.Strings.StrCmp(strID, c.unique_id))
                    return c;
            }
            return null;
        }

        public String[] GetColumnSampleByField(String strField)
        {
            return GetColumnSample(GetColumnField(strField));
        }

        public String[] GetColumnSample(nDataColumn c)
        {
            try
            {
                if (c == null)
                    return new String[] { "" };

                int i = Rows.Count;
                if (i > 10)
                    i = 10;

                String[] ary = new String[i];

                for (int j = 0; j < i; j++)
                {
                    nDataRow r = (nDataRow)Rows[j];
                    ary[j] = (String)r.Values[c.order];
                }

                return ary;
            }
            catch (Exception)
            {
                return new String[] { "" };
            }
        }

        public bool CheckDuplicateFields(ContextNM context)
        {
            ArrayList a = new ArrayList();
            String s = "";
            bool b = true;
            foreach (nDataColumn c in Columns)
            {
                if (c.p != null)
                {
                    if (a.Contains(c.p.Name.ToLower()))
                    {
                        b = false;
                        s += c.p.Name + "\r\n";
                    }
                    else
                    {
                        a.Add(c.p.Name.ToLower());
                    }
                }
            }

            if (!b)
                context.TheLeader.Tell("Duplicate column matchings were found:\r\n\r\n" + s);

            return b;
        }

        public bool HasNonExtraColumnField(String strField)
        {
            foreach (nDataColumn c in Columns)
            {
                if (!c.IsExtra)
                {
                    if (c.p != null)
                    {
                        if (Tools.Strings.StrCmp(strField, c.p.Name))
                            return true;
                    }
                }
            }
            return false;
        }

        public void ImportObjects(ContextNM context, String strClass, String unique_id_field, List<CoreVarValAttribute> props, ArrayList TakenCareOf, ref Int64 importcount)
        {
            ImportObjects(context, strClass, unique_id_field, props, TakenCareOf, ref importcount, "");
        }

        public void ImportObjects(ContextNM context, String strClass, String unique_id_field, List<CoreVarValAttribute> props, ArrayList TakenCareOf, ref Int64 importcount, String extra_where)
        {
            String strFields = "";
            String strValues = "";
            foreach (CoreVarValAttribute p in context.TheSys.CoreClassGet(strClass).VarValsGet())
            {
                strFields += ", " + p.Name;
                if (nTools.IsInArray(p.Name, TakenCareOf) || HasNonExtraColumnField(p.Name))
                {
                    String strX = "";
                    switch (p.TheFieldType)
                    {
                        case Tools.Database.FieldType.String:

                            if (p.TheFieldLength > 0)
                                strX = ", left(" + p.Name + ", " + p.TheFieldLength.ToString() + ")";
                            else
                                strX = ", left(" + p.Name + ", 50)";
                            break;
                        default:
                            strX = ", " + p.Name;
                            break;
                    }
                    strValues += strX;
                }
                else
                    strValues += ", " + DataConnectionSqlServer.ReplaceNullString(p.TheFieldType) + " as " + p.Name;
            }
            String strSQL = "insert into " + strClass + " (unique_id " + strFields + ") select " + unique_id_field + " " + strValues + " from " + TableName + " where " + unique_id_field + " <> 'not an id' and " + unique_id_field + " not in ( select unique_id from " + strClass + " ) " + extra_where;   // + " group by " + unique_id_field + " " + strGroup
            //Tools.FileSystem.PopText(strSQL);
            SetStatus("Importing...");
            try { xData.Execute(strSQL, ref importcount, false); }
            catch (Exception ee) { context.Leader.Tell("Error Importing: " + ee.Message); }
            SetStatus("Import Executed...");
        }

        public void CheckCriteria(ContextNM x, String strCaptionPiece, String strWhere)
        {
            long count = 0;
            CheckCriteria(x, strCaptionPiece, strWhere, ref count);
        }

        public void CheckCriteria(ContextNM x, String strCaptionPiece, String strWhere, ref long count)
        {
            count = 0;
            long l = xData.GetScalar_Long("select count(*) from " + TableName + " where " + strWhere);
            if (l > 0)
            {
                if (!x.TheLeader.AskYesNo(Tools.Number.LongFormat(l) + " item(s) appear to " + strCaptionPiece + ", and will be removed from the list.  Do you want to continue?"))
                    throw new Exception("Canceled");

                xData.Execute("delete from " + TableName + " where " + strWhere, ref count);
                RefreshFromDatabase(x);
            }
        }

        public void ConvertToText()
        {
            if (!TableMode)
                return;

            SetProgress(0);
            int i = 0;
            foreach (nDataColumn c in Columns)
            {
                ConvertToText(c.unique_id);
                i++;
                SetProgressPercent(Columns.Count, i);
            }
        }

        public void ConvertToText(String strField)
        {
            if (xData.IsTextField(TableName, strField))
                return;

            xData.Execute("alter table " + TableName + " drop column " + strField + "_temp", FailOK: true);
            xData.Execute("alter table " + TableName + " add " + strField + "_temp varchar(255)");

            if (xData.IsDecimalField(TableName, strField))
                xData.Execute("update " + TableName + " set " + strField + "_temp = LTRIM(RTRIM(STR(ROUND(" + strField + ",6),10,6)))");
            else
                xData.Execute("update " + TableName + " set " + strField + "_temp = cast(" + strField + " as varchar(255))");

            xData.Execute("alter table " + TableName + " drop column " + strField);
            xData.RenameField(TableName, strField + "_temp", strField);
        }

        public void ClearBlankRows()
        {
            String s = "";
            foreach (nDataColumn c in Columns)
            {
                if (Tools.Strings.StrExt(s))
                    s += " and ";
                s += "isnull(" + c.unique_id + ", '') = ''";
            }

            if (!Tools.Strings.StrExt(s))
                return;

            xData.Execute("delete from " + TableName + " where " + s);
        }

        public void RefreshFromDatabase(ContextNM context)
        {
            if (!TableMode)
                return;

            Rows = SelectRows(context, TableModeLevel);
            RefreshCount();
        }

        public void RefreshCount()
        {
            SetCount(xData.GetScalar_Long("select count(*) from " + TableName));
        }

        public void SetCount(long l)
        {
            m_count = l;
        }

        public void RemoveDuplicates(ContextNM context, String strField, bool silent)
        {
            RemoveDuplicates(context, strField, silent, TableName, strField);
        }

        public void RemoveDuplicates(ContextNM context, String strField, bool silent, String strMatchTable, String strMatchField)
        {
            String strSQL = "";
            String strUT = "temp_duplicate_" + TableName;
            String strFT = "temp_filter_" + TableName;

            xData.DropTable(strUT);
            xData.DropTable(strFT);

            //make a temp table with the uid, the order, and the value of each duplicated line
            strSQL = "create table " + strUT + "( unique_id varchar(255), unique_value varchar(" + FieldLength.ToString() + ") )";
            xData.Execute(strSQL);

            int limit = 0;
            if (Tools.Strings.StrCmp(TableName, strMatchTable))
                limit = 1;

            strSQL = "insert into " + strUT + "( unique_id, unique_value ) select unique_id, " + strField + " from " + TableName + " where (select count(*) from " + strMatchTable + " x where x." + strMatchField + " = " + TableName + "." + strField + ") > " + limit.ToString() + " ";
            xData.Execute(strSQL);

            //only filter them if the match is with itself.  otherwise all duplicates need to go
            if (Tools.Strings.StrCmp(TableName, strMatchTable))
            {
                //make another table with the max unique id of each, grouped by the unique value
                strSQL = "select max(unique_id) as unique_id, unique_value into " + strFT + " from " + strUT + " group by unique_value";
                xData.Execute(strSQL);

                //remove the max ones
                strSQL = "delete from " + strUT + " where unique_id in (select unique_id from " + strFT + ")";
                xData.Execute(strSQL);
            }

            //check them
            if (!silent)
            {
                long l = xData.GetScalar_Long("select count(*) from " + TableName + " where exists( select * from " + strUT + " ut where ut.unique_id = " + TableName + ".unique_id)");
                if (l > 0)
                {
                    if (!context.TheLeader.AskYesNo(Tools.Number.LongFormat(l) + " item(s) appear to contain duplicate " + strField + " values, and will be removed.  Do you want to continue?"))
                        throw new Exception("Canceled");
                }
            }

            //remove items that are in table 1 and not in table 2
            strSQL = "delete from " + TableName + " where exists( select * from " + strUT + " ut where ut.unique_id = " + TableName + ".unique_id)";
            xData.Execute(strSQL);

            RefreshFromDatabase(context);
            xData.DropTable(strUT);
            xData.DropTable(strFT);
        }

        public long CountSpecificValue(int col, String val)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                return -1;

            return xData.GetScalar_Long("select count(*) from " + TableName + " where isnull(" + c.unique_id + ", '') = '" + xData.SyntaxFilter(val) + "'");
        }

        public String GetColumnNameByColumnIndex(int col)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                return "";
            else
                return c.unique_id;
        }

        public long CountIncludingValue(int col, String val)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                return -1;

            return xData.GetScalar_Long("select count(*) from " + TableName + " where isnull(" + c.unique_id + ", '') like '%" + xData.SyntaxFilter(val) + "%'");
        }

        public long CountWithValue(int col)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                return -1;
            return xData.GetScalar_Long("select count(*) from " + TableName + " where len(isnull(" + c.unique_id + ", '')) > 0");
        }

        public void DeleteSpecificValue(int col, String val, ref long l)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Column not found");

            xData.Execute("delete from " + TableName + " where isnull(" + c.unique_id + ", '') = '" + xData.SyntaxFilter(val) + "'", ref l);
        }

        public void TruncateIncludingValue(int col, String val, ref long l)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Field not found");

            xData.Execute("update " + TableName + " set " + c.unique_id + " = left(" + c.unique_id + ", len(" + c.unique_id + ") - (charindex('" + xData.SyntaxFilter(val) + "', reverse(" + c.unique_id + ")) + 0)) where isnull(" + c.unique_id + ", '') like '%" + xData.SyntaxFilter(val) + "%'", ref l);
        }

        public void TruncateIncludingValue_Left(int col, String val, ref long l)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Field not found");

            xData.Execute("update " + TableName + " set " + c.unique_id + " = SubString(" + c.unique_id + ", charindex('" + xData.SyntaxFilter(val) + "', " + c.unique_id + ") + 1, 4096) where isnull(" + c.unique_id + ", '') like '%" + xData.SyntaxFilter(val) + "%'", ref l);
        }

        public void SplitEmailDomain(ContextNM context, int col, ref long l)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Field not found");

            nDataColumn n = new nDataColumn(Columns.Count);
            AddField(n.unique_id);
            Columns.Add(n);
            xData.SplitEmailDomain(TableName, c.unique_id, n.unique_id, ref l, "");

            RefreshFromDatabase(context);
        }

        public void SplitColumnIntoColumns(ContextNM context, int col, String by, ref long l)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Column not found");

            long lcount = CountIncludingValue(col, by);
            long xl = 0;
            while (lcount > 0)
            {
                SplitOnValue_Left(context, col, by, ref xl, true);
                lcount = CountIncludingValue(col, by);
            }

            RefreshFromDatabase(context);
        }

        public void SplitOnValue_Right(ContextNM context, int col, String val, ref long l, bool suppress_refresh)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Column not found");


            nDataColumn n = new nDataColumn(Columns.Count);
            AddField(n.unique_id);
            Columns.Add(n);

            xData.SplitFieldRight(TableName, c.unique_id, n.unique_id, val, ref l);
            TruncateIncludingValue(col, val, ref l);

            if (!suppress_refresh)
                RefreshFromDatabase(context);
        }

        public void SplitOnValue_Left(ContextNM context, int col, String val, ref long l, bool suppress_refresh)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Column not found");

            nDataColumn n = new nDataColumn(Columns.Count);
            AddField(n.unique_id);

            Columns.Add(n);

            xData.SplitFieldLeft(TableName, c.unique_id, n.unique_id, val, ref l);
            TruncateIncludingValue_Left(col, val, ref l);

            if (!suppress_refresh)
                RefreshFromDatabase(context);
        }

        public void AppendColumn(ContextNM context, int col, String strAppendCol, String strSeparator)
        {
            nDataColumn c = (nDataColumn)Columns[col];
            if (c == null)
                throw new Exception("Column not found");

            nDataColumn a = GetColumnByID(strAppendCol);
            if (a == null)
                throw new Exception("Other column not found");

            if (strSeparator.Length > 0)
                xData.Execute("update " + TableName + " set " + c.unique_id + " = isnull(" + c.unique_id + ", '') + '" + strSeparator + "' + isnull(" + a.unique_id + ", '')");
            else
                xData.Execute("update " + TableName + " set " + c.unique_id + " = isnull(" + c.unique_id + ", '') + isnull(" + a.unique_id + ", '')");

            RefreshFromDatabase(context);
        }

        public void ExportToCsv()
        {
            String s = "";
            foreach (nDataColumn c in Columns)
            {
                if (Tools.Strings.StrExt(s))
                    s += ", ";
                s += c.unique_id;
            }
            string folder = "c:\\Exports\\";
            if (!Tools.Folder.FolderExists(folder))
                Tools.Folder.MakeFolderExist(folder);
            String strFile = folder + "temp_" + Tools.Strings.GetNewID() + ".csv";
            long l = 0;
            xData.ExportSQLToCsv("select " + s + " from " + TableName, strFile, ref l);
            nTools.ExploreFolder(folder);
        }

        public void AbsorbSQL(ContextNM context, DataConnection data, String strSQL)
        {
            DataTable dataTable = data.Select(strSQL);
            if (dataTable == null)
                throw new Exception("No data");

            AbsorbDataTable(context, dataTable);
        }

        public void AbsorbDataTable(ContextNM context, DataTable dataTable)
        {
            InitTableMode();

            String strTable = "temp_" + Tools.Strings.GetNewID();
            xData.ImportDataTable(dataTable, strTable);

            String strSQL2 = "select *, IDENTITY(int, 0, 1) as temp_unique_order, cast(newid() as varchar(255)) as unique_id into " + TableName + " from " + strTable;
            xData.Execute(strSQL2);

            FilterDatabaseColumns();

            xData.Execute("alter table " + TableName + " add unique_order int");
            xData.Execute("update " + TableName + " set unique_order = temp_unique_order");
            xData.Execute("alter table " + TableName + " drop column temp_unique_order");

            CleanTheData();
            RefreshFromDatabase(context);
        }

        public void SetUniqueOrder()
        {
            try
            {
                xData.Execute("alter table " + TableName + " add temp_unique_order int IDENTITY");
                xData.Execute("update " + TableName + " set unique_order = temp_unique_order");
                xData.Execute("alter table " + TableName + " drop column temp_unique_order");
            }
            catch { }
        }

        public nDataTableHandle GetAsHandle()
        {
            nDataTableHandle h = new nDataTableHandle();
            h.xTable = this;
            return h;
        }

        public nDataTable Process(ContextNM x)
        {
            String s = "";
            foreach (nDataColumn c in this.Columns)
            {
                if (s != "")
                    s += ", ";
                s += c.unique_id;
            }

            DataTable orig = xData.Select("select " + s + " from " + TableName + " order by unique_order");
            List<ColumnAction> actions = x.LeaderNM.AskForColumnActions(orig);
            if (actions == null)
                return null;

            nDataTable ret = new nDataTable(xData);
            ret.AbsorbDataTable(x, nDataManipilation.ProcessTable(orig, actions));
            return ret;
        }
    }

    public class nDataColumn
    {
        public CoreVarValAttribute p;
        public int order = -1;
        public String m_Caption = "<click here>";
        public string Caption
        {
            get
            {
                if (m_Caption == "<click here>")
                {
                    if (Tools.Strings.StrExt(Heading))
                        return m_Caption + " [" + Heading + "]";
                    else
                        return m_Caption + " ";
                }
                else
                    return m_Caption;
            }

            set
            {
                m_Caption = value;
            }
        }

        public bool IsExtra = false;
        public String unique_id = "column_" + Tools.Strings.GetNewID();
        public String Heading = "";

        public nDataColumn(int o)
        {
            order = o;
        }
    }

    public class nDataRow
    {
        public String unique_id = Tools.Strings.GetNewID();
        public Int64 unique_order = -1;
        public ArrayList Values = new ArrayList();

        public nDataRow(Int64 order)
        {
            unique_order = order;
        }

        public nDataRow(String strID, Int64 order)
        {
            unique_id = strID;
            unique_order = order;
        }
    }

    public class nDataTableHandle : IRefreshable
    {
        public static ArrayList GetCommonFields(DataConnection xd, ArrayList handles)
        {
            ArrayList common = null;
            foreach (nDataTableHandle h in handles)
            {
                ArrayList x = xd.GetFieldArray(h.TableName);
                if (common == null)
                {
                    common = new ArrayList();
                    foreach (String s in x)
                    {
                        if (!IgnoreField(s))
                            common.Add(s.ToLower().Trim());
                    }
                }
                else
                {
                    foreach (String s in x)
                    {
                        if (!IgnoreField(s) && !common.Contains(s.ToLower().Trim()))
                            common.Add(s.ToLower().Trim());
                    }
                }
            }

            return common;
        }

        static bool IgnoreField(String s)
        {
            if (Tools.Strings.StrCmp(s, "unique_order"))
                return true;

            if (Tools.Strings.StrCmp(s, "temp_unique_order"))
                return true;

            if (s.StartsWith("column_"))
                return true;

            return false;
        }

        public static bool CombineTables(ContextNM context, nDataTable result, ArrayList handles, ArrayList fields, nRefresh xr)
        {
            result.InitTableMode();
            result.CreateTheTable();
            foreach (String s in fields)
            {
                result.AddField(s);
            }

            foreach (nDataTableHandle h in handles)
            {

                String strFields = "";
                String strValues = "";
                foreach (String s in fields)
                {
                    if (Tools.Strings.StrExt(strFields))
                        strFields += ", ";

                    if (Tools.Strings.StrExt(strValues))
                        strValues += ", ";

                    strFields += s;

                    if (h.xTable.FieldExists(s))
                        strValues += s;
                    else
                        strValues += "''";
                }

                String strSQL = "insert into " + result.TableName + " ( " + strFields + " ) select " + strValues + " from " + h.TableName;
                long l = 0;
                result.xData.Execute(strSQL, ref l);
                context.TheLeader.Comment("Added " + Tools.Number.LongFormat(l) + " rows from " + h.TableName);
                result.RefreshCount();
                xr.Refresh();
            }

            result.ScanColumnsWithoutChanges();
            result.SetUniqueOrder();
            result.RefreshFromDatabase(context);
            return true;
        }

        public System.Windows.Forms.ListViewItem xItem;
        public System.Windows.Forms.Control xControl;

        public nDataTable xTable;

        public String TableName
        {
            get
            {
                return xTable.TableName;
            }
        }

        public long RowCount
        {
            get
            {
                return xTable.Count;
            }
        }

        public System.Windows.Forms.Control RefreshControl
        {
            get
            {
                return xControl;
            }
        }

        public void DoRefresh()
        {
            if (xItem != null)
            {
                xItem.Text = TableName;
                xItem.SubItems[1].Text = Tools.Number.LongFormat(RowCount);
            }
        }
    }

    public class nDataTableCancelArgs
    {
        public bool Cancel = false;
    }

    namespace Enums
    {
        public enum DataConversionType
        {
            Cancel = 1,
            DeleteRow = 2,
            SetDefault = 3,
        }
    }

    public class nVar
    {
        public String variable_name = "";
        public Tools.Database.FieldType variable_type = Tools.Database.FieldType.Unknown;
        public Object variable_value = null;
        public Boolean b = false;

        public nVar()
        {

        }

        public nVar(CoreVarValAttribute p)
        {
            variable_name = p.Name;
            variable_type = p.TheFieldType;
            variable_value = p.TheFieldType;  //  ?? what is all this? nTools.ReplaceNull(p.property_type);
        }
    }
}
