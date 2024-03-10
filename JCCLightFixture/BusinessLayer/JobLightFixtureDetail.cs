using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
namespace JCCLightFixture.BusinessLayer
{
    class JobLightFixtureDetail
    {
        private string jobLightFixtureDetailID;
        private string jobLightFixtureID;
        private string quantity;
        private string length;
        private string paidAmount;
        private string receivedDate;
        private string receivedBy;
        private string notes;
        private string invoiceNumber;
        //
        public JobLightFixtureDetail()
        {
        }
        //
        public JobLightFixtureDetail(string jobLightFixtureDetailID,
                                string jobLightFixtureID,
                                string quantity,
                                string length,
                                string paidAmount,
                                string receivedDate,
                                string receivedBy,
                                string notes,
                                string invoiceNumber)
        {
            this.jobLightFixtureDetailID        = jobLightFixtureDetailID;
            this.jobLightFixtureID              = jobLightFixtureID;
            this.quantity                       = String.IsNullOrEmpty(quantity) ? "null" : quantity;
            this.length                         = String.IsNullOrEmpty(length) ? "null" : length;
            this.paidAmount                     = String.IsNullOrEmpty(paidAmount) ? "null" : paidAmount;
            this.receivedDate                   = String.IsNullOrEmpty(receivedDate) ? "null" : "'" + receivedDate + "'";
            this.receivedBy                     = "'" + receivedBy.Trim().Replace("'", "''") + "'";
            this.notes                          = "'" + notes.Trim().Replace("'", "''") + "'";
            this.invoiceNumber                  = "'" + invoiceNumber.Replace("'", "''") + "'";
        }
        //
        public string JobLightFixtureDetailID
        {
            get { return jobLightFixtureDetailID; }
        }
        //
        public static DataSet GetLightFixtureDetail(string jobLightFixtureID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureDetail " +
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
        public static bool Remove(string jobLightFixtureDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobLightFixtureDetail WHERE JobLightFixtureDetailID = " + jobLightFixtureDetailID;
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
            if (jobLightFixtureDetailID == "" || jobLightFixtureDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLightFixtureDetail(" +
                    " JobLightFixtureID, " +
                    " Quantity, " +
                    " Length, " +
                    " PaidAmount, " +
                    " InvoiceNumber, " +
                    " ReceivedDate, " +
                    " ReceivedBy, " +
                    " Notes " +
                    " ) VALUES ( " +
                    jobLightFixtureID + ", " +
                    quantity + ", " +
                    length + ", " +
                    paidAmount + ", " +
                    invoiceNumber + ", " +
                    receivedDate + ", " +
                    receivedBy + ", " +
                    notes + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobLightFixtureDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobLightFixtureDetail SET " +
                    " JobLightFixtureID = " + jobLightFixtureID + ", " +
                    " Quantity          = " + quantity + ", " + 
                    " Length            = " + length + ", " +
                    " PaidAmount        = " + paidAmount + ", " +
                    " InvoiceNumber     = " + invoiceNumber + ", " +
                    " ReceivedDate      = " + receivedDate + ", " +
                    " ReceivedBy        = " + receivedBy + ", " +
                    " Notes             = " + notes + " " +
                    " WHERE JobLightFixtureDetailID        = " + jobLightFixtureDetailID;
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
