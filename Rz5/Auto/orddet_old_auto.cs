using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("orddet_old", Abstract = true)]
    public partial class orddet_old_auto : Rz5.orddet
    {
        static orddet_old_auto()
        {
            Item.AttributesCache(typeof(orddet_old_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "userid":
                    useridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isselected":
                    isselectedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorname":
                    vendornameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate":
                    orderdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "leadtime":
                    leadtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "minimumquantity":
                    minimumquantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "totalvalue":
                    totalvalueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dockdate":
                    dockdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorcontactid":
                    vendorcontactidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorcontactname":
                    vendorcontactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "nopo":
                    nopoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "referencenumber":
                    referencenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendorid":
                    vendoridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mfg_certifications":
                    mfg_certificationsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_note":
                    line_noteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_cofc":
                    has_cofcAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_accepted":
                    is_acceptedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extendedfilled":
                    extendedfilledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extendedfilledcurr":
                    extendedfilledcurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extendedorder":
                    extendedorderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extendedordercurr":
                    extendedordercurrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quicknote":
                    quicknoteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warranty_period":
                    warranty_periodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_removedfromque":
                    is_removedfromqueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber":
                    ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertype":
                    ordertypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_dealdetail_uid":
                    base_dealdetail_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_dealheader_uid":
                    base_dealheader_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_ordhed_uid":
                    base_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "status_notes":
                    status_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "target_price":
                    target_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rohs":
                    rohsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "totalprice":
                    totalpriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unitcost":
                    unitcostAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_cost":
                    total_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unitprice":
                    unitpriceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "location":
                    locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "boxnum":
                    boxnumAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_company_uid":
                    vendor_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitystocked":
                    quantitystockedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitycancelled":
                    quantitycancelledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printedas":
                    printedasAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantityfilled":
                    quantityfilledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "original_vendor_name":
                    original_vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitybacked":
                    quantitybackedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stockvalue":
                    stockvalueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lineprofit":
                    lineprofitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyerid":
                    buyeridAttribute = (CoreVarValAttribute)attr;
                    break;
                case "requireddate":
                    requireddateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isinstock":
                    isinstockAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantityordered":
                    quantityorderedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stockid":
                    stockidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "delivery":
                    deliveryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "target_quantity":
                    target_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode":
                    linecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantitypurchased":
                    quantitypurchasedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_number_stripped":
                    part_number_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "type_caption":
                    type_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "currency_name":
                    currency_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unitprice_exchanged":
                    unitprice_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "totalprice_exchanged":
                    totalprice_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exchange_rate":
                    exchange_rateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unitprice_print":
                    unitprice_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "totalprice_print":
                    totalprice_printAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute useridAttribute;
        static CoreVarValAttribute isselectedAttribute;
        static CoreVarValAttribute vendornameAttribute;
        static CoreVarValAttribute orderdateAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute leadtimeAttribute;
        static CoreVarValAttribute minimumquantityAttribute;
        static CoreVarValAttribute totalvalueAttribute;
        static CoreVarValAttribute dockdateAttribute;
        static CoreVarValAttribute vendorcontactidAttribute;
        static CoreVarValAttribute vendorcontactnameAttribute;
        static CoreVarValAttribute nopoAttribute;
        static CoreVarValAttribute referencenumberAttribute;
        static CoreVarValAttribute vendoridAttribute;
        static CoreVarValAttribute mfg_certificationsAttribute;
        static CoreVarValAttribute line_noteAttribute;
        static CoreVarValAttribute has_cofcAttribute;
        static CoreVarValAttribute is_acceptedAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute extendedfilledAttribute;
        static CoreVarValAttribute extendedfilledcurrAttribute;
        static CoreVarValAttribute extendedorderAttribute;
        static CoreVarValAttribute extendedordercurrAttribute;
        static CoreVarValAttribute quicknoteAttribute;
        static CoreVarValAttribute warranty_periodAttribute;
        static CoreVarValAttribute is_removedfromqueAttribute;
        static CoreVarValAttribute ordernumberAttribute;
        static CoreVarValAttribute ordertypeAttribute;
        static CoreVarValAttribute base_dealdetail_uidAttribute;
        static CoreVarValAttribute base_dealheader_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_ordhed_uidAttribute;
        static CoreVarValAttribute status_notesAttribute;
        static CoreVarValAttribute target_priceAttribute;
        static CoreVarValAttribute rohsAttribute;
        static CoreVarValAttribute totalpriceAttribute;
        static CoreVarValAttribute unitcostAttribute;
        static CoreVarValAttribute unitpriceAttribute;
        static CoreVarValAttribute locationAttribute;
        static CoreVarValAttribute boxnumAttribute;
        static CoreVarValAttribute vendor_company_uidAttribute;
        static CoreVarValAttribute quantitystockedAttribute;
        static CoreVarValAttribute quantitycancelledAttribute;
        static CoreVarValAttribute printedasAttribute;
        static CoreVarValAttribute quantityfilledAttribute;
        static CoreVarValAttribute original_vendor_nameAttribute;
        static CoreVarValAttribute quantitybackedAttribute;
        static CoreVarValAttribute stockvalueAttribute;
        static CoreVarValAttribute lineprofitAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute buyeridAttribute;
        static CoreVarValAttribute requireddateAttribute;
        static CoreVarValAttribute isinstockAttribute;
        static CoreVarValAttribute quantityorderedAttribute;
        static CoreVarValAttribute stockidAttribute;
        static CoreVarValAttribute deliveryAttribute;
        static CoreVarValAttribute target_quantityAttribute;
        static CoreVarValAttribute linecodeAttribute;
        static CoreVarValAttribute quantitypurchasedAttribute;
        static CoreVarValAttribute part_number_strippedAttribute;
        static CoreVarValAttribute type_captionAttribute;
        static CoreVarValAttribute currency_nameAttribute;
        static CoreVarValAttribute unitprice_exchangedAttribute;
        static CoreVarValAttribute totalprice_exchangedAttribute;
        static CoreVarValAttribute exchange_rateAttribute;
        static CoreVarValAttribute unitprice_printAttribute;
        static CoreVarValAttribute totalprice_printAttribute;
        static CoreVarValAttribute total_costAttribute;
        

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 255, Caption="Base Company Uid", Importance = 40)]
        public VarString base_company_uidVar;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 255, Caption="Base Companycontact Uid", Importance = 41)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("userid", "String", TheFieldLength = 50, Caption="User Id", Importance = 46)]
        public VarString useridVar;

        [CoreVarVal("isselected", "Boolean", Caption="Is Selected", Importance = 54)]
        public VarBoolean isselectedVar;

        [CoreVarVal("vendorname", "String", TheFieldLength = 255, Caption="Vendor Name", Importance = 56)]
        public VarString vendornameVar;

        [CoreVarVal("orderdate", "DateTime", Caption="Order Date", Importance = 58)]
        public VarDateTime orderdateVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 60)]
        public VarString companynameVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption="Agent Name", Importance = 61)]
        public VarString agentnameVar;

        [CoreVarVal("leadtime", "String", TheFieldLength = 50, Caption="Lead Time", Importance = 69)]
        public VarString leadtimeVar;

        [CoreVarVal("minimumquantity", "Int64", Caption="Min. Quantity", Importance = 70)]
        public VarInt64 minimumquantityVar;

        [CoreVarVal("totalvalue", "Double", Caption="Total Value", Importance = 80)]
        public VarDouble totalvalueVar;

        [CoreVarVal("dockdate", "DateTime", Caption="Dock Date", Importance = 82)]
        public VarDateTime dockdateVar;

        [CoreVarVal("vendorcontactid", "String", TheFieldLength = 50, Caption="Vendor Contact", Importance = 85)]
        public VarString vendorcontactidVar;

        [CoreVarVal("vendorcontactname", "String", TheFieldLength = 50, Caption="Vendor Contact Name", Importance = 86)]
        public VarString vendorcontactnameVar;

        [CoreVarVal("nopo", "Boolean", Caption="No Po", Importance = 93)]
        public VarBoolean nopoVar;

        [CoreVarVal("referencenumber", "String", TheFieldLength = 50, Caption="Reference Number", Importance = 94)]
        public VarString referencenumberVar;

        [CoreVarVal("vendorid", "String", TheFieldLength = 50, Caption="Vendor Id", Importance = 101)]
        public VarString vendoridVar;

        [CoreVarVal("mfg_certifications", "Boolean", Caption="Mfg Certifications", Importance = 109)]
        public VarBoolean mfg_certificationsVar;

        [CoreVarVal("line_note", "String", TheFieldLength = 255, Caption="Line Note", Importance = 115)]
        public VarString line_noteVar;

        [CoreVarVal("has_cofc", "Boolean", Caption="Has C Of C", Importance = 116)]
        public VarBoolean has_cofcVar;

        [CoreVarVal("is_accepted", "Boolean", Caption="Is Accepted", Importance = 117)]
        public VarBoolean is_acceptedVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Contactname", Importance = 118)]
        public VarString contactnameVar;

        [CoreVarVal("extendedfilled", "Double", Caption="Extended (filled)", Importance = 119)]
        public VarDouble extendedfilledVar;

        [CoreVarVal("extendedfilledcurr", "String", TheFieldLength = 4, Caption="Extended (filled) Currency", Importance = 120)]
        public VarString extendedfilledcurrVar;

        [CoreVarVal("extendedorder", "Double", Caption="Extended (order)", Importance = 121)]
        public VarDouble extendedorderVar;

        [CoreVarVal("extendedordercurr", "String", TheFieldLength = 4, Caption="Extended (order) Currency", Importance = 122)]
        public VarString extendedordercurrVar;

        [CoreVarVal("quicknote", "String", TheFieldLength = 8000, Caption="Quick Note", Importance = 123)]
        public VarString quicknoteVar;

        [CoreVarVal("warranty_period", "String", TheFieldLength = 255, Caption="Warranty Period", Importance = 124)]
        public VarString warranty_periodVar;

        [CoreVarVal("is_removedfromque", "Boolean", Caption="Is Removed From Queue", Importance = 125)]
        public VarBoolean is_removedfromqueVar;

        [CoreVarVal("ordernumber", "String", TheFieldLength = 50, Caption="Order Number", Importance = 127)]
        public VarString ordernumberVar;

        [CoreVarVal("ordertype", "String", TheFieldLength = 50, Caption="Order Type", Importance = 128)]
        public VarString ordertypeVar;

        [CoreVarVal("base_dealdetail_uid", "String", TheFieldLength = 50, Caption="Base Dealdetail Id", Importance = 129)]
        public VarString base_dealdetail_uidVar;

        [CoreVarVal("base_dealheader_uid", "String", TheFieldLength = 50, Caption="Base Dealheader Id", Importance = 130)]
        public VarString base_dealheader_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 131)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_ordhed_uid", "String", TheFieldLength = 50, Caption="Base Ordhed Id", Importance = 132)]
        public VarString base_ordhed_uidVar;

        [CoreVarVal("status_notes", "String", TheFieldLength = 8000, Caption="Status Notes", Importance = 133)]
        public VarString status_notesVar;

        [CoreVarVal("target_price", "Double", Caption="Target Price", Importance = 134)]
        public VarDouble target_priceVar;

        [CoreVarVal("rohs", "Boolean", Caption="Rohs", Importance = 137)]
        public VarBoolean rohsVar;

        [CoreVarVal("totalprice", "Double", Caption="Total Price", Importance = 141)]
        public VarDouble totalpriceVar;

        [CoreVarVal("unitcost", "Double", Caption="Cost", Importance = 142)]
        public VarDouble unitcostVar;

        [CoreVarVal("unitprice", "Double", Caption="Unit Price", Importance = 143)]
        public VarDouble unitpriceVar;

        [CoreVarVal("location", "String", TheFieldLength = 255, Caption="Location", Importance = 144)]
        public VarString locationVar;

        [CoreVarVal("boxnum", "String", TheFieldLength = 255, Caption="Boxnum", Importance = 145)]
        public VarString boxnumVar;

        [CoreVarVal("vendor_company_uid", "String", TheFieldLength = 255, Caption="Vendor Company Uid", Importance = 146)]
        public VarString vendor_company_uidVar;

        [CoreVarVal("quantitystocked", "Int64", Caption="Quantitystocked", Importance = 147)]
        public VarInt64 quantitystockedVar;

        [CoreVarVal("quantitycancelled", "Int64", Caption="Quantitycancelled", Importance = 148)]
        public VarInt64 quantitycancelledVar;

        [CoreVarVal("printedas", "String", TheFieldLength = 8000, Caption="Printedas", Importance = 149)]
        public VarString printedasVar;

        [CoreVarVal("quantityfilled", "Int64", Caption="Quantityfilled", Importance = 150)]
        public VarInt64 quantityfilledVar;

        [CoreVarVal("original_vendor_name", "String", TheFieldLength = 255, Caption="Original Vendor Name", Importance = 151)]
        public VarString original_vendor_nameVar;

        [CoreVarVal("quantitybacked", "Int64", Caption="Quantitybacked", Importance = 152)]
        public VarInt64 quantitybackedVar;

        [CoreVarVal("stockvalue", "Double", Caption="Stockvalue", Importance = 153)]
        public VarDouble stockvalueVar;

        [CoreVarVal("lineprofit", "Double", Caption="Lineprofit", Importance = 154)]
        public VarDouble lineprofitVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption="Abs Type", Importance = 155)]
        public VarString abs_typeVar;

        [CoreVarVal("buyerid", "String", TheFieldLength = 255, Caption="Buyerid", Importance = 156)]
        public VarString buyeridVar;

        [CoreVarVal("requireddate", "DateTime", Caption="Requireddate", Importance = 157)]
        public VarDateTime requireddateVar;

        [CoreVarVal("isinstock", "Boolean", Caption="Isinstock", Importance = 158)]
        public VarBoolean isinstockVar;

        [CoreVarVal("quantityordered", "Int64", Caption="Quantityordered", Importance = 159)]
        public VarInt64 quantityorderedVar;

        [CoreVarVal("stockid", "String", TheFieldLength = 255, Caption="Stockid", Importance = 160)]
        public VarString stockidVar;

        [CoreVarVal("delivery", "String", TheFieldLength = 255, Caption="Delivery", Importance = 161)]
        public VarString deliveryVar;

        [CoreVarVal("target_quantity", "Int64", Caption="Target Quantity", Importance = 162)]
        public VarInt64 target_quantityVar;

        [CoreVarVal("linecode", "Int64", Caption="Linecode", Importance = 163)]
        public VarInt64 linecodeVar;

        [CoreVarVal("quantitypurchased", "Int64", Caption="Quantitypurchased", Importance = 164)]
        public VarInt64 quantitypurchasedVar;

        [CoreVarVal("part_number_stripped", "String", TheFieldLength = 255, Caption="Part Number Stripped", Importance = 165)]
        public VarString part_number_strippedVar;

        [CoreVarVal("type_caption", "String", TheFieldLength = 255, Caption="Type", Importance = 166)]
        public VarString type_captionVar;

        [CoreVarVal("currency_name", "String", Caption="Currency", Importance = 67)]
        public VarString currency_nameVar;

        [CoreVarVal("unitprice_exchanged", "Double", Caption="Exchanged Price", Importance = 65)]
        public VarDouble unitprice_exchangedVar;

        [CoreVarVal("totalprice_exchanged", "Double", Caption="Total Exchanged Price", Importance = 67)]
        public VarDouble totalprice_exchangedVar;

        [CoreVarVal("exchange_rate", "Double", Caption="Exchange Rate", Importance = 67)]
        public VarDouble exchange_rateVar;

        [CoreVarVal("unitprice_print", "String", Caption="Price Print", Importance = 68)]
        public VarString unitprice_printVar;

        [CoreVarVal("totalprice_print", "String", Caption="Total Print", Importance = 69)]
        public VarString totalprice_printVar;

        [CoreVarVal("total_cost", "Double", Caption = "total_cost", Importance = 70)]
        public VarDouble total_costVar;
        
        public orddet_old_auto()
        {
            StaticInit();
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            useridVar = new VarString(this, useridAttribute);
            isselectedVar = new VarBoolean(this, isselectedAttribute);
            vendornameVar = new VarString(this, vendornameAttribute);
            orderdateVar = new VarDateTime(this, orderdateAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            leadtimeVar = new VarString(this, leadtimeAttribute);
            minimumquantityVar = new VarInt64(this, minimumquantityAttribute);
            totalvalueVar = new VarDouble(this, totalvalueAttribute);
            dockdateVar = new VarDateTime(this, dockdateAttribute);
            vendorcontactidVar = new VarString(this, vendorcontactidAttribute);
            vendorcontactnameVar = new VarString(this, vendorcontactnameAttribute);
            nopoVar = new VarBoolean(this, nopoAttribute);
            referencenumberVar = new VarString(this, referencenumberAttribute);
            vendoridVar = new VarString(this, vendoridAttribute);
            mfg_certificationsVar = new VarBoolean(this, mfg_certificationsAttribute);
            line_noteVar = new VarString(this, line_noteAttribute);
            has_cofcVar = new VarBoolean(this, has_cofcAttribute);
            is_acceptedVar = new VarBoolean(this, is_acceptedAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            extendedfilledVar = new VarDouble(this, extendedfilledAttribute);
            extendedfilledcurrVar = new VarString(this, extendedfilledcurrAttribute);
            extendedorderVar = new VarDouble(this, extendedorderAttribute);
            extendedordercurrVar = new VarString(this, extendedordercurrAttribute);
            quicknoteVar = new VarString(this, quicknoteAttribute);
            warranty_periodVar = new VarString(this, warranty_periodAttribute);
            is_removedfromqueVar = new VarBoolean(this, is_removedfromqueAttribute);
            ordernumberVar = new VarString(this, ordernumberAttribute);
            ordertypeVar = new VarString(this, ordertypeAttribute);
            base_dealdetail_uidVar = new VarString(this, base_dealdetail_uidAttribute);
            base_dealheader_uidVar = new VarString(this, base_dealheader_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_ordhed_uidVar = new VarString(this, base_ordhed_uidAttribute);
            status_notesVar = new VarString(this, status_notesAttribute);
            target_priceVar = new VarDouble(this, target_priceAttribute);
            rohsVar = new VarBoolean(this, rohsAttribute);
            totalpriceVar = new VarDouble(this, totalpriceAttribute);
            unitcostVar = new VarDouble(this, unitcostAttribute);
            unitpriceVar = new VarDouble(this, unitpriceAttribute);
            locationVar = new VarString(this, locationAttribute);
            boxnumVar = new VarString(this, boxnumAttribute);
            vendor_company_uidVar = new VarString(this, vendor_company_uidAttribute);
            quantitystockedVar = new VarInt64(this, quantitystockedAttribute);
            quantitycancelledVar = new VarInt64(this, quantitycancelledAttribute);
            printedasVar = new VarString(this, printedasAttribute);
            quantityfilledVar = new VarInt64(this, quantityfilledAttribute);
            original_vendor_nameVar = new VarString(this, original_vendor_nameAttribute);
            quantitybackedVar = new VarInt64(this, quantitybackedAttribute);
            stockvalueVar = new VarDouble(this, stockvalueAttribute);
            lineprofitVar = new VarDouble(this, lineprofitAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            buyeridVar = new VarString(this, buyeridAttribute);
            requireddateVar = new VarDateTime(this, requireddateAttribute);
            isinstockVar = new VarBoolean(this, isinstockAttribute);
            quantityorderedVar = new VarInt64(this, quantityorderedAttribute);
            stockidVar = new VarString(this, stockidAttribute);
            deliveryVar = new VarString(this, deliveryAttribute);
            target_quantityVar = new VarInt64(this, target_quantityAttribute);
            linecodeVar = new VarInt64(this, linecodeAttribute);
            quantitypurchasedVar = new VarInt64(this, quantitypurchasedAttribute);
            part_number_strippedVar = new VarString(this, part_number_strippedAttribute);
            type_captionVar = new VarString(this, type_captionAttribute);
            currency_nameVar = new VarString(this, currency_nameAttribute);
            unitprice_exchangedVar = new VarDouble(this, unitprice_exchangedAttribute);
            totalprice_exchangedVar = new VarDouble(this, totalprice_exchangedAttribute);
            exchange_rateVar = new VarDouble(this, exchange_rateAttribute);
            unitprice_printVar = new VarString(this, unitprice_printAttribute);
            totalprice_printVar = new VarString(this, totalprice_printAttribute);
            total_costVar = new VarDouble(this, total_costAttribute);
            
        }

        public override string ClassId
        { get { return "orddet_old"; } }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String base_companycontact_uid
        {
            get  { return (String)base_companycontact_uidVar.Value; }
            set  { base_companycontact_uidVar.Value = value; }
        }

        public String userid
        {
            get  { return (String)useridVar.Value; }
            set  { useridVar.Value = value; }
        }

        public Boolean isselected
        {
            get  { return (Boolean)isselectedVar.Value; }
            set  { isselectedVar.Value = value; }
        }

        public String vendorname
        {
            get  { return (String)vendornameVar.Value; }
            set  { vendornameVar.Value = value; }
        }

        public DateTime orderdate
        {
            get  { return (DateTime)orderdateVar.Value; }
            set  { orderdateVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public String leadtime
        {
            get  { return (String)leadtimeVar.Value; }
            set  { leadtimeVar.Value = value; }
        }

        public Int64 minimumquantity
        {
            get  { return (Int64)minimumquantityVar.Value; }
            set  { minimumquantityVar.Value = value; }
        }

        public Double totalvalue
        {
            get  { return (Double)totalvalueVar.Value; }
            set  { totalvalueVar.Value = value; }
        }

        public DateTime dockdate
        {
            get  { return (DateTime)dockdateVar.Value; }
            set  { dockdateVar.Value = value; }
        }

        public String vendorcontactid
        {
            get  { return (String)vendorcontactidVar.Value; }
            set  { vendorcontactidVar.Value = value; }
        }

        public String vendorcontactname
        {
            get  { return (String)vendorcontactnameVar.Value; }
            set  { vendorcontactnameVar.Value = value; }
        }

        public Boolean nopo
        {
            get  { return (Boolean)nopoVar.Value; }
            set  { nopoVar.Value = value; }
        }

        public String referencenumber
        {
            get  { return (String)referencenumberVar.Value; }
            set  { referencenumberVar.Value = value; }
        }

        public String vendorid
        {
            get  { return (String)vendoridVar.Value; }
            set  { vendoridVar.Value = value; }
        }

        public Boolean mfg_certifications
        {
            get  { return (Boolean)mfg_certificationsVar.Value; }
            set  { mfg_certificationsVar.Value = value; }
        }

        public String line_note
        {
            get  { return (String)line_noteVar.Value; }
            set  { line_noteVar.Value = value; }
        }

        public Boolean has_cofc
        {
            get  { return (Boolean)has_cofcVar.Value; }
            set  { has_cofcVar.Value = value; }
        }

        public Boolean is_accepted
        {
            get  { return (Boolean)is_acceptedVar.Value; }
            set  { is_acceptedVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public Double extendedfilled
        {
            get  { return (Double)extendedfilledVar.Value; }
            set  { extendedfilledVar.Value = value; }
        }

        public String extendedfilledcurr
        {
            get  { return (String)extendedfilledcurrVar.Value; }
            set  { extendedfilledcurrVar.Value = value; }
        }

        public Double extendedorder
        {
            get  { return (Double)extendedorderVar.Value; }
            set  { extendedorderVar.Value = value; }
        }

        public String extendedordercurr
        {
            get  { return (String)extendedordercurrVar.Value; }
            set  { extendedordercurrVar.Value = value; }
        }

        public String quicknote
        {
            get  { return (String)quicknoteVar.Value; }
            set  { quicknoteVar.Value = value; }
        }

        public String warranty_period
        {
            get  { return (String)warranty_periodVar.Value; }
            set  { warranty_periodVar.Value = value; }
        }

        public Boolean is_removedfromque
        {
            get  { return (Boolean)is_removedfromqueVar.Value; }
            set  { is_removedfromqueVar.Value = value; }
        }

        public String ordernumber
        {
            get  { return (String)ordernumberVar.Value; }
            set  { ordernumberVar.Value = value; }
        }

        public String ordertype
        {
            get  { return (String)ordertypeVar.Value; }
            set  { ordertypeVar.Value = value; }
        }

        public String base_dealdetail_uid
        {
            get  { return (String)base_dealdetail_uidVar.Value; }
            set  { base_dealdetail_uidVar.Value = value; }
        }

        public String base_dealheader_uid
        {
            get  { return (String)base_dealheader_uidVar.Value; }
            set  { base_dealheader_uidVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String base_ordhed_uid
        {
            get  { return (String)base_ordhed_uidVar.Value; }
            set  { base_ordhed_uidVar.Value = value; }
        }

        public String status_notes
        {
            get  { return (String)status_notesVar.Value; }
            set  { status_notesVar.Value = value; }
        }

        public Double target_price
        {
            get  { return (Double)target_priceVar.Value; }
            set  { target_priceVar.Value = value; }
        }

        public Boolean rohs
        {
            get  { return (Boolean)rohsVar.Value; }
            set  { rohsVar.Value = value; }
        }

        public Double totalprice
        {
            get  { return (Double)totalpriceVar.Value; }
            set  { totalpriceVar.Value = value; }
        }

        public Double unitcost
        {
            get  { return (Double)unitcostVar.Value; }
            set  { unitcostVar.Value = value; }
        }

        public Double unitprice
        {
            get  { return (Double)unitpriceVar.Value; }
            set  { unitpriceVar.Value = value; }
        }

        public String location
        {
            get  { return (String)locationVar.Value; }
            set  { locationVar.Value = value; }
        }

        public String boxnum
        {
            get  { return (String)boxnumVar.Value; }
            set  { boxnumVar.Value = value; }
        }

        public String vendor_company_uid
        {
            get  { return (String)vendor_company_uidVar.Value; }
            set  { vendor_company_uidVar.Value = value; }
        }

        public Int64 quantitystocked
        {
            get  { return (Int64)quantitystockedVar.Value; }
            set  { quantitystockedVar.Value = value; }
        }

        public Int64 quantitycancelled
        {
            get  { return (Int64)quantitycancelledVar.Value; }
            set  { quantitycancelledVar.Value = value; }
        }

        public String printedas
        {
            get  { return (String)printedasVar.Value; }
            set  { printedasVar.Value = value; }
        }

        public Int64 quantityfilled
        {
            get  { return (Int64)quantityfilledVar.Value; }
            set  { quantityfilledVar.Value = value; }
        }

        public String original_vendor_name
        {
            get  { return (String)original_vendor_nameVar.Value; }
            set  { original_vendor_nameVar.Value = value; }
        }

        public Int64 quantitybacked
        {
            get  { return (Int64)quantitybackedVar.Value; }
            set  { quantitybackedVar.Value = value; }
        }

        public Double stockvalue
        {
            get  { return (Double)stockvalueVar.Value; }
            set  { stockvalueVar.Value = value; }
        }

        public Double lineprofit
        {
            get  { return (Double)lineprofitVar.Value; }
            set  { lineprofitVar.Value = value; }
        }

        public String abs_type
        {
            get  { return (String)abs_typeVar.Value; }
            set  { abs_typeVar.Value = value; }
        }

        public String buyerid
        {
            get  { return (String)buyeridVar.Value; }
            set  { buyeridVar.Value = value; }
        }

        public DateTime requireddate
        {
            get  { return (DateTime)requireddateVar.Value; }
            set  { requireddateVar.Value = value; }
        }

        public Boolean isinstock
        {
            get  { return (Boolean)isinstockVar.Value; }
            set  { isinstockVar.Value = value; }
        }

        public Int64 quantityordered
        {
            get  { return (Int64)quantityorderedVar.Value; }
            set  { quantityorderedVar.Value = value; }
        }

        public String stockid
        {
            get  { return (String)stockidVar.Value; }
            set  { stockidVar.Value = value; }
        }

        public String delivery
        {
            get  { return (String)deliveryVar.Value; }
            set  { deliveryVar.Value = value; }
        }

        public Int64 target_quantity
        {
            get  { return (Int64)target_quantityVar.Value; }
            set  { target_quantityVar.Value = value; }
        }

        public Int64 linecode
        {
            get  { return (Int64)linecodeVar.Value; }
            set  { linecodeVar.Value = value; }
        }

        public Int64 quantitypurchased
        {
            get  { return (Int64)quantitypurchasedVar.Value; }
            set  { quantitypurchasedVar.Value = value; }
        }

        public String part_number_stripped
        {
            get  { return (String)part_number_strippedVar.Value; }
            set  { part_number_strippedVar.Value = value; }
        }

        public String type_caption
        {
            get  { return (String)type_captionVar.Value; }
            set  { type_captionVar.Value = value; }
        }

        public String currency_name
        {
            get  { return (String)currency_nameVar.Value; }
            set  { currency_nameVar.Value = value; }
        }

        public Double unitprice_exchanged
        {
            get  { return (Double)unitprice_exchangedVar.Value; }
            set  { unitprice_exchangedVar.Value = value; }
        }

        public Double totalprice_exchanged
        {
            get  { return (Double)totalprice_exchangedVar.Value; }
            set  { totalprice_exchangedVar.Value = value; }
        }

        public Double exchange_rate
        {
            get  { return (Double)exchange_rateVar.Value; }
            set  { exchange_rateVar.Value = value; }
        }

        public String unitprice_print
        {
            get  { return (String)unitprice_printVar.Value; }
            set  { unitprice_printVar.Value = value; }
        }

        public String totalprice_print
        {
            get  { return (String)totalprice_printVar.Value; }
            set  { totalprice_printVar.Value = value; }
        }

        public Double total_cost
        {
            get { return (Double)total_costVar.Value; }
            set { total_costVar.Value = value; }
        }
        

    }
    public partial class orddet_old
    {
        public static orddet_old New(Context x)
        {  return (orddet_old)x.Item("orddet_old"); }

        public static orddet_old GetById(Context x, String uid)
        { return (orddet_old)x.GetById("orddet_old", uid); }

        public static orddet_old QtO(Context x, String sql)
        { return (orddet_old)x.QtO("orddet_old", sql); }
    }
}
