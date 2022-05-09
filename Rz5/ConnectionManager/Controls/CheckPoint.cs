using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethodx;

namespace ConnectionManager
{
    public delegate void CheckPointLinkClickHandler();

    public enum CheckPointState
    {
        Unknown = 0,
        Done = 1,
        Warning = 2,
    }

    public partial class CheckPoint : UserControl
    {
        public event CheckPointLinkClickHandler LinkClicked;

        public CheckPoint()
        {
            InitializeComponent();
        }

        public String Caption = "";
        public String Message = "";
        public String LinkText = "";

        public void CompleteLoad()
        {
            lblCaption.Text = Caption;
            lblMessage.Text = Message;
            lblLink.Text = LinkText;
        }

        public void SetState(CheckPointState state)
        {
            switch (state)
            {
                case CheckPointState.Done:
                    picCheck.BackgroundImage = il.Images["done"];
                    
                    if( !nTools.IsDevelopmentMachinePlain() )
                        lblLink.Visible = false;
                    else
                        lblLink.Visible = true;
                    
                    lblMessage.Text = "OK";
                    break;
                case CheckPointState.Warning:
                    picCheck.BackgroundImage = il.Images["warning"];
                    lblLink.Visible = true;
                    lblMessage.Text = Message;
                    break;
                default:
                    picCheck.BackgroundImage = il.Images["unknown"];
                    lblLink.Visible = false;
                    break;
            }
        }

        public void SetExplicitLink()
        {
            lblLink.Visible = true;
            lblMessage.Text = Message;
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LinkClicked != null)
                LinkClicked();
        }
    }
}
