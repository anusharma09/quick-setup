using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace Security.BusinessLayer
{
    class UserJob
    {
        private string userJobID;
        private string userID;
        private string jobNumber;
        private string invoiceApproval;
        private string readOnly;

        public string UserJobID
        {
            get { return userJobID; }
        }

        public UserJob()
        {
        }
        public UserJob(string userJobID,
                          string userID,
                          string jobNumber, 
                          string invoiceApproval,
                          string readOnly)
        {
            this.userJobID = userJobID;
            this.userID = userID;
            this.jobNumber = jobNumber.Trim().Replace("'", "''");
            this.invoiceApproval = invoiceApproval == "True" ? "1" : "0";
            this.readOnly = readOnly == "True" ? "1" : "0";
        }
        public static DataSet GetUserJob(string userID)
        {
            string query = "";

            query = " SELECT UserJobID, UserID, JobNumber [Job Number], InvoiceApproval As [Invoice Approval], ReadOnly AS [Read Only] " +
                    " FROM tblUserJob WHERE UserID =  " + userID;

            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Save()
        {
            if (userJobID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblUserJob(UserID, JobNumber, InvoiceApproval, ReadOnly) Values(" +
                    userID + ", '" + jobNumber + "', " + invoiceApproval + ", " + readOnly + ") " +
                    "Select @@IDENTITY ";
            try
            {
                userJobID = DataBaseUtil.ExecuteScalar(query, Security.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete(string userJobID)
        {
            string query = "";

            query = " DELETE FROM tblUserJob WHERE UserJobID = " + userJobID + " ";
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
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

            query = "Update tblUserJob  SET " +
                    " UserID                    = " + userID + ", " +
                    " JobNumber                 = '" + jobNumber + "', " +
                    " InvoiceApproval           = " + invoiceApproval + ", " +
                    " ReadOnly                  = " + readOnly + " " +
                    " WHERE UserJobID  = " + userJobID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
