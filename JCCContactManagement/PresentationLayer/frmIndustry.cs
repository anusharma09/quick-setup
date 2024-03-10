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
    public partial class frmIndustry : DevExpress.XtraBars.Ribbon.RibbonForm
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
        public frmIndustry()
        {
            InitializeComponent();
        }
        //
        public frmIndustry(string recordID, BindingSource bindingSource)
        {
            this.recordID           = recordID;
            this.bindingSource      = bindingSource;
            InitializeComponent();
        }
        //
        private void frmIndustry_Load(object sender, EventArgs e)
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
                 
                txtRecordID.DataBindings.Add("text", bindingSource, "CMIndustryID");
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    GetIndustry();
                }
                else
                {
                    GetIndustry();
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
        private void GetIndustryDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateIndustry(recordID);
                ProtectForm();
                this.Focus();

            }
            else
            {
                txtIndustry.Text = "";
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
               case "Next Industry":
                    if (CheckFormStatus(ClickedButton.Next))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MoveNext();
                        recordID = txtRecordID.Text;
                        GetIndustry();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "Previous Industry":
                    if (CheckFormStatus(ClickedButton.Previous))
                    {
                        if (changesStatus)
                        {
                            changesStatus = false;
                        }
                        bindingSource.MovePrevious();
                        recordID = txtRecordID.Text;
                        GetIndustry();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                    }
                    break;
                case "&New":
                    if (CheckFormStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetIndustry();
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
                    txtIndustry.Select();
                    txtIndustry.Select(0, 0);
                    bindingSource.CancelEdit();
                    GetIndustry();
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
                        SaveIndustry();
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
        private void SaveIndustry()
        {
            
            try
            {
                
                CMIndustry cmIndustry = new CMIndustry(recordID,
                                        txtIndustry.Text);
                cmIndustry.Save();
                recordID = cmIndustry.CMIndustryID;
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
        private void GetIndustry()
        {
            GetIndustryDetail(recordID);
            this.Text = txtIndustry.Text;
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
        private void frmIndustry_FormClosed(object sender, FormClosedEventArgs e)
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
        private void UpdateIndustry(string recordID)
        {
            try
            {
                DataRow dr;
                dr = CMIndustry.GetCMIndustryDetail(recordID).Tables[0].Rows[0];
                
                txtIndustry.Text                    = dr["Industry"].ToString();
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
            txtIndustry.ErrorText = "";

            if (txtIndustry.Text.Trim().Length == 0)
            {
                txtIndustry.ErrorText = "Industry is required";
                errorMessages = true;
            }
        }
    }
}