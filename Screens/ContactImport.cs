using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class ContactImport : UserControl, ICompleteLoad
    {
        public SysNewMethod xSys
        {
            get
            {
                return TheContext.xSys;
            }
        }
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        public bool PartialMode = false;
        protected ArrayList ExistingIDs = new ArrayList();        
        public ContactImport()
        {
            InitializeComponent();
        }
        public void CompleteLoad()
        {
            dv.DisableAccept();
            dv.CompleteLoad();
            dv.AddCommonField("companyname", "Company", "company", true);
            dv.AddCommonField("contactname", "Contact", "contact", !PartialMode);
            dv.AddCommonField("primaryphone", "Phone", "phone");
            dv.AddCommonField("primaryfax", "Fax", "fax");
            dv.AddCommonField("primaryemailaddress", "Email", "email");
            dv.AddCommonField("line1", "Address 1", "address1");
            dv.AddCommonField("line2", "Address 2", "address2");
            dv.AddCommonField("line3", "Address 3", "address3");
            dv.AddCommonField("adrcity", "City", "city");
            dv.AddCommonField("adrstate", "State", "state");
            dv.AddCommonField("adrzip", "Zip Code", "zip");
            dv.AddCommonField("adrcountry", "Country", "country");
            dv.AddCommonField("agentname", "Agent", "agent");
            if (PartialMode)
                dv.SetClass("partial_contact_surfacemail");
            else
                dv.SetClass("companycontact");
            DoResize();
            ctlAgent.SetUserName("");
            if (PartialMode)
                ctlAgent.Visible = false;
        }
        protected virtual void ImportContacts()
        {
            if (!dv.HasRequiredFields())
            {
                RzWin.Leader.Tell("Please select at least a company name and contact name column.");
                return;
            }
            String strAgent = ctlAgent.GetUserName();
            String strSource = "";
            String strGroup = "";
            if (!dv.CurrentTable.HasColumnField("agentname"))
            {
                if (!PartialMode && !Tools.Strings.StrExt(strAgent))
                {
                    if (RzWin.Leader.AskYesNo("Do you want to assign an agent to this import?"))
                        return;
                }
            }
            //formalize the fields
            dv.CurrentTable.SetActualFieldNames(RzWin.Context);
            SetStatus("Formalizing...");
            dv.CurrentTable.FormalizeFieldTypes(RzWin.Context);
            dv.CurrentTable.CheckCriteria(RzWin.Context, "blank company names", "isnull(companyname, '') = ''");
            if (!PartialMode)
                dv.CurrentTable.CheckCriteria(RzWin.Context, "blank contact names", "isnull(contactname, '') = ''");

            dv.CurrentTable.CheckCriteria(RzWin.Context, "duplicate company info", " exists( select * from partial_contact_surfacemail sm where sm.companyname = " + dv.CurrentTable.TableName + ".companyname) ");

            //import the rest
            SetStatus("Importing...");
            dv.CurrentTable.AddField("primaryphone");
            dv.CurrentTable.AddField("primaryfax");
            dv.CurrentTable.AddField("primaryemailaddress");
            dv.CurrentTable.AddField("email_domain");
            dv.CurrentTable.xData.SplitEmailDomain(dv.CurrentTable.TableName, "primaryemailaddress", "email_domain");
            dv.CurrentTable.AddField("abs_type");
            dv.CurrentTable.xData.Execute("update x set x.abs_type = 'DIST' from " + dv.CurrentTable.TableName + " x inner join domain d on d.domain_name = x.email_domain where isnull(x.email_domain, '') > '' and isnull(d.always_dist, 0) = 1");
            dv.CurrentTable.xData.Execute("update x set x.abs_type = 'OEM' from " + dv.CurrentTable.TableName + " x inner join domain d on d.domain_name = x.email_domain where isnull(x.email_domain, '') > '' and isnull(d.always_oem, 0) = 1");
            dv.CurrentTable.AddField("line1");
            dv.CurrentTable.AddField("line2");
            dv.CurrentTable.AddField("line3");
            dv.CurrentTable.AddField("adrcity");
            dv.CurrentTable.AddField("adrstate");
            dv.CurrentTable.AddField("adrzip");
            dv.CurrentTable.AddField("adrcountry");
            dv.CurrentTable.AddField("competition");
            dv.CurrentTable.AddField("notes");
            dv.CurrentTable.AddField("contactnotes");
            dv.CurrentTable.AddField("description");
            dv.CurrentTable.AddField("ip_address");
            dv.CurrentTable.AddField("base_mc_user_uid");
            dv.CurrentTable.AddField("agentname");
            if (dv.CurrentTable.HasColumnField("agentname"))
                dv.CurrentTable.xData.Execute("update x set x.base_mc_user_uid = y.unique_id from " + dv.CurrentTable.TableName + " x inner join n_user y on x.agentname = y.name");
            else
            {
                if (Tools.Strings.StrExt(strAgent))
                {
                    dv.CurrentTable.xData.Execute("update " + dv.CurrentTable.TableName + " set agentname = '" + dv.CurrentTable.xData.SyntaxFilter(strAgent) + "'");
                    String strUserID = RzWin.Context.xSys.TranslateUserNameToID(strAgent);
                    dv.CurrentTable.xData.Execute("update " + dv.CurrentTable.TableName + " set base_mc_user_uid = '" + dv.CurrentTable.xData.SyntaxFilter(strUserID) + "'");
                }
            }
            String strFields = "";
            String strValues = "";
            String strSQL = "";
            RzWin.Context.Data.FieldMakeExist("companycontact", new Field("competition", FieldType.String, 255));
            if (PartialMode)
            {
                strFields = "left(companyname, 50), left(primaryphone, 50), left(primaryfax, 50), left(primaryemailaddress, 50), left(line1, 50), left(line2, 50), left(line3, 50), left(adrcity, 50), left(adrstate, 50), left(adrzip, 50), left(adrcountry, 50), left(notes, 50), left(description, 50), left(ip_address, 50), getdate(), getdate(), left(primaryurl, 200)";
                strValues = "companyname, primaryphone, primaryfax, primaryemailaddress, line1, line2, line3, adrcity, adrstate, adrzip, adrcountry, notes, description, ip_address, date_created, date_modified, primaryurl";
                strSQL = "insert into partial_contact_surfacemail (unique_id, " + strValues + " ) select cast(newid() as varchar(50)), " + strFields + " from " + dv.CurrentTable.TableName;
            }
            else
            {
                //add front and back commas for discrete searches
                RzWin.Context.Data.FieldMakeExist(dv.CurrentTable.TableName, new Field("group_name", FieldType.String, 255));
                RzWin.Context.Data.FieldMakeExist(dv.CurrentTable.TableName, new Field("source", FieldType.String, 255));
                dv.CurrentTable.xData.Execute("update " + dv.CurrentTable.TableName + " set group_name = '," + dv.CurrentTable.xData.SyntaxFilter(strGroup) + ",'");
                dv.CurrentTable.xData.Execute("update " + dv.CurrentTable.TableName + " set source = '," + dv.CurrentTable.xData.SyntaxFilter(strSource) + ",'");
                strFields = "left(companyname, 50), left(contactname, 50), left(primaryphone, 50), left(primaryfax, 50), left(primaryemailaddress, 50), left(line1, 50), left(line2, 50), left(line3, 50), left(adrcity, 50), left(adrstate, 50), left(adrzip, 50), left(adrcountry, 50), left(base_mc_user_uid, 50), left(agentname, 50), left(source, 50), left(group_name, 50), left(competition, 50), left(email_domain, 50), left(abs_type, 50), left(contactnotes, 255)";
                strValues = "companyname, contactname, primaryphone, primaryfax, primaryemailaddress, line1, line2, line3, adrcity, adrstate, adrzip, adrcountry, base_mc_user_uid, agentname, source, group_name, competition, email_domain, abs_type, contactnotes";
                strSQL = "insert into companycontact (unique_id, " + strValues + " ) select cast(newid() as varchar(50)), " + strFields + " from " + dv.CurrentTable.TableName;
            }

            long count = RzWin.Context.TheData.Execute(strSQL);
            SetStatus("Import Complete: " + Tools.Number.LongFormat(count) + " new contacts were imported.");
        }
        private void ContactImport_Load(object sender, EventArgs e)
        {

        }
        private void ContactImport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height;

                dv.Top = 0;
                dv.Left = gb.Right;
                dv.Width = this.ClientRectangle.Width - gb.Width;
                dv.Height = (this.ClientRectangle.Height / 4) * 3;

                txtStatus.Left = gb.Right;
                txtStatus.Width = this.ClientRectangle.Width - gb.Width;
                txtStatus.Top = dv.Bottom;
                txtStatus.Height = this.ClientRectangle.Height - txtStatus.Top;
            }
            catch (Exception)
            { }
        }
        private void cmdImport_Click(object sender, EventArgs e)
        {
            ImportContacts();
        }
        protected void SetStatus(String strStatus)
        {
            if (InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(ActualSetStatus);
                Invoke(d, new Object[] { strStatus });
            }
            else
                ActualSetStatus(strStatus);
        }        
        private void ActualSetStatus(String strStatus)
        {
            txtStatus.Text = strStatus + "\r\n" + Tools.Strings.Left(txtStatus.Text, 2000);
        }
        private void ctlAgent_ChangeUser(GenericEvent e)
        {
            NewMethod.n_user u = NewMethod.n_user.Choose(RzWin.Context, RzWin.Logic.SalesPeople, false);
            if( u != null )
                ctlAgent.SetUserName(u.name);
        }
        public void SetDataTable(nDataTable d)
        {
            dv.SetDataTable(d);
        }
        public void AutoMatch()
        {
            dv.AutoMatchColumns();
        }
        public void SetAgentName(String strName)
        {
            ctlAgent.SetUserName(strName);
        }
    }
}
