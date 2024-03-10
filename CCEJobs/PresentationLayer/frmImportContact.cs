using JCCBusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CCEJobs.PresentationLayer
{
    public partial class frmImportContact : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected List<ContactList> lstContact;
        private BindingSource contactSourceBinding = new BindingSource();
        private BindingSource duplicateContactSourceBinding = new BindingSource();
        private DataTable dtSelected = new DataTable();
        private DataTable dtToBeInserted = new DataTable();

        public frmImportContact ()
        {
            InitializeComponent();
        }
        //
        public frmImportContact ( List<ContactList> lstContact )
        {
            this.lstContact = lstContact;
            InitializeComponent();
        }
        //
        private void frmContact_Load ( object sender, EventArgs e )
        {
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowDefaultWaitForm("Showing Contacts", "Analyzing duplicate contacts ...");
                Cursor = Cursors.AppStarting;
                DataTable dtContacts = GlobalContacts.convertListTodataTable(lstContact);

                DataTable dtDuplicate = GlobalContacts.getDuplicateContacts(dtContacts);
                //get unique contacts that will always be imported
                DataTable dtUnique = GlobalContacts.getUniqueContacts(dtContacts);
                // check if contacts already exists in database
                DataTable dtExisting = GlobalContacts.getExistingContacts(dtUnique);

                //Get Contacts that are unique that doesnot exists in database.
                dtToBeInserted = GlobalContacts.getContactsNotInDatabase(dtUnique, dtExisting);
                contactSourceBinding.DataSource = dtToBeInserted;
                grdUniqueContacts.DataSource = contactSourceBinding;

                //Merge Duplicate and already existing in Database contacts
                dtDuplicate.Merge(dtExisting);
                duplicateContactSourceBinding.DataSource = dtDuplicate;
                grdDuplicateContacts.DataSource = duplicateContactSourceBinding;

                Opacity = 1;
                Cursor = Cursors.Default;
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseDefaultWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CCEApplication.ApplicationName);
            }
        }

        private void grdDuplicateContactsView_SelectionChanged ( object sender, DevExpress.Data.SelectionChangedEventArgs e )
        {
            int[] rowId = grdDuplicateContactsView.GetSelectedRows();
            dtSelected = dtToBeInserted.Clone();
            for (int i = 0; i < rowId.Length; i++)
            {
                DataRow row = dtSelected.NewRow();
                row = grdDuplicateContactsView.GetDataRow(rowId[i]);
                dtSelected.ImportRow(row);
            }
        }

        private void allButtons_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {

        }

        private void btnImport_ItemClick ( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to import contacts", CCEApplication.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                   /* if (dtSelected.Rows.Count > 0)
                    {
                        DataTable dtDup = GlobalContacts.getDuplicateContacts(dtSelected);
                        if (dtDup.Rows.Count > 0)
                        {
                            DialogResult selectedOption = MessageBox.Show("You have selected duplicate contacts with same name. Do you want to Insert the contacts with same name.", CCEApplication.ApplicationName, MessageBoxButtons.YesNoCancel);
                            if (selectedOption == DialogResult.Yes)
                            {

                            }
                            else if (selectedOption == DialogResult.No)
                            {

                            }
                            else
                            {
                            
                            }

                        }
                    }*/
                    // Insert Unique Contacts
                    foreach (DataRow row in dtToBeInserted.Rows)
                    {
                        GlobalContacts contacts = new GlobalContacts(row["FirstName"].ToString(),
                                                        row["LastName"].ToString(),
                                                        row["MiddleName"].ToString(),
                                                        row["JobTitle"].ToString(),
                                                        row["EmailAddress"].ToString(),
                                                        row["Company"].ToString(),
                                                        row["Category"].ToString(),
                                                        "",
                                                        row["MobilePhone"].ToString(),
                                                        row["Street"].ToString(),
                                                        row["City"].ToString(),
                                                        row["State"].ToString(),
                                                        row["PostalCode"].ToString(),
                                                        row["Country"].ToString(),
                                                        row["BusinessPhone"].ToString(),
                                                        row["Fax"].ToString(),
                                                        row["Extension"].ToString()
                                                    );
                        GlobalContacts.ContactId = "0";
                        contacts.SaveDetail();
                    }
                    // Insert duplicate Manually selected contacts
                    foreach (DataRow dataRow in dtSelected.Rows)
                    {
                        GlobalContacts contacts = new GlobalContacts(dataRow["FirstName"].ToString(),
                                                       dataRow["LastName"].ToString(),
                                                       dataRow["MiddleName"].ToString(),
                                                       dataRow["JobTitle"].ToString(),
                                                       dataRow["EmailAddress"].ToString(),
                                                       dataRow["Company"].ToString(),
                                                       dataRow["Category"].ToString(),
                                                       "",
                                                       dataRow["MobilePhone"].ToString(),
                                                       dataRow["Street"].ToString(),
                                                       dataRow["City"].ToString(),
                                                       dataRow["State"].ToString(),
                                                       dataRow["PostalCode"].ToString(),
                                                       dataRow["Country"].ToString(),
                                                       dataRow["BusinessPhone"].ToString(),
                                                       dataRow["Fax"].ToString(),
                                                       dataRow["Extension"].ToString()
                                                   );
                        contacts.Upsert();
                    }
                    MessageBox.Show("Contacts imported successfully.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}