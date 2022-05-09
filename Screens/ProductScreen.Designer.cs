namespace Rz5
{
    partial class ProductScreen
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
            this.lv_products = new NewMethod.nList();
            this.SuspendLayout();
            // 
            // lv_products
            // 
            this.lv_products.AddCaption = "Add New";
            this.lv_products.AllowActions = true;
            this.lv_products.AllowAdd = true;
            this.lv_products.AllowDelete = true;
            this.lv_products.AllowDeleteAlways = false;
            this.lv_products.AllowDrop = true;
            this.lv_products.AllowOnlyOpenDelete = false;
            this.lv_products.AlternateConnection = null;
            this.lv_products.BackColor = System.Drawing.Color.White;
            this.lv_products.Caption = "";
            this.lv_products.CurrentTemplate = null;
            this.lv_products.ExtraClassInfo = "";
            this.lv_products.Location = new System.Drawing.Point(3, 3);
            this.lv_products.MultiSelect = true;
            this.lv_products.Name = "lv_products";
            this.lv_products.Size = new System.Drawing.Size(391, 152);
            this.lv_products.SuppressSelectionChanged = false;
            this.lv_products.TabIndex = 2;
            this.lv_products.zz_OpenColumnMenu = false;
            this.lv_products.zz_OrderLineType = "";
            this.lv_products.zz_ShowAutoRefresh = true;
            this.lv_products.zz_ShowUnlimited = true;
            this.lv_products.AboutToThrow += new Core.ShowHandler(this.lv_products_AboutToThrow);
            this.lv_products.AboutToAdd += new NewMethod.AddHandler(this.lv_products_AboutToAdd);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lv_products);
            this.Name = "Products";
            this.Size = new System.Drawing.Size(665, 509);
            this.ResumeLayout(false);

        }

        #endregion

        private NewMethod.nList lv_products;
    }
}
