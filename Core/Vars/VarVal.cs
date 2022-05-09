using System;
using System.Collections.Generic;
using System.Text;
using Tools.Database;

namespace Core
{
    public class VarVal : Var
    {
        public CoreVarValAttribute TheValAttribute
        {
            get
            {
                return (CoreVarValAttribute)TheAttribute;
            }
        }

        public VarVal(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        protected override void FieldValuesAppend(Context x, List<Tools.Database.FieldValue> values, bool changed_only)
        {
            base.FieldValuesAppend(x, values, changed_only);
            Tools.Database.FieldValue fv = new Tools.Database.FieldValue(TheValAttribute.TheFieldName, TheValAttribute.TheFieldType, TheValAttribute.TheFieldLength, m_Value);
            fv.ValueUse = TheValAttribute.ValueUse;
            values.Add(fv);
        }

        public override void Absorb(Context x, System.Data.DataRow r)
        {
            base.Absorb(x, r);
            Object val = r[TheValAttribute.TheFieldName];

            if (val != null)
            {
                if (val != DBNull.Value)
                {
                    Value = val;
                }
            }
        }

        public virtual bool ValueDifferent(object v)
        {
            if (v == null || Value == null)
                return true;

            return false;
        }

        public virtual bool ValueSame(object c)
        {
            return false;
        }

        public override object Value
        {
            get
            {
                if (base.Value == null)
                    return Default;
                else
                    return base.Value;
            }
            set
            {
                if (ValueSame(value))
                    return;

                base.Value = value;
            }
        }

        public Tools.Database.FieldType FieldType
        {
            get
            {
                return TheValAttribute.TheFieldType;
            }
        }

        protected virtual Object Default
        {
            get
            {
                throw new Exception("No default specified");
            }
        }

        public ValueUse ValueUse
        {
            get
            {
                return TheValAttribute.ValueUse;
            }
        }

        public static bool UseIsNumeric(ValueUse use)
        {
            switch (use)
            {
                case ValueUse.UnitMoney:
                case ValueUse.TotalMoney:
                case ValueUse.Quantity:
                case ValueUse.Count:
                case ValueUse.Percentage:
                    return true;
                default:
                    return false;
            }
        }

        public virtual void ValueSetFromString(String valueString)
        {
            throw new NotImplementedException();
        }
    }

    //public enum ValueUse
    //{
    //    Any,
    //    Ignore,  //for reporting
    //    Email,
    //    Phone,
    //    Url,
    //    List,
    //    PersonName,
    //    FirstName,
    //    LastName,
    //    IPAddress,
    //    Password,
    //    //numbers
    //    UnitMoney,
    //    TotalMoney,
    //    Quantity,
    //    Count,
    //    Percentage,
    //    DateOnly,
    //    TimeOnly,
    //    DateTime,
    //}
}
