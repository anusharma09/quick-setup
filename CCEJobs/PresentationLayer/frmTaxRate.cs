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
    public partial class frmTaxRate : Form
    {
        public frmTaxRate()
        {
            InitializeComponent();
        }

        private void frmTaxRate_Load(object sender, EventArgs e)
        {
            GetTaxRates();
        }

        private void GetTaxRates()
        {
            try
            {
                grdTaxRate.DataSource = JCCBusinessLayer.TaxRate.GetTaxRates().Tables[0];
                grdTaxRateView.Columns["Location"].Width = 300;
                grdTaxRateView.Columns["TaxRateID"].Visible = false;
                grdTaxRateView.Columns["TaxRate"].Caption = "Tax Rate";
                grdTaxRateView.Columns["TaxRate"].ColumnEdit = repTaxRate;
                grdTaxRateView.Columns["Location"].ColumnEdit = repLocation;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }

           /* grdUserView.Columns["User LANID"].ColumnEdit = repLANID;
            grdUserView.Columns["User Name"].ColumnEdit = repUserName;
            grdUserView.Columns["Email"].ColumnEdit = repEmail;
            grdUserView.Columns["Office"].ColumnEdit = StaticTables.Office;
            grdUserView.Columns["Department"].ColumnEdit = StaticTables.Department;
            grdUserView.Columns["Project Manager"].ColumnEdit = StaticTables.ProjectManager;
            grdUserView.Columns["Estimator"].ColumnEdit = StaticTables.Estimator;
            grdUserView.Columns["Sales Rep"].ColumnEdit = StaticTables.SalesRep;
            grdUserView.Columns["Job Tech"].ColumnEdit = StaticTables.JobTech;
            grdUserView.Columns["Title"].ColumnEdit = StaticTables.AccessTitle;

            grdUserView.Columns["Office"].Visible = false;
            grdUserView.Columns["Department"].Visible = false;
            grdUserView.Columns["Project Manager"].Visible = false;
            grdUserView.Columns["Estimator"].Visible = false;
            grdUserView.Columns["Sales Rep"].Visible = false;
            grdUserView.Columns["Job Tech"].Visible = false;


            grdUserView.Columns["Job Tech"].Caption = "Tech Rep";
            grdUserView.Columns["UserID"].Visible = false;
            grdUserView.BestFitColumns();
            
            */
        }

        //
        private void ProcessMenuItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "mnuAbout":
                    frmAbout frmAbount = new frmAbout();
                    frmAbount.ShowDialog();
                    break;
                case "mnuExit":
                    this.Close();
                    break;

            }
        }

        private void grdTaxRateView_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdTaxRateView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdTaxRateView.GetDataRow(grdTaxRateView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Rate?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            TaxRate.Remove(r[0].ToString());
                            grdTaxRateView.DeleteRow(grdTaxRateView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                        }
                    }
                }
            }
        }

        private void grdTaxRateView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool valid = true;
            string message = "";
            DataRow r = grdTaxRateView.GetDataRow(grdTaxRateView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Rate?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["TaxRate"].ToString().Trim() == "")
                {
                    message = "Tax Rate ..\n";
                    valid = false;
                }
                if (valid)
                {
                    UpdateRate();
                }
                else
                {
                    MessageBox.Show(message, CCEApplication.ApplicationName);
                    e.Valid = false;
                }
            }
            else
            {
                if (r["TaxRateID"] == DBNull.Value)
                    grdTaxRateView.DeleteRow(e.RowHandle);
                r.CancelEdit();
            }
        }
        //
        private void UpdateRate()
        {
            if (grdTaxRateView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdTaxRateView.GetDataRow(grdTaxRateView.GetSelectedRows()[0]);
                this.Cursor = Cursors.AppStarting;
                if (r == null)
                    return;


                try
                {
                    TaxRate rate = new TaxRate(r["TaxRateID"].ToString(),
                                        r["Location"].ToString(),
                                        r["TaxRate"].ToString());
                                     
                    rate.Save();
                    this.Cursor = Cursors.Default;
                    r["TaxRateID"] = rate.TaxRateID;
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
