using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;


namespace JCCMaterialOrder.Reports
{
    public partial class rptAdHocMaterialOrderListByJob : DevExpress.XtraReports.UI.XtraReport
    {
        public rptAdHocMaterialOrderListByJob()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
