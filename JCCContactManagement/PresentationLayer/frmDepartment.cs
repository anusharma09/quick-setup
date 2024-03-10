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
    public partial class frmDepartment : DevExpress.XtraBars.Ribbon.RibbonForm
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
        public frmDepartment()
        {
            InitializeComponent();
        }
        //
        public frmDepartment(string recordID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmDepartment_Load(object sender, EventArgs e)
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
                 
                txtRecordID.DataBindings.Add("text", bindingSource, "CMDepartmentID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    GetDepartment();
                }
                else
                {
                    GetDepartment();
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
        private void GetDepartmentDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateDepartment(recordID);
                ProtectForm();
                this.Focus();

            }
            else
            {
                txtDepartment.Text = "";
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
               case "Next Department":
                    if (CheckFormStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        GetDepartment();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "Previous Department":
                    if (CheckFormStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        GetDepartment();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "&New":
                    if (CheckFormStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetDepartment();
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
                    txtDepartment.Select();
                    txtDepartment.Select(0, 0);
                    bindingSource.CancelEdit();
                    GetDepartment();
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
                        SaveDepartment();
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
        private void SaveDepartment()
        {
            
            try
            {
                
                CMDepartment cmDepartment = new CMDepartment(recordID,
                                        txtDepartment.Text);
                cmDepartment.Save();
                recordID = cmDepartment.CMDepartmentID;
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
        private void GetDepartment()
        {
            GetDepartmentDetail(recordID);
            this.Text = txtDepartment.Text;
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
        private void frmDepartment_FormClosed(object sender, FormClosedEventArgs e)
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
        private void UpdateDepartment(string recordID)
        {
            try
            {
                DataRow dr;
                dr = CMDepartment.GetCMDepartmentDetail(recordID).Tables[0].Rows[0];
                
                txtDepartment.Text                    = dr["Department"].ToString();
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
            txtDepartment.ErrorText = "";

            if (txtDepartment.Text.Trim().Length == 0)
            {
                txtDepartment.ErrorText = "Department is required";
                errorMessages = true;
            }
        }
    }
}