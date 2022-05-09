using System.Linq;
using System.Windows.Forms;
using NewMethod;
using Core;

namespace Rz5
{

    public partial class frmOEMProduct : Form
    {
        oem_product TheProduct;
        ContextRz x = RzWin.Context;
        public frmOEMProduct()
        {
            InitializeComponent();
        }

        public void CompleteLoad(string productID = null)
        {
            if (productID != null)
            {
                TheProduct = oem_product.GetById(x, productID);
                if (TheProduct != null)
                    LoadValues(TheProduct);
            }
            else
            {
                TheProduct = new oem_product();
            }
        }

        private void LoadValues(oem_product p)
        {
            if (p != null)
            {
                ctl_oem_product_name.SetValue(p.oem_product_name);
                ctl_oem_product_description.SetValue(p.oem_product_description);
                ctl_base_price.SetValue(p.base_price);
            }
        }

        private void SaveValues()
        {
            if (TheProduct == null)
                TheProduct = new oem_product();
            TheProduct.oem_product_name = ctl_oem_product_name.GetValue_String();
            TheProduct.oem_product_description = ctl_oem_product_description.GetValue_String();
            TheProduct.base_price = ctl_base_price.GetValue_Double();
            if (!Tools.Strings.StrExt(TheProduct.unique_id))
                TheProduct.Insert(x);
            else
                TheProduct.Update(x);
            Close();          

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveValues();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (x.Leader.AskYesNo("Are you sure you want to delete " + TheProduct.Name + "?"))
            {
                TheProduct.Delete(x);
                Close();
            }
                
        }
    }
}
