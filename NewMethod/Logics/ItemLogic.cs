using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Tools;
using Core;

namespace NewMethod
{
    public class ItemLogic : Core.ItemLogic
    {
        public ItemLogic()
        {
            AllowOpen = true;
            ActsInstance.Add(new Act("Clip", Clip));  //, "Style"
            ActsInstance.Add(new Act("Color", Color, ColorPossible));  //, "Style"
            ActsInstance.Add(new Act("Icon", Icon, IconPossible));  //, "Style"
            //ActsInstance.Add(new Act("Copy", Copy, CopyPossible));  //, "Style"
        }
        public virtual void Color(Context x, ActArgs args)
        {
            bool cancel = false;
            Color c = x.TheLeader.ChooseColor(System.Drawing.Color.Black, ref cancel);
            if (cancel)
            {
                args.Canceled = true;
                return;
            }

            foreach (IItem i in args.TheItems.AllGet(x))
            {
                nObject n = (nObject)i;
                n.grid_color = c.ToArgb();
                x.TheDelta.Update(x, n);
            }
            args.Result(true);
        }
        public virtual void Clip(Context x, ActArgs args)
        {
            foreach (IItem i in args.TheItems.AllGet(x))
            {
                nObject n = (nObject)i;
                ((ContextNM)x).xUser.AddClipObject((ContextNM)x, n, true);
            }
        }
        public virtual void Icon(Context x, ActArgs args)
        {
            bool noneSelected = false;
            ImageHandle h = x.TheLeader.ChooseImage(ref noneSelected);
            if (h == null && !noneSelected)
            {
                args.Canceled = true;
                return;
            }

            foreach (IItem i in args.TheItems.AllGet(x))
            {
                nObject n = (nObject)i;

                if (noneSelected)
                    n.icon_index = 0;
                else
                {
                    switch (h.Name.ToLower())
                    {
                        case "cloud":
                            n.icon_index = 1;
                            break;
                        case "earth":
                            n.icon_index = 2;
                            break;
                        case "fire":
                            n.icon_index = 3;
                            break;
                        case "lightning":
                            n.icon_index = 4;
                            break;
                        case "dollar":
                            n.icon_index = 5;
                            break;
                        case "calendar":
                            n.icon_index = 6;
                            break;
                        case "plane":
                            n.icon_index = 7;
                            break;
                    }
                }

                x.TheDelta.Update(x, n);
            }
            args.Result(true);
        }
        public virtual bool ColorPossible(Context x, ActSetup set)
        {
            if (!set.IsRightClick)
                return false;

            return ColorPossible(set.ClassIdSingleOrBlank(x));
        }
        public virtual bool IconPossible(Context x, ActSetup set)
        {
            return set.IsRightClick;
        }
        public virtual bool ColorPossible(String classId)
        {
            return true;
        }

        //public virtual void Copy(Context x, ActArgs args)
        //{
        //    string s = "";
        //    foreach (IItem i in args.TheItems.AllGet(x))
        //    {
        //        nObject n = (nObject)i;
        //        if (Tools.Strings.StrExt(s))
        //            s += "\r\n";
        //        s += n.ToString() + " - ID: " + n.unique_id;
        //    }
        //    Tools.FileSystem.PopText(s);
        //    args.Result(true);
        //}
        //public virtual bool CopyPossible(Context x, ActSetup set)
        //{
        //    return ((ContextNM)x).xUser.IsDeveloper();
        //}
    }
}
