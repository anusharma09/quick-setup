using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptLaborFeedbackReport : DevExpress.XtraReports.UI.XtraReport
    {
        private Int64 used;
        private Int64 earned;
        private Double laborPerformanceFactor;

        public rptLaborFeedbackReport()
        {
            InitializeComponent();
            logo.Image = Properties.Resources.CompanyLogo;
            txtCompany.Text = CCEApplication.Company.ToUpper();
        }
        //
        private void grdLaborFeedback_CustomCellDisplayText(object sender, DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs e)
        {

            switch (e.RowValueType)
            {
                case DevExpress.XtraPivotGrid.PivotGridValueType.Total:
                    switch (e.DataField.Caption)
                    {
                        case "Used":
                            used = Convert.ToInt64(e.Value.ToString());
                            break;
                        case "Earned":
                            earned = Convert.ToInt64(Convert.ToDouble(e.Value.ToString()));
                            break;
                        case "Labor Performance Factor":
                            if (earned == 0 || used == 0)
                                e.DisplayText = "1.00";
                            else
                                laborPerformanceFactor = Convert.ToDouble(Convert.ToDouble(used) / Convert.ToDouble(earned));
                            e.DisplayText = String.Format("{0:n2}", laborPerformanceFactor);
                            break;
                    }
                    break;
                case DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal:
                    switch (e.DataField.Caption)
                    {
                        case "Used":
                            used = Convert.ToInt64(e.Value.ToString());
                            break;
                        case "Earned":
                            earned = Convert.ToInt64(Convert.ToDouble(e.Value.ToString()));
                            break;
                        case "Labor Performance Factor":
                            if (earned == 0 || used == 0)
                                e.DisplayText = "1.00";
                            else
                                laborPerformanceFactor = Convert.ToDouble(Convert.ToDouble(used) / Convert.ToDouble(earned));
                            e.DisplayText = String.Format("{0:n2}", laborPerformanceFactor);
                            break;
                    }
                    break;
            }

        }

    }
}
