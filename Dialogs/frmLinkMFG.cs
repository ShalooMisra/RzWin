using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmLinkMFG : Form
    {
        n_choice CurrentChoice = null;

        //Constructors
        public frmLinkMFG()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static void Choose(ref n_choice choice, Form owner)
        {
            Choose(ref choice, owner, "manufacturers", "Choose Manufacturer");
        }
        public static void Choose(ref n_choice choice, Form owner, String listname, String caption)
        {
            //if (xs == null)
            //    return;
            frmLinkMFG xForm = new frmLinkMFG();
            xForm.CompleteLoad();
            xForm.SetList(listname, caption);
            xForm.ShowDialog(owner);
            choice = xForm.CurrentChoice;
            xForm.Close();
        }
        //Public Functions
        public void CompleteLoad()
        {
            ctl_MFGList.LoadList(true);
        }
        public void SetList(String listname, String caption)
        {
            ctl_MFGList.Caption = caption;
            ctl_MFGList.ListName = listname;
            ctl_MFGList.LoadList(true);
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            CurrentChoice = null;
            Close();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            String v = ctl_MFGList.GetValue_String();
            n_choice c = ctl_MFGList.CurrentChoices.GetChoice(RzWin.Context, v);
            if (c == null)
                return;
            CurrentChoice = c;
            Close();
        }
    }
}