using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
namespace CCEJobs.Controls
{
    public partial class ctlPurchasing : UserControl
    {
        private BindingSource jobSourceBinding = new BindingSource();
        public ctlPurchasing()
        {
            InitializeComponent();
            cboReport.Properties.Items.Add("Job Setup Sheet");
            cboReport.Properties.Items.Add("Bid Schedule");
            cboReport.Properties.Items.Add("Weekly Estimate Successful");
            cboReport.Properties.Items.Add("Weekly Million Dollar");
        }
   
        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control ctlReport = new Control();
            panReportParamters.Controls.Clear();
            switch (cboReport.Text)
            {
                case "Bid Schedule":
                    panReportParamters.Controls.Add(new ctlBidScheduleReport());
                    break;
                case "Weekly Estimate Successful":
                    panReportParamters.Controls.Add(new ctlWeeklySuccessfulReport());
                    break;
                case "Weekly Million Dollar":
                    panReportParamters.Controls.Add(new ctlWeeklyMillionDollarReport());
                    break;

                default:
                    break;
            }
                    
        }
    }
}
