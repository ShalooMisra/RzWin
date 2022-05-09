using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using CoreDevelop;

namespace NewMethod
{
    public partial class nView_n_class : nView, IRefreshable
    {
        n_sys xSys;
        Boolean bSelectFirst = false;
        public n_prop CurrentProp;
        //public n_meth CurrentMeth;
        //public n_par CurrentPar;

        public nView_n_class()
        {
            InitializeComponent();
        }
        //Properties
        public n_class CurrentClass
        {
            get
            {
                return (n_class)base.GetCurrentObject();
            }
        }
        //Public Override Functions
        public override bool CompleteLoad()
        {
            xSys = base.GetCurrentObject().xSys;
            ctl_class_tag.SetValue(CurrentClass.class_tag);
            ctl_plural_tag.SetValue(CurrentClass.plural_tag);
            ctl_is_abstract.SetValue(CurrentClass.is_abstract);
            ctl_class_tag_line.SetValue(CurrentClass.tag_line);
            ctl_plural_line.SetValue(CurrentClass.plural_line);
            ctl_class_vivid.SetValue(CurrentClass.vivid);
            ctl_class_aspect.SetValue(CurrentClass.aspect);
            xIcon.CompleteLoad(CurrentClass);
            gbClass.Text = CurrentClass.class_name;
            chkNeedsUpdate.Checked = CurrentClass.needs_update;

            if (CurrentClass.xSys.xStructure.CurrentType != StructureType.DatabaseStructure)
            {
                gbProp.Enabled = false;
            }

            ShowProps();
            ShowActions();
            ShowRelates();
            Boolean b = base.CompleteLoad();
            ctl_enum_datatype.LoadList(true);

            DoRefresh();

            CurrentClass.xRefresh.Add(this);
            return b;
        }
        public override int GetImageIndex()
        {
            //return nTools.GetIconIndex(NewMethod.Enums.IconType.GuidedClass);
            return 0;
        }
        public override String GetCaption()
        {
            return CurrentClass.class_name;
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
            lv.RefreshFromCollection();
            lvInheritFrom.RefreshFromCollection();
            lvDerivedBy.RefreshFromCollection();
            lstReferencing.RefreshFromCollection();
            lstReferencedBy.RefreshFromCollection();
        }

        //Public Functions
        public void DoResize()
        {
            try
            {
                //Properties Tab
                ts.Width = this.ClientRectangle.Width - ts.Left;
                ts.Height = this.ClientRectangle.Height - ts.Top;
                lv.Top = 2;
                lv.Height = (tabPage1.ClientRectangle.Height - lv.Top) - 2;
                lv.Width = (tabPage1.ClientRectangle.Width - lv.Left) - 2;
                lv.DoResize();
                //Methods Tab
                gbMethod.Top = 0;
                gbMethod.Left = (tabPage2.ClientRectangle.Width - gbMethod.Width) - 2;
                gbMethod.Height = (tabPage2.ClientRectangle.Height - gbMethod.Top) - 2;
                lvMeths.Top = 2;
                lvMeths.Left = 2;
                lvMeths.Width = (gbMethod.Left - lvMeths.Left) - 3;
                cmdNewMethod.Width = lvMeths.Width;
                cmdNewMethod.Left = 2;
                cmdNewMethod.Top = (tabPage2.ClientRectangle.Height - cmdNewMethod.Height) - 2;
                lvMeths.Height = (cmdNewMethod.Top - lvMeths.Top) - 2;
                lvMeths.DoResize();
                p_methtop.Top = 10;
                p_methtop.Left = 0;
                p_methbottom.Left = 0;
                p_methbottom.Top = (gbMethod.Height - p_methbottom.Height) - 2;
                lvPars.Top = p_methtop.Bottom + 2;
                lvPars.Height = (p_methbottom.Top - lvPars.Top) - 2;
                lvPars.DoResize();
                //explanation
                ctl_explanation.Left = 2;
                ctl_explanation.Top = 0;
                ctl_explanation.Width = xIcon.Width;
                ctl_explanation.Height = (cmdSaveClass.Top - ctl_explanation.Top) - 2;
                //Actions
                lvActions.Top = 2;
                lvActions.Left = 2;
                lvActions.Width = (pageActions.ClientRectangle.Width - 4);
                lvActions.Height = (pageActions.ClientRectangle.Height - 4);
                lvActions.DoResize();

                lvInheritFrom.Left = 0;
                lvInheritFrom.Top = 0;
                lvInheritFrom.Height = pageRelationships.ClientRectangle.Height / 2;
                lvInheritFrom.Width = pageRelationships.ClientRectangle.Width / 2;

                lvDerivedBy.Left = 0;
                lvDerivedBy.Top = lvInheritFrom.Bottom;
                lvDerivedBy.Width = lvInheritFrom.Width;
                lvDerivedBy.Height = lvInheritFrom.Height;

                lstReferencedBy.Left = lvInheritFrom.Right;
                lstReferencedBy.Top = 0;
                lstReferencedBy.Width = lvInheritFrom.Width;
                lstReferencedBy.Height = lvInheritFrom.Height;

                lstReferencing.Left = lvInheritFrom.Right;
                lstReferencing.Top = lstReferencedBy.Bottom;
                lstReferencing.Width = lvInheritFrom.Width;
                lstReferencing.Height = lvInheritFrom.Height;

            }
            catch (Exception)
            { }
        }

