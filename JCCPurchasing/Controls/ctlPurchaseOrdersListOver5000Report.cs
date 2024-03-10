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
    public partial class ctlPurchaseOrdersListOver5000Report : UserControl
    {
        public ctlPurchaseOrdersListOver5000Report()
        {
            InitializeComponent();
            txtStartDate.Text = DateTime.Today.ToShortDateString();
            txtEndDate.Text = DateTime.Today.ToShortDateString();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStartDate.Text.Trim().Length == 0 || txtEndDate.Text.Trim().Length == 0)
                {
                    if (txtStartDate.Text.Trim().Length == 0)
                        txtStartDate.ErrorText = "Please enter Start Date";
                    if (txtEndDate.Text.Trim().Length == 0)
                        txtEndDate.ErrorText = "Please enter End Date";
                }
                else
                {
                    Reports.Reports.PurchaseOrdersList5000(txtStartDate.Text, txtEndDate.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 
        }
    }
}
