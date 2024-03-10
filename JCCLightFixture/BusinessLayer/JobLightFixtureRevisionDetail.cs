using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCLightFixture.BusinessLayer
{
    class JobLightFixtureRevisionDetail
    {
        private string jobLightFixtureRevisionDetailID;
        private string jobLightFixtureRevisionID;
        private string jobLightFixtureID;
        private string qtyRun;
        private string length;
        private string estimatedShipDate;
        private string notes;
        //
        public JobLightFixtureRevisionDetail()
        {
        }
        //
        public JobLightFixtureRevisionDetail(string jobLightFixtureRevisionDetailID,
                                            string jobLightFixtureRevisionID,
                                            string jobLightFixtureID,
                                            string qtyRun,
                                            string length,
                                            string estimatedShipDate,
                                            string notes)
        {
            this.jobLightFixtureRevisionDetailID = jobLightFixtureRevisionDetailID;
            this.jobLightFixtureRevisionID = jobLightFixtureRevisionID;
            this.jobLightFixtureID = jobLightFixtureID;
            this.qtyRun = String.IsNullOrEmpty(qtyRun) ? "null" : qtyRun;
            this.length = String.IsNullOrEmpty(length) ? "null" : length;
            this.estimatedShipDate = String.IsNullOrEmpty(estimatedShipDate) ? "null" : "'" + estimatedShipDate + "'";
            this.notes = "'" + notes.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobLightFixtureRevisionDetailID
        {
            get { return jobLightFixtureRevisionDetailID; }
        }
        //
        public static DataSet GetLightFixtureRevision(string jobLightFixtureRevisionID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureRevisionDetail " +
                           " WHERE JobLightFixtureRevisionID = " + jobLightFixtureRevisionID + " ";
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
        public static bool Remove(string jobLightFixtureRevisionDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobLightFixtureRevisionDetail WHERE JobLightFixtureRevisionDetailID = " + jobLightFixtureRevisionDetailID;
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
            if (jobLightFixtureRevisionDetailID == "" || jobLightFixtureRevisionDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLightFixtureRevisionDetail(" +
                    " JobLightFixtureRevisionID, " +
                    " JobLightFixtureID, " +
                    " QtyRun, " +
                    " Length, " +
                    " EstimatedShipDate, notes " +
                    " ) VALUES ( " +
                    jobLightFixtureRevisionID + ", " +
                    jobLightFixtureID + ", " +
                    qtyRun + ", " +
                    length + ", " +
                    estimatedShipDate + ", " +
                    notes + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobLightFixtureRevisionDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobLightFixtureRevisionDetail SET " +
                    " JobLightFixtureRevisionID      = " + jobLightFixtureRevisionID + ", " +
                    " JobLightFixtureID             = " + jobLightFixtureID + ", " +
                    " QtyRun                        = " + qtyRun + ", " +
                    " Length                        = " + length + ", " +
                    " EstimatedShipDate             = " + estimatedShipDate + ", " +
                    " Notes                         = " + notes + " " +
                    " WHERE JobLightFixtureRevisionDetailID   = " + jobLightFixtureRevisionDetailID;
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
