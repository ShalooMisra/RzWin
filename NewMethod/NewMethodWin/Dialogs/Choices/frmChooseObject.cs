using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseObject : ToolsWin.Dialogs.OKCancel
    {
        public static nObject ChooseFromCollection(ArrayList list)
        {
            List<Object> objects = new List<object>();
            foreach (Object x in list)
            {
                objects.Add(x);
            }
            return ChooseFromCollection(objects);
        }
        
        public static nObject ChooseFromCollection(List<object> objects)
        {
            return ChooseFromCollection(objects, "Choose");
        }

        public static nObject ChooseFromCollection(List<object> objects, String caption)
        {
            frmChooseObject xForm = new frmChooseObject();
            xForm.Objects = objects;
            xForm.LoadObjects();
            xForm.Text = caption;
            xForm.ShowDialog();            
            return xForm.SelectedObject;
        }

        public static Object ChooseFromPlainCollection(List<object> objects, String caption)
        {
            frmChooseObject xForm = new frmChooseObject();
            xForm.Objects = objects;
            xForm.LoadPlainObjects();
            xForm.Text = caption;
            xForm.ShowDialog();
            return xForm.SelectedPlainObject;
        }

        public static nObject ChooseFromSQL(String strClass, String strWhere, String strOrder)
        {
            String strSQL = "select * from " + strClass;

            if (Tools.Strings.StrExt(strWhere))
                strSQL += " where " + strWhere;

            if (Tools.Strings.StrExt(strOrder))
                strSQL += " order by " + strOrder;

            ArrayList a = NMWin.ContextDefault.QtC(strClass, strSQL);
            List<object> objects = new List<object>();
            foreach (Object x in a)
            {
                objects.Add(a);
            }
            return ChooseFromCollection(objects);
        }

        public static ArrayList ChooseFromCollectionMultiple(Dictionary<String, nObject> objects, String strCaption)
        {
            frmChooseObject xForm = new frmChooseObject();
            xForm.Objects = new List<object>();
            foreach(KeyValuePair<String, nObject> x in objects)
            {
                xForm.Objects.Add(x.Value);
            }
            xForm.LoadObjects(true);
            xForm.ShowDialog();
            return xForm.SelectedObjects;
        }

        public nObject SelectedObject;
        public Object SelectedPlainObject;
        public ArrayList SelectedObjects;
        public List<Object> Objects;
        public bool MultipleMode = false;
        public bool PlainMode = false;

        public frmChooseObject()
        {
            InitializeComponent();
        }

        public void LoadObjects()
        {
            LoadObjects(false);
        }
        public void LoadObjects(bool AllowMultiple)
        {            
            lst.Items.Clear();
            lst.MultiSelect = AllowMultiple;
            MultipleMode = AllowMultiple;

            foreach (nObject o in Objects)
            {
                ListViewItem l = lst.Items.Add(o.ToString());
                l.Tag = o;
            }
            DoResize();
        }

        public void LoadPlainObjects()
        {
            PlainMode = true;
            lst.Items.Clear();
            lst.MultiSelect = false;
            MultipleMode = false;

            foreach (Object o in Objects)
            {
                ListViewItem l = lst.Items.Add(o.ToString());
                l.Tag = o;
            }
            DoResize();
        }

        public override void OK()
        {
            try
            {
                if (MultipleMode)
                {
                    SelectedObjects = new ArrayList();
                    foreach (ListViewItem i in lst.SelectedItems)
                    {
                        if (i == null)
                            return;

                        nObject o = (nObject)i.Tag;
                        if (o != null)
                            SelectedObjects.Add(o);
                    }
                }
                else
                {
                    ListViewItem i = lst.SelectedItems[0];
                    if (i == null)
                        return;

                    if (PlainMode)
                    {
                        Object o = i.Tag;
                        if (o == null)
                            return;

                        SelectedPlainObject = o;
                    }
                    else
                    {
                        nObject o = (nObject)i.Tag;
                        if (o == null)
                            return;

                        SelectedObject = o;
                    }
                }
                base.OK();
            }
            catch (Exception)
            {
                NMWin.Leader.Tell("Please choose an item before continuing.");
            }
        }

        public override void Cancel()
        {
            SelectedObject = null;
            base.Cancel();
        }

        public override void  DoResize()
        {
 	         base.DoResize();

             try
             {
                 lst.Columns[0].Width = lst.Width;
             }
             catch { }
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }
    }
}