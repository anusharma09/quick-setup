using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMIndustry
    {
        private string cmIndustryID;
        private string cmIndustryDescription;
        //
        public string CMIndustryID
        {
            get { return cmIndustryID; }
        }
        //
        public CMIndustry()
        {
        }
        //
        public CMIndustry(string cmIndustryID,
                            string cmIndustryDescription)
        {
            this.cmIndustryID = String.IsNullOrEmpty(cmIndustryID) ? "" : cmIndustryID;
            this.cmIndustryDescription = cmIndustryDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmIndustryID == "" || cmIndustryID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMIndustry(CMIndustryDescription) Values(" +
                    "  '" + cmIndustryDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmIndustryID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMIndustry SET " +
                    " CMIndustryDescription         = '" + cmIndustryDescription + "' " +
                    " WHERE CMIndustryID            = " + cmIndustryID;

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
        public static void Delete(string cmIndustryID)
        {
            string query = "Delete FROM tblCMIndustry WHERE CMIndustryID = " + cmIndustryID;
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
        public static DataSet GetCMIndustryList()
        {
            string query = "";

            query = " SELECT CMIndustryID, " +
                    " CMIndustryDescription AS [Industry] " +
                    " FROM  tblCMIndustry  " +
                    " ORDER BY CMIndustryDescription ";
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
        public static DataSet GetCMIndustryDetail(string cmIndustryID)
        {
            string query = "";

            query = " SELECT CMIndustryID, " +
                    " CMIndustryDescription AS [Industry] " +
                    " FROM  tblCMIndustry  " +
                    " WHERE CMIndustryID = " + cmIndustryID + " ";
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
