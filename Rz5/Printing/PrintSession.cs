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
using System.Linq;

namespace Rz5
{
    public class PrintSession : IDisposable
    {
        public printheader PrintHeader;


        public nObject CurrentObject;
        public bool BlackAndWhite = false;
        public Boolean ConsolidateLines = false;
        public int PageNumber = 0;
        public bool HeaderOnEveryPage = false;
        protected bool selectLines = false;

        protected Tools.IGraphics CurrentGraphics;
        protected company CurrentCompany;
        protected NewMethod.n_user CurrentUser;

        protected int lngDWidth = 0;
        protected int heightAvailableForBand = 0;
        protected int lngOWidth = 0;
        protected int lngOHeight = 0;
        protected int lngBandY = 0;
        protected int lngFooterHeight = 0;
        protected int lngFooterTop = 0;
        protected bool boolPrintError = false;
        protected bool boolUseDescript = false;
        protected List<LineHandle> Lines = null;

        protected static int MarginBottom = 60;
        protected static int MarginTop = 30;

        //are these basically interchangable?
        protected const int lngBuffer = 6;    //switched from 20 2011_09_26
        protected int theta = 5;
        protected ContextRz TheContext;

        public PrintSession(ContextRz context, printheader printHeader, nObject xObject)
        {
            TheContext = context;
            PrintHeader = printHeader;
            CurrentObject = xObject;

            //added 2013_07_07 ; hopefully the performance hit won't be too large and this will auto-fill in the currency info and anything else
            if (CurrentObject is ordhed)
            {
                //ordhed xo = (ordhed)CurrentObject;
                //xo.Updating(context);
                //foreach (orddet d in xo.Details.RefsGetAsItems(context).AllGet(context))
                //{
                //    d.Updating(context);
                //}
            }
        }

        public virtual void Dispose()
        {

        }

        public virtual void Print()
        {
            PageNumber = 1;
        }


        public void PrintOnGraphics(ContextRz context, int w, int h)
        {
            int yOffset = 0;
            int BandOffset = 0;
            if (CurrentObject == null)
                return;
            lngDWidth = w;
            heightAvailableForBand = h;
            printdetail d = PrintHeader.GetDetailByName(context, "DETAILBAND");
            Font f = null;
            if (d != null)
                f = d.GetFont();
            else
                f = new Font("Times New Roman", 8);

            CurrentUser = null;
            if (CurrentObject is ordhed)
            {
                CurrentUser = ((ordhed)CurrentObject).UserObjectGet(context);
            }

            if (CurrentUser == null)
                CurrentUser = context.xUser;

            //get the template
            if (PrintHeader.CurrentTemplate == null)
                PrintHeader.CurrentTemplate = n_template.GetByName(context, PrintHeader.GetTemplateName());

            if (PrintHeader.CurrentTemplate == null)
            {
                if (Tools.Strings.StrExt(PrintHeader.ordertype))
                    context.TheLeader.Tell("The detail template for this layout could not be found.");
                PrintHeader.CurrentTemplate = n_template.New(context);
                PrintHeader.CurrentTemplate.template_name = PrintHeader.GetTemplateName();
                context.Insert(PrintHeader.CurrentTemplate);
            }

            CurrentCompany = null;
            if (CurrentObject is ordhed)
            {
                CurrentCompany = ((ordhed)CurrentObject).CompanyVar.RefGet(context);
            }

            if (CurrentCompany == null)
                CurrentCompany = company.New(context);

            //details
            Lines = new List<LineHandle>();

            if (CurrentObject is ordhed)
            {
                Lines = ((ordhed)CurrentObject).DetailsListForPrintLines(context, ConsolidateLines, PrintHeader.printname);
            }
            else if (CurrentObject is IPrintable)
            {
                String detail_name = "";
                try
                {
                    detail_name = Tools.Strings.SplitLines(d.textstring)[1];
                }
                catch { }
                IPrintable p = (IPrintable)CurrentObject;       

                foreach (Object x in p.PrintLines((ContextRz)context, detail_name))
                {
                    
                        Lines.Add(new LineHandleObject(context, (nObject)x));
                }
            }



            if (PrintHeader.width_index > 0 && PrintHeader.height_index > 0)
            {
                if (context.xUser.IsDeveloper())
                    context.TheLeader.Tell("Specific Setting");

                lngOWidth = Convert.ToInt32(PrintHeader.width_index);
                lngOHeight = Convert.ToInt32(PrintHeader.height_index);
            }
            else
            {
                lngOWidth = 7900;
                lngOHeight = 9015;
            }

            if (d == null)
            {
                lngBandY = 0;
            }
            else
            {
                lngBandY = ScaleFilter_Y(d.StartY);
            }

            lngFooterHeight = GetFooterHeight(context, lngBandY);

            if (d != null && Tools.Strings.StrCmp(d.alternate_file_name, "fixedheight"))
            {
                lngFooterTop = ScaleFilter_Y(d.StopY);
                lngFooterHeight = heightAvailableForBand - ScaleFilter_Y(d.StopY);
            }

            //Print the objects above the band
            PrintDesignObjects(context, "HEADER", true, 0, 0);

            Point bandStopped = new Point(0, 0);

            if (d != null)
            {
                if (!PrintABand(context, d, ref bandStopped, BandOffset))
                    return;
            }

            //see if we need a new page for the footer
            if (bandStopped.Y > lngFooterTop)
            {
                RollNewPage(f);

                //either way, all of the details are printed by now
                //so remove all but 10 pixels from the footer top
                yOffset = (lngFooterTop * -1) + 10;
            }
            else
            {
                //if any lines are on the page, print the footer in place
                if (Lines.Count > 0)
                    yOffset = 0;
                else
                {
                    if (HeaderOnEveryPage)
                        yOffset = 0;
                    else
                        yOffset = ((lngFooterTop - bandStopped.Y) * -1) + 10;
                }
            }

            //Print the rest, starting where PrintABand finished
            PrintDesignObjects(context, "FOOTER", true, 0, yOffset);

            if (PageNumber > 1)
                PrintPageNumber(f);

            PrintingComplete();
        }

        protected virtual void PrintingComplete()
        {

        }

