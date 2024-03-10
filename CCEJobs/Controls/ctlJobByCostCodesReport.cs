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
    public partial class ctlJobByCostCodesReport : UserControl
    {
        string jobPhase = "";
        string jobCode = "";
        string office = "";
        string department = "";
        DataTable jobTable;
        //
        public ctlJobByCostCodesReport()
        {
            InitializeComponent();
            txtDate.Text = DateTime.Today.ToShortDateString();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            jobPhase    = "(";
            jobCode     = "(";
            office      = "";
            department  = "";

            foreach (DataRow r in jobTable.Rows)
            {
                if (r["Selected"].ToString() == "True")
                {
                    jobPhase += Convert.ToChar(39) + r["Phase"].ToString().Trim() + Convert.ToChar(39) + ",";
                    jobCode += Convert.ToChar(39) + r["Code"].ToString().Trim() + Convert.ToChar(39) + ",";
                }
            }
            jobPhase = jobPhase.Remove(jobPhase.Length - 1, 1) + ")";
            jobCode = jobCode.Remove(jobCode.Length - 1, 1) + ")";
            if (!String.IsNullOrEmpty(cboOffice.Text))
                office = cboOffice.EditValue.ToString();
            if (!String.IsNullOrEmpty(cboDepartment.Text))
                office = cboDepartment.EditValue.ToString();
            if (jobCode.Length < 3)
            {
                MessageBox.Show("Please select cost codes for the report");
                return;
            }
            try
            {
                Reports.JobByCostCodesReport(txtDate.Text.Substring(6, 4), jobPhase, jobCode, office, department);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void ctlCompanyEstimateReviewReport_Load(object sender, EventArgs e)
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
            jobTable = StaticTables.CostCodes;
            grdCostCode.DataSource = jobTable.DefaultView;
            grdCostCodeView.Columns["Selected"].Caption = "";
            grdCostCodeView.Columns["Type"].OptionsColumn.AllowEdit = false;
            grdCostCodeView.Columns["Phase"].OptionsColumn.AllowEdit = false;
            grdCostCodeView.Columns["Code"].OptionsColumn.AllowEdit = false;
            grdCostCodeView.Columns["Title"].OptionsColumn.AllowEdit = false;
            grdCostCodeView.BestFitColumns();
        }

        private void cboOffice_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (e.DisplayValue.ToString().Trim() == "")
                e.Handled = true;
        }

        private void cboDepartment_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if (e.DisplayValue.ToString().Trim() == "")
                e.Handled = true;
        }
    }
}
