using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tie
{
    public class TransparentSplitContainer : SplitContainer
    {
        public TransparentSplitContainer() : base()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel2.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