        public int ScaleFilter_X(int lngx)
        {
            int l = 0;
            int k = lngx;
            ScaleFilter(ref k, ref l, false);
            return k;
        }
        public int ScaleFilter_Y(int lngy)
        {
            int l = 0;
            int k = lngy;
            ScaleFilter(ref l, ref k, false);
            return k;
        }
        public int ScaleFilter(ref int lngx, ref int lngy)
        {
            return ScaleFilter(ref lngx, ref lngy, false);
        }
        public int ScaleFilter(ref int lngx, ref int lngy, bool boolReverse)
        {
            int lngXPercent;
            int lngYPercent;
            bool TXFY;

            if (lngx > 0)
                TXFY = true;
            else
                TXFY = false;

            lngXPercent = Convert.ToInt32((Convert.ToDouble(lngx) / lngOWidth) * 100.0);
            lngYPercent = Convert.ToInt32((Convert.ToDouble(lngy) / lngOHeight) * 100.0);
            if (boolReverse)
            {
                if (lngXPercent > 0)
                    lngx = Convert.ToInt32(Math.Round(lngDWidth / (lngXPercent / 100.0), 0));

                if (lngYPercent > 0)
                    lngy = Convert.ToInt32(Math.Round(heightAvailableForBand / (lngYPercent / 100.0), 0));
            }
            else
            {
                Double i = (lngXPercent / 100.0);
                Double d = Math.Round(lngDWidth * Convert.ToDouble(i), 0);
                lngx = Convert.ToInt32(d);

                i = (lngYPercent / 100.0);
                d = Math.Round(heightAvailableForBand * Convert.ToDouble(i), 0);
                lngy = Convert.ToInt32(d);

                //lngx = Convert.ToInt32(lngx * 0.94);
                //lngy = Convert.ToInt32(lngy * 1.225);
            }

            if (TXFY)
                return lngx;
            else
                return lngy;

        }


        public void PrintDesignObjects(ContextRz context, String strType, bool boolBand, int sy, int yOffset)
        {
            try
            {
                PrintDesignObjectsByClass(context, strType, false, "LINE", sy, yOffset);
                if (boolPrintError)
                    return;

                PrintDesignObjectsByClass(context, strType, false, "BOX", sy, yOffset);
                if (boolPrintError)
                    return;

                PrintDesignObjectsByClass(context, strType, false, "HEADERBAND", sy, yOffset);
                if (boolPrintError)
                    return;

                PrintDesignObjectsByClass(context, strType, false, "GRAPHIC", sy, yOffset);
                PrintDesignObjectsByClass(context, strType, false, "TEXT", sy, yOffset);
            }
            catch (Exception ex)
            {
                context.TheLeader.Tell("Error in PrintDesignObjects: " + ex.Message);
            }
        }
        public void PrintDesignObjectsByClass(ContextRz context, String strType, bool boolBand, String strClassName, int lngStartLine, int yOffset)
        {
            int lngStarty;
            int lngOffset = 0;
            ArrayList colHold = new ArrayList();
            int lngHighest;

            lngHighest = 100000000;

            foreach (printdetail d in PrintHeader.AllDetails(context))
            {
                bool b = false;

                switch (strType.ToLower().Trim())
                {
                    case "":
                    case "all":
                        if (Tools.Strings.StrCmp(d.detailtype, strClassName))
                            b = true;
                        break;
                    case "header":
                        lngStarty = ScaleFilter_Y(d.StartY);
                        if (Tools.Strings.StrCmp(d.detailtype, strClassName) && lngStarty < lngBandY)
                            b = true;
                        break;
                    case "footer":
                        lngStarty = ScaleFilter_Y(d.StartY);
                        if (Tools.Strings.StrCmp(d.detailtype, strClassName) && lngStarty >= lngBandY)
                            b = true;
                        break;
                }

                if (b)
                {
                    colHold.Add(d);

                    if (d.starty < lngHighest)
                        lngHighest = d.StartY;
                }
            }

            foreach (printdetail d in colHold)
            {
                if (lngOffset > 0)
                {
                    d.starty = lngStartLine + (d.starty - lngOffset);
                    d.stopy = lngStartLine + (d.stopy - lngOffset);
                }

                PrintOneDesignObject(context, d, yOffset);
                if (boolPrintError)
                    return;
            }
        }
        public void PrintOneDesignObject(ContextRz context, printdetail d, int yOffset)
        {
            try
            {
                String strText;

                switch (d.detailtype.ToLower().Trim())
                {
                    case "line":
                        PrinterPrint(context, d, "", false, false, null, yOffset);
                        break;
                    case "box":
                        PrinterPrint(context, d, "", false, false, null, yOffset);
                        break;
                    case "headerband":
                        PrintHeaderBand(context, d);
                        break;
                    case "text":
                        if (d.textstring.ToLower().StartsWith("@@barcode@@"))
                        {
                            d.detailtype = "barcode";
                            strText = ParseOneTextLine(context, d.textstring, (d.centerx1 == -3)).Substring(11);
                            PrinterPrint(context, d, strText, false, false, null, yOffset);
                            d.detailtype = "text";
                            break;
                        }
                        Font xFont = d.GetFont();
                        strText = ParseOneTextLine(context, d.textstring, (d.centerx1 == -3));
                        if (d.max_width > 0)
                        {
                            float text_size = CurrentGraphics.MeasureString(strText, d.GetFont()).Width;
                            if (Convert.ToInt32(text_size) > d.max_width)
                                strText = GetWrappedText(d, strText);
                        }
                        PrinterPrint(context, d, strText, false, false, null, yOffset);
                        break;
                    case "graphic":
                        PrinterPrint(context, d, "", false, false, null, yOffset);
                        break;

                        //this is always handled manually, right?
                        //case "band":
                        //    int r = 0;
                        //    PrintABand(context, g, d, ref r, 0);
                        //    break;
                }
            }
            catch
            { }
        }

        int PrintBandHeader(ContextRz context, ArrayList colColumns, Point pLocation, int width, printdetail bandObject)
        {
            return PrintBandHeader(context, colColumns, pLocation, width, bandObject, Color.Black, Color.Black, Color.White);
        }

        int PrintBandHeader(ContextRz context, ArrayList colColumns, Point pLocation, int width, printdetail bandObject, Color line_color, Color header_font_color, Color header_fill_color)
        {
            Font xFont = null;
            if (bandObject.filename == "x")
            {
                xFont = new Font(bandObject.fontname, bandObject.fontsize);
            }
            else
                xFont = PrintHeader.GetHeaderFont();

            if (header_font_color != Color.Black)
                xFont = new Font(xFont, FontStyle.Bold);

            int headerHeight = Convert.ToInt32((CurrentGraphics.MeasureString("X", xFont).Height * 1.8));  //this was .Width for a *long* time

            if (colColumns != null)
            {
                Pen p = new Pen(line_color, 1);

                //Draw a line under the Headers
                if (header_fill_color != Color.White)
                    CurrentGraphics.FillRectangle(new SolidBrush(header_fill_color), pLocation.X, pLocation.Y, width, headerHeight);

                CurrentGraphics.DrawLine(p, pLocation.X, pLocation.Y + headerHeight, pLocation.X + width, pLocation.Y + headerHeight);

                //Print the header row
                String strTitleText;

                int headerCount = 1;
                int currentHeaderX = pLocation.X;

                foreach (DictionaryEntry d in PrintHeader.CurrentTemplate.AllColumns)
                {
                    n_column xColumn = (n_column)d.Value;
                    xColumn.ActualWidth = xColumn.GetActualWidth(width);
                    printdetail xTitle = printdetail.New(context);

                    strTitleText = xColumn.column_caption;

                    xTitle.textstring = strTitleText;
                    xTitle.centerx1 = currentHeaderX;
                    xTitle.centerx2 = currentHeaderX + xColumn.ActualWidth;
                    xTitle.detailtype = "text";
                    xTitle.starty = Convert.ToInt32(pLocation.Y + (CurrentGraphics.MeasureString("X", xFont).Height / 2));
                    xTitle.startx = pLocation.X;  //is this right?  or doesn't it matter because its centered?

                    xTitle.fontcolor = header_font_color.ToArgb();
                    PrinterPrint(context, xTitle, strTitleText, true, false, xFont, 0);

                    headerCount++;
                    currentHeaderX += xColumn.ActualWidth;
                }
            }

            return headerHeight + theta;
        }

