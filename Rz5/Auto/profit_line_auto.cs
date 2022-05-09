using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("profit_line")]
    public partial class profit_line_auto : NewMethod.nObject
    {
        static profit_line_auto()
        {
            Item.AttributesCache(typeof(profit_line_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_profit_line_uid":
                    the_profit_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_company_uid":
                    vendor_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_company_uid":
                    customer_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_ordhed_uid":
                    the_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_type":
                    order_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_number":
                    order_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_name":
                    customer_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_number":
                    part_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_stock":
                    is_stockAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_problem":
                    is_problemAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_cost":
                    unit_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price":
                    unit_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity":
                    quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_cost":
                    total_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price":
                    total_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_date":
                    order_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_volume":
                    total_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buy_type":
                    buy_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_warning":
                    is_warningAttribute = (CoreVarValAttribute)attr;
                    break;
                case "profit":
                    profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_email":
                    customer_emailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_priority_defense":
                    is_priority_defenseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_via":
                    ship_viaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "terms":
                    termsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_commission_paid":
                    is_commission_paidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_domain":
                    email_domainAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_orddet_uid":
                    base_orddet_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_paid":
                    is_paidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_priority_rfq":
                    is_priority_rfqAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_profit_line_uidAttribute;
        static CoreVarValAttribute vendor_company_uidAttribute;
        static CoreVarValAttribute customer_company_uidAttribute;
        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_ordhed_uidAttribute;
        static CoreVarValAttribute order_typeAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute order_numberAttribute;
        static CoreVarValAttribute customer_nameAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute part_numberAttribute;
        static CoreVarValAttribute is_stockAttribute;
        static CoreVarValAttribute is_problemAttribute;
        static CoreVarValAttribute unit_costAttribute;
        static CoreVarValAttribute unit_priceAttribute;
        static CoreVarValAttribute quantityAttribute;
        static CoreVarValAttribute total_costAttribute;
        static CoreVarValAttribute total_priceAttribute;
        static CoreVarValAttribute order_dateAttribute;
        static CoreVarValAttribute total_volumeAttribute;
        static CoreVarValAttribute buy_typeAttribute;
        static CoreVarValAttribute is_warningAttribute;
        static CoreVarValAttribute profitAttribute;
        static CoreVarValAttribute customer_emailAttribute;
        static CoreVarValAttribute is_priority_defenseAttribute;
        static CoreVarValAttribute ship_viaAttribute;
        static CoreVarValAttribute termsAttribute;
        static CoreVarValAttribute is_commission_paidAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute email_domainAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_orddet_uidAttribute;
        static CoreVarValAttribute is_paidAttribute;
        static CoreVarValAttribute is_priority_rfqAttribute;

        [CoreVarVal("the_profit_line_uid", "String", TheFieldLength = 255, Caption="The Profit Line Uid", Importance = 1)]
        public VarString the_profit_line_uidVar;

        [CoreVarVal("vendor_company_uid", "String", TheFieldLength = 255, Caption="Vendor Company Uid", Importance = 2)]
        public VarString vendor_company_uidVar;

        [CoreVarVal("customer_company_uid", "String", TheFieldLength = 255, Caption="Customer Company Uid", Importance = 3)]
        public VarString customer_company_uidVar;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 4)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_ordhed_uid", "String", TheFieldLength = 255, Caption="The Ordhed Uid", Importance = 5)]
        public VarString the_ordhed_uidVar;

        [CoreVarVal("order_type", "String", TheFieldLength = 255, Caption="Order Type", Importance = 6)]
        public VarString order_typeVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 7)]
        public VarString user_nameVar;

        [CoreVarVal("order_number", "String", TheFieldLength = 255, Caption="Order Number", Importance = 8)]
        public VarString order_numberVar;

        [CoreVarVal("customer_name", "String", TheFieldLength = 255, Caption="Customer Name", Importance = 9)]
        public VarString customer_nameVar;

        [CoreVarVal("vendor_name", "String", TheFieldLength = 255, Caption="Vendor Name", Importance = 10)]
        public VarString vendor_nameVar;

        [CoreVarVal("part_number", "String", TheFieldLength = 8000, Caption="Part Number", Importance = 11)]
        public VarString part_numberVar;

        [CoreVarVal("is_stock", "Boolean", Caption="Is Stock", Importance = 12)]
        public VarBoolean is_stockVar;

        [CoreVarVal("is_problem", "Boolean", Caption="Is Problem", Importance = 13)]
        public VarBoolean is_problemVar;

        [CoreVarVal("unit_cost", "Double", Caption="Unit Cost", Importance = 14)]
        public VarDouble unit_costVar;

        [CoreVarVal("unit_price", "Double", Caption="Unit Price", Importance = 15)]
        public VarDouble unit_priceVar;

        [CoreVarVal("quantity", "Int64", Caption="Quantity", Importance = 16)]
        public VarInt64 quantityVar;

        [CoreVarVal("total_cost", "Double", Caption="Total Cost", Importance = 17)]
        public VarDouble total_costVar;

        [CoreVarVal("total_price", "Double", Caption="Total Price", Importance = 18)]
        public VarDouble total_priceVar;

        [CoreVarVal("order_date", "DateTime", Caption="Order Date", Importance = 19)]
        public VarDateTime order_dateVar;

        [CoreVarVal("total_volume", "Double", Caption="Total Volume", Importance = 20)]
        public VarDouble total_volumeVar;

        [CoreVarVal("buy_type", "String", TheFieldLength = 255, Caption="Buy Type", Importance = 21)]
        public VarString buy_typeVar;

        [CoreVarVal("is_warning", "Boolean", Caption="Is Warning", Importance = 22)]
        public VarBoolean is_warningVar;

        [CoreVarVal("profit", "Double", Caption="Profit", Importance = 23)]
        public VarDouble profitVar;

        [CoreVarVal("customer_email", "String", TheFieldLength = 255, Caption="Customer Email", Importance = 24)]
        public VarString customer_emailVar;

        [CoreVarVal("is_priority_defense", "Boolean", Caption="Is Priority Defense", Importance = 25)]
        public VarBoolean is_priority_defenseVar;

        [CoreVarVal("ship_via", "String", TheFieldLength = 255, Caption="Ship Via", Importance = 26)]
        public VarString ship_viaVar;

        [CoreVarVal("terms", "String", TheFieldLength = 255, Caption="Terms", Importance = 27)]
        public VarString termsVar;

        [CoreVarVal("is_commission_paid", "Boolean", Caption="Is Commission Paid", Importance = 28)]
        public VarBoolean is_commission_paidVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption="Abs Type", Importance = 29)]
        public VarString abs_typeVar;

        [CoreVarVal("email_domain", "String", TheFieldLength = 255, Caption="Email Domain", Importance = 30)]
        public VarString email_domainVar;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 255, Caption="Base Companycontact Uid", Importance = 31)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_orddet_uid", "String", TheFieldLength = 255, Caption="Base Orddet Uid", Importance = 32)]
        public VarString base_orddet_uidVar;

        [CoreVarVal("is_paid", "Boolean", Caption="Is Paid", Importance = 33)]
        public VarBoolean is_paidVar;

        [CoreVarVal("is_priority_rfq", "Boolean", Caption="Is Priority Rfq", Importance = 34)]
        public VarBoolean is_priority_rfqVar;

        public profit_line_auto()
        {
            StaticInit();
            the_profit_line_uidVar = new VarString(this, the_profit_line_uidAttribute);
            vendor_company_uidVar = new VarString(this, vendor_company_uidAttribute);
            customer_company_uidVar = new VarString(this, customer_company_uidAttribute);
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_ordhed_uidVar = new VarString(this, the_ordhed_uidAttribute);
            order_typeVar = new VarString(this, order_typeAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            order_numberVar = new VarString(this, order_numberAttribute);
            customer_nameVar = new VarString(this, customer_nameAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            part_numberVar = new VarString(this, part_numberAttribute);
            is_stockVar = new VarBoolean(this, is_stockAttribute);
            is_problemVar = new VarBoolean(this, is_problemAttribute);
            unit_costVar = new VarDouble(this, unit_costAttribute);
            unit_priceVar = new VarDouble(this, unit_priceAttribute);
            quantityVar = new VarInt64(this, quantityAttribute);
            total_costVar = new VarDouble(this, total_costAttribute);
            total_priceVar = new VarDouble(this, total_priceAttribute);
            order_dateVar = new VarDateTime(this, order_dateAttribute);
            total_volumeVar = new VarDouble(this, total_volumeAttribute);
            buy_typeVar = new VarString(this, buy_typeAttribute);
            is_warningVar = new VarBoolean(this, is_warningAttribute);
            profitVar = new VarDouble(this, profitAttribute);
            customer_emailVar = new VarString(this, customer_emailAttribute);
            is_priority_defenseVar = new VarBoolean(this, is_priority_defenseAttribute);
            ship_viaVar = new VarString(this, ship_viaAttribute);
            termsVar = new VarString(this, termsAttribute);
            is_commission_paidVar = new VarBoolean(this, is_commission_paidAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            email_domainVar = new VarString(this, email_domainAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_orddet_uidVar = new VarString(this, base_orddet_uidAttribute);
            is_paidVar = new VarBoolean(this, is_paidAttribute);
            is_priority_rfqVar = new VarBoolean(this, is_priority_rfqAttribute);
        }

        public override string ClassId
        { get { return "profit_line"; } }

        public String the_profit_line_uid
        {
            get  { return (String)the_profit_line_uidVar.Value; }
            set  { the_profit_line_uidVar.Value = value; }
        }

        public String vendor_company_uid
        {
            get  { return (String)vendor_company_uidVar.Value; }
            set  { vendor_company_uidVar.Value = value; }
        }

        public String customer_company_uid
        {
            get  { return (String)customer_company_uidVar.Value; }
            set  { customer_company_uidVar.Value = value; }
        }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String the_ordhed_uid
        {
            get  { return (String)the_ordhed_uidVar.Value; }
            set  { the_ordhed_uidVar.Value = value; }
        }

        public String order_type
        {
            get  { return (String)order_typeVar.Value; }
            set  { order_typeVar.Value = value; }
        }

        public String user_name
        {
            get  { return (String)user_nameVar.Value; }
            set  { user_nameVar.Value = value; }
        }

        public String order_number
        {
            get  { return (String)order_numberVar.Value; }
            set  { order_numberVar.Value = value; }
        }

        public String customer_name
        {
            get  { return (String)customer_nameVar.Value; }
            set  { customer_nameVar.Value = value; }
        }

        public String vendor_name
        {
            get  { return (String)vendor_nameVar.Value; }
            set  { vendor_nameVar.Value = value; }
        }

        public String part_number
        {
            get  { return (String)part_numberVar.Value; }
            set  { part_numberVar.Value = value; }
        }

        public Boolean is_stock
        {
            get  { return (Boolean)is_stockVar.Value; }
            set  { is_stockVar.Value = value; }
        }

        public Boolean is_problem
        {
            get  { return (Boolean)is_problemVar.Value; }
            set  { is_problemVar.Value = value; }
        }

        public Double unit_cost
        {
            get  { return (Double)unit_costVar.Value; }
            set  { unit_costVar.Value = value; }
        }

        public Double unit_price
        {
            get  { return (Double)unit_priceVar.Value; }
            set  { unit_priceVar.Value = value; }
        }

        public Int64 quantity
        {
            get  { return (Int64)quantityVar.Value; }
            set  { quantityVar.Value = value; }
        }

        public Double total_cost
        {
            get  { return (Double)total_costVar.Value; }
            set  { total_costVar.Value = value; }
        }

        public Double total_price
        {
            get  { return (Double)total_priceVar.Value; }
            set  { total_priceVar.Value = value; }
        }

        public DateTime order_date
        {
            get  { return (DateTime)order_dateVar.Value; }
            set  { order_dateVar.Value = value; }
        }

        public Double total_volume
        {
            get  { return (Double)total_volumeVar.Value; }
            set  { total_volumeVar.Value = value; }
        }

        public String buy_type
        {
            get  { return (String)buy_typeVar.Value; }
            set  { buy_typeVar.Value = value; }
        }

        public Boolean is_warning
        {
            get  { return (Boolean)is_warningVar.Value; }
            set  { is_warningVar.Value = value; }
        }

        public Double profit
        {
            get  { return (Double)profitVar.Value; }
            set  { profitVar.Value = value; }
        }

        public String customer_email
        {
            get  { return (String)customer_emailVar.Value; }
            set  { customer_emailVar.Value = value; }
        }

        public Boolean is_priority_defense
        {
            get  { return (Boolean)is_priority_defenseVar.Value; }
            set  { is_priority_defenseVar.Value = value; }
        }

        public String ship_via
        {
            get  { return (String)ship_viaVar.Value; }
            set  { ship_viaVar.Value = value; }
        }

        public String terms
        {
            get  { return (String)termsVar.Value; }
            set  { termsVar.Value = value; }
        }

        public Boolean is_commission_paid
        {
            get  { return (Boolean)is_commission_paidVar.Value; }
            set  { is_commission_paidVar.Value = value; }
        }

        public String abs_type
        {
            get  { return (String)abs_typeVar.Value; }
            set  { abs_typeVar.Value = value; }
        }

        public String email_domain
        {
            get  { return (String)email_domainVar.Value; }
            set  { email_domainVar.Value = value; }
        }

        public String base_companycontact_uid
        {
            get  { return (String)base_companycontact_uidVar.Value; }
            set  { base_companycontact_uidVar.Value = value; }
        }

        public String base_orddet_uid
        {
            get  { return (String)base_orddet_uidVar.Value; }
            set  { base_orddet_uidVar.Value = value; }
        }

        public Boolean is_paid
        {
            get  { return (Boolean)is_paidVar.Value; }
            set  { is_paidVar.Value = value; }
        }

        public Boolean is_priority_rfq
        {
            get  { return (Boolean)is_priority_rfqVar.Value; }
            set  { is_priority_rfqVar.Value = value; }
        }

    }
    public partial class profit_line
    {
        public static profit_line New(Context x)
        {  return (profit_line)x.Item("profit_line"); }

        public static profit_line GetById(Context x, String uid)
        { return (profit_line)x.GetById("profit_line", uid); }

        public static profit_line QtO(Context x, String sql)
        { return (profit_line)x.QtO("profit_line", sql); }
    }
}
