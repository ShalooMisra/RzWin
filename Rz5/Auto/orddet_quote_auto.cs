using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("orddet_quote")]
    public partial class orddet_quote_auto : Rz5.orddet_old
    {
        static orddet_quote_auto()
        {
            Item.AttributesCache(typeof(orddet_quote_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "option_orddet_quote_uid":
                    option_orddet_quote_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_rfq_uid":
                    the_orddet_rfq_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "req_date":
                    req_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_sales_id":
                    last_sales_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_sales_number":
                    last_sales_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "target_manufacturer":
                    target_manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "target_datecode":
                    target_datecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "target_condition":
                    target_conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "target_delivery":
                    target_deliveryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_transmit_date":
                    last_transmit_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_priority":
                    is_priorityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_nostock":
                    is_nostockAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_note":
                    last_noteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_dead":
                    is_deadAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dead_notes":
                    dead_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "source":
                    sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_quote_total":
                    last_quote_totalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_quote_date":
                    last_quote_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stock_matches":
                    stock_matchesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "consign_matches":
                    consign_matchesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "excess_matches":
                    excess_matchesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sale_matches":
                    sale_matchesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sale_average":
                    sale_averageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sale_min":
                    sale_minAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sale_max":
                    sale_maxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sale_earliest":
                    sale_earliestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sale_latest":
                    sale_latestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_matches":
                    purchase_matchesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_average":
                    purchase_averageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_min":
                    purchase_minAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_max":
                    purchase_maxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_earliest":
                    purchase_earliestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_latest":
                    purchase_latestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_matches":
                    quote_matchesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_average":
                    quote_averageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_min":
                    quote_minAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_max":
                    quote_maxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_earliest":
                    quote_earliestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_latest":
                    quote_latestAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_strategic":
                    is_strategicAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_dock_date_initial":
                    customer_dock_date_initialAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importid":
                    importidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_email_alert_sent":
                    was_email_alert_sentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent":
                    list_acquisition_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent_uid":
                    list_acquisition_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_type":
                    split_commission_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_name":
                    split_commission_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_uid":
                    split_commission_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_ID":
                    split_commission_IDAttribute = (CoreVarValAttribute)attr;
                    break;
                    
                case "is_bom":
                    is_bomAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalpart_vendor_uid":
                    internalpart_vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;

                case "internalpart_vendor":
                    internalpart_vendorAttribute = (CoreVarValAttribute)attr;
                    break;

                case "affiliate_id":
                    affiliate_idAttribute = (CoreVarValAttribute)attr;
                    break;

                case "country_of_origin_vendor":
                    country_of_origin_vendorAttribute = (CoreVarValAttribute)attr;
                    break;



            }
        }

        static CoreVarValAttribute option_orddet_quote_uidAttribute;
        static CoreVarValAttribute the_orddet_rfq_uidAttribute;
        static CoreVarValAttribute req_dateAttribute;
        static CoreVarValAttribute last_sales_idAttribute;
        static CoreVarValAttribute last_sales_numberAttribute;
        static CoreVarValAttribute target_manufacturerAttribute;
        static CoreVarValAttribute target_datecodeAttribute;
        static CoreVarValAttribute target_conditionAttribute;
        static CoreVarValAttribute target_deliveryAttribute;
        static CoreVarValAttribute last_transmit_dateAttribute;
        static CoreVarValAttribute is_priorityAttribute;
        static CoreVarValAttribute is_nostockAttribute;
        static CoreVarValAttribute last_noteAttribute;
        static CoreVarValAttribute is_deadAttribute;
        static CoreVarValAttribute dead_notesAttribute;
        static CoreVarValAttribute sourceAttribute;
        static CoreVarValAttribute last_quote_totalAttribute;
        static CoreVarValAttribute last_quote_dateAttribute;
        static CoreVarValAttribute stock_matchesAttribute;
        static CoreVarValAttribute consign_matchesAttribute;
        static CoreVarValAttribute excess_matchesAttribute;
        static CoreVarValAttribute sale_matchesAttribute;
        static CoreVarValAttribute sale_averageAttribute;
        static CoreVarValAttribute sale_minAttribute;
        static CoreVarValAttribute sale_maxAttribute;
        static CoreVarValAttribute sale_earliestAttribute;
        static CoreVarValAttribute sale_latestAttribute;
        static CoreVarValAttribute purchase_matchesAttribute;
        static CoreVarValAttribute purchase_averageAttribute;
        static CoreVarValAttribute purchase_minAttribute;
        static CoreVarValAttribute purchase_maxAttribute;
        static CoreVarValAttribute purchase_earliestAttribute;
        static CoreVarValAttribute purchase_latestAttribute;
        static CoreVarValAttribute quote_matchesAttribute;
        static CoreVarValAttribute quote_averageAttribute;
        static CoreVarValAttribute quote_minAttribute;
        static CoreVarValAttribute quote_maxAttribute;
        static CoreVarValAttribute quote_earliestAttribute;
        static CoreVarValAttribute quote_latestAttribute;
        static CoreVarValAttribute is_strategicAttribute;
        static CoreVarValAttribute customer_dock_date_initialAttribute;
        static CoreVarValAttribute importidAttribute;
        static CoreVarValAttribute was_email_alert_sentAttribute;
        static CoreVarValAttribute list_acquisition_agentAttribute;
        static CoreVarValAttribute list_acquisition_agent_uidAttribute;
        static CoreVarValAttribute split_commission_typeAttribute;
        static CoreVarValAttribute split_commission_agent_nameAttribute;
        static CoreVarValAttribute split_commission_agent_uidAttribute;
        static CoreVarValAttribute split_commission_IDAttribute;
        static CoreVarValAttribute is_bomAttribute;
        static CoreVarValAttribute internalpart_vendor_uidAttribute;
        static CoreVarValAttribute internalpart_vendorAttribute;
        static CoreVarValAttribute affiliate_idAttribute;
        static CoreVarValAttribute country_of_origin_vendorAttribute;
        



        [CoreVarVal("option_orddet_quote_uid", "String", TheFieldLength = 255, Caption = "Option Orddet Quote Uid", Importance = 1)]
        public VarString option_orddet_quote_uidVar;

        [CoreVarVal("the_orddet_rfq_uid", "String", TheFieldLength = 255, Caption = "The Orddet Rfq Uid", Importance = 2)]
        public VarString the_orddet_rfq_uidVar;

        [CoreVarVal("req_date", "DateTime", Caption = "Req Date", Importance = 3)]
        public VarDateTime req_dateVar;

        [CoreVarVal("last_sales_id", "String", TheFieldLength = 255, Caption = "Last Sales Id", Importance = 4)]
        public VarString last_sales_idVar;

        [CoreVarVal("last_sales_number", "String", TheFieldLength = 255, Caption = "Last Sales Number", Importance = 5)]
        public VarString last_sales_numberVar;

        [CoreVarVal("target_manufacturer", "String", TheFieldLength = 255, Caption = "Target Manufacturer", Importance = 6)]
        public VarString target_manufacturerVar;

        [CoreVarVal("target_datecode", "String", TheFieldLength = 255, Caption = "Target Datecode", Importance = 7)]
        public VarString target_datecodeVar;

        [CoreVarVal("target_condition", "String", TheFieldLength = 255, Caption = "Target Condition", Importance = 8)]
        public VarString target_conditionVar;

        [CoreVarVal("target_delivery", "String", TheFieldLength = 255, Caption = "Target Delivery", Importance = 9)]
        public VarString target_deliveryVar;

        [CoreVarVal("last_transmit_date", "DateTime", Caption = "Last Transmit Date", Importance = 10)]
        public VarDateTime last_transmit_dateVar;

        [CoreVarVal("is_priority", "Boolean", Caption = "Is Priority", Importance = 11)]
        public VarBoolean is_priorityVar;

        [CoreVarVal("is_nostock", "Boolean", Caption = "Is No Stock", Importance = 12)]
        public VarBoolean is_nostockVar;

        [CoreVarVal("last_note", "String", TheFieldLength = 8000, Caption = "Last Note", Importance = 13)]
        public VarString last_noteVar;

        [CoreVarVal("is_dead", "Boolean", Caption = "Is Dead", Importance = 14)]
        public VarBoolean is_deadVar;

        [CoreVarVal("dead_notes", "String", TheFieldLength = 255, Caption = "Dead Notes", Importance = 15)]
        public VarString dead_notesVar;

        [CoreVarVal("source", "String", TheFieldLength = 255, Caption = "Source", Importance = 16)]
        public VarString sourceVar;

        [CoreVarVal("last_quote_total", "Double", Caption = "Last Quote Total", Importance = 17)]
        public VarDouble last_quote_totalVar;

        [CoreVarVal("last_quote_date", "DateTime", Caption = "Last Quote Date", Importance = 18)]
        public VarDateTime last_quote_dateVar;

        [CoreVarVal("stock_matches", "Int32", Caption = "Stock Matches", Importance = 19)]
        public VarInt32 stock_matchesVar;

        [CoreVarVal("consign_matches", "Int32", Caption = "Consign Matches", Importance = 20)]
        public VarInt32 consign_matchesVar;

        [CoreVarVal("excess_matches", "Int32", Caption = "Excess Matches", Importance = 21)]
        public VarInt32 excess_matchesVar;

        [CoreVarVal("sale_matches", "Int32", Caption = "Sale Matches", Importance = 22)]
        public VarInt32 sale_matchesVar;

        [CoreVarVal("sale_average", "Double", Caption = "Sale Average", Importance = 23)]
        public VarDouble sale_averageVar;

        [CoreVarVal("sale_min", "Double", Caption = "Sale Min", Importance = 24)]
        public VarDouble sale_minVar;

        [CoreVarVal("sale_max", "Double", Caption = "Sale Max", Importance = 25)]
        public VarDouble sale_maxVar;

        [CoreVarVal("sale_earliest", "DateTime", Caption = "Sale Earliest", Importance = 26)]
        public VarDateTime sale_earliestVar;

        [CoreVarVal("sale_latest", "DateTime", Caption = "Sale Latest", Importance = 27)]
        public VarDateTime sale_latestVar;

        [CoreVarVal("purchase_matches", "Int32", Caption = "Purchase Matches", Importance = 28)]
        public VarInt32 purchase_matchesVar;

        [CoreVarVal("purchase_average", "Double", Caption = "Purchase Average", Importance = 29)]
        public VarDouble purchase_averageVar;

        [CoreVarVal("purchase_min", "Double", Caption = "Purchase Min", Importance = 30)]
        public VarDouble purchase_minVar;

        [CoreVarVal("purchase_max", "Double", Caption = "Purchase Max", Importance = 31)]
        public VarDouble purchase_maxVar;

        [CoreVarVal("purchase_earliest", "DateTime", Caption = "Purchase Earliest", Importance = 32)]
        public VarDateTime purchase_earliestVar;

        [CoreVarVal("purchase_latest", "DateTime", Caption = "Purchase Latest", Importance = 33)]
        public VarDateTime purchase_latestVar;

        [CoreVarVal("quote_matches", "Int32", Caption = "Quote Matches", Importance = 34)]
        public VarInt32 quote_matchesVar;

        [CoreVarVal("quote_average", "Double", Caption = "Quote Average", Importance = 35)]
        public VarDouble quote_averageVar;

        [CoreVarVal("quote_min", "Double", Caption = "Quote Min", Importance = 36)]
        public VarDouble quote_minVar;

        [CoreVarVal("quote_max", "Double", Caption = "Quote Max", Importance = 37)]
        public VarDouble quote_maxVar;

        [CoreVarVal("quote_earliest", "DateTime", Caption = "Quote Earliest", Importance = 38)]
        public VarDateTime quote_earliestVar;

        [CoreVarVal("quote_latest", "DateTime", Caption = "Quote Latest", Importance = 39)]
        public VarDateTime quote_latestVar;

        [CoreVarVal("is_strategic", "Boolean", Caption = "Is Strategic", Importance = 40)]
        public VarBoolean is_strategicVar;

        [CoreVarVal("customer_dock_date_initial", "DateTime", Caption = "Initial Customer Dock Date", Importance = 41)]
        public VarDateTime customer_dock_date_initialVar;

        [CoreVarVal("importid", "String", TheFieldLength = 255, Caption = "importid", Importance = 42)]
        public VarString importidVar;

        [CoreVarVal("was_email_alert_sent", "Boolean", Caption = "Was the intitial Manager Notification for new reqs sent", Importance = 43)]
        public VarBoolean was_email_alert_sentVar;

        [CoreVarVal("list_acquisition_agent", "String", TheFieldLength = 100, Caption = "List Acquisition Agent", Importance = 146)]
        public VarString list_acquisition_agentVar;

        [CoreVarVal("list_acquisition_agent_uid", "String", TheFieldLength = 100, Caption = "List Acquisition Agent ID", Importance = 146)]
        public VarString list_acquisition_agent_uidVar;

        [CoreVarVal("split_commission_type", "String", Caption = "Split commission type", Importance = 26)]
        public VarString split_commission_typeVar;

        [CoreVarVal("split_commission_agent_name", "String", TheFieldLength = 200, Caption = "Split Commission Agent Name", Importance = 27)]
        public VarString split_commission_agent_nameVar;

        [CoreVarVal("split_commission_agent_uid", "String", TheFieldLength = 200, Caption = "Split Commission AgentUid", Importance = 28)]
        public VarString split_commission_agent_uidVar;

        [CoreVarVal("split_commission_ID", "String", TheFieldLength = 100, Caption = "Split Commissin Linkage", Importance = 146)]
        public VarString split_commission_IDVar;



        [CoreVarVal("is_bom", "Boolean", TheFieldLength = 50, Caption = "Is BOM", Importance = 29)]
        public VarBoolean is_bomVar;

        [CoreVarVal("internalpart_vendor_uid", "string", TheFieldLength = 50, Caption = "Unique ID For the internal_vendor part.  Example GCAT linkage to line being tested.", Importance = 30)]
        public VarString internalpart_vendor_uidVar;

        [CoreVarVal("internalpart_vendor", "String", TheFieldLength = 255, Caption = "Vendor Internal Part.  Example GCAT linkage to line being tested.", Importance = 32)]
        public VarString internalpart_vendorVar;

        [CoreVarVal("affiliate_id", "string", TheFieldLength = 50, Caption = "Affiliate ID, usually an email.", Importance = 32)]
        public VarString affiliate_idVar;

        [CoreVarVal("country_of_origin_vendor", "string", TheFieldLength = 50, Caption = "Country of origin based on vendor bid.", Importance = 33)]
        public VarString country_of_origin_vendorVar;
        


        public orddet_quote_auto()
        {
            StaticInit();
            option_orddet_quote_uidVar = new VarString(this, option_orddet_quote_uidAttribute);
            the_orddet_rfq_uidVar = new VarString(this, the_orddet_rfq_uidAttribute);
            req_dateVar = new VarDateTime(this, req_dateAttribute);
            last_sales_idVar = new VarString(this, last_sales_idAttribute);
            last_sales_numberVar = new VarString(this, last_sales_numberAttribute);
            target_manufacturerVar = new VarString(this, target_manufacturerAttribute);
            target_datecodeVar = new VarString(this, target_datecodeAttribute);
            target_conditionVar = new VarString(this, target_conditionAttribute);
            target_deliveryVar = new VarString(this, target_deliveryAttribute);
            last_transmit_dateVar = new VarDateTime(this, last_transmit_dateAttribute);
            is_priorityVar = new VarBoolean(this, is_priorityAttribute);
            is_nostockVar = new VarBoolean(this, is_nostockAttribute);
            last_noteVar = new VarString(this, last_noteAttribute);
            is_deadVar = new VarBoolean(this, is_deadAttribute);
            dead_notesVar = new VarString(this, dead_notesAttribute);
            sourceVar = new VarString(this, sourceAttribute);
            last_quote_totalVar = new VarDouble(this, last_quote_totalAttribute);
            last_quote_dateVar = new VarDateTime(this, last_quote_dateAttribute);
            stock_matchesVar = new VarInt32(this, stock_matchesAttribute);
            consign_matchesVar = new VarInt32(this, consign_matchesAttribute);
            excess_matchesVar = new VarInt32(this, excess_matchesAttribute);
            sale_matchesVar = new VarInt32(this, sale_matchesAttribute);
            sale_averageVar = new VarDouble(this, sale_averageAttribute);
            sale_minVar = new VarDouble(this, sale_minAttribute);
            sale_maxVar = new VarDouble(this, sale_maxAttribute);
            sale_earliestVar = new VarDateTime(this, sale_earliestAttribute);
            sale_latestVar = new VarDateTime(this, sale_latestAttribute);
            purchase_matchesVar = new VarInt32(this, purchase_matchesAttribute);
            purchase_averageVar = new VarDouble(this, purchase_averageAttribute);
            purchase_minVar = new VarDouble(this, purchase_minAttribute);
            purchase_maxVar = new VarDouble(this, purchase_maxAttribute);
            purchase_earliestVar = new VarDateTime(this, purchase_earliestAttribute);
            purchase_latestVar = new VarDateTime(this, purchase_latestAttribute);
            quote_matchesVar = new VarInt32(this, quote_matchesAttribute);
            quote_averageVar = new VarDouble(this, quote_averageAttribute);
            quote_minVar = new VarDouble(this, quote_minAttribute);
            quote_maxVar = new VarDouble(this, quote_maxAttribute);
            quote_earliestVar = new VarDateTime(this, quote_earliestAttribute);
            quote_latestVar = new VarDateTime(this, quote_latestAttribute);
            is_strategicVar = new VarBoolean(this, is_strategicAttribute);
            customer_dock_date_initialVar = new VarDateTime(this, customer_dock_date_initialAttribute);
            importidVar = new VarString(this, importidAttribute);
            was_email_alert_sentVar = new VarBoolean(this, was_email_alert_sentAttribute);
            list_acquisition_agentVar = new VarString(this, list_acquisition_agentAttribute);
            list_acquisition_agent_uidVar = new VarString(this, list_acquisition_agent_uidAttribute);
            split_commission_typeVar = new VarString(this, split_commission_typeAttribute);
            split_commission_agent_nameVar = new VarString(this, split_commission_agent_nameAttribute);
            split_commission_agent_uidVar = new VarString(this, split_commission_agent_uidAttribute);
            split_commission_IDVar = new VarString(this, split_commission_IDAttribute);
            is_bomVar = new VarBoolean(this, is_bomAttribute);
            internalpart_vendor_uidVar = new VarString(this, internalpart_vendor_uidAttribute);
            internalpart_vendorVar = new VarString(this, internalpart_vendorAttribute);
            affiliate_idVar = new VarString(this, affiliate_idAttribute);
            country_of_origin_vendorVar = new VarString(this, country_of_origin_vendorAttribute);
            
        }


        public override string ClassId
        { get { return "orddet_quote"; } }

        public String option_orddet_quote_uid
        {
            get { return (String)option_orddet_quote_uidVar.Value; }
            set { option_orddet_quote_uidVar.Value = value; }
        }

        public String the_orddet_rfq_uid
        {
            get { return (String)the_orddet_rfq_uidVar.Value; }
            set { the_orddet_rfq_uidVar.Value = value; }
        }

        public DateTime req_date
        {
            get { return (DateTime)req_dateVar.Value; }
            set { req_dateVar.Value = value; }
        }

        public String last_sales_id
        {
            get { return (String)last_sales_idVar.Value; }
            set { last_sales_idVar.Value = value; }
        }

        public String last_sales_number
        {
            get { return (String)last_sales_numberVar.Value; }
            set { last_sales_numberVar.Value = value; }
        }

        public String target_manufacturer
        {
            get { return (String)target_manufacturerVar.Value; }
            set { target_manufacturerVar.Value = value; }
        }

        public String target_datecode
        {
            get { return (String)target_datecodeVar.Value; }
            set { target_datecodeVar.Value = value; }
        }

        public String target_condition
        {
            get { return (String)target_conditionVar.Value; }
            set { target_conditionVar.Value = value; }
        }

        public String target_delivery
        {
            get { return (String)target_deliveryVar.Value; }
            set { target_deliveryVar.Value = value; }
        }

        public DateTime last_transmit_date
        {
            get { return (DateTime)last_transmit_dateVar.Value; }
            set { last_transmit_dateVar.Value = value; }
        }

        public Boolean is_priority
        {
            get { return (Boolean)is_priorityVar.Value; }
            set { is_priorityVar.Value = value; }
        }

        public Boolean is_nostock
        {
            get { return (Boolean)is_nostockVar.Value; }
            set { is_nostockVar.Value = value; }
        }

        public String last_note
        {
            get { return (String)last_noteVar.Value; }
            set { last_noteVar.Value = value; }
        }

        public Boolean is_dead
        {
            get { return (Boolean)is_deadVar.Value; }
            set { is_deadVar.Value = value; }
        }

        public String dead_notes
        {
            get { return (String)dead_notesVar.Value; }
            set { dead_notesVar.Value = value; }
        }

        public String source
        {
            get { return (String)sourceVar.Value; }
            set { sourceVar.Value = value; }
        }

        public Double last_quote_total
        {
            get { return (Double)last_quote_totalVar.Value; }
            set { last_quote_totalVar.Value = value; }
        }

        public DateTime last_quote_date
        {
            get { return (DateTime)last_quote_dateVar.Value; }
            set { last_quote_dateVar.Value = value; }
        }

        public Int32 stock_matches
        {
            get { return (Int32)stock_matchesVar.Value; }
            set { stock_matchesVar.Value = value; }
        }

        public Int32 consign_matches
        {
            get { return (Int32)consign_matchesVar.Value; }
            set { consign_matchesVar.Value = value; }
        }

        public Int32 excess_matches
        {
            get { return (Int32)excess_matchesVar.Value; }
            set { excess_matchesVar.Value = value; }
        }

        public Int32 sale_matches
        {
            get { return (Int32)sale_matchesVar.Value; }
            set { sale_matchesVar.Value = value; }
        }

        public Double sale_average
        {
            get { return (Double)sale_averageVar.Value; }
            set { sale_averageVar.Value = value; }
        }

        public Double sale_min
        {
            get { return (Double)sale_minVar.Value; }
            set { sale_minVar.Value = value; }
        }

        public Double sale_max
        {
            get { return (Double)sale_maxVar.Value; }
            set { sale_maxVar.Value = value; }
        }

        public DateTime sale_earliest
        {
            get { return (DateTime)sale_earliestVar.Value; }
            set { sale_earliestVar.Value = value; }
        }

        public DateTime sale_latest
        {
            get { return (DateTime)sale_latestVar.Value; }
            set { sale_latestVar.Value = value; }
        }

        public Int32 purchase_matches
        {
            get { return (Int32)purchase_matchesVar.Value; }
            set { purchase_matchesVar.Value = value; }
        }

        public Double purchase_average
        {
            get { return (Double)purchase_averageVar.Value; }
            set { purchase_averageVar.Value = value; }
        }

        public Double purchase_min
        {
            get { return (Double)purchase_minVar.Value; }
            set { purchase_minVar.Value = value; }
        }

        public Double purchase_max
        {
            get { return (Double)purchase_maxVar.Value; }
            set { purchase_maxVar.Value = value; }
        }

        public DateTime purchase_earliest
        {
            get { return (DateTime)purchase_earliestVar.Value; }
            set { purchase_earliestVar.Value = value; }
        }

        public DateTime purchase_latest
        {
            get { return (DateTime)purchase_latestVar.Value; }
            set { purchase_latestVar.Value = value; }
        }

        public Int32 quote_matches
        {
            get { return (Int32)quote_matchesVar.Value; }
            set { quote_matchesVar.Value = value; }
        }

        public Double quote_average
        {
            get { return (Double)quote_averageVar.Value; }
            set { quote_averageVar.Value = value; }
        }

        public Double quote_min
        {
            get { return (Double)quote_minVar.Value; }
            set { quote_minVar.Value = value; }
        }

        public Double quote_max
        {
            get { return (Double)quote_maxVar.Value; }
            set { quote_maxVar.Value = value; }
        }

        public DateTime quote_earliest
        {
            get { return (DateTime)quote_earliestVar.Value; }
            set { quote_earliestVar.Value = value; }
        }

        public DateTime quote_latest
        {
            get { return (DateTime)quote_latestVar.Value; }
            set { quote_latestVar.Value = value; }
        }
        public Boolean is_strategic
        {
            get { return (Boolean)is_strategicVar.Value; }
            set { is_strategicVar.Value = value; }
        }
        public DateTime customer_dock_date_initial
        {
            get { return (DateTime)customer_dock_date_initialVar.Value; }
            set { customer_dock_date_initialVar.Value = value; }
        }

        public String importid
        {
            get { return (String)importidVar.Value; }
            set { importidVar.Value = value; }
        }

        public bool was_email_alert_sent
        {
            get { return (bool)was_email_alert_sentVar.Value; }
            set { was_email_alert_sentVar.Value = value; }
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


        public string split_commission_type
        {
            get { return (string)split_commission_typeVar.Value; }
            set { split_commission_typeVar.Value = value; }
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

        public string split_commission_ID
        {
            get { return (string)split_commission_IDVar.Value; }
            set { split_commission_IDVar.Value = value; }
        }

        public Boolean is_bom
        {
            get { return (Boolean)is_bomVar.Value; }
            set { is_bomVar.Value = value; }
        }

        public string internalpart_vendor_uid
        {
            get { return (string)internalpart_vendor_uidVar.Value; }
            set { internalpart_vendor_uidVar.Value = value; }
        }


        public String internalpart_vendor
        {
            get { return (String)internalpart_vendorVar.Value; }
            set { internalpart_vendorVar.Value = value; }
        }

        public String affiliate_id
        {
            get { return (String)affiliate_idVar.Value; }
            set { affiliate_idVar.Value = value; }
        }

        public String country_of_origin_vendor
        {
            get { return (String)country_of_origin_vendorVar.Value; }
            set { country_of_origin_vendorVar.Value = value; }
        }

        

    }
    public partial class orddet_quote
    {
        public static orddet_quote New(Context x)
        { return (orddet_quote)x.Item("orddet_quote"); }

        public static orddet_quote GetById(Context x, String uid)
        { return (orddet_quote)x.GetById("orddet_quote", uid); }

        public static orddet_quote QtO(Context x, String sql)
        { return (orddet_quote)x.QtO("orddet_quote", sql); }


    }
}
