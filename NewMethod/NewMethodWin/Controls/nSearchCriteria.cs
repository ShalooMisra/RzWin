using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools.Database;
using Core;

namespace NewMethod
{
    public partial class nSearchCriteria : UserControl
    {
        public CoreVarValAttribute CurrentProp;
        public nEdit CurrentEdit;

        public eCriteriaType CriteriaType
        {
            get
            {
                if (optEquals.Checked)
                    return eCriteriaType.Equals;
                if (optLike.Checked)
                {
                    if (CurrentProp.TheFieldType != Tools.Database.FieldType.String)
                        return eCriteriaType.Equals;
                    return eCriteriaType.Like;
                }
                if (optMoreThan.Checked)
                    return eCriteriaType.GreaterThan;
                if (optLessThan.Checked)
                    return eCriteriaType.LessThan;
                return eCriteriaType.Equals;
            }
        }
        public nSearchCriteria()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(CoreVarValAttribute p)
        {
            if (p == null)
                return;
            CurrentProp = p;
            ShowPropEdit();
        }
        public void DoResize()
        {
            try
            {
                this.Width = 320;
                this.Height = 55;
                SetBorder();
            }
            catch (Exception)
            { }
        }
        public String GetWhere()
        {
            try
            {
                String value = "";
                switch (CurrentProp.TheFieldType)
                {
                    case FieldType.String:
                        value = (String)CurrentEdit.GetValue();
                        if (Tools.Strings.StrExt(value))
                            ////KT -Added the if / else below to put a '%' at teh beginning of the search term as well if we're searching description since
                            ////description can have our terms buried in a lot of different word.
                            if (CurrentProp.Name != "description")
                                value = " and " + CurrentProp.Name + " " + GetCriteriaSymbol() + " '" + value + (CriteriaType == eCriteriaType.Like ? "%'" : "'");
                            else
                                value = " and " + CurrentProp.Name + " " + GetCriteriaSymbol() + " '%" + value + (CriteriaType == eCriteriaType.Like ? "%'" : "'");
                        break;
                    case FieldType.Double:  // (Int32)FieldType.Double:
                    case FieldType.Int32:   // (Int32)FieldType.Int32:
                    case FieldType.Int64:   // (Int32)FieldType.Int64:
                        //zero checking doesn't work if you want to search for zeroes
                        if (CurrentEdit.IsBlank)
                            break;
                        Double d = (Double)CurrentEdit.GetValue();
                        value = d.ToString();
                        if (Tools.Strings.StrExt(value))
                            value = " and " + CurrentProp.Name + " " + GetCriteriaSymbol() + " " + value;
                        break;
                    case FieldType.Boolean:  // (Int32)FieldType.Boolean:
                        Boolean b = (Boolean)CurrentEdit.GetValue();
                        value = b.ToString();
                        if (Tools.Strings.StrExt(value))
                            value = " and " + CurrentProp.Name + " " + GetCriteriaSymbol() + " '" + value + "'";
                        break;
                    case FieldType.DateTime:  // (Int32)FieldType.DateTime:
                        DateTime dt = (DateTime)CurrentEdit.GetValue();
                        if (dt == null)
                            break;
                        value = dt.ToString();
                        if (Tools.Strings.StrExt(value))
                            value = " and " + CurrentProp.Name + " " + GetCriteriaSymbol() + " cast('" + value + "', as datetime)";
                        break;
                    default:
                        value = (String)CurrentEdit.GetValue();
                        if (Tools.Strings.StrExt(value))
                            value = " and " + CurrentProp.Name + " " + GetCriteriaSymbol() + " '" + value + "'" + (CriteriaType == eCriteriaType.Like ? "%" : "");
                        break;
                }
                return value;
            }
            catch (Exception)
            { return ""; }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch
            { }
        }
        private void ShowPropEdit()
        {
            if (CurrentProp == null)
                return;
            CurrentEdit = GetPropEdit();
            if (CurrentEdit == null)
                return;
            CurrentEdit.Caption = CurrentProp.Caption;
            this.Controls.Add(CurrentEdit);
            CurrentEdit.Top = 2;
            CurrentEdit.Left = 81;
            CurrentEdit.Width = 205;
            CurrentEdit.Height = 50;
            CurrentEdit.Visible = true;
            CurrentEdit.BringToFront();
            CurrentEdit.DoResize();
        }
        private nEdit GetPropEdit()
        {
            if (CurrentProp == null)
                return null;
            switch (CurrentProp.TheFieldType)
            {
                case FieldType.String:  // (Int32)FieldType.String:
                    return new nEdit_String();
                case FieldType.Double:  // (Int32)FieldType.Double:
                case FieldType.Int32:   // (Int32)FieldType.Int32:
                case FieldType.Int64:   // (Int32)FieldType.Int64:
                    return new nEdit_Number();
                case FieldType.Boolean:   // (Int32)FieldType.Boolean:
                    return new nEdit_Boolean();
                case FieldType.DateTime:   // (Int32)FieldType.DateTime:
                    return new nEdit_Date();
                default:
                    return new nEdit_String();
            }
        }
        private String GetCriteriaSymbol()
        {
            switch (CriteriaType)
            {
                case eCriteriaType.Like:
                    return "like";
                case eCriteriaType.Equals:
                    return "=";
                case eCriteriaType.GreaterThan:
                    return ">";
                case eCriteriaType.LessThan:
                    return "<";
            }
            return "=";
        }
        //Control Events
        private void nSearchCriteria_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        //Enums
    }
    public enum eCriteriaType
    {
        Equals = 0,
        Like = 1,
        GreaterThan = 2,
        LessThan = 3
    }
}
