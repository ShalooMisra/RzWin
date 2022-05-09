using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("service_line")]
    public partial class service_line_auto : NewMethod.nObject
    {
        static service_line_auto()
        {
            Item.AttributesCache(typeof(service_line_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "service_name":
                    service_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_line_uid":
                    the_orddet_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_code":
                    line_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_cost":
                    unit_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_cost":
                    total_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_service_order_uid":
                    the_service_order_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reference_id":
                    reference_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "nonconid":
                    nonconidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_notes":
                    service_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_line_ListID":
                    qb_line_ListIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_line_subitem_ListID":
                    qb_line_subitem_ListIDAttribute = (CoreVarValAttribute)attr;
                    break;
                    
                case "qb_line_TxnID":
                    qb_line_TxnIDAttribute = (CoreVarValAttribute)attr;
                    break;
                //case "hts_code":
                //    hts_codeAttribute = (CoreVarValAttribute)attr;
                //    break;

                case "harmonized_code":
                    harmonized_codeAttribute = (CoreVarValAttribute)attr;
                    break;






            }
        }

        static CoreVarValAttribute service_nameAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute the_orddet_line_uidAttribute;
        static CoreVarValAttribute line_codeAttribute;
        static CoreVarValAttribute unit_costAttribute;
        static CoreVarValAttribute total_costAttribute;
        static CoreVarValAttribute the_service_order_uidAttribute;
        static CoreVarValAttribute reference_idAttribute;
        static CoreVarValAttribute nonconidAttribute;
        static CoreVarValAttribute service_notesAttribute;
        static CoreVarValAttribute qb_line_ListIDAttribute;
        static CoreVarValAttribute qb_line_subitem_ListIDAttribute;        
        static CoreVarValAttribute qb_line_TxnIDAttribute;
        //static CoreVarValAttribute hts_codeAttribute;
        static CoreVarValAttribute harmonized_codeAttribute;
        

        [CoreVarVal("service_name", "String", TheFieldLength = 255, Caption="Service Name", Importance = 1)]
        public VarString service_nameVar;

        [CoreVarVal("quantity", "Int32", Caption="Quantity", Importance = 4)]
        public VarInt32 quantityVar;

        [CoreVarVal("the_orddet_line_uid", "String", TheFieldLength = 255, Caption="The Orddet Line Uid", Importance = 6)]
        public VarString the_orddet_line_uidVar;

        [CoreVarVal("line_code", "Int32", Caption="Line Code", Importance = 7)]
        public VarInt32 line_codeVar;

        [CoreVarVal("unit_cost", "Double", Caption="Unit Cost", Importance = 8)]
        public VarDouble unit_costVar;

        [CoreVarVal("total_cost", "Double", Caption="Total Cost", Importance = 9)]
        public VarDouble total_costVar;

        [CoreVarVal("the_service_order_uid", "String", TheFieldLength = 255, Caption="The Service Order Uid", Importance = 10)]
        public VarString the_service_order_uidVar;

        [CoreVarVal("reference_id", "String", TheFieldLength = 255, Caption="Reference Id", Importance = 11)]
        public VarString reference_idVar;

        [CoreVarVal("nonconid", "Int32", Caption = "Nonconformance ID", Importance = 7)]
        public VarInt32 nonconidVar;

        [CoreVarVal("service_notes", "String", TheFieldLength = 4096, Caption = "Service Notes", Importance = 12)]
        public VarString service_notesVar;

        [CoreVarVal("qb_line_ListID", "String", TheFieldLength = 255, Caption = "Qb List ID", Importance = 13)]
        public VarString qb_line_ListIDVar;

        [CoreVarVal("qb_line_subitem_ListID", "String", TheFieldLength = 255, Caption = "Qb Subitem List ID", Importance = 14)]
        public VarString qb_line_subitem_ListIDVar;
        

        [CoreVarVal("qb_line_TxnID", "String", TheFieldLength = 255, Caption = "Qb Order Txn ID", Importance = 15)]
        public VarString qb_line_TxnIDVar;


        //[CoreVarVal("hts_code", "String", TheFieldLength = 255, Caption = "HTS Code", Importance = 16)]
        //public VarString hts_codeVar;

        [CoreVarVal("harmonized_code", "String", TheFieldLength = 255, Caption = "Harmonized Code", Importance = 17)]
        public VarString harmonized_codeVar;

        
        public service_line_auto()
        {
            StaticInit();
            service_nameVar = new VarString(this, service_nameAttribute);
            quantityVar = new VarInt32(this, quantityAttribute);
            the_orddet_line_uidVar = new VarString(this, the_orddet_line_uidAttribute);
            line_codeVar = new VarInt32(this, line_codeAttribute);
            unit_costVar = new VarDouble(this, unit_costAttribute);
            total_costVar = new VarDouble(this, total_costAttribute);
            the_service_order_uidVar = new VarString(this, the_service_order_uidAttribute);
            reference_idVar = new VarString(this, reference_idAttribute);
            nonconidVar = new VarInt32(this, nonconidAttribute);
            service_notesVar = new VarString(this, service_notesAttribute);
            qb_line_ListIDVar = new VarString(this, qb_line_ListIDAttribute);
            qb_line_subitem_ListIDVar = new VarString(this, qb_line_subitem_ListIDAttribute);
            qb_line_TxnIDVar = new VarString(this, qb_line_TxnIDAttribute);
            //hts_codeVar = new VarString(this, hts_codeAttribute);
            harmonized_codeVar = new VarString(this, harmonized_codeAttribute);
            


        }

        public override string ClassId
        { get { return "service_line"; } }

        public String service_name
        {
            get  { return (String)service_nameVar.Value; }
            set  { service_nameVar.Value = value; }
        }

        public Int32 quantity
        {
            get  { return (Int32)quantityVar.Value; }
            set  { quantityVar.Value = value; }
        }

        public String the_orddet_line_uid
        {
            get  { return (String)the_orddet_line_uidVar.Value; }
            set  { the_orddet_line_uidVar.Value = value; }
        }

        public Int32 line_code
        {
            get  { return (Int32)line_codeVar.Value; }
            set  { line_codeVar.Value = value; }
        }

        public Double unit_cost
        {
            get  { return (Double)unit_costVar.Value; }
            set  { unit_costVar.Value = value; }
        }

        public Double total_cost
        {
            get  { return (Double)total_costVar.Value; }
            set  { total_costVar.Value = value; }
        }

        public String the_service_order_uid
        {
            get  { return (String)the_service_order_uidVar.Value; }
            set  { the_service_order_uidVar.Value = value; }
        }

        public String reference_id
        {
            get  { return (String)reference_idVar.Value; }
            set  { reference_idVar.Value = value; }
        }
        public Int32 nonconid
        {
            get { return (Int32)nonconidVar.Value; }
            set { nonconidVar.Value = value; }
            
        }

        public String service_notes
        {
            get { return (String)service_notesVar.Value; }
            set { service_notesVar.Value = value; }
        }

        public String qb_line_ListID
        {
            get { return (String)qb_line_ListIDVar.Value; }
            set { qb_line_ListIDVar.Value = value; }
        }

        public String qb_line_subitem_ListID
        {
            get { return (String)qb_line_subitem_ListIDVar.Value; }
            set { qb_line_subitem_ListIDVar.Value = value; }
        }               

        public String qb_line_TxnID
        {
            get { return (String)qb_line_TxnIDVar.Value; }
            set { qb_line_TxnIDVar.Value = value; }
        }

        //public String hts_code
        //{
        //    get { return (String)hts_codeVar.Value; }
        //    set { hts_codeVar.Value = value; }
        //}

        public String harmonized_code
        {
            get { return (String)harmonized_codeVar.Value; }
            set { harmonized_codeVar.Value = value; }
        }
        

    }
    public partial class service_line
    {
        public static service_line New(Context x)
        {  return (service_line)x.Item("service_line"); }

        public static service_line GetById(Context x, String uid)
        { return (service_line)x.GetById("service_line", uid); }

        public static service_line QtO(Context x, String sql)
        { return (service_line)x.QtO("service_line", sql); }
    }
}
