using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_service")]
    public partial class ordhed_service_auto : Rz5.ordhed_new
    {
        static ordhed_service_auto()
        {
            Item.AttributesCache(typeof(ordhed_service_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "apply_ordhed_invoice_uid":
                    apply_ordhed_invoice_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "senttoqb_invoice":
                    senttoqb_invoiceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "charge_service_to_customer":
                    charge_service_to_customerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "service_cost_balance":
                    service_cost_balanceAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute apply_ordhed_invoice_uidAttribute;
        static CoreVarValAttribute senttoqb_invoiceAttribute;
        static CoreVarValAttribute charge_service_to_customerAttribute;
        static CoreVarValAttribute service_cost_balanceAttribute;

        [CoreVarVal("apply_ordhed_invoice_uid", "String", TheFieldLength = 255, Caption="Apply Ordhed Invoice Uid", Importance = 1)]
        public VarString apply_ordhed_invoice_uidVar;

        [CoreVarVal("senttoqb_invoice", "Boolean", Caption="Sent To Qbs As Invoice", Importance = 2)]
        public VarBoolean senttoqb_invoiceVar;

        [CoreVarVal("charge_service_to_customer", "Boolean", Caption="Charge Service To Customer", Importance = 3)]
        public VarBoolean charge_service_to_customerVar;

        [CoreVarVal("service_cost_balance", "Double", Caption = "Service Cost Balance", Importance = 1)]
        public VarDouble service_cost_balanceVar;

        public ordhed_service_auto()
        {
            StaticInit();
            apply_ordhed_invoice_uidVar = new VarString(this, apply_ordhed_invoice_uidAttribute);
            senttoqb_invoiceVar = new VarBoolean(this, senttoqb_invoiceAttribute);
            charge_service_to_customerVar = new VarBoolean(this, charge_service_to_customerAttribute);
            service_cost_balanceVar = new VarDouble(this, service_cost_balanceAttribute);
        }

        public override string ClassId
        { get { return "ordhed_service"; } }

        public String apply_ordhed_invoice_uid
        {
            get  { return (String)apply_ordhed_invoice_uidVar.Value; }
            set  { apply_ordhed_invoice_uidVar.Value = value; }
        }

        public Boolean senttoqb_invoice
        {
            get  { return (Boolean)senttoqb_invoiceVar.Value; }
            set  { senttoqb_invoiceVar.Value = value; }
        }

        public Boolean charge_service_to_customer
        {
            get  { return (Boolean)charge_service_to_customerVar.Value; }
            set  { charge_service_to_customerVar.Value = value; }
        }

        public Double service_cost_balance
        {
            get { return (Double)service_cost_balanceVar.Value; }
            set { service_cost_balanceVar.Value = value; }
        }

    }
    public partial class ordhed_service
    {
        public static ordhed_service New(Context x)
        {  return (ordhed_service)x.Item("ordhed_service"); }

        public static ordhed_service GetById(Context x, String uid)
        { return (ordhed_service)x.GetById("ordhed_service", uid); }

        public static ordhed_service QtO(Context x, String sql)
        { return (ordhed_service)x.QtO("ordhed_service", sql); }

      
    }
}
