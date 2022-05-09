using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Globalization;
using System.IO;

using Core;
using NewMethod;

namespace Rz5
{
    public class PrintSessionPrinter : PrintSession
    {
        public PrintSessionPrinter(ContextRz context, printheader printHeader, nObject xObject)
            : base(context, printHeader, xObject)
        {
        }

        OrderPrintArgs TheOrderPrintArgs = null;
        public PrintSessionPrinter(printheader printHeader, OrderPrintArgs args)
            : base((ContextRz)args.TheContext, printHeader, args.xObject)
        {
            TheOrderPrintArgs = args;
        }

        public PrintDocument printDoc;
        public PageSettings pgSettings;
        public bool HasMorePages = false;

        public override void Print()
        {
            base.Print();

            if (TheOrderPrintArgs == null)
                PrintAfterInit("", 1, false, true);
            else
                PrintAfterInit(TheOrderPrintArgs.strPrinter, TheOrderPrintArgs.intCopies, TheOrderPrintArgs.BlackAndWhite, TheOrderPrintArgs.ConsolidateLines);
        }

        public void Print(String PrinterName, int copies, bool black_and_white, bool consolidate_lines)
        {
            base.Print();
            PrintAfterInit(PrinterName, copies, black_and_white, consolidate_lines);
        }

        String RequestedPrinterName;
        protected void PrintAfterInit(String requestedPrinterName, int copies, bool black_and_white, bool consolidate_lines)
        {
            BlackAndWhite = black_and_white;
            ConsolidateLines = consolidate_lines;
            RequestedPrinterName = requestedPrinterName;

            TheContext.TheLeader.CommentEllipse("Printing " + CurrentObject.ToString());

            try
            {
                if (copies != -1)
                {
                    InitPrintObjects();

                    printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);

                    if (!Tools.Strings.HasString(printDoc.PrinterSettings.PrinterName, "pdf"))
                        printDoc.PrinterSettings.Copies = (short)copies;
                    this.printDoc.Print();

                    //shouldn't this be here?
                    printDoc.PrintPage -= new PrintPageEventHandler(printDoc_PrintPage);
                    printDoc.Dispose();
                    printDoc = null;

                    pgSettings = null;
                }
            }
            catch (Exception ex)
            {
                TheContext.TheLeader.Error("Print Error: " + ex.Message);
            }
        }

        void InitPrintObjects()
        {
            printDoc = new PrintDocument();
            pgSettings = new PageSettings();

            if (Tools.Strings.StrExt(RequestedPrinterName))
            {
                RequestedPrinterName = FilterPrinterName(RequestedPrinterName);
                if (!Tools.Strings.StrCmp(RequestedPrinterName, printDoc.PrinterSettings.PrinterName))
                {
                    if (!PrinterExists(RequestedPrinterName))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (String s in PrinterSettings.InstalledPrinters)
                        {
                            sb.AppendLine(s);
                        }

                        TheContext.TheLeader.Tell("The printer '" + RequestedPrinterName + "' could not be found.  Below is the list of installed printer names:\r\n\r\n" + sb.ToString());
                        return;
                    }

                    String strOriginal = printDoc.PrinterSettings.PrinterName;
                    printDoc.PrinterSettings.PrinterName = RequestedPrinterName;
                }
            }

            printDoc.DefaultPageSettings.Landscape = PrintHeader.is_landscape;
        }

        GraphicsCache cache = null;
        public void printDoc_PrintPage(Object sender, PrintPageEventArgs e)
        {
            if (cache == null)  //write the whole thing out the first time
            {
                cache = new GraphicsCache(e.Graphics);
                Double mul = 0.95;
                CurrentGraphics = cache;
                PrintOnGraphics(TheContext, Convert.ToInt32(e.PageBounds.Width * mul), Convert.ToInt32(e.PageBounds.Height * mul));
            }

            CurrentGraphics = new Tools.GraphicsWrapper(e.Graphics);
            List<Tools.DrawItem> items = new List<Tools.DrawItem>(cache.PrintingPageItems);
            foreach (Tools.DrawItem i in items)
            {
                ((Tools.GraphicsWrapper)CurrentGraphics).Draw(i);
            }

            cache.PrintingPage++;
            e.HasMorePages = cache.PrintingPageItems.Count > 0;
        }

        protected override void RollNewPage(Font f)
        {
            base.RollNewPage(f);
            cache.PageAdd();
        }

        public static bool Print(ContextRz q, nObject x, String printHeaderName, int copies)
        {
            printheader tx = (printheader)q.QtO("printheader", "select * from printheader where printname = '" + q.Filter(printHeaderName) + "'");
            if (tx == null)
            {
                q.TheLeader.Error(printHeaderName + " can't be found in the printed forms");
                return false;
            }

            TransmitParameters p2 = new TransmitParameters(Enums.TransmitType.Print);
            p2.CopyCount = copies;
            p2.PrintTemplate = tx;
            p2.Print(q, x);
            return true;
        }

        public static bool PrinterExists(String sp)
        {
            String x = "";
            return PrinterExists(sp, ref x);
        }
        public static bool PrinterExists(String sp, ref String actual_name)
        {
            foreach (String s in PrinterSettings.InstalledPrinters)
            {
                if (sp == "pdf" && nTools.StartsWith(s, "Quickbooks"))
                    continue;

                if (Tools.Strings.StrCmp(sp, s))
                {
                    actual_name = s;
                    return true;
                }

                if (Tools.Strings.HasString(s, sp))
                {
                    actual_name = s;
                    return true;
                }

                if (Tools.Strings.StrCmp(sp.Replace(" ", ""), s.Replace(" ", "")))
                {
                    actual_name = s;
                    return true;
                }
            }
            return false;
        }
        public static String GetCurrentPrinter()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                return printDoc.PrinterSettings.PrinterName;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static String FilterPrinterName(String sp)
        {
            if (Tools.Strings.HasString(sp, "pdf"))
            {
                String ret = "";

                if (PrinterExists("Adobe PDF", ref ret))
                    return ret;

                if (PrinterExists("PDFCreator", ref ret))
                    return ret;

                if (PrinterExists(sp, ref ret))
                    return ret;

                return sp;
            }
            else
            {
                String ret = "";
                if (PrinterExists(sp, ref ret))
                    return ret;
                else
                    return "";
            }
        }
        public static String ChoosePrinter(System.Windows.Forms.IWin32Window owner)
        {
            System.Windows.Forms.PrintDialog p = new System.Windows.Forms.PrintDialog();
            p.ShowDialog(owner);
            return p.PrinterSettings.PrinterName;
        }
    }

    public class PrintHeaderDocument : PrintDocument
    {
        //Private Variables
        private PrintSessionPrinter MyHeader;
        private nObject MyObject;

        //Constructors
        public PrintHeaderDocument(ContextRz context, PrintSessionPrinter h, nObject o)
        {
            MyHeader = h;
            MyObject = o;
            //sets up the printheader but doesn't actually print anything
            MyHeader.printDoc = this;
            h.Print();
        }
        //Protected Override Functions
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);
        }
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            //base.OnPrintPage(e);
            MyHeader.printDoc_PrintPage(this, e);
        }
    }
}