        public void SaveClass()
        {
            CurrentClass.class_tag = ctl_class_tag.GetValue_String();
            CurrentClass.plural_tag = ctl_plural_tag.GetValue_String();
            CurrentClass.is_abstract = ctl_is_abstract.GetValue_Boolean();
            CurrentClass.tag_line = ctl_class_tag_line.GetValue_String();
            CurrentClass.plural_line = ctl_plural_line.GetValue_String();
            CurrentClass.vivid = ctl_class_vivid.GetValue_Integer();
            CurrentClass.aspect = ctl_class_aspect.GetValue_String();
            CurrentClass.ISave();
        }
        public void SaveProp()
        {
            String strName = CurrentProp.name;
            int t = CurrentProp.property_type;
            int l = CurrentProp.property_length;
            if (strName.ToLower().StartsWith("hold_temp_") && !ctl_name.GetValue_String().ToLower().StartsWith("hold_temp_"))
                CurrentClass.RemoveProp(CurrentProp, false);
            CurrentProp.GrabFormValues(gbProp, null);
            CurrentProp.property_use = nData.ConvertUseType(ctlproperty_use.GetValue_String());
            CurrentProp.choice_type = Enums.ConvertEnum.ConvertChoiceType(cboChoiceType.Text);
            CurrentProp.tag_line = ctl_tag_line.GetValue_String();
            CurrentProp.ISave();
            if (!Tools.Strings.StrCmp(strName, CurrentProp.name))
                CurrentClass.ReAbsorbProperty(CurrentProp);
            lv.RefreshFromCollection();
        }

        //Private Functions

        void ShowProps()
        {
            lv.BuildTemplate("n_prop", "name|property_tag|property_order");
            lv.CurrentSortedCollection = CurrentClass.Props.AllInOrder;
            bSelectFirst = true;
        }

        void ShowActions()
        {
            lvActions.ShowTemplate("all_actions", "n_action", true);
            lvActions.CurrentCollection = CurrentClass.Actions.AllByID;
            lvActions.RefreshFromCollection();
        }

        void ShowRelates()
        {
            lvInheritFrom.BuildTemplate("n_relate", "name|left_class_name");
            lvInheritFrom.CurrentCollection = CurrentClass.BaseClassRelates.AllByID;
            
            lvDerivedBy.BuildTemplate("n_relate", "name|right_class_name");
            lvDerivedBy.CurrentCollection = CurrentClass.DerivedClassRelates.AllByID;
            
            lstReferencing.BuildTemplate("n_relate", "name|left_class_name");
            lstReferencing.CurrentCollection = CurrentClass.ParentRelates.AllByID;
            
            lstReferencedBy.BuildTemplate("n_relate", "name|right_class_name");
            lstReferencedBy.CurrentCollection = CurrentClass.ChildRelates.AllByID;
            
        }

