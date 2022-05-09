using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmOwnerSettings : Form
    {
        public frmOwnerSettings()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            LoadSettings();
        }
        //Private Functions
        private void SaveSettings()
        {
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_companyname, txtCompanyName.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_address1, txtAddress1.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_address2, txtAddress2.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_city, txtCity.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_state, txtState.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_zip, txtZip.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_phone, txtPhone.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_fax, txtFax.GetValue_String());
            OwnerSettings.SetValue(RzWin.Context, OwnerSettingField.owner_country, cboCountry.GetValue_String());
            RzWin.Logic.SetInternalUPS(RzWin.Context, txtUPS.GetValue_String());
            RzWin.Logic.SetInternalFedex(RzWin.Context, txtFedex.GetValue_String());
            RzWin.Logic.SetInternalDHL(RzWin.Context, txtDHL.GetValue_String());


            this.Close();
        }
        private void LoadSettings()
        {
            txtCompanyName.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_companyname));
            txtAddress1.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_address1));
            txtAddress2.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_address2));
            txtCity.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_city));
            txtState.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_state));
            txtZip.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_zip));
            txtPhone.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_phone));
            txtFax.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_fax));
            cboCountry.SetValue(OwnerSettings.GetValue(RzWin.Context, OwnerSettingField.owner_country));
            txtUPS.SetValue(RzWin.Logic.InternalUPS);
            txtFedex.SetValue(RzWin.Logic.InternalFedex);
            txtDHL.SetValue(RzWin.Logic.InternalDHL);
            txtWidth.zz_Text = "240";
            txtHeight.zz_Text = "120";
            LoadCompanyLogo(RzWin.Context);

        }

        private void LoadCompanyLogo(ContextRz x)
        {
            txtOwnerLogoUrl.zz_Text = OwnerSettings.GetValue(x, OwnerSettingField.company_logo_url, false);
            string path = OwnerSettings.GetCompanyLogoPath(x);
            if (string.IsNullOrEmpty(path))
                throw new Exception("Path cannot be empty.");
            //if (File.Exists(path))
            //    pbOwnerLogo.Image = Image.FromFile(path);
            Image i = null;
            if (File.Exists(path))
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    i = Image.FromStream(stream);
                    
                }
            if (i == null)
                return;
            pbOwnerLogo.Image = i;
            int height = i.Height;
            int width = i.Width;
            txtHeight.SetValue(height);
            txtWidth.SetValue(width);

        }

        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }


        private void UpdateCompanyLogo(ContextRz x)
        {

            throw new NotImplementedException();
            //string strFilePath = null;
            //string url = txtOwnerLogoUrl.GetValue_String();



            //////Check to see if the file already exists
            ////if (File.Exists(strFilePath))
            ////    return;



            ////This method will GEt the logo path            
            ////Tools.Picture.GetFilePathFromLogoUrl(url, out strFilePath);


            ////Create the temp file and resize based on the width and height parameter
            //Image i = Tools.Picture.CreateImageFromUrl(url);

            ////Get the image Type for the Memorystream Save
            //ImageFormat f = Tools.Picture.GetImageFormat(strFilePath);

            ////Get the size from the textbox
            //int height = Convert.ToInt32(txtHeight.GetValue_String());
            //int width = Convert.ToInt32(txtWidth.GetValue_String());
            //Size size = new Size(width, height);

            ////Resize the Compan Logo to a common size for Printed forms uniformity.            
            //Image resized = Tools.Picture.ResizeImage(i, size);


            //OwnerSettings.SetValue(x, OwnerSettingField.company_logo_url, url);
            //string currentUrl = OwnerSettings.GetValue(x, "company_logo_url");            
            ////partpicture.fullpartnumber =  40a2d1b4-33ec-4201-9a1a-98ff2ecddfd2
            //partpicture p = (partpicture)x.QtO("partpicture", "select * from partpicture where fullpartnumber = '" + currentUrl + "'");

            //string companyLogoUid = "1dc36dbc05694dc28d361f9f7fa141e8";
            //if (p == null)
            //{               

            //    p = partpicture.New(RzWin.Context);
            //    p.fullpartnumber = currentUrl;
            //    p.Insert(x);   
            //}            
            
            //p.SetPictureDataByImage(x, resized, strFilePath);

            //p.SaveDataAsFile(x, strFilePath, false);

            //if(p.unique_id != companyLogoUid)
            //{
            //    //Delete existing company logo with uid
            //    partpicture existing = (partpicture)x.QtO("partpicture", "select * from partpicture where unique_id = '" + companyLogoUid + "'");
            //    if (existing != null)
            //        existing.Delete(x);

            //    //Set common uid for this logo.
            //    p.unique_id = companyLogoUid;
            //    p.Update(x);

            //}

            //string url = txtOwnerLogoUrl.GetValue_String();


        }



        private void btn_SaveCompanyLogo_Click(object sender, EventArgs e)
        {
            try
            {
                ContextRz x = RzWin.Context;
                UpdateCompanyLogo(x);
                LoadCompanyLogo(x);
                //RzWin.Leader.Tell("Successfully Updated the Company Logo.");
            }

            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }

        }
    }
}