using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("printheader")]
    public partial class printheader_auto : NewMethod.nObject
    {
        static printheader_auto()
        {
            Item.AttributesCache(typeof(printheader_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printname":
                    printnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printtag":
                    printtagAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printdescription":
                    printdescriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertype":
                    ordertypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printername":
                    printernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "copycount":
                    copycountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "colhedfont":
                    colhedfontAttribute = (CoreVarValAttribute)attr;
                    break;
                case "colhedfontsize":
                    colhedfontsizeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "colhedfontbold":
                    colhedfontboldAttribute = (CoreVarValAttribute)attr;
                    break;
                case "colhedfontitalic":
                    colhedfontitalicAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printpoinfo":
                    printpoinfoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "riderdata":
                    riderdataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_landscape":
                    is_landscapeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "width_index":
                    width_indexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "height_index":
                    height_indexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "new_format":
                    new_formatAttribute = (CoreVarValAttribute)attr;
                    break;
                case "paper_size":
                    paper_sizeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "scale_multiplier":
                    scale_multiplierAttribute = (CoreVarValAttribute)attr;
                    break;
                case "has_extras":
                    has_extrasAttribute = (CoreVarValAttribute)attr;
                    break;
                case "class_name":
                    class_nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute printnameAttribute;
        static CoreVarValAttribute printtagAttribute;
        static CoreVarValAttribute printdescriptionAttribute;
        static CoreVarValAttribute ordertypeAttribute;
        static CoreVarValAttribute printernameAttribute;
        static CoreVarValAttribute copycountAttribute;
        static CoreVarValAttribute colhedfontAttribute;
        static CoreVarValAttribute colhedfontsizeAttribute;
        static CoreVarValAttribute colhedfontboldAttribute;
        static CoreVarValAttribute colhedfontitalicAttribute;
        static CoreVarValAttribute printpoinfoAttribute;
        static CoreVarValAttribute riderdataAttribute;
        static CoreVarValAttribute is_landscapeAttribute;
        static CoreVarValAttribute width_indexAttribute;
        static CoreVarValAttribute height_indexAttribute;
        static CoreVarValAttribute new_formatAttribute;
        static CoreVarValAttribute paper_sizeAttribute;
        static CoreVarValAttribute scale_multiplierAttribute;
        static CoreVarValAttribute has_extrasAttribute;
        static CoreVarValAttribute class_nameAttribute;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 255, Caption="Base Mc User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("printname", "String", TheFieldLength = 255, Caption="Layout Name", Importance = 2)]
        public VarString printnameVar;

        [CoreVarVal("printtag", "String", TheFieldLength = 255, Caption="Layout Tag", Importance = 3)]
        public VarString printtagVar;

        [CoreVarVal("printdescription", "String", TheFieldLength = 255, Caption="Layout Description", Importance = 4)]
        public VarString printdescriptionVar;

        [CoreVarVal("ordertype", "String", TheFieldLength = 50, Caption="Order Type", Importance = 5)]
        public VarString ordertypeVar;

        [CoreVarVal("printername", "String", TheFieldLength = 50, Caption="Printer Name", Importance = 6)]
        public VarString printernameVar;

        [CoreVarVal("copycount", "Int32", Caption="Copy Count", Importance = 7)]
        public VarInt32 copycountVar;

        [CoreVarVal("colhedfont", "String", TheFieldLength = 50, Caption="Column Header Font", Importance = 8)]
        public VarString colhedfontVar;

        [CoreVarVal("colhedfontsize", "Int64", Caption="Column Header Font Size", Importance = 9)]
        public VarInt64 colhedfontsizeVar;

        [CoreVarVal("colhedfontbold", "Boolean", Caption="Column Header Bold", Importance = 10)]
        public VarBoolean colhedfontboldVar;

        [CoreVarVal("colhedfontitalic", "Boolean", Caption="Column Header Italic", Importance = 11)]
        public VarBoolean colhedfontitalicVar;

        [CoreVarVal("printpoinfo", "Boolean", Caption="Print Po Info", Importance = 12)]
        public VarBoolean printpoinfoVar;

        [CoreVarVal("riderdata", "String", TheFieldLength = 8000, Caption="Rider Data", Importance = 13)]
        public VarString riderdataVar;

        [CoreVarVal("is_landscape", "Boolean", Caption="Is Landscape", Importance = 14)]
        public VarBoolean is_landscapeVar;

        [CoreVarVal("width_index", "Int64", Caption="Width Index", Importance = 15)]
        public VarInt64 width_indexVar;

        [CoreVarVal("height_index", "Int64", Caption="Height Index", Importance = 16)]
        public VarInt64 height_indexVar;

        [CoreVarVal("new_format", "Boolean", Caption="New Format", Importance = 17)]
        public VarBoolean new_formatVar;

        [CoreVarVal("paper_size", "String", TheFieldLength = 255, Caption="Paper Size", Importance = 18)]
        public VarString paper_sizeVar;

        [CoreVarVal("scale_multiplier", "Double", Caption="Scale Multiplier", Importance = 19)]
        public VarDouble scale_multiplierVar;

        [CoreVarVal("has_extras", "Boolean", Caption="Has Extras", Importance = 20)]
        public VarBoolean has_extrasVar;

        [CoreVarVal("class_name", "String", TheFieldLength = 255, Caption="Class Name", Importance = 21)]
        public VarString class_nameVar;

        public printheader_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            printnameVar = new VarString(this, printnameAttribute);
            printtagVar = new VarString(this, printtagAttribute);
            printdescriptionVar = new VarString(this, printdescriptionAttribute);
            ordertypeVar = new VarString(this, ordertypeAttribute);
            printernameVar = new VarString(this, printernameAttribute);
            copycountVar = new VarInt32(this, copycountAttribute);
            colhedfontVar = new VarString(this, colhedfontAttribute);
            colhedfontsizeVar = new VarInt64(this, colhedfontsizeAttribute);
            colhedfontboldVar = new VarBoolean(this, colhedfontboldAttribute);
            colhedfontitalicVar = new VarBoolean(this, colhedfontitalicAttribute);
            printpoinfoVar = new VarBoolean(this, printpoinfoAttribute);
            riderdataVar = new VarString(this, riderdataAttribute);
            is_landscapeVar = new VarBoolean(this, is_landscapeAttribute);
            width_indexVar = new VarInt64(this, width_indexAttribute);
            height_indexVar = new VarInt64(this, height_indexAttribute);
            new_formatVar = new VarBoolean(this, new_formatAttribute);
            paper_sizeVar = new VarString(this, paper_sizeAttribute);
            scale_multiplierVar = new VarDouble(this, scale_multiplierAttribute);
            has_extrasVar = new VarBoolean(this, has_extrasAttribute);
            class_nameVar = new VarString(this, class_nameAttribute);
        }

        public override string ClassId
        { get { return "printheader"; } }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String printname
        {
            get  { return (String)printnameVar.Value; }
            set  { printnameVar.Value = value; }
        }

        public String printtag
        {
            get  { return (String)printtagVar.Value; }
            set  { printtagVar.Value = value; }
        }

        public String printdescription
        {
            get  { return (String)printdescriptionVar.Value; }
            set  { printdescriptionVar.Value = value; }
        }

        public String ordertype
        {
            get  { return (String)ordertypeVar.Value; }
            set  { ordertypeVar.Value = value; }
        }

        public String printername
        {
            get  { return (String)printernameVar.Value; }
            set  { printernameVar.Value = value; }
        }

        public Int32 copycount
        {
            get  { return (Int32)copycountVar.Value; }
            set  { copycountVar.Value = value; }
        }

        public String colhedfont
        {
            get  { return (String)colhedfontVar.Value; }
            set  { colhedfontVar.Value = value; }
        }

        public Int64 colhedfontsize
        {
            get  { return (Int64)colhedfontsizeVar.Value; }
            set  { colhedfontsizeVar.Value = value; }
        }

        public Boolean colhedfontbold
        {
            get  { return (Boolean)colhedfontboldVar.Value; }
            set  { colhedfontboldVar.Value = value; }
        }

        public Boolean colhedfontitalic
        {
            get  { return (Boolean)colhedfontitalicVar.Value; }
            set  { colhedfontitalicVar.Value = value; }
        }

        public Boolean printpoinfo
        {
            get  { return (Boolean)printpoinfoVar.Value; }
            set  { printpoinfoVar.Value = value; }
        }

        public String riderdata
        {
            get  { return (String)riderdataVar.Value; }
            set  { riderdataVar.Value = value; }
        }

        public Boolean is_landscape
        {
            get  { return (Boolean)is_landscapeVar.Value; }
            set  { is_landscapeVar.Value = value; }
        }

        public Int64 width_index
        {
            get  { return (Int64)width_indexVar.Value; }
            set  { width_indexVar.Value = value; }
        }

        public Int64 height_index
        {
            get  { return (Int64)height_indexVar.Value; }
            set  { height_indexVar.Value = value; }
        }

        public Boolean new_format
        {
            get  { return (Boolean)new_formatVar.Value; }
            set  { new_formatVar.Value = value; }
        }

        public String paper_size
        {
            get  { return (String)paper_sizeVar.Value; }
            set  { paper_sizeVar.Value = value; }
        }

        public Double scale_multiplier
        {
            get  { return (Double)scale_multiplierVar.Value; }
            set  { scale_multiplierVar.Value = value; }
        }

        public Boolean has_extras
        {
            get  { return (Boolean)has_extrasVar.Value; }
            set  { has_extrasVar.Value = value; }
        }

        public String class_name
        {
            get  { return (String)class_nameVar.Value; }
            set  { class_nameVar.Value = value; }
        }

    }
    public partial class printheader
    {
        public static printheader New(Context x)
        {  return (printheader)x.Item("printheader"); }

        public static printheader GetById(Context x, String uid)
        { return (printheader)x.GetById("printheader", uid); }

        public static printheader QtO(Context x, String sql)
        { return (printheader)x.QtO("printheader", sql); }
    }
}
