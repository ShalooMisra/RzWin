using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;
using Core;
using System.Collections;
using System.Linq;

namespace Rz5
{
    public partial class view_checkpayment : ViewPlusMenu
    {
        //Public Variables
        public checkpayment CurrentPayment
        {
            get
            {
                return (checkpayment)GetCurrentObject();
            }
        }

        public ordhed_new CurrentOrder
        {
            get
            {
                //return CurrentPayment.OrderObjectGet(RzWin.Context);
                return (ordhed_new)ordhed.GetById(RzWin.Context, CurrentPayment.base_ordhed_uid);
            }
        }

        //Private Variables        

        //Constructors
        public view_checkpayment()
        {
            InitializeComponent();
        }

        //Public Virtual Functions





        //Public Override Functions
        public override void Init(Item item)
        {
            base.Init(item);
            ctl_payment_type.LoadList(true);


        }



        public override void CompleteLoad()
        {

            if (RzWin.Context.Accounts.Enabled)
                throw new Exception("reorg");


            base.CompleteLoad();
            try
            {
                //GetPurchaseOrderLines();
                ctl_qb_account.LoadList(true);
                ctl_qb_account.SetValue(CurrentPayment.qb_account);
                //ordhed o = CurrentPayment.OrderObjectGet(RzWin.Context);
                if (CurrentOrder != null)
                {
                    lblCaption.Text = CurrentOrder.ToString();
                    lblDetails.Text = CurrentOrder.companyname + "\r\nDate: " + nTools.DateFormat(CurrentOrder.orderdate) + "\r\nTotal: $" + nTools.MoneyFormat(CurrentOrder.ordertotal);
                    //KT - Trying to fill Nlist with "details" - Working!
                    //details.CurrentVar = CurrentOrder.Details;
                    //details.Init(CurrentOrder.DetailArgsGet(RzWin.Context));          
                }


            }

            catch { }
            Xtransamount.SetValue(CurrentPayment.CalcTotal());



        }




        public override void CompleteSave()
        {
            if (RzWin.Context.Accounts.Enabled)
                throw new Exception("reorg");

            base.CompleteSave();
            CurrentPayment.Update(RzWin.Context);
            //KT - Trying to get UID form selected nList object to save to checkpayments table.

            if (details.GetSelectedID().Length > 0)
                CurrentPayment.line_uid = details.GetSelectedID();

            CurrentPayment.qb_account = ctl_qb_account.GetValue_String();
            //ordhed_new o = (ordhed_new)CurrentPayment.OrderObjectGet(RzWin.Context);
            //if (CurrentOrder == null)
            //o = (ordhed_new)ordhed.GetById(RzWin.Context, CurrentPayment.base_ordhed_uid);
            if (CurrentOrder != null)
            {
                CurrentPayment.ordernumber = CurrentOrder.ordernumber;
                //KT
                CurrentOrder.GatherTransactions(RzWin.Context);
                Double total = CurrentOrder.ordertotal;
                Double payments = GetOrderPaymentTotal(CurrentOrder);




                CurrentPayment.companyname = CurrentOrder.companyname;
                CurrentPayment.Update(RzWin.Context);
                CurrentOrder.CalculateAllAmounts(RzWin.Context);
                CurrentOrder.Update(RzWin.Context);
                if (CurrentPayment.sendTransactionAlertEmail)
                    SendTransactionAlertEmail();

                bool fullyPaid = payments >= total;
                if (fullyPaid)
                {
                    CheckCreditApplied();
                    string affiliateID = "";
                    if (IsAffiliateSale(out affiliateID))//And is affiliate salse
                        if (CurrentPayment.sendAffiliateAlertEmail)//and if email hasn't already been sent  
                            SendAffiliateSaleEmail(affiliateID);//send email alert
                }






                ShowTotal();
            }
        }

