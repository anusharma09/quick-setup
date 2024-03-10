using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCMaterialOrder.BusinessLayer;
using JCCMaterialOrder.Reports;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;
using JCCBusinessLayer;
namespace JCCMaterialOrder.PresentationLayer
{
    public partial class frmMaterialOrder : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected bool bColumnWidthChanged = false;
        protected   string recordID;
        protected   string jobID;
        protected   BindingSource bindingSource;
        protected   bool dataChanged;
        private     bool errorMessages = false;
        protected   DevExpress.XtraBars.ItemClickEventArgs currentButtonArg;
        protected   string currentButtonName = "";
        private     bool changesStatus = false;
        private     string jobNumber = "";
        DataTable   materialOrderDataTable;
        private     bool isUpdated = false;
        private bool isMaterialList = false;
        private string reportJobID;
        DataTable contact;
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
        public frmMaterialOrder()
        {
            InitializeComponent();
        }
        //
        public frmMaterialOrder(string recordID, string jobID, BindingSource bindingSource, bool isMaterialList)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            this.reportJobID        = jobID;
            this.bindingSource      = bindingSource;
            this.isMaterialList     = isMaterialList;
            InitializeComponent();
        }
        //
        private void frmMaterialOrder_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                if (isMaterialList)
                {
                    if (Security.Security.UserJCCEquipmentRentalAccessLevel == Security.Security.AccessLevel.ReadOnly)
                    {
                        btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        btnSave.Enabled = false;
                        btnUndo.Enabled = false;
                        mnuMaterialOrderEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                    mnuMaterialOrderEmail.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
                txtRecordID.DataBindings.Add("text", bindingSource, "JobMaterialOrderID");
                //
                if (!JCCMaterialOrder.BusinessLayer.StaticTables.IsLoaded)
                    JCCMaterialOrder.BusinessLayer.StaticTables.PopulateStaticTables();
                contact = Contact.GetJobContactForPullDown(jobID).Tables[0];

                DataTable tbl;
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                tbl = JCCMaterialOrder.BusinessLayer.StaticTables.Vendor;
                repVendor.DataSource = tbl;
                repVendor.DisplayMember = "Name";
                repVendor.ValueMember = "VendorID";
                col.Caption = "ID";
                col.FieldName = "VendorID";
                col.Visible = true;
                repVendor.Columns.Add(col);
                col1.Caption = "Name";
                col1.FieldName = "Name";
                col1.Visible = true;
                repVendor.Columns.Add(col1);

                cboFrom.Properties.DataSource = contact;
                cboFrom.Properties.PopulateColumns();
                cboFrom.Properties.DisplayMember = "Name";
                cboFrom.Properties.ValueMember = "ContactID";
                cboFrom.Properties.ShowHeader = false;
                cboFrom.Properties.Columns[0].Visible = false;

                cboPOAddress.Properties.DataSource = JCCMaterialOrder.BusinessLayer.StaticTables.POAddress;
                cboPOAddress.Properties.DisplayMember = "Type";
                cboPOAddress.Properties.ValueMember = "Type";
                cboPOAddress.Properties.PopulateColumns();
                cboPOAddress.Properties.ShowHeader = false;



                defaultFromID = JobDefaultValues.GetJobDefaultFrom(jobID);

                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    ribbonReport.Visible = false;
                    GetMaterialOrder();
                }
                else
                {
                    GetMaterialOrder();
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
        private void PreviousMaterialOrderON()
        {
            lblPreviousOrders.Visible = true;
            cboPreviousOrders.Visible = true;
            cboPreviousOrders.EditValue = null;
            cboPreviousOrders.Properties.Columns.Clear();
            cboPreviousOrders.Properties.DataSource = null;
            cboPreviousOrders.Properties.DataSource = MaterialOrder.GetJobMaterialOrderDescription(jobID).Tables[0];
            cboPreviousOrders.Properties.DisplayMember = "Description";
            cboPreviousOrders.Properties.ValueMember = "JobMaterialOrderID";
            cboPreviousOrders.Properties.PopulateColumns();
            cboPreviousOrders.Properties.ShowHeader = false;
            cboPreviousOrders.Properties.Columns[0].Visible = false;
        }
        //
        private void PreviousMaterialOrderOff()
        {
            lblPreviousOrders.Visible = false;
            cboPreviousOrders.Visible = false;
        }
        //
        private void GetMaterialOrderDetail(string recordID)
        {
            changesStatus = false;

            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateMaterialOrder(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtJobNumber.Text = "";
                txtOrderNumber.Text = "";
                txtCreatedDate.Text = "";
                txtCreatedBy.Text = "";
                txtDescription.Text = "";
                txtShipTo.Text = "";
                txtShipToAddress.Text = "";
                txtShipToCity.Text = "";
                txtShipToState.Text = "";
                txtShipToZip.Text = "";
                txtPhone.Text = "";
                cboFrom.EditValue = null;
                txtRequiredDate.EditValue = null;
                if (defaultFromID > 0)
                    cboFrom.EditValue = defaultFromID;

                UnProtectForm();
            }
            GetMaterialOrderItems(recordID);
            UpdateErrorMessages();
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            try
            {
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdMaterialOrderItemView, "frmMaterialOrder");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
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
            if (bColumnWidthChanged)
            {
                bColumnWidthChanged = false;
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdMaterialOrderItemView, "frmMaterialOrder");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }

            }
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Material Order":
                    if (CheckMaterialOrderStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetMaterialOrder();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "Previous Material Order":
                    if (CheckMaterialOrderStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        ribbonReport.Visible = true;
                        GetMaterialOrder();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = true;
                    }
                    break;
                case "&New":
                    if (CheckMaterialOrderStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        ribbonReport.Visible = false;
                        GetMaterialOrder();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        //btnCopy.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckMaterialOrderStatus(ClickedButton.Save))
                    {
                        ribbonReport.Visible = true;
                    }
                    break;
                case "&Undo":
                    GetMaterialOrder();
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
                case "Material Order":
                    try
                    {
                        Reports.Reports.MaterialOrderForm(reportJobID,recordID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                    break;
            }
        }
        //
        private bool CheckMaterialOrderStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveMaterialOrder();
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
        private void SaveMaterialOrder()
        {
           try
           {
               MaterialOrder order = new MaterialOrder(recordID,
                                                            jobID,
                                                            txtDescription.Text,
                                                            txtShipToAddress.Text,
                                                            txtRequiredDate.Text,
                                                            txtPhone.Text,
                                                            cboFrom.EditValue == null ? "" : cboFrom.EditValue.ToString(),
                                                            txtShipTo.Text,
                                                            txtShipToCity.Text,
                                                            txtShipToState.Text,
                                                            txtShipToZip.Text);
                                   
                order.Save();

                if (recordID == "" || recordID == "0")
                {
                    PreviousMaterialOrderON();
                    recordID = order.JobMaterialOrderID;
                }
                else
                    PreviousMaterialOrderOff();

                txtRecordID.Text = recordID;
                DataRow r = MaterialOrder.GetCreatUpdate(recordID).Tables[0].Rows[0];
                txtCreatedDate.EditValue = r["CreatedDate"];
                txtCreatedBy.Text = r["CreatedByName"].ToString();
                txtOrderNumber.Text = r["OrderNumber"].ToString();
                SaveMaterialOrderItems();
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
        private void GetMaterialOrder()
        {
            GetMaterialOrderDetail(recordID);
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
         /*   if (!dataChanged)
            {
                if (isMaterialList)
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
            }
            */


            if (!dataChanged)
            {
                if (isMaterialList)
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
        private void frmMaterialOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bColumnWidthChanged)
            {
                try
                {
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdMaterialOrderItemView, "frmMaterialOrder");
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
            }

            CheckMaterialOrderStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateMaterialOrder(string recordID)
        {
            try
            {
                DataRow r;
                r = MaterialOrder.GetMaterialOrder(recordID).Tables[0].Rows[0];
                reportJobID                     = r["JobID"].ToString();
                txtJobNumber.Text               = r["JobNumber"].ToString();
                txtOrderNumber.Text             = r["OrderNumber"].ToString();
                txtCreatedDate.EditValue        = r["CreatedDate"];
                txtCreatedBy.Text               = r["CreatedByName"].ToString();
                txtDescription.Text             = r["Description"].ToString();
                txtShipTo.Text                  = r["ShipTo"].ToString();
                txtShipToAddress.Text           = r["ShipToAddress"].ToString();
                txtShipToCity.Text              = r["ShipToCity"].ToString();
                txtShipToState.Text             = r["ShipToState"].ToString();
                txtShipToZip.Text               = r["ShipToZip"].ToString();
                txtPhone.Text = r["Phone"].ToString();
                txtRequiredDate.EditValue       = r["RequiredDate"];
                cboFrom.EditValue =             r["FromID"];

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
            txtRequiredDate.ErrorText = "";
            txtShipToAddress.ErrorText = "";
            txtDescription.ErrorText = "";
            
            
            
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

                        jobID = MaterialOrder.GetJobID(txtJobNumber.Text.Trim());
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
            //
            if (txtRequiredDate.Text.Trim() == "")
            {
                txtRequiredDate.ErrorText = "Required Date is Requried";
                errorMessages = true;
            }
            //
            if (txtDescription.Text.Trim() == "")
            {
                txtDescription.ErrorText = "Description is Required";
                errorMessages = true;
            }
        }
        //
        private void GetMaterialOrderItems(string jobMaterialOrderID)
        {
            try
            {
                materialOrderDataTable = MaterialOrderDetail.GetJobMaterialOrderItems(jobMaterialOrderID).Tables[0];

                this.grdMaterialOrderItem.DataSource = materialOrderDataTable.DefaultView;

                grdMaterialOrderItemView.Columns["JobMaterialOrderDetailID"].Visible = false;
                grdMaterialOrderItemView.Columns["Quantity"].ColumnEdit = repQuantity;
                grdMaterialOrderItemView.Columns["Description"].ColumnEdit = repDescriptionMem;
                grdMaterialOrderItemView.Columns["Vendor"].ColumnEdit = repVendor;
                grdMaterialOrderItemView.Columns["PO"].ColumnEdit = repPONumber;
                grdMaterialOrderItemView.BestFitColumns();
                grdMaterialOrderItemView.Columns["Description"].Width = 200;
                grdMaterialOrderItemView.Columns["Vendor"].Width = 200;
                grdMaterialOrderItemView.Columns["PO"].Width = 75;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void SetControlAccess()
        {
            if (recordID == "" || recordID == "0" )
            {
                grdMaterialOrderItemView.OptionsBehavior.Editable = false;
                grdMaterialOrderItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
            else
            {
              

                 if (isMaterialList)
                    {
                        if (Security.Security.UserJCCEquipmentRentalAccessLevel == Security.Security.AccessLevel.ReadOnly)
                        {
                              grdMaterialOrderItemView.OptionsBehavior.Editable = false;
                              grdMaterialOrderItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

                        }
                        else
                        {
                              grdMaterialOrderItemView.OptionsBehavior.Editable = true;
                                grdMaterialOrderItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

                        }
                    }
                    else
                    {
                        if (Security.Security.UserAccessTitle == Security.Security.AccessTitle.Foreman && !Security.Security.currentJobReadOnly)
                        {
                            grdMaterialOrderItemView.OptionsBehavior.Editable = true;
                            grdMaterialOrderItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        }
                        else
                        {
                            if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly ||
                                Security.Security.currentJobReadOnly)
                            {
                                grdMaterialOrderItemView.OptionsBehavior.Editable = false;
                                grdMaterialOrderItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                            }
                            else
                            {
                                grdMaterialOrderItemView.OptionsBehavior.Editable = true;
                                grdMaterialOrderItemView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;


                            }
                        }
                    }
                }

        }
        //
        private void SaveMaterialOrderItems()
        {
            bool eMail = false;
            try
            {
                this.Cursor = Cursors.AppStarting;
                MaterialOrderDetail materialDetail;
                if (materialOrderDataTable != null)
                {
                    foreach (DataRow r in materialOrderDataTable.Rows)
                    {
                        // Update Record
                        switch (r.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                materialDetail = new MaterialOrderDetail(
                                                    r["JobMaterialOrderDetailID"].ToString(),
                                                    recordID,
                                                    r["Quantity"].ToString(),
                                                    r["Description"].ToString(),
                                                    r["Needed By"].ToString(),
                                                    r["Received Date"].ToString(),
                                                    r["Vendor"].ToString(),
                                                    r["PO"].ToString());
                                materialDetail.Save();
                                r["JobMaterialOrderDetailID"] = materialDetail.JobMaterialOrderDetailID;
                                eMail = true;
                                break;
                            case DataRowState.Deleted:
                                try
                                {
                                    if (r["JobMaterialOrderDetailID"].ToString().Trim().Length > 0)
                                    {
                                        MaterialOrderDetail.Remove(r["JobMaterialOrderDetailID"].ToString());
                                    }
                                }
                                catch { }
                                break;
                        }
                    }
                }
                if (eMail)
                {
                    MaterialOrder.EMail(recordID);
                    MessageBox.Show("An Email has been sent for the new Material Order!", CCEApplication.ApplicationName);

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
                if (Security.Security.UserJCCEquipmentRentalAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void cboPreviousOrders_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPreviousOrders.EditValue != null)
            {
                materialOrderDataTable = MaterialOrderDetail.GetJobMaterialPreviousOrderItems(cboPreviousOrders.EditValue.ToString()).Tables[0];

                foreach(DataRow r in materialOrderDataTable.Rows)
                    r.SetModified();

                this.grdMaterialOrderItem.DataSource = materialOrderDataTable.DefaultView;

                grdMaterialOrderItemView.Columns["JobMaterialOrderDetailID"].Visible = false;
                grdMaterialOrderItemView.Columns["Quantity"].ColumnEdit = repQuantity;
                grdMaterialOrderItemView.Columns["Description"].ColumnEdit = repDescriptionMem;
                grdMaterialOrderItemView.Columns["Vendor"].ColumnEdit = repVendor;
                grdMaterialOrderItemView.Columns["PO"].ColumnEdit = repPONumber;
                grdMaterialOrderItemView.BestFitColumns();
                grdMaterialOrderItemView.Columns["Description"].Width = 200;
                grdMaterialOrderItemView.Columns["Vendor"].Width = 200;
                grdMaterialOrderItemView.Columns["PO"].Width = 75;
                if (materialOrderDataTable.Rows.Count > 0)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }

        private void grdMaterialOrderItemView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Delete")
            {
                DataRow r = grdMaterialOrderItemView.GetDataRow(grdMaterialOrderItemView.GetSelectedRows()[0]);
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
                        if(r["JobMaterialOrderDetailID"].ToString().Trim().Length > 0)
                            MaterialOrderDetail.Remove(r["JobMaterialOrderDetailID"].ToString());
                        r.Delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
                    }
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("You are about to Email the Material Order. Contine?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Reports.Reports.JobMaterialOrderEmail(jobID, recordID);
                    MessageBox.Show("The Email has been sent!", CCEApplication.ApplicationName);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, CCEApplication.ApplicationName); }
        }

        private void grdMaterialOrderItemView_ColumnWidthChanged(object sender, ColumnEventArgs e)
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
                       /* case "OFFICE":
                            t = Job.GetJobOffice(jobID).Tables[0];
                            if (t.Rows.Count > 0)
                            {
                                txtShipToAddress.Text = t.Rows[0]["Address"].ToString();
                                txtShipToCity.Text = t.Rows[0]["City"].ToString();
                                txtShipToState.Text = t.Rows[0]["State"].ToString();
                                txtShipToZip.Text = t.Rows[0]["ZipCode"].ToString();
                            }
                            break;*/
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
   
    }
}