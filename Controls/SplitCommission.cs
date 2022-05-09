using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewMethod;
using Core;
using System.Collections;
using Rz5.Enums;

namespace Rz5
{
    public partial class SplitCommission : UserControl
    {
        public SplitCommission()
        {
            InitializeComponent();
        }
        private string splitCommissionID { get; set; }
        public split_commission splitCommissionObject { get; set; }
        public n_user CurrentAgent { get; set; }
        public n_user ListAcquisitionAgent { get; set; }
        public n_user SplitCommissionAgent { get; set; }

        //public int splitCommissionAmount { get; set; }
        //public string SplitCommissionType { get; set; }
        public object CommissionableObject;
        public bool isModal = false;

        double StandardSplit = 0;
        double ListAquisitionSplit = 0;
        double MaxSplit = 0; //i.e. the commission percent of the agent.


        //Load the values from the CurrentObject
        public void CompleteLoad(ContextRz x, object co)
        {
            try
            {

                ctl_split_type.SetValue(SplitCommissionType.None.ToString());
                this.Enabled = false;
                if (x.CheckPermit(Permissions.ThePermits.CanManageCommission))
                    this.Enabled = true;
                //Load the Object, if it has split commission ID, load the splitCommissin Object.
                LoadCurrentObject(co);

                //Initial Control settings
                splitCommissionObject = null;
                lblAgent.Text = "<Choose ...>";
                ctl_split_commission_amnt.SetValue(0);

                if (!string.IsNullOrEmpty(splitCommissionID))
                    splitCommissionObject = split_commission.GetById(RzWin.Context, splitCommissionID);

                LoadCurrentAgents();
                if (CurrentAgent == null)
                    return;
                //throw new Exception("Could not determine the sales agent for this object.");
                LoadSplits();
                LoadSplitControls();




                btnDelete.Enabled = splitCommissionObject != null;


            }

            catch (Exception ex)
            {
                RzWin.Context.Leader.Error(ex.Message);
            }

        }

        private void LoadCurrentAgents()
        {

            if (splitCommissionObject != null)
                SplitCommissionAgent = n_user.GetById(RzWin.Context, splitCommissionObject.split_commission_agent_id);

            if (CommissionableObject is company)
            {
                //Get the companyID and set that on the commission object.
                company c = (company)CommissionableObject;
                CurrentAgent = n_user.GetById(RzWin.Context, c.base_mc_user_uid);

            }

            else if (CommissionableObject is orddet_quote)
            {

                //Get the companyID and set that on the commission object.
                orddet_quote q = (orddet_quote)CommissionableObject;
                CurrentAgent = n_user.GetById(RzWin.Context, q.base_mc_user_uid);
                ListAcquisitionAgent = n_user.GetById(RzWin.Context, q.list_acquisition_agent_uid);

            }

            else if (CommissionableObject is orddet_line)
            {

                //Get the companyID and set that on the commission object.
                orddet_line l = (orddet_line)CommissionableObject;
                CurrentAgent = n_user.GetById(RzWin.Context, l.seller_uid);
                ListAcquisitionAgent = n_user.GetById(RzWin.Context, l.list_acquisition_agent_uid);
            }

            else if (CommissionableObject is dealheader)
            {
                //Get the companyID and set that on the commission object.
                dealheader d = (dealheader)CommissionableObject;
                CurrentAgent = n_user.GetById(RzWin.Context, d.base_mc_user_uid);
            }

            if (ListAcquisitionAgent != null)
                ctl_ListAcquisitionAgent.SetValue(ListAcquisitionAgent.Name);


        }

        private void LoadSplits()
        {
            //Variables
            MaxSplit = CurrentAgent.commission_percent;
            if (ListAcquisitionAgent != null)
                ListAquisitionSplit = .03;
            if (splitCommissionObject != null)
                StandardSplit = splitCommissionObject.split_commission_percent;


            //Labels
            if (ListAquisitionSplit > 0)
                lblListAquisition.Text = (ListAquisitionSplit).ToString("P");
            if (StandardSplit > 0)
                lblStandardSplit.Text = StandardSplit.ToString("P");
            lblCurrentSplit.Text = ((ListAquisitionSplit + StandardSplit)).ToString("P");
            lblMaxSplit.Text = (MaxSplit).ToString("P");


        }

