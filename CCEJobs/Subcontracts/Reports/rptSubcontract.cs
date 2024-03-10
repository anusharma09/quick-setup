using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace CCEJobs.Subcontracts.Reports
{
    public partial class rptSubcontract : DevExpress.XtraReports.UI.XtraReport
    {
        private string emp = "";
        private string week = "";

        public rptSubcontract()
        {
            InitializeComponent();
        }

        private void xrLabel4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Emp
            if (emp == xrLabel4.Text)
                xrLabel4.Text = String.Empty;
            else
                emp = xrLabel4.Text;
        }

        private void xrLabel10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Week
            if (week == xrLabel10.Text)
                xrLabel10.Text = String.Empty;
            else
                week = xrLabel10.Text;
        }
    }
}
