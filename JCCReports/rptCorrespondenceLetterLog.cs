using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptCorrespondenceLetterLog : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCorrespondenceLetterLog()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
            CostImpact.DataBindings.Add("Text", this.DataSource, "Cost Impact");
        }
    }
}
