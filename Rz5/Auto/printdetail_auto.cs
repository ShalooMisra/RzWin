using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("printdetail")]
    public partial class printdetail_auto : NewMethod.nObject
    {
        static printdetail_auto()
        {
            Item.AttributesCache(typeof(printdetail_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_printheader_uid":
                    base_printheader_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "startx":
                    startxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "starty":
                    startyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stopx":
                    stopxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stopy":
                    stopyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontname":
                    fontnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "textstring":
                    textstringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "filename":
                    filenameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "centerx1":
                    centerx1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "centerx2":
                    centerx2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "fontbold":
                    fontboldAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontitalic":
                    fontitalicAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontcolor":
                    fontcolorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "detailtype":
                    detailtypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "drawwidth":
                    drawwidthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "detailname":
                    detailnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontsize":
                    fontsizeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "style_info":
                    style_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "max_width":
                    max_widthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_file_name":
                    alternate_file_nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_printheader_uidAttribute;
        static CoreVarValAttribute startxAttribute;
        static CoreVarValAttribute startyAttribute;
        static CoreVarValAttribute stopxAttribute;
        static CoreVarValAttribute stopyAttribute;
        static CoreVarValAttribute fontnameAttribute;
        static CoreVarValAttribute textstringAttribute;
        static CoreVarValAttribute filenameAttribute;
        static CoreVarValAttribute centerx1Attribute;
        static CoreVarValAttribute centerx2Attribute;
        static CoreVarValAttribute fontboldAttribute;
        static CoreVarValAttribute fontitalicAttribute;
        static CoreVarValAttribute fontcolorAttribute;
        static CoreVarValAttribute detailtypeAttribute;
        static CoreVarValAttribute drawwidthAttribute;
        static CoreVarValAttribute detailnameAttribute;
        static CoreVarValAttribute fontsizeAttribute;
        static CoreVarValAttribute style_infoAttribute;
        static CoreVarValAttribute max_widthAttribute;
        static CoreVarValAttribute alternate_file_nameAttribute;

        [CoreVarVal("base_printheader_uid", "String", TheFieldLength = 50, Caption="Base Printheader Id", Importance = 1)]
        public VarString base_printheader_uidVar;

        [CoreVarVal("startx", "Int64", Caption="Start X", Importance = 2)]
        public VarInt64 startxVar;

        [CoreVarVal("starty", "Int64", Caption="Starty", Importance = 3)]
        public VarInt64 startyVar;

        [CoreVarVal("stopx", "Int64", Caption="Stop X", Importance = 4)]
        public VarInt64 stopxVar;

        [CoreVarVal("stopy", "Int64", Caption="Stopy", Importance = 5)]
        public VarInt64 stopyVar;

        [CoreVarVal("fontname", "String", TheFieldLength = 255, Caption="Font Name", Importance = 6)]
        public VarString fontnameVar;

        [CoreVarVal("textstring", "String", TheFieldLength = 8000, Caption="Text", Importance = 7)]
        public VarString textstringVar;

        [CoreVarVal("filename", "String", TheFieldLength = 255, Caption="Picture File", Importance = 8)]
        public VarString filenameVar;

        [CoreVarVal("centerx1", "Int64", Caption="Center X 1", Importance = 9)]
        public VarInt64 centerx1Var;

        [CoreVarVal("centerx2", "Int64", Caption="Center X 2", Importance = 10)]
        public VarInt64 centerx2Var;

        [CoreVarVal("fontbold", "Boolean", Caption="Bold", Importance = 11)]
        public VarBoolean fontboldVar;

        [CoreVarVal("fontitalic", "Int32", Caption="Italic", Importance = 12)]
        public VarInt32 fontitalicVar;

        [CoreVarVal("fontcolor", "Int64", Caption="Color", Importance = 13)]
        public VarInt64 fontcolorVar;

        [CoreVarVal("detailtype", "String", TheFieldLength = 50, Caption="Detail Type", Importance = 14)]
        public VarString detailtypeVar;

        [CoreVarVal("drawwidth", "Int32", Caption="Draw Width", Importance = 15)]
        public VarInt32 drawwidthVar;

        [CoreVarVal("detailname", "String", TheFieldLength = 50, Caption="Detail Name", Importance = 16)]
        public VarString detailnameVar;

        [CoreVarVal("fontsize", "Int32", Caption="Font Size", Importance = 17)]
        public VarInt32 fontsizeVar;

        [CoreVarVal("style_info", "String", TheFieldLength = 8000, Caption="Style Info", Importance = 18)]
        public VarString style_infoVar;

        [CoreVarVal("max_width", "Int32", Caption="Max Width", Importance = 19)]
        public VarInt32 max_widthVar;

        [CoreVarVal("alternate_file_name", "String", TheFieldLength = 255, Caption="Alternate File Name", Importance = 22)]
        public VarString alternate_file_nameVar;

        public printdetail_auto()
        {
            StaticInit();
            base_printheader_uidVar = new VarString(this, base_printheader_uidAttribute);
            startxVar = new VarInt64(this, startxAttribute);
            startyVar = new VarInt64(this, startyAttribute);
            stopxVar = new VarInt64(this, stopxAttribute);
            stopyVar = new VarInt64(this, stopyAttribute);
            fontnameVar = new VarString(this, fontnameAttribute);
            textstringVar = new VarString(this, textstringAttribute);
            filenameVar = new VarString(this, filenameAttribute);
            centerx1Var = new VarInt64(this, centerx1Attribute);
            centerx2Var = new VarInt64(this, centerx2Attribute);
            fontboldVar = new VarBoolean(this, fontboldAttribute);
            fontitalicVar = new VarInt32(this, fontitalicAttribute);
            fontcolorVar = new VarInt64(this, fontcolorAttribute);
            detailtypeVar = new VarString(this, detailtypeAttribute);
            drawwidthVar = new VarInt32(this, drawwidthAttribute);
            detailnameVar = new VarString(this, detailnameAttribute);
            fontsizeVar = new VarInt32(this, fontsizeAttribute);
            style_infoVar = new VarString(this, style_infoAttribute);
            max_widthVar = new VarInt32(this, max_widthAttribute);
            alternate_file_nameVar = new VarString(this, alternate_file_nameAttribute);
        }

        public override string ClassId
        { get { return "printdetail"; } }

        public String base_printheader_uid
        {
            get  { return (String)base_printheader_uidVar.Value; }
            set  { base_printheader_uidVar.Value = value; }
        }

        public Int64 startx
        {
            get  { return (Int64)startxVar.Value; }
            set  { startxVar.Value = value; }
        }

        public Int64 starty
        {
            get  { return (Int64)startyVar.Value; }
            set  { startyVar.Value = value; }
        }

        public Int64 stopx
        {
            get  { return (Int64)stopxVar.Value; }
            set  { stopxVar.Value = value; }
        }

        public Int64 stopy
        {
            get  { return (Int64)stopyVar.Value; }
            set  { stopyVar.Value = value; }
        }

        public String fontname
        {
            get  { return (String)fontnameVar.Value; }
            set  { fontnameVar.Value = value; }
        }

        public String textstring
        {
            get  { return (String)textstringVar.Value; }
            set  { textstringVar.Value = value; }
        }

        public String filename
        {
            get  { return (String)filenameVar.Value; }
            set  { filenameVar.Value = value; }
        }

        public Int64 centerx1
        {
            get  { return (Int64)centerx1Var.Value; }
            set  { centerx1Var.Value = value; }
        }

        public Int64 centerx2
        {
            get  { return (Int64)centerx2Var.Value; }
            set  { centerx2Var.Value = value; }
        }

        public Boolean fontbold
        {
            get  { return (Boolean)fontboldVar.Value; }
            set  { fontboldVar.Value = value; }
        }

        public Int32 fontitalic
        {
            get  { return (Int32)fontitalicVar.Value; }
            set  { fontitalicVar.Value = value; }
        }

        public Int64 fontcolor
        {
            get  { return (Int64)fontcolorVar.Value; }
            set  { fontcolorVar.Value = value; }
        }

        public String detailtype
        {
            get  { return (String)detailtypeVar.Value; }
            set  { detailtypeVar.Value = value; }
        }

        public Int32 drawwidth
        {
            get  { return (Int32)drawwidthVar.Value; }
            set  { drawwidthVar.Value = value; }
        }

        public String detailname
        {
            get  { return (String)detailnameVar.Value; }
            set  { detailnameVar.Value = value; }
        }

        public Int32 fontsize
        {
            get  { return (Int32)fontsizeVar.Value; }
            set  { fontsizeVar.Value = value; }
        }

        public String style_info
        {
            get  { return (String)style_infoVar.Value; }
            set  { style_infoVar.Value = value; }
        }

        public Int32 max_width
        {
            get  { return (Int32)max_widthVar.Value; }
            set  { max_widthVar.Value = value; }
        }

        public String alternate_file_name
        {
            get  { return (String)alternate_file_nameVar.Value; }
            set  { alternate_file_nameVar.Value = value; }
        }

    }
    public partial class printdetail
    {
        public static printdetail New(Context x)
        {  return (printdetail)x.Item("printdetail"); }

        public static printdetail GetById(Context x, String uid)
        { return (printdetail)x.GetById("printdetail", uid); }

        public static printdetail QtO(Context x, String sql)
        { return (printdetail)x.QtO("printdetail", sql); }
    }
}
