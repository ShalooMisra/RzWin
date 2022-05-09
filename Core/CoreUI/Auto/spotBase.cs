using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace CoreUI
{
    [CoreClass("spot", SystemSupport=true)]
    public partial class spotBase : Core.Item
    {
        static spotBase()
        {
            Item.AttributesCache(typeof(spotBase), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "top_abs":
                    top_absAttribute = (CoreVarValAttribute)attr;
                    break;
                case "left_abs":
                    left_absAttribute = (CoreVarValAttribute)attr;
                    break;
                case "width_abs":
                    width_absAttribute = (CoreVarValAttribute)attr;
                    break;
                case "height_abs":
                    height_absAttribute = (CoreVarValAttribute)attr;
                    break;
                case "view_type":
                    view_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_class_id":
                    alternate_class_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "spot_info":
                    spot_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "Screen":
                    ScreenAttribute = (CoreVarRefSingleAttribute)attr;
                    break;
                case "Spot":
                    SpotAttribute = (CoreVarRefSingleAttribute)attr;
                    break;
                case "Spots":
                    SpotsAttribute = (CoreVarRefManyAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute top_absAttribute;
        static CoreVarValAttribute left_absAttribute;
        static CoreVarValAttribute width_absAttribute;
        static CoreVarValAttribute height_absAttribute;
        static CoreVarValAttribute view_typeAttribute;
        static CoreVarValAttribute alternate_class_idAttribute;
        static CoreVarValAttribute spot_infoAttribute;
        static CoreVarRefSingleAttribute ScreenAttribute;
        static CoreVarRefSingleAttribute SpotAttribute;
        static CoreVarRefManyAttribute SpotsAttribute;

        [CoreVarVal("top_abs", "Double")]
        public VarDouble top_absVar;

        [CoreVarVal("left_abs", "Double")]
        public VarDouble left_absVar;

        [CoreVarVal("width_abs", "Double")]
        public VarDouble width_absVar;

        [CoreVarVal("height_abs", "Double")]
        public VarDouble height_absVar;

        [CoreVarValEnum("view_type", "CoreUI.SpotViewType")]
        public VarEnum<CoreUI.SpotViewType> view_typeVar;

        [CoreVarVal("alternate_class_id", "String")]
        public VarString alternate_class_idVar;

        [CoreVarVal("spot_info", "String")]
        public VarString spot_infoVar;

        [CoreVarRefSingle("Screen", "CoreUI.spot", "CoreUI.screen", "SpotsAll")]
        public VarRefInstanceSingle<CoreUI.spot, CoreUI.screen> ScreenVar;

        [CoreVarRefSingle("Spot", "CoreUI.spot", "CoreUI.spot", "Spots")]
        public VarRefInstanceSingle<CoreUI.spot, CoreUI.spot> SpotVar;

        [CoreVarRefMany("Spots", "CoreUI.spot", "CoreUI.spot", "Spot")]
        public VarRefInstanceManyCollected<CoreUI.spot, CoreUI.spot> SpotsVar;

        public spotBase(ItemArgs a) : base(a)
        {
            StaticInit();
            top_absVar = new VarDouble(this, top_absAttribute);
            left_absVar = new VarDouble(this, left_absAttribute);
            width_absVar = new VarDouble(this, width_absAttribute);
            height_absVar = new VarDouble(this, height_absAttribute);
            view_typeVar = new VarEnum<CoreUI.SpotViewType>(new ItemArgs(a.TheContext, this), AttributeGet("view_typeVar"));
            alternate_class_idVar = new VarString(this, alternate_class_idAttribute);
            spot_infoVar = new VarString(this, spot_infoAttribute);
            ScreenVar = new VarRefInstanceSingle<CoreUI.spot, CoreUI.screen>(this, ScreenAttribute);
            SpotVar = new VarRefInstanceSingle<CoreUI.spot, CoreUI.spot>(this, SpotAttribute);
            SpotsVar = new VarRefInstanceManyCollected<CoreUI.spot, CoreUI.spot>(this, SpotsAttribute, ScreenVar);
        }

        public override string ClassId
        {
            get
            {
                return "spot";
            }
        }

        public Double top_abs
        {
            get
            {
                return (Double)top_absVar.Value;
            }
            set
            {
                top_absVar.ValueSetDirect(value);
            }
        }

        public Double left_abs
        {
            get
            {
                return (Double)left_absVar.Value;
            }
            set
            {
                left_absVar.ValueSetDirect(value);
            }
        }

        public Double width_abs
        {
            get
            {
                return (Double)width_absVar.Value;
            }
            set
            {
                width_absVar.ValueSetDirect(value);
            }
        }

        public Double height_abs
        {
            get
            {
                return (Double)height_absVar.Value;
            }
            set
            {
                height_absVar.ValueSetDirect(value);
            }
        }

        public SpotViewType view_type
        {
            get
            {
                return (SpotViewType)view_typeVar.Value;
            }
            set
            {
                view_typeVar.ValueSetDirect(value);
            }
        }

        public String alternate_class_id
        {
            get
            {
                return (String)alternate_class_idVar.Value;
            }
            set
            {
                alternate_class_idVar.ValueSetDirect(value);
            }
        }

        public String spot_info
        {
            get
            {
                return (String)spot_infoVar.Value;
            }
            set
            {
                spot_infoVar.ValueSetDirect(value);
            }
        }

    }
}
