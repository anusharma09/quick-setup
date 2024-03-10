using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCReports;
using JCCBusinessLayer;
//using CCEOTProjects.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CCEJobs.Controls
{
    public partial class ctlAllInsuranceRequirementsReport : UserControl
    {
        public ctlAllInsuranceRequirementsReport()
        {
            InitializeComponent();
            PopulateLists();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            int         i = 0;
            string      query = "";


            query = " WHERE (JobNumber >  ' ') ";
            //
            if (radioStatus.SelectedIndex == 0)
                query += " AND (Archived = 0) ";
            else
                if (radioStatus.SelectedIndex == 1)
                    query += " AND (Archived = 1) ";
            if (chkCompletedOps.CheckState == CheckState.Checked)
                query += " AND (CompletedOpS = 1) ";
            if (chkGLAutoWC.CheckState == CheckState.Checked)
                query += " AND (GLAutoWC = 1) " ;
            if (chkProfLiab.CheckState == CheckState.Checked)
                query += " AND (FrofLiab = 1) ";
            if (txtCompletedOps.Text.Trim().Length > 0)
                query += " AND (CompletedOPsYears = " + txtCompletedOps.Text + ") ";
            if (txtGLAutoWC.Text.Trim().Length > 0)
                query += " AND (GLAutoWCYears = " + txtGLAutoWC.Text + ") ";
            if (txtProfLiab.Text.Trim().Length > 0)
                query += " AND (ProfLiabYears = " + txtProfLiab.Text + ") ";
            //
            if (lstOffice.CheckedItems.Count > 0)
            {
                query += " AND  j.OfficeID IN(";
                for (i = 0; i < lstOffice.ItemCount; i++)
                {
                    if (lstOffice.GetItemChecked(i))
                    {
                        query += lstOffice.GetItemValue(i).ToString() + ",";
                    }
                }
                query = query.Remove(query.Length - 1, 1) + ") ";
            }
            //
            if (lstDepartment.CheckedItems.Count > 0)
            {
                query += " AND  j.DepartmentID IN(";
                for (i = 0; i < lstDepartment.ItemCount; i++)
                {
                    if (lstDepartment.GetItemChecked(i))
                    {
                        query += lstDepartment.GetItemValue(i).ToString() + ",";
                    }
                }
                query = query.Remove(query.Length - 1, 1) + ") ";
            }
            query += " AND [dbo].[GetUserJobAccess](j.JobID,'" + Security.Security.LoginID + "')  = 1 ";
            //
            try
            {
                Reports.AllInsuranceRequirementsReport(query);
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
            txtCompletedOps.Text        = String.Empty;
            txtGLAutoWC.Text            = String.Empty;
            txtProfLiab.Text            = String.Empty;
            chkCompletedOps.Checked     = false;
            chkGLAutoWC.Checked         = false;
            chkProfLiab.Checked         = false;
            lstOffice.DataSource        = null;
            lstDepartment.DataSource    = null;
            radioStatus.SelectedIndex   = 2;
            PopulateLists();
        }
        //
        private void PopulateLists()
        {
            lstOffice.DataSource = StaticTables.Office;
            lstOffice.DisplayMember = "OfficeName";
            lstOffice.ValueMember = "OfficeID";
            lstDepartment.DataSource = StaticTables.Department;
            lstDepartment.DisplayMember = "DepartmentName";
            lstDepartment.ValueMember = "DepartmentID";
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
    }
}
