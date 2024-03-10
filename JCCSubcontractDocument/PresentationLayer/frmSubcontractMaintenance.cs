using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCSubcontractDocument.BusinessLayer;

namespace JCCSubcontractDocument
{
   public partial class frmSubcontractMaintenance : Form
    {
        private string jobVendorSubcontractID = "";

        public frmSubcontractMaintenance()
        {
            InitializeComponent();
        }
        //
        private void frmSubcontractMaintenance_Load(object sender, EventArgs e)
        {
             GetSubcontracts();
        }
        //
        private void GetSubcontracts()
        {
            grdSubcontract.DataSource = SubcontractDocument.GetVendorSubcontracts().Tables[0];

           
            grdSubcontractView.Columns["JobVendorSubcontractID"].Visible = false;
            grdSubcontractView.Columns["Subcontract"].ColumnEdit = repSubcontract;
            grdSubcontractView.Columns["Subcontract"].Width = 300;
        }

        private void grdSubcontractView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdSubcontractView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DataRow r = grdSubcontractView.GetDataRow(grdSubcontractView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Document Changes?", JCCSubcontractDocument.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["Subcontract"].ToString().Trim() == "")
                {
                    message = "Subcontract is Required ..\n";
                    valid = false;
                }
                if (valid)
                {
                    UpdateSubcontract();
                }
                else
                {
                    MessageBox.Show(message, JCCSubcontractDocument.CCEApplication.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["JobVendorSubcontractID"] == DBNull.Value)
                    grdSubcontractView.DeleteRow(e.RowHandle);
                r.CancelEdit();
            }
        }
        //
        private void UpdateSubcontract()
        {
            if (grdSubcontractView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdSubcontractView.GetDataRow(grdSubcontractView.GetSelectedRows()[0]);
                this.Cursor = Cursors.AppStarting;
                if (r == null)
                    return;


                try
                {
                    SubcontractDocument  document = new SubcontractDocument(r["JobVendorSubcontractID"].ToString(),
                            r["Subcontract"].ToString());
                    document.Save();
                    jobVendorSubcontractID = document.JobVendorSubcontractID;
                    this.Cursor = Cursors.Default;
                    r["JobVendorSubcontractID"] = jobVendorSubcontractID;
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, JCCSubcontractDocument.CCEApplication.ApplicationName);
                }
            }
        }

        private void grdUserView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           

        }
        //
        private void grdSubcontractView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdSubcontractView.GetDataRow(grdSubcontractView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Document?", JCCSubcontractDocument.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            SubcontractDocument.Delete(r[0].ToString());
                            grdSubcontractView.DeleteRow(grdSubcontractView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, JCCSubcontractDocument.CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

    }
}