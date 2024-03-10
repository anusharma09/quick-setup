using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCSmallPO.Reports
{
    public partial class rptJobSmallPO : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobSmallPO()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void txtPOType_AfterPrint(object sender, EventArgs e)
        {
            subJobMajorPOBackPage.Visible = true;
        }

        private void rptJobSmallPO_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            Note.Rtf = GetCurrentColumnValue("Note").ToString();
        }

        
    }
}
