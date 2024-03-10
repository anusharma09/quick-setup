using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCContactManagement.BusinessLayer;
using JCCContactManagement;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
namespace JCCContactManagement.PresentationLayer
{
    public partial class frmReferredBy : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected BindingSource bindingSource;
        DataTable table;

        protected bool dataChanged;
        private bool errorMessages = false;
        private bool changesStatus = false;
        //
        enum ClickedButton
        {
            Next,
            Previous,
            Delete,
            New,
            Save,
            Undo,
            Close
        };
        //
        public frmReferredBy()
        {
            InitializeComponent();
        }
        //
        public frmReferredBy(string recordID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmReferredBy_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                  if (Security.Security.UserJCCContactManagementAccessLevel == Security.Security.AccessLevel.ReadOnly)
                  {
                      btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                      btnSave.Enabled = false;
                      btnUndo.Enabled = false;
                  }
                  else
                  {
                      if (Security.Security.UserJCCContactManagementAccessLevel != Security.Security.AccessLevel.ReadWriteCreate)
                          btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                  }
                 
                txtRecordID.DataBindings.Add("text", bindingSource, "CMReferredByID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    GetReferredBy();
                }
                else
                {
                    GetReferredBy();
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
        private void GetReferredByDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateReferredBy(recordID);
                ProtectForm();
                this.Focus();
            }
            else
            {
                txtReferredBy.Text = "";
                UnProtectForm();
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
        }
        //
        private void ProtectForm()
        {
            //txtCategoryName.Properties.ReadOnly = true;
        }
        //
        private void UnProtectForm()
        {
            //txtCategoryName.Properties.ReadOnly = false;
        }
        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
               case "Next Referred By":
                    if (CheckFormStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        GetReferredBy();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "Previous Referred By":
                    if (CheckFormStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        GetReferredBy();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "&New":
                    if (CheckFormStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetReferredBy();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckFormStatus(ClickedButton.Save))
                    {
                    }
                    break;
                case "&Undo":
                    txtReferredBy.Select();
                    txtReferredBy.Select(0, 0);
                    bindingSource.CancelEdit();
                    GetReferredBy();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    break;
            }
        }
        //
        private bool CheckFormStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveReferredBy();
                        bindingSource.EndEdit();
                        dataChanged = false;
                        btnUndo.Enabled = false;
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
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveReferredBy()
        {
            
            try
            {
                
                CMReferredBy cmReferredBy = new CMReferredBy(recordID,
                                        txtReferredBy.Text);
                cmReferredBy.Save();
                recordID = cmReferredBy.CMReferredByID;
                txtRecordID.Text = recordID;
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
        private void GetReferredBy()
        {
            GetReferredByDetail(recordID);
            this.Text = txtReferredBy.Text;
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
                string myString = myControl.Text.Trim().ToUpper();

                if (myString != myControl.Text.Trim())
                    myControl.Text = myControl.Text.ToString().ToUpper();
            }
            if (!dataChanged)
            {
                 if (Security.Security.UserJCCContactManagementAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }
        //
        private void frmReferredBy_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckFormStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateReferredBy(string recordID)
        {
            try
            {
                DataRow dr;
                dr = CMReferredBy.GetCMReferredByDetail(recordID).Tables[0].Rows[0];
                
                txtReferredBy.Text                    = dr["Referred By"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages()
        {     
            errorMessages = false;
            txtReferredBy.ErrorText = "";

            if (txtReferredBy.Text.Trim().Length == 0)
            {
                txtReferredBy.ErrorText = "Referred By is required";
                errorMessages = true;
            }
        }
    }
}