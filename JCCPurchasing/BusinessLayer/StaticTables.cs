using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using ContraCostaElectric.DatabaseUtil;
using BakirAndAssociates.DatabaseUtil;

using System.Reflection;
using System.Threading.Tasks;

//
//

namespace JCCPurchasing.BusinessLayer
{

    public class StaticTables
    {
        public static DataTable PurchasingAgents;
        public static DataTable Vendors;
        public static DataTable Office;
        public static DataTable Department;
        public static DataTable ProjectManager;
        public static bool isloaded = false;
   

        public  static bool PopulateStaticTables()
        {
            try
            {
                PurchasingAgents =  DataBaseUtil.ExecuteDataset("SELECT Distinct PurchasingAgent FROM tblJobPO Order By PurchasingAgent", CCEApplication.Connection, CommandType.Text).Tables[0];
                Vendors =  DataBaseUtil.ExecuteDataset("SELECT VendorID, Name FROM tblVendor ORDER BY Name", CCEApplication.Connection, CommandType.Text).Tables[0];
                Department =  DataBaseUtil.ExecuteDataset("SELECT DepartmentID, DepartmentName FROM tblDepartment ORDER BY DepartmentName", CCEApplication.Connection, CommandType.Text).Tables[0];
                Office =  DataBaseUtil.ExecuteDataset("SELECT OfficeID, OfficeName FROM tblOffice ORDER BY OfficeName", CCEApplication.Connection, CommandType.Text).Tables[0];
                ProjectManager =  DataBaseUtil.ExecuteDataset("SELECT ProjectManagerID, Description As ProjectManager FROM tblProjectManager ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                isloaded = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

    }
}
