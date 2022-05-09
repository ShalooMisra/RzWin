namespace NewMethod
{
    partial class SysLine
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
            this.lblSystemName = new System.Windows.Forms.Label();
            this.lblClasses = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblChangeConnection = new System.Windows.Forms.LinkLabel();
            this.lblDisconnect = new System.Windows.Forms.LinkLabel();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lblReferencedBy = new System.Windows.Forms.Label();
            this.lblReferencing = new System.Windows.Forms.Label();
            this.lblEditStructure = new System.Windows.Forms.LinkLabel();
            this.lblDerive = new System.Windows.Forms.LinkLabel();
            this.gbStructure = new System.Windows.Forms.GroupBox();
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.picRight = new System.Windows.Forms.PictureBox();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.lblInstances = new System.Windows.Forms.LinkLabel();
            this.mnuInstances = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblSubSystems = new System.Windows.Forms.LinkLabel();
            this.mnuSubSystems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.throb = new NewMethod.nThrobber();
            this.lblRecentInstances = new System.Windows.Forms.LinkLabel();
            this.lblPullInClass = new System.Windows.Forms.LinkLabel();
            this.lblCopy = new System.Windows.Forms.LinkLabel();
            this.lblPaste = new System.Windows.Forms.LinkLabel();
            this.gbStructure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSystemName
            // 
            this.lblSystemName.AutoSize = true;
            this.lblSystemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemName.Location = new System.Drawing.Point(10, 11);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(126, 20);
            this.lblSystemName.TabIndex = 0;
            this.lblSystemName.Text = "<System Name>";
            // 
            // lblClasses
            // 
            this.lblClasses.AutoSize = true;
            this.lblClasses.Location = new System.Drawing.Point(11, 31);
            this.lblClasses.Name = "lblClasses";
            this.lblClasses.Size = new System.Drawing.Size(55, 13);
            this.lblClasses.TabIndex = 1;
            this.lblClasses.Text = "<Classes>";
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(8, 18);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(73, 13);
            this.lblConnection.TabIndex = 2;
            this.lblConnection.Text = "<Connection>";
            // 
            // lblChangeConnection
            // 
            this.lblChangeConnection.AutoSize = true;
            this.lblChangeConnection.Location = new System.Drawing.Point(8, 35);
            this.lblChangeConnection.Name = "lblChangeConnection";
            this.lblChangeConnection.Size = new System.Drawing.Size(113, 13);
            this.lblChangeConnection.TabIndex = 3;
            this.lblChangeConnection.TabStop = true;
            this.lblChangeConnection.Text = "<Change Connection>";
            this.lblChangeConnection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangeConnection_LinkClicked);
            // 
            // lblDisconnect
            // 
            this.lblDisconnect.AutoSize = true;
            this.lblDisconnect.Location = new System.Drawing.Point(331, 39);
            this.lblDisconnect.Name = "lblDisconnect";
            this.lblDisconnect.Size = new System.Drawing.Size(59, 13);
            this.lblDisconnect.TabIndex = 4;
            this.lblDisconnect.TabStop = true;
            this.lblDisconnect.Text = "disconnect";
            this.lblDisconnect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDisconnect_LinkClicked);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(202, 13);
            this.pb.Name = "pb";
            this.pb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pb.Size = new System.Drawing.Size(176, 11);
            this.pb.TabIndex = 6;
            this.pb.Visible = false;
            // 
            // lblReferencedBy
            // 
            this.lblReferencedBy.AutoSize = true;
            this.lblReferencedBy.Location = new System.Drawing.Point(11, 50);
            this.lblReferencedBy.Name = "lblReferencedBy";
            this.lblReferencedBy.Size = new System.Drawing.Size(90, 13);
            this.lblReferencedBy.TabIndex = 7;
            this.lblReferencedBy.Text = "<Referenced By>";
            // 
            // lblReferencing
            // 
            this.lblReferencing.AutoSize = true;
            this.lblReferencing.Location = new System.Drawing.Point(12, 67);
            this.lblReferencing.Name = "lblReferencing";
            this.lblReferencing.Size = new System.Drawing.Size(77, 13);
            this.lblReferencing.TabIndex = 8;
            this.lblReferencing.Text = "<Referencing>";
            // 
            // lblEditStructure
            // 
            this.lblEditStructure.AutoSize = true;
            this.lblEditStructure.Location = new System.Drawing.Point(343, 31);
            this.lblEditStructure.Name = "lblEditStructure";
            this.lblEditStructure.Size = new System.Drawing.Size(68, 13);
            this.lblEditStructure.TabIndex = 9;
            this.lblEditStructure.TabStop = true;
            this.lblEditStructure.Text = "edit structure";
            this.lblEditStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblEditStructure_LinkClicked);
            // 
            // lblDerive
            // 
            this.lblDerive.AutoSize = true;
            this.lblDerive.Location = new System.Drawing.Point(375, 46);
            this.lblDerive.Name = "lblDerive";
            this.lblDerive.Size = new System.Drawing.Size(36, 13);
            this.lblDerive.TabIndex = 10;
            this.lblDerive.TabStop = true;
            this.lblDerive.Text = "derive";
            this.lblDerive.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDerive_LinkClicked);
            // 
            // gbStructure
            // 
            this.gbStructure.Controls.Add(this.lblChangeConnection);
            this.gbStructure.Controls.Add(this.lblConnection);
            this.gbStructure.Controls.Add(this.lblDisconnect);
            this.gbStructure.Location = new System.Drawing.Point(14, 108);
            this.gbStructure.Name = "gbStructure";
            this.gbStructure.Size = new System.Drawing.Size(396, 55);
            this.gbStructure.TabIndex = 11;
            this.gbStructure.TabStop = false;
            this.gbStructure.Text = "Structure";
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.Blue;
            this.picLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.picLeft.Location = new System.Drawing.Point(0, 0);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(5, 174);
            this.picLeft.TabIndex = 13;
            this.picLeft.TabStop = false;
            // 
            // picRight
            // 
            this.picRight.BackColor = System.Drawing.Color.Blue;
            this.picRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.picRight.Location = new System.Drawing.Point(419, 0);
            this.picRight.Name = "picRight";
            this.picRight.Size = new System.Drawing.Size(5, 174);
            this.picRight.TabIndex = 14;
            this.picRight.TabStop = false;
            // 
            // picBottom
            // 
            this.picBottom.BackColor = System.Drawing.Color.Blue;
            this.picBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picBottom.Location = new System.Drawing.Point(5, 169);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(414, 5);
            this.picBottom.TabIndex = 15;
            this.picBottom.TabStop = false;
            // 
            // picTop
            // 
            this.picTop.BackColor = System.Drawing.Color.Blue;
            this.picTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.picTop.Location = new System.Drawing.Point(5, 0);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(414, 5);
            this.picTop.TabIndex = 16;
            this.picTop.TabStop = false;
            // 
            // lblInstances
            // 
            this.lblInstances.AutoSize = true;
            this.lblInstances.Location = new System.Drawing.Point(348, 91);
            this.lblInstances.Name = "lblInstances";
            this.lblInstances.Size = new System.Drawing.Size(47, 13);
            this.lblInstances.TabIndex = 17;
            this.lblInstances.TabStop = true;
            this.lblInstances.Text = "instance";
            this.lblInstances.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblInstances_LinkClicked);
            // 
            // mnuInstances
            // 
            this.mnuInstances.Name = "mnuInstances";
            this.mnuInstances.Size = new System.Drawing.Size(61, 4);
            // 
            // lblSubSystems
            // 
            this.lblSubSystems.AutoSize = true;
            this.lblSubSystems.ContextMenuStrip = this.mnuSubSystems;
            this.lblSubSystems.Location = new System.Drawing.Point(350, 61);
            this.lblSubSystems.Name = "lblSubSystems";
            this.lblSubSystems.Size = new System.Drawing.Size(61, 13);
            this.lblSubSystems.TabIndex = 18;
            this.lblSubSystems.TabStop = true;
            this.lblSubSystems.Text = "subsystems";
            this.lblSubSystems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSubSystems_LinkClicked);
            // 
            // mnuSubSystems
            // 
            this.mnuSubSystems.Name = "mnuSubSystems";
            this.mnuSubSystems.Size = new System.Drawing.Size(61, 4);
            this.mnuSubSystems.Opening += new System.ComponentModel.CancelEventHandler(this.mnuSubSystems_Opening);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Maroon;
            this.throb.Location = new System.Drawing.Point(385, 9);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(26, 25);
            this.throb.TabIndex = 5;
            this.throb.UseParentBackColor = false;
            // 
            // lblRecentInstances
            // 
            this.lblRecentInstances.AutoSize = true;
            this.lblRecentInstances.Location = new System.Drawing.Point(396, 90);
            this.lblRecentInstances.Name = "lblRecentInstances";
            this.lblRecentInstances.Size = new System.Drawing.Size(13, 13);
            this.lblRecentInstances.TabIndex = 19;
            this.lblRecentInstances.TabStop = true;
            this.lblRecentInstances.Text = ">";
            this.lblRecentInstances.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblRecentInstances_LinkClicked);
            // 
            // lblPullInClass
            // 
            this.lblPullInClass.AutoSize = true;
            this.lblPullInClass.ContextMenuStrip = this.mnuSubSystems;
            this.lblPullInClass.Location = new System.Drawing.Point(348, 77);
            this.lblPullInClass.Name = "lblPullInClass";
            this.lblPullInClass.Size = new System.Drawing.Size(61, 13);
            this.lblPullInClass.TabIndex = 20;
            this.lblPullInClass.TabStop = true;
            this.lblPullInClass.Text = "pull in class";
            this.lblPullInClass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPullInClass_LinkClicked);
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.ContextMenuStrip = this.mnuSubSystems;
            this.lblCopy.Location = new System.Drawing.Point(199, 90);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(30, 13);
            this.lblCopy.TabIndex = 21;
            this.lblCopy.TabStop = true;
            this.lblCopy.Text = "copy";
            this.lblCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCopy_LinkClicked);
            // 
            // lblPaste
            // 
            this.lblPaste.AutoSize = true;
            this.lblPaste.ContextMenuStrip = this.mnuSubSystems;
            this.lblPaste.Location = new System.Drawing.Point(230, 90);
            this.lblPaste.Name = "lblPaste";
            this.lblPaste.Size = new System.Drawing.Size(33, 13);
            this.lblPaste.TabIndex = 22;
            this.lblPaste.TabStop = true;
            this.lblPaste.Text = "paste";
            this.lblPaste.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblPaste_LinkClicked);
            // 
            // SysLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPaste);
            this.Controls.Add(this.lblCopy);
            this.Controls.Add(this.lblPullInClass);
            this.Controls.Add(this.lblRecentInstances);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.lblSubSystems);
            this.Controls.Add(this.picRight);
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.lblInstances);
            this.Controls.Add(this.lblDerive);
            this.Controls.Add(this.lblEditStructure);
            this.Controls.Add(this.gbStructure);
            this.Controls.Add(this.lblReferencing);
            this.Controls.Add(this.lblReferencedBy);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.throb);
            this.Controls.Add(this.lblClasses);
            this.Controls.Add(this.lblSystemName);
            this.Name = "SysLine";
            this.Size = new System.Drawing.Size(424, 174);
            this.gbStructure.ResumeLayout(false);
            this.gbStructure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label lblClasses;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.LinkLabel lblChangeConnection;
        private System.Windows.Forms.LinkLabel lblDisconnect;
        private nThrobber throb;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lblReferencedBy;
        private System.Windows.Forms.Label lblReferencing;
        private System.Windows.Forms.LinkLabel lblEditStructure;
        private System.Windows.Forms.LinkLabel lblDerive;
        private System.Windows.Forms.GroupBox gbStructure;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.PictureBox picRight;
        private System.Windows.Forms.PictureBox picBottom;
        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.LinkLabel lblInstances;
        private System.Windows.Forms.LinkLabel lblSubSystems;
        private System.Windows.Forms.ContextMenuStrip mnuSubSystems;
        private System.Windows.Forms.ContextMenuStrip mnuInstances;
        private System.Windows.Forms.LinkLabel lblRecentInstances;
        private System.Windows.Forms.LinkLabel lblPullInClass;
        private System.Windows.Forms.LinkLabel lblCopy;
        private System.Windows.Forms.LinkLabel lblPaste;
    }
}
