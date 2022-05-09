using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;
using NewMethod;

namespace Rz5
{
    public class ToolsLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup acts)
        {
            if (!ToolsAvailable(x))
                return;

            ActHandle h = new ActHandle(new Act("Tools", new ActHandler(ToolsShow)));
            acts.Add(h);

            h.SubActs.Add(new ActHandle(new Act("Sql", new ActHandler(ToolsSqlShow))));
            h.SubActs.Add(new ActHandle(new Act("Text", new ActHandler(ToolsTextShow))));
            h.SubActs.Add(new ActHandle(new Act("Data Table", new ActHandler(DataTableDevelop))));
            h.SubActs.Add(new ActHandle(new Act("Data Table Sizes", new ActHandler(DataTableSizesManage))));
            h.SubActs.Add(new ActHandle(new Act("Data Fields", new ActHandler(DataFieldsDevelop))));
            h.SubActs.Add(new ActHandle(new Act("Data Sources List", new ActHandler(DataSourcesList))));
            h.AddSubSeparator();

            h.SubActs.Add(new ActHandle(new Act("Update Data Structure", new ActHandler(UpdateDataStructure))));
            h.SubActs.Add(new ActHandle(new Act("Field Maintenance", new ActHandler(FieldMaintenance))));
            h.SubActs.Add(new ActHandle(new Act("Show Connection Info", new ActHandler(ShowConnectionInfo))));
            h.SubActs.Add(new ActHandle(new Act("Set Company Identifier", new ActHandler(SetCompanyIdentifier))));
            h.SubActs.Add(new ActHandle(new Act("View Change History", new ActHandler(ViewChangeHistory))));
            h.AddSubSeparator();
            //h.SubActs.Add(new ActHandle(new Act("Test Screen", new ActHandler(ShowTestScreen))));
            h.SubActs.Add(new ActHandle(new Act("Sandbox", new ActHandler(SandboxShow))));
            if (NMWin.ContextDefault.TheSys.isDesignMode())
                h.SubActs.Add(new ActHandle(new Act("Publish Rz", new ActHandler(RzPublishShow))));
        }

        protected virtual bool ToolsAvailable(Context x)
        {
            return ((ContextNM)x).xUser.IsDeveloper();
        }

        public void ToolsShow(Context x, ActArgs args)
        {
            SandboxShow(x, args);
        }
        public void ToolsSqlShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.ToolsSqlShow((ContextRz)x);
            args.Result(true);
        }
        public void ToolsTextShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.ToolsTextShow((ContextRz)x);
            args.Result(true);
        }
        public void DataSourcesList(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.DataSourcesList((ContextRz)x);
            args.Result(true);
        }
        public void DataTableDevelop(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.DataTableDevelop((ContextRz)x);
            args.Result(true);
        }
        public void DataTableSizesManage(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.DataTableSizesManage((ContextRz)x);
            args.Result(true);
        }
        public void DataFieldsDevelop(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.DataFieldsDevelop((ContextRz)x);
            args.Result(true);
        }
        public void UpdateDataStructure(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            xrz.xSys.UpdateDataStructure(xrz, false);

            if (xrz.TheLogicRz.PictureData != null && !Tools.Strings.StrCmp(xrz.TheLogicRz.PictureData.DatabaseName, xrz.Data.DatabaseName))
            {
                //KT 10-11-2019 - No longer updating DataStructure for partpicture.
                //CoreClassHandle h = xrz.xSys.CoreClassGet("partpicture");
                //if (h != null)
                //    DataSql.StructureCheckClass(xrz, xrz.TheLogicRz.PictureData, h, h.Name, new List<Tools.Database.Field>());    //xrz.xSys.UpdateDataStructure(xrz, xrz.TheLogicRz.PictureData, false, false);
            }

            x.TheLeader.Comment("Done.");
            x.TheLeader.StopPopStatus(false);
            args.Result(true);
        }
        public void FieldMaintenance(Context x, ActArgs args)
        {
            x.Leader.StartPopStatus("Running field maintenance...");
            x.Sys.FieldMaintenance(x);
            x.Leader.CommentEllipse("Dropping extraneous recall fields");
            foreach (String table in x.Data.Connection.ScalarArray("select name from sysobjects where type = 'U'"))
            {
                x.Data.Connection.Execute("alter table " + table + " drop column recall_date", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_user_uid", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_user_name", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_machine_name", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_type", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_version", true);
                x.Data.Connection.Execute("alter table " + table + " drop column recall_uid", true);
            }
            args.Result(true);
            x.Leader.Comment("Done");
            x.Leader.StopPopStatus(true);
        }
        public void ShowConnectionInfo(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            String s = x.TheData.TheConnection.ConnectionString;
            if (xrz.xSys.Recall)
                s += "\r\n\r\nRecall:\r\n\r\n" + xrz.xSys.RecallConnection.ConnectionString;

            s += "\r\n\r\nPictures:\r\n\r\n" + xrz.TheLogicRz.PictureData.ConnectionString;

            x.TheLeader.ShowText(s);
        }
        public void SandboxShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.SandboxShow((ContextRz)x);
            args.Result(true);
        }

        public void RzPublishShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.RzPublishShow((ContextRz)x);
            args.Result(true);
        }

        public void SetCompanyIdentifier(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            string s = n_set.GetSetting((ContextRz)x, "company_identifier");
            s = x.TheLeader.AskForString("Company Identifier:", s, false);
            n_set.SetSetting((ContextRz)x, "company_identifier", s);
            xrz.Logic.CheckCompanyIdentifier((ContextRz)x);
        }
        public void ViewChangeHistory(Context x, ActArgs args)
        {
            x.Reorg();
            //String classId = x.TheLeader.AskForString("Class Id:", "partrecord", false);
            //if (!Tools.Strings.StrExt(classId))
            //    return;

            //String itemId = x.TheLeader.AskForString("Item Id:", "", false);
            //if (!Tools.Strings.StrExt(itemId))
            //    return;

            //nChanges c = new nChanges();
            //c.CompleteLoad(new Core.ItemTag(classId, itemId), classId + "." + itemId);
            //Rz4.RzApp.xMainForm.TabShow(c, classId + "." + itemId, "changes for " + itemId);

        }
        //public void ShowTestScreen(Context x, ActArgs args)
        //{
        //    CoreWin.frmTest t = new CoreWin.frmTest();
        //    t.CompleteLoad(x);
        //    t.Show();
        //}
    }
}
