using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseDateRange : Form
    {
        //Public Variables
        public Tools.Dates.DateRange SelectedDateRange;

        //Constructors
        public frmChooseDateRange()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static Tools.Dates.DateRange ChooseDateRange(DateTime dStart, DateTime dEnd, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseDateRange xForm = new frmChooseDateRange();
            xForm.CompleteLoad(dStart, dEnd, strCaption);
            xForm.ShowDialog(owner);
            return xForm.SelectedDateRange;
        }
        //Public Functions
        public void CompleteLoad(DateTime dStart, DateTime dEnd, String strCaption)
        {
            dtStart.Value = dStart;
            dtEnd.Value = dEnd;
            lblCaption.Text = strCaption;
        }
        //Private Functions
        private void OK()
        {
            SelectedDateRange = new Tools.Dates.DateRange(dtStart.Value, dtEnd.Value);
            Close();
        }
        private void Cancel()
        {
            SelectedDateRange = null;
            Close();
        }
        //Buttons
        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
