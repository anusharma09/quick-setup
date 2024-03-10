using JCCBusinessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CCEJobs.PresentationLayer
{
    public partial class frmGlobalContact : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected string recordID;
        protected bool dataChanged;
        private bool errorMessages = false;
        private bool changesStatus = false;
        private bool phoneValidation = false;

        //
        private enum ClickedButton
        {
            Delete,
            New,
            Save,
            Undo,
            Close
        };
        //
        public frmGlobalContact()
        {
            InitializeComponent();
        }
        //
        public frmGlobalContact(string recordID)
        {
            this.recordID = recordID;
            InitializeComponent();
        }
        //
        private void frmGlobalContacts_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.AppStarting;

                if (Security.Security.UserJCCGlobalContactLevel == Security.Security.AccessLevel.ReadOnly)
                {
                    btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = false;
                    DisableControl();
                }
                //
                UpdateErrorMessages();
                txtRecordID.Text = recordID;
                GlobalContacts.ContactId = recordID;
                cboCategories.Properties.DataSource = StaticTables.Category;
                cboCategories.Properties.DisplayMember = "Category";
                cboCategories.Properties.ValueMember = "Category";
                cboCategories.Properties.PopulateColumns();
                cboCategories.Properties.ShowHeader = false;
                if (cboCategories.Properties.Columns.Count > 0)
                {
                    cboCategories.Properties.Columns[0].Visible = false;
                }
                else
                {

                }

                if (recordID == "0")
                {
                    GetContact();
                }
                else
                {
                    GetContact();
                }
                Opacity = 1;
                Cursor = Cursors.Default;
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
                if (Security.Security.UserJCCGlobalContactLevel != Security.Security.AccessLevel.ReadOnly)
                {
                    btnDelete.Enabled = true;
                }
                Focus();
            }
            else
            {
                txtFirstName.Text = "";
                txtMiddleName.Text = "";
                txtLastName.Text = "";
                txtTitle.Text = "";
                txtEmail.Text = "";
                txtCompanyName.Text = "";
                cboCategories.EditValue = "";
                txtPhoneNumber.Text = "";
                txtCellPhoneNumber.Text = "";
                txtOfficeStreetAddress.Text = "";
                txtOfficeCity.Text = "";
                txtOfficeState.Text = "";
                txtOfficeZip.Text = "";
                txtOfficeCountry.Text = "";
                txtBusinessPhone.Text = "";
                txtExt.Text = "";
                txtOfficeFAXPhoneNumber.Text = "";
                btnDelete.Enabled = false;
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
                        GlobalContacts.ContactId = "0";
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
                case "&Delete":
                    if (MessageBox.Show("Are you sure you want to delete the contact?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteContact();
                    }
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
                        if (!phoneValidation)
                        {
                            MessageBox.Show("Please make sure to enter all required fields", CCEApplication.ApplicationName);
                        }
                        else
                        {
                            phoneValidation = false;
                        }

                        return false;
                    }
                }
                else
                {
                    if (SelectedButton == ClickedButton.Save)
                    {
                        return false;
                    }
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
                string firstName = string.Empty;
                if (txtFirstName.Text.Contains("'"))
                {
                    firstName = txtFirstName.Text.Replace("'", "''");
                }
                else
                { firstName = txtFirstName.Text; }

                string lastName = string.Empty;
                if (txtLastName.Text.Contains("'"))
                {
                    lastName = txtLastName.Text.Replace("'", "''");
                }
                else
                { lastName = txtLastName.Text; }

                string company = string.Empty;
                if (txtCompanyName.Text.Contains("'"))
                {
                    company = txtCompanyName.Text.Replace("'", "''");
                }
                else
                { company = txtCompanyName.Text; }

                GlobalContacts contact = new GlobalContacts(firstName,
                                                lastName,
                                                txtMiddleName.Text,
                                                txtTitle.Text,
                                                txtEmail.Text,
                                                company,
                                                cboCategories.Text,
                                                txtPhoneNumber.Text,
                                                txtCellPhoneNumber.Text,
                                                txtOfficeStreetAddress.Text,
                                                txtOfficeCity.Text,
                                                txtOfficeState.Text,
                                                txtOfficeZip.Text,
                                                txtOfficeCountry.Text,
                                                txtBusinessPhone.Text,
                                                txtOfficeFAXPhoneNumber.Text,
                                                txtExt.Text);

                contact.SaveDetail();
                if (recordID == "0" || recordID == "")
                {
                    recordID = GlobalContacts.ContactId;
                    MessageBox.Show("New Contact is added successfully.");
                }
                else
                {
                    MessageBox.Show("Contact is updated successfully.");
                }
                changesStatus = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnDelete.Enabled = true;
        }
        //
        private void GetContact()
        {
            GetContactDetail(recordID);
        }
        //
        private void ControlValidating(object sender, CancelEventArgs e)
        {
            UpdateErrorMessages();
        }
        //
        private bool ValidateAllControls()
        {
            UpdateErrorMessages("SAVE");
            return !errorMessages;
        }
        //
        private void AllControls_EditValue(Object sender, EventArgs e)
        {
            DevExpress.XtraEditors.BaseControl myControl = (DevExpress.XtraEditors.BaseControl)sender;
            if (!dataChanged)
            {
                if (Security.Security.UserJCCGlobalContactLevel != Security.Security.AccessLevel.ReadOnly)
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
        private void UpdateContact(string recordID)
        {
            try
            {
                DataRow rr;
                rr = GlobalContacts.GetGlobalContact(recordID).Tables[0].Rows[0];
                txtFirstName.Text = rr["FirstName"].ToString();
                txtLastName.Text = rr["LastName"].ToString();
                txtMiddleName.Text = rr["MiddleName"].ToString();
                txtBusinessPhone.Text = rr["OfficePhoneNumber"].ToString();
                txtPhoneNumber.Text = rr["PhoneNumber"].ToString();
                txtCompanyName.Text = rr["CompanyName"].ToString();
                txtEmail.Text = rr["email"].ToString();
                txtOfficeStreetAddress.Text = rr["OfficeStreetAddress"].ToString();
                txtOfficeCity.Text = rr["OfficeCity"].ToString();
                txtOfficeState.Text = rr["OfficeState"].ToString();
                txtOfficeZip.Text = rr["OfficeZIP"].ToString();
                txtOfficeCountry.Text = rr["OfficeCountry"].ToString();
                txtOfficeFAXPhoneNumber.Text = rr["OfficeFAXPhoneNumber"].ToString();
                txtCellPhoneNumber.Text = rr["CellPhoneNumber"].ToString();
                txtTitle.Text = rr["Title"].ToString();
                cboCategories.EditValue = rr["Categories"].ToString();
                txtExt.Text = rr["OfficePhoneNumberExtension"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }
        //
        private void UpdateErrorMessages(string from = "")
        {
            errorMessages = false;
            txtLastName.ErrorText = "";
            txtFirstName.ErrorText = "";
            txtEmail.ErrorText = "";
            txtBusinessPhone.ErrorText = "";
            txtOfficeFAXPhoneNumber.ErrorText = "";
            txtPhoneNumber.ErrorText = "";

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
            if (txtEmail.Text.Trim().Length > 0)
            {
                bool isEmail = Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    txtEmail.ErrorText = "Format of email address is not correct.";
                    errorMessages = true;
                }
            }
            if (from == "SAVE")
            {
                if (txtPhoneNumber.Text.Trim() == "(___) ___-____")
                    txtPhoneNumber.Text = "";
                if (txtBusinessPhone.Text.Trim() == "(___) ___-____")
                    txtBusinessPhone.Text = "";
                if (txtOfficeFAXPhoneNumber.Text.Trim() == "(___) ___-____")
                    txtOfficeFAXPhoneNumber.Text = "";
                if (txtCellPhoneNumber.Text.Trim() == "(___) ___-____")
                    txtCellPhoneNumber.Text = "";
                if (txtPhoneNumber.Text.Trim().Length > 0)
                {
                    bool isPhone = Regex.IsMatch(txtPhoneNumber.Text, "^((\\(\\d{3}\\))|\\d{3})[- .]?\\d{3}[- .]?\\d{4}$", RegexOptions.IgnoreCase);
                    if (!isPhone)
                    {
                        MessageBox.Show("Phone Number is not correct.");
                        phoneValidation = true;
                        errorMessages = true;
                    }
                }
                if (txtBusinessPhone.Text.Trim().Length > 0)
                {
                    bool isPhone = Regex.IsMatch(txtBusinessPhone.Text, "^((\\(\\d{3}\\))|\\d{3})[- .]?\\d{3}[- .]?\\d{4}$", RegexOptions.IgnoreCase);
                    if (!isPhone)
                    {
                        MessageBox.Show("Business Phone Number is not correct.");
                        phoneValidation = true;
                        errorMessages = true;
                    }
                }
                if (txtOfficeFAXPhoneNumber.Text.Trim().Length > 0)
                {
                    bool isPhone = Regex.IsMatch(txtOfficeFAXPhoneNumber.Text, "^((\\(\\d{3}\\))|\\d{3})[- .]?\\d{3}[- .]?\\d{4}$", RegexOptions.IgnoreCase);
                    if (!isPhone)
                    {
                        MessageBox.Show("Fax Number is not correct.");
                        phoneValidation = true;
                        errorMessages = true;
                    }
                }
                if (txtCellPhoneNumber.Text.Trim().Length > 0)
                {
                    bool isPhone = Regex.IsMatch(txtCellPhoneNumber.Text, "^((\\(\\d{3}\\))|\\d{3})[- .]?\\d{3}[- .]?\\d{4}$", RegexOptions.IgnoreCase);
                    if (!isPhone)
                    {
                        MessageBox.Show("Cell Phone Number is not correct.");
                        phoneValidation = true;
                        errorMessages = true;
                    }
                }
                if (txtOfficeZip.Text.Trim().Length > 0)
                {
                    bool isZip = Regex.IsMatch(txtOfficeZip.Text, "^(?(^00000(|-0000))|(\\d{5}(|-\\d{4})))$", RegexOptions.IgnoreCase);
                    if (!isZip)
                    {
                        MessageBox.Show("Zip code is not correct.");
                        phoneValidation = true;
                        errorMessages = true;
                    }
                }
            }
        }

        private void DeleteContact()
        {
            try
            {
                GlobalContacts.Delete(recordID);
                MessageBox.Show("Contact is deleted successfully.");
                dataChanged = false;
                Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DisableControl()
        {
            try
            {
                txtFirstName.Enabled = false;
                txtMiddleName.Enabled = false;
                txtLastName.Enabled = false;
                txtEmail.Enabled = false;
                txtTitle.Enabled = false;
                txtCompanyName.Enabled = false;
                cboCategories.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtCellPhoneNumber.Enabled = false;
                txtOfficeStreetAddress.Enabled = false;
                txtOfficeCity.Enabled = false;
                txtOfficeState.Enabled = false;
                txtOfficeCountry.Enabled = false;
                txtOfficeZip.Enabled = false;
                txtOfficeFAXPhoneNumber.Enabled = false;
                txtExt.Enabled = false;
                txtBusinessPhone.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}