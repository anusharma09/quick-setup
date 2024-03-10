using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCLightFixture.BusinessLayer;
//using JCCReports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
namespace JCCLightFixture.PresentationLayer
{
    public partial class frmLightFixture : DevExpress.XtraBars.Ribbon.RibbonForm
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
        private     DataTable lightFixtureReleaseDataTable;
        private     DataTable lightFixtureReceiveDataTable;
        private     DataTable lightFixtureRevisionDataTable;
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
        public frmLightFixture()
        {
            InitializeComponent();
        }
        //
        public frmLightFixture(string recordID, string jobID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmLightFixture_Load(object sender, EventArgs e)
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
                txtRecordID.DataBindings.Add("text", bindingSource, "JobLightFixtureID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetLightFixture();
                }
                else
                {
                    GetLightFixture();
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
        private void GetLightFixtureDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateLightFixture(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtType.Text = "";
                txtCode.Text = "";
                txtQtyRunRev00.EditValue = null;
                txtLengthRev00.EditValue = null;
                txtQtyRun.EditValue = null;
                txtLength.EditValue = null;
                txtMFGR.Text = "";
                txtDescription.Text = "";
                txtLeadTime.Text = "";
                txtQtyBalance.EditValue = null;
                txtLengthBalance.EditValue = null;
                txtUnitPrice.EditValue = null;
                txtExtension.EditValue = null;
                txtBalance.EditValue = null;

                UnProtectForm();
            }
            GetLightFixtureReleasedItems(recordID);
            GetLightFixtureRevisionItems(recordID);
            GetLightFixtureReceivedItems(recordID);
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
            txtQtyRunRev00.Properties.ReadOnly = true;
            txtLengthRev00.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            txtQtyRunRev00.Properties.ReadOnly = false;
            txtLengthRev00.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bColumnWidthChangedRelease)
            {
                bColumnWidthChangedRelease = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridLightFixtureReleaseView, "frmLightFixture");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            if (bColumnWidthChangedReceive)
            {
                bColumnWidthChangedReceive = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureReceiveView, "frmLightFixtureA");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            if (bColumnWidthChangedRevision)
            {
                bColumnWidthChangedRevision = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightRevisionFixtureView, "frmLightFixtureB");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Light Fixture":
                    if (CheckLightFixtureStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = false;
                        GetLightFixture();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "Previous Light Fixture":
                    if (CheckLightFixtureStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = false;
                        GetLightFixture();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckLightFixtureStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetLightFixture();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Delete":
                    if (MessageBox.Show("You are about to delete Light Fixture and related Releases, Revisions, and Receives. Continue?",CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("Are you sure?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                JobLightFixture.Remove(txtRecordID.Text);
                                recordID = "0";
                                txtRecordID.Text = "0";
                                ribbonReport.Visible = false;
                                GetLightFixture();
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
                    if (CheckLightFixtureStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = false;
                    }
                    break;
                case "&Undo":
                    GetLightFixture();
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
                case "Light Fixture":
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
        private bool CheckLightFixtureStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveLightFixture();
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
        private void SaveLightFixture()
        {
           try
           {
               JobLightFixture light = new JobLightFixture(recordID,
                                   jobID,
                                   txtType.Text,
                                   txtCode.Text,
                                   txtQtyRun.EditValue == null ? "" : txtQtyRun.EditValue.ToString(),
                                   txtQtyBalance.EditValue == null ? "" : txtQtyBalance.EditValue.ToString(),
                                   txtLength.EditValue == null ? "" : txtLength.EditValue.ToString(),
                                   txtLengthBalance.EditValue == null ? "" : txtLengthBalance.EditValue.ToString(),
                                   txtMFGR.Text,
                                   txtDescription.Text,
                                   txtLeadTime.Text,
                                   txtUnitPrice.EditValue == null ? "" : txtUnitPrice.EditValue.ToString(),
                                   txtExtension.EditValue == null ? "" : txtExtension.EditValue.ToString(),
                                   txtBalance.EditValue == null ? "" : txtBalance.EditValue.ToString(),
                                   txtQtyRunRev00.EditValue == null ? "" : txtQtyRunRev00.EditValue.ToString(),
                                   txtLengthRev00.EditValue == null ? "" : txtLengthRev00.EditValue.ToString());

                light.Save();

                recordID = light.JobLightFixtureID;
                txtRecordID.Text = recordID;
                SaveLightFixtureReceiveItems();
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
        private void GetLightFixture()
        {
            GetLightFixtureDetail(recordID);
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
        //
        private void frmLightFixture_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChangedRelease)
            {
                bColumnWidthChangedRelease = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(gridLightFixtureReleaseView, "frmLightFixture");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            if (bColumnWidthChangedReceive)
            {
                bColumnWidthChangedReceive = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightFixtureReceiveView, "frmLightFixtureA");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            if (bColumnWidthChangedRevision)
            {
                bColumnWidthChangedRevision = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdLightRevisionFixtureView, "frmLightFixtureB");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }

            CheckLightFixtureStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateLightFixture(string recordID)
        {
            try
            {
                DataRow r;
                r = JobLightFixture.GetLightFixtureDetail(recordID).Tables[0].Rows[0];

                txtType.Text              = r["Type"].ToString();
                txtCode.Text              = r["Code"].ToString();
                txtQtyRun.EditValue       = r["QtyRun"];
                txtQtyBalance.EditValue   = r["QtyBalance"];
                txtUnitPrice.EditValue    = r["UnitPrice"];
                txtExtension.EditValue    = r["Extension"];
                txtBalance.EditValue        = r["Balance"];
                txtLength.EditValue       = r["Length"];
                txtLengthBalance.EditValue = r["LengthBalance"];
                txtMFGR.Text               = r["MFGR"].ToString();
                txtDescription.Text         = r["Description"].ToString();
                txtLeadTime.Text            = r["LeadTime"].ToString();
                txtQtyRunRev00.EditValue    = r["QtyRunRev00"];
                txtLengthRev00.EditValue    = r["LengthRev00"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {
            txtType.ErrorText = "";
            txtCode.ErrorText = "";
            txtMFGR.ErrorText = "";
            txtDescription.ErrorText = "";

            errorMessages = false;
            //
            if (txtType.Text.Trim() == "")
            {
                txtType.ErrorText = "Type is Requried";
                errorMessages = true;
            }          
            //
            if (txtDescription.Text.Trim() == "")
            {
                txtDescription.ErrorText = "Description is Requried";
                errorMessages = true;
            }            
        }
        //
        private void GetLightFixtureReleasedItems(string jobLightFixtureID)
        {
            try
            {
                lightFixtureReleaseDataTable = JobLightFixture.GetLightFixtureItems(jobLightFixtureID).Tables[0];

                this.grdLightReleaseFixture.DataSource = lightFixtureReleaseDataTable.DefaultView;
                gridLightFixtureReleaseView.Columns["JobLightFixtureID"].Visible = false;
                gridLightFixtureReleaseView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(gridLightFixtureReleaseView, "frmLightFixture");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        //
        private void GetLightFixtureRevisionItems(string jobLightFixtureID)
        {
            try
            {
                lightFixtureRevisionDataTable = JobLightFixture.GetLightFixtureRevisionItems(jobLightFixtureID).Tables[0];

                this.grdLightRevisionFixture.DataSource = lightFixtureRevisionDataTable.DefaultView;
                grdLightRevisionFixtureView.Columns["JobLightFixtureID"].Visible = false;
                grdLightRevisionFixtureView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdLightRevisionFixtureView, "frmLightFixtureB");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void GetLightFixtureReceivedItems(string jobLightFixtureID)
        {
            try
            {
                lightFixtureReceiveDataTable = JobLightFixtureDetail.GetLightFixtureDetail(jobLightFixtureID).Tables[0];

                this.grdLightFixtureReceive.DataSource = lightFixtureReceiveDataTable.DefaultView;

                grdLightFixtureReceiveView.Columns["JobLightFixtureDetailID"].Visible = false;
                grdLightFixtureReceiveView.Columns["JobLightFixtureID"].Visible = false;
                grdLightFixtureReceiveView.Columns["Quantity"].ColumnEdit = repQuantity;
                grdLightFixtureReceiveView.Columns["PaidAmount"].ColumnEdit = repAmount;
                grdLightFixtureReceiveView.Columns["PaidAmount"].Caption = "Paid Amount";
                grdLightFixtureReceiveView.Columns["Length"].ColumnEdit = repQuantity; 
                grdLightFixtureReceiveView.Columns["InvoiceNumber"].Caption = "Invoice Number";
                grdLightFixtureReceiveView.Columns["ReceivedDate"].Caption = "Received Date";
                grdLightFixtureReceiveView.Columns["ReceivedBy"].Caption = "Received By";
                grdLightFixtureReceiveView.Columns["ReceivedBy"].ColumnEdit = repName;
                grdLightFixtureReceiveView.Columns["Notes"].ColumnEdit = repNote;
                grdLightFixtureReceiveView.Columns["InvoiceNumber"].ColumnEdit = repInvoiceNumber;

                grdLightFixtureReceiveView.Columns["PaidAmount"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLightFixtureReceiveView.Columns["PaidAmount"].SummaryItem.DisplayFormat = "{0:c2}";
                grdLightFixtureReceiveView.Columns["Quantity"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLightFixtureReceiveView.Columns["Quantity"].SummaryItem.DisplayFormat = "{0:n0}";
                grdLightFixtureReceiveView.Columns["Length"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                grdLightFixtureReceiveView.Columns["Length"].SummaryItem.DisplayFormat = "{0:n0}";

                grdLightFixtureReceiveView.BestFitColumns();
                grdLightFixtureReceiveView.Columns["Notes"].Width = 200;
                grdLightFixtureReceiveView.Columns["InvoiceNumber"].Width = 100;
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdLightFixtureReceiveView, "frmLightFixtureA");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            gridLightFixtureReleaseView.OptionsBehavior.Editable = false;
            if (recordID == "" || recordID == "0" || Security.Security.currentJobReadOnly)
            {
                grdLightFixtureReceiveView.OptionsBehavior.Editable = false;
                grdLightFixtureReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
                if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                {
                    grdLightFixtureReceiveView.OptionsBehavior.Editable = true;
                    grdLightFixtureReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
                else
                {
                    if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
                    {
                        grdLightFixtureReceiveView.OptionsBehavior.Editable = false;
                        grdLightFixtureReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    }
                    else
                    {
                        grdLightFixtureReceiveView.OptionsBehavior.Editable = true;
                        grdLightFixtureReceiveView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                    }

                }

            }
        }
        //
        private void SaveLightFixtureReceiveItems()
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                JobLightFixtureDetail detail;
                if (lightFixtureReceiveDataTable != null)
                {
                    foreach (DataRow r in lightFixtureReceiveDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                detail = new JobLightFixtureDetail(
                                                    r["JobLightFixtureDetailID"].ToString(),
                                                    recordID,
                                                    r["Quantity"].ToString(),
                                                    r["Length"].ToString(),
                                                    r["PaidAmount"].ToString(),
                                                    r["ReceivedDate"].ToString(),
                                                    r["ReceivedBy"].ToString(),
                                                    r["Notes"].ToString(),
                                                    r["InvoiceNumber"].ToString());
                                detail.Save();
                                r["JobLightFixtureDetailID"] = detail.JobLightFixtureDetailID;

                                break;
                            case DataRowState.Deleted:
                                JobLightFixtureDetail.Remove(r["JobLightFixtureDetailID"].ToString());
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
        private void txtUnitPrice_EditValueChanged(object sender, EventArgs e)
        {
            Calculdate();
            AllControls_EditValue(sender, e);
        }

        private void txtQtyRun_EditValueChanged(object sender, EventArgs e)
        {
            Calculdate();
            AllControls_EditValue(sender, e);
        }
        //
        private void Calculdate()
        {
            decimal quantity = 0;
            decimal unitPrice = 0;
            decimal length = 0;
            decimal extension = 0;
            decimal paidAmount = 0;
            decimal balance = 0;
            decimal quantityReceived = 0;
            decimal quantityBalance = 0;
            decimal lengthReceived = 0;
            decimal lengthBalance = 0;

            try
            {
                if (txtQtyRun.EditValue != null)
                    decimal.TryParse(txtQtyRun.EditValue.ToString(), out quantity);
                if (txtUnitPrice.EditValue != null)
                    decimal.TryParse(txtUnitPrice.EditValue.ToString(), out unitPrice);
                if (txtLength.EditValue != null)
                    decimal.TryParse(txtLength.EditValue.ToString(), out length);
                extension = quantity * unitPrice;
                txtExtension.EditValue = extension;


                if (lightFixtureReceiveDataTable != null && lightFixtureReceiveDataTable.Rows.Count > 0)
                {
                    if (grdLightFixtureReceiveView.Columns["PaidAmount"].SummaryItem.SummaryValue != null)
                        decimal.TryParse(lightFixtureReceiveDataTable.Compute("SUM(PaidAmount)", "").ToString(), out paidAmount);
                    if (grdLightFixtureReceiveView.Columns["Quantity"].SummaryItem.SummaryValue != null)
                        decimal.TryParse(lightFixtureReceiveDataTable.Compute("SUM(Quantity)", "").ToString(), out quantityReceived);
                    if (grdLightFixtureReceiveView.Columns["Length"].SummaryItem.SummaryValue != null)
                        decimal.TryParse(lightFixtureReceiveDataTable.Compute("SUM(Length)", "").ToString(), out lengthReceived);

                    balance = extension - paidAmount;
                    quantityBalance = quantity - quantityReceived;
                    lengthBalance = length - lengthReceived;
                    txtQtyBalance.EditValue = quantityBalance;
                    txtLengthBalance.EditValue = lengthReceived;
                    txtBalance.EditValue = balance;


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }



           
        }
      
       //
        private void grdLightFixtureReceiveView_RowUpdated(object sender, RowObjectEventArgs e)
        {
            isUpdated = true;
            Calculdate();
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

        private void txtLength_EditValueChanged(object sender, EventArgs e)
        {
            Calculdate();
            AllControls_EditValue(sender, e);
        }

        private void txtQtyRunRev00_EditValueChanged(object sender, EventArgs e)
        {
            if (recordID == "0")
                txtQtyRun.EditValue = txtQtyRunRev00.EditValue;
            AllControls_EditValue(sender, e);
        }

        private void txtLengthRev00_EditValueChanged(object sender, EventArgs e)
        {
            if (recordID == "0")
                txtLength.EditValue = txtLengthRev00.EditValue;
            AllControls_EditValue(sender, e);
        }

        private void grdLightFixtureReceiveView_KeyDown(object sender, KeyEventArgs e)
        {
           /* if ((Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly && !Security.Security.currentJobReadOnly) ||
                (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly))
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DataRow r = grdLightFixtureReceiveView.GetDataRow(grdLightFixtureReceiveView.GetSelectedRows()[0]);
                    if (r != null && !String.IsNullOrEmpty(r[0].ToString()))
                    {

                        if (MessageBox.Show("Delete Selected Item?", JCCLightFixture.CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            try
                            {
                                JobLightFixtureDetail.Remove(r[0].ToString());
                                grdLightFixtureReceiveView.DeleteRow(grdLightFixtureReceiveView.GetSelectedRows()[0]);
                                Calculdate();
                                isUpdated = true;
                                if (!dataChanged)
                                {
                                    dataChanged = true;
                                    btnUndo.Enabled = true;
                                    btnSave.Enabled = true;
                                    btnDelete.Enabled = false;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, JCCLightFixture.CCEApplication.ApplicationName);
                            }
                        }
                    }
                }
            } */
        }

        private void gridLightFixtureReleaseView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRelease = true;
        }

        private void grdLightRevisionFixtureView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedRevision = true;
        }

        private void grdLightFixtureReceiveView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChangedReceive = true;
        }
    }
}