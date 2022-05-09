using System;
using System.Windows.Forms;
using NewMethodx;
using ConnectionManagerCore;

namespace ConnectionManager
{
    public partial class ConnectionAdvanced : ConnectionManagerPanel
   {
        public ConnectionAdvanced()
        {
            InitializeComponent();

            this.EnableNextButton(false);
        }

        private void ShowRestore()
        {
            //nData d = new nData();
            //d.database_name = "master";
            //d.server_name = txtServer.Text;
            //d.target_type = (Int32)NewMethodx.Enums.ServerTypes.SQLServer;
            //d.user_name = txtUserName.Text;
            //d.user_password = txtPassword.Text;
            //d.SetConnectionString();
            //frmRestoreDB f = new frmRestoreDB();
            //if (!f.CompleteLoad(d))
            //{
            //    MessageBox.Show("Failed to connect. Please check your server settings.");
            //    return;
            //}
            //f.ShowDialog();
        }

        protected override void cancelButton_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Cancelling now will terminate installation. " +
            //                                            "Click 'Yes' to cancel or 'No' to continue.",
            //                                            "Cancel Download?", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
                Control parent = this.Parent;
                parent.Controls.Remove(this);
                InstallAction install = new InstallAction();
                parent.Controls.Add(install);
            //}
        }

        protected override void nextButton_Click(object sender, EventArgs e)
        {
            if (ToolsConnection.ConnectionFileDataSet(this.txtServer.Text, this.txtUserName.Text, this.txtPassword.Text, this.txtDatabaseName.Text))
            {
                Control parent = this.Parent;
                parent.Controls.Remove(this);
                InstallAction install = new InstallAction();
                parent.Controls.Add(install);
                ConnectionTest test = new ConnectionTest();
                test.Show();
            }
            else
                MessageBox.Show("Save Failed");

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (this.txtServer.Text == "" || this.txtUserName.Text == "" || this.txtPassword.Text == "" || this.txtDatabaseName.Text == "")
                this.EnableNextButton(false);
            else
                this.EnableNextButton(true);
        }

        private void lnkRestore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRestore();
        }
   }
}