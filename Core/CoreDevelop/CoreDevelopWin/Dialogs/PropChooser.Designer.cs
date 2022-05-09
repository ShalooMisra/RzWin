namespace CoreDevelopWin
{
    partial class PropChooser
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdNewDateTime = new System.Windows.Forms.Button();
            this.cmdNewInt64 = new System.Windows.Forms.Button();
            this.cmdNewInt32 = new System.Windows.Forms.Button();
            this.cmdMemberAddString = new System.Windows.Forms.Button();
            this.cmdMemberAddDouble = new System.Windows.Forms.Button();
            this.cmdNewOneToMany = new System.Windows.Forms.Button();
            this.cmdNewSingleRef = new System.Windows.Forms.Button();
            this.cmdNewBool = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdNewDateTime);
            this.groupBox2.Controls.Add(this.cmdNewInt64);
            this.groupBox2.Controls.Add(this.cmdNewInt32);
            this.groupBox2.Controls.Add(this.cmdMemberAddString);
            this.groupBox2.Controls.Add(this.cmdMemberAddDouble);
            this.groupBox2.Controls.Add(this.cmdNewOneToMany);
            this.groupBox2.Controls.Add(this.cmdNewSingleRef);
            this.groupBox2.Controls.Add(this.cmdNewBool);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 178);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Props";
            // 
            // cmdNewDateTime
            // 
            this.cmdNewDateTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewDateTime.Location = new System.Drawing.Point(138, 98);
            this.cmdNewDateTime.Name = "cmdNewDateTime";
            this.cmdNewDateTime.Size = new System.Drawing.Size(126, 33);
            this.cmdNewDateTime.TabIndex = 17;
            this.cmdNewDateTime.Text = "New DateTime";
            this.cmdNewDateTime.UseVisualStyleBackColor = true;
            this.cmdNewDateTime.Click += new System.EventHandler(this.cmdNewDateTime_Click);
            // 
            // cmdNewInt64
            // 
            this.cmdNewInt64.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewInt64.Location = new System.Drawing.Point(138, 59);
            this.cmdNewInt64.Name = "cmdNewInt64";
            this.cmdNewInt64.Size = new System.Drawing.Size(126, 33);
            this.cmdNewInt64.TabIndex = 16;
            this.cmdNewInt64.Text = "New Int64";
            this.cmdNewInt64.UseVisualStyleBackColor = true;
            this.cmdNewInt64.Click += new System.EventHandler(this.cmdNewInt64_Click);
            // 
            // cmdNewInt32
            // 
            this.cmdNewInt32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewInt32.Location = new System.Drawing.Point(6, 59);
            this.cmdNewInt32.Name = "cmdNewInt32";
            this.cmdNewInt32.Size = new System.Drawing.Size(126, 33);
            this.cmdNewInt32.TabIndex = 15;
            this.cmdNewInt32.Text = "New Int32";
            this.cmdNewInt32.UseVisualStyleBackColor = true;
            this.cmdNewInt32.Click += new System.EventHandler(this.cmdNewInt32_Click);
            // 
            // cmdMemberAddString
            // 
            this.cmdMemberAddString.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMemberAddString.Location = new System.Drawing.Point(6, 20);
            this.cmdMemberAddString.Name = "cmdMemberAddString";
            this.cmdMemberAddString.Size = new System.Drawing.Size(126, 33);
            this.cmdMemberAddString.TabIndex = 7;
            this.cmdMemberAddString.Text = "New String";
            this.cmdMemberAddString.UseVisualStyleBackColor = true;
            this.cmdMemberAddString.Click += new System.EventHandler(this.cmdMemberAddString_Click);
            // 
            // cmdMemberAddDouble
            // 
            this.cmdMemberAddDouble.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMemberAddDouble.Location = new System.Drawing.Point(6, 98);
            this.cmdMemberAddDouble.Name = "cmdMemberAddDouble";
            this.cmdMemberAddDouble.Size = new System.Drawing.Size(126, 33);
            this.cmdMemberAddDouble.TabIndex = 9;
            this.cmdMemberAddDouble.Text = "New Double";
            this.cmdMemberAddDouble.UseVisualStyleBackColor = true;
            this.cmdMemberAddDouble.Click += new System.EventHandler(this.cmdMemberAddDouble_Click);
            // 
            // cmdNewOneToMany
            // 
            this.cmdNewOneToMany.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewOneToMany.Location = new System.Drawing.Point(6, 137);
            this.cmdNewOneToMany.Name = "cmdNewOneToMany";
            this.cmdNewOneToMany.Size = new System.Drawing.Size(126, 33);
            this.cmdNewOneToMany.TabIndex = 12;
            this.cmdNewOneToMany.Text = "New List Of...";
            this.cmdNewOneToMany.UseVisualStyleBackColor = true;
            this.cmdNewOneToMany.Click += new System.EventHandler(this.cmdNewOneToMany_Click);
            // 
            // cmdNewSingleRef
            // 
            this.cmdNewSingleRef.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewSingleRef.Location = new System.Drawing.Point(138, 137);
            this.cmdNewSingleRef.Name = "cmdNewSingleRef";
            this.cmdNewSingleRef.Size = new System.Drawing.Size(126, 33);
            this.cmdNewSingleRef.TabIndex = 13;
            this.cmdNewSingleRef.Text = "New Single Ref";
            this.cmdNewSingleRef.UseVisualStyleBackColor = true;
            this.cmdNewSingleRef.Click += new System.EventHandler(this.cmdNewSingleRef_Click);
            // 
            // cmdNewBool
            // 
            this.cmdNewBool.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNewBool.Location = new System.Drawing.Point(138, 20);
            this.cmdNewBool.Name = "cmdNewBool";
            this.cmdNewBool.Size = new System.Drawing.Size(126, 33);
            this.cmdNewBool.TabIndex = 14;
            this.cmdNewBool.Text = "New Boolean";
            this.cmdNewBool.UseVisualStyleBackColor = true;
            this.cmdNewBool.Click += new System.EventHandler(this.cmdNewBool_Click);
            // 
            // PropChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(297, 204);
            this.Controls.Add(this.groupBox2);
            this.Name = "PropChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Property Chooser";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdNewDateTime;
        private System.Windows.Forms.Button cmdNewInt64;
        private System.Windows.Forms.Button cmdNewInt32;
        private System.Windows.Forms.Button cmdMemberAddString;
        private System.Windows.Forms.Button cmdMemberAddDouble;
        private System.Windows.Forms.Button cmdNewOneToMany;
        private System.Windows.Forms.Button cmdNewSingleRef;
        private System.Windows.Forms.Button cmdNewBool;
    }
}