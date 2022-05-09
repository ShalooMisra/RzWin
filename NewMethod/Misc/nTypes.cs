using System;
using System.Collections.Generic;
using System.Text;

namespace NewMethod
{
    public class nDouble
    {
        private Double m_Val = 0;

        //Public Contructors
        public nDouble()
        {
            m_Val = 0;
        }
        public nDouble(Double d)
        {
            m_Val = d;
        }
        public nDouble(Int16 i)
        {
            m_Val = Convert.ToDouble(i);
        }
        public nDouble(Int32 i)
        {
            m_Val = Convert.ToDouble(i);
        }
        public nDouble(Int64 i)
        {
            m_Val = Convert.ToDouble(i);
        }
        public nDouble(nDouble d)
        {
            m_Val = d.m_Val;
        }
        //Public Static Functions
        public static bool operator ==(nDouble t1, nDouble t2)
        {
            return t1.m_Val == t2.m_Val;
        }
        public static bool operator !=(nDouble t1, nDouble t2)
        {
            return t1.m_Val != t2.m_Val;
        }
        public static implicit operator nDouble(Double d)
        {
            nDouble dd = new nDouble();
            dd.m_Val = d;
            return dd;
        }
        public static implicit operator Double(nDouble d)
        {
            Double dd = d.m_Val;
            return dd;
        }
        public static implicit operator nDouble(String s)
        {
            nDouble d = 0;
            s = s.Replace("$", "");
            s = s.Replace("USD", "");
            s = s.Replace("usd", "");
            if (!Tools.Number.IsNumeric(s))
                return d;
            d = Double.Parse(s);
            return d;
        }
        public static implicit operator nDouble(nString s)
        {
            nDouble d = 0;
            s.Replace("$", "");
            s.Replace("USD", "");
            s.Replace("usd", "");
            s.Replace(",", "");
            if (!Tools.Number.IsNumeric(s))
                return d;
            d = Double.Parse(s);
            return d;
        }
        public static implicit operator nDouble(Int64 i)
        {
            nDouble ii = new nDouble(i);
            return ii;
        }
        public static implicit operator Int64(nDouble i)
        {
            return Convert.ToInt64(i.m_Val);
        }
        //Public Functions
        public nString MoneyFormat()
        {
            bool neg = false;
            if (m_Val < 0)
            {
                m_Val = m_Val * -1;
                neg = true;
            }
            nString str = "$" + (neg ? "-" : "") + nTools.MoneyFormat_2_6(m_Val);
            return str;
        }
        public override string ToString()
        {
            return m_Val.ToString();
        }
        public void TellUser(ContextNM x)
        {
            x.TheLeader.Tell(m_Val.ToString());
        }
    }

    public class nString
    {
        private String m_Val = "";

        //Public Contructors
        public nString()
        {
            m_Val = "";
        }
        public nString(String s)
        {
            m_Val = s;
        }
        public nString(nString s)
        {
            m_Val = s.m_Val;
        }
        //Public Static Functions
        public static bool operator ==(nString t1, nString t2)
        {
            return t1.m_Val == t2.m_Val;
        }
        public static bool operator ==(nString t1, String t2)
        {
            return t1.m_Val == t2;
        }
        public static bool operator !=(nString t1, nString t2)
        {
            return t1.m_Val != t2.m_Val;
        }
        public static bool operator !=(nString t1, String t2)
        {
            return t1.m_Val != t2;
        }
        public static implicit operator nString(String s)
        {
            nString ss = new nString();
            ss.m_Val = s;
            return ss;
        }
        public static implicit operator String(nString s)
        {
            String ss = s.m_Val;
            return ss;
        }
        //Public Functions
        public override string ToString()
        {
            return m_Val.ToString();
        }
        public nString ParseDelimit(String s, Int32 p)
        {
            if (!Exists())
                return new nString();
            return Tools.Strings.ParseDelimit(m_Val, s, p);
        }
        public nString AppendLine(String s)
        {
            nString n = new nString();
            m_Val += s + "\r\n";
            n = m_Val;
            return n;
        }
        public String[] Split(String split)
        {
            return Tools.Strings.Split(m_Val, split);
        }
        public nString Replace(String oldstr, String newstr)
        {
            if (!Exists())
                return new nString();
            nString s = m_Val.Replace(oldstr, newstr);
            m_Val = s;
            return s;
        }
        public Boolean Exists()
        {
            return Tools.Strings.StrExt(m_Val);
        }

