using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoreDevelopWin
{
    public partial class PropChooser : Form
    {
        //Public Variables
        public Type TheType;
        public bool OneToMany = false;
        public bool OneToOne = false;

        //Constructors
        public PropChooser()
        {
            InitializeComponent();
        }
        //Buttons
        private void cmdMemberAddString_Click(object sender, EventArgs e)
        {
            TheType = typeof(String);
            Close();
        }
        private void cmdNewBool_Click(object sender, EventArgs e)
        {
            TheType = typeof(Boolean);
            Close();
        }
        private void cmdNewInt32_Click(object sender, EventArgs e)
        {
            TheType = typeof(Int32);
            Close();
        }
        private void cmdNewInt64_Click(object sender, EventArgs e)
        {
            TheType = typeof(Int64);
            Close();
        }
        private void cmdMemberAddDouble_Click(object sender, EventArgs e)
        {
            TheType = typeof(Double);
            Close();
        }
        private void cmdNewDateTime_Click(object sender, EventArgs e)
        {
            TheType = typeof(DateTime);
            Close();
        }
        private void cmdNewOneToMany_Click(object sender, EventArgs e)
        {
            OneToMany = true;
            Close();
        }
        private void cmdNewSingleRef_Click(object sender, EventArgs e)
        {
            OneToOne = true;
            Close();
        }
    }
}
