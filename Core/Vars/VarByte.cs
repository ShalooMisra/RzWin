using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarByte : VarVal
    {
        public VarByte(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        public byte ValueByte
        {
            get
            {
                if (Value == null)
                    return 0;
                else
                    return (byte)Value;
            }
        }

        public override string ToString()
        {
            return ValueByte.ToString();
        }

        public override string ValueString
        {
            get
            {
                return ValueByte.ToString();
            }
        }

        public override object ValueFromString(string s)
        {
            try
            {
                return byte.Parse(s);
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
                byte d = byte.Parse(v);
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
            Value = byte.Parse(valueString);
        }
    }
}
