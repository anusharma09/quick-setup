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
    public partial class ctlJobLaborAnalysisReport : UserControl
    {
        public ctlJobLaborAnalysisReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where;
            
            where = " WHERE (Weekend BETWEEN '" + txtStartDate.Text + "' AND '" + txtEndDate.Text + "') ";

            if (!String.IsNullOrEmpty(cboEmployee.Text))
            {
                where +=  " AND EmpName = '" + cboEmployee.Text + "' " ;
            }

            if (!String.IsNullOrEmpty(txtJobNumber.Text))
            {
                where += " AND h.JobNumber = '" + txtJobNumber.Text + "' ";
            }
    
                //
                // Security 
                //
             where += " AND [dbo].[GetUserJobAccess](b.JobID,'" + Security.Security.LoginID + "')  = 1 ";
            try
            {
                Reports.JobLaborAnalysis(@where);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
                
             
        }

        private void ctlBidScheduleReport_Load(object sender, EventArgs e)
        {
            cboEmployee.Properties.DataSource = StaticTables.Employees;
            cboEmployee.Properties.PopulateColumns();
            cboEmployee.Properties.DisplayMember = "EmpName";
          //  cboEmployee.Properties.ValueMember = "Empname";
            cboEmployee.Properties.ShowHeader = false;
          //  cboEmployee.Properties.Columns[0].Visible = false;

            txtEndDate.Text = DateTime.Today.ToShortDateString();
            txtStartDate.Text = DateTime.Today.ToShortDateString();

          
        }

        private void cboEmployee_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
             if( String.IsNullOrEmpty(e.DisplayValue.ToString())) 
             {
                    cboEmployee.EditValue = null;
                    e.Handled = true;
             }

        }
    }
}
