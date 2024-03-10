using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMDepartment
    {
        private string cmDepartmentID;
        private string cmDepartmentDescription;
        //
        public string CMDepartmentID
        {
            get { return cmDepartmentID; }
        }
        //
        public CMDepartment()
        {
        }
        //
        public CMDepartment(string cmDepartmentID,
                            string cmDepartmentDescription)
        {
            this.cmDepartmentID = String.IsNullOrEmpty(cmDepartmentID) ? "" : cmDepartmentID;
            this.cmDepartmentDescription = cmDepartmentDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmDepartmentID == "" || cmDepartmentID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMDepartment(CMDepartmentDescription) Values(" +
                    "  '" + cmDepartmentDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmDepartmentID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMDepartment SET " +
                    " CMDepartmentDescription         = '" + cmDepartmentDescription + "' " +
                    " WHERE CMDepartmentID            = " + cmDepartmentID;

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
        public static void Delete(string cmDepartmentID)
        {
            string query = "Delete FROM tblCMDepartment WHERE CMDepartmentID = " + cmDepartmentID;
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
        public static DataSet GetCMDepartmentList()
        {
            string query = "";

            query = " SELECT CMDepartmentID, " +
                    " CMDepartmentDescription AS [Department] " +
                    " FROM  tblCMDepartment  " +
                    " ORDER BY CMDepartmentDescription ";
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
        public static DataSet GetCMDepartmentDetail(string cmDepartmentID)
        {
            string query = "";

            query = " SELECT CMDepartmentID, " +
                    " CMDepartmentDescription AS [Department] " +
                    " FROM  tblCMDepartment  " +
                    " WHERE CMDepartmentID = " + cmDepartmentID + " ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
