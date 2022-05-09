using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("import_summary")]
    public partial class import_summary_auto : NewMethod.nObject
    {
        static import_summary_auto()
        {
            Item.AttributesCache(typeof(import_summary_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "importid":
                    importidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importdate":
                    importdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "importnotes":
                    importnotesAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute importidAttribute;
        static CoreVarValAttribute importdateAttribute;
        static CoreVarValAttribute importnotesAttribute;

        [CoreVarVal("importid", "String", TheFieldLength = 255, Caption="Importid", Importance = 1)]
        public VarString importidVar;

        [CoreVarVal("importdate", "DateTime", Caption="Importdate", Importance = 2)]
        public VarDateTime importdateVar;

        [CoreVarVal("importnotes", "Text", Caption="Importnotes", Importance = 3)]
        public VarText importnotesVar;

        public import_summary_auto()
        {
            StaticInit();
            importidVar = new VarString(this, importidAttribute);
            importdateVar = new VarDateTime(this, importdateAttribute);
            importnotesVar = new VarText(this, importnotesAttribute);
        }

        public override string ClassId
        { get { return "import_summary"; } }

        public String importid
        {
            get  { return (String)importidVar.Value; }
            set  { importidVar.Value = value; }
        }

        public DateTime importdate
        {
            get  { return (DateTime)importdateVar.Value; }
            set  { importdateVar.Value = value; }
        }

        public String importnotes
        {
            get  { return (String)importnotesVar.Value; }
            set  { importnotesVar.Value = value; }
        }

    }
    public partial class import_summary
    {
        public static import_summary New(Context x)
        {  return (import_summary)x.Item("import_summary"); }

        public static import_summary GetById(Context x, String uid)
        { return (import_summary)x.GetById("import_summary", uid); }

        public static import_summary QtO(Context x, String sql)
        { return (import_summary)x.QtO("import_summary", sql); }
    }
}
