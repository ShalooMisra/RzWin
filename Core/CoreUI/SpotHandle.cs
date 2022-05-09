using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Core;

namespace CoreUI
{
    public class SpotHandle
    {
        public int TopAbs = 0;
        public int LeftAbs = 0;
        public int WidthAbs = 0;
        public int HeightAbs = 0;

        public int WidthPct = 0;
        public int HeightPct = 0;

        public ScreenHandle TheScreen;
        public SpotHandle ParentSpot;
        public List<SpotHandle> Spots = new List<SpotHandle>();

        public bool Changed = false;
        public bool ContainsChanges = false;
        public bool HideOverflow = true;

        public String Uid = Tools.Strings.GetNewID();
        public bool RelativeY = false;

        public void ChangedSpots(List<SpotHandle> changed)
        {
            if (Changed)
            {
                changed.Add(this);
            }
            else
            {
                foreach (SpotHandle c in Spots)
                {
                    c.ChangedSpots(changed);
                }
            }
        }

        public Point Location
        {
            get
            {
                return new Point(Convert.ToInt32(LeftAbs), Convert.ToInt32(TopAbs));
            }

            set
            {
                LeftAbs = value.X;
                TopAbs = value.Y;
                Change();
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Convert.ToInt32(WidthAbs), Convert.ToInt32(HeightAbs));
            }

            set
            {
                WidthAbs = value.Width;
                HeightAbs = value.Height;
                Change();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Location, Size);
            }
        }

        Color m_BackColor = Color.White;
        public Color BackColor
        {
            get
            {
                return m_BackColor;
            }

            set
            {
                m_BackColor = value;
                Change();
            }
        }

        public virtual void Change()
        {
            //if (Changed)
            //    return;

            Changed = true;
            if (ParentSpot != null)
                ParentSpot.ChildChanged();
        }

        public void ChildChanged()
        {
            //if (ContainsChanges)  //this seemed like a timesaver but it skipped the parent update
            //    return;

            ContainsChanges = true;
            if (ParentSpot != null)
                ParentSpot.ChildChanged();
        }

        public void ChangeClear(Context x)
        {
            Changed = false;
            ContainsChanges = false;
            foreach (SpotHandle c in Spots)
            {
                c.ChangeClear(x);
            }
        }

        public SpotHandle SpotById(String id)
        {
            if (id == Uid)
                return this;

            foreach (SpotHandle h in Spots)
            {
                if (h.Uid == id)
                    return h;
            }
            return null;

        }

        public virtual void Act(Context x, SpotActArgs args)
        {

        }

        public virtual void ActsList(Context x, List<String> ids, List<ActHandle> acts)
        {
        }

        public static String DivIdConvert(String id)
        {
            return "l_" + id;
        }

        public virtual void ResizeRender(StringBuilder sb)
        {
            foreach (SpotHandle h in Spots)
            {
                h.ResizeRender(sb);
            }
        }

        public virtual void ResizeRenderAfter(StringBuilder sb)
        {
            foreach (SpotHandle h in Spots)
            {
                h.ResizeRenderAfter(sb);
            }
        }

        public virtual String BorderRender()
        {
            return "";
        }

        public virtual void RunToRight(StringBuilder sb)
        {
            sb.AppendLine("                    $('#" + SpotHandle.DivIdConvert(Uid) + "').css('width', $('#" + SpotHandle.DivIdConvert(this.ParentSpot.Uid) + "').width());");  // - 10
        }

        public virtual void RunToBottom(StringBuilder sb)
        {
            sb.AppendLine("                    $('#" + SpotHandle.DivIdConvert(Uid) + "').css('height', $('#" + SpotHandle.DivIdConvert(this.ParentSpot.Uid) + "').height() - ($('#" + SpotHandle.DivIdConvert(this.Uid) + "').position().top));");   //  + 14
        }
    }

    public class SpotActArgs
    {
        public String ActionId;
        public String ActionParams;
        public Dictionary<String, String> Vars = new Dictionary<string, string>();

        public SpotActArgs(String actionId, String actionParams)
        {
            ActionId = Tools.Data.NullFilterString(actionId);
            ActionParams = Tools.Data.NullFilterString(actionParams);
        }

        public String Var(String name)
        {
            if (Vars.ContainsKey(name))
                return Vars[name];
            else
                return null;
        }
    }

}
