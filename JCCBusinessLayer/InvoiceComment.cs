using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class InvoiceComment
    {
        private string jobInvoiceCommentID;
        private string jobInvoiceID;
        private string jobID;
        private string comment;
        private string lastUpdateDate;
        private string userID;

        public string JobInvoiceCommentID
        {
            get { return jobInvoiceCommentID; }
        }

        public InvoiceComment()
        {
        }
        public InvoiceComment(string jobInvoiceCommentID,
                        string jobInvoiceID,
                        string jobID,
                        string comment,
                        string lastUpdateDate,
                        string userID)
        {


            this.jobInvoiceCommentID = jobInvoiceCommentID;
            this.jobInvoiceID = jobInvoiceID;
            this.jobID = jobID;
            this.comment = comment.Trim().ToUpper().Replace("'", "''");
            this.lastUpdateDate = lastUpdateDate;
            this.userID = userID;
        }

        public bool Save()
        {
            if (jobInvoiceCommentID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobInvoiceComment(JobInvoiceID, JobID, Comment, LastUpdateDate, UserID) Values(" +
                    jobInvoiceID + ", " + jobID + ", '" + comment + "', '" + lastUpdateDate + "', '" + userID + "')" +
                    "Select @@IDENTITY ";
            try
            {
                jobInvoiceCommentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobInvoiceComment SET " +
                    " Comment                   = '" + comment + "', " +
                    " LastUpdateDate            = '" + lastUpdateDate + "', " +
                    " UserID                    = '" + userID + "' " +
                    " WHERE JobInvoiceCommentID  = " + jobInvoiceCommentID;
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