        //what are these for?
        //public void TellUser()
        //{
        //    if (!Exists())
        //        return;
        //    context.TheLeader.Tell(m_Val);
        //}
        //public void SetStatus()
        //{
        //    if (!Exists())
        //        return;
        //    context.TheLeader.Comment(m_Val);
        //}

        public nString ToUpper()
        {
            m_Val = m_Val.ToUpper();
            return new nString(m_Val.ToUpper());
        }
        public nString ToLower()
        {
            m_Val = m_Val.ToLower();
            return new nString(m_Val.ToLower());
        }
    }

    public class nInt
    {
        private Int64 m_Val = 0;

        //Public Contructors
        public nInt()
        {
            m_Val = 0;
        }
        public nInt(Double i)
        {
            m_Val = Convert.ToInt64(i);
        }
        public nInt(Int16 i)
        {
            m_Val = i;
        }
        public nInt(Int32 i)
        {
            m_Val = i;
        }
        public nInt(Int64 i)
        {
            m_Val = i;
        }
        //Public Static Functions
        public static bool operator ==(nInt t1, nInt t2)
        {
            return t1.m_Val == t2.m_Val;
        }
        public static bool operator ==(nInt t1, Int16 t2)
        {
            return t1.m_Val == t2;
        }
        public static bool operator ==(nInt t1, Int32 t2)
        {
            return t1.m_Val == t2;
        }
        public static bool operator ==(nInt t1, Int64 t2)
        {
            return t1.m_Val == t2;
        }
        public static bool operator ==(nInt t1, Double t2)
        {
            return t1.m_Val == t2;
        }
        public static bool operator !=(nInt t1, nInt t2)
        {
            return t1.m_Val != t2.m_Val;
        }
        public static bool operator !=(nInt t1, Int16 t2)
        {
            return t1.m_Val != t2;
        }
        public static bool operator !=(nInt t1, Int32 t2)
        {
            return t1.m_Val != t2;
        }
        public static bool operator !=(nInt t1, Int64 t2)
        {
            return t1.m_Val != t2;
        }
        public static bool operator !=(nInt t1, Double t2)
        {
            return t1.m_Val != t2;
        }
        public static implicit operator nInt(Int16 i)
        {
            nInt ii = new nInt(i);
            return ii;
        }
        public static implicit operator Int16(nInt i)
        {
            Int16 ii = Convert.ToInt16(i.m_Val);
            return ii;
        }
        public static implicit operator nInt(Int32 i)
        {
            nInt ii = new nInt(i);
            return ii;
        }
        public static implicit operator Int32(nInt i)
        {
            Int32 ii = Convert.ToInt32(i.m_Val);
            return ii;
        }
        public static implicit operator nInt(Int64 i)
        {
            nInt ii = new nInt(i);
            return ii;
        }
        public static implicit operator Int64(nInt i)
        {
            Int64 ii = i.m_Val;
            return ii;
        }
        public static implicit operator nInt(Double i)
        {
            nInt ii = new nInt(i);
            return ii;
        }
        public static implicit operator Double(nInt i)
        {
            Double ii = Convert.ToDouble(i.m_Val);
            return ii;
        }
        public static implicit operator nInt(nDouble i)
        {
            nInt ii = new nInt(i);
            return ii;
        }
        public static implicit operator nDouble(nInt i)
        {
            Double ii = Convert.ToDouble(i.m_Val);
            return ii;
        }
        //Public Functions
        public override string ToString()
        {
            return m_Val.ToString();
        }
        //public void TellUser()
        //{
        //    context.TheLeader.Tell(m_Val.ToString());
        //}
    }
}
