using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("qc_turn_back", Caption = "Turn Backs", Importance = 84)]
    public partial class qc_turn_back_auto : NewMethod.nObject
    {
        static qc_turn_back_auto()
        {
            Item.AttributesCache(typeof(qc_turn_back_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "insp_id":
                    insp_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "turn_back_agent":
                    turn_back_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "turn_back_agent_uid":
                    turn_back_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "turn_back_date":
                    turn_back_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "turn_back_notes":
                    turn_back_notesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "inspection_agent":
                    inspection_agentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "inspection_agent_uid":
                    inspection_agent_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "turn_back_resolution_date":
                    turn_back_resolution_dateAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }


        static CoreVarValAttribute insp_idAttribute;
        static CoreVarValAttribute turn_back_agentAttribute;
        static CoreVarValAttribute turn_back_agent_uidAttribute;
        static CoreVarValAttribute turn_back_dateAttribute;
        static CoreVarValAttribute turn_back_notesAttribute;
        static CoreVarValAttribute inspection_agentAttribute;
        static CoreVarValAttribute inspection_agent_uidAttribute;
        static CoreVarValAttribute turn_back_resolution_dateAttribute;




        [CoreVarVal("insp_id", "String", Caption = "insp_id", Importance = 0)]
        public VarString insp_idVar;

        [CoreVarVal("turn_back_agent", "String", Caption = "turn_back_agent", Importance = 0)]
        public VarString turn_back_agentVar;

        [CoreVarVal("turn_back_agent_uid", "String", Caption = "turn_back_agent_uid Name", Importance = 1)]
        public VarString turn_back_agent_uidVar;

        [CoreVarVal("turn_back_date", "DateTime", Caption = "turn_back_date", Importance = 2)]
        public VarDateTime turn_back_dateVar;

        [CoreVarVal("turn_back_notes", "Text", Caption = "Total turn_back_notes", Importance = 3)]
        public VarString turn_back_notesVar;

        [CoreVarVal("inspection_agent", "String", Caption = "inspection_agent", Importance = 4)]
        public VarText inspection_agentVar;

        [CoreVarVal("inspection_agent_uid", "String", Caption = "Dest inspection_agent_uid Name", Importance = 5)]
        public VarString inspection_agent_uidVar;

        [CoreVarVal("turn_back_resolution_date", "DateTime", Caption = "turn_back_resolution_date", Importance = 6)]
        public VarDateTime turn_back_resolution_dateVar;

        public qc_turn_back_auto()
        {
            StaticInit();

            insp_idVar = new VarString(this, insp_idAttribute);
            turn_back_agentVar = new VarString(this, turn_back_agentAttribute);
            turn_back_agent_uidVar = new VarString(this, turn_back_agent_uidAttribute);
            turn_back_dateVar = new VarDateTime(this, turn_back_dateAttribute);
            turn_back_notesVar = new VarString(this, turn_back_notesAttribute);
            inspection_agentVar = new VarText(this, inspection_agentAttribute);
            inspection_agent_uidVar = new VarString(this, inspection_agent_uidAttribute);
            turn_back_resolution_dateVar = new VarDateTime(this, turn_back_resolution_dateAttribute);

        }

        public override string ClassId
        { get { return "qc_turn_back"; } }




        public string insp_id
        {
            get { return (string)insp_idVar.Value; }
            set { insp_idVar.Value = value; }
        }
        public String turn_back_agent
        {
            get { return (String)turn_back_agentVar.Value; }
            set { turn_back_agentVar.Value = value; }
        }

        public String turn_back_agent_uid
        {
            get { return (String)turn_back_agent_uidVar.Value; }
            set { turn_back_agent_uidVar.Value = value; }
        }

        public DateTime turn_back_date
        {
            get { return (DateTime)turn_back_dateVar.Value; }
            set { turn_back_dateVar.Value = value; }
        }

        public string turn_back_notes
        {
            get { return (string)turn_back_notesVar.Value; }
            set { turn_back_notesVar.Value = value; }
        }

        public String inspection_agent
        {
            get { return (String)inspection_agentVar.Value; }
            set { inspection_agentVar.Value = value; }
        }

        public String inspection_agent_uid
        {
            get { return (String)inspection_agent_uidVar.Value; }
            set { inspection_agent_uidVar.Value = value; }
        }

        public DateTime turn_back_resolution_date
        {
            get { return (DateTime)turn_back_resolution_dateVar.Value; }
            set { turn_back_resolution_dateVar.Value = value; }
        }


    }
    public partial class qc_turn_back
    {
        public static qc_turn_back New(Context x)
        { return (qc_turn_back)x.Item("qc_turn_back"); }

        public static qc_turn_back GetById(Context x, String uid)
        { return (qc_turn_back)x.GetById("qc_turn_back", uid); }

        public static qc_turn_back QtO(Context x, String sql)
        { return (qc_turn_back)x.QtO("qc_turn_back", sql); }

        public static qc_turn_back GetByName(Context x, String name, String extraSql = "")
        { return (qc_turn_back)x.GetByName("qc_turn_back", name, extraSql); }
    }
}
