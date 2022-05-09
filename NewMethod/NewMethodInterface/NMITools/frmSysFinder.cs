using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Tools;

namespace NewMethod
{
    public partial class frmSysFinder : Form
    {

        public static StructureHandle Find(IWin32Window owner)
        {
            return Find(owner, true, true, false);
        }
        public static StructureHandle FindXml(IWin32Window owner)
        {
            return Find(owner, true, false, true);
        }
        public static StructureHandle FindDatabase(IWin32Window owner)
        {
            return Find(owner, false, true, true);
        }

        public static StructureHandle Find(IWin32Window owner, bool allow_xml, bool allow_database, bool allow_loaded)
        {
            frmSysFinder f = new frmSysFinder();
            f.CompleteLoad(allow_xml, allow_database, allow_loaded);
            f.ShowDialog(owner);
            StructureHandle ret = f.SelectedHandle;
            try
            {
                f.Close();
                f.Dispose();
                f = null;                
            }
            catch { }
            return ret;
        }

        public StructureHandle SelectedHandle = null;
        ArrayList SystemNames;
        nData SystemData;
        bool allow_xml = true;
        bool allow_database = true;
        bool allow_loaded = false;

        public frmSysFinder()
        {
            InitializeComponent();
        }

        public void CompleteLoad(bool ax, bool ad, bool al)
        {
            allow_xml = ax;
            allow_database = ad;
            allow_loaded = al;
            ctlUser.SetValue("sa");

            if (!allow_database)
            {
                ctlServerName.Visible = false;
                ctlUser.Visible = false;
                ctlPassword.Visible = false;
                lblCheck.Visible = false;
            }
        }

        private void ctlSysName_DataChanged(GenericEvent e)
        {
            if( allow_xml )
                CheckXML();
        }

        void CheckXML()
        {
            try
            {
                String s = ctlSysName.GetValue_String();
                if (!Tools.Strings.StrExt(s))
                    return;

                String strFile = n_sys.GetRootFolder(s) + s + ".xml";
                if (!File.Exists(strFile))
                    lblXML.Visible = false;
                else
                {
                    lblXML.Visible = true;
                    lblXML.Text = strFile;
                }
            }
            catch { }
        }

        private void lblXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String strName = ctlSysName.GetValue_String();
            if (!Tools.Strings.StrExt(strName))
                return;

            if (n_sys.AllSystems.HasName(strName) && !allow_loaded)
            {
                nStatus.TellUser("The system '" + strName + "' is already loaded.");
                return;
            }

            SelectedHandle = new StructureHandle();
            SelectedHandle.SystemName = strName;
            SelectedHandle.HandleType = StructureType.XmlStructure;
            SelectedHandle.XmlFileName = lblXML.Text;
            this.Hide();
        }

        private void ctlServerName_DataChanged(GenericEvent e)
        {
            if (!allow_database)
                return;

            if (ToolsWin.SystemWin.IsDevelopmentMachine())
            {
                String s = GetSelectedServer();
                switch (s)
                {
                    case "V4":
                    case "LAPTOP07":
                        ctlPassword.SetValue("rec0gnin");
                        TryShowSystems();
                        break;
                    default:
                        break;
                }
            }
        }

        void TryShowSystems()
        {
            if (bg.IsBusy)
                return;

            lvSystems.Items.Clear();
            SystemNames = new ArrayList();
            SystemData = new nData(new n_data_target((Int32)Enums.ServerTypes.SQLServer, ctlServerName.GetValue_String(), "NewMethod", ctlUser.GetValue_String(), ctlPassword.GetValue_String()));
            bg.RunWorkerAsync();
        }

        String GetSelectedServer()
        {
            return Tools.Strings.ParseDelimit(ctlServerName.GetValue_String(), "[", 1).Trim();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            if (SystemData.CanConnect())
                SystemNames = SystemData.GetScalarArray("select distinct(system_name) from n_sys where isnull(system_name, '') > '' order by system_name");
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool match = false;
            lvSystems.BeginUpdate();
            try
            {
                foreach (String s in SystemNames)
                {
                    lvSystems.Items.Add(s);
                    if (Tools.Strings.StrCmp(s, ctlSysName.GetValue_String()))
                        match = true;
                }
            }
            catch { }
            lvSystems.EndUpdate();

            if( !match )
                lblDatabase.Visible = false;
            else
            {
                lblDatabase.Visible = true;
                lblDatabase.Text = ctlSysName.GetValue_String() + " [Database]";
            }
        }

        private void lblCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TryShowSystems();
        }

        private void lblDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String strName = ctlSysName.GetValue_String();
            if (!Tools.Strings.StrExt(strName))
                return;

            if (n_sys.AllSystems.HasName(strName) && !allow_loaded)
            {

                nStatus.TellUser("The system '" + strName + "' is already loaded.");
                return;
            }

            SelectedHandle = new StructureHandle();
            SelectedHandle.SystemName = strName;
            SelectedHandle.HandleType = StructureType.DatabaseStructure;
            SelectedHandle.xData = SystemData;
            this.Hide();
        }
    }
}