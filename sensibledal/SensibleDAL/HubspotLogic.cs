
using HubspotApis;
using Newtonsoft.Json;
using SensibleDAL.dbml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using static HubspotApis.HubspotApi;
using static SM_Enums;

namespace SensibleDAL
{
    public class HubspotLogic
    {

        //Log results of email match to Hubspot Company / contact
        public class HubspotMatchResults
        {


            public string customerEmail { get; set; }
            public HubspotApi.Contact hsContact { get; set; }
            public HubspotApi.Company hsCompany { get; set; }
            public List<HubspotApi.Contact> hsontactList { get; set; }
            public List<HubspotApi.Company> hsCompanyList { get; set; }
            public HubspotApi.Owner hsCompanyAgent { get; set; }
            public string matchResultLog { get; set; }
            public bool hubspotContactCreated { get; set; }
        }

        ////DataBase Operations   
        public static void RefreshHubspotEngagements(out int count)
        {



            List<hubspot_engagement> addedEngagements = new List<hubspot_engagement>();
            bool addToDatabase = true;
            DateTime lastUpdateCheck = DateTime.MinValue;
            hubspot_engagement newestEng = null;
            using (RzDataContext rdc = new RzDataContext())
            {
                lastUpdateCheck = rdc.hubspot_engagements.Max(m => m.date_created).Value;
                //DateTime lastUpdateCheck = new DateTime(2019, 07, 23, 13, 35, 00);
                //DateTime lastUpdateCheck = new DateTime(2019, 07, 22, 08,00,00);
                newestEng = rdc.hubspot_engagements.OrderByDescending(o => o.date_created).FirstOrDefault();

            }

            DateTime rzDateCreated = newestEng.date_created.Value;
            DateTime hsDateCreated = newestEng.hs_date_created.Value;
            long searchDate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(hsDateCreated);
            //Don't check mor than 5 minutes
            DateTime minutesAgo = DateTime.Now.AddMinutes(-5);
            //DateTime minutesAgo = DateTime.Now;
            //Update if it's been mroe than n minuts, OR if the engagementList is empty.
            count = 0;
            int offset = 0;
            bool doUpdate = lastUpdateCheck < minutesAgo;
            //if (doUpdate)//Less than = Before
            //if (true == true)
            {
                HubspotApi.EngagementRoot root = null;
                while (addToDatabase)
                {
                    //;
                    if (root == null)
                        root = HubspotApi.Engagements.GetRecentEngagements(searchDate, offset);
                    if (root == null)
                        return;
                    //Set the offset, increment it by past offset every time
                    offset = root.offset;
                    //Note:  The Offset, correspondes to the "next" engagement ID to be returned.  I.e. it will fetch from that number, and proceed, 
                    //you can pickup when you left off by starting at the most recent offset saved to DB                   
                    if (root.engagements.Count <= 0)
                        addToDatabase = false;
                    else
                    {
                        List<hubspot_engagement> newlyAddedEngagements = new List<hubspot_engagement>();

                        newlyAddedEngagements = AddEngagementsToDatabase(root.engagements);
                        addedEngagements.AddRange(newlyAddedEngagements);
                        count += addedEngagements.Count;
                        if (root.hasMore)
                            root = HubspotApi.Engagements.GetRecentEngagements(searchDate, offset);
                        else
                            addToDatabase = false;
                    }
                }
            }

        }

        public static void UpdateInProgressCallDispositions(RzDataContext rdc, out int updated)
        {
            //This can cause execution timeouts.
            rdc.CommandTimeout = 60;
            updated = 0;
            List<string> inProgressStatus = new List<string>() { "IN_PROGRESS", "CONNECTING" };

            //This is causing an api call for EACH engagement created today .... setting off execution timeouts
            //List<hubspot_engagement> InProgressHubspotCalls = rdc.hubspot_engagements.Where(w => (DateTime)w.hs_date_created >= DateTime.Today
            List<hubspot_engagement> InProgressHubspotCalls = rdc.hubspot_engagements.Where(w => (DateTime)w.hs_date_created >= DateTime.Today
            && inProgressStatus.Contains(w.status) && w.type == "CALL").ToList();

            foreach (hubspot_engagement he in InProgressHubspotCalls)
            {
                {
                    HubspotApi.Engagement hubEng = HubspotApi.Engagements.GetEngagementById(he.hubspotID);
                    if (hubEng != null)
                        if (hubEng.metadata.status != "IN_PROGRESS")
                        {
                            UpdateCallDisposition(he, hubEng);
                            UpdateEngagementProperties("call", he, hubEng);
                            updated++;
                        }
                }

            }
            if (updated > 0)
                rdc.SubmitChanges();

        }

        public static void UpdateCompletedNullDispositions(RzDataContext rdc, out int updated, long hubID = 0)
        {//Sometimes, the sync may run when a user has completed a call, but before disposition set.
         //In these cases we want to
         // -- get the latest version of these completed engagements from hs
         //hubID = 2860705671;
            updated = 0;

            List<hubspot_engagement> completedNullDispoEngagements = new List<hubspot_engagement>();
            if (hubID > 0)
            {

                //Get the specifically called HubID from local DB
                completedNullDispoEngagements = rdc.hubspot_engagements.Where(w => w.hubspotID == hubID).ToList();
                if (completedNullDispoEngagements.Count <= 0)
                {
                    //Not in Rz database, get the Hubspot Engagement from API, and ensure it's saved to the database.
                    HubspotApi.Engagement hubEng = HubspotApi.Engagements.GetEngagementById(hubID);

                    if (hubEng != null)
                    {//Save Hubspot Engagement to Rz database
                        List<HubspotApi.Engagement> engList = new List<HubspotApi.Engagement>();
                        engList.Add(hubEng);
                        AddEngagementsToDatabase(engList);
                        completedNullDispoEngagements = rdc.hubspot_engagements.Where(w => w.hubspotID == hubID).ToList();

                    }
                }

            }
            else
                completedNullDispoEngagements = rdc.hubspot_engagements.Where(w => w.hs_date_created.Value >= DateTime.Now.AddMinutes(-60) && w.status == "COMPLETED" && w.disposition_id == null).ToList();
            // -- loop through each, and get the latest hub eng 
            foreach (hubspot_engagement he in completedNullDispoEngagements)
            {
                bool isAbandoned = IsEngagementAbandoned(he);
                //if abandoned, don't spendign a hubspot Api call.
                if (!isAbandoned)
                {
                    HubspotApi.Engagement hubEng = HubspotApi.Engagements.GetEngagementById(he.hubspotID);
                    if (hubEng != null)
                    {
                        UpdateCallDisposition(he, hubEng);
                        UpdateEngagementProperties("call", he, hubEng);
                        updated++;
                    }
                }

            }
            if (updated > 0)
                rdc.SubmitChanges();


        }

        public static void ManageRzHubspotCompanyLinkage(string rzContactID, string rzCompanyID, HubspotApi.Contact hsContact, HubspotApi.Company hsCompany)
        {
            //Variable to hold the identified HS company

            //Does the company exist in HS
            company c = null;
            companycontact cc = null;

            using (RzDataContext rdc = new RzDataContext())
            {

                //Rz Company
                c = rdc.companies.Where(w => w.unique_id == rzCompanyID).FirstOrDefault();
                if (c == null)
                    return;

                //Rz Contact
                cc = rdc.companycontacts.Where(w => w.unique_id == rzContactID).FirstOrDefault();
                if (cc == null)
                    return;
                //Hubspot Contact Email
                string hsContactEmail = hsContact.Properties.Where(w => w.Key == "email").Select(s => s.Value.value).FirstOrDefault();
                if (string.IsNullOrEmpty(hsContactEmail))
                    return;

                //If we have a company ID, set hubspotCompany to that company
                if (hsCompany.companyId > 0)
                    if (c.hubspot_company_id != hsCompany.companyId)
                        c.hubspot_company_id = hsCompany.companyId;

                //If the company has id = 0 or was not found in Hubspot by ID

                if (hsContact.vid > 0)
                {

                    if (cc.hubspot_contact_id != hsContact.vid)
                        cc.hubspot_contact_id = hsContact.vid;


                    //string hsContactFirstName = hsContact.Properties.Where(w => w.Key == "firstname").Select(s => s.Value.value).FirstOrDefault();
                    //string hsContactLastName = hsContact.Properties.Where(w => w.Key == "lastname").Select(s => s.Value.value).FirstOrDefault();
                    //cc.contactname = hsContactFirstName + " " + hsContactLastName;
                }


                rdc.SubmitChanges();

            }
        }

        public class HubspotPortalLink
        {
            public long hubspot_contact_vid { get; set; }
            public string hub_contact_name { get; set; }
            public string portal_member_id { get; set; }
            public string portal_member_name { get; set; }
            public string portal_email { get; set; }
            public DateTime portal_register_date { get; set; }
            public DateTime portal_last_activity_date { get; set; }
        }

        public static HubspotPortalLink LinkPortalUserToHubspotContact(MembershipUser u)
        {
            HubspotPortalLink ret = new HubspotPortalLink();

            HubspotApi.Contact c = HubspotApi.Contacts.GetContactByEmail(u.Email);
            if (c == null)
                return null;

            //Gather variables from the Hubspot object            
            string str_hs_portal_create_date = c.Properties.Where(w => w.Key == "portal_registration_date").Select(s => s.Value.value).FirstOrDefault();
            string str_hs_portal_last_login = c.Properties.Where(w => w.Key == "last_portal_login").Select(s => s.Value.value).FirstOrDefault();
            string hsFirstName = c.Properties.Where(w => w.Key == "firstname").Select(s => s.Value.value).FirstOrDefault();
            string hsLastName = c.Properties.Where(w => w.Key == "lastname").Select(s => s.Value.value).FirstOrDefault();
            string str_hubspot_contact_vid = c.vid.ToString();

            //Craete Helper object and set values
            HubspotPortalLink hpl = new HubspotPortalLink();
            hpl.portal_member_id = u.ProviderUserKey.ToString();
            hpl.portal_member_name = u.UserName;
            hpl.hubspot_contact_vid = Convert.ToInt64(str_hubspot_contact_vid);
            hpl.hub_contact_name = hsFirstName + " " + hsLastName;
            hpl.portal_email = u.Email;
            hpl.portal_last_activity_date = u.LastActivityDate;
            hpl.portal_register_date = u.CreationDate;

            //Check if hubspot dates mnatch portal            
            Dictionary<string, string> contactProperties = new Dictionary<string, string>();
            long unixPortalCreationDate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(u.CreationDate.Date);
            if (unixPortalCreationDate.ToString() != str_hs_portal_create_date)
                contactProperties.Add("portal_registration_date", unixPortalCreationDate.ToString());

            long unixLastActivityDate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(u.LastActivityDate.Date);
            if (unixLastActivityDate.ToString() != str_hs_portal_last_login)
                contactProperties.Add("last_portal_login", unixLastActivityDate.ToString());
            if (contactProperties.Count > 0)
            {
                c.UpdateContact(contactProperties, c.vid);
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "Successfully updated Portal and Hubspot Linkage for " + u.Email);
                return hpl;
            }



            return ret;
        }

        public static List<HubspotPortalLink> LinkPortalUsersToHubspotContacts(List<MembershipUser> uList)
        {
            List<HubspotPortalLink> ret = new List<HubspotPortalLink>();
            foreach (MembershipUser u in uList)
            {
                HubspotPortalLink hl = LinkPortalUserToHubspotContact(u);
                if (hl != null)
                    ret.Add(hl);
            }
            return ret;
        }

        public static void FixMissingRecordings(RzDataContext rdc, out int fixedRecordings, long dealID)
        {
            fixedRecordings = 0;

            DateTime oneHourAgo = DateTime.Now.AddHours(-1);
            List<hubspot_engagement> completedWithNoRecordingList = new List<hubspot_engagement>();
            if (dealID > 0)
                completedWithNoRecordingList = rdc.hubspot_engagements.Where(w => w.type.ToLower() == "call" && w.hubspotID == dealID && w.hs_date_created.Value >= oneHourAgo && w.status == "COMPLETED" && (w.recording_url == null || w.recording_url == "") && !w.body.Contains("Logged from Rz")).ToList();
            else
                completedWithNoRecordingList = rdc.hubspot_engagements.Where(w => w.type.ToLower() == "call" && w.hs_date_created.Value >= oneHourAgo && w.status == "COMPLETED" && (w.recording_url == null || w.recording_url == "") && !w.body.Contains("Logged from Rz")).ToList();
            // -- loop through each, and get the latest hub eng 
            foreach (hubspot_engagement he in completedWithNoRecordingList)
            {
                //bool isAbandoned = IsEngagementAbandoned(he);
                //if abandoned, don't spendign a hubspot Api call.
                if (he.body.Contains("Logged from Rz"))
                    return;
                HubspotApi.Engagement hubEng = HubspotApi.Engagements.GetEngagementById(he.hubspotID);
                if (hubEng != null)
                {
                    //UpdateCallDisposition(he, hubEng);
                    if (!string.IsNullOrEmpty(hubEng.metadata.recordingUrl))
                    {
                        //UpdateCallRecordingUrl(he, hubEng);                            
                        UpdateEngagementProperties("call", he, hubEng);
                        fixedRecordings++;
                    }
                    else
                    {
                        if (hubEng.metadata.status == "No Answer")
                            return;
                        // he.abandoned = true;
                    }


                }


            }

            if (fixedRecordings > 0)
                rdc.SubmitChanges();

        }

        public static List<string> GetDialInHubspotNumbers()
        {
            List<string> ret = new List<string>() { "6179256372", "6172497806", "6173156996", "6175536128" };
            using (RzDataContext rdc = new RzDataContext())
            {
                List<string> RzIgnoreNumbers = (from choice in rdc.n_choices
                                                join grp in rdc.n_choice_groups on choice.the_n_choices_uid equals grp.unique_id
                                                where grp.name == "Hubspot Inbound Ignore Numbers"
                                                select choice.name).ToList(); //produces flat sequence


                foreach (string s in RzIgnoreNumbers)
                {
                    if (!string.IsNullOrEmpty(s))
                    {

                        string ss = Tools.Strings.ExtractDigits(s);
                        if (!ret.Contains(ss))
                            ret.Add(ss);
                    }

                }


            }

            return ret;

        }

