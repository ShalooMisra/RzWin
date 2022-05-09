using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Core;

namespace NewMethod
{
    public partial class frmChooseUser : Form
    {
        bool do_drop = true;

        public static n_user ChooseUser()
        {
            return ChooseUser(null);
        }
        public static n_user ChooseUser(ArrayList choices)
        {
            String strUserID = "";
            String strUserName = "";
            ChooseUserName(ref strUserID, ref strUserName, choices, false);
            if (!Tools.Strings.StrExt(strUserID))
                return null;

            return (n_user)NMWin.ContextDefault.xSys.Users.GetByID(strUserID);
        }
        public static void ChooseUserName(ref String UserID, ref String UserName, DataTable users)
        {
            frmChooseUser xForm = new frmChooseUser();
            xForm.CompleteLoad(users);
            xForm.ShowDialog();
            UserID = xForm.SelectedID;
            UserName = xForm.SelectedName;
            xForm.Close();
        }
        public static void ChooseUserName(ref String UserID, ref String UserName, ArrayList choices, bool AllowNew)
        {
            frmChooseUser xForm = new frmChooseUser();
            xForm.CompleteLoad(choices, AllowNew);
            xForm.ShowDialog();
            UserID = xForm.SelectedID;
            UserName = xForm.SelectedName;
            xForm.Close();
        }
        //public static n_user ChooseUser(n_sys xs)
        //{
        //    return ChooseUser(xs);
        //}
        //public static n_user ChooseUser(n_sys xs, ArrayList choices)
        //{
        //    String strUserID = "";
        //    String strUserName = "";
        //    ChooseUserName(xs, ref strUserID, ref strUserName, choices, false);
        //    if (!Tools.Strings.StrExt(strUserID))
        //        return null;

        //    return (n_user)xs.Users.GetByID(strUserID);
        //}
        //public static void ChooseUserName(n_sys xs, ref String UserID, ref String UserName, ArrayList choices, bool AllowNew)
        //{
        //    frmChooseUser xForm = new frmChooseUser();
        //    xForm.CompleteLoad(xs, choices, AllowNew);
        //    xForm.ShowDialog();
        //    UserID = xForm.SelectedID;
        //    UserName = xForm.SelectedName;
        //    xForm.Close();
        //}

        public String SelectedName = "";
        public String SelectedID = "";
        private ArrayList ChoiceList;

        public frmChooseUser()
        {
            InitializeComponent();
        }

        public void CompleteLoad(ArrayList choices, bool AllowNew)
        {
            try
            {
                if (choices != null)
                {
                    ChoiceList = choices;
                    cbo.Items.Clear();
                    foreach (String s in ChoiceList)
                    {
                        cbo.Items.Add(s);
                    }
                }
                else
                {
                    cbo.DataSource = NMWin.ContextDefault.xSys.UserList;
                    cbo.DisplayMember = "name";
                    cbo.ValueMember = "unique_id";
                    cbo.Text = "";
                }
                lblNew.Visible = AllowNew;
            }
            catch (Exception ex)
            { string error = ex.Message; }
        }
        public void CompleteLoad(DataTable users)
        {
            try
            {
                cbo.DataSource = users;
                cbo.DisplayMember = "name";
                cbo.ValueMember = "unique_id";
                cbo.Text = "";
                lblNew.Visible = false;
            }
            catch (Exception)
            { }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public String GetSelectedID()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)cbo.SelectedValue;
                s = (String)v[1];

            }
            catch (Exception)
            {
                s = (String)cbo.SelectedValue;
            }
            return s;
        }

        public String GetSelectedName()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)cbo.SelectedValue;
                s = (String)v[0];

            }
            catch (Exception)
            {
                s = (String)cbo.Text;
            }
            return s;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(cbo.Text))
            {
                NMWin.Leader.Error("Please select a name before continuing.");
                return;
            }
            ClickOK();
        }

        private void ClickOK()
        {
            if (ChoiceList != null)
            {
                SelectedName = cbo.Text;
                SelectedID = n_user.TranslateNameToID(NMWin.ContextDefault, SelectedName);
            }
            else
            {
                SelectedID = GetSelectedID();
                if (!string.IsNullOrEmpty(SelectedID))
                    SelectedName = GetSelectedName();
            }

            if (!Tools.Strings.StrExt(SelectedName))
            {
                SelectedID = "";
                SelectedName = "";
                return;
            }
            this.Hide();
        }

        private void frmChooseUser_Load(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
            cbo.Focus();
        }

        public void DropDown()
        {
            int i = 1;
            System.IntPtr p = (System.IntPtr)i;
            SendMessage(cbo.Handle, CB_SHOWDROPDOWN, p, IntPtr.Zero);
        }

        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);

        private const int CB_SHOWDROPDOWN = 0x14F;

        private void frmChooseUser_Activated(object sender, EventArgs e)
        {
            if (do_drop)
            {
                do_drop = false;
                DropDown();
            }
        }

        private void cbo_SelectedValueChanged(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void lblNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("create a new user account"))
                return;

            n_user u = n_user.New(NMWin.ContextDefault);
            u.super_user = true;
            NMWin.ContextDefault.Insert(u);
            NMWin.ContextDefault.Show(u);
            NMWin.ContextDefault.xSys.CacheUsers(NMWin.ContextDefault);
            if (ChoiceList != null)
            {
                ChoiceList.Add(u.name);
                ChoiceList.Sort();
            }
            CompleteLoad(ChoiceList, true);
            cbo.Text = u.Name;
        }
    }
}