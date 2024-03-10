using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobSubmittalDetail
    {
        private string jobSubmittalDetailID;
        private string jobSubmittalID;
        private string revisionNumber;
        private string jobSubmittalStatusID;
        private string submittedDate;
        private string receivedDate;
        private string note;
        //
        public string JobSubmittalDetailID
        {
            get { return jobSubmittalDetailID; }
        }
        //
        public string RevisionNumber
        {
            get { return revisionNumber; }
        }
        //
        public JobSubmittalDetail()
        {
        }
        public JobSubmittalDetail(string jobSubmittalDetailID,
                        string jobSubmittalID,
                        string revisionNumber,
                        string jobSubmittalStatusID,
                        string submittedDate,
                        string receivedDate,
                        string note)
        {
            this.jobSubmittalDetailID = jobSubmittalDetailID;
            this.jobSubmittalID = String.IsNullOrEmpty(jobSubmittalID) ? "Null" : jobSubmittalID;
            this.revisionNumber = string.IsNullOrEmpty(revisionNumber) ? "Null" : revisionNumber;
            this.jobSubmittalStatusID = String.IsNullOrEmpty(jobSubmittalStatusID) ? "Null" : jobSubmittalStatusID;
            this.submittedDate = String.IsNullOrEmpty(submittedDate) ? "Null" : "'" + submittedDate + "'";
            this.receivedDate = String.IsNullOrEmpty(receivedDate) ? "Null" : "'" + receivedDate + "'";
            this.note = "'" + note.Trim().Replace("'", "''") + "'";
        }
        //
        public static DataSet GetSubmittalDetail(string jobSubmittalID)
        {
            string query = "";

            query = " SELECT * FROM tblJobSubmittalDetail " +
                    " WHERE JobSubmittalID = " + jobSubmittalID + " ";
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
            if (jobSubmittalDetailID == "" || jobSubmittalDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSubmittalDetail(" +
                    " JobSubmittalID, " +
                    " RevisionNumber, " +
                    " JobSubmittalStatusID, " +
                    " SubmittedDate, " +
                    " ReceivedDate, " +
                    " Note) VALUES (" +
                    jobSubmittalID + ", " +
                    revisionNumber + ", " +
                    jobSubmittalStatusID + ", " +
                    submittedDate + ", " +
                    receivedDate + ", " +
                    note + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobSubmittalDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();

                DataTable t = DataBaseUtil.ExecuteDataset("SELECT RevisionNumber FROM tblJobSubmittalDetail WHERE JobSubmittalDetailID = " + jobSubmittalDetailID + " ",
                                CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    revisionNumber = t.Rows[0][0].ToString();
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

            query = "Update tblJobSubmittalDetail SET " +
                    " JobSubmittalID            = " + jobSubmittalID + ", " +
                    " RevisionNumber            = " + revisionNumber + ", " +
                    " JobSubmittalStatusID      = " + jobSubmittalStatusID + ", " +
                    " SubmittedDate             = " + submittedDate + ", " +
                    " ReceivedDate              = " + receivedDate + ", " +
                    " Note                      = " + note + " " +
                    " WHERE JobSubmittalDetailID  = " + jobSubmittalDetailID;
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
        public static void Delete(string jobSubmittalDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobSubmittalDetail WHERE JobSubmittalDetailID = " + jobSubmittalDetailID + " ";
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
