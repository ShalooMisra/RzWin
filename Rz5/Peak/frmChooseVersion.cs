using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Peak
{
    public partial class frmChooseVersion : Form
    {
        public static NewMethod.Version Choose(ArrayList a)
        {
            frmChooseVersion f = new frmChooseVersion();
            f.CompleteLoad(a);
            f.ShowDialog();
            NewMethod.Version v = f.SelectedVersion;
            try
            {
                f.Dispose();
                f = null;
            }
            catch
            {

            }
            return v;
        }

        public NewMethod.Version SelectedVersion = null;

        public frmChooseVersion()
        {
            InitializeComponent();
        }

        void CompleteDispose()
        {
            try
            {
                foreach (VersionPane p in VersionControls)
                {
                    fp.Controls.Remove(p);
                    p.VersionSelected -= new EventHandler(p_VersionSelected);
                    p.Dispose();
                }
            }
            catch { }
            VersionControls.Clear();
        }

        ArrayList VersionControls = new ArrayList();
        public void CompleteLoad(ArrayList a)
        {

            //KT 6-11-2018 For now I want to disable this, will bring it back when I have my head around this logic with the new changes.
            lblCompleteDelete.Visible = false;
            lblCompleteDelete.Enabled = false;

            VersionControls.Clear();
            a.Reverse();
            int i = 0;
            foreach (NewMethod.Version v in a)
            {
                VersionPane p = null;

                if (i > 0)
                {
                    p = new VersionPane();
                    fp.Controls.Add(p);
                    VersionControls.Add(p);
                    p.VersionSelected += new EventHandler(p_VersionSelected);
                }
                else
                {
                    p = vp;
                }

                p.Width = fp.ClientRectangle.Width - 20;

                p.CompleteLoad(v, (i == 0), (i == a.Count - 1));
                i++;
            }
        }

        void p_VersionSelected(object sender, EventArgs e)
        {
            //remove old ones
            ArrayList a = NewMethod.VersionUpdate.GetVersions(Program.ApplicationName, Program.ApplicationName, Program.FolderName, true);
            //KT so, changing this to 2 for my new changes (i.e. including the \Programfiles\Rz folder as a "version")
            //if (a.Count < 3)
            if (a.Count < 2)
                return;

            //remove the first entirely as an option
            a.RemoveAt(0);
            a.Reverse();

            StringBuilder sb = new StringBuilder();

            for (int i = 3; i < a.Count; i++)  //skip the most recent 3
            {
                NewMethod.Version v = (NewMethod.Version)a[i];
                if (DateTime.Now.Subtract(v.VersionDate).TotalDays > 10)
                    v.Obliterate(sb);
            }

            this.SelectedVersion = (NewMethod.Version)sender;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedVersion = null;
            this.Close();
        }

        private void lblCompleteDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to permanently delete every version except for the latest one?  This will not affect the database but it will remove all files in previous version folders on this workstation including reports, exports, and any other information or documents that were added to this program's folders on this machine.  Do you want to continue?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            ArrayList a = NewMethod.VersionUpdate.GetVersions(Program.ApplicationName, Program.ApplicationName, Program.FolderName, true);
            if (a.Count < 3)
                return;

            //remove the first entirely as an option
            a.RemoveAt(0);
            a.Reverse();

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < a.Count; i++)  //skip the latest one
            {
                NewMethod.Version v = (NewMethod.Version)a[i];
                v.Obliterate(sb);
            }

            MessageBox.Show("Done.  Please reopen the menu to see the changes.");
            this.SelectedVersion = null;
            this.Close();
        }
    }
}
