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
    public partial class ctlPreJobPlanning : UserControl
    {
        public ctlPreJobPlanning()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string reportType;
                if (radioReportType.SelectedIndex == 0)
                    reportType = "A";
                else
                    reportType = "C";
                Reports.PreJobPlanning(reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            
               
        }
    }
}
