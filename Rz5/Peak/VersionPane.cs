using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Peak
{
    public partial class VersionPane : UserControl
    {
        public event EventHandler VersionSelected;

        NewMethod.Version xv;

        public VersionPane()
        {
            InitializeComponent();
        }


        public void CompleteLoad(NewMethod.Version v, bool is_latest, bool is_earliest)
        {
            xv = v;
            lblName.Text = v.ExeName;
            lblDate.Text = "Date: " + v.VersionDate.ToString();
            lblSize.Text = "Size: " + NewMethod.Tools.Strings.LongFormat(v.CalcSizeInMB()) + " MB";
            lblRemove.Visible = !is_latest;

            try
            {
                lblVersion.Text = GetVersion(v.FolderPath + "NewMethod.dll");
            }
            catch
            {
                lblVersion.Text = "";
            }

        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            if (VersionSelected != null)
                VersionSelected(xv, null);


        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(this.ParentForm, "Are you sure you want to remove " + xv.ExeName + "?", "Remove?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            lblName.Text = "Deleting...";

            //try the exe to see if its in use
            String sexe = NewMethod.Tools.Folder.ConditionFolderName(xv.FolderPath) + "Rz4Loader.exe";
            if (File.Exists(sexe))
            {
                try
                {
                    File.Delete(sexe);
                }
                catch
                {
                    MessageBox.Show("Version in use");
                    return;
                }
            }

            StringBuilder sb = new StringBuilder();
            xv.Obliterate(sb);
            lblName.Text = "Deleted";
            this.Enabled = false;          
        }

        public String GetVersion(String strDll)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(strDll);
            return "Version " + fvi.FileVersion;

            //return "Version 19.x.x.x";

            //String ret = "";
            //try
            //{
            //    AppDomain _domain = AppDomain.CreateDomain("Remote Load For Version");
            //    NMAssemblyLoader _aLoader =
            //        (NMAssemblyLoader)_domain.CreateInstanceAndUnwrap("NMAssemblyLoader", "Peak");

            //    ret = _aLoader.GetVersion(strDll);

            //    AppDomain.Unload(_domain);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //return ret;
        }
    }

    [Serializable]
	public class NMAssemblyLoader : System.MarshalByRefObject /*<updated>*/
	{
		public String GetVersion(String strDll)
		{
            String ret = "";
            Assembly a = Assembly.LoadFile(strDll);
            if (a != null)
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(a.Location);
                ret = "Version: " + fvi.ProductMajorPart.ToString() + "." + fvi.ProductMinorPart.ToString() + "." + fvi.ProductBuildPart.ToString() + "." + fvi.ProductPrivatePart.ToString();
                fvi = null;
                a = null;
            }
            return ret;
		}		
	}
}
