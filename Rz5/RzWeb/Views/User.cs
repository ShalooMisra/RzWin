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
using NewMethodWeb;
using Rz5;
using Rz5.Web;

namespace RzWeb
{
    public class User : _Item
    {
        public Rz5.n_user TheUser
        {
            get
            {
                return (Rz5.n_user)Item;
            }
        }
        String UserDiv
        {
            get
            {
                return "user_" + Uid;
            }
        }
        TextControl txtName;
        TextControl txtPhone;
        TextControl txtExt;
        TextControl txtFax;
        TextControl txtEmail;
        TextControl txtCell;
        TextControl txtLogin;
        TextControl txtPW;
        BoolControl chkSuper;
        BoolControl chkRestrict;
        BoolControl chkWarehouse;
        BoolControl chkAccounting;
        AnchorControl aViewManager;
        ViewHandle TheView;

        public User(ContextRz x, Rz5.n_user u)
            : base(x, u)
        {
            txtName = (TextControl)SpotAdd(ControlAdd(new TextControl("name", "Name", TheUser.name)));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("phone", "Phone Number", TheUser.phone)));
            txtExt = (TextControl)SpotAdd(ControlAdd(new TextControl("phone_ext", "Extention", TheUser.phone_ext)));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("fax_number", "Fax Number", TheUser.fax_number)));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("email_address", "Email Address", TheUser.email_address)));
            txtCell = (TextControl)SpotAdd(ControlAdd(new TextControl("cell_number", "Cell Number", TheUser.cell_number)));
            txtLogin = (TextControl)SpotAdd(ControlAdd(new TextControl("login_name", "Login Name", TheUser.login_name)));
            txtPW = (TextControl)SpotAdd(ControlAdd(new TextControl("login_password", "Login Password", TheUser.login_password)));
            chkSuper = (BoolControl)SpotAdd(ControlAdd(new BoolControl("super_user", "Can See Everything", TheUser.super_user)));
            chkRestrict = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkRestrict", "Restricted User", TheUser.GetSetting_Boolean(x, "restricted_user"))));
            chkWarehouse = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkWarehouse", "Warehouse", TheUser.is_warehouse)));
            chkAccounting = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkAccounting", "Accounting", TheUser.is_accounting)));
            aViewManager = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewManager", "View User Management Screen", "ShowUserMgr()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "User Profile";
            if (TheUser != null)
                s = "User Profile [" + TheUser.name + "]";
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"user_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            txtName.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtExt.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCell.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLogin.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPW.Render(x, sb, screenHandle, viewHandle, session, page);
            chkSuper.Render(x, sb, screenHandle, viewHandle, session, page);
            chkRestrict.Render(x, sb, screenHandle, viewHandle, session, page);
            chkWarehouse.Render(x, sb, screenHandle, viewHandle, session, page);
            chkAccounting.Render(x, sb, screenHandle, viewHandle, session, page);
            aViewManager.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ShowUserMgr() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine(ActionScript("'user_manager'"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, UserDiv);
            RunDivToBottom(sb, UserDiv);
            sb.AppendLine(txtName.Select + ".css('left', 10);");
            sb.AppendLine(txtName.Select + ".css('top', 5);");
            sb.AppendLine(txtPhone.Select + ".css('top', 5);");
            sb.AppendLine(txtPhone.PlaceRight(txtName));
            sb.AppendLine(txtExt.Select + ".css('top', 5);");
            sb.AppendLine(txtExt.PlaceRight(txtPhone));
            sb.AppendLine(txtFax.Select + ".css('left', 10);");
            sb.AppendLine(txtFax.PlaceBelow(txtName));
            sb.AppendLine(txtEmail.PlaceRight(txtFax));
            sb.AppendLine(txtEmail.PlaceBelow(txtName));
            sb.AppendLine(txtCell.PlaceRight(txtEmail));
            sb.AppendLine(txtCell.PlaceBelow(txtName));
            sb.AppendLine(txtLogin.Select + ".css('left', 10);");
            sb.AppendLine(txtLogin.PlaceBelow(txtFax));
            sb.AppendLine(txtPW.PlaceRight(txtLogin));
            sb.AppendLine(txtPW.PlaceBelow(txtFax));
            sb.AppendLine(aViewManager.Select + ".css('left', 10);");
            sb.AppendLine(aViewManager.PlaceBelow(txtLogin));
            sb.AppendLine(chkSuper.PlaceBelow(txtCell, false, 26, 0));
            sb.AppendLine(chkSuper.PlaceRight(txtPW));
            sb.AppendLine(chkRestrict.PlaceBelow(txtCell));
            sb.AppendLine(chkRestrict.PlaceRight(txtPW));

            sb.AppendLine(chkWarehouse.PlaceBelow(chkSuper));
            sb.AppendLine(chkWarehouse.PlaceRight(txtPW));

            sb.AppendLine(chkAccounting.PlaceBelow(chkWarehouse));
            sb.AppendLine(chkAccounting.PlaceRight(txtPW));

        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                case "user_manager":
                    ShowUserManager((ContextRz)x);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            txtName.FixedWidth = 196;
            txtPhone.FixedWidth = 196;
            txtExt.FixedWidth = 170;
            txtFax.FixedWidth = 196;
            txtEmail.FixedWidth = 196;
            txtCell.FixedWidth = 170;
            txtLogin.FixedWidth = 196;
            txtPW.FixedWidth = 196;
            aViewManager.TextFontSize = FontSize.Large;
            chkSuper.TextFontSize = FontSize.Medium;
            chkRestrict.TextFontSize = FontSize.Medium;
        }
        protected override void SaveData(Context x, SpotActArgs args, Dictionary<string, string> values)
        {
            User.MakeUserExistRzRecognin((ContextRz)x, TheUser);
            TheUser.AddPermit((ContextNM)x, "Company:Search:Search Companies", true);
            TheUser.AddPermit((ContextNM)x, "Inventory:Search:Search Parts", true);
            TheUser.AddPermit((ContextNM)x, "Order:Search:Search Orders", true);
            TheUser.AddPermit((ContextNM)x, Permissions.ThePermits.ViewAllCompanies, true);

            string s = "";
            values.TryGetValue("chkRestrict", out s);
            bool b = Tools.Strings.StrCmp(s, "Restricted User");
            TheUser.SetSetting_Boolean((ContextRz)x, "restricted_user", b);

            TheUser.is_warehouse = GetBool("chkWarehouse", values);
            TheUser.is_accounting = GetBool("chkAccounting", values);

            //this is temporary
            chkSuper.BoolValue = TheUser.super_user;
            chkWarehouse.BoolValue = TheUser.is_warehouse;
            chkAccounting.BoolValue = TheUser.is_accounting;

            base.SaveData(x, args, values);
        }

        bool GetBool(String name, Dictionary<string, string> values)
        {
            string s = "";
            values.TryGetValue(name, out s);
            return Tools.Strings.StrExt(s) && !Tools.Strings.StrCmp(s, "undefined");
        }

        private void ShowUserManager(ContextRz x)
        {
            RzWeb.UserManager q = new RzWeb.UserManager(x);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        public static void MakeUserExistRzRecognin(ContextRz x, Rz5.n_user TheUser)
        {
            string id = x.GetSetting("rzweb_id");
            if (!Tools.Strings.StrExt(id))
                return;
            string db = x.TheData.TheConnection.TheKey.DatabaseName;
            x.TheData.TheConnection.TheKey.DatabaseName = "RzRecognin";
            x.TheData.TheConnection.ConnectionStringSet();
            string id2 = x.SelectScalarString("select unique_id from companycontact where base_company_uid = '" + id + "' and primaryemailaddress = '" + TheUser.login_name + "'");
            if (!Tools.Strings.StrExt(id2))
            {
                company c = company.GetById(x, id);
                if (c == null)
                {
                    return;
                }
                companycontact cc = c.AddContact(x);
                cc.contactname = TheUser.name;
                cc.primaryemailaddress = TheUser.login_name;
                cc.Update(x);
                x.TheData.TheConnection.TheKey.DatabaseName = db;
                x.TheData.TheConnection.ConnectionStringSet();
                return;
            }
            companycontact ccc = companycontact.GetById(x, id2);
            if (ccc != null)
            {
                ccc.contactname = TheUser.name;
                ccc.primaryphone = TheUser.phone;
                ccc.primaryphoneextension = TheUser.phone_ext;
                ccc.primaryfax = TheUser.fax_number;                
                ccc.alternatephone = TheUser.cell_number;
                try { x.Execute("update companycontact set web_password = '" + TheUser.login_password + "' where unique_id = '" + id2 + "'"); }
                catch { }
                ccc.Update(x);
            }
            x.TheData.TheConnection.TheKey.DatabaseName = db;
            x.TheData.TheConnection.ConnectionStringSet();
        }
    }
}
