using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;

using Core;
using CoreWeb;

namespace CoreWeb
{
    public class ListViewSpot : Spot
    {
        //public String Test = "Test!";

        //public event EventHandler ListViewDblClick;
        //public event EventHandler AddNewClick;
        public ColumnSource ColSource;
        public RowSource RowSource;
        public bool Broadcast = false;
        public bool DisableSingleClickNotify = false;
        public bool AllowExportRegardless = false;
        public bool FlattenRows = false;

        private string m_Caption = "";
        public virtual String Caption
        {
            get
            {
                return m_Caption;
            }
            set
            {
                m_Caption = value;
            }
        }
        public ListViewSpot()
        {
            //for resize testing
            //BackColor = Color.LightGreen;
        }
        public String TableId()
        {
            return Uid;
        }
        int m_HeightInRows = 0;
        public int HeightInRows
        {
            get
            {
                return m_HeightInRows;
            }

            set
            {
                m_HeightInRows = value;
            }
        }
        int m_HeightInPixelsTotal = 0;
        public int HeightInPixelsTotal
        {
            get
            {
                return m_HeightInPixelsTotal;
            }

            set
            {
                m_HeightInPixelsTotal = value;
            }
        }
        public int HeaderHeight
        {
            get
            {
                return 50;
            }
        }
        public int TheCount = 0;
        public String CountString
        {
            get
            {
                return Tools.Strings.PluralizePhrase("Row", TheCount);
            }
        }

        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);

