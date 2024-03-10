using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JCCBusinessLayer;
using CCEJobs.PresentationLayer;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace CCEJobs.Controls
{
 
    public partial class ctlJobContact : UserControl
    {  
        //
        protected bool bColumnWidthChanged = false;
        private Security.Security.JobCaller jobCaller = Security.Security.JobCaller.NoAccess;
        private DataSet jobContactDataSet;
        private string jobID;
        public bool comboIsLoaded = false;
        private bool IsnewJob = false;

        //
        public ctlJobContact()
        {
            InitializeComponent();
        }
        //
        public Security.Security.JobCaller JobCaller
        {
            set
            {
                jobCaller = value;
            }
        }
        //
        public string JobID
        {
            set
            {
                jobID = value;
                if (jobID == "")
                    jobID = "0";
                ClearDetail();
                if (jobID != "0")
                    GetJobContact();
                SetControlAccess();
            }
        }
     
        //
        private void GetJobContact()
        {
            try
            {
                if (bColumnWidthChanged)
                {
                    bColumnWidthChanged = false;
                    Security.BusinessLayer.UserConfiguration.SaveGridConfiguration(grdContactView, "ctlJobContact");
                }
                IsnewJob = Contact.CheckIsJobNew(Convert.ToInt32(jobID));
                jobContactDataSet = Contact.GetJobContact(jobID);

                grdContact.DataSource = jobContactDataSet.Tables[0].DefaultView;
                if (chkSelected.CheckState == CheckState.Checked)
                    jobContactDataSet.Tables[0].DefaultView.RowFilter = "Selected = True";
                grdContactView.Columns["CompanyContactID"].Visible = false;
                grdContactView.Columns["ContactID"].Visible = false;
                grdContactView.Columns["First Name"].OptionsColumn.AllowEdit = false;
                grdContactView.Columns["Last Name"].OptionsColumn.AllowEdit = false;
                grdContactView.Columns["Company"].OptionsColumn.AllowEdit = false;
                grdContactView.Columns["Lotus Notes"].Visible = false;
                grdContactView.BestFitColumns();
                Security.BusinessLayer.UserConfiguration.GetGridConfiguration(grdContactView, "ctlJobContact");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        private void chkSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (jobContactDataSet != null)
            {
                if (chkSelected.Checked.ToString() == "True")
                    jobContactDataSet.Tables[0].DefaultView.RowFilter = "Selected = True ";
                else
                    jobContactDataSet.Tables[0].DefaultView.RowFilter = "";
            }
        }
        //
        private void ctlJobCostCodes_Load(object sender, EventArgs e)
        {
            //check if there is any update in job contact details. If yes then prompt a notification
            string message = Contact.CheckIfContactIsUpdated(Convert.ToInt32(jobID));
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, CCEApplication.ApplicationName);
                Contact.UpdateJobContact(Convert.ToInt32(jobID));
            }

        }
        //
        private void SetControlAccess()
        {
            if (jobCaller == Security.Security.JobCaller.JCCDashboard ||
                Security.Security.UserJCCAccessLevel == Security.Security.AccessLevel.ReadOnly || Security.Security.currentJobReadOnly)
            {
                chkSelected.Visible = false;
                panContact.Visible = false;
                grdContactView.OptionsBehavior.Editable = false;
            }
            else
            {
                chkSelected.Visible = true;
                panContact.Visible = true;
                if (!comboIsLoaded)
                {
                    comboIsLoaded = true;
                    GetComboList();
                }
            }
        }
        //
        private void GetComboList()
        {
            if (jobID != "0" && jobID != "")
            {
                cboCompany.Properties.DataSource = Contact.GetCompany(Convert.ToInt32(jobID)).Tables[0];
                cboCompany.Properties.DisplayMember = "CompanyName";
                cboCompany.Properties.PopulateColumns();
                cboCompany.Properties.ShowHeader = false;

                cboLastName.Properties.DataSource = Contact.GetLastName(Convert.ToInt32(jobID)).Tables[0];
                cboLastName.Properties.DisplayMember = "LastName";
                cboLastName.Properties.PopulateColumns();
                cboLastName.Properties.ShowHeader = false;
            }
        }
        //
        private void btnProcess_Click(object sender, EventArgs e)
        {
           
            if (cboCompany.Text.Trim().Length > 0 || cboLastName.Text.Trim().Length > 0 )
            {
                string where = "";

                if (cboCompany.Text.Trim().Length > 0 && cboLastName.Text.Trim().Length > 0)
                    where = " WHERE CompanyName = '" + cboCompany.Text.Trim().Replace("'", "''") + "' AND LastName = '" + cboLastName.Text.Trim().Replace("'", "''") + "'";
                else
                    if (cboCompany.Text.Trim().Length > 0)
                        where = " WHERE CompanyName = '" + cboCompany.Text.Trim().Replace("'", "''") + "' ";
                    else
                        if (cboLastName.Text.Trim().Length > 0)
                            where = " WHERE LastName = '" + cboLastName.Text.Trim().Replace("'", "''") + "' ";


                DataTable t = Contact.GetContactList(where, Convert.ToInt32(jobID)).Tables[0];

                foreach (DataRow r in t.Rows)
                {
                    string query = "CompanyContactID = " + r["CompanyContactID"].ToString() + " ";
                   
                    DataRow[] m = jobContactDataSet.Tables[0].Select(query);
                    if (m.Length == 0 )
                    {
                        jobContactDataSet.Tables[0].ImportRow(r);
                    }
                }
                cboCompany.EditValue = null;
                cboLastName.EditValue = null;
            }
        }

        private void gridContactView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdContactView.GetDataRow(e.FocusedRowHandle);
                if (r == null)
                    return;
                string companyContactID = "";
                string lotusNotes = "";
                DataRow rr;

                companyContactID = r[0].ToString();
                lotusNotes = r["Lotus Notes"].ToString();
                rr = Contact.GetContact(companyContactID, lotusNotes, Convert.ToInt32(jobID)).Tables[0].Rows[0];

                txtFirstName.Text = rr["FirstName"].ToString();
                txtLastName.Text = rr["LastName"].ToString();
                txtOfficePhoneNumber.Text = rr["OfficePhoneNumber"].ToString();
                txtPhoneNumber.Text = rr["PhoneNumber"].ToString();
                txtCompanyName.Text = rr["CompanyName"].ToString();
                txtEmail.Text = rr["email"].ToString();
                txtOfficeStreetAddress.Text = rr["OfficeStreetAddress"].ToString();
                txtOfficeCity.Text = rr["OfficeCity"].ToString();
                txtOfficeState.Text = rr["OfficeState"].ToString();
                txtOfficeZIP.Text = rr["OfficeZIP"].ToString();
                txtOfficeCountry.Text = rr["OfficeCountry"].ToString();
                txtOfficeFAXPhoneNumber.Text = rr["OfficeFAXPhoneNumber"].ToString();
                txtCellPhoneNumber.Text = rr["CellPhoneNumber"].ToString();
                txtTitle.Text = rr["Title"].ToString();
                txtCategories.Text = rr["Categories"].ToString();
                if (!IsnewJob)
                {
                    txtWebSite.Text = rr["WebSite"].ToString();
                    if (lotusNotes == "True")
                    {
                        txtHomeAddress.Text = rr["HomeAddress"].ToString();
                        txtCity.Text = rr["City"].ToString();
                        txtState.Text = rr["State"].ToString();
                        txtZip.Text = rr["Zip"].ToString();
                        txtCountry.Text = rr["Country"].ToString();
                        txtHomeFAXPhoneNumber.Text = rr["HomeFAXPhoneNumber"].ToString();

                    }
                    else
                    {
                        txtHomeAddress.Text = "";
                        txtCity.Text = "";
                        txtState.Text = "";
                        txtZip.Text = "";
                        txtCountry.Text = "";
                    }
                }
                else
                {
                    txtHomeAddress.Text = "";
                    txtCity.Text = "";
                    txtState.Text = "";
                    txtZip.Text = "";
                    txtCountry.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void ClearDetail()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtOfficePhoneNumber.Text = "";
            txtPhoneNumber.Text = "";
            txtCompanyName.Text = "";
            txtEmail.Text = "";
            txtOfficeStreetAddress.Text = "";
            txtOfficeCity.Text = "";
            txtOfficeState.Text = "";
            txtOfficeZIP.Text = "";
            txtOfficeCountry.Text = "";
            txtOfficeFAXPhoneNumber.Text = "";
            txtCellPhoneNumber.Text = "";
            txtTitle.Text = "";
            txtCategories.Text = "";
            txtWebSite.Text = "";
            txtHomeAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtCountry.Text = "";
            txtHomeFAXPhoneNumber.Text = "";
            txtHomeAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            txtCountry.Text = "";

        }

        private void grdContactView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                DataRow r;

                r = grdContactView.GetDataRow(e.RowHandle);
                if (r == null)
                    return;
                string companyContactID = "";
                string contactID = "";
                string selected = "";
                string lotusNotes = "";

                companyContactID    = r[0].ToString();
                contactID           = r[1].ToString();
                selected            = r[2].ToString();
                lotusNotes =        r["Lotus Notes"].ToString();
                // Delete
                if (selected == "False" && contactID.Trim().Length > 0)
                {
                    //if (lotusNotes == "False") // 0 means false
                    //{
                        if (MessageBox.Show("Do you want to delete this contact?", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            e.Valid = false;
                            return;
                        }

                    //}
                    Contact.Delete(contactID);
                    //if (lotusNotes == "False")
                    //{
                        Contact.DeleteDetail(companyContactID);
                        GetJobContact();
                    //}
                }
                // Save
                if (selected == "True")
                {
                    Contact contact = new Contact(companyContactID, jobID, lotusNotes);
                    contact.Save();
                    r["ContactID"] = contact.ContactID; 

                }
               
            }
            catch (Exception ex)
            {
                e.Valid = false;
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void hyperLinkEdit1_Click(object sender, EventArgs e)
        {
            frmContact f = new frmContact("0", jobID);
            f.ShowDialog();
            GetJobContact();
        }

        private void grdContactView_DoubleClick(object sender, EventArgs e)
        {
            DataRow r;
            r = grdContactView.GetDataRow(grdContactView.GetSelectedRows()[0]);
            if (r == null)
                return;
            string companyContactID = "";
            string contactID = "";
            string selected = "";
            string lotusNotes = "";
            companyContactID = r[0].ToString();
            contactID = r[1].ToString();
            selected = r[2].ToString();
            lotusNotes = r["Lotus Notes"].ToString();
            if (lotusNotes == "False" && companyContactID.Trim().Length > 0)
            {
                frmContact f = new frmContact(companyContactID, jobID);
                f.ShowDialog();
                GetJobContact();
            }
        }

        private void grdContactView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.Ignore;
        }

        private void grdContactView_ColumnWidthChanged(object sender, ColumnEventArgs e)
        {
            bColumnWidthChanged = true;
        }
    }
}
