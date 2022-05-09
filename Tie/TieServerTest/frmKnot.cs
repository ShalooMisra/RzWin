using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tie;

namespace TieServerTest
{
    public partial class frmKnot : Form
    {
        public frmKnot()
        {
            InitializeComponent();
        }

        public void SetKnot(TieKnot t)
        {
            vk.SetKnot(t);
        }
    }
}