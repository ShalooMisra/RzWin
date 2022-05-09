using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensibleDAL.dbml;

namespace SensibleDAL
{
    public class RzLogic
    {

        public class RzDomainMatchResults
        {
            public companycontact rzContact { get; set; }
            public company rzCompany { get; set; }
            public List<companycontact> rzContactList { get; set; }
            public List<company> rzCompanyList { get; set; }
            public n_user rzCompanyAgent { get; set; }
            public string matchResultLog { get; set; }
            public bool createIfMissing { get; set; }
        }

        public static void MatchVisitorToRzByDomain(RzDataContext rdc, string customerEmail, bool createIfMissing, string[] firstLastPhone, out RzDomainMatchResults dmr)
        {
            dmr = new RzDomainMatchResults();
            dmr.createIfMissing = createIfMissing;


            string strFirstName = firstLastPhone[0];
            string strLastName = firstLastPhone[1];
            string strPhone = firstLastPhone[2];
            //Goal, after algorithm, have list for contacts, list for companies
            //Do final logic based on counts of these lists.  
            //Example: if both lists = Count 1, then we have identified single exact match for both
            //if Contacts <= 0 no contact found, and not able to created, if contacts >=1 multiple contacts.
            //Sane logic applies to company.
            try
            {
                //Validate the input string for security
                //Note that I can't use dmr.customer email to set values inside this dmrbecuase it's part of an out parameter
                //Exampe, can't do dmr.rzContactList = rdc.companycontacts.Where(w => w.primaryemailaddress == dmr.customerEmail).ToList();
                //That's why I don't reuse dmr.customerEmail below.
                if (!Tools.Email.IsEmailAddress(customerEmail))
                    throw new Exception(customerEmail + " is not a valid email address.");



                //Company and Contact List Variables
                dmr.rzContactList = new List<companycontact>();
                dmr.rzCompanyList = new List<company>();

                //The email from the quote:  "jesus.gonzalez@velocityelec.com";
                //Clean the string
                customerEmail = customerEmail.Trim().ToLower();

                //CONTACT Matchins
                //Get the contact by email            
                dmr.rzContactList = rdc.companycontacts.Where(w => w.primaryemailaddress == customerEmail).ToList();

                //No contacts found with this address, create      
                string logContactCreated = "";
                if (dmr.rzContactList.Count <= 0)
                {
                    dmr.matchResultLog += "CreateIfMissing flag is currently set to <b>'" + dmr.createIfMissing.ToString() + "'</b><em></em><br />";
                    if (dmr.createIfMissing == true)
                    {
                        dmr.rzContactList.Add(Contacts.CreateRzCompanyContact(rdc, customerEmail, strFirstName, strLastName, strPhone, "Portal Quote"));
                        logContactCreated += "Contact created in Rz for " + customerEmail + "<br />";
                    }
                    else
                        logContactCreated += "No contact found, and none created in Rz. <br />";

                }


                //COMPANY Matching       
                //At this point we may or may not have a contact.  In either case there may or may not be a comapany ID.  IF not, we still need to fall back on email domain to idendtify
                foreach (companycontact cc in dmr.rzContactList)
                {
                    company comp = rdc.companies.Where(w => w.unique_id == cc.base_company_uid).FirstOrDefault();
                    if (comp != null && !dmr.rzCompanyList.Contains(comp))
                        dmr.rzCompanyList.Add(comp);
                }
                //Also get companies that match email, could be they are found, and might be the correct comapny too.
                foreach (company c in Companies.GetRzCompanyListByEmailDomain(rdc, customerEmail))
                {
                    List<string> existingCompanyIds = new List<string>();
                    existingCompanyIds = dmr.rzCompanyList.Select(s => s.unique_id).Distinct().ToList();
                    if (!existingCompanyIds.Contains(c.unique_id))
                        dmr.rzCompanyList.Add(c);
                }



                //Now check counts of resulting Contact and Company lists
                //Make sure to set a value to out parameters
                dmr.rzContact = null;
                dmr.rzCompany = null;

                string logResults = "";
                string logContactMatch = "";
                string logCompanyMatch = "";



                if (dmr.rzContactList.Count != 1)
                    logContactMatch += LogUnmatchedRzObject("contact", dmr);
                else
                    dmr.rzContact = dmr.rzContactList[0];
                if (dmr.rzCompanyList.Count != 1)
                    logCompanyMatch += LogUnmatchedRzObject("company", dmr);
                else
                    dmr.rzCompany = dmr.rzCompanyList[0];

                //Handle Company Linkage if possible            
                HandleRzContactCompanyLinkage(rdc, dmr);

                //Set the Agent Object
                if (dmr.rzCompany != null)
                    dmr.rzCompanyAgent = Companies.GetRzAgentForCompany(rdc, dmr.rzCompany);




                string matchedContactName = "";
                string matchedContactEmail = "";
                string matchedCompany = "";
                string matchedAgent = "";
                if (dmr.rzContact != null)
                {
                    if (string.IsNullOrEmpty(dmr.rzContact.contactname))
                        matchedContactName = "No Contact Name Set.";
                    else
                        matchedContactName = dmr.rzContact.contactname.Trim();
                    matchedContactEmail = dmr.rzContact.primaryemailaddress.ToLower().Trim() ?? "No Contact Email Detected";
                }

                if (dmr.rzCompany != null)
                    matchedCompany = dmr.rzCompany.companyname ?? "No Company Name Set.";
                if (dmr.rzCompanyAgent != null)
                    matchedAgent = dmr.rzCompanyAgent.name ?? "No Agent Name Set.";

                //Log Matched Objects and log results of the process for debug /notify
                logResults = "<p style=\"font-size:16px; font-weight:bold;\">Rz Match Log:</p>";
                logResults += "<b>Matched Contact: </b>" + matchedContactName + " (" + matchedContactEmail + ")<br />";
                logResults += "<b>Matched Company: </b>" + matchedCompany + "<br />";
                logResults += "<b>Matched Agent: </b>" + matchedAgent + "<br />";



                dmr.matchResultLog = logResults + logContactCreated + logContactMatch + logCompanyMatch;

            }
            catch (Exception ex)
            {
                dmr = null;

            }
        }

