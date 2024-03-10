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
    public partial class ctlJobPrequalReport : UserControl
    {
        public ctlJobPrequalReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where = " WHERE j.JobNumber > ''  ";

            if (cboCustomer.Text.Trim().Length > 0)
                where += " AND j.CustomerID = '" + cboCustomer.EditValue.ToString() + "' ";

            if (txtScopeOfWork.Text.Trim().Length > 0)
                where += " AND j.ScopeOfWork LIKE '%" + txtScopeOfWork.Text.Trim() + "%' ";

            //
            if (lstDepartment.CheckedItems.Count > 0)
            {
                where += " AND  DepartmentName IN(";
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstDepartment.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                        where += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";

                }
               
                where = where.Remove(where.Length - 1, 1) + ")";
            }
            //
            if (lstContractType.CheckedItems.Count > 0)
            {
                where += " AND  cc.Description IN(";
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstContractType.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                        where += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";

                }

                where = where.Remove(where.Length - 1, 1) + ")";
            }
            //
            if (lstWorkType.CheckedItems.Count > 0)
            {
                where += " AND  bb.Description IN(";
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstWorkType.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                        where += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";
                }
                where = where.Remove(where.Length - 1, 1) + ")";
            }
            //
            if (lstPrequalKeywords.CheckedItems.Count > 0)
            {
                where += " AND  PP.PrequalKeyword IN(";
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstPrequalKeywords.Items)
                {
                    if (item.CheckState == CheckState.Checked)
                        where += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";
                }
                where = where.Remove(where.Length - 1, 1) + ")";
            }

            // Compeletion Date
            if (txtCompDateFrom.Text.Length > 0 && txtCompDateTo.Text.Length > 0)
               where += " AND (j.ContractEstComplDate BETWEEN '" + txtCompDateFrom.Text + "' AND '" + txtCompDateTo.Text + "') ";
            else
            {
                if (txtCompDateFrom.Text.Length > 0)
                    where += " AND j.ContractEstComplDate = '" + txtCompDateFrom.Text + "' ";
                if (txtCompDateTo.Text.Length > 0)
                    where += " AND j.ContractEstComplDate = '" + txtCompDateTo.Text + "' ";
            }
            // Amount
            if (txtAmountFrom.Text.Length > 0 && txtAmountTo.Text.Length > 0)
            {
                where += " AND (j.JobFinalContractAmount BETWEEN " + txtAmountFrom.Text.Replace("$", "").Replace(",", "") + " AND " + txtAmountTo.Text.Replace("$", "").Replace(",", "") + ") ";
            }
            else
            {
                if (txtAmountFrom.Text.Length > 0)
                {
                    where += "  AND ( j.JobFinalContractAmount >= " + txtAmountFrom.Text.Replace("$", "").Replace(",", "") + " ) ";
                }
                if (txtAmountTo.Text.Length > 0)
                {
                    where += " AND ( j.JobFinalContractAmount >= " + txtAmountTo.Text.Replace("$", "").Replace(",", "") + " )  ";
                }
            }
            // Archive Status
            if (radioArchiveStatus.SelectedIndex == 0)
                where += " AND j.Archived =  0 ";
            if (radioArchiveStatus.SelectedIndex == 1)
                where += " AND j.Archived =  1 ";
            
            where += " AND [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 AND void = 0  ";

            try
            {
                int reportType = radioReportType.SelectedIndex;
                Reports.JobPrequalSheet(@where, reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            
              
        }

        private void ctlBidScheduleReport_Load(object sender, EventArgs e)
        {
            
            cboCustomer.Properties.DataSource = StaticTables.Customers;
            cboCustomer.Properties.PopulateColumns();
            cboCustomer.Properties.DisplayMember = "Name";
            cboCustomer.Properties.ValueMember = "CustomerID";
            cboCustomer.Properties.ShowHeader = false;
            cboCustomer.Properties.Columns[0].Visible = false;

            UpdateLists();
            btnClear.Visible = false;
        }

        private void AllItems_EditValueChanged(object sender, EventArgs e)
        {
            btnClear.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            radioArchiveStatus.SelectedIndex = 0;
            radioReportType.SelectedIndex = 0;

            cboCustomer.EditValue = null;
            txtScopeOfWork.Text = null;
            txtAmountFrom.Text = null;
            txtAmountTo.Text = null;
            txtCompDateFrom.Text = null;
            txtCompDateTo.Text = null;                
            lstDepartment.Items.Clear();
            lstContractType.Items.Clear();
            lstWorkType.Items.Clear();
            lstPrequalKeywords.Items.Clear();
            UpdateLists();
            btnClear.Visible = false;
        }
        //
        private void UpdateLists()
        {
            DataTable table;
            table = StaticTables.Department;
            foreach (DataRow r in table.Rows)
                lstDepartment.Items.Add(r["DepartmentName"].ToString());

            table = StaticTables.ContractType;
            foreach (DataRow r in table.Rows)
                lstContractType.Items.Add(r["Description"].ToString());

            table = StaticTables.WorkType;
            foreach (DataRow r in table.Rows)
                lstWorkType.Items.Add(r["Description"].ToString());

            table = StaticTables.PrequalKeywords;
            foreach (DataRow r in table.Rows)
                lstPrequalKeywords.Items.Add(r["PrequalKeyword"].ToString());
        }

        private void lstDepartment_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }

        private void lstContractType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }

        private void lstWorkType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }

        private void lstPrequalKeywords_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }

       
    }
}
