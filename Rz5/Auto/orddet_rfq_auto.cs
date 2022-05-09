using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("orddet_rfq")]
    public partial class orddet_rfq_auto : Rz5.orddet_old
    {
        static orddet_rfq_auto()
        {
            Item.AttributesCache(typeof(orddet_rfq_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_orddet_quote_uid":
                    the_orddet_quote_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_purchase_id":
                    last_purchase_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_purchase_number":
                    last_purchase_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_canceled":
                    is_canceledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importid":
                    importidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent":
                    list_acquisition_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent_uid":
                    list_acquisition_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalpart_vendor_uid":
                    internalpart_vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internalpart_vendor":
                    internalpart_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country":
                    countryAttribute = (CoreVarValAttribute)attr;
                    break;


                    //case "internalpart_vendor":
                    //    internalpart_vendorAttribute = (CoreVarValAttribute)attr;
                    //    break;
                    //case "internalpart_vendor_vendor_uid":
                    //    internalpart_vendor_uidAttribute = (CoreVarValAttribute)attr;
                    //    break;

            }
        }

        static CoreVarValAttribute the_orddet_quote_uidAttribute;
        static CoreVarValAttribute last_purchase_idAttribute;
        static CoreVarValAttribute last_purchase_numberAttribute;
        static CoreVarValAttribute is_canceledAttribute;
        static CoreVarValAttribute importidAttribute;
        static CoreVarValAttribute list_acquisition_agentAttribute;
        static CoreVarValAttribute list_acquisition_agent_uidAttribute;
        static CoreVarValAttribute internalpart_vendor_uidAttribute;
        static CoreVarValAttribute internalpart_vendorAttribute;
        static CoreVarValAttribute countryAttribute;

        

        [CoreVarVal("the_orddet_quote_uid", "String", TheFieldLength = 255, Caption = "The Orddet Quote Uid", Importance = 1)]
        public VarString the_orddet_quote_uidVar;

        [CoreVarVal("last_purchase_id", "String", TheFieldLength = 255, Caption = "Last Purchase Id", Importance = 2)]
        public VarString last_purchase_idVar;

        [CoreVarVal("last_purchase_number", "String", TheFieldLength = 255, Caption = "Last Purchase Number", Importance = 3)]
        public VarString last_purchase_numberVar;

        [CoreVarVal("is_canceled", "Boolean", Caption = "Is Canceled", Importance = 4)]
        public VarBoolean is_canceledVar;

        [CoreVarVal("importid", "String", TheFieldLength = 255, Caption = "Stock / Consign Import ID", Importance = 5)]
        public VarString importidVar;
        [CoreVarVal("list_acquisition_agent", "String", TheFieldLength = 100, Caption = "List Acquisition Agent", Importance = 6)]
        public VarString list_acquisition_agentVar;

        [CoreVarVal("list_acquisition_agent_uid", "String", TheFieldLength = 100, Caption = "List Acquisition Agent ID", Importance = 7)]
        public VarString list_acquisition_agent_uidVar;


        [CoreVarVal("internalpart_vendor_uid", "String", TheFieldLength = 100, Caption = "Vendor Internal Part.  Example GCAT linkage to line being tested.", Importance = 7)]
        public VarString internalpart_vendor_uidVar;

        [CoreVarVal("internalpart_vendor", "String", TheFieldLength = 100, Caption = "Vendor Internal Part.  Example GCAT linkage to line being tested.", Importance = 7)]
        public VarString internalpart_vendorVar;

        //[CoreVarVal("internalpart_vendor", "String", TheFieldLength = 200, Caption = "Vendor Internal Part.  Example GCAT linkage to line being tested.", Importance = 8)]
        //public VarString internalpart_vendorVar;

        //[CoreVarVal("internalpart_vendor_uid", "String", TheFieldLength = 200, Caption = "Vendor Internal Part ID.  Example GCAT linkage to line being tested.", Importance = 9)]
        //public VarString internalpart_vendor_uidVar;
        [CoreVarVal("country", "String", TheFieldLength = 100, Caption = "Country of Origin", Importance = 8)]
        public VarString countryVar;
        





        public orddet_rfq_auto()
        {
            StaticInit();
            the_orddet_quote_uidVar = new VarString(this, the_orddet_quote_uidAttribute);
            last_purchase_idVar = new VarString(this, last_purchase_idAttribute);
            last_purchase_numberVar = new VarString(this, last_purchase_numberAttribute);
            is_canceledVar = new VarBoolean(this, is_canceledAttribute);
            importidVar = new VarString(this, importidAttribute);
            list_acquisition_agentVar = new VarString(this, list_acquisition_agentAttribute);
            list_acquisition_agent_uidVar = new VarString(this, list_acquisition_agent_uidAttribute);
            internalpart_vendor_uidVar = new VarString(this, internalpart_vendor_uidAttribute);
            internalpart_vendorVar = new VarString(this, internalpart_vendorAttribute);
            //internalpart_vendorVar = new VarString(this, internalpart_vendorAttribute);
            //internalpart_vendor_uidVar = new VarString(this, internalpart_vendor_uidAttribute);
            countryVar = new VarString(this, countryAttribute);

            
        }

        public override string ClassId
        { get { return "orddet_rfq"; } }

        public String the_orddet_quote_uid
        {
            get { return (String)the_orddet_quote_uidVar.Value; }
            set { the_orddet_quote_uidVar.Value = value; }
        }

        public String last_purchase_id
        {
            get { return (String)last_purchase_idVar.Value; }
            set { last_purchase_idVar.Value = value; }
        }

        public String last_purchase_number
        {
            get { return (String)last_purchase_numberVar.Value; }
            set { last_purchase_numberVar.Value = value; }
        }

        public Boolean is_canceled
        {
            get { return (Boolean)is_canceledVar.Value; }
            set { is_canceledVar.Value = value; }
        }

        public String importid
        {
            get { return (String)importidVar.Value; }
            set { importidVar.Value = value; }
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

        public string internalpart_vendor_uid
        {
            get { return (string)internalpart_vendor_uidVar.Value; }
            set { internalpart_vendor_uidVar.Value = value; }
        }

        public string internalpart_vendor
        {
            get { return (string)internalpart_vendorVar.Value; }
            set { internalpart_vendorVar.Value = value; }
        }
        //public string internalpart_vendor
        //{
        //    get { return (string)internalpart_vendorVar.Value; }
        //    set { internalpart_vendorVar.Value = value; }
        //}

        //public string internalpart_vendor_uid
        //{
        //    get { return (string)internalpart_vendor_uidVar.Value; }
        //    set { internalpart_vendor_uidVar.Value = value; }
        //}
        public string country
        {
            get { return (string)countryVar.Value; }
            set { countryVar.Value = value; }
        }
        





    }
    public partial class orddet_rfq
    {
        public static orddet_rfq New(Context x)
        { return (orddet_rfq)x.Item("orddet_rfq"); }

        public static orddet_rfq GetById(Context x, String uid)
        { return (orddet_rfq)x.GetById("orddet_rfq", uid); }

        public static orddet_rfq QtO(Context x, String sql)
        { return (orddet_rfq)x.QtO("orddet_rfq", sql); }
    }
}
