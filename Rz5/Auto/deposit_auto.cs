using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("deposit", Caption="Deposit", Importance = 84)]
    public partial class deposit_auto : NewMethod.nObject
    {
        static deposit_auto()
        {
            Item.AttributesCache(typeof(deposit_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_name":
                    account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_uid":
                    account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_amount":
                    total_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
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
                case "vendor_uid":
                    vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_number":
                    account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dest_account_number":
                    dest_account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cleared":
                    clearedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dest_account_full_name":
                    dest_account_full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_full_name":
                    account_full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute account_nameAttribute;
        static CoreVarValAttribute account_uidAttribute;
        static CoreVarValAttribute total_amountAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute dest_account_nameAttribute;
        static CoreVarValAttribute dest_account_uidAttribute;
        static CoreVarValAttribute balanceAttribute;
        static CoreVarValAttribute vendor_uidAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute account_numberAttribute;
        static CoreVarValAttribute dest_account_numberAttribute;
        static CoreVarValAttribute clearedAttribute;
        static CoreVarValAttribute dest_account_full_nameAttribute;
        static CoreVarValAttribute account_full_nameAttribute;

        [CoreVarVal("name", "String", Caption="Name", Importance = 0)]
        public VarString nameVar;

        [CoreVarVal("account_name", "String", Caption="Account Name", Importance = 1)]
        public VarString account_nameVar;

        [CoreVarVal("account_uid", "String", Caption="Account Uid", Importance = 2)]
        public VarString account_uidVar;

        [CoreVarVal("total_amount", "Double", Caption="Total Amount", Importance = 3)]
        public VarDouble total_amountVar;

        [CoreVarVal("description", "Text", Caption="Description", Importance = 4)]
        public VarText descriptionVar;

        [CoreVarVal("dest_account_name", "String", Caption="Dest Account Name", Importance = 5)]
        public VarString dest_account_nameVar;

        [CoreVarVal("dest_account_uid", "String", Caption="Dest Account Uid", Importance = 6)]
        public VarString dest_account_uidVar;

        [CoreVarVal("balance", "Double", Caption="Balance", Importance = 7)]
        public VarDouble balanceVar;

        [CoreVarVal("vendor_uid", "String", Caption="Vendor Uid", Importance = 8)]
        public VarString vendor_uidVar;

        [CoreVarVal("vendor_name", "String", Caption="Vendor Name", Importance = 9)]
        public VarString vendor_nameVar;

        [CoreVarVal("account_number", "Int32", Caption="Account Number", Importance = 10)]
        public VarInt32 account_numberVar;

        [CoreVarVal("dest_account_number", "Int32", Caption="Dest Account Number", Importance = 11)]
        public VarInt32 dest_account_numberVar;

        [CoreVarVal("cleared", "Boolean", Caption="Cleared", Importance = 12)]
        public VarBoolean clearedVar;

        [CoreVarVal("dest_account_full_name", "String", Caption="Dest Account Full Name", Importance = 13)]
        public VarString dest_account_full_nameVar;

        [CoreVarVal("account_full_name", "String", Caption="Account Full Name", Importance = 14)]
        public VarString account_full_nameVar;

        public deposit_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            account_nameVar = new VarString(this, account_nameAttribute);
            account_uidVar = new VarString(this, account_uidAttribute);
            total_amountVar = new VarDouble(this, total_amountAttribute);
            descriptionVar = new VarText(this, descriptionAttribute);
            dest_account_nameVar = new VarString(this, dest_account_nameAttribute);
            dest_account_uidVar = new VarString(this, dest_account_uidAttribute);
            balanceVar = new VarDouble(this, balanceAttribute);
            vendor_uidVar = new VarString(this, vendor_uidAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            account_numberVar = new VarInt32(this, account_numberAttribute);
            dest_account_numberVar = new VarInt32(this, dest_account_numberAttribute);
            clearedVar = new VarBoolean(this, clearedAttribute);
            dest_account_full_nameVar = new VarString(this, dest_account_full_nameAttribute);
            account_full_nameVar = new VarString(this, account_full_nameAttribute);
        }

        public override string ClassId
        { get { return "deposit"; } }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String account_name
        {
            get  { return (String)account_nameVar.Value; }
            set  { account_nameVar.Value = value; }
        }

        public String account_uid
        {
            get  { return (String)account_uidVar.Value; }
            set  { account_uidVar.Value = value; }
        }

        public Double total_amount
        {
            get  { return (Double)total_amountVar.Value; }
            set  { total_amountVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
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

        public Boolean cleared
        {
            get  { return (Boolean)clearedVar.Value; }
            set  { clearedVar.Value = value; }
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

    }
    public partial class deposit
    {
        public static deposit New(Context x)
        {  return (deposit)x.Item("deposit"); }

        public static deposit GetById(Context x, String uid)
        { return (deposit)x.GetById("deposit", uid); }

        public static deposit QtO(Context x, String sql)
        { return (deposit)x.QtO("deposit", sql); }

        public static deposit GetByName(Context x, String name, String extraSql = "")
        { return (deposit)x.GetByName("deposit", name, extraSql); }
    }
}
