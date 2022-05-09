using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("export_log")]
    public partial class export_log_auto : NewMethod.nObject
    {
        static export_log_auto()
        {
            Item.AttributesCache(typeof(export_log_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "export_name":
                    export_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "export_date":
                    export_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "export_rows":
                    export_rowsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "log_text":
                    log_textAttribute = (CoreVarValAttribute)attr;
                    break;
                case "end_date":
                    end_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "total_seconds":
                    total_secondsAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute export_nameAttribute;
        static CoreVarValAttribute export_dateAttribute;
        static CoreVarValAttribute export_rowsAttribute;
        static CoreVarValAttribute log_textAttribute;
        static CoreVarValAttribute end_dateAttribute;
        static CoreVarValAttribute total_secondsAttribute;

        [CoreVarVal("export_name", "String", TheFieldLength = 255, Caption="Export Name", Importance = 1)]
        public VarString export_nameVar;

        [CoreVarVal("export_date", "DateTime", Caption="Export Date", Importance = 2)]
        public VarDateTime export_dateVar;

        [CoreVarVal("export_rows", "Int64", Caption="Export Rows", Importance = 3)]
        public VarInt64 export_rowsVar;

        [CoreVarVal("log_text", "Text", Caption="Log Text", Importance = 4)]
        public VarText log_textVar;

        [CoreVarVal("end_date", "DateTime", Caption="End Date", Importance = 5)]
        public VarDateTime end_dateVar;

        [CoreVarVal("total_seconds", "Int64", Caption="Total Seconds", Importance = 6)]
        public VarInt64 total_secondsVar;

        public export_log_auto()
        {
            StaticInit();
            export_nameVar = new VarString(this, export_nameAttribute);
            export_dateVar = new VarDateTime(this, export_dateAttribute);
            export_rowsVar = new VarInt64(this, export_rowsAttribute);
            log_textVar = new VarText(this, log_textAttribute);
            end_dateVar = new VarDateTime(this, end_dateAttribute);
            total_secondsVar = new VarInt64(this, total_secondsAttribute);
        }

        public override string ClassId
        { get { return "export_log"; } }

        public String export_name
        {
            get  { return (String)export_nameVar.Value; }
            set  { export_nameVar.Value = value; }
        }

        public DateTime export_date
        {
            get  { return (DateTime)export_dateVar.Value; }
            set  { export_dateVar.Value = value; }
        }

        public Int64 export_rows
        {
            get  { return (Int64)export_rowsVar.Value; }
            set  { export_rowsVar.Value = value; }
        }

        public String log_text
        {
            get  { return (String)log_textVar.Value; }
            set  { log_textVar.Value = value; }
        }

        public DateTime end_date
        {
            get  { return (DateTime)end_dateVar.Value; }
            set  { end_dateVar.Value = value; }
        }

        public Int64 total_seconds
        {
            get  { return (Int64)total_secondsVar.Value; }
            set  { total_secondsVar.Value = value; }
        }

    }
    public partial class export_log
    {
        public static export_log New(Context x)
        {  return (export_log)x.Item("export_log"); }

        public static export_log GetById(Context x, String uid)
        { return (export_log)x.GetById("export_log", uid); }

        public static export_log QtO(Context x, String sql)
        { return (export_log)x.QtO("export_log", sql); }
    }
}
