using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace JCCReports
{
    public partial class rptJobPurchasingDetailSub : DevExpress.XtraReports.UI.XtraReport
    {
        public rptJobPurchasingDetailSub()
        {
            InitializeComponent();  
          
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DataRowView r = (DataRowView)GetCurrentRow();
           // DataRow rr = r;
            if (r != null)
            {
                if (r["JobNumber"].ToString() != r["Job"].ToString())
                    txtJobNumber.Styles.Style = style2;
                else
                    txtJobNumber.Styles.Style = style1;
            }
            else
                txtJobNumber.Styles.Style = style1;

        }
    }
}
