using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Tools;
using Tools.Database;

namespace Core
{
    public class Var : IVar, IDisposable
    {
        IItem m_Parent;
        public IItem Parent
        {
            get
            {
                return m_Parent;
            }

            set
            {
                m_Parent = value;
            }
        }

        public bool Changed = false;

        protected Object m_Value;
        public virtual Object Value
        {
            get { return m_Value; }
            set
            {
                m_Value = value;
                Changed = true;
            }
        }

        public String Name
        {
            get
            {
                return TheAttribute.Name;
            }
        }

        CoreVarAttribute m_TheAttribute;
        public CoreVarAttribute TheAttribute
        {
            get { return m_TheAttribute; }
            set { m_TheAttribute = value; }
        }
        public Var(IItem parent, CoreVarAttribute attr)
        {
            Parent = parent;
            TheAttribute = attr;
        }

        //public virtual bool ValueSameIs(Object v)
        //{            
        //    return false;
        //}

        ////should this be allowed?
        ////2011_10_22 will be replaced by the delta system
        //public void ValueSetDirect(Object v)
        //{
        //    m_Value = v;
        //    //m_ValuesChanged = true;
        //    //if (Container != null)
        //    //    Container.ValuesChangedSetDirect(true);
        //}

        //public virtual bool ValueSet(Context x, Object v)
        //{
        //    return ValueSet(x, v, true);
        //}

        //public virtual bool ValueSet(Context x, Object v, bool changed)
        //{
        //    if (ValueSameIs(x, v))
        //        return true;

        //    //should this hit the delta?
        //    //for now, lets have the change flags be the responsibility of the var
        //    //and have when its sent to the delta be the responsibility of the parent item
        //    //but what about when we want to show just an item's var in a view?
        //    //maybe a different control for that, like a VarContainer?
            
        //    m_Value = v;

        //    //2011_10_22 will be replaced by the delta system
        //    //if( changed )
        //    //    ValuesChangedSet(x, true);
        //    return true;
        //}

        //public VarStatus StatusGet(Context x, String v)
        //{
        //    VarStatus ret = new VarStatus();
        //    ret.Changed = !ValueSame(ValueFromString(v));

        //    String mess = "";
        //    ret.Acceptable = ValueAcceptable(x, v, ref mess);
        //    ret.AcceptableMessage = mess;
            
        //    StatusCheck(x, ret, v);
        //    return ret;
        //}

        protected virtual void StatusCheck(Context x, VarStatus s, String v)
        {
            
        }

        protected virtual bool ValueAcceptable(Context x, String v, ref String message)
        {
            return true;
        }

        public virtual Object ValueFromString(String s)
        {
            throw new NotImplementedException("Ni");
        }

        protected virtual void FieldValuesAppend(Context x, List<Tools.Database.FieldValue> values, bool changed_only)
        {
            //2011_10_22 the delta system needs to handle this now
            //if (!ValuesChanged && changed_only)
            //    return;

            
        }

        public virtual void Absorb(Context x, System.Data.DataRow r)
        {

        }

        public virtual String ValueString
        {
            get
            {
                return "";
            }
        }

        public virtual void Dispose()
        {

        }

        public List<FieldValue> FieldValuesGet(Context x, bool changed_only)
        {
            List<FieldValue> ret = new List<FieldValue>();
            FieldValuesAppend(x, ret, changed_only);
            return ret;
        }
    }

    public class VarStatus
    {
        public bool Changed = false;
        public bool Acceptable = true;
        public String AcceptableMessage;
    }

    public interface IVar
    {
        Object Value { get; }
        IItem Parent { get; }
        CoreVarAttribute TheAttribute { get; }
    }
}
