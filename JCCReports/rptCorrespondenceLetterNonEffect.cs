using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptCorrespondenceLetterNonEffect : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCorrespondenceLetterNonEffect()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void rptCorrespondenceLetterNonEffect_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            CorrespondenceLetterNote.Rtf = GetCurrentColumnValue("CorrespondenceLetterNote").ToString();
            title.Text = GetCurrentColumnValue("Title").ToString();

        }
        
    }
}
