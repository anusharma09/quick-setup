using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ContraCostaElectric.DatabaseUtil;

namespace JCCBusinessLayer
{
    public class TaxRate
    {
        private string taxRateID;
        private string location;
        private string taxRate;
        //
        public TaxRate()
        {
        }
        //
        public TaxRate(string taxRateID,
                               string location,
                               string taxRate)
        {
            this.taxRateID = taxRateID;
            this.location = "'" + location.Trim().Replace("'", "''") + "'";
            this.taxRate = String.IsNullOrEmpty(taxRate) ? "Null" : taxRate;
        }
        //
        public string TaxRateID
        {
            get { return taxRateID; }
        }
        //
        public static DataSet GetTaxRates()
        {
            string query = " SELECT * FROM tblTaxRate ORDER BY Location ";
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
        public static bool Remove(string taxRateID)
        {
            string query = "";

            query = "DELETE FROM tblTaxRate WHERE TaxRateID = " + taxRateID;
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
            if (taxRateID == "" || taxRateID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = "INSERT INTO tblTaxRate(" +
                    " Location, " +
                    " TaxRate " +
                    " ) VALUES ( " +
                    location + ", " +
                    taxRate + ") " +
                    "Select SCOPE_IDENTITY()  ";
            try
            {
                taxRateID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = "Update tblTaxRate SET " +
                    " Location                        = " + location + ", " +
                    " TaxRate                         = " + taxRate + " " +
                    " WHERE TaxRateID                 = " + taxRateID;
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
