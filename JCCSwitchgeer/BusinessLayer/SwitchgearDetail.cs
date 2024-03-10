using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
namespace JCCSwitchgear.BusinessLayer
{
    class SwitchgearDetail
    {
        private string jobSwitchgearDetailID;
        private string jobSwitchgearID;
        private string quantity;
        private string paidAmount;
        private string receivedDate;
        private string receivedBy;
        private string notes;
        private string invoiceNumber;
        //
        public SwitchgearDetail()
        {
        }
        //
        public SwitchgearDetail(string jobSwitchgearDetailID,
                                string jobSwitchgearID,
                                string quantity,
                                string paidAmount,
                                string receivedDate,
                                string receivedBy,
                                string notes,
                                string invoiceNumber)
        {
            this.jobSwitchgearDetailID          = jobSwitchgearDetailID;
            this.jobSwitchgearID                = jobSwitchgearID;
            this.quantity                       = String.IsNullOrEmpty(quantity) ? "null" : quantity;
            this.paidAmount                     = String.IsNullOrEmpty(paidAmount) ? "null" : paidAmount;
            this.receivedDate                   = String.IsNullOrEmpty(receivedDate) ? "null" : "'" + receivedDate + "'";
            this.receivedBy                     = "'" + receivedBy.Trim().Replace("'", "''") + "'";
            this.notes                          = "'" + notes.Trim().Replace("'", "''") + "'";
            this.invoiceNumber                  = "'" + invoiceNumber.Replace("'", "''") + "'";
        }
        //
        public string JobSwitchgearDetailID
        {
            get { return jobSwitchgearDetailID; }
        }
        //
        public static DataSet GetSwitchgearDetail(string jobSwitchgearID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearDetail " +
                           " WHERE JobSwitchgearID = " + jobSwitchgearID + " ";
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
        public static bool Remove(string jobSwitchgearDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobSwitchgearDetail WHERE JobSwitchgearDetailID = " + jobSwitchgearDetailID;
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
            if (jobSwitchgearDetailID == "" || jobSwitchgearDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSwitchgearDetail(" +
                    " JobSwitchgearID, " +
                    " Quantity, " +
                    " PaidAmount, " +
                    " InvoiceNumber, " +
                    " ReceivedDate, " +
                    " ReceivedBy, " +
                    " Notes " +
                    " ) VALUES ( " +
                    jobSwitchgearID + ", " +
                    quantity + ", " +
                    paidAmount + ", " +
                    invoiceNumber + ", " +
                    receivedDate + ", " +
                    receivedBy + ", " +
                    notes + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSwitchgearDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSwitchgearDetail SET " +
                    " JobSwitchgearID   = " + jobSwitchgearID + ", " +
                    " Quantity          = " + quantity + ", " + 
                    " PaidAmount        = " + paidAmount + ", " +
                    " InvoiceNumber     = " + invoiceNumber + ", " +
                    " ReceivedDate      = " + receivedDate + ", " +
                    " ReceivedBy        = " + receivedBy + ", " +
                    " Notes             = " + notes + " " +
                    " WHERE JobSwitchgearDetailID        = " + jobSwitchgearDetailID;
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
