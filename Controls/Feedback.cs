using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class Feedback : UserControl
    {
        SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.Sys;
            }
        }
        company CurrentCompany;
        Int32 positive = 0;
        Int32 neutral = 0;
        Int32 negative = 0;
        Int32 percent = 0;

        public Feedback()
        {
            InitializeComponent();
        }

        public void CompleteLoad(company c)
        {
            if (c == null)
                throw new Exception("No company");
            CurrentCompany = c;
            DoResize();
            ShowCompanyScores();
        }
        //Public Functions
        public void DoResize()
        {
            try
            {
                this.Width = 180;
                this.Height = 130;
                SetBorder();
                label2.Top = pbTop.Bottom;
                label2.Left = pbLeft.Right;
                label2.Width = pbRight.Left - label2.Left;
            }
            catch (Exception)
            { }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch (Exception)
            { }
        }
        private void ShowCompanyScores()
        {
            try
            {
                CalculateCompanyScores();
                SetLabels();
            }
            catch (Exception)
            { }
        }
        private void CalculateCompanyScores()
        {
            try
            {
                positive = 0;
                neutral = 0;
                negative = 0;

                if (CurrentCompany == null)
                    return;

                CurrentCompany.FeedbackCalc(RzWin.Context);

                positive = CurrentCompany.feedback_positive;
                neutral = CurrentCompany.feedback_neutral;
                negative = CurrentCompany.feedback_negative;
                percent = CurrentCompany.feedback_rating;

            }
            catch (Exception)
            { }
        }
        private void SetLabels()
        {
            try
            {
                lblPositive.Text = positive.ToString();
                lblNeutral.Text = neutral.ToString();
                lblNegative.Text = negative.ToString();
                lblPercent.Text = percent.ToString() + "%";
            }
            catch (Exception)
            { }
        }
        //Control Events
        private void Feedback_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCompanyScores();
        }
    }
}
