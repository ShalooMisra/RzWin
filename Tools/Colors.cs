using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml;

namespace Tools
{
    public partial class Colors
    {
        //Public Static Functions
        public static System.Drawing.Color GetColorFromInt(int c)
        {
            switch (c)
            {
                case 0:
                    return System.Drawing.Color.Black;
                case 1:
                    return System.Drawing.Color.Blue;
                case 2:
                    return System.Drawing.Color.Red;
                case 3:
                    return System.Drawing.Color.Green;
                case 4:
                    return System.Drawing.Color.Yellow;
                case 5:
                    return System.Drawing.Color.Orange;
                case 6:
                    return System.Drawing.Color.Purple;
                default:
                    return System.Drawing.Color.FromArgb(c);
            }
        }
        public static int GetIntFromColor(System.Drawing.Color c)
        {
            if (c == System.Drawing.Color.Blue)
                return 1;
            if (c == System.Drawing.Color.Red)
                return 2;
            if (c == System.Drawing.Color.Green)
                return 3;
            if (c == System.Drawing.Color.Yellow)
                return 4;
            if (c == System.Drawing.Color.Orange)
                return 5;
            if (c == System.Drawing.Color.Purple)
                return 6;
            return 0;
        }

        public static string RGBtoHEX(int Value)
        {
            int Result = (Value / 16);
            int Remain = (Value % 16);
            string Resultant = null;
            if (Result >= 10)
            {
                if (Result == 10)
                    Resultant = "A";
                if (Result == 11)
                    Resultant = "B";
                if (Result == 12)
                    Resultant = "C";
                if (Result == 13)
                    Resultant = "D";
                if (Result == 14)
                    Resultant = "E";
                if (Result == 15)
                    Resultant = "F";
            }
            else
                Resultant = Result.ToString();
            if (Remain >= 10)
            {
                if (Remain == 10)
                    Resultant += "A";
                if (Remain == 11)
                    Resultant += "B";
                if (Remain == 12)
                    Resultant += "C";
                if (Remain == 13)
                    Resultant += "D";
                if (Remain == 14)
                    Resultant += "E";
                if (Remain == 15)
                    Resultant += "F";
            }
            else
                Resultant += Remain.ToString();
            return Resultant;
        }
        public static Color ColorFromHex(String strHex)
        {
            System.Web.UI.WebControls.WebColorConverter c = new System.Web.UI.WebControls.WebColorConverter();
            return (Color)c.ConvertFromString("#" + strHex.Replace("#", ""));
        }
        public static Bitmap EnsureGraphicsCompatibleBitmap(Bitmap b)
        {
            if (b == null)
                return null;
            try
            {
                Graphics g = Graphics.FromImage(b);
                g.Dispose();
                g = null;
                return b;
            }
            catch (Exception ex)
            {
                Bitmap bn = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics gn = Graphics.FromImage(bn);
                gn.DrawImage(b, new Point(0, 0));
                gn.Dispose();
                gn = null;
                return bn;
            }

        }
    }
}
