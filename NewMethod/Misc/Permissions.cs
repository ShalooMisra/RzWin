using System;
using System.Collections.Generic;
using System.Text;

namespace NewMethod
{
    public class Permissions
    {
        static Permissions m_ThePermits = null;

        //this is to allow ThePermits to be accessible without the context
        public static void InitPermits(ContextNM context)
        {
            m_ThePermits = context.xSys.ThePermitLogic.GetPermissionsObject();
        }

        public static Permissions ThePermits
        {
            get
            {
                if (m_ThePermits == null)
                    throw new Exception("Permissions have not been initialized");

                return m_ThePermits;
            }
        }

        //System Management
        public string TeamTemplateEditor = "permit_TeamTemplateEditor";
        public string ViewReports = "permit_ViewReports";
        public string ViewPanel = "permit_ViewPanel";
        public string ViewTeamsAndUsers = "permit_ViewTeamsAndUsers";
        public string ViewAR_APScreen = "permit_ViewAR_APScreen";
        public string ManageChoiceLists = "permit_ManageChoiceLists";
        public string CanViewChangeHistory = "permit_CanViewChangeHistory";

        //Company Management     
        public string AssignCompanies = "permit_AssignCompanies";
        public string ViewAllCompanies = "permit_ViewAllCompanies";
        public string ViewAllContacts = "permit_ViewAllContacts";
        public string ViewAllReqs_Quotes = "permit_ViewAllReqs_Quotes";
        public string ViewAllBids = "permit_ViewAllBids";  
        public string ViewShipScreen = "permit_ViewShipScreen";
        public string ViewAllUsersOnReports = "permit_ViewAllUsersOnReports";
        public string ViewOrderLinks = "permit_ViewOrderLinks";
        public string CanLockCompanies = "permit_CanLockCompanies";

        //public string EditAllCompaniesOnTeam = "permit_EditAllCompaniesOnTeam";
        public string EditAllCompanies = "permit_EditAllCompanies";
        public string EditAllContacts = "permit_EditAllContacts";
        public string EditAllReqs_Quotes = "permit_EditAllReqs_Quotes";
        public string EditAllBids = "permit_EditAllBids";
        public string EditAllFormalQuotes = "permit_EditAllFormalQuotes";
        public string EditAllSalesOrders = "permit_EditAllSalesOrders";
        public string EditAllInvoices = "permit_EditAllInvoices";
        public string EditAllPurchaseOrders = "permit_EditAllPurchaseOrders";
        public string EditAllRMAs = "permit_EditAllRMAs";
        public string EditAllVRMAs = "permit_EditAllVRMAs";
        public string EditAllServiceOrders = "permit_EditAllServiceOrders";

        public string DeleteAllCompanies = "permit_DeleteAllCompanies";
        public string DeleteAllContacts = "permit_DeleteAllContacts";
        public string DeleteAllFormalQuotes = "permit_DeleteAllFormalQuotes";
        public string DeleteAllSalesOrders = "permit_DeleteAllSalesOrders";
        public string DeleteAllInvoices = "permit_DeleteAllInvoices";
        public string DeleteAllPurchaseOrders = "permit_DeleteAllPurchaseOrders";
        public string DeleteAllRMAs = "permit_DeleteAllRMAs";
        public string DeleteAllVRMAs = "permit_DeleteAllVRMAs";
        public string DeleteAllServiceOrders = "permit_DeleteAllServiceOrders";

        //Inventory Management
        public string DeleteInventoryLineItems = "Inventory:Delete:CanDeleteInventory";
        public string EditPartRecordQuantity = "Inventory:Edit:Can Edit Part Quantity";
        public string EditInventoryLineItems = "permit_EditInventoryLineItems";
        public string ImportLineItems = "permit_ImportLineItems";
        public string ImportCompanies = "permit_ImportCompanies";
        public string CanChangeStockType = "permit_CanChangeStockype";


        //KT Line Management
        public string DeleteLineItems = "permit_DeleteLineItems";
        public string AddManualSalesLines = "permit_AddManualSalesLines";
        public string CanChangeLineStatus = "permit_CanChangeLineStatus";
        public string CanChangeLineVendor = "permit_CanChangeLineVendor";

