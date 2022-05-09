using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_invoice")]
    public partial class ordhed_invoice_auto : Rz5.ordhed_new
    {
        static ordhed_invoice_auto()
        {
            Item.AttributesCache(typeof(ordhed_invoice_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "is_partial":
                    is_partialAttribute = (CoreVarValAttribute)attr;
                    break;
                case "gross_profit":
                    gross_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "net_profit":
                    net_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_caption":
                    credit_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_amount":
                    credit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_actual":
                    ship_date_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "commission_percent":
                    commission_percentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "override_stock_commission":
                    override_stock_commissionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "invoicetotal":
                    invoicetotalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipped_stock_batch_id":
                    shipped_stock_batch_idAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }

        static CoreVarValAttribute is_partialAttribute;
        static CoreVarValAttribute gross_profitAttribute;
        static CoreVarValAttribute net_profitAttribute;
        static CoreVarValAttribute credit_captionAttribute;
        static CoreVarValAttribute credit_amountAttribute;
        static CoreVarValAttribute ship_date_actualAttribute;
        static CoreVarValAttribute commission_percentAttribute;
        static CoreVarValAttribute override_stock_commissionAttribute;
        static CoreVarValAttribute invoicetotalAttribute;
        static CoreVarValAttribute shipped_stock_batch_idAttribute;


        [CoreVarVal("is_partial", "Boolean", Caption = "Is Partial", Importance = 1)]
        public VarBoolean is_partialVar;

        [CoreVarVal("gross_profit", "Double", Caption = "Gross Profit", Importance = 11)]
        public VarDouble gross_profitVar;

        [CoreVarVal("net_profit", "Double", Caption = "Net Profit", Importance = 12)]
        public VarDouble net_profitVar;

        [CoreVarVal("credit_caption", "String", TheFieldLength = 255, Caption = "Credit Caption", Importance = 17)]
        public VarString credit_captionVar;

        [CoreVarVal("credit_amount", "Double", Caption = "Credit Amount", Importance = 18)]
        public VarDouble credit_amountVar;

        [CoreVarVal("ship_date_actual", "DateTime", Caption = "Ship Date Actual", Importance = 5)]
        public VarDateTime ship_date_actualVar;

        [CoreVarVal("commission_percent", "Double", Caption = "Commission Percent", Importance = 19)]
        public VarDouble commission_percentVar;

        [CoreVarVal("override_stock_commission", "Boolean", Caption = "Override Stock Commission Percent", Importance = 20)]
        public VarBoolean override_stock_commissionVar;

        [CoreVarVal("invoicetotal", "Double", Caption = "Invoice Total", Importance = 21)]
        public VarDouble invoicetotalVar;

        [CoreVarVal("shipped_stock_batch_id", "string", Caption = "shipped_stock_batch_id", Importance = 22)]
        public VarString shipped_stock_batch_idVar;


        public ordhed_invoice_auto()
        {
            StaticInit();
            is_partialVar = new VarBoolean(this, is_partialAttribute);
            gross_profitVar = new VarDouble(this, gross_profitAttribute);
            net_profitVar = new VarDouble(this, net_profitAttribute);
            credit_captionVar = new VarString(this, credit_captionAttribute);
            credit_amountVar = new VarDouble(this, credit_amountAttribute);
            ship_date_actualVar = new VarDateTime(this, ship_date_actualAttribute);
            commission_percentVar = new VarDouble(this, commission_percentAttribute);
            override_stock_commissionVar = new VarBoolean(this, override_stock_commissionAttribute);
            invoicetotalVar = new VarDouble(this, invoicetotalAttribute);
            shipped_stock_batch_idVar = new VarString(this, shipped_stock_batch_idAttribute);



        }

        public override string ClassId
        { get { return "ordhed_invoice"; } }

        public Boolean is_partial
        {
            get { return (Boolean)is_partialVar.Value; }
            set { is_partialVar.Value = value; }
        }

        public Double gross_profit
        {
            get { return (Double)gross_profitVar.Value; }
            set { gross_profitVar.Value = value; }
        }

        public Double net_profit
        {
            get { return (Double)net_profitVar.Value; }
            set { net_profitVar.Value = value; }
        }

        public String credit_caption
        {
            get { return (String)credit_captionVar.Value; }
            set { credit_captionVar.Value = value; }
        }

        public Double credit_amount
        {
            get { return (Double)credit_amountVar.Value; }
            set { credit_amountVar.Value = value; }
        }

        public DateTime ship_date_actual
        {
            get { return (DateTime)ship_date_actualVar.Value; }
            set { ship_date_actualVar.Value = value; }
        }

        public Double commission_percent
        {
            get { return (Double)commission_percentVar.Value; }
            set { commission_percentVar.Value = value; }
        }

        public Boolean override_stock_commission
        {
            get { return (Boolean)override_stock_commissionVar.Value; }
            set { override_stock_commissionVar.Value = value; }
        }

        public double invoicetotal
        {
            get { return (double)invoicetotalVar.Value; }
            set { invoicetotalVar.Value = value; }
        }

        public string shipped_stock_batch_id
        {
            get { return (string)shipped_stock_batch_idVar.Value; }
            set { shipped_stock_batch_idVar.Value = value; }
        }


    }
    public partial class ordhed_invoice
    {
        public static ordhed_invoice New(Context x)
        { return (ordhed_invoice)x.Item("ordhed_invoice"); }

        public static ordhed_invoice GetById(Context x, String uid)
        { return (ordhed_invoice)x.GetById("ordhed_invoice", uid); }

        public static ordhed_invoice QtO(Context x, String sql)
        { return (ordhed_invoice)x.QtO("ordhed_invoice", sql); }
       
    }
}
