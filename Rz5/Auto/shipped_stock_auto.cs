using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("shipped_stock")]
    public partial class shipped_stock_auto : NewMethod.nObject
    {
        static shipped_stock_auto()
        {
            Item.AttributesCache(typeof(shipped_stock_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode":
                    datecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prefix":
                    prefixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumber":
                    basenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stocktype":
                    stocktypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumberstripped":
                    basenumberstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumbertrunced":
                    basenumbertruncedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "condition":
                    conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partsetup":
                    partsetupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecreated":
                    datecreatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datemodified":
                    datemodifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "modifiedby":
                    modifiedbyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "partsperpack":
                    partsperpackAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packaging":
                    packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "location":
                    locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepart":
                    alternatepartAttribute = (CoreVarValAttribute)attr;
                    break;
                case "category":
                    categoryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalcomment":
                    internalcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printcomment":
                    printcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_01":
                    userdata_01Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_02":
                    userdata_02Attribute = (CoreVarValAttribute)attr;
                    break;
                case "oemid":
                    oemidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "highprice":
                    highpriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "highpricecurr":
                    highpricecurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "midpricecurr":
                    midpricecurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "midprice":
                    midpriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lowprice":
                    lowpriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lowpricecurr":
                    lowpricecurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "highcostcurr":
                    highcostcurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "highcost":
                    highcostAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lowcost":
                    lowcostAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lowcostcurr":
                    lowcostcurrAttribute = (CoreVarValAttribute)attr;
                    break;
               
                case "dateconfirmed":
                    dateconfirmedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchaserid":
                    purchaseridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importid":
                    importidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "boxcode":
                    boxcodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "boxnum":
                    boxnumAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid":
                    legacyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isoffer":
                    isofferAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyphone":
                    companyphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyfax":
                    companyfaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyemailaddress":
                    companyemailaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leadtime":
                    leadtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companycontactname":
                    companycontactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "opportunityindex":
                    opportunityindexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "costcurr":
                    costcurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cost":
                    costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "price":
                    priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pricecurr":
                    pricecurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "issampleshelf":
                    issampleshelfAttribute = (CoreVarValAttribute)attr;
                    break;
                case "published":
                    publishedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "acceptcross":
                    acceptcrossAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isfilled":
                    isfilledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "delivery":
                    deliveryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isarchivereq":
                    isarchivereqAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantityallocated":
                    quantityallocatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oemnumber":
                    oemnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "islocked":
                    islockedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorname":
                    vendornameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatequantity":
                    alternatequantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country":
                    countryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lotnumber":
                    lotnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "activemarketing":
                    activemarketingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customertype":
                    customertypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_defined":
                    user_definedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "externalcomment":
                    externalcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warehousecomment":
                    warehousecommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "generaldescription":
                    generaldescriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reptaken":
                    reptakenAttribute = (CoreVarValAttribute)attr;
                    break;
                case "repassigned":
                    repassignedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "productgroup":
                    productgroupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importname":
                    importnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datetaken":
                    datetakenAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dateacted":
                    dateactedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_03":
                    userdata_03Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_04":
                    userdata_04Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_05":
                    userdata_05Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_06":
                    userdata_06Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_07":
                    userdata_07Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_08":
                    userdata_08Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_09":
                    userdata_09Attribute = (CoreVarValAttribute)attr;
                    break;
                case "userdata_10":
                    userdata_10Attribute = (CoreVarValAttribute)attr;
                    break;
                case "targetprice":
                    targetpriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "targetpricecurr":
                    targetpricecurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isconsigned":
                    isconsignedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dateimported":
                    dateimportedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buytype":
                    buytypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "previewemailresponses":
                    previewemailresponsesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lastsale":
                    lastsaleAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lastpurchase":
                    lastpurchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyerid":
                    buyeridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyername":
                    buyernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isresult":
                    isresultAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorid":
                    vendoridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isoriginalpack":
                    isoriginalpackAttribute = (CoreVarValAttribute)attr;
                    break;
                case "averagecost":
                    averagecostAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatepartstripped":
                    alternatepartstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mfg_certifications":
                    mfg_certificationsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "no_complete_report":
                    no_complete_reportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "expected_quantity":
                    expected_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_of_measure":
                    unit_of_measureAttribute = (CoreVarValAttribute)attr;
                    break;
                case "do_not_export":
                    do_not_exportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buy_date":
                    buy_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buy_purchase_id":
                    buy_purchase_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buy_sales_id":
                    buy_sales_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sales_caption":
                    sales_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "original_unique_id":
                    original_unique_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "original_stocktype":
                    original_stocktypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_archivable":
                    is_archivableAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_status":
                    part_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ad_quantity":
                    ad_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rohs_info":
                    rohs_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_purchase_uid":
                    the_purchase_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "consignment_code":
                    consignment_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_ordhed_purchase_uid":
                    the_ordhed_purchase_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reorder_quantity":
                    reorder_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "allocated_notes":
                    allocated_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "allocated_notes_display":
                    allocated_notes_displayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_available":
                    quantity_availableAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cogs_account_uid":
                    cogs_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cogs_account_name":
                    cogs_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "income_account_uid":
                    income_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "income_account_name":
                    income_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "asset_account_uid":
                    asset_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "asset_account_name":
                    asset_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_line_uid":
                    purchase_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_agent_uid":
                    purchase_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_agent_name":
                    purchase_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "serial":
                    serialAttribute = (CoreVarValAttribute)attr;
                    break;
                case "IHS_orddet_uid":
                    IHS_orddet_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_RMA_IHS":
                    is_RMA_IHSAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalpartnumber":
                    internalpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "QC_Status":
                    QC_StatusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "productType":
                    productTypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_overbuy":
                    is_overbuyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buy_purchase_ordernumber":
                    buy_purchase_ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "suggested_market_value":
                    suggested_market_valueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "suggested_market_value_date":
                    suggested_market_value_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent":
                    list_acquisition_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent_uid":
                    list_acquisition_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipped_stock_invoice_id":
                    shipped_stock_invoice_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipped_stock_invoice_number":
                    shipped_stock_invoice_numberAttribute = (CoreVarValAttribute)attr;
                    break;

                case "shipped_stock_batch_id":
                    shipped_stock_batch_idAttribute = (CoreVarValAttribute)attr;
                    break;
                    

            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute datecodeAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute prefixAttribute;
        static CoreVarValAttribute basenumberAttribute;
        static CoreVarValAttribute stocktypeAttribute;
        static CoreVarValAttribute basenumberstrippedAttribute;
        static CoreVarValAttribute basenumbertruncedAttribute;
        static CoreVarValAttribute conditionAttribute;
        static CoreVarValAttribute partsetupAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute partsperpackAttribute;
        static CoreVarValAttribute packagingAttribute;
        static CoreVarValAttribute locationAttribute;
        static CoreVarValAttribute alternatepartAttribute;
        static CoreVarValAttribute categoryAttribute;
        static CoreVarValAttribute internalcommentAttribute;
        static CoreVarValAttribute printcommentAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute userdata_01Attribute;
        static CoreVarValAttribute userdata_02Attribute;
        static CoreVarValAttribute oemidAttribute;
        static CoreVarValAttribute highpriceAttribute;
        static CoreVarValAttribute highpricecurrAttribute;
        static CoreVarValAttribute midpricecurrAttribute;
        static CoreVarValAttribute midpriceAttribute;
        static CoreVarValAttribute lowpriceAttribute;
        static CoreVarValAttribute lowpricecurrAttribute;
        static CoreVarValAttribute highcostcurrAttribute;
        static CoreVarValAttribute highcostAttribute;
        static CoreVarValAttribute lowcostAttribute;
        static CoreVarValAttribute lowcostcurrAttribute;
        
        static CoreVarValAttribute dateconfirmedAttribute;
        static CoreVarValAttribute purchaseridAttribute;
        static CoreVarValAttribute importidAttribute;
        static CoreVarValAttribute boxcodeAttribute;
        static CoreVarValAttribute boxnumAttribute;
        static CoreVarValAttribute legacyidAttribute;
        static CoreVarValAttribute isofferAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute companyphoneAttribute;
        static CoreVarValAttribute companyfaxAttribute;
        static CoreVarValAttribute companyemailaddressAttribute;
        static CoreVarValAttribute leadtimeAttribute;
        static CoreVarValAttribute companycontactnameAttribute;
        static CoreVarValAttribute opportunityindexAttribute;
        static CoreVarValAttribute costcurrAttribute;
        static CoreVarValAttribute costAttribute;
        static CoreVarValAttribute priceAttribute;
        static CoreVarValAttribute pricecurrAttribute;
        static CoreVarValAttribute issampleshelfAttribute;
        static CoreVarValAttribute publishedAttribute;
        static CoreVarValAttribute acceptcrossAttribute;
        static CoreVarValAttribute isfilledAttribute;
        static CoreVarValAttribute deliveryAttribute;
        static CoreVarValAttribute isarchivereqAttribute;
        static CoreVarValAttribute quantityallocatedAttribute;
        static CoreVarValAttribute oemnumberAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute islockedAttribute;
        static CoreVarValAttribute vendornameAttribute;
        static CoreVarValAttribute alternatequantityAttribute;
        static CoreVarValAttribute countryAttribute;
        static CoreVarValAttribute lotnumberAttribute;
        static CoreVarValAttribute activemarketingAttribute;
        static CoreVarValAttribute customertypeAttribute;
        static CoreVarValAttribute user_definedAttribute;
        static CoreVarValAttribute externalcommentAttribute;
        static CoreVarValAttribute warehousecommentAttribute;
        static CoreVarValAttribute generaldescriptionAttribute;
        static CoreVarValAttribute reptakenAttribute;
        static CoreVarValAttribute repassignedAttribute;
        static CoreVarValAttribute productgroupAttribute;
        static CoreVarValAttribute importnameAttribute;
        static CoreVarValAttribute datetakenAttribute;
        static CoreVarValAttribute dateactedAttribute;
        static CoreVarValAttribute userdata_03Attribute;
        static CoreVarValAttribute userdata_04Attribute;
        static CoreVarValAttribute userdata_05Attribute;
        static CoreVarValAttribute userdata_06Attribute;
        static CoreVarValAttribute userdata_07Attribute;
        static CoreVarValAttribute userdata_08Attribute;
        static CoreVarValAttribute userdata_09Attribute;
        static CoreVarValAttribute userdata_10Attribute;
        static CoreVarValAttribute targetpriceAttribute;
        static CoreVarValAttribute targetpricecurrAttribute;
        static CoreVarValAttribute isconsignedAttribute;
        static CoreVarValAttribute dateimportedAttribute;
        static CoreVarValAttribute buytypeAttribute;
        static CoreVarValAttribute previewemailresponsesAttribute;
        static CoreVarValAttribute lastsaleAttribute;
        static CoreVarValAttribute lastpurchaseAttribute;
        static CoreVarValAttribute buyeridAttribute;
        static CoreVarValAttribute buyernameAttribute;
        static CoreVarValAttribute isresultAttribute;
        static CoreVarValAttribute vendoridAttribute;
        static CoreVarValAttribute isoriginalpackAttribute;
        static CoreVarValAttribute averagecostAttribute;
        static CoreVarValAttribute alternatepartstrippedAttribute;
        static CoreVarValAttribute mfg_certificationsAttribute;
        static CoreVarValAttribute no_complete_reportAttribute;
        static CoreVarValAttribute expected_quantityAttribute;
        static CoreVarValAttribute unit_of_measureAttribute;
        static CoreVarValAttribute do_not_exportAttribute;
        static CoreVarValAttribute buy_dateAttribute;
        static CoreVarValAttribute buy_purchase_idAttribute;
        static CoreVarValAttribute buy_sales_idAttribute;
        static CoreVarValAttribute sales_captionAttribute;
        static CoreVarValAttribute original_unique_idAttribute;
        static CoreVarValAttribute original_stocktypeAttribute;
        static CoreVarValAttribute is_archivableAttribute;
        static CoreVarValAttribute part_statusAttribute;
        static CoreVarValAttribute ad_quantityAttribute;
        static CoreVarValAttribute rohs_infoAttribute;
        static CoreVarValAttribute the_purchase_uidAttribute;
        static CoreVarValAttribute consignment_codeAttribute;
        static CoreVarValAttribute the_ordhed_purchase_uidAttribute;
        static CoreVarValAttribute reorder_quantityAttribute;
        static CoreVarValAttribute allocated_notesAttribute;
        static CoreVarValAttribute allocated_notes_displayAttribute;
        static CoreVarValAttribute quantity_availableAttribute;
        static CoreVarValAttribute cogs_account_uidAttribute;
        static CoreVarValAttribute cogs_account_nameAttribute;
        static CoreVarValAttribute income_account_uidAttribute;
        static CoreVarValAttribute income_account_nameAttribute;
        static CoreVarValAttribute asset_account_uidAttribute;
        static CoreVarValAttribute asset_account_nameAttribute;
        static CoreVarValAttribute purchase_line_uidAttribute;
        static CoreVarValAttribute purchase_agent_uidAttribute;
        static CoreVarValAttribute purchase_agent_nameAttribute;
        static CoreVarValAttribute serialAttribute;
        static CoreVarValAttribute IHS_orddet_uidAttribute;
        static CoreVarValAttribute is_RMA_IHSAttribute;
        static CoreVarValAttribute internalpartnumberAttribute;
        static CoreVarValAttribute QC_StatusAttribute;
        static CoreVarValAttribute productTypeAttribute;
        static CoreVarValAttribute is_overbuyAttribute;
        static CoreVarValAttribute buy_purchase_ordernumberAttribute;
        static CoreVarValAttribute suggested_market_valueAttribute;
        static CoreVarValAttribute suggested_market_value_dateAttribute;
        static CoreVarValAttribute list_acquisition_agentAttribute;
        static CoreVarValAttribute list_acquisition_agent_uidAttribute;
        static CoreVarValAttribute shipped_stock_invoice_idAttribute;
        static CoreVarValAttribute shipped_stock_invoice_numberAttribute;
        static CoreVarValAttribute shipped_stock_batch_idAttribute;

        

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption = "User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 50, Caption = "Base Companycontact Id", Importance = 2)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption = "Base Company Id", Importance = 3)]
        public VarString base_company_uidVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 100, Caption = "Part Number", Importance = 4)]
        public VarString fullpartnumberVar;

        [CoreVarVal("quantity", "Int64", Caption = "Quantity", Importance = 5)]
        public VarInt64 quantityVar;

        [CoreVarVal("datecode", "String", TheFieldLength = 255, Caption = "Date Code", Importance = 6)]
        public VarString datecodeVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 255, Caption = "Manufacturer", Importance = 7)]
        public VarString manufacturerVar;

        [CoreVarVal("prefix", "String", TheFieldLength = 255, Caption = "Prefix", Importance = 8)]
        public VarString prefixVar;

        [CoreVarVal("basenumber", "String", TheFieldLength = 50, Caption = "Base Number", Importance = 9)]
        public VarString basenumberVar;

        [CoreVarVal("stocktype", "String", TheFieldLength = 50, Caption = "Stock Type", Importance = 10)]
        public VarString stocktypeVar;

        [CoreVarVal("basenumberstripped", "String", TheFieldLength = 50, Caption = "Stripped Base Number", Importance = 11)]
        public VarString basenumberstrippedVar;

        [CoreVarVal("basenumbertrunced", "String", TheFieldLength = 50, Caption = "Truncated Base Number", Importance = 12)]
        public VarString basenumbertruncedVar;

        [CoreVarVal("condition", "String", TheFieldLength = 50, Caption = "Condition", Importance = 13)]
        public VarString conditionVar;

        [CoreVarVal("partsetup", "String", TheFieldLength = 50, Caption = "Part Setup", Importance = 14)]
        public VarString partsetupVar;

        [CoreVarVal("datecreated", "DateTime", Caption = "Date Created", Importance = 15)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption = "Date Modified", Importance = 16)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption = "Modified By", Importance = 17)]
        public VarString modifiedbyVar;

        [CoreVarVal("partsperpack", "Int64", Caption = "Parts Per Pack", Importance = 18)]
        public VarInt64 partsperpackVar;

        [CoreVarVal("packaging", "String", TheFieldLength = 50, Caption = "Packaging", Importance = 19)]
        public VarString packagingVar;

        [CoreVarVal("location", "String", TheFieldLength = 8000, Caption = "Location", Importance = 20)]
        public VarString locationVar;

        [CoreVarVal("alternatepart", "String", TheFieldLength = 50, Caption = "Alternate Part", Importance = 21)]
        public VarString alternatepartVar;

        [CoreVarVal("category", "String", TheFieldLength = 50, Caption = "Category", Importance = 22)]
        public VarString categoryVar;

        [CoreVarVal("internalcomment", "String", TheFieldLength = 8000, Caption = "Internal Comment", Importance = 23)]
        public VarString internalcommentVar;

        [CoreVarVal("printcomment", "String", TheFieldLength = 8000, Caption = "Print Comment", Importance = 24)]
        public VarString printcommentVar;

        [CoreVarVal("description", "String", TheFieldLength = 8000, Caption = "Description", Importance = 25)]
        public VarString descriptionVar;

        [CoreVarVal("userdata_01", "String", TheFieldLength = 50, Caption = "User Data 1", Importance = 26)]
        public VarString userdata_01Var;

        [CoreVarVal("userdata_02", "String", TheFieldLength = 400, Caption = "User Data 2", Importance = 27)]
        public VarString userdata_02Var;

        [CoreVarVal("oemid", "String", TheFieldLength = 50, Importance = 28)]
        public VarString oemidVar;

        [CoreVarVal("highprice", "Double", Caption = "High Price", Importance = 29)]
        public VarDouble highpriceVar;

        [CoreVarVal("highpricecurr", "String", TheFieldLength = 4, Caption = "High Price Currency", Importance = 30)]
        public VarString highpricecurrVar;

        [CoreVarVal("midpricecurr", "String", TheFieldLength = 4, Caption = "Mid Price Currency", Importance = 31)]
        public VarString midpricecurrVar;

        [CoreVarVal("midprice", "Double", Caption = "Mid Price", Importance = 32)]
        public VarDouble midpriceVar;

        [CoreVarVal("lowprice", "Double", Caption = "Low Price", Importance = 33)]
        public VarDouble lowpriceVar;

        [CoreVarVal("lowpricecurr", "String", TheFieldLength = 4, Caption = "Low Price Currency", Importance = 34)]
        public VarString lowpricecurrVar;

        [CoreVarVal("highcostcurr", "String", TheFieldLength = 4, Caption = "High Cost Currency", Importance = 35)]
        public VarString highcostcurrVar;

        [CoreVarVal("highcost", "Double", Caption = "High Cost", Importance = 36)]
        public VarDouble highcostVar;

        [CoreVarVal("lowcost", "Double", Caption = "Low Cost", Importance = 37)]
        public VarDouble lowcostVar;

        [CoreVarVal("lowcostcurr", "String", TheFieldLength = 4, Caption = "Low Cost Currency", Importance = 38)]
        public VarString lowcostcurrVar;

        
        [CoreVarVal("dateconfirmed", "DateTime", Caption = "Confirmed", Importance = 40)]
        public VarDateTime dateconfirmedVar;

        [CoreVarVal("purchaserid", "String", TheFieldLength = 50, Importance = 41)]
        public VarString purchaseridVar;

        [CoreVarVal("importid", "String", TheFieldLength = 8000, Caption = "Import Id", Importance = 42)]
        public VarString importidVar;

        [CoreVarVal("boxcode", "String", TheFieldLength = 10, Caption = "Box Code", Importance = 43)]
        public VarString boxcodeVar;

        [CoreVarVal("boxnum", "String", TheFieldLength = 8000, Caption = "Box Number", Importance = 44)]
        public VarString boxnumVar;

        [CoreVarVal("legacyid", "String", TheFieldLength = 50, Importance = 45)]
        public VarString legacyidVar;

        [CoreVarVal("isoffer", "Boolean", Importance = 46)]
        public VarBoolean isofferVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 47)]
        public VarString companynameVar;

        [CoreVarVal("companyphone", "String", TheFieldLength = 255, Caption = "Company Phone", Importance = 48)]
        public VarString companyphoneVar;

        [CoreVarVal("companyfax", "String", TheFieldLength = 255, Caption = "Company Fax", Importance = 49)]
        public VarString companyfaxVar;

        [CoreVarVal("companyemailaddress", "String", TheFieldLength = 255, Caption = "E-mail Address", Importance = 50)]
        public VarString companyemailaddressVar;

        [CoreVarVal("leadtime", "String", TheFieldLength = 20, Caption = "Lead Time", Importance = 51)]
        public VarString leadtimeVar;

        [CoreVarVal("companycontactname", "String", TheFieldLength = 50, Caption = "Company Contact", Importance = 52)]
        public VarString companycontactnameVar;

        [CoreVarVal("opportunityindex", "Int64", Caption = "Opportunity Index", Importance = 53)]
        public VarInt64 opportunityindexVar;

        [CoreVarVal("costcurr", "String", TheFieldLength = 4, Caption = "Cost Currency", Importance = 54)]
        public VarString costcurrVar;

        [CoreVarVal("cost", "Double", Caption = "Cost", Importance = 55)]
        public VarDouble costVar;

        [CoreVarVal("price", "Double", Caption = "Price", Importance = 56)]
        public VarDouble priceVar;

        [CoreVarVal("pricecurr", "String", TheFieldLength = 4, Caption = "Price Currency", Importance = 57)]
        public VarString pricecurrVar;

        [CoreVarVal("issampleshelf", "Boolean", Caption = "Sample Shelf", Importance = 58)]
        public VarBoolean issampleshelfVar;

        [CoreVarVal("published", "Boolean", Importance = 59)]
        public VarBoolean publishedVar;

        [CoreVarVal("acceptcross", "Boolean", Caption = "Accept Cross", Importance = 60)]
        public VarBoolean acceptcrossVar;

        [CoreVarVal("isfilled", "Boolean", Importance = 61)]
        public VarBoolean isfilledVar;

        [CoreVarVal("delivery", "String", TheFieldLength = 20, Caption = "Delivery", Importance = 62)]
        public VarString deliveryVar;

        [CoreVarVal("isarchivereq", "Boolean", Importance = 63)]
        public VarBoolean isarchivereqVar;

        [CoreVarVal("quantityallocated", "Int64", Caption = "Quantity Allocated", Importance = 64)]
        public VarInt64 quantityallocatedVar;

        [CoreVarVal("oemnumber", "String", TheFieldLength = 20, Caption = "Oem Number", Importance = 65)]
        public VarString oemnumberVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption = "Agent Name", Importance = 66)]
        public VarString agentnameVar;

        [CoreVarVal("islocked", "Boolean", Caption = "Is Locked", Importance = 67)]
        public VarBoolean islockedVar;

        [CoreVarVal("vendorname", "String", TheFieldLength = 255, Caption = "Vendor Name", Importance = 68)]
        public VarString vendornameVar;

        [CoreVarVal("alternatequantity", "Int64", Caption = "Alternate Quantity", Importance = 69)]
        public VarInt64 alternatequantityVar;

        [CoreVarVal("country", "String", TheFieldLength = 50, Caption = "Country", Importance = 70)]
        public VarString countryVar;

        [CoreVarVal("lotnumber", "String", TheFieldLength = 50, Caption = "Lot Number", Importance = 71)]
        public VarString lotnumberVar;

        [CoreVarVal("activemarketing", "String", TheFieldLength = 50, Caption = "Active Marketing", Importance = 72)]
        public VarString activemarketingVar;

        [CoreVarVal("customertype", "String", TheFieldLength = 50, Caption = "Customer Type", Importance = 73)]
        public VarString customertypeVar;

        [CoreVarVal("user_defined", "String", TheFieldLength = 50, Caption = "User Defined", Importance = 74)]
        public VarString user_definedVar;

        [CoreVarVal("externalcomment", "String", TheFieldLength = 100, Caption = "External Comment", Importance = 75)]
        public VarString externalcommentVar;

        [CoreVarVal("warehousecomment", "String", TheFieldLength = 100, Caption = "Warehouse Comment", Importance = 76)]
        public VarString warehousecommentVar;

        [CoreVarVal("generaldescription", "String", TheFieldLength = 50, Caption = "General Description", Importance = 77)]
        public VarString generaldescriptionVar;

        [CoreVarVal("reptaken", "String", TheFieldLength = 50, Caption = "Rep Taken", Importance = 78)]
        public VarString reptakenVar;

        [CoreVarVal("repassigned", "String", TheFieldLength = 50, Caption = "Rep Assigned", Importance = 79)]
        public VarString repassignedVar;

        [CoreVarVal("productgroup", "String", TheFieldLength = 50, Caption = "Product Group", Importance = 80)]
        public VarString productgroupVar;

        [CoreVarVal("importname", "String", TheFieldLength = 50, Caption = "Import Name", Importance = 81)]
        public VarString importnameVar;

        [CoreVarVal("datetaken", "DateTime", Caption = "Date Taken", Importance = 82)]
        public VarDateTime datetakenVar;

        [CoreVarVal("dateacted", "DateTime", Caption = "Date Acted", Importance = 83)]
        public VarDateTime dateactedVar;

        [CoreVarVal("userdata_03", "String", TheFieldLength = 20, Caption = "User Data 3", Importance = 84)]
        public VarString userdata_03Var;

        [CoreVarVal("userdata_04", "String", TheFieldLength = 20, Caption = "User Data 4", Importance = 85)]
        public VarString userdata_04Var;

        [CoreVarVal("userdata_05", "String", TheFieldLength = 20, Caption = "User Data 5", Importance = 86)]
        public VarString userdata_05Var;

        [CoreVarVal("userdata_06", "String", TheFieldLength = 20, Caption = "User Data 6", Importance = 87)]
        public VarString userdata_06Var;

        [CoreVarVal("userdata_07", "String", TheFieldLength = 20, Caption = "User Data 7", Importance = 88)]
        public VarString userdata_07Var;

        [CoreVarVal("userdata_08", "String", TheFieldLength = 20, Caption = "User Data 8", Importance = 89)]
        public VarString userdata_08Var;

        [CoreVarVal("userdata_09", "String", TheFieldLength = 20, Caption = "User Data 9", Importance = 90)]
        public VarString userdata_09Var;

        [CoreVarVal("userdata_10", "String", TheFieldLength = 20, Caption = "User Data 10", Importance = 91)]
        public VarString userdata_10Var;

        [CoreVarVal("targetprice", "Double", Caption = "Target Price", Importance = 92)]
        public VarDouble targetpriceVar;

        [CoreVarVal("targetpricecurr", "String", TheFieldLength = 4, Caption = "Target Price Currency", Importance = 93)]
        public VarString targetpricecurrVar;

        [CoreVarVal("isconsigned", "Boolean", Caption = "Is Consigned", Importance = 94)]
        public VarBoolean isconsignedVar;

        [CoreVarVal("dateimported", "DateTime", Caption = "Date Imported", Importance = 95)]
        public VarDateTime dateimportedVar;

        [CoreVarVal("buytype", "String", TheFieldLength = 50, Caption = "Buy Type", Importance = 96)]
        public VarString buytypeVar;

        [CoreVarVal("previewemailresponses", "Boolean", Caption = "Preview Email Responses", Importance = 97)]
        public VarBoolean previewemailresponsesVar;

        [CoreVarVal("lastsale", "Double", Caption = "Last Sale", Importance = 98)]
        public VarDouble lastsaleVar;

        [CoreVarVal("lastpurchase", "Double", Caption = "Last Purchase", Importance = 99)]
        public VarDouble lastpurchaseVar;

        [CoreVarVal("buyerid", "String", TheFieldLength = 50, Caption = "Buyer Id", Importance = 100)]
        public VarString buyeridVar;

        [CoreVarVal("buyername", "String", TheFieldLength = 50, Caption = "Buyer Name", Importance = 101)]
        public VarString buyernameVar;

        [CoreVarVal("isresult", "Boolean", Caption = "Is Result", Importance = 102)]
        public VarBoolean isresultVar;

        [CoreVarVal("vendorid", "String", TheFieldLength = 50, Caption = "Vendor Id", Importance = 103)]
        public VarString vendoridVar;

        [CoreVarVal("isoriginalpack", "Boolean", Caption = "Is Original Pack", Importance = 104)]
        public VarBoolean isoriginalpackVar;

        [CoreVarVal("averagecost", "Double", Caption = "Average Cost", Importance = 109)]
        public VarDouble averagecostVar;

        [CoreVarVal("alternatepartstripped", "String", TheFieldLength = 255, Caption = "Alternatepartstripped", Importance = 110)]
        public VarString alternatepartstrippedVar;

        [CoreVarVal("mfg_certifications", "Boolean", Caption = "Mfg Certifications", Importance = 111)]
        public VarBoolean mfg_certificationsVar;

        [CoreVarVal("no_complete_report", "Boolean", Caption = "No Complete Report", Importance = 112)]
        public VarBoolean no_complete_reportVar;

        [CoreVarVal("expected_quantity", "Int64", Caption = "Expected Quantity", Importance = 113)]
        public VarInt64 expected_quantityVar;

        [CoreVarVal("unit_of_measure", "String", TheFieldLength = 15, Caption = "Unit Of Measure", Importance = 114)]
        public VarString unit_of_measureVar;

        [CoreVarVal("do_not_export", "Boolean", Caption = "Do Not Export", Importance = 115)]
        public VarBoolean do_not_exportVar;

        [CoreVarVal("buy_date", "DateTime", Caption = "Buy Date", Importance = 116)]
        public VarDateTime buy_dateVar;

        [CoreVarVal("buy_purchase_id", "String", TheFieldLength = 255, Caption = "Buy Purchase Id", Importance = 117)]
        public VarString buy_purchase_idVar;

        [CoreVarVal("buy_sales_id", "String", TheFieldLength = 255, Caption = "Buy Sales Id", Importance = 118)]
        public VarString buy_sales_idVar;

        [CoreVarVal("sales_caption", "String", TheFieldLength = 255, Caption = "Sales Caption", Importance = 119)]
        public VarString sales_captionVar;

        [CoreVarVal("original_unique_id", "String", TheFieldLength = 255, Caption = "Original Unique Id", Importance = 120)]
        public VarString original_unique_idVar;

        [CoreVarVal("original_stocktype", "String", TheFieldLength = 255, Caption = "Original Stocktype", Importance = 121)]
        public VarString original_stocktypeVar;

        [CoreVarVal("is_archivable", "Boolean", Caption = "Is Archivable", Importance = 122)]
        public VarBoolean is_archivableVar;

        [CoreVarVal("part_status", "String", TheFieldLength = 800, Caption = "Part Status", Importance = 123)]
        public VarString part_statusVar;

        [CoreVarVal("ad_quantity", "Int64", Caption = "Advertised Quantity", Importance = 127)]
        public VarInt64 ad_quantityVar;

        [CoreVarVal("rohs_info", "String", TheFieldLength = 50, Caption = "Rohs Info", Importance = 131)]
        public VarString rohs_infoVar;

        [CoreVarVal("the_purchase_uid", "String", TheFieldLength = 255, Caption = "The Purchase Uid", Importance = 132)]
        public VarString the_purchase_uidVar;

        [CoreVarVal("consignment_code", "String", TheFieldLength = 8000, Caption = "Consignment Code", Importance = 133)]
        public VarString consignment_codeVar;

        [CoreVarVal("the_ordhed_purchase_uid", "String", TheFieldLength = 255, Caption = "The Ordhed Purchase Uid", Importance = 134)]
        public VarString the_ordhed_purchase_uidVar;

        [CoreVarVal("reorder_quantity", "Int64", Caption = "Reorder Quantity", Importance = 135)]
        public VarInt64 reorder_quantityVar;

        [CoreVarVal("allocated_notes", "String", TheFieldLength = 8000, Caption = "Allocated Notes", Importance = 136)]
        public VarString allocated_notesVar;

        [CoreVarVal("allocated_notes_display", "String", TheFieldLength = 8000, Caption = "Allocated Notes Display", Importance = 137)]
        public VarString allocated_notes_displayVar;

        [CoreVarVal("quantity_available", "Int64", Caption = "Quantity Available", Importance = 138)]
        public VarInt64 quantity_availableVar;

        [CoreVarVal("cogs_account_uid", "String", Caption = "Cogs Account Uid", Importance = 128)]
        public VarString cogs_account_uidVar;

        [CoreVarVal("cogs_account_name", "String", Caption = "Cogs Account Name", Importance = 129)]
        public VarString cogs_account_nameVar;

        [CoreVarVal("income_account_uid", "String", Caption = "Income Account Uid", Importance = 130)]
        public VarString income_account_uidVar;

        [CoreVarVal("income_account_name", "String", Caption = "Income Account Name", Importance = 131)]
        public VarString income_account_nameVar;

        [CoreVarVal("asset_account_uid", "String", Caption = "Asset Account Uid", Importance = 132)]
        public VarString asset_account_uidVar;

        [CoreVarVal("asset_account_name", "String", Caption = "Asset Account Name", Importance = 133)]
        public VarString asset_account_nameVar;

        [CoreVarVal("purchase_line_uid", "String", Caption = "Purchase Line Uid", Importance = 134)]
        public VarString purchase_line_uidVar;

        [CoreVarVal("purchase_agent_uid", "String", Caption = "Purchase Agent Uid", Importance = 135)]
        public VarString purchase_agent_uidVar;

        [CoreVarVal("purchase_agent_name", "String", Caption = "Purchase Agent Name", Importance = 136)]
        public VarString purchase_agent_nameVar;

        [CoreVarVal("serial", "String", Caption = "Serial", Importance = 137)]
        public VarString serialVar;

        [CoreVarVal("IHS_orddet_uid", "String", TheFieldLength = 50, Caption = "IHS_orddet_uid", Importance = 138)]
        public VarString IHS_orddet_uidVar;

        [CoreVarVal("is_RMA_IHS", "Boolean", Importance = 139)]
        public VarBoolean is_RMA_IHSVar;

        [CoreVarVal("internalpartnumber", "String", TheFieldLength = 100, Caption = "Internal Part Number", Importance = 139)]
        public VarString internalpartnumberVar;

        [CoreVarVal("QC_Status", "String", TheFieldLength = 100, Caption = "QC Status", Importance = 140)]
        public VarString QC_StatusVar;

        [CoreVarVal("productType", "String", TheFieldLength = 100, Caption = "Product Type", Importance = 141)]
        public VarString productTypeVar;

        [CoreVarVal("is_overbuy", "Boolean", Caption = "Overbuy", Importance = 142)]
        public VarBoolean is_overbuyVar;

        [CoreVarVal("buy_purchase_ordernumber", "String", TheFieldLength = 100, Caption = "Stock PO Number", Importance = 143)]
        public VarString buy_purchase_ordernumberVar;

        [CoreVarVal("suggested_market_value", "Double", TheFieldLength = 100, Caption = "Suggested Market Value", Importance = 144)]
        public VarDouble suggested_market_valueVar;

        [CoreVarVal("suggested_market_value_date", "DateTime", TheFieldLength = 100, Caption = "Suggested Market Value Set Date", Importance = 145)]
        public VarDateTime suggested_market_value_dateVar;

        [CoreVarVal("list_acquisition_agent", "String", TheFieldLength = 100, Caption = "List Acquisition Agent", Importance = 146)]
        public VarString list_acquisition_agentVar;

        [CoreVarVal("list_acquisition_agent_uid", "String", TheFieldLength = 100, Caption = "List Acquisition Agent ID", Importance = 147)]
        public VarString list_acquisition_agent_uidVar;

        [CoreVarVal("shipped_stock_invoice_id", "String", TheFieldLength = 100, Caption = "Invoice ID for Shipped Stock (only present when manually moving lots)", Importance = 148)]
        public VarString shipped_stock_invoice_idVar;

        [CoreVarVal("shipped_stock_invoice_number", "String", TheFieldLength = 100, Caption = "Invoice ID for Shipped Stock (only present when manually moving lots)", Importance = 149)]
        public VarString shipped_stock_invoice_numberVar;

        [CoreVarVal("shipped_stock_batch_id", "String", TheFieldLength = 100, Caption = "Shipped Stock Batch ID (only present when manually moving lots)", Importance = 149)]
        public VarString shipped_stock_batch_idVar;
        

        public shipped_stock_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            quantityVar = new VarInt64(this, quantityAttribute);
            datecodeVar = new VarString(this, datecodeAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            prefixVar = new VarString(this, prefixAttribute);
            basenumberVar = new VarString(this, basenumberAttribute);
            stocktypeVar = new VarString(this, stocktypeAttribute);
            basenumberstrippedVar = new VarString(this, basenumberstrippedAttribute);
            basenumbertruncedVar = new VarString(this, basenumbertruncedAttribute);
            conditionVar = new VarString(this, conditionAttribute);
            partsetupVar = new VarString(this, partsetupAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            partsperpackVar = new VarInt64(this, partsperpackAttribute);
            packagingVar = new VarString(this, packagingAttribute);
            locationVar = new VarString(this, locationAttribute);
            alternatepartVar = new VarString(this, alternatepartAttribute);
            categoryVar = new VarString(this, categoryAttribute);
            internalcommentVar = new VarString(this, internalcommentAttribute);
            printcommentVar = new VarString(this, printcommentAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            userdata_01Var = new VarString(this, userdata_01Attribute);
            userdata_02Var = new VarString(this, userdata_02Attribute);
            oemidVar = new VarString(this, oemidAttribute);
            highpriceVar = new VarDouble(this, highpriceAttribute);
            highpricecurrVar = new VarString(this, highpricecurrAttribute);
            midpricecurrVar = new VarString(this, midpricecurrAttribute);
            midpriceVar = new VarDouble(this, midpriceAttribute);
            lowpriceVar = new VarDouble(this, lowpriceAttribute);
            lowpricecurrVar = new VarString(this, lowpricecurrAttribute);
            highcostcurrVar = new VarString(this, highcostcurrAttribute);
            highcostVar = new VarDouble(this, highcostAttribute);
            lowcostVar = new VarDouble(this, lowcostAttribute);
            lowcostcurrVar = new VarString(this, lowcostcurrAttribute);
            
            dateconfirmedVar = new VarDateTime(this, dateconfirmedAttribute);
            purchaseridVar = new VarString(this, purchaseridAttribute);
            importidVar = new VarString(this, importidAttribute);
            boxcodeVar = new VarString(this, boxcodeAttribute);
            boxnumVar = new VarString(this, boxnumAttribute);
            legacyidVar = new VarString(this, legacyidAttribute);
            isofferVar = new VarBoolean(this, isofferAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            companyphoneVar = new VarString(this, companyphoneAttribute);
            companyfaxVar = new VarString(this, companyfaxAttribute);
            companyemailaddressVar = new VarString(this, companyemailaddressAttribute);
            leadtimeVar = new VarString(this, leadtimeAttribute);
            companycontactnameVar = new VarString(this, companycontactnameAttribute);
            opportunityindexVar = new VarInt64(this, opportunityindexAttribute);
            costcurrVar = new VarString(this, costcurrAttribute);
            costVar = new VarDouble(this, costAttribute);
            priceVar = new VarDouble(this, priceAttribute);
            pricecurrVar = new VarString(this, pricecurrAttribute);
            issampleshelfVar = new VarBoolean(this, issampleshelfAttribute);
            publishedVar = new VarBoolean(this, publishedAttribute);
            acceptcrossVar = new VarBoolean(this, acceptcrossAttribute);
            isfilledVar = new VarBoolean(this, isfilledAttribute);
            deliveryVar = new VarString(this, deliveryAttribute);
            isarchivereqVar = new VarBoolean(this, isarchivereqAttribute);
            quantityallocatedVar = new VarInt64(this, quantityallocatedAttribute);
            oemnumberVar = new VarString(this, oemnumberAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            islockedVar = new VarBoolean(this, islockedAttribute);
            vendornameVar = new VarString(this, vendornameAttribute);
            alternatequantityVar = new VarInt64(this, alternatequantityAttribute);
            countryVar = new VarString(this, countryAttribute);
            lotnumberVar = new VarString(this, lotnumberAttribute);
            activemarketingVar = new VarString(this, activemarketingAttribute);
            customertypeVar = new VarString(this, customertypeAttribute);
            user_definedVar = new VarString(this, user_definedAttribute);
            externalcommentVar = new VarString(this, externalcommentAttribute);
            warehousecommentVar = new VarString(this, warehousecommentAttribute);
            generaldescriptionVar = new VarString(this, generaldescriptionAttribute);
            reptakenVar = new VarString(this, reptakenAttribute);
            repassignedVar = new VarString(this, repassignedAttribute);
            productgroupVar = new VarString(this, productgroupAttribute);
            importnameVar = new VarString(this, importnameAttribute);
            datetakenVar = new VarDateTime(this, datetakenAttribute);
            dateactedVar = new VarDateTime(this, dateactedAttribute);
            userdata_03Var = new VarString(this, userdata_03Attribute);
            userdata_04Var = new VarString(this, userdata_04Attribute);
            userdata_05Var = new VarString(this, userdata_05Attribute);
            userdata_06Var = new VarString(this, userdata_06Attribute);
            userdata_07Var = new VarString(this, userdata_07Attribute);
            userdata_08Var = new VarString(this, userdata_08Attribute);
            userdata_09Var = new VarString(this, userdata_09Attribute);
            userdata_10Var = new VarString(this, userdata_10Attribute);
            targetpriceVar = new VarDouble(this, targetpriceAttribute);
            targetpricecurrVar = new VarString(this, targetpricecurrAttribute);
            isconsignedVar = new VarBoolean(this, isconsignedAttribute);
            dateimportedVar = new VarDateTime(this, dateimportedAttribute);
            buytypeVar = new VarString(this, buytypeAttribute);
            previewemailresponsesVar = new VarBoolean(this, previewemailresponsesAttribute);
            lastsaleVar = new VarDouble(this, lastsaleAttribute);
            lastpurchaseVar = new VarDouble(this, lastpurchaseAttribute);
            buyeridVar = new VarString(this, buyeridAttribute);
            buyernameVar = new VarString(this, buyernameAttribute);
            isresultVar = new VarBoolean(this, isresultAttribute);
            vendoridVar = new VarString(this, vendoridAttribute);
            isoriginalpackVar = new VarBoolean(this, isoriginalpackAttribute);
            averagecostVar = new VarDouble(this, averagecostAttribute);
            alternatepartstrippedVar = new VarString(this, alternatepartstrippedAttribute);
            mfg_certificationsVar = new VarBoolean(this, mfg_certificationsAttribute);
            no_complete_reportVar = new VarBoolean(this, no_complete_reportAttribute);
            expected_quantityVar = new VarInt64(this, expected_quantityAttribute);
            unit_of_measureVar = new VarString(this, unit_of_measureAttribute);
            do_not_exportVar = new VarBoolean(this, do_not_exportAttribute);
            buy_dateVar = new VarDateTime(this, buy_dateAttribute);
            buy_purchase_idVar = new VarString(this, buy_purchase_idAttribute);
            buy_sales_idVar = new VarString(this, buy_sales_idAttribute);
            sales_captionVar = new VarString(this, sales_captionAttribute);
            original_unique_idVar = new VarString(this, original_unique_idAttribute);
            original_stocktypeVar = new VarString(this, original_stocktypeAttribute);
            is_archivableVar = new VarBoolean(this, is_archivableAttribute);
            part_statusVar = new VarString(this, part_statusAttribute);
            ad_quantityVar = new VarInt64(this, ad_quantityAttribute);
            rohs_infoVar = new VarString(this, rohs_infoAttribute);
            the_purchase_uidVar = new VarString(this, the_purchase_uidAttribute);
            consignment_codeVar = new VarString(this, consignment_codeAttribute);
            the_ordhed_purchase_uidVar = new VarString(this, the_ordhed_purchase_uidAttribute);
            reorder_quantityVar = new VarInt64(this, reorder_quantityAttribute);
            allocated_notesVar = new VarString(this, allocated_notesAttribute);
            allocated_notes_displayVar = new VarString(this, allocated_notes_displayAttribute);
            quantity_availableVar = new VarInt64(this, quantity_availableAttribute);
            cogs_account_uidVar = new VarString(this, cogs_account_uidAttribute);
            cogs_account_nameVar = new VarString(this, cogs_account_nameAttribute);
            income_account_uidVar = new VarString(this, income_account_uidAttribute);
            income_account_nameVar = new VarString(this, income_account_nameAttribute);
            asset_account_uidVar = new VarString(this, asset_account_uidAttribute);
            asset_account_nameVar = new VarString(this, asset_account_nameAttribute);
            purchase_line_uidVar = new VarString(this, purchase_line_uidAttribute);
            purchase_agent_uidVar = new VarString(this, purchase_agent_uidAttribute);
            purchase_agent_nameVar = new VarString(this, purchase_agent_nameAttribute);
            serialVar = new VarString(this, serialAttribute);
            IHS_orddet_uidVar = new VarString(this, IHS_orddet_uidAttribute);
            is_RMA_IHSVar = new VarBoolean(this, is_RMA_IHSAttribute);
            internalpartnumberVar = new VarString(this, internalpartnumberAttribute);
            QC_StatusVar = new VarString(this, QC_StatusAttribute);
            productTypeVar = new VarString(this, productTypeAttribute);
            is_overbuyVar = new VarBoolean(this, is_overbuyAttribute);
            buy_purchase_ordernumberVar = new VarString(this, buy_purchase_ordernumberAttribute);
            suggested_market_valueVar = new VarDouble(this, suggested_market_valueAttribute);
            suggested_market_value_dateVar = new VarDateTime(this, suggested_market_value_dateAttribute);
            list_acquisition_agentVar = new VarString(this, list_acquisition_agentAttribute);
            list_acquisition_agent_uidVar = new VarString(this, list_acquisition_agent_uidAttribute);
            shipped_stock_invoice_idVar = new VarString(this, shipped_stock_invoice_idAttribute);
            shipped_stock_invoice_numberVar = new VarString(this, shipped_stock_invoice_numberAttribute);
            shipped_stock_batch_idVar = new VarString(this, shipped_stock_batch_idAttribute);

            

        }

        public override string ClassId
        { get { return "shipped_stock_auto"; } }

        public String base_mc_user_uid
        {
            get { return (String)base_mc_user_uidVar.Value; }
            set { base_mc_user_uidVar.Value = value; }
        }

        public String base_companycontact_uid
        {
            get { return (String)base_companycontact_uidVar.Value; }
            set { base_companycontact_uidVar.Value = value; }
        }

        public String base_company_uid
        {
            get { return (String)base_company_uidVar.Value; }
            set { base_company_uidVar.Value = value; }
        }

        public String fullpartnumber
        {
            get { return (String)fullpartnumberVar.Value; }
            set { fullpartnumberVar.Value = value; }
        }

        public Int64 quantity
        {
            get { return (Int64)quantityVar.Value; }
            set { quantityVar.Value = value; }
        }

        public String datecode
        {
            get { return (String)datecodeVar.Value; }
            set { datecodeVar.Value = value; }
        }

        public String manufacturer
        {
            get { return (String)manufacturerVar.Value; }
            set { manufacturerVar.Value = value; }
        }

        public String prefix
        {
            get { return (String)prefixVar.Value; }
            set { prefixVar.Value = value; }
        }

        public String basenumber
        {
            get { return (String)basenumberVar.Value; }
            set { basenumberVar.Value = value; }
        }

        public String stocktype
        {
            get { return (String)stocktypeVar.Value; }
            set { stocktypeVar.Value = value; }
        }

        public String basenumberstripped
        {
            get { return (String)basenumberstrippedVar.Value; }
            set { basenumberstrippedVar.Value = value; }
        }

        public String basenumbertrunced
        {
            get { return (String)basenumbertruncedVar.Value; }
            set { basenumbertruncedVar.Value = value; }
        }

        public String condition
        {
            get { return (String)conditionVar.Value; }
            set { conditionVar.Value = value; }
        }

        public String partsetup
        {
            get { return (String)partsetupVar.Value; }
            set { partsetupVar.Value = value; }
        }

        public DateTime datecreated
        {
            get { return (DateTime)datecreatedVar.Value; }
            set { datecreatedVar.Value = value; }
        }

        public DateTime datemodified
        {
            get { return (DateTime)datemodifiedVar.Value; }
            set { datemodifiedVar.Value = value; }
        }

        public String modifiedby
        {
            get { return (String)modifiedbyVar.Value; }
            set { modifiedbyVar.Value = value; }
        }

        public Int64 partsperpack
        {
            get { return (Int64)partsperpackVar.Value; }
            set { partsperpackVar.Value = value; }
        }

        public String packaging
        {
            get { return (String)packagingVar.Value; }
            set { packagingVar.Value = value; }
        }

        public String location
        {
            get { return (String)locationVar.Value; }
            set { locationVar.Value = value; }
        }

        public String alternatepart
        {
            get { return (String)alternatepartVar.Value; }
            set { alternatepartVar.Value = value; }
        }

        public String category
        {
            get { return (String)categoryVar.Value; }
            set { categoryVar.Value = value; }
        }

        public String internalcomment
        {
            get { return (String)internalcommentVar.Value; }
            set { internalcommentVar.Value = value; }
        }

        public String printcomment
        {
            get { return (String)printcommentVar.Value; }
            set { printcommentVar.Value = value; }
        }

        public String description
        {
            get { return (String)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public String userdata_01
        {
            get { return (String)userdata_01Var.Value; }
            set { userdata_01Var.Value = value; }
        }

        public String userdata_02
        {
            get { return (String)userdata_02Var.Value; }
            set { userdata_02Var.Value = value; }
        }

        public String oemid
        {
            get { return (String)oemidVar.Value; }
            set { oemidVar.Value = value; }
        }

        public Double highprice
        {
            get { return (Double)highpriceVar.Value; }
            set { highpriceVar.Value = value; }
        }

        public String highpricecurr
        {
            get { return (String)highpricecurrVar.Value; }
            set { highpricecurrVar.Value = value; }
        }

        public String midpricecurr
        {
            get { return (String)midpricecurrVar.Value; }
            set { midpricecurrVar.Value = value; }
        }

        public Double midprice
        {
            get { return (Double)midpriceVar.Value; }
            set { midpriceVar.Value = value; }
        }

        public Double lowprice
        {
            get { return (Double)lowpriceVar.Value; }
            set { lowpriceVar.Value = value; }
        }

        public String lowpricecurr
        {
            get { return (String)lowpricecurrVar.Value; }
            set { lowpricecurrVar.Value = value; }
        }

        public String highcostcurr
        {
            get { return (String)highcostcurrVar.Value; }
            set { highcostcurrVar.Value = value; }
        }

        public Double highcost
        {
            get { return (Double)highcostVar.Value; }
            set { highcostVar.Value = value; }
        }

        public Double lowcost
        {
            get { return (Double)lowcostVar.Value; }
            set { lowcostVar.Value = value; }
        }

        public String lowcostcurr
        {
            get { return (String)lowcostcurrVar.Value; }
            set { lowcostcurrVar.Value = value; }
        }

        

        public DateTime dateconfirmed
        {
            get { return (DateTime)dateconfirmedVar.Value; }
            set { dateconfirmedVar.Value = value; }
        }

        public String purchaserid
        {
            get { return (String)purchaseridVar.Value; }
            set { purchaseridVar.Value = value; }
        }

        public String importid
        {
            get { return (String)importidVar.Value; }
            set { importidVar.Value = value; }
        }

        public String boxcode
        {
            get { return (String)boxcodeVar.Value; }
            set { boxcodeVar.Value = value; }
        }

        public String boxnum
        {
            get { return (String)boxnumVar.Value; }
            set { boxnumVar.Value = value; }
        }

        public String legacyid
        {
            get { return (String)legacyidVar.Value; }
            set { legacyidVar.Value = value; }
        }

        public Boolean isoffer
        {
            get { return (Boolean)isofferVar.Value; }
            set { isofferVar.Value = value; }
        }

        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }

        public String companyphone
        {
            get { return (String)companyphoneVar.Value; }
            set { companyphoneVar.Value = value; }
        }

        public String companyfax
        {
            get { return (String)companyfaxVar.Value; }
            set { companyfaxVar.Value = value; }
        }

        public String companyemailaddress
        {
            get { return (String)companyemailaddressVar.Value; }
            set { companyemailaddressVar.Value = value; }
        }

        public String leadtime
        {
            get { return (String)leadtimeVar.Value; }
            set { leadtimeVar.Value = value; }
        }

        public String companycontactname
        {
            get { return (String)companycontactnameVar.Value; }
            set { companycontactnameVar.Value = value; }
        }

        public Int64 opportunityindex
        {
            get { return (Int64)opportunityindexVar.Value; }
            set { opportunityindexVar.Value = value; }
        }

        public String costcurr
        {
            get { return (String)costcurrVar.Value; }
            set { costcurrVar.Value = value; }
        }

        public Double cost
        {
            get { return (Double)costVar.Value; }
            set { costVar.Value = value; }
        }

        public Double price
        {
            get { return (Double)priceVar.Value; }
            set { priceVar.Value = value; }
        }

        public String pricecurr
        {
            get { return (String)pricecurrVar.Value; }
            set { pricecurrVar.Value = value; }
        }

        public Boolean issampleshelf
        {
            get { return (Boolean)issampleshelfVar.Value; }
            set { issampleshelfVar.Value = value; }
        }

        public Boolean published
        {
            get { return (Boolean)publishedVar.Value; }
            set { publishedVar.Value = value; }
        }

        public Boolean acceptcross
        {
            get { return (Boolean)acceptcrossVar.Value; }
            set { acceptcrossVar.Value = value; }
        }

        public Boolean isfilled
        {
            get { return (Boolean)isfilledVar.Value; }
            set { isfilledVar.Value = value; }
        }

        public String delivery
        {
            get { return (String)deliveryVar.Value; }
            set { deliveryVar.Value = value; }
        }

        public Boolean isarchivereq
        {
            get { return (Boolean)isarchivereqVar.Value; }
            set { isarchivereqVar.Value = value; }
        }

        public Int64 quantityallocated
        {
            get { return (Int64)quantityallocatedVar.Value; }
            set { quantityallocatedVar.Value = value; }
        }

        public String oemnumber
        {
            get { return (String)oemnumberVar.Value; }
            set { oemnumberVar.Value = value; }
        }

        public String agentname
        {
            get { return (String)agentnameVar.Value; }
            set { agentnameVar.Value = value; }
        }

        public Boolean islocked
        {
            get { return (Boolean)islockedVar.Value; }
            set { islockedVar.Value = value; }
        }

        public String vendorname
        {
            get { return (String)vendornameVar.Value; }
            set { vendornameVar.Value = value; }
        }

        public Int64 alternatequantity
        {
            get { return (Int64)alternatequantityVar.Value; }
            set { alternatequantityVar.Value = value; }
        }

        public String country
        {
            get { return (String)countryVar.Value; }
            set { countryVar.Value = value; }
        }

        public String lotnumber
        {
            get { return (String)lotnumberVar.Value; }
            set { lotnumberVar.Value = value; }
        }

        public String activemarketing
        {
            get { return (String)activemarketingVar.Value; }
            set { activemarketingVar.Value = value; }
        }

        public String customertype
        {
            get { return (String)customertypeVar.Value; }
            set { customertypeVar.Value = value; }
        }

        public String user_defined
        {
            get { return (String)user_definedVar.Value; }
            set { user_definedVar.Value = value; }
        }

        public String externalcomment
        {
            get { return (String)externalcommentVar.Value; }
            set { externalcommentVar.Value = value; }
        }

        public String warehousecomment
        {
            get { return (String)warehousecommentVar.Value; }
            set { warehousecommentVar.Value = value; }
        }

        public String generaldescription
        {
            get { return (String)generaldescriptionVar.Value; }
            set { generaldescriptionVar.Value = value; }
        }

        public String reptaken
        {
            get { return (String)reptakenVar.Value; }
            set { reptakenVar.Value = value; }
        }

        public String repassigned
        {
            get { return (String)repassignedVar.Value; }
            set { repassignedVar.Value = value; }
        }

        public String productgroup
        {
            get { return (String)productgroupVar.Value; }
            set { productgroupVar.Value = value; }
        }

        public String importname
        {
            get { return (String)importnameVar.Value; }
            set { importnameVar.Value = value; }
        }

        public DateTime datetaken
        {
            get { return (DateTime)datetakenVar.Value; }
            set { datetakenVar.Value = value; }
        }

        public DateTime dateacted
        {
            get { return (DateTime)dateactedVar.Value; }
            set { dateactedVar.Value = value; }
        }

        public String userdata_03
        {
            get { return (String)userdata_03Var.Value; }
            set { userdata_03Var.Value = value; }
        }

        public String userdata_04
        {
            get { return (String)userdata_04Var.Value; }
            set { userdata_04Var.Value = value; }
        }

        public String userdata_05
        {
            get { return (String)userdata_05Var.Value; }
            set { userdata_05Var.Value = value; }
        }

        public String userdata_06
        {
            get { return (String)userdata_06Var.Value; }
            set { userdata_06Var.Value = value; }
        }

        public String userdata_07
        {
            get { return (String)userdata_07Var.Value; }
            set { userdata_07Var.Value = value; }
        }

        public String userdata_08
        {
            get { return (String)userdata_08Var.Value; }
            set { userdata_08Var.Value = value; }
        }

        public String userdata_09
        {
            get { return (String)userdata_09Var.Value; }
            set { userdata_09Var.Value = value; }
        }

        public String userdata_10
        {
            get { return (String)userdata_10Var.Value; }
            set { userdata_10Var.Value = value; }
        }

        public Double targetprice
        {
            get { return (Double)targetpriceVar.Value; }
            set { targetpriceVar.Value = value; }
        }

        public String targetpricecurr
        {
            get { return (String)targetpricecurrVar.Value; }
            set { targetpricecurrVar.Value = value; }
        }

        public Boolean isconsigned
        {
            get { return (Boolean)isconsignedVar.Value; }
            set { isconsignedVar.Value = value; }
        }

        public DateTime dateimported
        {
            get { return (DateTime)dateimportedVar.Value; }
            set { dateimportedVar.Value = value; }
        }

        public String buytype
        {
            get { return (String)buytypeVar.Value; }
            set { buytypeVar.Value = value; }
        }

        public Boolean previewemailresponses
        {
            get { return (Boolean)previewemailresponsesVar.Value; }
            set { previewemailresponsesVar.Value = value; }
        }

        public Double lastsale
        {
            get { return (Double)lastsaleVar.Value; }
            set { lastsaleVar.Value = value; }
        }

        public Double lastpurchase
        {
            get { return (Double)lastpurchaseVar.Value; }
            set { lastpurchaseVar.Value = value; }
        }

        public String buyerid
        {
            get { return (String)buyeridVar.Value; }
            set { buyeridVar.Value = value; }
        }

        public String buyername
        {
            get { return (String)buyernameVar.Value; }
            set { buyernameVar.Value = value; }
        }

        public Boolean isresult
        {
            get { return (Boolean)isresultVar.Value; }
            set { isresultVar.Value = value; }
        }

        public String vendorid
        {
            get { return (String)vendoridVar.Value; }
            set { vendoridVar.Value = value; }
        }

        public Boolean isoriginalpack
        {
            get { return (Boolean)isoriginalpackVar.Value; }
            set { isoriginalpackVar.Value = value; }
        }

        public Double averagecost
        {
            get { return (Double)averagecostVar.Value; }
            set { averagecostVar.Value = value; }
        }

        public String alternatepartstripped
        {
            get { return (String)alternatepartstrippedVar.Value; }
            set { alternatepartstrippedVar.Value = value; }
        }

        public Boolean mfg_certifications
        {
            get { return (Boolean)mfg_certificationsVar.Value; }
            set { mfg_certificationsVar.Value = value; }
        }

        public Boolean no_complete_report
        {
            get { return (Boolean)no_complete_reportVar.Value; }
            set { no_complete_reportVar.Value = value; }
        }

        public Int64 expected_quantity
        {
            get { return (Int64)expected_quantityVar.Value; }
            set { expected_quantityVar.Value = value; }
        }

        public String unit_of_measure
        {
            get { return (String)unit_of_measureVar.Value; }
            set { unit_of_measureVar.Value = value; }
        }

        public Boolean do_not_export
        {
            get { return (Boolean)do_not_exportVar.Value; }
            set { do_not_exportVar.Value = value; }
        }

        public DateTime buy_date
        {
            get { return (DateTime)buy_dateVar.Value; }
            set { buy_dateVar.Value = value; }
        }

        public String buy_purchase_id
        {
            get { return (String)buy_purchase_idVar.Value; }
            set { buy_purchase_idVar.Value = value; }
        }

        public String buy_sales_id
        {
            get { return (String)buy_sales_idVar.Value; }
            set { buy_sales_idVar.Value = value; }
        }

        public String sales_caption
        {
            get { return (String)sales_captionVar.Value; }
            set { sales_captionVar.Value = value; }
        }

        public String original_unique_id
        {
            get { return (String)original_unique_idVar.Value; }
            set { original_unique_idVar.Value = value; }
        }

        public String original_stocktype
        {
            get { return (String)original_stocktypeVar.Value; }
            set { original_stocktypeVar.Value = value; }
        }

        public Boolean is_archivable
        {
            get { return (Boolean)is_archivableVar.Value; }
            set { is_archivableVar.Value = value; }
        }

        public String part_status
        {
            get { return (String)part_statusVar.Value; }
            set { part_statusVar.Value = value; }
        }

        public Int64 ad_quantity
        {
            get { return (Int64)ad_quantityVar.Value; }
            set { ad_quantityVar.Value = value; }
        }

        public String rohs_info
        {
            get { return (String)rohs_infoVar.Value; }
            set { rohs_infoVar.Value = value; }
        }

        public String the_purchase_uid
        {
            get { return (String)the_purchase_uidVar.Value; }
            set { the_purchase_uidVar.Value = value; }
        }

        public String consignment_code
        {
            get { return (String)consignment_codeVar.Value; }
            set { consignment_codeVar.Value = value; }
        }

        public String the_ordhed_purchase_uid
        {
            get { return (String)the_ordhed_purchase_uidVar.Value; }
            set { the_ordhed_purchase_uidVar.Value = value; }
        }

        public Int64 reorder_quantity
        {
            get { return (Int64)reorder_quantityVar.Value; }
            set { reorder_quantityVar.Value = value; }
        }

        public String allocated_notes
        {
            get { return (String)allocated_notesVar.Value; }
            set { allocated_notesVar.Value = value; }
        }

        public String allocated_notes_display
        {
            get { return (String)allocated_notes_displayVar.Value; }
            set { allocated_notes_displayVar.Value = value; }
        }

        public Int64 quantity_available
        {
            get { return (Int64)quantity_availableVar.Value; }
            set { quantity_availableVar.Value = value; }
        }

        public String cogs_account_uid
        {
            get { return (String)cogs_account_uidVar.Value; }
            set { cogs_account_uidVar.Value = value; }
        }

        public String cogs_account_name
        {
            get { return (String)cogs_account_nameVar.Value; }
            set { cogs_account_nameVar.Value = value; }
        }

        public String income_account_uid
        {
            get { return (String)income_account_uidVar.Value; }
            set { income_account_uidVar.Value = value; }
        }

        public String income_account_name
        {
            get { return (String)income_account_nameVar.Value; }
            set { income_account_nameVar.Value = value; }
        }

        public String asset_account_uid
        {
            get { return (String)asset_account_uidVar.Value; }
            set { asset_account_uidVar.Value = value; }
        }

        public String asset_account_name
        {
            get { return (String)asset_account_nameVar.Value; }
            set { asset_account_nameVar.Value = value; }
        }

        public String purchase_line_uid
        {
            get { return (String)purchase_line_uidVar.Value; }
            set { purchase_line_uidVar.Value = value; }
        }

        public String purchase_agent_uid
        {
            get { return (String)purchase_agent_uidVar.Value; }
            set { purchase_agent_uidVar.Value = value; }
        }

        public String purchase_agent_name
        {
            get { return (String)purchase_agent_nameVar.Value; }
            set { purchase_agent_nameVar.Value = value; }
        }

        public String serial
        {
            get { return (String)serialVar.Value; }
            set { serialVar.Value = value; }
        }

        public String IHS_orddet_uid
        {
            get { return (String)IHS_orddet_uidVar.Value; }
            set { IHS_orddet_uidVar.Value = value; }
        }

        public Boolean is_RMA_IHS
        {
            get { return (Boolean)is_RMA_IHSVar.Value; }
            set { is_RMA_IHSVar.Value = value; }
        }

        public String internalpartnumber
        {
            get { return (String)internalpartnumberVar.Value; }
            set { internalpartnumberVar.Value = value; }
        }

        public String QC_Status
        {
            get { return (String)QC_StatusVar.Value; }
            set { QC_StatusVar.Value = value; }
        }

        public String productType
        {
            get { return (String)productTypeVar.Value; }
            set { productTypeVar.Value = value; }
        }

        public Boolean is_overbuy
        {
            get { return (Boolean)is_overbuyVar.Value; }
            set { is_overbuyVar.Value = value; }
        }

        public String buy_purchase_ordernumber
        {
            get { return (String)buy_purchase_ordernumberVar.Value; }
            set { buy_purchase_ordernumberVar.Value = value; }
        }


        public double suggested_market_value
        {
            get { return (double)suggested_market_valueVar.Value; }
            set { suggested_market_valueVar.Value = value; }
        }
        public DateTime suggested_market_value_date
        {
            get { return (DateTime)suggested_market_value_dateVar.Value; }
            set { suggested_market_value_dateVar.Value = value; }
        }

        public string list_acquisition_agent
        {
            get { return (string)list_acquisition_agentVar.Value; }
            set { list_acquisition_agentVar.Value = value; }
        }

        public string list_acquisition_agent_uid
        {
            get { return (string)list_acquisition_agent_uidVar.Value; }
            set { list_acquisition_agent_uidVar.Value = value; }
        }

        public string shipped_stock_invoice_id
        {
            get { return (string)shipped_stock_invoice_idVar.Value; }
            set { shipped_stock_invoice_idVar.Value = value; }
        }

        public string shipped_stock_invoice_number
        {
            get { return (string)shipped_stock_invoice_numberVar.Value; }
            set { shipped_stock_invoice_numberVar.Value = value; }
        }


        public string shipped_stock_batch_id
        {
            get { return (string)shipped_stock_batch_idVar.Value; }
            set { shipped_stock_batch_idVar.Value = value; }
        }


        


    }
    public partial class shipped_stock
    {
        public static shipped_stock New(Context x)
        { return (shipped_stock)x.Item("shipped_stock"); }

        public static shipped_stock GetById(Context x, String uid)
        { return (shipped_stock)x.GetById("shipped_stock", uid); }

        public static shipped_stock QtO(Context x, String sql)
        { return (shipped_stock)x.QtO("shipped_stock", sql); }
    }
}
