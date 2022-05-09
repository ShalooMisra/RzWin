using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OfficeInterop
{
    public class ExcelFont
    {
        private OfficeOpenXml.Style.ExcelFont font;

        public ExcelFont(OfficeOpenXml.ExcelRange range)
        {
            this.font = range.Style.Font;
        }

        public OfficeOpenXml.Style.ExcelFont GetExcelObject()
        {
            return this.font;
        }

        public bool Bold
        {
            get{ return (bool)this.font.Bold;}
            set { this.font.Bold = value; }
        }

        public string Name
        {
            get{return (string)this.font.Name;}
            set { this.font.Name = value; }
        }

        public int Size
        {
            get { return (int)this.font.Size;}
            set { this.font.Size = value; }
        }

        public bool Strikethrough
        {
            get
            {
                return (bool)this.font.Strike;
            }
            set
            {
                this.font.Strike = value;
            }
        }

        //public bool OutlineFont
        //{
        //    get
        //    {
        //        return (bool)this.font.Out
        //    }
        //    set
        //    {
        //        this.font.OutlineFont = value;
        //    }
        //}

        //public bool Shadow
        //{
        //    get
        //    {
        //        return (bool)this.font.Shad
        //    }
        //    set
        //    {
        //        this.font.Shadow = value;
        //    }
        //}

        public System.Drawing.Color Color
        {
            set
            {
                this.font.Color.SetColor(value);
            }
        }
    }
}
