using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace Security.BusinessLayer
{
    class UserAccess
    {
        private string userAccessID;
        private string userID;
        private string accessID;
        private string accessLevelID;
        private string officeID;
        private string departmentID;
        private string worktypeID;


        public string UserAccessID
        {
            get { return userAccessID; }
        }

        public UserAccess()
        {
        }
        //
        public UserAccess(string userAccessID,
                          string userID,
                          string accessID,
                          string accessLevelID,
                          string officeID,
                          string departmentID,
                          string worktypeID)

        {
            this.userAccessID       = userAccessID;
            this.userID             = userID;
            this.accessID           = accessID;
            this.accessLevelID      = accessLevelID;
            this.officeID           = String.IsNullOrEmpty(officeID) ? "Null" : officeID;
            this.departmentID       = String.IsNullOrEmpty(departmentID) ? "Null" : departmentID;
            this.worktypeID         = String.IsNullOrEmpty(worktypeID) ? "Null" : worktypeID;
        }
        //
        public static DataSet GetUserAccess(string userID)
        {
            string query = "";

            query = " SELECT UserAccessID, UserID, AccessID [Access], " +
                    " AccessLevelID AS [Access Level], " +
                    " OfficeID AS [Office], " +
                    " DepartmentID AS [Department],  " +
                    " WorkTypeID   AS [Work Type] " +
                    " FROM tblSecUserAccess WHERE UserID =  " + userID;

            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static DataSet GetUserProgramAccess(string userLANID)
        {
            string query = "";

            query = " SELECT UserAccessID, AccessID, " +
                    " AccessLevelID " +
                    " FROM tblSecUserAccess a   " +
                    " INNER JOIN tblUSer u ON a.UserID = u.UserID " +
                    " WHERE UserLANID =  '" + userLANID + "' ";

            try
            {
                return DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataSet GetUsrID(string userLANID)
        {
            string query = "";

            query = " SELECT UserID, TitleID FROM tblUser " +
                    " WHERE UserLANID =  '" + userLANID + "' ";

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
            if (userAccessID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblSecUserAccess(UserID, AccessID, AccessLevelID, OfficeID, DepartmentID, WorktypeID) Values(" +
                    userID + ", " + accessID + ", " + accessLevelID + ", " + officeID + ", " + departmentID + ", " + worktypeID + ") " +
                    "Select @@IDENTITY ";
            try
            {
                userAccessID = DataBaseUtil.ExecuteScalar(query, Security.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static bool Delete(string userAccessID)
        {
            string query = "";

            query = " DELETE FROM tblSecUserAccess WHERE UserAccessID = " + userAccessID + " ";
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
        //
        private bool Update()
        {
            string query = "";

            query = "Update tblSecUserAccess  SET " +
                    " UserID                    = " + userID + ", " +
                    " AccessID                  = " + accessID + ", " +
                    " AccessLevelID             = " + accessLevelID + ", " +
                    " OfficeID                  = " + officeID + ", " +
                    " DepartmentID              = " + departmentID + ", " +
                    " WorkTypeID                = " + worktypeID + " " +
                    " WHERE UserAccessID  = " + userAccessID;
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
