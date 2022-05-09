using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Focus
{
    public partial class FocusPanel : UserControl
    {
        public String ServerName = "";
        public bool IsDataConnected = false;

        public CommunityStatus CompanyStatus = new CommunityStatus();
        public CommunityStatus VineStatus = new CommunityStatus();
        public NewMethod.n_user CurrentUser = null;

        public FocusPanel()
        {
            InitializeComponent();
            lblStamp.Text = "";
        }

        public void ShowAllInfo()
        {
            ShowDataInfo();
            ShowCompanyInfo();
            ShowUserInfo();
            ShowInboxInfo();
            DoResize();
        }

        public void ShowDataInfo()
        {
            if (IsDataConnected)
            {
                lblData.Text = "Rz4 Data Connected\r\n[" + ServerName + "]";
                lblData.ForeColor = Color.Green;
                picData.Image = il.Images["Connected"];
                pData.Enabled = true;
            }
            else
            {
                lblData.Text = "Rz4 Data Not Connected\r\n[" + ServerName + "]";
                lblData.ForeColor = Color.Red;
                picData.Image = il.Images["Disconnected"];
                pData.Enabled = false;
            }
        }

        public void ShowCompanyInfo()
        {
            if (CompanyStatus.IsConnected)
            {
                //lblCompany.Text = "Connected\r\n" + Tools.Number.LongFormat(CompanyStatus.UserCount) + " Online";
                lblCompany.Text = "Company Link Connected";
                lblCompany.ForeColor = Color.Green;
                picCompany.Image = il.Images["company_connected"];
                pCompany.Enabled = true;
            }
            else
            {
                lblCompany.Text = "Company Link Unavailable";
                lblCompany.ForeColor = Color.Gray;
                picCompany.Image = il.Images["company_disconnected"];
                pCompany.Enabled = false;
            }
        }

        public void ShowUserInfo()
        {
            if (CurrentUser == null)
                return;

            String s = CurrentUser.name;
            if (Tools.Strings.StrExt(CurrentUser.email_address))
                s += "\r\n" + CurrentUser.email_address;

            //removed 2013_03_25: there isn't room for any more than the email line

            //if (Tools.Strings.StrExt(CurrentUser.phone))
            //    s += "\r\n" + CurrentUser.phone;

            //if (Tools.Strings.StrExt(CurrentUser.phone_ext))
            //{
            //    if (!Tools.Strings.StrExt(CurrentUser.phone))
            //        s += "\r\n";
            //    s += " x" + CurrentUser.phone_ext;
            //}

            lblProfile.Text = s;
        }

        public void ShowInboxInfo()
        {
            if (!RzWin.Context.Data.Connection.ConnectPossible())
            {
                IsDataConnected = false;
                ShowDataInfo();
                picInbox.Visible = false;
                picItems.Visible = false;
                lblViewInbox.Visible = false;
                return;
            }

            if (((ContextRz)RzWin.Context).xHook != null)
                CompanyStatus.IsConnected = ((ContextRz)RzWin.Context).xHook.IsConnected();
            else
                CompanyStatus.IsConnected = false;

            ShowCompanyInfo();

            if (RzWin.Logic.UserNotesDiabled(RzWin.Context.xUser))
            {
                HideInboxInfo();
            }
            else
            {
                ShowInboxInfoActually();
            }
        }

        void HideInboxInfo()
        {
            picItems.Visible = false;
            picInbox.Visible = false;
            lblViewInbox.Visible = false;
        }

        void ShowInboxInfoActually()
        {
            picInbox.Visible = true;
            lblViewInbox.Visible = true;

            int i = 0;
            
            if( CurrentUser != null )
                i = RzWin.Context.SelectScalarInt32("select count(*) from focus_item where the_n_user_uid = '" + CurrentUser.unique_id + "' and isnull(is_done, 0) = 0");

            switch (i)
            {
                case 0:
                    picItems.Visible = false;
                    lblViewInbox.Text = "No Items";
                    lblViewInbox.Enabled = false;
                    break;
                default:
                    //consider 10 items as full, at 2 pixels per item
                    //the bottom of the inbox is 24px
                    picItems.Visible = true;
                    int h = i * 2;
                    if (i > 20)
                        i = 20;
                    picItems.Height = h;
                    picItems.Top = 28 - picItems.Height;
                    lblViewInbox.Text = Tools.Number.LongFormat(i) + " " + nTools.Pluralize("Item", Convert.ToDouble(i));
                    lblViewInbox.Enabled = true;
                    break;
            }

            //show the ones that haven't been viewed
            ArrayList a = null;
            
            if( CurrentUser != null )
                a = RzWin.Context.QtC("focus_item", "select * from focus_item where the_n_user_uid = '" + CurrentUser.unique_id + "' and isnull(is_done, 0) = 0  and isnull(is_viewed, 0) = 0 order by date_created desc");

            if (a != null)
            {
                if (a.Count > 0)
                {
                    frmFocusItems.ShowItems(a, new Point(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
                    foreach (focus_item f in a)
                    {
                        f.is_viewed = true;
                        f.Update(RzWin.Context);
                    }
                }
            }
        }

        public void SetStatus(String s)
        {

        }

        public void SetActivityType(CoreWin.ActivityType t)
        {

        }

        private void lblChat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Form.ChatWithSomeone();
        }

        private void FocusPanel_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                picInbox.Left = this.ClientRectangle.Width - picInbox.Width;
                picInbox.Top = 0;
                lblViewInbox.Left = Convert.ToInt32(picInbox.Left - lblViewInbox.Width * 1.2);
                picItems.Left = picInbox.Left + (picInbox.Width / 2) - picItems.Width;
                picChat.Left = lblViewInbox.Left - (picChat.Width + 5);
            }
            catch { }
        }

        private void lblViewInbox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Form.ShowFocusInbox();
        }

        private void picInbox_Click(object sender, EventArgs e)
        {
            ShowInboxInfo();
            frmFocusItems.ShowItems(new ArrayList(), new Point(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
        }

        int chatflash = 0;
        public void FlashChat()
        {
            chatflash = 0;
            tmrChat.Stop();
            tmrChat.Interval = 150;
            tmrChat.Start();
        }

        private void tmrChat_Tick(object sender, EventArgs e)
        {
            if (chatflash > 4)
            {
                tmrChat.Stop();
                picChat.Visible = false;
            }
            else
            {
                picChat.Visible = !picChat.Visible;
                chatflash++;
            }
        }

        public void ExtraShow(Image i, String caption)
        {
            picExtra.Visible = true;
            picExtra.BackgroundImageLayout = ImageLayout.Stretch;
            picExtra.BackgroundImage = i;
            tip.SetToolTip(picExtra, caption);
        }

        public void ExtraHide()
        {
            picExtra.Visible = true;
            picExtra.BackgroundImage = null;
        }

        public void StampSet(String stamp, Color color)
        {
            lblStamp.ForeColor = color;
            lblStamp.Text = stamp;
        }
    }

    public class CommunityStatus
    {
        public bool IsConnected = false;
        public long UserCount = 0;
    }
}
