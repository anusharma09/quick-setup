using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace JCCReports
{
    public partial class rptJobSubmittalLogSub : DevExpress.XtraReports.UI.XtraReport
    {
        string jobNumber = "";
        public rptJobSubmittalLogSub()
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
