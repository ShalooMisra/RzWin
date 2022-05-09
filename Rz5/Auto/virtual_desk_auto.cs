using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("virtual_desk")]
    public partial class virtual_desk_auto : NewMethod.nObject
    {
        static virtual_desk_auto()
        {
            Item.AttributesCache(typeof(virtual_desk_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_virtual_floor_uid":
                    the_virtual_floor_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_team_uid":
                    the_n_team_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "desk_type":
                    desk_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "x_location":
                    x_locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "y_location":
                    y_locationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "job_desc":
                    job_descAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orientation":
                    orientationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "banner_pic":
                    banner_picAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_virtual_floor_uidAttribute;
        static CoreVarValAttribute the_n_team_uidAttribute;
        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute desk_typeAttribute;
        static CoreVarValAttribute x_locationAttribute;
        static CoreVarValAttribute y_locationAttribute;
        static CoreVarValAttribute job_descAttribute;
        static CoreVarValAttribute orientationAttribute;
        static CoreVarValAttribute banner_picAttribute;

        [CoreVarVal("the_virtual_floor_uid", "String", TheFieldLength = 255, Caption="The Virtual Floor Uid", Importance = 1)]
        public VarString the_virtual_floor_uidVar;

        [CoreVarVal("the_n_team_uid", "String", TheFieldLength = 255, Caption="The N Team Uid", Importance = 2)]
        public VarString the_n_team_uidVar;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 3)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 4)]
        public VarString nameVar;

        [CoreVarVal("desk_type", "String", TheFieldLength = 255, Caption="Desk Type", Importance = 5)]
        public VarString desk_typeVar;

        [CoreVarVal("x_location", "Int32", Caption="X Location", Importance = 6)]
        public VarInt32 x_locationVar;

        [CoreVarVal("y_location", "Int32", Caption="Y Location", Importance = 7)]
        public VarInt32 y_locationVar;

        [CoreVarVal("job_desc", "String", TheFieldLength = 255, Caption="Job Desc", Importance = 8)]
        public VarString job_descVar;

        [CoreVarVal("orientation", "Int32", Caption="Orientation", Importance = 9)]
        public VarInt32 orientationVar;

        [CoreVarVal("banner_pic", "String", TheFieldLength = 255, Caption="Banner Pic", Importance = 10)]
        public VarString banner_picVar;

        public virtual_desk_auto()
        {
            StaticInit();
            the_virtual_floor_uidVar = new VarString(this, the_virtual_floor_uidAttribute);
            the_n_team_uidVar = new VarString(this, the_n_team_uidAttribute);
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            desk_typeVar = new VarString(this, desk_typeAttribute);
            x_locationVar = new VarInt32(this, x_locationAttribute);
            y_locationVar = new VarInt32(this, y_locationAttribute);
            job_descVar = new VarString(this, job_descAttribute);
            orientationVar = new VarInt32(this, orientationAttribute);
            banner_picVar = new VarString(this, banner_picAttribute);
        }

        public override string ClassId
        { get { return "virtual_desk"; } }

        public String the_virtual_floor_uid
        {
            get  { return (String)the_virtual_floor_uidVar.Value; }
            set  { the_virtual_floor_uidVar.Value = value; }
        }

        public String the_n_team_uid
        {
            get  { return (String)the_n_team_uidVar.Value; }
            set  { the_n_team_uidVar.Value = value; }
        }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String desk_type
        {
            get  { return (String)desk_typeVar.Value; }
            set  { desk_typeVar.Value = value; }
        }

        public Int32 x_location
        {
            get  { return (Int32)x_locationVar.Value; }
            set  { x_locationVar.Value = value; }
        }

        public Int32 y_location
        {
            get  { return (Int32)y_locationVar.Value; }
            set  { y_locationVar.Value = value; }
        }

        public String job_desc
        {
            get  { return (String)job_descVar.Value; }
            set  { job_descVar.Value = value; }
        }

        public Int32 orientation
        {
            get  { return (Int32)orientationVar.Value; }
            set  { orientationVar.Value = value; }
        }

        public String banner_pic
        {
            get  { return (String)banner_picVar.Value; }
            set  { banner_picVar.Value = value; }
        }

    }
    public partial class virtual_desk
    {
        public static virtual_desk New(Context x)
        {  return (virtual_desk)x.Item("virtual_desk"); }

        public static virtual_desk GetById(Context x, String uid)
        { return (virtual_desk)x.GetById("virtual_desk", uid); }

        public static virtual_desk QtO(Context x, String sql)
        { return (virtual_desk)x.QtO("virtual_desk", sql); }

        public static virtual_desk GetByName(Context x, String name, String extraSql = "")
        { return (virtual_desk)x.GetByName("virtual_desk", name, extraSql); }
    }
}
