using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class OrderImport : UserControl, ICompleteLoad
    {
        //Private Variables
        private Enums.OrderType CurrentType;
        private bool TwoMode = false;
        private ImportInventory TheImportLogic;

        //Constructors
        public OrderImport()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            TheImportLogic = RzWin.Logic.GetImportInventoryLogic();
            SetOneMode();
            CheckTwo();
            DoResize();
        }
        public void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height;

                if (!TwoMode)
                {
                    dv2.Visible = false;
                    dv.Left = gb.Right;
                    dv.Top = 0;
                    dv.Height = this.ClientRectangle.Height;
                    dv.Width = this.ClientRectangle.Width - dv.Left;
                }
                else
                {
                    dv2.Visible = true;
                    dv.Left = gb.Right;
                    dv.Top = 0;
                    dv.Height = this.ClientRectangle.Height / 2;
                    dv.Width = this.ClientRectangle.Width - dv.Left;

                    dv2.Left = gb.Right;
                    dv2.Top = dv.Bottom;
                    dv2.Height = this.ClientRectangle.Height - dv.Height;
                    dv2.Width = this.ClientRectangle.Width - dv.Left;
                }
            }
            catch (Exception)
            { }

        }
        public void SetOneMode()
        {
            TwoMode = false;
            dv.CompleteLoad();
            dv.SetAcceptCaption("Import These Orders");
            dv.AlwaysDisableAccept = false;
            dv.AddCommonField("companyname", "Company Name", "name");
            dv.AddCommonField("orderdate", "Order Date", "date");
            dv.AddCommonField("terms", "Terms", "terms");
            dv.AddCommonField("shipvia", "Ship Via", "shipvia");
            dv.AddCommonField("ordernumber", "Order Number", "invcnbr|ordernum");
            dv.AddCommonField("agentname", "Agent Name", "slsperid|agent");
            dv.AddExtraField("extra_companysystemid", "Company System ID", "custid|vendorid|vendid");
            dv.AddExtraField("fullpartnumber", "Part Number", TheImportLogic.PartNumberAliases + "|invtid", true);
            dv.AddExtraField("alternatepart", "Alternate Part", "", false);
            dv.AddExtraField("quantityordered", "Quantity Ordered", "", false, FieldType.Int64);
            dv.AddExtraField("quantityfilled", "Quantity Filled", TheImportLogic.QuantityAliases, true, FieldType.Int64);
            dv.AddExtraField("datecode", "Date Code", TheImportLogic.DateCodeAliases);
            dv.AddExtraField("manufacturer", "Manufacturer", TheImportLogic.ManufacturerAliases);
            dv.AddExtraField("unitprice", "Price", "price", true, FieldType.Double);
            dv.AddExtraField("unitcost", "Cost", "cost", false, FieldType.Double);
            dv.AddExtraField("alternatepart", "Alternate Part", "alternate");
            dv.AddExtraField("vendorname", "Vendor Name", "vendor");
            dv.SetClass("ordhed");
            dv.Clear();
            CheckTwo();
            DoResize();
        }
        public void SetTwoMode()
        {
            TwoMode = true;
            dv.CompleteLoad();
            dv.AlwaysDisableAccept = true;
            dv.SetAcceptCaption("Import These Orders");
            dv.AddCommonField("companyname", "Company Name", "name", true);
            dv.AddCommonField("orderdate", "Order Date", "date");
            dv.AddCommonField("terms", "Terms", "terms");
            dv.AddCommonField("shipvia", "Ship Via", "shipvia");
            dv.AddCommonField("ordernumber", "Order Number", "invcnbr|ordernum");
            dv.AddCommonField("agentname", "Agent Name", "slsperid|agent");
            dv.AddExtraField("extra_companysystemid", "Company System ID", "custid|vendorid|vendid");
            dv.SetClass("ordhed");
            dv.Clear();
            dv2.Visible = true;
            dv2.CompleteLoad();
            dv2.AlwaysDisableAccept = true;
            dv2.AddCommonField("fullpartnumber", "Part Number", TheImportLogic.PartNumberAliases, true);
            dv2.AddExtraField("quantityordered", "Quantity Ordered", "", true, FieldType.Int64);
            dv2.AddCommonField("quantityfilled", "Quantity", TheImportLogic.QuantityAliases, true);
            dv2.AddCommonField("unitprice", "Price", "price", true);
            dv2.AddCommonField("manufacturer", "Manufacturer", TheImportLogic.ManufacturerAliases);
            dv2.AddCommonField("datecode", "DateCode", TheImportLogic.DateCodeAliases);
            dv2.AddExtraField("alternatepart", "Alternate Part", "alternate");
            dv2.SetClass("orddet");
            dv2.Clear();
            CheckTwo();
            DoResize();
        }
        //Private Functions
        private void RunImport()
        {
            RunImport(RzWin.Form.TheContextNM);
        }
        private void RunImport(ContextNM x)
        {
            if (!Tools.Strings.StrExt((String)cboOrderType.GetValue()))
            {
                x.TheLeader.TellTemp("Please choose an order type before continuing.");
                return;
            }

            CurrentType = RzLogic.ConvertOrderType((String)cboOrderType.GetValue());


            if (!Tools.Strings.StrExt((String)cboOrderType.GetValue()))
            {
                RzWin.Leader.Tell("Please choose an order type before continuing.");
                return;
            }

            //if (!dv.CurrentTable.HasColumnField("companyname"))
            //{
            //    RzWin.Leader.Tell("Please match the company name column before continuing.");
            //    return;
            //}

            if (!dv.CurrentTable.HasColumnField("fullpartnumber"))
            {
                RzWin.Leader.Tell("Please match the part number column before continuing.");
                return;
            }

            if (!dv.CurrentTable.HasColumnField("quantityfilled"))
            {
                RzWin.Leader.Tell("Please match the quantity column before continuing.");
                return;
            }

            if (!dv.CurrentTable.HasColumnField("unitprice"))
            {
                RzWin.Leader.Tell("Please match the price column before continuing.");
                return;
            }

            if (!RzWin.Leader.AreYouSure("import these " + Tools.Number.LongFormat(dv.Count) + " orders"))
                return;

            dv.SetStatus("Importing...");
            dv.ShowThrobber();
            bgImport.RunWorkerAsync();

        }
        private bool ImportOrders()
        {
            return ordhed.Import(RzWin.Context, dv.CurrentTable, CurrentType);
        }
        private void CheckTwo()
        {
            if (!TwoMode)
            {
                cmdImport.Visible = false;
                cboKeyDetail.Visible = false;
                cboKeyHeader.Visible = false;
                return;
            }
            else
            {
                cmdImport.Visible = true;
                cboKeyDetail.Visible = true;
                cboKeyHeader.Visible = true;

                cboKeyHeader.Items.Clear();
                if (dv.CurrentTable != null)
                {
                    foreach (nDataColumn c in dv.CurrentTable.Columns)
                    {
                        if (!Tools.Strings.StrExt("<click here>"))
                            cboKeyHeader.Items.Add(c.Caption);
                    }
                }

                cboKeyDetail.Items.Clear();
                if (dv2.CurrentTable != null)
                {
                    foreach (nDataColumn c in dv2.CurrentTable.Columns)
                    {
                        if (!Tools.Strings.StrExt("<click here>"))
                            cboKeyDetail.Items.Add(c.Caption);
                    }
                }
            }
        }
        //Buttons
        private void cmdImport_Click(object sender, EventArgs e)
        {

        }
        //Control Events
        private void OrderImport_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void dv_Accept()
        {
            RunImport();
        }
        private void optList_CheckedChanged(object sender, EventArgs e)
        {
            if (optSingleList.Checked)
                SetOneMode();
            else
                SetTwoMode();

            DoResize();
        }
        private void dv_AfterImport()
        {
            CheckTwo();
        }
        private void dv2_AfterImport()
        {
            CheckTwo();
        }
        //Background Workers
        private void bgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ImportOrders();
        }
        private void bgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dv.HideThrobber();
            dv.SetStatus("Ready.");
        }
    }
}
