namespace Rz5.Win.Screens
{
    partial class ConvertToRz4
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
            this.cmdConvert = new System.Windows.Forms.Button();
            this.bwNowTo2009 = new System.ComponentModel.BackgroundWorker();
            this.throb = new NewMethod.nThrobber();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.txt = new System.Windows.Forms.RichTextBox();
            this.bwPrepare = new System.ComponentModel.BackgroundWorker();
            this.cmdOrderInstances = new System.Windows.Forms.Button();
            this.bgwReSave = new System.ComponentModel.BackgroundWorker();
            this.cmdPrep = new System.Windows.Forms.Button();
            this.cmdConvert2 = new System.Windows.Forms.Button();
            this.cmdfinish = new System.Windows.Forms.Button();
            this.bw2009To2005 = new System.ComponentModel.BackgroundWorker();
            this.bgFinish = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // cmdConvert
            // 
            this.cmdConvert.Location = new System.Drawing.Point(3, 102);
            this.cmdConvert.Name = "cmdConvert";
            this.cmdConvert.Size = new System.Drawing.Size(158, 45);
            this.cmdConvert.TabIndex = 0;
            this.cmdConvert.Text = "Now To 2009";
            this.cmdConvert.UseVisualStyleBackColor = true;
            this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
            // 
            // bwNowTo2009
            // 
            this.bwNowTo2009.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            this.bwNowTo2009.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
            // 
            // throb
            // 
            this.throb.BackColor = System.Drawing.Color.Maroon;
            this.throb.Location = new System.Drawing.Point(51, 6);
            this.throb.Name = "throb";
            this.throb.Size = new System.Drawing.Size(51, 39);
            this.throb.TabIndex = 2;
            this.throb.UseParentBackColor = false;
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(179, 6);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(491, 18);
            this.pb.TabIndex = 3;
            // 
            // txt
            // 
            this.txt.Location = new System.Drawing.Point(180, 30);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(489, 440);
            this.txt.TabIndex = 4;
            this.txt.Text = "";
            // 
            // bwPrepare
            // 
            this.bwPrepare.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPrepare_DoWork);
            this.bwPrepare.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPrepare_RunWorkerCompleted);
            // 
            // cmdOrderInstances
            // 
            this.cmdOrderInstances.Location = new System.Drawing.Point(3, 255);
            this.cmdOrderInstances.Name = "cmdOrderInstances";
            this.cmdOrderInstances.Size = new System.Drawing.Size(158, 45);
            this.cmdOrderInstances.TabIndex = 5;
            this.cmdOrderInstances.Text = "ReSave Order Instances";
            this.cmdOrderInstances.UseVisualStyleBackColor = true;
            this.cmdOrderInstances.Click += new System.EventHandler(this.cmdOrderInstances_Click);
            // 
            // bgwReSave
            // 
            this.bgwReSave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwReSave_DoWork);
            this.bgwReSave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwReSave_RunWorkerCompleted);
            // 
            // cmdPrep
            // 
            this.cmdPrep.Location = new System.Drawing.Point(3, 51);
            this.cmdPrep.Name = "cmdPrep";
            this.cmdPrep.Size = new System.Drawing.Size(158, 45);
            this.cmdPrep.TabIndex = 6;
            this.cmdPrep.Text = "Start DB Prep";
            this.cmdPrep.UseVisualStyleBackColor = true;
            this.cmdPrep.Click += new System.EventHandler(this.cmdPrep_Click);
            // 
            // cmdConvert2
            // 
            this.cmdConvert2.Location = new System.Drawing.Point(3, 153);
            this.cmdConvert2.Name = "cmdConvert2";
            this.cmdConvert2.Size = new System.Drawing.Size(158, 45);
            this.cmdConvert2.TabIndex = 7;
            this.cmdConvert2.Text = "2009 To 2005";
            this.cmdConvert2.UseVisualStyleBackColor = true;
            this.cmdConvert2.Click += new System.EventHandler(this.cmdConvert2_Click);
            // 
            // cmdfinish
            // 
            this.cmdfinish.Location = new System.Drawing.Point(3, 204);
            this.cmdfinish.Name = "cmdfinish";
            this.cmdfinish.Size = new System.Drawing.Size(158, 45);
            this.cmdfinish.TabIndex = 8;
            this.cmdfinish.Text = "Finish";
            this.cmdfinish.UseVisualStyleBackColor = true;
            this.cmdfinish.Click += new System.EventHandler(this.cmdfinish_Click);
            // 
            // bw2009To2005
            // 
            this.bw2009To2005.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw2009To2005_DoWork);
            this.bw2009To2005.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw2009To2005_RunWorkerCompleted);
            // 
            // bgFinish
            // 
            this.bgFinish.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgFinish_DoWork);
            this.bgFinish.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgFinish_RunWorkerCompleted);
            // 
            // ConvertToRz4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmdfinish);
            this.Controls.Add(this.cmdConvert2);
            this.Controls.Add(this.cmdPrep);
            this.Controls.Add(this.cmdOrderInstances);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.throb);
            this.Controls.Add(this.cmdConvert);
            this.Name = "ConvertToRz4";
            this.Size = new System.Drawing.Size(719, 508);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdConvert;
        private System.ComponentModel.BackgroundWorker bwNowTo2009;
        private NewMethod.nThrobber throb;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.RichTextBox txt;
        private System.ComponentModel.BackgroundWorker bwPrepare;
        private System.Windows.Forms.Button cmdOrderInstances;
        private System.ComponentModel.BackgroundWorker bgwReSave;
        private System.Windows.Forms.Button cmdPrep;
        private System.Windows.Forms.Button cmdConvert2;
        private System.Windows.Forms.Button cmdfinish;
        private System.ComponentModel.BackgroundWorker bw2009To2005;
        private System.ComponentModel.BackgroundWorker bgFinish;
    }
}
