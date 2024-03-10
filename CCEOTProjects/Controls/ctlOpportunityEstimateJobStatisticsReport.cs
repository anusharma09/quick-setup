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
    public partial class ctlOpportunityEstimateJobStatisticsReport : UserControl
    {
        public ctlOpportunityEstimateJobStatisticsReport()
        {
            InitializeComponent();
            PopulateLists();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            int         i = 0;
            string      query = "";
            string      estimateQuery = "";

            query = " WHERE ";
            //
            if (lstOffice.CheckedItems.Count > 0)
            {
                query += " o.OfficeID IN(";
                for (i = 0; i < lstOffice.ItemCount; i++)
                {
                    if (lstOffice.GetItemChecked(i))
                    {
                        query += lstOffice.GetItemValue(i).ToString() + ",";
                    }
                }
                query = query.Remove(query.Length - 1, 1) + ") AND ";
            }
            //
            if (lstDepartment.CheckedItems.Count > 0)
            {
                query += " d.DepartmentID IN(";
                for (i = 0; i < lstDepartment.ItemCount; i++)
                {
                    if (lstDepartment.GetItemChecked(i))
                    {
                        query += lstDepartment.GetItemValue(i).ToString() + ",";
                    }
                }
                query = query.Remove(query.Length - 1, 1) + ") AND ";
            }
            //
            if (lstWorkType.CheckedItems.Count > 0)
            {
                query += " t.WorkTypeID IN(";
                for (i = 0; i < lstWorkType.ItemCount; i++)
                {
                    if (lstWorkType.GetItemChecked(i))
                    {
                        query += lstWorkType.GetItemValue(i).ToString() + ",";
                    }
                }
                query = query.Remove(query.Length - 1, 1) + ") AND ";
            }
            if (query.Length < 9)
                query = "";
            else
                query = query.Substring(0, query.Length - 5);

            //
            try
            {
                Reports.Reports.OpportunityEstimateJobStatistics(query);
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
            lstOffice.DataSource = null;
            lstDepartment.DataSource = null;
            lstWorkType.DataSource = null;
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
            lstWorkType.DataSource = StaticTables.WorkType;
            lstWorkType.DisplayMember = "Description";
            lstWorkType.ValueMember = "WorkTypeID";
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
        private void lstWorkType_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            btnClear.Visible = true;
        }
    }
}
