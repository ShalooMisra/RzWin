using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmAskForStringFromArray : Form
    {
        //Public Variables
        public bool Canceled = false;
        public String SelectedValue = "";

        //Constructors
        public frmAskForStringFromArray()
        {
            InitializeComponent();
        }
        //Public Functions
        public static string AskForStringFromArray(String prompt, String default_value, List<String> a, ref bool canceled)
        {
            frmAskForStringFromArray frm = new frmAskForStringFromArray();
            frm.Init(prompt, default_value, a);
            frm.ShowDialog();
            if (frm.Canceled)
                canceled = true;
            return frm.SelectedValue;
        }
        //Public Functions
        public void Init(String prompt, String default_value, List<String> a)
        {
            ctlList.Caption = prompt;
            string build = "";
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += s;
            }
            ctlList.SimpleList = build;
            ctlList.SetValue(default_value);
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            SelectedValue = "";
            Close();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedValue = ctlList.GetValue_String();
            Close();
        }
    }
}
