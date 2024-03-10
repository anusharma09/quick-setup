using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;

namespace JCCEquipmentRental.BusinessLayer
{
    class StaticTables
    {
        public static DataTable Vendor;
        public static bool IsLoaded = false;
        //
        public static void PopulateStaticTables()
        {
            PopulateVendor();
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
    }
}
