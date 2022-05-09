//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Reflection;

//using Core;

//namespace Rz4
//{
//    [CoreClass("user_activity", Importance = -1)]
//    public partial class user_activity_auto : NewMethod.nObject
//    {
//        static user_activity_auto()
//        {
//            Item.AttributesCache(typeof(user_activity_auto), AttributeCache);
//        }

//        static void StaticInit()
//        {

//        }

//        public static void AttributeCache(CoreAttribute attr)
//        {
//            switch (attr.Name)
//            {
//                case "the_companycontact_uid":
//                    the_companycontact_uidAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "the_n_user_uid":
//                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "name":
//                    nameAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "description":
//                    descriptionAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "user_name":
//                    user_nameAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "contact_caption":
//                    contact_captionAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "activity_type":
//                    activity_typeAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "activity_value":
//                    activity_valueAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "link_list":
//                    link_listAttribute = (CoreVarValAttribute)attr;
//                    break;
//                case "instance_id":
//                    instance_idAttribute = (CoreVarValAttribute)attr;
//                    break;
//            }
//        }

//        static CoreVarValAttribute the_companycontact_uidAttribute;
//        static CoreVarValAttribute the_n_user_uidAttribute;
//        static CoreVarValAttribute nameAttribute;
//        static CoreVarValAttribute descriptionAttribute;
//        static CoreVarValAttribute user_nameAttribute;
//        static CoreVarValAttribute contact_captionAttribute;
//        static CoreVarValAttribute activity_typeAttribute;
//        static CoreVarValAttribute activity_valueAttribute;
//        static CoreVarValAttribute link_listAttribute;
//        static CoreVarValAttribute instance_idAttribute;

//        [CoreVarVal("the_companycontact_uid", "String", TheFieldLength = 255, Caption="The Companycontact Uid", Importance = 1)]
//        public VarString the_companycontact_uidVar;

//        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 2)]
//        public VarString the_n_user_uidVar;

//        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 3)]
//        public VarString nameVar;

//        [CoreVarVal("description", "Text", Caption="Description", Importance = 4)]
//        public VarText descriptionVar;

//        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 5)]
//        public VarString user_nameVar;

//        [CoreVarVal("contact_caption", "String", TheFieldLength = 255, Caption="Contact Caption", Importance = 6)]
//        public VarString contact_captionVar;

//        [CoreVarVal("activity_type", "String", TheFieldLength = 255, Caption="Activity Type", Importance = 7)]
//        public VarString activity_typeVar;

//        [CoreVarVal("activity_value", "Double", Caption="Activity Value", Importance = 8)]
//        public VarDouble activity_valueVar;

//        [CoreVarVal("link_list", "Text", Caption="Link List", Importance = 9)]
//        public VarText link_listVar;

//        [CoreVarVal("instance_id", "String", TheFieldLength = 255, Caption="Instance Id", Importance = 10)]
//        public VarString instance_idVar;

//        public user_activity_auto()
//        {
//            StaticInit();
//            the_companycontact_uidVar = new VarString(this, the_companycontact_uidAttribute);
//            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
//            nameVar = new VarString(this, nameAttribute);
//            descriptionVar = new VarText(this, descriptionAttribute);
//            user_nameVar = new VarString(this, user_nameAttribute);
//            contact_captionVar = new VarString(this, contact_captionAttribute);
//            activity_typeVar = new VarString(this, activity_typeAttribute);
//            activity_valueVar = new VarDouble(this, activity_valueAttribute);
//            link_listVar = new VarText(this, link_listAttribute);
//            instance_idVar = new VarString(this, instance_idAttribute);
//        }

//        public override string ClassId
//        { get { return "user_activity"; } }

//        public String the_companycontact_uid
//        {
//            get  { return (String)the_companycontact_uidVar.Value; }
//            set  { the_companycontact_uidVar.Value = value; }
//        }

//        public String the_n_user_uid
//        {
//            get  { return (String)the_n_user_uidVar.Value; }
//            set  { the_n_user_uidVar.Value = value; }
//        }

//        public String name
//        {
//            get  { return (String)nameVar.Value; }
//            set  { nameVar.Value = value; }
//        }

//        public String description
//        {
//            get  { return (String)descriptionVar.Value; }
//            set  { descriptionVar.Value = value; }
//        }

//        public String user_name
//        {
//            get  { return (String)user_nameVar.Value; }
//            set  { user_nameVar.Value = value; }
//        }

//        public String contact_caption
//        {
//            get  { return (String)contact_captionVar.Value; }
//            set  { contact_captionVar.Value = value; }
//        }

//        public String activity_type
//        {
//            get  { return (String)activity_typeVar.Value; }
//            set  { activity_typeVar.Value = value; }
//        }

//        public Double activity_value
//        {
//            get  { return (Double)activity_valueVar.Value; }
//            set  { activity_valueVar.Value = value; }
//        }

//        public String link_list
//        {
//            get  { return (String)link_listVar.Value; }
//            set  { link_listVar.Value = value; }
//        }

//        public String instance_id
//        {
//            get  { return (String)instance_idVar.Value; }
//            set  { instance_idVar.Value = value; }
//        }

//    }
//    public partial class user_activity
//    {
//        public static user_activity New(Context x)
//        {  return (user_activity)x.Item("user_activity"); }

//        public static user_activity GetById(Context x, String uid)
//        { return (user_activity)x.GetById("user_activity", uid); }

//        public static user_activity QtO(Context x, String sql)
//        { return (user_activity)x.QtO("user_activity", sql); }

//        public static user_activity GetByName(Context x, String name, String extraSql = "")
//        { return (user_activity)x.GetByName("user_activity", name, extraSql); }
//    }
//}
