using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ProductScreen : UserControl
    {
        public ProductScreen()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            DoResize();
            loadProductsLv();
        }

        private void loadProductsLv()
        {
            lv_products.ShowTemplate("oem_product", "oem_product");
            lv_products.ShowData("oem_product", null, "oem_product_name");
        }

        public void DoResize()
        {
            DoResize(false);
        }
        public void DoResize(Boolean split)
        {
            try
            {
                lv_products.Top = 2;
                lv_products.Left = 2;
                lv_products.Width = 400;
                lv_products.Height = 600;

            }
            catch
            { }
        }

        private void lv_products_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            RzWin.Leader.ShowOEMProductForm(RzWin.Context, args);
        }

        private void lv_products_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;            
            frmOEMProduct op = new frmOEMProduct();
            op.CompleteLoad(lv_products.GetSelectedID());
            op.Show();
        }

        
    }
}
