using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using NewMethod;

namespace Rz5
{
    public partial class PrintPreviewPage : UserControl
    {
        private Boolean bAlternateResize = false;

        public Boolean AlternateResize
        {
            get
            {
                return bAlternateResize;
            }
            set
            {
                bAlternateResize = value;
            }
        }

        public PrintPreviewPage()
        {
            InitializeComponent();
        }

        private void PrintPreviewPage_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void Init(String PrinterName, bool landscape)
        {
            try
            {
                //PrintDocument printDoc = new PrintDocument();
                //printDoc.PrinterSettings.PrinterName = PrinterName;
                //int x = printDoc.DefaultPageSettings.PaperSize.Width;

                int x = 850;
                int y = 1100;

                if (x > 10)
                {
                    if (landscape)
                    {
                        //pg.Width = printDoc.DefaultPageSettings.PaperSize.Height;
                        pg.Width = y;
                        pg.Height = x;
                    }
                    else
                    {
                        pg.Width = x;
                        //pg.Height = printDoc.DefaultPageSettings.PaperSize.Height;
                        pg.Height = y;
                    }
                }
            }
            catch { }
            CenterForm();
        }

        public void DoResize()
        {
            if (bAlternateResize)
            {
                DoAltResize();
                return;
            }
            try
            {
                panel.Left = 0;
                panel.Height = 0;
                panel.Height = this.ClientRectangle.Height - hs.Height;
                panel.Width = this.ClientRectangle.Width - vs.Width;

                vs.Left = panel.Right;
                hs.Top = panel.Bottom;
                hs.Width = panel.Width;
                vs.Height = panel.Height;
            }
            catch (Exception)
            { }
        }

        public void DoAltResize()
        {
            try
            {
                panel.BackColor = Color.DarkGray;
                panel.Top = 5;
                panel.Left = 5;
                panel.Height = this.ClientRectangle.Height - (panel.Top * 2);
                panel.Width = this.ClientRectangle.Width - (panel.Left * 2);
                if (pg.Height > (panel.Height + (pg.Top * 2)))
                {
                    vs.Visible = true;
                    vs.Left = this.ClientRectangle.Width - vs.Width;
                    panel.Width = vs.Left;
                }
                else
                    vs.Visible = false;
                if (pg.Width > (panel.Width + (pg.Left * 2)))
                {
                    hs.Visible = true;
                    hs.Top = this.ClientRectangle.Height - hs.Height;
                    panel.Height = hs.Top;
                }
                else
                    hs.Visible = false;
                if (vs.Visible)
                    panel.Width = this.ClientRectangle.Width - ((panel.Left * 2) + vs.Width);
                if (hs.Visible)
                    panel.Height = this.ClientRectangle.Height - ((panel.Top * 2) + hs.Height);
                hs.Width = panel.Width;
                vs.Height = panel.Height;
                vs.Top = panel.Top;
                hs.Left = panel.Left;
                CenterForm();
            }
            catch (Exception)
            { }
        }

        private void CenterForm()
        {
            try
            {
                Int32 i = (panel.Width - pg.Width) / 2;
                if (i > 0)
                    pg.Left = i;
            }
            catch { }
        }

        private void Do_Scroll(object sender, ScrollEventArgs e)
        {
            if (hs.Value == 0)
            {
                if (bAlternateResize)
                    CenterForm();
                else
                    pg.Left = 5;
            }
            else
            {
                //at zero, the pic is at zero.  at 100, the pic is left by the amount that it hangs off of the edge
                long lngHangX = pg.Width - panel.Width;
                if (lngHangX <= 0)
                    if (bAlternateResize)
                        CenterForm();
                    else
                        pg.Left = 5;
                else
                    pg.Left = (Convert.ToInt32(lngHangX * Convert.ToDouble((hs.Value / 100.0))) * -1) - 25;
            }

            if (vs.Value == 0)
            {
                pg.Top = 5;
            }
            else
            {
                long lngHangY = pg.Height - panel.Height;
                if (lngHangY <= 0)
                    pg.Top = 5;
                else
                    pg.Top = (Convert.ToInt32(lngHangY * Convert.ToDouble((vs.Value / 100.0))) * -1) - 50;
            }
        }

        public PictureBox GetPG()
        {
            return pg;
        }

        public void SetBitmap(Image i)
        {
            try
            {
                pg.Image = i;
                pg.Refresh();
            }
            catch { }
        }

        private void pg_Click(object sender, EventArgs e)
        {
            
        }

        private void pg_MouseClick(object sender, MouseEventArgs e)
        {
            int w = nTools.CalcPercent(pg.ClientRectangle.Width, e.X);
            int h = nTools.CalcPercent(pg.ClientRectangle.Height, e.Y);

            if (PreviewClick != null)
                PreviewClick(w, h);
        }

        public event PreviewClickHandler PreviewClick;
        public event PreviewBoxHandler PreviewBox;

        Point ClickDown = new Point();
        private void pg_MouseDown(object sender, MouseEventArgs e)
        {
            ClickDown = new Point(e.X, e.Y);
        }

        private void pg_MouseUp(object sender, MouseEventArgs e)
        {
            if (ClickDown.X != e.X || ClickDown.Y != e.Y)
            {
                if (ToolsWin.Keyboard.GetShiftKey())
                {
                    if (PreviewBox != null)
                    {
                        int w = nTools.CalcPercent(pg.ClientRectangle.Width, ClickDown.X);
                        int h = nTools.CalcPercent(pg.ClientRectangle.Height, ClickDown.Y);
                        int w2 = nTools.CalcPercent(pg.ClientRectangle.Width, e.X);
                        int h2 = nTools.CalcPercent(pg.ClientRectangle.Height, e.Y);
                        PreviewBox(w, h, w2, h2);
                    }
                }
            }
        }
    }

    
    public delegate void PreviewBoxHandler(int x_pct, int y_pct, int x2_pct, int y2_pct);

}
