using System;
using System.Collections.Generic;

using System.Collections;
using NewMethod;
using HubspotApis;
using System.Linq;
using System.Text;
using SensibleDAL;
using SensibleDAL.dbml;
using RzInterfaceWin.Dialogs;
using System.Windows.Forms;
using Rz5.Enums;

namespace Rz5
{
    public partial class ViewHeaderQuote : ViewHeader
    {
        //Protected Variables
        protected ordhed_quote CurrentQuote
        {
            get { return (ordhed_quote)CurrentOrder;}
        }
               
        protected NewMethod.n_user CurrentQuoteAgent;

        //Constructors
        public ViewHeaderQuote()
        {
            InitializeComponent();
        }
        //Protected Override Functions
        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                dv.Top = tsDetails.Top;
                dv.Left = tsDetails.Left;
                dv.Width = tsDetails.Width;
                dv.Height = tsDetails.Height;
            }
            catch { }
        }
        protected override void CompleteLoad_Shipping()
        {
            base.CompleteLoad_Shipping();
        }

        //KT 11-9-2015 Refactored
        protected override void CompleteLoad_Company(Rz5.company c)
        {
            lblFinancials.Visible = false;
            base.CompleteLoad_Company(c);
            if (!((CompanyLogic)((SysRz5)RzWin.Context.xSys).TheCompanyLogic).IsCompanyFinancialsVerified(c, CurrentOrder))
            {
                lblFinancials.Visible = true;
                lblFinancials.BringToFront();
            }

        }


        protected override void SetShipVia()
        {

        }

        protected override void SetShipAccounts()
        {

            IsLoading = true;
            try
            {
                CurrentQuote.shippingaccount = ctl_shippingaccount.GetValue_String();

                CurrentQuote.shipvia = ctl_shipvia.GetValue_String();
                CurrentQuote.Update(RzWin.Context);
            }
            catch { }
            //CompleteLoad_Shipping();
            IsLoading = false;

        }
        //KT added by KT to contain CheckPermissions.
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            CurrentQuoteAgent = NewMethod.n_user.GetById(RzWin.Context, CurrentQuote.base_mc_user_uid);
            CheckPermissions();
            //LoadClosurePanel();
            LoadOpportunity();

        }


        public override void CompleteSave()
        {
            try
            {
                SetShipAccounts();
                //SaveOpportunity();
                base.CompleteSave();
            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }

        }


        protected override void CompleteLoad_Totals()
        {
            lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            lblCost.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            lblProfit.Text = RzWin.Context.TheSys.CurrencySymbol + " 0.00";
            if (CurrentQuote == null)
                return;
            CurrentQuote.CalculateAllAmounts(RzWin.Context);
            lblTotal.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentQuote.ordertotal);
            lblCost.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentQuote.costamount);
            lblProfit.Text = RzWin.Context.TheSys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentQuote.profitamount);

            //KT 11-9-2015 Refactored
            double sub_total = 0;
            foreach (orddet_quote l in CurrentQuote.DetailsList(RzWin.Context))
            {
                if (l.isselected)
                {
                    l.CalculateAmounts();
                    sub_total += l.quantityordered * l.unitprice;
                }
            }
            lblPerc.Text = RzWin.Context.Sys.TheOrderLogic.GetMarginNetPercent(CurrentQuote.profitamount, CurrentQuote.costamount);
            lblMargin.Text = RzWin.Context.Sys.TheOrderLogic.GetMarginNetPercent(CurrentQuote.profitamount, sub_total);


        }
        protected override void CompleteLoad_Status()
        {
            base.CompleteLoad_Status();
            CurrentQuote.LoadMissingProperties(RzWin.Context);
            LoadCompletionReport();
            cmdAction1.ImageKey = "TurnInQuote.png";
            cmdAction2.ImageKey = "ValidateQuote.png";
            gbAction1.Visible = false;//turn In           
            gbAction2.Visible = false;//Validate
            gbReport.Visible = false;//Report

            //Get count of quote lines
            int count = CurrentQuote.DetailCountGet(RzWin.Context, Enums.OrderLineStatus.Open);

            //Check if order can move to closure
            if (count > 0 && !CurrentQuote.isclosed)
            {
                //Allow turn in?
                gbAction1.Visible = TurnInAllowed();
                //Allow Validate / Create Sales Order
                gbAction2.Visible = ActivateAllowed();
                //Show the Completion Report.
                gbReport.Visible = ShowCompletionReport();
            }
            //Line Count
            lblLineStatus1.Text = "Open Lines: " + count.ToString();
            //Opportunity Stage:
            gbOpportunityStage.Text = "Opportunity Stage: " + CurrentQuote.opportunity_stage;

        }

        private bool TurnInAllowed()
        {

            if (CurrentQuote.ready_to_validate)
                return false;
            
            //Allow turn in if no missing Properties AND ...
            if (CurrentQuote.MissingPropertiesList.Count <= 0)
            {
                //... AND we have an orderreference
                string customerPO = ctl_orderreference.GetValue_String();
                if (!string.IsNullOrEmpty(customerPO))
                    return true;
            }

            //If we are missing Only 1 prop AND that prop is insufficient Credit, allow Turn In.
            else if (CurrentQuote.MissingPropertiesList.Count == 1)
            {
                string missingProp = CurrentQuote.MissingPropertiesList.Select(s => s.Value[0]).FirstOrDefault();
                if (missingProp.ToLower().Contains("insufficient credit"))
                    return true;
            }
            //All other conditions, don't allow Turn In.
            return false;
        }

        private bool ActivateAllowed()
        {
            //Must have been "Turned in" i.e. ready_to_validate AND have all issues resolved.
            if (CurrentQuote.ready_to_validate)
                return CurrentQuote.MissingPropertiesList.Count == 0;
            return false;
        }

        private bool ShowCompletionReport()
        {
            //Always show if there are items missing
            if (CurrentQuote.MissingPropertiesList.Count > 0)
                return true;
            return false;

        }

        //
        ordhed_sales sale_result;

        //
        protected override void Action1()
        {
            //Turn in Quote for Validation
            //Terms and Condition Confirmation
            //if (!RzWin.Leader.AskYesNo("Are you sure you have received a valid, hard-copy PO from the customer??"))
            //    return;

            bool customerTermsValidated = RzWin.Context.Leader.ConfirmCustomerTermsConditions(RzWin.Context, CurrentCompany);
            if (!customerTermsValidated)
                return;

            CurrentQuote.ready_to_validate = true;
            CurrentQuote.Update(RzWin.Context);


        }
        protected override void Action1Complete()
        {
            base.Action1Complete();

        }
        protected override void Action2()
        {
            try
            {

                //Validate and Create Sale
                if (CurrentQuote == null)
                    return;


                if (CheckQuoteDetails(true)) //IT could be that ther was once all data gathered, but something get deleted, and the status didn't get un-set, so let's confirm that now
                {
                    //bool customerTermsValidated = RzWin.Context.Leader.ConfirmCustomerTermsConditions(RzWin.Context, CurrentCompany);
                    //At Quote to Sale time, we pop an alert and email ap, sales agent and Joemar if has aged invoices
                    //Must still allow sale completion lest we lost stock.
                    RzWin.Context.TheSysRz.TheQuoteLogic.CheckAgedInvoices(RzWin.Context, CurrentCompany, CurrentQuote, true);


                    sale_result = CurrentQuote.SalesOrderCreate(RzWin.Context);
                    ////Moving this to the "TurnIn" workflow (Action1)
                    //Now that we have a sale, if we have a validation Hold, set it now
                    //if (sale_result != null)
                    //{
                    //    if (!customerTermsValidated)
                    //    {
                    //        validation_tracking vt = RzWin.Context.TheSysRz.TheOrderLogic.TrackValidation(RzWin.Context, sale_result, SalesOrderValidationStage.ValidationHold.ToString());
                    //    }
                    //}


                    CurrentQuote.opportunity_stage = SM_Enums.OpportunityStage.sale_won.ToString();
                    CurrentQuote.Update(RzWin.Context);
                    if (RzWin.Context.xSys.Recall)
                        RzWin.Context.xSys.RecallActionLog(CurrentQuote, "Sales Order Created: " + sale_result.ordernumber, RzWin.Context.xUser);

                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
                return;
            }
        }
        protected override void Action2Complete()
        {
            base.Action2Complete();

            if (sale_result == null)
                //CompleteLoad();
                return;
            RzWin.Context.Show(sale_result);
            SendCloseRequest();

        }





        private bool CheckQuoteDetails(bool gather = false)
        {


            bool already_gathered = CurrentQuote.is_all_data_gathered;
            //This needs to be in RzWin.Context.TheSysRz.TheOrderLogic.CheckOrderData()

            CurrentQuote.LoadMissingProperties(RzWin.Context, true);

            if (CurrentOrder.MissingPropertiesList.Count > 0)
            {
                CurrentQuote.is_all_data_gathered = false;
            }
            else
                CurrentQuote.is_all_data_gathered = true;

            //If the value changed in this session, update the order.
            if (already_gathered != CurrentQuote.is_all_data_gathered)
                CurrentQuote.Update(RzWin.Context);
            return CurrentQuote.is_all_data_gathered;



        }





        public override void FinishedAction(Core.ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "importlines":
                    ImportDetailLines();
                    break;
            }
            base.FinishedAction(args);
        }
        private void ImportDetailLines()
        {
            try
            {
                if (CurrentOrder == null)
                    return;
                dv.CompleteLoad();
                dv.SetAcceptCaption("Import These Lines");
                dv.AddCommonField("fullpartnumber", "Part Number", "part|number", true);
                dv.AddCommonField("quantityordered", "Quantity", "qty|quantity|quanity");
                dv.AddCommonField("manufacturer", "Manufacturer", "mfg|mfr|manufacturer|brand");
                dv.AddCommonField("datecode", "Date Code", "dc|datecode");
                dv.AddCommonField("unitprice", "Price", "targetprice|price");
                dv.AddCommonField("unitcost", "Cost", "cost");
                dv.AddCommonField("alternatepart", "Alternate Part #", "alternate|internal");
                dv.SetClass("orddet_quote");
                dv.Clear();
                dv.Visible = true;
                dv.BringToFront();
            }
            catch (Exception)
            {
            }
        }
        private void dv_Accept()
        {
            ArrayList a = dv.GetObjects();
            foreach (nObjectHolder h in a)
            {
                if (Tools.Strings.StrCmp(h.xObject.ClassId, "orddet_quote"))
                {
                    orddet_quote d = (orddet_quote)h.xObject;
                    if (Tools.Strings.StrExt(d.fullpartnumber))
                    {
                        d.Insert(RzWin.Context);
                        CurrentOrder.InsertDetail(RzWin.Context, d);
                    }
                }
            }
            CompleteLoad();
            dv.Visible = false;
        }

        private void CheckPermissions()
        {
            ctl_terms.Enabled = (RzWin.Context.CheckPermit(NewMethod.Permissions.ThePermits.CanSetCustomerTerms));
        }




        /// <summary>
        /// Opportunity Management
        /// </summary>

        //protected void LoadClosurePanel()
        //{

        //    //RzWin.Context.TheSysRz.TheOrderLogic.GetOpportunityStage_Quote(RzWin.Context, CurrentQuote);
        //    ctl_isLost.Enabled = RzWin.Context.Sys.TheOrderLogic.CanMarkQuoteLost(RzWin.Context, CurrentQuote);
        //    ctl_opportunity_lost_reason.LoadList("opportunity_lost_reason");
        //    if (CurrentQuote.opportunity_stage == HubspotLogic.GetDealStageNameFromDealStageID(HubspotApi.DealStage.sale_lost))
        //    {
        //        ctl_isLost.zz_CheckValue = true;
        //        ctl_opportunity_lost_reason.SetValue(CurrentQuote.opportunity_lost_reason);
        //    }
        //}
        protected void LoadOpportunity()
        {
            if (string.IsNullOrEmpty(CurrentQuote.opportunity_type))
                if (CurrentQuoteAgent != null)
                    if (CurrentQuoteAgent.IsTeamMember(RzWin.Context, "Distributor Sales", CurrentQuoteAgent))
                    {
                        CurrentQuote.opportunity_type = "Distributor";
                        CurrentQuote.Update(RzWin.Context);
                    }


        }
        protected void SaveOpportunity()
        {


            ////Opportunity Type
            //CurrentOrder.opportunity_type = ctl_opportunity_type.GetValue_String();

            ////Variables
            ////bool isLost = ctl_isLost.zz_CheckValue;
            ////string lostReason = ctl_opportunity_lost_reason.GetValue_String();

            ////The Below Methods update CurrentQuote.  Pass it's values to Hubspot AFTER saving the new opp values.
            //if (isLost)
            //{
            //    if (!string.IsNullOrEmpty(lostReason))
            //    {
            //        RzWin.Context.TheSysRz.TheOrderLogic.SetOpportunityLost(RzWin.Context, CurrentQuote, lostReason);
            //    }

            //    else
            //    {
            //        RzWin.Leader.Tell("Please select an reason from the list before marking this quote lost.");
            //        ctl_isLost.zz_CheckValue = false;
            //    }
            //    return;
            //}
            //else
            //{
            //    //if it's currently marked as lost, offer to reopen.
            //    if (!string.IsNullOrEmpty(CurrentOrder.opportunity_lost_reason))
            //        if (RzWin.Leader.AskYesNo("This opportuity is currently marked as lost (" + CurrentOrder.opportunity_lost_reason + ").  Would you like to reopen it?"))
            //        {
            //            RzWin.Context.TheSysRz.TheOrderLogic.SetOpportunityOpen(RzWin.Context, CurrentQuote);
            //        }

            //}




        }

        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdSetShipAccounts_Click(object sender, EventArgs e)
        {
            SetShipAccounts();
        }

        private void ViewHeaderQuote_Load(object sender, EventArgs e)
        {

        }



        //private void ctl_isLost_CheckChanged(object sender)
        //{
        //    //ctl_opportunity_lost_reason.Enabled = ctl_isLost.zz_CheckValue;
        //}

    }
}





