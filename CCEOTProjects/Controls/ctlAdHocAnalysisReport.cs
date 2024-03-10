using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CCEOTProjects.BusinessLayer;
using CCEOTProjects.Controls;

namespace CCEOTProjects.Controls
{
    public partial class ctlAdHocAnalysisReport : UserControl
    {
        private string query;

        public ctlAdHocAnalysisReport()
        {
            InitializeComponent();
        }
        public ctlAdHocAnalysisReport(string query)
    
        {
            InitializeComponent();
            this.query = query;
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.Reports.ProjectOpportunitiesAnalysis(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
                
        }

      
    }
}
