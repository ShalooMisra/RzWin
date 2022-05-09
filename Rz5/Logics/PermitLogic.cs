using System;
using NewMethod;

namespace Rz5
{
    public class PermitLogic : NewMethod.PermitLogic
    {
        public virtual bool IsHouseAccount(string username)
        {
            switch (username.ToLower())
            {
                case "":
                case "bad record":
                case "house account":
                case "house":
                case "unassigned":
                case "vendor":
                case "dead accounts (do not call)":
                    return true;
                default:
                    return false;
            }
        }

        public virtual bool CanBeViewedByCompany(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            //Super User
            if (u.SuperUser)
                return true;
            //Sales Assistat Team
            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;

            //Is the Company Owner
            n_user owner = n_user.GetById(context, x.UserID);
            if (owner == null)//If No Owner (ex-employee, allow open for reassign, etc)
                return true;
            if (x == null)//If no agent assigned?  Is that what this is?
                return true;

            //Is this user the Assigned Agent?
            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;
            String username = x.UserName;
            switch (x.ClassId.ToLower())
            {
                case "companycontact":
                    if (username == "")
                    {
                        companycontact contact = (companycontact)x;
                        company comp = contact.TheCompanyVar.RefGet(context);
                        if (comp != null)
                            username = comp.agentname;
                    }
                    break;
            }
            if (IsHouseAccount(username))
                return true;
            switch (x.ClassId.ToLower().Trim())
            {
                case "company":
                    {
                        company c = (company)x;
                        if (c == null)
                            return false;
                        //Vendor?                        
                        if (Tools.Strings.StrCmp(c.companytype, "vendor"))
                            return true;
                        //Is this company owned by a Team Member of which the current user is the Team Captain?
                        if (context.xUser.IsTeamCaptainOf(context, c.base_mc_user_uid))
                            return true;

                        //KT Allow Assistants to view Companies
                        if (u.IsAssistantTo(owner))
                            return true;

                        //Allow Team Leaders (i.e. assistants / RM's leaders) to view the assistant's accounts
                        if (context.xUser.IsAssistantLeaderTo(context, owner))
                            return true;


                        //Fall back on standard permit check
                        return CheckPermit(context, Permissions.ThePermits.ViewAllCompanies, u);


                    }
                case "ordhed_purchase":  //this never happens; ordhed doesn't pass to here
                    return true;
            }
            return false;

        }



        public virtual bool CanBeEditedByCompany(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {

            if (u.SuperUser)
                return true;

            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;



            //if (owner == null)
            //    return false;
            if (x == null)
                return true;
            if (!Tools.Strings.StrExt(x.UserID))
                return true;
            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;
            if (IsHouseAccount(x.UserName))
                return true;
            switch (x.ClassId.ToLower().Trim())
            {
                case "company":
                    {
                        company c = (company)x;
                        if (c == null)
                            return false;
                        //KT 9-23-2015 WTH is "is_vendor"                        
                        if (Tools.Strings.StrCmp(c.companytype, "vendor"))
                            return true;
                        //Is this company owned by a Team Member of which the current user is the Team Captain?
                        if (context.xUser.IsTeamCaptainOf(context, c.base_mc_user_uid))
                            return true;
                        //Assistant to      
                        n_user owner = n_user.GetById(context, x.UserID);
                        if (owner != null)
                        {
                            if (u.IsAssistantTo(owner))
                                return true;
                        }
                        return CheckPermit(context, Permissions.ThePermits.EditAllCompanies, u);

                    }
                case "ordhed_purchase":
                    return true;
            }

            return false;

        }
        public virtual bool CanBeDeletedByCompany(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (x == null)
                return true;
            if (u.SuperUser)
                return true;
            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;
            if (IsHouseAccount(x.UserName))
                return true;
            return CheckPermit(context, Permissions.ThePermits.DeleteAllCompanies, u);
        }

        public virtual bool CanBeViewedByContact(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (u.SuperUser)
                return true;

            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;



            //if (owner == null)
            //    return false;
            if (x == null)
                return true;

            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;
            String username = x.UserName;
            if (!Tools.Strings.StrExt(username))
            {
                companycontact contact = (companycontact)x;
                company comp = contact.TheCompanyVar.RefGet(context);
                if (comp != null)
                    username = comp.agentname;
            }
            if (IsHouseAccount(username))
                return true;
            if (u.IsOnTeamWith(context, x.UserID) && CheckPermit(context, Permissions.ThePermits.ViewAllContacts, u))
                return true;
            n_user owner = n_user.GetById(context, x.UserID);
            if (owner != null)
                if (u.IsAssistantTo(owner))
                    return true;
            if (u.IsTeamCaptainOf(context, x.UserID))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.ViewAllContacts, u);
        }
        public virtual bool CanBeEditedByContact(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (u.SuperUser)
                return true;

            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;


            //if (owner == null)
            //    return false;
            if (x == null)
                return true;

            if (!Tools.Strings.StrExt(x.UserID))
                return true;
            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;
            if (IsHouseAccount(x.UserName))
                return true;
            if (u.IsOnTeamWith(context, x.UserID) && CheckPermit(context, Permissions.ThePermits.EditAllContacts, u))
                return true;
            n_user owner = n_user.GetById(context, x.UserID);
            if (owner != null)
            {
                if (u.IsAssistantTo(owner))
                    return true;
            }

            return CheckPermit(context, Permissions.ThePermits.EditAllContacts, u);
        }

