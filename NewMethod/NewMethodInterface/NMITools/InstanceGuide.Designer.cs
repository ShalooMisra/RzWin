namespace NewMethod
{
    partial class InstanceGuide
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
            this.label1 = new System.Windows.Forms.Label();
            this.targets = new NewMethod.DataTargetManager();
            this.sl = new NewMethod.SysLine();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Instance Database Connection:";
            // 
            // targets
            // 
            this.targets.BackColor = System.Drawing.Color.White;
            this.targets.Location = new System.Drawing.Point(0, 269);
            this.targets.Name = "targets";
            this.targets.Size = new System.Drawing.Size(743, 513);
            this.targets.TabIndex = 6;
            // 
            // sl
            // 
            this.sl.BackColor = System.Drawing.Color.White;
            this.sl.Location = new System.Drawing.Point(3, 4);
            this.sl.Name = "sl";
            this.sl.PassiveMode = true;
            this.sl.Size = new System.Drawing.Size(420, 155);
            this.sl.TabIndex = 4;
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(444, 157);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(170, 44);
            this.cmdOpen.TabIndex = 8;
            this.cmdOpen.Text = "Open Instance Connection";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click);
            // 
            // InstanceGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targets);
            this.Controls.Add(this.sl);
            this.Name = "InstanceGuide";
            this.Size = new System.Drawing.Size(850, 721);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DataTargetManager targets;
        private SysLine sl;
        private System.Windows.Forms.Button cmdOpen;
    }
}