        public bool PrinterPrint(ContextRz context, printdetail xObject)
        {
            return PrinterPrint(context, xObject, "", false, false, null, 0);
        }
        public bool PrinterPrint(ContextRz context, printdetail xObject, String strText)
        {
            return PrinterPrint(context, xObject, strText, false, false, null, 0);
        }
        public bool PrinterPrint(ContextRz context, printdetail xObject, String strText, bool boolSuppressScale, bool boolSuppressAdd, Font xFont, int yOffset)
        {
            int lngStartX;
            int lngStartY;
            int lngStopX;
            int lngStopY;
            String strType;
            int lngMark;
            int centerx1;
            int centerx2;
            String strFile;
            int rightspot = 0;

            strType = xObject.detailtype;
            lngStartX = xObject.StartX;
            lngStartY = xObject.StartY;
            lngStopX = xObject.StopX;
            lngStopY = xObject.StopY;
            centerx1 = xObject.CenterX1;
            centerx2 = xObject.CenterX2;
            bool boolSuppressScale2 = false;

            if (xObject.textstring == "Purchase Order")
            {
                ;
            }

            if (xObject.fontsize > 0 && xObject.fontsize < 8)
            {
                ;
            }

            if (xFont == null)
                xFont = xObject.GetFont();

            if (centerx1 == -1)    //centered on the page
            {
                centerx1 = 0;
                centerx2 = lngDWidth;
                boolSuppressScale2 = true;
            }
            else if (centerx1 == -2)  //right aligned
            {
                rightspot = GetRightMargin() - Convert.ToInt32(CurrentGraphics.MeasureString(strText, xFont).Width);
                boolSuppressScale2 = true;
            }
            else
            {
                boolSuppressScale2 = false;
            }

            if (!boolSuppressScale)
            {
                ScaleFilter(ref lngStartX, ref lngStartY);
                ScaleFilter(ref lngStopX, ref lngStopY);
                if (!boolSuppressScale2)
                {
                    centerx1 = ScaleFilter_X(centerx1);
                    centerx2 = ScaleFilter_X(centerx2);
                }
            }

            Point p = new Point(Convert.ToInt32(lngStartX), Convert.ToInt32(lngStartY) + yOffset);
            Point pStop = new Point(Convert.ToInt32(lngStopX), Convert.ToInt32(lngStopY) + yOffset);

            //lngStopX, lngStopY
            Color b = Color.Black;
            Pen pn = null;
            int lngBaseCenter = 0;

            switch (strType.Trim().ToLower())
            {
                case "text":
                    lngMark = strText.IndexOf("\n");
                    if (lngMark > -1)
                    {
                        p.X = Convert.ToInt32(lngStartX);
                        String[] ary = Tools.Strings.Split(strText.Replace("\r", ""), "\n");
                        b = xObject.GetColor();
                        foreach (String s in ary)
                        {
                            CurrentGraphics.DrawString(s, xFont, b, p);
                            p.Y += Convert.ToInt32(CurrentGraphics.MeasureString("X", xFont).Height);
                        }
                    }
                    else
                    {
                        if (xFont == null)
                            xFont = xObject.GetFont();

                        p.X = lngStartX;

                        if (rightspot > 0)
                        {
                            p.X = rightspot;
                        }
                        else
                        {
                            if (centerx1 > 0 || centerx2 > 0)
                            {
                                lngBaseCenter = centerx1 + Convert.ToInt32(Math.Round(Convert.ToDouble((centerx2 - centerx1) / 2), 0));
                                int hw2 = Convert.ToInt32(CurrentGraphics.MeasureString(strText, xFont).Width / 2);
                                p.X = lngBaseCenter - hw2;
                            }
                        }

                        b = xObject.GetColor();
                        CurrentGraphics.DrawString(strText, xFont, b, p);
                    }
                    break;
                case "line":
                    pn = xObject.GetPen();
                    CurrentGraphics.DrawLine(pn, p.X, p.Y, pStop.X, pStop.Y);
                    break;
                case "box":

                    if (xObject.FillIn)
                    {
                        CurrentGraphics.FillRectangle(new SolidBrush(xObject.FillColor), p.X, p.Y, pStop.X - p.X, pStop.Y - p.Y);
                    }

                    pn = xObject.GetPen();
                    CurrentGraphics.DrawRectangle(pn, new Rectangle(p.X, p.Y, pStop.X - p.X, pStop.Y - p.Y));

                    break;
                case "graphic":

                    if (xObject.filename.StartsWith("partpicture/"))
                    {
                        Image i = xObject.GetImage(context);
                        if (i == null)
                            return false;

                        if (CurrentGraphics.NeedsAlternateResolutionImages && Tools.Strings.StrExt(xObject.alternate_file_name))
                            CurrentGraphics.DrawImageAlternateResolution(i, p.X, p.Y);
                        else
                            CurrentGraphics.DrawImage(i, p.X, p.Y, i.Width, i.Height);
                    }
                    else
                    {
                        strFile = context.Logic.GetPictureFileName(xObject.filename, BlackAndWhite);
                        if (Tools.Strings.StrExt(strFile))
                        {
                            if (System.IO.File.Exists(strFile))
                            {
                                if (CurrentGraphics is Tools.PDFWrapper)
                                {
                                    ((Tools.PDFWrapper)CurrentGraphics).DrawImage(strFile, p.X, p.Y);
                                }
                                else
                                {
                                    Image i = Image.FromFile(strFile);
                                    CurrentGraphics.DrawImage(i, p.X, p.Y, i.Width, i.Height);
                                }

                                //g.DrawLine(Pens.Black, p.X, p.Y, p.X + 100, p.Y + 100);
                            }
                        }
                    }
                    break;
                case "barcode":
                    BarcodeLib.Barcode bc = new BarcodeLib.Barcode();
                    int W = 130;
                    int H = 30;
                    bc.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                    BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;
                    try
                    {
                        bc.IncludeLabel = false;
                        bc.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);
                        bc.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;
                        Image i = bc.Encode(type, strText, Color.Black, Color.White, W, H);
                        if (i == null)
                            return false;
                        if (CurrentGraphics.NeedsAlternateResolutionImages && Tools.Strings.StrExt(xObject.alternate_file_name))
                            CurrentGraphics.DrawImageAlternateResolution(i, p.X, p.Y);
                        else
                            CurrentGraphics.DrawImage(i, p.X, p.Y, i.Width, i.Height);
                    }
                    catch (Exception ex)
                    {
                        context.TheLeader.Error(ex.Message);
                    }
                    break;
            }

