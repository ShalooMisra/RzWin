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
    public partial class view_companyaddress : ViewPlusMenu
    {
        public companyaddress CurrentAddress
        {
            get
            {
                return (companyaddress)GetCurrentObject();
            }
        }
        private Boolean bInhibit = false;

        public view_companyaddress()
        {
            InitializeComponent();
        }
        //Public Override Functions

        public override void CompleteLoad()
        {
            if (UPSWorldship.UseWorldship(RzWin.Context))
                SetStateList();
            base.CompleteLoad();
        }

        public override void CompleteSave()
        {
            if (Tools.Strings.StrExt(ctl_description.zz_Text))
                base.CompleteSave();
            else
                SetAddressLabel();

        }

        //Public Functions
        protected string AddressLabel = "";
        public void PasteAddress()
        {
            try
            {
                CompleteSave();
                CurrentAddress.PasteAddress(ToolsWin.Clipboard.GetClipText());
                CompleteLoad();
            }
            catch { }
        }
        public void CopyAddress()
        {
            try
            {
                CompleteSave();
                CurrentAddress.CopyAddress(RzWin.Context);
            }
            catch { }
        }
        //Private Functions
        private void SetStateList()
        {
            try
            {
                bInhibit = true;
                String country = ctl_adrcountry.GetValue_String();
                switch (country.ToLower().Trim())
                {
                    case "united states":
                        ctl_adrstate.SimpleList = "AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY";
                        break;
                    case "canada":
                        ctl_adrstate.SimpleList = "Alberta|British Columbia|Manitoba|New Brunswick|Newfoundland and Labrador|Northwest Territories|Nova Scotia|Nunavut|Ontario|Prince Edward Island|Quebec|Saskatchewan|Yukon";
                        break;
                    default:
                        ctl_adrstate.SimpleList = "AL|AK|AS|AZ|AR|CA|CO|CT|DC|DE|FL|FM|GA|GU|HI|IA|ID|IL|IN|KS|KY|LA|MD|MA|ME|MH|MI|MN|MP|MS|MO|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|PR|RI|SC|SD|TN|TX|UT|VA|VI|VT|WA|WI|WV|WY";
                        break;
                }
            }
            catch { }
        }
        //Buttons
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            PasteAddress();
        }
        private void cmdCopyAddress_Click(object sender, EventArgs e)
        {
            CopyAddress();
        }
        //Control Events
        private void ctl_adrcountry_DataChanged(GenericEvent e)
        {
            if (bInhibit)
            {
                bInhibit = false;
                return;
            }
            if (UPSWorldship.UseWorldship(RzWin.Context))
                SetStateList();
        }

        private void ctl_defaultbilling_CheckChanged(object sender)
        {
            if (ctl_defaultbilling.zz_CheckValue == true)
            {
                if (ctl_defaultshipping.zz_CheckValue == true)
                {
                    ctl_description.zz_Text = "Shipping/Billing";
                }
                else
                {
                    ctl_description.zz_Text = "Billing";
                }
            }
            else
            {
                if (ctl_defaultshipping.zz_CheckValue == true)
                {
                    ctl_description.zz_Text = "Shipping";
                }
                else
                {
                    ctl_description.zz_Text = "";
                }
            }
        }

        private void ctl_defaultshipping_CheckChanged(object sender)
        {
            if (ctl_defaultshipping.zz_CheckValue == true)
            {
                if (ctl_defaultbilling.zz_CheckValue == true)
                {
                    ctl_description.zz_Text = "Shipping/Billing";
                }
                else
                {
                    ctl_description.zz_Text = "Shipping";
                }
            }
            else
            {
                if (ctl_defaultbilling.zz_CheckValue == true)
                {

                    ctl_description.zz_Text = "Billing";
                }
                else
                {
                    ctl_description.zz_Text = "";
                }
            }
        }

        protected void SetAddressLabel()
        {
            while (!Tools.Strings.StrExt(AddressLabel))
            {
                AddressLabel = RzWin.Context.Leader.AskForString("Please provide a description for this address.");
                if (Tools.Strings.StrExt(AddressLabel))
                {
                    ctl_description.zz_Text = AddressLabel;
                    CompleteSave();
                    CompleteLoad();
                }

                else
                {                    
                    RzWin.Context.Leader.Tell("You must provide a description. Try again.");
                }
            }

        }
    }
}

