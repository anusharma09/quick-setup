using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCReports;
using JCCBusinessLayer;

namespace CCEJobs.Controls
{
    public partial class ctlJobProgressSummaryReport : UserControl
    {
        public ctlJobProgressSummaryReport()
        {
            InitializeComponent();
            if (Security.Security.UserJCCAccess == Security.Security.Access.JCCAdministrator ||
                Security.Security.UserJCCAccess == Security.Security.Access.ApplicationAdministrator)
            {
                checkedReportList.Items.Add("Month End Summary (WIP)", false);
                checkedReportList.Items.Add("Job Progress Summary (WIP)", false);
                checkedReportList.Items.Add("Cost of Completion (WIP)", false);
            }

        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            // /////////////////////////////////////
            // Process the Jobs for Month End //////
            // /////////////////////////////////////

            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim() == "")
            {
                MessageBox.Show("Please enter period date.", CCEApplication.ApplicationName);
                return;
            }
            if (checkedReportList.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select one or more reports to process.", CCEApplication.ApplicationName);
                return;
            }
            if (radioContractValue.SelectedIndex == 2)
            {
                ProcessMonthEndSummary(0);
                ProcessContractLog();
                ProcessJobProgressSummaryWIP(2);
                return;
            }
            if (checkedReportList.Items[0].CheckState == CheckState.Checked)
                ProcessMonthEndSummary(0);
            if (checkedReportList.Items[1].CheckState == CheckState.Checked)
                ProcessContractLog();
            if (checkedReportList.Items[2].CheckState == CheckState.Checked)
                ProcessJobProgressSummaryWIP(2);

