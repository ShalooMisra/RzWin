using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmAskSelectPrintedForm : Form
    {
        //Public Variables
        public ArrayList AllPrintedForms;
        //Private Variables
        private ContextNM TheContext;

        //Constructors
        public frmAskSelectPrintedForm()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static ArrayList AskSelectPrintedForm(ContextNM x)
        {
            if (x == null)
                return null;
            frmAskSelectPrintedForm f = new frmAskSelectPrintedForm();
            if (!f.CompleteLoad(x))
                return null;
            f.ShowDialog();
            return f.AllPrintedForms;
        }
        //Public Functions
        public bool CompleteLoad(ContextNM x)
        {
            if (x == null)
                return false;
            TheContext = x;
            LoadLV();
            return true;
        }
        //Private Functions
        private void LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                ArrayList a = RzWin.Context.QtC("printheader", "select * from printheader");
                if (a != null)
                {
                    foreach (printheader p in a)
                    {
                        if (p == null)
                            continue;
                        ListViewItem i = lv.Items.Add(p.printname);
                        i.Tag = p;
                    }
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void Select()
        {
            AllPrintedForms = new ArrayList();
            foreach (ListViewItem l in lv.CheckedItems)
            {
                AllPrintedForms.Add(l.Tag);
            }
        }
        private void Cancel()
        {
            AllPrintedForms = null;
        }
        //Buttons
        private void cmdClose_Click(object sender, EventArgs e)
        {
            Cancel();
            Close();
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            Select();
            Close();
        }
    }
}
