using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewMethod;
using QBFC13Lib;


namespace Rz5
{
    public partial class frmQuickbooksViewSalesRep : Form
    {
        private ISalesRepRet SalesRep;
        public frmQuickbooksViewSalesRep(ISalesRepRet salesRep)
        {
            InitializeComponent();
            SalesRep = salesRep;
        }


      public void CompleteLoad()
        {
            if (SalesRep == null)
            {
                RzWin.Context.Leader.Error("Sales Rep object cannot be null.");
                return;
            }               
            string name = SalesRep.SalesRepEntityRef.FullName.GetValue();
            string listID = SalesRep.SalesRepEntityRef.ListID.GetValue();
            string type = SalesRep.SalesRepEntityRef.Type.GetValue().ToString();


            lblName.zz_Text = name;
            lblListID.zz_Text = listID;
            lblType.zz_Text = type;

            n_user u = (n_user)RzWin.Context.QtO("n_user", "select * from n_user where qb_salesrep_listid = '" + listID + "'");
            bool userExists = u != null;
            SetUserExists(userExists);
           
            
        }

        private void SetUserExists(bool userExists)
        {
            if(userExists)
            {
                lblQbLinkageExists.BackColor = Color.DarkGreen;
                lblQbLinkageExists.Text = "Rz Linkage Exists";
            }
            else
            {
                lblQbLinkageExists.BackColor = Color.DarkOrange;
                lblQbLinkageExists.Text = "Rz Linkage does not Exist";
            }
        }
    }
}
