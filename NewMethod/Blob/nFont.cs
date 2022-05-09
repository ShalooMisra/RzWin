using System;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace NewMethod
{
    public partial class nFont
    {
        //Public Static Functions
        public static Font GetFont()
        {
            return GetFont(null);
        }
        public static Font GetFont(Form owner)
        {
            FontConverter fc = new FontConverter();
            try
            {
                FontDialog fd = new FontDialog();
                fd.Font = GetDefaultFont();
                fd.ShowDialog(owner);
                return fd.Font;
            }
            catch
            { return GetDefaultFont(); }
        }
        public static Font GetFontFromString(String font)
        {
            FontConverter fc = new FontConverter();
            try
            { return (Font)fc.ConvertFromString(font); }
            catch
            { return GetDefaultFont(); }
        }
        public static String GetStringFromFont(Font font)
        {
            FontConverter fc = new FontConverter();
            try
            { return fc.ConvertToString(font); }
            catch
            { return GetDefaultFontString(); }
        }
        public static String GetDefaultFontString()
        {
            return "Times New Roman, 9.75pt";
        }
        public static Font GetDefaultFont()
        {
            return GetFontFromString(GetDefaultFontString());
        }
    }
}
