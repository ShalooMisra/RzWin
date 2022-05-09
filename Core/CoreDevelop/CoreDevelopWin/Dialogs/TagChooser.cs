using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ToolsWin;
using CoreDevelop;

namespace CoreDevelopWin.Dialogs
{
    public partial class TagChooser : ToolsWin.Dialogs.OKCancel
    {
        public static SystemTag Choose()
        {
            TagChooser t = new TagChooser();
            t.Init();
            t.ShowDialog();

            SystemTag ret = t.TagSelected;

            try
            {
                t.Close();
                t.Dispose();
                t = null;
            }
            catch { }

            return ret;
        }

        public SystemTag TagSelected;

        public TagChooser()
        {
            InitializeComponent();
        }

        public void Init()
        {
            lv.Items.Clear();
            lv.BeginUpdate();

            try
            {
                List<SystemTag> tags = SystemTag.Tags;
                foreach (SystemTag t in tags)
                {
                    ListViewItem i = lv.Items.Add(t.Name);
                    i.SubItems.Add(t.FileNameDll);
                    i.SubItems.Add(t.FileNameSln);
                    i.SubItems.Add(t.CodePath);
                    i.Tag = t;
                }
            }
            catch { }

            lv.EndUpdate();
        }

        public override void InitUn()
        {
            try
            {
                lv.Items.Clear();
            }
            catch { }
            base.InitUn();
        }

        private void cmdChooseSln_Click(object sender, EventArgs e)
        {
            String file = ToolsWin.FileSystem.ChooseAFile();
            if (!File.Exists(file))
                return;
            txtSln.Text = file;
        }

        private void cmdChooseDll_Click(object sender, EventArgs e)
        {
            String file = ToolsWin.FileSystem.ChooseAFile();
            if (!File.Exists(file))
                return;
            txtDll.Text = file;

            String code_path = Path.GetDirectoryName(file);
            code_path = Path.GetDirectoryName(code_path);
            code_path = Tools.Folder.ConditionFolderName(Path.GetDirectoryName(code_path));

            txtCode.Text = code_path;

            String sln = code_path + Path.GetFileNameWithoutExtension(file) + "Build.sln";
            if (File.Exists(sln))
                txtSln.Text = sln;
        }

        private void cmdChooseCode_Click(object sender, EventArgs e)
        {
            String folder = ToolsWin.FileSystem.ChooseAFolder();
            if (!Directory.Exists(folder))
                return;
            txtCode.Text = Tools.Folder.ConditionFolderName(folder);
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SystemTag tag = SystemTag.Create(Startup.TheContext, txtDll.Text, txtSln.Text, txtCode.Text);
            if (tag == null)
                return;

            SystemTag.TagSave(tag);

            txtDll.Text = "";
            txtSln.Text = "";
            txtCode.Text = "";
            
            Init();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }

        public override void OK()
        {
            try
            {
                if (lv.SelectedItems.Count == 0)
                    return;

                TagSelected = (SystemTag)lv.SelectedItems[0].Tag;
                base.OK();
            }
            catch { }
        }

        public override void Cancel()
        {
            TagSelected = null;
            base.Cancel();
        }
    }
}
