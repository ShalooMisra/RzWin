using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class CompanyTypeStub : UserControl
    {
        public nObject CurrentObject;
        Enums.ContactType m_type = Enums.ContactType.Unknown;
        public Boolean bAltType = false;
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }

        public CompanyTypeStub()
        {
            InitializeComponent();
        }
        public void DoResize()
        {
            try
            {
                lbl.Top = 3;
                lbl.Left = 3;
                lbl.Height = (this.Height - lbl.Top) - 3;
                lbl.Width = (this.Width - lbl.Left) - 3;
            }
            catch (Exception)
            { }
        }

        public void SetType()
        {
            if (CurrentObject == null)
                return;

            String s = (String)CurrentObject.IGet("abs_type");
            if( !Tools.Strings.StrExt(s) )
                SetType(Enums.ContactType.Unknown, false);
            else if( Tools.Strings.StrCmp(s, "oem") )
                SetType(Enums.ContactType.OEM, false);
            else
                SetType(Enums.ContactType.DIST, false);
        }

        public void SetType(Enums.ContactType type, bool update)
        {
            switch (type)
            {
                case Enums.ContactType.Unknown:
                    this.BackColor = System.Drawing.Color.Gray;
                    lbl.Text = "(oem/dist)";
                    if (update && CurrentObject != null)
                        CurrentObject.ISet("abs_type", "");
                    break;
                case Enums.ContactType.DIST:
                    this.BackColor = System.Drawing.Color.Blue;
                    lbl.Text = "DIST";
                    if (update && CurrentObject != null)
                        CurrentObject.ISet("abs_type", "DIST");
                    break;
                default:
                    this.BackColor = System.Drawing.Color.Green;
                    lbl.Text = "OEM";
                    if (update && CurrentObject != null)
                        CurrentObject.ISet("abs_type", "OEM");
                    break;
            }
            lbl.ForeColor = this.BackColor;
            m_type = type;
        }

        public Enums.ContactType GetType_Contact()
        {
            switch (lbl.Text)
            {
                case "DIST":
                    return Enums.ContactType.DIST;
                case "OEM":
                    return Enums.ContactType.OEM;
                default:
                    return Enums.ContactType.Unknown;
            }
        }

        public void SetType(String type)
        {
            this.BackColor = System.Drawing.Color.Blue;
            lbl.Text = type;
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            Do_lbl_Click();
        }
        private void Do_lbl_Click()
        {
            Do_lbl_Click(RzWin.Form.TheContextNM);
        }
        private void Do_lbl_Click(ContextNM x)
        {
            if (bAltType)
                return;

            //make sure that the change isn't conflicting with an established domain

            //if (CurrentObject != null)
            //{
            //    String sd = nTools.ParseEmailDomain((String)CurrentObject.IGet("primaryemailaddress"));
            //    if (Tools.Strings.StrExt(sd))
            //    {
            //        domain d = domain.GetByName(Rz3App.xSys, sd);
            //        if (d != null)
            //        {
            //            if (d.always_dist || d.always_oem)
            //            {
            //                if (d.always_dist)
            //                    TheContext.TheLeader.TellTemp("The domain " + sd + " is permanently marked as DIST, and contacts within that domain cannot be assigned.");
            //                else
            //                    TheContext.TheLeader.TellTemp("The domain " + sd + " is permanently marked as OEM, and contacts within that domain cannot be assigned.");
            //                return;
            //            }
            //        }
            //    }
            //}

            switch (m_type)
            {
                case Enums.ContactType.Unknown:
                    SetType(Enums.ContactType.DIST, CurrentObject != null);
                    break;
                case Enums.ContactType.DIST:
                    SetType(Enums.ContactType.OEM, CurrentObject != null);
                    break;
                default:
                    SetType(Enums.ContactType.Unknown, CurrentObject != null);
                    break;
            }   
        }
        private void CompanyTypeStub_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }

    //namespace Enums
    //{
    //    public enum CompanyType
    //    {
    //        Any = 1,
    //        OEM = 2,
    //        DIST = 3,
    //    }
    //}
}
