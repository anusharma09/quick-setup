using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Security.BusinessLayer;

namespace Security
{
    partial class frmSecurityMaintenance : Form
    {
        private string userID = "";

        public frmSecurityMaintenance()
        {
            InitializeComponent();
        }
        //
        private void frmSecurityMaintenance_Load(object sender, EventArgs e)
        {
             GetUsers();
        }
        //
        private void GetUsers()
        {
            grdUser.DataSource = User.GetUsers().Tables[0];

            grdUserView.Columns["User LANID"].ColumnEdit = repLANID;
            grdUserView.Columns["User Name"].ColumnEdit = repUserName;
            grdUserView.Columns["Email"].ColumnEdit = repEmail;
            grdUserView.Columns["Office"].ColumnEdit = StaticTables.Office;
            grdUserView.Columns["Department"].ColumnEdit = StaticTables.Department;
            grdUserView.Columns["Project Manager"].ColumnEdit = StaticTables.ProjectManager;
            grdUserView.Columns["Estimator"].ColumnEdit = StaticTables.Estimator;
            grdUserView.Columns["Sales Rep"].ColumnEdit = StaticTables.SalesRep;
            grdUserView.Columns["Job Tech"].ColumnEdit = StaticTables.JobTech;
            grdUserView.Columns["Title"].ColumnEdit = StaticTables.AccessTitle;

            grdUserView.Columns["Office"].Visible = false;
            grdUserView.Columns["Department"].Visible = false;
            grdUserView.Columns["Project Manager"].Visible = false;
            grdUserView.Columns["Estimator"].Visible = false;
            grdUserView.Columns["Sales Rep"].Visible = false;
            grdUserView.Columns["Job Tech"].Visible = false;


            grdUserView.Columns["Job Tech"].Caption = "Tech Rep";
            grdUserView.Columns["UserID"].Visible = false;
            grdUserView.BestFitColumns();
            grdUserView.Columns["Title"].Width = 75;
        }

        private void grdUserView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdUserView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DataRow r = grdUserView.GetDataRow(grdUserView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save User Changes?", Security.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["User LanID"].ToString().Trim() == "")
                {
                    message = "User LANID is Required ..\n";
                    valid = false;
                }
                if (r["User Name"].ToString().Trim() == "")
                {
                    message = message + "User Name is Required ..\n";
                    valid = false;
                }
                if (r["Office"].ToString().Trim() == "")
                {
                 //   message = message + "Office is Required ..\n";
                 //   valid = false;
                }
                if (r["Department"].ToString().Trim() == "")
                {
                   // message = message + "Department is Requred ..\n";
                   // valid = false;
                }
                if (valid)
                {
                    UpdateUser();
                }
                else
                {
                    MessageBox.Show(message, Security.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["UserID"] == DBNull.Value)
                    grdUserView.DeleteRow(e.RowHandle);
                r.CancelEdit();
            }
        }
        //
        private void UpdateUser()
        {
            if (grdUserView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdUserView.GetDataRow(grdUserView.GetSelectedRows()[0]);
                this.Cursor = Cursors.AppStarting;
                if (r == null)
                    return;


                try
                {
                    User  user = new User(r["UserID"].ToString(),
                                        r["User LANID"].ToString(),
                                        r["User Name"].ToString(),
                                        r["Email"].ToString(),
                                        r["Office"].ToString(),
                                        r["Department"].ToString(),
                                        r["Project Manager"].ToString(),
                                        r["Estimator"].ToString(),
                                        r["Sales Rep"].ToString(),
                                        r["Job Tech"].ToString(),
                                        r["Title"].ToString(),
                                        r["Email"].ToString());
                    user.Save();
                    userID = user.UserID;
                    this.Cursor = Cursors.Default;
                    r["UserID"] = userID;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, Security.ApplicationName);
                }
            }
        }

