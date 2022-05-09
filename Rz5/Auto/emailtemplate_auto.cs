using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("emailtemplate")]
    public partial class emailtemplate_auto : NewMethod.nObject
    {
        static emailtemplate_auto()
        {
            Item.AttributesCache(typeof(emailtemplate_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "templatename":
                    templatenameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "emailbody":
                    emailbodyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "emailfooter":
                    emailfooterAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subjectstring":
                    subjectstringAttribute = (CoreVarValAttribute)attr;
                    break;
                case "class_name":
                    class_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertype":
                    ordertypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_vendormultiple":
                    is_vendormultipleAttribute = (CoreVarValAttribute)attr;
                    break;
                case "exclude_details":
                    exclude_detailsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_text":
                    is_textAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute templatenameAttribute;
        static CoreVarValAttribute emailbodyAttribute;
        static CoreVarValAttribute emailfooterAttribute;
        static CoreVarValAttribute subjectstringAttribute;
        static CoreVarValAttribute class_nameAttribute;
        static CoreVarValAttribute ordertypeAttribute;
        static CoreVarValAttribute is_vendormultipleAttribute;
        static CoreVarValAttribute exclude_detailsAttribute;
        static CoreVarValAttribute is_textAttribute;

        [CoreVarVal("templatename", "String", TheFieldLength = 50, Caption="Name", Importance = 1)]
        public VarString templatenameVar;

        [CoreVarVal("emailbody", "Text", Caption="Body", Importance = 2)]
        public VarText emailbodyVar;

        [CoreVarVal("emailfooter", "Text", Caption="Footer", Importance = 3)]
        public VarText emailfooterVar;

        [CoreVarVal("subjectstring", "String", TheFieldLength = 255, Caption="Subject", Importance = 4)]
        public VarString subjectstringVar;

        [CoreVarVal("class_name", "String", TheFieldLength = 50, Caption="Class Name", Importance = 5)]
        public VarString class_nameVar;

        [CoreVarVal("ordertype", "String", TheFieldLength = 255, Caption="Order Type", Importance = 6)]
        public VarString ordertypeVar;

        [CoreVarVal("is_vendormultiple", "Boolean", Caption="Is Vendor Multiple", Importance = 7)]
        public VarBoolean is_vendormultipleVar;

        [CoreVarVal("exclude_details", "Boolean", Caption="Exclude Details", Importance = 8)]
        public VarBoolean exclude_detailsVar;

        [CoreVarVal("is_text", "Boolean", Caption="Is Text", Importance = 9)]
        public VarBoolean is_textVar;

        public emailtemplate_auto()
        {
            StaticInit();
            templatenameVar = new VarString(this, templatenameAttribute);
            emailbodyVar = new VarText(this, emailbodyAttribute);
            emailfooterVar = new VarText(this, emailfooterAttribute);
            subjectstringVar = new VarString(this, subjectstringAttribute);
            class_nameVar = new VarString(this, class_nameAttribute);
            ordertypeVar = new VarString(this, ordertypeAttribute);
            is_vendormultipleVar = new VarBoolean(this, is_vendormultipleAttribute);
            exclude_detailsVar = new VarBoolean(this, exclude_detailsAttribute);
            is_textVar = new VarBoolean(this, is_textAttribute);
        }

        public override string ClassId
        { get { return "emailtemplate"; } }

        public String templatename
        {
            get  { return (String)templatenameVar.Value; }
            set  { templatenameVar.Value = value; }
        }

        public String emailbody
        {
            get  { return (String)emailbodyVar.Value; }
            set  { emailbodyVar.Value = value; }
        }

        public String emailfooter
        {
            get  { return (String)emailfooterVar.Value; }
            set  { emailfooterVar.Value = value; }
        }

        public String subjectstring
        {
            get  { return (String)subjectstringVar.Value; }
            set  { subjectstringVar.Value = value; }
        }

        public String class_name
        {
            get  { return (String)class_nameVar.Value; }
            set  { class_nameVar.Value = value; }
        }

        public String ordertype
        {
            get  { return (String)ordertypeVar.Value; }
            set  { ordertypeVar.Value = value; }
        }

        public Boolean is_vendormultiple
        {
            get  { return (Boolean)is_vendormultipleVar.Value; }
            set  { is_vendormultipleVar.Value = value; }
        }

        public Boolean exclude_details
        {
            get  { return (Boolean)exclude_detailsVar.Value; }
            set  { exclude_detailsVar.Value = value; }
        }

        public Boolean is_text
        {
            get  { return (Boolean)is_textVar.Value; }
            set  { is_textVar.Value = value; }
        }

    }
    public partial class emailtemplate
    {
        public static emailtemplate New(Context x)
        {  return (emailtemplate)x.Item("emailtemplate"); }

        public static emailtemplate GetById(Context x, String uid)
        { return (emailtemplate)x.GetById("emailtemplate", uid); }

        public static emailtemplate QtO(Context x, String sql)
        { return (emailtemplate)x.QtO("emailtemplate", sql); }
    }
}
