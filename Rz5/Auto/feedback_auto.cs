using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("feedback")]
    public partial class feedback_auto : NewMethod.nObject
    {
        static feedback_auto()
        {
            Item.AttributesCache(typeof(feedback_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_company_uid":
                    the_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feedback_type":
                    feedback_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "comment":
                    commentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "auto_key":
                    auto_keyAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute the_company_uidAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute feedback_typeAttribute;
        static CoreVarValAttribute commentAttribute;
        static CoreVarValAttribute auto_keyAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("the_company_uid", "String", TheFieldLength = 255, Caption="The Company Uid", Importance = 2)]
        public VarString the_company_uidVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 255, Caption="Agent Name", Importance = 3)]
        public VarString agentnameVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 4)]
        public VarString companynameVar;

        [CoreVarVal("feedback_type", "String", TheFieldLength = 255, Caption="Feedback Type", Importance = 5)]
        public VarString feedback_typeVar;

        [CoreVarVal("comment", "Text", Caption="Comment", Importance = 6)]
        public VarText commentVar;

        [CoreVarVal("auto_key", "String", TheFieldLength = 255, Caption="Auto Key", Importance = 7)]
        public VarString auto_keyVar;

        public feedback_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            the_company_uidVar = new VarString(this, the_company_uidAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            feedback_typeVar = new VarString(this, feedback_typeAttribute);
            commentVar = new VarText(this, commentAttribute);
            auto_keyVar = new VarString(this, auto_keyAttribute);
        }

        public override string ClassId
        { get { return "feedback"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String the_company_uid
        {
            get  { return (String)the_company_uidVar.Value; }
            set  { the_company_uidVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String feedback_type
        {
            get  { return (String)feedback_typeVar.Value; }
            set  { feedback_typeVar.Value = value; }
        }

        public String comment
        {
            get  { return (String)commentVar.Value; }
            set  { commentVar.Value = value; }
        }

        public String auto_key
        {
            get  { return (String)auto_keyVar.Value; }
            set  { auto_keyVar.Value = value; }
        }

    }
    public partial class feedback
    {
        public static feedback New(Context x)
        {  return (feedback)x.Item("feedback"); }

        public static feedback GetById(Context x, String uid)
        { return (feedback)x.GetById("feedback", uid); }

        public static feedback QtO(Context x, String sql)
        { return (feedback)x.QtO("feedback", sql); }
    }
}
