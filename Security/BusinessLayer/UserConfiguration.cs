using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using System.IO;

namespace Security.BusinessLayer
{
    public class UserConfiguration
    {
        private string userID;
        private string component;
        private string configuration;

        public string UserID
        {
            get { return userID; }
        }

        public UserConfiguration()
        {
        }
        public UserConfiguration(string userID,
                    string component,
                    string configuration)
        {
            this.userID         = userID;
            this.component      = component;
            this.configuration  = configuration;
        }
        //
        public static void SaveGridConfiguration(DevExpress.XtraGrid.Views.Grid.GridView gridView, string component)
        {
            try
            {
                System.IO.Stream stream = new System.IO.MemoryStream();
                gridView.ActiveFilter.Clear();
                gridView.SortInfo.Clear();
                gridView.SaveLayoutToStream(stream);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                System.IO.StreamReader read = new System.IO.StreamReader(stream);
                string config = read.ReadToEnd().Replace("'", "''");
                string id = Security.UserID.ToString();

                string query = "";

                query =  " DECLARE @Count INT " +
                         " SELECT @Count = COUNT(component) FROM tblUserConfiguration " +
                          " WHERE UserID  = " + id + " AND Component = '" + component + "' " +
                          " IF @Count = 1 " +
                          " UPDATE tblUserConfiguration SET Configuration = '" + config + "' " +
                          " WHERE UserID  = " + id + " AND Component = '" + component + "' " +
                          " ELSE " + 
                       "INSERT INTO tblUserConfiguration(userID, component, configuration) Values(" +
                        id + ", '" + component + "', '" + config + "') ";
                DataBaseUtil.ExecuteNonQuery(query, Security.Connection, CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        public static void GetGridConfiguration(DevExpress.XtraGrid.Views.Grid.GridView gridView, string component)
        {
            string query = "";
            string config = "";
            DataSet ds;
            string id = Security.UserID.ToString();

            try
            {
                query = " SELECT Configuration " +
                " FROM tblUserConfiguration " +
                " WHERE UserID  = " + id + " AND Component = '" + component + "' ";

                ds = DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                    config = ds.Tables[0].Rows[0]["Configuration"].ToString();



                if (config.Trim().Length == 0)
                    return;
                byte[] byteArray = Encoding.ASCII.GetBytes(config);
                MemoryStream stream = new MemoryStream(byteArray);
                gridView.RestoreLayoutFromStream(stream);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        //
        public static string GetConfiguration(string userID, string component)
        {
            string query = "";
            string config = "";
            DataSet ds;
            query = " SELECT Configuration " +
                    " FROM tblUserConfiguration " +
                    " WHERE UserID  = " + userID + " AND Component = '" + component + "' ";

            try
            {
                ds =  DataBaseUtil.ExecuteDataset(query, Security.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count > 0)
                    config = ds.Tables[0].Rows[0]["Configuration"].ToString();
                return config;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Save()
        {
            string config = "";

            config = GetConfiguration(userID, component);
            if (config.Trim().Length == 0)
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblUserConfiguration(userID, component, configuration) Values(" +
                    userID + ", '" + component + "', '" + configuration + "') ";
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

            query = "UPDATE tblUserConfiguration  SET " +
                    " Configuration = '"  + configuration + "' " +
                    " WHERE UserID  = " + userID + " AND Component = '" + component + "' ";
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
