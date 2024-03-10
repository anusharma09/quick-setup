using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class MajorPODetail
    {
        private string jobMajorPODetailID;
        private string jobMajorPOID;
        private string revisionNumber;
        private string workDescription;
        private string amount;
        private string revisionDate;

        public string JobMajorPODetailID
        {
            get { return jobMajorPODetailID; }
        }
        //
        public string RevisionNumber
        {
            get { return revisionNumber; }
        }
        //
        public MajorPODetail()
        {
        }
        public MajorPODetail(string jobMajorPODetailID,
                       string jobMajorPOID,
                       string revisionNumber,
                       string workDescription,
                       string amount,
                       string revisionDate)
        {
            this.jobMajorPODetailID = jobMajorPODetailID;
            this.jobMajorPOID = String.IsNullOrEmpty(jobMajorPOID) ? "Null" : jobMajorPOID;
            this.revisionNumber = revisionNumber.Trim();
            this.workDescription = "'" + workDescription.Trim().Replace("'", "''") + "'";
            this.amount = String.IsNullOrEmpty(amount) ? "Null" : amount;
            this.revisionDate = String.IsNullOrEmpty(revisionDate) ? "Null" : "'" + revisionDate + "'";
        }
        //
        /* public static DataSet GetRFISheet(string jobRFIID)
         {
             string query = "";

             query = " SELECT " +
                     " Company = " +
                     " CASE c.LotusNotes " +
                     " WHEN 1 THEN cc.CompanyName " +
                     " ELSE dd.CompanyName " +
                     " End, " +
                     " CompanyTo = " +
                     " CASE c.LotusNotes " +
                     " WHEN 1 THEN  cc.FirstName + ' '  + cc.LastName " +
                     " ELSE dd.FirstName  + ' ' + dd.LastName " +
                     " End, " +
                     " RFISubject, " +
                     " JobRFINumber, " +
                     " RFIDate, " +
                     " JobNumber, " +
                     " JobName, " +
                     " CompanyFrom = " +
                     " CASE l.LotusNotes " +
                     " WHEN 1 THEN  mm.FirstName + ' '  + mm.LastName " +
                     " ELSE nn.FirstName  + ' ' + nn.LastName " +
                     " End, " +
                     " RFIText, " +
                     " DesignDetailRequired, " +
                     " DelayJob, " +
                     " DiscussedOnPhoneWith, " +
                     " PhoneDiscussionDate, " +
                     " AnsweredNeededBy, " +
                     " RFIResponse " +
                     " FROM tblJobRFI r " +
                     " LEFT Join tblJob j ON r.JobID = j.JobID " +
                     " LEFT JOIN tblJobContact c ON r.RFIToContactID = c.ContactID " +
                     " LEFT JOIN tblCompanyContact cc ON c.CompanyContactID = cc.CompanyContactID " +
                     " LEFT JOIN tblJobContactDetail dd ON c.CompanyContactID = dd.JobContactDetailID " +
                     " LEFT JOIN tblJobContact l ON r.RFIFromID = l.ContactID " +
                     " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                     " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " +
                     " WHERE r.JobRFIID =  " + jobRFIID + " ";

             try
             {
                 return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         } */
        //
        /* public static DataSet GetRFI(string jobRFIID)
         {
             string query = "";

             query = " SELECT * FROM tblJobRFI WHERE JobRFIID = " + jobRFIID + " ";

             try
             {
                 return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }*/
        //
        public static DataSet GetMajorPODetail(string jobMajorPOID)
        {
            string query = "";

            query = " SELECT " +
                    " * " +
                    " FROM tblJobMajorPODetail " +
                    " WHERE JobMajorPOID = " + jobMajorPOID + " ";
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
            if (jobMajorPODetailID == "" || jobMajorPODetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobMajorPODetail(" +
                    " JobMajorPOID, " +
                    " RevisionNumber, " +
                    " WorkDescription, " +
                    " Amount, " +
                    " RevisionDate) VALUES (" +
                    jobMajorPOID + ", " +
                   "'" + revisionNumber + "', " +
                    workDescription + ", " +
                    amount + ", " +
                    revisionDate + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobMajorPODetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                query = "SELECT RevisionNumber FROM tblJobMajorPODetail WHERE JobMajorPODetailID = " + jobMajorPODetailID + " ";

                revisionNumber = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0]["RevisionNumber"].ToString();
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool Update()
        {
            string query = "";

            query = "Update tblJobMajorPODetail SET " +
                    " JobMajorPOID          = " + jobMajorPOID + ", " +
                    " RevisionNumber        = '" + revisionNumber + "', " +
                    " WorkDescription       = " + workDescription + ", " +
                    " Amount                = " + amount + ", " +
                    " RevisionDate          = " + revisionDate + " " +
                    " WHERE JobMajorPODetailID  = " + jobMajorPODetailID;
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
        //
        public static void Delete(string jobMajorPODetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobMajorPODetail WHERE JobMajorPODetailID = " + jobMajorPODetailID + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