            boolPrintError = false;
            return true;
        }


        public bool SuppressDescriptions = false;
        public bool ShouldUseDescript(List<LineHandle> lines, ArrayList colColumns)
        {
            if (lines.Count == 0)
                return false;

            if (SuppressDescriptions)
                return false;

            bool boolHasDescriptions = false;
            bool boolIncludesDescription = false;
            foreach (LineHandle l in lines)
            {
                if (l.BelowLineInfoHas)
                {
                    boolHasDescriptions = true;
                    break;
                }
            }

            foreach (DictionaryEntry d in PrintHeader.CurrentTemplate.AllColumns)
            {
                n_column c = (n_column)d.Value;
                if (Tools.Strings.StrCmp(c.field_name, "DESCRIPTION"))
                {
                    boolIncludesDescription = true;
                    break;
                }
            }
            return (boolHasDescriptions && (!boolIncludesDescription));
        }
        public int GetRightMargin()
        {
            return Convert.ToInt32(Convert.ToDouble(lngDWidth) * 0.96);
        }

        private void PrintPageNumber(Font f)
        {
            String s = "Page " + Tools.Number.LongFormat(PageNumber);
            Point p = new Point();
            p.X = Convert.ToInt32(lngDWidth - CurrentGraphics.MeasureString(s, f).Width) - 10;
            p.Y = 10;
            CurrentGraphics.DrawString(s, f, Color.Black, p);


            p.Y = (heightAvailableForBand - MarginBottom) + 30;
            CurrentGraphics.DrawString(s, f, Color.Black, p);
        }
        private void PrintContinuedMessage(Font f)
        {
            String s = "Continued On Page " + Tools.Number.LongFormat(PageNumber + 1);
            Point p = new Point();
            p.X = Convert.ToInt32((lngDWidth / 2) - (CurrentGraphics.MeasureString(s, f).Width / 2));
            p.Y = heightAvailableForBand - 20;
            CurrentGraphics.DrawString(s, f, Color.Black, p);
        }
        private int GetFooterHeight(ContextRz context, int lngBandY)
        {
            return GetFooterHeight(context, lngBandY, false);
        }
        private int GetFooterHeight(ContextRz context, int lngBandY, bool boolHeader)
        {
            int lngHold = 0;
            int lngStart = 0;

            if (!boolHeader)
                lngHold = heightAvailableForBand;
            else
                lngHold = 0;

            foreach (printdetail d in PrintHeader.AllDetails(context))
            {
                lngStart = ScaleFilter_Y(d.StartY);

                if (!boolHeader)
                {
                    if (lngStart > lngBandY)
                    {
                        if (lngHold > lngStart)
                            lngHold = lngStart;
                    }
                    else
                    {
                        if (lngStart < lngBandY)
                        {
                            if (lngHold < lngStart)
                                lngHold = lngStart;
                        }
                    }
                }
            }

            if (!boolHeader)
            {
                lngFooterTop = lngHold;
                return heightAvailableForBand - lngHold;
            }
            else
            {
                return lngHold;
            }
        }

        private string GetWrappedText(printdetail d, string text)
        {
            if (d == null)
                return text;
            return GetWrappedText(d.max_width, d.GetFont(), text);
        }
        private string GetWrappedText(int max_width, Font f, string text)
        {
            try
            {
                if (f == null)
                    return text;

                if (text.Contains("\r") || text.Contains("\n")) //Already has line breaks
                {
                    StringBuilder ret = new StringBuilder();
                    List<String> lines = Tools.Strings.SplitLinesList(text);
                    foreach (String line in lines)
                    {
                        ret.AppendLine(GetWrappedText(max_width, f, line));
                    }

                    //return text;
                    return ret.ToString();
                }
                string[] all = Tools.Strings.Split(text, " ");
                if (all == null)
                    return text;

                if (all.Length == 1) //Must be one large word, not sure what to exactly do here, maybe split the word and hyphen it? //Currently just returning the word.                    
                    return text;

                string build = "";
                string hold = "";
                foreach (string s in all)
                {
                    if (Tools.Strings.StrExt(hold))
                    {
                        int text_size = Convert.ToInt32(CurrentGraphics.MeasureString(hold + " " + s, f).Width);
                        if (text_size > max_width)
                        {
                            build += hold + "\r\n";
                            hold = "";
                        }
                        else
                            hold += " ";
                    }
                    hold += s;
                }
                if (Tools.Strings.StrExt(hold))
                    build += hold;

                return build;
            }
            catch (Exception ee)
            {
                return text;
            }
        }
        private void PrintHeaderBand(ContextRz context, printdetail d)
        {
            ArrayList a = new ArrayList();

            printdetail thebox = d.CreateSimilar(context);
            thebox.detailtype = "BOX";
            thebox.startx = d.startx;
            thebox.starty = d.starty;
            thebox.stopx = d.stopx;
            thebox.stopy = d.stopy;

            switch (d.style_info)
            {
                case "GrayWhite":
                    thebox.FillIn = true;
                    thebox.FillColor = Tools.Colors.ColorFromHex("#808080");
                    thebox.fontcolor = Tools.Colors.ColorFromHex("#8080ff").ToArgb();
                    break;
            }

            a.Add(thebox);

            bool boxMode = (d.stopy - d.starty) > 600;

            int halfline = Convert.ToInt32(d.starty + ((d.stopy - d.starty) / 2));

            //if its larger than the standard height, make the "half" line stay at the top for the caption
            if (boxMode)
                halfline = Convert.ToInt32(d.starty + 260);

            printdetail theline = d.CreateSimilar(context);
            theline.detailtype = "LINE";
            theline.startx = d.startx;
            theline.starty = halfline;
            theline.stopx = d.stopx;
            theline.stopy = theline.starty;

            switch (d.style_info)
            {
                case "GrayWhite":
                    theline.fontcolor = Tools.Colors.ColorFromHex("#8080ff").ToArgb();
                    break;
            }

            a.Add(theline);

            int avail_width = Convert.ToInt32(d.stopx - d.startx);

            ArrayList members = new ArrayList();
            String[] ary = Tools.Strings.SplitLines(d.textstring);
            float total = 0;
            string hold = "";
            BandMember lastMember = null;
            foreach (String line in ary)
            {
                hold = line.Replace("||", "~**~").Trim(); //'Or' change since use the pipe for other parses

                if (!hold.Contains("|") && lastMember != null)
                {
                    if (lastMember.Value.Trim() != "")
                        lastMember.Value += "\r\n";
                    lastMember.Value += hold;
                    continue;
                }

                BandMember m = new BandMember();

                m.Caption = InsertVariables(context, Tools.Strings.ParseDelimit(hold, "|", 1), false);
                m.Value = InsertVariables(context, Tools.Strings.ParseDelimit(hold, "|", 2), false);

                float fc = CurrentGraphics.MeasureString(m.Caption, d.GetFont()).Width;
                float fv = CurrentGraphics.MeasureString(m.Value, d.GetFont()).Width;
                float fx = fc;
                if (fv > fx)
                    fx = fv;

                m.Width = fx;
                total += fx;
                members.Add(m);
                lastMember = m;
            }

            int so_far = 0;
            bool first = true;
            foreach (BandMember m in members)
            {
                if (!first)
                {
                    printdetail vline = d.CreateSimilar(context);
                    vline.detailtype = "LINE";
                    vline.startx = d.startx + so_far;
                    vline.stopx = vline.startx;
                    vline.starty = d.starty;
                    vline.stopy = d.stopy;

                    switch (d.style_info)
                    {
                        case "GrayWhite":
                            vline.fontcolor = Tools.Colors.ColorFromHex("#8080ff").ToArgb();
                            break;
                    }

                    a.Add(vline);
                }

                m.WidthPercent = nTools.CalcPercent(total, m.Width);  //this is in actual graphics units
                int x_width = Convert.ToInt32(avail_width * (m.WidthPercent / 100));

                printdetail tex = d.CreateSimilar(context);
                tex.detailtype = "TEXT";
                tex.startx = d.startx + so_far;
                tex.starty = d.starty + 20;
                tex.centerx1 = tex.startx;
                tex.centerx2 = tex.startx + x_width;
                tex.textstring = m.Caption;
                tex.fontbold = true;

                switch (d.style_info)
                {
                    case "GrayWhite":
                        tex.fontcolor = Color.White.ToArgb();
                        break;
                }

                a.Add(tex);

                tex = d.CreateSimilar(context);
                tex.detailtype = "TEXT";
                tex.startx = d.startx + so_far;

                if (boxMode)
                    tex.starty = halfline + 70;
                else
                    tex.starty = halfline + 40;

                if (m.Value.Contains("\n"))
                {
                    tex.startx += 60;
                }
                else
                {
                    tex.centerx1 = tex.startx;
                    tex.centerx2 = tex.startx + x_width;
                }

                tex.textstring = m.Value;

                switch (d.style_info)
                {
                    case "GrayWhite":
                        tex.fontcolor = Color.White.ToArgb();
                        break;
                }

                a.Add(tex);

                so_far += x_width;
                first = false;
            }

            foreach (printdetail x in a)
            {
                x.IsSelected = d.IsSelected;
                PrintOneDesignObject(context, x, 0);
            }
        }

