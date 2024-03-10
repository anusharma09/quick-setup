using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
namespace JCCBusinessLayer
{
    public static class Utilities
    {
        public static string  GetEstimatorServer(string estimatorID)
        {
            DataSet ds;
            string estimatorServer = "";
            if (String.IsNullOrEmpty(estimatorID) || estimatorID == "Null")
                estimatorID = "0";
            string query = "SELECT  ServerName as [ServerName] from tblEstimator e " +
                            " INNER JOIN tblUser u ON e.Description = u.UserName " +
                            " INNER JOIN tblOffice o ON u.OfficeID = o.OfficeID " +
                            " WHERE e.EstimatorID = " + estimatorID;
            try
            {
                ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    // Default Martinez Server
                    query = "SELECT  ServerName AS [ServerName] from tblOffice WHERE OfficeName = 'Dynalectric Company'";
                    ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                }
                else
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                return estimatorServer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetJobServer(string officeID)
        {
            DataSet ds;
            string estimatorServer = "";
            string query = "SELECT  ServerName as [ServerName] from tblOffice " +
                            " WHERE OfficeID = " + officeID;
            try
            {
                ds = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    // Default Martinez Server
                    query = "SELECT  ServerName AS [ServerName] from tblOffice WHERE OfficeName = 'MARTINEZ'";
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                }
                else
                    estimatorServer = ds.Tables[0].Rows[0]["ServerName"].ToString();
                return estimatorServer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
