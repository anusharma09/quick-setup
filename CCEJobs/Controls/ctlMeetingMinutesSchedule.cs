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
 
    public partial class ctlMeetingMinutesSchedule : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private BindingSource meetingMinutesScheduleSourceBinding = new BindingSource();
        private DataTable meetingMinutesScheduleDataTable;
        private string jobID;
        private string sort = "";
        private string filter = "";
        private string meetingMinutesScheduleID;
        private string meetingMinutesSubjectID;
        //
        public ctlMeetingMinutesSchedule()
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
                GetMeetingMinutesSchedule();
                SetControlAccess();
            }
        }
        //
        public DataTable MeetingMinutesScheduleDataTable
        {
            get
            {
                return meetingMinutesScheduleDataTable;
            }
        }
        //
        public String MeetingMinutesScheduleID
        {
            get
            {
                return meetingMinutesScheduleID;
            }
        }
        //
        public String MeetingMinutesSubjectID
        {
            get
            {
                return meetingMinutesSubjectID;
            }
        }
        //
        public String MeetingMinutesScheduleSort
        {
            get
            {
                return sort;
            }
        }
        //
        public String MeetingMinutesScheduleFilter
        {
            get
            {
                return filter;
            }
        }
        //
        private void GetMeetingMinutesSchedule()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdMeetingMinutesScheduleView, "ctlMeetingMinutesSchedule");
                }

                meetingMinutesScheduleDataTable = MeetingMinutesSchedule.GetJobMeetingMinutesSchedule(jobID).Tables[0];
                meetingMinutesScheduleSourceBinding.DataSource = meetingMinutesScheduleDataTable;
                grdMeetingMinutesSchedule.DataSource = meetingMinutesScheduleSourceBinding;
                grdMeetingMinutesScheduleView.Columns["MeetingMinutesScheduleID"].Visible = false;
                grdMeetingMinutesScheduleView.Columns["MeetingMinutesSubjectID"].Visible = false;

               // grdSubmittalView.Columns["Date"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
               // grdSubmittalView.Columns["Date"].SummaryItem.DisplayFormat = "{0:n0}";

                grdMeetingMinutesScheduleView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdMeetingMinutesScheduleView, "ctlMeetingMinutesSchedule");

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
                panMeetingMinutesSchedule.Visible = false;
            }
            else
            {
                panMeetingMinutesSchedule.Visible = true;
            }
        }
        //
        private void grdMeetingMinutesScheduleView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdMeetingMinutesScheduleView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                {
                    meetingMinutesScheduleID = "";
                    meetingMinutesSubjectID = "";
                    return;
                }
                meetingMinutesScheduleID = r["MeetingMinutesScheduleID"].ToString();
                meetingMinutesSubjectID = r["MeetingMinutesSubjectID"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmMeetingMinutesSchedule f = new frmMeetingMinutesSchedule("0", jobID,meetingMinutesScheduleSourceBinding );
            f.ShowDialog();
            GetMeetingMinutesSchedule();
        }
        //
        private void grdMeetingMinutesScheduleView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdMeetingMinutesScheduleView.GetDataRow(grdMeetingMinutesScheduleView.GetSelectedRows()[0]);
            if (r == null)
                return;

            frmMeetingMinutesSchedule f = new frmMeetingMinutesSchedule(r["MeetingMinutesScheduleID"].ToString(), jobID, meetingMinutesScheduleSourceBinding);
            f.ShowDialog();
            GetMeetingMinutesSchedule();
        }
        //
        private void grdMeetingMinutesScheduleView_ColumnFilterChanged(object sender, EventArgs e)
        {
             try
            {
                string criteria = "";
                filter = grdMeetingMinutesScheduleView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdMeetingMinutesScheduleView.Columns)
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
                meetingMinutesScheduleDataTable.DefaultView.RowFilter = criteria;
                filter = criteria;
           }
            catch
            {
            }
        }
        //
        private void grdMeetingMinutesScheduleView_MouseUp(object sender, MouseEventArgs e)
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
                meetingMinutesScheduleDataTable.DefaultView.Sort = command;
            }
        }

        private void grdMeetingMinutesScheduleView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    return;
                DataRow r = grdMeetingMinutesScheduleView.GetDataRow(grdMeetingMinutesScheduleView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("You are about to delete the current Meeting Minutes and related Items and Attendees. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("You are sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                MeetingMinutesSchedule.Remove(r["MeetingMinutesScheduleID"].ToString());
                                grdMeetingMinutesScheduleView.DeleteRow(grdMeetingMinutesScheduleView.GetSelectedRows()[0]);
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

        private void grdMeetingMinutesScheduleView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
       // 
    }
}
