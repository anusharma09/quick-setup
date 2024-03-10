using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using DevExpress.XtraEditors.Repository;

namespace CCEJobs.PresentationLayer
{
    public partial class frmContact : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected string jobID;
        protected bool dataChanged;
        private bool errorMessages = false;
        private bool changesStatus = false;
        //
        enum ClickedButton
        {
            Delete,
            New,
            Save,
            Undo,
            Close
        };
        //
        public frmContact()
        {
            InitializeComponent();
        }
        //
        public frmContact(string recordID, string jobID)
        {
            this.recordID           = recordID;
            this.jobID              = jobID;
            InitializeComponent();
        }
        //
        private void frmContact_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;

                  if (Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly)
                  {
                      btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                      btnSave.Enabled = false;
                      btnUndo.Enabled = false;
                  }                 
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                if (recordID == "0")
                {
                    GetContact();
                }
                else
                {
                    GetContact();
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
        private void GetContactDetail(string recordID)
        {
            changesStatus = false;
            if (recordID.Length > 0 && recordID != "0")
            {
                UpdateContact(recordID);
                this.Focus();
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtTitle.Text = "";
                txtEmail.Text = "";
                txtWebSite.Text = "";
                txtCompanyName.Text = "";
                txtCategories.Text = "";
                txtPhoneNumber.Text = "";
                txtCellPhoneNumber.Text = "";
                txtOfficeStreetAddress.Text = "";
                txtOfficeCity.Text = "";
                txtOfficeState.Text = "";
                txtOfficeZip.Text = "";
                txtOfficeCountry.Text = "";
                txtOfficePhoneNumber.Text = "";
                txtOfficeFAXPhoneNumber.Text = "";
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            dataChanged = false;
            UpdateErrorMessages();
        }

        //
        private void allButtons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string name;
            name = ((DevExpress.XtraBars.Ribbon.RibbonBarManager)sender).PressedLink.Caption;
            switch (name)
            {
                case "&New":
                    if (CheckContactStatus(ClickedButton.New))
                    {
                        recordID = "0";
                        txtRecordID.Text = "0";
                        GetContact();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    break;
                case "&Save":
                    if (CheckContactStatus(ClickedButton.Save))
                    {
                    }
                    break;
                case "&Undo":
                    GetContact();
                    dataChanged = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = true;
                    break;
            }
        }
        //
        private bool CheckContactStatus(ClickedButton SelectedButton)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Save the changes?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (ValidateAllControls())
                    { 
                        SaveContact();
                        dataChanged = false;
                        btnUndo.Enabled = false;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Please make sure to enter all required fields", CCEApplication.ApplicationName);
                        return false;
                    }
                }
                else
                {
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
                dataChanged = false;
                btnUndo.Enabled = false;
                dxErrorProvider.ClearErrors();
                return true;
            }
        }
        //
        private void SaveContact()
        {
            try
            {
                
                Contact contact = new Contact(recordID,
                                                jobID, 
                                                txtFirstName.Text,
                                                txtLastName.Text,
                                                txtTitle.Text,
                                                txtEmail.Text,
                                                txtWebSite.Text,
                                                txtCompanyName.Text,
                                                txtCategories.Text,
                                                txtPhoneNumber.Text,
                                                txtCellPhoneNumber.Text,
                                                txtOfficeStreetAddress.Text,
                                                txtOfficeCity.Text,
                                                txtOfficeState.Text,
                                                txtOfficeZip.Text,
                                                txtOfficeCountry.Text,
                                                txtOfficePhoneNumber.Text,
                                                txtOfficeFAXPhoneNumber.Text );
                contact.SaveDetail();
                recordID = contact.JobContactDetailID;
                txtRecordID.Text = recordID;
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
        private void GetContact()
        {
            GetContactDetail(recordID);
            //this.Text = txtFirstName.Text;
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
                //string myString = myControl.Text.Trim().ToUpper();

               // if (myString != myControl.Text.Trim())
               //     myControl.Text = myControl.Text.ToString().ToUpper();
            }
            if (!dataChanged)
            {
                if (Security.Security.UserJCCAccessLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    dataChanged = true;
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
        }
        //
        private void frmContact_FormClosed(object sender, FormClosedEventArgs e)
        {
            CheckContactStatus(ClickedButton.Close);
            if (changesStatus)
            {
                changesStatus = false;
            }
        }
        private void CheckFormStatus()
        {
        }
        //
        private void UpdateContact(string recordID)
        {
            try
            {
                DataRow rr;
                rr =  Contact.GetContact(recordID, "False", Convert.ToInt32(jobID)).Tables[0].Rows[0];
                txtFirstName.Text           = rr["FirstName"].ToString();
                txtLastName.Text            = rr["LastName"].ToString();
                txtOfficePhoneNumber.Text   = rr["OfficePhoneNumber"].ToString();
                txtPhoneNumber.Text         = rr["PhoneNumber"].ToString();
                txtCompanyName.Text         = rr["CompanyName"].ToString();
                txtEmail.Text               = rr["email"].ToString();
                txtOfficeStreetAddress.Text = rr["OfficeStreetAddress"].ToString();
                txtOfficeCity.Text          = rr["OfficeCity"].ToString();
                txtOfficeState.Text         = rr["OfficeState"].ToString();
                txtOfficeZip.Text           = rr["OfficeZIP"].ToString();
                txtOfficeCountry.Text       = rr["OfficeCountry"].ToString();
                txtOfficeFAXPhoneNumber.Text = rr["OfficeFAXPhoneNumber"].ToString();
                txtCellPhoneNumber.Text     = rr["CellPhoneNumber"].ToString();
                txtTitle.Text               = rr["Title"].ToString();
                txtCategories.Text          = rr["Categories"].ToString();
                txtWebSite.Text             = rr["WebSite"].ToString();
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
            txtLastName.ErrorText = "";
            txtFirstName.ErrorText = "";

            if (txtFirstName.Text.Trim().Length == 0)
            {
                txtFirstName.ErrorText = "First Name is required";
                errorMessages = true;
            }
           
            if (txtLastName.Text.Trim().Length == 0)
            {
                txtLastName.ErrorText = "Last Name is required";
                errorMessages = true;
            }
        }
    }
}