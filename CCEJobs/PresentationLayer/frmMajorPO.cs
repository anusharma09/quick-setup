using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using JCCReports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace CCEJobs.PresentationLayer
{
    public partial class frmMajorPO : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChanged = false;
        protected string recordID;
        protected string jobID;
        protected BindingSource bindingSource;
        protected bool dataChanged;
        private bool errorMessages = false;
        protected DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected string currentButtonName = "";
        private bool changesStatus = false;
        private DataTable jobMajorPODetailDataTable;
        //
        private float salesTaxPercentCost = 0;
        private float salesTaxCost = 0;
        private float subtotalCost = 0;
        private float totalCost = 0;
        private string type = "";
        private bool updateCalc = true;
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
        public frmMajorPO()
        {
            InitializeComponent();
        }
        //
        public frmMajorPO(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID = recordID;
            this.jobID = jobID;
            this.bindingSource = bindingSource;
            InitializeComponent();
        }
        //
        private void frmMajorPO_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "JobMajorPOID");
                //
                cboVendorID.Properties.DataSource = StaticTables.Vendors;
                cboVendorID.Properties.DisplayMember = "Name";
                cboVendorID.Properties.ValueMember = "VendorID";
                cboVendorID.Properties.PopulateColumns();
                cboVendorID.Properties.ShowHeader = false;
                cboVendorID.Properties.Columns[0].Visible = false;
                //
                //
                cboSubcontract.Properties.DataSource = StaticTables.Subcontract;
                cboSubcontract.Properties.DisplayMember = "JobVendorSubcontract";
                cboSubcontract.Properties.ValueMember = "JobVendorSubcontractID";
                cboSubcontract.Properties.PopulateColumns();
                cboSubcontract.Properties.ShowHeader = false;
                //cboSubcontract.Properties.Columns[0].Visible = false;
                //
                cboCostCodes.Properties.DataSource = MajorPO.GetJobMajorPOCostCodes(jobID).Tables[0];
                cboCostCodes.Properties.DisplayMember = "Description";
                cboCostCodes.Properties.ValueMember = "JobCostCodePhaseID";
                cboCostCodes.Properties.PopulateColumns();
                cboCostCodes.Properties.ShowHeader = false;
                cboCostCodes.Properties.BestFit();
                cboCostCodes.Properties.Columns[0].Visible = false;
                //
                cboSubcontractor.Properties.DataSource = Contact.GetJobContactCompanyForPullDown(jobID).Tables[0];
                cboSubcontractor.Properties.DisplayMember = "Company";
                cboSubcontractor.Properties.ValueMember = "ContactID";
                cboSubcontractor.Properties.PopulateColumns();
                cboSubcontractor.Properties.ShowHeader = false;
                //
                cboPOAddress.Properties.DataSource = StaticTables.POAddress;
                cboPOAddress.Properties.DisplayMember = "Type";
                cboPOAddress.Properties.ValueMember = "Type";
                cboPOAddress.Properties.PopulateColumns();
                cboPOAddress.Properties.ShowHeader = false;

                //cboSubcontractor.Properties.Columns[0].Visible = false;
                //
                //UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetMajorPO();
                }
                else
                {
                    GetMajorPO();
                    ribbonReport.Visible = true;
                }
                UpdateErrorMessages();
                this.Opacity = 1;
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetMajorPODetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                cboCostCodes.EditValue = null;
                UpdateMajorPO(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtMajorPONumber.Text = "";
                cboVendorID.EditValue = null;
                cboCostCodes.EditValue = null;
                txtShipTo.Text = "";
                txtShipToAddress.Text = "";
                txtShipToCity.Text = "";
                txtShipToState.Text = "";
                txtShipToZip.Text = "";
                txtPODate.Text = "";
                txtPhase.Text = "";
                txtCostCode.Text = "";
                txtSalesTaxPercent.EditValue = null;
                txtNote.Text = "";
                txtSalesTax.EditValue = null;
                txtSubtotal.EditValue = null;
                txtTotal.EditValue = null;
                txtPOType.Text = "";
                cboSubcontractor.EditValue = null;
                cboSubcontract.EditValue = null;
                txtWorkDescription.Text = "";
                txtSubcontractAmount.Text = "";
                salesTaxPercentCost = 0;
                salesTaxCost = 0;
                subtotalCost = 0;
                totalCost = 0;
                type = "";
                cboStatus.SelectedIndex = 0;
                cboStatus.Properties.ReadOnly = false;
                try
                {
                    DataTable t = MajorPO.GetJobMajorPONote(jobID).Tables[0];
                    if (t.Rows.Count > 0)
                        txtNote.Text = t.Rows[0]["MajorPONote"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                }
                UnProtectForm();
            }
            GetMajorPOItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            if (cboStatus.Text == "Approved")
            {
                txtMajorPONumber.Properties.ReadOnly = true;
                cboVendorID.Properties.ReadOnly = true;
                cboCostCodes.Properties.ReadOnly = true;
            }
            else
            {
                UnProtectForm();
            }
            // cboCostCodes.EditValue = null;
        }
        //
        private void UnProtectForm()
        {
            txtMajorPONumber.Properties.ReadOnly = false;
            cboVendorID.Properties.ReadOnly = false;
            cboCostCodes.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridMajorPOView, "frmMajorPO");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "Next Major PO":
                    if (CheckMajorPOStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetMajorPO();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Major PO":
                    if (CheckMajorPOStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetMajorPO();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckMajorPOStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetMajorPO();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckMajorPOStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetMajorPO();
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
                case "Major PO":
                    try
                    {
                        Reports.MajorPO(jobID, recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;

                case "Attachment (MPO)":
                    try
                    {
                        WordDocuments.PrintAttachmentMPO(recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;

                case "Subcontract Agreement":
                    try
                    {
                        WordDocuments.PrintSubcontractAgreement(recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;

            }
        }

        //
        private bool CheckMajorPOStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    {
                        SaveMajorPO();
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
        private void SaveMajorPO()
        {
            try
            {
                MajorPO majorPO = new MajorPO(recordID,
                                    jobID,
                                    txtMajorPONumber.Text,
                                    cboVendorID.EditValue.ToString(),
                                    txtPOType.Text,
                                    txtPODate.Text,
                                    txtPhase.Text,
                                    txtCostCode.Text,
                                    txtNote.Text,
                                    txtSalesTaxPercent.EditValue == null ? "" : txtSalesTaxPercent.EditValue.ToString(),
                                    txtSubtotal.EditValue.ToString(),
                                    txtSalesTax.EditValue.ToString(),
                                    txtTotal.EditValue.ToString(),
                                    cboSubcontractor.EditValue == null ? "" : cboSubcontractor.EditValue.ToString(),
                                    txtWorkDescription.Text,
                                    txtSubcontractAmount.Text,
                                    cboSubcontract.EditValue == null ? "" : cboSubcontract.EditValue.ToString(),
                                    cboStatus.Text,
                                    txtShipTo.Text,
                                    txtShipToAddress.Text,
                                    txtShipToCity.Text,
                                    txtShipToState.Text,
                                    txtShipToZip.Text);

                majorPO.Save();

                recordID = majorPO.JobMajorPOID;
                txtRecordID.Text = recordID;
                SaveMajorPOItems();
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
            //btnCopy.Enabled = true;
        }
        //
        private void GetMajorPO()
        {
            GetMajorPODetail(recordID);
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
            /*  DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
              if (myControl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
              {
                //  string myString = myControl.Text.Trim().ToUpper();

                 // if (myString != myControl.Text.Trim())
                 //     myControl.Text = myControl.Text.ToString().ToUpper();
              }*/
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    //btnCopy.Enabled = false;
                }

            }
            if (updateCalc)
                CalculateValues();
        }
        //
        private void CalculateValues()
        {
            salesTaxPercentCost = 0;
            salesTaxCost = 0;
            subtotalCost = 0;
            totalCost = 0;
            float amount = 0;

            /* Calculate Material */
            if (txtSalesTaxPercent.EditValue != null)
                float.TryParse(txtSalesTaxPercent.EditValue.ToString(), out salesTaxPercentCost);
            if (jobMajorPODetailDataTable != null && jobMajorPODetailDataTable.Rows.Count > 0)
            {
                foreach (DataRow r in jobMajorPODetailDataTable.Rows)
                {
                    float.TryParse(r["Amount"].ToString(), out amount);
                    subtotalCost += amount;
                }
            }

            salesTaxCost = subtotalCost * salesTaxPercentCost;
            totalCost = subtotalCost + salesTaxCost;

            txtSalesTax.EditValue = salesTaxCost;
            txtSubtotal.EditValue = subtotalCost;
            txtTotal.EditValue = totalCost;



            if (recordID == "" || recordID == "0")
            {
                switch (type)
                {
                    case "M":
                        if (totalCost < 25000)
                            txtPOType.Text = "SPO";
                        else
                            txtPOType.Text = "MPO";
                        break;
                    case "S":
                        txtPOType.Text = "SUB";
                        break;
                    default:
                        txtPOType.Text = "";
                        break;
                }

            }
            else
            {
                switch (txtPOType.Text)
                {
                    case "MPO":
                        if (totalCost < 25000)
                            txtPOType.Text = "SPO";
                        break;
                    case "SPO":
                        if (totalCost >= 25000)
                            txtPOType.Text = "MPO";
                        break;
                }
            }
            //
        }
        //
        private void frmMajorPO_FormClosed(object sender, FormClosedEventArgs e)
        {
            bColumnWidthChanged = false;
            try
            {
                Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridMajorPOView, "frmMajorPO");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            CheckMajorPOStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateMajorPO(string recordID)
        {
            updateCalc = false;
            try
            {
                DataRow r;
                r = MajorPO.GetJobMajorPODetail(recordID).Tables[0].Rows[0];

                txtMajorPONumber.Text = r["MajorPONumber"].ToString();
                cboVendorID.EditValue = r["VendorID"].ToString();
                txtShipTo.Text = r["ShipTo"].ToString();
                txtShipToAddress.Text = r["ShipToAddress"].ToString();
                txtShipToCity.Text = r["ShipToCity"].ToString();
                txtShipToState.Text = r["ShipToState"].ToString();
                txtShipToZip.Text = r["ShipToZip"].ToString();
                txtPODate.EditValue = String.IsNullOrEmpty(r["PODate"].ToString()) ? null : r["PODate"];

                txtPhase.Text = r["Phase"].ToString();
                txtCostCode.Text = r["CostCode"].ToString();
                txtNote.Text = r["Note"].ToString();
                txtSalesTaxPercent.EditValue = r["SalesTaxPercent"];
                txtSubtotal.EditValue = r["Subtotal"];
                txtSalesTax.EditValue = r["SalesTax"];
                txtTotal.EditValue = r["Total"];

                txtPOType.Text = r["POType"].ToString();
                cboSubcontractor.EditValue = r["SubcontractorID"];
                txtWorkDescription.Text = r["WorkDescription"].ToString();
                txtSubcontractAmount.Text = r["SubcontractAmount"].ToString();
                cboSubcontract.EditValue = r["JobVendorSubcontractID"];
                cboStatus.Text = r["Status"].ToString();
                if (cboStatus.Text == "Approved")
                    cboStatus.Properties.ReadOnly = true;
                else
                    cboStatus.Properties.ReadOnly = false;
                if (cboStatus.Text.Trim().Length == 0)
                    cboStatus.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
            finally
            {
                updateCalc = true;
            }
        }
        //
        private void UpdateErrorMessages()
        {
            float subtotal = 0;
            float total = 0;
            errorMessages = false;

            txtMajorPONumber.ErrorText = "";
            cboVendorID.ErrorText = "";
            txtPODate.ErrorText = "";
            txtPhase.ErrorText = "";
            txtCostCode.ErrorText = "";

            txtSubtotal.ErrorText = "";
            txtTotal.ErrorText = "";
            cboSubcontract.ErrorText = "";

            try
            {
                float.TryParse(txtTotal.EditValue.ToString(), out total);
                float.TryParse(txtSubtotal.EditValue.ToString(), out subtotal);
            }
            catch { }
            if (total == 0 && (recordID != "0" && recordID != ""))
            {
                txtSubtotal.ErrorText = "Subtotal Amount is Required";
                txtTotal.ErrorText = "Total Amount is Required";
                errorMessages = true;
            }
            //
            if (txtMajorPONumber.Text.Trim().Length == 0)
            {
                txtMajorPONumber.ErrorText = " PO Number is Required";
            }
            else
            {
                if (!txtMajorPONumber.Properties.ReadOnly)
                {
                    if (MajorPO.IsPONumberDuplicate(recordID, jobID, txtMajorPONumber.Text.Trim()))
                    {
                        txtMajorPONumber.ErrorText = "Duplicate PO Number";
                        errorMessages = true;
                    }
                }
            }
            //
            if (cboVendorID.Text.Trim() == "")
            {
                cboVendorID.ErrorText = "Vendor is Required";
                errorMessages = true;
            }
            //
            if (txtPODate.Text.Trim() == "")
            {
                txtPODate.ErrorText = "PO Date is Required";
                errorMessages = true;
            }
            //
            if (txtPhase.Text.Trim() == "")
            {
                txtPhase.ErrorText = "Phase is Required";
                errorMessages = true;
            }
            //
            if (txtCostCode.Text.Trim() == "")
            {
                txtCostCode.ErrorText = "Cost Code is Required";
                errorMessages = true;
            }
            if (tabMajor.TabPages[1].PageVisible == true)
            {
                if (cboSubcontract.EditValue == null || cboSubcontract.EditValue.ToString().Length == 0)
                {
                    cboSubcontract.ErrorText = "Subcontract is Required";
                    errorMessages = true;
                }
            }

        }
        //
        private void GetMajorPOItems(string jobMajorPOID)
        {
            try
            {
                jobMajorPODetailDataTable = MajorPODetail.GetMajorPODetail(jobMajorPOID).Tables[0];

                this.grdMajorPO.DataSource = jobMajorPODetailDataTable.DefaultView;

                gridMajorPOView.Columns["JobMajorPOID"].Visible = false;
                gridMajorPOView.Columns["JobMajorPODetailID"].Visible = false;
                gridMajorPOView.Columns["RevisionNumber"].Caption = "Rev. Number";
                gridMajorPOView.Columns["WorkDescription"].Caption = "Work Description";
                gridMajorPOView.Columns["RevisionDate"].Caption = "Rev. Date";
                gridMajorPOView.Columns["Amount"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                gridMajorPOView.Columns["WorkDescription"].ColumnEdit = repWorkDescriptionMem;
                gridMajorPOView.Columns["Amount"].ColumnEdit = repAmount;
                gridMajorPOView.Columns["RevisionNumber"].ColumnEdit = repRevisionNumber;
                gridMajorPOView.Columns["Amount"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridMajorPOView.Columns["Amount"].DisplayFormat.FormatString = "{0:c2}";
                gridMajorPOView.Columns["RevisionDate"].VisibleIndex = 2;
                gridMajorPOView.Columns["Amount"].VisibleIndex = 3;
                gridMajorPOView.BestFitColumns();
                gridMajorPOView.Columns["WorkDescription"].Width = 400;
                gridMajorPOView.Columns["Amount"].Width = 75;
                //   Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridMajorPOView, "frmMajorPO");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            try
            {
                if (recordID == "" || recordID == "0")
                {
                    gridMajorPOView.OptionsBehavior.Editable = false;
                    gridMajorPOView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    Note.Enabled = false;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        gridMajorPOView.OptionsBehavior.Editable = false;
                        gridMajorPOView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        Note.Enabled = false;
                    }
                    else
                    {
                        gridMajorPOView.OptionsBehavior.Editable = true;
                        gridMajorPOView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        gridMajorPOView.Columns["RevisionNumber"].OptionsColumn.AllowEdit = false;
                        Note.Enabled = true;
                    }

                }
            }
            catch (Exception ex) { }
        }
        //
        private void SaveMajorPOItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                MajorPODetail majorPODetail;
                if (jobMajorPODetailDataTable != null && jobMajorPODetailDataTable.Rows.Count > 0)
                {
                    foreach (DataRow r in jobMajorPODetailDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                majorPODetail = new MajorPODetail(
                                                    r["JobMajorPODetailID"].ToString(),
                                                    recordID,
                                                    r["RevisionNumber"].ToString(),
                                                    r["WorkDescription"].ToString(),
                                                    r["Amount"].ToString(),
                                                    r["RevisionDate"].ToString());
                                majorPODetail.Save();
                                r["JobMajorPODetailID"] = majorPODetail.JobMajorPODetailID;
                                r["RevisionNumber"] = majorPODetail.RevisionNumber;
                                break;
                            case DataRowState.Deleted:
                                MajorPODetail.Delete(r["JobMajorPODetailID"].ToString());
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
        private void gridView1_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            CalculateValues();
        }

        private void cboCostCodes_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtPhase.Text = cboCostCodes.GetColumnValue("Phase").ToString();
                txtCostCode.Text = cboCostCodes.GetColumnValue("Code").ToString();
                type = cboCostCodes.GetColumnValue("Type").ToString();
            }
            catch { }
            switch (type)
            {
                case "M":
                    if (totalCost < 25000)
                        txtPOType.Text = "SPO";
                    else
                        txtPOType.Text = "MPO";
                    break;
                case "S":
                    txtPOType.Text = "SUB";
                    break;
                default:
                    txtPOType.Text = "";
                    break;
            }


            // CalculateValues();
        }

        private void txtPOType_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPOType.Text == "MPO")
            {
                btnAttachmentMPO.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnSubcontractAgreement.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                tabMajor.TabPages[1].PageVisible = false;
            }
            else if (txtPOType.Text == "SUB")
            {
                btnAttachmentMPO.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSubcontractAgreement.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                tabMajor.TabPages[1].PageVisible = true;
            }
            else
            {
                btnAttachmentMPO.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSubcontractAgreement.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                tabMajor.TabPages[1].PageVisible = false;
            }
        }

        private void txtNote_OnTextChanged(object source, EventArgs e)
        {
            AllControls_EditValue((Object)source, e);
        }

        private void gridMajorPOView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }

        private void cboPOAddress_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Job.GetJobOffice(jobID).Tables[0];
                if (cboPOAddress.EditValue != null && cboPOAddress.Text.Trim().Length > 0)
                {
                    DataTable t;
                    string type = cboPOAddress.EditValue.ToString().ToUpper();
                    switch (type)
                    {
                        case "OFFICE":
                            t = Job.GetJobOffice(jobID).Tables[0];
                            if (t.Rows.Count > 0)
                            {
                                txtShipToAddress.Text = t.Rows[0]["Address"].ToString();
                                txtShipToCity.Text = t.Rows[0]["City"].ToString();
                                txtShipToState.Text = t.Rows[0]["State"].ToString();
                                txtShipToZip.Text = t.Rows[0]["ZipCode"].ToString();
                            }
                            break;
                        case "JOB SITE":
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


        //
    }
}