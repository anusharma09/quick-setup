using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCEquipmentRental.Reports
{
    public partial class rptJobEquipmentRental : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobEquipmentRental()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
    }
}
