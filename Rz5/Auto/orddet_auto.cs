using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("orddet", Abstract = true)]
    public partial class orddet_auto : Rz5.part
    {
        static orddet_auto()
        {
            Item.AttributesCache(typeof(orddet_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "isvoid":
                    isvoidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "status":
                    statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "noPrint":
                    noPrintAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute isvoidAttribute;
        static CoreVarValAttribute statusAttribute;
        static CoreVarValAttribute noPrintAttribute;

        [CoreVarVal("isvoid", "Boolean", Caption="Is Void", Importance = 107)]
        public VarBoolean isvoidVar;

        [CoreVarVal("status", "String", TheFieldLength = 255, Caption="Status", Importance = 108)]
        public VarString statusVar;

        [CoreVarVal("noPrint", "Boolean", Caption = "Exclude this line from printing", Importance = 247)]
        public VarBoolean noPrintVar;


        public orddet_auto()
        {
            StaticInit();
            isvoidVar = new VarBoolean(this, isvoidAttribute);
            statusVar = new VarString(this, statusAttribute);
            noPrintVar = new VarBoolean(this, noPrintAttribute);
        }

        public override string ClassId
        { get { return "orddet"; } }

        public Boolean isvoid
        {
            get  { return (Boolean)isvoidVar.Value; }
            set  { isvoidVar.Value = value; }
        }

        public String status
        {
            get  { return (String)statusVar.Value; }
            set  { statusVar.Value = value; }
        }

        public bool noPrint
        {
            get { return (bool)noPrintVar.Value; }
            set { noPrintVar.Value = value; }
        }
    }
    public partial class orddet
    {
        public static orddet New(Context x)
        {  return (orddet)x.Item("orddet"); }

        public static orddet GetById(Context x, String uid)
        { return (orddet)x.GetById("orddet", uid); }

        public static orddet QtO(Context x, String sql)
        { return (orddet)x.QtO("orddet", sql); }
    }
}
