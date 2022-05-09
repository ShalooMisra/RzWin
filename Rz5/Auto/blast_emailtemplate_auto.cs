using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("blast_emailtemplate")]
    public partial class blast_emailtemplate_auto : NewMethod.nObject
    {
        static blast_emailtemplate_auto()
        {
            Item.AttributesCache(typeof(blast_emailtemplate_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "template_name":
                    template_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_subject":
                    email_subjectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_body":
                    email_bodyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_text":
                    is_textAttribute = (CoreVarValAttribute)attr;
                    break;
                case "attachments":
                    attachmentsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "seo_id":
                    seo_idAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute template_nameAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute email_subjectAttribute;
        static CoreVarValAttribute email_bodyAttribute;
        static CoreVarValAttribute is_textAttribute;
        static CoreVarValAttribute attachmentsAttribute;
        static CoreVarValAttribute seo_idAttribute;

        [CoreVarVal("template_name", "String", TheFieldLength = 255, Caption="Template Name", Importance = 1)]
        public VarString template_nameVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 2)]
        public VarString descriptionVar;

        [CoreVarVal("email_subject", "String", TheFieldLength = 255, Caption="Email Subject", Importance = 3)]
        public VarString email_subjectVar;

        [CoreVarVal("email_body", "Text", Caption="Email Body", Importance = 4)]
        public VarText email_bodyVar;

        [CoreVarVal("is_text", "Boolean", Caption="Is Text", Importance = 5)]
        public VarBoolean is_textVar;

        [CoreVarVal("attachments", "Text", Caption="Attachments", Importance = 6)]
        public VarText attachmentsVar;

        [CoreVarVal("seo_id", "String", TheFieldLength = 255, Caption="Seo Id", Importance = 7)]
        public VarString seo_idVar;

        public blast_emailtemplate_auto()
        {
            StaticInit();
            template_nameVar = new VarString(this, template_nameAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            email_subjectVar = new VarString(this, email_subjectAttribute);
            email_bodyVar = new VarText(this, email_bodyAttribute);
            is_textVar = new VarBoolean(this, is_textAttribute);
            attachmentsVar = new VarText(this, attachmentsAttribute);
            seo_idVar = new VarString(this, seo_idAttribute);
        }

        public override string ClassId
        { get { return "blast_emailtemplate"; } }

        public String template_name
        {
            get  { return (String)template_nameVar.Value; }
            set  { template_nameVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String email_subject
        {
            get  { return (String)email_subjectVar.Value; }
            set  { email_subjectVar.Value = value; }
        }

        public String email_body
        {
            get  { return (String)email_bodyVar.Value; }
            set  { email_bodyVar.Value = value; }
        }

        public Boolean is_text
        {
            get  { return (Boolean)is_textVar.Value; }
            set  { is_textVar.Value = value; }
        }

        public String attachments
        {
            get  { return (String)attachmentsVar.Value; }
            set  { attachmentsVar.Value = value; }
        }

        public String seo_id
        {
            get  { return (String)seo_idVar.Value; }
            set  { seo_idVar.Value = value; }
        }

    }
    public partial class blast_emailtemplate
    {
        public static blast_emailtemplate New(Context x)
        {  return (blast_emailtemplate)x.Item("blast_emailtemplate"); }

        public static blast_emailtemplate GetById(Context x, String uid)
        { return (blast_emailtemplate)x.GetById("blast_emailtemplate", uid); }

        public static blast_emailtemplate QtO(Context x, String sql)
        { return (blast_emailtemplate)x.QtO("blast_emailtemplate", sql); }
    }
}
