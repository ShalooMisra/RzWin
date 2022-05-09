using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("validation_form")]
    public partial class validation_form_auto : NewMethod.nObject
    {
        static validation_form_auto()
        {
            Item.AttributesCache(typeof(validation_form), AttributeCache);
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
                case "pv_agentname":
                    pv_agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pv_agent_uid":
                    pv_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "v_agentname":
                    v_agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "v_agent_uid":
                    v_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_uid":
                    company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pvDoesShipToMatch":
                    pvDoesShipToMatchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pvDoesShipToMatch_Notes":
                    pvDoesShipToMatch_NotesAttribute = (CoreVarValAttribute)attr;
                    break;                    
                case "pvDoesPnQtyPriceMfgMatch":
                    pvDoesPnQtyPriceMfgMatchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pvDoesPnQtyPriceMfgMatch_Notes":
                    pvDoesPnQtyPriceMfgMatch_NotesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pvDescriptionsAllLinesMatch":
                    pvDescriptionsAllLinesMatchAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pvDescriptionsAllLinesMatch_Notes":
                    pvDescriptionsAllLinesMatch_NotesAttribute = (CoreVarValAttribute)attr;
                    break;                    
                case "pvDockDateRealistic":
                    pvDockDateRealisticAttribute = (CoreVarValAttribute)attr;
                    break;
                case "pvDockDateRealistic_Notes":
                    pvDockDateRealistic_NotesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prevalidation_notes":
                    prevalidation_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_type":
                    validation_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prevalidation_complete":
                    prevalidation_completeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "validation_complete":
                    validation_completeAttribute = (CoreVarValAttribute)attr;
                    break;



            }
        }

        static CoreVarValAttribute orderid_salesAttribute;
        static CoreVarValAttribute ordernumber_salesAttribute;
        static CoreVarValAttribute pv_agentnameAttribute;
        static CoreVarValAttribute pv_agent_uidAttribute;
        static CoreVarValAttribute v_agentnameAttribute;
        static CoreVarValAttribute v_agent_uidAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute company_uidAttribute;
        static CoreVarValAttribute pvDoesShipToMatchAttribute;
        static CoreVarValAttribute pvDoesShipToMatch_NotesAttribute;        
        static CoreVarValAttribute pvDoesPnQtyPriceMfgMatchAttribute;
        static CoreVarValAttribute pvDoesPnQtyPriceMfgMatch_NotesAttribute;
        static CoreVarValAttribute pvDescriptionsAllLinesMatch_NotesAttribute;
        static CoreVarValAttribute pvDescriptionsAllLinesMatchAttribute;
        static CoreVarValAttribute pvDockDateRealisticAttribute;
        static CoreVarValAttribute pvDockDateRealistic_NotesAttribute;
        static CoreVarValAttribute prevalidation_notesAttribute;
        static CoreVarValAttribute validation_typeAttribute;
        static CoreVarValAttribute prevalidation_completeAttribute;
        static CoreVarValAttribute validation_completeAttribute;

        


        [CoreVarVal("orderid_sales", "String", TheFieldLength = 255, Caption = "Sales Order ID", Importance = 1)]
        public VarString orderid_salesVar;

        [CoreVarVal("ordernumber_sales", "String", TheFieldLength = 255, Caption = "Ordernumber Sales", Importance = 2)]
        public VarString ordernumber_salesVar;

        [CoreVarVal("pv_agentname", "String", TheFieldLength = 255, Caption = "Prevalidaion Agent Name", Importance = 5)]
        public VarString pv_agentnameVar;

        [CoreVarVal("pv_agent_uid", "String", TheFieldLength = 255, Caption = "Prevalidation Agent Uid", Importance = 6)]
        public VarString pv_agent_uidVar;

        [CoreVarVal("v_agentname", "String", TheFieldLength = 255, Caption = "Validaion Agent Name", Importance = 5)]
        public VarString v_agentnameVar;

        [CoreVarVal("v_agent_uid", "String", TheFieldLength = 255, Caption = "Validation Agent Uid", Importance = 6)]
        public VarString v_agent_uidVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption = "Company Name", Importance = 7)]
        public VarString companynameVar;

        [CoreVarVal("company_uid", "String", TheFieldLength = 255, Caption = "Company Uid", Importance = 8)]
        public VarString company_uidVar;

        [CoreVarVal("pvDoesShipToMatch", "Boolean", TheFieldLength = 255, Caption = "Pre-Validation: Does Ship-to Match?", Importance = 9)]
        public VarBoolean pvDoesShipToMatchVar;

        [CoreVarVal("pvDoesShipToMatch_Notes", "String", TheFieldLength = 4096, Caption = "Pre-Validation: Does Ship-to Match Notes", Importance = 7)]
        public VarString pvDoesShipToMatch_NotesVar;        


        [CoreVarVal("pvDoesPnQtyPriceMfgMatch", "Boolean", TheFieldLength = 255, Caption = "Pre-Validation: Do PN,QTY,Prioce, MFG Match?", Importance = 9)]
        public VarBoolean pvDoesPnQtyPriceMfgMatchVar;

        [CoreVarVal("pvDoesPnQtyPriceMfgMatch_Notes", "String", TheFieldLength = 4096, Caption = "Pre-Validation: Do PN,QTY,Prioce, MFG Match Notes", Importance = 7)]
        public VarString pvDoesPnQtyPriceMfgMatch_NotesVar;

        [CoreVarVal("pvDescriptionsAllLinesMatch", "Boolean", TheFieldLength = 255, Caption = "Pre-Validation: Does customer description match all lines?", Importance = 9)]
        public VarBoolean pvDescriptionsAllLinesMatchVar;

        [CoreVarVal("pvDescriptionsAllLinesMatch_Notes", "String", TheFieldLength = 4096, Caption = "Pre-Validation: Does customer description match Notes", Importance = 7)]
        public VarString pvDescriptionsAllLinesMatch_NotesVar;

        [CoreVarVal("pvDockDateRealistic", "Boolean", TheFieldLength = 255, Caption = "Pre-Validation: Is the customer's dock date realistic?", Importance = 9)]
        public VarBoolean pvDockDateRealisticVar;

        [CoreVarVal("pvDockDateRealistic_Notes", "String", TheFieldLength = 4096, Caption = "Pre-Validation:  Is the customer's dock date realistic Notes", Importance = 7)]
        public VarString pvDockDateRealistic_NotesVar;

        [CoreVarVal("prevalidation_notes", "String", TheFieldLength = 4096, Caption = "Pre-Validation Notes", Importance = 7)]
        public VarString prevalidation_notesVar;

        [CoreVarVal("validation_type", "String", TheFieldLength = 255, Caption = "Validation type", Importance = 7)]
        public VarString validation_typeVar;

        [CoreVarVal("prevalidation_complete", "Boolean", TheFieldLength = 255, Caption = "Prevalidation complete", Importance = 9)]
        public VarBoolean prevalidation_completeVar;

        [CoreVarVal("validation_complete", "Boolean", TheFieldLength = 255, Caption = "Validation complete", Importance = 9)]
        public VarBoolean validation_completeVar;



        

        public validation_form_auto()
        {
            StaticInit();
            orderid_salesVar = new VarString(this, orderid_salesAttribute);
            ordernumber_salesVar = new VarString(this, ordernumber_salesAttribute);
            pv_agentnameVar = new VarString(this, pv_agentnameAttribute);
            pv_agent_uidVar = new VarString(this, pv_agent_uidAttribute);
            v_agentnameVar = new VarString(this, v_agentnameAttribute);
            v_agent_uidVar = new VarString(this, v_agent_uidAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            company_uidVar = new VarString(this, company_uidAttribute);
            pvDoesShipToMatchVar = new VarBoolean(this, pvDoesShipToMatchAttribute);
            pvDoesShipToMatch_NotesVar = new VarString(this, pvDoesShipToMatch_NotesAttribute);
            pvDoesPnQtyPriceMfgMatchVar = new VarBoolean(this, pvDoesPnQtyPriceMfgMatchAttribute);
            pvDoesPnQtyPriceMfgMatch_NotesVar = new VarString(this, pvDoesPnQtyPriceMfgMatch_NotesAttribute);
            pvDescriptionsAllLinesMatchVar = new VarBoolean(this, pvDescriptionsAllLinesMatchAttribute);
            pvDescriptionsAllLinesMatch_NotesVar = new VarString(this, pvDescriptionsAllLinesMatch_NotesAttribute);
            pvDockDateRealisticVar = new VarBoolean(this, pvDockDateRealisticAttribute);            
            pvDockDateRealistic_NotesVar = new VarString(this, pvDockDateRealistic_NotesAttribute);
            prevalidation_notesVar = new VarString(this, prevalidation_notesAttribute);
            validation_typeVar = new VarString(this, validation_typeAttribute);
            prevalidation_completeVar = new VarBoolean(this, prevalidation_completeAttribute);
            validation_completeVar = new VarBoolean(this, validation_completeAttribute);            


        }

        public override string ClassId
        { get { return "validation_form"; } }

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

        public String pv_agentname
        {
            get { return (String)pv_agentnameVar.Value; }
            set { pv_agentnameVar.Value = value; }
        }

        public String pv_agent_uid
        {
            get { return (String)pv_agent_uidVar.Value; }
            set { pv_agent_uidVar.Value = value; }
        }

        public String v_agentname
        {
            get { return (String)v_agentnameVar.Value; }
            set { v_agentnameVar.Value = value; }
        }

        public String v_agent_uid
        {
            get { return (String)v_agent_uidVar.Value; }
            set { v_agent_uidVar.Value = value; }
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

        public bool pvDoesShipToMatch
        {
            get { return (bool)pvDoesShipToMatchVar.Value; }
            set { pvDoesShipToMatchVar.Value = value; }
        }

        public string pvDoesShipToMatch_Notes
        {
            get { return (string)pvDoesShipToMatch_NotesVar.Value; }
            set { pvDoesShipToMatch_NotesVar.Value = value; }
        }        

        public bool pvDoesPnQtyPriceMfgMatch
        {
            get { return (bool)pvDoesPnQtyPriceMfgMatchVar.Value; }
            set { pvDoesPnQtyPriceMfgMatchVar.Value = value; }
        }

        public string pvDoesPnQtyPriceMfgMatch_Notes
        {
            get { return (string)pvDoesPnQtyPriceMfgMatch_NotesVar.Value; }
            set { pvDoesPnQtyPriceMfgMatch_NotesVar.Value = value; }
        }

        public bool pvDescriptionsAllLinesMatch
        {
            get { return (bool)pvDescriptionsAllLinesMatchVar.Value; }
            set { pvDescriptionsAllLinesMatchVar.Value = value; }
        }

        public string pvDescriptionsAllLinesMatch_Notes
        {
            get { return (string)pvDescriptionsAllLinesMatch_NotesVar.Value; }
            set { pvDescriptionsAllLinesMatch_NotesVar.Value = value; }
        }

        public bool pvDockDateRealistic
        {
            get { return (bool)pvDockDateRealisticVar.Value; }
            set { pvDockDateRealisticVar.Value = value; }
        }
        public string pvDockDateRealistic_Notes
        {
            get { return (string)pvDockDateRealistic_NotesVar.Value; }
            set { pvDockDateRealistic_NotesVar.Value = value; }
        }


        public string prevalidation_notes
        {
            get { return (string)prevalidation_notesVar.Value; }
            set { prevalidation_notesVar.Value = value; }
        }

        public string validation_type
        {
            get { return (string)validation_typeVar.Value; }
            set { validation_typeVar.Value = value; }
        }

        public bool prevalidation_complete
        {
            get { return (bool)prevalidation_completeVar.Value; }
            set { prevalidation_completeVar.Value = value; }
        }

        public bool validation_complete
        {
            get { return (bool)validation_completeVar.Value; }
            set { validation_completeVar.Value = value; }
        }

       
    }
    public partial class validation_form
    {
        public static validation_form New(Context x)
        { return (validation_form)x.Item("validation_form"); }

        public static validation_form GetById(Context x, String uid)
        { return (validation_form)x.GetById("validation_form", uid); }

        public static validation_form QtO(Context x, String sql)
        { return (validation_form)x.QtO("validation_form", sql); }
    }
}
