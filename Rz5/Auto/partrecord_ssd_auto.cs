using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("partrecord_ssd")]
    public partial class partrecord_ssd_auto : NewMethod.nObject
    {
        static partrecord_ssd_auto()
        {
            Item.AttributesCache(typeof(partrecord_ssd_auto), AttributeCache);
        }


        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {

                case "partrecord_uid":
                    partrecord_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "capacity":
                    capacityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "formfactor":
                    formfactorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ssd_interface":
                    ssd_interfaceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "maxtemp":
                    maxtempAttribute = (CoreVarValAttribute)attr;
                    break;
             
                    
            }
        }


        static CoreVarValAttribute capacityAttribute;
        static CoreVarValAttribute partrecord_uidAttribute;
        static CoreVarValAttribute formfactorAttribute;
        static CoreVarValAttribute ssd_interfaceAttribute;
        static CoreVarValAttribute maxtempAttribute;
       
        

        

        [CoreVarVal("partrecord_uid", "String", TheFieldLength = 255, Caption = "Partrecord ID", Importance = 1)]
        public VarString partrecord_uidVar;

        [CoreVarVal("capacity", "String", TheFieldLength = 100, Caption = "Capacity", Importance = 2)]
        public VarString capacityVar;

        [CoreVarVal("formfactor", "String", TheFieldLength = 100, Caption = "Form Factor", Importance = 3)]
        public VarString formfactorVar;

         [CoreVarVal("ssd_interface", "String", TheFieldLength = 100, Caption = "ssd_interface", Importance = 4)]
        public VarString ssd_interfaceVar;

        [CoreVarVal("maxtemp", "String", TheFieldLength = 100, Caption = "Max. Temp", Importance = 5)]
         public VarString maxtempVar;
        
      
        


        public partrecord_ssd_auto()
        {
            StaticInit();
            partrecord_uidVar = new VarString(this, partrecord_uidAttribute);
            capacityVar = new VarString(this, capacityAttribute);
            formfactorVar = new VarString(this, formfactorAttribute);
            ssd_interfaceVar = new VarString(this, ssd_interfaceAttribute);
            maxtempVar = new VarString(this, maxtempAttribute);
            
            
            
            
        }




        public override string ClassId
        { get { return "partrecord_ssd"; } }

        public String partrecord_uid
        {
            get { return (String)partrecord_uidVar.Value; }
            set { partrecord_uidVar.Value = value; }
        }
        
        public String capacity
        {
            get { return (String)capacityVar.Value; }
            set { capacityVar.Value = value; }
        }

        public String formfactor
        {
            get { return (String)formfactorVar.Value; }
            set { formfactorVar.Value = value; }
        }

        public String ssd_interface
        {
            get { return (String)ssd_interfaceVar.Value; }
            set { ssd_interfaceVar.Value = value; }
        }

        public String maxtemp
        {
            get { return (String)maxtempVar.Value; }
            set { maxtempVar.Value = value; }
        }

       

        



    }
    public partial class partrecord_ssd
    {
        public static partrecord_ssd New(Context x)
        { return (partrecord_ssd)x.Item("partrecord_ssd"); }

        public static partrecord_ssd GetById(Context x, String uid)
        { return (partrecord_ssd)x.GetById("partrecord_ssd", uid); }

        public static partrecord_ssd QtO(Context x, String sql)
        { return (partrecord_ssd)x.QtO("partrecord_ssd", sql); }
    }
}
