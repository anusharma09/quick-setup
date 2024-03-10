using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCSmallPO.BusinessLayer;
using JCCSmallPO.Controls;

namespace JCCSmallPO.Controls
{
    public partial class ctlAdHocReport : UserControl
    {
        private DataTable table;
        private SmallPOListView view;
        string ord = "";
        string fil = "";

        public ctlAdHocReport()
        {
            InitializeComponent();
        }
        //
        public ctlAdHocReport(DataTable table,SmallPOListView view, string sortOrder, string filter)
    
        {
            InitializeComponent();
            this.table  = table;
            this.view = view;
            this.ord = sortOrder;
            this.fil = filter;
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

               Reports.Reports.AdHocReport(table, view, ord, fil);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }      
        } 
    }
}