        private void SendAffiliateSaleEmail(string affiliateID)
        {
            try
            {
                //Don't bother if PO payment etc.
                if (!(CurrentOrder is ordhed_invoice))
                    return;
                string companyName = CurrentOrder.companyname;
                double ordertotal = CurrentOrder.ordertotal;
                string orderType = CurrentOrder.OrderType.ToString();
                string orderNumber = CurrentOrder.ordernumber;
                string agentNAme = CurrentOrder.agentname;
                string reference = CurrentPayment.referencedata;



                List<string> ccList = new List<string>() { "ap@sensiblemicro.com", "affiliates@sensiblemicro.com" };



                StringBuilder body = new StringBuilder();
                body.Append("<b>Transaction Details:</b><br />");
                body.Append("Company: " + companyName + "<br />");
                body.Append("Invoice Number: " + orderNumber + "<br />");
                body.Append("Invoice Total:" + ordertotal.ToString("C") + "<br />");
                body.Append("Terms:" + CurrentOrder.terms + "<br />");
                body.Append("Reference Data:" + reference + "<br />");               
                body.Append("Open Balance: " + CurrentOrder.outstandingamount.ToString("C") + "<br />");
                body.Append("Affiliate ID: " + affiliateID + "<br />");



                string subject = "Affiliate Sale paid in full:  " + orderType + "# " + orderNumber;


                nEmailMessage msg = new nEmailMessage();
                msg.IsHTML = true;
                msg.Subject = subject;
                msg.FromAddress = "affiliates@sensiblemicro.com";
                msg.ToAddress = msg.FromAddress;
                if (ccList.Count > 0)
                    msg.CcRecipients = ccList;

                msg.HTMLBody = body.ToString();
                string error = "";
                msg.SetDefaultServer();
                msg.Send(ref error);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception("Error sending new payment email: " + error);
                //set this to false to avoid re-sending on future saves of this transaction.
                CurrentPayment.sendAffiliateAlertEmail = false;
                CurrentPayment.Update(RzWin.Context);
                RzWin.Context.Leader.Tell("'Paid in Full' email sent to affiliate team for commission payout.");

            }
            catch (Exception ex)
            {
                RzWin.Context.Leader.Error(ex.Message);
            }
        }

        private bool IsAffiliateSale(out string affiliateID)
        {
            List<orddet_line> lines = CurrentOrder.DetailsList(RzWin.Context).Cast<orddet_line>().ToList();
            string id = lines.Where(w => w.affiliate_id.Length > 0 && w.affiliate_id != null).Select(ss => ss.affiliate_id).FirstOrDefault();
            affiliateID = id;
            return !string.IsNullOrEmpty(id);

        }

        private void CheckCreditApplied()
        {
            ArrayList assignedCredits = RzWin.Context.QtC("companycredit", "select * from companycredit where applied_to_order_uid = '" + CurrentOrder.unique_id + "'");
            List<companycredit> creditsList = assignedCredits.Cast<companycredit>().ToList();
            double totalAssignedCredits = creditsList.Sum(s => s.creditamount);
            if (assignedCredits.Count > 0)
                if (!RzWin.Leader.AskYesNo("There appears to be a total of $" + totalAssignedCredits + " in company credits applied to this order.  Please confirm " + CurrentOrder.companyname + " has accepted the credit"))
                    if (RzWin.Leader.AskYesNo("You have indicated " + CurrentOrder.companyname + " did not accept the credit(s) as payment.  Would you like to unassign all credits from this order? (This will release them and make them available for future payments."))
                        UnassingAllCredits(creditsList);


            //Get List of Credits applied to this order.
            //If Any, confirm the amount with the user, and ask to confirm it is applied.
            //If they say no,
            //Ask User if they would like to release / unassign the credit.
            //If Yes, unassign the credit.
        }

        private void UnassingAllCredits(List<companycredit> creditsList)
        {
            foreach (companycredit c in creditsList)
            {
                c.applied_to_order = null;
                c.applied_to_order_uid = null;
                c.is_applied = null;
                c.Update(RzWin.Context);
            }
        }

        //Private Functions
        protected Double GetOrderPaymentTotal(ordhed o)
        {
            if (o == null)
                return 0;
            String SQL = "select sum(abs(transamount)) from checkpayment where base_ordhed_uid = '" + o.unique_id + "'";
            Double d = RzWin.Context.SelectScalarDouble(SQL);
            //KJT 11-17-2015 - need to round payment amounts up to nearest 2-digits
            double dr = System.Math.Ceiling(d * 100) / 100;
            return dr;
        }


        //Control Events

        ////Get list of related Line Data and bind to nList
        //public void GetPOLines(ordhed o)
        //{
        //    String SQL = "select fullpartnumber, quantity, linecode from orddet_line where base_ordhed_uid = '" + o.unique_id + "'";
        //    List<string> POLines = new List<string>();//Get a list of PO Lines for this PO
        //    {
        //        POLines.Add(SQL);
        //    }
        //    cboPOLines.DataSource = POLines;                        
        //}

        //2012_04_10 moved the calculation to the object
        void ShowTotal()
        {
            Xtransamount.SetValue(ctl_subtotal.GetValue_Double() + ctl_feeamount.GetValue_Double() + ctl_handlingamount.GetValue_Double() + ctl_taxamount.GetValue_Double());
        }

