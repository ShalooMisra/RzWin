using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("virtual_floor")]
    public partial class virtual_floor_auto : NewMethod.nObject
    {
        static virtual_floor_auto()
        {
            Item.AttributesCache(typeof(virtual_floor_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "background":
                    backgroundAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute backgroundAttribute;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("background", "Blob", Caption="Background", Importance = 2)]
        public VarBlob backgroundVar;

        public virtual_floor_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            backgroundVar = new VarBlob(this, backgroundAttribute);
        }

        public override string ClassId
        { get { return "virtual_floor"; } }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String background
        {
            get  { return (String)backgroundVar.Value; }
            set  { backgroundVar.Value = value; }
        }

    }
    public partial class virtual_floor
    {
        public static virtual_floor New(Context x)
        {  return (virtual_floor)x.Item("virtual_floor"); }

        public static virtual_floor GetById(Context x, String uid)
        { return (virtual_floor)x.GetById("virtual_floor", uid); }

        public static virtual_floor QtO(Context x, String sql)
        { return (virtual_floor)x.QtO("virtual_floor", sql); }

        public static virtual_floor GetByName(Context x, String name, String extraSql = "")
        { return (virtual_floor)x.GetByName("virtual_floor", name, extraSql); }
    }
}
