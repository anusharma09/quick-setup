using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCSwitchgear.BusinessLayer;
//using JCCReports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace JCCSwitchgear.PresentationLayer
{
    public partial class frmSwitchgear : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChangedRelease = false;
        protected bool bColumnWidthChangedRevision = false;
        protected bool bColumnWidthChangedReceive = false;
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     DataTable switchgearReleaseDataTable;
        private     DataTable switchgearRevisionDataTable;
        private     DataTable switchgearReceiveDataTable;
        private     bool isUpdated = false;
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
        public frmSwitchgear()
        {
            InitializeComponent();
        }
        //
        public frmSwitchgear(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmSwitchgear_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman &&
                                    !Security.Security.currentJobReadOnly)
                {
                    // btnSave.Enabled = false;
                    // btnUndo.Enabled = false;
                }
                else
                {

                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly
                        || Security.Security.currentJobReadOnly)
                    {
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }


                txtRecordID.DataBindings.Add("text", bindingSource, "JobSwitchgearID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetSwitchgear();
                }
                else
                {
                    GetSwitchgear();
                    ribbonReport.Visible = false;
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
        private void GetSwitchgearDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateSwitchgear(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtPageNo.Text = "";
                txtItemNo.Text = "";
                txtDesignation.Text = "";
                txtDescription.Text = "";
                txtQuantityRev00.EditValue = null;
                txtQuantity.EditValue = null;
                txtUnitPrice.EditValue = null;
                txtExtension.EditValue = null;
                txtBalance.EditValue = null;
                txtQuantityReceived.EditValue = null;
                txtQuantityBalance.EditValue = null;
                UnProtectForm();
            }
            GetSwitchgearReleasedItems(recordID);
            GetSwitchgearRevisionItems(recordID);
            GetSwitchgearReceivedItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnDelete.Enabled = true;
            dataChanged = false;

            if (recordID != "0")
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }
        //
        private void ProtectForm()
        {
            txtQuantityRev00.Properties.ReadOnly = true;
            txtQuantityRev00.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            txtQuantityRev00.Properties.ReadOnly = false;
            txtQuantityRev00.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (bColumnWidthChangedRelease)
            {
                bColumnWidthChangedRelease = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSwitchgearReleaseView, "frmSwitchgear");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            if (bColumnWidthChangedReceive)
            {
                bColumnWidthChangedReceive = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearReceiveView, "frmSwitchgearA");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            if (bColumnWidthChangedRevision)
            {
                bColumnWidthChangedRevision = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearRevisionView, "frmSwitchgearB");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Switchgear":
                    if (CheckSwitchgearStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = false;
                        GetSwitchgear();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Switchgear":
                    if (CheckSwitchgearStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = false;
                        GetSwitchgear();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckSwitchgearStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetSwitchgear();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Delete":
                    if (MessageBox.Show("You are about to delete Switchgear and related Releases, Revisions, and Receives. Continue?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                Switchgear.Remove(txtRecordID.Text);
                                recordID = "0";
                                txtRecordID.Text = "0";
                                ribbonReport.Visible = false;
                                GetSwitchgear();
                                dataChanged = false;
                                btnUndo.Enabled = false;
                                //btnCopy.Enabled = false;
                                btnSave.Enabled = false;
                                btnDelete.Enabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                            }
                        }
                    }
                    break;
 
                case "&Save":
                    if (CheckSwitchgearStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = false;
                    }
                    break;
                case "&Undo":
                    GetSwitchgear();
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
                case "Switchgear":
                    try
                    {
                        //Reports.SubmittalForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckSwitchgearStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveSwitchgear();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
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
                        btnDelete.Enabled = true;
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
                btnDelete.Enabled = true;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveSwitchgear()
        {
           try
           {
               Switchgear switchgear = new Switchgear(recordID,
                                   jobID,
                                   txtPageNo.Text,
                                   txtItemNo.Text,
                                   txtDesignation.Text,
                                   txtDescription.Text,
                                   txtQuantity.EditValue == null ? "" : txtQuantity.EditValue.ToString(),
                                   txtUnitPrice.EditValue == null ? "" : txtUnitPrice.EditValue.ToString(),
                                   txtExtension.EditValue == null ? "" : txtExtension.EditValue.ToString(),
                                   txtBalance.EditValue == null ? "" : txtBalance.EditValue.ToString(),
                                   txtQuantityReceived.EditValue == null ? "" : txtQuantityReceived.EditValue.ToString(),
                                   txtQuantityBalance.EditValue == null ? "" : txtQuantityBalance.EditValue.ToString(),
                                   txtQuantityRev00.EditValue == null ? "" : txtQuantityRev00.EditValue.ToString());

                switchgear.Save();

                recordID = switchgear.JobSwitchgearID;
                txtRecordID.Text = recordID;
                SaveSwitchgearReceiveItems();
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
            btnDelete.Enabled = true;
        }
        //
        private void GetSwitchgear()
        {
            GetSwitchgearDetail(recordID);
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
            DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
            if (myControl.GetType().ToString() == "DevExpress.XtraEditors.TextEdit")
            {
              //  string myString = myControl.Text.Trim().ToUpper();

               // if (myString != myControl.Text.Trim())
               //     myControl.Text = myControl.Text.ToString().ToUpper();
            }
            if (!dataChanged)
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly )
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                        //btnCopy.Enabled = false;
                        btnDelete.Enabled = false;

                    }
                }

            }
        }
        //
        private void frmSwitchgear_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChangedRelease)
            {
                bColumnWidthChangedRelease = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridSwitchgearReleaseView, "frmSwitchgear");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            if (bColumnWidthChangedReceive)
            {
                bColumnWidthChangedReceive = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearReceiveView, "frmSwitchgearA");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            if (bColumnWidthChangedRevision)
            {
                bColumnWidthChangedReceive = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdSwitchgearRevisionView, "frmSwitchgearB");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            CheckSwitchgearStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateSwitchgear(string recordID)
        {
            try
            {
                DataRow r;
                r = Switchgear.GetSwitchgear(recordID).Tables[0].Rows[0];
                
                txtPageNo.Text              = r["PageNo"].ToString();
                txtItemNo.Text              = r["ItemNo"].ToString();
                txtDesignation.Text         = r["Designation"].ToString();
                txtDescription.Text         = r["Description"].ToString();
                txtQuantityRev00.EditValue  = r["QuantityRev00"];
                txtQuantity.EditValue       = r["Quantity"];
                txtUnitPrice.EditValue      = r["UnitPrice"];
                txtExtension.EditValue      = r["Extension"];
                txtBalance.EditValue        = r["Balance"];
                txtQuantityReceived.EditValue = r["QuantityReceived"];
                txtQuantityBalance.EditValue = r["QuantityBalance"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtPageNo.ErrorText = "";
            txtItemNo.ErrorText = "";
            txtDescription.ErrorText = "";
            txtQuantityRev00.ErrorText = "";
            txtUnitPrice.ErrorText = "";

            errorMessages = false;
            //
            if (txtPageNo.Text.Trim() == "")
            {
                txtPageNo.ErrorText = "Page No is Requried";
                errorMessages = true;
            }
            //
            if (txtItemNo.Text.Trim() == "")
            {
                txtItemNo.ErrorText = "Item No is Requried";
                errorMessages = true;
            }            
            //
            if (txtDescription.Text.Trim() == "")
            {
                txtDescription.ErrorText = "Description is Requried";
                errorMessages = true;
            }            
            //
            if (txtQuantityRev00.EditValue == null)
            {
                txtQuantityRev00.ErrorText = "Quantity Rev 00 is Requried";
                errorMessages = true;
            }            
            //
            if (txtUnitPrice.EditValue == null)
            {
                txtUnitPrice.ErrorText = "Unit Price is Requried";
                errorMessages = true;
            }
        }
        //
        private void GetSwitchgearReleasedItems(string jobSwitchgearID)
        {
            try
            {
                switchgearReleaseDataTable = Switchgear.GetSwitchgearItems(jobSwitchgearID).Tables[0];

                this.grdSwitchgearRelease.DataSource = switchgearReleaseDataTable.DefaultView;

                gridSwitchgearReleaseView.Columns["JobSwitchgearID"].Visible = false;
                gridSwitchgearReleaseView.Columns["Quantity"].ColumnEdit = repQuantity;
                gridSwitchgearReleaseView.Columns["Quantity"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridSwitchgearReleaseView.Columns["Quantity"].SummaryItem.DisplayFormat = "{0:n0}";


                gridSwitchgearReleaseView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridSwitchgearReleaseView, "frmSwitchgear");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetSwitchgearReceivedItems(string jobSwitchgearID)
        {
            try
            {
                switchgearReceiveDataTable = SwitchgearDetail.GetSwitchgearDetail(jobSwitchgearID).Tables[0];

                this.grdSwitchgearReceive.DataSource = switchgearReceiveDataTable.DefaultView;

                grdSwitchgearReceiveView.Columns["JobSwitchgearDetailID"].Visible = false;
                grdSwitchgearReceiveView.Columns["JobSwitchgearID"].Visible = false;
                grdSwitchgearReceiveView.Columns["Quantity"].ColumnEdit = repQuantity;
                grdSwitchgearReceiveView.Columns["PaidAmount"].ColumnEdit = repAmount;
                grdSwitchgearReceiveView.Columns["PaidAmount"].Caption = "Paid Amount";
                grdSwitchgearReceiveView.Columns["InvoiceNumber"].Caption = "Invoice Number";
                grdSwitchgearReceiveView.Columns["ReceivedDate"].Caption = "Received Date";
                grdSwitchgearReceiveView.Columns["ReceivedBy"].Caption = "Received By";
                grdSwitchgearReceiveView.Columns["ReceivedBy"].ColumnEdit = repName;
                grdSwitchgearReceiveView.Columns["Notes"].ColumnEdit = repNote;
                grdSwitchgearReceiveView.Columns["InvoiceNumber"].ColumnEdit = repInvoiceNumber;

                grdSwitchgearReceiveView.Columns["PaidAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSwitchgearReceiveView.Columns["PaidAmount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdSwitchgearReceiveView.Columns["Quantity"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdSwitchgearReceiveView.Columns["Quantity"].SummaryItem.DisplayFormat = "{0:n0}";

                gridSwitchgearReleaseView.BestFitColumns();
                grdSwitchgearReceiveView.Columns["Notes"].Width = 200;
                grdSwitchgearReceiveView.Columns["InvoiceNumber"].Width = 100;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSwitchgearReceiveView, "frmSwitchgearA");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetSwitchgearRevisionItems(string jobSwitchgearID)
        {
            try
            {
                switchgearRevisionDataTable = Switchgear.GetSwitchgearRevisionItems(jobSwitchgearID).Tables[0];

                this.grdSwitchgearRevision.DataSource = switchgearRevisionDataTable.DefaultView;

                grdSwitchgearRevisionView.Columns["JobSwitchgearID"].Visible = false;
                grdSwitchgearRevisionView.Columns["Quantity"].ColumnEdit = repQuantity;


                grdSwitchgearRevisionView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdSwitchgearRevisionView, "frmSwitchgearB");
                grdSwitchgearRevisionView.OptionsBehavior.Editable = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            gridSwitchgearReleaseView.OptionsBehavior.Editable = false;
            if (recordID == "" || recordID == "0" || Security.Security.currentJobReadOnly)
            {
                grdSwitchgearReceiveView.OptionsBehavior.Editable = false;
                grdSwitchgearReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    grdSwitchgearReceiveView.OptionsBehavior.Editable = true;
                    grdSwitchgearReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        grdSwitchgearReceiveView.OptionsBehavior.Editable = false;
                        grdSwitchgearReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                    else
                    {
                        grdSwitchgearReceiveView.OptionsBehavior.Editable = true;
                        grdSwitchgearReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    }

                }

            }

        }
        //
        private void SaveSwitchgearReceiveItems()
        {

            try
            {
                this.Cursor = Cursors.AppStarting;
                SwitchgearDetail switchgearDetail;
                if (switchgearReceiveDataTable != null)
                {
                    foreach (DataRow r in switchgearReceiveDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                switchgearDetail = new SwitchgearDetail(
                                                    r["JobSwitchgearDetailID"].ToString(),
                                                    recordID,
                                                    r["Quantity"].ToString(),
                                                    r["PaidAmount"].ToString(),
                                                    r["ReceivedDate"].ToString(),
                                                    r["ReceivedBy"].ToString(),
                                                    r["Notes"].ToString(),
                                                    r["InvoiceNumber"].ToString());
                                switchgearDetail.Save();
                                r["JobSwitchgearDetailID"] = switchgearDetail.JobSwitchgearDetailID;
                                
                                break;
                            case DataRowState.Deleted:
                                SwitchgearDetail.Remove(r["JobSwitchgearDetailID"].ToString());
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
        private void gridSwitchgearView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            //Extension();
            if (!dataChanged)
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                        //btnCopy.Enabled = false;
                        btnDelete.Enabled = false;

                    }
                }

            }
        }

        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {
            Extension();
            AllControls_EditValue(sender, e);
        }

        private void txtUnitPrice_EditValueChanged(object sender, EventArgs e)
        {
            Extension();
            AllControls_EditValue(sender, e);
        }
        //
        private void Extension()
        {
            decimal quantity = 0;
            decimal unitPrice = 0;
            decimal extension = 0;
            decimal paidAmount = 0;
            decimal balance = 0;
            decimal quantityReceived = 0;
            decimal quantityBalance = 0;

            if (txtQuantity.EditValue != null)
            {
                decimal.TryParse(txtQuantity.EditValue.ToString(), out quantity);
            }
            if(txtUnitPrice.EditValue != null)
                decimal.TryParse(txtUnitPrice.EditValue.ToString(), out unitPrice);
            extension = quantity * unitPrice;
            txtExtension.EditValue = extension;

            //DevExpress.XtraGrid.GridSummaryItem totalPaidAmount = new DevExpress.XtraGrid.GridSummaryItem(DevExpress.Data.SummaryItemType.Sum,"PaidAmount", "");
            //if (totalPaidAmount.SummaryValue != null)
            if (switchgearReceiveDataTable != null && switchgearReceiveDataTable.Rows.Count > 0)
            {
                if (grdSwitchgearReceiveView.Columns["PaidAmount"].SummaryItem != null)
                    decimal.TryParse(switchgearReceiveDataTable.Compute("SUM(PaidAmount)","").ToString(), out paidAmount);
                if (grdSwitchgearReceiveView.Columns["Quantity"].SummaryItem != null)
                    decimal.TryParse(switchgearReceiveDataTable.Compute("SUM(Quantity)", "").ToString(), out quantityReceived);
            }
            balance = extension - paidAmount;
            quantityBalance = quantity - quantityReceived;
            txtQuantityReceived.EditValue = quantityReceived;
            txtQuantityBalance.EditValue = quantityBalance;
            txtBalance.EditValue = balance;

        }

        private void gridSwitchgearView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            /*if (e.Column.FieldName == "PaidAmount")
                Extension();*/
        }

        private void grdSwitchgearReceiveView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            Extension();
            isUpdated = true;
                Extension();
            if (!dataChanged)
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                        //btnCopy.Enabled = false;
                        btnDelete.Enabled = false;

                    }
                }

            }
        }

        private void txtQuantityRev00_EditValueChanged(object sender, EventArgs e)
        {
            if (recordID == "0")
                txtQuantity.EditValue = txtQuantityRev00.EditValue;
            AllControls_EditValue(sender, e);

        }

        private void gridSwitchgearReleaseView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRelease = true;
        }

        private void grdSwitchgearRevisionView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRevision = true;
        }

        private void grdSwitchgearReceiveView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedReceive = true;
        }
    }
}