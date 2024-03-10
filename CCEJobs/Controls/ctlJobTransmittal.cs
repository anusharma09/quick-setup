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
 
    public partial class ctlJobTransmittal : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource transmittalSourceBinding = new BindingSource();
        private DataTable jobTransmittalDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobTransmittalID;
        //
        public ctlJobTransmittal()
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
                GetJobTransmittal();
                SetControlAccess();
            }
        }
        //
        public DataTable TransmittalDataTable
        {
            get
            {
                return jobTransmittalDataTable;
            }
        }
        //
        public String TransmittalID
        {
            get
            {
                return jobTransmittalID;
            }
        }
        //
        public String TransmittalSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String TransmittalFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetJobTransmittal()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdTransmittalView, "ctlJobTransmittal");
                }

                jobTransmittalDataTable = JobTransmittal.GetJobTransmittalList(jobID).Tables[0];
                transmittalSourceBinding.DataSource = jobTransmittalDataTable;
                grdTransmittal.DataSource = transmittalSourceBinding;
                grdTransmittalView.Columns["JobTransmittalID"].Visible = false;

                grdTransmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                grdTransmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdTransmittalView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdTransmittalView, "ctlJobTransmittal");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                panTransmittal.Visible = false;
            }
            else
            {
                panTransmittal.Visible = true;
            }
        }
        //
        private void grdTransmittalView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdTransmittalView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobTransmittalID = "";
                    return;
                }
                jobTransmittalID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmTransmittal f = new frmTransmittal("0", jobID,transmittalSourceBinding );
            f.ShowDialog();
            GetJobTransmittal();
            
        }
        //
        private void grdTransmittalView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdTransmittalView.GetDataRow(grdTransmittalView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmTransmittal f = new frmTransmittal(r[0].ToString(), jobID, transmittalSourceBinding);
            f.ShowDialog();
            GetJobTransmittal();
            
        }
        //
        private void grdTransmittalView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdTransmittalView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdTransmittalView.Columns)
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
                jobTransmittalDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdTransmittalView_MouseUp(object sender, MouseEventArgs e)
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
                jobTransmittalDataTable.DefaultView.Sort = command;
            }
        }

        private void grdTransmittalView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        
    }
}
