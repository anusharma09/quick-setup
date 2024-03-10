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
    public partial class ctlAdHocReport : UserControl
    {
        private string queryCondition = "";
        public string QueryCondition
        {
            set { queryCondition = value; }
        }
        public ctlAdHocReport()
        {
            InitializeComponent();
        }
        public ctlAdHocReport(string queryCondition)
        {
            InitializeComponent();
            this.queryCondition = queryCondition;

        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
                         
            if (String.IsNullOrEmpty(queryCondition))
            {
                MessageBox.Show("No data to print", CCEApplication.ApplicationName);
                return;
            }
            try
            {

                Reports.AdHoc(queryCondition, cboReportFormat.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
                
        }

      
    }
}
