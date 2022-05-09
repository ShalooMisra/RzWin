using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("split_commission")]
    public partial class split_commission_auto : NewMethod.nObject
    {
        static split_commission_auto()
        {
            Item.AttributesCache(typeof(split_commission_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "the_orddet_line_uid":
                    the_orddet_line_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_orddet_quote_uid":
                    the_orddet_quote_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "dealheader_uid":
                    dealheader_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_percent":
                    split_commission_percentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent":
                    split_commission_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_agent_id":
                    split_commission_agent_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "split_commission_type":
                    split_commission_typeAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }

        static CoreVarValAttribute the_orddet_line_uidAttribute;
        static CoreVarValAttribute the_orddet_quote_uidAttribute;
        static CoreVarValAttribute dealheader_uidAttribute;        
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute split_commission_percentAttribute;
        static CoreVarValAttribute split_commission_agentAttribute;
        static CoreVarValAttribute split_commission_agent_idAttribute;
        static CoreVarValAttribute split_commission_typeAttribute;
        

        [CoreVarVal("the_orddet_line_uid", "String", TheFieldLength = 50, Caption="Orddet Line Uid", Importance = 1)]
        public VarString the_orddet_line_uidVar;

        [CoreVarVal("the_orddet_quote_uid", "String", TheFieldLength = 50, Caption = "Orddet Quote Uid", Importance = 1)]
        public VarString the_orddet_quote_uidVar;

        [CoreVarVal("dealheader_uid", "String", TheFieldLength = 50, Caption = "Dealheader / Batch Uid", Importance = 1)]
        public VarString dealheader_uidVar;        

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("split_commission_percent", "Double", TheFieldLength = 50, Caption = "split_commission_percent", Importance = 3)]
        public VarDouble split_commission_percentVar;

        [CoreVarVal("split_commission_agent", "String", TheFieldLength = 50, Caption = "Split Commissin Agent Name", Importance = 2)]
        public VarString split_commission_agentVar;

        [CoreVarVal("split_commission_agent_id", "String", TheFieldLength = 50, Caption = "Split Commissin Agent ID", Importance = 2)]
        public VarString split_commission_agent_idVar;

        [CoreVarVal("split_commission_type", "String", TheFieldLength = 50, Caption = "Split Commissin Type", Importance = 2)]
        public VarString split_commission_typeVar;
        

        public split_commission_auto()
        {
            StaticInit();
            the_orddet_line_uidVar = new VarString(this, the_orddet_line_uidAttribute);
            the_orddet_quote_uidVar = new VarString(this, the_orddet_quote_uidAttribute);
            dealheader_uidVar = new VarString(this, dealheader_uidAttribute);            
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            split_commission_percentVar = new VarDouble(this, split_commission_percentAttribute);
            split_commission_agentVar = new VarString(this, split_commission_agentAttribute);
            split_commission_agent_idVar = new VarString(this, split_commission_agent_idAttribute);
            split_commission_typeVar = new VarString(this, split_commission_typeAttribute);
            
        }

        public override string ClassId
        { get { return "split_commission"; } }

        public String the_orddet_line_uid
        {
            get  { return (String)the_orddet_line_uidVar.Value; }
            set  { the_orddet_line_uidVar.Value = value; }
        }

        public String the_orddet_quote_uid
        {
            get { return (String)the_orddet_quote_uidVar.Value; }
            set { the_orddet_quote_uidVar.Value = value; }
        }

        public String dealheader_uid
        {
            get { return (String)dealheader_uidVar.Value; }
            set { dealheader_uidVar.Value = value; }
        }
        

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public double split_commission_percent
        {
            get { return (double)split_commission_percentVar.Value; }
            set { split_commission_percentVar.Value = value; }
        }

        public String split_commission_agent
        {
            get { return (String)split_commission_agentVar.Value; }
            set { split_commission_agentVar.Value = value; }
        }

        public String split_commission_agent_id
        {
            get { return (String)split_commission_agent_idVar.Value; }
            set { split_commission_agent_idVar.Value = value; }
        }

        public String split_commission_type
        {
            get { return (String)split_commission_typeVar.Value; }
            set { split_commission_typeVar.Value = value; }
        }

        
    }
    public partial class split_commission
    {
        public static split_commission New(Context x)
        {  return (split_commission)x.Item("split_commission"); }

        public static split_commission GetById(Context x, String uid)
        { return (split_commission)x.GetById("split_commission", uid); }

        public static split_commission QtO(Context x, String sql)
        { return (split_commission)x.QtO("split_commission", sql); }
    }
}
