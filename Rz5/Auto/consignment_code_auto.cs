using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("consignment_code")]
    public partial class consignment_code_auto : NewMethod.nObject
    {
        static consignment_code_auto()
        {
            Item.AttributesCache(typeof(consignment_code_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "code_name":
                    code_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payout_percent":
                    payout_percentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "keep_percent":
                    keep_percentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_uid":
                    vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_contact_uid":
                    vendor_contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_contact_name":
                    vendor_contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "code_line":
                    code_lineAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_key":
                    order_keyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_stock":
                    is_stockAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_inactive":
                    is_inactiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "consignment_bogey":
                    consignment_bogeyAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute code_nameAttribute;
        static CoreVarValAttribute payout_percentAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute keep_percentAttribute;
        static CoreVarValAttribute vendor_uidAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute vendor_contact_uidAttribute;
        static CoreVarValAttribute vendor_contact_nameAttribute;
        static CoreVarValAttribute code_lineAttribute;
        static CoreVarValAttribute order_keyAttribute;
        static CoreVarValAttribute is_stockAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute is_inactiveAttribute;
        static CoreVarValAttribute consignment_bogeyAttribute;
        


        [CoreVarVal("code_name", "String", TheFieldLength = 255, Caption="Code Name", Importance = 1)]
        public VarString code_nameVar;

        [CoreVarVal("payout_percent", "Int32", Caption="Payout Percent", Importance = 2)]
        public VarInt32 payout_percentVar;

        [CoreVarVal("description", "String", TheFieldLength = 8000, Caption="Description", Importance = 3)]
        public VarString descriptionVar;

        [CoreVarVal("keep_percent", "Int32", Caption="Keep Percent", Importance = 4)]
        public VarInt32 keep_percentVar;

        [CoreVarVal("vendor_uid", "String", TheFieldLength = 255, Caption="Vendor Uid", Importance = 5)]
        public VarString vendor_uidVar;

        [CoreVarVal("vendor_name", "String", TheFieldLength = 255, Caption="Vendor Name", Importance = 6)]
        public VarString vendor_nameVar;

        [CoreVarVal("vendor_contact_uid", "String", TheFieldLength = 255, Caption="Vendor Contact Uid", Importance = 7)]
        public VarString vendor_contact_uidVar;

        [CoreVarVal("vendor_contact_name", "String", TheFieldLength = 255, Caption="Vendor Contact Name", Importance = 8)]
        public VarString vendor_contact_nameVar;

        [CoreVarVal("code_line", "String", TheFieldLength = 4096, Caption="Code Line", Importance = 9)]
        public VarString code_lineVar;

        [CoreVarVal("order_key", "String", TheFieldLength = 255, Caption="Order Key", Importance = 10)]
        public VarString order_keyVar;

        [CoreVarVal("is_stock", "Boolean", Caption="Is Stock", Importance = 11)]
        public VarBoolean is_stockVar;

        [CoreVarVal("notes", "Text", Caption="Notes", Importance = 12)]
        public VarText notesVar;

        [CoreVarVal("is_inactive", "Boolean", Caption="Is Inactive", Importance = 13)]
        public VarBoolean is_inactiveVar;

        [CoreVarVal("consignment_bogey", "Double", Caption = "Consignment Bogey - Amount to sell (total price) before commissionable", Importance = 14)]
        public VarDouble consignment_bogeyVar;


        

        public consignment_code_auto()
        {
            StaticInit();
            code_nameVar = new VarString(this, code_nameAttribute);
            payout_percentVar = new VarInt32(this, payout_percentAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            keep_percentVar = new VarInt32(this, keep_percentAttribute);
            vendor_uidVar = new VarString(this, vendor_uidAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            vendor_contact_uidVar = new VarString(this, vendor_contact_uidAttribute);
            vendor_contact_nameVar = new VarString(this, vendor_contact_nameAttribute);
            code_lineVar = new VarString(this, code_lineAttribute);
            order_keyVar = new VarString(this, order_keyAttribute);
            is_stockVar = new VarBoolean(this, is_stockAttribute);
            notesVar = new VarText(this, notesAttribute);
            is_inactiveVar = new VarBoolean(this, is_inactiveAttribute);
            consignment_bogeyVar = new VarDouble(this, consignment_bogeyAttribute);
            
        }

        public override string ClassId
        { get { return "consignment_code"; } }

        public String code_name
        {
            get  { return (String)code_nameVar.Value; }
            set  { code_nameVar.Value = value; }
        }

        public Int32 payout_percent
        {
            get  { return (Int32)payout_percentVar.Value; }
            set  { payout_percentVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public Int32 keep_percent
        {
            get  { return (Int32)keep_percentVar.Value; }
            set  { keep_percentVar.Value = value; }
        }

        public String vendor_uid
        {
            get  { return (String)vendor_uidVar.Value; }
            set  { vendor_uidVar.Value = value; }
        }

        public String vendor_name
        {
            get  { return (String)vendor_nameVar.Value; }
            set  { vendor_nameVar.Value = value; }
        }

        public String vendor_contact_uid
        {
            get  { return (String)vendor_contact_uidVar.Value; }
            set  { vendor_contact_uidVar.Value = value; }
        }

        public String vendor_contact_name
        {
            get  { return (String)vendor_contact_nameVar.Value; }
            set  { vendor_contact_nameVar.Value = value; }
        }

        public String code_line
        {
            get  { return (String)code_lineVar.Value; }
            set  { code_lineVar.Value = value; }
        }

        public String order_key
        {
            get  { return (String)order_keyVar.Value; }
            set  { order_keyVar.Value = value; }
        }

        public Boolean is_stock
        {
            get  { return (Boolean)is_stockVar.Value; }
            set  { is_stockVar.Value = value; }
        }

        public String notes
        {
            get  { return (String)notesVar.Value; }
            set  { notesVar.Value = value; }
        }

        public Boolean is_inactive
        {
            get  { return (Boolean)is_inactiveVar.Value; }
            set  { is_inactiveVar.Value = value; }
        }

        public double consignment_bogey
        {
            get { return (double)consignment_bogeyVar.Value; }
            set { consignment_bogeyVar.Value = value; }
        }

        

    }
    public partial class consignment_code
    {
        public static consignment_code New(Context x)
        {  return (consignment_code)x.Item("consignment_code"); }

        public static consignment_code GetById(Context x, String uid)
        { return (consignment_code)x.GetById("consignment_code", uid); }

        public static consignment_code QtO(Context x, String sql)
        { return (consignment_code)x.QtO("consignment_code", sql); }
    }
}
