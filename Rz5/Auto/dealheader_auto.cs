using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;
using System.Collections;

namespace Rz5
{
    [CoreClass("dealheader")]
    public partial class dealheader_auto : NewMethod.nObject
    {
        static dealheader_auto()
        {
            Item.AttributesCache(typeof(dealheader_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "main_n_team_uid":
                    main_n_team_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dealheader_name":
                    dealheader_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "start_date":
                    start_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_closed":
                    is_closedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "end_date":
                    end_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "teamname":
                    teamnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manually_created":
                    manually_createdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_approved":
                    is_approvedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_name":
                    customer_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_uid":
                    customer_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact_name":
                    contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact_uid":
                    contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                //KT Refactored from RzSensible
                case "is_sourced":
                    is_sourcedAttribute = (CoreVarValAttribute)attr;
                    break;

                case "opportunity_stage":
                    opportunity_stageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ClosureReason":
                    ClosureReasonAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_oem_product":
                    is_oem_productAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oem_product_name":
                    oem_product_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oem_product_uid":
                    oem_product_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oem_product_qty":
                    oem_product_qtyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_deal_id":
                    hubspot_deal_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_deal_created":
                    hubspot_deal_createdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_deal_created_date":
                    hubspot_deal_created_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internal_parts":
                    internal_partsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_portal_generated":
                    is_portal_generatedAttribute = (CoreVarValAttribute)attr;
                    break;
                //case "split_commission_agent_name":
                //    split_commission_agent_nameAttribute = (CoreVarValAttribute)attr;
                //    break;
                //case "split_commission_agent_uid":
                //    split_commission_agent_uidAttribute = (CoreVarValAttribute)attr;
                //    break;
                //case "split_commission_type":
                //    split_commission_typeAttribute = (CoreVarValAttribute)attr;
                //    break;
                case "split_commission_ID":
                    split_commission_IDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_bom":
                    is_bomAttribute = (CoreVarValAttribute)attr;
                    break;
                case "affiliate_id":
                    affiliate_idAttribute = (CoreVarValAttribute)attr;
                    break;

                case "affiliate_name":
                    affiliate_nameAttribute = (CoreVarValAttribute)attr;
                    break;

                    

            }
        }

        static CoreVarValAttribute main_n_team_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute dealheader_nameAttribute;
        static CoreVarValAttribute start_dateAttribute;
        static CoreVarValAttribute is_closedAttribute;
        static CoreVarValAttribute end_dateAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute teamnameAttribute;
        static CoreVarValAttribute manually_createdAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute is_approvedAttribute;
        static CoreVarValAttribute customer_nameAttribute;
        static CoreVarValAttribute customer_uidAttribute;
        static CoreVarValAttribute contact_nameAttribute;
        static CoreVarValAttribute contact_uidAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute is_sourcedAttribute;
        static CoreVarValAttribute opportunity_stageAttribute;
        static CoreVarValAttribute ClosureReasonAttribute;
        static CoreVarValAttribute is_oem_productAttribute;
        static CoreVarValAttribute oem_product_nameAttribute;
        static CoreVarValAttribute oem_product_uidAttribute;
        static CoreVarValAttribute oem_product_qtyAttribute;
        static CoreVarValAttribute hubspot_deal_idAttribute;
        static CoreVarValAttribute hubspot_deal_createdAttribute;
        static CoreVarValAttribute hubspot_deal_created_dateAttribute;
        static CoreVarValAttribute internal_partsAttribute;
        static CoreVarValAttribute is_portal_generatedAttribute;
        //static CoreVarValAttribute split_commission_agent_nameAttribute;
        //static CoreVarValAttribute split_commission_agent_uidAttribute;
        //static CoreVarValAttribute split_commission_typeAttribute;
        static CoreVarValAttribute split_commission_IDAttribute;
        static CoreVarValAttribute is_bomAttribute;
        static CoreVarValAttribute affiliate_idAttribute;
        static CoreVarValAttribute affiliate_nameAttribute;
        
        [CoreVarVal("main_n_team_uid", "String", TheFieldLength = 255, Caption = "Main N Team Uid", Importance = -2)]
        public VarString main_n_team_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", Caption = "Base Mc User Id")]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("dealheader_name", "String", TheFieldLength = 255, Caption = "Dealheader Name", Importance = 1)]
        public VarString dealheader_nameVar;

        [CoreVarVal("start_date", "DateTime", Caption = "Start Date", Importance = 2)]
        public VarDateTime start_dateVar;

        [CoreVarVal("is_closed", "Boolean", Caption = "Is Closed", Importance = 3)]
        public VarBoolean is_closedVar;

        [CoreVarVal("end_date", "DateTime", Caption = "End Date", Importance = 4)]
        public VarDateTime end_dateVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 255, Caption = "Agentname", Importance = 5)]
        public VarString agentnameVar;

