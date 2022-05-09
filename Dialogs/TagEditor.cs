using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Win.Dialogs
{
    public partial class TagEditor : ToolsWin.Dialogs.OKCancel
    {
        public static void Edit(nObject x)
        {
            TagEditor edit = new TagEditor();
            edit.Init(x);
            edit.ShowDialog();

            try
            {
                edit.Close();
                edit.Dispose();
                edit = null;
            }
            catch { }
        }

        nObject TheObject;
        String TheTags;
        n_choices TheChoices;
        public TagEditor()
        {
            InitializeComponent();
        }

        public void Init(nObject x)
        {
            base.Init();

            TheObject = x;
            lblCaption.Text = TheObject.ToString();

            TheTags = nData.NullFilter_String(TheObject.IGet("tags"));
            TheChoices = n_choices.ChoicesMakeExist(RzWin.Context, "TagsFor" + x.ClassId);
            ChoicesShow();
        }

        void ChoicesShow()
        {
            lv.Items.Clear();
            foreach (n_choice c in TheChoices.ChoicesList(RzWin.Context))
            {
                ListViewItem i = lv.Items.Add(c.name);
                if (Tools.Strings.HasString(TheTags, "<" + c.name + ">"))
                    i.Checked = true;
                i.Tag = c.name;
            }
        }

        public override void OK()
        {
            //do *not* just build the list from the checked items
            //this needs to support having hidden tags that aren't specifically on the tag choice list and get managed automatically
            foreach (ListViewItem i in lv.Items)
            {
                if (i.Checked)
                {
                    if (!Tools.Strings.HasString(TheTags, "<" + ((String)i.Tag) + ">"))
                    {
                        TheTags += "<" + ((String)i.Tag) + ">";
                    }
                }
                else
                {
                    TheTags = Tools.Strings.Replace(TheTags, "<" + ((String)i.Tag) + ">", "");
                }
            }

            TheObject.ISet("tags", TheTags);
            TheObject.Update(RzWin.Context);
            base.OK();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            String add = RzWin.Context.TheLeader.AskForString("New Tag Name");
            if (!Tools.Strings.StrExt(add))
                return;

            add = add.Replace("<", "[").Replace(">", "]"); 

            if (TheChoices.ChoiceContains(RzWin.Context, add))
            {
                RzWin.Context.TheLeader.Error(add + " already exists as a tag");
                return;
            }

            TheChoices.AddChoice(RzWin.Context, add);
            TheTags += "<" + add + ">";
            ChoicesShow();
        }
    }
}
