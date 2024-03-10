using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace CCEOTProjects.BusinessLayer
{
    class Assignment
    {
        private string otAssignmentID;
        private string otProjectID;
        private string assignedTo;
        private string assignedFrom;
        private string assignedDate;
        private string description;
        private string accepted;
        private string acceptedBy;
        private string acceptedDate;
        private string completed;
        private string completedBy;
        private string completedDate;

        public string AssignmentID
        {
            get { return otAssignmentID; }
        }
        //
        public Assignment()
        {
        }
        //
        public Assignment(string otAssignmentID,
                            string otProjectID,
                            string assignedTo,
                            string assignedFrom,
                            string assignedDate,
                            string description,
                            string accepted,
                            string acceptedBy,
                            string acceptedDate,
                            string completed,
                            string completedBy,
                            string completedDate)
        {
            this.otAssignmentID                 = otAssignmentID;
            this.otProjectID                    = otProjectID;
            this.assignedTo                     = assignedTo.Trim().Replace("'", "''");
            this.assignedFrom                   = assignedFrom.Trim().Replace("'", "''");
            this.assignedDate                   = String.IsNullOrEmpty(assignedDate) ? "null" : "'" + assignedDate + "'";
            this.description                    = description.Trim().Replace("'", "''");
            this.accepted                       = accepted == "True" ? "1" : "0";
            this.acceptedBy                     = acceptedBy.Trim().Replace("'", "''");
            this.acceptedDate                   = String.IsNullOrEmpty(acceptedDate) ? "null" : "'" + acceptedDate + "'";
            this.completed                      = completed == "True" ? "1" : "0";
            this.completedBy                    = completedBy.Trim().Replace("'", "''");
            this.completedDate                  = String.IsNullOrEmpty(completedDate) ? "null" : "'" + completedDate + "'";
        }
        //
        //
        public static DataSet GetAssigedToEmail(string otAssignmentID)
        {
           string query = " SELECT a.*, OTProjectNumber, OTProjectName," +
                   " u1.UserName AS AssignedFromName, " +
                   " u1.Email AS AssignedFromEmail, " +
                   " u2.UserName AS AssignedToName, " +
                   " u2.Email AS AssignedToEmail, " +
                   " u3.UserName AS AcceptedByName, " +
                   " u4.UserName AS CompletedByName " +
                   " FROM tblOTAssignment a " +
                   " LEFT JOIN tblUser u1 ON a.AssignedFrom = u1.UserLANID " +
                   " LEFT JOIN tblUser u2 ON a.AssignedTo = u2.UserLanID " +
                   " LEFT JOIN tblUser u3 ON a.AcceptedBy = u3.UserLanID " +
                   " LEFT JOIN tblUser u4 ON a.CompletedBy = u4.UserLanID " +
                   " LEFT JOIN tblOTProject p ON a.OTProjectID = p.OTProjectID " +
                   " WHERE OTAssignmentID = " + otAssignmentID + " ";
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
        public static DataSet GetAssignment(string otProjectID)
        {
            string query = "";

            query = " SELECT * FROM tblOTAssignment " +
                    " WHERE OTProjectID = " + otProjectID + " ";
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
        public static DataSet GetAssignmentReport(string otProjectID)
        {
            string query = "";

            query = " SELECT a.*, " +
	                " u1.UserName AS AssignedFromName, " +
	                " u2.UserName AS AssignedToName, " +
	                " u3.UserName AS AcceptedByName, " +
	                " u4.UserName AS CompletedByName " + 
                    " FROM tblOTAssignment a " +
                    " LEFT JOIN tblUser u1 ON a.AssignedFrom = u1.UserLANID " +
                    " LEFT JOIN tblUser u2 ON a.AssignedTo = u2.UserLanID " +
                    " LEFT JOIN tblUser u3 ON a.AcceptedBy = u3.UserLanID " +
                    " LEFT JOIN tblUser u4 ON a.CompletedBy = u4.UserLanID " +
                    " WHERE OTProjectID = " + otProjectID + " ";
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
        public bool Save()
        {
            if (otAssignmentID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = " INSERT INTO tblOTAssignment( " +
                    " OTProjectID, " +
                    " AssignedFrom, " +
                    " AssignedTo, " +
                    " AssignedDate, " +
                    " Description, " +
                    " Accepted, " +
                    " AcceptedBy, " +
                    " AcceptedDate, " +
                    " Completed, " +
                    " CompletedBy, " +
                    " CompletedDate " +
                    ")Values(" +
                    " " + otProjectID + ", " +
                    "'" + assignedFrom + "', " +
                    "'" + assignedTo + "', " +
                    " " + assignedDate + ", " +
                    "'" + description + "', " +
                    " " + accepted + ", " +
                    "'" + acceptedBy + "', " +
                    " " + acceptedDate + ", " +
                    " " + completed + ", " +
                    "'" + completedBy + "', " +
                    " " + completedDate + ") " +
                    " Select @@IDENTITY ";
            try
            {
                otAssignmentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static bool Delete(string otAssignmentID)
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblOTAssignment WHERE OTAssignmentID = " + otAssignmentID + " ";
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
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

            query = "Update tblOTAssignment       SET " +
                    " OTProjectID               = " + otProjectID + ", " +
                    " AssignedFrom              = '" + assignedFrom + "', " +
                    " AssignedTo                = '" + assignedTo + "', " +
                    " AssignedDate              = " + assignedDate + ", " +
                    " Description               = '" + description + "', " +
                    " Accepted                  = " + accepted + ", " +
                    " AcceptedBy                = '" + acceptedBy + "', " +
                    " AcceptedDate              =  " + acceptedDate + ", " +
                    " Completed                 = " + completed + ", " +
                    " CompletedBy               = '" + completedBy + "', " +
                    " CompletedDate             = " + completedDate + " " +
                    " WHERE OTAssignmentID  = " + otAssignmentID;
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
 
