using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace CCEOTProjects.BusinessLayer
{
    class WebLink
    {
        private string otWebLinkID;
        private string otProjectID;
        private string webLink;

        public string WebLinkID
        {
            get { return otWebLinkID; }
        }
        //
        public WebLink()
        {
        }
        //
        public WebLink(string otWebLinkID,
                    string otProjectID,
                    string webLink)
        {
            this.otWebLinkID    = otWebLinkID;
            this.otProjectID    = otProjectID;
            this.webLink        = webLink.Trim().ToUpper().Replace("'", "''");
        }
        //
        public static DataSet GetWebLinks(string otProjectID)
        {
            string query = "";

            query = " SELECT OTWebLinkID, OTProjectID, WebLink AS [Web Link] " +
                    " FROM tblOTWebLink WHERE OTProjectID = " + otProjectID + " ";
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
            if (otWebLinkID == "")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblOTWebLink(OTProjectID, WebLink) Values(" +
                    otProjectID + ", '" + webLink + "')" +
                    "Select @@IDENTITY ";
            try
            {
                otWebLinkID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static bool Delete(string otWebLinkID)
        {
            try
            {
                string query = "";

                query = " DELETE FROM tblOTWebLink WHERE OTWebLinkID = " + otWebLinkID + " ";
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

            query = "Update tblOTWebLink     SET " +
                    " OTProjectID               = " + otProjectID + ", " +
                    " WebLink                   = '" + webLink + "' " +
                    " WHERE OTWebLinkID  = " + otWebLinkID;
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
