using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class CompanyImport : UserControl, ICompleteLoad
    {
        //Public Variables
        SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }
        //Private Variables
        private String SelectedSource = "";

        //Constructors
        public CompanyImport()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            LoadView();
            DoResize();
        }
        public void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height;

                dv.Left = gb.Right;
                dv.Top = 0;
                dv.Height = this.ClientRectangle.Height;
                dv.Width = this.ClientRectangle.Width - dv.Left;
            }
            catch (Exception)
            { }

        }
        //Private Functions
        private void LoadView()
        {
            //if (dv.xSys == null)
            //{
                dv.CompleteLoad();
                dv.SetAcceptCaption("Import These Companies");
                dv.AddCommonField("companyname", "Company Name", "name", true);
                dv.AddCommonField("primarycontact", "Full Contact Name", "contactname|attn");
                dv.AddCommonField("primaryphone", "Phone", "phone");
                dv.AddCommonField("primaryfax", "Fax", "fax");
                dv.AddCommonField("primaryemailaddress", "Email", "email");
                dv.AddCommonField("companycode", "System ID", "custid");

                dv.AddExtraField("extra_billing_line1", "Billing Address - Line 1", "billaddr1");
                dv.AddExtraField("extra_billing_line2", "Billing Address - Line 2", "billaddr2");
                dv.AddExtraField("extra_billing_city", "Billing City", "billcity");
                dv.AddExtraField("extra_billing_state", "Billing State", "billstate");
                dv.AddExtraField("extra_billing_zip", "Billing Zipcode", "billzip");
                dv.AddExtraField("extra_billing_country", "Billing Country", "billcountry");

                dv.AddExtraField("extra_shipping_line1", "Shipping Address - Line 1", "addr1");
                dv.AddExtraField("extra_shipping_line2", "Shipping Address - Line 2", "addr2");
                dv.AddExtraField("extra_shipping_city", "Shipping City", "city");
                dv.AddExtraField("extra_shipping_state", "Shipping State", "state");
                dv.AddExtraField("extra_shipping_zip", "Shipping Zipcode", "zip");
                dv.AddExtraField("extra_shipping_country", "Shipping Country", "country");

                dv.AddExtraField("extra_contact_line1", "Contact Address - Line 1");
                dv.AddExtraField("extra_contact_line2", "Contact Address - Line 2");
                dv.AddExtraField("extra_contact_city", "Contact City");
                dv.AddExtraField("extra_contact_state", "Contact State");
                dv.AddExtraField("extra_contact_zip", "Contact Zipcode");
                dv.AddExtraField("extra_contact_country", "Contact Country");

                dv.AddExtraField("extra_firstname", "Contact First Name", "firstname|fname");
                dv.AddExtraField("extra_lastname", "Contact Last Name", "contactlastname|lname");
                dv.AddExtraField("extra_contact_title", "Contact Title", "title");
                dv.AddExtraField("extra_contact_phone", "Contact Phone");
                dv.AddExtraField("extra_contact_phone2", "Contact Phone 2");
                dv.AddExtraField("extra_contact_phone3", "Contact Phone 3");
                dv.AddExtraField("extra_contact_phone4", "Contact Phone 4");
                dv.AddExtraField("extra_contact_fax", "Contact Fax");
                dv.AddExtraField("extra_contact_id", "Contact ID", "", false, FieldType.Int32);

                dv.AddExtraField("user_code", "User Code", "");

                dv.SetClass("company");
            //}
            dv.Clear();
        }
        private void RunImport()
        {
            if (!dv.CurrentTable.HasColumnField("companyname"))
            {
                RzWin.Leader.Tell("Please match the company name column before continuing.");
                return;
            }
            if (!RzWin.Leader.AreYouSure("import these " + Tools.Number.LongFormat(dv.Count) + " companies"))
                return;
            SelectedSource = ctlSource.GetValue_String();
            if (!Tools.Strings.StrExt(SelectedSource))
            {
                RzWin.Leader.Tell("Please enter a 'Source' for this import before continuing.");
                return;
            }
            Dictionary<string, string> d = new Dictionary<string, string>();
            nDataColumn dupe = null;
            foreach (nDataColumn cc in dv.CurrentTable.Columns)
            {
                if (cc.p == null)
                    continue;
                try { d.Add(cc.p.Name, cc.p.Name); }
                catch { dupe = cc; }
            }
            if (dupe != null)
            {
                if (dv.CurrentTable.Columns.Count != d.Count)
                {
                    RzWin.Leader.Tell("Duplicate column assignment detected! - " + dupe.p.Name);
                    return;
                }
            }
            dv.SetStatus("Importing...");
            dv.ShowThrobber();
            bgImport.RunWorkerAsync();
        }
        private int ImportCompanies()
        {
            String s = "";
            if (dv.CurrentTable.HasColumnField("user_code"))
                s = "user_code";
            return company.Import(RzWin.Context, dv.CurrentTable, s, SelectedSource);
        }
        //DataView Events
        private void dv_Accept()
        {
            RunImport();
        }
        //Background Workers
        private void bgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ImportCompanies();
        }
        private void bgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dv.HideThrobber();
            dv.SetStatus("Ready.");
        }
        //Control Events
        private void CompanyImport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
