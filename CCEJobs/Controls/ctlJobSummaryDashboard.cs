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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace CCEJobs.Controls
{
    public enum JobSummaryDashboardView
    {
        Office,
        Department,
        ProjectManager,
        Job,
        List
    }
    //
    public partial class ctlJobSummaryDashboard : UserControl
    {
        private BindingSource jobSourceBinding = new BindingSource();
        private JobSummaryDashboardView jobListView = JobSummaryDashboardView.List;
        private DataTable jobList;
        private string reportQuery;
        private string query = "";
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;

        public ctlJobSummaryDashboard()
        {
            InitializeComponent();

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
        }
        //
        private void ctlJobList_Load(object sender, EventArgs e)
        {
            cboContractType.Properties.DataSource = StaticTables.ContractType;
            cboContractType.Properties.DisplayMember = "Description";
            cboContractType.Properties.ValueMember = "ContractTypeID";
            cboContractType.Properties.PopulateColumns();
            cboContractType.Properties.ShowHeader = false;

            cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
            cboProjectManager.Properties.DisplayMember = "Description";
            cboProjectManager.Properties.ValueMember = "ProjectManagerID";
            cboProjectManager.Properties.PopulateColumns();
            cboProjectManager.Properties.ShowHeader = false;

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
  
            cboProjectManager.Properties.Columns[0].Visible = false;
            cboDepartment.Properties.Columns[0].Visible = false;
            cboOffice.Properties.Columns[0].Visible = false;
            cboContractType.Properties.Columns[0].Visible = false;

        }
        private void GetJobList(string query)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            try
            {
                jobList = Job.GetJobSummaryListDashboard(query).Tables[0];
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
                FormatGrid();
                RestoreGridCustomization();
                UpdatePivotTable();

                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (jobList.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {   
            query = "";
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
            if (cboProjectManager.Text.Trim().Length > 0)
            {
                query += " AND b.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " ";
                reportQuery += "Project Manager:  " + cboProjectManager.Text + "\n";
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
            if (txtCurrentAmountFrom.Text.Length > 0 && txtCurrentAmountTo.Text.Length > 0)
            {
                query += " AND (b.JobFinalContractAmount BETWEEN " + txtCurrentAmountFrom.Text.Replace("$","").Replace(",","") + " AND " + txtCurrentAmountTo.Text.Replace("$","").Replace(",","") + ") ";
                reportQuery += "Contract Amt.:  " + txtCurrentAmountFrom.Text + " and " + txtCurrentAmountTo.Text + "\n";
            }
            else
            {
                if (txtCurrentAmountFrom.Text.Length > 0)
                {
                    query += " AND ( b.JobFinalContractAmount >= " + txtCurrentAmountFrom.Text.Replace("$", "").Replace(",", "") + " ) ";
                    reportQuery += "Current Amt. >=:  " + txtCurrentAmountFrom.Text + "\n";
                }
                if (txtCurrentAmountTo.Text.Length > 0)
                {
                    query += " AND ( b.JobFinalContractAmount >=" + txtCurrentAmountTo.Text.Replace("$", "").Replace(",", "") + " ) ";
                    reportQuery += "Current Amt. >=  " + txtCurrentAmountTo.Text + "\n";
                }
            }
            query += " AND ([dbo].[GetUserJobAccessDashboard](b.JobID, '" + Security.Security.LoginID + "')  = 1)  ";

            GetJobList(query);
            UpdateView(jobListView);
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
            cboProjectManager.EditValue = null;
            cboContractType.EditValue = null;
            txtStartDateFrom.Text = String.Empty;
            txtStartDateTo.Text = String.Empty;
            txtCompDateFrom.Text = String.Empty;
            txtCompDateTo.Text = String.Empty;
            txtCurrentAmountFrom.EditValue = null;
            txtCurrentAmountTo.EditValue = null;
            txtCurrentAmountFrom.Text = null;
            txtCurrentAmountTo.Text = null;
            btnClear.Visible = false;
        }
     
     

   

        public void UpdateView(JobSummaryDashboardView jobListView)
        {
            this.jobListView = jobListView;
            if (grdJobListView.Columns["Department"].GroupIndex > -1)
                grdJobListView.Columns["Department"].UnGroup();
            if (grdJobListView.Columns["Office"].GroupIndex > -1)
                grdJobListView.Columns["Office"].UnGroup();
            if (grdJobListView.Columns["Project Manager"].GroupIndex > -1)
                grdJobListView.Columns["Project Manager"].UnGroup();
            if (grdJobListView.Columns["Job No"].GroupIndex > -1)
                grdJobListView.Columns["Job No"].UnGroup();
            grdJobListView.GroupSummary.Clear();
            switch (jobListView)
            {
                case JobSummaryDashboardView.Department:
                    grdJobListView.Columns["Department"].Group();
                    break;
                case JobSummaryDashboardView.Office:
                    grdJobListView.Columns["Office"].Group();
                    break;
                case JobSummaryDashboardView.ProjectManager:
                    grdJobListView.Columns["Project Manager"].Group();
                    break;
                case JobSummaryDashboardView.Job:
                    grdJobListView.Columns["Job No"].Group();
                    break;
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            Reports.JobSummaryDashboardSummary(chartOrganization, grdOrganization, reportQuery);
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
        private void btnRestoreYourCustomization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RestoreGridCustomization();
            UpdatePivotTable();
        }
        //
        private void btnResetColumns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grdJobListView.CustomizationForm != null)
                {
                    grdJobListView.CustomizationForm.Enabled = false;
                    grdJobListView.OptionsCustomization.AllowColumnMoving = false;
                    grdJobListView.CustomizationForm.Controls.Clear();
                    grdJobListView.CustomizationForm.Close();
                }
                // gridView1.Refresh();
                grdJobListView.PopulateColumns();
                FormatGrid();
                UpdatePivotTable();
            }
            catch (Exception ex) { }
        }
        //
        private void btnCustomization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grdJobListView.OptionsCustomization.AllowColumnMoving = true;
            grdJobListView.ColumnsCustomization();
            
        }
        //
        private void btnExportToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string fileName = "JobSummaryDashboard.xls";

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
        //
        private void RestoreGridCustomization()
        {
            string configuration = "";
            
            configuration = Security.BusinessLayer.UserConfiguration.GetConfiguration(
                Security.Security.UserID.ToString(), "JobSummaryDashboard");
            if (configuration.Trim().Length == 0)
                return;
            byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
            MemoryStream stream = new MemoryStream(byteArray);
            grdJobListView.RestoreLayoutFromStream(stream);
        }
        //
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuJobProgress.ShowPopup( ctlJobSummaryDashboard.MousePosition);
        }
        //
        private void FormatGrid()
        {
            grdJobListView.Columns["Original Contract"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Approved COs"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Pending With Proceed"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Pending No Proceed"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Current Contract"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            grdJobListView.Columns["Current Budget"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Original Budget"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Approved CO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Pending Proceed CO"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Actual To Date"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Open Commit"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Cost To Complete"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Variance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["WIP Month End CAC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Amount Billed"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Amount Paid"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Retention"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Cash/Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Billed/Cost"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Material PO Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Cost This Month"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Billing This Month"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Revised CAC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["Projected Profit"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            grdJobListView.Columns["Original Contract"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Approved COs"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Pending With Proceed"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Pending No Proceed"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Current Contract"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Current Budget"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Original Budget"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Approved CO"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Pending Proceed CO"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Actual To Date"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Open Commit"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Cost To Complete"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Variance"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["WIP Month End CAC"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Amount Billed"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Amount Paid"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Retention"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Cash/Cost"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Billed/Cost"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Material PO Total"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Cost This Month"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Billing This Month"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Revised CAC"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Projected Profit"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["Job Name"].VisibleIndex = 1;
            grdJobListView.Columns["Job No"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.Columns["Contract Type"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.Columns["Job Name"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.Columns["Period"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            grdJobListView.BestFitColumns();

        }
        //
        private void SaveConfiguration()
        {
            try
            {
                System.IO.Stream stream = new System.IO.MemoryStream();
                grdJobListView.SaveLayoutToStream(stream);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                System.IO.StreamReader read = new System.IO.StreamReader(stream);
                string configuration = read.ReadToEnd().Replace("'", "''");
                Security.BusinessLayer.UserConfiguration config =
                    new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "JobSummaryDashboard", configuration);
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void btnSaveYourCustomization_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveConfiguration();
        }

        private void gridView1_DragObjectStart(object sender, DragObjectStartEventArgs e)
        {
            DevExpress.XtraGrid.Columns.GridColumn col = (DevExpress.XtraGrid.Columns.GridColumn)e.DragObject;
            switch (col.FieldName)
            {
                case "Job No":
                case "Job Name":
                case "Contract Type":
                case "Period":
                    e.Allow = false;
                    break;
            }
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
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

        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
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
                UpdatePivotTable();
            }
            catch
            {
            }
        }
        //
        private void UpdatePivotTable()
        {
            grdOrganization.DataSource = jobList.DefaultView;
            grdOrganization.RetrieveFields();
            grdOrganization.Fields["Job No"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            grdOrganization.Fields["Period"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobListView.Columns)
            {
                switch (col.FieldName)
                {
                    case "Job No":
                    case "Contract Type":
                    case "Job Name":
                    case "Office":
                    case "Department":
                    case "Project Manager":
                        break;
                    case "Period":
                        grdOrganization.Fields[col.FieldName].ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        grdOrganization.Fields[col.FieldName].ValueFormat.FormatString = "MM/dd/yyyy";
                        break;
                    default:
                        //
                        // Conversion 2015
                        try
                        {
                            if (col.VisibleIndex != -1)
                            {
                                grdOrganization.Fields[col.FieldName].CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                                grdOrganization.Fields[col.FieldName].CellFormat.FormatString = "c0";
                                grdOrganization.Fields[col.FieldName].Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
                            }
                        }
                        catch (Exception ex) { }
                        break;

                }
            }
            grdOrganization.RefreshData();
            grdOrganization.BestFit();
            DevExpress.XtraCharts.Series mySeries = new DevExpress.XtraCharts.Series();
            mySeries = chartOrganization.Series[0];
        }
        //
        private void gridView1_DragObjectDrop(object sender, DragObjectDropEventArgs e)
        {
             UpdatePivotTable();
        }
    }
}
