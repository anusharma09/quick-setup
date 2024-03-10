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
using System.Net.Mail;


namespace CCEOTProjects.Controls
{
    public partial class ctlProjectAssignments : UserControl
    {
        protected bool bColumnWidthChanged = false;
        DataTable assignmentTable; 
        private string otProjectID = "0";
        private string assignmentFilter = "";
        private string assignmentFilterField = "";
        private string assignmentSort = "";
        private string assignmentSortField = "";
        private bool rowChanged = false;
        //
        public ctlProjectAssignments()
        {
            InitializeComponent();
        }
        //
        public string OTProjectID
        {
            set
            {
                 if (otProjectID != value)
                {
                    otProjectID = value;
                    GetAssignment();
                    rowChanged = false;
                }
            }
        }
        //
        public bool IsRowChanged()
        {
            if (rowChanged)
            {
                MessageBox.Show("Please save Assignment.", CCEApplication.ApplicationName);
            }
            return rowChanged;    
        }
        public string AssignmentSort
        {
            get { return assignmentSort; }
        }
        public string AssignmentSortField
        {
            get { return assignmentSortField; }
        }
        //
        public string AssignmentFilter
        {
            get { return assignmentFilter; }
        }
        //
        public string AssignmentFilterField
        {
            get { return assignmentFilterField; }
        }
        //
        public DataTable AssignmentTable
        {
            get { return assignmentTable; }
        }
        //
        private void GetAssignment()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdAssignmentView, "ctlProjectAssignments");
                }

                assignmentTable = Assignment.GetAssignment(otProjectID).Tables[0];
                grdAssignment.DataSource = assignmentTable;
                grdAssignmentView.Columns["OTAssignmentID"].Visible = false;
                grdAssignmentView.Columns["OTProjectID"].Visible = false;
                grdAssignmentView.Columns["AssignedFrom"].Caption = "Assigned By";
                grdAssignmentView.Columns["AssignedTo"].Caption = "Assigned To";
                grdAssignmentView.Columns["AssignedDate"].Caption = "Assigned Date";
                grdAssignmentView.Columns["AcceptedBy"].Caption = "Accepted By";
                grdAssignmentView.Columns["AcceptedDate"].Caption = "Accepted Date";
                grdAssignmentView.Columns["CompletedBy"].Caption = "Completed By";
                grdAssignmentView.Columns["CompletedDate"].Caption = "Completed Date";
                grdAssignmentView.Columns["Description"].ColumnEdit = repEdit;
                grdAssignmentView.Columns["Description"].Width = 500;
                //grdAssignmentView.RowHeight = 50;
                grdAssignmentView.Columns["AssignedFrom"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["AssignedTo"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["AssignedDate"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["Description"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["Accepted"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["AcceptedBy"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["AcceptedDate"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["Completed"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["CompletedBy"].OptionsColumn.AllowEdit = false;
                grdAssignmentView.Columns["CompletedDate"].OptionsColumn.AllowEdit = false;
                //
                grdAssignmentView.Columns["AssignedFrom"].ColumnEdit = BusinessLayer.StaticTables.RepLANID;
                grdAssignmentView.Columns["AssignedTo"].ColumnEdit = BusinessLayer.StaticTables.RepLANID;
                grdAssignmentView.Columns["AcceptedBy"].ColumnEdit = BusinessLayer.StaticTables.RepLANID;
                grdAssignmentView.Columns["CompletedBy"].ColumnEdit = BusinessLayer.StaticTables.RepLANID;
                // date formating
                grdAssignmentView.Columns["AssignedDate"].ColumnEdit = repDate;
                grdAssignmentView.Columns["AcceptedDate"].ColumnEdit = repDate;
                grdAssignmentView.Columns["CompletedDate"].ColumnEdit = repDate;
                rowChanged = false;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdAssignmentView, "ctlProjectAssignments");


               // if (assignmentTable.Rows.Count > 0)
               // {
               // }
                if (assignmentTable.Rows.Count > 0)
                {
                   // grdAssignmentView.Focus();
                    try
                    {
                        DataRow r = grdAssignmentView.GetDataRow(grdAssignmentView.GetSelectedRows()[0]);
                        if (r != null)
                            AssignmentRowSetup(r);
                    }
                    catch { }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        private void grdAssignmentView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void grdAssignmentView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;

            //DataRow r =  grdAssignmentView.GetDataRow(grdAssignmentView.GetSelectedRows()[0]);
            DataRowView r = (DataRowView) e.Row;


            if (r == null)
            {
                //rowChanged = false;
                return;
            }
            if (r["Description"].ToString().Trim() == "" && r["AssignedTo"].ToString().Trim() == "")
            {
                //rowChanged = false;
                return;
            }
            if (r["Description"].ToString().Trim() == "" || r["AssignedTo"].ToString().Trim() == "")
            {
                MessageBox.Show("Please enter Assigned To & Description", CCEApplication.ApplicationName);
                valid = false;
                e.Valid = false;
                return;
            }
            if (valid)
            {
                DialogResult result;
                result = MessageBox.Show("Save Assignment?", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(r["AssignedTo"].ToString()) && (String.IsNullOrEmpty(r["AssignedFrom"].ToString()) || r["AssignedFrom"].ToString().Trim().Length == 0))
                        {
                            r["AssignedFrom"] = Security.Security.LoginID.ToUpper().ToUpper();
                            r["AssignedDate"] = DateTime.Now.ToString();
                        }

                        if ((r["Accepted"].ToString() == "True") && (String.IsNullOrEmpty(r["AcceptedBy"].ToString()) || r["AcceptedBy"].ToString().Trim().Length == 0))
                        {
                            r["AcceptedBy"] = Security.Security.LoginID.ToUpper();
                            r["AcceptedDate"] = DateTime.Now.ToString();
                        }

                        if ((r["Completed"].ToString() == "True") && (String.IsNullOrEmpty(r["CompletedBy"].ToString()) || r["CompletedBy"].ToString().Trim().Length == 0))
                        {
                            r["CompletedBy"] = Security.Security.LoginID.ToUpper();
                            r["CompletedDate"] = DateTime.Now.ToString();
                        }

                        Assignment assignment = new Assignment(r["OTAssignmentID"].ToString(),
                                                otProjectID,
                                            r["AssignedTo"].ToString(),
                                            r["AssignedFrom"].ToString(),
                                            r["AssignedDate"].ToString(),
                                            r["Description"].ToString(),
                                            r["Accepted"].ToString(),
                                            r["AcceptedBy"].ToString(),
                                            r["AcceptedDate"].ToString(),
                                            r["Completed"].ToString(),
                                            r["CompletedBy"].ToString(),
                                            r["CompletedDate"].ToString());
                        assignment.Save();
                        r["OTAssignmentID"] = assignment.AssignmentID;
                        AssignmentEmail(r["OTAssignmentID"].ToString());
                        rowChanged = false;
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
                        rowChanged = false;
                        return;
                    }
                    if (r["OTAssignmentID"] == DBNull.Value)
                    {
                        grdAssignmentView.DeleteRow(e.RowHandle);
                        r.CancelEdit();
                        //rowChanged = false;
                    }
                    else
                    {
                        r.CancelEdit();
                        //rowChanged = false;
                    }
                }
            }
            else
            {
                if (r["OTAssignmentID"] == DBNull.Value)
                {
                    grdAssignmentView.DeleteRow(e.RowHandle);
                    //r.CancelEdit();
                }
                else
                {
                    e.Valid = false;
                    rowChanged = false;
                }
            }
        }
        //
        private void grdAssignmentView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = grdAssignmentView.GetDataRow(e.FocusedRowHandle);
            AssignmentRowSetup(r);
        
        }
        private void AssignmentRowSetup(DataRow r)
        {
            if (r == null)
            {
                try
                {
                    grdAssignmentView.Columns["AssignedTo"].OptionsColumn.AllowEdit = true;
                    grdAssignmentView.Columns["Description"].OptionsColumn.AllowEdit = true;
                }
                catch { }
            }
            else
            {
                try
                {
                    grdAssignmentView.Columns["AssignedTo"].OptionsColumn.AllowEdit = false;
                    grdAssignmentView.Columns["Description"].OptionsColumn.AllowEdit = false;
                    grdAssignmentView.Columns["Accepted"].OptionsColumn.AllowEdit = false;
                    grdAssignmentView.Columns["Completed"].OptionsColumn.AllowEdit = false;

                    if (String.IsNullOrEmpty(r["AssignedFrom"].ToString()) || r["AssignedFrom"].ToString().Trim() == "")
                    {
                        grdAssignmentView.Columns["AssignedTo"].OptionsColumn.AllowEdit = true;
                        grdAssignmentView.Columns["Description"].OptionsColumn.AllowEdit = true;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(r["AcceptedBy"].ToString()) || r["AcceptedBy"].ToString().Trim() == "")
                        {
                            grdAssignmentView.Columns["Accepted"].OptionsColumn.AllowEdit = true;
                            grdAssignmentView.Columns["Description"].OptionsColumn.AllowEdit = true;
                        }
                        else
                        {
                            if (String.IsNullOrEmpty(r["CompletedBy"].ToString()) || r["CompletedBy"].ToString().Trim() == "")
                            {
                                grdAssignmentView.Columns["Completed"].OptionsColumn.AllowEdit = true;
                                grdAssignmentView.Columns["Description"].OptionsColumn.AllowEdit = true;
                            }
                        }
                    }
                }
                catch { }
            }
        }
        //
        private void grdAssignmentView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdAssignmentView.GetDataRow(grdAssignmentView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("Delete Selected Assignment?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Assignment.Delete(r[0].ToString());
                            grdAssignmentView.DeleteRow(grdAssignmentView.GetSelectedRows()[0]);
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
        private void grdAssignmentView_ColumnFilterChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = "";

                assignmentFilterField = "";
                assignmentFilter = grdAssignmentView.FilterPanelText;

                foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdAssignmentView.Columns)
                {
                    if (col.FilterInfo.FilterCriteria != null)
                    {
                        if (col.FilterInfo.FilterCriteria.ToString().Length > 0)
                        {
                            criteria += col.FilterInfo.FilterCriteria.ToString();
                            criteria += " AND ";
                            assignmentFilterField += col.FilterInfo.FilterString.ToString();
                            assignmentFilterField += " AND ";

                        }
                    }
                }
                if (criteria.Length > 0)
                {
                    criteria = criteria.Substring(0, criteria.Length - 4);
                    assignmentFilterField = assignmentFilterField.Substring(0, assignmentFilterField.Length - 4);
                }
                assignmentTable.DefaultView.RowFilter = criteria;
            }
            catch (Exception ex)
            {
            }
        }
        //
        private void grdAssignmentView_MouseUp(object sender, MouseEventArgs e)
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
                    assignmentSort = info.Column.Caption + " DESC";
                    assignmentSortField = info.Column.FieldName + " DESC";
                }
                else
                {
                    command += " ASC ";
                    assignmentSort = info.Column.Caption + " ASC";
                    assignmentSortField = info.Column.FieldName + " ASC";
                }
                assignmentTable.DefaultView.Sort = command;
            }
        }

        private void AssignmentEmail(string otAssignmentID)
        {
            MailMessage message;
            SmtpClient client;
            //
            try
            {

                DataTable table = Assignment.GetAssigedToEmail(otAssignmentID).Tables[0];

                if (table.Rows.Count > 0)
                {
                    message = new MailMessage(
                         "sg3admin@dyna-sd.com",
                         "sg3admin@dyna-sd.com",
                         "Project Opportunity Assignment",
                          "");
                    message.To.Clear();
                    if (table.Rows[0]["AssignedTo"].ToString().ToUpper()  != Security.Security.LoginID.ToUpper())
                        message.To.Add(table.Rows[0]["AssignedToEmail"].ToString());
                    if (table.Rows[0]["AssignedFrom"].ToString().ToUpper() != Security.Security.LoginID.ToUpper())
                        message.To.Add(table.Rows[0]["AssignedFromEmail"].ToString());


                    string accepted = table.Rows[0]["Accepted"].ToString() == "False" ? "No" : "Yes";
                    string completed = table.Rows[0]["Completed"].ToString() == "False" ? "No" : "Yes";


                    message.Body = "Project Opportunity Assignment: \n\n" +
                                    "     Project Number: " + table.Rows[0]["OTProjectNumber"].ToString() + "\n" +
                                    "      Project Name : " + table.Rows[0]["OTProjectName"].ToString() + "\n" +
                                    "        Assigned By: " + table.Rows[0]["AssignedFromName"].ToString() + "\n" +
                                    "        Assigned To: " + table.Rows[0]["AssignedToName"].ToString() + "\n" +
                                    "      Assigned Date: " + String.Format("{0:d}", table.Rows[0]["AssignedDate"].ToString()) + "\n" +
                                    "        Description: " + table.Rows[0]["Description"].ToString() + "\n" +
                                    "           Accepted: " + accepted + "\n" +
                                    "        Accepted By: " + table.Rows[0]["AcceptedByName"].ToString() + "\n" +
                                    "      Accepted Date: " + String.Format("{0:d}", table.Rows[0]["AcceptedDate"].ToString()) + "\n" +
                                    "          Completed: " + completed + "\n" +
                                    "       Completed By: " + table.Rows[0]["CompletedByName"].ToString() + "\n" +
                                    "     Completed Date: " + String.Format("{0:d}", table.Rows[0]["CompletedDate"].ToString());


                      

                    if (message.To.Count > 0)
                    {
                        client = new SmtpClient("10.1.3.15");
                        client.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            message = null;
            client = null;
        }

        private void grdAssignmentView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            rowChanged = true;
        }

        private void grdAssignmentView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
