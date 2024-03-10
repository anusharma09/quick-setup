using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobLaborAnalysisWeek : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobLaborAnalysisWeek()
        {
            InitializeComponent();
            if (CCEApplication.Company.ToUpper() == "DYNA")
            {
                logo.Image = Properties.Resources.Dynalectric;
                txtCompany.Text = "DYNALECTRIC";
            }
            else
                logo.Image = Properties.Resources.ContraCostaLogo;
        }
    }
}
