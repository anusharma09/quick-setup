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
    public partial class ctlOCIPClassifiedProjectsReport : UserControl
    {
        public ctlOCIPClassifiedProjectsReport()
        {
            InitializeComponent();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
            txtStartDate.Text = DateTime.Today.Date.ToShortDateString();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.OCIPClassifiedProjects(txtStartDate.Text, txtEndDate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

        }
    }
}
