using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class SystemView : NewMethod.nView, IRefreshable
    {
        n_sys xSys;

        public SystemView()
        {
            InitializeComponent();
        }

        public override void Init()  //ContextNM q
        {
            base.Init();  //q
        }

        public override bool CompleteLoad()
        {
            xSys = (n_sys)GetCurrentObject();
            base.CompleteLoad();
            sysline.CompleteLoad(xSys);

            lstClasses.BuildTemplate("n_class", "class_name|class_tag");
            lstClasses.CurrentSortedCollection = xSys.xStructure.Classes.AllByName;

            lstReferencedBy.BuildTemplate("n_sys", "system_name");
            lstReferencedBy.CurrentSortedCollection = xSys.xStructure.ChildSystems.AllByName;

            lstReferencing.BuildTemplate("n_sys", "system_name");
            lstReferencing.CurrentSortedCollection = xSys.xStructure.ParentSystems.AllByName;
            
            lstClasses.AllowAdd = (xSys.xStructure.CurrentType == StructureType.DatabaseStructure);
            lblStructureData.Visible = (xSys.xStructure.CurrentType == StructureType.DatabaseStructure);
            lblXml.Visible = (xSys.xStructure.CurrentType == StructureType.DatabaseStructure);
            lblObliterate.Visible = (xSys.xStructure.CurrentType == StructureType.DatabaseStructure);


            DoRefresh();
            xSys.xStructure.xRefresh.Add(this);

            return true;
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
            lstClasses.RefreshFromCollection();
            lstReferencedBy.RefreshFromCollection();
            lstReferencing.RefreshFromCollection();
        }

        private void lstClasses_AboutToThrow(object sender, ShowArgs args)
        {
            n_sys.ContextDefault.Show(args);
            args.Handled = true;
        }

        private void lstClasses_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            AddClass();
        }

        void AddClass()
        {
            int i = 1;
            while (xSys.HasClass("test_class_" + i.ToString()))
            {
                i++;
            }

            String strClassName = nStatus.InputMessageBox("Class Name", "test_class_" + i.ToString(), "Class Name", this.ParentForm);
            if (!Tools.Strings.StrExt(strClassName))
                return;

            n_class c = xSys.xStructure.TryAddClass(strClassName, nTools.NiceFormat(strClassName));
            if (c == null)
                return;

            xSys.ShowObject(c, n_sys.SoftStructureForm);
            lstClasses.RefreshFromCollection();
        }

        private void lblStructureData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            n_sys xs = xSys.xStructure.GetSystem("NewMethod");
            xs.UpdateDataStructure(n_sys.ContextDefault, xSys.xData, false, false);
        }

        private void lblSystemCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            n_sys_NMI.UpdateMyAutoCode(xSys);
        }

        private void lstClasses_AboutToDelete(object sender, ActArgs args)
        {
            args.Handled = true;
            n_class c = (n_class)args.xObject;
            if (!nStatus.AreYouSure("delete " + c.GetFriendlyName()))
                return;

            c.CompleteDelete();
            xSys.xStructure.xRefresh.Refresh();
        }

        private void lblXml_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (xSys.WriteUpdateFile())
                nStatus.TellUser("Done.");
            else
                nStatus.TellUser("Xml Create Error");
        }

        private void lblImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if( xSys.xStructure.CurrentType != StructureType.DatabaseStructure )
            {
                nStatus.TellUser("Imports can only be done on data-connected systems.");
                return;
            }

            n_data_target t = (n_data_target)frmChooseObject.ChooseFromSQL(this.ParentForm, n_sys.ContextDefault.xSys, "n_data_target", "", "name");
            if (t == null)
                return;

            nData d = new nData(t);
            String s = "";
            if( !d.CanConnect(ref s))
            {
                nStatus.TellUser("Can't connect: " + s);
                return;
            }

            s = d.GetScalar_String("select system_name from n_sys");
            if (!Tools.Strings.StrExt(s))
            {
                nStatus.TellUser("There don't appear to be any systems at this target.");
                return;
            }

            if (!nStatus.AreYouSure("import system '" + s + "'"))
                return;

            DataTable dt = d.GetDataTable("select * from n_sys where system_name = '" + d.SyntaxFilter(s) + "'");
            n_sys sys = new n_sys(xSys);
            sys.ICreate(xSys, dt.Rows[0]);
            sys.ISave_PreserveID(TheContext);

            sys.xData = xSys.xData;

            sys.ImportStructure(TheContext, d);

            n_sys_link l = new n_sys_link(xSys);
            l.left_n_sys_uid = xSys.unique_id;
            l.left_system_name = xSys.system_name;
            l.right_n_sys_uid = sys.unique_id;
            l.right_system_name = sys.system_name;
            l.ISave();

            nStatus.TellUser("Done.");
        }

        private void lblImportHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (xSys.xStructure.CurrentType != StructureType.DatabaseStructure)
            {
                nStatus.TellUser("Imports can only be done on data-connected systems.");
                return;
            }

            n_data_target t = (n_data_target)frmChooseObject.ChooseFromSQL(this.ParentForm, n_sys.ContextDefault.xSys, "n_data_target", "", "name");
            if (t == null)
                return;

            nData d = new nData(t);
            String s = "";
            if (!d.CanConnect(ref s))
            {
                nStatus.TellUser("Can't connect: " + s);
                return;
            }

            s = d.GetScalar_String("select system_name from n_sys");
            if (!Tools.Strings.StrExt(s))
            {
                nStatus.TellUser("There don't appear to be any systems at this target.");
                return;
            }

            if (!nStatus.AreYouSure("import the structure from system '" + s + "' into '" + xSys.system_name + "'"))
                return;

            xSys.ImportStructure(TheContext, d);

            nStatus.TellUser("Done.");
        }

        private void lblObliterate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!nStatus.AreYouSure("obliterate the entire " + xSys.system_name + " system"))
                return;

            if (!nStatus.AreYouSure("completely obliterate the entire " + xSys.system_name + " system for sure"))
                return;

            xSys.ObliterateStructure();
            n_sys.RemoveSystem(xSys);
            SendCloseRequest();
        }

        private void lblWriteObjectCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (!nStatus.AreYouSure("update all of the code for classes in " + xSys.system_name))
                return;

            nLanguage_CSharp l = new nLanguage_CSharp();

            nStatus.StartPopStatus("Writing code...");

            foreach (n_class c in xSys.xStructure.Classes.All)
            {

                if (l.RunAlternateCode(c))
                {
                    nStatus.SetStatus("Writing " + c.class_name);
                    c.ClearNeedsUpdate();
                }
                else
                {
                    nStatus.TellUser("Error on " + c.class_name + ".");
                }
            }

            nStatus.SetStatus("Done.");
            nStatus.StopPopStatus(true);
        }

        private void SystemView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                lstClasses.Height = this.ClientRectangle.Height - lstClasses.Top;
            }
            catch { }
        }

        private void lblPasteClasses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (n_class.ClassClipboard == null)
            {
                n_sys.ContextDefault.TheLeader.Error("No copied classes");
                return;
            }

            if (n_class.ClassClipboard.Count == 0)
            {
                n_sys.ContextDefault.TheLeader.Error("No copied classes");
                return;
            }

            foreach (n_class c in n_class.ClassClipboard)
            {
                n_class newclass = xSys.xStructure.TryAddClass(c.class_name, nTools.NiceFormat(c.class_name));
                if (newclass != null)
                {
                    newclass.class_tag = c.class_tag;
                    foreach (n_prop p in c.Props.All)
                    {
                        if (!newclass.Props.AllByName.ContainsKey(p.name.ToLower()))
                        {
                            n_prop newprop = (n_prop)p.Clone();
                            newprop.unique_id = "";
                            newclass.AbsorbNewProperty(newprop, false);
                        }
                    }

                    newclass.IUpdate();
                }
            }
            lstClasses.RefreshFromCollection();
        }
    }
}

