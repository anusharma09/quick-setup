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
    public partial class ctlBidScheduleReport : UserControl
    {
        public ctlBidScheduleReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where;
            
            if (String.IsNullOrEmpty(cboOffice.Text))
            {
                cboOffice.ErrorText = "Office is required";
            }
            else
            {
                where = " WHERE b.OfficeID = " + cboOffice.EditValue.ToString();
                if (lstJobStatus.CheckedItems.Count > 0)
                {
                    where += " AND  JobStatus IN(";
                    foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstJobStatus.Items)
                    {
                        if (item.CheckState == CheckState.Checked)
                            where += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";

                    }
                   
                    where = where.Remove(where.Length - 1, 1) + ")";
                    //
                    // Security 
                    //
                     where += " AND [dbo].[GetUserJobAccess](b.JobID,'" + Security.Security.LoginID + "')  = 1 AND void = 0 And Archived = 0 ";
                }
                try
                {
                    Reports.BidStatus(@where);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
                
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
          
            
             DataTable jobStatus = StaticTables.JobStatus;

             foreach (DataRow r in jobStatus.Rows)
                 lstJobStatus.Items.Add(r["JobStatus"].ToString());


        }
    }
}
