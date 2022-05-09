using NewMethod;

namespace Rz5
{
    partial class PrintedForms
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
            this.LV = new NewMethod.nList();
            this.gbCommands = new System.Windows.Forms.GroupBox();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.oFile = new System.Windows.Forms.OpenFileDialog();
            this.gbCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // LV
            // 
            this.LV.AddCaption = "Add New";
            this.LV.AllowActions = true;
            this.LV.AllowAdd = false;
            this.LV.AllowDelete = true;
            this.LV.AllowDrop = true;
            this.LV.Caption = "";
            this.LV.CurrentTemplate = null;
            this.LV.ExtraClassInfo = "";
            this.LV.Location = new System.Drawing.Point(20, 17);
            this.LV.MultiSelect = true;
            this.LV.Name = "LV";
            this.LV.Size = new System.Drawing.Size(253, 234);
            this.LV.SuppressSelectionChanged = false;
            this.LV.TabIndex = 0;
            this.LV.zz_OpenColumnMenu = false;
            this.LV.zz_ShowAutoRefresh = true;
            this.LV.zz_ShowUnlimited = true;
            this.LV.AboutToThrow += new Core.ShowHandler(this.LV_AboutToThrow);
            // 
            // gbCommands
            // 
            this.gbCommands.Controls.Add(this.cmdExport);
            this.gbCommands.Controls.Add(this.cmdImport);
            this.gbCommands.Controls.Add(this.cmdDelete);
            this.gbCommands.Controls.Add(this.cmdNew);
            this.gbCommands.Location = new System.Drawing.Point(3, 266);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.Size = new System.Drawing.Size(389, 61);
            this.gbCommands.TabIndex = 1;
            this.gbCommands.TabStop = false;
            this.gbCommands.Text = "Commands";
            // 
            // cmdExport
            // 
            this.cmdExport.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExport.Location = new System.Drawing.Point(213, 19);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(170, 33);
            this.cmdExport.TabIndex = 1;
            this.cmdExport.Text = "Export Templates";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImport.Location = new System.Drawing.Point(130, 19);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(170, 33);
            this.cmdImport.TabIndex = 3;
            this.cmdImport.Text = "Import Templates";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelete.Location = new System.Drawing.Point(67, 19);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(170, 33);
            this.cmdDelete.TabIndex = 2;
            this.cmdDelete.Text = "Delete Selected Template";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNew.Location = new System.Drawing.Point(6, 19);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(170, 33);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Text = "Create New Template";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // oFile
            // 
            this.oFile.FileName = "openFileDialog1";
            // 
            // PrintedForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCommands);
            this.Controls.Add(this.LV);
            this.Name = "PrintedForms";
            this.Size = new System.Drawing.Size(402, 341);
            this.Resize += new System.EventHandler(this.PrintedForms_Resize);
            this.gbCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private nList LV;
        private System.Windows.Forms.GroupBox gbCommands;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.OpenFileDialog oFile;
    }
}
