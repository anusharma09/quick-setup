using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContraCostaElectric.DatabaseUtil;
using System.IO;

namespace JCCContactManagement.BusinessLayer
{
    public class CMContact
    {
        private string cmContactID;
        private string cmCompanyID;
        private string cmContactLastName;
        private string cmContactFirstName;
        private string cmContactInitial;
        private string cmContactSalutation;
        private string cmContactKeyContact;
        private string cmLotusNotes;
        private string cmContactTitle;
        private string cmContactDepartment;
        private string cmContactStatus;
        private string cmContactReferredBy;
        private string cmContactPhone;
        private string cmContactPhoneExtension;
        private string cmContactMobile;
        private string cmContactFax;
        private string cmContactEmail;
        private string cmContactWebSite;
        private string cmContactAddress;
        private string cmContactAddress2;
        private string cmContactCity;
        private string cmContactState;
        private string cmContactZip;
        private string cmContactCountry;
        private string cmContactCreateDate;
        private string cmContactCreateBy;
        private string cmContactEditDate;
        private string cmContactEditBy;
        //
        public string CMContactID
        {
            get { return cmContactID; }
        }
        //
        public CMContact()
        {
        }
        //
        public CMContact(string cmContactID,
                         string cmCompanyID,
                         string cmContactLastName,
                         string cmContactFirstName,
                         string cmContactInitial,
                         string cmContactSalutation,
                         string cmContactKeyContact,
                         string cmLotusNotes,
                         string cmContactTitle,
                         string cmContactDepartment,
                         string cmContactStatus,
                         string cmContactReferredBy,
                         string cmContactPhone,
                         string cmContactPhoneExtension,
                         string cmContactMobile,
                         string cmContactFax,
                         string cmContactEmail,
                         string cmContactWebSite,
                         string cmContactAddress,
                         string cmContactAddress2,
                         string cmContactCity,
                         string cmContactState,
                         string cmContactZip,
                         string cmContactCountry,
                         string cmContactCreateDate,
                         string cmContactCreateBy,
                         string cmContactEditDate,
                         string cmContactEditBy)
        {
            this.cmContactID                = String.IsNullOrEmpty(cmContactID) ? "" : cmContactID;
            this.cmCompanyID                = String.IsNullOrEmpty(cmCompanyID) ? "null" : cmCompanyID;
            this.cmContactLastName          = cmContactLastName.Trim().Replace("'","''");
            this.cmContactFirstName         = cmContactFirstName.Trim().Replace("'", "''");
            this.cmContactInitial           = cmContactInitial.Trim().Replace("'", "''");
            this.cmContactSalutation        = cmContactSalutation.Trim().Replace("'", "''");
            this.cmContactKeyContact        = cmContactKeyContact == "True" ? "1" : "0";
            this.cmLotusNotes               = cmLotusNotes == "True" ? "1" : "0";
            this.cmContactTitle             = String.IsNullOrEmpty(cmContactTitle) ? "null" : cmContactTitle;
            this.cmContactDepartment        = String.IsNullOrEmpty(cmContactDepartment) ? "null" : cmContactDepartment;
            this.cmContactStatus            = String.IsNullOrEmpty(cmContactStatus) ? "null" : cmContactStatus;
            this.cmContactReferredBy        = String.IsNullOrEmpty(cmContactReferredBy) ? "null" : cmContactReferredBy;
            this.cmContactPhone             = cmContactPhone.Trim().Replace("'","''");
            this.cmContactPhoneExtension    = cmContactPhoneExtension.Trim().Replace("'","''");
            this.cmContactMobile            = cmContactMobile.Trim().Replace("'","''");
            this.cmContactFax               = cmContactFax.Trim().Replace("'","''");
            this.cmContactEmail             = cmContactEmail.Trim().Replace("'","''");
            this.cmContactWebSite           = cmContactWebSite.Trim().Replace("'","''");
            this.cmContactAddress           = cmContactAddress.Trim().Replace("'","''");
            this.cmContactAddress2          = cmContactAddress2.Trim().Replace("'","''");
            this.cmContactCity              = cmContactCity.Trim().Replace("'","''");
            this.cmContactState             = cmContactState.Trim().Replace("'","''");
            this.cmContactZip               = cmContactZip.Trim().Replace("'","''");
            this.cmContactCountry           = cmContactCountry.Trim().Replace("'","''");
            this.cmContactCreateDate        = String.IsNullOrEmpty(cmContactCreateDate) ? "null" : "'" + cmContactCreateDate + "'";
            this.cmContactCreateBy          = cmContactCreateBy.Trim().Replace("'","''");
            this.cmContactEditDate          = String.IsNullOrEmpty(cmContactEditDate) ? "null" : "'" + cmContactEditDate + "'";
            this.cmContactEditBy            = cmContactEditBy.Trim().Replace("'", "''");
        }
        // 
        public bool Save()
        {
            if (cmContactID == "" || cmContactID == "0")
                return Insert();
            else
                return Update();
        }
        //
        private bool Insert()
        {
            string query = "";

            query = " INSERT INTO tblCMContact( " + 
                    " CMCompanyID, " +              
                    " CMContactLastName, " +
                    " CMContactFirstName, " +
                    " CMContactInitial, " +
                    " CMContactSalutation, " +      
                    " CMContactKeyContact, " + 
                    " CMLotusNotes, " +
                    " CMContactTitle, " +           
                    " CMContactDepartment, " +      
                    " CMContactStatus, " +          
                    " CMContactReferredBy, " +      
                    " CMContactPhone, " +           
                    " CMContactPhoneExtension, " +  
                    " CMContactMobile, " +          
                    " CMContactFax, " +             
                    " CMContactEmail, " +           
                    " CMContactWebSite, " +         
                    " CMContactAddress, " +         
                    " CMContactAddress2, " +        
                    " CMContactCity, " +            
                    " CMContactState, " +           
                    " CMContactZip, " +             
                    " CMContactCountry, " +         
                    " CMContactCreateDate, " +      
                    " CMContactCreateBy, " +        
                    " CMContactEditDate, " +        
                    " CMContactEditBy) VALUES ( " +          
                    cmCompanyID + ", " +              
                    "'" + cmContactLastName + "', " +  
                    "'" + cmContactFirstName + "', " +
                    "'" + cmContactInitial + "', " +
                    "'" + cmContactSalutation + "', " +      
                    cmContactKeyContact + ", " + 
                    cmLotusNotes + ", " +
                    cmContactTitle + ", " +           
                    cmContactDepartment + ", " +      
                    cmContactStatus + ", " +          
                    cmContactReferredBy + ", " +      
                    "'" + cmContactPhone + "', " +           
                    "'" + cmContactPhoneExtension + "', " +  
                    "'" + cmContactMobile + "', " +          
                    "'" + cmContactFax + "', " +             
                    "'" + cmContactEmail + "', " +           
                    "'" + cmContactWebSite + "', " +         
                    "'" + cmContactAddress + "', " +        
                    "'" + cmContactAddress2 + "', " +        
                    "'" + cmContactCity + "', " +            
                    "'" + cmContactState + "', " +           
                    "'" + cmContactZip + "', " +             
                    "'" + cmContactCountry + "', " +        
                    cmContactCreateDate + ", " +      
                    "'" + cmContactCreateBy + "', " +        
                    cmContactEditDate + ", " +        
                    "'" + cmContactEditBy + "') " +          
                    "Select @@IDENTITY ";

            try
            {
                cmContactID = DataBaseUtil.ExecuteScalar(query, CCEApplication.Connection, CommandType.Text).ToString();
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

            query = " Update tblCMContact SET " +
                    " CMCompanyID               =  " + cmCompanyID + ", " +
                    " CMContactLastName         = '" + cmContactLastName + "', " +
                    " CMContactFirstName        = '" + cmContactFirstName + "', " +
                    " CMContactInitial          = '" + cmContactInitial + "', " +
                    " CMContactSalutation       = '" + cmContactSalutation + "', " +
                    " CMContactKeyContact       =  " + cmContactKeyContact + ", " +
                    " CMLotusNotes              =  " + cmLotusNotes + ", " +
                    " CMContactTitle            =  " + cmContactTitle + ", " +
                    " CMContactDepartment       =  " + cmContactDepartment + ", " +
                    " CMContactStatus           =  " + cmContactStatus + ", " +
                    " CMContactReferredBy       =  " + cmContactReferredBy + ", " +
                    " CMContactPhone            = '" + cmContactPhone + "', " +
                    " CMContactPhoneExtension   = '" + cmContactPhoneExtension + "', " +
                    " CMContactMobile           = '" + cmContactMobile + "', " +
                    " CMContactFax              = '" + cmContactFax + "', " +
                    " CMContactEmail            = '" + cmContactEmail + "', " +
                    " CMContactWebSite          = '" + cmContactWebSite + "', " +
                    " CMContactAddress          = '" + cmContactAddress + "', " +
                    " CMContactAddress2         = '" + cmContactAddress2 + "', " +
                    " CMContactCity             = '" + cmContactCity + "', " +
                    " CMContactState            = '" + cmContactState + "', " +
                    " CMContactZip              = '" + cmContactZip + "', " +
                    " CMContactCountry          = '" + cmContactCountry + "', " +
                    " CMContactCreateDate       =  " + cmContactCreateDate + ", " +
                    " CMContactCreateBy         = '" + cmContactCreateBy + "', " +
                    " CMContactEditDate         =  " + cmContactEditDate + ", " +
                    " CMContactEditBy           = '" + cmContactEditBy + "' " +        
                    " WHERE CMContactID            = " + cmContactID;

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
        public static void Delete(string cmContactID)
        {
            string query = "Delete FROM tblCMContact WHERE CMContactID = " + cmContactID;
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
        public static DataSet GetCMCompanyContacts(string companyID)
        {
            string query = "";

            query = " SELECT CMContactID, " +
                    " LTRIM(RTRIM(CMContactFirstName)) + ' ' + LTRIM(RTRIM(CMContactInitial)) + ' ' +LTRIM(RTRIM(CMContactLastName))   AS [Contact], " +
                    " CMContactSalutation       AS [Salutation], " +
                    " CMContactKeyContact       AS [Key Contact], " +
                    " CMTitleDescription        AS [Title], " +
                    " CMDepartmentDescription   AS [Department], " +
                    " CMContactPhone            AS [Phone], " +
                    " CMContactPhoneExtension   AS [Ext], " +
                    " CMContactMobile           AS [Mobile], " +
                    " CMContactFax              AS [Fax] " +
                    " FROM  tblCMContact cc  " +
                    " LEFT JOIN tblCMTitle tt ON cc.CMContactTitle = tt.CMTitleID " +
                    " LEFT JOIN tblCMDepartment d ON cc.CMContactDepartment = d.CMDepartmentID " +
                    " WHERE cc.CMCompanyID = " + companyID + " " +
                    " ORDER BY CMContactLastName ";
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
        public static DataSet GetCMContactList(string where)
        {            
            string query = "";

            query = " SELECT CMContactID, " +
                    " LTRIM(RTRIM(CMContactFirstName)) + ' ' + LTRIM(RTRIM(CMContactInitial)) + ' ' +LTRIM(RTRIM(CMContactLastName))   AS [Contact], " +
                    " CMContactSalutation       AS [Salutation], " +    
                    " CMContactKeyContact       AS [Key Contact], " +
                    " CMLotusNotes              AS [Lotus Notes], " +
                    " CMTitleDescription        AS [Title], " +
                    " c.CMCompanyName           AS [Company], " +             
                    " CMDepartmentDescription   AS [Department], " +
                    " CMIndustryDescription     AS [Industry], " +
                    " CMCompanyRegion           AS [Region], " +
                    " CMTerritoryDescription    AS [Territory], " +
                    " CMStatusDescription       AS [Status], " +
                    " CMReferredByDescription   AS [Referred By], " +     
                    " CMContactPhone            AS [Phone], " +          
                    " CMContactPhoneExtension   AS [Ext], " +
                    " CMContactMobile           AS [Mobile], " +         
                    " CMContactFax              AS [Fax], " +            
                    " CMContactAddress          AS [Address], " +        
                    " CMContactAddress2         AS [Address2], " +      
                    " CMContactCity             AS [City], " +          
                    " CMContactState            AS [State], " +          
                    " CMContactZip              AS [Zip] " +            
                    " FROM  tblCMContact cc  " +
                    " LEFT JOIN tblCMCompany c ON cc.CMCompanyID = c.CMCompanyID " +
                    " LEFT JOIN tblCMStatus s ON cc.CMContactStatus = s.CMStatusID " +
                    " LEFT JOIN tblCMReferredBy r ON cc.CMContactReferredBy = r.CMReferredByID " +
                    " LEFT JOIN tblCMIndustry i ON c.CMCompanyIndustry = i.CMIndustryID " +
                    " LEFT JOIN tblCMDepartment d ON cc.CMContactDepartment = d.CMDepartmentID " +
                    " LEFT JOIN tblCMTerritory t ON c.CMCompanyTerritory = t.CMTerritoryID " +
                    " LEFT JOIN tblCMTitle tt ON cc.CMContactTitle = tt.CMTitleID " +
                   where + " " +
                    " ORDER BY CMContactLastName ";
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
        public static DataSet GetCMContact(string cmContactID)
        {
            string query = "";

            query = " SELECT CMContactID, " +
                    " CMCompanyID               AS [Company], " +
                    " CMContactLastName         AS [Last Name], " +
                    " CMContactFirstName        AS [First Name], " +
                    " CMContactInitial          AS [Initial], " +
                    " CMContactSalutation       AS [Salutation], " +
                    " CMContactKeyContact       AS [Key Contact], " +
                    " CMLotusNotes              AS [Lotus Notes], " +
                    " CMContactTitle            AS [Title], " +
                    " CMContactDepartment       AS [Department], " +
                    " CMContactStatus           AS [Status], " +
                    " CMContactReferredBy       AS [Referred By], " +
                    " CMContactPhone            AS [Phone], " +
                    " CMContactPhoneExtension   AS [Ext], " +
                    " CMContactMobile           AS [Mobile], " +
                    " CMContactFax              AS [Fax], " +
                    " CMContactEmail            AS [Email], " +
                    " CMContactWebSite          AS [Web Site], " +
                    " CMContactAddress          AS [Address], " +
                    " CMContactAddress2         AS [Address2], " +
                    " CMContactCity             AS [City], " +
                    " CMContactState            AS [State], " +
                    " CMContactZip              AS [Zip], " +
                    " CMContactCountry          AS [Country], " +
                    " CMContactCreateDate       AS [Create Date], " +
                    " CMContactCreateBy         AS [Create By], " +
                    " CMContactEditDate         AS [Edit Date], " +
                    " CMContactEditBy           AS [Edit By] " +
                    " FROM  tblCMContact  " +
                    " WHERE CMContactID = " + cmContactID + " ";
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
