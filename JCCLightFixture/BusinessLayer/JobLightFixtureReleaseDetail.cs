using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCLightFixture.BusinessLayer
{
    class JobLightFixtureReleaseDetail
    {
        private string jobLightFixtureReleaseDetailID;
        private string jobLightFixtureReleaseID;
        private string jobLightFixtureID;
        private string qtyRun;
        private string length;
        private string estimatedShipDate;
        private string notes;
        //
        public JobLightFixtureReleaseDetail()
        {
        }
        //
        public JobLightFixtureReleaseDetail(string jobLightFixtureReleaseDetailID,
                                            string jobLightFixtureReleaseID,
                                            string jobLightFixtureID,
                                            string qtyRun,
                                            string length,
                                            string estimatedShipDate,
                                            string notes)
        {
            this.jobLightFixtureReleaseDetailID = jobLightFixtureReleaseDetailID;
            this.jobLightFixtureReleaseID = jobLightFixtureReleaseID;
            this.jobLightFixtureID = jobLightFixtureID;
            this.qtyRun = String.IsNullOrEmpty(qtyRun) ? "null" : qtyRun;
            this.length = String.IsNullOrEmpty(length) ? "null" : length;
            this.estimatedShipDate = String.IsNullOrEmpty(estimatedShipDate) ? "null" : "'" + estimatedShipDate + "'";
            this.notes = "'" + notes.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobLightFixtureReleaseDetailID
        {
            get { return jobLightFixtureReleaseDetailID; }
        }
        //
        public static DataSet GetLightFixtureRelease(string jobLightFixtureReleaseID)
        {

            string query = " SELECT * " +
                           " FROM tblJobLightFixtureReleaseDetail " +
                           " WHERE JobLightFixtureReleaseID = " + jobLightFixtureReleaseID + " ";
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
        public static bool Remove(string jobLightFixtureReleaseDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobLightFixtureReleaseDetail WHERE JobLightFixtureReleaseDetailID = " + jobLightFixtureReleaseDetailID;
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
            if (jobLightFixtureReleaseDetailID == "" || jobLightFixtureReleaseDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobLightFixtureReleaseDetail(" +
                    " JobLightFixtureReleaseID, " +
                    " JobLightFixtureID, " +
                    " QtyRun, " +
                    " Length, " +
                    " EstimatedShipDate, notes " +
                    " ) VALUES ( " +
                    jobLightFixtureReleaseID + ", " +
                    jobLightFixtureID + ", " +
                    qtyRun + ", " +
                    length + ", " +
                    estimatedShipDate + ", " +
                    notes + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobLightFixtureReleaseDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobLightFixtureReleaseDetail SET " +
                    " JobLightFixtureReleaseID      = " + jobLightFixtureReleaseID + ", " +
                    " JobLightFixtureID             = " + jobLightFixtureID + ", " +
                    " QtyRun                        = " + qtyRun + ", " +
                    " Length                        = " + length + ", " +
                    " EstimatedShipDate             = " + estimatedShipDate + ", " +
                    " Notes                         = " + notes + " " +
                    " WHERE JobLightFixtureReleaseDetailID   = " + jobLightFixtureReleaseDetailID;
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
