using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCPurchasing.BusinessLayer;

namespace JCCPurchasing.Controls
{
    public partial class ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport : UserControl
    {
        public ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport()
        {
            InitializeComponent();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJobNumber.Text.Trim().Length == 0 && cboProjectManager.Text.Trim().Length == 0)
                {
                    lblWarning.Visible = true;
                }
                else
                {
                    string query = "";
                    lblWarning.Visible = false;

                    query = " WHERE a.PO NOT LIKE 'N/A%'  AND a.JobNumber <> b.JobNumber ";
                    if (txtJobNumber.Text.Trim().Length > 0)
                        query += " AND a.JobNumber = '" + txtJobNumber.Text.Trim() + "' ";
                    if (cboProjectManager.Text.Trim().Length > 0)
                        query += " AND j.ProjectManagerID = " + cboProjectManager.EditValue.ToString();
                    if (txtStartDate.Text.Length > 0 && txtEndDate.Text.Length > 0)
                        query += " AND ( [Inv Date] BETWEEN '" + txtStartDate.Text + "' AND '" + txtEndDate.Text + "' )";
                    else
                        if (txtStartDate.Text.Length > 0)
                            query += " AND ( [Inv Date] = '" + txtStartDate.Text + "') ";
                        else 
                            if (txtEndDate.Text.Length > 0)
                               query += " AND ( [Inv Date] = '" + txtEndDate.Text + "') "; 

                    Reports.Reports.POInvoicesWithDifferentJobNumber(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
        //
        private void ctlPurchaseOrdersListInvoicesWithDifferentJobNumberReport_Load(object sender, EventArgs e)
        {
            cboProjectManager.Properties.DataSource = StaticTables.ProjectManager;
            cboProjectManager.Properties.DisplayMember = "ProjectManager";
            cboProjectManager.Properties.ValueMember = "ProjectManagerID";
            cboProjectManager.Properties.PopulateColumns();
            cboProjectManager.Properties.ShowHeader = false;
            cboProjectManager.Properties.Columns[0].Visible = false;
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }
    }
}
