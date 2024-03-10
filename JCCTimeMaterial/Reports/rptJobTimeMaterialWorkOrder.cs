using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCTimeMaterial.Reports
{
    public partial class rptJobTimeMaterialWorkOrder : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobTimeMaterialWorkOrder()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        private void Description_BeforePrint ( object sender, System.Drawing.Printing.PrintEventArgs e )
        {
            WorkDescText.Rtf = ((DataRowView)GetCurrentRow()).Row["WorkOrderDescription"].ToString();
        }
    }
}