        private Dictionary<String, nObject> ConvertToDictionary_nObject(SortedList sl)
        {
            Dictionary<String, nObject> d = new Dictionary<String, nObject>();
            foreach (DictionaryEntry e in sl)
            {
                try
                {
                    n_prop p = (n_prop)e.Value;
                    d.Add(p.unique_id, p);
                }
                catch (Exception)
                { continue; }
            }
            return d;
        }
        private Dictionary<String, nObject> ConvertToDictionary_nObject(ArrayList a)
        {
            Dictionary<String, nObject> d = new Dictionary<String, nObject>();
            foreach (nObject o in a)
            {
                try
                {
                    d.Add(o.unique_id, o);
                }
                catch (Exception)
                { continue; }
            }
            return d;
        }
        private void AddBlankProp(String strName, Enums.DataType t, int len, Enums.DataUse u)
        {
            n_prop p = new n_prop(GetCurrentObject().xSys);
            p.name = strName;
            p.property_tag = nTools.NiceFormat(p.name);
            p.property_type = (Int32)t;
            p.property_use = (Int32)u;
            p.property_length = len;
            CurrentClass.AbsorbNewProperty(p, false);
            lv.RefreshFromCollection();
            CurrentProp = p;
            ShowProp();
        }
        private void ShowProp()
        {
            ClearPropFields();
            if (CurrentProp == null)
                return;
            CurrentProp.LoadFormValues(gbProp, null);
            ctlproperty_type.SetValue(nData.ConvertDataType(CurrentProp.property_type));
            ctlproperty_use.SetValue(nData.ConvertUseType(CurrentProp.property_use));
            cboChoiceType.Text = Enums.ConvertEnum.ConvertChoiceType(CurrentProp.choice_type);
            SetChoiceType();
            ctl_tag_line.SetValue(CurrentProp.tag_line);
            ctlPropIcon.CompleteLoad(CurrentProp);
        }
        private void SetChoiceType()
        {
            //SaveProp();
            switch (CurrentProp.choice_type)
            {
                case (Int32)Enums.ChoiceType.None:
                    lblChoice.Visible = false;
                    lblNewChoice.Visible = false;
                    break;
                default:

                    lblChoice.Visible = true;
                    lblNewChoice.Visible = true;

                    //if it has a choice id, show the related choice
                    if (CurrentProp.xChoices != null)
                    {
                        lblChoice.Visible = true;
                        lblChoice.Text = "Edit " + CurrentProp.xChoices.name;
                    }
                    else
                    {
                        lblChoice.Visible = false;
                    }
                    break;
            }
        }
        private void DeleteSelected()
        {
            ArrayList l = lv.GetSelectedObjects();
            foreach (n_prop p in l)
            {
                CurrentClass.RemoveProp(p, true);
            }
        }
        private void CopySelected()
        {
            n_sys.Clipboard = lv.GetSelectedObjects();
        }
        private void PasteProps()
        {
            if (n_sys.Clipboard == null)
                return;

            n_prop q;
            foreach (n_prop p in n_sys.Clipboard)
            {
                q = (n_prop)p.Clone();
                q.unique_id = "";
                CurrentClass.AbsorbNewProperty(q, false);
            }

            ShowProps();
        }
        private void ShowMeth()
        {
            //CurrentMeth.LoadFormValues(this);
            //ctlaccess_specifier.SetValue(Enums.ConvertEnum.ConvertAccessSpecifier(CurrentMeth.access_specifier));
            //ctl_methname.SetValue(CurrentMeth.name);
            //if (CurrentPar == null)
            //{
            //    n_par xPar = new n_par(xSys);
            //    xPar.LoadFormValues(this);
            //    ctl_param_data_type.SetValue("");
            //    ctl_param_name.SetValue("");
            //}
            //else
            //{
            //    CurrentPar.LoadFormValues(this);
            //    ctl_param_data_type.SetValue(CurrentPar.data_type);
            //    ctl_param_name.SetValue(CurrentPar.name);
            //}
            //ShowPars();
        }
        private void SaveMeth()
        {
            //if (CurrentMeth == null)
            //    return;
            //CurrentMeth.GrabFormValues(this);
            //CurrentMeth.name = ctl_methname.GetValue_String();
            //CurrentMeth.access_specifier = Enums.ConvertEnum.ConvertAccessSpecifier(ctlaccess_specifier.GetValue_String());
            //CurrentMeth.ISave();
            //if (CurrentPar != null)
            //{
            //    CurrentPar.GrabFormValues(this);
            //    CurrentPar.data_type = ctl_param_data_type.GetValue_String();
            //    CurrentPar.name = ctl_param_name.GetValue_String();  
            //    CurrentPar.ISave();
            //}
            //ShowMeths();
            //ShowMeth();
        }
        private void ClearPropFields()
        {
            n_prop p = new n_prop(xSys);
            p.LoadFormValues(gbProp, null);
        }
        private void AddRelationship()
        {
            mnuClass.Show(System.Windows.Forms.Cursor.Position);
        }
        private void AddNewRelate(bool parent, bool newclass, Enums.RelationshipType t)
        {
            n_class c_start = CurrentClass;
            n_class c_end;
            if (c_start == null)
                return;
            string sd;
            switch (t)
            {
                case NewMethod.Enums.RelationshipType.Inherit:
                    sd = "inherit";
                    break;
                case NewMethod.Enums.RelationshipType.Subscribe:
                    sd = "subscribe";
                    break;
                default:
                    sd = "the";
                    break;
            }
            String strName = "";
            if (t == NewMethod.Enums.RelationshipType.Subscribe || t == NewMethod.Enums.RelationshipType.Inherit)
                strName = sd;
            else
                strName = nStatus.InputMessageBox("What is the name of this relate?", sd, "Name?", this);
            if (!Tools.Strings.StrExt(strName))
                return;
            if (t == NewMethod.Enums.RelationshipType.Self)
            {
                c_end = c_start;
                t = NewMethod.Enums.RelationshipType.ParentChild;
            }
            else
            {
                if (newclass)
                    c_end = MakeNewClass(c_start.xSys, false);
                else
                    c_end = ChooseAClass(c_start.xSys);
            }
            if (c_end == null)
                return;

            //ok, this has to save the relationship in terms of the system that is highest, since the lower system
            //can still be completely loaded and functional if it is supporting a different system that doesn't have the relate
            //there can't be circular references, so we can just:

            n_sys highest = null;
            
            if( c_start.xSys == c_end.xSys )
                highest = c_start.xSys;
            else if( c_start.xSys.HasAReferenceTo(c_end.xSys) )
                highest = c_start.xSys;
            else
                highest = c_end.xSys;

            bool order;
            if (t != NewMethod.Enums.RelationshipType.ParentChild)
                order = false;
            else
                order = (System.Windows.Forms.MessageBox.Show("Will the child have an order?", "Order?", MessageBoxButtons.YesNo) == DialogResult.Yes);
            
            if (parent)  //c_start is the child
                highest.RelateTwoClasses(c_end, c_start, strName, order, t);
            else
                highest.RelateTwoClasses(c_start, c_end, strName, order, t);
            if (newclass)
                xSys.ShowObject(c_end, n_sys.SoftStructureForm);

            if (t == NewMethod.Enums.RelationshipType.Subscribe)
                ShowSubscription(c_start, c_end);

            DoRefresh();
        }

