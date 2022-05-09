using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Core
{
    [CoreClass("DataKeySql", BaseClass="DataKey")]
    public class DataKeySqlBase : DataKey
    {
        static DataKeySqlBase()
        {
            Item.AttributesCache(typeof(DataKeySqlBase), AttributeCache);
        }

        static CoreVarValAttribute ServerNameAttribute;
        static CoreVarValAttribute DatabaseNameAttribute;
        static CoreVarValAttribute UserNameAttribute;
        static CoreVarValAttribute UserPasswordAttribute;
        static CoreVarValEnumAttribute ServerTypeAttribute;

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "ServerName":
                    ServerNameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "DatabaseName":
                    DatabaseNameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "UserName":
                    UserNameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "UserPassword":
                    UserPasswordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ServerType":
                    ServerTypeAttribute = (CoreVarValEnumAttribute)attr;
                    break;
            }
        }

        static void StaticInit()
        {

        }

        [CoreVarVal("ServerName", "String")]
        public VarString ServerNameVar;

        [CoreVarVal("DatabaseName", "String")]
        public VarString DatabaseNameVar;

        [CoreVarVal("UserName", "String")]
        public VarString UserNameVar;

        [CoreVarVal("UserPassword", "String")]
        public VarString UserPasswordVar;

        [CoreVarValEnum("ServerType", "Tools.Database.ServerType")]
        public VarEnum<Tools.Database.ServerType> ServerTypeVar;

        public DataKeySqlBase() //ItemArgs a
            : base()
        {
            StaticInit();

            ServerNameVar = new VarString(this, ServerNameAttribute);
            DatabaseNameVar = new VarString(this, DatabaseNameAttribute);
            UserNameVar = new VarString(this, UserNameAttribute);
            UserPasswordVar = new VarString(this, UserPasswordAttribute);
            ServerTypeVar = new VarEnum<Tools.Database.ServerType>(this, ServerTypeAttribute);
        }

        public override string ClassId
        {
            get
            {
                return "DataKeySql";
            }
        }

        public String DatabaseName
        {
            get
            {
                return (String)DatabaseNameVar.Value;
            }

            set
            {
                DatabaseNameVar.Value = value;
            }
        }

        public String ServerName
        {
            get
            {
                return (String)ServerNameVar.Value;
            }

            set
            {
                ServerNameVar.Value = value;
            }
        }

        public String UserName
        {
            get
            {
                return (String)UserNameVar.Value;
            }

            set
            {
                UserNameVar.Value = value;
            }
        }

        public String UserPassword
        {
            get
            {
                return (String)UserPasswordVar.Value;
            }

            set
            {
                UserPasswordVar.Value = value;
            }
        }
    }
}
