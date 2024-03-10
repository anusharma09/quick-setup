using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
namespace JCCBusinessLayer
{
    public class JobRFIDocument
    {
        private string jobRFIDocumentID;
        private string jobRFIID;
        private string document;
        private string email;
        //
        public JobRFIDocument()
        {
        }
        //
        public JobRFIDocument(string jobRFIDocumentID,
                                            string jobRFIID,
                                            string document,
                                            string email)
        {
            this.jobRFIDocumentID       = jobRFIDocumentID;
            this.jobRFIID               = jobRFIID;
            this.document               = "'" + document.Trim().Replace("'", "''") + "'";
            this.email                  = email == "True" ? "1" : "0";

        }
        //
        public string JobRFIDocumentID
        {
            get { return jobRFIDocumentID; }
        }
        //
        public static DataSet GetDocuments(string jobRFIID)
        {

            string query = " SELECT *, ' ' AS Link " +
                           " FROM tblJobRFIDocument " +
                           " WHERE JobRFIID = " + jobRFIID + " ";
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
        public static DataSet GetDocumentsForEmail(string jobRFIID)
        {

            string query = " SELECT * " +
                           " FROM tblJobRFIDocument " +
                           " WHERE JobRFIID = " + jobRFIID + "  AND Email = 1 ";
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
        public static bool Remove(string jobRFIDocumentID)
        {
            string query = "";

            query = "DELETE FROM tblJobRFIDocument WHERE JobRFIDocumentID = " + jobRFIDocumentID;
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
        public bool Save()
        {
            if (jobRFIDocumentID == "" || jobRFIDocumentID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobRFIDocument(" +
                    " JobRFIID, " +
                    " Document, " +
                    " Email " +
                    " ) VALUES ( " +
                    jobRFIID + ", " +
                    document + ", " +
                    email + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobRFIDocumentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobRFIDocument SET " +
                    " Document                          = " + document + ", " +
                    " Email                             = " + email + " " +
                    " WHERE JobRFIDocumentID            = " + jobRFIDocumentID;
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
