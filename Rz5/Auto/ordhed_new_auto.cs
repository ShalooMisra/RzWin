using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhed_new", Abstract = true)]
    public partial class ordhed_new_auto : Rz5.ordhed
    {
        static ordhed_new_auto()
        {
            Item.AttributesCache(typeof(ordhed_new_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "sub_total":
                    sub_totalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "expenses":
                    expensesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "posted_expenses":
                    posted_expensesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "amount_paid":
                    amount_paidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "days_to_pay":
                    days_to_payAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filled_total":
                    filled_totalAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute sub_totalAttribute;
        static CoreVarValAttribute expensesAttribute;
        static CoreVarValAttribute posted_expensesAttribute;
        static CoreVarValAttribute amount_paidAttribute;
        static CoreVarValAttribute days_to_payAttribute;
        static CoreVarValAttribute filled_totalAttribute;


        [CoreVarVal("sub_total", "Double", Caption="Sub Total", Importance = 1)]
        public VarDouble sub_totalVar;

        [CoreVarVal("expenses", "Double", Caption="Expenses", Importance = 2)]
        public VarDouble expensesVar;

        [CoreVarVal("posted_expenses", "Boolean", Transactional = true, Caption="Posted Expenses", Importance = 2)]
        public VarBoolean posted_expensesVar;

        [CoreVarVal("amount_paid", "Double", Transactional = true, Caption="Amount Paid", Importance = 3)]
        public VarDouble amount_paidVar;

        [CoreVarVal("days_to_pay", "Int32", Caption="Days To Pay", Importance = 4)]
        public VarInt32 days_to_payVar;

        [CoreVarVal("filled_total", "Double", Transactional = true, Caption="Filled Total", Importance = 5)]
        public VarDouble filled_totalVar;

        public ordhed_new_auto()
        {
            StaticInit();
            sub_totalVar = new VarDouble(this, sub_totalAttribute);
            expensesVar = new VarDouble(this, expensesAttribute);
            posted_expensesVar = new VarBoolean(this, posted_expensesAttribute);
            amount_paidVar = new VarDouble(this, amount_paidAttribute);
            days_to_payVar = new VarInt32(this, days_to_payAttribute);
            filled_totalVar = new VarDouble(this, filled_totalAttribute);
        }

        public override string ClassId
        { get { return "ordhed_new"; } }

        public Double sub_total
        {
            get  { return (Double)sub_totalVar.Value; }
            set  { sub_totalVar.Value = value; }
        }

        public Double expenses
        {
            get  { return (Double)expensesVar.Value; }
            set  { expensesVar.Value = value; }
        }

        public Boolean posted_expenses
        {
            get  { return (Boolean)posted_expensesVar.Value; }
        }

        public Double amount_paid
        {
            get  { return (Double)amount_paidVar.Value; }
        }

        public virtual void amount_paid_Add(Context context, Double amount)
        {
            amount_paidVar.Value = ((Double)amount_paidVar.Value + amount);
            TransValueUpdate(context, "amount_paid", TransValueUpdateOp.Add, amount);
        }
        public virtual void amount_paid_Subtract(Context context, Double amount)
        {
            amount_paidVar.Value = ((Double)amount_paidVar.Value - amount);
            TransValueUpdate(context, "amount_paid", TransValueUpdateOp.Subtract, amount);
        }
        public Int32 days_to_pay
        {
            get  { return (Int32)days_to_payVar.Value; }
            set  { days_to_payVar.Value = value; }
        }

        public Double filled_total
        {
            get  { return (Double)filled_totalVar.Value; }
        }

        public virtual void filled_total_Add(Context context, Double amount)
        {
            filled_totalVar.Value = ((Double)filled_totalVar.Value + amount);
            TransValueUpdate(context, "filled_total", TransValueUpdateOp.Add, amount);
        }
        public virtual void filled_total_Subtract(Context context, Double amount)
        {
            filled_totalVar.Value = ((Double)filled_totalVar.Value - amount);
            TransValueUpdate(context, "filled_total", TransValueUpdateOp.Subtract, amount);
        }
    }
    public partial class ordhed_new
    {
        public static ordhed_new New(Context x)
        {  return (ordhed_new)x.Item("ordhed_new"); }

        public static ordhed_new GetById(Context x, String uid)
        { return (ordhed_new)x.GetById("ordhed_new", uid); }

        public static ordhed_new QtO(Context x, String sql)
        { return (ordhed_new)x.QtO("ordhed_new", sql); }
    }
}
