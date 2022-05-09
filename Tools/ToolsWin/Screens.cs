using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class Screens
    {
        //Public Static Functions
        public static void SetOnMouse(System.Windows.Forms.Form xForm)
        {
            ToolsWin.ScreenQuadrant x = GetMouseQuadrant();
            System.Drawing.Point p = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            switch (x)
            {
                case ToolsWin.ScreenQuadrant.TopLeft:
                    xForm.Left = p.X;
                    xForm.Top = p.Y;
                    break;
                case ToolsWin.ScreenQuadrant.TopCenter:
                    xForm.Left = p.X - (xForm.Width / 2);
                    xForm.Top = p.Y;
                    break;
                case ToolsWin.ScreenQuadrant.TopRight:
                    xForm.Left = p.X - xForm.Width;
                    xForm.Top = p.Y;
                    break;
                case ToolsWin.ScreenQuadrant.MidLeft:
                    xForm.Left = p.X;
                    xForm.Top = p.Y - (xForm.Height / 2);
                    break;
                case ToolsWin.ScreenQuadrant.MidCenter:
                    xForm.Top = p.Y - (xForm.Height / 2);
                    xForm.Left = p.X - (xForm.Width / 2);
                    break;
                case ToolsWin.ScreenQuadrant.MidRight:
                    xForm.Top = p.Y - (xForm.Height / 2);
                    xForm.Left = p.X - xForm.Width;
                    break;
                case ToolsWin.ScreenQuadrant.BottomLeft:
                    xForm.Left = p.X;
                    xForm.Top = p.Y - xForm.Height;
                    break;
                case ToolsWin.ScreenQuadrant.BottomCenter:
                    xForm.Left = p.X - (xForm.Width / 2);
                    xForm.Top = p.Y - xForm.Height;
                    break;
                case ToolsWin.ScreenQuadrant.BottomRight:
                    xForm.Left = p.X - xForm.Width;
                    xForm.Top = p.Y - xForm.Height;
                    break;
            }
        }
        public static ToolsWin.ScreenQuadrant GetMouseQuadrant()
        {
            int w = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            w = w / 3;
            int x = System.Windows.Forms.Cursor.Position.X;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            y = y / 3;
            int z = System.Windows.Forms.Cursor.Position.Y;
            if (x <= w)    //left
            {
                if (z <= y)    //top
                {
                    return ToolsWin.ScreenQuadrant.TopLeft;
                }
                else if (z < (y * 2))    //middle
                {
                    return ToolsWin.ScreenQuadrant.MidLeft;
                }
                else    //bottom
                {
                    return ToolsWin.ScreenQuadrant.BottomLeft;
                }
            }
            else if (x < (w * 2))    //center
            {
                if (z <= y)    //top
                {
                    return ToolsWin.ScreenQuadrant.TopCenter;
                }
                else if (z < (y * 2))    //middle
                {
                    return ToolsWin.ScreenQuadrant.MidCenter;
                }
                else    //bottom
                {
                    return ToolsWin.ScreenQuadrant.BottomCenter;
                }
            }
            else    //right
            {
                if (z <= y)    //top
                {
                    return ToolsWin.ScreenQuadrant.TopRight;
                }
                else if (z < (y * 2))    //middle
                {
                    return ToolsWin.ScreenQuadrant.MidRight;
                }
                else    //bottom
                {
                    return ToolsWin.ScreenQuadrant.BottomRight;
                }
            }
        }

        public static void ShowDownTo(Control f, Control c)
        {
            try
            {
                f.Height = (f.Height - f.ClientRectangle.Height) + c.Bottom + 5;
            }
            catch { }
        }

        public static void ShowOverTo(Control f, Control c)
        {
            try
            {
                f.Width = (f.Width - f.ClientRectangle.Width) + c.Right + 5;
            }
            catch { }
        }

        public static int ChooseColor(IWin32Window owner)
        {
            ColorDialog f = new ColorDialog();
            f.ShowDialog(owner);
            return f.Color.ToArgb();
        }
    }

    public enum ScreenQuadrant
    {
        TopLeft = 1,
        TopCenter = 2,
        TopRight = 3,
        MidLeft = 4,
        MidCenter = 5,
        MidRight = 6,
        BottomLeft = 7,
        BottomCenter = 8,
        BottomRight = 9,
    }
}