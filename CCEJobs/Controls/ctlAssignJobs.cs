using DevExpress.XtraGrid.Views.Base;
using JCCBusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;
namespace CCEJobs.Controls
{

    public partial class ctlAssignJobs : UserControl
    {
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private DataSet jobAssignedUsersDataSet;
        private string jobID;

        public ctlAssignJobs ()
        {
            InitializeComponent();
        }
        
        public Security.Security.JobCaller JobCaller
        {
            set => jobCaller = value;
        }
        
        public string JobID
        {
            set
            {
                jobID = value;
                if (jobID == "")
                {
                    jobID = "0";
                }

                GetJobContact();
            }
        }

        
        private void GetJobContact ()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdUserView, "ctlJobContact");
                }

                jobAssignedUsersDataSet = Contact.GetAssignedUsers(jobID);

                grdUser.DataSource = jobAssignedUsersDataSet.Tables[0].DefaultView;

                grdUserView.Columns["UserID"].Visible = false;
                grdUserView.Columns["UserLANID"].OptionsColumn.AllowEdit = false;
                grdUserView.Columns["UserName"].OptionsColumn.AllowEdit = false;
                grdUserView.Columns["Email"].OptionsColumn.AllowEdit = false;
                grdUserView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdUserView, "ctlJobContact");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void ctlAssignJobs_Load ( object sender, EventArgs e )
        {
            GetComboList();
        }

        private void GetComboList ()
        {
            if (jobID != "0" && jobID != "")
            {

                cboUserName.Properties.DataSource = Contact.GetUsers().Tables[0];
                cboUserName.Properties.DisplayMember = "UserLANID";
                cboUserName.Properties.PopulateColumns();
                cboUserName.Properties.ShowHeader = false;
            }
        }
        //
        private void btnProcess_Click ( object sender, EventArgs e )
        {

            if (cboUserName.Text.Trim().Length > 0)
            {
                string userName = "";
                userName = cboUserName.Text.Trim();
                DataTable t = Contact.GetUserList(userName).Tables[0];
                foreach (DataRow r in t.Rows)
                {
                    DataRow[] dr = jobAssignedUsersDataSet.Tables[0].Select("UserLANID = '" + r["UserLANID"].ToString() + "'");
                    if (dr.Length == 0)
                    {
                        jobAssignedUsersDataSet.Tables[0].ImportRow(r);
                    }
                    else
                        MessageBox.Show("User already added to the list.");
                }
                cboUserName.EditValue = null;
               // btnAssignUser.Visible = true;
            }
        }
        private void grdUserView_RowUpdated ( object sender, RowObjectEventArgs e )
        {
            btnAssignUser.Visible = true;
        }

        private void grdUserView_InvalidRowException ( object sender, InvalidRowExceptionEventArgs e )
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
        }

        private void grdUserView_ColumnWidthChanged ( object sender, ColumnEventArgs e )
        {
            bColumnWidthChanged = true;
        }
        private void grdUserView_CellValueChanged ( object sender, CellValueChangedEventArgs e )
        {
            btnAssignUser.Visible = true;
        }


        private void btnAssignUser_Click ( object sender, EventArgs e )
        {
            try
            {
                foreach (DataRow r in jobAssignedUsersDataSet.Tables[0].Rows)
                {
                    int userID = Convert.ToInt32(r["UserID"]);
                    if (r["Selected"].ToString() == "True")
                    {
                        Contact.AssignUserToJob(jobID, userID, Convert.ToBoolean(r["ReadOnly"]));
                    }
                    if (r["Selected"].ToString() != "True")
                    {
                        Contact.DeleteAssignedUserToJob(jobID, userID, Convert.ToBoolean(r["ReadOnly"]));
                    }
                }
                MessageBox.Show("User(s) assigned to job successfully.");
                btnAssignUser.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToErrorLog(ex, CCEApplication.LogFile);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
