using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("ordhit")]
    public partial class ordhit_auto : NewMethod.nObject
    {
        static ordhit_auto()
        {
            Item.AttributesCache(typeof(ordhit_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_ordhed_uid":
                    the_ordhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordhit_name":
                    ordhit_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordhit_order":
                    ordhit_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notes":
                    notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hit_amount":
                    hit_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "deduct_profit":
                    deduct_profitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "original_amount":
                    original_amountAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extra_description":
                    extra_descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hit_date":
                    hit_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cost":
                    costAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_credit":
                    is_creditAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_ordhed_uidAttribute;
        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute ordhit_nameAttribute;
        static CoreVarValAttribute ordhit_orderAttribute;
        static CoreVarValAttribute notesAttribute;
        static CoreVarValAttribute hit_amountAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute deduct_profitAttribute;
        static CoreVarValAttribute original_amountAttribute;
        static CoreVarValAttribute extra_descriptionAttribute;
        static CoreVarValAttribute hit_dateAttribute;
        static CoreVarValAttribute costAttribute;
        static CoreVarValAttribute is_creditAttribute;

        

        [CoreVarVal("the_ordhed_uid", "String", TheFieldLength = 255, Caption="The Ordhed Uid", Importance = 1)]
        public VarString the_ordhed_uidVar;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 2)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("ordhit_name", "String", TheFieldLength = 255, Caption="Ordhit Name", Importance = 3)]
        public VarString ordhit_nameVar;

        [CoreVarVal("ordhit_order", "String", Caption="Ordhit Order", Importance = 4)]
        public VarString ordhit_orderVar;

        [CoreVarVal("notes", "String", TheFieldLength = 255, Caption="Notes", Importance = 5)]
        public VarString notesVar;

        [CoreVarVal("hit_amount", "Double", Caption="Hit Amount", Importance = 6)]
        public VarDouble hit_amountVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 7)]
        public VarString descriptionVar;

        [CoreVarVal("deduct_profit", "Boolean", Caption="Deduct Profit", Importance = 8)]
        public VarBoolean deduct_profitVar;

        [CoreVarVal("original_amount", "Double", Caption="Original Amount", Importance = 9)]
        public VarDouble original_amountVar;

        [CoreVarVal("extra_description", "String", TheFieldLength = 255, Caption="Extra Description", Importance = 10)]
        public VarString extra_descriptionVar;

        [CoreVarVal("hit_date", "DateTime", Caption="Hit Date", Importance = 11)]
        public VarDateTime hit_dateVar;

        [CoreVarVal("cost", "Double", Caption="Cost", Importance = 12)]
        public VarDouble costVar;

        [CoreVarVal("is_credit", "Boolean", Caption = "is_credit", Importance = 13)]
        public VarBoolean is_creditVar;

        

        public ordhit_auto()
        {
            StaticInit();
            the_ordhed_uidVar = new VarString(this, the_ordhed_uidAttribute);
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            ordhit_nameVar = new VarString(this, ordhit_nameAttribute);
            ordhit_orderVar = new VarString(this, ordhit_orderAttribute);
            notesVar = new VarString(this, notesAttribute);
            hit_amountVar = new VarDouble(this, hit_amountAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            deduct_profitVar = new VarBoolean(this, deduct_profitAttribute);
            original_amountVar = new VarDouble(this, original_amountAttribute);
            extra_descriptionVar = new VarString(this, extra_descriptionAttribute);
            hit_dateVar = new VarDateTime(this, hit_dateAttribute);
            costVar = new VarDouble(this, costAttribute);
            is_creditVar = new VarBoolean(this, is_creditAttribute);
        }

        public override string ClassId
        { get { return "ordhit"; } }

        public String the_ordhed_uid
        {
            get  { return (String)the_ordhed_uidVar.Value; }
            set  { the_ordhed_uidVar.Value = value; }
        }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String ordhit_name
        {
            get  { return (String)ordhit_nameVar.Value; }
            set  { ordhit_nameVar.Value = value; }
        }

        public String ordhit_order
        {
            get  { return (String)ordhit_orderVar.Value; }
            set  { ordhit_orderVar.Value = value; }
        }

        public String notes
        {
            get  { return (String)notesVar.Value; }
            set  { notesVar.Value = value; }
        }

        public Double hit_amount
        {
            get  { return (Double)hit_amountVar.Value; }
            set  { hit_amountVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public Boolean deduct_profit
        {
            get  { return (Boolean)deduct_profitVar.Value; }
            set  { deduct_profitVar.Value = value; }
        }

        public Double original_amount
        {
            get  { return (Double)original_amountVar.Value; }
            set  { original_amountVar.Value = value; }
        }

        public String extra_description
        {
            get  { return (String)extra_descriptionVar.Value; }
            set  { extra_descriptionVar.Value = value; }
        }

        public DateTime hit_date
        {
            get  { return (DateTime)hit_dateVar.Value; }
            set  { hit_dateVar.Value = value; }
        }

        public Double cost
        {
            get  { return (Double)costVar.Value; }
            set  { costVar.Value = value; }
        }

        public Boolean is_credit
        {
            get { return (Boolean)is_creditVar.Value; }
            set { is_creditVar.Value = value; }
        }

    }
    public partial class ordhit
    {
        public static ordhit New(Context x)
        {  return (ordhit)x.Item("ordhit"); }

        public static ordhit GetById(Context x, String uid)
        { return (ordhit)x.GetById("ordhit", uid); }

        public static ordhit QtO(Context x, String sql)
        { return (ordhit)x.QtO("ordhit", sql); }
    }
}
