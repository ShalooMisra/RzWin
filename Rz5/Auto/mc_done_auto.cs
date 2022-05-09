using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("mc_done")]
    public partial class mc_done_auto : NewMethod.nObject
    {
        static mc_done_auto()
        {
            Item.AttributesCache(typeof(mc_done_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_mc_duty_uid":
                    base_mc_duty_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "start_date":
                    start_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "end_date":
                    end_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "done_status":
                    done_statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_success":
                    is_successAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_mc_duty_uidAttribute;
        static CoreVarValAttribute start_dateAttribute;
        static CoreVarValAttribute end_dateAttribute;
        static CoreVarValAttribute done_statusAttribute;
        static CoreVarValAttribute is_successAttribute;

        [CoreVarVal("base_mc_duty_uid", "String", TheFieldLength = 50, Caption="Base Mc Duty Id", Importance = 1)]
        public VarString base_mc_duty_uidVar;

        [CoreVarVal("start_date", "DateTime", Caption="Start Date", Importance = 2)]
        public VarDateTime start_dateVar;

        [CoreVarVal("end_date", "DateTime", Caption="End Date", Importance = 3)]
        public VarDateTime end_dateVar;

        [CoreVarVal("done_status", "Text", Caption="Done Status", Importance = 4)]
        public VarText done_statusVar;

        [CoreVarVal("is_success", "Boolean", Caption="Is Success", Importance = 5)]
        public VarBoolean is_successVar;

        public mc_done_auto()
        {
            StaticInit();
            base_mc_duty_uidVar = new VarString(this, base_mc_duty_uidAttribute);
            start_dateVar = new VarDateTime(this, start_dateAttribute);
            end_dateVar = new VarDateTime(this, end_dateAttribute);
            done_statusVar = new VarText(this, done_statusAttribute);
            is_successVar = new VarBoolean(this, is_successAttribute);
        }

        public override string ClassId
        { get { return "mc_done"; } }

        public String base_mc_duty_uid
        {
            get  { return (String)base_mc_duty_uidVar.Value; }
            set  { base_mc_duty_uidVar.Value = value; }
        }

        public DateTime start_date
        {
            get  { return (DateTime)start_dateVar.Value; }
            set  { start_dateVar.Value = value; }
        }

        public DateTime end_date
        {
            get  { return (DateTime)end_dateVar.Value; }
            set  { end_dateVar.Value = value; }
        }

        public String done_status
        {
            get  { return (String)done_statusVar.Value; }
            set  { done_statusVar.Value = value; }
        }

        public Boolean is_success
        {
            get  { return (Boolean)is_successVar.Value; }
            set  { is_successVar.Value = value; }
        }

    }
    public partial class mc_done
    {
        public static mc_done New(Context x)
        {  return (mc_done)x.Item("mc_done"); }

        public static mc_done GetById(Context x, String uid)
        { return (mc_done)x.GetById("mc_done", uid); }

        public static mc_done QtO(Context x, String sql)
        { return (mc_done)x.QtO("mc_done", sql); }
    }
}
