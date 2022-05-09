using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Drawing;

namespace ToolsWin
{
    public partial class Win32API
    {
        //Public Static Functions


        public static int WM_SYSCOMMAND = 0x0112;
        public static int SC_CLOSE = 0xF060;
        public static int WM_SHOWWINDOW = 0x18;
        [DllImport("user32.dll")]
        public static extern int FindWindow(
            string lpClassName,     // class name
            string lpWindowName    // window name
        );

        [DllImport("User32")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        // Activates a window
        [DllImportAttribute("User32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        // Gets a window title text
        [DllImport("User32.Dll")]
        public static extern void GetWindowText(IntPtr h, StringBuilder s, int nMaxCount);
        public static int SW_SHOW = 5;
        public static int SW_RESTORE = 9;

        [DllImport("user32.dll", EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int abc);

        [DllImport("kernel32")]
        public extern static int LoadLibrary(string lpLibFileName);
        [DllImport("kernel32")]
        public extern static bool FreeLibrary(int hLibModule);

        public static bool IsDLLAvailabile(String strName)
        {
            try
            {
                int l = LoadLibrary(strName);
                if (l > 32)
                {
                    FreeLibrary(l);
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static Image GetScreenShot()
        {
            int xLoc;
            int yLoc;
            IntPtr dsk;
            IntPtr mem;

            int SCREEN_X = 0;
            int SCREEN_Y = 1;

            //get the handle of the desktop DC
            dsk = GetDC(GetDesktopWindow());

            //create memory DC
            mem = CreateCompatibleDC(dsk);

            //get the X coordinates of the screen
            xLoc = GetSystemMetrics(SCREEN_X);

            //get the Y coordinates of screen.
            yLoc = GetSystemMetrics(SCREEN_Y);

            return GetRectangleShot(new Point(0, 0), new Point(xLoc, yLoc));
        }



        public static Image GetControlShot(System.Windows.Forms.Control c)
        {
            int xLoc;
            int yLoc;
            IntPtr mem;

            //int SCREEN_X = 0;
            //int SCREEN_Y = 1;

            IntPtr dsk = c.Handle;

            //get the handle of the desktop DC
            dsk = GetDC(dsk);

            //create memory DC
            mem = CreateCompatibleDC(dsk);

            //get the X coordinates of the screen
            //xLoc = GetSystemMetrics(SCREEN_X);

            //get the Y coordinates of screen.
            //yLoc = GetSystemMetrics(SCREEN_Y);

            xLoc = c.Width;
            yLoc = c.Height;

            Point start = new Point(0, 0);
            Point end = new Point(xLoc, yLoc);

            //Bitmap _screenShot = null;
            IntPtr newBMP;

            int SRCCOPY = 13369376;

            Bitmap currentView;

            //create memory DC
            mem = CreateCompatibleDC(dsk);

            Rectangle r = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);

            //create a compatible image the size of the desktop
            newBMP = CreateCompatibleBitmap(dsk, r.Width, r.Height);

            //check against IntPtr (cant check IntPtr values against a null value)
            if (newBMP != IntPtr.Zero)
            {
                //select the image in memory
                IntPtr oldBmp = (IntPtr)SelectObject(mem, newBMP);
                //copy the new bitmap into memory
                BitBlt(mem, 0, 0, r.Width, r.Height, dsk, start.X, start.Y, SRCCOPY);
                //select the old bitmap into memory
                SelectObject(mem, oldBmp);
                //delete the memoryDC since we're through with it
                DeleteDC(mem);
                //release dskTopDC to free up the resources
                ReleaseDC(GetDesktopWindow(), dsk);
                //create out BitMap
                currentView = Image.FromHbitmap(newBMP);
                //return the image
                return currentView;
            }
            else  //null value returned
            {
                return null;
            }
        }

        private const int
           WM_PRINT = 0x317, PRF_CLIENT = 4,
           PRF_CHILDREN = 0x10, PRF_NON_CLIENT = 2,
           COMBINED_PRINTFLAGS = PRF_CLIENT | PRF_CHILDREN | PRF_NON_CLIENT;

        [DllImport("USER32.DLL")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam,
      int lParam);

        public static Image GetControlShotAlternate(System.Windows.Forms.Control control)
        {
            Bitmap b = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(b);

            IntPtr hWnd = control.Handle;
            IntPtr hDC = graphics.GetHdc();
            SendMessage(hWnd, WM_PRINT, hDC, COMBINED_PRINTFLAGS);
            graphics.ReleaseHdc(hDC);

            return b;
        }

        public static Image GetRectangleShot(Point start, Point end)
        {
            IntPtr dsk;
            IntPtr mem;
            //Bitmap _screenShot = null;
            IntPtr newBMP;

            int SRCCOPY = 13369376;

            Bitmap currentView;

            //get the handle of the desktop DC
            dsk = GetDC(GetDesktopWindow());

            //create memory DC
            mem = CreateCompatibleDC(dsk);

            Rectangle r = new Rectangle(start.X, start.Y, end.X - start.X, end.Y - start.Y);

            //create a compatible image the size of the desktop
            newBMP = CreateCompatibleBitmap(dsk, r.Width, r.Height);

            //check against IntPtr (cant check IntPtr values against a null value)
            if (newBMP != IntPtr.Zero)
            {
                //select the image in memory
                IntPtr oldBmp = (IntPtr)SelectObject(mem, newBMP);
                //copy the new bitmap into memory
                BitBlt(mem, 0, 0, r.Width, r.Height, dsk, start.X, start.Y, SRCCOPY);
                //select the old bitmap into memory
                SelectObject(mem, oldBmp);
                //delete the memoryDC since we're through with it
                DeleteDC(mem);
                //release dskTopDC to free up the resources
                ReleaseDC(GetDesktopWindow(), dsk);
                //create out BitMap
                currentView = Image.FromHbitmap(newBMP);
                //return the image
                return currentView;
            }
            else  //null value returned
            {
                return null;
            }

        }
        [DllImport("gdi32", EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32", EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        [DllImport("gdi32", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32", EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hDestDC, int X, int Y, int nWidth, int nHeight, IntPtr hSrcDC, int SrcX, int SrcY, int Rop);
        [DllImport("gdi32", EntryPoint = "DeleteDC")]
        public static extern IntPtr DeleteDC(IntPtr hDC);
    }
}
