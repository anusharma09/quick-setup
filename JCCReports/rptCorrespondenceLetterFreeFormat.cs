using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptCorrespondenceLetterFreeFormat : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCorrespondenceLetterFreeFormat()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void rptCorrespondenceLetterFreeFormat_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
            CorrespondenceLetterNote.Rtf = GetCurrentColumnValue("CorrespondenceLetterNote").ToString();
            Subject.Text = GetCurrentColumnValue("Subject").ToString();
            title.Text = GetCurrentColumnValue("Title").ToString();
        }
        
    }
}
