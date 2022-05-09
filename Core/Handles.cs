using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Core
{
    public class CoreClassHandle
    {
        public CoreClassAttribute TheAttribute;
        public Type TheType;

        public String Name
        {
            get
            {
                return TheAttribute.Name;
            }
        }

        public CoreClassHandle(CoreClassAttribute attr, Type t)
        {
            TheAttribute = attr;
            TheType = t;
        }

        //this is duplicated in Item; need to consolidate
        public List<CoreVarAttribute> VarsGet()
        {
            return Item.VarAttributesGet(TheType);
        }

        public List<CoreVarValAttribute> VarValsGet()
        {
            return Item.VarValAttributesGet(TheType);
        }

        public List<CoreVarValAttribute> VarValsGetSortedAlpha()
        {
            List<CoreVarValAttribute> ret = VarValsGet();
            ret.Sort(CoreAttribute.CompareByName);
            return ret;
        }

        public CoreVarAttribute VarGet(String prop)
        {
            foreach (CoreVarAttribute a in VarsGet())
            {
                if (Tools.Strings.StrCmp(a.Name, prop))
                    return a;
            }
            return null;
        }

        public CoreVarValAttribute VarValGet(String prop)
        {
            foreach (CoreVarValAttribute a in VarValsGet())
            {
                if (Tools.Strings.StrCmp(a.Name, prop))
                    return a;
            }
            return null;
        }

        //private static bool FilterMembersByAttributeType(MemberInfo info, object state)
        //{
        //    Type desired_attribute_type = (Type)state;
        //    object[] attrs = info.GetCustomAttributes(desired_attribute_type, false);
        //    return (attrs.Length > 0);
        //}

        public string GetFieldList()
        {
            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (CoreVarValAttribute a in VarValsGet())
            {
                if (!first)
                    sb.Append(", ");

                sb.Append(a.Name);
                first = false;
            }

            return sb.ToString();
        }
    }
}
