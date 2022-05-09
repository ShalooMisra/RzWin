using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("creditmemo_det", Caption="Creditmemo Det", Importance = 88)]
    public partial class creditmemo_det_auto : NewMethod.nObject
    {
        static creditmemo_det_auto()
        {
            Item.AttributesCache(typeof(creditmemo_det_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_creditmemo_hed_uid":
                    the_creditmemo_hed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate":
                    orderdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber":
                    ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_full_name":
                    account_full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_name":
                    account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_number":
                    account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_uid":
                    account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prefixstripped":
                    prefixstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "basenumberstripped":
                    basenumberstrippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price":
                    unit_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode":
                    linecodeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price":
                    total_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "type":
                    typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "applied_amount":
                    applied_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_paid":
                    is_paidAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_creditmemo_hed_uidAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute orderdateAttribute;
        static CoreVarValAttribute ordernumberAttribute;
        static CoreVarValAttribute account_full_nameAttribute;
        static CoreVarValAttribute account_nameAttribute;
        static CoreVarValAttribute account_numberAttribute;
        static CoreVarValAttribute account_uidAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute prefixstrippedAttribute;
        static CoreVarValAttribute basenumberstrippedAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute unit_priceAttribute;
        static CoreVarValAttribute linecodeAttribute;
        static CoreVarValAttribute total_priceAttribute;
        static CoreVarValAttribute typeAttribute;
        static CoreVarValAttribute applied_amountAttribute;
        static CoreVarValAttribute is_paidAttribute;

        [CoreVarVal("the_creditmemo_hed_uid", "String", Caption="The Creditmemo Hed Uid", Importance = 0)]
        public VarString the_creditmemo_hed_uidVar;

        [CoreVarVal("companyname", "String", Caption="Companyname", Importance = 1)]
        public VarString companynameVar;

        [CoreVarVal("base_company_uid", "String", Caption="Base Company Uid", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("contactname", "String", Caption="Contactname", Importance = 3)]
        public VarString contactnameVar;

        [CoreVarVal("base_companycontact_uid", "String", Caption="Base Companycontact Uid", Importance = 4)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("orderdate", "DateTime", Caption="Orderdate", Importance = 5)]
        public VarDateTime orderdateVar;

        [CoreVarVal("ordernumber", "String", Caption="Ordernumber", Importance = 6)]
        public VarString ordernumberVar;

        [CoreVarVal("account_full_name", "String", Caption="Account Full Name", Importance = 7)]
        public VarString account_full_nameVar;

        [CoreVarVal("account_name", "String", Caption="Account Name", Importance = 8)]
        public VarString account_nameVar;

        [CoreVarVal("account_number", "Int32", Caption="Account Number", Importance = 9)]
        public VarInt32 account_numberVar;

        [CoreVarVal("account_uid", "String", Caption="Account Uid", Importance = 10)]
        public VarString account_uidVar;

        [CoreVarVal("fullpartnumber", "String", Caption="Fullpartnumber", Importance = 11)]
        public VarString fullpartnumberVar;

        [CoreVarVal("prefixstripped", "String", Caption="Prefixstripped", Importance = 17)]
        public VarString prefixstrippedVar;

        [CoreVarVal("basenumberstripped", "String", Caption="Basenumberstripped", Importance = 13)]
        public VarString basenumberstrippedVar;

        [CoreVarVal("quantity", "Int32", Caption="Quantity", Importance = 14)]
        public VarInt32 quantityVar;

        [CoreVarVal("unit_price", "Double", Caption="Unit Price", Importance = 17)]
        public VarDouble unit_priceVar;

        [CoreVarVal("linecode", "Int32", Caption="Linecode", Importance = 16)]
        public VarInt32 linecodeVar;

        [CoreVarVal("total_price", "Double", Caption="Total Price", Importance = 17)]
        public VarDouble total_priceVar;

        [CoreVarVal("type", "String", Caption="Type", Importance = 18)]
        public VarString typeVar;

        [CoreVarVal("applied_amount", "Double", Transactional = true, Caption="Applied Amount", Importance = 19)]
        public VarDouble applied_amountVar;

        [CoreVarVal("is_paid", "Boolean", Transactional = true, Caption="Is Paid", Importance = 20)]
        public VarBoolean is_paidVar;

        public creditmemo_det_auto()
        {
            StaticInit();
            the_creditmemo_hed_uidVar = new VarString(this, the_creditmemo_hed_uidAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            orderdateVar = new VarDateTime(this, orderdateAttribute);
            ordernumberVar = new VarString(this, ordernumberAttribute);
            account_full_nameVar = new VarString(this, account_full_nameAttribute);
            account_nameVar = new VarString(this, account_nameAttribute);
            account_numberVar = new VarInt32(this, account_numberAttribute);
            account_uidVar = new VarString(this, account_uidAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            prefixstrippedVar = new VarString(this, prefixstrippedAttribute);
            basenumberstrippedVar = new VarString(this, basenumberstrippedAttribute);
            quantityVar = new VarInt32(this, quantityAttribute);
            unit_priceVar = new VarDouble(this, unit_priceAttribute);
            linecodeVar = new VarInt32(this, linecodeAttribute);
            total_priceVar = new VarDouble(this, total_priceAttribute);
            typeVar = new VarString(this, typeAttribute);
            applied_amountVar = new VarDouble(this, applied_amountAttribute);
            is_paidVar = new VarBoolean(this, is_paidAttribute);
        }

        public override string ClassId
        { get { return "creditmemo_det"; } }

        public String the_creditmemo_hed_uid
        {
            get  { return (String)the_creditmemo_hed_uidVar.Value; }
            set  { the_creditmemo_hed_uidVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public String base_companycontact_uid
        {
            get  { return (String)base_companycontact_uidVar.Value; }
            set  { base_companycontact_uidVar.Value = value; }
        }

        public DateTime orderdate
        {
            get  { return (DateTime)orderdateVar.Value; }
            set  { orderdateVar.Value = value; }
        }

        public String ordernumber
        {
            get  { return (String)ordernumberVar.Value; }
            set  { ordernumberVar.Value = value; }
        }

        public String account_full_name
        {
            get  { return (String)account_full_nameVar.Value; }
            set  { account_full_nameVar.Value = value; }
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

        public String account_uid
        {
            get  { return (String)account_uidVar.Value; }
            set  { account_uidVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public String prefixstripped
        {
            get  { return (String)prefixstrippedVar.Value; }
            set  { prefixstrippedVar.Value = value; }
        }

        public String basenumberstripped
        {
            get  { return (String)basenumberstrippedVar.Value; }
            set  { basenumberstrippedVar.Value = value; }
        }

        public Int32 quantity
        {
            get  { return (Int32)quantityVar.Value; }
            set  { quantityVar.Value = value; }
        }

        public Double unit_price
        {
            get  { return (Double)unit_priceVar.Value; }
            set  { unit_priceVar.Value = value; }
        }

        public Int32 linecode
        {
            get  { return (Int32)linecodeVar.Value; }
            set  { linecodeVar.Value = value; }
        }

        public Double total_price
        {
            get  { return (Double)total_priceVar.Value; }
            set  { total_priceVar.Value = value; }
        }

        public String type
        {
            get  { return (String)typeVar.Value; }
            set  { typeVar.Value = value; }
        }

        public Double applied_amount
        {
            get  { return (Double)applied_amountVar.Value; }
        }

        public virtual void applied_amount_Add(Context context, Double amount)
        {
            applied_amountVar.Value = ((Double)applied_amountVar.Value + amount);
            TransValueUpdate(context, "applied_amount", TransValueUpdateOp.Add, amount);
        }
        public virtual void applied_amount_Subtract(Context context, Double amount)
        {
            applied_amountVar.Value = ((Double)applied_amountVar.Value - amount);
            TransValueUpdate(context, "applied_amount", TransValueUpdateOp.Subtract, amount);
        }
        public Boolean is_paid
        {
            get  { return (Boolean)is_paidVar.Value; }
        }

    }
    public partial class creditmemo_det
    {
        public static creditmemo_det New(Context x)
        {  return (creditmemo_det)x.Item("creditmemo_det"); }

        public static creditmemo_det GetById(Context x, String uid)
        { return (creditmemo_det)x.GetById("creditmemo_det", uid); }

        public static creditmemo_det QtO(Context x, String sql)
        { return (creditmemo_det)x.QtO("creditmemo_det", sql); }
    }
}
