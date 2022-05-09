using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("budget_account", Caption="Budget Account", Importance = 86)]
    public partial class budget_account_auto : NewMethod.nObject
    {
        static budget_account_auto()
        {
            Item.AttributesCache(typeof(budget_account_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "account_uid":
                    account_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_name":
                    account_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_fullname":
                    account_fullnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "account_number":
                    account_numberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "budget_uid":
                    budget_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "annual_total":
                    annual_totalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "jan":
                    janAttribute = (CoreVarValAttribute)attr;
                    break;
                case "feb":
                    febAttribute = (CoreVarValAttribute)attr;
                    break;
                case "march":
                    marchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "april":
                    aprilAttribute = (CoreVarValAttribute)attr;
                    break;
                case "may":
                    mayAttribute = (CoreVarValAttribute)attr;
                    break;
                case "june":
                    juneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "july":
                    julyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "august":
                    augustAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sept":
                    septAttribute = (CoreVarValAttribute)attr;
                    break;
                case "oct":
                    octAttribute = (CoreVarValAttribute)attr;
                    break;
                case "nov":
                    novAttribute = (CoreVarValAttribute)attr;
                    break;
                case "december":
                    decemberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "budget_year":
                    budget_yearAttribute = (CoreVarValAttribute)attr;
                    break;
                case "budget_name":
                    budget_nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute account_uidAttribute;
        static CoreVarValAttribute account_nameAttribute;
        static CoreVarValAttribute account_fullnameAttribute;
        static CoreVarValAttribute account_numberAttribute;
        static CoreVarValAttribute budget_uidAttribute;
        static CoreVarValAttribute annual_totalAttribute;
        static CoreVarValAttribute janAttribute;
        static CoreVarValAttribute febAttribute;
        static CoreVarValAttribute marchAttribute;
        static CoreVarValAttribute aprilAttribute;
        static CoreVarValAttribute mayAttribute;
        static CoreVarValAttribute juneAttribute;
        static CoreVarValAttribute julyAttribute;
        static CoreVarValAttribute augustAttribute;
        static CoreVarValAttribute septAttribute;
        static CoreVarValAttribute octAttribute;
        static CoreVarValAttribute novAttribute;
        static CoreVarValAttribute decemberAttribute;
        static CoreVarValAttribute budget_yearAttribute;
        static CoreVarValAttribute budget_nameAttribute;

        [CoreVarVal("account_uid", "String", Caption="Account Uid", Importance = 0)]
        public VarString account_uidVar;

        [CoreVarVal("account_name", "String", Caption="Account Name", Importance = 1)]
        public VarString account_nameVar;

        [CoreVarVal("account_fullname", "String", Caption="Account Fullname", Importance = 2)]
        public VarString account_fullnameVar;

        [CoreVarVal("account_number", "Int32", Caption="Account Number", Importance = 3)]
        public VarInt32 account_numberVar;

        [CoreVarVal("budget_uid", "String", Caption="Budget Uid", Importance = 4)]
        public VarString budget_uidVar;

        [CoreVarVal("annual_total", "Double", Caption="Annual Total", Importance = 5)]
        public VarDouble annual_totalVar;

        [CoreVarVal("jan", "Double", Caption="Jan", Importance = 6)]
        public VarDouble janVar;

        [CoreVarVal("feb", "Double", Caption="Feb", Importance = 7)]
        public VarDouble febVar;

        [CoreVarVal("march", "Double", Caption="March", Importance = 8)]
        public VarDouble marchVar;

        [CoreVarVal("april", "Double", Caption="April", Importance = 9)]
        public VarDouble aprilVar;

        [CoreVarVal("may", "Double", Caption="May", Importance = 10)]
        public VarDouble mayVar;

        [CoreVarVal("june", "Double", Caption="June", Importance = 11)]
        public VarDouble juneVar;

        [CoreVarVal("july", "Double", Caption="July", Importance = 12)]
        public VarDouble julyVar;

        [CoreVarVal("august", "Double", Caption="August", Importance = 13)]
        public VarDouble augustVar;

        [CoreVarVal("sept", "Double", Caption="Sept", Importance = 14)]
        public VarDouble septVar;

        [CoreVarVal("oct", "Double", Caption="Oct", Importance = 15)]
        public VarDouble octVar;

        [CoreVarVal("nov", "Double", Caption="Nov", Importance = 16)]
        public VarDouble novVar;

        [CoreVarVal("december", "Double", Caption="December", Importance = 19)]
        public VarDouble decemberVar;

        [CoreVarVal("budget_year", "Int32", Caption="Budget Year", Importance = 18)]
        public VarInt32 budget_yearVar;

        [CoreVarVal("budget_name", "String", Caption="Budget Name", Importance = 19)]
        public VarString budget_nameVar;

        public budget_account_auto()
        {
            StaticInit();
            account_uidVar = new VarString(this, account_uidAttribute);
            account_nameVar = new VarString(this, account_nameAttribute);
            account_fullnameVar = new VarString(this, account_fullnameAttribute);
            account_numberVar = new VarInt32(this, account_numberAttribute);
            budget_uidVar = new VarString(this, budget_uidAttribute);
            annual_totalVar = new VarDouble(this, annual_totalAttribute);
            janVar = new VarDouble(this, janAttribute);
            febVar = new VarDouble(this, febAttribute);
            marchVar = new VarDouble(this, marchAttribute);
            aprilVar = new VarDouble(this, aprilAttribute);
            mayVar = new VarDouble(this, mayAttribute);
            juneVar = new VarDouble(this, juneAttribute);
            julyVar = new VarDouble(this, julyAttribute);
            augustVar = new VarDouble(this, augustAttribute);
            septVar = new VarDouble(this, septAttribute);
            octVar = new VarDouble(this, octAttribute);
            novVar = new VarDouble(this, novAttribute);
            decemberVar = new VarDouble(this, decemberAttribute);
            budget_yearVar = new VarInt32(this, budget_yearAttribute);
            budget_nameVar = new VarString(this, budget_nameAttribute);
        }

        public override string ClassId
        { get { return "budget_account"; } }

        public String account_uid
        {
            get  { return (String)account_uidVar.Value; }
            set  { account_uidVar.Value = value; }
        }

        public String account_name
        {
            get  { return (String)account_nameVar.Value; }
            set  { account_nameVar.Value = value; }
        }

        public String account_fullname
        {
            get  { return (String)account_fullnameVar.Value; }
            set  { account_fullnameVar.Value = value; }
        }

        public Int32 account_number
        {
            get  { return (Int32)account_numberVar.Value; }
            set  { account_numberVar.Value = value; }
        }

        public String budget_uid
        {
            get  { return (String)budget_uidVar.Value; }
            set  { budget_uidVar.Value = value; }
        }

        public Double annual_total
        {
            get  { return (Double)annual_totalVar.Value; }
            set  { annual_totalVar.Value = value; }
        }

        public Double jan
        {
            get  { return (Double)janVar.Value; }
            set  { janVar.Value = value; }
        }

        public Double feb
        {
            get  { return (Double)febVar.Value; }
            set  { febVar.Value = value; }
        }

        public Double march
        {
            get  { return (Double)marchVar.Value; }
            set  { marchVar.Value = value; }
        }

        public Double april
        {
            get  { return (Double)aprilVar.Value; }
            set  { aprilVar.Value = value; }
        }

        public Double may
        {
            get  { return (Double)mayVar.Value; }
            set  { mayVar.Value = value; }
        }

        public Double june
        {
            get  { return (Double)juneVar.Value; }
            set  { juneVar.Value = value; }
        }

        public Double july
        {
            get  { return (Double)julyVar.Value; }
            set  { julyVar.Value = value; }
        }

        public Double august
        {
            get  { return (Double)augustVar.Value; }
            set  { augustVar.Value = value; }
        }

        public Double sept
        {
            get  { return (Double)septVar.Value; }
            set  { septVar.Value = value; }
        }

        public Double oct
        {
            get  { return (Double)octVar.Value; }
            set  { octVar.Value = value; }
        }

        public Double nov
        {
            get  { return (Double)novVar.Value; }
            set  { novVar.Value = value; }
        }

        public Double december
        {
            get  { return (Double)decemberVar.Value; }
            set  { decemberVar.Value = value; }
        }

        public Int32 budget_year
        {
            get  { return (Int32)budget_yearVar.Value; }
            set  { budget_yearVar.Value = value; }
        }

        public String budget_name
        {
            get  { return (String)budget_nameVar.Value; }
            set  { budget_nameVar.Value = value; }
        }

    }
    public partial class budget_account
    {
        public static budget_account New(Context x)
        {  return (budget_account)x.Item("budget_account"); }

        public static budget_account GetById(Context x, String uid)
        { return (budget_account)x.GetById("budget_account", uid); }

        public static budget_account QtO(Context x, String sql)
        { return (budget_account)x.QtO("budget_account", sql); }
    }
}
