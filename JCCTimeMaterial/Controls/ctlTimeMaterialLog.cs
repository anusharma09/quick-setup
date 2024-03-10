using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCTimeMaterial.BusinessLayer;
using JCCTimeMaterial.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace JCCTimeMaterial.Controls
{
 
    public partial class ctlTimeMaterialLog : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource timeMaterialLogSourceBinding = new BindingSource();
        private DataTable timeMaterialLogDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobTimeMaterialLogID;
        //
        public ctlTimeMaterialLog()
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
                GetTimeMaterialLog();
                SetControlAccess();
            }
        }
        //
        public DataTable TimeMaterialLogDataTable
        {
            get
            {
                return timeMaterialLogDataTable;
            }
        }
        //
        public String JobTimeMaterialLogID
        {
            get
            {
                return jobTimeMaterialLogID;
            }
        }
        //
        public String TimeMaterialLogSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String TimeMaterialLogFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetTimeMaterialLog()
        {
            GetJobTimeMaterialLog();
        }
        //
        private void GetJobTimeMaterialLog()
        {
            try
            {


                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobTimeMaterialLogView, "ctlTimeMaterialLog");
                }



                timeMaterialLogDataTable = TimeMaterialWorkOrder.GetJobTimeMaterialWorkOrderLog(jobID).Tables[0];
                timeMaterialLogSourceBinding.DataSource = timeMaterialLogDataTable;
                grdJobTimeMaterialLog.DataSource = timeMaterialLogSourceBinding;
                grdJobTimeMaterialLogView.Columns["JobTimeMaterialWorkOrderID"].Visible = false;
                grdJobTimeMaterialLogView.Columns["JobID"].Visible = false;
                grdJobTimeMaterialLogView.Columns["Hours S"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobTimeMaterialLogView.Columns["Hours S"].DisplayFormat.FormatString = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours D"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobTimeMaterialLogView.Columns["Hours D"].DisplayFormat.FormatString = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours P"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobTimeMaterialLogView.Columns["Hours P"].DisplayFormat.FormatString = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours O"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdJobTimeMaterialLogView.Columns["Hours O"].DisplayFormat.FormatString = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours S"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobTimeMaterialLogView.Columns["Hours S"].SummaryItem.DisplayFormat = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours D"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobTimeMaterialLogView.Columns["Hours D"].SummaryItem.DisplayFormat = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours P"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobTimeMaterialLogView.Columns["Hours P"].SummaryItem.DisplayFormat = "{0:n2}";

                grdJobTimeMaterialLogView.Columns["Hours O"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdJobTimeMaterialLogView.Columns["Hours O"].SummaryItem.DisplayFormat = "{0:n2}";

                grdJobTimeMaterialLogView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobTimeMaterialLogView, "ctlTimeMaterialLog");

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
                panTimeMaterialLog.Visible = true;
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panTimeMaterialLog.Visible = false;
                }
                else
                {
                    panTimeMaterialLog.Visible = true;
                }
            }
        }
        //
        private void grdTimeMaterialLogView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdJobTimeMaterialLogView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobTimeMaterialLogID = "";
                    return;
                }
                jobTimeMaterialLogID = r["JobTimeMaterialWorkOrderID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmWorkOrder f = new frmWorkOrder("0", jobID, timeMaterialLogSourceBinding);
            f.ShowDialog();
            GetTimeMaterialLog();
        }
        //
        private void grdJobTimeMaterialLogView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdJobTimeMaterialLogView.GetDataRow(grdJobTimeMaterialLogView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmWorkOrder f = new frmWorkOrder(r["JobTimeMaterialWorkOrderID"].ToString(), jobID, timeMaterialLogSourceBinding);
            f.ShowDialog();
            GetTimeMaterialLog();
        }
        //
        private void grdJobTimeMaterialLogView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdJobTimeMaterialLogView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobTimeMaterialLogView.Columns)
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
                timeMaterialLogDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdTimeMaterialLogView_MouseUp(object sender, MouseEventArgs e)
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
                timeMaterialLogDataTable.DefaultView.Sort = command;
            }
        }

        private void grdJobTimeMaterialLogView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
       // 
    }
}
