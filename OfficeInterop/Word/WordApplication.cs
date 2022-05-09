using System;
using System.Collections.Generic;
using System.Text;
//using Word = Microsoft.Office.Interop.Word;

namespace OfficeInterop
{
    public class WordApplication
    {
        //Public Static Variables
        public static String ErrorMsg;
        //Private Variables
        private Word.Application xApp;

        //Public Static Functions
        public static WordDocument OpenWordDocument(ref WordApplication xAppWrapper, String wordfile, Boolean bShow, Boolean bNewWordVersion)
        {
            ErrorMsg = "";
            try
            {
                Object missing = System.Reflection.Missing.Value;
                Object filename = (Object)wordfile;
                Object boolShow = (Object)bShow;
                if (xAppWrapper == null)
                    xAppWrapper = new WordApplication();
                WordDocument xDoc;
                if (bShow)
                    xAppWrapper.Visible = true;

                xDoc = xAppWrapper.DocumentOpen(wordfile, bNewWordVersion);

                xDoc.Activate();
                return xDoc;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return new WordDocument(null);
            }
        }
        public static Boolean CloseApplication(Word.Application app)
        {
            ErrorMsg = "";
            try
            {
                Object t = true;
                Object f = false;
                Object wrap = Word.WdFindWrap.wdFindContinue;
                Object missing = System.Reflection.Missing.Value;
                app.Documents.Close(ref f, ref missing, ref missing);
                app.Quit(ref missing, ref missing, ref missing);
                app = null;
                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }
        //Public Functions
        public bool Visible
        {
            get
            {
                GetNewApplication();
                return xApp.Visible;
            }
            set
            {
                GetNewApplication();
                xApp.Visible = value;
            }
        }
        public WordDocument DocumentOpen(String filename)
        {
            GetNewApplication();
            Object missing = System.Reflection.Missing.Value;
            Object fn = (Object)filename;
            return new WordDocument(xApp.Documents.Open(ref fn, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing));
        }
        public WordDocument DocumentOpen(String filename, bool bNewWordVersion)
        {
            GetNewApplication();
            Object missing = System.Reflection.Missing.Value;
            Object fn = (Object)filename;
            if (bNewWordVersion)
                return new WordDocument(xApp.Documents.Open(ref fn, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing));
            else
                return new WordDocument(xApp.Documents.OpenOld(ref fn, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing));
        }
        public String ActivePrinter
        {
            set
            {
                GetNewApplication();
                xApp.ActivePrinter = value;
            }
        }
        public Boolean PrintWordDocument(String printername, Boolean bShow, Boolean bNewWordVersion)
        {
            GetNewApplication();
            ErrorMsg = "";
            try
            {
                if (xApp == null)
                    return false;
                xApp.ActivePrinter = printername;
                ActiveDocumentPrintOut(bNewWordVersion);
                if (bShow)
                    xApp.Visible = true;
                return true;
            }
            catch (Exception e)
            {
                ErrorMsg = e.Message;
                return false;
            }
        }
        public bool ActiveDocumentPrintOut(bool bNewWordVersion)
        {
            GetNewApplication();
            Object t = true;
            Object f = false;
            Object missing = System.Reflection.Missing.Value;
            try
            {
                if (bNewWordVersion)
                    xApp.ActiveDocument.PrintOut(ref t, ref f, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref f, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                else
                    xApp.ActiveDocument.PrintOutOld(ref t, ref f, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref f, ref missing, ref missing, ref missing);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Close()
        {
            try
            {
                if (xApp == null)
                    return true;
                Object t = true;
                Object f = false;
                Object wrap = Word.WdFindWrap.wdFindContinue;
                Object missing = System.Reflection.Missing.Value;
                xApp.Documents.Close(ref f, ref missing, ref missing);
                xApp.Quit(ref missing, ref missing, ref missing);
                xApp = null;
                GC.GetTotalMemory(false);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.GetTotalMemory(true);
                return true;
            }
            catch { }
            return false;
        }
        //Private Functions
        private void GetNewApplication()
        {
            if (xApp == null)
                xApp = new Word.Application();
        }
    }
}
