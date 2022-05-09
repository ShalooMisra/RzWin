using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class n_clip : n_clip_auto
    {
        public static bool AutoClip = false;

        public n_clip ParentClip;
        public TreeNode MyNode;
        public ArrayList MyNodes;
        public ArrayList AllClips;
        public Enums.ClipType ClipType
        {
            get
            {
                switch (this.clip_type.ToLower().Trim())
                {
                    case "folder":
                        return Enums.ClipType.Folder;
                    case "instance":
                        return Enums.ClipType.Instance;
                    default:
                        return Enums.ClipType.Unknown;
                }
            }

            set
            {
                switch (value)
                {
                    case Enums.ClipType.Folder:
                        clip_type = "Folder";
                        break;
                    case Enums.ClipType.Instance:
                        clip_type = "Instance";
                        break;
                    default:
                        clip_type = "Unknown";
                        break;
                }
            }
        }

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            last_update = System.DateTime.Now;
        }

        //Public Functions
        public void AddInCategory(ContextNM x, n_clip c, String s)
        {
            foreach (n_clip l in AllClips)
            {
                if (Tools.Strings.StrCmp(l.name, s))
                {
                    l.Add(c);
                    return;
                }
            }

            //add the category
            n_clip cat = (n_clip)x.Item("n_clip");  // new n_clip(xSys);
            Add(cat);
            cat.Add(c);
        }
        public void Add(n_clip c)
        {
            c.ParentClip = this;
            AllClips.Add(c);

            if (MyNode != null)  //add it to the notes
            {
                c.ShowClip(MyNode.Nodes);
            }
        }
        public void Clear()
        {
            AllClips = new ArrayList();
            MyNodes = new ArrayList();
            ParentClip = null;
        }
        public bool IsRoot()
        {
            return Tools.Strings.StrCmp(clip_type, "root");
        }
        public void ShowClip(TreeNodeCollection ns)
        {
            MyNodes = new ArrayList();

            TreeNode t = ns.Add(name);
            MyNode = t;
            MyNodes.Add(t);
            t.Tag = this;

            if (IsRoot())
            {
                t.ImageIndex = 0;
                t.SelectedImageIndex = 0;
            }
            else if (ClipType == NewMethod.Enums.ClipType.Folder)
            {
                t.ImageIndex = 1;
                t.SelectedImageIndex = 1;
            }
            else
            {
                t.ImageIndex = 2;
                t.SelectedImageIndex = 2;
            }

            foreach (n_clip l in AllClips)
            {
                l.ShowClip(t.Nodes);
            }

            if (is_expanded)
                MyNode.Expand();
        }
        public void UpdateNodes()
        {
            if (MyNodes == null)
                return;

            foreach (TreeNode n in MyNodes)
            {
                UpdateNode(n);
            }
        }
        public void UpdateNode(TreeNode n)
        {
            n.Text = name;
            if (is_expanded)
                n.Expand();
        }
        public nObject GetInstanceObject(ContextNM x)
        {
            return (nObject)x.GetById(link_class, link_id);
        }
        public nObjectHandle GetInstanceHandle()
        {
            return new nObjectHandle(link_class, link_id, "");
        }
        public void CompleteDelete(Context x)
        {
            x.Delete(this);
            foreach( n_clip c in AllClips )
            {
                c.CompleteDelete(x);
            }
        }
        public void RemoveClip(n_clip c)
        {
            AllClips.Remove(c);
        }
        public void RefreshSummary(ContextNM x)
        {
            RefreshSummary(x, null);
        }
        public void RefreshSummary(ContextNM x, nObject o)
        {
            if (o != null) //don't replace it if it has been edited
            {
                name = "~" + o.ToString();
            }
            else
            {
                o = GetInstanceObject(x);
                if (o == null)
                    return;

                if (name.ToLower().StartsWith("~"))
                    name = "~" + o.ToString();
            }

            summary = o.GetClipHTML(x);
            last_update = System.DateTime.Now;
        }
    }
}
