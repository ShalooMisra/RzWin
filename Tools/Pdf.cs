using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Tools
{
    public class PDFWrapper : IGraphics
    {
        public float ScalePercent = 0;
        public iTextSharp.text.Document doc1;
        public iTextSharp.text.pdf.PdfWriter writer;
        public iTextSharp.text.pdf.PdfContentByte cb;

        //Constructors
        public PDFWrapper(string file_name, bool landscape)
        {
            iTextSharp.text.FontFactory.RegisterDirectories();
            if (landscape)
                doc1 = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate());
            else
                doc1 = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
            writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc1, new System.IO.FileStream(file_name, System.IO.FileMode.Create));
            doc1.Open();
            cb = writer.DirectContent;
        }
        //Public Functions
        public void CloseDoc()
        {
            doc1.Close();
        }
        public void DrawImage(String file, int x, int y)
        {
            int widthUsed = 0;
            int heightUsed = 0;
            DrawImage(file, x, y, ref widthUsed, ref heightUsed);
        }       

        public void DrawImage(String file, int x, int y, ref int widthUsed, ref int heightUsed)
        {
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(file);

            gif.SetDpi(300, 300);
            gif.ScalePercent(72);  //65f
            gif.SetAbsolutePosition(Convert.ToInt32(x * 0.72F), ChangeY(y) - gif.ScaledHeight);  //x
            cb.AddImage(gif);
            widthUsed = Convert.ToInt32(gif.ScaledWidth * 1.385F);
            heightUsed = Convert.ToInt32(gif.ScaledHeight * 1.385F);

            //DrawLine(Pens.Black, x, y, x + widthUsed, y + heightUsed);
        }

        public void DrawImageWithCaption(Font font, String file, String caption, Point p)
        {
            int widthUsed = 0;
            int heightUsed = 0;
            DrawImage(file, p.X, p.Y, ref widthUsed, ref heightUsed);   //Convert.ToInt32(p.X * 0.75F)
            DrawString(caption, font, Color.Black, new Point(p.X, p.Y + heightUsed + 30)); 
        }

        public void DrawImageWithCaptionTop(Font font, String file, String caption, Point p)
        {
            int widthUsed = 0;
            int heightUsed = 0;
            DrawImage(file, p.X, p.Y, ref widthUsed, ref heightUsed);  //Convert.ToInt32(p.X * 0.75F)
            DrawString(caption, font, Color.Black, new Point(p.X, p.Y - 30));
        }

        //removed 2011_11_27 to try the actual blowup/scale to get true 300 dpi
        //public void DrawImage(Image i, int x, int y, int width, int height)
        //{
        //    Image j = Tools.Picture.GetThumbnailScale(i, Convert.ToInt32(i.Width * 0.72F), Convert.ToInt32(i.Height * 0.72F));

        //    iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(j, iTextSharp.text.BaseColor.WHITE);
            
        //    //int dx = gif.DpiX;
        //    //int dy = gif.DpiY;

        //    //gif.SetDpi(300, 300);
        //    //gif.ScalePercent(72.0f);
        //    gif.SetAbsolutePosition(Convert.ToInt32(x * 0.72F), ChangeY(y) - gif.ScaledHeight);  //x   Convert.ToInt32(x * 0.72F)
        //    cb.AddImage(gif);
        //}

        public void DrawImage(Image i, int x, int y, int width, int height)
        {
            //blow up the original so that bringing it back down to 24% will be the original size
            Double blowFactor = 0.33;
            Image j = Tools.Picture.GetThumbnailScale(i, Convert.ToInt32(Convert.ToDouble(i.Width) / blowFactor), Convert.ToInt32(Convert.ToDouble(i.Height) / blowFactor));

            DrawImageScaledTo300Dpi(j, x, y);
        }
        public void DrawImageScaledTo300Dpi(String file, int x, int y)
        {
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(file);
            gif.ScalePercent(24f);
            gif.SetAbsolutePosition(x, ChangeY(y));  //x
            cb.AddImage(gif);
        }

        public void DrawImageScaledTo300Dpi(Image image, int x, int y)
        {
            iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(image, iTextSharp.text.BaseColor.WHITE);
            gif.ScalePercent(24f);
            gif.SetAbsolutePosition(Convert.ToInt32(x * 0.72F), ChangeY(y) - gif.ScaledHeight);  //x   Convert.ToInt32(x * 0.72F)
            cb.AddImage(gif);
        }

        public void DrawLine(Pen pn, int x, int y, int stop_x, int stop_y)
        {
            x = ScaleX(x);
            y = ChangeY(y);
            stop_x = ScaleX(stop_x);
            stop_y = ChangeY(stop_y);

            cb.SetColorStroke(new iTextSharp.text.BaseColor(pn.Color));
            cb.MoveTo(x, y);
            cb.LineTo(stop_x, stop_y);
            cb.Stroke();
        }

        public void DrawLineHoriz(Pen pn, ref Point pt)
        {
            DrawLine(pn, pt.X, pt.Y, 800, pt.Y);
            pt.Y += 5;
        }

        public void FillRectangle(Brush b, int x, int y, int width, int height)
        {
            //2011_05_12 took this out for pdf
            //Color c = Color.White;
            //if (b is SolidBrush)
            //{
            //    try
            //    {
            //        c = ((SolidBrush)b).Color;
            //    }
            //    catch { }
            //}

            //cb.SetColorStroke(new iTextSharp.text.BaseColor(c));
            //cb.SetColorFill(new iTextSharp.text.BaseColor(c));

            //x = ScaleX(x);
            //y = ChangeY(y);
            //width = ScaleX(width);
            //height = ScaleY(height * -1);

            //cb.Rectangle(x, y, width, height);
            //cb.ClosePathFillStroke();
        }
        public void DrawStringReturn(ref Point p, String text, Font font)
        {
            int x = p.X;
            int y = p.Y;
            DrawStringHorizVert(text, font, Color.Black, ref p);
            p.Y += 2;
            DrawLine(Pens.Black, x, p.Y, p.X, p.Y);
            p.X = x;
            p.Y += 2;

            ////////////////////////////////////////

            //int style = 0;
            //if (font.Bold && font.Underline)
            //    style = iTextSharp.text.Font.UNDERLINE | iTextSharp.text.Font.BOLD;
            //else if (font.Bold)
            //    style = iTextSharp.text.Font.BOLD;
            //else if (font.Underline)
            //    style = iTextSharp.text.Font.UNDERLINE;

            //iTextSharp.text.Font pfont = iTextSharp.text.FontFactory.GetFont(font.Name, font.Size, style, iTextSharp.text.BaseColor.BLACK);

            //iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Hello", pfont));
            ////cell.BackgroundColor = Color.YELLOW;
            ////cell.BorderColor = Color.BLACK;
            //cell.BorderWidth = 2;
            ////cell.Rotation = 90;
            //cell.Left = p.X;
            //cell.Bottom = ChangeY(p.Y) + cell.Height;   // 200; //it should be the cell's position 
            //doc1.Add(cell); 

            //////////////////////////////////////////


            //iTextSharp.text.Paragraph par = new iTextSharp.text.Paragraph("underlined and strike-through paragraph");
            //par.Font.SetStyle(iTextSharp.text.Font.UNDERLINE | iTextSharp.text.Font.STRIKETHRU);
            
            //doc1.Add(par);
        }

        public void DrawCaptionValueReturn(ref Point p, String caption, String value, Font font)
        {
            int x = p.X;
            DrawStringHoriz(caption, font, Color.Black, ref p);
            p.X += 5;
            Font fontb = new Font(font, FontStyle.Bold);
            DrawStringVert(value, fontb, Color.Black, ref p);
            p.X = x;
        }

        public void DrawRectangle(Pen p, Rectangle r, bool filled)
        {
            int fx = ScaleX(Convert.ToInt32(doc1.PageSize.GetLeft(r.Left)));
            int fy = ChangeY(r.Top);
            int fw = ScaleX(r.Width);
            int fh = ScaleY(r.Height * -1);

            cb.Rectangle(fx, fy, fw, fh);

            if (filled)
            {
                cb.SetColorFill(new iTextSharp.text.BaseColor(p.Color));
                cb.FillStroke();
            }
            else
            {
                cb.SetColorStroke(new iTextSharp.text.BaseColor(p.Color));
                cb.Stroke();
            }
        }

        public void DrawRectangle(Pen p, Rectangle r)
        {
            DrawRectangle(p, r, false);
        }

        public void DrawString(String strText, Font xFont, Color c, Point p)
        {

            int w = 0;
            int h = 0;
            DrawString(strText, xFont, c, p, ref w, ref h);
        }

        public void DrawStringHoriz(String strText, Font xFont, Color c, ref Point p)
        {
            int w = 0;
            int h = 0;
            DrawString(strText, xFont, c, p, ref w, ref h);
            p.X += w;
        }

        public void DrawStringVert(String strText, Font xFont, Color c, ref Point p)
        {
            int w = 0;
            int h = 0;
            DrawString(strText, xFont, c, p, ref w, ref h);
            p.Y += h;
        }

        public void DrawStringHorizVert(String strText, Font xFont, Color c, ref Point p)
        {
            int w = 0;
            int h = 0;
            DrawString(strText, xFont, c, p, ref w, ref h);
            p.X += w;
            p.Y += h;
        }

        public void DrawString(String strText, Font xFont, Color c, Point p, ref int widthUsed, ref int heightUsed)
        {
            //if (strText.Contains("\r"))
            //{
            //    ;
            //}

            //if (strText.Contains("All equip"))
            //{
            //    ;
            //}

            widthUsed = 0;
            heightUsed = 0;

            int style = 0;
            if (xFont.Bold && xFont.Underline)
                style = iTextSharp.text.Font.UNDERLINE | iTextSharp.text.Font.BOLD;
            else if (xFont.Bold)
                style = iTextSharp.text.Font.BOLD;
            else if (xFont.Underline)
                style = iTextSharp.text.Font.UNDERLINE;

            iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(xFont.Name, xFont.Size, style);
            iTextSharp.text.pdf.BaseFont bf = font.GetCalculatedBaseFont(false);
            
            cb.SetFontAndSize(bf, font.Size);
            
            Point pActual = new Point(p.X, p.Y);

            List<String> lines = Tools.Strings.SplitLinesList(strText);
            foreach (String line in lines)
            {
                float fx = pActual.X;
                float fy = pActual.Y;

                fx = ScaleX(pActual.X);
                fy = ChangeY(pActual.Y);

                int height = Convert.ToInt32(GetTextHeight(bf, font.Size, strText));
                fy -= height;

                cb.BeginText();
                cb.SetColorFill(new iTextSharp.text.BaseColor(c));
                cb.SetTextMatrix(fx, fy);
                cb.ShowText(line);
                cb.EndText();

                SizeF sf = MeasureString(strText, xFont, bf);

                if( sf.Width > widthUsed )
                    widthUsed = Convert.ToInt32(sf.Width);
    
                heightUsed += Convert.ToInt32(sf.Height);

                pActual = new Point(pActual.X, pActual.Y + Convert.ToInt32(sf.Height));
            }
        }

        public float GetTextHeight(iTextSharp.text.pdf.BaseFont baseFont, float fontSize, String text)
        {
            float ascend = baseFont.GetAscentPoint("Xp", fontSize);
            float descend = baseFont.GetDescentPoint("Xp", fontSize);
            return (ascend - descend) * 1.2f;
        }

        public SizeF MeasureString(String strText, Font xFont)
        {
            iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(xFont.Name, xFont.Size, Convert.ToInt32(xFont.Style), iTextSharp.text.BaseColor.BLACK);
            iTextSharp.text.pdf.BaseFont bf = font.GetCalculatedBaseFont(false);
            return MeasureString(strText, xFont, bf);
        }

        public SizeF MeasureString(String strText, Font xFont, iTextSharp.text.pdf.BaseFont bf)
        {
            return new SizeF(bf.GetWidthPoint(strText, xFont.Size) * 1.4f, GetTextHeight(bf, xFont.Size, strText) * 1.5f);
        }

        public int ScaleX(int x)
        {
            return Convert.ToInt32(x * 0.72f);
        }

        public int ScaleY(int y)
        {
            return Convert.ToInt32(y * 0.72f);
        }

        public int ChangeY(int y)
        {
            return Convert.ToInt32(doc1.PageSize.Height) - ScaleY(y);
        }

        public void NewPage()
        {
            doc1.NewPage();
        }

        public bool NeedsAlternateResolutionImages { get { return true; } }

        public void DrawImageAlternateResolution(Image i, int x, int y)
        { 
            DrawImageScaledTo300Dpi(i, x, y);
        }
    }
}
