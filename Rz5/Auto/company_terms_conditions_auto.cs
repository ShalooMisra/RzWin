using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("company_terms_conditions")]
    public partial class company_terms_conditions_auto : NewMethod.nObject
    {
        static company_terms_conditions_auto()
        {
            Item.AttributesCache(typeof(company_terms_conditions_auto), AttributeCache);
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
                case "company_uid":
                    company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_dc_restriction":
                    has_dc_restrictionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_packaging_restriction":
                    has_packaging_restrictionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_rohs_restriction":
                    has_rohs_restrictionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_broker_restriction":
                    has_broker_restrictionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_coo_restriction":
                    has_coo_restrictionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_testing_restriction":
                    has_testing_restrictionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "requires_traceability":
                    requires_traceabilityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_packaging_restriction_detail":
                    has_packaging_restriction_detailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_dc_restriction_detail":
                    has_dc_restriction_detailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_testing_restriction_detail":
                    has_testing_restriction_detailAttribute = (CoreVarValAttribute)attr;
                    break;

                    


            }
        }

      
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute company_uidAttribute;
        static CoreVarValAttribute has_dc_restrictionAttribute;
        static CoreVarValAttribute has_packaging_restrictionAttribute;
        static CoreVarValAttribute has_rohs_restrictionAttribute;
        static CoreVarValAttribute has_broker_restrictionAttribute;
        static CoreVarValAttribute has_coo_restrictionAttribute;
        static CoreVarValAttribute has_testing_restrictionAttribute;
        static CoreVarValAttribute requires_traceabilityAttribute;
        static CoreVarValAttribute has_packaging_restriction_detailAttribute;
        static CoreVarValAttribute has_dc_restriction_detailAttribute;
        static CoreVarValAttribute has_testing_restriction_detailAttribute;

        


        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 1)]
        public VarString companynameVar;

        [CoreVarVal("company_uid", "String", TheFieldLength = 255, Caption = "Company Uid", Importance = 2)]
        public VarString company_uidVar;

        [CoreVarVal("has_dc_restriction", "Boolean", Caption = "Has Date Code Restriction", Importance = 3)]
        public VarBoolean has_dc_restrictionVar;

        [CoreVarVal("has_packaging_restriction", "Boolean", Caption = "Has Packaging Restriction", Importance = 4)]
        public VarBoolean has_packaging_restrictionVar;

        [CoreVarVal("has_rohs_restriction", "Boolean", Caption = "Has RoHS Restriction", Importance = 5)]
        public VarBoolean has_rohs_restrictionVar;

        [CoreVarVal("has_broker_restriction", "Boolean", Caption = "Has Broker Restriction", Importance = 6)]
        public VarBoolean has_broker_restrictionVar;

        [CoreVarVal("has_coo_restriction", "Boolean", Caption = "Has COO Restriction", Importance = 7)]
        public VarBoolean has_coo_restrictionVar;

        [CoreVarVal("has_testing_restriction", "Boolean", Caption = "Has Testing Restriction", Importance = 8)]
        public VarBoolean has_testing_restrictionVar;

        [CoreVarVal("requires_traceability", "Boolean", Caption = "Requires Traceability", Importance = 9)]
        public VarBoolean requires_traceabilityVar;

        [CoreVarVal("has_packaging_restriction_detail", "String", TheFieldLength = 255, Caption = "has_packaging_restriction_detail", Importance = 10)]
        public VarString has_packaging_restriction_detailVar;

        [CoreVarVal("has_dc_restriction_detail", "String", TheFieldLength = 255, Caption = "has_dc_restriction_detail", Importance = 11)]
        public VarString has_dc_restriction_detailVar;

        [CoreVarVal("has_testing_restriction_detail", "String", TheFieldLength = 255, Caption = "has_testing_restriction_detail", Importance = 12)]
        public VarString has_testing_restriction_detailVar;

        







        public company_terms_conditions_auto()
        {
            StaticInit();          
            companynameVar = new VarString(this, companynameAttribute);
            company_uidVar = new VarString(this, company_uidAttribute);
            has_dc_restrictionVar = new VarBoolean(this, has_dc_restrictionAttribute);
            has_packaging_restrictionVar = new VarBoolean(this, has_packaging_restrictionAttribute);
            has_rohs_restrictionVar = new VarBoolean(this, has_rohs_restrictionAttribute);
            has_broker_restrictionVar = new VarBoolean(this, has_broker_restrictionAttribute);
            has_coo_restrictionVar = new VarBoolean(this, has_coo_restrictionAttribute);
            has_testing_restrictionVar = new VarBoolean(this, has_testing_restrictionAttribute);
            requires_traceabilityVar = new VarBoolean(this, requires_traceabilityAttribute);
            has_packaging_restriction_detailVar = new VarString(this, has_packaging_restriction_detailAttribute);
            has_dc_restriction_detailVar = new VarString(this, has_dc_restriction_detailAttribute);
            has_testing_restriction_detailVar = new VarString(this, has_testing_restriction_detailAttribute);
            

        }


        public override string ClassId
        { get { return "company_terms_conditions"; } }       


        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }


        public String company_uid
        {
            get { return (String)company_uidVar.Value; }
            set { company_uidVar.Value = value; }
        }

        public Boolean has_dc_restriction
        {
            get { return (Boolean)has_dc_restrictionVar.Value; }
            set { has_dc_restrictionVar.Value = value; }
        }

        public Boolean has_packaging_restriction
        {
            get { return (Boolean)has_packaging_restrictionVar.Value; }
            set { has_packaging_restrictionVar.Value = value; }
        }

        public Boolean has_rohs_restriction
        {
            get { return (Boolean)has_rohs_restrictionVar.Value; }
            set { has_rohs_restrictionVar.Value = value; }
        }

        public Boolean has_broker_restriction
        {
            get { return (Boolean)has_broker_restrictionVar.Value; }
            set { has_broker_restrictionVar.Value = value; }
        }

        public Boolean has_coo_restriction
        {
            get { return (Boolean)has_coo_restrictionVar.Value; }
            set { has_coo_restrictionVar.Value = value; }
        }

        public Boolean has_testing_restriction
        {
            get { return (Boolean)has_testing_restrictionVar.Value; }
            set { has_testing_restrictionVar.Value = value; }
        }

        public Boolean requires_traceability
        {
            get { return (Boolean)requires_traceabilityVar.Value; }
            set { requires_traceabilityVar.Value = value; }
        }

        public String has_packaging_restriction_detail
        {
            get { return (String)has_packaging_restriction_detailVar.Value; }
            set { has_packaging_restriction_detailVar.Value = value; }
        }

        public String has_dc_restriction_detail
        {
            get { return (String)has_dc_restriction_detailVar.Value; }
            set { has_dc_restriction_detailVar.Value = value; }
        }

        public String has_testing_restriction_detail
        {
            get { return (String)has_testing_restriction_detailVar.Value; }
            set { has_testing_restriction_detailVar.Value = value; }
        }
        





    }
    public partial class company_terms_conditions
    {
        public static company_terms_conditions New(Context x)
        { return (company_terms_conditions)x.Item("company_terms_conditions"); }

        public static company_terms_conditions GetById(Context x, String uid)
        { return (company_terms_conditions)x.GetById("company_terms_conditions", uid); }

        public static company_terms_conditions QtO(Context x, String sql)
        { return (company_terms_conditions)x.QtO("company_terms_conditions", sql); }
    }
}