        private static void UpdateCallDisposition(hubspot_engagement he, HubspotApi.Engagement hubEng)
        {

            //If we have a disposition, update it
            if (hubEng == null)
                return;
            if (hubEng.metadata == null)
                return;
            if (!string.IsNullOrEmpty(hubEng.metadata.disposition))
            {
                he.disposition_id = hubEng.metadata.disposition;
                he.call_disposition = HubspotApi.HubPhoneCall.GetDispositionName(hubEng.metadata.disposition);
            }
            else
            {                //Else, check to see if this engagements is abandoned
                DateTime lastUpdated = HubspotApi.DateTimeFromUnixTimestampMillis((long)hubEng.engagement.lastUpdated);
                DateTime oneHourAgo = DateTime.Now.AddHours(-1);
                if (lastUpdated < oneHourAgo) //IF no disposition, and it was lastUpdated more than 1 hour ago, close it
                {//I want to close them to minimize innecessary calls to Hubspot API for abandoned engagements.
                    he.disposition_id = "no_dispo_set";
                    he.call_disposition = "no_dispo_set";
                }
            }

            //Always update Status, Body, adn Duration
            //he.status = hubEng.metadata.status;
            //he.body = hubEng.metadata.body;
            //he.duration = hubEng.metadata.durationMilliseconds;
            //UpdateEngagementProperties("call");
        }

        private static string GetContactEmailFromRzObject(RzDataContext rdc, string objectType, string objectID)
        {            //THis would be the contact's email (not the Rz Rep ) that we use to associate with a company.

            companycontact c = null;

            switch (objectType)
            {

                case "dealheader":
                    {
                        dealheader d = rdc.dealheaders.Where(w => w.unique_id == objectID).FirstOrDefault();
                        if (d == null)
                            return null;
                        c = rdc.companycontacts.Where(w => w.unique_id == d.contact_uid).FirstOrDefault();
                        if (c == null)
                            return null;
                        break;

                    }
                case "ordhed":
                    {
                        ordhed oh = rdc.ordheds.Where(w => w.unique_id == objectID).FirstOrDefault();
                        if (oh == null)
                            return null;
                        c = rdc.companycontacts.Where(w => w.unique_id == oh.base_companycontact_uid).FirstOrDefault();
                        if (c == null)
                            return null;
                        break;
                    }



            }

            return c.primaryemailaddress.Trim().ToLower();



        }

        private static void UpdateCallRecordingUrl(hubspot_engagement he, HubspotApi.Engagement hubEng)
        {

            //If we have a disposition, update it
            if (hubEng == null)
                return;
            if (hubEng.metadata == null)
                return;
            if (string.IsNullOrEmpty(hubEng.metadata.recordingUrl))
                return;
            he.recording_url = hubEng.metadata.recordingUrl;


        }

        private static void UpdateEngagementProperties(string type, hubspot_engagement he, HubspotApi.Engagement hubEng)
        {
            switch (type.ToLower())
            {
                case "call":
                    UpdateEngagementProperties_Call(he, hubEng);
                    break;
            }

        }

        private static void UpdateEngagementProperties_Call(hubspot_engagement he, HubspotApi.Engagement hubEng)
        {
            he.status = hubEng.metadata.status;
            he.body = hubEng.metadata.body;
            he.duration = Convert.ToInt32(hubEng.metadata.durationMilliseconds);
            he.recording_url = hubEng.metadata.recordingUrl;
        }

        public static List<hubspot_engagement> GetEngagementList(List<n_user> agentList, DateTime startDate, DateTime endDate)
        {
            List<hubspot_engagement> ret = new List<hubspot_engagement>();

            using (RzDataContext rdc = new RzDataContext())
            {

                //if (SelectedAgentIds.Count == 1)
                //    engagementList = rdc.hubspot_engagements.Where(w => w.hs_date_created.Value >= startOfWeek && w.hs_date_created.Value <= endOfWeek.AddDays(1) && SelectedAgentIds.Contains(w.base_mc_user_uid)).ToList();
                //else
                List<string> rzEmails = agentList.Select(s => s.email_address).Distinct().ToList();
                List<string> hubOwnerIds = rdc.hubspot_engagements.Where(w => rzEmails.Contains(w.ownerEmail)).Select(s => s.ownerID).Distinct().ToList();
                List<string> hubspotIgnoreList = GetDialInHubspotNumbers();
                ret = rdc.hubspot_engagements.Where(w => w.hs_date_created.Value >= startDate && w.hs_date_created.Value <= endDate && hubOwnerIds.Contains(w.ownerID) && !hubspotIgnoreList.Contains(w.toNumber ?? "") && !hubspotIgnoreList.Contains(w.fromNumber ?? "")).ToList();
                //ret = rdc.hubspot_engagements.Where(w => w.hs_date_created.Value >= startDate && w.hs_date_created.Value <= endDate && w.ownerID == "8681566" && w.call_disposition.ToLower() == "connected"  && !hubspotIgnoreList.Contains(w.toNumber ?? "")).ToList();

                //foreach (string s in hubOwnerIds)//Loop through, because linq has the 2100 parameter limit preventing me from using  && hubOwnerIds.Contains(w.ownerID)
                //engagementList.AddRange(rdc.hubspot_engagements.Where(w => w.hs_date_created.Value >= startOfWeek && w.hs_date_created.Value <= endOfWeek && w.ownerID == s).ToList());

                hubspot_engagement firstEng = ret.OrderBy(o => o.hs_date_created.Value).OrderBy(o => o.hs_date_created).FirstOrDefault();
                hubspot_engagement lastEng = ret.OrderByDescending(o => o.hs_date_created.Value).FirstOrDefault();

            }
            return ret;

        }

        private static bool IsEngagementAbandoned(hubspot_engagement he)
        {
            //bool ret = false;
            if (string.IsNullOrEmpty(he.disposition_id))
                return false;
            if (he.disposition_id == "no_dispo_set")
                return true;
            if (he.call_disposition == "no_dispo_set")
                return true;
            return false;
        }

        public static List<hubspot_engagement> AddEngagementsToDatabase(List<HubspotApi.Engagement> engagementList)
        {
            List<hubspot_engagement> ret = new List<hubspot_engagement>();

            //Populate the OwnerList -  This need to be in the AddtoDatabase method, since it can be different with each offset Iteration
            List<HubspotApi.Owner> ownerList = HubspotApi.Owners.GetOwners(engagementList.Select(s => s.engagement.ownerId).Distinct().ToList());


            //Rz 

            //Get list of owners and use that for name-matching, rather than separate API lookup per record
            //Also, use a list to filter account, i.e. house, since shares email with ctorrioni, and breaks the dictionary
            string houseAct = "17a7e95b7bcb47b0a2501d422f899100";
            string deadAct = "f2569b12718645e382e0346716f6785d";
            List<string> excludedRzUsers = new List<string>() { houseAct, deadAct };
            List<n_user> rzUserList = new List<n_user>();
            using (RzDataContext rdc = new RzDataContext())
                rzUserList = rdc.n_users.Distinct().Where(w => !excludedRzUsers.Contains(w.unique_id) && w.email_address != "ktill@sensiblemicro.com" && w.email_address.Length > 0 && w.is_inactive != true).ToList();


            //Combine them in a dictionary with HubID as key
            Dictionary<long, string> dictHubspotRzMatch = new Dictionary<long, string>();
            foreach (n_user u in rzUserList)
            {
                long hubspotID = 0;
                if (!string.IsNullOrEmpty(u.email_address))
                {
                    if (ownerList.Select(s => s.email.ToLower().Trim()).ToList().Contains(u.email_address.ToLower().Trim())) //check if the rzUser is a valid huubspot Owner
                    {

                        hubspotID = ownerList.Where(w => w.email.ToLower().Trim() == u.email_address.ToLower().Trim()).Select(s => s.ownerId).FirstOrDefault();
                        if (hubspotID != 0)
                        {
                            string rzID = u.unique_id;
                            dictHubspotRzMatch.Add(hubspotID, rzID);
                        }
                    }

                }
            }

            //Filter out Existing HubIDs:
            List<long> fetchedHubspotIDs = engagementList.Select(s => s.engagement.id).Distinct().ToList();
            List<long> duplicateRzHubIds = new List<long>();

            //This might be a huge query
            using (RzDataContext rdc = new RzDataContext())
                duplicateRzHubIds = rdc.hubspot_engagements.Where(w => fetchedHubspotIDs.Contains(w.hubspotID)).Select(s => s.hubspotID).ToList();
            //Some of these duplicatHubIds will have updates we nee dto grab. i.e. call_disposition for calls that were previously logged before call_disposition was captured.


            //Remove Duplicates
            if (duplicateRzHubIds.Count > 0)
                engagementList = engagementList.Where(w => !duplicateRzHubIds.Contains(w.engagement.id)).ToList();

            int i = 0;//for debugging index
            using (RzDataContext rdc = new RzDataContext())
            {


                foreach (HubspotApi.Engagement he in engagementList)
                {
                    HubspotApi.Owner owner = ownerList.Where(w => w.ownerId == he.engagement.ownerId).FirstOrDefault();
                    if (owner != null && owner.ownerId != 0)
                    {
                        hubspot_engagement hs = new hubspot_engagement();
                        if (dictHubspotRzMatch.ContainsKey(he.engagement.ownerId))
                            hs.base_mc_user_uid = dictHubspotRzMatch[he.engagement.ownerId];
                        hs.hubspotID = Convert.ToInt64(he.engagement.id);
                        hs.ownerID = owner.ownerId.ToString();
                        //If email, task, or Note, only keep 1st 25 characters.
                        if (he.engagement.type == "EMAIL" || he.engagement.type == "TASK" || he.engagement.type == "NOTE")
                            if (!string.IsNullOrEmpty(hs.body))
                                hs.body = he.metadata.body.Substring(0, 25);
                            else
                                hs.body = he.metadata.body ?? "";
                        hs.hs_date_created = HubspotApi.DateTimeFromUnixTimestampMillis((long)he.engagement.createdAt);
                        hs.date_created = DateTime.Now;
                        hs.date_modified = HubspotApi.DateTimeFromUnixTimestampMillis((long)he.engagement.lastUpdated);
                        hs.duration = Convert.ToInt32(he.metadata.durationMilliseconds);
                        hs.ownerName = owner.firstName + " " + owner.lastName;
                        hs.ownerEmail = owner.email;
                        hs.subject = he.metadata.subject;
                        hs.toNumber = he.metadata.toNumber;
                        hs.type = he.engagement.type;
                        hs.unique_id = Guid.NewGuid().ToString();
                        hs.status = he.metadata.status ?? "";
                        //hs.html = he.metadata.html ?? "";

                        if (!string.IsNullOrEmpty(he.metadata.recordingUrl))
                            hs.recording_url = he.metadata.recordingUrl.ToString();
                        if (!string.IsNullOrEmpty(he.metadata.disposition))
                        {
                            hs.disposition_id = he.metadata.disposition;
                            hs.call_disposition = HubspotApi.HubPhoneCall.GetDispositionName(he.metadata.disposition);
                        }
                        //Associated Company and Contacts
                        HubspotApi.Company hsCompany = null;
                        if (he.associations != null)
                            if (he.associations.companyIds.Count > 0)
                                hsCompany = HubspotApi.Companies.GetCompanyByID(he.associations.companyIds[0]);
                        if (hsCompany != null)
                        {
                            //Sometimes, "Name" can be null
                            if (!hsCompany.Properties.ContainsKey("name"))
                                hs.company_name = "No Name found via Hubspot API";
                            else
                                hs.company_name = hsCompany.Properties["name"].value;
                            hs.hs_company_id = hsCompany.companyId;
                        }
                        HubspotApi.Contact hsContact = null;
                        if (he.associations.contactIds.Count > 0)
                            hsContact = HubspotApi.Contacts.GetContactByID(he.associations.contactIds[0]);
                        if (hsContact != null)
                        {
                            //https://developers.hubspot.com/docs/methods/contacts/contacts-overview
                            // Contacts may have multiple vids, but the canonical-vid will be the primary ID for a record.
                            string firstName = "";
                            string lastName = "";
                            hs.hs_contact_id = hsContact.canonicalVid;
                            if (hsContact.Properties.ContainsKey("firstname"))
                                firstName = hsContact.Properties["firstname"].value;
                            if (hsContact.Properties.ContainsKey("lastname"))
                                lastName = hsContact.Properties["lastname"].value;
                            hs.hs_contact_first_name = firstName;
                            hs.hs_contact_last_name = lastName;
                        }
                        ret.Add(hs);
                        rdc.hubspot_engagements.InsertOnSubmit(hs);
                        i++;
                    }


                }
                //Submit all changes
                rdc.SubmitChanges();
            }
            return ret;
        }

        public static string GetHubpsotDealBusinessType(string customer_email)
        {
            if (string.IsNullOrEmpty(customer_email))
                return "undetermined";

            using (RzDataContext rdc = new RzDataContext())
            {
                companycontact theContact = rdc.companycontacts.Where(w => w.primaryemailaddress.ToLower().Trim() == customer_email.ToLower().Trim()).FirstOrDefault();
                if (theContact == null)
                    return "undetermined";

                //Hubspot Stages
                //undetermined - not found in database (could be a type, or maybe we missing email, rather than assume new business, let's flag undetermined and follow up manually
                //existingbusiness - has previously ordered  ( Sales > 0)
                //newbusiness - Found in Rz but first RFQ / first batch entry (ZERO history, no sales, FQ's etc. RFQ <= 0, FQ <=0, Sales <=0)
                //rfq - req but never quoted(previous rfqs / batches but never quoted due to stock availability), RFQ >0 FQ <=0 Sales <= 0
                //quoted - Quoted but no sales(have previously been formally quoted but has never ordered), Formal Quotes > 0, Unvoided Sales <= 0


                //Check Existing Sales
                int countExistingSales = rdc.ordhed_sales.Where(w => w.base_company_uid == theContact.base_company_uid).Count();
                if (countExistingSales > 0)
                    return "existingbusiness";
                //Quoted            
                int countExistingQuotes = rdc.ordhed_quotes.Where(w => w.base_company_uid == theContact.base_company_uid).Count();
                if (countExistingQuotes > 0)
                    return "quoted";

                ////Check quote_lines / RFQ                
                //int countExistingQuoteLines = rdc.orddet_quotes.Where(w => w.base_company_uid == theContact.base_company_uid).Count();
                //if (countExistingQuoteLines > 0)
                //{
                //    if (countExistingQuoteLines == 1) //This is counting the line for the current Batch.  HS Deal won't get created until at least 1 req, so this is New Business
                //        return "newbusiness";
                //    else
                //        return "rfq";
                //}


                //The above won't work if we import, miltiple lines for a new business customer, then req count will be >1 and that's rfq.  Instead let's count batches
                int countExistingBatches = rdc.dealheaders.Where(w => w.customer_uid == theContact.base_company_uid).Count();
                if (countExistingBatches > 0)
                {
                    if (countExistingBatches == 1) //IF count is exactly 1, then it's newbusiness
                        return "newbusiness";
                    else
                        return "rfq";
                }
                //New Business
                return
                    "newbusiness";



            }


        }

