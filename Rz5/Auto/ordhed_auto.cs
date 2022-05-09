using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed", Abstract = true)]
    public partial class ordhed_auto : NewMethod.nObject
    {
        static ordhed_auto()
        {
            Item.AttributesCache(typeof(ordhed_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_dealheader_uid":
                    base_dealheader_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_division_uid":
                    base_division_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber":
                    ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertype":
                    ordertypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "userid":
                    useridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "freightbilling":
                    freightbillingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isinternational":
                    isinternationalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "modifiedby":
                    modifiedbyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia":
                    shipviaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "terms":
                    termsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingamount":
                    shippingamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handlingamount":
                    handlingamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxamount":
                    taxamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "billingaddress":
                    billingaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaddress":
                    shippingaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxrateid":
                    taxrateidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "specialinstructionshipping":
                    specialinstructionshippingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "specialinstructionsbilling":
                    specialinstructionsbillingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packinginfo":
                    packinginfoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "islocked":
                    islockedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isclosed":
                    isclosedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isvoid":
                    isvoidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ispaid":
                    ispaidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderweight":
                    orderweightAttribute = (CoreVarValAttribute)attr;
                    break;
                case "trackingnumber":
                    trackingnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
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
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyagentid":
                    legacyagentidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacycompanyid":
                    legacycompanyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate":
                    orderdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderreference":
                    orderreferenceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "comment":
                    commentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalcomment":
                    internalcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lastfilled":
                    lastfilledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dockdate":
                    dockdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacycontact":
                    legacycontactAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount":
                    shippingaccountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fillingagent":
                    fillingagentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hasbeenfilled":
                    hasbeenfilledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isproforma":
                    isproformaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isflipdeal":
                    isflipdealAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country":
                    countryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertotal":
                    ordertotalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "grossamount":
                    grossamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "costamount":
                    costamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxamount_exchanged":
                    taxamount_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingamount_exchanged":
                    shippingamount_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "profitamount":
                    profitamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "outstandingamount":
                    outstandingamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "grossamount_exchanged":
                    grossamount_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "securityid":
                    securityidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printcomment":
                    printcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "requireddate":
                    requireddateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "soreference":
                    soreferenceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "senttoqb":
                    senttoqbAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datesenttoqb":
                    datesenttoqbAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rmareference":
                    rmareferenceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderfob":
                    orderfobAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyername":
                    buyernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qualitycontrol":
                    qualitycontrolAttribute = (CoreVarValAttribute)attr;
                    break;
                case "showonwarehouse":
                    showonwarehouseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dateclosed":
                    dateclosedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "existsonwarehouse":
                    existsonwarehouseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "totalvalue":
                    totalvalueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isbuyin":
                    isbuyinAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isnewcustomer":
                    isnewcustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ispromoattached":
                    ispromoattachedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyinid":
                    buyinidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isvalidated":
                    isvalidatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderbuyerid":
                    orderbuyeridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipdate":
                    shipdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "usercode":
                    usercodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "firstpartnumber":
                    firstpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatetracking":
                    alternatetrackingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "iswarned":
                    iswarnedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_received":
                    is_receivedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isverified":
                    isverifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "readytoship":
                    readytoshipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_date":
                    payment_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_commission_paid":
                    is_commission_paidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "date_expires":
                    date_expiresAttribute = (CoreVarValAttribute)attr;
                    break;
                case "c_of_c":
                    c_of_cAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertypedisplay":
                    ordertypedisplayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingdate":
                    shippingdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handlingdate":
                    handlingdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handlingamount_exchanged":
                    handlingamount_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertotal_exchanged":
                    ordertotal_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exchange_rate":
                    exchange_rateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "onhold":
                    onholdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "holdreason":
                    holdreasonAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rma_data":
                    rma_dataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_stock":
                    is_stockAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subtract_1":
                    subtract_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "subtract_2":
                    subtract_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "subtract_3":
                    subtract_3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "caption_data":
                    caption_dataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "invoice_date":
                    invoice_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "invoice_number":
                    invoice_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charged_amount":
                    charged_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_caption":
                    shipping_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handling_caption":
                    handling_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tax_caption":
                    tax_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subtract1_caption":
                    subtract1_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subtract2_caption":
                    subtract2_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subtract3_caption":
                    subtract3_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "no_return":
                    no_returnAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_government":
                    is_governmentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "billingname":
                    billingnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingname":
                    shippingnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecreated":
                    datecreatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datemodified":
                    datemodifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "username":
                    usernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_authorized":
                    is_authorizedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "authorized_date":
                    authorized_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "authorized_number":
                    authorized_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderamount":
                    orderamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_confirmed":
                    is_confirmedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_issue":
                    has_issueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "advance_payment_made":
                    advance_payment_madeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "currency_name":
                    currency_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "note_id":
                    note_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxdate":
                    taxdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "trackingstripped":
                    trackingstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "did_call":
                    did_callAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_date":
                    email_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "call_date":
                    call_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_date_group":
                    email_date_groupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "call_date_group":
                    call_date_groupAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_qbimport":
                    is_qbimportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "nameoncard":
                    nameoncardAttribute = (CoreVarValAttribute)attr;
                    break;
                case "created_by_tree":
                    created_by_treeAttribute = (CoreVarValAttribute)attr;
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
                case "creditcardnumber":
                    creditcardnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_incomplete":
                    is_incompleteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fell_down":
                    fell_downAttribute = (CoreVarValAttribute)attr;
                    break;
                case "drop_ship_address":
                    drop_ship_addressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "securitycode":
                    securitycodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_check_approved":
                    credit_check_approvedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_invoice":
                    is_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_approve_agent":
                    credit_approve_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_card_charged":
                    credit_card_chargedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packingslip_complete":
                    packingslip_completeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_reppaid":
                    is_reppaidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "static_reportnote":
                    static_reportnoteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_buyerpaid":
                    is_buyerpaidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ord_contents":
                    ord_contentsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "harmonized_code":
                    harmonized_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_packages":
                    total_packagesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_weight":
                    total_weightAttribute = (CoreVarValAttribute)attr;
                    break;
                case "strippedphone":
                    strippedphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "followup_date":
                    followup_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warranty_period":
                    warranty_periodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "date_paid":
                    date_paidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warehouse_id":
                    warehouse_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extra_info":
                    extra_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_invoice_number":
                    vendor_invoice_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "action_taken":
                    action_takenAttribute = (CoreVarValAttribute)attr;
                    break;
                case "certs_required":
                    certs_requiredAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lead_source":
                    lead_sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_domain":
                    email_domainAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_suffix":
                    email_suffixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingamount_print":
                    shippingamount_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "handlingamount_print":
                    handlingamount_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "taxamount_print":
                    taxamount_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertotal_print":
                    ordertotal_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "creditamount":
                    creditamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_deal_id":
                    hubspot_deal_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_order_TxnID":
                    qb_order_TxnIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "opportunity_stage":
                    opportunity_stageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "opportunity_lost_reason":
                    opportunity_lost_reasonAttribute = (CoreVarValAttribute)attr;
                    break;
                case "opportunity_type":
                    opportunity_typeAttribute = (CoreVarValAttribute)attr;
                    break;


            }
        }

        static CoreVarValAttribute base_dealheader_uidAttribute;
        static CoreVarValAttribute base_division_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute ordernumberAttribute;
        static CoreVarValAttribute ordertypeAttribute;
        static CoreVarValAttribute useridAttribute;
        static CoreVarValAttribute freightbillingAttribute;
        static CoreVarValAttribute isinternationalAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute shipviaAttribute;
        static CoreVarValAttribute termsAttribute;
        static CoreVarValAttribute shippingamountAttribute;
        static CoreVarValAttribute handlingamountAttribute;
        static CoreVarValAttribute taxamountAttribute;
        static CoreVarValAttribute billingaddressAttribute;
        static CoreVarValAttribute shippingaddressAttribute;
        static CoreVarValAttribute taxrateidAttribute;
        static CoreVarValAttribute specialinstructionshippingAttribute;
        static CoreVarValAttribute specialinstructionsbillingAttribute;
        static CoreVarValAttribute packinginfoAttribute;
        static CoreVarValAttribute islockedAttribute;
        static CoreVarValAttribute isclosedAttribute;
        static CoreVarValAttribute isvoidAttribute;
        static CoreVarValAttribute ispaidAttribute;
        static CoreVarValAttribute orderweightAttribute;
        static CoreVarValAttribute trackingnumberAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute primaryphoneAttribute;
        static CoreVarValAttribute primaryfaxAttribute;
        static CoreVarValAttribute primaryemailaddressAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute legacyagentidAttribute;
        static CoreVarValAttribute legacycompanyidAttribute;
        static CoreVarValAttribute orderdateAttribute;
        static CoreVarValAttribute orderreferenceAttribute;
        static CoreVarValAttribute commentAttribute;
        static CoreVarValAttribute internalcommentAttribute;
        static CoreVarValAttribute lastfilledAttribute;
        static CoreVarValAttribute dockdateAttribute;
        static CoreVarValAttribute legacycontactAttribute;
        static CoreVarValAttribute shippingaccountAttribute;
        static CoreVarValAttribute fillingagentAttribute;
        static CoreVarValAttribute hasbeenfilledAttribute;
        static CoreVarValAttribute isproformaAttribute;
        static CoreVarValAttribute isflipdealAttribute;
        static CoreVarValAttribute countryAttribute;
        static CoreVarValAttribute ordertotalAttribute;
        static CoreVarValAttribute grossamountAttribute;
        static CoreVarValAttribute costamountAttribute;
        static CoreVarValAttribute taxamount_exchangedAttribute;
        static CoreVarValAttribute shippingamount_exchangedAttribute;
        static CoreVarValAttribute profitamountAttribute;
        static CoreVarValAttribute outstandingamountAttribute;
        static CoreVarValAttribute grossamount_exchangedAttribute;
        static CoreVarValAttribute securityidAttribute;
        static CoreVarValAttribute printcommentAttribute;
        static CoreVarValAttribute requireddateAttribute;
        static CoreVarValAttribute soreferenceAttribute;
        static CoreVarValAttribute senttoqbAttribute;
        static CoreVarValAttribute datesenttoqbAttribute;
        static CoreVarValAttribute rmareferenceAttribute;
        static CoreVarValAttribute orderfobAttribute;
        static CoreVarValAttribute buyernameAttribute;
        static CoreVarValAttribute qualitycontrolAttribute;
        static CoreVarValAttribute showonwarehouseAttribute;
        static CoreVarValAttribute dateclosedAttribute;
        static CoreVarValAttribute existsonwarehouseAttribute;
        static CoreVarValAttribute totalvalueAttribute;
        static CoreVarValAttribute isbuyinAttribute;
        static CoreVarValAttribute isnewcustomerAttribute;
        static CoreVarValAttribute ispromoattachedAttribute;
        static CoreVarValAttribute buyinidAttribute;
        static CoreVarValAttribute isvalidatedAttribute;
        static CoreVarValAttribute orderbuyeridAttribute;
        static CoreVarValAttribute shipdateAttribute;
        static CoreVarValAttribute usercodeAttribute;
        static CoreVarValAttribute firstpartnumberAttribute;
        static CoreVarValAttribute alternatetrackingAttribute;
        static CoreVarValAttribute iswarnedAttribute;
        static CoreVarValAttribute is_receivedAttribute;
        static CoreVarValAttribute isverifiedAttribute;
        static CoreVarValAttribute readytoshipAttribute;
        static CoreVarValAttribute payment_dateAttribute;
        static CoreVarValAttribute is_commission_paidAttribute;
        static CoreVarValAttribute date_expiresAttribute;
        static CoreVarValAttribute c_of_cAttribute;
        static CoreVarValAttribute ordertypedisplayAttribute;
        static CoreVarValAttribute shippingdateAttribute;
        static CoreVarValAttribute handlingdateAttribute;
        static CoreVarValAttribute handlingamount_exchangedAttribute;
        static CoreVarValAttribute ordertotal_exchangedAttribute;
        static CoreVarValAttribute exchange_rateAttribute;
        static CoreVarValAttribute onholdAttribute;
        static CoreVarValAttribute holdreasonAttribute;
        static CoreVarValAttribute rma_dataAttribute;
        static CoreVarValAttribute is_stockAttribute;
        static CoreVarValAttribute subtract_1Attribute;
        static CoreVarValAttribute subtract_2Attribute;
        static CoreVarValAttribute subtract_3Attribute;
        static CoreVarValAttribute caption_dataAttribute;
        static CoreVarValAttribute invoice_dateAttribute;
        static CoreVarValAttribute invoice_numberAttribute;
        static CoreVarValAttribute charged_amountAttribute;
        static CoreVarValAttribute shipping_captionAttribute;
        static CoreVarValAttribute handling_captionAttribute;
        static CoreVarValAttribute tax_captionAttribute;
        static CoreVarValAttribute subtract1_captionAttribute;
        static CoreVarValAttribute subtract2_captionAttribute;
        static CoreVarValAttribute subtract3_captionAttribute;
        static CoreVarValAttribute no_returnAttribute;
        static CoreVarValAttribute is_governmentAttribute;
        static CoreVarValAttribute billingnameAttribute;
        static CoreVarValAttribute shippingnameAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute usernameAttribute;
        static CoreVarValAttribute is_authorizedAttribute;
        static CoreVarValAttribute authorized_dateAttribute;
        static CoreVarValAttribute authorized_numberAttribute;
        static CoreVarValAttribute orderamountAttribute;
        static CoreVarValAttribute is_confirmedAttribute;
        static CoreVarValAttribute has_issueAttribute;
        static CoreVarValAttribute advance_payment_madeAttribute;
        static CoreVarValAttribute currency_nameAttribute;
        static CoreVarValAttribute note_idAttribute;
        static CoreVarValAttribute taxdateAttribute;
        static CoreVarValAttribute trackingstrippedAttribute;
        static CoreVarValAttribute did_callAttribute;
        static CoreVarValAttribute email_dateAttribute;
        static CoreVarValAttribute call_dateAttribute;
        static CoreVarValAttribute email_date_groupAttribute;
        static CoreVarValAttribute call_date_groupAttribute;
        static CoreVarValAttribute is_qbimportAttribute;
        static CoreVarValAttribute nameoncardAttribute;
        static CoreVarValAttribute created_by_treeAttribute;
        static CoreVarValAttribute creditcardtypeAttribute;
        static CoreVarValAttribute expiration_monthAttribute;
        static CoreVarValAttribute expiration_yearAttribute;
        static CoreVarValAttribute security_codeAttribute;
        static CoreVarValAttribute cardbillingaddrAttribute;
        static CoreVarValAttribute cardbillingzipAttribute;
        static CoreVarValAttribute creditcardnumberAttribute;
        static CoreVarValAttribute is_incompleteAttribute;
        static CoreVarValAttribute fell_downAttribute;
        static CoreVarValAttribute drop_ship_addressAttribute;
        static CoreVarValAttribute securitycodeAttribute;
        static CoreVarValAttribute credit_check_approvedAttribute;
        static CoreVarValAttribute is_invoiceAttribute;
        static CoreVarValAttribute credit_approve_agentAttribute;
        static CoreVarValAttribute credit_card_chargedAttribute;
        static CoreVarValAttribute packingslip_completeAttribute;
        static CoreVarValAttribute is_reppaidAttribute;
        static CoreVarValAttribute static_reportnoteAttribute;
        static CoreVarValAttribute is_buyerpaidAttribute;
        static CoreVarValAttribute ord_contentsAttribute;
        static CoreVarValAttribute harmonized_codeAttribute;
        static CoreVarValAttribute total_packagesAttribute;
        static CoreVarValAttribute total_weightAttribute;
        static CoreVarValAttribute strippedphoneAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute followup_dateAttribute;
        static CoreVarValAttribute warranty_periodAttribute;
        static CoreVarValAttribute date_paidAttribute;
        static CoreVarValAttribute warehouse_idAttribute;
        static CoreVarValAttribute extra_infoAttribute;
        static CoreVarValAttribute vendor_invoice_numberAttribute;
        static CoreVarValAttribute action_takenAttribute;
        static CoreVarValAttribute certs_requiredAttribute;
        static CoreVarValAttribute lead_sourceAttribute;
        static CoreVarValAttribute email_domainAttribute;
        static CoreVarValAttribute email_suffixAttribute;
        static CoreVarValAttribute shippingamount_printAttribute;
        static CoreVarValAttribute handlingamount_printAttribute;
        static CoreVarValAttribute taxamount_printAttribute;
        static CoreVarValAttribute ordertotal_printAttribute;
        static CoreVarValAttribute creditamountAttribute;
        static CoreVarValAttribute hubspot_deal_idAttribute;
        static CoreVarValAttribute qb_order_TxnIDAttribute;
        static CoreVarValAttribute opportunity_stageAttribute;
        static CoreVarValAttribute opportunity_lost_reasonAttribute;
        static CoreVarValAttribute opportunity_typeAttribute;




        [CoreVarVal("base_dealheader_uid", "String", TheFieldLength = 50, Caption = "Base Dealheader Id", Importance = 1)]
        public VarString base_dealheader_uidVar;

        [CoreVarVal("base_division_uid", "String", TheFieldLength = 50, Caption = "Base Division Id", Importance = 2)]
        public VarString base_division_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption = "User Id", Importance = 3)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 50, Caption = "Base Companycontact Id", Importance = 4)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption = "Base Company Id", Importance = 5)]
        public VarString base_company_uidVar;

        [CoreVarVal("ordernumber", "String", TheFieldLength = 50, Caption = "Order Number", Importance = 6)]
        public VarString ordernumberVar;

        [CoreVarVal("ordertype", "String", TheFieldLength = 50, Caption = "Type", Importance = 7)]
        public VarString ordertypeVar;

        [CoreVarVal("userid", "String", TheFieldLength = 50, Caption = "User Id", Importance = 8)]
        public VarString useridVar;

        [CoreVarVal("freightbilling", "String", TheFieldLength = 50, Caption = "Freight Billing", Importance = 9)]
        public VarString freightbillingVar;

        [CoreVarVal("isinternational", "Boolean", Caption = "Is International", Importance = 10)]
        public VarBoolean isinternationalVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption = "Modified By", Importance = 11)]
        public VarString modifiedbyVar;

        [CoreVarVal("shipvia", "String", TheFieldLength = 50, Caption = "Ship Via", Importance = 12)]
        public VarString shipviaVar;

        [CoreVarVal("terms", "String", TheFieldLength = 50, Caption = "Terms", Importance = 13)]
        public VarString termsVar;

        [CoreVarVal("shippingamount", "Double", Caption = "Shipping", Importance = 14)]
        public VarDouble shippingamountVar;

        [CoreVarVal("handlingamount", "Double", Caption = "Handling", Importance = 17)]
        public VarDouble handlingamountVar;

        [CoreVarVal("taxamount", "Double", Caption = "Tax Amount", Importance = 18)]
        public VarDouble taxamountVar;

        [CoreVarVal("billingaddress", "String", TheFieldLength = 4096, Caption = "Billing Address", Importance = 20)]
        public VarString billingaddressVar;

        [CoreVarVal("shippingaddress", "String", TheFieldLength = 4096, Caption = "Shipping Address", Importance = 21)]
        public VarString shippingaddressVar;

        [CoreVarVal("taxrateid", "String", TheFieldLength = 50, Caption = "Tax Rate Id", Importance = 22)]
        public VarString taxrateidVar;

        [CoreVarVal("specialinstructionshipping", "String", TheFieldLength = 4096, Caption = "Shipping Instructions", Importance = 23)]
        public VarString specialinstructionshippingVar;

        [CoreVarVal("specialinstructionsbilling", "String", TheFieldLength = 4096, Caption = "Billing Instructions", Importance = 24)]
        public VarString specialinstructionsbillingVar;

        [CoreVarVal("packinginfo", "String", TheFieldLength = 50, Caption = "Packing Info", Importance = 25)]
        public VarString packinginfoVar;

        [CoreVarVal("islocked", "Boolean", Caption = "Is Locked", Importance = 26)]
        public VarBoolean islockedVar;

        [CoreVarVal("isclosed", "Boolean", Caption = "Is Closed", Importance = 27)]
        public VarBoolean isclosedVar;

        [CoreVarVal("isvoid", "Boolean", Caption = "Is Void", Importance = 28)]
        public VarBoolean isvoidVar;

        [CoreVarVal("ispaid", "Boolean", Transactional = true, Caption = "Is Paid", Importance = 29)]
        public VarBoolean ispaidVar;

        [CoreVarVal("orderweight", "Double", Caption = "Order Weight", Importance = 31)]
        public VarDouble orderweightVar;

        [CoreVarVal("trackingnumber", "String", TheFieldLength = 8000, Caption = "Tracking Number", Importance = 33)]
        public VarString trackingnumberVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption = "Agent Name", Importance = 34)]
        public VarString agentnameVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 50, Caption = "Contact Name", Importance = 35)]
        public VarString contactnameVar;

        [CoreVarVal("primaryphone", "String", TheFieldLength = 50, Caption = "Primary Phone", Importance = 36)]
        public VarString primaryphoneVar;

        [CoreVarVal("primaryfax", "String", TheFieldLength = 50, Caption = "Primary Fax", Importance = 37)]
        public VarString primaryfaxVar;

        [CoreVarVal("primaryemailaddress", "String", TheFieldLength = 256, Caption = "Primary Email", Importance = 38)]
        public VarString primaryemailaddressVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 8000, Caption = "Company Name", Importance = 39)]
        public VarString companynameVar;

        [CoreVarVal("legacyagentid", "String", TheFieldLength = 50, Caption = "Legacy Agent", Importance = 40)]
        public VarString legacyagentidVar;

        [CoreVarVal("legacycompanyid", "String", TheFieldLength = 50, Caption = "Legacy Company", Importance = 41)]
        public VarString legacycompanyidVar;

        [CoreVarVal("orderdate", "DateTime", Caption = "Order Date", Importance = 42)]
        public VarDateTime orderdateVar;

        [CoreVarVal("orderreference", "String", TheFieldLength = 50, Caption = "Ref/po", Importance = 43)]
        public VarString orderreferenceVar;

        [CoreVarVal("comment", "String", TheFieldLength = 4096, Caption = "Comment", Importance = 44)]
        public VarString commentVar;

        [CoreVarVal("internalcomment", "String", TheFieldLength = 4096, Caption = "Internal Comment", Importance = 45)]
        public VarString internalcommentVar;

        [CoreVarVal("lastfilled", "DateTime", Caption = "Last Filled", Importance = 46)]
        public VarDateTime lastfilledVar;

        [CoreVarVal("dockdate", "DateTime", Caption = "Dock Date", Importance = 47)]
        public VarDateTime dockdateVar;

        [CoreVarVal("legacycontact", "String", TheFieldLength = 8000, Caption = "Legacy Contact", Importance = 48)]
        public VarString legacycontactVar;

        [CoreVarVal("shippingaccount", "String", TheFieldLength = 50, Caption = "Shipping Account", Importance = 49)]
        public VarString shippingaccountVar;

        [CoreVarVal("fillingagent", "String", TheFieldLength = 50, Caption = "Filling Agent", Importance = 50)]
        public VarString fillingagentVar;

        [CoreVarVal("hasbeenfilled", "Boolean", Caption = "Has Been Filled", Importance = 51)]
        public VarBoolean hasbeenfilledVar;

        [CoreVarVal("isproforma", "Boolean", Caption = "Is Proforma", Importance = 52)]
        public VarBoolean isproformaVar;

        [CoreVarVal("isflipdeal", "Boolean", Caption = "Is Flip Deal", Importance = 53)]
        public VarBoolean isflipdealVar;

        [CoreVarVal("country", "String", TheFieldLength = 50, Caption = "Country", Importance = 54)]
        public VarString countryVar;

        [CoreVarVal("ordertotal", "Double", Caption = "Order Total", Importance = 56)]
        public VarDouble ordertotalVar;

        [CoreVarVal("grossamount", "Double", Caption = "Gross Amount", Importance = 58)]
        public VarDouble grossamountVar;

        [CoreVarVal("costamount", "Double", Caption = "Cost Amount", Importance = 59)]
        public VarDouble costamountVar;

        [CoreVarVal("taxamount_exchanged", "Double", Caption = "Exchanged Tax", Importance = 175)]
        public VarDouble taxamount_exchangedVar;

        [CoreVarVal("shippingamount_exchanged", "Double", Caption = "Exchanged Shipping", Importance = 173)]
        public VarDouble shippingamount_exchangedVar;

        [CoreVarVal("profitamount", "Double", Caption = "Profit Amount", Importance = 62)]
        public VarDouble profitamountVar;

        [CoreVarVal("outstandingamount", "Double", Caption = "Outstanding Amount", Importance = 63)]
        public VarDouble outstandingamountVar;

        [CoreVarVal("grossamount_exchanged", "Double", Caption = "Exchanged Subtotal", Importance = 172)]
        public VarDouble grossamount_exchangedVar;

        [CoreVarVal("securityid", "String", TheFieldLength = 50, Caption = "Security Id", Importance = 65)]
        public VarString securityidVar;

        [CoreVarVal("printcomment", "String", TheFieldLength = 4096, Caption = "Print Comment", Importance = 66)]
        public VarString printcommentVar;

        [CoreVarVal("requireddate", "DateTime", Caption = "Required Date", Importance = 67)]
        public VarDateTime requireddateVar;

        [CoreVarVal("soreference", "String", TheFieldLength = 50, Caption = "Sales Reference", Importance = 68)]
        public VarString soreferenceVar;

        [CoreVarVal("senttoqb", "Boolean", Caption = "Sent To Qb", Importance = 69)]
        public VarBoolean senttoqbVar;

        [CoreVarVal("datesenttoqb", "DateTime", Caption = "Date Sent", Importance = 70)]
        public VarDateTime datesenttoqbVar;

        [CoreVarVal("rmareference", "String", TheFieldLength = 50, Caption = "Rma Reference", Importance = 71)]
        public VarString rmareferenceVar;

        [CoreVarVal("orderfob", "String", TheFieldLength = 50, Caption = "Order Fob", Importance = 72)]
        public VarString orderfobVar;

        [CoreVarVal("buyername", "String", TheFieldLength = 50, Caption = "Buyers Name", Importance = 74)]
        public VarString buyernameVar;

        [CoreVarVal("qualitycontrol", "String", TheFieldLength = 50, Caption = "Quality Control", Importance = 75)]
        public VarString qualitycontrolVar;

        [CoreVarVal("showonwarehouse", "Boolean", Caption = "Show On Warehouse", Importance = 76)]
        public VarBoolean showonwarehouseVar;

        [CoreVarVal("dateclosed", "DateTime", Caption = "Date Closed", Importance = 77)]
        public VarDateTime dateclosedVar;

        [CoreVarVal("existsonwarehouse", "Boolean", Caption = "Exists On Warehouse", Importance = 78)]
        public VarBoolean existsonwarehouseVar;

        [CoreVarVal("totalvalue", "Double", Caption = "Total Value", Importance = 79)]
        public VarDouble totalvalueVar;

        [CoreVarVal("isbuyin", "Boolean", Caption = "Is Buy In", Importance = 80)]
        public VarBoolean isbuyinVar;

        [CoreVarVal("isnewcustomer", "Boolean", Caption = "Is New Customer", Importance = 81)]
        public VarBoolean isnewcustomerVar;

        [CoreVarVal("ispromoattached", "Boolean", Caption = "Is Promo Attached", Importance = 82)]
        public VarBoolean ispromoattachedVar;

        [CoreVarVal("buyinid", "String", TheFieldLength = 50, Caption = "Buy In Id", Importance = 83)]
        public VarString buyinidVar;

        [CoreVarVal("isvalidated", "Boolean", Caption = "Is Validated", Importance = 84)]
        public VarBoolean isvalidatedVar;

        [CoreVarVal("orderbuyerid", "String", TheFieldLength = 50, Caption = "Buyer Id", Importance = 85)]
        public VarString orderbuyeridVar;

        [CoreVarVal("shipdate", "DateTime", Caption = "Ship Date", Importance = 86)]
        public VarDateTime shipdateVar;

        [CoreVarVal("usercode", "String", TheFieldLength = 50, Caption = "User Code", Importance = 87)]
        public VarString usercodeVar;

        [CoreVarVal("firstpartnumber", "String", TheFieldLength = 255, Caption = "First Part Number", Importance = 88)]
        public VarString firstpartnumberVar;

        [CoreVarVal("alternatetracking", "String", TheFieldLength = 255, Caption = "Alternate Tracking", Importance = 89)]
        public VarString alternatetrackingVar;

        [CoreVarVal("iswarned", "Boolean", Caption = "Is Warned", Importance = 90)]
        public VarBoolean iswarnedVar;

        [CoreVarVal("is_received", "Boolean", Caption = "Is Received", Importance = 91)]
        public VarBoolean is_receivedVar;

        [CoreVarVal("isverified", "Boolean", Caption = "Is Verified", Importance = 92)]
        public VarBoolean isverifiedVar;

        [CoreVarVal("readytoship", "Boolean", Caption = "Ready To Ship", Importance = 93)]
        public VarBoolean readytoshipVar;

        [CoreVarVal("payment_date", "DateTime", Caption = "Payment Date", Importance = 94)]
        public VarDateTime payment_dateVar;

        [CoreVarVal("is_commission_paid", "Boolean", Caption = "Is Commission Paid", Importance = 95)]
        public VarBoolean is_commission_paidVar;

        [CoreVarVal("date_expires", "DateTime", Caption = "Date Expires", Importance = 96)]
        public VarDateTime date_expiresVar;

        [CoreVarVal("c_of_c", "Boolean", Caption = "C Of C", Importance = 97)]
        public VarBoolean c_of_cVar;

        [CoreVarVal("ordertypedisplay", "String", TheFieldLength = 50, Caption = "Type Display", Importance = 98)]
        public VarString ordertypedisplayVar;

        [CoreVarVal("shippingdate", "DateTime", Caption = "Shippingdate", Importance = 99)]
        public VarDateTime shippingdateVar;

        [CoreVarVal("handlingdate", "DateTime", Caption = "Handlingdate", Importance = 100)]
        public VarDateTime handlingdateVar;

        [CoreVarVal("handlingamount_exchanged", "Double", Caption = "Exchanged Handling", Importance = 174)]
        public VarDouble handlingamount_exchangedVar;

        [CoreVarVal("ordertotal_exchanged", "Double", Caption = "Exchanged Order Total", Importance = 171)]
        public VarDouble ordertotal_exchangedVar;

        [CoreVarVal("exchange_rate", "Double", Caption = "Exchange Rate", Importance = 170)]
        public VarDouble exchange_rateVar;

        [CoreVarVal("onhold", "Boolean", Caption = "Onhold", Importance = 104)]
        public VarBoolean onholdVar;

        [CoreVarVal("holdreason", "String", TheFieldLength = 255, Caption = "Hold Reason", Importance = 105)]
        public VarString holdreasonVar;

        [CoreVarVal("rma_data", "String", TheFieldLength = 255, Caption = "Rma Data", Importance = 106)]
        public VarString rma_dataVar;

        [CoreVarVal("is_stock", "Boolean", Caption = "Is Stock Order", Importance = 107)]
        public VarBoolean is_stockVar;

        [CoreVarVal("subtract_1", "Double", Caption = "Subtract 1", Importance = 108)]
        public VarDouble subtract_1Var;

        [CoreVarVal("subtract_2", "Double", Caption = "Subtract 2", Importance = 109)]
        public VarDouble subtract_2Var;

        [CoreVarVal("subtract_3", "Double", Caption = "Subtract 3", Importance = 110)]
        public VarDouble subtract_3Var;

        [CoreVarVal("caption_data", "String", TheFieldLength = 255, Caption = "Caption Data", Importance = 111)]
        public VarString caption_dataVar;

        [CoreVarVal("invoice_date", "DateTime", Caption = "Invoice Date", Importance = 112)]
        public VarDateTime invoice_dateVar;

        [CoreVarVal("invoice_number", "String", TheFieldLength = 255, Caption = "Invoice Number", Importance = 113)]
        public VarString invoice_numberVar;

        [CoreVarVal("charged_amount", "Double", Caption = "Charged Amount", Importance = 114)]
        public VarDouble charged_amountVar;

        [CoreVarVal("shipping_caption", "String", TheFieldLength = 255, Caption = "Shipping Caption", Importance = 115)]
        public VarString shipping_captionVar;

        [CoreVarVal("handling_caption", "String", TheFieldLength = 255, Caption = "Handling Caption", Importance = 116)]
        public VarString handling_captionVar;

        [CoreVarVal("tax_caption", "String", TheFieldLength = 255, Caption = "Tax Caption", Importance = 117)]
        public VarString tax_captionVar;

        [CoreVarVal("subtract1_caption", "String", TheFieldLength = 255, Caption = "Subtract1 Caption", Importance = 118)]
        public VarString subtract1_captionVar;

        [CoreVarVal("subtract2_caption", "String", TheFieldLength = 255, Caption = "Subtract2 Caption", Importance = 119)]
        public VarString subtract2_captionVar;

        [CoreVarVal("subtract3_caption", "String", TheFieldLength = 255, Caption = "Subtract3 Caption", Importance = 120)]
        public VarString subtract3_captionVar;

        [CoreVarVal("no_return", "Boolean", Caption = "No Return", Importance = 121)]
        public VarBoolean no_returnVar;

        [CoreVarVal("is_government", "Boolean", Caption = "Is Government", Importance = 122)]
        public VarBoolean is_governmentVar;

        [CoreVarVal("billingname", "String", TheFieldLength = 255, Caption = "Billing Name", Importance = 123)]
        public VarString billingnameVar;

        [CoreVarVal("shippingname", "String", TheFieldLength = 255, Caption = "Shipping Name", Importance = 124)]
        public VarString shippingnameVar;

        [CoreVarVal("datecreated", "DateTime", Caption = "Datecreated", Importance = 125)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption = "Date Modified", Importance = 126)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("username", "String", TheFieldLength = 50, Caption = "User Name", Importance = 127)]
        public VarString usernameVar;

        [CoreVarVal("is_authorized", "Boolean", Caption = "Is Authorized", Importance = 128)]
        public VarBoolean is_authorizedVar;

        [CoreVarVal("authorized_date", "DateTime", Caption = "Authorized Date", Importance = 129)]
        public VarDateTime authorized_dateVar;

        [CoreVarVal("authorized_number", "Int64", Caption = "Authorized Number", Importance = 130)]
        public VarInt64 authorized_numberVar;

        [CoreVarVal("orderamount", "Double", Caption = "Order Amount", Importance = 131)]
        public VarDouble orderamountVar;

        [CoreVarVal("is_confirmed", "Boolean", Caption = "Is Confirmed", Importance = 132)]
        public VarBoolean is_confirmedVar;

        [CoreVarVal("has_issue", "Boolean", Caption = "Has Issue", Importance = 133)]
        public VarBoolean has_issueVar;

        [CoreVarVal("advance_payment_made", "Boolean", Caption = "Advance Payment Made", Importance = 134)]
        public VarBoolean advance_payment_madeVar;

        [CoreVarVal("currency_name", "String", Caption = "Currency", Importance = 175)]
        public VarString currency_nameVar;

        [CoreVarVal("note_id", "String", TheFieldLength = 255, Caption = "Note Id For Terms", Importance = 136)]
        public VarString note_idVar;

        [CoreVarVal("taxdate", "DateTime", Caption = "Taxdate", Importance = 137)]
        public VarDateTime taxdateVar;

        [CoreVarVal("trackingstripped", "String", TheFieldLength = 255, Caption = "Tracking Number Stripped", Importance = 138)]
        public VarString trackingstrippedVar;

        [CoreVarVal("did_call", "Boolean", Caption = "Did Call", Importance = 139)]
        public VarBoolean did_callVar;

        [CoreVarVal("email_date", "DateTime", Caption = "Email Date", Importance = 140)]
        public VarDateTime email_dateVar;

        [CoreVarVal("call_date", "DateTime", Caption = "Call Date", Importance = 141)]
        public VarDateTime call_dateVar;

        [CoreVarVal("email_date_group", "DateTime", Caption = "Email Date Group", Importance = 142)]
        public VarDateTime email_date_groupVar;

        [CoreVarVal("call_date_group", "DateTime", Caption = "Call Date Group", Importance = 143)]
        public VarDateTime call_date_groupVar;

        [CoreVarVal("is_qbimport", "Boolean", Caption = "Is Qb Import", Importance = 144)]
        public VarBoolean is_qbimportVar;

        [CoreVarVal("nameoncard", "String", TheFieldLength = 255, Caption = "Name On Card", Importance = 145)]
        public VarString nameoncardVar;

        [CoreVarVal("created_by_tree", "Boolean", Caption = "Created By Tree", Importance = 146)]
        public VarBoolean created_by_treeVar;

        [CoreVarVal("creditcardtype", "String", TheFieldLength = 255, Caption = "Credit Card Type", Importance = 147)]
        public VarString creditcardtypeVar;

        [CoreVarVal("expiration_month", "Int32", Caption = "Expiration Month", Importance = 148)]
        public VarInt32 expiration_monthVar;

        [CoreVarVal("expiration_year", "Int32", Caption = "Expiration Year", Importance = 149)]
        public VarInt32 expiration_yearVar;

        [CoreVarVal("security_code", "Int32", Caption = "Security Code", Importance = 150)]
        public VarInt32 security_codeVar;

        [CoreVarVal("cardbillingaddr", "String", TheFieldLength = 255, Caption = "Card Billing Address", Importance = 151)]
        public VarString cardbillingaddrVar;

        [CoreVarVal("cardbillingzip", "String", TheFieldLength = 255, Caption = "Card Billing Zip", Importance = 152)]
        public VarString cardbillingzipVar;

        [CoreVarVal("creditcardnumber", "String", TheFieldLength = 50, Caption = "Credit Card Number", Importance = 153)]
        public VarString creditcardnumberVar;

        [CoreVarVal("is_incomplete", "Boolean", Caption = "Is Incomplete", Importance = 154)]
        public VarBoolean is_incompleteVar;

        [CoreVarVal("fell_down", "Boolean", Caption = "Fell Down", Importance = 155)]
        public VarBoolean fell_downVar;

        [CoreVarVal("drop_ship_address", "String", TheFieldLength = 8000, Caption = "Drop Ship Address", Importance = 156)]
        public VarString drop_ship_addressVar;

        [CoreVarVal("securitycode", "String", TheFieldLength = 255, Caption = "Security Code", Importance = 157)]
        public VarString securitycodeVar;

        [CoreVarVal("credit_check_approved", "Boolean", Caption = "Credit Check Approved", Importance = 158)]
        public VarBoolean credit_check_approvedVar;

        [CoreVarVal("is_invoice", "Boolean", Caption = "Is Invoice", Importance = 159)]
        public VarBoolean is_invoiceVar;

        [CoreVarVal("credit_approve_agent", "String", TheFieldLength = 255, Caption = "Credit Approve Agent", Importance = 161)]
        public VarString credit_approve_agentVar;

        [CoreVarVal("credit_card_charged", "Boolean", Caption = "Credit Card Charged", Importance = 162)]
        public VarBoolean credit_card_chargedVar;

        [CoreVarVal("packingslip_complete", "Boolean", Caption = "Packingslip Complete", Importance = 163)]
        public VarBoolean packingslip_completeVar;

        [CoreVarVal("is_reppaid", "Boolean", Caption = "Is Rep Paid", Importance = 164)]
        public VarBoolean is_reppaidVar;

        [CoreVarVal("static_reportnote", "String", TheFieldLength = 255, Caption = "Static Reportnote", Importance = 165)]
        public VarString static_reportnoteVar;

        [CoreVarVal("is_buyerpaid", "Boolean", Caption = "Is Buyer Paid", Importance = 166)]
        public VarBoolean is_buyerpaidVar;

        [CoreVarVal("ord_contents", "String", TheFieldLength = 255, Caption = "Contents", Importance = 167)]
        public VarString ord_contentsVar;

        [CoreVarVal("harmonized_code", "String", TheFieldLength = 255, Caption = "Harmonized Code", Importance = 168)]
        public VarString harmonized_codeVar;

        [CoreVarVal("total_packages", "Int64", Caption = "Total Packages", Importance = 169)]
        public VarInt64 total_packagesVar;

        [CoreVarVal("total_weight", "Double", Caption = "Total Weight", Importance = 170)]
        public VarDouble total_weightVar;

        [CoreVarVal("strippedphone", "String", TheFieldLength = 255, Caption = "Strippedphone", Importance = 171)]
        public VarString strippedphoneVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption = "Abs Type", Importance = 172)]
        public VarString abs_typeVar;

        [CoreVarVal("followup_date", "DateTime", Caption = "Followup Date", Importance = 173)]
        public VarDateTime followup_dateVar;

        [CoreVarVal("warranty_period", "String", TheFieldLength = 255, Caption = "Warranty Period", Importance = 174)]
        public VarString warranty_periodVar;

        [CoreVarVal("date_paid", "DateTime", Caption = "Date Paid", Importance = 175)]
        public VarDateTime date_paidVar;

        [CoreVarVal("warehouse_id", "String", TheFieldLength = 255, Caption = "Warehouse Id", Importance = 176)]
        public VarString warehouse_idVar;

        [CoreVarVal("extra_info", "String", TheFieldLength = 8000, Caption = "Extra Info", Importance = 177)]
        public VarString extra_infoVar;

        [CoreVarVal("vendor_invoice_number", "String", TheFieldLength = 255, Caption = "Vendor Invoice Number", Importance = 178)]
        public VarString vendor_invoice_numberVar;

        [CoreVarVal("action_taken", "String", TheFieldLength = 255, Caption = "Action Taken", Importance = 179)]
        public VarString action_takenVar;

        [CoreVarVal("certs_required", "Boolean", Caption = "Certs Required", Importance = 180)]
        public VarBoolean certs_requiredVar;

        [CoreVarVal("lead_source", "String", TheFieldLength = 255, Caption = "Lead Source", Importance = 181)]
        public VarString lead_sourceVar;

        [CoreVarVal("email_domain", "String", TheFieldLength = 255, Caption = "Email Domain", Importance = 182)]
        public VarString email_domainVar;

        [CoreVarVal("email_suffix", "String", TheFieldLength = 255, Caption = "Email Suffix", Importance = 183)]
        public VarString email_suffixVar;

        [CoreVarVal("shippingamount_print", "String", Caption = "Shipping Print", Importance = 176)]
        public VarString shippingamount_printVar;

        [CoreVarVal("handlingamount_print", "String", Caption = "Handling Print", Importance = 177)]
        public VarString handlingamount_printVar;

        [CoreVarVal("taxamount_print", "String", Caption = "Tax Print", Importance = 178)]
        public VarString taxamount_printVar;

        [CoreVarVal("ordertotal_print", "String", Caption = "Total Print", Importance = 179)]
        public VarString ordertotal_printVar;

        [CoreVarVal("creditamount", "Double", Caption = "Credit Amount", Importance = 180)]
        public VarDouble creditamountVar;

        [CoreVarVal("hubspot_deal_id", "Int64", Caption = "Hubspot Deal ID", Importance = 181)]
        public VarInt64 hubspot_deal_idVar;

        [CoreVarVal("qb_order_TxnID", "string", Caption = "Quickboks Transaction ID", Importance = 182)]
        public VarString qb_order_TxnIDVar;

        [CoreVarVal("opportunity_stage", "string", Caption = "Opportunity Stage", Importance = 183)]
        public VarString opportunity_stageVar;

        [CoreVarVal("opportunity_lost_reason", "string", Caption = "Opportunity Lost Reason", Importance = 184)]
        public VarString opportunity_lost_reasonVar;

        [CoreVarVal("opportunity_type", "string", Caption = "Opportunity Type", Importance = 185)]
        public VarString opportunity_typeVar;







        public ordhed_auto()
        {
            StaticInit();
            base_dealheader_uidVar = new VarString(this, base_dealheader_uidAttribute);
            base_division_uidVar = new VarString(this, base_division_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            ordernumberVar = new VarString(this, ordernumberAttribute);
            ordertypeVar = new VarString(this, ordertypeAttribute);
            useridVar = new VarString(this, useridAttribute);
            freightbillingVar = new VarString(this, freightbillingAttribute);
            isinternationalVar = new VarBoolean(this, isinternationalAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            shipviaVar = new VarString(this, shipviaAttribute);
            termsVar = new VarString(this, termsAttribute);
            shippingamountVar = new VarDouble(this, shippingamountAttribute);
            handlingamountVar = new VarDouble(this, handlingamountAttribute);
            taxamountVar = new VarDouble(this, taxamountAttribute);
            billingaddressVar = new VarString(this, billingaddressAttribute);
            shippingaddressVar = new VarString(this, shippingaddressAttribute);
            taxrateidVar = new VarString(this, taxrateidAttribute);
            specialinstructionshippingVar = new VarString(this, specialinstructionshippingAttribute);
            specialinstructionsbillingVar = new VarString(this, specialinstructionsbillingAttribute);
            packinginfoVar = new VarString(this, packinginfoAttribute);
            islockedVar = new VarBoolean(this, islockedAttribute);
            isclosedVar = new VarBoolean(this, isclosedAttribute);
            isvoidVar = new VarBoolean(this, isvoidAttribute);
            ispaidVar = new VarBoolean(this, ispaidAttribute);
            orderweightVar = new VarDouble(this, orderweightAttribute);
            trackingnumberVar = new VarString(this, trackingnumberAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            primaryphoneVar = new VarString(this, primaryphoneAttribute);
            primaryfaxVar = new VarString(this, primaryfaxAttribute);
            primaryemailaddressVar = new VarString(this, primaryemailaddressAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            legacyagentidVar = new VarString(this, legacyagentidAttribute);
            legacycompanyidVar = new VarString(this, legacycompanyidAttribute);
            orderdateVar = new VarDateTime(this, orderdateAttribute);
            orderreferenceVar = new VarString(this, orderreferenceAttribute);
            commentVar = new VarString(this, commentAttribute);
            internalcommentVar = new VarString(this, internalcommentAttribute);
            lastfilledVar = new VarDateTime(this, lastfilledAttribute);
            dockdateVar = new VarDateTime(this, dockdateAttribute);
            legacycontactVar = new VarString(this, legacycontactAttribute);
            shippingaccountVar = new VarString(this, shippingaccountAttribute);
            fillingagentVar = new VarString(this, fillingagentAttribute);
            hasbeenfilledVar = new VarBoolean(this, hasbeenfilledAttribute);
            isproformaVar = new VarBoolean(this, isproformaAttribute);
            isflipdealVar = new VarBoolean(this, isflipdealAttribute);
            countryVar = new VarString(this, countryAttribute);
            ordertotalVar = new VarDouble(this, ordertotalAttribute);
            grossamountVar = new VarDouble(this, grossamountAttribute);
            costamountVar = new VarDouble(this, costamountAttribute);
            taxamount_exchangedVar = new VarDouble(this, taxamount_exchangedAttribute);
            shippingamount_exchangedVar = new VarDouble(this, shippingamount_exchangedAttribute);
            profitamountVar = new VarDouble(this, profitamountAttribute);
            outstandingamountVar = new VarDouble(this, outstandingamountAttribute);
            grossamount_exchangedVar = new VarDouble(this, grossamount_exchangedAttribute);
            securityidVar = new VarString(this, securityidAttribute);
            printcommentVar = new VarString(this, printcommentAttribute);
            requireddateVar = new VarDateTime(this, requireddateAttribute);
            soreferenceVar = new VarString(this, soreferenceAttribute);
            senttoqbVar = new VarBoolean(this, senttoqbAttribute);
            datesenttoqbVar = new VarDateTime(this, datesenttoqbAttribute);
            rmareferenceVar = new VarString(this, rmareferenceAttribute);
            orderfobVar = new VarString(this, orderfobAttribute);
            buyernameVar = new VarString(this, buyernameAttribute);
            qualitycontrolVar = new VarString(this, qualitycontrolAttribute);
            showonwarehouseVar = new VarBoolean(this, showonwarehouseAttribute);
            dateclosedVar = new VarDateTime(this, dateclosedAttribute);
            existsonwarehouseVar = new VarBoolean(this, existsonwarehouseAttribute);
            totalvalueVar = new VarDouble(this, totalvalueAttribute);
            isbuyinVar = new VarBoolean(this, isbuyinAttribute);
            isnewcustomerVar = new VarBoolean(this, isnewcustomerAttribute);
            ispromoattachedVar = new VarBoolean(this, ispromoattachedAttribute);
            buyinidVar = new VarString(this, buyinidAttribute);
            isvalidatedVar = new VarBoolean(this, isvalidatedAttribute);
            orderbuyeridVar = new VarString(this, orderbuyeridAttribute);
            shipdateVar = new VarDateTime(this, shipdateAttribute);
            usercodeVar = new VarString(this, usercodeAttribute);
            firstpartnumberVar = new VarString(this, firstpartnumberAttribute);
            alternatetrackingVar = new VarString(this, alternatetrackingAttribute);
            iswarnedVar = new VarBoolean(this, iswarnedAttribute);
            is_receivedVar = new VarBoolean(this, is_receivedAttribute);
            isverifiedVar = new VarBoolean(this, isverifiedAttribute);
            readytoshipVar = new VarBoolean(this, readytoshipAttribute);
            payment_dateVar = new VarDateTime(this, payment_dateAttribute);
            is_commission_paidVar = new VarBoolean(this, is_commission_paidAttribute);
            date_expiresVar = new VarDateTime(this, date_expiresAttribute);
            c_of_cVar = new VarBoolean(this, c_of_cAttribute);
            ordertypedisplayVar = new VarString(this, ordertypedisplayAttribute);
            shippingdateVar = new VarDateTime(this, shippingdateAttribute);
            handlingdateVar = new VarDateTime(this, handlingdateAttribute);
            handlingamount_exchangedVar = new VarDouble(this, handlingamount_exchangedAttribute);
            ordertotal_exchangedVar = new VarDouble(this, ordertotal_exchangedAttribute);
            exchange_rateVar = new VarDouble(this, exchange_rateAttribute);
            onholdVar = new VarBoolean(this, onholdAttribute);
            holdreasonVar = new VarString(this, holdreasonAttribute);
            rma_dataVar = new VarString(this, rma_dataAttribute);
            is_stockVar = new VarBoolean(this, is_stockAttribute);
            subtract_1Var = new VarDouble(this, subtract_1Attribute);
            subtract_2Var = new VarDouble(this, subtract_2Attribute);
            subtract_3Var = new VarDouble(this, subtract_3Attribute);
            caption_dataVar = new VarString(this, caption_dataAttribute);
            invoice_dateVar = new VarDateTime(this, invoice_dateAttribute);
            invoice_numberVar = new VarString(this, invoice_numberAttribute);
            charged_amountVar = new VarDouble(this, charged_amountAttribute);
            shipping_captionVar = new VarString(this, shipping_captionAttribute);
            handling_captionVar = new VarString(this, handling_captionAttribute);
            tax_captionVar = new VarString(this, tax_captionAttribute);
            subtract1_captionVar = new VarString(this, subtract1_captionAttribute);
            subtract2_captionVar = new VarString(this, subtract2_captionAttribute);
            subtract3_captionVar = new VarString(this, subtract3_captionAttribute);
            no_returnVar = new VarBoolean(this, no_returnAttribute);
            is_governmentVar = new VarBoolean(this, is_governmentAttribute);
            billingnameVar = new VarString(this, billingnameAttribute);
            shippingnameVar = new VarString(this, shippingnameAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            usernameVar = new VarString(this, usernameAttribute);
            is_authorizedVar = new VarBoolean(this, is_authorizedAttribute);
            authorized_dateVar = new VarDateTime(this, authorized_dateAttribute);
            authorized_numberVar = new VarInt64(this, authorized_numberAttribute);
            orderamountVar = new VarDouble(this, orderamountAttribute);
            is_confirmedVar = new VarBoolean(this, is_confirmedAttribute);
            has_issueVar = new VarBoolean(this, has_issueAttribute);
            advance_payment_madeVar = new VarBoolean(this, advance_payment_madeAttribute);
            currency_nameVar = new VarString(this, currency_nameAttribute);
            note_idVar = new VarString(this, note_idAttribute);
            taxdateVar = new VarDateTime(this, taxdateAttribute);
            trackingstrippedVar = new VarString(this, trackingstrippedAttribute);
            did_callVar = new VarBoolean(this, did_callAttribute);
            email_dateVar = new VarDateTime(this, email_dateAttribute);
            call_dateVar = new VarDateTime(this, call_dateAttribute);
            email_date_groupVar = new VarDateTime(this, email_date_groupAttribute);
            call_date_groupVar = new VarDateTime(this, call_date_groupAttribute);
            is_qbimportVar = new VarBoolean(this, is_qbimportAttribute);
            nameoncardVar = new VarString(this, nameoncardAttribute);
            created_by_treeVar = new VarBoolean(this, created_by_treeAttribute);
            creditcardtypeVar = new VarString(this, creditcardtypeAttribute);
            expiration_monthVar = new VarInt32(this, expiration_monthAttribute);
            expiration_yearVar = new VarInt32(this, expiration_yearAttribute);
            security_codeVar = new VarInt32(this, security_codeAttribute);
            cardbillingaddrVar = new VarString(this, cardbillingaddrAttribute);
            cardbillingzipVar = new VarString(this, cardbillingzipAttribute);
            creditcardnumberVar = new VarString(this, creditcardnumberAttribute);
            is_incompleteVar = new VarBoolean(this, is_incompleteAttribute);
            fell_downVar = new VarBoolean(this, fell_downAttribute);
            drop_ship_addressVar = new VarString(this, drop_ship_addressAttribute);
            securitycodeVar = new VarString(this, securitycodeAttribute);
            credit_check_approvedVar = new VarBoolean(this, credit_check_approvedAttribute);
            is_invoiceVar = new VarBoolean(this, is_invoiceAttribute);
            credit_approve_agentVar = new VarString(this, credit_approve_agentAttribute);
            credit_card_chargedVar = new VarBoolean(this, credit_card_chargedAttribute);
            packingslip_completeVar = new VarBoolean(this, packingslip_completeAttribute);
            is_reppaidVar = new VarBoolean(this, is_reppaidAttribute);
            static_reportnoteVar = new VarString(this, static_reportnoteAttribute);
            is_buyerpaidVar = new VarBoolean(this, is_buyerpaidAttribute);
            ord_contentsVar = new VarString(this, ord_contentsAttribute);
            harmonized_codeVar = new VarString(this, harmonized_codeAttribute);
            total_packagesVar = new VarInt64(this, total_packagesAttribute);
            total_weightVar = new VarDouble(this, total_weightAttribute);
            strippedphoneVar = new VarString(this, strippedphoneAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            followup_dateVar = new VarDateTime(this, followup_dateAttribute);
            warranty_periodVar = new VarString(this, warranty_periodAttribute);
            date_paidVar = new VarDateTime(this, date_paidAttribute);
            warehouse_idVar = new VarString(this, warehouse_idAttribute);
            extra_infoVar = new VarString(this, extra_infoAttribute);
            vendor_invoice_numberVar = new VarString(this, vendor_invoice_numberAttribute);
            action_takenVar = new VarString(this, action_takenAttribute);
            certs_requiredVar = new VarBoolean(this, certs_requiredAttribute);
            lead_sourceVar = new VarString(this, lead_sourceAttribute);
            email_domainVar = new VarString(this, email_domainAttribute);
            email_suffixVar = new VarString(this, email_suffixAttribute);
            shippingamount_printVar = new VarString(this, shippingamount_printAttribute);
            handlingamount_printVar = new VarString(this, handlingamount_printAttribute);
            taxamount_printVar = new VarString(this, taxamount_printAttribute);
            ordertotal_printVar = new VarString(this, ordertotal_printAttribute);
            creditamountVar = new VarDouble(this, creditamountAttribute);
            hubspot_deal_idVar = new VarInt64(this, hubspot_deal_idAttribute);
            qb_order_TxnIDVar = new VarString(this, qb_order_TxnIDAttribute);
            opportunity_stageVar = new VarString(this, opportunity_stageAttribute);
            opportunity_lost_reasonVar = new VarString(this, opportunity_lost_reasonAttribute);
            opportunity_typeVar = new VarString(this, opportunity_typeAttribute);




        }

        public override string ClassId
        { get { return "ordhed"; } }

        public String base_dealheader_uid
        {
            get { return (String)base_dealheader_uidVar.Value; }
            set { base_dealheader_uidVar.Value = value; }
        }

        public String base_division_uid
        {
            get { return (String)base_division_uidVar.Value; }
            set { base_division_uidVar.Value = value; }
        }

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

        public String ordernumber
        {
            get { return (String)ordernumberVar.Value; }
            set { ordernumberVar.Value = value; }
        }

        public String ordertype
        {
            get { return (String)ordertypeVar.Value; }
            set { ordertypeVar.Value = value; }
        }

        public String userid
        {
            get { return (String)useridVar.Value; }
            set { useridVar.Value = value; }
        }

        public String freightbilling
        {
            get { return (String)freightbillingVar.Value; }
            set { freightbillingVar.Value = value; }
        }

        public Boolean isinternational
        {
            get { return (Boolean)isinternationalVar.Value; }
            set { isinternationalVar.Value = value; }
        }

        public String modifiedby
        {
            get { return (String)modifiedbyVar.Value; }
            set { modifiedbyVar.Value = value; }
        }

        public String shipvia
        {
            get { return (String)shipviaVar.Value; }
            set { shipviaVar.Value = value; }
        }

        public String terms
        {
            get { return (String)termsVar.Value; }
            set { termsVar.Value = value; }
        }

        public Double shippingamount
        {
            get { return (Double)shippingamountVar.Value; }
            set { shippingamountVar.Value = value; }
        }

        public Double handlingamount
        {
            get { return (Double)handlingamountVar.Value; }
            set { handlingamountVar.Value = value; }
        }

        public Double taxamount
        {
            get { return (Double)taxamountVar.Value; }
            set { taxamountVar.Value = value; }
        }

        public String billingaddress
        {
            get { return (String)billingaddressVar.Value; }
            set { billingaddressVar.Value = value; }
        }

        public String shippingaddress
        {
            get { return (String)shippingaddressVar.Value; }
            set { shippingaddressVar.Value = value; }
        }

        public String taxrateid
        {
            get { return (String)taxrateidVar.Value; }
            set { taxrateidVar.Value = value; }
        }

        public String specialinstructionshipping
        {
            get { return (String)specialinstructionshippingVar.Value; }
            set { specialinstructionshippingVar.Value = value; }
        }

        public String specialinstructionsbilling
        {
            get { return (String)specialinstructionsbillingVar.Value; }
            set { specialinstructionsbillingVar.Value = value; }
        }

        public String packinginfo
        {
            get { return (String)packinginfoVar.Value; }
            set { packinginfoVar.Value = value; }
        }

        public Boolean islocked
        {
            get { return (Boolean)islockedVar.Value; }
            set { islockedVar.Value = value; }
        }

        public Boolean isclosed
        {
            get { return (Boolean)isclosedVar.Value; }
            set { isclosedVar.Value = value; }
        }

        public Boolean isvoid
        {
            get { return (Boolean)isvoidVar.Value; }
            set { isvoidVar.Value = value; }
        }

        public Boolean ispaid
        {
            get { return (Boolean)ispaidVar.Value; }
        }

        public Double orderweight
        {
            get { return (Double)orderweightVar.Value; }
            set { orderweightVar.Value = value; }
        }

        public String trackingnumber
        {
            get { return (String)trackingnumberVar.Value; }
            set { trackingnumberVar.Value = value; }
        }

        public String agentname
        {
            get { return (String)agentnameVar.Value; }
            set { agentnameVar.Value = value; }
        }

        public String contactname
        {
            get { return (String)contactnameVar.Value; }
            set { contactnameVar.Value = value; }
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

        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }

        public String legacyagentid
        {
            get { return (String)legacyagentidVar.Value; }
            set { legacyagentidVar.Value = value; }
        }

        public String legacycompanyid
        {
            get { return (String)legacycompanyidVar.Value; }
            set { legacycompanyidVar.Value = value; }
        }

        public DateTime orderdate
        {
            get { return (DateTime)orderdateVar.Value; }
            set { orderdateVar.Value = value; }
        }

        public String orderreference
        {
            get { return (String)orderreferenceVar.Value; }
            set { orderreferenceVar.Value = value; }
        }

        public String comment
        {
            get { return (String)commentVar.Value; }
            set { commentVar.Value = value; }
        }

        public String internalcomment
        {
            get { return (String)internalcommentVar.Value; }
            set { internalcommentVar.Value = value; }
        }

        public DateTime lastfilled
        {
            get { return (DateTime)lastfilledVar.Value; }
            set { lastfilledVar.Value = value; }
        }

        public DateTime dockdate
        {
            get { return (DateTime)dockdateVar.Value; }
            set { dockdateVar.Value = value; }
        }

        public String legacycontact
        {
            get { return (String)legacycontactVar.Value; }
            set { legacycontactVar.Value = value; }
        }

        public String shippingaccount
        {
            get { return (String)shippingaccountVar.Value; }
            set { shippingaccountVar.Value = value; }
        }

        public String fillingagent
        {
            get { return (String)fillingagentVar.Value; }
            set { fillingagentVar.Value = value; }
        }

        public Boolean hasbeenfilled
        {
            get { return (Boolean)hasbeenfilledVar.Value; }
            set { hasbeenfilledVar.Value = value; }
        }

        public Boolean isproforma
        {
            get { return (Boolean)isproformaVar.Value; }
            set { isproformaVar.Value = value; }
        }

        public Boolean isflipdeal
        {
            get { return (Boolean)isflipdealVar.Value; }
            set { isflipdealVar.Value = value; }
        }

        public String country
        {
            get { return (String)countryVar.Value; }
            set { countryVar.Value = value; }
        }

        public Double ordertotal
        {
            get { return (Double)ordertotalVar.Value; }
            set { ordertotalVar.Value = value; }
        }

        public Double grossamount
        {
            get { return (Double)grossamountVar.Value; }
            set { grossamountVar.Value = value; }
        }

        public Double costamount
        {
            get { return (Double)costamountVar.Value; }
            set { costamountVar.Value = value; }
        }

        public Double taxamount_exchanged
        {
            get { return (Double)taxamount_exchangedVar.Value; }
            set { taxamount_exchangedVar.Value = value; }
        }

        public Double shippingamount_exchanged
        {
            get { return (Double)shippingamount_exchangedVar.Value; }
            set { shippingamount_exchangedVar.Value = value; }
        }

        public Double profitamount
        {
            get { return (Double)profitamountVar.Value; }
            set { profitamountVar.Value = value; }
        }

        public Double outstandingamount
        {
            get { return (Double)outstandingamountVar.Value; }
            set { outstandingamountVar.Value = value; }
        }

        public Double grossamount_exchanged
        {
            get { return (Double)grossamount_exchangedVar.Value; }
            set { grossamount_exchangedVar.Value = value; }
        }

        public String securityid
        {
            get { return (String)securityidVar.Value; }
            set { securityidVar.Value = value; }
        }

        public String printcomment
        {
            get { return (String)printcommentVar.Value; }
            set { printcommentVar.Value = value; }
        }

        public DateTime requireddate
        {
            get { return (DateTime)requireddateVar.Value; }
            set { requireddateVar.Value = value; }
        }

        public String soreference
        {
            get { return (String)soreferenceVar.Value; }
            set { soreferenceVar.Value = value; }
        }

        public Boolean senttoqb
        {
            get { return (Boolean)senttoqbVar.Value; }
            set { senttoqbVar.Value = value; }
        }

        public DateTime datesenttoqb
        {
            get { return (DateTime)datesenttoqbVar.Value; }
            set { datesenttoqbVar.Value = value; }
        }

        public String rmareference
        {
            get { return (String)rmareferenceVar.Value; }
            set { rmareferenceVar.Value = value; }
        }

        public String orderfob
        {
            get { return (String)orderfobVar.Value; }
            set { orderfobVar.Value = value; }
        }

        public String buyername
        {
            get { return (String)buyernameVar.Value; }
            set { buyernameVar.Value = value; }
        }

        public String qualitycontrol
        {
            get { return (String)qualitycontrolVar.Value; }
            set { qualitycontrolVar.Value = value; }
        }

        public Boolean showonwarehouse
        {
            get { return (Boolean)showonwarehouseVar.Value; }
            set { showonwarehouseVar.Value = value; }
        }

        public DateTime dateclosed
        {
            get { return (DateTime)dateclosedVar.Value; }
            set { dateclosedVar.Value = value; }
        }

        public Boolean existsonwarehouse
        {
            get { return (Boolean)existsonwarehouseVar.Value; }
            set { existsonwarehouseVar.Value = value; }
        }

        public Double totalvalue
        {
            get { return (Double)totalvalueVar.Value; }
            set { totalvalueVar.Value = value; }
        }

        public Boolean isbuyin
        {
            get { return (Boolean)isbuyinVar.Value; }
            set { isbuyinVar.Value = value; }
        }

        public Boolean isnewcustomer
        {
            get { return (Boolean)isnewcustomerVar.Value; }
            set { isnewcustomerVar.Value = value; }
        }

        public Boolean ispromoattached
        {
            get { return (Boolean)ispromoattachedVar.Value; }
            set { ispromoattachedVar.Value = value; }
        }

        public String buyinid
        {
            get { return (String)buyinidVar.Value; }
            set { buyinidVar.Value = value; }
        }

        public Boolean isvalidated
        {
            get { return (Boolean)isvalidatedVar.Value; }
            set { isvalidatedVar.Value = value; }
        }

        public String orderbuyerid
        {
            get { return (String)orderbuyeridVar.Value; }
            set { orderbuyeridVar.Value = value; }
        }

        public DateTime shipdate
        {
            get { return (DateTime)shipdateVar.Value; }
            set { shipdateVar.Value = value; }
        }

        public String usercode
        {
            get { return (String)usercodeVar.Value; }
            set { usercodeVar.Value = value; }
        }

        public String firstpartnumber
        {
            get { return (String)firstpartnumberVar.Value; }
            set { firstpartnumberVar.Value = value; }
        }

        public String alternatetracking
        {
            get { return (String)alternatetrackingVar.Value; }
            set { alternatetrackingVar.Value = value; }
        }

        public Boolean iswarned
        {
            get { return (Boolean)iswarnedVar.Value; }
            set { iswarnedVar.Value = value; }
        }

        public Boolean is_received
        {
            get { return (Boolean)is_receivedVar.Value; }
            set { is_receivedVar.Value = value; }
        }

        public Boolean isverified
        {
            get { return (Boolean)isverifiedVar.Value; }
            set { isverifiedVar.Value = value; }
        }

        public Boolean readytoship
        {
            get { return (Boolean)readytoshipVar.Value; }
            set { readytoshipVar.Value = value; }
        }

        public DateTime payment_date
        {
            get { return (DateTime)payment_dateVar.Value; }
            set { payment_dateVar.Value = value; }
        }

        public Boolean is_commission_paid
        {
            get { return (Boolean)is_commission_paidVar.Value; }
            set { is_commission_paidVar.Value = value; }
        }

        public DateTime date_expires
        {
            get { return (DateTime)date_expiresVar.Value; }
            set { date_expiresVar.Value = value; }
        }

        public Boolean c_of_c
        {
            get { return (Boolean)c_of_cVar.Value; }
            set { c_of_cVar.Value = value; }
        }

        public String ordertypedisplay
        {
            get { return (String)ordertypedisplayVar.Value; }
            set { ordertypedisplayVar.Value = value; }
        }

        public DateTime shippingdate
        {
            get { return (DateTime)shippingdateVar.Value; }
            set { shippingdateVar.Value = value; }
        }

        public DateTime handlingdate
        {
            get { return (DateTime)handlingdateVar.Value; }
            set { handlingdateVar.Value = value; }
        }

        public Double handlingamount_exchanged
        {
            get { return (Double)handlingamount_exchangedVar.Value; }
            set { handlingamount_exchangedVar.Value = value; }
        }

        public Double ordertotal_exchanged
        {
            get { return (Double)ordertotal_exchangedVar.Value; }
            set { ordertotal_exchangedVar.Value = value; }
        }

        public Double exchange_rate
        {
            get { return (Double)exchange_rateVar.Value; }
            set { exchange_rateVar.Value = value; }
        }

        public Boolean onhold
        {
            get { return (Boolean)onholdVar.Value; }
            set { onholdVar.Value = value; }
        }

        public String holdreason
        {
            get { return (String)holdreasonVar.Value; }
            set { holdreasonVar.Value = value; }
        }

        public String rma_data
        {
            get { return (String)rma_dataVar.Value; }
            set { rma_dataVar.Value = value; }
        }

        public Boolean is_stock
        {
            get { return (Boolean)is_stockVar.Value; }
            set { is_stockVar.Value = value; }
        }

        public Double subtract_1
        {
            get { return (Double)subtract_1Var.Value; }
            set { subtract_1Var.Value = value; }
        }

        public Double subtract_2
        {
            get { return (Double)subtract_2Var.Value; }
            set { subtract_2Var.Value = value; }
        }

        public Double subtract_3
        {
            get { return (Double)subtract_3Var.Value; }
            set { subtract_3Var.Value = value; }
        }

        public String caption_data
        {
            get { return (String)caption_dataVar.Value; }
            set { caption_dataVar.Value = value; }
        }

        public DateTime invoice_date
        {
            get { return (DateTime)invoice_dateVar.Value; }
            set { invoice_dateVar.Value = value; }
        }

        public String invoice_number
        {
            get { return (String)invoice_numberVar.Value; }
            set { invoice_numberVar.Value = value; }
        }

        public Double charged_amount
        {
            get { return (Double)charged_amountVar.Value; }
            set { charged_amountVar.Value = value; }
        }

        public String shipping_caption
        {
            get { return (String)shipping_captionVar.Value; }
            set { shipping_captionVar.Value = value; }
        }

        public String handling_caption
        {
            get { return (String)handling_captionVar.Value; }
            set { handling_captionVar.Value = value; }
        }

        public String tax_caption
        {
            get { return (String)tax_captionVar.Value; }
            set { tax_captionVar.Value = value; }
        }

        public String subtract1_caption
        {
            get { return (String)subtract1_captionVar.Value; }
            set { subtract1_captionVar.Value = value; }
        }

        public String subtract2_caption
        {
            get { return (String)subtract2_captionVar.Value; }
            set { subtract2_captionVar.Value = value; }
        }

        public String subtract3_caption
        {
            get { return (String)subtract3_captionVar.Value; }
            set { subtract3_captionVar.Value = value; }
        }

        public Boolean no_return
        {
            get { return (Boolean)no_returnVar.Value; }
            set { no_returnVar.Value = value; }
        }

        public Boolean is_government
        {
            get { return (Boolean)is_governmentVar.Value; }
            set { is_governmentVar.Value = value; }
        }

        public String billingname
        {
            get { return (String)billingnameVar.Value; }
            set { billingnameVar.Value = value; }
        }

        public String shippingname
        {
            get { return (String)shippingnameVar.Value; }
            set { shippingnameVar.Value = value; }
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

        public String username
        {
            get { return (String)usernameVar.Value; }
            set { usernameVar.Value = value; }
        }

        public Boolean is_authorized
        {
            get { return (Boolean)is_authorizedVar.Value; }
            set { is_authorizedVar.Value = value; }
        }

        public DateTime authorized_date
        {
            get { return (DateTime)authorized_dateVar.Value; }
            set { authorized_dateVar.Value = value; }
        }

        public Int64 authorized_number
        {
            get { return (Int64)authorized_numberVar.Value; }
            set { authorized_numberVar.Value = value; }
        }

        public Double orderamount
        {
            get { return (Double)orderamountVar.Value; }
            set { orderamountVar.Value = value; }
        }

        public Boolean is_confirmed
        {
            get { return (Boolean)is_confirmedVar.Value; }
            set { is_confirmedVar.Value = value; }
        }

        public Boolean has_issue
        {
            get { return (Boolean)has_issueVar.Value; }
            set { has_issueVar.Value = value; }
        }

        public Boolean advance_payment_made
        {
            get { return (Boolean)advance_payment_madeVar.Value; }
            set { advance_payment_madeVar.Value = value; }
        }

        public String currency_name
        {
            get { return (String)currency_nameVar.Value; }
            set { currency_nameVar.Value = value; }
        }

        public String note_id
        {
            get { return (String)note_idVar.Value; }
            set { note_idVar.Value = value; }
        }

        public DateTime taxdate
        {
            get { return (DateTime)taxdateVar.Value; }
            set { taxdateVar.Value = value; }
        }

        public String trackingstripped
        {
            get { return (String)trackingstrippedVar.Value; }
            set { trackingstrippedVar.Value = value; }
        }

        public Boolean did_call
        {
            get { return (Boolean)did_callVar.Value; }
            set { did_callVar.Value = value; }
        }

        public DateTime email_date
        {
            get { return (DateTime)email_dateVar.Value; }
            set { email_dateVar.Value = value; }
        }

        public DateTime call_date
        {
            get { return (DateTime)call_dateVar.Value; }
            set { call_dateVar.Value = value; }
        }

        public DateTime email_date_group
        {
            get { return (DateTime)email_date_groupVar.Value; }
            set { email_date_groupVar.Value = value; }
        }

        public DateTime call_date_group
        {
            get { return (DateTime)call_date_groupVar.Value; }
            set { call_date_groupVar.Value = value; }
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

        public Boolean created_by_tree
        {
            get { return (Boolean)created_by_treeVar.Value; }
            set { created_by_treeVar.Value = value; }
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

        public String creditcardnumber
        {
            get { return (String)creditcardnumberVar.Value; }
            set { creditcardnumberVar.Value = value; }
        }

        public Boolean is_incomplete
        {
            get { return (Boolean)is_incompleteVar.Value; }
            set { is_incompleteVar.Value = value; }
        }

        public Boolean fell_down
        {
            get { return (Boolean)fell_downVar.Value; }
            set { fell_downVar.Value = value; }
        }

        public String drop_ship_address
        {
            get { return (String)drop_ship_addressVar.Value; }
            set { drop_ship_addressVar.Value = value; }
        }

        public String securitycode
        {
            get { return (String)securitycodeVar.Value; }
            set { securitycodeVar.Value = value; }
        }

        public Boolean credit_check_approved
        {
            get { return (Boolean)credit_check_approvedVar.Value; }
            set { credit_check_approvedVar.Value = value; }
        }

        public Boolean is_invoice
        {
            get { return (Boolean)is_invoiceVar.Value; }
            set { is_invoiceVar.Value = value; }
        }

        public String credit_approve_agent
        {
            get { return (String)credit_approve_agentVar.Value; }
            set { credit_approve_agentVar.Value = value; }
        }

        public Boolean credit_card_charged
        {
            get { return (Boolean)credit_card_chargedVar.Value; }
            set { credit_card_chargedVar.Value = value; }
        }

        public Boolean packingslip_complete
        {
            get { return (Boolean)packingslip_completeVar.Value; }
            set { packingslip_completeVar.Value = value; }
        }

        public Boolean is_reppaid
        {
            get { return (Boolean)is_reppaidVar.Value; }
            set { is_reppaidVar.Value = value; }
        }

        public String static_reportnote
        {
            get { return (String)static_reportnoteVar.Value; }
            set { static_reportnoteVar.Value = value; }
        }

        public Boolean is_buyerpaid
        {
            get { return (Boolean)is_buyerpaidVar.Value; }
            set { is_buyerpaidVar.Value = value; }
        }

        public String ord_contents
        {
            get { return (String)ord_contentsVar.Value; }
            set { ord_contentsVar.Value = value; }
        }

        public String harmonized_code
        {
            get { return (String)harmonized_codeVar.Value; }
            set { harmonized_codeVar.Value = value; }
        }

        public Int64 total_packages
        {
            get { return (Int64)total_packagesVar.Value; }
            set { total_packagesVar.Value = value; }
        }

        public Double total_weight
        {
            get { return (Double)total_weightVar.Value; }
            set { total_weightVar.Value = value; }
        }

        public String strippedphone
        {
            get { return (String)strippedphoneVar.Value; }
            set { strippedphoneVar.Value = value; }
        }

        public String abs_type
        {
            get { return (String)abs_typeVar.Value; }
            set { abs_typeVar.Value = value; }
        }

        public DateTime followup_date
        {
            get { return (DateTime)followup_dateVar.Value; }
            set { followup_dateVar.Value = value; }
        }

        public String warranty_period
        {
            get { return (String)warranty_periodVar.Value; }
            set { warranty_periodVar.Value = value; }
        }

        public DateTime date_paid
        {
            get { return (DateTime)date_paidVar.Value; }
            set { date_paidVar.Value = value; }
        }

        public String warehouse_id
        {
            get { return (String)warehouse_idVar.Value; }
            set { warehouse_idVar.Value = value; }
        }

        public String extra_info
        {
            get { return (String)extra_infoVar.Value; }
            set { extra_infoVar.Value = value; }
        }

        public String vendor_invoice_number
        {
            get { return (String)vendor_invoice_numberVar.Value; }
            set { vendor_invoice_numberVar.Value = value; }
        }

        public String action_taken
        {
            get { return (String)action_takenVar.Value; }
            set { action_takenVar.Value = value; }
        }

        public Boolean certs_required
        {
            get { return (Boolean)certs_requiredVar.Value; }
            set { certs_requiredVar.Value = value; }
        }

        public String lead_source
        {
            get { return (String)lead_sourceVar.Value; }
            set { lead_sourceVar.Value = value; }
        }

        public String email_domain
        {
            get { return (String)email_domainVar.Value; }
            set { email_domainVar.Value = value; }
        }

        public String email_suffix
        {
            get { return (String)email_suffixVar.Value; }
            set { email_suffixVar.Value = value; }
        }

        public String shippingamount_print
        {
            get { return (String)shippingamount_printVar.Value; }
            set { shippingamount_printVar.Value = value; }
        }

        public String handlingamount_print
        {
            get { return (String)handlingamount_printVar.Value; }
            set { handlingamount_printVar.Value = value; }
        }

        public String taxamount_print
        {
            get { return (String)taxamount_printVar.Value; }
            set { taxamount_printVar.Value = value; }
        }

        public String ordertotal_print
        {
            get { return (String)ordertotal_printVar.Value; }
            set { ordertotal_printVar.Value = value; }
        }
        public Double creditamount
        {
            get { return (Double)creditamountVar.Value; }
            set { creditamountVar.Value = value; }
        }
        public Int64 hubspot_deal_id
        {
            get { return (Int64)hubspot_deal_idVar.Value; }
            set { hubspot_deal_idVar.Value = value; }
        }

        public string qb_order_TxnID
        {
            get { return (string)qb_order_TxnIDVar.Value; }
            set { qb_order_TxnIDVar.Value = value; }
        }

        public string opportunity_stage
        {
            get { return (string)opportunity_stageVar.Value; }
            set { opportunity_stageVar.Value = value; }
        }

        public string opportunity_lost_reason
        {
            get { return (string)opportunity_lost_reasonVar.Value; }
            set { opportunity_lost_reasonVar.Value = value; }
        }

        public string opportunity_type
        {
            get { return (string)opportunity_typeVar.Value; }
            set { opportunity_typeVar.Value = value; }
        }




    }
    public partial class ordhed
    {
        public static ordhed New(Context x)
        { return (ordhed)x.Item("ordhed"); }

        public static ordhed GetById(Context x, String uid)
        { return (ordhed)x.GetById("ordhed", uid); }

        public static ordhed QtO(Context x, String sql)
        { return (ordhed)x.QtO("ordhed", sql); }

    }
}
