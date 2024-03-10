using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CCEJobs.Controls
{
    public partial class frmPOInvoiceSummary : Form
    {
        public frmPOInvoiceSummary()
        {
            InitializeComponent();
        }
        public string InvoiceNumber
        {
            set { txtInvoiceNumber.Text = value; }
        }
        public string Vendor
        {
            set { txtVendor.Text = value; }
        }
        public string InvoiceAmount
        {
            set { txtInvoiceAmount.Text = value; }
        }
        public string InvoiceDate
        {
            set { txtInvoiceDate.Text = value; }
        }
    }
}