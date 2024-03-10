using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CCEJobs.Subcontracts.Reports
{
    public partial class rptSubcontractContractLog : DevExpress.XtraReports.UI.XtraReport
    {
        private bool hasContract = false;
        private bool hasApprovedChanges = false;
        private bool hasPendingChanges = false;
        private bool hasPendingNoProceed = false;
        private bool hasCancelled = false;
        private bool hasAllowance = false;
               
          
        public rptSubcontractContractLog()
        {
            InitializeComponent();
        }
       
        private void txtTotalCost_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";


            summaryS = txtTotalCost.Summary.GetResult().ToString();

            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);


            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractTotalCost.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesTotalCost.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesTotalCost.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedTotalCost.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledTotalCost.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledTotalCost.Text = summaryS;
                    break;

            }
        }

        private void txtContractAmount_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";

            summaryS = txtContractAmount.Summary.GetResult().ToString();
            if (summaryS.Trim().Length == 0)
                summaryS = "0";
            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);
            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractContractAmount.Text =  summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesContractAmount.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesContractAmount.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedContractAmount.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledContractAmount.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledContractAmount.Text = summaryS;
                    break;

            }
        }

 
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!hasContract)
            {
                txtOriginalContractTotalCost.Text = "0";
                txtOriginalContractContractAmount.Text = "0";
            }
            if (!hasApprovedChanges)
            {
                txtApprovedChangesTotalCost.Text = "0";
                txtApprovedChangesContractAmount.Text = "0";
            }
            if (!hasPendingChanges)
            {
                txtPendingChangesTotalCost.Text = "0";
                txtPendingChangesContractAmount.Text = "0";
            }
            if (!hasPendingNoProceed)
            {
                txtPendingNoProceedTotalCost.Text = "0";
                txtPendingNoProceedContractAmount.Text = "0";
            }
            if (!hasAllowance)
            {
                txtAllowancesTotalCost.Text = "0";
                txtAllowancesContractAmount.Text = "0";
            }
            if (!hasCancelled)
            {
                txtCancelledTotalCost.Text = "0";
                txtCancelledContractAmount.Text = "0";
            }

            hasContract = false;
            hasApprovedChanges = false;
            hasPendingChanges = false;
            hasPendingNoProceed = false;
            hasCancelled = false;
            hasAllowance = false;
        }

        private void GroupHeader2_AfterPrint(object sender, EventArgs e)
        {
            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    hasContract = true;
                    break;
                case "B - Approved":
                    hasApprovedChanges = true;
                    break;
                case "C - Pending With Proceed":
                    hasPendingChanges = true;
                    break;
                case "D - Pending No Proceed":
                    hasPendingNoProceed = true;
                    break;
                case "X - Cancelled":
                    hasCancelled = true;
                    break;
                case "I - Allowances":
                    hasAllowance = true;
                    break;

            }
        }

 
      
    }
}
