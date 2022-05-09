using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("journal", Caption="Journal", Importance = 81)]
    public partial class journal_auto : NewMethod.nObject
    {
        static journal_auto()
        {
            Item.AttributesCache(typeof(journal_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "type":
                    typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_name":
                    account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_number":
                    account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_amount":
                    credit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "debit_amount":
                    debit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_id":
                    account_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "balance":
                    balanceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split":
                    splitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "entry_id":
                    entry_idAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute typeAttribute;
        static CoreVarValAttribute account_nameAttribute;
        static CoreVarValAttribute account_numberAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute credit_amountAttribute;
        static CoreVarValAttribute debit_amountAttribute;
        static CoreVarValAttribute account_idAttribute;
        static CoreVarValAttribute balanceAttribute;
        static CoreVarValAttribute splitAttribute;
        static CoreVarValAttribute entry_idAttribute;

        [CoreVarVal("type", "String", Caption="Type", Importance = 0)]
        public VarString typeVar;

        [CoreVarVal("account_name", "String", Caption="Account Name", Importance = 1)]
        public VarString account_nameVar;

        [CoreVarVal("account_number", "Int32", Caption="Account Number", Importance = 2)]
        public VarInt32 account_numberVar;

        [CoreVarVal("description", "String", Caption="Description", Importance = 3)]
        public VarString descriptionVar;

        [CoreVarVal("credit_amount", "Double", ValueUse = ValueUse.UnitMoney, Caption="Credit Amount", Importance = 4)]
        public VarDouble credit_amountVar;

        [CoreVarVal("debit_amount", "Double", ValueUse = ValueUse.UnitMoney, Caption="Debit Amount", Importance = 5)]
        public VarDouble debit_amountVar;

        [CoreVarVal("account_id", "String", Caption="Account Id", Importance = 6)]
        public VarString account_idVar;

        [CoreVarVal("balance", "Double", ValueUse = ValueUse.UnitMoney, Caption="Balance", Importance = 7)]
        public VarDouble balanceVar;

        [CoreVarVal("split", "String", Caption="Split", Importance = 8)]
        public VarString splitVar;

        [CoreVarVal("entry_id", "String", Caption="Entry Id", Importance = 9)]
        public VarString entry_idVar;

        public journal_auto()
        {
            StaticInit();
            typeVar = new VarString(this, typeAttribute);
            account_nameVar = new VarString(this, account_nameAttribute);
            account_numberVar = new VarInt32(this, account_numberAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            credit_amountVar = new VarDouble(this, credit_amountAttribute);
            debit_amountVar = new VarDouble(this, debit_amountAttribute);
            account_idVar = new VarString(this, account_idAttribute);
            balanceVar = new VarDouble(this, balanceAttribute);
            splitVar = new VarString(this, splitAttribute);
            entry_idVar = new VarString(this, entry_idAttribute);
        }

        public override string ClassId
        { get { return "journal"; } }

        public String type
        {
            get  { return (String)typeVar.Value; }
            set  { typeVar.Value = value; }
        }

        public String account_name
        {
            get  { return (String)account_nameVar.Value; }
            set  { account_nameVar.Value = value; }
        }

        public Int32 account_number
        {
            get  { return (Int32)account_numberVar.Value; }
            set  { account_numberVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public Double credit_amount
        {
            get  { return (Double)credit_amountVar.Value; }
            set  { credit_amountVar.Value = value; }
        }

        public Double debit_amount
        {
            get  { return (Double)debit_amountVar.Value; }
            set  { debit_amountVar.Value = value; }
        }

        public String account_id
        {
            get  { return (String)account_idVar.Value; }
            set  { account_idVar.Value = value; }
        }

        public Double balance
        {
            get  { return (Double)balanceVar.Value; }
            set  { balanceVar.Value = value; }
        }

        public String split
        {
            get  { return (String)splitVar.Value; }
            set  { splitVar.Value = value; }
        }

        public String entry_id
        {
            get  { return (String)entry_idVar.Value; }
            set  { entry_idVar.Value = value; }
        }

    }
    public partial class journal
    {
        public static journal New(Context x)
        {  return (journal)x.Item("journal"); }

        public static journal GetById(Context x, String uid)
        { return (journal)x.GetById("journal", uid); }

        public static journal QtO(Context x, String sql)
        { return (journal)x.QtO("journal", sql); }
    }
}
