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
    public partial class ctlOpportunityEstimateHoursReport : UserControl
    {
        public ctlOpportunityEstimateHoursReport()
        {
            InitializeComponent();
            PopulateLists();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            int         i = 0;
            string      opportunityQuery = "";

            opportunityQuery = " WHERE  ";
            //
            if (txtBidDateFrom.Text.Length > 0 && txtBidDateTo.Text.Length > 0)
            {
                opportunityQuery += " AND (p.BidDate BETWEEN '" + txtBidDateFrom.Text + "' AND '" + txtBidDateTo.Text + "') ";
            }
            else
            {
                if (txtBidDateFrom.Text.Length > 0)
                {
                    opportunityQuery += " AND (p.BidDate >= '" + txtBidDateFrom.Text + "') ";
                }
                if (txtBidDateTo.Text.Length > 0)
                {
                    opportunityQuery += " AND (p.BidDate >= '" + txtBidDateTo.Text + "') ";
                }
            }
            //
            if (lstOffice.CheckedItems.Count > 0)
            {
                opportunityQuery += " AND  p.OfficeID IN(";
                for (i = 0; i < lstOffice.ItemCount; i++)
                {
                    if (lstOffice.GetItemChecked(i))
                    {
                        opportunityQuery += lstOffice.GetItemValue(i).ToString() + ",";
                    }
                }
                opportunityQuery = opportunityQuery.Remove(opportunityQuery.Length - 1, 1) + ") ";
            }
            //
            if (lstDepartment.CheckedItems.Count > 0)
            {
                opportunityQuery += " AND  p.DepartmentID IN(";
                for (i = 0; i < lstDepartment.ItemCount; i++)
                {
                    if (lstDepartment.GetItemChecked(i))
                    {
                        opportunityQuery += lstDepartment.GetItemValue(i).ToString() + ",";
                    }
                }
                opportunityQuery = opportunityQuery.Remove(opportunityQuery.Length - 1, 1) + ") ";
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
            if (opportunityQuery.Length < 10)
                opportunityQuery = "";
            else
                opportunityQuery = opportunityQuery.Remove(9, 4);

            //
            try
            {
                Reports.Reports.EstimateOpportunityHouursTracking(opportunityQuery);
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
