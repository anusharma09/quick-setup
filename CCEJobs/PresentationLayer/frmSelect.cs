using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;

namespace CCEJobs.PresentationLayer
{
    public partial class frmSelect : Form
    {
        string jobStatus;
        string[] retValues = new string[2];
        public frmSelect()
        {
            InitializeComponent();
        }
        public frmSelect(string jobStatus)
        {
            InitializeComponent();
            this.jobStatus = jobStatus;
        }
        public string[] SelectList () 
        {
            this.ShowDialog();
            return retValues;
        }

  

        private void frmSelect_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Select an Estimate or a Job and\n" +
                                " Click Select to copy to the form.\n" +
                                " Click Cancel to return to the form without coping.";

            cboRevision.Properties.DataSource = StaticTables.Revision;
            cboRevision.Properties.DisplayMember = "RevisionDescription";
            cboRevision.Properties.ValueMember = "RevisionID";
            cboRevision.Properties.PopulateColumns();
            cboRevision.Properties.Columns[0].Visible = false;
            cboRevision.Properties.Columns[1].Width = 200;
            radioSelect.SelectedIndex = 1;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Boolean isReady = true;
            cboSelect.ErrorText = "";
            cboRevision.ErrorText = "";

            if (cboSelect.EditValue == null && cboRevision.EditValue == null)
            {
                retValues[0] = "";
                retValues[1] = "";
                isReady = true;
            }
            else
            {
                if (cboSelect.EditValue == null)
                {
                    retValues[0] = String.Empty;
                    cboSelect.ErrorText = "An Estimate or a Job is required!";
                    isReady = false;
                }
                else
                {
                    retValues[0] = cboSelect.EditValue.ToString();
                }
                if (!String.IsNullOrEmpty(cboRevision.Text))
                {
                    retValues[1] = cboRevision.EditValue.ToString() + " - " + cboRevision.Text.Trim();
                }
                else
                {
                    retValues[1] = String.Empty;
                    cboRevision.ErrorText = "Revision is required.";
                    isReady = false;
                }
            }
            if (isReady)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            retValues[0] = "";
            retValues[1] = "";
            this.Close();
        }

        private void cboRevision_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            if(String.IsNullOrEmpty(e.DisplayValue.ToString()))
            {
                cboRevision.EditValue = String.Empty;
                e.Handled = true;
            }
        }

        private void frmSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrEmpty(retValues[0]))
                retValues[0] = "";
            if (String.IsNullOrEmpty(retValues[1]))
                retValues[1] = "";
        }


        private void radioSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboSelect_EditValueChanged
            cboSelect.EditValueChanged -= cboSelect_EditValueChanged;
            if (radioSelect.SelectedIndex == 1)
            {
                cboSelect.Properties.DataSource = StaticTables.Jobs;
                cboSelect.Properties.DisplayMember = "Job Name";
                cboSelect.Properties.ValueMember = "JobID";
            }
            else
            {
                cboSelect.Properties.DataSource = StaticTables.Estimates;
                cboSelect.Properties.DisplayMember = "Job Name";
                cboSelect.Properties.ValueMember = "JobID";
            }
            cboSelect.EditValueChanged += new EventHandler(cboSelect_EditValueChanged);
            cboSelect.EditValue = null;
            cboSelect.Properties.PopulateColumns();
            cboSelect.Properties.Columns[0].Visible = false;
            cboSelect.Properties.Columns[1].Width = 200;

        }

        private void cboSelect_EditValueChanged(object sender, EventArgs e)
        {

        }


    }
}