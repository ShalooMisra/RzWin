using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarDouble : VarVal
    {
        public VarDouble(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        public Double ValueDouble
        {
            get
            {
                if (Value == null)
                    return 0;
                else
                    return (Double)Value;
            }
        }

        public override object Value
        {
            get
            {
                return Tools.Data.NullFilterDouble(base.Value);
            }
        }

        public override string ToString()
        {
            return ValueDouble.ToString();
        }

        public override String ValueString
        {
            get
            {
                return ValueDouble.ToString();
            }
        }

        public override object ValueFromString(string s)
        {
            try
            {
                return Double.Parse(s);
            }
            catch { return (Double)0; }
        }

        protected override bool ValueAcceptable(Context x, string v, ref string message)
        {
            if (!base.ValueAcceptable(x, v, ref message))
                return false;

            if (v == null)
            {
                message = "Value cannot be null";
                return false;
            }

            try
            {
                Double d = Double.Parse(v);
                return true;
            }
            catch { return false; }
        }

        protected override object Default
        {
            get
            {
                return Convert.ToDouble(0);
            }
        }

        public override bool ValueSame(object c)
        {
            if (ValueDifferent(c))
                return false;

            try
            {
                return (Math.Round((Double)c, 6) == Math.Round((Double)Value, 6));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void ValueSetFromString(string valueString)
        {
            Value = Double.Parse(valueString);
        }
    }
}
