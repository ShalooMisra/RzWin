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
    public partial class frmChoosePrintedForm : Form
    {
        //Public Variables
        public printheader TheForm;
        public bool IsCancel = false;
        //Private Variables
        private ContextRz TheContext;
        private ordhed TheOrder;
        private TransmitParameters TheParams;

        //Constructors
        public frmChoosePrintedForm()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static printheader ChoosePrintedForm(ContextNM x, ordhed o, TransmitParameters p)
        {
            frmChoosePrintedForm f = new frmChoosePrintedForm();
            if (!f.CompleteLoad(x, o, p))
                return null;
            f.ShowDialog();
            if (f.IsCancel)
                return null;
            else
                return f.TheForm;
        }
        //Public Functions
        public bool CompleteLoad(ContextNM x, ordhed o, TransmitParameters p)
        {
            if (x == null)
                return false;
            if (o == null)
                return false;
            if (p == null)
                return false;
            TheContext = (ContextRz)x;
            TheOrder = o;
            TheParams = p;
            LoadForms();
            return true;
        }
        //Private Functions
        private void Accept()
        {
            try
            {
                TheForm = (printheader)lv.GetSelectedObject();
            }
            catch { }
        }
        private void LoadForms()
        {
            lv.ShowData(RzWin.Context.TheSysRz.TheOrderLogic.OrdHedPrintTemplateArgsGet(TheContext, TheOrder, TheParams.type));
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            IsCancel = true;
            Close();
        }
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
            Close();
        }
    }
}
