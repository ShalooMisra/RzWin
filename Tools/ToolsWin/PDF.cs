using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ToolsWin
{
    public partial class PDF
    {
        //Public Static Functions
        public static ArrayList ExtractImagesFromPDF(string sourcePdf)
        {
            ArrayList a = new ArrayList();
            iTextSharp.text.pdf.RandomAccessFileOrArray raf;
            iTextSharp.text.pdf.PdfReader reader;
            iTextSharp.text.pdf.PdfObject pdfObj;
            iTextSharp.text.pdf.PdfStream pdfStrem; 
            try
            {
                raf = new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf);
                reader = new iTextSharp.text.pdf.PdfReader(raf, null);
                for (int i = 0; i < reader.XrefSize; i++)
                {
                    pdfObj = reader.GetPdfObject(i);
                    if (pdfObj != null && pdfObj.IsStream())
                    {
                        pdfStrem = (iTextSharp.text.pdf.PdfStream)pdfObj;
                        iTextSharp.text.pdf.PdfObject subtype = pdfStrem.Get(iTextSharp.text.pdf.PdfName.SUBTYPE);
                        if (subtype != null && Tools.Strings.StrCmp(subtype.ToString(), iTextSharp.text.pdf.PdfName.IMAGE.ToString()))
                        {
                            byte[] bytes = iTextSharp.text.pdf.PdfReader.GetStreamBytesRaw((iTextSharp.text.pdf.PRStream)pdfStrem);
                            if (bytes != null)
                            {
                                try
                                {
                                    System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes);
                                    memStream.Position = 0;
                                    Image img = Image.FromStream(memStream);
                                    a.Add(img);
                                }
                                catch { /*Most likely the image is in an unsupported format, Doing nothing*/ }
                            }
                        }
                    }
                }
                reader.Close();
            }
            catch { }
            return a;
        }
    }
}
