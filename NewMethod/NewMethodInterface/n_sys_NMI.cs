using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewMethod
{
    public class n_sys_NMI : n_sys_NewMethod
    {
        public n_sys_NMI()
            : base(null)
        {
        }

        public override nView  GetView(string strClass, string strExtra)
        {
            switch (strClass.ToLower())
            {
                case "n_sys":
                    return new SystemView();
                case "n_class":
                    return new nView_n_class();
                default:
                    return base.GetView(strClass, strExtra);
            }
        }

        public void ShowInstanceByTarget(n_data_target t)
        {
            nData d = new nData(t);
            String s = "";
            if (!d.CanConnect(ref s))
            {
                nStatus.TellUser("The data source could not be connected to: " + s);
                return;
            }

            if (n_sys.ContextDefault.xSys != null)
            {
                if (Tools.Strings.StrExt(t.unique_id) && Tools.Strings.StrExt(unique_id))
                {
                    n_instance_target it = (n_instance_target)n_sys.ContextDefault.xSys.QtO("n_instance_target", "select * from n_instance_target where the_n_data_target_uid = '" + t.unique_id + "' and the_n_sys_uid = '" + unique_id + "'");
                    if (it == null)
                    {
                        it = new n_instance_target(n_sys.ContextDefault.xSys);
                        it.the_n_sys_uid = unique_id;
                        it.the_n_data_target_uid = t.unique_id;
                        it.name = t.server_name + "\\" + t.database_name;
                        it.ISave();
                    }
                }
            }

            ShowInstanceByData(d);
        }

        public void ShowInstanceByData(nData d)
        {
            //this is under construction 2010_03_30

            ////create the data structure in the instance target
            //UpdateDataStructure(d, false, false);

            //n_sys instance_sys = MakeInstanceSystem(d);
            //instance_sys.CreateAndShowMainForm();

            //instance_sys.unique_id = Tools.Strings.GetNewID();
            //InstanceSystems.Add(instance_sys);
        }

        public static void SetObjectCode(n_class c)
        {
            nLanguage_CSharp l = new nLanguage_CSharp();
            l.SetAltObjectCode_Auto(c);
        }

        public static bool UpdateAllCode(n_sys the_sys)
        {
            nLanguage_CSharp l = new nLanguage_CSharp();
            bool b = false;
            if (the_sys.xStructure.Classes.Count <= 0)
                b = true;
            n_class c;
            //bool bNewCode = nStatus.AskUser_YesNo("Would you like to use the new code generation?"); 
            bool bNewCode = true;
            foreach (DictionaryEntry d in the_sys.xStructure.Classes.AllByName)
            {
                c = (n_class)d.Value;
                if (c.needs_update)
                {
                    if (c.is_abstract)
                        c.ClearNeedsUpdate();
                    else
                    {
                        b = true;
                        //if (bNewCode)
                        //{
                        if (!l.RunAlternateCode(c))
                            return false;
                        else
                            c.ClearNeedsUpdate();
                        //}
                        //else
                        //{
                        //    if (!l.SetObjectCode(c))
                        //        return false;
                        //    else
                        //        c.ClearNeedsUpdate();
                        //}
                    }
                }
            }
            if (b)
                UpdateMyAutoCode(the_sys);

            foreach (n_sys s in the_sys.ChildSystems.All)
            {
                UpdateAllCode(s);
            }

            return true;
        }
        public static void UpdateMyAutoCode(n_sys the_sys)
        {
            nLanguage_CSharp l = new nLanguage_CSharp();
            String s = l.GetSystemCode(the_sys);
            String f = the_sys.GetRootFolder() + "iObjects\\auto\\n_sys_" + the_sys.system_name + "_auto.cs";
            nTools.MakeBackup(f);
            Tools.Files.SaveFileAsString(f, s);
        }


    }
}
