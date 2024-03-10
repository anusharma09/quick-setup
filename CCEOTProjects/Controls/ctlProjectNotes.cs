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
    public partial class ctlProjectNotes : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable noteTable; 
        private string otProjectID = "0";
        private string noteFilter = "";
        private string noteSort = "";
        //
        public ctlProjectNotes()
        {
            InitializeComponent();
        }
        //
        public string OTProjectID
        {
            set
            {
                {
                    otProjectID = value;
                    GetNotes();
                }
            }
        }
        //
        public string NoteSort
        {
            get { return noteSort; }
        }
        //
        public string NoteFilter
        {
            get { return noteFilter; }
        }
        //
        public DataTable NoteTable
        {
            get { return noteTable; }
        }
        //
        private void GetNotes()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdNoteView, "ctlProjectNotes");
                }

                noteTable = Note.GetNotes(otProjectID).Tables[0];
                grdNote.DataSource = noteTable;

                grdNoteView.Columns["Note"].ColumnEdit = repEdit;
                grdNoteView.Columns["OTNoteID"].Visible = false;
                grdNoteView.Columns["OTProjectID"].Visible = false;
                grdNoteView.Columns["Note"].Width = 500;
                grdNoteView.RowHeight = 50;
                grdNoteView.Columns["Created By"].OptionsColumn.AllowEdit = false;
                grdNoteView.Columns["Date"].OptionsColumn.AllowEdit = false;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdNoteView, "ctlProjectNotes");

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
        private void grdNoteView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;

            DataRow r = grdNoteView.GetDataRow(grdNoteView.GetSelectedRows()[0]);
            if (r["Note"].ToString().Trim() == "")
            {
                valid = false;
            }
            if (valid)
            {
                DialogResult result;
                result = MessageBox.Show("Save Note?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Note note = new Note(r["OTNoteID"].ToString(),
                                                otProjectID,
                                            r["Note"].ToString(),
                                            Security.Security.LoginID.ToUpper(),
                                            DateTime.Now.ToShortDateString());
                        note.Save();
                        r["OTNoteID"] = note.NoteID;
                        r["Created By"] = Security.Security.LoginID.ToUpper();
                        r["Date"] = DateTime.Now.ToShortDateString();
                        this.Cursor = Cursors.Default;
                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                }
                else
                {
                    if (result == DialogResult.Cancel)
                    {
                        e.Valid = false;
                        return;
                    }
                    if (r["OTNoteID"] == DBNull.Value)
                    {
                        grdNoteView.DeleteRow(e.RowHandle);
                        r.CancelEdit();
                    }
                    else
                    {
                        r.CancelEdit();
                    }
                }
            }
            else
            {
                if (r["OTNoteID"] == DBNull.Value)
                {
                    grdNoteView.DeleteRow(e.RowHandle);
                    r.CancelEdit();
                }
                else
                    e.Valid = false;
            }
        }
        //
        private void grdNoteView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = grdNoteView.GetDataRow(e.FocusedRowHandle);
            if (r == null)
            {
                repEdit.ReadOnly = false;
               // grdNoteView.OptionsBehavior.Editable = true;
            }
            else
            {
                repEdit.ReadOnly = true;
                //grdNoteView.OptionsBehavior.Editable = false;
            }
        }
        //
        private void grdNoteView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdNoteView.GetDataRow(grdNoteView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("Delete Selected Note?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            WebLink.Delete(r[0].ToString());
                            grdNoteView.DeleteRow(grdNoteView.GetSelectedRows()[0]);
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
                noteFilter = grdNoteView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdNoteView.Columns)
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
                noteTable.DefaultView.RowFilter = criteria;
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
                    noteSort = info.Column.Caption + " DESC";
                }
                else
                {
                    command += " ASC ";
                    noteSort = info.Column.Caption + " ASC";
                }
                noteTable.DefaultView.Sort = command;
            }
        }

        private void grdNoteView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

    }
}
