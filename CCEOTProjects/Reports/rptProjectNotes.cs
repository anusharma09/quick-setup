using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CCEOTProjects.Reports
{
    public partial class rptProjectNotes : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProjectNotes()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