        private bool PrintABand(ContextRz context, printdetail bandObject, ref Point bandStopped, int yOffset)
        {
            if (Lines == null)
                return true;

            Font xFont;
            Pen xPen;

            if (bandObject == null)
                return true;

            if (bandObject.fontsize < 8)
                xFont = new Font("Times New Roman", 10);
            else
                xFont = new Font(bandObject.fontname, bandObject.fontsize);

            if (bandObject.drawwidth > 0)
                xPen = new Pen(Color.Black, bandObject.drawwidth);
            else
                xPen = new Pen(Color.Black, 1);

            //Coordinates%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            int startX = bandObject.StartX;
            int startY = bandObject.StartY;
            ScaleFilter(ref startX, ref startY, false);
            Point bandLocation = new Point(startX, startY);
            int bandWidth = GetRightMargin() - bandLocation.X;

            //what is this for?
            if (yOffset > 0)
                bandLocation.Y = yOffset;

            if (PrintHeader.CurrentTemplate.AllColumns == null || PrintHeader.CurrentTemplate.AllColumns.Count == 0)
                PrintHeader.CurrentTemplate.GatherColumns(context);

            boolUseDescript = ShouldUseDescript(Lines, PrintHeader.CurrentTemplate.GetColumnArray());

            int right = ScaleFilter_X(Convert.ToInt32(bandObject.stopx));

            //Set the columns collection %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            String strReportName;
            String strBandName;

            strReportName = bandObject.base_printheader_uid;
            strBandName = bandObject.detailname;

            //Loop, printing as many as possible%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            int headerHeightUsed = PrintBandHeader(context, PrintHeader.CurrentTemplate.GetColumnArray(), bandLocation, bandWidth, bandObject);
            Point detailLocation = new Point(bandLocation.X, bandLocation.Y + headerHeightUsed);

            foreach (LineHandle l in Lines)
            {
                xFont = bandObject.GetFont();
                PrintOneDetail(context, l, PrintHeader.CurrentTemplate.GetColumnArray(), ref bandLocation, bandWidth, ref detailLocation, bandObject, xFont);

                //mark it as printed
                l.PrintedIs = true;

                if (detailLocation.Y > heightAvailableForBand - MarginBottom)  //this logic is also in printbelow, deciding whether to draw the last line
                {
                    RollNewPageBand(context, bandObject, xFont, ref bandLocation, bandWidth, ref detailLocation);
                }
            }

            //check for going past the page
            if ((detailLocation.Y + Convert.ToInt32(CurrentGraphics.MeasureString("X", xFont).Height * 4)) > heightAvailableForBand)  //needs to go as far down as possible
            {
                detailLocation.Y = heightAvailableForBand - MarginBottom;
                FinishBand(context, bandLocation, bandWidth, detailLocation);
                RollNewPageBand(context, bandObject, xFont, ref bandLocation, bandWidth, ref detailLocation);
            }
            else if ((detailLocation.Y + Convert.ToInt32(CurrentGraphics.MeasureString("X", xFont).Height * 4)) > lngFooterTop) //check for going past the bottom info's top
            {
                detailLocation.Y = heightAvailableForBand - MarginBottom;
                FinishBand(context, bandLocation, bandWidth, detailLocation);
                RollNewPageBand(context, bandObject, xFont, ref bandLocation, bandWidth, ref detailLocation);
                detailLocation.Y = lngFooterTop;
                FinishBand(context, bandLocation, bandWidth, detailLocation);
            }
            else
            {
                detailLocation.Y = lngFooterTop;
                FinishBand(context, bandLocation, bandWidth, detailLocation);
            }

            ////if there isn't enough room on the page for the footer, print the box and the columns all the way down the page
            //if (detailLocation.Y > lngFooterTop)
            //    BoxHeight = heightAvailableForBand - (BoxY + 50);

            //PrintDetailHeader(g, CurrentTemplate.GetColumnArray(), BoxX, BoxY, BoxHeight, lngWidth, LineColor);

            //BandEnded = BoxY + BoxHeight;
            return true;
        }

        void FinishBand(ContextRz context, Point bandLocation, int bandWidth, Point lastDetailLocation)
        {
            Pen p = new Pen(Color.Black, 1);
            Rectangle r = new Rectangle(bandLocation.X, bandLocation.Y, bandWidth, lastDetailLocation.Y - bandLocation.Y);
            CurrentGraphics.DrawRectangle(p, r);

            int i = 0;
            int x = bandLocation.X;
            foreach (n_column c in PrintHeader.CurrentTemplate.ColumnsList(context))
            {
                if (i > 0)
                {
                    CurrentGraphics.DrawLine(p, x, bandLocation.Y, x, lastDetailLocation.Y);
                }

                x += c.ActualWidth;
                i++;
            }
        }

