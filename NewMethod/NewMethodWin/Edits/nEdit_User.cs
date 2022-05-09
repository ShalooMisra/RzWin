using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace NewMethod
{
    public partial class nEdit_User : NewMethod.nEdit
    {
        public event ChangeUserHandler ChangeUser;
        public event NoteUserHandler NoteUser;
        public event ClearUserHandler ClearUser;

        public nObject CurrentObject;
        public String CurrentIDField = "";
        public String CurrentNameField = "";

        public ArrayList AlternateChoices;

        public nEdit_User()
        {
            InitializeComponent();
        }

        public override String Caption
        {
            get
            {
                return base.lblCaption.Text;
            }
            set
            {
                base.lblCaption.Text = value;
            }
        }

        private bool m_AllowView = false;
        public bool AllowView
        {
            get
            {
                return m_AllowView;
            }
            set
            {
                m_AllowView = value;
            }
        }

        private bool m_AllowNew = false;
        public bool AllowNew
        {
            get
            {
                return m_AllowNew;
            }
            set
            {
                m_AllowNew = value;
            }
        }

        private bool m_AllowClear = false;
        public bool AllowClear
        {
            get
            {
                return m_AllowClear;
            }
            set
            {
                m_AllowClear = value;
                lblClear.Visible = value;
            }
        }

        private bool m_AllowChange = true;
        public bool AllowChange
        {
            get
            {
                return m_AllowChange;
            }
            set
            {
                m_AllowChange = value;
                lbl.Enabled = m_AllowChange;
            }
        }

        public String GetUserName()
        {
            if (Tools.Strings.StrCmp(lbl.Text, "..."))
                return "";
            else if (Tools.Strings.StrCmp(lbl.Text, "< user name >"))
                return "";
            else
                return lbl.Text;
        }

        private void lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ChangeUser != null)
            {
                GenericEvent g = new GenericEvent();
                ChangeUser(g);
                if (g.Handled)
                    return;
            }

            if (CurrentObject != null)
                DoChangeUser();
        }

        public void DoChangeUser()
        {
            n_user u = NMWin.Leader.AskForUser(AlternateChoices, AllowNew);
            if (u == null)
                return;
            SetUserInfo(u.unique_id, u.name);
            SetUserName((String)CurrentObject.IGet(CurrentNameField));
            RaiseChangedEvent();
        }

        private void lblNote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NoteUser != null)
            {
                NoteUser(new GenericEvent());
                return;
            }

            if (CurrentObject != null)
            {
                NMWin.ContextDefault.xSys.SendNote(NMWin.ContextDefault, null);  //changed 2012_05_27 i think this is right
            }
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ClearUser != null)
            {
                ClearUser(new GenericEvent());
                return;
            }

            if (CurrentObject != null)
            {
                DoClearUser();
            }
            else
            {
                SetUserName("");
            }
            RaiseChangedEvent();
        }

        public void SetUserName()
        {
            if (CurrentObject == null)
                return;

            SetUserName((String)CurrentObject.IGet(CurrentNameField));
        }

        public void SetUserName(String strName)
        {
            if (!Tools.Strings.StrExt(strName)) //(kt)If there is no username, set the label to ".."
            {
                lbl.Text = "...";
                lblView.Visible = false;
                lblNote.Visible = false;
                lblClear.Visible = false;
            }
            else
            {
                lbl.Text = strName; // (KT)else, set THIS as the user name.  THIS is the varaible I want to affect and set to comapny owner.
                lblView.Visible = AllowView;
                //lblNote.Visible = true;
                lblClear.Visible = AllowClear;                
            }
        }

        public String UserVarName = "";
        public void SetUserInfo(String strID, String strName)
        {
            if (CurrentObject == null)
                return;

            if (Tools.Strings.StrExt(UserVarName))
            {
                n_user u = (n_user)NMWin.ContextDefault.xSys.Users.GetByName(strName);
                if (u != null)
                {
                    Core.IVarRefSingle r = (Core.IVarRefSingle)CurrentObject.VarGetByName(UserVarName);
                    if (r != null)
                    {
                        r.RefItemSet(NMWin.ContextDefault, u);
                        return;
                    }
                }
            }

            if (!Tools.Strings.StrCmp((String)CurrentObject.IGet(CurrentIDField), strID))
                CurrentObject.ISet(CurrentIDField, strID);

            if (!Tools.Strings.StrCmp((String)CurrentObject.IGet(CurrentNameField), strName))
                CurrentObject.ISet(CurrentNameField, strName);
        }

        public void DoClearUser()
        {
            SetUserInfo("", "");
            SetUserName("");
        }

        private void lblView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentObject != null)
            {
                n_user u = n_user.GetById(NMWin.ContextDefault, (String)CurrentObject.IGet(CurrentIDField));
                if (u != null)
                    NMWin.ContextDefault.Show(u);
            }
        }

        private void nEdit_User_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public override void DoResize()
        {
            try
            {
                base.DoResize();
                lbl.Width = this.ClientRectangle.Width - lbl.Left;
            }
            catch { }
        }
    }

    public delegate void ChangeUserHandler(GenericEvent e);
    public delegate void NoteUserHandler(GenericEvent e);
    public delegate void ClearUserHandler(GenericEvent e);

}