        public virtual bool ViewAccessByAssignedAgent(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {


            if (u.SuperUser)
                return true;

            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;
           

            n_user owner = n_user.GetById(context, x.UserID);
            if (owner == null)
                return false;

            if (x == null)
                return true;

            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;

            //Assitant To
            if (context.TheSysRz.ThePermitLogicRz.IsOwnedByAssistant(context, owner, u))
                return true;

            if (context.TheSysRz.ThePermitLogicRz.IsOwnedByAssistantsLeader(context, owner, u))
                return true;


            switch (x.UserName.ToLower())
            {
                case "":
                case "bad record":
                case "house account":
                case "house":
                case "unassigned":
                    return true;
            }

            return false;
        }




        //KT Override that accepts companyuid (string c)
        public virtual bool ViewAccessByAssignedAgent(ContextRz context, IAssignedAgent x, NewMethod.n_user u, string c)
        {

            string CompanyCurrentOwnerUID = context.SelectScalarString("select base_mc_user_uid from company where unique_id = '" + c + "'");
            //KT This so I can check the company's owner below, if house, allow access
            company TheCompany = (company)context.GetById("company", c);

            if (x == null)
                return true;

            if (u.SuperUser)
                return true;

            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;

            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;

            if (Tools.Strings.StrCmp(u.unique_id, CompanyCurrentOwnerUID))
                return true;
            //KT if company owner is house, allow access
            if (TheCompany != null)
                if (TheCompany.agentname == "House")
                    return true;

            switch (x.UserName.ToLower())
            {
                case "":
                case "bad record":
                case "house account":
                case "house":
                case "unassigned":
                    return true;
            }

            return false;
        }




        public virtual bool EditAccessByAssignedAgent(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {

            if (u.SuperUser)
                return true;
            if (u.IsTeamMember(context, "sales_assistant", u))
                return true;


            n_user owner = n_user.GetById(context, x.UserID);
            if (owner == null)
                return false;
            if (x == null)
                return true;

            if (u.CheckPermit(context, "Edit All Orders", true))
                return true;

            if (Tools.Strings.StrCmp(u.unique_id, x.UserID))
                return true;

            if (IsOwnedByAssistant(context, owner, u))
                return true;

            if (IsOwnedByAssistantsLeader(context, owner, u))
                return true;

            switch (x.UserName.ToLower())
            {
                case "":
                case "bad record":
                case "house account":
                case "house":
                case "unassigned":
                    return true;
            }

            return false;
        }
        public virtual bool DeleteAccessByAssignedAgent(IAssignedAgent x, NewMethod.n_user u)
        {
            if (x == null)
                return true;

            if (u.SuperUser)
                return true;

            return false;
        }

        public virtual bool CanBeViewedByDealheader(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.ViewAllReqs_Quotes, u);
        }
        public virtual bool CanBeEditedByDealheader(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllReqs_Quotes, u);
        }





