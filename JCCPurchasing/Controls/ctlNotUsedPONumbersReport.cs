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
    public partial class ctlNotUsedPONumbersReport : UserControl
    {
        public ctlNotUsedPONumbersReport()
        {
            InitializeComponent();
            txtStartDate.Text = null;
            txtEndDate.Text = null;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                Reports.Reports.NotUsedPONumbers(txtStartDate.Text, txtEndDate.Text);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            } 

        }
    }
}
