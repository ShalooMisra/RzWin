using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_purchase")]
    public partial class ordhed_purchase_auto : Rz5.ordhed_new
    {
        static ordhed_purchase_auto()
        {
            Item.AttributesCache(typeof(ordhed_purchase_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "shipped_complete":
                    shipped_completeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_quantity":
                    total_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipped_quantity":
                    shipped_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_sales_order_uid":
                    the_sales_order_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_consignment_code_uid":
                    the_consignment_code_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_consign":
                    is_consignAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lot_number":
                    lot_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_consumption":
                    is_consumptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payment_total":
                    payment_totalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_bill":
                    is_billAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_actual":
                    receive_date_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_credit":
                    is_creditAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_credit_card":
                    is_credit_cardAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_account_full_name":
                    cc_account_full_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_account_name":
                    cc_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_account_number":
                    cc_account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_account_uid":
                    cc_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_amount":
                    credit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "post_to_portal":
                    post_to_portalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "first_customer":
                    first_customerAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute shipped_completeAttribute;
        static CoreVarValAttribute total_quantityAttribute;
        static CoreVarValAttribute shipped_quantityAttribute;
        static CoreVarValAttribute the_sales_order_uidAttribute;
        static CoreVarValAttribute the_consignment_code_uidAttribute;
        static CoreVarValAttribute is_consignAttribute;
        static CoreVarValAttribute lot_numberAttribute;
        static CoreVarValAttribute is_consumptionAttribute;
        static CoreVarValAttribute payment_totalAttribute;
        static CoreVarValAttribute is_billAttribute;
        static CoreVarValAttribute receive_date_actualAttribute;
        static CoreVarValAttribute is_creditAttribute;
        static CoreVarValAttribute is_credit_cardAttribute;
        static CoreVarValAttribute cc_account_full_nameAttribute;
        static CoreVarValAttribute cc_account_nameAttribute;
        static CoreVarValAttribute cc_account_numberAttribute;
        static CoreVarValAttribute cc_account_uidAttribute;
        static CoreVarValAttribute credit_amountAttribute;
        static CoreVarValAttribute post_to_portalAttribute;
        static CoreVarValAttribute first_customerAttribute;



        

        [CoreVarVal("shipped_complete", "Boolean", Caption="Shipped Complete", Importance = 1)]
        public VarBoolean shipped_completeVar;

        [CoreVarVal("total_quantity", "Int32", Caption="Total Quantity", Importance = 2)]
        public VarInt32 total_quantityVar;

        [CoreVarVal("shipped_quantity", "Int32", Caption="Shipped Quantity", Importance = 3)]
        public VarInt32 shipped_quantityVar;

        [CoreVarVal("the_sales_order_uid", "String", TheFieldLength = 255, Caption="The Sales Order Uid", Importance = 4)]
        public VarString the_sales_order_uidVar;

        [CoreVarVal("the_consignment_code_uid", "String", TheFieldLength = 255, Caption="The Consignment Code Uid", Importance = 5)]
        public VarString the_consignment_code_uidVar;

        [CoreVarVal("is_consign", "Boolean", Caption="Is Consign", Importance = 6)]
        public VarBoolean is_consignVar;

        [CoreVarVal("lot_number", "String", TheFieldLength = 255, Caption="Lot Number", Importance = 7)]
        public VarString lot_numberVar;

        [CoreVarVal("is_consumption", "Boolean", Caption="Is Consumption", Importance = 7)]
        public VarBoolean is_consumptionVar;

        [CoreVarVal("payment_total", "Double", Caption="Payment Total", Importance = 8)]
        public VarDouble payment_totalVar;

        [CoreVarVal("is_bill", "Boolean", Caption="Is Bill", Importance = 9)]
        public VarBoolean is_billVar;

        [CoreVarVal("receive_date_actual", "DateTime", Caption="Receive Date Actual", Importance = 10)]
        public VarDateTime receive_date_actualVar;

        [CoreVarVal("is_credit", "Boolean", Caption="Is Credit", Importance = 11)]
        public VarBoolean is_creditVar;

        [CoreVarVal("is_credit_card", "Boolean", Caption="Is Credit Card", Importance = 12)]
        public VarBoolean is_credit_cardVar;

        [CoreVarVal("cc_account_full_name", "String", Caption="Cc Account Full Name", Importance = 13)]
        public VarString cc_account_full_nameVar;

        [CoreVarVal("cc_account_name", "String", Caption="Cc Account Name", Importance = 14)]
        public VarString cc_account_nameVar;

        [CoreVarVal("cc_account_number", "Int32", Caption="Cc Account Number", Importance = 15)]
        public VarInt32 cc_account_numberVar;

        [CoreVarVal("cc_account_uid", "String", Caption="Cc Account Uid", Importance = 16)]
        public VarString cc_account_uidVar;

         [CoreVarVal("credit_amount", "Double", Caption = "credit_amount", Importance = 17)]
        public VarDouble credit_amountVar;

        [CoreVarVal("post_to_portal", "Boolean", Caption = "Post to Portal", Importance = 18)]
        public VarBoolean post_to_portalVar;

        [CoreVarVal("first_customer", "String", Caption = "First Customer based on PO line items.", Importance = 19)]
        public VarString first_customerVar;


        
        public ordhed_purchase_auto()
        {
            StaticInit();
            shipped_completeVar = new VarBoolean(this, shipped_completeAttribute);
            total_quantityVar = new VarInt32(this, total_quantityAttribute);
            shipped_quantityVar = new VarInt32(this, shipped_quantityAttribute);
            the_sales_order_uidVar = new VarString(this, the_sales_order_uidAttribute);
            the_consignment_code_uidVar = new VarString(this, the_consignment_code_uidAttribute);
            is_consignVar = new VarBoolean(this, is_consignAttribute);
            lot_numberVar = new VarString(this, lot_numberAttribute);
            is_consumptionVar = new VarBoolean(this, is_consumptionAttribute);
            payment_totalVar = new VarDouble(this, payment_totalAttribute);
            is_billVar = new VarBoolean(this, is_billAttribute);
            receive_date_actualVar = new VarDateTime(this, receive_date_actualAttribute);
            is_creditVar = new VarBoolean(this, is_creditAttribute);
            is_credit_cardVar = new VarBoolean(this, is_credit_cardAttribute);
            cc_account_full_nameVar = new VarString(this, cc_account_full_nameAttribute);
            cc_account_nameVar = new VarString(this, cc_account_nameAttribute);
            cc_account_numberVar = new VarInt32(this, cc_account_numberAttribute);
            cc_account_uidVar = new VarString(this, cc_account_uidAttribute);
            credit_amountVar = new VarDouble(this, credit_amountAttribute);
            post_to_portalVar = new VarBoolean(this, post_to_portalAttribute);
            first_customerVar = new VarString(this, first_customerAttribute);

            
        }

        public override string ClassId
        { get { return "ordhed_purchase"; } }

        public Boolean shipped_complete
        {
            get  { return (Boolean)shipped_completeVar.Value; }
            set  { shipped_completeVar.Value = value; }
        }

        public Int32 total_quantity
        {
            get  { return (Int32)total_quantityVar.Value; }
            set  { total_quantityVar.Value = value; }
        }

        public Int32 shipped_quantity
        {
            get  { return (Int32)shipped_quantityVar.Value; }
            set  { shipped_quantityVar.Value = value; }
        }

        public String the_sales_order_uid
        {
            get  { return (String)the_sales_order_uidVar.Value; }
            set  { the_sales_order_uidVar.Value = value; }
        }

        public String the_consignment_code_uid
        {
            get  { return (String)the_consignment_code_uidVar.Value; }
            set  { the_consignment_code_uidVar.Value = value; }
        }

        public Boolean is_consign
        {
            get  { return (Boolean)is_consignVar.Value; }
            set  { is_consignVar.Value = value; }
        }

        public String lot_number
        {
            get  { return (String)lot_numberVar.Value; }
            set  { lot_numberVar.Value = value; }
        }

        public Boolean is_consumption
        {
            get  { return (Boolean)is_consumptionVar.Value; }
            set  { is_consumptionVar.Value = value; }
        }

        public Double payment_total
        {
            get  { return (Double)payment_totalVar.Value; }
            set  { payment_totalVar.Value = value; }
        }

        public Boolean is_bill
        {
            get  { return (Boolean)is_billVar.Value; }
            set  { is_billVar.Value = value; }
        }

        public DateTime receive_date_actual
        {
            get  { return (DateTime)receive_date_actualVar.Value; }
            set  { receive_date_actualVar.Value = value; }
        }

        public Boolean is_credit
        {
            get  { return (Boolean)is_creditVar.Value; }
            set  { is_creditVar.Value = value; }
        }

        public Boolean is_credit_card
        {
            get  { return (Boolean)is_credit_cardVar.Value; }
            set  { is_credit_cardVar.Value = value; }
        }

        public String cc_account_full_name
        {
            get  { return (String)cc_account_full_nameVar.Value; }
            set  { cc_account_full_nameVar.Value = value; }
        }

        public String cc_account_name
        {
            get  { return (String)cc_account_nameVar.Value; }
            set  { cc_account_nameVar.Value = value; }
        }

        public Int32 cc_account_number
        {
            get  { return (Int32)cc_account_numberVar.Value; }
            set  { cc_account_numberVar.Value = value; }
        }

        public String cc_account_uid
        {
            get  { return (String)cc_account_uidVar.Value; }
            set  { cc_account_uidVar.Value = value; }
        }

        public Double credit_amount
        {
            get { return (Double)credit_amountVar.Value; }
            set { credit_amountVar.Value = value; }
        }
        public Boolean post_to_portal
        {
            get { return (Boolean)post_to_portalVar.Value; }
            set { post_to_portalVar.Value = value; }
        }


        public String first_customer
        {
            get { return (String)first_customerVar.Value; }
            set { first_customerVar.Value = value; }
        }


        


    }
    public partial class ordhed_purchase
    {
        public static ordhed_purchase New(Context x)
        {  return (ordhed_purchase)x.Item("ordhed_purchase"); }

        public static ordhed_purchase GetById(Context x, String uid)
        { return (ordhed_purchase)x.GetById("ordhed_purchase", uid); }

        public static ordhed_purchase QtO(Context x, String sql)
        { return (ordhed_purchase)x.QtO("ordhed_purchase", sql); }
    }
}
