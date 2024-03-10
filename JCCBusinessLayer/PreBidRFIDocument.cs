using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
namespace JCCBusinessLayer
{
    public class PreBidRFIDocument
    {
        private string opportunityRFIDocumentID;
        private string RFIID;
        private string document;
        private string email;
        //
        public PreBidRFIDocument ()
        {
        }
        //
        public PreBidRFIDocument ( string opportunityRFIDocumentID,
                                            string opportunityRFIID,
                                            string document,
                                            string email)
        {
            this.opportunityRFIDocumentID       = opportunityRFIDocumentID;
            this.RFIID               = opportunityRFIID;
            this.document               = "'" + document.Trim().Replace("'", "''") + "'";
            this.email                  = email == "True" ? "1" : "0";

        }
        //
        public string OpportunityRFIDocumentID
        {
            get { return opportunityRFIDocumentID; }
        }
        //
        public static DataSet GetDocuments(string RFIID)
        {

            string query = " SELECT *, ' ' AS Link " +
                           " FROM tblPreBidRFIDocument " +
                           " WHERE PreBidRFIID = " + RFIID + " ";
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
        public static DataSet GetDocumentsForEmail(string RFIID)
        {

            string query = " SELECT * " +
                           " FROM tblPreBidRFIDocument " +
                           " WHERE PreBidRFIID = " + RFIID + "  AND Email = 1 ";
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
        public static bool Remove(string rfiDocumentID)
        {
            string query = "";

            query = "DELETE FROM tblPreBidRFIDocument WHERE PreBidRFIDocumentID = " + rfiDocumentID;
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
            if (opportunityRFIDocumentID == "" || opportunityRFIDocumentID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblPreBidRFIDocument(" +
                    " PreBidRFIID, " +
                    " Document, " +
                    " Email " +
                    " ) VALUES ( " +
                    RFIID + ", " +
                    document + ", " +
                    email + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                opportunityRFIDocumentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblPreBidRFIDocument SET " +
                    " Document                          = " + document + ", " +
                    " Email                             = " + email + " " +
                    " WHERE PreBidRFIDocumentID            = " + opportunityRFIDocumentID;
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