        public static string CloseRzDealsFromHubspot(out int count)
        {
            //Process:  
            //The Agent:
            //Opens a deal
            //Chooses Sale Lost from "dealstage"
            //  IF they don't provide reason, the deal could be stamped closed, but isn't closed
            //  I can't look at just closed, has to be closed AND have a closed reason, then Workflow stamps the Hubspot Closed Date
            //Provides "sale_lost_reason" - this will always be mandatory


            //Logic:
            //Get recent Engagements (last 6 mins to account for timing overlaps)
            //string is_closed = "";
            string sales_lost_reason = "";
            string close_date = "";
            //initially set cound to zero.  Only change if items found.
            count = 0;

            string closureReport = "Closure Report: <br />";

            List<HubspotApi.Deal> recentlyModifiedDealList = HubspotApi.Deals.GetDealsModifiedSinceMinutes(6);
            List<HubspotApi.Deal> closedDeals = new List<HubspotApi.Deal>();
            //Loop through them, create list of engagements that where non of those 3 fields are blank
            foreach (HubspotApi.Deal d in recentlyModifiedDealList)
            {
                //is_closed = d.properties.Where(w => w.Key == "hs_is_closed").Select(s => s.Value.value).FirstOrDefault();
                sales_lost_reason = d.properties.Where(w => w.Key == "closed_lost_reason").Select(s => s.Value.value).FirstOrDefault();
                close_date = d.properties.Where(w => w.Key == "closedate").Select(s => s.Value.value).FirstOrDefault();


                //if (!string.IsNullOrEmpty(is_closed) && !string.IsNullOrEmpty(sales_lost_reason) && !string.IsNullOrEmpty(close_date))
                if (!string.IsNullOrEmpty(sales_lost_reason) && !string.IsNullOrEmpty(close_date))
                {
                    string modified_date = d.properties.Where(w => w.Key == "hs_lastmodifieddate").Select(s => s.Value.value).FirstOrDefault();
                    DateTime modifiedDateEST = HubspotApi.Api.DateTimeESTFromUnixTimestampMillis(Convert.ToInt64(modified_date));
                    if (modifiedDateEST <= DateTime.Now.AddDays(-6))
                    {
                        return closureReport;
                    }

                    //If all 3 values are present, ok to close, add to list
                    closedDeals.Add(d);
                }

            }


            if (closedDeals.Count <= 0 || closedDeals == null)
                return closureReport;

            //Since we have a count, set it.
            count = closedDeals.Count;

            //Get the related RzOrders, Quotes and or Sales
            using (RzDataContext rdc = new RzDataContext())
            {
                foreach (HubspotApi.Deal d in closedDeals)
                {
                    string closeResults = CloseRzObjectsFromHubspotDeal(rdc, d);
                    if (!string.IsNullOrEmpty(closeResults))
                        closureReport += closeResults;
                }

                rdc.SubmitChanges();
            }




            //If Not closed, close the order object, and any related (FQ / SO)
            if (closureReport == "Closure Report: <br />")
                //closureReport = "Closure Report: Nothing found to close.";
                return null;
            return closureReport;


        }

        public static string CloseRzObjectsFromHubspotDeal(RzDataContext rdc, HubspotApi.Deal d)
        {
            string ret = "";
            //NOTE Per Nicole @ marketing - this should only apply to reqs and Formal Quotes.
            //string rz_sales_id = d.properties.Where(w => w.Key == "rz_quote_id").Select(s => s.Value.value).FirstOrDefault();
            string rz_quote_id = d.properties.Where(w => w.Key == "rz_quote_id").Select(s => s.Value.value).FirstOrDefault();
            string rz_batch_id = d.properties.Where(w => w.Key == "rz_batch_id").Select(s => s.Value.value).FirstOrDefault();
            string sales_lost_reason = d.properties.Where(w => w.Key == "closed_lost_reason").Select(s => s.Value.value).FirstOrDefault();
            string close_date = d.properties.Where(w => w.Key == "closedate").Select(s => s.Value.value).FirstOrDefault();
            string modified_date = d.properties.Where(w => w.Key == "hs_lastmodifieddate").Select(s => s.Value.value).FirstOrDefault();

            //Variables for Test / debugging 
            long longCloseDate = 0;
            Int64.TryParse(close_date, out longCloseDate);
            long longModifiedDate = 0;
            Int64.TryParse(modified_date, out longModifiedDate);
            DateTime closeDateEST = HubspotApi.Api.DateTimeESTFromUnixTimestampMillis(longCloseDate);
            DateTime modifiedDastEST = HubspotApi.Api.DateTimeESTFromUnixTimestampMillis(longModifiedDate);


            //If ALL of these values are null, there's nothing in Rz to update, stop work
            if (string.IsNullOrEmpty(rz_quote_id) && string.IsNullOrEmpty(rz_batch_id))
            {
                ret += "No qote or Batch ID found.";
                return ret;

            }



            //Confirm we have a proper close date before DateTime conversion.
            long closeDateMillis = 0;
            closeDateMillis = d.properties.Where(w => w.Key == "closedate").Select(s => Convert.ToInt64(s.Value.value)).FirstOrDefault();
            //if (!long.TryParse(close_date, out closeDateMillis))
            //{
            //closureReport += "close_date (" + close_date + ") it not an Int64";
            // }

            DateTime dtClose_Date = HubspotApi.Api.DateTimeESTFromUnixTimestampMillis(closeDateMillis);
            //ordhed_sale theSale = null;
            ordhed_quote theQuote = null;
            dealheader theBatch = null;

            ////int closedSales = 0;           
            //int closedQuotes = 0;
            //int closedBatches = 0;



            //theSale = rdc.ordhed_sales.Where(w => w.unique_id == rz_sales_id).FirstOrDefault();
            theQuote = rdc.ordhed_quotes.Where(w => w.unique_id == rz_quote_id).FirstOrDefault();
            theBatch = rdc.dealheaders.Where(w => w.unique_id == rz_batch_id).FirstOrDefault();
            if (theQuote == null && theBatch == null)
                return null;
            //if (theSale != null && theSale.isclosed != true)
            //{                    
            //    theSale.opportunity_lost_reason = sales_lost_reason;
            //    theSale.isclosed = true;         
            //    closureReport += "Closed Sale: #" + theSale.ordernumber + "("+theSale.companyname+ ") <br />";
            //    ++closedSales;
            //}

            if (theQuote != null)
            {

                if ((bool)theQuote.isclosed || (bool)theQuote.isvoid)//Already closed elsewhere
                {
                    //ret += "Formal Quote " + theQuote.ordernumber + ": Already Closed <br /> <br />";
                }
                else
                {
                    ret += "Rz Quotes for DealID " + d.dealId + ": <br />";
                    theQuote.isclosed = true;
                    theQuote.isvoid = true;
                    theQuote.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
                    theQuote.opportunity_lost_reason = sales_lost_reason;
                    theQuote.grid_color = Convert.ToInt32(SM_Enums.RzGridColor.Gray);

                    ret += "Closed Quote: #" + theQuote.ordernumber + "(" + theQuote.companyname + ")  <br /><br />";
                    //++closedQuotes;
                }

            }

            if (theBatch != null)
            {
                if ((bool)theBatch.is_closed)//Already closed elsewhere
                {
                    //ret += "Batch " + theBatch.dealheader_name + ": Already Closed <br />";
                }
                else
                {
                    ret += "Rz Quotes for DealID " + d.dealId + ": <br />";
                    theBatch.is_closed = true;
                    theBatch.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
                    theBatch.ClosureReason = sales_lost_reason;
                    theBatch.grid_color = Convert.ToInt32(SM_Enums.RzGridColor.Gray);

                    ret += "Closed Batch ID: " + theBatch.dealheader_name + "(" + theBatch.customer_name + ") <br />";
                    //++closedBatches;

                }

            }

            // int totalClosed = closedBatches + closedQuotes;


            //Send an email of the reaslts so we can track.
            //closureReport += "Batches closed: " + closedBatches.ToString() + "<br />";
            //closureReport += "Quotes closed: " + closedQuotes.ToString() + "<br />";
            //closureReport += "Sales closed: " + closedSales.ToString() + "<br />";
            //closureReport += "Total Rz objects closed: " + totalClosed.ToString();
            //tools.SendMail("huspot_deal_closures@sensiblemicro.com", "ktill@sensiblemicro.com", "Hubspot API Deal Closure Report", closureReport);


            return ret;

        }

        public class HubDbPart
        {
            public string HubDbId { get; set; }
            public string ComID { get; set; }
            public string PartNumber { get; set; }
            public string Manufacturer { get; set; }
            public string Quantity { get; set; }
            public string ImageUrl { get; set; }
            //public byte[] Graphic { get; set; }
        }

        public static List<HubDbPart> GetHubDbFranchiseParts()
        {
            List<HubDbPart> lstFranchiseParts = new List<HubDbPart>();
            HubspotApi.HubDbRows rowsList = HubspotApi.HubDBs.GetHubDBTableRows("1056508"); //Adam's Tech table for now.  TODO: Common Franchise PArts Table for Adam's Tech, Geyer, etc.
            List<HubspotApi.Values> listValues = rowsList.Rows.Select(s => s.values).ToList();
            //Column 9 has comID
            //List<string> strComIds = listValues.Select(s => s.nine.ToString()).OrderBy(o => o).ToList();
            //int i = 0;
            foreach (var v in listValues)
            {
                if (string.IsNullOrEmpty(v.two)) //users may accidentially add empty row to table.  If partnumber is null, skip.
                    continue;

                HubDbPart hubPart = new HubDbPart();
                hubPart.PartNumber = v.two;
                hubPart.ComID = v.ten;
                hubPart.Manufacturer = v.three;
                hubPart.ImageUrl = GetHubDbImage(v.six);

                if (!lstFranchiseParts.Contains(hubPart))
                    lstFranchiseParts.Add(hubPart);
            }

            return lstFranchiseParts;
        }

        private static string GetHubDbImage(object o)
        {

            HubspotApi.HubDbGraphic g = JsonConvert.DeserializeObject<HubspotApi.HubDbGraphic>(o.ToString());
            if (g != null)
                if (!string.IsNullOrEmpty(g.Url))
                    return g.Url;
            return "";


        }

        public static List<HubDbPart> GetHubDbAdwordsParts()
        {
            List<HubDbPart> listHubDbParts = new List<HubDbPart>();
            HubspotApi.HubDbRows rowsList = HubspotApi.HubDBs.GetHubDBTableRows("1041110"); //Adam's Tech table for now.
            List<HubspotApi.Values> listValues = rowsList.Rows.Select(s => s.values).ToList();
            //"2": "46045677",
            //"3": "LUPXA255A0E400",
            //"4": {
            //    "url": "https://info.sensiblemicro.com/hubfs/aw-parts/LUPXA255A0E400.jpg",
            //        "width": 640,
            //        "height": 640,
            //        "type": "image"
            //    }
            foreach (var v in listValues)
            {
                if (string.IsNullOrEmpty(v.two)) //users may accidentially add empty row to table.  If partnumber is null, skip.
                    continue;

                HubDbPart hubPart = new HubDbPart();
                hubPart.PartNumber = v.three;
                hubPart.ComID = v.two;
                //hubPart.Manufacturer = v.three;
                if (v.four != null)
                    hubPart.ImageUrl = GetHubDbImage(v.four);

                if (!listHubDbParts.Contains(hubPart))
                    listHubDbParts.Add(hubPart);
            }

            return listHubDbParts;
        }

        private static string GetPartsStringFromOrddetQuote(List<orddet_quote> qList)
        {

            string ret = string.Join(",", qList.Select(s => s.fullpartnumber).ToList());
            return ret;

        }

        private static string GetPartsStringFromOrddetLine(List<orddet_line> lList)
        {

            string ret = string.Join(",", lList.Select(s => s.fullpartnumber).ToList());
            return ret;

        }


        private static string GetLineItemsListFromOrdhed(ordhed currentOrder)
        {
            string ret = null;
            string orderType = currentOrder.GetType().ToString().ToLower();
            using (RzDataContext rdc = new RzDataContext())
            {
                switch (orderType)
                {
                    case "quote":
                        {
                            List<orddet_quote> qLines = rdc.orddet_quotes.Where(w => w.base_ordhed_uid == currentOrder.unique_id).ToList();
                            ret = GetPartsStringFromOrddetQuote(qLines);
                            break;
                        }

                    case "sales":
                        {
                            List<orddet_line> lines = rdc.orddet_lines.Where(w => w.orderid_sales == currentOrder.unique_id).ToList();
                            ret = GetPartsStringFromOrddetLine(lines);
                            break;
                        }
                    case "invoice":
                        {
                            List<orddet_line> lines = rdc.orddet_lines.Where(w => w.orderid_invoice == currentOrder.unique_id).ToList();
                            ret = GetPartsStringFromOrddetLine(lines);
                            break; ;
                        }

                }
            }
            return ret;
        }

        public static HubspotApi.Owner GetHubspotDealOwner(string user_ID)
        {

            n_user u = null;
            using (RzDataContext rdc = new RzDataContext())
                u = rdc.n_users.Where(w => w.unique_id == user_ID).FirstOrDefault();
            if (u == null)
                return null;
            if (string.IsNullOrEmpty(u.email_address))
                return null;
            if (!Tools.Email.IsEmailAddress(u.email_address))
                return null;
            HubspotApi.Owner hsOwner = HubspotApi.Owners.GetOwnerByEmail(u.email_address);
            return hsOwner;
        }

