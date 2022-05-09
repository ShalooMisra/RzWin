using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("blast_adrhed")]
    public partial class blast_adrhed_auto : NewMethod.nObject
    {
        static blast_adrhed_auto()
        {
            Item.AttributesCache(typeof(blast_adrhed_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "list_name":
                    list_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_count":
                    total_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sent_count":
                    sent_countAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute list_nameAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute total_countAttribute;
        static CoreVarValAttribute sent_countAttribute;

        [CoreVarVal("list_name", "String", TheFieldLength = 255, Caption="List Name", Importance = 1)]
        public VarString list_nameVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 2)]
        public VarString descriptionVar;

        [CoreVarVal("total_count", "Int64", Caption="Total Count", Importance = 3)]
        public VarInt64 total_countVar;

        [CoreVarVal("sent_count", "Int64", Caption="Sent Count", Importance = 4)]
        public VarInt64 sent_countVar;

        public blast_adrhed_auto()
        {
            StaticInit();
            list_nameVar = new VarString(this, list_nameAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            total_countVar = new VarInt64(this, total_countAttribute);
            sent_countVar = new VarInt64(this, sent_countAttribute);
        }

        public override string ClassId
        { get { return "blast_adrhed"; } }

        public String list_name
        {
            get  { return (String)list_nameVar.Value; }
            set  { list_nameVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public Int64 total_count
        {
            get  { return (Int64)total_countVar.Value; }
            set  { total_countVar.Value = value; }
        }

        public Int64 sent_count
        {
            get  { return (Int64)sent_countVar.Value; }
            set  { sent_countVar.Value = value; }
        }

    }
    public partial class blast_adrhed
    {
        public static blast_adrhed New(Context x)
        {  return (blast_adrhed)x.Item("blast_adrhed"); }

        public static blast_adrhed GetById(Context x, String uid)
        { return (blast_adrhed)x.GetById("blast_adrhed", uid); }

        public static blast_adrhed QtO(Context x, String sql)
        { return (blast_adrhed)x.QtO("blast_adrhed", sql); }
    }
}
