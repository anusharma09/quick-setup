using System;
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
using CCEOTProjects.BusinessLayer;



namespace CCEOTProjects.Controls
{
    public partial class ctlProjectAudit : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable auditTable; 
        private string otProjectID = "0";
        private string auditFilter = "";
        private string auditSort = "";
        //
        public ctlProjectAudit()
        {
            InitializeComponent();
        }
        //
        public string OTProjectID
        {
            set
            {
                //if (otProjectID != value)
                {
                    otProjectID = value;
                    GetAudit();
                }
            }
        }
        public string AuditSort
        {
            get { return auditSort; }
        }
        //
        public string AuditFilter
        {
            get { return auditFilter; }
        }
        //
        public DataTable AuditTable
        {
            get { return auditTable; }
        }
        //
        private void GetAudit()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdAuditView, "ctlProjectAudit");
                }

                auditTable = Audit.GetAudit(otProjectID).Tables[0];
                grdAudit.DataSource = auditTable;

                grdAuditView.Columns["Audit"].ColumnEdit = repEdit;
                grdAuditView.Columns["OTAuditID"].Visible = false;
                grdAuditView.Columns["OTProjectID"].Visible = false;
                grdAuditView.Columns["Audit"].Width = 500;
                grdAuditView.RowHeight = 50;
                grdAuditView.Columns["Created By"].OptionsColumn.AllowEdit = false;
                grdAuditView.Columns["Date"].OptionsColumn.AllowEdit = false;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdAuditView, "ctlProjectAudit");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        private void grdNoteView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void grdNoteView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            repEdit.ReadOnly = true;
        }
        //
        private void grdNoteView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdAuditView.GetDataRow(grdAuditView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("Delete Selected Note?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            WebLink.Delete(r[0].ToString());
                            grdAuditView.DeleteRow(grdAuditView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }
        //
        private void grdNoteView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";
                auditFilter = grdAuditView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdAuditView.Columns)
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
                auditTable.DefaultView.RowFilter = criteria;
            }
            catch (Exception ex)
            {
            }
        }

        private void grdNoteView_MouseUp(object sender, MouseEventArgs e)
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
                    auditSort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    auditSort = info.Column.Caption + " ASC";
                }
                auditTable.DefaultView.Sort = command;
            }
        }

        private void grdAuditView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

    }
}
