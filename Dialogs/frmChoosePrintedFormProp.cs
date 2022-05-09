using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class frmChoosePrintedFormProp : Form
    {
        //Public Functions
        public string TheProp = "";
        //Private Variables
        private ContextNM TheContext;
        private string TheType = "";

        //Constructors
        public frmChoosePrintedFormProp()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(ContextNM x, string type)
        {
            TheContext = x;
            TheType = type;
            lblType.Text = TheType + " Props";
            LoadLV();
        }
        //Private Functions
        private void GetSelectedProp()
        {
            RzWin.Context.Reorg();
            //TheProp = "";
            //if (lv.SelectedItems == null)
            //    return;
            //if (lv.SelectedItems.Count <= 0)
            //    return;
            //n_prop p = (n_prop)lv.SelectedItems[0].Tag;
            //if (p == null)
            //    return;
            //TheProp = "[" + TheType.ToUpper() + "." + p.name.ToUpper() + "]";
        }
        private void LoadLV()
        {
            //there may be a more elegant way to write this
            RzWin.Context.Reorg();

            //if (TheContext == null)
            //    return;
            //List<CoreVarValAttribute> attrs;
            //Dictionary<String, CoreVarValAttribute> sl = new Dictionary<string, CoreVarValAttribute>();
            //try
            //{
            //    switch (TheType.ToLower())
            //    {
            //        case "agent":
            //            attrs = TheContext.Sys.VarVals("n_user");
            //            foreach (CoreVarValAttribute p in attrs)
            //            {
            //                if (Tools.Strings.StrCmp("name", p.Name))
            //                    sl.Add(p.Name, p);
            //                else if (Tools.Strings.StrCmp("phone", p.Name))
            //                    sl.Add(p.Name, p);
            //                else if (Tools.Strings.StrCmp("phone_ext", p.Name))
            //                    sl.Add(p.Name, p);
            //                else if (Tools.Strings.StrCmp("email_address", p.Name))
            //                    sl.Add(p.Name, p);
            //                else if (Tools.Strings.StrCmp("fax_number", p.Name))
            //                    sl.Add(p.Name, p);
            //            }
            //            break;
            //        default:
            //            attrs = TheContext.Sys.VarVals("ordhed");
            //            foreach (CoreVarValAttribute p in attrs)
            //            {
            //                p = (n_prop)d.Value;
            //                if (Tools.Strings.StrCmp("ordernumber", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("ordertype", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("freightbilling", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("shipvia", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("terms", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("shippingamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("handlingamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("taxamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("billingaddress", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("shippingaddress", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("specialinstructionshipping", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("specialinstructionsbilling", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("packinginfo", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("trackingnumber", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("agentname", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("contactname", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("primaryphone", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("primaryfax", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("primaryemailaddress", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("companyname", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("orderdate", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("orderreference", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("comment", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("internalcomment", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("dockdate", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("shippingaccount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("country", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("ordertotal", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("grossamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("costamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("profitamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("outstandingamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("printcomment", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("requireddate", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("soreference", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("rmareference", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("orderfob", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("buyername", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("totalvalue", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("shipdate", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("alternatetracking", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("shippingdate", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("handlingdate", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("subtract_1", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("subtract_2", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("subtract_3", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("charged_amount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("orderamount", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("nameoncard", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("creditcardtype", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("expiration_month", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("expiration_year", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("security_code", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("cardbillingaddr", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("cardbillingzip", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("creditcardnumber", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("drop_ship_address", p.name))
            //                    sl.Add(p.name, p);
            //                else if (Tools.Strings.StrCmp("securitycode", p.name))
            //                    sl.Add(p.name, p);
            //            }
            //            break;
            //    }
            //    LoadLV(sl);
            //}
            //catch { }
        }
        private void LoadLV(SortedList s)
        {
            RzWin.Context.Reorg();
            //lv.Items.Clear();
            //if (s == null)
            //    return;
            //lv.SuspendLayout();
            //try
            //{
            //    n_prop p;
            //    foreach (DictionaryEntry d in s)
            //    {
            //        if (!(d.Value is n_prop))
            //            continue;
            //        p = (n_prop)d.Value;
            //        ListViewItem xLst = lv.Items.Add(p.property_tag);
            //        xLst.Tag = d.Value;
            //    }
            //}
            //catch { }
            //lv.SuspendLayout();
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheProp = "";
            Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            GetSelectedProp();
            Close();
        }
        //Control Events
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            GetSelectedProp();
            Close();
        }
    }
}