        //public string NotSearchAllCompanies = "permit_NotSearchAllCompanies";

        public string OpenAllOrders = "permit_OpenAllOrders";
        public string OpenAllFormalQuotes = "permit_OpenAllFormalQuotes";
        public string OpenAllSalesOrders = "permit_OpenAllSalesOrders";
        public string OpenAllInvoices = "permit_OpenAllInvoices";
        public string OpenAllPurchaseOrders = "permit_OpenAllPurchaseOrders";
        public string OpenAllRMAs = "permit_OpenAllRMAs";
        public string OpenAllVRMAs = "permit_OpenAllVRMAs";
        public string OpenAllServiceOrders = "permit_OpenAllServiceOrders";
        public string VoidAllOrders = "permit_VoidAllOrders";

      

        public string ApplyPayments = "permit_ApplyPayments";
        public string SendOrdersToQuickBooks = "permit_SendOrdersToQuickBooks";
        public string SendCompaniesToQuickBooks = "permit_SendCompaniesToQuickBooks";
        public string ExportListsToExcel = "permit_ExportListsToExcel";

        public string AddOtherChargeCredit = "permit_AddOtherChargeCredit";
        public string CanChargeCustomerServiceCost = "permit_CanChargeCustomerServiceCost";
        public string EditCompanyCreditLimits = "permit_EditCompanyCreditLimits";

        //Search
        public string PartSearch = "Inventory:Search:Search Parts";
        public string SearchCompanies = "Company:Search:Search Companies";
        public string SearchHome = "General:Search:Search Home";
        public string SearchOrders = "Order:Search:Search Orders";
        
           

        //Financial Management
        public string ManageDeductions = "permit_ManageDeductions";
        public string CanVerifyFinancials = "permit_CanVerifyFinancials";
        
        public string CanViewCompanyQBTab = "permit_CanViewCompanyQBTab";
        public string CanEditCommissionPercentInvoice = "permit_CanEditCommissionPercentInvoice";
        public string CanManageCommission = "permit_CanManageSplitCommission";
        public string ViewAllAgentsInCrossRef = "permit_ViewAllAgentsInCrossRef";               
 
        public string CanChangeNoteDate = "permit_CanChangeNoteDate";        
        public string CanOverridePaymentTerms = "permit_CanOverridePaymentTerms";
        public string CanOverrideProblemCustomer = "permit_CanOverrideProblemCustomer";
        public string CanEditLineItems = "permit_CanEditLineItems";
        public string CanSetCustomerTerms = "permit_CanSetCustomerTerms";
        public string CanSetVendorTerms = "permit_CanSetVendorTerms";
        public string CanManageConsignment = "permit_CanManageConsignment";
       

        //Quality Management
        public string CanApplyAVL = "permit_CanApplyAVL";
        public string CanSetScopeOfApproval = "permit_CanSetScopeOfApproval";
        public string CanVetSuppliers = "permit_CanVetSuppliers";
        public string CanSetProblemVendor = "permit_CanSetProblemVendor";

        //Order Management
        public string CanChangeOrderDate = "permit_CanChangeOrderDate";
        public string ChangeOrderNumbers = "permit_ChangeOrderNumbers";
        public string CanUseBinSwapper = "permit_CanUseBinSwapper";
        public string AllowDNCBids = "permit_AllowDNCBids";
        public string CanValidate = "permit_CanValidate";
        public string CanShipValidationHold = "permit_CanShipValidationHold";

        //Portal Management
        public string CanPostToPortal = "permit_CanPostToPortal";


        //Integrations
        public string CanManageHubspot = "permit_CanManageHubspot";



    }
    public class PermitNode
    {
        public string PermitName = "";
        public string PermitString = "";
        public bool HasPermit = false;
        public List<PermitNode> Nodes = new List<PermitNode>();

        public PermitNode(string name, string permit)
        {
            PermitName = name;
            PermitString = permit;
        }
    }
}
