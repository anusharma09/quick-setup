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

namespace CCEJobs.Controls
{
    public enum FieldOperationListView
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
    public partial class ctlFieldOperationList : UserControl
    {
        private BindingSource operationSourceBinding = new BindingSource();
        private DataTable OperationTable;
        private static string queryCondition = "";
        private string reportFilter = "";
        private string reportSort = "";
        private bool initialScreen = true;
        private bool IsNewEmployee = false;
        public ctlFieldOperationList ()
        {
            InitializeComponent();
            queryCondition = "Where a.EmployeeID = 0";
            GetOperationFieldList(" Where a.EmployeeID = 0 ");
            initialScreen = false;
        }
        //
        private void grdFieldOperationList_DoubleClick ( object sender, EventArgs e)
        {
            DataRow r;
            r = grdFieldOperationListView.GetDataRow(grdFieldOperationListView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmEmployee f = new frmEmployee(r[0].ToString(), operationSourceBinding, false);
            f.ShowDialog();
            GetOperationFieldList(queryCondition);
        }
        //
        private void ctlFieldOperationList_Load ( object sender, EventArgs e)
        {
            if (Security.Security.UserJCCAccess != Security.Security.Access.ApplicationAdministrator) 
            {
                if ((Security.Security.UserJCCFieldOperationLevel != Security.Security.AccessLevel.ReadWriteCreate
                && Security.Security.UserJCCFieldOperationLevel != Security.Security.AccessLevel.RedWriteCreateSB))
                {
                    panelControl1.Visible = false;
                    btnAddNewJob.Visible = false;
                }
                else
                {
                    panelControl1.Visible = true;
                    btnAddNewJob.Visible = true;
                }
            }
            else
            {
                panelControl1.Visible = true;
                btnAddNewJob.Visible = true;
            }

            cboEmployeeStatus.Properties.DataSource = StaticTables.EmployeeStatus;
            cboEmployeeStatus.Properties.DisplayMember = "EmployeeStatus";
            cboEmployeeStatus.Properties.ValueMember = "EmployeeStatusID";
            cboEmployeeStatus.Properties.PopulateColumns();
            cboEmployeeStatus.Properties.ShowHeader = false;
            cboEmployeeStatus.Properties.Columns[0].Visible = false;

            cboApprenticeshipStatus.Properties.DataSource = StaticTables.EmployeeStatus;
            cboApprenticeshipStatus.Properties.DisplayMember = "EmployeeStatus";
            cboApprenticeshipStatus.Properties.ValueMember = "EmployeeStatusID";
            cboApprenticeshipStatus.Properties.PopulateColumns();
            cboApprenticeshipStatus.Properties.ShowHeader = false;
            cboApprenticeshipStatus.Properties.Columns[0].Visible = false;

            cboInjuryType.Properties.DataSource = StaticTables.InjuryType;
            cboInjuryType.Properties.DisplayMember = "Type";
            cboInjuryType.Properties.ValueMember = "ID";
            cboInjuryType.Properties.PopulateColumns();
            cboInjuryType.Properties.ShowHeader = false;
            cboInjuryType.Properties.Columns[0].Visible = false;
        }
        public void GetOperationFieldList(string where)
        {
            if (! initialScreen)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("", "");
            try
            {

                OperationTable = FieldOperation.getOperationFieldList(where).Tables[0];
                operationSourceBinding.DataSource = OperationTable.DefaultView;
                grdFieldOperationList.DataSource = operationSourceBinding;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

            finally
            {
                grdFieldOperationList.MainView.PopulateColumns();
                grdFieldOperationListView.Columns[0].Visible = false;
                lblCount.Text = Convert.ToString(OperationTable.Rows.Count);
                RestoreCustomization();
                if (!initialScreen)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    if (OperationTable.Rows.Count == 0)
                    {
                        if (!IsNewEmployee)
                            MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                    }
                    
                }
            }
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {   //
            // Process The List
            //   
          string query = " WHERE ";
            if (cboEmployeeStatus.Text.Trim().Length > 0)
            {
                if (cboEmployeeStatus.Text.Trim().ToString().ToUpper()=="YES")
                    query += " a.IsEmployeeActive = 1 AND ";
                if (cboEmployeeStatus.Text.Trim().ToString().ToUpper() == "NO")
                    query += " a.IsEmployeeActive = 0 AND ";
            }
            if (cboApprenticeshipStatus.Text.Trim().Length > 0)
            {
                if (cboApprenticeshipStatus.Text.Trim().ToString().ToUpper() == "YES")
                    query += " a.ApprenticeshipCompleted = 1 AND ";
                if (cboApprenticeshipStatus.Text.Trim().ToString().ToUpper() == "NO")
                    query += " a.ApprenticeshipCompleted = 0 AND ";
            }

            if (!String.IsNullOrEmpty(txtEmployeeNumber.Text))
                query += " a.DynaEmployeeNumber like '%" + txtEmployeeNumber.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtSSN.Text))
                query += " a.SocialSecurityNumber like '%" + txtSSN.Text.Trim().Replace("'", "''") + "' AND ";
            if (!String.IsNullOrEmpty(txtFirstName.Text))
                query += " a.FirstName like '%" + txtFirstName.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtLastName.Text))
                query += " a.LastName like '%" + txtLastName.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtNickName.Text))
                query += " a.NickName like '%" + txtNickName.Text.Trim().Replace("'", "''") + "%' AND ";
            if (!String.IsNullOrEmpty(txtClassification.Text))
                query += " b.Classification like '%" + txtClassification.Text.Trim().Replace("'", "''") + "%' AND ";
            if (txtTerminateDateFrom.Text.Length > 0 && txtTerminateDateTo.Text.Length > 0)
                query += " (c.TerminationDate BETWEEN '" + txtTerminateDateFrom.Text + "' AND '" + txtTerminateDateTo.Text + "') AND ";
            else
            {
                if (txtTerminateDateFrom.Text.Length > 0)
                    query += " c.TerminationDate = '" + txtTerminateDateFrom.Text + "' AND ";
                if (txtTerminateDateTo.Text.Length > 0)
                    query += " c.TerminationDate = '" + txtTerminateDateTo.Text + "' AND ";
            }
            // HireDate
            if (txtHireDateFrom.Text.Length > 0 && txtHireDateTo.Text.Length > 0)
                query += " (a.HireDate BETWEEN '" + txtHireDateFrom.Text + "' AND '" + txtHireDateTo.Text + "') AND ";
            else
            {
                if (txtHireDateFrom.Text.Length > 0)
                    query += " a.HireDate = '" + txtHireDateFrom.Text + "' AND ";
                if (txtHireDateTo.Text.Length > 0)
                    query += " a.HireDate = '" + txtHireDateTo.Text + "' AND ";
            }
            // ClassificationDate
            if (txtClassificationDateFrom.Text.Length > 0 && txtClassificationDateTo.Text.Length > 0)
                query += " (b.ClassificationDate BETWEEN '" + txtClassificationDateFrom.Text + "' AND '" + txtClassificationDateTo.Text + "') AND ";
            else
            {
                if (txtClassificationDateFrom.Text.Length > 0)
                    query += " b.ClassificationDate = '" + txtClassificationDateFrom.Text + "' AND ";
                if (txtClassificationDateTo.Text.Length > 0)
                    query += " b.ClassificationDate = '" + txtClassificationDateTo.Text + "' AND ";
            }
            // Injury Date
            if (txtInjuryFrom.Text.Length > 0 && txtInjuryTo.Text.Length > 0)
                query += " (d.InjuryDate BETWEEN '" + txtInjuryFrom.Text + "' AND '" + txtInjuryTo.Text + "') AND ";
            else
            {
                if (txtInjuryFrom.Text.Length > 0)
                    query += " d.InjuryDate = '" + txtInjuryFrom.Text + "' AND ";
                if (txtInjuryTo.Text.Length > 0)
                    query += " d.InjuryDate = '" + txtInjuryTo.Text + "' AND ";
            }
            if (cboInjuryType.Text.Trim().Length > 0)
            {
                if (cboInjuryType.Text.Trim() != "None")
                    query += " d.InjuryType = '" + cboInjuryType.Text.Trim() + "' AND ";
            }
            if (txtBadge.Text.Trim().Length > 0)
            {
                query += " e.BadgeType like '%" + txtBadge.Text.Trim() + "%' AND ";
            }
            if (query.Length == 7)
                query = "";
            else
                query = query.Remove(query.Length - 4, 4);
            queryCondition = query;
            GetOperationFieldList(query);
        }

        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeNumber.Text = String.Empty;
            txtSSN.Text = String.Empty;
            this.txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtNickName.Text = String.Empty;
            txtClassification.Text = String.Empty;
            txtTerminateDateFrom.Text = String.Empty;
            txtTerminateDateTo.Text = String.Empty;
            txtHireDateFrom.Text = String.Empty;
            txtHireDateTo.Text = String.Empty;
            txtClassificationDateFrom.Text = String.Empty;
            txtClassificationDateTo.Text = String.Empty;
            cboApprenticeshipStatus.EditValue = null;
            cboEmployeeStatus.EditValue = null;
            txtBadge.Text = String.Empty;
            cboInjuryType.EditValue = null;
            txtInjuryFrom.Text = String.Empty;
            txtInjuryTo.Text = String.Empty;
            btnClear.Visible = false;
        }
       
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
           //frmJob job = new frmJob("0", jobSourceBinding, Security.Security.JobCaller.JCCJob);
           // job.ShowDialog();
        }
       
        private void dockManager1_StartDocking(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }
        //
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
   
            DataRow row = grdFieldOperationListView.GetDataRow(e.RowHandle);
           // Job.UpdateAdjustmentPercent(row[0].ToString(), row["AdjustmentPercent"].ToString());
           
        }
      
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "btnSaveYourCustomization":
                    try
                    {
                        System.IO.Stream stream = new System.IO.MemoryStream();
                        grdFieldOperationListView.SaveLayoutToStream(stream);
                        stream.Seek(0, System.IO.SeekOrigin.Begin);
                        System.IO.StreamReader read = new System.IO.StreamReader(stream);
                        string configuration = read.ReadToEnd().Replace("'", "''");

                        Security.BusinessLayer.UserConfiguration config =
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "MainJobList", configuration);
                        config.Save();
                        grdFieldOperationListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdFieldOperationListView.CustomizationForm != null)
                            grdFieldOperationListView.CustomizationForm.Close();
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
                        if (grdFieldOperationListView.CustomizationForm != null)
                        {
                            grdFieldOperationListView.CustomizationForm.Enabled = false;
                            grdFieldOperationListView.OptionsCustomization.AllowColumnMoving = false;
                            grdFieldOperationListView.CustomizationForm.Controls.Clear();
                            grdFieldOperationListView.CustomizationForm.Close();
                        }
                        grdFieldOperationList.Refresh();
                        grdFieldOperationListView.PopulateColumns();
                        grdFieldOperationListView.OptionsCustomization.AllowColumnMoving = false;
                        if (grdFieldOperationListView.CustomizationForm != null)
                            grdFieldOperationListView.CustomizationForm.Close();
                    }
                    catch (Exception ex) { }
                    break;
                case "btnCustomization":
                    grdFieldOperationListView.OptionsCustomization.AllowColumnMoving = true;
                    grdFieldOperationListView.ColumnsCustomization();
                    break;
                case "btnExportToExcel":
                    try
                    {
                        if (grdFieldOperationListView.RowCount == 0)
                            return;
                        string fileName = "EmployeeList.xls";
                        Exception ex;
                        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("Temp");
                        string tempLocation = Environment.CurrentDirectory;

                        if (File.Exists(tempLocation + "\\" + fileName))
                            File.Delete(tempLocation + "\\" + fileName);
                        //
                        DevExpress.XtraPrinting.XlsExportOptions option = new DevExpress.XtraPrinting.XlsExportOptions();
                        grdFieldOperationListView.ExportToXls(tempLocation + "\\" + fileName, option);
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
                grdFieldOperationListView.RestoreLayoutFromStream(stream);
                grdFieldOperationListView.OptionsCustomization.AllowColumnMoving = false;

                if (grdFieldOperationListView.CustomizationForm != null)
                    grdFieldOperationListView.CustomizationForm.Close();
               // FormatGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
            }
        }
        //
        //
        private void grdFieldOperationListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuMenuJobList.ShowPopup(ctlJobList.MousePosition);
        }

        private void grdFieldOperationListView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                string filter = grdFieldOperationListView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdFieldOperationListView.Columns)
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
                OperationTable.DefaultView.RowFilter = criteria;
                reportFilter = criteria;
            }
            catch
            {
            }
            
        }

        private void grdFieldOperationListView_MouseUp(object sender, MouseEventArgs e)
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
                OperationTable.DefaultView.Sort = command;
            }
        }

        private void btnAddNewJob_MouseClick(object sender, MouseEventArgs e)
        {
            FieldOperation fieldOperation = new FieldOperation();
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("Please wait", "Employees getting imported ...");
                    fieldOperation.Import(@openFile.FileName,CCEApplication.ProfilePicLocation,CCEApplication.LogFile, CCEApplication.DestinationPicLocation);
                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
                    MessageBox.Show("Employee(s) successfully imported.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }   
        }

        private void labelControl15_Click ( object sender, EventArgs e )
        {

        }

        private void hyperLinkEdit1_Click_1 ( object sender, EventArgs e )
        {
            IsNewEmployee = true;
            frmEmployee frm = new frmEmployee("0", operationSourceBinding, true);
            frm.ShowDialog();
            GetOperationFieldList(queryCondition);
            IsNewEmployee = false;
        }
    }
}
