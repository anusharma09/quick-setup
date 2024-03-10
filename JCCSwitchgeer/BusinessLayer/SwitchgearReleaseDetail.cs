using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCSwitchgear.BusinessLayer
{
    class SwitchgearReleaseDetail
    {
        private string jobSwitchgearReleaseDetailID;
        private string jobSwitchgearReleaseID;
        private string jobSwitchgearID;
        private string quantity;
        private string estimatedShipDate;
        private string notes;
        //
        public SwitchgearReleaseDetail()
        {
        }
        //
        public SwitchgearReleaseDetail(string jobSwitchgearReleaseDetailID,
                                            string jobSwitchgearReleaseID,
                                            string jobSwitchgearID,
                                            string quantity,
                                            string estimatedShipDate,
                                            string notes)
        {
            this.jobSwitchgearReleaseDetailID = jobSwitchgearReleaseDetailID;
            this.jobSwitchgearReleaseID = jobSwitchgearReleaseID;
            this.jobSwitchgearID = jobSwitchgearID;
            this.quantity = String.IsNullOrEmpty(quantity) ? "null" : quantity;
            this.estimatedShipDate = String.IsNullOrEmpty(estimatedShipDate) ? "null" : "'" + estimatedShipDate + "'";
            this.notes = "'" + notes.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobSwitchgearReleaseDetailID
        {
            get { return jobSwitchgearReleaseDetailID; }
        }
        //
        public static DataSet GetSwitchgearRelease(string jobSwitchgearReleaseID)
        {

            string query = " SELECT * " +
                           " FROM tblJobSwitchgearReleaseDetail " +
                           " WHERE JobSwitchgearReleaseID = " + jobSwitchgearReleaseID + " ";
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
        public static bool Remove(string jobSwitchgearReleaseDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobSwitchgearReleaseDetail WHERE JobSwitchgearReleaseDetailID = " + jobSwitchgearReleaseDetailID;
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
            if (jobSwitchgearReleaseDetailID == "" || jobSwitchgearReleaseDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSwitchgearReleaseDetail(" +
                    " JobSwitchgearReleaseID, " +
                    " JobSwitchgearID, " +
                    " Quantity, " +
                    " EstimatedShipDate,notes " +
                    " ) VALUES ( " +
                    jobSwitchgearReleaseID + ", " +
                    jobSwitchgearID + ", " +
                    quantity + ", " +
                     estimatedShipDate + ", " +
                    notes + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSwitchgearReleaseDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobSwitchgearReleaseDetail SET " +
                    " JobSwitchgearReleaseID        = " + jobSwitchgearReleaseID + ", " +
                    " JobSwitchgearID               = " + jobSwitchgearID + ", " +
                    " Quantity                      = " + quantity + ", " +
                    " EstimatedShipDate             = " + estimatedShipDate + ", " +
                    " Notes                         = " + notes + " " +
                    " WHERE JobSwitchgearReleaseDetailID   = " + jobSwitchgearReleaseDetailID;
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
