using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CCEJobs.Utilities;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Localization;


using DevExpress.Utils.Menu;

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CCEJobs.Controls
{
    public enum JobListView
    {
        JobStatus,
        Office,
        Department,
        Customer,
        ProjectManager,
        Estimator,
        Superintendent,
        Foreman,
        List
    }
    //
    public partial class ctlJobList : UserControl
    {
        private BindingSource jobSourceBinding = new BindingSource();
        private JobListView jobListView = JobListView.List;
        private DataTable jobTable;
        string queryCondition;
        private bool isAdHoc = false;
        private string reportFilter = "";
        private string reportSort = "";
        frmJob job;
        private bool initialScreen = true;
        public ctlJobList()
        {
            InitializeComponent();

            GetJobList(" Where b.JobID = 0 ");
            initialScreen = false;
        }
        //
        private void grdJobList_DoubleClick(object sender, EventArgs e)
        {
            if (grdJobListView.RowCount == 0)
                return;
            //DevExpress.Utils.WaitDialogForm wait = new DevExpress.Utils.WaitDialogForm("", "... " + "Loading Job" + " ...");
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");


            // WaitProgress wait = new WaitProgress();
            //  wait.ShowDialog();

            DataRow dataRow;
            dataRow = this.grdJobListView.GetDataRow(grdJobListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (job != null)
                {
                    job.Close();
                    job.Dispose();
                }
                job = new frmJob(dataRow[0].ToString(), jobSourceBinding, Security.Security.JobCaller.JCCJob);
                try
                {
                    job.Show();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }

            }
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();

            //wait.Dispose();
        }
        //
        private void ctlJobList_Load(object sender, EventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadWriteCreate
                && Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB))
            {
                panelControl1.Visible = false;
                btnAddNewJob.Visible = false;
            }
            else
            {
                panelControl1.Visible = true;
                btnAddNewJob.Visible = true;
            }
            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.RedWriteCreateSB)
                chkStarbuilderList.Visible = true;
            cboContractType.Properties.DataSource = StaticTables.ContractType;
            cboContractType.Properties.DisplayMember = "Description";
            cboContractType.Properties.ValueMember = "ContractTypeID";
            cboContractType.Properties.PopulateColumns();
            cboContractType.Properties.ShowHeader = false;

            cboCustomerName.Properties.DataSource = StaticTables.Customers;
            cboCustomerName.Properties.DisplayMember = "Name";
            cboCustomerName.Properties.ValueMember = "CustomerID";
            cboCustomerName.Properties.PopulateColumns();
            cboCustomerName.Properties.ShowHeader = false;

            cboOwnerClass.Properties.DataSource = StaticTables.OwnerClass;
            cboOwnerClass.Properties.DisplayMember = "Description";
            cboOwnerClass.Properties.ValueMember = "OwnerClassID";
            cboOwnerClass.Properties.PopulateColumns();
            cboOwnerClass.Properties.ShowHeader = false;

            cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
            cboProjectManager.Properties.DisplayMember = "Description";
            cboProjectManager.Properties.ValueMember = "ProjectManagerID";
            cboProjectManager.Properties.PopulateColumns();
            cboProjectManager.Properties.ShowHeader = false;

            cboEstimator.Properties.DataSource = StaticTables.Estimator;
            cboEstimator.Properties.DisplayMember = "Description";
            cboEstimator.Properties.ValueMember = "EstimatorID";
            cboEstimator.Properties.PopulateColumns();
            cboEstimator.Properties.ShowHeader = false;

            cboForeman.Properties.DataSource = StaticTables.Foreman;
            cboForeman.Properties.DisplayMember = "Description";
            cboForeman.Properties.ValueMember = "ForemanID";
            cboForeman.Properties.PopulateColumns();
            cboForeman.Properties.ShowHeader = false;

            cboSuperintendent.Properties.DataSource = StaticTables.Superintendent;
            cboSuperintendent.Properties.DisplayMember = "Description";
            cboSuperintendent.Properties.ValueMember = "SuperintendentID";
            cboSuperintendent.Properties.PopulateColumns();
            cboSuperintendent.Properties.ShowHeader = false;

            cboDepartment.Properties.DataSource = StaticTables.Department;
            cboDepartment.Properties.DisplayMember = "DepartmentName";
            cboDepartment.Properties.ValueMember = "DepartmentID";
            cboDepartment.Properties.PopulateColumns();
            cboDepartment.Properties.ShowHeader = false;

            cboOffice.Properties.DataSource = StaticTables.Office;
            cboOffice.Properties.PopulateColumns();
            cboOffice.Properties.DisplayMember = "OfficeName";
            cboOffice.Properties.ValueMember = "OfficeID";
            cboOffice.Properties.ShowHeader = false;

            cboJobStatus.Properties.DataSource = StaticTables.JobStatus;
            cboJobStatus.Properties.DisplayMember = "JobStatus";
            cboJobStatus.Properties.ValueMember = "JobStatusID";
            cboJobStatus.Properties.PopulateColumns();
            cboJobStatus.Properties.ShowHeader = false;
            // Reports
            cboReport.Properties.Items.Add("Ad Hoc");
            cboReport.Properties.Items.Add("Bid Schedule");
            cboReport.Properties.Items.Add("Weekly Budget");
            cboReport.Properties.Items.Add("Weekly Estimate Successful");
            cboReport.Properties.Items.Add("Weekly Million Dollar");
            cboReport.Properties.Items.Add("Weekly Estimate No No Bid");
            cboReport.Properties.Items.Add("Weekly Estimate Open Pending");
            cboReport.Properties.Items.Add("Weekly New Job");
            cboReport.Properties.Items.Add("OCIP Classified Jobs");
            cboReport.Properties.Items.Add("Pre Job Planning");
            cboReport.Properties.Items.Add("Company Estimate Review");
            cboReport.Properties.Items.Add("Company Estimate History");
            cboReport.Properties.Items.Add("POs With No Invoice");
            cboReport.Properties.Items.Add("POs With Invoices - Different Job Number");
            cboReport.Properties.Items.Add("Customer Invoices Aging");
            cboReport.Properties.Items.Add("Job Labor Analysis");
            cboReport.Properties.Items.Add("Job by Cost Codes");
            cboReport.Properties.Items.Add("Job Prequal");
            cboReport.Properties.Items.Add("Jobs with Labor Activities by Week");
            cboReport.Properties.Items.Add("Month End");
            cboReport.Properties.Items.Add("All Insurance Requirements");
            /* if (Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator ||
                 Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator)
                     cboReport.Properties.Items.Add("Job Log List");*/
            cboContractType.Properties.Columns[0].Visible = false;
            cboOwnerClass.Properties.Columns[0].Visible = false;
            cboProjectManager.Properties.Columns[0].Visible = false;
            cboEstimator.Properties.Columns[0].Visible = false;
            cboSuperintendent.Properties.Columns[0].Visible = false;
            cboForeman.Properties.Columns[0].Visible = false;
            cboDepartment.Properties.Columns[0].Visible = false;
            cboOffice.Properties.Columns[0].Visible = false;
            cboJobStatus.Properties.Columns[0].Visible = false;
        }
        private void GetJobList(string where)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            try
            {

                jobTable = Job.GetJobList(where).Tables[0];
                jobSourceBinding.DataSource = jobTable.DefaultView;
                grdJobList.DataSource = jobSourceBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

            finally
            {
                grdJobList.MainView.PopulateColumns();
                grdJobListView.Columns[0].Visible = false;
                UpdateListView(jobListView);
                RestoreCustomization();
                FormatGrid();
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (jobTable.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }
        }
        //
        private void FormatGrid()
        {

            if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
              Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWrite ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadWriteCreate ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.RedWriteCreateSB)
                {
                    grdJobListView.OptionsBehavior.Editable = true;
                    grdJobListView.Columns["AdjustmentPercent"].Caption = "Adj. Percent %";
                    grdJobListView.Columns["AdjustmentPercent"].OptionsColumn.AllowEdit = true;
                    grdJobListView.Columns["AdjustmentPercent"].ColumnEdit = repPercent;
                    grdJobListView.Columns["AdjustmentPercent"].AppearanceCell.BackColor = Color.LightSalmon;


                    grdJobListView.Columns["CurrentBudgetLabor"].Caption = "Budget Labor($)";
                    grdJobListView.Columns["CurrentBudgetLabor"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["CurrentBudgetLabor"].AppearanceCell.BackColor = Color.LightGreen;
                    grdJobListView.Columns["CurrentBudgetLabor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdJobListView.Columns["CurrentBudgetLabor"].DisplayFormat.FormatString = "{0:c2}";

                    grdJobListView.Columns["CommittedCostToDateLabor"].Caption = "Actual Labor ($)";
                    grdJobListView.Columns["CommittedCostToDateLabor"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["CommittedCostToDateLabor"].AppearanceCell.BackColor = Color.LightGreen;
                    grdJobListView.Columns["CommittedCostToDateLabor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdJobListView.Columns["CommittedCostToDateLabor"].DisplayFormat.FormatString = "{0:c2}";

                    grdJobListView.Columns["Cash Received Percent"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdJobListView.Columns["Cash Received Percent"].DisplayFormat.FormatString = "%{0:n2}";

                    grdJobListView.Columns["Opportunity #"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Contract Type"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Estimate No"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Job No"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Bid Date"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Job Start Date"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Est. Compl. Date"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["W/L Date"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Job Name"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Job Status"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Office"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Department"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Customer"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Project Manager"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Estimator"].OptionsColumn.AllowEdit = false;
                    grdJobListView.Columns["Superintendent"].OptionsColumn.AllowEdit = false;
                }
            }
            else
            {
                grdJobListView.Columns["AdjustmentPercent"].Visible = false;
                grdJobListView.Columns["CurrentBudgetLabor"].Visible = false;
                grdJobListView.Columns["CommittedCostToDateLabor"].Visible = false;
            }
            grdJobListView.BestFitColumns();
            grdJobListView.Columns["Estimate No"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdJobListView.Columns["Estimate No"].SummaryItem.DisplayFormat = "Count: {0:n0}";
            grdJobListView.Columns["RecordNo"].Visible = false;
            grdJobListView.Columns["ReadOnly"].Visible = false;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {   //
            // Process The List
            //   
            string query = " WHERE ";

            if (chkStarbuilderList.CheckState == CheckState.Checked)
            {
                query += " [dbo].[GetStarbuilderJob](b.JobNumber )= 0 AND ";
            }

            if (!String.IsNullOrEmpty(txtEstimateNumber.Text))
                query += " b.EstimateNumber like '" + txtEstimateNumber.Text.Trim().Replace("'", "''") + "%' AND ";
            if (txtScopeOfWork.Text.Trim().Length > 0)
                query += " ScopeOfWork like '%" + txtScopeOfWork.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtJobNumber.Text))
                query += " JobNumber like '" + txtJobNumber.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtJobName.Text))
                query += " JobName like '" + txtJobName.Text.Trim().Replace("'", "''") + "%' AND ";
            if (cboJobStatus.Text.Trim().Length > 0)
                query += " b.JobStatusID = " + cboJobStatus.EditValue.ToString() + " AND ";
            if (cboContractType.Text.Trim().Length > 0)
                query += " b.ContractTypeID = " + cboContractType.EditValue.ToString() + " AND ";
            if (cboOffice.Text.Trim().Length > 0)
                query += " b.OfficeID = " + cboOffice.EditValue.ToString() + " AND ";
            if (cboDepartment.Text.Trim().Length > 0)
                query += " b.DepartmentID = " + cboDepartment.EditValue.ToString() + " AND ";
            if (cboCustomerName.Text.Trim().Length > 0)
                query += " b.CustomerID = '" + cboCustomerName.EditValue.ToString() + "' AND ";
            if (cboOwnerClass.Text.Trim().Length > 0)
                query += " b.OwnerClassID = " + cboOwnerClass.EditValue.ToString() + " AND ";
            if (cboProjectManager.Text.Trim().Length > 0)
                query += " b.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " AND ";
            if (cboEstimator.Text.Trim().Length > 0)
                query += " b.EstimatorID = " + cboEstimator.EditValue.ToString() + " AND ";
            if (cboSuperintendent.Text.Trim().Length > 0)
                query += " b.SuperintendentID = " + cboForeman.EditValue.ToString() + " AND ";
            if (cboForeman.Text.Trim().Length > 0)
                query += " b.ForemanID = " + cboSuperintendent.EditValue.ToString() + " AND ";

            // Archive Status
            if (radioArchiveStatus.SelectedIndex == 0)
                query += " b.Archived =  0 " + " AND ";
            if (radioArchiveStatus.SelectedIndex == 1)
                query += " b.Archived =  1 " + " AND ";
            // Job Status
            if (radioJobStatus.SelectedIndex == 0)
                query += " (b.JobNumber is Null OR b.JobNumber = '') " + " AND ";
            if (radioJobStatus.SelectedIndex == 1)
                query += " (b.JobNumber > '')   " + " AND ";

            // WIP Status
            if (radioWIP.SelectedIndex == 0)
                query += " b.WIPRequired =  1 " + " AND ";
            if (radioWIP.SelectedIndex == 1)
                query += " b.WIPRequired =  0 " + " AND ";




            if (radioJobCompletedStatus.SelectedIndex == 0)
            {
                query += " bb.JobCompleted =  1 " + " AND ";
            }
            if (radioJobCompletedStatus.SelectedIndex == 1)
            {
                query += " bb.JobCompleted =  0 " + " AND ";
            }


            // Bid Date
            if (txtBidDateFrom.Text.Length > 0 && txtBidDateTo.Text.Length > 0)
                query += " (b.BidDate BETWEEN '" + txtBidDateFrom.Text + "' AND '" + txtBidDateTo.Text + "') AND ";
            else
            {
                if (txtBidDateFrom.Text.Length > 0)
                    query += " b.BidDate = '" + txtBidDateFrom.Text + "' AND ";
                if (txtBidDateTo.Text.Length > 0)
                    query += " b.BidDate = '" + txtBidDateTo.Text + "' AND ";
            }
            // StartDate
            if (txtStartDateFrom.Text.Length > 0 && txtStartDateTo.Text.Length > 0)
                query += " (b.ContractStartDate BETWEEN '" + txtStartDateFrom.Text + "' AND '" + txtStartDateTo.Text + "') AND ";
            else
            {
                if (txtStartDateFrom.Text.Length > 0)
                    query += " b.ContractStartDate = '" + txtStartDateFrom.Text + "' AND ";
                if (txtStartDateTo.Text.Length > 0)
                    query += " b.ContractStartDate = '" + txtStartDateTo.Text + "' AND ";
            }
            // Cash Percent
            if (txtCashReceivedPercentFrom.Text.Length > 0 && txtCashReceivedPercentTo.Text.Length > 0)
            {
                query += " (bb.CashReceivedPercent BETWEEN " + txtCashReceivedPercentFrom.Text.Replace("$", "").Replace(",", "") + " AND " + txtCashReceivedPercentTo.Text.Replace("$", "").Replace(",", "") + ") AND ";
            }
            else
            {
                if (txtCashReceivedPercentFrom.Text.Length > 0)
                {
                    query += " ( bb.CashReceivedPercent >= " + txtCashReceivedPercentFrom.Text.Replace("$", "").Replace(",", "") + " ) AND ";
                }
                if (txtCashReceivedPercentTo.Text.Length > 0)
                {
                    query += " ( bb.CashReceivedPercent >=" + txtCashReceivedPercentTo.Text.Replace("$", "").Replace(",", "") + " ) AND ";
                }
            }
            // Compeletion Date
            if (txtCompDateFrom.Text.Length > 0 && txtCompDateTo.Text.Length > 0)
                query += " (b.ContractEstComplDate BETWEEN '" + txtCompDateFrom.Text + "' AND '" + txtCompDateTo.Text + "') AND ";
            else
            {
                if (txtCompDateFrom.Text.Length > 0)
                    query += " b.ContractEstComplDate = '" + txtCompDateFrom.Text + "' AND ";
                if (txtCompDateTo.Text.Length > 0)
                    query += " b.ContractEstComplDate = '" + txtCompDateTo.Text + "' AND ";
            }
            // WONLost Date
            if (txtWLDateFrom.Text.Length > 0 && txtWLDateTo.Text.Length > 0)
                query += " (b.WONLostDate BETWEEN '" + txtWLDateFrom.Text + "' AND '" + txtWLDateTo.Text + "') AND ";
            else
            {
                if (txtWLDateFrom.Text.Length > 0)
                    query += " b.WONLostDate = '" + txtWLDateFrom.Text + "' AND ";
                if (txtWLDateTo.Text.Length > 0)
                    query += " b.WONLostDate = '" + txtStartDateTo.Text + "' AND ";
            }

            // 10/16/2008
            // Security
            //
            query += " [dbo].[GetUserJobAccess](b.JobID,'" + Security.Security.LoginID + "')  = 1 AND ";
            //
            // 06/18/2013
            // Job Access Read Only & Read Write
            // 


            if (query.Length == 7)
                query = "";
            else
                query = query.Remove(query.Length - 4, 4);
            queryCondition = query;
            GetJobList(query);
            if (isAdHoc)
            {
                panReportParamters.Controls.Clear();
                panReportParamters.Controls.Add(new ctlAdHocReport(queryCondition));

            }

        }
        //
        private void cboCustomerName_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboCustomerName.EditValue = String.Empty;
            }

        }
        //
        private void cboOwnerClass_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboOwnerClass.EditValue = String.Empty;
            }
        }
        //
        private void cboDepartment_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboDepartment.EditValue = String.Empty;
            }
        }
        //
        private void cboOffice_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboOffice.EditValue = String.Empty;
            }
        }
        //
        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEstimateNumber.Text = String.Empty;
            txtJobNumber.Text = String.Empty;
            this.txtJobName.Text = String.Empty;
            cboJobStatus.EditValue = null;
            cboOffice.EditValue = null;
            cboDepartment.EditValue = null;
            cboCustomerName.EditValue = null;
            cboOwnerClass.EditValue = null;
            cboProjectManager.EditValue = null;
            cboEstimator.EditValue = null;
            cboSuperintendent.EditValue = null;
            cboForeman.EditValue = null;
            cboContractType.EditValue = null;
            txtBidDateFrom.Text = String.Empty;
            txtBidDateTo.Text = String.Empty;
            txtStartDateFrom.Text = String.Empty;
            txtStartDateTo.Text = String.Empty;
            txtCompDateFrom.Text = String.Empty;
            txtCompDateTo.Text = String.Empty;
            txtWLDateFrom.Text = String.Empty;
            txtWLDateTo.Text = String.Empty;
            txtCashReceivedPercentFrom.Text = null;
            txtCashReceivedPercentTo.Text = null;

            chkStarbuilderList.CheckState = CheckState.Unchecked;
            btnClear.Visible = false;
        }
        //
        public void UpdateListView(JobListView jobView)
        {
            jobListView = jobView;
            if (grdJobListView.Columns["Job Status"].GroupIndex > -1)
                grdJobListView.Columns["Job Status"].UnGroup();
            if (grdJobListView.Columns["Department"].GroupIndex > -1)
                grdJobListView.Columns["Department"].UnGroup();
            if (grdJobListView.Columns["Office"].GroupIndex > -1)
                grdJobListView.Columns["Office"].UnGroup();
            if (grdJobListView.Columns["Customer"].GroupIndex > -1)
                grdJobListView.Columns["Customer"].UnGroup();

            if (grdJobListView.Columns["Project Manager"].GroupIndex > -1)
                grdJobListView.Columns["Project Manager"].UnGroup();
            if (grdJobListView.Columns["Superintendent"].GroupIndex > -1)
                grdJobListView.Columns["Superintendent"].UnGroup();
            if (grdJobListView.Columns["Estimator"].GroupIndex > -1)
                grdJobListView.Columns["Estimator"].UnGroup();
            if (grdJobListView.Columns["Foreman"].GroupIndex > -1)
                grdJobListView.Columns["Foreman"].UnGroup();
            switch (jobListView)
            {
                case JobListView.Customer:
                    grdJobListView.Columns["Customer"].Group();
                    break;
                //   case JobListView.CustomerClass:
                //       gridView1.Columns["Customer Class"].Group();
                //       break;
                case JobListView.Department:
                    grdJobListView.Columns["Department"].Group();
                    break;
                case JobListView.Estimator:
                    grdJobListView.Columns["Estimator"].Group();
                    break;
                case JobListView.Foreman:
                    grdJobListView.Columns["Foreman"].Group();
                    break;
                case JobListView.JobStatus:
                    grdJobListView.Columns["Job Status"].Group();
                    break;
                case JobListView.Office:
                    grdJobListView.Columns["Office"].Group();
                    break;
                case JobListView.ProjectManager:
                    grdJobListView.Columns["Project Manager"].Group();
                    break;
                case JobListView.Superintendent:
                    grdJobListView.Columns["Superintendent"].Group();
                    break;
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            //frmJob job = new frmJob("0", jobSourceBinding, Security.Security.JobCaller.JCCJob);
            // job.ShowDialog();
        }
        //
        private void cboReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Control ctlReport = new Control();
            panReportParamters.Controls.Clear();
            switch (cboReport.Text)
            {
                case "Ad Hoc":
                    isAdHoc = true;
                    panReportParamters.Controls.Add(new ctlAdHocReport(queryCondition));
                    break;
                case "Bid Schedule":
                    panReportParamters.Controls.Add(new ctlBidScheduleReport());
                    break;
                case "Weekly Budget":
                    panReportParamters.Controls.Add(new ctlWeeklyBudgetReport());
                    break;
                case "Weekly Estimate Successful":
                    panReportParamters.Controls.Add(new ctlWeeklySuccessfulReport());
                    break;
                case "Weekly Estimate No No Bid":
                    panReportParamters.Controls.Add(new ctlWeeklyEstimateNoNoBidReport());
                    break;
                case "Weekly Estimate Open Pending":
                    panReportParamters.Controls.Add(new ctlWeeklyEstimateOpenPendingReport());
                    break;
                case "Weekly New Job":
                    panReportParamters.Controls.Add(new ctlWeeklyNewJobReport());
                    break;
                case "Weekly Million Dollar":
                    panReportParamters.Controls.Add(new ctlWeeklyMillionDollarReport());
                    break;
                case "OCIP Classified Jobs":
                    panReportParamters.Controls.Add(new ctlOCIPClassifiedProjectsReport());
                    break;
                case "Pre Job Planning":
                    panReportParamters.Controls.Add(new ctlPreJobPlanning());
                    break;
                case "Company Estimate Review":
                    panReportParamters.Controls.Add(new ctlCompanyEstimateReviewReport());
                    break;
                case "Company Estimate History":
                    panReportParamters.Controls.Add(new ctlCompanyEstimateHistoryReport());
                    break;

                case "POs With No Invoice":
                    panReportParamters.Controls.Add(new ctlPOsWithNoInvoiceReport());
                    break;
                case "Customer Invoices Aging":
                    panReportParamters.Controls.Add(new ctlCustomerInvoicesAgingReport());
                    break;

                case "Job Labor Analysis":
                    panReportParamters.Controls.Add(new ctlJobLaborAnalysisReport());
                    break;

                case "Job by Cost Codes":
                    panReportParamters.Controls.Add(new ctlJobByCostCodesReport());
                    break;

                case "Month End":
                    panReportParamters.Controls.Add(new ctlJobProgressSummaryReport());
                    break;
                case "Job Log List":
                    panReportParamters.Controls.Add(new ctlJobLogReport());
                    break;

                case "Job Prequal":
                    panReportParamters.Controls.Add(new ctlJobPrequalReport());
                    break;

                case "POs With Invoices - Different Job Number":
                    panReportParamters.Controls.Add(new ctlPOsWithNoMatchInvoiceReport());
                    break;

                case "Jobs with Labor Activities by Week":
                    panReportParamters.Controls.Add(new ctlJobsWithLaborActivityByWeekReport());
                    break;
                case "All Insurance Requirements":
                    panReportParamters.Controls.Add(new ctlAllInsuranceRequirementsReport());
                    break;

                default:
                    break;
            }
        }
        //
        private void dockManager1_StartDocking(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }
        //
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            DataRow row = grdJobListView.GetDataRow(e.RowHandle);
            Job.UpdateAdjustmentPercent(row[0].ToString(), row["AdjustmentPercent"].ToString());

        }
        //
        private void cboContractType_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboContractType.EditValue = String.Empty;
            }
        }
        //
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdJobListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "MainJobList", configuration);
                        config.Save();
                        grdJobListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdJobListView.CustomizationForm != null)
                            grdJobListView.CustomizationForm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
                case "btnRestoreYourCustomization":
                    RestoreCustomization();
                    break;
                case "btnDelete":
                    // RestoreCustomization();
                    break;
                case "btnResetColumns":
                    try
                    {
                        if (grdJobListView.CustomizationForm != null)
                        {
                            grdJobListView.CustomizationForm.Enabled = false;
                            grdJobListView.OptionsCustomization.AllowColumnMoving = false;
                            grdJobListView.CustomizationForm.Controls.Clear();
                            grdJobListView.CustomizationForm.Close();
                        }
                        grdJobList.Refresh();
                        grdJobListView.PopulateColumns();
                        grdJobListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdJobListView.CustomizationForm != null)
                            grdJobListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdJobListView.OptionsCustomization.AllowColumnMoving = true;
                    grdJobListView.ColumnsCustomization();
                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdJobListView.RowCount == 0)
                            return;
                        string fileName = "JobListAdHoc.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
                        grdJobListView.ExportToXls(tempLocation + "\\" + fileName, option);
                        // 
                        Excel.Application oXl;
                        Excel.Workbook oBook;
                        oXl = new Microsoft.Office.Interop.Excel.Application();
                        try
                        {
                            oBook = oXl.Workbooks._Open(tempLocation + "\\" + fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                        }
                        catch (Exception ex1)
                        {
                            MessageBox.Show(ex1.Message, CCEApplication.ApplicationName);
                        }
                        oXl.Visible = true;
                        oXl.UserControl = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private void RestoreCustomization()
        {
            try
            {
                string configuration = "";

                configuration = Security.BusinessLayer.UserConfiguration.GetConfiguration(
                    Security.Security.UserID.ToString(), "MainJobList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdJobListView.RestoreLayoutFromStream(stream);
                grdJobListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdJobListView.CustomizationForm != null)
                    grdJobListView.CustomizationForm.Close();
                // FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdJobListView_DragObjectStart(object sender, DevExpress.XtraGrid.Views.Base.DragObjectStartEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn col = (DevExpress.XtraGrid.Columns.GridColumn)e.DragObject;

            if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
             Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
            {
                switch (col.FieldName)
                {
                    case "RecordNo":
                        e.Allow = false;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (col.FieldName)
                {
                    case "RecordNo":
                    case "AdjustmentPercent":
                    case "CurrentBudgetLabor":
                    case "CommittedCostToDateLabor":
                        e.Allow = false;
                        break;
                    default:
                        break;
                }
            }
        }
        //
        private void grdJobListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuJobList.ShowPopup(ctlJobList.MousePosition);
        }

        private void grdJobListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdJobListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobListView.Columns)
                {
                    if (col.FilterInfo.FilterCriteria != null)
                    {
                        if (col.FilterInfo.FilterCriteria.ToString().Length > 0)
                        {
                            criteria += col.FilterInfo.FilterCriteria.ToString();
                            criteria += " AND ";
                        }
                    }
                }
                if (criteria.Length > 0)
                    criteria = criteria.Substring(0, criteria.Length - 4);
                jobTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
            }
            catch
            {
            }

        }

        private void grdJobListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                ColumnSortOrder sort = info.Column.SortOrder;
                string command = info.Column.FieldName;
                if (info.Column.SortOrder == ColumnSortOrder.Ascending)
                {
                    command += " DESC";
                    reportSort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    reportSort = info.Column.Caption + " ASC";
                }
                jobTable.DefaultView.Sort = command;
            }
        }

        private void btnAddNewJob_MouseClick(object sender, MouseEventArgs e)
        {
            frmJob job = new frmJob("0", jobSourceBinding, Security.Security.JobCaller.JCCJob);
            job.ShowDialog();
        }

        private void grdJobListView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {

            bool userSecurity = true;
            if ((Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator))
            { userSecurity = false; }
            else if (Security.Security.UserJCCAccess != Security.Security.Access.JCCAdministrator)
            { userSecurity = false; }
            else if (Security.Security.UserJCCAccess != Security.Security.Access.JCCSuperUser)
            { userSecurity = false; }
            else
            { userSecurity = true; }

            if (userSecurity)
            {

                int i = mnuMenuJobList.ItemLinks.Count - 1;
                while (i >= 0)
                {
                    if (mnuMenuJobList.ItemLinks[i].Item is BarButtonItem)
                    {
                        if (mnuMenuJobList.ItemLinks[i].Item.Caption == "Delete")
                        {
                            mnuMenuJobList.RemoveLink(mnuMenuJobList.ItemLinks[i]);
                        }
                    }
                    i--;
                }
            }
        }
    }
}
