using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
using NewMethod;
using System.IO;

namespace Rz5
{
    public partial class printdetail : printdetail_auto
    {
        public bool IsSelected = false;

        ~printdetail()
        {
            if (m_Image != null)
            {
                m_Image.Dispose();
                m_Image = null;
            }
        }

        //these need to be in the database at some point
        public bool FillIn = false;
        public Color FillColor = Color.White;

        public void AbsorbGraphic(ContextRz context, String file)
        {
            if (!Tools.Picture.IsPictureFile(file))
                throw new Exception(Path.GetFileName(file) + " is not a picture file");

            partpicture p = partpicture.New(context);
            p.InsertTo(context, context.Logic.PictureData);
            //Actually saves the file to the path
            p.SetPictureDataByFile(context, file);
            //partpicture info like file_path
            p.SavePictureData(context);
            //This gets stamped with the unique_id of the partpicture
            p.filename = "partpicture/" + p.unique_id;
            //This, likethe Insert above, needst o pass the MySql table else will try to save via SQL connection.
            p.UpdateTo(context, context.Logic.PictureData);
            filename = p.filename;
            Update(context);
        }

       
        //public void AbsorbGraphicFromUrl(ContextRz context, string url)
        //{


        //    partpicture p = partpicture.New(context);
        //    p.InsertTo(context, context.Logic.PictureData);
        //    Image img = Tools.Picture.GetImageFromUrl(url);
        //    p.SetPictureDataByImage(context, img);           
        //    p.SavePictureData(context);

        //    //filename = "partpicture/" + p.unique_id;
        //    filename = url;
        //    Update(context);
        //}

        Image m_Image;
        public Image GetImage(ContextRz context)
        {
            if (m_Image != null)
                return m_Image;

            partpicture pic = partpicture.GetById(context, Tools.Strings.ParseDelimit(filename, "/", 2), context.Logic.PictureData);

            if (pic != null)
            {
                pic.LoadPictureData(context);
                m_Image = pic.GetPictureImage(context);
            }

            return m_Image;
        }

        //public override string GetOneLineDescription()
        //{
        //    switch (detailtype.ToLower())
        //    {
        //        case "band":
        //            return "Detail Band";
        //        case "box":
        //            return "Box";
        //        case "graphic":
        //            return "Picture";
        //        case "line":
        //            if (StartXPct == StopXPct) //vertical
        //            {
        //                return "Vertical Line";
        //            }
        //            else if (StartYPct == StopYPct)  //horizontal
        //            {
        //                return "Horizontal Line";
        //            }
        //            else
        //            {
        //                return "Line";
        //            }
        //            break;
        //        case "text":
        //            return "Text: " + textstring;
        //    }
        //    return "Unknown";
        //}

        public bool HitTest(int w, int h)
        {

            //if (textstring == "COMMENT:")
            //{
            //    ;
            //}

            int theta = 2;

            switch (detailtype.ToLower())
            {
                case "band":
                    if (StartXPct < w && StartYPct < h && w < 90 && (h - StartYPct) < theta * 5)  //alll the way to the left
                        return true;
                    break;
                case "box":
                case "headerband":
                    if (StartXPct < w && StartYPct < h && StopXPct > w && StopYPct > h)
                        return true;
                    break;
                case  "graphic":
                    if (StartXPct < w && StartYPct < h && (StartXPct + 4) > w && (StartYPct + 4) > h)
                        return true;
                    break;
                case "line":
                    if (StartXPct == StopXPct) //vertical
                    {
                        if (StartYPct < h && StopYPct > h && Math.Abs(StartXPct - w) < theta)
                            return true;
                    }
                    else if (StartYPct == StopYPct)  //horizontal
                    {
                        if (StartXPct < w && StopXPct > w && Math.Abs(StartYPct - h) < theta)
                            return true;
                    }
                    else
                    {
                        if (Math.Abs(StartXPct - w) < theta && Math.Abs(StartYPct - h) < theta)
                            return true;
                    }
                    break;
                case "text":
                    if (StartXPct < w && (StartXPct + Convert.ToInt32((textstring.Length + 1) * .5) ) > w && Math.Abs(StartYPct - h) < theta)
                        return true;
                    break;
            }
            return false;
        }

