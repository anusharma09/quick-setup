using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ContraCostaElectric.DatabaseUtil;

namespace JCCMaterialOrder.BusinessLayer
{
    class MaterialOrderDetail
    {
        private string jobMaterialOrderDetailID;
        private string jobMaterialOrderID;
        private string quantity;
        private string description;
        private string receivedDate;
        private string neededBy;
        private string vendorID;
        private string poNumber;
        //
        public MaterialOrderDetail()
        {
        }
        //
        public MaterialOrderDetail(string jobMaterialOrderDetailID,
                               string jobMaterialOrderID,
                               string quantity,
                               string description,
                               string receivedDate,
                               string neededBy,
                               string vendorID,
                               string poNumber)
        {
            this.jobMaterialOrderDetailID = jobMaterialOrderDetailID;
            this.jobMaterialOrderID = jobMaterialOrderID;
            this.quantity = String.IsNullOrEmpty(quantity) ? "Null" : quantity;
            this.description = "'" + description.Trim().Replace("'", "''") + "'";
            this.receivedDate = String.IsNullOrEmpty(receivedDate) ? "null" : "'" + receivedDate + "'";
            this.neededBy = String.IsNullOrEmpty(neededBy) ? "null" : "'" + neededBy + "'";
            this.vendorID = "'" + vendorID.Trim().Replace("'", "''") + "'";
            this.poNumber = "'" + poNumber.Trim().Replace("'", "''") + "'";
        }
        //
        public string JobMaterialOrderDetailID
        {
            get { return jobMaterialOrderDetailID; }
        }
        //
        public static DataSet GetJobMaterialOrderItems(string jobMaterialOrderID)
        {
            if (jobMaterialOrderID == "")
                jobMaterialOrderID = "0";

            string query = " SELECT " +
                           " JobMaterialOrderDetailID, " +
                           " Quantity, " +
                           " Description, " +
                           " NeededBy AS [Needed By], " +
                           " DateReceived AS [Received Date], " +
                           " VendorID AS [Vendor], " +
                           " PONumber AS [PO] " +
                           " FROM tblJobMaterialOrderDetail  " +
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
        public static DataSet GetJobMaterialPreviousOrderItems(string jobMaterialOrderID)
        {
            if (jobMaterialOrderID == "")
                jobMaterialOrderID = "0";

            string query = " DECLARE @MyDate  SMALLDATETIME " +
                           " SELECT " +
                           " '' AS JobMaterialOrderDetailID, " +
                           " '' AS Quantity, " +
                           " Description, " +
                           " @MyDate AS [Received Date], " +
                           " '' AS [Vendor], " +
                           " '' AS [PO] " +
                           " FROM tblJobMaterialOrderDetail  " +
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
        public static bool Remove(string jobMaterialOrderDetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobMaterialOrderDetail WHERE JobMaterialOrderDetailID = " + jobMaterialOrderDetailID;
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
        public bool Save()
        {
            if (jobMaterialOrderDetailID == "" || jobMaterialOrderDetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobMaterialOrderDetail(" +
                    " JobMaterialOrderID, " +
                    " Quantity, " +
                    " Description, " +
                    " NeededBy, " +
                    " DateReceived, " +
                    " VendorID, " +
                    " PONumber " +
                    " ) VALUES ( " +
                    jobMaterialOrderID + ", " +
                    quantity + ", " +
                    description + ", " +
                    neededBy + ", " +
                    receivedDate + ", " +
                    vendorID + ", " +
                    poNumber + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobMaterialOrderDetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblJobMaterialOrderDetail SET " +
                    " Quantity                        = " + quantity + ", " +
                    " Description                     = " + description + ", " +
                    " NeededBy                        = " + neededBy + ", " +
                    " DateReceived                    = " + receivedDate + ", " +
                    " VendorID                        = " + vendorID + ", " +
                    " PONumber                        = " + poNumber + " " +
                    " WHERE JobMaterialOrderDetailID        = " + jobMaterialOrderDetailID;
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