        public static class HubspotCalls
        {


            //Public Classes:
            public class LastHubspotCallUserObject
            {
                public string userName { get; set; }
                public DateTime lastCall { get; set; }
                public double timeSinceLastCall { get; set; }
            }


            private static List<hubspot_engagement> GetTodaysCalls(RzDataContext rdc)
            {
                List<hubspot_engagement> ret = new List<hubspot_engagement>();
                ret = rdc.hubspot_engagements.Where(w => w.date_created >= DateTime.Today && w.type.ToLower() == "call").ToList();
                return ret;

            }
            public static List<LastHubspotCallUserObject> GetLastCallUserObjects(RzDataContext rdc)
            {
                List<LastHubspotCallUserObject> ret = new List<LastHubspotCallUserObject>();

                List<LastHubspotCallUserObject> ncuList = new List<LastHubspotCallUserObject>();
                List<n_user> phoneUsers = RzLogic.Users.GetPhoneUsers(rdc);
                List<hubspot_engagement> todaysCalls = GetTodaysCalls(rdc);
                List<string> omittedUsers = new List<string>() { "ctorrioni@sensiblemicro.com", "lmcdonald@sensiblemicro.com" };
                phoneUsers = phoneUsers.Where(w => !omittedUsers.Contains(w.email_address.ToLower())).ToList();

                foreach (n_user u in phoneUsers)
                {
                    List<hubspot_engagement> currentUserCalls = todaysCalls.Where(w => w.base_mc_user_uid == u.unique_id).ToList();
                    var lastCall = (from d in currentUserCalls select d.hs_date_created).Max();
                    //In the morning, before any calls, this will be null.  Setting 9am as the official start time in those cases.
                    if (lastCall == null)
                        lastCall = RzLogic.Business.startOfSensibleBusinessDay;

                    LastHubspotCallUserObject lcu = new LastHubspotCallUserObject();
                    lcu.userName = u.name;
                    lcu.lastCall = (DateTime)lastCall;
                    TimeSpan ts = DateTime.Now.Subtract((DateTime)lastCall);

                    lcu.timeSinceLastCall = ts.TotalMinutes;
                    //Add to List
                    ret.Add(lcu);




                }


                return ret;
            }

            public static void DoNoCallAlertEmail(string to = null, string[] cc = null, int minutesSince = 0)
            {
                if (string.IsNullOrEmpty(to))
                    to = "joemar@sensiblemicro.com";
                //if (cc == null)
                //    cc = new string[] { "ktill@sensiblemicro.com" };


                List<LastHubspotCallUserObject> usersCalls = new List<LastHubspotCallUserObject>();
                using (RzDataContext rdc = new RzDataContext())
                    usersCalls = GetLastCallUserObjects(rdc);
                if (minutesSince != 0)
                    usersCalls = usersCalls.Where(w => w.timeSinceLastCall >= minutesSince).OrderByDescending(o => o.timeSinceLastCall).ToList();
                if (usersCalls.Count > 0)
                {
                    string htmlBody = buildNoCallEmailBodyHTML(usersCalls);
                    SystemLogic.Email.SendMail("no_call_alert@sensiblemicro.com", to, "No Call Alert", htmlBody, cc);

                }

            }

            private static string buildNoCallEmailBodyHTML(List<LastHubspotCallUserObject> usersWithNoCalls)
            {
                string ret = "";
                StringBuilder sb = new StringBuilder();
                //Headers

                sb.Append("<table style = \"width:600px; border: 1px solid black; padding:5px; \">\n");
                sb.Append("<thead style = \"font-weight:bold; \" >\n");
                sb.Append("<tr>\n");
                sb.Append("<th style = \"witdh:40%; text-align: left; \" > Agent </th>\n");
                sb.Append("<th style = \"witdh:30%; text-align: left; \" > Last Call </th>\n");
                sb.Append("<th style = \"witdh:30%; text-align: right; \" > Minutes Since </th>\n");
                sb.Append("</tr>\n");
                sb.Append("</thead>\n");

                //Body Rows
                foreach (LastHubspotCallUserObject h in usersWithNoCalls.OrderByDescending(o => o.timeSinceLastCall))
                {

                    int timeSince = (int)h.timeSinceLastCall;

                    sb.Append("<tr><td style = \"text-align: left; \">" + h.userName + "</td><td style = \"text-align: left; \">" + h.lastCall + "</td><td style = \"font-weight:bold;text-align: right; \">" + timeSince.ToString() + "</td></tr>\n");

                }
                sb.Append("</table>\n");
                ret = sb.ToString();
                return ret;
            }


        }




        //Hubspot Management
        public static HubspotApi.Deal CreateHubspotDeal(object rzObject)
        {

            string errorMessage = "Cannot create Hubspot Deal.  ";
            //Original create Date

            //Confirm Valid Contact ID
            string contactID = null;
            //Get the object's agent ID, confirm they are Hubspot enabled
            string agentID = null;
            //Source Unique IF for RzObject
            string rzObjectID = "";
            //Get the Rz Object Type
            if (rzObject is dealheader)
            {
                dealheader d = (dealheader)rzObject;
                contactID = d.contact_uid;
                agentID = d.base_mc_user_uid;
                rzObjectID = d.unique_id;


            }
            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                contactID = o.base_companycontact_uid;
                agentID = o.base_mc_user_uid;
                rzObjectID = o.unique_id;

            }
            else if (rzObject is ordhed_quote)
            {
                ordhed_quote o = (ordhed_quote)rzObject;
                contactID = o.base_companycontact_uid;
                agentID = o.base_mc_user_uid;
                rzObjectID = o.unique_id;

            }
            else if (rzObject is ordhed_sale)
            {
                ordhed_sale o = (ordhed_sale)rzObject;
                contactID = o.base_companycontact_uid;
                agentID = o.base_mc_user_uid;
                rzObjectID = o.unique_id;
            }
            else if (rzObject is ordhed_invoice)
            {

                ordhed_invoice o = (ordhed_invoice)rzObject;
                contactID = o.base_companycontact_uid;
                agentID = o.base_mc_user_uid;
                rzObjectID = o.unique_id;
            }
            else
            {
                //Object type not identified
                return null;
            }
            //Alert and return if no valid Agent ID
            if (string.IsNullOrEmpty(agentID))
            {
                //x.Leader.Error(errorMessage + "Agent ID not found for this order.");
                return null;
            }

