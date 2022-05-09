using NewMethod;

namespace Rz5
{
    partial class SplitSearch
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xDisplay2 = new NewMethod.nList();
            this.xDisplay = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // xDisplay2
            // 
            this.xDisplay2.AddCaption = "Add New";
            this.xDisplay2.AllowActions = true;
            this.xDisplay2.AllowAdd = false;
            this.xDisplay2.AllowDelete = true;
            this.xDisplay2.AllowDeleteAlways = false;
            this.xDisplay2.AllowDrop = true;
            this.xDisplay2.AllowOnlyOpenDelete = false;
            this.xDisplay2.AlternateConnection = null;
            this.xDisplay2.Caption = "";
            this.xDisplay2.CurrentTemplate = null;
            this.xDisplay2.ExtraClassInfo = "";
            this.xDisplay2.Location = new System.Drawing.Point(247, 298);
            this.xDisplay2.MultiSelect = true;
            this.xDisplay2.Name = "xDisplay2";
            this.xDisplay2.Size = new System.Drawing.Size(419, 195);
            this.xDisplay2.SuppressSelectionChanged = false;
            this.xDisplay2.TabIndex = 6;
            this.xDisplay2.zz_OpenColumnMenu = false;
            this.xDisplay2.zz_OrderLineType = "";
            this.xDisplay2.zz_ShowAutoRefresh = true;
            this.xDisplay2.zz_ShowUnlimited = true;
            this.xDisplay2.ObjectClicked += new NewMethod.ObjectClickHandler(this.xDisplay2_ObjectClicked);
            // 
            // xDisplay
            // 
            this.xDisplay.AddCaption = "Add New";
            this.xDisplay.AllowActions = true;
            this.xDisplay.AllowAdd = false;
            this.xDisplay.AllowDelete = true;
            this.xDisplay.AllowDeleteAlways = false;
            this.xDisplay.AllowDrop = true;
            this.xDisplay.AllowOnlyOpenDelete = false;
            this.xDisplay.AlternateConnection = null;
            this.xDisplay.Caption = "";
            this.xDisplay.CurrentTemplate = null;
            this.xDisplay.ExtraClassInfo = "";
            this.xDisplay.Location = new System.Drawing.Point(247, 22);
            this.xDisplay.MultiSelect = true;
            this.xDisplay.Name = "xDisplay";
            this.xDisplay.Size = new System.Drawing.Size(419, 195);
            this.xDisplay.SuppressSelectionChanged = false;
            this.xDisplay.TabIndex = 5;
            this.xDisplay.zz_OpenColumnMenu = false;
            this.xDisplay.zz_OrderLineType = "";
            this.xDisplay.zz_ShowAutoRefresh = true;
            this.xDisplay.zz_ShowUnlimited = true;
            this.xDisplay.ObjectClicked += new NewMethod.ObjectClickHandler(this.xDisplay_ObjectClicked);
            // 
            // SplitSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.xDisplay2);
            this.Controls.Add(this.xDisplay);
            this.Name = "SplitSearch";
            this.Size = new System.Drawing.Size(699, 512);
            this.Resize += new System.EventHandler(this.SplitSearch_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public nList xDisplay2;
        public nList xDisplay;
    }
}
