using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarBoolean : VarVal
    {
        public VarBoolean(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        public Boolean ValueBoolean
        {
            get
            {
                if (Value == null)
                    return false;
                else
                    return (Boolean)Value;
            }
        }

        public override string ToString()
        {
            return ValueBoolean.ToString();
        }

        public override String ValueString
        {
            get
            {
                return ValueBoolean.ToString();
            }
        }

        public override object ValueFromString(string s)
        {
            try
            {
                return Boolean.Parse(s);
            }
            catch { return false; }
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
                Boolean d = Boolean.Parse(v);
                return true;
            }
            catch { return false; }
        }

        protected override object Default
        {
            get
            {
                return false;
            }
        }

        public override bool ValueSame(object c)
        {
            if (ValueDifferent(c))
                return false;

            return ((bool)c == (bool)Value);
        }

        public override void ValueSetFromString(string valueString)
        {
            Value = Boolean.Parse(valueString);
        }
    }
}
