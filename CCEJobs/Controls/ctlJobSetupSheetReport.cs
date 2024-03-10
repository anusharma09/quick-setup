using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCEJobs.Reports;
namespace CCEJobs.Controls
{
    public partial class ctlJobSetupSheetReport : UserControl
    {
        public ctlJobSetupSheetReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Reports.Reports.JobSetupSheet();
        }
    }
}
