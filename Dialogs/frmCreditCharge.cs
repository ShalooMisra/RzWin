using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Rz5;

namespace Rz5
{
    public partial class frmCreditCharge : Form
    {
        //Private Variables
        private ContextNM TheContext;
        private ordhit TheHit;

        //Constructors
        public frmCreditCharge()
        {
            InitializeComponent();
            this.AcceptButton = cmdAdd;
        }
        //Public Functions
        public void CompleteLoad(ContextNM x, ordhit h)
        {
            TheContext = x;
            TheHit = h;
            ctl_ordhit_name.LoadList(true);
            LoadHit();
        }
        //Private Functions
        private void LoadHit()
        {
            if (TheHit == null)
                return;
            ctl_ordhit_name.SetValue(TheHit.ordhit_name);
            cbxDeductProfit.Checked = TheHit.deduct_profit;
            ctl_hit_amount.SetValue(TheHit.hit_amount);
            ctl_notes.SetValue(TheHit.notes);
          
        }      

        private void Add()
        {
            //ensure the user enters a value for both ordhit_name and hit_amount
            //if(ctl_ordhit_name.GetValue_String().Length == 0 || ctl_hit_amount.GetValue_Double() == 0 )
            //{
            //    if (ctl_ordhit_name.GetValue_String().Length == 0)
            //    {
            //        RzWin.Context.Leader.Tell("Please choose a category.");
            //        return;
            //    }
            //    else 
            //    {
            //        RzWin.Context.Leader.Tell("Please enter an amount.");
            //        return;
            //    } 
            //}
            //else
            //{
                if (TheHit == null)
                    TheHit = new ordhit();
                TheHit.ordhit_name = ctl_ordhit_name.GetValue_String();
                TheHit.notes = ctl_notes.GetValue_String();
                TheHit.deduct_profit = cbxDeductProfit.Checked;
                TheHit.hit_amount = ctl_hit_amount.GetValue_Double();               
                if (optCharge.Checked)
                {
                    TheHit.is_credit = false;
                    TheHit.hit_amount = Math.Abs(ctl_hit_amount.GetValue_Double());
                }
                else if (optCredit.Checked)
                {
                    TheHit.is_credit = true;
                    TheHit.hit_amount = Math.Abs(ctl_hit_amount.GetValue_Double());
                }
                if (!Tools.Strings.StrExt(TheHit.unique_id))
                    TheHit.Insert(RzWin.Context);                   
                else
                    TheHit.Update(RzWin.Context);
                Close();
               
           // }
           
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            Add();
            
        }
       
        private void ctl_ordhit_name_SelectionChanged(Tools.GenericEvent e)
        {

            List<string> creditList = new List<string> { "Customer Credit", "Customer Discount" };
            if (creditList.Contains(ctl_ordhit_name.GetValue_String()))
            {
                cbxDeductProfit.Visible = true;
                cbxDeductProfit.Checked = true;
                optCredit.Checked = true;
                optCharge.Checked = false;
            }
                
            else
            {
                cbxDeductProfit.Visible = false;
                cbxDeductProfit.Checked = false;
                optCredit.Checked = false;
                optCharge.Checked = true;
            }
                
        }
    }
}
