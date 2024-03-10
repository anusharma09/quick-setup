using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ContraCostaElectric.DatabaseUtil;

namespace JCCSmallPO.BusinessLayer
{
    class SmallPODetail
    {
        private string jobSmallPODetailID;
        private string jobSmallPOID;
        private string quantity;
        private string description;
        private string phase;
        private string costCode;
        private string price;
        private string UOM;
        private string taxRate;
        private string amount;
        private string itemNumber;
        //
        public SmallPODetail()
        {
        }
        //
        public SmallPODetail(string jobSmallPODetailID,
                               string jobSmallPOID,
                               string quantity,
                               string description,
                               string phase,
                               string costCode,
                               string price,
                               string UOM,
                               string taxRate,
                               string amount)
        {
            this.jobSmallPODetailID     = jobSmallPODetailID;
            this.jobSmallPOID           = jobSmallPOID;
            this.quantity               = String.IsNullOrEmpty(quantity) ? "Null" : quantity;
            this.description            = "'" + description.Trim().Replace("'", "''") + "'";
            this.phase                  = "'" + phase.Trim().Replace("'", "''") + "'";
            this.costCode               = "'" + costCode.Trim().Replace("'", "''") + "'";
            this.price                  = String.IsNullOrEmpty(price) ? "Null" : price;
            this.UOM                    = String.IsNullOrEmpty(UOM) ? "Null" : UOM;
            this.taxRate                = String.IsNullOrEmpty(taxRate) ? "Null" : taxRate;
            this.amount                 = String.IsNullOrEmpty(amount) ? "Null" : amount;
        }
        //
        public string JobSmallPODetailID
        {
            get { return jobSmallPODetailID; }
        }
        //
        public string ItemNumber
        {
            get { return itemNumber; }
        }
        //
        public static DataSet GetJobSmallPOItems(string jobSmallPOID)
        {
            if (jobSmallPOID == "")
                jobSmallPOID = "0";

            string query = " SELECT " +
                           " JobSmallPODetailID, " +
                           " ItemNumber AS [Line No], " +
                           " Quantity, " +
                           " Description, " +
                           " Phase, " +
                           " CostCode AS [Cost Code], " +
                           " Price, " +
                           " UOM, " +
                           " TaxRate AS [Tax Rate], " +
                           " Amount " +
                           " FROM tblJobSmallPODetail  " +
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
        public static bool Remove(string jobSmallPODetailID)
        {
            string query = "";

            query = "DELETE FROM tblJobSmallPODetail WHERE JobSmallPODetailID = " + jobSmallPODetailID;
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
            if (jobSmallPODetailID == "" || jobSmallPODetailID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblJobSmallPODetail(" +
                    " JobSmallPOID, " +
                    " Quantity, " +
                    " Description, " +
                    " Phase, " +
                    " CostCode, " +
                    " Price, " +
                    " UOM, " +
                    " TaxRate, " +
                    " Amount " +
                    " ) VALUES ( " +
                    jobSmallPOID + ", " +
                    quantity + ", " +
                    description + ", " +
                    phase + ", " +
                    costCode + ", " +
                    price + ", " +
                    UOM + ", " +
                    taxRate + ", " +
                    amount + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                jobSmallPODetailID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
                query = "SELECT ItemNumber FROM tblJobSmallPODetail WHERE JobSmallPODetailID = " + jobSmallPODetailID + " ";
                DataTable t = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
                if (t.Rows.Count > 0)
                    itemNumber = t.Rows[0]["ItemNumber"].ToString();
                
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

            query = "Update tblJobSmallPODetail SET " +
                    " Quantity                        = " + quantity + ", " +
                    " Description                     = " + description + ", " +
                    " Phase                           = " + phase + ", " +
                    " CostCode                        = " + costCode + ", " +
                    " Price                           = " + price + ", " +
                    " UOM                             = " + UOM + ", " +
                    " TaxRate                         = " + taxRate + ", " +
                    " Amount                          = " + amount + " " +
                    " WHERE JobSmallPODetailID        = " + jobSmallPODetailID;
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