            //Alert and return if no valid Agent
            n_user u;
            using (RzDataContext rdc = new RzDataContext())
                u = rdc.n_users.Where(w => w.unique_id == agentID).FirstOrDefault();//.GetById(x, agentID);
            if (u == null)
            {
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + "Rz User not found with id: " + agentID);
                return null;
            }

            //Do nothing if owning agent is not Hubspot enabeld.
            if (!u.is_hubspot_enabled ?? false)
                return null;


            //Alert and return if no valid contact ID
            if (string.IsNullOrEmpty(contactID))
            {
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + "Contact ID not set for this order.", false);
                return null;
            }

            //Confirm Actual contact associated with the ID we found
            companycontact theContact;
            using (RzDataContext rdc = new RzDataContext())
                theContact = rdc.companycontacts.Where(w => w.unique_id == contactID).FirstOrDefault();//.GetById(x, contactID);
            if (theContact == null)
            {
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + "The system was unable to find the contact related to this order (contact uid = '" + contactID + "').");
                return null;
            }

            //Confirm Valid Contact Email Address
            if (string.IsNullOrEmpty(theContact.primaryemailaddress))
            {
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + "No email address exists in Rz for " + theContact.contactname + ".");
                return null;
            }
            if (!Tools.Email.IsEmailAddress(theContact.primaryemailaddress))
            {
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + theContact.primaryemailaddress + " is not a valid email address.");
                return null;
            }


            //Generate the associations
            HubspotApi.Associations ass = HubspotApi.Deals.CreateDealAssociations(theContact.primaryemailaddress);
            if (ass == null)
            {
                //Add this contact and associate with this Hubspot User.
                HubspotApi.Contact hsContact = CreateHubspotContact(theContact, HubspotApi.Contacts.ContactSource.RzDealCreated);
                ass = HubspotApi.Deals.CreateDealAssociations(theContact.primaryemailaddress);
                if (ass == null)
                {
                    SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + "error creating Hubspot deal associations for " + theContact.primaryemailaddress + ".  Is this the right email address for the contact?");
                    return null;
                }
                else
                { return null; }
            }

            //Generate the Properties
            Dictionary<string, string> props = GenerateBaseHubspotDealProperties(rzObject);

            //Handle Rz-specific property logic
            props = GenerateRzHubspotProperties(rzObject, props);

            //On Create Only, set the businesstype
            string businessType = HubspotLogic.GetHubpsotDealBusinessType(theContact.primaryemailaddress);
            props.Add("dealtype", businessType);

            if (props == null)
            {
                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, errorMessage + "error creating Hubspot deal properties for the rzObject.");
                return null;
            }

            //Create the Deal
            //HubspotApi hsa = new HubspotApi();
            //Tag source as  "rz_generated" for all quotes foming from OrderLogic.
            //"quote_source" may be in use wtih other marketing fields.  Need to confirm with them 1st
            //props.Add("quote_source", "rz_generated");

            HubspotApi.Deal ret = HubspotApi.Deals.CreateDeal(ass, props);
            //Stap this ID on all related orders.

            SetDealIDRelatedOrders(ret, rzObjectID);


            //if (ret != null)
            //{
            //    if (ret.dealId > 0)
            //        GetAndSyncRelatedHubspotID(rzObject, ret.dealId);
            //}


            return ret;

        }

        private static void SetDealIDRelatedOrders(Deal ret, string rzObjectId)
        {
            List<object> relatedOrders = null;
            long dealHubID = ret.dealId;
            long rzHubID = 0;
            using (RzDataContext rdc = new RzDataContext())
            {
                relatedOrders = GetRelatedOrders(rdc, rzObjectId);
                foreach (object o in relatedOrders)
                {
                    if (o is dealheader)
                    {
                        dealheader d = (dealheader)o;
                        rzHubID = d.hubspot_deal_id ?? 0;
                        if (rzHubID == 0 || rzHubID != dealHubID)
                            ((dealheader)o).hubspot_deal_id = dealHubID;

                    }
                    else if (o is ordhed_quote)
                    {
                        ordhed_quote q = (ordhed_quote)o;
                        rzHubID = q.hubspot_deal_id ?? 0;
                        if (rzHubID == 0 || rzHubID != dealHubID)
                            ((ordhed_quote)o).hubspot_deal_id = dealHubID;

                    }
                    else if (o is ordhed_sale)
                    {
                        ordhed_sale s = (ordhed_sale)o;
                        rzHubID = s.hubspot_deal_id ?? 0;
                        if (rzHubID == 0 || rzHubID != dealHubID)
                            ((ordhed_sale)o).hubspot_deal_id = dealHubID;

                    }
                }
                rdc.SubmitChanges();
            }


        }



        public static HubspotApi.Deal UpdateHubspotDeal(object rzObject)
        {
            long dealID = 0;
            bool isRzOpportunityLost = false;
            bool isHubspotDealLost = false;

            //Check to see if the Rz Object is Closed
            if (rzObject is dealheader)
            {
                dealheader d = (dealheader)rzObject;
                if (d != null)
                {

                    dealID = d.hubspot_deal_id ?? 0;
                    isRzOpportunityLost = d.is_closed ?? false;

                }

            }
            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                if (o != null)
                {
                    dealID = o.hubspot_deal_id.Value;
                    isRzOpportunityLost = o.isclosed.Value;
                }
            }

            else if (rzObject is ordhed_quote)
            {
                ordhed_quote q = (ordhed_quote)rzObject;
                if (q != null)
                {
                    dealID = q.hubspot_deal_id.Value;
                    isRzOpportunityLost = q.isclosed.Value;
                }
            }
            else if (rzObject is ordhed_sale)
            {
                ordhed_sale s = (ordhed_sale)rzObject;
                if (s != null)
                {
                    dealID = s.hubspot_deal_id.Value;
                    isRzOpportunityLost = s.isclosed.Value;
                }
            }
            else if (rzObject is ordhed_invoice)
            {
                ordhed_invoice i = (ordhed_invoice)rzObject;
                if (i != null)
                {
                    dealID = i.hubspot_deal_id.Value;
                    isRzOpportunityLost = i.isclosed.Value;
                }

            }

            //Valid Deal ID?
            if (dealID <= 0)
                return null;

            //Get the deal to check for certain properties
            HubspotApi.Deal ret = HubspotApi.Deals.GetDealByID(dealID);//This will never be null, need to check DealID
            if (ret.dealId <= 0)
                return null;



            //If Object closed in Hubspot but still open in Rz, Check if deal has been closed, if so, close Rz Deal    
            string currentHsDealStageID = ret.properties.Where(w => w.Key == "dealstage").Select(s => s.Value.value).FirstOrDefault();
            string currentHsDealStage = HubspotApi.Deals.GetDealStageNameFromDealStageID(currentHsDealStageID);
            string sales_lost_reason = ret.properties.Where(w => w.Key == "closed_lost_reason").Select(s => s.Value.value).FirstOrDefault();
            //if (!string.IsNullOrEmpty(sales_lost_reason))
            if (currentHsDealStage == HubspotApi.DealStage.sale_lost)
                isHubspotDealLost = true;
            //If this has been closed in Hubspot
            if (isHubspotDealLost)
            { //IF it's already closed in Rz, don't update deal
                if (isRzOpportunityLost)
                    return ret;
                //Offer to close it
                else if (CheckCloseRzObjectFromHubspot(rzObject, ret))//If close successful, return null to halt deal update.
                    return null;
                return ret;
            }


            //Get the base properties for the deal
            Dictionary<string, string> props = GenerateBaseHubspotDealProperties(rzObject);
            //Handle Rz-specific property logic
            props = GenerateRzHubspotProperties(rzObject, props);
            if (props == null)
                return null;

            //Update the deal
            ret = HubspotApi.Deals.UpdateDeal(dealID, props);
            //if (ret != null)
            //{
            //    if (ret.dealId > 0)
            //        GetAndSyncRelatedHubspotID(rzObject, ret.dealId);

            //    //Save DealID to the object
            //    if (d != null)
            //    {

            //    }
            //}

            return ret;
        }
        //public static HubspotApi.Deal GetAndSyncRelatedHubspotID(object rzObject, long forcedHubID = 0)
        //{
        //    //Sometimes, we mave have a deal on a SO, but not the Quote or the batch, and vice versa.
        //    //This method will get the related dealheaders, and ordheds, find any HubID's an update all related orders a common ID.
        //    //HubID allows me to sync to a specific ID as needed.

        //    string sourceObjectID = GetSourceObjectID(rzObject);
        //    HubspotApi.Deal ret = null;
        //    dealheader oppDealheader = (dealheader)GetRelatedOrders(sourceObjectID, "dealheader");
        //    ordhed_quote oppFormalQuote = (ordhed_quote)GetRelatedOrders(sourceObjectID, "quote");
        //    ordhed_sale oppOrdhedSales = (ordhed_sale)GetRelatedOrders(sourceObjectID, "sale");
        //    ordhed_invoice oppInvoice = (ordhed_invoice)GetRelatedOrders(sourceObjectID, "invoice");
        //    long retHubID = 0;
        //    if (forcedHubID > 0)
        //        retHubID = forcedHubID;

        //    //Get the hub ID in order of dealheader, Quote, sale
        //    if (retHubID <= 0)
        //    {
        //        if (oppDealheader != null)
        //        {
        //            if (oppDealheader.hubspot_deal_id > 0)
        //                retHubID = oppDealheader.hubspot_deal_id.Value;
        //        }
        //    }

        //    //if no id from dealheader, check quote
        //    if (retHubID <= 0)
        //    {
        //        if (oppFormalQuote != null)
        //        {
        //            if (oppFormalQuote.hubspot_deal_id > 0)
        //                retHubID = oppFormalQuote.hubspot_deal_id.Value;
        //        }
        //    }

        //    //if no id from quote, check sale
        //    if (retHubID <= 0)
        //    {
        //        if (oppOrdhedSales != null)
        //        {
        //            retHubID = oppOrdhedSales.hubspot_deal_id.Value;
        //        }
        //    }

        //    //if we have no discovered hubUD from any objects, at this point, return null
        //    if (retHubID <= 0)
        //        return null;

        //    //Update any Discovered hubID with the one we have here.
        //    if (oppDealheader != null)
        //    {
        //        if (oppDealheader.hubspot_deal_id != retHubID)
        //        {
        //            oppDealheader.hubspot_deal_id = retHubID;
        //            //oppDealheader.Update(x);
        //        }

        //    }

        //    if (oppOrdhedSales != null)
        //    {
        //        if (oppOrdhedSales.hubspot_deal_id != retHubID)
        //        {
        //            oppOrdhedSales.hubspot_deal_id = retHubID;
        //            //oppOrdhedSales.Update(x);
        //        }

        //    }

        //    if (oppFormalQuote != null)
        //    {
        //        if (oppFormalQuote.hubspot_deal_id != retHubID)
        //        {
        //            oppFormalQuote.hubspot_deal_id = retHubID;
        //            //oppFormalQuote.Update(x);
        //        }

        //    }

        //    if (oppInvoice != null)
        //    {
        //        if (oppInvoice.hubspot_deal_id != retHubID)
        //        {
        //            oppInvoice.hubspot_deal_id = retHubID;
        //            //oppInvoice.Update(x);
        //        }

        //    }
        //    if (retHubID > 0)
        //        ret = HubspotApi.Deals.GetDealByID(retHubID);
        //    return ret;

        //}

        private static Dictionary<string, string> GetProfitAmountsRzSale(ordhed_sale relatedSale, Dictionary<string, string> props)
        {
            //Amount and Gross Profit (From Sale)
            string amount = "";
            string gross_profit = "";

            if (relatedSale != null)
            {
                //While sale may be set on the Formal Quote, we'll update it with the Sales Order since Sales order wins.
                amount = relatedSale.ordertotal.ToString();
                gross_profit = relatedSale.gross_profit.ToString();
                //Per Hubspot Rules, Can only do certain reports using the Amount column.  Thus if we want to report on GP, need to send GP to the amount column
                if (!string.IsNullOrEmpty(gross_profit))
                    props.Add("amount", gross_profit);
                //Have created a new Rz property to send the sale amount to a customer Rz field rz_sales_amount
                if (!string.IsNullOrEmpty(amount))
                    props.Add("rz_total_amount", amount);


                //Previously, we set amount as sale amount
                //if (!string.IsNullOrEmpty(amount))
                //    props.Add("rz_total_amount", amount);
                //if (!string.IsNullOrEmpty(gross_profit))
                //    props.Add("gross_profit", gross_profit);
            }

            return props;
        }

        private static Dictionary<string, string> GetProfitAmountsRzQuote(ordhed_quote relatedQuote, Dictionary<string, string> props)
        {
            //Amount and Gross Profit (From Sale)
            string amount = "";
            string gross_profit = "";

            if (relatedQuote != null)
            {
                //While sale may be set on the Formal Quote, we'll update it with the Sales Order since Sales order wins.
                amount = relatedQuote.ordertotal.ToString();
                gross_profit = relatedQuote.profitamount.ToString();
                if (!string.IsNullOrEmpty(amount))
                    props.Add("amount", amount);
                if (!string.IsNullOrEmpty(gross_profit))
                    props.Add("gross_profit", gross_profit);
            }

            return props;
        }



        public static Dictionary<string, string> GenerateBaseHubspotDealProperties(object rzObject)
        {



            Dictionary<string, string> props = new Dictionary<string, string>();
            string hubspot_owner_id = "";
            string createdate = "";
            //string dealstageName = "";
            //string dealstageID = "";
            string rz_agent_id = "";
            string rz_company_id = "";
            string rz_contact_id = "";
            string rz_batch_id = "";
            string rz_batch_name = "";
            string rz_sales_id = "";
            string rz_sales_number = "";
            string rz_invoice_id = "";
            string rz_invoice_number = "";
            string rz_quote_id = "";
            string rz_quote_number = "";
            string opportunity_lost_reason = "";
            string affiliate_id = "";

            //Need to get teh id's for related orders as well
            using (RzDataContext rdc = new RzDataContext())
            {

                if (rzObject is ordhed_invoice)
                {
                    ordhed_invoice o = (ordhed_invoice)rzObject;
                    rz_agent_id = o.base_mc_user_uid;
                    rz_company_id = o.base_company_uid;
                    rz_contact_id = o.base_companycontact_uid;
                    //dealstageName = o.opportunity_stage;
                    //dealstageID = GetHubsotDealStageFromRzOpportunityStage(rzObject);
                    opportunity_lost_reason = o.opportunity_lost_reason;
                    rz_invoice_id = o.unique_id;
                    rz_invoice_number = o.ordernumber;
                    createdate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(o.date_created.Value).ToString();
                }

                else if (rzObject is ordhed_sale)
                {
                    ordhed_sale o = (ordhed_sale)rzObject;
                    rz_agent_id = o.base_mc_user_uid;
                    rz_company_id = o.base_company_uid;
                    rz_contact_id = o.base_companycontact_uid;
                    //dealstageName = o.opportunity_stage;
                    //dealstageID = GetHubsotDealStageFromRzOpportunityStage(rzObject);
                    opportunity_lost_reason = o.opportunity_lost_reason;
                    rz_sales_id = o.unique_id;
                    rz_sales_number = o.ordernumber;
                    createdate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(o.date_created.Value).ToString();
                }

                else if (rzObject is ordhed_quote)
                {
                    ordhed_quote o = (ordhed_quote)rzObject;
                    rz_agent_id = o.base_mc_user_uid;
                    rz_company_id = o.base_company_uid;
                    rz_contact_id = o.base_companycontact_uid;
                    //dealstageName = o.opportunity_stage;
                    //dealstageID = GetHubsotDealStageFromRzOpportunityStage(rzObject);
                    opportunity_lost_reason = o.opportunity_lost_reason;
                    rz_quote_id = o.unique_id;
                    rz_quote_number = o.ordernumber;
                    createdate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(o.date_created.Value).ToString();
                }

                else if (rzObject is dealheader)
                {

                    dealheader d = (dealheader)rzObject;
                    if (d == null)
                        return null;
                    rz_agent_id = d.base_mc_user_uid;
                    rz_company_id = d.customer_uid;
                    rz_contact_id = d.contact_uid;
                    rz_batch_id = d.unique_id;
                    rz_batch_name = d.dealheader_name;
                    //dealstageName = d.opportunity_stage;
                    //dealstageID = HubspotApi.Deals.GetDealStageIDFromDealStageName(d.opportunity_stage);
                    createdate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(d.date_created.Value).ToString();
                    opportunity_lost_reason = d.ClosureReason;
                }



            }


            //Owner
            HubspotApi.Owner hubOwner = HubspotLogic.GetHubspotDealOwner(rz_agent_id);
            if (hubOwner != null)
                hubspot_owner_id = hubOwner.ownerId.ToString();

            //Affiliate ID
            affiliate_id = GetAffiliateID_OrderObject(rzObject);

            //Check fro null/empty, else empty values will overwrite existing.
            if (!string.IsNullOrEmpty(hubspot_owner_id))
                props.Add("hubspot_owner_id", hubspot_owner_id);
            if (!string.IsNullOrEmpty(rz_agent_id))
                props.Add("rz_agent_id", rz_agent_id);
            if (!string.IsNullOrEmpty(rz_company_id))
                props.Add("rz_company_id", rz_company_id);
            if (!string.IsNullOrEmpty(rz_contact_id))
                props.Add("rz_contact_id", rz_contact_id);
            //if (!string.IsNullOrEmpty(part_number))
            //    props.Add("part_number", part_number);
            //if (!string.IsNullOrEmpty(manufacturer))
            //    props.Add("manufacturer", manufacturer);
            //if (!string.IsNullOrEmpty(dealstageID))
            //    props.Add("dealstage", dealstageID);
            //Don't check null here, opp lost just overwrites
            props.Add("closed_lost_reason", opportunity_lost_reason);
            if (!string.IsNullOrEmpty(rz_batch_id))
                props.Add("rz_batch_id", rz_batch_id);
            if (!string.IsNullOrEmpty(rz_batch_name))
                props.Add("rz_batch_name", rz_batch_name);
            if (!string.IsNullOrEmpty(rz_quote_id))
                props.Add("rz_quote_id", rz_quote_id);
            if (!string.IsNullOrEmpty(rz_quote_number))
                props.Add("rz_quote_number", rz_quote_number);
            if (!string.IsNullOrEmpty(rz_sales_id))
                props.Add("rz_sales_id", rz_sales_id);
            if (!string.IsNullOrEmpty(rz_sales_number))
                props.Add("rz_sales_number", rz_sales_number);
            if (!string.IsNullOrEmpty(rz_invoice_id))
                props.Add("rz_invoice_id", rz_invoice_id);
            if (!string.IsNullOrEmpty(rz_invoice_number))
                props.Add("rz_invoice_number", rz_invoice_number);
            if (!string.IsNullOrEmpty(createdate))
                props.Add("createdate", createdate);
            if (!string.IsNullOrEmpty(affiliate_id))
                props.Add("affiliate_id", affiliate_id);
            return props;


        }

        private static string GetAffiliateID_OrderObject(object rzObject)
        {

            //To prevent re-saves causing affiliates from being set when, say, a companycontact becomes and affiliate, but also has non affiliate orders, we will only save affiliate on new Order Object creation, or controls on WebForm by permitted users.

            using (RzDataContext rdc = new RzDataContext())
            {
                if (rzObject is dealheader)
                {
                    dealheader d = (dealheader)rzObject;

                    //List<orddet_quote> lineList = d.GetAllOrddetQuotes(x).Cast<orddet_quote>().ToList();
                    List<orddet_quote> lineList = rdc.orddet_quotes.Where(w => w.base_dealheader_uid == d.unique_id).ToList();
                    string id = lineList.Where(w => (w.affiliate_id ?? "").Length > 0).Select(s => s.affiliate_id).FirstOrDefault();
                    if (!string.IsNullOrEmpty(id))
                        return id;
                }
                else if (rzObject is ordhed_quote)
                {
                    ordhed_quote q = (ordhed_quote)rzObject;
                    //List<orddet_quote> lineList = q.DetailsList(x).Cast<orddet_quote>().ToList();
                    List<orddet_quote> lineList = rdc.orddet_quotes.Where(w => w.base_ordhed_uid == q.unique_id).ToList();
                    string id = lineList.Where(w => w.affiliate_id.Length > 0 && w.affiliate_id != null).Select(s => s.affiliate_id).FirstOrDefault();
                    if (!string.IsNullOrEmpty(id))
                        return id;
                }
                else if (rzObject is ordhed_sale)
                {
                    ordhed_sale s = (ordhed_sale)rzObject;
                    //List<orddet_line> lineList = s.DetailsList(x).Cast<orddet_line>().ToList();
                    List<orddet_line> lineList = rdc.orddet_lines.Where(w => w.orderid_sales == s.unique_id).ToList();
                    string id = lineList.Where(w => w.affiliate_id.Length > 0 && w.affiliate_id != null).Select(ss => ss.affiliate_id).FirstOrDefault();
                    if (!string.IsNullOrEmpty(id))
                        return id;
                }

                return "";
            }

        }

        public static Dictionary<string, string> GenerateRzHubspotProperties(object rzObject, Dictionary<string, string> props)
        {


            //Check for a related sale for profit amounts
            string sourceObjectID = GetSourceObjectID(rzObject);


            //ordhed_quote relatedQuote = (ordhed_quote)GetRelatedOrders(sourceObjectID, "quote");// GetOpportunityQuote(rzObject);
            //ordhed_sale relatedSale = (ordhed_sale)GetRelatedOrders(sourceObjectID, "sales");
            string rz_company_name = "Unknown";

            dealheader relatedDealheader = null;
            ordhed_sale relatedSale = null;
            ordhed_quote relatedQuote = null;
            string formalQuoteID = null; //for dealheader and ordhed_quote linkage
            string salesOrderID = null;

            //Get the DealName
            //Since we already might have a sale, passing that in to save db trips
            string dealName = "";

            List<object> relatedOrders = null;




            using (RzDataContext rdc = new RzDataContext())
            {
                relatedOrders = GetRelatedOrders(rdc, sourceObjectID);
            }

            foreach (object o in relatedOrders)
            {
                if (o is dealheader)
                    relatedDealheader = (dealheader)o;
                else if (o is ordhed_quote)
                    relatedQuote = (ordhed_quote)o;
                else if (o is ordhed_sale)
                    relatedSale = (ordhed_sale)o;
            }


            if (relatedSale != null)
            {
                dealName = GenerateDealName(relatedSale);
                props = GetProfitAmountsRzSale(relatedSale, props);
                rz_company_name = relatedSale.companyname;

            }
            else if (relatedQuote != null)
            {
                dealName = GenerateDealName(relatedQuote);
                props = GetProfitAmountsRzQuote(relatedQuote, props);
                props.Add("opportunity_type", relatedQuote.opportunity_type);
                rz_company_name = relatedQuote.companyname;
            }

            else if (relatedDealheader != null)
            {
                dealName = GenerateDealName(relatedDealheader);
                rz_company_name = relatedDealheader.customer_name;
            }
            else
                throw new Exception("Rz API: DealName Error. Could not determine a proper dealname for Rzobject with id: " + sourceObjectID);


            if (!string.IsNullOrEmpty(rz_company_name))
                props.Add("rz_company_name", rz_company_name);
            //This will also become the primary deal name is presenet (so either batch or sales ordeR)
            if (!string.IsNullOrEmpty(dealName))
                props.Add("dealname", dealName);

            //Part Numbers / MFG - comma separated values of each
            string part_number = "";
            string manufacturer = "";
            string internalPartNumber = "";
            GetDealDetailsFromRzObject(rzObject, relatedQuote, relatedSale, out part_number, out manufacturer, out internalPartNumber);

            props.Add("part_number", part_number);
            props.Add("manufacturer", manufacturer);
            props.Add("rz_internal_part", internalPartNumber);


            return props;
        }

        private static string GenerateDealName(object rzObject)
        {
            if (rzObject is ordhed_sale)
                return "(Sale#: " + ((ordhed_sale)rzObject).ordernumber + ")";
            else if (rzObject is ordhed_quote)
                return "(FQ#: " + ((ordhed_quote)rzObject).ordernumber + ")";
            else if (rzObject is dealheader)
                return "(Batch#: " + ((dealheader)rzObject).dealheader_name + ")";
            return "Problem Creating Deal Name.";
        }

        private static string GetSourceObjectID(object rzObject)
        {
            string ret = "";
            if (rzObject is dealheader)
                ret = ((dealheader)rzObject).unique_id;
            else if (rzObject is ordhed_quote)
                ret = ((ordhed_quote)rzObject).unique_id;
            if (rzObject is ordhed_sale)
                ret = ((ordhed_sale)rzObject).unique_id;
            if (rzObject is ordhed_invoice)
                ret = ((ordhed_invoice)rzObject).unique_id;
            if (string.IsNullOrEmpty(ret))
                throw new Exception("Could not determine source object ID.");
            return ret;
        }

        private static void GetDealDetailsFromRzObject(object rzObject, ordhed_quote relatedQuote, ordhed_sale relatedSale, out string strPart, out string strMfg, out string strInternal)
        {
            strPart = "";
            strMfg = "";
            strInternal = "";

            using (RzDataContext rdc = new RzDataContext())
            {
                if (relatedSale != null)
                {

                    //List<orddet_line> lineList = relatedSale.DetailsList(x).Cast<orddet_line>().ToList();
                    List<orddet_line> lineList = rdc.orddet_lines.Where(w => w.orderid_sales == relatedSale.unique_id).ToList();
                    strPart = GenerateDealPartString(lineList);//string.Join(",", lineList.Select(s => s.fullpartnumber).ToList());
                    strMfg = string.Join(",", lineList.Select(s => s.manufacturer).ToList());
                    strInternal = string.Join(",", lineList.Select(s => s.internal_customer.Trim().ToUpper() ?? s.fullpartnumber.Trim().ToUpper()).Distinct());
                }
                else if (relatedQuote != null)
                {
                    //List<orddet_quote> lineList = relatedQuote.DetailsList(x).Cast<orddet_quote>().ToList();
                    List<orddet_quote> lineList = rdc.orddet_quotes.Where(w => w.base_ordhed_uid == relatedQuote.unique_id).ToList();
                    strPart = GenerateDealPartString(lineList);//string.Join(",", lineList.Select(s => s.fullpartnumber).ToList());
                    strMfg = string.Join(",", lineList.Select(s => s.manufacturer).ToList());
                    strInternal = string.Join(",", lineList.Select(s => s.internalpartnumber.Trim().ToUpper() ?? s.fullpartnumber.Trim().ToUpper()).Distinct());
                }

                else if (rzObject is dealheader)
                {
                    dealheader d = (dealheader)rzObject;
                    //List<orddet_quote> reqList = d.ReqsGetAll(x).Cast<orddet_quote>().ToList();
                    List<orddet_quote> reqList = rdc.orddet_quotes.Where(w => w.base_dealheader_uid == d.unique_id).ToList();
                    strPart = GenerateDealPartString(reqList);
                    strMfg = string.Join(",", reqList.Select(s => s.manufacturer).ToList());
                    //if(!string.IsNullOrEmpty(s.internalpartnumber) || !string.IsNullOrEmpty(s.internalpartnumber))
                    List<string> internalList = reqList.Where(w => w.internalpartnumber != null && w.internalpartnumber.Length > 0).Select(s => s.internalpartnumber).ToList();
                    //Internal PArts
                    if (internalList != null && internalList.Count > 0)
                        strInternal = string.Join(",", internalList.Distinct().ToList());
                    else if (!string.IsNullOrEmpty(strPart))
                        strInternal = string.Join(",", reqList.Where(w => w.fullpartnumber != null && w.fullpartnumber.Length > 0).Select(s => s.fullpartnumber).Distinct().ToList()).Trim().ToUpper();
                    //strInternal = string.Join(",", reqList.Select(s => s.internalpartnumber.Trim().ToUpper() ?? s.fullpartnumber.Trim().ToUpper()).Distinct());
                }
            }



        }

        private static string GenerateDealPartString(object list)
        {
            //object can be a List<orddet_quote> or a List<orddet_line>
            List<orddet_quote> quoteList = null;
            List<orddet_line> lineList = null;
            string ret = "";
            if (list is List<orddet_line> || list is List<orddet_line>)
            {
                lineList = (List<orddet_line>)list;
                foreach (orddet_line l in lineList)
                {
                    ret += l.fullpartnumber.Trim().ToUpper() + " (" + l.quantity + ")";
                    if (l != lineList.Last())
                        ret += ",";
                }
                return ret;
            }
            else if (list is List<orddet_quote>)
            {
                quoteList = (List<orddet_quote>)list;
                foreach (orddet_quote q in quoteList)
                {

                    string qty = q.target_quantity.ToString();
                    if (q.quantityordered > 0)
                        qty = q.quantityordered.ToString();
                    ret += q.fullpartnumber.Trim().ToUpper() + " (" + qty + ")";
                    if (q != quoteList.Last())
                        ret += ",";
                }
                return ret;
            }
            return ret;

        }

        //private static string SetHubspotDealName(object rzObject, ordhed_sale relatedSale1)
        //{
        //    //Deal Name Rules 8-8-2019
        //    //Syntax:  <amount - when present> <orderObject#>
        //    //Use SO, or FQ, or Batch (in order if present) to derive text for dealname
        //    //Example:  dealName = " (Batch#: " + relatedDeal.dealheader_name + ")";
        //    //Example:  dealName = "$" + relatedSale.ordertotal + " "+ "(Sale#: " + relatedSale.ordernumber + ")";
        //    dealheader relatedDealheader = null;
        //    ordhed_quote relatedQuote = null;
        //    ordhed_sale relatedSale = null;








        //    string sourceObjectID = GetSourceObjectID(rzObject);
        //    relatedSale = (ordhed_sale)GetRelatedOrders(sourceObjectID, "sale");
        //    relatedQuote = (ordhed_quote)GetRelatedOrders(sourceObjectID, "quote");





        //    if (relatedSale != null)
        //        return "(Sale#: " + relatedSale.ordernumber + ")";


        //    if (relatedQuote != null)
        //        return "(FQ#: " + relatedQuote.ordernumber + ")";

        //    if (relatedDealheader != null)
        //        return " (Batch#: " + ((dealheader)rzObject).dealheader_name + ")";



        //    //object o = GetRelatedOrders(sourceObjectID, )


        //    ////Will sometimes already have a related sale from previous method
        //    //if (relatedSale != null)
        //    //    //return "$" + relatedSale.ordertotal + " " + "(Sale#: " + relatedSale.ordernumber + ")";
        //    //    return "(Sale#: " + relatedSale.ordernumber + ")";
        //    //ordhed_quote relatedQuote = GetRelatedOrders()
        //    //if (relatedQuote != null)
        //    //    //return "$" + relatedQuote.ordertotal + " " + "(FQ#: " + relatedQuote.ordernumber + ")";
        //    //    return "(FQ#: " + relatedQuote.ordernumber + ")";
        //    //dealheader relatedDeal = GetOpportunityDealheader(rzObject);
        //    //if (relatedDeal != null)
        //    //    return " (Batch#: " + relatedDeal.dealheader_name + ")";

        //    return "Rz API: DealName Error.  Report this to IT.";

        //}



        //private static ordhed_sale GetOpportunitySale(object rzObject)
        //{
        //    //We only update ordheds, dealheaders may not even have a related order, and making changed to batch, should not win over changes to Sales Order.
        //    //Sales order is the golden standard of data.
        //    ordhed_sale ret = null;
        //    if (rzObject is ordhed_sale)
        //        ret = (ordhed_sale)rzObject;

        //    else if (rzObject is dealheader)
        //    {
        //        dealheader d = (dealheader)rzObject;
        //        //List<ordhed_sale> saleList = d.GetOrders(OrderType.Sales);
        //        List<ordhed_sale> saleList = (List<ordhed_sale>)GetRelatedOrders(d.unique_id, "sale");
        //        if (saleList == null)
        //            return null;
        //        //List<ordhed_sales> sList = saleList.Cast<ordhed_sales>().ToList();
        //        //if (sList == null)
        //        //    return null;
        //        if (saleList.Count > 1)
        //        {
        //            SystemLogic.Logs.LogEvent(SM_Enums.LogType.Error, "More than one Sales Order was detected for batch# " + d.dealheader_name + ".  Cannot get the related sale to update the opportunity stage.");
        //            return null;
        //        }

        //        if (saleList.Count == 1)
        //            ret = (ordhed_sale)saleList[0];

        //    }
        //    else if (rzObject is ordhed)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        List<ordhed_sale> saleList = (List<ordhed_sale>)GetRelatedOrders(o.unique_id, "sale");
        //        ret = saleList[0];

        //    }
        //    else if (rzObject is ordhed_quote)
        //    {
        //        ordhed_quote o = (ordhed_quote)rzObject;
        //        List<ordhed_sale> saleList = (List<ordhed_sale>)GetRelatedOrders(o.unique_id, "sale");
        //        ret = saleList[0];

        //    }
        //    else if (rzObject is ordhed_invoice)
        //    {
        //        ordhed_invoice o = (ordhed_invoice)rzObject;
        //        List<ordhed_sale> saleList = (List<ordhed_sale>)GetRelatedOrders(o.unique_id, "sale");
        //        ret = saleList[0];

        //    }
        //    return ret;
        //}
        //private List<object> GetRelatedOrders(string sourceOrderID)
        //{
        //    RzDataContext rdc = new RzDataContext();
        //    return GetRelatedOrders(rdc, sourceOrderID);
        //}


        private static List<object> GetRelatedOrders(RzDataContext rdc, string sourceOrderID)
        {
            if (rdc == null)
                rdc = new RzDataContext();



            List<object> ret = new List<object>();
            //Quote line
            orddet_quote quoteLine = null;
            orddet_line saleLine = null;

            dealheader d = null;
            ordhed_quote q = null;
            ordhed_sale s = null;


            object o = null;


            //Identify the source object
            o = rdc.dealheaders.Where(w => w.unique_id == sourceOrderID).FirstOrDefault();
            if (o == null)
                o = rdc.ordhed_quotes.Where(w => w.unique_id == sourceOrderID).FirstOrDefault();
            if (o == null)
                o = rdc.ordhed_sales.Where(w => w.unique_id == sourceOrderID).FirstOrDefault();

            if (o == null)
                return null;

            //dealheaders and ordhed_Quotes require orddeT_quote for linkage, not represeented int eh ordlnk table.
            if (o is dealheader)
            {
                d = (dealheader)o;
                quoteLine = rdc.orddet_quotes.Where(w => w.base_dealheader_uid == d.unique_id).FirstOrDefault();
            }
            else if (o is ordhed_quote)
            {
                q = (ordhed_quote)o;
                quoteLine = rdc.orddet_quotes.Where(w => w.base_ordhed_uid == q.unique_id).FirstOrDefault();
            }
            else if (o is ordhed_sale)
                s = (ordhed_sale)o;
            else
                return null;


            if (quoteLine != null)
            {
                saleLine = rdc.orddet_lines.Where(w => w.quote_line_uid == quoteLine.unique_id).FirstOrDefault();
            }
            else if (s != null)
            {
                saleLine = rdc.orddet_lines.Where(w => w.orderid_sales == s.unique_id).FirstOrDefault();
                if (saleLine != null)
                {
                    if (quoteLine == null)
                        quoteLine = rdc.orddet_quotes.Where(w => w.unique_id == saleLine.quote_line_uid).FirstOrDefault();
                }
            }

            //Now we should have found any quote or sale lines, can use to relate.
            if (quoteLine != null)
            {
                if (q == null)
                    q = rdc.ordhed_quotes.Where(w => w.unique_id == quoteLine.base_ordhed_uid).FirstOrDefault();
                if (d == null)
                    d = rdc.dealheaders.Where(w => w.unique_id == quoteLine.base_dealheader_uid).FirstOrDefault();
            }
            if (saleLine != null)
                s = rdc.ordhed_sales.Where(w => w.unique_id == saleLine.orderid_sales).FirstOrDefault();



            if (d != null && !ret.Contains(d))
                ret.Add(d);
            if (q != null && !ret.Contains(q))
                ret.Add(q);
            if (s != null && !ret.Contains(s))
                ret.Add(s);
            return ret;
        }

        //private static object GetRelatedOrders(string sourceOrderID, string targetOrderType)
        //{
        //    using (RzDataContext rdc = new RzDataContext())
        //    {
        //        //Dictionary<string, string> targetOrderElements = rdc.ordlnks.Where(w => w.orderid1 == sourceOrderID && w.ordertype2 == targetOrderType).ToDictionary(d => d.orderid2, d => d.ordertype2);

        //        //this may be a dealheader, which isn't in ordlink, so we need the ordhed_qoute, then get any related Sales
        //        //dealheaders are not part of ordlink;
        //        dealheader d = rdc.dealheaders.Where(w => w.unique_id == sourceOrderID).FirstOrDefault();
        //        if (d != null)
        //        {
        //            //this is a dealheader
        //            if (targetOrderType == "dealheader")
        //                return d;
        //            else
        //                return GetOrdersRelatedToDealheader(d, targetOrderType);
        //        }


        //        //All other order objects.
        //        //Invoices don't link directly to the Quote, instead the link to a sale, which in turn links to a quote, therefore, the Sale is the key to finding all related orders.                
        //        string orderid_sales = rdc.ordlnks.Where(w => w.orderid1 == sourceOrderID && w.ordertype2.ToLower() == "sales").Select(s => s.orderid2).FirstOrDefault();
        //        //If we have no sale ID, then this hasn't made it past Formal Quote Stage.
        //        if (string.IsNullOrEmpty(orderid_sales))
        //        {
        //            //Since no possible sale or invoice, return on that condition
        //            if (targetOrderType.ToLower() == "sale" || targetOrderType.ToLower() == "invoice")
        //                return null;
        //            //Since we may be looking for a quote, and dealheader already handled above, handle quote here
        //            if (targetOrderType.ToLower() == "quote")
        //                return rdc.ordlnks.Where(w => w.orderid1 == orderid_sales && w.ordertype2.ToLower() == "quote").FirstOrDefault();
        //        }
        //        //If we do have a salesID, and dealheaders are already covered, then we may be looking for a Quote, sale, or invoice.


        //        ordlnk ol = rdc.ordlnks.Where(w => (w.orderid1 == orderid_sales || w.orderid2 == orderid_sales) && w.ordertype2.ToLower() == targetOrderType).OrderByDescending(o => o.date_modified).FirstOrDefault();
        //        //No related orders matching the target type, return null
        //        if (ol == null)
        //            return null;
        //        string targetID = ol.orderid2;
        //        switch (targetOrderType)
        //        {
        //            case "quote":
        //                {
        //                    return (ordhed_quote)rdc.ordhed_quotes.Where(w => w.unique_id == targetID).FirstOrDefault();
        //                }
        //            case "sales":
        //                {
        //                    return (ordhed_sale)rdc.ordhed_sales.Where(w => w.unique_id == targetID).FirstOrDefault();
        //                }
        //            case "invoice":
        //                {
        //                    return (ordhed_invoice)rdc.ordhed_invoices.Where(w => w.unique_id == targetID).FirstOrDefault();
        //                }
        //        }

        //        return null;

        //    }
        //}

        private object GetOrdersRelatedToDealheader(dealheader dealheader, string targetOrderType)
        {
            ordhed_quote dealheaderQuote = null;
            ordhed_sale dealheaderSale = null;

            //using (RzDataContext rdc = new RzDataContext())
            //{
            //    dealheaderQuote = rdc.ordhed_quotes.Where(w => w.unique_id == dealheader.unique_id).FirstOrDefault();
            //    if (dealheaderQuote != null)
            //        dealheaderSale = (ordhed_sale)GetRelatedOrders(dealheaderQuote.unique_id, targetOrderType);

            //}

            List<object> orderList = null;
            using (RzDataContext rdc = new RzDataContext())
                orderList = GetRelatedOrders(rdc, dealheaderQuote.unique_id);




            foreach (object o in orderList)
            {
                if (o is ordhed_quote)
                    dealheaderQuote = (ordhed_quote)o;
                else if (o is ordhed_sale)
                    dealheaderSale = (ordhed_sale)o;
            }



            if (targetOrderType == "quote")
                return dealheaderQuote;
            else
                return dealheaderSale;


        }

        //private static object GetRelatedOrders(object baseObj, string relatedOrderType)
        //{
        //    //baseObj is the object for which we are seeking related orders
        //    //relatedType is the orderType we are seeking.
        //    dealheader d = null;
        //    ordhed_quote q = null;
        //    ordhed_sale s = null;
        //    ordhed_invoice i = null;

        //    switch (relatedOrderType)
        //    {
        //        case "dealheader":
        //            {
        //                d = (dealheader)baseObj;
        //                break;
        //            }
        //        case "quote":
        //            {
        //                q = (ordhed_quote)baseObj;
        //                break;

        //            }
        //        case "sale":
        //            {
        //                s = (ordhed_sale)baseObj;
        //                break;
        //            }
        //        case "invoice":
        //            {
        //                i = (ordhed_invoice)baseObj;
        //                break;
        //            }


        //    }

        //    if (d != null)
        //    {

        //    }
        //    else if (q != null)
        //    {

        //    }
        //    else if (s != null)
        //    {

        //    }

        //    else if (i != null)
        //    {

        //    }
        //    else
        //        return null;




        //    using (RzDataContext rdc = new RzDataContext())
        //    {
        //        switch (relatedOrderType)
        //        {
        //            case "dealheader":
        //                {
        //                    if (baseObj is dealheader)
        //                        return (dealheader)baseObj;
        //                    else if (baseObj is ordhed_quote)
        //                    {
        //                        ordhed_quote q = (ordhed_quote)baseObj;
        //                        List<string> quote_lineIDs = rdc.orddet_quotes.Where(w => w.base_ordhed_uid == q.unique_id && (w.base_ordhed_uid ?? "").Length > 0).Select(s => s.unique_id).ToList();
        //                        if (quote_lineIDs != null && quote_lineIDs.Count > 0)
        //                        {
        //                            dealheader ret = rdc.dealheaders.Where(w => w.unique_id == quote_lineIDs[0]).FirstOrDefault();
        //                            return ret;
        //                        }

        //                    }
        //                    else if (baseObj is ordhed_sale)
        //                    {
        //                        ordhed_sale s is
        //                    }




        //                    break;
        //                }
        //            case "quote":
        //                {
        //                    if (baseObj is ordhed_quote)
        //                        return (ordhed_quote)baseObj;
        //                    break;

        //                }
        //            case "sale":
        //                {
        //                    if (baseObj is ordhed_sale)
        //                        return (ordhed_sale)baseObj;
        //                    break;


        //                }
        //            case "invoice":
        //                {
        //                    if (baseObj is ordhed_invoice)
        //                        return (ordhed_invoice)baseObj;

        //                    break;
        //                }


        //        }
        //    }



        //    return null;
        //}

        //private static object GetRelatedOrdersDealHeader(string relatedType)
        //{
        //    throw new NotImplementedException();
        //}

        //private static object GetRelatedOrdersQuote(string relatedType)
        //{
        //    throw new NotImplementedException();
        //}

        //private static object GetRelatedOrdersSale(string relatedType)
        //{
        //    throw new NotImplementedException();
        //}

        //private static dealheader GetOpportunityDealheader(dealheader rzObject)
        //{
        //    dealheader ret = null;
        //    if (rzObject is dealheader)
        //        ret = (dealheader)rzObject;

        //    else if (rzObject is ordhed)
        //    {
        //        ordhed o = (ordhed)rzObject;
        //        List<dealheader> dealheaderList = (List<dealheader>)GetRelatedOrders(o, "dealheader");
        //        ret = dealheaderList[0];
        //    }

        //    return ret;
        //}

        //private static ordhed_quote GetOpportunityQuote(ordhed_quote rzObject)
        //{
        //    ordhed_quote ret = null;
        //    //Quote Object
        //    if (rzObject is ordhed_quote)
        //        ret = (ordhed_quote)rzObject;
        //    //DealheaderObject
        //    else if (rzObject is dealheader)
        //    {
        //        dealheader d = (dealheader)rzObject;
        //        List<ordhed_quote> dealList = (List<ordhed_quote>)GetRelatedOrders(d, "quote");
        //        if (dealList != null)
        //            if (dealList.Count > 0)
        //                ret = (ordhed_quote)dealList[0];
        //    }

        //    //Orhded Object
        //    else if (rzObject is ordhed)
        //    {
        //        ordhed_quote o = (ordhed_quote)rzObject;
        //        List<ordhed_quote> ordhedList = (List<ordhed_quote>)GetRelatedOrders(o, "quote");
        //        if (ordhedList != null)
        //            if (ordhedList.Count > 0)
        //                ret = ordhedList[0];
        //    }

        //    return ret;
        //}


        //private static ordhed_invoice GetOpportunityInvoice(ordhed_invoice rzObject)
        //{
        //    dealheader d = null;
        //    //Is this object an invoice?
        //    if (rzObject is ordhed_invoice)
        //        return (ordhed_invoice)rzObject;
        //    ordhed o = null;
        //    if (rzObject is dealheader)
        //    {
        //        //Don't bother trying to get quote_line_uid then relate to line, then get the invoice, just do that for ordheds.
        //        return null;
        //    }



        //    List<ordhed_invoice> iList = (List<ordhed_invoice>)GetRelatedOrders(rzObject, "invoice");

        //    if (iList == null)
        //        return null;
        //    if (iList.Count == 0)
        //        return null;
        //    if (iList.Count > 1)
        //        return null;
        //    return iList[0];

        //}

        private static string GetHubsotDealStageFromRzOpportunityStage(object rzObject)
        {
            using (RzDataContext rdc = new RzDataContext())
            {
                string strOppStage = "";
                if (rzObject is dealheader)
                {
                    dealheader d = (dealheader)rzObject;
                    strOppStage = d.opportunity_stage;
                }

                if (rzObject is ordhed)
                {
                    ordhed o = (ordhed)rzObject;
                    if (string.IsNullOrEmpty(o.opportunity_stage))//not identified on ordhed, let's derive from sale order.  If it's an invoice, it can't be voided, so unless it's a voided sale we're loading opp stage should be sale won. 
                    {
                        //Formal Quote, might be voided
                        ordhed_quote quote = rdc.ordhed_quotes.Where(w => w.unique_id == o.unique_id).FirstOrDefault();
                        ordhed_sale sale = rdc.ordhed_sales.Where(w => w.unique_id == o.unique_id).FirstOrDefault();

                        if (quote != null && quote.isvoid.Value == true)
                        {
                            o.opportunity_stage = OpportunityStage.sale_lost.ToString();
                            rdc.SubmitChanges();
                        }
                        else if (sale != null)
                        {
                            if (sale.isvoid == true)
                                o.opportunity_stage = OpportunityStage.sale_lost.ToString();
                            else
                                o.opportunity_stage = OpportunityStage.sale_won.ToString();
                            rdc.SubmitChanges();
                        }
                    }
                    else
                        strOppStage = o.opportunity_stage;

                }


                if (strOppStage.ToLower().Trim().Contains("won"))
                    return HubspotApi.DealStage.sale_won;
                else if (strOppStage.ToLower().Trim().Contains("lost"))
                    return HubspotApi.DealStage.sale_lost;
                else if (strOppStage.ToLower().Trim().Contains("created"))
                    return HubspotApi.DealStage.formal_quote_created;
                else if (strOppStage.ToLower().Trim().Contains("rfq"))
                    return HubspotApi.DealStage.rfq_received;

                return null;
            }


        }
        private static HubspotApi.Contact CreateHubspotContact(companycontact c, string contactSource)
        {
            SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "Creating Hubspot contact for " + c.primaryemailaddress, true, "Rz");
            Dictionary<string, string> props = GenerateHubspotContactProperties(c);
            //We'll want the Hubspot Owner right?  Probably expecially if no company existis at ALL in HS, would nee to link it to a user.


            //string ownerEmail = GetHubspotOwnerEmailFromRzObject(x, c);
            //if (string.IsNullOrEmpty(ownerEmail))
            //    return null;


            if (props == null)
                return null;
            string message = "<b>Details</b><br />";
            foreach (KeyValuePair<string, string> kvp in props)
            { message += kvp.Key + ": " + kvp.Value + "<br />"; }


            HubspotApi.Contact ret = HubspotApi.Contacts.CreateHubspotContact(props, contactSource);
            if (ret.Properties == null)
                return null;
            SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "Rz Deal: Hubspot Contact successfully created for " + c.primaryemailaddress + " (VID: " + ret.vid + ")", true, "Rz");
            SystemLogic.Email.SendMail(SystemLogic.Email.EmailGroupAddress.RzAlert, SystemLogic.Email.EmailGroup.Systems, "HubSpot contact created via Rz Deal Sync: " + c.primaryemailaddress, message);
            HubspotApi.Associations ass = HubspotApi.Deals.CreateDealAssociations(c.primaryemailaddress);
            return ret;


        }
        private static Dictionary<string, string> GenerateHubspotContactProperties(companycontact c)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            //FirstName *Required
            KeyValuePair<string, string> kvp = GenerateHubspotContactProperty(c, "firstname");
            if (string.IsNullOrEmpty(kvp.Value))
                return null;
            props.Add(kvp.Key, kvp.Value);

            //Email *Required
            kvp = GenerateHubspotContactProperty(c, "email");
            if (string.IsNullOrEmpty(kvp.Value))
                return null;
            props.Add(kvp.Key, kvp.Value);

            //website
            kvp = GenerateHubspotContactProperty(c, "website");
            if (!string.IsNullOrEmpty(kvp.Value))
                props.Add(kvp.Key, kvp.Value);

            //lastname
            kvp = GenerateHubspotContactProperty(c, "lastname");
            if (!string.IsNullOrEmpty(kvp.Value))
                props.Add(kvp.Key, kvp.Value);


            return props;
        }
        private static KeyValuePair<string, string> GenerateHubspotContactProperty(companycontact c, string key)
        {


            string value = null;
            string valueText = null;
            List<string> requiredContactProperties = new List<string>() { "email", "firstname" };

            switch (key)
            {
                case "firstname":
                    {
                        value = c.first_name.Trim().ToLower();
                        value = Tools.Strings.CapitalizeFirstLetter(value);
                        valueText = "first name";
                        break;
                    }
                case "email":
                    {
                        value = c.primaryemailaddress.Trim().ToLower();
                        valueText = "email address";
                        break;
                    }
                case "lastname":
                    {
                        var names = c.contactname.Split(' ');
                        if (names.Length > 1)
                        {
                            value = Tools.Strings.CapitalizeFirstLetter(value);
                            valueText = "last name";
                        }
                        else
                            return new KeyValuePair<string, string>();//retun null if no last name
                        break;
                    }
                case "website":
                    {
                        MailAddress address = new MailAddress(c.primaryemailaddress);
                        string website = address.Host.Trim().ToLower();
                        value = website;
                        valueText = "website";
                        break;
                    }
                    //case "company":
                    //    {
                    //        string company = c.companyname.Trim().ToLower();
                    //        value = c.companyname.Trim().ToLower();
                    //        valueText = "email address";
                    //        break;
                    //    }

            }

            //first name and email are required
            if (requiredContactProperties.Contains(key))
            {
                if (string.IsNullOrEmpty(value))
                    //value = x.Leader.AskForString("Please enter a " + valueText + " for this contact.");
                    return new KeyValuePair<string, string>();
                if (String.IsNullOrEmpty(value))
                {
                    //x.Leader.Error("Sorry, cannot create hubspot deal without the " + valueText);
                    return new KeyValuePair<string, string>();
                }
            }







            KeyValuePair<string, string> ret = new KeyValuePair<string, string>(key, value);
            return ret;
        }
        private string GetHubspotOwnerEmailFromRzObject(object rzObject)
        {

            string ownerRzUserID = null;

            if (rzObject is dealheader)
            {
                dealheader d = (dealheader)rzObject;
                ownerRzUserID = d.base_mc_user_uid;
            }

            else if (rzObject is ordhed)
            {
                ordhed o = (ordhed)rzObject;
                ownerRzUserID = o.base_mc_user_uid;
            }
            else if (rzObject is companycontact)
            {
                companycontact cc = (companycontact)rzObject;
                ownerRzUserID = cc.base_mc_user_uid;
            }
            n_user u;
            using (RzDataContext rdc = new RzDataContext())
                u = rdc.n_users.Where(w => w.unique_id == ownerRzUserID).FirstOrDefault();//.GetById(x, ownerRzUserID);
            if (u == null)
                return null;

            //Vendors shold be assigned to Phil
            if (u.name == "Vendor")
                return "pscott@sensiblemicro.com";

            if (!Tools.Email.IsEmailAddress(u.email_address))
                return null;


            return u.email_address.ToLower().Trim();
        }






        public static bool CheckCloseRzObjectFromHubspot(object rzObject, HubspotApi.Deal deal)
        {
            string dealstage = deal.properties.Where(w => w.Key == "dealstage").Select(s => s.Value.value).FirstOrDefault();
            string sales_lost_reason = deal.properties.Where(w => w.Key == "closed_lost_reason").Select(s => s.Value.value).FirstOrDefault();
            string outReason = "";
            SetRzOpportunityLost(rzObject, sales_lost_reason, out outReason);
            return true;

        }

        public static bool SetRzOpportunityLost(object rzObject, string inputReason, out string outPutReason)
        {
            outPutReason = "";
            string selectedReason = inputReason;


            if (String.IsNullOrEmpty(selectedReason))
            {
                //x.Leader.Error("You must choose a reason. ");
                return false;
            }


            using (RzDataContext rdc = new RzDataContext())
            {
                if (rzObject is dealheader)
                {
                    dealheader d = (dealheader)rzObject;
                    dealheader currentBatch = rdc.dealheaders.Where(w => w.unique_id == d.unique_id).FirstOrDefault();
                    currentBatch.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
                    currentBatch.ClosureReason = selectedReason;
                    currentBatch.is_closed = true;


                }
                else if (rzObject is ordhed)
                {
                    //ordhed_quote q = rdc.ordhed_quotes.Where(w => w.unique_id == o.unique_id).FirstOrDefault();
                    ordhed oh = (ordhed)rzObject;
                    ordhed o = rdc.ordheds.Where(w => w.unique_id == oh.unique_id).FirstOrDefault();
                    o.opportunity_stage = SM_Enums.OpportunityStage.sale_lost.ToString();
                    o.opportunity_lost_reason = selectedReason;
                    o.isclosed = true;
                }

                rdc.SubmitChanges();
            }

            return true;
        }


        //public static void SynchronizeHubspotDeals2(DateTime startDate, out int UpdatedDealCount)
        //{
        //    UpdatedDealCount = 0;
        //    //Get all modified dealheaders, ordhed_quotes, ordhed_sales, ordhed_invoices.
        //    //Group all related orders together, and ensure they have same Hub ID, set that value if not already set.
        //    //For each HubID itendified per above, update each deal with the proper uids.


        //    //Everything that needs to sync would have been modified today.
        //    List<dealheader> modifiedBatches = new List<dealheader>();
        //    List<ordhed_quote> modifiedQuotes = new List<ordhed_quote>();
        //    List<ordhed_sale> modifiedSales = new List<ordhed_sale>();
        //    List<ordhed_invoice> modifiedInvoices = new List<ordhed_invoice>();
        //    List<orddet_quote> quoteLines = new List<orddet_quote>();//For correlating deals to sales
        //    List<orddet_line> orddetLines = new List<orddet_line>();//For correlating deals to sales



        //    //Dictionary to relate a HubID with multiple Rz Order Objects
        //    Dictionary<long, List<object>> dictHubIdAndRzObjectList = new Dictionary<long, List<object>>();
           

        //    using (RzDataContext rdc = new RzDataContext())
        //    {
        //        //Objects                
        //        modifiedSales = rdc.ordhed_sales.Where(w => w.date_modified >= startDate.Date).ToList();
        //        modifiedQuotes = rdc.ordhed_quotes.Where(w => w.date_modified >= startDate.Date).ToList();
        //        modifiedBatches = rdc.dealheaders.Where(w => w.date_modified >= startDate.Date).ToList();


        //        //I don't need / want to sync all related orders, would be nice, but messy in code.  Rz already handles opportunity stage.  We're just updating / creating Hubspot Deals with the latest stage.
        //        Deal d = null;


        //        //start with today's batches. Create any deals as needed then add them to the dict
        //        foreach (dealheader dh in modifiedBatches)
        //        {

        //            if (dh.hubspot_deal_id == 0)
        //                d = CreateHubspotDeal(d);
        //            else
        //                d = UpdateHubspotDeal(dh);
        //            if (d == null)
        //                throw new Exception("Failed to create deal for dealheader: "+dh.dealheader_name);
        //            KeyValuePair<long, List<object>> kvp = new KeyValuePair<long, List<object>>() {d.dealId, }

        //        }




        //        List<object> relatedObjectList = new List<object>();
        //        foreach (ordhed_sale s in modifiedSales)
        //        {
        //            if (!relatedObjectList.Contains(s))
        //                relatedObjectList.Add(s);
        //            string quoteID = rdc.ordlnks.Where(w => w.ordertype1 == "Sale" && w.ordertype2 == "Quote").Select(s => s.orderid2).FirstOrDefault();


        //        }

        //        foreach (ordhed_sale s in modifiedSales)
        //        {
        //            //Can't have or update deals if no Contact ID.
        //            if (string.IsNullOrEmpty(s.base_companycontact_uid))
        //                continue;

        //            long hubID = s.hubspot_deal_id.Value;
        //            if (hubID > 0)
        //                d = HubspotApi.Deals.GetDealByID(hubID);
        //            if (d == null)
        //                d = CreateHubspotDeal(s);
        //            else
        //                syncedHubIds.Add(d.dealId);
        //            SystemLogic.Logs.LogEvent(LogType.Information, "Successfully synced HubID: " + hubID + " for Sale: " + s.ordernumber, false);
        //        }
        //        foreach (ordhed_quote q in modifiedQuotes)
        //        {
        //            //Can't have or update deals if no Contact ID.
        //            if (string.IsNullOrEmpty(q.base_companycontact_uid))
        //                continue;
        //            long hubID = q.hubspot_deal_id.Value;

        //            d = HubspotApi.Deals.GetDealByID(hubID);
        //            if (d == null || hubID == 0)
        //                d = CreateHubspotDeal(q);
        //            else
        //                UpdateHubspotDeal(q);
        //            syncedHubIds.Add(d.dealId);
        //            SystemLogic.Logs.LogEvent(LogType.Information, "Successfully synced HubID: " + hubID + " for Quote: " + q.ordernumber + "Old Value: ", false);
        //        }
        //        foreach (dealheader b in modifiedBatches)
        //        {
        //            //Can't have or update deals if no Contact ID.
        //            if (string.IsNullOrEmpty(b.contact_uid))
        //                continue;
        //            long hubID = 0;
        //            //b.hubspot_deal_id can be null
        //            if (b.hubspot_deal_id == null || b.hubspot_deal_id.Value == 0)
        //            {
        //                d = CreateHubspotDeal(b);
        //                hubID = d.dealId;
        //            }
        //            else
        //                d = UpdateHubspotDeal(b);
        //            hubID = b.hubspot_deal_id.Value;


        //            //Possible deal creation fails due to things like no contact being set.  
        //            if (d == null || hubID == 0)
        //            {
        //                SystemLogic.Logs.LogEvent(LogType.Warning, "Deal not created for dealheader ID: " + b.unique_id + "(" + b.dealheader_name + ")");
        //                continue;
        //            }

        //            syncedHubIds.Add(d.dealId);
        //            SystemLogic.Logs.LogEvent(LogType.Information, "Successfully synced HubID: " + hubID + " for Batch " + b.dealheader_name, false);
        //        }

        //        UpdatedDealCount = syncedHubIds.Count();

        //    }


        //    //UpdatedDealCount = 0;
        //    //return;
        //}




        public static void SynchronizeHubspotDeals(DateTime startDate, out int UpdatedDealCount)
        {
            UpdatedDealCount = 0;

            //Everything that needs to sync would have been modified today.
            List<dealheader> modifiedBatches = new List<dealheader>();
            List<ordhed_quote> modifiedQuotes = new List<ordhed_quote>();
            List<ordhed_sale> modifiedSales = new List<ordhed_sale>();
            List<ordhed_invoice> modifiedInvoices = new List<ordhed_invoice>();
            List<orddet_quote> quoteLines = new List<orddet_quote>();//For correlating deals to sales
            List<orddet_line> orddetLines = new List<orddet_line>();//For correlating deals to sales

            //To avoid doubling up, add any synced items ids to a list
            List<long> syncedHubIds = new List<long>();

            using (RzDataContext rdc = new RzDataContext())
            {
                //Objects
                //modifiedInvoices = rdc.ordhed_invoices.Where(w => w.date_modified >= startDate).ToList();
                modifiedSales = rdc.ordhed_sales.Where(w => w.date_modified >= startDate.Date).ToList();
                modifiedQuotes = rdc.ordhed_quotes.Where(w => w.date_modified >= startDate.Date).ToList();
                modifiedBatches = rdc.dealheaders.Where(w => w.date_modified >= startDate.Date).ToList();



                //string currentStage = null;
                //I don't need / want to sync all related orders, would be nice, but messy in code.  Rz already handles opportunity stage.  We're just updating / creating Hubspot Deals with the latest stage.
                Deal d = null;


                foreach (ordhed_sale s in modifiedSales)
                {
                    //Can't have or update deals if no Contact ID.
                    if (string.IsNullOrEmpty(s.base_companycontact_uid))
                        continue;

                    long hubID = s.hubspot_deal_id.Value;
                    if (hubID > 0)
                        d = HubspotApi.Deals.GetDealByID(hubID);
                    if (d == null)
                        d = CreateHubspotDeal(s);
                    else
                        syncedHubIds.Add(d.dealId);
                    SystemLogic.Logs.LogEvent(LogType.Information, "Successfully synced HubID: " + hubID + " for Sale: " + s.ordernumber, false);
                }
                foreach (ordhed_quote q in modifiedQuotes)
                {
                    //Can't have or update deals if no Contact ID.
                    if (string.IsNullOrEmpty(q.base_companycontact_uid))
                        continue;
                    long hubID = q.hubspot_deal_id.Value;

                    d = HubspotApi.Deals.GetDealByID(hubID);
                    if (d == null || hubID == 0)
                        d = CreateHubspotDeal(q);
                    else
                        UpdateHubspotDeal(q);
                    syncedHubIds.Add(d.dealId);
                    SystemLogic.Logs.LogEvent(LogType.Information, "Successfully synced HubID: " + hubID + " for Quote: " + q.ordernumber + "Old Value: ", false);
                }
                foreach (dealheader b in modifiedBatches)
                {
                    //Can't have or update deals if no Contact ID.
                    if (string.IsNullOrEmpty(b.contact_uid))
                        continue;
                    long hubID = 0;
                    //b.hubspot_deal_id can be null
                    if (b.hubspot_deal_id == null || b.hubspot_deal_id.Value == 0)
                    {
                        d = CreateHubspotDeal(b);
                        hubID = d.dealId;
                    }
                    else
                        d = UpdateHubspotDeal(b);
                    hubID = b.hubspot_deal_id.Value;


                    //Possible deal creation fails due to things like no contact being set.  
                    if (d == null || hubID == 0)
                    {
                        SystemLogic.Logs.LogEvent(LogType.Information, "Deal not created for dealheader ID: " + b.unique_id + "(" + b.dealheader_name + ")");
                        continue;
                    }

                    syncedHubIds.Add(d.dealId);
                    SystemLogic.Logs.LogEvent(LogType.Information, "Successfully synced HubID: " + hubID + " for Batch " + b.dealheader_name, false);
                }

                UpdatedDealCount = syncedHubIds.Count();

            }

        }


    }
    //End Hubspot Management
}




