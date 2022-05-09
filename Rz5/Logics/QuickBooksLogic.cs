using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using QBFC13Lib;


using Core;
using NewMethod;
using Rz5.Enums;
using System.Linq;
using System.Windows.Forms;

namespace Rz5
{ //KT - 2-26-2015 - Scroll to the bottom to see the original Sensible implementation code for QuickBooksLogic.cs
    public class QuickBooksLogic
    {
        private ICustomerRet TheCustomer = null;
        private IVendorRet TheVendor = null;

        ordhed_sales CurrentSalesOrder = null;
        ordhed_purchase CurrentPurchaseOrder = null;
        ordhed_service CurrentServiceOrder = null;

        public QuickBooksLogic()
        {
            try
            {
                sessionManager = new QBSessionManager();
            }
            catch (Exception ee)
            {
                string msg = ee.Message;
            }
        }
        public virtual void InvoiceAddCustomerMsg(QBFC13Lib.IInvoiceAdd InvoiceAdd, ordhed_invoice xOrder)
        {
            if (Tools.Strings.StrExt(xOrder.printcomment) && (xOrder.printcomment.Length <= 50))
            {
                try
                {
                    InvoiceAdd.CustomerMsgRef.FullName.SetValue(QBTrim(xOrder.printcomment, InvoiceAdd.CustomerMsgRef.FullName.GetMaxLength()));
                }
                catch { }
            }
        }
        public virtual void SalesAddCustomerMsg(ContextRz x, ISalesOrderAdd SalesAdd, ordhed_sales xOrder)
        {
            if (Tools.Strings.StrExt(xOrder.printcomment) && (xOrder.printcomment.Length <= 50))
            {
                try
                {
                    if (CheckMessage(x, xOrder))
                        SalesAdd.CustomerMsgRef.FullName.SetValue(QBTrim(xOrder.printcomment, SalesAdd.CustomerMsgRef.FullName.GetMaxLength()));
                }
                catch { }
            }
        }
        public virtual void SalesModCustomerMsg(ContextRz x, ISalesOrderMod SalesMod, ordhed_sales xOrder)
        {
            if (Tools.Strings.StrExt(xOrder.printcomment) && (xOrder.printcomment.Length <= 50))
            {
                try
                {
                    if (CheckMessage(x, xOrder))
                        SalesMod.CustomerMsgRef.FullName.SetValue(QBTrim(xOrder.printcomment, SalesMod.CustomerMsgRef.FullName.GetMaxLength()));
                }
                catch { }
            }
        }
        public virtual void PurchaseModCustomerMsg(IPurchaseOrderMod PurchaseMod, ordhed_purchase xOrder)
        {
            if (Tools.Strings.StrExt(xOrder.printcomment) && (xOrder.printcomment.Length <= 50))
            {
                try
                {
                    //PurchaseMod.CustomerMsgRef.FullName.SetValue(QBTrim(xOrder.printcomment, PurchaseMod.Memo.FullName.GetMaxLength()));
                }
                catch { }
            }
        }

        public virtual String GetQBPartNumber(ContextRz context, orddet_line lineItem, Enums.OrderType orderType)
        {
            if (Tools.Strings.StrCmp(lineItem.unique_id, "<overhead>"))
                return IdentifierFilter(lineItem.fullpartnumber);
            if (SimplyPartsMode(context))
                return "Parts";
            if (Tools.Strings.StrExt(lineItem.alternatepart_02))
                return QBPartFilter(context, lineItem.alternatepart_02);
            else
                return QBPartFilter(context, lineItem.fullpartnumber);
        }


        public virtual QuickBooksImportLogic GetQBImportLogic()
        {
            return new QuickBooksImportLogic();
        }
        //public virtual void AddPurchaseDetails(ContextRz context, IPurchaseOrderAdd PurchaseOrderAdd, List<orddet_line> a, String strCustomer, String strInitials)
        //{
        //    foreach (orddet_line d in a)
        //    {
        //        if (d.qb_sent_purchase)
        //            continue;

        //        if (!Tools.Strings.StrExt(d.fullpartnumber))
        //            continue;

        //        String strPartNumber = GetQBPartNumber(context, d, Enums.OrderType.Purchase);
        //        if (!Tools.Strings.StrExt(strPartNumber))
        //            continue;

        //        //Double dblAmount = Math.Round(d.unit_cost * d.QBPurchaseQuantity, 2);
        //        QBFC13Lib.IORPurchaseOrderLineAdd xItem = PurchaseOrderAdd.ORPurchaseOrderLineAddList.Append();
        //        //PartNumber
        //        xItem.PurchaseOrderLineAdd.ItemRef.FullName.SetValue(Tools.Strings.Left(strPartNumber, 30).Trim());
        //        //Quantity
        //        xItem.PurchaseOrderLineAdd.Quantity.SetValue(d.QBPurchaseQuantity);
        //        if (Tools.Strings.StrExt(strCustomer))
        //            xItem.PurchaseOrderLineAdd.CustomerRef.FullName.SetValue(strCustomer);
        //        //unit Cost
        //        xItem.PurchaseOrderLineAdd.Rate.SetValue(Math.Round(d.unit_cost, 6));

        //        //Description
        //        if (!d.fullpartnumber.ToLower().Contains("gcat"))//If this isn't a GCAT line include description
        //        {
        //            if (Tools.Strings.StrExt(d.description))
        //                xItem.PurchaseOrderLineAdd.Desc.SetValue(Tools.Strings.Left(d.description, Convert.ToInt32(xItem.PurchaseOrderLineAdd.Desc.GetMaxLength())));
        //            else
        //                xItem.PurchaseOrderLineAdd.Desc.SetValue(Tools.Strings.Left(d.fullpartnumber, Convert.ToInt32(xItem.PurchaseOrderLineAdd.Desc.GetMaxLength())));

        //        }



        //        if (SetClassToInitials(context) && Tools.Strings.StrExt(strInitials))
        //            xItem.PurchaseOrderLineAdd.ClassRef.FullName.SetValue(strInitials);
        //    }
        //}
        //Public Events
        public event QBStatusHandler GotStatus;
        //Public Variables
        public QBSessionManager sessionManager;
        public bool IsConnected = false;
        public String LastStatus = "";
        private String m_GeneralOption = "<none>";
        public String GeneralOption(ContextRz context)
        {
            if (m_GeneralOption != "<none>")
                return m_GeneralOption;
            String strValue = context.GetSetting("qb_GeneralOption");
            m_GeneralOption = strValue;
            return m_GeneralOption;
        }
        public void GeneralOptionSet(ContextRz context, String value)
        {
            m_GeneralOption = value;
            context.SetSetting("qb_GeneralOption", m_GeneralOption);
        }
        private String m_InvoiceOption = "<none>";
        public String InvoiceOption(ContextRz context)
        {
            if (m_InvoiceOption != "<none>")
                return m_InvoiceOption;
            String strValue = context.GetSetting("qb_InvoiceOption");
            m_InvoiceOption = strValue;
            return m_InvoiceOption;
        }
        public void InvoiceOptionSet(ContextRz context, String value)
        {
            m_InvoiceOption = value;
            context.SetSetting("qb_InvoiceOption", m_InvoiceOption);
        }
        private String m_POOption = "<none>";
        public String POOption(ContextRz context)
        {
            if (m_POOption != "<none>")
                return m_POOption;
            String strValue = context.GetSetting("qb_POOption");
            m_POOption = strValue;
            return m_POOption;
        }
        public void POOptionSet(ContextRz context, String value)
        {
            m_POOption = value;
            context.SetSetting("qb_POOption", m_POOption);
        }
        private String m_OutgoingShipping = "<none>";
        public String OutgoingShipping(ContextRz context)
        {
            if (m_OutgoingShipping != "<none>")
                return m_OutgoingShipping;
            String strValue = context.GetSetting("qb_OutgoingShipping");
            if (!Tools.Strings.StrExt(strValue))
                strValue = "Freight";
            m_OutgoingShipping = strValue;
            return m_OutgoingShipping;
        }
        public void OutgoingShippingSet(ContextRz context, String value)
        {
            m_OutgoingShipping = value;
            context.SetSetting("qb_OutgoingShipping", m_OutgoingShipping);
        }
        private String m_IncomingShipping = "<none>";
        public String IncomingShipping(ContextRz context)
        {
            if (m_IncomingShipping != "<none>")
                return m_IncomingShipping;
            String strValue = context.GetSetting("qb_IncomingShipping");
            if (!Tools.Strings.StrExt(strValue))
                strValue = "Freight";
            m_IncomingShipping = strValue;
            return m_IncomingShipping;
        }
        public void IncomingShippingSet(ContextRz context, String value)
        {
            m_IncomingShipping = value;
            context.SetSetting("qb_IncomingShipping", m_IncomingShipping);
        }
        private String m_HandlingItem = "<none>";
        public String HandlingItem(ContextRz context)
        {
            if (m_HandlingItem != "<none>")
                return m_HandlingItem;
            String strValue = context.GetSetting("qb_HandlingItem");
            if (!Tools.Strings.StrExt(strValue))
                strValue = "Bank Fee";
            m_HandlingItem = strValue;
            return m_HandlingItem;
        }
        public void HandlingItemSet(ContextRz context, String value)
        {
            m_HandlingItem = value;
            context.SetSetting("qb_HandlingItem", m_HandlingItem);
        }
        private String m_VendorSuffix = "<none>";
        public String VendorSuffix(ContextRz context)
        {
            if (m_VendorSuffix != "<none>")
                return m_VendorSuffix;
            String strValue = context.GetSetting("qb_VendorSuffix");
            m_VendorSuffix = strValue;
            return m_VendorSuffix;
        }
        public void VendorSuffixSet(ContextRz context, String value)
        {
            m_VendorSuffix = value;
            context.SetSetting("qb_VendorSuffix", m_VendorSuffix);
        }
        private String m_ItemSuffix = "<none>";
        public String ItemSuffix(ContextRz context)
        {
            if (m_ItemSuffix != "<none>")
                return m_ItemSuffix;
            String strValue = context.GetSetting("qb_ItemSuffix");
            m_ItemSuffix = strValue;
            return m_ItemSuffix;
        }
        public void ItemSuffixSet(ContextRz context, String value)
        {
            m_ItemSuffix = value;
            context.SetSetting("qb_ItemSuffix", m_ItemSuffix);
        }
        private String m_InvoiceTemplateName = "<none>";
        public String InvoiceTemplateName(ContextRz context)
        {
            if (m_InvoiceTemplateName != "<none>")
                return m_InvoiceTemplateName;
            String strValue = context.GetSetting("qb_InvoiceTemplateName");
            m_InvoiceTemplateName = strValue;
            return m_InvoiceTemplateName;
        }
        public void InvoiceTemplateNameSet(ContextRz context, String value)
        {
            m_InvoiceTemplateName = value;
            context.SetSetting("qb_InvoiceTemplateName", m_InvoiceTemplateName);
        }
        //Private Variables
        private String m_version_name = "";
        private String m_income_account = "";
        private String m_expense_account = "";
        private String m_asset_account = "";
        private String m_cogs_account = "";
        private String m_deposit_account = "";
        private String m_income_account_number = "";
        private String m_expense_account_number = "";
        private String m_asset_account_number = "";
        private String m_cogs_account_number = "";
        private String m_deposit_account_number = "";
        //Public Functions
        public bool Connect(ContextRz context)
        {
            try
            {
                if (IsConnected == true)
                    return true;
                //context.Comment("Connecting to Quickbooks...");
                sessionManager.OpenConnection("", "Rz3 <> Quickbooks Interface");
                sessionManager.BeginSession("", ENOpenMode.omDontCare);
                //context.Comment("Connected.");
                IsConnected = true;
            }
            catch (Exception ex)
            {
                IsConnected = false;
                String s = "Rz could not connect to Quickbooks.  For the connection to work, the Quickbooks SDK needs to be installed on this computer, and Quickbooks needs to be open and logged in to the company file that you want to use.\r\n\r\n\r\nDetail:\r\n\r\n" + ex.Message;
                context.Comment(s);
                context.TheLeader.Tell(s);
                Disconnect();
                sessionManager = new QBSessionManager();
                return false;
            }
            return true;
        }
        public void Disconnect()
        {
            IsConnected = false;
            try
            {
                sessionManager.EndSession();
                sessionManager.CloseConnection();
            }
            catch (Exception)
            {
            }

        }
        public bool CheckConnect(ContextRz context)
        {
            if (IsConnected)
                return true;
            else
                return Connect(context);
        }

        private IResponse GetResponse(ContextRz context, IMsgSetRequest req)
        {
            IResponse ret = null;
            IMsgSetResponse responseSet = GetResponseSet(context, req);
            ret = responseSet.ResponseList.GetAt(0);
            return ret;
        }

        private IMsgSetResponse GetResponseSet(ContextRz context, IMsgSetRequest req)
        {
            IMsgSetResponse ret = null;
            if (!Connect(context))
                throw new Exception("Failed Connect() getting ResponseSet");
            ret = sessionManager.DoRequests(req);//This sends the Sale, should have a ISalesOrderRet response                    

            Disconnect();

            return ret;
        }


        public bool CreateOrLinkQbParts(ContextRz context, ordhed_new xOrder)
        {
            //So, since all other methods rely on orddet_lines, we need to catch Service LInes here and do the conversion.
            List<orddet_line> lines = new List<orddet_line>();

            switch (xOrder.OrderType)
            {
                case OrderType.Service:
                    lines = ConvertServiceLinesToOrddetLines(context, xOrder);
                    break;
                default:
                    lines = xOrder.DetailsVar.RefsList(context);
                    break;
            }

            foreach (orddet_line l in lines)
            {
                //Remember, at this point "lines" can be a service or purchase
                //if (string.IsNullOrEmpty(l.qb_line_ListID) || string.IsNullOrEmpty(l.qb_line_subitem_ListID))
                CreateOrLinkQbPart(context, xOrder, l, xOrder.OrderType);
            }
            return true;
        }
        public virtual bool CreateOrLinkQbPart(ContextRz context, Rz5.ordhed_new xOrder, orddet_line xDetail, Enums.OrderType type)
        {
            context.Comment("Checking Quickbooks line item linkage: " + xDetail.fullpartnumber);
            //Service line subitem  = "Vendor Lab Services"            
            switch (type)
            {
                case OrderType.Service:
                    return CreateOrLinkServiceQbPart(context, xOrder, xDetail, type);
                default:
                    return CreateOrLinkNonInvQbPart(context, xOrder, xDetail, type);
            }
        }

        private bool CreateOrLinkServiceQbPart(ContextRz context, ordhed_new xOrder, orddet_line xDetail, OrderType type)
        {
            ordhed_service so = (ordhed_service)xOrder;
            service_line sl = so.ServiceLines.RefsList(context)[0];
            if (sl == null)
                throw new Exception("Could not locat a service line with id: " + xDetail.unique_id);
            IItemServiceRet qbServiceSubItem = null;
            qbServiceSubItem = GetAddServiceSubItem(context, xDetail, type);
            if (qbServiceSubItem == null)
            {
                context.Comment("Unable to create the subitem (MFG) for this part in Quickbooks.");
                return false;
            }

            string subItemNAme = qbServiceSubItem.FullName.GetValue();
            //MPN Item       
            IItemServiceRet servicePartItem = GetAddServiceItem(context, xDetail, qbServiceSubItem, type);
            if (servicePartItem == null)
                throw new Exception("Unable to create the item record for this part in Quickbooks.");

            context.Comment("Setting Service Line Quickbooks IDs");
            sl.qb_line_ListID = servicePartItem.ListID.GetValue();
            sl.qb_line_subitem_ListID = qbServiceSubItem.ListID.GetValue();
            sl.Update(context);
            context.Comment("Setting SubItem_ListID: " + sl.qb_line_subitem_ListID + "  for " + sl.Name);
            //Testing
            List<service_line> sLines = so.ServiceLines.RefsList(context);
            foreach (service_line sline in sLines)
            {
                string listID = sline.qb_line_ListID;
                string subItemListID = sline.qb_line_subitem_ListID;
            }

            return true;
        }
        private IItemServiceRet GetAddServiceItem(ContextRz context, orddet_line xDetail, IItemServiceRet subItem, OrderType type)
        {
            IItemServiceRet svcItem = null;
            orddet_line theItem = null;

            theItem = (orddet_line)xDetail;

            string mfg = subItem.FullName.GetValue();
            //KT Wait, I don't want ot search including MFG, because same part might be linked to different MFG spelling
            string strPartNumber = theItem.fullpartnumber.ToUpper().Trim();
            //1st check by ID  
            if (!string.IsNullOrEmpty(theItem.qb_line_ListID))
                svcItem = GetServicePartById(context, theItem, theItem.qb_line_ListID);//regardless of subitem, the qb_listID should pull the exact item.
            //2nd if no ID, search by name
            if (svcItem == null)
            {
                IItemServiceRetList itemList = GetServiceRetListMatches(context, strPartNumber);
                //Even if only 1 result, make user specify, which will tag the List ID
                if (itemList != null)
                    svcItem = AskUserForQuickbooksServiceItem(context, itemList, theItem);
            }
            if (svcItem == null)
                if (context.Leader.AskYesNo(theItem.manufacturer + ":" + strPartNumber + " doesn't match any Parts in Quickbooks.  Would you like to add it now?"))
                    svcItem = CreateLinkServiceItem(context, strPartNumber, theItem, type, subItem);
            return svcItem;
        }
        private IItemServiceRet CreateLinkServiceItem(ContextRz context, string strPartNumber, orddet_line theItem, OrderType type, IItemServiceRet subItem)
        {
            try
            {
                //Sometimes, rz line items for parts that exist in Qb will not have the list ID tagged, therefore, we need to check by name.               
                strPartNumber = QBPartFilter(context, strPartNumber);
                context.TheLeader.CommentEllipse("Checking Service Item '" + strPartNumber);
                context.TheLeader.CommentEllipse("Using '" + strPartNumber + "' as the Service Name");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                //The Add Variable
                IItemServiceAdd svcItemAdd = requestSet.AppendItemServiceAddRq();
                //Pat Number
                svcItemAdd.Name.SetValue(strPartNumber);
                string subaccount = "";
                //Income Account
                svcItemAdd.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.SetValue(IncomeAccount(context, theItem) + subaccount);
                //Expense Account
                svcItemAdd.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.SetValue(ExpenseAccount(context, theItem) + subaccount);
                //Subitem Reference - ID
                svcItemAdd.ParentRef.ListID.SetValue(subItem.ListID.GetValue());
                //Subitem Reference - Name
                svcItemAdd.ParentRef.FullName.SetValue(subItem.FullName.GetValue());

                //Description = MFG, MPN
                if (!strPartNumber.ToLower().Contains("gcat"))
                {
                    string descriptionString = GetDescriptionString(subItem.FullName.GetValue(), strPartNumber);
                    //Purchase Lines Description
                    svcItemAdd.ORSalesPurchase.SalesAndPurchase.PurchaseDesc.SetValue(descriptionString);
                    //Sales Lines Description
                    svcItemAdd.ORSalesPurchase.SalesAndPurchase.SalesDesc.SetValue(descriptionString);

                }



                if (!Connect(context))
                    throw new Exception("Connect failed on CreateLineMpn");
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                    throw new Exception("There was an error exporting part number " + strPartNumber + ": " + response.StatusMessage);

                //Set the listID Relationship
                IItemServiceRet item = (IItemServiceRet)response.Detail;
                if (item == null)
                    throw new Exception("There was an error retreiving the IITemServiceRet item from the response.");
                context.TheLeader.Comment("Exported part number " + strPartNumber);

                return item;
            }
            catch (Exception ex)
            {
                Disconnect();
                context.Leader.Error(ex.Message);
                return null;
            }
        }
        private IItemServiceRetList GetServiceRetListMatches(ContextRz context, string strItemName)
        {
            try
            {
                //string cleanedItemName = CleanItemForQbSearch(strItemName);

                if (!Connect(context))
                    return null;
                context.TheLeader.CommentEllipse("Getting list of possible matches for: '" + strItemName + "'");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemServiceQuery q = requestSet.AppendItemServiceQueryRq();
                //Search for parts based on part.Length -3

                q.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.Name.SetValue(strItemName);
                q.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                //Get the response, which should contain the desired object, we'll get that object out of this response later
                IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet);
                //GetAt(0) == Get the 1st item in the response
                IResponse response1 = responseSet1.ResponseList.GetAt(0);
                string responseMessage = response1.StatusMessage;

                if (response1.StatusCode != 0)
                {
                    if (response1.StatusCode == 500)//No matches found
                        return null;
                    if (response1.StatusCode == 1)//No matches found //"A query request did not find a matching object in QuickBooks"
                        return null;
                }
                if (response1.Detail == null)
                {
                    Disconnect();
                    context.TheLeader.CommentEllipse("No similar matches found for for: '" + strItemName + "'");
                    return null;
                }
                IItemServiceRetList itemRetList = (IItemServiceRetList)response1.Detail;
                Disconnect();
                return itemRetList;
            }

            catch (Exception ex)
            {
                context.Leader.Error(ex.Message);
                Disconnect();
                return null;
            }
        }
        private IItemServiceRet GetAddServiceSubItem(ContextRz context, orddet_line xDetail, OrderType type)
        {
            IItemServiceRet subItem = null;
            orddet_line theItem = null;
            theItem = (orddet_line)xDetail;


            string strMfg = theItem.manufacturer.ToUpper();


            //Get Sensible Abbreviated MFG string.
            strMfg = GetShortenedManufacturerString(strMfg);
            if (string.IsNullOrEmpty(strMfg))
                throw new Exception("'" + theItem.fullpartnumber + "' appears to not have a MFG.  This is required to add to QB");
            //1st check by ID  
            if (!string.IsNullOrEmpty(theItem.qb_line_subitem_ListID))
                subItem = GetServicePartById(context, theItem, theItem.qb_line_subitem_ListID);//regardless of subitem, the qb_listID should pull the exact item.
            //2nd if no ID, search by name
            if (subItem == null)
            {
                IItemServiceRetList itemList = GetServiceRetListMatches(context, strMfg);
                //Even if only 1 result, make user specify, which will tag the List ID
                if (itemList != null)
                    subItem = AskUserForQuickbooksServiceItem(context, itemList, theItem, true);
            }
            if (subItem == null)
                if (context.Leader.AskYesNo(strMfg + " doesn't match any MFG in Quickbooks.  Would you like to add it now?"))
                    subItem = CreateLinkServiceSubitem(context, strMfg, theItem, type);

            return subItem;
        }
        private IItemServiceRet CreateLinkServiceSubitem(ContextRz context, string strMfg, orddet_line xDet, OrderType type)
        {
            try
            {
                context.TheLeader.CommentEllipse("Checking part '" + strMfg);
                IItemServiceRet existingItem = GetServicePartById(context, xDet, xDet.qb_line_subitem_ListID);
                if (existingItem != null) //Link to Exisitng
                {
                    return existingItem;
                }
                else //Add newe
                {
                    context.TheLeader.CommentEllipse("Using '" + strMfg + "' as the part number");
                    IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                    requestSet.Attributes.OnError = ENRqOnError.roeStop;
                    IItemServiceAdd svcAdd = requestSet.AppendItemServiceAddRq();
                    svcAdd.Name.SetValue(strMfg);
                    string subaccount = "";
                    svcAdd.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.SetValue(IncomeAccount(context, xDet) + subaccount);
                    svcAdd.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.SetValue(ExpenseAccount(context, xDet) + subaccount);
                    if (!Connect(context))
                        throw new Exception("Connect failed on MakeSubItemExist");
                    IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                    IResponse response = responseSet.ResponseList.GetAt(0);
                    Disconnect();
                    if (response.StatusCode != 0)
                        HandleQbStatusCode(context, response, strMfg);
                    context.TheLeader.Comment("Exported part number " + strMfg);
                    IItemServiceRet ret = (IItemServiceRet)response.Detail;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                context.Leader.Error(ex.Message);
                return null;
            }
        }







        private List<orddet_line> ConvertServiceLinesToOrddetLines(ContextRz context, ordhed_new xOrder)
        {
            List<orddet_line> ret = new List<orddet_line>();
            ordhed_service s = (ordhed_service)xOrder;
            ArrayList arrSLines = context.QtC("service_line", "select * from service_line where the_service_order_uid = '" + s.unique_id + "'");
            foreach (service_line sl in arrSLines)
            {
                context.Comment("Converting Service Line: " + sl.Name);
                ret.Add(CreateOrddetFromServiceLine(context, sl, s));
                context.Comment("Service Line: " + sl.Name + " successfully converted");
            }
            if (ret.Count <= 0)
                throw new Exception("Unable to convert service lines to orddet lines.  List empty.");
            return ret;

        }

        private orddet_line CreateOrddetFromServiceLine(ContextRz context, service_line sl, ordhed_service o)
        {
            orddet_line ret = new orddet_line();
            ret.unique_id = sl.unique_id;
            ret.orderid_service = sl.the_service_order_uid;
            if (string.IsNullOrEmpty(sl.service_name))
                throw new Exception("Please provide a 'Service Name' for this service. This is required to sync to QB");

            ret.fullpartnumber = sl.service_name;
            //The code will look for a MFG later for "subitem", need to see what we are doing for subitem
            ret.manufacturer = GetServiceLineMpnString(sl, o);//sl.service_notes;
            ret.quantity = sl.quantity;
            ret.unit_cost = sl.unit_cost;
            ret.linecode_purchase = sl.line_code;
            ret.qb_line_ListID = sl.qb_line_ListID;
            ret.qb_line_subitem_ListID = sl.qb_line_subitem_ListID;
            ret.qb_line_TxnID_purchase = sl.qb_line_TxnID;
            return ret;
        }

        private IItemNonInventoryRet GetAddNonInvItem(ContextRz context, orddet_line xDetail, IItemNonInventoryRet subItem, OrderType type)
        {
            IItemNonInventoryRet mpnItem = null;
            orddet_line theItem = null;
            theItem = (orddet_line)xDetail;

            string mfg = subItem.FullName.GetValue();
            //KT Wait, I don't want ot search including MFG, because same part might be linked to different MFG spelling
            string strPartNumber = theItem.fullpartnumber.ToUpper().Trim();
            //1st check by ID  
            if (!string.IsNullOrEmpty(theItem.qb_line_ListID))
                mpnItem = GetNonInvPartById(context, theItem, theItem.qb_line_ListID);//regardless of subitem, the qb_listID should pull the exact item.
            //2nd if no ID, search by name
            if (mpnItem == null)
            {
                IItemNonInventoryRetList itemList = GetNonInventoryRetListMatches(context, strPartNumber);
                //Even if only 1 result, make user specify, which will tag the List ID
                if (itemList != null)
                    mpnItem = AskUserForQuickbooksNonInvItem(context, itemList, theItem);
            }
            if (mpnItem == null)
                if (context.Leader.AskYesNo(theItem.manufacturer + ":" + strPartNumber + " doesn't match any Parts in Quickbooks.  Would you like to add it now?"))
                    mpnItem = CreateLinkNonInventoryItem(context, strPartNumber, theItem, type, subItem);
            return mpnItem;
        }
        private IItemNonInventoryRet GetAddNonInvSubItem(ContextRz context, orddet_line xDetail, Enums.OrderType type)
        {
            IItemNonInventoryRet subItem = null;
            orddet_line theItem = null;
            theItem = (orddet_line)xDetail;

            string strMfg = theItem.manufacturer.ToUpper();
            strMfg = GetShortenedManufacturerString(strMfg);
            if (string.IsNullOrEmpty(strMfg))
                throw new Exception("'" + theItem.fullpartnumber + "' appears to not have a MFG.  This is required to add to QB");
            //1st check by ID  
            if (!string.IsNullOrEmpty(theItem.qb_line_subitem_ListID))
                subItem = GetNonInvPartById(context, theItem, theItem.qb_line_subitem_ListID);//regardless of subitem, the qb_listID should pull the exact item.
            //2nd if no ID, search by name
            if (subItem == null)
            {
                IItemNonInventoryRetList itemList = GetNonInventoryRetListMatches(context, strMfg);
                //Even if only 1 result, make user specify, which will tag the List ID
                if (itemList != null)
                    subItem = AskUserForQuickbooksNonInvItem(context, itemList, theItem, true);
            }
            if (subItem == null)
                if (context.Leader.AskYesNo(strMfg + " doesn't match any MFG in Quickbooks.  Would you like to add it now?"))
                    subItem = CreateLinkNonInvSubitem(context, strMfg, theItem, type);

            return subItem;
        }
        private IItemNonInventoryRetList GetNonInventoryRetListMatches(ContextRz context, string strItemName)
        {
            try
            {
                string cleanedItemName = CleanItemForQbSearch(strItemName);

                if (!Connect(context))
                    return null;
                context.TheLeader.CommentEllipse("Getting list of possible matches for: '" + strItemName + "'");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemNonInventoryQuery q = requestSet.AppendItemNonInventoryQueryRq();
                //Search for parts based on part.Length -3

                q.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.Name.SetValue(cleanedItemName);
                //ENMatchCriterion matchCriterion = ENMatchCriterion.mcContains;
                //If a small name, like "TI", use NMatchCriterion.mcStartsWith;
                ENMatchCriterion matchCriterion = GetBestMatchCriterion(strItemName);

                q.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(matchCriterion);
                //Get the response, which should contain the desired object, we'll get that object out of this response later
                IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet);
                //GetAt(0) == Get the 1st item in the response
                IResponse response1 = responseSet1.ResponseList.GetAt(0);
                string responseMessage = response1.StatusMessage;

                if (response1.StatusCode != 0)
                {
                    if (response1.StatusCode == 500)//No matches found
                        return null;
                    if (response1.StatusCode == 1)//No matches found //"A query request did not find a matching object in QuickBooks"
                        return null;
                }
                if (response1.Detail == null)
                {
                    Disconnect();
                    context.TheLeader.CommentEllipse("No similar matches found for for: '" + strItemName + "'");
                    return null;
                }


                IItemNonInventoryRetList itemRetList = (IItemNonInventoryRetList)response1.Detail;
                Disconnect();
                return itemRetList;
            }

            catch (Exception ex)
            {
                context.Leader.Error(ex.Message);
                Disconnect();
                return null;
            }

        }

        private ENMatchCriterion GetBestMatchCriterion(string strItemName)
        {
            if (strItemName.Length <= 3)
                return ENMatchCriterion.mcStartsWith;
            else if(partHasShortWords(strItemName))
                return ENMatchCriterion.mcStartsWith;
            //default
            return ENMatchCriterion.mcContains;
        }

        private bool partHasShortWords(string strItemName)
        {

            //if multiword, see if first word is short
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            string[] wordArray = strItemName.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            if (wordArray[0].Length <= 3)
                    return true;
            return false;
        }

