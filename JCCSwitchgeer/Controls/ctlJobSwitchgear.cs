
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCSwitchgear.BusinessLayer;
using JCCSwitchgear.PresentationLayer;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace JCCSwitchgear.Controls
{
 
    public partial class ctlJobSwitchgear : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        protected bool bColumnWidthChangedRelease = false;
        protected bool bColumnWidthChangedRevision = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource switchgearSourceBinding = new BindingSource();
        private BindingSource switchgearReleaseSourceBinding = new BindingSource();
        private BindingSource switchgearRevisionSourceBinding = new BindingSource();
        private DataSet jobSwitchgearDataSet;
        private DataSet jobSwitchgearReleaseDataSet;
        private DataSet jobSwitchgearRevisionDataSet;
        private string jobID;
        
        private string sortSwitchgear = "";
        private string filterSwitchgear = "";
        private string jobSwitchgearID;

        private string sortSwitchgearRelease = "";
        private string filterSwitchgearRelease = "";
        private string jobSwitchgearReleaseID;

        private string sortSwitchgearRevision = "";
        private string filterSwitchgearRevision = "";
        private string jobSwitchgearRevisionID;

        //
        public ctlJobSwitchgear()
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
                GetJobSwitchgear();
                GetJobSwitchgearRelease();
                GetJobSwitchgearRevision();
                SetControlAccess();
            }
        }
        //
        public DataSet SwitchgearDataSet
        {
            get
            {
                return jobSwitchgearDataSet;
            }
        }
        //
        public DataSet SwitchgearReleaseDataSet
        {
            get
            {
                return jobSwitchgearReleaseDataSet;
            }
        }
        //
        public DataSet SwitchgearRevisionDataSet
        {
            get
            {
                return jobSwitchgearRevisionDataSet;
            }
        }
        //
        public String SwitchgearID
        {
            get
            {
                return jobSwitchgearID;
            }
        }
        //
        public String SwitchgearReleaseID
        {
            get
            {
                return jobSwitchgearReleaseID;
            }
        }
        //
        public String SwitchgearRevisionID
        {
            get
            {
                return jobSwitchgearRevisionID;
            }
        }
        //
        public String SwitchgearSort
        {
            get
            {
                return sortSwitchgear;
            }
        }
        //
        public String SwitchgearReleaseSort
        {
            get
            {
                return sortSwitchgearRelease;
            }
        }
        //
        public String SwitchgearRevisionSort
        {
            get
            {
                return sortSwitchgearRevision;
            }
        }
        //
        public String SwitchgearFilter
        {
            get
            {
                return filterSwitchgear;
            }
        }
        //
        public String SwitchgearReleaseFilter
        {
            get
            {
                return filterSwitchgearRelease;
            }
        }
        //
        public String SwitchgearRevisionFilter
        {
            get
            {
                return filterSwitchgearRevision;
            }
        }
        //
        private void GetJobSwitchgear()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearView, "ctlJobSwitchgear");
                }


                jobSwitchgearDataSet = Switchgear.GetJobSwitchgear(jobID);
                jobSwitchgearDataSet.Relations[0].RelationName = "Detail";
                switchgearSourceBinding.DataSource = jobSwitchgearDataSet.Tables[0];
                grdSwitchgear.DataSource = switchgearSourceBinding;
                grdSwitchgearView.Columns["JobSwitchgearID"].Visible = false;
                grdSwitchgearView.Columns["Quantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSwitchgearView.Columns["Quantity"].DisplayFormat.FormatString = "{0:n0}";
                grdSwitchgearView.Columns["Unit Price"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSwitchgearView.Columns["Unit Price"].DisplayFormat.FormatString = "{0:c2}";
                grdSwitchgearView.Columns["Extension"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSwitchgearView.Columns["Extension"].DisplayFormat.FormatString = "{0:c2}";
                grdSwitchgearView.Columns["Balance"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSwitchgearView.Columns["Balance"].DisplayFormat.FormatString = "{0:c2}";
                grdSwitchgearView.Columns["Qty Rec"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSwitchgearView.Columns["Qty Rec"].DisplayFormat.FormatString = "{0:n0}";
                grdSwitchgearView.Columns["Qty Bal"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                grdSwitchgearView.Columns["Qty Bal"].DisplayFormat.FormatString = "{0:n0}";

                grdSwitchgearView.Columns["Extension"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSwitchgearView.Columns["Extension"].SummaryItem.DisplayFormat = "{0:c2}";
                grdSwitchgearView.Columns["Balance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSwitchgearView.Columns["Balance"].SummaryItem.DisplayFormat = "{0:c2}";


                grdSwitchgearView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSwitchgearView, "ctlJobSwitchgear");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void GetJobSwitchgearRelease()
        {
            try
            {
                if (bColumnWidthChangedRelease)
                {
                    bColumnWidthChangedRelease = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearReleaseView, "ctlJobSwitchgearRelease");
                }
                jobSwitchgearReleaseDataSet = SwitchgearRelease.GetJobSwitchgearRelease(jobID);
                jobSwitchgearReleaseDataSet.Relations[0].RelationName = "Detail";
                switchgearReleaseSourceBinding.DataSource = jobSwitchgearReleaseDataSet.Tables[0];
                grdSwitchgearRelease.DataSource = switchgearReleaseSourceBinding;
                grdSwitchgearReleaseView.Columns["JobSwitchgearReleaseID"].Visible = false;
                grdSwitchgearReleaseView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSwitchgearReleaseView, "ctlJobSwitchgearRelease");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void GetJobSwitchgearRevision()
        {
            try
            {
                if (bColumnWidthChangedRevision)
                {
                    bColumnWidthChangedRevision = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearRevisionView, "ctlJobSwitchgearRevision");
                }

                jobSwitchgearRevisionDataSet = SwitchgearRevision.GetJobSwitchgearRevision(jobID);
                jobSwitchgearRevisionDataSet.Relations[0].RelationName = "Detail";
                switchgearRevisionSourceBinding.DataSource = jobSwitchgearRevisionDataSet.Tables[0];
                grdSwitchgearRevision.DataSource = switchgearRevisionSourceBinding;
                grdSwitchgearRevisionView.Columns["JobSwitchgearRevisionID"].Visible = false;
                grdSwitchgearRevisionView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSwitchgearRevisionView, "ctlJobSwitchgearRevision");
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
                panSwitchgear.Visible = true;
                panSwitchgearRelease.Visible = true;
                panSwitchgearRevision.Visible = true;
            }
            else
            {

                if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                    Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    panSwitchgear.Visible = false;
                    panSwitchgearRelease.Visible = false;
                    panSwitchgearRevision.Visible = false;
                }
                else
                {
                    panSwitchgear.Visible = true;
                    panSwitchgearRelease.Visible = true;
                    panSwitchgearRevision.Visible = true;
                }
            }
        }
        //
        private void grdLightFixtureView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdSwitchgearView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobSwitchgearID = "";
                    return;
                }
                jobSwitchgearID = r[0].ToString();
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

                r = grdSwitchgearReleaseView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobSwitchgearReleaseID = "";
                    return;
                }
                jobSwitchgearReleaseID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmSwitchgear f = new frmSwitchgear("0", jobID,switchgearSourceBinding );
            f.ShowDialog();
            GetJobSwitchgear();
        }
        //
        private void hyperLinkEdit2_Click(object sender, EventArgs e)
        {
            frmSwitchgearRelease f = new frmSwitchgearRelease("0", jobID, switchgearReleaseSourceBinding);
            f.ShowDialog();
            GetJobSwitchgearRelease();
        }
        //
        private void grdLightFixtureView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdSwitchgearView.GetDataRow(grdSwitchgearView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmSwitchgear f = new frmSwitchgear(r[0].ToString(), jobID, switchgearSourceBinding);
            f.ShowDialog();
            GetJobSwitchgear();
        }
        //
        private void grdLightFixtureReleaseView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdSwitchgearReleaseView.GetDataRow(grdSwitchgearReleaseView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmSwitchgearRelease f = new frmSwitchgearRelease(r[0].ToString(), jobID, switchgearReleaseSourceBinding);
            f.ShowDialog();
            GetJobSwitchgearRelease();
        }
        //
        private void grdLightFixtureView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filterSwitchgear = grdSwitchgearView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSwitchgearView.Columns)
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
                jobSwitchgearDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filterSwitchgear = criteria;
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
                filterSwitchgearRelease = grdSwitchgearReleaseView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSwitchgearReleaseView.Columns)
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
                jobSwitchgearReleaseDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filterSwitchgearRelease = criteria;
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
                    sortSwitchgear = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sortSwitchgear = info.Column.Caption + " ASC";
                }
                jobSwitchgearDataSet.Tables[0].DefaultView.Sort = command;
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
                    sortSwitchgearRelease = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    sortSwitchgearRelease = info.Column.Caption + " ASC";
                }
                jobSwitchgearReleaseDataSet.Tables[0].DefaultView.Sort = command;
            }
        }
        //
        private void grdLightFixtureView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdLightFixtureView = sender as GridView;
            GridView view = grdSwitchgearView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobSwitchgearID"].Visible = false;
            view.OptionsBehavior.Editable = false;

            view.Columns["Quantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Quantity"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Paid Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Paid Amount"].DisplayFormat.FormatString = "{0:n0}";

            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }
        //
        private void grdLightFixtureReleaseView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdSwitchgearReleaseView = sender as GridView;
            GridView view = grdSwitchgearReleaseView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobSwitchgearReleaseID"].Visible = false;
            view.OptionsBehavior.Editable = false;

            view.Columns["Quantity"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            view.Columns["Quantity"].DisplayFormat.FormatString = "{0:n0}";


            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
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
                    ImportSwitchgear import = new ImportSwitchgear();
                    import.Import(@openFile.FileName, jobID);
                    GetJobSwitchgear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void grdSwitchgearView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
               (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdSwitchgearView.GetDataRow(grdSwitchgearView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Switchgear and related Releases, Revisions, and Receives. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    Switchgear.Remove(r[0].ToString());
                                    grdSwitchgearView.DeleteRow(grdSwitchgearView.GetSelectedRows()[0]);
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

        private void grdSwitchgearReleaseView_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
            (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdSwitchgearReleaseView.GetDataRow(grdSwitchgearReleaseView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Switchgear Release and related Items. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    SwitchgearRelease.Remove(r[0].ToString());
                                    grdSwitchgearReleaseView.DeleteRow(grdSwitchgearReleaseView.GetSelectedRows()[0]);
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

        private void grdSwitchgearRevisionView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                filterSwitchgearRevision = grdSwitchgearRevisionView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSwitchgearRevisionView.Columns)
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
                jobSwitchgearRevisionDataSet.Tables[0].DefaultView.RowFilter = criteria;
                filterSwitchgearRevision = criteria.Replace("[", "").Replace("]", "");
            }
            catch
            {
            }
        }

        private void grdSwitchgearRevisionView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdSwitchgearRevisionView.GetDataRow(grdSwitchgearRevisionView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmSwitchgearRevision f = new frmSwitchgearRevision(r[0].ToString(), jobID, switchgearRevisionSourceBinding);
            f.ShowDialog();
            GetJobSwitchgearRevision();
        }

        private void grdSwitchgearRevisionView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdSwitchgearRevisionView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    jobSwitchgearRevisionID = "";
                    return;
                }
                jobSwitchgearRevisionID = r[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

        }

        private void grdSwitchgearRevisionView_KeyDown(object sender, KeyEventArgs e)
        {
                       if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
               (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdSwitchgearRevisionView.GetDataRow(grdSwitchgearRevisionView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("You are about to delete Switchgear Revision and related Items. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                try
                                {
                                    SwitchgearRevision.Remove(r[0].ToString());
                                    grdSwitchgearRevisionView.DeleteRow(grdSwitchgearRevisionView.GetSelectedRows()[0]);
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

        private void hyperLinkEdit4_Click(object sender, EventArgs e)
        {
            frmSwitchgearRevision f = new frmSwitchgearRevision("0", jobID, switchgearRevisionSourceBinding);
            f.ShowDialog();
            GetJobSwitchgearRevision();

        }

        private void grdSwitchgearView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void grdSwitchgearReleaseView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRelease = true;
        }

        private void grdSwitchgearRevisionView_ColumnWidthChanged(object sender, ColumnEventArgs e)
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