        private void ctl_subtotal_DataChanged(GenericEvent e)
        {
            ShowTotal();
        }

        private void ctl_feeamount_DataChanged(GenericEvent e)
        {
            ShowTotal();
        }

        private void ctl_handlingamount_DataChanged(GenericEvent e)
        {
            ShowTotal();
        }

        private void ctl_taxamount_DataChanged(GenericEvent e)
        {
            ShowTotal();
        }

        private void view_checkpayment_Leave(object sender, EventArgs e)
        {
            //Update the Order 

            ordhed_new o = (ordhed_new)CurrentPayment.OrderObjectGet(RzWin.Context);

            o.Update(RzWin.Context);





            //Close the existing tab somehow           


            //Open a new tab? - 
            //o.ShowPayments(RzWin.Context);

        }

        private void SendTransactionAlertEmail()
        {

            try
            {

                //Send new Invoice Payment email Alert
                if (CurrentOrder.OrderType != Enums.OrderType.Invoice)
                    return;
                if (!CurrentPayment.sendTransactionAlertEmail)
                    return;
                if (CurrentPayment.transamount <= 0)
                    return;


                //Send an email alert with the following properties
                //companyname
                //transaction amount
                //Payment Date

                //To the following parties
                //sales agent
                //ap??

                string companyName = CurrentOrder.companyname;
                double transAmount = CurrentPayment.transamount;
                DateTime paymentDate = CurrentPayment.transdate;
                StringBuilder body = new StringBuilder();
                string orderType = CurrentOrder.OrderType.ToString();
                string orderNumber = CurrentOrder.ordernumber;
                string agentNAme = CurrentOrder.agentname;
                n_user currentUser = n_user.GetById(RzWin.Context, CurrentOrder.base_mc_user_uid);

                string agentEmail = "ap@sensiblemicro.com";

                List<string> ccList = new List<string>() { "ap@sensiblemicro.com" };

                if (currentUser != null)
                {
                    if (!string.IsNullOrEmpty(currentUser.email_address))
                    {
                        agentEmail = currentUser.email_address.Trim().ToLower();
                        ccList.Add(agentEmail);
                    }
                }


                //Add shipping if Terms Dictate
                if (AlertShippingTeam())
                    ccList.Add("sm_shipping@sensiblemicro.com");


                body.Append("<b>Transaction Details:</b><br />");
                body.Append("Company: " + companyName + "<br />");
                body.Append("Payment Date: " + paymentDate.ToShortDateString() + "<br />");
                body.Append("Invoice Number: " + orderNumber + "<br />");
                body.Append("Payment Amount:" + transAmount.ToString("C") + "<br />");
                body.Append("Terms:" + CurrentOrder.terms + "<br />");
                if (CurrentOrder is ordhed_invoice)
                {
                    ordhed_invoice i = (ordhed_invoice)CurrentOrder;
                    body.Append("Order Total: " + i.ordertotal.ToString("C") + "<br />");
                    body.Append("Open Balance: " + i.outstandingamount.ToString("C") + "<br />");
                    body.Append("Net Profit: " + i.net_profit.ToString("C") + "<br />");

                }


                string subject = "Rz payment posted for " + orderType + "# " + orderNumber;


                nEmailMessage msg = new nEmailMessage();
                msg.IsHTML = true;
                msg.Subject = subject;
                msg.FromAddress = "rz_payments@sensiblemicro.com";
                msg.ToAddress = agentEmail;
                if (ccList.Count > 0)
                    msg.CcRecipients = ccList;

                msg.HTMLBody = body.ToString();
                string error = "";
                msg.SetDefaultServer();
                msg.Send(ref error);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception("Error sending new payment email: " + error);
                //set this to false to avoid re-sending on future saves of this transaction.
                CurrentPayment.sendTransactionAlertEmail = false;
                CurrentPayment.Update(RzWin.Context);

            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
        }

        private bool AlertShippingTeam()
        {
            List<string> exactMatchList = new List<string>()
            {

                 "mastercard","amex", "paypal", "visa"


            };


            string invoiceTerms = CurrentOrder.terms.Trim().ToLower();
            if (string.IsNullOrEmpty(invoiceTerms))
                return false;

            //if matches common credit types
            if (exactMatchList.Contains(invoiceTerms))
                return true;
            //or contains words:
            //"Credit", "Wire"
            if (invoiceTerms.Contains("wire") || invoiceTerms.Contains("credit") || invoiceTerms.Contains("advance"))
                return true;
            return false;



        }
    }
}