        private void RollNewPageBand(ContextRz context, printdetail bandObject, Font xFont, ref Point bandLocation, int bandWidth, ref Point lastDetailLocation)
        {
            FinishBand(context, bandLocation, bandWidth, lastDetailLocation);
            RollNewPage(xFont);

            //print the header...
            bandLocation = new Point(bandLocation.X, MarginTop);
            int headerHeightUsed = PrintBandHeader(context, PrintHeader.CurrentTemplate.GetColumnArray(), bandLocation, bandWidth, bandObject);
            lastDetailLocation = new Point(bandLocation.X, bandLocation.Y + headerHeightUsed);

            Font f = bandObject.GetFont();
            if (f == null)
                f = new Font("Times New Roman", 10);
        }

        protected virtual void RollNewPage(Font f)
        {
            PrintPageNumber(f);
            if (HeaderOnEveryPage)
                PrintContinuedMessage(f);

            PageNumber++;
        }

        private int GetHeight(ref int lngy, int lngRowHeight, int lngDetailsLeft)
        {
            int lngLoad = 0;
            int lngHeight = 0;

            lngLoad = (lngRowHeight * lngDetailsLeft) + lngFooterHeight;

            lngHeight = Convert.ToInt32(Math.Round((heightAvailableForBand * 0.95) - lngy, 0));
            if (lngLoad < lngHeight)
            {
                //boolFooterFits = true;
                return lngFooterTop - lngy;
            }
            else
            {
                //boolFooterFits = false;
                return lngHeight;
            }
        }

        private void PrintOneDetail(ContextRz context, LineHandle xLine, ArrayList colColumns, ref Point bandLocation, int bandWidth, ref Point detailLocation, printdetail bandObject, Font xFont)
        {
            int partColumnStartX = 0;
            int partColumnWidth = 0;

            int x = bandLocation.X;
            foreach (DictionaryEntry d in PrintHeader.CurrentTemplate.AllColumns)
            {
                n_column xColumn = (n_column)d.Value;
                if (Tools.Strings.StrCmp(xColumn.field_name, "fullpartnumber") || Tools.Strings.StrCmp(xColumn.field_name, "pec_with_release") || Tools.Strings.StrCmp(xColumn.field_name, "pec") || Tools.Strings.StrCmp(xColumn.field_name, "purchased_as_number"))
                {
                    partColumnStartX = x;
                    partColumnWidth = xColumn.ActualWidth;
                    break;
                }
                x += xColumn.ActualWidth;
            }

            try
            {
                Point valueLocation = new Point(detailLocation.X, detailLocation.Y);
                foreach (DictionaryEntry d in PrintHeader.CurrentTemplate.AllColumns)
                {
                    Point valueLocationOffset = new Point(valueLocation.X, valueLocation.Y);
                    n_column xColumn = (n_column)d.Value;
                    xColumn.ActualWidth = xColumn.GetActualWidth(bandWidth);
                    String strValue = context.TheSysRz.ThePrintLogic.GetColumnValue(xColumn, xLine);

                    if (xColumn.field_name.Trim().ToLower() == "description")
                        strValue = xLine.Description;

                    if (xColumn.RightAlign)
                    {
                        valueLocationOffset.X = Convert.ToInt32((valueLocation.X + xColumn.ActualWidth) - (CurrentGraphics.MeasureString(strValue, xFont).Width + lngBuffer));
                    }
                    else
                    {
                        valueLocationOffset.X = Convert.ToInt32(valueLocation.X + lngBuffer);

                        if (CurrentGraphics.MeasureString(strValue, xFont).Width > (xColumn.ActualWidth - lngBuffer))
                        {
                            //if (xColumn.field_name.Trim().ToLower() == "description" || xColumn.field_name.Trim().ToLower() == "locations")
                            //{
                            String buf = "";
                            ArrayList words = nTools.SplitArray(strValue, " ");
                            ArrayList lines = new ArrayList();
                            for (int i = 0; i < words.Count; i++)
                            {
                                String tempbuf = (buf + " " + (String)words[i]);
                                if (CurrentGraphics.MeasureString(tempbuf, xFont).Width > (xColumn.ActualWidth - lngBuffer))
                                {
                                    lines.Add(buf.Trim());
                                    buf = "";
                                }

                                buf += ((String)words[i] + " ");
                            }

                            if (Tools.Strings.StrExt(buf))
                                lines.Add(buf.Trim());

                            strValue = "";
                            foreach (String l in lines)
                            {
                                if (Tools.Strings.StrExt(strValue))
                                {
                                    strValue += "\r\n";
                                    detailLocation.Y += (Convert.ToInt32(CurrentGraphics.MeasureString(l, xFont).Height));
                                }
                                strValue += l;
                            }
                            //}
                            //else
                            //{
                            //    while (strValue.Length > 0 && CurrentGraphics.MeasureString(strValue, xFont).Width > (xColumn.ActualWidth - lngBuffer))
                            //    {
                            //        strValue = Tools.Strings.Left(strValue, strValue.Length - 1);
                            //    }
                            //    strValue = strValue + "...";
                            //}
                        }
                    }

                    switch (xColumn.field_name.Trim().ToLower())
                    {
                        case "linecode":

                            try
                            {
                                strValue = Tools.Strings.Right("000000" + Tools.Data.NullFilterInt(xLine.Value("linecode")).ToString(), 4);
                            }
                            catch { }
                            valueLocationOffset.X = Convert.ToInt32(valueLocation.X + lngBuffer);
                            break;
                    }


                    Brush b = Brushes.Black;
                    CurrentGraphics.DrawString(strValue, xFont, Color.Black, valueLocationOffset);
                    valueLocation.X += xColumn.ActualWidth;
                }

                detailLocation.Y += Convert.ToInt32(CurrentGraphics.MeasureString("X", xFont).Height);

                PrintBelowLine(context, xLine, ref detailLocation, ref bandLocation, bandWidth, partColumnStartX, partColumnWidth, bandObject, xFont);
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
            }
        }