        private string CleanItemForQbSearch(string strItemName)
        {
            List<char> specialChars = new List<char>() { ',', '_', '/', ' ', '-' };

            foreach (char c in strItemName.ToArray())
            {
                if (specialChars.Contains(c))
                    strItemName = strItemName.Replace(c, ' ');

            }
            string[] words = strItemName.Split(' ');
            strItemName = words[0];// ONly look at the 1st element for best matches.
            int itemNameLength = strItemName.Length;
            if (itemNameLength >= 8)
            {                //MFGs (especially) can be short, like 3 letters.  handle shorter numbers here.
                strItemName = strItemName.Substring(0, strItemName.Length - 3);
            }
            return strItemName;

        }

        private IItemNonInventoryRet CreateLinkNonInvSubitem(ContextRz context, string strMfg, orddet_line xDet, OrderType type)
        {
            try
            {


                context.TheLeader.CommentEllipse("Checking part '" + strMfg);
                IItemNonInventoryRet existingItem = GetNonInvPartById(context, xDet, xDet.qb_line_subitem_ListID);
                if (existingItem != null) //Link to Exisitng
                {
                    return existingItem;
                }
                else //Add newe
                {
                    context.TheLeader.CommentEllipse("Using '" + strMfg + "' as the part number");
                    IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                    requestSet.Attributes.OnError = ENRqOnError.roeStop;
                    QBFC13Lib.IItemNonInventoryAdd NonStockAdd = requestSet.AppendItemNonInventoryAddRq();
                    NonStockAdd.Name.SetValue(strMfg);
                    string subaccount = "";

                    NonStockAdd.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.SetValue(IncomeAccount(context, xDet) + subaccount);
                    NonStockAdd.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.SetValue(ExpenseAccount(context, xDet) + subaccount);
                    if (!Connect(context))
                        throw new Exception("Connect failed on MakeSubItemExist");
                    IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                    IResponse response = responseSet.ResponseList.GetAt(0);
                    Disconnect();
                    if (response.StatusCode != 0)
                        HandleQbStatusCode(context, response, strMfg);
                    context.TheLeader.Comment("Exported part number " + strMfg);
                    IItemNonInventoryRet ret = (IItemNonInventoryRet)response.Detail;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                context.Leader.Error(ex.Message);
                return null;
            }

        }
        private IItemNonInventoryRet CreateLinkNonInventoryItem(ContextRz context, string strPartNumber, orddet_line xDet, OrderType type, IItemNonInventoryRet subItem)
        {

            try
            {
                //Sometimes, rz line items for parts that exist in Qb will not have the list ID tagged, therefore, we need to check by name.

                strPartNumber = QBPartFilter(context, strPartNumber);
                context.TheLeader.CommentEllipse("Checking part '" + strPartNumber);
                context.TheLeader.CommentEllipse("Using '" + strPartNumber + "' as the part number");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                //The Add Variable
                IItemNonInventoryAdd NonStockAdd = requestSet.AppendItemNonInventoryAddRq();
                //Pat Number
                NonStockAdd.Name.SetValue(strPartNumber);
                string subaccount = "";
                //Income Account
                NonStockAdd.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.SetValue(IncomeAccount(context, xDet) + subaccount);
                //Expense Account
                NonStockAdd.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.SetValue(ExpenseAccount(context, xDet) + subaccount);
                //Subitem Reference - ID
                NonStockAdd.ParentRef.ListID.SetValue(subItem.ListID.GetValue());
                //Subitem Reference - Name
                NonStockAdd.ParentRef.FullName.SetValue(subItem.FullName.GetValue());

                //Purchase Lines Description
                //Description = MFG, MPN
                if (!strPartNumber.ToLower().Contains("gcat"))
                {
                    //Description = MFG, MPN
                    string descriptionString = GetDescriptionString(subItem.FullName.GetValue(), strPartNumber);
                    NonStockAdd.ORSalesPurchase.SalesAndPurchase.PurchaseDesc.SetValue(descriptionString);
                    //Sales Lines Description
                    NonStockAdd.ORSalesPurchase.SalesAndPurchase.SalesDesc.SetValue(descriptionString);

                }



                if (!Connect(context))
                    throw new Exception("Connect failed on CreateLineMpn");
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                    throw new Exception("There was an error exporting part number " + strPartNumber + ": " + response.StatusMessage);

                //Set the listID Relationship
                IItemNonInventoryRet item = (IItemNonInventoryRet)response.Detail;
                if (item == null)
                    throw new Exception("There was an error retreiving the IITemNonInvenotryRet item from the response.");
                SetQbRelationshipNonStockItem(context, item, xDet);
                context.TheLeader.Comment("Exported part number " + strPartNumber);

                return item;
            }
            catch (Exception ex)
            {
                Disconnect();
                context.Leader.Error(ex.Message);
                return null;
            }

        }

        private bool CreateOrLinkNonInvQbPart(ContextRz context, ordhed_new xOrder, orddet_line xDetail, OrderType type)
        {
            
            IItemNonInventoryRet subItem = null;
            subItem = GetAddNonInvSubItem(context, xDetail, type);
            string subValue = subItem.FullName.GetValue();
            if (subItem == null)
            {
                string msg = "Unable to create the subitem (MFG) for this part in Quickbooks.";
                context.Comment(msg);
                throw new Exception(msg);
            }
            //MPN Item              
            IItemNonInventoryRet mpnPart = null;
            mpnPart = GetAddNonInvItem(context, xDetail, subItem, type);
            if (mpnPart == null)
                throw new Exception("Unable to create the item record for this part in Quickbooks.");

            //ConfirmMfgMatch(context, mpnPart,subItem, xOrder, xDetail);

            string foundPartListID = mpnPart.ListID.GetValue();
            string lineListID = xDetail.qb_line_ListID;
            xDetail.qb_line_ListID = foundPartListID;
            context.TheDelta.Update(context, xDetail);
            context.Comment("Setting Rz Line ListID: " + lineListID + "  for " + xDetail.fullpartnumber);
            return true;
        }

        private bool UpdateNonInventoryPart(ContextRz context, string strPartNumber, orddet_line xDet, OrderType type)
        {
            context.TheLeader.CommentEllipse("Using '" + strPartNumber + "' as the part number");
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            //Get the Inventory Part
            IItemNonInventoryQuery q = requestSet.AppendItemNonInventoryQueryRq();
            //Provide a ordernumber to get the desired order
            string partNumber = xDet.fullpartnumber; //o.qbtransactionid
            q.ORListQueryWithOwnerIDAndClass.FullNameList.Add(partNumber);
            //Connect to QB
            if (!Connect(context))
                return false;
            //Get the response, which should contain the desired object, we'll get that object out of this response later
            IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet);
            //GetAt(0) == Get the 1st item in the response
            IResponse response1 = responseSet1.ResponseList.GetAt(0);

            //If null, disconnect
            if (response1.Detail == null)
            {
                Disconnect();
                return false;
            }

            IItemNonInventoryRetList itemRetList = (IItemNonInventoryRetList)response1.Detail;
            IItemNonInventoryRet existingItem = itemRetList.GetAt(0);

            //Update the Part
            IItemNonInventoryMod NonStockMod = requestSet.AppendItemNonInventoryModRq();

            //ListID (required)
            string ListID = existingItem.ListID.GetValue();
            NonStockMod.ListID.SetValue(ListID);
            //Edit Sequence(required)
            NonStockMod.EditSequence.SetValue(existingItem.EditSequence.GetValue());
            //part number
            NonStockMod.Name.SetValue(partNumber);
            //manufacturer
            string subaccount = "";
            //Income Account
            NonStockMod.ORSalesPurchaseMod.SalesAndPurchaseMod.IncomeAccountRef.FullName.SetValue(IncomeAccount(context, xDet) + subaccount);
            //Expense Account
            NonStockMod.ORSalesPurchaseMod.SalesAndPurchaseMod.ExpenseAccountRef.FullName.SetValue(ExpenseAccount(context, xDet) + subaccount);
            //Unit Cost
            NonStockMod.ORSalesPurchaseMod.SalesAndPurchaseMod.PurchaseCost.SetValue(xDet.unit_cost);
            //Unit Price
            NonStockMod.ORSalesPurchaseMod.SalesAndPurchaseMod.SalesPrice.SetValue(xDet.unit_cost);
            //Line Description
            if (!strPartNumber.ToLower().Contains("gcat"))
            {

                string descriptionString = GetDescriptionString(xDet.manufacturer, strPartNumber);
                //Purchase Lines Description
                NonStockMod.ORSalesPurchaseMod.SalesAndPurchaseMod.PurchaseDesc.SetValue(descriptionString);
                //Sales Lines Description
                NonStockMod.ORSalesPurchaseMod.SalesAndPurchaseMod.SalesDesc.SetValue(descriptionString);



            }


            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            if (response.StatusCode != 0)
                throw new Exception("There was an error Updating part number " + strPartNumber + ": " + response.StatusMessage);
            context.TheLeader.Comment("Updated part number " + strPartNumber);
            return true;
        }


        public virtual bool MakeServiceItemExist(ContextRz context, String strPartNumber)
        {
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.IItemServiceAdd ServiceAdd = requestSet.AppendItemServiceAddRq();

            strPartNumber = IdentifierFilter(Tools.Strings.Left(strPartNumber, 30)).Trim();

            if (NonInvPartExists(context, strPartNumber))
                return true;

            context.TheLeader.Comment("Checking service '" + strPartNumber + "'...");

            if (ItemExists(context, strPartNumber))
            {
                context.TheLeader.Comment("Part '" + strPartNumber + "' already exists.");
                return true;
            }

            try
            {
                context.TheLeader.Comment("Using '" + strPartNumber + "' as the service item...");
                ServiceAdd.Name.SetValue(strPartNumber);
                string subaccount = "";
                //if (Rz3App.xLogic.IsCuetech)
                //{
                //    if (Tools.Strings.StrExt(xDet.category))
                //        subaccount = ":" + xDet.category;
                //}
                ServiceAdd.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.SetValue(IncomeAccount(context, null) + subaccount);
                ServiceAdd.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.SetValue(ExpenseAccount(context, null) + subaccount);
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                {
                    //context.TheLeader.Tell("There was an error exporting service " + strPartNumber + ": " + response.StatusMessage);
                    return false;
                }

                context.TheLeader.Comment("Exported service item " + strPartNumber);
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return false;
            }
        }
        public void MakeInvPartsExist(ContextRz context, ordhed_new xOrder)
        {
            foreach (orddet_line l in xOrder.DetailsVar.RefsList(context))
            {
                MakeInvPartExist(context, l, xOrder.OrderType);
            }
        }
        public void MakeInvPartExist(ContextRz context, orddet_line xDetail, Enums.OrderType type)
        {
            if (!Tools.Strings.StrExt(xDetail.fullpartnumber))
                return;

            String strPartNumber = GetQBPartNumber(context, xDetail, type);
            if (!Tools.Strings.StrExt(strPartNumber))
                throw new Exception(xDetail.ToString() + " has no QB part number");

            IItemInventoryRet inv = MakeInvPartExist(context, strPartNumber, xDetail, type);
            //switch (type)
            //{
            //    case Enums.OrderType.Quote:
            //    case Enums.OrderType.Sales:
            //    case Enums.OrderType.Invoice:
            //        xDetail.qbid_invoice = strPartNumber;
            //        break;
            //    default:
            //        xDetail.qbid_purchase = strPartNumber;
            //        break;
            //}
            if (inv != null)
            {
                xDetail.qb_line_ListID = inv.ListID.GetValue();
                context.Update(xDetail);
            }

        }
        public void MakeInvPartExist(ContextRz context, String strPartNumber, Enums.OrderType type)
        {
            MakeInvPartExist(context, strPartNumber, null, type);
        }
        public IItemInventoryRet MakeInvPartExist(ContextRz context, String strPartNumber, orddet_line xDetail, Enums.OrderType type)
        {
            strPartNumber = QBPartFilter(context, strPartNumber);
            if (InvPartExists(context, strPartNumber))
            {
                context.TheLeader.Comment(strPartNumber + " already exists.");
                return null;
            }

            context.TheLeader.CommentEllipse("Sending " + strPartNumber + " as an inventory part");
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.IItemInventoryAdd StockAdd = requestSet.AppendItemInventoryAddRq();
            StockAdd.Name.SetValue(Tools.Strings.Left(strPartNumber, 30).Trim());
            string subaccount = "";

            StockAdd.IncomeAccountRef.FullName.SetValue(ConfirmAccount(context, "income", "Income Account For " + strPartNumber, IncomeAccount(context, null) + subaccount));
            StockAdd.AssetAccountRef.FullName.SetValue(ConfirmAccount(context, "asset", "Asset Account For " + strPartNumber, AssetAccount(context) + subaccount));

            String cogsAccount = ConfirmAccount(context, "cogs", "COGS Account For " + strPartNumber, COGSAccount(context, null) + subaccount);
            context.TheLeader.Comment("Using COGS account " + cogsAccount);
            StockAdd.COGSAccountRef.FullName.SetValue(cogsAccount);

            if (xDetail != null)
            {
                StockAdd.PurchaseCost.SetValue(xDetail.unit_cost);
                StockAdd.SalesPrice.SetValue(xDetail.unit_price);
            }

            if (!Connect(context))
                throw new Exception("Connect failed making the inventory part exist");


            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            if (response.StatusCode != 0)
            {
                if (response.StatusCode == 3100)
                    context.TheLeader.Comment(strPartNumber + " already exists");
                else
                    throw new Exception("There was an error exporting part number " + strPartNumber + ": " + response.StatusMessage);
            }
            else
                context.TheLeader.Comment("Exported part number " + strPartNumber);
            IItemInventoryRet ret = (IItemInventoryRet)response.Detail;
            return ret;
        }
        protected virtual String ConfirmAccount(ContextRz context, String key, String caption, String account)
        {
            return account;  //this is overridden for some companies where they want to put the account in every time
        }



        private ISalesOrderRet GetQbSaleRet(ContextRz context, ordhed_sales o)
        {
            //Instantiate a List of object(s) that was returned in the response
            ISalesOrderRetList salesRetList = GetQbSaleRetList(context, o);
            if (salesRetList == null)
                context.Leader.Error("Could not return the Sales Ret List from QB.");
            ISalesOrderRet ret = salesRetList.GetAt(0);
            string orderNumber = ret.RefNumber.GetValue();
            return ret;
        }


