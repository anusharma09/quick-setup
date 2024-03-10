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
    public partial class ctlWeeklyBudgetReport : UserControl
    {
        public ctlWeeklyBudgetReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.WeeklyEstimateBudget(radioReport.SelectedIndex.ToString().Trim(),
                                            radioReportType.SelectedIndex.ToString().Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
    }
}