        void PrintBelowLine(ContextRz context, LineHandle xLine, ref Point detailLocation, ref Point bandLocation, int bandWidth, int partColumnStartX, int partColumnWidth, printdetail bandObject, Font xFont)
        {
            if (CurrentObject is ordhed_service)
                boolUseDescript = true;
            if (((SysRz5)context.xSys).ThePrintLogic.ShouldUseDescriptExtra(CurrentObject, PrintHeader.printname))
                boolUseDescript = true;
            if (boolUseDescript)
            {
                //detailLocation.Y += Convert.ToInt32(CurrentGraphics.MeasureString("X", xFont).Height);
                Point descriptionLocation = new Point(detailLocation.X, detailLocation.Y);

                if (xLine != null)
                {
                    if (partColumnStartX > 0)
                        descriptionLocation.X = partColumnStartX;

                    descriptionLocation.X += lngBuffer / 2;

                    if (xLine.BelowLineInfo.Count > 0)
                    {
                        foreach (String line in xLine.BelowLineInfo)
                        {
                            PrintBelowLine(context, line, partColumnWidth, bandObject, xFont, ref bandLocation, bandWidth, ref descriptionLocation);
                        }
                    }
                }

                detailLocation = new Point(detailLocation.X, descriptionLocation.Y);

                if (boolUseDescript)
                {
                    if (((String)xLine.Value("fullpartnumber")) == "P0884002")
                    {
                        ;
                    }

                    if (detailLocation.Y < heightAvailableForBand - (MarginBottom + theta + 1))
                    {
                        int yOffset = 3;
                        CurrentGraphics.DrawLine(new Pen(Brushes.Black, 1), detailLocation.X, detailLocation.Y + yOffset, bandLocation.X + bandWidth, detailLocation.Y + yOffset);
                    }
                }

                detailLocation.Y += theta;  //below
            }
        }

        void PrintBelowLine(ContextRz context, String belowLine, int part_column_width, printdetail bandObject, Font xFont, ref Point bandLocation, int bandWidth, ref Point pStart)
        {
            if (context.TheSysRz.ThePrintLogic.UseWrappedDescription())
                belowLine = GetWrappedText(part_column_width - (lngBuffer + 10), xFont, belowLine);

            String[] lines = Tools.Strings.SplitLines(belowLine);
            foreach (String line in lines)
            {
                if (!Tools.Strings.StrExt(line))
                    continue;

                if (pStart.Y > heightAvailableForBand - MarginBottom)
                {
                    Point pNewStart = new Point(pStart.X, pStart.Y);
                    RollNewPageBand(context, bandObject, xFont, ref bandLocation, bandWidth, ref pNewStart);
                    pStart.Y = pNewStart.Y;  //preserve the original X
                }

                string hold = line;

                PrintWhite(pStart.X, pStart.Y, Convert.ToInt32(pStart.X + CurrentGraphics.MeasureString(line, xFont).Width) - 3, Convert.ToInt32(pStart.Y + CurrentGraphics.MeasureString("X", xFont).Height) - 2);
                CurrentGraphics.DrawString(hold, xFont, Color.Black, pStart);
                pStart = new Point(pStart.X, pStart.Y + Convert.ToInt32(CurrentGraphics.MeasureString(line, xFont).Height));
            }
        }

