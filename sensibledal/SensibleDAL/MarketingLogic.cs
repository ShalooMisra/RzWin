using HubspotApis;
using SensibleDAL.dbml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensibleDAL
{
    public class MarketingLogic
    {
        public static DataTable LoadRzHubspotCompanyActivity(DateTime startDate, int maxCompanies = 0)
        {
            DataTable ret = GetData(startDate, maxCompanies);
            return ret;
        }

        private static DataTable GetData(DateTime startDate, int maxCompanies)
        {
            //Rolling Last 3 Years Customers 
            DateTime threeYearsAgo = DateTime.Today.AddYears(-3);
            //Generate the Datatable Columns
            DataTable ret = GenerateDatatable();
            using (RzDataContext rdc = new RzDataContext())
            {
                //having at least 1 sale in last 3 years where invoices > 1                
                List<string> customerIDs = rdc.orddet_lines.Where(w => w.seller_name != "Phil Scott" && w.date_created.Value >= startDate && (w.orderid_invoice ?? "").Length > 0).Select(s => s.customer_uid).Distinct().ToList();
                List<company> customers = rdc.companies.Where(w => customerIDs.Contains(w.unique_id)).ToList();

                if (maxCompanies > 0)
                    customers = customers.Take(maxCompanies).ToList();


                foreach (company c in customers)
                {
                    //RzData
                    string RzCompanyName = c.companyname;
                    string RzCompanyID = c.unique_id;
                    string RzWebsiteUrl = c.primarywebaddress ?? "";
                    long RzHubspotID = c.hubspot_company_id ?? 0;
                    string RzAgentName = c.agentname;
                    string RzAgendID = c.base_mc_user_uid;
                    string RzTotalSales = rdc.ordhed_invoices.Where(w => w.base_company_uid == c.unique_id).Sum(s => s.ordertotal ?? 0).ToString("C");
                    DateTime RzLastBatchDate = rdc.dealheaders.Where(w => w.customer_uid == c.unique_id).Max(s => s.date_created) ?? DateTime.MinValue;
                    DateTime RzLastQuoteDate = rdc.ordhed_quotes.Where(w => w.base_company_uid == c.unique_id).Max(s => s.date_created) ?? DateTime.MinValue;
                    DateTime RzLastInvoiceDate = rdc.ordhed_invoices.Where(w => w.base_company_uid == c.unique_id).Max(s => s.date_created) ?? DateTime.MinValue;
                    string RzIndustrySegment = c.industry_segment ?? "Unknown";
                    //Hubspot Data
                    string HubspotAnnualRevenue = "Unknown";
                    string HubspotOwnerName = "N/A";
                    long HubspotOwnerID = 0;
                    string HubspotLastContactDate = "Unknown";
                    string HubspotLastContact = "Unknown";
                    string HubspotWebsiteUrl = "";
                    //OTher Data
                    string companyWebSite = "Unknown";
                    //Hubspot Company
                    if (c.hubspot_company_id > 0)
                    {

                        HubspotApi.Company hsCompany = HubspotApi.Companies.GetCompanyByID((long)c.hubspot_company_id);
                        if (hsCompany != null)
                            if (hsCompany.Properties != null)
                                if (hsCompany.Properties.ContainsKey("annualrevenue"))
                                {
                                    string strAnnualRev = hsCompany.Properties.Where(w => w.Key == "annualrevenue").Select(s => s.Value.value ?? HubspotAnnualRevenue).FirstOrDefault();
                                    double dblAnnualRev = 0;
                                    if (double.TryParse(strAnnualRev, out dblAnnualRev))
                                        HubspotAnnualRevenue = dblAnnualRev.ToString("C");

                                    //Hubspot Owner
                                    if (hsCompany.Properties.ContainsKey("hubspot_owner_id"))
                                    {
                                        string strHubspotOwnerID = hsCompany.Properties.Where(w => w.Key == "hubspot_owner_id").Select(s => s.Value.value).FirstOrDefault();
                                        HubspotOwnerID = 0;
                                        if (Int64.TryParse(strHubspotOwnerID, out HubspotOwnerID))
                                        {
                                            HubspotApi.Owner hsOwner = HubspotApi.Owners.GetOwnerByID(HubspotOwnerID);
                                            if (hsOwner != null)
                                                HubspotOwnerName = hsOwner.firstName + " " + hsOwner.lastName;
                                        }



                                    }

                                    //Last Engagement (contact)
                                    if (hsCompany.Properties.ContainsKey("notes_last_contacted"))
                                    {
                                        long lastContactDate = hsCompany.Properties.Where(w => w.Key == "notes_last_contacted").Select(s => Convert.ToInt64(s.Value.value)).FirstOrDefault();
                                        DateTime dtLastContact = HubspotApi.DateTimeFromUnixTimestampMillis(lastContactDate);
                                        HubspotLastContactDate = dtLastContact.ToShortDateString();
                                    }
                                    //WebSite
                                    if (hsCompany.Properties.ContainsKey("website"))
                                    {
                                        HubspotWebsiteUrl = hsCompany.Properties.Where(w => w.Key == "website").Select(s => s.Value.value).FirstOrDefault() ?? "Unknown";
                                    }                                     


                                }

                    }


                    //We may have an Rz Website, or a Hubspot.  HS is more accurate, so prefer that.
                    
                    if(!string.IsNullOrEmpty(HubspotWebsiteUrl))
                    {
                        companyWebSite = HubspotWebsiteUrl.Trim().ToLower();
                    }
                    else if(!string.IsNullOrEmpty(RzWebsiteUrl))
                        companyWebSite = RzWebsiteUrl.Trim().ToLower();



                    DataRow dr = ret.NewRow();
                    dr[0] = RzCompanyName ?? "Unknown";
                    dr[1] = RzCompanyID ?? "Unknown";
                    dr[2] = companyWebSite ?? "Unknown";
                    dr[3] = RzHubspotID;
                    dr[4] = HubspotAnnualRevenue ?? "Unknown";
                    dr[5] = RzAgentName ?? "Unknown";
                    dr[6] = RzAgendID ?? "Unknown";
                    dr[7] = HubspotOwnerName ?? "Unknown";
                    dr[8] = HubspotOwnerID;
                    dr[9] = HubspotLastContactDate ?? "Unknown";
                    dr[10] = HubspotLastContact ?? "Unknown";
                    dr[11] = RzTotalSales ?? "Unknown";
                    dr[12] = RzLastBatchDate == DateTime.MinValue ? "N/A" : RzLastBatchDate.ToShortDateString();
                    dr[13] = RzLastQuoteDate == DateTime.MinValue ? "N/A" : RzLastQuoteDate.ToShortDateString();
                    dr[14] = RzLastInvoiceDate == DateTime.MinValue ? "N/A" : RzLastInvoiceDate.ToShortDateString();
                    dr[15] = RzIndustrySegment;
                    dr[16] = RzHubspotID > 0 ? "https://app.hubspot.com/contacts/1878634/company/" + RzHubspotID : "No HS Link";
                    ret.Rows.Add(dr);
                }


            }
            return ret;
        }

        private static DataTable GenerateDatatable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RzCompanyName", typeof(string));
            dt.Columns.Add("RzCompanyID", typeof(string));
            dt.Columns.Add("companyWebSite", typeof(string));
            dt.Columns.Add("RzHubspotID", typeof(string));
            dt.Columns.Add("HubspotAnnualRevenue", typeof(string));
            dt.Columns.Add("RzAgentName", typeof(string));
            dt.Columns.Add("RzAgendID", typeof(string));
            dt.Columns.Add("HubspotOwnerName", typeof(string));
            dt.Columns.Add("HubspotOwnerID", typeof(string));
            dt.Columns.Add("HubspotLastContactDate", typeof(string));
            dt.Columns.Add("HubspotLastContact", typeof(string));
            dt.Columns.Add("RzTotalSales", typeof(string));
            dt.Columns.Add("RzLastBatchDate", typeof(string));
            dt.Columns.Add("RzLastQuoteDate", typeof(string));
            dt.Columns.Add("RzLastInvoiceDate", typeof(string));
            dt.Columns.Add("RzIndustrySegment", typeof(string));
            dt.Columns.Add("HubspotCompanyUrl", typeof(string));
            return dt;
        }
    }
}
