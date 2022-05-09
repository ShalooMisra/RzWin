using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using NewMethod.CadmParsing;

namespace NewMethod
{
    public partial class frmNMI : NewMethod.frmMain
    {
        public frmNMI()
        {
            InitializeComponent();
        }

        public override void LoadToolBar()
        {
            base.LoadToolBar();

            ToolStripButton b = AddToolBarButton("ParseInspector", null);
            b.Click += new EventHandler(parseinspector_Click);
        }

        void parseinspector_Click(object sender, EventArgs e)
        {
            //ParseInspector p = new ParseInspector();
            //TabShow(p, "ParseInspector");
        }
    }
}

