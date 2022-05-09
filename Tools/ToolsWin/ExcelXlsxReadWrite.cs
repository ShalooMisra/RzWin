//// Excel2007ReadWrite created by Zeljko Svedic. This source code is free to use, modify and 
//// incorporate in your software products. This code is not owned by GemBoxSoftware.com or is
//// related in any way to GemBox.Spreadsheet Free/Professional .NET component.

//using System;
//using System.IO;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;
//using System.Data;
//using System.Xml;
//using ICSharpCode.SharpZipLib.Zip;

//namespace ToolsWin
//{
//    public class ExcelXlsx
//    {
//        public static void DeleteDirectoryContents(string directory)
//        {
//            DirectoryInfo di = new DirectoryInfo(directory);

//            foreach (FileInfo currFile in di.GetFiles())
//                currFile.Delete();

//            foreach (DirectoryInfo currDir in di.GetDirectories())
//                currDir.Delete(true);
//        }

//        public static void UnzipFile(string zipFileName, string targetDirectory)
//        {
//            (new FastZip()).ExtractZip(zipFileName, targetDirectory, null);
//        }

//        public static void ZipDirectory(string sourceDirectory, string zipFileName)
//        {
//            (new FastZip()).CreateZip(zipFileName, sourceDirectory, true, null);
//        }

//        public static ArrayList ReadStringTable(Stream input)
//        {
//            ArrayList stringTable = new ArrayList();

//            using (XmlTextReader reader = new XmlTextReader(input))
//            {
//                for (reader.MoveToContent(); reader.Read(); )
//                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "t")
//                        stringTable.Add(reader.ReadElementString());
//            }

//            return stringTable;
//        }

//        public static DateTime ConvertToDateTime(double excelDate)
//        {
//            if (excelDate < 1)
//            {
//                throw new ArgumentException("Excel dates cannot be smaller than 0.");
//            }
//            DateTime dateOfReference = new DateTime(1900, 1, 1);
//            if (excelDate > 60d)
//            {
//                excelDate = excelDate - 2;
//            }
//            else
//            {
//                excelDate = excelDate - 1;
//            }
//            return dateOfReference.AddDays(excelDate);
//        } 

//        public static DataTable ReadWorksheet(Stream input, ArrayList stringTable, DataTable data)
//        {
//            using (XmlTextReader reader = new XmlTextReader(input))
//            {
//                ArrayList list = new ArrayList();
//                DataRow dr = null;
//                int colIndex = 0;
//                string type;
//                double val = 1;
//                string span;

//                for (reader.MoveToContent(); reader.Read(); )
//                {
//                    if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "sheetData" && dr != null)
//                        data.Rows.Add(dr);
//                    if (reader.NodeType == XmlNodeType.Element && reader.NodeType != XmlNodeType.EndElement)
//                    {
//                        switch (reader.Name)
//                        {
//                            case "row":
//                                span = reader.GetAttribute("spans");
//                                char[] separator = new char[] { ':' };
//                                string[] range = new string[2];
//                                range = span.Split(separator, 2);

//                                if (data.Columns.Count < Convert.ToInt32(range[1]))
//                                {
//                                    for (int i = 0; i < Convert.ToInt32(range[1]); i++)
//                                    {
//                                        DataColumn column = new DataColumn();
//                                        column.ColumnName = "F" + (i + 1).ToString();
//                                        data.Columns.Add(column);

//                                    }
//                                }
//                                if (colIndex != 0)
//                                {
//                                    data.Rows.Add(dr);

//                                }
//                                dr = data.NewRow();

//                                colIndex = 0;

//                                break;

//                            case "c":
//                                StringBuilder cols = new StringBuilder();
//                                StringBuilder row = new StringBuilder();
//                                string str = reader.GetAttribute("r");
//                                type = reader.GetAttribute("t");
//                                reader.Read();
//                                if (reader.NodeType == XmlNodeType.EndElement)
//                                    break;
//                                val = Convert.ToDouble(reader.ReadElementString());

//                                if (type == "s")
//                                {
//                                    int index = (int)val;
//                                    dr[colIndex] = stringTable[index];
//                                }
//                                else
//                                    dr[colIndex] = val;
//                                colIndex++;

//                                break;

//                        }
//                    }
//                }
  
//            }

//            return data;
//        }

//        public static ArrayList CreateStringTables(DataTable data, out Hashtable lookupTable)
//        {
//            ArrayList stringTable = new ArrayList();
//            lookupTable = new Hashtable();

//            foreach (DataRow row in data.Rows)
//                foreach (DataColumn column in data.Columns)
//                    if (column.DataType == typeof(string))
//                    {
//                        string val = (string)row[column];

//                        if (!lookupTable.Contains(val))
//                        {
//                            lookupTable.Add(val, stringTable.Count);
//                            stringTable.Add(val);
//                        }
//                    }

//            return stringTable;
//        }

//        public static void WriteStringTable(Stream output, ArrayList stringTable)
//        {
//            using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.UTF8))
//            {
//                writer.WriteStartDocument(true);

//                writer.WriteStartElement("sst");
//                writer.WriteAttributeString("xml:space", "preserve");
//                writer.WriteAttributeString("xmlns", "http://schemas.microsoft.com/office/excel/2006/2");
//                writer.WriteAttributeString("count", stringTable.Count.ToString());
//                writer.WriteAttributeString("uniqueCount", stringTable.Count.ToString());

//                foreach (string str in stringTable)
//                {
//                    writer.WriteStartElement("sstItem");
//                    writer.WriteElementString("t", str);
//                    writer.WriteEndElement();
//                }

