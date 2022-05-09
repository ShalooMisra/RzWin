using System;
using System.Text;
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
using RzWeb.Screens;
using RzWeb;

namespace RzWeb
{
    public class Panel : RzMenuScreen
    {
        public Panel(ContextRz x)
            : base(x)
        {
        }
        public override String Title(Context x)
        {
            return "User Panel";
        }
        protected override void InitSections(ContextRz context)
        {
            base.InitSections(context);

            MenuSection s = new MenuSection("Company Information");
            s.Contents.Add(new ActHandle(new Act("RzWeb Account Management", new ActHandler(RzWebAccountShow))));
            s.Contents.Add(new ActHandle(new Act("Edit Company Details", new ActHandler(CompanyDetailsShow))));
            s.Contents.Add(new ActHandle(new Act("Data Management", new ActHandler(DataManagementShow))));
            Sections.Add(s);
            s = new MenuSection("Formats and Designs");
            s.Contents.Add(new ActHandle(new Act("Printed Forms", new ActHandler(PrintedFormsShow))));
            Sections.Add(s);
            s = new MenuSection("System Management");
            s.Contents.Add(new ActHandle(new Act("User Manager", new ActHandler(UserManagerShow))));
            s.Contents.Add(new ActHandle(new Act("Field Maintenance", new ActHandler(FieldMaintenance))));
            Sections.Add(s);

        }
        public void RzWebAccountShow(Context x, ActArgs args)
        {
            RzWebApp.ManageRzWebAccount((ContextRz)x);
        }
        public void DataManagementShow(Context x, ActArgs args)
        {
            if (Tools.Misc.IsDevelopmentMachine())
            {
                x.Leader.BrowseUrl("DataDownload.aspx?id=" + ((ContextRz)x).GetSetting("rzweb_id"));
            }
            else
                x.Leader.BrowseUrl("https://rzweb.recognin.com/DataDownload.aspx?id=" + ((ContextRz)x).GetSetting("rzweb_id"));
        }
        public void CompanyDetailsShow(Context x, ActArgs args)
        {
            ((LeaderWebUserRz)x.Leader).ScreenShow(x, new CompanyDetails((ContextRz)x));
        }
        public void PrintedFormsShow(Context x, ActArgs args)
        {
            ((LeaderWebUserRz)x.Leader).ScreenShow(x, new FormList((ContextRz)x));
        }
        public void UserManagerShow(Context x, ActArgs args)
        {
            ((LeaderWebUserRz)x.Leader).ScreenShow(x, new UserManager((ContextRz)x));
        }
        public void FieldMaintenance(Context x, ActArgs args)
        {
            x.TheLeader.AreYouSure("you want to run the field maintenance, it may take a while");
            ((ContextRz)x).TheSysRz.TheToolsLogic.FieldMaintenance(x, args);
            x.TheLeader.Tell("Field Maintenance Complete.");
        }
    }
}