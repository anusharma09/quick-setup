using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCSmallPO.BusinessLayer;
using JCCBusinessLayer;
// Atef
//using JCCSmallPO.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace JCCSmallPO.PresentationLayer
{
    public partial class frmSmallPO : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected   bool bColumnWidthChanged = false;
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     string jobNumber = "";
        private     string servCommJobNo = "";
        DataTable   smallPODataTable;
        private     bool isUpdated = false;
        private string reportJobID;
        private bool isList = false;
        //
        enum ClickedButton
        {
            Next,
            Previous,
            Delete,
            New,
            Save,
            Undo,
            Close,
            Copy
        };
        //
        public frmSmallPO()
        {
            InitializeComponent();
        }
        //
        public frmSmallPO(string recordID, string jobID, BindingSource bindingSource, bool isList)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.reportJobID        = jobID;
            this.bindingSource      = bindingSource;
            this.isList             = isList;
            InitializeComponent();
        }
        //
        private void frmSmallPO_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                if (isList)
                {
                    if (Security.Security.UserJCCSmallPOAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                    }
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly
                       || Security.Security.currentJobReadOnly)
                    {
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                    }
                }
                if (jobID != "0")
                {
                    lblJobNumber.Visible = false;
                    txtJobNumber.Visible = false;
                    txtServCommJobNo.Visible = false;
                    lblServCommJobNo.Visible = false;
                }
                if (!JCCSmallPO.BusinessLayer.StaticTables.IsLoaded)
                    JCCSmallPO.BusinessLayer.StaticTables.PopulateStaticTables();
                txtRecordID.DataBindings.Add("text", bindingSource, "JobSmallPOID");
                //
                cboVendorID.Properties.DataSource = JCCSmallPO.BusinessLayer.StaticTables.Vendor;
                cboVendorID.Properties.DisplayMember = "Name";
                cboVendorID.Properties.ValueMember = "VendorID";
                cboVendorID.Properties.PopulateColumns();
                cboVendorID.Properties.ShowHeader = false;
                cboVendorID.Properties.Columns[0].Visible = false;
                // TaxRateID - Location - TaxRate
                DataTable tbl;
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();

                tbl = JCCSmallPO.BusinessLayer.StaticTables.TaxRate;
                repTaxRate.DataSource = tbl;
                repTaxRate.DisplayMember = "TaxRate";
                repTaxRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                repTaxRate.DisplayFormat.FormatString = "p4";
                repTaxRate.ValueMember = "TaxRate";
                col.Caption = "ID";
                col.FieldName = "TaxRateID";
                col.Visible = false;
                repTaxRate.Columns.Add(col);
                col1.Caption = "Location";
                col1.FieldName = "Location";
                col1.Visible = true;
                repTaxRate.Columns.Add(col1);

                col2.Caption = "TaxRate";
                col2.FieldName = "TaxRate";
                col2.Visible = true;
                repTaxRate.Columns.Add(col2);
                repTaxRate.Columns[2].FormatString = "p4";
                repTaxRate.Columns[2].FormatType = DevExpress.Utils.FormatType.Custom;

                //
                cboPOAddress.Properties.DataSource = JCCSmallPO.BusinessLayer.StaticTables.POAddress;
                cboPOAddress.Properties.DisplayMember = "Type";
                cboPOAddress.Properties.ValueMember = "Type";
                cboPOAddress.Properties.PopulateColumns();
                cboPOAddress.Properties.ShowHeader = false;



                //
                // UOM
                //
                DataTable table = new DataTable();

                // Create two columns, ID and Name.
                DataColumn idColumn = table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Name", typeof(string));

                // Set the ID column as the primary key column.
                table.PrimaryKey = new DataColumn[] { idColumn };

                table.Rows.Add(new object[] { 1, "E - 1 Unit" });
                table.Rows.Add(new object[] { 100, "C - 100 Units" });
                table.Rows.Add(new object[] { 1000, "M - 1000 Units" });

                DevExpress.XtraEditors.Controls.LookUpColumnInfo col11 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col12 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();

                repUOM.DataSource = table;
                repUOM.DisplayMember = "ID";
                repUOM.ValueMember = "ID";
                col11.Caption = "ID";
                col11.FieldName = "ID";
                col11.Visible = false;
                repUOM.Columns.Add(col11);
                col12.Caption = "Name";
                col12.FieldName = "Name";
                col12.Visible = true;
                repUOM.Columns.Add(col12);

       
                
                
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetSmallPO();
                }
                else
                {
                    GetSmallPO();
                    ribbonReport.Visible = true;
                }
                this.Opacity = 1;
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetSmallPODetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateSmallPO(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtJobNumber.Text = "";
                txtServCommJobNo.Text = "";
                txtSmallPONumber.Text = "";
                txtCreatedDate.Text = "";
                txtCreatedBy.Text = "";
                txtShipTo.Text = "";
                txtShipToAddress.Text = "";
                txtShipToCity.Text = "";
                txtShipToState.Text = "";
                txtShipToZip.Text = "";
                cboVendorID.EditValue = null;
                cboShipVia.Text = "";
                txtNote.Text = "";
                txtTotal.Text = "";
                txtShipping.Text = "";
                txtSubTotal.Text = "";
                txtSalesTax.Text = "";
                chkAttachmentA.CheckState = CheckState.Unchecked;
                chkNotification.CheckState = CheckState.Unchecked;
                chkNoUPSDHL.CheckState = CheckState.Unchecked;
                chkPaymentNet30.CheckState = CheckState.Unchecked;
                // Get the job note at that time
                // and Job Address
                if (jobID != "0" && jobID != "")
                {
                    GetAddressNote();
                }
                UnProtectForm();
            }
            GetSmallPOItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            //txtJobNumber.Properties.ReadOnly = true;
            //txtServCommJobNo.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            //txtJobNumber.Properties.ReadOnly = false;
            //txtServCommJobNo.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSmallPOItemView, "frmSmallPO");

            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSmallPOItemView, "frmSmallPO");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }


            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Small PO":
                    if (CheckSmallPOStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSmallPO();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Small PO":
                    if (CheckSmallPOStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetSmallPO();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckSmallPOStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetSmallPO();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckSmallPOStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetSmallPO();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    //btnCopy.Enabled = true;
                    break;
                /*case "&Copy":
                    recordID = "0";
                    txtRecordID.Text = "0";
                    txtJobRFINumber.Text = "";
                    ribbonReport.Visible = false;
                    dataChanged = true;
                    btnUndo.Enabled = false;
                    btnCopy.Enabled = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    UnProtectForm();
                    break;*/
                case "Small PO":
                    try
                    {
                       Reports.Reports.SmallPOForm(reportJobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckSmallPOStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveSmallPO();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Please make sure to enter all required fields.", CCEApplication.ApplicationName);
                        return false;
                    }
                }
                else
                {
                    bindingSource.CancelEdit();
                    if (SelectedButton == ClickedButton.Save)
                        return false;
                    else
                    {
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        dxErrorProvider.ClearErrors();
                        return true;
                    }
                }
            }
            else
            {
                bindingSource.CancelEdit();
                dataChanged = false;
                btnUndo.Enabled = false;
                //btnCopy.Enabled = true;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveSmallPO()
        {
           try
           {
               SmallPO smallPO = new SmallPO(recordID,
                                            jobID,
                                            txtServCommJobNo.Text,
                                            cboVendorID.EditValue == null ? null : cboVendorID.EditValue.ToString(),
                                            cboShipVia.Text,
                                            txtShipTo.Text,
                                            txtShipToAddress.Text,
                                            txtShipToCity.Text,
                                            txtShipToState.Text,
                                            txtShipToZip.Text,
                                            txtNote.Text,
                                            txtShipping.EditValue == null ? null : txtShipping.EditValue.ToString(),
                                            txtSubTotal.EditValue == null ? null : txtSubTotal.EditValue.ToString(),
                                            txtSalesTax.EditValue == null ? null : txtSalesTax.EditValue.ToString(),
                                            txtTotal.EditValue == null ? null : txtTotal.EditValue.ToString(),
                                            chkAttachmentA.Checked.ToString(),
                                            chkNoUPSDHL.Checked.ToString(),
                                            chkNotification.Checked.ToString(),
                                            chkPaymentNet30.Checked.ToString());                        
                smallPO.Save(); 

                if (recordID == "" || recordID == "0")
                {
                    recordID = smallPO.JobSmallPOID;
                    DataRow r = SmallPO.GetCreatUpdate(recordID).Tables[0].Rows[0];
                    txtCreatedDate.EditValue = r["PODate"];
                    txtCreatedBy.Text = r["CreatedByName"].ToString();
                    txtSmallPONumber.Text = r["SmallPONumber"].ToString();
                }        
                txtRecordID.Text = recordID;
                SaveSmallPOItems(); 
                SetControlAccess();
                ProtectForm();
                changesStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
        }
        //
        private void GetSmallPO()
        {
            GetSmallPODetail(recordID);
            SetControlAccess();
        }
        //
        private void ControlValidating(object sender, CancelEventArgs e)
        {
            UpdateErrorMessages();
        }
        //
        private bool ValidateAllControls()
        {
            UpdateErrorMessages();
            return !errorMessages;
        }
        //
        private void AllControls_EditValue(Object sender, EventArgs e)
        {
           /* DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
            if (myControl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
            {
              //  string myString = myControl.Text.Trim().ToUpper();

               // if (myString != myControl.Text.Trim())
               //     myControl.Text = myControl.Text.ToString().ToUpper();
            }*/
            if (!dataChanged)
            {
                if (isList)
                {
                    if ( Security.Security.UserJCCSmallPOAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                    }
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly ||
                    Security.Security.currentJobReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                    }
                }
            }
        }
        //
        private void frmSmallPO_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSmallPOItemView, "frmSmallPO");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckSmallPOStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateSmallPO(string recordID)
        {
            try
            {
                DataRow r;
                r = SmallPO.GetSmallPO(recordID).Tables[0].Rows[0];
                reportJobID                     = r["JobID"].ToString();
                txtJobNumber.Text               = r["JobNumber"].ToString();
                txtServCommJobNo.Text           = r["ServCommJobNo"].ToString();
                txtSmallPONumber.Text           = r["SmallPONumber"].ToString();
                cboVendorID.EditValue           = r["VendorID"];
                txtCreatedDate.EditValue        = r["PODate"];
                cboShipVia.Text                 = r["ShipVia"].ToString();
                txtShipTo.Text                  = r["ShipTo"].ToString();
                txtShipToAddress.Text           = r["ShipToAddress"].ToString();
                txtShipToCity.Text              = r["ShipToCity"].ToString();
                txtShipToState.Text             = r["ShipToState"].ToString();
                txtShipToZip.Text               = r["ShipToZip"].ToString();
                txtNote.Text                    = r["Note"].ToString();
                txtShipping.EditValue           = r["Shipping"];
                txtSubTotal.EditValue           = r["Subtotal"];
                txtSalesTax.EditValue           = r["SalesTax"];
                txtTotal.EditValue              = r["Total"];
                txtCreatedBy.Text               = r["CreatedByName"].ToString();
                chkAttachmentA.EditValue        = r["AttachmentA"];
                chkNotification.EditValue       = r["Notification"];
                chkNoUPSDHL.EditValue           = r["NoUPSDHL"];
                chkPaymentNet30.EditValue       = r["PaymentNet30"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtJobNumber.ErrorText = "";
            txtServCommJobNo.ErrorText = "";
            cboVendorID.ErrorText = "";
            cboShipVia.ErrorText = "";
                        
            errorMessages = false;
            //
            if (txtJobNumber.Visible)
            {
               // if (recordID == "" || recordID == "0")
                {
                    if (txtJobNumber.Text.Trim().Length == 0 && txtServCommJobNo.Text.Trim().Length == 0)
                    {
                        //txtJobNumber.ErrorText = "Job Number is Required";
                        //errorMessages = true;
                    }
                    else
                    {
                        if (txtJobNumber.Text.Trim().Length > 0 && txtServCommJobNo.Text.Trim().Length > 0)
                        {
                            txtJobNumber.ErrorText = "You either enter Job No. OR ServComm Job No";
                            txtServCommJobNo.ErrorText = "You either enter Job No. OR ServComm Job No";
                            errorMessages = true;
                        }
                        else
                        {
                            if (txtJobNumber.Text.Trim().Length > 0)
                            {
                                jobID = SmallPO.GetJobID(txtJobNumber.Text.Trim());
                                if (jobID == "0" || jobID == "")
                                {
                                    txtJobNumber.ErrorText = "Job does not exist or your access is denied!";
                                    errorMessages = true;
                                }
                                else
                                    reportJobID = jobID;
                            }
                        }
                    }
                }
            }
            //
            if (cboVendorID.Text == "")
            {
                cboVendorID.ErrorText = "Vendor is Requried";
                errorMessages = true;
            }
            //
            if (cboShipVia.Text.Trim() == "")
            {
                cboShipVia.ErrorText = "Ship Via is Required";
                errorMessages = true;
            }
        }
        //
        private void GetSmallPOItems(string jobSmallPOID)
        {
            try
            {
                smallPODataTable = SmallPODetail.GetJobSmallPOItems(jobSmallPOID).Tables[0];

                this.grdSmallPOItem.DataSource = smallPODataTable.DefaultView;

                grdSmallPOItemView.Columns["JobSmallPODetailID"].Visible = false;
                grdSmallPOItemView.Columns["Tax Rate"].ColumnEdit = repTaxRate;
                grdSmallPOItemView.Columns["UOM"].ColumnEdit = repUOM;
                grdSmallPOItemView.Columns["Quantity"].ColumnEdit = repQuantity;
                grdSmallPOItemView.Columns["Description"].ColumnEdit = repDescription;
                grdSmallPOItemView.Columns["Phase"].ColumnEdit = repPhase;
                grdSmallPOItemView.Columns["Price"].ColumnEdit = repPrice;
                grdSmallPOItemView.Columns["Cost Code"].ColumnEdit = repPhase;
                grdSmallPOItemView.Columns["Amount"].ColumnEdit = repPrice;
                grdSmallPOItemView.Columns["Amount"].Caption = "Total";
                grdSmallPOItemView.BestFitColumns();
                grdSmallPOItemView.Columns["Description"].Width = 200;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSmallPOItemView, "frmSmallPO");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            if (recordID == "" || recordID == "0")
            {
                grdSmallPOItemView.OptionsBehavior.Editable = false;
                grdSmallPOItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                Note.Enabled = false;
            }
            else
            {
                if (isList)
                {
                    if (Security.Security.UserJCCSmallPOAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                        grdSmallPOItemView.OptionsBehavior.Editable = false;
                        grdSmallPOItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        Note.Enabled = false;
                    }
                    else
                    {
                        grdSmallPOItemView.OptionsBehavior.Editable = true;
                        grdSmallPOItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        grdSmallPOItemView.Columns["Amount"].OptionsColumn.AllowEdit = false;
                        grdSmallPOItemView.Columns["Line No"].OptionsColumn.AllowEdit = false;
                        Note.Enabled = true;
                    }
                }
                else
                { 
                     if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly ||
                    Security.Security.currentJobReadOnly)
                     {
                         grdSmallPOItemView.OptionsBehavior.Editable = false;
                         grdSmallPOItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        Note.Enabled = false;
                     }
                     else
                     {
                         grdSmallPOItemView.OptionsBehavior.Editable = true;
                         grdSmallPOItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                         grdSmallPOItemView.Columns["Amount"].OptionsColumn.AllowEdit = false;
                         grdSmallPOItemView.Columns["Line No"].OptionsColumn.AllowEdit = false;
                        Note.Enabled = true;
                     }
                }

            }
        }
        //
        private void SaveSmallPOItems()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                SmallPODetail smallPODetail;
                if (smallPODataTable != null)
                {
                    foreach (DataRow r in smallPODataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                 smallPODetail = new SmallPODetail(
                                                    r["JobSmallPODetailID"].ToString(),
                                                    recordID,
                                                    r["Quantity"].ToString(),
                                                    r["Description"].ToString(),
                                                    r["Phase"].ToString(),
                                                    r["Cost Code"].ToString(),
                                                    r["Price"].ToString(),
                                                    r["UOM"].ToString(),
                                                    r["Tax Rate"].ToString(),
                                                    r["Amount"].ToString());
                                smallPODetail.Save();
                                r["JobSmallPODetailID"] = smallPODetail.JobSmallPODetailID;
                                r["Line No"] = smallPODetail.ItemNumber;
                                break;
                            case DataRowState.Deleted:
                                try
                                {
                                    if (r["JobSmallPODetailID"].ToString().Trim().Length > 0)
                                    {
                                        SmallPODetail.Remove(r["JobSmallPODetailID"].ToString());
                                    }
                                }
                                catch { }
                                break;
                        }
                    }
                }
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void gridMaterialOrderItemView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCSmallPOAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            decimal subtotal = 0;
            decimal salesTax = 0;
            decimal a = 0;
            decimal b = 0;
            foreach (DataRow dr in smallPODataTable.Rows)
            {
                a = 0;
                b = 0;
                decimal.TryParse(dr["Amount"].ToString(), out a);
                decimal.TryParse(dr["Tax Rate"].ToString(), out b);
                subtotal = subtotal + a;
                salesTax = salesTax + (a * b);
            }
            txtSubTotal.EditValue = subtotal;
            txtSalesTax.EditValue = salesTax;
        }

        //
        private void grdSmallPOItemView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Delete")
            {
                DataRow r = grdSmallPOItemView.GetDataRow(grdSmallPOItemView.GetSelectedRows()[0]);
                if (r == null)
                    return;
                string id = r[0].ToString();
               // if (id == "")
                //    return;
                if (MessageBox.Show("Delete Item?", CCEApplication.ApplicationName,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if(r["JobSmallPODetailID"].ToString().Trim().Length > 0)
                           SmallPODetail.Remove(r["JobSmallPODetailID"].ToString());
                        r.Delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                }
            }
        }
        //
        private void txtJobNumber_Validated(object sender, EventArgs e)
        {
            if (txtJobNumber.Properties.ReadOnly == false && txtJobNumber.Text.Trim().Length > 0)// && txtShipTo.Text.Trim().Length == 0)
            {
                jobID = SmallPO.GetJobID(txtJobNumber.Text.Trim());
                if (jobID == "0" || jobID == "")
                {
                    txtJobNumber.ErrorText = "Job does not exist or your access is denied!";
                    if (cboPOAddress.Text == null || cboPOAddress.Text.Trim().Length == 0)
                    {
                        //GetAddressNote();
                    }
                }
                else
                {
                   // GetAddressNote();
                }

            }
        }
        private void GetAddressNote()
        {
            // Get Ship to Address
            DataTable t = SmallPO.GetShipToAddress(jobID).Tables[0];
            if (t.Rows.Count > 0)
            {
                DataRow r = t.Rows[0];
                txtShipTo.Text = r["JobName"].ToString();
                txtShipToAddress.Text = r["JobAddress1"].ToString();
                txtShipToCity.Text = r["JobCity"].ToString();
                txtShipToState.Text = r["JobState"].ToString();
                txtShipToZip.Text = r["JobZip"].ToString();
            }
            t = SmallPO.GetSmallPONote(jobID).Tables[0];
            if (t.Rows.Count > 0 && txtNote.Text.Trim().Length == 0)
                txtNote.Text = t.Rows[0][0].ToString();
        }
        private void grdSmallPOItemView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow r = grdSmallPOItemView.GetDataRow(e.RowHandle);
            if (r != null)
            {
                decimal quantity = 0;
                decimal price = 0;
                decimal uom = 0;
                decimal total = 0;
                decimal calcPrice = 0;

                decimal.TryParse(r["Quantity"].ToString(), out quantity);
                decimal.TryParse(r["Price"].ToString(), out price);
                decimal.TryParse(r["UOM"].ToString(), out uom);

                if (uom != 0)
                    calcPrice = price / uom;
                total = calcPrice * quantity;
                r["Amount"] = total;
                grdSmallPOItemView.RefreshRow(e.RowHandle);
                
            }
        }

        private void txtShipping_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
            AllControls_EditValue(sender, e);
        }
        private void CalculateTotal()
        {
            decimal subtotal = 0;
            decimal salesTax = 0;
            decimal shipping = 0;
            try
            {
                decimal.TryParse(txtSubTotal.EditValue.ToString(), out subtotal);
                decimal.TryParse(txtSalesTax.EditValue.ToString(), out salesTax);
                decimal.TryParse(txtShipping.EditValue.ToString(), out shipping);

                txtTotal.EditValue = subtotal + salesTax + shipping;
            }
            catch { }
        }

        private void txtSubTotal_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtSalesTax_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void grdSmallPOItemView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void cboPOAddress_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtShipTo.Text = string.Empty;
                //Job.GetJobOffice(jobID).Tables[0];
                if (cboPOAddress.EditValue != null && cboPOAddress.Text.Trim().Length > 0)
                {
                    DataTable t;
                    string type = cboPOAddress.EditValue.ToString().ToUpper();
                    txtShipTo.Text = string.Empty;
                    switch (type)
                    {
                      /*  case "OFFICE":
                            t = Job.GetJobOffice(jobID).Tables[0];
                            if (t.Rows.Count > 0)
                            {
                                txtShipToAddress.Text = t.Rows[0]["Address"].ToString();
                                txtShipToCity.Text = t.Rows[0]["City"].ToString();
                                txtShipToState.Text = t.Rows[0]["State"].ToString();
                                txtShipToZip.Text = t.Rows[0]["ZipCode"].ToString();
                            }
                            break; */
                        case "JOB SITE":
                            if (txtJobNumber.Visible == true && txtJobNumber.Text.Trim().Length > 0)
                                t = Job.GetJobAddressByJobNumber(txtJobNumber.Text).Tables[0];
                            else
                                t = Job.GetJobAddressByJobID(jobID).Tables[0];

                            if (t.Rows.Count > 0)
                            {
                                txtShipToAddress.Text = t.Rows[0]["JobAddress1"].ToString();
                                txtShipToCity.Text = t.Rows[0]["JobCity"].ToString();
                                txtShipToState.Text = t.Rows[0]["JobState"].ToString();
                                txtShipToZip.Text = t.Rows[0]["JobZip"].ToString();
                            }
                            break;
                        case "OTHER":
                            break;
                        default:
                            t = Job.GetPOAddressByType(type).Tables[0];
                            if (t.Rows.Count > 0)
                            {
                                txtShipTo.Text = string.Empty;
                                txtShipToAddress.Text = t.Rows[0]["ShipToAddress"].ToString();
                                txtShipToCity.Text = t.Rows[0]["ShipToCity"].ToString();
                                txtShipToState.Text = t.Rows[0]["ShipToState"].ToString();
                                txtShipToZip.Text = t.Rows[0]["ShipToZip"].ToString();
                            }
                            break;
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void txtJobNumber_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("Leave function!");
        }

        private void Note_Click(object sender, EventArgs e)
        {
            ControlsLibrary.MSWord f = new ControlsLibrary.MSWord();
            f.MyText = txtNote.Text;
            f.ShowDialog();
            txtNote.Text = f.MyText;

            if (!dataChanged)
            {
                dataChanged = true;
                btnUndo.Enabled = true;
                btnSave.Enabled = true;
            }
        }
    }
}