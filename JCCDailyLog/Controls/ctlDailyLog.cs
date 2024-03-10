using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCDailyLog.BusinessLayer;
using JCCDailyLog.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace JCCDailyLog.Controls
{
 
    public partial class ctlDailyLog : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource dailyLogSourceBinding = new BindingSource();
        private DataTable dailyLogDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobDailyLogID;
        //
        public ctlDailyLog()
        {
            InitializeComponent();
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
                if (jobID == "")
                    jobID = "0";
                GetDailyLog();
                SetControlAccess();
            }
        }
        //
        public DataTable DailyLogDataTable
        {
            get
            {
                return dailyLogDataTable;
            }
        }
        //
        public String JobDailyLogID
        {
            get
            {
                return jobDailyLogID;
            }
        }
        //
        public int ReportType
        {
            get
            {
                return radioGroupType.SelectedIndex;
            }
        }
        //
        public String DailyLogSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String DailyLogFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetDailyLog()
        {
            GetJobDailyLog();
        }
        //
        private void GetJobDailyLog()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobDailyLogView, "ctlDailyLog");
                }


                dailyLogDataTable = DailyLog.GetJobDailyLog(jobID, radioGroupType.SelectedIndex).Tables[0];
                grdJobDailyLog.DataSource = null;
                grdJobDailyLogView.Columns.Clear();
                dailyLogSourceBinding.DataSource = dailyLogDataTable;
                grdJobDailyLog.DataSource = dailyLogSourceBinding;
                grdJobDailyLogView.Columns["JobDailyLogID"].Visible = false;
                // grdJobDailyLogView.Columns["JobID"].Visible = false;

                // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdJobDailyLogView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobDailyLogView, "ctlDailyLog");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void SetControlAccess()
        {

            if (jobCaller == Security.Security.JobCaller.JCCJob && Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                panDailyLogSecurity.Visible = true;
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panDailyLogSecurity.Visible = false;
                }
                else
                {
                    panDailyLogSecurity.Visible = true;
                }
            }
             
        }
        //
        private void grdDailyLogView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdJobDailyLogView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobDailyLogID = "";
                    return;
                }
                jobDailyLogID = r["JobDailyLogID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmDailyLog f = new frmDailyLog("0", jobID, dailyLogSourceBinding);
            f.ShowDialog();
            GetDailyLog();
        }
        //
        private void grdDailyLogView_DoubleClick(object sender, EventArgs e)
        {
            if (grdJobDailyLogView.IsEmpty)
                return;

            DataRow r;
            if (grdJobDailyLogView.IsEmpty)
                return;
            r = grdJobDailyLogView.GetDataRow(grdJobDailyLogView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmDailyLog f = new frmDailyLog(r["JobDailyLogID"].ToString(), jobID, dailyLogSourceBinding);
            f.ShowDialog();
           //     GetDailyLog();
        }
        //
        private void grdDailyLogView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdJobDailyLogView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobDailyLogView.Columns)
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
                dailyLogDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdDailyLogView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
               // ColumnSortOrder sort = info.Column.SortOrder;
                string command = info.Column.FieldName;
                if (info.Column.SortOrder == ColumnSortOrder.Ascending)
                {
                    command += " DESC";
                    sort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sort = info.Column.Caption + " ASC";
                }
                dailyLogDataTable.DefaultView.Sort = command;
            }
        }

        private void radioGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchDaily.Text = string.Empty;
            GetJobDailyLog();
        }

        private void grdJobDailyLogView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            if (radioGroupType.SelectedIndex != 0)
                bColumnWidthChanged = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {               

                dailyLogDataTable = DailyLog.GetJobDailyLog(jobID, radioGroupType.SelectedIndex, txtSearchDaily.Text.Trim()).Tables[0];
                grdJobDailyLog.DataSource = null;
                grdJobDailyLogView.Columns.Clear();
                dailyLogSourceBinding.DataSource = dailyLogDataTable;
                grdJobDailyLog.DataSource = dailyLogSourceBinding;
                grdJobDailyLogView.Columns["JobDailyLogID"].Visible = false;           
                grdJobDailyLogView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobDailyLogView, "ctlDailyLog");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