        public bool BoxTest(int w, int h, int w2, int h2)
        {
            return (StartXPct > w && StartYPct > h && StartXPct < w2 && StartYPct < h2);
        }

        //lngOWidth = 7900;
        //lngOHeight = 9015;
        public int StartXPct
        {
            get
            {
                return nTools.CalcPercent(7900, StartX);
            }
        }

        public int StopXPct
        {
            get
            {
                return nTools.CalcPercent(7900, StopX);
            }
        }

        public int StartYPct
        {
            get
            {
                return nTools.CalcPercent(9015, StartY);
            }
        }

        public int StopYPct
        {
            get
            {
                return nTools.CalcPercent(9015, StopY);
            }
        }

        //Public Functions
        public int StartX
        {
            get
            { return Convert.ToInt32(startx); }

            set
            { startx = Convert.ToInt64(value); }
        }
        public int StartY
        {
            get
            { return Convert.ToInt32(starty); }

            set
            { starty = Convert.ToInt64(value); }
        }
        public int StopX
        {
            get
            { return Convert.ToInt32(stopx); }

            set
            { stopx = Convert.ToInt64(value); }
        }
        public int StopY
        {
            get
            { return Convert.ToInt32(stopy); }

            set
            { stopy = Convert.ToInt64(value); }
        }
        public int CenterX1
        {
            get
            { return Convert.ToInt32(centerx1); }

            set
            { centerx1= Convert.ToInt64(value); }
        }
        public int CenterX2
        {
            get
            { return Convert.ToInt32(centerx2); }

            set
            { centerx2 = Convert.ToInt64(value); }
        }
        public Font GetFont()
        {
            Font xFont;
            FontStyle st;

            try
            {

                if (fontbold && (fontitalic > 0))
                    st = FontStyle.Bold | FontStyle.Italic;
                else if (fontbold)
                    st = FontStyle.Bold;
                else if (fontitalic > 0)
                    st = FontStyle.Italic;
                else
                {
                    if (Tools.Strings.StrCmp(fontname, "monotype corsiva"))
                        st = FontStyle.Bold | FontStyle.Italic;
                    else
                        st = FontStyle.Regular;
                }

                int size = 10;
                if (fontsize > 3)
                    size = fontsize;

                if (Tools.Strings.StrExt(fontname))
                    return new Font(fontname, size, st);
                else
                    xFont = new Font("Times New Roman", size, st);
            }
            catch
            {
                xFont = new Font("Times New Roman", 10);
            }

            return xFont;
        }
        public Brush GetBrush()
        {
            return new SolidBrush(GetColor());
            //if (textstring.Contains("comment"))
            //{
            //    ;
            //}


        }

        public Color GetColor()
        {
            if (IsSelected)
                return System.Drawing.Color.Red;

            return nTools.GetColorFromInt(Convert.ToInt32(this.fontcolor));

            //switch (this.fontcolor)
            //{
            //    case 0:
            //        return System.Drawing.Brushes.Black;
            //    case 2:
            //        return System.Drawing.Brushes.Red;
            //    case 3:
            //        return System.Drawing.Brushes.Green;
            //    case 4:
            //        return System.Drawing.Brushes.Yellow;
            //    case 5:
            //        return System.Drawing.Brushes.Navy; 
            //    default:
            //        return System.Drawing.Brushes.Blue;
            //}
        }

        public Pen GetPen()
        {
            if (drawwidth == 0)
                return new Pen(GetBrush(), 1);
            else
                return new Pen(GetBrush(), drawwidth);
        }


        public static printdetail GetByName(ContextRz context, string strFormID, string strName)
        {
            return (printdetail)context.QtO("printdetail", "select * from printdetail where detailname = '" + strName + "' and base_printheader_uid = '" + strFormID + "'");
        }

        public printdetail CreateSimilar(ContextRz context)
        {
            printdetail ret = printdetail.New(context);
            ret.fontname = fontname;
            ret.fontsize = fontsize;
            ret.fontbold = fontbold;
            ret.fontcolor = fontcolor;
            ret.fontitalic = fontitalic;
            ret.drawwidth = drawwidth;
            return ret;
        }
    }
}
