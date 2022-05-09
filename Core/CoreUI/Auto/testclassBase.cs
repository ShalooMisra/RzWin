using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace CoreUI
{
    [CoreClass("testclass")]
    public partial class testclassBase : Core.Item
    {
        static testclassBase()
        {
            Item.AttributesCache(typeof(ListUserBase), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "teststring":
                    teststringAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute teststringAttribute;

        [CoreVarVal("teststring", "System.String")]
        public VarString teststringVar;

        public testclassBase(ItemArgs a) : base(a)
        {
            StaticInit();
            teststringVar = new VarString(this, teststringAttribute);
        }

        public override string ClassId
        {
            get
            {
                return "testclass";
            }
        }

        public String teststring
        {
            get
            {
                return (String)teststringVar.Value;
            }
            set
            {
                teststringVar.ValueSetDirect(value);
            }
        }

    }
}
