using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptJobRFISheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobRFISheet()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void RFIText_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RFIText.Rtf = ((DataRowView)GetCurrentRow()).Row["RFIText"].ToString();
        }

        private void RFIResponse_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            RFIResponse.Rtf = ((DataRowView)GetCurrentRow()).Row["RFIResponse"].ToString();
        }

        private void rptJobRFISheet_DataSourceRowChanged(object sender, DataSourceRowEventArgs e)
        {
               
        }

        private void CostImpact_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CostImpact.CheckState = ((DataRowView)GetCurrentRow()).Row["CostImpactYesNo"].ToString() == "True" ? 
                System.Windows.Forms.CheckState.Unchecked: System.Windows.Forms.CheckState.Checked;
        }

        
    }
}
