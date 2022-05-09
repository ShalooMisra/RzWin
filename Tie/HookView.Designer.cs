using System;

namespace Tie
{
    partial class HookView
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
                try
                {
                    //CurrentHook.GotMessageEvent -= new GotMessageHandler(CurrentHook_GotMessageEvent);
                    CurrentHook.GotClients += new GotClientsHandler(CurrentHook_GotClients);
                }
                catch { }

                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdDrop = new System.Windows.Forms.Button();
            this.cmdDropQuick = new System.Windows.Forms.Button();
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.cmdGetSessions = new System.Windows.Forms.Button();
            this.cmdStartPersistence = new System.Windows.Forms.Button();
            this.cmdStopPersistence = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.chkFlaky = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.optServer = new System.Windows.Forms.RadioButton();
            this.optClient = new System.Windows.Forms.RadioButton();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblClientCount = new System.Windows.Forms.Label();
            this.xView = new Tie.EndView();
            this.SuspendLayout();
            // 
            // cmdDrop
            // 
            this.cmdDrop.Location = new System.Drawing.Point(142, 18);
            this.cmdDrop.Name = "cmdDrop";
            this.cmdDrop.Size = new System.Drawing.Size(80, 22);
            this.cmdDrop.TabIndex = 6;
            this.cmdDrop.Text = "Drop [notify]";
            this.cmdDrop.UseVisualStyleBackColor = true;
            this.cmdDrop.Click += new System.EventHandler(this.cmdDrop_Click);
            // 
            // cmdDropQuick
            // 
            this.cmdDropQuick.Location = new System.Drawing.Point(142, 41);
            this.cmdDropQuick.Name = "cmdDropQuick";
            this.cmdDropQuick.Size = new System.Drawing.Size(80, 22);
            this.cmdDropQuick.TabIndex = 7;
            this.cmdDropQuick.Text = "Drop [quick]";
            this.cmdDropQuick.UseVisualStyleBackColor = true;
            this.cmdDropQuick.Click += new System.EventHandler(this.cmdDropQuick_Click);
            // 
            // lv
            // 
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lv.FullRowSelect = true;
            this.lv.Location = new System.Drawing.Point(3, 121);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(219, 325);
            this.lv.TabIndex = 8;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.SelectedIndexChanged += new System.EventHandler(this.lv_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Session";
            this.columnHeader1.Width = 422;
            // 
            // cmdGetSessions
            // 
            this.cmdGetSessions.Location = new System.Drawing.Point(8, 41);
            this.cmdGetSessions.Name = "cmdGetSessions";
            this.cmdGetSessions.Size = new System.Drawing.Size(92, 22);
            this.cmdGetSessions.TabIndex = 9;
            this.cmdGetSessions.Text = "Get Sessions";
            this.cmdGetSessions.UseVisualStyleBackColor = true;
            this.cmdGetSessions.Click += new System.EventHandler(this.cmdGetSessions_Click);
            // 
            // cmdStartPersistence
            // 
            this.cmdStartPersistence.Location = new System.Drawing.Point(8, 65);
            this.cmdStartPersistence.Name = "cmdStartPersistence";
            this.cmdStartPersistence.Size = new System.Drawing.Size(92, 22);
            this.cmdStartPersistence.TabIndex = 10;
            this.cmdStartPersistence.Text = "Start Persist";
            this.cmdStartPersistence.UseVisualStyleBackColor = true;
            this.cmdStartPersistence.Click += new System.EventHandler(this.cmdStartPersistence_Click);
            // 
            // cmdStopPersistence
            // 
            this.cmdStopPersistence.Location = new System.Drawing.Point(142, 65);
            this.cmdStopPersistence.Name = "cmdStopPersistence";
            this.cmdStopPersistence.Size = new System.Drawing.Size(80, 22);
            this.cmdStopPersistence.TabIndex = 11;
            this.cmdStopPersistence.Text = "Stop Persist";
            this.cmdStopPersistence.UseVisualStyleBackColor = true;
            this.cmdStopPersistence.Click += new System.EventHandler(this.cmdStopPersistence_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(8, 17);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(92, 22);
            this.cmdConnect.TabIndex = 12;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // chkFlaky
            // 
            this.chkFlaky.AutoSize = true;
            this.chkFlaky.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFlaky.Location = new System.Drawing.Point(171, 98);
            this.chkFlaky.Name = "chkFlaky";
            this.chkFlaky.Size = new System.Drawing.Size(51, 17);
            this.chkFlaky.TabIndex = 13;
            this.chkFlaky.Text = "Flaky";
            this.chkFlaky.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(7, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "<status>";
            // 
            // tmr
            // 
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // optServer
            // 
            this.optServer.AutoSize = true;
            this.optServer.Checked = true;
            this.optServer.Location = new System.Drawing.Point(3, 103);
            this.optServer.Name = "optServer";
            this.optServer.Size = new System.Drawing.Size(56, 17);
            this.optServer.TabIndex = 16;
            this.optServer.TabStop = true;
            this.optServer.Text = "Server";
            this.optServer.UseVisualStyleBackColor = true;
            this.optServer.CheckedChanged += new System.EventHandler(this.optServer_CheckedChanged);
            // 
            // optClient
            // 
            this.optClient.AutoSize = true;
            this.optClient.Location = new System.Drawing.Point(65, 103);
            this.optClient.Name = "optClient";
            this.optClient.Size = new System.Drawing.Size(62, 17);
            this.optClient.TabIndex = 17;
            this.optClient.Text = "<client>";
            this.optClient.UseVisualStyleBackColor = true;
            this.optClient.CheckedChanged += new System.EventHandler(this.optClient_CheckedChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(10, 3);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(35, 13);
            this.lblCaption.TabIndex = 18;
            this.lblCaption.Text = "label1";
            // 
            // lblClientCount
            // 
            this.lblClientCount.Location = new System.Drawing.Point(100, 21);
            this.lblClientCount.Name = "lblClientCount";
            this.lblClientCount.Size = new System.Drawing.Size(40, 15);
            this.lblClientCount.TabIndex = 20;
            this.lblClientCount.Text = "0";
            this.lblClientCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // xView
            // 
            this.xView.Location = new System.Drawing.Point(222, 6);
            this.xView.Name = "xView";
            this.xView.Size = new System.Drawing.Size(435, 440);
            this.xView.TabIndex = 15;
            this.xView.TargetSession = "";
            this.xView.Load += new System.EventHandler(this.xView_Load);
            // 
            // HookView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblClientCount);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.optClient);
            this.Controls.Add(this.optServer);
            this.Controls.Add(this.xView);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.cmdStopPersistence);
            this.Controls.Add(this.cmdStartPersistence);
            this.Controls.Add(this.cmdGetSessions);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.cmdDropQuick);
            this.Controls.Add(this.cmdDrop);
            this.Controls.Add(this.chkFlaky);
            this.Name = "HookView";
            this.Size = new System.Drawing.Size(658, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdDrop;
        private System.Windows.Forms.Button cmdDropQuick;
        private System.Windows.Forms.ListView lv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdGetSessions;
        private System.Windows.Forms.Button cmdStartPersistence;
        private System.Windows.Forms.Button cmdStopPersistence;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.CheckBox chkFlaky;
        private System.Windows.Forms.Label lblStatus;
        private EndView xView;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.RadioButton optServer;
        private System.Windows.Forms.RadioButton optClient;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblClientCount;
    }
}
