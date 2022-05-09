
using HubspotApis;
using Rz5;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;


namespace NewMethod
{
    public partial class frmManageHubspot : Form
    {
        public frmManageHubspot()
        {
            InitializeComponent();
        }
        //Event Handler to update ParentForm
        public event EventHandler HubspotUpdated;

        //HubspotApis.HubspotApi.Company TheHubspotCompany;
        object TheRzObject;
        string TheHubspotObjectURL;
        HubspotApi.Deal TheHubspotDeal;       

        public void CompleteLoad(ContextRz x, object o)
        {
            TheRzObject = o;

            string objectType = TheRzObject.GetType().ToString().ToLower();
            switch (objectType)
            {
                case "rz5.dealheader":
                case "rz5.ordhed_sales":
                case "rz5.ordhed_quote":
                case "rz5.ordhed_invoice":
                    LoadDealSettings(x, o, objectType);
                    break;
                case "rz5.company":
                    LoadCompanySettings(x, (company)o);
                    break;
            }
        }



        private void LoadDealSettings(ContextRz x, object o, string objectType)
        {

            TheHubspotDeal = LoadHubspotDeal(x, o, objectType);
            txtObjectID.Enabled = x.TheSysRz.ThePermitLogic.CheckPermit(x, Permissions.ThePermits.CanManageHubspot, x.xUser);
            lblHSObjectTypeLabel.Text = "Current Deal ID: ";
            llHSObjectName.Text = "<not assoicated>";
            txtObjectID.Text = string.Empty;

            if (TheHubspotDeal != null)
            {
                TheHubspotObjectURL = @"https://app.hubspot.com/contacts/1878634/deal/" + TheHubspotDeal.dealId + "/";
                llHSObjectName.Text = TheHubspotDeal.properties.Where(w => w.Key == "dealname").Select(s => s.Value.value).FirstOrDefault();
                lblHSObjectIDLabel.Text = "Deal ID: ";
                llHSObjectName.Text = TheHubspotDeal.dealId.ToString();
            }


        }

        private HubspotApi.Deal LoadHubspotDeal(ContextRz x, object o, string objectType)
        {
            long hubID = 0;
            switch (objectType)
            {
                case "rz5.dealheader":
                    {
                        dealheader d = (dealheader)o;
                        hubID = d.hubspot_deal_id;
                        break;
                    }
                case "rz5.ordhed_sales":
                case "rz5.ordhed_quote":
                case "rz5.ordhed_invoice":
                    {
                        ordhed oh = (ordhed)o;
                        hubID = oh.hubspot_deal_id;
                        break;
                    }


            }

            if (hubID <= 0)
                return null;
            return HubspotApi.Deals.GetDealByID(hubID);
        }

       

        private void LoadCompanySettings(ContextRz x, company c)
        {
            txtObjectID.Enabled = x.TheSysRz.ThePermitLogic.CheckPermit(x, Permissions.ThePermits.CanManageHubspot, x.xUser);
            lblHSObjectTypeLabel.Text = "Current Company: ";
            llHSObjectName.Text = "<not assoicated>";
            txtObjectID.Text = string.Empty;
            HubspotApi.Company TheHubspotCompany = null;
            if (c != null)
            {
                if ((c.hubspot_company_id > 0))
                {
                    TheHubspotCompany = HubspotApi.Companies.GetCompanyByID(c.hubspot_company_id);
                }

                if (TheHubspotCompany != null)
                {
                    long hsCompanyID = TheHubspotCompany.companyId;
                    TheHubspotObjectURL = @"https://app.hubspot.com/contacts/1878634/company/" + hsCompanyID + "/";

                    txtObjectID.Text = TheHubspotCompany.companyId.ToString();


                    lblHSObjectIDLabel.Text = "Company : ";
                    llHSObjectName.Text = TheHubspotCompany.Properties.Where(w => w.Key == "name").Select(s => s.Value.value).FirstOrDefault();
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DeleteAssociation();

            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }

            Close();
        }

        private void DeleteAssociation()
        {
            if (TheRzObject != null)
                if (RzWin.Context.Leader.AreYouSure("delete the Hubspot association?"))
                {
                    string objType = TheRzObject.GetType().ToString().ToLower();
                    switch (objType)
                    {
                        case "rz5.dealheader":
                            {
                                dealheader TheRzDealheader = (dealheader)TheRzObject;
                                TheRzDealheader.hubspot_deal_id = 0;
                                RzWin.Context.Update(TheRzDealheader);
                                TheRzDealheader = null;
                                break;
                            }

                        case "rz5.ordhed_sales":
                            {
                                ordhed TheRzOrdhed = (ordhed)TheRzObject;
                                TheRzOrdhed.hubspot_deal_id = 0;
                                RzWin.Context.Update(TheRzOrdhed);
                                TheRzOrdhed = null;
                                break;
                            }
                        case "rz5.company":
                            {
                                company TheRzCompany = (company)TheRzObject;
                                TheRzCompany.hubspot_company_id = 0;
                                RzWin.Context.Update(TheRzCompany);
                                TheRzCompany = null;

                                break;
                            }                           
                    }
                }

            CompleteLoad(RzWin.Context, TheRzObject);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CompleteSave();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }


        }

