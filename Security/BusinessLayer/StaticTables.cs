using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;
using DevExpress.XtraEditors.Repository;


namespace Security.BusinessLayer
{

    class StaticTables
    {
        public static RepositoryItemLookUpEdit ProjectManager;
        public static RepositoryItemLookUpEdit Estimator;
        public static RepositoryItemLookUpEdit Department;
        public static RepositoryItemLookUpEdit Office;
        public static RepositoryItemLookUpEdit SalesRep;
        public static RepositoryItemLookUpEdit JobTech;
        public static RepositoryItemLookUpEdit Access;
        public static RepositoryItemLookUpEdit AccessLevel;
        public static RepositoryItemLookUpEdit WorkType;
        public static RepositoryItemLookUpEdit AccessTitle;
       
        public static void PopulateStaticTables()
        {

            try
            {
                PopulateOffice();
                PopulateDepartment();
                PopulateProjectManager();
                PopulateEstimator();
                PopulateSalesRep();
                PopulateJobTech();
                PopulateAccess();
                PopulateAccessLevel();
                PopulateAccessTitle();
                PopulateWorkType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        private static void PopulateProjectManager()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            ProjectManager = new RepositoryItemLookUpEdit();
            ProjectManager.DataSource = DataBaseUtil.ExecuteDataset("SELECT ProjectManagerID, Description FROM tblProjectManager ORDER BY Description", Security.Connection, CommandType.Text).Tables[0];
            ProjectManager.DisplayMember = "Description";
            ProjectManager.ValueMember = "ProjectManagerID";
            col.Caption = "ID";
            col.FieldName = "ProjectManagerID";
            col.Visible = false;
            ProjectManager.Columns.Add(col);
            col1.Caption = "Project Manager";
            col1.FieldName = "Description";
            col1.Visible = true;
            ProjectManager.Columns.Add(col1);
            ProjectManager.ShowHeader = false;
            ProjectManager.NullText = "";
        }
        //
        private static void PopulateEstimator()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            Estimator = new RepositoryItemLookUpEdit();
            Estimator.DataSource = DataBaseUtil.ExecuteDataset("SELECT EstimatorID, Description FROM tblEstimator ORDER BY Description", Security.Connection, CommandType.Text).Tables[0];
            Estimator.DisplayMember = "Description";
            Estimator.ValueMember = "EstimatorID";
            col.Caption = "ID";
            col.FieldName = "EstimatorID";
            col.Visible = false;
            Estimator.Columns.Add(col);
            col1.Caption = "Estimator";
            col1.FieldName = "Description";
            col1.Visible = true;
            Estimator.Columns.Add(col1);
            Estimator.ShowHeader = false;
            Estimator.NullText = "";
        }
        //
        private static void PopulateSalesRep()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            SalesRep = new RepositoryItemLookUpEdit();
            SalesRep.DataSource = DataBaseUtil.ExecuteDataset("SELECT SalesRepID, Description FROM tblSalesRep ORDER BY Description", Security.Connection, CommandType.Text).Tables[0];
            SalesRep.DisplayMember = "Description";
            SalesRep.ValueMember = "SalesRepID";
            col.Caption = "ID";
            col.FieldName = "SalesRepID";
            col.Visible = false;
            SalesRep.Columns.Add(col);
            col1.Caption = "SalesRep";
            col1.FieldName = "Description";
            col1.Visible = true;
            SalesRep.Columns.Add(col1);
            SalesRep.ShowHeader = false;
            SalesRep.NullText = "";
        }
        //
        private static void PopulateJobTech()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            JobTech = new RepositoryItemLookUpEdit();
            JobTech.DataSource = DataBaseUtil.ExecuteDataset("SELECT JobTechID, Description FROM tblJobTech ORDER BY Description", Security.Connection, CommandType.Text).Tables[0];
            JobTech.DisplayMember = "Description";
            JobTech.ValueMember = "JobTechID";
            col.Caption = "ID";
            col.FieldName = "JobTechID";
            col.Visible = false;
            JobTech.Columns.Add(col);
            col1.Caption = "JobTech";
            col1.FieldName = "Description";
            col1.Visible = true;
            JobTech.Columns.Add(col1);
            JobTech.ShowHeader = false;
            JobTech.NullText = "";
        }
        private static void PopulateOffice()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            Office = new RepositoryItemLookUpEdit();
            Office.DataSource = DataBaseUtil.ExecuteDataset("SELECT OfficeID, OfficeName FROM tblOffice ORDER BY OfficeName", Security.Connection, CommandType.Text).Tables[0];
            Office.DisplayMember = "OfficeName";
            Office.ValueMember = "OfficeID";
            col.Caption = "ID";
            col.FieldName = "OfficeID";
            col.Visible = false;
            Office.Columns.Add(col);
            col1.Caption = "Office";
            col1.FieldName = "OfficeName";
            col1.Visible = true;
            Office.Columns.Add(col1);
            Office.ShowHeader = false;
            Office.NullText = "";
        }

        private static void PopulateDepartment()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            Department = new RepositoryItemLookUpEdit();
            Department.DataSource = DataBaseUtil.ExecuteDataset("SELECT DepartmentID, DepartmentName FROM tblDepartment ORDER BY DepartmentName", Security.Connection, CommandType.Text).Tables[0];
            Department.DisplayMember = "DepartmentName";
            Department.ValueMember = "DepartmentID";
            col.Caption = "ID";
            col.FieldName = "DepartmentID";
            col.Visible = false;
            Department.Columns.Add(col);
            col1.Caption = "Department";
            col1.FieldName = "DepartmentName";
            col1.Visible = true;
            Department.Columns.Add(col1);
            Department.ShowHeader = false;
            Department.NullText = "";
        }

        private static void PopulateWorkType()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            WorkType = new RepositoryItemLookUpEdit();
            WorkType.DataSource = DataBaseUtil.ExecuteDataset("SELECT WorkTypeID, Description FROM tblWorkType ORDER BY Description", Security.Connection, CommandType.Text).Tables[0];
            WorkType.DisplayMember = "Description";
            WorkType.ValueMember = "WorkTypeID";
            col.Caption = "ID";
            col.FieldName = "WorkTypeID";
            col.Visible = false;
            WorkType.Columns.Add(col);
            col1.Caption = "Work Type";
            col1.FieldName = "Description";
            col1.Visible = true;
            WorkType.Columns.Add(col1);
            WorkType.ShowHeader = false;
            WorkType.NullText = "";
        }

        private static void PopulateAccess()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            Access = new RepositoryItemLookUpEdit();
            Access.DataSource = DataBaseUtil.ExecuteDataset("SELECT AccessID, AccessDescription FROM tblSecAccess ORDER BY AccessDescription", Security.Connection, CommandType.Text).Tables[0];
            Access.DisplayMember = "AccessDescription";
            Access.ValueMember = "AccessID";
            col.Caption = "ID";
            col.FieldName = "AccessID";
            col.Visible = false;
            Access.Columns.Add(col);
            col1.Caption = "Access";
            col1.FieldName = "AccessDescription";
            col1.Visible = true;
            Access.Columns.Add(col1);
            Access.ShowHeader = false;
            Access.NullText = "";
        }

        private static void PopulateAccessLevel()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            AccessLevel = new RepositoryItemLookUpEdit();
            AccessLevel.DataSource = DataBaseUtil.ExecuteDataset("SELECT AccessLevelID, AccessLevelDescription FROM tblSecAccessLevel ORDER BY AccessLevelDescription", Security.Connection, CommandType.Text).Tables[0];
            AccessLevel.DisplayMember = "AccessLevelDescription";
            AccessLevel.ValueMember = "AccessLevelID";
            col.Caption = "ID";
            col.FieldName = "AccessLevelID";
            col.Visible = false;
            AccessLevel.Columns.Add(col);
            col1.Caption = "Access Level";
            col1.FieldName = "AccessLevelDescription";
            col1.Visible = true;
            AccessLevel.Columns.Add(col1);
            AccessLevel.ShowHeader = false;
            AccessLevel.NullText = "";
        }
        private static void PopulateAccessTitle()
        {
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            DevExpress.XtraEditors.Controls.LookUpColumnInfo col1 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo();
            AccessTitle = new RepositoryItemLookUpEdit();
            AccessTitle.DataSource = DataBaseUtil.ExecuteDataset(" SELECT 0 AS TitleID, '' AS Title UNION SELECT TitleID, Title FROM tblSecTitle ORDER BY Title", Security.Connection, CommandType.Text).Tables[0];
            AccessTitle.DisplayMember = "Title";
            AccessTitle.ValueMember = "TitleID";
            col.Caption = "ID";
            col.FieldName = "TitleID";
            col.Visible = false;
            AccessTitle.Columns.Add(col);
            col1.Caption = "Title";
            col1.FieldName = "Title";
            col1.Visible = true;
            AccessTitle.Columns.Add(col1);
            AccessTitle.ShowHeader = false;
            AccessTitle.NullText = "";
        }

    }
}
