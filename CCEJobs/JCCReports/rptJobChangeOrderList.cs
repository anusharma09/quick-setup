using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobChangeOrderList : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobChangeOrderList()
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

        private void txtTotalOverHead_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // txtApprovedCOAmount.Text = String.Format("{0:c2}", Convert.ToDouble(TotalOverHead()));
        }

        private double TotalOverHead()
        {
            return (Convert.ToDouble(String.IsNullOrEmpty(txtOriginalContractAmount.Text) ? "0" : txtOriginalContractAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", ""))
                - Convert.ToDouble(String.IsNullOrEmpty(txtTotalCost.Text) ? "0" : txtTotalCost.Summary.GetResult().ToString().Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")));
        }

        private double TotalOverHeadPercent()
        {
            if (Convert.ToDouble(txtOriginalContractAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) > 0)
                return (Convert.ToDouble(txtApprovedCOAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")) / Convert.ToDouble(txtOriginalContractAmount.Text.Replace("$", "").Replace(",", "").Replace("(", "-").Replace(")", "")));
            else
                 return 0;
 
        }
        private void txtPercentOverHead_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           // txtPendingCOWithProceedAmount.Text = String.Format("{0:p2}", Convert.ToDouble(TotalOverHeadPercent()));
        }

    }
}
