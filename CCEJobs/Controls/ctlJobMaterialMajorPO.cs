using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace CCEJobs.Controls
{

    public partial class ctlJobMaterialMajorPO : UserControl
    {
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource majorPOSourceBinding = new BindingSource();
        private DataTable jobMajorPODataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobMajorPOID;
        private string poType = "";
        //
        public ctlJobMaterialMajorPO()
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
                GetJobMajorPO();
                SetControlAccess();
            }
        }
        //
        public DataTable MajorPODataTable
        {
            get
            {
                return jobMajorPODataTable;
            }
        }
        //
        public String MajorPOID
        {
            get
            {
                return jobMajorPOID;
            }
        }
        //
        public String MajorPOType
        {
            get
            {
                return poType;
            }
        }
        //
        public String MajorPOSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String MajorPOFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetJobMajorPO()
        {
            try
            {
                try
                {
                    if (bColumnWidthChanged)
                    {
                        bColumnWidthChanged = false;
                        Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdMajorPOView, "ctlJobMaterialMajorPO");
                    }
                }
                catch (Exception ex)
                {
                    ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                }

                jobMajorPODataTable = MajorPO.GetJobMajorPO(jobID).Tables[0];
                majorPOSourceBinding.DataSource = jobMajorPODataTable;
                grdMajorPO.DataSource = majorPOSourceBinding;
                grdMajorPOView.Columns["JobMajorPOID"].Visible = false;
                try
                {
                    grdMajorPOView.Columns["Tax Percent"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdMajorPOView.Columns["Tax Percent"].DisplayFormat.FormatString = "{0:p4}";

                    grdMajorPOView.Columns["Sales Tax"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdMajorPOView.Columns["Sales Tax"].DisplayFormat.FormatString = "{0:c2}";

                    grdMajorPOView.Columns["Subtotal"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdMajorPOView.Columns["Subtotal"].DisplayFormat.FormatString = "{0:c2}";

                    grdMajorPOView.Columns["Total"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    grdMajorPOView.Columns["Total"].DisplayFormat.FormatString = "{0:c2}";


                    grdMajorPOView.Columns["Sales Tax"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grdMajorPOView.Columns["Sales Tax"].SummaryItem.DisplayFormat = "{0:c2}";

                    grdMajorPOView.Columns["Subtotal"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grdMajorPOView.Columns["Subtotal"].SummaryItem.DisplayFormat = "{0:c2}";

                    grdMajorPOView.Columns["Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    grdMajorPOView.Columns["Total"].SummaryItem.DisplayFormat = "{0:c2}";
                }
                catch (Exception ex)
                { ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile); }

                grdMajorPOView.BestFitColumns();

                try
                {
                    Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdMajorPOView, "ctlJobMaterialMajorPO");
                }
                catch (Exception ex)
                {
                    ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
               // MessageBox.Show(ex.Message);
            }
        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                panMajorPO.Visible = false;
            }
            else
            {
                panMajorPO.Visible = true;
            }
        }
        //
        private void grdMajorPOView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdMajorPOView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobMajorPOID = "";
                    return;
                }
                jobMajorPOID = r[0].ToString();
                poType = r["PO Type"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmMajorPO f = new frmMajorPO("0", jobID, majorPOSourceBinding);
            f.ShowDialog();
            GetJobMajorPO();

        }

        private void grdMajorPOView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow r;
                try
                {
                    //int a = 10;
                    //int b = 0;
                    //int c = a / b;
                    r = grdMajorPOView.GetDataRow(grdMajorPOView.GetSelectedRows()[0]);
                    if (r == null)
                        return;


                    frmMajorPO f = new frmMajorPO(r[0].ToString(), jobID, majorPOSourceBinding);
                    f.ShowDialog();
                }
                catch (Exception ex)
                {
                    ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                   // MessageBox.Show(ex.Message);
                }

                try
                {
                    GetJobMajorPO();
                }
                catch (Exception ex)
                {
                    ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                  //  MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                //MessageBox.Show(ex.Message);
            }

        }
        //
        private void grdMajorPOView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                filter = grdMajorPOView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdMajorPOView.Columns)
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
                jobMajorPODataTable.DefaultView.RowFilter = criteria;
                filter = criteria.Replace("[", "").Replace("]", "");
            }
            catch
            {
            }
        }
        //
        private void grdMajorPOView_MouseUp(object sender, MouseEventArgs e)
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
                jobMajorPODataTable.DefaultView.Sort = command;
            }
        }

        private void grdMajorPOView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

    }
}