        private void CompleteSave()
        {
            string input = Tools.Strings.SanitizeInput(txtObjectID.Text);
            long newHubID = 0;
            if (!long.TryParse(input, out newHubID))
            {
                RzWin.Leader.Error("'" + txtObjectID.Text + "' is not a valid Hubspot company ID.");
                return;
            }
            else
            {
                string objType = TheRzObject.GetType().ToString().ToLower();
                switch (objType)
                {
                    case "rz5.company":
                        {
                            SaveHubspotCompany(newHubID);
                            break;
                        }
                    case "rz5.ordhed_sales":
                    case "rz5.dealheader":
                        {
                            SaveHubspotDeal(newHubID);
                            break;
                        }
                }
            }
        }

        private void SaveHubspotDeal(long newHubID)
        {

            TheHubspotDeal = HubspotApi.Deals.GetDealByID(newHubID);
            string dealName;
            long existingHubID = 0;
            ordhed o = null;
            dealheader d = null;
            if (TheHubspotDeal.dealId <= 0)
            {
                RzWin.Context.Leader.Error("Hubpsot API did not find a deal associated with ID: " + newHubID);
                TheHubspotDeal = null;
                return;
            }

            string objType = TheRzObject.GetType().ToString().ToLower();
            switch (objType)
            {

                case "rz5.ordhed_sales":
                    {
                        o = (ordhed)TheRzObject;
                        existingHubID = o.hubspot_deal_id;
                        break;
                    }
                case "rz5.dealheader":
                    {
                        d = (dealheader)TheRzObject;
                        existingHubID = d.hubspot_deal_id;
                        break;
                    }

            }


            if (existingHubID == newHubID)
                return;

            
                string hsDealNAme = TheHubspotDeal.properties.Where(w => w.Key == "dealname").Select(s => s.Value.value).FirstOrDefault();
                if (RzWin.Context.Leader.AreYouSure("associate this object with the Hubspot DealID: " + newHubID + "?"))
                {
                    if(o != null)
                    {
                        o.hubspot_deal_id = TheHubspotDeal.dealId;
                        RzWin.Context.Update(o);                   
                    }
                    else if (d != null)
                    {
                        d.hubspot_deal_id = TheHubspotDeal.dealId;
                        RzWin.Context.Update(d);
                    }                   

                    CompleteLoad(RzWin.Context,TheRzObject);
                }

            
        }

        

        private void SaveHubspotCompany(long hsID)
        {
            HubspotApi.Company TheHubspotCompany = HubspotApi.Companies.GetCompanyByID(hsID);
            if (TheHubspotCompany == null || TheHubspotCompany.companyId == 0)
            {
                RzWin.Context.Leader.Error("Hubpsot API did not find a company associated with ID: " + hsID);
                return;
            }

            //If Rz Company is already set to the provided ID, do nothing.
            company TheRzCompany = (company)TheRzObject;
            if (TheRzCompany.hubspot_company_id.ToString() == txtObjectID.Text)
                return;

            if (TheHubspotCompany != null)
            {
                string hsCompanyNAme = TheHubspotCompany.Properties.Where(w => w.Key == "name").Select(s => s.Value.value).FirstOrDefault();
                if (RzWin.Context.Leader.AreYouSure("associate this company with the Hubspot Company: " + hsCompanyNAme + " (ID:" + TheHubspotCompany.companyId + ")"))
                {
                    if (TheRzCompany.hubspot_company_id != TheHubspotCompany.companyId)
                    {
                        TheRzCompany.hubspot_company_id = TheHubspotCompany.companyId;
                        RzWin.Context.Update(TheRzCompany);
                    }
                    CompleteLoad(RzWin.Context,TheRzCompany);
                }

            }
        }

        private void llHSObjectName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (!string.IsNullOrEmpty(TheHubspotObjectURL))
            {
                ProcessStartInfo hsLink = new ProcessStartInfo(TheHubspotObjectURL);
                Process.Start(hsLink);
            }

        }


    }
}
