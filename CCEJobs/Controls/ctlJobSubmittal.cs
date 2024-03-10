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
 
    public partial class ctlJobSubmittal : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource submittalSourceBinding = new BindingSource();
        private DataSet jobSubmittalDataSet;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobSubmittalID;
        //
        public ctlJobSubmittal()
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
                GetJobSubmittal();
                SetControlAccess();
            }
        }
        //
        public DataSet SubmittalDataSet
        {
            get
            {
                return jobSubmittalDataSet;
            }
        }
        //
        public String SubmittalID
        {
            get
            {
                return jobSubmittalID;
            }
        }
        //
        public String SubmittalSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String SubmittalFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetJobSubmittal()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSubmittalView, "ctlJobSubmittal");
                }

                jobSubmittalDataSet = JobSubmittal.GetJobSubmittalList(jobID);
                jobSubmittalDataSet.Relations[0].RelationName = "Detail";
                submittalSourceBinding.DataSource = jobSubmittalDataSet.Tables[0];
                grdSubmittal.DataSource = submittalSourceBinding;
                grdSubmittalView.Columns["JobSubmittalID"].Visible = false;
                grdSubmittalView.Columns["Title"].Visible = false;
                grdSubmittalView.Columns["Rev No"].ColumnEdit = repRevNumber;

               // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
               // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdSubmittalView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSubmittalView, "ctlJobSubmittal");

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
                panSubmittal.Visible = false;
            }
            else
            {
                panSubmittal.Visible = true;
            }
        }
        //
        private void grdSubmittalView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdSubmittalView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobSubmittalID = "";
                    return;
                }
                jobSubmittalID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmSubmittal f = new frmSubmittal("0", jobID,submittalSourceBinding );
            f.ShowDialog();
            GetJobSubmittal();
            
        }
        private void hyperLinkEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ImportSubmittal import = new ImportSubmittal();
                    import.Import(@openFile.FileName, jobID);
                    GetJobSubmittal();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdSubmittalView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdSubmittalView.GetDataRow(grdSubmittalView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmSubmittal f = new frmSubmittal(r[0].ToString(), jobID, submittalSourceBinding);
            f.ShowDialog();
            GetJobSubmittal();
            
        }
        //
        private void grdSubmittalView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdSubmittalView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSubmittalView.Columns)
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
                jobSubmittalDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filter = criteria.Replace("[","").Replace("]","");
           }
            catch
            {
            }
        }
        //
        private void grdSubmittalView_MouseUp(object sender, MouseEventArgs e)
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
                jobSubmittalDataSet.Tables[0].DefaultView.Sort = command;
            }
        }

        private void grdSubmittalView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdSubmittalView = sender as GridView;
            GridView view = grdSubmittalView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobSubmittalID"].Visible = false;
            view.Columns["Rev No"].ColumnEdit = repRevNumber;
            view.OptionsBehavior.Editable = false;
          
            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }

        private void grdSubmittalView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdSubmittalView.GetDataRow(grdSubmittalView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("Delete Selected Submittal?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {

                                try
                                {
                                    JobSubmittal.Delete(r[0].ToString());
                                    grdSubmittalView.DeleteRow(grdSubmittalView.GetSelectedRows()[0]);
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
        private void grdSubmittalView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
        
    }
}
