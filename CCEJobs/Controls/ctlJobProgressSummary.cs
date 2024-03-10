using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using DevExpress.XtraGrid;

namespace CCEJobs.Controls
{
    public partial class ctlJobProgressSummary : UserControl
    {
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private bool upgradeable = false;
        private string jobID;
        private DataSet jobProgressSummaryDataSet;
        private bool systemUpdate = false;
        private bool currentPeriod = true;
        private string period = "";
        private bool isCommentChanged = false;
        private bool isTM = false;
        private bool isWarning = false;
        private bool trackChangeOrder = false;
        private string contractType = "";
        private bool updateStatus = false;

        //
        public ctlJobProgressSummary()
        {
            InitializeComponent();
            //
            // Add Tool Tip
            //
            toolTipController1.SetToolTip(lblProjectedProfit, "Projected Profit = Current Contract - Total Cost");
            toolTipController1.SetToolTipIconType(lblProjectedProfit, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblBaselineProfit, "Budget Profit = Current Contract - Current Budget");
            toolTipController1.SetToolTipIconType(lblBaselineProfit, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblLaborCompletePercentage, "Labor % Complete = Actual To Date Labor($) / Revised CAC Labor ($)");
            toolTipController1.SetToolTipIconType(lblLaborCompletePercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblBilledCompletePercentage, "Billed % Complete = Amount Billed / Current Contract");
            toolTipController1.SetToolTipIconType(lblBilledCompletePercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblProjectCompletePercentage, "Projected % Complete = Actual To Date Total($) / Revised CAC Total ($)");
            toolTipController1.SetToolTipIconType(lblProjectCompletePercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblProjectedProfitPercentage, "Projected Profit % = Projected Profit / Current Contract");
            toolTipController1.SetToolTipIconType(lblProjectedProfitPercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblBaselineProfitPercentage, "Current Profit % = Budget Profit / Current Contract \n" + " For T&M jobs, defaults to 0");
            toolTipController1.SetToolTipIconType(lblBaselineProfitPercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblProfitGainFade, "Profit Gain / Fade = Projected Profit % -  Baseline Profit %");
            toolTipController1.SetToolTipIconType(lblProfitGainFade, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblLaborPerformanceFactor, "Labor Perf. Factor =  Actual Hours  / Earned Hours ");
            toolTipController1.SetToolTipIconType(lblLaborPerformanceFactor, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblCostPerformanceFactor, "Cost Perf. Factor =  Revised CAC Labor ($)  / Current Budget Labor ($) ");
            toolTipController1.SetToolTipIconType(lblCostPerformanceFactor, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblMaterialPurchasedPercentage, "% of Material Purchased =  Actual To Date Material ($)  / Current Budget Material ($) ");
            toolTipController1.SetToolTip(lblCashReceivedPercent, "% Cash Percent =  Amount Paid  / Current Contract ");
            toolTipController1.SetToolTipIconType(lblMaterialPurchasedPercentage, DevExpress.Utils.ToolTipIconType.Information);


            cboPeriod.Properties.DataSource = StaticTables.ArchivePeriod;
            cboPeriod.Properties.PopulateColumns();
            cboPeriod.Properties.DisplayMember = "Period";
            cboPeriod.Properties.ShowHeader = false;
            cboPeriod.Visible = false;
            radioDataType.SelectedIndex = 0;
        }
        //

        public string ContractType
        {
            set
            {
                contractType = value;
                SetContractType();
            }
        }
        //
        public bool TrackChangeOrder
        {
            set
            {
                trackChangeOrder = value;
                SetContractType();

            }
        }
        //
        private void SetContractType()
        {
            switch (contractType)
            {
                case "TIME & MATERIAL":
                case "GUARANTEED MAXIMUM":
                case "COST PLUS":
                case "UNIT PRICE":
                    if (trackChangeOrder)
                    {
                        isTM = false;
                    }
                    else
                    {
                        isTM = true;
                    }
                    break;
                default:
                    isTM = false;
                    break;
            }
            if (contractType == "GUARANTEED MAXIMUM" || contractType == "TIME & MATERIAL" || contractType == "COST PLUS") 
                isWarning = true;
        }

