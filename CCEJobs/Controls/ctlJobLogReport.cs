using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCReports;
using JCCBusinessLayer;

namespace CCEJobs.Controls
{
    public partial class ctlJobLogReport : UserControl
    {
        public ctlJobLogReport()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string where;
            
            if (String.IsNullOrEmpty(txtStartDate.Text) || String.IsNullOrEmpty(txtEndDate.Text))
            {
                if (String.IsNullOrEmpty(txtStartDate.Text))
                    txtStartDate.ErrorText = "Start date is required";
                 if (String.IsNullOrEmpty(txtEndDate.Text))
                    txtEndDate.ErrorText = "End date is required";
            }
            else
            {
                where = " WHERE l.Date BETWEEN '" + txtStartDate.Text + "' AND '" + txtEndDate.Text + "' ";

                if (!String.IsNullOrEmpty(cboUser.Text))
                    where += " AND l.UserID = " + cboUser.EditValue.ToString();

                try
                {
                    Reports.JobLogListAll(@where, txtStartDate.Text, txtEndDate.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
            }     
        }

        private void ctlJobLogReport_Load(object sender, EventArgs e)
        {
            cboUser.Properties.DataSource = StaticTables.Users;
            cboUser.Properties.PopulateColumns();
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserID";
            cboUser.Properties.ShowHeader = false;
            cboUser.Properties.Columns[0].Visible = false;
        }
    }
}
