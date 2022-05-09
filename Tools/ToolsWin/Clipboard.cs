using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class Clipboard
    {
        public static String GetClipText()
        {
            try
            {
                return System.Windows.Forms.Clipboard.GetText();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static bool SetClip(String s)
        {
            try
            {
                //System.Windows.Forms.Clipboard.Clear();
                System.Windows.Forms.Clipboard.SetText(s);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}