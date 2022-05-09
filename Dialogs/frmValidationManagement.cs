using NewMethod;
using Rz5;
using Rz5.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmValidationManagement : Form
    {
        public frmValidationManagement()
        {
            InitializeComponent();
        }

        public ordhed_sales CurrentSalesOrder;
        protected List<string> ValidationStages;

        private List<SalesOrderValidationStage> HoldStages = new List<SalesOrderValidationStage>()
        { SalesOrderValidationStage.CustomerHold, SalesOrderValidationStage.ValidationHold, SalesOrderValidationStage.InspectionHold };
        private SalesOrderValidationStage CurrentStage;
        private SalesOrderValidationStage NewStage;
        bool isHold;


        public void CompleteLoad(ordhed_sales o)
        {

            CurrentSalesOrder = o;
            //Load the list for the stages dropdown
            ctl_validation_stage.LoadList("validation_stage");
            //Load all stages in memory
            ValidationStages = validation_tracking.GetAllValidationStages(RzWin.Context);
            //Load the CurrentStage variable
            CurrentStage = (SalesOrderValidationStage)Enum.Parse(typeof(SalesOrderValidationStage), CurrentSalesOrder.validation_stage);
            //Set the stage dropdown to current value
            ctl_validation_stage.SetValue(CurrentStage.ToString());
            //Only Validators should be able to manually change validation. Other users must use the Resolve Button
            //ctl_validation_stage.Enabled = RzWin.Context.CheckPermit(Permissions.ThePermits.CanValidate);
            //Set the isHold Variable
            isHold = HoldStages.Contains(CurrentStage);
            //Show/hide resolve button'
            LoadResolveButton();


        }

        private void LoadResolveButton()
        {

            //btnResolve.Text = "⚠";
            //btnResolve.ForeColor = System.Drawing.Color.Red;
            btnResolve.Text = "✔";
            btnResolve.ForeColor= System.Drawing.Color.Green;
            btnResolve.Visible = isHold;

        }



        private void LoadDropDown()
        {

        }

        private void btnShowValidationForm_Click(object sender, EventArgs e)
        {
            //ContextRz x = RzWin.Context;

            try
            {
                validation_form vf = validation_form.GetByOrderID(RzWin.Context, CurrentSalesOrder);
                if (vf == null)
                    vf = validation_form.ValidationFormCreate(RzWin.Context, CurrentSalesOrder);
                if (vf == null)
                    return;
                RzWin.Context.Leader.ValidationFormShow(RzWin.Context, vf);

            }
            catch (Exception ex)
            {
                RzWin.Context.Leader.Tell(ex.Message);
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {

            try
            {                
                validation_tracking vt = RzWin.Context.TheSysRz.TheOrderLogic.TrackValidation(RzWin.Context, CurrentSalesOrder, SalesOrderValidationStage.Validation.ToString(), isHold);
                this.Close();
            }
            catch (Exception ex)
            {
                RzWin.Context.Leader.Error(ex.Message);
                this.Close();
            }
        }

        private void ctl_validation_stage_SelectionChanged(Tools.GenericEvent e)
        {
            //Passign this through below to prevent override ValidationComplete stages
            bool isHold = validation_tracking.CheckIsHoldStage(RzWin.Context, ctl_validation_stage.GetValue_String());

            //Check to see if the selection has changed
            if (CurrentSalesOrder.validation_stage != ctl_validation_stage.GetValue_String())
            {
                //Message to tell the user
                string message = "";
                if (ctl_validation_stage.GetValue_String() == Rz5.Enums.SalesOrderValidationStage.ValidationComplete.ToString())
                    message = "you want to mark this order Validation Complete";
                else
                    message = "you want to set the validation stage to " + ctl_validation_stage.GetValue_String();
                //This may be redundant, extra clicks, will just ensure users type a reason.
                ////Confirm the validation change with the user
                //if (!RzWin.Leader.AreYouSure(message))
                //{
                //    ctl_validation_stage.SetValue(CurrentSalesOrder.validation_stage); //reset the dropdown on no
                //    return;
                //}

                //Log the validationtracking result
                validation_tracking vt = RzWin.Context.TheSysRz.TheOrderLogic.TrackValidation(RzWin.Context, CurrentSalesOrder, ctl_validation_stage.GetValue_String(), isHold);

                //if (vt != null)
                //    //Send any alert emails.
                //    SendValidationAlerts(ctl_validation_stage.GetValue_String());

                //Close the Modal
                this.Close();

            }


        }

        //private void SendValidationAlerts(string validation_stage, bool isResolved = false)
        //{
        //    //Generic Alert Message
        //    string alert = validation_stage + "    ⚠ Email Alert ⚠";

        //    //Switch through the stages to trigger alert.
        //    switch (validation_stage)
        //    {
        //        case "PreValidation":
        //            {
        //                break;
        //            }
        //        case "Validation":
        //            {
        //                if (isResolved)
        //                    SendValidationResolvedAlert(validation_stage, alert);
        //                break;
        //            }
        //        case "CustomerHold":
        //        case "InspectionHold":
        //        case "ValidationHold":
        //            {
        //                //
        //                //SendValidationHoldAlert(validation_stage, alert);
        //                break;
        //            }

        //        case "ValidationComplete":
        //            {
        //                //SendValidationCompleteAlert(validation_stage, alert);
        //                break;
        //            }
        //        default:
        //            break;
        //    }
        //}

        private void SendValidationResolvedAlert(string validation_stage, string alert)
        {
            string message = "Validation issues have been resolved for Sales Order# " + CurrentSalesOrder.ordernumber;
            RzWin.Context.Leader.Tell(message + " " + alert);


        }

        //private void SendValidationHoldAlert(string validation_stage, string alert)
        //{
        //    string message = CurrentSalesOrder.agentname + ", your order " + CurrentSalesOrder.OrddetName + " has been placed on " + validation_stage + " because the following: " + Environment.NewLine + alert;

        //    RzWin.Context.Leader.Tell(message);
        //}

        //private void SendValidationCompleteAlert(string validation_stage, string alert)
        //{
        //    RzWin.Context.Leader.Tell(alert);
        //}
    }
}
