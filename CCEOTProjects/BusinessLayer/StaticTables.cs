using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
// using ContraCostaElectric.DatabaseUtil;
using BakirAndAssociates.DatabaseUtil;
using DevExpress.XtraEditors.Repository;
using System.Threading.Tasks;

namespace CCEOTProjects.BusinessLayer
{
    public class StaticTables
    {
        public static DataTable OTStatus;
        public static DataTable Office;
        public static DataTable Department;
        public static DataTable WorkType;
        public static DataTable AssignedTo;
        public static DataTable UnitType;
        public static DataTable EstimateStatus;
        public static DataTable ProjectStatus;
        public static RepositoryItemLookUpEdit RepLANID;
        //
        public  static bool PopulateStaticTables()
        {
            try
            {
                WorkType =   DataBaseUtil.ExecuteDataset("SELECT WorkTypeID, Description FROM tblWorkType ORDER BY Description", CCEApplication.Connection, CommandType.Text).Tables[0];
                OTStatus = DataBaseUtil.ExecuteDataset(" SELECT * FROM tblOTStatus ", CCEApplication.Connection, CommandType.Text).Tables[0];
                Office =  DataBaseUtil.ExecuteDataset(" SELECT OfficeID, OfficeName AS Name  FROM tblOffice Order By OfficeName ", CCEApplication.Connection, CommandType.Text).Tables[0];
                Department =  DataBaseUtil.ExecuteDataset(" SELECT DepartmentID, DepartmentName AS Name  FROM tblDepartment Order By DepartmentName ", CCEApplication.Connection, CommandType.Text).Tables[0];
                AssignedTo =  DataBaseUtil.ExecuteDataset(" SELECT UserLANID, UserName FROM tblUser WHERE UserName is not Null ORDER By UserName ", CCEApplication.Connection, CommandType.Text).Tables[0];
                UnitType =  DataBaseUtil.ExecuteDataset(" SELECT UnitType AS UnitTypeCode, UnitType FROM tblOTUnitType ORDER BY UnitType ", CCEApplication.Connection, CommandType.Text).Tables[0];
                EstimateStatus =  DataBaseUtil.ExecuteDataset(" SELECT * FROM tblJobStatus WHERE JobStatus <> 'WON' ", CCEApplication.Connection, CommandType.Text).Tables[0];
                ProjectStatus =  DataBaseUtil.ExecuteDataset(" SELECT * FROM tblOTStatus WHERE OTStatusDescription <> 'APPROVED'", CCEApplication.Connection, CommandType.Text).Tables[0];


                DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
                RepLANID = new RepositoryItemLookUpEdit();

                RepLANID.DataSource = AssignedTo;
                RepLANID.DisplayMember = "UserName";
                RepLANID.ValueMember = "UserLANID";
                col.Caption = "User";
                col.FieldName = "UserLANID";
                col.Visible = false;
                RepLANID.Columns.Add(col);
                col1.Caption = "User Name";
                col1.FieldName = "UserName";
                col1.Visible = true;
                RepLANID.Columns.Add(col1);
                RepLANID.NullText = "";
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }
    }
}
