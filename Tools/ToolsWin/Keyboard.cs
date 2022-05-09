using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class Keyboard
    {
        public static bool GetControlKey()
        {
            return ((Control.ModifierKeys & Keys.Control) == Keys.Control);
        }
        public static bool GetShiftKey()
        {
            return ((Control.ModifierKeys & Keys.Shift) == Keys.Shift);
        }
        public static bool GetControlAndShiftKeys()
        {
            return (GetControlKey() && GetShiftKey());
        }
    }
}