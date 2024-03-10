using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCPurchasing.BusinessLayer;


namespace JCCPurchasing.Controls
{
    public partial class ctlPurchaseOrderReceivedItemsReport : UserControl
    {
        public ctlPurchaseOrderReceivedItemsReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPONumber.Text.Trim().Length == 0)
                {
                    txtPONumber.ErrorText = "Please enter a PO Number";
                
                }
                else
                {
                    Reports.Reports.PurchaseOrderReceivedItems(txtPONumber.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
    }
}
