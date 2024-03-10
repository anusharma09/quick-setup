using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCMaterialOrder.BusinessLayer
{
    class MaterialOrder
    {
        private string jobMaterialOrderID;
        private string jobID;
        private string createdBy;
        private string createdDate;
        private string description;
        private string shipToAddress;
        private string requiredDate;
        private string phone;
        private string fromID;
        private string shipTo;
        private string shipToCity;
        private string shipToState;
        private string shipToZip;
        //
        public MaterialOrder()
        {
        }
        //
        public MaterialOrder(string jobMaterialOrderID,
                               string jobID,
                               string description,
                               string shipToAddress,
                               string requiredDate,
                               string phone,
                               string fromID,
                               string shipTo,
                               string shipToCity,
                               string shipToState,
                               string shipToZip)
        {
            this.jobMaterialOrderID                     = jobMaterialOrderID;
            this.jobID                                  = jobID;
            this.description                            = "'" + description.Trim().Replace("'", "''") + "'";
            this.shipTo                                 = "'" + shipTo.Trim().Replace("'", "''") + "'";
            this.shipToAddress                          = "'" + shipToAddress.Trim().Replace("'", "''") + "'";
            this.shipToCity                             = "'" + shipToCity.Trim().Replace("'", "''") + "'";
            this.shipToState                            = "'" + shipToState.Trim().Replace("'", "''") + "'";
            this.shipToZip                              = "'" + shipToZip.Trim().Replace("'", "''") + "'";
            this.requiredDate                           = String.IsNullOrEmpty(requiredDate) ? "null" : "'" + requiredDate + "'";
            this.phone                                  = "'" + phone.Trim().Replace("'", "''") + "'";
            this.fromID                                 = String.IsNullOrEmpty(fromID) ? "null" :  fromID;

        }
        //
        public string JobMaterialOrderID
        {
            get { return jobMaterialOrderID; }
        }
        //
        public static DataSet GetEmailTo()
        {

            string query = " SELECT DISTINCT  EMail " +
                           " FROM tblSECUserAccess a  " +
                           " INNER JOIN tblUser u ON a.UserID = u.UserID " +
                           " WHERE AccessID IN(43) "; 
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
        public static DataSet GetJobMaterialOrderDescription(string jobID)
        {

            string query = " SELECT " +
                           " JobMaterialOrderID, Description " +
                           " FROM tblJobMaterialOrder " +
                           " WHERE JobID = " + jobID + " " +
                           " ORDER BY Description ";
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
        //
        public static DataSet GetJobMaterialOrderForm(string jobMaterialOrderID)
        {

            string query = "  SELECT " +
                           "  OrderNumber, " +
                           "  JobNumber, " +
                           "  JobName, " +
                           "  r.Description, " +
                           " ShipTo, " +
                           " ShipToAddress, " +
                           " ISNULL(ShipToCity, '') + ', ' + ISNULL(ShipToState, '') + ' ' + ISNULL(ShipToZip, '') AS CityStateZip, " +
                           "  RequiredDate, " +
                           "  r.CreatedDate, " +
                           "  UserName, " +
                           "  Quantity, " +
                           "  d.Description AS [ItemDescription], " +
                           "  NeededBy, " +
                           "  DateReceived, " +
                           "  Name AS Vendor, " +
                           "  d.PONumber, " +
                           " r.Phone,  " +
                           " EmailFrom = " +
                           " CASE l.LotusNotes " +
                           " WHEN 1 THEN  ISNULL(mm.Email, '')" +
                           " ELSE ISNULL(nn.Email, '') " +
                           " End " +
                           "  FROM tblJobMaterialOrder r " +
                           "  LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           "  LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " +
                           "  LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                           "  LEFT JOIN tblJobMaterialOrderDetail d ON r.JobMaterialOrderID = d.JobMaterialOrderID " +
                           "  LEFT JOIN tblVendor v ON d.VendorID = v.VendorID " +
                           " LEFT JOIN tblJobContact l ON r.FromID = l.ContactID " +
                           " LEFT JOIN tblCompanyContact mm ON l.CompanyContactID = mm.CompanyContactID " +
                           " LEFT JOIN tblJobContactDetail nn ON l.CompanyContactID = nn.JobContactDetailID " + 
                           " WHERE r.JobMaterialOrderID = " + jobMaterialOrderID + " ";
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
        public static DataSet GetMaterialOrderList(string where)
        {

            string query = " SELECT " +
                           " JobMaterialOrderID, " +
                           " OrderNumber AS [Order No], " +
                           " JobNumber AS [Job], " +
                           " r.Description AS [Description], " +
                           " ShipToAddress AS [Ship To Address], " +
                           " RequiredDate AS [Date Required], " +
                           " r.CreatedDate AS [Created Date], " +
                           " UserName  AS [Created By], " +
                           " m.Description AS [Project Manager] " +
                           " FROM tblJobMaterialOrder r " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " +
                           " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                           where;
	

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
        //
        public static string GetJobID(string jobNumber)
        {
            string query = "";
            bool ret = false;
            string jobID = "0";
            DataTable t;
            if (jobNumber == "")
                jobNumber = "0";
            


            if (Security.Security.UserJCCEquipmentRentalAccess == Security.Security.Access.JCCEquipmentRentalAdmin ||
                Security.Security.UserJCCEquipmentRentalAccess == Security.Security.Access.JCCEquipmentRentalAdminMail)
            {
                query = "SELECT JobID FROM tblJob WHERE JobNumber = '" + jobNumber + "'";
            }
            else
            {
                query = " SELECT JobID " + 
                        " FROM tblJob " + 
                        " WHERE JobNumber = '" + jobNumber + "'" + 
                        " AND [dbo].[GetUserJobAccess](JobID,'" + Security.Security.LoginID  + "')  = 1 "; 
            }

            try
            {
                t =  DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    jobID = t.Rows[0]["JobID"].ToString();
                return jobID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetJobMaterialOrderList(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            string query = " SELECT " +
                           " JobMaterialOrderID, " +
                           " r.JobID, " +
                           " OrderNumber AS [Order No], " +
                           " r.Description AS [Description], " +
                           " ShipToAddress AS [Ship To Address], " +
                           " RequiredDate AS [Date Required], " +
                           " r.CreatedDate AS [Created Date], " +
                           " UserName  AS [Created By] " +
                           " FROM tblJobMaterialOrder r " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " +
                           " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                           " WHERE r.JobID = " + jobID + " ";

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
        public static DataSet GetJobMaterialOrderListCondition(string where)
        {
        
            string query = " SELECT " +
                           " r.JobMaterialOrderID, " +
                           " r.JobID, " +
                           " OrderNumber AS [Order No], " +
                           " r.Description AS [Description], " +
                           " ShipToAddress AS [Ship To Address], " +
                           " RequiredDate AS [Date Required], " +
                           " r.CreatedDate AS [Created Date], " +
                           " UserName  AS [Created By] " +
                           " FROM tblJobMaterialOrder r " +
                           " LEFT JOIN tblJobMaterialOrderDetail d ON r.JobMaterialOrderID = d.JobMaterialOrderID " +
                           " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                           " LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " +
                           " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID " +
                           where;

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
        public static DataSet GetMaterialOrder(string jobMaterialOrderID)
        {
            if (jobMaterialOrderID == "")
                jobMaterialOrderID = "0";

            string query = "SELECT r.*, " +
                    " JobNumber, " +
                    " u.UserName AS CreatedByName " +
                " FROM tblJobMaterialOrder r" +
                " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                " LEFT JOIN tblUser u ON r.CreatedBy = u.UserLanID " +
                " WHERE JobMaterialOrderID = " + jobMaterialOrderID + " ";

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
        public static DataSet EMail(string jobMaterialOrderID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobMaterialOrderID", jobMaterialOrderID);

            try
            {
                return DataBaseUtil.ExecuteParDataset("dbo.[up_JCCMaterialOrderMail]", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

        //
        public static DataSet GetCreatUpdate(string jobMaterialOrderID)
        {
            if (jobMaterialOrderID == "")
                jobMaterialOrderID = "0";

            string query = "SELECT OrderNumber, r.CreatedDate, " +
                    " u.UserName AS CreatedByName " +
                " FROM tblJobMaterialOrder r" +
                " LEFT JOIN tblUser u ON r.CreatedBy = u.UserLanID " +
                " WHERE JobMaterialOrderID = " + jobMaterialOrderID + " ";

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
        public static bool Remove(string jobMaterialOrderID)
        {
            string query = "";

            query = "DELETE FROM tblJobMaterialOrderDetail WHERE JobMaterialOrderID = " + jobMaterialOrderID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobMaterialOrder WHERE JobMaterialOrderID = " + jobMaterialOrderID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public bool Save()
        {
            if (jobMaterialOrderID == "" || jobMaterialOrderID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobMaterialOrder(" +
                    " JobID, " +                    
                    " CreatedBy, " +                
                    " CreatedDate, " +             
                    " Description, " +
                    " ShipTo, " +
                    " ShipToAddress, " +
                    " ShipToCity, " +
                    " ShipToState, " +
                    " ShipToZip, " +
                    " Phone, " +
                    " FromID, " +
                    " RequiredDate " +     
                    " ) VALUES ( " +
                    jobID + ", " +                     
                    "'" + Security.Security.LoginID + "', " +                
                    "'" + DateTime.Now.ToShortDateString() + "', " +             
                    description + ", " +  
                    shipTo + ", " +
                    shipToAddress + ", " +
                    shipToCity + ", " +
                    shipToState + ", " +
                    shipToZip + ", " +
                    phone + ", " +
                    fromID + ", " +
                    requiredDate + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobMaterialOrderID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobMaterialOrder SET " +
                    " Description                     = " + description + ", " +
                    " ShipTo                          = " + shipTo + ", " +
                    " ShipToAddress                   = " + shipToAddress + ", " +
                    " ShipToCity                      = " + shipToCity + ", " +
                    " ShipToState                     = " + shipToState + ", " +
                    " ShipToZip                       = " + shipToZip + ", " +
                    " Phone                           = " + phone + ", " +
                    " FromID                          = " + fromID + ", " +     
                    " RequiredDate                    = " + requiredDate + " " +                          
                    " WHERE JobMaterialOrderID        = " + jobMaterialOrderID;
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
