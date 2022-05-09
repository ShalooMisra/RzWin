using System;
using System.Collections.Generic;
using System.Text;

namespace Rz5
{
    namespace Enums
    {
        public enum TransactionType
        {
            Check = 1,
            Payment = 2,
        }
        public enum Website
        {
            BrokerForum = 1,
            NetComponents = 2,
            ICSource = 3,
            ChipSource = 4,
            PartsBase = 5,
        }
        public enum ContactType
        {
            Unknown = 0,
            OEM = 1,
            DIST = 2,
        }

        public enum ContactFunction
        {
            Any = 0,
            Vendor = 1,
            Vendor2 = 2,
            Vendor3 = 3,
            Vendor4 = 4,
        }

        public enum FillType
        {
            Pick = 1,
            Receive = 2,
        }
        public enum EmailRFQType
        {
            Franchise = 0,
            Web = 1,
            China = 2,
            Preferred = 3
        }
        public enum TransmitType
        {
            Any = 0,
            Print = 1,
            Fax = 2,
            Email = 3,
            PDF = 4,
        }
        public enum OrderType
        {
            Any = 0,
            RFQ = 1,
            Quote = 2,
            Sales = 3,
            Purchase = 4,
            Invoice = 5,
            RMA = 6,
            VendRMA = 7,
            Service = 8,
        }
        public enum OrderLineStatus  //the order here is very important; we often compare what status is > another
        {
            Void,
            Frozen,
            Hold,
            Open,
            Buy,
            Received,
            Packing_For_Service,
            Out_For_Service,
            Received_From_Service,
            Packing,
            Shipped,
            RMA_Receiving,
            RMA_Received,
            ////KT - "IHS" = In House Service
            //RMA_Receiving_IHS,
            //RMA_Received_IHS,
            Vendor_RMA_Packing,
            Vendor_RMA_Shipped,
            //KT - Scrap / Quarantine
            Scrapped,
            Quarantined,
            PreInvoiced,
            Any,
        }
        public enum OrderDirection
        {
            Any = 0,
            Incoming = 1,
            Outgoing = 2,
        }
        public enum OrderQuantityType
        {
            Any = 0,
            Ordered = 1,
            Filled = 2,
        }
        public enum StockType
        {
            Any = 0,
            Stock = 1,
            Excess = 2,
            Consign = 3,
            Buy = 4,
            Offers = 5,
            Archive = 6,
            WebPart = 7,
            Bids = 8,
            Master = 10,
            Service = 11,
        }
        public enum QuoteType
        {
            Any = 0,
            GivingOut = 1,
            Receiving = 2
        }
        public enum ReqDisplayType
        {
            All = 0,
            Sourced = 1,
            NotSourced = 2,
            Quoted = 3,
            NotQuoted = 4
        }





        public enum SalesOrderValidationStage
        {
            FormalQuote,
            PreValidation,
            Validation,
            ValidationComplete,
            ValidationHold,
            InspectionHold,
            CustomerHold,
            
        }

      
        


        public enum QuickbooksSyncType //Helps determine ISalesOrderAdd vs ISalesOrderMod for example, since the QB COM_Objects don't expose themselves.
        {
            Update,
            Insert
        }

        public enum QuickbooksQueryType //handle querying QB by listID, name, etc
        {
            ListIDList,
            FullNameList,
            ListFilter
        }


        public enum SplitCommissionType
        {
            None = 0,
            Standard = 1,//=   1/3 to split agent
            Design = 2,//= 2/3 to split agent               
        }


    }
}
