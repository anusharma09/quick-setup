using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;


namespace JCCMaterialOrder.BusinessLayer
{
    public class StaticTables
    {
        public static DataTable Vendor;
        public static DataTable POAddress;
        public static bool IsLoaded = false;
        //
        public static void PopulateStaticTables()
        {
            PopulateVendor();
            PopulatePO();
            IsLoaded = true;
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
    }
}
