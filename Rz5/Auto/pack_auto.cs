using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("pack")]
    public partial class pack_auto : NewMethod.nObject
    {
        static pack_auto()
        {
            Item.AttributesCache(typeof(pack_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode":
                    datecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "condition":
                    conditionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "location":
                    locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "boxnum":
                    boxnumAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_invoice_uid":
                    the_orddet_invoice_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_purchase_uid":
                    the_orddet_purchase_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_rma_uid":
                    the_orddet_rma_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_vendrma_uid":
                    the_orddet_vendrma_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_service_out_uid":
                    the_orddet_service_out_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_service_in_uid":
                    the_orddet_service_in_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "drop_ship":
                    drop_shipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_code":
                    line_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "put_away":
                    put_awayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_partrecord_uid":
                    the_partrecord_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "packaging":
                    packagingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_code":
                    lot_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "serial":
                    serialAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pack_complete":
                    pack_completeAttribute = (CoreVarValAttribute)attr;
                    break;

                    
            }
        }

        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute datecodeAttribute;
        static CoreVarValAttribute conditionAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute locationAttribute;
        static CoreVarValAttribute boxnumAttribute;
        static CoreVarValAttribute the_orddet_invoice_uidAttribute;
        static CoreVarValAttribute the_orddet_purchase_uidAttribute;
        static CoreVarValAttribute the_orddet_rma_uidAttribute;
        static CoreVarValAttribute the_orddet_vendrma_uidAttribute;
        static CoreVarValAttribute the_orddet_service_out_uidAttribute;
        static CoreVarValAttribute the_orddet_service_in_uidAttribute;
        static CoreVarValAttribute drop_shipAttribute;
        static CoreVarValAttribute line_codeAttribute;
        static CoreVarValAttribute put_awayAttribute;
        static CoreVarValAttribute the_partrecord_uidAttribute;
        static CoreVarValAttribute packagingAttribute;
        static CoreVarValAttribute lot_codeAttribute;
        static CoreVarValAttribute serialAttribute;
        static CoreVarValAttribute pack_completeAttribute;
        

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Fullpartnumber", Importance = 1)]
        public VarString fullpartnumberVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 255, Caption="Manufacturer", Importance = 2)]
        public VarString manufacturerVar;

        [CoreVarVal("datecode", "String", TheFieldLength = 255, Caption="Datecode", Importance = 3)]
        public VarString datecodeVar;

        [CoreVarVal("condition", "String", TheFieldLength = 255, Caption="Condition", Importance = 4)]
        public VarString conditionVar;

        [CoreVarVal("quantity", "Int32", Caption="Quantity", Importance = 5)]
        public VarInt32 quantityVar;

        [CoreVarVal("location", "String", TheFieldLength = 255, Caption="Location", Importance = 6)]
        public VarString locationVar;

        [CoreVarVal("boxnum", "String", TheFieldLength = 255, Caption="Boxnum", Importance = 7)]
        public VarString boxnumVar;

        [CoreVarVal("the_orddet_invoice_uid", "String", TheFieldLength = 255, Caption="The Orddet Invoice Uid", Importance = 8)]
        public VarString the_orddet_invoice_uidVar;

        [CoreVarVal("the_orddet_purchase_uid", "String", TheFieldLength = 255, Caption="The Orddet Purchase Uid", Importance = 9)]
        public VarString the_orddet_purchase_uidVar;

        [CoreVarVal("the_orddet_rma_uid", "String", TheFieldLength = 255, Caption="The Orddet Rma Uid", Importance = 10)]
        public VarString the_orddet_rma_uidVar;

        [CoreVarVal("the_orddet_vendrma_uid", "String", TheFieldLength = 255, Caption="The Orddet Vendrma Uid", Importance = 11)]
        public VarString the_orddet_vendrma_uidVar;

        [CoreVarVal("the_orddet_service_out_uid", "String", TheFieldLength = 255, Caption="The Orddet Service Out Uid", Importance = 12)]
        public VarString the_orddet_service_out_uidVar;

        [CoreVarVal("the_orddet_service_in_uid", "String", TheFieldLength = 255, Caption="The Orddet Service In Uid", Importance = 13)]
        public VarString the_orddet_service_in_uidVar;

        [CoreVarVal("drop_ship", "Boolean", Caption="Drop Ship", Importance = 14)]
        public VarBoolean drop_shipVar;

        [CoreVarVal("line_code", "Int32", Caption="Line Code", Importance = 15)]
        public VarInt32 line_codeVar;

        [CoreVarVal("put_away", "Boolean", Caption="Put Away", Importance = 16)]
        public VarBoolean put_awayVar;

        [CoreVarVal("the_partrecord_uid", "String", TheFieldLength = 255, Caption="The Partrecord Uid", Importance = 17)]
        public VarString the_partrecord_uidVar;

        [CoreVarVal("packaging", "String", TheFieldLength = 255, Caption="Packaging", Importance = 18)]
        public VarString packagingVar;

        [CoreVarVal("lot_code", "String", TheFieldLength = 255, Caption="Lot Code", Importance = 19)]
        public VarString lot_codeVar;

        [CoreVarVal("serial", "String", TheFieldLength = 255, Caption = "Serial", Importance = 20)]
        public VarString serialVar;

        [CoreVarVal("pack_complete", "Boolean", Caption = "Pack / Unpack completed", Importance = 16)]
        public VarBoolean pack_completeVar;

        

        public pack_auto()
        {
            StaticInit();
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            datecodeVar = new VarString(this, datecodeAttribute);
            conditionVar = new VarString(this, conditionAttribute);
            quantityVar = new VarInt32(this, quantityAttribute);
            locationVar = new VarString(this, locationAttribute);
            boxnumVar = new VarString(this, boxnumAttribute);
            the_orddet_invoice_uidVar = new VarString(this, the_orddet_invoice_uidAttribute);
            the_orddet_purchase_uidVar = new VarString(this, the_orddet_purchase_uidAttribute);
            the_orddet_rma_uidVar = new VarString(this, the_orddet_rma_uidAttribute);
            the_orddet_vendrma_uidVar = new VarString(this, the_orddet_vendrma_uidAttribute);
            the_orddet_service_out_uidVar = new VarString(this, the_orddet_service_out_uidAttribute);
            the_orddet_service_in_uidVar = new VarString(this, the_orddet_service_in_uidAttribute);
            drop_shipVar = new VarBoolean(this, drop_shipAttribute);
            line_codeVar = new VarInt32(this, line_codeAttribute);
            put_awayVar = new VarBoolean(this, put_awayAttribute);
            the_partrecord_uidVar = new VarString(this, the_partrecord_uidAttribute);
            packagingVar = new VarString(this, packagingAttribute);
            lot_codeVar = new VarString(this, lot_codeAttribute);
            serialVar = new VarString(this, serialAttribute);
            pack_completeVar = new VarBoolean(this, pack_completeAttribute);
            
        }

        public override string ClassId
        { get { return "pack"; } }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public String manufacturer
        {
            get  { return (String)manufacturerVar.Value; }
            set  { manufacturerVar.Value = value; }
        }

        public String datecode
        {
            get  { return (String)datecodeVar.Value; }
            set  { datecodeVar.Value = value; }
        }

        public String condition
        {
            get  { return (String)conditionVar.Value; }
            set  { conditionVar.Value = value; }
        }

        public Int32 quantity
        {
            get  { return (Int32)quantityVar.Value; }
            set  { quantityVar.Value = value; }
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

        public String the_orddet_invoice_uid
        {
            get  { return (String)the_orddet_invoice_uidVar.Value; }
            set  { the_orddet_invoice_uidVar.Value = value; }
        }

        public String the_orddet_purchase_uid
        {
            get  { return (String)the_orddet_purchase_uidVar.Value; }
            set  { the_orddet_purchase_uidVar.Value = value; }
        }

        public String the_orddet_rma_uid
        {
            get  { return (String)the_orddet_rma_uidVar.Value; }
            set  { the_orddet_rma_uidVar.Value = value; }
        }

        public String the_orddet_vendrma_uid
        {
            get  { return (String)the_orddet_vendrma_uidVar.Value; }
            set  { the_orddet_vendrma_uidVar.Value = value; }
        }

        public String the_orddet_service_out_uid
        {
            get  { return (String)the_orddet_service_out_uidVar.Value; }
            set  { the_orddet_service_out_uidVar.Value = value; }
        }

        public String the_orddet_service_in_uid
        {
            get  { return (String)the_orddet_service_in_uidVar.Value; }
            set  { the_orddet_service_in_uidVar.Value = value; }
        }

        public Boolean drop_ship
        {
            get  { return (Boolean)drop_shipVar.Value; }
            set  { drop_shipVar.Value = value; }
        }

        public Int32 line_code
        {
            get  { return (Int32)line_codeVar.Value; }
            set  { line_codeVar.Value = value; }
        }

        public Boolean put_away
        {
            get  { return (Boolean)put_awayVar.Value; }
            set  { put_awayVar.Value = value; }
        }

        public String the_partrecord_uid
        {
            get  { return (String)the_partrecord_uidVar.Value; }
            set  { the_partrecord_uidVar.Value = value; }
        }

        public String packaging
        {
            get  { return (String)packagingVar.Value; }
            set  { packagingVar.Value = value; }
        }

        public String lot_code
        {
            get  { return (String)lot_codeVar.Value; }
            set  { lot_codeVar.Value = value; }
        }

        public String serial
        {
            get { return (String)serialVar.Value; }
            set { serialVar.Value = value; }
        }

        public Boolean pack_complete
        {
            get { return (Boolean)pack_completeVar.Value; }
            set { pack_completeVar.Value = value; }
        }





    }
    public partial class pack
    {
        public static pack New(Context x)
        {  return (pack)x.Item("pack"); }

        public static pack GetById(Context x, String uid)
        { return (pack)x.GetById("pack", uid); }

        public static pack QtO(Context x, String sql)
        { return (pack)x.QtO("pack", sql); }
    }
}
