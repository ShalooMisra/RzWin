using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarEnum<T> : VarVal, IEnumVar
    {        
        public VarEnum(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
        }

        public T ValueEnum
        {
            get
            {
                if (Value == null)
                    return default(T);

                return ValueParse((Value.ToString()).Replace(" ", "_"));
            }

            //set
            //{
            //    Value = value.ToString().Replace("_", " ");
            //}
        }

        public void ValueEnumSet(Context x, T val)
        {
            Value = val.ToString().Replace("_", " ");
        }

        public T ValueParse(String val)
        {
            bool success = false;
            return ValueParse(val, ref success);
        }

        public T ValueParse(String val, ref bool success)
        {
            try
            {
                T ret = (T)Enum.Parse(typeof(T), val.Replace(" ", "_"), true);
                success = true;
                return ret;
            }
            catch
            {
                success = false;
                return (T)Enum.Parse(typeof(T), "Unknown", true);
            } 
        }

        public override String ValueString
        {
            get
            {
                String ret = (String)Value;  // ValueEnum.ToString().Replace("_", " ");
                if (ret == null || ret == "Unknown")
                    return "";
                else
                    return ret;
            }
        }

        public List<String> Options
        {
            get
            {
                List<String> ret = new List<string>();
                String[] ops = Enum.GetNames(typeof(T));
                foreach (String s in ops)
                {
                    if( s != "Unknown" )
                        ret.Add(s.Replace("_", " "));
                }
                return ret;
            }
        }

        public void ValueSetString(String val)
        {
            bool success = false;
            T test = ValueParse(val, ref success);
            if( !success )
                throw new Exception("Enum set error");
            Value = test.ToString().Replace("_", " ");
        }

        public override string ToString()
        {
            return ValueString;
        }

        public override object ValueFromString(string s)
        {
            return (String)Value;
        }
    }

    public interface IEnumVar
    {
        List<String> Options { get; }
        void ValueSetString(String val);
        String ValueString{ get; }
    }
}
