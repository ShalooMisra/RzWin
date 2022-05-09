using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OfficeInteropTest
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            //String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.Personal)) + Tools.Strings.GetNewID() + ".xls";
            //ExcelApplication xlApp = new ExcelApplication();
            //ExcelWorkbook xlBook;
            //xlBook = xlApp.AddWorkbook();// .OpenWorkbooks(@"c:\bilge\test.xls", false, false);
            //xlBook.SaveAs(strFile, ExcelSaveAsAccess.Exclusive);
            //ExcelWorksheet xlSheet = xlBook.get_Worksheet(1);
            //xlSheet.SetCellValue(1, 1, 34.56, "0.00");
            //xlSheet.SetCellValue(2, 1, 34.56, "0.00");
            //xlSheet.SetCellValue(3, 1, "=SUM(A1:A2)");     
            //xlBook.Save();
            //xlApp.Visible = true;
        }

        private void cmdWord_Click(object sender, EventArgs e)
        {
            //WordApplication word = new WordApplication();
            //WordDocument d = word.DocumentOpen(@"c:\bilge\testdoc.doc");
            //d.ReplaceText("<test>", "Lorem Ipsum", 0);
            //d.ReplacePicture(@"c:\bilge\nasco.jpg");
            //word.Visible = true;
        }

        private void cmdOutlook_Click(object sender, EventArgs e)
        {
            OutlookApplication xApp = new OutlookApplication();
            OutlookMAPIFolder xInbox = xApp.GetInbox();
            if (xInbox == null)
                return;
            OutlookMAPIFolder xTest = xInbox.FolderGet("Test");
            OutlookMAPIFolder xTest2 = xTest.FolderGet("SubTest");
            if (xTest == null)
                return;
            List<EmailMessage> l = xTest.GetEmailMessages();
            foreach (EmailMessage em in l)
            {
                MessageBox.Show(em.SUBJECT);
                em.MoveToFolder(xTest2);
            }
        }
    }
}