        private static string LogUnmatchedRzObject(string type, RzDomainMatchResults dmr)
        {
            string ret = "<br />";
            //ret += "<em>(Unidentified)</em>&nbsp;&nbsp;";
            int count = 0;

            //Get detail on why no match
            switch (type.ToLower())
            {
                case "company":
                    {
                        count = dmr.rzCompanyList.Count();
                        break;
                    }
                case "contact":
                    {
                        count = dmr.rzContactList.Count();
                        break;
                    }

            }

            //No objects found
            if (count == 0)
            {

            }


            //more than 1 object found
            if (count > 1)
            {
                ret += buildPotentialMatchList(type, count, dmr);
            }

            return ret;

        }

        private static string buildPotentialMatchList(string type, int count, RzDomainMatchResults dmr)
        {
            string ret = "<b>" + count + " Potential " + Tools.Strings.CapitalizeFirstLetter(type) + " Matches Found:</b><br />";
            switch (type.ToLower())
            {
                case "company":
                    {
                        foreach (company c in dmr.rzCompanyList)
                            ret += c.companyname + "<br />";
                        break;
                    }
                case "contact":
                    {
                        foreach (companycontact c in dmr.rzContactList)
                            ret += c.contactname + "(" + c.primaryemailaddress + ") Company: " + c.companyname + " <br />";
                        break;
                    }

            }

            return ret;
        }

        private static void HandleRzContactCompanyLinkage(RzDataContext rdc, RzDomainMatchResults dmr)
        {


            if (dmr.rzContact != null)
            {
                //If we are missing a companyid, we need to try to update to a proper company if matched.
                if (string.IsNullOrEmpty(dmr.rzContact.base_company_uid))
                {
                    //retrieve the companycontact dbml object for updating
                    companycontact c = rdc.companycontacts.Where(w => w.unique_id == dmr.rzContact.unique_id).FirstOrDefault();

                    //If we have an actual company, link the contact to there.
                    if (dmr.rzCompany != null)
                    {
                        c.base_company_uid = dmr.rzCompany.unique_id;
                        c.companyname = dmr.rzCompany.companyname;
                    }
                    else
                    {
                        //Retrieved teh unidentified coompany object from dbml in case it's name changes, so we get an accurate contact.companyname
                        company unidentComp = Companies.UnidentifiedCompanyAccount;
                        c.base_company_uid = unidentComp.unique_id;
                        c.companyname = unidentComp.companyname;
                        dmr.rzCompany = unidentComp;
                    }



                    //Submit changes to DB
                    rdc.SubmitChanges();

                    //refresh the contact object in dmr
                    dmr.rzContact = c;
                }
            }


            //If Company si still null, set to unassigned 
            if (dmr.rzCompany == null)
            {
                //Set the company to unidentified
                company c = Companies.UnidentifiedCompanyAccount;
                //refresh the contact object in dmr
                if (c != null)
                    dmr.rzCompany = c;
            }
        }



        public class Business
        {

            public static DateTime startOfSensibleBusinessDay = GetStartOfSensibleBusinessDay();

            private static DateTime GetStartOfSensibleBusinessDay()
            {
                DateTime ret = DateTime.Today;
                TimeSpan ts = new TimeSpan(9, 00, 0);//as of 2019, official start time is 9AM
                ret = ret.Date + ts;
                return ret;
            }


        }