        private void LoadCurrentObject(object co)
        {
            if (co != null)
            {
                CommissionableObject = co;
                if (CommissionableObject is company)
                {

                    //ctl_split_agent.CurrentObject = ((company)co);
                    splitCommissionID = ((company)co).split_commission_ID;
                }
                else if (CommissionableObject is orddet_quote)
                {
                    //ctl_split_agent.CurrentObject = ((orddet_quote)co);
                    splitCommissionID = ((orddet_quote)co).split_commission_ID;
                }

                else if (CommissionableObject is orddet_line)
                {
                    //ctl_split_agent.CurrentObject = ((orddet_line)co);
                    splitCommissionID = ((orddet_line)co).split_commission_ID;
                }

                else if (CommissionableObject is dealheader)
                {
                    //ctl_split_agent.CurrentObject = ((dealheader)co);
                    splitCommissionID = ((dealheader)co).split_commission_ID;
                }

            }



        }


        //Load all control items.
        private void LoadSplitControls()
        {
            try
            {
                if (CommissionableObject == null)
                    return;

                if (splitCommissionObject != null)
                    if (!string.IsNullOrEmpty(splitCommissionObject.split_commission_type))
                        ctl_split_type.SetValue(splitCommissionObject.split_commission_type);

                bool canManage = RzWin.Context.CheckPermit(Permissions.ThePermits.CanManageCommission);
                if (!canManage)
                {
                    lblAgent.Enabled = false;
                    ctl_split_commission_amnt.Enabled = false;
                }

                if (splitCommissionObject != null)
                {
                    lblAgent.Text = splitCommissionObject.split_commission_agent;
                    ctl_split_commission_amnt.SetValue(splitCommissionObject.split_commission_percent); //Converting from decimal to integer.
                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }

        }





        private void SaveSplitCommission(ContextRz x)
        {
            //SetSplitAgent(RzWin.Context, CurrentObject);
            //n_user SplitAgent = n_user.GetByName(RzWin.Context, ctl_split_agent.GetUserName());
            //n_user ExistingSplitAgent = SplitCommissionAgent;
            //Set these variables, as they are needed to refer to in modal situations.
            //SplitCommissionType = split_commission_type.GetValue_String();
            //RzWin.Context.TheSysRz.TheProfitLogic.SetSplitCommissionForObject(RzWin.Context, CurrentObject);        

            if (string.IsNullOrEmpty(lblAgent.Text) || lblAgent.Text == "<Choose ...>")
            {
                throw new Exception("Please choose a split commission agent.");
            }

            if (!AllowedToSplit(out string notAllowedReason))
            {
                x.Leader.Error(notAllowedReason);
                return;
            }



            SplitCommissionAgent = n_user.GetByName(x, lblAgent.Text);
            if (SplitCommissionAgent == null)
                throw new Exception("No Split agent found with name: " + lblAgent.Text);
            //Split Percent.  Don't allow Integers, force .1 for 10%, .03 for 3%, etc.
            double dblSplitPercent = 0;
            //if (int.TryParse(ctl_split_commission_amnt.GetValue_Integer().ToString(), out intSplitPercent))
            //    throw new Exception("Please use decimals to express percent.  Example: for 10%, use .10 or .1, for 3% use .03");
            string strSplitPercent = ctl_split_commission_amnt.zz_Text;
            if (!strSplitPercent.Contains("."))
                throw new Exception("Please use decimals to express percent.  Example: for 10%, use .10 or .1, for 3% use .03");

            if (!double.TryParse(strSplitPercent, out dblSplitPercent))
                throw new Exception(ctl_split_commission_amnt.GetValue_Integer() + " is not a valid commmission percent value.");
            if (dblSplitPercent == 0)
                throw new Exception("Please enter a value for split commission percent.");
            if (dblSplitPercent > MaxSplit)
                throw new Exception("Sorry, you cannot split more than the max split of " + MaxSplit.ToString("P"));

            string confirmPercent = (dblSplitPercent * 100).ToString(); //Express this as actual percent for confirmation
            if (!x.Leader.AreYouSure("you want to set a " + confirmPercent + "% split on this line item"))
                return;


            if (splitCommissionObject == null)
            {
                splitCommissionObject = split_commission.New(x);
                splitCommissionObject.Insert(x);
            }


            //Set base values for Split Commission object.
            splitCommissionObject.split_commission_agent = SplitCommissionAgent.name;
            splitCommissionObject.split_commission_agent_id = SplitCommissionAgent.unique_id;
            splitCommissionObject.split_commission_percent = dblSplitPercent;
            splitCommissionObject.split_commission_type = ctl_split_type.GetValue_String();


            //Set object specific values
            if (CommissionableObject != null && splitCommissionObject != null)
            {
                if (CommissionableObject is company)
                {

                    //Get the companyID and set that on the commission object.
                    company c = (company)CommissionableObject;
                    splitCommissionObject.base_company_uid = c.unique_id;
                    splitCommissionObject.Update(x);

                    //Update the RzObject with the ID of the Commission Object.
                    c.split_commission_ID = splitCommissionObject.unique_id;
                    c.Update(x);

                }

                else if (CommissionableObject is orddet_quote)
                {

                    //Get the companyID and set that on the commission object.
                    orddet_quote q = (orddet_quote)CommissionableObject;
                    splitCommissionObject.base_company_uid = q.unique_id;
                    splitCommissionObject.Update(x);

                    //Update the RzObject with the ID of the Commission Object.
                    q.split_commission_ID = splitCommissionObject.unique_id;
                    q.Update(x);
                }

                else if (CommissionableObject is orddet_line)
                {

                    //Get the companyID and set that on the commission object.
                    orddet_line l = (orddet_line)CommissionableObject;
                    splitCommissionObject.the_orddet_line_uid = l.unique_id;
                    splitCommissionObject.Update(x);

                    //Update the RzObject with the ID of the Commission Object.
                    l.split_commission_ID = splitCommissionObject.unique_id;
                    l.Update(x);
                }

                else if (CommissionableObject is dealheader)
                {
                    //Get the companyID and set that on the commission object.
                    dealheader d = (dealheader)CommissionableObject;
                    splitCommissionObject.base_company_uid = d.unique_id;
                    splitCommissionObject.Update(x);

                    //Update the RzObject with the ID of the Commission Object.
                    d.split_commission_ID = splitCommissionObject.unique_id;
                    d.Update(x);
                }
            }

        }

        private bool AllowedToSplit(out string notAllowedReason)
        {
            notAllowedReason = "";
            //if (isListAcquisiton())
            //{
            //    notAllowedReason = "This line is already a list aquisition split.  Cannot split further.";
            //    return false;
            //}

            return string.IsNullOrEmpty(notAllowedReason);
        }

        //private bool isListAcquisiton()
        //{

        //    string listAcquisitionID = "";
        //    if (CommissionableObject is orddet_line)
        //        listAcquisitionID = ((orddet_line)CommissionableObject).list_acquisition_agent_uid;
        //    else if (CommissionableObject is orddet_quote)
        //        listAcquisitionID = ((orddet_line)CommissionableObject).list_acquisition_agent_uid;
        //    return !string.IsNullOrEmpty(listAcquisitionID);
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSplitCommission(RzWin.Context);
                //In case this is a modal, return OK on change.
                Form f = (Form)this.TopLevelControl;
                if (f != null)
                    f.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
        }

