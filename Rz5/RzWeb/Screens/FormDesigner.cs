using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using Rz5;
using RzWeb.Controls;
using Core;
using System.Web.UI;
using System.IO;
using System.Drawing.Imaging;

namespace RzWeb.Screens
{
    public class FormDesigner : Screen
    {
        public static int DesignWidth = 7850;
        public static int DesignHeight = 9000;
        public printheader PrintHeader;
        ordhed order;
        PrintSurface surface;
        PrintTools tools;
        PrintPreview preview;

        public FormDesigner(ContextRz context, printheader printHeader, Page page)
        {
            PrintHeader = printHeader;

            surface = (PrintSurface)SpotAdd(new PrintSurface());
            surface.Init(context);

            tools = (PrintTools)SpotAdd(new PrintTools());
            preview = (PrintPreview)SpotAdd(new PrintPreview());

            String className = PrintHeader.class_name.ToLower();
            if (!Tools.Strings.StrExt(className))
                className = "ordhed_" + PrintHeader.ordertype.ToLower();

            order = (ordhed)context.QtO(className, "select top 1 * from " + className + " order by orderdate");  //get the first one?

            PreviewRefresh(context, page);
        }
        public override void ClientScriptsInclude(System.Web.UI.Page page)
        {
            base.ClientScriptsInclude(page);
            page.ClientScript.RegisterClientScriptInclude("CoreDesign", "Scripts/CoreDesign.js");
            page.ClientScript.RegisterClientScriptInclude("rzscript", "Scripts/Rz.js");
        }
        public override void ResizeRenderAll(StringBuilder sb, Page page)
        {
            base.ResizeRenderAll(sb, page);
            sb.AppendLine("ResizeByFactors();");
            sb.AppendLine("SkyLatticeResizeAll();");
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);

            tools.PlaceLeftEdge(sb);
            sb.AppendLine(tools.Select + ".css('height', 70);");
            tools.PlaceTopEdge(sb);
            tools.RunToRight(sb);

            surface.PlaceLeftEdge(sb);
            sb.AppendLine(surface.PlaceBelow(tools));
            sb.AppendLine(surface.Select + ".css('height', $(window).height() - ( " + tools.Select + ".outerHeight(true) + (  " + surface.Select + ".outerHeight(true) - " + surface.Select + ".height()  )  ) );");

            sb.AppendLine(surface.Select + ".css('width', " + surface.Select + ".height() * .7727);");

            sb.AppendLine(preview.PlaceBelow(tools));
            sb.AppendLine(preview.Select + ".css('left', " + surface.Select + ".outerWidth(true));");
            sb.AppendLine(preview.Select + ".css('height', $(window).height() - " + tools.Select + ".outerHeight(true));");
            sb.AppendLine(preview.Select + ".css('width', $(window).width() - " + surface.Select + ".outerWidth(true));");
        }
        public override String Title(Context x)
        {
            return "Form Designer";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "move":
                    Move(x, args);
                    break;
                case "pdf":
                    Pdf(x, args);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        void Move(Context context, SpotActArgs args)
        {
            DesignSpot s = (DesignSpot)surface.SpotById(args.ActionParams);
            printdetail d = s.Detail;

            Double x = Double.Parse(Tools.Data.NullFilterString(args.Request["position_left"]));
            Double y = Double.Parse(Tools.Data.NullFilterString(args.Request["position_top"]));
            Double w = Double.Parse(Tools.Data.NullFilterString(args.Request["position_width"]));
            Double h = Double.Parse(Tools.Data.NullFilterString(args.Request["position_height"]));

            x *= DesignWidth;
            y *= DesignHeight;
            w *= DesignWidth;
            h *= DesignHeight;

            d.startx = Convert.ToInt32(x);
            d.starty = Convert.ToInt32(y);
            d.stopx = Convert.ToInt32(x + w);
            d.stopy = Convert.ToInt32(y + h);
            d.Update(context);

            PreviewRefresh((ContextRz)context, args.SourcePage);
        }
        void Pdf(Context context, SpotActArgs args)
        {
            PrintSessionPdf session = new PrintSessionPdf((ContextRz)context, PrintHeader, order);
            String file = session.Print(false, Tools.Strings.FilterTrash(order.ToString()));

            String dest = args.SourcePage.MapPath("~/Bilge/" + Path.GetFileNameWithoutExtension(file) + "_" + Tools.Dates.GetNowPathHMS() + "_" + Path.GetExtension(file));
            if (File.Exists(dest))
                File.Delete(dest);

            File.Move(file, dest);
            args.SourceView.FilesToDownload.Add(dest);
            //Flow();
        }
        public void PreviewRefresh(ContextRz context, Page page)
        {
            String bilge = page.MapPath("~/Bilge/");
            if (!Directory.Exists(bilge))
                Directory.CreateDirectory(bilge);

            String path = Tools.Folder.ConditionFolderName(bilge) + "preview_" + PrintHeader.unique_id + ".jpg";
            if (File.Exists(path))
                File.Delete(path);

            PrintSessionImages session = new PrintSessionImages(context, PrintHeader, order, 850, 1100);
            session.Print();
            session.Images[0].Save(path, ImageFormat.Jpeg);

            lastPreview = "Bilge/" + Path.GetFileName(path);
            preview.Change();
            //Flow();
        }
        public void ContentRefresh(ContextRz context, ViewHandle view)
        {
            surface.Spots.Clear();
            surface.Init(context);
            surface.Change();
            //view.Flow();
        }
        String lastPreview = "";
        public String PreviewPath
        {
            get
            {
                return lastPreview;
            }
        }
    }
    public class PrintSurface : Spot
    {
        public FormDesigner DesignScreen
        {
            get
            {
                return (FormDesigner)TheScreen;
            }
        }
        public printheader PrintHeader
        {
            get
            {
                return DesignScreen.PrintHeader;
            }
        }
        public void Init(ContextRz context)
        {
            foreach (printdetail d in PrintHeader.AllDetails(context))
            {
                switch (d.detailtype.ToUpper())
                {
                    case "HEADERBAND":
                        SpotAdd(TheScreen, new DesignBar(d));
                        break;
                    case "BAND":
                        SpotAdd(TheScreen, new DesignBand(d));
                        break;
                    case "TEXT":
                        SpotAdd(TheScreen, new DesignText(d));
                        break;
                    case "GRAPHIC":
                        SpotAdd(TheScreen, new DesignGraphic(d));
                        break;
                }
            }
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            viewHandle.ScriptsToRun.Add(Select + ".css('border', 'thick solid #CCCCCC');");
            viewHandle.ScriptsToRun.Add(Select + ".css('margin', '4px');");
        }
    }
    public class DesignControl : Spot
    {
        protected void PreviewRefresh(ContextRz x, Page page)
        {
            ((FormDesigner)TheScreen).PreviewRefresh(x, page);
        }
        protected void ContentRefresh(ContextRz x, ViewHandle view)
        {
            ((FormDesigner)TheScreen).ContentRefresh(x, view);
        }
        protected printheader PrintHeader
        {
            get
            {
                return ((FormDesigner)TheScreen).PrintHeader;
            }
        }
    }
    public class PrintTools : DesignControl
    {
        public FormDesigner DesignScreen
        {
            get
            {
                return (FormDesigner)TheScreen;
            }
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div style=\"float: left; font-size: larger; margin: 4px\">" + PrintHeader.printname + "</div>");

