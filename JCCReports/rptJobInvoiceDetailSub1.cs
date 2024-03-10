using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobInvoiceDetailSub1 : DevExpress.XtraReports.UI.XtraReport
    {
        string jobNumber = "";
        public rptJobInvoiceDetailSub1()
        {
            InitializeComponent();  
        }
        public string JobNumber
        {
            set
            {
                jobNumber = value;
            }
        }
    }
}
