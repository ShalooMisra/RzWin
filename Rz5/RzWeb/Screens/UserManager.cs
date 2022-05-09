using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Rz5.Web;
using System.Web.UI;

namespace RzWeb
{
    public class UserManager : RzScreen
    {
        ListViewSpotUsers lvUsers;
        String UserDiv
        {
            get
            {
                return "usermgr_" + Uid;
            }
        }
        ViewHandle TheView;

        public UserManager(ContextRz x)
            : base(x)
        {
            lvUsers = (ListViewSpotUsers)SpotAdd(new ListViewSpotUsers());
            lvUsers.SkipParentRender = true;
            lvUsers.TheArgs = new ListArgs(x);            
            lvUsers.TheArgs.AddAllow = true;
            lvUsers.TheArgs.AddCaption = "Add A New User";
            lvUsers.TheArgs.TheCaption = "Users";
            lvUsers.TheArgs.TheClass = "n_user";
            lvUsers.TheArgs.TheLimit = -1;
            lvUsers.TheArgs.TheOrder = "name";
            lvUsers.TheArgs.TheTable = "n_user";
            lvUsers.TheArgs.TheTemplate = "all_users";
            lvUsers.TheArgs.TheWhere = " name not in ('Recognin Technologies', 'RzSystem' ) ";
            lvUsers.CurrentTemplate = n_template.GetByName(x, lvUsers.TheArgs.TheTemplate);
            if (lvUsers.CurrentTemplate == null)
                lvUsers.CurrentTemplate = n_template.Create(x, lvUsers.TheArgs.TheClass, lvUsers.TheArgs.TheTemplate);
            lvUsers.CurrentTemplate.GatherColumns(x);
            lvUsers.ColSource = new ColumnSourceTemplate(lvUsers.CurrentTemplate);
            lvUsers.RowSource = new RowSourceTable(x.Select(lvUsers.TheArgs.RenderSql(x, lvUsers.CurrentTemplate)));
            lvUsers.ItemDoubleClicked += new ItemDoubleClickHandler(lvUsers_ItemDoubleClicked);
            lvUsers.AddNewItem += new ItemAddHandler(lvUsers_AddNewItem);
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "User Manager";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {         
                default:
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"usermgr_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 175px;\">");
            lvUsers.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, UserDiv);
            RunDivToBottom(sb, UserDiv);
            RunDivToRight(sb, UserDiv);
            sb.AppendLine(lvUsers.Select + ".css('top', 2);");
            sb.AppendLine(lvUsers.Select + ".css('left', 2);");
            sb.AppendLine(lvUsers.Select + ".css('width', $('#" + UserDiv + "').width() + 8);");
            sb.AppendLine(lvUsers.Select + ".css('height', $('#" + UserDiv + "').height() + 6);");
        }
        private void AddScripts(ViewHandle viewHandle)
        {
        }
        private void AdjustControls()
        {
            lvUsers.ExtraStyle = "; font-size: small";
        }
        private void lvUsers_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            Rz5.n_user u = null;
            try { u = (Rz5.n_user)item; }
            catch { }
            if (u == null)
                return;
            RzWeb.User q = new RzWeb.User((ContextRz)x, u);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvUsers_AddNewItem(Context x, Page page, ViewHandle viewHandle)
        {
            String user = x.TheLeader.AskForString("What is the user's full name?", "", "User Full Name");
            if (!Tools.Strings.StrExt(user))
                return;
            String email = x.TheLeader.AskForString("What is the user's email address?", "", "User Email");
            if (!Tools.Strings.StrExt(email))
                return;
            Rz5.n_user u = (Rz5.n_user)x.QtO("n_user", "select * from n_user where login_name = '" + x.Filter(email) + "'");
            if (u != null)
            {
                x.TheLeader.Error("The login name '" + email + "' is already in use.");
                return;
            }
            u = Rz5.n_user.New(x);
            u.name = user;
            u.login_name = email;
            u.email_address = email;
            u.super_user = true;
            x.Insert(u);
            User.MakeUserExistRzRecognin((ContextRz)x, u);
            ((ContextRz)x).xSys.CacheUsers((ContextRz)x);            
            if (u != null)
            {
                RzWeb.User q = new RzWeb.User((ContextRz)x, u);
                AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
                TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
            }
        }
    }
    public class ListViewSpotUsers : ListViewSpotRz
    {
        public ListViewSpotUsers()
            : base("n_user")
        {
        }
    }
}
