using Core;
using System;


namespace Rz5
{
    [CoreClass("recent_item", Caption = "Recently Opened Items", Importance = 85)]
    public partial class recent_item_auto : NewMethod.nObject
    {
        static recent_item_auto()
        {
            Item.AttributesCache(typeof(recent_item_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }
        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "item_uid":
                    item_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "item_name":
                    item_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "item_classid":
                    item_classidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "item_orderType":
                    item_orderTypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_uid":
                    user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_bookmarked":
                    is_bookmarkedAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }


        static CoreVarValAttribute item_uidAttribute;
        static CoreVarValAttribute item_nameAttribute;
        static CoreVarValAttribute item_classidAttribute;
        static CoreVarValAttribute item_orderTypeAttribute;        
        static CoreVarValAttribute user_uidAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute is_bookmarkedAttribute;


        [CoreVarVal("item_uid", "String", TheFieldLength = 255, Caption = "Item Id", Importance = 1)]
        public VarString item_uidVar;

        [CoreVarVal("item_name", "String", TheFieldLength = 255, Caption = "Item Name", Importance = 2)]
        public VarString item_nameVar;


        [CoreVarVal("item_classid", "String", TheFieldLength = 255, Caption = "Item Class ID", Importance = 2)]
        public VarString item_classidVar;

        [CoreVarVal("item_orderType", "String", TheFieldLength = 255, Caption = "Item Order Type (for line items)", Importance = 2)]
        public VarString item_orderTypeVar;
        

        [CoreVarVal("user_uid", "String", TheFieldLength = 255, Caption = "n_user uid", Importance = 3)]
        public VarString user_uidVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption = "user_name", Importance = 5)]
        public VarString user_nameVar;

        [CoreVarVal("is_bookmarked", "Boolean", Caption = "Is Bookmarked / Pinned", Importance = 10)]
        public VarBoolean is_bookmarkedVar;


        public recent_item_auto()
        {
            StaticInit();
            item_uidVar = new VarString(this, item_uidAttribute);
            item_nameVar = new VarString(this, item_nameAttribute);
            item_classidVar = new VarString(this, item_classidAttribute);
            item_orderTypeVar = new VarString(this, item_orderTypeAttribute);            
            user_uidVar = new VarString(this, user_uidAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            is_bookmarkedVar = new VarBoolean(this, is_bookmarkedAttribute);


        }

        public override string ClassId
        { get { return "recent_item"; } }

        public string item_uid
        {
            get { return (string)item_uidVar.Value; }
            set { item_uidVar.Value = value; }
        }

        public string item_name
        {
            get { return (string)item_nameVar.Value; }
            set { item_nameVar.Value = value; }
        }

        public string item_classid
        {
            get { return (string)item_classidVar.Value; }
            set { item_classidVar.Value = value; }
        }

        public string item_orderType
        {
            get { return (string)item_orderTypeVar.Value; }
            set { item_orderTypeVar.Value = value; }
        }
               

        public string user_uid
        {
            get { return (string)user_uidVar.Value; }
            set { user_uidVar.Value = value; }
        }


        public string user_name
        {
            get { return (string)user_nameVar.Value; }
            set { user_nameVar.Value = value; }
        }

        public bool is_bookmarked
        {
            get { return (bool)is_bookmarkedVar.Value; }
            set { is_bookmarkedVar.Value = value; }
        }


    }
    public partial class recent_item
    {
        public static recent_item New(Context x)
        { return (recent_item)x.Item("recent_item"); }

        public static recent_item GetById(Context x, String uid)
        { return (recent_item)x.GetById("recent_item", uid); }

        public static recent_item QtO(Context x, String sql)
        { return (recent_item)x.QtO("recent_item", sql); }

    }

  

}
