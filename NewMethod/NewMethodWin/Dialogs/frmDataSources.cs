using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class frmDataSources : Form
    {
        public static n_data_target Choose(System.Windows.Forms.IWin32Window owner, SysNewMethod xs)
        {
            frmDataSources xForm = new frmDataSources();
            xForm.CompleteLoad(xs);
            xForm.ShowDialog(owner);
            n_data_target t = xForm.SelectedTarget;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return t;
        }

        public static Tools.Database.DataConnection ChooseConnection(System.Windows.Forms.IWin32Window owner, SysNewMethod xs)
        {
            frmDataSources xForm = new frmDataSources();
            xForm.CompleteLoad(xs);
            xForm.ShowDialog(owner);
            Tools.Database.DataConnection ret = xForm.SelectedConnection;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return ret;
        }

        public SysNewMethod xSys;
        public n_data_target SelectedTarget;
        public n_data_target CurrentTarget;

        public frmDataSources()
        {
            InitializeComponent();
        }

        public void CompleteLoad(SysNewMethod xs)
        {
            xSys = xs;
            lv.ShowTemplate("data_sources", "n_data_target", true);
            lv.ShowData("n_data_target", "", "name");
            CurrentTarget = null;
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                if (CurrentTarget == null)
                {
                    gb.Enabled = false;
                }
                else
                {
                    gb.Enabled = true;
                }
            }
            catch (Exception)
            { }
        }

        private void lv_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            LoadTarget((n_data_target)args.TheItems.FirstGet(NMWin.ContextDefault));
        }

        private void LoadTarget(n_data_target t)
        {
            if (CurrentTarget != null)
                SaveTarget();

            ctl_name.SetValue(t.name);
            ctl_server_name.SetValue(t.server_name);
            ctl_database_name.SetValue(t.database_name);
            ctl_user_name.SetValue(t.user_name);
            ctl_user_password.SetValue(t.user_password);
            ctl_command_string.SetValue(t.command_string);

            if (t.target_type == (int)Enums.ServerTypes.MySQL)
                optMySQL.Checked = true;
            else
                optSQLServer.Checked = true;

            CurrentTarget = t;
            gb.Enabled = true;
        }

        private void SaveTarget()
        {
            if (CurrentTarget == null)
                return;

            CurrentTarget.name = (String)ctl_name.GetValue();
            CurrentTarget.server_name = (String)ctl_server_name.GetValue();
            CurrentTarget.database_name = (String)ctl_database_name.GetValue();
            CurrentTarget.user_name = (String)ctl_user_name.GetValue();
            CurrentTarget.user_password = (String)ctl_user_password.GetValue();
            CurrentTarget.command_string = (String)ctl_command_string.GetValue();

            if (optMySQL.Checked)
                CurrentTarget.target_type = (Int32)Enums.ServerTypes.MySQL;
            else
                CurrentTarget.target_type = (Int32)Enums.ServerTypes.SQLServer;

            NMWin.ContextDefault.Update(CurrentTarget);
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveTarget();
        }

        private void lv_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            n_data_target t = n_data_target.New(NMWin.ContextDefault);
            
            if( optMySQL.Checked )
                t.target_type = (Int32)Enums.ServerTypes.MySQL;
            else
                t.target_type = (Int32)Enums.ServerTypes.SQLServer;
    
            t.name = "New Data Source";
            t.database_name = NMWin.Data.TheKey.DatabaseName;
            t.user_name = "sa";
            t.server_name = System.Environment.MachineName;
            NMWin.ContextDefault.Insert(t);
            LoadTarget(t);
            lv.ReDoSearch();
        }

        private void lv_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedTarget = null;
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (CurrentTarget == null)
            {
                NMWin.Leader.Tell("Please choose a data source before continuing.");
                return;
            }
            SelectedTarget = CurrentTarget;
            this.Hide();
        }

        private void cmdTestConnect_Click(object sender, EventArgs e)
        {
            if (CurrentTarget == null)
                return;
            SaveTarget();

            Tools.Database.DataConnection con = SelectedConnection;
            String err = "";
            if(con.ConnectPossible(ref err))
                NMWin.Leader.Tell("This data source is available.");
            else
                NMWin.Leader.Tell("Connection error: " + err);
        }

        public Tools.Database.DataConnection SelectedConnection
        {
            get
            {
                if (CurrentTarget == null)
                    return null;

                Tools.Database.DataConnection con = null;

                switch (CurrentTarget.TargetType)
                {
                    case Enums.ServerTypes.SQLServer:
                        con = Tools.Database.DataConnection.Create(Tools.Database.ServerType.SqlServer);
                        break;
                    case Enums.ServerTypes.MySQL:
                        con = Tools.Database.DataConnection.Create(Tools.Database.ServerType.SqlMy);
                        break;
                    default:
                        return null;
                }

                con.TheKey = new Tools.Database.Key();
                con.TheKey.ServerName = CurrentTarget.server_name;
                con.TheKey.UserName = CurrentTarget.user_name;
                con.TheKey.UserPassword = CurrentTarget.user_password;
                con.TheKey.DatabaseName = CurrentTarget.database_name;
                con.ConnectionStringSet();
                return con;
            }
        }
    }
}