            switch (args.ActionId.ToLower())
            {
                case "singleclick":
                    SingleClick(x, args.ActionParams, args.SourcePage, args.SourceView);
                    break;
                case "doubleclick":
                    DoubleClick(x, args.ActionParams, args.SourcePage, args.SourceView);
                    break;
                case "table_state":
                    TableStateChanged(x, args.ActionParams, args.SourceView.Uid);
                    break;
            }
        }
        protected virtual void TableStateChanged(Context x, String tableState, String changedViewId)
        {

        }
        protected virtual void SingleClick(Context context, String itemId, System.Web.UI.Page page, ViewHandle viewHandle)
        {

        }
        protected virtual void DoubleClick(Context context, String itemId, System.Web.UI.Page page, ViewHandle viewHandle)
        {

        }
        public virtual ColumnSource GetColumnSource(Context x)
        {
            return null;
        }
        public virtual RowSource GetRowSource(Context x)
        {
            return null;
        }
        public virtual void SetCurrentData(RowSource r)
        {
            RowSource = r;
        }
        public void CheckDelta(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (RowSource == null)
            {
                Change();
                return;
            }
            //find the rows that were changed and RefreshElement them
            RowSource rsob = GetRowSource(x);
            List<RowHandle> changed = new List<RowHandle>();
            List<RowHandle> added = new List<RowHandle>();
            List<RowHandle> removed = new List<RowHandle>();
            ColumnSource temp = GetColumnSource(x);
            rsob.DeltaFrom(RowSource, temp, changed, added, removed);
            if (added.Count > 0)
            {
                //have to re-show everything.
                //this still destroys the client-side sorting, though
                //we need to track the client side sorting so we know where to insert new items
                Change();
                return;
            }
            if (changed.Count > 0 || removed.Count > 0)
            {
                CoreWeb.WebTable table = WebTableCreate();
                foreach (RowHandle h in changed)
                {
                    StringBuilder sb = new StringBuilder();
                    table.RenderRow(x, temp, h, page, sb, this);
                    viewHandle.ElementsToReplace.Add(new ElementReplace(BuildRowId(Uid, h.Uid), sb.ToString()));
                }
                foreach (RowHandle h in removed)
                {
                    viewHandle.ScriptsToRun.Add(TableObjectScript + ".fnDeleteRow( document.getElementById('" + BuildRowId(Uid, h.Uid) + "') );");
                }
                SetCurrentData(rsob);
                //TheScreen.Flow();
            }
        }
        public static String RowIdDelimiter = "_dot_";
        public static String BuildRowId(String tableId, String rowId)
        {
            return tableId + RowIdDelimiter + rowId;
        }
        public static List<String> ParseRowIds(String tableAndRowIds)
        {
            List<String> ret = new List<string>();
            foreach (String s in Tools.Strings.Split(tableAndRowIds, "|"))
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                ret.Add(Tools.Strings.ParseDelimit(s, RowIdDelimiter, 2).Trim());
            }
            return ret;
        }
        protected override void ClassesList(Context context, List<string> classes)
        {
            base.ClassesList(context, classes);
            classes.Add("coretable");
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            if (ShowTools || AllowExportRegardless)
            {
                RenderTools(x, sb, viewHandle);
            }
            else
            {
                sb.Append("<div id=\"" + ToolsDivId + "\">");
                sb.Append("</div>");
            }
            if (ColSource != null)
            {
                sb.Append(TableRender(x, screenHandle, viewHandle, session, page));
            }
            if (!viewHandle.InitialRender && !viewHandle.ScriptsToRun.Contains("DoResize();"))
                viewHandle.ScriptsToRun.Add("DoResize();");
        }
        public virtual bool ShowTools
        {
            get
            {
                return Tools.Strings.StrExt(Caption);
            }
        }

        protected virtual void RenderTools(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            sb.Append("<div id=\"" + ToolsDivId + "\" style=\"overflow: auto;\">");  //
            RenderToolsContents(x, sb, viewHandle);
            sb.Append("</div>");
        }

        protected virtual void RenderToolsContents(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            String rowCaption = "";
            if (RowSource != null)
            {
                int count = RowSource.Count;
                if (count > 0)
                    rowCaption = "&nbsp;&nbsp;(" + Tools.Strings.PluralizePhrase("Result", count) + ")";
            }
            sb.Append("<div style=\"float: left\">" + Caption + rowCaption + "</div>");
        }
        public String ToolsDivId
        {
            get
            {
                return "tableToolsDiv_" + DivId;
            }
        }
        public void ColumnDefs(Context x, System.Text.StringBuilder sb, System.Web.UI.Page page, WebTable table)
        {
            if (ColSource == null)
                return;

            try
            {
                sb.AppendLine(", \"aoColumns\": [");
                bool first = true;

                if (table.UseIconColumn)
                {
                    sb.AppendLine(" { \"sWidth\": \"1%\", \"sType\": \"string\" }");
                    first = false;
                }

                foreach (ColumnHandle c in ColSource)
                {
                    if (!first)
                        sb.Append(", ");
                    switch (c.DataType)
                    {
                        case Tools.Database.FieldType.Int32:
                        case Tools.Database.FieldType.Int64:
                        case Tools.Database.FieldType.Double:
                            sb.AppendLine(" { \"sWidth\": \"" + c.WidthPercent.ToString() + "%\", \"sType\": \"numeric-commaignore\" }");
                            break;
                        case Tools.Database.FieldType.DateTime:
                            sb.AppendLine(" { \"sWidth\": \"" + c.WidthPercent.ToString() + "%\", \"sType\": \"date\" }");
                            break;
                        default:
                            sb.AppendLine(" { \"sWidth\": \"" + c.WidthPercent.ToString() + "%\", \"sType\": \"string\" }");
                            break;
                    }
                    first = false;
                }
                sb.AppendLine("]");
            }
            catch { }
        }
        public String JqPath(System.Web.UI.Page page)
        {
            return page.ResolveClientUrl("~/Jq");
        }
        public String MenuPage(System.Web.UI.Page page)
        {
            return page.ResolveClientUrl("~/ContextMenu.aspx");
        }
        protected virtual String TableRender(Context context, Screen screen, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            WebTable t = WebTableCreate();
            sb.Append(t.ListRender(context, ColSource, RowSource, page, ref count, Uid, this));
            viewHandle.ScriptsToRun.Add(ClickScript(context, page, viewHandle));
            viewHandle.ScriptsToRun.Add(DataTableScript(context, page, t, viewHandle));
            return sb.ToString();
        }
        protected virtual WebTable WebTableCreate()
        {
            WebTableJq wt = new WebTableJq(Uid);
            wt.FlattenRows = FlattenRows;
            return wt;
        }
        //protected virtual void MenuControlsRender(StringBuilder sb, System.Web.UI.Page page)
        //{
        //    sb.AppendLine("    <div style=\"display: none; position: absolute; padding: 2px; overflow: none; z-index: 0; background-color: #FFFFFF;\"");
        //    sb.AppendLine("    id=\"menu_" + Uid + "\">");
        //    sb.AppendLine("        <table width=\"250px\" cellspacing=\"2\" cellpadding=\"2\" border=\"1\" id=\"menulist_" + Uid + "\">");
        //    sb.AppendLine("            <tbody>");
        //    sb.AppendLine("            </tbody>");
        //    sb.AppendLine("        </table>");
        //    sb.AppendLine("    </div>");

        //    sb.AppendLine("    <div style=\"display: none; position: absolute; padding: 2px;\" id=\"WaitingDiv_" + Uid + "\">");
        //    sb.AppendLine("    <img border=\"0\" alt=\"Waiting\" src=\"" + page.ResolveClientUrl("~/Jq/images/ui-anim_basic_16x16.gif") + "\"/>");
        //    sb.AppendLine("    </div>");
        //}
        public String SelectionChangeScript = "";
        protected String ClickScript(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            bool selectionChange = Tools.Strings.StrExt(SelectionChangeScript);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$('#" + Uid + "').on(\"click\", \".webtablerow\", function (evt) ");
            sb.AppendLine("        {");
            sb.AppendLine("            if( $(this).attr(\"id\") == '' )");
            sb.AppendLine("                return;");
            sb.AppendLine("            if( evt.ctrlKey )");
            sb.AppendLine("            {");
            sb.AppendLine("                if ($(this).hasClass('row_selected')) ");
            sb.AppendLine("                {");
            sb.AppendLine("                    $(this).removeClass('row_selected');");

            if( selectionChange )
                sb.AppendLine("                    " + SelectionChangeScript);

            if (Broadcast)
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("                }");
            sb.AppendLine("                else ");
            sb.AppendLine("                {");
            sb.AppendLine("                    $(this).addClass('row_selected');");
            sb.AppendLine("                    SetActiveRow('" + Uid + "', $(this));");

            if (selectionChange)
                sb.AppendLine("                    " + SelectionChangeScript);

            if (Broadcast)
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("                }");
            sb.AppendLine("           }");
            sb.AppendLine("            else if( evt.shiftKey )");
            sb.AppendLine("            {");
            sb.AppendLine("                try {");
            sb.AppendLine("                if ($(this).hasClass('row_selected')) ");
            sb.AppendLine("                {");
            sb.AppendLine("                    $(this).removeClass('row_selected');");

            if (selectionChange)
                sb.AppendLine("                    " + SelectionChangeScript);

            if (Broadcast)
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("                }");
            sb.AppendLine("                else");
            sb.AppendLine("                {");
            sb.AppendLine("                    SetSelectedActiveRowOrRange('" + Uid + "', $(this));");

            if (selectionChange)
                sb.AppendLine("                    " + SelectionChangeScript);

            if( Broadcast )
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("                }");
            sb.AppendLine("                } catch(e){ alert(e.message); }");
            sb.AppendLine("           }");
            sb.AppendLine("           else");
            sb.AppendLine("           {");
            sb.AppendLine("               SetSelectedActiveRow('" + Uid + "', $(this));");

            if (selectionChange)
                sb.AppendLine("                    " + SelectionChangeScript);

            if (Broadcast)
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("                var x = $(this).attr(\"id\");");
            sb.AppendLine("                var ids = x.split(\"_dot_\");");
            sb.AppendLine("                var id = ids[1];");

            if( !DisableSingleClickNotify )
                sb.AppendLine("                " + ActionScript("'singleclick'", "ids[1]"));

            sb.AppendLine("           }");
            sb.AppendLine("        });");


            sb.AppendLine("        $('#" + Uid + "').on(\"dblclick\", \".webtablerow\", function (evt) ");
            sb.AppendLine("        {");
            sb.AppendLine("                if( $(this).attr(\"id\") == '' )");
            sb.AppendLine("                    return;");
            sb.AppendLine("                SetSelectedActiveRow('" + Uid + "', $(this));");

            if (selectionChange)
                sb.AppendLine("                    " + SelectionChangeScript);

            if (Broadcast)
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("                var x = $(this).attr(\"id\");");
            sb.AppendLine("                var ids = x.split(\"_dot_\");");
            sb.AppendLine("                var id = ids[1];");
            sb.AppendLine("                " + ActionScript("'doubleclick'", "ids[1]"));
            sb.AppendLine("        });");

            sb.AppendLine("        $('#" + Uid + "').off(\"contextmenu\").on(\"contextmenu\", \".webtablerow\", function(e)");
            sb.AppendLine("        {");
            sb.AppendLine("            if( $(this).attr(\"id\") == '' )");
            sb.AppendLine("                return;");

            sb.AppendLine("            if ($(this).hasClass('row_selected') == false) ");
            sb.AppendLine("            {");
            sb.AppendLine("                SetSelectedActiveRow('" + Uid + "', $(this));");

            if (Broadcast)
                sb.AppendLine("                    " + BroadcastScript());

            sb.AppendLine("            }");

            sb.AppendLine("            var datarray = [];  datarray.push({name: 'ids', value: SelectedRowIds('" + Uid + "')});  MenuShowWithParameters('" + Uid + "', e.pageX, e.pageY, datarray);");

            sb.AppendLine("            return false;");
            sb.AppendLine("        }); ");

            //sb.AppendLine("        $('#menulist_" + Uid + "').find('tbody').on(\"click\", \"tr\", function (evt) ");
            //sb.AppendLine("        {");
            //sb.AppendLine("                $('#menu_" + Uid + "').hide();");
            //sb.AppendLine("                " + ActionScript("$(this).attr(\"id\")", "SelectedRowIds('" + Uid + "')"));
            //sb.AppendLine("        });");

            //sb.AppendLine("        $(\"#menu_" + Uid + "\").bind(\"mouseleave\", function( event )");
            //sb.AppendLine("        {");
            //sb.AppendLine("            $('#menu_" + Uid + "').hide();");
            //sb.AppendLine("        });");

            return sb.ToString();
        }
        public String SelectedRowCountScript
        {
            get
            {
                return "SelectedRowCount('" + Uid + "')";
            }
        }
        public String SelectedRowIdsScript
        {
            get
            {
                return "SelectedRowIds('" + Uid + "')";
            }
        }
        public String SetSelectedRowsScript(String ids)
        {
            String ret = "SetSelectedRows('" + Uid + "', '" + ids + "');";
            if (Tools.Strings.StrExt(SelectionChangeScript))
                ret += " " + SelectionChangeScript;
            return ret;
        }
        public String RemoveRowScript(String tableAndRowId)
        {
            return TableObjectScript + ".fnDeleteRow( document.getElementById('" + tableAndRowId + "') );";
        }
        protected String BroadcastScript()
        {
            return "BroadcastTableState('" + TheScreen.Uid + "', '" + Uid + "', '" + Uid + "');";
        }
        public String TableObjectId
        {
            get
            {
                return "tableObject" + Uid;
            }
        }
        public String TableObjectScript
        {
            get
            {
                return "TableGet('" + DivId + "')";
            }
        }
        protected String DataTableScript(Context x, System.Web.UI.Page page, WebTable table, ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine();

            if( viewHandle.InitialRender )
                sb.AppendLine("DoResize();");

            sb.AppendLine("var " + TableObjectId + " = $('#" + Uid + "').dataTable(");
            sb.AppendLine("{");
            //sb.AppendLine("\"bJQueryUI\": true,");
            sb.AppendLine("\"bPaginate\": false,");
            sb.AppendLine("\"bRetrieve\": true,");
            sb.AppendLine("\"bFilter\": false,");
            sb.AppendLine("\"bInfo\": false,");
            sb.AppendLine("\"bAutoWidth\": false,");
            sb.AppendLine("\"aaSorting\": [],");
            //sb.AppendLine("\"fnInfoCallback\": function( oSettings, iStart, iEnd, iMax, iTotal, sPre ) ");
            //sb.AppendLine("{");
            //sb.AppendLine("return '';");
            //sb.AppendLine("},");

            sb.AppendLine("\"oLanguage\": {");
            sb.AppendLine("\"sEmptyTable\": \"\"");
            sb.AppendLine("},");

            sb.AppendLine("\"sScrollX\": \"100%\"");
            sb.AppendLine(",\"sScrollY\": \"1px\"");
            ColumnDefs(x, sb, page, table);
            sb.AppendLine("});");

            sb.AppendLine("TableSet('" + DivId + "', " + TableObjectId + ");");
            //sb.AppendLine("$('.dataTables_empty').hide();");
            
            if( !viewHandle.InitialRender )
                sb.AppendLine("DoResize();");

            return sb.ToString();
        }
    }
}