        //
        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }
        //
        public string JobID
        {
            set 
            { 
                jobID = value;
                GetJobProgressSummary();
                SetControlAccess();
            }
        }
        //
        public bool Upgradeable
        {
            set
            {
                upgradeable = value;
            }
        }
        //
        public string Period
        {
            get
            {
                return period;
            }
        }
        //
        public bool CurrentPeriod
        {
            get
            {
                return currentPeriod;
            }
        }
        //
        private void GetJobProgressSummary()
        {

            string id;
            updateStatus = false;
            bool isCurrentComment = false;
            bool isArchiveComment = false;

            if (String.IsNullOrEmpty(jobID))
                id = "0";
            else
                id = jobID;
            try
            {
                // Check fo Current or History
                if (radioDataType.SelectedIndex == 1 && cboPeriod.Text.Trim().Length > 0)
                {
                    currentPeriod = false;
                    txtComment.Properties.ReadOnly = true;

                }
                else
                {
                    currentPeriod = true;
                    txtComment.Properties.ReadOnly = false;
                }
                if (currentPeriod)
                {
                    jobProgressSummaryDataSet = Job.GetJobSummary(id);
                    // Flag for the comments
                    isCurrentComment = Job.IsCurrentComment(id);
                    isArchiveComment = Job.IsArchiveComment(id);
                    if (isCurrentComment || isArchiveComment)
                    {
                        txtCommentWarning.Visible = true;
                        if (isCurrentComment)
                            txtCommentWarning.Text = "Current Comment - ";
                        if (isArchiveComment)
                            txtCommentWarning.Text += "Archived Comment ";
                        txtCommentWarning.ErrorText = txtCommentWarning.Text;
                    }
                    else
                        txtCommentWarning.Visible = false;

                    // End of the section here
                    if (!isTM)
                    {
                        if (Job.IsNoQuantity(id))
                            txtWarning.Visible = true;
                        else
                            txtWarning.Visible = false;
                    }
                    else
                        txtWarning.Visible = false;
                }
                else
                {
                    jobProgressSummaryDataSet = Job.GetJobSummaryHistory(id, cboPeriod.Text);
                    txtWarning.Visible = false;
                    txtCommentWarning.Visible = false;
                }


                if (jobProgressSummaryDataSet.Tables[0].Rows.Count > 0)
                {
                    txtOriginalContract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalContract"].ToString();
                    txtApprovedCO.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedCO"].ToString();
                    txtPendingCO.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingCO"].ToString();
                    txtNotApprovedCO.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["NotApprovedCO"].ToString();
                    txtCurrentContract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentContract"].ToString();

                    txtAmountBilled.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["AmountBilled"].ToString();
                    txtAmountPaid.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["AmountPaid"].ToString();
                    txtRetention.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["Retention"].ToString();
                    txtCashCost.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CashCost"].ToString();
                    txtBilledCost.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BilledCost"].ToString();

                    txtCurrentBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLaborHours"].ToString();
                    txtCurrentBudgetLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLaborHours100"].ToString();
                    txtCurrentBudgetLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLaborHours500"].ToString();
                    txtCurrentBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLabor"].ToString();
                    txtCurrentBudgetLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLabor100"].ToString();
                    txtCurrentBudgetLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLabor500"].ToString();
                    txtCurrentBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetMaterial"].ToString();
                    txtCurrentBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetRental"].ToString();
                    txtCurrentBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetSubcontract"].ToString();
                    txtCurrentBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetDJC"].ToString();


                    txtOriginalBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLaborHours"].ToString();
                    txtOriginalBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLabor"].ToString();

                    txtOriginalBudgetLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLaborHours100"].ToString();
                    txtOriginalBudgetLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLabor100"].ToString();
                    txtOriginalBudgetLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLaborHours500"].ToString();
                    txtOriginalBudgetLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLabor500"].ToString();
                    
                    txtOriginalBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetMaterial"].ToString();
                    txtOriginalBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetRental"].ToString();
                    txtOriginalBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetSubcontract"].ToString();
                    txtOriginalBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetDJC"].ToString();

                    txtApprovedBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLaborHours"].ToString();
                    txtApprovedBudgetLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLaborHours100"].ToString();
                    txtApprovedBudgetLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLaborHours500"].ToString();
                    
                    txtApprovedBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLabor"].ToString();
                    txtApprovedBudgetLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLabor100"].ToString();
                    txtApprovedBudgetLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLabor500"].ToString();
                    txtApprovedBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetMaterial"].ToString();
                    txtApprovedBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetRental"].ToString();
                    txtApprovedBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetSubcontract"].ToString();
                    txtApprovedBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetDJC"].ToString();

                    txtPendingBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLaborHours"].ToString();
                    txtPendingBudgetLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLaborHours100"].ToString();
                    txtPendingBudgetLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLaborHours500"].ToString();
                    txtPendingBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLabor"].ToString();
                    txtPendingBudgetLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLabor100"].ToString();
                    txtPendingBudgetLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLabor500"].ToString();
                    txtPendingBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetMaterial"].ToString();
                    txtPendingBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetRental"].ToString();
                    txtPendingBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetSubcontract"].ToString();
                    txtPendingBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetDJC"].ToString();

                    txtCommittedCostToDateLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLaborHours"].ToString();
                    txtCommittedCostToDateLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLaborHours100"].ToString();
                    txtCommittedCostToDateLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLaborHours500"].ToString();
                    txtCommittedCostToDateLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLabor"].ToString();
                    txtCommittedCostToDateLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLabor100"].ToString();
                    txtCommittedCostToDateLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLabor500"].ToString();
                    txtCommittedCostToDateMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateMaterial"].ToString();
                    txtCommittedCostToDateRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateRental"].ToString();
                    txtCommittedCostToDateSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateSubcontract"].ToString();
                    txtCommittedCostToDateDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateDJC"].ToString();


                    txtOpenCommitLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLaborHours"].ToString();
                    txtOpenCommitLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLaborHours100"].ToString();
                    txtOpenCommitLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLaborHours500"].ToString();
                    txtOpenCommitLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLabor"].ToString();
                    txtOpenCommitLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLabor100"].ToString();
                    txtOpenCommitLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLabor500"].ToString();
                    txtOpenCommitMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitMaterial"].ToString();
                    txtOpenCommitRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitRental"].ToString();
                    txtOpenCommitSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitSubcontract"].ToString();
                    txtOpenCommitDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitDJC"].ToString();
                    txtOpenCommit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommit"].ToString();



                    txtCostToCompleteLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLaborHours"].ToString();
                    txtCostToCompleteLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLaborHours100"].ToString();
                    txtCostToCompleteLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLaborHours500"].ToString();
                    txtCostToCompleteLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLabor"].ToString();
                    txtCostToCompleteLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLabor100"].ToString();
                    txtCostToCompleteLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLabor500"].ToString();
                    txtCostToCompleteMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteMaterial"].ToString();
                    txtCostToCompleteRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteRental"].ToString();
                    txtCostToCompleteSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteSubcontract"].ToString();
                    txtCostToCompleteDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteDJC"].ToString();

                    txtCostToCommitLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitLaborHours"].ToString();
                    txtCostToCommitLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitLaborHours100"].ToString();
                    txtCostToCommitLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitLaborHours500"].ToString();
                    txtCostToCommitLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitLabor"].ToString();
                    txtCostToCommitLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitLabor100"].ToString();
                    txtCostToCommitLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitLabor500"].ToString();
                    txtCostToCommitMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitMaterial"].ToString();
                    txtCostToCommitRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitRental"].ToString();
                    txtCostToCommitSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitSubcontract"].ToString();
                    txtCostToCommitDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommitDJC"].ToString();

                    txtWIPCostToCompleteLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLaborHours"].ToString();
                    txtWIPCostToCompleteLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLaborHours100"].ToString();
                    txtWIPCostToCompleteLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLaborHours500"].ToString();
                    txtWIPCostToCompleteLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLabor"].ToString();
                    txtWIPCostToCompleteLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLabor100"].ToString();
                    txtWIPCostToCompleteLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLabor500"].ToString();
                    txtWIPCostToCompleteMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteMaterial"].ToString();
                    txtWIPCostToCompleteRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteRental"].ToString();
                    txtWIPCostToCompleteSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteSubcontract"].ToString();
                    txtWIPCostToCompleteDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteDJC"].ToString();

                    txtVarianceLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLaborHours"].ToString();
                    txtVarianceLaborHours100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLaborHours100"].ToString();
                    txtVarianceLaborHours500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLaborHours500"].ToString();
                    txtVarianceLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLabor"].ToString();
                    txtVarianceLabor100.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLabor100"].ToString();
                    txtVarianceLabor500.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLabor500"].ToString();
                    txtVarianceMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceMaterial"].ToString();
                    txtVarianceRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceRental"].ToString();
                    txtVarianceSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceSubcontract"].ToString();
                    txtVarianceDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceDJC"].ToString();
                    txtVariance.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["Variance"].ToString();

                    txtCurrentBudget.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudget"].ToString();
                    txtOriginalBudget.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudget"].ToString();
                    txtApprovedBudget.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudget"].ToString();
                    txtPendingBudget.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudget"].ToString();
                    
                    txtCommittedCostToDate.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDate"].ToString();
                    txtCostToComplete.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToComplete"].ToString();
                    txtCostToCommit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCommit"].ToString();
                    txtWIPCostToComplete.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToComplete"].ToString();

                    txtProjectedProfit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ProjectedProfit"].ToString();
                    txtBaselineProfit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BaselineProfit"].ToString();

                    txtLaborCompletePercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["LaborCompletePercentage"].ToString();
                    txtBilledCompletePercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BilledCompletePercentage"].ToString();
                    txtCostToCostCompletePercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCostCompletePercentage"].ToString();

                    txtProjectedProfitPercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ProjectedProfitPercentage"].ToString();
                    txtBaselineProfitPercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BaselineProfitPercentage"].ToString();

                    txtProfitGainFade.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ProfitGainFade"].ToString();
                    txtJobPerformanceFactor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["JobPerformanceFactor"].ToString();

                    txtCostPerformanceFactor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostPerformanceFactor"].ToString();
                    txtLaborPercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["LaborPercentage"].ToString();
                    txtMaterialPercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["MaterialPercentage"].ToString();
                    txtMaterialPOTotal.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["MaterialPOTotal"].ToString();
                    txtCostThisMonth.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostThisMonth"].ToString();
                    txtBillingThisMonth.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BillingThisMonth"].ToString();
                    txtApprovedBy.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBy"].ToString();
                    txtComment.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["Comment"].ToString();
                    txtCashReceivedPercent.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CashReceivedPercent"].ToString();
                    // 
                    // Update for Warning
                    //
                    double committedCost = Convert.ToDouble(jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDate"].ToString());
                    double currentContract = Convert.ToDouble(jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentContract"].ToString());
                    if (currentContract > 0 && ( (committedCost / currentContract) > .80) && isWarning == true)
                        lblWarning.Visible = true;
                    else
                        lblWarning.Visible = false;
                    isCommentChanged = false; 
                    if (Convert.ToBoolean(jobProgressSummaryDataSet.Tables[0].Rows[0]["Approved"].ToString()))
                    {
                        systemUpdate = true;
                        chkApproved.Checked = Convert.ToBoolean(jobProgressSummaryDataSet.Tables[0].Rows[0]["Approved"].ToString());
                        chkApproved.Properties.ReadOnly = true;
                    }
                    else
                    {
                        systemUpdate = true;
                        chkApproved.Checked = false;
                        chkApproved.Properties.ReadOnly = false;
                        systemUpdate = false;
                    }
                    chkJobCompleted.Checked = Convert.ToBoolean(jobProgressSummaryDataSet.Tables[0].Rows[0]["JobCompleted"].ToString());

                    ValidateDashboard();
                }
                else
                {
                    txtOriginalContract.Text = null;
                    txtApprovedCO.Text = null;
                    txtPendingCO.Text = null;
                    txtNotApprovedCO.Text = null;
                    txtCurrentContract.Text = null;
                    txtAmountBilled.Text = null;
                    txtAmountPaid.Text = null;
                    txtRetention.Text = null;
                    txtCashCost.Text = null;
                    txtBilledCost.Text = null;

                    txtCurrentBudgetLaborHours.Text = null;
                    txtCurrentBudgetLaborHours100.Text = null;
                    txtCurrentBudgetLaborHours500.Text = null;
                    txtCurrentBudgetLabor.Text = null;
                    txtCurrentBudgetLabor100.Text = null;
                    txtCurrentBudgetLabor500.Text = null;
                    txtCurrentBudgetMaterial.Text = null;
                    txtCurrentBudgetRental.Text = null;
                    txtCurrentBudgetSubcontract.Text = null;
                    txtCurrentBudgetDJC.Text = null;

                    txtOriginalBudgetLaborHours.Text = null;
                    txtOriginalBudgetLaborHours100.Text = null;
                    txtOriginalBudgetLaborHours500.Text = null;
                    txtOriginalBudgetLabor.Text = null;
                    txtOriginalBudgetLabor100.Text = null;
                    txtOriginalBudgetLabor500.Text = null;
                    txtOriginalBudgetMaterial.Text = null;
                    txtOriginalBudgetRental.Text = null;
                    txtOriginalBudgetSubcontract.Text = null;
                    txtOriginalBudgetDJC.Text = null;

                    txtApprovedBudgetLaborHours.Text = null;
                    txtApprovedBudgetLaborHours100.Text = null;
                    txtApprovedBudgetLaborHours500.Text = null;
                    txtApprovedBudgetLabor.Text = null;
                    txtApprovedBudgetLabor100.Text = null;
                    txtApprovedBudgetLabor500.Text = null;
                    txtApprovedBudgetMaterial.Text = null;
                    txtApprovedBudgetRental.Text = null;
                    txtApprovedBudgetSubcontract.Text = null;
                    txtApprovedBudgetDJC.Text = null;

                    txtPendingBudgetLaborHours.Text = null;
                    txtPendingBudgetLaborHours100.Text = null;
                    txtPendingBudgetLaborHours500.Text = null;
                    txtPendingBudgetLabor.Text = null;
                    txtPendingBudgetLabor100.Text = null;
                    txtPendingBudgetLabor500.Text = null;
                    txtPendingBudgetMaterial.Text = null;
                    txtPendingBudgetRental.Text = null;
                    txtPendingBudgetSubcontract.Text = null;
                    txtPendingBudgetDJC.Text = null;


                    txtCommittedCostToDateLaborHours.Text = null;
                    txtCommittedCostToDateLaborHours100.Text = null;
                    txtCommittedCostToDateLaborHours500.Text = null;
                    txtCommittedCostToDateLabor.Text = null;
                    txtCommittedCostToDateLabor100.Text = null;
                    txtCommittedCostToDateLabor500.Text = null;
                    txtCommittedCostToDateMaterial.Text = null;
                    txtCommittedCostToDateRental.Text = null;
                    txtCommittedCostToDateSubcontract.Text = null;
                    txtCommittedCostToDateDJC.Text = null;

                    txtOpenCommitLaborHours.Text = null;
                    txtOpenCommitLaborHours100.Text = null;
                    txtOpenCommitLaborHours500.Text = null;
                    txtOpenCommitLabor.Text = null;
                    txtOpenCommitLabor100.Text = null;
                    txtOpenCommitLabor500.Text = null;
                    txtOpenCommitMaterial.Text = null;
                    txtOpenCommitRental.Text = null;
                    txtOpenCommitSubcontract.Text = null;
                    txtOpenCommitDJC.Text = null;
                    txtOpenCommit.Text = null;

                    txtCostToCompleteLaborHours.Text = null;
                    txtCostToCompleteLaborHours100.Text = null;
                    txtCostToCompleteLaborHours500.Text = null;
                    txtCostToCompleteLabor.Text = null;
                    txtCostToCompleteLabor100.Text = null;
                    txtCostToCompleteLabor500.Text = null;
                    txtCostToCompleteMaterial.Text = null;
                    txtCostToCompleteRental.Text = null;
                    txtCostToCompleteSubcontract.Text = null;
                    txtCostToCompleteDJC.Text = null;

                    txtCostToCommitLaborHours.Text = null;
                    txtCostToCommitLaborHours100.Text = null;
                    txtCostToCommitLaborHours500.Text = null;
                    txtCostToCommitLabor.Text = null;
                    txtCostToCommitLabor100.Text = null;
                    txtCostToCommitLabor500.Text = null;
                    txtCostToCommitMaterial.Text = null;
                    txtCostToCommitRental.Text = null;
                    txtCostToCommitSubcontract.Text = null;
                    txtCostToCommitDJC.Text = null;
                    txtCurrentBudget.Text = null;

                    txtOriginalBudget.Text = null;
                    txtApprovedBudget.Text = null;
                    txtPendingBudget.Text = null;

                    txtCommittedCostToDate.Text = null;
                    txtCostToComplete.Text = null;
                    txtCostToCommit.Text = null;
                    txtProjectedProfit.Text = null;
                    txtBaselineProfit.Text = null;
                    txtLaborCompletePercentage.Text = null;
                    txtBilledCompletePercentage.Text = null;
                    txtCostToCostCompletePercentage.Text = null;
                    txtProjectedProfitPercentage.Text = null;
                    txtBaselineProfitPercentage.Text = null;
                    txtProfitGainFade.Text = null;
                    txtJobPerformanceFactor.Text = null;
                    txtCostPerformanceFactor.Text = null;
                    txtLaborPercentage.Text = null;
                    txtMaterialPercentage.Text = null;

                    txtVarianceLaborHours.Text = null;
                    txtVarianceLaborHours100.Text = null;
                    txtVarianceLaborHours500.Text = null;
                    txtVarianceLabor.Text = null;
                    txtVarianceLabor100.Text = null;
                    txtVarianceLabor500.Text = null;
                    txtVarianceMaterial.Text = null;
                    txtVarianceRental.Text = null;
                    txtVarianceSubcontract.Text = null;
                    txtVarianceDJC.Text = null;
                    txtVariance.Text = null;
                    txtApprovedBy.Text = null;
                    chkApproved.Checked = false;
                    chkJobCompleted.Checked = false;
                    

                    ClearDashboardFlags();
                }
                btnSave.Visible = false;
                updateStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void ValidateDashboard()
        {           
            if (!isTM)
            {
                txtJobPerformanceFactor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                txtProfitGainFade.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                txtProjectedProfitPercentage.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                txtCostPerformanceFactor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                txtMaterialPercentage.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;

                txtJobPerformanceFactor.ToolTip = "Warning will be displayed when Performace Factor is > " + StaticTables.jobPerformanceFactor.ToString();
                txtProfitGainFade.ToolTip = "Warning will be displayed when Gain Fade is  < " + StaticTables.profitGainFade.ToString();
                txtProjectedProfitPercentage.ToolTip = "Warning will be displayed when Profit Percentage is < " + StaticTables.projectedProfitPercentage.ToString();

                txtCostPerformanceFactor.ToolTip = "Warning will be displayed when Cost Performance Factor is > " + StaticTables.costPerformanceFactor.ToString();
                txtMaterialPercentage.ToolTip = "Warning will be displayed when Labor Percentage is > " + StaticTables.laborPercentage.ToString() +
                                                " and Material Percentage is < " + StaticTables.materialPercentage.ToString();


                if (Convert.ToDouble(txtJobPerformanceFactor.Text.Replace("%", "").Replace(",", "")) > StaticTables.jobPerformanceFactor)
                {
                    picJobPerformanceFactor.ToolTip = "Job Performance Factor > " + StaticTables.jobPerformanceFactor.ToString();
                    picJobPerformanceFactor.Visible = true;
                }
                else
                    picJobPerformanceFactor.Visible = false;

                if (Convert.ToDouble(txtProjectedProfitPercentage.Text.Replace("%", "").Replace(",", "")) < StaticTables.projectedProfitPercentage)
                {
                    picProjectedProfitPercentage.ToolTip = " Projected Profit Percentage < " + StaticTables.projectedProfitPercentage.ToString();
                    picProjectedProfitPercentage.Visible = true;
                }
                else
                    picProjectedProfitPercentage.Visible = false;

                //
                if (Convert.ToDouble(txtProfitGainFade.Text.Replace("%", "").Replace(",", "")) < StaticTables.profitGainFade)
                {
                    picProfitGainFade.ToolTip = "Gain Fade < " + StaticTables.profitGainFade.ToString();
                    //picProfitGainFade.Visible = true;
                    picProfitGainFade.Visible = false;
                }
                else
                    picProfitGainFade.Visible = false;

                if (Convert.ToDouble(txtCostPerformanceFactor.Text.Replace("%", "").Replace(",", "")) > StaticTables.costPerformanceFactor)
                {
                    picCostPerformanceFactor.ToolTip = "Cost Performance Factor > " + StaticTables.costPerformanceFactor.ToString();
                    picCostPerformanceFactor.Visible = true;
                }
                else
                    picCostPerformanceFactor.Visible = false;

                double materialPercentage = Convert.ToDouble(txtMaterialPercentage.Text.Replace("%", "").Replace(",", ""));
                double laborPercentage = Convert.ToDouble(txtLaborPercentage.Text.Replace("%", "").Replace(",", ""));
                if ( materialPercentage < StaticTables.materialPercentage && laborPercentage > StaticTables.laborPercentage)
                {
                    picMaterialPercentage.ToolTip = "Labor Percentage is > " + StaticTables.laborPercentage.ToString() +
                                                    " and Material Percentage is < " + StaticTables.materialPercentage.ToString();
                    picMaterialPercentage.Visible = true;
                }
                else
                    picMaterialPercentage.Visible = false;
            }
            else
            {
                ClearDashboardFlags();       
            }
        }
        //
        private void ClearDashboardFlags()
        {
            txtJobPerformanceFactor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            txtProfitGainFade.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            txtProjectedProfitPercentage.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            txtCostPerformanceFactor.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            txtMaterialPercentage.ToolTipIconType = DevExpress.Utils.ToolTipIconType.None;
            //
            txtJobPerformanceFactor.ToolTip = "";
            txtProfitGainFade.ToolTip = "";
            txtProjectedProfitPercentage.ToolTip = "";
            txtCostPerformanceFactor.ToolTip = "";
            txtMaterialPercentage.ToolTip = "";
            //
            picJobPerformanceFactor.Visible = false;
            picProjectedProfitPercentage.Visible = false;
            picProfitGainFade.Visible = false;
            picCostPerformanceFactor.Visible = false;
            picMaterialPercentage.Visible = false;
        }
        //
        private void chkApproved_CheckedChanged(object sender, EventArgs e)
        {
            if (!updateStatus)
                return;
            if (systemUpdate)
            {
                systemUpdate = false;
            }
            else
            {
                string projectProfit = txtProjectedProfit.Text;
                if (String.IsNullOrEmpty(projectProfit))
                {
                  
                }
                else
                {
                    if (chkApproved.CheckState == CheckState.Checked)
                    {
                        if (float.Parse(projectProfit.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) < 0)
                        {
                            if (MessageBox.Show("Projected Profit is Negative. Do you want to approve?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                if (Job.UpdateJobSummary(jobID, chkApproved.Checked.ToString(), chkJobCompleted.Checked.ToString(), Security.Security.LoginID, txtComment.Text))
                                {
                                    txtApprovedBy.Text = Security.Security.LoginID;
                                    if (btnSave.Visible)
                                        btnSave.Visible = false;
                                }
                            }
                            else
                                chkApproved.Checked = false;

                        }
                        else
                        {
                            if (Job.UpdateJobSummary(jobID, chkApproved.Checked.ToString(), chkJobCompleted.Checked.ToString(), Security.Security.LoginID, txtComment.Text))
                                txtApprovedBy.Text = Security.Security.LoginID;
                        }
                    }
                }
            }
        }
        //
        private void radioDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioDataType.SelectedIndex == 0)
            {
                lblPeriod.Visible = false;
                cboPeriod.Visible = false;
                panApproval.Visible = true;
                if (cboPeriod.Text.Trim().Length > 0)
                {
                    GetJobProgressSummary();
                    cboPeriod.EditValue = String.Empty;
                }
            }
            else
            {
                lblPeriod.Visible = true;
                cboPeriod.Visible = true;
                panApproval.Visible = false;
            }
          
        }
        //
        private void cboPeriod_EditValueChanged(object sender, EventArgs e)
        {
            period = cboPeriod.Text;
            GetJobProgressSummary();
        }

        private void chkJobCompleted_CheckedChanged(object sender, EventArgs e)
        {
            if (!updateStatus)
                return;
            if (Job.UpdateJobSummary(jobID, chkApproved.Checked.ToString(), chkJobCompleted.Checked.ToString(), Security.Security.LoginID,txtComment.Text))
                txtApprovedBy.Text = Security.Security.LoginID;

        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                chkApproved.Properties.ReadOnly = true;
                chkJobCompleted.Properties.ReadOnly = true;
                txtComment.Properties.ReadOnly = true;
            }
            else
            {
                txtComment.Properties.ReadOnly = false;
                chkApproved.Properties.ReadOnly = false;
                chkJobCompleted.Properties.ReadOnly = false;
            }
            if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
              Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
            {
                lblWIP1.Visible = true;
                lblWIP2.Visible = true;
                lblWIP3.Visible = true;
                lblWIP4.Visible = true;
                lblWIP5.Visible = true;
                txtWIPCostToCompleteLaborHours.Visible = true;
                txtWIPCostToCompleteLaborHours100.Visible = true;
                txtWIPCostToCompleteLaborHours500.Visible = true;
                txtWIPCostToCompleteLabor.Visible = true;
                txtWIPCostToCompleteLabor100.Visible = true;
                txtWIPCostToCompleteLabor500.Visible = true;
                txtWIPCostToCompleteMaterial.Visible = true;
                txtWIPCostToCompleteRental.Visible = true;
                txtWIPCostToCompleteSubcontract.Visible = true;
                txtWIPCostToCompleteDJC.Visible = true;
                txtWIPCostToComplete.Visible = true;
            }
            else
            {
                lblWIP1.Visible = false;
                lblWIP2.Visible = false;
                lblWIP3.Visible = false;
                lblWIP4.Visible = false;
                lblWIP5.Visible = false;
                txtWIPCostToCompleteLaborHours.Visible = false;
                txtWIPCostToCompleteLaborHours100.Visible = false;
                txtWIPCostToCompleteLaborHours500.Visible = false;
                txtWIPCostToCompleteLabor.Visible = false;
                txtWIPCostToCompleteLabor100.Visible = false;
                txtWIPCostToCompleteLabor500.Visible = false;
                txtWIPCostToCompleteMaterial.Visible = false;
                txtWIPCostToCompleteRental.Visible = false;
                txtWIPCostToCompleteSubcontract.Visible = false;
                txtWIPCostToCompleteDJC.Visible = false;
                txtWIPCostToComplete.Visible = false;
            }
        }

        private void txtComment_EditValueChanged(object sender, EventArgs e)
        {
            isCommentChanged = true;
            btnSave.Visible = true;
        }

        private void txtComment_Leave(object sender, EventArgs e)
        {
            if (!updateStatus)
                return;
            if (isCommentChanged)
            {
                isCommentChanged = false;
                btnSave.Visible = false;
                Job.UpdateJobSummary(jobID, chkApproved.Checked.ToString(), chkJobCompleted.Checked.ToString(), Security.Security.LoginID, txtComment.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!updateStatus)
                return;
            if (isCommentChanged)
            {
                isCommentChanged = false;
                btnSave.Visible = false;
                Job.UpdateJobSummary(jobID, chkApproved.Checked.ToString(), chkJobCompleted.Checked.ToString(), Security.Security.LoginID, txtComment.Text);
            }
        }
    }
}
