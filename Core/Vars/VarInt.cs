using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarInt32 : VarVal
    {
        public VarInt32(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
            m_Value = 0;
        }

        public Int32 ValueInt
        {
            get
            {
                return (Int32)Value;
            }
        }

        public override string ToString()
        {
            return ValueInt.ToString();
        }

        public override String ValueString
        {
            get
            {
                return ValueInt.ToString();
            }
        }

        public override object ValueFromString(string s)
        {
            try
            {
                return Int32.Parse(s);
            }
            catch { return (Int32)0; }
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
                Int32 d = Int32.Parse(v);
                return true;
            }
            catch { return false; }
        }

        protected override object Default
        {
            get
            {
                return Convert.ToInt32(0);
            }
        }

        public override bool ValueSame(object c)
        {
            if (ValueDifferent(c))
                return false;

            try
            {
                return ((int)c == (int)Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void ValueSetFromString(string valueString)
        {
            Value = Int32.Parse(valueString);
        }
    }
    public class VarInt64 : VarVal
    {
        public VarInt64(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
            m_Value = (long)0;
        }

        public Int64 ValueInt
        {
            get
            {
                return (Int64)Value;
            }
        }

        public override object Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                if (!(value is Int64))
                {
                    ;
                }
                base.Value = value;
            }
        }

        public override string ToString()
        {
            return ValueInt.ToString();
        }

        public override String ValueString
        {
            get
            {
                return ValueInt.ToString();
            }
        }

        public override object ValueFromString(string s)
        {
            try
            {
                return Int64.Parse(s);
            }
            catch { return (Int64)0; }
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
                Int64 d = Int64.Parse(v);
                return true;
            }
            catch { return false; }
        }

        protected override object Default
        {
            get
            {
                return Convert.ToInt64(0);
            }
        }

        public override bool ValueSame(object c)
        {
            if (ValueDifferent(c))
                return false;

            try
            {
                return (Convert.ToInt64(c) == Convert.ToInt64(Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void ValueSetFromString(string valueString)
        {
            Value = Int64.Parse(valueString);
        }
    }
}
