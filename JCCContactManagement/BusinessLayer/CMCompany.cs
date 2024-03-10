using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMCompany
    {
        private string cmCompanyID;
        private string cmCompanyParentID;
        private string cmCompanySystemID;
        private string cmCompanyAlphaName;
        private string cmCompanyName;
        private string cmCompanyAddress;
        private string cmCompanyAddress2;
        private string cmCompanyCity;
        private string cmCompanyState;
        private string cmCompanyZip;
        private string cmCompanyCountry;
        private string cmCompanyPhone;
        private string cmCompanyFax;
        private string cmCompanyTollFree;
        private string cmCompanyWebSite;
        private string cmCompanyStatus;
        private string cmCompanyReferredBy;
        private string cmCompanyDivision;
        private string cmCompanyIndustry;
        private string cmCompanyRevenue;
        private string cmCompanyNumberOfEmployees;
        private string cmCompanyRegion;
        private string cmCompanyTerritory;
        private string cmCompanyDescription;
        private string cmCompanyCreateDate;
        private string cmCompanyCreateBy;
        private string cmCompanyEditDate;
        private string cmCompanyEditBy;
        //
        public string CMCompanyID
        {
            get { return cmCompanyID; }
        }
        //
        public CMCompany()
        {
        }
        //
        public CMCompany(string cmCompanyID,
                         string cmCompanyParentID,
                         string cmCompanySystemID,
                         string cmCompanyAlphaName,
                         string cmCompanyName,
                         string cmCompanyAddress,
                         string cmCompanyAddress2,
                         string cmCompanyCity,
                         string cmCompanyState,
                         string cmCompanyZip,
                         string cmCompanyCountry,
                         string cmCompanyPhone,
                         string cmCompanyFax,
                         string cmCompanyTollFree,
                         string cmCompanyWebSite,
                         string cmCompanyStatus,
                         string cmCompanyReferredBy,
                         string cmCompanyDivision,
                         string cmCompanyIndustry,
                         string cmCompanyRevenue,
                         string cmCompanyNumberOfEmployees,
                         string cmCompanyRegion,
                         string cmCompanyTerritory,
                         string cmCompanyDescription,
                         string cmCompanyCreateDate,
                         string cmCompanyCreateBy,
                         string cmCompanyEditDate,
                         string cmCompanyEditBy)
        {
            this.cmCompanyID                            = cmCompanyID;
            this.cmCompanyParentID                      = String.IsNullOrEmpty(cmCompanyParentID) ? "null" : cmCompanyParentID;
            this.cmCompanySystemID                      = cmCompanySystemID.Trim().Replace("'", "''");
            this.cmCompanyAlphaName                     = cmCompanyAlphaName.Trim().Replace("'", "''");
            this.cmCompanyName                          = cmCompanyName.Trim().Replace("'", "''");
            this.cmCompanyAddress                       = cmCompanyAddress.Trim().Replace("'", "''");
            this.cmCompanyAddress2                      = cmCompanyAddress2.Trim().Replace("'", "''");
            this.cmCompanyCity                          = cmCompanyCity.Trim().Replace("'", "''");
            this.cmCompanyState                         = cmCompanyState.Trim().Replace("'", "''");
            this.cmCompanyZip                           = cmCompanyZip.Trim().Replace("'", "''");
            this.cmCompanyCountry                       = cmCompanyCountry.Trim().Replace("'", "''");
            this.cmCompanyPhone                         = cmCompanyPhone.Trim().Replace("'", "''");
            this.cmCompanyFax                           = cmCompanyFax.Trim().Replace("'", "''");
            this.cmCompanyTollFree                      = cmCompanyTollFree.Trim().Replace("'", "''");
            this.cmCompanyWebSite                       = cmCompanyWebSite.Trim().Replace("'", "''");
            this.cmCompanyStatus                        = String.IsNullOrEmpty(cmCompanyStatus) ? "null" : cmCompanyStatus;
            this.cmCompanyReferredBy                    = String.IsNullOrEmpty(cmCompanyReferredBy) ? "null" : cmCompanyReferredBy;
            this.cmCompanyDivision                      = cmCompanyDivision.Trim().Replace("'", "''");
            this.cmCompanyIndustry                      = String.IsNullOrEmpty(cmCompanyIndustry) ? "null" : cmCompanyIndustry;
            this.cmCompanyRevenue                       = String.IsNullOrEmpty(cmCompanyRevenue) ? "null" : cmCompanyRevenue.Replace("(", "-").Replace(")", "").Replace(",", "").Replace("$", "");
            this.cmCompanyNumberOfEmployees             = String.IsNullOrEmpty(cmCompanyNumberOfEmployees) ? "null" : cmCompanyNumberOfEmployees.Replace("(", "-").Replace(")", "").Replace(",", "").Replace("$", "");
            this.cmCompanyRegion                        = cmCompanyRegion.Trim().Replace("'", "''");
            this.cmCompanyTerritory                     = String.IsNullOrEmpty(cmCompanyTerritory) ? "null" : cmCompanyTerritory;
            this.cmCompanyDescription                   = cmCompanyDescription.Trim().Replace("'", "''");
            this.cmCompanyCreateDate                    = String.IsNullOrEmpty(cmCompanyCreateDate) ? "null" : "'" + cmCompanyCreateDate + "'";
            this.cmCompanyCreateBy                      = cmCompanyCreateBy.Trim().Replace("'","''");
            this.cmCompanyEditDate                      = String.IsNullOrEmpty(cmCompanyEditDate) ? "null" : "'" + cmCompanyEditDate + "'";
            this.cmCompanyEditBy                        = cmCompanyEditBy.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmCompanyID == "" || cmCompanyID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = " INSERT INTO tblCMCompany( " +
                    " CMCompanyParentID, " + 
                    " CMCompanySystemID, " +
                    " CMCompanyAlphaName, " +
                    " CMCompanyName, " +         
                    " CMCompanyAddress, " +               
                    " CMCompanyAddress2, " +              
                    " CMCompanyCity, " +                  
                    " CMCompanyState, " +                 
                    " CMCompanyZip, " +                  
                    " CMCompanyCountry, " +               
                    " CMCompanyPhone, " +                 
                    " CMCompanyFax, " +                   
                    " CMCompanyTollFree, " +              
                    " CMCompanyWebSite, " +               
                    " CMCompanyStatus, " +                
                    " CMCompanyReferredBy, " +            
                    " CMCompanyDivision, " +              
                    " CMCompanyIndustry, " +              
                    " CMCompanyRevenue, " +               
                    " CMCompanyNumberOfEmployees, " +     
                    " CMCompanyRegion, " +                
                    " CMCompanyTerritory, " +             
                    " CMCompanyDescription, " +           
                    " CMCompanyCreateDate, " +            
                    " CMCompanyCreateBy, " +              
                    " CMCompanyEditDate, " +              
                    " CMCompanyEditBy) VALUES ( " +                
                    cmCompanyParentID + ", " +   
                    "'" + cmCompanySystemID + "', " +
                    "'" + cmCompanyAlphaName + "', " +
                    "'" + cmCompanyName + "', " +                  
                    "'" + cmCompanyAddress + "', " +               
                    "'" + cmCompanyAddress2 + "', " +              
                    "'" + cmCompanyCity + "', " +                 
                    "'" + cmCompanyState + "', " +                 
                    "'" + cmCompanyZip + "', " +                  
                    "'" + cmCompanyCountry + "', " +               
                    "'" + cmCompanyPhone + "', " +                
                    "'" + cmCompanyFax + "', " +                  
                    "'" + cmCompanyTollFree + "', " +              
                    "'" + cmCompanyWebSite  + "', " +              
                    cmCompanyStatus + ", " +                
                    cmCompanyReferredBy + ", " +            
                    "'" + cmCompanyDivision + "', " +              
                    cmCompanyIndustry + ", " +              
                    cmCompanyRevenue + ", " +               
                    cmCompanyNumberOfEmployees + ", " +     
                    "'" + cmCompanyRegion + "', " +                
                    cmCompanyTerritory + ", " +             
                    "'" + cmCompanyDescription + "', " +           
                    cmCompanyCreateDate + ", " +            
                    "'" + cmCompanyCreateBy + "', " +              
                    cmCompanyEditDate + ", " +              
                    "'" + cmCompanyEditBy + "') " +                
                    "Select @@IDENTITY ";
            try
            {
                cmCompanyID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMCompany SET " +
                    " CMCompanyParentID                     =  " + cmCompanyParentID + ", " +  
                    " CMCompanySystemID                     = '" + cmCompanySystemID + "', " +
                    " CMCompanyAlphaName                    = '" + cmCompanyAlphaName + "', " +
                    " CMCompanyName                         = '" + cmCompanyName + "', " +              
                    " CMCompanyAddress                      = '" + cmCompanyAddress + "', " +           
                    " CMCompanyAddress2                     = '" + cmCompanyAddress2 + "', " +          
                    " CMCompanyCity                         = '" + cmCompanyCity + "', " +              
                    " CMCompanyState                        = '" + cmCompanyState + "', " +             
                    " CMCompanyZip                          = '" + cmCompanyZip + "', " +              
                    " CMCompanyCountry                      = '" + cmCompanyCountry + "', " +           
                    " CMCompanyPhone                        = '" + cmCompanyPhone + "', " +             
                    " CMCompanyFax                          = '" + cmCompanyFax + "', " +               
                    " CMCompanyTollFree                     = '" + cmCompanyTollFree + "', " +          
                    " CMCompanyWebSite                      = '" + cmCompanyWebSite  + "', " +          
                    " CMCompanyStatus                       =  " + cmCompanyStatus + ", " +                
                    " CMCompanyReferredBy                   =  " + cmCompanyReferredBy + ", " +            
                    " CMCompanyDivision                     = '" + cmCompanyDivision + "', " +          
                    " CMCompanyIndustry                     =  " + cmCompanyIndustry + ", " +              
                    " CMCompanyRevenue                      =  " + cmCompanyRevenue + ", " +               
                    " CMCompanyNumberOfEmployees            =  " + cmCompanyNumberOfEmployees + ", " +     
                    " CMCompanyRegion                       = '" + cmCompanyRegion + "', " +            
                    " CMCompanyTerritory                    =  " + cmCompanyTerritory + ", " +             
                    " CMCompanyDescription                  = '" + cmCompanyDescription + "', " +       
                    " CMCompanyCreateDate                   =  " + cmCompanyCreateDate + ", " +            
                    " CMCompanyCreateBy                     = '" + cmCompanyCreateBy + "', " +          
                    " CMCompanyEditDate                     =  " + cmCompanyEditDate + ", " +              
                    " CMCompanyEditBy                       = '" + cmCompanyEditBy + "' " +            
                    " WHERE CMCompanyID                     =  " + cmCompanyID;

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
        public static void Delete(string cmCompanyID)
        {
            string query = "Delete FROM tblCMCompany WHERE CMCompanyID = " + cmCompanyID;
            try
            {
                DataBaseUtil.ExecuteNonQuery(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public static DataSet GetCMCompanyList(string where)
        {
            string query = "";

            query = " SELECT CMCompanyID, " +
                   // " CMCompanyParentID          AS [Parent Company], " +  
                    " CMCompanySystemID          AS [Company ID], " +
                    " CMCompanyAlphaName         AS [Alpha Name], " +
                    " CMCompanyName              AS [Company Name], " +         
                    " CMCompanyAddress           AS [Address], " +            
                    " CMCompanyAddress2          AS [Address2], " +           
                    " CMCompanyCity              AS [City], " +               
                    " CMCompanyState             AS [State], " +              
                    " CMCompanyZip               AS [Zip], " +               
                   // " CMCompanyCountry           AS [Country], " +            
                    " CMCompanyPhone             AS [Phone], " +              
                    " CMCompanyFax               AS [Fax], " +                
                   // " CMCompanyTollFree          AS [Toll Free], " +           
                   // " CMCompanyWebSite           AS [Web Site], " +            
                    " CMStatusDescription        AS [Status], " +             
                    " CMReferredByDescription    AS [Referred By], " +         
                   // " CMCompanyDivision          AS [Division], " +           
                    " CMIndustryDescription      AS [Industry], " +           
                   // " CMCompanyRevenue           AS [Revenue], " +            
                   // " CMCompanyNumberOfEmployees AS [Number of Emp], " +  
                    " CMCompanyRegion            AS [Region], " +
                    " CMTerritoryDescription     AS [Territory], " +          
                   // " CMCompanyDescription       AS [Description], " +       
                   // " CMCompanyCreateDate        AS [Create Date], " +         
                   // " CMCompanyCreateBy          AS [Create By], " +           
                   // " CMCompanyEditDate          AS [Edit Date], " +
                   // " CMCompanyEditBy            AS [Edit By], " +
                    " IsCustomer                 AS [Is Customer], " +
                    " IsVendor                   AS [Is Vendor] " + 
                    " FROM tblCMCompany c " +
                    " LEFT JOIN tblCMStatus s ON c.CMCompanyStatus = s.CMStatusID " +
                    " LEFT JOIN tblCMReferredBy r ON c.CMCompanyReferredBy = r.CMReferredByID " +
                    " LEFT JOIN tblCMIndustry i ON c.CMCompanyIndustry = i.CMIndustryID " +
                    " LEFT JOIN tblCMTerritory t ON c.CMCompanyTerritory = t.CMTerritoryID " + 
                    where + " " +
                    " ORDER BY CMCompanyName ";
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
        public static DataSet GetCMCompany(string CMCompanyID)
        {
            string query = "";

            query = " SELECT CMCompanyID, " +
                    " CMCompanyParentID          AS [Parent Company], " +
                    " CMCompanySystemID          AS [Company ID], " +
                    " CMCompanyAlphaName         AS [Alpha Name], " +
                    " CMCompanyName              AS [Company Name], " +
                    " CMCompanyAddress           AS [Address], " +
                    " CMCompanyAddress2          AS [Address2], " +
                    " CMCompanyCity              AS [City], " +
                    " CMCompanyState             AS [State], " +
                    " CMCompanyZip               AS [Zip], " +
                    " CMCompanyCountry           AS [Country], " +
                    " CMCompanyPhone             AS [Phone], " +
                    " CMCompanyFax               AS [Fax], " +
                    " CMCompanyTollFree          AS [Toll Free], " +
                    " CMCompanyWebSite           AS [Web Site], " +
                    " CMCompanyStatus            AS [Status], " +
                    " CMCompanyReferredBy        AS [Referred By], " +
                    " CMCompanyDivision          AS [Division], " +
                    " CMCompanyIndustry          AS [Industry], " +
                    " CMCompanyRevenue           AS [Revenue], " +
                    " CMCompanyNumberOfEmployees AS [Number of Emp], " +
                    " CMCompanyRegion            AS [Region], " +
                    " CMCompanyTerritory         AS [Territory], " +
                    " CMCompanyDescription       AS [Description], " +
                    " CMCompanyCreateDate        AS [Create Date], " +
                    " CMCompanyCreateBy          AS [Create By], " +
                    " CMCompanyEditDate          AS [Edit Date], " +
                    " CMCompanyEditBy            AS [Edit By], " +
                    " IsCustomer                 AS [Is Customer], " +
                    " IsVendor                   AS [Is Vendor] " +
                    " FROM  tblCMCompany  " +
                    " WHERE CMCompanyID = " + CMCompanyID + " ";
            try
            {
                return DataBaseUtil.ExecuteDataset(query, CCEApplication.Connection, CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
