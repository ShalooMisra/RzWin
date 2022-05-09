using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmAddToSO : Form
    {
        SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }

        Boolean bNew;
        Boolean bCancel;
        String sID;

        public frmAddToSO()
        {
            InitializeComponent();
        }
        public void CompleteLoad()
        {
            bNew = false; 
            bCancel = false;
            sID = "";
        }
        //Public Functions
        public Boolean IsCanceled()
        {
            return bCancel;
        }
        public Boolean IsNew()
        {
            return bNew;
        }
        public String GetID()
        {
            return sID;
        }
        //Buttons
        private void cmdNewSalesOrder_Click(object sender, EventArgs e)
        {
            bCancel = false;
            bNew = true;
            this.Hide();
        }
        private void cmdFill_Click(object sender, EventArgs e)
        {
            String SQL = "select top 200 (ordernumber + ' - ' + companyname) as ordernumb, unique_id from " + ordhed.MakeOrdhedName(Enums.OrderType.Sales) + " where ordertype = 'sales' order by orderdate desc";
            if (!RzWin.Context.CheckPermit("Orders:Edit:CanEditSales"))
                SQL += " and base_mc_user_uid = '" + RzWin.User.unique_id + "'";
            cboOrders.DataSource = RzWin.Context.Select(SQL);
            cboOrders.DisplayMember = "ordernumb";
            cboOrders.ValueMember = "unique_id";
            cboOrders.Text = "";
            cboOrders.SelectedItem = null;
            cboOrders.Enabled = true;
        }
        private void cmdAddTo_Click(object sender, EventArgs e)
        {
            try
            {
                bCancel = false;
                bNew = false;
                sID = cboOrders.SelectedValue.ToString();  
                this.Hide();
            }
            catch(Exception)
            { }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            bCancel = true;
            bNew = false;
            this.Hide();
        }
        //Control Events
        private void cboOrders_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ordhed o = ordhed.GetById(RzWin.Context, cboOrders.SelectedValue.ToString());
                if (o == null)
                {
                    RzWin.Leader.Tell("This order could not be found in the system.");
                    return;
                }
                cmdAddTo.Enabled = true;
                cmdAddTo.Text = "Add To " + o.ordernumber + "    >>>"; 
            }
            catch (Exception)
            { }
        }
    }
}