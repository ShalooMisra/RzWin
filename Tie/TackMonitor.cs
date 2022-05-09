using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Tie
{
    public partial class TackMonitor : UserControl
    {
        public TieTack xTack;

        public TackMonitor()
        {
            InitializeComponent();
        }

        public void CompleteLoad(TieTack t)
        {
            xTack = t;
            t.GotStatus += new TieEndStatusHandler(t_GotStatus);

            lblStatus.Text = "Pin: " + xTack.TackName + "\r\nRack Address: " + xTack.HostName + "\r\nPort: " + xTack.HostPort.ToString();

            tmr.Start();
        }

        void t_GotStatus(TieEnd end, string s)
        {
            status.AppendText(s + "\n");
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (xTack == null)
                return;

            if (xTack.IsConnected())
            {
                picConnected.Visible = true;
                picDisconnected.Visible = false;

                if (xTack.UnreadableMessages > 0)
                {
                    lblError.Text = "POTENTIAL PASSWORD MIS-MATCH.\r\nPlease ensure that the connection password entered matches the one that the rack at " + xTack.RackAddress + " is configured for.";
                    lblError.Visible = true;
                }
                else
                    lblError.Visible = false;
            }
            else
            {
                picConnected.Visible = false;
                picDisconnected.Visible = true;
            }
        }

        private void CloseTack()
        {
            try
            {
                if (xTack == null)
                    return;

                xTack.StopPersistence();
                xTack.Close();
                xTack = null;
            }
            catch { }
        }
    }
}
