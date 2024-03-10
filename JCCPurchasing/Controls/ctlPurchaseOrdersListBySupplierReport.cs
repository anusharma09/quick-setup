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
    public partial class ctlPurchaseOrdersListBySupplierReport : UserControl
    {
        public ctlPurchaseOrdersListBySupplierReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJobNumber.Text.Trim().Length == 0)
                    txtJobNumber.ErrorText = "Please enter a Job Number";
                else
                   Reports.Reports.PurchaseOrdersListBySupplier(txtJobNumber.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
    }
}
