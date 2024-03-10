using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;


namespace CCEJobs.Controls
{
    public partial class ctlJobProgressComment : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable commentTable;
        private string jobID = "0";
        private string commentFilter = "";
        private string commentSort = "";
        //
        public ctlJobProgressComment()
        {
            InitializeComponent();
        }
        //
        public string JobID
        {
            set
            {
                {
                    jobID = value;
                    GetComments();
                }
            }
        }
        //
        public string CommentSort
        {
            get { return commentSort; }
        }
        //
        public string CommentFilter
        {
            get { return commentFilter; }
        }
        //
        public DataTable CommentTable
        {
            get { return commentTable; }
        }
        //
        private void GetComments()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobProgressCommentView, "ctlJobProgressComment");
                }

                commentTable = Job.GetProgressComments(jobID).Tables[0];
                grdJobProgressComment.DataSource = commentTable;
                grdJobProgressCommentView.Columns["Comment"].ColumnEdit = repEdit;
                grdJobProgressCommentView.Columns["Comment"].Width = 500;
                grdJobProgressCommentView.RowHeight = 50;
                repEdit.ReadOnly = true;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobProgressCommentView, "ctlJobProgressComment");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdJobProgressCommentView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                commentFilter = grdJobProgressCommentView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdJobProgressCommentView.Columns)
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
                commentTable.DefaultView.RowFilter = criteria;
            }
            catch (Exception ex) { }
        }
        //
        private void grdJobProgressCommentView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.Clicks > 1) return;
            GridView view = sender as GridView;
            Point p = view.GridControl.PointToClient(MousePosition);
            GridHitInfo info = view.CalcHitInfo(p);
            if (info.HitTest == GridHitTest.Column)
            {
                ColumnSortOrder sort = info.Column.SortOrder;
                string command = info.Column.FieldName;
                if (info.Column.SortOrder == ColumnSortOrder.Ascending)
                {
                    command += " DESC";
                    commentSort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    commentSort = info.Column.Caption + " ASC";
                }
                commentTable.DefaultView.Sort = command;
            }
        }

        private void grdJobProgressCommentView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
