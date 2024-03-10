using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCSwitchgear.BusinessLayer
{
    class SwitchgearRevisionDetail
    {
        private string jobSwitchgearRevisionDetailID;
        private string jobSwitchgearRevisionID;
        private string jobSwitchgearID;
        private string quantity;
        private string estimatedShipDate;
        private string notes;
        //
        public SwitchgearRevisionDetail()
        {
        }
        //
        public SwitchgearRevisionDetail(string jobSwitchgearRevisionDetailID,
                                            string jobSwitchgearRevisionID,
                                            string jobSwitchgearID,
                                            string quantity,
                                            string estimatedShipDate,
                                            string notes)
        {
            this.jobSwitchgearRevisionDetailID = jobSwitchgearRevisionDetailID;
            this.jobSwitchgearRevisionID = jobSwitchgearRevisionID;
            this.jobSwitchgearID = jobSwitchgearID;
            this.quantity = String.IsNullOrEmpty(quantity) ? "null" : quantity;
            this.estimatedShipDate = String.IsNullOrEmpty(estimatedShipDate) ? "null" : "'" + estimatedShipDate + "'";
            this.notes = "'" + notes.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobSwitchgearRevisionDetailID
        {
            get { return jobSwitchgearRevisionDetailID; }
        }
        //
        public static DataSet GetSwitchgearRevision(string jobSwitchgearRevisionID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearRevisionDetail " +
                           " WHERE JobSwitchgearRevisionID = " + jobSwitchgearRevisionID + " ";
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
        public static bool Remove(string jobSwitchgearRevisionDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobSwitchgearRevisionDetail WHERE JobSwitchgearRevisionDetailID = " + jobSwitchgearRevisionDetailID;
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
            if (jobSwitchgearRevisionDetailID == "" || jobSwitchgearRevisionDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSwitchgearRevisionDetail(" +
                    " JobSwitchgearRevisionID, " +
                    " JobSwitchgearID, " +
                    " Quantity, " +
                    " EstimatedShipDate,notes " +
                    " ) VALUES ( " +
                    jobSwitchgearRevisionID + ", " +
                    jobSwitchgearID + ", " +
                    quantity + ", " +
                    estimatedShipDate + ", " +
                    notes + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSwitchgearRevisionDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSwitchgearRevisionDetail SET " +
                    " JobSwitchgearRevisionID        = " + jobSwitchgearRevisionID + ", " +
                    " JobSwitchgearID               = " + jobSwitchgearID + ", " +
                    " Quantity                      = " + quantity + ", " +
                    " EstimatedShipDate             = " + estimatedShipDate + ", " +
                    " Notes                         = " + notes + " " +
                    " WHERE JobSwitchgearRevisionDetailID   = " + jobSwitchgearRevisionDetailID;
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
