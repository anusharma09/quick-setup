using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCLightFixture.BusinessLayer
{
    class JobLightFixture
    {
        private string jobLightFixtureID;
        private string jobID;
        private string type;
        private string code;
        private string qtyRun;
        private string qtyBalance;
        private string length;
        private string lengthBalance;
        private string MFGR;
        private string description;
        private string leadTime;
        private string unitPrice;
        private string extension;
        private string balance;
        private string qtyRunRev00;
        private string lengthRev00;
        //
        public JobLightFixture()
        {
        }
        //
        public JobLightFixture(string jobLightFixtureID,
                                string jobID,
                                string type,
                                string code,
                                string qtyRun,
                                string qtyBalance,
                                string length,
                                string lengthBalance,
                                string MFGR,
                                string description,
                                string leadTime,
                                string unitPrice,
                                string extension,
                                string balance,
                                string qtyRunRev00,
                                string lengthRev00)
        {
            this.jobLightFixtureID              = jobLightFixtureID;
            this.jobID                          = jobID;
            this.type                           = "'" + type.Trim().Replace("'", "''") + "'";
            this.code                           = "'" + code.Trim().Replace("'", "''") + "'";
            this.qtyRun                         = String.IsNullOrEmpty(qtyRun) ? "null" : qtyRun;
            this.qtyBalance                     = String.IsNullOrEmpty(qtyBalance) ? "null" : qtyBalance;
            this.length                         = String.IsNullOrEmpty(length) ? "null" : length;
            this.lengthBalance                  = String.IsNullOrEmpty(lengthBalance) ? "null" : lengthBalance;
            this.MFGR                           = "'" + MFGR.Trim().Replace("'", "''") + "'";
            this.description                    = "'" + description.Trim().Replace("'", "''") + "'";
            this.leadTime                       = "'" + leadTime.Trim().Replace("'", "''") + "'";
            this.unitPrice                      = String.IsNullOrEmpty(unitPrice) ? "null" : unitPrice;
            this.extension                      = String.IsNullOrEmpty(extension) ? "null" : extension;
            this.balance                        = string.IsNullOrEmpty(balance) ? "null" : balance;
            this.qtyRunRev00                    = string.IsNullOrEmpty(qtyRunRev00) ? "null" : qtyRunRev00;
            this.lengthRev00                    = string.IsNullOrEmpty(lengthRev00) ? "null" : lengthRev00;

        }
        //
        public string JobLightFixtureID
        {
            get { return jobLightFixtureID; }
        }
        //
        public static DataSet GetJobLightFixturePullDown(string jobID)
        {

            string query = "";
            query = " SELECT " +
                    " JobLightFixtureID, " +
                    " Type, " +
                    " MFGR, " +
                    " Description, " +
                    " QtyRun AS [Qty Run], " +
                    " Length AS [Length] " +
                    " FROM tblJobLightFixture " +
                    " WHERE JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query,CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobLightFixture(string jobID)
        {

            string query = "";
            string query1 = "";
            query = " SELECT " + 
                    " JobLightFixtureID, " +
                    " Type, " +
                    " Code, " +
                    " QtyRunRev00 AS [Qty Run Rev 00], " +
                    " LengthRev00 AS [Length Rev 00], " +
                    " QtyRun AS [Qty Run], " +
                    " QtyBalance AS [Qty Bal], " +
                    " Length, " +
                    " LengthBalance AS [Length Bal], " +
                    " [dbo].[GetJobLightFixtureRevision] (JobLightFixtureID, '+') AS [Rev +], " +
                    " [dbo].[GetJobLightFixtureRevision] (JobLightFixtureID, '-') AS [Rev -], " +

                    " MFGR, " +
                    " Description, " +
                    " LeadTime AS [Lead Time], " +
                    " UnitPrice AS [Unit Price], " +
                    " Extension, " +
                    " Balance " +
                    " FROM tblJobLightFixture " +
                    " WHERE JobID = " + jobID + " ";

            query1 = " SELECT " +
	                 " d.JobLightFixtureID, " +
	                 " d.Quantity, " +
	                 " d.Length, " + 
                     " ReceivedDate AS [Received Date], " +
                     " ReceivedBy AS [Received By], " +
                     " Notes, " +
                     " PaidAmount AS [Paid Amount], " +
                     " InvoiceNumber AS [Invoice No] " +
                     " FROM tblJobLightFixtureDetail d " +
                     " INNER JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                     " WHERE f.JobID = " + jobID + " ";

            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobLightFixtureID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetLightFixtureItems(string jobLightFixtureID)
        {

            string query = "";

            query = " SELECT " +
                     " d.JobLightFixtureID, " +
                     " PONumber AS [PO Number], " +
                     " ReleaseNumber AS [Rel No], " +
                     " ReleaseDate AS [Rel Date], " +
                     " d.QtyRun AS [Qty Run], " +
                     " d.Length, " +
                     " EstimatedShipDate AS [Est Ship Date] " +
                     " FROM tblJobLightFixtureReleaseDetail d " +
                     " INNER JOIN tblJobLightFixtureRelease s ON d.JobLightFixtureReleaseID = s.JobLightFixtureReleaseID " +
                     " INNER JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                     " WHERE f.jobLightFixtureID = " + jobLightFixtureID + " ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetLightFixtureRevisionItems(string jobLightFixtureID)
        {

            string query = "";

            query = " SELECT " +
                     " d.JobLightFixtureID, " +
                     " RevisionNumber AS [Rev No], " +
                     " RevisionDate AS [Rev Date], " +
                     " d.QtyRun AS [Qty Run], " +
                     " d.Length, " +
                     " EstimatedShipDate AS [Est Ship Date] " +
                     " FROM tblJobLightFixtureRevisionDetail d " +
                     " INNER JOIN tblJobLightFixtureRevision s ON d.JobLightFixtureRevisionID = s.JobLightFixtureRevisionID " +
                     " INNER JOIN tblJobLightFixture f ON d.JobLightFixtureID = f.JobLightFixtureID " +
                     " WHERE f.jobLightFixtureID = " + jobLightFixtureID + " ";

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
        public static DataSet GetLightFixtureDetail(string jobLightFixtureID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixture " +
                           " WHERE JobLightFixtureID = " + jobLightFixtureID + " ";
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
        public static bool Remove(string jobLightFixtureID)
        {
            string query = "";

            
            try
            {

                query = "DELETE FROM tblJobLightFixtureRevisionDetail WHERE JobLightFixtureID = " + jobLightFixtureID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);


                query = "DELETE FROM tblJobLightFixtureReleaseDetail WHERE JobLightFixtureID = " + jobLightFixtureID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                query = "DELETE FROM tblJobLightFixtureDetail WHERE JobLightFixtureID = " + jobLightFixtureID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);


                query = "DELETE FROM tblJobLightFixture WHERE JobLightFixtureID = " + jobLightFixtureID;
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
            if (jobLightFixtureID == "" || jobLightFixtureID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLightFixture(" +
                    " JobID, " +
                    " Type, " +
                    " Code, " +
                    " QtyRunRev00, " +
                    " LengthRev00, " +
                    " QtyRun, " +
                    " QtyBalance, " +
                    " Length, " +
                    " LengthBalance, " +
                    " MFGR, " +
                    " Description, " +
                    " LeadTime, " +
                    " UnitPrice, " +
                    " Extension, " +
                    " Balance " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    type + ", " +
                    code + ", " +
                    qtyRunRev00 + ", " +
                    lengthRev00 + ", " +
                    qtyRun + ", " +
                    qtyBalance + ", " +
                    length + ", " +
                    lengthBalance + ", " +
                    MFGR + ", " +
                    description + ", " +
                    leadTime + ", " +
                    unitPrice + ", " +
                    extension + ", " +
                    balance + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobLightFixtureID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobLightFixture SET " +
                    " JobID             = " + jobID + ", " +
                    " Type              = " + type + ", " + 
                    " Code              = " + code + ", " +
                    " QtyRunRev00       = " + qtyRunRev00 + ", " +
                    " LengthRev00       = " + lengthRev00 + ", " +
                    " QtyRun            = " + qtyRun + ", " +
                    " QtyBalance        = " + qtyBalance + ", " +
                    " Length            = " + length + ", " +
                    " LengthBalance     = " + lengthBalance + ", " +
                    " MFGR              = " + MFGR + ", " +
                    " Description       = " + description + ", " +
                    " LeadTime          = " + leadTime + ", " +
                    " UnitPrice         = " + unitPrice + ", " +
                    " Extension         = " + extension + ", " +
                    " Balance           = " + balance + " " +
                    " WHERE JobLightFixtureID   = " + jobLightFixtureID;
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
