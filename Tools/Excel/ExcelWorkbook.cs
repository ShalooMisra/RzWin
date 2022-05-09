using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;

using OfficeOpenXml;

namespace OfficeInterop
{
    public class ExcelWorkbook
    {
        private ExcelPackage Package;
        private OfficeOpenXml.ExcelWorkbook Workbook;

        public ExcelWorkbook(ExcelPackage package, OfficeOpenXml.ExcelWorkbook workbook)
        {
            Package = package;
            Workbook = workbook;            
        }

        public ExcelWorksheet Worksheet(int baseOneIndex)
        {
            while (this.Workbook.Worksheets.Count < baseOneIndex)
            {
                this.Workbook.Worksheets.Add("Sheet" + (this.Workbook.Worksheets.Count + 1).ToString());
            }
            return new ExcelWorksheet(this.Workbook.Worksheets[baseOneIndex]);
        }

        public void Close(bool saveChanges)
        {
            if (saveChanges)
                Save();

            Package = null;
            Workbook = null;

            //is there anything to do here?  
        }

        public void Save()
        {
            Package.Save();
        }

        public void SaveAs(string fileName)
        {
            Package.SaveAs(new FileInfo(fileName));
        }

        public List<ExcelWorksheet> Worksheets
        {
            get
            {
                List<ExcelWorksheet> ret = new List<ExcelWorksheet>();
                foreach (OfficeOpenXml.ExcelWorksheet s in Workbook.Worksheets)
                {
                    ret.Add(new ExcelWorksheet(s));
                }
                return ret;
            }
        }
    }
}
