using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Tools
{
    public static class Printing
    {
    }

    // PrintDirect.cs
    [StructLayout(LayoutKind.Sequential)]
    public struct DOCINFO
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string pDataType;
    }
    public class PrintDirect
    {
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern long ClosePrinter(IntPtr hPrinter);

        public static void PrintString(String s)
        {
            PrintString(s, "Zebra");
        }

        public static void PrintString(String s, String printer_name)
        {
            System.IntPtr lhPrinter = new System.IntPtr();
            DOCINFO di = new DOCINFO();
            int pcWritten = 0;
            di.pDocName = "Rz Print";
            di.pDataType = "RAW";
            //lhPrinter contains the handle for the printer opened
            //If lhPrinter is 0 then an error has occured
            PrintDirect.OpenPrinter(printer_name, ref lhPrinter, 0);
            PrintDirect.StartDocPrinter(lhPrinter, 1, ref di);
            PrintDirect.StartPagePrinter(lhPrinter);
            try
            {
                PrintDirect.WritePrinter(lhPrinter, s, s.Length, ref pcWritten);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                PrintDirect.EndPagePrinter(lhPrinter);
                PrintDirect.EndDocPrinter(lhPrinter);
                PrintDirect.ClosePrinter(lhPrinter);
            }
        }
    }

}
