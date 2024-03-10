using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using JCCReports;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace CCEJobs.Controls
{
    public enum JobDashboardView
    {
        Office,
        Department,
        Customer,
        ProjectManager,
        Estimator,
        Foreman,
        List
    }
    //
    public partial class ctlJobDashboard : UserControl
    {
        private BindingSource jobSourceBinding = new BindingSource();
        private JobDashboardView jobListView = JobDashboardView.List;
        private DataTable jobList;
        private string reportQuery;
        private float projectedProfitPercentage;
        private float profitGainFade;
        private float jobPerformanceFactor;
        private frmJob job;
        private string query = "";
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;

        public ctlJobDashboard()
        {
            InitializeComponent();

            lblLaborPerformance.BackColor = Color.Wheat;
            lblProjectProfit.BackColor = Color.LightGreen;
            lblLaborPerformanceProjectProfit.BackColor = Color.LightBlue;

            chartOrganization.DataSource = grdOrganization;
            chartOrganization.SeriesDataMember = "Series";
            chartOrganization.SeriesTemplate.ArgumentDataMember = "Arguments";
            chartOrganization.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
            chartOrganization.SeriesTemplate.Label.Visible = false;
            chartOrganization.SeriesTemplate.Label.Antialiasing = true;
 
            chartOrganization.PaletteName = "Apex";
            chartOrganization.SeriesTemplate.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            chartOrganization.SeriesTemplate.PointOptions.ValueNumericOptions.Precision = 0;
            //
            DevExpress.XtraCharts.XYDiagram diag = (DevExpress.XtraCharts.XYDiagram)chartOrganization.Diagram;
            diag.AxisX.Range.SetInternalMinMaxValues(0, 10);
            diag.AxisX.Label.Angle = 50;
            diag.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number;
            diag.AxisY.NumericOptions.Precision = 0;

            GetJobList(" AND b.JobID = 0 ");
            initialScreen = false;

            DataSet ds;
            try
            {
                ds = Job.GetDashboardFlags();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    projectedProfitPercentage = float.Parse(ds.Tables[0].Rows[0]["ProjectedProfitPercentage"].ToString());
                    profitGainFade = float.Parse(ds.Tables[0].Rows[0]["ProfitGainFade"].ToString());
                    jobPerformanceFactor = float.Parse(ds.Tables[0].Rows[0]["JobPerformanceFactor"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdJobList_DoubleClick(object sender, EventArgs e)
        {
            DataRow dataRow;
            dataRow =  this.grdJobListView.GetDataRow(grdJobListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
               // DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");


                if (job != null)
                {
                    job.Close();
                    job.Dispose();
                }
                job = new frmJob(dataRow[0].ToString(), jobSourceBinding, Security.Security.JobCaller.JCCDashboard );
                job.Show();
               // DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
            }
        }
        //
        private void ctlJobList_Load(object sender, EventArgs e)
        {
            cboContractType.Properties.DataSource = StaticTables.ContractType;
            cboContractType.Properties.DisplayMember = "Description";
            cboContractType.Properties.ValueMember = "ContractTypeID";
            cboContractType.Properties.PopulateColumns();
            cboContractType.Properties.ShowHeader = false;
            //
            cboCustomerName.Properties.DataSource = StaticTables.Customers;
            cboCustomerName.Properties.DisplayMember = "Name";
            cboCustomerName.Properties.ValueMember = "CustomerID";
            cboCustomerName.Properties.PopulateColumns();
            cboCustomerName.Properties.ShowHeader = false;
            //
            cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
            cboProjectManager.Properties.DisplayMember = "Description";
            cboProjectManager.Properties.ValueMember = "ProjectManagerID";
            cboProjectManager.Properties.PopulateColumns();
            cboProjectManager.Properties.ShowHeader = false;
            //
            cboEstimator.Properties.DataSource = StaticTables.Estimator;
            cboEstimator.Properties.DisplayMember = "Description";
            cboEstimator.Properties.ValueMember = "EstimatorID";
            cboEstimator.Properties.PopulateColumns();
            cboEstimator.Properties.ShowHeader = false;
            //
            cboDepartment.Properties.DataSource = StaticTables.Department;
            cboDepartment.Properties.DisplayMember = "DepartmentName";
            cboDepartment.Properties.ValueMember = "DepartmentID";
            cboDepartment.Properties.PopulateColumns();
            cboDepartment.Properties.ShowHeader = false;
            //
            cboOffice.Properties.DataSource = StaticTables.Office;
            cboOffice.Properties.PopulateColumns();
            cboOffice.Properties.DisplayMember = "OfficeName";
            cboOffice.Properties.ValueMember = "OfficeID";
            cboOffice.Properties.ShowHeader = false;
            //
            cboForeman.Properties.DataSource = StaticTables.Foreman;
            cboForeman.Properties.DisplayMember = "Description";
            cboForeman.Properties.ValueMember = "ForemanID";
            cboForeman.Properties.PopulateColumns();
            cboForeman.Properties.ShowHeader = false;
            //
            cboProjectManager.Properties.Columns[0].Visible = false;
            cboEstimator.Properties.Columns[0].Visible = false;
            cboDepartment.Properties.Columns[0].Visible = false;
            cboOffice.Properties.Columns[0].Visible = false;
            cboContractType.Properties.Columns[0].Visible = false;
            cboForeman.Properties.Columns[0].Visible = false;
        }
        private void GetJobList(string query)
        {
            try
            {
                if (!initialScreen)
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
                jobList = Job.GetJobListDashboard(query).Tables[0];
                jobSourceBinding.DataSource = jobList.DefaultView;
                grdJobList.DataSource = jobSourceBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            finally
            {
                grdJobList.MainView.PopulateColumns();
                RestoreCustomization();
                FormatGrid();
                UpdateOrganizationView();
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (jobList.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }
        }
        //
        private void FormatGrid()
        {
            grdJobListView.Columns[0].Visible = false;
            grdJobListView.Columns["Dashboard"].Visible = false;
            grdJobListView.Columns["TrackChangeOrder"].Visible = false;
            grdJobListView.Columns["Current Contract"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Projected Profit Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Cost To Date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Amount Billed"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Amount Paid"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Performance Factor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Profit Fade"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Profit Percentage"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Profit Percentage"].Caption = "Projected Profit";
            grdJobListView.Columns["Cost Performance Factor"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Labor Percentage"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Material Percentage"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Cash Received Percent"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Current Contract"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Projected Profit Amount"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Cost To Date"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Amount Billed"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Amount Paid"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Performance Factor"].DisplayFormat.FormatString = "{0:n}";
            grdJobListView.Columns["Performance Factor"].Caption = "Labor Performance Factor";
            grdJobListView.Columns["Profit Fade"].DisplayFormat.FormatString = "%{0:n2}";
            grdJobListView.Columns["Profit Percentage"].DisplayFormat.FormatString = "%{0:n2}";
            grdJobListView.Columns["Labor Percentage"].DisplayFormat.FormatString = "%{0:n2}";
            grdJobListView.Columns["Material Percentage"].DisplayFormat.FormatString = "%{0:n2}";
            grdJobListView.Columns["Cash Received Percent"].DisplayFormat.FormatString = "%{0:n2}";
            grdJobListView.Columns["Cost Performance Factor"].DisplayFormat.FormatString = "{0:n}";
            grdJobListView.Columns["Current Contract"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["Current Contract"].SummaryItem.DisplayFormat = "{0:c0}";
            grdJobListView.Columns["Projected Profit Amount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["Projected Profit Amount"].SummaryItem.DisplayFormat = "{0:c0}";
            grdJobListView.Columns["Cost To Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["Cost To Date"].SummaryItem.DisplayFormat = "{0:c0}";
            grdJobListView.Columns["Amount Billed"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["Amount Billed"].SummaryItem.DisplayFormat = "{0:c0}";
            grdJobListView.Columns["Amount Paid"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["Amount Paid"].SummaryItem.DisplayFormat = "{0:c0}";
            grdJobListView.Columns["Job No"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdJobListView.Columns["Job No"].SummaryItem.DisplayFormat = "Job Count: {0:n0}";
            grdJobListView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded;
            grdOrganization.DataSource = Job.GetJobListDashboardSummary(query).Tables[0].DefaultView;
            grdOrganization.RetrieveFields();
            grdOrganization.Fields["Office"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            grdOrganization.Fields["Department"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            grdOrganization.Fields["Project Manager"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            grdOrganization.Fields["Customer"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            grdOrganization.Fields["Current Contract"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOrganization.Fields["Current Contract"].CellFormat.FormatString = "n0";
            grdOrganization.Fields["Current Contract"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            grdOrganization.Fields["Cost To Date"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOrganization.Fields["Cost To Date"].CellFormat.FormatString = "n0";
            grdOrganization.Fields["Cost To Date"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            grdOrganization.Fields["Projected Profit"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOrganization.Fields["Projected Profit"].CellFormat.FormatString = "n0";
            grdOrganization.Fields["Projected Profit"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            grdOrganization.Fields["Amount Billed"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOrganization.Fields["Amount Billed"].CellFormat.FormatString = "n0";
            grdOrganization.Fields["Amount Billed"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            grdOrganization.Fields["Amount Paid"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOrganization.Fields["Amount Paid"].CellFormat.FormatString = "n0";
            grdOrganization.Fields["Amount Paid"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            grdOrganization.Fields["Number of Jobs"].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOrganization.Fields["Number of Jobs"].CellFormat.FormatString = "n0";
            grdOrganization.Fields["Number of Jobs"].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            grdOrganization.BestFit();
            DevExpress.XtraCharts.Series mySeries = new DevExpress.XtraCharts.Series();
            mySeries = chartOrganization.Series[0];
            grdJobListView.Columns["Job Name"].VisibleIndex = 1;
            grdJobListView.Columns["Job No"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.Columns["Contract Type"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.Columns["Job Name"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.BestFitColumns();
            grdJobListView.Columns["Current Contract"].ToolTip = "Current Contract:\n" +
                                                            "= Original Contract Cost + Approved CO + Pending With Proceed";
            grdJobListView.Columns["Cost To Date"].ToolTip = "Cost To Date\n" +
                                                        "Actual Cost. This value is pulled from Starbuilder";
            grdJobListView.Columns["Amount Billed"].ToolTip = "Amount Billed:\n" +
                                                        " Billed Amount to Date. This value is pulled from Starbuilder";
            grdJobListView.Columns["Amount Paid"].ToolTip = "Amount Paid:\n" +
                                                        "Amount Paid to Date. This value is pulled from Starbuilder";
            grdJobListView.Columns["Labor Percentage"].ToolTip = "Labor Percentage:\n " +
                                                            " = Actual Hours / Total Budget Hours ";
            grdJobListView.Columns["Cash Received Percent"].ToolTip = "Cash Received Percent:\n " +
                                                           " = Amount Paid / Current Contract ";
            grdJobListView.Columns["Cost Performance Factor"].ToolTip = "Cost Performance Factor:\n" +
                                                                " Revised Cost at Completion  / Total Budget Cost\n " +
                                                                "Warning Red Color will be displayed when Cost Performance Factor is > " + StaticTables.costPerformanceFactor.ToString();
            grdJobListView.Columns["Performance Factor"].ToolTip = "Labor Performance Factor:\n" +
                                                               "= (Estimated Performance Factor *  Total Budget Hours) / Total Budget Hours\n" +
                                                               "Warning Red Color will be displayed when Performace Factor is > " + StaticTables.jobPerformanceFactor.ToString();
            grdJobListView.Columns["Profit Percentage"].ToolTip = "Projected Profit:\n" +
                                                            "= Projected Profit / Current Contract\n" +
                                                            "Warning Red Color will be displayed when Projected Profit is < " + StaticTables.projectedProfitPercentage.ToString();
            grdJobListView.Columns["Profit Fade"].ToolTip = " Profit Fade:\n" +
                                                        "= Projected Profit Percentage - Baseline Profit Percentage \n" +
                                                       "Warning Red Color will be displayed when Gain Fade is  < " + StaticTables.profitGainFade.ToString();
            grdJobListView.Columns["Material Percentage"].ToolTip = " Material Percentage:\n" +
                                                            "= Actual Cost  / Total Budget Cost\n" +
                                                            "Warning Red Color will be displayed when Labor Percentage is > " + StaticTables.laborPercentage.ToString() +
                                                            " and Material Percentage is < " + StaticTables.materialPercentage.ToString();
        }
        //
        private void UpdateOrganizationView()
        {
            switch (jobListView)
            {
                case JobDashboardView.Customer:
                    grdOrganization.Fields["Customer"].Visible = true;
                    grdOrganization.Fields["Project Manager"].Visible = false;
                    break;
                case JobDashboardView.ProjectManager:
                    grdOrganization.Fields["Customer"].Visible = false;
                    grdOrganization.Fields["Project Manager"].Visible = true;
                    break;
                default:
                    grdOrganization.Fields["Customer"].Visible = false;
                    grdOrganization.Fields["Project Manager"].Visible = false;
                    break;
            }
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {   
            query = "";
            try
            {
                reportQuery = "Report Query: \n";
                if (cboOffice.Text.Trim().Length > 0)
                {
                    query += " AND b.OfficeID = " + cboOffice.EditValue.ToString() + " ";
                    reportQuery += "Office:  " + cboOffice.Text + "\n";
                }

                if (cboContractType.Text.Trim().Length > 0)
                {
                    query += " AND b.ContractTypeID = " + cboContractType.EditValue.ToString() + " ";
                    reportQuery += "Contract Type:  " + cboContractType.Text + "\n";
                }


                if (cboDepartment.Text.Trim().Length > 0)
                {
                    query += " AND b.DepartmentID = " + cboDepartment.EditValue.ToString() + " ";
                    reportQuery += "Department:  " + cboDepartment.Text + "\n";
                }
                if (cboCustomerName.Text.Trim().Length > 0)
                {
                    query += " AND b.CustomerID = '" + cboCustomerName.EditValue.ToString() + "' ";
                    reportQuery += "Customer:  " + cboCustomerName.Text + "\n";
                }
                if (cboProjectManager.Text.Trim().Length > 0)
                {
                    query += " AND b.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " ";
                    reportQuery += "Project Manager:  " + cboProjectManager.Text + "\n";
                }
                if (cboEstimator.Text.Trim().Length > 0)
                {
                    query += " AND b.EstimatorID = " + cboEstimator.EditValue.ToString() + " ";
                    reportQuery += "Estimator:  " + cboEstimator.Text + "\n";
                }

                if (cboForeman.Text.Trim().Length > 0)
                {
                    query += " AND b.ForemanID = " + cboForeman.EditValue.ToString() + "  ";
                    reportQuery += "Foreman:  " + cboForeman.Text + "\n";

                }

                if (radioArchiveStatus.SelectedIndex == 0)
                {
                    query += " AND b.Archived =  0 " + " ";
                    reportQuery += "Open Status:  " + "Open " + "\n";
                }
                if (radioArchiveStatus.SelectedIndex == 1)
                {
                    query += " AND b.Archived =  1 " + " ";
                    reportQuery += "Open Status:  " + "Closed" + "\n";
                }


                if (radioJobCompletedStatus.SelectedIndex == 0)
                {
                    query += " AND z.JobCompleted =  1 " + " ";
                    reportQuery += "Job Completed (Field):  " + "Completed. " + "\n";
                }
                if (radioJobCompletedStatus.SelectedIndex == 1)
                {
                    query += " AND z.JobCompleted =  0 " + " ";
                    reportQuery += "Job Completed (Field):  " + "Not Completed" + "\n";
                }


                // StartDate
                if (txtStartDateFrom.Text.Length > 0 && txtStartDateTo.Text.Length > 0)
                {
                    query += " AND (b.ContractStartDate BETWEEN '" + txtStartDateFrom.Text + "' AND '" + txtStartDateTo.Text + "') ";
                    reportQuery += "Start Date Between:  " + txtStartDateFrom.Text + " and " + txtStartDateTo.Text + "\n";
                }
                else
                {
                    if (txtStartDateFrom.Text.Length > 0)
                    {
                        query += " AND b.ContractStartDate = '" + txtStartDateFrom.Text + "' ";
                        reportQuery += "Start Date:  " + txtStartDateFrom.Text + "\n";

                    }
                    if (txtStartDateTo.Text.Length > 0)
                    {
                        query += " AND b.ContractStartDate = '" + txtStartDateTo.Text + "' ";
                        reportQuery += "Start Date:  " + txtStartDateTo.Text + "\n";
                    }
                }
                // Compeletion Date
                if (txtCompDateFrom.Text.Length > 0 && txtCompDateTo.Text.Length > 0)
                {
                    query += " AND (b.ContractEstComplDate BETWEEN '" + txtCompDateFrom.Text + "' AND '" + txtCompDateTo.Text + "') ";
                    reportQuery += "Compl Date Between:  " + txtCompDateFrom.Text + " and " + txtCompDateTo.Text + "\n";
                }
                else
                {
                    if (txtCompDateFrom.Text.Length > 0)
                    {
                        query += " AND b.ContractEstComplDate = '" + txtCompDateFrom.Text + "' ";
                        reportQuery += "Compl Date:  " + txtCompDateFrom.Text + "\n";
                    }
                    if (txtCompDateTo.Text.Length > 0)
                    {
                        query += " AND b.ContractEstComplDate = '" + txtCompDateTo.Text + "' ";
                        reportQuery += "Compl Date:  " + txtCompDateTo.Text + "\n";
                    }
                }
                // Current Amount
                if (txtCurrentAmountFrom.Text.Length > 0 && txtCurrentAmountTo.Text.Length > 0)
                {
                    query += " AND (z.CurrentContract BETWEEN " + txtCurrentAmountFrom.Text.Replace("$", "").Replace(",", "") + " AND " + txtCurrentAmountTo.Text.Replace("$", "").Replace(",", "") + ") ";
                    reportQuery += "Contract Amt.:  " + txtCurrentAmountFrom.Text + " and " + txtCurrentAmountTo.Text + "\n";
                }
                else
                {
                    if (txtCurrentAmountFrom.Text.Length > 0)
                    {
                        query += " AND ( z.CurrentContract >= " + txtCurrentAmountFrom.Text.Replace("$", "").Replace(",", "") + " ) ";
                        reportQuery += "Current Amt. >=:  " + txtCurrentAmountFrom.Text + "\n";
                    }
                    if (txtCurrentAmountTo.Text.Length > 0)
                    {
                        query += " AND ( z.CurrentContract >=" + txtCurrentAmountTo.Text.Replace("$", "").Replace(",", "") + " ) ";
                        reportQuery += "Current Amt. >=  " + txtCurrentAmountTo.Text + "\n";
                    }
                }
                // Cash Percent
                if (txtCashReceivedPercentFrom.Text.Length > 0 && txtCashReceivedPercentTo.Text.Length > 0)
                {
                    query += " AND (z.CashReceivedPercent BETWEEN " + txtCashReceivedPercentFrom.Text.Replace("$", "").Replace(",", "") + " AND " + txtCashReceivedPercentTo.Text.Replace("$", "").Replace(",", "") + ") ";
                    reportQuery += "Cash Receive:  " + txtCashReceivedPercentFrom.Text + " and " + txtCashReceivedPercentTo.Text + "\n";
                }
                else
                {
                    if (txtCashReceivedPercentFrom.Text.Length > 0)
                    {
                        query += " AND ( z.CashReceivedPercent >= " + txtCashReceivedPercentFrom.Text.Replace("$", "").Replace(",", "") + " ) ";
                        reportQuery += "% Cash Received >=:  " + txtCashReceivedPercentFrom.Text + "\n";
                    }
                    if (txtCashReceivedPercentTo.Text.Length > 0)
                    {
                        query += " AND ( z.CashReceivedPercent >=" + txtCashReceivedPercentTo.Text.Replace("$", "").Replace(",", "") + " ) ";
                        reportQuery += "% Cash Received >=:  " + txtCashReceivedPercentTo.Text + "\n";
                    }
                }
                //
                if (txtPerformanceFactor.Text.Length > 0)
                {
                    query += " AND (JobPerformanceFactor >= " + txtPerformanceFactor.Text.Replace(",", "") + ") ";
                    reportQuery += "Performance Factor:  " + txtPerformanceFactor.Text + "\n";
                }
                if (txtProfitFade.Text.Length > 0)
                {
                    query += " AND (ProfitGainFade >= " + txtProfitFade.Text.Replace("'", "") + ") ";
                    reportQuery += "Profit Fade:  " + txtProfitFade.Text + "\n";
                }
                if (txtProfitPercentage.Text.Length > 0)
                {
                    query += " AND (ProjectedProfitPercentage >= " + txtProfitPercentage.Text.Replace(",", "") + ") ";
                    reportQuery += "Profit Percentage:  " + txtProfitPercentage.Text + "\n";
                }
                // Out of Compliance
                if (chkOutOfCompliance.CheckState == CheckState.Checked)
                {
                    query += " AND (ProjectedProfitPercentage < " + projectedProfitPercentage + " OR " +
                                  " JobPerformanceFactor > " + jobPerformanceFactor + " )   AND ( LTRIM(RTRIM(aaa.Code)) <> 'TM' ) ";
                    query += " AND (z.CurrentContract > = 250000 ) ";

                    reportQuery += "Out of Compliance:  " + chkOutOfCompliance.Checked + "\n";
                }
                // Missing Quantities
                if (chkMissingQuantities.CheckState == CheckState.Checked)
                {
                    query += " AND ((SELECT COUNT(tblJobCostCodePhase.JobID) FROM tblJobCostCodePhase  " +
                            " WHERE  " +
                            " JobCostCodeType = 'L' " +
                            " AND CommittedHours > 0 " +
                            " AND CommittedQuantity = 0 " +
                            " AND tblJobCostCodePhase.JobID = b.JobID " +
                            " ) > 0 )";
                    query += " AND ( LTRIM(RTRIM(aaa.Code)) <> 'TM' ) ";

                    reportQuery += "Missing Quantities:  " + chkMissingQuantities.Checked + "\n";
                }

                query += " AND ([dbo].[GetUserJobAccessDashboard](b.JobID, '" + Security.Security.LoginID + "')  = 1)  ";

                GetJobList(query);
                UpdateView(jobListView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void cboCustomerName_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboCustomerName.EditValue = String.Empty;
            }
            
        }

        private void cboDepartment_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboDepartment.EditValue = String.Empty;
            }
        }

        private void cboOffice_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboOffice.EditValue = String.Empty;
            }
        }

        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboOffice.EditValue = null;
            cboDepartment.EditValue = null;
            cboCustomerName.EditValue = null;
            cboProjectManager.EditValue = null;
            cboEstimator.EditValue = null;
            cboContractType.EditValue = null;
            txtStartDateFrom.Text = String.Empty;
            txtStartDateTo.Text = String.Empty;
            txtCompDateFrom.Text = String.Empty;
            txtCompDateTo.Text = String.Empty;
            txtCurrentAmountFrom.EditValue = null;
            txtCurrentAmountTo.EditValue = null;
            txtPerformanceFactor.Text = String.Empty;
            txtProfitFade.Text = String.Empty;
            txtProfitPercentage.Text = String.Empty;
            txtCurrentAmountFrom.Text = null;
            txtCurrentAmountTo.Text = null;
            txtCashReceivedPercentFrom.Text = null;
            txtCashReceivedPercentTo.Text = null;
            btnClear.Visible = false;
        }
        //
        private void radioGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOrganizationView();
            UpdateView(jobListView);
        }
        //
        public void UpdateView(JobDashboardView jobListView)
        {
            this.jobListView = jobListView;
            if (grdJobListView.Columns["Department"].GroupIndex > -1)
                grdJobListView.Columns["Department"].UnGroup();
            if (grdJobListView.Columns["Office"].GroupIndex > -1)
                grdJobListView.Columns["Office"].UnGroup();
            if (grdJobListView.Columns["Customer"].GroupIndex > -1)
                grdJobListView.Columns["Customer"].UnGroup();
            if (grdJobListView.Columns["Project Manager"].GroupIndex > -1)
                grdJobListView.Columns["Project Manager"].UnGroup();
            if (grdJobListView.Columns["Estimator"].GroupIndex > -1)
                grdJobListView.Columns["Estimator"].UnGroup();
            if (grdJobListView.Columns["Foreman"].GroupIndex > -1)
                grdJobListView.Columns["Foreman"].UnGroup();

            grdJobListView.GroupSummary.Clear();
            switch (jobListView)
            {
                case JobDashboardView.Customer:
                    grdJobListView.Columns["Customer"].Group();
                    break;
                case JobDashboardView.Department:
                    grdJobListView.Columns["Department"].Group();
                    break;
                case JobDashboardView.Estimator:
                    grdJobListView.Columns["Estimator"].Group();
                    break;
                case JobDashboardView.Office:
                    grdJobListView.Columns["Office"].Group();
                    break;
                case JobDashboardView.ProjectManager:
                    grdJobListView.Columns["Project Manager"].Group();
                    break;
                case JobDashboardView.Foreman:
                    grdJobListView.Columns["Foreman"].Group();
                    break;

            }
            grdJobListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "Job No", grdJobListView.Columns["Job No"], "Job Count: {0:n0}");
            grdJobListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Current Contract", grdJobListView.Columns["Current Contract"], "{0:c0}");
            grdJobListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Cost To Date", grdJobListView.Columns["Cost To Date"], "{0:c0}");
            grdJobListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount Billed", grdJobListView.Columns["Amount Billed"], "{0:c0}");
            grdJobListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Amount Paid", grdJobListView.Columns["Amount Paid"], "{0:c0}");
        }
        //
        private void btnSummary_Click(object sender, EventArgs e)
        {
            Reports.JobDashboardSummary(chartOrganization, grdOrganization, reportQuery);
        }
        //
        private void chartOrganization_BoundDataChanged(object sender, EventArgs e)
        {
            if (chartOrganization.Series.Count >  0)
            {
                foreach (DevExpress.XtraCharts.Series ser in chartOrganization.Series)
                {
                    if (ser.Name.Length > 13)
                        ser.LegendText = ser.Name.Substring(13, ser.Name.Length - 13);
                    else
                        ser.LegendText = "";
                }
            }
        }
        //
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            if (e.RowHandle >= 0)
            {

                    if (IsTM(sender, e))
                        return;

                    string performanceFactor = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Performance Factor"]);
                    string profitPercentage = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Profit Percentage"]);
                    string materialPercentage = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Material Percentage"]);
                    if (Convert.ToDouble(performanceFactor.Replace("%", "").Replace(",", "")) > jobPerformanceFactor)
                    {
                        count++;
                        count2++;
                    }
                    if (Convert.ToDouble(profitPercentage.Replace("%", "").Replace(",", "")) < projectedProfitPercentage)
                    {
                        count1++;
                        count2++;
                    }
                    if (count2 > 1)
                        e.Appearance.BackColor = Color.LightBlue;
                    else
                        if (count1 == 1)
                            e.Appearance.BackColor = Color.LightBlue;
                        else
                            if (count == 1)
                                e.Appearance.BackColor = Color.LightBlue; 
            }
        }
        //
        private void btnDetail_Click(object sender, EventArgs e)
        {
            Reports.JobDashboardDetail(jobList, reportQuery);
        }
        //
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView View = sender as GridView;
           
            if (e.RowHandle >= 0)
            {
                    if (IsTM(sender, e))
                        return;
                    string performanceFactor = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Performance Factor"]);
                    string profitPercentage = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Profit Percentage"]);
                    string profitFade = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Profit Fade"]);
                    string costPerformanceFactor = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Cost Performance Factor"]);
                    string laborPercentage = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Labor Percentage"]);
                    string materialPercentage = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Material Percentage"]);

                  
                    switch (e.Column.Caption)
                    {
                        case "Labor Performance Factor":
                            if (Convert.ToDouble(performanceFactor.Replace("%", "").Replace(",", "")) > jobPerformanceFactor)
                            {
                                e.Appearance.BackColor = Color.Salmon;
                            }
                            break; 
                        case "Projected Profit":
                            if (Convert.ToDouble(profitPercentage.Replace("%", "").Replace(",", "")) < projectedProfitPercentage)
                            {
                                e.Appearance.BackColor = Color.Salmon;
                            }
                            break;
                        case "Profit Fade":
                            if (Convert.ToDouble(profitFade.Replace("%", "").Replace(",", "")) < profitGainFade)
                            {
                                e.Appearance.BackColor = Color.Salmon;
                            }
                            break;
                        
                        case "Cost Performance Factor":
                            if (Convert.ToDouble(costPerformanceFactor.Replace("%", "").Replace(",", "")) > StaticTables.costPerformanceFactor)
                            {
                                e.Appearance.BackColor = Color.Salmon;
                            }
                            break;

                        case "Material Percentage":
                            double lb = Convert.ToDouble(laborPercentage.Replace("%", "").Replace(",", ""));
                            double mb = Convert.ToDouble(materialPercentage.Replace("%", "").Replace(",", ""));

                            if (lb > StaticTables.laborPercentage && mb < StaticTables.materialPercentage)
                            {
                                e.Appearance.BackColor = Color.Salmon;
                            }
                            break;
                    }
            }
        }
        //
        private bool IsTM(object sender,   DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string contractType = "";
            string trackChangeOrder = "";
            GridView View = sender as GridView;

            contractType = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Contract Type"]);
            trackChangeOrder = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TrackChangeOrder"]);
            if (View.GetRowCellDisplayText(e.RowHandle, View.Columns["Dashboard"]) == "Checked")
                return true;
            if ((contractType == "TIME & MATERIAL" ||
                contractType == "GUARANTEED MAXIMUM" ||
                contractType == "COST PLUS" ||
                contractType == "UNIT PRICE")
            && (trackChangeOrder == "Unchecked"))
                return true;
            else
                return false;
        }
        //
        private bool IsTM(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            string contractType = "";
            string trackChangeOrder = "";
            GridView View = sender as GridView;

            contractType = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Contract Type"]);
            trackChangeOrder = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TrackChangeOrder"]);
            if (View.GetRowCellDisplayText(e.RowHandle, View.Columns["Dashboard"]) == "Checked")
                return true;
            if ((contractType == "TIME & MATERIAL" ||
                contractType == "GUARANTEED MAXIMUM" ||
                contractType == "COST PLUS" ||
                contractType == "UNIT PRICE")
            && (trackChangeOrder == "Unchecked"))
                return true;
            else
                return false;
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
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "JobDashboardList", configuration);
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
                        string fileName = "JobDashboardListAdHoc.xls";
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
                    Security.Security.UserID.ToString(), "JobDashboardList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdJobListView.RestoreLayoutFromStream(stream);
                grdJobListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdJobListView.CustomizationForm != null)
                    grdJobListView.CustomizationForm.Close();
                //FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdJobListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuJobList.ShowPopup(ctlJobDashboard.MousePosition);
        }
        //
        private void grdJobListView_DragObjectStart(object sender, DevExpress.XtraGrid.Views.Base.DragObjectStartEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn col = (DevExpress.XtraGrid.Columns.GridColumn)e.DragObject;
            switch (col.FieldName)
            {
                case "Dashboard":
                case "RecordNo":
                case "TrackChangeOrder":
                case "Job No":
                case "Contract Type":
                case "Job Name":
                    e.Allow = false;
                    break;
                default:
                    break;
            }
        }
        //
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
                jobList.DefaultView.Sort = command;
            }
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
                jobList.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
            }
            catch
            {
            }
        }

        private void grdJobListView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //if (e.MenuType == GridMenuType.Column)
            //{
            //    // Customize  
            //    DXMenuItem miCustomize = GetItemByStringId(e.Menu, GridStringId.MenuColumnColumnCustomization);
            //    if (miCustomize != null)
            //        miCustomize.Visible = false;

            //    // Group By This Column  
            //    DXMenuItem miGroup = GetItemByStringId(e.Menu, GridStringId.MenuColumnGroup);
            //    if (miGroup != null)
            //        miGroup.Enabled = false;
            //}
        }
    }
}
