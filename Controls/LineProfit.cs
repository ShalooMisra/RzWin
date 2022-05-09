using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using Core;

namespace Rz5.Win.Controls
{


    public partial class LineProfit : UserControl
    {


        //Private Variables
        private orddet_line TheLine;
        private profit_deduction TheDeduction;
        private bool TotalsVisible = true;
        private Enums.OrderType TheType;
        private ordhed_sales TheSale;
        private ordhed_purchase ThePurchase;
        private ordhed CurrentOrder;

        //Constructors
        public LineProfit()
        {
            InitializeComponent();
        }
        //Public Functions
        //public void Init(orddet_line l, Enums.OrderType t)
        //{
        //    TheLine = l;
        //    TheType = t;
        //    LoadLine();
        //}

        ////KT - new init that accepts the current sales order object as well
        //public void Init(orddet_line l, Enums.OrderType t, ordhed_sales s)
        //{
        //    TheSale = s;
        //    TheLine = l;
        //    CurrentOrder = s;
        //    ctl_include_on_po.Visible = !String.IsNullOrEmpty(l.orderid_purchase); //Visible if orderid_purchase exists.
        //    TheType = t;
        //    LoadLine();
        //}
        public void Init(orddet_line l, Enums.OrderType t, ordhed o)
        {
            //if (o == null)
            //    throw new Exception("Header order not identified for this deduction.  Please report to IT.");
            CurrentOrder = o;

            TheLine = l;
            TheType = t;
            ctl_include_on_po.Visible = !String.IsNullOrEmpty(l.orderid_purchase); //Visible if orderid_purchase exists.
            LoadLine();
        }

