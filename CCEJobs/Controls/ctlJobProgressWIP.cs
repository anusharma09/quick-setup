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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;

namespace CCEJobs.Controls
{
    public partial class ctlJobProgressWIP : UserControl
    {
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private bool upgradeable = false;
        private string jobID;
        private DataSet jobProgressDataSet = new DataSet();
        private DataTable phaseTable = new DataTable();
        private bool isUpdated = false;
        private bool currentPeriod = true;
        private string perid = "";
        //
        double committedHours = 0;
        double totalBudgetHours = 0;
        double committedQuantity = 0;
        double totalBudgetQuantity = 0;
        double totalBudgetHoursPerf = 0;
        double estimatePerfFactor = 0;
        double revisedCAC = 0;
        double totalBudgetCost = 0;
        double revisePerformanceFactor = 0;
        double projectedTotalHours = 0;
        double projectedCAC = 0;
        //
        public ctlJobProgressWIP()
        {
            InitializeComponent();
            cboPeriod.Properties.DataSource = StaticTables.ArchivePeriod;
            cboPeriod.Properties.PopulateColumns();
            cboPeriod.Properties.DisplayMember = "Period";
            cboPeriod.Properties.ShowHeader = false;
            cboPeriod.Visible = false;
            radioDataType.SelectedIndex = 0;
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
                if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
                Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
                {
                    jobID = value;
                    GetJobProgress();
                    SetControlAccess();
                }
            }
        }
        // 
        public bool IsUpdated
        {
            get
            {
                return isUpdated;
            }
        }
        //
        public bool Updateable
        {
            set
            {
                upgradeable = value;
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
        public string Period
        {
            get
            {
                return perid;
            }
        }
        //
        private void GetJobProgress()
        {
            string id;
           
            if (String.IsNullOrEmpty(jobID))
                id = "0";
            else
                id = jobID;
            try
            {
               // jobProgressDataSet.Tables.Clear();
               // jobProgressDataSet.Relations.Clear();
            
                if (radioDataType.SelectedIndex == 1 && cboPeriod.Text.Trim().Length > 0)
                    currentPeriod = false;
                else
                    currentPeriod = true;
                if (currentPeriod)
                {
                    jobProgressDataSet = CostCode.GetJobProgressWithPhaseAdmin(id);
                    jobProgressDataSet.Relations[0].RelationName = "Budget Code";
                    jobProgressDataSet.Relations[1].RelationName = "Comment";
                    this.grdJobProgress.DataSource = jobProgressDataSet;
                    this.grdJobProgress.DataMember = "Main";
                }
                else
                {
                    jobProgressDataSet = CostCode.GetJobProgressHistoryWithPhaseAdmin(id, cboPeriod.Text);
                    this.grdJobProgress.DataSource = jobProgressDataSet.Tables[0].DefaultView;
                }
           
                grdJobProgressView.Columns["Type"].Group();
                grdJobProgressView.ExpandAllGroups();
                foreach (DevExpress.XtraGrid.Columns.GridColumn c in grdJobProgressView.Columns)
                    c.OptionsColumn.AllowEdit = false;
                grdJobProgressView.Columns["Qty Adjustment"].AppearanceCell.BackColor = grdJobProgressView.Columns["% Used Hrs"].AppearanceCell.BackColor;
                grdJobProgressView.Columns["Value Adjustment"].AppearanceCell.BackColor = grdJobProgressView.Columns["% Used Hrs"].AppearanceCell.BackColor;
                grdJobProgressView.Columns["Monthend Value Adjustment"].AppearanceCell.BackColor = grdJobProgressView.Columns["% Used Hrs"].AppearanceCell.BackColor;
                grdJobProgressView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded;
                
                grdJobProgressView.Columns["Original Contract Qty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Original Contract Qty"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Original Contract Qty"].AppearanceCell.BackColor = Color.LightGray;
                grdJobProgressView.Columns["Original Contract Qty"].Caption = "Original Contract Qty";
                grdJobProgressView.Columns["Original Contract Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Original Contract Hrs"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Original Contract Hrs"].AppearanceCell.BackColor = Color.LightGray;
                grdJobProgressView.Columns["Original Contract Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Original Contract Cost"].DisplayFormat.FormatString = "{0:c0}";
                grdJobProgressView.Columns["Original Contract Cost"].AppearanceCell.BackColor = Color.LightGray;
                grdJobProgressView.Columns["Approved Change Order Qty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Approved Change Order Qty"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Approved Change Order Qty"].AppearanceCell.BackColor = Color.LightGoldenrodYellow;
                grdJobProgressView.Columns["Approved Change Order Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Approved Change Order Hrs"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Approved Change Order Hrs"].AppearanceCell.BackColor = Color.LightGoldenrodYellow;
                grdJobProgressView.Columns["Approved Change Order Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Approved Change Order Cost"].DisplayFormat.FormatString = "{0:c0}";
                grdJobProgressView.Columns["Approved Change Order Cost"].AppearanceCell.BackColor = Color.LightGoldenrodYellow;
                grdJobProgressView.Columns["Pending W. Proceed Qty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Pending W. Proceed Qty"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Pending W. Proceed Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Pending W. Proceed Hrs"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Pending W. Proceed Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Pending W. Proceed Cost"].DisplayFormat.FormatString = "{0:c0}";
                grdJobProgressView.Columns["Approved Change Order Qty"].Caption = "Approved CO Qty";
                grdJobProgressView.Columns["Approved Change Order Hrs"].Caption = "Approved CO Hrs";
                grdJobProgressView.Columns["Approved Change Order Cost"].Caption = "Approved CO Cost";
                grdJobProgressView.Columns["Qty Adjustment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Qty Adjustment"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Qty Adjustment"].Caption = "Qty Replacement";
                grdJobProgressView.Columns["Total Budget Qty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Total Budget Qty"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Total Budget Qty"].AppearanceCell.BackColor = Color.LightBlue;
                grdJobProgressView.Columns["Total Budget Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Total Budget Hrs"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Total Budget Hrs"].AppearanceCell.BackColor = Color.LightBlue;
                grdJobProgressView.Columns["Total Budget Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Total Budget Cost"].DisplayFormat.FormatString = "{0:c0}";
                grdJobProgressView.Columns["Total Budget Cost"].AppearanceCell.BackColor = Color.LightBlue;
                grdJobProgressView.Columns["Committed Qty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Committed Qty"].Caption = "Actual Qty";
                grdJobProgressView.Columns["Committed Qty"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Committed Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Committed Hrs"].Caption = "Actual Hrs";
                grdJobProgressView.Columns["Committed Hrs"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Committed Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Committed Cost"].Caption = "Actual Cost";
                grdJobProgressView.Columns["Committed Cost"].DisplayFormat.FormatString = "{0:c0}";
                grdJobProgressView.Columns["Budget Labor Unit"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Budget Labor Unit"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["Actual Labor Unit"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Actual Labor Unit"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["Open Commitment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Open Commitment"].DisplayFormat.FormatString = "{0:c0}";
                grdJobProgressView.Columns["% Used Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["% Used Hrs"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["% Used Qty"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["% Used Qty"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["Estimated Perf. Factor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Estimated Perf. Factor"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["Estimated Perf. Factor"].Caption = "Labor Perf. Factor";
                grdJobProgressView.Columns["Differential Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Differential Hrs"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["Current Perf. Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Current Perf. Hrs"].Caption = "Composite Crew Rate";
                grdJobProgressView.Columns["Current Perf. Hrs"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Projected Total Hrs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Projected Total Hrs"].DisplayFormat.FormatString = "{0:n0}";
                grdJobProgressView.Columns["Projected CAC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Projected CAC"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Monthend CAC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Monthend CAC"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Monthend CAC"].AppearanceCell.BackColor = Color.LightGreen;
                //grdJobProgressView.Columns["Monthend CAC"].AppearanceCell.BackColor = Color.LightGray;
                grdJobProgressView.Columns["Monthend CAC"].Caption = "Month end CAC";
                grdJobProgressView.Columns["Projected Over/Under"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Projected Over/Under"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Projected Over/Under"].Caption = "Projected Variance";
                grdJobProgressView.Columns["Value Adjustment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Value Adjustment"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Value Adjustment"].Caption = "Value Replacement";
                grdJobProgressView.Columns["% Adjustment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["% Adjustment"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["% Adjustment"].Visible = false;
                grdJobProgressView.Columns["Revised CAC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Revised CAC"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Revised CAC"].Caption = "Revised CAC";
                grdJobProgressView.Columns["Revised Monthend CAC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Revised Monthend CAC"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Revised Monthend CAC"].AppearanceCell.BackColor = Color.LightGreen;
                //grdJobProgressView.Columns["Revised Monthend CAC"].AppearanceCell.BackColor = Color.LightGray;
                grdJobProgressView.Columns["Revised Over/Under"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Revised Over/Under"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Revised Over/Under"].Caption = "Revised Variance";
                grdJobProgressView.Columns["Revised Perf. Factor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Revised Perf. Factor"].DisplayFormat.FormatString = "{0:n2}";
                grdJobProgressView.Columns["Revised Perf. Factor"].Caption = "Cost Perf. Factor";
                grdJobProgressView.Columns["Monthend Value Adjustment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["Monthend Value Adjustment"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["Monthend Value Adjustment"].Caption = "Month end Value Adj.";
                
                grdJobProgressView.Columns["ActualCostPlusCommitment"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobProgressView.Columns["ActualCostPlusCommitment"].DisplayFormat.FormatString = "{0:c2}";
                grdJobProgressView.Columns["ActualCostPlusCommitment"].Caption = "Actual + Commit";
                grdJobProgressView.Columns["ActualCostPlusCommitment"].AppearanceCell.BackColor = Color.LightGreen;
                //grdJobProgressView.Columns["ActualCostPlusCommitment"].AppearanceCell.BackColor = Color.LightGray;



                //
                // WIP Adjustment
                //
                grdJobProgressView.Columns["Original Contract Qty"].Visible = false;
                grdJobProgressView.Columns["Original Contract Hrs"].Visible = false;
                grdJobProgressView.Columns["Original Contract Cost"].Visible = false;
                grdJobProgressView.Columns["Approved Change Order Qty"].Visible = false;
                grdJobProgressView.Columns["Approved Change Order Hrs"].Visible = false;
                grdJobProgressView.Columns["Approved Change Order Cost"].Visible = false;
                grdJobProgressView.Columns["Pending W. Proceed Qty"].Visible = false;
                grdJobProgressView.Columns["Pending W. Proceed Hrs"].Visible = false;
                grdJobProgressView.Columns["Pending W. Proceed Cost"].Visible = false;            
                grdJobProgressView.Columns["Qty Adjustment"].Visible = false;
                grdJobProgressView.Columns["Total Budget Qty"].Visible = false;  
                grdJobProgressView.Columns["Committed Qty"].Visible = false;
                grdJobProgressView.Columns["Budget Labor Unit"].Visible = false;
                grdJobProgressView.Columns["Actual Labor Unit"].Visible = false;
                grdJobProgressView.Columns["% Used Hrs"].Visible = false;
                grdJobProgressView.Columns["% Used Qty"].Visible = false;
                grdJobProgressView.Columns["Estimated Perf. Factor"].Visible = false;
                grdJobProgressView.Columns["Differential Hrs"].Visible = false;
                grdJobProgressView.Columns["Current Perf. Hrs"].Visible = false;
                grdJobProgressView.Columns["Projected Total Hrs"].Visible = false;
                grdJobProgressView.Columns["Projected CAC"].Visible = false;
                grdJobProgressView.Columns["Projected Over/Under"].Visible = false;
                grdJobProgressView.Columns["Value Adjustment"].Visible = false;
                grdJobProgressView.Columns["% Adjustment"].Visible = false;
                grdJobProgressView.Columns["Revised CAC"].Visible = false;
                grdJobProgressView.Columns["Revised Monthend CAC"].Caption = "Final";
                grdJobProgressView.Columns["Revised Over/Under"].Visible = false;
                grdJobProgressView.Columns["Revised Perf. Factor"].Visible = false;
                grdJobProgressView.Columns["Monthend Value Adjustment"].Visible = false;
                grdJobProgressView.Columns["Monthend CAC"].Visible = false;
                grdJobProgressView.Columns["ActualCostPlusCommitment"].Visible = false;
                grdJobProgressView.Columns["Estimated Crew Rate"].Visible = false;
                //
                // Emd of WIP Adjustment
                //
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Original Contract Hrs", grdJobProgressView.Columns["Original Contract Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Original Contract Cost", grdJobProgressView.Columns["Original Contract Cost"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Approved Change Order Hrs", grdJobProgressView.Columns["Approved Change Order Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Approved Change Order Cost", grdJobProgressView.Columns["Approved Change Order Cost"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Pending W. Proceed Hrs", grdJobProgressView.Columns["Pending W. Proceed Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Pending W. Proceed Cost", grdJobProgressView.Columns["Pending W. Proceed Cost"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Budget Hrs", grdJobProgressView.Columns["Total Budget Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Budget Cost", grdJobProgressView.Columns["Total Budget Cost"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Committed Hrs", grdJobProgressView.Columns["Committed Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Committed Cost", grdJobProgressView.Columns["Committed Cost"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Open Commitment", grdJobProgressView.Columns["Open Commitment"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "% Used Hrs", grdJobProgressView.Columns["% Used Hrs"], "{0:n0}%");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "% Used Qty", grdJobProgressView.Columns["% Used Qty"], "{0:n0}%");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "Estimated Perf. Factor", grdJobProgressView.Columns["Estimated Perf. Factor"], "{0:n2}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "Revised Perf. Factor", grdJobProgressView.Columns["Revised Perf. Factor"], "{0:n2}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Custom, "Current Perf. Hrs", grdJobProgressView.Columns["Current Perf. Hrs"], "{0:c2}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Differential Hrs", grdJobProgressView.Columns["Differential Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Projected Total Hrs", grdJobProgressView.Columns["Projected Total Hrs"], "{0:n0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Projected CAC", grdJobProgressView.Columns["Projected CAC"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Monthend CAC", grdJobProgressView.Columns["Monthend CAC"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Projected Over/Under", grdJobProgressView.Columns["Projected Over/Under"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Value Adjustment", grdJobProgressView.Columns["Value Adjustment"], "{0:c2}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Revised CAC", grdJobProgressView.Columns["Revised CAC"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Revised Monthend CAC", grdJobProgressView.Columns["Revised Monthend CAC"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Revised Over/Under", grdJobProgressView.Columns["Revised Over/Under"], "{0:c0}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Monthend Value Adjustment", grdJobProgressView.Columns["Monthend Value Adjustment"], "{0:c2}");
                grdJobProgressView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "ActualCostPlusCommitment", grdJobProgressView.Columns["ActualCostPlusCommitment"], "{0:c2}");
                grdJobProgressView.Columns["Original Contract Hrs"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Original Contract Hrs"].SummaryItem.DisplayFormat = "{0:n0}";
                grdJobProgressView.Columns["Original Contract Cost"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Original Contract Cost"].SummaryItem.DisplayFormat = "{0:c0}";
                grdJobProgressView.Columns["Approved Change Order Hrs"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Approved Change Order Hrs"].SummaryItem.DisplayFormat = "{0:n0}";
                grdJobProgressView.Columns["Approved Change Order Cost"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Approved Change Order Cost"].SummaryItem.DisplayFormat = "{0:c0}";
                grdJobProgressView.Columns["Pending W. Proceed Hrs"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Pending W. Proceed Hrs"].SummaryItem.DisplayFormat = "{0:n0}";
                grdJobProgressView.Columns["Pending W. Proceed Cost"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Pending W. Proceed Cost"].SummaryItem.DisplayFormat = "{0:c0}";
                grdJobProgressView.Columns["Total Budget Hrs"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Total Budget Hrs"].SummaryItem.DisplayFormat = "{0:n0}";
                grdJobProgressView.Columns["Total Budget Cost"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Total Budget Cost"].SummaryItem.DisplayFormat = "{0:c0}";
                grdJobProgressView.Columns["Committed Hrs"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Committed Hrs"].SummaryItem.DisplayFormat = "{0:n0}";
                grdJobProgressView.Columns["Committed Cost"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Committed Cost"].SummaryItem.DisplayFormat = "{0:c0}";
                grdJobProgressView.Columns["Open Commitment"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Open Commitment"].SummaryItem.DisplayFormat = "{0:c0}";
                grdJobProgressView.Columns["Projected Total Hrs"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Projected Total Hrs"].SummaryItem.DisplayFormat = "{0:n0}";
                grdJobProgressView.Columns["Revised Monthend CAC"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobProgressView.Columns["Revised Monthend CAC"].SummaryItem.DisplayFormat = "{0:c0}";


                grdJobProgressView.Columns[0].Visible = false;
                grdJobProgressView.Columns["Phase"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                grdJobProgressView.Columns["Code"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                grdJobProgressView.Columns["Description"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                grdJobProgressView.GroupSummary[13].Tag = "Used Hours";
                grdJobProgressView.GroupSummary[14].Tag = "Used Quantity";
                grdJobProgressView.BestFitColumns();
                grdJobProgressView.Columns["Description"].Width = 150;
                grdJobProgressView.Columns["Phase"].Width = 75;
                // Tool Tips
               grdJobProgressView.Columns["Phase"].ToolTip = "Cost Code Phase Number";
                grdJobProgressView.Columns["Code"].ToolTip = "Cost Code Number";
                grdJobProgressView.Columns["Description"].ToolTip = "Cost Code Description";
                grdJobProgressView.Columns["Original Contract Qty"].ToolTip = "Original Contract Quantity";
                grdJobProgressView.Columns["Original Contract Hrs"].ToolTip = "Original Contract Hours";
                grdJobProgressView.Columns["Original Contract Cost"].ToolTip = "Original Contract Cost";
                grdJobProgressView.Columns["Approved Change Order Qty"].ToolTip = "Approved Change Order Quantity";
                grdJobProgressView.Columns["Approved Change Order Hrs"].ToolTip = "Approved Change Order Hours";
                grdJobProgressView.Columns["Approved Change Order Cost"].ToolTip = "Approved Change Order Cost";
                grdJobProgressView.Columns["Pending W. Proceed Qty"].ToolTip = "Pending with Proceed Change Order Quantity";
                grdJobProgressView.Columns["Pending W. Proceed Hrs"].ToolTip = "Pending with Proceed Change Order Hors";
                grdJobProgressView.Columns["Pending W. Proceed Cost"].ToolTip = "Pending with Proceed Change Order Cost";
                grdJobProgressView.Columns["Qty Adjustment"].ToolTip = "Quantity Replacement:\n" +
                                                                        " This value is entered by the user.\n\n" +
                                                                        " ** If Quantity Replacement <> 0, it will replace Total Budget Quantity.";
                grdJobProgressView.Columns["Total Budget Qty"].ToolTip = "Total Budget Quantity:\n" +
                                                                        " = Original Budget Quantity + \n" +
                                                                        "   Approved Change Order Quantity + \n" +
                                                                        "   Pending with Proceed Change Order Quantity\n\n" +
                                                                        " ** If Quantity Replacement <> 0, it will replace Total Budget Quantity";
                grdJobProgressView.Columns["Total Budget Hrs"].ToolTip = "Total Budget Hours:\n" +
                                                                        " = Original Budget Hours + \n" +
                                                                        "   Approved Change Order Hours + \n" +
                                                                        "   Pending with Proceed Change Order Hours";
                grdJobProgressView.Columns["Total Budget Cost"].ToolTip = "Total Budget Cost:\n" +
                                                                        " = Original Budget Cost + \n" +
                                                                        "   Approved Change Order Cost + \n" +
                                                                        "   Pending with Proceed Change Order Cost";
                grdJobProgressView.Columns["Committed Qty"].ToolTip = "Actual Quantity:\n" +
                                                                       " A roll-up for the all the used quantity up to date\n\n" +
                                                                       " ** Quantities are entered by the user in the Weekly Quantities Tab";
                grdJobProgressView.Columns["Committed Hrs"].ToolTip = "Actual Hours:\n" +
                                                                       " A roll-up for the all the used hours up to date\n\n" +
                                                                       " ** Hours are pulled form Starbuilder system";
                grdJobProgressView.Columns["Committed Cost"].ToolTip = "Actual Cost:\n" +
                                                       " A roll-up for the cost up to date\n\n" +
                                                       " ** Hours are pulled form Starbuilder system";
                grdJobProgressView.Columns["Budget Labor Unit"].ToolTip = "Budget Labor Unit:\n" +
                                                        " = Total Budget Hrs / Total Budget Quantity";
                grdJobProgressView.Columns["Actual Labor Unit"].ToolTip = "Actual Labor Unit:\n" +
                                                                          "Actual Hrs / Actual Quantity";
                grdJobProgressView.Columns["Projected Over/Under"].ToolTip = "Projected Variance:\n" +
                                                                                 " =  Projected Cost at Completion - Total Budget Cost";
                grdJobProgressView.Columns["Open Commitment"].ToolTip = "Open Commitment:\n" +
                                                      " The commitment up to date\n\n" +
                                                      " ** Commitment is pulled form Starbuilder system";
                grdJobProgressView.Columns["% Used Hrs"].ToolTip = "% Used Hours:\n" +
                                                                    " = Actual Hours / Total Budget Hours";
                grdJobProgressView.Columns["% Used Qty"].ToolTip = "% Used Quantity:\n" +
                                                    " = Actual Quantity / Total Budget Quantity";
                grdJobProgressView.Columns["Estimated Perf. Factor"].ToolTip = "Labor Performance Factor:\n" +
                                                                               " If % Used Quantity = 0 then 1.00\n" +
                                                                               " Else = % Used Hours / % Used Quantity";
                grdJobProgressView.Columns["Differential Hrs"].ToolTip = "Differential Hours:\n" +
                                                                         " = (Labor Performance Factor - 1) * Total Budget Hours";
                grdJobProgressView.Columns["Current Perf. Hrs"].ToolTip = "Composite Crew Rate:\n" +
                                                                            " = Actual Cost / Actual Hours";
                grdJobProgressView.Columns["Projected Total Hrs"].ToolTip = "Projected Total Hours:\n" +
                                                                            " = (Total Budget Hours + Differential Hours)\n" +
                                                                            " OR = Actual Hours \n " +
                                                                            " Whatever is higher ";
                grdJobProgressView.Columns["Projected CAC"].ToolTip = "Projected Cost at Completion:\n" +
                                                                      " ** For type'L': If No (Actual Cost or Actual Hours) then Projected CAC = Total Budget Cost \n" + 
                                                                      "                 Else Projected Total Hours * ( Actual Cost / Actual Hours)\n" +
                                                                      " ** For other: = (Actual Cost + Open Commitment\n" +
                                                                      "               OR = Total Budget Cost\n" +
                                                                      "    Whatever is higher";
                grdJobProgressView.Columns["Projected Over/Under"].ToolTip = "Projected Variance:\n" +
                                                                            " =  Projected Cost at Completion - Total Budget Cost";
                grdJobProgressView.Columns["Value Adjustment"].ToolTip = "Value Replacement:\n" +
                                                                        " This value is entered by the user.\n\n" +                                        
                                                                        " ** If Value Replacement > 0 and > (Actual Cost + Open Commitment) it will replace Revised Cost at Completion.";
                grdJobProgressView.Columns["% Adjustment"].ToolTip = "% Adjustment:\n" +
                                                                   " = Value Replacement / Total Budget Cost";
                grdJobProgressView.Columns["Revised CAC"].ToolTip = "Revised Cost at Completion:\n" +
                                                                    " = Projected Cost at Complition\n\n" +
                                                                    " OR ( = Actual Cost + Open Commitment\n" +
                                                                    " OR = Value Replacment)\n" +
                                                                    " Whichver is higher";
                grdJobProgressView.Columns["Revised Over/Under"].ToolTip = "Revised Variance:\n" +
                                                                        " If Value Replacement = 0, Revise Variance = Projected CAC\n" +
                                                                        " Else Revise Variance = Value Replacement - Total Budget Cost";
                grdJobProgressView.Columns["Revised Perf. Factor"].ToolTip = "Cost Performance Factor:\n " +
                                                                            " IF Total Budget Cost = 0 Then 1 \n" +
                                                                            " Else Revised Cost at Completion / Total Budget Cost";
                grdJobProgressView.Columns["ActualCostPlusCommitment"].ToolTip = "Actual + Commit:\n" +
                                                                                " = Actual Cost + Open Commitment";
                grdJobProgressView.Columns["Monthend CAC"].ToolTip = "Month End Cost at Completion:\n" +
                                                                    " =  Actual Cost + Open Commitment +  Value Replacement\n" +
                                                                    " OR = Total Budget Cost\n" +
                                                                    " OR = Actual Cost + Open Commitment\n " +
                                                                    " Whatever is higher";
                grdJobProgressView.Columns["UpdateMonthendValueAdjustment"].ToolTip = "Update Month End Value Replacement:\n" +
                                                                                    " Checked and unckecked by the user.\n\n" +
                                                                                    " ** When checked, Month End Value Adjustment will be replaced with Actual Cost + Open Commitment\n" +
                                                                                    " ** When Unchecked, Month End Value Adjustment will be replaced with 0\n" +
                                                                                    " ** The user still can type a value in Month End Value Adjustment.\n";
                grdJobProgressView.Columns["Monthend Value Adjustment"].ToolTip = "Month End Value Adjustment:\n" +
                                                                                 " This value is entered by the user.\n" +
                                                                                 " ** When using the Check Box:\n" +
                                                                                 " If user checked the box, Month End Value Adjustment will be replaced with Actual Cost + Open Commitment\n" +
                                                                                 " If user unchecked the box, Month End Value Adjustment will be replaced with 0";  
                grdJobProgressView.Columns["Revised Monthend CAC"].ToolTip = "Revised Month End Cost at Completion:\n" +
                                                                            " = Month End Value Adjustment\n" +
                                                                            " OR = Actual Cost + Open Commitment\n" +
                                                                            " Whatever is higher";
                  
          
            }
            catch (Exception ex)
            {
               // ex = null;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void btnUpdateJobProgress_Click(object sender, EventArgs e)
        {
            SaveChanges(true);
        }
        //
        public void SaveChanges(bool save)
        {
            if (save)
            {
                try
                {
                    CostCode costCode;
                    foreach (DataRow r in jobProgressDataSet.Tables[0].Rows)
                    {
                        costCode = new CostCode(r["JobCostCodePhaseID"].ToString(),
                                                "", "", "", "", r["Description"].ToString(),
                                                "", r["Value Adjustment"].ToString(), r["Qty Adjustment"].ToString(), r["Monthend Value Adjustment"].ToString());

                        costCode.Save();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
            btnUpdateJobProgress.Enabled = false;
            btnUpdateJobProgress.Visible = false;
            isUpdated = false;
        }
        //
        private void grdJobProgressView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnUpdateJobProgress.Enabled = true;
            btnUpdateJobProgress.Visible = true;
            isUpdated = true;
            if (e.Column.Name == "colUpdateMonthendValueAdjustment")
            {
                DataRow r = grdJobProgressView.GetDataRow(e.RowHandle);
                if (e.Value.ToString() == "True")
                    r["Monthend Value Adjustment"] = r["ActualCostPlusCommitment"];
                else
                    r["Monthend Value Adjustment"] = "0";
            }
        }
        //
        private void grdJobProgressView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            string summaryID = "";
            Double i = 0;
            Double j = 0;

            GridSummaryItem item = (GridSummaryItem)e.Item;
          
            summaryID = item.FieldName;
           
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                switch (summaryID)
                {
                    case "% Used Hrs":
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Committed Hrs").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Committed Hrs"));
                        committedHours = committedHours + i;
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Hrs").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Hrs"));  
                        totalBudgetHours = totalBudgetHours + i;
                        break;
                    case "% Used Qty":
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Committed Qty").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Committed Qty"));
                        committedQuantity = committedQuantity + i;
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Qty").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Qty"));
                        totalBudgetQuantity = totalBudgetQuantity + i;
                        break;
                    case "Estimated Perf. Factor":
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Hrs").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Hrs"));

                        totalBudgetHoursPerf = totalBudgetHoursPerf + i;
                        j = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Estimated Perf. Factor").ToString()))
                            j = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Estimated Perf. Factor"));

                        estimatePerfFactor = estimatePerfFactor + i * j;
                        break;
                    case "Revised Perf. Factor":
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Revised CAC").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Revised CAC"));
                        revisedCAC = revisedCAC + i;
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Cost").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Total Budget Cost"));
                        totalBudgetCost = totalBudgetCost + i;
                        break;
                    case "Current Perf. Hrs":
                        i = 0;
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Projected Total Hrs").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Projected Total Hrs"));
                        projectedTotalHours = projectedTotalHours + i;
                        i = 0;                       
                        if (!String.IsNullOrEmpty(grdJobProgressView.GetRowCellValue(e.RowHandle, "Projected CAC").ToString()))
                            i = Convert.ToDouble(grdJobProgressView.GetRowCellValue(e.RowHandle, "Projected CAC"));
                        projectedCAC = projectedCAC + i;
                        break;
                }
            }
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                switch (summaryID)
                {
                    case "% Used Hrs":
                        if (totalBudgetHours > 0)
                            e.TotalValue = Convert.ToInt64( (committedHours / totalBudgetHours) * 100);
                        else
                            e.TotalValue = 0;
                        committedHours = 0;
                        totalBudgetHours = 0;
                        break;
                    case "% Used Qty":
                        if (totalBudgetQuantity > 0)
                            e.TotalValue = Convert.ToInt64((committedQuantity / totalBudgetQuantity) * 100);
                        else
                            e.TotalValue = 0;
                        committedQuantity = 0;
                        totalBudgetQuantity = 0;
                        break;
                    case "Estimated Perf. Factor":
                        if (totalBudgetHoursPerf > 0)
                            e.TotalValue = Convert.ToDouble((estimatePerfFactor / totalBudgetHoursPerf));
                        else
                            e.TotalValue = 0;
                        totalBudgetHoursPerf = 0;
                        estimatePerfFactor = 0;
                        break;

                    case "Revised Perf. Factor":
                        if (totalBudgetCost > 0)
                            e.TotalValue = Convert.ToDouble((revisedCAC / totalBudgetCost));
                        else
                            e.TotalValue = 0;
                        revisedCAC = 0;
                        totalBudgetCost = 0;
                        break;

                    case "Current Perf. Hrs":
                        if (projectedTotalHours > 0)
                            e.TotalValue = Convert.ToDouble((projectedCAC / projectedTotalHours));
                        else
                            e.TotalValue = 0;
                        projectedCAC = 0;
                        projectedTotalHours = 0;
                        break;
                }
            }
        }
        //
        private void grdJobProgressView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnUpdateJobProgress.Enabled = true;
            btnUpdateJobProgress.Visible = true;
            isUpdated = true;
        }
        //
        private void radioDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioDataType.SelectedIndex == 0)
            {
                lblPeriod.Visible = false;
                cboPeriod.Visible = false;
                if (cboPeriod.Text.Trim().Length > 0)
                {
                    GetJobProgress();
                    cboPeriod.EditValue = String.Empty;
                }
            }
            else
            {
                lblPeriod.Visible = true;
                cboPeriod.Visible = true;
            }
           
        }
        //
        private void cboPeriod_EditValueChanged(object sender, EventArgs e)
        {
            perid = cboPeriod.Text;
            GetJobProgress();
        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly
                )
                grdJobProgressView.OptionsBehavior.Editable = false;
            else
            {
                grdJobProgressView.OptionsBehavior.Editable = true;

                if (currentPeriod)
                {
                    grdJobProgressView.Columns["Value Adjustment"].OptionsColumn.AllowEdit = true;
                    grdJobProgressView.Columns["Qty Adjustment"].OptionsColumn.AllowEdit = true;
                    grdJobProgressView.Columns["Monthend Value Adjustment"].OptionsColumn.AllowEdit = true;
                    grdJobProgressView.Columns["Qty Adjustment"].AppearanceCell.BackColor = Color.LightSalmon;
                    grdJobProgressView.Columns["Value Adjustment"].AppearanceCell.BackColor = Color.LightSalmon;
                    grdJobProgressView.Columns["Monthend Value Adjustment"].AppearanceCell.BackColor = Color.LightSalmon;
                    grdJobProgressView.Columns["UpdateMonthendValueAdjustment"].Caption = "";
                    grdJobProgressView.Columns["UpdateMonthendValueAdjustment"].OptionsColumn.AllowEdit = true;
                    grdJobProgressView.Columns["UpdateMonthendValueAdjustment"].Caption = "";
                    // WIP - It Should be True
                    grdJobProgressView.Columns["UpdateMonthendValueAdjustment"].Visible = false;
                }
                else
                {
                    
                    grdJobProgressView.Columns["UpdateMonthendValueAdjustment"].Visible = false;
                }
            }
        }

        private void grdJobProgressView_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            
            GridView grdJobProgressView = sender as GridView;
            GridView view = grdJobProgressView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();
            if (e.RelationIndex == 0)
            {
                view.OptionsBehavior.Editable = false;
                view.Columns["JobCostCodePhaseID"].Visible = false;
                view.Columns["QuantityToDate"].Caption = "Actual Qty";
                view.Columns["QuantityToDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["QuantityToDate"].DisplayFormat.FormatString = "{0:n0}";
                view.Columns["HoursToDate"].Caption = "Actual Hrs";
                view.Columns["HoursToDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["HoursToDate"].DisplayFormat.FormatString = "{0:n0}";
                view.Columns["LaborPerformanceFactor"].Caption = "Labor Perf. Factor";
                view.Columns["LaborPerformanceFactor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["LaborPerformanceFactor"].DisplayFormat.FormatString = "{0:n2}";
                view.Columns["Earned"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                view.Columns["Earned"].DisplayFormat.FormatString = "{0:n0}";
            }
            else
            {
                view.Columns["JobCostCodePhaseCommentID"].Visible = false;
                view.Columns["JobCostCodePhaseID"].Visible = false;
                view.Columns["LastUpdateDate"].OptionsColumn.AllowEdit = false;
                view.Columns["UserID"].OptionsColumn.AllowEdit = false;
                view.Columns["LastUpdateDate"].Caption = "Last Update Date";
                view.Columns["UserID"].Caption = "Updated by";
                view.Columns["Comment"].Width = 500;
                view.Columns["Comment"].ColumnEdit = repComment;
                view.Columns["LastUpdateDate"].Width = 100;
                view.Columns["UserID"].Width = 100;

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
              Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                {
                    view.OptionsBehavior.Editable = true;
                }
                else
                {
                    view.OptionsBehavior.Editable = true;
                    view.ValidateRow += new ValidateRowEventHandler(view_ValidateRow);
                    view.InvalidRowException += new InvalidRowExceptionEventHandler(view_InvalidRowException);
                    view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
            }   
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
           
        }
        private void view_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void view_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DialogResult result;

           

            DataRowView r = (DataRowView)e.Row;

            result = MessageBox.Show("Save Comment?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Cancel:
                    e.Valid = false;
                    break;
                case DialogResult.No:
                    e.Valid = true;
                    r.CancelEdit();
                    break;
                case DialogResult.Yes:  
                    if (r["Comment"] == DBNull.Value)
                    {
                        message = message + "Change Order Status is Requred ..\n";
                        valid = false;
                    }

                    if (valid)
                    {
                        UpdatePhaseComment(r);
                        e.Valid = true;
                        grdJobProgressComment.RefreshData();
                        
                    }
                    else
                    {
                        MessageBox.Show(message, CCEApplication.ApplicationName);
                        e.Valid = false;
                    }
                    break;


            }



        }
        void UpdatePhaseComment(DataRowView r)
        {
            DataRow row = grdJobProgressView.GetDataRow(grdJobProgressView.GetSelectedRows()[0]);

            r["LastUpdateDate"] = DateTime.Today.Date;
            r["UserID"] = Security.Security.LoginID;

            PhaseComment comment = new PhaseComment(r["JobCostCodePhaseCommentID"].ToString(),
                                    row["JobCostCodePhaseID"].ToString(),
                                    r["Comment"].ToString(),
                                    r["LastUpdateDate"].ToString(),
                                    r["UserID"].ToString());
            comment.Save();
            r["JobCostCodePhaseCommentID"] = comment.JobCostCodePhaseCommentID;
            r["JobCostCodePhaseID"] = row["JobCostCodePhaseID"].ToString();
            
        }
    }
}
