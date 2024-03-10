using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;

namespace CCEJobs.Controls
{
    public partial class ctlJobBiddingContractor : UserControl
    {  
        //
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private DataTable jobBiddingContractorDataTable;
        private string jobID;
        private bool isLoaded = false;
        protected bool bColumnWidthChanged = false;
        //
        public ctlJobBiddingContractor()
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
                if (!isLoaded)
                {
                    repEstimator.DataSource = JCCBusinessLayer.StaticTables.Estimator;
                    repEstimator.DisplayMember = "Description";
                    repEstimator.ValueMember = "EstimatorID";
                    repEstimator.PopulateColumns();
                    repEstimator.Columns[0].Visible = false;
                    isLoaded = true;
                }
                GetJobBiddingContractor();
                SetControlAccess();
            }
        }
        //
        private void GetJobBiddingContractor()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdJobBiddingContractorView, "ctlJobBiddingContractor");
                }

                repContractor.DataSource = Contact.GetJobContactCompanyForPullDown(jobID).Tables[0];
                repContractor.DisplayMember = "Company";
                repContractor.ValueMember = "ContactID";
                repContractor.PopulateColumns();
                repContractor.Columns[0].Visible = false;
                //
                jobBiddingContractorDataTable = JobBiddingContractor.GetJobBiddingContractorList(jobID).Tables[0];
                grdJobBiddingContractor.DataSource = jobBiddingContractorDataTable;
                grdJobBiddingContractorView.Columns["JobBiddingContractorID"].Visible = false;
                grdJobBiddingContractorView.Columns["JobID"].Visible = false;
                grdJobBiddingContractorView.Columns["Contractor"].ColumnEdit = repContractor;
                grdJobBiddingContractorView.Columns["Estimator"].ColumnEdit = repEstimator;
                grdJobBiddingContractorView.Columns["Status"].ColumnEdit = repStatus;
                grdJobBiddingContractorView.Columns["Amount"].ColumnEdit = repAmount;
                grdJobBiddingContractorView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdJobBiddingContractorView, "ctlJobBiddingContractor");

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
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                grdJobBiddingContractorView.OptionsBehavior.Editable = false;
                grdJobBiddingContractorView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            }
            else
            {
                grdJobBiddingContractorView.OptionsBehavior.Editable = true;
                grdJobBiddingContractorView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            }
        }
       
        //
        private void grdJobBiddingContractorView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        //
        private void grdJobBiddingContractorView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow r;
            bool valid = true;
            string message = "Make sure to enter the following:\r" +
                            "Contractor \r" +
                            "Status\r" +
                            "Estimator\r" +
                            "Amount";

            r = grdJobBiddingContractorView.GetDataRow(grdJobBiddingContractorView.GetSelectedRows()[0]);
            if (MessageBox.Show("Save Contractor Bid?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (r[2].ToString().Trim().Length == 0)
                    valid = false;
                if (r[3].ToString().Trim().Length == 0)
                    valid = false;
                if (r[4].ToString().Trim().Length == 0)
                    valid = false;
                if (r[5].ToString().Trim().Length == 0)
                    valid = false;
            
                if (!valid)
                {
                    MessageBox.Show(message, CCEApplication.ApplicationName);
                    e.Valid = false;
                }
                else
                    SaveContractorBid();
            }
            else
            {
                string jobBiddingContractorID = r[0].ToString();
                if (jobBiddingContractorID == "")
                {
                    grdJobBiddingContractorView.DeleteSelectedRows();
                }
                else
                    r.CancelEdit();
            }
        }
        //
        private void SaveContractorBid()
        {

            try
            {
                DataRow r;

                r = grdJobBiddingContractorView.GetDataRow(grdJobBiddingContractorView.GetSelectedRows()[0]);
                if (r != null)
                {
                    JobBiddingContractor contractor = new JobBiddingContractor(r[0].ToString().Trim().Length == 0 ? "0" : r[0].ToString(),
                                                    jobID,
                                                    r[2].ToString(),
                                                    r[3].ToString(),
                                                    r[4].ToString(),
                                                    r[5].ToString());

                    contractor.Save();
                    r[0] = contractor.JobBiddingContractorID;
                    r[1] = jobID;
                    r.EndEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void grdJobBiddingContractorView_KeyUp(object sender, KeyEventArgs e)
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                return;
            if (e.KeyCode.ToString() == "Delete")
                DeleteContractorBid();
        }
        //
        private void DeleteContractorBid()
        {
            DataRow r = grdJobBiddingContractorView.GetDataRow(grdJobBiddingContractorView.GetSelectedRows()[0]);
            if (r == null)
                return;
            string id = r[0].ToString();
            if (id == "")
                return;
            if (MessageBox.Show("Delete selected Contractor Bid?", CCEApplication.ApplicationName,
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    JobBiddingContractor.Delete(id);
                    r.Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }
        }

        private void grdJobBiddingContractorView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
