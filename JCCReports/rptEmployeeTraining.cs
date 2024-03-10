using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptEmployeeTraining : DevExpress.XtraReports.UI.XtraReport
    {
        public rptEmployeeTraining ()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void txtPOType_AfterPrint(object sender, EventArgs e)
        {
            
        }

        private void rptJobMajorPO_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            
        }

        
    }
}
