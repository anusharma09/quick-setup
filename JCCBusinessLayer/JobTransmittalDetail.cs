using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class JobTransmittalDetail
    {
        private string jobTransmittalDetailID;
        private string jobTransmittalID;
        private string itemNumber;
        private string copies;
        private string description;

        public string JobTransmittalDetailID
        {
            get { return jobTransmittalDetailID; }
        }

        public JobTransmittalDetail()
        {
        }
        public JobTransmittalDetail(string jobTransmittalDetailID,
                                    string jobTransmittalID,
                                    string itemNumber,
                                    string copies,
                                    string description)
        {
            this.jobTransmittalDetailID = jobTransmittalDetailID;
            this.jobTransmittalID = String.IsNullOrEmpty(jobTransmittalID) ? "Null" : jobTransmittalID;
            this.itemNumber = "'" + itemNumber.Trim().Replace("'", "''") + "'";
            this.copies = "'" + copies.Trim().Replace("'", "''") + "'";
            this.description = "'" + description.Trim().Replace("'", "''") + "'";
        }
        //
        public static DataSet GetTransmittalDetail(string jobTransmittalID)
        {
            string query = "";

            query = " SELECT * FROM tblJobTransmittalDetail WHERE JobTransmittalID = " + jobTransmittalID + " ";

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
        public static void Delete(string jobTransmittalDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobTransmittalDetail WHERE JobTransmittalDetailID = " + jobTransmittalDetailID + " ";

            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobTransmittalDetailID == "" || jobTransmittalDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobTransmittalDetail(" +
                    " JobTransmittalID, " +
                    " ItemNumber, " +
                    " Copies, " +
                    " Description) VALUES (" +
                    jobTransmittalID + ", " +
                    itemNumber + ", " +
                    copies + ", " +
                    description + ") " +
                   "Select @@IDENTITY ";
            try
            {
                jobTransmittalDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobTransmittalDetail SET " +
                    " JobTransmittalID      = " + jobTransmittalID + ", " +
                    " ItemNumber            = " + itemNumber + ", " +
                    " copies                = " + copies + ", " +
                    " Description           = " + description + " " +
                    " WHERE JobTransmittalDetailID  = " + jobTransmittalDetailID;
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
