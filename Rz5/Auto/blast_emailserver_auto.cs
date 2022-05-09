using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("blast_emailserver")]
    public partial class blast_emailserver_auto : NewMethod.nObject
    {
        static blast_emailserver_auto()
        {
            Item.AttributesCache(typeof(blast_emailserver_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "servername":
                    servernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "serverport":
                    serverportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "username":
                    usernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "password":
                    passwordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fromaddress":
                    fromaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "templatename":
                    templatenameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fromname":
                    fromnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ssl_required":
                    ssl_requiredAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute servernameAttribute;
        static CoreVarValAttribute serverportAttribute;
        static CoreVarValAttribute usernameAttribute;
        static CoreVarValAttribute passwordAttribute;
        static CoreVarValAttribute fromaddressAttribute;
        static CoreVarValAttribute templatenameAttribute;
        static CoreVarValAttribute fromnameAttribute;
        static CoreVarValAttribute ssl_requiredAttribute;

        [CoreVarVal("servername", "String", TheFieldLength = 255, Caption="Server Name", Importance = 1)]
        public VarString servernameVar;

        [CoreVarVal("serverport", "Int32", Caption="Server Port", Importance = 2)]
        public VarInt32 serverportVar;

        [CoreVarVal("username", "String", TheFieldLength = 255, Caption="User Name", Importance = 3)]
        public VarString usernameVar;

        [CoreVarVal("password", "String", TheFieldLength = 255, Caption="Password", Importance = 4)]
        public VarString passwordVar;

        [CoreVarVal("fromaddress", "String", TheFieldLength = 255, Caption="From Address", Importance = 5)]
        public VarString fromaddressVar;

        [CoreVarVal("templatename", "String", TheFieldLength = 255, Caption="Template Name", Importance = 6)]
        public VarString templatenameVar;

        [CoreVarVal("fromname", "String", TheFieldLength = 255, Caption="Fromname", Importance = 7)]
        public VarString fromnameVar;

        [CoreVarVal("ssl_required", "Boolean", Caption="Ssl Required", Importance = 8)]
        public VarBoolean ssl_requiredVar;

        public blast_emailserver_auto()
        {
            StaticInit();
            servernameVar = new VarString(this, servernameAttribute);
            serverportVar = new VarInt32(this, serverportAttribute);
            usernameVar = new VarString(this, usernameAttribute);
            passwordVar = new VarString(this, passwordAttribute);
            fromaddressVar = new VarString(this, fromaddressAttribute);
            templatenameVar = new VarString(this, templatenameAttribute);
            fromnameVar = new VarString(this, fromnameAttribute);
            ssl_requiredVar = new VarBoolean(this, ssl_requiredAttribute);
        }

        public override string ClassId
        { get { return "blast_emailserver"; } }

        public String servername
        {
            get  { return (String)servernameVar.Value; }
            set  { servernameVar.Value = value; }
        }

        public Int32 serverport
        {
            get  { return (Int32)serverportVar.Value; }
            set  { serverportVar.Value = value; }
        }

        public String username
        {
            get  { return (String)usernameVar.Value; }
            set  { usernameVar.Value = value; }
        }

        public String password
        {
            get  { return (String)passwordVar.Value; }
            set  { passwordVar.Value = value; }
        }

        public String fromaddress
        {
            get  { return (String)fromaddressVar.Value; }
            set  { fromaddressVar.Value = value; }
        }

        public String templatename
        {
            get  { return (String)templatenameVar.Value; }
            set  { templatenameVar.Value = value; }
        }

        public String fromname
        {
            get  { return (String)fromnameVar.Value; }
            set  { fromnameVar.Value = value; }
        }

        public Boolean ssl_required
        {
            get  { return (Boolean)ssl_requiredVar.Value; }
            set  { ssl_requiredVar.Value = value; }
        }

    }
    public partial class blast_emailserver
    {
        public static blast_emailserver New(Context x)
        {  return (blast_emailserver)x.Item("blast_emailserver"); }

        public static blast_emailserver GetById(Context x, String uid)
        { return (blast_emailserver)x.GetById("blast_emailserver", uid); }

        public static blast_emailserver QtO(Context x, String sql)
        { return (blast_emailserver)x.QtO("blast_emailserver", sql); }
    }
}
