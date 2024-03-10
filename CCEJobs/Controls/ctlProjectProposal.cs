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
    public partial class ctlProjectProposal : UserControl
    {
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource ProjectProposalSourceBinding = new BindingSource();
        private DataTable opportunityProjectProposalDataTable;
        private string jobID = "0";
        
        private string sort = "";
        private string filter = "";
        private string jobProjectProposalID;
        //
        public ctlProjectProposal()
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

                {
                    jobID = value;
                     GetProjectProposal(jobID);
                }
            }
        }

        //
        public DataTable ProjectProposalDataTable
        {
            get
            {
                return opportunityProjectProposalDataTable;
            }
        }
        //
        public String ProjectProposalID
        {
            get
            {
                return jobProjectProposalID;
            }
        }
        //
        public String ProjectProposalSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String ProjectProposalFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetProjectProposal(string jobID)
        {
            try
            {
                opportunityProjectProposalDataTable = ProjectProposal.GetProposals(jobID).Tables[0];
                ProjectProposalSourceBinding.DataSource = opportunityProjectProposalDataTable;
                grdProjectProposal.DataSource = ProjectProposalSourceBinding;
                grdProjectProposalView.BestFitColumns();
                
                grdProjectProposalView.Columns[1].Visible = false;
                grdProjectProposalView.Columns[2].Visible = false;
                grdProjectProposalView.Columns[5].Visible = false;
                grdProjectProposalView.Columns[8].Visible = false;
                


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
                panProjectProposal.Visible = true;
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panProjectProposal.Visible = false;
                }
                else
                {
                    panProjectProposal.Visible = true;
                }
            }


        }
        //
        private void grdProjectProposalView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdProjectProposalView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobProjectProposalID = "";
                    return;
                }
                jobProjectProposalID = r[1].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmProjectProposal f = new frmProjectProposal("0",jobID, ProjectProposalSourceBinding,true,"","");
            f.ShowDialog();
            GetProjectProposal(jobID);

        }

        private void grdProjectProposalView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdProjectProposalView.GetDataRow(grdProjectProposalView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmProjectProposal f = new frmProjectProposal(r[1].ToString(), jobID, ProjectProposalSourceBinding,false, r[5].ToString(), r[9].ToString());
            f.ShowDialog();
            GetProjectProposal(jobID);
        }
        //
        private void grdProjectProposalView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                filter = grdProjectProposalView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdProjectProposalView.Columns)
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
                opportunityProjectProposalDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
            }
            catch
            {
            }
        }
        //
        private void grdProjectProposalView_MouseUp(object sender, MouseEventArgs e)
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
                opportunityProjectProposalDataTable.DefaultView.Sort = command;
            }
        }

        private void grdProjectProposalView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

    }
}
