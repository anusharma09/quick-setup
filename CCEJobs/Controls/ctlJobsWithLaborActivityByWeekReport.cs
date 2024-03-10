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
    public partial class ctlJobsWithLaborActivityByWeekReport : UserControl
    {
        public ctlJobsWithLaborActivityByWeekReport()
        {
            InitializeComponent();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                Reports.JobsWithLaborActivityByWeek(DateTime.Parse(txtEndDate.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

    
    }
}
