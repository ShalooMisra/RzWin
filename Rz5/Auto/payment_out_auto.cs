using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("payment_out", Caption="Payment Out", Importance = 86)]
    public partial class payment_out_auto : NewMethod.nObject
    {
        static payment_out_auto()
        {
            Item.AttributesCache(typeof(payment_out_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "vendor_uid":
                    vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "amount":
                    amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_uid":
                    account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_name":
                    account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cleared":
                    clearedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reference_number":
                    reference_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "check_number":
                    check_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dest_account_name":
                    dest_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dest_account_uid":
                    dest_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "balance":
                    balanceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_number":
                    account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dest_account_number":
                    dest_account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dest_account_full_name":
                    dest_account_full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_full_name":
                    account_full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_method":
                    payment_methodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "check_printed":
                    check_printedAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute vendor_uidAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute amountAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute account_uidAttribute;
        static CoreVarValAttribute account_nameAttribute;
        static CoreVarValAttribute clearedAttribute;
        static CoreVarValAttribute reference_numberAttribute;
        static CoreVarValAttribute check_numberAttribute;
        static CoreVarValAttribute dest_account_nameAttribute;
        static CoreVarValAttribute dest_account_uidAttribute;
        static CoreVarValAttribute balanceAttribute;
        static CoreVarValAttribute account_numberAttribute;
        static CoreVarValAttribute dest_account_numberAttribute;
        static CoreVarValAttribute dest_account_full_nameAttribute;
        static CoreVarValAttribute account_full_nameAttribute;
        static CoreVarValAttribute payment_methodAttribute;
        static CoreVarValAttribute check_printedAttribute;

        [CoreVarVal("vendor_uid", "String", Caption="Vendor Uid", Importance = 0)]
        public VarString vendor_uidVar;

        [CoreVarVal("vendor_name", "String", Caption="Vendor Name", Importance = 1)]
        public VarString vendor_nameVar;

        [CoreVarVal("amount", "Double", Caption="Amount", Importance = 2)]
        public VarDouble amountVar;

        [CoreVarVal("description", "Text", Caption="Description", Importance = 3)]
        public VarText descriptionVar;

        [CoreVarVal("account_uid", "String", Caption="Account Uid", Importance = 4)]
        public VarString account_uidVar;

        [CoreVarVal("account_name", "String", Caption="Account Name", Importance = 5)]
        public VarString account_nameVar;

        [CoreVarVal("cleared", "Boolean", Caption="Cleared", Importance = 6)]
        public VarBoolean clearedVar;

        [CoreVarVal("reference_number", "String", Caption="Reference Number", Importance = 7)]
        public VarString reference_numberVar;

        [CoreVarVal("check_number", "Int32", Caption="Check Number", Importance = 8)]
        public VarInt32 check_numberVar;

        [CoreVarVal("dest_account_name", "String", Caption="Dest Account Name", Importance = 9)]
        public VarString dest_account_nameVar;

        [CoreVarVal("dest_account_uid", "String", Caption="Dest Account Uid", Importance = 10)]
        public VarString dest_account_uidVar;

        [CoreVarVal("balance", "Double", Caption="Balance", Importance = 11)]
        public VarDouble balanceVar;

        [CoreVarVal("account_number", "Int32", Caption="Account Number", Importance = 12)]
        public VarInt32 account_numberVar;

        [CoreVarVal("dest_account_number", "Int32", Caption="Dest Account Number", Importance = 13)]
        public VarInt32 dest_account_numberVar;

        [CoreVarVal("dest_account_full_name", "String", Caption="Dest Account Full Name", Importance = 14)]
        public VarString dest_account_full_nameVar;

        [CoreVarVal("account_full_name", "String", Caption="Account Full Name", Importance = 15)]
        public VarString account_full_nameVar;

        [CoreVarVal("payment_method", "String", Caption="Payment Method", Importance = 16)]
        public VarString payment_methodVar;

        [CoreVarVal("check_printed", "Boolean", Caption="Check Printed", Importance = 17)]
        public VarBoolean check_printedVar;

        public payment_out_auto()
        {
            StaticInit();
            vendor_uidVar = new VarString(this, vendor_uidAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            amountVar = new VarDouble(this, amountAttribute);
            descriptionVar = new VarText(this, descriptionAttribute);
            account_uidVar = new VarString(this, account_uidAttribute);
            account_nameVar = new VarString(this, account_nameAttribute);
            clearedVar = new VarBoolean(this, clearedAttribute);
            reference_numberVar = new VarString(this, reference_numberAttribute);
            check_numberVar = new VarInt32(this, check_numberAttribute);
            dest_account_nameVar = new VarString(this, dest_account_nameAttribute);
            dest_account_uidVar = new VarString(this, dest_account_uidAttribute);
            balanceVar = new VarDouble(this, balanceAttribute);
            account_numberVar = new VarInt32(this, account_numberAttribute);
            dest_account_numberVar = new VarInt32(this, dest_account_numberAttribute);
            dest_account_full_nameVar = new VarString(this, dest_account_full_nameAttribute);
            account_full_nameVar = new VarString(this, account_full_nameAttribute);
            payment_methodVar = new VarString(this, payment_methodAttribute);
            check_printedVar = new VarBoolean(this, check_printedAttribute);
        }

        public override string ClassId
        { get { return "payment_out"; } }

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

        public Double amount
        {
            get  { return (Double)amountVar.Value; }
            set  { amountVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String account_uid
        {
            get  { return (String)account_uidVar.Value; }
            set  { account_uidVar.Value = value; }
        }

        public String account_name
        {
            get  { return (String)account_nameVar.Value; }
            set  { account_nameVar.Value = value; }
        }

        public Boolean cleared
        {
            get  { return (Boolean)clearedVar.Value; }
            set  { clearedVar.Value = value; }
        }

        public String reference_number
        {
            get  { return (String)reference_numberVar.Value; }
            set  { reference_numberVar.Value = value; }
        }

        public Int32 check_number
        {
            get  { return (Int32)check_numberVar.Value; }
            set  { check_numberVar.Value = value; }
        }

        public String dest_account_name
        {
            get  { return (String)dest_account_nameVar.Value; }
            set  { dest_account_nameVar.Value = value; }
        }

        public String dest_account_uid
        {
            get  { return (String)dest_account_uidVar.Value; }
            set  { dest_account_uidVar.Value = value; }
        }

        public Double balance
        {
            get  { return (Double)balanceVar.Value; }
            set  { balanceVar.Value = value; }
        }

        public Int32 account_number
        {
            get  { return (Int32)account_numberVar.Value; }
            set  { account_numberVar.Value = value; }
        }

        public Int32 dest_account_number
        {
            get  { return (Int32)dest_account_numberVar.Value; }
            set  { dest_account_numberVar.Value = value; }
        }

        public String dest_account_full_name
        {
            get  { return (String)dest_account_full_nameVar.Value; }
            set  { dest_account_full_nameVar.Value = value; }
        }

        public String account_full_name
        {
            get  { return (String)account_full_nameVar.Value; }
            set  { account_full_nameVar.Value = value; }
        }

        public String payment_method
        {
            get  { return (String)payment_methodVar.Value; }
            set  { payment_methodVar.Value = value; }
        }

        public Boolean check_printed
        {
            get  { return (Boolean)check_printedVar.Value; }
            set  { check_printedVar.Value = value; }
        }

    }
    public partial class payment_out
    {
        public static payment_out New(Context x)
        {  return (payment_out)x.Item("payment_out"); }

        public static payment_out GetById(Context x, String uid)
        { return (payment_out)x.GetById("payment_out", uid); }

        public static payment_out QtO(Context x, String sql)
        { return (payment_out)x.QtO("payment_out", sql); }
    }
}