        private ISalesOrderRetList GetQbSaleRetList(ContextRz context, ordhed_sales o)
        {
            ISalesOrderRetList salesRetList = null;
            //Setup the request to query the existing sales order.
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            //Create the order query object to get the order we want to modify, add to the requestSet
            ISalesOrderQuery q = requestSet.AppendSalesOrderQueryRq();
            q.IncludeLineItems.SetValue(true); //If False, you will get NO LINE ITEMS!!    
            q.ORTxnNoAccountQuery.TxnIDList.Add(o.qb_order_TxnID);
            //Connect to QB
            if (!Connect(context))
                return null;
            //Get the response, which should contain the desired object, we'll get that object out of this response later
            IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet);
            IResponse response1 = responseSet1.ResponseList.GetAt(0);
            //If null, disconnect
            if (response1.Detail == null)
            {
                Disconnect();
                string badID = o.qb_order_TxnID;
                o.qb_order_TxnID = null;
                o.Update(context);
                throw new Exception("Could not find a Quickbooks sale with TxnID = " + badID + " Has it been deleted from Quickbooks?" + Environment.NewLine + Environment.NewLine + "Rz link deleted, you can re-sync this order to create it in Quickbooks.  ***Beware** this can create a duplicate entry if it has already been manually added to Quickbooks.");
            }
            //Instantiate a List of object(s) that was returned in the response
            salesRetList = (ISalesOrderRetList)response1.Detail;
            Disconnect(); //End of Sales Order Ret List GET
            return salesRetList;

        }


        private IPurchaseOrderRet GetQbPurchaseRet(ContextRz context, ordhed_new p)
        {
            //Instantiate a List of object(s) that was returned in the response
            IPurchaseOrderRetList purchaseRetList = GetQbPurchaseRetList(context, p);
            if (purchaseRetList == null)
                context.Leader.Error("Could not return the Purchase Ret List from QB.");
            IPurchaseOrderRet ret = purchaseRetList.GetAt(0);
            string orderNumber = ret.RefNumber.GetValue();
            string orderTxnID = ret.TxnID.GetValue();
            return ret;
        }

        private IPurchaseOrderRetList GetQbPurchaseRetList(ContextRz context, ordhed_new p)
        {
            IPurchaseOrderRetList purchaseRetList = null;
            //Setup the request to query the existing purchase order.
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            //Create the order query object to get the order we want to modify, add to the requestSet
            IPurchaseOrderQuery q = requestSet.AppendPurchaseOrderQueryRq();
            q.IncludeLineItems.SetValue(true); //If False, you will get NO LINE ITEMS!!    
            q.ORTxnQuery.TxnIDList.Add(p.qb_order_TxnID);
            //Connect to QB
            if (!Connect(context))
                return null;
            //Get the response, which should contain the desired object, we'll get that object out of this response later
            IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet);
            IResponse response1 = responseSet1.ResponseList.GetAt(0);
            //If null, disconnect
            if (response1.Detail == null)
            {
                Disconnect();
                string badID = p.qb_order_TxnID;
                p.qb_order_TxnID = null;
                p.Update(context);
                throw new Exception("Could not find a Quickbooks purchase with TxnID = " + badID + " Has it been deleted from Quickbooks? Link deleted");
            }
            //Instantiate a List of object(s) that was returned in the response
            purchaseRetList = (IPurchaseOrderRetList)response1.Detail;
            Disconnect(); //End of purchase Order Ret List GET
            return purchaseRetList;

        }





        public virtual bool SendOrder(ContextRz context, ordhed_new xOrder)
        {
            //Old way
            try
            {


                if (!Connect(context))
                {
                    context.TheLeader.Comment("No QB connection.");
                    return false;
                }

                Disconnect();
                context.Leader.CommentEllipse("Sending " + xOrder.ordertype + " Order: " + xOrder.ordernumber);
                //Ensure Company MEets Criteria
                if (!MeetsQBCriteria(context, xOrder))
                    return false;
                //QB Ship Via
                MakeShipViaExist(context, xOrder.shipvia);
                //QB Terms
                MakeTermsExist(context, xOrder.terms);
                //Rz Company
                company c = xOrder.CompanyVar.RefGet(context);
                if (c == null)
                    throw new Exception("Cound not identify Rz Company");
                //QB Company
                GetCreateQuickbooksCompany(context, c, xOrder);
                //QB Line Item Creation / Linkage
                CreateOrLinkQbParts(context, xOrder);
                //Customer Reference Message, needed?
                if (!CheckMessage(context, xOrder))
                    return false;

                //Create the Order
                bool success = false;
                bool update = !string.IsNullOrEmpty(xOrder.qb_order_TxnID);
                switch (xOrder.OrderType)
                {

                    case Enums.OrderType.Sales:
                        {
                            if (xOrder is ordhed_sales)
                                CurrentSalesOrder = (ordhed_sales)xOrder;

                            if (update)
                                success = UpdateQBSalesOrder(context, (ordhed_sales)xOrder);
                            else
                                success = CreateQBSalesOrder(context, (ordhed_sales)xOrder, TheCustomer);
                            break;
                        }
                    case OrderType.Service:
                    case Enums.OrderType.Purchase:
                        {
                            if (xOrder.OrderType is OrderType.Service)
                                CurrentServiceOrder = (ordhed_service)xOrder;
                            else
                                CurrentPurchaseOrder = (ordhed_purchase)xOrder;

                            if (update)
                                success = UpdateQBPurchaseOrder(context, xOrder);
                            else
                                success = CreateQBPurchaseOrder(context, xOrder, TheVendor);
                            break;
                        }
                    default:
                        throw new Exception("Unknown order type");
                }
                if (!success)
                {
                    context.TheLeader.Comment("Order creation failed.");
                    context.TheLeader.StopPopStatus(true);
                    return false;
                }
                context.Leader.CommentEllipse("Quickbooks Synchronization Successful for " + xOrder.ToString());
                return true;
            }
            catch (Exception ee)
            {
                context.TheLeader.Comment(ee.Message);
                context.TheLeader.Error(ee);
                return false;
            }
        }

        private void GetCreateQuickbooksCompany(ContextRz context, company c, ordhed xOrder)
        {
            //Quickbooks Company           
            bool exists = false;
            //CompanyType
            CompanySelectionType type;
            switch (xOrder.OrderType)
            {
                case OrderType.Sales:
                    type = CompanySelectionType.Customer;
                    break;
                case OrderType.Service:
                case OrderType.Purchase:
                    type = CompanySelectionType.Vendor;
                    break;
                default:
                    throw new Exception("CompanySelectionType not defined for " + xOrder.OrderType.ToString());

            }

            //Get By ID           
            exists = GetQuickbooksCompanyByID(context, c, type);

            //No ID, Identify & Link Existing QB Company By Name
            if (!exists)
            {
                if (context.Leader.AskYesNo("No relationship between QB and Rz for " + c.companyname + " exists, would you like to search / create it?"))
                    exists = SearchQBCompanyByName(context, c, xOrder.OrderType);
            }
            //Not identified by Search, add?
            if (!exists)
            {
                if (context.Leader.AskYesNo("Would you like to add this company to Quickbooks?"))
                {
                    string companyName = MakeCompanyExist(context, xOrder);
                    exists = !string.IsNullOrEmpty(companyName);
                }
            }
            //Must have a customer / vendor
            if (!exists)
                throw new Exception("Quickbooks company not found or created for this order.  Cannot proceed with adding order.");

        }

        private bool SearchQBCompanyByName(ContextRz context, company c, OrderType oType)
        {
            switch (oType)
            {
                case OrderType.Sales:
                case OrderType.Invoice:
                    {
                        TheCustomer = SearchQBCustomerByName(context, c);
                        return TheCustomer != null;
                    }
                case OrderType.Service:
                case OrderType.Purchase:
                    {
                        TheVendor = SearchQBVendorByName(context, c);
                        return TheVendor != null;
                    }
            }
            return false;
        }



        private void SetQbSalesAgent(ContextRz context, object qbObject, QuickbooksSyncType syncType, ordhed_new xOrder)
        {
            //Set The Sales Agent Initials        
            string qbAgentInitials = GetQbAgentInitials(context, xOrder);



            if (!string.IsNullOrEmpty(qbAgentInitials))
            {
                //Search for the Rep based on initials
                n_user u = n_user.GetById(context, xOrder.base_mc_user_uid);
                if (u == null)
                    return;
                ISalesRepRet qbSalesRep = GetQbSalesRep(context, u);
                //If doesn't exist / null, offer to create
                if (qbSalesRep == null)
                {
                    return;
                    //if (context.Leader.AskYesNo(qbAgentInitials + " does not exist as a Sales Rep in Quickbooks.  Would you like to add it?"))
                    //{
                    //    qbSalesRep = CreateOrAddSalesAgent();
                    //}
                }
                if (qbSalesRep != null)
                {
                    //Set the List ID in Rz for this Sales Rep
                    switch (syncType)
                    {
                        case QuickbooksSyncType.Insert:
                            {
                                if(xOrder.OrderType == OrderType.Purchase)
                                {
                                    IPurchaseOrderAdd p = (IPurchaseOrderAdd)qbObject;
                                    p.Other1.SetValue(qbAgentInitials);
                                }
                                else if (xOrder.OrderType == OrderType.Sales)
                                {
                                    ISalesOrderAdd s = (ISalesOrderAdd)qbObject;
                                    s.SalesRepRef.FullName.SetValue(qbAgentInitials);

                                }
                                
                            }
                            break;
                        case QuickbooksSyncType.Update:
                            {

                                if (xOrder.OrderType == OrderType.Purchase)
                                {
                                    IPurchaseOrderMod p = (IPurchaseOrderMod)qbObject;
                                    p.Other1.SetValue(qbAgentInitials);
                                }
                                else if (xOrder.OrderType == OrderType.Sales)
                                {
                                    ISalesOrderMod s = (ISalesOrderMod)qbObject;
                                    s.SalesRepRef.FullName.SetValue(qbAgentInitials);

                                }

                                
                            }
                            break;
                    }
                }


            }
        }

        private ISalesRepRet AddSalesAgent(Context x)
        {
            throw new NotImplementedException();
        }

        public ISalesRepRet GetQbSalesRep(ContextRz x, n_user u)
        {
            ISalesRepRetList ret = DoSalesRepQuery(x, u);
            if (ret == null) return null;
            return ret.GetAt(0);
        }

        public ISalesRepRet GetQbSalesRepByInitials(ContextRz x, string initials)
        {
            n_user u = (n_user)x.QtO("n_user", "select * from n_user where user_initials = '" + initials + "'");
            if (u == null)
            {
                x.Leader.Error("No user found with intials" + initials);
                return null;
            }
            ISalesRepRetList ret = DoSalesRepQuery(x, u);
            if (ret == null) return null;
            return ret.GetAt(0);
        }

        public ISalesRepRet GetQbSalesRepByName(ContextRz x, string name)
        {
            ISalesRepRetList ret = DoSalesRepQuery(x, name);
            if (ret == null) return null;
            return ret.GetAt(0);
        }

        private string GetQbAgentInitials(ContextRz x, ordhed_new xOrder)
        {
            string ret = x.TheSysRz.TheQuickBooksLogic.InitalsCalc(x, xOrder);

            if (string.IsNullOrEmpty(ret))
            {
                x.TheLeader.Comment("Could not determine the agent's initials for this order.  Skipping.");
                return null;
            }

            if (ret.Length > 3)
            {
                x.TheLeader.Comment("Agend itials are longer than Quickbooks allows: ('" + ret + "')  Skipping.");
                return null;
            }
            return ret;
        }
        //private void SetQbAgent(ContextRz context, object orderAdd, ordhed_new xOrder, QuickbooksSyncType syncType)
        //{

        //    //Agent Initals  - Needed??
        //    String strInitials = context.TheSysRz.TheQuickBooksLogic.InitalsCalc(context, xOrder);
        //    if (string.IsNullOrEmpty(strInitials))
        //    {
        //        context.TheLeader.Comment("Could not determine the agent's initials for this order.  Skipping.");
        //        return;
        //    }

        //    if (strInitials.Length > 3)
        //    {
        //        context.TheLeader.Comment("Agend itials are longer than Quickbooks allows: ('" + strInitials + "')  Skipping.");
        //        return;
        //    }

        //    //String strAgentInitials = "";
        //    //if (!Tools.Strings.StrExt(strAgentInitials))
        //    //    strAgentInitials = strInitials;
        //    //if (Tools.Strings.StrExt(strInitials))
        //    //    context.TheLeader.Comment("Using class initials: " + strInitials);

        //    //if (Tools.Strings.StrExt(strAgentInitials))
        //    //{
        //    //    context.TheLeader.Comment("Using agent initials: " + strAgentInitials);
        //    //    SaleMod.SalesRepRef.FullName.SetValue(strAgentInitials);
        //    //}



        //    switch (syncType)
        //    {
        //        case QuickbooksSyncType.Insert:
        //            {
        //                ISalesOrderAdd s = (ISalesOrderAdd)orderAdd;
        //                s.SalesRepRef.FullName.SetValue(strInitials);
        //            }
        //            break;
        //        case QuickbooksSyncType.Update:
        //            {
        //                ISalesOrderMod s = (ISalesOrderMod)orderAdd;
        //                s.SalesRepRef.FullName.SetValue(strInitials);
        //            }
        //            break;
        //            //case "IPurchaseOrderAdd":
        //            //    {
        //            //        IPurchaseOrderAdd s = (IPurchaseOrderAdd)orderAdd;
        //            //        s.ref.FullName.SetValue(strInitials);
        //            //    }
        //            //    break;
        //            //case "IPurchaseOrderMod":
        //            //    {
        //            //        IPurchaseOrderMod s = (IPurchaseOrderMod)orderAdd;
        //            //        s.SalesRepRef.FullName.SetValue(strInitials);
        //            //    }
        //            //    break;

        //    }
        //}






        private void CheckQbPartNumberMismatch(ContextRz context, orddet_line d, ordhed_new xOrder)
        {
            string message = "";
            //Get the linked item from QB
            IItemNonInventoryRet existingNonInvItem = null;
            IItemServiceRet existingServiceItem = null;
            if (xOrder is ordhed_sales || xOrder is ordhed_purchase)
                existingNonInvItem = GetNonInvPartById(context, d, d.qb_line_ListID);
            else if (xOrder is ordhed_service)
                existingServiceItem = GetServicePartById(context, d, d.qb_line_ListID);


            if (existingNonInvItem == null && existingServiceItem == null)//No match of any type found
            {
                if (context.Leader.AskYesNo("No Quickbooks part was found with ListID: " + d.qb_line_ListID + " Would you like to remove this linkage and fix now?"))
                    ClearListIDLInkage(context, d, xOrder.OrderType);
                else
                {
                    message = "Could not locate Quickbooks item with listID of: " + d.qb_line_ListID;
                    context.Comment(message);
                    throw new Exception(message);
                }

            }


            //Get the part string, will be in MFG:PARTNUMBER format
            string qbPartString = "";
            if (existingNonInvItem != null)
                qbPartString = existingNonInvItem.FullName.GetValue();
            else if (existingServiceItem != null)
                qbPartString = existingServiceItem.FullName.GetValue();
            else
                throw new Exception("Could not obtain Quickbooks part string from the API Ret item.");



            string qbPartNumber = (qbPartString.Split(':')[1] ?? "").Trim().ToUpper();
            string qbMfg = (qbPartString.Split(':')[0] ?? "").Trim().ToUpper();

            string rzPartNumber = d.fullpartnumber.Trim().ToUpper();
            string rzMfg = d.manufacturer.Trim().ToUpper();




            if (qbPartNumber != rzPartNumber)
            {
                if (context.Leader.AskYesNo("The Qb Part (" + qbPartNumber + ") does not match the current Rz Partnumber (" + rzPartNumber + ").  Would you like to update Quickbooks with the new Rz Data?"))
                    ClearListIDLInkage(context, d, xOrder.OrderType);
            }
            else if (qbMfg != rzMfg)
            {
                if (context.Leader.AskYesNo("The Qb Manufacturer (" + qbMfg + ") does not match the current Rz Partnumber (" + rzMfg + ").  Would you like to update Quickbooks with the new Rz Data?"))
                    ClearListIDLInkage(context, d, xOrder.OrderType);
            }

        }






        private string GetTransactionIdFromLineItem(orddet_line d, ordhed_new xOrder)
        {
            //-1 = new line
            // blank = remove from QB
            string txnID = "";
            switch (xOrder.OrderType)
            {
                case OrderType.Purchase:
                    txnID = d.qb_line_TxnID_purchase;
                    break;
                case OrderType.Service:
                case OrderType.Sales:
                    txnID = d.qb_line_TxnID;
                    break;
            }
            if (string.IsNullOrEmpty(txnID))//Else, if there is was no txnID, this is a new line     
                txnID = "-1";
            return txnID;
        }



        private List<OrderLineStatus> invalidQbStatus = new List<OrderLineStatus>() { OrderLineStatus.RMA_Received, OrderLineStatus.RMA_Receiving, OrderLineStatus.Vendor_RMA_Packing, OrderLineStatus.Vendor_RMA_Shipped, OrderLineStatus.Void, OrderLineStatus.Scrapped };



        private bool CreateQBSalesOrder(ContextRz context, ordhed_sales xOrder, ICustomerRet customer)
        {
            //Add the Sales Order
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            if (!Connect(context))
            {
                return false;
            }

            context.Comment("Creating the Quickbooks Sales Item for " + xOrder.ordernumber);
            if (xOrder.credit_amount != 0)
            {
                //make the credit item exist
                MakeServiceItemExist(context, xOrder.credit_caption);
            }

            List<orddet_line> lines = xOrder.DetailsVar.RefsList(context);
            List<orddet_line> charges = new List<orddet_line>();
            foreach (orddet_line d in charges)
            {
                MakeServiceItemExist(context, d.fullpartnumber);
                lines.Add(d);
            }
            ISalesOrderAdd SalesAdd = requestSet.AppendSalesOrderAddRq();




            //Set The Sales Agent                
            SetQbSalesAgent(context, SalesAdd,QuickbooksSyncType.Insert, xOrder);


            //Set the Customer and Contact references
            string custListID = customer.ListID.GetValue();
            SalesAdd.RefNumber.SetValue(xOrder.ordernumber);
            SalesAdd.CustomerRef.ListID.SetValue(custListID);
            //Buyer Name (contactname)
            if (!string.IsNullOrEmpty(xOrder.contactname))
            {
                int leng = xOrder.contactname.Length;
                if (leng >= 30)
                    throw new Exception("Sorry, '" + xOrder.contactname + "' is " + leng + " characters long, and is too long for the Quickbooks Contact Contact Name field.  Please check the contact name and ensure you have the correct data, or reduce the length of the name.");


            }
            else
                SalesAdd.Other.SetValue(xOrder.contactname);

            //Customer PO
            SalesAdd.PONumber.SetValue(Tools.Strings.Left(xOrder.orderreference, Convert.ToInt32(SalesAdd.PONumber.GetMaxLength())));
            //Sale Terms
            if (Tools.Strings.StrExt(xOrder.terms))
                SalesAdd.TermsRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(xOrder.terms), Convert.ToInt32(SalesAdd.TermsRef.FullName.GetMaxLength())));
            //Ship Via
            if (Tools.Strings.StrExt(xOrder.shipvia))
                SalesAdd.ShipMethodRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(xOrder.shipvia), Convert.ToInt32(SalesAdd.ShipMethodRef.FullName.GetMaxLength())));
            //Customet Message from Print Comment
            SalesAddCustomerMsg(context, SalesAdd, xOrder);

            //LineItems
            CreateQbLineItemsSale(context, xOrder, SalesAdd);

            IMsgSetResponse responseSet = null;
            IResponse response = null;
            //Actually Send the Response



            Connect(context);
            //context.TheLeader.CommentEllipse("Sending " + xOrder.ToString());

            //Send the request and get the response from QuickBooks
            responseSet = sessionManager.DoRequests(requestSet);//This sends the Sale, should have a ISalesOrderRet response                    
            response = responseSet.ResponseList.GetAt(0);
            int code = response.StatusCode;
            string message = response.StatusMessage;
            if (code != 0)
            {
                if (code == 3205)

                    AlertFixCompanyAddress(context, xOrder, message);
                else
                    HandleQbStatusCode(context, response, xOrder.ordernumber);
            }

            ISalesOrderRet theSale = (ISalesOrderRet)response.Detail;
            //End the session and close the connection to QuickBooks
            Disconnect();
            if (theSale == null)
            {
                string msg = "Could not obtain valid ISalesOrderRet response from Quickbooks";
                context.TheLeader.CommentEllipse("Error: " + msg);
                throw new Exception(msg);
            }
            SetQbRelationshipOrder(context, theSale, xOrder);
            SetQbRelationshipSalesLines(context, theSale, xOrder);



            Disconnect();

            //context.Leader.CommentEllipse("Quickbooks Synchronization Successful for " + xOrder.ToString());
            return true;

        }

        private bool UpdateQBSalesOrder(ContextRz context, ordhed_sales o)
        {
            if (o == null)
                return false;

            context.Comment("Updating Sales Order# " + o.ordernumber);

            //Get the SaleRet from a SaleRetList
            ISalesOrderRet qbSaleRet = GetQbSaleRet(context, o);

            //Setup the Modify object, a modify will return a single <object>Ref in the response
            //Setup the request to query the existing sales order.
            IMsgSetRequest requestSetSaleMod = GetLatestMsgSetRequest(context, sessionManager);
            requestSetSaleMod.Attributes.OnError = ENRqOnError.roeStop;
            //Create the order query object to get the order we want to modify, add to the requestSet
            ISalesOrderMod SaleMod = requestSetSaleMod.AppendSalesOrderModRq();
            string saleEditSequence = qbSaleRet.EditSequence.GetValue();
            SaleMod.EditSequence.SetValue(saleEditSequence);
            string qbSaleTxnId = qbSaleRet.TxnID.GetValue();
            SaleMod.TxnID.SetValue(qbSaleTxnId);


            //Set The Sales Agent                
            SetQbSalesAgent(context, SaleMod, QuickbooksSyncType.Update, o);

            //Order Number (can change)
            SaleMod.RefNumber.SetValue(o.ordernumber);
            //Order Date
            if (Tools.Dates.DateExists(o.orderdate))
            {
                SaleMod.TxnDate.SetValue(o.orderdate);
                SaleMod.ShipDate.SetValue(o.orderdate);
                SaleMod.DueDate.SetValue(o.EstimateDueDate());
            }
            //Customer PO
            SaleMod.PONumber.SetValue(Tools.Strings.Left(o.orderreference, Convert.ToInt32(SaleMod.PONumber.GetMaxLength())));
            //Sale Terms
            if (Tools.Strings.StrExt(o.terms))
                SaleMod.TermsRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(o.terms), Convert.ToInt32(SaleMod.TermsRef.FullName.GetMaxLength())));
            //Ship Via
            if (Tools.Strings.StrExt(o.shipvia))
                SaleMod.ShipMethodRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(o.shipvia), Convert.ToInt32(SaleMod.ShipMethodRef.FullName.GetMaxLength())));
            //Buyer Name (contactname)
            if (!string.IsNullOrEmpty(o.contactname))
                SaleMod.Other.SetValue(o.contactname);

            //Customer Message from Print Comment
            SalesModCustomerMsg(context, SaleMod, o);

            //Add / Update Line Items
            UpdateQbLineItemsSale(context, SaleMod, o);

            //Actually Send the Response              
            context.TheLeader.CommentEllipse("Sending Sales Order Update Request To Quickbooks API");

            IResponse response = GetResponse(context, requestSetSaleMod);
            if (response == null)
                context.Error("Null response from Quickbooks.");
            //Get the response code
            int code = response.StatusCode;
            string message = response.StatusMessage;
            if (code != 0)
            {
                if (code == 3205)

                    AlertFixCompanyAddress(context, o, message);
                else
                    HandleQbStatusCode(context, response, o.ordernumber, o);
            }

            ISalesOrderRet theSale = (ISalesOrderRet)response.Detail;
            //End the session and close the connection to QuickBooks                
            if (theSale == null)
            {
                string msg = "Could not obtain valid ISalesOrderRet response from Quickbooks";
                context.TheLeader.CommentEllipse("Error: " + msg);
                throw new Exception(msg);
            }

            SetQbRelationshipSalesLines(context, theSale, o);
            return true;

        }

        private bool CreateQbLineItemsSale(ContextRz context, ordhed_sales xOrder, ISalesOrderAdd SalesAdd, string strInitials = null)
        {
            context.Comment("Creating Line Items for Sales Order# " + xOrder.ordernumber);
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //Add the details            
            try
            {
                foreach (orddet_line d in xOrder.DetailsList(context))
                {

                    if (Tools.Strings.StrExt(d.fullpartnumber))
                    {
                        context.Comment("Creating Line Item " + d.fullpartnumber);
                        String strPartNumber = GetQBPartNumber(context, d, Enums.OrderType.Invoice);
                        //if (ShouldSendItemToQb(context, d))
                        if (Tools.Strings.StrExt(strPartNumber))
                        {
                            IORSalesOrderLineAdd xItem = SalesAdd.ORSalesOrderLineAddList.Append();
                            //Set field value for ListID
                            xItem.SalesOrderLineAdd.ItemRef.ListID.SetValue(d.qb_line_ListID);
                            //Total Price (price & QTY)
                            //Double dblAmount = Math.Round(d.unit_price * d.quantity, 2);
                            //Part Number
                            xItem.SalesOrderLineAdd.ItemRef.FullName.SetValue(Tools.Strings.Left(strPartNumber, 30).Trim());
                            //Quantity
                            xItem.SalesOrderLineAdd.Quantity.SetValue(d.quantity);
                            //Unit Price
                            //Double dblAmount = Math.Round(d.unit_price * d.quantity, 2);
                            double unit_price = Math.Round(d.unit_price, 5);
                            xItem.SalesOrderLineAdd.ORRatePriceLevel.Rate.SetValue(unit_price);

                            //Description
                            //Description
                            if (!d.fullpartnumber.ToLower().Contains("gcat"))//If this isn't a GCAT line include description
                            {
                                string descriptionString = GetDescriptionString(d.manufacturer, d.fullpartnumber);
                                //Purchase Lines Description
                                xItem.SalesOrderLineAdd.Desc.SetValue(descriptionString);
                            }


                            //Customer Description = IPN                         
                            string custdescriptionString = GetCustomerInternalDescriptionString(d);

                            if (!string.IsNullOrEmpty(custdescriptionString))
                                xItem.SalesOrderLineAdd.Other1.SetValue(custdescriptionString);

                            //if (SetClassToInitials(context) && Tools.Strings.StrExt(strInitials))
                            xItem.SalesOrderLineAdd.Other2.SetValue(d.linecode_sales.ToString());
                        }
                        context.Comment(d.fullpartnumber + " created successfully");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error adding the line items to this QuickBooks transfer: " + ex.Message);
                return false;
            }
        }

        private void UpdateQbLineItemsSale(ContextRz context, ISalesOrderMod SaleMod, ordhed_new xOrder)
        {

            context.Comment("Updating Line Items for Sales Order# " + xOrder.ordernumber);
            string txnID = null;

            //KT the lines need to be updated in the same order they appear in QB
            //Believe this order can be determined by the sequantiality of the qb_line_txnid
            //This list is just to help watch these id's and the order they are going in.
            List<string> existingTxnIds = new List<string>();
            foreach (orddet_line d in xOrder.DetailsList(context))
            {
                existingTxnIds.Add(d.qb_line_TxnID);
            }



            //context.TheLeader.CommentEllipse("Sending line items");
            foreach (orddet_line d in xOrder.DetailsList(context))
            {
                //https://stackoverflow.com/questions/27671952/how-to-add-an-invoice-line-item-to-an-existing-quickbooks-invoice-using-qbfc-and
                if (Tools.Strings.StrExt(d.fullpartnumber))
                {
                    context.Comment("Updating Line Item " + d.fullpartnumber);
                    //Instantiate the Modification object
                    IORSalesOrderLineMod lineMod = SaleMod.ORSalesOrderLineModList.Append();

                    //TxnID
                    txnID = GetTransactionIdFromLineItem(d, xOrder);
                    //Get the NonInventory Part by Id.

                    //Check for Part Numbr Mismatch, offer to clear
                    CheckQbPartNumberMismatch(context, d, xOrder);


                    lineMod.SalesOrderLineMod.TxnLineID.SetValue(txnID);
                    if (txnID == "-1")//New Line need set linecode for linkage
                        lineMod.SalesOrderLineMod.Other2.SetValue(d.linecode_sales.ToString());

                    //Set field value for ListID
                    string ListID = d.qb_line_ListID;
                    if (string.IsNullOrEmpty(ListID))
                        CreateOrLinkQbPart(context, xOrder, d, OrderType.Sales);
                    else
                        UpdateNonInventoryPart(context, d.fullpartnumber, d, OrderType.Sales);
                    if (string.IsNullOrEmpty(d.qb_line_ListID))
                        throw new Exception("Unable to create and link Qb part.  Missing ListID");
                    lineMod.SalesOrderLineMod.ItemRef.ListID.SetValue(d.qb_line_ListID);

                    //Set field value for FullName
                    lineMod.SalesOrderLineMod.ItemRef.FullName.SetValue(d.fullpartnumber);

                    //Description
                    if (!d.fullpartnumber.ToLower().Contains("gcat"))//If this isn't a GCAT line include description
                    {
                        //Set field value for Desc
                        string descriptionString = GetDescriptionString(d.manufacturer, d.fullpartnumber);
                        lineMod.SalesOrderLineMod.Desc.SetValue(descriptionString);

                    }



                    //If you specify both Rate and Amount in a request, the Rate you provide will be ignored, and you will receive a warning. If you specify both Quantity and Amount in an Add request, QuickBooks will use them to calculate Rate. (Rate, Amount, and Quantity cannot be cleared.)
                    //i.e. don't sent amount, just send rate (unit_price) and Quanity (unit)
                    //Quantity
                    lineMod.SalesOrderLineMod.Quantity.SetValue(d.quantity);
                    //Unit Price;
                    double unit_price = Math.Round(d.unit_price, 5);
                    lineMod.SalesOrderLineMod.ORRatePriceLevel.Rate.SetValue(unit_price);


                    //Customer Description = IPN     
                    string custdescriptionString = GetCustomerInternalDescriptionString(d);

                    //Other1 = Customer Internal = MFG,IPN                       
                    if (!string.IsNullOrEmpty(custdescriptionString))
                        if (custdescriptionString.Length > 29)//Other1 is limited to 29 Characters
                            context.Leader.Tell("Please Note, Quickbooks has a limit of 29 characters for the 'Other1' field (which is where Sensible has chosen to save the Customer Internal.) " + custdescriptionString + " is " + custdescriptionString.Length.ToString() + " characters long, and can therefore not be sent, pleae input this manually for now and notify IT for a more permenant solution.");
                        else
                            lineMod.SalesOrderLineMod.Other1.SetValue(custdescriptionString);
                    context.Comment("Update for " + d.fullpartnumber + " is successful.");
                }
            }
            return;

        }




        private bool CreateQBPurchaseOrder(ContextRz context, ordhed_new xOrder, IVendorRet vendor)
        {
            List<orddet_line> lines = null;
            ordhed_service TheServiceOrder = null;
            ordhed_purchase ThePurchaseOrder = null;

            //Service Orders - These need to come after the line item they relate to
            //so that line item has a qb_line_listID

            switch (xOrder.OrderType)
            {
                case OrderType.Service:
                    {
                        context.Comment("Creating Quickbooks object for Service Order# " + xOrder.ordernumber);
                        TheServiceOrder = (ordhed_service)xOrder;
                        //First Create the Line Items
                        lines = TheServiceOrder.DetailsVar.RefsList(context);
                        break;
                    }
                case OrderType.Purchase:
                    {
                        context.Comment("Creating Quickbooks object for Purchase Order# " + xOrder.ordernumber);
                        ThePurchaseOrder = (ordhed_purchase)xOrder;
                        lines = ThePurchaseOrder.DetailsVar.RefsList(context);
                        break;
                    }
                default:
                    return false;
            }



            //Add the Sales Order
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            if (!Connect(context))
            {
                return false;
            }

            IPurchaseOrderAdd purchaseAdd = requestSet.AppendPurchaseOrderAddRq();


            //Set The Sales Agent                
            SetQbSalesAgent(context, purchaseAdd, QuickbooksSyncType.Insert, xOrder);


            //Vendor Reference
            string vendName = vendor.Name.GetValue();
            string vendListID = vendor.ListID.GetValue();
            purchaseAdd.RefNumber.SetValue(xOrder.ordernumber);
            purchaseAdd.VendorRef.ListID.SetValue(vendListID);

            //Agent Initials
            //String strInitials = context.TheSysRz.TheQuickBooksLogic.InitalsCalc(context, xOrder);
            //String strAgentInitials = "";
            //if (!Tools.Strings.StrExt(strAgentInitials))
            //    strAgentInitials = strInitials;
            //if (Tools.Strings.StrExt(strInitials))
            //    context.TheLeader.Comment("Using class initials: " + strInitials);

            //Class?                         
            purchaseAdd.ClassRef.FullName.SetValue("Vendor");


            //Dates
            if (Tools.Dates.DateExists(xOrder.orderdate))
            {
                purchaseAdd.TxnDate.SetValue(xOrder.orderdate);
                purchaseAdd.DueDate.SetValue(xOrder.orderdate);
            }

            //Purchase Terms
            if (Tools.Strings.StrExt(xOrder.terms))
                purchaseAdd.TermsRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(xOrder.terms), Convert.ToInt32(purchaseAdd.TermsRef.FullName.GetMaxLength())));
            //Ship Via
            if (Tools.Strings.StrExt(xOrder.shipvia))
                purchaseAdd.ShipMethodRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(xOrder.shipvia), Convert.ToInt32(purchaseAdd.ShipMethodRef.FullName.GetMaxLength())));
            //Shipping Account = Other2
            if (Tools.Strings.StrExt(xOrder.shippingaccount))
                purchaseAdd.Other2.SetValue(Tools.Strings.Left(IdentifierFilter(xOrder.shippingaccount), Convert.ToInt32(purchaseAdd.Other2.GetMaxLength())));

            //Addresses
            //SplitTextAddress(context, xOrder.companyname, purchaseAdd.ShipAddress, xOrder.shippingaddress);
            //SplitTextAddress(context, xOrder.companyname, purchaseAdd.VendorAddress, xOrder.billingaddress);

            //LineItems
            CreateQbLineItemsPurchase(context, xOrder, purchaseAdd);
            IMsgSetResponse responseSet = null;
            IResponse response = null;
            //Actually Send the Response

            //context.TheLeader.CommentEllipse("Sending " + xOrder.ToString());
            //Send the request and get the response from QuickBooks
            Connect(context);
            responseSet = sessionManager.DoRequests(requestSet);//This sends the Sale, should have a ISalesOrderRet response                    
            response = responseSet.ResponseList.GetAt(0);
            int code = response.StatusCode;
            string message = response.StatusMessage;
            if (code != 0)
            {
                if (code == 3205)

                    AlertFixCompanyAddress(context, xOrder, message);
                else
                    HandleQbStatusCode(context, response, xOrder.ordernumber);
            }

            IPurchaseOrderRet thePurchase = (IPurchaseOrderRet)response.Detail;
            //End the session and close the connection to QuickBooks
            Disconnect();
            if (thePurchase == null)
            {
                string msg = "Could not obtain valid IPurchaseOrderRet response from Quickbooks";
                context.TheLeader.CommentEllipse("Error: " + msg);
                throw new Exception(msg);
            }
            SetQbRelationshipOrder(context, thePurchase, xOrder);
            SetQbRelationshipPurchaseLines(context, thePurchase, xOrder);


            Disconnect();

            //context.Comment(xOrder.ordernumber + " created successfully");
            return true;
        }

        public bool UpdateQBPurchaseOrder(ContextRz context, ordhed_new p)
        {
            if (p == null)
                return false;

            switch (p.OrderType)
            {
                case OrderType.Purchase:
                    p = (ordhed_purchase)p;
                    break;
                case OrderType.Service:
                    p = (ordhed_service)p;
                    break;
            }

            context.Comment("Updating " + p.ordertype + " Order# " + p.ordernumber);

            //Field Mappings based on Sensible Purchase Order QB Template
            //Field: "QB Property"
            //Sale No: "FOB"
            //P.O. Date= "Due Date"
            //Sales REP = "OTher1"

            //Get the PurchaseRet from a SaleRetList
            IPurchaseOrderRet qbPurchaseRet = GetQbPurchaseRet(context, p);
            string poNumber = qbPurchaseRet.RefNumber.GetValue();
            string poTxnID = qbPurchaseRet.TxnID.GetValue();
            //Setup the Modify object, a modify will return a single <object>Ref in the response
            //Setup the request to query the existing purchase order.
            IMsgSetRequest requestSetPurchaseMod = GetLatestMsgSetRequest(context, sessionManager);
            requestSetPurchaseMod.Attributes.OnError = ENRqOnError.roeStop;
            //Create the order query object to get the order we want to modify, add to the requestSet
            IPurchaseOrderMod PurchaseMod = requestSetPurchaseMod.AppendPurchaseOrderModRq();
            PurchaseMod.TxnID.SetValue(poTxnID);


            //Set The Sales Agent                
            SetQbSalesAgent(context, PurchaseMod, QuickbooksSyncType.Update, p);


            //Vendor Reference
            string vendName = TheVendor.Name.GetValue();
            string vendListID = TheVendor.ListID.GetValue();
            PurchaseMod.RefNumber.SetValue(p.ordernumber);
            PurchaseMod.VendorRef.ListID.SetValue(vendListID);
            string purchaseEditSequence = qbPurchaseRet.EditSequence.GetValue();
            PurchaseMod.EditSequence.SetValue(purchaseEditSequence);
            //Order Number (can change)
            PurchaseMod.RefNumber.SetValue(p.ordernumber);
            //Order Date = Due Date
            if (Tools.Dates.DateExists(p.orderdate))
            {
                PurchaseMod.TxnDate.SetValue(p.orderdate);
                PurchaseMod.DueDate.SetValue(p.orderdate);
            }
            //Terms
            if (Tools.Strings.StrExt(p.terms))
                PurchaseMod.TermsRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(p.terms), Convert.ToInt32(PurchaseMod.TermsRef.FullName.GetMaxLength())));
            //Ship Via
            if (Tools.Strings.StrExt(p.shipvia))
                PurchaseMod.ShipMethodRef.FullName.SetValue(Tools.Strings.Left(IdentifierFilter(p.shipvia), Convert.ToInt32(PurchaseMod.ShipMethodRef.FullName.GetMaxLength())));
            //Shipping Account = Other2
            if (Tools.Strings.StrExt(p.shippingaccount))
                PurchaseMod.Other2.SetValue(Tools.Strings.Left(IdentifierFilter(p.shippingaccount), Convert.ToInt32(PurchaseMod.Other2.GetMaxLength())));

            //Buyer Name (contactname) //Not Used with Purchase Order
            UpdateQbLineItemsPurchase(context, PurchaseMod, p);

            //End MAin Purchase Update  
            //Actually Send the Response              
            context.TheLeader.CommentEllipse("Sending Purchase Order Update Request To Quickbooks API");

            IResponse response = GetResponse(context, requestSetPurchaseMod);
            if (response == null)
                context.Error("Null response from Quickbooks.");
            //Get the response code
            int code = response.StatusCode;
            string message = response.StatusMessage;
            if (code != 0)
            {
                if (code == 3205)

                    AlertFixCompanyAddress(context, p, message);
                else
                    HandleQbStatusCode(context, response, p.ordernumber, p);
            }

            IPurchaseOrderRet thePurchase = (IPurchaseOrderRet)response.Detail;
            //End the session and close the connection to QuickBooks                
            if (thePurchase == null)
            {
                string msg = "Could not obtain valid IPurchaseOrderRet response from Quickbooks";
                context.TheLeader.CommentEllipse("Error: " + msg);
                throw new Exception(msg);
            }

            SetQbRelationshipPurchaseLines(context, thePurchase, p);
            return true;

        }

        private bool CreateQbLineItemsPurchase(ContextRz context, ordhed_new xOrder, IPurchaseOrderAdd purchAdd)
        {
            //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //Add the details  

            context.Comment("Creating Line Items for " + xOrder.ordertype + " Order# " + xOrder.ordernumber);
            List<orddet_line> lines = new List<orddet_line>();
            switch (xOrder.OrderType)
            {
                case OrderType.Service:
                    {
                        ordhed_service s = (ordhed_service)xOrder;
                        lines = ConvertServiceLinesToOrddetLines(context, xOrder);
                        break;
                    }
                default:
                    {
                        lines = xOrder.DetailsVar.RefsList(context);
                        break;
                    }

            }

            foreach (orddet_line d in lines)
            {

                if (ShouldSendItemToQb(context, d))
                {
                    context.Comment("Updating Line Item " + d.fullpartnumber);
                    String strPartNumber = GetQBPartNumber(context, d, OrderType.Purchase);
                    //if (ShouldSendItemToQb(context, d))
                    if (Tools.Strings.StrExt(strPartNumber))
                    {
                        IORPurchaseOrderLineAdd xItem = purchAdd.ORPurchaseOrderLineAddList.Append();
                        //Set field value for ListID
                        xItem.PurchaseOrderLineAdd.ItemRef.ListID.SetValue(d.qb_line_ListID);
                        //Total Price (price & QTY)
                        //Double dblAmount = Math.Round(d.unit_cost * d.quantity, 2);
                        //Part Number
                        xItem.PurchaseOrderLineAdd.ItemRef.FullName.SetValue(Tools.Strings.Left(strPartNumber, 30).Trim());
                        //Quantity
                        xItem.PurchaseOrderLineAdd.Quantity.SetValue(d.quantity);
                        //Unit Price   = Rate
                        double unit_cost = Math.Round(d.unit_cost, 5);
                        xItem.PurchaseOrderLineAdd.Rate.SetValue(unit_cost);
                        //Line Description
                        //Description
                        if (!d.fullpartnumber.ToLower().Contains("gcat"))//If this isn't a GCAT line include description
                        {
                            string descriptionString = GetDescriptionString(d.manufacturer, strPartNumber);
                            xItem.PurchaseOrderLineAdd.Desc.SetValue(descriptionString);
                        }


                        //Customer Description = IPN             
                        string custdescriptionString = GetCustomerInternalDescriptionString(d);

                        if (!string.IsNullOrEmpty(custdescriptionString))
                            xItem.PurchaseOrderLineAdd.Other1.SetValue(custdescriptionString);

                        //if (SetClassToInitials(context) && Tools.Strings.StrExt(strInitials))
                        xItem.PurchaseOrderLineAdd.Other2.SetValue(d.linecode_purchase.ToString());
                        context.Comment("Update for " + d.fullpartnumber + " is successful.");
                    }
                }
            }

            return true;

        }

        private bool UpdateQbLineItemsPurchase(ContextRz context, IPurchaseOrderMod PurchMod, ordhed_new xOrder)
        {
            ordhed_purchase ThePurchaseOrder = null;
            ordhed_service TheServiceOrder = null;
            if (xOrder.OrderType == OrderType.Service)
                TheServiceOrder = (ordhed_service)xOrder;
            else if (xOrder.OrderType == OrderType.Purchase)
                ThePurchaseOrder = (ordhed_purchase)xOrder;

            context.Comment("Updating Line Items for " + xOrder.ordertype + " Order# " + xOrder.ordernumber);
            string txnID = null;

            List<orddet_line> lines = new List<orddet_line>();
            switch (xOrder.OrderType)
            {
                case OrderType.Service:
                    {
                        lines = ConvertServiceLinesToOrddetLines(context, TheServiceOrder);
                        break;
                    }
                default:
                    {
                        lines = ThePurchaseOrder.DetailsVar.RefsList(context);
                        break;
                    }

            }

            context.TheLeader.CommentEllipse("Sending line items");
            foreach (orddet_line d in lines)
            {
                //https://stackoverflow.com/questions/27671952/how-to-add-an-invoice-line-item-to-an-existing-quickbooks-invoice-using-qbfc-and
                if (Tools.Strings.StrExt(d.fullpartnumber))
                {
                    context.Comment("Updating Line Item " + d.fullpartnumber);
                    //Line Modification Object
                    IORPurchaseOrderLineMod lineMod = PurchMod.ORPurchaseOrderLineModList.Append();

                    //Set field value for TxnLineID                        
                    txnID = txnID = GetTransactionIdFromLineItem(d, xOrder);

                    if (ThePurchaseOrder != null)
                        CheckQbPartNumberMismatch(context, d, ThePurchaseOrder);
                    else if (TheServiceOrder != null)
                        CheckQbPartNumberMismatch(context, d, TheServiceOrder);


                    if (txnID == "-1")//New Line need set linecode for linkage
                        lineMod.PurchaseOrderLineMod.Other2.SetValue(d.linecode_purchase.ToString());

                    //TransactionID
                    lineMod.PurchaseOrderLineMod.TxnLineID.SetValue(txnID);

                    //Set field value for ListID
                    string ListID = d.qb_line_ListID;
                    if (string.IsNullOrEmpty(ListID))
                        CreateOrLinkQbPart(context, xOrder, d, OrderType.Purchase);


                    //ListID
                    if (string.IsNullOrEmpty(d.qb_line_ListID))
                        throw new Exception("Unable to create and link Qb part.  Missing ListID");
                    lineMod.PurchaseOrderLineMod.ItemRef.ListID.SetValue(d.qb_line_ListID);

                    //Set field value for FullName
                    lineMod.PurchaseOrderLineMod.ItemRef.FullName.SetValue(d.fullpartnumber);

                    //Set field value for Quantity
                    lineMod.PurchaseOrderLineMod.Quantity.SetValue(d.quantity);

                    //Unit Price  = Rate
                    double unit_cost = Math.Round(d.unit_cost, 5);//max 5 decimals
                    lineMod.PurchaseOrderLineMod.Rate.SetValue(unit_cost);


                    //Description
                    if (!d.fullpartnumber.ToLower().Contains("gcat"))//If this isn't a GCAT line include description
                    {
                        string descriptionString = GetDescriptionString(d.manufacturer, d.fullpartnumber);
                        lineMod.PurchaseOrderLineMod.Desc.SetValue(descriptionString);
                    }


                    context.Comment("Update for " + d.fullpartnumber + " is successful.");
                }
            }
            return true;

        }

        private bool AlertFixCompanyAddress(ContextRz context, ordhed_new p, string message)
        {
            company c = p.CompanyVar.RefGet(context);
            string strCompanyName = c.companyname;
            context.Leader.Error("Note, QB can't handle this company's address.  You can correct this on the Quickbooks Company edit screen that follows." + Environment.NewLine + Environment.NewLine + message);
            //ShowCompanyToQbForm(xrz, Enums.CompanySelectionType.Customer, this, GetPrimaryShippingAddressString(xrz), GetPrimaryBillingAddressString(xrz));
            bool addressFixed = context.TheLeaderRz.ShowAddQBCompany(c, ref strCompanyName, Enums.CompanySelectionType.Customer, c.GetPrimaryShippingAddressString(context), c.GetPrimaryBillingAddressString(context));
            if (addressFixed)
                context.Leader.Tell("Fixed address, please try syncing again.");

            return addressFixed;
        }



        //including a second parameter to allow users to set which value they want to use, since different by line typ (sale / purchase)
        private double GetQBLineQuantity(orddet_line d, int quantity)
        {
            List<string> disallowedStatus = new List<string>();
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Packing.ToString());
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Shipped.ToString());
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Shipped.ToString());
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Shipped.ToString());

            if (disallowedStatus.Contains(d.status))
                return 0;
            return quantity;
        }
        //including a second parameter to allow users to set which value they want to use, since different by line typ (sale / purchase)
        private double GetQBLineAmount(orddet_line d, double amount)
        {
            List<string> disallowedStatus = new List<string>();
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Packing.ToString());
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Shipped.ToString());
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Shipped.ToString());
            disallowedStatus.Add(OrderLineStatus.Vendor_RMA_Shipped.ToString());

            if (disallowedStatus.Contains(d.status))
                return 0;
            return amount;
        }


        private string GetServiceLineMpnString(service_line d, ordhed_service s)
        {
            string vendoruid = s.base_company_uid;
            string vendorName = s.companyname;
            switch (vendoruid)
            {
                case "7a28f08ba2a1467d87bc5a2311f9d0b2"://White Horse              
                case "c75d3d332e0849ab8794fba5a8a921f6"://Emporium Partners
                    return "Vendor Lab Services";
                default:
                    return d.service_name;

            }
        }

        private bool ShouldSendItemToQb(ContextRz context, orddet_line d)
        {

            if (string.IsNullOrEmpty(d.fullpartnumber))
                return false;
            return true;

        }

        private bool ShouldSendLineToQB(orddet_line d)
        {
            if (!invalidQbStatus.Contains(d.Status))
                return true;
            return false;
        }

        private bool ShouldRemoveLineFromQB(orddet_line d)
        {
            if (invalidQbStatus.Contains(d.Status))
                return true;
            return false;
        }



        private string GetDescriptionString(string subItem, string nonInvItem)
        {
            //This mimics the QB 
            //string MPN = "";
            //string MFG = "";
            //MFG = d.manufacturer.Trim().ToUpper();
            //MPN = d.fullpartnumber.Trim().ToUpper() ?? "";
            //return MFG + ":" + MPN;
            return subItem + "," + nonInvItem;

        }

        private string GetCustomerInternalDescriptionString(orddet_line d)
        {
            //this only goes on sales lines.           
            string IPN = "";
            if (!string.IsNullOrEmpty(d.internal_customer))
                IPN = d.internal_customer;
            else
                IPN = d.fullpartnumber;
            //Confirmed on 8-19-18, just IPN, 
            return IPN;
        }


        private string GetShortenedManufacturerString(string mFG)
        {
            string ret = mFG.ToLower();
            switch (ret)
            {
                case "texas instruments":
                    {
                        ret = "TI";
                        break;
                    }

            }
            return ret.ToUpper();
        }

        private void SetQbRelationshipOrder(ContextRz context, object qbObj, object rzOrder)
        {
            string rzOrderType = rzOrder.GetType().ToString().ToLower();
            switch (rzOrderType)
            {
                case "rz5.ordhed_sales":
                    {
                        context.Leader.Comment("Setting Sales Order Relationship");
                        SetQbRelationshipSalesOrder(context, (ISalesOrderRet)qbObj, (ordhed_sales)rzOrder);
                        break;
                    }

                case "rz5.ordhed_purchase":
                    {
                        context.Leader.Comment("Setting Purchase Order Relationship");
                        SetQbRelationshipPurchaseOrder(context, (IPurchaseOrderRet)qbObj, (ordhed_purchase)rzOrder);
                        break;
                    }

                case "rz5.ordhed_service":
                    {
                        context.Leader.Comment("Setting Service Order Relationship");
                        SetQbRelationshipPurchaseOrder(context, (IPurchaseOrderRet)qbObj, (ordhed_service)rzOrder);
                        break;
                    }


            }
            context.Comment("Relationship set successfully");
        }
        private void SetQbRelationshipSalesOrder(ContextRz context, ISalesOrderRet qbSale, ordhed_sales xOrder)
        {
            if (qbSale == null)
                throw new Exception("Could not find the Quickbooks Sale");
            string txnID = qbSale.TxnID.GetValue();
            if (string.IsNullOrEmpty(txnID))
                throw new Exception("Could not identify the Quickbooks Sale TxnID");
            xOrder.qb_order_TxnID = txnID;
            xOrder.Update(context);
            context.Comment("Relationship set successfully");
        }
        private void SetQbRelationshipPurchaseOrder(ContextRz context, IPurchaseOrderRet qbPurchase, ordhed_new rzPurchase)
        {

            if (qbPurchase == null)
                throw new Exception("Could not find the Quickbooks Sale");
            string txnID = qbPurchase.TxnID.GetValue();
            if (string.IsNullOrEmpty(txnID))
                throw new Exception("Could not identify the Quickbooks Sale TxnID");
            rzPurchase.qb_order_TxnID = txnID;
            rzPurchase.Update(context);
            context.Comment("Relationship set successfully");
        }

        private void SetQbRelationshipSalesLines(ContextRz context, ISalesOrderRet theSale, ordhed_sales o)
        {
            //don't want to update relational linkage during updates, no matter how unlikely it is to fail.
            foreach (orddet_line d in o.DetailsList(context))
            {

                context.Comment("Updating Rz Line relationship " + d.fullpartnumber);
                string rzLineCode = d.linecode_sales.ToString();
                string rzLineTxnID = d.qb_line_TxnID.ToString();
                if (string.IsNullOrEmpty(rzLineTxnID))//Only updating relationships for lines that don't have one.
                {
                    IORSalesOrderLineRetList qbSaleLineList = theSale.ORSalesOrderLineRetList;
                    for (Int32 i = 0; i <= qbSaleLineList.Count - 1; i++)
                    {
                        IORSalesOrderLineRet qbLine = qbSaleLineList.GetAt(i);
                        string qbLineCode = qbLine.SalesOrderLineRet.Other2.GetValue() ?? "";
                        if (rzLineCode == qbLineCode)
                        {
                            string txnID = qbLine.SalesOrderLineRet.TxnLineID.GetValue();
                            d.qb_line_TxnID = txnID;
                            d.Update(context);
                        }
                    }
                }
                context.Comment("Rz Line relationship updated for " + d.fullpartnumber);

            }


        }

        private void SetQbRelationshipPurchaseLines(ContextRz context, IPurchaseOrderRet thePO, ordhed_new o)
        {

            //don't want to update relational linkage during updates, no matter how unlikely it is to fail.
            List<orddet_line> lines = new List<orddet_line>();
            switch (o.OrderType)
            {
                case OrderType.Service:
                    lines = ConvertServiceLinesToOrddetLines(context, o);
                    break;
                default:
                    lines = o.DetailsVar.RefsList(context);
                    break;
            }

            foreach (orddet_line d in lines)
            {
                context.Comment("Updating Line relationship " + d.fullpartnumber);
                string rzLineCode = d.linecode_purchase.ToString();
                string rzLineTxnID = d.qb_line_TxnID_purchase.ToString();
                if (string.IsNullOrEmpty(rzLineTxnID))//Only updating relationships for lines that don't have one.
                {
                    IORPurchaseOrderLineRetList qbPOLineList = thePO.ORPurchaseOrderLineRetList;
                    for (Int32 i = 0; i <= qbPOLineList.Count - 1; i++)
                    {
                        IORPurchaseOrderLineRet qbLine = qbPOLineList.GetAt(i);
                        string qbLineCode = qbLine.PurchaseOrderLineRet.Other2.GetValue() ?? "";
                        if (rzLineCode == qbLineCode)
                        {
                            string txnID = qbLine.PurchaseOrderLineRet.TxnLineID.GetValue();
                            switch (o.OrderType)
                            {
                                case OrderType.Service:
                                    {
                                        //Get the service line, and update it with the QB Relationship.
                                        service_line sl = service_line.GetById(context, d.unique_id);//the d.unique_id is mapped to service_line.unique_id int his case
                                        if (sl != null)
                                        {
                                            sl.qb_line_TxnID = txnID;
                                            sl.Update(context);
                                        }
                                    }
                                    break;
                                default:
                                    {
                                        d.qb_line_TxnID_purchase = txnID;
                                        d.Update(context);
                                    }

                                    break;
                            }


                        }
                    }
                }
                context.Comment("Line relationship updated for " + d.fullpartnumber);

            }

        }

        private void SetQbRelationshipNonStockItem(ContextRz x, IItemNonInventoryRet qbItem, orddet_line l)
        {

            string qb_listID = qbItem.ListID.GetValue();
            string fullpartnumber = qbItem.FullName.GetValue();
            if (string.IsNullOrEmpty(qb_listID))
                throw new Exception("Could not identify the NonStockInventory listID");
            l.qb_line_ListID = qb_listID;
            l.Update(x);
        }



        private bool SetQbRelationshipCustomer(ContextRz x, ICustomerRet qbCust, company c)
        {

            string qbCompanyName = qbCust.FullName.GetValue();
            string listID = qbCust.ListID.GetValue();
            if (string.IsNullOrEmpty(listID))
                throw new Exception("Could not identify the Quickbooks Company listID");
            c.qb_company_ListID = listID;
            //c.qb_company_type = "customer";
            c.Update(x);
            return true;
        }
        private bool SetQbRelationshipVendor(ContextRz x, IVendorRet qbVend, company c)
        {

            string qbCompanyName = qbVend.CompanyName.GetValue();
            string listID = qbVend.ListID.GetValue();
            if (string.IsNullOrEmpty(listID))
                throw new Exception("Could not identify the Quickbooks Vendor listID");
            c.qb_company_ListID_vendor = listID;
            //c.qb_company_type = "vendor";
            c.Update(x);
            return true;
        }
        private void RemoveQbRelationshipCompany(ContextRz context, company c)
        {
            c.qb_company_ListID = null;
            c.qb_company_type = null;
            c.Update(context);
        }
        private ISalesOrderRet GetQuickbooksSale(ContextRz context, ordhed_sales o)
        {
            //Setup the request
            IMsgSetRequest requestSet1 = GetLatestMsgSetRequest(context, sessionManager);
            requestSet1.Attributes.OnError = ENRqOnError.roeStop;
            //Create the order query object to get the order we want to modify, add to the requestSet
            ISalesOrderQuery q = requestSet1.AppendSalesOrderQueryRq();
            q.IncludeLineItems.SetValue(true); //If False, you will get NO LINE ITEMS!!                                                  
                                               //Provide a ordernumber to get the desired order
                                               //string txnId = "21E8C-1671111795";
                                               //q.ORTxnNoAccountQuery.TxnIDList.Add(txnId);
            q.ORTxnNoAccountQuery.TxnIDList.Add(o.qb_order_TxnID);

            //Connect to QB
            if (!Connect(context))
                return null;
            //Get the response, which should contain the desired object, we'll get that object out of this response later
            IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet1);
            //GetAt(0) == Get the 1st item in the response
            IResponse response1 = responseSet1.ResponseList.GetAt(0);
            //If null, disconnect
            if (response1.Detail == null)
            {
                Disconnect();
                return null;
            }
            //Instantiate a List of object(s) that was returned in the response
            ISalesOrderRetList salesRet = (ISalesOrderRetList)response1.Detail;
            if (salesRet == null)
            {
                Disconnect();
                return null;
            }
            //Get the sales object fromt the Ret list
            return salesRet.GetAt(0);
        }



        //The following sample code is generated as an illustration of
        //Creating requests and parsing responses ONLY
        //This code is NOT intended to show best practices or ideal code
        //Use at your most careful discretion


        //Create a Sales Rep
        public void DoSalesRepAdd(ContextRz context, n_user u)
        {
            try
            {
                //Create the session Manager object
                IMsgSetRequest requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;


                BuildSalesRepAddRq(requestMsgSet, u);

                //Connect to QuickBooks and begin a session
                //sessionManager.OpenConnection("", "Sample Code from OSR");
                //connectionOpen = true;
                //sessionManager.BeginSession("", ENOpenMode.omDontCare);
                //sessionBegun = true;

                //Send the request and get the response from QuickBooks
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                ////End the session and close the connection to QuickBooks
                //sessionManager.EndSession();
                //sessionBegun = false;
                //sessionManager.CloseConnection();
                //connectionOpen = false;

                WalkSalesRepAddRs(responseMsgSet);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                Disconnect();
            }
        }

        //Build Sales Rep Add Request
        void BuildSalesRepAddRq(IMsgSetRequest requestMsgSet, n_user u)
        {
            ISalesRepAdd SalesRepAddRq = requestMsgSet.AppendSalesRepAddRq();
            //Set field value for Initial
            SalesRepAddRq.Initial.SetValue(u.Initials);
            //Set field value for IsActive
            SalesRepAddRq.IsActive.SetValue(true);
            //Set field value for ListID
            SalesRepAddRq.SalesRepEntityRef.ListID.SetValue("0");
            //Set field value for FullName
            SalesRepAddRq.SalesRepEntityRef.FullName.SetValue(u.Initials);
            //Set field value for IncludeRetElementList
            //May create more than one of these if needed
            //You use this if you want to limit the data that will be returned in the response. In this list, you specify the name of each top-level element or aggregate that you want to be returned in the response to the request.
            //SalesRepAddRq.IncludeRetElementList.Add("ab");
        }



        //Get the Sales Rep Add Response
        void WalkSalesRepAddRs(IMsgSetResponse responseMsgSet)
        {
            if (responseMsgSet == null) return;
            IResponseList responseList = responseMsgSet.ResponseList;
            if (responseList == null) return;
            //if we sent only one request, there is only one response, we'll walk the list for this sample
            for (int i = 0; i < responseList.Count; i++)
            {
                IResponse response = responseList.GetAt(i);
                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode >= 0)
                {
                    //the request-specific response is in the details, make sure we have some
                    if (response.Detail != null)
                    {
                        //make sure the response is the type we're expecting
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtSalesRepAddRs)
                        {
                            //upcast to more specific type here, this is safe because we checked with response.Type check above
                            ISalesRepRet SalesRepRet = (ISalesRepRet)response.Detail;
                            WalkSalesRepRet(SalesRepRet);
                        }
                    }
                }
            }
        }



        //Query Sales Reps
        protected void WalkSalesRepRet(ISalesRepRet SalesRepRet)
        {
            if (SalesRepRet == null) return;
            //Go through all the elements of ISalesRepRet
            //Get value of ListID
            string ListID21489 = (string)SalesRepRet.ListID.GetValue();
            //Get value of TimeCreated
            DateTime TimeCreated21490 = (DateTime)SalesRepRet.TimeCreated.GetValue();
            //Get value of TimeModified
            DateTime TimeModified21491 = (DateTime)SalesRepRet.TimeModified.GetValue();
            //Get value of EditSequence
            string EditSequence21492 = (string)SalesRepRet.EditSequence.GetValue();
            //Get value of Initial
            string Initial21493 = (string)SalesRepRet.Initial.GetValue();
            //Get value of IsActive
            if (SalesRepRet.IsActive != null)
            {
                bool IsActive21494 = (bool)SalesRepRet.IsActive.GetValue();
            }
            //Get value of ListID
            if (SalesRepRet.SalesRepEntityRef.ListID != null)
            {
                string ListID21495 = (string)SalesRepRet.SalesRepEntityRef.ListID.GetValue();
            }
            //Get value of FullName
            if (SalesRepRet.SalesRepEntityRef.FullName != null)
            {
                string FullName21496 = (string)SalesRepRet.SalesRepEntityRef.FullName.GetValue();
            }
        }



        public ISalesRepRetList DoSalesRepQuery(ContextRz context, string s)
        {

            try
            {
                //Create the session Manager object
                //Create the session Manager object
                IMsgSetRequest requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;

                BuildSalesRepQueryRq(requestMsgSet, QuickbooksQueryType.ListFilter, s);

                //Connect to QuickBooks and begin a session
                Connect(context);

                //Send the request and get the response from QuickBooks
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                //End the session and close the connection to QuickBooks
                Disconnect();

                return WalkSalesRepQueryRs(responseMsgSet);
            }
            catch (Exception ex)
            {
                context.Leader.Error(ex.Message);
                Disconnect();
                return null;
            }
        }


        public ISalesRepRetList DoSalesRepQuery(ContextRz context, n_user u)
        {

            try
            {
                //Create the session Manager object
                IMsgSetRequest requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;

                BuildSalesRepQueryRq(requestMsgSet, QuickbooksQueryType.FullNameList, u.Initials);

                //Connect to QuickBooks and begin a session
                Connect(context);

                //Send the request and get the response from QuickBooks
                IMsgSetResponse responseMsgSet = sessionManager.DoRequests(requestMsgSet);

                //End the session and close the connection to QuickBooks
                Disconnect();

                return WalkSalesRepQueryRs(responseMsgSet);
            }
            catch (Exception ex)
            {
                context.Leader.Error(ex.Message);
                Disconnect();
                return null;
            }
        }
        void BuildSalesRepQueryRq(IMsgSetRequest requestMsgSet, QuickbooksQueryType queryType, string strQuery)
        {
            ISalesRepQuery SalesRepQueryRq = requestMsgSet.AppendSalesRepQueryRq();
            //Set attributes
            //Set field value for metaData
            SalesRepQueryRq.metaData.SetValue(ENmetaData.mdMetaDataAndResponseData);

            //Search by ListID           
            if (queryType == QuickbooksQueryType.ListIDList)
            {
                //Set field value for ListIDList
                //May create more than one of these if needed
                SalesRepQueryRq.ORListQuery.ListIDList.Add(strQuery);//sample ID
            }
            //if (ORListQueryElementType21521 == "FullNameList")
            if (queryType == QuickbooksQueryType.FullNameList)
            {
                //Set field value for FullNameList
                //May create more than one of these if needed
                SalesRepQueryRq.ORListQuery.FullNameList.Add(strQuery);
            }
            //if (ORListQueryElementType21521 == "ListFilter")
            if (queryType == QuickbooksQueryType.ListFilter)
            {
                //Set field value for MaxReturned
                SalesRepQueryRq.ORListQuery.ListFilter.MaxReturned.SetValue(20);
                //Set field value for ActiveStatus
                SalesRepQueryRq.ORListQuery.ListFilter.ActiveStatus.SetValue(ENActiveStatus.asActiveOnly);//Default
                                                                                                          //Set field value for FromModifiedDate
                SalesRepQueryRq.ORListQuery.ListFilter.FromModifiedDate.SetValue(DateTime.Parse("5/4/2005 12:15:12"), false);
                //Set field value for ToModifiedDate
                SalesRepQueryRq.ORListQuery.ListFilter.ToModifiedDate.SetValue(DateTime.Now, false);
                string ORNameFilterElementType21522 = "NameFilter";
                if (ORNameFilterElementType21522 == "NameFilter")
                {
                    //Set field value for MatchCriterion
                    SalesRepQueryRq.ORListQuery.ListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                    //Set field value for Name
                    SalesRepQueryRq.ORListQuery.ListFilter.ORNameFilter.NameFilter.Name.SetValue(strQuery);
                }
                if (ORNameFilterElementType21522 == "NameRangeFilter")
                {
                    //Set field value for FromName
                    SalesRepQueryRq.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.FromName.SetValue("fromName");
                    //Set field value for ToName
                    SalesRepQueryRq.ORListQuery.ListFilter.ORNameFilter.NameRangeFilter.ToName.SetValue("toName");
                }
            }
            //Set field value for IncludeRetElementList
            //May create more than one of these if needed
            //SalesRepQueryRq.IncludeRetElementList.Add("ab");//add another name to query
        }


        private ISalesRepRetList WalkSalesRepQueryRs(IMsgSetResponse responseMsgSet)
        {
            if (responseMsgSet == null) return null;
            IResponseList responseList = responseMsgSet.ResponseList;
            if (responseList == null) return null;
            //if we sent only one request, there is only one response, we'll walk the list for this sample
            for (int i = 0; i < responseList.Count; i++)
            {
                IResponse response = responseList.GetAt(i);
                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode >= 0)
                {
                    //the request-specific response is in the details, make sure we have some
                    if (response.Detail != null)
                    {
                        //make sure the response is the type we're expecting
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtSalesRepQueryRs)
                        {
                            //upcast to more specific type here, this is safe because we checked with response.Type check above
                            ISalesRepRetList SalesRepRetList = (ISalesRepRetList)response.Detail;

                            return SalesRepRetList;
                        }
                    }
                }
            }
            return null;
        }


        //protected virtual bool UseQbPurchaseOrders(ContextRz context, ordhed_new xOrder)
        //{
        //    return Tools.Strings.HasString(POOption(context), "PurchaseOrder") || context.GetSettingBoolean("use_qb_purchase_orders");
        //}
        //protected virtual bool InventoryOnlyMode(ContextRz context, ordhed_new xOrder)
        //{
        //    return GeneralOption(context).Contains("InventoryOnly");
        //}
        protected virtual bool MeetsQBCriteria(ContextRz context, ordhed_new xOrder)
        {
            if (!xOrder.HasAtLeastOnePartNumber(context) && Tools.Data.NullFilterDouble(xOrder.IGet("credit_amount")) == 0)
            {
                context.Comment(xOrder.ToString() + " does not appear to have any line items or credits to transfer.");
                return false;
            }

            return true;
        }
        protected virtual bool CheckMessage(ContextRz context, ordhed_new xOrder)
        {
            if ((xOrder.OrderType == OrderType.Invoice || xOrder.OrderType == OrderType.Sales) && Tools.Strings.StrExt(xOrder.printcomment) && (xOrder.printcomment.Length <= 50))
                MakeCustRefMsgExist(context, xOrder.printcomment);
            return true;
        }
        protected String IdentifierFilter(String valueIn)
        {
            return valueIn.Replace(":", " ");
        }
        public String QBPartFilter(ContextRz context, String strPart)
        {
            switch (strPart.ToLower())
            {
                case "bank fee":
                case "freight":
                    return strPart;
            }

            if (Tools.Strings.StrCmp(strPart, context.TheSysRz.TheQuickBooksLogic.IncomingShipping(context)) || Tools.Strings.StrCmp(strPart, context.TheSysRz.TheQuickBooksLogic.OutgoingShipping(context)) || Tools.Strings.StrCmp(strPart, context.TheSysRz.TheQuickBooksLogic.HandlingItem(context)))
                return Tools.Strings.Left(strPart, 30);
            if (Tools.Strings.StrExt(context.TheSysRz.TheQuickBooksLogic.ItemSuffix(context)) && !strPart.ToLower().Trim().EndsWith(context.TheSysRz.TheQuickBooksLogic.ItemSuffix(context).ToLower().Trim()))
                strPart += " " + context.TheSysRz.TheQuickBooksLogic.ItemSuffix(context).Trim();
            return IdentifierFilter(Tools.Strings.Left(strPart, 30));   //changed from 40  2011_03_09
        }
        public short m_qbXMLMajorVer = 0;
        public short qbXMLMajorVer(ContextRz context)
        {
            if (m_qbXMLMajorVer > 0)
                return m_qbXMLMajorVer;
            m_qbXMLMajorVer = Convert.ToInt16(context.GetSettingInt64("qb_major_version"));
            return m_qbXMLMajorVer;
        }
        public void qbXMLMajorVerSet(ContextRz context, short value)
        {
            m_qbXMLMajorVer = value;
            context.SetSettingInt64("qb_major_version", m_qbXMLMajorVer);
        }
        public short m_qbXMLMinorVer = 0;
        public short qbXMLMinorVer(ContextRz context)
        {
            if (m_qbXMLMinorVer > 0)
                return m_qbXMLMinorVer;
            m_qbXMLMinorVer = Convert.ToInt16(context.GetSettingInt64("qb_minor_version"));
            return m_qbXMLMinorVer;
        }
        public void qbXMLMinorVerSet(ContextRz context, short value)
        {
            m_qbXMLMinorVer = value;
            context.SetSettingInt64("qb_minor_version", m_qbXMLMinorVer);
        }
        public String VersionName(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_version_name))
                return m_version_name;
            String strAccount = context.GetSetting("qb_version_name");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "US";
            m_version_name = strAccount;
            return m_version_name;
        }
        public void VersionNameSet(ContextRz context, String value)
        {
            m_version_name = value;
            context.SetSetting("qb_version_name", m_version_name);
        }
        public virtual String IncomeAccount(ContextRz context, orddet_line l)
        {
            if (Tools.Strings.StrExt(m_income_account))
                return m_income_account;
            String strAccount = n_set.GetSetting(context, "qb_income_account");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "RzIncome";
            m_income_account = strAccount;
            return m_income_account;
        }
        public void IncomeAccountSet(ContextRz context, String value)
        {
            m_income_account = value;
            n_set.SetSetting(context, "qb_income_account", m_income_account);
        }
        public virtual String ExpenseAccount(ContextRz context, orddet_line l)
        {
            if (Tools.Strings.StrExt(m_expense_account))
                return m_expense_account;
            String strAccount = context.GetSetting("qb_expense_account");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "RzExpense";
            m_expense_account = strAccount;
            return m_expense_account;
        }
        public virtual void ExpenseAccountSet(ContextRz context, String value)
        {
            m_expense_account = value;
            n_set.SetSetting(context, "qb_expense_account", m_expense_account);
        }
        public String AssetAccount(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_asset_account))
                return m_asset_account;
            String strAccount = n_set.GetSetting(context, "qb_asset_account");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "RzAsset";
            m_asset_account = strAccount;
            return m_asset_account;
        }
        public void AssetAccountSet(ContextRz context, String value)
        {
            m_asset_account = value;
            context.SetSetting("qb_asset_account", m_asset_account);
        }
        public virtual String COGSAccount(ContextRz context, orddet_line l)
        {
            if (Tools.Strings.StrExt(m_cogs_account))
                return m_cogs_account;
            String strAccount = context.GetSetting("qb_cogs_account");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "RzCOGS";
            m_cogs_account = strAccount;
            return m_cogs_account;
        }
        public void COGSAccountSet(ContextRz context, String value)
        {
            m_cogs_account = value;
            context.SetSetting("qb_cogs_account", m_cogs_account);
        }
        public String DepositAccount(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_deposit_account))
                return m_deposit_account;
            String strAccount = context.GetSetting("qb_deposit_account");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "RzDeposit";
            m_deposit_account = strAccount;
            return m_deposit_account;
        }
        public void DepositAccountSet(ContextRz context, String value)
        {
            m_deposit_account = value;
            context.SetSetting("qb_deposit_account", m_deposit_account);
        }
        public String IncomeAccountNumber(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_income_account_number))
                return m_income_account_number;
            String strAccount = context.GetSetting("qb_income_account_number");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "INC001";
            m_income_account_number = strAccount;
            return m_income_account_number;
        }
        public void IncomeAccountNumberSet(ContextRz context, String value)
        {
            m_income_account_number = value;
            context.SetSetting("qb_income_account_number", m_income_account_number);
        }
        public String ExpenseAccountNumber(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_expense_account_number))
                return m_expense_account_number;
            String strAccount = context.GetSetting("qb_expense_account_number");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "EXP001";
            m_expense_account_number = strAccount;
            return m_expense_account_number;
        }
        public void ExpenseAccountNumberSet(ContextRz context, String value)
        {
            m_expense_account_number = value;
            context.SetSetting("qb_expense_account_number", m_expense_account_number);
        }
        public String AssetAccountNumber(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_asset_account_number))
                return m_asset_account_number;
            String strAccount = context.GetSetting("qb_asset_account_number");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "AST001";
            m_asset_account_number = strAccount;
            return m_asset_account_number;
        }
        public void AssetAccountNumberSet(ContextRz context, String value)
        {
            m_asset_account_number = value;
            context.SetSetting("qb_asset_account_number", m_asset_account_number);
        }
        public String COGSAccountNumber(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_cogs_account_number))
                return m_cogs_account_number;
            String strAccount = n_set.GetSetting(context, "qb_cogs_account_number");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "COG001";
            m_cogs_account_number = strAccount;
            return m_cogs_account_number;
        }
        public void COGSAccountNumberSet(ContextRz context, String value)
        {
            m_cogs_account_number = value;
            context.SetSetting("qb_cogs_account_number", m_cogs_account_number);
        }
        public String DepositAccountNumber(ContextRz context)
        {
            if (Tools.Strings.StrExt(m_deposit_account_number))
                return m_deposit_account_number;
            String strAccount = context.GetSetting("qb_deposit_account_number");
            if (!Tools.Strings.StrExt(strAccount))
                strAccount = "DEP001";
            m_deposit_account_number = strAccount;
            return m_deposit_account_number;
        }
        public void DepositAccountNumberSet(ContextRz context, String value)
        {
            m_deposit_account_number = value;
            context.SetSetting("qb_deposit_account_number", m_cogs_account_number);
        }
        public bool SetClassToInitials(ContextRz context)
        {
            return Tools.Strings.HasString(GeneralOption(context), "SetClassToInitials");
        }
        public bool InvPartExists(ContextRz context, String strPartNumber, bool identifier_filter = true)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IItemInventoryQuery StockQuery = requestSet.AppendItemInventoryQueryRq();
                string part = Tools.Strings.Left(strPartNumber, 30).Trim();
                if (identifier_filter)
                    part = IdentifierFilter(Tools.Strings.Left(strPartNumber, 30)).Trim();
                //StockQuery.ORListQuery.FullNameList.Add(part);
                StockQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(part);
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                    return false;
                if (responseSet.ResponseList.Count <= 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return false;
            }
        }
        public bool NonInvPartExists(ContextRz context, String strPartNumber)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IItemNonInventoryQuery NonStockQuery = requestSet.AppendItemNonInventoryQueryRq();
                NonStockQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(IdentifierFilter(Tools.Strings.Left(strPartNumber, 30)).Trim());
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                    return false;
                if (responseSet.ResponseList.Count <= 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return false;
            }
        }
        public bool NonInvPartExists(ContextRz context, orddet_line l)
        {
            try
            {
                //Sometimes we will have a list ID, sometimes not.
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemNonInventoryQuery NonStockQuery = requestSet.AppendItemNonInventoryQueryRq();
                string partNumber = l.fullpartnumber;
                if (string.IsNullOrEmpty(l.qb_line_ListID))
                {
                    NonStockQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(partNumber.Trim());
                }
                else
                {
                    NonStockQuery.ORListQueryWithOwnerIDAndClass.ListIDList.Add(l.qb_line_ListID.Trim());
                }
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                {
                    throw new Exception(response.StatusMessage);
                }

                if (responseSet.ResponseList.Count <= 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return false;
            }
        }

        private bool CheckIsSubItem(string itemName)
        {
            bool ret = false;
            //If the PartNumber contains No ":" then it's a subitem            
            if (!itemName.Contains(":"))
                ret = true;
            return ret;

        }


        private string GetSubItemFromString(string strPartNumber)
        {
            if (CheckIsSubItem(strPartNumber))
                return strPartNumber;
            else
                return ExtractSubItemFromQbPartNumber(strPartNumber);
        }

        private string ExtractSubItemFromQbPartNumber(string strPartNumber)
        {
            if (!strPartNumber.Contains(":"))
                return null;
            string[] splitString = strPartNumber.Split(':');
            string ret = splitString[0] ?? null;
            return ret;
        }

        public IItemNonInventoryRet GetNonInvPartByName(ContextRz context, String strPartNumber, orddet_line xDetail)
        {
            try
            {
                IItemNonInventoryRetList ItemNonInventoryRetList = null;
                IItemNonInventoryRet ItemNonInventoryRet = null;
                List<IItemNonInventoryRet> retList = new List<IItemNonInventoryRet>();
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemNonInventoryQuery NonStockQuery = requestSet.AppendItemNonInventoryQueryRq();
                //NonStockQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(IdentifierFilter(Tools.Strings.Left(strPartNumber, 30)).Trim());

                NonStockQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.Name.SetValue(strPartNumber);
                NonStockQuery.ORListQueryWithOwnerIDAndClass.ListWithClassFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(ENMatchCriterion.mcContains);
                if (!Connect(context))
                    return null;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();

                string message = response.StatusMessage;


                return ItemNonInventoryRet;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }
        public IItemNonInventoryRet GetNonInvPartById(ContextRz context, orddet_line l, string listID)
        {
            try
            {
                if (string.IsNullOrEmpty(listID))
                    return null;
                IItemNonInventoryRetList ItemNonInventoryRetList = null;
                IItemNonInventoryRet ItemNonInventoryRet = null;
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemNonInventoryQuery NonStockQuery = requestSet.AppendItemNonInventoryQueryRq();
                NonStockQuery.ORListQueryWithOwnerIDAndClass.ListIDList.Add(IdentifierFilter(Tools.Strings.Left(listID, 30)).Trim());
                if (!Connect(context))
                    return null;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();


                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode >= 0)
                {
                    //the request-specific response is in the details, make sure we have some
                    if (response.Detail != null)
                    {
                        //make sure the response is the type we're expecting
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtItemNonInventoryQueryRs)
                        {
                            //upcast to more ecific type here, this is safe because we checked with response.Type check above
                            ItemNonInventoryRetList = (IItemNonInventoryRetList)response.Detail;
                            ItemNonInventoryRet = ItemNonInventoryRetList.GetAt(0);

                        }
                    }
                }
                return ItemNonInventoryRet;

            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }



        public IItemServiceRet GetServicePartById(ContextRz context, orddet_line l, string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return null;
                IItemServiceRetList svcRetList = null;
                IItemServiceRet svcRet = null;
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemServiceQuery svcQuery = requestSet.AppendItemServiceQueryRq();
                svcQuery.ORListQueryWithOwnerIDAndClass.ListIDList.Add(IdentifierFilter(Tools.Strings.Left(id, 30)).Trim());
                if (!Connect(context))
                    return null;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();

                //check the status code of the response, 0=ok, >0 is warning
                if (response.StatusCode >= 0)
                {
                    //the request-specific response is in the details, make sure we have some
                    if (response.Detail != null)
                    {
                        //make sure the response is the type we're expecting
                        ENResponseType responseType = (ENResponseType)response.Type.GetValue();
                        if (responseType == ENResponseType.rtItemServiceQueryRs)
                        {
                            //upcast to more ecific type here, this is safe because we checked with response.Type check above
                            svcRetList = (IItemServiceRetList)response.Detail;
                            svcRet = svcRetList.GetAt(0);

                        }
                    }
                }
                return svcRet;

            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }

        public bool ServiceItemExists(ContextRz context, String strPartNumber)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IItemServiceQuery ServiceQuery = requestSet.AppendItemServiceQueryRq();
                ServiceQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(IdentifierFilter(Tools.Strings.Left(strPartNumber, 30)).Trim());
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode != 0)
                    return false;
                if (responseSet.ResponseList.Count <= 0)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return false;
            }
        }
        public bool ItemExists(ContextRz context, String item)
        {
            if (NonInvPartExists(context, item))
                return true;

            if (ServiceItemExists(context, item))
                return true;

            if (InvPartExists(context, item))
                return true;

            return false;
        }
        public bool ItemExists(ContextRz context, orddet_line l)
        {
            if (NonInvPartExists(context, l))
                return true;
            return false;
        }
        public String MakeCompanyExist(ContextRz context, ordhed xOrder)
        {
            switch (xOrder.OrderType)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RMA:
                    return MakeCustomerExist(context, xOrder.CompanyVar.RefGet(context), xOrder.shippingaddress, xOrder.billingaddress);
                case Enums.OrderType.RFQ:
                case Enums.OrderType.Purchase:
                case Enums.OrderType.VendRMA:
                    return MakeVendorExist(context, xOrder.CompanyVar.RefGet(context), xOrder.shippingaddress, xOrder.billingaddress);
                case Enums.OrderType.Service:
                    //if (args != null)
                    //{
                    //    if (args.AsInvoice)
                    //    {
                    //        if (!MakeCustomerExist(xOrder.CompanyVar.RefGet(contextRz), ref strCompanyName, Silent, xOrder.shippingaddress, xOrder.billingaddress))
                    //        {
                    //            if (!Silent)
                    //                context.TheLeader.Tell("The company for " + xOrder.ToString() + " was not sent to QuickBooks as a customer.");
                    //            return false;
                    //        }
                    //        break;
                    //    }
                    //}
                    return MakeVendorExist(context, xOrder.CompanyVar.RefGet(context), xOrder.shippingaddress, xOrder.billingaddress);
                default:
                    throw new Exception(xOrder.ToString() + " is neither incoming nor outgoing.");
            }
        }
        public bool SendQuote(ordhed xOrder, IMsgSetRequest requestSet)
        {
            return false;
        }
        private string GetElementType(string type)
        {
            switch (type.ToLower())
            {
                case "list":
                    return "ListDataExt";
                case "txn":
                    return "TxnDataExt";
                case "other":
                    return "OtherDataExtType";
            }

            return null;
        }

        public void TestConnect(ContextRz context)
        {
            if (!Connect(context))
                throw new Exception("No QB connection.");

            Disconnect();
        }
        public virtual String PayableAccountCalc(ordhed_new p)
        {
            //2012_04_25  wtf?  this could never work
            //return ExpenseAccountNumber;
            return "Accounts Payable";
        }
        public virtual String MemoCalc(ordhed_new p)
        {
            return p.ordernumber;
        }

        public virtual String InitalsCalc(ContextRz context, ordhed_new order)
        {
            NewMethod.n_user u = order.UserObjectGet(context);
            if (u != null)
                //return u.GetSetting(context, "qb_initials");                
                //return u.GetSetting(context, "user_initials");
                return u.Initials.Trim().ToUpper();
            else
                return "";
        }

        public virtual void SplitTextAddress(ContextRz context, String strCompanyName, QBFC13Lib.IAddress xAddress, String strAddress)
        {
            try
            {
                if (!string.IsNullOrEmpty(strCompanyName))
                    xAddress.Addr1.SetValue(Tools.Strings.Left(FilterCustomerName(context, strCompanyName), Convert.ToInt32(xAddress.Addr1.GetMaxLength())));
                //changed 2008/01/09 so that the company name is the top line, which i think is the qb default
                String[] ary = Tools.Strings.Split(strAddress, "\r\n");
                int i = 0;
                string adr2 = "";
                string adr3 = "";
                string adr4 = "";
                string adrCity = "";
                string adrState = "";
                string adrPostal = "";
                string adrCountry = "";
                foreach (String s in ary)
                {
                    switch (i)
                    {
                        case 0:
                            adr2 = s;
                            break;
                        case 1:
                            adr3 = s;
                            break;
                        case 2:
                            adr4 = s;
                            break;
                        case 3:
                            adrCity = s;
                            break;
                        case 4:
                            adrState = s;
                            break;
                        case 5:
                            adrPostal = s;
                            break;
                        case 6:
                            adrCountry = s;
                            break;
                    }
                    i++;
                }
                if (!string.IsNullOrEmpty(adr2))
                    xAddress.Addr2.SetValue(Tools.Strings.Left(adr2, Convert.ToInt32(xAddress.Addr2.GetMaxLength())));
                if (!string.IsNullOrEmpty(adr3))
                    xAddress.Addr3.SetValue(Tools.Strings.Left(adr3, Convert.ToInt32(xAddress.Addr3.GetMaxLength())));
                if (!string.IsNullOrEmpty(adr4))
                    xAddress.Addr4.SetValue(Tools.Strings.Left(adr4, Convert.ToInt32(xAddress.Addr4.GetMaxLength())));
                if (!string.IsNullOrEmpty(adrCity))
                    xAddress.City.SetValue(Tools.Strings.Left(adrCity, Convert.ToInt32(xAddress.City.GetMaxLength())));
                if (!string.IsNullOrEmpty(adrState))
                    xAddress.State.SetValue(Tools.Strings.Left(adrState, Convert.ToInt32(xAddress.State.GetMaxLength())));
                if (!string.IsNullOrEmpty(adrPostal))
                    xAddress.PostalCode.SetValue(Tools.Strings.Left(adrPostal, Convert.ToInt32(xAddress.PostalCode.GetMaxLength())));
                if (!string.IsNullOrEmpty(adrCountry))
                    xAddress.Country.SetValue(Tools.Strings.Left(adrCountry, Convert.ToInt32(xAddress.Country.GetMaxLength())));

            }
            catch (Exception ex)
            {
                throw new Exception("Error splitting address ...");
            }
        }
        public String MakeCustomerExist(ContextRz context, company c)
        {
            return MakeCustomerExist(context, c, "x", "x");
        }
        public String MakeCustomerExist(ContextRz context, company c, String strAddress1, String strAddress2)
        {
            String strCustomerName = "";
            if (CompanyExists(context, c, CompanySelectionType.Customer))
            {
                context.TheLeader.Comment("Returning " + c.companyname + " as the vendor name for " + c.companyname);
                return c.companyname;
            }
            return context.TheLeaderRz.QBCreateCompany(context, Enums.CompanySelectionType.Customer, c, strAddress1, strAddress2);
        }
        public String MakeVendorExist(ContextRz context, company v)
        {
            return MakeVendorExist(context, v, "", "");
        }
        public String MakeVendorExist(ContextRz context, company v, String strAddress1, String strAddress2)
        {
            if (v == null)
                throw new Exception("The vendor is null");

            //String vendorName = "";
            //if (VendorExists(context, v, ref vendorName))
            if (CompanyExists(context, v, CompanySelectionType.Vendor))
            {
                context.TheLeader.Comment("Returning " + v.companyname + " as the vendor name for " + v.companyname);
                return v.companyname;
            }

            return context.TheLeaderRz.QBCreateCompany(context, Enums.CompanySelectionType.Vendor, v, strAddress1, strAddress2);
        }
        public bool UpdateCustomerInfo(ContextRz context, company c, companyaddress billing, companyaddress shipping, String strCustomerName)
        {
            return UpdateCustomerInfo(context, c, billing, shipping, strCustomerName, false);
        }
        public bool UpdateCustomerInfo(ContextRz context, company c, companyaddress billing, companyaddress shipping, String strCustomerName, Boolean bJustCreditCardInfo)
        {
            if (!Tools.Strings.StrExt(strCustomerName))
                return false;
            try
            {
                IMsgSetRequest requestSet1 = GetLatestMsgSetRequest(context, sessionManager);
                requestSet1.Attributes.OnError = ENRqOnError.roeStop;
                ICustomerQuery q = requestSet1.AppendCustomerQueryRq();
                //q.ORCustomerListQuery.FullNameList.Add(strCustomerName);
                q.ORCustomerListQuery.ListIDList.Add(c.qb_company_ListID);
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet1);
                IResponse response1 = responseSet1.ResponseList.GetAt(0);
                if (response1.Detail == null)
                {
                    Disconnect();
                    return false;
                }
                QBFC13Lib.ICustomerRetList custRet = (QBFC13Lib.ICustomerRetList)response1.Detail;
                if (custRet == null)
                {
                    Disconnect();
                    return false;
                }
                QBFC13Lib.ICustomerRet xCust = custRet.GetAt(0);
                context.Comment("Updating " + strCustomerName + "...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.ICustomerMod CustomerMod = requestSet.AppendCustomerModRq();
                CustomerMod.ListID.SetValue(xCust.ListID.GetValue());
                CustomerMod.EditSequence.SetValue(Tools.Strings.Left(xCust.EditSequence.GetValue(), Convert.ToInt32(CustomerMod.EditSequence.GetMaxLength())));
                if (!bJustCreditCardInfo)
                {
                    CustomerMod.Name.SetValue(Tools.Strings.Left(strCustomerName, Convert.ToInt32(CustomerMod.Name.GetMaxLength())));
                    CustomerMod.Contact.SetValue(Tools.Strings.Left(c.primarycontact, Convert.ToInt32(CustomerMod.Contact.GetMaxLength())));
                    CustomerMod.Email.SetValue(Tools.Strings.Left(c.primaryemailaddress, Convert.ToInt32(CustomerMod.Email.GetMaxLength())));
                    CustomerMod.Fax.SetValue(Tools.Strings.Left(c.primaryfax, Convert.ToInt32(CustomerMod.Fax.GetMaxLength())));
                    CustomerMod.Phone.SetValue(Tools.Strings.Left(c.primaryphone, Convert.ToInt32(CustomerMod.Phone.GetMaxLength())));
                    CustomerMod.ResaleNumber.SetValue(Tools.Strings.Left(c.taxid, Convert.ToInt32(CustomerMod.ResaleNumber.GetMaxLength())));
                    SetAddress(CustomerMod.BillAddress, c.companyname, billing);
                    SetAddress(CustomerMod.ShipAddress, c.companyname, shipping);
                }
                //Credit Card Info
                //Cannot Add Expiration Year earlier than current year.  Therefore, check that, 
                if (c.expiration_year > 0)
                {
                    if (c.expiration_year < DateTime.Today.Year)

                        context.Leader.Tell("The expiration year for the card we have on file for " + c.companyname + " is " + c.expiration_year + " which is less that the current year, and Quickbooks doesn't allow this.  Credit card information is being skipped for now.  Update the card to a current one, then Rz can send the new data to Quickbooks.");

                    else
                    {
                        CustomerMod.CreditCardInfo.CreditCardNumber.SetValue(Tools.Strings.Left(c.creditcardnumber, Convert.ToInt32(CustomerMod.CreditCardInfo.CreditCardNumber.GetMaxLength())));
                        CustomerMod.CreditCardInfo.CreditCardAddress.SetValue(Tools.Strings.Left(c.cardbillingaddr, Convert.ToInt32(CustomerMod.CreditCardInfo.CreditCardAddress.GetMaxLength())));
                        CustomerMod.CreditCardInfo.CreditCardPostalCode.SetValue(Tools.Strings.Left(c.cardbillingzip, Convert.ToInt32(CustomerMod.CreditCardInfo.CreditCardPostalCode.GetMaxLength())));
                        CustomerMod.CreditCardInfo.NameOnCard.SetValue(Tools.Strings.Left(c.nameoncard, Convert.ToInt32(CustomerMod.CreditCardInfo.NameOnCard.GetMaxLength())));
                        if (c.expiration_month > 0 && c.expiration_month < 13)
                            CustomerMod.CreditCardInfo.ExpirationMonth.SetValue(c.expiration_month);
                        if (c.expiration_year > 0)
                            CustomerMod.CreditCardInfo.ExpirationYear.SetValue(c.expiration_year);
                    }
                }

                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode == 0)
                {
                    context.Comment("The customer " + c.companyname + " [" + strCustomerName + "] was updated in QuickBooks.");
                    return true;
                }
                else
                {
                    context.TheLeader.Tell("The customer " + c.companyname + " [" + strCustomerName + "] could not be updated in QuickBooks: " + response.StatusMessage);
                    return false;
                }
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error updaing " + c.companyname + " [" + strCustomerName + "] in QuickBooks: " + ex.Message);
                return false;
            }
        }
        public bool UpdateVendorInfo(ContextRz context, company c, companyaddress billing, companyaddress shipping, String strVendorName, Boolean bJustCreditCardInfo)
        {
            if (!Tools.Strings.StrExt(strVendorName))
                return false;
            try
            {
                IMsgSetRequest requestSet1 = GetLatestMsgSetRequest(context, sessionManager);
                requestSet1.Attributes.OnError = ENRqOnError.roeStop;
                IVendorQuery q = requestSet1.AppendVendorQueryRq();
                q.ORVendorListQuery.FullNameList.Add(strVendorName);
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet1 = sessionManager.DoRequests(requestSet1);
                IResponse response1 = responseSet1.ResponseList.GetAt(0);
                if (response1.Detail == null)
                {
                    Disconnect();
                    return false;
                }
                IVendorRetList vendRet = (IVendorRetList)response1.Detail;
                if (vendRet == null)
                {
                    Disconnect();
                    return false;
                }
                IVendorRet xVend = vendRet.GetAt(0);
                context.Comment("Updating " + strVendorName + "...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IVendorMod VendorMod = requestSet.AppendVendorModRq();
                VendorMod.ListID.SetValue(xVend.ListID.GetValue());
                VendorMod.EditSequence.SetValue(Tools.Strings.Left(xVend.EditSequence.GetValue(), Convert.ToInt32(VendorMod.EditSequence.GetMaxLength())));
                if (!bJustCreditCardInfo)
                {
                    VendorMod.Name.SetValue(Tools.Strings.Left(strVendorName, Convert.ToInt32(VendorMod.Name.GetMaxLength())));
                    VendorMod.Contact.SetValue(Tools.Strings.Left(c.primarycontact, Convert.ToInt32(VendorMod.Contact.GetMaxLength())));
                    VendorMod.Email.SetValue(Tools.Strings.Left(c.primaryemailaddress, Convert.ToInt32(VendorMod.Email.GetMaxLength())));
                    VendorMod.Fax.SetValue(Tools.Strings.Left(c.primaryfax, Convert.ToInt32(VendorMod.Fax.GetMaxLength())));
                    VendorMod.Phone.SetValue(Tools.Strings.Left(c.primaryphone, Convert.ToInt32(VendorMod.Phone.GetMaxLength())));
                    //VendorMod.ResaleNumber.SetValue(Tools.Strings.Left(c.taxid, Convert.ToInt32(VendorMod.ResaleNumber.GetMaxLength())));
                    SetAddress(VendorMod.VendorAddress, c.companyname, billing);
                    SetAddress(VendorMod.ShipAddress, c.companyname, shipping);
                }

                ////Credit Card Info
                ////Cannot Add Expiration Year earlier than current year.  Therefore, check that, 
                //if (c.expiration_year > 0)
                //{
                //    if (c.expiration_year < DateTime.Today.Year)

                //        context.Leader.Tell("The expiration year for the card we have on file for " + c.companyname + " is " + c.expiration_year + " which is less that the current year, and Quickbooks doesn't allow this.  Credit card information is being skipped for now.  Update the card to a current one, then Rz can send the new data to Quickbooks.");

                //    else
                //    {
                //        VendorMod.CreditCardInfo.CreditCardNumber.SetValue(Tools.Strings.Left(c.creditcardnumber, Convert.ToInt32(CustomerMod.CreditCardInfo.CreditCardNumber.GetMaxLength())));
                //        VendorMod.CreditCardInfo.CreditCardAddress.SetValue(Tools.Strings.Left(c.cardbillingaddr, Convert.ToInt32(CustomerMod.CreditCardInfo.CreditCardAddress.GetMaxLength())));
                //        VendorMod.CreditCardInfo.CreditCardPostalCode.SetValue(Tools.Strings.Left(c.cardbillingzip, Convert.ToInt32(CustomerMod.CreditCardInfo.CreditCardPostalCode.GetMaxLength())));
                //        VendorMod.CreditCardInfo.NameOnCard.SetValue(Tools.Strings.Left(c.nameoncard, Convert.ToInt32(CustomerMod.CreditCardInfo.NameOnCard.GetMaxLength())));
                //        if (c.expiration_month > 0 && c.expiration_month < 13)
                //            VendorMod.CreditCardInfo.ExpirationMonth.SetValue(c.expiration_month);
                //        if (c.expiration_year > 0)
                //            VendorMod.CreditCardInfo.ExpirationYear.SetValue(c.expiration_year);
                //    }
                //}

                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.StatusCode == 0)
                {
                    context.Comment("The customer " + c.companyname + " [" + strVendorName + "] was updated in QuickBooks.");
                    return true;
                }
                else
                {
                    context.TheLeader.Tell("The customer " + c.companyname + " [" + strVendorName + "] could not be updated in QuickBooks: " + response.StatusMessage);
                    return false;
                }
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error updaing " + c.companyname + " [" + strVendorName + "] in QuickBooks: " + ex.Message);
                return false;
            }
        }
        public bool SendCustomerDirectly(ContextRz context, company c, companyaddress billing, companyaddress shipping, String strCustomerName)
        {
            if (!Tools.Strings.StrExt(strCustomerName))
                return false;
            try
            {

                context.Comment("Sending " + strCustomerName + "...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                ICustomerAdd CustomerAdd = requestSet.AppendCustomerAddRq();
                CustomerAdd.Name.SetValue(Tools.Strings.Left(strCustomerName, Convert.ToInt32(CustomerAdd.Name.GetMaxLength())));
                CustomerAdd.CompanyName.SetValue(Tools.Strings.Left(strCustomerName, Convert.ToInt32(CustomerAdd.CompanyName.GetMaxLength())));
                CustomerAdd.Contact.SetValue(Tools.Strings.Left(c.primarycontact, Convert.ToInt32(CustomerAdd.Contact.GetMaxLength())));
                CustomerAdd.Email.SetValue(Tools.Strings.Left(c.primaryemailaddress, Convert.ToInt32(CustomerAdd.Email.GetMaxLength())));
                CustomerAdd.Fax.SetValue(Tools.Strings.Left(c.primaryfax, Convert.ToInt32(CustomerAdd.Fax.GetMaxLength())));
                CustomerAdd.Phone.SetValue(Tools.Strings.Left(c.primaryphone, Convert.ToInt32(CustomerAdd.Phone.GetMaxLength())));
                CustomerAdd.ResaleNumber.SetValue(Tools.Strings.Left(c.taxid, Convert.ToInt32(CustomerAdd.ResaleNumber.GetMaxLength())));
                //Credit Card Info
                //Cannot Add Expiration Year earlier than current year.  Therefore, check that, 
                if (c.expiration_year > 0)
                {
                    if (c.expiration_year < DateTime.Today.Year)
                        context.Leader.Tell("The expiration year for the card we have on file for " + c.companyname + " is " + c.expiration_year + " which is less that the current year, and Quickbooks doesn't allow this.  Credit card information is being skipped for now.  Update the card to a current one, then Rz can send the new data to Quickbooks.");
                    else
                    {
                        CustomerAdd.CreditCardInfo.CreditCardNumber.SetValue(Tools.Strings.Left(c.creditcardnumber, Convert.ToInt32(CustomerAdd.CreditCardInfo.CreditCardNumber.GetMaxLength())));
                        CustomerAdd.CreditCardInfo.CreditCardAddress.SetValue(Tools.Strings.Left(c.cardbillingaddr, Convert.ToInt32(CustomerAdd.CreditCardInfo.CreditCardAddress.GetMaxLength())));
                        CustomerAdd.CreditCardInfo.CreditCardPostalCode.SetValue(Tools.Strings.Left(c.cardbillingzip, Convert.ToInt32(CustomerAdd.CreditCardInfo.CreditCardPostalCode.GetMaxLength())));
                        CustomerAdd.CreditCardInfo.NameOnCard.SetValue(Tools.Strings.Left(c.nameoncard, Convert.ToInt32(CustomerAdd.CreditCardInfo.NameOnCard.GetMaxLength())));
                        if (c.expiration_month > 0 && c.expiration_month < 13)
                            CustomerAdd.CreditCardInfo.ExpirationMonth.SetValue(c.expiration_month);
                        if (c.expiration_year > 0)
                            CustomerAdd.CreditCardInfo.ExpirationYear.SetValue(c.expiration_year);
                    }
                }

                //Address Info
                SetAddress(CustomerAdd.BillAddress, c.companyname, billing);
                SetAddress(CustomerAdd.ShipAddress, c.companyname, shipping);


                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                bool successfullySent = false;
                if (response.StatusCode == 3100)
                {//3100 means name is already in use.  This means the customer may exist in QB but hasn't had the relationship set in Rz.
                 //Allow user to review teh company / name, and set the link.
                    successfullySent = doQbCompanyLink(context, c, CompanySelectionType.Customer);
                }

                else if (response.StatusCode == 0)
                {
                    ICustomerRet qbCust = (ICustomerRet)response.Detail;
                    successfullySent = SetQbRelationshipCustomer(context, qbCust, c);
                }
                else
                    HandleQbStatusCode(context, response, c.companyname);

                if (successfullySent)

                    context.Leader.Tell(c.companyname + " has been successfully linked to the Quickbooks Customer: " + c.companyname);
                else
                    context.TheLeader.Tell("The customer " + c.companyname + " [" + strCustomerName + "] could not be added to QuickBooks: " + response.StatusMessage);

                return successfullySent;


            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error sending " + c.companyname + " [" + strCustomerName + "] to QuickBooks: " + ex.Message);
                Disconnect();
                return false;
            }

        }
        public bool SendVendorDirectly(ContextRz context, company c, companyaddress billing, companyaddress shipping, String strVendorName)
        {
            if (!Tools.Strings.StrExt(strVendorName))
                return false;
            try
            {
                context.Comment("Sending " + strVendorName + "...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IVendorAdd VendorAdd = requestSet.AppendVendorAddRq();
                VendorAdd.Name.SetValue(Tools.Strings.Left(strVendorName, Convert.ToInt32(VendorAdd.Name.GetMaxLength())));
                VendorAdd.CompanyName.SetValue(Tools.Strings.Left(strVendorName, Convert.ToInt32(VendorAdd.CompanyName.GetMaxLength())));
                VendorAdd.NameOnCheck.SetValue(Tools.Strings.Left(strVendorName.Replace(" (V)", "").Trim(), Convert.ToInt32(VendorAdd.NameOnCheck.GetMaxLength())));
                VendorAdd.Contact.SetValue(Tools.Strings.Left(c.primarycontact, Convert.ToInt32(VendorAdd.Contact.GetMaxLength())));
                VendorAdd.Email.SetValue(Tools.Strings.Left(c.primaryemailaddress, Convert.ToInt32(VendorAdd.Email.GetMaxLength())));
                VendorAdd.Fax.SetValue(Tools.Strings.Left(c.primaryfax, Convert.ToInt32(VendorAdd.Fax.GetMaxLength())));
                VendorAdd.Phone.SetValue(Tools.Strings.Left(c.primaryphone, Convert.ToInt32(VendorAdd.Phone.GetMaxLength())));
                //VendorAdd.VendorTaxIdent.SetValue(Tools.Strings.Left(c.taxid, Convert.ToInt32(VendorAdd.VendorTaxIdent.GetMaxLength())));

                switch (c.taxid.ToLower().Trim())
                {
                    case "":
                    case "donotsell":
                        break;
                    default:
                        VendorAdd.VendorTaxIdent.SetValue(Tools.Strings.Left(c.taxid, Convert.ToInt32(VendorAdd.VendorTaxIdent.GetMaxLength())));
                        break;
                }

                SetAddress(VendorAdd.VendorAddress, c.companyname, billing);
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                bool successfullySent = false;
                if (response.StatusCode == 3100)
                {//3100 means name is already in use.  This means the customer may exist in QB but hasn't had the relationship set in Rz.
                 //Allow user to review teh company / name, and set the link.
                    successfullySent = doQbCompanyLink(context, c, CompanySelectionType.Vendor);
                }
                else if (response.StatusCode == 0)
                {
                    IVendorRet qbVend = (IVendorRet)response.Detail;
                    successfullySent = SetQbRelationshipVendor(context, qbVend, c);
                    context.Comment("The vendor " + c.companyname + " [" + strVendorName + "] was added to QuickBooks.");

                }
                else
                    HandleQbStatusCode(context, response, c.companyname);


                if (successfullySent)
                    context.Leader.Tell(c.companyname + " has been successfully linked to the Quickbooks Vendor: " + c.companyname);
                else
                    context.TheLeader.Tell("The vendor " + c.companyname + " [" + strVendorName + "] could not be added to QuickBooks: " + response.StatusMessage);

                return successfullySent;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error sending " + c.companyname + " [" + strVendorName + "] to QuickBooks: " + ex.Message);
                return false;
            }
        }
        private bool doQbCompanyLink(ContextRz context, company c, CompanySelectionType type)
        {
            switch (type)
            {
                case CompanySelectionType.Customer:
                    {
                        TheCustomer = SearchQBCustomerByName(context, c);
                        if (TheCustomer != null)
                            return SetQbRelationshipCustomer(context, TheCustomer, c);
                        return false;
                    }
                case CompanySelectionType.Vendor:
                    {
                        TheVendor = SearchQBVendorByName(context, c);
                        if (TheVendor != null)
                            return SetQbRelationshipVendor(context, TheVendor, c);
                        return false;
                    }
                default:
                    return false;
            }
        }
        private void HandleQbStatusCode(ContextRz context, IResponse response, string itemName, ordhed_new xOrder = null)
        {
            int code = response.StatusCode;
            switch (code)
            {
                case 3120:
                    {
                        //TxnID in Rz not found in Qb.
                        if (context.Leader.AskYesNo("It appears the item that was initially synced from Rz to QB has changed.  Would you like to remove the reference in RZ to the old part, which should allow you to sync this as a new part to correct the issue?"))
                        {
                            //This is telling us a transaction was set on the line, but can't be found or doesn't exist in QB.  Remove lines related to current order, with this txnid.
                            ClearTxnIdLinkageOrdhed(context, response, xOrder);

                        }
                        break;
                    }
                case 3020:
                    context.Leader.Error("Quickbooks does not allow entry of credit card data with an expiration year less than the current year.  Please fix before trying to add or update this company in Quickbooks.");
                    break;
                case 3100:
                    throw new Exception(response.StatusMessage);
                case 3140:
                    throw new Exception("Agent does not exist in Quickbooks:  " + response.StatusMessage);
                //case 3205:
                //    context.Leader.Error("Note, QB can't handle this company's address.  Please consolidate the address to 5 or less lines if you want to sync the address");
                //    break;
                case 3070:
                    throw new Exception("There was an error updating this order in QuickBooks.  The Ordernumber '" + itemName + "' is too long.  Code: " + code + " Message: " + response.StatusMessage);
                case 3175:
                    throw new Exception("This transaction appears to be locked.  Please make sure no one is actively editing this order in QB, then try again.");
                case 3290:
                    throw new Exception(response.StatusMessage);
                default:
                    throw new Exception("There was an error sending [" + itemName + "] to QuickBooks: Code: " + code + " Message: " + response.StatusMessage);


            }
        }

        private void ClearListIDLInkage(ContextRz context, orddet_line d, Enums.OrderType OrderType)
        {
            //Clear the MFG ID
            d.qb_line_subitem_ListID = null;
            if (OrderType == OrderType.Sales)
            {
                d.qb_line_ListID = null;
                d.Update(context);
            }
            else if (OrderType == OrderType.Purchase)
            {
                d.qb_line_ListID = null;
                d.Update(context);
            }
            else if (OrderType == OrderType.Service)
            {
                service_line sl = service_line.GetById(context, d.unique_id);
                if (sl == null)
                    throw new Exception("Could not find a service line with unique_id: " + d.unique_id);
                sl.qb_line_ListID = null;
                sl.qb_line_subitem_ListID = null;
                sl.Update(context);
            }
            else
                throw new Exception("Cannot clear TxnID:  Uknown Rz Order Type");

            context.Comment("Rz line has been dis-associated wit the old Quickbooks part number.  Part will be updated on next Sync.");
        }

        private void ClearTxnIdLinkageOrdhed(ContextRz x, IResponse response, ordhed_new xOrder)
        {
            //Identify the problematic line on the PO / Item, then un-set the QB identifiers for it in Rz.
            string[] sp = response.StatusMessage.Split('"');
            string problemTxnID = sp[1];
            List<orddet_line> lineList = new List<orddet_line>();



            if (xOrder is ordhed_sales)
                lineList = CurrentSalesOrder.DetailsVar.RefsList(x).Where(w => w.qb_line_TxnID == problemTxnID).ToList();
            else if (xOrder is ordhed_purchase)
                lineList = CurrentPurchaseOrder.DetailsVar.RefsList(x).Where(w => w.qb_line_TxnID_purchase == problemTxnID).ToList();
            else if (xOrder is ordhed_service)
                lineList = CurrentServiceOrder.DetailsVar.RefsList(x).Where(w => w.qb_line_TxnID_purchase == problemTxnID).ToList();



            if (lineList.Count <= 0)
                throw new Exception("Could not retrieve list of lines from order header for which to clear TxnID.");

            foreach (orddet_line l in lineList)
            {
                x.Leader.Comment("Clearing Txn reference to Quickbooks Order Object for " + l.fullpartnumber);
                if (xOrder is ordhed_sales)
                    l.qb_line_TxnID = null;
                else
                    l.qb_line_TxnID_purchase = null;
                l.Update(x);
                x.Leader.Comment("Txn Reference cleared for " + l.fullpartnumber);
            }

        }



        public virtual ArrayList GetSalesRepCollection(ContextRz context)
        {
            ArrayList a = new ArrayList();
            try
            {
                context.Comment("Gathering all QB's Sales Reps...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                if (requestSet == null)
                    return a;
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.ISalesRepQuery SalesRepQuery = requestSet.AppendSalesRepQueryRq();
                if (SalesRepQuery == null)
                {
                    context.TheLeader.Comment("SalesRep Query came back null.");
                    return a;
                }
                if (!Connect(context))
                    return a;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                if (responseSet == null)
                    return a;
                IResponse response = responseSet.ResponseList.GetAt(0);
                if (response == null)
                    return a;
                Disconnect();
                if (response.StatusCode != 0)
                {
                    context.TheLeader.Comment("Failed.");
                    return a;
                }
                QBFC13Lib.ISalesRepRetList salesrepRetList = (ISalesRepRetList)response.Detail;
                if (salesrepRetList != null)
                {
                    for (Int32 i = 0; i < salesrepRetList.Count; i++)
                    {
                        QBFC13Lib.ISalesRepRet SalesRepRet = salesrepRetList.GetAt(i); ;
                        if (SalesRepRet == null)
                            continue;
                        try
                        {
                            NewMethod.n_user u = NewMethod.n_user.New(context);
                            if (SalesRepRet.SalesRepEntityRef != null)
                            {
                                if (SalesRepRet.SalesRepEntityRef.FullName != null)
                                    u.name = SalesRepRet.SalesRepEntityRef.FullName.GetValue();
                            }
                            if (SalesRepRet.Initial != null)
                                u.user_initials = SalesRepRet.Initial.GetValue();
                            if (Tools.Strings.StrExt(u.name) && Tools.Strings.StrExt(u.user_initials))
                                a.Add(u);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                return a;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error retreiving this employee list: " + ex.Message);
                return a;
            }
        }
        public virtual ArrayList GetCompanyCollection(ContextNM x)
        {
            x.Reorg();
            return null;

        }
        public virtual ArrayList GetVendorCollection(ContextNM x)
        {
            x.Reorg();
            return null;


        }
        public virtual ArrayList GetInventoryCollection(ContextNM x)
        {
            x.Reorg();
            return null;


        }
        public virtual ArrayList GetNonInventoryCollection(ContextNM x)
        {
            x.Reorg();
            return null;

        }
        public virtual ArrayList GetSalesOrderCollection(ContextRz context, DateTime date_cutoff)
        {
            ArrayList a = new ArrayList();
            try
            {
                context.Comment("Gathering all QB's Sales Orders...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                if (requestSet == null)
                    return a;
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.ISalesOrderQuery SalesQuery = requestSet.AppendSalesOrderQueryRq();
                if (SalesQuery == null)
                {
                    context.TheLeader.Comment("SalesQuery returned null.");
                    return a;
                }
                SalesQuery.IncludeLineItems.SetValue(true);
                if (!Connect(context))
                    return a;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                if (responseSet == null)
                    return a;
                IResponse response = responseSet.ResponseList.GetAt(0);
                if (response == null)
                    return a;
                Disconnect();
                if (response.StatusCode != 0)
                {
                    context.TheLeader.Comment("Failed.");
                    return a;
                }
                QBFC13Lib.ISalesOrderRetList salesRetList = (ISalesOrderRetList)response.Detail;
                if (salesRetList == null)
                    return a;
                for (Int32 i = 0; i < salesRetList.Count; i++)
                {
                    QBFC13Lib.ISalesOrderRet SalesRet = salesRetList.GetAt(i);
                    if (SalesRet == null)
                        continue;
                    if (Tools.Dates.DateExists(date_cutoff))
                    {
                        if (SalesRet.TxnDate == null)
                            continue;
                        if (SalesRet.TxnDate.IsEmpty())
                            continue;
                        if (SalesRet.TxnDate.GetValue() < date_cutoff)
                            continue;
                    }
                    a.Add(SalesRet);

                }
                return a;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error retreiving sales order list: " + ex.Message);
                context.TheLeader.Tell("There was an error retreiving sales order list: " + ex.Message);
                return a;
            }
        }
        public virtual ArrayList GetPurchaseOrderCollection(ContextRz context, DateTime date_cutoff)
        {
            ArrayList a = new ArrayList();
            long bad_count = 0;
            try
            {
                context.Comment("Gathering all QB's Purchase Orders...");
                context.Comment("IMsgSetRequest requestSet = GetLatestMsgSetRequest(sessionManager);");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                if (requestSet == null)
                {
                    context.Comment("requestSet == null");
                    return a;
                }
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                context.Comment("QBFC13Lib.IPurchaseOrderQuery PurchaseQuery = requestSet.AppendPurchaseOrderQueryRq();");
                QBFC13Lib.IPurchaseOrderQuery PurchaseQuery = requestSet.AppendPurchaseOrderQueryRq();
                if (PurchaseQuery == null)
                {
                    context.Comment("PurchaseQuery returned null.");
                    return a;
                }
                PurchaseQuery.IncludeLineItems.SetValue(true);
                context.Comment("Connect()");
                if (!Connect(context))
                {
                    context.Comment("!Connect()");
                    return a;
                }
                context.Comment("IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);");
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                if (responseSet == null)
                {
                    context.Comment("responseSet == null");
                    return a;
                }
                context.Comment("IResponse response = responseSet.ResponseList.GetAt(0);");
                IResponse response = responseSet.ResponseList.GetAt(0);
                if (response == null)
                {
                    context.Comment("response == null");
                    return a;
                }
                context.Comment("Disconnect()");
                Disconnect();
                if (response.StatusCode != 0)
                {
                    context.Comment("Failed.");
                    return a;
                }
                context.Comment("QBFC13Lib.IPurchaseOrderRetList purchaseRetList = (IPurchaseOrderRetList)response.Detail;");
                QBFC13Lib.IPurchaseOrderRetList purchaseRetList = (IPurchaseOrderRetList)response.Detail;
                if (purchaseRetList == null)
                {
                    context.Comment("purchaseRetList == null");
                    return a;
                }
                context.Comment("Found " + purchaseRetList.Count + " purchase orders.");
                Int32 countn = 0;
                for (Int32 i = 0; i < purchaseRetList.Count; i++)
                {
                    try
                    {
                        countn = i + 1;
                        context.Comment("Importing " + countn + " of " + purchaseRetList.Count + ".");
                        QBFC13Lib.IPurchaseOrderRet PurchaseRet = purchaseRetList.GetAt(i);
                        if (PurchaseRet == null)
                            continue;
                        if (Tools.Dates.DateExists(date_cutoff))
                        {
                            if (PurchaseRet.TxnDate == null)
                                continue;
                            if (PurchaseRet.TxnDate.IsEmpty())
                                continue;
                            if (PurchaseRet.TxnDate.GetValue() < date_cutoff)
                                continue;
                        }
                        ordhed o = ordhed.CreateNew((ContextRz)context, Enums.OrderType.Purchase);
                        SetPurchaseOrderNumber(context, PurchaseRet, o);
                        context.Update(o);
                        String customer = "";
                        if (PurchaseRet.VendorRef != null)
                        {
                            if (PurchaseRet.VendorRef.FullName != null)
                            {
                                if (!PurchaseRet.VendorRef.FullName.IsEmpty())
                                    customer = PurchaseRet.VendorRef.FullName.GetValue();
                            }
                        }
                        customer = ParseTrimCompany(customer);
                        o.companyname = customer;
                        o.base_company_uid = company.TranslateNameToID(context, o.companyname);
                        if (PurchaseRet.RefNumber != null)
                        {
                            if (!PurchaseRet.RefNumber.IsEmpty())
                                o.ordernumber = PurchaseRet.RefNumber.GetValue();
                        }
                        if (PurchaseRet.Memo != null)
                        {
                            if (!PurchaseRet.Memo.IsEmpty())
                                o.internalcomment = "Memo: " + PurchaseRet.Memo.GetValue();
                        }
                        if (PurchaseRet.VendorMsg != null)
                        {
                            if (!PurchaseRet.VendorMsg.IsEmpty())
                            {
                                if (Tools.Strings.StrExt(o.internalcomment))
                                    o.internalcomment += "\r\n";
                                o.internalcomment += "VendorMsg: " + PurchaseRet.VendorMsg.GetValue();
                            }
                        }
                        o.is_qbimport = true;
                        if (PurchaseRet.TxnDate != null)
                        {
                            if (!PurchaseRet.TxnDate.IsEmpty())
                                o.orderdate = PurchaseRet.TxnDate.GetValue();
                        }
                        if (PurchaseRet.RefNumber != null)
                        {
                            if (!PurchaseRet.RefNumber.IsEmpty())
                                o.orderreference = PurchaseRet.RefNumber.GetValue();
                        }
                        if (PurchaseRet.ShipAddress != null)
                        {
                            if (PurchaseRet.ShipAddress.Addr1 != null)
                            {
                                if (!PurchaseRet.ShipAddress.Addr1.IsEmpty())
                                {
                                    o.shippingaddress = PurchaseRet.ShipAddress.Addr1.GetValue() + "\r\n";
                                    o.billingaddress = PurchaseRet.ShipAddress.Addr1.GetValue() + "\r\n";
                                    o.billingname = PurchaseRet.ShipAddress.Addr1.GetValue();
                                    o.shippingname = PurchaseRet.ShipAddress.Addr1.GetValue();
                                }
                                if (PurchaseRet.ShipAddress.Addr2 != null)
                                {
                                    if (!PurchaseRet.ShipAddress.Addr2.IsEmpty())
                                    {
                                        o.shippingaddress += PurchaseRet.ShipAddress.Addr2.GetValue() + "\r\n";
                                        o.billingaddress += PurchaseRet.ShipAddress.Addr2.GetValue() + "\r\n";
                                    }
                                }
                                if (PurchaseRet.ShipAddress.Addr3 != null)
                                {
                                    if (!PurchaseRet.ShipAddress.Addr3.IsEmpty())
                                    {
                                        o.shippingaddress += PurchaseRet.ShipAddress.Addr3.GetValue() + "\r\n";
                                        o.billingaddress += PurchaseRet.ShipAddress.Addr3.GetValue() + "\r\n";
                                    }
                                }
                                if (PurchaseRet.ShipAddress.City != null)
                                {
                                    if (!PurchaseRet.ShipAddress.City.IsEmpty())
                                    {
                                        o.shippingaddress += PurchaseRet.ShipAddress.City.GetValue() + ", ";
                                        o.billingaddress += PurchaseRet.ShipAddress.City.GetValue() + ", ";
                                    }
                                }
                                if (PurchaseRet.ShipAddress.State != null)
                                {
                                    if (!PurchaseRet.ShipAddress.State.IsEmpty())
                                    {
                                        o.shippingaddress += PurchaseRet.ShipAddress.State.GetValue() + "  ";
                                        o.billingaddress += PurchaseRet.ShipAddress.State.GetValue() + "  ";
                                    }
                                }
                                if (PurchaseRet.ShipAddress.PostalCode != null)
                                {
                                    if (!PurchaseRet.ShipAddress.PostalCode.IsEmpty())
                                    {
                                        o.shippingaddress += PurchaseRet.ShipAddress.PostalCode.GetValue() + "\r\n";
                                        o.billingaddress += PurchaseRet.ShipAddress.PostalCode.GetValue() + "\r\n";
                                    }
                                }
                                if (PurchaseRet.ShipAddress.Country != null)
                                {
                                    if (!PurchaseRet.ShipAddress.Country.IsEmpty())
                                    {
                                        o.shippingaddress += PurchaseRet.ShipAddress.Country.GetValue();
                                        o.billingaddress += PurchaseRet.ShipAddress.Country.GetValue();
                                    }
                                }
                            }
                        }
                        if (PurchaseRet.TermsRef != null)
                        {
                            if (!PurchaseRet.TermsRef.FullName.IsEmpty())
                                o.terms = PurchaseRet.TermsRef.FullName.GetValue();
                        }
                        if (PurchaseRet.ShipMethodRef != null)
                        {
                            if (!PurchaseRet.ShipMethodRef.FullName.IsEmpty())
                                o.shipvia = PurchaseRet.ShipMethodRef.FullName.GetValue();
                        }
                        for (Int32 ii = 0; ii <= PurchaseRet.ORPurchaseOrderLineRetList.Count - 1; ii++)
                        {
                            try
                            {
                                QBFC13Lib.IORPurchaseOrderLineRet y = (QBFC13Lib.IORPurchaseOrderLineRet)PurchaseRet.ORPurchaseOrderLineRetList.GetAt(ii);
                                if (y == null)
                                    continue;
                                QBFC13Lib.IPurchaseOrderLineRet line = y.PurchaseOrderLineRet;
                                if (line == null)
                                    continue;
                                orddet_line d = (orddet_line)o.GetNewDetail((ContextRz)context);
                                if (line.ItemRef != null)
                                {
                                    if (line.ItemRef.FullName != null)
                                    {
                                        if (!line.ItemRef.FullName.IsEmpty())
                                            d.fullpartnumber = line.ItemRef.FullName.GetValue();
                                    }
                                    if (Tools.Strings.StrCmp(d.fullpartnumber, "777") || Tools.Strings.StrCmp(d.fullpartnumber, "cost of good sold"))
                                    {
                                        if (line.Desc != null)
                                        {
                                            if (!line.Desc.IsEmpty())
                                                d.fullpartnumber = line.Desc.GetValue();
                                        }
                                    }
                                    d.alternatepart_04 = d.fullpartnumber;
                                }
                                if (line.Desc != null)
                                {
                                    if (!line.Desc.IsEmpty())
                                        d.description = line.Desc.GetValue();
                                }
                                if (!Tools.Strings.StrExt(d.fullpartnumber) && !Tools.Strings.StrExt(d.description))
                                {
                                    context.Delete(d);
                                    continue;
                                }
                                if (Tools.Strings.StrCmp(d.fullpartnumber, "Subtotal"))
                                {
                                    context.Delete(d);
                                    continue;
                                }
                                if (line.Quantity != null)
                                {
                                    if (!line.Quantity.IsEmpty())
                                        d.quantity = Convert.ToInt32(line.Quantity.GetValue());
                                }
                                if (line.Quantity != null)
                                {
                                    if (!line.Quantity.IsEmpty())
                                        d.quantity = Convert.ToInt32(line.Quantity.GetValue());
                                }
                                else
                                    d.quantity = 1;
                                if (line.ReceivedQuantity != null)
                                {
                                    if (!line.ReceivedQuantity.IsEmpty())
                                        d.quantity_unpacked = Convert.ToInt32(line.ReceivedQuantity.GetValue());
                                }
                                if (d.quantity == 0)
                                    d.quantity = d.quantity_unpacked;
                                if (d.quantity == 0)
                                {
                                    d.quantity = 1;
                                    d.quantity_unpacked = 1;
                                }
                                if (d.quantity <= d.quantity_unpacked)
                                    d.Status = Enums.OrderLineStatus.Received;
                                else
                                    d.Status = Enums.OrderLineStatus.Open;
                                if (line.Amount != null)
                                {
                                    if (!line.Amount.IsEmpty())
                                    {
                                        Double dd = line.Amount.GetValue();
                                        if (d.quantity > 0)
                                            d.unit_cost = dd / d.quantity;
                                    }
                                }
                                context.Update(d);
                            }
                            catch { bad_count = bad_count + 1; }
                        }
                        //o.GatherDetails();
                        if (PurchaseRet.IsFullyReceived != null)
                        {
                            if (!PurchaseRet.IsFullyReceived.IsEmpty())
                            {
                                if (PurchaseRet.IsFullyReceived.GetValue())
                                {
                                    try { o.Inserting(context); }
                                    catch { }
                                    checkpayment cp = checkpayment.New(context);
                                    cp.base_company_uid = o.base_company_uid;
                                    cp.base_ordhed_uid = o.unique_id;
                                    cp.companyname = o.companyname;
                                    cp.transamount = o.ordertotal;
                                    cp.transtype = "Check";
                                    cp.senttoqb = true;
                                    context.Insert(cp);
                                }
                            }
                        }
                        o.senttoqb = true;
                        context.Update(o);
                    }
                    catch { bad_count = bad_count + 1; }
                }
                if (bad_count > 0)
                    context.Comment("Rejected count: " + bad_count.ToString());
                return a;
            }
            catch (Exception ex)
            {
                if (bad_count > 0)
                    context.Comment("Rejected count: " + bad_count.ToString());
                context.TheLeader.Error("There was an error retreiving purchase order list: " + ex.Message);
                return a;
            }
        }
        public virtual ArrayList GetBillCollection(ContextRz context, DateTime date_cutoff)
        {
            ArrayList a = new ArrayList();
            long bad_count = 0;
            try
            {
                context.Comment("Gathering all QB's Bills...");
                context.Comment("IMsgSetRequest requestSet = GetLatestMsgSetRequest(sessionManager);");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                if (requestSet == null)
                {
                    context.Comment("requestSet == null");
                    return a;
                }
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                context.Comment("QBFC13Lib.IBillQuery BillQuery = requestSet.AppendBillQueryRq();");
                QBFC13Lib.IBillQuery BillQuery = requestSet.AppendBillQueryRq();
                if (BillQuery == null)
                {
                    context.Comment("BillQuery returned null.");
                    return a;
                }
                BillQuery.IncludeLineItems.SetValue(true);
                context.Comment("Connect()");
                if (!Connect(context))
                {
                    context.Comment("!Connect()");
                    return a;
                }
                context.Comment("IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);");
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                if (responseSet == null)
                {
                    context.Comment("responseSet == null");
                    return a;
                }
                context.Comment("IResponse response = responseSet.ResponseList.GetAt(0);");
                IResponse response = responseSet.ResponseList.GetAt(0);
                if (response == null)
                {
                    context.Comment("response == null");
                    return a;
                }
                context.Comment("Disconnect()");
                Disconnect();
                if (response.StatusCode != 0)
                {
                    context.Comment("Failed.");
                    return a;
                }
                context.Comment("QBFC13Lib.IBillRetList billRetList = (IBillRetList)response.Detail;");
                QBFC13Lib.IBillRetList billRetList = (IBillRetList)response.Detail;
                if (billRetList == null)
                {
                    context.Comment("billRetList == null");
                    return a;
                }
                context.Comment("Found " + billRetList.Count + " bills.");
                Int32 countn = 0;
                for (Int32 i = 0; i < billRetList.Count; i++)
                {
                    try
                    {
                        countn = i + 1;
                        context.Comment("Importing " + countn + " of " + billRetList.Count + ".");
                        QBFC13Lib.IBillRet BillRet = billRetList.GetAt(i);
                        if (BillRet == null)
                            continue;
                        if (Tools.Dates.DateExists(date_cutoff))
                        {
                            if (BillRet.TxnDate == null)
                                continue;
                            if (BillRet.TxnDate.IsEmpty())
                                continue;
                            if (BillRet.TxnDate.GetValue() < date_cutoff)
                                continue;
                        }
                        ordhed o = ordhed.CreateNew((ContextRz)context, Enums.OrderType.Purchase);
                        //this happens in CreateNew
                        //context.Update(o.ISave();
                        String customer = "";
                        if (BillRet.VendorRef != null)
                        {
                            if (BillRet.VendorRef.FullName != null)
                            {
                                if (!BillRet.VendorRef.FullName.IsEmpty())
                                    customer = BillRet.VendorRef.FullName.GetValue();
                            }
                        }
                        customer = ParseTrimCompany(customer);
                        o.companyname = customer;
                        o.base_company_uid = company.TranslateNameToID(context, o.companyname);
                        if (BillRet.RefNumber != null)
                        {
                            if (!BillRet.RefNumber.IsEmpty())
                                o.ordernumber = BillRet.RefNumber.GetValue();
                        }
                        if (BillRet.Memo != null)
                        {
                            if (!BillRet.Memo.IsEmpty())
                                o.internalcomment = "Memo: " + BillRet.Memo.GetValue();
                        }
                        o.is_qbimport = true;
                        if (BillRet.TxnDate != null)
                        {
                            if (!BillRet.TxnDate.IsEmpty())
                                o.orderdate = BillRet.TxnDate.GetValue();
                        }
                        if (BillRet.RefNumber != null)
                        {
                            if (!BillRet.RefNumber.IsEmpty())
                                o.orderreference = BillRet.RefNumber.GetValue();
                        }
                        if (BillRet.TermsRef != null)
                        {
                            if (BillRet.TermsRef.FullName != null)
                            {
                                if (!BillRet.TermsRef.FullName.IsEmpty())
                                    o.terms = BillRet.TermsRef.FullName.GetValue();
                            }
                        }
                        if (BillRet.ExpenseLineRetList != null)
                        {
                            for (Int32 ii = 0; ii <= BillRet.ExpenseLineRetList.Count - 1; ii++)
                            {
                                try
                                {
                                    QBFC13Lib.IExpenseLineRet line = (QBFC13Lib.IExpenseLineRet)BillRet.ExpenseLineRetList.GetAt(ii);
                                    if (line == null)
                                        continue;
                                    orddet_line d = (orddet_line)o.GetNewDetail((ContextRz)context);
                                    if (line.Memo != null)
                                    {
                                        if (!line.Memo.IsEmpty())
                                            d.fullpartnumber = line.Memo.GetValue();
                                        d.alternatepart_04 = d.fullpartnumber;
                                    }
                                    d.description = d.fullpartnumber;
                                    if (!Tools.Strings.StrExt(d.fullpartnumber) && !Tools.Strings.StrExt(d.description))
                                    {
                                        context.Delete(d);
                                        continue;
                                    }
                                    if (Tools.Strings.StrCmp(d.fullpartnumber, "Subtotal"))
                                    {
                                        context.Delete(d);
                                        continue;
                                    }
                                    d.quantity = 1;
                                    if (d.quantity <= d.quantity_unpacked)
                                        d.Status = Enums.OrderLineStatus.Received;
                                    else
                                        d.Status = Enums.OrderLineStatus.Open;
                                    if (line.Amount != null)
                                    {
                                        if (!line.Amount.IsEmpty())
                                        {
                                            Double dd = line.Amount.GetValue();
                                            if (d.quantity > 0)
                                                d.unit_cost = dd / d.quantity;
                                        }
                                    }
                                    context.Update(d);
                                }
                                catch (Exception ee)
                                {
                                    context.Comment("Details Error: " + ee.Message);
                                    bad_count = bad_count + 1;
                                }
                            }
                        }
                        if (BillRet.ORItemLineRetList != null)
                        {
                            for (Int32 ii = 0; ii <= BillRet.ORItemLineRetList.Count - 1; ii++)
                            {
                                try
                                {
                                    QBFC13Lib.IORItemLineRet y = (QBFC13Lib.IORItemLineRet)BillRet.ORItemLineRetList.GetAt(ii);
                                    if (y == null)
                                        continue;
                                    QBFC13Lib.IItemLineRet line = y.ItemLineRet;
                                    if (line == null)
                                        continue;
                                    orddet_line d = (orddet_line)o.GetNewDetail((ContextRz)context);
                                    if (line.ItemRef != null)
                                    {
                                        if (line.ItemRef.FullName != null)
                                        {
                                            if (!line.ItemRef.FullName.IsEmpty())
                                                d.fullpartnumber = line.ItemRef.FullName.GetValue();
                                        }
                                        if (Tools.Strings.StrCmp(d.fullpartnumber, "777") || Tools.Strings.StrCmp(d.fullpartnumber, "cost of good sold"))
                                        {
                                            if (line.Desc != null)
                                            {
                                                if (!line.Desc.IsEmpty())
                                                    d.fullpartnumber = line.Desc.GetValue();
                                            }
                                        }
                                        d.alternatepart_04 = d.fullpartnumber;
                                    }
                                    if (line.Desc != null)
                                    {
                                        if (!line.Desc.IsEmpty())
                                            d.description = line.Desc.GetValue();
                                    }
                                    if (!Tools.Strings.StrExt(d.fullpartnumber) && !Tools.Strings.StrExt(d.description))
                                    {
                                        context.Delete(d);
                                        continue;
                                    }
                                    if (Tools.Strings.StrCmp(d.fullpartnumber, "Subtotal"))
                                    {
                                        context.Delete(d);
                                        continue;
                                    }
                                    if (line.Quantity != null)
                                    {
                                        if (!line.Quantity.IsEmpty())
                                            d.quantity = Convert.ToInt32(line.Quantity.GetValue());
                                    }
                                    if (line.Quantity != null)
                                    {
                                        if (!line.Quantity.IsEmpty())
                                            d.quantity = Convert.ToInt32(line.Quantity.GetValue());
                                    }
                                    else
                                        d.quantity = 1;
                                    if (d.quantity == 0)
                                        d.quantity = d.quantity_unpacked;
                                    if (d.quantity == 0)
                                    {
                                        d.quantity = 1;
                                        d.quantity_unpacked = 1;
                                    }
                                    if (d.quantity <= d.quantity_unpacked)
                                        d.Status = Enums.OrderLineStatus.Received;
                                    else
                                        d.Status = Enums.OrderLineStatus.Open;
                                    if (line.Amount != null)
                                    {
                                        if (!line.Amount.IsEmpty())
                                        {
                                            Double dd = line.Amount.GetValue();
                                            if (d.quantity > 0)
                                                d.unit_cost = dd / d.quantity;
                                        }
                                    }
                                    context.Update(d);
                                }
                                catch (Exception ee)
                                {
                                    context.Comment("Details Error: " + ee.Message);
                                    bad_count = bad_count + 1;
                                }
                            }
                        }
                        o.senttoqb = true;
                        context.Update(o);
                    }
                    catch (Exception ee)
                    {
                        context.Comment("PO Error: " + ee.Message);
                        bad_count = bad_count + 1;
                    }
                }
                if (bad_count > 0)
                    context.Comment("Rejected count: " + bad_count.ToString());
                return a;
            }
            catch (Exception ex)
            {
                if (bad_count > 0)
                    context.Comment("Rejected count: " + bad_count.ToString());
                context.TheLeader.Error("There was an error retreiving purchase order list: " + ex.Message);
                return a;
            }
        }
        public virtual ArrayList GetInvoiceOrderCollection(ContextRz context, DateTime date_cutoff)
        {
            ArrayList a = new ArrayList();
            long bad_count = 0;
            try
            {
                context.Comment("Gathering all QB's Invoice Orders...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                if (requestSet == null)
                    return a;
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IInvoiceQuery InvoiceQuery = requestSet.AppendInvoiceQueryRq();
                if (InvoiceQuery == null)
                {
                    context.Comment("InvoiceQuery returned null.");
                    return a;
                }
                InvoiceQuery.IncludeLineItems.SetValue(true);
                if (!Connect(context))
                    return a;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                if (responseSet == null)
                    return a;
                IResponse response = responseSet.ResponseList.GetAt(0);
                if (response == null)
                    return a;
                Disconnect();
                if (response.StatusCode != 0)
                {
                    context.Comment("Failed.");
                    return a;
                }
                QBFC13Lib.IInvoiceRetList invoiceRetList = (IInvoiceRetList)response.Detail;
                if (invoiceRetList == null)
                    return a;
                context.Comment("Found " + invoiceRetList.Count + " invoices.");
                Int32 countn = 0;
                for (Int32 i = 0; i < invoiceRetList.Count; i++)
                {
                    try
                    {
                        countn = i + 1;
                        context.Comment("Importing " + countn + " of " + invoiceRetList.Count + ".");
                        QBFC13Lib.IInvoiceRet InvoiceRet = invoiceRetList.GetAt(i);
                        if (InvoiceRet == null)
                            continue;
                        if (Tools.Dates.DateExists(date_cutoff))
                        {
                            if (InvoiceRet.TxnDate == null)
                                continue;
                            if (InvoiceRet.TxnDate.IsEmpty())
                                continue;
                            if (InvoiceRet.TxnDate.GetValue() < date_cutoff)
                                continue;
                        }
                        ordhed_invoice o = (ordhed_invoice)ordhed.CreateNew((ContextRz)context, Enums.OrderType.Invoice);
                        SetInvoiceOrderNumber(context, InvoiceRet, o);
                        context.Update(o);
                        String customer = "";
                        if (InvoiceRet.CustomerRef != null)
                        {
                            if (InvoiceRet.CustomerRef.FullName != null)
                            {
                                if (!InvoiceRet.CustomerRef.FullName.IsEmpty())
                                    customer = InvoiceRet.CustomerRef.FullName.GetValue();
                            }
                        }
                        customer = ParseTrimCompany(customer);
                        o.companyname = customer;
                        o.base_company_uid = company.TranslateNameToID(context, o.companyname);
                        if (InvoiceRet.RefNumber != null)
                        {
                            if (!InvoiceRet.RefNumber.IsEmpty())
                                o.ordernumber = InvoiceRet.RefNumber.GetValue();
                        }
                        if (InvoiceRet.PONumber != null)
                        {
                            if (!InvoiceRet.PONumber.IsEmpty())
                                o.orderreference = "PO#" + InvoiceRet.PONumber.GetValue();
                        }
                        if (InvoiceRet.Memo != null)
                        {
                            if (!InvoiceRet.Memo.IsEmpty())
                                o.internalcomment = "Memo: " + InvoiceRet.Memo.GetValue();
                        }
                        if (InvoiceRet.CustomerMsgRef != null)
                        {
                            if (!InvoiceRet.CustomerMsgRef.FullName.IsEmpty())
                            {
                                if (Tools.Strings.StrExt(o.internalcomment))
                                    o.internalcomment += "\r\n";
                                o.internalcomment += "CustMsg: " + InvoiceRet.CustomerMsgRef.FullName.GetValue();
                            }
                        }
                        o.is_qbimport = true;
                        if (InvoiceRet.TxnDate != null)
                        {
                            if (!InvoiceRet.TxnDate.IsEmpty())
                                o.orderdate = InvoiceRet.TxnDate.GetValue();
                        }
                        if (InvoiceRet.SalesRepRef != null)
                        {
                            if (InvoiceRet.SalesRepRef.FullName != null)
                            {
                                if (!InvoiceRet.SalesRepRef.FullName.IsEmpty())
                                    o.alternatetracking = InvoiceRet.SalesRepRef.FullName.GetValue();
                            }
                        }
                        o.agentname = o.alternatetracking;
                        if (Tools.Strings.StrExt(o.agentname))
                        {
                            n_user u = (n_user)context.QtO("n_user", "select * from n_user where user_initials = '" + o.agentname + "'");
                            if (u != null)
                            {
                                o.agentname = u.name;
                                o.base_mc_user_uid = u.unique_id;
                            }
                        }
                        if (InvoiceRet.BillAddress != null)
                        {
                            if (InvoiceRet.BillAddress.Addr1 != null)
                            {
                                if (!InvoiceRet.BillAddress.Addr1.IsEmpty())
                                {
                                    o.billingaddress = InvoiceRet.BillAddress.Addr1.GetValue() + "\r\n";
                                    o.billingname = InvoiceRet.BillAddress.Addr1.GetValue();
                                }
                            }
                            if (InvoiceRet.BillAddress.Addr2 != null)
                            {
                                if (!InvoiceRet.BillAddress.Addr2.IsEmpty())
                                    o.billingaddress += InvoiceRet.BillAddress.Addr2.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.BillAddress.Addr3 != null)
                            {
                                if (!InvoiceRet.BillAddress.Addr3.IsEmpty())
                                    o.billingaddress += InvoiceRet.BillAddress.Addr3.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.BillAddress.City != null)
                            {
                                if (!InvoiceRet.BillAddress.City.IsEmpty())
                                    o.billingaddress += InvoiceRet.BillAddress.City.GetValue() + ", ";
                            }
                            if (InvoiceRet.BillAddress.State != null)
                            {
                                if (!InvoiceRet.BillAddress.State.IsEmpty())
                                    o.billingaddress += InvoiceRet.BillAddress.State.GetValue() + "  ";
                            }
                            if (InvoiceRet.BillAddress.PostalCode != null)
                            {
                                if (!InvoiceRet.BillAddress.PostalCode.IsEmpty())
                                    o.billingaddress += InvoiceRet.BillAddress.PostalCode.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.BillAddress.Country != null)
                            {
                                if (!InvoiceRet.BillAddress.Country.IsEmpty())
                                    o.billingaddress += InvoiceRet.BillAddress.Country.GetValue();
                            }
                        }
                        if (InvoiceRet.ShipAddress != null)
                        {
                            if (InvoiceRet.ShipAddress.Addr1 != null)
                            {
                                if (!InvoiceRet.ShipAddress.Addr1.IsEmpty())
                                {
                                    o.shippingaddress = InvoiceRet.ShipAddress.Addr1.GetValue() + "\r\n";
                                    o.shippingname = InvoiceRet.ShipAddress.Addr1.GetValue();
                                }
                            }
                            if (InvoiceRet.ShipAddress.Addr2 != null)
                            {
                                if (!InvoiceRet.ShipAddress.Addr2.IsEmpty())
                                    o.shippingaddress += InvoiceRet.ShipAddress.Addr2.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.ShipAddress.Addr3 != null)
                            {
                                if (!InvoiceRet.ShipAddress.Addr3.IsEmpty())
                                    o.shippingaddress += InvoiceRet.ShipAddress.Addr3.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.ShipAddress.City != null)
                            {
                                if (!InvoiceRet.ShipAddress.City.IsEmpty())
                                    o.shippingaddress += InvoiceRet.ShipAddress.City.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.ShipAddress.State != null)
                            {
                                if (!InvoiceRet.ShipAddress.State.IsEmpty())
                                    o.shippingaddress += InvoiceRet.ShipAddress.State.GetValue() + "\r\n";
                            }
                            if (InvoiceRet.ShipAddress.PostalCode != null)
                            {
                                if (!InvoiceRet.ShipAddress.PostalCode.IsEmpty())
                                    o.shippingaddress += InvoiceRet.ShipAddress.PostalCode.GetValue() + "\r\n";
                            }
                        }
                        if (InvoiceRet.TermsRef != null)
                        {
                            if (!InvoiceRet.TermsRef.FullName.IsEmpty())
                                o.terms += InvoiceRet.TermsRef.FullName.GetValue();
                        }
                        if (InvoiceRet.ShipMethodRef != null)
                        {
                            if (!InvoiceRet.ShipMethodRef.FullName.IsEmpty())
                                o.shipvia += InvoiceRet.ShipMethodRef.FullName.GetValue();
                        }
                        if (InvoiceRet.IsPaid != null)
                        {
                            if (!InvoiceRet.IsPaid.IsEmpty())
                            {
                                //to avoid the transaction requirement
                                o.ispaid_Set(context, InvoiceRet.IsPaid.GetValue());
                            }
                        }
                        for (Int32 ii = 0; ii <= InvoiceRet.ORInvoiceLineRetList.Count - 1; ii++)
                        {
                            try
                            {
                                QBFC13Lib.IORInvoiceLineRet y = (QBFC13Lib.IORInvoiceLineRet)InvoiceRet.ORInvoiceLineRetList.GetAt(ii);
                                if (y == null)
                                    continue;
                                QBFC13Lib.IInvoiceLineRet line = y.InvoiceLineRet;
                                if (line == null)
                                    continue;
                                orddet_line d = (orddet_line)o.GetNewDetail((ContextRz)context);
                                if (line.ItemRef != null)
                                {
                                    if (line.ItemRef.FullName != null)
                                    {
                                        if (!line.ItemRef.FullName.IsEmpty())
                                            d.fullpartnumber = line.ItemRef.FullName.GetValue();
                                    }
                                    if (Tools.Strings.StrCmp(d.fullpartnumber, "777") || Tools.Strings.StrCmp(d.fullpartnumber, "cost of good sold"))
                                    {
                                        if (line.Desc != null)
                                        {
                                            if (!line.Desc.IsEmpty())
                                                d.fullpartnumber = line.Desc.GetValue();
                                        }
                                    }
                                    d.alternatepart_04 = d.fullpartnumber;
                                }
                                if (line.Desc != null)
                                {
                                    if (!line.Desc.IsEmpty())
                                        d.description = line.Desc.GetValue();
                                }
                                if (!Tools.Strings.StrExt(d.fullpartnumber) && !Tools.Strings.StrExt(d.description))
                                {
                                    context.Delete(d);
                                    continue;
                                }
                                if (Tools.Strings.StrCmp(d.fullpartnumber, "Subtotal"))
                                {
                                    context.Delete(d);
                                    continue;
                                }
                                if (line.Quantity != null)
                                {
                                    if (!line.Quantity.IsEmpty())
                                        d.quantity = Convert.ToInt32(line.Quantity.GetValue());
                                }
                                else
                                    d.quantity = 1;
                                d.quantity_packed = d.quantity;
                                if (d.quantity == d.quantity_packed)
                                    d.Status = Enums.OrderLineStatus.Shipped;
                                if (line.Amount != null)
                                {
                                    if (!line.Amount.IsEmpty())
                                    {
                                        Double dd = line.Amount.GetValue();
                                        if (d.quantity > 0)
                                            d.unit_price = dd / d.quantity;
                                    }
                                }
                                context.Update(d);
                            }
                            catch { bad_count = bad_count + 1; }
                        }
                        orddet_line det = (orddet_line)o.GetNewDetail((ContextRz)context);
                        if (InvoiceRet.SalesTaxTotal != null)
                        {
                            if (!InvoiceRet.SalesTaxTotal.IsEmpty())
                            {
                                det.fullpartnumber = "Sales Tax Total";
                                det.description = "QuickBooks Sales Tax Total";
                                det.quantity = 1;
                                det.quantity_packed = 1;
                                det.unit_price = InvoiceRet.SalesTaxTotal.GetValue();
                                det.Status = Enums.OrderLineStatus.Shipped;
                                context.Update(det);
                            }
                        }
                        //o.GatherDetails();
                        Double payamount = 0;
                        if (InvoiceRet.AppliedAmount != null)
                        {
                            if (!InvoiceRet.AppliedAmount.IsEmpty())
                                payamount = InvoiceRet.AppliedAmount.GetValue() * -1;
                            if (payamount > 0)
                            {
                                try { o.Inserting(context); }
                                catch { }
                                checkpayment cp = checkpayment.New(context);
                                cp.base_company_uid = o.base_company_uid;
                                cp.base_ordhed_uid = o.unique_id;
                                cp.companyname = o.companyname;
                                cp.transamount = payamount;
                                cp.transtype = "Payment";
                                cp.senttoqb = true;
                                context.Insert(cp);
                            }
                        }
                        o.senttoqb = true;
                        context.Update(o);
                    }
                    catch { bad_count = bad_count + 1; }
                }
                if (bad_count > 0)
                    context.Comment("Rejected count: " + bad_count.ToString());
                return a;
            }
            catch (Exception ex)
            {
                if (bad_count > 0)
                    context.Comment("Rejected count: " + bad_count.ToString());
                context.TheLeader.Error("There was an error retreiving invoice order list: " + ex.Message);
                return a;
            }
        }
        public virtual ArrayList GetEstimateCollection(ContextNM context)
        {
            ArrayList a = new ArrayList();

            context.TheLeader.Error("reorg");
            return a;


        }
        public virtual ArrayList GetCreditMemoCollection(ContextNM context)
        {
            ArrayList a = new ArrayList();

            context.TheLeader.Error("reorg");
            return a;


        }
        protected virtual void AdjustQBBillingAddress(company c)
        {
            //do nothing
        }
        protected virtual void AdjustQBShippingAddress(company c)
        {
            //do nothing
        }
        protected virtual void SetQBCompanyAgent(company c, NewMethod.n_user u)
        {
            //do nothing
        }
        protected virtual void SetQBVendorAgent(company c)
        {
            //do nothing
        }
        protected virtual void SetSalesOrderNumber(ContextRz context, QBFC13Lib.ISalesOrderRet SalesRet, ordhed o)
        {
            //do nothing
        }
        protected virtual void SetPurchaseOrderNumber(ContextRz context, QBFC13Lib.IPurchaseOrderRet PurchaseRet, ordhed o)
        {
            //do nothing
        }
        protected virtual void SetInvoiceOrderNumber(ContextRz context, QBFC13Lib.IInvoiceRet InvoiceRet, Rz5.ordhed o)
        {
            //do nothing
        }

        public bool CompanyExists(ContextRz context, company c, CompanySelectionType type)
        {
            bool exists = false;
            //if (string.IsNullOrEmpty(c.qb_company_ListID))//OK, it's possible, there is no ListID, in which case, search by name for inactive account.
            //    return exists;
            try
            {
                //if both the id types are null, then no link exists.
                if (string.IsNullOrEmpty(c.qb_company_ListID) && string.IsNullOrEmpty(c.qb_company_ListID_vendor))
                    return false;
                GetQuickbooksCompanyByID(context, c, type);
                switch (type)
                {
                    case CompanySelectionType.Customer:
                        {

                            if (TheCustomer != null)//This is a verified real company in QB 
                            {
                                //Is the customer inactive?  If so, offer to reactive?
                                if (TheCustomer.IsActive.GetValue() == false)
                                {
                                    if (context.Leader.AskYesNo("This Customer account is inactive, would you like to reactivate?"))
                                    {
                                        ReactivateCustomer(context, TheCustomer);
                                    }
                                }

                                exists = true;
                            }

                            break;
                        }
                    case CompanySelectionType.Vendor:
                        {
                            if (TheVendor != null)//This is a verified real company in QB 
                            {
                                //Is the vendor inactive?  If so, offer to reactive?
                                if (TheVendor.IsActive.GetValue() == false)
                                {
                                    if (context.Leader.AskYesNo("This Vendor account is inactive, would you like to reactivate?"))
                                    {
                                        ReactivateVendor(context, TheVendor);
                                    }
                                }

                                exists = true;
                            }
                            break;
                        }


                }
                //IF we're here, none of the above have returnd, that means neither found a match based on this QB id.
                //That might mean it's been deleted, or something else is wrong, removing the qbid relationship from Rz quietly
                //so it can be re-associated
                //if (!exists)
                //    RemoveQbRelationshipCompany(context, c);
                return exists;

            }
            catch (Exception ex)
            {
                Disconnect();
                context.TheLeader.Tell("An error occurred while checking if " + c.companyname + " exists in Quickbooks as a customer: " + ex.Message);
                return false;
            }
        }

        private void ReactivateCompany(ContextRz context, object o, CompanySelectionType type)
        {
            try
            {
                switch (type)
                {
                    case CompanySelectionType.Customer:
                        {
                            ReactivateCustomer(context, (ICustomerRet)o);
                            break;
                        }
                    case CompanySelectionType.Vendor:
                        {
                            ReactivateVendor(context, (IVendorRet)o);
                            break;
                        }
                }
            }
            catch (Exception ex)
            { }

        }
        private void ReactivateCustomer(ContextRz context, ICustomerRet existingCustomer)
        {
            //Set the Active Boolean to true;
            //Update the company in QB
            if (!Connect(context))
                throw new Exception("Unable to establish QBFC connection");
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.ICustomerMod CustomerMod = requestSet.AppendCustomerModRq();
            CustomerMod.ListID.SetValue(existingCustomer.ListID.GetValue());
            CustomerMod.EditSequence.SetValue(Tools.Strings.Left(existingCustomer.EditSequence.GetValue(), Convert.ToInt32(CustomerMod.EditSequence.GetMaxLength())));
            CustomerMod.IsActive.SetValue(true);
            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();

        }
        private void ReactivateVendor(ContextRz context, IVendorRet existingVendor)
        {
            ///Set the Active Boolean to true;
            //Update the company in QB
            if (!Connect(context))
                throw new Exception("Unable to establish QBFC connection");
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IVendorMod VendorMod = requestSet.AppendVendorModRq();
            VendorMod.ListID.SetValue(existingVendor.ListID.GetValue());
            VendorMod.EditSequence.SetValue(Tools.Strings.Left(existingVendor.EditSequence.GetValue(), Convert.ToInt32(VendorMod.EditSequence.GetMaxLength())));
            VendorMod.IsActive.SetValue(true);
            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();

        }
        protected bool GetQuickbooksCompanyByID(ContextRz context, company c, CompanySelectionType type)
        {
            switch (type)
            {
                case CompanySelectionType.Customer:
                    {
                        TheCustomer = GetQuickbooksCustomerByID(context, c.qb_company_ListID);
                        return TheCustomer != null;
                    }
                case CompanySelectionType.Vendor:
                    {
                        TheVendor = GetQuickbooksVendorByID(context, c.qb_company_ListID_vendor);
                        return TheVendor != null;
                    }
            }
            return false;

        }
        protected ICustomerRet GetQuickbooksCustomerByID(ContextRz context, string qbListID)
        {
            //Disconnect();
            if (string.IsNullOrEmpty(qbListID))
                return null;
            ICustomerRet companyRet = null;
            try
            {
                IMsgSetRequest requestMsgSet;
                IMsgSetResponse responseMsgSet;
                if (!Connect(context))
                    return null;
                requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;
                ICustomerQuery CustomerQueryRq = requestMsgSet.AppendCustomerQueryRq();
                CustomerQueryRq.ORCustomerListQuery.ListIDList.Add(qbListID);
                //Fix for wierd issue related to min "TimeModified" date
                //custQ.ORCustomerListQuery.CustomerListFilter.FromModifiedDate.SetValue(DateTime.Parse("1/1/1971"), true);              
                responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                Disconnect();
                int statusCode = response.StatusCode;
                string statusMessage = response.StatusMessage;
                switch (response.StatusCode)
                {
                    case 0://Successfully run
                        {
                            ICustomerRetList custRetList = (ICustomerRetList)response.Detail;
                            Disconnect();
                            if (custRetList != null)
                                for (Int32 i = 0; i < custRetList.Count; i++)
                                {
                                    ICustomerRet q = custRetList.GetAt(i);
                                    if (q != null)
                                    {
                                        string name = q.FullName.GetValue();
                                        string id = q.ListID.GetValue();
                                        if (id == qbListID)
                                            return q;
                                    }
                                }
                            break;
                        }

                    case 1://No Match
                        {
                            break;
                        }
                }



                return companyRet;

            }
            catch (Exception ex)
            {
                Disconnect();
                string error = (ex.Message.ToString() + "\nStack Trace: \n" + ex.StackTrace + "\nExiting the application");
                throw new Exception(error);

            }

        }
        protected IVendorRet GetQuickbooksVendorByID(ContextRz context, string qbListID)
        {
            //Disconnect();
            if (string.IsNullOrEmpty(qbListID))
                return null;
            IVendorRet companyRet = null;
            try
            {
                IMsgSetRequest requestMsgSet;
                IMsgSetResponse responseMsgSet;
                if (!Connect(context))
                    return null;
                requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;
                IVendorQuery CustomerQueryRq = requestMsgSet.AppendVendorQueryRq();
                CustomerQueryRq.ORVendorListQuery.ListIDList.Add(qbListID);


                //Fix for wierd issue related to min "TimeModified" date
                //custQ.ORCustomerListQuery.CustomerListFilter.FromModifiedDate.SetValue(DateTime.Parse("1/1/1971"), true);

                //Set field value for ListID                    
                //custQ.ORCustomerListQuery.CustomerListFilter.ClassFilter.ORClassFilter.ListIDList.Add(qbListID);
                responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                int statusCode = response.StatusCode;
                string statusMessage = response.StatusMessage;
                switch (response.StatusCode)
                {
                    case 0://Successfully run
                        {
                            IVendorRetList vendRetList = (IVendorRetList)response.Detail;
                            Disconnect();
                            if (vendRetList != null)
                                for (Int32 i = 0; i < vendRetList.Count; i++)
                                {
                                    IVendorRet q = vendRetList.GetAt(i);
                                    if (q != null)
                                    {
                                        string name = q.CompanyName.GetValue();
                                        string id = q.ListID.GetValue();
                                        if (id == qbListID)
                                            return q;
                                    }
                                }
                            break;
                        }

                    case 1://No Match
                        {
                            break;
                        }
                }
                return companyRet;

            }
            catch (Exception ex)
            {
                Disconnect();
                string error = (ex.Message.ToString() + "\nStack Trace: \n" + ex.StackTrace + "\nExiting the application");
                throw new Exception(error);

            }

        }
        private IVendorRet SearchQBVendorByName(ContextRz context, company c)
        {
            if (string.IsNullOrEmpty(c.companyname))
                return null;
            IVendorRet companyRet = null;
            try
            {
                IMsgSetRequest requestMsgSet;
                IMsgSetResponse responseMsgSet;
                if (!Connect(context))
                    return null;
                requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;
                IVendorQuery vendQ = requestMsgSet.AppendVendorQueryRq();


                //Fix for wierd issue related to min "TimeModified" date
                vendQ.ORVendorListQuery.VendorListFilter.FromModifiedDate.SetValue(DateTime.Parse("1/1/1971"), true);
                //Set field value for MatchCriterion
                ENMatchCriterion mc = ENMatchCriterion.mcStartsWith;
                vendQ.ORVendorListQuery.VendorListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(mc);

                //Set field value for Name , based on match Criterion
                vendQ.ORVendorListQuery.VendorListFilter.ORNameFilter.NameFilter.Name.SetValue(c.companyname.Substring(0, GetCompanyNameLength(c, mc)));



                responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                Disconnect();

                string result = response.StatusMessage;

                if (response.StatusCode == 0)
                {
                    IVendorRetList vendorRetList = (IVendorRetList)response.Detail;
                    if (vendorRetList == null)
                        return null;
                    companyRet = (IVendorRet)AskUserForQuickbooksCompany(context, vendorRetList, CompanySelectionType.Vendor, c);
                    return companyRet;
                }

                else if (response.StatusCode == 1)//A query request did not find a matching object in QuickBooks.
                {
                    //Don't want to automatically add a company.  Going to rely on the form in the beginning.
                    //if (context.Leader.AskYesNo("No similar match to '" + qbCompanyName + "' was found.  Would you like to add this company?"))
                    //{
                    //    context.Leader.Tell("Add new company here");
                    //    return null;//Change this to the add compny method.
                    //}


                }
                return null;

            }
            catch (Exception ex)
            {
                Disconnect();
                string error = (ex.Message.ToString() + "\nStack Trace: \n" + ex.StackTrace + "\nExiting the application");
                throw new Exception(error);

            }
        }
        public ICustomerRet SearchQBCustomerByName(ContextRz context, company c)
        {

            if (string.IsNullOrEmpty(c.companyname))
                return null;
            ICustomerRet companyRet = null;
            try
            {
                IMsgSetRequest requestMsgSet;
                IMsgSetResponse responseMsgSet;
                if (!Connect(context))
                    return null;
                requestMsgSet = GetLatestMsgSetRequest(context, sessionManager);
                requestMsgSet.Attributes.OnError = ENRqOnError.roeStop;
                ICustomerQuery custQ = requestMsgSet.AppendCustomerQueryRq();


                //Fix for wierd issue related to min "TimeModified" date
                custQ.ORCustomerListQuery.CustomerListFilter.FromModifiedDate.SetValue(DateTime.Parse("1/1/1971"), true);

                //Set field value for MatchCriterion
                ENMatchCriterion mc = ENMatchCriterion.mcStartsWith;
                custQ.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameFilter.MatchCriterion.SetValue(mc);

                //Set field value for Name , based on match Criterion
                custQ.ORCustomerListQuery.CustomerListFilter.ORNameFilter.NameFilter.Name.SetValue(c.companyname.Substring(0, GetCompanyNameLength(c, mc)));



                responseMsgSet = sessionManager.DoRequests(requestMsgSet);
                IResponse response = responseMsgSet.ResponseList.GetAt(0);
                Disconnect();

                string result = response.StatusMessage;

                if (response.StatusCode == 0)
                {
                    ICustomerRetList customerRetList = (ICustomerRetList)response.Detail;
                    if (customerRetList == null)
                        return null;
                    companyRet = (ICustomerRet)AskUserForQuickbooksCompany(context, customerRetList, CompanySelectionType.Customer, c);
                    return companyRet;
                }

                else if (response.StatusCode == 1)//A query request did not find a matching object in QuickBooks.
                {
                    //Don't want to automatically add a company.  Going to rely on the form in the beginning.
                    //if (context.Leader.AskYesNo("No similar match to '" + qbCompanyName + "' was found.  Would you like to add this company?"))
                    //{
                    //    context.Leader.Tell("Add new company here");
                    //    return null;//Change this to the add compny method.
                    //}


                }
                return null;

            }
            catch (Exception ex)
            {
                Disconnect();
                string error = (ex.Message.ToString() + "\nStack Trace: \n" + ex.StackTrace + "\nExiting the application");
                throw new Exception(error);

            }

        }

        private int GetCompanyNameLength(company c, ENMatchCriterion matchCriterion)
        {
            //If we're passign a company with more than 5 letters in name, let's only check 1st five letters to also find close matches that may be spoelled a little different.
            //I used to always only check the 1st 5 letters, which broke with "SVT" because only 3.
            //Since the 5 letter check worked pretty well before, we're going to allow the short stuff, while still constraining to 1st 5  digits if length is at least 5
            int companyNameLength = c.companyname.Length;
            switch (matchCriterion)
            {
                case ENMatchCriterion.mcStartsWith:
                    {

                        if (companyNameLength >= 5)
                            companyNameLength = 5;
                        break;
                    }
            }

            return companyNameLength;
        }

        private ICustomerRet AskUserForQuickbooksCustomer(ContextRz context, ICustomerRetList custRetList, company c)
        {
            ICustomerRet ret = null;
            Dictionary<string, object> matchedQbCustomers = new Dictionary<string, object>();
            Dictionary<string, string> matchedQbCustomersID = new Dictionary<string, string>();
            for (Int32 i = 0; i < custRetList.Count; i++)
            {
                ICustomerRet q = custRetList.GetAt(i);
                if (q != null)
                {
                    if (q.CompanyName != null)
                    {
                        string name = q.FullName.GetValue();
                        string id = q.ListID.GetValue();
                        matchedQbCustomers.Add(name, q);
                        matchedQbCustomersID.Add(name, id);
                    }
                }
            }
            if (matchedQbCustomers.Count > 0)
            {
                List<string> choices = new List<string>(matchedQbCustomers.Keys);
                string qbCustFullName = context.TheLeader.ChooseOneString(context, "Please match the customer: '" + c.companyname + "'", choices);
                if (!string.IsNullOrEmpty(qbCustFullName))
                {
                    ret = (ICustomerRet)matchedQbCustomers[qbCustFullName];
                    string id = ret.ListID.GetValue();
                    string name = ret.FullName.GetValue();
                    // Associate this company now  
                    SetQbRelationshipCustomer(context, ret, c);
                    //c.qb_company_ListID = id;
                    //c.Update(context);
                }

            }
            return ret;
        }
        private IVendorRet AskUserForQuickbooksVendor(ContextRz context, IVendorRetList vendRetList, company c)
        {
            IVendorRet ret = null;
            Dictionary<string, object> matchedQbVendors = new Dictionary<string, object>();
            Dictionary<string, string> matchedQbVendorID = new Dictionary<string, string>();
            for (Int32 i = 0; i < vendRetList.Count; i++)
            {
                IVendorRet q = vendRetList.GetAt(i);
                if (q != null)
                {
                    if (q.CompanyName != null)
                    {
                        string name = q.CompanyName.GetValue();
                        string id = q.ListID.GetValue();
                        matchedQbVendors.Add(name, q);
                        matchedQbVendorID.Add(name, id);
                    }

                }
            }
            if (matchedQbVendors.Count > 0)
            {
                List<string> choices = new List<string>(matchedQbVendors.Keys);
                string qbVendFullName = context.TheLeader.ChooseOneString(context, "Please match the vendor: '" + c.companyname + "'", choices);
                if (!string.IsNullOrEmpty(qbVendFullName))
                {

                    ret = (IVendorRet)matchedQbVendors[qbVendFullName];
                    string id = ret.ListID.GetValue();
                    string name = ret.Name.GetValue();
                    // Associate this company now   
                    SetQbRelationshipVendor(context, ret, c);
                    //c.qb_company_ListID = id;
                    //c.Update(context);
                }

            }
            return ret;
        }



        private IItemNonInventoryRet AskUserForQuickbooksNonInvItem(ContextRz context, IItemNonInventoryRetList itemRetList, orddet_line l, bool subItem = false)
        {
            IItemNonInventoryRet ret = null;
            Dictionary<string, object> matchedQbItems = new Dictionary<string, object>();
            string message = "Choose best match for:  ";
            if (!subItem)
                message += l.fullpartnumber.ToUpper();
            else
                message += l.manufacturer.ToUpper();
            message += "(Click Cancel to add to QB)";

            for (Int32 i = 0; i < itemRetList.Count; i++)
            {
                IItemNonInventoryRet item = itemRetList.GetAt(i);
                if (item != null)
                {

                    string name = item.FullName.GetValue();
                    string id = item.ListID.GetValue();
                    if (subItem)
                    {
                        if (CheckIsSubItem(name))
                            matchedQbItems.Add(name, item);
                    }
                    else
                        matchedQbItems.Add(name, item);

                }
            }

            if (matchedQbItems.Count > 0)
            {
                List<string> choices = new List<string>(matchedQbItems.Keys);
                string qbItemName = context.TheLeader.ChooseOneString(context, message, choices);
                if (!string.IsNullOrEmpty(qbItemName))
                {
                    ret = (IItemNonInventoryRet)matchedQbItems[qbItemName];
                    string id = ret.ListID.GetValue();
                    string name = ret.FullName.GetValue();
                    // Associate this company now  
                    if (subItem)
                        l.qb_line_subitem_ListID = id;
                    else
                        l.qb_line_ListID = id;
                    l.Update(context);
                }

            }
            return ret;
        }

        private IItemServiceRet AskUserForQuickbooksServiceItem(ContextRz context, IItemServiceRetList itemRetList, orddet_line l, bool subItem = false)
        {
            IItemServiceRet ret = null;
            Dictionary<string, object> matchedQbItems = new Dictionary<string, object>();
            string message = "Choose best match for:  ";
            if (!subItem)
                message += l.fullpartnumber.ToUpper();
            else
                message += l.manufacturer.ToUpper();
            message += "(Click Cancel to add to QB)";

            for (Int32 i = 0; i < itemRetList.Count; i++)
            {
                IItemServiceRet item = itemRetList.GetAt(i);
                //We need to update the service line related to this dummy orddet_line               
                if (item != null)
                {

                    string name = item.FullName.GetValue();
                    string id = item.ListID.GetValue();
                    if (subItem)
                    {
                        if (CheckIsSubItem(name))
                            matchedQbItems.Add(name, item);
                    }
                    else
                        matchedQbItems.Add(name, item);

                }
            }

            if (matchedQbItems.Count > 0)
            {

                service_line sl = service_line.GetById(context, l.unique_id);
                if (sl == null)
                    throw new Exception("Could not locat a service line with id: " + l.unique_id);

                List<string> choices = new List<string>(matchedQbItems.Keys);
                string qbItemName = context.TheLeader.ChooseOneString(context, message, choices);
                if (!string.IsNullOrEmpty(qbItemName))
                {
                    ret = (IItemServiceRet)matchedQbItems[qbItemName];
                    string id = ret.ListID.GetValue();
                    string name = ret.FullName.GetValue();
                    sl.qb_line_ListID = id;
                    sl.Update(context);
                }

            }
            return ret;
        }


        private object AskUserForQuickbooksCompany(ContextRz context, object retList, CompanySelectionType type, company c)
        {

            switch (type)
            {
                case CompanySelectionType.Customer:
                    return AskUserForQuickbooksCustomer(context, (ICustomerRetList)retList, c);
                case CompanySelectionType.Vendor:
                    return AskUserForQuickbooksVendor(context, (IVendorRetList)retList, c);
                default:
                    return null;
            }

        }
        public bool VendorExists(ContextRz context, String strVendorName)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IVendorQuery q = requestSet.AppendVendorQueryRq();
                //q.ORVendorListQuery.VendorListFilter.ORNameFilter.NameFilter.Name.SetValue(strVendorName);
                q.ORVendorListQuery.FullNameList.Add(strVendorName);
                if (!Connect(context))
                    return false;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                return (response.StatusCode == 0);
            }
            catch (Exception ex)
            {
                context.TheLeader.Tell("An error occurred while checking if " + strVendorName + " exists in Quickbooks as a vendor: " + ex.Message);
                return false;
            }
        }
        public String FilterCustomerName(ContextRz context, String strName)
        {
            return Tools.Strings.ParseDelimit(strName, "[", 1).Trim();
        }
        public String FilterVendorName(ContextRz context, String strName)
        {
            return FilterCustomerName(context, strName).Trim() + " " + VendorSuffix(context).Trim();
        }
        public void MakeShipViaExist(ContextRz context, String strShipVia)
        {
            if (!Tools.Strings.StrExt(strShipVia))
                return;

            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IShipMethodAdd ShipAdd = requestSet.AppendShipMethodAddRq();
            ShipAdd.Name.SetValue(Tools.Strings.Left(IdentifierFilter(strShipVia), Convert.ToInt32(ShipAdd.Name.GetMaxLength())));
            ShipAdd.IsActive.SetValue(true);
            if (!Connect(context))
                throw new Exception("Connection failed adding ShipVia");

            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            //IShipMethodRet shipRet = (IShipMethodRet)response.Detail;
            //string shipID = shipRet.ListID.GetValue();
            if (response.StatusCode == 0)
            {
                context.TheLeader.Comment("The shipping method '" + strShipVia + "' was added.");
                return;
            }
            else if (response.StatusCode == 3100)
            {
                context.TheLeader.Comment("The shipping method '" + strShipVia + "' already exists.");
                return;
            }
            else
                throw new Exception("The shipping method '" + strShipVia + "' could not be added: " + response.StatusMessage);
        }
        public void MakeTermsExist(ContextRz context, String terms)
        {
            if (!Tools.Strings.StrExt(terms))
                return;

            if (TermsExists(context, terms))
                return;

            context.TheLeaderRz.QBCreateTerms(context, terms);
        }
        public void CreateTerms(ContextRz context, String terms, int dueDays, Double discountPercent, int discountDays)
        {
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.IStandardTermsAdd TermsAdd = requestSet.AppendStandardTermsAddRq();
            TermsAdd.Name.SetValue(Tools.Strings.Left(IdentifierFilter(terms), Convert.ToInt32(TermsAdd.Name.GetMaxLength())));
            TermsAdd.IsActive.SetValue(true);
            TermsAdd.StdDueDays.SetValue(dueDays);
            TermsAdd.DiscountPct.SetValue(discountPercent);
            TermsAdd.StdDiscountDays.SetValue(discountDays);
            if (!Connect(context))
                throw new Exception("Connection failed on adding terms " + terms);

            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            if (response.StatusCode == 0)
            {
                context.TheLeader.Comment("The terms '" + terms + "' was added.");
                return;
            }
            else if (response.StatusCode == 3100)
            {
                context.TheLeader.Comment("The terms '" + terms + "' already exists.");
                return;
            }
            else
                throw new Exception("The terms '" + terms + "' could not be added: " + response.StatusMessage);
        }
        public void MakeCustRefMsgExist(ContextRz context, String tracking)
        {
            if (!Tools.Strings.StrExt(tracking))
                return;
            if (CustRefMsgExists(context, tracking))
                return;

            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.ICustomerMsgAdd MsgAdd = requestSet.AppendCustomerMsgAddRq();
            MsgAdd.Name.SetValue(Tools.Strings.Left(tracking, Convert.ToInt32(MsgAdd.Name.GetMaxLength())));
            MsgAdd.IsActive.SetValue(true);
            if (!Connect(context))
                throw new Exception("Connection failed making customer ref message");

            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            if (response.StatusCode == 0)
            {
                context.TheLeader.Comment("The customer message '" + tracking + "' was added.");
                return;
            }
            else if (response.StatusCode == 3100)
            {
                context.TheLeader.Comment("The customer message '" + tracking + "' already exists.");
                return;
            }
            else
                throw new Exception("The customer message '" + tracking + "' could not be added: " + response.StatusMessage);
        }
        public bool TermsExists(ContextRz context, String strTerms)
        {
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            IStandardTermsQuery q = requestSet.AppendStandardTermsQueryRq();
            q.ORListQuery.FullNameList.Add(IdentifierFilter(strTerms));
            if (!Connect(context))
                return false;
            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            //IStandardTermsRet ret = (IStandardTermsRet)response.Detail;
            //string id = ret.ListID.GetValue();
            Disconnect();
            return (response.StatusCode == 0);
        }
        public bool CustRefMsgExists(ContextRz context, String tracking)
        {
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            ICustomerMsgQuery q = requestSet.AppendCustomerMsgQueryRq();
            q.ORListQuery.FullNameList.Add(tracking);
            if (!Connect(context))
                return false;
            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            return (response.StatusCode == 0);
        }
        public String GetVersionInfo(ContextRz context, ref Double d)
        {
            if (qbXMLMajorVer(context) > 0)
                return qbXMLMajorVer(context).ToString() + "." + qbXMLMinorVer(context).ToString();
            if (!Connect(context))
                return null;
            String s = "";
            d = QBFCLatestVersion(context, sessionManager, ref s);
            Disconnect();
            return "Latest version: " + d.ToString() + "\r\n\r\n" + s;
        }
        public IMsgSetRequest GetLatestMsgSetRequest(ContextRz context, QBSessionManager sessionManager)
        {
            try
            {
                IMsgSetRequest requestMsgSet;
                if (qbXMLMajorVer(context) > 0)
                {
                    requestMsgSet = sessionManager.CreateMsgSetRequest(VersionName(context), qbXMLMajorVer(context), qbXMLMinorVer(context));
                    return requestMsgSet;
                }
                if (!Connect(context))
                    return null;
                // IY: Find and adapt to supported version of QuickBooks
                double supportedVersion = QBFCLatestVersion(context, sessionManager);
                // MessageBox.Show("supportedVersion = " + supportedVersion.ToString());
                if (supportedVersion >= 4.0)
                {
                    qbXMLMajorVerSet(context, 4);
                    qbXMLMinorVerSet(context, 0);
                }
                else if (supportedVersion >= 3.0)
                {
                    qbXMLMajorVerSet(context, 3);
                    qbXMLMinorVerSet(context, 0);
                }
                else if (supportedVersion >= 2.0)
                {
                    qbXMLMajorVerSet(context, 2);
                    qbXMLMinorVerSet(context, 0);
                }
                else if (supportedVersion >= 1.1)
                {
                    qbXMLMajorVerSet(context, 1);
                    qbXMLMinorVerSet(context, 1);
                }
                else
                {
                    qbXMLMajorVerSet(context, 1);
                    qbXMLMinorVerSet(context, 0);
                    System.Windows.Forms.MessageBox.Show("It seems that you are running QuickBooks 2002 Release 1. We strongly recommend that you use QuickBooks' online update feature to obtain the latest fixes and enhancements");
                }
                // MessageBox.Show("qbXMLMajorVer = " + qbXMLMajorVer);
                // MessageBox.Show("qbXMLMinorVer = " + qbXMLMinorVer);
                // IY: Create the message set request object
                requestMsgSet = sessionManager.CreateMsgSetRequest(VersionName(context), qbXMLMajorVer(context), qbXMLMinorVer(context));
                Disconnect();
                return requestMsgSet;
            }
            catch (Exception ex)
            {
                try
                {
                    Disconnect();
                }
                catch
                {
                }
                context.TheLeader.Tell("SDK Error: " + ex.Message + "  Please be sure that the QuickBooks SDK is installed.");
                return null;
            }
        }
        public bool CreateAccounts(ContextRz context)
        {
            try
            {
                MakeAccountExist(context, ExpenseAccount(context, null), ExpenseAccountNumber(context), ENAccountType.atExpense);
                MakeAccountExist(context, IncomeAccount(context, null), IncomeAccountNumber(context), ENAccountType.atIncome);
                MakeAccountExist(context, AssetAccount(context), AssetAccountNumber(context), ENAccountType.atOtherAsset);
                MakeAccountExist(context, COGSAccount(context, null), COGSAccountNumber(context), ENAccountType.atCostOfGoodsSold);
                MakeAccountExist(context, DepositAccount(context), DepositAccountNumber(context), ENAccountType.atIncome);
                MakeInvPartExist(context, OutgoingShipping(context), Enums.OrderType.Invoice);
                MakeInvPartExist(context, IncomingShipping(context), Enums.OrderType.Invoice);
                MakeInvPartExist(context, HandlingItem(context), Enums.OrderType.Invoice);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool MakeAccountExist(ContextRz context, String strAccount, String strNumber, QBFC13Lib.ENAccountType t)
        {
            if (!Tools.Strings.StrExt(strAccount))
                return false;
            context.Comment("Checking account " + strAccount);
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.IAccountAdd AccountAdd = requestSet.AppendAccountAddRq();
            AccountAdd.Name.SetValue(strAccount);
            AccountAdd.OpenBalance.SetValue(0);
            AccountAdd.AccountType.SetValue(t);
            AccountAdd.OpenBalanceDate.SetValue(System.DateTime.Now);
            AccountAdd.AccountNumber.SetValue(Tools.Strings.Left(strNumber, 5));
            if (!Connect(context))
                return false;
            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            Disconnect();
            if (response.StatusCode == 0)
            {
                context.Comment(strAccount + " was added.");
                return true;
            }
            else
            {
                context.Comment(strAccount + " was not added: " + response.StatusMessage);
                return false;
            }
        }
        public bool AccountExist(ContextRz context, String strAccount, QBFC13Lib.ENAccountType t)
        {
            if (!Tools.Strings.StrExt(strAccount))
                return false;
            context.Comment("Checking account " + strAccount);
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            QBFC13Lib.IAccountQuery AccountQ = requestSet.AppendAccountQueryRq();
            AccountQ.ORAccountListQuery.AccountListFilter.AccountTypeList.Add(t);
            if (!Connect(context))
                return false;
            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            IResponse response = responseSet.ResponseList.GetAt(0);
            int RowCount = responseSet.ResponseList.Count;
            IAccountRetList AccountList = (IAccountRetList)response.Detail;
            IAccountRet AccountRet = AccountList.GetAt(0);
            for (int i = 0; i < AccountList.Count; i++)
            {
                String name = AccountList.GetAt(i).FullName.GetValue().ToString();
                ENAccountType type = AccountList.GetAt(i).AccountType.GetValue();
                if (!Tools.Strings.StrCmp(strAccount, name))
                    continue;
                if (type != t)
                    continue;
                if (Tools.Strings.StrCmp(strAccount, name))
                {
                    Disconnect();
                    return true;
                }
            }
            Disconnect();
            return false;
        }
        public bool SendCheckPayment(ContextRz context, checkpayment c)
        {
            if (c.senttoqb)
            {
                context.TheLeader.Comment("This transaction has already been sent to QuickBooks.");
                context.TheLeader.TellTemp("This transaction has already been sent to QuickBooks.");
                return false;
            }
            ordhed o = c.OrderObjectGet(context);
            if (o == null)
            {
                context.TheLeader.Comment("The order for this payment could not be found.");
                context.TheLeader.TellTemp("The order for this payment could not be found.");
                return false;
            }
            if (!o.senttoqb)
            {
                context.TheLeader.Comment("The order for this payment has not been sent to Quickbooks yet.");
                context.TheLeader.TellTemp("The order for this payment has not been sent to Quickbooks yet.");
                return false;
            }
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            String strCompany;
            company comp = o.CompanyVar.RefGet(context);
            string cust = comp.GetQuickbooksCustomerName(context);
            switch (c.TransactionType)
            {
                case Enums.TransactionType.Check:
                    if (comp != null)
                        strCompany = comp.GetQuickbooksVendorName(context);
                    else
                        strCompany = FilterVendorName(context, o.companyname);
                    if (!SendCheck(context, c, strCompany, requestSet))
                        return false;
                    break;
                case Enums.TransactionType.Payment:
                    if (comp != null)
                        strCompany = comp.GetQuickbooksCustomerName(context);
                    else
                        strCompany = FilterCustomerName(context, o.companyname);
                    if (!SendPayment(context, c, strCompany, requestSet))
                        return false;
                    break;
            }
            if (!Connect(context))
                return false;
            IMsgSetResponse responseSet = null;
            IResponse response = null;
            try
            {
                context.Comment("Sending " + c.ToString());
                responseSet = sessionManager.DoRequests(requestSet);
                response = responseSet.ResponseList.GetAt(0);
                Disconnect();
            }
            catch (Exception ex)
            {
                context.TheLeader.Error("There was an error exporting " + c.ToString() + ": " + ex.Message);
            }
            Disconnect();
            if (response != null)
            {
                if (response.StatusCode != 0)
                {
                    //if (args.Silent)
                    //    context.Comment("There was an error sending " + c.ToString() + ": " + response.StatusMessage);
                    //else
                    context.TheLeader.Tell("There was an error sending " + c.ToString() + ": " + response.StatusMessage);
                    context.TheLeader.Comment("There was an error sending " + c.ToString() + ": " + response.StatusMessage);
                    return false;
                }
            }
            else
            {
                return false;
            }
            context.Comment("Successfully sent " + c.ToString());
            context.TheLeader.Comment("Successfully sent " + c.ToString());
            c.senttoqb = true;
            try
            {
                context.Update(c);
            }
            catch { }

            return true;
        }
        public virtual bool SendPayment(ContextRz context, checkpayment c, String strCompanyName, IMsgSetRequest requestSet)
        {
            QBFC13Lib.IReceivePaymentAdd p = requestSet.AppendReceivePaymentAddRq();
            p.CustomerRef.FullName.SetValue(strCompanyName);
            p.TotalAmount.SetValue(c.transamount);
            p.ORApplyPayment.IsAutoApply.SetValue(false);
            p.DepositToAccountRef.FullName.SetValue(DepositAccount(context));
            p.RefNumber.SetValue(Tools.Strings.Left(c.referencedata, 30).Trim());
            p.TxnDate.SetValue(c.transdate);
            return true;
        }
        public bool SendCheck(ContextRz context, checkpayment c, String strCompanyName, IMsgSetRequest requestSet)
        {
            //this is done just by paying a bill in QB
            context.TheLeader.Comment("Payments to vendors must be manually recorded in QuickBooks by marking the original QB bill as 'paid'.");
            return false;
        }
        public bool ImportCheckPayment(ContextRz context, checkpayment c)
        {
            if (c == null)
                return false;
            IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
            requestSet.Attributes.OnError = ENRqOnError.roeStop;
            company comp = company.New(context);
            String strCompany = "";
            switch (c.TransactionType)
            {
                case Enums.TransactionType.Check:
                    comp.companyname = c.companyname;
                    strCompany = MakeVendorExist(context, comp, "x", "x");
                    return false;
                    if (!Tools.Strings.StrExt(strCompany))
                        strCompany = FilterCustomerName(context, c.companyname);
                    if (!ImportCheck(c, strCompany, requestSet))
                        return false;
                    break;
                case Enums.TransactionType.Payment:
                    comp.companyname = c.companyname;
                    strCompany = MakeCustomerExist(context, comp);
                    if (!Tools.Strings.StrExt(strCompany))
                        strCompany = FilterCustomerName(context, c.companyname);
                    if (!ImportPayment(c, strCompany, requestSet))
                        return false;
                    break;
            }
            if (!Connect(context))
                return false;
            IMsgSetResponse responseSet = null;
            IResponse response = null;
            try
            {
                responseSet = sessionManager.DoRequests(requestSet);
                response = responseSet.ResponseList.GetAt(0);
            }
            catch { }
            Disconnect();
            if (response != null)
            {
                string m = response.StatusMessage;
                if (response.StatusCode != 0)
                {
                    context.TheLeader.Comment("ImportCheckPayment Error: " + response.StatusMessage);
                    return false;
                }
            }
            else
            {
                context.TheLeader.Comment("No response");
                return false;
            }
            return true;
        }
        public bool ImportPayment(checkpayment c, String strCompanyName, IMsgSetRequest requestSet)
        {
            QBFC13Lib.IReceivePaymentAdd p = requestSet.AppendReceivePaymentAddRq();
            p.CustomerRef.FullName.SetValue(strCompanyName);
            p.TotalAmount.SetValue(c.subtotal);
            p.ORApplyPayment.IsAutoApply.SetValue(false);
            p.DepositToAccountRef.FullName.SetValue(c.transamountcurr);
            //p.PaymentMethodRef.FullName.SetValue(c.referencedata);
            p.RefNumber.SetValue("Import From Rz3");
            p.TxnDate.SetValue(c.datecreated);
            p.Memo.SetValue(c.description);
            return true;
        }
        public bool ImportCheck(checkpayment c, String strCompanyName, IMsgSetRequest requestSet)
        {
            QBFC13Lib.ICheckAdd a = requestSet.AppendCheckAddRq();
            a.PayeeEntityRef.FullName.SetValue(strCompanyName);
            a.RefNumber.SetValue("Import From Rz3");
            a.TxnDate.SetValue(c.datecreated);
            a.AccountRef.FullName.SetValue(c.referencedata);
            //a.TotalAmount.SetValue(c.subtotal);
            //a.ORApplyPayment.IsAutoApply.SetValue(false);
            return true;
        }
        public bool SimplyPartsMode(ContextRz context)
        {
            return (Tools.Strings.HasString(GeneralOption(context), "SimplyParts"));
        }
        public bool NonUSVersion(ContextRz context)
        {
            return VersionName(context) != "US";
        }
        public ArrayList GetUnpaidInvoiceSummaries(ContextRz context)
        {
            ArrayList a = new ArrayList();
            if (Tools.Misc.IsDevelopmentMachine())
            {
                QBUnpaidInvoiceSummary sumx = new QBUnpaidInvoiceSummary();
                sumx.OrderNumber = "000001";
                sumx.OrderDate = DateTime.Now.Subtract(TimeSpan.FromDays(25));
                sumx.Balance = 1234.56;
                sumx.Terms = "Net 30";
                sumx.CustomerName = "Test Company";
                sumx.DueDate = DateTime.Now;
                a.Add(sumx);
                return a;
            }
            try
            {
                context.Comment("Gathering all unpaid QB Invoices...");
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                if (requestSet == null)
                    return a;
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IInvoiceQuery InvoiceQuery = requestSet.AppendInvoiceQueryRq();
                if (InvoiceQuery == null)
                {
                    context.Comment("InvoiceQuery returned null.");
                    return a;
                }
                InvoiceQuery.IncludeLineItems.SetValue(false);
                InvoiceQuery.ORInvoiceQuery.InvoiceFilter.PaidStatus.SetValue(ENPaidStatus.psNotPaidOnly);
                if (!Connect(context))
                    return a;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                if (responseSet == null)
                    return a;
                IResponse response = responseSet.ResponseList.GetAt(0);
                if (response == null)
                    return a;
                Disconnect();
                if (response.StatusCode != 0)
                {
                    context.Comment("Failed.");
                    return a;
                }
                QBFC13Lib.IInvoiceRetList invoiceRetList = (IInvoiceRetList)response.Detail;
                if (invoiceRetList == null)
                    return a;
                context.Comment("Found " + invoiceRetList.Count + " invoices.");
                Int32 countn = 0;
                for (Int32 i = 0; i < invoiceRetList.Count; i++)
                {
                    try
                    {
                        countn = i + 1;
                        context.Comment("Importing " + countn + " of " + invoiceRetList.Count + ".");
                        //System.Windows.Forms.Application.DoEvents();
                        QBFC13Lib.IInvoiceRet InvoiceRet = invoiceRetList.GetAt(i);
                        if (InvoiceRet == null)
                            continue;
                        QBUnpaidInvoiceSummary sum = new QBUnpaidInvoiceSummary();
                        sum.OrderNumber = InvoiceRet.RefNumber.GetValue();
                        sum.OrderDate = InvoiceRet.TimeCreated.GetValue();
                        sum.Balance = InvoiceRet.BalanceRemaining.GetValue();
                        sum.Terms = InvoiceRet.TermsRef.FullName.GetValue();
                        sum.CustomerName = InvoiceRet.CustomerRef.FullName.GetValue();
                        sum.DueDate = InvoiceRet.DueDate.GetValue();
                        a.Add(sum);
                    }
                    catch { }
                }
            }
            catch { }
            return a;
        }
        //Private Functions
        private string AskPartNumber(ContextRz context, String strPartNumber, orddet xDet, ref bool existing, ref bool canceled)
        {
            context.Reorg();
            return "";
            //frmAddInvItem f = new frmAddInvItem();
            //if (!f.CompleteLoad(SysRz4.Context, strPartNumber, xDet))
            //    return strPartNumber;
            //f.ShowDialog();
            //existing = f.PartExists;
            //canceled = f.IsCanceled;
            //return f.SelectedPart;
        }
        public String QBTrim(String s, String max)
        {
            int m = 0;
            try
            {
                m = Convert.ToInt32(max);
            }
            catch
            {
            }
            if (m == 0)
                m = 20;
            return Tools.Strings.Left(s, m);
        }
        protected String ParseTrimCompany(nString comp)
        {
            try
            {
                nString s = comp.ParseDelimit(":", 1).ToString().Trim();
                if (s.ToString().EndsWith("."))
                    s = s.ToString().Substring(0, s.ToString().Length - 1);
                return s.ToString();
            }
            catch
            {
                return comp.ToString();
            }
        }
        private void SetAddress(QBFC13Lib.IAddress addy, String strCompanyName, companyaddress xAddress)
        {
            if (xAddress != null)
            {
                addy.Addr1.SetValue(Tools.Strings.Left(strCompanyName, Convert.ToInt32(addy.Addr1.GetMaxLength())));
                addy.Addr2.SetValue(Tools.Strings.Left(xAddress.line1, Convert.ToInt32(addy.Addr2.GetMaxLength())));
                addy.Addr3.SetValue(Tools.Strings.Left(xAddress.line2 + "  " + xAddress.line3, Convert.ToInt32(addy.Addr3.GetMaxLength())));
                addy.City.SetValue(Tools.Strings.Left(xAddress.adrcity, Convert.ToInt32(addy.City.GetMaxLength())));
                addy.State.SetValue(Tools.Strings.Left(xAddress.adrstate, Convert.ToInt32(addy.State.GetMaxLength())));
                addy.PostalCode.SetValue(Tools.Strings.Left(xAddress.adrzip, Convert.ToInt32(addy.PostalCode.GetMaxLength())));
                addy.Country.SetValue(Tools.Strings.Left(xAddress.adrcountry, Convert.ToInt32(addy.Country.GetMaxLength())));
            }

        }
        private double QBFCLatestVersion(ContextRz context, QBSessionManager SessionManager)
        {
            String s = "";
            return QBFCLatestVersion(context, SessionManager, ref s);
        }
        private double QBFCLatestVersion(ContextRz context, QBSessionManager SessionManager, ref String strAll)
        {
            // IY: Use oldest version to ensure that we work with any QuickBooks (US)
            IMsgSetRequest msgset = SessionManager.CreateMsgSetRequest(VersionName(context), 1, 0);
            msgset.AppendHostQueryRq();
            // MessageBox.Show(msgset.ToXMLString());
            IMsgSetResponse QueryResponse = SessionManager.DoRequests(msgset);
            // IY: The response list contains only one response,
            // which corresponds to our single HostQuery request
            IResponse response = QueryResponse.ResponseList.GetAt(0);
            // IY: Please refer to QBFC Developers Guide/pg for details on why
            // "as" clause was used to link this derrived class to its base class
            IHostRet HostResponse = response.Detail as IHostRet;
            IBSTRList supportedVersions = HostResponse.SupportedQBXMLVersionList as IBSTRList;
            int i;
            double vers;
            double LastVers = 0;
            string svers = null;
            for (i = 0; i <= supportedVersions.Count - 1; i++)
            {
                svers = supportedVersions.GetAt(i);
                strAll += svers + "\r\n";
                vers = Convert.ToDouble(svers);
                if (vers > LastVers)
                {
                    LastVers = vers;
                    //svers = supportedVersions.GetAt(i);
                }
            }
            // IY: Close the session and connection with QuickBooks
            SessionManager.EndSession();
            SessionManager.CloseConnection();
            return LastVers;
        }
        private void TellUserTemp(string s, ContextNM x)
        {
            if (x != null)
                x.TheLeader.TellTemp(s);
        }
        private bool HasAmpleQuantityInv(ContextRz context, string strPartNumber, orddet d)
        {
            context.TheLeader.Error("reorg");
            return false;

        }
        public enum QBItemAccountCategory
        {
            Asset,
            Income,
            Expense,
        }
        public account GetItemAccount(ContextRz context, String item, QBItemAccountCategory c)
        {
            account a = GetNonInvPartAccount(context, item);
            if (a != null)
                return a;
            a = GetServiceItemAccount(context, item);
            if (a != null)
                return a;
            return GetInvPartAccount(context, item, c);
        }
        public account GetInvPartAccount(ContextRz context, String strPartNumber, QBItemAccountCategory c)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IItemInventoryQuery StockQuery = requestSet.AppendItemInventoryQueryRq();
                StockQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(Tools.Strings.Left(strPartNumber, 30).Trim());
                if (!Connect(context))
                    return null;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.Detail == null)
                    return null;
                IItemInventoryRetList list = (IItemInventoryRetList)response.Detail;
                for (Int32 ii = 0; ii <= list.Count - 1; ii++)
                {
                    IItemInventoryRet inv = list.GetAt(ii);
                    if (inv.FullName != null)
                    {
                        if (Tools.Strings.StrCmp(strPartNumber, inv.FullName.GetValue()))
                        {
                            try
                            {
                                string acnt = "";
                                switch (c)
                                {
                                    case QBItemAccountCategory.Asset:
                                        acnt = inv.AssetAccountRef.FullName.GetValue();
                                        break;
                                    case QBItemAccountCategory.Income:
                                        acnt = inv.IncomeAccountRef.FullName.GetValue();
                                        break;
                                    case QBItemAccountCategory.Expense:
                                        acnt = inv.COGSAccountRef.FullName.GetValue();
                                        break;
                                }
                                return account.GetByFullName(context, acnt);
                            }
                            catch { return null; }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }
        public account GetNonInvPartAccount(ContextRz context, String strPartNumber)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IItemNonInventoryQuery NonStockQuery = requestSet.AppendItemNonInventoryQueryRq();
                NonStockQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(Tools.Strings.Left(strPartNumber, 30).Trim());
                if (!Connect(context))
                    return null;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.Detail == null)
                    return null;
                IItemNonInventoryRetList list = (IItemNonInventoryRetList)response.Detail;
                for (Int32 ii = 0; ii <= list.Count - 1; ii++)
                {
                    IItemNonInventoryRet inv = list.GetAt(ii);
                    if (inv.FullName != null)
                    {
                        if (Tools.Strings.StrCmp(strPartNumber, inv.FullName.GetValue()))
                        {
                            try
                            {
                                return account.GetByFullName(context, inv.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            catch { return null; }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }
        public account GetServiceItemAccount(ContextRz context, String strPartNumber)
        {
            try
            {
                IMsgSetRequest requestSet = GetLatestMsgSetRequest(context, sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                QBFC13Lib.IItemServiceQuery ServiceQuery = requestSet.AppendItemServiceQueryRq();
                ServiceQuery.ORListQueryWithOwnerIDAndClass.FullNameList.Add(Tools.Strings.Left(strPartNumber, 30).Trim());
                if (!Connect(context))
                    return null;
                IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                Disconnect();
                if (response.Detail == null)
                    return null;
                IItemServiceRetList list = (IItemServiceRetList)response.Detail;
                for (Int32 ii = 0; ii <= list.Count - 1; ii++)
                {
                    IItemServiceRet inv = list.GetAt(ii);
                    if (inv.FullName != null)
                    {
                        if (Tools.Strings.StrCmp(strPartNumber, inv.FullName.GetValue()))
                        {
                            try
                            {
                                return account.GetByFullName(context, inv.ORSalesPurchase.SalesOrPurchase.AccountRef.FullName.GetValue());
                            }
                            catch { return null; }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                context.TheLeader.Error(ex.Message);
                return null;
            }
        }

    }
    public class QBUnpaidInvoiceSummary
    {
        public String OrderNumber = "";
        public DateTime OrderDate;
        public String CustomerName = "";
        public DateTime DueDate;
        public String Terms = "";
        public Double Balance = 0;
    }
    public delegate void QBStatusHandler(String s);
    public class BillLineHandle
    {
        public orddet_line TheLine;
        public Enums.OrderType TheType;
    }

}

