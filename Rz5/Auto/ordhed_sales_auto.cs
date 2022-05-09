using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    //KT - 9-29-2014 - added vrma_payment elements below to expose po payments to ordhed_sales total calculations.

    [CoreClass("ordhed_sales")]
    public partial class ordhed_sales_auto : Rz5.ordhed_new
    {
        static ordhed_sales_auto()
        {
            Item.AttributesCache(typeof(ordhed_sales_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "notify_date":
                    notify_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "invoice_created":
                    invoice_createdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_invoice_date":
                    last_invoice_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filled_volume":
                    filled_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unfilled_volume":
                    unfilled_volumeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_complete":
                    ship_completeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "open_balance":
                    open_balanceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_quantity":
                    total_quantityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_quantity_filled":
                    total_quantity_filledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "invoice_info":
                    invoice_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "gross_profit":
                    gross_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "net_profit":
                    net_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "open_line_count":
                    open_line_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_rma_replacement":
                    has_rma_replacementAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_profit_subtractions":
                    total_profit_subtractionsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "status_caption":
                    status_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_caption":
                    credit_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_amount":
                    credit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_to_invoice":
                    credit_to_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vrma_payment":
                    vrma_paymentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rma_loss":
                    rma_lossAttribute = (CoreVarValAttribute)attr;
                    break;
                case "po_payment":
                    po_paymentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_TermsOverride":
                    is_TermsOverrideAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_Credits":
                    total_CreditsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_Charges":
                    total_ChargesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "current_net_profit":
                    current_net_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_line_cost":
                    total_line_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_po_deductions":
                    total_po_deductionsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_stage":
                    validation_stageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_hold_reason":
                    validation_hold_reasonAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_stage_timestamp":
                    validation_stage_timestampAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_stage_agent_id":
                    validation_stage_agent_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_stage_agent":
                    validation_stage_agentAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }

        static CoreVarValAttribute notify_dateAttribute;
        static CoreVarValAttribute invoice_createdAttribute;
        static CoreVarValAttribute last_invoice_dateAttribute;
        static CoreVarValAttribute filled_volumeAttribute;
        static CoreVarValAttribute unfilled_volumeAttribute;
        static CoreVarValAttribute ship_completeAttribute;
        static CoreVarValAttribute open_balanceAttribute;
        static CoreVarValAttribute total_quantityAttribute;
        static CoreVarValAttribute total_quantity_filledAttribute;
        static CoreVarValAttribute invoice_infoAttribute;
        static CoreVarValAttribute gross_profitAttribute;
        static CoreVarValAttribute net_profitAttribute;
        static CoreVarValAttribute open_line_countAttribute;
        static CoreVarValAttribute has_rma_replacementAttribute;
        static CoreVarValAttribute total_profit_subtractionsAttribute;
        static CoreVarValAttribute status_captionAttribute;
        static CoreVarValAttribute credit_captionAttribute;
        static CoreVarValAttribute credit_amountAttribute;
        static CoreVarValAttribute credit_to_invoiceAttribute;
        static CoreVarValAttribute vrma_paymentAttribute;
        static CoreVarValAttribute rma_lossAttribute;
        static CoreVarValAttribute po_paymentAttribute;
        static CoreVarValAttribute is_TermsOverrideAttribute;
        static CoreVarValAttribute total_CreditsAttribute;
        static CoreVarValAttribute total_ChargesAttribute;
        static CoreVarValAttribute current_net_profitAttribute;
        static CoreVarValAttribute total_line_costAttribute;
        static CoreVarValAttribute total_po_deductionsAttribute;
        static CoreVarValAttribute validation_stageAttribute;
        static CoreVarValAttribute validation_hold_reasonAttribute;
        static CoreVarValAttribute validation_stage_timestampAttribute;
        static CoreVarValAttribute validation_stage_agent_idAttribute;
        static CoreVarValAttribute validation_stage_agentAttribute;

        


        [CoreVarVal("notify_date", "DateTime", Caption = "Notify Date", Importance = 1)]
        public VarDateTime notify_dateVar;

        [CoreVarVal("invoice_created", "Boolean", Caption = "Invoice Created", Importance = 2)]
        public VarBoolean invoice_createdVar;

        [CoreVarVal("last_invoice_date", "DateTime", Caption = "Last Invoice Date", Importance = 3)]
        public VarDateTime last_invoice_dateVar;

        [CoreVarVal("filled_volume", "Double", Caption = "Filled Volume", Importance = 4)]
        public VarDouble filled_volumeVar;

        [CoreVarVal("unfilled_volume", "Double", Caption = "Unfilled Volume", Importance = 5)]
        public VarDouble unfilled_volumeVar;

        [CoreVarVal("ship_complete", "Boolean", Caption = "Ship Complete", Importance = 6)]
        public VarBoolean ship_completeVar;

        [CoreVarVal("open_balance", "Double", Caption = "Open Balance", Importance = 7)]
        public VarDouble open_balanceVar;

        [CoreVarVal("total_quantity", "Int32", Caption = "Total Quantity", Importance = 8)]
        public VarInt32 total_quantityVar;

        [CoreVarVal("total_quantity_filled", "Int32", Caption = "Total Quantity Filled", Importance = 9)]
        public VarInt32 total_quantity_filledVar;

        [CoreVarVal("invoice_info", "String", TheFieldLength = 255, Caption = "Invoice Info", Importance = 10)]
        public VarString invoice_infoVar;

        [CoreVarVal("gross_profit", "Double", Caption = "Gross Profit", Importance = 11)]
        public VarDouble gross_profitVar;

        [CoreVarVal("net_profit", "Double", Caption = "Net Profit", Importance = 12)]
        public VarDouble net_profitVar;

        [CoreVarVal("open_line_count", "Int32", Caption = "Open Line Count", Importance = 13)]
        public VarInt32 open_line_countVar;

        [CoreVarVal("has_rma_replacement", "Boolean", Caption = "Has Rma Replacement", Importance = 14)]
        public VarBoolean has_rma_replacementVar;

        [CoreVarVal("total_profit_subtractions", "Double", Caption = "Total Profit Subtractions", Importance = 15)]
        public VarDouble total_profit_subtractionsVar;

        [CoreVarVal("status_caption", "String", TheFieldLength = 255, Caption = "Status Caption", Importance = 16)]
        public VarString status_captionVar;

        [CoreVarVal("credit_caption", "String", TheFieldLength = 255, Caption = "Credit Caption", Importance = 17)]
        public VarString credit_captionVar;

        [CoreVarVal("credit_amount", "Double", Caption = "Credit Amount", Importance = 18)]
        public VarDouble credit_amountVar;

        [CoreVarVal("credit_to_invoice", "String", TheFieldLength = 255, Caption = "Credit To Invoice", Importance = 19)]
        public VarString credit_to_invoiceVar;

        [CoreVarVal("vrma_payment", "Double", Caption = "PO Payment", Importance = 20)]
        public VarDouble vrma_paymentVar;

        [CoreVarVal("rma_loss", "Double", Caption = "rma_loss", Importance = 21)]
        public VarDouble rma_lossVar;

        [CoreVarVal("po_payment", "Double", Caption = "po_payment", Importance = 22)]
        public VarDouble po_paymentVar;

        [CoreVarVal("is_TermsOverride", "Boolean", Caption = "Terms Override", Importance = 23)]
        public VarBoolean is_TermsOverrideVar;

        [CoreVarVal("total_Credits", "Double", Caption = "Total Credits", Importance = 24)]
        public VarDouble total_CreditsVar;

        [CoreVarVal("total_Charges", "Double", Caption = "Total Charges", Importance = 25)]
        public VarDouble total_ChargesVar;

        [CoreVarVal("current_net_profit", "Double", Caption = "Current Net Profit", Importance = 26)]
        public VarDouble current_net_profitVar;

        [CoreVarVal("total_line_cost", "Double", Caption = "Total Line Cost", Importance = 27)]
        public VarDouble total_line_costVar;

        [CoreVarVal("total_po_deductions", "Double", Caption = "Total PO Deductions", Importance = 28)]
        public VarDouble total_po_deductionsVar;

        [CoreVarVal("validation_stage", "String", TheFieldLength = 255, Caption = "Validation Stage", Importance = 29)]
        public VarString validation_stageVar;

        [CoreVarVal("validation_hold_reason", "String", TheFieldLength = 4096, Caption = "Validation Stage", Importance = 30)]
        public VarString validation_hold_reasonVar;

        [CoreVarVal("validation_stage_timestamp", "DateTime", Caption = "Time current validation stage was set", Importance = 31)]
        public VarDateTime validation_stage_timestampVar;

        [CoreVarVal("validation_stage_agent_id", "String", TheFieldLength = 255, Caption = "validation_stage_agent_id", Importance = 32)]
        public VarString validation_stage_agent_idVar;

        [CoreVarVal("validation_stage_agent", "String", TheFieldLength = 255, Caption = "validation_stage_agent", Importance = 33)]
        public VarString validation_stage_agentVar;
        

        public ordhed_sales_auto()
        {
            StaticInit();
            notify_dateVar = new VarDateTime(this, notify_dateAttribute);
            invoice_createdVar = new VarBoolean(this, invoice_createdAttribute);
            last_invoice_dateVar = new VarDateTime(this, last_invoice_dateAttribute);
            filled_volumeVar = new VarDouble(this, filled_volumeAttribute);
            unfilled_volumeVar = new VarDouble(this, unfilled_volumeAttribute);
            ship_completeVar = new VarBoolean(this, ship_completeAttribute);
            open_balanceVar = new VarDouble(this, open_balanceAttribute);
            total_quantityVar = new VarInt32(this, total_quantityAttribute);
            total_quantity_filledVar = new VarInt32(this, total_quantity_filledAttribute);
            invoice_infoVar = new VarString(this, invoice_infoAttribute);
            gross_profitVar = new VarDouble(this, gross_profitAttribute);
            net_profitVar = new VarDouble(this, net_profitAttribute);
            open_line_countVar = new VarInt32(this, open_line_countAttribute);
            has_rma_replacementVar = new VarBoolean(this, has_rma_replacementAttribute);
            total_profit_subtractionsVar = new VarDouble(this, total_profit_subtractionsAttribute);
            status_captionVar = new VarString(this, status_captionAttribute);
            credit_captionVar = new VarString(this, credit_captionAttribute);
            credit_amountVar = new VarDouble(this, credit_amountAttribute);
            credit_to_invoiceVar = new VarString(this, credit_to_invoiceAttribute);
            vrma_paymentVar = new VarDouble(this, vrma_paymentAttribute);
            rma_lossVar = new VarDouble(this, rma_lossAttribute);
            po_paymentVar = new VarDouble(this, po_paymentAttribute);
            is_TermsOverrideVar = new VarBoolean(this, is_TermsOverrideAttribute);
            total_CreditsVar = new VarDouble(this, total_CreditsAttribute);
            total_ChargesVar = new VarDouble(this, total_ChargesAttribute);
            current_net_profitVar = new VarDouble(this, current_net_profitAttribute);
            total_line_costVar = new VarDouble(this, total_line_costAttribute);
            total_po_deductionsVar = new VarDouble(this, total_po_deductionsAttribute);
            validation_stageVar = new VarString(this, validation_stageAttribute);
            validation_hold_reasonVar = new VarString(this, validation_hold_reasonAttribute);
            validation_stage_timestampVar = new VarDateTime(this, validation_stage_timestampAttribute);
            validation_stage_agent_idVar = new VarString(this, validation_stage_agent_idAttribute);
            validation_stage_agentVar = new VarString(this, validation_stage_agentAttribute);
            

        }

        public override string ClassId
        { get { return "ordhed_sales"; } }

        public DateTime notify_date
        {
            get { return (DateTime)notify_dateVar.Value; }
            set { notify_dateVar.Value = value; }
        }

        public Boolean invoice_created
        {
            get { return (Boolean)invoice_createdVar.Value; }
            set { invoice_createdVar.Value = value; }
        }

        public DateTime last_invoice_date
        {
            get { return (DateTime)last_invoice_dateVar.Value; }
            set { last_invoice_dateVar.Value = value; }
        }

        public Double filled_volume
        {
            get { return (Double)filled_volumeVar.Value; }
            set { filled_volumeVar.Value = value; }
        }

        public Double unfilled_volume
        {
            get { return (Double)unfilled_volumeVar.Value; }
            set { unfilled_volumeVar.Value = value; }
        }

        public Boolean ship_complete
        {
            get { return (Boolean)ship_completeVar.Value; }
            set { ship_completeVar.Value = value; }
        }

        public Double open_balance
        {
            get { return (Double)open_balanceVar.Value; }
            set { open_balanceVar.Value = value; }
        }

        public Int32 total_quantity
        {
            get { return (Int32)total_quantityVar.Value; }
            set { total_quantityVar.Value = value; }
        }

        public Int32 total_quantity_filled
        {
            get { return (Int32)total_quantity_filledVar.Value; }
            set { total_quantity_filledVar.Value = value; }
        }

        public String invoice_info
        {
            get { return (String)invoice_infoVar.Value; }
            set { invoice_infoVar.Value = value; }
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

        public Int32 open_line_count
        {
            get { return (Int32)open_line_countVar.Value; }
            set { open_line_countVar.Value = value; }
        }

        public Boolean has_rma_replacement
        {
            get { return (Boolean)has_rma_replacementVar.Value; }
            set { has_rma_replacementVar.Value = value; }
        }

        public Double total_profit_subtractions
        {
            get { return (Double)total_profit_subtractionsVar.Value; }
            set { total_profit_subtractionsVar.Value = value; }
        }

        public String status_caption
        {
            get { return (String)status_captionVar.Value; }
            set { status_captionVar.Value = value; }
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

        public String credit_to_invoice
        {
            get { return (String)credit_to_invoiceVar.Value; }
            set { credit_to_invoiceVar.Value = value; }
        }
        public Double vrma_payment
        {
            get { return (Double)vrma_paymentVar.Value; }
            set { vrma_paymentVar.Value = value; }
        }

        public Double rma_loss
        {
            get { return (Double)rma_lossVar.Value; }
            set { rma_lossVar.Value = value; }
        }
        public Double po_payment
        {
            get { return (Double)po_paymentVar.Value; }
            set { po_paymentVar.Value = value; }
        }

        public Boolean is_TermsOverride
        {
            get { return (Boolean)is_TermsOverrideVar.Value; }
            set { is_TermsOverrideVar.Value = value; }
        }

        public Double total_Credits
        {
            get { return (Double)total_CreditsVar.Value; }
            set { total_CreditsVar.Value = value; }
        }

        public Double total_Charges
        {
            get { return (Double)total_ChargesVar.Value; }
            set { total_ChargesVar.Value = value; }
        }

        public Double current_net_profit
        {
            get { return (Double)current_net_profitVar.Value; }
            set { current_net_profitVar.Value = value; }
        }

        public Double total_line_cost
        {
            get { return (Double)total_line_costVar.Value; }
            set { total_line_costVar.Value = value; }
        }

        public Double total_po_deductions
        {
            get { return (Double)total_po_deductionsVar.Value; }
            set { total_po_deductionsVar.Value = value; }
        }

        public string validation_stage
        {
            get { return (string)validation_stageVar.Value; }
            set { validation_stageVar.Value = value; }
        }

        public string validation_hold_reason
        {
            get { return (string)validation_hold_reasonVar.Value; }
            set { validation_hold_reasonVar.Value = value; }
        }

        public DateTime validation_stage_timestamp
        {
            get { return (DateTime)validation_stage_timestampVar.Value; }
            set { validation_stage_timestampVar.Value = value; }
        }

        public String validation_stage_agent_id
        {
            get { return (String)validation_stage_agent_idVar.Value; }
            set { validation_stage_agent_idVar.Value = value; }
        }

        public String validation_stage_agent
        {
            get { return (String)validation_stage_agentVar.Value; }
            set { validation_stage_agentVar.Value = value; }
        }
        



    }
    public partial class ordhed_sales
    {
        public static ordhed_sales New(Context x)
        { return (ordhed_sales)x.Item("ordhed_sales"); }

        public static ordhed_sales GetById(Context x, String uid)
        { return (ordhed_sales)x.GetById("ordhed_sales", uid); }

        public static ordhed_sales QtO(Context x, String sql)
        { return (ordhed_sales)x.QtO("ordhed_sales", sql); }

        
    }
}
