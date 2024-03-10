using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using System.Data.SqlClient;

namespace CCEOTProjects.BusinessLayer
{
    class Audit
    {
        public Audit()
        {
        }
        //
        public static DataSet GetAudit(string otProjectID)
        {
            string query = "";

            query = " SELECT OTAuditID, OTProjectID, Audit, UserName AS [Created By], AuditDate AS [Date] " +
                    " FROM tblOTAudit a " +
                    " LEFT JOIN tblUser u ON a.UserLANID = u.UserLANID " +
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
        public static Int64 GetSessionID(string otProjectID)
        {
            Int64 sessionID = 0;

            string query = "SELECT MAX(otAuditID) AS SessionID FROM tblOTAudit WHERE UserLANID = '" + Security.Security.LoginID.ToUpper() + "'  AND OTProjectID = " + otProjectID + " ";
            try
            {
                DataRow r = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0];
                if (r["SessionID"] != null &&    !String.IsNullOrEmpty(r["SessionID"].ToString()))
                    sessionID = Int64.Parse(r["SessionID"].ToString());
                return sessionID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static DataSet GetSessionAudit(string otProjectID, string sessionID)
        {
            string query = "";

            query = " SELECT Audit " +
                    " FROM tblOTAudit  " +
                    " WHERE OTProjectID = " + otProjectID + "  AND OTAuditID >= " + sessionID + "  AND UserLANID = '" + 
                     Security.Security.LoginID.ToUpper() + "' ";
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
