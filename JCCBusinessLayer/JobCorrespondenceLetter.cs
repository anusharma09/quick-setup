using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobCorrespondenceLetter
    {
        private string jobCorrespondenceLetterID;
        private string jobID;
        private string contactID;
        private string from;
        private string correspondenceLetterDate;
        private string correspondenceLetterNumber;
        private string correspondenceLetterDescription;
        private string correspondenceLetterNote;
        private string costImpact;
        private string subject;
        private string title;
        //
        public string JobCorrespondenceLetterID
        {
            get { return jobCorrespondenceLetterID; }
        }
        //
        public JobCorrespondenceLetter()
        {
        }
        public JobCorrespondenceLetter(string jobCorrespondenceLetterID,
                       string jobID,
                       string contactID,
                       string from,
                       string correspondenceLetterDate,
                       string correspondenceLetterNumber,
                       string correspondenceLetterDescription,
                       string correspondenceLetterNote,
                       string costImpact,
                       string subject,
                       string title)
        {
            this.jobCorrespondenceLetterID = jobCorrespondenceLetterID;
            this.jobID = String.IsNullOrEmpty(jobID) ? "Null" : jobID;
            this.contactID = String.IsNullOrEmpty(contactID) ? "Null" : contactID;
            this.from = "'" + from.Trim().Replace("'","''") + "'";
            this.correspondenceLetterDate = String.IsNullOrEmpty(correspondenceLetterDate) ? "Null" : "'" + correspondenceLetterDate + "'";
            this.correspondenceLetterNumber = "'" + correspondenceLetterNumber.Trim().Replace("'", "''") + "'";
            this.correspondenceLetterDescription = "'" + correspondenceLetterDescription.Trim().Replace("'", "''") + "'";
            this.correspondenceLetterNote = "'" + correspondenceLetterNote.Trim().Replace("'", "''") + "'";
            this.costImpact = costImpact;
            this.subject = "'" + subject.Trim().Replace("'", "''") + "'";
            this.title = "'" + title.Trim().Replace("'", "''") + "'";

        }
        //
        public static DataSet GetJobCorrespondenceLetterList(string jobID)
        {
            string query = "";

            if (Contact.CheckIsJobNew(Convert.ToInt32(jobID)))
            {
                query = " SELECT " +
                                   " JobCorrespondenceLetterID, " +
                                   " t.JobID," +
                                   " CorrespondenceLetterDate AS [Date], " +
                                   " [From], " +
                                   " Contact = " +
                                   "   CASE LotusNotes " +
                                   "   WHEN 1 THEN ISNULL(gc.FirstName, '') + ' ' + ISNULL(gc.LastName, '') + ' at: '  + ISNULL(gc.PhoneNumber, '') " +
                                   "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') + ' at: '  + ISNULL(d.PhoneNumber,'') " +
                                   " END, " +
                                   " Company = " +
                                   "   CASE LotusNotes " +
                                   "   WHEN 1 THEN ISNULL(gc.CompanyName, '') " +
                                   "   ELSE ISNULL(d.CompanyName, '') " +
                                   " END, " +
                                   " CorrespondenceLetterNumber AS [Number], " +
                                   " CorrespondenceLetterDescription AS [Description], " +
                                   " [Cost Impact]  = " +
                                   " CASE CostImpact " +
                                   " WHEN 0 THEN 'No' " +
                                   " WHEN 1 THEN 'Yes' " +
                                   " ELSE 'Free Format' " +
                                   " END, " +
                                   " Subject = " +
                                   " CASE CostImpact " +
                                   " WHEN 0 THEN 'No Effect Pending' " +
                                   " WHEN 1 THEN 'Effect Pending' " +
                                   " ELSE Subject " +
                                   " END " +
                                   " FROM tblJobCorrespondenceLetter t  " +
                                   " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                                   " LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID  " +
                                   //" LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                                   " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +

                                   " WHERE t.JobID = " + jobID + " ";
            }

            else
            {
                query = " SELECT " +
                    " JobCorrespondenceLetterID, " +
                    " t.JobID," +
                    " CorrespondenceLetterDate AS [Date], " +
                    " [From], " +
                    " Contact = " +
                    "   CASE LotusNotes " +
                    "   WHEN 1 THEN ISNULL(c.FirstName, '') + ' ' + ISNULL(c.LastName, '') + ' at: '  + ISNULL(c.PhoneNumber, '') " +
                    "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') + ' at: '  + ISNULL(d.PhoneNumber,'') " +
                    " END, " +
                    " Company = " +
                    "   CASE LotusNotes " +
                    "   WHEN 1 THEN ISNULL(c.CompanyName, '') " +
                    "   ELSE ISNULL(d.CompanyName, '') " +
                    " END, " +
                    " CorrespondenceLetterNumber AS [Number], " +
                    " CorrespondenceLetterDescription AS [Description], " +
                    " [Cost Impact]  = " +
                    " CASE CostImpact " +
                    " WHEN 0 THEN 'No' " +
                    " WHEN 1 THEN 'Yes' " +
                    " ELSE 'Free Format' " +
                    " END, " +
                    " Subject = " +
                    " CASE CostImpact " +
                    " WHEN 0 THEN 'No Effect Pending' " +
                    " WHEN 1 THEN 'Effect Pending' " +
                    " ELSE Subject " +
                    " END " +
                    " FROM tblJobCorrespondenceLetter t  " +
                    " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                    " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +

                    " WHERE t.JobID = " + jobID + " ";
            }
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetCorrespondenceLetter(string jobCorrespondenceLetterID)
        {
            string query = "";

            query = " SELECT Distinct " +
                    " JobName, " +
                    " JobNumber, " +
                    " Att =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.FirstName, '') + ' ' + ISNULL(gc.LastName, '') " +
                    "   ELSE ISNULL(d.FirstName, '') + ' ' + ISNULL(d.LastName, '') " +
                    " END, " +
                    " CompanyName = " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.CompanyName, '') " +
                    "   ELSE ISNULL(d.CompanyName, '')  " +
                    " END, " +
                    "  CompanyAddress =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.OfficeStreetAddress, '') " +
                    "   ELSE ISNULL(d.OfficeStreetAddress, '')  " +
                    " END, " +
                    "   CompanyCityStateZip =  " +
                    "   CASE jc.LotusNotes  " +
                    "   WHEN 1 THEN ISNULL(gc.OfficeCity, '') + ', ' + ISNULL(gc.OfficeState, '') + ' ' + ISNULL(gc.OfficeZip, '') " +
                    "   ELSE ISNULL(d.OfficeCity, '') + ', ' + ISNULL(d.OfficeState, '') + ' ' + ISNULL(d.OfficeZip, '') " +
                    " END, " +
                    "  [From], " +
                    " t.*, " +
                    " t.Title " +
                    " FROM tblJobCorrespondenceLetter t " +
                    " LEFT JOIN tblJob j ON t.JobID = j.JobID " +
                    " LEFT JOIN  tblJobContact jc ON t.ContactID = jc.ContactID " +
                    " LEFT JOIN tblGlobalContact gc ON jc.CompanyContactID = gc.GlobalContactID  " +
                    " LEFT JOIN tblCompanyContact c ON jc.CompanyContactID = c.CompanyContactID " +
                    " LEFT JOIN tblJobContactDetail d ON jc.CompanyContactID = d.JobContactDetailID " +
                " WHERE t.JobCorrespondenceLetterID = " + jobCorrespondenceLetterID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobCorrespondenceLetter(string jobCorrespondenceLetterID)
        {
            string query = "";

            query = " SELECT * " +
                    " FROM tblJobCorrespondenceLetter  " +
                    " WHERE JobCorrespondenceLetterID = " + jobCorrespondenceLetterID + " ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobCorrespondenceLetterID == "" || jobCorrespondenceLetterID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobCorrespondenceLetter(" +
                    " JobID, " +
                    " ContactID, " +
                    " [From], " +
                    " CorrespondenceLetterDate, " +
                    " CorrespondenceLetterNumber, " +
                    " CorrespondenceLetterDescription, " +
                    " CostImpact, " +
                    " Subject, " +
                    " Title, " +
                    " CorrespondenceLetterNote) VALUES (" +
                    jobID + ", " +
                    contactID + ", " +
                    from + ", " +
                    correspondenceLetterDate + ", " +
                    correspondenceLetterNumber + ", " +
                    correspondenceLetterDescription + ", " +
                    costImpact + ", " +
                    subject + ", " +
                    title + ", " +
                    correspondenceLetterNote + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobCorrespondenceLetterID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private bool Update()
        {
            string query = "";

            query = "Update tblJobCorrespondenceLetter SET " +
                    " JobID                             = " + jobID + ", " +
                    " ContactID                         = " + contactID + ", " +
                    " [FROM]                            = " + from + ", " +
                    " CorrespondenceLetterDate          = " + correspondenceLetterDate + ", " +
                    " CorrespondenceLetterNumber        = " + correspondenceLetterNumber + ", "  +
                    " CorrespondenceLetterDescription   = " + correspondenceLetterDescription + ", " +
                    " CostImpact                        = " + costImpact + ", " +
                    " Subject                           = " + subject + ", " +
                    " Title                             = " + title + ", " +
                    " CorrespondenceLetterNote          = " + correspondenceLetterNote + " " +
                    " WHERE JobCorrespondenceLetterID  = " + jobCorrespondenceLetterID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Remove(string jobCorrespondenceLetterID)
        {
            string query = "";

            query = "DELETE FROM tblJobCorrespondenceLetter  WHERE JobCorrespondenceLetterID  = " + jobCorrespondenceLetterID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}
