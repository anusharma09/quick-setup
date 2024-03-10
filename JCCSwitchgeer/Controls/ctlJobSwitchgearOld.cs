
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
 
    public partial class ctlJobSwitchgearOld : UserControl
    {  
        //
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource switchgearSourceBinding = new BindingSource();
        private DataSet jobSwitchgearDataSet;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string jobSwitchgearID;
        //
        public ctlJobSwitchgearOld()
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
        public String SwitchgearID
        {
            get
            {
                return jobSwitchgearID;
            }
        }
        //
        public String SwitchgearSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String SwitchgearFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetJobSwitchgear()
        {
            try
            {

                jobSwitchgearDataSet = Switchgear.GetJobSwitchgear(jobID);
                jobSwitchgearDataSet.Relations[0].RelationName = "Detail";
                switchgearSourceBinding.DataSource = jobSwitchgearDataSet.Tables[0];
                grdSwitchgear.DataSource = switchgearSourceBinding;
                grdSwitchgearView.Columns["JobSwitchgearID"].Visible = false;

                grdSwitchgearView.Columns["Extension"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSwitchgearView.Columns["Extension"].SummaryItem.DisplayFormat = "{0:c2}";
                grdSwitchgearView.Columns["Balance"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSwitchgearView.Columns["Balance"].SummaryItem.DisplayFormat = "{0:c2}";

                grdSwitchgearView.BestFitColumns();
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
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly )
            {
                panSwitchgear.Visible = false;
            }
            else
            {
                panSwitchgear.Visible = true;
            }
        }
        //
        private void grdSwitchgearView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
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
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmSwitchgear f = new frmSwitchgear("0", jobID,switchgearSourceBinding );
            f.ShowDialog();
            GetJobSwitchgear();
        }
        //
        private void grdSwitchgearView_DoubleClick(object sender, EventArgs e)
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
        private void grdSwitchgearView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdSwitchgearView.FilterPanelText;

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
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdSwitchgearView_MouseUp(object sender, MouseEventArgs e)
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
                jobSwitchgearDataSet.Tables[0].DefaultView.Sort = command;
            }
        }

        private void grdSwitchgearView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView grdSwitchgearView = sender as GridView;
            GridView view = grdSwitchgearView.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            view.BeginDataUpdate();
            view.BestFitColumns();

            view.Columns["JobSwitchgearID"].Visible = false;
            view.OptionsBehavior.Editable = false;
          
            view.OptionsCustomization.AllowSort = false;
            view.OptionsCustomization.AllowFilter = false;
            view.OptionsView.ShowFooter = false;
            view.EndUpdate();
        }

        private void hyperLinkEdit2_Click(object sender, EventArgs e)
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
        
    }
}
