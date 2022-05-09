using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace ToolsWin.Dialogs
{
    public partial class DialogBase : Form
    {
        public DialogBase()
        {
            InitializeComponent();
        }

        public virtual void Init()
        {
            this.Icon = Style.StyleCurrent.IconFormDefault;
        }

        public virtual void InitUn()
        {

        }
    }
}