        private void lblAgent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string strName = "";
            string strID = "";
            frmChooseUser.ChooseUserName(ref strID, ref strName, null, false);

            if (!Tools.Strings.StrExt(strID))
                return;
            NewMethod.n_user u = NewMethod.n_user.GetById(RzWin.Context, strID);
            if (u != null)
            {
                lblAgent.Text = u.Name;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (RzWin.Leader.AreYouSure(" you want to delete this split commission object?"))
                    if (splitCommissionObject != null)
                    {
                        RzWin.Context.Delete(splitCommissionObject);
                        DeleteSplitCommissionID(RzWin.Context);
                        //CompleteLoad(RzWin.Context, CommissionableObject);
                    }
                Form f = (Form)this.TopLevelControl;
                if (f != null)
                    f.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
        }

        private void DeleteSplitCommissionID(ContextRz x)
        {
            if (CommissionableObject == null)
                throw new Exception("No commissionable object found to manage.");

            else if (CommissionableObject is company)
            {
                company c = (company)CommissionableObject;
                c.split_commission_ID = null;
                c.Update(x);
            }
            else if (CommissionableObject is dealheader)
            {
                dealheader d = (dealheader)CommissionableObject;
                d.split_commission_ID = null;
                d.Update(x);
            }
            else if (CommissionableObject is orddet_quote)
            {
                orddet_quote q = (orddet_quote)CommissionableObject;
                q.split_commission_ID = null;
                q.Update(x);
            }
            else if (CommissionableObject is orddet_line)
            {
                orddet_line l = (orddet_line)CommissionableObject;
                l.split_commission_ID = null;
                l.Update(x);
            }

            CompleteLoad(x, CommissionableObject);
        }

        private void ctl_split_type_SelectionChanged(Tools.GenericEvent e)
        {
            string type = ctl_split_type.GetValue_String();

            //C# Switch Statements cannot use evaluated variables, so can't use Enums

            switch (type)
            {
                case "Design":
                    {
                        ctl_split_commission_amnt.SetValue(.07);
                        break;
                    }
                case "Standard":
                    {
                        ctl_split_commission_amnt.SetValue(.05);
                        break;
                    }

            }
        }
    }
}
