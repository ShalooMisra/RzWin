using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;
using Rz5;
using System;
using System.Collections;

namespace Rz5
{
    public partial class view_validation_form : Form
    {
        private ordhed_sales CurrentSalesOrder = null;
        private validation_form vf = null;
        private ContextRz x = null;
        //Constructors      
        public view_validation_form(ContextRz contextx, validation_form v)
        {
            x = contextx;
            vf = v;
            CurrentSalesOrder = ordhed_sales.GetById(x, v.orderid_sales);
            InitializeComponent();
            init();
            CompleteLoad();
        }

        //Public Virtual Functions
        public virtual ArrayList GetPrevalidationLines()
        {
            ArrayList ret = new ArrayList();
            foreach (Control c in gbPrevalidation.Controls)
            {
                //var type = c.GetType().ToString();
                //var type2 = Type.GetType("InspectionLine").ToString();
                if (c.GetType().ToString() == "Rz5.InspectionLine")
                    ret.Add(c);
            }
            return ret;

        }

        public void init()
        {
            //Ship To Match                
            ctl_pvDoesShipToMatch.FieldYesNo = "pvDoesShipToMatch";
            ctl_pvDoesShipToMatch.FieldNotes = "pvDoesShipToMatch_Notes";

            //QTY PRice MFG Match             
            ctl_pvDoesPnQtyPriceMfgMatch.FieldYesNo = "pvDoesPnQtyPriceMfgMatch";
            ctl_pvDoesPnQtyPriceMfgMatch.FieldNotes = "pvDoesPnQtyPriceMfgMatch_Notes";

            //Dock Date Realistic      
            ctl_pvDockDateRealistic.FieldYesNo = "pvDockDateRealistic";
            ctl_pvDockDateRealistic.FieldNotes = "pvDockDateRealistic_Notes";

        }

        private void CompleteLoad()
        {
            try
            {
                NMWin.LoadFormValues(this, vf);
                foreach (InspectionLine l in GetPrevalidationLines())
                {
                    l.xObject = vf;
                    l.CompleteLoad();
                }

                lblCurrentStatus.Text = GetCurrentValidationStage(RzWin.Context, CurrentSalesOrder);

                lblPrevalidationStatus.Text = vf.prevalidation_complete == true ? "Complete" : "In Progress";

                if (!CurrentSalesOrder.validation_stage.ToLower().Contains("hold"))
                    btnSavePreval.Enabled = true;
                else if (x.CheckPermit(Permissions.ThePermits.CanValidate))
                    btnSavePreval.Enabled = true;
                else
                    btnSavePreval.Enabled = false;

                LoadValidationGrid();

            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
        }

        private string GetCurrentValidationStage(ContextRz context, ordhed_sales currentSalesOrder)
        {
            return x.SelectScalarString("select top 1 new_stage from validation_tracking where orderid_sales = '" + currentSalesOrder.unique_id + "' order by date_created DESC");
        }

        private void LoadValidationGrid()
        {

            validations.Clear();
            String strSQL = "orderid_sales = '" + CurrentSalesOrder.unique_id + "'";
            validations.ShowTemplate("validation_tracking", "validation_tracking", RzWin.User.TemplateEditor);
            validations.ShowData("validation_tracking", strSQL, "date_created DESC", 10);
        }

        private void SavePrevalidation()
        {


            NMWin.GrabFormValues(this, vf);
            foreach (Rz5.InspectionLine l in GetPrevalidationLines())
            {
                l.CompleteSave();
            }
            SaveOtherFields();
            Close();
            vf.Update(x);
           
            validation_tracking vt = RzWin.Context.TheSysRz.TheOrderLogic.TrackValidation(RzWin.Context, CurrentSalesOrder, Enums.SalesOrderValidationStage.Validation.ToString());
         

        }

        private void SaveValidation()
        {
            throw new NotImplementedException();
        }


        private void SaveOtherFields()
        {
            vf.prevalidation_notes = ctl_prevalidation_notes.GetValue_String() ?? "";
        }


        private bool CheckPrevalidationComplete()
        {
            bool ret = true;
            NMWin.LoadFormValues(this, vf);
            foreach (InspectionLine l in GetPrevalidationLines())
            {
                l.CompleteLoad();
                if (!l.Checked)
                    ret = false;
            }
            return ret;
        }

        private void btnSavePreval_Click(object sender, System.EventArgs e)
        {
            try
            {
                SavePrevalidation();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }

        }
    }
}
