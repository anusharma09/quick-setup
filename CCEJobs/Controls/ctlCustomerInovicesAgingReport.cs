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
    public partial class ctlCustomerInvoicesAgingReport : UserControl
    {
        public ctlCustomerInvoicesAgingReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where = "";
            if (String.IsNullOrEmpty(cboOffice.Text) && String.IsNullOrEmpty(cboDepartment.Text) && txtJobNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show("Must enter Office, Department, or Job Number", CCEApplication.ApplicationName);
                return;
            }
            if (!String.IsNullOrEmpty(cboOffice.Text))
                where = " WHERE j.OfficeID = " + cboOffice.EditValue.ToString();

            if (!String.IsNullOrEmpty(cboDepartment.Text))
            {
                if (where.Length == 0)
                    where = " WHERE j.DepartmentID = " + cboDepartment.EditValue.ToString();
                else
                    where += " AND j.DepartmentID = " + cboDepartment.EditValue.ToString();
            }
            if (txtJobNumber.Text.Trim().Length > 0)
            {
                if (where.Length == 0)
                    where = " WHERE j.JobNumber = '" + txtJobNumber.Text + "'";
                else
                    where += " AND j.JobNumber = '" + txtJobNumber.Text + "'";
            }
            //
            // Security 
            //
             where += " AND j.Archived = 0 AND [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 ";
            
            try
            {
                Reports.JobInvoiceDetailAging(JobCost.GetJobARInvoiceDetailAging(where));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }   
        }
        //
        private void ctlBidScheduleReport_Load(object sender, EventArgs e)
        {
            cboOffice.Properties.DataSource = StaticTables.Office;
            cboOffice.Properties.PopulateColumns();
            cboOffice.Properties.DisplayMember = "OfficeName";
            cboOffice.Properties.ValueMember = "OfficeID";
            cboOffice.Properties.ShowHeader = false;
            cboOffice.Properties.Columns[0].Visible = false;
            cboDepartment.Properties.DataSource = StaticTables.Department;
            cboDepartment.Properties.PopulateColumns();
            cboDepartment.Properties.DisplayMember = "DepartmentName";
            cboDepartment.Properties.ValueMember = "DepartmentID";
            cboDepartment.Properties.ShowHeader = false;
            cboDepartment.Properties.Columns[0].Visible = false;
        }
    }
}
