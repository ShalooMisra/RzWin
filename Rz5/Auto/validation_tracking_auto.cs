using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("validation_tracking")]
    public partial class validation_tracking_auto : NewMethod.nObject
    {
        static validation_tracking_auto()
        {
            Item.AttributesCache(typeof(validation_tracking_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "orderid_sales":
                    orderid_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber_sales":
                    ordernumber_salesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "new_stage":
                    new_stageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "previous_stage":
                    previous_stageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agent_uid":
                    agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_uid":
                    company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hold_reason":
                    hold_reasonAttribute = (CoreVarValAttribute)attr;
                    break;


            }
        }

        static CoreVarValAttribute orderid_salesAttribute;
        static CoreVarValAttribute ordernumber_salesAttribute;
        static CoreVarValAttribute new_stageAttribute;
        static CoreVarValAttribute previous_stageAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute agent_uidAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute company_uidAttribute;
        static CoreVarValAttribute hold_reasonAttribute;



        [CoreVarVal("orderid_sales", "String", TheFieldLength = 255, Caption = "Sales Order ID", Importance = 1)]
        public VarString orderid_salesVar;

        [CoreVarVal("ordernumber_sales", "String", TheFieldLength = 255, Caption = "Ordernumber Sales", Importance = 2)]
        public VarString ordernumber_salesVar;

        [CoreVarVal("new_stage", "String", TheFieldLength = 255, Caption = "New Stage", Importance = 3)]
        public VarString new_stageVar;

        [CoreVarVal("previous_stage", "String", TheFieldLength = 255, Caption = "Previous Stage", Importance = 4)]
        public VarString previous_stageVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 255, Caption = "Agent Name", Importance = 5)]
        public VarString agentnameVar;

        [CoreVarVal("agent_uid", "String", TheFieldLength = 255, Caption = "Agent Uid", Importance = 6)]
        public VarString agent_uidVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 7)]
        public VarString companynameVar;

        [CoreVarVal("company_uid", "String", TheFieldLength = 255, Caption = "Company Uid", Importance = 8)]
        public VarString company_uidVar;

        [CoreVarVal("hold_reason", "String", TheFieldLength = 4096, Caption = "Hold Reason", Importance = 9)]
        public VarString hold_reasonVar;






        public validation_tracking_auto()
        {
            StaticInit();
            orderid_salesVar = new VarString(this, orderid_salesAttribute);
            ordernumber_salesVar = new VarString(this, ordernumber_salesAttribute);
            new_stageVar = new VarString(this, new_stageAttribute);
            previous_stageVar = new VarString(this, previous_stageAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            agent_uidVar = new VarString(this, agent_uidAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            company_uidVar = new VarString(this, company_uidAttribute);
            hold_reasonVar = new VarString(this, hold_reasonAttribute);

        }

        public override string ClassId
        { get { return "validation_tracking"; } }

        public String orderid_sales
        {
            get { return (String)orderid_salesVar.Value; }
            set { orderid_salesVar.Value = value; }
        }

        public String ordernumber_sales
        {
            get { return (String)ordernumber_salesVar.Value; }
            set { ordernumber_salesVar.Value = value; }
        }

        public String new_stage
        {
            get { return (String)new_stageVar.Value; }
            set { new_stageVar.Value = value; }
        }

        public String previous_stage
        {
            get { return (String)previous_stageVar.Value; }
            set { previous_stageVar.Value = value; }
        }

        public String agentname
        {
            get { return (String)agentnameVar.Value; }
            set { agentnameVar.Value = value; }
        }

        public String agent_uid
        {
            get { return (String)agent_uidVar.Value; }
            set { agent_uidVar.Value = value; }
        }


        public String companyname
        {
            get { return (String)companynameVar.Value; }
            set { companynameVar.Value = value; }
        }


        public String company_uid
        {
            get { return (String)company_uidVar.Value; }
            set { company_uidVar.Value = value; }
        }

        public String hold_reason
        {
            get { return (String)hold_reasonVar.Value; }
            set { hold_reasonVar.Value = value; }
        }



    }
    public partial class validation_tracking
    {
        public static validation_tracking New(Context x)
        { return (validation_tracking)x.Item("validation_tracking"); }

        public static validation_tracking GetById(Context x, String uid)
        { return (validation_tracking)x.GetById("validation_tracking", uid); }

        public static validation_tracking QtO(Context x, String sql)
        { return (validation_tracking)x.QtO("validation_tracking", sql); }

        public static bool CheckIsHoldStage(ContextRz x, string stage)
        {

            //nList for validation_stage = "01a320ef251440638f2e24e237b2218a"
            List<string> holdStages = x.SelectScalarList("select DISTINCT name from n_choice where the_n_choices_uid = '01a320ef251440638f2e24e237b2218a' and LEN(isnull(name,'')) > 0 and name like '%Hold'");
            bool isHold = false;// If it's one of the hold conditions.
            if (holdStages.Contains(stage))
                isHold = true;
            return isHold;

        }

        public static List<string> GetAllValidationStages(ContextRz x)
        {
            List<string> ret = x.SelectScalarList("select DISTINCT name from n_choice where the_n_choices_uid = '01a320ef251440638f2e24e237b2218a' and LEN(isnull(name,'')) > 0");
            return ret;

        }
    }
}
