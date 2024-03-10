using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMTerritory
    {
        private string cmTerritoryID;
        private string cmTerritoryDescription;
        //
        public string CMTerritoryID
        {
            get { return cmTerritoryID; }
        }
        //
        public CMTerritory()
        {
        }
        //
        public CMTerritory(string cmTerritoryID,
                            string cmTerritoryDescription)
        {
            this.cmTerritoryID = String.IsNullOrEmpty(cmTerritoryID) ? "" : cmTerritoryID;
            this.cmTerritoryDescription = cmTerritoryDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmTerritoryID == "" || cmTerritoryID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMTerritory(CMTerritoryDescription) Values(" +
                    "  '" + cmTerritoryDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmTerritoryID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMTerritory SET " +
                    " CMTerritoryDescription         = '" + cmTerritoryDescription + "' " +
                    " WHERE CMTerritoryID            = " + cmTerritoryID;

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
        public static void Delete(string cmTerritoryID)
        {
            string query = "Delete FROM tblCMTerritory WHERE CMTerritoryID = " + cmTerritoryID;
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
        public static DataSet GetCMTerritoryList()
        {
            string query = "";

            query = " SELECT CMTerritoryID, " +
                    " CMTerritoryDescription AS [Territory] " +
                    " FROM  tblCMTerritory  " +
                    " ORDER BY CMTerritoryDescription ";
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
        public static DataSet GetCMTerritoryDetail(string cmTerritoryID)
        {
            string query = "";

            query = " SELECT CMTerritoryID, " +
                    " CMTerritoryDescription AS [Territory] " +
                    " FROM  tblCMTerritory  " +
                    " WHERE CMTerritoryID = " + cmTerritoryID + " ";
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
