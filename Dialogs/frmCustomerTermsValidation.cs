using Rz5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmCustomerTermsValidation : Form
    {
        //commit test
        public company_terms_conditions CurrentTerms;
        private company CurrentCompany;

        public frmCustomerTermsValidation(company_terms_conditions ct = null)
        {

            CurrentCompany = company.GetById(RzWin.Context, ct.company_uid);
            if (CurrentCompany == null)
                throw new Exception("Company cannot be null.");
            CurrentTerms = ct;
            InitializeComponent();
            CompleteLoad();
        }

        public void CompleteLoad()
        {
            lblCompanyName.Text = CurrentCompany.companyname;
            LoadCompanyRequirementsText();
        }

        private void LoadCompanyRequirementsText()
        {

            bool dateCodeResriction = CurrentTerms.has_dc_restriction;
            bool packagingRestriction = CurrentTerms.has_packaging_restriction;
            bool rohsRestriction = CurrentTerms.has_rohs_restriction;
            bool brokerRestriction = CurrentTerms.has_broker_restriction;
            bool cooRestriction = CurrentTerms.has_coo_restriction;
            bool testingRestriction = CurrentTerms.has_testing_restriction;
            bool requiresTraceability = CurrentTerms.requires_traceability;

            string strPackagingRestriction = CurrentTerms.has_packaging_restriction_detail;
            string strDateCodeRestriction = CurrentTerms.has_dc_restriction_detail;
            string strTestingRestriction = CurrentTerms.has_testing_restriction_detail;


            StringBuilder sb = new StringBuilder();
          


            if (dateCodeResriction)
                sb.Append("Date Code Restriction: [" + strDateCodeRestriction + "]" + Environment.NewLine);
            if (packagingRestriction)
                sb.Append("Packaging Restriction: [" + strPackagingRestriction + "]" + Environment.NewLine);
            if (testingRestriction)
                sb.Append("Testing Restriction: [" + strTestingRestriction + "]" + Environment.NewLine);
            if (rohsRestriction)
                sb.Append("RoHS Restriction" + Environment.NewLine);
            if (brokerRestriction)
                sb.Append("Broker Restriction" + Environment.NewLine);
            if (cooRestriction)
                sb.Append("COO Restriction" + Environment.NewLine);
            if (requiresTraceability)
                sb.Append("Requires traceability");


            
            //if (!string.IsNullOrEmpty(sb.ToString()))
            txtTermsRestrictions.Text = sb.ToString();

            if (!string.IsNullOrEmpty(CurrentCompany.description))
                txtDescription.Text = CurrentCompany.description;


        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Form f = (Form)this.TopLevelControl;
            f.DialogResult = DialogResult.OK;
            f.Close();
        }
    }
}
