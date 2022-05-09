using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using NewMethod;
using System.Data.SqlTypes;
using System.Collections;

namespace Rz5
{
    public partial class frmDeduction : Form
    {
        //Private Variables
        private ContextRz TheContext;
        private Rz5.profit_deduction TheDeduction;
        private Rz5.orddet_line TheLine;
        private Rz5.ordhed_sales TheSale;
        private Rz5.ordhed_purchase ThePurchase;
        private ordhed_invoice TheInvoice;
        private ordhed_rma TheRma;
        private ordhed_vendrma TheVendRma;
        protected ViewDetailSales DetailView;
        //KT The Source is used to notify a user that SO needs to be closed and reopend to see changes.
        protected String TheSource;
        bool isCanceledLineDeduction = false;




        //Constructors
        public frmDeduction()
        {
            InitializeComponent();
        }


        //Public Functions
        public bool CompleteLoad(ContextRz x, Rz5.profit_deduction p, Rz5.orddet_line l, ordhed o, string Source = null)
        {
            try
            {


                if (x == null)
                    return false;
                if (p == null)
                    return false;
                if (l == null)
                    return false;

                TheContext = x;
                TheDeduction = p;
                TheLine = l;


                if (o != null)
                {
                    switch (o.ordertype.ToLower())
                    {
                        case "sales":
                            TheSale = (ordhed_sales)o;
                            break;
                        case "purchase":
                            ThePurchase = (ordhed_purchase)o;
                            break;
                        case "invoice":
                            TheInvoice = (ordhed_invoice)o;
                            break;
                        case "rma":
                            TheRma = (ordhed_rma)o;
                            break;
                        case "vendrma":
                            TheVendRma = (ordhed_vendrma)o;
                            break;


                    }
                }
                TheSource = Source;

                //KT if there isn't a po uid on the line, inhibit the ability to manage that.              
                if (!Tools.Strings.StrExt(l.orderid_purchase))
                    ctl_include_on_po.Visible = false;

                NMWin.LoadFormValues(this, TheDeduction);
                ctl_name.LoadList(true);
                ctl_name.SetValue(TheDeduction.Name);
                ctl_description.SetValue(TheDeduction.description);
                if (TheDeduction.payroll_deduction_date > new DateTime(1900, 1, 1))
                    ctl_payroll_deduction_date.SetValue(TheDeduction.payroll_deduction_date);
                else
                    ctl_payroll_deduction_date.SetValue(DateTime.Now);
                //Tooltip
                LoadToolTip();


                isCanceledLineDeduction = CheckIsCanceledLineDeduction(o);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool CheckIsCanceledLineDeduction(ordhed o)
        {
            ArrayList canceledDeductions = RzWin.Context.TheSysRz.TheProfitLogic.GetCanceledDeductions(RzWin.Context, o);
            if (canceledDeductions == null)
                return false;
            foreach (profit_deduction p in canceledDeductions)
            {
                if (p.unique_id == TheDeduction.unique_id)
                    return true;
            }
            return false;
        }

        private void LoadToolTip()
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.


            toolTip1.SetToolTip(this.ctl_is_payroll_deduction, "Payroll deductions exist to recoup losses that occur after commission payout.");
            toolTip1.SetToolTip(this.ctl_payroll_deduction_date, "The date of the payroll deduction (defaults to the date created).  This is the date of the invoice period this will be tallied.");
        }

        public void CompleteSave()
        {
            SaveDeduction();          
        }

      

        public void SaveDeduction()
        {

            if (TheLine == null)
                return;
            try
            {
                //Set Deduction details
                TheDeduction.name = ctl_name.GetValue_String();
                TheDeduction.description = ctl_description.GetValue_String();
                if (ctl_amount.GetValue_Double() < 0)
                    TheDeduction.amount = ctl_amount.GetValue_Double() * -1;
                else
                    TheDeduction.amount = ctl_amount.GetValue_Double();
                if (TheDeduction.created_by.Length == 0)
                    TheDeduction.created_by = RzWin.User.Name;
                TheDeduction.modified_by = RzWin.User.Name;
                TheDeduction.exclude_from_profit_calc = ctl_exclude_from_profit_calc.zz_CheckValue;
                TheDeduction.include_on_po = ctl_include_on_po.zz_CheckValue;
                //if (ctl_name.GetValue_String().ToLower() == "payroll deduction")
                if (ctl_is_payroll_deduction.zz_CheckValue == true)
                {
                    AddPayrollDeduction(RzWin.Context);
                }
                else
                {
                    if (TheDeduction.is_payroll_deduction)
                        RemovePayrollDeduction(RzWin.Context);
                }

                //Order References
                TheDeduction.purchase_order_uid = TheLine.orderid_purchase;
                TheDeduction.ordernumber_purchase = TheLine.ordernumber_purchase;
                TheDeduction.the_orddet_line_uid = TheLine.unique_id;
                TheDeduction.linecode_purchase = TheLine.linecode_purchase;
                TheDeduction.linecode_sales = TheLine.linecode_sales;
                TheDeduction.sales_order_uid = TheLine.orderid_sales;

                //Save Deduction to DataBase
                if (!Tools.Strings.StrExt(TheDeduction.unique_id))
                    TheDeduction.Insert(TheContext);
                else
                    TheDeduction.Update(TheContext);

                if (!isCanceledLineDeduction)
                {
                    //Set Line Ref
                    TheLine.DeductionsVar.RefsRemove(TheContext, TheDeduction);
                    TheLine.DeductionsVar.RefsAdd(TheContext, TheDeduction);
                    TheLine.DeductionsVar.UpdateAll(TheContext);
                    TheLine.Update(TheContext);

                    ////Set Sales Ref
                    if (TheSale != null)
                    {

                        TheSale.DeductionsVar.RefsRemove(TheContext, TheDeduction);
                        TheSale.DeductionsVar.RefsAdd(TheContext, TheDeduction);
                        TheSale.DeductionsVar.UpdateAll(TheContext);
                        TheSale.Update(TheContext);
                    }
                    //Set Purchase Ref
                    if (ThePurchase != null)
                    {

                        ThePurchase.DeductionsVar.RefsRemove(TheContext, TheDeduction);
                        ThePurchase.DeductionsVar.RefsAdd(TheContext, TheDeduction);
                        ThePurchase.DeductionsVar.UpdateAll(TheContext);
                        ThePurchase.Update(TheContext);
                    }
                }

                



            }
            catch (Exception ex)
            {
                TheContext.Leader.Tell(ex.Message);
            }
        }



        public void DeleteDeduction()
        {

            if (TheLine == null)
                return;
            try
            {
                if (RzWin.Context.Leader.AreYouSure(" you want to delete this deduction?"))
                {



                    //IF this deduction is in the refslist, remove it, otherwise, it's a canceled line, no refs exist, just delete from database.
                    if (!isCanceledLineDeduction)
                    {
                        TheLine.DeductionsVar.RefsRemove(TheContext, TheDeduction);
                        TheLine.DeductionsVar.UpdateAll(TheContext);
                        TheLine.Update(TheContext);

                        ////Set Sales Ref
                        if (TheSale != null)
                        {
                            TheSale.DeductionsVar.RefsRemove(TheContext, TheDeduction);
                            TheSale.DeductionsVar.UpdateAll(TheContext);
                            TheSale.Update(TheContext);
                        }
                        //Set Purchase Ref
                        if (ThePurchase != null)
                        {

                            ThePurchase.DeductionsVar.RefsRemove(TheContext, TheDeduction);
                            ThePurchase.DeductionsVar.UpdateAll(TheContext);
                            ThePurchase.Update(TheContext);
                        }
                    }


                    TheDeduction.Delete(RzWin.Context);


                    //TheLine.DeductionsVar.RefsRemove(TheContext, TheLine);
                    //TheContext.Delete(TheLine);
                    Close();
                }
            }
            catch (Exception ex)
            {
                TheContext.Leader.Tell(ex.Message);
            }
        }



        private void AddPayrollDeduction(ContextRz x)// if false will clear the PD Flags
        {
            ordhed_invoice i = null;
            if (!string.IsNullOrEmpty(TheLine.orderid_invoice))
                i = (ordhed_invoice)ordhed_invoice.GetById(TheContext, TheLine.orderid_invoice);
            if (i == null)
            {
                RzWin.Leader.Tell("Invoice not found.  Cannot deduct payroll.");
                return;
            }
            if (i.outstandingamount > 0)//If there is no Outstanding amont, it's paid in full or better.
            {
                RzWin.Leader.Tell("Invoice apoears to have an oustanding balance.  Cannot deduct payroll.");
                return;
            }
            TheDeduction.is_payroll_deduction = true;
            //DateTime minDate = SqlDateTime.MinValue.Value;
            //if (TheDeduction.payroll_deduction_date <= minDate)
            //    ctl_payroll_deduction_date.SetValue(DateTime.Now);
            //else
            //    ctl_payroll_deduction_date.SetValue(TheDeduction.payroll_deduction_date);
            TheDeduction.payroll_deduction_date = DateTime.Now;
            TheDeduction.payroll_deduction_date = ctl_payroll_deduction_date.GetValue_Date();
            TheDeduction.Update(x);
            //TheDeduction.payroll_deduction_date = ctl_payroll_deduction_date.GetValue_Date();

        }
        private void RemovePayrollDeduction(ContextRz x)// if false will clear the PD Flags
        {
            ordhed_invoice i = null;
            if (!string.IsNullOrEmpty(TheLine.orderid_invoice))
                i = (ordhed_invoice)ordhed_invoice.GetById(TheContext, TheLine.orderid_invoice);
            if (i == null)
            {
                RzWin.Leader.Tell("Invoice not found.  Cannot remove payroll deduction.");
                return;
            }

            TheDeduction.is_payroll_deduction = false;
            TheDeduction.payroll_deduction_date = SqlDateTime.MinValue.Value;

            TheDeduction.Update(x);
            ctl_payroll_deduction_date.Visible = false;

            //TheDeduction.payroll_deduction_date = ctl_payroll_deduction_date.GetValue_Date();

        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            CompleteSave();
            Close();
        }

        private void frmDeduction_Leave(object sender, EventArgs e)
        {

        }

        private void ctl_name_SelectionChanged(Tools.GenericEvent e)
        {

            //No, we don't want to have to create a SEPARATE deduction, simply flag existing deduction as a PD.
            //if (ctl_name.GetValue_String().ToLower() == "payroll deduction")
            //{
            //    ctl_description.SetValue("Payroll Deduction");
            //    ctl_payroll_deduction_date.Visible = true;
            //}
            //else
            //{                
            //    ctl_payroll_deduction_date.Visible = false;
            //}

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteDeduction();
        }

        private void ctl_is_payroll_deduction_CheckChanged(object sender)
        {
            //switch payroll deduction date on / off
        }


    }
}
