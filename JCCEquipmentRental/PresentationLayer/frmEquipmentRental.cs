using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCEquipmentRental.BusinessLayer;
using JCCEquipmentRental.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
using JCCBusinessLayer;
namespace JCCEquipmentRental.PresentationLayer
{
    public partial class frmEquipmentRental : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     string jobNumber = "";
        private     bool isEquipmentList = false;
        private     string duration = "";
        private     string endDate;

        DataTable   contact;
        protected int defaultFromID;
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
        public frmEquipmentRental()
        {
            InitializeComponent();
        }
        //
        public frmEquipmentRental(string recordID, string jobID, BindingSource bindingSource, bool isEquipmentList)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.bindingSource      = bindingSource;
            this.isEquipmentList    = isEquipmentList;
            InitializeComponent();
        }
        //
        private void frmEquipmentRental_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                if (isEquipmentList)
                {
                    if (Security.Security.UserJCCEquipmentRentalAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                        mnuEquipmentRentalEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                }
                else
                {
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
                            btnSave.Enabled = false;
                            btnUndo.Enabled = false;
                        }
                    }


                }

                if (jobID != "0")
                {
                    lblJobNumber.Visible = false;
                    txtJobNumber.Visible = false;
                }
                else
                {
                    lblFrom.Visible = false;
                    cboFrom.Visible = false;
                    mnuEquipmentRentalEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                contact = Contact.GetJobContactForPullDown(jobID).Tables[0];
                txtRecordID.DataBindings.Add("text", bindingSource, "JobEquipmentRentalID");
                //
                cboVendor.Properties.DataSource = JCCEquipmentRental.BusinessLayer.StaticTables.Vendor;
                cboVendor.Properties.DisplayMember = "Name";
                cboVendor.Properties.ValueMember = "VendorID";
                cboVendor.Properties.PopulateColumns();
                cboVendor.Properties.ShowHeader = false;
                //

                cboFrom.Properties.DataSource = contact;
                cboFrom.Properties.PopulateColumns();
                cboFrom.Properties.DisplayMember = "Name";
                cboFrom.Properties.ValueMember = "ContactID";
                cboFrom.Properties.ShowHeader = false;
                cboFrom.Properties.Columns[0].Visible = false;
                //
                defaultFromID = JobDefaultValues.GetJobDefaultFrom(jobID);
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetEquipmentRental();
                }
                else
                {
                    GetEquipmentRental();
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
        private void GetEquipmentRentalDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateEquipmentRental(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtJobNumber.Text = "";
                txtRequestNumber.Text = "";
                txtCreationDate.Text = "";
                txtCreatedBy.Text = "";
                txtUpdatedDate.Text = "";
                txtUpdatedBy.Text = "";
                txtEquipmentNumber.Text = "";
                txtEquipmentDescription.Text = "";
                txtEquipmentAccessories.Text = "";
                txtDeliveryDate.Text = "";
                txtDuration.Text = "";
                txtStartRentalDate.Text = "";
                txtEndRentalDate.Text = "";
                txtOffRentalDate.Text = "";
                chkGoodCondition.CheckState = CheckState.Unchecked;
                chkReturnedAsReceived.CheckState = CheckState.Unchecked;
                txtPickedUpDate.Text = "";
                txtPONumber.Text = "";
                cboVendor.EditValue = null;
                cboFrom.EditValue = null;
                cboStatus.Text = "";
                txtTermNumber.Text = "";
                txtDTNumber.Text = "";
                txtComment.Text = "";
                cboStatus.Text = "Open";
                duration = "";
                endDate = "";
                if (defaultFromID > 0)
                    cboFrom.EditValue = defaultFromID;
                UnProtectForm();
            }
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
        }
        //
        private void ProtectForm()
        {
            txtJobNumber.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            txtJobNumber.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Equipment Rental":
                    if (CheckEquipmentRentalStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetEquipmentRental();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Equipment Rental":
                    if (CheckEquipmentRentalStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetEquipmentRental();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckEquipmentRentalStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetEquipmentRental();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckEquipmentRentalStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetEquipmentRental();
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
                case "Equipment Rental":
                    try
                    {
                        Reports.Reports.EquipmentRentalForm(jobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckEquipmentRentalStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveEquipmentRental();
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
        private void SaveEquipmentRental()
        {
           try
           {
               EquipmentRental equip = new EquipmentRental(recordID,
                                                            jobID,
                                                            txtEquipmentNumber.Text,
                                                            txtEquipmentDescription.Text,
                                                            txtEquipmentAccessories.Text,
                                                            txtDeliveryDate.Text,
                                                            txtDuration.Text,
                                                            txtStartRentalDate.Text,
                                                            txtEndRentalDate.Text,
                                                            txtOffRentalDate.Text,
                                                            txtPickedUpDate.Text,
                                                            chkGoodCondition.Checked.ToString(),
                                                            chkReturnedAsReceived.Checked.ToString(),
                                                            txtPONumber.Text,
                                                            cboVendor.EditValue == null ? "" : cboVendor.EditValue.ToString(),
                                                            cboStatus.Text,
                                                            txtTermNumber.Text,
                                                            txtDTNumber.Text,
                                                            txtComment.Text,
                                                            cboFrom.EditValue == null ? "" : cboFrom.EditValue.ToString(),
                                                            txtPhone.Text);
                                   
                equip.Save();
                if (txtRecordID.Text != recordID || duration != txtDuration.Text || endDate != txtEndRentalDate.Text)
                {
                    MessageBox.Show("An Email has been sent for the Eqipment Rental!", CCEApplication.ApplicationName);
                    duration = txtDuration.Text;
                    endDate = txtEndRentalDate.Text;
                }
                recordID = equip.JobEquipmentRentalID;
                txtRecordID.Text = recordID;
                DataRow r = EquipmentRental.GetCreatUpdate(recordID).Tables[0].Rows[0];
                txtCreationDate.EditValue = r["CreationDate"];
                txtCreatedBy.Text = r["CreatedByName"].ToString();
                txtUpdatedDate.EditValue = r["UpdatedDate"];
                txtUpdatedBy.Text = r["UpdatedByName"].ToString();
                txtRequestNumber.Text = r["RequestNumber"].ToString();
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
        private void GetEquipmentRental()
        {
            GetEquipmentRentalDetail(recordID);
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
                if (isEquipmentList)
                {
                    if (Security.Security.UserJCCEquipmentRentalAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                    }
                    else
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
                        //btnCopy.Enabled = false;

                    }
                }
                else
                {
                    if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                    {
                        dataChanged = true;
                        btnUndo.Enabled = true;
                        btnSave.Enabled = true;
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

                        }
                    }
                }
            }
        }
        //
        private void frmEquipmentRental_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckEquipmentRentalStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateEquipmentRental(string recordID)
        {
            try
            {
                DataRow r;
                r = EquipmentRental.GetEquipmentRental(recordID).Tables[0].Rows[0];
                txtJobNumber.Text               = r["JobNumber"].ToString();
                txtRequestNumber.Text = r["RequestNumber"].ToString();
                txtCreationDate.EditValue       = r["CreationDate"];
                txtCreatedBy.Text               = r["CreatedByName"].ToString();
                txtUpdatedDate.EditValue        = r["UpdatedDate"];
                txtUpdatedBy.Text               = r["UpdatedByName"].ToString();
                txtEquipmentNumber.Text         = r["EquipmentNumber"].ToString();
                txtEquipmentDescription.Text    = r["EquipmentDescription"].ToString();
                txtEquipmentAccessories.Text    = r["EquipmentAccessories"].ToString();
                txtDeliveryDate.EditValue       = r["DeliveryDate"];
                txtDuration.Text                = r["Duration"].ToString();
                txtStartRentalDate.EditValue    = r["StartRentalDate"];
                txtEndRentalDate.EditValue      = r["EndRentalDate"];
                txtOffRentalDate.EditValue      = r["OffRentalDate"].ToString();
                txtPickedUpDate.EditValue       = r["PickedUpdDate"];
                chkGoodCondition.EditValue      = r["GoodCondition"];
                chkReturnedAsReceived.EditValue = r["ReturnedAsReceived"];
                txtPONumber.Text                = r["PONumber"].ToString();
                cboVendor.EditValue             = r["Vendor"];
                cboFrom.EditValue               = r["FromID"];
                cboStatus.Text                  = r["Status"].ToString();
                txtTermNumber.Text              = r["TermNumber"].ToString();
                txtDTNumber.Text                = r["DTNumber"].ToString();
                txtComment.Text                 = r["Comment"].ToString();
                txtPhone.Text                   = r["Phone"].ToString();
                duration =   r["Duration"].ToString();
                endDate = r["EndRentalDate"].ToString();
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
            txtDeliveryDate.ErrorText = "";
            txtEquipmentDescription.ErrorText = "";
            txtDuration.ErrorText = "";
            cboStatus.ErrorText = "";
            
            
            
            errorMessages = false;
            //
            if (txtJobNumber.Visible)
            {
                if (recordID == "" || recordID == "0")
                {
                    if (txtJobNumber.Text.Trim().Length == 0)
                    {
                        txtJobNumber.ErrorText = "Job Number is Required";
                        errorMessages = true;
                    }
                    else
                    {

                        jobID = EquipmentRental.GetJobID(txtJobNumber.Text.Trim());
                        if (jobID == "0" || jobID == "")
                        {
                            txtJobNumber.ErrorText = "Job does not exist or your access is denied!";
                            errorMessages = true;
                        }
                    }
                }
            }
            //
            if (txtDeliveryDate.Text.Trim() == "")
            {
                txtDeliveryDate.ErrorText = "Delivery Date is Requried";
                errorMessages = true;
            }
            //
            if (txtEquipmentDescription.Text.Trim() == "")
            {
                txtEquipmentDescription.ErrorText = "Eqipment Description is Required";
                errorMessages = true;
            }
            //
            if (txtDuration.Text.Trim() == "")
            {
                txtDuration.ErrorText = "Duration is Required";
                errorMessages = true;
            }
            //
            if (cboStatus.Text == "")
            {
                cboStatus.ErrorText = "Status is Required";
                errorMessages = true;
            }
        }
       
        //
        private void SetControlAccess()
        {

        }

        private void mnuEquipmentRentalEmail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("You are about to Email the Rental Equipment. Contine?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Reports.Reports.JobEquipmentRentalEmail(jobID, recordID);
                    MessageBox.Show("The Email has been sent!", CCEApplication.ApplicationName);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

        }
   
    }
}