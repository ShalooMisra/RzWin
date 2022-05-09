namespace NewMethod
{
    partial class nText
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
            this.txt = new System.Windows.Forms.RichTextBox();
            this.gbReplace = new System.Windows.Forms.GroupBox();
            this.chkCaseSensitiveReplace = new System.Windows.Forms.CheckBox();
            this.cmdFindAndReplace = new System.Windows.Forms.Button();
            this.txtReplace = new System.Windows.Forms.TextBox();
            this.lblReplace = new System.Windows.Forms.Label();
            this.txtFindReplace = new System.Windows.Forms.TextBox();
            this.lblFind = new System.Windows.Forms.Label();
            this.gbRemove = new System.Windows.Forms.GroupBox();
            this.cmdRemoveDuplicates = new System.Windows.Forms.Button();
            this.cmdRemoveBefore = new System.Windows.Forms.Button();
            this.Trim = new System.Windows.Forms.Button();
            this.cmdRemoveCr = new System.Windows.Forms.Button();
            this.cmdRemoveAfter = new System.Windows.Forms.Button();
            this.txtRemove = new System.Windows.Forms.TextBox();
            this.cmdRemoveWithout = new System.Windows.Forms.Button();
            this.cmdRemoveWith = new System.Windows.Forms.Button();
            this.cmdRemoveAllLineBreaks = new System.Windows.Forms.Button();
            this.cmdRemoveExtraLines = new System.Windows.Forms.Button();
            this.cmdRemoveExtraSpaces = new System.Windows.Forms.Button();
            this.cmdRemoveSymbols = new System.Windows.Forms.Button();
            this.cmdRemoveNumbers = new System.Windows.Forms.Button();
            this.gbAdd = new System.Windows.Forms.GroupBox();
            this.cmdAddEnd = new System.Windows.Forms.Button();
            this.cmdAddBeginning = new System.Windows.Forms.Button();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.gbGlean = new System.Windows.Forms.GroupBox();
            this.cmdGleanEmailAddresses = new System.Windows.Forms.Button();
            this.gbTransform = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCsvColumns = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCsvSeparator = new System.Windows.Forms.TextBox();
            this.cmdCsv = new System.Windows.Forms.Button();
            this.cmdCommatize = new System.Windows.Forms.Button();
            this.cmdAlphabetize = new System.Windows.Forms.Button();
            this.cmdTransformSQLIn = new System.Windows.Forms.Button();
            this.sp = new System.Windows.Forms.SplitContainer();
            this.txtBlurbs = new System.Windows.Forms.RichTextBox();
            this.tvBlurbs = new System.Windows.Forms.TreeView();
            this.gbBreak = new System.Windows.Forms.GroupBox();
            this.cmdClearBlurbs = new System.Windows.Forms.Button();
            this.cmdBreak = new System.Windows.Forms.Button();
            this.txtBreak = new System.Windows.Forms.TextBox();
            this.parseEmailDomainButton = new System.Windows.Forms.Button();
            this.gbReplace.SuspendLayout();
            this.gbRemove.SuspendLayout();
            this.gbAdd.SuspendLayout();
            this.gbGlean.SuspendLayout();
            this.gbTransform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sp)).BeginInit();
            this.sp.Panel1.SuspendLayout();
            this.sp.Panel2.SuspendLayout();
            this.sp.SuspendLayout();
            this.gbBreak.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt.Location = new System.Drawing.Point(14, 13);
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txt.Size = new System.Drawing.Size(235, 200);
            this.txt.TabIndex = 0;
            this.txt.Text = "";
            this.txt.WordWrap = false;
            // 
            // gbReplace
            // 
            this.gbReplace.BackColor = System.Drawing.Color.White;
            this.gbReplace.Controls.Add(this.chkCaseSensitiveReplace);
            this.gbReplace.Controls.Add(this.cmdFindAndReplace);
            this.gbReplace.Controls.Add(this.txtReplace);
            this.gbReplace.Controls.Add(this.lblReplace);
            this.gbReplace.Controls.Add(this.txtFindReplace);
            this.gbReplace.Controls.Add(this.lblFind);
            this.gbReplace.Location = new System.Drawing.Point(5, 5);
            this.gbReplace.Name = "gbReplace";
            this.gbReplace.Size = new System.Drawing.Size(182, 204);
            this.gbReplace.TabIndex = 1;
            this.gbReplace.TabStop = false;
            this.gbReplace.Text = "Replace";
            // 
            // chkCaseSensitiveReplace
            // 
            this.chkCaseSensitiveReplace.AutoSize = true;
            this.chkCaseSensitiveReplace.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaseSensitiveReplace.Location = new System.Drawing.Point(3, 14);
            this.chkCaseSensitiveReplace.Name = "chkCaseSensitiveReplace";
            this.chkCaseSensitiveReplace.Size = new System.Drawing.Size(93, 17);
            this.chkCaseSensitiveReplace.TabIndex = 5;
            this.chkCaseSensitiveReplace.Text = "Case Sensitive";
            this.chkCaseSensitiveReplace.UseVisualStyleBackColor = true;
            // 
            // cmdFindAndReplace
            // 
            this.cmdFindAndReplace.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdFindAndReplace.Location = new System.Drawing.Point(6, 172);
            this.cmdFindAndReplace.Name = "cmdFindAndReplace";
            this.cmdFindAndReplace.Size = new System.Drawing.Size(168, 28);
            this.cmdFindAndReplace.TabIndex = 4;
            this.cmdFindAndReplace.Text = "Find And Replace";
            this.cmdFindAndReplace.UseVisualStyleBackColor = true;
            this.cmdFindAndReplace.Click += new System.EventHandler(this.cmdFindAndReplace_Click);
            // 
            // txtReplace
            // 
            this.txtReplace.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReplace.Location = new System.Drawing.Point(3, 109);
            this.txtReplace.Multiline = true;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReplace.Size = new System.Drawing.Size(179, 59);
            this.txtReplace.TabIndex = 3;
            this.txtReplace.WordWrap = false;
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Location = new System.Drawing.Point(132, 93);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(47, 13);
            this.lblReplace.TabIndex = 2;
            this.lblReplace.Text = "Replace";
            // 
            // txtFindReplace
            // 
            this.txtFindReplace.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindReplace.Location = new System.Drawing.Point(0, 32);
            this.txtFindReplace.Multiline = true;
            this.txtFindReplace.Name = "txtFindReplace";
            this.txtFindReplace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFindReplace.Size = new System.Drawing.Size(179, 59);
            this.txtFindReplace.TabIndex = 1;
            this.txtFindReplace.WordWrap = false;
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Location = new System.Drawing.Point(148, 16);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(27, 13);
            this.lblFind.TabIndex = 0;
            this.lblFind.Text = "Find";
            // 
            // gbRemove
            // 
            this.gbRemove.BackColor = System.Drawing.Color.White;
            this.gbRemove.Controls.Add(this.cmdRemoveDuplicates);
            this.gbRemove.Controls.Add(this.cmdRemoveBefore);
            this.gbRemove.Controls.Add(this.Trim);
            this.gbRemove.Controls.Add(this.cmdRemoveCr);
            this.gbRemove.Controls.Add(this.cmdRemoveAfter);
            this.gbRemove.Controls.Add(this.txtRemove);
            this.gbRemove.Controls.Add(this.cmdRemoveWithout);
            this.gbRemove.Controls.Add(this.cmdRemoveWith);
            this.gbRemove.Controls.Add(this.cmdRemoveAllLineBreaks);
            this.gbRemove.Controls.Add(this.cmdRemoveExtraLines);
            this.gbRemove.Controls.Add(this.cmdRemoveExtraSpaces);
            this.gbRemove.Controls.Add(this.cmdRemoveSymbols);
            this.gbRemove.Controls.Add(this.cmdRemoveNumbers);
            this.gbRemove.Location = new System.Drawing.Point(5, 215);
            this.gbRemove.Name = "gbRemove";
            this.gbRemove.Size = new System.Drawing.Size(182, 206);
            this.gbRemove.TabIndex = 2;
            this.gbRemove.TabStop = false;
            this.gbRemove.Text = "Remove";
            // 
            // cmdRemoveDuplicates
            // 
            this.cmdRemoveDuplicates.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveDuplicates.Location = new System.Drawing.Point(89, 80);
            this.cmdRemoveDuplicates.Name = "cmdRemoveDuplicates";
            this.cmdRemoveDuplicates.Size = new System.Drawing.Size(85, 20);
            this.cmdRemoveDuplicates.TabIndex = 17;
            this.cmdRemoveDuplicates.Text = "Duplicates";
            this.cmdRemoveDuplicates.UseVisualStyleBackColor = true;
            this.cmdRemoveDuplicates.Click += new System.EventHandler(this.cmdRemoveDuplicates_Click);
            // 
            // cmdRemoveBefore
            // 
            this.cmdRemoveBefore.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveBefore.Location = new System.Drawing.Point(6, 163);
            this.cmdRemoveBefore.Name = "cmdRemoveBefore";
            this.cmdRemoveBefore.Size = new System.Drawing.Size(99, 20);
            this.cmdRemoveBefore.TabIndex = 16;
            this.cmdRemoveBefore.Text = "Remove Before";
            this.cmdRemoveBefore.UseVisualStyleBackColor = true;
            this.cmdRemoveBefore.Click += new System.EventHandler(this.cmdRemoveBefore_Click);
            // 
            // Trim
            // 
            this.Trim.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trim.Location = new System.Drawing.Point(89, 37);
            this.Trim.Name = "Trim";
            this.Trim.Size = new System.Drawing.Size(83, 21);
            this.Trim.TabIndex = 15;
            this.Trim.Text = "Trim";
            this.Trim.UseVisualStyleBackColor = true;
            this.Trim.Click += new System.EventHandler(this.Trim_Click);
            // 
            // cmdRemoveCr
            // 
            this.cmdRemoveCr.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveCr.Location = new System.Drawing.Point(89, 16);
            this.cmdRemoveCr.Name = "cmdRemoveCr";
            this.cmdRemoveCr.Size = new System.Drawing.Size(83, 21);
            this.cmdRemoveCr.TabIndex = 14;
            this.cmdRemoveCr.Text = "CR";
            this.cmdRemoveCr.UseVisualStyleBackColor = true;
            this.cmdRemoveCr.Click += new System.EventHandler(this.cmdRemoveCr_Click);
            // 
            // cmdRemoveAfter
            // 
            this.cmdRemoveAfter.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveAfter.Location = new System.Drawing.Point(6, 182);
            this.cmdRemoveAfter.Name = "cmdRemoveAfter";
            this.cmdRemoveAfter.Size = new System.Drawing.Size(99, 20);
            this.cmdRemoveAfter.TabIndex = 13;
            this.cmdRemoveAfter.Text = "Remove After";
            this.cmdRemoveAfter.UseVisualStyleBackColor = true;
            this.cmdRemoveAfter.Click += new System.EventHandler(this.cmdRemoveAfter_Click);
            // 
            // txtRemove
            // 
            this.txtRemove.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemove.Location = new System.Drawing.Point(109, 139);
            this.txtRemove.Name = "txtRemove";
            this.txtRemove.Size = new System.Drawing.Size(67, 21);
            this.txtRemove.TabIndex = 12;
            // 
            // cmdRemoveWithout
            // 
            this.cmdRemoveWithout.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveWithout.Location = new System.Drawing.Point(6, 144);
            this.cmdRemoveWithout.Name = "cmdRemoveWithout";
            this.cmdRemoveWithout.Size = new System.Drawing.Size(99, 20);
            this.cmdRemoveWithout.TabIndex = 11;
            this.cmdRemoveWithout.Text = "Remove Without";
            this.cmdRemoveWithout.UseVisualStyleBackColor = true;
            this.cmdRemoveWithout.Click += new System.EventHandler(this.cmdRemoveWithout_Click);
            // 
            // cmdRemoveWith
            // 
            this.cmdRemoveWith.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveWith.Location = new System.Drawing.Point(6, 125);
            this.cmdRemoveWith.Name = "cmdRemoveWith";
            this.cmdRemoveWith.Size = new System.Drawing.Size(99, 20);
            this.cmdRemoveWith.TabIndex = 10;
            this.cmdRemoveWith.Text = "Remove With";
            this.cmdRemoveWith.UseVisualStyleBackColor = true;
            this.cmdRemoveWith.Click += new System.EventHandler(this.cmdRemoveWith_Click);
            // 
            // cmdRemoveAllLineBreaks
            // 
            this.cmdRemoveAllLineBreaks.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveAllLineBreaks.Location = new System.Drawing.Point(7, 102);
            this.cmdRemoveAllLineBreaks.Name = "cmdRemoveAllLineBreaks";
            this.cmdRemoveAllLineBreaks.Size = new System.Drawing.Size(168, 20);
            this.cmdRemoveAllLineBreaks.TabIndex = 9;
            this.cmdRemoveAllLineBreaks.Text = "All Line Breaks";
            this.cmdRemoveAllLineBreaks.UseVisualStyleBackColor = true;
            this.cmdRemoveAllLineBreaks.Click += new System.EventHandler(this.cmdRemoveAllLineBreaks_Click);
            // 
            // cmdRemoveExtraLines
            // 
            this.cmdRemoveExtraLines.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveExtraLines.Location = new System.Drawing.Point(7, 80);
            this.cmdRemoveExtraLines.Name = "cmdRemoveExtraLines";
            this.cmdRemoveExtraLines.Size = new System.Drawing.Size(76, 20);
            this.cmdRemoveExtraLines.TabIndex = 8;
            this.cmdRemoveExtraLines.Text = "Extra Lines";
            this.cmdRemoveExtraLines.UseVisualStyleBackColor = true;
            this.cmdRemoveExtraLines.Click += new System.EventHandler(this.cmdRemoveExtraLines_Click);
            // 
            // cmdRemoveExtraSpaces
            // 
            this.cmdRemoveExtraSpaces.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveExtraSpaces.Location = new System.Drawing.Point(7, 59);
            this.cmdRemoveExtraSpaces.Name = "cmdRemoveExtraSpaces";
            this.cmdRemoveExtraSpaces.Size = new System.Drawing.Size(168, 20);
            this.cmdRemoveExtraSpaces.TabIndex = 7;
            this.cmdRemoveExtraSpaces.Text = "Extra Spaces";
            this.cmdRemoveExtraSpaces.UseVisualStyleBackColor = true;
            this.cmdRemoveExtraSpaces.Click += new System.EventHandler(this.cmdRemoveExtraSpaces_Click);
            // 
            // cmdRemoveSymbols
            // 
            this.cmdRemoveSymbols.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveSymbols.Location = new System.Drawing.Point(7, 37);
            this.cmdRemoveSymbols.Name = "cmdRemoveSymbols";
            this.cmdRemoveSymbols.Size = new System.Drawing.Size(76, 21);
            this.cmdRemoveSymbols.TabIndex = 6;
            this.cmdRemoveSymbols.Text = "Symbols";
            this.cmdRemoveSymbols.UseVisualStyleBackColor = true;
            this.cmdRemoveSymbols.Click += new System.EventHandler(this.cmdRemoveSymbols_Click);
            // 
            // cmdRemoveNumbers
            // 
            this.cmdRemoveNumbers.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRemoveNumbers.Location = new System.Drawing.Point(7, 15);
            this.cmdRemoveNumbers.Name = "cmdRemoveNumbers";
            this.cmdRemoveNumbers.Size = new System.Drawing.Size(76, 21);
            this.cmdRemoveNumbers.TabIndex = 5;
            this.cmdRemoveNumbers.Text = "Numbers";
            this.cmdRemoveNumbers.UseVisualStyleBackColor = true;
            this.cmdRemoveNumbers.Click += new System.EventHandler(this.cmdRemoveNumbers_Click);
            // 
            // gbAdd
            // 
            this.gbAdd.BackColor = System.Drawing.Color.White;
            this.gbAdd.Controls.Add(this.cmdAddEnd);
            this.gbAdd.Controls.Add(this.cmdAddBeginning);
            this.gbAdd.Controls.Add(this.txtAdd);
            this.gbAdd.Location = new System.Drawing.Point(5, 423);
            this.gbAdd.Name = "gbAdd";
            this.gbAdd.Size = new System.Drawing.Size(182, 132);
            this.gbAdd.TabIndex = 3;
            this.gbAdd.TabStop = false;
            this.gbAdd.Text = "Add";
            // 
            // cmdAddEnd
            // 
            this.cmdAddEnd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddEnd.Location = new System.Drawing.Point(7, 106);
            this.cmdAddEnd.Name = "cmdAddEnd";
            this.cmdAddEnd.Size = new System.Drawing.Size(168, 20);
            this.cmdAddEnd.TabIndex = 10;
            this.cmdAddEnd.Text = "Each Line End";
            this.cmdAddEnd.UseVisualStyleBackColor = true;
            this.cmdAddEnd.Click += new System.EventHandler(this.cmdAddEnd_Click);
            // 
            // cmdAddBeginning
            // 
            this.cmdAddBeginning.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAddBeginning.Location = new System.Drawing.Point(7, 84);
            this.cmdAddBeginning.Name = "cmdAddBeginning";
            this.cmdAddBeginning.Size = new System.Drawing.Size(168, 20);
            this.cmdAddBeginning.TabIndex = 9;
            this.cmdAddBeginning.Text = "Each Line Start";
            this.cmdAddBeginning.UseVisualStyleBackColor = true;
            this.cmdAddBeginning.Click += new System.EventHandler(this.cmdAddBeginning_Click);
            // 
            // txtAdd
            // 
            this.txtAdd.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd.Location = new System.Drawing.Point(3, 19);
            this.txtAdd.Multiline = true;
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAdd.Size = new System.Drawing.Size(179, 59);
            this.txtAdd.TabIndex = 4;
            this.txtAdd.WordWrap = false;
            // 
            // gbGlean
            // 
            this.gbGlean.Controls.Add(this.cmdGleanEmailAddresses);
            this.gbGlean.Location = new System.Drawing.Point(193, 170);
            this.gbGlean.Name = "gbGlean";
            this.gbGlean.Size = new System.Drawing.Size(182, 45);
            this.gbGlean.TabIndex = 4;
            this.gbGlean.TabStop = false;
            this.gbGlean.Text = "Glean";
            // 
            // cmdGleanEmailAddresses
            // 
            this.cmdGleanEmailAddresses.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGleanEmailAddresses.Location = new System.Drawing.Point(7, 19);
            this.cmdGleanEmailAddresses.Name = "cmdGleanEmailAddresses";
            this.cmdGleanEmailAddresses.Size = new System.Drawing.Size(168, 20);
            this.cmdGleanEmailAddresses.TabIndex = 11;
            this.cmdGleanEmailAddresses.Text = "Email Addresses";
            this.cmdGleanEmailAddresses.UseVisualStyleBackColor = true;
            this.cmdGleanEmailAddresses.Click += new System.EventHandler(this.cmdGleanEmailAddresses_Click);
            // 
            // gbTransform
            // 
            this.gbTransform.BackColor = System.Drawing.Color.White;
            this.gbTransform.Controls.Add(this.parseEmailDomainButton);
            this.gbTransform.Controls.Add(this.label2);
            this.gbTransform.Controls.Add(this.txtCsvColumns);
            this.gbTransform.Controls.Add(this.label1);
            this.gbTransform.Controls.Add(this.txtCsvSeparator);
            this.gbTransform.Controls.Add(this.cmdCsv);
            this.gbTransform.Controls.Add(this.cmdCommatize);
            this.gbTransform.Controls.Add(this.cmdAlphabetize);
            this.gbTransform.Controls.Add(this.cmdTransformSQLIn);
            this.gbTransform.Location = new System.Drawing.Point(193, 221);
            this.gbTransform.Name = "gbTransform";
            this.gbTransform.Size = new System.Drawing.Size(182, 154);
            this.gbTransform.TabIndex = 5;
            this.gbTransform.TabStop = false;
            this.gbTransform.Text = "Transform";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Column Count";
            // 
            // txtCsvColumns
            // 
            this.txtCsvColumns.Location = new System.Drawing.Point(108, 125);
            this.txtCsvColumns.Name = "txtCsvColumns";
            this.txtCsvColumns.Size = new System.Drawing.Size(67, 20);
            this.txtCsvColumns.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Separator";
            // 
            // txtCsvSeparator
            // 
            this.txtCsvSeparator.Location = new System.Drawing.Point(10, 125);
            this.txtCsvSeparator.Name = "txtCsvSeparator";
            this.txtCsvSeparator.Size = new System.Drawing.Size(67, 20);
            this.txtCsvSeparator.TabIndex = 15;
            // 
            // cmdCsv
            // 
            this.cmdCsv.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCsv.Location = new System.Drawing.Point(9, 84);
            this.cmdCsv.Name = "cmdCsv";
            this.cmdCsv.Size = new System.Drawing.Size(166, 20);
            this.cmdCsv.TabIndex = 14;
            this.cmdCsv.Text = ".Csv";
            this.cmdCsv.UseVisualStyleBackColor = true;
            this.cmdCsv.Click += new System.EventHandler(this.cmdCsv_Click);
            // 
            // cmdCommatize
            // 
            this.cmdCommatize.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCommatize.Location = new System.Drawing.Point(100, 15);
            this.cmdCommatize.Name = "cmdCommatize";
            this.cmdCommatize.Size = new System.Drawing.Size(76, 20);
            this.cmdCommatize.TabIndex = 13;
            this.cmdCommatize.Text = "Commatize";
            this.cmdCommatize.UseVisualStyleBackColor = true;
            this.cmdCommatize.Click += new System.EventHandler(this.cmdCommatize_Click);
            // 
            // cmdAlphabetize
            // 
            this.cmdAlphabetize.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAlphabetize.Location = new System.Drawing.Point(7, 15);
            this.cmdAlphabetize.Name = "cmdAlphabetize";
            this.cmdAlphabetize.Size = new System.Drawing.Size(76, 20);
            this.cmdAlphabetize.TabIndex = 12;
            this.cmdAlphabetize.Text = "Alphabetize";
            this.cmdAlphabetize.UseVisualStyleBackColor = true;
            this.cmdAlphabetize.Click += new System.EventHandler(this.cmdAlphabetize_Click);
            // 
            // cmdTransformSQLIn
            // 
            this.cmdTransformSQLIn.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdTransformSQLIn.Location = new System.Drawing.Point(8, 37);
            this.cmdTransformSQLIn.Name = "cmdTransformSQLIn";
            this.cmdTransformSQLIn.Size = new System.Drawing.Size(168, 20);
            this.cmdTransformSQLIn.TabIndex = 11;
            this.cmdTransformSQLIn.Text = "SQL \'In\'";
            this.cmdTransformSQLIn.UseVisualStyleBackColor = true;
            this.cmdTransformSQLIn.Click += new System.EventHandler(this.cmdTransformSQLIn_Click);
            // 
            // sp
            // 
            this.sp.Location = new System.Drawing.Point(381, 5);
            this.sp.Name = "sp";
            this.sp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sp.Panel1
            // 
            this.sp.Panel1.BackColor = System.Drawing.Color.White;
            this.sp.Panel1.Controls.Add(this.txt);
            // 
            // sp.Panel2
            // 
            this.sp.Panel2.Controls.Add(this.txtBlurbs);
            this.sp.Panel2.Controls.Add(this.tvBlurbs);
            this.sp.Size = new System.Drawing.Size(656, 906);
            this.sp.SplitterDistance = 723;
            this.sp.TabIndex = 6;
            this.sp.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.sp_SplitterMoved);
            // 
            // txtBlurbs
            // 
            this.txtBlurbs.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlurbs.Location = new System.Drawing.Point(311, 15);
            this.txtBlurbs.Name = "txtBlurbs";
            this.txtBlurbs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.txtBlurbs.Size = new System.Drawing.Size(273, 137);
            this.txtBlurbs.TabIndex = 1;
            this.txtBlurbs.Text = "";
            this.txtBlurbs.WordWrap = false;
            // 
            // tvBlurbs
            // 
            this.tvBlurbs.Location = new System.Drawing.Point(14, 15);
            this.tvBlurbs.Name = "tvBlurbs";
            this.tvBlurbs.Size = new System.Drawing.Size(280, 137);
            this.tvBlurbs.TabIndex = 0;
            // 
            // gbBreak
            // 
            this.gbBreak.BackColor = System.Drawing.Color.White;
            this.gbBreak.Controls.Add(this.cmdClearBlurbs);
            this.gbBreak.Controls.Add(this.cmdBreak);
            this.gbBreak.Controls.Add(this.txtBreak);
            this.gbBreak.Location = new System.Drawing.Point(193, 5);
            this.gbBreak.Name = "gbBreak";
            this.gbBreak.Size = new System.Drawing.Size(182, 159);
            this.gbBreak.TabIndex = 7;
            this.gbBreak.TabStop = false;
            this.gbBreak.Text = "Break";
            // 
            // cmdClearBlurbs
            // 
            this.cmdClearBlurbs.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdClearBlurbs.Location = new System.Drawing.Point(6, 123);
            this.cmdClearBlurbs.Name = "cmdClearBlurbs";
            this.cmdClearBlurbs.Size = new System.Drawing.Size(167, 24);
            this.cmdClearBlurbs.TabIndex = 7;
            this.cmdClearBlurbs.Text = "Clear Blurbs";
            this.cmdClearBlurbs.UseVisualStyleBackColor = true;
            this.cmdClearBlurbs.Click += new System.EventHandler(this.cmdClearBlurbs_Click);
            // 
            // cmdBreak
            // 
            this.cmdBreak.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBreak.Location = new System.Drawing.Point(6, 93);
            this.cmdBreak.Name = "cmdBreak";
            this.cmdBreak.Size = new System.Drawing.Size(167, 24);
            this.cmdBreak.TabIndex = 6;
            this.cmdBreak.Text = "Break Into Blurbs";
            this.cmdBreak.UseVisualStyleBackColor = true;
            this.cmdBreak.Click += new System.EventHandler(this.cmdBreak_Click);
            // 
            // txtBreak
            // 
            this.txtBreak.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBreak.Location = new System.Drawing.Point(3, 19);
            this.txtBreak.Multiline = true;
            this.txtBreak.Name = "txtBreak";
            this.txtBreak.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBreak.Size = new System.Drawing.Size(179, 68);
            this.txtBreak.TabIndex = 5;
            this.txtBreak.WordWrap = false;
            // 
            // parseEmailDomainButton
            // 
            this.parseEmailDomainButton.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parseEmailDomainButton.Location = new System.Drawing.Point(7, 60);
            this.parseEmailDomainButton.Name = "parseEmailDomainButton";
            this.parseEmailDomainButton.Size = new System.Drawing.Size(168, 20);
            this.parseEmailDomainButton.TabIndex = 19;
            this.parseEmailDomainButton.Text = "Parse Email Domain";
            this.parseEmailDomainButton.UseVisualStyleBackColor = true;
            this.parseEmailDomainButton.Click += new System.EventHandler(this.parseEmailDomainButton_Click);
            // 
            // nText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbBreak);
            this.Controls.Add(this.sp);
            this.Controls.Add(this.gbTransform);
            this.Controls.Add(this.gbGlean);
            this.Controls.Add(this.gbAdd);
            this.Controls.Add(this.gbRemove);
            this.Controls.Add(this.gbReplace);
            this.Name = "nText";
            this.Size = new System.Drawing.Size(1064, 928);
            this.Resize += new System.EventHandler(this.nText_Resize);
            this.gbReplace.ResumeLayout(false);
            this.gbReplace.PerformLayout();
            this.gbRemove.ResumeLayout(false);
            this.gbRemove.PerformLayout();
            this.gbAdd.ResumeLayout(false);
            this.gbAdd.PerformLayout();
            this.gbGlean.ResumeLayout(false);
            this.gbTransform.ResumeLayout(false);
            this.gbTransform.PerformLayout();
            this.sp.Panel1.ResumeLayout(false);
            this.sp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sp)).EndInit();
            this.sp.ResumeLayout(false);
            this.gbBreak.ResumeLayout(false);
            this.gbBreak.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txt;
        private System.Windows.Forms.GroupBox gbReplace;
        private System.Windows.Forms.TextBox txtFindReplace;
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button cmdFindAndReplace;
        private System.Windows.Forms.TextBox txtReplace;
        private System.Windows.Forms.Label lblReplace;
        private System.Windows.Forms.CheckBox chkCaseSensitiveReplace;
        private System.Windows.Forms.GroupBox gbRemove;
        private System.Windows.Forms.Button cmdRemoveSymbols;
        private System.Windows.Forms.Button cmdRemoveNumbers;
        private System.Windows.Forms.Button cmdRemoveExtraSpaces;
        private System.Windows.Forms.Button cmdRemoveExtraLines;
        private System.Windows.Forms.GroupBox gbAdd;
        private System.Windows.Forms.Button cmdAddEnd;
        private System.Windows.Forms.Button cmdAddBeginning;
        private System.Windows.Forms.TextBox txtAdd;
        private System.Windows.Forms.Button cmdRemoveAllLineBreaks;
        private System.Windows.Forms.GroupBox gbGlean;
        private System.Windows.Forms.Button cmdGleanEmailAddresses;
        private System.Windows.Forms.GroupBox gbTransform;
        private System.Windows.Forms.Button cmdTransformSQLIn;
        private System.Windows.Forms.Button cmdAlphabetize;
        private System.Windows.Forms.Button cmdRemoveWithout;
        private System.Windows.Forms.Button cmdRemoveWith;
        private System.Windows.Forms.TextBox txtRemove;
        private System.Windows.Forms.Button cmdRemoveAfter;
        private System.Windows.Forms.SplitContainer sp;
        private System.Windows.Forms.RichTextBox txtBlurbs;
        private System.Windows.Forms.TreeView tvBlurbs;
        private System.Windows.Forms.GroupBox gbBreak;
        private System.Windows.Forms.Button cmdBreak;
        private System.Windows.Forms.TextBox txtBreak;
        private System.Windows.Forms.Button cmdClearBlurbs;
        private System.Windows.Forms.Button Trim;
        private System.Windows.Forms.Button cmdRemoveCr;
        private System.Windows.Forms.Button cmdRemoveBefore;
        private System.Windows.Forms.Button cmdRemoveDuplicates;
        private System.Windows.Forms.Button cmdCommatize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCsvColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCsvSeparator;
        private System.Windows.Forms.Button cmdCsv;
        private System.Windows.Forms.Button parseEmailDomainButton;
    }
}
