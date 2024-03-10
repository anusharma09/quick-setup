using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobInvoiceDetailSub : DevExpress.XtraReports.UI.XtraReport
    {
        string jobNumber = "";
        public rptJobInvoiceDetailSub()
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
