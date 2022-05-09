using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarString : VarVal
    {
        public VarString(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
            m_Value = "";
        }

        public VarString(IItem parent, CoreVarAttribute attr, String val)
            : this(parent, attr)
        {
            if (val == null)
                m_Value = "";
            else
                m_Value = val;
        }

        public override String ValueString
        {
            get
            {
                return (String)Value;
            }
        }

        public override string ToString()
        {
            return ValueString;
        }

        public override object ValueFromString(string s)
        {
            return s;
        }

        protected override bool ValueAcceptable(Context x, string v, ref string message)
        {
            if( !base.ValueAcceptable(x, v, ref message) )
                return false;

            if( v == null )
            {
                message = "Value cannot be null";
                return false;
            }

            //needs a warning if the string is too long, based on TheVarAttribute.LengthMax
            return true;
        }

        protected override object Default
        {
            get
            {
                return "";
            }
        }

        public override bool ValueSame(object c)
        {
            if (ValueDifferent(c))
                return false;

            return ((string)c == (string)Value);
        }

        public override void ValueSetFromString(string valueString)
        {
            Value = valueString;
        }
    }
}
