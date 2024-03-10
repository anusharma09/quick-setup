using Security.BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Security
{
    internal partial class frmMasterAgreementNumber : Form
    {
        private string masterAgreementID = "";

        public frmMasterAgreementNumber ()
        {
            InitializeComponent();
        }
        //
        private void frmMasterAgreementNumber_Load ( object sender, EventArgs e )
        {
            GetMasterAgreements();
        }
        //
        private void GetMasterAgreements ()
        {
            grdMasterAgreement.DataSource = MasterAgreement.GetMasterAgreements().Tables[0];

            grdMasterAgreementView.Columns["Company"].ColumnEdit = repCompany;
            grdMasterAgreementView.Columns["MasterNumber"].ColumnEdit = repMasterNumber;
            grdMasterAgreementView.Columns["ContractDate"].ColumnEdit = repContractDate;
            grdMasterAgreementView.Columns["DateSigned"].ColumnEdit = repSignedDate;
            //grdMasterAgreementView.Columns["Link"].ColumnEdit = repLink;
            grdMasterAgreementView.Columns["MasterAgreementID"].Visible = false;
            grdMasterAgreementView.BestFitColumns();
        }

        private void grdMasterAgreementView_InvalidRowException ( object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e )
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void grdMasterAgreementView_ValidateRow ( object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e )
        {
            bool valid = true;
            string message = "";
            DataRow r = grdMasterAgreementView.GetDataRow(grdMasterAgreementView.GetSelectedRows()[0]);

            if (MessageBox.Show("Save Master Agreement Changes?", "Master Agreement Number", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Validate Fields
                if (r["Company"].ToString().Trim() == "")
                {
                    message = "Company is Required ..\n";
                    valid = false;
                }
                if (r["MasterNumber"].ToString().Trim() == "")
                {
                    message = message + "Master Number is Required ..\n";
                    valid = false;
                }

                if (valid)
                {
                    UpdateUser();
                }
                else
                {
                    MessageBox.Show(message, "Master Agreement Number");
                    e.Valid = false;
                }
            }
            else
            {
                if (r["MasterAgreementID"] == DBNull.Value)
                {
                    grdMasterAgreementView.DeleteRow(e.RowHandle);
                }

                r.CancelEdit();
            }
        }
        //
        private void UpdateUser ()
        {
            if (grdMasterAgreementView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdMasterAgreementView.GetDataRow(grdMasterAgreementView.GetSelectedRows()[0]);
                Cursor = Cursors.AppStarting;
                if (r == null)
                {
                    return;
                }

                try
                {
                    MasterAgreement agreement = new MasterAgreement(r["MasterAgreementID"].ToString(),
                                        r["Company"].ToString(),
                                        r["MasterNumber"].ToString(),
                                        r["ContractDate"].ToString(),
                                        r["DateSigned"].ToString());

                    agreement.Save();
                    masterAgreementID = agreement.MasterAgreementID;
                    Cursor = Cursors.Default;
                    r["MasterAgreementID"] = masterAgreementID;
                    GetMasterAgreements();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, "Master Agreement Number");
                }
            }
        }

        private void grdMasterAgreementView_FocusedRowChanged ( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (grdMasterAgreementView.SelectedRowsCount != 0)
            {
                DataRow r;
                r = grdMasterAgreementView.GetDataRow(grdMasterAgreementView.GetSelectedRows()[0]);
                if (r == null)
                {
                    masterAgreementID = "0";
                }
                else
                {
                    masterAgreementID = r["MasterAgreementID"].ToString();
                }
            }

        }
        private void ProcessMenuItem_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            switch (e.Item.Name)
            {
                case "mnuAbout":
                    frmAbout frmAbount = new frmAbout();
                    frmAbount.ShowDialog();
                    break;
                case "mnuExit":
                    Close();
                    break;

            }
        }

        private void grdMasterAgreementView_KeyDown ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Delete)
            {
                DataRow r = grdMasterAgreementView.GetDataRow(grdMasterAgreementView.GetSelectedRows()[0]);
                if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                {

                    if (MessageBox.Show("Delete Selected Agreement?", "Master Agreement Number", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            MasterAgreement.Delete(r[0].ToString());
                            grdMasterAgreementView.DeleteRow(grdMasterAgreementView.GetSelectedRows()[0]);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Master Agreement Number");
                        }
                    }
                }
            }
        }

        private void hyperlinkImport_Click ( object sender, EventArgs e )
        {
            try
            {
                openFile.FileName = "*.xls";
                openFile.Filter = "Excel Files|*.xls";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    ImportMasterAgreement import = new ImportMasterAgreement();
                    import.Import(@openFile.FileName);
                    GetMasterAgreements();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Master Agreement Number");
            }
        }
    }
}