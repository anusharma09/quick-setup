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
 
    public partial class ctlJobCorrespondenceLetter : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource correspondenceLetterSourceBinding = new BindingSource();
        private DataTable correspondenceLetterDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string correspondenceLetterID;
        //
        public ctlJobCorrespondenceLetter()
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
                GetCorrespondenceLetter();
                SetControlAccess();
            }
        }
        //
        public DataTable CorrespondenceLetterDataTable
        {
            get
            {
                return correspondenceLetterDataTable;
            }
        }
        //
        public String CorrespondenceLetterID
        {
            get
            {
                return correspondenceLetterID;
            }
        }
        //
        public String CorrespondenceLetterSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String CorrespondenceLetterFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetCorrespondenceLetter()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobCorrespondenceLetterView, "ctlJobCorrespondenceLetter");
                }

                correspondenceLetterDataTable = JobCorrespondenceLetter.GetJobCorrespondenceLetterList(jobID).Tables[0];
                correspondenceLetterSourceBinding.DataSource = correspondenceLetterDataTable;
                grdJobCorrespondenceLetter.DataSource = correspondenceLetterSourceBinding;
                grdJobCorrespondenceLetterView.Columns["JobCorrespondenceLetterID"].Visible = false;
                grdJobCorrespondenceLetterView.Columns["JobID"].Visible = false;

                //grdJobCorrespondenceLetterView.Columns["Note"].ColumnEdit = repCorrespondenceLetterNote;
               // grdJobCorrespondenceLetterView.Columns["Cost Impact"].ColumnEdit = repCostImpact;

               // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
               // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdJobCorrespondenceLetterView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobCorrespondenceLetterView, "ctlJobCorrespondenceLetter");

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
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly )
            {
                panJobCorrespondenceLetter.Visible = false;
            }
            else
            {
                panJobCorrespondenceLetter.Visible = true;
            }
        }
        //
        private void grdJobCorrespondenceLetterView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdJobCorrespondenceLetterView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    correspondenceLetterID = "";
                    return;
                }
                correspondenceLetterID = r["JobCorrespondenceLetterID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmCorrespondenceLetter f = new frmCorrespondenceLetter("0", jobID, correspondenceLetterSourceBinding);
            f.ShowDialog();
            GetCorrespondenceLetter();
        }
        //
        private void grdJobCorrespondenceLetterView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdJobCorrespondenceLetterView.GetDataRow(grdJobCorrespondenceLetterView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmCorrespondenceLetter f = new frmCorrespondenceLetter(r["JobCorrespondenceLetterID"].ToString(), jobID, correspondenceLetterSourceBinding);
            f.ShowDialog();
            GetCorrespondenceLetter();
        }
        //
        private void grdJobCorrespondenceLetterView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdJobCorrespondenceLetterView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobCorrespondenceLetterView.Columns)
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
                correspondenceLetterDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdJobCorrespondenceLetterView_MouseUp(object sender, MouseEventArgs e)
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
                correspondenceLetterDataTable.DefaultView.Sort = command;
            }
        }

        private void grdJobCorrespondenceLetterView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdJobCorrespondenceLetterView.GetDataRow(grdJobCorrespondenceLetterView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Correspondence Letter. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    JobCorrespondenceLetter.Remove(r[0].ToString());
                                    grdJobCorrespondenceLetterView.DeleteRow(grdJobCorrespondenceLetterView.GetSelectedRows()[0]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void grdJobCorrespondenceLetterView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
       // 
    }
}
