using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using NewMethod;

namespace Rz5
{
    public class PrintSessionImages : PrintSession
    {
        public List<Image> Images = new List<Image>();
        protected int ImageWidth;
        protected int ImageHeight;

        public PrintSessionImages(ContextRz context, printheader printHeader, nObject xObject, int imageWidth, int imageHeight)
            : base(context, printHeader, xObject)
        {
            ImageWidth = imageWidth;
            ImageHeight = imageHeight;
        }

        public override void Dispose()
        {
            base.Dispose();

            try
            {
                foreach (Image i in Images)
                {
                    i.Dispose();
                }
                Images.Clear();
            }
            catch { }
        }

        public override void Print()
        {
            base.Print();
            Bitmap b = new Bitmap(ImageWidth, ImageHeight);

            using(Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
            }

            Images.Add(b);
            CurrentGraphics = new Tools.GraphicsWrapper(Graphics.FromImage(b));            
            PrintOnGraphics(TheContext, ImageWidth, ImageHeight);
        }

        protected override void RollNewPage(Font f)
        {
            base.RollNewPage(f);
            Bitmap b = new Bitmap(ImageWidth, ImageHeight);

            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
            }

            Images.Add(b);
            CurrentGraphics = new Tools.GraphicsWrapper(Graphics.FromImage(b));
        }
    }
}
