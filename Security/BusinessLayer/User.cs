using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace Security.BusinessLayer
{
    class User
    {
        private string userID;
        private string userLANID;
        private string userName;
        private string userEmail;
        private string officeID;
        private string departmentID;
        private string projectManagerID;
        private string estimatorID;
        private string salesRepID;
        private string jobTechID;
        private string titleID;
        private string email;

        public string UserID
        {
            get { return userID; }
        }

        public User()
        {
        }
        public User(string userID,
                    string userLANID,
                    string userName,
                    string userEmail,
                    string officeID,
                    string departmentID,
                    string projectManagerID,
                    string estimatorID,
                    string salesRepID,
                    string jobTechID,
                    string titleID,
                    string email)
        {
            this.userID             = userID;
            this.userLANID          = userLANID.Trim().ToUpper().Replace("'","''");
            this.userName           = userName.Trim().ToUpper().Replace("'","''");
            this.userEmail          = userEmail.Trim().ToUpper().Replace("'", "''");
            this.officeID           = String.IsNullOrEmpty(officeID) ? "Null" : officeID;
            this.departmentID       = String.IsNullOrEmpty(departmentID) ? "Null" : departmentID;
            this.projectManagerID   = String.IsNullOrEmpty(projectManagerID) ? "Null" : projectManagerID;
            this.estimatorID        = String.IsNullOrEmpty(estimatorID) ? "Null" : estimatorID;
            this.salesRepID         = String.IsNullOrEmpty(salesRepID) ? "Null" : salesRepID;
            this.jobTechID          = String.IsNullOrEmpty(jobTechID) ? "Null" : jobTechID;
            this.titleID            = String.IsNullOrEmpty(titleID) ? "Null" : titleID;
            this.email              = email.Trim().ToUpper().Replace("'", "''");

        }
        public static DataSet GetUsers()
        {
            string query = "";

            query = " SELECT UserID, UserLANID AS [User LANID], " +
                    " UserName AS [User Name], Email," +
                    " TitleID AS Title, " +
                    " OfficeID AS [Office], " +
                    " DepartmentID AS [Department], " +
                    " ProjectManagerID AS [Project Manager], " +
                    " EstimatorID AS [Estimator], " +
                    " SalesRepID AS [Sales Rep], " +
                    " JobTechID AS [Job Tech] " +          
                    " FROM tblUser "; 

            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Save()
        {
            if (userID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblUser(UserLANID, UserName, OfficeID, DepartmentID, ProjectManagerID, EstimatorID, SalesRepID, JobTechID, TitleID, Email) Values('" +
                    userLANID + "', '" + userName + "', " +  officeID + ", " + departmentID + ", " + projectManagerID + ", " + estimatorID + ", " + salesRepID + ", " + jobTechID + ", " + titleID + ", '" + email + "')" +
                    "Select @@IDENTITY ";
            try
            {
                userID = DataBaseUtil.ExecuteScalar(query, Security.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool Delete(string userID)
        {
            try
            {
                string query = "";
                
                query = " DELETE FROM tblUserJob WHERE UserID = " + userID + " ";
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
                query = " DELETE FROM tblSecUserAccess WHERE UserID = " + userID + " ";
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
                query = " DELETE FROM tblUser WHERE UserID = " + userID + " ";
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
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

            query = "Update tblUser     SET " +
                    " UserLANID                 = '" + userLANID + "', " +
                    " UserName                  = '" + userName + "', " +
                    " Email                     = '" + userEmail + "', " +
                    " OfficeID                  = " + officeID + ", " +
                    " DepartmentID              = " + departmentID + ", " +
                    " ProjectManagerID          = " + projectManagerID + ", " +
                    " EstimatorID               = " + estimatorID + ", " +
                    " SalesRepID                = " + salesRepID + ", " +
                    " JobTechID                 = " + jobTechID + ", " +
                    " TitleID                   = " + titleID + " " +
                    " WHERE UserID  = " + userID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