        private void grdUserView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdUserView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdUserView.GetDataRow(grdUserView.GetSelectedRows()[0]);
                if (r == null )
                {
                    userID = "0";
                    GetUserAccess();
                    GetUserJob();
                }
                else
                {
                    userID = r["UserID"].ToString();
                    GetUserAccess();
                    GetUserJob();
                }
            }

        }
        //
        private void GetUserAccess()
        {
            grdUserAccess.DataSource = UserAccess.GetUserAccess(userID).Tables[0];

            grdUserAccessView.Columns["Office"].ColumnEdit = StaticTables.Office;
            grdUserAccessView.Columns["Department"].ColumnEdit = StaticTables.Department;
            grdUserAccessView.Columns["Work Type"].ColumnEdit = StaticTables.WorkType;
            grdUserAccessView.Columns["Access"].ColumnEdit = StaticTables.Access;
            grdUserAccessView.Columns["Access Level"].ColumnEdit = StaticTables.AccessLevel;
            
            grdUserAccessView.Columns["UserAccessID"].Visible = false;
            grdUserAccessView.Columns["UserID"].Visible = false;
            grdUserAccessView.BestFitColumns();
            if (userID == "0")
                grdUserAccessView.OptionsBehavior.Editable = false;
            else
                grdUserAccessView.OptionsBehavior.Editable = true;
            grdUserAccessView.BestFitColumns();
        }
        //
        private void GetUserJob()
        {
            grdUserJob.DataSource = UserJob.GetUserJob(userID).Tables[0];

            grdUserJobView.Columns["Job Number"].ColumnEdit = repJobNumber;
            grdUserJobView.Columns["Invoice Approval"].Visible = false;
            grdUserJobView.Columns["UserJobID"].Visible = false;
            grdUserJobView.Columns["UserID"].Visible = false;
            grdUserJobView.BestFitColumns();
            if (userID == "0")
                grdUserJobView.OptionsBehavior.Editable = false;
            else
                grdUserJobView.OptionsBehavior.Editable = true;
            grdUserJobView.BestFitColumns();
        }
        //
        private void grdUserAccessView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DataRow r = grdUserAccessView.GetDataRow(grdUserAccessView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save User Access?", Security.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["Access"].ToString().Trim() == "")
                {
                    message = "Access is Required ..\n";
                    valid = false;
                }
                if (r["Access Level"].ToString().Trim() == "")
                {
                    message = "Access Level is Required ..\n";
                    valid = false;
                }

                if (valid)
                {
                    UpdateUserAccess();
                }
                else
                {
                    MessageBox.Show(message, Security.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["UserAccessID"] == DBNull.Value)
                    grdUserAccessView.DeleteRow(e.RowHandle);
                r.CancelEdit();
            }
        }
        //
        private void grdUserAccessView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void grdUserJobView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

            bool valid = true;
            string message = "";
            DataRow r = grdUserJobView.GetDataRow(grdUserJobView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Job?", Security.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["Job Number"].ToString().Trim() == "")
                {
                    message = "Job Number is Required ..\n";
                    valid = false;
                }
                if (valid)
                {
                    UpdateUserJob();
                }
                else
                {
                    MessageBox.Show(message, Security.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["UserJobID"] == DBNull.Value)
                    grdUserJobView.DeleteRow(e.RowHandle);
                r.CancelEdit();
            }
        }
        //
        private void grdUserJobView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void UpdateUserJob()
        {
            if (grdUserJobView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdUserJobView.GetDataRow(grdUserJobView.GetSelectedRows()[0]);
                if (r == null)
                    return;
                this.Cursor = Cursors.AppStarting;
                try
                {
                    UserJob userJob = new UserJob(r["UserJobID"].ToString(),
                                        userID,
                                        r["Job Number"].ToString(), r["Invoice Approval"].ToString(), r["Read Only"].ToString());
                    userJob.Save();
                    r["UserJobID"] = userJob.UserJobID;
                    this.Cursor = Cursors.Default;
                    
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, Security.ApplicationName);
                }
            }
        }
        //
        private void UpdateUserAccess()
        {
            if (grdUserAccessView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdUserAccessView.GetDataRow(grdUserAccessView.GetSelectedRows()[0]);
                if (r == null)
                    return;
                this.Cursor = Cursors.AppStarting;
                try
                {
                    UserAccess userAccess = new UserAccess(r["UserAccessID"].ToString(),
                                        userID,
                                        r["Access"].ToString(),
                                        r["Access Level"].ToString(),
                                        r["Office"].ToString(),
                                        r["Department"].ToString(),
                                        r["Work Type"].ToString());
                    userAccess.Save();
                    r["UserAccessID"] = userAccess.UserAccessID;
                    this.Cursor = Cursors.Default;

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, Security.ApplicationName);
                }
            }
        }
        //
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mnuAbout":
                    frmAbout frmAbount = new frmAbout();
                    frmAbount.ShowDialog();
                    break;
                case "mnuExit":
                    this.Close();
                    break;

            }
        }
        //
        private void grdUserJobView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdUserJobView.GetDataRow(grdUserJobView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {
                    if (MessageBox.Show("Delete Selected Job?", Security.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            UserJob.Delete(r[0].ToString());
                            grdUserJobView.DeleteRow(grdUserJobView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Security.ApplicationName);
                        }
                    }
                }
            }
        }
        //
        private void grdUserAccessView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdUserAccessView.GetDataRow(grdUserAccessView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Access?", Security.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            UserAccess.Delete(r[0].ToString());
                            grdUserAccessView.DeleteRow(grdUserAccessView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Security.ApplicationName);
                        }
                    }
                }
            }
        }
        //
        private void grdUserView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdUserView.GetDataRow(grdUserView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected User?", Security.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            User.Delete(r[0].ToString());
                            grdUserView.DeleteRow(grdUserView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, Security.ApplicationName);
                        }
                    }
                }
            }
        }

    }
}