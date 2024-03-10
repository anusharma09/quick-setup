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
    public partial class ctlPOsWithNoMatchInvoiceReport : UserControl
    {
        public ctlPOsWithNoMatchInvoiceReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where = " WHERE  p.JobNumber <> b.JobNumber AND j.Archived = 0 ";

            if (!String.IsNullOrEmpty(cboOffice.Text))
                where += " AND j.OfficeID = " + cboOffice.EditValue.ToString();

            if (!String.IsNullOrEmpty(cboDepartment.Text))
            {
                where += " AND j.DepartmentID = " + cboDepartment.EditValue.ToString();
            }
            if (txtJobNumber.Text.Trim().Length > 0)
            {
                where += " AND j.JobNumber = '" + txtJobNumber.Text + "'";
            }
            //
            // Security 
            //
             where += " AND [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 ";
            
            try
            {
                Reports.POsWithNoMatchInvoce(@where);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
                
                 
        }

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
