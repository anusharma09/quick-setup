using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
namespace JCCSwitchgear.BusinessLayer
{
    class Switchgear
    {
        private string jobSwitchgearID;
        private string jobID;
        private string pageNo;
        private string itemNo;
        private string designation;
        private string description;
        private string quantity;
        private string unitPrice;
        private string extension;
        private string balance;
        private string quantityReceived;
        private string quantityBalance;
        private string quantityRev00;
        //
        public Switchgear()
        {
        }
        //
        public Switchgear(string jobSwitchgearID,
                          string jobID,
                          string pageNo,
                          string itemNo,
                          string designation,
                          string description,
                          string quantity,
                          string unitPrice,
                          string extension,
                          string balance,
                          string quantityReceived,
                          string quantityBalance,
                          string quantityRev00)
        {
            this.jobSwitchgearID       = jobSwitchgearID;
            this.jobID                 = jobID;
            this.pageNo                = "'" + pageNo.Trim().Replace("'", "''") + "'";
            this.itemNo                = "'" + itemNo.Trim().Replace("'","''") + "'";
            this.designation           = "'" + designation.Trim().Replace("'", "''") + "'";
            this.description           = "'" + description.Trim().Replace("'", "''") + "'";
            this.quantity              = String.IsNullOrEmpty(quantity) ? "null" : quantity;
            this.unitPrice             = String.IsNullOrEmpty(unitPrice) ? "null" : unitPrice;
            this.extension             = String.IsNullOrEmpty(extension) ? "null" : extension;
            this.balance               = String.IsNullOrEmpty(balance) ? "null" : balance;
            this.quantityReceived      = String.IsNullOrEmpty(quantityReceived) ? "null" : quantityReceived;
            this.quantityBalance       = String.IsNullOrEmpty(quantityBalance) ? "null" : quantityBalance;
            this.quantityRev00         = String.IsNullOrEmpty(quantityRev00) ? "null" : quantityRev00;

        }
        //
        public string JobSwitchgearID
        {
            get { return jobSwitchgearID; }
        }
        //
        public static DataSet GetSwitchgear(string jobSwitchgearID)
        {

            string query = "";

            query = " SELECT * " +
                    " FROM tblJobSwitchgear s " +
                    " WHERE s.JobSwitchgearID = " + jobSwitchgearID + " ";

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
        public static DataSet GetSwitchgearPullDown(string jobID)
        {

            string query = "";
            query = " SELECT " +
                    " JobSwitchgearID, " +
                    " ItemNo, " +
                    " Description, " +
                    "Quantity AS [Quantity] " +
                    " FROM tblJobSwitchgear " +
                    " WHERE JobID = " + jobID + " ";

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
        public static DataSet GetJobSwitchgear(string jobID)
        {

            string query = "";
            string query1 = "";
            query = " SELECT " +
                    " s.JobSwitchgearID, " +
                    " PageNo AS [Page No],  " +
                    " ItemNo   AS [Item No], " +
                    " Designation, " +
                    " Description, " +
                    " QuantityRev00 AS [Quantity Rev 00], " +
                    " Quantity, " +
                    " UnitPrice AS [Unit Price], " +
                    " Extension, " +
                    " Balance, " +
                    " QuantityReceived AS [Qty Rec], " +
                    " QuantityBalance AS [Qty Bal], " +
                    " [dbo].[GetJobSwitchgearRevision] (s.JobSwitchgearID, '+') AS [Rev +], " +
                    " [dbo].[GetJobSwitchgearRevision] (s.JobSwitchgearID, '-') AS [Rev -] " +
                    " FROM tblJobSwitchgear s " +
                    " WHERE s.JobID = " + jobID + " ";

               query1 = " SELECT " +
                  " d.JobSwitchgearID, " +
                  " d.Quantity, " +
                  " ReceivedDate AS [Received Date], " +
                  " ReceivedBy AS [Received By], " +
                  " Notes, " +
                  " d.PaidAmount AS [Paid Amount], " +
                  " InvoiceNumber  AS [Invoice Number] " +
                  " FROM tblJobSwitchgearDetail d " +
                  " INNER JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                  " WHERE f.JobID = " + jobID + " ";


            try
            {
                return DataBaseUtil.ExecuteDatasetRelation(query, query1, "", "JobSwitchgearID", CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetSwitchgearItems(string jobSwitchgearID)
        {

            string query = "";

            query = " SELECT " +
                     " d.JobSwitchgearID, " +
                     " PONumber AS [PO Number], " +
                     " ReleaseNumber AS [Rel No], " +
                     " ReleaseDate AS [Rel Date], " +
                     " d.Quantity, " +
                     " EstimatedShipDate AS [Est Ship Date] " +
                     " FROM tblJobSwitchgearReleaseDetail d " +
                     " INNER JOIN tblJobSwitchgearRelease s ON d.JobSwitchgearReleaseID = s.JobSwitchgearReleaseID " +
                     " INNER JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                     " WHERE f.jobSwitchgearID = " + jobSwitchgearID + " ";

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
        public static DataSet GetSwitchgearRevisionItems(string jobSwitchgearID)
        {

            string query = "";

            query = " SELECT " +
                     " d.JobSwitchgearID, " +
                     " RevisionNumber AS [Rev No], " +
                     " RevisionDate AS [Rev Date], " +
                     " d.Quantity, " +
                     " EstimatedShipDate AS [Est Ship Date] " +
                     " FROM tblJobSwitchgearRevisionDetail d " +
                     " INNER JOIN tblJobSwitchgearRevision s ON d.JobSwitchgearRevisionID = s.JobSwitchgearRevisionID " +
                     " INNER JOIN tblJobSwitchgear f ON d.JobSwitchgearID = f.JobSwitchgearID " +
                     " WHERE f.jobSwitchgearID = " + jobSwitchgearID + " ";

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
        public static bool Remove(string jobSwitchgearID)
        {
            string query = "";

            try
            {
                query = "DELETE FROM tblJobSwitchgearRevisionDetail WHERE JobSwitchgearID = " + jobSwitchgearID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);


                query = "DELETE FROM tblJobSwitchgearReleaseDetail WHERE JobSwitchgearID = " + jobSwitchgearID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);

                query = "DELETE FROM tblJobSwitchGearDetail WHERE JobSwitchgearID = " + jobSwitchgearID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);


                query = "DELETE FROM tblJobSwitchGear WHERE JobSwitchgearID = " + jobSwitchgearID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                
;
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
            if (jobSwitchgearID == "" || jobSwitchgearID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSwitchgear(" +
                    " JobID, " +
                    " pageNo, " +
                    " ItemNo, " +
                    " Designation, " +
                    " Description, " +
                    " QuantityRev00, " +
                    " Quantity, " +
                    " UnitPrice, " +
                    " Extension, " +
                    " Balance,  " +
                    " QuantityReceived, " +
                    " QuantityBalance " +
                    " ) VALUES ( " +
                    jobID + ", " +
                    pageNo + ", " +
                    itemNo + ", " +
                    designation + ", " +
                    description + ", " +
                    quantityRev00 + ", " +
                    quantity + ", " +
                    unitPrice + ", " +
                    extension + ", " +
                    balance + ", " +
                    quantityReceived + ", " + 
                    quantityBalance + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSwitchgearID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSwitchgear SET " +
                    " JobID             = " + jobID + ", " +
                    " pageNo            = " + pageNo + ", " +
                    " ItemNo            = " + itemNo + ", " +
                    " Designation       = " + designation + ", " +
                    " Description       = " + description + ", " +
                    " QuantityRev00     = " + quantityRev00 + ", " +
                    " Quantity          = " + quantity + ", " +
                    " UnitPrice         = " + unitPrice + ", " +
                    " Extension         = " + extension + ", " +
                    " Balance           = " + balance + ", " +
                    " QuantityReceived  = " + quantityReceived + ", " +
                    " QuantityBalance   = " + quantityBalance + " " +
                    " WHERE JobSwitchgearID        = " + jobSwitchgearID;
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
