using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace RzSensible
{
    public partial class frmChooseIndustry : Form
    {
        //Public Variables
        public string TheChoice;
        //Private Variables
        private ContextNM TheContext;

        //Constructors
        public frmChooseIndustry()
        {
            InitializeComponent();
        }
        //Public Functions
        public static string ChooseIndustrySection(ContextNM x)
        {
            frmChooseIndustry f = new frmChooseIndustry();
            if (!f.CompleteLoad(x))
                return "";
            f.ShowDialog();
            return f.TheChoice;
        }
        //Public Functions
        public bool CompleteLoad(ContextNM x)
        {
            if (x == null)
                return false;
            TheContext = x;
            ctl_industry_segment.LoadList(true);
            return true;
        }
        //Private Functions
        private void SetSelected()
        {
            TheChoice = ctl_industry_segment.GetValue_String();
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheChoice = "";
            Close();
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            SetSelected();
            Close();
        }
    }
}
