using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordrma")]
    public partial class ordrma_auto : NewMethod.nObject
    {
        static ordrma_auto()
        {
            Item.AttributesCache(typeof(ordrma_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "vendrma_ordhed_uid":
                    vendrma_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rma_ordhed_uid":
                    rma_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordrma_name":
                    ordrma_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_reimbursed":
                    customer_reimbursedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_reimbursed":
                    vendor_reimbursedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "return_reason":
                    return_reasonAttribute = (CoreVarValAttribute)attr;
                    break;
                case "current_status":
                    current_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "planned_status":
                    planned_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_refund":
                    customer_refundAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vendor_refund":
                    vendor_refundAttribute = (CoreVarValAttribute)attr;
                    break;
                case "will_replace":
                    will_replaceAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute vendrma_ordhed_uidAttribute;
        static CoreVarValAttribute rma_ordhed_uidAttribute;
        static CoreVarValAttribute ordrma_nameAttribute;
        static CoreVarValAttribute customer_reimbursedAttribute;
        static CoreVarValAttribute vendor_reimbursedAttribute;
        static CoreVarValAttribute return_reasonAttribute;
        static CoreVarValAttribute current_statusAttribute;
        static CoreVarValAttribute planned_statusAttribute;
        static CoreVarValAttribute customer_refundAttribute;
        static CoreVarValAttribute vendor_refundAttribute;
        static CoreVarValAttribute will_replaceAttribute;

        [CoreVarVal("vendrma_ordhed_uid", "String", TheFieldLength = 50, Caption="Vendrma Ordhed Id", Importance = 1)]
        public VarString vendrma_ordhed_uidVar;

        [CoreVarVal("rma_ordhed_uid", "String", TheFieldLength = 50, Caption="Rma Ordhed Id", Importance = 2)]
        public VarString rma_ordhed_uidVar;

        [CoreVarVal("ordrma_name", "String", TheFieldLength = 255, Caption="Ordrma Name", Importance = 3)]
        public VarString ordrma_nameVar;

        [CoreVarVal("customer_reimbursed", "String", TheFieldLength = 255, Caption="Customer Reimbursed", Importance = 4)]
        public VarString customer_reimbursedVar;

        [CoreVarVal("vendor_reimbursed", "String", TheFieldLength = 255, Caption="Vendor Reimbursed", Importance = 5)]
        public VarString vendor_reimbursedVar;

        [CoreVarVal("return_reason", "String", TheFieldLength = 255, Caption="Return Reason", Importance = 6)]
        public VarString return_reasonVar;

        [CoreVarVal("current_status", "String", TheFieldLength = 255, Caption="Current Status", Importance = 7)]
        public VarString current_statusVar;

        [CoreVarVal("planned_status", "String", TheFieldLength = 255, Caption="Planned Status", Importance = 8)]
        public VarString planned_statusVar;

        [CoreVarVal("customer_refund", "Boolean", Caption="Customer Refund", Importance = 9)]
        public VarBoolean customer_refundVar;

        [CoreVarVal("vendor_refund", "Boolean", Caption="Vendor Refund", Importance = 10)]
        public VarBoolean vendor_refundVar;

        [CoreVarVal("will_replace", "Boolean", Caption="Will Replace", Importance = 11)]
        public VarBoolean will_replaceVar;

        public ordrma_auto()
        {
            StaticInit();
            vendrma_ordhed_uidVar = new VarString(this, vendrma_ordhed_uidAttribute);
            rma_ordhed_uidVar = new VarString(this, rma_ordhed_uidAttribute);
            ordrma_nameVar = new VarString(this, ordrma_nameAttribute);
            customer_reimbursedVar = new VarString(this, customer_reimbursedAttribute);
            vendor_reimbursedVar = new VarString(this, vendor_reimbursedAttribute);
            return_reasonVar = new VarString(this, return_reasonAttribute);
            current_statusVar = new VarString(this, current_statusAttribute);
            planned_statusVar = new VarString(this, planned_statusAttribute);
            customer_refundVar = new VarBoolean(this, customer_refundAttribute);
            vendor_refundVar = new VarBoolean(this, vendor_refundAttribute);
            will_replaceVar = new VarBoolean(this, will_replaceAttribute);
        }

        public override string ClassId
        { get { return "ordrma"; } }

        public String vendrma_ordhed_uid
        {
            get  { return (String)vendrma_ordhed_uidVar.Value; }
            set  { vendrma_ordhed_uidVar.Value = value; }
        }

        public String rma_ordhed_uid
        {
            get  { return (String)rma_ordhed_uidVar.Value; }
            set  { rma_ordhed_uidVar.Value = value; }
        }

        public String ordrma_name
        {
            get  { return (String)ordrma_nameVar.Value; }
            set  { ordrma_nameVar.Value = value; }
        }

        public String customer_reimbursed
        {
            get  { return (String)customer_reimbursedVar.Value; }
            set  { customer_reimbursedVar.Value = value; }
        }

        public String vendor_reimbursed
        {
            get  { return (String)vendor_reimbursedVar.Value; }
            set  { vendor_reimbursedVar.Value = value; }
        }

        public String return_reason
        {
            get  { return (String)return_reasonVar.Value; }
            set  { return_reasonVar.Value = value; }
        }

        public String current_status
        {
            get  { return (String)current_statusVar.Value; }
            set  { current_statusVar.Value = value; }
        }

        public String planned_status
        {
            get  { return (String)planned_statusVar.Value; }
            set  { planned_statusVar.Value = value; }
        }

        public Boolean customer_refund
        {
            get  { return (Boolean)customer_refundVar.Value; }
            set  { customer_refundVar.Value = value; }
        }

        public Boolean vendor_refund
        {
            get  { return (Boolean)vendor_refundVar.Value; }
            set  { vendor_refundVar.Value = value; }
        }

        public Boolean will_replace
        {
            get  { return (Boolean)will_replaceVar.Value; }
            set  { will_replaceVar.Value = value; }
        }

    }
    public partial class ordrma
    {
        public static ordrma New(Context x)
        {  return (ordrma)x.Item("ordrma"); }

        public static ordrma GetById(Context x, String uid)
        { return (ordrma)x.GetById("ordrma", uid); }

        public static ordrma QtO(Context x, String sql)
        { return (ordrma)x.QtO("ordrma", sql); }
    }
}
