using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptCostBreakdownSheet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCostBreakdownSheet()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }

        private void txtTotalOverHead_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtTotalOverHead.Text = String.Format("{0:c2}", Convert.ToDouble(TotalOverHead()));
        }

        private double TotalOverHead()
        {
            return (Convert.ToDouble(String.IsNullOrEmpty(txtApprovedAmount.Text) ? "0" : txtApprovedAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", ""))
                - Convert.ToDouble(String.IsNullOrEmpty(txtTotalCost.Text) ? "0" : txtTotalCost.Summary.GetResult().ToString().Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")));
        }

        private double TotalOverHeadPercent()
        {
            if (Convert.ToDouble(String.IsNullOrEmpty(txtApprovedAmount.Text) ? "0" : txtApprovedAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                return (Convert.ToDouble(String.IsNullOrEmpty(txtTotalOverHead.Text) ? "0" : txtTotalOverHead.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) / Convert.ToDouble(String.IsNullOrEmpty(txtApprovedAmount.Text) ? "0" : txtApprovedAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")));
            else
                 return 0;
 
        }
        private void txtPercentOverHead_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtPercentOverHead.Text = String.Format("{0:p2}", Convert.ToDouble(TotalOverHeadPercent()));
        }

    }
}
