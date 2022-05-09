                                   using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class SysManager : UserControl, IRefreshable
    {
        public SysManager()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            n_sys.StaticRefresh.Add(this);
            ShowSystems();
            n_sys_target t = GetNMTarget();
            if (t == null)
                lblLastNM.Visible = false;
            else
            {
                lblLastNM.Visible = true;
                if (Tools.Strings.StrExt(t.xml_file))
                    lblLastNM.Text = "open last NM: [Xml]";
                else
                    lblLastNM.Text = "open last NM: [Database:" + t.server_name + "]";
            }
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
            ShowSystems();
        }

        ArrayList LastSystemList = new ArrayList();  //for checking deletes
        ArrayList SystemLines = new ArrayList();
        public void ShowSystems()
        {
            ArrayList ThisTime = new ArrayList();

            try
            {
                foreach (n_sys s in n_sys.AllSystems.All)
                {
                    ThisTime.Add(s);
                    LastSystemList.Remove(s);
                    if (s.xLine == null)
                    {
                        s.xLine = new SysLine();
                        ((SysLine)s.xLine).LoadTarget += new SystemTargetHandler(xLine_LoadTarget);
                        fp.Controls.Add(((SysLine)s.xLine));
                        SystemLines.Add(s.xLine);
                        ((SysLine)s.xLine).CompleteLoad(s);
                    }
                }

                ArrayList ToRemove = new ArrayList();
                foreach (n_sys s in LastSystemList)
                {
                    foreach (SysLine l in SystemLines)
                    {
                        if (l.TheSys == s)
                            ToRemove.Add(l);
                    }
                }

                foreach (SysLine l in ToRemove)
                {
                    l.LoadTarget += new SystemTargetHandler(xLine_LoadTarget);
                    SystemLines.Remove(l);
                    fp.Controls.Remove(l);
                }

                LastSystemList = ThisTime;

            }
            catch { }
        }

        void xLine_LoadTarget(object sender, n_sys_target t)
        {
            AddSystemByHandle(t.GetAsHandle());
        }

        private void lblOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StructureHandle h = frmSysFinder.Find(this.ParentForm);
            if (h == null)
                return;

            AddSystemByHandle(h);
        }

        public void AddSystemByHandle(StructureHandle h)
        {
            if (!h.Prepare())  //gets the unique id from the xml or database so that addsystem can use the right id
            {                  //also grabs the parent system requirements
                nStatus.TellUser("This system couldn't be prepared.");
                return;
            }

            foreach (String s in h.ParentSystemNames)
            {
                bool fail = false;
                StringBuilder sb = new StringBuilder();
                if (!n_sys.AllSystems.HasName(s))
                {
                    sb.AppendLine(s);
                    fail = true;
                }

                if (fail)
                {
                    nStatus.TellUser("Please load the following system(s) before continuing:\r\n\r\n" + sb.ToString());
                    return;
                }
            }

            n_sys xs = n_sys.MakeSystem(h.SystemName);
            xs.xSys = xs;
            xs.CreateStructure();
            xs.unique_id = h.SystemID;
            xs.system_name = h.SystemName;
            n_sys.AddSystem(xs);
            
            //ShowSystems();  AddSystem shows automatically



            nStatusTarget t = null;
            SysLine l = GetLineBySystem(xs);
            if (l != null)
                t = l.xStatusTarget;

            if (Tools.Strings.StrCmp(xs.system_name, "NewMethod"))  //for newmethod, structure and instance changes are identical
            {
                xs.InstanceSystems.Add(xs);
                n_sys_target tar = GetNMTarget();
                if (tar == null)
                {
                    tar = new n_sys_target(n_sys.ContextDefault.xSys);
                    tar.the_n_sys_uid = "";
                    tar.system_name = "NewMethod";
                }
                tar.AbsorbHandle(h);
                tar.ISave();
            }
            else
            {
                if (h.HandleType == StructureType.DatabaseStructure)  //update it
                {
                    if (h.xData.CanConnect())
                    {
                        n_sys nms = (n_sys)n_sys.AllSystems.GetByName("NewMethod");
                        if (nms != null)
                        {
                            nStatus.StartPopStatus();
                            nms.UpdateDataStructure(n_sys.ContextDefault, h.xData, false, false);
                            nStatus.StopPopStatus();
                        }
                    }
                }
            }

            xs.xStructure.InitFromHandleAsync(h, t);

            if (xs.system_name == "NewMethod" && NewMethodInterface.Program.NewMethodSys == null)
                NewMethodInterface.Program.NewMethodSys = xs;
        }

        n_sys_target GetNMTarget()
        {
            return (n_sys_target)n_sys.ContextDefault.xSys.QtO("n_sys_target", "select * from n_sys_target where the_n_sys_uid = ''");
        }

        public SysLine GetLineBySystem(n_sys s)
        {
            foreach(SysLine l in SystemLines)
            {
                if (l.TheSys == s)
                    return l;
            }
            return null;
        }

        private void lblLastNM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            n_sys_target t = GetNMTarget();
            if (t == null)
                return;

            AddSystemByHandle(t.GetAsHandle());
        }
    }
}
