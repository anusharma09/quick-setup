using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCPurchasing.BusinessLayer;
using JCCPurchasing.Controls;

namespace JCCPurchasing.Controls
{
    public partial class ctlAdHocReport : UserControl
    {
        private DataTable table;
        POListView view;
        private string query;
        private string sort;
        private string filtr;

        public ctlAdHocReport()
        {
            InitializeComponent();
        }
        public ctlAdHocReport(DataTable table,POListView view, string query, string reportFilter, string reportSort )
    
        {
            InitializeComponent();
            this.table  = table;
            this.view = view;
            this.query = query;
            this.sort = reportSort;
            this.filtr = reportFilter;
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.Reports.AdHocReport(table, view, query, radioOption.SelectedIndex, filtr, sort);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
                
        }

      
    }
}
