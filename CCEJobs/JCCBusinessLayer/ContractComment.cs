using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace JCCBusinessLayer
{
    public class ChangeOrderComment
    {
        private string jobChangeOrderCommentID;
        private string jobChangeOrderID;
        private string comment;
        private string lastUpdateDate;
        private string userID;

        public string JobChangeOrderCommentID
        {
            get { return jobChangeOrderCommentID; }
        }

        public ChangeOrderComment()
        {
        }
        public ChangeOrderComment(string jobChangeOrderCommentID,
                        string jobChangeOrderID,
                        string comment,
                        string lastUpdateDate,
                        string userID)
        {


            this.jobChangeOrderCommentID = jobChangeOrderCommentID;
            this.jobChangeOrderID = jobChangeOrderID;
            this.comment = comment.Trim().ToUpper().Replace("'", "''");
            this.lastUpdateDate = lastUpdateDate;
            this.userID = userID;
        }

        public bool Save()
        {
            if (jobChangeOrderCommentID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobChangeOrderComment(jobChangeOrderID, Comment, LastUpdateDate, UserID) Values(" +
                    jobChangeOrderID + ", '" + comment + "', '" + lastUpdateDate + "', '" + userID + "')" +
                    "Select @@IDENTITY ";
            try
            {
                jobChangeOrderCommentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobChangeOrderComment SET " +
                    " Comment                   = '" + comment + "', " +
                    " LastUpdateDate            = '" + lastUpdateDate + "', " +
                    " UserID                    = '" + userID + "' " +
                    " WHERE JobChangeOrderCommentID  = " + jobChangeOrderCommentID;
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