        public class Teams
        {
            public static List<n_user> GetUsersForTeams(RzDataContext rdc, List<string> teamNames, bool includeInactive = false)
            {
                List<n_user> ret = new List<n_user>();
                foreach (string s in teamNames)
                {
                    n_team t = rdc.n_teams.Where(w => w.name.ToLower() == s).FirstOrDefault();
                    if (t != null)
                    {
                        List<n_member> membersOfTeam = rdc.n_members.Where(w => w.the_n_team_uid == t.unique_id).ToList();
                        foreach (n_member m in membersOfTeam)
                        {
                            n_user u = rdc.n_users.Where(w => w.unique_id == m.the_n_user_uid).FirstOrDefault();
                            if (u != null)
                            {
                                if (includeInactive)
                                {
                                    if (!ret.Contains(u))
                                        ret.Add(u);
                                }
                                else
                                {
                                    if (!u.is_inactive ?? false)
                                        if (!ret.Contains(u))
                                            ret.Add(u);
                                }



                            }
                        }
                    }
                }
                return ret;
            }

        }
        public class Users
        {

            //Users
            public static List<n_user> GetPhoneUsers(RzDataContext rdc)
            {
                List<n_user> phoneUsers = new List<n_user>();
                phoneUsers = Teams.GetUsersForTeams(rdc, new List<string>() { "Sales" }, false);
                phoneUsers = phoneUsers.Where(w => w.name != "_PhoneReportDummy").ToList();

                return phoneUsers;

            }


        }

        public class OrderBatch
        {
            public static long GetNextBatchNumberLinq()
            {
                using (RzDataContext rdc = new RzDataContext())
                {
                    n_set nextBatchSetting = rdc.n_sets.Where(w => w.name == "current_orderbatch_number").FirstOrDefault();
                    string s = nextBatchSetting.setting_value;
                    long l = 0;
                    if (!long.TryParse(s, out l))
                        throw new Exception("Next batch number not convertible to Int64.  Batch not created.");
                    //Iterate to next batch number
                    l++;
                    //Update the setting with this new number.

                    nextBatchSetting.setting_value = l.ToString();
                    rdc.SubmitChanges();
                    return l;
                }
                   
            }

        }





    }





    public class Contacts
    {
        public static companycontact CreateRzCompanyContact(RzDataContext rdc, string customerEmail, string firstName, string lastName, string phone, string source)
        {
            companycontact ret = new companycontact();


            ret.unique_id = Guid.NewGuid().ToString();
            ret.first_name = firstName ?? "";
            ret.contactname = BuildContactNameString(firstName, lastName);
            ret.source =source;
            ret.primaryphone = phone ?? "";
            ret.primaryemailaddress = customerEmail;
            //Default is unidentified.  Can be updated later in the process.
            ret.date_created = DateTime.Now;
            //ret.companyname = "Unidentified Portal Quote";
            //ret.base_company_uid = Companies.UnidentifiedCompanyID;
            rdc.companycontacts.InsertOnSubmit(ret);
            rdc.SubmitChanges();


            return ret;

        }

        private static string BuildContactNameString(string firstName, string lastName)
        {
            string nameString = firstName ?? "";
            if (!string.IsNullOrEmpty(lastName))
            {
                //add a space if we already have a first name
                if (!string.IsNullOrEmpty(firstName))
                    nameString += " ";
                nameString += lastName;
            }
            return nameString;
        }
    }

    public class Companies
    {
        public static string UnidentifiedCompanyID = "32d6b3b68a764e3893794ba7f481f30f";
        public static company UnidentifiedCompanyAccount = GetRzUnidentifiedCompany();
        private static company GetRzUnidentifiedCompany()
        {
            using (RzDataContext rdc = new RzDataContext())
                return rdc.companies.Where(w => w.unique_id == UnidentifiedCompanyID).SingleOrDefault();
        }

        public static List<company> GetRzCompanyListByEmailDomain(RzDataContext rdc, string emailAddress)
        {
            List<company> ret = new List<company>();
            string emailDomain = Tools.Email.ParseEmailDomain(emailAddress);
            //Match company by matching contact email address domain
            List<companycontact> contactsThatMatchDomain = new List<companycontact>();
            contactsThatMatchDomain = rdc.companycontacts.Where(w => w.primaryemailaddress.Trim().ToLower().Contains(emailDomain)).ToList();

            //List of unique_company Ids that can come from various projections / queries
            List<string> matchingCompanyIDs = new List<string>();
            foreach (companycontact c in contactsThatMatchDomain)
            {
                if (!string.IsNullOrEmpty(c.base_company_uid))
                    if (!matchingCompanyIDs.Contains(c.base_company_uid))
                        matchingCompanyIDs.Add(c.base_company_uid);
            }

            //Get companyIDs that match primarywebaddress
            matchingCompanyIDs.AddRange(rdc.companies.Where(w => w.primarywebaddress.Trim().ToLower().Contains(emailDomain)).Select(s => s.unique_id).ToList());

            foreach (string s in matchingCompanyIDs)
            {
                company c = rdc.companies.Where(w => w.unique_id == s).FirstOrDefault();
                if (c != null && !ret.Contains(c))
                    ret.Add(c);
            }

            return ret;

        }

        internal static n_user GetRzAgentForCompany(RzDataContext rdc, company rzCompany)
        {
            return rdc.n_users.Where(w => w.unique_id == rzCompany.base_mc_user_uid).FirstOrDefault();
        }
    }

}

