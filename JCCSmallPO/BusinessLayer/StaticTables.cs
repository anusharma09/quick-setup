using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;


namespace JCCSmallPO.BusinessLayer
{
    public class StaticTables
    {
        public static DataTable Vendor;
        public static DataTable TaxRate;
        public static DataTable POAddress;
        public static DataTable Terms;
        public static bool IsLoaded = false;
        //
        public static void PopulateStaticTables()
        {
            PopulateVendor();
            PopulateTaxRate();
            PopulatePO();
            PopulateTerms();

            IsLoaded = true;
        }
        //
        public static void PopulateTerms()
        {
            try
            {
                string query = "";
                query = " SELECT  * " +
                        " FROM tblJobSmallPOTerm";
                Terms = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                //
        public static void PopulateVendor()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " VendorID, " +
                        " [Name] " +
                        " FROM tblVendor " +
                        " ORDER BY [Name] ";
                Vendor = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulatePO()
        {
            try
            {
                POAddress = DataBaseUtil.ExecuteDataset("SELECT  Type FROM tblJobPOAddress ORDER BY Type", CCEApplication.Connection, CommandType.Text).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        //
        public static void PopulateTaxRate()
        {
            try
            {
                string query = "";
                query = " SELECT * " +
                        " FROM tblTaxRate " +
                        " ORDER BY Location ";
                TaxRate = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



      
    }
}
