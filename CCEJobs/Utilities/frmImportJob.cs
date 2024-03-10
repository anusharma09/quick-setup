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
    public partial class frmImportJob : Form
    {
        public frmImportJob()
        {
            InitializeComponent();
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtJobNumber.Text.Trim().Length == 0)
                return;
            if (MessageBox.Show("You are about to import the entered job from Starbuilder. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Again, are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            this.Cursor = Cursors.AppStarting;
                            // Create the precess here
                            Job.ImportJob(txtJobNumber.Text.Trim());
                            // End the Process
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Job was imported successfully!", CCEApplication.ApplicationName);
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