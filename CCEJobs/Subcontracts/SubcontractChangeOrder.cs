using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using JCCBusinessLayer;

namespace CCEJobs.Subcontracts
{
    class SubcontractChangeOrder
    {
        private string subcontractChangeOrderID;
        private string subcontractID;
        private string subcontractChangeOrderNumber;
        private string subcontractChangeOrderRequestDate;
        private string subcontractChangeOrderRequestedAmount;
        private string subcontractChangeOrderApprovedDate;
        private string subcontractChangeOrderApprovedAmount;
        private string subcontractChangeOrderStatus;
        private string subcontractChangeOrderDescription;
        private string subcontractChangeOrderUpdateFlag;
        private string subcontractChangeOrderLastUpdateDate;
        private string subcontractChangeOrderOwnerNumber;
        private string subcontractChangeOrderUserDescription;

        public string SubcontractChangeOrderID
        {
            get { return subcontractChangeOrderID; }
        }

        public string SubcontractChangeOrderNumber
        {
            get { return subcontractChangeOrderNumber; }
        }

        public SubcontractChangeOrder()
        {
        }
        public SubcontractChangeOrder(string subcontractChangeOrderID,
                                string subcontractID,
                                string subcontractChangeOrderNumber,
                                string subcontractChangeOrderRequestDate,
                                string subcontractChangeOrderRequestedAmount,
                                string subcontractChangeOrderApprovedDate,
                                string subcontractChangeOrderApprovedAmount,
                                string subcontractChangeOrderStatus,
                                string subcontractChangeOrderDescription,
                                string subcontractChangeOrderOwnerNumber,
                                string subcontractChangeOrderUserDescription)                       
        {


            this.subcontractChangeOrderID = subcontractChangeOrderID;
            this.subcontractID = subcontractID;
            this.subcontractChangeOrderNumber = subcontractChangeOrderNumber;
            this.subcontractChangeOrderRequestDate = String.IsNullOrEmpty(subcontractChangeOrderRequestDate) ? "null" : "'" + subcontractChangeOrderRequestDate + "'";
            this.subcontractChangeOrderRequestedAmount = String.IsNullOrEmpty(subcontractChangeOrderRequestedAmount) ? "Null" : subcontractChangeOrderRequestedAmount;
            this.subcontractChangeOrderApprovedDate = String.IsNullOrEmpty(subcontractChangeOrderApprovedDate) ? "null" : "'" + subcontractChangeOrderApprovedDate + "'";
            this.subcontractChangeOrderApprovedAmount = String.IsNullOrEmpty(subcontractChangeOrderApprovedAmount) ? "Null" : subcontractChangeOrderApprovedAmount;
            this.subcontractChangeOrderStatus = subcontractChangeOrderStatus.Trim().ToUpper().Replace("'", "''");
            this.subcontractChangeOrderDescription = subcontractChangeOrderDescription.Trim().ToUpper().Replace("'", "''");
            this.subcontractChangeOrderOwnerNumber = subcontractChangeOrderOwnerNumber.Trim().ToUpper().Replace("'", "''");
            this.subcontractChangeOrderUserDescription = subcontractChangeOrderUserDescription.Trim().ToUpper().Replace("'", "''");
            this.subcontractChangeOrderLastUpdateDate = DateTime.Today.ToString();
            if (this.subcontractChangeOrderID == "")
                subcontractChangeOrderUpdateFlag = "0";
            else
                subcontractChangeOrderUpdateFlag = "1";
        }
        //
        public static DataSet GetSubcontractChangeOrders(string subcontractID)
        {
            string query = "";
            if (subcontractID == null)
                subcontractID = "0";

            query = "SELECT * FROM tblSubcontractChangeOrder" +
                    " WHERE SubcontractID = '" + subcontractID + "' ";
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
        public static bool UpdatePrimaryContract(string jobID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobID", jobID);
        
            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMJobUpdateStarbuilderPrimaryContract]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool UpdateChangeOrder(string subcontractID, string subcontractChangeOrderID)
        {
            string orderNumber = "";

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@SubcontractID", subcontractID);
            par[1] = new SqlParameter("@SubcontractChangeOrderID", subcontractChangeOrderID);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMSubcontractUpdateStarbuilderChangeOrder]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdatePrimaryContractCostCodes(string jobID)
        {

            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@JobID", jobID);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMJobUpdateStarbuilderPrimaryContractCostCodes]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool UpdateChangeOrderCostCodes(string subcontractID, string subcontractChangeOrderNumber)
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@SubcontractID", subcontractID);
            par[1] = new SqlParameter("@SubcontractChangeOrderNumber", subcontractChangeOrderNumber);

            try
            {
                DataBaseUtil.ExecuteParDataset("dbo.[up_DMSubcontractUpdateStarbuilderChangeOrderCostCodes]", CCEApplication.Connection, CommandType.StoredProcedure, par);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //
        public static DataSet GetSubcontractOriginalContractStatus(string subcontractID)
        {
            string query = "";

            query = "SELECT SubcontractChangeOrderID FROM tblSubcontractChangeOrder" +
                    " WHERE SubcontractID = '" + subcontractID + "' AND SubcontractChangeOrderDescription = 'ORIGINAL CONTRACT' AND SubcontractChangeOrderStatus = 'APPROVED' ";
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
        public static DataSet GetSubcontractChangeOrderDetail(string subcontractChangeOrderID)
        {
            string query = "";
            if (subcontractChangeOrderID == "")
                subcontractChangeOrderID = "0";

            query = "SELECT     " +
                    " sub.SubcontractNumber, " +
                    " SubcontractChangeOrderNumber, " + 
                    " j.JobNumber, j.JobName, m.Description AS ProjectManager, u.Name AS VendorName, " + 
                    " CASE ISNULL(SubcontractChangeOrderApprovedAmount, 0) WHEN 0 THEN SubcontractChangeOrderRequestedAmount ELSE SubcontractChangeOrderApprovedAmount " +
                    " END AS ApprovedAmount, p.SubcontractCostCodeType, p.SubcontractCostCodePhase, p.CostCode, p.UserDescription AS CostCodeDescription, " +
                    " ISNULL(d.Cost, 0) AS Cost " +
                    " FROM tblJob j INNER JOIN " +
                    " tblSubcontract AS sub ON j.JobID = sub.JobID LEFT OUTER JOIN " +
                    " tblProjectManager AS m ON j.ProjectManagerID = m.ProjectManagerID LEFT OUTER JOIN " +
                    " tblSubcontractChangeOrder AS C ON sub.SubcontractID = C.SubcontractID LEFT OUTER JOIN " +
                    " tblVendor AS u ON sub.VendorID = u.VendorID LEFT OUTER JOIN " +
                    " tblSubcontractCostCode AS d ON C.SubcontractChangeOrderID = d.SubcontractChangeOrderID LEFT OUTER JOIN " +
                    " tblSubcontractCostCodePhase AS p ON d.SubcontractCostCodePhaseID = p.SubcontractCostCodePhaseID " +
                    " WHERE c.SubcontractChangeOrderID = '" + subcontractChangeOrderID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet GetSubcontractChangeOrder(string subcontractChangeOrderID)
        {
            string query = "";
            if (subcontractChangeOrderID == "")
                subcontractChangeOrderID = "0";

            query = "SELECT * FROM tblSubcontractChangeOrder" +
                    " WHERE subcontractChangeOrderID = '" + subcontractChangeOrderID + "' ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Save()
        {
            if (subcontractChangeOrderID == "")
                return Insert();
            else
                return Update();
        }
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblSubcontractChangeOrder(SubcontractID, SubcontractChangeOrderNumber, " +
                    " SubcontractChangeOrderRequestDate, SubcontractChangeOrderRequestedAmount, " +
                    " SubcontractChangeOrderApprovedDate, SubcontractChangeOrderApprovedAmount, " +
                    " SubcontractChangeOrderStatus, SubcontractChangeOrderDescription, " + 
                    " SubcontractChangeOrderUpdateFlag, SubcontractChangeOrderLastUpdate, SubcontractChangeOrderOwnerNumber, SubcontractChangeOrderUserDescription) Values(" +
                    subcontractID + ", dbo.GetNewSubcontractChangeOrderNumber ( " +  subcontractID +  "), " +
                    " " + subcontractChangeOrderRequestDate + ", " +  subcontractChangeOrderRequestedAmount + ", " +
                    " " + subcontractChangeOrderApprovedDate + ", " + subcontractChangeOrderApprovedAmount + ", " +
                    " '" + subcontractChangeOrderStatus + "', '" + subcontractChangeOrderDescription + "', " +
                    " " + subcontractChangeOrderUpdateFlag + ", '" + subcontractChangeOrderLastUpdateDate + "', '" + subcontractChangeOrderOwnerNumber + "', '" + subcontractChangeOrderUserDescription + "')" +
                    "Select @@IDENTITY ";
            try
            {
                subcontractChangeOrderID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                // Get JobChange Order Number //
                query = "SELECT subcontractChangeOrderNumber FROM tblSubcontractChangeOrder WHERE SubcontractChangeOrderID =  " + subcontractChangeOrderID + " ";
                subcontractChangeOrderNumber = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0].Rows[0][0].ToString();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private bool Update()
        {
            string query = "";

            query = "Update tblSubcontractChangeOrder SET " +
                    " SubcontractChangeOrderRequestDate       = " + subcontractChangeOrderRequestDate + ", " +
                    " SubcontractChangeOrderRequestedAmount   = " + subcontractChangeOrderRequestedAmount + ", " +
                    " SubcontractChangeOrderApprovedDate      = " + subcontractChangeOrderApprovedDate + ", " +
                    " SubcontractChangeOrderApprovedAmount    = " + subcontractChangeOrderApprovedAmount + ", " +
                    " SubcontractChangeOrderStatus            = '" + subcontractChangeOrderStatus + "', " +
                    " SubcontractChangeOrderDescription       = '" + subcontractChangeOrderDescription + "', " +
                    " SubcontractChangeOrderUpdateFlag        = " + subcontractChangeOrderUpdateFlag + ", " +
                    " SubcontractChangeOrderLastUpdate        = '" + subcontractChangeOrderLastUpdateDate + "', " +
                    " SubcontractChangeOrderOwnerNumber       = '" + subcontractChangeOrderOwnerNumber + "', " + 
                    " SubcontractChangeOrderUserDescription   = '" + subcontractChangeOrderUserDescription + "' " +
                    " WHERE SubcontractChangeOrderID = " + subcontractChangeOrderID;
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
        public static DataSet GetCostCode(string subcontractChangeOrderID, string subcontractID)
        {
            if (subcontractChangeOrderID == "")
                subcontractChangeOrderID = "0";
            if (subcontractID == "")
                subcontractID = "0";

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@SubcontractChangeOrderID", subcontractChangeOrderID);
            par[1] = new SqlParameter("@SubcontractID", subcontractID);


            try
            {
                return DataBaseUtil.ExecuteParDataset("up_JCGetSubcontractCostCodeBySubcontractChangeOrder", CCEApplication.Connection, CommandType.StoredProcedure, par);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet GetSubcontractLog(string subcontractID)
        {
            string query =  " SELECT " +  
                            " SubcontractChangeOrderLogID, " + 
                            " l.SubcontractID, " + 
                            " SubcontractChangeOrderNumber, " + 
                            " SubcontractChangeOrderRequestDate, " +
                            " SubcontractChangeOrderApprovedDate, " +
                            " SubcontractChangeOrderContractAmount, " + 
                            " SubcontractChangeOrderStatus, " + 
                            " SubcontractChangeOrderDescription, " + 
                            " SubcontractChangeOrderOwnerNumber, " + 
                            " SubcontractCostCodeType, " + 
                            " Subcontract  AS TotalCost, " +
	                        " SubcontractNumber, " +
                            " JobNumber, " + 
                            " JobName, " + 
                            " Sub.VendorID, " + 
                            " [Name] AS VendorName, " + 
                            " Description AS ProjectManager, " + 
                            " SubcontractChangeOrderDescriptionGroup " + 
                            " FROM tblSubcontractChangeOrderLog l " +
	                        " INNER JOIN tblSubcontract sub ON l.SubcontractID = sub.SubcontractID " +
                            " INNER JOIN tblJob j ON sub.JobID = j.JobID " + 
                            " LEFT JOIN tblVendor c ON sub.VendorID = c.VendorID " + 
                            " LEFT JOIN tblProjectManager m ON j.ProjectManagerID = m.ProjectManagerID " + 
                            " WHERE sub.SubcontractID =  " + subcontractID + "";

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
