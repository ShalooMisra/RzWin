using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using Rz5;
using System.Web;
using RzWeb.Screens;
using Core;
using System.Web.UI;
using Rz5.Web;

namespace RzWeb.Controls
{
    public class DesignSpot : DesignControl
    {
        public printdetail Detail;
        public Double LeftFactor = 0;
        public Double TopFactor = 0;
        public Double WidthFactor = 0;
        public Double HeightFactor = 0;

        public DesignSpot(printdetail detail)
        {
            Detail = detail;
            LeftFactor = Convert.ToDouble(detail.startx) / Convert.ToDouble(FormDesigner.DesignWidth);
            TopFactor = Convert.ToDouble(detail.starty) / Convert.ToDouble(FormDesigner.DesignHeight);
            WidthFactor = Convert.ToDouble(detail.stopx - detail.startx) / Convert.ToDouble(FormDesigner.DesignWidth);
            HeightFactor = Convert.ToDouble(detail.stopy - detail.starty)  / Convert.ToDouble(FormDesigner.DesignHeight);
        }

        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<table border=\"0\"><tr><td><img src=\"Graphics/Move.png\" id=\"" + MoveHandleId + "\" class=\"chopstix-drag-handle\" style=\"cursor: move;\"></td><td><a href=\"#\" style=\"font-size: smaller\" onclick=\"" + ActionScript("'edit'", "''") + "\">edit</a></td>");

            if (Removable)
                sb.Append("<td><a href=\"#\" style=\"font-size: smaller\" onclick=\"" + ActionScript("'remove'", "''") + "\">remove</a></td>");

            sb.AppendLine("</tr></table>");
            viewHandle.ScriptsToRun.Add("SkyLatticeDraggable('" + DivId + "');");

            if (Resizeable)
            {
                viewHandle.ScriptsToRun.Add("SkyLatticeResizable('" + DivId + "');");
                viewHandle.ScriptsToRun.Add(Select + ".css('border', 'thin solid #CCCCCC');");
            }

            String bg = BackgroundColor;
            if( bg != "" )
                viewHandle.ScriptsToRun.Add(Select + ".css('background-color', '" + bg + "');");

            viewHandle.ScriptsToRun.Add(PositionByFactor);            
        }

        protected virtual String BackgroundColor
        {
            get
            {
                return "";
            }
        }

        public override void Act(Context x, SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            switch (args.ActionId)
            {
                case "edit":
                    Edit(xrz, args);
                    break;
                case "remove":
                    Remove(xrz, args);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }

        protected virtual void Edit(ContextRz x, SpotActArgs args)
        {
            ((LeaderWebUserRz)x.Leader).PrintDetailEdit(Detail);
            Detail.Update(x);
            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }

        protected virtual void Remove(ContextRz x, SpotActArgs args)
        {
            if (!x.Leader.AreYouSure("remove this item"))
                return;

            PrintHeader.AllDetails(x).Remove(Detail);
            Detail.Delete(x);            
            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }

        public String PositionByFactor
        {
            get
            {
                return "PositionByFactor('" + DivId + "', " + LeftFactor.ToString() + ", " + TopFactor.ToString() + ", " + WidthFactor.ToString() + ", " + HeightFactor.ToString() + ");";
            }
        }

        protected override void ClassesList(Core.Context context, List<string> classes)
        {
            base.ClassesList(context, classes);
            classes.Add("chopstix-resize");
        }

        protected virtual bool Resizeable
        {
            get
            {
                return true;
            }
        }

        String MoveHandleId
        {
            get
            {
                return Uid + "_move_handle";
            }
        }

        protected virtual bool Removable
        {
            get
            {
                return true;
            }
        }
    }    

    public class DesignBar : DesignSpot
    {
        public DesignBar(printdetail detail)
            : base(detail)
        {

        }

        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div><font style=\"font-size: smaller\">" + HttpUtility.HtmlEncode(Detail.textstring) + "</font></div>");
        }

        protected override string BackgroundColor
        {
            get
            {
                return "#c4c6fd";
            }
        }
    }

    public class DesignText : DesignSpot
    {
        public DesignText(printdetail detail)
            : base(detail)
        {
        }

        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div><font style=\"font-size: smaller\">" + HttpUtility.HtmlEncode(Detail.textstring) + "</font></div>");
        }

        protected override bool Resizeable
        {
            get
            {
                return false;
            }
        }
    }

    public class DesignGraphic : DesignSpot
    {
        public DesignGraphic(printdetail detail)
            : base(detail)
        {
        }

        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<img src=\"Graphics/Picture.png\"/>");
        }

        protected override bool Resizeable
        {
            get
            {
                return false;
            }
        }

        protected override void Edit(ContextRz x, SpotActArgs args)
        {
            //base.Edit(x, args);
            String file = x.Leader.AskForFile("Picture File");

            if (!Tools.Picture.IsPictureFile(file))
            {
                x.Leader.Tell("Please choose a picture file");
                return;
            }

            Detail.AbsorbGraphic(x, file);
            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }
    }

    public class DesignBand : DesignSpot
    {
        public DesignBand(printdetail detail)
            : base(detail)
        {
        }

        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div>Line Item List</div>");
        }

        protected override bool Removable
        {
            get
            {
                return false;
            }
        }

        protected override string BackgroundColor
        {
            get
            {
                return "#d2fdd9";
            }
        }

        protected override void Edit(ContextRz x, SpotActArgs args)
        {
            ((LeaderWebUserRz)x.Leader).TemplateEdit(x, PrintHeader.CurrentTemplate);
            Detail.Update(x);
            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }
    }
}
