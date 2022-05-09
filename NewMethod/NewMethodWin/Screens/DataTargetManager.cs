using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
   

    public partial class DataTargetManager : UserControl
    {
        SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }

        public DataTargetManager()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            lstTargets.ShowTemplate("all_targets", "n_data_target");
            lstTargets.ShowData("n_data_target", "", "name");
        }

        private void lstTargets_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            String strName = NMWin.Leader.AskForString("Name", "Data Target 1", "Name");
            if (!Tools.Strings.StrExt(strName))
                return;

            n_data_target t = n_data_target.New(NMWin.ContextDefault);
            t.name = strName;
            t.user_name = "sa";
            t.server_name = Tools.Strings.ParseDelimit(strName, "-", 1).Trim();
            t.target_type = 2; //sql server
            NMWin.ContextDefault.Insert(t);
            lstTargets.ReDoSearch();

            ShowTarget(t);
        }

        private void dv_GotSave(nView s)
        {
            NMWin.ContextDefault.Update(dv.CurrentTarget);
            lstTargets.ReDoSearch();
        }

        private void lstTargets_ObjectClicked(object sender, ObjectClickArgs args)
        {
            args.Handled = true;
            try
            {
                ShowTarget((n_data_target)args.GetObject());
            }
            catch { }
        }

        public void ShowTarget(n_data_target t)
        {
            dv.Init(t);
            dv.CompleteLoad();
        }

        private void lstTargets_AboutToDelete(object sender, ActArgs args)
        {
            //args.Handled = true;
            //args.xObject.DeleteFromLocalXml();
            //n_data_target.GetLocalDataConnections(xSys).Remove(args.xObject);
        }

        public n_data_target GetSelectedTarget()
        {
            return dv.CurrentTarget;
        }
    }
}
