using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Display
{
    public class GridColumnSource
    {
        public List<GridColumnDetail> m_Details = null;

        public virtual List<GridColumnDetail> DetailsGet(Context x)
        {
            if (m_Details == null)
                m_Details = CalcDetails(x);
            return m_Details;
        }

        public virtual List<GridColumnDetail> CalcDetails(Context x)
        {
            return new List<GridColumnDetail>();
        }

        public String[] NullRow
        {
            get
            {
                return new String[m_Details.Count];
            }
        }
    }

    public class GridColumnSourceInfer : GridColumnSource
    {
        IItems TheItems;
        public GridColumnSourceInfer(IItems items)
        {
            TheItems = items;
        }

        public override List<GridColumnDetail> CalcDetails(Context x)
        {
            List<GridColumnDetail> ret = new List<GridColumnDetail>();

            //ret.Add(new GridColumnDetail("Uid", "Id", Alignment.Left, "", 30));

            //if (TheItems is ItemsContents)
            //{
            //    ret.Add(new GridColumnDetail("Uid", "Id", Alignment.Left, "", 30));
            //    ret.Add(new GridColumnDetail("ToString", "Value", Alignment.Left, "", 50));
            //    return ret;
            //}

            List<CoreVarAttribute> common = null;

            if (TheItems is ItemsQueryClass)
                common = ((Sys)x.TheSys).PropsGetByClass(((ItemsQueryClass)TheItems).ClassId);
            else
                common = Item.VarsCommonGet(x, TheItems);

            if (common.Count == 0)
            {
                ret.Add(new GridColumnDetail("ToString", "Value", Alignment.Left, "", 50));
            }
            else
            {
                foreach (CoreVarAttribute a in common)
                {
                    ret.Add(new GridColumnDetail(a.Name, a.Name, a.AlignmentDefault, a.FormatDefault, 15));  //a.TheFieldName
                }
            }
            return ret;
        }
    }

    public class GridColumnSourceInferByClass : GridColumnSource
    {
        String ClassName;
        public GridColumnSourceInferByClass(String class_name)
        {
            ClassName = class_name;
        }

        public override List<GridColumnDetail> CalcDetails(Context x)
        {
            List<GridColumnDetail> ret = new List<GridColumnDetail>();

            //ret.Add(new GridColumnDetail("Uid", "Id", Alignment.Left, "", 30));

            List<CoreVarAttribute> common = ((Sys)x.TheSys).PropsGetByClass(ClassName);

            if (common.Count == 0)
            {
                ret.Add(new GridColumnDetail("ToString", "Value", Alignment.Left, "", 50));
            }
            else
            {
                foreach (CoreVarAttribute a in common)
                {
                    ret.Add(new GridColumnDetail(a.Name, a.Name, a.AlignmentDefault, a.FormatDefault, 15));  //a.TheFieldName
                }
            }
            return ret;
        }
    }

    public class GridColumnDetail
    {
        public String VarName;
        public String Caption;
        public Alignment Alignment;
        public String Format;
        public int WidthPercent;

        public GridColumnDetail(String var_name, String caption)
            : this(var_name, caption, Alignment.Left, "", 15)
        {

        }

        public GridColumnDetail(String var_name, String caption, Alignment align, String format, int width)
        {
            VarName = var_name;
            Caption = caption;
            Alignment = align;
            Format = format;
            WidthPercent = width;
        }
    }

    public interface IGridTarget
    {
        void RowAdd(IItem y, String[] data);
    }

    public enum Alignment
    {
        Left = 0,
        Right = 1,
        Center = 2,
    }
}
