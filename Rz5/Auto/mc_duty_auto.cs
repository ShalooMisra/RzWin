using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("mc_duty")]
    public partial class mc_duty_auto : NewMethod.nObject
    {
        static mc_duty_auto()
        {
            Item.AttributesCache(typeof(mc_duty_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "last_mc_done_uid":
                    last_mc_done_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duty_name":
                    duty_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duty_order":
                    duty_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duty_interval":
                    duty_intervalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duty_type":
                    duty_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "off_hours":
                    off_hoursAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duty_targets":
                    duty_targetsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_disabled":
                    is_disabledAttribute = (CoreVarValAttribute)attr;
                    break;
                case "file_name":
                    file_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "function_name":
                    function_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duty_parameters":
                    duty_parametersAttribute = (CoreVarValAttribute)attr;
                    break;
                case "last_run":
                    last_runAttribute = (CoreVarValAttribute)attr;
                    break;
                case "done_status":
                    done_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ideal_hour":
                    ideal_hourAttribute = (CoreVarValAttribute)attr;
                    break;
                case "script_code":
                    script_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ideal_minute":
                    ideal_minuteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ideal_weekday":
                    ideal_weekdayAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute last_mc_done_uidAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute duty_nameAttribute;
        static CoreVarValAttribute duty_orderAttribute;
        static CoreVarValAttribute duty_intervalAttribute;
        static CoreVarValAttribute duty_typeAttribute;
        static CoreVarValAttribute off_hoursAttribute;
        static CoreVarValAttribute duty_targetsAttribute;
        static CoreVarValAttribute is_disabledAttribute;
        static CoreVarValAttribute file_nameAttribute;
        static CoreVarValAttribute function_nameAttribute;
        static CoreVarValAttribute duty_parametersAttribute;
        static CoreVarValAttribute last_runAttribute;
        static CoreVarValAttribute done_statusAttribute;
        static CoreVarValAttribute ideal_hourAttribute;
        static CoreVarValAttribute script_codeAttribute;
        static CoreVarValAttribute ideal_minuteAttribute;
        static CoreVarValAttribute ideal_weekdayAttribute;

        [CoreVarVal("last_mc_done_uid", "String", TheFieldLength = 50, Caption="Last Mc Done Id", Importance = 1)]
        public VarString last_mc_done_uidVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="Base Mc User Id", Importance = 2)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("duty_name", "String", TheFieldLength = 255, Caption="Duty Name", Importance = 3)]
        public VarString duty_nameVar;

        [CoreVarVal("duty_order", "Int64", Caption="Duty Order", Importance = 4)]
        public VarInt64 duty_orderVar;

        [CoreVarVal("duty_interval", "Int64", Caption="Interval (minutes)", Importance = 5)]
        public VarInt64 duty_intervalVar;

        [CoreVarVal("duty_type", "Int32", Caption="Duty Type", Importance = 6)]
        public VarInt32 duty_typeVar;

        [CoreVarVal("off_hours", "Boolean", Caption="Off Hours Only", Importance = 7)]
        public VarBoolean off_hoursVar;

        [CoreVarVal("duty_targets", "String", TheFieldLength = 255, Caption="Duty Targets", Importance = 8)]
        public VarString duty_targetsVar;

        [CoreVarVal("is_disabled", "Boolean", Caption="Is Disabled", Importance = 9)]
        public VarBoolean is_disabledVar;

        [CoreVarVal("file_name", "String", TheFieldLength = 4096, Caption="File Name", Importance = 10)]
        public VarString file_nameVar;

        [CoreVarVal("function_name", "String", TheFieldLength = 255, Caption="Function Name", Importance = 11)]
        public VarString function_nameVar;

        [CoreVarVal("duty_parameters", "String", TheFieldLength = 4096, Caption="Parameters", Importance = 12)]
        public VarString duty_parametersVar;

        [CoreVarVal("last_run", "DateTime", Caption="Last Run", Importance = 13)]
        public VarDateTime last_runVar;

        [CoreVarVal("done_status", "Text", Caption="Done Status", Importance = 14)]
        public VarText done_statusVar;

        [CoreVarVal("ideal_hour", "Int32", Caption="Ideal Hour", Importance = 15)]
        public VarInt32 ideal_hourVar;

        [CoreVarVal("script_code", "Text", Caption="Script Code", Importance = 16)]
        public VarText script_codeVar;

        [CoreVarVal("ideal_minute", "Int32", Caption="Ideal Minute", Importance = 17)]
        public VarInt32 ideal_minuteVar;

        [CoreVarVal("ideal_weekday", "String", TheFieldLength = 255, Caption="Ideal Weekday", Importance = 18)]
        public VarString ideal_weekdayVar;

        public mc_duty_auto()
        {
            StaticInit();
            last_mc_done_uidVar = new VarString(this, last_mc_done_uidAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            duty_nameVar = new VarString(this, duty_nameAttribute);
            duty_orderVar = new VarInt64(this, duty_orderAttribute);
            duty_intervalVar = new VarInt64(this, duty_intervalAttribute);
            duty_typeVar = new VarInt32(this, duty_typeAttribute);
            off_hoursVar = new VarBoolean(this, off_hoursAttribute);
            duty_targetsVar = new VarString(this, duty_targetsAttribute);
            is_disabledVar = new VarBoolean(this, is_disabledAttribute);
            file_nameVar = new VarString(this, file_nameAttribute);
            function_nameVar = new VarString(this, function_nameAttribute);
            duty_parametersVar = new VarString(this, duty_parametersAttribute);
            last_runVar = new VarDateTime(this, last_runAttribute);
            done_statusVar = new VarText(this, done_statusAttribute);
            ideal_hourVar = new VarInt32(this, ideal_hourAttribute);
            script_codeVar = new VarText(this, script_codeAttribute);
            ideal_minuteVar = new VarInt32(this, ideal_minuteAttribute);
            ideal_weekdayVar = new VarString(this, ideal_weekdayAttribute);
        }

        public override string ClassId
        { get { return "mc_duty"; } }

        public String last_mc_done_uid
        {
            get  { return (String)last_mc_done_uidVar.Value; }
            set  { last_mc_done_uidVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String duty_name
        {
            get  { return (String)duty_nameVar.Value; }
            set  { duty_nameVar.Value = value; }
        }

        public Int64 duty_order
        {
            get  { return (Int64)duty_orderVar.Value; }
            set  { duty_orderVar.Value = value; }
        }

        public Int64 duty_interval
        {
            get  { return (Int64)duty_intervalVar.Value; }
            set  { duty_intervalVar.Value = value; }
        }

        public Int32 duty_type
        {
            get  { return (Int32)duty_typeVar.Value; }
            set  { duty_typeVar.Value = value; }
        }

        public Boolean off_hours
        {
            get  { return (Boolean)off_hoursVar.Value; }
            set  { off_hoursVar.Value = value; }
        }

        public String duty_targets
        {
            get  { return (String)duty_targetsVar.Value; }
            set  { duty_targetsVar.Value = value; }
        }

        public Boolean is_disabled
        {
            get  { return (Boolean)is_disabledVar.Value; }
            set  { is_disabledVar.Value = value; }
        }

        public String file_name
        {
            get  { return (String)file_nameVar.Value; }
            set  { file_nameVar.Value = value; }
        }

        public String function_name
        {
            get  { return (String)function_nameVar.Value; }
            set  { function_nameVar.Value = value; }
        }

        public String duty_parameters
        {
            get  { return (String)duty_parametersVar.Value; }
            set  { duty_parametersVar.Value = value; }
        }

        public DateTime last_run
        {
            get  { return (DateTime)last_runVar.Value; }
            set  { last_runVar.Value = value; }
        }

        public String done_status
        {
            get  { return (String)done_statusVar.Value; }
            set  { done_statusVar.Value = value; }
        }

        public Int32 ideal_hour
        {
            get  { return (Int32)ideal_hourVar.Value; }
            set  { ideal_hourVar.Value = value; }
        }

        public String script_code
        {
            get  { return (String)script_codeVar.Value; }
            set  { script_codeVar.Value = value; }
        }

        public Int32 ideal_minute
        {
            get  { return (Int32)ideal_minuteVar.Value; }
            set  { ideal_minuteVar.Value = value; }
        }

        public String ideal_weekday
        {
            get  { return (String)ideal_weekdayVar.Value; }
            set  { ideal_weekdayVar.Value = value; }
        }

    }
    public partial class mc_duty
    {
        public static mc_duty New(Context x)
        {  return (mc_duty)x.Item("mc_duty"); }

        public static mc_duty GetById(Context x, String uid)
        { return (mc_duty)x.GetById("mc_duty", uid); }

        public static mc_duty QtO(Context x, String sql)
        { return (mc_duty)x.QtO("mc_duty", sql); }
    }
}
