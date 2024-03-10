using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
//using CCEJobs.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using CCEJobs.PresentationLayer;

namespace CCEJobs.Controls
{
 
    public partial class ctlPreBidRFI : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource RFISourceBinding = new BindingSource();
        private DataTable opportunityRFIDataTable;
        private string jobID = "0";
        private string sort = "";
        private string filter = "";
        private string jobRFIID;
        //
        public ctlPreBidRFI ()
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
                //if (otProjectID != value)
                {
                    jobID = value;
                    GetOpportunityRFI();
                }
            }
        }
        //
        public DataTable RFIDataTable
        {
            get
            {
                return opportunityRFIDataTable;
            }
        }
        //
        public String RFIID
        {
            get
            {
                return jobRFIID;
            }
        }
        //
        public String RFISort
        {
            get
            {
                return sort;
            }
        }
        //
        public String RFIFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetOpportunityRFI()
        {
            try
            {
                opportunityRFIDataTable = PreBidRFI.GetOpportunityRFI(jobID).Tables[0];
                RFISourceBinding.DataSource = opportunityRFIDataTable;
                grdRFI.DataSource = RFISourceBinding;
                grdRFIView.Columns["PreBidRFIID"].Visible = false;
                grdRFIView.BestFitColumns();
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
                panRFI.Visible = true;
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panRFI.Visible = false;
                }
                else
                {
                    panRFI.Visible = true;
                }
            }


        }
        //
        private void grdRFIView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdRFIView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobRFIID = "";
                    return;
                }
                jobRFIID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmPreBidRFI f = new frmPreBidRFI("0", jobID, RFISourceBinding );
            f.ShowDialog();
            GetOpportunityRFI();
            
        }

        private void grdRFIView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdRFIView.GetDataRow(grdRFIView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmPreBidRFI f = new frmPreBidRFI(r[0].ToString(), jobID, RFISourceBinding);
            f.ShowDialog();
            GetOpportunityRFI(); 
        }
        //
        private void grdRFIView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdRFIView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdRFIView.Columns)
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
                opportunityRFIDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdRFIView_MouseUp(object sender, MouseEventArgs e)
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
                opportunityRFIDataTable.DefaultView.Sort = command;
            }
        }

        private void grdRFIView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        
    }
}
