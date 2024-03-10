using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;

namespace JCCSmallPO.BusinessLayer
{
    class SmallPO
    {
        private string smallPONumber;
        private string jobSmallPOID;
        private string jobID;
        private string servCommJobNo;
        private string vendorID;
        private string shipVia;
        private string shipTo;
        private string shipToAddress;
        private string shipToCity;
        private string shipToState;
        private string shipToZip;
        private string note;
        private string shipping;
        private string subtotal;
        private string salesTax;
        private string total;
        private string attachmentA;
        private string noUPSDHL;
        private string notification;
        private string paymentNet30;
        //
        public SmallPO()
        {
        }
        //
        public SmallPO(string jobSmallPOID,
                                string jobID,
                                string servCommJobNo,
                                string vendorID,
                                string shipVia,
                                string shipTo,
                                string shipToAddress,
                                string shipToCity,
                                string shipToState,
                                string shipToZip,
                                string note,
                                string shipping,
                                string subtotal,
                                string salesTax,
                                string total,
                                string attachmentA,
                                string noUPSDHL,
                                string notification,
                                string paymentNet30)
        {
            this.jobSmallPOID       = jobSmallPOID;
            this.jobID              = jobID;
            this.servCommJobNo      = "'" + servCommJobNo.Trim().Replace("'", "''") + "'";
            this.vendorID           = "'" + vendorID.Trim().Replace("'", "''") + "'";
            this.shipVia            = "'" + shipVia.Trim().Replace("'", "''") + "'";
            this.shipTo             = "'" + shipTo.Trim().Replace("'", "''") + "'";
            this.shipToAddress      = "'" + shipToAddress.Trim().Replace("'", "''") + "'";
            this.shipToCity         = "'" + shipToCity.Trim().Replace("'", "''") + "'";
            this.shipToState        = "'" + shipToState.Trim().Replace("'", "''") + "'";
            this.shipToZip          = "'" + shipToZip.Trim().Replace("'", "''") + "'";
            this.note               = "'" + note.Trim().Replace("'", "''") + "'";
            this.shipping           = String.IsNullOrEmpty(shipping) ? "Null" : shipping;
            this.subtotal           = String.IsNullOrEmpty(subtotal) ? "null" : subtotal;
            this.salesTax           = String.IsNullOrEmpty(salesTax) ? "null" : salesTax;
            this.total              = String.IsNullOrEmpty(total) ? "null" : total;
            this.attachmentA        = attachmentA == "True" ? "1" : "0";
            this.noUPSDHL           = noUPSDHL == "True" ? "1" : "0";
            this.notification       = notification == "True" ? "1" : "0";
            this.paymentNet30       = paymentNet30 == "True" ? "1" : "0";
        }
        //
        public string JobSmallPOID
        {
            get { return jobSmallPOID; }
        }
        //
        public string SmallPONumber
        {
            get { return smallPONumber; }
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
        // Updated
        //
        public static DataSet GetJobSmallPOForm(string jobSmallPOID)
        {

            string query = " SELECT " +
                           " JobNumber, " +
                           " ServCommJobNo, " +
                           " SmallPONumber, " +
	                       " ShipTo, " +
	                       " ShipToAddress, " +
	                       " ISNULL(ShipToCity, '') + ', ' + ISNULL(ShipToState, '') + ' ' + ISNULL(ShipToZip, '') AS CityStateZip, " +
	                       " PODate, " +
	                       " ShipVia, " +
	                       " ItemNumber, " +
	                       " Quantity, " +
	                       " Description, " +
	                       " Phase, " +
	                       " CostCode, " +
	                       " Price, " +
	                       " UOM, " +
	                       " TaxRate, " +
	                       " Amount, " +
	                       " Shipping, " +
	                       " Subtotal, " +
	                       " SalesTax, " +
	                       " Total, " +
                           " Note, " +
                           " Name, " +
	                       " Address1, " +
	                       " Address2, " +
	                       " ISNULL(City, '') + ', ' + ISNULL(State, '') + ' ' + ISNULL(ZipCode, '') AS VendorCityStateZip, " +
                           " AttachmentA, " +
                           " NoUPSDHL, " +
                           " Notification, " +
                           " PaymentNet30 " +
                           " FROM tblJobSmallPO s " +
                           " LEFT JOIN tblJobSmallPODetail d " +
                           " ON s.JobSmallPOID = d.JobSmallPOID " +
                           " LEFT JOIN tblVendor v ON s.VendorID = v.VendorID " +
                           " LEFT JOIN tblJob j ON s.JobID = j.JobID " +
                           " WHERE s.JobSmallPOID = " + jobSmallPOID + " ORDER BY ItemNumber";


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
        public static DataSet GetSmallPOList(string where)
        {
            /* Updated */
            string query = " SELECT " +
	                       " JobSmallPOID, " +
	                       " SmallPONumber AS [PO No], " + 
	                       " JobNumber AS [Job], " +
                           " ServCommJobNo AS [ServComm Job], " +
	                       " LTRIM(RTRIM(ISNULL(ShipToAddress, ''))) " +
		                   "     AS [Ship To Address], " +
	                       " LTRIM(RTRIM(ISNULL(ShipToCity, ''))) + ', ' + LTRIM(RTRIM(ISNULL(ShipToState, ''))) + ' ' + LTRIM(RTRIM(ISNULL(ShipToZip, ''))) " +
	                       " AS [Ship To City/State/Zip], " +
	                       " PODate AS [PO Date], " +
	                       " UserName  AS [Created By], " + 
	                       " m.Description AS [Project Manager] " + 
	                       " FROM tblJobSmallPO r " +
	                       " LEFT JOIN tblJob j ON r.JobID = j.JobID " + 
	                       " LEFT JOIN tblProjectManager m ON m.ProjectManagerID = j.ProjectManagerID " + 
	                       " LEFT JOIN tblUSer u ON r.CreatedBy = u.UserLanID  " +
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
        public static DataSet GetJobSmallPO(string jobID)
        {
            string query = "";

            query = " SELECT " +
                    " JobSmallPOID, " +
                    " SmallPONumber AS [PO Number], " +
                    " p.VendorID	AS [Vendor ID], " +
                    " Name		AS [Vendor Name], " +
                    " PODate		AS [PO Date], " +
                    " Shipping, " +
                    " Subtotal, " +
                    " SalesTax	    AS [Sales Tax], " +
                    " Total " +
                    " FROM tblJobSmallPO p " +
                    " LEFT JOIN tblVendor v ON p.VendorID = v.VendorID " +
                    " WHERE p.JobID = " + jobID + " ";
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
        // Updated
        //
        public static string GetJobID(string jobNumber)
        {
            string query = "";
            bool ret = false;
            string jobID = "0";
            DataTable t;
            if (jobNumber == "")
                jobNumber = "0";



            if (Security.Security.UserJCCSmallPOAccess == Security.Security.Access.JCCSmallPOAdmin)
            {
                query = "SELECT JobID FROM tblJob WHERE JobNumber = '" + jobNumber + "'";
            }
            else
            {
                query = " SELECT JobID " +
                        " FROM tblJob " +
                        " WHERE JobNumber = '" + jobNumber + "'" +
                        " AND [dbo].[GetUserJobAccess](JobID,'" + Security.Security.LoginID + "')  = 1 ";
            }

            try
            {
                t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
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
        // Updated
        //
        public static DataSet GetSmallPONote(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            string query = "SELECT SmallPONote " +
                " FROM tblJobDefaultValues" +
                " WHERE JobID = " + jobID + " ";

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
        // Updated
        //
        public static DataSet GetSmallPO(string jobSmallPOID)
        {
            if (jobSmallPOID == "")
                jobSmallPOID = "0";

            string query = "SELECT r.*, " +
                    " JobNumber, " +
                    " u.UserName AS CreatedByName " +
                " FROM tblJobSmallPO r" +
                " LEFT JOIN tblJob j ON r.JobID = j.JobID " +
                " LEFT JOIN tblUser u ON r.CreatedBy = u.UserLanID " +
                " WHERE JobSmallPOID = " + jobSmallPOID + " ";

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
        // Update
        //
        public static DataSet GetCreatUpdate(string jobSmallPOID)
        {
            if (jobSmallPOID == "")
                jobSmallPOID = "0";

            string query = "SELECT SmallPONumber, r.PODate, " +
                    " u.UserName AS CreatedByName " +
                " FROM tblJobSmallPO r" +
                " LEFT JOIN tblUser u ON r.CreatedBy = u.UserLanID " +
                " WHERE JobSmallPOID = " + jobSmallPOID + " ";

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
        public static DataSet GetShipToAddress(string jobID)
        {
            if (jobID == "")
                jobID = "0";

            string query = "SELECT JobName, JobAddress1, JobCity, JobState, JobZip " +
                " FROM tblJob " +
                " WHERE JobID = " + jobID + " ";

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
        // Updated
        //
        public static bool Remove(string jobSmallPOID)
        {
            string query = "";

            query = "DELETE FROM tblJobSmallPODetail WHERE JobSmallPOID = " + jobSmallPOID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                query = "DELETE FROM tblJobSmallPO WHERE JobSmallPOID = " + jobSmallPOID;
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        // Updated
        //
        public bool Save()
        {
            if (jobSmallPOID == "" || jobSmallPOID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSmallPO(" +
                    " JobID, " +  
                    " ServCommJobNo, " +
                    " VendorID, " +
                    " PODate, " +        
                    " ShipVia, " +       
                    " ShipTo, " +        
                    " ShipToAddress, " + 
                    " ShipToCity, " +    
                    " ShipToState, " +   
                    " ShipToZip, " +     
                    " Note, " +          
                    " Shipping, " +      
                    " Subtotal, " +      
                    " SalesTax, " +      
                    " Total, " +         
                    " CreatedBy, " +
                    " AttachmentA, " +
                    " NoUPSDHL, " +
                    " Notification, " +
                    " PaymentNet30 " +
                    " ) VALUES ( " +
                    jobID + ", " +    
                    servCommJobNo + ", " +
                    vendorID + ", " +
                    "'" + DateTime.Now.ToShortDateString() + "', " +
                    shipVia + ", " +      
                    shipTo + ", " +        
                    shipToAddress + ", " + 
                    shipToCity + ", " +    
                    shipToState + ", " +   
                    shipToZip + ", " +     
                    note + ", " +         
                    shipping + ", " +      
                    subtotal + ", " +      
                    salesTax + ", " +      
                    total + ", " +
                    "'" + Security.Security.LoginID + "', " + 
                    attachmentA + ", " +
                    noUPSDHL + ", " +
                    notification + ", " +
                    paymentNet30 + "  " +      
                    ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSmallPOID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        // Updated
        private bool Update()
        {
            string query = "";

            query = "Update tblJobSmallPO           SET " +
                    " JobID                           = " + jobID + ", " +
                    " ServCommJobNo                   = " + servCommJobNo + ", " +
                    " VendorID                        = " + vendorID + ", " +
                    " ShipVia                         = " + shipVia + ", " +
                    " ShipTo                          = " + shipTo + ", " +
                    " ShipToAddress                   = " + shipToAddress + ", " +
                    " ShipToCity                      = " + shipToCity + ", " +
                    " ShipToState                     = " + shipToState + ", " +
                    " ShipToZip                       = " + shipToZip + ", " +
                    " Note                            = " + note + ", " +    
                    " Shipping                        = " + shipping + ", " + 
                    " Subtotal                        = " + subtotal + ", " + 
                    " SalesTax                        = " + salesTax + ", " + 
                    " Total                           = " + total + ", " +
                    " AttachmentA                     = " + attachmentA + ", " +
                    " NoUPSDHL                        = " + noUPSDHL + ", " +
                    " Notification                    = " + notification + ", " +
                    " PaymentNet30                    = " + paymentNet30 + " " +
                    " WHERE JobSmallPOID              = " + jobSmallPOID;
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
