using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ContraCostaElectric.DatabaseUtil;

namespace JCCContactManagement.BusinessLayer
{
    class StaticTables
    {
        public static DataTable Company;
        public static DataTable Department;
        public static DataTable Industry;
        public static DataTable ReferredBy;
        public static DataTable Status;
        public static DataTable Title;
        public static DataTable Territory;
        public static bool IsLoaded = false;
        //
        public static void PopulateStaticTables()
        {
            PopulateCompany();
            PopulateDepartment();
            PopulateIndustry();
            PopulateReferredBy();
            PopulateStatus();
            PopulateTitle();
            PopulateTerritory();
            IsLoaded = true;
        }
        //
        public static void PopulateCompany()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " CMCompanyID AS [ID], " +
                        " CMCompanyName AS [Description] " +
                        " FROM tblCMCompany " +
                        " ORDER BY CMCompanyName ";
                Company = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulateDepartment()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " CMDepartmentID AS [ID], " +
                        " CMDepartmentDescription AS [Description] " +
                        " FROM tblCMDepartment " +
                        " ORDER BY CMDepartmentDescription ";
                Department = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulateIndustry()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " CMIndustryID AS [ID], " + 
                        " CMIndustryDescription AS [Description] " +
                        " FROM tblCMIndustry " +
                        " ORDER BY CMIndustryDescription ";
                Industry = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulateReferredBy()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        "CMReferredByID AS [ID], " + 
                        " CMReferredByDescription AS [Description] " +
                        " FROM tblCMReferredBy " +
                        " ORDER BY CMReferredByDescription ";
                ReferredBy = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulateStatus()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " CMStatusID AS [ID], " +
                        " CMStatusDescription AS [Description] " +
                        " FROM tblCMStatus " +
                        " ORDER BY CMStatusDescription ";
                Status = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulateTitle()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " CMTitleID AS [ID], " +
                        " CMTitleDescription AS [Description] " +
                        " FROM tblCMTitle " +
                        " ORDER BY CMTitleDescription ";
                Title = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static void PopulateTerritory()
        {
            try
            {
                string query = "";
                query = " SELECT " +
                        " CMTerritoryID AS [ID], " +
                        " CMTerritoryDescription AS [Description] " +
                        " FROM tblCMTerritory " +
                        " ORDER BY CMTerritoryDescription ";
                Territory = DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
