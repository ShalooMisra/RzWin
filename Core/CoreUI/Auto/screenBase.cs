using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace CoreUI
{
    [CoreClass("screen", SystemSupport=true)]
    public partial class screenBase : CoreUI.spot
    {
        static screenBase()
        {
            Item.AttributesCache(typeof(screenBase), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "SpotsAll":
                    SpotsAllAttribute = (CoreVarRefManyAttribute)attr;
                    break;
                case "Name":
                    NameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarRefManyAttribute SpotsAllAttribute;
        static CoreVarValAttribute NameAttribute;

        [CoreVarRefMany("SpotsAll", "CoreUI.screen", "CoreUI.spot", "Screen")]
        public VarRefInstanceMany<CoreUI.screen, CoreUI.spot> SpotsAllVar;

        [CoreVarVal("Name", "System.String")]
        public VarString NameVar;

        public screenBase(ItemArgs a) : base(a)
        {
            StaticInit();
            SpotsAllVar = new VarRefInstanceMany<CoreUI.screen, CoreUI.spot>(this, SpotsAllAttribute);
            NameVar = new VarString(this, NameAttribute);
        }

        public override string ClassId
        {
            get
            {
                return "screen";
            }
        }

        public String Name
        {
            get
            {
                return (String)NameVar.Value;
            }
            set
            {
                NameVar.ValueSetDirect(value);
            }
        }

    }
}
