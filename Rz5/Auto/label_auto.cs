using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("label")]
    public partial class label_auto : NewMethod.nObject
    {
        static label_auto()
        {
            Item.AttributesCache(typeof(label_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "labelname":
                    labelnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "printername":
                    printernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "labeldata":
                    labeldataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "islandscape":
                    islandscapeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "labelwidth":
                    labelwidthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "labelheight":
                    labelheightAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontname":
                    fontnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontsize":
                    fontsizeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontbold":
                    fontboldAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fontitalic":
                    fontitalicAttribute = (CoreVarValAttribute)attr;
                    break;
                case "startx":
                    startxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "starty":
                    startyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute labelnameAttribute;
        static CoreVarValAttribute printernameAttribute;
        static CoreVarValAttribute labeldataAttribute;
        static CoreVarValAttribute islandscapeAttribute;
        static CoreVarValAttribute labelwidthAttribute;
        static CoreVarValAttribute labelheightAttribute;
        static CoreVarValAttribute fontnameAttribute;
        static CoreVarValAttribute fontsizeAttribute;
        static CoreVarValAttribute fontboldAttribute;
        static CoreVarValAttribute fontitalicAttribute;
        static CoreVarValAttribute startxAttribute;
        static CoreVarValAttribute startyAttribute;
        static CoreVarValAttribute descriptionAttribute;

        [CoreVarVal("labelname", "String", TheFieldLength = 50, Caption="Label Name", Importance = 1)]
        public VarString labelnameVar;

        [CoreVarVal("printername", "String", TheFieldLength = 255, Caption="Printer Name", Importance = 2)]
        public VarString printernameVar;

        [CoreVarVal("labeldata", "String", TheFieldLength = 8000, Caption="Label Data", Importance = 3)]
        public VarString labeldataVar;

        [CoreVarVal("islandscape", "Boolean", Caption="Is Landscape", Importance = 4)]
        public VarBoolean islandscapeVar;

        [CoreVarVal("labelwidth", "Int64", Caption="Label Width", Importance = 5)]
        public VarInt64 labelwidthVar;

        [CoreVarVal("labelheight", "Int64", Caption="Label Height", Importance = 6)]
        public VarInt64 labelheightVar;

        [CoreVarVal("fontname", "String", TheFieldLength = 50, Caption="Font Name", Importance = 7)]
        public VarString fontnameVar;

        [CoreVarVal("fontsize", "Int32", Caption="Font Size", Importance = 8)]
        public VarInt32 fontsizeVar;

        [CoreVarVal("fontbold", "Boolean", Caption="Font Bold", Importance = 9)]
        public VarBoolean fontboldVar;

        [CoreVarVal("fontitalic", "Boolean", Caption="Font Italic", Importance = 10)]
        public VarBoolean fontitalicVar;

        [CoreVarVal("startx", "Int64", Caption="Start X", Importance = 11)]
        public VarInt64 startxVar;

        [CoreVarVal("starty", "Int64", Caption="Start Y", Importance = 12)]
        public VarInt64 startyVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 13)]
        public VarString descriptionVar;

        public label_auto()
        {
            StaticInit();
            labelnameVar = new VarString(this, labelnameAttribute);
            printernameVar = new VarString(this, printernameAttribute);
            labeldataVar = new VarString(this, labeldataAttribute);
            islandscapeVar = new VarBoolean(this, islandscapeAttribute);
            labelwidthVar = new VarInt64(this, labelwidthAttribute);
            labelheightVar = new VarInt64(this, labelheightAttribute);
            fontnameVar = new VarString(this, fontnameAttribute);
            fontsizeVar = new VarInt32(this, fontsizeAttribute);
            fontboldVar = new VarBoolean(this, fontboldAttribute);
            fontitalicVar = new VarBoolean(this, fontitalicAttribute);
            startxVar = new VarInt64(this, startxAttribute);
            startyVar = new VarInt64(this, startyAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
        }

        public override string ClassId
        { get { return "label"; } }

        public String labelname
        {
            get  { return (String)labelnameVar.Value; }
            set  { labelnameVar.Value = value; }
        }

        public String printername
        {
            get  { return (String)printernameVar.Value; }
            set  { printernameVar.Value = value; }
        }

        public String labeldata
        {
            get  { return (String)labeldataVar.Value; }
            set  { labeldataVar.Value = value; }
        }

        public Boolean islandscape
        {
            get  { return (Boolean)islandscapeVar.Value; }
            set  { islandscapeVar.Value = value; }
        }

        public Int64 labelwidth
        {
            get  { return (Int64)labelwidthVar.Value; }
            set  { labelwidthVar.Value = value; }
        }

        public Int64 labelheight
        {
            get  { return (Int64)labelheightVar.Value; }
            set  { labelheightVar.Value = value; }
        }

        public String fontname
        {
            get  { return (String)fontnameVar.Value; }
            set  { fontnameVar.Value = value; }
        }

        public Int32 fontsize
        {
            get  { return (Int32)fontsizeVar.Value; }
            set  { fontsizeVar.Value = value; }
        }

        public Boolean fontbold
        {
            get  { return (Boolean)fontboldVar.Value; }
            set  { fontboldVar.Value = value; }
        }

        public Boolean fontitalic
        {
            get  { return (Boolean)fontitalicVar.Value; }
            set  { fontitalicVar.Value = value; }
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

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

    }
    public partial class label
    {
        public static label New(Context x)
        {  return (label)x.Item("label"); }

        public static label GetById(Context x, String uid)
        { return (label)x.GetById("label", uid); }

        public static label QtO(Context x, String sql)
        { return (label)x.QtO("label", sql); }
    }
}