            if (checkedReportList.Items[3].CheckState == CheckState.Checked)
                ProcessJobDetailMonthEndCostOfCompletion(3);
            if (checkedReportList.Items.Count > 4)
            {
                if (checkedReportList.Items[4].CheckState == CheckState.Checked)
                    ProcessMonthEndSummary(4);
                if (checkedReportList.Items[5].CheckState == CheckState.Checked)
                    ProcessJobProgressSummaryWIP(5);
                if (checkedReportList.Items[6].CheckState == CheckState.Checked)
                    ProcessJobDetailMonthEndCostOfCompletion(6);
            }
        }
        //
        private void ProcessMonthEndSummary(int value)
        {
            string query;
            string period = "";


            // Process Month End Summary
            query = " SELECT b.*, m.Description As [ProjectManager], JobNumber, JobName, t.Description AS [ContractType], " +
               " CommentStatus = " +
               " CASE ISNULL(b.Comment,'') " +
               " WHEN '' THEN 0 " +
               " ELSE 1 " +
               " END "; 

            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query + "  FROM tblJobBalanceHistory b ";
            }
            else
            {
                query = query + "  FROM tblJobBalance b ";
            }
            query = query + " INNER JOIN tblJob J " +
                            " ON b.JobID = j.JobID " +
                            " Left Join tblProjectManager m " +
                            " ON j.ProjectManagerID = m.ProjectManagerID        " +
                            " LEFT JOIN tblContractType t ON j.ContractTypeID = t.ContractTypeID " +
                            " WHERE JobNumber > '' AND " +
                            " [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 AND ";

            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query +  " period =  '" + cboPeriod.Text + "' AND ";
                period = cboPeriod.Text;
            }
            else
            {
                query = query + " Archived <> 1 AND ";
            }
            //
            if (radioApproved.SelectedIndex == 1)
            {
                query = query + " Approved = 1 AND ";
            }
            //
            if (radioApproved.SelectedIndex == 2) // Non Approved
            {
                query = query +  " Approved = 0 AND ";
            }
            //
            if (radioContractValue.SelectedIndex == 0)
            {
                query = query + " JobFinalContractAmount >= 250000 AND ";
            }
            //
            if (!String.IsNullOrEmpty(cboOffice.Text))
            {
                query = query +  "  j.OfficeID = " + cboOffice.EditValue.ToString() + " AND ";
            }
            //
            if (!String.IsNullOrEmpty(cboDepartment.Text))
            {
                query = query +  "  j.DepartmentID = " + cboDepartment.EditValue.ToString() + " AND ";
            }
            //
            if (!String.IsNullOrEmpty(cboProjectManager.Text))
            {
                query = query +  "  j.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " AND ";
            }
            //
            query +=   " [dbo].[GetUserJobAccess](b.JobID,'" + Security.Security.LoginID + "')  = 1 AND ";

            if (query.Length > 8)
                query = query.Substring(0, query.Length - 5);

            try
            {
                if (value == 0)
                    Reports.JobProgressSummaryReport(query, period);
                else
                    Reports.JobProgressSummaryWIPReport(query, period);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }    
        }

        private void ProcessContractLog()
        {
            string query;
            string period = "";


            // Process Contract Log
            query = "SELECT " +
                            " JobChangeOrderLogID, " +
                            " l.JobID, " +
                            " JobChangeOrderNumber, " +
                            " JobChangeOrderRequestDate," +
                            " JobChangeOrderApprovedDate, " +
                            " JobChangeOrderContractAmount, " +
                            " JobChangeOrderStatus, " +
                            " JobChangeOrderDescription, " +
                            " JobChangeOrderOwnerNumber, " +
                            " JobCostCodeType, " +
                             " JobChangeOrderUserDescription, " +
                            " Hours, " +
                            " Labor, " +
                            " Subcontract, " +
                            " Material, " +
                            " Expense, " +
                            " Labor + Subcontract + Material + Expense AS TotalCost, " +
                            " (JobChangeOrderContractAmount -   (Labor + Subcontract + Material + Expense) ) AS EstProfit, " +
                            " ProfitPercent = " +
                            " CASE ISNULL(JobChangeOrderContractAmount,0) " +
                            " WHEN  0 THEN 0 " +
                            " ELSE CAST(  ( JobChangeOrderContractAmount -  (Labor + Subcontract + Material + Expense)) / JobChangeOrderContractAmount AS FLOAT) " +
                            " END, " +
                            " JobNumber, " +
                            " JobName, " +
                            " j.CustomerID, " +
                            " [Name] AS CustomerName, " +
                            " m.Description AS ProjectManager, " +
                            " t.Description AS ContractType, " +
                            " ContractEstComplDate, " +
                            " JobChangeOrderDescriptionGroup ";

            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query + "  FROM tblJobChangeOrderLogHistory l ";
            }
            else
            {
                query = query + "  FROM tblJobChangeOrderLog l ";
            }
            query = query + " INNER JOIN tblJob j ON l.JobID = j.JobID " +
                            " LEFT JOIN tblCustomer c ON j.CustomerID = c.CustomerID " +
                            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
                            " LEFT JOIN tblContractType t ON j.ContractTypeID = t.ContractTypeID " +
                            " WHERE [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 AND ";

            // Archive or Current Data
            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query +  " period =  '" + cboPeriod.Text + "' AND ";
                period = cboPeriod.Text;
            }
            else
            {
                query = query + " Archived <> 1 AND ";
            }
            // Check for Final ContractAmount
            if ( radioContractValue.SelectedIndex ==  0 || radioContractValue.SelectedIndex == 2 )
            {
                query = query + " JobFinalContractAmount >= 250000 AND ";
            }
            //
            if (!String.IsNullOrEmpty(cboOffice.Text))
            {
                query = query +  "  j.OfficeID = " + cboOffice.EditValue.ToString() + " AND ";
            }
            //
            if (!String.IsNullOrEmpty(cboDepartment.Text))
            {
                query = query +  "  j.DepartmentID = " + cboDepartment.EditValue.ToString() + " AND ";
            }
            //
            if (!String.IsNullOrEmpty(cboProjectManager.Text))
            {
                query = query + "  j.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " AND ";
            }
            //
            if (radioContractValue.SelectedIndex == 2)
            {
                query = query + " (j.ContractTypeID = 3 OR TrackChangeOrder = 1) AND ";
            }

            if (query.Length > 8)
                query = query.Substring(0, query.Length - 5);

            try
            {
                //
                // New Routine for the Contract Log Report
                //
                Reports.JobContractLogMonthEndReport(query, period);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void ProcessJobProgressSummaryWIP(int value)
        {
            string query;
            string period = "";


            // Process Contract Log
            query = "SELECT b.*, c.Description AS ContractType, m.Description AS ProjectManager, o.Phone, o.Fax, address + ' ' + City + ', ' + state + ' ' + zipCode AS [OfficeAddress],  j.JobNumber, j.JobName,  " +
                    " CommentStatus = " +
                    " CASE ISNULL(b.Comment,'') " +
                    " WHEN '' THEN 0 " +
                    " ELSE 1 " +
                    " END "; 

            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query + "  FROM tblJobBalanceHistory b ";
            }
            else
            {
                query = query + "  FROM tblJobBalance b ";
            }
            query = query +
                       " LEFT JOIN tblJob j " +
                       " ON b.JobID = j.JobID " +
                       " LEFT JOIN tblContractType c " +
                        " ON j.ContractTypeID = c.ContractTypeID " +
                        " LEFT JOIN tblOffice o ON j.OfficeID = O.OfficeID " +
            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
            " WHERE [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 AND ";
            // Archive or Current Data
            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query +  " period =  '" + cboPeriod.Text + "' AND ";
                period = cboPeriod.Text;
            }
            else
            {
                query = query + "  Archived <> 1 AND ";
            }

            // Check for Final ContractAmount
            if (radioContractValue.SelectedIndex == 0 || radioContractValue.SelectedIndex == 2)
            {
                query = query + " JobFinalContractAmount >= 250000 AND ";
            }

            if (!String.IsNullOrEmpty(cboOffice.Text))
            {
                query = query + "  j.OfficeID = " + cboOffice.EditValue.ToString() + " AND ";
            }



            if (!String.IsNullOrEmpty(cboDepartment.Text))
            {
                query = query + "  j.DepartmentID = " + cboDepartment.EditValue.ToString() + " AND ";
            }



            if (!String.IsNullOrEmpty(cboProjectManager.Text))
            {
                query = query + "  j.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " AND ";
            }
            if (radioContractValue.SelectedIndex == 2)
            {
                query = query + " (j.ContractTypeID = 3 OR TrackChangeOrder = 1) AND ";
            }

            if (query.Length > 8)
                query = query.Substring(0, query.Length - 5);

            try
            {
                //
                // New Routine for the Contract Log Report
                //
                if (value == 2)
                    Reports.JobProgressSummaryMonthEndReport(query, period);
                else
                    Reports.JobProgressSummaryWIPMonthEndReport(query, period);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        //
        private void ProcessJobDetailMonthEndCostOfCompletion(int value)
        {
            string query;
            string period = "";


           query = " SELECT DISTINCT JobCostCodePhaseID, JobCostCodePhase As [Phase], CostCode AS [Code] , " + 
                    " Type = CASE JobCostCodeType + Substring(JobCostCodePhase,1,1) " +  
                    " WHEN 'L1' THEN '100 - LABOR' " +
                    " WHEN 'L5' THEN '500 - PREFAB' " + 
                    " WHEN 'M2' THEN '200 - MATERIAL' " + 
                    " WHEN 'E3' THEN '300 - RENTAL' " + 
                    " WHEN 'S4' THEN '400 - SUBCONTRACT' " + 
                    " WHEN 'O8' THEN '800 - DJC' " + 
                    " ELSE 'OTHERS' " + 
                    " END, " + 
                    " UserDescription AS [Description], " +
                    " TotalBudgetCost AS [Total Budget Cost], " + 
                    " Cost AS [Committed Cost], " +   
                    " ValueAdjustment As [Value Adjustment], " + 
                    " MonthEndCAC AS  [Monthend CAC], " +
                    " RevisedCACMonthend AS [Revised Monthend CAC], " +
                    " OpenCommitment As [Open Commitment], " +
                    " c.Description AS ContractType, m.Description AS ProjectManager, o.Phone, o.Fax, address + ' ' + City + ', ' + state + ' ' + zipCode AS [OfficeAddress],  j.JobNumber, j.JobName  ";   

            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query + "  FROM tblJobCostCodePhaseHistory b ";
            }
            else
            {
                query = query + "  FROM tblJobCostCodePhase b ";
            }
            query = query +
                       " LEFT JOIN tblJob j " +
                       " ON b.JobID = j.JobID " +
                       " LEFT JOIN tblContractType c " +
                        " ON j.ContractTypeID = c.ContractTypeID " +
                        " LEFT JOIN tblOffice o ON j.OfficeID = O.OfficeID " +
            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " +
            " WHERE [dbo].[GetUserJobAccess](j.JobID, '" + Security.Security.LoginID + "')  = 1 AND ";

            // Archive or Current Data
            if (radioDataType.SelectedIndex > 0 && cboPeriod.Text.Trim().Length > 0)
            {
                query = query +  " period =  '" + cboPeriod.Text + "' AND ";
                period = cboPeriod.Text;
            }
            else
            {
                query = query + " Archived <> 1 AND ";
            }
            
            // Check for Final ContractAmount
            if (radioContractValue.SelectedIndex == 0)
            {
                query = query +  " JobFinalContractAmount >= 250000 AND ";
            }

            if (!String.IsNullOrEmpty(cboOffice.Text))
            {
                query = query +  "  j.OfficeID = " + cboOffice.EditValue.ToString() + " AND ";
            }

            if (!String.IsNullOrEmpty(cboDepartment.Text))
            {
                query = query +  "  j.DepartmentID = " + cboDepartment.EditValue.ToString() + " AND ";
            }


            if (!String.IsNullOrEmpty(cboProjectManager.Text))
            {
                query = query + "  j.ProjectManagerID = " + cboProjectManager.EditValue.ToString() + " AND ";
            }

            if (query.Length > 8)
                query = query.Substring(0, query.Length - 5);

            try
            {
                //
                // New Routine for the Contract Log Report
                //
                if (value == 3)
                    Reports.JobDetailMonthEndCostOfCompletion(query, period);
                else
                    Reports.JobDetailMonthEndCostOfCompletionWIP(query, period);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }



        private void ctlBidScheduleReport_Load(object sender, EventArgs e)
        {

            cboDepartment.Properties.DataSource = StaticTables.Department;
            cboDepartment.Properties.DisplayMember = "DepartmentName";
            cboDepartment.Properties.ValueMember = "DepartmentID";
            cboDepartment.Properties.PopulateColumns();
            cboDepartment.Properties.ShowHeader = false;
            cboDepartment.Properties.Columns[0].Visible = false;

            cboOffice.Properties.DataSource = StaticTables.Office;
            cboOffice.Properties.PopulateColumns();
            cboOffice.Properties.DisplayMember = "OfficeName";
            cboOffice.Properties.ValueMember = "OfficeID";
            cboOffice.Properties.ShowHeader = false;
            cboOffice.Properties.Columns[0].Visible = false;
            
            cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
            cboProjectManager.Properties.DisplayMember = "Description";
            cboProjectManager.Properties.ValueMember = "ProjectManagerID";
            cboProjectManager.Properties.PopulateColumns();
            cboProjectManager.Properties.ShowHeader = false;
            cboProjectManager.Properties.Columns[0].Visible = false;

            cboPeriod.Properties.DataSource = StaticTables.ArchivePeriod;
            cboPeriod.Properties.PopulateColumns();
            cboPeriod.Properties.DisplayMember = "Period";
            cboPeriod.Properties.ShowHeader = false;
            cboPeriod.Visible = false;
            radioDataType.SelectedIndex = 0;

        }

        private void radioDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioDataType.SelectedIndex == 0)
            {
                lblPeriod.Visible = false;
                cboPeriod.EditValue = String.Empty;
                cboPeriod.Visible = false;
            }
            else
            {
                lblPeriod.Visible = true;
                cboPeriod.Visible = true;
            }
        }
        private void cboOffice_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if(e.DisplayValue.ToString().Trim().Length == 0)
                e.Handled = true;
        }
        private void cboDepartment_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (e.DisplayValue.ToString().Trim().Length == 0)
                e.Handled = true;
        }
    }
}
