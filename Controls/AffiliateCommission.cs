using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin.Controls
{
    public partial class AffiliateCommission : UserControl
    {
        object CurrentObject;


        public AffiliateCommission()
        {
            InitializeComponent();
        }


        //Load Methods
        public void CompleteLoad(object o)
        {
            CurrentObject = o;
            LoadAffiliate();
        }

        private void LoadAffiliate()
        {
            string affiliateID = "N/A";


            if (CurrentObject is orddet_quote)
                affiliateID = ((orddet_quote)CurrentObject).affiliate_id;

            else if (CurrentObject is orddet_line)
                affiliateID = ((orddet_line)CurrentObject).affiliate_id;

            else if (CurrentObject is ordhed_quote)
                affiliateID = ((orddet_quote)CurrentObject).affiliate_id;

            //else if (CurrentObject is ordhed_sales)
            //    affiliateID = ((ordhed_sales)CurrentObject).affiliate_id;

            //else if (CurrentObject is ordhed_invoice)
            //    affiliateID = ((ordhed_invoice)CurrentObject).affiliate_id;

            if (!string.IsNullOrEmpty(affiliateID))
                ctl_affiliateID.SetValue(affiliateID);

        }



        //Save Methods
        private void btnSaveAffiliateID_Click(object sender, EventArgs e)
        {
            SaveAffiliaeID();
            LoadAffiliate();
        }

        private void SaveAffiliaeID()
        {
            if (CurrentObject == null)
                throw new Exception("Error: Commissionable object is null.");

            string sanitizedInput = Tools.Strings.SanitizeInput(ctl_affiliateID.GetValue_String()).ToLower();
            if (!Tools.Email.IsEmailAddress(sanitizedInput))
                throw new Exception("Affiliate ID must be an email address.");


            if (CurrentObject is orddet_quote)
                SetAffiliateID_Orddet(RzWin.Context, CurrentObject, sanitizedInput);

            else if (CurrentObject is orddet_line)
                SetAffiliateID_Orddet(RzWin.Context, CurrentObject, sanitizedInput);

            else if (CurrentObject is ordhed_quote)
            {
                List<orddet> quoteLines = ((ordhed_quote)CurrentObject).DetailsList(RzWin.Context);
                foreach (orddet od in quoteLines)
                    SetAffiliateID_Orddet(RzWin.Context, od, sanitizedInput);


            }
            else if (CurrentObject is ordhed_sales)
            {
                List<orddet> saleLines = ((ordhed_sales)CurrentObject).DetailsList(RzWin.Context);
                foreach (orddet od in saleLines)
                    SetAffiliateID_Orddet(RzWin.Context, od, sanitizedInput);

            }
            else if (CurrentObject is ordhed_invoice)
            {
                List<orddet> saleLines = ((ordhed_invoice)CurrentObject).DetailsList(RzWin.Context);
                foreach (orddet od in saleLines)
                    SetAffiliateID_Orddet(RzWin.Context, od, sanitizedInput);
            }



        }

        private void SetAffiliateID_Orddet(ContextRz x, object o, string affiliateID)
        {
            if (o is orddet_quote)
            {
                orddet_quote q = (orddet_quote)o;
                q.affiliate_id = affiliateID;
                q.Update(x);
            }
            else if (o is orddet_line)
            {
                orddet_line l = (orddet_line)o;
                l.affiliate_id = affiliateID;
                l.Update(x);
            }
        }



        //Delete Methods
        private void btnDeleteAffiliateID_Click(object sender, EventArgs e)
        {
            DeleteAffiliateID(RzWin.Context);
            LoadAffiliate();
        }

        private void DeleteAffiliateID(ContextRz x)
        {
            if (CurrentObject is orddet_quote || CurrentObject is orddet_line)
                DeleteAffiliateIDOrddet(x, CurrentObject);


            else if (CurrentObject is ordhed_quote)
            {
                List<orddet> quoteLines = ((ordhed_quote)CurrentObject).DetailsList(RzWin.Context);
                foreach (orddet od in quoteLines)
                    DeleteAffiliateIDOrddet(x, od);


            }
            else if (CurrentObject is ordhed_sales)
            {

                List<orddet> saleLines = ((ordhed_sales)CurrentObject).DetailsList(RzWin.Context);
                foreach (orddet od in saleLines)
                    DeleteAffiliateIDOrddet(x, od);
            }
            else if (CurrentObject is ordhed_invoice)
            {
                List<orddet>saleLines = ((ordhed_invoice)CurrentObject).DetailsList(RzWin.Context);
                foreach (orddet od in saleLines)
                    DeleteAffiliateIDOrddet(x, od);
            }
            else
                throw new Exception("Invalid Affiliate Object type.");
        }

        private void DeleteAffiliateIDOrddet(ContextRz x, object currentObject)
        {
            if (CurrentObject is orddet_quote)
            {
                ((orddet_quote)CurrentObject).affiliate_id = null;
                ((orddet_quote)CurrentObject).Update(x);
            }
            else if (CurrentObject is orddet_line)
            {
                ((orddet_line)CurrentObject).affiliate_id = null;
                ((orddet_line)CurrentObject).Update(x);
            }

        }
    }
}
