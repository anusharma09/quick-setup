using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;

namespace CCEJobs.Utilities
{
    public partial class frmJobProgressHistory : Form
    {
        public frmJobProgressHistory()
        {
            InitializeComponent();
        }
   

        private void frmSelect_Load(object sender, EventArgs e)
        {
            try
            {
                string lastJobSummaryPeriod = "";
                lastJobSummaryPeriod = Job.GetLastJobSummaryPeriod();
                if (lastJobSummaryPeriod.Length > 2)
                {
                    txtPreviousArchiveDate.Text = Convert.ToDateTime(lastJobSummaryPeriod).ToShortDateString();
                    txtArchivePeriod.Text = Convert.ToDateTime(lastJobSummaryPeriod).AddMonths(1).ToShortDateString();
                    txtArchivePeriod.Properties.ReadOnly = true;
                    lblCurrentPeriod.Text = "Current Period Date:";
                }
                txtPayrollHistoryDate.Text = DateTime.Today.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
  
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You are about to archive Current Job Summary. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Are you Sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Again, are you Sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;
                            Job.ArchiveJobSummary(txtArchivePeriod.Text, txtPayrollHistoryDate.Text);
                            this.Cursor = Cursors.Default;
                        }
                        catch (Exception ex)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }
    }
}