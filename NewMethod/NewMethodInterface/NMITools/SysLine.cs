using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class SysLine : UserControl, IRefreshable
    {
        public n_sys TheSys;

        public SysLine()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }

        //this probably needs an actual system
        public void CompleteLoad(n_sys xs)
        {
            TheSys = xs;
            DoRefresh();
        }

        public Control RefreshControl
        {
            get
            {
                return this;
            }
        }

        public void DoRefresh()
        {
            lblSystemName.Text = TheSys.system_name;
            lblReferencedBy.Text = "Referenced By: " + Tools.Number.LongFormat(TheSys.ChildSystems.Count);
            lblReferencing.Text = "Referencing: " + Tools.Number.LongFormat(TheSys.ParentSystems.Count);

            bool hs = true;

            if (TheSys == null)
            {
                hs = false;
            }
            else
            {
                if (TheSys.xStructure == null)
                    hs = false;
                else
                {
                    if (TheSys.xStructure.CurrentType == StructureType.NoStructure)
                        hs = false;
                }
            }

            if(hs)
            {
                lblConnection.Visible = true;
                lblChangeConnection.Visible = !m_PassiveMode;
                lblDisconnect.Visible = !m_PassiveMode;
                lblEditStructure.Visible = true;
                lblDerive.Visible = true;
                lblPullInClass.Visible = true;

                //lblReferencedBy.Visible = true;
                //lblReferencing.Visible = true;

                lblClasses.Text = "Classes: " + Tools.Number.LongFormat(TheSys.xStructure.Classes.Count);
                switch (TheSys.xStructure.CurrentType)
                {
                    case StructureType.XmlStructure:
                        lblConnection.Text = "Connection: Xml [" + TheSys.xStructure.xHandle.XmlFileName + "]";
                        lblChangeConnection.Text = "Switch To Database";
                        break;
                    case StructureType.DatabaseStructure:
                        lblConnection.Text = "Connection: Database [Server: " + TheSys.xStructure.xHandle.xData.server_name + "]";
                        lblChangeConnection.Text = "Switch To Xml";
                        break;
                }

                if (Tools.Strings.StrCmp(TheSys.system_name, "NewMethod"))
                {
                    lblInstances.Visible = false;
                    lblRecentInstances.Visible = false;
                }
                else
                {
                    lblInstances.Visible = true;
                    lblRecentInstances.Visible = true;
                }

                lblSubSystems.Visible = true;

                LoadSubSystemMenu();
                LoadInstanceMenu();
            }
            else
            {
                lblClasses.Text = "No Classes";

                lblConnection.Visible = false;
                lblChangeConnection.Visible = false;
                lblDisconnect.Visible = false;
                lblEditStructure.Visible = false;
                lblDerive.Visible = false;
                lblInstances.Visible = false;
                lblRecentInstances.Visible = false;
                lblSubSystems.Visible = false;
                lblPullInClass.Visible = false;
                //lblReferencedBy.Visible = false;
                //lblReferencing.Visible = false;
            }           
        }

        private void lblDisconnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            n_sys.RemoveSystem(TheSys);
        }

        nStatusTarget m_xStatusTarget;
        public nStatusTarget xStatusTarget
        {
            get
            {
                if( m_xStatusTarget == null )
                    m_xStatusTarget = new nStatusTarget(new SetStatusDelegate(HandleStatus), new SetProgressDelegate(HandleProgress), new SetStateDelegate(HandleState), this);

                return m_xStatusTarget;
            }
        }

        public void HandleStatus(String s)
        {

        }

        public void HandleProgress(int p)
        {
            pb.Value = p;
        }

        public void HandleState(StatusStateType t)
        {
            DoRefresh();

            switch (t)
            {
                case StatusStateType.Done:
                    throb.HideThrobber();
                    pb.Visible = false;
                    break;
                case StatusStateType.Working:
                    throb.ShowThrobber();
                    pb.Visible = true;
                    break;
                case StatusStateType.Error:
                    throb.HideThrobber();
                    pb.Visible = false;
                    break;
            }
        }

        private void lblChangeConnection_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StructureHandle h = null;
            switch (TheSys.xStructure.CurrentType)
            {
                case StructureType.DatabaseStructure:
                    h = frmSysFinder.FindXml(this.ParentForm);
                    break;
                case StructureType.XmlStructure:
                    h = frmSysFinder.FindDatabase(this.ParentForm);
                    break;
            }

            if (h != null)
                TheSys.xStructure.SwitchToHandleAsync(h);
        }

        private void lblEditStructure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TheSys.ShowObject(TheSys, n_sys.SoftStructureForm);
            n_sys.ContextDefault.xSys.ShowObject(TheSys, n_sys.SoftStructureForm);
        }

        private void lblDerive_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SystemDerivationGuide d = new SystemDerivationGuide();
            n_sys.SoftStructureForm.TabShow(d, "Derive From " + TheSys.system_name);
            d.CompleteLoad(TheSys);
            d.LoadTargets();
        }

        public bool m_PassiveMode = false;
        public bool PassiveMode
        {
            get
            {
                return m_PassiveMode;
            }

            set
            {
                m_PassiveMode = value;
                //DoRefresh();
            }
        }

        private void lblInstances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InstanceGuide d = new InstanceGuide();
            n_sys.SoftStructureForm.TabShow(d, "Instances Of " + TheSys.system_name);
            d.CompleteLoad();
            d.LoadTargets();
        }

        private void mnuSubSystems_Opening(object sender, CancelEventArgs e)
        {

        }

        void LoadSubSystemMenu()
        {
            mnuSubSystems.Items.Clear();
            if (n_sys.ContextDefault.xSys == null)
                return;

            ArrayList a = n_sys.ContextDefault.xSys.QtC("n_sys_target", "select * from n_sys_target where the_n_sys_uid = '" + TheSys.unique_id + "' order by system_name");
            foreach (n_sys_target t in a)
            {
                ToolStripMenuItem i = new ToolStripMenuItem(t.system_name);
                i.Click += new EventHandler(i_Click);
                i.Tag = t;
                mnuSubSystems.Items.Add(i);
            }
        }

        void LoadInstanceMenu()
        {
            mnuInstances.Items.Clear();
            if (n_sys.ContextDefault.xSys == null)
                return;

            ArrayList a = n_sys.ContextDefault.xSys.QtC("n_instance_target", "select * from n_instance_target where the_n_sys_uid = '" + TheSys.unique_id + "'");
            foreach (n_instance_target t in a)
            {
                ToolStripMenuItem i = new ToolStripMenuItem(t.name);
                i.Click += new EventHandler(instance_Click);
                i.Tag = t;
                mnuInstances.Items.Add(i);
            }
        }

        public event SystemTargetHandler LoadTarget;
        void i_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem i = (ToolStripMenuItem)sender;
                n_sys_target t = (n_sys_target)i.Tag;

                if (LoadTarget != null)
                    LoadTarget(this, t);

            }
            catch { }
        }

        void instance_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ToolStripMenuItem i = (ToolStripMenuItem)sender;
            //    n_instance_target it = (n_instance_target)i.Tag;
            //    n_data_target t = it.GetDataTarget();
            //    if (t == null)
            //        return;

            //    TheSys.ShowInstanceByTarget(t);
            //}
            //catch { }
        }

        private void lblSubSystems_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mnuSubSystems.Show(System.Windows.Forms.Cursor.Position);
        }

        private void lblRecentInstances_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mnuInstances.Show(Cursor.Position);
        }

        private void lblPullInClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChooseClass xForm = new frmChooseClass();
            xForm.xSys = TheSys;
            xForm.LoadClasses();
            xForm.ShowDialog(this.ParentForm);
            n_class c = xForm.SelectedClass;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            if (c == null)
                return;

            if (!nStatus.AreYouSure("pull " + c.class_name + " into " + TheSys.system_name))
                return;

            n_class nc = (n_class)c.CloneWithNewID();
            nc.xSys = TheSys;
            nc.the_n_sys_uid = TheSys.unique_id;
            nc.ISave_PreserveID(n_sys.ContextDefault);

            foreach (n_prop p in c.Props.All)
            {
                n_prop np = (n_prop)p.CloneWithNewID();
                np.the_n_class_uid = nc.unique_id;
                np.xSys = TheSys;
                np.ISave_PreserveID(n_sys.ContextDefault);
            }

            nStatus.TellUser("Done");
        }

        private void lblCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewMethodInterface.Program.ClipboardSys = TheSys;
        }

        private void lblPaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NewMethodInterface.Program.ClipboardSys == null)
            {
                nStatus.TellUser("No copied system");
                return;
            }

            foreach (n_class c in NewMethodInterface.Program.ClipboardSys.xStructure.Classes.All)
            {
                n_class x = (n_class)TheSys.xStructure.Classes.GetByName(c.class_name);
                if (x == null)
                {
                    x = TheSys.AddNewClass(c.class_name);
                    x.class_tag = c.class_tag;
                    x.is_abstract = c.is_abstract;
                    x.plural_line = c.plural_line;
                    x.plural_tag = c.plural_tag;
                    x.ISave();
                }

                n_class nmc = (n_class)NewMethodInterface.Program.NewMethodSys.xStructure.Classes.GetByName(c.class_name);
                if( nmc != null )
                    TheSys.RelateTwoClasses(nmc, x, "inherit", false, NewMethod.Enums.RelationshipType.Inherit);

                foreach (n_prop p in c.Props.All)
                {
                    switch (p.name.ToLower())
                    {
                        case "unique_id":
                            continue;
                    }

                    n_prop px = x.GetPropByName(p.name);
                    if (px == null)
                    {
                        px = new n_prop(TheSys);
                        px.name = p.name;
                        px.property_tag = p.property_tag;
                        px.property_type = p.property_type;
                        px.property_use = p.property_use;
                        px.property_length = p.property_length;
                        x.AbsorbNewProperty(px, false);
                        px.IUpdate();
                    }
                }
                x.IUpdate();
            }

            DoRefresh();
            nStatus.Done();
        }
    }

    public delegate void SystemTargetHandler(Object sender, n_sys_target t);

   
}