            sb.AppendLine("<div style=\"float: left; padding: 4px\"><input id=\"newGraphic\" type=\"button\" value=\"Add A Picture\" onclick=\"" + ActionScript("'add_graphic'") + "\" style=\"font-size: smaller\"/></div>");
            Buttonize(viewHandle, "newGraphic", "Picture.png");

            sb.AppendLine("<div style=\"float: left; padding: 4px\"><input id=\"newText\" type=\"button\" value=\"Add Text or Tags\" onclick=\"" + ActionScript("'add_text'") + "\" style=\"font-size: smaller\"/></div>");
            Buttonize(viewHandle, "newText", "Text.png");

            sb.AppendLine("<div style=\"float: left; padding: 4px\"><input id=\"newBox\" type=\"button\" value=\"Add Box\" onclick=\"" + ActionScript("'add_box'") + "\" style=\"font-size: smaller\"/></div>");
            Buttonize(viewHandle, "newBox", "Box.png");

            sb.AppendLine("<div style=\"float: right\"><img src=\"Graphics/Pdf.png\" style=\"margin: 6px; cursor: pointer;\" onclick=\"" + DesignScreen.ActionScript("'pdf'", "''") + "\"></div>");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            switch (args.ActionId)
            {
                case "add_graphic":
                    AddGraphic(xrz, args);
                    break;
                case "add_text":
                    AddText(xrz, args);
                    break;
                case "add_box":
                    AddHeaderBand(xrz, args);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        void AddGraphic(ContextRz x, SpotActArgs args)
        {
            String file = x.Leader.AskForFile("Picture file (.jpg only)");
            if (!File.Exists(file))
                return;

            if (!file.ToLower().EndsWith(".jpg"))
            {
                x.Leader.Tell("Please select a .jpg file");
                return;
            }

            printdetail d = PrintHeader.DetailAdd(x, "GRAPHIC");
            d.AbsorbGraphic(x, file);

            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }
        void AddText(ContextRz x, SpotActArgs args)
        {
            String text = x.TheLeader.AskForString("Text and/or Tags", "", true);
            if (!Tools.Strings.StrExt(text))
                return;

            printdetail d = PrintHeader.DetailAdd(x, "TEXT");
            d.textstring = text;
            d.Update(x);
            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }
        void AddHeaderBand(ContextRz x, SpotActArgs args)
        {
            String text = x.TheLeader.AskForString("Contents", "", true);
            if (!Tools.Strings.StrExt(text))
                return;

            printdetail d = PrintHeader.DetailAdd(x, "HEADERBAND");
            d.textstring = text;
            d.Update(x);
            PreviewRefresh(x, args.SourcePage);
            ContentRefresh(x, args.SourceView);
        }
    }
    public class PrintPreview : Spot
    {
        public FormDesigner DesignScreen
        {
            get
            {
                return (FormDesigner)TheScreen;
            }
        }
        public printheader PrintHeader
        {
            get
            {
                return DesignScreen.PrintHeader;
            }
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div style=\"width: 100%; height: 100%; overflow: scroll\">");
            sb.AppendLine("<img border=\"0\" title=\"Preview\" title=\"Preview\" src=\"" + DesignScreen.PreviewPath + "?rnd=" + Tools.Strings.GetNewID() + "\" width=\"510\" height=\"660\" />");
            sb.AppendLine("</div>");
        }
    }
}