        public virtual bool CanBeViewedByQuote(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.ViewAllReqs_Quotes, u);
        }
        public virtual bool CanBeEditedByQuote(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllReqs_Quotes, u);
        }



        public virtual bool CanBeViewedByRFQ(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.ViewAllBids, u);
        }
        public virtual bool CanBeEditedByRFQ(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllBids, u);
        }

        public virtual bool CanBeViewedByFormalQuote(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllFormalQuotes, u);
        }
        public virtual bool CanBeEditedByFormalQuote(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            //Allow Split Agents to edit FQ
            if (IsSplitAgentForCompany(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllFormalQuotes, u);
        }

        private bool IsSplitAgentForCompany(ContextRz x, IAssignedAgent o, n_user u)
        {
            company c = null;
           if(o is ordhed_quote)
            {
                ordhed_quote q = (ordhed_quote)o;
                c = company.GetById(x, q.base_company_uid);
                if (c == null)
                    return false;
                if (string.IsNullOrEmpty(c.split_commission_ID))
                    return false;

                split_commission sc = split_commission.GetById(x,c.split_commission_ID);
                if (u.unique_id == sc.split_commission_agent_id)
                    return true;
            }

            return false;
        }

        public virtual bool CanBeDeletedByFormalQuote(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllFormalQuotes, u);
        }

        public virtual bool CanBeViewedBySalesOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {

            if (ViewAccessByAssignedAgent(context, x, u))
                return true;

            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllSalesOrders, u);
        }

        //KT Alternate Method to above that accepts companyuid
        public virtual bool CanBeViewedBySalesOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u, string c)
        {

            if (ViewAccessByAssignedAgent(context, x, u, c))
                return true;

            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllSalesOrders, u);
        }

        public virtual bool CanBeEditedBySalesOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllSalesOrders, u);
        }
        public virtual bool CanBeDeletedBySalesOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllSalesOrders, u);
        }

        public virtual bool CanBeViewedByInvoice(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllInvoices, u);
        }
        public virtual bool CanBeEditedByInvoice(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllInvoices, u);
        }
        public virtual bool CanBeDeletedByInvoice(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllInvoices, u);
        }

        public virtual bool CanBeViewedByPurchaseOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllPurchaseOrders, u);
        }
        public virtual bool CanBeEditedByPurchaseOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllPurchaseOrders, u);
        }
        public virtual bool CanBeDeletedByPurchaseOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllPurchaseOrders, u);
        }

        public virtual bool CanBeViewedByRMA(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllRMAs, u);
        }
        public virtual bool CanBeEditedByRMA(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllRMAs, u);
        }
        public virtual bool CanBeDeletedByRMA(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllRMAs, u);
        }

        public virtual bool CanBeViewedByVRMA(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllVRMAs, u);
        }
        public virtual bool CanBeEditedByVRMA(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllVRMAs, u);
        }
        public virtual bool CanBeDeletedByVRMA(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllVRMAs, u);
        }

        public virtual bool CanBeViewedByServiceOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (ViewAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.OpenAllServiceOrders, u);
        }
        public virtual bool CanBeEditedByServiceOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (EditAccessByAssignedAgent(context, x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.EditAllServiceOrders, u);
        }
        public virtual bool CanBeDeletedByServiceOrder(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            if (DeleteAccessByAssignedAgent(x, u))
                return true;
            else
                return CheckPermit(context, Permissions.ThePermits.DeleteAllServiceOrders, u);
        }



        private bool IsOwnedByAssistantsLeader(ContextNM x, n_user owner, NewMethod.n_user assistant)  //If the account is owned by an assistant's leader
        {
            if (assistant.IsAssistantTo(owner))
                return true;
            return false;
        }

        //Assistant To Logic
        private bool IsOwnedByAssistant(ContextNM x, n_user assistant, NewMethod.n_user leader) //if the object is owned by one of a leader's assistants
        {
            n_user u = n_user.GetById(x, assistant.unique_id);
            if (u == null)
                return false;
            if (string.IsNullOrEmpty(u.assistant_to_uid))
                return false;
            if (assistant.IsAssistantTo(leader))
                return true;
            return false;
        }



        //Integrations Logic
        //Hubspot
        public virtual bool CanManageHubspot(ContextRz context, IAssignedAgent x, NewMethod.n_user u)
        {
            return CheckPermit(context, Permissions.ThePermits.CanManageHubspot, u);
        }

    }
}
