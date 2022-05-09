using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using NewMethod;

namespace Rz5
{
    public class PrintSessionCache : PrintSession
    {
        public GraphicsCache graphicsCache;

        public PrintSessionCache(ContextRz context, printheader printHeader, nObject xObject)
            : base(context, printHeader, xObject)
        {
        }

        protected override void RollNewPage(Font f)
        {
            base.RollNewPage(f);
            graphicsCache.PageAdd();
        }
    }

    public class GraphicsCache : Tools.GraphicsWrapper
    {
        public int PrintingPage = 1;
        GraphicsPage CurrentPage;
        List<GraphicsPage> Pages = new List<GraphicsPage>();

        public GraphicsCache(Graphics g)
            : base(g)
        {
            PageAdd();
        }

        ~GraphicsCache()
        {
            try
            {
                Pages.Clear();
                CurrentPage = null;
                Pages = null;
            }
            catch { }
        }

        public void PageAdd()
        {
            CurrentPage = new GraphicsPage();
            Pages.Add(CurrentPage);
        }

        public override void DrawImage(Image i, int x, int y, int width, int height)
        {
            CurrentPage.Items.Add(new Tools.DrawItemImage(i, x, y, width, height));
        }

        public override void DrawLine(Pen pn, int x, int y, int stop_x, int stop_y)
        {
            CurrentPage.Items.Add(new Tools.DrawItemLine(pn, x, y, stop_x, stop_y));
        }

        public override void FillRectangle(Brush b, int x, int y, int width, int height)
        {
            CurrentPage.Items.Add(new Tools.DrawItemFillRectangle(b, x, y, width, height));
        }

        public override void DrawRectangle(Pen p, Rectangle r)
        {
            CurrentPage.Items.Add(new Tools.DrawItemRectangle(p, r));
        }

        public override void DrawString(string strText, Font xFont, Color c, Point p)
        {
            CurrentPage.Items.Add(new Tools.DrawItemString(strText, xFont, c, p));
        }

        public List<Tools.DrawItem> PrintingPageItems
        {
            get
            {
                if (PrintingPage > Pages.Count)
                    return new List<Tools.DrawItem>();
                else
                    return Pages[PrintingPage - 1].Items;
            }
        }

        //public virtual void DrawImage(Image i, int x, int y, int width, int height) { G.DrawImage(i, x, y, width, height); }
        //public virtual void DrawLine(Pen pn, int x, int y, int stop_x, int stop_y) { G.DrawLine(pn, x, y, stop_x, stop_y); }
        //public virtual void FillRectangle(Brush b, int x, int y, int width, int height) { G.FillRectangle(b, x, y, width, height); }
        //public virtual void DrawRectangle(Pen p, Rectangle r) { G.DrawRectangle(p, r); }
        //public virtual void DrawString(String strText, Font xFont, Color c, Point p) { G.DrawString(strText, xFont, new SolidBrush(c), p); }

    }

    public class GraphicsPage
    {
        public List<Tools.DrawItem> Items = new List<Tools.DrawItem>();

        ~GraphicsPage()
        {
            Items.Clear();
            Items = null;
        }
    }

}
