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
    public partial class ShipmentConfirmation : UserControl, IFocusControl
    {
        public ShipmentConfirmation()
        {
            InitializeComponent();
        }
        ContextNM TheContext
        {
            get { return RzWin.Context; }
        }
        ordhed TheSale;
        company TheCompany;
        companycontact TheContact;

        public void CompleteLoad(focus_item i)
        {
            try
            {
                TheSale = (ordhed_sales)TheContext.GetById("ordhed_sales", i.extra_info);
                TheCompany = TheSale.CompanyVar.RefGet(RzWin.Context);
                TheContact = TheSale.ContactVar.RefGet(RzWin.Context);
            }
            catch { }

            if (TheSale == null)
            {
                lblCaption.Text = "This order was not found.";
                lblOrder.Text = "This order was not found.";
                cmdASN.Enabled = false;
            }
            else
            {
                lblCaption.Text = "Shipment Confirmation for " + TheSale.ToString();
                lblOrder.Text = "View " + TheSale.ToString();
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
            TheContext.Show(TheSale);
        }

        private void lblCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TheContext.Show(TheCompany);
        }

        private void lblContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TheContext.Show(TheContact);
        }

        private void cmdASN_Click(object sender, EventArgs e)
        {
            TheSale.legacycontact = nTools.Replace(TheSale.legacycontact, "ConfirmShip", "");
            TheSale.Update(RzWin.Context);

            RzWin.Logic.NotifyWarehouse(RzWin.Context, TheSale, TheSale.ToString() + " Confirmed for shipment", TheSale.ToString() + " confirmed for shipment");
            cmdASN.Enabled = false;
            cmdASN.Text = "Shipment Confirmed.";
        }
    }
}
