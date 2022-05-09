using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmCompanyFlag : Form
    {
        //"demo"
        //"bozz"
        //"stl"
        //"legend"
        //"ultimate"
        //"earthtron"
        //"atometron"
        //"aat"
        //"pmt"
        //"inet"
        //"axiom"
        //"ntc"
        //"nasco"
        //"merit"
        //"pipeline"
        //"tesla"
        //"phoenix"
        //"phoenixwarehouse"
        //"phoenixbrazil"
        //"ci"
        //"basiceparts"
        //"select"
        //"isttar"
        //"arrowtronics"
        //"kimtronics"
        //"voxx"
        //"integrity"
        //"prism"
        //"gemtek"
        //"tes"
        //"zeris"
        //"iconix"
        //"voyager"
        //"cuetech"
        //"concord"
        //"sensiblemicro"
        //"marketplace"
        //"g2"
        //"alfa"
        //"recognin"
        //"necomponents"

        //Public Variables
        public string CompanyIdent = "";

        //Constructors
        public frmCompanyFlag()
        {
            InitializeComponent();
        }
        //Private Functions
        private void Apply()
        {
            string s = OptionString();
            CompanyIdent = s;               
        }
        private string OptionString()
        {
            string s = "";
            foreach (Control c in this.Controls)
            {
                if (!(c is RadioButton))
                    continue;
                RadioButton r = (RadioButton)c;
                if (!r.Checked)
                    continue;
                s = r.Text.ToLower();
                if (Tools.Strings.StrCmp(s, "none"))
                    s = "";
            }
            return s;
        }
        //Buttons
        private void cmdApply_Click(object sender, EventArgs e)
        {
            Apply();
            Close();
        }
    }
}