        public void InitUn()
        {
            try
            {
                TheLine = null;
            }
            catch { }
        }
        public void Save()
        {
            DeductionSave();
        }
        //Private Functions
        private void LoadLine()
        {

            lblCaption.Text = "Deductions on " + TheLine.ToString();
            lvDeductions.CurrentVar = TheLine.DeductionsVar;
            int n = TheLine.DeductionsVar.CountGet(RzWin.Context);
            lvDeductions.Init(TheLine.DeductionArgsGet(RzWin.Context));
            //ctlDeductionName.LoadList("deduction_type");
            ctlDeductionName.LoadList(true);
            if (!CanManageDeductions())
                lvDeductions.AllowAdd = false;

            TotalsVisible = TheLine.SalesHas;
            pTotals.Visible = TotalsVisible;



            lblGP.Text = Tools.Number.MoneyFormat(TheLine.gross_profit);

            if (TheLine.total_deduction == 0)
            {
                lblDeductions.Text = "None";
                lblDeductions.ForeColor = Color.Gray;
            }
            else
            {
                lblDeductions.Text = Tools.Number.MoneyFormat(TheLine.total_deduction);
                lblDeductions.ForeColor = Color.Red;
            }

            if (TheLine.RMAHas)
            {
                lblRMA.ForeColor = Color.Red;
                lblRMA.Text = Tools.Number.MoneyFormat(TheLine.rma_subtraction);
            }
            else
            {
                lblRMA.ForeColor = Color.Gray;
                lblRMA.Text = "None";
            }
            lblNet.Text = Tools.Number.MoneyFormat(TheLine.net_profit);
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                lvDeductions.Left = 0;
                lvDeductions.Width = this.ClientRectangle.Width;

                pTotals.Left = this.ClientRectangle.Width - pTotals.Width;
                pDeduction.Left = 0;
                pDeduction.Width = this.ClientRectangle.Width;

                if (pDeduction.Visible)
                {

                }
                else
                {

                }

                if (TotalsVisible)
                {
                    pTotals.Visible = true;

                    if (TheDeduction == null)
                    {
                        //KT adding padding for the bottom bar of Rz (+ 60)
                        lvDeductions.Height = this.ClientRectangle.Height - (lvDeductions.Top + pTotals.Height + 60);
                        pTotals.Top = lvDeductions.Bottom;
                        //pDeduction.Visible = false;
                    }
                    else
                    {
                        //pDeduction.Visible = true;
                        lvDeductions.Height = this.ClientRectangle.Height - (lvDeductions.Top + pDeduction.Height + pTotals.Height);
                        //pDeduction.Top = lvDeductions.Bottom;
                        //pTotals.Top = pDeduction.Bottom;
                    }
                }
                else
                {
                    pTotals.Visible = false;

                    if (TheDeduction == null)
                    {
                        lvDeductions.Height = this.ClientRectangle.Height - lvDeductions.Top;
                        //pDeduction.Visible = false;
                    }
                    else
                    {
                        //pDeduction.Visible = true;
                        //lvDeductions.Height = this.ClientRectangle.Height - (lvDeductions.Top + pDeduction.Height);
                        //pDeduction.Top = lvDeductions.Bottom;
                    }
                }
            }
            catch { }
        }
        private void DeductionShow(profit_deduction d)
        {
            TheDeduction = d;
            ctlDeductionName.SetValue(TheDeduction.name);
            ctlDeductionAmount.SetValue(TheDeduction.amount);
            ctldescription.SetValue(TheDeduction.description);
            ctl_include_on_po.SetValue(TheDeduction.include_on_po);
            ctl_is_payroll_deduction.SetValue(TheDeduction.is_payroll_deduction);
            ctl_exclude_from_profit_calc.SetValue(TheDeduction.exclude_from_profit_calc);
            DoResize();
        }
        private void DeductionSave()
        {
            //TheDeduction = (profit_deduction)lvDeductions.GetSelectedObject();
            //if (TheDeduction == null)
            //    throw new Exception ("Please select a deduction from the list to save.");
            //TheDeduction.name = ctlDeductionName.GetValue_String();
            //TheDeduction.amount = ctlDeductionAmount.GetValue_Double();
            //if (TheDeduction.created_by.Length == 0)
            //    TheDeduction.created_by = RzWin.User.Name;
            //TheDeduction.modified_by = RzWin.User.Name;
            //TheDeduction.description = ctldescription.GetValue_String();
            //TheDeduction.exclude_from_profit_calc = ctl_exclude_from_profit_calc.zz_CheckValue;

            ////KT check for orderid_sales and ensure it's tagged if exists.
            //if (!String.IsNullOrEmpty(TheLine.orderid_sales))
            //{
            //    TheDeduction.linecode_sales = TheLine.linecode_sales;
            //    TheDeduction.sales_order_uid = TheLine.orderid_sales;
            //}

            //if (!String.IsNullOrEmpty(TheLine.orderid_purchase))
            //{

            //    TheDeduction.purchase_order_uid = TheLine.orderid_purchase;
            //    TheDeduction.vendor_name = TheLine.vendor_name;
            //    TheDeduction.vendor_uid = TheLine.vendor_uid;
            //    TheDeduction.ordernumber_purchase = TheLine.ordernumber_purchase;
            //}
            //if (ctl_include_on_po.zz_CheckValue == true)
            //{
            //    TheDeduction.include_on_po = ctl_include_on_po.zz_CheckValue;
            //}

            //if (ctl_is_payroll_deduction.zz_CheckValue == true)
            //    TheDeduction.is_payroll_deduction = true;
            //else
            //    TheDeduction.is_payroll_deduction = false;

            //TheDeduction.Update(RzWin.Context);
        }