        [CoreVarVal("teamname", "String", TheFieldLength = 255, Caption = "Teamname", Importance = 6)]
        public VarString teamnameVar;

        [CoreVarVal("manually_created", "Boolean", Caption = "Manually Created", Importance = 7)]
        public VarBoolean manually_createdVar;

        [CoreVarVal("notes", "Text", Caption = "Notes", Importance = 8)]
        public VarText notesVar;

        [CoreVarVal("is_approved", "Boolean", Caption = "Is Approved", Importance = 9)]
        public VarBoolean is_approvedVar;

        [CoreVarVal("customer_name", "String", TheFieldLength = 255, Caption = "Customer Name", Importance = 10)]
        public VarString customer_nameVar;

        [CoreVarVal("customer_uid", "String", TheFieldLength = 255, Caption = "Customer Uid", Importance = 11)]
        public VarString customer_uidVar;

        [CoreVarVal("contact_name", "String", TheFieldLength = 255, Caption = "Contact Name", Importance = 12)]
        public VarString contact_nameVar;

        [CoreVarVal("contact_uid", "String", TheFieldLength = 255, Caption = "Contact Uid", Importance = 13)]
        public VarString contact_uidVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption = "User Name", Importance = 14)]
        public VarString user_nameVar;

        [CoreVarVal("is_sourced", "Boolean", Caption = "Is Sourced", Importance = 15)]
        public VarBoolean is_sourcedVar;

        [CoreVarVal("opportunity_stage", "String", TheFieldLength = 50, Caption = "Opportunity Stage", Importance = 16)]
        public VarString opportunity_stageVar;

        [CoreVarVal("ClosureReason", "String", TheFieldLength = 50, Caption = "Closure Reason", Importance = 17)]
        public VarString ClosureReasonVar;

        [CoreVarVal("is_oem_product", "Boolean", Caption = "Is OEM PRoduct", Importance = 18)]
        public VarBoolean is_oem_productVar;

        [CoreVarVal("oem_product_name", "String", TheFieldLength = 50, Caption = "OEM Product Name", Importance = 19)]
        public VarString oem_product_nameVar;

        [CoreVarVal("oem_product_uid", "String", TheFieldLength = 50, Caption = "OEM Product UID", Importance = 20)]
        public VarString oem_product_uidVar;

        [CoreVarVal("oem_product_qty", "Int32", Caption = "OEM Product QTY", Importance = 21)]
        public VarInt32 oem_product_qtyVar;

        [CoreVarVal("hubspot_deal_id", "Int64", TheFieldLength = 50, Caption = "Hubspot Deal ID", Importance = 22)]
        public VarInt64 hubspot_deal_idVar;

        [CoreVarVal("hubspot_deal_created", "Boolean", Caption = "Has a hubspot deal been created?", Importance = 23)]
        public VarBoolean hubspot_deal_createdVar;

        [CoreVarVal("hubspot_deal_created_date", "DateTime", Caption = "Hubspot Deal Creation Date", Importance = 24)]
        public VarDateTime hubspot_deal_created_dateVar;

        [CoreVarVal("internal_parts", "Text", Caption = "Internal Parts", Importance = 25)]
        public VarText internal_partsVar;

        [CoreVarVal("is_portal_generated", "Boolean", Caption = "Did this deal originate from the portal?", Importance = 23)]
        public VarBoolean is_portal_generatedVar;

        //[CoreVarVal("split_commission_agent_name", "String", TheFieldLength = 50, Caption = "Split Commission Agent Name", Importance = 24)]
        //public VarString split_commission_agent_nameVar;

        //[CoreVarVal("split_commission_agent_uid", "String", TheFieldLength = 50, Caption = "Split Commission Agent ID", Importance = 25)]
        //public VarString split_commission_agent_uidVar;

        //[CoreVarVal("split_commission_type", "String", TheFieldLength = 50, Caption = "Split Commission type", Importance = 25)]
        //public VarString split_commission_typeVar;

        [CoreVarVal("split_commission_ID", "String", TheFieldLength = 100, Caption = "Split Commissin Linkage", Importance = 146)]
        public VarString split_commission_IDVar;

        [CoreVarVal("is_bom", "Boolean", TheFieldLength = 50, Caption = "Is BOM", Importance = 25)]
        public VarBoolean is_bomVar;

        [CoreVarVal("affiliate_id", "String", TheFieldLength = 50, Caption = "Affiliate ID", Importance = 26)]
        public VarString affiliate_idVar;

        [CoreVarVal("affiliate_name", "String", TheFieldLength = 50, Caption = "Affiliate Name", Importance = 27)]
        public VarString affiliate_nameVar;
        



        public dealheader_auto()
        {
            StaticInit();
            main_n_team_uidVar = new VarString(this, main_n_team_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            dealheader_nameVar = new VarString(this, dealheader_nameAttribute);
            start_dateVar = new VarDateTime(this, start_dateAttribute);
            is_closedVar = new VarBoolean(this, is_closedAttribute);
            end_dateVar = new VarDateTime(this, end_dateAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            teamnameVar = new VarString(this, teamnameAttribute);
            manually_createdVar = new VarBoolean(this, manually_createdAttribute);
            notesVar = new VarText(this, notesAttribute);
            is_approvedVar = new VarBoolean(this, is_approvedAttribute);
            customer_nameVar = new VarString(this, customer_nameAttribute);
            customer_uidVar = new VarString(this, customer_uidAttribute);
            contact_nameVar = new VarString(this, contact_nameAttribute);
            contact_uidVar = new VarString(this, contact_uidAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            is_sourcedVar = new VarBoolean(this, is_sourcedAttribute);
            opportunity_stageVar = new VarString(this, opportunity_stageAttribute);
            ClosureReasonVar = new VarString(this, ClosureReasonAttribute);
            is_oem_productVar = new VarBoolean(this, is_oem_productAttribute);
            oem_product_nameVar = new VarString(this, oem_product_nameAttribute);
            oem_product_uidVar = new VarString(this, oem_product_uidAttribute);
            oem_product_qtyVar = new VarInt32(this, oem_product_qtyAttribute);
            hubspot_deal_idVar = new VarInt64(this, hubspot_deal_idAttribute);
            hubspot_deal_createdVar = new VarBoolean(this, hubspot_deal_createdAttribute);
            hubspot_deal_created_dateVar = new VarDateTime(this, hubspot_deal_created_dateAttribute);
            internal_partsVar = new VarText(this, internal_partsAttribute);
            is_portal_generatedVar = new VarBoolean(this, is_portal_generatedAttribute);
            //split_commission_agent_nameVar = new VarString(this, split_commission_agent_nameAttribute);
            //split_commission_agent_uidVar = new VarString(this, split_commission_agent_uidAttribute);
            //split_commission_typeVar = new VarString(this, split_commission_typeAttribute);
            split_commission_IDVar = new VarString(this, split_commission_IDAttribute);
            is_bomVar = new VarBoolean(this, is_bomAttribute);
            affiliate_idVar = new VarString(this, affiliate_idAttribute);
            affiliate_nameVar = new VarString(this, affiliate_nameAttribute);
            


        }

        public override string ClassId
        { get { return "dealheader"; } }

        public String main_n_team_uid
        {
            get { return (String)main_n_team_uidVar.Value; }
            set { main_n_team_uidVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get { return (String)base_mc_user_uidVar.Value; }
            set { base_mc_user_uidVar.Value = value; }
        }

        public String dealheader_name
        {
            get { return (String)dealheader_nameVar.Value; }
            set { dealheader_nameVar.Value = value; }
        }

        public DateTime start_date
        {
            get { return (DateTime)start_dateVar.Value; }
            set { start_dateVar.Value = value; }
        }

        public Boolean is_closed
        {
            get { return (Boolean)is_closedVar.Value; }
            set { is_closedVar.Value = value; }
        }

        public DateTime end_date
        {
            get { return (DateTime)end_dateVar.Value; }
            set { end_dateVar.Value = value; }
        }

        public String agentname
        {
            get { return (String)agentnameVar.Value; }
            set { agentnameVar.Value = value; }
        }

        public String teamname
        {
            get { return (String)teamnameVar.Value; }
            set { teamnameVar.Value = value; }
        }

        public Boolean manually_created
        {
            get { return (Boolean)manually_createdVar.Value; }
            set { manually_createdVar.Value = value; }
        }

        public String notes
        {
            get { return (String)notesVar.Value; }
            set { notesVar.Value = value; }
        }

        public Boolean is_approved
        {
            get { return (Boolean)is_approvedVar.Value; }
            set { is_approvedVar.Value = value; }
        }

        public String customer_name
        {
            get { return (String)customer_nameVar.Value; }
            set { customer_nameVar.Value = value; }
        }

        public String customer_uid
        {
            get { return (String)customer_uidVar.Value; }
            set { customer_uidVar.Value = value; }
        }

        public String contact_name
        {
            get { return (String)contact_nameVar.Value; }
            set { contact_nameVar.Value = value; }
        }

        public String contact_uid
        {
            get { return (String)contact_uidVar.Value; }
            set { contact_uidVar.Value = value; }
        }

        public String user_name
        {
            get { return (String)user_nameVar.Value; }
            set { user_nameVar.Value = value; }
        }

        public Boolean is_sourced
        {
            get { return (Boolean)is_sourcedVar.Value; }
            set { is_sourcedVar.Value = value; }
        }

        public String opportunity_stage
        {
            get { return (String)opportunity_stageVar.Value; }
            set { opportunity_stageVar.Value = value; }
        }

        public String ClosureReason
        {
            get { return (String)ClosureReasonVar.Value; }
            set { ClosureReasonVar.Value = value; }
        }
        public bool is_oem_product
        {
            get { return (bool)is_oem_productVar.Value; }
            set { is_oem_productVar.Value = value; }
        }

        public string oem_product_name
        {
            get { return (string)oem_product_nameVar.Value; }
            set { oem_product_nameVar.Value = value; }
        }

        public string oem_product_uid
        {
            get { return (string)oem_product_uidVar.Value; }
            set { oem_product_uidVar.Value = value; }
        }

        public Int32 oem_product_qty
        {
            get { return (Int32)oem_product_qtyVar.Value; }
            set { oem_product_qtyVar.Value = value; }
        }

        public Int64 hubspot_deal_id
        {
            get { return (Int64)hubspot_deal_idVar.Value; }
            set { hubspot_deal_idVar.Value = value; }
        }

        public Boolean hubspot_deal_created
        {
            get { return (Boolean)hubspot_deal_createdVar.Value; }
            set { hubspot_deal_createdVar.Value = value; }
        }

        public DateTime hubspot_deal_created_date
        {
            get { return (DateTime)hubspot_deal_created_dateVar.Value; }
            set { hubspot_deal_created_dateVar.Value = value; }
        }

        public String internal_parts
        {
            get { return (String)internal_partsVar.Value; }
            set { internal_partsVar.Value = value; }
        }

        public Boolean is_portal_generated
        {
            get { return (Boolean)is_portal_generatedVar.Value; }
            set { is_portal_generatedVar.Value = value; }
        }

        //public String split_commission_agent_name
        //{
        //    get { return (String)split_commission_agent_nameVar.Value; }
        //    set { split_commission_agent_nameVar.Value = value; }
        //}

        //public String split_commission_agent_uid
        //{
        //    get { return (String)split_commission_agent_uidVar.Value; }
        //    set { split_commission_agent_uidVar.Value = value; }
        //}

        //public String split_commission_type
        //{
        //    get { return (String)split_commission_typeVar.Value; }
        //    set { split_commission_typeVar.Value = value; }
        //}

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

        public String affiliate_id
        {
            get { return (String)affiliate_idVar.Value; }
            set { affiliate_idVar.Value = value; }
        }

        public String affiliate_name
        {
            get { return (String)affiliate_nameVar.Value; }
            set { affiliate_nameVar.Value = value; }
        }
        

    }
    public partial class dealheader
    {
        public static dealheader New(Context x)
        { return (dealheader)x.Item("dealheader"); }

        public static dealheader GetById(Context x, String uid)
        { return (dealheader)x.GetById("dealheader", uid); }

        public static dealheader QtO(Context x, String sql)
        { return (dealheader)x.QtO("dealheader", sql); }

       
    }
}
