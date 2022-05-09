using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Focus
{
    public partial class AdvanceShipmentNotification : UserControl, IFocusControl
    {
        public AdvanceShipmentNotification()
        {
            InitializeComponent();
        }

        ordhed TheInvoice;
        company TheCompany;
        companycontact TheContact;

        public void CompleteLoad(focus_item i)
        {
            try
            {
                TheInvoice = (ordhed_invoice)RzWin.Context.GetById("ordhed_invoice", i.extra_info);
                TheCompany = TheInvoice.CompanyVar.RefGet(RzWin.Context);
                TheContact = TheInvoice.ContactVar.RefGet(RzWin.Context);
            }
            catch { }

            if (TheInvoice == null)
            {
                lblCaption.Text = "This order was not found.";
                lblOrder.Text = "This order was not found.";
                cmdASN.Enabled = false;
            }
            else
            {
                lblCaption.Text = "ASN Reminder for " + TheInvoice.ToString();
                lblOrder.Text = "View " + TheInvoice.ToString();
                cmdASN.Enabled = true;
            }

            if( TheCompany == null )
                lblCompany.Text = "";
            else
                lblCompany.Text = "View " + TheCompany.companyname;

            if( TheContact == null )
                lblContact.Text = "";
            else
                lblContact.Text = "View " + TheContact.contactname;
        }

        public void LimitControls()
        {

        }

        public void CompleteSave()
        {
            
        }

        private void lblOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(TheInvoice);
        }

        private void lblCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(TheCompany);
        }

        private void lblContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(TheContact);
        }

        private void cmdASN_Click(object sender, EventArgs e)
        {
            ((ordhed_invoice)TheInvoice).CreateASNEmail(RzWin.Context);
        }
    }
}
