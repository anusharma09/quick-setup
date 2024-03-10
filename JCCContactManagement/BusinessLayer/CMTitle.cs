using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMTitle
    {
        private string cmTitleID;
        private string cmTitleDescription;
        //
        public string CMTitleID
        {
            get { return cmTitleID; }
        }
        //
        public CMTitle()
        {
        }
        //
        public CMTitle(string cmTitleID,
                            string cmTitleDescription)
        {
            this.cmTitleID = String.IsNullOrEmpty(cmTitleID) ? "" : cmTitleID;
            this.cmTitleDescription = cmTitleDescription.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmTitleID == "" || cmTitleID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblCMTitle(CMTitleDescription) Values(" +
                    "  '" + cmTitleDescription + "') " +
                    "Select @@IDENTITY ";

            try
            {
                cmTitleID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMTitle SET " +
                    " CMTitleDescription         = '" + cmTitleDescription + "' " +
                    " WHERE CMTitleID            = " + cmTitleID;

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
        public static void Delete(string cmTitleID)
        {
            string query = "Delete FROM tblCMTitle WHERE CMTitleID = " + cmTitleID;
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
        public static DataSet GetCMTitleList()
        {
            string query = "";

            query = " SELECT CMTitleID, " +
                    " CMTitleDescription AS [Title] " +
                    " FROM  tblCMTitle  " +
                    " ORDER BY CMTitleDescription ";
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
        public static DataSet GetCMTitleDetail(string cmTitleID)
        {
            string query = "";

            query = " SELECT CMTitleID, " +
                    " CMTitleDescription AS [Title] " +
                    " FROM  tblCMTitle  " +
                    " WHERE CMTitleID = " + cmTitleID + " ";
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
