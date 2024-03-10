using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptJobMajorPO : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobMajorPO()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void txtPOType_AfterPrint(object sender, EventArgs e)
        {
            if (txtPOType.Text == "SUB")
                subJobMajorPOBackPage.Visible = false;
            else
                subJobMajorPOBackPage.Visible = true;
        }

        private void rptJobMajorPO_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            Note.Rtf = GetCurrentColumnValue("Note").ToString();
            
        }

        
    }
}
