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
    public partial class ctlJobProgressSummaryWIP : UserControl
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
        private bool trackChangeOrder = false;
        private string contractType;
        private bool updateStatus = false;
        //
        public ctlJobProgressSummaryWIP()
        {
            InitializeComponent();

            //
            // Add Tool Tip
            //
            toolTipController1.SetToolTip(lblProjectedProfit, "Projected Profit = Current Contract - WIP Month End CAC");
            toolTipController1.SetToolTipIconType(lblProjectedProfit, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblBaselineProfit, "Baseline Profit = Original Contract - Original Cost");
            toolTipController1.SetToolTipIconType(lblBaselineProfit, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblLaborCompletePercentage, "Labor % Complete = Actual To Date Labor($) / Revised CAC Labor ($)");
            toolTipController1.SetToolTipIconType(lblLaborCompletePercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblBilledCompletePercentage, "Billed % Complete = Amount Billed / Current Contract");
            toolTipController1.SetToolTipIconType(lblBilledCompletePercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblProjectCompletePercentage, "Projected % Complete = Actual To Date Total($) / Revised CAC Total ($)");
            toolTipController1.SetToolTipIconType(lblProjectCompletePercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblProjectedProfitPercentage, "Projected Profit % = Projected Profit / Current Contract");
            toolTipController1.SetToolTipIconType(lblProjectedProfitPercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblBaselineProfitPercentage, "Baseline Profit % = Baseline Profit / Original Contract \n" + " For T&M jobs, defaults to 0" );
            toolTipController1.SetToolTipIconType(lblBaselineProfitPercentage, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblProfitGainFade, "Profit Gain / Fade = Projected Profit % -  Baseline Profit %");
            toolTipController1.SetToolTipIconType(lblProfitGainFade, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblLaborPerformanceFactor, "Labor Perf. Factor =  Estimate Performance Factor  / Budget Hours Labor ");
            toolTipController1.SetToolTipIconType(lblLaborPerformanceFactor, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblCostPerformanceFactor, "Cost Perf. Factor =  Revised CAC Labor ($)  / Current Budget Labor ($) ");
            toolTipController1.SetToolTipIconType(lblCostPerformanceFactor, DevExpress.Utils.ToolTipIconType.Information);
            toolTipController1.SetToolTip(lblMaterialPurchasedPercentage, "% of Material Purchased =  Actual To Date Material ($)  / Current Budget Material ($) ");
            toolTipController1.SetToolTip(lblCashReceivedPercent, "% Cash Percent =  Amount Paind  / Current Contract ");

            toolTipController1.SetToolTipIconType(lblMaterialPurchasedPercentage, DevExpress.Utils.ToolTipIconType.Information);

            cboPeriod.Properties.DataSource = StaticTables.ArchivePeriod;
            cboPeriod.Properties.PopulateColumns();
            cboPeriod.Properties.DisplayMember = "Period";
            cboPeriod.Properties.ShowHeader = false;
            cboPeriod.Visible = false;
            radioDataType.SelectedIndex = 0;
        }

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
                    jobProgressSummaryDataSet = Job.GetJobSummary(id);
                else
                    jobProgressSummaryDataSet = Job.GetJobSummaryHistory(id, cboPeriod.Text);


                if (jobProgressSummaryDataSet.Tables[0].Rows.Count > 0)
                {
                    txtOriginalContract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalContract"].ToString();
                    txtApprovedCO.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedCO"].ToString();
                    txtPendingCO.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPPendingCO"].ToString();
                    txtNotApprovedCO.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["NotApprovedCO"].ToString();
                    txtCurrentContract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCurrentContract"].ToString();

                    txtAmountBilled.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["AmountBilled"].ToString();
                    txtAmountPaid.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["AmountPaid"].ToString();
                    txtRetention.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["Retention"].ToString();
                    txtCashCost.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CashCost"].ToString();
                    txtBilledCost.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BilledCost"].ToString();

                    txtCurrentBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLaborHours"].ToString();
                    txtCurrentBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetLabor"].ToString();
                    txtCurrentBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetMaterial"].ToString();
                    txtCurrentBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetRental"].ToString();
                    txtCurrentBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetSubcontract"].ToString();
                    txtCurrentBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CurrentBudgetDJC"].ToString();


                    txtOriginalBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLaborHours"].ToString();
                    txtOriginalBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetLabor"].ToString();
                    txtOriginalBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetMaterial"].ToString();
                    txtOriginalBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetRental"].ToString();
                    txtOriginalBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetSubcontract"].ToString();
                    txtOriginalBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OriginalBudgetDJC"].ToString();

                    txtApprovedBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLaborHours"].ToString();
                    txtApprovedBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetLabor"].ToString();
                    txtApprovedBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetMaterial"].ToString();
                    txtApprovedBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetRental"].ToString();
                    txtApprovedBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetSubcontract"].ToString();
                    txtApprovedBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["ApprovedBudgetDJC"].ToString();

                    txtPendingBudgetLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLaborHours"].ToString();
                    txtPendingBudgetLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetLabor"].ToString();
                    txtPendingBudgetMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetMaterial"].ToString();
                    txtPendingBudgetRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetRental"].ToString();
                    txtPendingBudgetSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetSubcontract"].ToString();
                    txtPendingBudgetDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["PendingBudgetDJC"].ToString();

                    txtCommittedCostToDateLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLaborHours"].ToString();
                    txtCommittedCostToDateLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateLabor"].ToString();
                    txtCommittedCostToDateMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateMaterial"].ToString();
                    txtCommittedCostToDateRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateRental"].ToString();
                    txtCommittedCostToDateSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateSubcontract"].ToString();
                    txtCommittedCostToDateDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CommittedCostToDateDJC"].ToString();

                    txtOpenCommitLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLaborHours"].ToString();
                    txtOpenCommitLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitLabor"].ToString();
                    txtOpenCommitMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitMaterial"].ToString();
                    txtOpenCommitRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitRental"].ToString();
                    txtOpenCommitSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitSubcontract"].ToString();
                    txtOpenCommitDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommitDJC"].ToString();
                    txtOpenCommit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["OpenCommit"].ToString();



                    txtCostToCompleteLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLaborHours"].ToString();
                    txtCostToCompleteLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteLabor"].ToString();
                    txtCostToCompleteMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteMaterial"].ToString();
                    txtCostToCompleteRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteRental"].ToString();
                    txtCostToCompleteSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteSubcontract"].ToString();
                    txtCostToCompleteDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCompleteDJC"].ToString();

                    txtCostToCommitLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommitLaborHours"].ToString();
                    txtCostToCommitLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommitLabor"].ToString();
                    txtCostToCommitMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommitMaterial"].ToString();
                    txtCostToCommitRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommitRental"].ToString();
                    txtCostToCommitSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommitSubcontract"].ToString();
                    txtCostToCommitDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommitDJC"].ToString();

                    txtWIPCostToCompleteLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLaborHours"].ToString();
                    txtWIPCostToCompleteLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteLabor"].ToString();
                    txtWIPCostToCompleteMaterial.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteMaterial"].ToString();
                    txtWIPCostToCompleteRental.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteRental"].ToString();
                    txtWIPCostToCompleteSubcontract.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteSubcontract"].ToString();
                    txtWIPCostToCompleteDJC.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCompleteDJC"].ToString();

                    txtVarianceLaborHours.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLaborHours"].ToString();
                    txtVarianceLabor.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["VarianceLabor"].ToString();
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
                    txtCostToCommit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToCommit"].ToString();
                    txtWIPCostToComplete.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPCostToComplete"].ToString();

                    txtProjectedProfit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPProjectedProfit"].ToString();
                    txtBaselineProfit.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPBaselineProfit"].ToString();

                    txtLaborCompletePercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["LaborCompletePercentage"].ToString();
                    txtBilledCompletePercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["BilledCompletePercentage"].ToString();
                    txtCostToCostCompletePercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["CostToCostCompletePercentage"].ToString();

                    txtProjectedProfitPercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPProjectedProfitPercentage"].ToString();
                    txtBaselineProfitPercentage.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPBaselineProfitPercentage"].ToString();

                    txtProfitGainFade.Text = jobProgressSummaryDataSet.Tables[0].Rows[0]["WIPProfitGainFade"].ToString();
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
                    txtCurrentBudgetLabor.Text = null;
                    txtCurrentBudgetMaterial.Text = null;
                    txtCurrentBudgetRental.Text = null;
                    txtCurrentBudgetSubcontract.Text = null;
                    txtCurrentBudgetDJC.Text = null;

                    txtOriginalBudgetLaborHours.Text = null;
                    txtOriginalBudgetLabor.Text = null;
                    txtOriginalBudgetMaterial.Text = null;
                    txtOriginalBudgetRental.Text = null;
                    txtOriginalBudgetSubcontract.Text = null;
                    txtOriginalBudgetDJC.Text = null;

                    txtApprovedBudgetLaborHours.Text = null;
                    txtApprovedBudgetLabor.Text = null;
                    txtApprovedBudgetMaterial.Text = null;
                    txtApprovedBudgetRental.Text = null;
                    txtApprovedBudgetSubcontract.Text = null;
                    txtApprovedBudgetDJC.Text = null;

                    txtPendingBudgetLaborHours.Text = null;
                    txtPendingBudgetLabor.Text = null;
                    txtPendingBudgetMaterial.Text = null;
                    txtPendingBudgetRental.Text = null;
                    txtPendingBudgetSubcontract.Text = null;
                    txtPendingBudgetDJC.Text = null;

                    txtOpenCommitLaborHours.Text = null;
                    txtOpenCommitLabor.Text = null;
                    txtOpenCommitMaterial.Text = null;
                    txtOpenCommitRental.Text = null;
                    txtOpenCommitSubcontract.Text = null;
                    txtOpenCommitDJC.Text = null;
                    txtOpenCommit.Text = null;


                    txtCommittedCostToDateLabor.Text = null;
                    txtCommittedCostToDateMaterial.Text = null;
                    txtCommittedCostToDateRental.Text = null;
                    txtCommittedCostToDateSubcontract.Text = null;
                    txtCommittedCostToDateDJC.Text = null;
                    txtCostToCompleteLabor.Text = null;
                    txtCostToCompleteMaterial.Text = null;
                    txtCostToCompleteRental.Text = null;
                    txtCostToCompleteSubcontract.Text = null;
                    txtCostToCompleteDJC.Text = null;
                    txtCostToCommitLabor.Text = null;
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
                    txtVarianceLabor.Text = null;
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
                    picProfitGainFade.Visible = true;
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
