using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public class CloseArgs
    {
        public String Reason;
        public Boolean Handled;
        public CloseArgs()
        {
            Handled = false;
        }
    }

    public delegate void CloseHandler(Object sender, CloseArgs args);
    public delegate void ShowExternalHandler(Object sender);
}