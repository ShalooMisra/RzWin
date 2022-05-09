using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin.Controls
{
    public partial class AccountSelection : UserControl
    {
        public event AccountSelectedHandler AccountSelected;

        public AccountSelection()
        {
            InitializeComponent();
        }

        bool loading = false;
        String lastAccountName = "";
        public void Init(String caption, AccountCriteria criteria)
        {
            captionLabel.Text = caption;

            loading = true;

            selectionBox.Items.Clear();

            foreach (account a in RzWin.Accounts.GetAccounts(RzWin.Context, criteria))
            {
                selectionBox.Items.Add(a.name);
            }

            selectionBox.Items.Add("");
            loading = false;
        }

        new public void Load(String accountId, String accountName)
        {
            loading = true;

            try
            {
                selectionBox.SelectedItem = selectionBox.Items[selectionBox.Items.IndexOf(accountName)];
            }
            catch { }

            loading = false;
            lastAccountName = selectionBox.Text;
        }

        private void selectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            String name = selectionBox.Text;
            account act = RzWin.Context.Accounts.GetAccount(RzWin.Context, name);
            if (act == null)
            {
                RzWin.Leader.Tell("The account " + selectionBox.Text + " could not be found");
                return;
            }

            if (AccountSelected != null)
            {
                bool cancel = false;
                AccountSelected(act, ref cancel);

                if (cancel)
                {
                    loading = true;
                    selectionBox.SelectedItem = selectionBox.Items[selectionBox.Items.IndexOf(lastAccountName)];
                    loading = false;
                }
            }
        }
    }

    public delegate void AccountSelectedHandler(account newAccount, ref bool cancel);
}
