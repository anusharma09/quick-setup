using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCEOTProjects.BusinessLayer;
using CCEOTProjects.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CCEOTProjects.Controls
{
    public partial class ctlOpportunityEstimateTrackingReport : UserControl
    {
        public ctlOpportunityEstimateTrackingReport()
        {
            InitializeComponent();
            PopulateLists();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            int         i = 0;
            string      opportunityQuery = "";
            string      estimateQuery = "";

            opportunityQuery = " WHERE (OTStatusDescription <> 'APPROVED') ";
            estimateQuery = " WHERE (JobStatus <> 'WON')  AND (j.EstimateNumber > ' ') ";
            //
            if (txtBidDateFrom.Text.Length > 0 && txtBidDateTo.Text.Length > 0)
            {
                opportunityQuery += " AND (p.BidDate BETWEEN '" + txtBidDateFrom.Text + "' AND '" + txtBidDateTo.Text + "') ";
                estimateQuery += " AND (j.BidDate BETWEEN '" + txtBidDateFrom.Text + "' AND '" + txtBidDateTo.Text + "') ";
            }
            else
            {
                if (txtBidDateFrom.Text.Length > 0)
                {
                    opportunityQuery += " AND (p.BidDate >= '" + txtBidDateFrom.Text + "') ";
                    estimateQuery += " AND (j.BidDate >= '" + txtBidDateFrom.Text + "') ";
                }
                if (txtBidDateTo.Text.Length > 0)
                {
                    opportunityQuery += " AND (p.BidDate >= '" + txtBidDateTo.Text + "') ";
                    estimateQuery += " AND (j.BidDate >= '" + txtBidDateTo.Text + "') ";
                }
            }
            //
            if (lstOffice.CheckedItems.Count > 0)
            {
                opportunityQuery += " AND  p.OfficeID IN(";
                estimateQuery += " AND  j.OfficeID IN(";
                for (i = 0; i < lstOffice.ItemCount; i++)
                {
                    if (lstOffice.GetItemChecked(i))
                    {
                        opportunityQuery += lstOffice.GetItemValue(i).ToString() + ",";
                        estimateQuery += lstOffice.GetItemValue(i).ToString() + ",";
                    }
                }
                opportunityQuery = opportunityQuery.Remove(opportunityQuery.Length - 1, 1) + ") ";
                estimateQuery = estimateQuery.Remove(estimateQuery.Length - 1, 1) + ") ";
            }
            //
            if (lstDepartment.CheckedItems.Count > 0)
            {
                opportunityQuery += " AND  p.DepartmentID IN(";
                estimateQuery += " AND  j.DepartmentID IN(";
                for (i = 0; i < lstDepartment.ItemCount; i++)
                {
                    if (lstDepartment.GetItemChecked(i))
                    {
                        opportunityQuery += lstDepartment.GetItemValue(i).ToString() + ",";
                        estimateQuery += lstDepartment.GetItemValue(i).ToString() + ",";
                    }
                }
                opportunityQuery = opportunityQuery.Remove(opportunityQuery.Length - 1, 1) + ") ";
                estimateQuery = estimateQuery.Remove(estimateQuery.Length - 1, 1) + ") ";
            }
            //
            if (lstProjectStatus.CheckedItems.Count > 0)
            {
                opportunityQuery += " AND  p.OTProjectStatusID IN(";
                for (i = 0; i < lstProjectStatus.ItemCount; i++)
                {
                    if (lstProjectStatus.GetItemChecked(i))
                    {
                        opportunityQuery += lstProjectStatus.GetItemValue(i).ToString() + ",";
                    }
                }
                opportunityQuery = opportunityQuery.Remove(opportunityQuery.Length - 1, 1) + ") ";
            }
            //
            if (lstEstimateStatus.CheckedItems.Count > 0)
            {
                estimateQuery += " AND  j.JobStatusID IN(";
                for (i = 0; i < lstEstimateStatus.ItemCount; i++)
                {
                    if (lstEstimateStatus.GetItemChecked(i))
                    {
                        estimateQuery += lstEstimateStatus.GetItemValue(i).ToString() + ",";
                    }
                }
                estimateQuery = estimateQuery.Remove(estimateQuery.Length - 1, 1) + ") ";
            }
            estimateQuery += " AND [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 AND void = 0 And Archived = 0 ";
            //
            try
            {
                Reports.Reports.EstimateOpportunityTracking(opportunityQuery,estimateQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }   
        }
        //
        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBidDateFrom.Text = String.Empty;
            txtBidDateTo.Text = String.Empty;
            lstOffice.DataSource = null;
            lstDepartment.DataSource = null;
            lstProjectStatus.DataSource = null;
            lstEstimateStatus.DataSource = null;
            PopulateLists();
        }
        //
        private void PopulateLists()
        {
            lstOffice.DataSource = StaticTables.Office;
            lstOffice.DisplayMember = "Name";
            lstOffice.ValueMember = "OfficeID";
            lstDepartment.DataSource = StaticTables.Department;
            lstDepartment.DisplayMember = "Name";
            lstDepartment.ValueMember = "DepartmentID";
            lstProjectStatus.DataSource = StaticTables.ProjectStatus;
            lstProjectStatus.DisplayMember = "OTStatusDescription";
            lstProjectStatus.ValueMember = "OTStatusID";
            lstEstimateStatus.DataSource = StaticTables.EstimateStatus;
            lstEstimateStatus.DisplayMember = "JobStatus";
            lstEstimateStatus.ValueMember = "JobStatusID";
            btnClear.Visible = false;
            btnProcess.Focus();
        }
        //
        private void lstOffice_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void lstDepartment_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void lstProjectStatus_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }
        //
        private void lstEstimateStatus_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }
        //
    }
}
