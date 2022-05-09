using QBFC13Lib;
using Rz5;
using NewMethod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rz5
{
    public partial class frmQuickbooksSalesRepsTests : Form
    {
        public frmQuickbooksSalesRepsTests()
        {
            InitializeComponent();
        }

        private void btnSearchByInitials_Click(object sender, EventArgs e)
        {
            
            string s = ctlQuery.GetValue_String();
            if (string.IsNullOrEmpty(s))
            {
                RzWin.Context.Leader.Error("Please provide Initials.");
                return;
            }
            ISalesRepRet salesRep = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetQbSalesRepByName(RzWin.Context, s);
            if(salesRep == null)
            {
                RzWin.Context.Leader.Error("No rep intials match '"+s+"'");
                return;
            }
            else
            {
                frmQuickbooksViewSalesRep f = new frmQuickbooksViewSalesRep(salesRep);
                f.CompleteLoad();
                f.Show();
            }
            
        }

        private void btnSearchByUser_Click(object sender, EventArgs e)
        {
            
        }
    }
}