        private void ShowSubscription(n_class subscriber, n_class base_class)
        {
            SubscriptionDesigner s = new SubscriptionDesigner();
            n_sys.SoftStructureForm.TabShow(s, subscriber.class_name + " Subscribing To " + base_class.class_name);
            s.CompleteLoad(subscriber, base_class);
        }

        private n_class MakeNewClass(n_sys sys, bool is_abstract)
        {
            n_class c = nGuide.MakeNewClass(sys, "new_class", is_abstract);
            if (c == null)
                return null;
            xSys.ShowObject(c, n_sys.SoftStructureForm);
            return c;
        }
        private n_class ChooseAClass(n_sys s)
        {
            frmChooseClass xForm = new frmChooseClass();
            xForm.xSys = s;
            xForm.LoadClasses();
            xForm.ShowDialog(this.ParentForm);
            return xForm.SelectedClass;
        }
        //Menus
        private void mnuDeleteProp_Click(object sender, EventArgs e)
        {
            if (!nStatus.AreYouSure("delete thes selected properties"))
                return;

            DeleteSelected();

            ShowProps();
        }
        private void mnuCut_Click(object sender, EventArgs e)
        {
            CopySelected();
            DeleteSelected();
        }
        private void mnuPaste_Click(object sender, EventArgs e)
        {
            PasteProps();
        }
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            CopySelected();
        }
        private void mnuAddParentRelate_New_Click(object sender, EventArgs e)
        {
            AddNewRelate(true, true, NewMethod.Enums.RelationshipType.ParentChild);
        }
        private void mnuAddParentRelate_Existing_Click(object sender, EventArgs e)
        {
            AddNewRelate(true, false, NewMethod.Enums.RelationshipType.ParentChild);
        }
        private void mnuAddChildRelate_New_Click(object sender, EventArgs e)
        {
            AddNewRelate(false, true, NewMethod.Enums.RelationshipType.ParentChild);
        }
        private void mnuAddChildRelate_Existing_Click(object sender, EventArgs e)
        {
            AddNewRelate(false, false, NewMethod.Enums.RelationshipType.ParentChild);
        }
        private void mnuAddSelfRelate_Click(object sender, EventArgs e)
        {
            AddNewRelate(true, false, NewMethod.Enums.RelationshipType.Self);
        }
        private void mnuDerivedClass_Click(object sender, EventArgs e)
        {
            AddNewRelate(false, true, NewMethod.Enums.RelationshipType.Inherit);
        }
        private void mnuBaseClass_Click(object sender, EventArgs e)
        {
            AddNewRelate(true, false, NewMethod.Enums.RelationshipType.Inherit);
        }
        private void mnuSubscribe_Click(object sender, EventArgs e)
        {
            AddNewRelate(true, false, NewMethod.Enums.RelationshipType.Subscribe);
        }
        //Buttons
        private void cmdString_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_string", Enums.DataType.String, 255, 0);
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (GetCurrentObject() != null)
            {
                SaveClass();

                if (CurrentProp != null)
                {
                    SaveProp();
                }
            }
        }
        private void cmdLong_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_long", Enums.DataType.Long, 255, 0);
        }
        private void cmdInteger_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_integer", Enums.DataType.Integer, 255, 0);
        }
        private void cmdMemo_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_memo", Enums.DataType.Memo, 255, 0);
        }
        private void cmdList_Click(object sender, EventArgs e)
        {
            //this should just key off of the is_list and base_n_list_uid fields
            //AddBlankProp("new_string", Enums.DataType.String, 255);
        }
        private void cmdDate_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_date", Enums.DataType.Date, 255, 0);
        }
        private void cmdBoolean_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_boolean", Enums.DataType.Boolean, 255, 0);
        }
        private void cmdFloat_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_float", Enums.DataType.Float, 255, 0);
        }
        private void cmdURL_Click(object sender, EventArgs e)
        {
            AddBlankProp("url", Enums.DataType.String, 255, Enums.DataUse.Url);
        }
        private void cmdChangeOrder_Click(object sender, EventArgs e)
        {
            if (CurrentProp == null)
                return;

            String s = nStatus.InputMessageBox("New Order?", "-1", "New Order", this);

            Int32 i;
            try
            {
                i = Convert.ToInt32(s);
                CurrentProp.property_order = i;
                CurrentProp.ISave();
                CurrentClass.ReAbsorbProperty(CurrentProp);
                ShowProps();
            }
            catch
            { }
        }
        private void cmdNewMethod_Click(object sender, EventArgs e)
        {
            //CurrentClass.AddNewMeth("temp_new_method", "");
            //ShowMeths();
        }
        private void cmdEmail_Click(object sender, EventArgs e)
        {
            AddBlankProp("email", Enums.DataType.String, 255, Enums.DataUse.Email);
        }
        private void cmdRelates_Click(object sender, EventArgs e)
        {
            AddRelationship();
        }
        private void cmdReOrder_Click(object sender, EventArgs e)
        {
            if (CurrentProp == null)
                return;

            Int32 i;
            try
            {
                i = CurrentClass.GetNextPropOrder(false);
                CurrentProp.property_order = i;
                CurrentProp.ISave();
                CurrentClass.ReAbsorbProperty(CurrentProp);
                ShowProps();
            }
            catch (Exception ex)
            { }
        }
        private void cmdUniqueID_Click(object sender, EventArgs e)
        {
            try
            {
                n_class c = (n_class)GetCurrentObject();
                n_prop p = c.CreateUniqueID();
                if (p != null)
                {
                    CurrentProp = p;
                    ShowProps();
                    ShowProp();
                }
            }
            catch (Exception)
            { }
        }
        private void cmdSaveClass_Click(object sender, EventArgs e)
        {
            SaveClass();
        }
        private void cmdBlob_Click(object sender, EventArgs e)
        {
            AddBlankProp("hold_temp_blob", Enums.DataType.Blob, 255, 0);
        }
        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveMeth();
        }
        private void cmdNewPar_Click(object sender, EventArgs e)
        {
            //if (CurrentMeth == null)
            //    return;

            //n_par p = CurrentMeth.AddNew_the_n_par();
            //p.name = "temp_new_par";
            //p.ISave();
            //CurrentMeth.AbsorbPar(p);
            //CurrentPar = p;
            //ShowMeth();
        }
        //Control Events
        private void nView_n_class_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void cboChoiceType_TextChanged(object sender, EventArgs e)
        {
            SetChoiceType();
        }
        private void cboChoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetChoiceType();
        }
        private void cboChoiceType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SaveProp();
            ShowProp();
        }
        private void lblSelectChoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            n_choices c = nStatus.ChooseAChoice(GetCurrentObject().xSys);
            if (c == null)
                return;
            SaveProp();
            CurrentProp.AbsorbChoicesObject(c);
            ShowProp();
        }
        private void lblChoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentClass.xSys.ThrowObjectUp(CurrentProp.xChoices);
        }
        private void lblNewChoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String strDefault = "";
            if (CurrentProp != null)
                strDefault = CurrentProp.name;
            String strChoice = nStatus.InputMessageBox("New choice name?", strDefault, "New Choice Name", this.ParentForm);
            if (!Tools.Strings.StrExt(strChoice))
                return;
            n_choices c = CurrentClass.xSys.GetChoicesByName(strChoice);
            if (c != null)
            {
                if (nStatus.AskUser_YesNo("The choice list '" + strChoice + "' already exists.  Do you want to use it?"))
                {
                    SaveProp();
                    CurrentProp.AbsorbChoicesObject(c);
                    ShowProp();
                }
                return;
            }
            c = new n_choices(CurrentClass.xSys);
            c.name = strChoice;
            c.ISave();
            SaveProp();
            CurrentProp.AbsorbChoicesObject(c);
            ShowProp();
            CurrentClass.xSys.ThrowObjectUp(c);
        }
        private void lvPars_ObjectClicked(object sender, ObjectClickArgs args)
        {
            //n_par p = (n_par)lvPars.GetSelectedObject();
            //if (p == null)
            //    return;
            //CurrentPar = p;
            //ShowMeth();
        }
        private void lvMeths_ObjectClicked(object sender, ObjectClickArgs args)
        {
            //n_meth m = (n_meth)lvMeths.GetSelectedObject();
            //if (m == null)
            //    return;
            //CurrentMeth = m;
            //CurrentPar = null;
            //ShowMeth();
        }
        private void lvActions_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            n_action a = CurrentClass.GetNewAction();
            ShowActions();
            //CurrentClass.xSys.ThrowObjectUp(a);
            n_sys.SoftStructureForm.ShowObject(a);
        }
        private void lv_ObjectClicked(object sender, ObjectClickArgs args)
        {
            n_prop p = (n_prop)lv.GetSelectedObject();
            if (p == null)
                return;
            CurrentProp = p;
            ShowProp();
        }
        private void lv_FinishedFill(object sender)
        {
            if (!bSelectFirst)
                return;
            bSelectFirst = false;
            lv.SelectFirst(true);
        }
        private void ctlproperty_type_SelectionChanged(GenericEvent e)
        {
            int len = 0;
            ctl_is_enum.Visible = false;
            switch (ctlproperty_type.GetValue_String().ToLower())
            {
                case "string":
                    len = 255;
                    break;
                case "memo":
                    len = 16;
                    break;
                case "float":
                    len = 8;
                    break;
                case "integer":
                    ctl_is_enum.Visible = true;
                    len = 2;
                    break;
                case "long":
                    len = 4;
                    break;
                case "date":
                    len = 8;
                    break;
                case "boolean":
                    len = 1;
                    break;
            }
            if (len > 0)
                ctl_property_length.SetValue(len.ToString());
        }
        private void ctl_is_enum_CheckChanged(object sender)
        {
            ctl_enum_datatype.Enabled = ctl_is_enum.GetValue_Boolean();
        }
        private void ctl_name_zz_GotKeyUp(object sender, KeyEventArgs e)
        {
            ctl_property_tag.SetValue(nTools.NiceFormat(ctl_name.GetValue_String()));
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
        }

        private void lvInheritFrom_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            AddNewRelate(true, false, NewMethod.Enums.RelationshipType.Inherit);
        }

        private void lstReferencing_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            AddNewRelate(true, false, NewMethod.Enums.RelationshipType.ParentChild);
        }

        private void lblWriteCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nLanguage_CSharp l = new nLanguage_CSharp();
            if (l.RunAlternateCode(CurrentClass))
            {
                CurrentClass.ClearNeedsUpdate();
                nStatus.TellUser("Done.");
            }
            else
            {
                nStatus.TellUser("Error.");
            }
        }

        private void lstReferencing_AboutToDelete(object sender, ActionArgs args)
        {
            args.Handled = true;
            n_relate r = (n_relate)args.xObject;
            r.CompleteDelete();
            
        }

        private void gbProp_Enter(object sender, EventArgs e)
        {

        }

        private void ctl_prop_aspect_Load(object sender, EventArgs e)
        {

        }

        private void lvActions_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            n_sys.SoftStructureForm.Show(args);
        }

        private void lblCodeCore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nLanguage_CSharp l = new nLanguage_CSharp();
            if (l.RunCoreCode(CurrentClass))
            {
                //CurrentClass.ClearNeedsUpdate();
                //nStatus.TellUser("Done.");
            }
            else
            {
                nStatus.TellUser("Error.");
            }
        }

        private void lblLiveCore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nLanguage_CSharp l = new nLanguage_CSharp();
            BoxClass bc = l.ConvertToCore(CurrentClass);
            Tools.FileSystem.PopText(bc.LiveFileRender());
        }
    }
}

