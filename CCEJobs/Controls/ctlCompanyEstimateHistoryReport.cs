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
    public partial class ctlCompanyEstimateHistoryReport : UserControl
    {
        string jobStatus;
        public ctlCompanyEstimateHistoryReport()
        {
            InitializeComponent();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            jobStatus = "(";
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in lstJobStatus.Items)
            {
                if (item.CheckState == CheckState.Checked)
                    jobStatus += Convert.ToChar(39) + item.Value.ToString().Trim() + Convert.ToChar(39) + ",";

            }
            jobStatus = jobStatus.Remove(jobStatus.Length - 1, 1) + ")";
            

            try
            {
                string archiveStatus;
                if (chkArchive.Checked)
                    archiveStatus = "1";
                else
                    archiveStatus = "0";
                Reports.CompanyEstimateHistoryReport(txtEndDate.Text, jobStatus, archiveStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void ctlCompanyEstimateReviewReport_Load(object sender, EventArgs e)
        {
            DataTable jobStatus = StaticTables.JobStatus;

            foreach (DataRow r in jobStatus.Rows)
                lstJobStatus.Items.Add(r["JobStatus"].ToString());

        }
    }
}
