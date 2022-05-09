using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("orddet_line")]
    public partial class orddet_line_auto : Rz5.orddet
    {
        static orddet_line_auto()
        {
            Item.AttributesCache(typeof(orddet_line_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "unit_price":
                    unit_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_cost":
                    unit_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mfg_certifications":
                    mfg_certificationsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_cofc":
                    has_cofcAttribute = (CoreVarValAttribute)attr;
                    break;
                case "assemblyname":
                    assemblynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "warranty_period":
                    warranty_periodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tracking_invoice":
                    tracking_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tracking_purchase":
                    tracking_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tracking_rma":
                    tracking_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tracking_vendrma":
                    tracking_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tracking_service_in":
                    tracking_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tracking_service_out":
                    tracking_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_invoice":
                    shipvia_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_purchase":
                    shipvia_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_rma":
                    shipvia_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_vendrma":
                    shipvia_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_service_out":
                    shipvia_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_service_in":
                    shipvia_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount_invoice":
                    shippingaccount_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount_purchase":
                    shippingaccount_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount_rma":
                    shippingaccount_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount_vendrma":
                    shippingaccount_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount_service_out":
                    shippingaccount_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shippingaccount_service_in":
                    shippingaccount_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_uid":
                    customer_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_name":
                    customer_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_contact_uid":
                    customer_contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_contact_name":
                    customer_contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_uid":
                    vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_name":
                    vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_contact_uid":
                    vendor_contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_contact_name":
                    vendor_contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_vendor_uid":
                    service_vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_vendor_name":
                    service_vendor_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_vendor_contact_uid":
                    service_vendor_contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_vendor_contact_name":
                    service_vendor_contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_fee_invoice":
                    shipping_fee_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_fee_purchase":
                    shipping_fee_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_fee_rma":
                    shipping_fee_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_fee_vendrma":
                    shipping_fee_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_fee_service_out":
                    shipping_fee_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipping_fee_service_in":
                    shipping_fee_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_invoice":
                    charge1_fee_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_invoice_caption":
                    charge1_fee_invoice_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_purchase":
                    charge1_fee_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_purchase_caption":
                    charge1_fee_purchase_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_rma":
                    charge1_fee_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_rma_caption":
                    charge1_fee_rma_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_vendrma":
                    charge1_fee_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_vendrma_caption":
                    charge1_fee_vendrma_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_service_out":
                    charge1_fee_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_service_out_caption":
                    charge1_fee_service_out_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_service_in":
                    charge1_fee_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge1_fee_service_in_caption":
                    charge1_fee_service_in_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_invoice":
                    charge2_fee_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_invoice_caption":
                    charge2_fee_invoice_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_purchase":
                    charge2_fee_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_purchase_caption":
                    charge2_fee_purchase_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_rma":
                    charge2_fee_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_rma_caption":
                    charge2_fee_rma_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_vendrma":
                    charge2_fee_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_vendrma_caption":
                    charge2_fee_vendrma_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_service_out":
                    charge2_fee_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_service_out_caption":
                    charge2_fee_service_out_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_service_in":
                    charge2_fee_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge2_fee_service_in_caption":
                    charge2_fee_service_in_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "seller_uid":
                    seller_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "seller_name":
                    seller_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyer_uid":
                    buyer_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "buyer_name":
                    buyer_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_sales":
                    orderid_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_purchase":
                    orderid_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_invoice":
                    orderid_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_rma":
                    orderid_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_vendrma":
                    orderid_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_service":
                    orderid_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_sales":
                    linecode_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_purchase":
                    linecode_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_invoice":
                    linecode_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_rma":
                    linecode_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_vendrma":
                    linecode_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate_sales":
                    orderdate_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate_purchase":
                    orderdate_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate_invoice":
                    orderdate_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate_rma":
                    orderdate_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate_vendrma":
                    orderdate_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate_service":
                    orderdate_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qcid_purchase":
                    qcid_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qcid_invoice":
                    qcid_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qcid_rma":
                    qcid_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qcid_vendrma":
                    qcid_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qcid_service_out":
                    qcid_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qcid_service_in":
                    qcid_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_due":
                    receive_date_dueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_actual":
                    receive_date_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_due":
                    ship_date_dueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_actual":
                    ship_date_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_agent_uid":
                    receive_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_agent_name":
                    receive_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_agent_uid":
                    ship_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_agent_name":
                    ship_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_note":
                    ship_noteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_note":
                    receive_noteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price":
                    total_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_cost":
                    total_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "gross_profit":
                    gross_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "net_profit":
                    net_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_date_service":
                    paid_date_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_date_purchase":
                    paid_date_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_amount_service":
                    paid_amount_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_amount_purchase":
                    paid_amount_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_date_invoice":
                    paid_date_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_amount_invoice":
                    paid_amount_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_sales":
                    ordernumber_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_purchase":
                    ordernumber_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_service":
                    ordernumber_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_rma":
                    ordernumber_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_vendrma":
                    ordernumber_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_sales":
                    notes_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_purchase":
                    notes_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_rma":
                    notes_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes_vendrma":
                    notes_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_location":
                    receive_locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_packed":
                    quantity_packedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderid_quote":
                    orderid_quoteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_quote":
                    ordernumber_quoteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quote_line_uid":
                    quote_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_invoice":
                    ordernumber_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_shipped":
                    was_shippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_received":
                    was_receivedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_service_out":
                    was_service_outAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_service_in":
                    was_service_inAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_rma":
                    was_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_vendrma":
                    was_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_rma_received":
                    was_rma_receivedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_vendrma_shipped":
                    was_vendrma_shippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stocktype_receive":
                    stocktype_receiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid_sales":
                    legacyid_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid_purchase":
                    legacyid_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid_service":
                    legacyid_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid_invoice":
                    legacyid_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid_rma":
                    legacyid_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid_vendrma":
                    legacyid_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_purchase":
                    was_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_invoice":
                    was_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_unpacked":
                    quantity_unpackedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_packed_service":
                    quantity_packed_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_unpacked_service":
                    quantity_unpacked_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_packed_vendrma":
                    quantity_packed_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quantity_unpacked_rma":
                    quantity_unpacked_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "linecode_service":
                    linecode_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_vendrma":
                    unit_price_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_vendrma":
                    total_price_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_rma":
                    unit_price_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_rma":
                    total_price_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "put_away":
                    put_awayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "put_away_date":
                    put_away_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "put_away_user":
                    put_away_userAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_cost":
                    service_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_leadtime":
                    service_leadtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_rma_replacement":
                    is_rma_replacementAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_deduction":
                    total_deductionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendrma_will_refund":
                    vendrma_will_refundAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rma_subtraction":
                    rma_subtractionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_service_due":
                    ship_date_service_dueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_service_actual":
                    ship_date_service_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_vendrma_due":
                    ship_date_vendrma_dueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_vendrma_actual":
                    ship_date_vendrma_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_service_due":
                    receive_date_service_dueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_service_actual":
                    receive_date_service_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_rma_due":
                    receive_date_rma_dueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_rma_actual":
                    receive_date_rma_actualAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_date_next":
                    ship_date_nextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_date_next":
                    receive_date_nextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_next":
                    shipvia_nextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "shipvia_receive_next":
                    shipvia_receive_nextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ship_to_next":
                    ship_to_nextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "receive_from_next":
                    receive_from_nextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "drop_ship":
                    drop_shipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "drop_ship_comments":
                    drop_ship_commentsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "internal_customer":
                    internal_customerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_group_id":
                    line_group_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rohs_info_vendor":
                    rohs_info_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_dock_date":
                    customer_dock_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "status_caption":
                    status_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecode_purchase":
                    datecode_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "inventory_link_uid":
                    inventory_link_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "inventory_link_caption":
                    inventory_link_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "po_option_number":
                    po_option_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "po_option":
                    po_optionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchased_as_other":
                    purchased_as_otherAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchased_as_number":
                    purchased_as_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "part_number_stripped":
                    part_number_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchased_as_stripped":
                    purchased_as_strippedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_agent_uid":
                    service_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_agent_name":
                    service_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge_service_to_customer":
                    charge_service_to_customerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_sent_purchase":
                    qb_sent_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_po_number":
                    customer_po_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_sent_service":
                    qb_sent_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "put_away_rma":
                    put_away_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "needs_purchasing":
                    needs_purchasingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "currency_name_price":
                    currency_name_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exchange_rate_price":
                    exchange_rate_priceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "currency_name_cost":
                    currency_name_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exchange_rate_cost":
                    exchange_rate_costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_exchanged":
                    unit_price_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_exchanged":
                    total_price_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_cost_exchanged":
                    unit_cost_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_cost_exchanged":
                    total_cost_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_print":
                    unit_price_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_print":
                    total_price_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_cost_print":
                    unit_cost_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_cost_print":
                    total_cost_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_rma_exchanged":
                    unit_price_rma_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_vendrma_exchanged":
                    unit_price_vendrma_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_rma_exchanged":
                    total_price_rma_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_vendrma_exchanged":
                    total_price_vendrma_exchangedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_rma_print":
                    unit_price_rma_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unit_price_vendrma_print":
                    unit_price_vendrma_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_rma_print":
                    total_price_rma_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_price_vendrma_print":
                    total_price_vendrma_printAttribute = (CoreVarValAttribute)attr;
                    break;
                case "needs_post_put_away":
                    needs_post_put_awayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exchange_rate_rma":
                    exchange_rate_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exchange_rate_vendrma":
                    exchange_rate_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "needs_post_ship":
                    needs_post_shipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_consumption":
                    is_consumptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line_type":
                    line_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_amount_rma":
                    paid_amount_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_date_rma":
                    paid_date_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_amount_vendrma":
                    paid_amount_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paid_date_vendrma":
                    paid_date_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_expense_account_name":
                    purchase_expense_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "purchase_expense_account_uid":
                    purchase_expense_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sales_income_account_name":
                    sales_income_account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sales_income_account_uid":
                    sales_income_account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "posted_invoice":
                    posted_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "posted_purchase":
                    posted_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "posted_rma":
                    posted_rmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "posted_vendrma":
                    posted_vendrmaAttribute = (CoreVarValAttribute)attr;
                    break;
                case "posted_service":
                    posted_serviceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cc_charge_type":
                    cc_charge_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_dock_date_initial":
                    customer_dock_date_initialAttribute = (CoreVarValAttribute)attr;
                    break;
                //KT Refactored from Rz5
                case "total_fees":
                    total_feesAttribute = (CoreVarValAttribute)attr;
                    break;
                //KT - Bool for is In House Service RMA
                case "is_RMA_IHS":
                    is_RMA_IHSAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isvoid_SMCFault":
                    isvoid_SMCFaultAttribute = (CoreVarValAttribute)attr;
                    break;
                case "unique_id_canceled":
                    unique_id_canceledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "insp_id":
                    insp_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "nonconid":
                    nonconidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bid_partnumber":
                    bid_partnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importid":
                    importidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "quoted_partnumber":
                    quoted_partnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tbd_cleared_date":
                    tbd_cleared_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qc_status":
                    qc_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                //QB Sales Order ID? 
                case "qb_line_ListID":
                    qb_line_ListIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_line_subitem_ListID":
                    qb_line_subitem_ListIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_order_ListID":
                    qb_order_ListIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_line_TxnID":
                    qb_line_TxnIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "qb_line_TxnID_purchase":
                    qb_line_TxnID_purchaseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent":
                    list_acquisition_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_acquisition_agent_uid":
                    list_acquisition_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "country_of_origin":
                    country_of_originAttribute = (CoreVarValAttribute)attr;
                    break;

                case "is_split_commission":
                    is_split_commissionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_name":
                    split_commission_agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_uid":
                    split_commission_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_type":
                    split_commission_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_ID":
                    split_commission_IDAttribute = (CoreVarValAttribute)attr;
                    break;

                case "harmonized_tariff_schedule":
                    harmonized_tariff_scheduleAttribute = (CoreVarValAttribute)attr;
                    break;

                case "projected_dock_date":
                    projected_dock_dateAttribute = (CoreVarValAttribute)attr;
                    break;

                case "internalpart_vendor_uid":
                    internalpart_vendor_uidAttribute = (CoreVarValAttribute)attr;
                    break;

                case "internalpart_vendor":
                    internalpart_vendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "affiliate_id":
                    affiliate_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "inspection_status":
                    inspection_statusAttribute = (CoreVarValAttribute)attr;
                    break;

                case "source":
                    sourceAttribute = (CoreVarValAttribute)attr;
                    break;

                case "country_of_origin_vendor":
                    country_of_origin_vendorAttribute = (CoreVarValAttribute)attr;
                    break;

                case "line_validation_status":
                    line_validation_statusAttribute = (CoreVarValAttribute)attr;
                    break;



            }
        }

        static CoreVarValAttribute unit_priceAttribute;
        static CoreVarValAttribute unit_costAttribute;
        static CoreVarValAttribute mfg_certificationsAttribute;
        static CoreVarValAttribute has_cofcAttribute;
        static CoreVarValAttribute assemblynameAttribute;
        static CoreVarValAttribute warranty_periodAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute tracking_invoiceAttribute;
        static CoreVarValAttribute tracking_purchaseAttribute;
        static CoreVarValAttribute tracking_rmaAttribute;
        static CoreVarValAttribute tracking_vendrmaAttribute;
        static CoreVarValAttribute tracking_service_inAttribute;
        static CoreVarValAttribute tracking_service_outAttribute;
        static CoreVarValAttribute shipvia_invoiceAttribute;
        static CoreVarValAttribute shipvia_purchaseAttribute;
        static CoreVarValAttribute shipvia_rmaAttribute;
        static CoreVarValAttribute shipvia_vendrmaAttribute;
        static CoreVarValAttribute shipvia_service_outAttribute;
        static CoreVarValAttribute shipvia_service_inAttribute;
        static CoreVarValAttribute shippingaccount_invoiceAttribute;
        static CoreVarValAttribute shippingaccount_purchaseAttribute;
        static CoreVarValAttribute shippingaccount_rmaAttribute;
        static CoreVarValAttribute shippingaccount_vendrmaAttribute;
        static CoreVarValAttribute shippingaccount_service_outAttribute;
        static CoreVarValAttribute shippingaccount_service_inAttribute;
        static CoreVarValAttribute customer_uidAttribute;
        static CoreVarValAttribute customer_nameAttribute;
        static CoreVarValAttribute customer_contact_uidAttribute;
        static CoreVarValAttribute customer_contact_nameAttribute;
        static CoreVarValAttribute vendor_uidAttribute;
        static CoreVarValAttribute vendor_nameAttribute;
        static CoreVarValAttribute vendor_contact_uidAttribute;
        static CoreVarValAttribute vendor_contact_nameAttribute;
        static CoreVarValAttribute service_vendor_uidAttribute;
        static CoreVarValAttribute service_vendor_nameAttribute;
        static CoreVarValAttribute service_vendor_contact_uidAttribute;
        static CoreVarValAttribute service_vendor_contact_nameAttribute;
        static CoreVarValAttribute shipping_fee_invoiceAttribute;
        static CoreVarValAttribute shipping_fee_purchaseAttribute;
        static CoreVarValAttribute shipping_fee_rmaAttribute;
        static CoreVarValAttribute shipping_fee_vendrmaAttribute;
        static CoreVarValAttribute shipping_fee_service_outAttribute;
        static CoreVarValAttribute shipping_fee_service_inAttribute;
        static CoreVarValAttribute charge1_fee_invoiceAttribute;
        static CoreVarValAttribute charge1_fee_invoice_captionAttribute;
        static CoreVarValAttribute charge1_fee_purchaseAttribute;
        static CoreVarValAttribute charge1_fee_purchase_captionAttribute;
        static CoreVarValAttribute charge1_fee_rmaAttribute;
        static CoreVarValAttribute charge1_fee_rma_captionAttribute;
        static CoreVarValAttribute charge1_fee_vendrmaAttribute;
        static CoreVarValAttribute charge1_fee_vendrma_captionAttribute;
        static CoreVarValAttribute charge1_fee_service_outAttribute;
        static CoreVarValAttribute charge1_fee_service_out_captionAttribute;
        static CoreVarValAttribute charge1_fee_service_inAttribute;
        static CoreVarValAttribute charge1_fee_service_in_captionAttribute;
        static CoreVarValAttribute charge2_fee_invoiceAttribute;
        static CoreVarValAttribute charge2_fee_invoice_captionAttribute;
        static CoreVarValAttribute charge2_fee_purchaseAttribute;
        static CoreVarValAttribute charge2_fee_purchase_captionAttribute;
        static CoreVarValAttribute charge2_fee_rmaAttribute;
        static CoreVarValAttribute charge2_fee_rma_captionAttribute;
        static CoreVarValAttribute charge2_fee_vendrmaAttribute;
        static CoreVarValAttribute charge2_fee_vendrma_captionAttribute;
        static CoreVarValAttribute charge2_fee_service_outAttribute;
        static CoreVarValAttribute charge2_fee_service_out_captionAttribute;
        static CoreVarValAttribute charge2_fee_service_inAttribute;
        static CoreVarValAttribute charge2_fee_service_in_captionAttribute;
        static CoreVarValAttribute seller_uidAttribute;
        static CoreVarValAttribute seller_nameAttribute;
        static CoreVarValAttribute buyer_uidAttribute;
        static CoreVarValAttribute buyer_nameAttribute;
        static CoreVarValAttribute orderid_salesAttribute;
        static CoreVarValAttribute orderid_purchaseAttribute;
        static CoreVarValAttribute orderid_invoiceAttribute;
        static CoreVarValAttribute orderid_rmaAttribute;
        static CoreVarValAttribute orderid_vendrmaAttribute;
        static CoreVarValAttribute orderid_serviceAttribute;
        static CoreVarValAttribute linecode_salesAttribute;
        static CoreVarValAttribute linecode_purchaseAttribute;
        static CoreVarValAttribute linecode_invoiceAttribute;
        static CoreVarValAttribute linecode_rmaAttribute;
        static CoreVarValAttribute linecode_vendrmaAttribute;
        static CoreVarValAttribute orderdate_salesAttribute;
        static CoreVarValAttribute orderdate_purchaseAttribute;
        static CoreVarValAttribute orderdate_invoiceAttribute;
        static CoreVarValAttribute orderdate_rmaAttribute;
        static CoreVarValAttribute orderdate_vendrmaAttribute;
        static CoreVarValAttribute orderdate_serviceAttribute;
        static CoreVarValAttribute qcid_purchaseAttribute;
        static CoreVarValAttribute qcid_invoiceAttribute;
        static CoreVarValAttribute qcid_rmaAttribute;
        static CoreVarValAttribute qcid_vendrmaAttribute;
        static CoreVarValAttribute qcid_service_outAttribute;
        static CoreVarValAttribute qcid_service_inAttribute;
        static CoreVarValAttribute receive_date_dueAttribute;
        static CoreVarValAttribute receive_date_actualAttribute;
        static CoreVarValAttribute ship_date_dueAttribute;
        static CoreVarValAttribute ship_date_actualAttribute;
        static CoreVarValAttribute receive_agent_uidAttribute;
        static CoreVarValAttribute receive_agent_nameAttribute;
        static CoreVarValAttribute ship_agent_uidAttribute;
        static CoreVarValAttribute ship_agent_nameAttribute;
        static CoreVarValAttribute ship_noteAttribute;
        static CoreVarValAttribute receive_noteAttribute;
        static CoreVarValAttribute total_priceAttribute;
        static CoreVarValAttribute total_costAttribute;
        static CoreVarValAttribute gross_profitAttribute;
        static CoreVarValAttribute net_profitAttribute;
        static CoreVarValAttribute paid_date_serviceAttribute;
        static CoreVarValAttribute paid_date_purchaseAttribute;
        static CoreVarValAttribute paid_amount_serviceAttribute;
        static CoreVarValAttribute paid_amount_purchaseAttribute;
        static CoreVarValAttribute paid_date_invoiceAttribute;
        static CoreVarValAttribute paid_amount_invoiceAttribute;
        static CoreVarValAttribute ordernumber_salesAttribute;
        static CoreVarValAttribute ordernumber_purchaseAttribute;
        static CoreVarValAttribute ordernumber_serviceAttribute;
        static CoreVarValAttribute ordernumber_rmaAttribute;
        static CoreVarValAttribute ordernumber_vendrmaAttribute;
        static CoreVarValAttribute notes_salesAttribute;
        static CoreVarValAttribute notes_purchaseAttribute;
        static CoreVarValAttribute notes_rmaAttribute;
        static CoreVarValAttribute notes_vendrmaAttribute;
        static CoreVarValAttribute receive_locationAttribute;
        static CoreVarValAttribute quantity_packedAttribute;
        static CoreVarValAttribute orderid_quoteAttribute;
        static CoreVarValAttribute ordernumber_quoteAttribute;
        static CoreVarValAttribute quote_line_uidAttribute;
        static CoreVarValAttribute ordernumber_invoiceAttribute;
        static CoreVarValAttribute was_shippedAttribute;
        static CoreVarValAttribute was_receivedAttribute;
        static CoreVarValAttribute was_service_outAttribute;
        static CoreVarValAttribute was_service_inAttribute;
        static CoreVarValAttribute was_rmaAttribute;
        static CoreVarValAttribute was_vendrmaAttribute;
        static CoreVarValAttribute was_rma_receivedAttribute;
        static CoreVarValAttribute was_vendrma_shippedAttribute;
        static CoreVarValAttribute stocktype_receiveAttribute;
        static CoreVarValAttribute legacyid_salesAttribute;
        static CoreVarValAttribute legacyid_purchaseAttribute;
        static CoreVarValAttribute legacyid_serviceAttribute;
        static CoreVarValAttribute legacyid_invoiceAttribute;
        static CoreVarValAttribute legacyid_rmaAttribute;
        static CoreVarValAttribute legacyid_vendrmaAttribute;
        static CoreVarValAttribute was_purchaseAttribute;
        static CoreVarValAttribute was_invoiceAttribute;
        static CoreVarValAttribute quantity_unpackedAttribute;
        static CoreVarValAttribute quantity_packed_serviceAttribute;
        static CoreVarValAttribute quantity_unpacked_serviceAttribute;
        static CoreVarValAttribute quantity_packed_vendrmaAttribute;
        static CoreVarValAttribute quantity_unpacked_rmaAttribute;
        static CoreVarValAttribute linecode_serviceAttribute;
        static CoreVarValAttribute unit_price_vendrmaAttribute;
        static CoreVarValAttribute total_price_vendrmaAttribute;
        static CoreVarValAttribute unit_price_rmaAttribute;
        static CoreVarValAttribute total_price_rmaAttribute;
        static CoreVarValAttribute put_awayAttribute;
        static CoreVarValAttribute put_away_dateAttribute;
        static CoreVarValAttribute put_away_userAttribute;
        static CoreVarValAttribute service_costAttribute;
        static CoreVarValAttribute service_leadtimeAttribute;
        static CoreVarValAttribute is_rma_replacementAttribute;
        static CoreVarValAttribute total_deductionAttribute;
        static CoreVarValAttribute vendrma_will_refundAttribute;
        static CoreVarValAttribute rma_subtractionAttribute;
        static CoreVarValAttribute ship_date_service_dueAttribute;
        static CoreVarValAttribute ship_date_service_actualAttribute;
        static CoreVarValAttribute ship_date_vendrma_dueAttribute;
        static CoreVarValAttribute ship_date_vendrma_actualAttribute;
        static CoreVarValAttribute receive_date_service_dueAttribute;
        static CoreVarValAttribute receive_date_service_actualAttribute;
        static CoreVarValAttribute receive_date_rma_dueAttribute;
        static CoreVarValAttribute receive_date_rma_actualAttribute;
        static CoreVarValAttribute ship_date_nextAttribute;
        static CoreVarValAttribute receive_date_nextAttribute;
        static CoreVarValAttribute shipvia_nextAttribute;
        static CoreVarValAttribute shipvia_receive_nextAttribute;
        static CoreVarValAttribute ship_to_nextAttribute;
        static CoreVarValAttribute receive_from_nextAttribute;
        static CoreVarValAttribute drop_shipAttribute;
        static CoreVarValAttribute drop_ship_commentsAttribute;
        static CoreVarValAttribute internal_customerAttribute;
        static CoreVarValAttribute line_group_idAttribute;
        static CoreVarValAttribute rohs_info_vendorAttribute;
        static CoreVarValAttribute customer_dock_dateAttribute;
        static CoreVarValAttribute status_captionAttribute;
        static CoreVarValAttribute datecode_purchaseAttribute;
        static CoreVarValAttribute inventory_link_uidAttribute;
        static CoreVarValAttribute inventory_link_captionAttribute;
        static CoreVarValAttribute po_option_numberAttribute;
        static CoreVarValAttribute po_optionAttribute;
        static CoreVarValAttribute purchased_as_otherAttribute;
        static CoreVarValAttribute purchased_as_numberAttribute;
        static CoreVarValAttribute part_number_strippedAttribute;
        static CoreVarValAttribute purchased_as_strippedAttribute;
        static CoreVarValAttribute service_agent_uidAttribute;
        static CoreVarValAttribute service_agent_nameAttribute;
        static CoreVarValAttribute charge_service_to_customerAttribute;
        static CoreVarValAttribute qb_sent_purchaseAttribute;
        static CoreVarValAttribute customer_po_numberAttribute;
        static CoreVarValAttribute qb_sent_serviceAttribute;
        static CoreVarValAttribute put_away_rmaAttribute;
        static CoreVarValAttribute needs_purchasingAttribute;
        static CoreVarValAttribute currency_name_priceAttribute;
        static CoreVarValAttribute exchange_rate_priceAttribute;
        static CoreVarValAttribute currency_name_costAttribute;
        static CoreVarValAttribute exchange_rate_costAttribute;
        static CoreVarValAttribute unit_price_exchangedAttribute;
        static CoreVarValAttribute total_price_exchangedAttribute;
        static CoreVarValAttribute unit_cost_exchangedAttribute;
        static CoreVarValAttribute total_cost_exchangedAttribute;
        static CoreVarValAttribute unit_price_printAttribute;
        static CoreVarValAttribute total_price_printAttribute;
        static CoreVarValAttribute unit_cost_printAttribute;
        static CoreVarValAttribute total_cost_printAttribute;
        static CoreVarValAttribute unit_price_rma_exchangedAttribute;
        static CoreVarValAttribute unit_price_vendrma_exchangedAttribute;
        static CoreVarValAttribute total_price_rma_exchangedAttribute;
        static CoreVarValAttribute total_price_vendrma_exchangedAttribute;
        static CoreVarValAttribute unit_price_rma_printAttribute;
        static CoreVarValAttribute unit_price_vendrma_printAttribute;
        static CoreVarValAttribute total_price_rma_printAttribute;
        static CoreVarValAttribute total_price_vendrma_printAttribute;
        static CoreVarValAttribute needs_post_put_awayAttribute;
        static CoreVarValAttribute exchange_rate_rmaAttribute;
        static CoreVarValAttribute exchange_rate_vendrmaAttribute;
        static CoreVarValAttribute needs_post_shipAttribute;
        static CoreVarValAttribute is_consumptionAttribute;
        static CoreVarValAttribute line_typeAttribute;
        static CoreVarValAttribute paid_amount_rmaAttribute;
        static CoreVarValAttribute paid_date_rmaAttribute;
        static CoreVarValAttribute paid_amount_vendrmaAttribute;
        static CoreVarValAttribute paid_date_vendrmaAttribute;
        static CoreVarValAttribute purchase_expense_account_nameAttribute;
        static CoreVarValAttribute purchase_expense_account_uidAttribute;
        static CoreVarValAttribute sales_income_account_nameAttribute;
        static CoreVarValAttribute sales_income_account_uidAttribute;
        static CoreVarValAttribute posted_invoiceAttribute;
        static CoreVarValAttribute posted_purchaseAttribute;
        static CoreVarValAttribute posted_rmaAttribute;
        static CoreVarValAttribute posted_vendrmaAttribute;
        static CoreVarValAttribute posted_serviceAttribute;
        static CoreVarValAttribute cc_charge_typeAttribute;
        static CoreVarValAttribute customer_dock_date_initialAttribute;
        static CoreVarValAttribute total_feesAttribute;
        static CoreVarValAttribute is_RMA_IHSAttribute;
        static CoreVarValAttribute isvoid_SMCFaultAttribute;
        static CoreVarValAttribute unique_id_canceledAttribute;
        static CoreVarValAttribute insp_idAttribute;
        static CoreVarValAttribute nonconidAttribute;
        static CoreVarValAttribute bid_partnumberAttribute;
        static CoreVarValAttribute importidAttribute;
        static CoreVarValAttribute quoted_partnumberAttribute;
        static CoreVarValAttribute tbd_cleared_dateAttribute;
        static CoreVarValAttribute qc_statusAttribute;
        static CoreVarValAttribute qb_order_ListIDAttribute;
        static CoreVarValAttribute qb_line_ListIDAttribute;
        static CoreVarValAttribute qb_line_TxnIDAttribute;
        static CoreVarValAttribute qb_line_subitem_ListIDAttribute;
        static CoreVarValAttribute qb_line_TxnID_purchaseAttribute;
        static CoreVarValAttribute list_acquisition_agentAttribute;
        static CoreVarValAttribute list_acquisition_agent_uidAttribute;
        static CoreVarValAttribute is_split_commissionAttribute;
        static CoreVarValAttribute split_commission_agent_nameAttribute;
        static CoreVarValAttribute split_commission_agent_uidAttribute;
        static CoreVarValAttribute split_commission_typeAttribute;
        static CoreVarValAttribute split_commission_IDAttribute;
        static CoreVarValAttribute country_of_originAttribute;
        static CoreVarValAttribute harmonized_tariff_scheduleAttribute;
        static CoreVarValAttribute projected_dock_dateAttribute;
        static CoreVarValAttribute internalpart_vendor_uidAttribute;
        static CoreVarValAttribute internalpart_vendorAttribute;
        static CoreVarValAttribute affiliate_idAttribute;
        static CoreVarValAttribute inspection_statusAttribute;
        static CoreVarValAttribute sourceAttribute;
        static CoreVarValAttribute country_of_origin_vendorAttribute;
        static CoreVarValAttribute line_validation_statusAttribute;

        




        [CoreVarVal("unit_price", "Double", Caption = "Unit Price", Importance = 1)]
        public VarDouble unit_priceVar;

        [CoreVarVal("unit_cost", "Double", Caption = "Unit Cost", Importance = 2)]
        public VarDouble unit_costVar;

        [CoreVarVal("mfg_certifications", "Boolean", Caption = "Mfg Certifications", Importance = 5)]
        public VarBoolean mfg_certificationsVar;

        [CoreVarVal("has_cofc", "Boolean", Caption = "Has Cofc", Importance = 6)]
        public VarBoolean has_cofcVar;

        [CoreVarVal("assemblyname", "String", TheFieldLength = 255, Caption = "Assemblyname", Importance = 7)]
        public VarString assemblynameVar;

        [CoreVarVal("warranty_period", "String", TheFieldLength = 255, Caption = "Warranty Period", Importance = 8)]
        public VarString warranty_periodVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption = "Abs Type", Importance = 9)]
        public VarString abs_typeVar;

        [CoreVarVal("tracking_invoice", "String", TheFieldLength = 8000, Caption = "Tracking Invoice", Importance = 10)]
        public VarString tracking_invoiceVar;

        [CoreVarVal("tracking_purchase", "String", TheFieldLength = 8000, Caption = "Tracking Purchase", Importance = 11)]
        public VarString tracking_purchaseVar;

        [CoreVarVal("tracking_rma", "String", TheFieldLength = 8000, Caption = "Tracking Rma", Importance = 13)]
        public VarString tracking_rmaVar;

        [CoreVarVal("tracking_vendrma", "String", TheFieldLength = 255, Caption = "Tracking Vendrma", Importance = 14)]
        public VarString tracking_vendrmaVar;

        [CoreVarVal("tracking_service_in", "String", TheFieldLength = 8000, Caption = "Tracking Service In", Importance = 15)]
        public VarString tracking_service_inVar;

        [CoreVarVal("tracking_service_out", "String", TheFieldLength = 8000, Caption = "Tracking Service Out", Importance = 16)]
        public VarString tracking_service_outVar;

        [CoreVarVal("shipvia_invoice", "String", TheFieldLength = 255, Caption = "Shipvia Invoice", Importance = 17)]
        public VarString shipvia_invoiceVar;

        [CoreVarVal("shipvia_purchase", "String", TheFieldLength = 255, Caption = "Shipvia Purchase", Importance = 18)]
        public VarString shipvia_purchaseVar;

        [CoreVarVal("shipvia_rma", "String", TheFieldLength = 255, Caption = "Shipvia Rma", Importance = 19)]
        public VarString shipvia_rmaVar;

        [CoreVarVal("shipvia_vendrma", "String", TheFieldLength = 255, Caption = "Shipvia Vendrma", Importance = 20)]
        public VarString shipvia_vendrmaVar;

        [CoreVarVal("shipvia_service_out", "String", TheFieldLength = 255, Caption = "Shipvia Service Out", Importance = 21)]
        public VarString shipvia_service_outVar;

        [CoreVarVal("shipvia_service_in", "String", TheFieldLength = 255, Caption = "Shipvia Service In", Importance = 22)]
        public VarString shipvia_service_inVar;

        [CoreVarVal("shippingaccount_invoice", "String", TheFieldLength = 255, Caption = "Shippingaccount Invoice", Importance = 23)]
        public VarString shippingaccount_invoiceVar;

        [CoreVarVal("shippingaccount_purchase", "String", TheFieldLength = 255, Caption = "Shippingaccount Purchase", Importance = 24)]
        public VarString shippingaccount_purchaseVar;

        [CoreVarVal("shippingaccount_rma", "String", TheFieldLength = 255, Caption = "Shippingaccount Rma", Importance = 25)]
        public VarString shippingaccount_rmaVar;

        [CoreVarVal("shippingaccount_vendrma", "String", TheFieldLength = 255, Caption = "Shippingaccount Vendrma", Importance = 26)]
        public VarString shippingaccount_vendrmaVar;

        [CoreVarVal("shippingaccount_service_out", "String", TheFieldLength = 255, Caption = "Shippingaccount Service Out", Importance = 27)]
        public VarString shippingaccount_service_outVar;

        [CoreVarVal("shippingaccount_service_in", "String", TheFieldLength = 255, Caption = "Shippingaccount Service In", Importance = 28)]
        public VarString shippingaccount_service_inVar;

        [CoreVarVal("customer_uid", "String", TheFieldLength = 255, Caption = "Customer Uid", Importance = 29)]
        public VarString customer_uidVar;

        [CoreVarVal("customer_name", "String", TheFieldLength = 8000, Caption = "Customer Name", Importance = 30)]
        public VarString customer_nameVar;

        [CoreVarVal("customer_contact_uid", "String", TheFieldLength = 255, Caption = "Customer Contact Uid", Importance = 31)]
        public VarString customer_contact_uidVar;

        [CoreVarVal("customer_contact_name", "String", TheFieldLength = 8000, Caption = "Customer Contact Name", Importance = 32)]
        public VarString customer_contact_nameVar;

        [CoreVarVal("vendor_uid", "String", TheFieldLength = 255, Caption = "Vendor Uid", Importance = 33)]
        public VarString vendor_uidVar;

        [CoreVarVal("vendor_name", "String", TheFieldLength = 8000, Caption = "Vendor Name", Importance = 34)]
        public VarString vendor_nameVar;

        [CoreVarVal("vendor_contact_uid", "String", TheFieldLength = 255, Caption = "Vendor Contact Uid", Importance = 35)]
        public VarString vendor_contact_uidVar;

        [CoreVarVal("vendor_contact_name", "String", TheFieldLength = 8000, Caption = "Vendor Contact Name", Importance = 36)]
        public VarString vendor_contact_nameVar;

        [CoreVarVal("service_vendor_uid", "String", TheFieldLength = 255, Caption = "Service Vendor Uid", Importance = 37)]
        public VarString service_vendor_uidVar;

        [CoreVarVal("service_vendor_name", "String", TheFieldLength = 8000, Caption = "Service Vendor Name", Importance = 38)]
        public VarString service_vendor_nameVar;

        [CoreVarVal("service_vendor_contact_uid", "String", TheFieldLength = 255, Caption = "Service Vendor Contact Uid", Importance = 39)]
        public VarString service_vendor_contact_uidVar;

        [CoreVarVal("service_vendor_contact_name", "String", TheFieldLength = 8000, Caption = "Service Vendor Contact Name", Importance = 40)]
        public VarString service_vendor_contact_nameVar;

        [CoreVarVal("shipping_fee_invoice", "Double", Caption = "Shipping Fee Invoice", Importance = 41)]
        public VarDouble shipping_fee_invoiceVar;

        [CoreVarVal("shipping_fee_purchase", "Double", Caption = "Shipping Fee Purchase", Importance = 42)]
        public VarDouble shipping_fee_purchaseVar;

        [CoreVarVal("shipping_fee_rma", "Double", Caption = "Shipping Fee Rma", Importance = 43)]
        public VarDouble shipping_fee_rmaVar;

        [CoreVarVal("shipping_fee_vendrma", "Double", Caption = "Shipping Fee Vendrma", Importance = 44)]
        public VarDouble shipping_fee_vendrmaVar;

        [CoreVarVal("shipping_fee_service_out", "Double", Caption = "Shipping Fee Service Out", Importance = 45)]
        public VarDouble shipping_fee_service_outVar;

        [CoreVarVal("shipping_fee_service_in", "Double", Caption = "Shipping Fee Service In", Importance = 46)]
        public VarDouble shipping_fee_service_inVar;

        [CoreVarVal("charge1_fee_invoice", "Double", Caption = "Charge1 Fee Invoice", Importance = 47)]
        public VarDouble charge1_fee_invoiceVar;

        [CoreVarVal("charge1_fee_invoice_caption", "String", TheFieldLength = 255, Caption = "Charge1 Fee Invoice Caption", Importance = 48)]
        public VarString charge1_fee_invoice_captionVar;

        [CoreVarVal("charge1_fee_purchase", "Double", Caption = "Charge1 Fee Purchase", Importance = 49)]
        public VarDouble charge1_fee_purchaseVar;

        [CoreVarVal("charge1_fee_purchase_caption", "String", TheFieldLength = 255, Caption = "Charge1 Fee Purchase Caption", Importance = 50)]
        public VarString charge1_fee_purchase_captionVar;

        [CoreVarVal("charge1_fee_rma", "Double", Caption = "Charge1 Fee Rma", Importance = 51)]
        public VarDouble charge1_fee_rmaVar;

        [CoreVarVal("charge1_fee_rma_caption", "String", TheFieldLength = 255, Caption = "Charge1 Fee Rma Caption", Importance = 52)]
        public VarString charge1_fee_rma_captionVar;

        [CoreVarVal("charge1_fee_vendrma", "Double", Caption = "Charge1 Fee Vendrma", Importance = 53)]
        public VarDouble charge1_fee_vendrmaVar;

        [CoreVarVal("charge1_fee_vendrma_caption", "String", TheFieldLength = 255, Caption = "Charge1 Fee Vendrma Caption", Importance = 54)]
        public VarString charge1_fee_vendrma_captionVar;

        [CoreVarVal("charge1_fee_service_out", "Double", Caption = "Charge1 Fee Service Out", Importance = 55)]
        public VarDouble charge1_fee_service_outVar;

        [CoreVarVal("charge1_fee_service_out_caption", "String", TheFieldLength = 255, Caption = "Charge1 Fee Service Out Caption", Importance = 56)]
        public VarString charge1_fee_service_out_captionVar;

        [CoreVarVal("charge1_fee_service_in", "Double", Caption = "Charge1 Fee Service In", Importance = 57)]
        public VarDouble charge1_fee_service_inVar;

        [CoreVarVal("charge1_fee_service_in_caption", "String", TheFieldLength = 255, Caption = "Charge1 Fee Service In Caption", Importance = 58)]
        public VarString charge1_fee_service_in_captionVar;

        [CoreVarVal("charge2_fee_invoice", "Double", Caption = "Charge2 Fee Invoice", Importance = 59)]
        public VarDouble charge2_fee_invoiceVar;

        [CoreVarVal("charge2_fee_invoice_caption", "String", TheFieldLength = 255, Caption = "Charge2 Fee Invoice Caption", Importance = 60)]
        public VarString charge2_fee_invoice_captionVar;

        [CoreVarVal("charge2_fee_purchase", "Double", Caption = "Charge2 Fee Purchase", Importance = 61)]
        public VarDouble charge2_fee_purchaseVar;

        [CoreVarVal("charge2_fee_purchase_caption", "String", TheFieldLength = 255, Caption = "Charge2 Fee Purchase Caption", Importance = 62)]
        public VarString charge2_fee_purchase_captionVar;

        [CoreVarVal("charge2_fee_rma", "Double", Caption = "Charge2 Fee Rma", Importance = 63)]
        public VarDouble charge2_fee_rmaVar;

        [CoreVarVal("charge2_fee_rma_caption", "String", TheFieldLength = 255, Caption = "Charge2 Fee Rma Caption", Importance = 64)]
        public VarString charge2_fee_rma_captionVar;

        [CoreVarVal("charge2_fee_vendrma", "Double", Caption = "Charge2 Fee Vendrma", Importance = 65)]
        public VarDouble charge2_fee_vendrmaVar;

        [CoreVarVal("charge2_fee_vendrma_caption", "String", TheFieldLength = 255, Caption = "Charge2 Fee Vendrma Caption", Importance = 66)]
        public VarString charge2_fee_vendrma_captionVar;

        [CoreVarVal("charge2_fee_service_out", "Double", Caption = "Charge2 Fee Service Out", Importance = 67)]
        public VarDouble charge2_fee_service_outVar;

        [CoreVarVal("charge2_fee_service_out_caption", "String", TheFieldLength = 255, Caption = "Charge2 Fee Service Out Caption", Importance = 68)]
        public VarString charge2_fee_service_out_captionVar;

        [CoreVarVal("charge2_fee_service_in", "Double", Caption = "Charge2 Fee Service In", Importance = 69)]
        public VarDouble charge2_fee_service_inVar;

        [CoreVarVal("charge2_fee_service_in_caption", "String", TheFieldLength = 255, Caption = "Charge2 Fee Service In Caption", Importance = 70)]
        public VarString charge2_fee_service_in_captionVar;

        [CoreVarVal("seller_uid", "String", TheFieldLength = 255, Caption = "Seller Uid", Importance = 77)]
        public VarString seller_uidVar;

        [CoreVarVal("seller_name", "String", TheFieldLength = 8000, Caption = "Seller Name", Importance = 78)]
        public VarString seller_nameVar;

        [CoreVarVal("buyer_uid", "String", TheFieldLength = 255, Caption = "Buyer Uid", Importance = 79)]
        public VarString buyer_uidVar;

        [CoreVarVal("buyer_name", "String", TheFieldLength = 8000, Caption = "Buyer Name", Importance = 80)]
        public VarString buyer_nameVar;

        [CoreVarVal("orderid_sales", "String", TheFieldLength = 255, Caption = "Orderid Sales", Importance = 81)]
        public VarString orderid_salesVar;

        [CoreVarVal("orderid_purchase", "String", TheFieldLength = 255, Caption = "Orderid Purchase", Importance = 82)]
        public VarString orderid_purchaseVar;

        [CoreVarVal("orderid_invoice", "String", TheFieldLength = 255, Caption = "Orderid Invoice", Importance = 83)]
        public VarString orderid_invoiceVar;

        [CoreVarVal("orderid_rma", "String", TheFieldLength = 255, Caption = "Orderid Rma", Importance = 84)]
        public VarString orderid_rmaVar;

        [CoreVarVal("orderid_vendrma", "String", TheFieldLength = 255, Caption = "Orderid Vendrma", Importance = 85)]
        public VarString orderid_vendrmaVar;

        [CoreVarVal("orderid_service", "String", TheFieldLength = 255, Caption = "Orderid Service", Importance = 86)]
        public VarString orderid_serviceVar;

        [CoreVarVal("linecode_sales", "Int32", Caption = "Linecode Sales", Importance = 87)]
        public VarInt32 linecode_salesVar;

        [CoreVarVal("linecode_purchase", "Int32", Caption = "Linecode Purchase", Importance = 88)]
        public VarInt32 linecode_purchaseVar;

        [CoreVarVal("linecode_invoice", "Int32", Caption = "Linecode Invoice", Importance = 89)]
        public VarInt32 linecode_invoiceVar;

        [CoreVarVal("linecode_rma", "Int32", Caption = "Linecode Rma", Importance = 90)]
        public VarInt32 linecode_rmaVar;

        [CoreVarVal("linecode_vendrma", "Int32", Caption = "Linecode Vendrma", Importance = 91)]
        public VarInt32 linecode_vendrmaVar;

        [CoreVarVal("orderdate_sales", "DateTime", Caption = "Orderdate Sales", Importance = 92)]
        public VarDateTime orderdate_salesVar;

        [CoreVarVal("orderdate_purchase", "DateTime", Caption = "Orderdate Purchase", Importance = 93)]
        public VarDateTime orderdate_purchaseVar;

        [CoreVarVal("orderdate_invoice", "DateTime", Caption = "Orderdate Invoice", Importance = 94)]
        public VarDateTime orderdate_invoiceVar;

        [CoreVarVal("orderdate_rma", "DateTime", Caption = "Orderdate Rma", Importance = 95)]
        public VarDateTime orderdate_rmaVar;

        [CoreVarVal("orderdate_vendrma", "DateTime", Caption = "Orderdate Vendrma", Importance = 96)]
        public VarDateTime orderdate_vendrmaVar;

        [CoreVarVal("orderdate_service", "DateTime", Caption = "Orderdate Service", Importance = 97)]
        public VarDateTime orderdate_serviceVar;

        [CoreVarVal("qcid_purchase", "String", TheFieldLength = 255, Caption = "Qcid Purchase", Importance = 100)]
        public VarString qcid_purchaseVar;

        [CoreVarVal("qcid_invoice", "String", TheFieldLength = 255, Caption = "Qcid Invoice", Importance = 101)]
        public VarString qcid_invoiceVar;

        [CoreVarVal("qcid_rma", "String", TheFieldLength = 255, Caption = "Qcid Rma", Importance = 102)]
        public VarString qcid_rmaVar;

        [CoreVarVal("qcid_vendrma", "String", TheFieldLength = 255, Caption = "Qcid Vendrma", Importance = 103)]
        public VarString qcid_vendrmaVar;

        [CoreVarVal("qcid_service_out", "String", TheFieldLength = 255, Caption = "Qcid Service Out", Importance = 104)]
        public VarString qcid_service_outVar;

        [CoreVarVal("qcid_service_in", "String", TheFieldLength = 255, Caption = "Qcid Service In", Importance = 105)]
        public VarString qcid_service_inVar;

        [CoreVarVal("receive_date_due", "DateTime", Caption = "Receive Date Due", Importance = 106)]
        public VarDateTime receive_date_dueVar;

        [CoreVarVal("receive_date_actual", "DateTime", Caption = "Receive Date Actual", Importance = 107)]
        public VarDateTime receive_date_actualVar;

        [CoreVarVal("ship_date_due", "DateTime", Caption = "Ship Date Due", Importance = 108)]
        public VarDateTime ship_date_dueVar;

        [CoreVarVal("ship_date_actual", "DateTime", Caption = "Ship Date Actual", Importance = 109)]
        public VarDateTime ship_date_actualVar;

        [CoreVarVal("receive_agent_uid", "String", TheFieldLength = 255, Caption = "Receive Agent Uid", Importance = 110)]
        public VarString receive_agent_uidVar;

        [CoreVarVal("receive_agent_name", "String", TheFieldLength = 8000, Caption = "Receive Agent Name", Importance = 111)]
        public VarString receive_agent_nameVar;

        [CoreVarVal("ship_agent_uid", "String", TheFieldLength = 255, Caption = "Ship Agent Uid", Importance = 112)]
        public VarString ship_agent_uidVar;

        [CoreVarVal("ship_agent_name", "String", TheFieldLength = 8000, Caption = "Ship Agent Name", Importance = 113)]
        public VarString ship_agent_nameVar;

        [CoreVarVal("ship_note", "String", TheFieldLength = 8000, Caption = "Ship Note", Importance = 114)]
        public VarString ship_noteVar;

        [CoreVarVal("receive_note", "String", TheFieldLength = 8000, Caption = "Receive Note", Importance = 115)]
        public VarString receive_noteVar;

        [CoreVarVal("total_price", "Double", Caption = "Total Price", Importance = 116)]
        public VarDouble total_priceVar;

        [CoreVarVal("total_cost", "Double", Caption = "Total Cost", Importance = 117)]
        public VarDouble total_costVar;

        [CoreVarVal("gross_profit", "Double", Caption = "Gross Profit", Importance = 118)]
        public VarDouble gross_profitVar;

        [CoreVarVal("net_profit", "Double", Caption = "Net Profit", Importance = 119)]
        public VarDouble net_profitVar;

        [CoreVarVal("paid_date_service", "DateTime", Caption = "Paid Date Service", Importance = 230)]
        public VarDateTime paid_date_serviceVar;

        [CoreVarVal("paid_date_purchase", "DateTime", Caption = "Paid Date Purchase", Importance = 228)]
        public VarDateTime paid_date_purchaseVar;

        [CoreVarVal("paid_amount_service", "Double", Caption = "Paid Amount Service", Importance = 229)]
        public VarDouble paid_amount_serviceVar;

        [CoreVarVal("paid_amount_purchase", "Double", Caption = "Paid Amount Purchase", Importance = 227)]
        public VarDouble paid_amount_purchaseVar;

        [CoreVarVal("paid_date_invoice", "DateTime", Caption = "Paid Date Invoice", Importance = 226)]
        public VarDateTime paid_date_invoiceVar;

        [CoreVarVal("paid_amount_invoice", "Double", Caption = "Paid Amount Invoice", Importance = 225)]
        public VarDouble paid_amount_invoiceVar;

        [CoreVarVal("ordernumber_sales", "String", TheFieldLength = 255, Caption = "Ordernumber Sales", Importance = 126)]
        public VarString ordernumber_salesVar;

        [CoreVarVal("ordernumber_purchase", "String", TheFieldLength = 255, Caption = "Ordernumber Purchase", Importance = 127)]
        public VarString ordernumber_purchaseVar;

        [CoreVarVal("ordernumber_service", "String", TheFieldLength = 255, Caption = "Ordernumber Service", Importance = 128)]
        public VarString ordernumber_serviceVar;

        [CoreVarVal("ordernumber_rma", "String", TheFieldLength = 255, Caption = "Ordernumber Rma", Importance = 129)]
        public VarString ordernumber_rmaVar;

        [CoreVarVal("ordernumber_vendrma", "String", TheFieldLength = 255, Caption = "Ordernumber Vendrma", Importance = 130)]
        public VarString ordernumber_vendrmaVar;

        [CoreVarVal("notes_sales", "Text", Caption = "Notes Sales", Importance = 137)]
        public VarText notes_salesVar;

        [CoreVarVal("notes_purchase", "Text", Caption = "Notes Purchase", Importance = 138)]
        public VarText notes_purchaseVar;

        [CoreVarVal("notes_rma", "Text", Caption = "Notes Rma", Importance = 139)]
        public VarText notes_rmaVar;

        [CoreVarVal("notes_vendrma", "Text", Caption = "Notes Vendrma", Importance = 140)]
        public VarText notes_vendrmaVar;

        [CoreVarVal("receive_location", "String", TheFieldLength = 255, Caption = "Receive Location", Importance = 141)]
        public VarString receive_locationVar;

        [CoreVarVal("quantity_packed", "Int32", Caption = "Quantity Packed", Importance = 142)]
        public VarInt32 quantity_packedVar;

        [CoreVarVal("orderid_quote", "String", TheFieldLength = 255, Caption = "Orderid Quote", Importance = 143)]
        public VarString orderid_quoteVar;

        [CoreVarVal("ordernumber_quote", "String", TheFieldLength = 255, Caption = "Ordernumber Quote", Importance = 144)]
        public VarString ordernumber_quoteVar;

        [CoreVarVal("quote_line_uid", "String", TheFieldLength = 255, Caption = "Quote Line Uid", Importance = 145)]
        public VarString quote_line_uidVar;

        [CoreVarVal("ordernumber_invoice", "String", TheFieldLength = 255, Caption = "Ordernumber Invoice", Importance = 147)]
        public VarString ordernumber_invoiceVar;

        [CoreVarVal("was_shipped", "Boolean", Caption = "Was Shipped", Importance = 148)]
        public VarBoolean was_shippedVar;

        [CoreVarVal("was_received", "Boolean", Caption = "Was Received", Importance = 149)]
        public VarBoolean was_receivedVar;

        [CoreVarVal("was_service_out", "Boolean", Caption = "Was Service Out", Importance = 150)]
        public VarBoolean was_service_outVar;

        [CoreVarVal("was_service_in", "Boolean", Caption = "Was Service In", Importance = 151)]
        public VarBoolean was_service_inVar;

        [CoreVarVal("was_rma", "Boolean", Caption = "Was Rma", Importance = 152)]
        public VarBoolean was_rmaVar;

        [CoreVarVal("was_vendrma", "Boolean", Caption = "Was Vendrma", Importance = 153)]
        public VarBoolean was_vendrmaVar;

        [CoreVarVal("was_rma_received", "Boolean", Caption = "Was Rma Received", Importance = 154)]
        public VarBoolean was_rma_receivedVar;

        [CoreVarVal("was_vendrma_shipped", "Boolean", Caption = "Was Vendrma Shipped", Importance = 155)]
        public VarBoolean was_vendrma_shippedVar;

        [CoreVarVal("stocktype_receive", "String", TheFieldLength = 255, Caption = "Stocktype Receive", Importance = 156)]
        public VarString stocktype_receiveVar;

        [CoreVarVal("legacyid_sales", "String", TheFieldLength = 255, Caption = "Legacyid Sales", Importance = 157)]
        public VarString legacyid_salesVar;

        [CoreVarVal("legacyid_purchase", "String", TheFieldLength = 255, Caption = "Legacyid Purchase", Importance = 158)]
        public VarString legacyid_purchaseVar;

        [CoreVarVal("legacyid_service", "String", TheFieldLength = 255, Caption = "Legacyid Service", Importance = 159)]
        public VarString legacyid_serviceVar;

        [CoreVarVal("legacyid_invoice", "String", TheFieldLength = 255, Caption = "Legacyid Invoice", Importance = 160)]
        public VarString legacyid_invoiceVar;

        [CoreVarVal("legacyid_rma", "String", TheFieldLength = 255, Caption = "Legacyid Rma", Importance = 161)]
        public VarString legacyid_rmaVar;

        [CoreVarVal("legacyid_vendrma", "String", TheFieldLength = 255, Caption = "Legacyid Vendrma", Importance = 162)]
        public VarString legacyid_vendrmaVar;

        [CoreVarVal("was_purchase", "Boolean", Caption = "Was Purchase", Importance = 163)]
        public VarBoolean was_purchaseVar;

        [CoreVarVal("was_invoice", "Boolean", Caption = "Was Invoice", Importance = 164)]
        public VarBoolean was_invoiceVar;

        [CoreVarVal("quantity_unpacked", "Int32", Caption = "Quantity Unpacked", Importance = 165)]
        public VarInt32 quantity_unpackedVar;

        [CoreVarVal("quantity_packed_service", "Int32", Caption = "Quantity Packed Service", Importance = 166)]
        public VarInt32 quantity_packed_serviceVar;

        [CoreVarVal("quantity_unpacked_service", "Int32", Caption = "Quantity Unpacked Service", Importance = 167)]
        public VarInt32 quantity_unpacked_serviceVar;

        [CoreVarVal("quantity_packed_vendrma", "Int32", Caption = "Quantity Packed Vendrma", Importance = 168)]
        public VarInt32 quantity_packed_vendrmaVar;

        [CoreVarVal("quantity_unpacked_rma", "Int32", Caption = "Quantity Unpacked Rma", Importance = 169)]
        public VarInt32 quantity_unpacked_rmaVar;

        [CoreVarVal("linecode_service", "Int32", Caption = "Linecode Service", Importance = 170)]
        public VarInt32 linecode_serviceVar;

        [CoreVarVal("unit_price_vendrma", "Double", Caption = "Unit Price Vendrma", Importance = 171)]
        public VarDouble unit_price_vendrmaVar;

        [CoreVarVal("total_price_vendrma", "Double", Caption = "Total Price Vendrma", Importance = 172)]
        public VarDouble total_price_vendrmaVar;

        [CoreVarVal("unit_price_rma", "Double", Caption = "Unit Price Rma", Importance = 173)]
        public VarDouble unit_price_rmaVar;

        [CoreVarVal("total_price_rma", "Double", Caption = "Total Price Rma", Importance = 174)]
        public VarDouble total_price_rmaVar;

        [CoreVarVal("put_away", "Boolean", Caption = "Put Away", Importance = 175)]
        public VarBoolean put_awayVar;

        [CoreVarVal("put_away_date", "DateTime", Caption = "Put Away Date", Importance = 176)]
        public VarDateTime put_away_dateVar;

        [CoreVarVal("put_away_user", "String", TheFieldLength = 255, Caption = "Put Away User", Importance = 177)]
        public VarString put_away_userVar;

        [CoreVarVal("service_cost", "Double", Caption = "Service Cost", Importance = 178)]
        public VarDouble service_costVar;

        [CoreVarVal("service_leadtime", "String", TheFieldLength = 255, Caption = "Service Leadtime", Importance = 179)]
        public VarString service_leadtimeVar;

        [CoreVarVal("is_rma_replacement", "Boolean", Caption = "Is Rma Replacement", Importance = 180)]
        public VarBoolean is_rma_replacementVar;

        [CoreVarVal("total_deduction", "Double", Caption = "Total Deduction", Importance = 181)]
        public VarDouble total_deductionVar;

        [CoreVarVal("vendrma_will_refund", "Boolean", Caption = "Vendrma Will Refund", Importance = 182)]
        public VarBoolean vendrma_will_refundVar;

        [CoreVarVal("rma_subtraction", "Double", Caption = "Rma Subtraction", Importance = 183)]
        public VarDouble rma_subtractionVar;

        [CoreVarVal("ship_date_service_due", "DateTime", Caption = "Ship Date Service Due", Importance = 184)]
        public VarDateTime ship_date_service_dueVar;

        [CoreVarVal("ship_date_service_actual", "DateTime", Caption = "Ship Date Service Actual", Importance = 185)]
        public VarDateTime ship_date_service_actualVar;

        [CoreVarVal("ship_date_vendrma_due", "DateTime", Caption = "Ship Date Vendrma Due", Importance = 186)]
        public VarDateTime ship_date_vendrma_dueVar;

        [CoreVarVal("ship_date_vendrma_actual", "DateTime", Caption = "Ship Date Vendrma Actual", Importance = 187)]
        public VarDateTime ship_date_vendrma_actualVar;

        [CoreVarVal("receive_date_service_due", "DateTime", Caption = "Receive Date Service Due", Importance = 188)]
        public VarDateTime receive_date_service_dueVar;

        [CoreVarVal("receive_date_service_actual", "DateTime", Caption = "Receive Date Service Actual", Importance = 189)]
        public VarDateTime receive_date_service_actualVar;

        [CoreVarVal("receive_date_rma_due", "DateTime", Caption = "Receive Date Rma Due", Importance = 190)]
        public VarDateTime receive_date_rma_dueVar;

        [CoreVarVal("receive_date_rma_actual", "DateTime", Caption = "Receive Date Rma Actual", Importance = 191)]
        public VarDateTime receive_date_rma_actualVar;

        [CoreVarVal("ship_date_next", "DateTime", Caption = "Ship Date Next", Importance = 192)]
        public VarDateTime ship_date_nextVar;

        [CoreVarVal("receive_date_next", "DateTime", Caption = "Receive Date Next", Importance = 193)]
        public VarDateTime receive_date_nextVar;

        [CoreVarVal("shipvia_next", "String", TheFieldLength = 255, Caption = "Shipvia Next", Importance = 194)]
        public VarString shipvia_nextVar;

        [CoreVarVal("shipvia_receive_next", "String", TheFieldLength = 255, Caption = "Shipvia Receive Next", Importance = 195)]
        public VarString shipvia_receive_nextVar;

        [CoreVarVal("ship_to_next", "String", TheFieldLength = 255, Caption = "Ship To Next", Importance = 196)]
        public VarString ship_to_nextVar;

        [CoreVarVal("receive_from_next", "String", TheFieldLength = 255, Caption = "Receive From Next", Importance = 197)]
        public VarString receive_from_nextVar;

        [CoreVarVal("drop_ship", "Boolean", Caption = "Drop Ship", Importance = 198)]
        public VarBoolean drop_shipVar;

        [CoreVarVal("drop_ship_comments", "text", Caption = "Drop Ship Comments", Importance = 198)]
        public VarText drop_ship_commentsVar;

        [CoreVarVal("internal_customer", "String", TheFieldLength = 255, Caption = "Internal Customer", Importance = 199)]
        public VarString internal_customerVar;


        [CoreVarVal("line_group_id", "String", TheFieldLength = 255, Caption = "Line Group Id", Importance = 202)]
        public VarString line_group_idVar;

        [CoreVarVal("rohs_info_vendor", "String", TheFieldLength = 255, Caption = "Rohs Info Vendor", Importance = 203)]
        public VarString rohs_info_vendorVar;

        [CoreVarVal("customer_dock_date", "DateTime", Caption = "Customer Dock Date", Importance = 204)]
        public VarDateTime customer_dock_dateVar;

        [CoreVarVal("status_caption", "String", TheFieldLength = 255, Caption = "Status Caption", Importance = 205)]
        public VarString status_captionVar;

        [CoreVarVal("datecode_purchase", "String", TheFieldLength = 255, Caption = "Datecode Purchase", Importance = 206)]
        public VarString datecode_purchaseVar;

        [CoreVarVal("inventory_link_uid", "String", TheFieldLength = 255, Caption = "Inventory Link Uid", Importance = 207)]
        public VarString inventory_link_uidVar;

        [CoreVarVal("inventory_link_caption", "String", TheFieldLength = 255, Caption = "Inventory Link Caption", Importance = 208)]
        public VarString inventory_link_captionVar;

        [CoreVarVal("po_option_number", "String", TheFieldLength = 255, Caption = "Po Option Number", Importance = 209)]
        public VarString po_option_numberVar;

        [CoreVarVal("po_option", "String", TheFieldLength = 255, Caption = "Po Option", Importance = 210)]
        public VarString po_optionVar;

        [CoreVarVal("purchased_as_other", "Boolean", Caption = "Purchased As Other", Importance = 211)]
        public VarBoolean purchased_as_otherVar;

        [CoreVarVal("purchased_as_number", "String", TheFieldLength = 255, Caption = "Purchased As Number", Importance = 212)]
        public VarString purchased_as_numberVar;

        [CoreVarVal("part_number_stripped", "String", TheFieldLength = 255, Caption = "Part Number Stripped", Importance = 213)]
        public VarString part_number_strippedVar;

        [CoreVarVal("purchased_as_stripped", "String", TheFieldLength = 255, Caption = "Purchased As Stripped", Importance = 214)]
        public VarString purchased_as_strippedVar;

        [CoreVarVal("service_agent_uid", "String", TheFieldLength = 255, Caption = "Service Agent Uid", Importance = 215)]
        public VarString service_agent_uidVar;

        [CoreVarVal("service_agent_name", "String", TheFieldLength = 255, Caption = "Service Agent Name", Importance = 216)]
        public VarString service_agent_nameVar;

        [CoreVarVal("charge_service_to_customer", "Boolean", Caption = "Charge Service To Customer", Importance = 217)]
        public VarBoolean charge_service_to_customerVar;

        [CoreVarVal("qb_sent_purchase", "Boolean", Caption = "Qb Sent Purchase", Importance = 218)]
        public VarBoolean qb_sent_purchaseVar;

        [CoreVarVal("customer_po_number", "String", TheFieldLength = 255, Caption = "Customer Po Number", Importance = 219)]
        public VarString customer_po_numberVar;

        [CoreVarVal("qb_sent_service", "Boolean", Caption = "Qb Sent Service", Importance = 220)]
        public VarBoolean qb_sent_serviceVar;

        [CoreVarVal("put_away_rma", "Boolean", Caption = "Put Away Rma", Importance = 221)]
        public VarBoolean put_away_rmaVar;

        [CoreVarVal("needs_purchasing", "Boolean", Caption = "Needs Purchasing", Importance = 197)]
        public VarBoolean needs_purchasingVar;

        [CoreVarVal("currency_name_price", "String", Caption = "Price Currency", Importance = 205)]
        public VarString currency_name_priceVar;

        [CoreVarVal("exchange_rate_price", "Double", Caption = "Price Exchange Rate", Importance = 206)]
        public VarDouble exchange_rate_priceVar;

        [CoreVarVal("currency_name_cost", "String", Caption = "Cost Currency", Importance = 207)]
        public VarString currency_name_costVar;

        [CoreVarVal("exchange_rate_cost", "Double", Caption = "Cost Exchange Rate", Importance = 208)]
        public VarDouble exchange_rate_costVar;

        [CoreVarVal("unit_price_exchanged", "Double", Caption = "Exchanged Unit Price", Importance = 209)]
        public VarDouble unit_price_exchangedVar;

        [CoreVarVal("total_price_exchanged", "Double", Caption = "Exchanged Total Price", Importance = 210)]
        public VarDouble total_price_exchangedVar;

        [CoreVarVal("unit_cost_exchanged", "Double", Caption = "Exchanged Unit Cost", Importance = 211)]
        public VarDouble unit_cost_exchangedVar;

        [CoreVarVal("total_cost_exchanged", "Double", Caption = "Exchanged Total Cost", Importance = 212)]
        public VarDouble total_cost_exchangedVar;

        [CoreVarVal("unit_price_print", "String", Caption = "Unit Price Print", Importance = 213)]
        public VarString unit_price_printVar;

        [CoreVarVal("total_price_print", "String", Caption = "Total Price Print", Importance = 214)]
        public VarString total_price_printVar;

        [CoreVarVal("unit_cost_print", "String", Caption = "Unit Cost Print", Importance = 215)]
        public VarString unit_cost_printVar;

        [CoreVarVal("total_cost_print", "String", Caption = "Total Cost Print", Importance = 216)]
        public VarString total_cost_printVar;

        [CoreVarVal("unit_price_rma_exchanged", "Double", Caption = "Rma Unit Exchanged", Importance = 217)]
        public VarDouble unit_price_rma_exchangedVar;

        [CoreVarVal("unit_price_vendrma_exchanged", "Double", Caption = "Vrma Unit Exchanged", Importance = 218)]
        public VarDouble unit_price_vendrma_exchangedVar;

        [CoreVarVal("total_price_rma_exchanged", "Double", Caption = "Rma Total Exchanged", Importance = 219)]
        public VarDouble total_price_rma_exchangedVar;

        [CoreVarVal("total_price_vendrma_exchanged", "Double", Caption = "Vrma Total Exchanged", Importance = 220)]
        public VarDouble total_price_vendrma_exchangedVar;

        [CoreVarVal("unit_price_rma_print", "String", Caption = "Rma Unit Print", Importance = 221)]
        public VarString unit_price_rma_printVar;

        [CoreVarVal("unit_price_vendrma_print", "String", Caption = "Vrma Unit Print", Importance = 222)]
        public VarString unit_price_vendrma_printVar;

        [CoreVarVal("total_price_rma_print", "String", Caption = "Rma Total Print", Importance = 223)]
        public VarString total_price_rma_printVar;

        [CoreVarVal("total_price_vendrma_print", "String", Caption = "Vrma Total Print", Importance = 224)]
        public VarString total_price_vendrma_printVar;

        [CoreVarVal("needs_post_put_away", "Boolean", Caption = "Needs Post Put Away", Importance = 225)]
        public VarBoolean needs_post_put_awayVar;

        [CoreVarVal("exchange_rate_rma", "Double", Caption = "Exchange Rate Rma", Importance = 226)]
        public VarDouble exchange_rate_rmaVar;

        [CoreVarVal("exchange_rate_vendrma", "Double", Caption = "Exchange Rate Vendrma", Importance = 227)]
        public VarDouble exchange_rate_vendrmaVar;

        [CoreVarVal("needs_post_ship", "Boolean", Caption = "Needs Post Ship", Importance = 228)]
        public VarBoolean needs_post_shipVar;

        [CoreVarVal("is_consumption", "Boolean", Caption = "Is Consumption", Importance = 229)]
        public VarBoolean is_consumptionVar;

        [CoreVarVal("line_type", "String", Caption = "Line Type", Importance = 230)]
        public VarString line_typeVar;

        [CoreVarVal("paid_amount_rma", "Double", Caption = "Paid Amount Rma", Importance = 231)]
        public VarDouble paid_amount_rmaVar;

        [CoreVarVal("paid_date_rma", "DateTime", Caption = "Paid Date Rma", Importance = 232)]
        public VarDateTime paid_date_rmaVar;

        [CoreVarVal("paid_amount_vendrma", "Double", Caption = "Paid Amount Vendrma", Importance = 233)]
        public VarDouble paid_amount_vendrmaVar;

        [CoreVarVal("paid_date_vendrma", "DateTime", Caption = "Paid Date Vendrma", Importance = 234)]
        public VarDateTime paid_date_vendrmaVar;

        [CoreVarVal("purchase_expense_account_name", "String", Caption = "Purchase Expense Account Name", Importance = 235)]
        public VarString purchase_expense_account_nameVar;

        [CoreVarVal("purchase_expense_account_uid", "String", Caption = "Purchase Expense Account Uid", Importance = 236)]
        public VarString purchase_expense_account_uidVar;

        [CoreVarVal("sales_income_account_name", "String", Caption = "Sales Income Account Name", Importance = 237)]
        public VarString sales_income_account_nameVar;

        [CoreVarVal("sales_income_account_uid", "String", Caption = "Sales Income Account Uid", Importance = 238)]
        public VarString sales_income_account_uidVar;

        [CoreVarVal("posted_invoice", "Boolean", Caption = "Posted Invoice", Importance = 239)]
        public VarBoolean posted_invoiceVar;

        [CoreVarVal("posted_purchase", "Boolean", Caption = "Posted Purchase", Importance = 240)]
        public VarBoolean posted_purchaseVar;

        [CoreVarVal("posted_rma", "Boolean", Caption = "Posted Rma", Importance = 241)]
        public VarBoolean posted_rmaVar;

        [CoreVarVal("posted_vendrma", "Boolean", Caption = "Posted Vendrma", Importance = 242)]
        public VarBoolean posted_vendrmaVar;

        [CoreVarVal("posted_service", "Boolean", Caption = "Posted Service", Importance = 243)]
        public VarBoolean posted_serviceVar;

        [CoreVarVal("cc_charge_type", "String", Caption = "Cc Charge Type", Importance = 244)]
        public VarString cc_charge_typeVar;

        [CoreVarVal("customer_dock_date_initial", "DateTime", Caption = "Initial Customer Dock Date", Importance = 245)]
        public VarDateTime customer_dock_date_initialVar;

        [CoreVarVal("total_fees", "Double", Caption = "Total Fees", Importance = 246)]
        public VarDouble total_feesVar;

        [CoreVarVal("is_RMA_IHS", "Boolean", Caption = "RMA - In House Service", Importance = 247)]
        public VarBoolean is_RMA_IHSVar;

        [CoreVarVal("isvoid_SMCFault", "Boolean", Caption = "Void - SMC Fault", Importance = 248)]
        public VarBoolean isvoid_SMCFaultVar;

        [CoreVarVal("unique_id_canceled", "String", TheFieldLength = 255, Caption = "UID Of the original line", Importance = 249)]
        public VarString unique_id_canceledVar;

        [CoreVarVal("insp_id", "String", TheFieldLength = 255, Caption = "IDEA Inspection ID", Importance = 250)]
        public VarString insp_idVar;

        [CoreVarVal("nonconid", "Int32", Caption = "Nonconformance ID", Importance = 251)]
        public VarInt32 nonconidVar;

        [CoreVarVal("bid_partnumber", "String", Caption = "bid partnumber", Importance = 251)]
        public VarString bid_partnumberVar;

        [CoreVarVal("importid", "String", Caption = "importid", Importance = 252)]
        public VarString importidVar;

        [CoreVarVal("quoted_partnumber", "String", Caption = "quoted_partnumber", Importance = 253)]
        public VarString quoted_partnumberVar;

        [CoreVarVal("tbd_cleared_date", "DateTime", Caption = "TBD Cleared Date", Importance = 254)]
        public VarDateTime tbd_cleared_dateVar;

        [CoreVarVal("qc_status", "String", Caption = "qc_status", Importance = 255)]
        public VarString qc_statusVar;

        [CoreVarVal("qb_order_ListID", "String", TheFieldLength = 255, Caption = "QB Order ID", Importance = 256)]
        public VarString qb_order_ListIDVar;

        [CoreVarVal("qb_line_ListID", "String", TheFieldLength = 255, Caption = "QB Line ID", Importance = 257)]
        public VarString qb_line_ListIDVar;

        [CoreVarVal("qb_line_subitem_ListID", "String", TheFieldLength = 255, Caption = "QB MFG List ID", Importance = 258)]
        public VarString qb_line_subitem_ListIDVar;

        [CoreVarVal("qb_line_TxnID", "String", TheFieldLength = 255, Caption = "QB Line Transaction ID", Importance = 258)]
        public VarString qb_line_TxnIDVar;

        [CoreVarVal("qb_line_TxnID_purchase", "String", TheFieldLength = 255, Caption = "QB Line Transaction ID - Purchases", Importance = 258)]
        public VarString qb_line_TxnID_purchaseVar;

        [CoreVarVal("list_acquisition_agent", "String", TheFieldLength = 100, Caption = "List Acquisition Agent", Importance = 146)]
        public VarString list_acquisition_agentVar;

        [CoreVarVal("list_acquisition_agent_uid", "String", TheFieldLength = 100, Caption = "List Acquisition Agent ID", Importance = 146)]
        public VarString list_acquisition_agent_uidVar;

        [CoreVarVal("is_split_commission", "Boolean", Caption = "Is SPlit Commission", Importance = 26)]
        public VarBoolean is_split_commissionVar;


        [CoreVarVal("split_commission_agent_name", "String", TheFieldLength = 200, Importance = 235)]
        public VarString split_commission_agent_nameVar;

        [CoreVarVal("split_commission_agent_uid", "String", TheFieldLength = 200, Importance = 236)]
        public VarString split_commission_agent_uidVar;

        [CoreVarVal("split_commission_type", "String", TheFieldLength = 20, Importance = 237)]
        public VarString split_commission_typeVar;

        [CoreVarVal("split_commission_ID", "String", TheFieldLength = 100, Caption = "Split Commissin Linkage", Importance = 146)]
        public VarString split_commission_IDVar;

        [CoreVarVal("country_of_origin", "String", TheFieldLength = 50, Caption = "Country of Origin", Importance = 238)]
        public VarString country_of_originVar;

        [CoreVarVal("harmonized_tariff_schedule", "String", TheFieldLength = 50, Caption = "Harmonized Tariff Schedule AKA Harmonized Code", Importance = 239)]
        public VarString harmonized_tariff_scheduleVar;

        [CoreVarVal("projected_dock_date", "DateTime", TheFieldLength = 50, Caption = "Realistic Sensible Projected Dock Date", Importance = 240)]
        public VarDateTime projected_dock_dateVar;

        [CoreVarVal("internalpart_vendor_uid", "string", TheFieldLength = 50, Caption = "Unique ID For the internal_vendor part.  Example GCAT linkage to line being tested.", Importance = 241)]
        public VarString internalpart_vendor_uidVar;

        [CoreVarVal("internalpart_vendor", "String", TheFieldLength = 255, Caption = "Vendor Internal Part.  Example GCAT linkage to line being tested.", Importance = 242)]
        public VarString internalpart_vendorVar;

        [CoreVarVal("affiliate_id", "string", TheFieldLength = 50, Caption = "Affiliate ID, usually an email.", Importance = 243)]
        public VarString affiliate_idVar;

        [CoreVarVal("inspection_status", "string", TheFieldLength = 75, Caption = "Inspection status codes that relate to the inspection process", Importance = 244)]
        public VarString inspection_statusVar;

        [CoreVarVal("source", "string", TheFieldLength = 75, Caption = "The source of the line, i.e. what intitiave generated ir, like portal quote", Importance = 245)]
        public VarString sourceVar;

        [CoreVarVal("country_of_origin_vendor", "string", TheFieldLength = 75, Caption = "Country of origin as stated by vendor bid", Importance = 246)]
        public VarString country_of_origin_vendorVar;

        [CoreVarVal("line_validation_status", "string", TheFieldLength = 75, Caption = "Line-level validation status", Importance = 246)]
        public VarString line_validation_statusVar;

        

        public orddet_line_auto()
        {
            StaticInit();
            unit_priceVar = new VarDouble(this, unit_priceAttribute);
            unit_costVar = new VarDouble(this, unit_costAttribute);
            mfg_certificationsVar = new VarBoolean(this, mfg_certificationsAttribute);
            has_cofcVar = new VarBoolean(this, has_cofcAttribute);
            assemblynameVar = new VarString(this, assemblynameAttribute);
            warranty_periodVar = new VarString(this, warranty_periodAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            tracking_invoiceVar = new VarString(this, tracking_invoiceAttribute);
            tracking_purchaseVar = new VarString(this, tracking_purchaseAttribute);
            tracking_rmaVar = new VarString(this, tracking_rmaAttribute);
            tracking_vendrmaVar = new VarString(this, tracking_vendrmaAttribute);
            tracking_service_inVar = new VarString(this, tracking_service_inAttribute);
            tracking_service_outVar = new VarString(this, tracking_service_outAttribute);
            shipvia_invoiceVar = new VarString(this, shipvia_invoiceAttribute);
            shipvia_purchaseVar = new VarString(this, shipvia_purchaseAttribute);
            shipvia_rmaVar = new VarString(this, shipvia_rmaAttribute);
            shipvia_vendrmaVar = new VarString(this, shipvia_vendrmaAttribute);
            shipvia_service_outVar = new VarString(this, shipvia_service_outAttribute);
            shipvia_service_inVar = new VarString(this, shipvia_service_inAttribute);
            shippingaccount_invoiceVar = new VarString(this, shippingaccount_invoiceAttribute);
            shippingaccount_purchaseVar = new VarString(this, shippingaccount_purchaseAttribute);
            shippingaccount_rmaVar = new VarString(this, shippingaccount_rmaAttribute);
            shippingaccount_vendrmaVar = new VarString(this, shippingaccount_vendrmaAttribute);
            shippingaccount_service_outVar = new VarString(this, shippingaccount_service_outAttribute);
            shippingaccount_service_inVar = new VarString(this, shippingaccount_service_inAttribute);
            customer_uidVar = new VarString(this, customer_uidAttribute);
            customer_nameVar = new VarString(this, customer_nameAttribute);
            customer_contact_uidVar = new VarString(this, customer_contact_uidAttribute);
            customer_contact_nameVar = new VarString(this, customer_contact_nameAttribute);
            vendor_uidVar = new VarString(this, vendor_uidAttribute);
            vendor_nameVar = new VarString(this, vendor_nameAttribute);
            vendor_contact_uidVar = new VarString(this, vendor_contact_uidAttribute);
            vendor_contact_nameVar = new VarString(this, vendor_contact_nameAttribute);
            service_vendor_uidVar = new VarString(this, service_vendor_uidAttribute);
            service_vendor_nameVar = new VarString(this, service_vendor_nameAttribute);
            service_vendor_contact_uidVar = new VarString(this, service_vendor_contact_uidAttribute);
            service_vendor_contact_nameVar = new VarString(this, service_vendor_contact_nameAttribute);
            shipping_fee_invoiceVar = new VarDouble(this, shipping_fee_invoiceAttribute);
            shipping_fee_purchaseVar = new VarDouble(this, shipping_fee_purchaseAttribute);
            shipping_fee_rmaVar = new VarDouble(this, shipping_fee_rmaAttribute);
            shipping_fee_vendrmaVar = new VarDouble(this, shipping_fee_vendrmaAttribute);
            shipping_fee_service_outVar = new VarDouble(this, shipping_fee_service_outAttribute);
            shipping_fee_service_inVar = new VarDouble(this, shipping_fee_service_inAttribute);
            charge1_fee_invoiceVar = new VarDouble(this, charge1_fee_invoiceAttribute);
            charge1_fee_invoice_captionVar = new VarString(this, charge1_fee_invoice_captionAttribute);
            charge1_fee_purchaseVar = new VarDouble(this, charge1_fee_purchaseAttribute);
            charge1_fee_purchase_captionVar = new VarString(this, charge1_fee_purchase_captionAttribute);
            charge1_fee_rmaVar = new VarDouble(this, charge1_fee_rmaAttribute);
            charge1_fee_rma_captionVar = new VarString(this, charge1_fee_rma_captionAttribute);
            charge1_fee_vendrmaVar = new VarDouble(this, charge1_fee_vendrmaAttribute);
            charge1_fee_vendrma_captionVar = new VarString(this, charge1_fee_vendrma_captionAttribute);
            charge1_fee_service_outVar = new VarDouble(this, charge1_fee_service_outAttribute);
            charge1_fee_service_out_captionVar = new VarString(this, charge1_fee_service_out_captionAttribute);
            charge1_fee_service_inVar = new VarDouble(this, charge1_fee_service_inAttribute);
            charge1_fee_service_in_captionVar = new VarString(this, charge1_fee_service_in_captionAttribute);
            charge2_fee_invoiceVar = new VarDouble(this, charge2_fee_invoiceAttribute);
            charge2_fee_invoice_captionVar = new VarString(this, charge2_fee_invoice_captionAttribute);
            charge2_fee_purchaseVar = new VarDouble(this, charge2_fee_purchaseAttribute);
            charge2_fee_purchase_captionVar = new VarString(this, charge2_fee_purchase_captionAttribute);
            charge2_fee_rmaVar = new VarDouble(this, charge2_fee_rmaAttribute);
            charge2_fee_rma_captionVar = new VarString(this, charge2_fee_rma_captionAttribute);
            charge2_fee_vendrmaVar = new VarDouble(this, charge2_fee_vendrmaAttribute);
            charge2_fee_vendrma_captionVar = new VarString(this, charge2_fee_vendrma_captionAttribute);
            charge2_fee_service_outVar = new VarDouble(this, charge2_fee_service_outAttribute);
            charge2_fee_service_out_captionVar = new VarString(this, charge2_fee_service_out_captionAttribute);
            charge2_fee_service_inVar = new VarDouble(this, charge2_fee_service_inAttribute);
            charge2_fee_service_in_captionVar = new VarString(this, charge2_fee_service_in_captionAttribute);
            seller_uidVar = new VarString(this, seller_uidAttribute);
            seller_nameVar = new VarString(this, seller_nameAttribute);
            buyer_uidVar = new VarString(this, buyer_uidAttribute);
            buyer_nameVar = new VarString(this, buyer_nameAttribute);
            orderid_salesVar = new VarString(this, orderid_salesAttribute);
            orderid_purchaseVar = new VarString(this, orderid_purchaseAttribute);
            orderid_invoiceVar = new VarString(this, orderid_invoiceAttribute);
            orderid_rmaVar = new VarString(this, orderid_rmaAttribute);
            orderid_vendrmaVar = new VarString(this, orderid_vendrmaAttribute);
            orderid_serviceVar = new VarString(this, orderid_serviceAttribute);
            linecode_salesVar = new VarInt32(this, linecode_salesAttribute);
            linecode_purchaseVar = new VarInt32(this, linecode_purchaseAttribute);
            linecode_invoiceVar = new VarInt32(this, linecode_invoiceAttribute);
            linecode_rmaVar = new VarInt32(this, linecode_rmaAttribute);
            linecode_vendrmaVar = new VarInt32(this, linecode_vendrmaAttribute);
            orderdate_salesVar = new VarDateTime(this, orderdate_salesAttribute);
            orderdate_purchaseVar = new VarDateTime(this, orderdate_purchaseAttribute);
            orderdate_invoiceVar = new VarDateTime(this, orderdate_invoiceAttribute);
            orderdate_rmaVar = new VarDateTime(this, orderdate_rmaAttribute);
            orderdate_vendrmaVar = new VarDateTime(this, orderdate_vendrmaAttribute);
            orderdate_serviceVar = new VarDateTime(this, orderdate_serviceAttribute);
            qcid_purchaseVar = new VarString(this, qcid_purchaseAttribute);
            qcid_invoiceVar = new VarString(this, qcid_invoiceAttribute);
            qcid_rmaVar = new VarString(this, qcid_rmaAttribute);
            qcid_vendrmaVar = new VarString(this, qcid_vendrmaAttribute);
            qcid_service_outVar = new VarString(this, qcid_service_outAttribute);
            qcid_service_inVar = new VarString(this, qcid_service_inAttribute);
            receive_date_dueVar = new VarDateTime(this, receive_date_dueAttribute);
            receive_date_actualVar = new VarDateTime(this, receive_date_actualAttribute);
            ship_date_dueVar = new VarDateTime(this, ship_date_dueAttribute);
            ship_date_actualVar = new VarDateTime(this, ship_date_actualAttribute);
            receive_agent_uidVar = new VarString(this, receive_agent_uidAttribute);
            receive_agent_nameVar = new VarString(this, receive_agent_nameAttribute);
            ship_agent_uidVar = new VarString(this, ship_agent_uidAttribute);
            ship_agent_nameVar = new VarString(this, ship_agent_nameAttribute);
            ship_noteVar = new VarString(this, ship_noteAttribute);
            receive_noteVar = new VarString(this, receive_noteAttribute);
            total_priceVar = new VarDouble(this, total_priceAttribute);
            total_costVar = new VarDouble(this, total_costAttribute);
            gross_profitVar = new VarDouble(this, gross_profitAttribute);
            net_profitVar = new VarDouble(this, net_profitAttribute);
            paid_date_serviceVar = new VarDateTime(this, paid_date_serviceAttribute);
            paid_date_purchaseVar = new VarDateTime(this, paid_date_purchaseAttribute);
            paid_amount_serviceVar = new VarDouble(this, paid_amount_serviceAttribute);
            paid_amount_purchaseVar = new VarDouble(this, paid_amount_purchaseAttribute);
            paid_date_invoiceVar = new VarDateTime(this, paid_date_invoiceAttribute);
            paid_amount_invoiceVar = new VarDouble(this, paid_amount_invoiceAttribute);
            ordernumber_salesVar = new VarString(this, ordernumber_salesAttribute);
            ordernumber_purchaseVar = new VarString(this, ordernumber_purchaseAttribute);
            ordernumber_serviceVar = new VarString(this, ordernumber_serviceAttribute);
            ordernumber_rmaVar = new VarString(this, ordernumber_rmaAttribute);
            ordernumber_vendrmaVar = new VarString(this, ordernumber_vendrmaAttribute);
            notes_salesVar = new VarText(this, notes_salesAttribute);
            notes_purchaseVar = new VarText(this, notes_purchaseAttribute);
            notes_rmaVar = new VarText(this, notes_rmaAttribute);
            notes_vendrmaVar = new VarText(this, notes_vendrmaAttribute);
            receive_locationVar = new VarString(this, receive_locationAttribute);
            quantity_packedVar = new VarInt32(this, quantity_packedAttribute);
            orderid_quoteVar = new VarString(this, orderid_quoteAttribute);
            ordernumber_quoteVar = new VarString(this, ordernumber_quoteAttribute);
            quote_line_uidVar = new VarString(this, quote_line_uidAttribute);
            ordernumber_invoiceVar = new VarString(this, ordernumber_invoiceAttribute);
            was_shippedVar = new VarBoolean(this, was_shippedAttribute);
            was_receivedVar = new VarBoolean(this, was_receivedAttribute);
            was_service_outVar = new VarBoolean(this, was_service_outAttribute);
            was_service_inVar = new VarBoolean(this, was_service_inAttribute);
            was_rmaVar = new VarBoolean(this, was_rmaAttribute);
            was_vendrmaVar = new VarBoolean(this, was_vendrmaAttribute);
            was_rma_receivedVar = new VarBoolean(this, was_rma_receivedAttribute);
            was_vendrma_shippedVar = new VarBoolean(this, was_vendrma_shippedAttribute);
            stocktype_receiveVar = new VarString(this, stocktype_receiveAttribute);
            legacyid_salesVar = new VarString(this, legacyid_salesAttribute);
            legacyid_purchaseVar = new VarString(this, legacyid_purchaseAttribute);
            legacyid_serviceVar = new VarString(this, legacyid_serviceAttribute);
            legacyid_invoiceVar = new VarString(this, legacyid_invoiceAttribute);
            legacyid_rmaVar = new VarString(this, legacyid_rmaAttribute);
            legacyid_vendrmaVar = new VarString(this, legacyid_vendrmaAttribute);
            was_purchaseVar = new VarBoolean(this, was_purchaseAttribute);
            was_invoiceVar = new VarBoolean(this, was_invoiceAttribute);
            quantity_unpackedVar = new VarInt32(this, quantity_unpackedAttribute);
            quantity_packed_serviceVar = new VarInt32(this, quantity_packed_serviceAttribute);
            quantity_unpacked_serviceVar = new VarInt32(this, quantity_unpacked_serviceAttribute);
            quantity_packed_vendrmaVar = new VarInt32(this, quantity_packed_vendrmaAttribute);
            quantity_unpacked_rmaVar = new VarInt32(this, quantity_unpacked_rmaAttribute);
            linecode_serviceVar = new VarInt32(this, linecode_serviceAttribute);
            unit_price_vendrmaVar = new VarDouble(this, unit_price_vendrmaAttribute);
            total_price_vendrmaVar = new VarDouble(this, total_price_vendrmaAttribute);
            unit_price_rmaVar = new VarDouble(this, unit_price_rmaAttribute);
            total_price_rmaVar = new VarDouble(this, total_price_rmaAttribute);
            put_awayVar = new VarBoolean(this, put_awayAttribute);
            put_away_dateVar = new VarDateTime(this, put_away_dateAttribute);
            put_away_userVar = new VarString(this, put_away_userAttribute);
            service_costVar = new VarDouble(this, service_costAttribute);
            service_leadtimeVar = new VarString(this, service_leadtimeAttribute);
            is_rma_replacementVar = new VarBoolean(this, is_rma_replacementAttribute);
            total_deductionVar = new VarDouble(this, total_deductionAttribute);
            vendrma_will_refundVar = new VarBoolean(this, vendrma_will_refundAttribute);
            rma_subtractionVar = new VarDouble(this, rma_subtractionAttribute);
            ship_date_service_dueVar = new VarDateTime(this, ship_date_service_dueAttribute);
            ship_date_service_actualVar = new VarDateTime(this, ship_date_service_actualAttribute);
            ship_date_vendrma_dueVar = new VarDateTime(this, ship_date_vendrma_dueAttribute);
            ship_date_vendrma_actualVar = new VarDateTime(this, ship_date_vendrma_actualAttribute);
            receive_date_service_dueVar = new VarDateTime(this, receive_date_service_dueAttribute);
            receive_date_service_actualVar = new VarDateTime(this, receive_date_service_actualAttribute);
            receive_date_rma_dueVar = new VarDateTime(this, receive_date_rma_dueAttribute);
            receive_date_rma_actualVar = new VarDateTime(this, receive_date_rma_actualAttribute);
            ship_date_nextVar = new VarDateTime(this, ship_date_nextAttribute);
            receive_date_nextVar = new VarDateTime(this, receive_date_nextAttribute);
            shipvia_nextVar = new VarString(this, shipvia_nextAttribute);
            shipvia_receive_nextVar = new VarString(this, shipvia_receive_nextAttribute);
            ship_to_nextVar = new VarString(this, ship_to_nextAttribute);
            receive_from_nextVar = new VarString(this, receive_from_nextAttribute);
            drop_shipVar = new VarBoolean(this, drop_shipAttribute);
            drop_ship_commentsVar = new VarText(this, drop_ship_commentsAttribute);
            internal_customerVar = new VarString(this, internal_customerAttribute);
            line_group_idVar = new VarString(this, line_group_idAttribute);
            rohs_info_vendorVar = new VarString(this, rohs_info_vendorAttribute);
            customer_dock_dateVar = new VarDateTime(this, customer_dock_dateAttribute);
            status_captionVar = new VarString(this, status_captionAttribute);
            datecode_purchaseVar = new VarString(this, datecode_purchaseAttribute);
            inventory_link_uidVar = new VarString(this, inventory_link_uidAttribute);
            inventory_link_captionVar = new VarString(this, inventory_link_captionAttribute);
            po_option_numberVar = new VarString(this, po_option_numberAttribute);
            po_optionVar = new VarString(this, po_optionAttribute);
            purchased_as_otherVar = new VarBoolean(this, purchased_as_otherAttribute);
            purchased_as_numberVar = new VarString(this, purchased_as_numberAttribute);
            part_number_strippedVar = new VarString(this, part_number_strippedAttribute);
            purchased_as_strippedVar = new VarString(this, purchased_as_strippedAttribute);
            service_agent_uidVar = new VarString(this, service_agent_uidAttribute);
            service_agent_nameVar = new VarString(this, service_agent_nameAttribute);
            charge_service_to_customerVar = new VarBoolean(this, charge_service_to_customerAttribute);
            qb_sent_purchaseVar = new VarBoolean(this, qb_sent_purchaseAttribute);
            customer_po_numberVar = new VarString(this, customer_po_numberAttribute);
            qb_sent_serviceVar = new VarBoolean(this, qb_sent_serviceAttribute);
            put_away_rmaVar = new VarBoolean(this, put_away_rmaAttribute);
            needs_purchasingVar = new VarBoolean(this, needs_purchasingAttribute);
            currency_name_priceVar = new VarString(this, currency_name_priceAttribute);
            exchange_rate_priceVar = new VarDouble(this, exchange_rate_priceAttribute);
            currency_name_costVar = new VarString(this, currency_name_costAttribute);
            exchange_rate_costVar = new VarDouble(this, exchange_rate_costAttribute);
            unit_price_exchangedVar = new VarDouble(this, unit_price_exchangedAttribute);
            total_price_exchangedVar = new VarDouble(this, total_price_exchangedAttribute);
            unit_cost_exchangedVar = new VarDouble(this, unit_cost_exchangedAttribute);
            total_cost_exchangedVar = new VarDouble(this, total_cost_exchangedAttribute);
            unit_price_printVar = new VarString(this, unit_price_printAttribute);
            total_price_printVar = new VarString(this, total_price_printAttribute);
            unit_cost_printVar = new VarString(this, unit_cost_printAttribute);
            total_cost_printVar = new VarString(this, total_cost_printAttribute);
            unit_price_rma_exchangedVar = new VarDouble(this, unit_price_rma_exchangedAttribute);
            unit_price_vendrma_exchangedVar = new VarDouble(this, unit_price_vendrma_exchangedAttribute);
            total_price_rma_exchangedVar = new VarDouble(this, total_price_rma_exchangedAttribute);
            total_price_vendrma_exchangedVar = new VarDouble(this, total_price_vendrma_exchangedAttribute);
            unit_price_rma_printVar = new VarString(this, unit_price_rma_printAttribute);
            unit_price_vendrma_printVar = new VarString(this, unit_price_vendrma_printAttribute);
            total_price_rma_printVar = new VarString(this, total_price_rma_printAttribute);
            total_price_vendrma_printVar = new VarString(this, total_price_vendrma_printAttribute);
            needs_post_put_awayVar = new VarBoolean(this, needs_post_put_awayAttribute);
            exchange_rate_rmaVar = new VarDouble(this, exchange_rate_rmaAttribute);
            exchange_rate_vendrmaVar = new VarDouble(this, exchange_rate_vendrmaAttribute);
            needs_post_shipVar = new VarBoolean(this, needs_post_shipAttribute);
            is_consumptionVar = new VarBoolean(this, is_consumptionAttribute);
            line_typeVar = new VarString(this, line_typeAttribute);
            paid_amount_rmaVar = new VarDouble(this, paid_amount_rmaAttribute);
            paid_date_rmaVar = new VarDateTime(this, paid_date_rmaAttribute);
            paid_amount_vendrmaVar = new VarDouble(this, paid_amount_vendrmaAttribute);
            paid_date_vendrmaVar = new VarDateTime(this, paid_date_vendrmaAttribute);
            purchase_expense_account_nameVar = new VarString(this, purchase_expense_account_nameAttribute);
            purchase_expense_account_uidVar = new VarString(this, purchase_expense_account_uidAttribute);
            sales_income_account_nameVar = new VarString(this, sales_income_account_nameAttribute);
            sales_income_account_uidVar = new VarString(this, sales_income_account_uidAttribute);
            posted_invoiceVar = new VarBoolean(this, posted_invoiceAttribute);
            posted_purchaseVar = new VarBoolean(this, posted_purchaseAttribute);
            posted_rmaVar = new VarBoolean(this, posted_rmaAttribute);
            posted_vendrmaVar = new VarBoolean(this, posted_vendrmaAttribute);
            posted_serviceVar = new VarBoolean(this, posted_serviceAttribute);
            cc_charge_typeVar = new VarString(this, cc_charge_typeAttribute);
            customer_dock_date_initialVar = new VarDateTime(this, customer_dock_date_initialAttribute);
            total_feesVar = new VarDouble(this, total_feesAttribute);
            is_RMA_IHSVar = new VarBoolean(this, is_RMA_IHSAttribute);
            isvoid_SMCFaultVar = new VarBoolean(this, isvoid_SMCFaultAttribute);
            unique_id_canceledVar = new VarString(this, unique_id_canceledAttribute);
            insp_idVar = new VarString(this, insp_idAttribute);
            nonconidVar = new VarInt32(this, nonconidAttribute);
            bid_partnumberVar = new VarString(this, bid_partnumberAttribute);
            importidVar = new VarString(this, importidAttribute);
            quoted_partnumberVar = new VarString(this, quoted_partnumberAttribute);
            tbd_cleared_dateVar = new VarDateTime(this, tbd_cleared_dateAttribute);
            qc_statusVar = new VarString(this, qc_statusAttribute);
            qb_order_ListIDVar = new VarString(this, qb_order_ListIDAttribute);
            qb_line_ListIDVar = new VarString(this, qb_line_ListIDAttribute);
            qb_line_TxnIDVar = new VarString(this, qb_line_TxnIDAttribute);
            qb_line_subitem_ListIDVar = new VarString(this, qb_line_subitem_ListIDAttribute);
            qb_line_TxnID_purchaseVar = new VarString(this, qb_line_TxnID_purchaseAttribute);
            list_acquisition_agentVar = new VarString(this, list_acquisition_agentAttribute);
            list_acquisition_agent_uidVar = new VarString(this, list_acquisition_agent_uidAttribute);
            is_split_commissionVar = new VarBoolean(this, is_split_commissionAttribute);
            split_commission_agent_nameVar = new VarString(this, split_commission_agent_nameAttribute);
            split_commission_agent_uidVar = new VarString(this, split_commission_agent_uidAttribute);
            split_commission_typeVar = new VarString(this, split_commission_typeAttribute);
            split_commission_IDVar = new VarString(this, split_commission_IDAttribute);
            country_of_originVar = new VarString(this, country_of_originAttribute);
            harmonized_tariff_scheduleVar = new VarString(this, harmonized_tariff_scheduleAttribute);
            projected_dock_dateVar = new VarDateTime(this, projected_dock_dateAttribute);
            internalpart_vendor_uidVar = new VarString(this, internalpart_vendor_uidAttribute);
            internalpart_vendorVar = new VarString(this, internalpart_vendorAttribute);
            affiliate_idVar = new VarString(this, affiliate_idAttribute);
            inspection_statusVar = new VarString(this, inspection_statusAttribute);
            sourceVar = new VarString(this, sourceAttribute);
            country_of_origin_vendorVar = new VarString(this, country_of_origin_vendorAttribute);
            line_validation_statusVar = new VarString(this, line_validation_statusAttribute);
            

        }

        public override string ClassId
        { get { return "orddet_line"; } }

        public Double unit_price
        {
            get { return (Double)unit_priceVar.Value; }
            set { unit_priceVar.Value = value; }
        }

        public Double unit_cost
        {
            get { return (Double)unit_costVar.Value; }
            set { unit_costVar.Value = value; }
        }

        public Boolean mfg_certifications
        {
            get { return (Boolean)mfg_certificationsVar.Value; }
            set { mfg_certificationsVar.Value = value; }
        }

        public Boolean has_cofc
        {
            get { return (Boolean)has_cofcVar.Value; }
            set { has_cofcVar.Value = value; }
        }

        public String assemblyname
        {
            get { return (String)assemblynameVar.Value; }
            set { assemblynameVar.Value = value; }
        }

        public String warranty_period
        {
            get { return (String)warranty_periodVar.Value; }
            set { warranty_periodVar.Value = value; }
        }

        public String abs_type
        {
            get { return (String)abs_typeVar.Value; }
            set { abs_typeVar.Value = value; }
        }

        public String tracking_invoice
        {
            get { return (String)tracking_invoiceVar.Value; }
            set { tracking_invoiceVar.Value = value; }
        }

        public String tracking_purchase
        {
            get { return (String)tracking_purchaseVar.Value; }
            set { tracking_purchaseVar.Value = value; }
        }

        public String tracking_rma
        {
            get { return (String)tracking_rmaVar.Value; }
            set { tracking_rmaVar.Value = value; }
        }

        public String tracking_vendrma
        {
            get { return (String)tracking_vendrmaVar.Value; }
            set { tracking_vendrmaVar.Value = value; }
        }

        public String tracking_service_in
        {
            get { return (String)tracking_service_inVar.Value; }
            set { tracking_service_inVar.Value = value; }
        }

        public String tracking_service_out
        {
            get { return (String)tracking_service_outVar.Value; }
            set { tracking_service_outVar.Value = value; }
        }

        public String shipvia_invoice
        {
            get { return (String)shipvia_invoiceVar.Value; }
            set { shipvia_invoiceVar.Value = value; }
        }

        public String shipvia_purchase
        {
            get { return (String)shipvia_purchaseVar.Value; }
            set { shipvia_purchaseVar.Value = value; }
        }

        public String shipvia_rma
        {
            get { return (String)shipvia_rmaVar.Value; }
            set { shipvia_rmaVar.Value = value; }
        }

        public String shipvia_vendrma
        {
            get { return (String)shipvia_vendrmaVar.Value; }
            set { shipvia_vendrmaVar.Value = value; }
        }

        public String shipvia_service_out
        {
            get { return (String)shipvia_service_outVar.Value; }
            set { shipvia_service_outVar.Value = value; }
        }

        public String shipvia_service_in
        {
            get { return (String)shipvia_service_inVar.Value; }
            set { shipvia_service_inVar.Value = value; }
        }

        public String shippingaccount_invoice
        {
            get { return (String)shippingaccount_invoiceVar.Value; }
            set { shippingaccount_invoiceVar.Value = value; }
        }

        public String shippingaccount_purchase
        {
            get { return (String)shippingaccount_purchaseVar.Value; }
            set { shippingaccount_purchaseVar.Value = value; }
        }

        public String shippingaccount_rma
        {
            get { return (String)shippingaccount_rmaVar.Value; }
            set { shippingaccount_rmaVar.Value = value; }
        }

        public String shippingaccount_vendrma
        {
            get { return (String)shippingaccount_vendrmaVar.Value; }
            set { shippingaccount_vendrmaVar.Value = value; }
        }

        public String shippingaccount_service_out
        {
            get { return (String)shippingaccount_service_outVar.Value; }
            set { shippingaccount_service_outVar.Value = value; }
        }

        public String shippingaccount_service_in
        {
            get { return (String)shippingaccount_service_inVar.Value; }
            set { shippingaccount_service_inVar.Value = value; }
        }

        public String customer_uid
        {
            get { return (String)customer_uidVar.Value; }
            set { customer_uidVar.Value = value; }
        }

        public String customer_name
        {
            get { return (String)customer_nameVar.Value; }
            set { customer_nameVar.Value = value; }
        }

        public String customer_contact_uid
        {
            get { return (String)customer_contact_uidVar.Value; }
            set { customer_contact_uidVar.Value = value; }
        }

        public String customer_contact_name
        {
            get { return (String)customer_contact_nameVar.Value; }
            set { customer_contact_nameVar.Value = value; }
        }

        public String vendor_uid
        {
            get { return (String)vendor_uidVar.Value; }
            set { vendor_uidVar.Value = value; }
        }

        public String vendor_name
        {
            get { return (String)vendor_nameVar.Value; }
            set { vendor_nameVar.Value = value; }
        }

        public String vendor_contact_uid
        {
            get { return (String)vendor_contact_uidVar.Value; }
            set { vendor_contact_uidVar.Value = value; }
        }

        public String vendor_contact_name
        {
            get { return (String)vendor_contact_nameVar.Value; }
            set { vendor_contact_nameVar.Value = value; }
        }

        public String service_vendor_uid
        {
            get { return (String)service_vendor_uidVar.Value; }
            set { service_vendor_uidVar.Value = value; }
        }

        public String service_vendor_name
        {
            get { return (String)service_vendor_nameVar.Value; }
            set { service_vendor_nameVar.Value = value; }
        }

        public String service_vendor_contact_uid
        {
            get { return (String)service_vendor_contact_uidVar.Value; }
            set { service_vendor_contact_uidVar.Value = value; }
        }

        public String service_vendor_contact_name
        {
            get { return (String)service_vendor_contact_nameVar.Value; }
            set { service_vendor_contact_nameVar.Value = value; }
        }

        public Double shipping_fee_invoice
        {
            get { return (Double)shipping_fee_invoiceVar.Value; }
            set { shipping_fee_invoiceVar.Value = value; }
        }

        public Double shipping_fee_purchase
        {
            get { return (Double)shipping_fee_purchaseVar.Value; }
            set { shipping_fee_purchaseVar.Value = value; }
        }

        public Double shipping_fee_rma
        {
            get { return (Double)shipping_fee_rmaVar.Value; }
            set { shipping_fee_rmaVar.Value = value; }
        }

        public Double shipping_fee_vendrma
        {
            get { return (Double)shipping_fee_vendrmaVar.Value; }
            set { shipping_fee_vendrmaVar.Value = value; }
        }

        public Double shipping_fee_service_out
        {
            get { return (Double)shipping_fee_service_outVar.Value; }
            set { shipping_fee_service_outVar.Value = value; }
        }

        public Double shipping_fee_service_in
        {
            get { return (Double)shipping_fee_service_inVar.Value; }
            set { shipping_fee_service_inVar.Value = value; }
        }

        public Double charge1_fee_invoice
        {
            get { return (Double)charge1_fee_invoiceVar.Value; }
            set { charge1_fee_invoiceVar.Value = value; }
        }

        public String charge1_fee_invoice_caption
        {
            get { return (String)charge1_fee_invoice_captionVar.Value; }
            set { charge1_fee_invoice_captionVar.Value = value; }
        }

        public Double charge1_fee_purchase
        {
            get { return (Double)charge1_fee_purchaseVar.Value; }
            set { charge1_fee_purchaseVar.Value = value; }
        }

        public String charge1_fee_purchase_caption
        {
            get { return (String)charge1_fee_purchase_captionVar.Value; }
            set { charge1_fee_purchase_captionVar.Value = value; }
        }

        public Double charge1_fee_rma
        {
            get { return (Double)charge1_fee_rmaVar.Value; }
            set { charge1_fee_rmaVar.Value = value; }
        }

        public String charge1_fee_rma_caption
        {
            get { return (String)charge1_fee_rma_captionVar.Value; }
            set { charge1_fee_rma_captionVar.Value = value; }
        }

        public Double charge1_fee_vendrma
        {
            get { return (Double)charge1_fee_vendrmaVar.Value; }
            set { charge1_fee_vendrmaVar.Value = value; }
        }

        public String charge1_fee_vendrma_caption
        {
            get { return (String)charge1_fee_vendrma_captionVar.Value; }
            set { charge1_fee_vendrma_captionVar.Value = value; }
        }

        public Double charge1_fee_service_out
        {
            get { return (Double)charge1_fee_service_outVar.Value; }
            set { charge1_fee_service_outVar.Value = value; }
        }

        public String charge1_fee_service_out_caption
        {
            get { return (String)charge1_fee_service_out_captionVar.Value; }
            set { charge1_fee_service_out_captionVar.Value = value; }
        }

        public Double charge1_fee_service_in
        {
            get { return (Double)charge1_fee_service_inVar.Value; }
            set { charge1_fee_service_inVar.Value = value; }
        }

        public String charge1_fee_service_in_caption
        {
            get { return (String)charge1_fee_service_in_captionVar.Value; }
            set { charge1_fee_service_in_captionVar.Value = value; }
        }

        public Double charge2_fee_invoice
        {
            get { return (Double)charge2_fee_invoiceVar.Value; }
            set { charge2_fee_invoiceVar.Value = value; }
        }

        public String charge2_fee_invoice_caption
        {
            get { return (String)charge2_fee_invoice_captionVar.Value; }
            set { charge2_fee_invoice_captionVar.Value = value; }
        }

        public Double charge2_fee_purchase
        {
            get { return (Double)charge2_fee_purchaseVar.Value; }
            set { charge2_fee_purchaseVar.Value = value; }
        }

        public String charge2_fee_purchase_caption
        {
            get { return (String)charge2_fee_purchase_captionVar.Value; }
            set { charge2_fee_purchase_captionVar.Value = value; }
        }

        public Double charge2_fee_rma
        {
            get { return (Double)charge2_fee_rmaVar.Value; }
            set { charge2_fee_rmaVar.Value = value; }
        }

        public String charge2_fee_rma_caption
        {
            get { return (String)charge2_fee_rma_captionVar.Value; }
            set { charge2_fee_rma_captionVar.Value = value; }
        }

        public Double charge2_fee_vendrma
        {
            get { return (Double)charge2_fee_vendrmaVar.Value; }
            set { charge2_fee_vendrmaVar.Value = value; }
        }

        public String charge2_fee_vendrma_caption
        {
            get { return (String)charge2_fee_vendrma_captionVar.Value; }
            set { charge2_fee_vendrma_captionVar.Value = value; }
        }

        public Double charge2_fee_service_out
        {
            get { return (Double)charge2_fee_service_outVar.Value; }
            set { charge2_fee_service_outVar.Value = value; }
        }

        public String charge2_fee_service_out_caption
        {
            get { return (String)charge2_fee_service_out_captionVar.Value; }
            set { charge2_fee_service_out_captionVar.Value = value; }
        }

        public Double charge2_fee_service_in
        {
            get { return (Double)charge2_fee_service_inVar.Value; }
            set { charge2_fee_service_inVar.Value = value; }
        }

        public String charge2_fee_service_in_caption
        {
            get { return (String)charge2_fee_service_in_captionVar.Value; }
            set { charge2_fee_service_in_captionVar.Value = value; }
        }

        public String seller_uid
        {
            get { return (String)seller_uidVar.Value; }
            set { seller_uidVar.Value = value; }
        }

        public String seller_name
        {
            get { return (String)seller_nameVar.Value; }
            set { seller_nameVar.Value = value; }
        }

        public String buyer_uid
        {
            get { return (String)buyer_uidVar.Value; }
            set { buyer_uidVar.Value = value; }
        }

        public String buyer_name
        {
            get { return (String)buyer_nameVar.Value; }
            set { buyer_nameVar.Value = value; }
        }

        public String orderid_sales
        {
            get { return (String)orderid_salesVar.Value; }
            set { orderid_salesVar.Value = value; }
        }

        public String orderid_purchase
        {
            get { return (String)orderid_purchaseVar.Value; }
            set { orderid_purchaseVar.Value = value; }
        }

        public String orderid_invoice
        {
            get { return (String)orderid_invoiceVar.Value; }
            set { orderid_invoiceVar.Value = value; }
        }

        public String orderid_rma
        {
            get { return (String)orderid_rmaVar.Value; }
            set { orderid_rmaVar.Value = value; }
        }

        public String orderid_vendrma
        {
            get { return (String)orderid_vendrmaVar.Value; }
            set { orderid_vendrmaVar.Value = value; }
        }

        public String orderid_service
        {
            get { return (String)orderid_serviceVar.Value; }
            set { orderid_serviceVar.Value = value; }
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

        public Int32 linecode_invoice
        {
            get { return (Int32)linecode_invoiceVar.Value; }
            set { linecode_invoiceVar.Value = value; }
        }

        public Int32 linecode_rma
        {
            get { return (Int32)linecode_rmaVar.Value; }
            set { linecode_rmaVar.Value = value; }
        }

        public Int32 linecode_vendrma
        {
            get { return (Int32)linecode_vendrmaVar.Value; }
            set { linecode_vendrmaVar.Value = value; }
        }

        public DateTime orderdate_sales
        {
            get { return (DateTime)orderdate_salesVar.Value; }
            set { orderdate_salesVar.Value = value; }
        }

        public DateTime orderdate_purchase
        {
            get { return (DateTime)orderdate_purchaseVar.Value; }
            set { orderdate_purchaseVar.Value = value; }
        }

        public DateTime orderdate_invoice
        {
            get { return (DateTime)orderdate_invoiceVar.Value; }
            set { orderdate_invoiceVar.Value = value; }
        }

        public DateTime orderdate_rma
        {
            get { return (DateTime)orderdate_rmaVar.Value; }
            set { orderdate_rmaVar.Value = value; }
        }

        public DateTime orderdate_vendrma
        {
            get { return (DateTime)orderdate_vendrmaVar.Value; }
            set { orderdate_vendrmaVar.Value = value; }
        }

        public DateTime orderdate_service
        {
            get { return (DateTime)orderdate_serviceVar.Value; }
            set { orderdate_serviceVar.Value = value; }
        }



        public String qcid_purchase
        {
            get { return (String)qcid_purchaseVar.Value; }
            set { qcid_purchaseVar.Value = value; }
        }

        public String qcid_invoice
        {
            get { return (String)qcid_invoiceVar.Value; }
            set { qcid_invoiceVar.Value = value; }
        }

        public String qcid_rma
        {
            get { return (String)qcid_rmaVar.Value; }
            set { qcid_rmaVar.Value = value; }
        }

        public String qcid_vendrma
        {
            get { return (String)qcid_vendrmaVar.Value; }
            set { qcid_vendrmaVar.Value = value; }
        }

        public String qcid_service_out
        {
            get { return (String)qcid_service_outVar.Value; }
            set { qcid_service_outVar.Value = value; }
        }

        public String qcid_service_in
        {
            get { return (String)qcid_service_inVar.Value; }
            set { qcid_service_inVar.Value = value; }
        }

        public DateTime receive_date_due
        {
            get { return (DateTime)receive_date_dueVar.Value; }
            set { receive_date_dueVar.Value = value; }
        }

        public DateTime receive_date_actual
        {
            get { return (DateTime)receive_date_actualVar.Value; }
            set { receive_date_actualVar.Value = value; }
        }

        public DateTime ship_date_due
        {
            get { return (DateTime)ship_date_dueVar.Value; }
            set { ship_date_dueVar.Value = value; }
        }

        public DateTime ship_date_actual
        {
            get { return (DateTime)ship_date_actualVar.Value; }
            set { ship_date_actualVar.Value = value; }
        }

        public String receive_agent_uid
        {
            get { return (String)receive_agent_uidVar.Value; }
            set { receive_agent_uidVar.Value = value; }
        }

        public String receive_agent_name
        {
            get { return (String)receive_agent_nameVar.Value; }
            set { receive_agent_nameVar.Value = value; }
        }

        public String ship_agent_uid
        {
            get { return (String)ship_agent_uidVar.Value; }
            set { ship_agent_uidVar.Value = value; }
        }

        public String ship_agent_name
        {
            get { return (String)ship_agent_nameVar.Value; }
            set { ship_agent_nameVar.Value = value; }
        }

        public String ship_note
        {
            get { return (String)ship_noteVar.Value; }
            set { ship_noteVar.Value = value; }
        }

        public String receive_note
        {
            get { return (String)receive_noteVar.Value; }
            set { receive_noteVar.Value = value; }
        }

        public Double total_price
        {
            get { return (Double)total_priceVar.Value; }
            set { total_priceVar.Value = value; }
        }

        public Double total_cost
        {
            get { return (Double)total_costVar.Value; }
            set { total_costVar.Value = value; }
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

        public DateTime paid_date_service
        {
            get { return (DateTime)paid_date_serviceVar.Value; }
            set { paid_date_serviceVar.Value = value; }
        }

        public DateTime paid_date_purchase
        {
            get { return (DateTime)paid_date_purchaseVar.Value; }
            set { paid_date_purchaseVar.Value = value; }
        }

        public Double paid_amount_service
        {
            get { return (Double)paid_amount_serviceVar.Value; }
            set { paid_amount_serviceVar.Value = value; }
        }

        public Double paid_amount_purchase
        {
            get { return (Double)paid_amount_purchaseVar.Value; }
            set { paid_amount_purchaseVar.Value = value; }
        }

        public DateTime paid_date_invoice
        {
            get { return (DateTime)paid_date_invoiceVar.Value; }
            set { paid_date_invoiceVar.Value = value; }
        }

        public Double paid_amount_invoice
        {
            get { return (Double)paid_amount_invoiceVar.Value; }
            set { paid_amount_invoiceVar.Value = value; }
        }

        public String ordernumber_sales
        {
            get { return (String)ordernumber_salesVar.Value; }
            set { ordernumber_salesVar.Value = value; }
        }

        public String ordernumber_purchase
        {
            get { return (String)ordernumber_purchaseVar.Value; }
            set { ordernumber_purchaseVar.Value = value; }
        }

        public String ordernumber_service
        {
            get { return (String)ordernumber_serviceVar.Value; }
            set { ordernumber_serviceVar.Value = value; }
        }

        public String ordernumber_rma
        {
            get { return (String)ordernumber_rmaVar.Value; }
            set { ordernumber_rmaVar.Value = value; }
        }

        public String ordernumber_vendrma
        {
            get { return (String)ordernumber_vendrmaVar.Value; }
            set { ordernumber_vendrmaVar.Value = value; }
        }

        public String notes_sales
        {
            get { return (String)notes_salesVar.Value; }
            set { notes_salesVar.Value = value; }
        }

        public String notes_purchase
        {
            get { return (String)notes_purchaseVar.Value; }
            set { notes_purchaseVar.Value = value; }
        }

        public String notes_rma
        {
            get { return (String)notes_rmaVar.Value; }
            set { notes_rmaVar.Value = value; }
        }

        public String notes_vendrma
        {
            get { return (String)notes_vendrmaVar.Value; }
            set { notes_vendrmaVar.Value = value; }
        }

        public String receive_location
        {
            get { return (String)receive_locationVar.Value; }
            set { receive_locationVar.Value = value; }
        }

        public Int32 quantity_packed
        {
            get { return (Int32)quantity_packedVar.Value; }
            set { quantity_packedVar.Value = value; }
        }

        public String orderid_quote
        {
            get { return (String)orderid_quoteVar.Value; }
            set { orderid_quoteVar.Value = value; }
        }

        public String ordernumber_quote
        {
            get { return (String)ordernumber_quoteVar.Value; }
            set { ordernumber_quoteVar.Value = value; }
        }

        public String quote_line_uid
        {
            get { return (String)quote_line_uidVar.Value; }
            set { quote_line_uidVar.Value = value; }
        }

        public String ordernumber_invoice
        {
            get { return (String)ordernumber_invoiceVar.Value; }
            set { ordernumber_invoiceVar.Value = value; }
        }

        public Boolean was_shipped
        {
            get { return (Boolean)was_shippedVar.Value; }
            set { was_shippedVar.Value = value; }
        }

        public Boolean was_received
        {
            get { return (Boolean)was_receivedVar.Value; }
            set { was_receivedVar.Value = value; }
        }

        public Boolean was_service_out
        {
            get { return (Boolean)was_service_outVar.Value; }
            set { was_service_outVar.Value = value; }
        }

        public Boolean was_service_in
        {
            get { return (Boolean)was_service_inVar.Value; }
            set { was_service_inVar.Value = value; }
        }

        public Boolean was_rma
        {
            get { return (Boolean)was_rmaVar.Value; }
            set { was_rmaVar.Value = value; }
        }

        public Boolean was_vendrma
        {
            get { return (Boolean)was_vendrmaVar.Value; }
            set { was_vendrmaVar.Value = value; }
        }

        public Boolean was_rma_received
        {
            get { return (Boolean)was_rma_receivedVar.Value; }
            set { was_rma_receivedVar.Value = value; }
        }

        public Boolean was_vendrma_shipped
        {
            get { return (Boolean)was_vendrma_shippedVar.Value; }
            set { was_vendrma_shippedVar.Value = value; }
        }

        public String stocktype_receive
        {
            get { return (String)stocktype_receiveVar.Value; }
            set { stocktype_receiveVar.Value = value; }
        }

        public String legacyid_sales
        {
            get { return (String)legacyid_salesVar.Value; }
            set { legacyid_salesVar.Value = value; }
        }

        public String legacyid_purchase
        {
            get { return (String)legacyid_purchaseVar.Value; }
            set { legacyid_purchaseVar.Value = value; }
        }

        public String legacyid_service
        {
            get { return (String)legacyid_serviceVar.Value; }
            set { legacyid_serviceVar.Value = value; }
        }

        public String legacyid_invoice
        {
            get { return (String)legacyid_invoiceVar.Value; }
            set { legacyid_invoiceVar.Value = value; }
        }

        public String legacyid_rma
        {
            get { return (String)legacyid_rmaVar.Value; }
            set { legacyid_rmaVar.Value = value; }
        }

        public String legacyid_vendrma
        {
            get { return (String)legacyid_vendrmaVar.Value; }
            set { legacyid_vendrmaVar.Value = value; }
        }

        public Boolean was_purchase
        {
            get { return (Boolean)was_purchaseVar.Value; }
            set { was_purchaseVar.Value = value; }
        }

        public Boolean was_invoice
        {
            get { return (Boolean)was_invoiceVar.Value; }
            set { was_invoiceVar.Value = value; }
        }

        public Int32 quantity_unpacked
        {
            get { return (Int32)quantity_unpackedVar.Value; }
            set { quantity_unpackedVar.Value = value; }
        }

        public Int32 quantity_packed_service
        {
            get { return (Int32)quantity_packed_serviceVar.Value; }
            set { quantity_packed_serviceVar.Value = value; }
        }

        public Int32 quantity_unpacked_service
        {
            get { return (Int32)quantity_unpacked_serviceVar.Value; }
            set { quantity_unpacked_serviceVar.Value = value; }
        }

        public Int32 quantity_packed_vendrma
        {
            get { return (Int32)quantity_packed_vendrmaVar.Value; }
            set { quantity_packed_vendrmaVar.Value = value; }
        }

        public Int32 quantity_unpacked_rma
        {
            get { return (Int32)quantity_unpacked_rmaVar.Value; }
            set { quantity_unpacked_rmaVar.Value = value; }
        }

        public Int32 linecode_service
        {
            get { return (Int32)linecode_serviceVar.Value; }
            set { linecode_serviceVar.Value = value; }
        }

        public Double unit_price_vendrma
        {
            get { return (Double)unit_price_vendrmaVar.Value; }
            set { unit_price_vendrmaVar.Value = value; }
        }

        public Double total_price_vendrma
        {
            get { return (Double)total_price_vendrmaVar.Value; }
            set { total_price_vendrmaVar.Value = value; }
        }

        public Double unit_price_rma
        {
            get { return (Double)unit_price_rmaVar.Value; }
            set { unit_price_rmaVar.Value = value; }
        }

        public Double total_price_rma
        {
            get { return (Double)total_price_rmaVar.Value; }
            set { total_price_rmaVar.Value = value; }
        }

        public Boolean put_away
        {
            get { return (Boolean)put_awayVar.Value; }
            set { put_awayVar.Value = value; }
        }

        public DateTime put_away_date
        {
            get { return (DateTime)put_away_dateVar.Value; }
            set { put_away_dateVar.Value = value; }
        }

        public String put_away_user
        {
            get { return (String)put_away_userVar.Value; }
            set { put_away_userVar.Value = value; }
        }

        public Double service_cost
        {
            get { return (Double)service_costVar.Value; }
            set { service_costVar.Value = value; }
        }

        public String service_leadtime
        {
            get { return (String)service_leadtimeVar.Value; }
            set { service_leadtimeVar.Value = value; }
        }

        public Boolean is_rma_replacement
        {
            get { return (Boolean)is_rma_replacementVar.Value; }
            set { is_rma_replacementVar.Value = value; }
        }

        public Double total_deduction
        {
            get { return (Double)total_deductionVar.Value; }
            set { total_deductionVar.Value = value; }
        }

        public Boolean vendrma_will_refund
        {
            get { return (Boolean)vendrma_will_refundVar.Value; }
            set { vendrma_will_refundVar.Value = value; }
        }

        public Double rma_subtraction
        {
            get { return (Double)rma_subtractionVar.Value; }
            set { rma_subtractionVar.Value = value; }
        }

        public DateTime ship_date_service_due
        {
            get { return (DateTime)ship_date_service_dueVar.Value; }
            set { ship_date_service_dueVar.Value = value; }
        }

        public DateTime ship_date_service_actual
        {
            get { return (DateTime)ship_date_service_actualVar.Value; }
            set { ship_date_service_actualVar.Value = value; }
        }

        public DateTime ship_date_vendrma_due
        {
            get { return (DateTime)ship_date_vendrma_dueVar.Value; }
            set { ship_date_vendrma_dueVar.Value = value; }
        }

        public DateTime ship_date_vendrma_actual
        {
            get { return (DateTime)ship_date_vendrma_actualVar.Value; }
            set { ship_date_vendrma_actualVar.Value = value; }
        }

        public DateTime receive_date_service_due
        {
            get { return (DateTime)receive_date_service_dueVar.Value; }
            set { receive_date_service_dueVar.Value = value; }
        }

        public DateTime receive_date_service_actual
        {
            get { return (DateTime)receive_date_service_actualVar.Value; }
            set { receive_date_service_actualVar.Value = value; }
        }

        public DateTime receive_date_rma_due
        {
            get { return (DateTime)receive_date_rma_dueVar.Value; }
            set { receive_date_rma_dueVar.Value = value; }
        }

        public DateTime receive_date_rma_actual
        {
            get { return (DateTime)receive_date_rma_actualVar.Value; }
            set { receive_date_rma_actualVar.Value = value; }
        }

        public DateTime ship_date_next
        {
            get { return (DateTime)ship_date_nextVar.Value; }
            set { ship_date_nextVar.Value = value; }
        }

        public DateTime receive_date_next
        {
            get { return (DateTime)receive_date_nextVar.Value; }
            set { receive_date_nextVar.Value = value; }
        }

        public String shipvia_next
        {
            get { return (String)shipvia_nextVar.Value; }
            set { shipvia_nextVar.Value = value; }
        }

        public String shipvia_receive_next
        {
            get { return (String)shipvia_receive_nextVar.Value; }
            set { shipvia_receive_nextVar.Value = value; }
        }

        public String ship_to_next
        {
            get { return (String)ship_to_nextVar.Value; }
            set { ship_to_nextVar.Value = value; }
        }

        public String receive_from_next
        {
            get { return (String)receive_from_nextVar.Value; }
            set { receive_from_nextVar.Value = value; }
        }

        public Boolean drop_ship
        {
            get { return (Boolean)drop_shipVar.Value; }
            set { drop_shipVar.Value = value; }
        }

        public string drop_ship_comments
        {
            get { return (string)drop_ship_commentsVar.Value; }
            set { drop_ship_commentsVar.Value = value; }
        }

        public String internal_customer
        {
            get { return (String)internal_customerVar.Value; }
            set { internal_customerVar.Value = value; }
        }


        public String line_group_id
        {
            get { return (String)line_group_idVar.Value; }
            set { line_group_idVar.Value = value; }
        }

        public String rohs_info_vendor
        {
            get { return (String)rohs_info_vendorVar.Value; }
            set { rohs_info_vendorVar.Value = value; }
        }

        public DateTime customer_dock_date
        {
            get { return (DateTime)customer_dock_dateVar.Value; }
            set { customer_dock_dateVar.Value = value; }
        }

        public String status_caption
        {
            get { return (String)status_captionVar.Value; }
            set { status_captionVar.Value = value; }
        }

        public String datecode_purchase
        {
            get { return (String)datecode_purchaseVar.Value; }
            set { datecode_purchaseVar.Value = value; }
        }

        public String inventory_link_uid
        {
            get { return (String)inventory_link_uidVar.Value; }
            set { inventory_link_uidVar.Value = value; }
        }

        public String inventory_link_caption
        {
            get { return (String)inventory_link_captionVar.Value; }
            set { inventory_link_captionVar.Value = value; }
        }

        public String po_option_number
        {
            get { return (String)po_option_numberVar.Value; }
            set { po_option_numberVar.Value = value; }
        }

        public String po_option
        {
            get { return (String)po_optionVar.Value; }
            set { po_optionVar.Value = value; }
        }

        public Boolean purchased_as_other
        {
            get { return (Boolean)purchased_as_otherVar.Value; }
            set { purchased_as_otherVar.Value = value; }
        }

        public String purchased_as_number
        {
            get { return (String)purchased_as_numberVar.Value; }
            set { purchased_as_numberVar.Value = value; }
        }

        public String part_number_stripped
        {
            get { return (String)part_number_strippedVar.Value; }
            set { part_number_strippedVar.Value = value; }
        }

        public String purchased_as_stripped
        {
            get { return (String)purchased_as_strippedVar.Value; }
            set { purchased_as_strippedVar.Value = value; }
        }

        public String service_agent_uid
        {
            get { return (String)service_agent_uidVar.Value; }
            set { service_agent_uidVar.Value = value; }
        }

        public String service_agent_name
        {
            get { return (String)service_agent_nameVar.Value; }
            set { service_agent_nameVar.Value = value; }
        }

        public Boolean charge_service_to_customer
        {
            get { return (Boolean)charge_service_to_customerVar.Value; }
            set { charge_service_to_customerVar.Value = value; }
        }

        public Boolean qb_sent_purchase
        {
            get { return (Boolean)qb_sent_purchaseVar.Value; }
            set { qb_sent_purchaseVar.Value = value; }
        }

        public String customer_po_number
        {
            get { return (String)customer_po_numberVar.Value; }
            set { customer_po_numberVar.Value = value; }
        }

        public Boolean qb_sent_service
        {
            get { return (Boolean)qb_sent_serviceVar.Value; }
            set { qb_sent_serviceVar.Value = value; }
        }

        public Boolean put_away_rma
        {
            get { return (Boolean)put_away_rmaVar.Value; }
            set { put_away_rmaVar.Value = value; }
        }

        public Boolean needs_purchasing
        {
            get { return (Boolean)needs_purchasingVar.Value; }
            set { needs_purchasingVar.Value = value; }
        }

        public String currency_name_price
        {
            get { return (String)currency_name_priceVar.Value; }
            set { currency_name_priceVar.Value = value; }
        }

        public Double exchange_rate_price
        {
            get { return (Double)exchange_rate_priceVar.Value; }
            set { exchange_rate_priceVar.Value = value; }
        }

        public String currency_name_cost
        {
            get { return (String)currency_name_costVar.Value; }
            set { currency_name_costVar.Value = value; }
        }

        public Double exchange_rate_cost
        {
            get { return (Double)exchange_rate_costVar.Value; }
            set { exchange_rate_costVar.Value = value; }
        }

        public Double unit_price_exchanged
        {
            get { return (Double)unit_price_exchangedVar.Value; }
            set { unit_price_exchangedVar.Value = value; }
        }

        public Double total_price_exchanged
        {
            get { return (Double)total_price_exchangedVar.Value; }
            set { total_price_exchangedVar.Value = value; }
        }

        public Double unit_cost_exchanged
        {
            get { return (Double)unit_cost_exchangedVar.Value; }
            set { unit_cost_exchangedVar.Value = value; }
        }

        public Double total_cost_exchanged
        {
            get { return (Double)total_cost_exchangedVar.Value; }
            set { total_cost_exchangedVar.Value = value; }
        }

        public String unit_price_print
        {
            get { return (String)unit_price_printVar.Value; }
            set { unit_price_printVar.Value = value; }
        }

        public String total_price_print
        {
            get { return (String)total_price_printVar.Value; }
            set { total_price_printVar.Value = value; }
        }

        public String unit_cost_print
        {
            get { return (String)unit_cost_printVar.Value; }
            set { unit_cost_printVar.Value = value; }
        }

        public String total_cost_print
        {
            get { return (String)total_cost_printVar.Value; }
            set { total_cost_printVar.Value = value; }
        }

        public Double unit_price_rma_exchanged
        {
            get { return (Double)unit_price_rma_exchangedVar.Value; }
            set { unit_price_rma_exchangedVar.Value = value; }
        }

        public Double unit_price_vendrma_exchanged
        {
            get { return (Double)unit_price_vendrma_exchangedVar.Value; }
            set { unit_price_vendrma_exchangedVar.Value = value; }
        }

        public Double total_price_rma_exchanged
        {
            get { return (Double)total_price_rma_exchangedVar.Value; }
            set { total_price_rma_exchangedVar.Value = value; }
        }

        public Double total_price_vendrma_exchanged
        {
            get { return (Double)total_price_vendrma_exchangedVar.Value; }
            set { total_price_vendrma_exchangedVar.Value = value; }
        }

        public String unit_price_rma_print
        {
            get { return (String)unit_price_rma_printVar.Value; }
            set { unit_price_rma_printVar.Value = value; }
        }

        public String unit_price_vendrma_print
        {
            get { return (String)unit_price_vendrma_printVar.Value; }
            set { unit_price_vendrma_printVar.Value = value; }
        }

        public String total_price_rma_print
        {
            get { return (String)total_price_rma_printVar.Value; }
            set { total_price_rma_printVar.Value = value; }
        }

        public String total_price_vendrma_print
        {
            get { return (String)total_price_vendrma_printVar.Value; }
            set { total_price_vendrma_printVar.Value = value; }
        }

        public Boolean needs_post_put_away
        {
            get { return (Boolean)needs_post_put_awayVar.Value; }
            set { needs_post_put_awayVar.Value = value; }
        }

        public Double exchange_rate_rma
        {
            get { return (Double)exchange_rate_rmaVar.Value; }
            set { exchange_rate_rmaVar.Value = value; }
        }

        public Double exchange_rate_vendrma
        {
            get { return (Double)exchange_rate_vendrmaVar.Value; }
            set { exchange_rate_vendrmaVar.Value = value; }
        }

        public Boolean needs_post_ship
        {
            get { return (Boolean)needs_post_shipVar.Value; }
            set { needs_post_shipVar.Value = value; }
        }

        public Boolean is_consumption
        {
            get { return (Boolean)is_consumptionVar.Value; }
            set { is_consumptionVar.Value = value; }
        }

        public String line_type
        {
            get { return (String)line_typeVar.Value; }
            set { line_typeVar.Value = value; }
        }

        public Double paid_amount_rma
        {
            get { return (Double)paid_amount_rmaVar.Value; }
            set { paid_amount_rmaVar.Value = value; }
        }

        public DateTime paid_date_rma
        {
            get { return (DateTime)paid_date_rmaVar.Value; }
            set { paid_date_rmaVar.Value = value; }
        }

        public Double paid_amount_vendrma
        {
            get { return (Double)paid_amount_vendrmaVar.Value; }
            set { paid_amount_vendrmaVar.Value = value; }
        }

        public DateTime paid_date_vendrma
        {
            get { return (DateTime)paid_date_vendrmaVar.Value; }
            set { paid_date_vendrmaVar.Value = value; }
        }

        public String purchase_expense_account_name
        {
            get { return (String)purchase_expense_account_nameVar.Value; }
            set { purchase_expense_account_nameVar.Value = value; }
        }

        public String purchase_expense_account_uid
        {
            get { return (String)purchase_expense_account_uidVar.Value; }
            set { purchase_expense_account_uidVar.Value = value; }
        }

        public String sales_income_account_name
        {
            get { return (String)sales_income_account_nameVar.Value; }
            set { sales_income_account_nameVar.Value = value; }
        }

        public String sales_income_account_uid
        {
            get { return (String)sales_income_account_uidVar.Value; }
            set { sales_income_account_uidVar.Value = value; }
        }

        public Boolean posted_invoice
        {
            get { return (Boolean)posted_invoiceVar.Value; }
            set { posted_invoiceVar.Value = value; }
        }

        public Boolean posted_purchase
        {
            get { return (Boolean)posted_purchaseVar.Value; }
            set { posted_purchaseVar.Value = value; }
        }

        public Boolean posted_rma
        {
            get { return (Boolean)posted_rmaVar.Value; }
            set { posted_rmaVar.Value = value; }
        }

        public Boolean posted_vendrma
        {
            get { return (Boolean)posted_vendrmaVar.Value; }
            set { posted_vendrmaVar.Value = value; }
        }

        public Boolean posted_service
        {
            get { return (Boolean)posted_serviceVar.Value; }
            set { posted_serviceVar.Value = value; }
        }

        public String cc_charge_type
        {
            get { return (String)cc_charge_typeVar.Value; }
            set { cc_charge_typeVar.Value = value; }
        }

        public DateTime customer_dock_date_initial
        {
            get { return (DateTime)customer_dock_date_initialVar.Value; }
            set { customer_dock_date_initialVar.Value = value; }
        }

        public Double total_fees
        {
            get { return (Double)total_feesVar.Value; }
            set { total_feesVar.Value = value; }
        }

        public Boolean is_RMA_IHS
        {
            get { return (Boolean)is_RMA_IHSVar.Value; }
            set { is_RMA_IHSVar.Value = value; }
        }

        public Boolean isvoid_SMCFault
        {
            get { return (Boolean)isvoid_SMCFaultVar.Value; }
            set { isvoid_SMCFaultVar.Value = value; }
        }

        public String unique_id_canceled
        {
            get { return (String)unique_id_canceledVar.Value; }
            set { unique_id_canceledVar.Value = value; }
        }

        public String insp_id
        {
            get { return (String)insp_idVar.Value; }
            set { insp_idVar.Value = value; }
        }

        public Int32 nonconid
        {
            get { return (Int32)nonconidVar.Value; }
            set { nonconidVar.Value = value; }
        }


        public String bid_partnumber
        {
            get { return (String)bid_partnumberVar.Value; }
            set { bid_partnumberVar.Value = value; }
        }

        public String importid
        {
            get { return (String)importidVar.Value; }
            set { importidVar.Value = value; }
        }

        public String quoted_partnumber
        {
            get { return (String)quoted_partnumberVar.Value; }
            set { quoted_partnumberVar.Value = value; }
        }

        public DateTime tbd_cleared_date
        {
            get { return (DateTime)tbd_cleared_dateVar.Value; }
            set { tbd_cleared_dateVar.Value = value; }
        }

        public string qc_status
        {
            get { return (string)qc_statusVar.Value; }
            set { qc_statusVar.Value = value; }
        }

        public string qb_order_ListID
        {
            get { return (string)qb_order_ListIDVar.Value; }
            set { qb_order_ListIDVar.Value = value; }
        }

        public string qb_line_ListID
        {
            get { return (string)qb_line_ListIDVar.Value; }
            set { qb_line_ListIDVar.Value = value; }
        }

        public string qb_line_subitem_ListID
        {
            get { return (string)qb_line_subitem_ListIDVar.Value; }
            set { qb_line_subitem_ListIDVar.Value = value; }
        }


        public string qb_line_TxnID//sale line id
        {
            get { return (string)qb_line_TxnIDVar.Value; }
            set { qb_line_TxnIDVar.Value = value; }
        }

        public string qb_line_TxnID_purchase
        {
            get { return (string)qb_line_TxnID_purchaseVar.Value; }
            set { qb_line_TxnID_purchaseVar.Value = value; }
        }

        public string list_acquisition_agent
        {
            get { return (string)list_acquisition_agentVar.Value; }
            set { list_acquisition_agentVar.Value = value; }
        }

        public string list_acquisition_agent_uid
        {
            get { return (string)list_acquisition_agent_uidVar.Value; }
            set { list_acquisition_agent_uidVar.Value = value; }
        }


        public bool is_split_commission
        {
            get { return (bool)is_split_commissionVar.Value; }
            set { is_split_commissionVar.Value = value; }
        }

        public string split_commission_agent_name
        {
            get { return (string)split_commission_agent_nameVar.Value; }
            set { split_commission_agent_nameVar.Value = value; }
        }

        public string split_commission_agent_uid
        {
            get { return (string)split_commission_agent_uidVar.Value; }
            set { split_commission_agent_uidVar.Value = value; }
        }

        public string split_commission_type
        {
            get { return (string)split_commission_typeVar.Value; }
            set { split_commission_typeVar.Value = value; }
        }

        public string split_commission_ID
        {
            get { return (string)split_commission_IDVar.Value; }
            set { split_commission_IDVar.Value = value; }
        }
		

        public string country_of_origin
        {
            get { return (string)country_of_originVar.Value; }
            set { country_of_originVar.Value = value; }
        }

        public string country_of_origin_vendor
        {
            get { return (string)country_of_origin_vendorVar.Value; }
            set { country_of_origin_vendorVar.Value = value; }
        }

        public string harmonized_tariff_schedule
        {
            get { return (string)harmonized_tariff_scheduleVar.Value; }
            set { harmonized_tariff_scheduleVar.Value = value; }
        }

        public DateTime projected_dock_date
        {
            get { return (DateTime)projected_dock_dateVar.Value; }
            set { projected_dock_dateVar.Value = value; }
        }

        public string internalpart_vendor_uid
        {
            get { return (string)internalpart_vendor_uidVar.Value; }
            set { internalpart_vendor_uidVar.Value = value; }
        }


        public String internalpart_vendor
        {
            get { return (String)internalpart_vendorVar.Value; }
            set { internalpart_vendorVar.Value = value; }
        }


        public String affiliate_id
        {
            get { return (String)affiliate_idVar.Value; }
            set { affiliate_idVar.Value = value; }
        }

        public String inspection_status
        {
            get { return (String)inspection_statusVar.Value; }
            set { inspection_statusVar.Value = value; }
        }

        public String source
        {
            get { return (String)sourceVar.Value; }
            set { sourceVar.Value = value; }
        }


        public String line_validation_status
        {
            get { return (String)line_validation_statusVar.Value; }
            set { line_validation_statusVar.Value = value; }
        }

        



    }
    public partial class orddet_line
    {
        public static orddet_line New(Context x)
        { return (orddet_line)x.Item("orddet_line"); }

        public static orddet_line GetById(Context x, String uid)
        { return (orddet_line)x.GetById("orddet_line", uid); }

        public static orddet_line QtO(Context x, String sql)
        { return (orddet_line)x.QtO("orddet_line", sql); }
    }
}
