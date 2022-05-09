using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;

namespace Rz5
{
    public partial class frmUPSWorldShip : Form
    {
        //Public Variables
        public ordhed Order = null;
        public UPSObject UPS = null;
        //Private Variables
        private Boolean bInhibit = false;

        //Constructors
        public frmUPSWorldShip()
        {
            InitializeComponent();
        }
        //Public Functions
        public Boolean CompleteLoad(ordhed o)
        {
            Order = o;
            if (Order == null)
                return false;
            SetStateList();
            LoadOrder();
            DoResize();
            return true;
        }
        public void DoResize()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    Type t = c.GetType();
                    if (t.FullName.ToLower().Contains("nedit"))
                    {
                        nEdit e = null;
                        try { e = (nEdit)c; }
                        catch { }
                        if (e != null)
                            e.DoResize();
                    }
                }
            }
            catch { }
        }
        //Private Functions
        private void LoadOrder()
        {
            try
            {
                ctlCompany.SetValue(Order.companyname);
                ctlAttention.SetValue(Order.contactname);
                ctlPhone.SetValue(Order.primaryphone);
                ctlFax.SetValue(Order.primaryfax);
                ctlEmail.SetValue(Order.primaryemailaddress);
                ctlAccount.SetValue(Order.shippingaccount);
                ctlResidential.SetValue(false);
                ctlServiceType.SetValue(Order.shipvia.Replace("UPS-", "").Trim());
                ctlPackages.SetValue(1);
                ctlWeight.SetValue(0);
                ctlRef1.SetValue(Order.orderreference);
                if (Tools.Strings.StrExt(ctlAccount.GetValue_String()))
                    ctlBillingOption.SetValue("Bill Receiver");
                else
                    ctlBillingOption.SetValue("Bill Shipper");
                company c = Order.CompanyVar.RefGet(RzWin.Context);
                if (c != null)
                {
                    companyaddress a = c.GetPrimaryShippingAddress(RzWin.Context);
                    ctlAddress1.SetValue(a.line1);
                    ctlAddress2.SetValue(a.line2);
                    ctlAddress3.SetValue(a.line3);
                    ctlCountry.SetValue(a.adrcountry);
                    ctlPostalCode.SetValue(a.adrzip);
                    ctlCity.SetValue(a.adrcity);
                    ctlState.SetValue(a.adrstate);
                }
            }
            catch { }
        }
        private void DoXMLSend()
        {
            DoXMLSend(RzWin.Form.TheContextNM);
        }
        private void DoXMLSend(ContextNM x)
        {
            if (!Tools.Strings.StrExt(UPSWorldship.XMLPath(RzWin.Context)))
            {
                x.TheLeader.TellTemp("You need to set the XML path before attempting a send.");
                cmdSettings_Click(new object(), new EventArgs());
                return;
            }
            UPS = AssymbleUPSObject();
        }
        private UPSObject AssymbleUPSObject()
        {
            UPSObject o = new UPSObject();
            try
            {
                o.OrderID = Order.unique_id;
                o.CompanyOrName = ctlCompany.GetValue_String();
                if (!Tools.Strings.StrExt(ctlAttention.GetValue_String()))
                    o.Attention = o.CompanyOrName;
                else
                    o.Attention = ctlAttention.GetValue_String();
                o.Address1 = ctlAddress1.GetValue_String();
                o.Address2 = ctlAddress2.GetValue_String();
                o.Address3 = ctlAddress3.GetValue_String();
                o.CountryTerritory = UPSWorldship.TranslateCountryToCode(ctlCountry.GetValue_String());
                o.PostalCode = ctlPostalCode.GetValue_String();
                o.CityOrTown = ctlCity.GetValue_String();
                o.StateProvinceCounty = UPSWorldship.TranslateStateToCode(ctlCountry.GetValue_String(), ctlState.GetValue_String());
                o.Telephone = ctlPhone.GetValue_String();
                o.FaxNumber = ctlFax.GetValue_String();
                o.EmailAddress = ctlEmail.GetValue_String();
                o.ReceiverUpsAccountNumber = ctlAccount.GetValue_String();
                o.ResidentialIndicator = ctlResidential.GetValue_Int32().ToString();
                o.ServiceType = UPSWorldship.TranslateShipViaToCode(ctlServiceType.GetValue_String());
                o.NumberOfPackages = ctlPackages.GetValue_Integer().ToString();
                Double d = ctlWeight.GetValue_Double();
                if (d <= 0)
                    return null;
                o.ShipmentActualWeight = d.ToString();
                o.DescriptionOfGoods = ctlDescription.GetValue_String();
                o.Reference1 = ctlRef1.GetValue_String();
                o.Reference2 = ctlRef2.GetValue_String();
                o.Reference3 = ctlRef3.GetValue_String();
                o.BillingOption = UPSWorldship.TranslateBillingToCode(ctlBillingOption.GetValue_String());
            }
            catch { }
            return o;
        }
        private void UpdateCompanyInformation()
        {
            if (!RzWin.Leader.AskYesNo("Are you sure you want to update this information back to the company account?"))
                return;
            try
            {
                company c = Order.CompanyVar.RefGet(RzWin.Context);
                if (c == null)
                {
                    RzWin.Leader.Tell("The company could not be found in the system. Please try this shipment again.");
                    return;
                }
                c.primaryphone = ctlPhone.GetValue_String();
                c.primaryfax = ctlFax.GetValue_String();
                c.primaryemailaddress = ctlEmail.GetValue_String();
                c.Update(RzWin.Context);
                companyaddress a = c.GetPrimaryShippingAddress(RzWin.Context);
                if (a == null)
                {
                    a = companyaddress.New(RzWin.Context);
                    a.base_company_uid = c.unique_id;
                    a.Insert(RzWin.Context);
                }
                a.line1 = ctlAddress1.GetValue_String();
                a.line2 = ctlAddress2.GetValue_String();
                a.line3 = ctlAddress3.GetValue_String();
                a.adrcountry = ctlCountry.GetValue_String();
                a.adrzip = ctlPostalCode.GetValue_String();
                a.adrcity = ctlCity.GetValue_String();
                a.adrstate = ctlState.GetValue_String();
                a.Update(RzWin.Context);
                RzWin.Leader.Tell("Done.");
            }
            catch { }
        }
        private void SetStateList()
        {
            try
            {
                bInhibit = true;
                String country = ctlCountry.GetValue_String();
                switch (country.ToLower().Trim())
                {
                    case "united states":
                        ctlState.SimpleList = "AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY";
                        break;
                    case "canada":
                        ctlState.SimpleList = "Alberta|British Columbia|Manitoba|New Brunswick|Newfoundland and Labrador|Northwest Territories|Nova Scotia|Nunavut|Ontario|Prince Edward Island|Quebec|Saskatchewan|Yukon";
                        break;
                    default:
                        ctlState.SimpleList = "AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY";
                        break;
                }
            }
            catch { }
        }
        //Buttons
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            DoXMLSend();
            this.Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdSettings_Click(object sender, EventArgs e)
        {
            frmWorldShipSettings xForm = new frmWorldShipSettings();
            xForm.CompleteLoad();
            xForm.ShowDialog();
        }
        private void cmdUpdateCompany_Click(object sender, EventArgs e)
        {
            UpdateCompanyInformation();
        }
        //Control Events
        private void frmUPSWorldShip_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void ctlState_DataChanged(GenericEvent e)
        {
            if (bInhibit)
            {
                bInhibit = false;
                return;
            }
            SetStateList();
        }
    }
}
