using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nView_n_choice : nView
    {
        public n_choice CurrentChoice;

        public nView_n_choice()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            CurrentChoice = (n_choice)GetCurrentObject();
            NMWin.LoadFormValues(this, CurrentChoice, null);
            base.CompleteLoad();
        }

        //Buttons
        private void cmdApply_Click(object sender, EventArgs e)
        {
            CompleteSaveAndUpdate();
            NMWin.Leader.Tell("Saved.");
        }
    }
}

