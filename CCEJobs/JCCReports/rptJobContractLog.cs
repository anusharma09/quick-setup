using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobContractLog : DevExpress.XtraReports.UI.XtraReport
    {
        private bool hasContract = false;
        private bool hasApprovedChanges = false;
        private bool hasPendingChanges = false;
        private bool hasPendingNoProceed = false;
        private bool hasCancelled = false;
        private bool hasAllowance = false;
               
          
        public rptJobContractLog()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }
        
        private void txtHours_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";
  
        
             summaryS = txtHours.Summary.GetResult().ToString();
           
            
        
            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);


            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractHours.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesHours.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesHours.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedHours.Text = summaryS;
                    break;
                case "X - Cancelled":
                    if (hasCancelled)
                        txtCancelledHours.Text = summaryS;
                    else
                        txtCancelledHours.Text = "0";
                    break;
                case "I - Allowances":
                    txtCancelledHours.Text = summaryS;
                    break;

            }
           
        }

        private void txtLabor_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";


             summaryS = txtLabor.Summary.GetResult().ToString();

            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);


            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractLabor.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesLabor.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesLabor.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedLabor.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledLabor.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledLabor.Text = summaryS;
                    break;
            }
        }

        private void txtSubContract_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";


            summaryS = txtSubContract.Summary.GetResult().ToString();

            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);


            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractSubcontract.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesSubcontract.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesSubcontract.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedSubcontract.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledSubcontract.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledSubcontract.Text = summaryS;
                    break;

            }
        }

        private void txtMaterial_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";


            summaryS = txtMaterial.Summary.GetResult().ToString();

            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);


            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractMaterial.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesMaterial.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesMaterial.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedMaterial.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledMaterial.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledMaterial.Text = summaryS;
                    break;

            }
        }

        private void txtExpense_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";


            summaryS = txtExpense.Summary.GetResult().ToString();

            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);


            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractExpense.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesExpense.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesExpense.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedExpense.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledExpense.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledExpense.Text = summaryS;
                    break;

            }
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
            txtEstimateProfitPercent.Text = CalculatePercent(txtEstProfit.Summary.GetResult().ToString(), txtContractAmount.Summary.GetResult().ToString());
        }

        private void txtEstProfit_AfterPrint(object sender, EventArgs e)
        {
            double summary = 0;
            string summaryS = "0";


            summaryS = txtEstProfit.Summary.GetResult().ToString();

             

            if (summaryS.Trim().Length == 0)
                summaryS = "0";

            if (!String.IsNullOrEmpty(summaryS))
                summary = Convert.ToDouble(summaryS);
            summaryS = String.Format("{0:n0}", summary);

            switch (txtHeaderGroup.Text.Trim())
            {
                case "":
                    txtOriginalContractEstProfit.Text = summaryS;
                    break;
                case "B - Approved":
                    txtApprovedChangesEstProfit.Text = summaryS;
                    break;
                case "C - Pending With Proceed":
                    txtPendingChangesEstProfit.Text = summaryS;
                    break;
                case "D - Pending No Proceed":
                    txtPendingNoProceedEstProfit.Text = summaryS;
                    break;
                case "X - Cancelled":
                    txtCancelledEstProfit.Text = summaryS;
                    break;
                case "I - Allowances":
                    txtCancelledEstProfit.Text = summaryS;
                    break;

            }
            txtEstimateProfitPercent.Text = CalculatePercent(txtEstProfit.Summary.GetResult().ToString(), txtContractAmount.Summary.GetResult().ToString());
        }


        private void xrLabel12_AfterPrint(object sender, EventArgs e)
        {
           
        }

        private string CalculatePercent(string estProfit, string contractAmount)
        {
            double percent = 0;
            if (estProfit.Trim().Length > 0 && contractAmount.Trim().Length > 0)
            {
                double est =  Convert.ToDouble(estProfit.Replace(",","").Replace("%",""));
                double contract = Convert.ToDouble(contractAmount.Replace(",", "").Replace("%",""));

                if (contract != 0)
                    percent = est / contract;
                

            }
            return String.Format("{0:0%}", percent);
        }

        private void txtOriginalContractEstProfit_AfterPrint(object sender, EventArgs e)
        {
            txtOriginalContractPercent.Text = 
                CalculatePercent(txtOriginalContractEstProfit.Text, 
                txtOriginalContractContractAmount.Text);
        }

        private void txtOriginalContractContractAmount_AfterPrint(object sender, EventArgs e)
        {
            txtOriginalContractPercent.Text =
             CalculatePercent(txtOriginalContractEstProfit.Text,
             txtOriginalContractContractAmount.Text);
        }

        private void txtApprovedChangesContractAmount_AfterPrint(object sender, EventArgs e)
        {
            txtApprovedChangesPercent.Text =
             CalculatePercent(txtApprovedChangesEstProfit.Text,
             txtApprovedChangesContractAmount.Text);
        }

        private void txtApprovedChangesEstProfit_AfterPrint(object sender, EventArgs e)
        {
            txtApprovedChangesPercent.Text =
                CalculatePercent(txtApprovedChangesEstProfit.Text,
                txtApprovedChangesContractAmount.Text);
        }

        private void txtPendingChangesContractAmount_AfterPrint(object sender, EventArgs e)
        {
            txtPendingChangesPercent.Text =
                CalculatePercent(txtPendingChangesEstProfit.Text,
                txtPendingChangesContractAmount.Text);

        }

        private void txtPendingChangesEstProfit_AfterPrint(object sender, EventArgs e)
        {
            txtPendingChangesPercent.Text =
                CalculatePercent(txtPendingChangesEstProfit.Text,
                txtPendingChangesContractAmount.Text);
        }

        private void txtPendingNoProceedContractAmount_AfterPrint(object sender, EventArgs e)
        {
            txtPendingNoProceedPercent.Text =
                CalculatePercent(txtPendingNoProceedEstProfit.Text,
                txtPendingNoProceedContractAmount.Text);
        }

        private void txtPendingNoProceedEstProfit_AfterPrint(object sender, EventArgs e)
        {
            txtPendingNoProceedPercent.Text =
                CalculatePercent(txtPendingNoProceedEstProfit.Text,
                txtPendingNoProceedContractAmount.Text);
        }

        private void txtAllowancesContractAmount_AfterPrint(object sender, EventArgs e)
        {
            txtAllowancesPercent.Text =
                CalculatePercent(txtAllowancesEstProfit.Text,
                txtAllowancesContractAmount.Text);
        }

        private void txtAllowancesEstProfit_AfterPrint(object sender, EventArgs e)
        {
            txtAllowancesPercent.Text =
                CalculatePercent(txtAllowancesEstProfit.Text,
                txtAllowancesContractAmount.Text);
        }

        private void txtCancelledContractAmount_AfterPrint(object sender, EventArgs e)
        {
            txtCancelledPercent.Text =
                CalculatePercent(txtCancelledEstProfit.Text,
                txtCancelledContractAmount.Text);
        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!hasContract)
            {
                txtOriginalContractHours.Text = "0";
                txtOriginalContractLabor.Text = "0";
                txtOriginalContractSubcontract.Text = "0";
                txtOriginalContractMaterial.Text = "0";
                txtOriginalContractExpense.Text = "0";
                txtOriginalContractTotalCost.Text = "0";
                txtOriginalContractContractAmount.Text = "0";
                txtOriginalContractEstProfit.Text = "0";
                txtOriginalContractPercent.Text = "0";
            }
            if (!hasApprovedChanges)
            {
                txtApprovedChangesHours.Text = "0";
                txtApprovedChangesLabor.Text = "0";
                txtApprovedChangesSubcontract.Text = "0";
                txtApprovedChangesMaterial.Text = "0";
                txtApprovedChangesExpense.Text = "0";
                txtApprovedChangesTotalCost.Text = "0";
                txtApprovedChangesContractAmount.Text = "0";
                txtApprovedChangesEstProfit.Text = "0";
                txtApprovedChangesPercent.Text = "0";
            }
            if (!hasPendingChanges)
            {
                txtPendingChangesHours.Text = "0";
                txtPendingChangesLabor.Text = "0";
                txtPendingChangesSubcontract.Text = "0";
                txtPendingChangesMaterial.Text = "0";
                txtPendingChangesExpense.Text = "0";
                txtPendingChangesTotalCost.Text = "0";
                txtPendingChangesContractAmount.Text = "0";
                txtPendingChangesEstProfit.Text = "0";
                txtPendingChangesPercent.Text = "0";
            }
            if (!hasPendingNoProceed)
            {
                txtPendingNoProceedHours.Text = "0";
                txtPendingNoProceedLabor.Text = "0";
                txtPendingNoProceedSubcontract.Text = "0";
                txtPendingNoProceedMaterial.Text = "0";
                txtPendingNoProceedExpense.Text = "0";
                txtPendingNoProceedTotalCost.Text = "0";
                txtPendingNoProceedContractAmount.Text = "0";
                txtPendingNoProceedEstProfit.Text = "0";
                txtPendingNoProceedPercent.Text = "0";
            }
            if (!hasAllowance)
            {
                txtAllowancesHours.Text = "0";
                txtAllowancesLabor.Text = "0";
                txtAllowancesSubcontract.Text = "0";
                txtAllowancesMaterial.Text = "0";
                txtAllowancesExpense.Text = "0";
                txtAllowancesTotalCost.Text = "0";
                txtAllowancesContractAmount.Text = "0";
                txtAllowancesEstProfit.Text = "0";
                txtAllowancesPercent.Text = "0";
            }
            if (!hasCancelled)
            {
                txtCancelledHours.Text = "0";
                txtCancelledLabor.Text = "0";
                txtCancelledSubcontract.Text = "0";
                txtCancelledMaterial.Text = "0";
                txtCancelledExpense.Text = "0";
                txtCancelledTotalCost.Text = "0";
                txtCancelledContractAmount.Text = "0";
                txtCancelledEstProfit.Text = "0";
                txtCancelledPercent.Text = "0";
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
