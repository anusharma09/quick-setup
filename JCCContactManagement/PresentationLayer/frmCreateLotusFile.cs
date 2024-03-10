using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JCCContactManagement.BusinessLayer;



namespace JCCContactManagement.PresentationLayer
{
    public partial class frmCreateLotusFile : Form
    {
        public frmCreateLotusFile()
        {
            InitializeComponent();
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text.Trim();
            string contact = "";
            DataTable t;

            if (fileName.Trim().Length == 0)
            {
                MessageBox.Show("Please enter File Name");
                return;
            }

            FileStream fs = null;

            try
            {
                this.Cursor = Cursors.AppStarting;
                using(fs = File.Create(@fileName));
                using (StreamWriter sw = new StreamWriter(@fileName))
                {
                    t = LotusNotes.GetLotusContacts();
                    foreach (DataRow r in t.Rows)
                    {
                        contact = "" +
                            "$AddressFormat:  1 " + "\r\n" +
                            "$NameFormat:  1 " + "\r\n" +
                            "$BusinessAddressFormat:  1" + "\r\n" +
                            "$PersonalAddressFormat:  1" + "\r\n" +
                            "$PreviewFormat:  1" + "\r\n" +
                            "FirstName:  " + r["CMContactFirstName"].ToString() + "\r\n" +
                            "MiddleInitial: " + r["CMContactInitial"].ToString() + "\r\n" +
                            "LastName:  " + r["CMContactLastName"].ToString() + "\r\n" +
                            "Title:  " + r["CMTitleDescription"].ToString() + "\r\n" +
                            "Suffix:  " + r["CMContactSalutation"].ToString() + "\r\n" +
                            "MailAddress:  " + r["CMContactEmail"].ToString() + "\r\n" +
                            "CompanyName:  " + r["CMCompanyName"].ToString() + "\r\n" +
                            "JobTitle:  " + r["CMTitleDescription"].ToString() + "\r\n" +
                            "OfficeStreetAddress:  " + r["CMContactAddress"].ToString() + "\r\n" +
                            "OfficeCity:  " + r["CMContactCity"].ToString() + "\r\n" +
                            "OfficeState:  " + r["CMContactState"].ToString() + "\r\n" +
                            "OfficeZIP:  " + r["CMContactZip"].ToString() + "\r\n" +
                            "OfficePhoneNumber:  " + r["CMContactPhone"].ToString() + "\r\n" +
                            "OfficeFAXPhoneNumber:  " + r["CMContactFax"].ToString() + "\r\n" +
                            "CellPhoneNumber:  " + r["CMContactMobile"].ToString() + "\r\n" +
                            //"FullName:  " + r["CMContact"].ToString() + "\r\n" +
                            "NameDisplayPref:  2" + "\r\n" + "\r\n" + "\f" + "\r\n";
                        sw.Write(contact);
                        sw.Flush();
                    }
                    sw.Close();
                    fs.Close();
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("File creation is completed!", CCEApplication.ApplicationName);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
    }
}