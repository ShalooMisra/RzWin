using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("profit_deduction")]
    public partial class profit_deduction_auto : NewMethod.nObject
    {
        static profit_deduction_auto()
        {
            Item.AttributesCache(typeof(profit_deduction_auto), AttributeCache);
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
                case "amount":
                    amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_line_uid":
                    the_orddet_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_order_uid":
                    purchase_order_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_on_po":
                    include_on_poAttribute = (CoreVarValAttribute)attr;
                    break;
                case "created_by":
                    created_byAttribute = (CoreVarValAttribute)attr;
                    break;
                case "modified_by":
                    modified_byAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_sales":
                    linecode_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_purchase":
                    linecode_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sales_order_uid":
                    sales_order_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_payroll_deduction":
                    is_payroll_deductionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_uid":
                    vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_purchase":
                    ordernumber_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exclude_from_profit_calc":
                    exclude_from_profit_calcAttribute = (CoreVarValAttribute)attr;
                    break;
                case "payroll_deduction_date":
                    payroll_deduction_dateAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute amountAttribute;
        static CoreVarValAttribute the_orddet_line_uidAttribute;
        static CoreVarValAttribute purchase_order_uidAttribute;
        static CoreVarValAttribute include_on_poAttribute;
        static CoreVarValAttribute created_byAttribute;
        static CoreVarValAttribute modified_byAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute linecode_salesAttribute;
        static CoreVarValAttribute linecode_purchaseAttribute;
        static CoreVarValAttribute sales_order_uidAttribute;
        static CoreVarValAttribute is_payroll_deductionAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute vendor_uidAttribute;
        static CoreVarValAttribute ordernumber_purchaseAttribute;
        static CoreVarValAttribute exclude_from_profit_calcAttribute;
        static CoreVarValAttribute payroll_deduction_dateAttribute;




        [CoreVarVal("name", "String", TheFieldLength = 255, Caption = "Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("amount", "Double", Caption = "Amount", Importance = 2)]
        public VarDouble amountVar;

        [CoreVarVal("the_orddet_line_uid", "String", TheFieldLength = 255, Caption = "The Orddet Line Uid", Importance = 3)]
        public VarString the_orddet_line_uidVar;

        [CoreVarVal("purchase_order_uid", "String", TheFieldLength = 255, Caption = "Purchase Order Uid", Importance = 1)]
        public VarString purchase_order_uidVar;

        [CoreVarVal("include_on_po", "Boolean", Caption = "Include On Po", Importance = 2)]
        public VarBoolean include_on_poVar;

        [CoreVarVal("created_by", "String", TheFieldLength = 255, Caption = "Created by", Importance = 4)]
        public VarString created_byVar;

        [CoreVarVal("modified_by", "String", TheFieldLength = 255, Caption = "Modified by", Importance = 5)]
        public VarString modified_byVar;

        [CoreVarVal("description", "String", TheFieldLength = 4096, Caption = "Description", Importance = 6)]
        public VarString descriptionVar;

        [CoreVarVal("linecode_sales", "Int32", Caption = "Linecode Sales", Importance = 7)]
        public VarInt32 linecode_salesVar;

        [CoreVarVal("linecode_purchase", "Int32", Caption = "Linecode Purchase", Importance = 8)]
        public VarInt32 linecode_purchaseVar;

        [CoreVarVal("sales_order_uid", "String", TheFieldLength = 255, Caption = "Sales Order Uid", Importance = 9)]
        public VarString sales_order_uidVar;

        [CoreVarVal("is_payroll_deduction", "Boolean", Caption = "Payroll Deduction", Importance = 10)]
        public VarBoolean is_payroll_deductionVar;

        [CoreVarVal("vendor_name", "String", TheFieldLength = 255, Caption = "vendor_name", Importance = 11)]
        public VarString vendor_nameVar;

        [CoreVarVal("vendor_uid", "String", TheFieldLength = 255, Caption = "vendor_uid", Importance = 12)]
        public VarString vendor_uidVar;

        [CoreVarVal("ordernumber_purchase", "String", TheFieldLength = 255, Caption = "ordernumber_purchase", Importance = 13)]
        public VarString ordernumber_purchaseVar;

        [CoreVarVal("exclude_from_profit_calc", "Boolean", Caption = "Exclude from profit calculation", Importance = 14)]
        public VarBoolean exclude_from_profit_calcVar;

        [CoreVarVal("payroll_deduction_date", "DateTime", Caption = "Date Payroll Deduction was Added", Importance = 15)]
        public VarDateTime payroll_deduction_dateVar;

      

        public profit_deduction_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            amountVar = new VarDouble(this, amountAttribute);
            the_orddet_line_uidVar = new VarString(this, the_orddet_line_uidAttribute);
            purchase_order_uidVar = new VarString(this, purchase_order_uidAttribute);
            include_on_poVar = new VarBoolean(this, include_on_poAttribute);
            created_byVar = new VarString(this, created_byAttribute);
            modified_byVar = new VarString(this, modified_byAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            linecode_salesVar = new VarInt32(this, linecode_salesAttribute);
            linecode_purchaseVar = new VarInt32(this, linecode_purchaseAttribute);
            sales_order_uidVar = new VarString(this, sales_order_uidAttribute);
            is_payroll_deductionVar = new VarBoolean(this, is_payroll_deductionAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            vendor_uidVar = new VarString(this, vendor_uidAttribute);
            ordernumber_purchaseVar = new VarString(this, ordernumber_purchaseAttribute);
            exclude_from_profit_calcVar = new VarBoolean(this, exclude_from_profit_calcAttribute);
            payroll_deduction_dateVar = new VarDateTime(this, payroll_deduction_dateAttribute);

        }

        public override string ClassId
        { get { return "profit_deduction"; } }

        public String name
        {
            get { return (String)nameVar.Value; }
            set { nameVar.Value = value; }
        }

        public Double amount
        {
            get { return (Double)amountVar.Value; }
            set { amountVar.Value = value; }
        }

        public String the_orddet_line_uid
        {
            get { return (String)the_orddet_line_uidVar.Value; }
            set { the_orddet_line_uidVar.Value = value; }
        }

        public String purchase_order_uid
        {
            get { return (String)purchase_order_uidVar.Value; }
            set { purchase_order_uidVar.Value = value; }
        }

        public Boolean include_on_po
        {
            get { return (Boolean)include_on_poVar.Value; }
            set { include_on_poVar.Value = value; }
        }

        public String created_by
        {
            get { return (String)created_byVar.Value; }
            set { created_byVar.Value = value; }
        }

        public String modified_by
        {
            get { return (String)modified_byVar.Value; }
            set { modified_byVar.Value = value; }
        }

        public String description
        {
            get { return (String)descriptionVar.Value; }
            set { descriptionVar.Value = value; }
        }

        public Int32 linecode_sales
        {
            get { return (Int32)linecode_salesVar.Value; }
            set { linecode_salesVar.Value = value; }
        }

        public Int32 linecode_purchase
        {
            get { return (Int32)linecode_purchaseVar.Value; }
            set { linecode_purchaseVar.Value = value; }
        }

        public String sales_order_uid
        {
            get { return (String)sales_order_uidVar.Value; }
            set { sales_order_uidVar.Value = value; }
        }

        public Boolean is_payroll_deduction
        {
            get { return (Boolean)is_payroll_deductionVar.Value; }
            set { is_payroll_deductionVar.Value = value; }
        }

        public String vendor_name
        {
            get { return (String)vendor_nameVar.Value; }
            set { vendor_nameVar.Value = value; }
        }

        public String vendor_uid
        {
            get { return (String)vendor_uidVar.Value; }
            set { vendor_uidVar.Value = value; }
        }

        public String ordernumber_purchase
        {
            get { return (String)ordernumber_purchaseVar.Value; }
            set { ordernumber_purchaseVar.Value = value; }
        }

        public Boolean exclude_from_profit_calc
        {
            get { return (Boolean)exclude_from_profit_calcVar.Value; }
            set { exclude_from_profit_calcVar.Value = value; }
        }

        public DateTime payroll_deduction_date
        {
            get { return (DateTime)payroll_deduction_dateVar.Value; }
            set { payroll_deduction_dateVar.Value = value; }
        }

        

    }
    public partial class profit_deduction
    {
        public static profit_deduction New(Context x)
        { return (profit_deduction)x.Item("profit_deduction"); }

        public static profit_deduction GetById(Context x, String uid)
        { return (profit_deduction)x.GetById("profit_deduction", uid); }

        public static profit_deduction QtO(Context x, String sql)
        { return (profit_deduction)x.QtO("profit_deduction", sql); }

        public static profit_deduction GetByName(Context x, String name, String extraSql = "")
        { return (profit_deduction)x.GetByName("profit_deduction", name, extraSql); }
    }
}
