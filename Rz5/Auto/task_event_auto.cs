using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("task_event")]
    public partial class task_event_auto : NewMethod.nObject
    {
        static task_event_auto()
        {
            Item.AttributesCache(typeof(task_event_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "user_uid":
                    user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "user_name":
                    user_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "from_status":
                    from_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "to_status":
                    to_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "event_date":
                    event_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "task_uid":
                    task_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "from_user":
                    from_userAttribute = (CoreVarValAttribute)attr;
                    break;
                case "to_user":
                    to_userAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute user_uidAttribute;
        static CoreVarValAttribute user_nameAttribute;
        static CoreVarValAttribute from_statusAttribute;
        static CoreVarValAttribute to_statusAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute event_dateAttribute;
        static CoreVarValAttribute task_uidAttribute;
        static CoreVarValAttribute from_userAttribute;
        static CoreVarValAttribute to_userAttribute;

        [CoreVarVal("user_uid", "String", TheFieldLength = 255, Caption="User Uid", Importance = 1)]
        public VarString user_uidVar;

        [CoreVarVal("user_name", "String", TheFieldLength = 255, Caption="User Name", Importance = 2)]
        public VarString user_nameVar;

        [CoreVarVal("from_status", "String", TheFieldLength = 255, Caption="From Status", Importance = 3)]
        public VarString from_statusVar;

        [CoreVarVal("to_status", "String", TheFieldLength = 255, Caption="To Status", Importance = 4)]
        public VarString to_statusVar;

        [CoreVarVal("notes", "Text", Caption="Notes", Importance = 5)]
        public VarText notesVar;

        [CoreVarVal("event_date", "DateTime", Caption="Event Date", Importance = 6)]
        public VarDateTime event_dateVar;

        [CoreVarVal("task_uid", "String", TheFieldLength = 255, Caption="Task Uid", Importance = 7)]
        public VarString task_uidVar;

        [CoreVarVal("from_user", "String", TheFieldLength = 255, Caption="From User", Importance = 8)]
        public VarString from_userVar;

        [CoreVarVal("to_user", "String", TheFieldLength = 255, Caption="To User", Importance = 9)]
        public VarString to_userVar;

        public task_event_auto()
        {
            StaticInit();
            user_uidVar = new VarString(this, user_uidAttribute);
            user_nameVar = new VarString(this, user_nameAttribute);
            from_statusVar = new VarString(this, from_statusAttribute);
            to_statusVar = new VarString(this, to_statusAttribute);
            notesVar = new VarText(this, notesAttribute);
            event_dateVar = new VarDateTime(this, event_dateAttribute);
            task_uidVar = new VarString(this, task_uidAttribute);
            from_userVar = new VarString(this, from_userAttribute);
            to_userVar = new VarString(this, to_userAttribute);
        }

        public override string ClassId
        { get { return "task_event"; } }

        public String user_uid
        {
            get  { return (String)user_uidVar.Value; }
            set  { user_uidVar.Value = value; }
        }

        public String user_name
        {
            get  { return (String)user_nameVar.Value; }
            set  { user_nameVar.Value = value; }
        }

        public String from_status
        {
            get  { return (String)from_statusVar.Value; }
            set  { from_statusVar.Value = value; }
        }

        public String to_status
        {
            get  { return (String)to_statusVar.Value; }
            set  { to_statusVar.Value = value; }
        }

        public String notes
        {
            get  { return (String)notesVar.Value; }
            set  { notesVar.Value = value; }
        }

        public DateTime event_date
        {
            get  { return (DateTime)event_dateVar.Value; }
            set  { event_dateVar.Value = value; }
        }

        public String task_uid
        {
            get  { return (String)task_uidVar.Value; }
            set  { task_uidVar.Value = value; }
        }

        public String from_user
        {
            get  { return (String)from_userVar.Value; }
            set  { from_userVar.Value = value; }
        }

        public String to_user
        {
            get  { return (String)to_userVar.Value; }
            set  { to_userVar.Value = value; }
        }

    }
    public partial class task_event
    {
        public static task_event New(Context x)
        {  return (task_event)x.Item("task_event"); }

        public static task_event GetById(Context x, String uid)
        { return (task_event)x.GetById("task_event", uid); }

        public static task_event QtO(Context x, String sql)
        { return (task_event)x.QtO("task_event", sql); }
    }
}