//                writer.WriteEndElement();
//            }
//        }

//        public static string RowColumnToPosition(int row, int column)
//        {
//            return ExcelXlsx.ColumnIndexToName(column) + ExcelXlsx.RowIndexToName(row);
//        }

//        public static string ColumnIndexToName(int columnIndex)
//        {
//            char second = (char)(((int)'A') + columnIndex % 26);

//            columnIndex /= 26;

//            if (columnIndex == 0)
//                return second.ToString();
//            else
//                return ((char)(((int)'A') - 1 + columnIndex)).ToString() + second.ToString();
//        }

//        public static string RowIndexToName(int rowIndex)
//        {
//            return (rowIndex + 1).ToString();
//        }

//        public static void WriteWorksheet(Stream output, DataTable data, Hashtable lookupTable)
//        {
//            using (XmlTextWriter writer = new XmlTextWriter(output, Encoding.UTF8))
//            {
//                writer.WriteStartDocument(true);

//                writer.WriteStartElement("worksheet");
//                writer.WriteAttributeString("xml:space", "preserve");
//                writer.WriteAttributeString("xmlns", "http://schemas.microsoft.com/office/excel/2006/2");
//                writer.WriteAttributeString("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");

//                writer.WriteElementString("sheetPr", null);

//                writer.WriteStartElement("dimension");
//                string lastCell = ExcelXlsx.RowColumnToPosition(data.Rows.Count - 1, data.Columns.Count - 1);
//                writer.WriteAttributeString("ref", "A1:" + lastCell);
//                writer.WriteEndElement();

//                writer.WriteStartElement("sheetViews");
//                writer.WriteStartElement("sheetView");
//                writer.WriteAttributeString("tabSelected", "1");
//                writer.WriteAttributeString("workbookViewId", "0");
//                writer.WriteElementString("selection", null);
//                writer.WriteEndElement();
//                writer.WriteEndElement();

//                writer.WriteStartElement("sheetFormatPr");
//                writer.WriteAttributeString("defaultRowHeight", "15");
//                writer.WriteEndElement();

//                writer.WriteStartElement("sheetData");
//                ExcelXlsx.WriteWorksheetData(writer, data, lookupTable);
//                writer.WriteEndElement();

//                writer.WriteStartElement("sheetProtection");
//                writer.WriteAttributeString("objects", "0");
//                writer.WriteAttributeString("scenarios", "0");
//                writer.WriteEndElement();

//                writer.WriteElementString("printOptions", null);

//                writer.WriteStartElement("pageMargins");
//                writer.WriteAttributeString("left", "0.7");
//                writer.WriteAttributeString("right", "0.7");
//                writer.WriteAttributeString("top", "0.75");
//                writer.WriteAttributeString("bottom", "0.75");
//                writer.WriteAttributeString("header", "0.3");
//                writer.WriteAttributeString("footer", "0.3");
//                writer.WriteEndElement();

//                writer.WriteElementString("headerFooter", null);

//                writer.WriteEndElement();
//            }
//        }

//        public static void WriteWorksheetData(XmlTextWriter writer, DataTable data, Hashtable lookupTable)
//        {
//            int rowsCount = data.Rows.Count;
//            int columnsCount = data.Columns.Count;
//            string relPos;

//            for (int row = 0; row < rowsCount; row++)
//            {
//                writer.WriteStartElement("row");
//                relPos = ExcelXlsx.RowIndexToName(row);
//                writer.WriteAttributeString("r", relPos);
//                writer.WriteAttributeString("spans", "1:" + columnsCount.ToString());

//                for (int column = 0; column < columnsCount; column++)
//                {
//                    object val = data.Rows[row][column];

//                    writer.WriteStartElement("c");
//                    relPos = ExcelXlsx.RowColumnToPosition(row, column);
//                    writer.WriteAttributeString("r", relPos);

//                    if (val.GetType() == typeof(string))
//                    {
//                        writer.WriteAttributeString("t", "s");
//                        val = lookupTable[val];
//                    }

//                    writer.WriteElementString("v", val.ToString());

//                    writer.WriteEndElement();
//                }

//                writer.WriteEndElement();
//            }
//        }

//        public static DataTable XlsxWorksheetToDataTable(string fileName, string worksheet)
//        {
//            string tempDir = Path.GetTempPath();

//            // Delete contents of the temporary directory.
//            //ExcelXlsx.DeleteDirectoryContents(tempDir);

//            // Unzip input XLSX file to the temporary directory.
//            ExcelXlsx.UnzipFile(fileName, tempDir);

//            // Open XML file with table of all unique strings used in the workbook..
//            FileStream fs = new FileStream(tempDir + @"\xl\sharedStrings.xml",
//                FileMode.Open, FileAccess.Read);
//            // ..and call helper method that parses that XML and returns an array of strings.
//            ArrayList stringTable = ExcelXlsx.ReadStringTable(fs);

//            // Open XML file with worksheet data..
//            if (worksheet == null || worksheet == "")
//                worksheet = "sheet1";
//            worksheet += ".xml";
//            fs = new FileStream(tempDir + @"\xl\worksheets\" + worksheet,
//                FileMode.Open, FileAccess.Read);

//            DataTable dataTable = new DataTable();

//            // ..and call helper method that parses that XML and fills DataTable with values.
//            dataTable = ExcelXlsx.ReadWorksheet(fs, stringTable, dataTable);

//            return dataTable;
//        }
//    }
//}
