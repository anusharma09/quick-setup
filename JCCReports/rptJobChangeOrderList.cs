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
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
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


        //
        private decimal Cost()
        {
            return 0;
        }
        //
        private decimal ContractAmount()
        {
          
            decimal ret = 0;

            switch (GetCurrentColumnValue("JobChangeOrderStatus").ToString().Trim().ToUpper())
            {
                case "APPROVED":
                    decimal.TryParse(GetCurrentColumnValue("JobChangeOrderApprovedAmount").ToString(), out ret);
                    break;
                case "PENDING":
                    decimal.TryParse(GetCurrentColumnValue("JobChangeOrderRequestedAmount").ToString(), out ret);
                    break;
            }
            return ret;
        }
        //
        private void txtProfit_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal profit = 0;

            profit = Profit();
            txtProfit.Text = String.Format("{0:c2}", profit);
        }
        //
        private decimal Profit()
        {
            decimal profit = 0;
            decimal cost = 0;
            decimal contractAmount = 0;

            contractAmount = ContractAmount();
            decimal.TryParse(GetCurrentColumnValue("Cost").ToString(), out cost);
            profit = contractAmount - cost;
            return profit;
        }
        //
        private void profitPercent_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal profit = 0;
            decimal contractAmount = 0;
            decimal profitPer = 0;

            profit = Profit();
            contractAmount = ContractAmount();

            if (contractAmount > 0)
                profitPer = profit / contractAmount;

            profitPercent.Text = String.Format("{0:p}", profitPer);

        }
    }
}

