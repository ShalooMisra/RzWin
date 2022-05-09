using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;
using System.Collections;

namespace Rz5
{
    [CoreClass("company")]
    public partial class company_auto : NewMethod.nObject
    {
        static company_auto()
        {
            Item.AttributesCache(typeof(company_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_mfg_link_uid":
                    the_mfg_link_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactfrequency":
                    contactfrequencyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companytype":
                    companytypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primarycontact":
                    primarycontactAttribute = (CoreVarValAttribute)attr;
                    break;
                case "divisionof":
                    divisionofAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxid":
                    taxidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "termsascustomer":
                    termsascustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditascustomer":
                    creditascustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pastduelimitascustomer":
                    pastduelimitascustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditascustomercurr":
                    creditascustomercurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditasvendorcurr":
                    creditasvendorcurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditasvendor":
                    creditasvendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pastduelimitasvendor":
                    pastduelimitasvendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "termsasvendor":
                    termsasvendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "freightbilling":
                    freightbillingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipviacustomer":
                    shipviacustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipviavendor":
                    shipviavendorAttribute = (CoreVarValAttribute)attr;
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
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notetext":
                    notetextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryphone":
                    primaryphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryfax":
                    primaryfaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryemailaddress":
                    primaryemailaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primarywebaddress":
                    primarywebaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "zipcode":
                    zipcodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "statename":
                    statenameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country":
                    countryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isinternational":
                    isinternationalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oncredithold":
                    oncreditholdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isactive":
                    isactiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companynumber":
                    companynumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companycode":
                    companycodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internetusername":
                    internetusernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internetpassword":
                    internetpasswordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importid":
                    importidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "countryindex":
                    countryindexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alias1":
                    alias1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alias2":
                    alias2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "contactmethod":
                    contactmethodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid":
                    legacyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "textemailonly":
                    textemailonlyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "distilledname":
                    distillednameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyagent":
                    legacyagentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "confirmationrequestdate":
                    confirmationrequestdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pricelevel":
                    pricelevelAttribute = (CoreVarValAttribute)attr;
                    break;
                case "logopath":
                    logopathAttribute = (CoreVarValAttribute)attr;
                    break;
                case "websitegreeting":
                    websitegreetingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "instockonly":
                    instockonlyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalcompanyname":
                    internalcompanynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyrating":
                    companyratingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "specialty":
                    specialtyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "inventorylines":
                    inventorylinesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "timeoffset":
                    timeoffsetAttribute = (CoreVarValAttribute)attr;
                    break;
                case "timezone":
                    timezoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactfunction":
                    contactfunctionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternaterfqaddress":
                    alternaterfqaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternateconfirmationaddress":
                    alternateconfirmationaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "websiteresponse":
                    websiteresponseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primarycontactbirthday":
                    primarycontactbirthdayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "websitebillingaddress":
                    websitebillingaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "websiteshippingaddress":
                    websiteshippingaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "securityid":
                    securityidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryphoneextension":
                    primaryphoneextensionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "speeddialnumber":
                    speeddialnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendoraccountnumber":
                    vendoraccountnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isvendor":
                    isvendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "iscustomer":
                    iscustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "systemgroups":
                    systemgroupsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "strippedphone":
                    strippedphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lastcontactdate":
                    lastcontactdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "websitemoniker":
                    websitemonikerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotrfq":
                    donotrfqAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rfqemail":
                    rfqemailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "confirmationcount":
                    confirmationcountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "confirmationpercent":
                    confirmationpercentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rfqcount":
                    rfqcountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ispastdue":
                    ispastdueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "wherefoundcompany":
                    wherefoundcompanyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companysize":
                    companysizeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditcardnumber":
                    creditcardnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "distilledphone":
                    distilledphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "distilledfax":
                    distilledfaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prospectid":
                    prospectidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hasduplicates":
                    hasduplicatesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exportable":
                    exportableAttribute = (CoreVarValAttribute)attr;
                    break;
                case "c_of_c":
                    c_of_cAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isdistributor":
                    isdistributorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_name":
                    qb_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_terms":
                    qb_termsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_terms_v":
                    qb_terms_vAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_billing":
                    qb_billingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_shipping":
                    qb_shippingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_locked":
                    is_lockedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_problem":
                    is_problemAttribute = (CoreVarValAttribute)attr;
                    break;
                case "archiveperiod":
                    archiveperiodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "archivetimespan":
                    archivetimespanAttribute = (CoreVarValAttribute)attr;
                    break;
                case "delete_oldoffers":
                    delete_oldoffersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "default_currency":
                    default_currencyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "need_contact":
                    need_contactAttribute = (CoreVarValAttribute)attr;
                    break;
                case "needs_contact":
                    needs_contactAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_government":
                    is_governmentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isindependent":
                    isindependentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isfranchise":
                    isfranchiseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_domain":
                    email_domainAttribute = (CoreVarValAttribute)attr;
                    break;
                case "source":
                    sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_marketing":
                    last_marketingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isoem":
                    isoemAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isbroker":
                    isbrokerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isweb":
                    iswebAttribute = (CoreVarValAttribute)attr;
                    break;
                case "iserai":
                    iseraiAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isiso":
                    isisoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "iscem":
                    iscemAttribute = (CoreVarValAttribute)attr;
                    break;
                case "group_name":
                    group_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_charge":
                    cc_chargeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handling_charge":
                    handling_chargeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_warning":
                    cc_warningAttribute = (CoreVarValAttribute)attr;
                    break;
                case "call_schedule":
                    call_scheduleAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotemail":
                    donotemailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "salesgenie_page":
                    salesgenie_pageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "problem_vendor":
                    problem_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_qbimport":
                    is_qbimportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "nameoncard":
                    nameoncardAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditcardtype":
                    creditcardtypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "expiration_month":
                    expiration_monthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "expiration_year":
                    expiration_yearAttribute = (CoreVarValAttribute)attr;
                    break;
                case "security_code":
                    security_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cardbillingaddr":
                    cardbillingaddrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cardbillingzip":
                    cardbillingzipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_criteria":
                    company_criteriaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "city":
                    cityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "securitycode":
                    securitycodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "islocked_purchase":
                    islocked_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "delete_archives":
                    delete_archivesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "delete_archives_period":
                    delete_archives_periodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_name_v":
                    qb_name_vAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mrp_info":
                    mrp_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_prospect":
                    is_prospectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_pic_type":
                    company_pic_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bank_wire_info":
                    bank_wire_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "po_min":
                    po_minAttribute = (CoreVarValAttribute)attr;
                    break;
                case "po_notify":
                    po_notifyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "next_contact_date":
                    next_contact_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_activity_date":
                    last_activity_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ignore":
                    ignoreAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feedback_positive":
                    feedback_positiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feedback_negative":
                    feedback_negativeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feedback_neutral":
                    feedback_neutralAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feedback_rating":
                    feedback_ratingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lead_source":
                    lead_sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_calllog_uid":
                    last_calllog_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "main_companyaddress_uid":
                    main_companyaddress_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "industry_segment":
                    industry_segmentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "localtime":
                    localtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bankname":
                    banknameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bankaddress":
                    bankaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "swiftcode":
                    swiftcodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "accountnumber":
                    accountnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vatnumber":
                    vatnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companysizetext":
                    companysizetextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "freeshipping":
                    freeshippingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "average_profit":
                    average_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isverified":
                    isverifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "positive_auto":
                    positive_autoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "positive_manual":
                    positive_manualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "negative_auto":
                    negative_autoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "negative_manual":
                    negative_manualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_1":
                    notes_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_2":
                    notes_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_3":
                    notes_3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_4":
                    notes_4Attribute = (CoreVarValAttribute)attr;
                    break;
                case "star_rating":
                    star_ratingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "years_in_business":
                    years_in_businessAttribute = (CoreVarValAttribute)attr;
                    break;
                case "date_assigned":
                    date_assignedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_names":
                    alternate_namesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_reqs":
                    calc_reqsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_bids":
                    calc_bidsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_qquotes":
                    calc_qquotesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_fquotes":
                    calc_fquotesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_sales":
                    calc_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_purchases":
                    calc_purchasesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bids_from_reqs":
                    bids_from_reqsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bell_ringers":
                    bell_ringersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_calls":
                    calc_callsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_notes":
                    calc_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_sales_amount":
                    total_sales_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_req_date":
                    last_req_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_sale_date":
                    last_sale_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_call_date":
                    last_call_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_call_notes":
                    last_call_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_call_result":
                    last_call_resultAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agent":
                    agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_last_quote":
                    calc_last_quoteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_invoice_line_count":
                    calc_invoice_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_invoice_volume":
                    calc_invoice_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_vendrma_line_count":
                    calc_vendrma_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_purchase_line_count":
                    calc_purchase_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_purchase_volume":
                    calc_purchase_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_pot_invoice_line_count":
                    calc_pot_invoice_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_pot_invoice_volume":
                    calc_pot_invoice_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_pot_vendrma_line_count":
                    calc_pot_vendrma_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_pot_purchase_line_count":
                    calc_pot_purchase_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_pot_purchase_volume":
                    calc_pot_purchase_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_purchase_date":
                    last_purchase_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warranty_period":
                    warranty_periodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warranty_period_vendor":
                    warranty_period_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "balance_owed_vendor":
                    balance_owed_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "balance_owed_customer":
                    balance_owed_customerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_Display":
                    Products_DisplayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_SSD":
                    Products_SSDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_Cabling":
                    Products_CablingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_Interconnect":
                    Products_InterconnectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_CrystalOsc":
                    Products_CrystalOscAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_Relay":
                    Products_RelayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_PowerSupply":
                    Products_PowerSupplyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_OpticalTransceiver":
                    Products_OpticalTransceiverAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Products_Components":
                    Products_ComponentsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "SOA_components":
                    SOA_componentsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "SOA_services":
                    SOA_servicesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vetted_date":
                    vetted_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vetted_by":
                    vetted_byAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_vetted":
                    is_vettedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customerTermsMemo":
                    customerTermsMemoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorTermsMemo":
                    vendorTermsMemoAttribute = (CoreVarValAttribute)attr;
                    break;

                case "created_by_name":
                    created_by_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "created_by_uid":
                    created_by_uidAttribute = (CoreVarValAttribute)attr;
                    break;

                case "GCAT_required":
                    GCAT_requiredAttribute = (CoreVarValAttribute)attr;
                    break;
                //REfactored from RzSensible
                case "has_financials":
                    has_financialsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_company_ListID":
                    qb_company_ListIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_company_ListID_vendor":
                    qb_company_ListID_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_company_type":
                    qb_company_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_company_id":
                    hubspot_company_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_name":
                    split_commission_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_uid":
                    split_commission_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_default_type":
                    split_commission_default_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_date_active":
                    split_commission_date_activeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_ID":
                    split_commission_IDAttribute = (CoreVarValAttribute)attr;
                    break;




            }
        }

        static CoreVarValAttribute the_mfg_link_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute contactfrequencyAttribute;
        static CoreVarValAttribute companytypeAttribute;
        static CoreVarValAttribute primarycontactAttribute;
        static CoreVarValAttribute divisionofAttribute;
        static CoreVarValAttribute taxidAttribute;
        static CoreVarValAttribute termsascustomerAttribute;
        static CoreVarValAttribute creditascustomerAttribute;
        static CoreVarValAttribute pastduelimitascustomerAttribute;
        static CoreVarValAttribute creditascustomercurrAttribute;
        static CoreVarValAttribute creditasvendorcurrAttribute;
        static CoreVarValAttribute creditasvendorAttribute;
        static CoreVarValAttribute pastduelimitasvendorAttribute;
        static CoreVarValAttribute termsasvendorAttribute;
        static CoreVarValAttribute freightbillingAttribute;
        static CoreVarValAttribute shipviacustomerAttribute;
        static CoreVarValAttribute shipviavendorAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute notetextAttribute;
        static CoreVarValAttribute primaryphoneAttribute;
        static CoreVarValAttribute primaryfaxAttribute;
        static CoreVarValAttribute primaryemailaddressAttribute;
        static CoreVarValAttribute primarywebaddressAttribute;
        static CoreVarValAttribute zipcodeAttribute;
        static CoreVarValAttribute statenameAttribute;
        static CoreVarValAttribute countryAttribute;
        static CoreVarValAttribute isinternationalAttribute;
        static CoreVarValAttribute oncreditholdAttribute;
        static CoreVarValAttribute isactiveAttribute;
        static CoreVarValAttribute companynumberAttribute;
        static CoreVarValAttribute companycodeAttribute;
        static CoreVarValAttribute internetusernameAttribute;
        static CoreVarValAttribute internetpasswordAttribute;
        static CoreVarValAttribute importidAttribute;
        static CoreVarValAttribute countryindexAttribute;
        static CoreVarValAttribute alias1Attribute;
        static CoreVarValAttribute alias2Attribute;
        static CoreVarValAttribute contactmethodAttribute;
        static CoreVarValAttribute legacyidAttribute;
        static CoreVarValAttribute textemailonlyAttribute;
        static CoreVarValAttribute distillednameAttribute;
        static CoreVarValAttribute legacyagentAttribute;
        static CoreVarValAttribute confirmationrequestdateAttribute;
        static CoreVarValAttribute pricelevelAttribute;
        static CoreVarValAttribute logopathAttribute;
        static CoreVarValAttribute websitegreetingAttribute;
        static CoreVarValAttribute instockonlyAttribute;
        static CoreVarValAttribute internalcompanynameAttribute;
        static CoreVarValAttribute companyratingAttribute;
        static CoreVarValAttribute specialtyAttribute;
        static CoreVarValAttribute inventorylinesAttribute;
        static CoreVarValAttribute timeoffsetAttribute;
        static CoreVarValAttribute timezoneAttribute;
        static CoreVarValAttribute contactfunctionAttribute;
        static CoreVarValAttribute alternaterfqaddressAttribute;
        static CoreVarValAttribute alternateconfirmationaddressAttribute;
        static CoreVarValAttribute websiteresponseAttribute;
        static CoreVarValAttribute primarycontactbirthdayAttribute;
        static CoreVarValAttribute websitebillingaddressAttribute;
        static CoreVarValAttribute websiteshippingaddressAttribute;
        static CoreVarValAttribute securityidAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute primaryphoneextensionAttribute;
        static CoreVarValAttribute speeddialnumberAttribute;
        static CoreVarValAttribute vendoraccountnumberAttribute;
        static CoreVarValAttribute isvendorAttribute;
        static CoreVarValAttribute iscustomerAttribute;
        static CoreVarValAttribute systemgroupsAttribute;
        static CoreVarValAttribute strippedphoneAttribute;
        static CoreVarValAttribute lastcontactdateAttribute;
        static CoreVarValAttribute websitemonikerAttribute;
        static CoreVarValAttribute donotrfqAttribute;
        static CoreVarValAttribute rfqemailAttribute;
        static CoreVarValAttribute confirmationcountAttribute;
        static CoreVarValAttribute confirmationpercentAttribute;
        static CoreVarValAttribute rfqcountAttribute;
        static CoreVarValAttribute ispastdueAttribute;
        static CoreVarValAttribute wherefoundcompanyAttribute;
        static CoreVarValAttribute companysizeAttribute;
        static CoreVarValAttribute creditcardnumberAttribute;
        static CoreVarValAttribute distilledphoneAttribute;
        static CoreVarValAttribute distilledfaxAttribute;
        static CoreVarValAttribute prospectidAttribute;
        static CoreVarValAttribute hasduplicatesAttribute;
        static CoreVarValAttribute exportableAttribute;
        static CoreVarValAttribute c_of_cAttribute;
        static CoreVarValAttribute isdistributorAttribute;
        static CoreVarValAttribute qb_nameAttribute;
        static CoreVarValAttribute qb_termsAttribute;
        static CoreVarValAttribute qb_terms_vAttribute;
        static CoreVarValAttribute qb_billingAttribute;
        static CoreVarValAttribute qb_shippingAttribute;
        static CoreVarValAttribute is_lockedAttribute;
        static CoreVarValAttribute is_problemAttribute;
        static CoreVarValAttribute archiveperiodAttribute;
        static CoreVarValAttribute archivetimespanAttribute;
        static CoreVarValAttribute delete_oldoffersAttribute;
        static CoreVarValAttribute default_currencyAttribute;
        static CoreVarValAttribute need_contactAttribute;
        static CoreVarValAttribute needs_contactAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute is_governmentAttribute;
        static CoreVarValAttribute isindependentAttribute;
        static CoreVarValAttribute isfranchiseAttribute;
        static CoreVarValAttribute email_domainAttribute;
        static CoreVarValAttribute sourceAttribute;
        static CoreVarValAttribute last_marketingAttribute;
        static CoreVarValAttribute isoemAttribute;
        static CoreVarValAttribute isbrokerAttribute;
        static CoreVarValAttribute iswebAttribute;
        static CoreVarValAttribute iseraiAttribute;
        static CoreVarValAttribute isisoAttribute;
        static CoreVarValAttribute iscemAttribute;
        static CoreVarValAttribute group_nameAttribute;
        static CoreVarValAttribute cc_chargeAttribute;
        static CoreVarValAttribute handling_chargeAttribute;
        static CoreVarValAttribute cc_warningAttribute;
        static CoreVarValAttribute call_scheduleAttribute;
        static CoreVarValAttribute donotemailAttribute;
        static CoreVarValAttribute salesgenie_pageAttribute;
        static CoreVarValAttribute problem_vendorAttribute;
        static CoreVarValAttribute is_qbimportAttribute;
        static CoreVarValAttribute nameoncardAttribute;
        static CoreVarValAttribute creditcardtypeAttribute;
        static CoreVarValAttribute expiration_monthAttribute;
        static CoreVarValAttribute expiration_yearAttribute;
        static CoreVarValAttribute security_codeAttribute;
        static CoreVarValAttribute cardbillingaddrAttribute;
        static CoreVarValAttribute cardbillingzipAttribute;
        static CoreVarValAttribute company_criteriaAttribute;
        static CoreVarValAttribute cityAttribute;
        static CoreVarValAttribute securitycodeAttribute;
        static CoreVarValAttribute islocked_purchaseAttribute;
        static CoreVarValAttribute delete_archivesAttribute;
        static CoreVarValAttribute delete_archives_periodAttribute;
        static CoreVarValAttribute qb_name_vAttribute;
        static CoreVarValAttribute mrp_infoAttribute;
        static CoreVarValAttribute is_prospectAttribute;
        static CoreVarValAttribute company_pic_typeAttribute;
        static CoreVarValAttribute bank_wire_infoAttribute;
        static CoreVarValAttribute po_minAttribute;
        static CoreVarValAttribute po_notifyAttribute;
        static CoreVarValAttribute next_contact_dateAttribute;
        static CoreVarValAttribute last_activity_dateAttribute;
        static CoreVarValAttribute ignoreAttribute;
        static CoreVarValAttribute feedback_positiveAttribute;
        static CoreVarValAttribute feedback_negativeAttribute;
        static CoreVarValAttribute feedback_neutralAttribute;
        static CoreVarValAttribute feedback_ratingAttribute;
        static CoreVarValAttribute lead_sourceAttribute;
        static CoreVarValAttribute last_calllog_uidAttribute;
        static CoreVarValAttribute main_companyaddress_uidAttribute;
        static CoreVarValAttribute industry_segmentAttribute;
        static CoreVarValAttribute localtimeAttribute;
        static CoreVarValAttribute banknameAttribute;
        static CoreVarValAttribute bankaddressAttribute;
        static CoreVarValAttribute swiftcodeAttribute;
        static CoreVarValAttribute accountnumberAttribute;
        static CoreVarValAttribute vatnumberAttribute;
        static CoreVarValAttribute companysizetextAttribute;
        static CoreVarValAttribute freeshippingAttribute;
        static CoreVarValAttribute average_profitAttribute;
        static CoreVarValAttribute isverifiedAttribute;
        static CoreVarValAttribute positive_autoAttribute;
        static CoreVarValAttribute positive_manualAttribute;
        static CoreVarValAttribute negative_autoAttribute;
        static CoreVarValAttribute negative_manualAttribute;
        static CoreVarValAttribute notes_1Attribute;
        static CoreVarValAttribute notes_2Attribute;
        static CoreVarValAttribute notes_3Attribute;
        static CoreVarValAttribute notes_4Attribute;
        static CoreVarValAttribute star_ratingAttribute;
        static CoreVarValAttribute years_in_businessAttribute;
        static CoreVarValAttribute date_assignedAttribute;
        static CoreVarValAttribute alternate_namesAttribute;
        static CoreVarValAttribute calc_reqsAttribute;
        static CoreVarValAttribute calc_bidsAttribute;
        static CoreVarValAttribute calc_qquotesAttribute;
        static CoreVarValAttribute calc_fquotesAttribute;
        static CoreVarValAttribute calc_salesAttribute;
        static CoreVarValAttribute calc_purchasesAttribute;
        static CoreVarValAttribute bids_from_reqsAttribute;
        static CoreVarValAttribute bell_ringersAttribute;
        static CoreVarValAttribute calc_callsAttribute;
        static CoreVarValAttribute calc_notesAttribute;
        static CoreVarValAttribute total_sales_amountAttribute;
        static CoreVarValAttribute last_req_dateAttribute;
        static CoreVarValAttribute last_sale_dateAttribute;
        static CoreVarValAttribute last_call_dateAttribute;
        static CoreVarValAttribute last_call_notesAttribute;
        static CoreVarValAttribute last_call_resultAttribute;
        static CoreVarValAttribute agentAttribute;
        static CoreVarValAttribute calc_last_quoteAttribute;
        static CoreVarValAttribute calc_invoice_line_countAttribute;
        static CoreVarValAttribute calc_invoice_volumeAttribute;
        static CoreVarValAttribute calc_vendrma_line_countAttribute;
        static CoreVarValAttribute calc_purchase_line_countAttribute;
        static CoreVarValAttribute calc_purchase_volumeAttribute;
        static CoreVarValAttribute calc_pot_invoice_line_countAttribute;
        static CoreVarValAttribute calc_pot_invoice_volumeAttribute;
        static CoreVarValAttribute calc_pot_vendrma_line_countAttribute;
        static CoreVarValAttribute calc_pot_purchase_line_countAttribute;
        static CoreVarValAttribute calc_pot_purchase_volumeAttribute;
        static CoreVarValAttribute last_purchase_dateAttribute;
        static CoreVarValAttribute warranty_periodAttribute;
        static CoreVarValAttribute warranty_period_vendorAttribute;
        static CoreVarValAttribute balance_owed_vendorAttribute;
        static CoreVarValAttribute balance_owed_customerAttribute;
        static CoreVarValAttribute Products_DisplayAttribute;
        static CoreVarValAttribute Products_SSDAttribute;
        static CoreVarValAttribute Products_CablingAttribute;
        static CoreVarValAttribute Products_InterconnectAttribute;
        static CoreVarValAttribute Products_CrystalOscAttribute;
        static CoreVarValAttribute Products_RelayAttribute;
        static CoreVarValAttribute Products_PowerSupplyAttribute;
        static CoreVarValAttribute Products_OpticalTransceiverAttribute;
        static CoreVarValAttribute Products_ComponentsAttribute;
        static CoreVarValAttribute SOA_componentsAttribute;
        static CoreVarValAttribute SOA_servicesAttribute;
        static CoreVarValAttribute has_financialsAttribute;
        static CoreVarValAttribute vetted_dateAttribute;
        static CoreVarValAttribute vetted_byAttribute;
        static CoreVarValAttribute is_vettedAttribute;
        static CoreVarValAttribute customerTermsMemoAttribute;
        static CoreVarValAttribute vendorTermsMemoAttribute;
        static CoreVarValAttribute created_by_nameAttribute;
        static CoreVarValAttribute created_by_uidAttribute;
        static CoreVarValAttribute GCAT_requiredAttribute;
        static CoreVarValAttribute qb_company_ListIDAttribute;
        static CoreVarValAttribute qb_company_typeAttribute;
        static CoreVarValAttribute qb_company_ListID_vendorAttribute;
        static CoreVarValAttribute hubspot_company_idAttribute;
        static CoreVarValAttribute split_commission_agent_nameAttribute;
        static CoreVarValAttribute split_commission_agent_uidAttribute;
        static CoreVarValAttribute split_commission_default_typeAttribute;
        static CoreVarValAttribute split_commission_date_activeAttribute;
        static CoreVarValAttribute split_commission_IDAttribute;

        [CoreVarVal("the_mfg_link_uid", "String", TheFieldLength = 255, Caption = "The Mfg Link Uid", Importance = 1)]
        public VarString the_mfg_link_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption = "User Id", Importance = 2)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 3)]
        public VarString companynameVar;

        [CoreVarVal("contactfrequency", "String", TheFieldLength = 255, Caption = "Contact Frequency", Importance = 4)]
        public VarString contactfrequencyVar;

        [CoreVarVal("companytype", "String", TheFieldLength = 50, Caption = "Type", Importance = 5)]
        public VarString companytypeVar;

        [CoreVarVal("primarycontact", "String", TheFieldLength = 255, Caption = "Primary Contact", Importance = 6)]
        public VarString primarycontactVar;

        [CoreVarVal("divisionof", "String", TheFieldLength = 50, Caption = "Division Of", Importance = 7)]
        public VarString divisionofVar;

        [CoreVarVal("taxid", "String", TheFieldLength = 50, Caption = "Tax Id", Importance = 8)]
        public VarString taxidVar;

        [CoreVarVal("termsascustomer", "String", TheFieldLength = 50, Caption = "Terms As Customer", Importance = 9)]
        public VarString termsascustomerVar;

        [CoreVarVal("creditascustomer", "Double", Caption = "Credit As Customer", Importance = 10)]
        public VarDouble creditascustomerVar;

        [CoreVarVal("pastduelimitascustomer", "Int32", Caption = "Due Limit (as Customer)", Importance = 11)]
        public VarInt32 pastduelimitascustomerVar;

        [CoreVarVal("creditascustomercurr", "String", TheFieldLength = 4, Caption = "Credit As Customer Currency", Importance = 12)]
        public VarString creditascustomercurrVar;

        [CoreVarVal("creditasvendorcurr", "String", TheFieldLength = 4, Caption = "Credit As Vendor Currency", Importance = 13)]
        public VarString creditasvendorcurrVar;

        [CoreVarVal("creditasvendor", "Double", Caption = "Credit As Vendor", Importance = 14)]
        public VarDouble creditasvendorVar;

        [CoreVarVal("pastduelimitasvendor", "Int32", Caption = "Due Limit (as Vendor)", Importance = 15)]
        public VarInt32 pastduelimitasvendorVar;

        [CoreVarVal("termsasvendor", "String", TheFieldLength = 50, Caption = "Terms As Vendor", Importance = 16)]
        public VarString termsasvendorVar;

        [CoreVarVal("freightbilling", "String", TheFieldLength = 50, Caption = "Freight Billing", Importance = 17)]
        public VarString freightbillingVar;

        [CoreVarVal("shipviacustomer", "String", TheFieldLength = 50, Caption = "Ship Via (customer)", Importance = 18)]
        public VarString shipviacustomerVar;

        [CoreVarVal("shipviavendor", "String", TheFieldLength = 50, Caption = "Ship Via (vendor)", Importance = 19)]
        public VarString shipviavendorVar;

        [CoreVarVal("datecreated", "DateTime", Caption = "Date Created", Importance = 20)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption = "Date Modified", Importance = 21)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption = "Modified By", Importance = 22)]
        public VarString modifiedbyVar;

        [CoreVarVal("description", "String", TheFieldLength = 8000, Caption = "Description", Importance = 23)]
        public VarString descriptionVar;

        [CoreVarVal("notetext", "Text", Caption = "Notes", Importance = 24)]
        public VarText notetextVar;

        [CoreVarVal("primaryphone", "String", TheFieldLength = 50, Caption = "Primary Phone", Importance = 25)]
        public VarString primaryphoneVar;

        [CoreVarVal("primaryfax", "String", TheFieldLength = 50, Caption = "Primary Fax", Importance = 26)]
        public VarString primaryfaxVar;

        [CoreVarVal("primaryemailaddress", "String", TheFieldLength = 100, Caption = "Primary Email", Importance = 27)]
        public VarString primaryemailaddressVar;

        [CoreVarVal("primarywebaddress", "String", TheFieldLength = 50, Caption = "Primary Web Address", Importance = 28)]
        public VarString primarywebaddressVar;

        [CoreVarVal("zipcode", "String", TheFieldLength = 50, Caption = "Zip Code", Importance = 29)]
        public VarString zipcodeVar;

        [CoreVarVal("statename", "String", TheFieldLength = 50, Caption = "State", Importance = 30)]
        public VarString statenameVar;

        [CoreVarVal("country", "String", TheFieldLength = 50, Caption = "Country", Importance = 31)]
        public VarString countryVar;

        [CoreVarVal("isinternational", "Boolean", Caption = "Is International", Importance = 32)]
        public VarBoolean isinternationalVar;

        [CoreVarVal("oncredithold", "Boolean", Caption = "On Credit Hold", Importance = 213)]
        public VarBoolean oncreditholdVar;

        [CoreVarVal("isactive", "Boolean", Caption = "Is Active", Importance = 33)]
        public VarBoolean isactiveVar;

        [CoreVarVal("companynumber", "Int32", Caption = "Company Number", Importance = 34)]
        public VarInt32 companynumberVar;

        [CoreVarVal("companycode", "String", TheFieldLength = 50, Caption = "Company Code", Importance = 35)]
        public VarString companycodeVar;

        [CoreVarVal("internetusername", "String", TheFieldLength = 50, Caption = "Internet Name", Importance = 36)]
        public VarString internetusernameVar;

        [CoreVarVal("internetpassword", "String", TheFieldLength = 50, Caption = "Internet Password", Importance = 37)]
        public VarString internetpasswordVar;

        [CoreVarVal("importid", "String", TheFieldLength = 50, Importance = 38)]
        public VarString importidVar;

        [CoreVarVal("countryindex", "Int32", Importance = 39)]
        public VarInt32 countryindexVar;

        [CoreVarVal("alias1", "String", TheFieldLength = 50, Caption = "Alias 1", Importance = 40)]
        public VarString alias1Var;

        [CoreVarVal("alias2", "String", TheFieldLength = 50, Caption = "Alias 2", Importance = 41)]
        public VarString alias2Var;

        [CoreVarVal("contactmethod", "String", TheFieldLength = 50, Caption = "Contact Method", Importance = 42)]
        public VarString contactmethodVar;

        [CoreVarVal("legacyid", "String", TheFieldLength = 50, Importance = 43)]
        public VarString legacyidVar;

        [CoreVarVal("textemailonly", "Boolean", Caption = "Text Email Only", Importance = 44)]
        public VarBoolean textemailonlyVar;

        [CoreVarVal("distilledname", "String", TheFieldLength = 50, Importance = 45)]
        public VarString distillednameVar;

        [CoreVarVal("legacyagent", "String", TheFieldLength = 50, Importance = 46)]
        public VarString legacyagentVar;

        [CoreVarVal("confirmationrequestdate", "DateTime", Caption = "Confirmation Request Date", Importance = 47)]
        public VarDateTime confirmationrequestdateVar;

        [CoreVarVal("pricelevel", "Int32", Caption = "Price Level", Importance = 48)]
        public VarInt32 pricelevelVar;

        [CoreVarVal("logopath", "String", TheFieldLength = 50, Caption = "Logo Path", Importance = 49)]
        public VarString logopathVar;

        [CoreVarVal("websitegreeting", "String", TheFieldLength = 255, Caption = "Website Greeting", Importance = 50)]
        public VarString websitegreetingVar;

        [CoreVarVal("instockonly", "Boolean", Importance = 51)]
        public VarBoolean instockonlyVar;

        [CoreVarVal("internalcompanyname", "String", TheFieldLength = 50, Caption = "Internal Name", Importance = 52)]
        public VarString internalcompanynameVar;

        [CoreVarVal("companyrating", "Int32", Caption = "Rating", Importance = 53)]
        public VarInt32 companyratingVar;

        [CoreVarVal("specialty", "String", TheFieldLength = 50, Caption = "Specialty", Importance = 54)]
        public VarString specialtyVar;

        [CoreVarVal("inventorylines", "Int64", Caption = "Lines Of Stock", Importance = 55)]
        public VarInt64 inventorylinesVar;

        [CoreVarVal("timeoffset", "Int32", Caption = "Time Offset", Importance = 56)]
        public VarInt32 timeoffsetVar;

        [CoreVarVal("timezone", "String", TheFieldLength = 255, Caption = "Time Zone", Importance = 57)]
        public VarString timezoneVar;

        [CoreVarVal("contactfunction", "String", TheFieldLength = 50, Caption = "Contact Function", Importance = 58)]
        public VarString contactfunctionVar;

        [CoreVarVal("alternaterfqaddress", "String", TheFieldLength = 50, Caption = "Alternate Rfq Address", Importance = 59)]
        public VarString alternaterfqaddressVar;

        [CoreVarVal("alternateconfirmationaddress", "String", TheFieldLength = 50, Caption = "Alternate Confirmation Address", Importance = 60)]
        public VarString alternateconfirmationaddressVar;

        [CoreVarVal("websiteresponse", "String", TheFieldLength = 50, Importance = 61)]
        public VarString websiteresponseVar;

        [CoreVarVal("primarycontactbirthday", "String", TheFieldLength = 50, Caption = "Contact Birthday", Importance = 62)]
        public VarString primarycontactbirthdayVar;

        [CoreVarVal("websitebillingaddress", "String", TheFieldLength = 255, Importance = 63)]
        public VarString websitebillingaddressVar;

        [CoreVarVal("websiteshippingaddress", "String", TheFieldLength = 255, Importance = 64)]
        public VarString websiteshippingaddressVar;

        [CoreVarVal("securityid", "String", TheFieldLength = 50, Importance = 65)]
        public VarString securityidVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption = "Agent Name", Importance = 66)]
        public VarString agentnameVar;

        [CoreVarVal("primaryphoneextension", "String", TheFieldLength = 50, Caption = "Phone Ext.", Importance = 67)]
        public VarString primaryphoneextensionVar;

        [CoreVarVal("speeddialnumber", "String", TheFieldLength = 50, Caption = "Speed Dial", Importance = 68)]
        public VarString speeddialnumberVar;

        [CoreVarVal("vendoraccountnumber", "String", TheFieldLength = 50, Importance = 69)]
        public VarString vendoraccountnumberVar;

        [CoreVarVal("isvendor", "Boolean", Caption = "Is Vendor", Importance = 72)]
        public VarBoolean isvendorVar;

        [CoreVarVal("iscustomer", "Boolean", Caption = "Is Customer", Importance = 73)]
        public VarBoolean iscustomerVar;

        [CoreVarVal("systemgroups", "String", TheFieldLength = 255, Importance = 74)]
        public VarString systemgroupsVar;

        [CoreVarVal("strippedphone", "String", TheFieldLength = 50, Caption = "Stripped Phone", Importance = 75)]
        public VarString strippedphoneVar;

        [CoreVarVal("lastcontactdate", "DateTime", Caption = "Last Contact", Importance = 76)]
        public VarDateTime lastcontactdateVar;

        [CoreVarVal("websitemoniker", "String", TheFieldLength = 50, Caption = "Website Moniker", Importance = 77)]
        public VarString websitemonikerVar;

        [CoreVarVal("donotrfq", "Boolean", Caption = "Do Not Rfq", Importance = 78)]
        public VarBoolean donotrfqVar;

        [CoreVarVal("rfqemail", "String", TheFieldLength = 255, Caption = "Rfq Email Address", Importance = 79)]
        public VarString rfqemailVar;

        [CoreVarVal("confirmationcount", "Int64", Caption = "Confirmation Count", Importance = 80)]
        public VarInt64 confirmationcountVar;

        [CoreVarVal("confirmationpercent", "Double", Caption = "Confirmation Percent", Importance = 81)]
        public VarDouble confirmationpercentVar;

        [CoreVarVal("rfqcount", "Int64", Caption = "Rfq Count", Importance = 82)]
        public VarInt64 rfqcountVar;

        [CoreVarVal("ispastdue", "Boolean", Caption = "Is Past Due", Importance = 83)]
        public VarBoolean ispastdueVar;

        [CoreVarVal("wherefoundcompany", "String", TheFieldLength = 50, Caption = "Where Found", Importance = 84)]
        public VarString wherefoundcompanyVar;

        [CoreVarVal("companysize", "Int64", Caption = "Company Size", Importance = 85)]
        public VarInt64 companysizeVar;

        [CoreVarVal("creditcardnumber", "String", TheFieldLength = 50, Caption = "Credit Card Number", Importance = 86)]
        public VarString creditcardnumberVar;

        [CoreVarVal("distilledphone", "String", TheFieldLength = 50, Caption = "Distilled Phone", Importance = 87)]
        public VarString distilledphoneVar;

        [CoreVarVal("distilledfax", "String", TheFieldLength = 50, Caption = "Distilled Fax", Importance = 88)]
        public VarString distilledfaxVar;

        [CoreVarVal("prospectid", "String", TheFieldLength = 50, Caption = "Prospect Id", Importance = 89)]
        public VarString prospectidVar;

        [CoreVarVal("hasduplicates", "Boolean", Caption = "Has Duplicates", Importance = 90)]
        public VarBoolean hasduplicatesVar;

        [CoreVarVal("exportable", "Boolean", Caption = "Exportable", Importance = 91)]
        public VarBoolean exportableVar;

        [CoreVarVal("c_of_c", "Boolean", Caption = "C Of C", Importance = 92)]
        public VarBoolean c_of_cVar;

        [CoreVarVal("isdistributor", "Boolean", Caption = "Is Distributor", Importance = 93)]
        public VarBoolean isdistributorVar;

        [CoreVarVal("qb_name", "String", TheFieldLength = 255, Caption = "Qb Name", Importance = 94)]
        public VarString qb_nameVar;

        [CoreVarVal("qb_terms", "String", TheFieldLength = 255, Caption = "Qb Terms", Importance = 95)]
        public VarString qb_termsVar;

        [CoreVarVal("qb_terms_v", "String", TheFieldLength = 255, Caption = "Qb Vendor Terms", Importance = 96)]
        public VarString qb_terms_vVar;

        [CoreVarVal("qb_billing", "String", TheFieldLength = 255, Caption = "Qb Billing", Importance = 97)]
        public VarString qb_billingVar;

        [CoreVarVal("qb_shipping", "String", TheFieldLength = 255, Caption = "Qb Shipping", Importance = 98)]
        public VarString qb_shippingVar;

        [CoreVarVal("is_locked", "Boolean", Caption = "Is Locked", Importance = 99)]
        public VarBoolean is_lockedVar;

        [CoreVarVal("is_problem", "Boolean", Caption = "Is Problem", Importance = 100)]
        public VarBoolean is_problemVar;

        [CoreVarVal("archiveperiod", "Int64", Caption = "Archive Period", Importance = 101)]
        public VarInt64 archiveperiodVar;

        [CoreVarVal("archivetimespan", "String", TheFieldLength = 255, Caption = "Archive Timespan", Importance = 102)]
        public VarString archivetimespanVar;

        [CoreVarVal("delete_oldoffers", "Boolean", Caption = "Delete Old Offers", Importance = 103)]
        public VarBoolean delete_oldoffersVar;

        [CoreVarVal("default_currency", "String", TheFieldLength = 15, Caption = "Default Currency", Importance = 104)]
        public VarString default_currencyVar;

        [CoreVarVal("need_contact", "Boolean", Caption = "Need Contact", Importance = 105)]
        public VarBoolean need_contactVar;

        [CoreVarVal("needs_contact", "Boolean", Caption = "Needs Contact", Importance = 106)]
        public VarBoolean needs_contactVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption = "Absolute Type", Importance = 107)]
        public VarString abs_typeVar;

        [CoreVarVal("is_government", "Boolean", Caption = "Is Government", Importance = 108)]
        public VarBoolean is_governmentVar;

        [CoreVarVal("isindependent", "Boolean", Caption = "Is Independent", Importance = 109)]
        public VarBoolean isindependentVar;

        [CoreVarVal("isfranchise", "Boolean", Caption = "Is Franchise", Importance = 110)]
        public VarBoolean isfranchiseVar;

        [CoreVarVal("email_domain", "String", TheFieldLength = 255, Caption = "Email Domain", Importance = 111)]
        public VarString email_domainVar;

        [CoreVarVal("source", "String", TheFieldLength = 255, Caption = "Source", Importance = 112)]
        public VarString sourceVar;

        [CoreVarVal("last_marketing", "DateTime", Caption = "Last Marketing", Importance = 113)]
        public VarDateTime last_marketingVar;

        [CoreVarVal("isoem", "Boolean", Caption = "Is Oem", Importance = 114)]
        public VarBoolean isoemVar;

        [CoreVarVal("isbroker", "Boolean", Caption = "Is Broker", Importance = 115)]
        public VarBoolean isbrokerVar;

        [CoreVarVal("isweb", "Boolean", Caption = "Is Web", Importance = 116)]
        public VarBoolean iswebVar;

        [CoreVarVal("iserai", "Boolean", Caption = "Is Erai", Importance = 117)]
        public VarBoolean iseraiVar;

        [CoreVarVal("isiso", "Boolean", Caption = "Is Iso", Importance = 118)]
        public VarBoolean isisoVar;

        [CoreVarVal("iscem", "Boolean", Caption = "Is Cem", Importance = 119)]
        public VarBoolean iscemVar;

        [CoreVarVal("group_name", "String", TheFieldLength = 4096, Caption = "Group Name", Importance = 120)]
        public VarString group_nameVar;

        [CoreVarVal("cc_charge", "Double", Caption = "Cc Charge", Importance = 121)]
        public VarDouble cc_chargeVar;

        [CoreVarVal("handling_charge", "Double", Caption = "Handling Charge", Importance = 122)]
        public VarDouble handling_chargeVar;

        [CoreVarVal("cc_warning", "String", TheFieldLength = 255, Caption = "Cc Warning", Importance = 123)]
        public VarString cc_warningVar;

        [CoreVarVal("call_schedule", "String", TheFieldLength = 255, Caption = "Call Schedule", Importance = 124)]
        public VarString call_scheduleVar;

        [CoreVarVal("donotemail", "Boolean", Caption = "Do Not Email", Importance = 125)]
        public VarBoolean donotemailVar;

        [CoreVarVal("salesgenie_page", "Text", Caption = "Salesgenie Page", Importance = 126)]
        public VarText salesgenie_pageVar;

        [CoreVarVal("problem_vendor", "Boolean", Caption = "Problem Vendor", Importance = 127)]
        public VarBoolean problem_vendorVar;

        [CoreVarVal("is_qbimport", "Boolean", Caption = "Is Qb Import", Importance = 128)]
        public VarBoolean is_qbimportVar;

        [CoreVarVal("nameoncard", "String", TheFieldLength = 255, Caption = "Name On Card", Importance = 129)]
        public VarString nameoncardVar;

        [CoreVarVal("creditcardtype", "String", TheFieldLength = 255, Caption = "Credit Card Type", Importance = 130)]
        public VarString creditcardtypeVar;

        [CoreVarVal("expiration_month", "Int32", Caption = "Expiration Month", Importance = 131)]
        public VarInt32 expiration_monthVar;

        [CoreVarVal("expiration_year", "Int32", Caption = "Expiration Year", Importance = 132)]
        public VarInt32 expiration_yearVar;

        [CoreVarVal("security_code", "Int32", Caption = "Security Code", Importance = 133)]
        public VarInt32 security_codeVar;

        [CoreVarVal("cardbillingaddr", "String", TheFieldLength = 255, Caption = "Card Billing Address", Importance = 134)]
        public VarString cardbillingaddrVar;

        [CoreVarVal("cardbillingzip", "String", TheFieldLength = 255, Caption = "Card Billing Zip", Importance = 135)]
        public VarString cardbillingzipVar;

        [CoreVarVal("company_criteria", "String", TheFieldLength = 255, Caption = "Company Criteria", Importance = 136)]
        public VarString company_criteriaVar;

        [CoreVarVal("city", "String", TheFieldLength = 255, Caption = "City", Importance = 137)]
        public VarString cityVar;

        [CoreVarVal("securitycode", "String", TheFieldLength = 255, Caption = "Security Code", Importance = 138)]
        public VarString securitycodeVar;

        [CoreVarVal("islocked_purchase", "Boolean", Caption = "Islocked Purchase", Importance = 139)]
        public VarBoolean islocked_purchaseVar;

        [CoreVarVal("delete_archives", "Boolean", Caption = "Delete Archives", Importance = 140)]
        public VarBoolean delete_archivesVar;

        [CoreVarVal("delete_archives_period", "Int64", Caption = "Delete Archives Period", Importance = 141)]
        public VarInt64 delete_archives_periodVar;

        [CoreVarVal("qb_name_v", "String", TheFieldLength = 255, Caption = "Qb Name V", Importance = 142)]
        public VarString qb_name_vVar;

        [CoreVarVal("mrp_info", "String", TheFieldLength = 255, Caption = "Mrp Info", Importance = 143)]
        public VarString mrp_infoVar;

        [CoreVarVal("is_prospect", "Boolean", Caption = "Is Prospect", Importance = 144)]
        public VarBoolean is_prospectVar;

        [CoreVarVal("company_pic_type", "String", TheFieldLength = 2, Caption = "Company Pic Type", Importance = 145)]
        public VarString company_pic_typeVar;

        [CoreVarVal("bank_wire_info", "String", TheFieldLength = 255, Caption = "Bank Wire Info", Importance = 146)]
        public VarString bank_wire_infoVar;

        [CoreVarVal("po_min", "Double", Caption = "Po Min", Importance = 147)]
        public VarDouble po_minVar;

        [CoreVarVal("po_notify", "String", TheFieldLength = 8000, Caption = "Po Notify", Importance = 148)]
        public VarString po_notifyVar;

        [CoreVarVal("next_contact_date", "DateTime", Caption = "Next Contact Date", Importance = 149)]
        public VarDateTime next_contact_dateVar;

        [CoreVarVal("last_activity_date", "DateTime", Caption = "Last Activity Date", Importance = 150)]
        public VarDateTime last_activity_dateVar;

        [CoreVarVal("ignore", "Boolean", Caption = "Ignore", Importance = 151)]
        public VarBoolean ignoreVar;

        [CoreVarVal("feedback_positive", "Int32", Caption = "Feedback Positive", Importance = 152)]
        public VarInt32 feedback_positiveVar;

        [CoreVarVal("feedback_negative", "Int32", Caption = "Feedback Negative", Importance = 153)]
        public VarInt32 feedback_negativeVar;

        [CoreVarVal("feedback_neutral", "Int32", Caption = "Feedback Neutral", Importance = 154)]
        public VarInt32 feedback_neutralVar;

        [CoreVarVal("feedback_rating", "Int32", Caption = "Feedback Rating", Importance = 155)]
        public VarInt32 feedback_ratingVar;

        [CoreVarVal("lead_source", "String", TheFieldLength = 255, Caption = "Lead Source", Importance = 156)]
        public VarString lead_sourceVar;

        [CoreVarVal("last_calllog_uid", "String", TheFieldLength = 50, Caption = "Last Calllog Id", Importance = 157)]
        public VarString last_calllog_uidVar;

        [CoreVarVal("main_companyaddress_uid", "String", TheFieldLength = 50, Caption = "Main Companyaddress Id", Importance = 158)]
        public VarString main_companyaddress_uidVar;

        [CoreVarVal("industry_segment", "String", TheFieldLength = 255, Caption = "Industry Segment", Importance = 159)]
        public VarString industry_segmentVar;

        [CoreVarVal("localtime", "String", TheFieldLength = 50, Caption = "Local Time", Importance = 160)]
        public VarString localtimeVar;

        [CoreVarVal("bankname", "String", TheFieldLength = 50, Caption = "Bank Name", Importance = 161)]
        public VarString banknameVar;

        [CoreVarVal("bankaddress", "String", TheFieldLength = 255, Caption = "Bank Address", Importance = 162)]
        public VarString bankaddressVar;

        [CoreVarVal("swiftcode", "String", TheFieldLength = 50, Caption = "Swift Code", Importance = 163)]
        public VarString swiftcodeVar;

        [CoreVarVal("accountnumber", "String", TheFieldLength = 50, Caption = "Account Number", Importance = 164)]
        public VarString accountnumberVar;

        [CoreVarVal("vatnumber", "String", TheFieldLength = 255, Caption = "Vat Number", Importance = 165)]
        public VarString vatnumberVar;

        [CoreVarVal("companysizetext", "String", TheFieldLength = 255, Caption = "Company Size Text", Importance = 166)]
        public VarString companysizetextVar;

        [CoreVarVal("freeshipping", "Boolean", Caption = "Free Shipping", Importance = 167)]
        public VarBoolean freeshippingVar;

        [CoreVarVal("average_profit", "Double", Caption = "Average Profit", Importance = 168)]
        public VarDouble average_profitVar;

        [CoreVarVal("isverified", "Boolean", Caption = "Is Verified", Importance = 169)]
        public VarBoolean isverifiedVar;

        [CoreVarVal("positive_auto", "Int32", Caption = "Positive Auto", Importance = 170)]
        public VarInt32 positive_autoVar;

        [CoreVarVal("positive_manual", "Int32", Caption = "Positive Manual", Importance = 171)]
        public VarInt32 positive_manualVar;

        [CoreVarVal("negative_auto", "Int32", Caption = "Negative Auto", Importance = 172)]
        public VarInt32 negative_autoVar;

        [CoreVarVal("negative_manual", "Int32", Caption = "Negative Manual", Importance = 173)]
        public VarInt32 negative_manualVar;

        [CoreVarVal("notes_1", "String", TheFieldLength = 255, Caption = "Notes 1", Importance = 174)]
        public VarString notes_1Var;

        [CoreVarVal("notes_2", "String", TheFieldLength = 255, Caption = "Notes 2", Importance = 175)]
        public VarString notes_2Var;

        [CoreVarVal("notes_3", "String", TheFieldLength = 255, Caption = "Notes 3", Importance = 176)]
        public VarString notes_3Var;

        [CoreVarVal("notes_4", "String", TheFieldLength = 255, Caption = "Notes 4", Importance = 177)]
        public VarString notes_4Var;

        [CoreVarVal("star_rating", "Int32", Caption = "Star Rating", Importance = 178)]
        public VarInt32 star_ratingVar;

        [CoreVarVal("years_in_business", "Int32", Caption = "Years In Business", Importance = 179)]
        public VarInt32 years_in_businessVar;

        [CoreVarVal("date_assigned", "DateTime", Caption = "Date Assigned", Importance = 180)]
        public VarDateTime date_assignedVar;

        [CoreVarVal("alternate_names", "Text", Caption = "Alternate Names", Importance = 181)]
        public VarText alternate_namesVar;

        [CoreVarVal("calc_reqs", "Int64", Caption = "Calc Reqs", Importance = 182)]
        public VarInt64 calc_reqsVar;

        [CoreVarVal("calc_bids", "Int64", Caption = "Calc Bids", Importance = 183)]
        public VarInt64 calc_bidsVar;

        [CoreVarVal("calc_qquotes", "Int64", Caption = "Calc Qquotes", Importance = 184)]
        public VarInt64 calc_qquotesVar;

        [CoreVarVal("calc_fquotes", "Int64", Caption = "Calc Fquotes", Importance = 185)]
        public VarInt64 calc_fquotesVar;

        [CoreVarVal("calc_sales", "Int64", Caption = "Calc Sales", Importance = 186)]
        public VarInt64 calc_salesVar;

        [CoreVarVal("calc_purchases", "Int64", Caption = "Calc Purchases", Importance = 187)]
        public VarInt64 calc_purchasesVar;

        [CoreVarVal("bids_from_reqs", "Int64", Caption = "Bids From Reqs", Importance = 188)]
        public VarInt64 bids_from_reqsVar;

        [CoreVarVal("bell_ringers", "Int64", Caption = "Bell Ringers", Importance = 189)]
        public VarInt64 bell_ringersVar;

        [CoreVarVal("calc_calls", "Int64", Caption = "Calc Calls", Importance = 190)]
        public VarInt64 calc_callsVar;

        [CoreVarVal("calc_notes", "Int64", Caption = "Calc Notes", Importance = 191)]
        public VarInt64 calc_notesVar;

        [CoreVarVal("total_sales_amount", "Double", Caption = "Total Sales Amount", Importance = 192)]
        public VarDouble total_sales_amountVar;

        [CoreVarVal("last_req_date", "DateTime", Caption = "Last Req Date", Importance = 193)]
        public VarDateTime last_req_dateVar;

        [CoreVarVal("last_sale_date", "DateTime", Caption = "Last Sale Date", Importance = 194)]
        public VarDateTime last_sale_dateVar;

        [CoreVarVal("last_call_date", "DateTime", Caption = "Last Call Date", Importance = 195)]
        public VarDateTime last_call_dateVar;

        [CoreVarVal("last_call_notes", "String", TheFieldLength = 255, Caption = "Last Call Notes", Importance = 196)]
        public VarString last_call_notesVar;

        [CoreVarVal("last_call_result", "String", TheFieldLength = 255, Caption = "Last Call Result", Importance = 197)]
        public VarString last_call_resultVar;

        [CoreVarVal("agent", "String", TheFieldLength = 255, Caption = "Agent", Importance = 198)]
        public VarString agentVar;

        [CoreVarVal("calc_last_quote", "DateTime", Caption = "Calc Last Quote", Importance = 199)]
        public VarDateTime calc_last_quoteVar;

        [CoreVarVal("calc_invoice_line_count", "Int64", Caption = "Calc Invoice Line Count", Importance = 200)]
        public VarInt64 calc_invoice_line_countVar;

        [CoreVarVal("calc_invoice_volume", "Double", Caption = "Calc Invoice Volume", Importance = 201)]
        public VarDouble calc_invoice_volumeVar;

        [CoreVarVal("calc_vendrma_line_count", "Int64", Caption = "Calc Vendrma Line Count", Importance = 202)]
        public VarInt64 calc_vendrma_line_countVar;

        [CoreVarVal("calc_purchase_line_count", "Int64", Caption = "Calc Purchase Line Count", Importance = 203)]
        public VarInt64 calc_purchase_line_countVar;

        [CoreVarVal("calc_purchase_volume", "Double", Caption = "Calc Purchase Volume", Importance = 204)]
        public VarDouble calc_purchase_volumeVar;

        [CoreVarVal("calc_pot_invoice_line_count", "Int64", Caption = "Calc Potential Invoice Line Count", Importance = 205)]
        public VarInt64 calc_pot_invoice_line_countVar;

        [CoreVarVal("calc_pot_invoice_volume", "Double", Caption = "Calc Potential Invoice Volume", Importance = 206)]
        public VarDouble calc_pot_invoice_volumeVar;

        [CoreVarVal("calc_pot_vendrma_line_count", "Int64", Caption = "Calc Potential Vendrma Line Count", Importance = 207)]
        public VarInt64 calc_pot_vendrma_line_countVar;

        [CoreVarVal("calc_pot_purchase_line_count", "Int64", Caption = "Calc Potential Purchase Line Count", Importance = 208)]
        public VarInt64 calc_pot_purchase_line_countVar;

        [CoreVarVal("calc_pot_purchase_volume", "Double", Caption = "Calc Potential Purchase Volume", Importance = 209)]
        public VarDouble calc_pot_purchase_volumeVar;

        [CoreVarVal("last_purchase_date", "DateTime", Caption = "Last Purchase Date", Importance = 210)]
        public VarDateTime last_purchase_dateVar;

        [CoreVarVal("warranty_period", "String", TheFieldLength = 255, Caption = "Warranty Period", Importance = 211)]
        public VarString warranty_periodVar;

        [CoreVarVal("warranty_period_vendor", "String", TheFieldLength = 255, Caption = "Warranty Period Vendor", Importance = 212)]
        public VarString warranty_period_vendorVar;

        [CoreVarVal("balance_owed_vendor", "Double", Caption = "Balance Owed Vendor", Importance = 213)]
        public VarDouble balance_owed_vendorVar;

        [CoreVarVal("balance_owed_customer", "Double", Caption = "Balance Owed Customer", Importance = 214)]
        public VarDouble balance_owed_customerVar;

        [CoreVarVal("Products_Display", "Boolean", Caption = "Products_Display", Importance = 215)]
        public VarBoolean Products_DisplayVar;

        [CoreVarVal("Products_SSD", "Boolean", Caption = "Products_SSD", Importance = 216)]
        public VarBoolean Products_SSDVar;

        [CoreVarVal("Products_Cabling", "Boolean", Caption = "Products_Cabling", Importance = 217)]
        public VarBoolean Products_CablingVar;

        [CoreVarVal("Products_Interconnect", "Boolean", Caption = "Products_Interconnect", Importance = 218)]
        public VarBoolean Products_InterconnectVar;

        [CoreVarVal("Products_CrystalOsc", "Boolean", Caption = "Products_CrystalOsc", Importance = 219)]
        public VarBoolean Products_CrystalOscVar;

        [CoreVarVal("Products_Relay", "Boolean", Caption = "Products_Relay", Importance = 220)]
        public VarBoolean Products_RelayVar;

        [CoreVarVal("Products_PowerSupply", "Boolean", Caption = "Products_PowerSupply", Importance = 220)]
        public VarBoolean Products_PowerSupplyVar;

        [CoreVarVal("Products_OpticalTransceiver", "Boolean", Caption = "Products_OpticalTransceiver", Importance = 220)]
        public VarBoolean Products_OpticalTransceiverVar;

        [CoreVarVal("Products_Components", "Boolean", Caption = "Products_Components", Importance = 220)]
        public VarBoolean Products_ComponentsVar;

        [CoreVarVal("SOA_components", "Boolean", Caption = "SOA Components", Importance = 221)]
        public VarBoolean SOA_componentsVar;

        [CoreVarVal("SOA_services", "Boolean", Caption = "SOA Services", Importance = 222)]
        public VarBoolean SOA_servicesVar;

        [CoreVarVal("has_financials", "Boolean", Caption = "Has Financials", Importance = 223)]
        public VarBoolean has_financialsVar;

        [CoreVarVal("vetted_date", "DateTime", Caption = "Vetted Date", Importance = 224)]
        public VarDateTime vetted_dateVar;

        [CoreVarVal("vetted_by", "String", TheFieldLength = 255, Caption = "Vetted By", Importance = 225)]
        public VarString vetted_byVar;

        [CoreVarVal("is_vetted", "Boolean", Caption = "Is Vetted", Importance = 227)]
        public VarBoolean is_vettedVar;

        [CoreVarVal("customerTermsMemo", "Text", Caption = "Customer Terms Memo", Importance = 228)]
        public VarText customerTermsMemoVar;

        [CoreVarVal("vendorTermsMemo", "Text", Caption = "Vendor Terms Memo", Importance = 228)]
        public VarText vendorTermsMemoVar;

        [CoreVarVal("created_by_name", "String", TheFieldLength = 255, Caption = "Created by Name", Importance = 229)]
        public VarString created_by_nameVar;

        [CoreVarVal("created_by_uid", "String", TheFieldLength = 50, Caption = "Created by Id", Importance = 230)]
        public VarString created_by_uidVar;

        [CoreVarVal("GCAT_required", "Boolean", Caption = "GCAT Testing Required for all orders", Importance = 231)]
        public VarBoolean GCAT_requiredVar;

        [CoreVarVal("qb_company_ListID", "String", TheFieldLength = 50, Importance = 232)]
        public VarString qb_company_ListIDVar;

        [CoreVarVal("qb_company_type", "String", TheFieldLength = 50, Importance = 232)]
        public VarString qb_company_typeVar;

        [CoreVarVal("qb_company_ListID_vendor", "String", TheFieldLength = 50, Importance = 233)]
        public VarString qb_company_ListID_vendorVar;

        [CoreVarVal("hubspot_company_id", "Int64", Caption = "hubspot_company_id", Importance = 234)]
        public VarInt64 hubspot_company_idVar;

        [CoreVarVal("split_commission_agent_name", "String", TheFieldLength = 200, Importance = 235)]
        public VarString split_commission_agent_nameVar;

        [CoreVarVal("split_commission_agent_uid", "String", TheFieldLength = 200, Importance = 236)]
        public VarString split_commission_agent_uidVar;

        [CoreVarVal("split_commission_default_type", "String", TheFieldLength = 20, Importance = 237)]
        public VarString split_commission_default_typeVar;

        [CoreVarVal("split_commission_date_active", "DateTime", TheFieldLength = 20, Importance = 238)]
        public VarDateTime split_commission_date_activeVar;

        [CoreVarVal("split_commission_ID", "String", TheFieldLength = 100, Caption = "Split Commissin Linkage", Importance = 146)]
        public VarString split_commission_IDVar;

        public company_auto()
        {
            StaticInit();
            the_mfg_link_uidVar = new VarString(this, the_mfg_link_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            contactfrequencyVar = new VarString(this, contactfrequencyAttribute);
            companytypeVar = new VarString(this, companytypeAttribute);
            primarycontactVar = new VarString(this, primarycontactAttribute);
            divisionofVar = new VarString(this, divisionofAttribute);
            taxidVar = new VarString(this, taxidAttribute);
            termsascustomerVar = new VarString(this, termsascustomerAttribute);
            creditascustomerVar = new VarDouble(this, creditascustomerAttribute);
            pastduelimitascustomerVar = new VarInt32(this, pastduelimitascustomerAttribute);
            creditascustomercurrVar = new VarString(this, creditascustomercurrAttribute);
            creditasvendorcurrVar = new VarString(this, creditasvendorcurrAttribute);
            creditasvendorVar = new VarDouble(this, creditasvendorAttribute);
            pastduelimitasvendorVar = new VarInt32(this, pastduelimitasvendorAttribute);
            termsasvendorVar = new VarString(this, termsasvendorAttribute);
            freightbillingVar = new VarString(this, freightbillingAttribute);
            shipviacustomerVar = new VarString(this, shipviacustomerAttribute);
            shipviavendorVar = new VarString(this, shipviavendorAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            notetextVar = new VarText(this, notetextAttribute);
            primaryphoneVar = new VarString(this, primaryphoneAttribute);
            primaryfaxVar = new VarString(this, primaryfaxAttribute);
            primaryemailaddressVar = new VarString(this, primaryemailaddressAttribute);
            primarywebaddressVar = new VarString(this, primarywebaddressAttribute);
            zipcodeVar = new VarString(this, zipcodeAttribute);
            statenameVar = new VarString(this, statenameAttribute);
            countryVar = new VarString(this, countryAttribute);
            isinternationalVar = new VarBoolean(this, isinternationalAttribute);
            oncreditholdVar = new VarBoolean(this, oncreditholdAttribute);
            isactiveVar = new VarBoolean(this, isactiveAttribute);
            companynumberVar = new VarInt32(this, companynumberAttribute);
            companycodeVar = new VarString(this, companycodeAttribute);
            internetusernameVar = new VarString(this, internetusernameAttribute);
            internetpasswordVar = new VarString(this, internetpasswordAttribute);
            importidVar = new VarString(this, importidAttribute);
            countryindexVar = new VarInt32(this, countryindexAttribute);
            alias1Var = new VarString(this, alias1Attribute);
            alias2Var = new VarString(this, alias2Attribute);
            contactmethodVar = new VarString(this, contactmethodAttribute);
            legacyidVar = new VarString(this, legacyidAttribute);
            textemailonlyVar = new VarBoolean(this, textemailonlyAttribute);
            distillednameVar = new VarString(this, distillednameAttribute);
            legacyagentVar = new VarString(this, legacyagentAttribute);
            confirmationrequestdateVar = new VarDateTime(this, confirmationrequestdateAttribute);
            pricelevelVar = new VarInt32(this, pricelevelAttribute);
            logopathVar = new VarString(this, logopathAttribute);
            websitegreetingVar = new VarString(this, websitegreetingAttribute);
            instockonlyVar = new VarBoolean(this, instockonlyAttribute);
            internalcompanynameVar = new VarString(this, internalcompanynameAttribute);
            companyratingVar = new VarInt32(this, companyratingAttribute);
            specialtyVar = new VarString(this, specialtyAttribute);
            inventorylinesVar = new VarInt64(this, inventorylinesAttribute);
            timeoffsetVar = new VarInt32(this, timeoffsetAttribute);
            timezoneVar = new VarString(this, timezoneAttribute);
            contactfunctionVar = new VarString(this, contactfunctionAttribute);
            alternaterfqaddressVar = new VarString(this, alternaterfqaddressAttribute);
            alternateconfirmationaddressVar = new VarString(this, alternateconfirmationaddressAttribute);
            websiteresponseVar = new VarString(this, websiteresponseAttribute);
            primarycontactbirthdayVar = new VarString(this, primarycontactbirthdayAttribute);
            websitebillingaddressVar = new VarString(this, websitebillingaddressAttribute);
            websiteshippingaddressVar = new VarString(this, websiteshippingaddressAttribute);
            securityidVar = new VarString(this, securityidAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            primaryphoneextensionVar = new VarString(this, primaryphoneextensionAttribute);
            speeddialnumberVar = new VarString(this, speeddialnumberAttribute);
            vendoraccountnumberVar = new VarString(this, vendoraccountnumberAttribute);
            isvendorVar = new VarBoolean(this, isvendorAttribute);
            iscustomerVar = new VarBoolean(this, iscustomerAttribute);
            systemgroupsVar = new VarString(this, systemgroupsAttribute);
            strippedphoneVar = new VarString(this, strippedphoneAttribute);
            lastcontactdateVar = new VarDateTime(this, lastcontactdateAttribute);
            websitemonikerVar = new VarString(this, websitemonikerAttribute);
            donotrfqVar = new VarBoolean(this, donotrfqAttribute);
            rfqemailVar = new VarString(this, rfqemailAttribute);
            confirmationcountVar = new VarInt64(this, confirmationcountAttribute);
            confirmationpercentVar = new VarDouble(this, confirmationpercentAttribute);
            rfqcountVar = new VarInt64(this, rfqcountAttribute);
            ispastdueVar = new VarBoolean(this, ispastdueAttribute);
            wherefoundcompanyVar = new VarString(this, wherefoundcompanyAttribute);
            companysizeVar = new VarInt64(this, companysizeAttribute);
            creditcardnumberVar = new VarString(this, creditcardnumberAttribute);
            distilledphoneVar = new VarString(this, distilledphoneAttribute);
            distilledfaxVar = new VarString(this, distilledfaxAttribute);
            prospectidVar = new VarString(this, prospectidAttribute);
            hasduplicatesVar = new VarBoolean(this, hasduplicatesAttribute);
            exportableVar = new VarBoolean(this, exportableAttribute);
            c_of_cVar = new VarBoolean(this, c_of_cAttribute);
            isdistributorVar = new VarBoolean(this, isdistributorAttribute);
            qb_nameVar = new VarString(this, qb_nameAttribute);
            qb_termsVar = new VarString(this, qb_termsAttribute);
            qb_terms_vVar = new VarString(this, qb_terms_vAttribute);
            qb_billingVar = new VarString(this, qb_billingAttribute);
            qb_shippingVar = new VarString(this, qb_shippingAttribute);
            is_lockedVar = new VarBoolean(this, is_lockedAttribute);
            is_problemVar = new VarBoolean(this, is_problemAttribute);
            archiveperiodVar = new VarInt64(this, archiveperiodAttribute);
            archivetimespanVar = new VarString(this, archivetimespanAttribute);
            delete_oldoffersVar = new VarBoolean(this, delete_oldoffersAttribute);
            default_currencyVar = new VarString(this, default_currencyAttribute);
            need_contactVar = new VarBoolean(this, need_contactAttribute);
            needs_contactVar = new VarBoolean(this, needs_contactAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            is_governmentVar = new VarBoolean(this, is_governmentAttribute);
            isindependentVar = new VarBoolean(this, isindependentAttribute);
            isfranchiseVar = new VarBoolean(this, isfranchiseAttribute);
            email_domainVar = new VarString(this, email_domainAttribute);
            sourceVar = new VarString(this, sourceAttribute);
            last_marketingVar = new VarDateTime(this, last_marketingAttribute);
            isoemVar = new VarBoolean(this, isoemAttribute);
            isbrokerVar = new VarBoolean(this, isbrokerAttribute);
            iswebVar = new VarBoolean(this, iswebAttribute);
            iseraiVar = new VarBoolean(this, iseraiAttribute);
            isisoVar = new VarBoolean(this, isisoAttribute);
            iscemVar = new VarBoolean(this, iscemAttribute);
            group_nameVar = new VarString(this, group_nameAttribute);
            cc_chargeVar = new VarDouble(this, cc_chargeAttribute);
            handling_chargeVar = new VarDouble(this, handling_chargeAttribute);
            cc_warningVar = new VarString(this, cc_warningAttribute);
            call_scheduleVar = new VarString(this, call_scheduleAttribute);
            donotemailVar = new VarBoolean(this, donotemailAttribute);
            salesgenie_pageVar = new VarText(this, salesgenie_pageAttribute);
            problem_vendorVar = new VarBoolean(this, problem_vendorAttribute);
            is_qbimportVar = new VarBoolean(this, is_qbimportAttribute);
            nameoncardVar = new VarString(this, nameoncardAttribute);
            creditcardtypeVar = new VarString(this, creditcardtypeAttribute);
            expiration_monthVar = new VarInt32(this, expiration_monthAttribute);
            expiration_yearVar = new VarInt32(this, expiration_yearAttribute);
            security_codeVar = new VarInt32(this, security_codeAttribute);
            cardbillingaddrVar = new VarString(this, cardbillingaddrAttribute);
            cardbillingzipVar = new VarString(this, cardbillingzipAttribute);
            company_criteriaVar = new VarString(this, company_criteriaAttribute);
            cityVar = new VarString(this, cityAttribute);
            securitycodeVar = new VarString(this, securitycodeAttribute);
            islocked_purchaseVar = new VarBoolean(this, islocked_purchaseAttribute);
            delete_archivesVar = new VarBoolean(this, delete_archivesAttribute);
            delete_archives_periodVar = new VarInt64(this, delete_archives_periodAttribute);
            qb_name_vVar = new VarString(this, qb_name_vAttribute);
            mrp_infoVar = new VarString(this, mrp_infoAttribute);
            is_prospectVar = new VarBoolean(this, is_prospectAttribute);
            company_pic_typeVar = new VarString(this, company_pic_typeAttribute);
            bank_wire_infoVar = new VarString(this, bank_wire_infoAttribute);
            po_minVar = new VarDouble(this, po_minAttribute);
            po_notifyVar = new VarString(this, po_notifyAttribute);
            next_contact_dateVar = new VarDateTime(this, next_contact_dateAttribute);
            last_activity_dateVar = new VarDateTime(this, last_activity_dateAttribute);
            ignoreVar = new VarBoolean(this, ignoreAttribute);
            feedback_positiveVar = new VarInt32(this, feedback_positiveAttribute);
            feedback_negativeVar = new VarInt32(this, feedback_negativeAttribute);
            feedback_neutralVar = new VarInt32(this, feedback_neutralAttribute);
            feedback_ratingVar = new VarInt32(this, feedback_ratingAttribute);
            lead_sourceVar = new VarString(this, lead_sourceAttribute);
            last_calllog_uidVar = new VarString(this, last_calllog_uidAttribute);
            main_companyaddress_uidVar = new VarString(this, main_companyaddress_uidAttribute);
            industry_segmentVar = new VarString(this, industry_segmentAttribute);
            localtimeVar = new VarString(this, localtimeAttribute);
            banknameVar = new VarString(this, banknameAttribute);
            bankaddressVar = new VarString(this, bankaddressAttribute);
            swiftcodeVar = new VarString(this, swiftcodeAttribute);
            accountnumberVar = new VarString(this, accountnumberAttribute);
            vatnumberVar = new VarString(this, vatnumberAttribute);
            companysizetextVar = new VarString(this, companysizetextAttribute);
            freeshippingVar = new VarBoolean(this, freeshippingAttribute);
            average_profitVar = new VarDouble(this, average_profitAttribute);
            isverifiedVar = new VarBoolean(this, isverifiedAttribute);
            positive_autoVar = new VarInt32(this, positive_autoAttribute);
            positive_manualVar = new VarInt32(this, positive_manualAttribute);
            negative_autoVar = new VarInt32(this, negative_autoAttribute);
            negative_manualVar = new VarInt32(this, negative_manualAttribute);
            notes_1Var = new VarString(this, notes_1Attribute);
            notes_2Var = new VarString(this, notes_2Attribute);
            notes_3Var = new VarString(this, notes_3Attribute);
            notes_4Var = new VarString(this, notes_4Attribute);
            star_ratingVar = new VarInt32(this, star_ratingAttribute);
            years_in_businessVar = new VarInt32(this, years_in_businessAttribute);
            date_assignedVar = new VarDateTime(this, date_assignedAttribute);
            alternate_namesVar = new VarText(this, alternate_namesAttribute);
            calc_reqsVar = new VarInt64(this, calc_reqsAttribute);
            calc_bidsVar = new VarInt64(this, calc_bidsAttribute);
            calc_qquotesVar = new VarInt64(this, calc_qquotesAttribute);
            calc_fquotesVar = new VarInt64(this, calc_fquotesAttribute);
            calc_salesVar = new VarInt64(this, calc_salesAttribute);
            calc_purchasesVar = new VarInt64(this, calc_purchasesAttribute);
            bids_from_reqsVar = new VarInt64(this, bids_from_reqsAttribute);
            bell_ringersVar = new VarInt64(this, bell_ringersAttribute);
            calc_callsVar = new VarInt64(this, calc_callsAttribute);
            calc_notesVar = new VarInt64(this, calc_notesAttribute);
            total_sales_amountVar = new VarDouble(this, total_sales_amountAttribute);
            last_req_dateVar = new VarDateTime(this, last_req_dateAttribute);
            last_sale_dateVar = new VarDateTime(this, last_sale_dateAttribute);
            last_call_dateVar = new VarDateTime(this, last_call_dateAttribute);
            last_call_notesVar = new VarString(this, last_call_notesAttribute);
            last_call_resultVar = new VarString(this, last_call_resultAttribute);
            agentVar = new VarString(this, agentAttribute);
            calc_last_quoteVar = new VarDateTime(this, calc_last_quoteAttribute);
            calc_invoice_line_countVar = new VarInt64(this, calc_invoice_line_countAttribute);
            calc_invoice_volumeVar = new VarDouble(this, calc_invoice_volumeAttribute);
            calc_vendrma_line_countVar = new VarInt64(this, calc_vendrma_line_countAttribute);
            calc_purchase_line_countVar = new VarInt64(this, calc_purchase_line_countAttribute);
            calc_purchase_volumeVar = new VarDouble(this, calc_purchase_volumeAttribute);
            calc_pot_invoice_line_countVar = new VarInt64(this, calc_pot_invoice_line_countAttribute);
            calc_pot_invoice_volumeVar = new VarDouble(this, calc_pot_invoice_volumeAttribute);
            calc_pot_vendrma_line_countVar = new VarInt64(this, calc_pot_vendrma_line_countAttribute);
            calc_pot_purchase_line_countVar = new VarInt64(this, calc_pot_purchase_line_countAttribute);
            calc_pot_purchase_volumeVar = new VarDouble(this, calc_pot_purchase_volumeAttribute);
            last_purchase_dateVar = new VarDateTime(this, last_purchase_dateAttribute);
            warranty_periodVar = new VarString(this, warranty_periodAttribute);
            warranty_period_vendorVar = new VarString(this, warranty_period_vendorAttribute);
            balance_owed_vendorVar = new VarDouble(this, balance_owed_vendorAttribute);
            balance_owed_customerVar = new VarDouble(this, balance_owed_customerAttribute);
            Products_DisplayVar = new VarBoolean(this, Products_DisplayAttribute);
            Products_SSDVar = new VarBoolean(this, Products_SSDAttribute);
            Products_CablingVar = new VarBoolean(this, Products_CablingAttribute);
            Products_InterconnectVar = new VarBoolean(this, Products_InterconnectAttribute);
            Products_CrystalOscVar = new VarBoolean(this, Products_CrystalOscAttribute);
            Products_RelayVar = new VarBoolean(this, Products_RelayAttribute);
            Products_PowerSupplyVar = new VarBoolean(this, Products_PowerSupplyAttribute);
            Products_OpticalTransceiverVar = new VarBoolean(this, Products_OpticalTransceiverAttribute);
            Products_ComponentsVar = new VarBoolean(this, Products_ComponentsAttribute);
            SOA_componentsVar = new VarBoolean(this, SOA_componentsAttribute);
            SOA_servicesVar = new VarBoolean(this, SOA_servicesAttribute);
            //KT Refactored from RzSensible
            has_financialsVar = new VarBoolean(this, has_financialsAttribute);
            vetted_dateVar = new VarDateTime(this, vetted_dateAttribute);
            vetted_byVar = new VarString(this, vetted_byAttribute);
            is_vettedVar = new VarBoolean(this, is_vettedAttribute);
            customerTermsMemoVar = new VarText(this, customerTermsMemoAttribute);
            vendorTermsMemoVar = new VarText(this, vendorTermsMemoAttribute);
            created_by_nameVar = new VarString(this, created_by_nameAttribute);
            created_by_uidVar = new VarString(this, created_by_uidAttribute);
            GCAT_requiredVar = new VarBoolean(this, GCAT_requiredAttribute);
            qb_company_ListIDVar = new VarString(this, qb_company_ListIDAttribute);
            qb_company_typeVar = new VarString(this, qb_company_typeAttribute);
            qb_company_ListID_vendorVar = new VarString(this, qb_company_ListID_vendorAttribute);
            hubspot_company_idVar = new VarInt64(this, hubspot_company_idAttribute);
            split_commission_agent_nameVar = new VarString(this, split_commission_agent_nameAttribute);
            split_commission_agent_uidVar = new VarString(this, split_commission_agent_uidAttribute);
            split_commission_default_typeVar = new VarString(this, split_commission_default_typeAttribute);
            split_commission_date_activeVar = new VarDateTime(this, split_commission_date_activeAttribute);
            split_commission_IDVar = new VarString(this, split_commission_IDAttribute);




        }

        public override string ClassId
        { get { return "company"; } }

        public String the_mfg_link_uid
        {
            get { return (String)the_mfg_link_uidVar.Value; }
            set { the_mfg_link_uidVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get { return (String)base_mc_user_uidVar.Value; }
            set { base_mc_user_uidVar.Value = value; }
        }

        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }

        public String contactfrequency
        {
            get { return (String)contactfrequencyVar.Value; }
            set { contactfrequencyVar.Value = value; }
        }

        public String companytype
        {
            get { return (String)companytypeVar.Value; }
            set { companytypeVar.Value = value; }
        }

        public String primarycontact
        {
            get { return (String)primarycontactVar.Value; }
            set { primarycontactVar.Value = value; }
        }

        public String divisionof
        {
            get { return (String)divisionofVar.Value; }
            set { divisionofVar.Value = value; }
        }

        public String taxid
        {
            get { return (String)taxidVar.Value; }
            set { taxidVar.Value = value; }
        }

        public String termsascustomer
        {
            get { return (String)termsascustomerVar.Value; }
            set { termsascustomerVar.Value = value; }
        }

        public Double creditascustomer
        {
            get { return (Double)creditascustomerVar.Value; }
            set { creditascustomerVar.Value = value; }
        }

        public Int32 pastduelimitascustomer
        {
            get { return (Int32)pastduelimitascustomerVar.Value; }
            set { pastduelimitascustomerVar.Value = value; }
        }

        public String creditascustomercurr
        {
            get { return (String)creditascustomercurrVar.Value; }
            set { creditascustomercurrVar.Value = value; }
        }

        public String creditasvendorcurr
        {
            get { return (String)creditasvendorcurrVar.Value; }
            set { creditasvendorcurrVar.Value = value; }
        }

        public Double creditasvendor
        {
            get { return (Double)creditasvendorVar.Value; }
            set { creditasvendorVar.Value = value; }
        }

        public Int32 pastduelimitasvendor
        {
            get { return (Int32)pastduelimitasvendorVar.Value; }
            set { pastduelimitasvendorVar.Value = value; }
        }

        public String termsasvendor
        {
            get { return (String)termsasvendorVar.Value; }
            set { termsasvendorVar.Value = value; }
        }

        public String freightbilling
        {
            get { return (String)freightbillingVar.Value; }
            set { freightbillingVar.Value = value; }
        }

        public String shipviacustomer
        {
            get { return (String)shipviacustomerVar.Value; }
            set { shipviacustomerVar.Value = value; }
        }

        public String shipviavendor
        {
            get { return (String)shipviavendorVar.Value; }
            set { shipviavendorVar.Value = value; }
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

        public String description
        {
            get { return (String)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public String notetext
        {
            get { return (String)notetextVar.Value; }
            set { notetextVar.Value = value; }
        }

        public String primaryphone
        {
            get { return (String)primaryphoneVar.Value; }
            set { primaryphoneVar.Value = value; }
        }

        public String primaryfax
        {
            get { return (String)primaryfaxVar.Value; }
            set { primaryfaxVar.Value = value; }
        }

        public String primaryemailaddress
        {
            get { return (String)primaryemailaddressVar.Value; }
            set { primaryemailaddressVar.Value = value; }
        }

        public String primarywebaddress
        {
            get { return (String)primarywebaddressVar.Value; }
            set { primarywebaddressVar.Value = value; }
        }

        public String zipcode
        {
            get { return (String)zipcodeVar.Value; }
            set { zipcodeVar.Value = value; }
        }

        public String statename
        {
            get { return (String)statenameVar.Value; }
            set { statenameVar.Value = value; }
        }

        public String country
        {
            get { return (String)countryVar.Value; }
            set { countryVar.Value = value; }
        }

        public Boolean isinternational
        {
            get { return (Boolean)isinternationalVar.Value; }
            set { isinternationalVar.Value = value; }
        }

        public Boolean oncredithold
        {
            get { return (Boolean)oncreditholdVar.Value; }
            set { oncreditholdVar.Value = value; }
        }

        public Boolean isactive
        {
            get { return (Boolean)isactiveVar.Value; }
            set { isactiveVar.Value = value; }
        }

        public Int32 companynumber
        {
            get { return (Int32)companynumberVar.Value; }
            set { companynumberVar.Value = value; }
        }

        public String companycode
        {
            get { return (String)companycodeVar.Value; }
            set { companycodeVar.Value = value; }
        }

        public String internetusername
        {
            get { return (String)internetusernameVar.Value; }
            set { internetusernameVar.Value = value; }
        }

        public String internetpassword
        {
            get { return (String)internetpasswordVar.Value; }
            set { internetpasswordVar.Value = value; }
        }

        public String importid
        {
            get { return (String)importidVar.Value; }
            set { importidVar.Value = value; }
        }

        public Int32 countryindex
        {
            get { return (Int32)countryindexVar.Value; }
            set { countryindexVar.Value = value; }
        }

        public String alias1
        {
            get { return (String)alias1Var.Value; }
            set { alias1Var.Value = value; }
        }

        public String alias2
        {
            get { return (String)alias2Var.Value; }
            set { alias2Var.Value = value; }
        }

        public String contactmethod
        {
            get { return (String)contactmethodVar.Value; }
            set { contactmethodVar.Value = value; }
        }

        public String legacyid
        {
            get { return (String)legacyidVar.Value; }
            set { legacyidVar.Value = value; }
        }

        public Boolean textemailonly
        {
            get { return (Boolean)textemailonlyVar.Value; }
            set { textemailonlyVar.Value = value; }
        }

        public String distilledname
        {
            get { return (String)distillednameVar.Value; }
            set { distillednameVar.Value = value; }
        }

        public String legacyagent
        {
            get { return (String)legacyagentVar.Value; }
            set { legacyagentVar.Value = value; }
        }

        public DateTime confirmationrequestdate
        {
            get { return (DateTime)confirmationrequestdateVar.Value; }
            set { confirmationrequestdateVar.Value = value; }
        }

        public Int32 pricelevel
        {
            get { return (Int32)pricelevelVar.Value; }
            set { pricelevelVar.Value = value; }
        }

        public String logopath
        {
            get { return (String)logopathVar.Value; }
            set { logopathVar.Value = value; }
        }

        public String websitegreeting
        {
            get { return (String)websitegreetingVar.Value; }
            set { websitegreetingVar.Value = value; }
        }

        public Boolean instockonly
        {
            get { return (Boolean)instockonlyVar.Value; }
            set { instockonlyVar.Value = value; }
        }

        public String internalcompanyname
        {
            get { return (String)internalcompanynameVar.Value; }
            set { internalcompanynameVar.Value = value; }
        }

        public Int32 companyrating
        {
            get { return (Int32)companyratingVar.Value; }
            set { companyratingVar.Value = value; }
        }

        public String specialty
        {
            get { return (String)specialtyVar.Value; }
            set { specialtyVar.Value = value; }
        }

        public Int64 inventorylines
        {
            get { return (Int64)inventorylinesVar.Value; }
            set { inventorylinesVar.Value = value; }
        }

        public Int32 timeoffset
        {
            get { return (Int32)timeoffsetVar.Value; }
            set { timeoffsetVar.Value = value; }
        }

        public String timezone
        {
            get { return (String)timezoneVar.Value; }
            set { timezoneVar.Value = value; }
        }

        public String contactfunction
        {
            get { return (String)contactfunctionVar.Value; }
            set { contactfunctionVar.Value = value; }
        }

        public String alternaterfqaddress
        {
            get { return (String)alternaterfqaddressVar.Value; }
            set { alternaterfqaddressVar.Value = value; }
        }

        public String alternateconfirmationaddress
        {
            get { return (String)alternateconfirmationaddressVar.Value; }
            set { alternateconfirmationaddressVar.Value = value; }
        }

        public String websiteresponse
        {
            get { return (String)websiteresponseVar.Value; }
            set { websiteresponseVar.Value = value; }
        }

        public String primarycontactbirthday
        {
            get { return (String)primarycontactbirthdayVar.Value; }
            set { primarycontactbirthdayVar.Value = value; }
        }

        public String websitebillingaddress
        {
            get { return (String)websitebillingaddressVar.Value; }
            set { websitebillingaddressVar.Value = value; }
        }

        public String websiteshippingaddress
        {
            get { return (String)websiteshippingaddressVar.Value; }
            set { websiteshippingaddressVar.Value = value; }
        }

        public String securityid
        {
            get { return (String)securityidVar.Value; }
            set { securityidVar.Value = value; }
        }

        public String agentname
        {
            get { return (String)agentnameVar.Value; }
            set { agentnameVar.Value = value; }
        }

        public String primaryphoneextension
        {
            get { return (String)primaryphoneextensionVar.Value; }
            set { primaryphoneextensionVar.Value = value; }
        }

        public String speeddialnumber
        {
            get { return (String)speeddialnumberVar.Value; }
            set { speeddialnumberVar.Value = value; }
        }

        public String vendoraccountnumber
        {
            get { return (String)vendoraccountnumberVar.Value; }
            set { vendoraccountnumberVar.Value = value; }
        }

        public Boolean isvendor
        {
            get { return (Boolean)isvendorVar.Value; }
            set { isvendorVar.Value = value; }
        }

        public Boolean iscustomer
        {
            get { return (Boolean)iscustomerVar.Value; }
            set { iscustomerVar.Value = value; }
        }

        public String systemgroups
        {
            get { return (String)systemgroupsVar.Value; }
            set { systemgroupsVar.Value = value; }
        }

        public String strippedphone
        {
            get { return (String)strippedphoneVar.Value; }
            set { strippedphoneVar.Value = value; }
        }

        public DateTime lastcontactdate
        {
            get { return (DateTime)lastcontactdateVar.Value; }
            set { lastcontactdateVar.Value = value; }
        }

        public String websitemoniker
        {
            get { return (String)websitemonikerVar.Value; }
            set { websitemonikerVar.Value = value; }
        }

        public Boolean donotrfq
        {
            get { return (Boolean)donotrfqVar.Value; }
            set { donotrfqVar.Value = value; }
        }

        public String rfqemail
        {
            get { return (String)rfqemailVar.Value; }
            set { rfqemailVar.Value = value; }
        }

        public Int64 confirmationcount
        {
            get { return (Int64)confirmationcountVar.Value; }
            set { confirmationcountVar.Value = value; }
        }

        public Double confirmationpercent
        {
            get { return (Double)confirmationpercentVar.Value; }
            set { confirmationpercentVar.Value = value; }
        }

        public Int64 rfqcount
        {
            get { return (Int64)rfqcountVar.Value; }
            set { rfqcountVar.Value = value; }
        }

        public Boolean ispastdue
        {
            get { return (Boolean)ispastdueVar.Value; }
            set { ispastdueVar.Value = value; }
        }

        public String wherefoundcompany
        {
            get { return (String)wherefoundcompanyVar.Value; }
            set { wherefoundcompanyVar.Value = value; }
        }

        public Int64 companysize
        {
            get { return (Int64)companysizeVar.Value; }
            set { companysizeVar.Value = value; }
        }

        public String creditcardnumber
        {
            get { return (String)creditcardnumberVar.Value; }
            set { creditcardnumberVar.Value = value; }
        }

        public String distilledphone
        {
            get { return (String)distilledphoneVar.Value; }
            set { distilledphoneVar.Value = value; }
        }

        public String distilledfax
        {
            get { return (String)distilledfaxVar.Value; }
            set { distilledfaxVar.Value = value; }
        }

        public String prospectid
        {
            get { return (String)prospectidVar.Value; }
            set { prospectidVar.Value = value; }
        }

        public Boolean hasduplicates
        {
            get { return (Boolean)hasduplicatesVar.Value; }
            set { hasduplicatesVar.Value = value; }
        }

        public Boolean exportable
        {
            get { return (Boolean)exportableVar.Value; }
            set { exportableVar.Value = value; }
        }

        public Boolean c_of_c
        {
            get { return (Boolean)c_of_cVar.Value; }
            set { c_of_cVar.Value = value; }
        }

        public Boolean isdistributor
        {
            get { return (Boolean)isdistributorVar.Value; }
            set { isdistributorVar.Value = value; }
        }

        public String qb_name
        {
            get { return (String)qb_nameVar.Value; }
            set { qb_nameVar.Value = value; }
        }

        public String qb_terms
        {
            get { return (String)qb_termsVar.Value; }
            set { qb_termsVar.Value = value; }
        }

        public String qb_terms_v
        {
            get { return (String)qb_terms_vVar.Value; }
            set { qb_terms_vVar.Value = value; }
        }

        public String qb_billing
        {
            get { return (String)qb_billingVar.Value; }
            set { qb_billingVar.Value = value; }
        }

        public String qb_shipping
        {
            get { return (String)qb_shippingVar.Value; }
            set { qb_shippingVar.Value = value; }
        }

        public Boolean is_locked
        {
            get { return (Boolean)is_lockedVar.Value; }
            set { is_lockedVar.Value = value; }
        }

        public Boolean is_problem
        {
            get { return (Boolean)is_problemVar.Value; }
            set { is_problemVar.Value = value; }
        }

        public Int64 archiveperiod
        {
            get { return (Int64)archiveperiodVar.Value; }
            set { archiveperiodVar.Value = value; }
        }

        public String archivetimespan
        {
            get { return (String)archivetimespanVar.Value; }
            set { archivetimespanVar.Value = value; }
        }

        public Boolean delete_oldoffers
        {
            get { return (Boolean)delete_oldoffersVar.Value; }
            set { delete_oldoffersVar.Value = value; }
        }

        public String default_currency
        {
            get { return (String)default_currencyVar.Value; }
            set { default_currencyVar.Value = value; }
        }

        public Boolean need_contact
        {
            get { return (Boolean)need_contactVar.Value; }
            set { need_contactVar.Value = value; }
        }

        public Boolean needs_contact
        {
            get { return (Boolean)needs_contactVar.Value; }
            set { needs_contactVar.Value = value; }
        }

        public String abs_type
        {
            get { return (String)abs_typeVar.Value; }
            set { abs_typeVar.Value = value; }
        }

        public Boolean is_government
        {
            get { return (Boolean)is_governmentVar.Value; }
            set { is_governmentVar.Value = value; }
        }

        public Boolean isindependent
        {
            get { return (Boolean)isindependentVar.Value; }
            set { isindependentVar.Value = value; }
        }

        public Boolean isfranchise
        {
            get { return (Boolean)isfranchiseVar.Value; }
            set { isfranchiseVar.Value = value; }
        }

        public String email_domain
        {
            get { return (String)email_domainVar.Value; }
            set { email_domainVar.Value = value; }
        }

        public String source
        {
            get { return (String)sourceVar.Value; }
            set { sourceVar.Value = value; }
        }

        public DateTime last_marketing
        {
            get { return (DateTime)last_marketingVar.Value; }
            set { last_marketingVar.Value = value; }
        }

        public Boolean isoem
        {
            get { return (Boolean)isoemVar.Value; }
            set { isoemVar.Value = value; }
        }

        public Boolean isbroker
        {
            get { return (Boolean)isbrokerVar.Value; }
            set { isbrokerVar.Value = value; }
        }

        public Boolean isweb
        {
            get { return (Boolean)iswebVar.Value; }
            set { iswebVar.Value = value; }
        }

        public Boolean iserai
        {
            get { return (Boolean)iseraiVar.Value; }
            set { iseraiVar.Value = value; }
        }

        public Boolean isiso
        {
            get { return (Boolean)isisoVar.Value; }
            set { isisoVar.Value = value; }
        }

        public Boolean iscem
        {
            get { return (Boolean)iscemVar.Value; }
            set { iscemVar.Value = value; }
        }

        public String group_name
        {
            get { return (String)group_nameVar.Value; }
            set { group_nameVar.Value = value; }
        }

        public Double cc_charge
        {
            get { return (Double)cc_chargeVar.Value; }
            set { cc_chargeVar.Value = value; }
        }

        public Double handling_charge
        {
            get { return (Double)handling_chargeVar.Value; }
            set { handling_chargeVar.Value = value; }
        }

        public String cc_warning
        {
            get { return (String)cc_warningVar.Value; }
            set { cc_warningVar.Value = value; }
        }

        public String call_schedule
        {
            get { return (String)call_scheduleVar.Value; }
            set { call_scheduleVar.Value = value; }
        }

        public Boolean donotemail
        {
            get { return (Boolean)donotemailVar.Value; }
            set { donotemailVar.Value = value; }
        }

        public String salesgenie_page
        {
            get { return (String)salesgenie_pageVar.Value; }
            set { salesgenie_pageVar.Value = value; }
        }

        public Boolean problem_vendor
        {
            get { return (Boolean)problem_vendorVar.Value; }
            set { problem_vendorVar.Value = value; }
        }

        public Boolean is_qbimport
        {
            get { return (Boolean)is_qbimportVar.Value; }
            set { is_qbimportVar.Value = value; }
        }

        public String nameoncard
        {
            get { return (String)nameoncardVar.Value; }
            set { nameoncardVar.Value = value; }
        }

        public String creditcardtype
        {
            get { return (String)creditcardtypeVar.Value; }
            set { creditcardtypeVar.Value = value; }
        }

        public Int32 expiration_month
        {
            get { return (Int32)expiration_monthVar.Value; }
            set { expiration_monthVar.Value = value; }
        }

        public Int32 expiration_year
        {
            get { return (Int32)expiration_yearVar.Value; }
            set { expiration_yearVar.Value = value; }
        }

        public Int32 security_code
        {
            get { return (Int32)security_codeVar.Value; }
            set { security_codeVar.Value = value; }
        }

        public String cardbillingaddr
        {
            get { return (String)cardbillingaddrVar.Value; }
            set { cardbillingaddrVar.Value = value; }
        }

        public String cardbillingzip
        {
            get { return (String)cardbillingzipVar.Value; }
            set { cardbillingzipVar.Value = value; }
        }

        public String company_criteria
        {
            get { return (String)company_criteriaVar.Value; }
            set { company_criteriaVar.Value = value; }
        }

        public String city
        {
            get { return (String)cityVar.Value; }
            set { cityVar.Value = value; }
        }

        public String securitycode
        {
            get { return (String)securitycodeVar.Value; }
            set { securitycodeVar.Value = value; }
        }

        public Boolean islocked_purchase
        {
            get { return (Boolean)islocked_purchaseVar.Value; }
            set { islocked_purchaseVar.Value = value; }
        }

        public Boolean delete_archives
        {
            get { return (Boolean)delete_archivesVar.Value; }
            set { delete_archivesVar.Value = value; }
        }

        public Int64 delete_archives_period
        {
            get { return (Int64)delete_archives_periodVar.Value; }
            set { delete_archives_periodVar.Value = value; }
        }

        public String qb_name_v
        {
            get { return (String)qb_name_vVar.Value; }
            set { qb_name_vVar.Value = value; }
        }

        public String mrp_info
        {
            get { return (String)mrp_infoVar.Value; }
            set { mrp_infoVar.Value = value; }
        }

        public Boolean is_prospect
        {
            get { return (Boolean)is_prospectVar.Value; }
            set { is_prospectVar.Value = value; }
        }

        public String company_pic_type
        {
            get { return (String)company_pic_typeVar.Value; }
            set { company_pic_typeVar.Value = value; }
        }

        public String bank_wire_info
        {
            get { return (String)bank_wire_infoVar.Value; }
            set { bank_wire_infoVar.Value = value; }
        }

        public Double po_min
        {
            get { return (Double)po_minVar.Value; }
            set { po_minVar.Value = value; }
        }

        public String po_notify
        {
            get { return (String)po_notifyVar.Value; }
            set { po_notifyVar.Value = value; }
        }

        public DateTime next_contact_date
        {
            get { return (DateTime)next_contact_dateVar.Value; }
            set { next_contact_dateVar.Value = value; }
        }

        public DateTime last_activity_date
        {
            get { return (DateTime)last_activity_dateVar.Value; }
            set { last_activity_dateVar.Value = value; }
        }

        public Boolean ignore
        {
            get { return (Boolean)ignoreVar.Value; }
            set { ignoreVar.Value = value; }
        }

        public Int32 feedback_positive
        {
            get { return (Int32)feedback_positiveVar.Value; }
            set { feedback_positiveVar.Value = value; }
        }

        public Int32 feedback_negative
        {
            get { return (Int32)feedback_negativeVar.Value; }
            set { feedback_negativeVar.Value = value; }
        }

        public Int32 feedback_neutral
        {
            get { return (Int32)feedback_neutralVar.Value; }
            set { feedback_neutralVar.Value = value; }
        }

        public Int32 feedback_rating
        {
            get { return (Int32)feedback_ratingVar.Value; }
            set { feedback_ratingVar.Value = value; }
        }

        public String lead_source
        {
            get { return (String)lead_sourceVar.Value; }
            set { lead_sourceVar.Value = value; }
        }

        public String last_calllog_uid
        {
            get { return (String)last_calllog_uidVar.Value; }
            set { last_calllog_uidVar.Value = value; }
        }

        public String main_companyaddress_uid
        {
            get { return (String)main_companyaddress_uidVar.Value; }
            set { main_companyaddress_uidVar.Value = value; }
        }

        public String industry_segment
        {
            get { return (String)industry_segmentVar.Value; }
            set { industry_segmentVar.Value = value; }
        }

        public String localtime
        {
            get { return (String)localtimeVar.Value; }
            set { localtimeVar.Value = value; }
        }

        public String bankname
        {
            get { return (String)banknameVar.Value; }
            set { banknameVar.Value = value; }
        }

        public String bankaddress
        {
            get { return (String)bankaddressVar.Value; }
            set { bankaddressVar.Value = value; }
        }

        public String swiftcode
        {
            get { return (String)swiftcodeVar.Value; }
            set { swiftcodeVar.Value = value; }
        }

        public String accountnumber
        {
            get { return (String)accountnumberVar.Value; }
            set { accountnumberVar.Value = value; }
        }

        public String vatnumber
        {
            get { return (String)vatnumberVar.Value; }
            set { vatnumberVar.Value = value; }
        }

        public String companysizetext
        {
            get { return (String)companysizetextVar.Value; }
            set { companysizetextVar.Value = value; }
        }

        public Boolean freeshipping
        {
            get { return (Boolean)freeshippingVar.Value; }
            set { freeshippingVar.Value = value; }
        }

        public Double average_profit
        {
            get { return (Double)average_profitVar.Value; }
            set { average_profitVar.Value = value; }
        }

        public Boolean isverified
        {
            get { return (Boolean)isverifiedVar.Value; }
            set { isverifiedVar.Value = value; }
        }

        public Int32 positive_auto
        {
            get { return (Int32)positive_autoVar.Value; }
            set { positive_autoVar.Value = value; }
        }

        public Int32 positive_manual
        {
            get { return (Int32)positive_manualVar.Value; }
            set { positive_manualVar.Value = value; }
        }

        public Int32 negative_auto
        {
            get { return (Int32)negative_autoVar.Value; }
            set { negative_autoVar.Value = value; }
        }

        public Int32 negative_manual
        {
            get { return (Int32)negative_manualVar.Value; }
            set { negative_manualVar.Value = value; }
        }

        public String notes_1
        {
            get { return (String)notes_1Var.Value; }
            set { notes_1Var.Value = value; }
        }

        public String notes_2
        {
            get { return (String)notes_2Var.Value; }
            set { notes_2Var.Value = value; }
        }

        public String notes_3
        {
            get { return (String)notes_3Var.Value; }
            set { notes_3Var.Value = value; }
        }

        public String notes_4
        {
            get { return (String)notes_4Var.Value; }
            set { notes_4Var.Value = value; }
        }

        public Int32 star_rating
        {
            get { return (Int32)star_ratingVar.Value; }
            set { star_ratingVar.Value = value; }
        }

        public Int32 years_in_business
        {
            get { return (Int32)years_in_businessVar.Value; }
            set { years_in_businessVar.Value = value; }
        }

        public DateTime date_assigned
        {
            get { return (DateTime)date_assignedVar.Value; }
            set { date_assignedVar.Value = value; }
        }

        public String alternate_names
        {
            get { return (String)alternate_namesVar.Value; }
            set { alternate_namesVar.Value = value; }
        }

        public Int64 calc_reqs
        {
            get { return (Int64)calc_reqsVar.Value; }
            set { calc_reqsVar.Value = value; }
        }

        public Int64 calc_bids
        {
            get { return (Int64)calc_bidsVar.Value; }
            set { calc_bidsVar.Value = value; }
        }

        public Int64 calc_qquotes
        {
            get { return (Int64)calc_qquotesVar.Value; }
            set { calc_qquotesVar.Value = value; }
        }

        public Int64 calc_fquotes
        {
            get { return (Int64)calc_fquotesVar.Value; }
            set { calc_fquotesVar.Value = value; }
        }

        public Int64 calc_sales
        {
            get { return (Int64)calc_salesVar.Value; }
            set { calc_salesVar.Value = value; }
        }

        public Int64 calc_purchases
        {
            get { return (Int64)calc_purchasesVar.Value; }
            set { calc_purchasesVar.Value = value; }
        }

        public Int64 bids_from_reqs
        {
            get { return (Int64)bids_from_reqsVar.Value; }
            set { bids_from_reqsVar.Value = value; }
        }

        public Int64 bell_ringers
        {
            get { return (Int64)bell_ringersVar.Value; }
            set { bell_ringersVar.Value = value; }
        }

        public Int64 calc_calls
        {
            get { return (Int64)calc_callsVar.Value; }
            set { calc_callsVar.Value = value; }
        }

        public Int64 calc_notes
        {
            get { return (Int64)calc_notesVar.Value; }
            set { calc_notesVar.Value = value; }
        }

        public Double total_sales_amount
        {
            get { return (Double)total_sales_amountVar.Value; }
            set { total_sales_amountVar.Value = value; }
        }

        public DateTime last_req_date
        {
            get { return (DateTime)last_req_dateVar.Value; }
            set { last_req_dateVar.Value = value; }
        }

        public DateTime last_sale_date
        {
            get { return (DateTime)last_sale_dateVar.Value; }
            set { last_sale_dateVar.Value = value; }
        }

        public DateTime last_call_date
        {
            get { return (DateTime)last_call_dateVar.Value; }
            set { last_call_dateVar.Value = value; }
        }

        public String last_call_notes
        {
            get { return (String)last_call_notesVar.Value; }
            set { last_call_notesVar.Value = value; }
        }

        public String last_call_result
        {
            get { return (String)last_call_resultVar.Value; }
            set { last_call_resultVar.Value = value; }
        }

        public String agent
        {
            get { return (String)agentVar.Value; }
            set { agentVar.Value = value; }
        }

        public DateTime calc_last_quote
        {
            get { return (DateTime)calc_last_quoteVar.Value; }
            set { calc_last_quoteVar.Value = value; }
        }

        public Int64 calc_invoice_line_count
        {
            get { return (Int64)calc_invoice_line_countVar.Value; }
            set { calc_invoice_line_countVar.Value = value; }
        }

        public Double calc_invoice_volume
        {
            get { return (Double)calc_invoice_volumeVar.Value; }
            set { calc_invoice_volumeVar.Value = value; }
        }

        public Int64 calc_vendrma_line_count
        {
            get { return (Int64)calc_vendrma_line_countVar.Value; }
            set { calc_vendrma_line_countVar.Value = value; }
        }

        public Int64 calc_purchase_line_count
        {
            get { return (Int64)calc_purchase_line_countVar.Value; }
            set { calc_purchase_line_countVar.Value = value; }
        }

        public Double calc_purchase_volume
        {
            get { return (Double)calc_purchase_volumeVar.Value; }
            set { calc_purchase_volumeVar.Value = value; }
        }

        public Int64 calc_pot_invoice_line_count
        {
            get { return (Int64)calc_pot_invoice_line_countVar.Value; }
            set { calc_pot_invoice_line_countVar.Value = value; }
        }

        public Double calc_pot_invoice_volume
        {
            get { return (Double)calc_pot_invoice_volumeVar.Value; }
            set { calc_pot_invoice_volumeVar.Value = value; }
        }

        public Int64 calc_pot_vendrma_line_count
        {
            get { return (Int64)calc_pot_vendrma_line_countVar.Value; }
            set { calc_pot_vendrma_line_countVar.Value = value; }
        }

        public Int64 calc_pot_purchase_line_count
        {
            get { return (Int64)calc_pot_purchase_line_countVar.Value; }
            set { calc_pot_purchase_line_countVar.Value = value; }
        }

        public Double calc_pot_purchase_volume
        {
            get { return (Double)calc_pot_purchase_volumeVar.Value; }
            set { calc_pot_purchase_volumeVar.Value = value; }
        }

        public DateTime last_purchase_date
        {
            get { return (DateTime)last_purchase_dateVar.Value; }
            set { last_purchase_dateVar.Value = value; }
        }

        public String warranty_period
        {
            get { return (String)warranty_periodVar.Value; }
            set { warranty_periodVar.Value = value; }
        }

        public String warranty_period_vendor
        {
            get { return (String)warranty_period_vendorVar.Value; }
            set { warranty_period_vendorVar.Value = value; }
        }

        public Double balance_owed_vendor
        {
            get { return (Double)balance_owed_vendorVar.Value; }
            set { balance_owed_vendorVar.Value = value; }
        }

        public Double balance_owed_customer
        {
            get { return (Double)balance_owed_customerVar.Value; }
            set { balance_owed_customerVar.Value = value; }
        }
        public Boolean Products_Display
        {
            get { return (Boolean)Products_DisplayVar.Value; }
            set { Products_DisplayVar.Value = value; }
        }
        public Boolean Products_SSD
        {
            get { return (Boolean)Products_SSDVar.Value; }
            set { Products_SSDVar.Value = value; }
        }
        public Boolean Products_Cabling
        {
            get { return (Boolean)Products_CablingVar.Value; }
            set { Products_CablingVar.Value = value; }
        }
        public Boolean Products_Interconnect
        {
            get { return (Boolean)Products_InterconnectVar.Value; }
            set { Products_InterconnectVar.Value = value; }
        }
        public Boolean Products_CrystalOsc
        {
            get { return (Boolean)Products_CrystalOscVar.Value; }
            set { Products_CrystalOscVar.Value = value; }
        }
        public Boolean Products_Relay
        {
            get { return (Boolean)Products_RelayVar.Value; }
            set { Products_RelayVar.Value = value; }
        }
        public Boolean Products_PowerSupply
        {
            get { return (Boolean)Products_PowerSupplyVar.Value; }
            set { Products_PowerSupplyVar.Value = value; }
        }
        public Boolean Products_OpticalTransceiver
        {
            get { return (Boolean)Products_OpticalTransceiverVar.Value; }
            set { Products_OpticalTransceiverVar.Value = value; }
        }
        public Boolean Products_Components
        {
            get { return (Boolean)Products_ComponentsVar.Value; }
            set { Products_ComponentsVar.Value = value; }
        }

        public Boolean SOA_components
        {
            get { return (Boolean)SOA_componentsVar.Value; }
            set { SOA_componentsVar.Value = value; }
        }

        public Boolean SOA_services
        {
            get { return (Boolean)SOA_servicesVar.Value; }
            set { SOA_servicesVar.Value = value; }
        }
        public Boolean has_financials
        {
            get { return (Boolean)has_financialsVar.Value; }
            set { has_financialsVar.Value = value; }
        }

        public DateTime vetted_date
        {
            get { return (DateTime)vetted_dateVar.Value; }
            set { vetted_dateVar.Value = value; }
        }

        public String vetted_by
        {
            get { return (String)vetted_byVar.Value; }
            set { vetted_byVar.Value = value; }
        }

        public Boolean is_vetted
        {
            get { return (Boolean)is_vettedVar.Value; }
            set { is_vettedVar.Value = value; }
        }

        public String customerTermsMemo
        {
            get { return (String)customerTermsMemoVar.Value; }
            set { customerTermsMemoVar.Value = value; }
        }

        public String vendorTermsMemo
        {
            get { return (String)vendorTermsMemoVar.Value; }
            set { vendorTermsMemoVar.Value = value; }
        }
        public String created_by_name
        {
            get { return (String)created_by_nameVar.Value; }
            set { created_by_nameVar.Value = value; }
        }
        public String created_by_uid
        {
            get { return (String)created_by_uidVar.Value; }
            set { created_by_uidVar.Value = value; }
        }

        public Boolean GCAT_required
        {
            get { return (Boolean)GCAT_requiredVar.Value; }
            set { GCAT_requiredVar.Value = value; }
        }


        public String qb_company_ListID
        {
            get { return (String)qb_company_ListIDVar.Value; }
            set { qb_company_ListIDVar.Value = value; }
        }

        public String qb_company_type
        {
            get { return (String)qb_company_typeVar.Value; }
            set { qb_company_typeVar.Value = value; }
        }

        public String qb_company_ListID_vendor
        {
            get { return (String)qb_company_ListID_vendorVar.Value; }
            set { qb_company_ListID_vendorVar.Value = value; }
        }

        public Int64 hubspot_company_id
        {
            get { return (Int64)hubspot_company_idVar.Value; }
            set { hubspot_company_idVar.Value = value; }
        }

        public string split_commission_agent_name
        {
            get { return (string)split_commission_agent_nameVar.Value; }
            set { split_commission_agent_nameVar.Value = value; }
        }

        public string split_commission_agent_uid
        {
            get { return (string)split_commission_agent_uidVar.Value; }
            set { split_commission_agent_uidVar.Value = value; }
        }

        public string split_commission_default_type
        {
            get { return (string)split_commission_default_typeVar.Value; }
            set { split_commission_default_typeVar.Value = value; }
        }

        public DateTime split_commission_date_active
        {
            get { return (DateTime)split_commission_date_activeVar.Value; }
            set { split_commission_date_activeVar.Value = value; }
        }
        
        public string split_commission_ID
        {
            get { return (string)split_commission_IDVar.Value; }
            set { split_commission_IDVar.Value = value; }
        }


    }
    public partial class company
    {
        public static company New(Context x)
        { return (company)x.Item("company"); }

        public static company GetById(Context x, String uid)
        { return (company)x.GetById("company", uid); }

        public static company QtO(Context x, String sql)
        { return (company)x.QtO("company", sql); }

      
    }
}
