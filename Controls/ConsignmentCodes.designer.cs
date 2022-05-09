namespace RzSensible
{
    partial class ConsignmentCodes
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
            this.components = new System.ComponentModel.Container();
            this.lvCodes = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // lvCodes
            // 
            this.lvCodes.AddCaption = "Add A New Consignment Code";
            this.lvCodes.AllowActions = true;
            this.lvCodes.AllowAdd = true;
            this.lvCodes.AllowDelete = true;
            this.lvCodes.AllowDeleteAlways = false;
            this.lvCodes.AllowDrop = true;
            this.lvCodes.AllowOnlyOpenDelete = false;
            this.lvCodes.AlternateConnection = null;
            this.lvCodes.BackColor = System.Drawing.Color.White;
            this.lvCodes.Caption = "";
            this.lvCodes.CurrentTemplate = null;
            this.lvCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCodes.ExtraClassInfo = "";
            this.lvCodes.Location = new System.Drawing.Point(0, 0);
            this.lvCodes.MultiSelect = true;
            this.lvCodes.Name = "lvCodes";
            this.lvCodes.Size = new System.Drawing.Size(641, 500);
            this.lvCodes.SuppressSelectionChanged = false;
            this.lvCodes.TabIndex = 0;
            this.lvCodes.zz_OpenColumnMenu = false;
            this.lvCodes.zz_OrderLineType = "";
            this.lvCodes.zz_ShowAutoRefresh = true;
            this.lvCodes.zz_ShowUnlimited = true;
            this.lvCodes.AboutToThrow += new Core.ShowHandler(this.lvCodes_AboutToThrow);
            this.lvCodes.AboutToAdd += new NewMethod.AddHandler(this.lvCodes_AboutToAdd);
            // 
            // ConsignmentCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lvCodes);
            this.Name = "ConsignmentCodes";
            this.Size = new System.Drawing.Size(641, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lvCodes;
    }
}
