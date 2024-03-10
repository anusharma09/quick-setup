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
    public partial class ctlJobCostAnalysisDashboard : UserControl
    {
        private BindingSource jobSourceBinding = new BindingSource();
        private frmJob job;
        private DataTable jobList;
        private string query = "";
        private string reportSort = "";
        private string reportFilter = "";
        private bool initialScreen = true;
        //
        public ctlJobCostAnalysisDashboard()
        {
            InitializeComponent();
            GetJobList(" WHERE j.JobNumber = '' ");
            initialScreen = false;
        }
        //
        private void ctlJobList_Load(object sender, EventArgs e)
        {
        }
        private void GetJobList(string query)
        {
            try
            {

                jobList = Job.GetJobCostListDashboard(query).Tables[0];
                jobSourceBinding.DataSource = jobList.DefaultView;
                grdJobList.DataSource = jobSourceBinding;
                grdJobList.MainView.PopulateColumns();
                RestoreCustomization();
                //FormatGrid();
                if (!initialScreen)
                {
                    if (jobList.Rows.Count == 0)
                        MessageBox.Show("Search process is completed with no result.", CCEApplication.ApplicationName, MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {   
            query = " WHERE ";

            if (radioJob.SelectedIndex == 0)
            {
                query += " LEN(JobNumber) = 4  AND ";
            }
            else
            {
                if (radioJob.SelectedIndex == 1)
                    query += " LEN(JobNumber) = 5 AND ";
            }

            if (radioStatus.SelectedIndex == 0)
            {
                query += " Archived = 0  AND ";
            }
            else
            {
                if (radioStatus.SelectedIndex == 1)
                    query += " Archived = 1 AND ";
            }
        

            query += " ([dbo].[GetUserJobCostAccess](j.JobNumber, '" + Security.Security.LoginID + "')  = 1)  ";

            GetJobList(query);
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
                            new Security.BusinessLayer.UserConfiguration(Security.Security.UserID.ToString(), "JobCostAnalysisList", configuration);
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
                        string fileName = "JobCostAnalysisListAdHoc.xls";
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
                    Security.Security.UserID.ToString(), "JobCostAnalysisList");
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
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                mnuJobCostAnalysis.ShowPopup( ctlJobCostAnalysisDashboard.MousePosition);
            
        }
        private void FormatGrid()
        {
            grdJobListView.Columns["JobNumber"].Caption = "Job #";
            grdJobListView.Columns["JobName"].Caption = "Job Name";
            grdJobListView.Columns["JobNumber"].Caption = "Job #";
            grdJobListView.Columns["OriginalContractAmount"].Caption = "Original Contract";
            grdJobListView.Columns["CommittedCostToDate"].Caption = "Actual Cost";
            grdJobListView.Columns["AmountBilled"].Caption = "Amount Billed";
            grdJobListView.Columns["Archived"].Caption = "Closed";
            grdJobListView.Columns["OriginalContractAmount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["CommittedCostToDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["AmountBilled"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grdJobListView.Columns["OriginalContractAmount"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["CommittedCostToDate"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["AmountBilled"].DisplayFormat.FormatString = "{0:c0}";
            grdJobListView.Columns["OriginalContractAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["OriginalContractAmount"].SummaryItem.DisplayFormat = "{0:c2}";
            grdJobListView.Columns["CommittedCostToDate"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["CommittedCostToDate"].SummaryItem.DisplayFormat = "{0:c2}";
            grdJobListView.Columns["AmountBilled"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grdJobListView.Columns["AmountBilled"].SummaryItem.DisplayFormat = "{0:c2}";
            grdJobListView.Columns["JobNumber"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            grdJobListView.Columns["JobNumber"].SummaryItem.DisplayFormat = "Jobs Count: {0:n0}";
            grdJobListView.BestFitColumns();
        }
       //
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
        //
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
            }
            catch
            {
            }
        }
        //
        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.JobDashboardCost(reportSort, reportFilter, jobList, radioReport.SelectedIndex);
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

                if (job != null)
                {
                    job.Close();
                    job.Dispose();
                }
                job = new frmJob(dataRow[0].ToString(), jobSourceBinding, Security.Security.JobCaller.JCCDashboard, true);
                job.Show();
            }
        }
    }
}
