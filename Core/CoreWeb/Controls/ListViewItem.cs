using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Core;
using System.Web;
using System.Data;
using Tools.Database;

namespace CoreWeb
{
    public class ListViewItem : ListViewSpot
    {
        public bool AllowExport = true;
        
        bool m_AllowAdd = true;
        public bool AllowAdd
        {
            get
            {
                return m_AllowAdd && (ItemAddNew != null);
            }

            set
            {
                m_AllowAdd = value;
            }
        }         
        public bool AllowRefresh
        {
            get
            {
                return (RefreshList != null);
            }
        }

        public String ClassId = "";
        public String AlternateTable = "";
        public event ItemSingleClickHandler ItemSingleClicked;
        public event ItemDoubleClickHandler ItemDoubleClicked;
        public event MenuActionHandler MenuActionClicked;
        public event ItemAddNewHandler ItemAddNew;
        public event RefreshListHandler RefreshList;

        public ListViewItem(String classId)
        {
            ClassId = classId;
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            String action = args.ActionId.ToLower();
            switch (action)
            {
                case "open_blob":
                    OpenBlob(x, args);
                    break;
                case "download_list":
                    DownloadList(x, args);
                    break;
                case "refresh_list":
                    if (RefreshList != null)
                        RefreshList(x, this);
                    break;
                case "add_instance":
                    if (ItemAddNew != null)
                        ItemAddNew(x, this);
                    break;
                case "delete":
                    Delete(x, args);
                    return;  //return or the below will also run a delete process
            }
            ActArgs argsx = new ActArgs(action);
            argsx.TheItems = new ItemsInstance();
            String idString = args.ActionParams;
            if (!Tools.Strings.StrExt(idString))
                idString = args.Request["ids"];
            if (!Tools.Strings.StrExt(idString))
                return;
            String[] keys = Tools.Strings.Split(idString, "|");
            List<String> ids = new List<String>();
            foreach (String k in keys)
            {
                String id = Tools.Strings.ParseDelimit(k, "_dot_", 2);
                if (Tools.Strings.StrExt(id))
                {
                    IItem n = RowSource.TryFind(ClassId, id);

                    if( n == null )
                        n = x.TheSys.ItemGetByTag(x, new ItemTag(ClassId, id));

                    if (n != null)
                    {
                        argsx.TheItems.Add(x, n);
                        ids.Add(id);
                    }
                }
            }
            if (MenuActionClicked != null)
            {
                MenuActionClicked(x, argsx, args.SourcePage, args.SourceView);
                if (argsx.Handled)
                    return;
            }
            List<ActHandle> acts = new List<ActHandle>();
            ActsList(x, ids, acts, args.Request);
            foreach (ActHandle a in acts)
            {
                if (Tools.Strings.StrExt(a.Name) && Tools.Strings.StrCmp(a.Name, action))
                {
                    argsx.TheAct = a.TheAct;
                    break;
                }
            }
            if (argsx.TheAct == null)
                argsx.Name = action;
            x.TheSys.ActInstanceBeforeAfter(x, argsx);
        }
        void Delete(Context x, SpotActArgs args)
        {
            List<Item> items = new List<Item>();
            List<String> ids = new List<string>();

            String idString = args.ActionParams;
            if (!Tools.Strings.StrExt(idString))
                idString = args.Request["ids"];
            if (!Tools.Strings.StrExt(idString))
                return;
            String[] keys = Tools.Strings.Split(idString, "|");
            foreach (String k in keys)
            {
                String id = Tools.Strings.ParseDelimit(k, "_dot_", 2);
                if (Tools.Strings.StrExt(id))
                {
                    ids.Add(id);

                    Item n = (Item)RowSource.TryFind(ClassId, id);

                    if (n == null)
                        n = (Item)x.TheSys.ItemGetByTag(x, new ItemTag(ClassId, id));

                    if (n != null)
                        items.Add(n);
                }
            }

            if (items.Count == 0)
                return;

            if (items.Count == 1 && !x.Leader.AreYouSure("delete " + x.ItemCaption(items[0])))
                return;

            if (items.Count > 1 && !x.Leader.AreYouSure("delete " + Tools.Strings.PluralizePhrase("item", items.Count)))
                return;

            foreach (Item i in items)
            {
                i.Delete(x);

                if (RowSource != null)
                    RowSource.TryRemove(i);
            }

            Change();
            //foreach (String id in ids)
            //{
            //    args.SourceView.ScriptsToRun.Add(RemoveRowScript(id));
            //}
        }
        void OpenBlob(Context x, SpotActArgs args)
        {
            String itemId = Tools.Strings.ParseDelimit(args.ActionParams, ".", 1);
            String blobName = Tools.Strings.ParseDelimit(args.ActionParams, ".", 2);

            IItem item = ((RowHandleItem)RowSource.Find(itemId)).Item;
            VarBlob b = (VarBlob)item.VarGetByName(blobName);

            try
            {
                String file = b.WriteFile(x, args.Request.MapPath("~/Exports"));
                args.SourceView.ScriptsToRun.Add("window.open('Exports/" + Path.GetFileName(file) + "');");
            }
            catch (Exception ex) { x.TheLeader.Error(ex); }
        }
        protected override void DoubleClick(Context x, string itemId, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            base.DoubleClick(x, itemId, page, viewHandle);
            Item n = ResolveItem(x, itemId);
            if (n == null)
                return;
            if (ItemDoubleClicked != null)
                ItemDoubleClicked(x, n, page, viewHandle);
        }
        protected virtual Item ResolveItem(Context x, String itemId)
        {
            Item n = (Item)RowSource.TryFind(ClassId, itemId);
            if (n == null)
                n = (Item)x.TheSys.ItemGetByTag(x, new ItemTag(ClassId, itemId));
            if (n == null && Tools.Strings.StrExt(AlternateTable))
                n = (Item)x.TheData.GetById(x, ClassId, itemId, AlternateTable);
            return n;
        }
        protected override void SingleClick(Context context, String itemId, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            base.SingleClick(context, itemId, page, viewHandle);
            Item n = (Item)RowSource.TryFind(ClassId, itemId);
            if (n == null)
                n = (Item)context.TheSys.ItemGetByTag(context, new ItemTag(ClassId, itemId));
            if (n == null && Tools.Strings.StrExt(AlternateTable))
                n = (Item)context.TheData.GetById(context, ClassId, itemId, AlternateTable);
            if (n == null)
                return;
            if (ItemSingleClicked != null)
                ItemSingleClicked(context, n, page, viewHandle);
        }
        public override void ActsList(Context x, List<string> ids, List<ActHandle> acts, HttpRequest request)
        {
            base.ActsList(x, ids, acts, request);
            ActSetup actSetup = new ActSetup();
            actSetup.IsRightClick = true;
            actSetup.TheItems = new ItemsInstance();
            int lim = 0;
            IItem n = null;
            foreach (String id in ids)
            {
                if (lim >= 10)
                    break;
                n = x.TheSys.ItemGetByTag(x, new ItemTag(ClassId, id));
                if (n == null)
                    continue;
                actSetup.TheItems.Add(x, n);
                lim++;
            }
            x.TheSys.ActsListInstance(x, actSetup);
            List<ActHandle> a = FilterActsForWeb(x, actSetup.Handles, n); 
            foreach (ActHandle h in a)
            {
                acts.Add(h);
            }
        }
        protected virtual List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> a, IItem item)
        {
            return a;
        }
        protected override void RenderToolsContents(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            base.RenderToolsContents(x, sb, viewHandle);
            sb.Append("<div style=\"float: right\">");
            if (RowSource != null && RowSource.Count > 0 && AllowExport)
                sb.Append("<img src=\"Graphics/ExcelSmall.png\" title=\"Download this list\" alt=\"Download this list\" style=\"cursor: pointer; margin: 2px\" onclick=\"" + ActionScript("'download_list'") + "\"/>");
            if (AllowAdd && ItemAddNew != null)
                sb.Append("<img src=\"Graphics/add_lv.png\" title=\"Add New " + Tools.Strings.NiceFormat(ClassId) + "\" alt=\"Add New " + Tools.Strings.NiceFormat(ClassId) + "\" style=\"cursor: pointer; margin: 2px;\" onclick=\"" + ActionScript("'add_instance'") + "\"/>");
            if (RefreshList != null)
                sb.Append("<img src=\"Graphics/Refresh.png\" title=\"Refresh List\" alt=\"Refresh List\" style=\"cursor: pointer; margin: 2px;\" onclick=\"" + ActionScript("'refresh_list'") + "\"/>");//margin-right: 18p;
            sb.Append("</div>");
        }
        private void DownloadList(Context x, SpotActArgs args)
        {
            List<String> captions = new List<string>();
            List<FieldType> types = new List<FieldType>();
            foreach (ColumnHandle c in ColSource)
            {
                captions.Add(c.Caption);
                types.Add(c.DataType);
            }
            if (RowSource is RowSourceTable)
            {
                RowSourceTable rt = (RowSourceTable)RowSource;
                DataTable d = rt.GetDataTable();
                if (d == null)
                    return;
                String file = (x.Leader.BilgePath(x) + "Export_" + Tools.Strings.GetNewID() + "_" + Tools.Dates.GetNowPathHMS() + ".xlsx").Replace("__", "_");
                Tools.Excel.DataTableToExcel(file, d, captions, types);
                args.SourceView.FilesToDownload.Add(file);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in captions)
                {
                    if (Tools.Strings.StrExt(sb.ToString()))
                        sb.Append(",");
                    sb.Append("\"" + s + "\"");
                }
                sb.Append("\r\n");
                string row = "";
                foreach (RowHandle i in RowSource)
                {
                    row = "";
                    string[] str = Tools.Strings.Split(i.ValueString(ColSource), "|^|");
                    int ii = 0;
                    foreach (string s in str)
                    {
                        ii++;
                        if (ii > ColSource.Count)
                        {
                            break;
                        }
                        if (Tools.Strings.StrExt(row))
                            row += ",";
                        row += "\"" + s + "\"";
                    }
                    sb.AppendLine(row);
                }
                String file = (x.Leader.BilgePath(x) + "Export_" + Tools.Strings.GetNewID() + "_" + Tools.Dates.GetNowPathHMS() + ".csv").Replace("__", "_");
                Tools.Files.SaveFileAsString(file, sb.ToString());
                args.SourceView.FilesToDownload.Add(file);
            }
        }
    }
    public delegate void ItemDoubleClickHandler(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle);
    public delegate void ItemSingleClickHandler(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle);
    public delegate void MenuActionHandler(Context x, ActArgs args, System.Web.UI.Page page, ViewHandle viewHandle);
    public delegate void ItemAddNewHandler(Context x, ListViewItem lv);
    public delegate void RefreshListHandler(Context x, ListViewItem lv);
}





