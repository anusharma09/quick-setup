using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using System.IO;
namespace CCEJobs.PresentationLayer
{
    public partial class frmProcessingQuery : Form
    {
        private int i;
        private int j;
        private bool updated;
        private string query;
        private DataView dv;
        private bool getData;
        public frmProcessingQuery()
        {
            InitializeComponent();
        }

        public DataView GetData(string query)  
        {
            InitializeComponent();
            this.ShowDialog();
            return dv;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!getData)
                ProcessQuery();
            if (i > 40)
            {
                lblUpdate.Text = "Processing Query";
                i = 0;
            }
            else
            {
                lblUpdate.Text = lblUpdate.Text + ".";
                i = i + 1;
            }
            j = j + 1;
        }

 
        private void ProcessQuery()
        {
            //this.Cursor = Cursors.IBeam;
            try
            {
               dv = Job.GetJobList(query).Tables[0].DefaultView;
               timer1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName, MessageBoxButtons.OK);
            }
        }

    }
}