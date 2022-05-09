using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("test_pictures")]
    public partial class test_pictures_auto : NewMethod.nObject
    {
        static test_pictures_auto()
        {
            Item.AttributesCache(typeof(test_pictures_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_ordhed_uid":
                    the_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "caption_1":
                    caption_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "caption_2":
                    caption_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "pic_1":
                    pic_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "pic_2":
                    pic_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "pic_3":
                    pic_3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "pic_4":
                    pic_4Attribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_ordhed_uidAttribute;
        static CoreVarValAttribute caption_1Attribute;
        static CoreVarValAttribute caption_2Attribute;
        static CoreVarValAttribute pic_1Attribute;
        static CoreVarValAttribute pic_2Attribute;
        static CoreVarValAttribute pic_3Attribute;
        static CoreVarValAttribute pic_4Attribute;

        [CoreVarVal("the_ordhed_uid", "String", TheFieldLength = 255, Caption="The Ordhed Uid", Importance = 1)]
        public VarString the_ordhed_uidVar;

        [CoreVarVal("caption_1", "String", TheFieldLength = 255, Caption="Caption 1", Importance = 2)]
        public VarString caption_1Var;

        [CoreVarVal("caption_2", "String", TheFieldLength = 255, Caption="Caption 2", Importance = 3)]
        public VarString caption_2Var;

        [CoreVarVal("pic_1", "Blob", Caption="Pic 1", Importance = 4)]
        public VarBlob pic_1Var;

        [CoreVarVal("pic_2", "Blob", Caption="Pic 2", Importance = 5)]
        public VarBlob pic_2Var;

        [CoreVarVal("pic_3", "Blob", Caption="Pic 3", Importance = 6)]
        public VarBlob pic_3Var;

        [CoreVarVal("pic_4", "Blob", Caption="Pic 4", Importance = 7)]
        public VarBlob pic_4Var;

        public test_pictures_auto()
        {
            StaticInit();
            the_ordhed_uidVar = new VarString(this, the_ordhed_uidAttribute);
            caption_1Var = new VarString(this, caption_1Attribute);
            caption_2Var = new VarString(this, caption_2Attribute);
            pic_1Var = new VarBlob(this, pic_1Attribute);
            pic_2Var = new VarBlob(this, pic_2Attribute);
            pic_3Var = new VarBlob(this, pic_3Attribute);
            pic_4Var = new VarBlob(this, pic_4Attribute);
        }

        public override string ClassId
        { get { return "test_pictures"; } }

        public String the_ordhed_uid
        {
            get  { return (String)the_ordhed_uidVar.Value; }
            set  { the_ordhed_uidVar.Value = value; }
        }

        public String caption_1
        {
            get  { return (String)caption_1Var.Value; }
            set  { caption_1Var.Value = value; }
        }

        public String caption_2
        {
            get  { return (String)caption_2Var.Value; }
            set  { caption_2Var.Value = value; }
        }

        public String pic_1
        {
            get  { return (String)pic_1Var.Value; }
            set  { pic_1Var.Value = value; }
        }

        public String pic_2
        {
            get  { return (String)pic_2Var.Value; }
            set  { pic_2Var.Value = value; }
        }

        public String pic_3
        {
            get  { return (String)pic_3Var.Value; }
            set  { pic_3Var.Value = value; }
        }

        public String pic_4
        {
            get  { return (String)pic_4Var.Value; }
            set  { pic_4Var.Value = value; }
        }

    }
    public partial class test_pictures
    {
        public static test_pictures New(Context x)
        {  return (test_pictures)x.Item("test_pictures"); }

        public static test_pictures GetById(Context x, String uid)
        { return (test_pictures)x.GetById("test_pictures", uid); }

        public static test_pictures QtO(Context x, String sql)
        { return (test_pictures)x.QtO("test_pictures", sql); }
    }
}
