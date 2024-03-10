using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCContactManagement.BusinessLayer;
using JCCContactManagement.Controls;

namespace JCCContactManagement.Controls
{
    public partial class ctlAdHocContactReport : UserControl
    {
        private DataTable table;
        private ContactListView view;
        string ord = "";
        string fil = "";

        public ctlAdHocContactReport()
        {
            InitializeComponent();
        }
        //
        public ctlAdHocContactReport(DataTable table,ContactListView view, string sortOrder, string filter)
    
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

               Reports.Reports.AdHocContactReport(table, view, ord, fil);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }      
        } 
    }
}
