using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class DataKeyBase : Item
    {
        static DataKeyBase()
        {
            Item.AttributesCache(typeof(DataKeyBase), AttributeCache);
        }

        static CoreVarValAttribute NameAttribute;
        static CoreVarValAttribute FolderPathAttribute;

        static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "Name":
                    NameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "FolderPath":
                    FolderPathAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static void StaticInit()
        {

        }

        [CoreVarVal("Name", "String")]
        public VarString NameVar;
        public String Name
        {
            get
            {
                return (String)NameVar.Value;
            }
            set
            {
                NameVar.Value = value;
            }
        }

        [CoreVarVal("FolderPath", "String")]
        public VarString FolderPathVar;

        public DataKeyBase()  //ItemArgs a
           // : base(a)
        {
            StaticInit();

            NameVar = new VarString(this, NameAttribute);
            FolderPathVar = new VarString(this, FolderPathAttribute);
        }

        public override string ClassId
        {
            get
            {
                return "DataKey";
            }
        }
    }
}
