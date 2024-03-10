using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CCEOTProjects.BusinessLayer;
using CCEOTProjects.PresentationLayer;
namespace CCEOTProjects.Controls
{
    public enum ProjectListView
    {
        ProjectStatus,
        WorkType,
        Office,
        Department,
        List
    }
    //
    public partial class ctlOTProjectList : UserControl
    {
        private BindingSource projectSourceBinding = new BindingSource();
        private ProjectListView projectListView = ProjectListView.List;
        private DataTable projectTable;
        string queryCondition;
        private bool isAdHoc = false;
        private bool isAdHoc1 = false;
        string projectID = "0";
        bool bBinnd = false;
        private string reportFilter = "";
        private string reportSort = "";
        frmProjectOpportunity project;
        private bool initialScreen = true;
        public ctlOTProjectList()
        {
            InitializeComponent();
            GetProjectList(" Where OTProjectID = 0 ");
            initialScreen = false;
        }
        //
        private void grdJobList_DoubleClick(object sender, EventArgs e)
        {
            if (grdOpportunityListView.RowCount == 0)
                return;
            DataRow dataRow;
            dataRow =  this.grdOpportunityListView.GetDataRow(grdOpportunityListView.GetSelectedRows()[0]);
            if (!dataRow.IsNull(0))
            {
                if (project != null)
                {
                    project.Close();
                    project.Dispose();
                }
                project = new frmProjectOpportunity(dataRow[0].ToString(), projectSourceBinding);
                try
                {
                    project.Show();
                }
                catch (Exception ex) {
                   MessageBox.Show(ex.Message);
                }
            }
        }
        //
        private void ctlJobList_Load(object sender, EventArgs e)
        {
            try
            {
                if ((Security.Security.UserJCCProjectOpportunityAccessLevel != Security.Security.AccessLevel.ReadWriteCreate
                    && Security.Security.UserJCCProjectOpportunityAccessLevel != Security.Security.AccessLevel.RedWriteCreateSB))
                {
                    panelControl1.Visible = false;
                    btnAddNewOpportunity.Visible = false;
                }
                else
                {
                    panelControl1.Visible = true;
                    btnAddNewOpportunity.Visible = true;
                }
                cboDepartment.Properties.DataSource = StaticTables.Department;
                cboDepartment.Properties.DisplayMember = "Name";
                cboDepartment.Properties.ValueMember = "DepartmentID";
                cboDepartment.Properties.PopulateColumns();
                cboDepartment.Properties.ShowHeader = false;
                cboOffice.Properties.DataSource = StaticTables.Office;
                cboOffice.Properties.PopulateColumns();
                cboOffice.Properties.DisplayMember = "Name";
                cboOffice.Properties.ValueMember = "OfficeID";
                cboOffice.Properties.ShowHeader = false;
                foreach (DataRow r in StaticTables.OTStatus.Rows)
                    lstProjectStatus.Items.Add(r["OTStatusDescription"].ToString());

                //
                cboWorkType.Properties.DataSource = StaticTables.WorkType;
                cboWorkType.Properties.PopulateColumns();
                cboWorkType.Properties.DisplayMember = "Description";
                cboWorkType.Properties.ValueMember = "WorkTypeID";
                cboWorkType.Properties.ShowHeader = false;

                cboAssignedTo.Properties.DataSource = StaticTables.AssignedTo;
                cboAssignedTo.Properties.PopulateColumns();
                cboAssignedTo.Properties.DisplayMember = "UserName";
                cboAssignedTo.Properties.ValueMember = "UserLANID";
                cboAssignedTo.Properties.ShowHeader = false;

                cboAssignedFrom.Properties.DataSource = StaticTables.AssignedTo;
                cboAssignedFrom.Properties.PopulateColumns();
                cboAssignedFrom.Properties.DisplayMember = "UserName";
                cboAssignedFrom.Properties.ValueMember = "UserLANID";
                cboAssignedFrom.Properties.ShowHeader = false;

                // Reports
                cboReport.Properties.Items.Add("Ad Hoc");
                cboReport.Properties.Items.Add("Opportunities Analysis");
                cboReport.Properties.Items.Add("Opportunity & Estimate Tracking");
                //cboReport.Properties.Items.Add("Estimate Hours Tracking");
                cboReport.Properties.Items.Add("Opportunity Estimate Job Statistics");
                //
                cboWorkType.Properties.Columns[0].Visible = false;
                cboDepartment.Properties.Columns[0].Visible = false;
                cboOffice.Properties.Columns[0].Visible = false;
                cboAssignedTo.Properties.Columns[0].Visible = false;
                cboAssignedFrom.Properties.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetProjectList(string where)
        {
            if (!initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");

            try
            {
                projectTable = OTProject.GetProjectList(where).Tables[0];
                projectSourceBinding.DataSource = projectTable.DefaultView;
                grdOpportunityList.DataSource = projectSourceBinding;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            finally
            {

                grdOpportunityList.MainView.PopulateColumns();
                grdOpportunityListView.Columns[0].Visible = false;
                RestoreCustomization();
                UpdateListView(projectListView);
                FormatGrid();
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (projectTable.Rows.Count == 0)
               
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }
            }
        }
        //
        private void FormatGrid()
        {
            grdOpportunityListView.Columns["Project $"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOpportunityListView.Columns["Project $"].DisplayFormat.FormatString = "{0:c2}";
            grdOpportunityListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Project $", grdOpportunityListView.Columns["Project $"], "{0:c2}");
            grdOpportunityListView.Columns["Project $"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdOpportunityListView.Columns["Project $"].SummaryItem.DisplayFormat = "{0:c2}";
            grdOpportunityListView.Columns["Electrical $"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdOpportunityListView.Columns["Electrical $"].DisplayFormat.FormatString = "{0:c2}";
            grdOpportunityListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Electrical $", grdOpportunityListView.Columns["Electrical $"], "{0:c2}");
            grdOpportunityListView.Columns["Electrical $"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdOpportunityListView.Columns["Electrical $"].SummaryItem.DisplayFormat = "{0:c2}";
            grdOpportunityListView.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "Project #", grdOpportunityListView.Columns["Project #"], "Count: {0:n0}");
            grdOpportunityListView.Columns["Project #"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdOpportunityListView.Columns["Project #"].SummaryItem.DisplayFormat = "Count: {0:n0}";
            grdOpportunityListView.Columns["OTProjectID"].Visible = false;
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string query = " WHERE ";
                if (!String.IsNullOrEmpty(txtEstimateNumber.Text))
                    query += " EstimateNumber like '" + txtEstimateNumber.Text.Trim().Replace("'", "''") + "%' AND ";
                if (!String.IsNullOrEmpty(txtProjectNumber.Text))
                    query += " OTProjectNumber like '" + txtProjectNumber.Text.Trim().Replace("'", "''") + "%' AND ";
                if (!String.IsNullOrEmpty(txtProjectName.Text))
                    query += " OTProjectName like '" + txtProjectName.Text.Trim().Replace("'", "''") + "%' AND ";
                if (lstProjectStatus.CheckedItems.Count > 0)
                {
                    query += " s.OTStatusDescription IN(";
                    foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstProjectStatus.Items)
                    {
                        if (item.CheckState == CheckState.Checked)
                            query += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";
                    }
                    query = query.Remove(query.Length - 1, 1) + ") AND ";
                }
                if (lstPrequalRequired.CheckedItems.Count > 0)
                {
                    query += " p.PrequalRequired IN(";
                    foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstPrequalRequired.Items)
                    {
                        if (item.CheckState == CheckState.Checked)
                            query += Convert.ToChar(39) + item.ToString() + Convert.ToChar(39) + ",";
                    }
                    query = query.Remove(query.Length - 1, 1) + ") AND ";
                }
                if (cboWorkType.Text.Trim().Length > 0)
                    query += " p.WorkTypeID = " + cboWorkType.EditValue.ToString() + " AND ";
                if (cboOffice.Text.Trim().Length > 0)
                    query += " p.OfficeID = " + cboOffice.EditValue.ToString() + " AND ";
                if (cboDepartment.Text.Trim().Length > 0)
                    query += " p.DepartmentID = " + cboDepartment.EditValue.ToString() + " AND ";
                //if (cboAssignedTo.Text.Trim().Length > 0)
                //    query += " p.AssignedTo  =  '" + cboAssignedTo.EditValue.ToString() + "' AND ";
                if (cboAssignedTo.Text.Trim().Length > 0)
                    query += " [dbo].[GetAssignmentsTo] (p.OTProjectID, '" + cboAssignedTo.EditValue.ToString() + "') = 1 AND ";

                if (cboAssignedFrom.Text.Trim().Length > 0)
                    query += " [dbo].[GetAssignmentsFrom] (p.OTProjectID, '" + cboAssignedFrom.EditValue.ToString() + "') = 1 AND ";

                // Bid Date
                if (txtBidDateFrom.Text.Length > 0 && txtBidDateTo.Text.Length > 0)
                    query += " (p.BidDate BETWEEN '" + txtBidDateFrom.Text + "' AND '" + txtBidDateTo.Text + "') AND ";
                else
                {
                    if (txtBidDateFrom.Text.Length > 0)
                        query += " p.BidDate = '" + txtBidDateFrom.Text + "' AND ";
                    if (txtBidDateTo.Text.Length > 0)
                        query += " p.BidDate = '" + txtBidDateTo.Text + "' AND ";
                }
                // Status Date
                if (txtStatusDateFrom.Text.Length > 0 && txtStatusDateTo.Text.Length > 0)
                    query += " (p.StatusDate BETWEEN '" + txtStatusDateFrom.Text + "' AND '" + txtStatusDateTo.Text + "') AND ";
                else
                {
                    if (txtStatusDateFrom.Text.Length > 0)
                        query += " p.StatusDate = '" + txtStatusDateFrom.Text + "' AND ";
                    if (txtStatusDateTo.Text.Length > 0)
                        query += " p.StatusDate = '" + txtStatusDateTo.Text + "' AND ";
                }
                // Prequal Date
                if (txtPrequalDateFrom.Text.Length > 0 && txtPrequalDateTo.Text.Length > 0)
                    query += " (p.PrequalDate BETWEEN '" + txtPrequalDateFrom.Text + "' AND '" + txtPrequalDateTo.Text + "') AND ";
                else
                {
                    if (txtPrequalDateFrom.Text.Length > 0)
                        query += " p.PrequalDate = '" + txtPrequalDateFrom.Text + "' AND ";
                    if (txtPrequalDateTo.Text.Length > 0)
                        query += " p.PrequalDate = '" + txtPrequalDateTo.Text + "' AND ";
                }
                // Next Action Date
                if (txtNextActionFrom.Text.Length > 0 && txtNextActionTo.Text.Length > 0)
                    query += " (p.NextActionDateAuto BETWEEN '" + txtNextActionFrom.Text + "' AND '" + txtNextActionTo.Text + "') AND ";
                else
                {
                    if (txtNextActionFrom.Text.Length > 0)
                        query += " p.NextActionDateAuto = '" + txtNextActionFrom.Text + "' AND ";
                    if (txtNextActionTo.Text.Length > 0)
                        query += " p.NextActionDateAuto = '" + txtNextActionTo.Text + "' AND ";
                }
                if (radioApproved.SelectedIndex == 0)
                    query += " p.Approved = 1  AND ";

                if (radioApproved.SelectedIndex == 1)
                    query += " p.Approved <> 1  AND ";

                if (radioForwardForApproval.SelectedIndex == 0)
                    query += " p.ForwardForApproval = 1  AND ";

                if (radioForwardForApproval.SelectedIndex == 1)
                    query += " p.ForwardForApproval <> 1  AND ";
                if (chkNeedCEOApproval.CheckState == CheckState.Checked)
                    query += " (p.ForwardForApproval = 1 AND p.PApproved <> 1 AND ElectricalDollar >= 5000000) AND ";
                if (chkNeedDMApproval.CheckState == CheckState.Checked)
                    query += " (p.ForwardForApproval = 1 AND p.Approved <> 1) AND ";
                if (chkOpenItems.CheckState == CheckState.Checked)
                    query += " (p.OTProjectStatusID IN (3,4,5,6) ) AND ";        
                query += " [dbo].[GetUserProjectOpportunityAccess](p.OTProjectID,'" + Security.Security.LoginID.ToUpper() + "')  = 1 AND ";

                if (query.Length == 7)
                    query = "";
                else
                    query = query.Remove(query.Length - 4, 4);
                queryCondition = query;
                GetProjectList(query);
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(projectTable, projectListView, queryCondition, reportFilter, reportSort));
                }
                else
                {
                    if (isAdHoc1)
                    {
                        panReportParamters.Controls.Clear();
                        panReportParamters.Controls.Add(new ctlAdHocAnalysisReport(queryCondition));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
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
            txtProjectNumber.Text = String.Empty;
            this.txtProjectName.Text = String.Empty;
            cboOffice.EditValue = null;
            cboDepartment.EditValue = null;
            cboAssignedTo.EditValue = null;
            cboAssignedFrom.EditValue = null;
            cboWorkType.EditValue = null;
            txtBidDateFrom.Text = String.Empty;
            txtBidDateTo.Text = String.Empty;
            txtNextActionFrom.Text = String.Empty;
            txtNextActionTo.Text = String.Empty;
            txtStatusDateFrom.Text = String.Empty;
            txtStatusDateTo.Text = String.Empty;
            txtPrequalDateFrom.Text = String.Empty;
            txtPrequalDateTo.Text = String.Empty;

            if (lstProjectStatus.CheckedItems.Count > 0)
            {
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstProjectStatus.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                        item.CheckState = CheckState.Unchecked;
                }
            }

            if (lstPrequalRequired.CheckedItems.Count > 0)
            {
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstPrequalRequired.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                        item.CheckState = CheckState.Unchecked;
                }
            }
            chkOpenItems.CheckState = CheckState.Checked;
            radioForwardForApproval.SelectedIndex = 2;
            radioApproved.SelectedIndex = 2;
            chkNeedCEOApproval.Checked = false;
            chkNeedDMApproval.Checked = false;
            btnClear.Visible = false;
            txtEstimateNumber.Focus();
        }
        //
        public void UpdateListView( ProjectListView projectView)
        {
            projectListView = projectView;
            if (grdOpportunityListView.Columns["Status"].GroupIndex > -1)
                grdOpportunityListView.Columns["Status"].UnGroup();
            if (grdOpportunityListView.Columns["Department"].GroupIndex > -1)
                grdOpportunityListView.Columns["Department"].UnGroup();
            if (grdOpportunityListView.Columns["Office"].GroupIndex > -1)
                grdOpportunityListView.Columns["Office"].UnGroup();
            if (grdOpportunityListView.Columns["Work Type"].GroupIndex > -1)
                grdOpportunityListView.Columns["Work Type"].UnGroup();
            //if (grdOpportunityListView.Columns["Assigned To"].GroupIndex > -1)
            //    grdOpportunityListView.Columns["Assigned To"].UnGroup();

            switch (projectListView)
            {
                case ProjectListView.WorkType:
                    grdOpportunityListView.Columns["Work Type"].Group();
                    break;
                case ProjectListView.Department:
                    grdOpportunityListView.Columns["Department"].Group();
                    break;
                case ProjectListView.ProjectStatus:
                    grdOpportunityListView.Columns["Status"].Group();
                    break;
                case ProjectListView.Office:
                    grdOpportunityListView.Columns["Office"].Group();
                    break;
              //  case ProjectListView.AssignedTo:
              //      grdOpportunityListView.Columns["Assigned To"].Group();
              //      break;
            }
            if (isAdHoc)
            {
                panReportParamters.Controls.Clear();
                panReportParamters.Controls.Add(new ctlAdHocReport(projectTable, projectListView, queryCondition, reportFilter, reportSort));
            }
            else
            {
                if (isAdHoc1)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocAnalysisReport(queryCondition));
                }
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmProjectOpportunity project = new frmProjectOpportunity("0", projectSourceBinding);
            project.ShowDialog();
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
                    isAdHoc1 = false;
                    panReportParamters.Controls.Add(new ctlAdHocReport(projectTable, projectListView, queryCondition, reportFilter, reportSort));
                    break;
                case "Opportunities Analysis":
                    isAdHoc = false;
                    isAdHoc1 = true;
                    panReportParamters.Controls.Add(new ctlAdHocAnalysisReport(queryCondition));
                    break;
                case "Opportunity & Estimate Tracking":
                    isAdHoc = false;
                    isAdHoc1 = false;
                    panReportParamters.Controls.Add(new ctlOpportunityEstimateTrackingReport());
                    break;
             /*   case "Estimate Hours Tracking":
                    isAdHoc = false;
                    isAdHoc1 = false;
                    panReportParamters.Controls.Add(new ctlOpportunityEstimateHoursReport());
                    break;*/
                case "Opportunity Estimate Job Statistics":
                    isAdHoc = false;
                    isAdHoc1 = false;
                    panReportParamters.Controls.Add(new ctlOpportunityEstimateJobStatisticsReport());
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
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdOpportunityListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "ProjectOpportunitiesList", configuration);
                        config.Save();
                        grdOpportunityListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdOpportunityListView.CustomizationForm != null)
                            grdOpportunityListView.CustomizationForm.Close();
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
                        if (grdOpportunityListView.CustomizationForm != null)
                        {
                            grdOpportunityListView.CustomizationForm.Enabled = false;
                            grdOpportunityListView.OptionsCustomization.AllowColumnMoving = false;
                            grdOpportunityListView.CustomizationForm.Controls.Clear();
                            grdOpportunityListView.CustomizationForm.Close();
                        }
                        grdOpportunityList.Refresh();
                        grdOpportunityListView.PopulateColumns();
                        grdOpportunityListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdOpportunityListView.CustomizationForm != null)
                            grdOpportunityListView.CustomizationForm.Close();
                        FormatGrid();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdOpportunityListView.OptionsCustomization.AllowColumnMoving = true;
                    grdOpportunityListView.ColumnsCustomization();
                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdOpportunityListView.RowCount == 0)
                            return;
                        string fileName = "ProjectOpportunitiesList.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
                        grdOpportunityListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
                    Security.Security.UserID.ToString(), "ProjectOpportunitiesList");
                if (configuration.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(configuration);
                MemoryStream stream = new MemoryStream(byteArray);
                grdOpportunityListView.RestoreLayoutFromStream(stream);
                grdOpportunityListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdOpportunityListView.CustomizationForm != null)
                    grdOpportunityListView.CustomizationForm.Close();
                //FormatGrid();
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

            switch (col.FieldName)
            {
                case "OTProjectID":
                    e.Allow = false;
                    break;
                default:
                    break;
            }
        }
        //
        private void grdJobListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuJobList.ShowPopup(ctlOTProjectList.MousePosition);
        }
        //
        private void grdJobListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdOpportunityListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdOpportunityListView.Columns)
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
                projectTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
                if (isAdHoc)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocReport(projectTable, projectListView, queryCondition, reportFilter, reportSort));
                }
                else
                {
                    if (isAdHoc1)
                    {
                        panReportParamters.Controls.Clear();
                        panReportParamters.Controls.Add(new ctlAdHocAnalysisReport(queryCondition));
                    }
                }

            }
            catch
            {
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
                projectTable.DefaultView.Sort = command;
            }
            if (isAdHoc)
            {
                panReportParamters.Controls.Clear();
                panReportParamters.Controls.Add(new ctlAdHocReport(projectTable, projectListView, queryCondition, reportFilter, reportSort));
            }
            else
            {
                if (isAdHoc1)
                {
                    panReportParamters.Controls.Clear();
                    panReportParamters.Controls.Add(new ctlAdHocAnalysisReport(queryCondition));
                }
            }
        }
        //
        private void cboWorkType_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                e.Handled = true;
                cboWorkType.EditValue = String.Empty;
            }
        }
        //
        private void lstProjectStatus_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void chkOpenItems_EditValueChanged(object sender, EventArgs e)
        {
            if (chkOpenItems.CheckState != CheckState.Checked)
                AllItems_EditValueChanged(sender, e);
        }

        private void lstPrequalRequired_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }  
    }
}
