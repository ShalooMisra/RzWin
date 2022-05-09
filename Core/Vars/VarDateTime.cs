using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarDateTime : VarVal
    {
        public VarDateTime(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        public DateTime ValueDateTime
        {
            get
            {
                if (Value == null)
                    return Tools.Dates.NullDate;
                else
                    return (DateTime)Value;
            }
        }

        public override String ValueString
        {
            get
            {
                return ValueDateTime.ToString();
            }
        }

        public bool NullIs
        {
            get
            {
                if( Value == null )
                    return true;

                return ValueDateTime < Tools.Dates.NullDateCompare;
            }
        }

        public override string ToString()
        {
            //this should look at a setting in the attribute for what the main interval is
            //for most date fields, showing just the mm/dd/yyyy is the right default, but for others it might just be the year, or the minute, or whatever
            //or maybe the attributes should all have a default format?

            if (NullIs)
                return "";
            else
                return Tools.Dates.DateFormat(ValueDateTime);  
        }

        public override object ValueFromString(string s)
        {
            try
            {
                return DateTime.Parse(s);
            }
            catch
            {
                return Tools.Dates.NullDate;
            }
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

            return Tools.Dates.IsDate(v);
        }

        protected override object Default
        {
            get
            {
                return Tools.Dates.NullDate;
            }
        }

        public override bool ValueSame(object c)
        {
            if (ValueDifferent(c))
                return false;

            return Math.Abs(((DateTime)Value).Subtract((DateTime)c).TotalMilliseconds) < 1000;  //saving to the db rounds down milliseconds
        }

        public override void ValueSetFromString(string valueString)
        {
            Value = DateTime.Parse(valueString);
        }
    }
}