        private void PrintWhite(int startx, int starty, int stopx, int stopy)
        {
            CurrentGraphics.FillRectangle(Brushes.White, startx, starty, stopx - startx, stopy - starty);
        }
        private String ParseOneTextLine(ContextRz context, String strLine, bool boolFullDate)
        {
            bool boolBold;
            bool boolItalic;
            bool boolRight;
            bool boolCenter;
            String strSize;
            int lngMark;
            String strFormat;
            String strText = "";

            if (Tools.Strings.HasString(strLine, "\r\n"))
            {
                int x = 0;
            }
            strLine = strLine.Replace("||", "~**~");
            lngMark = strLine.IndexOf("|");
            if (lngMark < 0)
                strFormat = "";
            else if (lngMark > -1)
                strFormat = Tools.Strings.Left(strLine, lngMark);
            else
                strFormat = "";

            if (lngMark > -1)
                strText = Tools.Strings.Right(strLine, strLine.Length - lngMark);
            else
                strText = strLine;

            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //Set the format
            boolBold = false;
            boolItalic = false;
            boolCenter = false;
            boolRight = false;
            strSize = "";
            lngMark = strFormat.IndexOf(",");
            if (lngMark > 0)
            {
                strSize = Tools.Strings.Left(strFormat, lngMark - 1);
            }

            boolBold = Tools.Strings.HasString(strFormat, "B");
            boolItalic = Tools.Strings.HasString(strFormat, "I");
            boolRight = Tools.Strings.HasString(strFormat, "R");
            boolCenter = Tools.Strings.HasString(strFormat, "C");

            //End Format
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            return InsertVariables(context, strText, boolFullDate);
        }
        private String InsertVariables(ContextRz context, String strHold, bool boolFullDate)
        {
            int lngMark;
            String strFirst;
            String strLast;
            String strText;
            String strVariable;
            int lngLength = 0;
            bool money_format = Tools.Strings.HasString(strHold, "@@[");
            strHold = strHold.Replace("@@[", "[");

            strText = strHold;
            while (Tools.Strings.HasString(strText, "["))
            {
                if (!Tools.Strings.HasString(strText, "]"))
                    return strText;

                lngMark = strText.IndexOf("[");
                if (lngMark == -1)
                    return strText;

                strFirst = Tools.Strings.Left(strText, lngMark);
                strText = Tools.Strings.Right(strText, strText.Length - (lngMark));
                lngMark = strText.IndexOf("]");
                if (strText.Length > (lngMark + 1))
                    strLast = Tools.Strings.Right(strText, strText.Length - (lngMark + 1));
                else
                    strLast = "";

                strVariable = Tools.Strings.Left(strText, lngMark + 1);
                strVariable = ResolveVariable(context, strVariable, ref lngLength, boolFullDate, money_format, !strHold.Contains(context.Sys.CurrencySymbol));
                if (!Tools.Strings.StrExt(strVariable))
                {
                    if (!Tools.Strings.HasString(strHold, "["))
                        return "";
                }

                if (lngLength > 0)
                    strVariable = Tools.Strings.Left(strVariable + nTools.Space(lngLength), lngLength);

                strVariable = strVariable.Replace("[", "(").Replace("]", ")");  //this was messing up multi-variable strings

                strText = strFirst + strVariable + strLast;
            }
            if (strText.Contains("<") && strText.Contains(">") && strText.Contains("."))
                strText = OwnerSettings.ParseDefaultCompanySettings(context, strText);

            return strText;
        }
        private String ResolveVariable(ContextRz context, String strVariable, ref int lngLength, bool boolFullDate, bool money_format, bool includeCurrencySymbol)
        {
            try
            {
                if (money_format)
                {
                    ;
                }
                long lngMark;
                String strVar;
                String strProp = "";
                String strLength;
                long lngMark1;
                String strResult = "";
                if (!Tools.Strings.StrExt(strVariable))
                    return "";
                strVar = Tools.Strings.Mid(strVariable, 2, strVariable.Length - 2);
                String strFormat = Tools.Strings.ParseDelimit(strVar, "-format-", 2);
                strVar = Tools.Strings.ParseDelimit(strVar, "-format-", 1);
                lngMark = strVar.IndexOf(".");
                if (lngMark == -1)
                {
                    switch (strVar.Trim().ToLower())
                    {
                        case "now":
                            if (Tools.Strings.StrExt(strFormat))
                                return String.Format(strFormat, DateTime.Now);
                            else
                                return nTools.DateFormat(DateTime.Now);
                        case "year":
                            return System.DateTime.Now.Year.ToString();
                        case "month":
                            return System.DateTime.Now.Month.ToString();
                        case "day":
                            return System.DateTime.Now.Day.ToString();
                        case "orderdate-year4":
                            return ((ordhed)CurrentObject).orderdate.Year.ToString();
                        case "orderdate-year2":
                            return Tools.Strings.Right(((ordhed)CurrentObject).orderdate.Year.ToString(), 2);
                        case "machine":
                            return Environment.MachineName;
                    }
                }
                else
                {
                    strProp = Tools.Strings.ParseDelimit(strVar, ".", 2);
                    lngMark1 = strProp.IndexOf(",");
                    if (lngMark1 > -1)
                    {
                        strLength = Tools.Strings.Right(strProp, Convert.ToInt32(strProp.Length - lngMark1));
                        strProp = Tools.Strings.Left(strProp, Convert.ToInt32(lngMark1 - 1));
                        lngLength = Int32.Parse(strLength);
                    }
                    else
                        strLength = "0";
                    strVar = Tools.Strings.ParseDelimit(strVar, ".", 1);
                    if (Tools.Strings.StrCmp(strVar, "ordhed"))
                        strVar = "order";
                    if (Tools.Strings.StrCmp(strVar, "order") && Tools.Strings.StrCmp(strProp, "filledamount"))
                        strProp = "subtotal";
                    string[] alts = new string[0];
                    switch (strVar.ToLower().Trim())
                    {
                        case "order":
                            if (Tools.Strings.Left(strProp, 1) == "~")
                            {
                                strProp = Tools.Strings.Mid(strProp, 2).ToLower().Trim();
                                if (includeCurrencySymbol)
                                    strResult = context.Sys.CurrencySymbol + nTools.MoneyFormat((Double)CurrentObject.IGet(strProp));
                                else
                                    strResult = nTools.MoneyFormat((Double)CurrentObject.IGet(strProp));
                            }
                            else
                            {
                                if (Tools.Strings.StrExt(strFormat))
                                {
                                    if (strProp.Contains("~**~"))
                                    {
                                        alts = Tools.Strings.Split(strProp, "~**~");
                                        foreach (string s in alts)
                                        {
                                            strResult = String.Format(strFormat, CurrentObject.IGet(strProp.ToLower().Trim()));
                                            if (Tools.Strings.StrExt(strResult))
                                                break;
                                        }
                                    }
                                    else
                                        strResult = String.Format(strFormat, CurrentObject.IGet(strProp.ToLower().Trim()));
                                }
                                else
                                {
                                    if ((!boolFullDate) && (Tools.Strings.HasString(strProp.ToLower().Trim(), "DATE") || Tools.Strings.StrCmp(strProp, "LASTFILLED")))
                                        strResult = nTools.DateFormat((DateTime)CurrentObject.IGet(strProp.ToLower().Trim()));
                                    else if (Tools.Strings.HasString(strProp.ToLower().Trim(), "TIME"))
                                        strResult = ((DateTime)CurrentObject.IGet(strProp.ToLower().Replace("time", "date").Trim())).ToShortTimeString();
                                    else
                                    {
                                        if (Tools.Strings.StrCmp(strProp, "subtotal"))
                                        {
                                            Double d = 0;
                                            if (CurrentObject is ordhed_new)
                                                d = ((ordhed_new)CurrentObject).sub_total;
                                            else
                                                d = ((ordhed)CurrentObject).SubTotal(context);

                                            if (includeCurrencySymbol)
                                                strResult = context.Sys.CurrencySymbol + nTools.MoneyFormat(d);
                                            else
                                                strResult = nTools.MoneyFormat(d);
                                        }
                                        else if (Tools.Strings.StrCmp(strProp, "ordertotal"))
                                        {
                                            if (includeCurrencySymbol)
                                                strResult = context.Sys.CurrencySymbol + nTools.MoneyFormat(((ordhed)CurrentObject).ordertotal);
                                            else
                                                strResult = nTools.MoneyFormat(((ordhed)CurrentObject).ordertotal);
                                        }
                                        else
                                        {
                                            if (strProp.Contains("~**~"))
                                            {
                                                alts = Tools.Strings.Split(strProp, "~**~");
                                                foreach (string s in alts)
                                                {
                                                    Object rr = CurrentObject.IGet(s.ToLower().Trim());
                                                    if (rr == null)
                                                        strResult = "";
                                                    else
                                                    {
                                                        strResult = rr.ToString();
                                                        if (money_format && Tools.Number.IsNumeric(strResult))
                                                        {
                                                            try
                                                            {
                                                                if (includeCurrencySymbol)
                                                                    strResult = context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(Double.Parse(strResult));
                                                                else
                                                                    strResult = Tools.Number.MoneyFormat(Double.Parse(strResult));
                                                            }
                                                            catch { }
                                                        }
                                                    }
                                                    if (Tools.Strings.StrExt(strResult))
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Object r = CurrentObject.IGet(strProp.ToLower().Trim());
                                                if (r == null)
                                                    strResult = "";
                                                else
                                                {
                                                    strResult = r.ToString();
                                                    if (money_format && Tools.Number.IsNumeric(strResult))
                                                    {
                                                        try
                                                        {
                                                            if (includeCurrencySymbol)
                                                                strResult = context.Sys.CurrencySymbol + Tools.Number.MoneyFormat(Double.Parse(strResult));
                                                            else
                                                                strResult = Tools.Number.MoneyFormat(Double.Parse(strResult));
                                                        }
                                                        catch { }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case "company":
                            strResult = (String)CurrentCompany.IGet(strProp.ToLower().Trim());
                            break;
                        case "agent":
                            strResult = (String)CurrentUser.IGet(strProp.ToLower().Trim());
                            break;
                        case "user":
                            strResult = (String)CurrentUser.IGet(strProp.ToLower().Trim());
                            break;
                        default:
                            if (Tools.Strings.StrCmp(CurrentObject.ClassId, strVar))
                            {
                                if ((!boolFullDate) && (Tools.Strings.HasString(strProp.ToLower().Trim(), "DATE") || Tools.Strings.StrCmp(strProp, "LASTFILLED") || Tools.Strings.StrCmp(strProp, "path_deadline")))
                                    strResult = nTools.DateFormat(nData.NullFilter_Date(CurrentObject.IGet(strProp.ToLower().Trim())));
                                else
                                    strResult = nData.NullFilter_String(CurrentObject.IGet(strProp.ToLower().Trim()));
                            }
                            else
                                strResult = "";
                            break;
                    }
                }
                strResult = strResult.Trim();
                if (Tools.Strings.StrCmp(strProp, "companyname"))
                    return Tools.Strings.ParseDelimit(strResult, "[", 1).Trim();
                else
                    return strResult;
            }
            catch (Exception)
            {
                if (context.xUser.IsDeveloper())
                    return "!";
                else
                    return "";
            }
        }



    }
}
