using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("companycredit")]
    public partial class companycredit_auto : NewMethod.nObject
    {
        static companycredit_auto()
        {
            Item.AttributesCache(typeof(companycredit_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }
        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;

                case "base_ordhed_uid":
                    base_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;

                case "ordernumber":
                    ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;

                case "creditamount":
                    creditamountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "applied_to_order":
                    applied_to_orderAttribute = (CoreVarValAttribute)attr;
                    break;

                case "applied_to_order_uid":
                    applied_to_order_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_order_uid":
                    purchase_order_uidAttribute = (CoreVarValAttribute)attr;
                    break;              
                case "internalcomment":
                    internalcommentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_applied":
                    is_appliedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_type":
                    credit_typeAttribute = (CoreVarValAttribute)attr;
                    break;



            }
        }

        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute base_ordhed_uidAttribute;
        static CoreVarValAttribute ordernumberAttribute;
        static CoreVarValAttribute creditamountAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute applied_to_orderAttribute;
        static CoreVarValAttribute applied_to_order_uidAttribute;
        static CoreVarValAttribute purchase_order_uidAttribute;
        static CoreVarValAttribute internalcommentAttribute;
        static CoreVarValAttribute is_appliedAttribute;
        static CoreVarValAttribute credit_typeAttribute;
        






        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 1)]
        public VarString companynameVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 255, Caption = "Company ID", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("base_ordhed_uid", "String", TheFieldLength = 255, Caption = "Ordhed ID", Importance = 3)]
        public VarString base_ordhed_uidVar;

        [CoreVarVal("ordernumber", "String", TheFieldLength = 255, Caption = "From Order", Importance = 4)]
        public VarString ordernumberVar;

        [CoreVarVal("creditamount", "Double", Caption = "Credit Amount", Importance = 5)]
        public VarDouble creditamountVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption = "Description", Importance = 6)]
        public VarString descriptionVar;

        [CoreVarVal("applied_to_order", "String", TheFieldLength = 255, Caption = "Applied to Order", Importance = 7)]
        public VarString applied_to_orderVar;

        [CoreVarVal("applied_to_order_uid", "String", TheFieldLength = 255, Caption = "Applied To Order UID", Importance = 8)]
        public VarString applied_to_order_uidVar;

        [CoreVarVal("purchase_order_uid", "String", TheFieldLength = 255, Caption = "Purchase Order UID", Importance = 9)]
        public VarString purchase_order_uidVar;

        [CoreVarVal("internalcomment", "String", TheFieldLength = 4096, Caption = "Internal Comment", Importance = 10)]
        public VarString internalcommentVar;

        [CoreVarVal("is_applied", "String", TheFieldLength = 255, Caption = "is_applied", Importance = 11)]
        public VarString is_appliedVar;

        [CoreVarVal("credit_type", "String", TheFieldLength = 255, Caption = "credit_type", Importance = 12)]
        public VarString credit_typeVar;


        public companycredit_auto()
        {
            StaticInit();
            companynameVar = new VarString(this, companynameAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            base_ordhed_uidVar = new VarString(this, base_ordhed_uidAttribute);
            ordernumberVar = new VarString(this, ordernumberAttribute);
            creditamountVar = new VarDouble(this, creditamountAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            applied_to_orderVar = new VarString(this, applied_to_orderAttribute);
            applied_to_order_uidVar = new VarString(this, applied_to_order_uidAttribute);
            purchase_order_uidVar = new VarString(this, purchase_order_uidAttribute);
            internalcommentVar = new VarString(this, internalcommentAttribute);
            is_appliedVar = new VarString(this, is_appliedAttribute);
            credit_typeVar = new VarString(this, credit_typeAttribute);


        }


        public override string ClassId
        { get { return "companycredit"; } }

        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }

        public String base_company_uid
        {
            get { return (String)base_company_uidVar.Value; }
            set { base_company_uidVar.Value = value; }
        }

        public String base_ordhed_uid
        {
            get { return (String)base_ordhed_uidVar.Value; }
            set { base_ordhed_uidVar.Value = value; }
        }

        public String ordernumber
        {
            get { return (String)ordernumberVar.Value; }
            set { ordernumberVar.Value = value; }
        }

        public Double creditamount
        {
            get { return (Double)creditamountVar.Value; }
            set { creditamountVar.Value = value; }
        }

        public String description
        {
            get { return (String)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public String applied_to_order
        {
            get { return (String)applied_to_orderVar.Value; }
            set { applied_to_orderVar.Value = value; }
        }

        public String applied_to_order_uid
        {
            get { return (String)applied_to_order_uidVar.Value; }
            set { applied_to_order_uidVar.Value = value; }
        }

        public String purchase_order_uid
        {
            get { return (String)purchase_order_uidVar.Value; }
            set { purchase_order_uidVar.Value = value; }
        }

        public String internalcomment
        {
            get { return (String)internalcommentVar.Value; }
            set { internalcommentVar.Value = value; }
        }

        public String is_applied
        {
            get { return (String)is_appliedVar.Value; }
            set { is_appliedVar.Value = value; }
        }

        public String credit_type
        {
            get { return (String)credit_typeVar.Value; }
            set { credit_typeVar.Value = value; }
        }

        



    }
    public partial class companycredit
    {
        public static companycredit New(Context x)
        { return (companycredit)x.Item("companycredit"); }

        public static companycredit GetById(Context x, String uid)
        { return (companycredit)x.GetById("companycredit", uid); }

        public static companycredit QtO(Context x, String sql)
        { return (companycredit)x.QtO("companycredit", sql); }


    }
}
