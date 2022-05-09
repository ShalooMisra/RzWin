using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("payment_in", Caption="Payment In", Importance = 85)]
    public partial class payment_in_auto : NewMethod.nObject
    {
        static payment_in_auto()
        {
            Item.AttributesCache(typeof(payment_in_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "customer_uid":
                    customer_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_name":
                    customer_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "amount":
                    amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "deposit_uid":
                    deposit_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "deposit_name":
                    deposit_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_method":
                    payment_methodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "method_details":
                    method_detailsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_deposited":
                    is_depositedAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute customer_uidAttribute;
        static CoreVarValAttribute customer_nameAttribute;
        static CoreVarValAttribute amountAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute deposit_uidAttribute;
        static CoreVarValAttribute deposit_nameAttribute;
        static CoreVarValAttribute payment_methodAttribute;
        static CoreVarValAttribute method_detailsAttribute;
        static CoreVarValAttribute is_depositedAttribute;

        [CoreVarVal("customer_uid", "String", Caption="Customer Uid", Importance = 0)]
        public VarString customer_uidVar;

        [CoreVarVal("customer_name", "String", Caption="Customer Name", Importance = 1)]
        public VarString customer_nameVar;

        [CoreVarVal("amount", "Double", Caption="Amount", Importance = 2)]
        public VarDouble amountVar;

        [CoreVarVal("description", "Text", Caption="Description", Importance = 3)]
        public VarText descriptionVar;

        [CoreVarVal("deposit_uid", "String", Caption="Deposit Uid", Importance = 4)]
        public VarString deposit_uidVar;

        [CoreVarVal("deposit_name", "String", Caption="Deposit Name", Importance = 5)]
        public VarString deposit_nameVar;

        [CoreVarVal("payment_method", "String", Caption="Payment Method", Importance = 6)]
        public VarString payment_methodVar;

        [CoreVarVal("method_details", "Text", Caption="Method Details", Importance = 7)]
        public VarText method_detailsVar;

        [CoreVarVal("is_deposited", "Boolean", Caption="Is Deposited", Importance = 8)]
        public VarBoolean is_depositedVar;

        public payment_in_auto()
        {
            StaticInit();
            customer_uidVar = new VarString(this, customer_uidAttribute);
            customer_nameVar = new VarString(this, customer_nameAttribute);
            amountVar = new VarDouble(this, amountAttribute);
            descriptionVar = new VarText(this, descriptionAttribute);
            deposit_uidVar = new VarString(this, deposit_uidAttribute);
            deposit_nameVar = new VarString(this, deposit_nameAttribute);
            payment_methodVar = new VarString(this, payment_methodAttribute);
            method_detailsVar = new VarText(this, method_detailsAttribute);
            is_depositedVar = new VarBoolean(this, is_depositedAttribute);
        }

        public override string ClassId
        { get { return "payment_in"; } }

        public String customer_uid
        {
            get  { return (String)customer_uidVar.Value; }
            set  { customer_uidVar.Value = value; }
        }

        public String customer_name
        {
            get  { return (String)customer_nameVar.Value; }
            set  { customer_nameVar.Value = value; }
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

        public String deposit_uid
        {
            get  { return (String)deposit_uidVar.Value; }
            set  { deposit_uidVar.Value = value; }
        }

        public String deposit_name
        {
            get  { return (String)deposit_nameVar.Value; }
            set  { deposit_nameVar.Value = value; }
        }

        public String payment_method
        {
            get  { return (String)payment_methodVar.Value; }
            set  { payment_methodVar.Value = value; }
        }

        public String method_details
        {
            get  { return (String)method_detailsVar.Value; }
            set  { method_detailsVar.Value = value; }
        }

        public Boolean is_deposited
        {
            get  { return (Boolean)is_depositedVar.Value; }
            set  { is_depositedVar.Value = value; }
        }

    }
    public partial class payment_in
    {
        public static payment_in New(Context x)
        {  return (payment_in)x.Item("payment_in"); }

        public static payment_in GetById(Context x, String uid)
        { return (payment_in)x.GetById("payment_in", uid); }

        public static payment_in QtO(Context x, String sql)
        { return (payment_in)x.QtO("payment_in", sql); }
    }
}
