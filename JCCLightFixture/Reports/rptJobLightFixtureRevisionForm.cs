using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCLightFixture.Reports
{
    public partial class rptJobLightFixtureRevisionForm : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobLightFixtureRevisionForm()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();

            XRBinding binding = new XRBinding("Text", this.DataSource, "Length","{0:n0}");
            length.DataBindings.Add(binding);

        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RevisionNumber.Text = GetCurrentColumnValue("RevisionNumber").ToString();
            RevisionDate.Text = GetCurrentColumnValue("RevisionDate").ToString().Substring(0, 10);
            
        }
        
    }
}
