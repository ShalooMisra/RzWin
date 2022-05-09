using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public class PermitLogic
    {
        public virtual Permissions GetPermissionsObject()
        {
            return new Permissions();
        }

        //2012_12_06
        //this SUCKS.  the compiler is letting the build go but then saying the method doesn't exist when it runs if i insert this as an optional parameter in the method below
        //of course this breaks everything that inherits CheckPermit to do something important
        public virtual bool CheckPermitBlockOption(ContextNM x, string permit, NewMethod.n_user u, bool blockIfMissing)
        {
            return u.CheckPermit(x, permit, blockIfMissing);
        }

        public virtual bool CheckPermit(ContextNM x, string permit, n_user u,bool blockIfMissing = true,  bool ignoreSuperUser = false)
        {
            return u.CheckPermit(x, permit, blockIfMissing, ignoreSuperUser);
        }

        public virtual List<PermitNode> GetPermitNodeCollection(ContextNM x, NewMethod.n_team TheTeam, NewMethod.n_user TheUser, bool IsTeam)
        {
            List<PermitNode> ret = new List<PermitNode>();
            int check_count = 0;
            int main_node_check_count = 0;
            PermitNode p;
            PermitNode pp;
            PermitNode ppp;

            try
            {


                //System Management
                p = new PermitNode("System Management", "sublist");
                check_count = 0;


                pp = new PermitNode("Template Editor", Permissions.ThePermits.TeamTemplateEditor);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.TeamTemplateEditor);
                else
                    pp.HasPermit = TheUser.template_editor;
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Access Part Search", Permissions.ThePermits.PartSearch);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.PartSearch);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.PartSearch, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Access People Search", Permissions.ThePermits.SearchCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.SearchCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.SearchCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Access Home Screen", Permissions.ThePermits.SearchHome);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.SearchHome);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.SearchHome, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Access Order Screen", Permissions.ThePermits.SearchOrders);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.SearchOrders);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.SearchOrders, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("View Ship Screen", Permissions.ThePermits.ViewShipScreen);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewShipScreen);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewShipScreen, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("View AR/AP Screen", Permissions.ThePermits.ViewAR_APScreen);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewAR_APScreen);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewAR_APScreen, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Access Panel", Permissions.ThePermits.ViewPanel);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewPanel);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewPanel, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Access Reports", Permissions.ThePermits.ViewReports);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewReports);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewReports, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("View Teams and Users", Permissions.ThePermits.ViewTeamsAndUsers);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewTeamsAndUsers);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewTeamsAndUsers, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Manage Choice Lists", Permissions.ThePermits.ManageChoiceLists);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ManageChoiceLists);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ManageChoiceLists, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);
                //Change History
                pp = new PermitNode("View Change History", Permissions.ThePermits.CanViewChangeHistory);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanViewChangeHistory);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanViewChangeHistory, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);











                if (check_count == 11)
                    p.HasPermit = true;
                else
                    p.HasPermit = false;
                ret.Add(p);





                //Data Management
                p = new PermitNode("Data Management", "sublist");
                check_count = 0;


                pp = new PermitNode("View All User's On Reports", Permissions.ThePermits.ViewAllUsersOnReports);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewAllUsersOnReports);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewAllUsersOnReports, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Import Line Items", Permissions.ThePermits.ImportLineItems);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ImportLineItems);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ImportLineItems, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Import Companies", Permissions.ThePermits.ImportCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ImportCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ImportCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("View All Agents In Cross Reference", ((Permissions)Permissions.ThePermits).ViewAllAgentsInCrossRef);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).ViewAllAgentsInCrossRef);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).ViewAllAgentsInCrossRef, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Export List Items to Excel", ((Permissions)Permissions.ThePermits).ExportListsToExcel);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).ExportListsToExcel);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).ExportListsToExcel, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);



                if (check_count == 5)
                    p.HasPermit = true;
                else
                    p.HasPermit = false;
                ret.Add(p);






                //Company and Contact Management
                p = new PermitNode("Company / Contact Management", "sublist");
                check_count = 0;


                pp = new PermitNode("Assign Companies", Permissions.ThePermits.AssignCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.AssignCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.AssignCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("View All Companies", Permissions.ThePermits.ViewAllCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewAllCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewAllCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                //pp = new PermitNode("Edit All Companies On Team", Permissions.ThePermits.EditAllCompaniesOnTeam);
                //if (IsTeam)
                //    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllCompaniesOnTeam);
                //else
                //    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllCompaniesOnTeam, true);
                //if (pp.HasPermit)
                //    check_count++;
                //p.Nodes.Add(pp);

                pp = new PermitNode("Edit All Companies", Permissions.ThePermits.EditAllCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("View All Contacts", Permissions.ThePermits.ViewAllContacts);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewAllContacts);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewAllContacts, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Edit All Contacts", Permissions.ThePermits.EditAllContacts);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllContacts);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllContacts, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Delete All Companies", Permissions.ThePermits.DeleteAllCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Delete All Contacts", Permissions.ThePermits.DeleteAllContacts);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllContacts);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllContacts, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Change Note Date", ((Permissions)Permissions.ThePermits).CanChangeNoteDate);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanChangeNoteDate);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanChangeNoteDate, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can lock and unlock companies", ((Permissions)Permissions.ThePermits).CanLockCompanies);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanLockCompanies);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanLockCompanies, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                //KT changed to 7 after removing "Can View / Edit all companies on team."
                //- Going with Captain to determine this, that way I can isolate it to single team., else when I set those perms, I set them for ALL teams user is member of.
                if (check_count == 9)
                    p.HasPermit = true;
                else
                    p.HasPermit = false;
                ret.Add(p);




                //Financial Management
                p = new PermitNode("Financial Management", "sublist");
                check_count = 0;


                pp = new PermitNode("Can Charge Customer The Service Cost", Permissions.ThePermits.CanChargeCustomerServiceCost);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanChargeCustomerServiceCost);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanChargeCustomerServiceCost, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Add Other Charge/Credit To Orders", Permissions.ThePermits.AddOtherChargeCredit);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.AddOtherChargeCredit);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.AddOtherChargeCredit, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);


                pp = new PermitNode("Can Edit Company Credit Limits", Permissions.ThePermits.EditCompanyCreditLimits);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditCompanyCreditLimits);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditCompanyCreditLimits, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);


                pp = new PermitNode("Can Apply Payments", Permissions.ThePermits.ApplyPayments);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ApplyPayments);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ApplyPayments, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                //Orders To Quickbooks
                pp = new PermitNode("Can Send Orders to Quick Books", Permissions.ThePermits.SendOrdersToQuickBooks);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.SendOrdersToQuickBooks);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.SendOrdersToQuickBooks, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);
                //Companies To Quickbooks
                pp = new PermitNode("Can Send Companies to Quick Books", Permissions.ThePermits.SendCompaniesToQuickBooks);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.SendCompaniesToQuickBooks);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.SendCompaniesToQuickBooks, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                //Quickbooks Tab
                pp = new PermitNode("Can View Company QB Tab", ((Permissions)Permissions.ThePermits).CanViewCompanyQBTab);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanViewCompanyQBTab);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanViewCompanyQBTab, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);


                pp = new PermitNode("Can Verify Financials", ((Permissions)Permissions.ThePermits).CanVerifyFinancials);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanVerifyFinancials);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanVerifyFinancials, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

              

                pp = new PermitNode("Can Edit Commission Percent Invoice", ((Permissions)Permissions.ThePermits).CanEditCommissionPercentInvoice);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanEditCommissionPercentInvoice);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanEditCommissionPercentInvoice, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);


                pp = new PermitNode("Can Manage Commission", Permissions.ThePermits.CanManageCommission);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanManageCommission);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanManageCommission, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Manage Deductions (Create, Edit, Delete)", ((Permissions)Permissions.ThePermits).ManageDeductions);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).ManageDeductions);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).ManageDeductions, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Override Payment Terms", ((Permissions)Permissions.ThePermits).CanOverridePaymentTerms);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanOverridePaymentTerms);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanOverridePaymentTerms, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Set Customer Terms", ((Permissions)Permissions.ThePermits).CanSetCustomerTerms);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanSetCustomerTerms);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanSetCustomerTerms, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Set Vendor Terms", ((Permissions)Permissions.ThePermits).CanSetVendorTerms);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanSetVendorTerms);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanSetVendorTerms, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);
                

                if (check_count == 14)
                    p.HasPermit = true;
                else
                    p.HasPermit = false;
                ret.Add(p);





                //Quality Management
                p = new PermitNode("QualityManagement", "sublist");
                check_count = 0;

                pp = new PermitNode("Can Apply AVL", ((Permissions)Permissions.ThePermits).CanApplyAVL);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanApplyAVL);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanApplyAVL, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Vet Suppliers", ((Permissions)Permissions.ThePermits).CanVetSuppliers);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanVetSuppliers);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanVetSuppliers, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Set Scope of Approval", ((Permissions)Permissions.ThePermits).CanSetScopeOfApproval);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanSetScopeOfApproval);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanSetScopeOfApproval, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Set Problem Vendor", ((Permissions)Permissions.ThePermits).CanSetProblemVendor);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanSetProblemVendor);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanSetProblemVendor, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);                

                if (check_count == 4)
                    p.HasPermit = true;
                else
                    p.HasPermit = false;
                ret.Add(p);





                //Order Management
                main_node_check_count = 0;
                p = new PermitNode("Order Management", "sublist");

                pp = new PermitNode("Can Change Order Date", Permissions.ThePermits.CanChangeOrderDate);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanChangeOrderDate);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanChangeOrderDate, true);
                if (pp.HasPermit)
                    main_node_check_count++;
                p.Nodes.Add(pp);

                //
                pp = new PermitNode("Can Validate Orders", Permissions.ThePermits.CanValidate);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanValidate);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanValidate, true);
                if (pp.HasPermit)
                    main_node_check_count++;
                p.Nodes.Add(pp);   
                
                pp = new PermitNode("Can Ship Validation Hold", Permissions.ThePermits.CanShipValidationHold);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanShipValidationHold);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanShipValidationHold, true);
                if (pp.HasPermit)
                    main_node_check_count++;
                p.Nodes.Add(pp);
       
                pp = new PermitNode("Can Change Order Numbers", (Permissions.ThePermits).ChangeOrderNumbers);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit((Permissions.ThePermits).ChangeOrderNumbers);
                else
                    pp.HasPermit = TheUser.HasPermit((Permissions.ThePermits).ChangeOrderNumbers, true);
                if (pp.HasPermit)
                    main_node_check_count++;
                p.Nodes.Add(pp);
                
                pp = new PermitNode("Void All Orders", Permissions.ThePermits.VoidAllOrders);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.VoidAllOrders);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.VoidAllOrders, true);
                if (pp.HasPermit)
                    main_node_check_count++;
                p.Nodes.Add(pp);
                
                pp = new PermitNode("Can Add Manual Sales Order Line Items", Permissions.ThePermits.AddManualSalesLines);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.AddManualSalesLines);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.AddManualSalesLines, true);
                if (pp.HasPermit)
                    main_node_check_count++;
                p.Nodes.Add(pp);                

                pp = new PermitNode("Can Change Line Status", Permissions.ThePermits.CanChangeLineStatus);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanChangeLineStatus);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanChangeLineStatus, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);
               
                pp = new PermitNode("Can Change Line Vendor", Permissions.ThePermits.CanChangeLineVendor);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanChangeLineVendor);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanChangeLineVendor, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Override Problem Customer", ((Permissions)Permissions.ThePermits).CanOverrideProblemCustomer);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanOverrideProblemCustomer);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanOverrideProblemCustomer, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);
               



                pp = new PermitNode("Batch Management", "sublist");
                check_count = 0;


                ppp = new PermitNode("View All Reqs/Quotes", Permissions.ThePermits.ViewAllReqs_Quotes);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewAllReqs_Quotes);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewAllReqs_Quotes, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);


                ppp = new PermitNode("Edit All Reqs/Quotes", Permissions.ThePermits.EditAllReqs_Quotes);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllReqs_Quotes);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllReqs_Quotes, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("View All Bids", Permissions.ThePermits.ViewAllBids);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.ViewAllBids);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.ViewAllBids, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);


                ppp = new PermitNode("Edit All Bids", Permissions.ThePermits.EditAllBids);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllBids);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllBids, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);


                ppp = new PermitNode("Can accept bids from DNC vendors in Order Batch", Permissions.ThePermits.AllowDNCBids);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.AllowDNCBids);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.AllowDNCBids, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

              


                if (check_count == 5)
                {
                    pp.HasPermit = true;
                    main_node_check_count++;
                }

                else
                    pp.HasPermit = false;
                p.Nodes.Add(pp);
                //End Batch Management


                //Order Management : Open
                pp = new PermitNode("Open", "sublist");
                check_count = 0;

                ppp = new PermitNode("All Orders", Permissions.ThePermits.OpenAllOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);


                ppp = new PermitNode("Formal Quotes", Permissions.ThePermits.OpenAllFormalQuotes);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllFormalQuotes);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllFormalQuotes, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);


                ppp = new PermitNode("Sales Orders", Permissions.ThePermits.OpenAllSalesOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllSalesOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllSalesOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Invoices", Permissions.ThePermits.OpenAllInvoices);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllInvoices);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllInvoices, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Purchase Orders", Permissions.ThePermits.OpenAllPurchaseOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllPurchaseOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllPurchaseOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("RMAs", Permissions.ThePermits.OpenAllRMAs);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllRMAs);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllRMAs, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("VRMAs", Permissions.ThePermits.OpenAllVRMAs);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllVRMAs);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllVRMAs, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Service Orders", Permissions.ThePermits.OpenAllServiceOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.OpenAllServiceOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.OpenAllServiceOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);



                if (check_count == 8)
                {
                    pp.HasPermit = true;
                    main_node_check_count++;
                }
                else
                    pp.HasPermit = false;
                p.Nodes.Add(pp);
                //End Order Management : Open


                //Order Management : Edit
                pp = new PermitNode("Edit", "sublist");
                check_count = 0;
                ppp = new PermitNode("Formal Quotes", Permissions.ThePermits.EditAllFormalQuotes);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllFormalQuotes);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllFormalQuotes, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Sales Orders", Permissions.ThePermits.EditAllSalesOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllSalesOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllSalesOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Invoices", Permissions.ThePermits.EditAllInvoices);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllInvoices);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllInvoices, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Purchase Orders", Permissions.ThePermits.EditAllPurchaseOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllPurchaseOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllPurchaseOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("RMAs", Permissions.ThePermits.EditAllRMAs);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllRMAs);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllRMAs, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("VRMAs", Permissions.ThePermits.EditAllVRMAs);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllVRMAs);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllVRMAs, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Service Orders", Permissions.ThePermits.EditAllServiceOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditAllServiceOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditAllServiceOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Line Items", ((Permissions)Permissions.ThePermits).CanEditLineItems);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanEditLineItems);
                else
                    ppp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanEditLineItems, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);



               



                if (check_count == 8)
                {
                    pp.HasPermit = true;
                    main_node_check_count++;
                }
                else
                    pp.HasPermit = false;
                p.Nodes.Add(pp);
                //End Order Management : Edit   




                //Order Management : Delete
                pp = new PermitNode("Delete", "sublist");
                check_count = 0;


                ppp = new PermitNode("Formal Quotes", Permissions.ThePermits.DeleteAllFormalQuotes);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllFormalQuotes);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllFormalQuotes, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Sales Orders", Permissions.ThePermits.DeleteAllSalesOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllSalesOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllSalesOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Invoices", Permissions.ThePermits.DeleteAllInvoices);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllInvoices);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllInvoices, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Purchase Orders", Permissions.ThePermits.DeleteAllPurchaseOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllPurchaseOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllPurchaseOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("RMAs", Permissions.ThePermits.DeleteAllRMAs);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllRMAs);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllRMAs, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("VRMAs", Permissions.ThePermits.DeleteAllVRMAs);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllVRMAs);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllVRMAs, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                ppp = new PermitNode("Service Orders", Permissions.ThePermits.DeleteAllServiceOrders);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteAllServiceOrders);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteAllServiceOrders, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);

                //KT 
                ppp = new PermitNode("Line Items", Permissions.ThePermits.DeleteLineItems);
                if (IsTeam)
                    ppp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteLineItems);
                else
                    ppp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteLineItems, true);
                if (ppp.HasPermit)
                    check_count++;
                pp.Nodes.Add(ppp);



                if (check_count == 9)
                {
                    pp.HasPermit = true;
                    main_node_check_count++;
                }
                else
                    pp.HasPermit = false;
                p.Nodes.Add(pp);
                //End Order Management : Delete


                if (check_count == 8)
                {
                    pp.HasPermit = true;
                    main_node_check_count++;
                }

                if (main_node_check_count == 10)
                    p.HasPermit = true;
                ret.Add(p);
                //End Order Management



                //Warehouse / Inventory Management
                //KT THis is currently the only section where thge check_count system is funcitoning as I intend.
                //Intended function = if users has all perms, then check the top level node
                //Not terrible useful - Improvements would be a different (shaded gray box) on the parent node if there are partial permissions
                //Also, if click top level, lower levels get clicked too, need to see ViewEditPermissions.cs
                p = new PermitNode("Warehouse", "sublist");
                check_count = 0;


                pp = new PermitNode("Can Use Bin Swapper", Permissions.ThePermits.CanUseBinSwapper);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanUseBinSwapper);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanUseBinSwapper, true);
                if (pp.HasPermit == true)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Edit Inventory Line Items", Permissions.ThePermits.EditInventoryLineItems);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditInventoryLineItems);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditInventoryLineItems, true);
                if (pp.HasPermit == true)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Edit Inventory Quantity", Permissions.ThePermits.EditPartRecordQuantity);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.EditPartRecordQuantity);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.EditPartRecordQuantity, true);
                if (pp.HasPermit == true)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Delete Inventory Line Items", Permissions.ThePermits.DeleteInventoryLineItems);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.DeleteInventoryLineItems);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.DeleteInventoryLineItems, true);
                if (pp.HasPermit == true)
                    check_count++;
                p.Nodes.Add(pp);


                pp = new PermitNode("Can Manage Consignment", ((Permissions)Permissions.ThePermits).CanManageConsignment);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanManageConsignment);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanManageConsignment, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);

                pp = new PermitNode("Can Change StockType", ((Permissions)Permissions.ThePermits).CanChangeStockType);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(((Permissions)Permissions.ThePermits).CanChangeStockType);
                else
                    pp.HasPermit = TheUser.HasPermit(((Permissions)Permissions.ThePermits).CanChangeStockType, true);
                if (pp.HasPermit)
                    check_count++;
                p.Nodes.Add(pp);


                if (check_count == 6)
                    p.HasPermit = true;
                ret.Add(p);


                //System Management
                p = new PermitNode("Portal Management", "sublist");
                check_count = 0;

                pp = new PermitNode("Can Post to Portal", Permissions.ThePermits.CanPostToPortal);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanPostToPortal);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanPostToPortal, true);
                if (pp.HasPermit == true)
                    check_count++;
                p.Nodes.Add(pp);

                if (check_count == 1)
                    p.HasPermit = true;
                ret.Add(p);


                //Integrations
                p = new PermitNode("Integrations Management", "sublist");
                check_count = 0;

                pp = new PermitNode("Can Manage Hubspot", Permissions.ThePermits.CanManageHubspot);
                if (IsTeam)
                    pp.HasPermit = TheTeam.HasPermit(Permissions.ThePermits.CanManageHubspot);
                else
                    pp.HasPermit = TheUser.HasPermit(Permissions.ThePermits.CanManageHubspot, true);
                if (pp.HasPermit == true)
                    check_count++;
                p.Nodes.Add(pp);

                if (check_count == 1)
                    p.HasPermit = true;
                ret.Add(p);


            }
            catch { }
            return ret;
        }

       
    }
}
