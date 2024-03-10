
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCLightFixture.BusinessLayer;
using JCCLightFixture.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using Security;

namespace JCCLightFixture.Controls
{
 
    public partial class ctlJobLightFixture : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        protected bool bColumnWidthChangedRelease = false;
        protected bool bColumnWidthChangedRevision = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource lightFixtureSourceBinding = new BindingSource();
        private BindingSource lightFixtureReleaseSourceBinding = new BindingSource();
        private BindingSource lightFixtureRevisionSourceBinding = new BindingSource();
        
        private DataSet jobLightFixtureDataSet;
        private DataSet jobLightFixtureReleaseDataSet;
        private DataSet jobLightFixtureRevisionDataSet;

        private string jobID;
        
        private string sortLightFixture = "";
        private string filterLightFixture = "";
        private string jobLightFixtureID;

        private string sortLightFixtureRelease = "";
        private string filterLightFixtureRelease = "";
        private string jobLightFixtureReleaseID;

        private string sortLightFixtureRevision = "";
        private string filterLightFixtureRevision = "";
        private string jobLightFixtureRevisionID;

        //
        public ctlJobLightFixture()
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
                GetJobLightFixture();
                GetJobLightFixtureRelease();
                GetJobLightFixtureRevision();
                SetControlAccess();
            }
        }
        //
        public DataSet LightFixtureDataSet
        {
            get
            {
                return jobLightFixtureDataSet;
            }
        }
        //
        public DataSet LightFixtureReleaseDataSet
        {
            get
            {
                return jobLightFixtureReleaseDataSet;
            }
        }
        //
        //
        public DataSet LightFixtureRevisionDataSet
        {
            get
            {
                return jobLightFixtureRevisionDataSet;
            }
        }
        //
        public String LightFixtureID
        {
            get
            {
                return jobLightFixtureID;
            }
        }
        //
        public String LightFixtureReleaseID
        {
            get
            {
                return jobLightFixtureReleaseID;
            }
        }
        //
        public String LightFixtureRevisionID
        {
            get
            {
                return jobLightFixtureRevisionID;
            }
        }
        //
        public String LightFixtureSort
        {
            get
            {
                return sortLightFixture;
            }
        }
        //
        public String LightFixtureReleaseSort
        {
            get
            {
                return sortLightFixtureRelease;
            }
        }
        //
        public String LightFixtureRevisionSort
        {
            get
            {
                return sortLightFixtureRevision;
            }
        }
        //
        public String LightFixtureFilter
        {
            get
            {
                return filterLightFixture;
            }
        }
        //
        public String LightFixtureReleaseFilter
        {
            get
            {
                return filterLightFixtureRelease;
            }
        }
        //
        public String LightFixtureRevisionFilter
        {
            get
            {
                return filterLightFixtureRevision;
            }
        }
        //
        private void GetJobLightFixture()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureView, "ctlJobLightFixture");
                }


                jobLightFixtureDataSet = JobLightFixture.GetJobLightFixture(jobID);
                jobLightFixtureDataSet.Relations[0].RelationName = "Detail";
                lightFixtureSourceBinding.DataSource = jobLightFixtureDataSet.Tables[0];
                grdLightFixture.DataSource = lightFixtureSourceBinding;
                grdLightFixtureView.Columns["JobLightFixtureID"].Visible = false;
                grdLightFixtureView.Columns["Qty Run"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Qty Run"].DisplayFormat.FormatString = "{0:n0}";
                grdLightFixtureView.Columns["Qty Bal"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Qty Bal"].DisplayFormat.FormatString = "{0:n0}";
                grdLightFixtureView.Columns["Length"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Length"].DisplayFormat.FormatString = "{0:n0}";
                grdLightFixtureView.Columns["Length Bal"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Length Bal"].DisplayFormat.FormatString = "{0:n0}";
                grdLightFixtureView.Columns["Unit Price"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Unit Price"].DisplayFormat.FormatString = "{0:c2}";
                grdLightFixtureView.Columns["Extension"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Extension"].DisplayFormat.FormatString = "{0:c2}";
                grdLightFixtureView.Columns["Balance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdLightFixtureView.Columns["Balance"].DisplayFormat.FormatString = "{0:c2}";



                grdLightFixtureView.Columns["Extension"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLightFixtureView.Columns["Extension"].SummaryItem.DisplayFormat = "{0:c2}";
                grdLightFixtureView.Columns["Balance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLightFixtureView.Columns["Balance"].SummaryItem.DisplayFormat = "{0:c2}";


                grdLightFixtureView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdLightFixtureView, "ctlJobLightFixture");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void GetJobLightFixtureRelease()
        {
            try
            {
                if (bColumnWidthChangedRelease)
                {
                    bColumnWidthChangedRelease = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureReleaseView, "ctlJobLightFixtureRelease");
                }

                jobLightFixtureReleaseDataSet = JobLightFixtureRelease.GetJobLightFixtureRelease(jobID);
                jobLightFixtureReleaseDataSet.Relations[0].RelationName = "Detail";
                lightFixtureReleaseSourceBinding.DataSource = jobLightFixtureReleaseDataSet.Tables[0];
                grdLightFixtureRelease.DataSource = lightFixtureReleaseSourceBinding;
                grdLightFixtureReleaseView.Columns["JobLightFixtureReleaseID"].Visible = false;
                grdLightFixtureReleaseView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdLightFixtureReleaseView, "ctlJobLightFixtureRelease");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void GetJobLightFixtureRevision()
        {
            try
            {
                if (bColumnWidthChangedRevision)
                {
                    bColumnWidthChangedRevision = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureRevisionView, "ctlJobLightFixtureRevision");
                }

                jobLightFixtureRevisionDataSet = JobLightFixtureRevision.GetJobLightFixtureRevision(jobID);
                jobLightFixtureRevisionDataSet.Relations[0].RelationName = "Detail";
                lightFixtureRevisionSourceBinding.DataSource = jobLightFixtureRevisionDataSet.Tables[0];
                grdLightFixtureRevision.DataSource = lightFixtureRevisionSourceBinding;
                grdLightFixtureRevisionView.Columns["JobLightFixtureRevisionID"].Visible = false;
                grdLightFixtureRevisionView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdLightFixtureRevisionView, "ctlJobLightFixtureRevision");
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
            {
                panLightFixture.Visible = true;
                panLightFixtureRelease.Visible = true;
                panLightFixtureRevision.Visible = true;
            }
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panLightFixture.Visible = false;
                    panLightFixtureRelease.Visible = false;
                    panLightFixtureRevision.Visible = false;
                }
                else
                {
                    panLightFixture.Visible = true;
                    panLightFixtureRelease.Visible = true;
                    panLightFixtureRevision.Visible = true;
                }
            }
        }
        //
        private void grdLightFixtureView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdLightFixtureView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobLightFixtureID = "";
                    return;
                }
                jobLightFixtureID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void grdLightFixtureReleaseView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdLightFixtureReleaseView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobLightFixtureReleaseID = "";
                    return;
                }
                jobLightFixtureReleaseID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdLightFixtureRevisionView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdLightFixtureRevisionView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobLightFixtureRevisionID = "";
                    return;
                }
                jobLightFixtureRevisionID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmLightFixture f = new frmLightFixture("0", jobID,lightFixtureSourceBinding );
            f.ShowDialog();
            GetJobLightFixture();
        }
        //
        private void hyperLinkEdit2_Click(object sender, EventArgs e)
        {
            frmLightFixtureRelease f = new frmLightFixtureRelease("0", jobID, lightFixtureReleaseSourceBinding);
            f.ShowDialog();
            GetJobLightFixtureRelease();
        }
        //
        private void grdLightFixtureView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdLightFixtureView.GetDataRow(grdLightFixtureView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmLightFixture f = new frmLightFixture(r[0].ToString(), jobID, lightFixtureSourceBinding);
            f.ShowDialog();
            GetJobLightFixture();
        }
        //
        private void grdLightFixtureReleaseView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdLightFixtureReleaseView.GetDataRow(grdLightFixtureReleaseView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmLightFixtureRelease f = new frmLightFixtureRelease(r[0].ToString(), jobID, lightFixtureReleaseSourceBinding);
            f.ShowDialog();
            GetJobLightFixtureRelease();
        }
        //
        private void grdLightFixtureRevisionView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdLightFixtureRevisionView.GetDataRow(grdLightFixtureRevisionView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmLightFixtureRevision f = new frmLightFixtureRevision(r[0].ToString(), jobID, lightFixtureRevisionSourceBinding);
            f.ShowDialog();
            GetJobLightFixtureRevision();
        }
        //
        private void grdLightFixtureView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filterLightFixture = grdLightFixtureView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdLightFixtureView.Columns)
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
                jobLightFixtureDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filterLightFixture = criteria.Replace("[", "").Replace("]", ""); 
           }
            catch
            {
            }
        }
        //
        private void grdLightFixtureReleaseView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                filterLightFixtureRelease = grdLightFixtureReleaseView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdLightFixtureReleaseView.Columns)
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
                jobLightFixtureReleaseDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filterLightFixtureRelease = criteria.Replace("[", "").Replace("]", ""); 
            }
            catch
            {
            }
        }
        //
        private void grdLightFixtureRevisionView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                filterLightFixtureRevision = grdLightFixtureRevisionView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdLightFixtureRevisionView.Columns)
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
                jobLightFixtureRevisionDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filterLightFixtureRevision = criteria.Replace("[","").Replace("]","");
            }
            catch
            {
            }
        }
        //
        private void grdLightFixtureView_MouseUp(object sender, MouseEventArgs e)
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
                    sortLightFixture = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sortLightFixture = info.Column.Caption + " ASC";
                }
                jobLightFixtureDataSet.Tables[0].DefaultView.Sort = command;
            }
        }
        //
        private void grdLightFixtureReleaseView_MouseUp(object sender, MouseEventArgs e)
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
                    sortLightFixtureRelease = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sortLightFixtureRelease = info.Column.Caption + " ASC";
                }
                jobLightFixtureReleaseDataSet.Tables[0].DefaultView.Sort = command;
            }
        }
        //
        private void grdLightFixtureRevisionView_MouseUp(object sender, MouseEventArgs e)
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
                    sortLightFixtureRevision = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sortLightFixtureRevision = info.Column.Caption + " ASC";
                }
                jobLightFixtureRevisionDataSet.Tables[0].DefaultView.Sort = command;
            }
        }
        //
        private void grdLightFixtureView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdLightFixtureView = sender as GridView;
            GridView view = grdLightFixtureView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobLightFixtureID"].Visible = false;
            view.OptionsBehavior.Editable = false;

            view.Columns["Quantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Quantity"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Length"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Length"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Paid Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Paid Amount"].DisplayFormat.FormatString = "{0:c2}";


            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }
        //
        private void grdLightFixtureReleaseView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdLightFixtureReleaseView = sender as GridView;
            GridView view = grdLightFixtureReleaseView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobLightFixtureReleaseID"].Visible = false;
            view.OptionsBehavior.Editable = false;

            view.Columns["Qty Run"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Length"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Notes"].Width = 500;

            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsCustomization.AllowColumnResizing = true;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }
        //
        private void grdLightFixtureRevisionView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdLightFixtureRevisionView = sender as GridView;
            GridView view = grdLightFixtureRevisionView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobLightFixtureRevisionID"].Visible = false;
            view.OptionsBehavior.Editable = false;

            view.Columns["Qty Run"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Length"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Notes"].Width = 500;

            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsCustomization.AllowColumnResizing = true;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }

        private void hyperLinkEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ImportLightFixture import = new ImportLightFixture();
                    import.Import(@openFile.FileName, jobID);
                    GetJobLightFixture();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void grdLightFixtureView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
               (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdLightFixtureView.GetDataRow(grdLightFixtureView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Light Fixture and related Releases, Revisions, and Receives. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    JobLightFixture.Remove(r[0].ToString());
                                    grdLightFixtureView.DeleteRow(grdLightFixtureView.GetSelectedRows()[0]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, JCCLightFixture.CCEApplication.ApplicationName);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void hyperLinkEdit4_Click(object sender, EventArgs e)
        {
            frmLightFixtureRevision f = new frmLightFixtureRevision("0", jobID, lightFixtureRevisionSourceBinding);
            f.ShowDialog();
            GetJobLightFixtureRevision();
        }

        private void grdLightFixtureReleaseView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
               (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdLightFixtureReleaseView.GetDataRow(grdLightFixtureReleaseView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Light Fixture Release and related Items. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    JobLightFixtureRelease.Remove(r[0].ToString());
                                    grdLightFixtureReleaseView.DeleteRow(grdLightFixtureReleaseView.GetSelectedRows()[0]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, JCCLightFixture.CCEApplication.ApplicationName);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void grdLightFixtureRevisionView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
               (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdLightFixtureRevisionView.GetDataRow(grdLightFixtureRevisionView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Light Fixture Revision and related Items. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    JobLightFixtureRevision.Remove(r[0].ToString());
                                    grdLightFixtureRevisionView.DeleteRow(grdLightFixtureRevisionView.GetSelectedRows()[0]);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, JCCLightFixture.CCEApplication.ApplicationName);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void grdLightFixtureView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdLightFixtureReleaseView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRelease = true;
        }

        private void grdLightFixtureRevisionView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRevision = true;
        }

        private void btnOpenTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = @openFile.FileName;
                    proc.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
       
    }
}
