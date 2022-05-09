using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ItemClassic : Item
    {
        static ItemClassic()
        {
            Item.AttributesCache(typeof(ItemClassic), AttributeCache);
        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "date_created":
                    date_createdAttribute = (CoreVarValAttribute)attr;
                    break;
                case "date_modified":
                    date_modifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "grid_color":
                    grid_colorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "icon_index":
                    icon_indexAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute date_createdAttribute;
        static CoreVarValAttribute date_modifiedAttribute;
        static CoreVarValAttribute grid_colorAttribute;
        static CoreVarValAttribute icon_indexAttribute;

        [CoreVarVal("date_created", "DateTime")]
        public VarDateTime date_createdVar;

        [CoreVarVal("date_modified", "DateTime")]
        public VarDateTime date_modifiedVar;

        [CoreVarVal("grid_color", "Int32")]
        public VarInt32 grid_colorVar;

        [CoreVarVal("icon_index", "Int32")]
        public VarInt32 icon_indexVar;

        static void StaticInit()
        {
        }

        public ItemClassic()  // : base()  //ItemArgs a
        {
            StaticInit();
            date_createdVar = new VarDateTime(this, date_createdAttribute);
            date_modifiedVar = new VarDateTime(this, date_modifiedAttribute);
            grid_colorVar = new VarInt32(this, grid_colorAttribute);
            icon_indexVar = new VarInt32(this, icon_indexAttribute);
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            date_createdVar.Value = DateTime.Now;
        }

        public override void Updating(Context x)
        {            
            base.Updating(x);
            date_modifiedVar.Value = DateTime.Now;
            grid_colorVar.Value = GridColorCalc(x);
        }

        protected virtual int GridColorCalc(Context x)
        {
            return grid_color;// 0;
        }

        public int grid_color
        {
            get
            {
                return grid_colorVar.ValueInt;
            }

            set
            {
                grid_colorVar.Value = value;
            }
        }

        public int icon_index
        {
            get
            {
                return icon_indexVar.ValueInt;
            }

            set
            {
                icon_indexVar.Value = value;
            }
        }

        public DateTime date_created
        {
            get
            {
                return date_createdVar.ValueDateTime;
            }

            set
            {
                date_createdVar.Value = value;
            }
        }

        public DateTime date_modified
        {
            get
            {
                return date_modifiedVar.ValueDateTime;
            }

            set
            {
                date_modifiedVar.Value = value;
            }
        }

        public virtual void ISet(String property, Object value)
        {
            ValSet(property, value);
        }

        public Object IGet(String property)
        {
            return ValGet(property);
        }
    }
}