        //Buttons
        private void cmdOk_Click(object sender, EventArgs e)
        {
            DeductionSave();
            TheDeduction = null;
            TheLine.CalculateAmounts(RzWin.Context);
            LoadLine();
        }
        //Control Events
        private void LineProfit_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvDeductions_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            AddDeduction(RzWin.Context);
        }
        private void lvDeductions_AboutToThrow(Context x, Core.ShowArgs args)
        {
            if (CanManageDeductions())
            {
                args.Handled = true;
                //DeductionShow((profit_deduction)args.TheItems.FirstGet(RzWin.Context));
                ShowDeduction(x);
            }

            else
                RzWin.Leader.Tell("Sorry, editing deductions is not possible with current permission level.");

        }

        private void ShowDeduction(Context x)
        {

            profit_deduction p = (profit_deduction)lvDeductions.GetSelectedObject();
            if (p == null)
                return;
            frmDeduction f = new frmDeduction();
            //f.CompleteLoad(RzWin.Context, d, TheLine);
            //f.CompleteLoad(RzWin.Context, p, TheLine, TheSale);            
            f.CompleteLoad((ContextRz)x, p, TheLine, CurrentOrder);
            f.ShowDialog();
        }

        private void AddDeduction(Context x)
        {
            //profit_deduction p = new profit_deduction();
            //if (p == null)
            //    return;            
            profit_deduction d = TheLine.DeductionsVar.RefAddNew(Rz5.RzWin.Context);
            frmDeduction f = new frmDeduction();
            //f.CompleteLoad(RzWin.Context, d, TheLine, TheSale);
            f.CompleteLoad((ContextRz)x, d, TheLine, CurrentOrder);
            f.ShowDialog();

            //CurrentOrder.Update(RzWin.Context);



            ////Her'es how they did in from PO header:
            //profit_deduction p = ((ordhed_purchase)CurrentOrder).DeductionsVar.RefAddNew(RzWin.Context);
            //ShowCharge(p);
            //CompleteLoad_Charges();
            //CurrentOrder.Update(RzWin.Context);

        }

        private bool CanManageDeductions()
        {
            //RzWin.Context.CheckPermit("Order:Edit:Can Close " + CurrentOrder.OrderType.ToString());
            bool allowed = ((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (NewMethod.Permissions.ThePermits).ManageDeductions, RzWin.Context.xUser);
            if (allowed)
                return true;
            else
                return false;

        }


        private void lvDeductions_AboutToAction(object sender, ActArgs args)
        {

            if (args.ActionName == "delete")
            {
                args.Handled = true;
                deleteDeductions();
            }

        }

        private void deleteDeductions()
        {
            if (TheLine == null)
                return;

            ArrayList objects = lvDeductions.GetSelectedObjects();
            if (((SysRz5)RzWin.Context.xSys).ThePermitLogic.CheckPermit(RzWin.Context, (NewMethod.Permissions.ThePermits).ManageDeductions, RzWin.Context.xUser))
            {
                if (RzWin.Context.Leader.AskYesNo("Are you sure you want to delete this deduction(s)?"))
                    foreach (profit_deduction p in objects)
                    {
                        ThePurchase = ordhed_purchase.GetById(RzWin.Context, p.purchase_order_uid);
                        TheSale = ordhed_sales.GetById(RzWin.Context, p.sales_order_uid);



                        if (ThePurchase != null)
                        {

                            ThePurchase.DeductionsVar.RefsRemove(RzWin.Context, p);
                            ThePurchase.DeductionsVar.UpdateAll(RzWin.Context);
                            ThePurchase.Update(RzWin.Context);
                        }


                        if (TheSale != null)
                        {

                            TheSale.DeductionsVar.RefsRemove(RzWin.Context, p);
                            TheSale.DeductionsVar.UpdateAll(RzWin.Context);
                            TheSale.Update(RzWin.Context);
                        }


                        TheLine.DeductionsVar.RefsRemove(RzWin.Context, p);


                        TheLine.VarRefsList.Remove(TheLine.DeductionsVar);
                        TheLine.Update(RzWin.Context);

                        p.Delete(RzWin.Context);

                    }
            }





            //    //Save Deduction to DataBase
            //    if (!Tools.Strings.StrExt(TheDeduction.unique_id))
            //        TheDeduction.Insert(TheContext);
            //    else
            //        TheDeduction.Update(TheContext);

            //    //Set Line Ref
            //    TheLine.DeductionsVar.RefsRemove(TheContext, TheDeduction);
            //    TheLine.DeductionsVar.RefsAdd(TheContext, TheDeduction);
            //    TheLine.DeductionsVar.UpdateAll(TheContext);
            //    TheLine.Update(TheContext);

            //    ////Set Sales Ref
            //    if (TheSale != null)
            //    {

            //        TheSale.DeductionsVar.RefsRemove(TheContext, TheDeduction);
            //        TheSale.DeductionsVar.RefsAdd(TheContext, TheDeduction);
            //        TheSale.DeductionsVar.UpdateAll(TheContext);
            //        TheSale.Update(TheContext);
            //    }
            //    //Set Purchase Ref
            //    if (ThePurchase != null)
            //    {

            //        ThePurchase.DeductionsVar.RefsRemove(TheContext, TheDeduction);
            //        ThePurchase.DeductionsVar.RefsAdd(TheContext, TheDeduction);
            //        ThePurchase.DeductionsVar.UpdateAll(TheContext);
            //        ThePurchase.Update(TheContext);
            //    }
        }

        private void lvDeductions_AboutToDelete(object sender, ActArgs args)
        {


            //RzWin.Leader.Tell("About to Delete.");

        }


        private void lvDeductions_FinishedAction(object sender, ActArgs args)
        {
            //RzWin.Leader.Tell("Finished Action.");  
            //this.Refresh();
        }

        private void lvDeductions_Leave(object sender, EventArgs e)
        {
            //RzWin.Leader.Tell("Leave.");
        }
    }
}
