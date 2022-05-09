using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SM_Enums
/// </summary>
public class SM_Enums
{
    public SM_Enums()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public enum LineProcessType
    {
        LinePriority,
        VendorPaymentApproved
    }


    public enum QcStatus
    {
        Inbound,
        In_House,
        Initial_Inspection,
        Final_Inspection,
        Turned_Back,
        //Final_Inspection_Complete
        Shipped
    }

    public enum LineValidationStatus
    {
        ReSourced //Indicated a line has gone from Source TBD to a new vendor, requires validation
    }

    public enum PortalRole
    {
        admin,
        buyer,
        consign,
        portal_admin,
        sm_insp_admin,
        sm_insp_user,
        sm_internal,
        sm_internal_executive,
        sm_nonconadmin,
        sm_nonconuser,
        sm_nonconviewer,
        sm_warehouse
    }

    public enum StockType
    {

        stock,
        buy,
        offer,
        consign,
        excess

    }

    public enum SplitCommissionType
    {
        standard_split,
        list_acquisition
    }

    public enum ChartType
    {
        line,
        bar,
        horizontalBar,
        pie
    }

    public enum RzLineStatus
    {
        Packing,
        RMA_Receiving,
        Received_From_Service,
        Void,
        Hold,
        Quarantined,
        Shipped,
        Vendor_RMA_Packing,
        Buy,
        Received,
        Out_For_Service,
        Open,
        Scrapped,
        Vendor_RMA_Shipped,
        RMA_Received,
        Packing_For_Service
    }

    public enum InspectionType
    {
        noncon = 1,
        idea = 2,
        gcat = 3
    }

    public enum DetailType
    {
        orddet_line = 0,
        partrecord = 1,
        service_line = 2
    }



    public enum OpportunityLostReason
    {
        Pricing = 0,
        NoResoponse = 1,
        NoStock = 2,
        Quality = 3
    }

    public enum OpportunityStage
    {
        rfq_received,
        formal_quote_created,
        sale_won,
        sale_lost
    }

    public enum BonusCategoryName
    {

        PhoneCallCount = 0,
        VideoCreationCount = 1

    }


    public enum AutomateProcess
    {
        erai_import = 0,
        aged_quotes = 1,
        sitemap_generator = 2,
        daily_call_count = 3,
        truncate_hubspot_engagements = 4,
        source_tbd_report = 5,
        hubspot_deal_sync = 6
    }


    public enum CSVImportType
    {
        ListPartSearch = 0,
        EraiImport = 1
    }

    public enum RzGridColor
    {

        Gray = -8355712,
        Blue = -16776961,
        Red = -65536,
        Green = -16744448,
        Yellow = -2448096

    }

    public enum LogType
    {
        Information = 0,
        Warning = 1,
        Error = 2

    }

    public enum NonConStatus
    {
        PendingApproval = 1,
        Open = 2,
        PendingCompletion = 3,
        Complete = 4,
        ShortShip = 5

    }
}