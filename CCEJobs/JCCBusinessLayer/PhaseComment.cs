using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class PhaseComment
    {
        private string jobCostCodePhaseCommentID;
        private string jobCostCodePhaseID;
        private string comment;
        private string lastUpdateDate;
        private string userID;

        public string JobCostCodePhaseCommentID
        {
            get { return jobCostCodePhaseCommentID; }
        }

        public PhaseComment()
        {
        }
        public PhaseComment(string jobCostCodePhaseCommentID,
                        string jobCostCodePhaseID,
                        string comment,
                        string lastUpdateDate,
                        string userID)
        {


            this.jobCostCodePhaseCommentID = jobCostCodePhaseCommentID;
            this.jobCostCodePhaseID = jobCostCodePhaseID;
            this.comment = comment.Trim().ToUpper().Replace("'", "''");
            this.lastUpdateDate = lastUpdateDate;
            this.userID = userID;
        }

        public bool Save()
        {
            if (jobCostCodePhaseCommentID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobCostCodePhaseComment(jobCostCodePhaseID, Comment, LastUpdateDate, UserID) Values(" +
                    jobCostCodePhaseID + ", '" + comment + "', '" + lastUpdateDate + "', '" + userID + "')" +
                    "Select @@IDENTITY ";
            try
            {
                jobCostCodePhaseCommentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobCostCodePhaseComment SET " +
                    " Comment                   = '" + comment + "', " +
                    " LastUpdateDate            = '" + lastUpdateDate + "', " +
                    " UserID                    = '" + userID + "' " +
                    " WHERE JobCostCodePhaseCommentID  = " + jobCostCodePhaseCommentID;
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
